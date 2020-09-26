using System;
using System.Collections.Generic;
using System.Text;

namespace LaMC.Application.DTO
{
    public class ClienteDTO
    {
        public int IdCliente { get; set; }
        public string Nombre { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public string Observaciones { get; set; }

        public virtual ICollection<FacturaDTO> Factura { get; set; }
    }
}
