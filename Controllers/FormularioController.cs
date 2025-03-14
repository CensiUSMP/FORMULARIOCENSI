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
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Parser;
using iText.Kernel.Pdf.Canvas.Parser.Listener;
using RazorEngine;
using RazorEngine.Templating;
using System.Security.Claims;

namespace FORMULARIOCENSI.Controllers
{
    [Authorize(Roles = "User")] 
    public class FormularioController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public FormularioController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        [Authorize]
        public async Task<IActionResult> Index2()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            return View(await _context.DataFormulario
                .Where(f => f.UserId == userId)
                .ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var formulario = await _context.DataFormulario
                .Include(p => p.Estados)
                .Include(p => p.Estadosa)
                .Include(p => p.Dialogo)
                .Include(p => p.Status)
                .FirstOrDefaultAsync(m => m.Id == id && m.UserId == userId);
            if (formulario == null)
            {
                return NotFound();
            }

            return View(formulario);
        }

        public IActionResult GetImage(int id)
        {
            var prueba = _context.DataFormulario.FirstOrDefault(p => p.Id == id);

            if (prueba == null || prueba.Imagen == null)
            {
                return NotFound();
            }

            return File(prueba.Imagen, "image/jpeg"); // Ajusta el tipo MIME según sea necesario
        }
        public IActionResult GetImagea(int id)
        {
            var prueba = _context.DataFormulario.FirstOrDefault(p => p.Id == id);

            if (prueba == null || prueba.Imagena == null)
            {
                return NotFound();
            }

            return File(prueba.Imagena, "image/jpeg"); // Ajusta el tipo MIME según sea necesario
        }
        public IActionResult GetImagec(int id)
        {
            var prueba = _context.DataFormulario.FirstOrDefault(p => p.Id == id);

            if (prueba == null || prueba.Imagenc == null)
            {
                return NotFound();
            }

            return File(prueba.Imagenc, "image/jpeg"); // Ajusta el tipo MIME según sea necesario
        }

