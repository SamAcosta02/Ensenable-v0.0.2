using Microsoft.AspNetCore.Mvc;
using Ensenable.Models;
using Ensenable.Datos;

namespace Ensenable.Controllers
{
    public class MantenedorController : Controller
    {
        UsersDatos usersDatos = new UsersDatos();
        public IActionResult Listar()
        {
            var oLista = usersDatos.Listar();
            return View(oLista);
        }



        public IActionResult Insertar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Insertar(UsersModel oUser)
        {
            if (!ModelState.IsValid)
                return View();

            var resp = usersDatos.Insertar(oUser);
            if (resp)
            {
                return RedirectToAction("Listar");
            }
            else
            {
                return View();
            }
        }


        public IActionResult Eliminar(int id_user)
        {
            var oUser = usersDatos.Obtener(id_user);
            return View(oUser);
        }
        [HttpPost]
        public IActionResult Eliminar(UsersModel oUser)
        {
            var resp = usersDatos.Eliminar(oUser.id_user);

            if (resp)
            {
                return RedirectToAction("Listar");
            }
            else
                return View();
        }



        public IActionResult Editar(int id_user)
        {
            var oUser = usersDatos.Obtener(id_user);
            return View(oUser);
        }
        [HttpPost]
        public IActionResult Editar(UsersModel oUser)
        {
            if (!ModelState.IsValid)
                return View();

            var resp = usersDatos.Editar(oUser);
            if (resp)
            {
                return RedirectToAction("Listar");
            }
            else
            {
                return View();
            }
        }


        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Validar(UsersModel oUser)
        {
            var bandera = usersDatos.ValidarLogin(oUser.user_email, oUser.user_password);
            if(bandera == 1)
            {
                return RedirectToAction("Listar");
            }
            else
            {
                return RedirectToAction("LoginError");
            }
        }

        public IActionResult LoginError()
        {
            return View();
        }
        

    }
}
