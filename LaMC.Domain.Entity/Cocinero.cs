using System;
using System.Collections.Generic;
using System.Text;

namespace LaMC.Domain.Entity
{
    public class Cocinero
    {
        public int IdCocinero { get; set; }
        public string Nombre { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }

        public virtual ICollection<DetalleFactura> DetalleFactura { get; set; }
    }
}
