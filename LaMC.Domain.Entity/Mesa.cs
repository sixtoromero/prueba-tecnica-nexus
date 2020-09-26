using System;
using System.Collections.Generic;
using System.Text;

namespace LaMC.Domain.Entity
{
    public class Mesa
    {
        public int IdMesa { get; set; }
        public int NumMaxComensa { get; set; }
        public string Ubicacion { get; set; }

        public virtual ICollection<Factura> Factura { get; set; }
    }
}