        [HttpGet]
        public IActionResult GetArchivo(int id)
        {
            var prueba = _context.DataFormulario.Find(id);
            if (prueba == null || prueba.Archivo == null)
            {
                return NotFound();
            }

            string contentType;
            var extension = Path.GetExtension(prueba.ArchivoName).ToLower();

            switch (extension)
            {
                case ".pdf":
                    contentType = "application/pdf";
                    break;
                case ".png":
                case ".jpg":
                case ".jpeg":
                    contentType = $"image/{extension.Replace(".", "")}";
                    break;
                case ".txt":
                    contentType = "text/plain";
                    break;
                default:
                    contentType = "application/octet-stream"; // Otros archivos
                    break;
            }

            return File(prueba.Archivo, contentType);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Formulario prueba, List<IFormFile> upload, List<IFormFile> uploada, List<IFormFile> uploadArchivo, List<IFormFile> uploadc)
        {
            //if (ModelState.IsValid)
            try
            {
                prueba.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                Console.WriteLine($"UserId obtenido: {prueba.UserId}");
                // Primera imagen
                if (upload != null && upload.Count > 0)
                {
                    var up = upload.First();
                    using (var str = up.OpenReadStream())
                    {
                        using (var br = new BinaryReader(str))
                        {
                            prueba.Imagen = br.ReadBytes((Int32)str.Length);
                            prueba.ImagenName = Path.GetFileName(up.FileName);
                        }
                    }
                }

                // Segunda imagen
                if (uploada != null && uploada.Count > 0)
                {
                    var up = uploada.First();
                    using (var str = up.OpenReadStream())
                    {
                        using (var br = new BinaryReader(str))
                        {
                            prueba.Imagena = br.ReadBytes((Int32)str.Length);
                            prueba.ImagenNamea = Path.GetFileName(up.FileName);
                        }
                    }
                }

                if (uploadArchivo != null && uploadArchivo.Count > 0)
                {
                    var up = uploadArchivo.First();
                    using (var str = up.OpenReadStream())
                    {
                        using (var br = new BinaryReader(str))
                        {
                            prueba.Archivo = br.ReadBytes((Int32)str.Length);
                            prueba.ArchivoName = Path.GetFileName(up.FileName);

                            // Extraer texto del PDF
                            if (Path.GetExtension(up.FileName).ToLower() == ".pdf")
                            {
                                prueba.ArchivoTextoExtraido = ExtractTextFromPdf(prueba.Archivo);
                            }
                        }
                    }
                }

                if (uploadc != null && uploadc.Count > 0)
                {
                    var up = uploadc.First();
                    using (var str = up.OpenReadStream())
                    {
                        using (var br = new BinaryReader(str))
                        {
                            prueba.Imagenc = br.ReadBytes((Int32)str.Length);
                            prueba.ImagenNamec = Path.GetFileName(up.FileName);
                        }
                    }
                }


                // Depuración: Verificar valores antes de guardar
                Console.WriteLine($"Imagen principal: {prueba.ImagenName}, Imagen secundaria: {prueba.ImagenNamea}, Archivo: {prueba.ArchivoName}, Imagen terciaria: {prueba.ImagenNamec}");

                // Agregar entidad principal
                _context.DataFormulario.Add(prueba);
                await _context.SaveChangesAsync();

                // Manejar Estados asociados
                if (prueba.Estados != null && prueba.Estados.Count > 0)
                {
                    foreach (var estado in prueba.Estados)
                    {
                        estado.FormularioId = prueba.Id;

                        if (estado.Id == 0)
                        {
                            _context.DataEstados.Add(estado);
                        }
                    }

                    await _context.SaveChangesAsync();
                }
                if (prueba.Estadosa != null && prueba.Estadosa.Count > 0)
                {
                    foreach (var estadoa in prueba.Estadosa)
                    {
                        estadoa.FormularioId = prueba.Id;

                        if (estadoa.Id == 0)
                        {
                            _context.DataEstadosa.Add(estadoa);
                        }
                    }

                    await _context.SaveChangesAsync();
                }
                if (prueba.Dialogo != null && prueba.Dialogo.Count > 0)
                {
                    foreach (var dialogo in prueba.Dialogo)
                    {
                        dialogo.FormularioId = prueba.Id;

                        if (dialogo.Id == 0)
                        {
                            _context.DataDialogo.Add(dialogo);
                        }
                    }

                    await _context.SaveChangesAsync();
                }
                if (prueba.Status != null && prueba.Status.Count > 0)
                {
                    foreach (var statu in prueba.Status)
                    {
                        statu.FormularioId = prueba.Id;

                        if (statu.Id == 0)
                        {
                            _context.DataStatus.Add(statu);
                        }
                    }

                    await _context.SaveChangesAsync();
                }

                return RedirectToAction(nameof(Index2));
            }

            catch (Exception ex)
            {
                // Registrar el error para diagnóstico
                Console.WriteLine($"Error al guardar el formulario: {ex.Message}");
                ModelState.AddModelError("", "Error al guardar el formulario: " + ex.Message);
                return View(prueba);
            }
        }
        private string ExtractTextFromPdf(byte[] pdfBytes)
        {
            using (var memoryStream = new MemoryStream(pdfBytes))
            {
                using (var pdfReader = new PdfReader(memoryStream))
                {
                    using (var pdfDocument = new PdfDocument(pdfReader))
                    {
                        var textBuilder = new StringBuilder();

                        for (int i = 1; i <= pdfDocument.GetNumberOfPages(); i++)
                        {
                            var page = pdfDocument.GetPage(i);
                            var strategy = new LocationTextExtractionStrategy();

                            PdfTextExtractor.GetTextFromPage(page, strategy);
                            textBuilder.Append(strategy.GetResultantText());
                        }

                        return textBuilder.ToString();
                    }
                }
            }
        }
        // Existing method to display the image


