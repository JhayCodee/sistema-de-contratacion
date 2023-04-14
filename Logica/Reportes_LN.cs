using Datos;
using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class Reportes_LN
    {
        private readonly Contexto _bd;

        public Reportes_LN()
        {
            _bd = new Contexto();
        }

        // get lista de personal por area
        public List<PersonalPorArea_VM> ObtenerPersonalPorAreas()
        {
            List<PersonalPorArea_VM> lista = new List<PersonalPorArea_VM>();

            lista = _bd.spReportePersonalPorArea()
            .Select(i => new PersonalPorArea_VM
            {
                NombreArea = i.NombreArea,
                SumaSalarios = i.SumaSalarios,
                Hombres = i.Hombres,
                Mujeres = i.Mujeres,
                TotalEmpleados = i.TotalEmpleados
            }).ToList();

            return lista;
        }


        // get lista de personal por cargo
        public List<PersonalPorCargo_VM> ObtenerPersonalPorCargo()
        {
            List<PersonalPorCargo_VM> lista = new List<PersonalPorCargo_VM>();

            lista = _bd.spReportePersonalXCargo()
            .Select(i => new PersonalPorCargo_VM
            {
                NombreCargo = i.NombreCargo,
                SumaSalarios = i.SumaSalarios,
                Hombres = i.Hombres,
                Mujeres = i.Mujeres,
                TotalEmpleados = i.TotalEmpleados
            }).ToList();

            return lista;
        }

        // get lista de personal por rango salarial
        public List<PersonalPorRangoSalarial_VM> ObtenerPersonalPorRangoSalarial()
        {
            List<PersonalPorRangoSalarial_VM> lista = new List<PersonalPorRangoSalarial_VM>();

            lista = _bd.spReportePorRangoSalarial()
            .Select(i => new PersonalPorRangoSalarial_VM
            {
                Rango = i.Rango,
                Hombres = i.Hombres,
                Mujeres = i.Mujeres,
                TotalEmpleados = i.TotalEmpleados
            }).ToList();

            return lista;
        }

    }
}
