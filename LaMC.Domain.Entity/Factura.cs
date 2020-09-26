using System;
using System.Collections.Generic;
using System.Text;

namespace LaMC.Domain.Entity
{
    public class Factura
    {
        public int IdFactura { get; set; }
        public int IdCliente { get; set; }
        public int IdCamarero { get; set; }
        public int IdMesa { get; set; }
        public DateTime FechaFactura { get; set; }

        public virtual Camarero Camarero { get; set; }
        public virtual Cliente Cliente { get; set; }
        public virtual ICollection<DetalleFactura> DetalleFactura { get; set; }
        public virtual Mesa Mesa { get; set; }
    }
}
