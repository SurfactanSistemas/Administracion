namespace Modulo_Capacitacion.Maestros.Cursos
{
    partial class AgModCurso
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
            this.LBTema = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.TB_DescTema = new System.Windows.Forms.ComboBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.TB_CodTema = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TB_Horas = new System.Windows.Forms.TextBox();
            this.TB_DescCurso = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.BT_Salir = new System.Windows.Forms.Button();
            this.BT_LimpiarPant = new System.Windows.Forms.Button();
            this.BT_Guardar = new System.Windows.Forms.Button();
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
            this.panel1.Controls.Add(this.LBTema);
            this.panel1.Location = new System.Drawing.Point(1, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(524, 39);
            this.panel1.TabIndex = 5;
            // 
            // LBTema
            // 
            this.LBTema.AutoSize = true;
            this.LBTema.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBTema.ForeColor = System.Drawing.Color.White;
            this.LBTema.Location = new System.Drawing.Point(22, 11);
            this.LBTema.Name = "LBTema";
            this.LBTema.Size = new System.Drawing.Size(142, 19);
            this.LBTema.TabIndex = 0;
            this.LBTema.Text = "INGRESO DE CURSO";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(74)))), ((int)(((byte)(95)))));
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Location = new System.Drawing.Point(0, 36);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(524, 345);
            this.panel2.TabIndex = 6;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.Control;
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Controls.Add(this.TB_DescTema);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Controls.Add(this.TB_CodTema);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.TB_Horas);
            this.panel3.Controls.Add(this.TB_DescCurso);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.BT_Salir);
            this.panel3.Controls.Add(this.BT_LimpiarPant);
            this.panel3.Controls.Add(this.BT_Guardar);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.LFechaAviso);
            this.panel3.Controls.Add(this.TB_Codigo);
            this.panel3.Location = new System.Drawing.Point(8, 8);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(504, 239);
            this.panel3.TabIndex = 0;
            // 
            // panel5
            // 
            this.panel5.Location = new System.Drawing.Point(483, 50);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(20, 28);
            this.panel5.TabIndex = 37;
            // 
            // TB_DescTema
            // 
            this.TB_DescTema.FormattingEnabled = true;
            this.TB_DescTema.Location = new System.Drawing.Point(238, 56);
            this.TB_DescTema.Name = "TB_DescTema";
            this.TB_DescTema.Size = new System.Drawing.Size(270, 21);
            this.TB_DescTema.TabIndex = 36;
            this.TB_DescTema.SelectedIndexChanged += new System.EventHandler(this.TB_DescTema_SelectedIndexChanged);
            // 
            // panel4
            // 
            this.panel4.Location = new System.Drawing.Point(212, 49);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(20, 28);
            this.panel4.TabIndex = 35;
            // 
            // TB_CodTema
            // 
            this.TB_CodTema.FormattingEnabled = true;
            this.TB_CodTema.Location = new System.Drawing.Point(128, 55);
            this.TB_CodTema.Name = "TB_CodTema";
            this.TB_CodTema.Size = new System.Drawing.Size(104, 21);
            this.TB_CodTema.TabIndex = 34;
            this.TB_CodTema.SelectedIndexChanged += new System.EventHandler(this.TB_CodTema_SelectedIndexChanged);
            this.TB_CodTema.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TB_CodTema_KeyDown_1);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(22, 126);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 18);
            this.label3.TabIndex = 33;
            this.label3.Text = "Horas:";
            // 
            // TB_Horas
            // 
            this.TB_Horas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TB_Horas.Location = new System.Drawing.Point(128, 124);
            this.TB_Horas.Name = "TB_Horas";
            this.TB_Horas.Size = new System.Drawing.Size(84, 20);
            this.TB_Horas.TabIndex = 32;
            // 
            // TB_DescCurso
            // 
            this.TB_DescCurso.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TB_DescCurso.Location = new System.Drawing.Point(128, 89);
            this.TB_DescCurso.Name = "TB_DescCurso";
            this.TB_DescCurso.Size = new System.Drawing.Size(357, 20);
            this.TB_DescCurso.TabIndex = 31;
            this.TB_DescCurso.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TB_DescCurso_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(22, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 18);
            this.label2.TabIndex = 28;
            this.label2.Text = "Descripción:";
            // 
            // BT_Salir
            // 
            this.BT_Salir.BackgroundImage = global::Modulo_Capacitacion.Properties.Resources.apagar1;
            this.BT_Salir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BT_Salir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BT_Salir.ForeColor = System.Drawing.SystemColors.Control;
            this.BT_Salir.Location = new System.Drawing.Point(328, 175);
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
            this.BT_LimpiarPant.Location = new System.Drawing.Point(245, 171);
            this.BT_LimpiarPant.Margin = new System.Windows.Forms.Padding(0);
            this.BT_LimpiarPant.Name = "BT_LimpiarPant";
            this.BT_LimpiarPant.Size = new System.Drawing.Size(40, 40);
            this.BT_LimpiarPant.TabIndex = 26;
            this.BT_LimpiarPant.UseVisualStyleBackColor = true;
            this.BT_LimpiarPant.Click += new System.EventHandler(this.BT_LimpiarPant_Click);
            // 
            // BT_Guardar
            // 
            this.BT_Guardar.BackgroundImage = global::Modulo_Capacitacion.Properties.Resources.grabar;
            this.BT_Guardar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BT_Guardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BT_Guardar.ForeColor = System.Drawing.SystemColors.Control;
            this.BT_Guardar.Location = new System.Drawing.Point(162, 175);
            this.BT_Guardar.Margin = new System.Windows.Forms.Padding(0);
            this.BT_Guardar.Name = "BT_Guardar";
            this.BT_Guardar.Size = new System.Drawing.Size(40, 40);
            this.BT_Guardar.TabIndex = 25;
            this.BT_Guardar.UseVisualStyleBackColor = true;
            this.BT_Guardar.Click += new System.EventHandler(this.BT_Guardar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(22, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 18);
            this.label1.TabIndex = 6;
            this.label1.Text = "Tema:";
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
            this.TB_Codigo.Location = new System.Drawing.Point(128, 21);
            this.TB_Codigo.Name = "TB_Codigo";
            this.TB_Codigo.ReadOnly = true;
            this.TB_Codigo.Size = new System.Drawing.Size(84, 20);
            this.TB_Codigo.TabIndex = 5;
            // 
            // AgModCurso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(519, 290);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AgModCurso";
            this.Load += new System.EventHandler(this.AgModCurso_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label LBTema;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TB_Horas;
        private System.Windows.Forms.TextBox TB_DescCurso;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BT_Salir;
        private System.Windows.Forms.Button BT_LimpiarPant;
        private System.Windows.Forms.Button BT_Guardar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LFechaAviso;
        private System.Windows.Forms.TextBox TB_Codigo;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.ComboBox TB_DescTema;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ComboBox TB_CodTema;
    }
}