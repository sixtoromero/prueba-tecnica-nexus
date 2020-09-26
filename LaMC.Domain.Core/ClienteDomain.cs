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
    public class ClienteDomain : IClienteDomain
    {
        private readonly IClienteRepository _Repository;
        public IConfiguration Configuration { get; }

        public ClienteDomain(IClienteRepository clienteRepository, IConfiguration _configuration)
        {
            _Repository = clienteRepository;
            Configuration = _configuration;
        }

        public async Task<string> InsertAsync(Cliente model)
        {
            return await _Repository.InsertAsync(model);
        }

        public async Task<string> UpdateAsync(Cliente model)
        {
            return await _Repository.UpdateAsync(model);
        }

        public async Task<string> DeleteAsync(int? Id)
        {
            return await _Repository.DeleteAsync(Id);
        }

        public async Task<IEnumerable<Cliente>> GetAllAsync()
        {
            return await _Repository.GetAllAsync();
        }

        public async Task<Cliente> GetAsync(int? Id)
        {
            return await _Repository.GetAsync(Id);
        }
    }
}
