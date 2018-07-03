namespace Modulo_Capacitacion.Listados.CursosPorResponsable
{
    partial class Inicio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Inicio));
            this.panel1 = new System.Windows.Forms.Panel();
            this.LBChofer = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.TB_Responsable2 = new System.Windows.Forms.ComboBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.TB_CodResponsable2 = new System.Windows.Forms.ComboBox();
            this.TB_Año = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.CB_Ordenamiento = new System.Windows.Forms.ComboBox();
            this.TB_Mes = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.BT_Pantalla = new System.Windows.Forms.Button();
            this.BT_Imprimir = new System.Windows.Forms.Button();
            this.BT_Salir = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(139)))), ((int)(((byte)(82)))));
            this.panel1.Controls.Add(this.LBChofer);
            this.panel1.Location = new System.Drawing.Point(-3, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(477, 39);
            this.panel1.TabIndex = 11;
            // 
            // LBChofer
            // 
            this.LBChofer.AutoSize = true;
            this.LBChofer.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBChofer.ForeColor = System.Drawing.Color.White;
            this.LBChofer.Location = new System.Drawing.Point(17, 10);
            this.LBChofer.Name = "LBChofer";
            this.LBChofer.Size = new System.Drawing.Size(281, 19);
            this.LBChofer.TabIndex = 0;
            this.LBChofer.Text = "LISTADO DE CURSOS POR RESPONSABLE";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(74)))), ((int)(((byte)(95)))));
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Location = new System.Drawing.Point(0, 36);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(476, 302);
            this.panel2.TabIndex = 13;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.Control;
            this.panel3.Controls.Add(this.panel7);
            this.panel3.Controls.Add(this.TB_Responsable2);
            this.panel3.Controls.Add(this.panel6);
            this.panel3.Controls.Add(this.TB_CodResponsable2);
            this.panel3.Controls.Add(this.TB_Año);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.CB_Ordenamiento);
            this.panel3.Controls.Add(this.TB_Mes);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.BT_Pantalla);
            this.panel3.Controls.Add(this.BT_Imprimir);
            this.panel3.Controls.Add(this.BT_Salir);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Location = new System.Drawing.Point(7, 7);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(397, 281);
            this.panel3.TabIndex = 0;
            // 
            // panel7
            // 
            this.panel7.Location = new System.Drawing.Point(304, 32);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(19, 29);
            this.panel7.TabIndex = 111;
            // 
            // TB_Responsable2
            // 
            this.TB_Responsable2.FormattingEnabled = true;
            this.TB_Responsable2.Location = new System.Drawing.Point(254, 34);
            this.TB_Responsable2.Name = "TB_Responsable2";
            this.TB_Responsable2.Size = new System.Drawing.Size(68, 21);
            this.TB_Responsable2.TabIndex = 110;
            this.TB_Responsable2.SelectedIndexChanged += new System.EventHandler(this.TB_Responsable2_SelectedIndexChanged);
            // 
            // panel6
            // 
            this.panel6.Location = new System.Drawing.Point(234, 32);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(19, 29);
            this.panel6.TabIndex = 109;
            // 
            // TB_CodResponsable2
            // 
            this.TB_CodResponsable2.FormattingEnabled = true;
            this.TB_CodResponsable2.Location = new System.Drawing.Point(186, 34);
            this.TB_CodResponsable2.Name = "TB_CodResponsable2";
            this.TB_CodResponsable2.Size = new System.Drawing.Size(61, 21);
            this.TB_CodResponsable2.TabIndex = 108;
            this.TB_CodResponsable2.SelectedIndexChanged += new System.EventHandler(this.TB_CodResponsable2_SelectedIndexChanged);
            // 
            // TB_Año
            // 
            this.TB_Año.Location = new System.Drawing.Point(254, 77);
            this.TB_Año.Name = "TB_Año";
            this.TB_Año.Size = new System.Drawing.Size(51, 20);
            this.TB_Año.TabIndex = 91;
            this.TB_Año.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TB_Año.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TB_Año_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(38, 118);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 18);
            this.label4.TabIndex = 89;
            this.label4.Text = "Ordenamiento:";
            // 
            // CB_Ordenamiento
            // 
            this.CB_Ordenamiento.FormattingEnabled = true;
            this.CB_Ordenamiento.Items.AddRange(new object[] {
            "POR PERSONAL",
            "POR TAREA"});
            this.CB_Ordenamiento.Location = new System.Drawing.Point(186, 118);
            this.CB_Ordenamiento.Name = "CB_Ordenamiento";
            this.CB_Ordenamiento.Size = new System.Drawing.Size(119, 21);
            this.CB_Ordenamiento.TabIndex = 88;
            // 
            // TB_Mes
            // 
            this.TB_Mes.Location = new System.Drawing.Point(186, 77);
            this.TB_Mes.Name = "TB_Mes";
            this.TB_Mes.Size = new System.Drawing.Size(49, 20);
            this.TB_Mes.TabIndex = 85;
            this.TB_Mes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TB_Mes.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TB_Mes_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(38, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 18);
            this.label2.TabIndex = 83;
            this.label2.Text = "Mes y Año";
            // 
            // BT_Pantalla
            // 
            this.BT_Pantalla.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BT_Pantalla.BackgroundImage")));
            this.BT_Pantalla.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BT_Pantalla.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BT_Pantalla.ForeColor = System.Drawing.SystemColors.Control;
            this.BT_Pantalla.Location = new System.Drawing.Point(83, 174);
            this.BT_Pantalla.Name = "BT_Pantalla";
            this.BT_Pantalla.Size = new System.Drawing.Size(40, 40);
            this.BT_Pantalla.TabIndex = 81;
            this.BT_Pantalla.UseVisualStyleBackColor = true;
            this.BT_Pantalla.Click += new System.EventHandler(this.BT_Pantalla_Click);
            // 
            // BT_Imprimir
            // 
            this.BT_Imprimir.BackgroundImage = global::Modulo_Capacitacion.Properties.Resources.imprimir;
            this.BT_Imprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BT_Imprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BT_Imprimir.ForeColor = System.Drawing.SystemColors.Control;
            this.BT_Imprimir.Location = new System.Drawing.Point(184, 174);
            this.BT_Imprimir.Name = "BT_Imprimir";
            this.BT_Imprimir.Size = new System.Drawing.Size(40, 40);
            this.BT_Imprimir.TabIndex = 80;
            this.BT_Imprimir.UseVisualStyleBackColor = true;
            this.BT_Imprimir.Click += new System.EventHandler(this.BT_Imprimir_Click);
            // 
            // BT_Salir
            // 
            this.BT_Salir.BackgroundImage = global::Modulo_Capacitacion.Properties.Resources.apagar;
            this.BT_Salir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BT_Salir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BT_Salir.ForeColor = System.Drawing.SystemColors.Control;
            this.BT_Salir.Location = new System.Drawing.Point(274, 174);
            this.BT_Salir.Name = "BT_Salir";
            this.BT_Salir.Size = new System.Drawing.Size(40, 40);
            this.BT_Salir.TabIndex = 79;
            this.BT_Salir.UseVisualStyleBackColor = true;
            this.BT_Salir.Click += new System.EventHandler(this.BT_Salir_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(38, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Responsable:";
            // 
            // Inicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 332);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Inicio";
            this.Load += new System.EventHandler(this.Inicio_Load);
            this.Shown += new System.EventHandler(this.Inicio_Shown);
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
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox CB_Ordenamiento;
        private System.Windows.Forms.TextBox TB_Mes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BT_Pantalla;
        private System.Windows.Forms.Button BT_Imprimir;
        private System.Windows.Forms.Button BT_Salir;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TB_Año;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.ComboBox TB_Responsable2;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.ComboBox TB_CodResponsable2;
    }
}