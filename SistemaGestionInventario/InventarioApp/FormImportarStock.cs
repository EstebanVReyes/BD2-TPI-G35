using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventarioApp
{
    public partial class FormImportarStock : Form
    {
        private DataTable tablaCargada;
        public FormImportarStock()
        {
            InitializeComponent();
        }




        private void btnImportar_Click(object sender, EventArgs e)
        {


            if (tablaCargada == null || tablaCargada.Rows.Count == 0)
            {
                MessageBox.Show("Primero debés buscar y cargar un archivo válido");
                return;
            }

            DialogResult r = MessageBox.Show(
                "¿Deseas importar los datos?",
                "Confirmar",
                MessageBoxButtons.YesNo);

            if (r == DialogResult.Yes)
            {
                StockNegocio negocio = new StockNegocio();

                //  LLAMA a la capa negocio
                negocio.ImportarDesdeTabla(tablaCargada);

                MessageBox.Show("Importación completada correctamente");
            }

        }



        private DataTable CargarGrilla(string ruta)
        {
            DataTable tabla = new DataTable();

            tabla.Columns.Add("CodBase");
            tabla.Columns.Add("CodColor");
            tabla.Columns.Add("CodTalle");
            tabla.Columns.Add("Cantidad", typeof(int));

            int filaNumero = 0;

            foreach (string linea in System.IO.File.ReadAllLines(ruta))
            {
                filaNumero++;

                if (string.IsNullOrWhiteSpace(linea))
                    continue;

                string[] datos = linea.Split(';');

                if (datos.Length < 4)
                    continue;

                if (string.IsNullOrWhiteSpace(datos[0]) ||
                    string.IsNullOrWhiteSpace(datos[1]) ||
                    string.IsNullOrWhiteSpace(datos[2]) ||
                    string.IsNullOrWhiteSpace(datos[3]))
                    continue;

                int cantidad;
                if (!int.TryParse(datos[3], out cantidad))
                    continue;

                tabla.Rows.Add(datos[0], datos[1], datos[2], cantidad);
            }

            dgvStock.DataSource = tabla;

            return tabla;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {


            OpenFileDialog archivo = new OpenFileDialog();
            archivo.Filter = "Archivos TXT (*.txt)|*.txt";

            if (archivo.ShowDialog() == DialogResult.OK)
            {
                txtRuta.Text = archivo.FileName;

                // Carga y valida
                tablaCargada = CargarGrilla(archivo.FileName);


            }
        }
    }
}
