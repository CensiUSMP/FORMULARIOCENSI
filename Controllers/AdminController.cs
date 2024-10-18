using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FORMULARIOCENSI.Data;
using FORMULARIOCENSI.Models;
using Microsoft.AspNetCore.Authorization;
using DinkToPdf;
using DinkToPdf.Contracts;
using System.Text;


namespace FORMULARIOCENSI.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IConverter _converter;

        public AdminController(ApplicationDbContext context, IConverter converter)
        {
            _context = context;
            _converter = converter;
        }

        // GET: Admin
        public async Task<IActionResult> Index()
        {
            return View(await _context.DataFormulario.ToListAsync());
        }

        // GET: Admin/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formulario = await _context.DataFormulario
                .FirstOrDefaultAsync(m => m.Id == id);
            if (formulario == null)
            {
                return NotFound();
            }

            return View(formulario);
        }

        // GET: Admin/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Titulo,DatosPaciente,Sinopsis,Base,Estado1,Estado2,Estado3,Estado4,Estado5,Estado6,Estado7,Autores,HistoriaClinica,SituaciónTriaje,NotaHospitalizacion,SignosVitales,EstadoGeneral,Cardiovascular,Cuello,Respiratorio,Abdomen,GenitoUrinario,AparatoLocomotor,Piel,Neurologico,Endovenoso,Laboratorios,Recomendaciones,Ordenes,CompetenciaGeneral,Objetivos,Identificar,Distinguir,Discriminar,Actuar,Usar,Aplicar,MedidasEsenciales,Baseline,Estado1Desem,Estado2Desem,Estado3Desem,Estado4Desem,Estado5Desem,Estado6Desem,Estado7Desem,Estado8Desem,Preguntas,Equipos,Confederado,Definiciones,Herramientas,MonitorDesfibrilador,Enfoque,Control,Bibliografía,PuntosDebriefing,Aprendizaje,Referencias,Escenarios")] Formulario formulario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(formulario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(formulario);
        }

        // GET: Admin/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            Formulario objFormulario = _context.DataFormulario.Find(id);
            if (objFormulario == null)
            {
                return NotFound();
            }
            return View(objFormulario);
        }

        // POST: Admin/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Titulo,DatosPaciente,Sinopsis,Base,Estado1,Estado2,Estado3,Estado4,Estado5,Estado6,Estado7,Autores,HistoriaClinica,SituaciónTriaje,NotaHospitalizacion,SignosVitales,EstadoGeneral,Cardiovascular,Cuello,Respiratorio,Abdomen,GenitoUrinario,AparatoLocomotor,Piel,Neurologico,Endovenoso,Laboratorios,Recomendaciones,Ordenes,CompetenciaGeneral,Objetivos,Identificar,Distinguir,Discriminar,Actuar,Usar,Aplicar,MedidasEsenciales,Baseline,Estado1Desem,Estado2Desem,Estado3Desem,Estado4Desem,Estado5Desem,Estado6Desem,Estado7Desem,Estado8Desem,Preguntas,Equipos,Confederado,Definiciones,Herramientas,MonitorDesfibrilador,Enfoque,Control,Bibliografía,PuntosDebriefing,Aprendizaje,Referencias,Escenarios")] Formulario objFormulario)
        {
            _context.Update(objFormulario);
            _context.SaveChanges();
            ViewData["Message"] = "El formulario ya esta actualizado";
            return View(objFormulario);
        }

        // GET: Admin/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formulario = await _context.DataFormulario
                .FirstOrDefaultAsync(m => m.Id == id);
            if (formulario == null)
            {
                return NotFound();
            }

            return View(formulario);
        }

        // POST: Admin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var formulario = await _context.DataFormulario.FindAsync(id);
            if (formulario != null)
            {
                _context.DataFormulario.Remove(formulario);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FormularioExists(int id)
        {
            return _context.DataFormulario.Any(e => e.Id == id);
        }
        public IActionResult ExportPdf(int id)
        {
            var formulario = _context.DataFormulario.FirstOrDefault(f => f.Id == id);

            if (formulario == null)
            {
                return NotFound();
            }

            var baseUrl = $"{Request.Scheme}://{Request.Host}";
var logoUrl = $"{baseUrl}/images/logo.jpeg";




            // Crear contenido HTML para el PDF
            var htmlContent = $@"
<!DOCTYPE html>
<html lang='es'>
<head>
    <meta charset='utf-8' />
    <title>Formulario - {formulario.Titulo}</title>
    <style>
        body {{ font-family: Arial, sans-serif; }}
        table {{ width: 100%; border-collapse: collapse; }}
        td, th {{ padding: 10px; border: 1px solid #000; }}
        h1 {{ font-size: 1.2em; margin: 0; }}
        .logo {{ text-align: left; }}
        .logo img {{ width: 120px; }}
        .info-table {{ text-align: right; font-size: 0.9em; }}
        .center-text {{ text-align: center; }}
        .highlight {{ color: #007bff; text-decoration: underline; }}
    </style>
</head>
<body>
    <table>
        <tr>
            <td class='logo'>
                <img src='{logoUrl}' alt='USMP Logo'>
            </td>
            <td class='center-text'>
                <h1>Formulario de desarrollo de ECS<br />FRT_002</h1>
                <p><a href='#' class='highlight'>{formulario.Titulo}</a></p>
            </td>
            <td class='info-table'>
                <p><strong>Código:</strong> FRT_002</p>
                <p><strong>Versión:</strong> 1.0</p>
                <p><strong>Fecha:</strong> febrero 2024</p>
                <p><strong>Página:</strong> 1</p>
            </td>
        </tr>
    </table>

    <hr />

    <section>
        <h2>Descripción del paciente:</h2>
        <p>{formulario.DatosPaciente.Replace(Environment.NewLine, "<br />")}</p>
        <h1>Resumen del caso</h1>
        <h2>Sinopsis</h2>
        <p>{formulario.Sinopsis.Replace(Environment.NewLine, "<br />")}</p>
        <h2>En estadio paciente Base:</h2>
        <p>{formulario.Base.Replace(Environment.NewLine, "<br />")}</p>
        <h2>En el Estado 1: Inicio de la atención</h2>
        <p>{formulario.Estado1.Replace(Environment.NewLine, "<br />")}</p>
        <h2>En el Estado 2: TV estable</h2>
        <p>{formulario.Estado2.Replace(Environment.NewLine, "<br />")}</p>
        <h2>Estado 3: Amiodarona o lidocaína administrada</h2>
        <p>{formulario.Estado3.Replace(Environment.NewLine, "<br />")}</p>
        <h2>Estado 4: No mejoría de la TV</h2>
        <p>{formulario.Estado4.Replace(Environment.NewLine, "<br />")}</p>
        <h2>Estado 5: Paciente recuperado</h2>
        <p>{formulario.Estado5.Replace(Environment.NewLine, "<br />")}</p>
        <h2>Estado 6: No mejoría de la TV 2da dosis de amiodarona</h2>
        <p>{formulario.Estado6.Replace(Environment.NewLine, "<br />")}</p>
        <h2>Estado 7: Paciente recuperado luego de cardioversión eléctrica sincronizada</h2>
        <p>{formulario.Estado7.Replace(Environment.NewLine, "<br />")}</p>
        <h1>Autores</h1>
        <p>{formulario.Autores.Replace(Environment.NewLine, "<br />")}</p>
        <h1>Antecedentes del Paciente</h1>
        <h2>Historia clínica del paciente</h2>
        <p>{formulario.HistoriaClinica.Replace(Environment.NewLine, "<br />")}</p>
        <h2>Nota de ingreso</h2>
        <h2>Situación en triaje:</h2>
        <p>{formulario.SituaciónTriaje.Replace(Environment.NewLine, "<br />")}</p>
        <h2>Nota de hospitalización:</h2>
        <p>{formulario.NotaHospitalizacion.Replace(Environment.NewLine, "<br />")}</p>
        <h2>A la evaluación:</h2>
        <h2>Signos vitales:</h2>
        <p>{formulario.SignosVitales.Replace(Environment.NewLine, "<br />")}</p>
        <h2>Estado general:</h2>
        <p>{formulario.EstadoGeneral.Replace(Environment.NewLine, "<br />")}</p>
        <h2>Cardiovascular</h2>
        <p>{formulario.Cardiovascular.Replace(Environment.NewLine, "<br />")}</p>
        <h2>Cuello:</h2>
        <p>{formulario.Cuello.Replace(Environment.NewLine, "<br />")}</p>
        <h2>Respiratorio:</h2>
        <p>{formulario.Respiratorio.Replace(Environment.NewLine, "<br />")}</p>
        <h2>Abdomen:</h2>
        <p>{formulario.Abdomen.Replace(Environment.NewLine, "<br />")}</p>
        <h2>Genito-Urinario:</h2>
        <p>{formulario.GenitoUrinario.Replace(Environment.NewLine, "<br />")}</p>
        <h2>Aparato Locomotor:</h2>
        <p>{formulario.AparatoLocomotor.Replace(Environment.NewLine, "<br />")}</p>
        <h2>Piel:</h2>
        <p>{formulario.Piel.Replace(Environment.NewLine, "<br />")}</p>
        <h2>Neurológico:</h2>
        <p>{formulario.Neurologico.Replace(Environment.NewLine, "<br />")}</p>
        <h2>Endovenoso</h2>
        <p>{formulario.Endovenoso.Replace(Environment.NewLine, "<br />")}</p>
        <h2>Laboratorios:</h2>
        <p>{formulario.Laboratorios.Replace(Environment.NewLine, "<br />")}</p>
        <h2>Recomendaciones:</h2>
        <p>{formulario.Recomendaciones.Replace(Environment.NewLine, "<br />")}</p>
        <h1>Órdenes</h1>
        <h2>Orden inicial del médico tratante:</h2>
        <p>{formulario.Ordenes.Replace(Environment.NewLine, "<br />")}</p>
        <h1>Preparación</h1>
        <h1>Objetivos del aprendizaje</h1>
        <h2>Competencia General:</h2>
        <p>{formulario.CompetenciaGeneral.Replace(Environment.NewLine, "<br />")}</p>
        <h2>Objetivos:</h2>
        <p>{formulario.Objetivos.Replace(Environment.NewLine, "<br />")}</p>
        <h2>Identificar y diagnosticar</h2>
        <p>{formulario.Identificar.Replace(Environment.NewLine, "<br />")}</p>
        <h2>Distinguir diagnósticos diferenciales</h2>
        <p>{formulario.Distinguir.Replace(Environment.NewLine, "<br />")}</p>
        <h2>Discriminar y contrastar</h2>
        <p>{formulario.Discriminar.Replace(Environment.NewLine, "<br />")}</p>
        <h2>Actuar</h2>
        <p>{formulario.Actuar.Replace(Environment.NewLine, "<br />")}</p>
        <h2>Usar</h2>
        <p>{formulario.Usar.Replace(Environment.NewLine, "<br />")}</p>
        <h2>Aplicar</h2>
        <p>{formulario.Aplicar.Replace(Environment.NewLine, "<br />")}</p>
        <h1>Desempeño como medida del aprendizaje</h1>
        <h2>Medidas esenciales de rendimiento del escenario</h2>
        <p>{formulario.MedidasEsenciales.Replace(Environment.NewLine, "<br />")}</p>
        <h2>Base line: Evaluación inicial</h2>
        <p>{formulario.Baseline.Replace(Environment.NewLine, "<br />")}</p>
        <h2>Estado 1: Inicio de atención</h2>
        <p>{formulario.Estado1Desem.Replace(Environment.NewLine, "<br />")}</p>
        <h2>Estado 2: TV estable</h2>
        <p>{formulario.Estado2Desem.Replace(Environment.NewLine, "<br />")}</p>
        <h2>Estado 3: Amiodarona administrada</h2>
        <p>{formulario.Estado3Desem.Replace(Environment.NewLine, "<br />")}</p>
        <h2>Estado 4: No Mejoría de la TV</h2>
        <p>{formulario.Estado4Desem.Replace(Environment.NewLine, "<br />")}</p>
        <h2>Estado 5: Paciente recuperado</h2>
        <p>{formulario.Estado5Desem.Replace(Environment.NewLine, "<br />")}</p>
        <h2>Estado 6: No mejoría de la TV 2da dosis de infusión de amiodarona</h2>
        <p>{formulario.Estado6Desem.Replace(Environment.NewLine, "<br />")}</p>
        <h2>Estado 7: Paciente recuperado de 2da dosis de infusión de amiodarona</h2>
        <p>{formulario.Estado7Desem.Replace(Environment.NewLine, "<br />")}</p>
        <h2>Estado 8: Paciente que no recibe terapia</h2>
        <p>{formulario.Estado8Desem.Replace(Environment.NewLine, "<br />")}</p>
        <h1>Preguntas de preparación</h1>
        <p>{formulario.Preguntas.Replace(Environment.NewLine, "<br />")}</p>
        <h2>Equipos y suministros</h2>
        <p>{formulario.Equipos.Replace(Environment.NewLine, "<br />")}</p>
        <h2>Confederados</h2>
        <p>{formulario.Confederado.Replace(Environment.NewLine, "<br />")}</p>
        <h1>Notas</h1>
        <h1>Notas del facilitador</h1>
        <h2>Definiciones</h2>
        <p>{formulario.Definiciones.Replace(Environment.NewLine, "<br />")}</p>
        <h2>Herramientas</h2>
        <p>{formulario.Herramientas.Replace(Environment.NewLine, "<br />")}</p>
        <h2>Motor-desfibrilador</h2>
        <p>{formulario.MonitorDesfibrilador.Replace(Environment.NewLine, "<br />")}</p>
        <h2>Enfoque de caso: recepción</h2>
        <p>{formulario.Enfoque.Replace(Environment.NewLine, "<br />")}</p>
        <h2>Control post terapia:</h2>
        <p>{formulario.Control.Replace(Environment.NewLine, "<br />")}</p>
        <h2>Bibliografía</h2>
        <p>{formulario.Bibliografía.Replace(Environment.NewLine, "<br />")}</p>
        <h1>Puntos de debriefing</h1>
        <h2>El facilitador debe empezar dando una introducción sobre el proceso de debriefing</h2>
        <p>{formulario.PuntosDebriefing.Replace(Environment.NewLine, "<br />")}</p>
        <h1>Aprendizaje - preguntas y respuestas</h1>
        <p>{formulario.Aprendizaje.Replace(Environment.NewLine, "<br />")}</p>
        <h2>Referencias bibliográficas</h2>
        <p>{formulario.Referencias.Replace(Environment.NewLine, "<br />")}</p>
        <h2>Escenarios precargados</h2>
        <p>{formulario.Escenarios.Replace(Environment.NewLine, "<br />")}</p>
    </section>
</body>
</html>";



            // Configuración del documento PDF
            var pdfDocument = new HtmlToPdfDocument()
{
    GlobalSettings = new GlobalSettings
    {
        PaperSize = PaperKind.A4,
        Orientation = Orientation.Portrait,
        Margins = new MarginSettings { Top = 10, Bottom = 10 }
    },
    Objects = {
        new ObjectSettings
        {
            PagesCount = true,
            HtmlContent = htmlContent, // Asegúrate de que esto sea el HTML correcto
            WebSettings = { DefaultEncoding = "utf-8" },
            FooterSettings = { Right = "Página [page] de [toPage]" }
        }
    }
};


            // Convertir HTML a PDF y devolver el archivo
            var pdf = _converter.Convert(pdfDocument);
            return File(pdf, "application/pdf", "Formulario.pdf");
        }
    }
}
