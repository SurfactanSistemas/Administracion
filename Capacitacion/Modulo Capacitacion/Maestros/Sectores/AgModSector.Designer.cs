namespace Modulo_Capacitacion.Maestros.Sectores
{
    partial class AgModSector
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.LBChofer = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.BT_Salir = new System.Windows.Forms.Button();
            this.BT_LimpiarPant = new System.Windows.Forms.Button();
            this.BT_Guardar = new System.Windows.Forms.Button();
            this.TB_Nombre = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.LFechaAviso = new System.Windows.Forms.Label();
            this.TB_Codigo = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(139)))), ((int)(((byte)(82)))));
            this.panel1.Controls.Add(this.LBChofer);
            this.panel1.Location = new System.Drawing.Point(-1, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(802, 39);
            this.panel1.TabIndex = 2;
            // 
            // LBChofer
            // 
            this.LBChofer.AutoSize = true;
            this.LBChofer.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBChofer.ForeColor = System.Drawing.Color.White;
            this.LBChofer.Location = new System.Drawing.Point(22, 11);
            this.LBChofer.Name = "LBChofer";
            this.LBChofer.Size = new System.Drawing.Size(148, 19);
            this.LBChofer.TabIndex = 0;
            this.LBChofer.Text = "INGRESO DE SECTOR";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(74)))), ((int)(((byte)(95)))));
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Location = new System.Drawing.Point(-8, 38);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(501, 223);
            this.panel2.TabIndex = 3;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.Control;
            this.panel3.Controls.Add(this.BT_Salir);
            this.panel3.Controls.Add(this.BT_LimpiarPant);
            this.panel3.Controls.Add(this.BT_Guardar);
            this.panel3.Controls.Add(this.TB_Nombre);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.LFechaAviso);
            this.panel3.Controls.Add(this.TB_Codigo);
            this.panel3.Location = new System.Drawing.Point(16, 8);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(468, 185);
            this.panel3.TabIndex = 0;
            // 
            // BT_Salir
            // 
            this.BT_Salir.BackgroundImage = global::Modulo_Capacitacion.Properties.Resources.apagar1;
            this.BT_Salir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BT_Salir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BT_Salir.ForeColor = System.Drawing.SystemColors.Control;
            this.BT_Salir.Location = new System.Drawing.Point(290, 119);
            this.BT_Salir.Name = "BT_Salir";
            this.BT_Salir.Size = new System.Drawing.Size(40, 40);
            this.BT_Salir.TabIndex = 27;
            this.BT_Salir.UseVisualStyleBackColor = true;
            this.BT_Salir.Click += new System.EventHandler(this.BT_Salir_Click);
            // 
            // BT_LimpiarPant
            // 
            this.BT_LimpiarPant.BackgroundImage = global::Modulo_Capacitacion.Properties.Resources.limpiar;
            this.BT_LimpiarPant.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BT_LimpiarPant.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BT_LimpiarPant.ForeColor = System.Drawing.SystemColors.Control;
            this.BT_LimpiarPant.Location = new System.Drawing.Point(207, 115);
            this.BT_LimpiarPant.Margin = new System.Windows.Forms.Padding(0);
            this.BT_LimpiarPant.Name = "BT_LimpiarPant";
            this.BT_LimpiarPant.Size = new System.Drawing.Size(40, 40);
            this.BT_LimpiarPant.TabIndex = 26;
            this.BT_LimpiarPant.UseVisualStyleBackColor = true;
            this.BT_LimpiarPant.Click += new System.EventHandler(this.BT_LimpiarPant_Click);
            // 
            // BT_Guardar
            // 
            this.BT_Guardar.BackgroundImage = global::Modulo_Capacitacion.Properties.Resources.Aceptar_N2;
            this.BT_Guardar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BT_Guardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BT_Guardar.ForeColor = System.Drawing.SystemColors.Control;
            this.BT_Guardar.Location = new System.Drawing.Point(124, 119);
            this.BT_Guardar.Margin = new System.Windows.Forms.Padding(0);
            this.BT_Guardar.Name = "BT_Guardar";
            this.BT_Guardar.Size = new System.Drawing.Size(40, 40);
            this.BT_Guardar.TabIndex = 25;
            this.BT_Guardar.UseVisualStyleBackColor = true;
            this.BT_Guardar.Click += new System.EventHandler(this.BT_Guardar_Click);
            // 
            // TB_Nombre
            // 
            this.TB_Nombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TB_Nombre.Location = new System.Drawing.Point(163, 60);
            this.TB_Nombre.Name = "TB_Nombre";
            this.TB_Nombre.Size = new System.Drawing.Size(270, 20);
            this.TB_Nombre.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(22, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 18);
            this.label1.TabIndex = 6;
            this.label1.Text = "Nombre:";
            // 
            // LFechaAviso
            // 
            this.LFechaAviso.AutoSize = true;
            this.LFechaAviso.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LFechaAviso.Location = new System.Drawing.Point(22, 21);
            this.LFechaAviso.Name = "LFechaAviso";
            this.LFechaAviso.Size = new System.Drawing.Size(55, 18);
            this.LFechaAviso.TabIndex = 4;
            this.LFechaAviso.Text = "Codigo:";
            // 
            // TB_Codigo
            // 
            this.TB_Codigo.Enabled = false;
            this.TB_Codigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TB_Codigo.Location = new System.Drawing.Point(163, 21);
            this.TB_Codigo.Name = "TB_Codigo";
            this.TB_Codigo.ReadOnly = true;
            this.TB_Codigo.Size = new System.Drawing.Size(84, 20);
            this.TB_Codigo.TabIndex = 5;
            this.TB_Codigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // AgModSector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 239);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AgModSector";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label LBChofer;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button BT_Salir;
        private System.Windows.Forms.Button BT_LimpiarPant;
        private System.Windows.Forms.Button BT_Guardar;
        private System.Windows.Forms.TextBox TB_Nombre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LFechaAviso;
        private System.Windows.Forms.TextBox TB_Codigo;
    }
}