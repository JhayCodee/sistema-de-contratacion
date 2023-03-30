using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class PrestacionesSociales_VM
    {
        public string Codigo { get; set; }
        public Nullable<System.DateTime> FechaInicio { get; set; }
        public Nullable<System.DateTime> FechaFin { get; set; }
        public double Salario { get; set; }
        public Nullable<double> DiasAguinaldo { get; set; }
        public Nullable<double> MontoAguinaldo { get; set; }
        public Nullable<double> DiasVacaciones { get; set; }
        public Nullable<double> MontoVacaciones { get; set; }
        public Nullable<double> TotalProvision { get; set; }
        public string NombreCompleto { get; set; }
        public Nullable<double> diasIndem { get; set; }
        public Nullable<double> MontoIndem { get; set; }

    }
}
