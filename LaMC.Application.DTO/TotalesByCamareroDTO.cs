using System;
using System.Collections.Generic;
using System.Text;

namespace LaMC.Application.DTO
{
    public class TotalesByCamareroDTO
    {
        public int IdCamarero { get; set; }
        public string Nombre { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public string Mes { get; set; }
        public decimal Total { get; set; }
    }
}