        // Existing method to display the image

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prueba = await _context.DataFormulario
                .Include(p => p.Estados)
                .Include(p => p.Estadosa)
                .Include(p => p.Dialogo)
                .Include(p => p.Status)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (prueba == null)
            {
                return NotFound();
            }

            return View(prueba);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Formulario prueba, List<IFormFile> upload, List<IFormFile> uploada, List<IFormFile> uploadArchivo, List<IFormFile> uploadc)
        {
            if (id != prueba.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var existingFormulario = await _context.DataFormulario
                .AsNoTracking() // Para evitar conflictos de seguimiento de entidad
                .FirstOrDefaultAsync(f => f.Id == id);

                    if (existingFormulario == null)
                    {
                        return NotFound();
                    }
                    prueba.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                    Console.WriteLine($"UserId obtenido en Edit: {prueba.UserId}");



                    if (upload != null && upload.Count > 0)
                    {
                        foreach (var up in upload)
                        {
                            using (var str = up.OpenReadStream())
                            {
                                using (var br = new BinaryReader(str))
                                {
                                    prueba.Imagen = br.ReadBytes((Int32)str.Length);
                                    prueba.ImagenName = Path.GetFileName(up.FileName);
                                }
                            }
                        }
                    }
                    else
                    {
                        prueba.Imagen = existingFormulario.Imagen;
                        prueba.ImagenName = existingFormulario.ImagenName;
                    }


                    if (uploada != null && uploada.Count > 0)
                    {
                        foreach (var up in uploada)
                        {
                            using (var str = up.OpenReadStream())
                            {
                                using (var br = new BinaryReader(str))
                                {
                                    prueba.Imagena = br.ReadBytes((Int32)str.Length);
                                    prueba.ImagenNamea = Path.GetFileName(up.FileName);
                                }
                            }
                        }
                    }
                    else
                    {
                        prueba.Imagena = existingFormulario.Imagena;
                        prueba.ImagenNamea = existingFormulario.ImagenNamea;
                    }
                    Console.WriteLine($"Imagen principal: {prueba.ImagenName}, Imagen secundaria: {prueba.ImagenNamea}");

                    // Update the main Prueba entity
                    _context.Update(prueba);
                    _context.Entry(prueba).Property(p => p.UserId).IsModified = true;
                    await _context.SaveChangesAsync();

                    if (uploadArchivo != null && uploadArchivo.Count > 0)
                    {
                        var up = uploadArchivo.First();
                        using (var str = up.OpenReadStream())
                        {
                            using (var br = new BinaryReader(str))
                            {
                                prueba.Archivo = br.ReadBytes((Int32)str.Length);
                                prueba.ArchivoName = Path.GetFileName(up.FileName);

                                // Extraer texto del PDF si es necesario
                                if (Path.GetExtension(up.FileName).ToLower() == ".pdf")
                                {
                                    prueba.ArchivoTextoExtraido = ExtractTextFromPdf(prueba.Archivo);
                                }
                            }
                        }
                    }
                    else
                    {
                        // Mantener el archivo anterior si no se sube uno nuevo
                        prueba.Archivo = existingFormulario.Archivo;
                        prueba.ArchivoName = existingFormulario.ArchivoName;
                        prueba.ArchivoTextoExtraido = existingFormulario.ArchivoTextoExtraido;
                    }

                    if (uploadc != null && uploadc.Count > 0)
                    {
                        foreach (var up in uploadc)
                        {
                            using (var str = up.OpenReadStream())
                            {
                                using (var br = new BinaryReader(str))
                                {
                                    prueba.Imagenc = br.ReadBytes((Int32)str.Length);
                                    prueba.ImagenNamec = Path.GetFileName(up.FileName);
                                }
                            }
                        }
                    }
                    else
                    {
                        prueba.Imagenc = existingFormulario.Imagenc;
                        prueba.ImagenNamec = existingFormulario.ImagenNamec;
                    }


                    // Handle associated Estados
                    if (prueba.Estados != null)
                    {
                        // Get existing estados for this Prueba
                        var existingEstados = await _context.DataEstados
                            .Where(e => e.FormularioId == prueba.Id)
                            .ToListAsync();

                        // Remove estados that are not in the current list
                        var estadosToRemove = existingEstados
                            .Where(existing => !prueba.Estados.Any(current =>
                                current.Id == existing.Id))
                            .ToList();

                        _context.DataEstados.RemoveRange(estadosToRemove);

                        // Update or add new estados
                        foreach (var estado in prueba.Estados)
                        {
                            estado.FormularioId = prueba.Id;

                            if (estado.Id == 0)
                            {
                                // New estado
                                _context.DataEstados.Add(estado);
                            }
                            else
                            {
                                // Existing estado
                                _context.Update(estado);
                            }
                        }

                        await _context.SaveChangesAsync();
                    }
                    if (prueba.Estadosa != null)
                    {
                        // Get existing estados for this Prueba
                        var existingEstados = await _context.DataEstadosa
                            .Where(e => e.FormularioId == prueba.Id)
                            .ToListAsync();

                        // Remove estados that are not in the current list
                        var estadosToRemove = existingEstados
                            .Where(existing => !prueba.Estadosa.Any(current =>
                                current.Id == existing.Id))
                            .ToList();

                        _context.DataEstadosa.RemoveRange(estadosToRemove);

                        // Update or add new estados
                        foreach (var estadoa in prueba.Estadosa)
                        {
                            estadoa.FormularioId = prueba.Id;

                            if (estadoa.Id == 0)
                            {
                                // New estado
                                _context.DataEstadosa.Add(estadoa);
                            }
                            else
                            {
                                // Existing estado
                                _context.Update(estadoa);
                            }
                        }

                        await _context.SaveChangesAsync();
                    }
                    if (prueba.Dialogo != null)
                    {
                        // Get existing estados for this Prueba
                        var existingEstados = await _context.DataDialogo
                            .Where(e => e.FormularioId == prueba.Id)
                            .ToListAsync();

                        // Remove estados that are not in the current list
                        var dialogoToRemove = existingEstados
                            .Where(existing => !prueba.Dialogo.Any(current =>
                                current.Id == existing.Id))
                            .ToList();

                        _context.DataDialogo.RemoveRange(dialogoToRemove);

                        // Update or add new estados
                        foreach (var dialogo in prueba.Dialogo)
                        {
                            dialogo.FormularioId = prueba.Id;

                            if (dialogo.Id == 0)
                            {
                                // New estado
                                _context.DataDialogo.Add(dialogo);
                            }
                            else
                            {
                                // Existing estado
                                _context.Update(dialogo);
                            }
                        }

                        await _context.SaveChangesAsync();
                    }

                    if (prueba.Status != null)
                    {
                        // Get existing estados for this Prueba
                        var existingEstados = await _context.DataStatus
                            .Where(e => e.FormularioId == prueba.Id)
                            .ToListAsync();

                        // Remove estados that are not in the current list
                        var estadosToRemove = existingEstados
                            .Where(existing => !prueba.Status.Any(current =>
                                current.Id == existing.Id))
                            .ToList();

                        _context.DataStatus.RemoveRange(estadosToRemove);

                        // Update or add new estados
                        foreach (var status in prueba.Status)
                        {
                            status.FormularioId = prueba.Id;

                            if (status.Id == 0)
                            {
                                // New estado
                                _context.DataStatus.Add(status);
                            }
                            else
                            {
                                // Existing estado
                                _context.Update(status);
                            }
                        }

                        await _context.SaveChangesAsync();
                    }

                    return RedirectToAction(nameof(Index2));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PruebaExists(prueba.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }

            return View(prueba);
        }
        private bool PruebaExists(int id)
        {
            return _context.DataFormulario.Any(e => e.Id == id);
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
