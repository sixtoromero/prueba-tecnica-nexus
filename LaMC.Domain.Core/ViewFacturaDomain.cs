using LaMC.Domain.Entity;
using LaMC.Domain.Interface;
using LaMC.InfraStructure.Interface;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace LaMC.Domain.Core
{
    public class ViewFacturaDomain : IViewFacturaDomain
    {
        private readonly IViewFacturaRepository _Repository;
        public IConfiguration Configuration { get; }

        public ViewFacturaDomain(IViewFacturaRepository repository, IConfiguration _configuration)
        {
            _Repository = repository;
            Configuration = _configuration;
        }

        public async Task<IEnumerable<ViewFactura>> getListFactura()
        {
            return await _Repository.getListFactura();
        }

        public async Task<IEnumerable<ViewFactura>> getListFacturaByFecha(DateTime FechaInicio, DateTime FechaFin)
        {
            return await _Repository.getListFacturaByFecha(FechaInicio, FechaFin);
        }
    }
}
