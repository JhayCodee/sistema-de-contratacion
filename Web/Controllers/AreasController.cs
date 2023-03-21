using Logica;
using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class AreasController : Controller
    {
        public readonly Areas_LN LnArea;

        public AreasController()
        {
            LnArea = new Areas_LN();
        }

        // GET: Areas
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult AgregarArea()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AgregarArea(Area_VM area)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Message = "Hubo un error al agregar el Area";
                ViewBag.AlertType = "error";
                return View();
            }
            try
            {
                area.Activo = true;

                if (LnArea.AgregarArea(area))
                {
                    ViewBag.Message = "Area agregado exitosamente";
                    ViewBag.AlertType = "success";
                    return View();
                }
                else
                {
                    ViewBag.Message = "Hubo un error al agregar el Area";
                    ViewBag.AlertType = "error";
                    return View();
                }
            }
            catch
            {
                ViewBag.Message = "Hubo un error al agregar el Area";
                ViewBag.AlertType = "error";
                return View();
            }
        }

        public ActionResult EditarArea(int id)
        {
            Area_VM a = LnArea.BuscarAreaPorId(id);

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
        public ActionResult EditarArea(Area_VM area)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Message = "Hubo un error al editar el Area";
                ViewBag.AlertType = "error";
                return View();
            }

            try
            {
                if (LnArea.ActualizarArea(area))
                {
                    ViewBag.Message = "Area agregado exitosamente";
                    ViewBag.AlertType = "success";
                    return Redirect("/Areas/Index");
                }
                else
                {
                    ViewBag.Message = "Hubo un error al editar el Area";
                    ViewBag.AlertType = "error";
                    return View();
                }
            }
            catch
            {
                ViewBag.Message = "Hubo un error al editar el Area";
                ViewBag.AlertType = "error";
                return View();
            }

        }


        public ActionResult AreasJson()
        {
            List<Area_VM> lista = new List<Area_VM>();
            lista = LnArea.ObtenerAreas();
            return Json(new { data = lista }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ValidarCodigoArea(string codigo)
        {
            bool existe = LnArea.CodigoAreaExiste(codigo);
            return Json(!existe, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ValidarCodigoConId(string codigo, int id)
        {
            bool existe = LnArea.ValidarCodigoAreaConID(codigo, id);
            return Json(existe, JsonRequestBehavior.AllowGet);
        }

    }
}