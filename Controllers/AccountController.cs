using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;

namespace FORMULARIOCENSI.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;

    public AccountController(SignInManager<IdentityUser> signInManager)
    {
        _signInManager = signInManager;
    }

    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        // Aquí puedes personalizar tu mensaje
        TempData["Message"] = "Tu mensaje personalizado de logout";
        return RedirectToAction("Index", "Home");
    }
    }
}