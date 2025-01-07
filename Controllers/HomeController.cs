using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FORMULARIOCENSI.Models;
using Microsoft.AspNetCore.Identity;

namespace FORMULARIOCENSI.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly UserManager<IdentityUser> _userManager;

    public HomeController(ILogger<HomeController> logger, UserManager<IdentityUser> userManager)
    {
        _logger = logger;
        _userManager = userManager;
    }

    public async Task<IActionResult> Index()
        {
            // Obtener el usuario actual
            var user = await _userManager.GetUserAsync(User);

            if (user != null)
            {
                // Obtener los roles del usuario
                var roles = await _userManager.GetRolesAsync(user);
                // Pasar los roles a la vista
                ViewData["UserRoles"] = roles;
            }

            return View();
        }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
