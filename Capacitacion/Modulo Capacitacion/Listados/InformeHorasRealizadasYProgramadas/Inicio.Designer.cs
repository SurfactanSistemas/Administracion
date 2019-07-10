using System.ComponentModel;
using System.Windows.Forms;

namespace Modulo_Capacitacion.Listados.InformeHorasRealizadasYProgramadas
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.btnPantalla = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbSector = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtLegajo = new System.Windows.Forms.TextBox();
            this.txtDescLegajo = new System.Windows.Forms.TextBox();
            this.txtDescCurso = new System.Windows.Forms.TextBox();
            this.txtCurso = new System.Windows.Forms.TextBox();
            this.cmbTipo = new System.Windows.Forms.ComboBox();
            this.txtAnio = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.rbPorCurso = new System.Windows.Forms.RadioButton();
            this.rbPorLegajo = new System.Windows.Forms.RadioButton();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(74)))), ((int)(((byte)(95)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(511, 43);
            this.panel1.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(8, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(350, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "INFORME DE HORAS REALIZADAS Y PROGRAMADAS";
            // 
            // btnImprimir
            // 
            this.btnImprimir.Location = new System.Drawing.Point(43, 228);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(127, 40);
            this.btnImprimir.TabIndex = 5;
            this.btnImprimir.Text = "IMPRIMIR";
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // btnPantalla
            // 
            this.btnPantalla.Location = new System.Drawing.Point(192, 228);
            this.btnPantalla.Name = "btnPantalla";
            this.btnPantalla.Size = new System.Drawing.Size(127, 40);
            this.btnPantalla.TabIndex = 6;
            this.btnPantalla.Text = "MOSTRAR POR PANTALLA";
            this.btnPantalla.UseVisualStyleBackColor = true;
            this.btnPantalla.Click += new System.EventHandler(this.btnPantalla_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(341, 228);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(127, 40);
            this.btnCerrar.TabIndex = 7;
            this.btnCerrar.Text = "CERRAR";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbPorLegajo);
            this.groupBox1.Controls.Add(this.rbPorCurso);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.cmbTipo);
            this.groupBox1.Controls.Add(this.txtAnio);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(5, 49);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(500, 171);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "PARÁMETROS";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.cmbSector);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtLegajo);
            this.groupBox2.Controls.Add(this.txtDescLegajo);
            this.groupBox2.Controls.Add(this.txtDescCurso);
            this.groupBox2.Controls.Add(this.txtCurso);
            this.groupBox2.Location = new System.Drawing.Point(14, 57);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(473, 100);
            this.groupBox2.TabIndex = 4;
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
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "CURSO:";
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
            // cmbTipo
            // 
            this.cmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipo.FormattingEnabled = true;
            this.cmbTipo.Items.AddRange(new object[] {
            "COMPLETO",
            "SÓLO CUMPLIDOS",
            "SÓLO PENDIENTES"});
            this.cmbTipo.Location = new System.Drawing.Point(189, 23);
            this.cmbTipo.Name = "cmbTipo";
            this.cmbTipo.Size = new System.Drawing.Size(135, 21);
            this.cmbTipo.TabIndex = 2;
            // 
            // txtAnio
            // 
            this.txtAnio.Location = new System.Drawing.Point(53, 23);
            this.txtAnio.MaxLength = 4;
            this.txtAnio.Name = "txtAnio";
            this.txtAnio.Size = new System.Drawing.Size(41, 20);
            this.txtAnio.TabIndex = 1;
            this.txtAnio.Text = "9999";
            this.txtAnio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAnio.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAnio_KeyDown);
            this.txtAnio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAnio_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(100, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Tipo de Informe:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Año:";
            // 
            // rbPorCurso
            // 
            this.rbPorCurso.AutoSize = true;
            this.rbPorCurso.Checked = true;
            this.rbPorCurso.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbPorCurso.Location = new System.Drawing.Point(344, 16);
            this.rbPorCurso.Name = "rbPorCurso";
            this.rbPorCurso.Size = new System.Drawing.Size(136, 16);
            this.rbPorCurso.TabIndex = 5;
            this.rbPorCurso.TabStop = true;
            this.rbPorCurso.Text = "AGRUPADO POR CURSO";
            this.rbPorCurso.UseVisualStyleBackColor = true;
            this.rbPorCurso.Click += new System.EventHandler(this.rbPorCurso_Click);
            // 
            // rbPorLegajo
            // 
            this.rbPorLegajo.AutoSize = true;
            this.rbPorLegajo.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbPorLegajo.Location = new System.Drawing.Point(344, 39);
            this.rbPorLegajo.Name = "rbPorLegajo";
            this.rbPorLegajo.Size = new System.Drawing.Size(139, 16);
            this.rbPorLegajo.TabIndex = 5;
            this.rbPorLegajo.TabStop = true;
            this.rbPorLegajo.Text = "AGRUPADO POR LEGAJO";
            this.rbPorLegajo.UseVisualStyleBackColor = true;
            this.rbPorLegajo.Click += new System.EventHandler(this.rbPorCurso_Click);
            // 
            // Inicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(511, 276);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.btnPantalla);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Name = "Inicio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Inicio_Load);
            this.Shown += new System.EventHandler(this.Inicio_Shown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Button btnImprimir;
        private Button btnPantalla;
        private Button btnCerrar;
        private GroupBox groupBox1;
        private Label label2;
        private TextBox txtAnio;
        private Label label3;
        private ComboBox cmbTipo;
        private GroupBox groupBox2;
        private Label label6;
        private Label label5;
        private Label label4;
        private ComboBox cmbSector;
        private TextBox txtLegajo;
        private TextBox txtCurso;
        private TextBox txtDescLegajo;
        private TextBox txtDescCurso;
        private RadioButton rbPorLegajo;
        private RadioButton rbPorCurso;
    }
}