using System.ComponentModel;
using System.Windows.Forms;

namespace Modulo_Capacitacion.Listados.PlanCapacitacionAnualTentativo
{
    partial class AsignaTema
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvLegajos = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.LBPerfil = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.Tema = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DescTema = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Horas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLegajos)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvLegajos
            // 
            this.dgvLegajos.AllowUserToAddRows = false;
            this.dgvLegajos.AllowUserToDeleteRows = false;
            this.dgvLegajos.AllowUserToResizeColumns = false;
            this.dgvLegajos.AllowUserToResizeRows = false;
            this.dgvLegajos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLegajos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Tema,
            this.DescTema,
            this.Horas});
            this.dgvLegajos.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvLegajos.Location = new System.Drawing.Point(0, 40);
            this.dgvLegajos.Name = "dgvLegajos";
            this.dgvLegajos.ReadOnly = true;
            this.dgvLegajos.RowHeadersWidth = 15;
            this.dgvLegajos.RowTemplate.Height = 20;
            this.dgvLegajos.ShowCellToolTips = false;
            this.dgvLegajos.Size = new System.Drawing.Size(522, 153);
            this.dgvLegajos.TabIndex = 4;
            this.dgvLegajos.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvLegajos_CellMouseDoubleClick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(74)))), ((int)(((byte)(95)))));
            this.panel1.Controls.Add(this.LBPerfil);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(522, 40);
            this.panel1.TabIndex = 3;
            // 
            // LBPerfil
            // 
            this.LBPerfil.AutoSize = true;
            this.LBPerfil.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBPerfil.ForeColor = System.Drawing.Color.White;
            this.LBPerfil.Location = new System.Drawing.Point(207, 11);
            this.LBPerfil.Name = "LBPerfil";
            this.LBPerfil.Size = new System.Drawing.Size(108, 19);
            this.LBPerfil.TabIndex = 1;
            this.LBPerfil.Text = "AYUDA TEMAS";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(311, -3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(84, 43);
            this.button2.TabIndex = 2;
            this.button2.Text = "Cerrar";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(220, 201);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(83, 42);
            this.button1.TabIndex = 5;
            this.button1.Text = "Cerrar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Tema
            // 
            this.Tema.DataPropertyName = "Tema";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Tema.DefaultCellStyle = dataGridViewCellStyle7;
            this.Tema.HeaderText = "Tema";
            this.Tema.Name = "Tema";
            this.Tema.ReadOnly = true;
            this.Tema.Width = 50;
            // 
            // DescTema
            // 
            this.DescTema.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DescTema.DataPropertyName = "Descripcion";
            this.DescTema.HeaderText = "Descripción";
            this.DescTema.Name = "DescTema";
            // 
            // Horas
            // 
            this.Horas.DataPropertyName = "Horas";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Horas.DefaultCellStyle = dataGridViewCellStyle8;
            this.Horas.HeaderText = "Horas";
            this.Horas.Name = "Horas";
            this.Horas.ReadOnly = true;
            this.Horas.Width = 40;
            // 
            // AsignaTema
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(522, 250);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dgvLegajos);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button2);
            this.Name = "AsignaTema";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            ((System.ComponentModel.ISupportInitialize)(this.dgvLegajos)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView dgvLegajos;
        private Panel panel1;
        private Label LBPerfil;
        private Button button2;
        private Button button1;
        private DataGridViewTextBoxColumn Tema;
        private DataGridViewTextBoxColumn DescTema;
        private DataGridViewTextBoxColumn Horas;
    }
}