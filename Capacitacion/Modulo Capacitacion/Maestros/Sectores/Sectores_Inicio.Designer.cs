using System.ComponentModel;
using System.Windows.Forms;

namespace Modulo_Capacitacion.Maestros.Sectores
{
    partial class Sectores_Inicio
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.DGV_Sectores = new System.Windows.Forms.DataGridView();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Bt_Fin = new System.Windows.Forms.Button();
            this.BT_Eliminar = new System.Windows.Forms.Button();
            this.BTModifSector = new System.Windows.Forms.Button();
            this.BTAgregarSector = new System.Windows.Forms.Button();
            this.P_Filtrado = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.TBFiltro = new System.Windows.Forms.TextBox();
            this.P_Verde = new System.Windows.Forms.Panel();
            this.CMS_Sectores = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.codigoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.descripcionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Sectores)).BeginInit();
            this.P_Filtrado.SuspendLayout();
            this.P_Verde.SuspendLayout();
            this.CMS_Sectores.SuspendLayout();
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
            this.panel1.Size = new System.Drawing.Size(797, 35);
            this.panel1.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(9, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "SECTORES";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(405, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "SURFACTAN S.A.";
            // 
            // DGV_Sectores
            // 
            this.DGV_Sectores.AllowUserToAddRows = false;
            this.DGV_Sectores.AllowUserToDeleteRows = false;
            this.DGV_Sectores.AllowUserToResizeRows = false;
            this.DGV_Sectores.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.DGV_Sectores.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DGV_Sectores.ColumnHeadersHeight = 34;
            this.DGV_Sectores.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Codigo,
            this.Descripcion});
            this.DGV_Sectores.Location = new System.Drawing.Point(85, 0);
            this.DGV_Sectores.Margin = new System.Windows.Forms.Padding(0);
            this.DGV_Sectores.Name = "DGV_Sectores";
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGV_Sectores.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DGV_Sectores.RowHeadersWidth = 15;
            this.DGV_Sectores.Size = new System.Drawing.Size(712, 364);
            this.DGV_Sectores.TabIndex = 5;
            this.DGV_Sectores.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DGV_Sectores_RowHeaderMouseDoubleClick);
            // 
            // Codigo
            // 
            this.Codigo.DataPropertyName = "Codigo";
            this.Codigo.HeaderText = "Codigo";
            this.Codigo.MinimumWidth = 65;
            this.Codigo.Name = "Codigo";
            this.Codigo.Width = 65;
            // 
            // Descripcion
            // 
            this.Descripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Descripcion.DataPropertyName = "Descripcion";
            this.Descripcion.HeaderText = "Descripcion";
            this.Descripcion.MinimumWidth = 330;
            this.Descripcion.Name = "Descripcion";
            // 
            // Bt_Fin
            // 
            this.Bt_Fin.BackgroundImage = global::Modulo_Capacitacion.Properties.Resources.apagar;
            this.Bt_Fin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Bt_Fin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Bt_Fin.ForeColor = System.Drawing.SystemColors.Control;
            this.Bt_Fin.Location = new System.Drawing.Point(19, 288);
            this.Bt_Fin.Margin = new System.Windows.Forms.Padding(0);
            this.Bt_Fin.Name = "Bt_Fin";
            this.Bt_Fin.Size = new System.Drawing.Size(47, 53);
            this.Bt_Fin.TabIndex = 14;
            this.Bt_Fin.UseVisualStyleBackColor = true;
            this.Bt_Fin.Click += new System.EventHandler(this.Bt_Fin_Click);
            // 
            // BT_Eliminar
            // 
            this.BT_Eliminar.BackgroundImage = global::Modulo_Capacitacion.Properties.Resources.eliminar;
            this.BT_Eliminar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BT_Eliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BT_Eliminar.ForeColor = System.Drawing.SystemColors.Control;
            this.BT_Eliminar.Location = new System.Drawing.Point(17, 150);
            this.BT_Eliminar.Name = "BT_Eliminar";
            this.BT_Eliminar.Size = new System.Drawing.Size(50, 70);
            this.BT_Eliminar.TabIndex = 10;
            this.BT_Eliminar.UseVisualStyleBackColor = true;
            this.BT_Eliminar.Click += new System.EventHandler(this.BT_Eliminar_Click);
            // 
            // BTModifSector
            // 
            this.BTModifSector.BackgroundImage = global::Modulo_Capacitacion.Properties.Resources.editar_sectores;
            this.BTModifSector.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BTModifSector.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTModifSector.ForeColor = System.Drawing.SystemColors.Control;
            this.BTModifSector.Location = new System.Drawing.Point(19, 84);
            this.BTModifSector.Margin = new System.Windows.Forms.Padding(0);
            this.BTModifSector.Name = "BTModifSector";
            this.BTModifSector.Size = new System.Drawing.Size(47, 53);
            this.BTModifSector.TabIndex = 7;
            this.BTModifSector.UseVisualStyleBackColor = true;
            this.BTModifSector.Click += new System.EventHandler(this.BTModifSector_Click);
            // 
            // BTAgregarSector
            // 
            this.BTAgregarSector.BackgroundImage = global::Modulo_Capacitacion.Properties.Resources.agregar_sectores;
            this.BTAgregarSector.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BTAgregarSector.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTAgregarSector.ForeColor = System.Drawing.SystemColors.Control;
            this.BTAgregarSector.Location = new System.Drawing.Point(17, 7);
            this.BTAgregarSector.Name = "BTAgregarSector";
            this.BTAgregarSector.Size = new System.Drawing.Size(50, 64);
            this.BTAgregarSector.TabIndex = 6;
            this.BTAgregarSector.UseVisualStyleBackColor = true;
            this.BTAgregarSector.Click += new System.EventHandler(this.BTAgregarSector_Click);
            // 
            // P_Filtrado
            // 
            this.P_Filtrado.Controls.Add(this.label4);
            this.P_Filtrado.Controls.Add(this.txtCodigo);
            this.P_Filtrado.Controls.Add(this.label3);
            this.P_Filtrado.Controls.Add(this.TBFiltro);
            this.P_Filtrado.Dock = System.Windows.Forms.DockStyle.Top;
            this.P_Filtrado.Location = new System.Drawing.Point(0, 0);
            this.P_Filtrado.Name = "P_Filtrado";
            this.P_Filtrado.Size = new System.Drawing.Size(797, 52);
            this.P_Filtrado.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(277, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Filtrar:";
            // 
            // TBFiltro
            // 
            this.TBFiltro.Location = new System.Drawing.Point(339, 17);
            this.TBFiltro.Name = "TBFiltro";
            this.TBFiltro.Size = new System.Drawing.Size(430, 20);
            this.TBFiltro.TabIndex = 3;
            this.TBFiltro.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TBFiltro_KeyUp);
            // 
            // P_Verde
            // 
            this.P_Verde.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.P_Verde.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(139)))), ((int)(((byte)(82)))));
            this.P_Verde.Controls.Add(this.P_Filtrado);
            this.P_Verde.Location = new System.Drawing.Point(0, 35);
            this.P_Verde.Margin = new System.Windows.Forms.Padding(0);
            this.P_Verde.Name = "P_Verde";
            this.P_Verde.Size = new System.Drawing.Size(797, 55);
            this.P_Verde.TabIndex = 4;
            // 
            // CMS_Sectores
            // 
            this.CMS_Sectores.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.codigoToolStripMenuItem,
            this.descripcionToolStripMenuItem});
            this.CMS_Sectores.Name = "CMS_Sectores";
            this.CMS_Sectores.Size = new System.Drawing.Size(137, 48);
            // 
            // codigoToolStripMenuItem
            // 
            this.codigoToolStripMenuItem.Name = "codigoToolStripMenuItem";
            this.codigoToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.codigoToolStripMenuItem.Text = "Codigo";
            // 
            // descripcionToolStripMenuItem
            // 
            this.descripcionToolStripMenuItem.Name = "descripcionToolStripMenuItem";
            this.descripcionToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.descripcionToolStripMenuItem.Text = "Descripcion";
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
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 56F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(797, 455);
            this.tableLayoutPanel1.TabIndex = 15;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.DGV_Sectores, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 91);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(797, 364);
            this.tableLayoutPanel2.TabIndex = 5;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.BTAgregarSector);
            this.panel2.Controls.Add(this.BTModifSector);
            this.panel2.Controls.Add(this.Bt_Fin);
            this.panel2.Controls.Add(this.btnImprimir);
            this.panel2.Controls.Add(this.BT_Eliminar);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(85, 364);
            this.panel2.TabIndex = 0;
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackgroundImage = global::Modulo_Capacitacion.Properties.Resources.imprimir;
            this.btnImprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImprimir.ForeColor = System.Drawing.SystemColors.Control;
            this.btnImprimir.Location = new System.Drawing.Point(17, 215);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(50, 70);
            this.btnImprimir.TabIndex = 10;
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(160, 16);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(84, 20);
            this.txtCodigo.TabIndex = 3;
            this.txtCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCodigo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodigo_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.Control;
            this.label4.Location = new System.Drawing.Point(98, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "Código:";
            // 
            // Sectores_Inicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(797, 455);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MinimumSize = new System.Drawing.Size(572, 442);
            this.Name = "Sectores_Inicio";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Shown += new System.EventHandler(this.Sectores_Inicio_Shown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Sectores)).EndInit();
            this.P_Filtrado.ResumeLayout(false);
            this.P_Filtrado.PerformLayout();
            this.P_Verde.ResumeLayout(false);
            this.CMS_Sectores.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private Label label2;
        private Label label1;
        private DataGridView DGV_Sectores;
        private Button BTAgregarSector;
        private Button BTModifSector;
        private Button BT_Eliminar;
        private Button Bt_Fin;
        private Panel P_Filtrado;
        private TextBox TBFiltro;
        private Panel P_Verde;
        private ContextMenuStrip CMS_Sectores;
        private ToolStripMenuItem codigoToolStripMenuItem;
        private ToolStripMenuItem descripcionToolStripMenuItem;
        private DataGridViewTextBoxColumn Codigo;
        private DataGridViewTextBoxColumn Descripcion;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private Panel panel2;
        private Label label3;
        private Button btnImprimir;
        private Label label4;
        private TextBox txtCodigo;
    }
}