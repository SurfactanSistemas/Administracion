using System.ComponentModel;
using System.Windows.Forms;

namespace HojaRuta.Auxiliares
{
    partial class AtrasoExpedicion
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtFechaEntrega = new System.Windows.Forms.MaskedTextBox();
            this.txtFechaAviso = new System.Windows.Forms.MaskedTextBox();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.txtDesCliente = new System.Windows.Forms.TextBox();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.txtProblema = new System.Windows.Forms.TextBox();
            this.txtNroPedido = new System.Windows.Forms.TextBox();
            this.cmbPlanta = new System.Windows.Forms.ComboBox();
            this.cmbRetraso = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(74)))), ((int)(((byte)(95)))));
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.ForeColor = System.Drawing.SystemColors.Control;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(446, 35);
            this.panel1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(334, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 22);
            this.label2.TabIndex = 0;
            this.label2.Text = "SURFACTAN";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(26, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ingreso de Aviso de No Entrega";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtFechaEntrega);
            this.groupBox1.Controls.Add(this.txtFechaAviso);
            this.groupBox1.Controls.Add(this.btnConfirmar);
            this.groupBox1.Controls.Add(this.txtDesCliente);
            this.groupBox1.Controls.Add(this.txtCliente);
            this.groupBox1.Controls.Add(this.txtProblema);
            this.groupBox1.Controls.Add(this.txtNroPedido);
            this.groupBox1.Controls.Add(this.cmbPlanta);
            this.groupBox1.Controls.Add(this.cmbRetraso);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(8, 37);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(430, 221);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // txtFechaEntrega
            // 
            this.txtFechaEntrega.Location = new System.Drawing.Point(117, 83);
            this.txtFechaEntrega.Mask = "00/00/0000";
            this.txtFechaEntrega.Name = "txtFechaEntrega";
            this.txtFechaEntrega.PromptChar = ' ';
            this.txtFechaEntrega.ReadOnly = true;
            this.txtFechaEntrega.Size = new System.Drawing.Size(79, 20);
            this.txtFechaEntrega.TabIndex = 5;
            this.txtFechaEntrega.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtFechaAviso
            // 
            this.txtFechaAviso.Location = new System.Drawing.Point(117, 23);
            this.txtFechaAviso.Mask = "00/00/0000";
            this.txtFechaAviso.Name = "txtFechaAviso";
            this.txtFechaAviso.PromptChar = ' ';
            this.txtFechaAviso.ReadOnly = true;
            this.txtFechaAviso.Size = new System.Drawing.Size(79, 20);
            this.txtFechaAviso.TabIndex = 5;
            this.txtFechaAviso.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Location = new System.Drawing.Point(132, 179);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(167, 32);
            this.btnConfirmar.TabIndex = 4;
            this.btnConfirmar.Text = "CONFIRMAR";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // txtDesCliente
            // 
            this.txtDesCliente.BackColor = System.Drawing.Color.LightCyan;
            this.txtDesCliente.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDesCliente.Location = new System.Drawing.Point(176, 53);
            this.txtDesCliente.MaxLength = 50;
            this.txtDesCliente.Name = "txtDesCliente";
            this.txtDesCliente.Size = new System.Drawing.Size(240, 20);
            this.txtDesCliente.TabIndex = 2;
            // 
            // txtCliente
            // 
            this.txtCliente.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCliente.Location = new System.Drawing.Point(117, 53);
            this.txtCliente.MaxLength = 50;
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.ReadOnly = true;
            this.txtCliente.Size = new System.Drawing.Size(55, 20);
            this.txtCliente.TabIndex = 2;
            // 
            // txtProblema
            // 
            this.txtProblema.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProblema.Location = new System.Drawing.Point(117, 113);
            this.txtProblema.MaxLength = 50;
            this.txtProblema.Name = "txtProblema";
            this.txtProblema.Size = new System.Drawing.Size(299, 20);
            this.txtProblema.TabIndex = 2;
            this.txtProblema.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtProblema_KeyDown);
            // 
            // txtNroPedido
            // 
            this.txtNroPedido.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNroPedido.Location = new System.Drawing.Point(288, 23);
            this.txtNroPedido.MaxLength = 50;
            this.txtNroPedido.Name = "txtNroPedido";
            this.txtNroPedido.ReadOnly = true;
            this.txtNroPedido.Size = new System.Drawing.Size(128, 20);
            this.txtNroPedido.TabIndex = 2;
            this.txtNroPedido.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cmbPlanta
            // 
            this.cmbPlanta.FormattingEnabled = true;
            this.cmbPlanta.Items.AddRange(new object[] {
            "",
            "PLANTA I",
            "PLANTA V"});
            this.cmbPlanta.Location = new System.Drawing.Point(335, 144);
            this.cmbPlanta.Name = "cmbPlanta";
            this.cmbPlanta.Size = new System.Drawing.Size(78, 21);
            this.cmbPlanta.TabIndex = 1;
            // 
            // cmbRetraso
            // 
            this.cmbRetraso.FormattingEnabled = true;
            this.cmbRetraso.Items.AddRange(new object[] {
            "",
            "ERROR DEL SISTEMA",
            "VARIOS",
            "PROBLEMAS DE VEHICULOS",
            "PROBLEMAS DE LOGISTICA",
            "PROBLEMAS DE RECEPCION CLIENTE",
            "VARIOS",
            "CORTE DE LUZ",
            "PEDIDO POR EL CLIENTE",
            "FALTA DE PAGO",
            "CONFIRMACION PEDIDO PARCIAL",
            "ENVASES"});
            this.cmbRetraso.Location = new System.Drawing.Point(115, 144);
            this.cmbRetraso.Name = "cmbRetraso";
            this.cmbRetraso.Size = new System.Drawing.Size(172, 21);
            this.cmbRetraso.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(67, 57);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 14);
            this.label6.TabIndex = 0;
            this.label6.Text = "Cliente:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(14, 86);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(95, 14);
            this.label7.TabIndex = 0;
            this.label7.Text = "Fecha de Entrega:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(212, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 14);
            this.label5.TabIndex = 0;
            this.label5.Text = "Nº de Pedido:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(24, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 14);
            this.label4.TabIndex = 0;
            this.label4.Text = "Fecha de Aviso:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(290, 147);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(39, 14);
            this.label9.TabIndex = 0;
            this.label9.Text = "Planta:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(38, 147);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 14);
            this.label8.TabIndex = 0;
            this.label8.Text = "Tipo Retraso:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(55, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 14);
            this.label3.TabIndex = 0;
            this.label3.Text = "Problema:";
            // 
            // AtrasoExpedicion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(446, 264);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.MaximumSize = new System.Drawing.Size(462, 303);
            this.MinimumSize = new System.Drawing.Size(462, 303);
            this.Name = "AtrasoExpedicion";
            this.Load += new System.EventHandler(this.AtrasoExpedicion_Load);
            this.Shown += new System.EventHandler(this.AtrasoExpedicion_Shown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Label label2;
        private GroupBox groupBox1;
        private TextBox txtNroPedido;
        private Label label3;
        private Button btnConfirmar;
        private MaskedTextBox txtFechaAviso;
        private Label label5;
        private Label label4;
        private TextBox txtDesCliente;
        private TextBox txtCliente;
        private Label label6;
        private MaskedTextBox txtFechaEntrega;
        private Label label7;
        private ComboBox cmbRetraso;
        private Label label8;
        private ComboBox cmbPlanta;
        private Label label9;
        private TextBox txtProblema;
    }
}