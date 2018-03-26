namespace Eval_Proveedores.Novedades
{
    partial class ConsultaTipo
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.LBCamion = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.BT_Cancelar = new System.Windows.Forms.Button();
            this.Bt_Aceptar = new System.Windows.Forms.Button();
            this.CB_Otros = new System.Windows.Forms.CheckBox();
            this.CB_Mant = new System.Windows.Forms.CheckBox();
            this.CB_Calibracion = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.CB_Transp = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(139)))), ((int)(((byte)(82)))));
            this.panel1.Controls.Add(this.LBCamion);
            this.panel1.Location = new System.Drawing.Point(0, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(284, 39);
            this.panel1.TabIndex = 3;
            // 
            // LBCamion
            // 
            this.LBCamion.AutoSize = true;
            this.LBCamion.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBCamion.ForeColor = System.Drawing.Color.White;
            this.LBCamion.Location = new System.Drawing.Point(22, 11);
            this.LBCamion.Name = "LBCamion";
            this.LBCamion.Size = new System.Drawing.Size(151, 19);
            this.LBCamion.TabIndex = 0;
            this.LBCamion.Text = "TIPO DE PROVEEDOR";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(74)))), ((int)(((byte)(95)))));
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Location = new System.Drawing.Point(0, 39);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(284, 228);
            this.panel2.TabIndex = 4;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.Control;
            this.panel3.Controls.Add(this.BT_Cancelar);
            this.panel3.Controls.Add(this.Bt_Aceptar);
            this.panel3.Controls.Add(this.CB_Otros);
            this.panel3.Controls.Add(this.CB_Mant);
            this.panel3.Controls.Add(this.CB_Calibracion);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.CB_Transp);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Location = new System.Drawing.Point(7, 7);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(270, 210);
            this.panel3.TabIndex = 0;
            // 
            // BT_Cancelar
            // 
            this.BT_Cancelar.Location = new System.Drawing.Point(161, 172);
            this.BT_Cancelar.Name = "BT_Cancelar";
            this.BT_Cancelar.Size = new System.Drawing.Size(75, 23);
            this.BT_Cancelar.TabIndex = 7;
            this.BT_Cancelar.Text = "Cancelar";
            this.BT_Cancelar.UseVisualStyleBackColor = true;
            this.BT_Cancelar.Click += new System.EventHandler(this.BT_Cancelar_Click);
            // 
            // Bt_Aceptar
            // 
            this.Bt_Aceptar.Location = new System.Drawing.Point(19, 172);
            this.Bt_Aceptar.Name = "Bt_Aceptar";
            this.Bt_Aceptar.Size = new System.Drawing.Size(75, 23);
            this.Bt_Aceptar.TabIndex = 6;
            this.Bt_Aceptar.Text = "Aceptar";
            this.Bt_Aceptar.UseVisualStyleBackColor = true;
            this.Bt_Aceptar.Click += new System.EventHandler(this.Bt_Aceptar_Click);
            // 
            // CB_Otros
            // 
            this.CB_Otros.AutoSize = true;
            this.CB_Otros.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CB_Otros.Location = new System.Drawing.Point(161, 128);
            this.CB_Otros.Name = "CB_Otros";
            this.CB_Otros.Size = new System.Drawing.Size(57, 19);
            this.CB_Otros.TabIndex = 5;
            this.CB_Otros.Text = "Otros";
            this.CB_Otros.UseVisualStyleBackColor = true;
            this.CB_Otros.CheckedChanged += new System.EventHandler(this.CB_Otros_CheckedChanged);
            // 
            // CB_Mant
            // 
            this.CB_Mant.AutoSize = true;
            this.CB_Mant.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CB_Mant.Location = new System.Drawing.Point(19, 128);
            this.CB_Mant.Name = "CB_Mant";
            this.CB_Mant.Size = new System.Drawing.Size(112, 19);
            this.CB_Mant.TabIndex = 4;
            this.CB_Mant.Text = "Mantenimiento";
            this.CB_Mant.UseVisualStyleBackColor = true;
            this.CB_Mant.CheckedChanged += new System.EventHandler(this.CB_Mant_CheckedChanged);
            // 
            // CB_Calibracion
            // 
            this.CB_Calibracion.AutoSize = true;
            this.CB_Calibracion.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CB_Calibracion.Location = new System.Drawing.Point(161, 82);
            this.CB_Calibracion.Name = "CB_Calibracion";
            this.CB_Calibracion.Size = new System.Drawing.Size(85, 19);
            this.CB_Calibracion.TabIndex = 3;
            this.CB_Calibracion.Text = "Calibración";
            this.CB_Calibracion.UseVisualStyleBackColor = true;
            this.CB_Calibracion.CheckedChanged += new System.EventHandler(this.CB_Calibracion_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(15, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = " desea evaluar:";
            // 
            // CB_Transp
            // 
            this.CB_Transp.AutoSize = true;
            this.CB_Transp.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CB_Transp.Location = new System.Drawing.Point(19, 82);
            this.CB_Transp.Name = "CB_Transp";
            this.CB_Transp.Size = new System.Drawing.Size(97, 19);
            this.CB_Transp.TabIndex = 1;
            this.CB_Transp.Text = "Transportista";
            this.CB_Transp.UseVisualStyleBackColor = true;
            this.CB_Transp.CheckedChanged += new System.EventHandler(this.CB_Transp_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(191, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Elija el tipo de proveedor que";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // ConsultaTipo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(300, 300);
            this.MinimumSize = new System.Drawing.Size(300, 300);
            this.Name = "ConsultaTipo";
            this.Load += new System.EventHandler(this.ConsultaTipo_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label LBCamion;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.CheckBox CB_Transp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BT_Cancelar;
        private System.Windows.Forms.Button Bt_Aceptar;
        private System.Windows.Forms.CheckBox CB_Otros;
        private System.Windows.Forms.CheckBox CB_Mant;
        private System.Windows.Forms.CheckBox CB_Calibracion;
        private System.Windows.Forms.Label label2;
    }
}