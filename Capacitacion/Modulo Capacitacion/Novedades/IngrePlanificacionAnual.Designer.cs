using System.ComponentModel;
using System.Windows.Forms;

namespace Modulo_Capacitacion.Novedades
{
    partial class IngrePlanificacionAnual
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle27 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle28 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle25 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle26 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.LBPerfil = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel11 = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.label14 = new System.Windows.Forms.Label();
            this.TB_CodTemas = new System.Windows.Forms.ComboBox();
            this.CB_Curso = new System.Windows.Forms.ComboBox();
            this.TB_DescTemas = new System.Windows.Forms.ComboBox();
            this.LB_Curso = new System.Windows.Forms.Label();
            this.lblAtencion = new System.Windows.Forms.Label();
            this.DGV_Crono = new System.Windows.Forms.DataGridView();
            this.Tema = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DesTema = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Curso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DesCurso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Horas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Realizado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TB_Buscar = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.TB_DesLegajob = new System.Windows.Forms.ComboBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.TB_CodLegajob = new System.Windows.Forms.ComboBox();
            this.TB_Año = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.LFechaAviso = new System.Windows.Forms.Label();
            this.TB_DesLegajo = new System.Windows.Forms.TextBox();
            this.BT_AgregarCurso = new System.Windows.Forms.Button();
            this.BT_LimpiarPant = new System.Windows.Forms.Button();
            this.BT_Guardar = new System.Windows.Forms.Button();
            this.BT_Salir = new System.Windows.Forms.Button();
            this.TB_CodLegajo = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Crono)).BeginInit();
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
            this.panel3.Controls.Add(this.TB_CodLegajo);
            this.panel3.Controls.Add(this.TB_DesLegajo);
            this.panel3.Controls.Add(this.groupBox1);
            this.panel3.Controls.Add(this.lblAtencion);
            this.panel3.Controls.Add(this.DGV_Crono);
            this.panel3.Controls.Add(this.TB_Buscar);
            this.panel3.Controls.Add(this.BT_LimpiarPant);
            this.panel3.Controls.Add(this.BT_Guardar);
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Controls.Add(this.TB_DesLegajob);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Controls.Add(this.TB_CodLegajob);
            this.panel3.Controls.Add(this.TB_Año);
            this.panel3.Controls.Add(this.BT_Salir);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.LFechaAviso);
            this.panel3.Location = new System.Drawing.Point(7, 6);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(790, 550);
            this.panel3.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel11);
            this.groupBox1.Controls.Add(this.panel10);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.TB_CodTemas);
            this.groupBox1.Controls.Add(this.CB_Curso);
            this.groupBox1.Controls.Add(this.TB_DescTemas);
            this.groupBox1.Controls.Add(this.LB_Curso);
            this.groupBox1.Controls.Add(this.BT_AgregarCurso);
            this.groupBox1.Location = new System.Drawing.Point(61, 387);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(668, 110);
            this.groupBox1.TabIndex = 144;
            this.groupBox1.TabStop = false;
            // 
            // panel11
            // 
            this.panel11.Location = new System.Drawing.Point(143, 19);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(19, 29);
            this.panel11.TabIndex = 136;
            // 
            // panel10
            // 
            this.panel10.Location = new System.Drawing.Point(530, 21);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(19, 29);
            this.panel10.TabIndex = 138;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(44, 24);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(45, 18);
            this.label14.TabIndex = 134;
            this.label14.Text = "Tema:";
            // 
            // TB_CodTemas
            // 
            this.TB_CodTemas.FormattingEnabled = true;
            this.TB_CodTemas.Location = new System.Drawing.Point(104, 25);
            this.TB_CodTemas.Name = "TB_CodTemas";
            this.TB_CodTemas.Size = new System.Drawing.Size(37, 21);
            this.TB_CodTemas.TabIndex = 135;
            // 
            // CB_Curso
            // 
            this.CB_Curso.FormattingEnabled = true;
            this.CB_Curso.Location = new System.Drawing.Point(168, 72);
            this.CB_Curso.Name = "CB_Curso";
            this.CB_Curso.Size = new System.Drawing.Size(326, 21);
            this.CB_Curso.TabIndex = 141;
            this.CB_Curso.Visible = false;
            // 
            // TB_DescTemas
            // 
            this.TB_DescTemas.FormattingEnabled = true;
            this.TB_DescTemas.Location = new System.Drawing.Point(168, 25);
            this.TB_DescTemas.Name = "TB_DescTemas";
            this.TB_DescTemas.Size = new System.Drawing.Size(375, 21);
            this.TB_DescTemas.TabIndex = 137;
            this.TB_DescTemas.SelectedIndexChanged += new System.EventHandler(this.TB_DescTemas_SelectedIndexChanged);
            // 
            // LB_Curso
            // 
            this.LB_Curso.AutoSize = true;
            this.LB_Curso.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LB_Curso.Location = new System.Drawing.Point(94, 73);
            this.LB_Curso.Name = "LB_Curso";
            this.LB_Curso.Size = new System.Drawing.Size(47, 18);
            this.LB_Curso.TabIndex = 140;
            this.LB_Curso.Text = "Curso:";
            this.LB_Curso.Visible = false;
            // 
            // lblAtencion
            // 
            this.lblAtencion.BackColor = System.Drawing.Color.Red;
            this.lblAtencion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblAtencion.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.lblAtencion.ForeColor = System.Drawing.SystemColors.Control;
            this.lblAtencion.Location = new System.Drawing.Point(457, 16);
            this.lblAtencion.Name = "lblAtencion";
            this.lblAtencion.Size = new System.Drawing.Size(320, 78);
            this.lblAtencion.TabIndex = 143;
            this.lblAtencion.Text = "ESTOS CURSOS NO SE ENCUENTRAN GRABADOS, SE LOS TRAE DE MANERA AUTOMATICA DESDE EL" +
                " \'MAESTRO\' DE LEGAJOS.";
            this.lblAtencion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblAtencion.Visible = false;
            // 
            // DGV_Crono
            // 
            this.DGV_Crono.AllowUserToAddRows = false;
            this.DGV_Crono.AllowUserToDeleteRows = false;
            this.DGV_Crono.AllowUserToResizeRows = false;
            this.DGV_Crono.ColumnHeadersHeight = 25;
            this.DGV_Crono.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Tema,
            this.DesTema,
            this.Curso,
            this.DesCurso,
            this.Horas,
            this.Realizado});
            this.DGV_Crono.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.DGV_Crono.Location = new System.Drawing.Point(8, 103);
            this.DGV_Crono.Margin = new System.Windows.Forms.Padding(0);
            this.DGV_Crono.Name = "DGV_Crono";
            this.DGV_Crono.ReadOnly = true;
            dataGridViewCellStyle27.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle27.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle27.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle27.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle27.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            dataGridViewCellStyle27.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle27.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle27.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV_Crono.RowHeadersDefaultCellStyle = dataGridViewCellStyle27;
            this.DGV_Crono.RowHeadersWidth = 15;
            dataGridViewCellStyle28.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.DGV_Crono.RowsDefaultCellStyle = dataGridViewCellStyle28;
            this.DGV_Crono.RowTemplate.Height = 18;
            this.DGV_Crono.ShowCellToolTips = false;
            this.DGV_Crono.Size = new System.Drawing.Size(775, 266);
            this.DGV_Crono.TabIndex = 142;
            this.DGV_Crono.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DGV_Crono_CellMouseDoubleClick);
            this.DGV_Crono.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DGV_Crono_RowHeaderMouseDoubleClick);
            // 
            // Tema
            // 
            this.Tema.DataPropertyName = "Tema";
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Tema.DefaultCellStyle = dataGridViewCellStyle22;
            this.Tema.HeaderText = "Tema";
            this.Tema.Name = "Tema";
            this.Tema.ReadOnly = true;
            this.Tema.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.Tema.Width = 50;
            // 
            // DesTema
            // 
            this.DesTema.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DesTema.DataPropertyName = "DesTema";
            this.DesTema.HeaderText = "Descripcion Tema";
            this.DesTema.Name = "DesTema";
            this.DesTema.ReadOnly = true;
            // 
            // Curso
            // 
            this.Curso.DataPropertyName = "Curso";
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle23.NullValue = "0";
            this.Curso.DefaultCellStyle = dataGridViewCellStyle23;
            this.Curso.HeaderText = "Curso";
            this.Curso.Name = "Curso";
            this.Curso.ReadOnly = true;
            this.Curso.Width = 50;
            // 
            // DesCurso
            // 
            this.DesCurso.DataPropertyName = "DesCurso";
            dataGridViewCellStyle24.NullValue = " ";
            this.DesCurso.DefaultCellStyle = dataGridViewCellStyle24;
            this.DesCurso.HeaderText = "Descripcion Curso";
            this.DesCurso.Name = "DesCurso";
            this.DesCurso.ReadOnly = true;
            this.DesCurso.Width = 250;
            // 
            // Horas
            // 
            this.Horas.DataPropertyName = "Horas";
            dataGridViewCellStyle25.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Horas.DefaultCellStyle = dataGridViewCellStyle25;
            this.Horas.HeaderText = "Horas";
            this.Horas.Name = "Horas";
            this.Horas.ReadOnly = true;
            this.Horas.Width = 50;
            // 
            // Realizado
            // 
            this.Realizado.DataPropertyName = "Realizado";
            dataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Realizado.DefaultCellStyle = dataGridViewCellStyle26;
            this.Realizado.HeaderText = "Realizado";
            this.Realizado.Name = "Realizado";
            this.Realizado.ReadOnly = true;
            this.Realizado.Width = 70;
            // 
            // TB_Buscar
            // 
            this.TB_Buscar.Location = new System.Drawing.Point(167, 52);
            this.TB_Buscar.Name = "TB_Buscar";
            this.TB_Buscar.Size = new System.Drawing.Size(75, 23);
            this.TB_Buscar.TabIndex = 133;
            this.TB_Buscar.Text = "Buscar";
            this.TB_Buscar.UseVisualStyleBackColor = true;
            this.TB_Buscar.Click += new System.EventHandler(this.TB_Buscar_Click);
            // 
            // panel5
            // 
            this.panel5.Location = new System.Drawing.Point(422, 16);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(19, 29);
            this.panel5.TabIndex = 130;
            // 
            // TB_DesLegajob
            // 
            this.TB_DesLegajob.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.TB_DesLegajob.FormattingEnabled = true;
            this.TB_DesLegajob.Location = new System.Drawing.Point(401, 79);
            this.TB_DesLegajob.Name = "TB_DesLegajob";
            this.TB_DesLegajob.Size = new System.Drawing.Size(19, 21);
            this.TB_DesLegajob.TabIndex = 129;
            this.TB_DesLegajob.Visible = false;
            this.TB_DesLegajob.SelectedIndexChanged += new System.EventHandler(this.TB_DesLegajo_SelectedIndexChanged);
            // 
            // panel4
            // 
            this.panel4.Location = new System.Drawing.Point(143, 16);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(19, 29);
            this.panel4.TabIndex = 128;
            // 
            // TB_CodLegajob
            // 
            this.TB_CodLegajob.FormattingEnabled = true;
            this.TB_CodLegajob.Location = new System.Drawing.Point(422, 80);
            this.TB_CodLegajob.Name = "TB_CodLegajob";
            this.TB_CodLegajob.Size = new System.Drawing.Size(10, 21);
            this.TB_CodLegajob.TabIndex = 127;
            this.TB_CodLegajob.Visible = false;
            this.TB_CodLegajob.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TB_CodLegajo_KeyDown);
            this.TB_CodLegajob.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.TB_CodLegajo_MouseDoubleClick);
            // 
            // TB_Año
            // 
            this.TB_Año.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TB_Año.Location = new System.Drawing.Point(83, 54);
            this.TB_Año.Name = "TB_Año";
            this.TB_Año.Size = new System.Drawing.Size(54, 20);
            this.TB_Año.TabIndex = 35;
            this.TB_Año.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TB_Año.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TB_Año_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 18);
            this.label1.TabIndex = 6;
            this.label1.Text = "Año:";
            // 
            // LFechaAviso
            // 
            this.LFechaAviso.AutoSize = true;
            this.LFechaAviso.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LFechaAviso.Location = new System.Drawing.Point(14, 21);
            this.LFechaAviso.Name = "LFechaAviso";
            this.LFechaAviso.Size = new System.Drawing.Size(52, 18);
            this.LFechaAviso.TabIndex = 4;
            this.LFechaAviso.Text = "Legajo:";
            // 
            // TB_DesLegajo
            // 
            this.TB_DesLegajo.Location = new System.Drawing.Point(171, 20);
            this.TB_DesLegajo.Name = "TB_DesLegajo";
            this.TB_DesLegajo.Size = new System.Drawing.Size(249, 20);
            this.TB_DesLegajo.TabIndex = 145;
            this.TB_DesLegajo.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.TB_DesLegajo_MouseDoubleClick);
            // 
            // BT_AgregarCurso
            // 
            this.BT_AgregarCurso.BackgroundImage = global::Modulo_Capacitacion.Properties.Resources.agregar_cursos;
            this.BT_AgregarCurso.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BT_AgregarCurso.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BT_AgregarCurso.ForeColor = System.Drawing.SystemColors.Control;
            this.BT_AgregarCurso.Location = new System.Drawing.Point(585, 37);
            this.BT_AgregarCurso.Margin = new System.Windows.Forms.Padding(0);
            this.BT_AgregarCurso.Name = "BT_AgregarCurso";
            this.BT_AgregarCurso.Size = new System.Drawing.Size(40, 40);
            this.BT_AgregarCurso.TabIndex = 139;
            this.BT_AgregarCurso.UseVisualStyleBackColor = true;
            this.BT_AgregarCurso.Click += new System.EventHandler(this.BT_AgregarCurso_Click);
            // 
            // BT_LimpiarPant
            // 
            this.BT_LimpiarPant.BackgroundImage = global::Modulo_Capacitacion.Properties.Resources.limpiar;
            this.BT_LimpiarPant.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BT_LimpiarPant.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BT_LimpiarPant.ForeColor = System.Drawing.SystemColors.Control;
            this.BT_LimpiarPant.Location = new System.Drawing.Point(374, 502);
            this.BT_LimpiarPant.Margin = new System.Windows.Forms.Padding(0);
            this.BT_LimpiarPant.Name = "BT_LimpiarPant";
            this.BT_LimpiarPant.Size = new System.Drawing.Size(40, 40);
            this.BT_LimpiarPant.TabIndex = 132;
            this.BT_LimpiarPant.UseVisualStyleBackColor = true;
            this.BT_LimpiarPant.Click += new System.EventHandler(this.BT_LimpiarPant_Click);
            // 
            // BT_Guardar
            // 
            this.BT_Guardar.BackgroundImage = global::Modulo_Capacitacion.Properties.Resources.Aceptar_N2;
            this.BT_Guardar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BT_Guardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BT_Guardar.ForeColor = System.Drawing.SystemColors.Control;
            this.BT_Guardar.Location = new System.Drawing.Point(290, 502);
            this.BT_Guardar.Margin = new System.Windows.Forms.Padding(0);
            this.BT_Guardar.Name = "BT_Guardar";
            this.BT_Guardar.Size = new System.Drawing.Size(40, 40);
            this.BT_Guardar.TabIndex = 131;
            this.BT_Guardar.UseVisualStyleBackColor = true;
            this.BT_Guardar.Click += new System.EventHandler(this.BT_Guardar_Click);
            // 
            // BT_Salir
            // 
            this.BT_Salir.BackgroundImage = global::Modulo_Capacitacion.Properties.Resources.apagar1;
            this.BT_Salir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BT_Salir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BT_Salir.ForeColor = System.Drawing.SystemColors.Control;
            this.BT_Salir.Location = new System.Drawing.Point(460, 502);
            this.BT_Salir.Name = "BT_Salir";
            this.BT_Salir.Size = new System.Drawing.Size(40, 40);
            this.BT_Salir.TabIndex = 27;
            this.BT_Salir.UseVisualStyleBackColor = true;
            this.BT_Salir.Click += new System.EventHandler(this.BT_Salir_Click);
            // 
            // TB_CodLegajo
            // 
            this.TB_CodLegajo.Location = new System.Drawing.Point(83, 19);
            this.TB_CodLegajo.Name = "TB_CodLegajo";
            this.TB_CodLegajo.Size = new System.Drawing.Size(54, 20);
            this.TB_CodLegajo.TabIndex = 145;
            this.TB_CodLegajo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TB_CodLegajo_KeyDown);
            this.TB_CodLegajo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SoloNumeros);
            this.TB_CodLegajo.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.TB_DesLegajo_MouseDoubleClick);
            // 
            // IngrePlanificacionAnual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(803, 602);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "IngrePlanificacionAnual";
            this.Load += new System.EventHandler(this.IngrePlanificacionAnual_Load);
            this.Shown += new System.EventHandler(this.IngrePlanificacionAnual_Shown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Crono)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private Label LBPerfil;
        private Panel panel2;
        private Panel panel3;
        private Button BT_Salir;
        private Label label1;
        private Label LFechaAviso;
        private TextBox TB_Año;
        private Panel panel5;
        private ComboBox TB_DesLegajob;
        private Panel panel4;
        private ComboBox TB_CodLegajob;
        private Button BT_LimpiarPant;
        private Button BT_Guardar;
        private Button TB_Buscar;
        private Panel panel10;
        private ComboBox TB_DescTemas;
        private Panel panel11;
        private ComboBox TB_CodTemas;
        private Label label14;
        private Button BT_AgregarCurso;
        private ComboBox CB_Curso;
        private Label LB_Curso;
        private DataGridView DGV_Crono;
        private Label lblAtencion;
        private GroupBox groupBox1;
        private DataGridViewTextBoxColumn Tema;
        private DataGridViewTextBoxColumn DesTema;
        private DataGridViewTextBoxColumn Curso;
        private DataGridViewTextBoxColumn DesCurso;
        private DataGridViewTextBoxColumn Horas;
        private DataGridViewTextBoxColumn Realizado;
        private TextBox TB_DesLegajo;
        private TextBox TB_CodLegajo;
    }
}