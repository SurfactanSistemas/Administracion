using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Vista.Properties;

namespace Vista

{
    partial class Muestra
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
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
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            this.P_Buscar = new Panel();
            this.P_Filtrado = new Panel();
            this.LBFiltro = new Label();
            this.BT_Filtrar = new Button();
            this.TBFiltro = new TextBox();
            this.LBError = new Label();
            this.BT_MenuFiltros = new Button();
            this.BT_Buscar = new Button();
            this.label2 = new Label();
            this.TB_Hasta = new TextBox();
            this.label1 = new Label();
            this.TB_Desde = new TextBox();
            this.P_Botones = new Panel();
            this.tableLayoutPanel2 = new TableLayoutPanel();
            this.panel2 = new Panel();
            this.BtActLaborat = new Button();
            this.BtExportar = new Button();
            this.BtEtiquetas = new Button();
            this.BtEliminar = new Button();
            this.BtRemito = new Button();
            this.BtFin = new Button();
            this.BtImpresion = new Button();
            this.DGV_Muestra = new DataGridView();
            this.CMS_Filtros = new ContextMenuStrip(this.components);
            this.pedidoToolStripMenuItem = new ToolStripMenuItem();
            this.fechaToolStripMenuItem = new ToolStripMenuItem();
            this.codigoToolStripMenuItem = new ToolStripMenuItem();
            this.descripcionToolStripMenuItem = new ToolStripMenuItem();
            this.cantidadToolStripMenuItem = new ToolStripMenuItem();
            this.nombreParaElClienteToolStripMenuItem = new ToolStripMenuItem();
            this.clienteToolStripMenuItem = new ToolStripMenuItem();
            this.codClienteToolStripMenuItem = new ToolStripMenuItem();
            this.vendedorToolStripMenuItem = new ToolStripMenuItem();
            this.óbservacionesToolStripMenuItem = new ToolStripMenuItem();
            this.remitoToolStripMenuItem = new ToolStripMenuItem();
            this.hojaDeRutaToolStripMenuItem = new ToolStripMenuItem();
            this.sinRemitoToolStripMenuItem = new ToolStripMenuItem();
            this.sinRemitoConLote1ToolStripMenuItem = new ToolStripMenuItem();
            this.toolTip_BTBajaMuestra = new ToolTip(this.components);
            this.toolTip_ActLab = new ToolTip(this.components);
            this.toolTip_Export = new ToolTip(this.components);
            this.toolTip_Etiquetas = new ToolTip(this.components);
            this.toolTip_Remito = new ToolTip(this.components);
            this.toolTip_Impresion = new ToolTip(this.components);
            this.toolTip_Fin = new ToolTip(this.components);
            this.panel1 = new Panel();
            this.label4 = new Label();
            this.label3 = new Label();
            this.toolTip_Eliminar = new ToolTip(this.components);
            this.tableLayoutPanel1 = new TableLayoutPanel();
            this.muestraBindingSource = new BindingSource(this.components);
            this.Id = new DataGridViewTextBoxColumn();
            this.Pedido = new DataGridViewTextBoxColumn();
            this.Fecha = new DataGridViewTextBoxColumn();
            this.Codigo = new DataGridViewTextBoxColumn();
            this.Nombre = new DataGridViewTextBoxColumn();
            this.Cantidad = new DataGridViewTextBoxColumn();
            this.DescriCliente = new DataGridViewTextBoxColumn();
            this.Razon = new DataGridViewTextBoxColumn();
            this.Cliente = new DataGridViewTextBoxColumn();
            this.NombreVend = new DataGridViewTextBoxColumn();
            this.Observaciones = new DataGridViewTextBoxColumn();
            this.Fecha2 = new DataGridViewTextBoxColumn();
            this.remitoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            this.HojaRuta = new DataGridViewTextBoxColumn();
            this.CodigoConf = new DataGridViewTextBoxColumn();
            this.Nombre2 = new DataGridViewTextBoxColumn();
            this.Lote2 = new DataGridViewTextBoxColumn();
            this.Observaciones2 = new DataGridViewTextBoxColumn();
            this.Cantidad2 = new DataGridViewTextBoxColumn();
            this.OrdenFecha = new DataGridViewTextBoxColumn();
            this.Lote1 = new DataGridViewTextBoxColumn();
            this.P_Buscar.SuspendLayout();
            this.P_Filtrado.SuspendLayout();
            this.P_Botones.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel2.SuspendLayout();
            ((ISupportInitialize)(this.DGV_Muestra)).BeginInit();
            this.CMS_Filtros.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((ISupportInitialize)(this.muestraBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // P_Buscar
            // 
            this.P_Buscar.BackColor = Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(139)))), ((int)(((byte)(82)))));
            this.P_Buscar.Controls.Add(this.P_Filtrado);
            this.P_Buscar.Controls.Add(this.LBError);
            this.P_Buscar.Controls.Add(this.BT_MenuFiltros);
            this.P_Buscar.Controls.Add(this.BT_Buscar);
            this.P_Buscar.Controls.Add(this.label2);
            this.P_Buscar.Controls.Add(this.TB_Hasta);
            this.P_Buscar.Controls.Add(this.label1);
            this.P_Buscar.Controls.Add(this.TB_Desde);
            this.P_Buscar.Dock = DockStyle.Fill;
            this.P_Buscar.Location = new Point(0, 43);
            this.P_Buscar.Margin = new Padding(0);
            this.P_Buscar.Name = "P_Buscar";
            this.P_Buscar.Size = new Size(787, 60);
            this.P_Buscar.TabIndex = 0;
            // 
            // P_Filtrado
            // 
            this.P_Filtrado.Controls.Add(this.LBFiltro);
            this.P_Filtrado.Controls.Add(this.BT_Filtrar);
            this.P_Filtrado.Controls.Add(this.TBFiltro);
            this.P_Filtrado.Location = new Point(455, 4);
            this.P_Filtrado.Name = "P_Filtrado";
            this.P_Filtrado.Size = new Size(639, 53);
            this.P_Filtrado.TabIndex = 7;
            this.P_Filtrado.Visible = false;
            // 
            // LBFiltro
            // 
            this.LBFiltro.Font = new Font("Calibri", 11.25F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.LBFiltro.ForeColor = Color.White;
            this.LBFiltro.Location = new Point(3, 18);
            this.LBFiltro.Name = "LBFiltro";
            this.LBFiltro.Size = new Size(105, 18);
            this.LBFiltro.TabIndex = 7;
            this.LBFiltro.Text = "label5";
            this.LBFiltro.TextAlign = ContentAlignment.MiddleRight;
            // 
            // BT_Filtrar
            // 
            this.BT_Filtrar.Location = new Point(234, 14);
            this.BT_Filtrar.Name = "BT_Filtrar";
            this.BT_Filtrar.Size = new Size(75, 23);
            this.BT_Filtrar.TabIndex = 6;
            this.BT_Filtrar.Text = "Filtrar";
            this.BT_Filtrar.UseVisualStyleBackColor = true;
            this.BT_Filtrar.Click += new EventHandler(this.BT_Filtrar_Click);
            // 
            // TBFiltro
            // 
            this.TBFiltro.Location = new Point(114, 16);
            this.TBFiltro.Name = "TBFiltro";
            this.TBFiltro.Size = new Size(114, 20);
            this.TBFiltro.TabIndex = 5;
            this.TBFiltro.TextChanged += new EventHandler(this.TBFiltro_TextChanged);
            this.TBFiltro.KeyDown += new KeyEventHandler(this.TBFiltro_KeyDown);
            // 
            // LBError
            // 
            this.LBError.AutoSize = true;
            this.LBError.Location = new Point(73, 56);
            this.LBError.Name = "LBError";
            this.LBError.Size = new Size(0, 13);
            this.LBError.TabIndex = 9;
            // 
            // BT_MenuFiltros
            // 
            this.BT_MenuFiltros.Location = new Point(374, 18);
            this.BT_MenuFiltros.Name = "BT_MenuFiltros";
            this.BT_MenuFiltros.Size = new Size(75, 23);
            this.BT_MenuFiltros.TabIndex = 8;
            this.BT_MenuFiltros.Text = "Filtra Por";
            this.BT_MenuFiltros.UseVisualStyleBackColor = true;
            this.BT_MenuFiltros.Click += new EventHandler(this.button7_Click);
            // 
            // BT_Buscar
            // 
            this.BT_Buscar.Location = new Point(276, 17);
            this.BT_Buscar.Name = "BT_Buscar";
            this.BT_Buscar.Size = new Size(92, 25);
            this.BT_Buscar.TabIndex = 4;
            this.BT_Buscar.Text = "Buscar";
            this.BT_Buscar.UseVisualStyleBackColor = true;
            this.BT_Buscar.Click += new EventHandler(this.BT_Buscar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new Font("Calibri", 11F, FontStyle.Bold);
            this.label2.ForeColor = SystemColors.ButtonFace;
            this.label2.Location = new Point(145, 20);
            this.label2.Name = "label2";
            this.label2.Size = new Size(42, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "Hasta";
            // 
            // TB_Hasta
            // 
            this.TB_Hasta.Location = new Point(189, 20);
            this.TB_Hasta.Name = "TB_Hasta";
            this.TB_Hasta.Size = new Size(67, 20);
            this.TB_Hasta.TabIndex = 2;
            this.TB_Hasta.Text = "2017";
            this.TB_Hasta.KeyDown += new KeyEventHandler(this.TB_Hasta_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new Font("Calibri", 11F, FontStyle.Bold);
            this.label1.ForeColor = SystemColors.ButtonFace;
            this.label1.Location = new Point(13, 20);
            this.label1.Name = "label1";
            this.label1.Size = new Size(47, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Desde";
            // 
            // TB_Desde
            // 
            this.TB_Desde.Location = new Point(62, 20);
            this.TB_Desde.Name = "TB_Desde";
            this.TB_Desde.Size = new Size(67, 20);
            this.TB_Desde.TabIndex = 0;
            this.TB_Desde.Text = "2017";
            this.TB_Desde.KeyDown += new KeyEventHandler(this.TB_Desde_KeyDown);
            // 
            // P_Botones
            // 
            this.P_Botones.AutoSize = true;
            this.P_Botones.Controls.Add(this.tableLayoutPanel2);
            this.P_Botones.Dock = DockStyle.Fill;
            this.P_Botones.Location = new Point(3, 106);
            this.P_Botones.Name = "P_Botones";
            this.P_Botones.Size = new Size(781, 442);
            this.P_Botones.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.DGV_Muestra, 1, 0);
            this.tableLayoutPanel2.Dock = DockStyle.Fill;
            this.tableLayoutPanel2.Location = new Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new Size(781, 442);
            this.tableLayoutPanel2.TabIndex = 10;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.BtActLaborat);
            this.panel2.Controls.Add(this.BtExportar);
            this.panel2.Controls.Add(this.BtEtiquetas);
            this.panel2.Controls.Add(this.BtEliminar);
            this.panel2.Controls.Add(this.BtRemito);
            this.panel2.Controls.Add(this.BtFin);
            this.panel2.Controls.Add(this.BtImpresion);
            this.panel2.Dock = DockStyle.Fill;
            this.panel2.Location = new Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new Size(94, 436);
            this.panel2.TabIndex = 11;
            // 
            // BtActLaborat
            // 
            this.BtActLaborat.BackgroundImage = Resources.Act_Lab_N1;
            this.BtActLaborat.BackgroundImageLayout = ImageLayout.Zoom;
            this.BtActLaborat.FlatAppearance.BorderSize = 0;
            this.BtActLaborat.FlatStyle = FlatStyle.Flat;
            this.BtActLaborat.Location = new Point(19, 1);
            this.BtActLaborat.Margin = new Padding(0);
            this.BtActLaborat.Name = "BtActLaborat";
            this.BtActLaborat.Size = new Size(52, 55);
            this.BtActLaborat.TabIndex = 2;
            this.toolTip_ActLab.SetToolTip(this.BtActLaborat, " Actualizar \r\nLaboratorio\r\n     (F4)");
            this.BtActLaborat.UseVisualStyleBackColor = true;
            this.BtActLaborat.Click += new EventHandler(this.BtActLaborat_Click);
            // 
            // BtExportar
            // 
            this.BtExportar.BackgroundImage = Resources.Export_N;
            this.BtExportar.BackgroundImageLayout = ImageLayout.Zoom;
            this.BtExportar.FlatAppearance.BorderSize = 0;
            this.BtExportar.FlatStyle = FlatStyle.Flat;
            this.BtExportar.Location = new Point(19, 57);
            this.BtExportar.Margin = new Padding(0);
            this.BtExportar.Name = "BtExportar";
            this.BtExportar.Size = new Size(60, 60);
            this.BtExportar.TabIndex = 3;
            this.toolTip_Export.SetToolTip(this.BtExportar, "Exportacion\r\n      (F5)");
            this.BtExportar.UseVisualStyleBackColor = true;
            this.BtExportar.Click += new EventHandler(this.button2_Click);
            // 
            // BtEtiquetas
            // 
            this.BtEtiquetas.BackgroundImage = Resources.Etiquetas_N1;
            this.BtEtiquetas.BackgroundImageLayout = ImageLayout.Zoom;
            this.BtEtiquetas.FlatAppearance.BorderSize = 0;
            this.BtEtiquetas.FlatStyle = FlatStyle.Flat;
            this.BtEtiquetas.Location = new Point(15, 117);
            this.BtEtiquetas.Margin = new Padding(0);
            this.BtEtiquetas.Name = "BtEtiquetas";
            this.BtEtiquetas.Size = new Size(55, 57);
            this.BtEtiquetas.TabIndex = 4;
            this.toolTip_Etiquetas.SetToolTip(this.BtEtiquetas, "Etiquetas\r\n    (F6)");
            this.BtEtiquetas.UseVisualStyleBackColor = true;
            this.BtEtiquetas.Click += new EventHandler(this.BtEtiquetas_Click);
            // 
            // BtEliminar
            // 
            this.BtEliminar.BackgroundImage = Resources.Eliminar2;
            this.BtEliminar.BackgroundImageLayout = ImageLayout.Zoom;
            this.BtEliminar.FlatStyle = FlatStyle.Flat;
            this.BtEliminar.ForeColor = SystemColors.Control;
            this.BtEliminar.Location = new Point(15, 311);
            this.BtEliminar.Margin = new Padding(0);
            this.BtEliminar.Name = "BtEliminar";
            this.BtEliminar.Size = new Size(51, 53);
            this.BtEliminar.TabIndex = 9;
            this.toolTip_Eliminar.SetToolTip(this.BtEliminar, "Eliminar\r\n");
            this.BtEliminar.UseVisualStyleBackColor = true;
            this.BtEliminar.Click += new EventHandler(this.BtEliminar_Click);
            // 
            // BtRemito
            // 
            this.BtRemito.BackgroundImage = Resources.Remito1;
            this.BtRemito.BackgroundImageLayout = ImageLayout.Zoom;
            this.BtRemito.FlatAppearance.BorderSize = 0;
            this.BtRemito.FlatStyle = FlatStyle.Flat;
            this.BtRemito.Location = new Point(18, 184);
            this.BtRemito.Margin = new Padding(0);
            this.BtRemito.Name = "BtRemito";
            this.BtRemito.Size = new Size(54, 53);
            this.BtRemito.TabIndex = 5;
            this.toolTip_Remito.SetToolTip(this.BtRemito, "Remito\r\n   (F8)");
            this.BtRemito.UseVisualStyleBackColor = true;
            this.BtRemito.Click += new EventHandler(this.BtRemito_Click);
            // 
            // BtFin
            // 
            this.BtFin.BackgroundImage = Resources.Salir1;
            this.BtFin.BackgroundImageLayout = ImageLayout.Zoom;
            this.BtFin.FlatAppearance.BorderSize = 0;
            this.BtFin.FlatStyle = FlatStyle.Flat;
            this.BtFin.Location = new Point(15, 376);
            this.BtFin.Margin = new Padding(0);
            this.BtFin.Name = "BtFin";
            this.BtFin.Size = new Size(46, 50);
            this.BtFin.TabIndex = 7;
            this.toolTip_Fin.SetToolTip(this.BtFin, "  Fin\r\n(F10)");
            this.BtFin.UseVisualStyleBackColor = true;
            this.BtFin.Click += new EventHandler(this.button6_Click);
            // 
            // BtImpresion
            // 
            this.BtImpresion.BackgroundImage = Resources.Impresion_N1;
            this.BtImpresion.BackgroundImageLayout = ImageLayout.Zoom;
            this.BtImpresion.FlatAppearance.BorderSize = 0;
            this.BtImpresion.FlatStyle = FlatStyle.Flat;
            this.BtImpresion.Location = new Point(18, 250);
            this.BtImpresion.Margin = new Padding(0);
            this.BtImpresion.Name = "BtImpresion";
            this.BtImpresion.Size = new Size(48, 52);
            this.BtImpresion.TabIndex = 6;
            this.toolTip_Impresion.SetToolTip(this.BtImpresion, "Impresion\r\n    (F9)");
            this.BtImpresion.UseVisualStyleBackColor = true;
            this.BtImpresion.Click += new EventHandler(this.BtImpresion_Click);
            // 
            // DGV_Muestra
            // 
            this.DGV_Muestra.AllowUserToAddRows = false;
            this.DGV_Muestra.AllowUserToDeleteRows = false;
            this.DGV_Muestra.AllowUserToResizeRows = false;
            this.DGV_Muestra.AutoGenerateColumns = false;
            this.DGV_Muestra.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_Muestra.Columns.AddRange(new DataGridViewColumn[] {
            this.Id,
            this.Pedido,
            this.Fecha,
            this.Codigo,
            this.Nombre,
            this.Cantidad,
            this.DescriCliente,
            this.Razon,
            this.Cliente,
            this.NombreVend,
            this.Observaciones,
            this.Fecha2,
            this.remitoDataGridViewTextBoxColumn,
            this.HojaRuta,
            this.CodigoConf,
            this.Nombre2,
            this.Lote2,
            this.Observaciones2,
            this.Cantidad2,
            this.OrdenFecha,
            this.Lote1});
            this.DGV_Muestra.DataSource = this.muestraBindingSource;
            this.DGV_Muestra.Dock = DockStyle.Fill;
            this.DGV_Muestra.Location = new Point(103, 3);
            this.DGV_Muestra.Name = "DGV_Muestra";
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.Padding = new Padding(5, 0, 0, 0);
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            this.DGV_Muestra.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.DGV_Muestra.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.DGV_Muestra.Size = new Size(781, 436);
            this.DGV_Muestra.TabIndex = 8;
            this.DGV_Muestra.ColumnHeaderMouseClick += new DataGridViewCellMouseEventHandler(this.DGV_Muestra_ColumnHeaderMouseClick);
            this.DGV_Muestra.KeyDown += new KeyEventHandler(this.DGV_Muestra_KeyDown);
            // 
            // CMS_Filtros
            // 
            this.CMS_Filtros.Items.AddRange(new ToolStripItem[] {
            this.pedidoToolStripMenuItem,
            this.fechaToolStripMenuItem,
            this.codigoToolStripMenuItem,
            this.descripcionToolStripMenuItem,
            this.cantidadToolStripMenuItem,
            this.nombreParaElClienteToolStripMenuItem,
            this.clienteToolStripMenuItem,
            this.codClienteToolStripMenuItem,
            this.vendedorToolStripMenuItem,
            this.óbservacionesToolStripMenuItem,
            this.remitoToolStripMenuItem,
            this.hojaDeRutaToolStripMenuItem,
            this.sinRemitoToolStripMenuItem,
            this.sinRemitoConLote1ToolStripMenuItem});
            this.CMS_Filtros.Name = "contextMenuStrip1";
            this.CMS_Filtros.Size = new Size(220, 312);
            // 
            // pedidoToolStripMenuItem
            // 
            this.pedidoToolStripMenuItem.Name = "pedidoToolStripMenuItem";
            this.pedidoToolStripMenuItem.Size = new Size(219, 22);
            this.pedidoToolStripMenuItem.Text = "Pedido";
            this.pedidoToolStripMenuItem.Click += new EventHandler(this.pedidoToolStripMenuItem_Click);
            // 
            // fechaToolStripMenuItem
            // 
            this.fechaToolStripMenuItem.Name = "fechaToolStripMenuItem";
            this.fechaToolStripMenuItem.Size = new Size(219, 22);
            this.fechaToolStripMenuItem.Text = "Fecha";
            this.fechaToolStripMenuItem.Click += new EventHandler(this.fechaToolStripMenuItem_Click);
            // 
            // codigoToolStripMenuItem
            // 
            this.codigoToolStripMenuItem.Name = "codigoToolStripMenuItem";
            this.codigoToolStripMenuItem.Size = new Size(219, 22);
            this.codigoToolStripMenuItem.Text = "Codigo";
            this.codigoToolStripMenuItem.Click += new EventHandler(this.codigoToolStripMenuItem_Click);
            // 
            // descripcionToolStripMenuItem
            // 
            this.descripcionToolStripMenuItem.Name = "descripcionToolStripMenuItem";
            this.descripcionToolStripMenuItem.Size = new Size(219, 22);
            this.descripcionToolStripMenuItem.Text = "Descripcion";
            this.descripcionToolStripMenuItem.Click += new EventHandler(this.descripcionToolStripMenuItem_Click);
            // 
            // cantidadToolStripMenuItem
            // 
            this.cantidadToolStripMenuItem.Name = "cantidadToolStripMenuItem";
            this.cantidadToolStripMenuItem.Size = new Size(219, 22);
            this.cantidadToolStripMenuItem.Text = "Cantidad";
            this.cantidadToolStripMenuItem.Click += new EventHandler(this.cantidadToolStripMenuItem_Click);
            // 
            // nombreParaElClienteToolStripMenuItem
            // 
            this.nombreParaElClienteToolStripMenuItem.Name = "nombreParaElClienteToolStripMenuItem";
            this.nombreParaElClienteToolStripMenuItem.Size = new Size(219, 22);
            this.nombreParaElClienteToolStripMenuItem.Text = "Nombre para el cliente";
            this.nombreParaElClienteToolStripMenuItem.Click += new EventHandler(this.nombreParaElClienteToolStripMenuItem_Click);
            // 
            // clienteToolStripMenuItem
            // 
            this.clienteToolStripMenuItem.Name = "clienteToolStripMenuItem";
            this.clienteToolStripMenuItem.Size = new Size(219, 22);
            this.clienteToolStripMenuItem.Text = "Razon";
            this.clienteToolStripMenuItem.Click += new EventHandler(this.clienteToolStripMenuItem_Click);
            // 
            // codClienteToolStripMenuItem
            // 
            this.codClienteToolStripMenuItem.Name = "codClienteToolStripMenuItem";
            this.codClienteToolStripMenuItem.Size = new Size(219, 22);
            this.codClienteToolStripMenuItem.Text = "Cod.Cliente";
            this.codClienteToolStripMenuItem.Click += new EventHandler(this.codClienteToolStripMenuItem_Click);
            // 
            // vendedorToolStripMenuItem
            // 
            this.vendedorToolStripMenuItem.Name = "vendedorToolStripMenuItem";
            this.vendedorToolStripMenuItem.Size = new Size(219, 22);
            this.vendedorToolStripMenuItem.Text = "Vendedor";
            this.vendedorToolStripMenuItem.Click += new EventHandler(this.vendedorToolStripMenuItem_Click);
            // 
            // óbservacionesToolStripMenuItem
            // 
            this.óbservacionesToolStripMenuItem.Name = "óbservacionesToolStripMenuItem";
            this.óbservacionesToolStripMenuItem.Size = new Size(219, 22);
            this.óbservacionesToolStripMenuItem.Text = "Observaciones";
            this.óbservacionesToolStripMenuItem.Click += new EventHandler(this.óbservacionesToolStripMenuItem_Click);
            // 
            // remitoToolStripMenuItem
            // 
            this.remitoToolStripMenuItem.Name = "remitoToolStripMenuItem";
            this.remitoToolStripMenuItem.Size = new Size(219, 22);
            this.remitoToolStripMenuItem.Text = "Remito";
            this.remitoToolStripMenuItem.Click += new EventHandler(this.remitoToolStripMenuItem_Click);
            // 
            // hojaDeRutaToolStripMenuItem
            // 
            this.hojaDeRutaToolStripMenuItem.Name = "hojaDeRutaToolStripMenuItem";
            this.hojaDeRutaToolStripMenuItem.Size = new Size(219, 22);
            this.hojaDeRutaToolStripMenuItem.Text = "Hoja de Ruta";
            this.hojaDeRutaToolStripMenuItem.Click += new EventHandler(this.hojaDeRutaToolStripMenuItem_Click);
            // 
            // sinRemitoToolStripMenuItem
            // 
            this.sinRemitoToolStripMenuItem.Name = "sinRemitoToolStripMenuItem";
            this.sinRemitoToolStripMenuItem.Size = new Size(219, 22);
            this.sinRemitoToolStripMenuItem.Text = "Muestra s/Remito";
            this.sinRemitoToolStripMenuItem.Click += new EventHandler(this.sinRemitoToolStripMenuItem_Click);
            // 
            // sinRemitoConLote1ToolStripMenuItem
            // 
            this.sinRemitoConLote1ToolStripMenuItem.Name = "sinRemitoConLote1ToolStripMenuItem";
            this.sinRemitoConLote1ToolStripMenuItem.Size = new Size(219, 22);
            this.sinRemitoConLote1ToolStripMenuItem.Text = "Muestra s/Remito c/Partida";
            this.sinRemitoConLote1ToolStripMenuItem.Click += new EventHandler(this.sinRemitoConLote1ToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(74)))), ((int)(((byte)(95)))));
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = DockStyle.Fill;
            this.panel1.Location = new Point(0, 0);
            this.panel1.Margin = new Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new Size(787, 43);
            this.panel1.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Bottom)
                        | AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Font = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = Color.White;
            this.label4.Location = new Point(17, 14);
            this.label4.Name = "label4";
            this.label4.Size = new Size(251, 19);
            this.label4.TabIndex = 1;
            this.label4.Text = "INGRESO DE MUESTRAS A CLIENTES";
            // 
            // label3
            // 
            this.label3.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Bottom)
                        | AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new Font("Calibri", 15.75F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = Color.White;
            this.label3.Location = new Point(619, 9);
            this.label3.Margin = new Padding(0);
            this.label3.Name = "label3";
            this.label3.Size = new Size(156, 26);
            this.label3.TabIndex = 0;
            this.label3.Text = "SURFACTAN S.A.";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.P_Buscar, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.P_Botones, 0, 2);
            this.tableLayoutPanel1.Dock = DockStyle.Fill;
            this.tableLayoutPanel1.Location = new Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 43F));
            this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new RowStyle());
            this.tableLayoutPanel1.Size = new Size(787, 551);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // muestraBindingSource
            // 
            this.muestraBindingSource.DataSource = typeof(Negocio.Muestra);
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.Visible = false;
            // 
            // Pedido
            // 
            this.Pedido.DataPropertyName = "Pedido";
            this.Pedido.HeaderText = "Pedido";
            this.Pedido.Name = "Pedido";
            this.Pedido.ReadOnly = true;
            this.Pedido.Width = 50;
            // 
            // Fecha
            // 
            this.Fecha.DataPropertyName = "Fecha";
            this.Fecha.HeaderText = "Fecha";
            this.Fecha.Name = "Fecha";
            this.Fecha.ReadOnly = true;
            this.Fecha.SortMode = DataGridViewColumnSortMode.Programmatic;
            this.Fecha.Width = 70;
            // 
            // Codigo
            // 
            this.Codigo.DataPropertyName = "Codigo";
            this.Codigo.HeaderText = "Codigo";
            this.Codigo.Name = "Codigo";
            this.Codigo.ReadOnly = true;
            this.Codigo.Width = 85;
            // 
            // Nombre
            // 
            this.Nombre.DataPropertyName = "Nombre";
            this.Nombre.HeaderText = "Descripcion";
            this.Nombre.MinimumWidth = 90;
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            this.Nombre.Width = 90;
            // 
            // Cantidad
            // 
            this.Cantidad.DataPropertyName = "Cantidad";
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.Name = "Cantidad";
            this.Cantidad.ReadOnly = true;
            this.Cantidad.Width = 70;
            // 
            // DescriCliente
            // 
            this.DescriCliente.DataPropertyName = "DescriCliente";
            this.DescriCliente.HeaderText = "Nombre para Cliente";
            this.DescriCliente.Name = "DescriCliente";
            this.DescriCliente.ReadOnly = true;
            this.DescriCliente.Width = 90;
            // 
            // Razon
            // 
            this.Razon.DataPropertyName = "Razon";
            this.Razon.HeaderText = "Razon";
            this.Razon.Name = "Razon";
            this.Razon.ReadOnly = true;
            this.Razon.Width = 85;
            // 
            // Cliente
            // 
            this.Cliente.DataPropertyName = "Cliente";
            this.Cliente.HeaderText = "Cod.Cliente";
            this.Cliente.Name = "Cliente";
            // 
            // NombreVend
            // 
            this.NombreVend.DataPropertyName = "NombreVend";
            this.NombreVend.HeaderText = "NombreVend";
            this.NombreVend.Name = "NombreVend";
            // 
            // Observaciones
            // 
            this.Observaciones.DataPropertyName = "Observaciones";
            this.Observaciones.HeaderText = "Observaciones";
            this.Observaciones.Name = "Observaciones";
            this.Observaciones.ReadOnly = true;
            this.Observaciones.Width = 85;
            // 
            // Fecha2
            // 
            this.Fecha2.DataPropertyName = "Fecha2";
            this.Fecha2.HeaderText = "Fecha OK";
            this.Fecha2.Name = "Fecha2";
            this.Fecha2.ReadOnly = true;
            this.Fecha2.Width = 30;
            // 
            // remitoDataGridViewTextBoxColumn
            // 
            this.remitoDataGridViewTextBoxColumn.DataPropertyName = "Remito";
            this.remitoDataGridViewTextBoxColumn.HeaderText = "Remito";
            this.remitoDataGridViewTextBoxColumn.Name = "remitoDataGridViewTextBoxColumn";
            this.remitoDataGridViewTextBoxColumn.ReadOnly = true;
            this.remitoDataGridViewTextBoxColumn.Width = 50;
            // 
            // HojaRuta
            // 
            this.HojaRuta.DataPropertyName = "HojaRuta";
            this.HojaRuta.HeaderText = "H. Ruta";
            this.HojaRuta.Name = "HojaRuta";
            this.HojaRuta.ReadOnly = true;
            this.HojaRuta.Width = 42;
            // 
            // CodigoConf
            // 
            this.CodigoConf.DataPropertyName = "CodigoConf";
            this.CodigoConf.HeaderText = "Cod. Conf";
            this.CodigoConf.Name = "CodigoConf";
            this.CodigoConf.ReadOnly = true;
            this.CodigoConf.Width = 60;
            // 
            // Nombre2
            // 
            this.Nombre2.DataPropertyName = "Nombre2";
            this.Nombre2.HeaderText = "Descripcion2";
            this.Nombre2.Name = "Nombre2";
            this.Nombre2.ReadOnly = true;
            this.Nombre2.Width = 80;
            // 
            // Lote2
            // 
            this.Lote2.DataPropertyName = "Lote2";
            this.Lote2.HeaderText = "Lote";
            this.Lote2.Name = "Lote2";
            this.Lote2.ReadOnly = true;
            this.Lote2.Width = 41;
            // 
            // Observaciones2
            // 
            this.Observaciones2.DataPropertyName = "Observaciones2";
            this.Observaciones2.HeaderText = "Observaciones2";
            this.Observaciones2.Name = "Observaciones2";
            this.Observaciones2.ReadOnly = true;
            this.Observaciones2.Width = 80;
            // 
            // Cantidad2
            // 
            this.Cantidad2.DataPropertyName = "Cantidad2";
            this.Cantidad2.HeaderText = "Cantidad";
            this.Cantidad2.Name = "Cantidad2";
            this.Cantidad2.ReadOnly = true;
            this.Cantidad2.Width = 50;
            // 
            // OrdenFecha
            // 
            this.OrdenFecha.DataPropertyName = "OrdenFecha";
            this.OrdenFecha.HeaderText = "OrdenFecha";
            this.OrdenFecha.Name = "OrdenFecha";
            this.OrdenFecha.SortMode = DataGridViewColumnSortMode.Programmatic;
            this.OrdenFecha.Visible = false;
            // 
            // Lote1
            // 
            this.Lote1.DataPropertyName = "Lote1";
            this.Lote1.HeaderText = "Lote1";
            this.Lote1.Name = "Lote1";
            // 
            // Muestra
            // 
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = SystemColors.Control;
            this.ClientSize = new Size(787, 551);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MinimumSize = new Size(803, 39);
            this.Name = "Muestra";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Maximized;
            this.Load += new EventHandler(this.Form1_Load);
            this.P_Buscar.ResumeLayout(false);
            this.P_Buscar.PerformLayout();
            this.P_Filtrado.ResumeLayout(false);
            this.P_Filtrado.PerformLayout();
            this.P_Botones.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((ISupportInitialize)(this.DGV_Muestra)).EndInit();
            this.CMS_Filtros.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((ISupportInitialize)(this.muestraBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel P_Buscar;
        private Panel P_Botones;
        private Button BtActLaborat;
        private Button BtFin;
        private Button BtImpresion;
        private Button BtRemito;
        private Button BtEtiquetas;
        private Button BtExportar;
        private Button BT_Buscar;
        private Label label2;
        private TextBox TB_Hasta;
        private Label label1;
        private TextBox TB_Desde;
        private TextBox TBFiltro;
        private Button BT_Filtrar;
        private Panel P_Filtrado;
        private BindingSource muestraBindingSource;
        private DataGridView DGV_Muestra;
        private Button BT_MenuFiltros;
        private ContextMenuStrip CMS_Filtros;
        private ToolStripMenuItem pedidoToolStripMenuItem;
        private ToolStripMenuItem fechaToolStripMenuItem;
        private ToolStripMenuItem codigoToolStripMenuItem;
        private ToolStripMenuItem descripcionToolStripMenuItem;
        private ToolStripMenuItem cantidadToolStripMenuItem;
        private ToolStripMenuItem nombreParaElClienteToolStripMenuItem;
        private ToolStripMenuItem óbservacionesToolStripMenuItem;
        private Label LBError;
        private ToolTip toolTip_BTBajaMuestra;
        private ToolTip toolTip_ActLab;
        private ToolTip toolTip_Export;
        private ToolTip toolTip_Etiquetas;
        private ToolTip toolTip_Remito;
        private ToolTip toolTip_Impresion;
        private ToolTip toolTip_Fin;
        private Panel panel1;
        private Label label4;
        private Label label3;
        private Label LBFiltro;
        private ToolStripMenuItem clienteToolStripMenuItem;
        private ToolStripMenuItem remitoToolStripMenuItem;
        private ToolStripMenuItem hojaDeRutaToolStripMenuItem;
        private ToolStripMenuItem sinRemitoToolStripMenuItem;
        private ToolStripMenuItem sinRemitoConLote1ToolStripMenuItem;
        private Button BtEliminar;
        private ToolTip toolTip_Eliminar;
        private ToolStripMenuItem codClienteToolStripMenuItem;
        private ToolStripMenuItem vendedorToolStripMenuItem;
        private TableLayoutPanel tableLayoutPanel2;
        private Panel panel2;
        private TableLayoutPanel tableLayoutPanel1;
        private DataGridViewTextBoxColumn Id;
        private DataGridViewTextBoxColumn Pedido;
        private DataGridViewTextBoxColumn Fecha;
        private DataGridViewTextBoxColumn Codigo;
        private DataGridViewTextBoxColumn Nombre;
        private DataGridViewTextBoxColumn Cantidad;
        private DataGridViewTextBoxColumn DescriCliente;
        private DataGridViewTextBoxColumn Razon;
        private DataGridViewTextBoxColumn Cliente;
        private DataGridViewTextBoxColumn NombreVend;
        private DataGridViewTextBoxColumn Observaciones;
        private DataGridViewTextBoxColumn Fecha2;
        private DataGridViewTextBoxColumn remitoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn HojaRuta;
        private DataGridViewTextBoxColumn CodigoConf;
        private DataGridViewTextBoxColumn Nombre2;
        private DataGridViewTextBoxColumn Lote2;
        private DataGridViewTextBoxColumn Observaciones2;
        private DataGridViewTextBoxColumn Cantidad2;
        private DataGridViewTextBoxColumn OrdenFecha;
        private DataGridViewTextBoxColumn Lote1;
    }
}

