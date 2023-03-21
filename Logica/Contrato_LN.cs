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
    public class Contrato_LN
    {
        private readonly Contexto _bd;

        public Contrato_LN()
        {
            _bd = new Contexto();
        }


        // agregar contrato
        public bool AgregarContrato(Contrato_VM c)
        {
            try
            {
                var contrato = new Contrato
                {
                    IdEmpleado = c.IdEmpleado,
                    FechaInicio = c.FechaInicio,
                    FechaFin = c.FechaFin,
                    IdArea = c.IdArea,
                    IdCargo = c.IdCargo,
                    TipoContrato = c.TipoContrato,
                    EstadoFila = c.EstadoFila,
                    Salario = c.Salario
                };

                _bd.Contrato.Add(contrato);
                _bd.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public ObtenerEmpleados_VM ObtenerInformacionPorId(int id)
        {
            var o = _bd.ObtenerEmpleados().FirstOrDefault(c => c.IdEmpleado == id);

            if (o != null)
            {
                var emp = new ObtenerEmpleados_VM
                (
                    o.Codigo,
                    o.Genero,
                    o.TelefonoPersonal,
                    o.EmailPersonal,
                    o.FechaInicio,
                    o.FechaFin,
                    o.NombreArea,
                    o.NombreCargo,
                    o.Salario,
                    o.Fotografia,
                    o.TipoContrato,
                    o.IdEmpleado,
                    o.Nombres,
                    o.Apellidos,
                    o.TipoSangre
                );

                return emp;
            }
            else
            {
                return null;
            }
        }

        public bool ActualizarContrato(Contrato_VM c)
        {
            try
            {
                var contrato = _bd.Contrato.FirstOrDefault(x => x.IdEmpleado == c.IdEmpleado);

                if (contrato != null)
                {
                    contrato.IdEmpleado = c.IdEmpleado;
                    contrato.FechaInicio = c.FechaInicio;
                    contrato.FechaFin = c.FechaFin;
                    contrato.IdArea = c.IdArea;
                    contrato.IdCargo = c.IdCargo;
                    contrato.TipoContrato = c.TipoContrato;
                    contrato.Salario = c.Salario;

                    _bd.Entry(contrato).State = EntityState.Modified;
                    _bd.SaveChanges();
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al actualizar el contrato: " + ex.Message);
                Console.WriteLine(ex.StackTrace);
                return false;
            }
        }

        public List<ObtenerEmpleados_VM> ObtenerListaEmpleadosYContrato()
        {
            List<ObtenerEmpleados_VM> listaEmpleados = new List<ObtenerEmpleados_VM>();
            var lista = _bd.ObtenerEmpleados();

            foreach (var i in lista)
            {
                var le = new ObtenerEmpleados_VM
                {
                    Codigo = i.Codigo,
                    Genero = i.Genero,
                    TelefonoPersonal = i.TelefonoPersonal,
                    EmailPersonal = i.EmailPersonal,
                    FechaInicio = i.FechaInicio,
                    FechaFin = i.FechaFin,
                    NombreArea = i.NombreArea,
                    NombreCargo = i.NombreCargo,
                    TipoContrato = i.TipoContrato,
                    Salario = i.Salario,
                    Fotografia = i.Fotografia,
                    IdEmpleado = i.IdEmpleado,
                    Nombres = i.Nombres,
                    Apellidos = i.Apellidos
                };

                listaEmpleados.Add(le);
            }

            return listaEmpleados;
        }


        // Obtener areas
        public List<Area_VM> ObtenerAreas()
        {
            var lista = _bd.Areas.Select(i => new Area_VM
            {
                IdArea = i.IdArea,
                NombreArea = i.NombreArea,
            }).ToList();

            return lista;
        }

        // obtener Cargos
        public List<Cargo_VM> ObtenerCargos()
        {
            var lista = _bd.Cargos.Select(i => new Cargo_VM
            {
                IdCargo = i.IdCargo,
                NombreCargo = i.NombreCargo,
            }).ToList();

            return lista;
        }

        // obtener TipoContrato
        public List<TipoContrato_VM> ObtenerTipoContrato()
        {
            var lista = _bd.TipoContrato.Select(i => new TipoContrato_VM
            {
                IdTipoContrato = i.IdTipoContrato,
                NombreTipoContrato = i.NombreTipoContrato,
            }).ToList();

            return lista;
        }

        //listas selectpicker
        public List<AreaCargoTipoContrato_VM> ObtenerListasSP()
        {
            List<Area_VM> listaareas = this.ObtenerAreas();
            List<Cargo_VM> listacargos = this.ObtenerCargos();
            List<TipoContrato_VM> listatipoContratos = this.ObtenerTipoContrato();

            AreaCargoTipoContrato_VM act = new AreaCargoTipoContrato_VM
            {
                ListaArea = listaareas,
                ListaCargo = listacargos,
                ListaTipoContrato = listatipoContratos
            };

            List<AreaCargoTipoContrato_VM> lista = new List<AreaCargoTipoContrato_VM>();

            lista.Add(act);

            return lista;
        }


    }
}
