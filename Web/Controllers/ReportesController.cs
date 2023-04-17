using Logica;
using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class ReportesController : Controller
    {
        public readonly Reportes_LN LnReportes;

        public ReportesController()
        {
            LnReportes = new Reportes_LN();
        }

        // GET: Reportes
        public ActionResult ReporteArea()
        {
            return View();
        }

        public ActionResult ReporteCargo()
        {
            return View();
        }

        public ActionResult ReporteRangoSalarial()
        {
            return View();
        }
        public ActionResult ReportePorEdad()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetPersonalPorArea()
        {
            List<PersonalPorArea_VM> lista = new List<PersonalPorArea_VM>();
            lista = LnReportes.ObtenerPersonalPorAreas();
            return Json(new { data = lista }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetPersonalPorCargo()
        {
            List<PersonalPorCargo_VM> lista = new List<PersonalPorCargo_VM>();
            lista = LnReportes.ObtenerPersonalPorCargo();
            return Json(new { data = lista }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetPersonalPorRangoSalarial()
        {
            List<PersonalPorRangoSalarial_VM> lista = new List<PersonalPorRangoSalarial_VM>();
            lista = LnReportes.ObtenerPersonalPorRangoSalarial();
            return Json(new { data = lista }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetPersonalPorEdad()
        {
            List<PersonalPorEdad_VM> lista = new List<PersonalPorEdad_VM>();
            lista = LnReportes.ObtenerPersonalPorEdad();
            return Json(new { data = lista }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetRangoSalarialLINQ()
        {
            List<PersonalPorRangoSalarial_VM> lista = new List<PersonalPorRangoSalarial_VM>();
            lista = LnReportes.ObtenerRangoSalarialLINQ();
            return Json(new { data = lista }, JsonRequestBehavior.AllowGet);
        }
    }
}