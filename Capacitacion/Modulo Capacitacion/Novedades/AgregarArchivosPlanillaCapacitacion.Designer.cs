namespace Modulo_Capacitacion.Novedades
{
    partial class AgregarArchivosPlanillaCapacitacion
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
            this.Button3 = new System.Windows.Forms.Button();
            this.Button2 = new System.Windows.Forms.Button();
            this.Button1 = new System.Windows.Forms.Button();
            this.dgvArchivos = new System.Windows.Forms.DataGridView();
            this.FechaArchivo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DescArchivo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Icono = new System.Windows.Forms.DataGridViewImageColumn();
            this.PathArchivo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArchivos)).BeginInit();
            this.Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Button3
            // 
            this.Button3.Location = new System.Drawing.Point(480, 59);
            this.Button3.Name = "Button3";
            this.Button3.Size = new System.Drawing.Size(164, 23);
            this.Button3.TabIndex = 59;
            this.Button3.Text = "CERRAR";
            this.Button3.UseVisualStyleBackColor = true;
            this.Button3.Click += new System.EventHandler(this.Button3_Click);
            // 
            // Button2
            // 
            this.Button2.Location = new System.Drawing.Point(175, 59);
            this.Button2.Name = "Button2";
            this.Button2.Size = new System.Drawing.Size(164, 23);
            this.Button2.TabIndex = 60;
            this.Button2.Text = "Eliminar Archivo(s)";
            this.Button2.UseVisualStyleBackColor = true;
            this.Button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // Button1
            // 
            this.Button1.Location = new System.Drawing.Point(5, 59);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(164, 23);
            this.Button1.TabIndex = 58;
            this.Button1.Text = "Agregar Archivo(s)";
            this.Button1.UseVisualStyleBackColor = true;
            this.Button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // dgvArchivos
            // 
            this.dgvArchivos.AllowDrop = true;
            this.dgvArchivos.AllowUserToAddRows = false;
            this.dgvArchivos.AllowUserToDeleteRows = false;
            this.dgvArchivos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvArchivos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FechaArchivo,
            this.DescArchivo,
            this.Icono,
            this.PathArchivo});
            this.dgvArchivos.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvArchivos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvArchivos.Location = new System.Drawing.Point(0, 91);
            this.dgvArchivos.Name = "dgvArchivos";
            this.dgvArchivos.ReadOnly = true;
            this.dgvArchivos.RowHeadersWidth = 15;
            this.dgvArchivos.RowTemplate.Height = 30;
            this.dgvArchivos.ShowCellToolTips = false;
            this.dgvArchivos.Size = new System.Drawing.Size(648, 244);
            this.dgvArchivos.TabIndex = 57;
            this.dgvArchivos.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvArchivos_CellMouseDoubleClick);
            this.dgvArchivos.DragDrop += new System.Windows.Forms.DragEventHandler(this.dgvArchivos_DragDrop);
            this.dgvArchivos.DragEnter += new System.Windows.Forms.DragEventHandler(this.dgvArchivos_DragEnter);
            // 
            // FechaArchivo
            // 
            this.FechaArchivo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.FechaArchivo.HeaderText = "Fecha";
            this.FechaArchivo.Name = "FechaArchivo";
            this.FechaArchivo.ReadOnly = true;
            this.FechaArchivo.Width = 62;
            // 
            // DescArchivo
            // 
            this.DescArchivo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DescArchivo.HeaderText = "Descripción";
            this.DescArchivo.Name = "DescArchivo";
            this.DescArchivo.ReadOnly = true;
            // 
            // Icono
            // 
            this.Icono.HeaderText = "";
            this.Icono.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.Icono.Name = "Icono";
            this.Icono.ReadOnly = true;
            this.Icono.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Icono.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Icono.Width = 50;
            // 
            // PathArchivo
            // 
            this.PathArchivo.HeaderText = "Path";
            this.PathArchivo.Name = "PathArchivo";
            this.PathArchivo.ReadOnly = true;
            this.PathArchivo.Visible = false;
            // 
            // Panel1
            // 
            this.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(74)))), ((int)(((byte)(95)))));
            this.Panel1.Controls.Add(this.Label2);
            this.Panel1.Controls.Add(this.Label1);
            this.Panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel1.Location = new System.Drawing.Point(0, 0);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(648, 50);
            this.Panel1.TabIndex = 56;
            // 
            // Label2
            // 
            this.Label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.ForeColor = System.Drawing.SystemColors.Control;
            this.Label2.Location = new System.Drawing.Point(472, 12);
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
            this.Label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.SystemColors.Control;
            this.Label1.Location = new System.Drawing.Point(19, 16);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(78, 19);
            this.Label1.TabIndex = 0;
            this.Label1.Text = "ARCHIVOS";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // AgregarArchivosPlanillaCapacitacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(648, 335);
            this.Controls.Add(this.Button3);
            this.Controls.Add(this.Button2);
            this.Controls.Add(this.Button1);
            this.Controls.Add(this.dgvArchivos);
            this.Controls.Add(this.Panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AgregarArchivosPlanillaCapacitacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.AgregarArchivosPlanillaCapacitacion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvArchivos)).EndInit();
            this.Panel1.ResumeLayout(false);
            this.Panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Button Button3;
        internal System.Windows.Forms.Button Button2;
        internal System.Windows.Forms.Button Button1;
        internal System.Windows.Forms.DataGridView dgvArchivos;
        internal System.Windows.Forms.DataGridViewTextBoxColumn FechaArchivo;
        internal System.Windows.Forms.DataGridViewTextBoxColumn DescArchivo;
        internal System.Windows.Forms.DataGridViewImageColumn Icono;
        internal System.Windows.Forms.DataGridViewTextBoxColumn PathArchivo;
        internal System.Windows.Forms.Panel Panel1;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}