using LaMC.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LaMC.Domain.Interface
{
    public interface IViewFacturaDomain
    {
        Task<IEnumerable<ViewFactura>> getListFactura();
        Task<IEnumerable<ViewFactura>> getListFacturaByFecha(DateTime FechaInicio, DateTime FechaFin);
    }
}
