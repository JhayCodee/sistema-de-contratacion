using Logica;
using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class TipoContratoController : Controller
    {
        private readonly TipoContrato_LN lnTipoContrato;

        public TipoContratoController()
        {
            lnTipoContrato = new TipoContrato_LN();
        }

        // GET: TipoContrato
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AgregarTipoContrato()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AgregarTipoContrato(TipoContrato_VM tp)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Message = "Hubo un error al agregar el tipo de contrato";
                ViewBag.AlertType = "error";
                return View();
            }
            try
            {
                tp.Activo = true;

                if (lnTipoContrato.AgregarTipoContrato(tp))
                {
                    ViewBag.Message = "tipo de contrato agregado exitosamente";
                    ViewBag.AlertType = "success";
                    return View();
                }
                else
                {
                    ViewBag.Message = "Hubo un error al agregar el tipo de contrato";
                    ViewBag.AlertType = "error";
                    return View();
                }
            }
            catch
            {
                ViewBag.Message = "Hubo un error al agregar el tipo de contrato";
                ViewBag.AlertType = "error";
                return View();
            }
        }

        public ActionResult EditarTipoContrato(int id)
        {
            TipoContrato_VM a = lnTipoContrato.BuscarTipoContratoPorId(id);

            if (a != null)
            {
                return View(a);
            }
            else
            {
                return View();
            }
        }


        [HttpPost]
        public ActionResult EditarTipoContrato(TipoContrato_VM tp)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Message = "Hubo un error al editar el Tipo de contrato";
                ViewBag.AlertType = "error";
                return View();
            }

            try
            {
                if (lnTipoContrato.ActualizarTipoContrato(tp))
                {
                    ViewBag.Message = "Tipo de contrato agregado exitosamente";
                    ViewBag.AlertType = "success";
                    return Redirect("/TipoContrato/Index");
                }
                else
                {
                    ViewBag.Message = "Hubo un error al editar el Tipo de contrato";
                    ViewBag.AlertType = "error";
                    return View();
                }
            }
            catch
            {
                ViewBag.Message = "Hubo un error al editar el Tipo de contrato";
                ViewBag.AlertType = "error";
                return View();
            }

        }


        public ActionResult TipoContratoJson()
        {
            List<TipoContrato_VM> lista = new List<TipoContrato_VM>();
            lista = lnTipoContrato.ObtnerTipoContrato();
            return Json(new { data = lista }, JsonRequestBehavior.AllowGet);
        }



    }
}