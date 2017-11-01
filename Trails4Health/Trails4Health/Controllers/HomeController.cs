using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Trails4Health.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Reservas()
        {
            return View();
        }

        public IActionResult ComoChegar()
        {
            return View();
        }

        public IActionResult Trilhos()
        {
            return View();
        }

        public IActionResult Fotos()
        {
            return View();
        }

        public IActionResult Loja()
        {
            return View();
        }

        public IActionResult Contactos()
        {
            return View();
        }
         

        public IActionResult Error()
        {
            return View();
        }
    }
}
