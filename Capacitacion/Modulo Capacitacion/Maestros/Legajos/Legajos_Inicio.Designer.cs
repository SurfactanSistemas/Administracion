namespace Modulo_Capacitacion.Maestros.Legajos
{
    partial class Legajos_Inicio
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.DGV_Legajos = new System.Windows.Forms.DataGridView();
            this.Clave = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Vigencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sector = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Perfil = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.P_Verde = new System.Windows.Forms.Panel();
            this.P_Filtrado = new System.Windows.Forms.Panel();
            this.TBFiltro = new System.Windows.Forms.TextBox();
            this.LBFiltro = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Bt_Fin = new System.Windows.Forms.Button();
            this.BT_Eliminar = new System.Windows.Forms.Button();
            this.BTModifLegajo = new System.Windows.Forms.Button();
            this.BTAgregarLegajo = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.legajoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Legajos)).BeginInit();
            this.P_Verde.SuspendLayout();
            this.P_Filtrado.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.legajoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // DGV_Legajos
            // 
            this.DGV_Legajos.AllowUserToAddRows = false;
            this.DGV_Legajos.AllowUserToDeleteRows = false;
            this.DGV_Legajos.AllowUserToResizeRows = false;
            this.DGV_Legajos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.DGV_Legajos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.DGV_Legajos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.DGV_Legajos.ColumnHeadersHeight = 34;
            this.DGV_Legajos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Clave,
            this.Codigo,
            this.Descripcion,
            this.Vigencia,
            this.Sector,
            this.Perfil});
            this.DGV_Legajos.Location = new System.Drawing.Point(85, 0);
            this.DGV_Legajos.Margin = new System.Windows.Forms.Padding(0);
            this.DGV_Legajos.Name = "DGV_Legajos";
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGV_Legajos.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.DGV_Legajos.Size = new System.Drawing.Size(622, 326);
            this.DGV_Legajos.TabIndex = 26;
            this.DGV_Legajos.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DGV_Perfiles_RowHeaderMouseDoubleClick);
            // 
            // Clave
            // 
            this.Clave.DataPropertyName = "Clave";
            this.Clave.HeaderText = "Clave";
            this.Clave.Name = "Clave";
            this.Clave.Visible = false;
            this.Clave.Width = 59;
            // 
            // Codigo
            // 
            this.Codigo.DataPropertyName = "Codigo";
            this.Codigo.HeaderText = "Codigo";
            this.Codigo.Name = "Codigo";
            this.Codigo.Visible = false;
            this.Codigo.Width = 65;
            // 
            // Descripcion
            // 
            this.Descripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Descripcion.DataPropertyName = "Descripcion";
            this.Descripcion.HeaderText = "Nombre de Empleado";
            this.Descripcion.Name = "Descripcion";
            // 
            // Vigencia
            // 
            this.Vigencia.DataPropertyName = "Vigencia";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Vigencia.DefaultCellStyle = dataGridViewCellStyle3;
            this.Vigencia.HeaderText = "Vigencia";
            this.Vigencia.Name = "Vigencia";
            this.Vigencia.Width = 73;
            // 
            // Sector
            // 
            this.Sector.DataPropertyName = "Sector";
            this.Sector.HeaderText = "Sector";
            this.Sector.Name = "Sector";
            this.Sector.Width = 63;
            // 
            // Perfil
            // 
            this.Perfil.DataPropertyName = "Perfil";
            this.Perfil.HeaderText = "Perfil";
            this.Perfil.Name = "Perfil";
            this.Perfil.Width = 55;
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
            this.P_Verde.Size = new System.Drawing.Size(707, 59);
            this.P_Verde.TabIndex = 21;
            // 
            // P_Filtrado
            // 
            this.P_Filtrado.Controls.Add(this.TBFiltro);
            this.P_Filtrado.Controls.Add(this.LBFiltro);
            this.P_Filtrado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.P_Filtrado.Location = new System.Drawing.Point(0, 0);
            this.P_Filtrado.Margin = new System.Windows.Forms.Padding(0);
            this.P_Filtrado.Name = "P_Filtrado";
            this.P_Filtrado.Size = new System.Drawing.Size(707, 59);
            this.P_Filtrado.TabIndex = 1;
            // 
            // TBFiltro
            // 
            this.TBFiltro.Location = new System.Drawing.Point(149, 17);
            this.TBFiltro.Name = "TBFiltro";
            this.TBFiltro.Size = new System.Drawing.Size(537, 20);
            this.TBFiltro.TabIndex = 1;
            this.TBFiltro.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TBFiltro_KeyDown);
            this.TBFiltro.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TBFiltro_KeyUp);
            // 
            // LBFiltro
            // 
            this.LBFiltro.AutoSize = true;
            this.LBFiltro.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBFiltro.ForeColor = System.Drawing.Color.White;
            this.LBFiltro.Location = new System.Drawing.Point(94, 17);
            this.LBFiltro.Name = "LBFiltro";
            this.LBFiltro.Size = new System.Drawing.Size(49, 18);
            this.LBFiltro.TabIndex = 0;
            this.LBFiltro.Text = "Filtrar:";
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
            this.panel1.Size = new System.Drawing.Size(707, 39);
            this.panel1.TabIndex = 20;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(9, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "LEGAJOS";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(543, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "SURFACTAN S.A.";
            // 
            // Bt_Fin
            // 
            this.Bt_Fin.BackgroundImage = global::Modulo_Capacitacion.Properties.Resources.apagar;
            this.Bt_Fin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Bt_Fin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Bt_Fin.ForeColor = System.Drawing.SystemColors.Control;
            this.Bt_Fin.Location = new System.Drawing.Point(16, 259);
            this.Bt_Fin.Margin = new System.Windows.Forms.Padding(0);
            this.Bt_Fin.Name = "Bt_Fin";
            this.Bt_Fin.Size = new System.Drawing.Size(47, 53);
            this.Bt_Fin.TabIndex = 25;
            this.Bt_Fin.UseVisualStyleBackColor = true;
            this.Bt_Fin.Click += new System.EventHandler(this.Bt_Fin_Click);
            // 
            // BT_Eliminar
            // 
            this.BT_Eliminar.BackgroundImage = global::Modulo_Capacitacion.Properties.Resources.eliminar;
            this.BT_Eliminar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BT_Eliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BT_Eliminar.ForeColor = System.Drawing.SystemColors.Control;
            this.BT_Eliminar.Location = new System.Drawing.Point(14, 173);
            this.BT_Eliminar.Name = "BT_Eliminar";
            this.BT_Eliminar.Size = new System.Drawing.Size(50, 70);
            this.BT_Eliminar.TabIndex = 24;
            this.BT_Eliminar.UseVisualStyleBackColor = true;
            this.BT_Eliminar.Click += new System.EventHandler(this.BT_Eliminar_Click);
            // 
            // BTModifLegajo
            // 
            this.BTModifLegajo.BackgroundImage = global::Modulo_Capacitacion.Properties.Resources.editar_legajo;
            this.BTModifLegajo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BTModifLegajo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTModifLegajo.ForeColor = System.Drawing.SystemColors.Control;
            this.BTModifLegajo.Location = new System.Drawing.Point(16, 104);
            this.BTModifLegajo.Margin = new System.Windows.Forms.Padding(0);
            this.BTModifLegajo.Name = "BTModifLegajo";
            this.BTModifLegajo.Size = new System.Drawing.Size(47, 53);
            this.BTModifLegajo.TabIndex = 23;
            this.BTModifLegajo.UseVisualStyleBackColor = true;
            this.BTModifLegajo.Click += new System.EventHandler(this.BTModifLegajo_Click);
            // 
            // BTAgregarLegajo
            // 
            this.BTAgregarLegajo.BackgroundImage = global::Modulo_Capacitacion.Properties.Resources.agregar_legajo;
            this.BTAgregarLegajo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BTAgregarLegajo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTAgregarLegajo.ForeColor = System.Drawing.SystemColors.Control;
            this.BTAgregarLegajo.Location = new System.Drawing.Point(11, 14);
            this.BTAgregarLegajo.Name = "BTAgregarLegajo";
            this.BTAgregarLegajo.Size = new System.Drawing.Size(56, 74);
            this.BTAgregarLegajo.TabIndex = 22;
            this.BTAgregarLegajo.UseVisualStyleBackColor = true;
            this.BTAgregarLegajo.Click += new System.EventHandler(this.BTAgregarLegajo_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.P_Verde, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 59F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(707, 424);
            this.tableLayoutPanel1.TabIndex = 27;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.DGV_Legajos, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 98);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(707, 326);
            this.tableLayoutPanel2.TabIndex = 22;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.BTAgregarLegajo);
            this.panel2.Controls.Add(this.BTModifLegajo);
            this.panel2.Controls.Add(this.BT_Eliminar);
            this.panel2.Controls.Add(this.Bt_Fin);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(79, 320);
            this.panel2.TabIndex = 0;
            // 
            // legajoBindingSource
            // 
            this.legajoBindingSource.DataSource = typeof(Negocio.Legajo);
            // 
            // Legajos_Inicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(707, 424);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MinimumSize = new System.Drawing.Size(723, 462);
            this.Name = "Legajos_Inicio";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Shown += new System.EventHandler(this.Legajos_Inicio_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Legajos)).EndInit();
            this.P_Verde.ResumeLayout(false);
            this.P_Filtrado.ResumeLayout(false);
            this.P_Filtrado.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.legajoBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DGV_Legajos;
        private System.Windows.Forms.Button Bt_Fin;
        private System.Windows.Forms.Button BT_Eliminar;
        private System.Windows.Forms.Button BTModifLegajo;
        private System.Windows.Forms.Button BTAgregarLegajo;
        private System.Windows.Forms.Panel P_Verde;
        private System.Windows.Forms.Panel P_Filtrado;
        private System.Windows.Forms.TextBox TBFiltro;
        private System.Windows.Forms.Label LBFiltro;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource legajoBindingSource;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Clave;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Vigencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sector;
        private System.Windows.Forms.DataGridViewTextBoxColumn Perfil;
    }
}