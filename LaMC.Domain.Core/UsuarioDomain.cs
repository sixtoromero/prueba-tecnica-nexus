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
    public class UsuarioDomain : IUsuarioDomain
    {
        private readonly IUsuarioRepository _Repository;
        public IConfiguration Configuration { get; }

        public UsuarioDomain(IUsuarioRepository repository, IConfiguration _configuration)
        {
            _Repository = repository;
            Configuration = _configuration;
        }

        public async Task<string> InsertAsync(Usuario model)
        {
            return await _Repository.InsertAsync(model);
        }

        public async Task<string> UpdateAsync(Usuario model)
        {
            return await _Repository.UpdateAsync(model);
        }

        public async Task<string> DeleteAsync(int? Id)
        {
            return await _Repository.DeleteAsync(Id);
        }

        public async Task<IEnumerable<Usuario>> GetAllAsync()
        {
            return await _Repository.GetAllAsync();
        }

        public async Task<Usuario> GetAsync(int? Id)
        {
            return await _Repository.GetAsync(Id);
        }

        public async Task<Usuario> getLogin(Usuario model)
        {
            return await _Repository.getLogin(model);
        }
    }
}
