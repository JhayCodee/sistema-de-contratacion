using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class Contrato_VM
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

        public virtual Area_VM Areas { get; set; }
        public virtual Cargo_VM Cargos { get; set; }
        public virtual Empleado_VM Empleados { get; set; }
        public virtual TipoContrato_VM TipoContrato1 { get; set; }
    }
}
