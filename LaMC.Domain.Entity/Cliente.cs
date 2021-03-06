﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LaMC.Domain.Entity
{
    public class Cliente
    {
        public int IdCliente { get; set; }
        public string Nombre { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public string Observaciones { get; set; }

        [NotMapped]
        public decimal Total { get; set; }

        public virtual ICollection<Factura> Factura { get; set; }
    }
}
