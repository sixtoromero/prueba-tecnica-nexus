using LaMC.Application.DTO;
using LaMC.Domain.Entity;
using LaMC.Transversal.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LaMC.Application.Interface
{
    public interface IClienteApplication : IApplication<ClienteDTO>
    {
        Task<Response<IEnumerable<ClienteDTO>>> GetClientesMayorCompra();
    }
}
