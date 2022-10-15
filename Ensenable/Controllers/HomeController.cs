using Ensenable.Models;
using Ensenable.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Ensenable.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        CursoDatos cursodatos = new CursoDatos();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Tutorial1()
        {
            return View();
        }

        public IActionResult Tutorial2()
        {
            return View();
        }

        public IActionResult Tutorial3()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Cursos()
        {
            return View();
        }

        public IActionResult CreaCursos()
        {
            return View();
        }

        public IActionResult ListarCursos()
        {
            var oLista = cursodatos.ListarCursos();
            return View(oLista);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
