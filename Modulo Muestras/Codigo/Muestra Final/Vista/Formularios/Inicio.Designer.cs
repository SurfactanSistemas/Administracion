using System;


namespace Vista

{
    partial class Muestra
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.P_Buscar = new System.Windows.Forms.Panel();
            this.P_Filtrado = new System.Windows.Forms.Panel();
            this.LBFiltro = new System.Windows.Forms.Label();
            this.BT_Filtrar = new System.Windows.Forms.Button();
            this.TBFiltro = new System.Windows.Forms.TextBox();
            this.LBError = new System.Windows.Forms.Label();
            this.BT_MenuFiltros = new System.Windows.Forms.Button();
            this.BT_Buscar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.TB_Hasta = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TB_Desde = new System.Windows.Forms.TextBox();
            this.P_Botones = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.BtActLaborat = new System.Windows.Forms.Button();
            this.BtExportar = new System.Windows.Forms.Button();
            this.BtEtiquetas = new System.Windows.Forms.Button();
            this.BtEliminar = new System.Windows.Forms.Button();
            this.BtRemito = new System.Windows.Forms.Button();
            this.BtFin = new System.Windows.Forms.Button();
            this.BtImpresion = new System.Windows.Forms.Button();
            this.DGV_Muestra = new System.Windows.Forms.DataGridView();
            this.muestraBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.CMS_Filtros = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.pedidoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fechaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.codigoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.descripcionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cantidadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nombreParaElClienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.codClienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vendedorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.óbservacionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.remitoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hojaDeRutaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sinRemitoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sinRemitoConLote1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip_BTBajaMuestra = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip_ActLab = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip_Export = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip_Etiquetas = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip_Remito = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip_Impresion = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip_Fin = new System.Windows.Forms.ToolTip(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.toolTip_Eliminar = new System.Windows.Forms.ToolTip(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pedido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DescriCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Razon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NombreVend = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Observaciones = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remitoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HojaRuta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodigoConf = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Lote2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Observaciones2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrdenFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Lote1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.P_Buscar.SuspendLayout();
            this.P_Filtrado.SuspendLayout();
            this.P_Botones.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Muestra)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.muestraBindingSource)).BeginInit();
            this.CMS_Filtros.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // P_Buscar
            // 
            this.P_Buscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(139)))), ((int)(((byte)(82)))));
            this.P_Buscar.Controls.Add(this.P_Filtrado);
            this.P_Buscar.Controls.Add(this.LBError);
            this.P_Buscar.Controls.Add(this.BT_MenuFiltros);
            this.P_Buscar.Controls.Add(this.BT_Buscar);
            this.P_Buscar.Controls.Add(this.label2);
            this.P_Buscar.Controls.Add(this.TB_Hasta);
            this.P_Buscar.Controls.Add(this.label1);
            this.P_Buscar.Controls.Add(this.TB_Desde);
            this.P_Buscar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.P_Buscar.Location = new System.Drawing.Point(0, 43);
            this.P_Buscar.Margin = new System.Windows.Forms.Padding(0);
            this.P_Buscar.Name = "P_Buscar";
            this.P_Buscar.Size = new System.Drawing.Size(787, 60);
            this.P_Buscar.TabIndex = 0;
            // 
            // P_Filtrado
            // 
            this.P_Filtrado.Controls.Add(this.LBFiltro);
            this.P_Filtrado.Controls.Add(this.BT_Filtrar);
            this.P_Filtrado.Controls.Add(this.TBFiltro);
            this.P_Filtrado.Location = new System.Drawing.Point(455, 4);
            this.P_Filtrado.Name = "P_Filtrado";
            this.P_Filtrado.Size = new System.Drawing.Size(639, 53);
            this.P_Filtrado.TabIndex = 7;
            this.P_Filtrado.Visible = false;
            // 
            // LBFiltro
            // 
            this.LBFiltro.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBFiltro.ForeColor = System.Drawing.Color.White;
            this.LBFiltro.Location = new System.Drawing.Point(3, 18);
            this.LBFiltro.Name = "LBFiltro";
            this.LBFiltro.Size = new System.Drawing.Size(105, 18);
            this.LBFiltro.TabIndex = 7;
            this.LBFiltro.Text = "label5";
            this.LBFiltro.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // BT_Filtrar
            // 
            this.BT_Filtrar.Location = new System.Drawing.Point(234, 14);
            this.BT_Filtrar.Name = "BT_Filtrar";
            this.BT_Filtrar.Size = new System.Drawing.Size(75, 23);
            this.BT_Filtrar.TabIndex = 6;
            this.BT_Filtrar.Text = "Filtrar";
            this.BT_Filtrar.UseVisualStyleBackColor = true;
            this.BT_Filtrar.Click += new System.EventHandler(this.BT_Filtrar_Click);
            // 
            // TBFiltro
            // 
            this.TBFiltro.Location = new System.Drawing.Point(114, 16);
            this.TBFiltro.Name = "TBFiltro";
            this.TBFiltro.Size = new System.Drawing.Size(114, 20);
            this.TBFiltro.TabIndex = 5;
            this.TBFiltro.TextChanged += new System.EventHandler(this.TBFiltro_TextChanged);
            this.TBFiltro.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TBFiltro_KeyDown);
            // 
            // LBError
            // 
            this.LBError.AutoSize = true;
            this.LBError.Location = new System.Drawing.Point(73, 56);
            this.LBError.Name = "LBError";
            this.LBError.Size = new System.Drawing.Size(0, 13);
            this.LBError.TabIndex = 9;
            // 
            // BT_MenuFiltros
            // 
            this.BT_MenuFiltros.Location = new System.Drawing.Point(374, 18);
            this.BT_MenuFiltros.Name = "BT_MenuFiltros";
            this.BT_MenuFiltros.Size = new System.Drawing.Size(75, 23);
            this.BT_MenuFiltros.TabIndex = 8;
            this.BT_MenuFiltros.Text = "Filtra Por";
            this.BT_MenuFiltros.UseVisualStyleBackColor = true;
            this.BT_MenuFiltros.Click += new System.EventHandler(this.button7_Click);
            // 
            // BT_Buscar
            // 
            this.BT_Buscar.Location = new System.Drawing.Point(276, 17);
            this.BT_Buscar.Name = "BT_Buscar";
            this.BT_Buscar.Size = new System.Drawing.Size(92, 25);
            this.BT_Buscar.TabIndex = 4;
            this.BT_Buscar.Text = "Buscar";
            this.BT_Buscar.UseVisualStyleBackColor = true;
            this.BT_Buscar.Click += new System.EventHandler(this.BT_Buscar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(145, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "Hasta";
            // 
            // TB_Hasta
            // 
            this.TB_Hasta.Location = new System.Drawing.Point(189, 20);
            this.TB_Hasta.Name = "TB_Hasta";
            this.TB_Hasta.Size = new System.Drawing.Size(67, 20);
            this.TB_Hasta.TabIndex = 2;
            this.TB_Hasta.Text = "2017";
            this.TB_Hasta.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TB_Hasta_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(13, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Desde";
            // 
            // TB_Desde
            // 
            this.TB_Desde.Location = new System.Drawing.Point(62, 20);
            this.TB_Desde.Name = "TB_Desde";
            this.TB_Desde.Size = new System.Drawing.Size(67, 20);
            this.TB_Desde.TabIndex = 0;
            this.TB_Desde.Text = "2017";
            this.TB_Desde.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TB_Desde_KeyDown);
            // 
            // P_Botones
            // 
            this.P_Botones.AutoSize = true;
            this.P_Botones.Controls.Add(this.tableLayoutPanel2);
            this.P_Botones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.P_Botones.Location = new System.Drawing.Point(3, 106);
            this.P_Botones.Name = "P_Botones";
            this.P_Botones.Size = new System.Drawing.Size(781, 442);
            this.P_Botones.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.DGV_Muestra, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(781, 442);
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
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(94, 436);
            this.panel2.TabIndex = 11;
            // 
            // BtActLaborat
            // 
            this.BtActLaborat.BackgroundImage = global::Vista.Properties.Resources.Act_Lab_N1;
            this.BtActLaborat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BtActLaborat.FlatAppearance.BorderSize = 0;
            this.BtActLaborat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtActLaborat.Location = new System.Drawing.Point(19, 1);
            this.BtActLaborat.Margin = new System.Windows.Forms.Padding(0);
            this.BtActLaborat.Name = "BtActLaborat";
            this.BtActLaborat.Size = new System.Drawing.Size(52, 55);
            this.BtActLaborat.TabIndex = 2;
            this.toolTip_ActLab.SetToolTip(this.BtActLaborat, " Actualizar \r\nLaboratorio\r\n     (F4)");
            this.BtActLaborat.UseVisualStyleBackColor = true;
            this.BtActLaborat.Click += new System.EventHandler(this.BtActLaborat_Click);
            // 
            // BtExportar
            // 
            this.BtExportar.BackgroundImage = global::Vista.Properties.Resources.Export_N;
            this.BtExportar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BtExportar.FlatAppearance.BorderSize = 0;
            this.BtExportar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtExportar.Location = new System.Drawing.Point(19, 57);
            this.BtExportar.Margin = new System.Windows.Forms.Padding(0);
            this.BtExportar.Name = "BtExportar";
            this.BtExportar.Size = new System.Drawing.Size(60, 60);
            this.BtExportar.TabIndex = 3;
            this.toolTip_Export.SetToolTip(this.BtExportar, "Exportacion\r\n      (F5)");
            this.BtExportar.UseVisualStyleBackColor = true;
            this.BtExportar.Click += new System.EventHandler(this.button2_Click);
            // 
            // BtEtiquetas
            // 
            this.BtEtiquetas.BackgroundImage = global::Vista.Properties.Resources.Etiquetas_N1;
            this.BtEtiquetas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BtEtiquetas.FlatAppearance.BorderSize = 0;
            this.BtEtiquetas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtEtiquetas.Location = new System.Drawing.Point(15, 117);
            this.BtEtiquetas.Margin = new System.Windows.Forms.Padding(0);
            this.BtEtiquetas.Name = "BtEtiquetas";
            this.BtEtiquetas.Size = new System.Drawing.Size(55, 57);
            this.BtEtiquetas.TabIndex = 4;
            this.toolTip_Etiquetas.SetToolTip(this.BtEtiquetas, "Etiquetas\r\n    (F6)");
            this.BtEtiquetas.UseVisualStyleBackColor = true;
            this.BtEtiquetas.Click += new System.EventHandler(this.BtEtiquetas_Click);
            // 
            // BtEliminar
            // 
            this.BtEliminar.BackgroundImage = global::Vista.Properties.Resources.Eliminar2;
            this.BtEliminar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BtEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtEliminar.ForeColor = System.Drawing.SystemColors.Control;
            this.BtEliminar.Location = new System.Drawing.Point(15, 311);
            this.BtEliminar.Margin = new System.Windows.Forms.Padding(0);
            this.BtEliminar.Name = "BtEliminar";
            this.BtEliminar.Size = new System.Drawing.Size(51, 53);
            this.BtEliminar.TabIndex = 9;
            this.toolTip_Eliminar.SetToolTip(this.BtEliminar, "Eliminar\r\n");
            this.BtEliminar.UseVisualStyleBackColor = true;
            this.BtEliminar.Click += new System.EventHandler(this.BtEliminar_Click);
            // 
            // BtRemito
            // 
            this.BtRemito.BackgroundImage = global::Vista.Properties.Resources.Remito1;
            this.BtRemito.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BtRemito.FlatAppearance.BorderSize = 0;
            this.BtRemito.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtRemito.Location = new System.Drawing.Point(18, 184);
            this.BtRemito.Margin = new System.Windows.Forms.Padding(0);
            this.BtRemito.Name = "BtRemito";
            this.BtRemito.Size = new System.Drawing.Size(54, 53);
            this.BtRemito.TabIndex = 5;
            this.toolTip_Remito.SetToolTip(this.BtRemito, "Remito\r\n   (F8)");
            this.BtRemito.UseVisualStyleBackColor = true;
            this.BtRemito.Click += new System.EventHandler(this.BtRemito_Click);
            // 
            // BtFin
            // 
            this.BtFin.BackgroundImage = global::Vista.Properties.Resources.Salir1;
            this.BtFin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BtFin.FlatAppearance.BorderSize = 0;
            this.BtFin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtFin.Location = new System.Drawing.Point(15, 376);
            this.BtFin.Margin = new System.Windows.Forms.Padding(0);
            this.BtFin.Name = "BtFin";
            this.BtFin.Size = new System.Drawing.Size(46, 50);
            this.BtFin.TabIndex = 7;
            this.toolTip_Fin.SetToolTip(this.BtFin, "  Fin\r\n(F10)");
            this.BtFin.UseVisualStyleBackColor = true;
            this.BtFin.Click += new System.EventHandler(this.button6_Click);
            // 
            // BtImpresion
            // 
            this.BtImpresion.BackgroundImage = global::Vista.Properties.Resources.Impresion_N1;
            this.BtImpresion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BtImpresion.FlatAppearance.BorderSize = 0;
            this.BtImpresion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtImpresion.Location = new System.Drawing.Point(18, 250);
            this.BtImpresion.Margin = new System.Windows.Forms.Padding(0);
            this.BtImpresion.Name = "BtImpresion";
            this.BtImpresion.Size = new System.Drawing.Size(48, 52);
            this.BtImpresion.TabIndex = 6;
            this.toolTip_Impresion.SetToolTip(this.BtImpresion, "Impresion\r\n    (F9)");
            this.BtImpresion.UseVisualStyleBackColor = true;
            this.BtImpresion.Click += new System.EventHandler(this.BtImpresion_Click);
            // 
            // DGV_Muestra
            // 
            this.DGV_Muestra.AllowUserToAddRows = false;
            this.DGV_Muestra.AllowUserToDeleteRows = false;
            this.DGV_Muestra.AllowUserToResizeRows = false;
            this.DGV_Muestra.AutoGenerateColumns = false;
            this.DGV_Muestra.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_Muestra.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
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
            this.DGV_Muestra.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGV_Muestra.Location = new System.Drawing.Point(103, 3);
            this.DGV_Muestra.Name = "DGV_Muestra";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV_Muestra.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.DGV_Muestra.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.DGV_Muestra.Size = new System.Drawing.Size(781, 436);
            this.DGV_Muestra.TabIndex = 8;
            this.DGV_Muestra.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DGV_Muestra_ColumnHeaderMouseClick);
            this.DGV_Muestra.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DGV_Muestra_KeyDown);
            // 
            // muestraBindingSource
            // 
            this.muestraBindingSource.DataSource = typeof(Negocio.Muestra);
            // 
            // CMS_Filtros
            // 
            this.CMS_Filtros.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.CMS_Filtros.Size = new System.Drawing.Size(220, 312);
            // 
            // pedidoToolStripMenuItem
            // 
            this.pedidoToolStripMenuItem.Name = "pedidoToolStripMenuItem";
            this.pedidoToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
            this.pedidoToolStripMenuItem.Text = "Pedido";
            this.pedidoToolStripMenuItem.Click += new System.EventHandler(this.pedidoToolStripMenuItem_Click);
            // 
            // fechaToolStripMenuItem
            // 
            this.fechaToolStripMenuItem.Name = "fechaToolStripMenuItem";
            this.fechaToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
            this.fechaToolStripMenuItem.Text = "Fecha";
            this.fechaToolStripMenuItem.Click += new System.EventHandler(this.fechaToolStripMenuItem_Click);
            // 
            // codigoToolStripMenuItem
            // 
            this.codigoToolStripMenuItem.Name = "codigoToolStripMenuItem";
            this.codigoToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
            this.codigoToolStripMenuItem.Text = "Codigo";
            this.codigoToolStripMenuItem.Click += new System.EventHandler(this.codigoToolStripMenuItem_Click);
            // 
            // descripcionToolStripMenuItem
            // 
            this.descripcionToolStripMenuItem.Name = "descripcionToolStripMenuItem";
            this.descripcionToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
            this.descripcionToolStripMenuItem.Text = "Descripcion";
            this.descripcionToolStripMenuItem.Click += new System.EventHandler(this.descripcionToolStripMenuItem_Click);
            // 
            // cantidadToolStripMenuItem
            // 
            this.cantidadToolStripMenuItem.Name = "cantidadToolStripMenuItem";
            this.cantidadToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
            this.cantidadToolStripMenuItem.Text = "Cantidad";
            this.cantidadToolStripMenuItem.Click += new System.EventHandler(this.cantidadToolStripMenuItem_Click);
            // 
            // nombreParaElClienteToolStripMenuItem
            // 
            this.nombreParaElClienteToolStripMenuItem.Name = "nombreParaElClienteToolStripMenuItem";
            this.nombreParaElClienteToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
            this.nombreParaElClienteToolStripMenuItem.Text = "Nombre para el cliente";
            this.nombreParaElClienteToolStripMenuItem.Click += new System.EventHandler(this.nombreParaElClienteToolStripMenuItem_Click);
            // 
            // clienteToolStripMenuItem
            // 
            this.clienteToolStripMenuItem.Name = "clienteToolStripMenuItem";
            this.clienteToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
            this.clienteToolStripMenuItem.Text = "Razon";
            this.clienteToolStripMenuItem.Click += new System.EventHandler(this.clienteToolStripMenuItem_Click);
            // 
            // codClienteToolStripMenuItem
            // 
            this.codClienteToolStripMenuItem.Name = "codClienteToolStripMenuItem";
            this.codClienteToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
            this.codClienteToolStripMenuItem.Text = "Cod.Cliente";
            this.codClienteToolStripMenuItem.Click += new System.EventHandler(this.codClienteToolStripMenuItem_Click);
            // 
            // vendedorToolStripMenuItem
            // 
            this.vendedorToolStripMenuItem.Name = "vendedorToolStripMenuItem";
            this.vendedorToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
            this.vendedorToolStripMenuItem.Text = "Vendedor";
            this.vendedorToolStripMenuItem.Click += new System.EventHandler(this.vendedorToolStripMenuItem_Click);
            // 
            // óbservacionesToolStripMenuItem
            // 
            this.óbservacionesToolStripMenuItem.Name = "óbservacionesToolStripMenuItem";
            this.óbservacionesToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
            this.óbservacionesToolStripMenuItem.Text = "Observaciones";
            this.óbservacionesToolStripMenuItem.Click += new System.EventHandler(this.óbservacionesToolStripMenuItem_Click);
            // 
            // remitoToolStripMenuItem
            // 
            this.remitoToolStripMenuItem.Name = "remitoToolStripMenuItem";
            this.remitoToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
            this.remitoToolStripMenuItem.Text = "Remito";
            this.remitoToolStripMenuItem.Click += new System.EventHandler(this.remitoToolStripMenuItem_Click);
            // 
            // hojaDeRutaToolStripMenuItem
            // 
            this.hojaDeRutaToolStripMenuItem.Name = "hojaDeRutaToolStripMenuItem";
            this.hojaDeRutaToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
            this.hojaDeRutaToolStripMenuItem.Text = "Hoja de Ruta";
            this.hojaDeRutaToolStripMenuItem.Click += new System.EventHandler(this.hojaDeRutaToolStripMenuItem_Click);
            // 
            // sinRemitoToolStripMenuItem
            // 
            this.sinRemitoToolStripMenuItem.Name = "sinRemitoToolStripMenuItem";
            this.sinRemitoToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
            this.sinRemitoToolStripMenuItem.Text = "Muestra s/Remito";
            this.sinRemitoToolStripMenuItem.Click += new System.EventHandler(this.sinRemitoToolStripMenuItem_Click);
            // 
            // sinRemitoConLote1ToolStripMenuItem
            // 
            this.sinRemitoConLote1ToolStripMenuItem.Name = "sinRemitoConLote1ToolStripMenuItem";
            this.sinRemitoConLote1ToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
            this.sinRemitoConLote1ToolStripMenuItem.Text = "Muestra s/Remito c/Partida";
            this.sinRemitoConLote1ToolStripMenuItem.Click += new System.EventHandler(this.sinRemitoConLote1ToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(74)))), ((int)(((byte)(95)))));
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(787, 43);
            this.panel1.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(17, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(251, 19);
            this.label4.TabIndex = 1;
            this.label4.Text = "INGRESO DE MUESTRAS A CLIENTES";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(619, 9);
            this.label3.Margin = new System.Windows.Forms.Padding(0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(156, 26);
            this.label3.TabIndex = 0;
            this.label3.Text = "SURFACTAN S.A.";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.P_Buscar, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.P_Botones, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 43F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(787, 551);
            this.tableLayoutPanel1.TabIndex = 3;
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
            this.Fecha.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
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
            this.OrdenFecha.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.OrdenFecha.Visible = false;
            // 
            // Lote1
            // 
            this.Lote1.DataPropertyName = "Lote1";
            this.Lote1.HeaderText = "Lote1";
            this.Lote1.Name = "Lote1";
            this.Lote1.Visible = false;
            // 
            // Muestra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(787, 551);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MinimumSize = new System.Drawing.Size(803, 39);
            this.Name = "Muestra";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.P_Buscar.ResumeLayout(false);
            this.P_Buscar.PerformLayout();
            this.P_Filtrado.ResumeLayout(false);
            this.P_Filtrado.PerformLayout();
            this.P_Botones.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Muestra)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.muestraBindingSource)).EndInit();
            this.CMS_Filtros.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel P_Buscar;
        private System.Windows.Forms.Panel P_Botones;
        private System.Windows.Forms.Button BtActLaborat;
        private System.Windows.Forms.Button BtFin;
        private System.Windows.Forms.Button BtImpresion;
        private System.Windows.Forms.Button BtRemito;
        private System.Windows.Forms.Button BtEtiquetas;
        private System.Windows.Forms.Button BtExportar;
        private System.Windows.Forms.Button BT_Buscar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TB_Hasta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TB_Desde;
        private System.Windows.Forms.TextBox TBFiltro;
        private System.Windows.Forms.Button BT_Filtrar;
        private System.Windows.Forms.Panel P_Filtrado;
        private System.Windows.Forms.BindingSource muestraBindingSource;
        private System.Windows.Forms.DataGridView DGV_Muestra;
        private System.Windows.Forms.Button BT_MenuFiltros;
        private System.Windows.Forms.ContextMenuStrip CMS_Filtros;
        private System.Windows.Forms.ToolStripMenuItem pedidoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fechaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem codigoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem descripcionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cantidadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nombreParaElClienteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem óbservacionesToolStripMenuItem;
        private System.Windows.Forms.Label LBError;
        private System.Windows.Forms.ToolTip toolTip_BTBajaMuestra;
        private System.Windows.Forms.ToolTip toolTip_ActLab;
        private System.Windows.Forms.ToolTip toolTip_Export;
        private System.Windows.Forms.ToolTip toolTip_Etiquetas;
        private System.Windows.Forms.ToolTip toolTip_Remito;
        private System.Windows.Forms.ToolTip toolTip_Impresion;
        private System.Windows.Forms.ToolTip toolTip_Fin;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label LBFiltro;
        private System.Windows.Forms.ToolStripMenuItem clienteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem remitoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hojaDeRutaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sinRemitoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sinRemitoConLote1ToolStripMenuItem;
        private System.Windows.Forms.Button BtEliminar;
        private System.Windows.Forms.ToolTip toolTip_Eliminar;
        private System.Windows.Forms.ToolStripMenuItem codClienteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vendedorToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pedido;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn DescriCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn Razon;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreVend;
        private System.Windows.Forms.DataGridViewTextBoxColumn Observaciones;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha2;
        private System.Windows.Forms.DataGridViewTextBoxColumn remitoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn HojaRuta;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoConf;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lote2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Observaciones2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad2;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrdenFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lote1;
    }
}

