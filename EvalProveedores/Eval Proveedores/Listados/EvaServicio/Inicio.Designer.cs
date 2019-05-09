namespace Eval_Proveedores.Listados.EvaServicio
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
            this.CB_Tipo = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.TB_DescProve = new System.Windows.Forms.ComboBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.TB_Prove = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.BT_Pantalla = new System.Windows.Forms.Button();
            this.Bt_Imprimir = new System.Windows.Forms.Button();
            this.BT_Salir = new System.Windows.Forms.Button();
            this.TB_Hasta = new System.Windows.Forms.MaskedTextBox();
            this.TB_Desde = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(139)))), ((int)(((byte)(82)))));
            this.panel1.Controls.Add(this.LBChofer);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(584, 39);
            this.panel1.TabIndex = 5;
            // 
            // LBChofer
            // 
            this.LBChofer.AutoSize = true;
            this.LBChofer.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBChofer.ForeColor = System.Drawing.Color.White;
            this.LBChofer.Location = new System.Drawing.Point(10, 10);
            this.LBChofer.Name = "LBChofer";
            this.LBChofer.Size = new System.Drawing.Size(266, 19);
            this.LBChofer.TabIndex = 0;
            this.LBChofer.Text = "LISTADO DE EVALUACION DE SERVICIO";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(74)))), ((int)(((byte)(95)))));
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Location = new System.Drawing.Point(0, 39);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(558, 200);
            this.panel2.TabIndex = 8;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.Control;
            this.panel3.Controls.Add(this.CB_Tipo);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Controls.Add(this.TB_DescProve);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Controls.Add(this.TB_Prove);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.BT_Pantalla);
            this.panel3.Controls.Add(this.Bt_Imprimir);
            this.panel3.Controls.Add(this.BT_Salir);
            this.panel3.Controls.Add(this.TB_Hasta);
            this.panel3.Controls.Add(this.TB_Desde);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Location = new System.Drawing.Point(7, 7);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(536, 184);
            this.panel3.TabIndex = 0;
            // 
            // CB_Tipo
            // 
            this.CB_Tipo.FormattingEnabled = true;
            this.CB_Tipo.Items.AddRange(new object[] {
            "",
            "Completo",
            "Calibración",
            "Ensayo",
            "Mantenimiento",
            "Otro"});
            this.CB_Tipo.Location = new System.Drawing.Point(193, 146);
            this.CB_Tipo.Name = "CB_Tipo";
            this.CB_Tipo.Size = new System.Drawing.Size(100, 21);
            this.CB_Tipo.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(55, 149);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 18);
            this.label4.TabIndex = 89;
            this.label4.Text = "Tipo:";
            // 
            // panel5
            // 
            this.panel5.Location = new System.Drawing.Point(500, 21);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(22, 25);
            this.panel5.TabIndex = 88;
            // 
            // TB_DescProve
            // 
            this.TB_DescProve.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.TB_DescProve.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.TB_DescProve.FormattingEnabled = true;
            this.TB_DescProve.Location = new System.Drawing.Point(319, 23);
            this.TB_DescProve.Name = "TB_DescProve";
            this.TB_DescProve.Size = new System.Drawing.Size(197, 21);
            this.TB_DescProve.TabIndex = 2;
            // 
            // panel4
            // 
            this.panel4.Location = new System.Drawing.Point(291, 21);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(22, 25);
            this.panel4.TabIndex = 86;
            // 
            // TB_Prove
            // 
            this.TB_Prove.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.TB_Prove.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.TB_Prove.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.TB_Prove.FormattingEnabled = true;
            this.TB_Prove.Location = new System.Drawing.Point(193, 23);
            this.TB_Prove.MaxLength = 11;
            this.TB_Prove.Name = "TB_Prove";
            this.TB_Prove.Size = new System.Drawing.Size(100, 21);
            this.TB_Prove.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(55, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 18);
            this.label3.TabIndex = 83;
            this.label3.Text = "Proveedor:";
            // 
            // BT_Pantalla
            // 
            this.BT_Pantalla.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BT_Pantalla.BackgroundImage")));
            this.BT_Pantalla.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BT_Pantalla.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BT_Pantalla.ForeColor = System.Drawing.SystemColors.Control;
            this.BT_Pantalla.Location = new System.Drawing.Point(334, 127);
            this.BT_Pantalla.Name = "BT_Pantalla";
            this.BT_Pantalla.Size = new System.Drawing.Size(40, 40);
            this.BT_Pantalla.TabIndex = 81;
            this.BT_Pantalla.UseVisualStyleBackColor = true;
            this.BT_Pantalla.Click += new System.EventHandler(this.BT_Pantalla_Click);
            // 
            // Bt_Imprimir
            // 
            this.Bt_Imprimir.BackgroundImage = global::Eval_Proveedores.Properties.Resources.Imprimir;
            this.Bt_Imprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Bt_Imprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Bt_Imprimir.ForeColor = System.Drawing.SystemColors.Control;
            this.Bt_Imprimir.Location = new System.Drawing.Point(400, 127);
            this.Bt_Imprimir.Name = "Bt_Imprimir";
            this.Bt_Imprimir.Size = new System.Drawing.Size(40, 40);
            this.Bt_Imprimir.TabIndex = 80;
            this.Bt_Imprimir.UseVisualStyleBackColor = true;
            this.Bt_Imprimir.Click += new System.EventHandler(this.Bt_Imprimir_Click);
            // 
            // BT_Salir
            // 
            this.BT_Salir.BackgroundImage = global::Eval_Proveedores.Properties.Resources.Fin21;
            this.BT_Salir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BT_Salir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BT_Salir.ForeColor = System.Drawing.SystemColors.Control;
            this.BT_Salir.Location = new System.Drawing.Point(466, 127);
            this.BT_Salir.Name = "BT_Salir";
            this.BT_Salir.Size = new System.Drawing.Size(40, 40);
            this.BT_Salir.TabIndex = 79;
            this.BT_Salir.UseVisualStyleBackColor = true;
            this.BT_Salir.Click += new System.EventHandler(this.BT_Salir_Click);
            // 
            // TB_Hasta
            // 
            this.TB_Hasta.Location = new System.Drawing.Point(193, 108);
            this.TB_Hasta.Mask = "00/00/0000";
            this.TB_Hasta.Name = "TB_Hasta";
            this.TB_Hasta.PromptChar = ' ';
            this.TB_Hasta.Size = new System.Drawing.Size(100, 20);
            this.TB_Hasta.TabIndex = 4;
            this.TB_Hasta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TB_Hasta.ValidatingType = typeof(System.DateTime);
            // 
            // TB_Desde
            // 
            this.TB_Desde.Location = new System.Drawing.Point(193, 65);
            this.TB_Desde.Mask = "00/00/0000";
            this.TB_Desde.Name = "TB_Desde";
            this.TB_Desde.PromptChar = ' ';
            this.TB_Desde.Size = new System.Drawing.Size(100, 20);
            this.TB_Desde.TabIndex = 3;
            this.TB_Desde.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TB_Desde.ValidatingType = typeof(System.DateTime);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(55, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Hasta Fecha:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(55, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Desde Fecha:";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            // 
            // Inicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(550, 237);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(566, 276);
            this.MinimumSize = new System.Drawing.Size(566, 276);
            this.Name = "Inicio";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Load += new System.EventHandler(this.Inicio_Load);
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
        private System.Windows.Forms.ComboBox CB_Tipo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.ComboBox TB_DescProve;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ComboBox TB_Prove;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button BT_Pantalla;
        private System.Windows.Forms.Button Bt_Imprimir;
        private System.Windows.Forms.Button BT_Salir;
        private System.Windows.Forms.MaskedTextBox TB_Hasta;
        private System.Windows.Forms.MaskedTextBox TB_Desde;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}