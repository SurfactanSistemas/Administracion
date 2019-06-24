namespace Modulo_Capacitacion.Listados.TemasPorLegajoConsolidado
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbSector = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtLegajo = new System.Windows.Forms.TextBox();
            this.txtDescLegajo = new System.Windows.Forms.TextBox();
            this.txtDescCurso = new System.Windows.Forms.TextBox();
            this.txtCurso = new System.Windows.Forms.TextBox();
            this.TB_AñoHasta = new System.Windows.Forms.MaskedTextBox();
            this.TB_AñoDesde = new System.Windows.Forms.MaskedTextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label4 = new System.Windows.Forms.Label();
            this.CB_Tipo = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.BT_Pantalla = new System.Windows.Forms.Button();
            this.BT_Imprimir = new System.Windows.Forms.Button();
            this.BT_Salir = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(139)))), ((int)(((byte)(82)))));
            this.panel1.Controls.Add(this.LBChofer);
            this.panel1.Location = new System.Drawing.Point(-3, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(518, 39);
            this.panel1.TabIndex = 9;
            // 
            // LBChofer
            // 
            this.LBChofer.AutoSize = true;
            this.LBChofer.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBChofer.ForeColor = System.Drawing.Color.White;
            this.LBChofer.Location = new System.Drawing.Point(10, 10);
            this.LBChofer.Name = "LBChofer";
            this.LBChofer.Size = new System.Drawing.Size(333, 19);
            this.LBChofer.TabIndex = 0;
            this.LBChofer.Text = "LISTADO DE TEMAS POR LEGAJO CONSOLIDADO";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(74)))), ((int)(((byte)(95)))));
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Location = new System.Drawing.Point(0, 37);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(515, 344);
            this.panel2.TabIndex = 12;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.Control;
            this.panel3.Controls.Add(this.groupBox2);
            this.panel3.Controls.Add(this.TB_AñoHasta);
            this.panel3.Controls.Add(this.TB_AñoDesde);
            this.panel3.Controls.Add(this.progressBar1);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.CB_Tipo);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.BT_Pantalla);
            this.panel3.Controls.Add(this.BT_Imprimir);
            this.panel3.Controls.Add(this.BT_Salir);
            this.panel3.Location = new System.Drawing.Point(11, 8);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(493, 221);
            this.panel3.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.cmbSector);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txtLegajo);
            this.groupBox2.Controls.Add(this.txtDescLegajo);
            this.groupBox2.Controls.Add(this.txtDescCurso);
            this.groupBox2.Controls.Add(this.txtCurso);
            this.groupBox2.Location = new System.Drawing.Point(10, 42);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(473, 100);
            this.groupBox2.TabIndex = 92;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "FILTRAR PARA VALORES PARTICULARES";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 73);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "SECTOR:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 47);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "LEGAJO:";
            // 
            // cmbSector
            // 
            this.cmbSector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSector.FormattingEnabled = true;
            this.cmbSector.Items.AddRange(new object[] {
            "COMPLETO",
            "SÓLO PENDIENTES"});
            this.cmbSector.Location = new System.Drawing.Point(66, 69);
            this.cmbSector.Name = "cmbSector";
            this.cmbSector.Size = new System.Drawing.Size(400, 21);
            this.cmbSector.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "CURSO:";
            // 
            // txtLegajo
            // 
            this.txtLegajo.Location = new System.Drawing.Point(66, 43);
            this.txtLegajo.MaxLength = 4;
            this.txtLegajo.Name = "txtLegajo";
            this.txtLegajo.Size = new System.Drawing.Size(41, 20);
            this.txtLegajo.TabIndex = 1;
            this.txtLegajo.Text = "9999";
            this.txtLegajo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtLegajo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtLegajo_KeyDown);
            this.txtLegajo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAnio_KeyPress);
            // 
            // txtDescLegajo
            // 
            this.txtDescLegajo.BackColor = System.Drawing.Color.Cyan;
            this.txtDescLegajo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescLegajo.Location = new System.Drawing.Point(113, 43);
            this.txtDescLegajo.Name = "txtDescLegajo";
            this.txtDescLegajo.Size = new System.Drawing.Size(353, 20);
            this.txtDescLegajo.TabIndex = 1;
            this.txtDescLegajo.Text = "9999";
            // 
            // txtDescCurso
            // 
            this.txtDescCurso.BackColor = System.Drawing.Color.Cyan;
            this.txtDescCurso.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescCurso.Location = new System.Drawing.Point(112, 18);
            this.txtDescCurso.Name = "txtDescCurso";
            this.txtDescCurso.Size = new System.Drawing.Size(354, 20);
            this.txtDescCurso.TabIndex = 1;
            this.txtDescCurso.Text = "9999";
            // 
            // txtCurso
            // 
            this.txtCurso.Location = new System.Drawing.Point(66, 18);
            this.txtCurso.MaxLength = 3;
            this.txtCurso.Name = "txtCurso";
            this.txtCurso.Size = new System.Drawing.Size(41, 20);
            this.txtCurso.TabIndex = 1;
            this.txtCurso.Text = "9999";
            this.txtCurso.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCurso.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCurso_KeyDown);
            this.txtCurso.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAnio_KeyPress);
            // 
            // TB_AñoHasta
            // 
            this.TB_AñoHasta.Location = new System.Drawing.Point(159, 14);
            this.TB_AñoHasta.Mask = "00/00/0000";
            this.TB_AñoHasta.Name = "TB_AñoHasta";
            this.TB_AñoHasta.PromptChar = ' ';
            this.TB_AñoHasta.Size = new System.Drawing.Size(66, 20);
            this.TB_AñoHasta.TabIndex = 91;
            this.TB_AñoHasta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TB_AñoHasta.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TB_AñoHasta_KeyDown);
            // 
            // TB_AñoDesde
            // 
            this.TB_AñoDesde.Location = new System.Drawing.Point(87, 14);
            this.TB_AñoDesde.Mask = "00/00/0000";
            this.TB_AñoDesde.Name = "TB_AñoDesde";
            this.TB_AñoDesde.PromptChar = ' ';
            this.TB_AñoDesde.Size = new System.Drawing.Size(66, 20);
            this.TB_AñoDesde.TabIndex = 91;
            this.TB_AñoDesde.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TB_AñoDesde.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TB_AñoDesde_KeyDown);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(10, 148);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(473, 18);
            this.progressBar1.TabIndex = 90;
            this.progressBar1.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(231, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 18);
            this.label4.TabIndex = 89;
            this.label4.Text = "Tipo Listado:";
            // 
            // CB_Tipo
            // 
            this.CB_Tipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_Tipo.FormattingEnabled = true;
            this.CB_Tipo.Items.AddRange(new object[] {
            "COMPLETO",
            "PLANIFICADO",
            "NO PLANIFICADO"});
            this.CB_Tipo.Location = new System.Drawing.Point(323, 16);
            this.CB_Tipo.Name = "CB_Tipo";
            this.CB_Tipo.Size = new System.Drawing.Size(111, 21);
            this.CB_Tipo.TabIndex = 88;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(20, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 18);
            this.label3.TabIndex = 86;
            this.label3.Text = "Período:";
            // 
            // BT_Pantalla
            // 
            this.BT_Pantalla.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BT_Pantalla.BackgroundImage")));
            this.BT_Pantalla.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BT_Pantalla.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BT_Pantalla.ForeColor = System.Drawing.SystemColors.Control;
            this.BT_Pantalla.Location = new System.Drawing.Point(131, 174);
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
            this.BT_Imprimir.Location = new System.Drawing.Point(226, 174);
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
            this.BT_Salir.Location = new System.Drawing.Point(321, 174);
            this.BT_Salir.Name = "BT_Salir";
            this.BT_Salir.Size = new System.Drawing.Size(40, 40);
            this.BT_Salir.TabIndex = 79;
            this.BT_Salir.UseVisualStyleBackColor = true;
            this.BT_Salir.Click += new System.EventHandler(this.BT_Salir_Click);
            // 
            // Inicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 273);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Inicio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Inicio_Load);
            this.Shown += new System.EventHandler(this.Inicio_Shown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label LBChofer;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox CB_Tipo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button BT_Pantalla;
        private System.Windows.Forms.Button BT_Imprimir;
        private System.Windows.Forms.Button BT_Salir;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.MaskedTextBox TB_AñoHasta;
        private System.Windows.Forms.MaskedTextBox TB_AñoDesde;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbSector;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtLegajo;
        private System.Windows.Forms.TextBox txtDescLegajo;
        private System.Windows.Forms.TextBox txtDescCurso;
        private System.Windows.Forms.TextBox txtCurso;
    }
}