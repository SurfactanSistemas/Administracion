namespace Eval_Proveedores.Listados.ListadoEvaluacionProvMPFarma
{
    partial class ListadoEvaluacionesProveedoreMPFarma
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dgvProveedores = new Util.DBDataGridView();
            this.Listar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Proveedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtFiltrar = new System.Windows.Forms.TextBox();
            this.rbEvalVencida = new System.Windows.Forms.RadioButton();
            this.rbSinEvaluar = new System.Windows.Forms.RadioButton();
            this.rbListadoCompleto = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rbFichaCompleta = new System.Windows.Forms.RadioButton();
            this.rbResumido = new System.Windows.Forms.RadioButton();
            this.btnPantalla = new System.Windows.Forms.Button();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnExportar = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.Panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProveedores)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // Panel1
            // 
            this.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(74)))), ((int)(((byte)(95)))));
            this.Panel1.Controls.Add(this.Label2);
            this.Panel1.Controls.Add(this.Label1);
            this.Panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel1.Location = new System.Drawing.Point(0, 0);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(551, 50);
            this.Panel1.TabIndex = 52;
            // 
            // Label2
            // 
            this.Label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.ForeColor = System.Drawing.SystemColors.Control;
            this.Label2.Location = new System.Drawing.Point(375, 12);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(156, 26);
            this.Label2.TabIndex = 1;
            this.Label2.Text = "SURFACTAN S.A.";
            // 
            // Label1
            // 
            this.Label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.SystemColors.Control;
            this.Label1.Location = new System.Drawing.Point(19, 17);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(247, 17);
            this.Label1.TabIndex = 0;
            this.Label1.Text = "LISTADO EVAL. PROVEEDORES MP FARMA";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Location = new System.Drawing.Point(9, 56);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(532, 338);
            this.groupBox1.TabIndex = 53;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "PARÁMETROS";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dgvProveedores);
            this.groupBox4.Controls.Add(this.txtFiltrar);
            this.groupBox4.Controls.Add(this.rbEvalVencida);
            this.groupBox4.Controls.Add(this.rbSinEvaluar);
            this.groupBox4.Controls.Add(this.rbListadoCompleto);
            this.groupBox4.Location = new System.Drawing.Point(10, 78);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(7);
            this.groupBox4.Size = new System.Drawing.Size(512, 246);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "TIPO DE LISTADO";
            // 
            // dgvProveedores
            // 
            this.dgvProveedores.AllowUserToAddRows = false;
            this.dgvProveedores.AllowUserToDeleteRows = false;
            this.dgvProveedores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProveedores.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Listar,
            this.Proveedor,
            this.Nombre});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(217)))), ((int)(((byte)(232)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(170)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvProveedores.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvProveedores.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvProveedores.DoubleBuffered = true;
            this.dgvProveedores.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvProveedores.Location = new System.Drawing.Point(7, 95);
            this.dgvProveedores.Name = "dgvProveedores";
            this.dgvProveedores.ReadOnly = true;
            this.dgvProveedores.RowHeadersWidth = 15;
            this.dgvProveedores.RowTemplate.Height = 18;
            this.dgvProveedores.ShowCellToolTips = false;
            this.dgvProveedores.SinClickDerecho = false;
            this.dgvProveedores.Size = new System.Drawing.Size(498, 144);
            this.dgvProveedores.TabIndex = 3;
            this.dgvProveedores.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvProveedores_CellMouseClick);
            // 
            // Listar
            // 
            this.Listar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Listar.DataPropertyName = "Listar";
            this.Listar.HeaderText = "";
            this.Listar.Name = "Listar";
            this.Listar.ReadOnly = true;
            this.Listar.Width = 5;
            // 
            // Proveedor
            // 
            this.Proveedor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Proveedor.DataPropertyName = "Proveedor";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Proveedor.DefaultCellStyle = dataGridViewCellStyle1;
            this.Proveedor.HeaderText = "Proveedor";
            this.Proveedor.Name = "Proveedor";
            this.Proveedor.ReadOnly = true;
            this.Proveedor.Width = 81;
            // 
            // Nombre
            // 
            this.Nombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Nombre.DataPropertyName = "Nombre";
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            // 
            // txtFiltrar
            // 
            this.txtFiltrar.Location = new System.Drawing.Point(7, 69);
            this.txtFiltrar.Name = "txtFiltrar";
            this.txtFiltrar.Size = new System.Drawing.Size(498, 20);
            this.txtFiltrar.TabIndex = 2;
            this.txtFiltrar.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtFiltrar_KeyUp);
            // 
            // rbEvalVencida
            // 
            this.rbEvalVencida.AutoSize = true;
            this.rbEvalVencida.Location = new System.Drawing.Point(308, 29);
            this.rbEvalVencida.Name = "rbEvalVencida";
            this.rbEvalVencida.Size = new System.Drawing.Size(163, 17);
            this.rbEvalVencida.TabIndex = 0;
            this.rbEvalVencida.Text = "SÓLO CON EVAL. VENCIDA";
            this.rbEvalVencida.UseVisualStyleBackColor = true;
            this.rbEvalVencida.Click += new System.EventHandler(this.rbListadoCompleto_Click);
            // 
            // rbSinEvaluar
            // 
            this.rbSinEvaluar.AutoSize = true;
            this.rbSinEvaluar.Location = new System.Drawing.Point(148, 29);
            this.rbSinEvaluar.Name = "rbSinEvaluar";
            this.rbSinEvaluar.Size = new System.Drawing.Size(128, 17);
            this.rbSinEvaluar.TabIndex = 0;
            this.rbSinEvaluar.Text = "SÓLO SIN EVALUAR";
            this.rbSinEvaluar.UseVisualStyleBackColor = true;
            this.rbSinEvaluar.Click += new System.EventHandler(this.rbListadoCompleto_Click);
            // 
            // rbListadoCompleto
            // 
            this.rbListadoCompleto.AutoSize = true;
            this.rbListadoCompleto.Checked = true;
            this.rbListadoCompleto.Location = new System.Drawing.Point(32, 29);
            this.rbListadoCompleto.Name = "rbListadoCompleto";
            this.rbListadoCompleto.Size = new System.Drawing.Size(84, 17);
            this.rbListadoCompleto.TabIndex = 0;
            this.rbListadoCompleto.TabStop = true;
            this.rbListadoCompleto.Text = "COMPLETO";
            this.rbListadoCompleto.UseVisualStyleBackColor = true;
            this.rbListadoCompleto.Click += new System.EventHandler(this.rbListadoCompleto_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rbFichaCompleta);
            this.groupBox3.Controls.Add(this.rbResumido);
            this.groupBox3.Location = new System.Drawing.Point(10, 19);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(513, 53);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "TIPO DE LISTADO";
            // 
            // rbFichaCompleta
            // 
            this.rbFichaCompleta.AutoSize = true;
            this.rbFichaCompleta.Location = new System.Drawing.Point(238, 21);
            this.rbFichaCompleta.Name = "rbFichaCompleta";
            this.rbFichaCompleta.Size = new System.Drawing.Size(233, 17);
            this.rbFichaCompleta.TabIndex = 0;
            this.rbFichaCompleta.Text = "FICHA COMPLETA MP POR PROVEEDOR";
            this.rbFichaCompleta.UseVisualStyleBackColor = true;
            // 
            // rbResumido
            // 
            this.rbResumido.AutoSize = true;
            this.rbResumido.Checked = true;
            this.rbResumido.Location = new System.Drawing.Point(24, 21);
            this.rbResumido.Name = "rbResumido";
            this.rbResumido.Size = new System.Drawing.Size(209, 17);
            this.rbResumido.TabIndex = 0;
            this.rbResumido.TabStop = true;
            this.rbResumido.Text = "RESUMIDO POR MP Y PROVEEDOR";
            this.rbResumido.UseVisualStyleBackColor = true;
            // 
            // btnPantalla
            // 
            this.btnPantalla.Location = new System.Drawing.Point(28, 408);
            this.btnPantalla.Name = "btnPantalla";
            this.btnPantalla.Size = new System.Drawing.Size(107, 43);
            this.btnPantalla.TabIndex = 54;
            this.btnPantalla.Text = "MOSTRAR POR PANTALLA";
            this.btnPantalla.UseVisualStyleBackColor = true;
            this.btnPantalla.Click += new System.EventHandler(this.btnPantalla_Click);
            // 
            // btnImprimir
            // 
            this.btnImprimir.Location = new System.Drawing.Point(157, 408);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(107, 43);
            this.btnImprimir.TabIndex = 54;
            this.btnImprimir.Text = "IMPRIMIR";
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(415, 408);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(107, 43);
            this.btnCerrar.TabIndex = 54;
            this.btnCerrar.Text = "CERRAR";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // btnExportar
            // 
            this.btnExportar.Location = new System.Drawing.Point(286, 408);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(107, 43);
            this.btnExportar.TabIndex = 54;
            this.btnExportar.Text = "EXPORTAR";
            this.btnExportar.UseVisualStyleBackColor = true;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // ListadoEvaluacionesProveedoreMPFarma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(551, 463);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.btnExportar);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.btnPantalla);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Panel1);
            this.MaximizeBox = false;
            this.Name = "ListadoEvaluacionesProveedoreMPFarma";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.ListadoEvaluacionesProveedoreMPFarma_Load);
            this.Panel1.ResumeLayout(false);
            this.Panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProveedores)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Panel Panel1;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbListadoCompleto;
        private System.Windows.Forms.RadioButton rbEvalVencida;
        private System.Windows.Forms.RadioButton rbSinEvaluar;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rbFichaCompleta;
        private System.Windows.Forms.RadioButton rbResumido;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtFiltrar;
        private System.Windows.Forms.Button btnPantalla;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Button btnCerrar;
        private Util.DBDataGridView dgvProveedores;
        private System.Windows.Forms.Button btnExportar;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Listar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Proveedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
    }
}