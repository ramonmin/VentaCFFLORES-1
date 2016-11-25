using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace CFFLORES.WebService.Dominio
{
    [DataContract]
    public class EVenta
    {
        [DataMember]
        public int IdVenta { get; set; }
        [DataMember]
        public string Dni { get; set; }
        [DataMember]
        public string Cliente { get; set; }
        [DataMember]
        public DateTime Fecha { get; set; }
        [DataMember]
        public string TipoDoc { get; set; }
        [DataMember]
        public string NroDoc { get; set; }
        [DataMember]
        public string Serie { get; set; }
        [DataMember]
        public decimal Monto { get; set; }
        [DataMember]
        public int Estado { get; set; }
    }
}