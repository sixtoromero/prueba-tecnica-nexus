using System;
using System.Collections.Generic;
using System.Text;

namespace LaMC.Application.DTO
{
    public class FacturaDTO
    {
        public int IdFactura { get; set; }
        public int IdCliente { get; set; }
        public int IdCamarero { get; set; }
        public int IdMesa { get; set; }
        public DateTime FechaFactura { get; set; }

        public virtual CamareroDTO Camarero { get; set; }
        public virtual ClienteDTO Cliente { get; set; }
        public virtual ICollection<DetalleFacturaDTO> DetalleFactura { get; set; }
        public virtual MesaDTO Mesa { get; set; }
    }
}
