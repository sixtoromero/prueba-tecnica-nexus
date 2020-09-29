using LaMC.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LaMC.InfraStructure.Interface
{
    public interface IViewFacturaRepository
    {
        Task<IEnumerable<ViewFactura>> getListFactura();
        Task<IEnumerable<ViewFactura>> getListFacturaByFecha(DateTime FechaInicio, DateTime FechaFin);
        Task<IEnumerable<TotalesByCamarero>> getTotalesporCamarero();

    }
}
