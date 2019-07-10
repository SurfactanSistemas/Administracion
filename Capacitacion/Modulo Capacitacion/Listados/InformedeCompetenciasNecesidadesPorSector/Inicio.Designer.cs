using System.ComponentModel;
using System.Windows.Forms;

namespace Modulo_Capacitacion.Listados.InformedeCompetenciasNecesidadesPorSector
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
            this.BT_Pantalla = new System.Windows.Forms.Button();
            this.BT_Imprimir = new System.Windows.Forms.Button();
            this.BT_Salir = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbSectores = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.CB_Observ = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(139)))), ((int)(((byte)(82)))));
            this.panel1.Controls.Add(this.LBChofer);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(464, 39);
            this.panel1.TabIndex = 6;
            // 
            // LBChofer
            // 
            this.LBChofer.AutoSize = true;
            this.LBChofer.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBChofer.ForeColor = System.Drawing.Color.White;
            this.LBChofer.Location = new System.Drawing.Point(7, 10);
            this.LBChofer.Name = "LBChofer";
            this.LBChofer.Size = new System.Drawing.Size(450, 17);
            this.LBChofer.TabIndex = 0;
            this.LBChofer.Text = "INFORME DE COMPETENCIAS Y NECESIDADES DE CAPACITACION POR SECTOR";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(74)))), ((int)(((byte)(95)))));
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 39);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(464, 247);
            this.panel2.TabIndex = 9;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.Control;
            this.panel3.Controls.Add(this.cmbSectores);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.CB_Observ);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.BT_Pantalla);
            this.panel3.Controls.Add(this.BT_Imprimir);
            this.panel3.Controls.Add(this.BT_Salir);
            this.panel3.Location = new System.Drawing.Point(13, 7);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(439, 234);
            this.panel3.TabIndex = 0;
            // 
            // BT_Pantalla
            // 
            this.BT_Pantalla.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BT_Pantalla.BackgroundImage")));
            this.BT_Pantalla.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BT_Pantalla.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BT_Pantalla.ForeColor = System.Drawing.SystemColors.Control;
            this.BT_Pantalla.Location = new System.Drawing.Point(100, 146);
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
            this.BT_Imprimir.Location = new System.Drawing.Point(201, 146);
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
            this.BT_Salir.Location = new System.Drawing.Point(291, 146);
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
            this.label1.Location = new System.Drawing.Point(97, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 18);
            this.label1.TabIndex = 86;
            this.label1.Text = "Sector:";
            // 
            // cmbSectores
            // 
            this.cmbSectores.FormattingEnabled = true;
            this.cmbSectores.Items.AddRange(new object[] {
            "Imprime Observaciones",
            "No imprime Observaciones"});
            this.cmbSectores.Location = new System.Drawing.Point(154, 29);
            this.cmbSectores.Name = "cmbSectores";
            this.cmbSectores.Size = new System.Drawing.Size(199, 21);
            this.cmbSectores.TabIndex = 87;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(45, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 18);
            this.label3.TabIndex = 86;
            this.label3.Text = "Observaciones:";
            // 
            // CB_Observ
            // 
            this.CB_Observ.FormattingEnabled = true;
            this.CB_Observ.Items.AddRange(new object[] {
            "Imprime Observaciones",
            "No imprime Observaciones"});
            this.CB_Observ.Location = new System.Drawing.Point(154, 60);
            this.CB_Observ.Name = "CB_Observ";
            this.CB_Observ.Size = new System.Drawing.Size(199, 21);
            this.CB_Observ.TabIndex = 87;
            // 
            // Inicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 286);
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

        private Panel panel1;
        private Label LBChofer;
        private Panel panel2;
        private Panel panel3;
        private Button BT_Pantalla;
        private Button BT_Imprimir;
        private Button BT_Salir;
        private ComboBox cmbSectores;
        private Label label1;
        private ComboBox CB_Observ;
        private Label label3;
    }
}