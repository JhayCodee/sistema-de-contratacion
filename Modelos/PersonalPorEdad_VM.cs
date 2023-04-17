using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class PersonalPorEdad_VM
    {
        public string RangoAniosContrato { get; set; }
        public Nullable<int> Hombres { get; set; }
        public Nullable<int> Mujeres { get; set; }
        public Nullable<int> TotalEmpleados { get; set; }
    }
}
