using iText.Kernel.Font;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Kernel.Colors;
using Microsoft.AspNetCore.Mvc;
using iText.IO.Font.Constants;
using Microsoft.EntityFrameworkCore;
using FORMULARIOCENSI.Data;
using FORMULARIOCENSI.Models;
using iText.IO.Image;
using iText.Layout.Properties;
using iText.Layout.Borders;
using iText.Kernel.Pdf.Canvas.Draw;
using iText.Kernel.Events;
using Microsoft.AspNetCore.Authorization;


namespace FORMULARIOCENSI.Controllers
{
    [Authorize]
    public class PdfDownloadController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _env;

        public PdfDownloadController(ApplicationDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.DataFormulario.ToListAsync());
        }

        public async Task<IActionResult> ExportPdf(int id)
        {
            var formulario = await _context.DataFormulario
                .Include(f => f.Estados)
                .Include(f => f.Estadosa)
                .Include(f => f.Dialogo)
                .Include(f => f.Status)
                .FirstOrDefaultAsync(f => f.Id == id);

            if (formulario == null)
            {
                return NotFound();
            }

            var memoryStream = new MemoryStream();
            var writer = new PdfWriter(memoryStream);
            var pdf = new PdfDocument(writer);
            var document = new Document(pdf, PageSize.A4);
            document.SetMargins(100, 35, 35, 35);

            string pathLogo = System.IO.Path.Combine(_env.WebRootPath ?? "wwwroot", "images", "logo.jpeg");
            Image img = new Image(ImageDataFactory.Create(pathLogo));
            pdf.AddEventHandler(PdfDocumentEvent.START_PAGE, new HeaderEventHandler1(img, formulario.Titulo));
            pdf.AddEventHandler(PdfDocumentEvent.END_PAGE, new WatermarkEventHandler());



            PdfFont font = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);
            PdfFont boldFont = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);




            // Función helper para agregar secciones
            void AddSection(string title, string content)
            {
                if (!string.IsNullOrEmpty(content))
                {
                    document.Add(new Paragraph(title)
                        .SetFont(boldFont)
                        .SetFontSize(12)
                        .SetMarginTop(10));
                    document.Add(new Paragraph(content)
                        .SetFont(font)
                        .SetFontSize(10));
                }
            }

            // Resumen del caso
            document.Add(new Paragraph("Resumen del caso").SetFont(boldFont).SetFontSize(12).SetMarginTop(10));
            AddSection("Sinopsis", formulario.Sinopsis);

            // Estados
            if (formulario.Estados != null && formulario.Estados.Any())
            {
                document.Add(new Paragraph("Estados").SetFont(boldFont).SetFontSize(12).SetMarginTop(10));
                foreach (var estado in formulario.Estados)
                {
                    document.Add(new Paragraph($"Estado {estado.Numero}: {estado.Nombre}")
                        .SetFont(boldFont)
                        .SetFontSize(11));
                    document.Add(new Paragraph(estado.Descripcion)
                        .SetFont(font)
                        .SetFontSize(10));
                }
            }

            // Imagen del flujograma
            if (formulario.Imagen != null)
            {
                document.Add(new Paragraph("Flujograma").SetFont(boldFont).SetFontSize(12).SetMarginTop(10));
                var imageData = ImageDataFactory.Create(formulario.Imagen);
                var image = new Image(imageData);
                image.SetWidth(300);
                document.Add(image);
            }

            // Datos básicos
            AddSection("Autores", formulario.Autores);
            AddSection("Historial médico", formulario.Historial_medico);
            AddSection("Alergias", formulario.Alergias);
            AddSection("Medicamentos", formulario.Medicamentos);
            AddSection("Historia familiar/social", formulario.Historia_familiar);

            // Nota de ingreso
            document.Add(new Paragraph("Nota de ingreso").SetFont(boldFont).SetFontSize(12).SetMarginTop(10));
            AddSection("Situación", formulario.Situacion);
            AddSection("Nota de hospitalización", formulario.Nota_de_hospitalizacion);

            // Examen físico
            document.Add(new Paragraph("Examen físico").SetFont(boldFont).SetFontSize(12).SetMarginTop(10));
            AddSection("Signos vitales", formulario.Signos_vitales);
            AddSection("Estado general", formulario.Estado_general);
            AddSection("Piel", formulario.Piel);
            AddSection("Tórax", formulario.Torax);
            AddSection("Cervical", formulario.CV);
            AddSection("Abdomen", formulario.Abdomen);
            AddSection("Neurológico", formulario.Neurologico);
            AddSection("Laboratorio", formulario.Laboratorio);

            // Segunda imagen
            if (formulario.Imagena != null)
            {
                document.Add(new Paragraph("Imágenes").SetFont(boldFont).SetFontSize(12).SetMarginTop(10));
                var imageData = ImageDataFactory.Create(formulario.Imagena);
                var image = new Image(imageData);
                image.SetWidth(300);
                document.Add(image);
            }

            AddSection("Órdenes", formulario.Orden_inicial);

            // Preparación y objetivos
            document.Add(new Paragraph("Preparación").SetFont(boldFont).SetFontSize(12).SetMarginTop(10));
            document.Add(new Paragraph("Objetivos del aprendizaje").SetFont(boldFont).SetFontSize(12));
            AddSection("Distinguir", formulario.Distinguir);
            AddSection("Indicar", formulario.Indicar);
            AddSection("Analizar", formulario.Analizar);
            AddSection("Evaluación", formulario.Evaluación);
            AddSection("Aplicar", formulario.Aplicar);

            // Desempeño
            document.Add(new Paragraph("Desempeño como medida del aprendizaje").SetFont(boldFont).SetFontSize(12).SetMarginTop(10));
            AddSection("Medidas esenciales", formulario.Medidas_esenciales);
            AddSection("Baseline", formulario.Baseline);

            // Estados A
            if (formulario.Estadosa != null && formulario.Estadosa.Any())
            {
                document.Add(new Paragraph("Estados").SetFont(boldFont).SetFontSize(12).SetMarginTop(10));
                foreach (var estadoa in formulario.Estadosa)
                {
                    document.Add(new Paragraph($"Estado {estadoa.Numero}: {estadoa.Nombre}")
                        .SetFont(boldFont)
                        .SetFontSize(11));
                    document.Add(new Paragraph(estadoa.Descripcion)
                        .SetFont(font)
                        .SetFontSize(10));
                }
            }

            AddSection("Preguntas de preparación", formulario.Preguntas_de_preparacion);
            AddSection("Equipos de suministro", formulario.Equipos_de_suministro);


            // Diálogo
            if (formulario.Dialogo != null && formulario.Dialogo.Any())
            {
                document.Add(new Paragraph("Guión").SetFont(boldFont).SetFontSize(12).SetMarginTop(10));
                Table dialogoTable = new Table(2).UseAllAvailableWidth();
                dialogoTable.AddCell(new Cell().Add(new Paragraph("Personaje")).SetBackgroundColor(ColorConstants.YELLOW));
                dialogoTable.AddCell(new Cell().Add(new Paragraph("Guión")).SetBackgroundColor(ColorConstants.YELLOW));

                foreach (var dialogo in formulario.Dialogo)
                {
                    dialogoTable.AddCell(new Cell().Add(new Paragraph(dialogo.Personaje)));
                    dialogoTable.AddCell(new Cell().Add(new Paragraph(dialogo.Guion)));
                }
                document.Add(dialogoTable);
            }

            // Add this section right after the Status section, before document.Close()

            // Text Extraction Section
            

            // Resto de secciones
            AddSection("Confederado", formulario.Confederado);

            if (!string.IsNullOrEmpty(formulario.ArchivoTextoExtraido))
            {
                document.Add(new Paragraph("Texto Extraído")
                    .SetFont(boldFont)
                    .SetFontSize(12)
                    .SetMarginTop(10));

                // Create a pre-formatted text block
                Table textTable = new Table(1).UseAllAvailableWidth();

                // Style for monospace text
                PdfFont courierFont = PdfFontFactory.CreateFont(StandardFonts.COURIER);

                Cell textCell = new Cell()
                    .Add(new Paragraph(formulario.ArchivoTextoExtraido)
                        .SetFont(courierFont)
                        .SetFontSize(9)
                        .SetFixedLeading(12)) // Line height
                    .SetPadding(10)
                    .SetBackgroundColor(new DeviceRgb(245, 245, 245)); // Light gray background

                textTable.AddCell(textCell);
                document.Add(textTable);
            }

            // Handle PDF file display if text extraction is not available
            else if (formulario.Archivo != null)
            {
                document.Add(new Paragraph("Archivo Original")
                    .SetFont(boldFont)
                    .SetFontSize(12)
                    .SetMarginTop(10));

                if (formulario.ArchivoName.EndsWith(".pdf", StringComparison.OrdinalIgnoreCase))
                {
                    // Add a note about the original PDF
                    document.Add(new Paragraph($"Archivo PDF original: {formulario.ArchivoName}")
                        .SetFont(font)
                        .SetFontSize(10)
                        .SetMarginBottom(5));
                }
                else
                {
                    // Add information about non-PDF attachment
                    document.Add(new Paragraph($"Archivo adjunto: {formulario.ArchivoName}")
                        .SetFont(font)
                        .SetFontSize(10)
                        .SetMarginBottom(5));
                }
            }

            AddSection("Introducción", formulario.Introduccion);
            AddSection("Emociones", formulario.Emociones);
            AddSection("Descripción", formulario.Descripcion);
            AddSection("Análisis", formulario.Analisis);
            AddSection("Síntesis", formulario.Sintesis);
            AddSection("Preguntas del debriefing", formulario.PreguntasDD);
            AddSection("Baseline Aprendizaje", formulario.BaselineApren);

            // Status
            if (formulario.Status != null && formulario.Status.Any())
            {
                document.Add(new Paragraph("Estados").SetFont(boldFont).SetFontSize(12).SetMarginTop(10));
                foreach (var status in formulario.Status)
                {
                    document.Add(new Paragraph($"Estado {status.Numero}: {status.Nombre}")
                        .SetFont(boldFont)
                        .SetFontSize(11));
                    document.Add(new Paragraph(status.Descripcion)
                        .SetFont(font)
                        .SetFontSize(10));
                }
            }

            AddSection("Referencias bibliográficas", formulario.ReferenciasB);
            AddSection("Escenarios precargados", formulario.EscenariosP);

            // Lista de chequeo (imagen)
            if (formulario.Imagenc != null)
            {
                document.Add(new Paragraph("Lista de chequeo").SetFont(boldFont).SetFontSize(12).SetMarginTop(10));
                var imageData = ImageDataFactory.Create(formulario.Imagenc);
                var image = new Image(imageData);
                image.SetWidth(300);
                document.Add(image);
            }

            document.Close();

            var bytes = memoryStream.ToArray();
            memoryStream.Dispose();
            return File(bytes, "application/pdf", $"Formulario_{formulario.Titulo}_{DateTime.Now:yyyyMMdd}.pdf");
        }



        public class HeaderEventHandler1 : IEventHandler
        {
            Image Img;
            string Titulo;

            public HeaderEventHandler1(Image img, string titulo)
            {
                Img = img;
                Titulo = titulo ?? "";

            }

            public void HandleEvent(Event @event)
            {
                PdfDocumentEvent docEvent = (PdfDocumentEvent)@event;
                PdfDocument pdfDoc = docEvent.GetDocument();
                PdfPage page = docEvent.GetPage();

                // Increase bottom margin of header area
                Rectangle rootArea = new Rectangle(
    35,                                       // Left position
    page.GetPageSize().GetTop() - 100,         // Adjust top position lower
    page.GetPageSize().GetRight() - 70,       // Width
    70                                        // Height of header
);
                Canvas canvas = new Canvas(page, rootArea);
                canvas.Add(getTable(docEvent)).Close();
            }

            public Table getTable(PdfDocumentEvent docEvent)
            {
                float[] cellWidth = { 40f, 80f, 40f };
                Table tableEvent = new Table(UnitValue.CreatePercentArray(cellWidth)).UseAllAvailableWidth();

                Style styleCell = new Style().SetBorder(Border.NO_BORDER);

                Style styleText = new Style().SetTextAlignment(TextAlignment.RIGHT).SetFontSize(10f);

                Cell cell = new Cell().Add(Img.SetAutoScale(true)).SetBorder(new SolidBorder(ColorConstants.BLACK, 1));

                tableEvent.AddCell(cell.AddStyle(styleCell).SetTextAlignment(TextAlignment.LEFT));
                PdfFont bold = PdfFontFactory.CreateFont(StandardFonts.TIMES_BOLD);

                Cell cellCenter = new Cell()
        .Add(new Paragraph("Formulario de desarrollo de ECS").SetFont(bold))
        .Add(new Paragraph("FRT_002").SetFont(bold))
        .Add(new Paragraph(Titulo).SetFont(bold))
        .SetTextAlignment(TextAlignment.CENTER)
        .SetBorder(new SolidBorder(ColorConstants.BLACK, 1));
                tableEvent.AddCell(cellCenter);

                cell = new Cell().Add(new Paragraph("Código: FRT_002\n").SetFont(bold)).Add(new Paragraph("Versión: 1.0\n").SetFont(bold)).AddStyle(styleText).AddStyle(styleCell).SetBorder(new SolidBorder(ColorConstants.BLACK, 1));

                tableEvent.AddCell(cell);

                return tableEvent;
            }
        }

        public class WatermarkEventHandler : IEventHandler
        {
            public void HandleEvent(Event @event)
            {
                PdfDocumentEvent docEvent = (PdfDocumentEvent)@event;
                PdfDocument pdfDoc = docEvent.GetDocument();
                PdfPage page = docEvent.GetPage();

                Canvas canvas = new Canvas(page, page.GetPageSize());
                PdfFont font = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);
                string watermarkPath = System.IO.Path.Combine("wwwroot", "images", "USMP.png");
                ImageData imageData = ImageDataFactory.Create(watermarkPath);
                Image watermark = new Image(imageData);

                // Escalar la imagen a un tamaño más pequeño (ejemplo: 200x100)
                watermark.ScaleToFit(700, 400);

                // Posicionar la imagen centrada en la página
                float x = (page.GetPageSize().GetWidth() - watermark.GetImageScaledWidth()) / 2;
                float y = (page.GetPageSize().GetHeight() - watermark.GetImageScaledHeight()) / 2;
                watermark.SetFixedPosition(x, y);

                // Opcional: Hacerla semitransparente
                watermark.SetOpacity(0.3f);

                canvas.Add(watermark);


            }
        }

    }
}