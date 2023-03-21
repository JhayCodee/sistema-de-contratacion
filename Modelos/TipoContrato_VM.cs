using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class TipoContrato_VM
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TipoContrato_VM()
        {
            this.Contrato = new HashSet<Contrato_VM>();
        }

        public int IdTipoContrato { get; set; }
        public string NombreTipoContrato { get; set; }
        public bool AplicaAguinaldo { get; set; }
        public bool AplicaIndemnizacion { get; set; }
        public bool Activo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Contrato_VM> Contrato { get; set; }
    }
}
