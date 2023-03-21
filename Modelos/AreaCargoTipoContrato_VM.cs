using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class AreaCargoTipoContrato_VM
    {

        public List<Area_VM> ListaArea { get; set; }
        public List<Cargo_VM> ListaCargo { get; set; }
        public List<TipoContrato_VM> ListaTipoContrato { get; set; }

    }
}
