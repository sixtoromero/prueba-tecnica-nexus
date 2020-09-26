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
    public class CocineroDomain : ICocineroDomain
    {
        private readonly ICocineroRepository _Repository;
        public IConfiguration Configuration { get; }

        public CocineroDomain(ICocineroRepository repository, IConfiguration _configuration)
        {
            _Repository = repository;
            Configuration = _configuration;
        }

        public async Task<string> InsertAsync(Cocinero model)
        {
            return await _Repository.InsertAsync(model);
        }

        public async Task<string> UpdateAsync(Cocinero model)
        {
            return await _Repository.UpdateAsync(model);
        }

        public async Task<string> DeleteAsync(int? Id)
        {
            return await _Repository.DeleteAsync(Id);
        }

        public async Task<IEnumerable<Cocinero>> GetAllAsync()
        {
            return await _Repository.GetAllAsync();
        }

        public async Task<Cocinero> GetAsync(int? Id)
        {
            return await _Repository.GetAsync(Id);
        }
    }
}
