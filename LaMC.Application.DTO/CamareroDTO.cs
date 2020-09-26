using System;
using System.Collections.Generic;
using System.Text;

namespace LaMC.Application.DTO
{
    public class CamareroDTO
    {
        public int IdCamarero { get; set; }
        public string Nombre { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }

        public virtual ICollection<FacturaDTO> Factura { get; set; }
    }
}
