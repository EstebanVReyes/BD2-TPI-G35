using AccesoDatos;
using Negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ArticuloNegocio
    {


        public DataTable ObtenerRubros()
        {
            Conexion conexion = new Conexion();

            conexion.setearConsulta("SELECT idRubro, Nombre FROM Rubro");

            DataTable tabla = new DataTable();
            tabla.Load(conexion.ejecutarLectura());

            return tabla;
        }

        public DataTable ObtenerMarcas()
        {
            Conexion conexion = new Conexion();

            conexion.setearConsulta("SELECT idMarca, Nombre FROM Marca");

            DataTable tabla = new DataTable();
            tabla.Load(conexion.ejecutarLectura());

            return tabla;
        }

        public DataTable ObtenerProveedores()
        {
            Conexion conexion = new Conexion();

            conexion.setearConsulta("SELECT idProveedor, Nombre FROM Proveedor");

            DataTable tabla = new DataTable();
            tabla.Load(conexion.ejecutarLectura());

            return tabla;
        }


        public DataTable ObtenerColores()
        {
            Conexion conexion = new Conexion();

            conexion.setearConsulta("SELECT idColor, Codigo, Nombre FROM Color");

            DataTable tabla = new DataTable();
            tabla.Load(conexion.ejecutarLectura());

            return tabla;
        }



        public DataTable ObtenerTalles()
        {
            Conexion conexion = new Conexion();

            conexion.setearConsulta("SELECT idTalle, Codigo, Nombre FROM Talle");

            DataTable tabla = new DataTable();
            tabla.Load(conexion.ejecutarLectura());

            return tabla;
        }

        public int InsertarArticulo(string codigo, string nombre, string descripcion,
                            int idRubro, int idMarca, int idProveedor)
        {
            Conexion conexion = new Conexion();

            conexion.setearConsulta(@"
        INSERT INTO Articulo (CodigoBase, Nombre, Descripcion, idRubro, idMarca, idProveedor)
        VALUES (@cod, @nom, @desc, @rubro, @marca, @prov);
        SELECT SCOPE_IDENTITY();
    ");

            conexion.setearParametro("@cod", codigo);
            conexion.setearParametro("@nom", nombre);
            conexion.setearParametro("@desc", descripcion);
         
            conexion.setearParametro("@rubro", idRubro);
            conexion.setearParametro("@marca", idMarca);
            conexion.setearParametro("@prov", idProveedor);

            return Convert.ToInt32(conexion.ejecutarScalar());
        }

        public void InsertarDetalle(int idArticulo, int idColor, int idTalle, string sku,decimal Precio)
        {
            if (idArticulo <= 0 || idColor <= 0 || idTalle <= 0)
            {
                throw new Exception("Datos inválidos para insertar detalle");
            }

            Conexion conexion = new Conexion();

            conexion.setearConsulta(@"
        IF NOT EXISTS (
            SELECT 1
            FROM DetalleArticulo
            WHERE SKU = @sku
        )
        INSERT INTO DetalleArticulo (idArticulo, idColor, idTalle, SKU,precio)
        VALUES (@art, @color, @talle, @sku,@pre)
    ");

            conexion.setearParametro("@art", idArticulo);
            conexion.setearParametro("@color", idColor);
            conexion.setearParametro("@talle", idTalle);
            conexion.setearParametro("@sku", sku);
            conexion.setearParametro("@Pre", Precio);
            conexion.ejecutarAccion();
        }


    }
}
