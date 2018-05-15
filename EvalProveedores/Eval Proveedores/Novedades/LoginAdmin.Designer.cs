namespace Eval_Proveedores.Novedades
{
    partial class LoginAdmin
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.LBCamion = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.TB_Clave = new System.Windows.Forms.MaskedTextBox();
            this.BT_Salir = new System.Windows.Forms.Button();
            this.BT_Guardar = new System.Windows.Forms.Button();
            this.LFechaAviso = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(139)))), ((int)(((byte)(82)))));
            this.panel1.Controls.Add(this.LBCamion);
            this.panel1.Location = new System.Drawing.Point(0, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(390, 39);
            this.panel1.TabIndex = 3;
            // 
            // LBCamion
            // 
            this.LBCamion.AutoSize = true;
            this.LBCamion.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBCamion.ForeColor = System.Drawing.Color.White;
            this.LBCamion.Location = new System.Drawing.Point(22, 11);
            this.LBCamion.Name = "LBCamion";
            this.LBCamion.Size = new System.Drawing.Size(214, 19);
            this.LBCamion.TabIndex = 0;
            this.LBCamion.Text = "INGRESO DE ADMINISTRADOR";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(74)))), ((int)(((byte)(95)))));
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Location = new System.Drawing.Point(0, 38);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(390, 153);
            this.panel2.TabIndex = 4;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.Control;
            this.panel3.Controls.Add(this.TB_Clave);
            this.panel3.Controls.Add(this.BT_Salir);
            this.panel3.Controls.Add(this.BT_Guardar);
            this.panel3.Controls.Add(this.LFechaAviso);
            this.panel3.Location = new System.Drawing.Point(7, 8);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(375, 126);
            this.panel3.TabIndex = 0;
            // 
            // TB_Clave
            // 
            this.TB_Clave.Location = new System.Drawing.Point(217, 32);
            this.TB_Clave.Mask = "9999";
            this.TB_Clave.Name = "TB_Clave";
            this.TB_Clave.PasswordChar = '*';
            this.TB_Clave.PromptChar = ' ';
            this.TB_Clave.Size = new System.Drawing.Size(53, 20);
            this.TB_Clave.TabIndex = 26;
            this.TB_Clave.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TB_Clave.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TB_Clave_KeyDown);
            // 
            // BT_Salir
            // 
            this.BT_Salir.BackgroundImage = global::Eval_Proveedores.Properties.Resources.Fin21;
            this.BT_Salir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BT_Salir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BT_Salir.ForeColor = System.Drawing.SystemColors.Control;
            this.BT_Salir.Location = new System.Drawing.Point(107, 75);
            this.BT_Salir.Name = "BT_Salir";
            this.BT_Salir.Size = new System.Drawing.Size(40, 40);
            this.BT_Salir.TabIndex = 25;
            this.toolTip1.SetToolTip(this.BT_Salir, "Salir");
            this.BT_Salir.UseVisualStyleBackColor = true;
            this.BT_Salir.Click += new System.EventHandler(this.BT_Salir_Click);
            // 
            // BT_Guardar
            // 
            this.BT_Guardar.BackgroundImage = global::Eval_Proveedores.Properties.Resources.Grabar;
            this.BT_Guardar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BT_Guardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BT_Guardar.ForeColor = System.Drawing.SystemColors.Control;
            this.BT_Guardar.Location = new System.Drawing.Point(218, 75);
            this.BT_Guardar.Margin = new System.Windows.Forms.Padding(0);
            this.BT_Guardar.Name = "BT_Guardar";
            this.BT_Guardar.Size = new System.Drawing.Size(40, 40);
            this.BT_Guardar.TabIndex = 23;
            this.toolTip1.SetToolTip(this.BT_Guardar, "Validar");
            this.BT_Guardar.UseVisualStyleBackColor = true;
            this.BT_Guardar.Click += new System.EventHandler(this.BT_Guardar_Click);
            // 
            // LFechaAviso
            // 
            this.LFechaAviso.AutoSize = true;
            this.LFechaAviso.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LFechaAviso.Location = new System.Drawing.Point(85, 34);
            this.LFechaAviso.Name = "LFechaAviso";
            this.LFechaAviso.Size = new System.Drawing.Size(110, 18);
            this.LFechaAviso.TabIndex = 2;
            this.LFechaAviso.Text = "Ingrese su clave:";
            // 
            // LoginAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(389, 178);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(405, 217);
            this.MinimumSize = new System.Drawing.Size(405, 217);
            this.Name = "LoginAdmin";
            this.Load += new System.EventHandler(this.LoginAdmin_Load);
            this.Shown += new System.EventHandler(this.LoginAdmin_Shown);
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
        private System.Windows.Forms.Label LFechaAviso;
        private System.Windows.Forms.Button BT_Guardar;
        private System.Windows.Forms.Button BT_Salir;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.MaskedTextBox TB_Clave;
    }
}