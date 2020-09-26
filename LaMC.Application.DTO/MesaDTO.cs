using System;
using System.Collections.Generic;
using System.Text;

namespace LaMC.Application.DTO
{
    public class MesaDTO
    {
        public int IdMesa { get; set; }
        public int NumMaxComensa { get; set; }
        public string Ubicacion { get; set; }

        public virtual ICollection<FacturaDTO> Factura { get; set; }
    }
}
