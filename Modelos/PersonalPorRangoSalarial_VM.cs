using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class PersonalPorRangoSalarial_VM
    {
        public string Rango { get; set; }
        public Nullable<int> Hombres { get; set; }
        public Nullable<int> Mujeres { get; set; }
        public Nullable<int> TotalEmpleados { get; set; }
    }
}
