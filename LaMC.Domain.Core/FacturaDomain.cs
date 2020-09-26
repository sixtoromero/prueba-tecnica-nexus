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
    public class FacturaDomain : IFacturaDomain
    {
        private readonly IFacturaRepository _Repository;
        public IConfiguration Configuration { get; }

        public FacturaDomain(IFacturaRepository repository, IConfiguration _configuration)
        {
            _Repository = repository;
            Configuration = _configuration;
        }

        public async Task<string> InsertAsync(Factura model)
        {
            return await _Repository.InsertAsync(model);
        }

        public async Task<string> UpdateAsync(Factura model)
        {
            return await _Repository.UpdateAsync(model);
        }

        public async Task<string> DeleteAsync(int? Id)
        {
            return await _Repository.DeleteAsync(Id);
        }

        public async Task<IEnumerable<Factura>> GetAllAsync()
        {
            return await _Repository.GetAllAsync();
        }

        public async Task<Factura> GetAsync(int? Id)
        {
            return await _Repository.GetAsync(Id);
        }
    }
}
