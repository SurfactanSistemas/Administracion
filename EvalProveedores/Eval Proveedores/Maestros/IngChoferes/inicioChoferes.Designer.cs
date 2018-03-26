namespace Eval_Proveedores.IngChoferes
{
    partial class inicioChoferes
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.P_Verde = new System.Windows.Forms.Panel();
            this.P_Filtrado = new System.Windows.Forms.Panel();
            this.BT_Filtrar = new System.Windows.Forms.Button();
            this.TBFiltro = new System.Windows.Forms.TextBox();
            this.LBFiltro = new System.Windows.Forms.Label();
            this.BT_MenuFiltros = new System.Windows.Forms.Button();
            this.DGV_Choferes = new System.Windows.Forms.DataGridView();
            this.codigoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Aplica = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CargPelig = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.proveedorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NomProve = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codigoEmpresaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaVto1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Comentario1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaVto2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Comentario2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaVto3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrdFechaVto1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrdFechaVto2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrdFechaVto3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaEnt1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaEnt2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaEnt3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrdFechaEnt1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrdFechaEnt2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrdFechaEnt3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Comentario3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.choferBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.Bt_Fin = new System.Windows.Forms.Button();
            this.BT_Eliminar = new System.Windows.Forms.Button();
            this.Bt_Imprimir = new System.Windows.Forms.Button();
            this.BTModifChofer = new System.Windows.Forms.Button();
            this.BTAgregarChofer = new System.Windows.Forms.Button();
            this.CMS_Filtros = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.codigoProveedorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nombreProveedorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nombreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.P_Verde.SuspendLayout();
            this.P_Filtrado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Choferes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.choferBindingSource)).BeginInit();
            this.CMS_Filtros.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(74)))), ((int)(((byte)(95)))));
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(-8, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1122, 39);
            this.panel1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(9, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(165, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "INGRESO DE CHOFERES";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(965, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "SURFACTAN S.A.";
            // 
            // P_Verde
            // 
            this.P_Verde.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.P_Verde.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(139)))), ((int)(((byte)(82)))));
            this.P_Verde.Controls.Add(this.P_Filtrado);
            this.P_Verde.Controls.Add(this.BT_MenuFiltros);
            this.P_Verde.Location = new System.Drawing.Point(-8, 38);
            this.P_Verde.Name = "P_Verde";
            this.P_Verde.Size = new System.Drawing.Size(1122, 55);
            this.P_Verde.TabIndex = 2;
            // 
            // P_Filtrado
            // 
            this.P_Filtrado.Controls.Add(this.BT_Filtrar);
            this.P_Filtrado.Controls.Add(this.TBFiltro);
            this.P_Filtrado.Controls.Add(this.LBFiltro);
            this.P_Filtrado.Location = new System.Drawing.Point(96, 1);
            this.P_Filtrado.Name = "P_Filtrado";
            this.P_Filtrado.Size = new System.Drawing.Size(404, 52);
            this.P_Filtrado.TabIndex = 1;
            this.P_Filtrado.Visible = false;
            // 
            // BT_Filtrar
            // 
            this.BT_Filtrar.Location = new System.Drawing.Point(316, 15);
            this.BT_Filtrar.Name = "BT_Filtrar";
            this.BT_Filtrar.Size = new System.Drawing.Size(75, 23);
            this.BT_Filtrar.TabIndex = 2;
            this.BT_Filtrar.Text = "Filtrar";
            this.BT_Filtrar.UseVisualStyleBackColor = true;
            this.BT_Filtrar.Click += new System.EventHandler(this.BT_Filtrar_Click);
            // 
            // TBFiltro
            // 
            this.TBFiltro.Location = new System.Drawing.Point(145, 17);
            this.TBFiltro.Name = "TBFiltro";
            this.TBFiltro.Size = new System.Drawing.Size(146, 20);
            this.TBFiltro.TabIndex = 1;
            this.TBFiltro.TextChanged += new System.EventHandler(this.TBFiltro_TextChanged);
            this.TBFiltro.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TBFiltro_KeyDown);
            // 
            // LBFiltro
            // 
            this.LBFiltro.AutoSize = true;
            this.LBFiltro.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBFiltro.ForeColor = System.Drawing.Color.White;
            this.LBFiltro.Location = new System.Drawing.Point(4, 17);
            this.LBFiltro.Name = "LBFiltro";
            this.LBFiltro.Size = new System.Drawing.Size(46, 18);
            this.LBFiltro.TabIndex = 0;
            this.LBFiltro.Text = "label3";
            // 
            // BT_MenuFiltros
            // 
            this.BT_MenuFiltros.Location = new System.Drawing.Point(15, 16);
            this.BT_MenuFiltros.Name = "BT_MenuFiltros";
            this.BT_MenuFiltros.Size = new System.Drawing.Size(75, 23);
            this.BT_MenuFiltros.TabIndex = 0;
            this.BT_MenuFiltros.Text = "Filtrar Por";
            this.BT_MenuFiltros.UseVisualStyleBackColor = true;
            this.BT_MenuFiltros.Click += new System.EventHandler(this.BT_MenuFiltros_Click);
            // 
            // DGV_Choferes
            // 
            this.DGV_Choferes.AllowUserToAddRows = false;
            this.DGV_Choferes.AllowUserToDeleteRows = false;
            this.DGV_Choferes.AllowUserToResizeRows = false;
            this.DGV_Choferes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGV_Choferes.AutoGenerateColumns = false;
            this.DGV_Choferes.ColumnHeadersHeight = 34;
            this.DGV_Choferes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codigoDataGridViewTextBoxColumn,
            this.descripcionDataGridViewTextBoxColumn,
            this.Aplica,
            this.CargPelig,
            this.proveedorDataGridViewTextBoxColumn,
            this.NomProve,
            this.codigoEmpresaDataGridViewTextBoxColumn,
            this.FechaVto1,
            this.Comentario1,
            this.FechaVto2,
            this.Comentario2,
            this.FechaVto3,
            this.OrdFechaVto1,
            this.OrdFechaVto2,
            this.OrdFechaVto3,
            this.FechaEnt1,
            this.FechaEnt2,
            this.FechaEnt3,
            this.OrdFechaEnt1,
            this.OrdFechaEnt2,
            this.OrdFechaEnt3,
            this.Comentario3});
            this.DGV_Choferes.DataSource = this.choferBindingSource;
            this.DGV_Choferes.Location = new System.Drawing.Point(70, 93);
            this.DGV_Choferes.Margin = new System.Windows.Forms.Padding(0);
            this.DGV_Choferes.Name = "DGV_Choferes";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV_Choferes.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.DGV_Choferes.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.DGV_Choferes.Size = new System.Drawing.Size(1044, 358);
            this.DGV_Choferes.TabIndex = 3;
            this.DGV_Choferes.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DGV_Choferes_RowHeaderMouseDoubleClick);
            // 
            // codigoDataGridViewTextBoxColumn
            // 
            this.codigoDataGridViewTextBoxColumn.DataPropertyName = "Codigo";
            this.codigoDataGridViewTextBoxColumn.HeaderText = "Codigo";
            this.codigoDataGridViewTextBoxColumn.Name = "codigoDataGridViewTextBoxColumn";
            // 
            // descripcionDataGridViewTextBoxColumn
            // 
            this.descripcionDataGridViewTextBoxColumn.DataPropertyName = "Descripcion";
            this.descripcionDataGridViewTextBoxColumn.HeaderText = "Nombre";
            this.descripcionDataGridViewTextBoxColumn.Name = "descripcionDataGridViewTextBoxColumn";
            // 
            // Aplica
            // 
            this.Aplica.DataPropertyName = "AplicaIII";
            this.Aplica.HeaderText = "Aplica";
            this.Aplica.Name = "Aplica";
            this.Aplica.Visible = false;
            // 
            // CargPelig
            // 
            this.CargPelig.DataPropertyName = "DescAplica";
            this.CargPelig.HeaderText = "Carg. Pelig.";
            this.CargPelig.Name = "CargPelig";
            // 
            // proveedorDataGridViewTextBoxColumn
            // 
            this.proveedorDataGridViewTextBoxColumn.DataPropertyName = "Proveedor";
            this.proveedorDataGridViewTextBoxColumn.HeaderText = "Proveedor";
            this.proveedorDataGridViewTextBoxColumn.Name = "proveedorDataGridViewTextBoxColumn";
            this.proveedorDataGridViewTextBoxColumn.Visible = false;
            this.proveedorDataGridViewTextBoxColumn.Width = 101;
            // 
            // NomProve
            // 
            this.NomProve.DataPropertyName = "NombProve";
            this.NomProve.HeaderText = "Nomb. Prove";
            this.NomProve.Name = "NomProve";
            // 
            // codigoEmpresaDataGridViewTextBoxColumn
            // 
            this.codigoEmpresaDataGridViewTextBoxColumn.DataPropertyName = "CodigoEmpresa";
            this.codigoEmpresaDataGridViewTextBoxColumn.HeaderText = "CodigoEmpresa";
            this.codigoEmpresaDataGridViewTextBoxColumn.Name = "codigoEmpresaDataGridViewTextBoxColumn";
            this.codigoEmpresaDataGridViewTextBoxColumn.Visible = false;
            // 
            // FechaVto1
            // 
            this.FechaVto1.DataPropertyName = "FechaVtoI";
            this.FechaVto1.HeaderText = "Vto Ruta";
            this.FechaVto1.Name = "FechaVto1";
            // 
            // Comentario1
            // 
            this.Comentario1.DataPropertyName = "ComentarioI";
            this.Comentario1.HeaderText = "Observ. Ruta";
            this.Comentario1.Name = "Comentario1";
            // 
            // FechaVto2
            // 
            this.FechaVto2.DataPropertyName = "FechaVtoII";
            this.FechaVto2.HeaderText = "Vto RTO ";
            this.FechaVto2.Name = "FechaVto2";
            // 
            // Comentario2
            // 
            this.Comentario2.DataPropertyName = "ComentarioII";
            this.Comentario2.HeaderText = "Observ. RTO";
            this.Comentario2.Name = "Comentario2";
            // 
            // FechaVto3
            // 
            this.FechaVto3.DataPropertyName = "FechaVtoIII";
            this.FechaVto3.HeaderText = "Vto Carg. Pelig.";
            this.FechaVto3.Name = "FechaVto3";
            this.FechaVto3.Width = 110;
            // 
            // OrdFechaVto1
            // 
            this.OrdFechaVto1.DataPropertyName = "OrdFechaVtoI";
            this.OrdFechaVto1.HeaderText = "OrdFechaVto1";
            this.OrdFechaVto1.Name = "OrdFechaVto1";
            this.OrdFechaVto1.Visible = false;
            // 
            // OrdFechaVto2
            // 
            this.OrdFechaVto2.DataPropertyName = "OrdFechaVtoII";
            this.OrdFechaVto2.HeaderText = "OrdFechaVto2";
            this.OrdFechaVto2.Name = "OrdFechaVto2";
            this.OrdFechaVto2.Visible = false;
            // 
            // OrdFechaVto3
            // 
            this.OrdFechaVto3.DataPropertyName = "OrdFechaVtoIII";
            this.OrdFechaVto3.HeaderText = "OrdFechaVto3";
            this.OrdFechaVto3.Name = "OrdFechaVto3";
            this.OrdFechaVto3.Visible = false;
            // 
            // FechaEnt1
            // 
            this.FechaEnt1.DataPropertyName = "FechaEntregaI";
            this.FechaEnt1.HeaderText = "FechaEnt1";
            this.FechaEnt1.Name = "FechaEnt1";
            this.FechaEnt1.Visible = false;
            // 
            // FechaEnt2
            // 
            this.FechaEnt2.DataPropertyName = "FechaEntregaII";
            this.FechaEnt2.HeaderText = "FechaEnt2";
            this.FechaEnt2.Name = "FechaEnt2";
            this.FechaEnt2.Visible = false;
            // 
            // FechaEnt3
            // 
            this.FechaEnt3.DataPropertyName = "FechaEntregaIII";
            this.FechaEnt3.HeaderText = "FechaEnt3";
            this.FechaEnt3.Name = "FechaEnt3";
            this.FechaEnt3.Visible = false;
            // 
            // OrdFechaEnt1
            // 
            this.OrdFechaEnt1.DataPropertyName = "OrdFechaEntregaI";
            this.OrdFechaEnt1.HeaderText = "OrdFechaEnt1";
            this.OrdFechaEnt1.Name = "OrdFechaEnt1";
            this.OrdFechaEnt1.Visible = false;
            // 
            // OrdFechaEnt2
            // 
            this.OrdFechaEnt2.DataPropertyName = "OrdFechaEntregaII";
            this.OrdFechaEnt2.HeaderText = "OrdFechaEnt2";
            this.OrdFechaEnt2.Name = "OrdFechaEnt2";
            this.OrdFechaEnt2.Visible = false;
            // 
            // OrdFechaEnt3
            // 
            this.OrdFechaEnt3.DataPropertyName = "OrdFechaEntregaIII";
            this.OrdFechaEnt3.HeaderText = "OrdFechaEnt3";
            this.OrdFechaEnt3.Name = "OrdFechaEnt3";
            this.OrdFechaEnt3.Visible = false;
            // 
            // Comentario3
            // 
            this.Comentario3.DataPropertyName = "ComentarioIII";
            this.Comentario3.HeaderText = "Observ Carg. Pelig.";
            this.Comentario3.Name = "Comentario3";
            this.Comentario3.Width = 120;
            // 
            // choferBindingSource
            // 
            this.choferBindingSource.DataSource = typeof(Negocio.Chofer);
            // 
            // Bt_Fin
            // 
            this.Bt_Fin.BackgroundImage = global::Eval_Proveedores.Properties.Resources.Fin2;
            this.Bt_Fin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Bt_Fin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Bt_Fin.ForeColor = System.Drawing.SystemColors.Control;
            this.Bt_Fin.Location = new System.Drawing.Point(12, 396);
            this.Bt_Fin.Margin = new System.Windows.Forms.Padding(0);
            this.Bt_Fin.Name = "Bt_Fin";
            this.Bt_Fin.Size = new System.Drawing.Size(47, 53);
            this.Bt_Fin.TabIndex = 13;
            this.toolTip1.SetToolTip(this.Bt_Fin, "Salir");
            this.Bt_Fin.UseVisualStyleBackColor = true;
            this.Bt_Fin.Click += new System.EventHandler(this.Bt_Fin_Click);
            // 
            // BT_Eliminar
            // 
            this.BT_Eliminar.BackgroundImage = global::Eval_Proveedores.Properties.Resources.eliminar;
            this.BT_Eliminar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BT_Eliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BT_Eliminar.ForeColor = System.Drawing.SystemColors.Control;
            this.BT_Eliminar.Location = new System.Drawing.Point(8, 266);
            this.BT_Eliminar.Name = "BT_Eliminar";
            this.BT_Eliminar.Size = new System.Drawing.Size(55, 70);
            this.BT_Eliminar.TabIndex = 9;
            this.toolTip1.SetToolTip(this.BT_Eliminar, "Eliminar");
            this.BT_Eliminar.UseVisualStyleBackColor = true;
            this.BT_Eliminar.Click += new System.EventHandler(this.BT_Eliminar_Click);
            // 
            // Bt_Imprimir
            // 
            this.Bt_Imprimir.BackgroundImage = global::Eval_Proveedores.Properties.Resources.Imprimir;
            this.Bt_Imprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Bt_Imprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Bt_Imprimir.ForeColor = System.Drawing.SystemColors.Control;
            this.Bt_Imprimir.Location = new System.Drawing.Point(7, 337);
            this.Bt_Imprimir.Margin = new System.Windows.Forms.Padding(0);
            this.Bt_Imprimir.Name = "Bt_Imprimir";
            this.Bt_Imprimir.Size = new System.Drawing.Size(56, 48);
            this.Bt_Imprimir.TabIndex = 6;
            this.toolTip1.SetToolTip(this.Bt_Imprimir, "Imprimir");
            this.Bt_Imprimir.UseVisualStyleBackColor = true;
            this.Bt_Imprimir.Click += new System.EventHandler(this.Bt_Imprimir_Click);
            // 
            // BTModifChofer
            // 
            this.BTModifChofer.BackgroundImage = global::Eval_Proveedores.Properties.Resources.choferes_modificar;
            this.BTModifChofer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BTModifChofer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTModifChofer.ForeColor = System.Drawing.SystemColors.Control;
            this.BTModifChofer.Location = new System.Drawing.Point(7, 203);
            this.BTModifChofer.Margin = new System.Windows.Forms.Padding(0);
            this.BTModifChofer.Name = "BTModifChofer";
            this.BTModifChofer.Size = new System.Drawing.Size(56, 60);
            this.BTModifChofer.TabIndex = 5;
            this.toolTip1.SetToolTip(this.BTModifChofer, "Modificar\r\n  Chofer");
            this.BTModifChofer.UseVisualStyleBackColor = true;
            this.BTModifChofer.Click += new System.EventHandler(this.BTModifChofer_Click);
            // 
            // BTAgregarChofer
            // 
            this.BTAgregarChofer.BackgroundImage = global::Eval_Proveedores.Properties.Resources.choferes_agregar;
            this.BTAgregarChofer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BTAgregarChofer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTAgregarChofer.ForeColor = System.Drawing.SystemColors.Control;
            this.BTAgregarChofer.Location = new System.Drawing.Point(5, 129);
            this.BTAgregarChofer.Name = "BTAgregarChofer";
            this.BTAgregarChofer.Size = new System.Drawing.Size(60, 71);
            this.BTAgregarChofer.TabIndex = 4;
            this.toolTip1.SetToolTip(this.BTAgregarChofer, "Agregar\r\nChofer");
            this.BTAgregarChofer.UseVisualStyleBackColor = true;
            this.BTAgregarChofer.Click += new System.EventHandler(this.BTAgregarChofer_Click);
            // 
            // CMS_Filtros
            // 
            this.CMS_Filtros.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.codigoProveedorToolStripMenuItem,
            this.nombreProveedorToolStripMenuItem,
            this.nombreToolStripMenuItem});
            this.CMS_Filtros.Name = "CMS_Filtros";
            this.CMS_Filtros.Size = new System.Drawing.Size(176, 70);
            // 
            // codigoProveedorToolStripMenuItem
            // 
            this.codigoProveedorToolStripMenuItem.Name = "codigoProveedorToolStripMenuItem";
            this.codigoProveedorToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.codigoProveedorToolStripMenuItem.Text = "Codigo Chofer";
            this.codigoProveedorToolStripMenuItem.Click += new System.EventHandler(this.codigoProveedorToolStripMenuItem_Click);
            // 
            // nombreProveedorToolStripMenuItem
            // 
            this.nombreProveedorToolStripMenuItem.Name = "nombreProveedorToolStripMenuItem";
            this.nombreProveedorToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.nombreProveedorToolStripMenuItem.Text = "Nombre Proveedor";
            this.nombreProveedorToolStripMenuItem.Click += new System.EventHandler(this.nombreProveedorToolStripMenuItem_Click);
            // 
            // nombreToolStripMenuItem
            // 
            this.nombreToolStripMenuItem.Name = "nombreToolStripMenuItem";
            this.nombreToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.nombreToolStripMenuItem.Text = "Nombre";
            this.nombreToolStripMenuItem.Click += new System.EventHandler(this.nombreToolStripMenuItem_Click);
            // 
            // inicioChoferes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1114, 453);
            this.Controls.Add(this.Bt_Fin);
            this.Controls.Add(this.BT_Eliminar);
            this.Controls.Add(this.Bt_Imprimir);
            this.Controls.Add(this.BTModifChofer);
            this.Controls.Add(this.BTAgregarChofer);
            this.Controls.Add(this.DGV_Choferes);
            this.Controls.Add(this.P_Verde);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1130, 491);
            this.Name = "inicioChoferes";
            this.Load += new System.EventHandler(this.inicioChoferes_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.P_Verde.ResumeLayout(false);
            this.P_Filtrado.ResumeLayout(false);
            this.P_Filtrado.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Choferes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.choferBindingSource)).EndInit();
            this.CMS_Filtros.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel P_Verde;
        private System.Windows.Forms.Panel P_Filtrado;
        private System.Windows.Forms.Button BT_Filtrar;
        private System.Windows.Forms.TextBox TBFiltro;
        private System.Windows.Forms.Label LBFiltro;
        private System.Windows.Forms.Button BT_MenuFiltros;
        private System.Windows.Forms.DataGridView DGV_Choferes;
        private System.Windows.Forms.Button BTAgregarChofer;
        private System.Windows.Forms.Button BTModifChofer;
        private System.Windows.Forms.Button Bt_Imprimir;
        private System.Windows.Forms.Button BT_Eliminar;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.BindingSource choferBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn aplicaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaVto1DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaVto2DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaVto3DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ordFechaVto1DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ordFechaVto2DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ordFechaVto3DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaEnt1DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaEnt2DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaEnt3DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ordFechaEnt1DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ordFechaEnt2DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ordFechaEnt3DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn comentario1DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn comentario2DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn comentario3DataGridViewTextBoxColumn;
        private System.Windows.Forms.Button Bt_Fin;
        private System.Windows.Forms.ContextMenuStrip CMS_Filtros;
        private System.Windows.Forms.ToolStripMenuItem codigoProveedorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nombreProveedorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nombreToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Aplica;
        private System.Windows.Forms.DataGridViewTextBoxColumn CargPelig;
        private System.Windows.Forms.DataGridViewTextBoxColumn proveedorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn NomProve;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigoEmpresaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaVto1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Comentario1;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaVto2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Comentario2;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaVto3;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrdFechaVto1;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrdFechaVto2;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrdFechaVto3;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaEnt1;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaEnt2;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaEnt3;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrdFechaEnt1;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrdFechaEnt2;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrdFechaEnt3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Comentario3;
    }
}