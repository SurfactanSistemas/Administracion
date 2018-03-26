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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.TBFiltro = new System.Windows.Forms.TextBox();
            this.LBFiltro = new System.Windows.Forms.Label();
            this.BT_MenuFiltros = new System.Windows.Forms.Button();
            this.CB_Tipo = new System.Windows.Forms.ComboBox();
            this.DGV_Evaluaciones = new System.Windows.Forms.DataGridView();
            this.claveDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.proveedorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NombProve = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DescTipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.periodoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DescPer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Observ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PromedioTot = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.añoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.evaluaGenBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.Bt_Fin = new System.Windows.Forms.Button();
            this.BT_Eliminar = new System.Windows.Forms.Button();
            this.BTModifEvaluacion = new System.Windows.Forms.Button();
            this.BTAgregarEvaluacion = new System.Windows.Forms.Button();
            this.CMS_Filtros = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.nombreProveedorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tipoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.periodoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.P_Verde.SuspendLayout();
            this.PProve.SuspendLayout();
            this.P_Filtrado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Evaluaciones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.evaluaGenBindingSource)).BeginInit();
            this.CMS_Filtros.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(74)))), ((int)(((byte)(95)))));
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(-8, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(861, 39);
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
            this.P_Verde.Controls.Add(this.PProve);
            this.P_Verde.Controls.Add(this.P_Filtrado);
            this.P_Verde.Controls.Add(this.BT_MenuFiltros);
            this.P_Verde.Controls.Add(this.CB_Tipo);
            this.P_Verde.Location = new System.Drawing.Point(-8, 38);
            this.P_Verde.Name = "P_Verde";
            this.P_Verde.Size = new System.Drawing.Size(861, 55);
            this.P_Verde.TabIndex = 4;
            // 
            // PProve
            // 
            this.PProve.Controls.Add(this.BT_Filtrar2);
            this.PProve.Controls.Add(this.TB_Filtro2);
            this.PProve.Controls.Add(this.LB_Prove);
            this.PProve.Location = new System.Drawing.Point(489, 1);
            this.PProve.Name = "PProve";
            this.PProve.Size = new System.Drawing.Size(322, 52);
            this.PProve.TabIndex = 2;
            this.PProve.Visible = false;
            // 
            // BT_Filtrar2
            // 
            this.BT_Filtrar2.Location = new System.Drawing.Point(244, 14);
            this.BT_Filtrar2.Name = "BT_Filtrar2";
            this.BT_Filtrar2.Size = new System.Drawing.Size(75, 23);
            this.BT_Filtrar2.TabIndex = 2;
            this.BT_Filtrar2.Text = "Filtrar";
            this.BT_Filtrar2.UseVisualStyleBackColor = true;
            this.BT_Filtrar2.Click += new System.EventHandler(this.BT_Filtrar2_Click);
            // 
            // TB_Filtro2
            // 
            this.TB_Filtro2.Location = new System.Drawing.Point(89, 15);
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
            this.LB_Prove.Location = new System.Drawing.Point(7, 15);
            this.LB_Prove.Name = "LB_Prove";
            this.LB_Prove.Size = new System.Drawing.Size(46, 18);
            this.LB_Prove.TabIndex = 0;
            this.LB_Prove.Text = "label3";
            // 
            // P_Filtrado
            // 
            this.P_Filtrado.Controls.Add(this.BT_Filtrar);
            this.P_Filtrado.Controls.Add(this.TBFiltro);
            this.P_Filtrado.Controls.Add(this.LBFiltro);
            this.P_Filtrado.Location = new System.Drawing.Point(104, 0);
            this.P_Filtrado.Name = "P_Filtrado";
            this.P_Filtrado.Size = new System.Drawing.Size(381, 52);
            this.P_Filtrado.TabIndex = 1;
            this.P_Filtrado.Visible = false;
            // 
            // BT_Filtrar
            // 
            this.BT_Filtrar.Location = new System.Drawing.Point(297, 16);
            this.BT_Filtrar.Name = "BT_Filtrar";
            this.BT_Filtrar.Size = new System.Drawing.Size(75, 23);
            this.BT_Filtrar.TabIndex = 2;
            this.BT_Filtrar.Text = "Filtrar";
            this.BT_Filtrar.UseVisualStyleBackColor = true;
            this.BT_Filtrar.Click += new System.EventHandler(this.BT_Filtrar_Click);
            // 
            // TBFiltro
            // 
            this.TBFiltro.Location = new System.Drawing.Point(129, 17);
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
            // CB_Tipo
            // 
            this.CB_Tipo.FormattingEnabled = true;
            this.CB_Tipo.Items.AddRange(new object[] {
            "TRANSPORTISTA",
            "CALIBRACION",
            "MANTENIMIENTO",
            "OTROS"});
            this.CB_Tipo.Location = new System.Drawing.Point(212, 16);
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
            this.claveDataGridViewTextBoxColumn,
            this.proveedorDataGridViewTextBoxColumn,
            this.NombProve,
            this.Estado,
            this.tipoDataGridViewTextBoxColumn,
            this.DescTipo,
            this.periodoDataGridViewTextBoxColumn,
            this.DescPer,
            this.Observ,
            this.mesDataGridViewTextBoxColumn,
            this.PromedioTot,
            this.añoDataGridViewTextBoxColumn});
            this.DGV_Evaluaciones.DataSource = this.evaluaGenBindingSource;
            this.DGV_Evaluaciones.Location = new System.Drawing.Point(70, 93);
            this.DGV_Evaluaciones.Margin = new System.Windows.Forms.Padding(0);
            this.DGV_Evaluaciones.Name = "DGV_Evaluaciones";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV_Evaluaciones.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.DGV_Evaluaciones.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.DGV_Evaluaciones.Size = new System.Drawing.Size(774, 358);
            this.DGV_Evaluaciones.TabIndex = 5;
            this.DGV_Evaluaciones.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DGV_Evaluaciones_RowHeaderMouseDoubleClick);
            // 
            // claveDataGridViewTextBoxColumn
            // 
            this.claveDataGridViewTextBoxColumn.DataPropertyName = "Clave";
            this.claveDataGridViewTextBoxColumn.HeaderText = "Clave";
            this.claveDataGridViewTextBoxColumn.Name = "claveDataGridViewTextBoxColumn";
            this.claveDataGridViewTextBoxColumn.Visible = false;
            // 
            // proveedorDataGridViewTextBoxColumn
            // 
            this.proveedorDataGridViewTextBoxColumn.DataPropertyName = "Proveedor";
            this.proveedorDataGridViewTextBoxColumn.HeaderText = "Proveedor";
            this.proveedorDataGridViewTextBoxColumn.Name = "proveedorDataGridViewTextBoxColumn";
            // 
            // NombProve
            // 
            this.NombProve.DataPropertyName = "NombProve";
            this.NombProve.HeaderText = "Nombre Proveedor";
            this.NombProve.Name = "NombProve";
            this.NombProve.Width = 200;
            // 
            // Estado
            // 
            this.Estado.DataPropertyName = "Estado";
            this.Estado.HeaderText = "Estado Proveedor";
            this.Estado.Name = "Estado";
            // 
            // tipoDataGridViewTextBoxColumn
            // 
            this.tipoDataGridViewTextBoxColumn.DataPropertyName = "Tipo";
            this.tipoDataGridViewTextBoxColumn.HeaderText = "Tipo";
            this.tipoDataGridViewTextBoxColumn.Name = "tipoDataGridViewTextBoxColumn";
            this.tipoDataGridViewTextBoxColumn.Visible = false;
            this.tipoDataGridViewTextBoxColumn.Width = 50;
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
            // mesDataGridViewTextBoxColumn
            // 
            this.mesDataGridViewTextBoxColumn.DataPropertyName = "Mes";
            this.mesDataGridViewTextBoxColumn.HeaderText = "Mes";
            this.mesDataGridViewTextBoxColumn.Name = "mesDataGridViewTextBoxColumn";
            this.mesDataGridViewTextBoxColumn.Visible = false;
            // 
            // PromedioTot
            // 
            this.PromedioTot.DataPropertyName = "Promedio";
            this.PromedioTot.HeaderText = "PromedioTot";
            this.PromedioTot.Name = "PromedioTot";
            // 
            // añoDataGridViewTextBoxColumn
            // 
            this.añoDataGridViewTextBoxColumn.DataPropertyName = "Año";
            this.añoDataGridViewTextBoxColumn.HeaderText = "Año";
            this.añoDataGridViewTextBoxColumn.Name = "añoDataGridViewTextBoxColumn";
            this.añoDataGridViewTextBoxColumn.Visible = false;
            // 
            // evaluaGenBindingSource
            // 
            this.evaluaGenBindingSource.DataSource = typeof(Negocio.EvaluaGen);
            // 
            // Bt_Fin
            // 
            this.Bt_Fin.BackgroundImage = global::Eval_Proveedores.Properties.Resources.Fin2;
            this.Bt_Fin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Bt_Fin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Bt_Fin.ForeColor = System.Drawing.SystemColors.Control;
            this.Bt_Fin.Location = new System.Drawing.Point(9, 342);
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
            this.BT_Eliminar.Location = new System.Drawing.Point(8, 269);
            this.BT_Eliminar.Name = "BT_Eliminar";
            this.BT_Eliminar.Size = new System.Drawing.Size(55, 70);
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
            this.BTModifEvaluacion.Location = new System.Drawing.Point(7, 203);
            this.BTModifEvaluacion.Margin = new System.Windows.Forms.Padding(0);
            this.BTModifEvaluacion.Name = "BTModifEvaluacion";
            this.BTModifEvaluacion.Size = new System.Drawing.Size(56, 60);
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
            this.BTAgregarEvaluacion.Location = new System.Drawing.Point(5, 129);
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
            // InicEvaluacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(844, 452);
            this.Controls.Add(this.Bt_Fin);
            this.Controls.Add(this.BT_Eliminar);
            this.Controls.Add(this.BTModifEvaluacion);
            this.Controls.Add(this.BTAgregarEvaluacion);
            this.Controls.Add(this.DGV_Evaluaciones);
            this.Controls.Add(this.P_Verde);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(860, 490);
            this.MinimumSize = new System.Drawing.Size(860, 490);
            this.Name = "InicEvaluacion";
            this.Load += new System.EventHandler(this.InicEvaluacion_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.P_Verde.ResumeLayout(false);
            this.PProve.ResumeLayout(false);
            this.PProve.PerformLayout();
            this.P_Filtrado.ResumeLayout(false);
            this.P_Filtrado.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Evaluaciones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.evaluaGenBindingSource)).EndInit();
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
        private System.Windows.Forms.DataGridViewTextBoxColumn claveDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn proveedorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombProve;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estado;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DescTipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn periodoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DescPer;
        private System.Windows.Forms.DataGridViewTextBoxColumn Observ;
        private System.Windows.Forms.DataGridViewTextBoxColumn mesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn PromedioTot;
        private System.Windows.Forms.DataGridViewTextBoxColumn añoDataGridViewTextBoxColumn;
        private System.Windows.Forms.Panel PProve;
        private System.Windows.Forms.Button BT_Filtrar2;
        private System.Windows.Forms.TextBox TB_Filtro2;
        private System.Windows.Forms.Label LB_Prove;
        private System.Windows.Forms.ComboBox CB_Tipo;
    }
}