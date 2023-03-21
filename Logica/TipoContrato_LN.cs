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
    public class TipoContrato_LN
    {
        private readonly Contexto _bd;

        public TipoContrato_LN()
        {
            _bd = new Contexto();
        }


        public List<TipoContrato_VM> ObtnerTipoContrato()
        {
            List<TipoContrato_VM> lista = new List<TipoContrato_VM>();

            lista = _bd.TipoContrato.Select(i => new TipoContrato_VM
            {
               IdTipoContrato = i.IdTipoContrato,
               NombreTipoContrato = i.NombreTipoContrato,
               AplicaAguinaldo = i.AplicaAguinaldo,
               AplicaIndemnizacion = i.AplicaIndemnizacion,
               Activo = i.Activo

            }).ToList();

            return lista;
        }

        public bool AgregarTipoContrato(TipoContrato_VM tp)
        {
            try
            {
                var a = new TipoContrato
                {
                    NombreTipoContrato = tp.NombreTipoContrato,
                    AplicaIndemnizacion = tp.AplicaIndemnizacion,
                    AplicaAguinaldo = tp.AplicaAguinaldo,
                    Activo = tp.Activo
                };

                _bd.TipoContrato.Add(a);
                _bd.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool ActualizarTipoContrato(TipoContrato_VM tp)
        {
            try
            {
                var a = _bd.TipoContrato.FirstOrDefault(x => x.IdTipoContrato == tp.IdTipoContrato);

                if (a != null)
                {
                    a.NombreTipoContrato = tp.NombreTipoContrato;
                    a.AplicaAguinaldo = tp.AplicaAguinaldo;
                    a.AplicaIndemnizacion = tp.AplicaIndemnizacion;
                    a.Activo = tp.Activo;

                    _bd.Entry(a).State = EntityState.Modified;
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

        public TipoContrato_VM BuscarTipoContratoPorId(int id)
        {
            var tp = _bd.TipoContrato.Find(id);

            if (tp != null)
            {
                TipoContrato_VM e = new TipoContrato_VM
                {
                    IdTipoContrato = tp.IdTipoContrato,
                    NombreTipoContrato = tp.NombreTipoContrato,
                    AplicaAguinaldo = tp.AplicaAguinaldo,
                    AplicaIndemnizacion = tp.AplicaIndemnizacion,
                    Activo = tp.Activo
                };

                return e;
            }
            else
            {
                return null;
            }
        }

    }
}
