using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Ensenable.Models;
using Ensenable.Datos;
using Microsoft.AspNetCore.Http;
using Microsoft.CodeAnalysis;
using Microsoft.AspNetCore.Components.Routing;

namespace Ensenable.Controllers
{
    public class HomeController : Controller
    {
        UsersDatos usersDatos = new UsersDatos();
        
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {

            ViewBag.Session = HttpContext.Session.GetInt32("Test");
            return View();
        }

        public IActionResult Privacy()
        {
            ViewBag.Session = HttpContext.Session.GetInt32("Test");
            return View();
        }

        public IActionResult Tutorial1()
        {
            ViewBag.Session = HttpContext.Session.GetInt32("Test");
            return View();
        }

        public IActionResult Tutorial2()
        {
            ViewBag.Session = HttpContext.Session.GetInt32("Test");
            return View();
        }

        public IActionResult Tutorial3()
        {
            ViewBag.Session = HttpContext.Session.GetInt32("Test");
            return View();
        }
        
        //Login y validacion
        public IActionResult Login()
        {
            ViewBag.Session = HttpContext.Session.GetInt32("Test");
            return View();
        }

        public IActionResult ValidarLogin(UsersModel oUser)
        {
            var bandera = usersDatos.ValidarLogin(oUser.user_email, oUser.user_password);
            if (bandera == 1)
            {
                oUser = usersDatos.getUserInfo(oUser.user_email);
                HttpContext.Session.SetInt32("Test", oUser.id_user);
                return RedirectToAction("Privacy");
            }
            else
            {
                TempData["errorLogin"] = 1;
                return RedirectToAction("Login");
            }
        }

        //LOGOUT Y ACABAR SESSION
        public IActionResult LogOut()
        {
            TempData["LogOut"] = 1;
            HttpContext.Session.Clear();
            return RedirectToAction("Privacy");
        }



        //PAGINA REGISTRARSE
        public IActionResult Register()
        {
            ViewBag.Session = HttpContext.Session.GetInt32("Test");
            return View();
        }
        [HttpPost]
        public IActionResult Register(UsersModel oUser)
        {
            if (!ModelState.IsValid)
            {
                TempData["invalidRegis"] = 1;
                return View();
            }

            var bandera = usersDatos.ValidarRegis(oUser.user_email);
            if (bandera == 1)
            {
                TempData["errorRegis"] = 1;
                return RedirectToAction("Register");
            }
            var resp = usersDatos.Insertar(oUser);
            if (resp)
            {
                oUser = usersDatos.getUserInfo(oUser.user_email);
                HttpContext.Session.SetInt32("Test", oUser.id_user);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }


        //PAGINA ABOUT
        public IActionResult About()
        {
            ViewBag.Session = HttpContext.Session.GetInt32("Test");
            return View();
        }



        //PAGINA ACCOUNT
        public IActionResult Account()
        {
            ViewBag.Session = HttpContext.Session.GetInt32("Test");
            return View();
        }



        //..
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            ViewBag.Session = HttpContext.Session.GetInt32("Test");
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}