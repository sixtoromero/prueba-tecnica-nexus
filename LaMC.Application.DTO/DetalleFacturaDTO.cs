using System;
using System.Collections.Generic;
using System.Text;

namespace LaMC.Application.DTO
{
    public class DetalleFacturaDTO
    {
        public int IdDetalleFactura { get; set; }
        public int IdFactura { get; set; }
        public int IdCocinero { get; set; }
        public int Plato { get; set; }
        public decimal Importe { get; set; }        

        public virtual CocineroDTO Cocinero { get; set; }
        public virtual FacturaDTO Factura { get; set; }
    }
}
