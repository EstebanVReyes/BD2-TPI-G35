using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
public class Conexion
    {

        private string cadenaConexion = "Server=localhost,1433;Database=BD2_TPI_G35;User Id=sa;Password=Maycol-123456;TrustServerCertificate=True";

        private SqlConnection conexion;
        private SqlCommand comando;

        public Conexion()
        {
            conexion = new SqlConnection(cadenaConexion);
            comando = new SqlCommand();
        }

        public SqlDataReader ejecutarLectura()
        {
            SqlDataReader lector;

            try
            {
                comando.Connection = conexion;
                conexion.Open();
                lector = comando.ExecuteReader();
                return lector;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void setearConsulta(string consulta)
        {
            comando.CommandText = consulta;
            comando.CommandType = CommandType.Text;
            comando.Parameters.Clear();
        }


        public void setearSP(string nombreSP)
        {
            comando.CommandText = nombreSP;
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Clear();
        }

        public void setearParametro(string nombre, object valor)
        {
            comando.Parameters.AddWithValue(nombre, valor);
        }

        public void ejecutarAccion()
        {
            try
            {
                comando.Connection = conexion;
                conexion.Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al ejecutar acción: " + ex.Message);
            }
            finally
            {
                conexion.Close();
            }
        }

        public object ejecutarScalar()
        {
            try
            {
                comando.Connection = conexion;
                conexion.Open();
                return comando.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al ejecutar scalar: " + ex.Message);
            }
            finally
            {
                conexion.Close();
            }
        }


    }
}
