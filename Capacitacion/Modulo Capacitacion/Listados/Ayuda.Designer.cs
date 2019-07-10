using System.ComponentModel;
using System.Windows.Forms;

namespace Modulo_Capacitacion.Listados
{
    partial class Ayuda
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.LBChofer = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtAyuda = new System.Windows.Forms.TextBox();
            this.dgvAyuda = new System.Windows.Forms.DataGridView();
            this.BT_Salir = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAyuda)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(74)))), ((int)(((byte)(95)))));
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 39);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(427, 267);
            this.panel2.TabIndex = 11;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.Control;
            this.panel3.Controls.Add(this.dgvAyuda);
            this.panel3.Controls.Add(this.txtAyuda);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.BT_Salir);
            this.panel3.Location = new System.Drawing.Point(7, 9);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(413, 248);
            this.panel3.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(139)))), ((int)(((byte)(82)))));
            this.panel1.Controls.Add(this.LBChofer);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(427, 39);
            this.panel1.TabIndex = 10;
            // 
            // LBChofer
            // 
            this.LBChofer.AutoSize = true;
            this.LBChofer.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBChofer.ForeColor = System.Drawing.Color.White;
            this.LBChofer.Location = new System.Drawing.Point(10, 10);
            this.LBChofer.Name = "LBChofer";
            this.LBChofer.Size = new System.Drawing.Size(232, 19);
            this.LBChofer.TabIndex = 0;
            this.LBChofer.Text = "LISTADO DE LEGAJOS POR PERFIL";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 80;
            this.label1.Text = "Filtrar";
            // 
            // txtAyuda
            // 
            this.txtAyuda.Location = new System.Drawing.Point(82, 24);
            this.txtAyuda.Name = "txtAyuda";
            this.txtAyuda.Size = new System.Drawing.Size(295, 20);
            this.txtAyuda.TabIndex = 81;
            this.txtAyuda.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAyuda_KeyPress);
            // 
            // dgvAyuda
            // 
            this.dgvAyuda.AllowUserToAddRows = false;
            this.dgvAyuda.AllowUserToDeleteRows = false;
            this.dgvAyuda.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAyuda.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvAyuda.Location = new System.Drawing.Point(16, 59);
            this.dgvAyuda.Name = "dgvAyuda";
            this.dgvAyuda.ReadOnly = true;
            this.dgvAyuda.Size = new System.Drawing.Size(381, 140);
            this.dgvAyuda.TabIndex = 82;
            this.dgvAyuda.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAyuda_CellDoubleClick);
            // 
            // BT_Salir
            // 
            this.BT_Salir.BackgroundImage = global::Modulo_Capacitacion.Properties.Resources.apagar;
            this.BT_Salir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BT_Salir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BT_Salir.ForeColor = System.Drawing.SystemColors.Control;
            this.BT_Salir.Location = new System.Drawing.Point(186, 209);
            this.BT_Salir.Name = "BT_Salir";
            this.BT_Salir.Size = new System.Drawing.Size(34, 32);
            this.BT_Salir.TabIndex = 79;
            this.BT_Salir.UseVisualStyleBackColor = true;
            this.BT_Salir.Click += new System.EventHandler(this.BT_Salir_Click);
            // 
            // Ayuda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 306);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Ayuda";
            this.Text = "Ayuda";
            this.Shown += new System.EventHandler(this.Ayuda_Shown);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAyuda)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel2;
        private Panel panel3;
        private Button BT_Salir;
        private Panel panel1;
        private Label LBChofer;
        private TextBox txtAyuda;
        private Label label1;
        private DataGridView dgvAyuda;
    }
}