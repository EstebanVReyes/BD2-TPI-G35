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
    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void transitoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void exportarATXTToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void verStockToolStripMenuItem_Click(object sender, EventArgs e)
        {

            FormStock frm = new FormStock();
            frm.Show();

        }

        private void ajusteStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormImportarStock frm = new FormImportarStock();
            frm.Show();

        }

        private void articulosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAltaproducto frm = new FormAltaproducto();
            frm.Show();

        }
    }
}
