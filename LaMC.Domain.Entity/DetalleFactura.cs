using System;
using System.Collections.Generic;
using System.Text;

namespace LaMC.Domain.Entity
{
    public class DetalleFactura
    {
        public int IdDetalleFactura { get; set; }
        public int IdFactura { get; set; }
        public int IdCocinero { get; set; }
        public int Plato { get; set; }
        public decimal Importe { get; set; }

        public virtual Cocinero Cocinero { get; set; }
        public virtual Factura Factura { get; set; }

    }
}
