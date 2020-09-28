using System;
using System.Collections.Generic;
using System.Text;

namespace LaMC.Application.DTO
{
    public class ViewFacturaDTO
    {
        public int IdFactura { get; set; }
        public string Cliente { get; set; }
        public string Camarero { get; set; }
        public string Mesa { get; set; }
        public DateTime Fecha { get; set; }
    }
}
