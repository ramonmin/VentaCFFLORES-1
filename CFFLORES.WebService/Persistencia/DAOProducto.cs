using CFFLORES.WebService.Dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CFFLORES.WebService.Persistencia
{
    public class DAOProducto
    {
        private string cadenaconexion = "Data Source=a1d03a2d-9c0f-4408-a40e-a6c90072de9e.sqlserver.sequelizer.com;Initial Catalog=dba1d03a2d9c0f4408a40ea6c90072de9e;User Id=tvmfwzevhnftvnla;Password=2Ccx6Hj4f3x55DK6Quii6SixnKvTrFciBYEozCMmQGhaFo3U5qeDwtdiuMkumxKF;";
        //private string cadenaconexion = "Data Source=LAPTOP-C3204AHJ\\SQLEXPRESS;Initial Catalog=CFFLORESDB;Integrated Security=True";
        public EProducto ObtenerProducto(string codigobarra, string nombre, string tipo)
        {

            EProducto productoEncontrado = null;
            string sql = "";
            if (codigobarra.Length != 0 && nombre.Length != 0 && tipo.Length != 0)
                 sql = "SELECT * FROM producto WHERE CodigoBarra = @cod and nombre = @nom and tipo = @tip";
            else if (codigobarra.Length != 0 && nombre.Length != 0 && tipo.Length == 0)
                sql = "SELECT * FROM producto WHERE CodigoBarra = @cod and nombre = @nom";
            else if (codigobarra.Length != 0 && nombre.Length == 0 && tipo.Length == 0)
                sql = "SELECT * FROM producto WHERE CodigoBarra = @cod";
            else if (codigobarra.Length == 0 && nombre.Length != 0 && tipo.Length != 0)
                sql = "SELECT * FROM producto WHERE nombre = @nom and tipo = @tip";
            else if (codigobarra.Length == 0 && nombre.Length == 0 && tipo.Length != 0)
                sql = "SELECT * FROM producto WHERE tipo = @tip";
            else if (codigobarra.Length == 0 && nombre.Length != 0 && tipo.Length == 0)
                sql = "SELECT * FROM producto WHERE nombre = @nom ";

            using (SqlConnection con = new SqlConnection(cadenaconexion))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    com.Parameters.Add(new SqlParameter("@cod", codigobarra));
                    com.Parameters.Add(new SqlParameter("@nom", nombre));
                    com.Parameters.Add(new SqlParameter("@tip", tipo));
                    using (SqlDataReader resultado = com.ExecuteReader())
                    {
                        if (resultado.Read())
                        {
                            productoEncontrado = new EProducto()
                            {
                                codigobarra = (string)resultado["CodigoBarra"],
                                Nombre = (string)resultado["Nombre"],
                                Stock = Int32.Parse(resultado["Stock"].ToString()),
                                Precio = Double.Parse(resultado["Precio"].ToString()),
                                Estado = (string)resultado["Estado"],
                                Tipo = (string)resultado["Tipo"]
                            };
                        }
                    }
                }
            }
            return productoEncontrado;
        }
        /*
        public EProducto CrearProducto(EProducto productoACrear)
        {
            EProducto productoCreado = null;
            string sql = "INSERT INTO producto VALUES (@cod, @nom,@stock,@precio)";
            using (SqlConnection con = new SqlConnection(cadenaconexion))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    com.Parameters.Add(new SqlParameter("@cod", productoACrear.codigobarra));
                    com.Parameters.Add(new SqlParameter("@nom", productoACrear.Nombre));
                    com.Parameters.Add(new SqlParameter("@stock", productoACrear.Stock));
                    com.Parameters.Add(new SqlParameter("@precio", productoACrear.Precio));
                    com.ExecuteNonQuery();
                }
            }
            productoCreado = ObtenerProducto(productoACrear.codigobarra);
            return productoCreado;
        }

        public EProducto ModificarProducto(EProducto productoACrear)
        {
            EProducto productoCreado = null;
            string sql = "update producto set Nombre = @nom, Stock = @, precio = @Precio where CodigoBarra = @cod ";
            using (SqlConnection con = new SqlConnection(cadenaconexion))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    com.Parameters.Add(new SqlParameter("@cod", productoACrear.codigobarra));
                    com.Parameters.Add(new SqlParameter("@nom", productoACrear.Nombre));
                    com.Parameters.Add(new SqlParameter("@stock", productoACrear.Stock));
                    com.Parameters.Add(new SqlParameter("@precio", productoACrear.Precio));
                    com.ExecuteNonQuery();
                }
            }
            productoCreado = ObtenerProducto(productoACrear.codigobarra);
            return productoCreado;
        }
*/
        public List<EProducto> ListarProducto()
        {
            List<EProducto> productoList = new List<EProducto>();
            EProducto productobe = null;
            string sql = "SELECT * FROM producto";
            using (SqlConnection con = new SqlConnection(cadenaconexion))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    using (SqlDataReader resultado = com.ExecuteReader())
                    {
                        while (resultado.Read())
                        {
                            productobe = new EProducto()
                            {
                                codigobarra = (string)resultado["CodigoBarra"].ToString(),
                                Nombre = (string)resultado["Nombre"].ToString(),
                                Stock = Int32.Parse(resultado["Stock"].ToString()),
                                Precio = Double.Parse(resultado["Precio"].ToString()),
                                Estado = (string)resultado["Estado"].ToString(),
                                Tipo = (string)resultado["Tipo"]
                            };
                            productoList.Add(productobe);
                        }
                    }
                }
            }
            return productoList;
        }

    }
}