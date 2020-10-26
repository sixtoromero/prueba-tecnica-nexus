using LaMC.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LaMC.Domain.Interface
{
    public interface IUsuarioDomain : IDomain<Usuario>
    {
        Task<Usuario> getLogin(Usuario model);
    }
}
