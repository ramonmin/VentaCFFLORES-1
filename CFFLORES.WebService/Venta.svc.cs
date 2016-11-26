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
        public List<EVenta> Listar(string busqueda, string Valor)
        {
            /*
             busqueda:
             1: Listar
             2: Por Dni
             3: Por Serie
             4: Por Id
             */
            if (String.IsNullOrEmpty(busqueda)) busqueda = "1";
            if (String.IsNullOrEmpty(Valor)) Valor = "1";

            if (busqueda.Equals("2") &&  Valor.Length != 8)//Busqueda por DNI
            {
                throw new WebFaultException<string>("La Busqueda por DNI debe contener 8 Caracteres", HttpStatusCode.InternalServerError);
            }

            if (busqueda.Equals("3") && Valor.Length != 3)//Busqueda por Serie
            {
                throw new WebFaultException<string>("La Busqueda por Serie debe contener 3 Caracteres", HttpStatusCode.InternalServerError);
            }

            List<EVenta> obobVenta = new List<EVenta>();
            obobVenta = dao.Listar(busqueda, Valor);

            if (obobVenta.Capacity == 0)
            {
                throw new WebFaultException<string>("No Existe Venta", HttpStatusCode.InternalServerError);

            }



            return obobVenta;


        }
        
        public List<EVenta> Modificar(EVenta beventa)
        {

            /*
             Estados:
             0: Venta
             1: Contabilizado
             2: Anulado
             */
             if (beventa == null)
            {
                beventa = new EVenta { IdVenta = 0,Estado=0 };
            }

            List<EVenta> obobVenta = new List<EVenta>();

            obobVenta = dao.Listar("4", beventa.IdVenta.ToString());

            if (obobVenta.Capacity == 0)
            {
                throw new WebFaultException<string>("No Existe Venta", HttpStatusCode.InternalServerError);

            }

            string estado = obobVenta[0].Estado.ToString();
            if (estado.Equals("1"))
            {
                throw new WebFaultException<string>("No se puede Anular la Venta, ya se encuentra contabilizado", HttpStatusCode.InternalServerError);

            }
            if (estado.Equals("2"))
            {
                throw new WebFaultException<string>("La venta ya se encuentra Anulada", HttpStatusCode.InternalServerError);

            }

            List<EVenta> obobVentaresult = new List<EVenta>();
            obobVentaresult = dao.Modificar(beventa);



            return obobVentaresult;
        }
        
    
    }
}
