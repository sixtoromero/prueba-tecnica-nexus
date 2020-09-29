﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LaMC.Domain.Entity
{
    public class TotalesByCamarero
    {
        public int IdCamarero { get; set; }
        public string Nombre { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public string Mes { get; set; }
        public decimal Total { get; set; }
    }
}
