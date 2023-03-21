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
    public class Areas_LN
    {
        private readonly Contexto _bd;
    
        public Areas_LN()
        {
            _bd = new Contexto();
        }

        public List<Area_VM> ObtenerAreas()
        {
            List<Area_VM> lista = new List<Area_VM>();

            lista = _bd.Areas
            .Where(i => i.Activo == true)
            .Select(i => new Area_VM
            {
                IdArea = i.IdArea,
                CodigoArea = i.CodigoArea,
                NombreArea = i.NombreArea,
                Activo = i.Activo

            }).ToList();

            return lista;
        }

        public bool AgregarArea(Area_VM area)
        {
            try
            {
                var a = new Areas
                {
                    CodigoArea = area.CodigoArea,
                    NombreArea = area.NombreArea,
                    Activo = area.Activo
                };

                _bd.Areas.Add(a);
                _bd.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool ActualizarArea(Area_VM e)
        {
            try
            {
                var a = _bd.Areas.FirstOrDefault(x => x.IdArea == e.IdArea);

                if (a != null)
                {
                    a.CodigoArea = e.CodigoArea;
                    a.NombreArea = e.NombreArea;
                    a.Activo = e.Activo;

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

        public bool CodigoAreaExiste(string codigo)
        {
            return _bd.Areas.Any(e => e.CodigoArea == codigo);
        }

        public Area_VM BuscarAreaPorId(int id)
        {
            var e = _bd.Areas.Find(id);

            if (e != null)
            {
                Area_VM area = new Area_VM
                {
                    IdArea = e.IdArea,
                    CodigoArea = e.CodigoArea,
                    NombreArea = e.NombreArea,
                    Activo = e.Activo 
                };

                return area;
            }
            else
            {
                return null;
            }
        }

        public bool ValidarCodigoAreaConID(string codigo, int id)
        {
            if (!CodigoAreaExiste(codigo))
            {
                return true;
            }

            Areas e = _bd.Areas.Find(id);

            if (e != null && e.CodigoArea == codigo)
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
