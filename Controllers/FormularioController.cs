using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FORMULARIOCENSI.Models;
using FORMULARIOCENSI.Data;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace FORMULARIOCENSI.Controllers
{
    [Authorize]
    public class FormularioController : Controller

    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public FormularioController(ApplicationDbContext context, UserManager<IdentityUser>userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public IActionResult Index2()
        {
            return View(_context.DataFormulario.ToList());
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Formulario objFormulario)
        {
            _context.Add(objFormulario);
            _context.SaveChanges();
            ViewData["Message"] = "El formulario ya esta registrado";

            
            return RedirectToAction(nameof(Index2));
        }
        public IActionResult Edit(int id)
        {
            Formulario objFormulario = _context.DataFormulario.Find(id);
            if(objFormulario == null){
                return NotFound();
            }
            return View(objFormulario);
        }
        [HttpPost]
        public IActionResult Edit(int id,[Bind("Id,Sinopsis,Autores,HistoriaClinica,NotaIngreso,Ordenes,Objetivos,Desempeño,Preguntas,Equipos,Guión,Confederado,NotasFacilitador,PuntosDebriefing,Aprendizaje,Referencias,Escenarios")] Formulario objFormulario)
        {
             _context.Update(objFormulario);
             _context.SaveChanges();
              ViewData["Message"] = "El formulario ya esta actualizado";
             return View(objFormulario);
        }
        public IActionResult Delete(int id)
        {
            Formulario objFormulario = _context.DataFormulario.Find(id);
            _context.DataFormulario.Remove(objFormulario);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index2));
        }
    }

}