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
    public class MesaDomain : IMesaDomain
    {
        private readonly IMesaRepository _Repository;
        public IConfiguration Configuration { get; }

        public MesaDomain(IMesaRepository repository, IConfiguration _configuration)
        {
            _Repository = repository;
            Configuration = _configuration;
        }

        public async Task<string> InsertAsync(Mesa model)
        {
            return await _Repository.InsertAsync(model);
        }

        public async Task<string> UpdateAsync(Mesa model)
        {
            return await _Repository.UpdateAsync(model);
        }

        public async Task<string> DeleteAsync(int? Id)
        {
            return await _Repository.DeleteAsync(Id);
        }

        public async Task<IEnumerable<Mesa>> GetAllAsync()
        {
            return await _Repository.GetAllAsync();
        }

        public async Task<Mesa> GetAsync(int? Id)
        {
            return await _Repository.GetAsync(Id);
        }
    }
}
