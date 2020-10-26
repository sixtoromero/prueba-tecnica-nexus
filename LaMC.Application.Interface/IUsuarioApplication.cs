using LaMC.Application.DTO;
using LaMC.Transversal.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LaMC.Application.Interface
{
    public interface IUsuarioApplication : IApplication<UsuarioDTO>
    {
        Task<Response<UsuarioDTO>> getLogin(UsuarioDTO model);
    }
}
