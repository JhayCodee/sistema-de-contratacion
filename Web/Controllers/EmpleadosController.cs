using Logica;
using Modelos;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class EmpleadosController : Controller
    {
        private readonly Empleados_LN LnEmpleado;
        private readonly Contrato_LN LnContrato;


        public EmpleadosController()
        {
            LnEmpleado = new Empleados_LN();
            LnContrato = new Contrato_LN();
        }

        // Lista de empleados
        public ActionResult Empleados_VW()
        {
            ViewBag.ListaEmpleado = LnEmpleado.ListarEmpleados();
            return View();
        }

        

        // Vista de agregar empleado
        public ActionResult AgregarEmpleado()
        {
            List<Area_VM> ListaAreas = LnContrato.ObtenerAreas();
            List<Cargo_VM> ListaCargos = LnContrato.ObtenerCargos();
            List<TipoContrato_VM> listaTipoContratos = LnContrato.ObtenerTipoContrato();

            var lista = new AreaCargoTipoContrato_VM
            {
                ListaArea = ListaAreas,
                ListaCargo = ListaCargos,
                ListaTipoContrato = listaTipoContratos,
            };

            return View(lista);
        }

        // guarda empleado en la base de datos
        [HttpPost]
        public ActionResult AgregarEmpleado(Empleado_VM empleado, Contrato_VM contrato, HttpPostedFileBase Fotografia)
        {

            List<Area_VM> ListaAreas = LnContrato.ObtenerAreas();
            List<Cargo_VM> ListaCargos = LnContrato.ObtenerCargos();
            List<TipoContrato_VM> listaTipoContratos = LnContrato.ObtenerTipoContrato();

            var lista = new AreaCargoTipoContrato_VM
            {
                ListaArea = ListaAreas,
                ListaCargo = ListaCargos,
                ListaTipoContrato = listaTipoContratos,
            };

            if (!ModelState.IsValid)
            {
                ViewBag.Message = "Los campos del formulario no son válidos";
                ViewBag.AlertType = "error";
                return View(lista);
            }

            if (LnEmpleado.CodigoEmpleadoExiste(empleado.Codigo))
            {
                ViewBag.Message = "El código de empleado ya existe";
                ViewBag.AlertType = "error";
                return View(lista);
            }

            try
            {
                if (Fotografia != null && Fotografia.ContentLength > 0)
                {
                    string fileName = Path.GetFileName(Fotografia.FileName);
                    string fileExtension = Path.GetExtension(fileName);

                    // Lista de extensiones permitidas
                    List<string> allowedExtensions = new List<string> { ".jpg", ".jpeg", ".png", ".webp" };

                    // valida que la extension sea valida
                    if (!allowedExtensions.Contains(fileExtension.ToLower()))
                    {
                        ViewBag.Message = "La imagen debe ser un archivo con extension " + string.Join(", ", allowedExtensions);
                        ViewBag.AlertType = "error";
                        return View(lista);
                    }

                    string path = Path.Combine(Server.MapPath("~/Content/Images"), empleado.Codigo + fileName);
                    Fotografia.SaveAs(path);
                    Debug.WriteLine("Imagen guardada en " + path);
                    empleado.Fotografia = "/Content/Images/" + empleado.Codigo + fileName;
                } 
                else
                {
                    ViewBag.Message = "No inserto una imagen valida";
                    ViewBag.AlertType = "error";
                    return View(lista);
                }

                // si se pudo agregar el empleado

                if (LnEmpleado.AgregarEmpleado(empleado))
                {
                    // agrega el contrato

                    var e = LnEmpleado.BuscarEmpleadoPorCodigo(empleado.Codigo);

                    if(e == null)
                    {
                        ViewBag.Message = "Hubo un error al agregar el empleado";
                        ViewBag.AlertType = "error";
                        return View(lista);
                    }

                    contrato.IdEmpleado = e.IdEmpleado;
                    contrato.EstadoFila = true;

                    if (LnContrato.AgregarContrato(contrato))
                    {
                        ViewBag.Message = "Empleado agregado exitosamente";
                        ViewBag.AlertType = "success";
                        return View();
                    }
                    else
                    {
                        ViewBag.Message = "Hubo un error al agregar el empleado";
                        ViewBag.AlertType = "error";
                        return View(lista);
                    }

                }
                else
                {
                    ViewBag.Message = "Hubo un error al agregar el empleado";
                    ViewBag.AlertType = "error";
                    return View(lista);
                }


                


            }
            catch
            {
                ViewBag.Message = "Hubo un error al agregar el empleado";
                ViewBag.AlertType = "error";
            }

            return View();

        }

        // valida si existe o no el codigo del empleado
        [HttpPost]
        public ActionResult ValidarCodigoEmpleado(string codigo)
        {
            bool existe = LnEmpleado.CodigoEmpleadoExiste(codigo);

            return Json(!existe, JsonRequestBehavior.AllowGet);
        }

        // valida si existe el correo del empleado
        [HttpPost]
        public ActionResult ValidarCorreoEmpleado(string EmailPersonal)
        {
            bool existe = LnEmpleado.CorreoEmpleadoExiste(EmailPersonal);
            return Json(!existe, JsonRequestBehavior.AllowGet);
        }

        // Validar correo con Id
        public ActionResult ValidarCorreoConId(string EmailPersonal, int id)
        {
            bool existe = LnEmpleado.ValidarCorreoConID(EmailPersonal, id);
            return Json(existe, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ValidarCodigoEmpleadoConID(string codigo, int id)
        {
            bool existe = LnEmpleado.ValidarCodigoEmpleadoConID(codigo, id);
            return Json(existe, JsonRequestBehavior.AllowGet);
        }


        // Empleados/AgregarEmpleado || Json de la lista de empleados
        public ActionResult EmpleadosJson()
        {
            List<ObtenerEmpleados_VM> lista = new List<ObtenerEmpleados_VM>();
            lista = LnContrato.ObtenerListaEmpleadosYContrato();
            return Json(new { data = lista }, JsonRequestBehavior.AllowGet);
        }


        // Editar Empleados
        [HttpGet]
        public ActionResult EditarEmpleados (int id)
        {
            ObtenerEmpleados_VM empleado = LnContrato.ObtenerInformacionPorId(id);
            var lista = LnContrato.ObtenerListasSP();
            List <ObtenerEmpleados_VM> e = new List<ObtenerEmpleados_VM>();
            e.Add(empleado);

            var tupleModel = new Tuple<List<ObtenerEmpleados_VM>, List<AreaCargoTipoContrato_VM>>(e, lista);

            if(empleado != null)
            {
                return View(tupleModel);
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult EditarEmpleados(Empleado_VM empleado, Contrato_VM contrato, HttpPostedFileBase foto)
        {
            ObtenerEmpleados_VM em = LnContrato.ObtenerInformacionPorId(empleado.IdEmpleado);
            var lista = LnContrato.ObtenerListasSP();
            List<ObtenerEmpleados_VM> e = new List<ObtenerEmpleados_VM>();
            e.Add(em);

            var tupleModel = new Tuple<List<ObtenerEmpleados_VM>, List<AreaCargoTipoContrato_VM>>(e, lista);


            if (empleado.Fotografia == null)
            {
                empleado.Fotografia = "/Content/Images/defaultimg.png";
            }

            if (!ModelState.IsValid)
            {
                ViewBag.Message = "Los campos del formulario no son válidos";
                ViewBag.AlertType = "error";
                return View(tupleModel);
            }

            try
            {
                if (foto != null && foto.ContentLength > 0)
                {
                    string fileName = Path.GetFileName(foto.FileName);
                    string fileExtension = Path.GetExtension(fileName);

                    // Lista de extensiones permitidas
                    List<string> allowedExtensions = new List<string> { ".jpg", ".jpeg", ".png", ".webp", "jfif" };

                    // valida que la extension sea valida
                    if (!allowedExtensions.Contains(fileExtension.ToLower()))
                    {
                        ViewBag.Message = "La imagen debe ser un archivo con extension " + string.Join(", ", allowedExtensions);
                        ViewBag.AlertType = "error";
                        return View(tupleModel);
                    }

                    string path = Path.Combine(Server.MapPath("~/Content/Images"), empleado.Codigo + fileName);
                    foto.SaveAs(path);
                    Debug.WriteLine("Imagen guardada en " + path);
                    empleado.Fotografia = "/Content/Images/" + empleado.Codigo + fileName;
                }


                bool resultado = LnEmpleado.ActualizarEmpleado(empleado);

                if (resultado)
                {
                    if (LnContrato.ActualizarContrato(contrato))
                    {
                        ViewBag.Message = "Empleado agregado exitosamente";
                        ViewBag.AlertType = "success";
                        return Redirect("/Empleados/Empleados_VW");
                    }
                    else
                    {
                        ViewBag.Message = "Hubo un error al agregar el empleado";
                        ViewBag.AlertType = "error";
                        return View(tupleModel);
                    }
                    
                }
                else
                {
                    ViewBag.Message = "Hubo un error al agregar el empleado";
                    ViewBag.AlertType = "error";
                    return View(tupleModel);
                }
            }
            catch
            {
                ViewBag.Message = "Hubo un error al agregar el empleado";
                ViewBag.AlertType = "error";
                return View(tupleModel);
            }
        }

    }
}
