using System.ComponentModel;
using System.Windows.Forms;

namespace Modulo_Capacitacion.Listados.ListadoPerfilPuestoConLegajosAsociados
{
    partial class Linio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Linio));
            this.panel1 = new System.Windows.Forms.Panel();
            this.LBChofer = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbPerfiles = new System.Windows.Forms.ComboBox();
            this.cmbSectores = new System.Windows.Forms.ComboBox();
            this.rbPorPerfil = new System.Windows.Forms.RadioButton();
            this.rbPorSector = new System.Windows.Forms.RadioButton();
            this.BT_Pantalla = new System.Windows.Forms.Button();
            this.BT_Imprimir = new System.Windows.Forms.Button();
            this.BT_Salir = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox1.SuspendLayout();
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
            this.LBChofer.Size = new System.Drawing.Size(387, 19);
            this.LBChofer.TabIndex = 0;
            this.LBChofer.Text = "PERFIL DE PUESTO CON IC Y NC DE LEGAJOS ASOCIADOS";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(74)))), ((int)(((byte)(95)))));
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 39);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(7);
            this.panel2.Size = new System.Drawing.Size(469, 190);
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
            this.panel3.Size = new System.Drawing.Size(455, 176);
            this.panel3.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbPerfiles);
            this.groupBox1.Controls.Add(this.cmbSectores);
            this.groupBox1.Controls.Add(this.rbPorPerfil);
            this.groupBox1.Controls.Add(this.rbPorSector);
            this.groupBox1.Location = new System.Drawing.Point(10, 14);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(436, 103);
            this.groupBox1.TabIndex = 88;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "PARÁMETROS";
            // 
            // cmbPerfiles
            // 
            this.cmbPerfiles.DropDownHeight = 150;
            this.cmbPerfiles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPerfiles.DropDownWidth = 500;
            this.cmbPerfiles.Enabled = false;
            this.cmbPerfiles.FormattingEnabled = true;
            this.cmbPerfiles.IntegralHeight = false;
            this.cmbPerfiles.Items.AddRange(new object[] {
            "Imprime Observaciones",
            "No imprime Observaciones"});
            this.cmbPerfiles.Location = new System.Drawing.Point(120, 62);
            this.cmbPerfiles.Name = "cmbPerfiles";
            this.cmbPerfiles.Size = new System.Drawing.Size(299, 21);
            this.cmbPerfiles.TabIndex = 88;
            // 
            // cmbSectores
            // 
            this.cmbSectores.DropDownHeight = 150;
            this.cmbSectores.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSectores.DropDownWidth = 500;
            this.cmbSectores.FormattingEnabled = true;
            this.cmbSectores.IntegralHeight = false;
            this.cmbSectores.Items.AddRange(new object[] {
            "Imprime Observaciones",
            "No imprime Observaciones"});
            this.cmbSectores.Location = new System.Drawing.Point(120, 28);
            this.cmbSectores.Name = "cmbSectores";
            this.cmbSectores.Size = new System.Drawing.Size(299, 21);
            this.cmbSectores.TabIndex = 88;
            // 
            // rbPorPerfil
            // 
            this.rbPorPerfil.AutoSize = true;
            this.rbPorPerfil.Location = new System.Drawing.Point(17, 63);
            this.rbPorPerfil.Name = "rbPorPerfil";
            this.rbPorPerfil.Size = new System.Drawing.Size(88, 17);
            this.rbPorPerfil.TabIndex = 86;
            this.rbPorPerfil.Text = "POR PERFIL";
            this.rbPorPerfil.UseVisualStyleBackColor = true;
            this.rbPorPerfil.MouseClick += new System.Windows.Forms.MouseEventHandler(this.rbPorSector_MouseClick);
            // 
            // rbPorSector
            // 
            this.rbPorSector.AutoSize = true;
            this.rbPorSector.Checked = true;
            this.rbPorSector.Location = new System.Drawing.Point(17, 29);
            this.rbPorSector.Name = "rbPorSector";
            this.rbPorSector.Size = new System.Drawing.Size(95, 17);
            this.rbPorSector.TabIndex = 86;
            this.rbPorSector.TabStop = true;
            this.rbPorSector.Text = "POR SECTOR";
            this.rbPorSector.UseVisualStyleBackColor = true;
            this.rbPorSector.MouseClick += new System.Windows.Forms.MouseEventHandler(this.rbPorSector_MouseClick);
            // 
            // BT_Pantalla
            // 
            this.BT_Pantalla.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.BT_Pantalla.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BT_Pantalla.BackgroundImage")));
            this.BT_Pantalla.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BT_Pantalla.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BT_Pantalla.ForeColor = System.Drawing.SystemColors.Control;
            this.BT_Pantalla.Location = new System.Drawing.Point(174, 128);
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
            this.BT_Imprimir.Location = new System.Drawing.Point(406, 128);
            this.BT_Imprimir.Name = "BT_Imprimir";
            this.BT_Imprimir.Size = new System.Drawing.Size(40, 40);
            this.BT_Imprimir.TabIndex = 80;
            this.BT_Imprimir.UseVisualStyleBackColor = true;
            this.BT_Imprimir.Visible = false;
            this.BT_Imprimir.Click += new System.EventHandler(this.BT_Imprimir_Click);
            // 
            // BT_Salir
            // 
            this.BT_Salir.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.BT_Salir.BackgroundImage = global::Modulo_Capacitacion.Properties.Resources.apagar;
            this.BT_Salir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BT_Salir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BT_Salir.ForeColor = System.Drawing.SystemColors.Control;
            this.BT_Salir.Location = new System.Drawing.Point(241, 128);
            this.BT_Salir.Name = "BT_Salir";
            this.BT_Salir.Size = new System.Drawing.Size(40, 40);
            this.BT_Salir.TabIndex = 79;
            this.BT_Salir.UseVisualStyleBackColor = true;
            this.BT_Salir.Click += new System.EventHandler(this.BT_Salir_Click);
            // 
            // Linio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 229);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Linio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Shown += new System.EventHandler(this.Inicio_Shown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private Label LBChofer;
        private Panel panel2;
        private Panel panel3;
        private Button BT_Pantalla;
        private Button BT_Imprimir;
        private Button BT_Salir;
        private GroupBox groupBox1;
        private RadioButton rbPorSector;
        private ComboBox cmbSectores;
        private ComboBox cmbPerfiles;
        private RadioButton rbPorPerfil;
    }
}