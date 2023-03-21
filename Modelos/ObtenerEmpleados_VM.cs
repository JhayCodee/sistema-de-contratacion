using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class ObtenerEmpleados_VM
    {
        public ObtenerEmpleados_VM(string codigo, int? genero, string telefonoPersonal, string emailPersonal, DateTime? fechaInicio, DateTime? fechaFin, string nombreArea, string nombreCargo, double salario, string fotografia, string tipoContrato, int idEmpleado, string nombres, string apellidos, string tiposangre)
        {
            Codigo = codigo;
            Genero = genero;
            TelefonoPersonal = telefonoPersonal;
            EmailPersonal = emailPersonal;
            FechaInicio = fechaInicio;
            FechaFin = fechaFin;
            NombreArea = nombreArea;
            NombreCargo = nombreCargo;
            Salario = salario;
            Fotografia = fotografia;
            TipoContrato = tipoContrato;
            IdEmpleado = idEmpleado;
            Nombres = nombres;
            Apellidos = apellidos;
            TipoSangre = tiposangre;
        }

        public ObtenerEmpleados_VM()
        {

        }

        public string Codigo { get; set; }
        public Nullable<int> Genero { get; set; }
        public string TelefonoPersonal { get; set; }
        public string EmailPersonal { get; set; }
        public Nullable<System.DateTime> FechaInicio { get; set; }
        public Nullable<System.DateTime> FechaFin { get; set; }
        public string NombreArea { get; set; }
        public string NombreCargo { get; set; }
        public double Salario { get; set; }
        public string Fotografia { get; set; }
        public string TipoContrato { get; set; }
        public int IdEmpleado { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string TipoSangre { get; set; }

    }
}
