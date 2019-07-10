using System.ComponentModel;
using System.Windows.Forms;

namespace Modulo_Capacitacion.Listados.InformedeCompetencias
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbSi = new System.Windows.Forms.RadioButton();
            this.rbNo = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbSectores = new System.Windows.Forms.ComboBox();
            this.rbPorSector = new System.Windows.Forms.RadioButton();
            this.rbPorLegajo = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TB_Desde = new System.Windows.Forms.TextBox();
            this.TB_Hasta = new System.Windows.Forms.TextBox();
            this.BT_Pantalla = new System.Windows.Forms.Button();
            this.BT_Imprimir = new System.Windows.Forms.Button();
            this.BT_Salir = new System.Windows.Forms.Button();
            this.rbPorPerfil = new System.Windows.Forms.RadioButton();
            this.cmbPerfiles = new System.Windows.Forms.ComboBox();
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
            this.panel1.Size = new System.Drawing.Size(469, 39);
            this.panel1.TabIndex = 6;
            // 
            // LBChofer
            // 
            this.LBChofer.AutoSize = true;
            this.LBChofer.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBChofer.ForeColor = System.Drawing.Color.White;
            this.LBChofer.Location = new System.Drawing.Point(10, 10);
            this.LBChofer.Name = "LBChofer";
            this.LBChofer.Size = new System.Drawing.Size(440, 19);
            this.LBChofer.TabIndex = 0;
            this.LBChofer.Text = "INFORME DE COMPETENCIAS Y NECESIDADES DE CAPACITACION";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(74)))), ((int)(((byte)(95)))));
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 39);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(7);
            this.panel2.Size = new System.Drawing.Size(469, 258);
            this.panel2.TabIndex = 9;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.Control;
            this.panel3.Controls.Add(this.groupBox1);
            this.panel3.Controls.Add(this.BT_Pantalla);
            this.panel3.Controls.Add(this.BT_Imprimir);
            this.panel3.Controls.Add(this.BT_Salir);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(7, 7);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(455, 244);
            this.panel3.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cmbPerfiles);
            this.groupBox1.Controls.Add(this.cmbSectores);
            this.groupBox1.Controls.Add(this.rbPorPerfil);
            this.groupBox1.Controls.Add(this.rbPorSector);
            this.groupBox1.Controls.Add(this.rbPorLegajo);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.TB_Desde);
            this.groupBox1.Controls.Add(this.TB_Hasta);
            this.groupBox1.Location = new System.Drawing.Point(10, 14);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(436, 176);
            this.groupBox1.TabIndex = 88;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "PARÁMETROS";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.groupBox2.Controls.Add(this.rbSi);
            this.groupBox2.Controls.Add(this.rbNo);
            this.groupBox2.Location = new System.Drawing.Point(193, 119);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(120, 44);
            this.groupBox2.TabIndex = 91;
            this.groupBox2.TabStop = false;
            // 
            // rbSi
            // 
            this.rbSi.AutoSize = true;
            this.rbSi.Checked = true;
            this.rbSi.Location = new System.Drawing.Point(10, 16);
            this.rbSi.Name = "rbSi";
            this.rbSi.Size = new System.Drawing.Size(35, 17);
            this.rbSi.TabIndex = 90;
            this.rbSi.TabStop = true;
            this.rbSi.Text = "SI";
            this.rbSi.UseVisualStyleBackColor = true;
            // 
            // rbNo
            // 
            this.rbNo.AutoSize = true;
            this.rbNo.Location = new System.Drawing.Point(70, 16);
            this.rbNo.Name = "rbNo";
            this.rbNo.Size = new System.Drawing.Size(41, 17);
            this.rbNo.TabIndex = 90;
            this.rbNo.Text = "NO";
            this.rbNo.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(33, 135);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(128, 13);
            this.label4.TabIndex = 89;
            this.label4.Text = "¿Imprimir Observaciones?";
            // 
            // cmbSectores
            // 
            this.cmbSectores.FormattingEnabled = true;
            this.cmbSectores.Items.AddRange(new object[] {
            "Imprime Observaciones",
            "No imprime Observaciones"});
            this.cmbSectores.Location = new System.Drawing.Point(193, 57);
            this.cmbSectores.Name = "cmbSectores";
            this.cmbSectores.Size = new System.Drawing.Size(232, 21);
            this.cmbSectores.TabIndex = 88;
            // 
            // rbPorSector
            // 
            this.rbPorSector.AutoSize = true;
            this.rbPorSector.Location = new System.Drawing.Point(35, 58);
            this.rbPorSector.Name = "rbPorSector";
            this.rbPorSector.Size = new System.Drawing.Size(95, 17);
            this.rbPorSector.TabIndex = 86;
            this.rbPorSector.Text = "POR SECTOR";
            this.rbPorSector.UseVisualStyleBackColor = true;
            this.rbPorSector.Click += new System.EventHandler(this.rbPorLegajo_Click);
            // 
            // rbPorLegajo
            // 
            this.rbPorLegajo.AutoSize = true;
            this.rbPorLegajo.Checked = true;
            this.rbPorLegajo.Location = new System.Drawing.Point(35, 28);
            this.rbPorLegajo.Name = "rbPorLegajo";
            this.rbPorLegajo.Size = new System.Drawing.Size(99, 17);
            this.rbPorLegajo.TabIndex = 86;
            this.rbPorLegajo.TabStop = true;
            this.rbPorLegajo.Text = "POR LEGAJOS";
            this.rbPorLegajo.UseVisualStyleBackColor = true;
            this.rbPorLegajo.Click += new System.EventHandler(this.rbPorLegajo_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(190, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Desde:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(316, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 18);
            this.label2.TabIndex = 83;
            this.label2.Text = "Hasta:";
            // 
            // TB_Desde
            // 
            this.TB_Desde.Location = new System.Drawing.Point(253, 26);
            this.TB_Desde.Name = "TB_Desde";
            this.TB_Desde.Size = new System.Drawing.Size(51, 20);
            this.TB_Desde.TabIndex = 84;
            this.TB_Desde.Text = "1";
            this.TB_Desde.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TB_Desde.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TB_Desde_KeyDown);
            this.TB_Desde.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Ayuda_MouseDoubleClick);
            // 
            // TB_Hasta
            // 
            this.TB_Hasta.Location = new System.Drawing.Point(374, 26);
            this.TB_Hasta.MaxLength = 4;
            this.TB_Hasta.Name = "TB_Hasta";
            this.TB_Hasta.Size = new System.Drawing.Size(51, 20);
            this.TB_Hasta.TabIndex = 85;
            this.TB_Hasta.Text = "9999";
            this.TB_Hasta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TB_Hasta.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Ayuda_MouseDoubleClick);
            // 
            // BT_Pantalla
            // 
            this.BT_Pantalla.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.BT_Pantalla.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BT_Pantalla.BackgroundImage")));
            this.BT_Pantalla.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BT_Pantalla.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BT_Pantalla.ForeColor = System.Drawing.SystemColors.Control;
            this.BT_Pantalla.Location = new System.Drawing.Point(112, 196);
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
            this.BT_Imprimir.Location = new System.Drawing.Point(207, 196);
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
            this.BT_Salir.Location = new System.Drawing.Point(302, 196);
            this.BT_Salir.Name = "BT_Salir";
            this.BT_Salir.Size = new System.Drawing.Size(40, 40);
            this.BT_Salir.TabIndex = 79;
            this.BT_Salir.UseVisualStyleBackColor = true;
            this.BT_Salir.Click += new System.EventHandler(this.BT_Salir_Click);
            // 
            // rbPorPerfil
            // 
            this.rbPorPerfil.AutoSize = true;
            this.rbPorPerfil.Location = new System.Drawing.Point(35, 92);
            this.rbPorPerfil.Name = "rbPorPerfil";
            this.rbPorPerfil.Size = new System.Drawing.Size(88, 17);
            this.rbPorPerfil.TabIndex = 86;
            this.rbPorPerfil.Text = "POR PERFIL";
            this.rbPorPerfil.UseVisualStyleBackColor = true;
            this.rbPorPerfil.Click += new System.EventHandler(this.rbPorLegajo_Click);
            // 
            // cmbPerfiles
            // 
            this.cmbPerfiles.FormattingEnabled = true;
            this.cmbPerfiles.Items.AddRange(new object[] {
            "Imprime Observaciones",
            "No imprime Observaciones"});
            this.cmbPerfiles.Location = new System.Drawing.Point(193, 91);
            this.cmbPerfiles.Name = "cmbPerfiles";
            this.cmbPerfiles.Size = new System.Drawing.Size(232, 21);
            this.cmbPerfiles.TabIndex = 88;
            // 
            // Inicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 297);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Inicio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Inicio_Load);
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
        private Label label2;
        private Button BT_Pantalla;
        private Button BT_Imprimir;
        private Button BT_Salir;
        private Label label1;
        private GroupBox groupBox1;
        private RadioButton rbPorSector;
        private RadioButton rbPorLegajo;
        private ComboBox cmbSectores;
        private Label label4;
        private RadioButton rbNo;
        private RadioButton rbSi;
        private GroupBox groupBox2;
        private ComboBox cmbPerfiles;
        private RadioButton rbPorPerfil;
    }
}