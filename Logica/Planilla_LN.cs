using Datos;
using Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class Planilla_LN
    {
        private readonly Contexto _db;

        public Planilla_LN()
        {
            _db = new Contexto();
        }

        public List<Planilla_VM> GenerarPlanilla(DateTime fecha1, DateTime fecha2)
        {
            List<Planilla_VM> lt = new List<Planilla_VM>();
            
            var lista = _db.Planilla(fecha1, fecha2);

            foreach (var i in lista)
            {
                var planillaVM = new Planilla_VM
                {
                    Codigo_Empleado = i.Codigo_Empleado,
                    Nombre_Completo = i.Nombre_Completo,
                    Fecha_de_Ingreso = i.Fecha_de_Ingreso,
                    Salario_Basico = i.Salario_Basico,
                    TipodeContrato = i.TipodeContrato,
                    Dias_de_Salario = i.Dias_de_Salario,
                    Monto_Salario = i.Monto_Salario,
                    Antiguedad = i.Antiguedad,
                    INSS = i.INSS,
                    Total_Neto = i.Total_Neto,
                    IR_Mensual = i.IR_Mensual,
                    Ingresos_Netos = i.Ingresos_Netos,
                    NombreArea = i.NombreArea,
                    Cargo = i.Cargo
                };

                lt.Add(planillaVM);
            }

            return lt;        
        }

    }
}
