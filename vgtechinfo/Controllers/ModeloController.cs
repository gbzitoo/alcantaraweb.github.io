using System;
using System.Diagnostics;
using System.Linq;
using System.Net.Mail;
using Microsoft.AspNetCore.Mvc;
using vgtechinfo.Models;

namespace vgtechinfo.Controllers
{
    public class ModeloController : Controller
    {
        public IActionResult Catalogo()
        {
            return View();
        }

    }
}
