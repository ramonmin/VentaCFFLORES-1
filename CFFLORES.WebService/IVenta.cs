using CFFLORES.WebService.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web.UI;

namespace CFFLORES.WebService
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IVenta" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IVenta
    {
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "Venta/{Valor}/", ResponseFormat = WebMessageFormat.Json)]
        List<EVenta> VentaListar(string Valor);
        /*
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "Cliente/{Venta}/", ResponseFormat = WebMessageFormat.Json)]
        int VentaAnular(int id);*/

        /* [OperationContract]
         [WebInvoke(Method = "PUT", UriTemplate = "Cliente", ResponseFormat = WebMessageFormat.Json)]
         ECliente ModificarCliente(ECliente clientes);

         [OperationContract]
         [WebInvoke(Method = "DELETE", UriTemplate = "Cliente/{dni}", ResponseFormat = WebMessageFormat.Json)]
         void EliminarCliente(string dni);*/

    }
}
