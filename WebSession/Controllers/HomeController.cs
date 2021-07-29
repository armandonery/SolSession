using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebSession.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                throw;
            }
        }

        public ActionResult Sesion(string usuario, string pass)
        {
            try
            {

                if (usuario == "root" && pass == "toor")
                {
                    Session["usuario"] = usuario;
                    TempData["msj"] = "Has ingresado correctamente!";
                }
                else
                    throw new ApplicationException("Usuario y contraseña incorrectos");

                return View();
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return View("Index");
            }
        }

        public ActionResult cerrarSesion()
        {
            try
            {
                Session["usuario"] = null;
                TempData["msj"] = "Se cerro la sesion correctamente";
                return View("Index");
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return View();
            }
        }

        public ActionResult mostrarSesion()
        {
            if (Session["usuario"] == null)
            {
                return View("Index");
            }
            return View();
        }

    }
}