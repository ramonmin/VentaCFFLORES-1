using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFFLORES.Presentacion
{
    public class Venta
    {
        public int IdVenta { get; set; }
        public string Dni { get; set; }
        public string Cliente{ get; set; }
        public DateTime Fecha { get; set; }
        public string TipoDoc { get; set; }
        public string NroDoc { get; set; }
        public string Serie { get; set; }
        public decimal Monto { get; set; }
        public int Estado { get; set; }
    }
}
