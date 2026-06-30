using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos;
using Dominio;
using System.Data;
namespace Negocio
{
    public class StockNegocio
    {

        public List<Stock> listarStock()
        {
            List<Stock> lista = new List<Stock>();
            Conexion con = new Conexion();

            try
            {
                con.setearConsulta("SELECT * FROM VStockCompleto");
                SqlDataReader reader = con.ejecutarLectura();


                while (reader.Read())
                {
                    Stock s = new Stock();

                    s.Rubro = reader["Rubro"].ToString();
                    s.CodigoBase = reader["CodigoBase"].ToString();
                    s.Color = reader["Color"].ToString();
                    s.Talle = reader["Talle"].ToString();
                    s.Descripcion = reader["Descripcion"].ToString();   
                    s.Precio = reader["Precio"] != DBNull.Value ? Convert.ToDecimal(reader["Precio"]) : 0; 
                    s.Cantidad = (int)reader["Cantidad"];
                    s.Deposito = reader["Deposito"].ToString();

                    lista.Add(s);
                }


                reader.Close();
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ImportarDesdeTabla(DataTable tabla)
        {
            Conexion conexion = new Conexion();

            foreach (DataRow fila in tabla.Rows)
            {
                string consulta = @"INSERT INTO Stock_Temp
                            (CodBase, CodColor, CodTalle, Cantidad)
                            VALUES (@base, @color, @talle, @cantidad)";

                conexion.setearConsulta(consulta);
                conexion.setearParametro("@base", fila["CodBase"]);
                conexion.setearParametro("@color", fila["CodColor"]);
                conexion.setearParametro("@talle", fila["CodTalle"]);
                conexion.setearParametro("@cantidad", fila["Cantidad"]);

                conexion.ejecutarAccion();
            }


            conexion.setearSP("sp_ProcesarStock");
            conexion.ejecutarAccion();
        }




    }


}
