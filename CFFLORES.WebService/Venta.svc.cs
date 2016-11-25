using CFFLORES.WebService.Dominio;
using CFFLORES.WebService.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace CFFLORES.WebService
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Venta" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Venta.svc o Venta.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Venta : IVenta
    {
        private DAOVenta dao = new DAOVenta();
        public List<EVenta> VentaListar(string Valor)
        {
            if (String.IsNullOrEmpty(Valor)) Valor = "";

            if (Valor.Length != 8 && Valor.Length != 3 && !Valor.Equals("1"))
            {
                throw new WebFaultException<string>("La Busqueda es por DNI (8 Caracteres) o Serie (3 Caracteres)", HttpStatusCode.InternalServerError);
            }

            List<EVenta> obobVenta = new List<EVenta>();
            obobVenta = dao.Listar(Valor);

            if (obobVenta.Capacity == 0)
            {
                throw new WebFaultException<string>("No Existen Ventas", HttpStatusCode.InternalServerError);

            }



            return obobVenta;


        }
        /*
        public int VentaAnular(int id)
        {
            return dao.AnularVenta(id);
        }
        */
    
    }
}
