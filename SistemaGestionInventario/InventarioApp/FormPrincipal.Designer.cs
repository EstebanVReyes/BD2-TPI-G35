namespace InventarioApp
{
    partial class FormPrincipal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.inventarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verStockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ajusteStockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportarStockTXTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.articulosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.coloresToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tallesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.marcaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rubroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transitoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mercaderiaEnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mercaderiaEnTransitoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productosToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.verMovimientosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.historialToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.coloresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportarATXTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.talleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.inventarioToolStripMenuItem,
            this.productosToolStripMenuItem,
            this.transitoToolStripMenuItem,
            this.productosToolStripMenuItem1,
            this.coloresToolStripMenuItem,
            this.talleToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // inventarioToolStripMenuItem
            // 
            this.inventarioToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.verStockToolStripMenuItem,
            this.ajusteStockToolStripMenuItem,
            this.exportarStockTXTToolStripMenuItem});
            this.inventarioToolStripMenuItem.Name = "inventarioToolStripMenuItem";
            this.inventarioToolStripMenuItem.Size = new System.Drawing.Size(89, 24);
            this.inventarioToolStripMenuItem.Text = "Inventario";
            // 
            // verStockToolStripMenuItem
            // 
            this.verStockToolStripMenuItem.Name = "verStockToolStripMenuItem";
            this.verStockToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.verStockToolStripMenuItem.Text = "Ver Stock";
            this.verStockToolStripMenuItem.Click += new System.EventHandler(this.verStockToolStripMenuItem_Click);
            // 
            // ajusteStockToolStripMenuItem
            // 
            this.ajusteStockToolStripMenuItem.Name = "ajusteStockToolStripMenuItem";
            this.ajusteStockToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.ajusteStockToolStripMenuItem.Text = "Ajuste Stock";
            this.ajusteStockToolStripMenuItem.Click += new System.EventHandler(this.ajusteStockToolStripMenuItem_Click);
            // 
            // exportarStockTXTToolStripMenuItem
            // 
            this.exportarStockTXTToolStripMenuItem.Name = "exportarStockTXTToolStripMenuItem";
            this.exportarStockTXTToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.exportarStockTXTToolStripMenuItem.Text = "Exportar Stock TXT";
            // 
            // productosToolStripMenuItem
            // 
            this.productosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.articulosToolStripMenuItem,
            this.coloresToolStripMenuItem1,
            this.tallesToolStripMenuItem,
            this.marcaToolStripMenuItem,
            this.rubroToolStripMenuItem});
            this.productosToolStripMenuItem.Name = "productosToolStripMenuItem";
            this.productosToolStripMenuItem.Size = new System.Drawing.Size(89, 24);
            this.productosToolStripMenuItem.Text = "Productos";
            // 
            // articulosToolStripMenuItem
            // 
            this.articulosToolStripMenuItem.Name = "articulosToolStripMenuItem";
            this.articulosToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.articulosToolStripMenuItem.Text = "Articulos";
            this.articulosToolStripMenuItem.Click += new System.EventHandler(this.articulosToolStripMenuItem_Click);
            // 
            // coloresToolStripMenuItem1
            // 
            this.coloresToolStripMenuItem1.Name = "coloresToolStripMenuItem1";
            this.coloresToolStripMenuItem1.Size = new System.Drawing.Size(224, 26);
            this.coloresToolStripMenuItem1.Text = "Colores";
            // 
            // tallesToolStripMenuItem
            // 
            this.tallesToolStripMenuItem.Name = "tallesToolStripMenuItem";
            this.tallesToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.tallesToolStripMenuItem.Text = "Talles";
            // 
            // marcaToolStripMenuItem
            // 
            this.marcaToolStripMenuItem.Name = "marcaToolStripMenuItem";
            this.marcaToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.marcaToolStripMenuItem.Text = "Marcas";
            // 
            // rubroToolStripMenuItem
            // 
            this.rubroToolStripMenuItem.Name = "rubroToolStripMenuItem";
            this.rubroToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.rubroToolStripMenuItem.Text = "Rubros";
            // 
            // transitoToolStripMenuItem
            // 
            this.transitoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mercaderiaEnToolStripMenuItem,
            this.mercaderiaEnTransitoToolStripMenuItem});
            this.transitoToolStripMenuItem.Name = "transitoToolStripMenuItem";
            this.transitoToolStripMenuItem.Size = new System.Drawing.Size(82, 24);
            this.transitoToolStripMenuItem.Text = "Compras";
            this.transitoToolStripMenuItem.Click += new System.EventHandler(this.transitoToolStripMenuItem_Click);
            // 
            // mercaderiaEnToolStripMenuItem
            // 
            this.mercaderiaEnToolStripMenuItem.Name = "mercaderiaEnToolStripMenuItem";
            this.mercaderiaEnToolStripMenuItem.Size = new System.Drawing.Size(243, 26);
            this.mercaderiaEnToolStripMenuItem.Text = "Registrar Compras";
            // 
            // mercaderiaEnTransitoToolStripMenuItem
            // 
            this.mercaderiaEnTransitoToolStripMenuItem.Name = "mercaderiaEnTransitoToolStripMenuItem";
            this.mercaderiaEnTransitoToolStripMenuItem.Size = new System.Drawing.Size(243, 26);
            this.mercaderiaEnTransitoToolStripMenuItem.Text = "Mercaderia en Transito";
            // 
            // productosToolStripMenuItem1
            // 
            this.productosToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.verMovimientosToolStripMenuItem,
            this.historialToolStripMenuItem});
            this.productosToolStripMenuItem1.Name = "productosToolStripMenuItem1";
            this.productosToolStripMenuItem1.Size = new System.Drawing.Size(121, 24);
            this.productosToolStripMenuItem1.Text = "Moviminientos";
            // 
            // verMovimientosToolStripMenuItem
            // 
            this.verMovimientosToolStripMenuItem.Name = "verMovimientosToolStripMenuItem";
            this.verMovimientosToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.verMovimientosToolStripMenuItem.Text = "Ver Movimientos";
            // 
            // historialToolStripMenuItem
            // 
            this.historialToolStripMenuItem.Name = "historialToolStripMenuItem";
            this.historialToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.historialToolStripMenuItem.Text = "Historial";
            // 
            // coloresToolStripMenuItem
            // 
            this.coloresToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportarATXTToolStripMenuItem,
            this.importarToolStripMenuItem,
            this.usuariosToolStripMenuItem});
            this.coloresToolStripMenuItem.Name = "coloresToolStripMenuItem";
            this.coloresToolStripMenuItem.Size = new System.Drawing.Size(75, 24);
            this.coloresToolStripMenuItem.Text = "Sistema";
            // 
            // exportarATXTToolStripMenuItem
            // 
            this.exportarATXTToolStripMenuItem.Name = "exportarATXTToolStripMenuItem";
            this.exportarATXTToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.exportarATXTToolStripMenuItem.Text = "Exportar a TXT";
            this.exportarATXTToolStripMenuItem.Click += new System.EventHandler(this.exportarATXTToolStripMenuItem_Click);
            // 
            // importarToolStripMenuItem
            // 
            this.importarToolStripMenuItem.Name = "importarToolStripMenuItem";
            this.importarToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.importarToolStripMenuItem.Text = "Importar Inventario";
            // 
            // usuariosToolStripMenuItem
            // 
            this.usuariosToolStripMenuItem.Name = "usuariosToolStripMenuItem";
            this.usuariosToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.usuariosToolStripMenuItem.Text = "Usuarios";
            // 
            // talleToolStripMenuItem
            // 
            this.talleToolStripMenuItem.Name = "talleToolStripMenuItem";
            this.talleToolStripMenuItem.Size = new System.Drawing.Size(52, 24);
            this.talleToolStripMenuItem.Text = "Salir";
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormPrincipal";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem inventarioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verStockToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ajusteStockToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportarStockTXTToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem productosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transitoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem productosToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem coloresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem talleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem articulosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem coloresToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem tallesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem marcaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rubroToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mercaderiaEnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mercaderiaEnTransitoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verMovimientosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem historialToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportarATXTToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usuariosToolStripMenuItem;
    }
}

