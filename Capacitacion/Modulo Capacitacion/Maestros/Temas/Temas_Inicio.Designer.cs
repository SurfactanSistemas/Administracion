namespace Modulo_Capacitacion.Maestros.Temas
{
    partial class Temas_Inicio
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.P_Verde = new System.Windows.Forms.Panel();
            this.P_Filtrado = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TBFiltro = new System.Windows.Forms.TextBox();
            this.DGV_Temas = new System.Windows.Forms.DataGridView();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TemaI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TemaII = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TemaIII = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Responsable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Horas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ResponsableI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ResponsableII = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ResponsableIV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.BTAgregarTema = new System.Windows.Forms.Button();
            this.BTModifTema = new System.Windows.Forms.Button();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.BT_Eliminar = new System.Windows.Forms.Button();
            this.Bt_Fin = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.P_Verde.SuspendLayout();
            this.P_Filtrado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Temas)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(74)))), ((int)(((byte)(95)))));
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1081, 39);
            this.panel1.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(9, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "TEMAS";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(927, 5);
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
            this.P_Verde.Location = new System.Drawing.Point(0, 39);
            this.P_Verde.Margin = new System.Windows.Forms.Padding(0);
            this.P_Verde.Name = "P_Verde";
            this.P_Verde.Size = new System.Drawing.Size(1081, 52);
            this.P_Verde.TabIndex = 5;
            // 
            // P_Filtrado
            // 
            this.P_Filtrado.Controls.Add(this.button1);
            this.P_Filtrado.Controls.Add(this.label4);
            this.P_Filtrado.Controls.Add(this.txtCodigo);
            this.P_Filtrado.Controls.Add(this.label3);
            this.P_Filtrado.Controls.Add(this.TBFiltro);
            this.P_Filtrado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.P_Filtrado.Location = new System.Drawing.Point(0, 0);
            this.P_Filtrado.Margin = new System.Windows.Forms.Padding(0);
            this.P_Filtrado.Name = "P_Filtrado";
            this.P_Filtrado.Size = new System.Drawing.Size(1081, 52);
            this.P_Filtrado.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.Control;
            this.label4.Location = new System.Drawing.Point(183, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 16);
            this.label4.TabIndex = 2;
            this.label4.Text = "Filtrar:";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(241, 17);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(66, 20);
            this.txtCodigo.TabIndex = 1;
            this.txtCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCodigo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodigo_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(356, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Filtrar:";
            // 
            // TBFiltro
            // 
            this.TBFiltro.Location = new System.Drawing.Point(414, 17);
            this.TBFiltro.Name = "TBFiltro";
            this.TBFiltro.Size = new System.Drawing.Size(380, 20);
            this.TBFiltro.TabIndex = 1;
            this.TBFiltro.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TBFiltro_KeyUp);
            // 
            // DGV_Temas
            // 
            this.DGV_Temas.AllowUserToAddRows = false;
            this.DGV_Temas.AllowUserToDeleteRows = false;
            this.DGV_Temas.AllowUserToResizeRows = false;
            this.DGV_Temas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.DGV_Temas.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.DGV_Temas.ColumnHeadersHeight = 30;
            this.DGV_Temas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Codigo,
            this.Descripcion,
            this.TemaI,
            this.TemaII,
            this.TemaIII,
            this.Responsable,
            this.Horas,
            this.Tipo,
            this.ResponsableI,
            this.ResponsableII,
            this.ResponsableIV});
            this.DGV_Temas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGV_Temas.Location = new System.Drawing.Point(96, 0);
            this.DGV_Temas.Margin = new System.Windows.Forms.Padding(0);
            this.DGV_Temas.Name = "DGV_Temas";
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.DGV_Temas.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.DGV_Temas.RowHeadersWidth = 15;
            this.DGV_Temas.Size = new System.Drawing.Size(985, 413);
            this.DGV_Temas.TabIndex = 6;
            this.DGV_Temas.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DGV_Temas_RowHeaderMouseDoubleClick);
            // 
            // Codigo
            // 
            this.Codigo.DataPropertyName = "Codigo";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Codigo.DefaultCellStyle = dataGridViewCellStyle1;
            this.Codigo.HeaderText = "Codigo";
            this.Codigo.Name = "Codigo";
            this.Codigo.Width = 65;
            // 
            // Descripcion
            // 
            this.Descripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Descripcion.DataPropertyName = "Descripcion";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.Descripcion.DefaultCellStyle = dataGridViewCellStyle2;
            this.Descripcion.HeaderText = "Descripcion";
            this.Descripcion.Name = "Descripcion";
            // 
            // TemaI
            // 
            this.TemaI.DataPropertyName = "TemaI";
            this.TemaI.HeaderText = "Detalle";
            this.TemaI.Name = "TemaI";
            this.TemaI.Width = 65;
            // 
            // TemaII
            // 
            this.TemaII.DataPropertyName = "TemaII";
            this.TemaII.HeaderText = "DetalleII";
            this.TemaII.Name = "TemaII";
            this.TemaII.Visible = false;
            this.TemaII.Width = 71;
            // 
            // TemaIII
            // 
            this.TemaIII.DataPropertyName = "TemaIII";
            this.TemaIII.HeaderText = "DetalleIII";
            this.TemaIII.Name = "TemaIII";
            this.TemaIII.Visible = false;
            this.TemaIII.Width = 74;
            // 
            // Responsable
            // 
            this.Responsable.DataPropertyName = "Responsable";
            this.Responsable.HeaderText = "Responsable";
            this.Responsable.Name = "Responsable";
            this.Responsable.Width = 94;
            // 
            // Horas
            // 
            this.Horas.DataPropertyName = "Horas";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Horas.DefaultCellStyle = dataGridViewCellStyle3;
            this.Horas.HeaderText = "Horas";
            this.Horas.Name = "Horas";
            this.Horas.Visible = false;
            this.Horas.Width = 60;
            // 
            // Tipo
            // 
            this.Tipo.DataPropertyName = "Tipo";
            this.Tipo.HeaderText = "Tipo";
            this.Tipo.Name = "Tipo";
            this.Tipo.Visible = false;
            this.Tipo.Width = 53;
            // 
            // ResponsableI
            // 
            this.ResponsableI.DataPropertyName = "ResponsableII";
            this.ResponsableI.HeaderText = "ResponsableI";
            this.ResponsableI.Name = "ResponsableI";
            this.ResponsableI.Visible = false;
            this.ResponsableI.Width = 97;
            // 
            // ResponsableII
            // 
            this.ResponsableII.DataPropertyName = "ResponsableIII";
            this.ResponsableII.HeaderText = "ResponsableII";
            this.ResponsableII.Name = "ResponsableII";
            this.ResponsableII.Visible = false;
            // 
            // ResponsableIV
            // 
            this.ResponsableIV.DataPropertyName = "ResponsableIV";
            this.ResponsableIV.HeaderText = "ResponsableIV";
            this.ResponsableIV.Name = "ResponsableIV";
            this.ResponsableIV.Visible = false;
            this.ResponsableIV.Width = 104;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.P_Verde, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 52F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1081, 504);
            this.tableLayoutPanel1.TabIndex = 18;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 96F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.DGV_Temas, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 91);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1081, 413);
            this.tableLayoutPanel2.TabIndex = 6;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.BTAgregarTema);
            this.panel2.Controls.Add(this.BTModifTema);
            this.panel2.Controls.Add(this.btnImprimir);
            this.panel2.Controls.Add(this.BT_Eliminar);
            this.panel2.Controls.Add(this.Bt_Fin);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(96, 413);
            this.panel2.TabIndex = 0;
            // 
            // BTAgregarTema
            // 
            this.BTAgregarTema.BackgroundImage = global::Modulo_Capacitacion.Properties.Resources.agregar_temas;
            this.BTAgregarTema.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BTAgregarTema.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTAgregarTema.ForeColor = System.Drawing.SystemColors.Control;
            this.BTAgregarTema.Location = new System.Drawing.Point(21, 34);
            this.BTAgregarTema.Name = "BTAgregarTema";
            this.BTAgregarTema.Size = new System.Drawing.Size(55, 67);
            this.BTAgregarTema.TabIndex = 7;
            this.BTAgregarTema.UseVisualStyleBackColor = true;
            this.BTAgregarTema.Click += new System.EventHandler(this.BTAgregarTema_Click);
            // 
            // BTModifTema
            // 
            this.BTModifTema.BackgroundImage = global::Modulo_Capacitacion.Properties.Resources.editar_temas;
            this.BTModifTema.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BTModifTema.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTModifTema.ForeColor = System.Drawing.SystemColors.Control;
            this.BTModifTema.Location = new System.Drawing.Point(21, 116);
            this.BTModifTema.Margin = new System.Windows.Forms.Padding(0);
            this.BTModifTema.Name = "BTModifTema";
            this.BTModifTema.Size = new System.Drawing.Size(55, 67);
            this.BTModifTema.TabIndex = 15;
            this.BTModifTema.UseVisualStyleBackColor = true;
            this.BTModifTema.Click += new System.EventHandler(this.BTModifTema_Click);
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackgroundImage = global::Modulo_Capacitacion.Properties.Resources.imprimir;
            this.btnImprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImprimir.ForeColor = System.Drawing.SystemColors.Control;
            this.btnImprimir.Location = new System.Drawing.Point(21, 276);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(55, 67);
            this.btnImprimir.TabIndex = 16;
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // BT_Eliminar
            // 
            this.BT_Eliminar.BackgroundImage = global::Modulo_Capacitacion.Properties.Resources.eliminar;
            this.BT_Eliminar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BT_Eliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BT_Eliminar.ForeColor = System.Drawing.SystemColors.Control;
            this.BT_Eliminar.Location = new System.Drawing.Point(21, 200);
            this.BT_Eliminar.Name = "BT_Eliminar";
            this.BT_Eliminar.Size = new System.Drawing.Size(55, 67);
            this.BT_Eliminar.TabIndex = 16;
            this.BT_Eliminar.UseVisualStyleBackColor = true;
            this.BT_Eliminar.Click += new System.EventHandler(this.BT_Eliminar_Click);
            // 
            // Bt_Fin
            // 
            this.Bt_Fin.BackgroundImage = global::Modulo_Capacitacion.Properties.Resources.apagar;
            this.Bt_Fin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Bt_Fin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Bt_Fin.ForeColor = System.Drawing.SystemColors.Control;
            this.Bt_Fin.Location = new System.Drawing.Point(21, 346);
            this.Bt_Fin.Margin = new System.Windows.Forms.Padding(0);
            this.Bt_Fin.Name = "Bt_Fin";
            this.Bt_Fin.Size = new System.Drawing.Size(55, 67);
            this.Bt_Fin.TabIndex = 17;
            this.Bt_Fin.UseVisualStyleBackColor = true;
            this.Bt_Fin.Click += new System.EventHandler(this.Bt_Fin_Click);
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.SystemColors.Control;
            this.button1.Location = new System.Drawing.Point(800, 14);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 24);
            this.button1.TabIndex = 3;
            this.button1.Text = "Limpiar Filtro";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Temas_Inicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1081, 504);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Temas_Inicio";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Temas_Inicio_Load);
            this.Shown += new System.EventHandler(this.Temas_Inicio_Shown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.P_Verde.ResumeLayout(false);
            this.P_Filtrado.ResumeLayout(false);
            this.P_Filtrado.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Temas)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel P_Verde;
        private System.Windows.Forms.Panel P_Filtrado;
        private System.Windows.Forms.TextBox TBFiltro;
        private System.Windows.Forms.DataGridView DGV_Temas;
        private System.Windows.Forms.Button BTAgregarTema;
        private System.Windows.Forms.Button Bt_Fin;
        private System.Windows.Forms.Button BT_Eliminar;
        private System.Windows.Forms.Button BTModifTema;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn TemaI;
        private System.Windows.Forms.DataGridViewTextBoxColumn TemaII;
        private System.Windows.Forms.DataGridViewTextBoxColumn TemaIII;
        private System.Windows.Forms.DataGridViewTextBoxColumn Responsable;
        private System.Windows.Forms.DataGridViewTextBoxColumn Horas;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ResponsableI;
        private System.Windows.Forms.DataGridViewTextBoxColumn ResponsableII;
        private System.Windows.Forms.DataGridViewTextBoxColumn ResponsableIV;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Button button1;
    }
}