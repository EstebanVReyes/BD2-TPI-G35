using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio;
using Negocio;

namespace InventarioApp
{
    public partial class FormStock : Form
    {
        public FormStock()
        {
            InitializeComponent();
            this.Text = "Consulta de Stock";
            this.BackColor = Color.White;
     
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        private void FormStock_Load(object sender, EventArgs e)
        {


            // ✅ Ventana limpia


            estiloControles();

            // ✅ Cargar datos
            cargarStock();

            // ✅ Formatear grid
            formatearGrid();


        }

        private void cargarStock()
        {
            try
            {
                StockNegocio negocio = new StockNegocio();

                dgvStock.DataSource = negocio.listarStock();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el stock: " + ex.Message);
            }
        }


        private void formatearGrid()
        {
            dgvStock.RowHeadersVisible = false;

            dgvStock.BackgroundColor = Color.White;
            dgvStock.BorderStyle = BorderStyle.FixedSingle;

            dgvStock.EnableHeadersVisualStyles = true;

            dgvStock.DefaultCellStyle.Font = new Font("Segoe UI", 10);

            dgvStock.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvStock.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvStock.MultiSelect = false;
            dgvStock.AllowUserToAddRows = false;

            // Encabezados
            dgvStock.Columns["Rubro"].HeaderText = "Rubro";
            dgvStock.Columns["CodigoBase"].HeaderText = "Código";
            dgvStock.Columns["Color"].HeaderText = "Color";
            dgvStock.Columns["Talle"].HeaderText = "Talle";
            dgvStock.Columns["Descripcion"].HeaderText = "Descripción";
            dgvStock.Columns["Cantidad"].HeaderText = "Cantidad";
            dgvStock.Columns["Precio"].HeaderText = "Precio";
            dgvStock.Columns["Deposito"].HeaderText = "Depósito";

            // Alineación
            dgvStock.Columns["Cantidad"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvStock.Columns["Precio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvStock.Columns["Precio"].DefaultCellStyle.Format = "N0";
        }


        private void estiloControles()
        {
            // Título (el que ya tenés en el diseñador)
            lblTitulo.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            lblTitulo.AutoSize = true;

            // Centrar título
            lblTitulo.Left = (this.ClientSize.Width - lblTitulo.Width) / 2;

            // Label buscar
            lblbuscar.Font = new Font("Segoe UI", 10);

            // TextBox
            txtBuscar.Font = new Font("Segoe UI", 10);
            txtBuscar.BorderStyle = BorderStyle.FixedSingle;

            // Botón
            btnbuscar.Font = new Font("Segoe UI", 10);
            btnbuscar.FlatStyle = FlatStyle.Flat;
            btnbuscar.FlatAppearance.BorderColor = Color.Gray;
            btnbuscar.Width = 90;
            btnbuscar.Height = 28;
        }
    }





}

