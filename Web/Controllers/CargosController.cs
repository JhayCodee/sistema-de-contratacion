using Logica;
using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class CargosController : Controller
    {
        private readonly Cargos_LN lnCargos;

        public CargosController ()
        {
            lnCargos = new Cargos_LN();
        }


        // GET: Cargos
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AgregarCargo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AgregarCargo(Cargo_VM c)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Message = "Hubo un error al agregar el Cargo";
                ViewBag.AlertType = "error";
                return View();
            }
            try
            {
                c.Activo = true;

                if (lnCargos.AgregarCargo(c))
                {
                    ViewBag.Message = "Cargo agregado exitosamente";
                    ViewBag.AlertType = "success";
                    return View();
                }
                else
                {
                    ViewBag.Message = "Hubo un error al agregar el Cargo";
                    ViewBag.AlertType = "error";
                    return View();
                }
            }
            catch
            {
                ViewBag.Message = "Hubo un error al agregar el Cargo";
                ViewBag.AlertType = "error";
                return View();
            }
        }

        [HttpGet]
        public ActionResult EditarCargo(int id)
        {
            try
            {
                Cargo_VM cargo = lnCargos.BuscarCargoPorId(id);
                return View(cargo);
            }
            catch
            {
                return (null);
            }

        }

        [HttpPost]
        public ActionResult EditarCargo(Cargo_VM c)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Message = "Hubo un error al editar el cargo";
                ViewBag.AlertType = "error";
                return View();
            }

            try
            {
                if (lnCargos.ActualizarCargo(c))
                {
                    ViewBag.Message = "Cargo agregado exitosamente";
                    ViewBag.AlertType = "success";
                    return Redirect("/Cargos/Index");
                }
                else
                {
                    ViewBag.Message = "Hubo un error al editar el Cargo";
                    ViewBag.AlertType = "error";
                    return View();
                }
            }
            catch
            {
                ViewBag.Message = "Hubo un error al editar el Cargo";
                ViewBag.AlertType = "error";
                return View();
            }
        }


        [HttpGet]
        public ActionResult CargosJson()
        {
            List<Cargo_VM> lista = new List<Cargo_VM>();
            lista = lnCargos.ObtenerCargos();
            return Json(new { data = lista }, JsonRequestBehavior.AllowGet);
        }


        public ActionResult ValidarCodigoCargo(string codigo)
        {
            bool existe = lnCargos.CodigoCargoExiste(codigo);
            return Json(!existe, JsonRequestBehavior.AllowGet);
        }


        public ActionResult ValidarCodigoConId(string codigo, int id)
        {
            bool existe = lnCargos.ValidarCodigoCargoConID(codigo, id);
            return Json(existe, JsonRequestBehavior.AllowGet);
        }

    }
}