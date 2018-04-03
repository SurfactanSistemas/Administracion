namespace Modulo_Capacitacion.Novedades
{
    partial class IngresoDeCursosRealizados
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
            this.LBPerfil = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.DGV_Legajos = new System.Windows.Forms.DataGridView();
            this.TB_Instruc = new System.Windows.Forms.TextBox();
            this.TB_Temas = new System.Windows.Forms.TextBox();
            this.BT_Salir = new System.Windows.Forms.Button();
            this.BT_LimpiarPant = new System.Windows.Forms.Button();
            this.BT_Guardar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.LFechaAviso = new System.Windows.Forms.Label();
            this.TB_Codigo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.TB_Actividad = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TB_CodTema = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.TB_DesCurso = new System.Windows.Forms.TextBox();
            this.DTP_Fecha = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.TB_Horas = new System.Windows.Forms.TextBox();
            this.CB_TipoI = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.CB_Tipo2 = new System.Windows.Forms.ComboBox();
            this.TB_CodCurso = new System.Windows.Forms.TextBox();
            this.TB_DescTema = new System.Windows.Forms.TextBox();
            this.Legajo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Observaciones = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Legajos)).BeginInit();
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
            this.LBPerfil.Size = new System.Drawing.Size(465, 19);
            this.LBPerfil.TabIndex = 0;
            this.LBPerfil.Text = "INGRESO DE PLANIFICACION ANUAL DE CAPACITACION POR LEGAJO";
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
            this.panel3.Controls.Add(this.TB_DescTema);
            this.panel3.Controls.Add(this.TB_CodCurso);
            this.panel3.Controls.Add(this.CB_Tipo2);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.CB_TipoI);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.TB_Horas);
            this.panel3.Controls.Add(this.DTP_Fecha);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.TB_DesCurso);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.TB_CodTema);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.TB_Actividad);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.DGV_Legajos);
            this.panel3.Controls.Add(this.TB_Instruc);
            this.panel3.Controls.Add(this.TB_Temas);
            this.panel3.Controls.Add(this.BT_Salir);
            this.panel3.Controls.Add(this.BT_LimpiarPant);
            this.panel3.Controls.Add(this.BT_Guardar);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.LFechaAviso);
            this.panel3.Controls.Add(this.TB_Codigo);
            this.panel3.Location = new System.Drawing.Point(7, 6);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(790, 540);
            this.panel3.TabIndex = 3;
            // 
            // DGV_Legajos
            // 
            this.DGV_Legajos.AllowUserToAddRows = false;
            this.DGV_Legajos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.DGV_Legajos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.DGV_Legajos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_Legajos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Legajo,
            this.Descripcion,
            this.Observaciones});
            this.DGV_Legajos.Location = new System.Drawing.Point(13, 152);
            this.DGV_Legajos.Name = "DGV_Legajos";
            this.DGV_Legajos.Size = new System.Drawing.Size(760, 318);
            this.DGV_Legajos.TabIndex = 36;
            // 
            // TB_Instruc
            // 
            this.TB_Instruc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TB_Instruc.Location = new System.Drawing.Point(79, 83);
            this.TB_Instruc.Name = "TB_Instruc";
            this.TB_Instruc.Size = new System.Drawing.Size(274, 20);
            this.TB_Instruc.TabIndex = 35;
            // 
            // TB_Temas
            // 
            this.TB_Temas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TB_Temas.Location = new System.Drawing.Point(79, 117);
            this.TB_Temas.Name = "TB_Temas";
            this.TB_Temas.Size = new System.Drawing.Size(695, 20);
            this.TB_Temas.TabIndex = 34;
            // 
            // BT_Salir
            // 
            this.BT_Salir.BackgroundImage = global::Modulo_Capacitacion.Properties.Resources.apagar1;
            this.BT_Salir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BT_Salir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BT_Salir.ForeColor = System.Drawing.SystemColors.Control;
            this.BT_Salir.Location = new System.Drawing.Point(454, 488);
            this.BT_Salir.Name = "BT_Salir";
            this.BT_Salir.Size = new System.Drawing.Size(40, 40);
            this.BT_Salir.TabIndex = 27;
            this.BT_Salir.UseVisualStyleBackColor = true;
            // 
            // BT_LimpiarPant
            // 
            this.BT_LimpiarPant.BackgroundImage = global::Modulo_Capacitacion.Properties.Resources.limpiar;
            this.BT_LimpiarPant.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BT_LimpiarPant.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BT_LimpiarPant.ForeColor = System.Drawing.SystemColors.Control;
            this.BT_LimpiarPant.Location = new System.Drawing.Point(371, 484);
            this.BT_LimpiarPant.Margin = new System.Windows.Forms.Padding(0);
            this.BT_LimpiarPant.Name = "BT_LimpiarPant";
            this.BT_LimpiarPant.Size = new System.Drawing.Size(40, 40);
            this.BT_LimpiarPant.TabIndex = 26;
            this.BT_LimpiarPant.UseVisualStyleBackColor = true;
            // 
            // BT_Guardar
            // 
            this.BT_Guardar.BackgroundImage = global::Modulo_Capacitacion.Properties.Resources.grabar;
            this.BT_Guardar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BT_Guardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BT_Guardar.ForeColor = System.Drawing.SystemColors.Control;
            this.BT_Guardar.Location = new System.Drawing.Point(288, 488);
            this.BT_Guardar.Margin = new System.Windows.Forms.Padding(0);
            this.BT_Guardar.Name = "BT_Guardar";
            this.BT_Guardar.Size = new System.Drawing.Size(40, 40);
            this.BT_Guardar.TabIndex = 25;
            this.BT_Guardar.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 18);
            this.label1.TabIndex = 6;
            this.label1.Text = "Fecha";
            // 
            // LFechaAviso
            // 
            this.LFechaAviso.AutoSize = true;
            this.LFechaAviso.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LFechaAviso.Location = new System.Drawing.Point(10, 20);
            this.LFechaAviso.Name = "LFechaAviso";
            this.LFechaAviso.Size = new System.Drawing.Size(55, 18);
            this.LFechaAviso.TabIndex = 4;
            this.LFechaAviso.Text = "Codigo:";
            // 
            // TB_Codigo
            // 
            this.TB_Codigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TB_Codigo.Location = new System.Drawing.Point(79, 19);
            this.TB_Codigo.Name = "TB_Codigo";
            this.TB_Codigo.Size = new System.Drawing.Size(54, 20);
            this.TB_Codigo.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(10, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 18);
            this.label2.TabIndex = 37;
            this.label2.Text = "Instructor";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(10, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 18);
            this.label3.TabIndex = 38;
            this.label3.Text = "Temas";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(375, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 18);
            this.label4.TabIndex = 40;
            this.label4.Text = "Actividad";
            // 
            // TB_Actividad
            // 
            this.TB_Actividad.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TB_Actividad.Location = new System.Drawing.Point(443, 83);
            this.TB_Actividad.Name = "TB_Actividad";
            this.TB_Actividad.Size = new System.Drawing.Size(274, 20);
            this.TB_Actividad.TabIndex = 39;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(142, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 18);
            this.label5.TabIndex = 42;
            this.label5.Text = "Tema:";
            // 
            // TB_CodTema
            // 
            this.TB_CodTema.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TB_CodTema.Location = new System.Drawing.Point(196, 19);
            this.TB_CodTema.Name = "TB_CodTema";
            this.TB_CodTema.Size = new System.Drawing.Size(42, 20);
            this.TB_CodTema.TabIndex = 41;
            this.TB_CodTema.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TB_CodTema_KeyDown);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(461, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 18);
            this.label6.TabIndex = 44;
            this.label6.Text = "Curso";
            // 
            // TB_DesCurso
            // 
            this.TB_DesCurso.Enabled = false;
            this.TB_DesCurso.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TB_DesCurso.Location = new System.Drawing.Point(559, 19);
            this.TB_DesCurso.Name = "TB_DesCurso";
            this.TB_DesCurso.ReadOnly = true;
            this.TB_DesCurso.Size = new System.Drawing.Size(215, 20);
            this.TB_DesCurso.TabIndex = 43;
            // 
            // DTP_Fecha
            // 
            this.DTP_Fecha.Location = new System.Drawing.Point(79, 53);
            this.DTP_Fecha.Name = "DTP_Fecha";
            this.DTP_Fecha.Size = new System.Drawing.Size(129, 20);
            this.DTP_Fecha.TabIndex = 45;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(217, 54);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 18);
            this.label7.TabIndex = 46;
            this.label7.Text = "Horas";
            // 
            // TB_Horas
            // 
            this.TB_Horas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TB_Horas.Location = new System.Drawing.Point(286, 53);
            this.TB_Horas.Name = "TB_Horas";
            this.TB_Horas.Size = new System.Drawing.Size(54, 20);
            this.TB_Horas.TabIndex = 47;
            this.TB_Horas.Text = "1";
            // 
            // CB_TipoI
            // 
            this.CB_TipoI.FormattingEnabled = true;
            this.CB_TipoI.Items.AddRange(new object[] {
            "Interna",
            "Externa"});
            this.CB_TipoI.Location = new System.Drawing.Point(419, 53);
            this.CB_TipoI.Name = "CB_TipoI";
            this.CB_TipoI.Size = new System.Drawing.Size(121, 21);
            this.CB_TipoI.TabIndex = 48;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(363, 54);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 18);
            this.label8.TabIndex = 49;
            this.label8.Text = "Tipo";
            // 
            // CB_Tipo2
            // 
            this.CB_Tipo2.FormattingEnabled = true;
            this.CB_Tipo2.Items.AddRange(new object[] {
            "Programada",
            "No Programada"});
            this.CB_Tipo2.Location = new System.Drawing.Point(547, 53);
            this.CB_Tipo2.Name = "CB_Tipo2";
            this.CB_Tipo2.Size = new System.Drawing.Size(121, 21);
            this.CB_Tipo2.TabIndex = 50;
            // 
            // TB_CodCurso
            // 
            this.TB_CodCurso.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TB_CodCurso.Location = new System.Drawing.Point(513, 19);
            this.TB_CodCurso.Name = "TB_CodCurso";
            this.TB_CodCurso.Size = new System.Drawing.Size(42, 20);
            this.TB_CodCurso.TabIndex = 51;
            this.TB_CodCurso.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TB_CodCurso_KeyDown);
            // 
            // TB_DescTema
            // 
            this.TB_DescTema.Enabled = false;
            this.TB_DescTema.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TB_DescTema.Location = new System.Drawing.Point(244, 19);
            this.TB_DescTema.Name = "TB_DescTema";
            this.TB_DescTema.ReadOnly = true;
            this.TB_DescTema.Size = new System.Drawing.Size(215, 20);
            this.TB_DescTema.TabIndex = 52;
            // 
            // Legajo
            // 
            this.Legajo.DataPropertyName = "Legajo";
            this.Legajo.HeaderText = "Legajo";
            this.Legajo.Name = "Legajo";
            this.Legajo.Width = 64;
            // 
            // Descripcion
            // 
            this.Descripcion.DataPropertyName = "Descripcion";
            this.Descripcion.HeaderText = "Nombre";
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.Width = 69;
            // 
            // Observaciones
            // 
            this.Observaciones.DataPropertyName = "Observaciones";
            this.Observaciones.HeaderText = "Observaciones";
            this.Observaciones.Name = "Observaciones";
            this.Observaciones.Width = 103;
            // 
            // IngresoDeCursosRealizados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(803, 589);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "IngresoDeCursosRealizados";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Legajos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label LBPerfil;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox TB_Temas;
        private System.Windows.Forms.Button BT_Salir;
        private System.Windows.Forms.Button BT_LimpiarPant;
        private System.Windows.Forms.Button BT_Guardar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LFechaAviso;
        private System.Windows.Forms.TextBox TB_Codigo;
        private System.Windows.Forms.TextBox TB_Instruc;
        private System.Windows.Forms.DataGridView DGV_Legajos;
        private System.Windows.Forms.TextBox TB_DescTema;
        private System.Windows.Forms.TextBox TB_CodCurso;
        private System.Windows.Forms.ComboBox CB_Tipo2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox CB_TipoI;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox TB_Horas;
        private System.Windows.Forms.DateTimePicker DTP_Fecha;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TB_DesCurso;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TB_CodTema;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TB_Actividad;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Legajo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Observaciones;
    }
}