using LaMC.Application.DTO;
using LaMC.Transversal.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LaMC.Application.Interface
{
    public interface IViewFacturaApplication
    {
        Task<Response<IEnumerable<ViewFacturaDTO>>> getListFactura();
        Task<Response<IEnumerable<ViewFacturaDTO>>> getListFacturaByFecha(DateTime FechaInicio, DateTime FechaFin);
        Task<Response<IEnumerable<TotalesByCamareroDTO>>> getTotalesporCamarero();
    }
}
