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
    public class Cargos_LN
    {
        private readonly Contexto _bd;

        public Cargos_LN ()
        {
            _bd = new Contexto();
        }


        public List<Cargo_VM> ObtenerCargos()
        {
            List<Cargo_VM> lista = new List<Cargo_VM>();

            lista = _bd.Cargos.Select(i => new Cargo_VM
            {
                IdCargo = i.IdCargo,
                CodigoCargo = i.CodigoCargo,
                NombreCargo = i.NombreCargo,
                RangoSalarioInicial = i.RangoSalarioInicial,
                RangoSalarialFinal = i.RangoSalarialFinal,
                Activo = i.Activo

            }).ToList();

            return lista;
        }

        public bool AgregarCargo (Cargo_VM c)
        {
            try
            {
                var cargo = new Cargos
                {
                    CodigoCargo = c.CodigoCargo,
                    NombreCargo = c.NombreCargo,
                    RangoSalarioInicial = c.RangoSalarioInicial,
                    RangoSalarialFinal = c.RangoSalarialFinal,
                    Activo = c.Activo
                };

                _bd.Cargos.Add(cargo);
                _bd.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool ActualizarCargo(Cargo_VM c)
        {
            var cargo = _bd.Cargos.FirstOrDefault(x => x.IdCargo == c.IdCargo);

            if (cargo != null)
            {
                cargo.CodigoCargo = c.CodigoCargo;
                cargo.NombreCargo = c.NombreCargo;
                cargo.RangoSalarioInicial = c.RangoSalarioInicial;
                cargo.RangoSalarialFinal = c.RangoSalarialFinal;
                cargo.Activo = c.Activo;

                _bd.Entry(cargo).State = EntityState.Modified;
                _bd.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public Cargo_VM BuscarCargoPorId(int id)
        {
            var e = _bd.Cargos.Find(id);

            if (e != null)
            {
                Cargo_VM cargo = new Cargo_VM
                {
                    IdCargo = e.IdCargo,
                    CodigoCargo = e.CodigoCargo,
                    NombreCargo = e.NombreCargo,
                    RangoSalarioInicial = e.RangoSalarioInicial,
                    RangoSalarialFinal = e.RangoSalarialFinal,
                    Activo = e.Activo
                };

                return cargo;
            }
            else
            {
                return null;
            }
        }

        public bool CodigoCargoExiste(string codigo)
        {
            return _bd.Cargos.Any(e => e.CodigoCargo == codigo);
        }


        public bool ValidarCodigoCargoConID(string codigo, int id)
        {
            if (!CodigoCargoExiste(codigo))
            {
                return true;
            }

            Cargos e = _bd.Cargos.Find(id);

            if (e != null && e.CodigoCargo == codigo)
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
