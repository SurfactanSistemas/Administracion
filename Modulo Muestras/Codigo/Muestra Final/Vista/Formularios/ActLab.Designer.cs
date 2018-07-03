using System.ComponentModel;
using System.Windows.Forms;

namespace Vista
{
    partial class ActLab
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.LB_Id = new System.Windows.Forms.Label();
            this.BtSalir = new System.Windows.Forms.Button();
            this.BtGuardar = new System.Windows.Forms.Button();
            this.TbCantEntregada = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TBFechaRealiz = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TBCodEnsayo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TBDescMatPrima = new System.Windows.Forms.TextBox();
            this.TBCodMatPrima = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.toolTip_Guardar = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip_Cerrar = new System.Windows.Forms.ToolTip(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.TB_Observaciones = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(139)))), ((int)(((byte)(82)))));
            this.panel1.Controls.Add(this.label5);
            this.panel1.Location = new System.Drawing.Point(-1, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(522, 42);
            this.panel1.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(6, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(334, 19);
            this.label5.TabIndex = 0;
            this.label5.Text = "ACTUALIZACION DE DATOS EN EL LABORATORIO";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(74)))), ((int)(((byte)(95)))));
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Location = new System.Drawing.Point(-1, 38);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(522, 250);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.Control;
            this.panel3.Controls.Add(this.TB_Observaciones);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.LB_Id);
            this.panel3.Controls.Add(this.BtSalir);
            this.panel3.Controls.Add(this.BtGuardar);
            this.panel3.Controls.Add(this.TbCantEntregada);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.TBFechaRealiz);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.TBCodEnsayo);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.TBDescMatPrima);
            this.panel3.Controls.Add(this.TBCodMatPrima);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Location = new System.Drawing.Point(6, 6);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(510, 233);
            this.panel3.TabIndex = 0;
            // 
            // LB_Id
            // 
            this.LB_Id.AutoSize = true;
            this.LB_Id.Location = new System.Drawing.Point(288, 47);
            this.LB_Id.Name = "LB_Id";
            this.LB_Id.Size = new System.Drawing.Size(0, 13);
            this.LB_Id.TabIndex = 14;
            this.LB_Id.Visible = false;
            // 
            // BtSalir
            // 
            this.BtSalir.BackgroundImage = global::Vista.Properties.Resources.Salir;
            this.BtSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BtSalir.Location = new System.Drawing.Point(454, 184);
            this.BtSalir.Name = "BtSalir";
            this.BtSalir.Size = new System.Drawing.Size(40, 40);
            this.BtSalir.TabIndex = 13;
            this.toolTip_Cerrar.SetToolTip(this.BtSalir, "Cerrar");
            this.BtSalir.UseVisualStyleBackColor = true;
            this.BtSalir.Click += new System.EventHandler(this.button4_Click);
            // 
            // BtGuardar
            // 
            this.BtGuardar.BackgroundImage = global::Vista.Properties.Resources.Grabar_N;
            this.BtGuardar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BtGuardar.Location = new System.Drawing.Point(408, 184);
            this.BtGuardar.Name = "BtGuardar";
            this.BtGuardar.Size = new System.Drawing.Size(40, 40);
            this.BtGuardar.TabIndex = 10;
            this.toolTip_Guardar.SetToolTip(this.BtGuardar, "Guardar");
            this.BtGuardar.UseVisualStyleBackColor = true;
            this.BtGuardar.Click += new System.EventHandler(this.BtGuardar_Click);
            // 
            // TbCantEntregada
            // 
            this.TbCantEntregada.Location = new System.Drawing.Point(160, 115);
            this.TbCantEntregada.Name = "TbCantEntregada";
            this.TbCantEntregada.Size = new System.Drawing.Size(113, 20);
            this.TbCantEntregada.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(10, 117);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(132, 18);
            this.label4.TabIndex = 8;
            this.label4.Text = "Cantidad Entregada:";
            // 
            // TBFechaRealiz
            // 
            this.TBFechaRealiz.Enabled = false;
            this.TBFechaRealiz.Location = new System.Drawing.Point(160, 81);
            this.TBFechaRealiz.Name = "TBFechaRealiz";
            this.TBFechaRealiz.Size = new System.Drawing.Size(113, 20);
            this.TBFechaRealiz.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(10, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(140, 18);
            this.label3.TabIndex = 6;
            this.label3.Text = "Fecha de Realización:";
            // 
            // TBCodEnsayo
            // 
            this.TBCodEnsayo.Location = new System.Drawing.Point(160, 47);
            this.TBCodEnsayo.Name = "TBCodEnsayo";
            this.TBCodEnsayo.Size = new System.Drawing.Size(113, 20);
            this.TBCodEnsayo.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(7, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 18);
            this.label2.TabIndex = 4;
            this.label2.Text = "Código de Ensayo:";
            // 
            // TBDescMatPrima
            // 
            this.TBDescMatPrima.Enabled = false;
            this.TBDescMatPrima.Location = new System.Drawing.Point(288, 15);
            this.TBDescMatPrima.Name = "TBDescMatPrima";
            this.TBDescMatPrima.Size = new System.Drawing.Size(206, 20);
            this.TBDescMatPrima.TabIndex = 3;
            // 
            // TBCodMatPrima
            // 
            this.TBCodMatPrima.Enabled = false;
            this.TBCodMatPrima.Location = new System.Drawing.Point(160, 16);
            this.TBCodMatPrima.Name = "TBCodMatPrima";
            this.TBCodMatPrima.Size = new System.Drawing.Size(113, 20);
            this.TBCodMatPrima.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Código de M. Prima:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(10, 149);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(103, 18);
            this.label6.TabIndex = 15;
            this.label6.Text = "Observaciones:";
            // 
            // TB_Observaciones
            // 
            this.TB_Observaciones.Location = new System.Drawing.Point(160, 147);
            this.TB_Observaciones.Name = "TB_Observaciones";
            this.TB_Observaciones.Size = new System.Drawing.Size(334, 20);
            this.TB_Observaciones.TabIndex = 16;
            // 
            // ActLab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(521, 282);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "ActLab";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Label label1;
        private TextBox TbCantEntregada;
        private Label label4;
        private TextBox TBFechaRealiz;
        private Label label3;
        private TextBox TBCodEnsayo;
        private Label label2;
        private TextBox TBDescMatPrima;
        private TextBox TBCodMatPrima;
        private Button BtGuardar;
        private Button BtSalir;
        private Label label5;
        private Label LB_Id;
        private ToolTip toolTip_Cerrar;
        private ToolTip toolTip_Guardar;
        private TextBox TB_Observaciones;
        private Label label6;
    }
}