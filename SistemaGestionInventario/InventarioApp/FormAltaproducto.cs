using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AccesoDatos;
using Negocio;


namespace InventarioApp
{
    public partial class FormAltaproducto : Form
    {
        public FormAltaproducto()
        {
            InitializeComponent();
        }

        private void FormAltaproducto_Load(object sender, EventArgs e)
        {
            CargarCombos();
            CargarColorYTalle();
        }



        private void CargarCombos()
        {
            ArticuloNegocio negocio = new ArticuloNegocio();

            //RUBRO
            cmbRubro.DataSource = negocio.ObtenerRubros();
            cmbRubro.DisplayMember = "Nombre";
            cmbRubro.ValueMember = "idRubro";

            //------------------------------------------------

            // MARCA
            cmbMarca.DataSource = negocio.ObtenerMarcas();
            cmbMarca.DisplayMember = "Nombre";
            cmbMarca.ValueMember = "idMarca";

            //------------------------------------------------

            // PROVEEDOR
            cmbProveedor.DataSource = negocio.ObtenerProveedores();
            cmbProveedor.DisplayMember = "Nombre";
            cmbProveedor.ValueMember = "idProveedor";
        }


        private void CargarColorYTalle()
        {
            ArticuloNegocio negocio = new ArticuloNegocio();

            clbColor.DataSource = negocio.ObtenerColores();
            clbColor.DisplayMember = "Nombre";
            clbColor.ValueMember = "idColor";

            clbTalle.DataSource = negocio.ObtenerTalles();
            clbTalle.DisplayMember = "Nombre";
            clbTalle.ValueMember = "idTalle";
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            // ✅ Validaciones básicas
            if (string.IsNullOrWhiteSpace(txtCodigoBase.Text))
            {
                MessageBox.Show("El código es obligatorio");
                return;
            }

            if (txtCodigoBase.Text.Length != 5 || !txtCodigoBase.Text.All(char.IsDigit))
            {
                MessageBox.Show("El código debe tener exactamente 5 dígitos numéricos");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El nombre es obligatorio");
                return;
            }

            if (clbColor.CheckedItems.Count == 0)
            {
                MessageBox.Show("Seleccioná al menos un color");
                return;
            }

            if (clbTalle.CheckedItems.Count == 0)
            {
                MessageBox.Show("Seleccioná al menos un talle");
                return;
            }

            try
            {
                ArticuloNegocio negocio = new ArticuloNegocio();

                // ✅ 1. Insertar artículo
                int idArticulo = negocio.InsertarArticulo(
                    txtCodigoBase.Text,
                    txtNombre.Text,
                    txtDescripcion.Text,
                     
                    (int)cmbRubro.SelectedValue,
                    (int)cmbMarca.SelectedValue,
                    (int)cmbProveedor.SelectedValue
                );

                // ✅ 2. Insertar combinaciones Color + Talle + SKU
                string codigoBase = txtCodigoBase.Text;

                decimal precio;

                if (!decimal.TryParse(txtPrecio.Text, out precio))
                {
                    MessageBox.Show("Ingrese un precio válido");
                    return;
                }


                foreach (DataRowView color in clbColor.CheckedItems)
                {
                    int idColor = Convert.ToInt32(color["idColor"]);
                    string codColor = color["Codigo"].ToString();

                    foreach (DataRowView talle in clbTalle.CheckedItems)
                    {
                        int idTalle = Convert.ToInt32(talle["idTalle"]);
                        string codTalle = talle["Codigo"].ToString();

                        // ✅ SKU = CodigoBase + CodigoColor + CodigoTalle
                        string sku = codigoBase + codColor + codTalle;

                        negocio.InsertarDetalle(idArticulo, idColor, idTalle, sku, precio);
                    }
                }

                MessageBox.Show("Artículo guardado correctamente ✅");

                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }



        }

        private void LimpiarCampos()
        {
            txtCodigoBase.Clear();
            txtNombre.Clear();
            txtDescripcion.Clear();

            cmbRubro.SelectedIndex = 0;
            cmbMarca.SelectedIndex = 0;
            cmbProveedor.SelectedIndex = 0;

            for (int i = 0; i < clbColor.Items.Count; i++)
                clbColor.SetItemChecked(i, false);

            for (int i = 0; i < clbTalle.Items.Count; i++)
                clbTalle.SetItemChecked(i, false);
        }
    }
}
