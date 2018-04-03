namespace Modulo_Capacitacion.Maestros.Perfiles
{
    partial class Perfiles_Inicio
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
            this.P_Filtrado = new System.Windows.Forms.Panel();
            this.BT_Filtrar = new System.Windows.Forms.Button();
            this.TBFiltro = new System.Windows.Forms.TextBox();
            this.LBFiltro = new System.Windows.Forms.Label();
            this.BT_MenuFiltros = new System.Windows.Forms.Button();
            this.Bt_Fin = new System.Windows.Forms.Button();
            this.BT_Eliminar = new System.Windows.Forms.Button();
            this.BTModifSector = new System.Windows.Forms.Button();
            this.BTAgregarPerfil = new System.Windows.Forms.Button();
            this.CMS_Perfil = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.descripcionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.versionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.codigoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sectorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.temasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.perfilBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DGV_Perfiles = new System.Windows.Forms.DataGridView();
            this.perfilBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.panel1.SuspendLayout();
            this.P_Verde.SuspendLayout();
            this.P_Filtrado.SuspendLayout();
            this.CMS_Perfil.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.temasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.perfilBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Perfiles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.perfilBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(74)))), ((int)(((byte)(95)))));
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(1, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(737, 39);
            this.panel1.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(9, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "PERFILES";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(568, 6);
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
            this.P_Verde.Location = new System.Drawing.Point(0, 37);
            this.P_Verde.Name = "P_Verde";
            this.P_Verde.Size = new System.Drawing.Size(741, 55);
            this.P_Verde.TabIndex = 5;
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
            // Bt_Fin
            // 
            this.Bt_Fin.BackgroundImage = global::Modulo_Capacitacion.Properties.Resources.apagar;
            this.Bt_Fin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Bt_Fin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Bt_Fin.ForeColor = System.Drawing.SystemColors.Control;
            this.Bt_Fin.Location = new System.Drawing.Point(15, 388);
            this.Bt_Fin.Margin = new System.Windows.Forms.Padding(0);
            this.Bt_Fin.Name = "Bt_Fin";
            this.Bt_Fin.Size = new System.Drawing.Size(47, 53);
            this.Bt_Fin.TabIndex = 18;
            this.Bt_Fin.UseVisualStyleBackColor = true;
            this.Bt_Fin.Click += new System.EventHandler(this.Bt_Fin_Click);
            // 
            // BT_Eliminar
            // 
            this.BT_Eliminar.BackgroundImage = global::Modulo_Capacitacion.Properties.Resources.eliminar;
            this.BT_Eliminar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BT_Eliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BT_Eliminar.ForeColor = System.Drawing.SystemColors.Control;
            this.BT_Eliminar.Location = new System.Drawing.Point(14, 294);
            this.BT_Eliminar.Name = "BT_Eliminar";
            this.BT_Eliminar.Size = new System.Drawing.Size(50, 70);
            this.BT_Eliminar.TabIndex = 17;
            this.BT_Eliminar.UseVisualStyleBackColor = true;
            this.BT_Eliminar.Click += new System.EventHandler(this.BT_Eliminar_Click);
            // 
            // BTModifSector
            // 
            this.BTModifSector.BackgroundImage = global::Modulo_Capacitacion.Properties.Resources.editar_perfiles;
            this.BTModifSector.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BTModifSector.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTModifSector.ForeColor = System.Drawing.SystemColors.Control;
            this.BTModifSector.Location = new System.Drawing.Point(9, 209);
            this.BTModifSector.Margin = new System.Windows.Forms.Padding(0);
            this.BTModifSector.Name = "BTModifSector";
            this.BTModifSector.Size = new System.Drawing.Size(47, 53);
            this.BTModifSector.TabIndex = 16;
            this.BTModifSector.UseVisualStyleBackColor = true;
            this.BTModifSector.Click += new System.EventHandler(this.BTModifSector_Click);
            // 
            // BTAgregarPerfil
            // 
            this.BTAgregarPerfil.BackgroundImage = global::Modulo_Capacitacion.Properties.Resources.agregar_perfiles;
            this.BTAgregarPerfil.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BTAgregarPerfil.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTAgregarPerfil.ForeColor = System.Drawing.SystemColors.Control;
            this.BTAgregarPerfil.Location = new System.Drawing.Point(15, 110);
            this.BTAgregarPerfil.Name = "BTAgregarPerfil";
            this.BTAgregarPerfil.Size = new System.Drawing.Size(50, 64);
            this.BTAgregarPerfil.TabIndex = 15;
            this.BTAgregarPerfil.UseVisualStyleBackColor = true;
            this.BTAgregarPerfil.Click += new System.EventHandler(this.BTAgregarPerfil_Click);
            // 
            // CMS_Perfil
            // 
            this.CMS_Perfil.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.descripcionToolStripMenuItem,
            this.versionToolStripMenuItem,
            this.codigoToolStripMenuItem,
            this.sectorToolStripMenuItem});
            this.CMS_Perfil.Name = "CMS_Perfil";
            this.CMS_Perfil.Size = new System.Drawing.Size(137, 92);
            // 
            // descripcionToolStripMenuItem
            // 
            this.descripcionToolStripMenuItem.Name = "descripcionToolStripMenuItem";
            this.descripcionToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.descripcionToolStripMenuItem.Text = "Descripcion";
            this.descripcionToolStripMenuItem.Click += new System.EventHandler(this.descripcionToolStripMenuItem_Click);
            // 
            // versionToolStripMenuItem
            // 
            this.versionToolStripMenuItem.Name = "versionToolStripMenuItem";
            this.versionToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.versionToolStripMenuItem.Text = "Version";
            this.versionToolStripMenuItem.Click += new System.EventHandler(this.versionToolStripMenuItem_Click);
            // 
            // codigoToolStripMenuItem
            // 
            this.codigoToolStripMenuItem.Name = "codigoToolStripMenuItem";
            this.codigoToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.codigoToolStripMenuItem.Text = "Codigo";
            this.codigoToolStripMenuItem.Click += new System.EventHandler(this.codigoToolStripMenuItem_Click);
            // 
            // sectorToolStripMenuItem
            // 
            this.sectorToolStripMenuItem.Name = "sectorToolStripMenuItem";
            this.sectorToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.sectorToolStripMenuItem.Text = "Sector";
            this.sectorToolStripMenuItem.Click += new System.EventHandler(this.sectorToolStripMenuItem_Click);
            // 
            // temasBindingSource
            // 
            this.temasBindingSource.DataMember = "Temas";
            this.temasBindingSource.DataSource = this.perfilBindingSource;
            // 
            // perfilBindingSource
            // 
            this.perfilBindingSource.DataSource = typeof(Negocio.Perfil);
            // 
            // DGV_Perfiles
            // 
            this.DGV_Perfiles.AllowUserToAddRows = false;
            this.DGV_Perfiles.AllowUserToDeleteRows = false;
            this.DGV_Perfiles.AllowUserToResizeRows = false;
            this.DGV_Perfiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.DGV_Perfiles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.DGV_Perfiles.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.DGV_Perfiles.ColumnHeadersHeight = 34;
            this.DGV_Perfiles.Location = new System.Drawing.Point(75, 93);
            this.DGV_Perfiles.Margin = new System.Windows.Forms.Padding(0);
            this.DGV_Perfiles.Name = "DGV_Perfiles";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV_Perfiles.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.DGV_Perfiles.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.DGV_Perfiles.Size = new System.Drawing.Size(666, 367);
            this.DGV_Perfiles.TabIndex = 19;
            // 
            // perfilBindingSource1
            // 
            this.perfilBindingSource1.DataSource = typeof(Negocio.Perfil);
            // 
            // Perfiles_Inicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(738, 460);
            this.Controls.Add(this.DGV_Perfiles);
            this.Controls.Add(this.Bt_Fin);
            this.Controls.Add(this.BT_Eliminar);
            this.Controls.Add(this.BTModifSector);
            this.Controls.Add(this.BTAgregarPerfil);
            this.Controls.Add(this.P_Verde);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(754, 498);
            this.Name = "Perfiles_Inicio";
            this.Load += new System.EventHandler(this.Perfiles_Inicio_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.P_Verde.ResumeLayout(false);
            this.P_Filtrado.ResumeLayout(false);
            this.P_Filtrado.PerformLayout();
            this.CMS_Perfil.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.temasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.perfilBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Perfiles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.perfilBindingSource1)).EndInit();
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
        private System.Windows.Forms.Button Bt_Fin;
        private System.Windows.Forms.Button BT_Eliminar;
        private System.Windows.Forms.Button BTModifSector;
        private System.Windows.Forms.Button BTAgregarPerfil;
        private System.Windows.Forms.ContextMenuStrip CMS_Perfil;
        private System.Windows.Forms.ToolStripMenuItem descripcionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem versionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem codigoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sectorToolStripMenuItem;
        private System.Windows.Forms.BindingSource perfilBindingSource;
        private System.Windows.Forms.BindingSource perfilBindingSource1;
        private System.Windows.Forms.BindingSource temasBindingSource;
        private System.Windows.Forms.DataGridView DGV_Perfiles;
    }
}