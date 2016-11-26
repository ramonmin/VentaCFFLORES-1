using CFFLORES.WebService.Dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CFFLORES.WebService.Persistencia
{
    public class DAOVenta
    {
        private string cadenaconexion = "Data Source=a1d03a2d-9c0f-4408-a40e-a6c90072de9e.sqlserver.sequelizer.com;Initial Catalog=dba1d03a2d9c0f4408a40ea6c90072de9e;User Id=tvmfwzevhnftvnla;Password=2Ccx6Hj4f3x55DK6Quii6SixnKvTrFciBYEozCMmQGhaFo3U5qeDwtdiuMkumxKF;";
        //private string cadenaconexion = "Data Source=LAPTOP-C3204AHJ\\SQLEXPRESS;Initial Catalog=CFFLORESDB;Integrated Security=True";

        public List<EVenta> Listar(string busqueda, string Valor)
        {
            List<EVenta> lista = new List<EVenta>();

            string sql = "";
            if (busqueda.Equals("1")) //Listar
                sql = "SELECT * FROM venta";
            else if (busqueda.Equals("2")) //Por Dni
                sql = "SELECT * FROM venta where dni ="+ Valor;
            else if (busqueda.Equals("3")) //Por Serie
                sql = "SELECT * FROM venta where Serie =" + Valor;
            else if (busqueda.Equals("4")) //Por idVenta
                sql = "SELECT * FROM venta where IdVenta =" + Valor;

            try
            {
                using (SqlConnection con = new SqlConnection(cadenaconexion))
                {
                    con.Open();
                    using (SqlCommand com = new SqlCommand(sql, con))
                    {
                        using (SqlDataReader dr = com.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                EVenta ve = new EVenta();

                                ve.IdVenta = Convert.ToInt32(dr[0]);
                                ve.Dni = dr[1].ToString();
                                ve.Fecha = Convert.ToDateTime(dr[2]);
                                ve.TipoDoc = dr[3].ToString();
                                ve.NroDoc = dr[4].ToString();
                                ve.Serie = dr[5].ToString();
                                ve.Monto = Convert.ToDecimal(dr[6].ToString());
                                ve.Estado = Convert.ToInt32(dr[7].ToString());
                                ve.Cliente = dr[8].ToString();
                                lista.Add(ve);
                            }
                            dr.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return lista;
        }

        public List<EVenta> Modificar(EVenta venta)
        {
            /*
             Estados:
             0: Venta
             1: Contabilizado
             2: Anulado
             */
            List<EVenta> resultado = new List<EVenta>();

            string sql = "";
            if (venta.Estado ==0)
                sql = "update venta set Estado=2 where Idventa=@idventa ";
            else 
                sql = "update venta set Estado=Estado where Idventa=@idventa ";
            try
            {
                using (SqlConnection con = new SqlConnection(cadenaconexion))
                {
                    con.Open();
                    using (SqlCommand com = new SqlCommand(sql, con))
                    {
                        com.Parameters.Add(new SqlParameter("@idventa", venta.IdVenta));
                        com.ExecuteNonQuery();
                    }
                }
                resultado = Listar("4", venta.IdVenta.ToString());
                return resultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}