using Datos;
using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class PrestacionesSociales_LN
    {
        private readonly Contexto _db;

        public PrestacionesSociales_LN()
        {
            _db = new Contexto();
        }

        public List<PrestacionesSociales_VM> Prestaciones(DateTime corte)
        {
            List<PrestacionesSociales_VM> lista = new List<PrestacionesSociales_VM>();

            var l = _db.spCalcularAguinaldo(corte);

            foreach (var i in l)
            {
                var ps = new PrestacionesSociales_VM
                {
                    Codigo = i .Codigo,
                    FechaInicio = i.FechaInicio,
                    FechaFin = i .FechaFin,
                    Salario = i.Salario,
                    DiasAguinaldo = i.DiasAguinaldo,
                    MontoAguinaldo = i.MontoAguinaldo,
                    DiasVacaciones = i.DiasVacaciones,
                    MontoVacaciones = i.MontoVacaciones,
                    TotalProvision = i.TotalProvision,
                    NombreCompleto = i.NombreCompleto,
                    diasIndem = i.diasIndem,
                    MontoIndem = i.MontoIndem
                };

                lista.Add(ps);
            }
            return lista;
        }

    }
}
