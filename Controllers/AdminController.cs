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
        body {{ font-family: Arial, sans-serif; line-height: 1.5; }}
        header {{ text-align: center; }}
        h1 {{ font-size: 1.5em; }}
        p {{ margin: 10px 0; }}
        hr {{ border: 1px solid #000; }}
        section {{ margin-bottom: 20px; }}
    </style>
</head>
<body>
    <header>
        <img src='{logoUrl}' alt='Logo' height='50' width='320'/>

        <h1>Formulario de desarrollo de ECS</h1>
        <p>Código: FRT_002</p>
        <p>Versión: 1.0</p>
        <p>Fecha: febrero 2024</p>
        <p>Página: 1</p>
    </header>

    <hr />

    <section>
        <h2>Descripción del paciente:</h2>
        <p>Datos del paciente:<br /> {formulario.DatosPaciente.Replace(Environment.NewLine, "<br />")}</p>
    </section>

    <section>
        <h2>Examen físico:</h2>
        <p>ARGC: {formulario.DatosPaciente.Replace(Environment.NewLine, "<br />")}</p>
        <p>BEH: {formulario.Sinopsis.Replace(Environment.NewLine, "<br />")}</p>
        <p>BEN: {formulario.Base.Replace(Environment.NewLine, "<br />")}</p>
    </section>

    <section>
        <h2>Diagnóstico:</h2>
        <p>{formulario.HistoriaClinica.Replace(Environment.NewLine, "<br />")}</p>
    </section>

    <section>
        <h2>Estado de atención:</h2>
        <p>{formulario.EstadoGeneral.Replace(Environment.NewLine, "<br />")}</p>
    </section>

    <footer>
        <p>Confidencial - Solo para uso médico</p>
    </footer>
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
