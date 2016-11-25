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

        public List<EVenta> Listar(string Valor)
        {
            List<EVenta> lista = new List<EVenta>();

            string sql = "";
            if (Valor.Length == 1 )
                sql = "SELECT * FROM venta";
            else if (Valor.Length ==8)
                sql = "SELECT * FROM venta where dni ="+ Valor;
            else if (Valor.Length != 8)
                sql = "SELECT * FROM venta where Serie =" + Valor;

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

        public int AnularVenta(int idventa)
        {
            int ok;
            string sql = "update venta set Estado=0 where Idventa=@idventa ";
            try
            {
                using (SqlConnection con = new SqlConnection(cadenaconexion))
                {
                    con.Open();
                    using (SqlCommand com = new SqlCommand(sql, con))
                    {
                        com.Parameters.Add(new SqlParameter("@idventa", idventa));
                        ok = com.ExecuteNonQuery() == 1 ? 1 : 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ok;
        }
    }
}