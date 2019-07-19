namespace Modulo_Capacitacion.Listados.PlanCapacitacionAnualTentativo
{
    partial class Listado
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.txtAno = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.BT_Salir = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbSectores = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.rbPorLegajo = new System.Windows.Forms.RadioButton();
            this.rbPlanilla = new System.Windows.Forms.RadioButton();
            this.rbAperturaCursos = new System.Windows.Forms.RadioButton();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(74)))), ((int)(((byte)(95)))));
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(514, 50);
            this.panel2.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(368, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(143, 18);
            this.label3.TabIndex = 0;
            this.label3.Text = "SURFACTAN S.A.";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(8, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(254, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "LISTADO DE CALENDARIO TENTATIVO";
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.progressBar1.Location = new System.Drawing.Point(12, 211);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(491, 30);
            this.progressBar1.TabIndex = 85;
            // 
            // txtAno
            // 
            this.txtAno.Location = new System.Drawing.Point(57, 30);
            this.txtAno.Name = "txtAno";
            this.txtAno.Size = new System.Drawing.Size(45, 20);
            this.txtAno.TabIndex = 84;
            this.txtAno.Text = "9999";
            this.txtAno.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAno.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAno_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Año:";
            // 
            // btnAceptar
            // 
            this.btnAceptar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnAceptar.BackgroundImage = global::Modulo_Capacitacion.Properties.Resources.Aceptar_N2;
            this.btnAceptar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAceptar.ForeColor = System.Drawing.SystemColors.Control;
            this.btnAceptar.Location = new System.Drawing.Point(177, 249);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(51, 43);
            this.btnAceptar.TabIndex = 81;
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // BT_Salir
            // 
            this.BT_Salir.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.BT_Salir.BackgroundImage = global::Modulo_Capacitacion.Properties.Resources.apagar;
            this.BT_Salir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BT_Salir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BT_Salir.ForeColor = System.Drawing.SystemColors.Control;
            this.BT_Salir.Location = new System.Drawing.Point(290, 249);
            this.BT_Salir.Name = "BT_Salir";
            this.BT_Salir.Size = new System.Drawing.Size(48, 43);
            this.BT_Salir.TabIndex = 79;
            this.BT_Salir.UseVisualStyleBackColor = true;
            this.BT_Salir.Click += new System.EventHandler(this.BT_Salir_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbSectores);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.rbAperturaCursos);
            this.groupBox1.Controls.Add(this.rbPorLegajo);
            this.groupBox1.Controls.Add(this.rbPlanilla);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtAno);
            this.groupBox1.Location = new System.Drawing.Point(12, 58);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(490, 140);
            this.groupBox1.TabIndex = 86;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "PARÁMETROS";
            // 
            // cmbSectores
            // 
            this.cmbSectores.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cmbSectores.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSectores.FormattingEnabled = true;
            this.cmbSectores.Location = new System.Drawing.Point(165, 109);
            this.cmbSectores.Name = "cmbSectores";
            this.cmbSectores.Size = new System.Drawing.Size(304, 21);
            this.cmbSectores.TabIndex = 87;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(54, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 13);
            this.label4.TabIndex = 86;
            this.label4.Text = "Filtrar por Sector";
            // 
            // rbPorLegajo
            // 
            this.rbPorLegajo.AutoSize = true;
            this.rbPorLegajo.Location = new System.Drawing.Point(118, 55);
            this.rbPorLegajo.Name = "rbPorLegajo";
            this.rbPorLegajo.Size = new System.Drawing.Size(269, 17);
            this.rbPorLegajo.TabIndex = 85;
            this.rbPorLegajo.TabStop = true;
            this.rbPorLegajo.Text = "PLAN ANUAL ABIERTO POR SECTOR Y LEGAJO";
            this.rbPorLegajo.UseVisualStyleBackColor = true;
            // 
            // rbPlanilla
            // 
            this.rbPlanilla.AutoSize = true;
            this.rbPlanilla.Checked = true;
            this.rbPlanilla.Location = new System.Drawing.Point(118, 32);
            this.rbPlanilla.Name = "rbPlanilla";
            this.rbPlanilla.Size = new System.Drawing.Size(114, 17);
            this.rbPlanilla.TabIndex = 85;
            this.rbPlanilla.TabStop = true;
            this.rbPlanilla.Text = "PLANILLA ANUAL";
            this.rbPlanilla.UseVisualStyleBackColor = true;
            // 
            // rbAperturaCursos
            // 
            this.rbAperturaCursos.AutoSize = true;
            this.rbAperturaCursos.Location = new System.Drawing.Point(118, 78);
            this.rbAperturaCursos.Name = "rbAperturaCursos";
            this.rbAperturaCursos.Size = new System.Drawing.Size(365, 17);
            this.rbAperturaCursos.TabIndex = 85;
            this.rbAperturaCursos.TabStop = true;
            this.rbAperturaCursos.Text = "APERTURA DE CURSOS POR TEMAS INCLUIDOS EN PLAN ANUAL";
            this.rbAperturaCursos.UseVisualStyleBackColor = true;
            // 
            // Listado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 302);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.BT_Salir);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Listado";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Listado_Load);
            this.Shown += new System.EventHandler(this.Listado_Shown);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.TextBox txtAno;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button BT_Salir;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbPorLegajo;
        private System.Windows.Forms.RadioButton rbPlanilla;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbSectores;
        private System.Windows.Forms.RadioButton rbAperturaCursos;
    }
}