using System.ComponentModel;
using System.Windows.Forms;

namespace Modulo_Capacitacion.Listados.TemasRealizadosPorSector
{
    partial class Inicio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Inicio));
            this.panel1 = new System.Windows.Forms.Panel();
            this.LBChofer = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtAnioHasta = new System.Windows.Forms.MaskedTextBox();
            this.txtAnioDesde = new System.Windows.Forms.MaskedTextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TB_Hasta = new System.Windows.Forms.TextBox();
            this.TB_Desde = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.BT_Pantalla = new System.Windows.Forms.Button();
            this.BT_Imprimir = new System.Windows.Forms.Button();
            this.BT_Salir = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbSector = new System.Windows.Forms.RadioButton();
            this.rbLegajo = new System.Windows.Forms.RadioButton();
            this.rbTema = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbTodos = new System.Windows.Forms.RadioButton();
            this.rbProgramados = new System.Windows.Forms.RadioButton();
            this.rbNoProgramados = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
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
            this.panel1.Size = new System.Drawing.Size(521, 39);
            this.panel1.TabIndex = 8;
            // 
            // LBChofer
            // 
            this.LBChofer.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.LBChofer.AutoSize = true;
            this.LBChofer.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBChofer.ForeColor = System.Drawing.Color.White;
            this.LBChofer.Location = new System.Drawing.Point(10, 10);
            this.LBChofer.Name = "LBChofer";
            this.LBChofer.Size = new System.Drawing.Size(235, 19);
            this.LBChofer.TabIndex = 0;
            this.LBChofer.Text = "LISTADO DE CURSOS REALIZADOS";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(74)))), ((int)(((byte)(95)))));
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 39);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(7);
            this.panel2.Size = new System.Drawing.Size(521, 311);
            this.panel2.TabIndex = 11;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.Control;
            this.panel3.Controls.Add(this.groupBox2);
            this.panel3.Controls.Add(this.groupBox1);
            this.panel3.Controls.Add(this.BT_Pantalla);
            this.panel3.Controls.Add(this.BT_Imprimir);
            this.panel3.Controls.Add(this.BT_Salir);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(7, 7);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(507, 297);
            this.panel3.TabIndex = 0;
            // 
            // txtAnioHasta
            // 
            this.txtAnioHasta.Location = new System.Drawing.Point(217, 60);
            this.txtAnioHasta.Mask = "00/00/0000";
            this.txtAnioHasta.Name = "txtAnioHasta";
            this.txtAnioHasta.PromptChar = ' ';
            this.txtAnioHasta.Size = new System.Drawing.Size(66, 20);
            this.txtAnioHasta.TabIndex = 100;
            this.txtAnioHasta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtAnioDesde
            // 
            this.txtAnioDesde.Location = new System.Drawing.Point(116, 60);
            this.txtAnioDesde.Mask = "00/00/0000";
            this.txtAnioDesde.Name = "txtAnioDesde";
            this.txtAnioDesde.PromptChar = ' ';
            this.txtAnioDesde.Size = new System.Drawing.Size(66, 20);
            this.txtAnioDesde.TabIndex = 100;
            this.txtAnioDesde.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAnioDesde.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAnioDesde_KeyDown);
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.progressBar1.Location = new System.Drawing.Point(3, 125);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(477, 30);
            this.progressBar1.TabIndex = 99;
            this.progressBar1.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 18);
            this.label4.TabIndex = 98;
            this.label4.Text = "LISTAR CURSOS:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(43, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 18);
            this.label3.TabIndex = 94;
            this.label3.Text = "PERIODO:";
            // 
            // TB_Hasta
            // 
            this.TB_Hasta.Location = new System.Drawing.Point(257, 25);
            this.TB_Hasta.Name = "TB_Hasta";
            this.TB_Hasta.Size = new System.Drawing.Size(65, 20);
            this.TB_Hasta.TabIndex = 85;
            this.TB_Hasta.Text = "9999";
            this.TB_Hasta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TB_Hasta.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TB_Hasta_KeyDown);
            this.TB_Hasta.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Ayuda_MouseDoubleClick);
            // 
            // TB_Desde
            // 
            this.TB_Desde.Location = new System.Drawing.Point(117, 25);
            this.TB_Desde.Name = "TB_Desde";
            this.TB_Desde.Size = new System.Drawing.Size(65, 20);
            this.TB_Desde.TabIndex = 84;
            this.TB_Desde.Text = "1";
            this.TB_Desde.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TB_Desde.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TB_Desde_KeyDown);
            this.TB_Desde.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Ayuda_MouseDoubleClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(204, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 18);
            this.label2.TabIndex = 83;
            this.label2.Text = "HASTA:";
            // 
            // BT_Pantalla
            // 
            this.BT_Pantalla.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.BT_Pantalla.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BT_Pantalla.BackgroundImage")));
            this.BT_Pantalla.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BT_Pantalla.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BT_Pantalla.ForeColor = System.Drawing.SystemColors.Control;
            this.BT_Pantalla.Location = new System.Drawing.Point(138, 246);
            this.BT_Pantalla.Name = "BT_Pantalla";
            this.BT_Pantalla.Size = new System.Drawing.Size(40, 40);
            this.BT_Pantalla.TabIndex = 81;
            this.BT_Pantalla.UseVisualStyleBackColor = true;
            this.BT_Pantalla.Click += new System.EventHandler(this.BT_Pantalla_Click);
            // 
            // BT_Imprimir
            // 
            this.BT_Imprimir.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.BT_Imprimir.BackgroundImage = global::Modulo_Capacitacion.Properties.Resources.imprimir;
            this.BT_Imprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BT_Imprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BT_Imprimir.ForeColor = System.Drawing.SystemColors.Control;
            this.BT_Imprimir.Location = new System.Drawing.Point(233, 246);
            this.BT_Imprimir.Name = "BT_Imprimir";
            this.BT_Imprimir.Size = new System.Drawing.Size(40, 40);
            this.BT_Imprimir.TabIndex = 80;
            this.BT_Imprimir.UseVisualStyleBackColor = true;
            this.BT_Imprimir.Click += new System.EventHandler(this.BT_Imprimir_Click);
            // 
            // BT_Salir
            // 
            this.BT_Salir.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.BT_Salir.BackgroundImage = global::Modulo_Capacitacion.Properties.Resources.apagar;
            this.BT_Salir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BT_Salir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BT_Salir.ForeColor = System.Drawing.SystemColors.Control;
            this.BT_Salir.Location = new System.Drawing.Point(328, 246);
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
            this.label1.Location = new System.Drawing.Point(60, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "DESDE:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbTema);
            this.groupBox1.Controls.Add(this.rbLegajo);
            this.groupBox1.Controls.Add(this.rbSector);
            this.groupBox1.Location = new System.Drawing.Point(10, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(486, 48);
            this.groupBox1.TabIndex = 101;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "LISTAR POR:";
            // 
            // rbSector
            // 
            this.rbSector.AutoSize = true;
            this.rbSector.Checked = true;
            this.rbSector.Location = new System.Drawing.Point(82, 19);
            this.rbSector.Name = "rbSector";
            this.rbSector.Size = new System.Drawing.Size(69, 17);
            this.rbSector.TabIndex = 0;
            this.rbSector.TabStop = true;
            this.rbSector.Text = "SECTOR";
            this.rbSector.UseVisualStyleBackColor = true;
            // 
            // rbLegajo
            // 
            this.rbLegajo.AutoSize = true;
            this.rbLegajo.Location = new System.Drawing.Point(217, 19);
            this.rbLegajo.Name = "rbLegajo";
            this.rbLegajo.Size = new System.Drawing.Size(66, 17);
            this.rbLegajo.TabIndex = 0;
            this.rbLegajo.Text = "LEGAJO";
            this.rbLegajo.UseVisualStyleBackColor = true;
            // 
            // rbTema
            // 
            this.rbTema.AutoSize = true;
            this.rbTema.Location = new System.Drawing.Point(349, 19);
            this.rbTema.Name = "rbTema";
            this.rbTema.Size = new System.Drawing.Size(55, 17);
            this.rbTema.TabIndex = 0;
            this.rbTema.Text = "TEMA";
            this.rbTema.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbNoProgramados);
            this.groupBox2.Controls.Add(this.rbProgramados);
            this.groupBox2.Controls.Add(this.rbTodos);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtAnioHasta);
            this.groupBox2.Controls.Add(this.TB_Desde);
            this.groupBox2.Controls.Add(this.txtAnioDesde);
            this.groupBox2.Controls.Add(this.TB_Hasta);
            this.groupBox2.Controls.Add(this.progressBar1);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(10, 73);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(486, 161);
            this.groupBox2.TabIndex = 102;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "PARÁMETROS";
            // 
            // rbTodos
            // 
            this.rbTodos.AutoSize = true;
            this.rbTodos.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbTodos.Location = new System.Drawing.Point(117, 96);
            this.rbTodos.Name = "rbTodos";
            this.rbTodos.Size = new System.Drawing.Size(61, 17);
            this.rbTodos.TabIndex = 101;
            this.rbTodos.TabStop = true;
            this.rbTodos.Text = "TODOS";
            this.rbTodos.UseVisualStyleBackColor = true;
            // 
            // rbProgramados
            // 
            this.rbProgramados.AutoSize = true;
            this.rbProgramados.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbProgramados.Location = new System.Drawing.Point(180, 96);
            this.rbProgramados.Name = "rbProgramados";
            this.rbProgramados.Size = new System.Drawing.Size(140, 17);
            this.rbProgramados.TabIndex = 101;
            this.rbProgramados.TabStop = true;
            this.rbProgramados.Text = "SÓLO PROGRAMADOS";
            this.rbProgramados.UseVisualStyleBackColor = true;
            // 
            // rbNoProgramados
            // 
            this.rbNoProgramados.AutoSize = true;
            this.rbNoProgramados.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbNoProgramados.Location = new System.Drawing.Point(322, 96);
            this.rbNoProgramados.Name = "rbNoProgramados";
            this.rbNoProgramados.Size = new System.Drawing.Size(158, 17);
            this.rbNoProgramados.TabIndex = 101;
            this.rbNoProgramados.TabStop = true;
            this.rbNoProgramados.Text = "SÓLO NO PROGRAMADOS";
            this.rbNoProgramados.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(188, 61);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(23, 18);
            this.label5.TabIndex = 83;
            this.label5.Text = "AL";
            // 
            // Inicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(521, 350);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Inicio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Shown += new System.EventHandler(this.Inicio_Shown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private Label LBChofer;
        private Panel panel2;
        private Panel panel3;
        private TextBox TB_Hasta;
        private TextBox TB_Desde;
        private Button BT_Pantalla;
        private Button BT_Imprimir;
        private Button BT_Salir;
        private Label label4;
        private Label label3;
        private ProgressBar progressBar1;
        private MaskedTextBox txtAnioHasta;
        private MaskedTextBox txtAnioDesde;
        private Label label2;
        private Label label1;
        private GroupBox groupBox1;
        private RadioButton rbTema;
        private RadioButton rbLegajo;
        private RadioButton rbSector;
        private GroupBox groupBox2;
        private RadioButton rbNoProgramados;
        private RadioButton rbProgramados;
        private RadioButton rbTodos;
        private Label label5;
    }
}