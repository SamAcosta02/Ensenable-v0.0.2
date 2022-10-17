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
        ActivityDatos activitydatos = new ActivityDatos();

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

        //Controladores con backend

        // CURSOS

        public IActionResult ListarCursos()
        {
            var oLista = cursodatos.ListarCursos();
            return View(oLista);
        }

        public IActionResult CrearCurso()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult CrearCurso(CourseModel oCourse)
        {
            if (!ModelState.IsValid)
                return View();

            var resp = cursodatos.CrearCurso(oCourse);
            if(resp)
            {
                return RedirectToAction("ListarCursos");
            }
            else
            {
                return View();
            }
        }

        public IActionResult EditarDetallesCurso(int IdCourse)
        {
            var oCurso = cursodatos.ObtenerDetalles(IdCourse);
            return View(oCurso);
        }

        [HttpPost]
        public IActionResult EditarDetallesCurso(CourseModel oCourse)
        {
            if (!ModelState.IsValid)
                return View();

            var respuesta = cursodatos.EditarDetalleCurso(oCourse);

            if (respuesta)
            {
                return RedirectToAction("ListarCursos");
            }
            else
                return View();
        }

        public IActionResult PublicarCurso(int IdCourse)
        {
            var oCurso = cursodatos.ObtenerDetalles(IdCourse);
            return View(oCurso);
        }

        [HttpPost]
        public IActionResult PublicarCurso(CourseModel oCourse)
        {
            if (!ModelState.IsValid)
                return View();

            var respuesta = cursodatos.PublicarCurso(oCourse);

            if (respuesta)
            {
                return RedirectToAction("ListarCursos");
            }
            else
                return View();
        }

        public IActionResult DesPublicarCurso(int IdCourse)
        {
            var oCurso = cursodatos.ObtenerDetalles(IdCourse);
            return View(oCurso);
        }

        [HttpPost]
        public IActionResult DesPublicarCurso(CourseModel oCourse)
        {
            if (!ModelState.IsValid)
                return View();

            var respuesta = cursodatos.DesPublicarCurso(oCourse);

            if (respuesta)
            {
                return RedirectToAction("ListarCursos");
            }
            else
                return View();
        }

        public IActionResult EliminarCurso(int IdCourse)
        {
            var oCourse = cursodatos.ObtenerDetalles(IdCourse);
            return View(oCourse);
        }
        [HttpPost]
        public IActionResult EliminarCurso(CourseModel oCourse)
        {
            var respuesta = cursodatos.EliminarCurso(oCourse.IdCourse);

            if (respuesta)
            {
                return RedirectToAction("ListarCursos");
            }
            else
                return View();
        }

        // ACTIVIDADES

        public IActionResult ListActivities(int IdCourse)
        {
            var oLista = activitydatos.ListarActivities(IdCourse);
            int length = oLista.Count();

            TempData["curso"] = IdCourse;
            return View(oLista);
        }


        public IActionResult EditarDetallesAct(int IdActivity)
        {
            var oActivity = activitydatos.ObtenerDetallesAct(IdActivity);
            return View(oActivity);
        }

        [HttpPost]
        public IActionResult EditarDetallesAct(ActivityModel oActivity)
        {
            var respuesta = activitydatos.EditarDetalleActivity(oActivity);

            if (respuesta)
            {
                return RedirectToAction("ListActivities", new { IdCourse = oActivity.IdCourse});
            }
            else
                return View();
        }

        public IActionResult CrearActivity(int IdCourse)
        {
            ActivityModel oActivity = new ActivityModel();
            oActivity.IdCourse = IdCourse;
            return View(oActivity);
        }

        [HttpPost]
        public IActionResult CrearActivity(ActivityModel oActivity)
        {
            var resp = activitydatos.CrearActivity(oActivity);
            if (resp)
            {
                return RedirectToAction("ListActivities", new { IdCourse = oActivity.IdCourse });
            }
            else
            {
                return View();
            }
        }

        public IActionResult EliminarActivity(int IdActivity)
        {
            var oActivity = activitydatos.ObtenerDetallesAct(IdActivity);
            return View(oActivity);
        }

        [HttpPost]
        public IActionResult EliminarActivity(ActivityModel oActivity)
        {
            var respuesta = activitydatos.EliminarActivity(oActivity.IdActivity);

            if (respuesta)
            {
                return RedirectToAction("ListActivities", new { IdCourse = oActivity.IdCourse });
            }
            else
                return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
