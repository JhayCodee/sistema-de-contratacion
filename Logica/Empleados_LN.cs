using Datos;
using Modelos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class Empleados_LN
    {
        private readonly Contexto _bd;

        public Empleados_LN()
        {
            _bd = new Contexto();
        }

        // Devuelve la lista de empleados de la bd
        public List<Empleado_VM> ListarEmpleados()
        {
            var lista = _bd.Empleados.Select(i => new Empleado_VM
            {
                IdEmpleado = i.IdEmpleado,
                Codigo = i.Codigo,
                Nombres = i.Nombres,
                Apellidos = i.Apellidos,
                Genero = i.Genero,
                TelefonoPersonal = i.TelefonoPersonal,
                EmailPersonal = i.EmailPersonal,
                TipoSangre = i.TipoSangre,
                Fotografia = i.Fotografia

            }).ToList();
            return lista;
        }

        // agrega un empleado a la bd
        public bool AgregarEmpleado(Empleado_VM e)
        {
            try
            {
                var empleado = new Empleados
                {
                    Codigo = e.Codigo,
                    Nombres = e.Nombres,
                    Apellidos = e.Apellidos,
                    Genero = e.Genero,
                    TelefonoPersonal = e.TelefonoPersonal,
                    EmailPersonal = e.EmailPersonal,
                    TipoSangre = e.TipoSangre,
                    Fotografia = e.Fotografia
                };

                _bd.Empleados.Add(empleado);
                _bd.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool ActualizarEmpleado(Empleado_VM e)
        {
            try
            {
                var empleado = _bd.Empleados.FirstOrDefault(x => x.IdEmpleado == e.IdEmpleado);

                if (empleado != null)
                {
                    empleado.Codigo = e.Codigo;
                    empleado.Nombres = e.Nombres;
                    empleado.Apellidos = e.Apellidos;
                    empleado.Genero = e.Genero;
                    empleado.TelefonoPersonal = e.TelefonoPersonal;
                    empleado.EmailPersonal = e.EmailPersonal;
                    empleado.TipoSangre = e.TipoSangre;
                    empleado.Fotografia = e.Fotografia;

                    _bd.Entry(empleado).State = EntityState.Modified;
                    _bd.SaveChanges();
                    return true;
                }

                return false;
            }
            catch
            {
                return false;
            }
        }

        // verifica si el codigo de empleado existe o no
        public bool CodigoEmpleadoExiste(string codigo)
        {
            return _bd.Empleados.Any(e => e.Codigo == codigo);
        }

        // verifica si el correo ya existe
        public bool CorreoEmpleadoExiste(string correo)
        {
            return _bd.Empleados.Any(c => c.EmailPersonal == correo);
        }


        // Busca empleado x ID
        public Empleado_VM BuscarEmpleadoPorID(int id)
        {

            Empleados e = _bd.Empleados.Find(id);

            if (e != null)
            {
                var empleado = new Empleado_VM
            (
                e.IdEmpleado,
                e.Codigo,
                e.Nombres,
                e.Apellidos,
                e.Genero,
                e.TelefonoPersonal,
                e.EmailPersonal,
                e.TipoSangre,
                e.Fotografia
            );

                return empleado;
            }
            else
            {
                return null;
            }
            
        }

        public Empleado_VM BuscarEmpleadoPorCodigo(string codigo)
        {
            Empleados e = _bd.Empleados.SingleOrDefault(c => c.Codigo == codigo);

            if (e != null)
            {
                var empleado = new Empleado_VM
                (
                    e.IdEmpleado,
                    e.Codigo,
                    e.Nombres,
                    e.Apellidos,
                    e.Genero,
                    e.TelefonoPersonal,
                    e.EmailPersonal,
                    e.TipoSangre,
                    e.Fotografia
                );

                return empleado;
            }
            else
            {
                return null;
            }
        }


        public bool ValidarCorreoConID(string correo, int id)
        {
            // verificar si el correo existe
            // el correo pertenece a mi id?
            // si pertenece devolver false para permitir edicion
            // si no me pertenece true para no permitir

            if(!CorreoEmpleadoExiste(correo))
            {
                return true;
            }

            Empleados e = _bd.Empleados.Find(id);
            
            if (e != null && e.EmailPersonal == correo)
            {
                return true;
            }
            else
            {
                return false;
            }

        }


        public bool ValidarCodigoEmpleadoConID(string codigo, int id)
        {
            if (!CodigoEmpleadoExiste(codigo))
            {
                return true;
            }

            Empleados e = _bd.Empleados.Find(id);

            if (e != null && e.Codigo == codigo)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

    }

}
