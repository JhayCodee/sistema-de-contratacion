﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Datos
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class Contexto : DbContext
    {
        public Contexto()
            : base("name=Contexto")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Areas> Areas { get; set; }
        public virtual DbSet<Cargos> Cargos { get; set; }
        public virtual DbSet<Contrato> Contrato { get; set; }
        public virtual DbSet<Empleados> Empleados { get; set; }
        public virtual DbSet<TipoContrato> TipoContrato { get; set; }
        public virtual DbSet<Rangos> Rangos { get; set; }
        public virtual DbSet<RangosContrato> RangosContrato { get; set; }
    
        public virtual ObjectResult<Planilla_Result> Planilla(Nullable<System.DateTime> fechaInicio, Nullable<System.DateTime> fechaFin)
        {
            var fechaInicioParameter = fechaInicio.HasValue ?
                new ObjectParameter("FechaInicio", fechaInicio) :
                new ObjectParameter("FechaInicio", typeof(System.DateTime));
    
            var fechaFinParameter = fechaFin.HasValue ?
                new ObjectParameter("FechaFin", fechaFin) :
                new ObjectParameter("FechaFin", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Planilla_Result>("Planilla", fechaInicioParameter, fechaFinParameter);
        }
    
        public virtual ObjectResult<ObtenerEmpleados_Result> ObtenerEmpleados()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ObtenerEmpleados_Result>("ObtenerEmpleados");
        }
    
        public virtual ObjectResult<spCalcularAguinaldo_Result> spCalcularAguinaldo(Nullable<System.DateTime> finAguinaldo)
        {
            var finAguinaldoParameter = finAguinaldo.HasValue ?
                new ObjectParameter("FinAguinaldo", finAguinaldo) :
                new ObjectParameter("FinAguinaldo", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spCalcularAguinaldo_Result>("spCalcularAguinaldo", finAguinaldoParameter);
        }
    
        public virtual ObjectResult<spReportePersonalPorArea_Result> spReportePersonalPorArea()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spReportePersonalPorArea_Result>("spReportePersonalPorArea");
        }
    
        public virtual ObjectResult<spReportePersonalXCargo_Result> spReportePersonalXCargo()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spReportePersonalXCargo_Result>("spReportePersonalXCargo");
        }
    
        public virtual ObjectResult<spReportePorRangoSalarial_Result> spReportePorRangoSalarial()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spReportePorRangoSalarial_Result>("spReportePorRangoSalarial");
        }
    
        public virtual ObjectResult<spReportePersonalPorEdad_Result> spReportePersonalPorEdad()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spReportePersonalPorEdad_Result>("spReportePersonalPorEdad");
        }
    }
}
