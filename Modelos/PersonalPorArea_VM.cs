using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class PersonalPorArea_VM
    {
        public string NombreArea { get; set; }
        public Nullable<double> SumaSalarios { get; set; }
        public Nullable<int> Hombres { get; set; }
        public Nullable<int> Mujeres { get; set; }
        public Nullable<int> TotalEmpleados { get; set; }
    }
}
