using System;
using Logica;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Modelos;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using iTextSharp.text.html.simpleparser;
using Newtonsoft.Json.Linq;
using System.Data;
using Newtonsoft.Json;
using System.Web.Script.Serialization;
using System.Web.Helpers;
using System.Diagnostics;

namespace Web.Controllers
{
    public class PlanillaController : Controller
    {

        private readonly Planilla_LN LnPlanilla;

        public PlanillaController()
        {
            LnPlanilla = new Planilla_LN();
        }

        // GET: Planilla
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ObtenerDatos(string daterange)
        {
            try
            {
                string fechaInicial = daterange.Substring(0, 10);
                string fechaFinal = daterange.Substring(13, 10);

                DateTime fechaI, fechaF;

                fechaI = DateTime.ParseExact(fechaInicial, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                fechaF = DateTime.ParseExact(fechaFinal, "yyyy-MM-dd", CultureInfo.InvariantCulture);

                List<Planilla_VM> lista = LnPlanilla.GenerarPlanilla(fechaI, fechaF);

                //OrdenarFechaDesc(lista);

                return Json(new { data = lista }, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json(new { data = new { } }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult ColillaPdf(string planilla, string fechas)
        {
            JObject row = JObject.Parse(planilla);

            string htmlFilePath = Server.MapPath("~/Views/Planilla/Plantilla.html");
            string htmlContent = System.IO.File.ReadAllText(htmlFilePath);
            DateTime dt = (DateTime)row["Fecha_de_Ingreso"];

            float salarioAntiguedad = (float)row["Monto_Salario"] + (float)row["Antiguedad"];
            float deducciones = (float)row["INSS"] + (float)row["IR_Mensual"];

            htmlContent = htmlContent.Replace("@rango", fechas);
            htmlContent = htmlContent.Replace("@CodigoNombre", (string)row["Codigo_Empleado"] + "-" + (string)row["Nombre_Completo"]);
            htmlContent = htmlContent.Replace("@TipoContrato", (string)row["TipodeContrato"]);
            htmlContent = htmlContent.Replace("@Cargo", (string)row["Cargo"] );
            htmlContent = htmlContent.Replace("@Area", (string)row["NombreArea"]);
            htmlContent = htmlContent.Replace("@FechaIngreso", dt.ToString("yyyy-MM-dd"));

            htmlContent = htmlContent.Replace("@SalarioMensual", String.Format("{0:#,##0.00}", row["Salario_Basico"]));
            htmlContent = htmlContent.Replace("@Salario", String.Format("{0:#,##0.00}", row["Monto_Salario"] ?? 0));

            htmlContent = htmlContent.Replace("@Ant", String.Format("{0:#,##0.00}", row["Antiguedad"] ?? 0));
            htmlContent = htmlContent.Replace("@Total", String.Format("{0:#,##0.00}", salarioAntiguedad));
            htmlContent = htmlContent.Replace("@INSS", String.Format("{0:#,##0.00}", row["INSS"] ?? 0));
            htmlContent = htmlContent.Replace("@IR", String.Format("{0:#,##0.00}", row["Ir_Mensual"] ?? 0));
            htmlContent = htmlContent.Replace("@Deducciones", String.Format("{0:#,##0.00}", deducciones));
            htmlContent = htmlContent.Replace("@Neto", String.Format("{0:#,##0.00}", row["Ingresos_Netos"] ?? 0));


            MemoryStream memoryStream = new MemoryStream();
            Document document = new Document();
            PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);
            document.Open();
            XMLWorkerHelper.GetInstance().ParseXHtml(writer, document, new StringReader(htmlContent));
            document.Close();
            byte[] bytes = memoryStream.ToArray();
            memoryStream.Close();
            return File(bytes, "application/pdf", "file.pdf");

        }

        [HttpGet]
        public ActionResult ImprimirTodosPdf(string fecha)
        {
            try
            {
                string fechaInicial = fecha.Substring(0, 10);
                string fechaFinal = fecha.Substring(13, 10);
                DateTime fechaI, fechaF;
                fechaI = DateTime.ParseExact(fechaInicial, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                fechaF = DateTime.ParseExact(fechaFinal, "yyyy-MM-dd", CultureInfo.InvariantCulture);

                List<Planilla_VM> lista = LnPlanilla.GenerarPlanilla(fechaI, fechaF);

                string htmlFilePath = Server.MapPath("~/Views/Planilla/Plantilla.html");
                string htmlContent = System.IO.File.ReadAllText(htmlFilePath);

                MemoryStream memoryStream = new MemoryStream();
                Document document = new Document();
                PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);
                document.Open();

                for (int i = 0; i < lista.Count; i++)
                {
                    string htmlContentPage = htmlContent;
                    htmlContentPage = htmlContentPage.Replace("@rango", fecha);
                    htmlContentPage = htmlContentPage.Replace("@CodigoNombre", lista[i].Codigo_Empleado + lista[i].Nombre_Completo);
                    htmlContentPage = htmlContentPage.Replace("@TipoContrato", lista[i].TipodeContrato);
                    htmlContentPage = htmlContentPage.Replace("@Cargo", lista[i].Cargo);

                    htmlContentPage = htmlContentPage.Replace("@SalarioMensual", lista[i].Salario_Basico.ToString("#,##0.00"));
                    htmlContentPage = htmlContentPage.Replace("@Area", lista[i].NombreArea);
                    
                    htmlContentPage = htmlContentPage.Replace("@FechaIngreso", (lista[i].Fecha_de_Ingreso)?.ToString("yyyy-MM-dd"));

                    htmlContentPage = htmlContentPage.Replace("@Salario", lista[i].Monto_Salario?.ToString("#,##0.00") );

                    htmlContentPage = htmlContentPage.Replace("@Ant", lista[i].Antiguedad?.ToString("#,##0.00"));

                    htmlContentPage = htmlContentPage.Replace("@Total", (lista[i].Monto_Salario + lista[i].Antiguedad)?.ToString("#,##0.00"));

                    htmlContentPage = htmlContentPage.Replace("@INSS", lista[i].INSS?.ToString("#,##0.00"));

                    htmlContentPage = htmlContentPage.Replace("@IR", lista[i].IR_Mensual?.ToString("#,##0.00") );
                    htmlContentPage = htmlContentPage.Replace("@Deducciones", (lista[i].INSS + lista[i].IR_Mensual)?.ToString("#,##0.00") );
                    htmlContentPage = htmlContentPage.Replace("@Neto", lista[i].Ingresos_Netos?.ToString("#,##0.00"));

                    XMLWorkerHelper.GetInstance().ParseXHtml(writer, document, new StringReader(htmlContentPage));
                    document.NewPage();
                }

                document.Close();
                byte[] bytes = memoryStream.ToArray();
                memoryStream.Close();
                return File(bytes, "application/pdf", "archivo.pdf");
            }
            catch
            {
                return Content($"Error al generar el archivo PDF");
            }

        }
    }
}

