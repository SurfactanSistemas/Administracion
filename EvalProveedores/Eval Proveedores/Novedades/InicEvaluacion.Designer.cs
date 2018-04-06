namespace Eval_Proveedores.Novedades
{
    partial class InicEvaluacion
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.P_Verde = new System.Windows.Forms.Panel();
            this.PProve = new System.Windows.Forms.Panel();
            this.BT_Filtrar2 = new System.Windows.Forms.Button();
            this.TB_Filtro2 = new System.Windows.Forms.TextBox();
            this.LB_Prove = new System.Windows.Forms.Label();
            this.P_Filtrado = new System.Windows.Forms.Panel();
            this.BT_Filtrar = new System.Windows.Forms.Button();
            this.TBFiltroMes = new System.Windows.Forms.TextBox();
            this.LBFiltro = new System.Windows.Forms.Label();
            this.BT_MenuFiltros = new System.Windows.Forms.Button();
            this.CB_Tipo = new System.Windows.Forms.ComboBox();
            this.DGV_Evaluaciones = new System.Windows.Forms.DataGridView();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.Bt_Fin = new System.Windows.Forms.Button();
            this.BT_Eliminar = new System.Windows.Forms.Button();
            this.BTModifEvaluacion = new System.Windows.Forms.Button();
            this.BTAgregarEvaluacion = new System.Windows.Forms.Button();
            this.CMS_Filtros = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.nombreProveedorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tipoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.periodoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ckSoloUltimas = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.evaluaGenBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.TBFiltroAno = new System.Windows.Forms.TextBox();
            this.Clave = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Proveedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NombProve = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DescTipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.periodoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DescPer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Observ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PromedioTot = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ano = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.P_Verde.SuspendLayout();
            this.PProve.SuspendLayout();
            this.P_Filtrado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Evaluaciones)).BeginInit();
            this.CMS_Filtros.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.evaluaGenBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(74)))), ((int)(((byte)(95)))));
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(858, 38);
            this.panel1.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(21, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(174, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "LISTA DE EVALUACIONES";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(694, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "SURFACTAN S.A.";
            // 
            // P_Verde
            // 
            this.P_Verde.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(139)))), ((int)(((byte)(82)))));
            this.P_Verde.Controls.Add(this.ckSoloUltimas);
            this.P_Verde.Controls.Add(this.PProve);
            this.P_Verde.Controls.Add(this.P_Filtrado);
            this.P_Verde.Controls.Add(this.BT_MenuFiltros);
            this.P_Verde.Controls.Add(this.CB_Tipo);
            this.P_Verde.Dock = System.Windows.Forms.DockStyle.Fill;
            this.P_Verde.Location = new System.Drawing.Point(0, 38);
            this.P_Verde.Margin = new System.Windows.Forms.Padding(0);
            this.P_Verde.Name = "P_Verde";
            this.P_Verde.Size = new System.Drawing.Size(858, 62);
            this.P_Verde.TabIndex = 4;
            // 
            // PProve
            // 
            this.PProve.Controls.Add(this.BT_Filtrar2);
            this.PProve.Controls.Add(this.TB_Filtro2);
            this.PProve.Controls.Add(this.LB_Prove);
            this.PProve.Location = new System.Drawing.Point(203, 5);
            this.PProve.Name = "PProve";
            this.PProve.Size = new System.Drawing.Size(322, 52);
            this.PProve.TabIndex = 2;
            this.PProve.Visible = false;
            // 
            // BT_Filtrar2
            // 
            this.BT_Filtrar2.Location = new System.Drawing.Point(244, 15);
            this.BT_Filtrar2.Name = "BT_Filtrar2";
            this.BT_Filtrar2.Size = new System.Drawing.Size(75, 23);
            this.BT_Filtrar2.TabIndex = 2;
            this.BT_Filtrar2.Text = "Filtrar";
            this.BT_Filtrar2.UseVisualStyleBackColor = true;
            this.BT_Filtrar2.Click += new System.EventHandler(this.BT_Filtrar2_Click);
            // 
            // TB_Filtro2
            // 
            this.TB_Filtro2.Location = new System.Drawing.Point(89, 16);
            this.TB_Filtro2.Name = "TB_Filtro2";
            this.TB_Filtro2.Size = new System.Drawing.Size(146, 20);
            this.TB_Filtro2.TabIndex = 1;
            this.TB_Filtro2.TextChanged += new System.EventHandler(this.TB_Filtro2_TextChanged);
            this.TB_Filtro2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TB_Filtro2_KeyDown);
            // 
            // LB_Prove
            // 
            this.LB_Prove.AutoSize = true;
            this.LB_Prove.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LB_Prove.ForeColor = System.Drawing.Color.White;
            this.LB_Prove.Location = new System.Drawing.Point(7, 17);
            this.LB_Prove.Name = "LB_Prove";
            this.LB_Prove.Size = new System.Drawing.Size(46, 18);
            this.LB_Prove.TabIndex = 0;
            this.LB_Prove.Text = "label3";
            // 
            // P_Filtrado
            // 
            this.P_Filtrado.Controls.Add(this.BT_Filtrar);
            this.P_Filtrado.Controls.Add(this.TBFiltroAno);
            this.P_Filtrado.Controls.Add(this.TBFiltroMes);
            this.P_Filtrado.Controls.Add(this.LBFiltro);
            this.P_Filtrado.Location = new System.Drawing.Point(203, 5);
            this.P_Filtrado.Name = "P_Filtrado";
            this.P_Filtrado.Size = new System.Drawing.Size(322, 52);
            this.P_Filtrado.TabIndex = 1;
            this.P_Filtrado.Visible = false;
            // 
            // BT_Filtrar
            // 
            this.BT_Filtrar.Location = new System.Drawing.Point(233, 15);
            this.BT_Filtrar.Name = "BT_Filtrar";
            this.BT_Filtrar.Size = new System.Drawing.Size(75, 23);
            this.BT_Filtrar.TabIndex = 2;
            this.BT_Filtrar.Text = "Filtrar";
            this.BT_Filtrar.UseVisualStyleBackColor = true;
            this.BT_Filtrar.Click += new System.EventHandler(this.BT_Filtrar_Click);
            // 
            // TBFiltroMes
            // 
            this.TBFiltroMes.Location = new System.Drawing.Point(126, 16);
            this.TBFiltroMes.MaxLength = 2;
            this.TBFiltroMes.Name = "TBFiltroMes";
            this.TBFiltroMes.Size = new System.Drawing.Size(40, 20);
            this.TBFiltroMes.TabIndex = 1;
            this.TBFiltroMes.TextChanged += new System.EventHandler(this.TBFiltro_TextChanged);
            this.TBFiltroMes.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TBFiltroMes_KeyDown);
            // 
            // LBFiltro
            // 
            this.LBFiltro.AutoSize = true;
            this.LBFiltro.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBFiltro.ForeColor = System.Drawing.Color.White;
            this.LBFiltro.Location = new System.Drawing.Point(11, 17);
            this.LBFiltro.Name = "LBFiltro";
            this.LBFiltro.Size = new System.Drawing.Size(46, 18);
            this.LBFiltro.TabIndex = 0;
            this.LBFiltro.Text = "label3";
            // 
            // BT_MenuFiltros
            // 
            this.BT_MenuFiltros.Location = new System.Drawing.Point(107, 20);
            this.BT_MenuFiltros.Name = "BT_MenuFiltros";
            this.BT_MenuFiltros.Size = new System.Drawing.Size(75, 23);
            this.BT_MenuFiltros.TabIndex = 0;
            this.BT_MenuFiltros.Text = "Filtrar Por";
            this.BT_MenuFiltros.UseVisualStyleBackColor = true;
            this.BT_MenuFiltros.Click += new System.EventHandler(this.BT_MenuFiltros_Click);
            // 
            // CB_Tipo
            // 
            this.CB_Tipo.FormattingEnabled = true;
            this.CB_Tipo.Items.AddRange(new object[] {
            "TRANSPORTISTA",
            "CALIBRACION",
            "MANTENIMIENTO",
            "OTROS"});
            this.CB_Tipo.Location = new System.Drawing.Point(297, 21);
            this.CB_Tipo.Name = "CB_Tipo";
            this.CB_Tipo.Size = new System.Drawing.Size(190, 21);
            this.CB_Tipo.TabIndex = 3;
            this.CB_Tipo.Visible = false;
            this.CB_Tipo.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // DGV_Evaluaciones
            // 
            this.DGV_Evaluaciones.AllowUserToAddRows = false;
            this.DGV_Evaluaciones.AllowUserToDeleteRows = false;
            this.DGV_Evaluaciones.AllowUserToResizeRows = false;
            this.DGV_Evaluaciones.AutoGenerateColumns = false;
            this.DGV_Evaluaciones.ColumnHeadersHeight = 34;
            this.DGV_Evaluaciones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Clave,
            this.Proveedor,
            this.NombProve,
            this.Estado,
            this.Tipo,
            this.DescTipo,
            this.periodoDataGridViewTextBoxColumn,
            this.DescPer,
            this.Observ,
            this.Mes,
            this.PromedioTot,
            this.Ano});
            this.DGV_Evaluaciones.DataSource = this.evaluaGenBindingSource;
            this.DGV_Evaluaciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGV_Evaluaciones.Location = new System.Drawing.Point(101, 0);
            this.DGV_Evaluaciones.Margin = new System.Windows.Forms.Padding(0);
            this.DGV_Evaluaciones.Name = "DGV_Evaluaciones";
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGV_Evaluaciones.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.DGV_Evaluaciones.Size = new System.Drawing.Size(757, 351);
            this.DGV_Evaluaciones.TabIndex = 5;
            this.DGV_Evaluaciones.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DGV_Evaluaciones_RowHeaderMouseDoubleClick);
            // 
            // Bt_Fin
            // 
            this.Bt_Fin.BackgroundImage = global::Eval_Proveedores.Properties.Resources.Fin2;
            this.Bt_Fin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Bt_Fin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Bt_Fin.ForeColor = System.Drawing.SystemColors.Control;
            this.Bt_Fin.Location = new System.Drawing.Point(17, 243);
            this.Bt_Fin.Margin = new System.Windows.Forms.Padding(0);
            this.Bt_Fin.Name = "Bt_Fin";
            this.Bt_Fin.Size = new System.Drawing.Size(60, 71);
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
            this.BT_Eliminar.Location = new System.Drawing.Point(17, 170);
            this.BT_Eliminar.Name = "BT_Eliminar";
            this.BT_Eliminar.Size = new System.Drawing.Size(60, 71);
            this.BT_Eliminar.TabIndex = 11;
            this.toolTip1.SetToolTip(this.BT_Eliminar, "Eliminar");
            this.BT_Eliminar.UseVisualStyleBackColor = true;
            this.BT_Eliminar.Click += new System.EventHandler(this.BT_Eliminar_Click);
            // 
            // BTModifEvaluacion
            // 
            this.BTModifEvaluacion.BackgroundImage = global::Eval_Proveedores.Properties.Resources.Modificar1;
            this.BTModifEvaluacion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BTModifEvaluacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTModifEvaluacion.ForeColor = System.Drawing.SystemColors.Control;
            this.BTModifEvaluacion.Location = new System.Drawing.Point(17, 104);
            this.BTModifEvaluacion.Margin = new System.Windows.Forms.Padding(0);
            this.BTModifEvaluacion.Name = "BTModifEvaluacion";
            this.BTModifEvaluacion.Size = new System.Drawing.Size(60, 71);
            this.BTModifEvaluacion.TabIndex = 7;
            this.toolTip1.SetToolTip(this.BTModifEvaluacion, " Modificar\r\nEvaluación");
            this.BTModifEvaluacion.UseVisualStyleBackColor = true;
            this.BTModifEvaluacion.Click += new System.EventHandler(this.BTModifEvaluacion_Click);
            // 
            // BTAgregarEvaluacion
            // 
            this.BTAgregarEvaluacion.BackgroundImage = global::Eval_Proveedores.Properties.Resources.UNO_MAS2;
            this.BTAgregarEvaluacion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BTAgregarEvaluacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTAgregarEvaluacion.ForeColor = System.Drawing.SystemColors.Control;
            this.BTAgregarEvaluacion.Location = new System.Drawing.Point(17, 30);
            this.BTAgregarEvaluacion.Name = "BTAgregarEvaluacion";
            this.BTAgregarEvaluacion.Size = new System.Drawing.Size(60, 71);
            this.BTAgregarEvaluacion.TabIndex = 6;
            this.toolTip1.SetToolTip(this.BTAgregarEvaluacion, " Agregar\r\nEvaluación");
            this.BTAgregarEvaluacion.UseVisualStyleBackColor = true;
            this.BTAgregarEvaluacion.Click += new System.EventHandler(this.BTAgregarEvaluacion_Click);
            // 
            // CMS_Filtros
            // 
            this.CMS_Filtros.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nombreProveedorToolStripMenuItem,
            this.tipoToolStripMenuItem,
            this.periodoToolStripMenuItem});
            this.CMS_Filtros.Name = "contextMenuStrip1";
            this.CMS_Filtros.Size = new System.Drawing.Size(176, 70);
            // 
            // nombreProveedorToolStripMenuItem
            // 
            this.nombreProveedorToolStripMenuItem.Name = "nombreProveedorToolStripMenuItem";
            this.nombreProveedorToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.nombreProveedorToolStripMenuItem.Text = "Nombre Proveedor";
            this.nombreProveedorToolStripMenuItem.Click += new System.EventHandler(this.nombreProveedorToolStripMenuItem_Click);
            // 
            // tipoToolStripMenuItem
            // 
            this.tipoToolStripMenuItem.Name = "tipoToolStripMenuItem";
            this.tipoToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.tipoToolStripMenuItem.Text = "Tipo";
            this.tipoToolStripMenuItem.Click += new System.EventHandler(this.tipoToolStripMenuItem_Click);
            // 
            // periodoToolStripMenuItem
            // 
            this.periodoToolStripMenuItem.Name = "periodoToolStripMenuItem";
            this.periodoToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.periodoToolStripMenuItem.Text = "Periodo";
            this.periodoToolStripMenuItem.Click += new System.EventHandler(this.periodoToolStripMenuItem_Click);
            // 
            // ckSoloUltimas
            // 
            this.ckSoloUltimas.Checked = true;
            this.ckSoloUltimas.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckSoloUltimas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckSoloUltimas.ForeColor = System.Drawing.SystemColors.Control;
            this.ckSoloUltimas.Location = new System.Drawing.Point(543, 14);
            this.ckSoloUltimas.Name = "ckSoloUltimas";
            this.ckSoloUltimas.Size = new System.Drawing.Size(96, 34);
            this.ckSoloUltimas.TabIndex = 14;
            this.ckSoloUltimas.Text = "Sólo Ultimas";
            this.ckSoloUltimas.UseVisualStyleBackColor = true;
            this.ckSoloUltimas.CheckedChanged += new System.EventHandler(this.ckSoloUltimas_CheckedChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.P_Verde, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 62F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(858, 451);
            this.tableLayoutPanel1.TabIndex = 15;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 101F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.DGV_Evaluaciones, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 100);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(858, 351);
            this.tableLayoutPanel2.TabIndex = 5;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.BTAgregarEvaluacion);
            this.panel2.Controls.Add(this.BTModifEvaluacion);
            this.panel2.Controls.Add(this.Bt_Fin);
            this.panel2.Controls.Add(this.BT_Eliminar);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(95, 345);
            this.panel2.TabIndex = 0;
            // 
            // evaluaGenBindingSource
            // 
            this.evaluaGenBindingSource.DataSource = typeof(Negocio.EvaluaGen);
            // 
            // TBFiltroAno
            // 
            this.TBFiltroAno.Location = new System.Drawing.Point(172, 16);
            this.TBFiltroAno.MaxLength = 4;
            this.TBFiltroAno.Name = "TBFiltroAno";
            this.TBFiltroAno.Size = new System.Drawing.Size(55, 20);
            this.TBFiltroAno.TabIndex = 1;
            this.TBFiltroAno.TextChanged += new System.EventHandler(this.TBFiltro_TextChanged);
            this.TBFiltroAno.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TBFiltro_KeyDown);
            // 
            // Clave
            // 
            this.Clave.DataPropertyName = "Clave";
            this.Clave.HeaderText = "Clave";
            this.Clave.Name = "Clave";
            this.Clave.Visible = false;
            // 
            // Proveedor
            // 
            this.Proveedor.DataPropertyName = "Proveedor";
            this.Proveedor.HeaderText = "Proveedor";
            this.Proveedor.Name = "Proveedor";
            // 
            // NombProve
            // 
            this.NombProve.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.NombProve.DataPropertyName = "NombProve";
            this.NombProve.HeaderText = "Nombre Proveedor";
            this.NombProve.Name = "NombProve";
            // 
            // Estado
            // 
            this.Estado.DataPropertyName = "Estado";
            this.Estado.HeaderText = "Estado Proveedor";
            this.Estado.Name = "Estado";
            // 
            // Tipo
            // 
            this.Tipo.DataPropertyName = "Tipo";
            this.Tipo.HeaderText = "Tipo";
            this.Tipo.Name = "Tipo";
            this.Tipo.Visible = false;
            this.Tipo.Width = 50;
            // 
            // DescTipo
            // 
            this.DescTipo.DataPropertyName = "DescTipo";
            this.DescTipo.HeaderText = "Tipo";
            this.DescTipo.Name = "DescTipo";
            // 
            // periodoDataGridViewTextBoxColumn
            // 
            this.periodoDataGridViewTextBoxColumn.DataPropertyName = "Periodo";
            this.periodoDataGridViewTextBoxColumn.HeaderText = "Periodo";
            this.periodoDataGridViewTextBoxColumn.Name = "periodoDataGridViewTextBoxColumn";
            this.periodoDataGridViewTextBoxColumn.Visible = false;
            this.periodoDataGridViewTextBoxColumn.Width = 50;
            // 
            // DescPer
            // 
            this.DescPer.DataPropertyName = "DescFecha";
            this.DescPer.HeaderText = "Periodo";
            this.DescPer.Name = "DescPer";
            // 
            // Observ
            // 
            this.Observ.DataPropertyName = "Observaciones";
            this.Observ.HeaderText = "Observaciones";
            this.Observ.Name = "Observ";
            this.Observ.Width = 200;
            // 
            // Mes
            // 
            this.Mes.DataPropertyName = "Mes";
            this.Mes.HeaderText = "Mes";
            this.Mes.Name = "Mes";
            this.Mes.Visible = false;
            // 
            // PromedioTot
            // 
            this.PromedioTot.DataPropertyName = "Promedio";
            this.PromedioTot.HeaderText = "PromedioTot";
            this.PromedioTot.Name = "PromedioTot";
            // 
            // Ano
            // 
            this.Ano.DataPropertyName = "Año";
            this.Ano.HeaderText = "Año";
            this.Ano.Name = "Ano";
            this.Ano.Visible = false;
            // 
            // InicEvaluacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(858, 451);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MaximizeBox = false;
            this.Name = "InicEvaluacion";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.InicEvaluacion_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.P_Verde.ResumeLayout(false);
            this.PProve.ResumeLayout(false);
            this.PProve.PerformLayout();
            this.P_Filtrado.ResumeLayout(false);
            this.P_Filtrado.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Evaluaciones)).EndInit();
            this.CMS_Filtros.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.evaluaGenBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel P_Verde;
        private System.Windows.Forms.Panel P_Filtrado;
        private System.Windows.Forms.Button BT_Filtrar;
        private System.Windows.Forms.TextBox TBFiltroMes;
        private System.Windows.Forms.Label LBFiltro;
        private System.Windows.Forms.Button BT_MenuFiltros;
        private System.Windows.Forms.DataGridView DGV_Evaluaciones;
        private System.Windows.Forms.Button BTAgregarEvaluacion;
        private System.Windows.Forms.Button BTModifEvaluacion;
        private System.Windows.Forms.Button BT_Eliminar;
        private System.Windows.Forms.Button Bt_Fin;
        private System.Windows.Forms.BindingSource evaluaGenBindingSource;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ContextMenuStrip CMS_Filtros;
        private System.Windows.Forms.ToolStripMenuItem nombreProveedorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tipoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem periodoToolStripMenuItem;
        private System.Windows.Forms.Panel PProve;
        private System.Windows.Forms.Button BT_Filtrar2;
        private System.Windows.Forms.TextBox TB_Filtro2;
        private System.Windows.Forms.Label LB_Prove;
        private System.Windows.Forms.ComboBox CB_Tipo;
        private System.Windows.Forms.CheckBox ckSoloUltimas;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox TBFiltroAno;
        private System.Windows.Forms.DataGridViewTextBoxColumn Clave;
        private System.Windows.Forms.DataGridViewTextBoxColumn Proveedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombProve;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estado;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn DescTipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn periodoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DescPer;
        private System.Windows.Forms.DataGridViewTextBoxColumn Observ;
        private System.Windows.Forms.DataGridViewTextBoxColumn Mes;
        private System.Windows.Forms.DataGridViewTextBoxColumn PromedioTot;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ano;
    }
}