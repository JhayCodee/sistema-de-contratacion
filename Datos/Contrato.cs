//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Datos
{
    using System;
    using System.Collections.Generic;
    
    public partial class Contrato
    {
        public int IdContrato { get; set; }
        public int IdEmpleado { get; set; }
        public Nullable<System.DateTime> FechaInicio { get; set; }
        public Nullable<System.DateTime> FechaFin { get; set; }
        public Nullable<int> IdArea { get; set; }
        public Nullable<int> IdCargo { get; set; }
        public Nullable<int> TipoContrato { get; set; }
        public Nullable<bool> EstadoFila { get; set; }
        public double Salario { get; set; }
    
        public virtual Areas Areas { get; set; }
        public virtual Cargos Cargos { get; set; }
        public virtual Empleados Empleados { get; set; }
        public virtual TipoContrato TipoContrato1 { get; set; }
    }
}
