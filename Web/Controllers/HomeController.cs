using Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly Empleados_LN LnEmpleado;

        public HomeController()
        {
            LnEmpleado = new Empleados_LN();
        }

        public ActionResult Index()
        {
            ViewBag.ListaEmpleado = LnEmpleado.ListarEmpleados();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}