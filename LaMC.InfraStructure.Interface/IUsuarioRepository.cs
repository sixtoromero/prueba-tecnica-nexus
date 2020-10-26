using LaMC.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LaMC.InfraStructure.Interface
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        Task<Usuario> getLogin(Usuario model);
    }
}
