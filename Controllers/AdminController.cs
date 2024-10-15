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


namespace FORMULARIOCENSI.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
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
            if(objFormulario == null){
                return NotFound();
            }
            return View(objFormulario);
        }

        // POST: Admin/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id,[Bind("Id,Titulo,DatosPaciente,Sinopsis,Base,Estado1,Estado2,Estado3,Estado4,Estado5,Estado6,Estado7,Autores,HistoriaClinica,SituaciónTriaje,NotaHospitalizacion,SignosVitales,EstadoGeneral,Cardiovascular,Cuello,Respiratorio,Abdomen,GenitoUrinario,AparatoLocomotor,Piel,Neurologico,Endovenoso,Laboratorios,Recomendaciones,Ordenes,CompetenciaGeneral,Objetivos,Identificar,Distinguir,Discriminar,Actuar,Usar,Aplicar,MedidasEsenciales,Baseline,Estado1Desem,Estado2Desem,Estado3Desem,Estado4Desem,Estado5Desem,Estado6Desem,Estado7Desem,Estado8Desem,Preguntas,Equipos,Confederado,Definiciones,Herramientas,MonitorDesfibrilador,Enfoque,Control,Bibliografía,PuntosDebriefing,Aprendizaje,Referencias,Escenarios")] Formulario objFormulario)
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
    }
}
