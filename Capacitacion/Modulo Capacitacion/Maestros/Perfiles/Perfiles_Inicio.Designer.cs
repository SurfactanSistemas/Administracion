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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.P_Verde = new System.Windows.Forms.Panel();
            this.P_Filtrado = new System.Windows.Forms.Panel();
            this.TBFiltro = new System.Windows.Forms.TextBox();
            this.LBFiltro = new System.Windows.Forms.Label();
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
            this.DGV_Perfiles = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.perfilBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.perfilBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.panel1.SuspendLayout();
            this.P_Verde.SuspendLayout();
            this.P_Filtrado.SuspendLayout();
            this.CMS_Perfil.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.temasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Perfiles)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.perfilBindingSource)).BeginInit();
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
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(899, 38);
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
            this.label1.Location = new System.Drawing.Point(730, 6);
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
            this.P_Verde.Location = new System.Drawing.Point(0, 38);
            this.P_Verde.Margin = new System.Windows.Forms.Padding(0);
            this.P_Verde.Name = "P_Verde";
            this.P_Verde.Size = new System.Drawing.Size(899, 55);
            this.P_Verde.TabIndex = 5;
            // 
            // P_Filtrado
            // 
            this.P_Filtrado.Controls.Add(this.TBFiltro);
            this.P_Filtrado.Controls.Add(this.LBFiltro);
            this.P_Filtrado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.P_Filtrado.Location = new System.Drawing.Point(0, 0);
            this.P_Filtrado.Margin = new System.Windows.Forms.Padding(0);
            this.P_Filtrado.Name = "P_Filtrado";
            this.P_Filtrado.Size = new System.Drawing.Size(899, 55);
            this.P_Filtrado.TabIndex = 1;
            // 
            // TBFiltro
            // 
            this.TBFiltro.Location = new System.Drawing.Point(129, 17);
            this.TBFiltro.Name = "TBFiltro";
            this.TBFiltro.Size = new System.Drawing.Size(642, 20);
            this.TBFiltro.TabIndex = 1;
            this.TBFiltro.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TBFiltro_KeyDown);
            this.TBFiltro.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TBFiltro_KeyUp);
            // 
            // LBFiltro
            // 
            this.LBFiltro.AutoSize = true;
            this.LBFiltro.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBFiltro.ForeColor = System.Drawing.Color.White;
            this.LBFiltro.Location = new System.Drawing.Point(74, 19);
            this.LBFiltro.Name = "LBFiltro";
            this.LBFiltro.Size = new System.Drawing.Size(49, 18);
            this.LBFiltro.TabIndex = 0;
            this.LBFiltro.Text = "Filtrar:";
            // 
            // Bt_Fin
            // 
            this.Bt_Fin.BackgroundImage = global::Modulo_Capacitacion.Properties.Resources.apagar;
            this.Bt_Fin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Bt_Fin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Bt_Fin.ForeColor = System.Drawing.SystemColors.Control;
            this.Bt_Fin.Location = new System.Drawing.Point(11, 318);
            this.Bt_Fin.Margin = new System.Windows.Forms.Padding(0);
            this.Bt_Fin.Name = "Bt_Fin";
            this.Bt_Fin.Size = new System.Drawing.Size(50, 54);
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
            this.BT_Eliminar.Location = new System.Drawing.Point(11, 174);
            this.BT_Eliminar.Name = "BT_Eliminar";
            this.BT_Eliminar.Size = new System.Drawing.Size(50, 54);
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
            this.BTModifSector.Location = new System.Drawing.Point(11, 102);
            this.BTModifSector.Margin = new System.Windows.Forms.Padding(0);
            this.BTModifSector.Name = "BTModifSector";
            this.BTModifSector.Size = new System.Drawing.Size(50, 54);
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
            this.BTAgregarPerfil.Location = new System.Drawing.Point(11, 30);
            this.BTAgregarPerfil.Name = "BTAgregarPerfil";
            this.BTAgregarPerfil.Size = new System.Drawing.Size(50, 54);
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
            // 
            // versionToolStripMenuItem
            // 
            this.versionToolStripMenuItem.Name = "versionToolStripMenuItem";
            this.versionToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.versionToolStripMenuItem.Text = "Version";
            // 
            // codigoToolStripMenuItem
            // 
            this.codigoToolStripMenuItem.Name = "codigoToolStripMenuItem";
            this.codigoToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.codigoToolStripMenuItem.Text = "Codigo";
            // 
            // sectorToolStripMenuItem
            // 
            this.sectorToolStripMenuItem.Name = "sectorToolStripMenuItem";
            this.sectorToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.sectorToolStripMenuItem.Text = "Sector";
            // 
            // temasBindingSource
            // 
            this.temasBindingSource.DataMember = "Temas";
            this.temasBindingSource.DataSource = this.perfilBindingSource;
            // 
            // DGV_Perfiles
            // 
            this.DGV_Perfiles.AllowUserToAddRows = false;
            this.DGV_Perfiles.AllowUserToDeleteRows = false;
            this.DGV_Perfiles.AllowUserToResizeRows = false;
            this.DGV_Perfiles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.DGV_Perfiles.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.DGV_Perfiles.ColumnHeadersHeight = 34;
            this.DGV_Perfiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGV_Perfiles.Location = new System.Drawing.Point(72, 0);
            this.DGV_Perfiles.Margin = new System.Windows.Forms.Padding(0);
            this.DGV_Perfiles.Name = "DGV_Perfiles";
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGV_Perfiles.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DGV_Perfiles.Size = new System.Drawing.Size(827, 441);
            this.DGV_Perfiles.TabIndex = 19;
            this.DGV_Perfiles.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DGV_Perfiles_RowHeaderMouseDoubleClick);
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
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(899, 534);
            this.tableLayoutPanel1.TabIndex = 20;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 72F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.DGV_Perfiles, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 93);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 441F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 441F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(899, 441);
            this.tableLayoutPanel2.TabIndex = 6;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.BTAgregarPerfil);
            this.panel2.Controls.Add(this.btnImprimir);
            this.panel2.Controls.Add(this.BT_Eliminar);
            this.panel2.Controls.Add(this.BTModifSector);
            this.panel2.Controls.Add(this.Bt_Fin);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(72, 441);
            this.panel2.TabIndex = 0;
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackgroundImage = global::Modulo_Capacitacion.Properties.Resources.imprimir;
            this.btnImprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImprimir.ForeColor = System.Drawing.SystemColors.Control;
            this.btnImprimir.Location = new System.Drawing.Point(11, 246);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(50, 54);
            this.btnImprimir.TabIndex = 17;
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // perfilBindingSource
            // 
            this.perfilBindingSource.DataSource = typeof(Negocio.Perfil);
            // 
            // perfilBindingSource1
            // 
            this.perfilBindingSource1.DataSource = typeof(Negocio.Perfil);
            // 
            // Perfiles_Inicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(899, 534);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MinimumSize = new System.Drawing.Size(754, 498);
            this.Name = "Perfiles_Inicio";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Shown += new System.EventHandler(this.Periles_Inicio_Shown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.P_Verde.ResumeLayout(false);
            this.P_Filtrado.ResumeLayout(false);
            this.P_Filtrado.PerformLayout();
            this.CMS_Perfil.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.temasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Perfiles)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.perfilBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.perfilBindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel P_Verde;
        private System.Windows.Forms.Panel P_Filtrado;
        private System.Windows.Forms.TextBox TBFiltro;
        private System.Windows.Forms.Label LBFiltro;
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
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnImprimir;
    }
}