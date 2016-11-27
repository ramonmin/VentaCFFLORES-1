using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.IO;
using System.Web.Script.Serialization;
using System.Collections.Generic;
using System.Text;

namespace CFFLORES.TestRest
{
    [TestClass]
    public class VentaTest
    {
        [TestMethod]
        public void TestListar()
        {
            string busqueda = "2";
            string valor = "11111111";
            try
            {
                
                string URLAuth = "http://localhost:24832/Venta.svc/Venta/" + busqueda.ToString() + "/" + valor.ToString();

                HttpWebRequest req = (HttpWebRequest)WebRequest.
                    Create(URLAuth);
                req.Method = "GET";

                req.ContentType = "application/json";

                var res = (HttpWebResponse)req.GetResponse();
                StreamReader reader = new StreamReader(res.GetResponseStream());
                string clienteJson = reader.ReadToEnd();
                JavaScriptSerializer JsonConvert = new JavaScriptSerializer();
                List<Venta> registros = new List<Venta>();
                registros = JsonConvert.Deserialize<List<Venta>>(clienteJson);

                foreach (var value in registros)
                {
                    Assert.AreEqual(valor, value.Dni);
                }

            }
            catch (WebException ex)
            {
                HttpStatusCode code = ((HttpWebResponse)ex.Response).StatusCode;
                string message = ((HttpWebResponse)ex.Response).StatusDescription;
                StreamReader reader = new StreamReader(ex.Response.GetResponseStream());
                string error = reader.ReadToEnd();
                JavaScriptSerializer js = new JavaScriptSerializer();
                string mensaje = js.Deserialize<string>(error);
                if (busqueda.Equals("2"))
                    Assert.AreEqual("La Busqueda por DNI debe contener 8 Caracteres", mensaje);
                else if (busqueda.Equals("3"))
                    Assert.AreEqual("La Busqueda por Serie debe contener 3 Caracteres", mensaje);
                else
                    Assert.AreEqual("No Existe Venta", mensaje);

            }
        }
        [TestMethod]
        public void TestModificar()
        {
            string idcliente = "1";
            string estado = "0";
            string postdata = "{\"IdVenta\":\"" + idcliente + "\",\"Estado\":\"" + estado + "\"}";
            //string postdata = "{\"IdVenta\":\"1\",\"Estado\":\"true\"}";
            byte[] data = Encoding.UTF8.GetBytes(postdata);
            string URLAuth = "http://localhost:24832/Venta.svc/Venta";

            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(URLAuth);
            req.Method = "PUT";
            req.ContentLength = data.Length;
            req.ContentType = "application/json";
            var reqStream = req.GetRequestStream();
            reqStream.Write(data, 0, data.Length);
            var res = (HttpWebResponse)req.GetResponse();
            StreamReader reader = new StreamReader(res.GetResponseStream());
            string clienteJson = reader.ReadToEnd();
            JavaScriptSerializer JsonConvert = new JavaScriptSerializer();
           List<Venta> registros = new List<Venta>();
                registros = JsonConvert.Deserialize<List<Venta>>(clienteJson);

                foreach (var value in registros)
                {
                    Assert.AreEqual(idcliente, value.IdVenta.ToString());
                }

            }
            catch (WebException ex)
            {
                HttpStatusCode code = ((HttpWebResponse)ex.Response).StatusCode;
                string message = ((HttpWebResponse)ex.Response).StatusDescription;
                StreamReader reader = new StreamReader(ex.Response.GetResponseStream());
                string error = reader.ReadToEnd();
                JavaScriptSerializer js = new JavaScriptSerializer();
                string mensaje = js.Deserialize<string>(error);
                if (estado.Equals("1"))
                    Assert.AreEqual("No se puede Anular la Venta, ya se encuentra contabilizado", mensaje);
                else if (estado.Equals("2"))
                    Assert.AreEqual("La venta ya se encuentra Anulada", mensaje);
                else if (estado.Equals("3"))
                    Assert.AreEqual("No Existe Venta", mensaje);

            }

}
    }
}
