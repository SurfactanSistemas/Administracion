namespace Eval_Proveedores.Listados.ListadoProvMPFarma
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
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbTipo = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ckPellital = new System.Windows.Forms.CheckBox();
            this.ckPlantaVII = new System.Windows.Forms.CheckBox();
            this.ckPlantaVI = new System.Windows.Forms.CheckBox();
            this.ckPlantaV = new System.Windows.Forms.CheckBox();
            this.ckPlantaIV = new System.Windows.Forms.CheckBox();
            this.ckPlantaIII = new System.Windows.Forms.CheckBox();
            this.ckPlantaII = new System.Windows.Forms.CheckBox();
            this.ckPlantaI = new System.Windows.Forms.CheckBox();
            this.ckTodos = new System.Windows.Forms.CheckBox();
            this.rbTodos = new System.Windows.Forms.RadioButton();
            this.rbSoloConMovimientos = new System.Windows.Forms.RadioButton();
            this.BT_Pantalla = new System.Windows.Forms.Button();
            this.BT_Imprimir = new System.Windows.Forms.Button();
            this.BT_Salir = new System.Windows.Forms.Button();
            this.TB_Hasta = new System.Windows.Forms.MaskedTextBox();
            this.TB_Desde = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(139)))), ((int)(((byte)(82)))));
            this.panel1.Controls.Add(this.LBChofer);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(560, 39);
            this.panel1.TabIndex = 3;
            // 
            // LBChofer
            // 
            this.LBChofer.AutoSize = true;
            this.LBChofer.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBChofer.ForeColor = System.Drawing.Color.White;
            this.LBChofer.Location = new System.Drawing.Point(7, 11);
            this.LBChofer.Name = "LBChofer";
            this.LBChofer.Size = new System.Drawing.Size(437, 19);
            this.LBChofer.TabIndex = 0;
            this.LBChofer.Text = "LISTADO DE EVALUACION ACTUAL DE PROVEEDORES DE FARMA";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(74)))), ((int)(((byte)(95)))));
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 39);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(560, 281);
            this.panel2.TabIndex = 6;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.Control;
            this.panel3.Controls.Add(this.progressBar1);
            this.panel3.Controls.Add(this.groupBox1);
            this.panel3.Controls.Add(this.BT_Pantalla);
            this.panel3.Controls.Add(this.BT_Imprimir);
            this.panel3.Controls.Add(this.BT_Salir);
            this.panel3.Controls.Add(this.TB_Hasta);
            this.panel3.Controls.Add(this.TB_Desde);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Location = new System.Drawing.Point(8, 5);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(544, 271);
            this.panel3.TabIndex = 0;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(42, 191);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(467, 25);
            this.progressBar1.TabIndex = 87;
            this.progressBar1.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cmbTipo);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.rbTodos);
            this.groupBox1.Controls.Add(this.rbSoloConMovimientos);
            this.groupBox1.Location = new System.Drawing.Point(42, 39);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(467, 149);
            this.groupBox1.TabIndex = 86;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(114, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 13);
            this.label3.TabIndex = 89;
            this.label3.Text = "TIPO DE PRODUCTO";
            // 
            // cmbTipo
            // 
            this.cmbTipo.FormattingEnabled = true;
            this.cmbTipo.Items.AddRange(new object[] {
            "TODOS",
            "FARMA",
            "FOOD",
            "VETERINARIA",
            "ENVASES",
            "OTROS"});
            this.cmbTipo.Location = new System.Drawing.Point(235, 37);
            this.cmbTipo.Name = "cmbTipo";
            this.cmbTipo.Size = new System.Drawing.Size(117, 21);
            this.cmbTipo.TabIndex = 88;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ckPellital);
            this.groupBox2.Controls.Add(this.ckPlantaVII);
            this.groupBox2.Controls.Add(this.ckPlantaVI);
            this.groupBox2.Controls.Add(this.ckPlantaV);
            this.groupBox2.Controls.Add(this.ckPlantaIV);
            this.groupBox2.Controls.Add(this.ckPlantaIII);
            this.groupBox2.Controls.Add(this.ckPlantaII);
            this.groupBox2.Controls.Add(this.ckPlantaI);
            this.groupBox2.Controls.Add(this.ckTodos);
            this.groupBox2.Location = new System.Drawing.Point(93, 59);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(280, 83);
            this.groupBox2.TabIndex = 87;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Empresas";
            // 
            // ckPellital
            // 
            this.ckPellital.AutoSize = true;
            this.ckPellital.Location = new System.Drawing.Point(195, 60);
            this.ckPellital.Name = "ckPellital";
            this.ckPellital.Size = new System.Drawing.Size(56, 17);
            this.ckPellital.TabIndex = 91;
            this.ckPellital.Text = "Pellital";
            this.ckPellital.UseVisualStyleBackColor = true;
            this.ckPellital.CheckedChanged += new System.EventHandler(this.Plantas_CheckedChanged);
            // 
            // ckPlantaVII
            // 
            this.ckPlantaVII.AutoSize = true;
            this.ckPlantaVII.Location = new System.Drawing.Point(195, 37);
            this.ckPlantaVII.Name = "ckPlantaVII";
            this.ckPlantaVII.Size = new System.Drawing.Size(72, 17);
            this.ckPlantaVII.TabIndex = 90;
            this.ckPlantaVII.Text = "Planta VII";
            this.ckPlantaVII.UseVisualStyleBackColor = true;
            this.ckPlantaVII.CheckedChanged += new System.EventHandler(this.Plantas_CheckedChanged);
            // 
            // ckPlantaVI
            // 
            this.ckPlantaVI.AutoSize = true;
            this.ckPlantaVI.Location = new System.Drawing.Point(195, 14);
            this.ckPlantaVI.Name = "ckPlantaVI";
            this.ckPlantaVI.Size = new System.Drawing.Size(69, 17);
            this.ckPlantaVI.TabIndex = 93;
            this.ckPlantaVI.Text = "Planta VI";
            this.ckPlantaVI.UseVisualStyleBackColor = true;
            this.ckPlantaVI.CheckedChanged += new System.EventHandler(this.Plantas_CheckedChanged);
            // 
            // ckPlantaV
            // 
            this.ckPlantaV.AutoSize = true;
            this.ckPlantaV.Location = new System.Drawing.Point(108, 61);
            this.ckPlantaV.Name = "ckPlantaV";
            this.ckPlantaV.Size = new System.Drawing.Size(66, 17);
            this.ckPlantaV.TabIndex = 92;
            this.ckPlantaV.Text = "Planta V";
            this.ckPlantaV.UseVisualStyleBackColor = true;
            this.ckPlantaV.CheckedChanged += new System.EventHandler(this.Plantas_CheckedChanged);
            // 
            // ckPlantaIV
            // 
            this.ckPlantaIV.AutoSize = true;
            this.ckPlantaIV.Location = new System.Drawing.Point(108, 37);
            this.ckPlantaIV.Name = "ckPlantaIV";
            this.ckPlantaIV.Size = new System.Drawing.Size(69, 17);
            this.ckPlantaIV.TabIndex = 89;
            this.ckPlantaIV.Text = "Planta IV";
            this.ckPlantaIV.UseVisualStyleBackColor = true;
            this.ckPlantaIV.CheckedChanged += new System.EventHandler(this.Plantas_CheckedChanged);
            // 
            // ckPlantaIII
            // 
            this.ckPlantaIII.AutoSize = true;
            this.ckPlantaIII.Location = new System.Drawing.Point(108, 14);
            this.ckPlantaIII.Name = "ckPlantaIII";
            this.ckPlantaIII.Size = new System.Drawing.Size(68, 17);
            this.ckPlantaIII.TabIndex = 86;
            this.ckPlantaIII.Text = "Planta III";
            this.ckPlantaIII.UseVisualStyleBackColor = true;
            this.ckPlantaIII.CheckedChanged += new System.EventHandler(this.Plantas_CheckedChanged);
            // 
            // ckPlantaII
            // 
            this.ckPlantaII.AutoSize = true;
            this.ckPlantaII.Location = new System.Drawing.Point(19, 61);
            this.ckPlantaII.Name = "ckPlantaII";
            this.ckPlantaII.Size = new System.Drawing.Size(65, 17);
            this.ckPlantaII.TabIndex = 85;
            this.ckPlantaII.Text = "Planta II";
            this.ckPlantaII.UseVisualStyleBackColor = true;
            this.ckPlantaII.CheckedChanged += new System.EventHandler(this.Plantas_CheckedChanged);
            // 
            // ckPlantaI
            // 
            this.ckPlantaI.AutoSize = true;
            this.ckPlantaI.Location = new System.Drawing.Point(19, 38);
            this.ckPlantaI.Name = "ckPlantaI";
            this.ckPlantaI.Size = new System.Drawing.Size(62, 17);
            this.ckPlantaI.TabIndex = 88;
            this.ckPlantaI.Text = "Planta I";
            this.ckPlantaI.UseVisualStyleBackColor = true;
            this.ckPlantaI.CheckedChanged += new System.EventHandler(this.Plantas_CheckedChanged);
            // 
            // ckTodos
            // 
            this.ckTodos.AutoSize = true;
            this.ckTodos.Location = new System.Drawing.Point(19, 15);
            this.ckTodos.Name = "ckTodos";
            this.ckTodos.Size = new System.Drawing.Size(56, 17);
            this.ckTodos.TabIndex = 87;
            this.ckTodos.Text = "Todos";
            this.ckTodos.UseVisualStyleBackColor = true;
            this.ckTodos.CheckedChanged += new System.EventHandler(this.ckTodos_CheckedChanged);
            this.ckTodos.Click += new System.EventHandler(this.ckTodos_Click);
            // 
            // rbTodos
            // 
            this.rbTodos.AutoSize = true;
            this.rbTodos.Checked = true;
            this.rbTodos.Location = new System.Drawing.Point(287, 15);
            this.rbTodos.Name = "rbTodos";
            this.rbTodos.Size = new System.Drawing.Size(55, 17);
            this.rbTodos.TabIndex = 0;
            this.rbTodos.TabStop = true;
            this.rbTodos.Text = "Todos";
            this.rbTodos.UseVisualStyleBackColor = true;
            // 
            // rbSoloConMovimientos
            // 
            this.rbSoloConMovimientos.AutoSize = true;
            this.rbSoloConMovimientos.Location = new System.Drawing.Point(125, 15);
            this.rbSoloConMovimientos.Name = "rbSoloConMovimientos";
            this.rbSoloConMovimientos.Size = new System.Drawing.Size(129, 17);
            this.rbSoloConMovimientos.TabIndex = 0;
            this.rbSoloConMovimientos.Text = "Sólo con Movimientos";
            this.rbSoloConMovimientos.UseVisualStyleBackColor = true;
            // 
            // BT_Pantalla
            // 
            this.BT_Pantalla.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BT_Pantalla.BackgroundImage")));
            this.BT_Pantalla.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BT_Pantalla.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BT_Pantalla.ForeColor = System.Drawing.SystemColors.Control;
            this.BT_Pantalla.Location = new System.Drawing.Point(167, 223);
            this.BT_Pantalla.Name = "BT_Pantalla";
            this.BT_Pantalla.Size = new System.Drawing.Size(40, 40);
            this.BT_Pantalla.TabIndex = 83;
            this.BT_Pantalla.UseVisualStyleBackColor = true;
            this.BT_Pantalla.Click += new System.EventHandler(this.BT_Pantalla_Click);
            // 
            // BT_Imprimir
            // 
            this.BT_Imprimir.BackgroundImage = global::Eval_Proveedores.Properties.Resources.Imprimir;
            this.BT_Imprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BT_Imprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BT_Imprimir.ForeColor = System.Drawing.SystemColors.Control;
            this.BT_Imprimir.Location = new System.Drawing.Point(250, 223);
            this.BT_Imprimir.Name = "BT_Imprimir";
            this.BT_Imprimir.Size = new System.Drawing.Size(40, 40);
            this.BT_Imprimir.TabIndex = 80;
            this.BT_Imprimir.UseVisualStyleBackColor = true;
            this.BT_Imprimir.Click += new System.EventHandler(this.BT_Imprimir_Click_1);
            // 
            // BT_Salir
            // 
            this.BT_Salir.BackgroundImage = global::Eval_Proveedores.Properties.Resources.Fin21;
            this.BT_Salir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BT_Salir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BT_Salir.ForeColor = System.Drawing.SystemColors.Control;
            this.BT_Salir.Location = new System.Drawing.Point(338, 223);
            this.BT_Salir.Name = "BT_Salir";
            this.BT_Salir.Size = new System.Drawing.Size(40, 40);
            this.BT_Salir.TabIndex = 79;
            this.BT_Salir.UseVisualStyleBackColor = true;
            this.BT_Salir.Click += new System.EventHandler(this.BT_Salir_Click);
            // 
            // TB_Hasta
            // 
            this.TB_Hasta.Location = new System.Drawing.Point(381, 16);
            this.TB_Hasta.Mask = "00/00/0000";
            this.TB_Hasta.Name = "TB_Hasta";
            this.TB_Hasta.PromptChar = ' ';
            this.TB_Hasta.Size = new System.Drawing.Size(100, 20);
            this.TB_Hasta.TabIndex = 4;
            this.TB_Hasta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TB_Hasta.ValidatingType = typeof(System.DateTime);
            this.TB_Hasta.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TB_Hasta_KeyDown);
            // 
            // TB_Desde
            // 
            this.TB_Desde.Location = new System.Drawing.Point(162, 16);
            this.TB_Desde.Mask = "00/00/0000";
            this.TB_Desde.Name = "TB_Desde";
            this.TB_Desde.PromptChar = ' ';
            this.TB_Desde.Size = new System.Drawing.Size(100, 20);
            this.TB_Desde.TabIndex = 3;
            this.TB_Desde.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TB_Desde.ValidatingType = typeof(System.DateTime);
            this.TB_Desde.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TB_Desde_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(290, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Hasta Fecha:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(63, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Desde Fecha:";
            // 
            // Inicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(560, 320);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Name = "Inicio";
            this.Load += new System.EventHandler(this.Inicio_Load);
            this.Shown += new System.EventHandler(this.Inicio_Shown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label LBChofer;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button BT_Pantalla;
        private System.Windows.Forms.Button BT_Imprimir;
        private System.Windows.Forms.Button BT_Salir;
        private System.Windows.Forms.MaskedTextBox TB_Hasta;
        private System.Windows.Forms.MaskedTextBox TB_Desde;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbTodos;
        private System.Windows.Forms.RadioButton rbSoloConMovimientos;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox ckPellital;
        private System.Windows.Forms.CheckBox ckPlantaVII;
        private System.Windows.Forms.CheckBox ckPlantaVI;
        private System.Windows.Forms.CheckBox ckPlantaV;
        private System.Windows.Forms.CheckBox ckPlantaIV;
        private System.Windows.Forms.CheckBox ckPlantaIII;
        private System.Windows.Forms.CheckBox ckPlantaII;
        private System.Windows.Forms.CheckBox ckPlantaI;
        private System.Windows.Forms.CheckBox ckTodos;
        private System.Windows.Forms.ComboBox cmbTipo;
        private System.Windows.Forms.Label label3;
    }
}