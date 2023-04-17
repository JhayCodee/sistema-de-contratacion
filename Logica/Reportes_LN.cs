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

        public List<PersonalPorRangoSalarial_VM> ObtenerRangoSalarialLINQ()
        {
            var res = from c in _bd.Contrato
                      join e in _bd.Empleados on c.IdEmpleado equals e.IdEmpleado
                      let rangoSalario = (c.Salario >= 0 && c.Salario <= 10000) ? "0 - 10000"
                                           : (c.Salario >= 10001 && c.Salario <= 20000) ? "10001 - 20000"
                                           : (c.Salario >= 20001 && c.Salario <= 30000) ? "20001 - 30000"
                                           : (c.Salario >= 30001 && c.Salario <= 40000) ? "30001 - 40000"
                                           : "40001 - mas"
                      where c.EstadoFila == true
                      group e by rangoSalario into g
                      select new PersonalPorRangoSalarial_VM
                      {
                          Rango = g.Key,
                          Hombres = g.Count(h => h.Genero == 1),
                          Mujeres = g.Count(m => m.Genero == 0 || m.Genero == 2),
                          TotalEmpleados = g.Count()
                      };

            return res.ToList();
        }



        public List<PersonalPorEdad_VM> ObtenerPersonalPorEdad()
        {
            List<PersonalPorEdad_VM> lista = new List<PersonalPorEdad_VM>();

            lista = _bd.spReportePersonalPorEdad()
            .Select(i => new PersonalPorEdad_VM
            {
                RangoAniosContrato = i.RangoAniosContrato,
                Hombres = i.Hombres,
                Mujeres = i.Mujeres,
                TotalEmpleados = i.TotalEmpleados
            }).ToList();

            return lista;
        }

    }
}
