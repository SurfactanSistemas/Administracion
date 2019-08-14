using System.ComponentModel;
using System.Windows.Forms;

namespace Modulo_Capacitacion.Listados.PlanCapacitacionAnualTentativo
{
    partial class TentativoListaCursos
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.LBPerfil = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgvGrilla = new System.Windows.Forms.DataGridView();
            this.Curso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Personas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Horas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cursada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Resta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mes1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mes2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mes3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mes4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mes5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mes6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mes7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mes8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mes9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mes10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mes11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mes12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtAnio = new System.Windows.Forms.TextBox();
            this.BT_Salir = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrilla)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(139)))), ((int)(((byte)(82)))));
            this.panel1.Controls.Add(this.LBPerfil);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(809, 39);
            this.panel1.TabIndex = 7;
            // 
            // LBPerfil
            // 
            this.LBPerfil.AutoSize = true;
            this.LBPerfil.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBPerfil.ForeColor = System.Drawing.Color.White;
            this.LBPerfil.Location = new System.Drawing.Point(22, 11);
            this.LBPerfil.Name = "LBPerfil";
            this.LBPerfil.Size = new System.Drawing.Size(415, 19);
            this.LBPerfil.TabIndex = 0;
            this.LBPerfil.Text = "CRONOGRAMA TENTATIVO DE CAPACITACION DE PERSONAL";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(74)))), ((int)(((byte)(95)))));
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Location = new System.Drawing.Point(0, 38);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(809, 618);
            this.panel2.TabIndex = 8;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.Control;
            this.panel3.Controls.Add(this.dgvGrilla);
            this.panel3.Controls.Add(this.txtAnio);
            this.panel3.Controls.Add(this.BT_Salir);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Location = new System.Drawing.Point(7, 6);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(790, 540);
            this.panel3.TabIndex = 3;
            // 
            // dgvGrilla
            // 
            this.dgvGrilla.AllowUserToAddRows = false;
            this.dgvGrilla.AllowUserToDeleteRows = false;
            this.dgvGrilla.AllowUserToResizeColumns = false;
            this.dgvGrilla.AllowUserToResizeRows = false;
            this.dgvGrilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGrilla.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Curso,
            this.Descripcion,
            this.Personas,
            this.Horas,
            this.Cursada,
            this.Resta,
            this.Mes1,
            this.Mes2,
            this.Mes3,
            this.Mes4,
            this.Mes5,
            this.Mes6,
            this.Mes7,
            this.Mes8,
            this.Mes9,
            this.Mes10,
            this.Mes11,
            this.Mes12});
            this.dgvGrilla.Location = new System.Drawing.Point(15, 40);
            this.dgvGrilla.Name = "dgvGrilla";
            this.dgvGrilla.ReadOnly = true;
            this.dgvGrilla.RowHeadersWidth = 10;
            this.dgvGrilla.RowTemplate.Height = 20;
            this.dgvGrilla.ShowCellToolTips = false;
            this.dgvGrilla.Size = new System.Drawing.Size(760, 432);
            this.dgvGrilla.TabIndex = 36;
            this.dgvGrilla.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvGrilla_CellMouseDoubleClick);
            // 
            // Curso
            // 
            this.Curso.DataPropertyName = "Curso";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Curso.DefaultCellStyle = dataGridViewCellStyle1;
            this.Curso.HeaderText = "Tema";
            this.Curso.Name = "Curso";
            this.Curso.ReadOnly = true;
            this.Curso.Width = 40;
            // 
            // Descripcion
            // 
            this.Descripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Descripcion.DataPropertyName = "Descripcion";
            this.Descripcion.HeaderText = "Descripcion";
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.ReadOnly = true;
            // 
            // Personas
            // 
            this.Personas.DataPropertyName = "Personas";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Personas.DefaultCellStyle = dataGridViewCellStyle2;
            this.Personas.HeaderText = "Personas";
            this.Personas.Name = "Personas";
            this.Personas.ReadOnly = true;
            this.Personas.Width = 60;
            // 
            // Horas
            // 
            this.Horas.DataPropertyName = "Horas";
            this.Horas.HeaderText = "Horas";
            this.Horas.Name = "Horas";
            this.Horas.ReadOnly = true;
            this.Horas.Visible = false;
            this.Horas.Width = 50;
            // 
            // Cursada
            // 
            this.Cursada.DataPropertyName = "HorasRealizado";
            this.Cursada.HeaderText = "Cursada";
            this.Cursada.Name = "Cursada";
            this.Cursada.ReadOnly = true;
            this.Cursada.Visible = false;
            this.Cursada.Width = 50;
            // 
            // Resta
            // 
            this.Resta.DataPropertyName = "Resta";
            this.Resta.HeaderText = "Resta";
            this.Resta.Name = "Resta";
            this.Resta.ReadOnly = true;
            this.Resta.Visible = false;
            this.Resta.Width = 50;
            // 
            // Mes1
            // 
            this.Mes1.DataPropertyName = "Mes1";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Mes1.DefaultCellStyle = dataGridViewCellStyle3;
            this.Mes1.HeaderText = "Jun";
            this.Mes1.Name = "Mes1";
            this.Mes1.ReadOnly = true;
            this.Mes1.Width = 30;
            // 
            // Mes2
            // 
            this.Mes2.DataPropertyName = "Mes2";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Mes2.DefaultCellStyle = dataGridViewCellStyle4;
            this.Mes2.HeaderText = "Jul";
            this.Mes2.Name = "Mes2";
            this.Mes2.ReadOnly = true;
            this.Mes2.Width = 30;
            // 
            // Mes3
            // 
            this.Mes3.DataPropertyName = "Mes3";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Mes3.DefaultCellStyle = dataGridViewCellStyle5;
            this.Mes3.HeaderText = "Ago";
            this.Mes3.Name = "Mes3";
            this.Mes3.ReadOnly = true;
            this.Mes3.Width = 30;
            // 
            // Mes4
            // 
            this.Mes4.DataPropertyName = "Mes4";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Mes4.DefaultCellStyle = dataGridViewCellStyle6;
            this.Mes4.HeaderText = "Sep";
            this.Mes4.Name = "Mes4";
            this.Mes4.ReadOnly = true;
            this.Mes4.Width = 30;
            // 
            // Mes5
            // 
            this.Mes5.DataPropertyName = "Mes5";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Mes5.DefaultCellStyle = dataGridViewCellStyle7;
            this.Mes5.HeaderText = "Oct";
            this.Mes5.Name = "Mes5";
            this.Mes5.ReadOnly = true;
            this.Mes5.Width = 30;
            // 
            // Mes6
            // 
            this.Mes6.DataPropertyName = "Mes6";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Mes6.DefaultCellStyle = dataGridViewCellStyle8;
            this.Mes6.HeaderText = "Nov";
            this.Mes6.Name = "Mes6";
            this.Mes6.ReadOnly = true;
            this.Mes6.Width = 30;
            // 
            // Mes7
            // 
            this.Mes7.DataPropertyName = "Mes7";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Mes7.DefaultCellStyle = dataGridViewCellStyle9;
            this.Mes7.HeaderText = "Dic";
            this.Mes7.Name = "Mes7";
            this.Mes7.ReadOnly = true;
            this.Mes7.Width = 30;
            // 
            // Mes8
            // 
            this.Mes8.DataPropertyName = "Mes8";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Mes8.DefaultCellStyle = dataGridViewCellStyle10;
            this.Mes8.HeaderText = "Ene";
            this.Mes8.Name = "Mes8";
            this.Mes8.ReadOnly = true;
            this.Mes8.Width = 30;
            // 
            // Mes9
            // 
            this.Mes9.DataPropertyName = "Mes9";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Mes9.DefaultCellStyle = dataGridViewCellStyle11;
            this.Mes9.HeaderText = "Feb";
            this.Mes9.Name = "Mes9";
            this.Mes9.ReadOnly = true;
            this.Mes9.Width = 30;
            // 
            // Mes10
            // 
            this.Mes10.DataPropertyName = "Mes10";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Mes10.DefaultCellStyle = dataGridViewCellStyle12;
            this.Mes10.HeaderText = "Mar";
            this.Mes10.Name = "Mes10";
            this.Mes10.ReadOnly = true;
            this.Mes10.Width = 30;
            // 
            // Mes11
            // 
            this.Mes11.DataPropertyName = "Mes11";
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Mes11.DefaultCellStyle = dataGridViewCellStyle13;
            this.Mes11.HeaderText = "Abr";
            this.Mes11.Name = "Mes11";
            this.Mes11.ReadOnly = true;
            this.Mes11.Width = 30;
            // 
            // Mes12
            // 
            this.Mes12.DataPropertyName = "Mes12";
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Mes12.DefaultCellStyle = dataGridViewCellStyle14;
            this.Mes12.HeaderText = "May";
            this.Mes12.Name = "Mes12";
            this.Mes12.ReadOnly = true;
            this.Mes12.Width = 30;
            // 
            // txtAnio
            // 
            this.txtAnio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAnio.Location = new System.Drawing.Point(84, 14);
            this.txtAnio.Name = "txtAnio";
            this.txtAnio.ReadOnly = true;
            this.txtAnio.Size = new System.Drawing.Size(54, 20);
            this.txtAnio.TabIndex = 35;
            this.txtAnio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // BT_Salir
            // 
            this.BT_Salir.BackgroundImage = global::Modulo_Capacitacion.Properties.Resources.apagar1;
            this.BT_Salir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BT_Salir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BT_Salir.ForeColor = System.Drawing.SystemColors.Control;
            this.BT_Salir.Location = new System.Drawing.Point(375, 487);
            this.BT_Salir.Name = "BT_Salir";
            this.BT_Salir.Size = new System.Drawing.Size(40, 40);
            this.BT_Salir.TabIndex = 27;
            this.BT_Salir.UseVisualStyleBackColor = true;
            this.BT_Salir.Click += new System.EventHandler(this.BT_Salir_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 18);
            this.label1.TabIndex = 6;
            this.label1.Text = "Año:";
            // 
            // TentativoListaCursos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(803, 589);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "TentativoListaCursos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrilla)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private Label LBPerfil;
        private Panel panel2;
        private Panel panel3;
        private Button BT_Salir;
        private Label label1;
        private TextBox txtAnio;
        private DataGridView dgvGrilla;
        private DataGridViewTextBoxColumn Curso;
        private DataGridViewTextBoxColumn Descripcion;
        private DataGridViewTextBoxColumn Personas;
        private DataGridViewTextBoxColumn Horas;
        private DataGridViewTextBoxColumn Cursada;
        private DataGridViewTextBoxColumn Resta;
        private DataGridViewTextBoxColumn Mes1;
        private DataGridViewTextBoxColumn Mes2;
        private DataGridViewTextBoxColumn Mes3;
        private DataGridViewTextBoxColumn Mes4;
        private DataGridViewTextBoxColumn Mes5;
        private DataGridViewTextBoxColumn Mes6;
        private DataGridViewTextBoxColumn Mes7;
        private DataGridViewTextBoxColumn Mes8;
        private DataGridViewTextBoxColumn Mes9;
        private DataGridViewTextBoxColumn Mes10;
        private DataGridViewTextBoxColumn Mes11;
        private DataGridViewTextBoxColumn Mes12;
    }
}