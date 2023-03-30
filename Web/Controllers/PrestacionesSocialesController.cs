using Logica;
using Modelos;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class PrestacionesSocialesController : Controller
    {
        private readonly PrestacionesSociales_LN lnPrestaciones;

        public PrestacionesSocialesController()
        {
            lnPrestaciones = new PrestacionesSociales_LN();
        }


        // GET: PrestacionesSociales
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ObtenerDatos(string daterange)
        {
            try
            {
                DateTime fechaI = DateTime.ParseExact(daterange, "MM/dd/yyyy", CultureInfo.InvariantCulture);

                List<PrestacionesSociales_VM> lista = lnPrestaciones.Prestaciones(fechaI);

                return Json(new { data = lista }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { error = ex.Message });
            }
        }


    }
}