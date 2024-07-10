using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FORMULARIOCENSI.Models;

namespace FORMULARIOCENSI.Controllers;

public class FormularioController : Controller
{
    public IActionResult Index2()
    {
        return View();
    }
}

