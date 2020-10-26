using System;
using System.Collections.Generic;
using System.Text;

namespace LaMC.Application.DTO
{
    public class UsuarioDTO
    {
        public int IdUsuario { get; set; }
        public string NombreUsuario { get; set; }
        public string Clave { get; set; }

        public string Token { get; set; }
    }
}
