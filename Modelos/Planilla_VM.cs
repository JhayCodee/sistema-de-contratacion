﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class Planilla_VM
    {
        public string Codigo_Empleado { get; set; }
        public string Nombre_Completo { get; set; }
        public Nullable<System.DateTime> Fecha_de_Ingreso { get; set; }
        public double Salario_Basico { get; set; }
        public string TipodeContrato { get; set; }
        public Nullable<int> Dias_de_Salario { get; set; }
        public Nullable<double> Monto_Salario { get; set; }
        public Nullable<double> Antiguedad { get; set; }
        public Nullable<double> INSS { get; set; }
        public Nullable<double> Total_Neto { get; set; }
        public Nullable<double> IR_Mensual { get; set; }
        public Nullable<double> Ingresos_Netos { get; set; }
        public string NombreArea { get; set; }
        public string Cargo { get; set; }

    }
}
