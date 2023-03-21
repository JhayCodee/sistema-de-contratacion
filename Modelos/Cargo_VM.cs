using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class Cargo_VM
    {
         [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Cargo_VM()
        {
            this.Contrato = new HashSet<Contrato_VM>();
        }
    
        public int IdCargo { get; set; }
        public string CodigoCargo { get; set; }
        public string NombreCargo { get; set; }
        public Nullable<double> RangoSalarioInicial { get; set; }
        public Nullable<double> RangoSalarialFinal { get; set; }
        public bool Activo { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Contrato_VM> Contrato { get; set; }
    }
}
