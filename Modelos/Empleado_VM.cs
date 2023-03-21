using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class Empleado_VM
    {
        public Empleado_VM()
        {

        }

        public Empleado_VM(int id, string codigo, string nombres, string apellidos, Nullable<int> genero, string telefonoPersonal, string emailPersonal, string tipoSangre, string fotografia)
        {
            IdEmpleado = id;
            Codigo = codigo;
            Nombres = nombres;
            Apellidos = apellidos;
            Genero = genero;
            TelefonoPersonal = telefonoPersonal;
            EmailPersonal = emailPersonal;
            TipoSangre = tipoSangre;
            Fotografia = fotografia;
        }


        [Required]
        public int IdEmpleado { get; set; }
        
        [Required]
        public string Codigo { get; set; }
        
        [Required]
        public string Nombres { get; set; }
        
        [Required]
        public string Apellidos { get; set; }

        [Required]
        public Nullable<int> Genero { get; set; }

        [Required]
        public string TelefonoPersonal { get; set; }

        [Required]
        [EmailAddress]
        public string EmailPersonal { get; set; }

        [Required]
        public string TipoSangre { get; set; }

        public string Fotografia { get; set; }
    }
}
