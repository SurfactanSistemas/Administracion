using System.ComponentModel;
using System.Windows.Forms;

namespace Modulo_Capacitacion.Novedades
{
    partial class ActualizacionDeCompetenciasYNecesidadesDeCapacitacion
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.LBPerfil = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.BT_Guardar = new System.Windows.Forms.Button();
            this.BT_Limpiar = new System.Windows.Forms.Button();
            this.BT_Salir = new System.Windows.Forms.Button();
            this.btnAyuda = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbSector = new System.Windows.Forms.RadioButton();
            this.rbPerfil = new System.Windows.Forms.RadioButton();
            this.cmbOrganizar = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDescTema = new System.Windows.Forms.TextBox();
            this.txtTema = new System.Windows.Forms.TextBox();
            this.dgvGrilla = new System.Windows.Forms.DataGridView();
            this.Clave = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Perfil = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DescPerfil = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Legajo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Curso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DescCurso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Necesario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Deseable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idCalificacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idCalificacionAnterior = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Calificacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Observaciones = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MarcarActualizacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Marca = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlAyuda = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.btnCerrarAyuda = new System.Windows.Forms.Button();
            this.gbAyuda = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFiltrar = new System.Windows.Forms.TextBox();
            this.dgvAyuda = new System.Windows.Forms.DataGridView();
            this.pnlProgreso = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.cmbAuxi = new System.Windows.Forms.ComboBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrilla)).BeginInit();
            this.pnlAyuda.SuspendLayout();
            this.panel6.SuspendLayout();
            this.gbAyuda.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAyuda)).BeginInit();
            this.pnlProgreso.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(139)))), ((int)(((byte)(82)))));
            this.panel1.Controls.Add(this.LBPerfil);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(870, 39);
            this.panel1.TabIndex = 7;
            // 
            // LBPerfil
            // 
            this.LBPerfil.AutoSize = true;
            this.LBPerfil.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBPerfil.ForeColor = System.Drawing.Color.White;
            this.LBPerfil.Location = new System.Drawing.Point(22, 11);
            this.LBPerfil.Name = "LBPerfil";
            this.LBPerfil.Size = new System.Drawing.Size(485, 19);
            this.LBPerfil.TabIndex = 0;
            this.LBPerfil.Text = "ACTUALIZACIÓN DE COMPETENCIAS Y NECESIDADES DE CAPACITACIÓN";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(74)))), ((int)(((byte)(95)))));
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 39);
            this.panel2.Margin = new System.Windows.Forms.Padding(30);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(870, 550);
            this.panel2.TabIndex = 8;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.Control;
            this.panel3.Controls.Add(this.tableLayoutPanel1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(30);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(870, 550);
            this.panel3.TabIndex = 3;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel4, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel5, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dgvGrilla, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 82F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 69F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(870, 550);
            this.tableLayoutPanel1.TabIndex = 28;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.button1);
            this.panel4.Controls.Add(this.BT_Guardar);
            this.panel4.Controls.Add(this.BT_Limpiar);
            this.panel4.Controls.Add(this.BT_Salir);
            this.panel4.Controls.Add(this.btnAyuda);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(3, 484);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(864, 63);
            this.panel4.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button1.Location = new System.Drawing.Point(9, 11);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(147, 40);
            this.button1.TabIndex = 27;
            this.button1.Text = "Limpiar Todas las Marcas";
            this.toolTip1.SetToolTip(this.button1, "Elimina todas las marcas de los legajos actualizados hasta la fecha");
            this.button1.UseVisualStyleBackColor = true;
            // 
            // BT_Guardar
            // 
            this.BT_Guardar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.BT_Guardar.BackgroundImage = global::Modulo_Capacitacion.Properties.Resources.Aceptar_N2;
            this.BT_Guardar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BT_Guardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BT_Guardar.ForeColor = System.Drawing.SystemColors.Control;
            this.BT_Guardar.Location = new System.Drawing.Point(289, 11);
            this.BT_Guardar.Name = "BT_Guardar";
            this.BT_Guardar.Size = new System.Drawing.Size(40, 40);
            this.BT_Guardar.TabIndex = 27;
            this.toolTip1.SetToolTip(this.BT_Guardar, "Grabar Actualizaciones");
            this.BT_Guardar.UseVisualStyleBackColor = true;
            this.BT_Guardar.Click += new System.EventHandler(this.BT_Guardar_Click);
            // 
            // BT_Limpiar
            // 
            this.BT_Limpiar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.BT_Limpiar.BackgroundImage = global::Modulo_Capacitacion.Properties.Resources.limpiar;
            this.BT_Limpiar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BT_Limpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BT_Limpiar.ForeColor = System.Drawing.SystemColors.Control;
            this.BT_Limpiar.Location = new System.Drawing.Point(412, 11);
            this.BT_Limpiar.Name = "BT_Limpiar";
            this.BT_Limpiar.Size = new System.Drawing.Size(40, 40);
            this.BT_Limpiar.TabIndex = 27;
            this.toolTip1.SetToolTip(this.BT_Limpiar, "Limpiar Pantalla");
            this.BT_Limpiar.UseVisualStyleBackColor = true;
            this.BT_Limpiar.Click += new System.EventHandler(this.BT_LimpiarPant_Click);
            // 
            // BT_Salir
            // 
            this.BT_Salir.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.BT_Salir.BackgroundImage = global::Modulo_Capacitacion.Properties.Resources.apagar1;
            this.BT_Salir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BT_Salir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BT_Salir.ForeColor = System.Drawing.SystemColors.Control;
            this.BT_Salir.Location = new System.Drawing.Point(535, 11);
            this.BT_Salir.Name = "BT_Salir";
            this.BT_Salir.Size = new System.Drawing.Size(40, 40);
            this.BT_Salir.TabIndex = 27;
            this.toolTip1.SetToolTip(this.BT_Salir, "Salir del Formulario");
            this.BT_Salir.UseVisualStyleBackColor = true;
            this.BT_Salir.Click += new System.EventHandler(this.BT_Salir_Click);
            // 
            // btnAyuda
            // 
            this.btnAyuda.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnAyuda.BackgroundImage = global::Modulo_Capacitacion.Properties.Resources.Consulta_Dat_N1;
            this.btnAyuda.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAyuda.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAyuda.ForeColor = System.Drawing.SystemColors.Control;
            this.btnAyuda.Location = new System.Drawing.Point(780, 11);
            this.btnAyuda.Name = "btnAyuda";
            this.btnAyuda.Size = new System.Drawing.Size(40, 40);
            this.btnAyuda.TabIndex = 27;
            this.btnAyuda.UseVisualStyleBackColor = true;
            this.btnAyuda.Visible = false;
            this.btnAyuda.Click += new System.EventHandler(this.btnAyuda_Click);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.groupBox1);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(10, 3);
            this.panel5.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(850, 76);
            this.panel5.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnBuscar);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtDescTema);
            this.groupBox1.Controls.Add(this.txtTema);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(850, 76);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnBuscar.BackgroundImage = global::Modulo_Capacitacion.Properties.Resources.Consulta_Dat_N1;
            this.btnBuscar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.ForeColor = System.Drawing.SystemColors.Control;
            this.btnBuscar.Location = new System.Drawing.Point(619, 13);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(54, 55);
            this.btnBuscar.TabIndex = 29;
            this.toolTip1.SetToolTip(this.btnBuscar, "Procesar Búsqueda");
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtCodigo);
            this.groupBox2.Controls.Add(this.rbSector);
            this.groupBox2.Controls.Add(this.rbPerfil);
            this.groupBox2.Controls.Add(this.cmbOrganizar);
            this.groupBox2.Location = new System.Drawing.Point(32, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(577, 53);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Organizar Por:";
            // 
            // rbSector
            // 
            this.rbSector.AutoSize = true;
            this.rbSector.Location = new System.Drawing.Point(137, 22);
            this.rbSector.Name = "rbSector";
            this.rbSector.Size = new System.Drawing.Size(56, 17);
            this.rbSector.TabIndex = 3;
            this.rbSector.Text = "Sector";
            this.rbSector.UseVisualStyleBackColor = true;
            this.rbSector.Click += new System.EventHandler(this.rbSector_Click);
            // 
            // rbPerfil
            // 
            this.rbPerfil.AutoSize = true;
            this.rbPerfil.Checked = true;
            this.rbPerfil.Location = new System.Drawing.Point(55, 22);
            this.rbPerfil.Name = "rbPerfil";
            this.rbPerfil.Size = new System.Drawing.Size(48, 17);
            this.rbPerfil.TabIndex = 3;
            this.rbPerfil.TabStop = true;
            this.rbPerfil.Text = "Perfil";
            this.rbPerfil.UseVisualStyleBackColor = true;
            this.rbPerfil.Click += new System.EventHandler(this.rbPerfil_Click);
            // 
            // cmbOrganizar
            // 
            this.cmbOrganizar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOrganizar.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbOrganizar.FormattingEnabled = true;
            this.cmbOrganizar.Location = new System.Drawing.Point(250, 19);
            this.cmbOrganizar.Name = "cmbOrganizar";
            this.cmbOrganizar.Size = new System.Drawing.Size(272, 21);
            this.cmbOrganizar.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(776, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tema:";
            this.label2.Visible = false;
            // 
            // txtDescTema
            // 
            this.txtDescTema.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtDescTema.Location = new System.Drawing.Point(819, 46);
            this.txtDescTema.Name = "txtDescTema";
            this.txtDescTema.ReadOnly = true;
            this.txtDescTema.Size = new System.Drawing.Size(21, 20);
            this.txtDescTema.TabIndex = 0;
            this.txtDescTema.Visible = false;
            // 
            // txtTema
            // 
            this.txtTema.Location = new System.Drawing.Point(796, 46);
            this.txtTema.Name = "txtTema";
            this.txtTema.Size = new System.Drawing.Size(17, 20);
            this.txtTema.TabIndex = 0;
            this.txtTema.Visible = false;
            this.txtTema.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTema_KeyDown);
            this.txtTema.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtTema_MouseDoubleClick);
            // 
            // dgvGrilla
            // 
            this.dgvGrilla.AllowUserToAddRows = false;
            this.dgvGrilla.AllowUserToDeleteRows = false;
            this.dgvGrilla.AllowUserToOrderColumns = true;
            this.dgvGrilla.AllowUserToResizeRows = false;
            this.dgvGrilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGrilla.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Clave,
            this.Perfil,
            this.DescPerfil,
            this.Legajo,
            this.Nombre,
            this.Curso,
            this.DescCurso,
            this.Necesario,
            this.Deseable,
            this.idCalificacion,
            this.idCalificacionAnterior,
            this.Calificacion,
            this.Observaciones,
            this.MarcarActualizacion,
            this.Marca});
            this.dgvGrilla.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvGrilla.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvGrilla.Location = new System.Drawing.Point(10, 85);
            this.dgvGrilla.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.dgvGrilla.Name = "dgvGrilla";
            this.dgvGrilla.RowHeadersWidth = 15;
            this.dgvGrilla.Size = new System.Drawing.Size(850, 393);
            this.dgvGrilla.TabIndex = 2;
            this.dgvGrilla.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvGrilla_CellMouseClick);
            // 
            // Clave
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Clave.DefaultCellStyle = dataGridViewCellStyle1;
            this.Clave.HeaderText = "Clave";
            this.Clave.Name = "Clave";
            this.Clave.ReadOnly = true;
            this.Clave.Visible = false;
            this.Clave.Width = 50;
            // 
            // Perfil
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Perfil.DefaultCellStyle = dataGridViewCellStyle2;
            this.Perfil.HeaderText = "Perfil";
            this.Perfil.Name = "Perfil";
            this.Perfil.ReadOnly = true;
            this.Perfil.Width = 30;
            // 
            // DescPerfil
            // 
            this.DescPerfil.HeaderText = "Perfil";
            this.DescPerfil.Name = "DescPerfil";
            this.DescPerfil.ReadOnly = true;
            this.DescPerfil.Width = 150;
            // 
            // Legajo
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Legajo.DefaultCellStyle = dataGridViewCellStyle3;
            this.Legajo.HeaderText = "Legajo";
            this.Legajo.Name = "Legajo";
            this.Legajo.ReadOnly = true;
            this.Legajo.Width = 40;
            // 
            // Nombre
            // 
            this.Nombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            // 
            // Curso
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Curso.DefaultCellStyle = dataGridViewCellStyle4;
            this.Curso.HeaderText = "Curso";
            this.Curso.Name = "Curso";
            this.Curso.ReadOnly = true;
            this.Curso.Visible = false;
            this.Curso.Width = 30;
            // 
            // DescCurso
            // 
            this.DescCurso.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.DescCurso.HeaderText = "Curso";
            this.DescCurso.Name = "DescCurso";
            this.DescCurso.ReadOnly = true;
            this.DescCurso.Width = 59;
            // 
            // Necesario
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Necesario.DefaultCellStyle = dataGridViewCellStyle5;
            this.Necesario.HeaderText = "Necesario";
            this.Necesario.Name = "Necesario";
            this.Necesario.ReadOnly = true;
            this.Necesario.Width = 70;
            // 
            // Deseable
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Deseable.DefaultCellStyle = dataGridViewCellStyle6;
            this.Deseable.HeaderText = "Deseable";
            this.Deseable.Name = "Deseable";
            this.Deseable.ReadOnly = true;
            this.Deseable.Width = 70;
            // 
            // idCalificacion
            // 
            this.idCalificacion.HeaderText = "idCalificacion";
            this.idCalificacion.Name = "idCalificacion";
            this.idCalificacion.Visible = false;
            // 
            // idCalificacionAnterior
            // 
            this.idCalificacionAnterior.HeaderText = "idCalificacionAnterior";
            this.idCalificacionAnterior.Name = "idCalificacionAnterior";
            this.idCalificacionAnterior.Visible = false;
            // 
            // Calificacion
            // 
            this.Calificacion.HeaderText = "Calificacion";
            this.Calificacion.Name = "Calificacion";
            this.Calificacion.ReadOnly = true;
            // 
            // Observaciones
            // 
            this.Observaciones.HeaderText = "Observaciones";
            this.Observaciones.MaxInputLength = 30;
            this.Observaciones.Name = "Observaciones";
            this.Observaciones.Width = 200;
            // 
            // MarcarActualizacion
            // 
            this.MarcarActualizacion.HeaderText = "MarcarActualizacion";
            this.MarcarActualizacion.Name = "MarcarActualizacion";
            this.MarcarActualizacion.Visible = false;
            this.MarcarActualizacion.Width = 30;
            // 
            // Marca
            // 
            this.Marca.HeaderText = "Marca";
            this.Marca.Name = "Marca";
            this.Marca.Visible = false;
            this.Marca.Width = 30;
            // 
            // pnlAyuda
            // 
            this.pnlAyuda.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(139)))), ((int)(((byte)(82)))));
            this.pnlAyuda.Controls.Add(this.panel6);
            this.pnlAyuda.Controls.Add(this.gbAyuda);
            this.pnlAyuda.Location = new System.Drawing.Point(731, 394);
            this.pnlAyuda.Name = "pnlAyuda";
            this.pnlAyuda.Size = new System.Drawing.Size(68, 88);
            this.pnlAyuda.TabIndex = 9;
            this.pnlAyuda.Visible = false;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.SystemColors.Control;
            this.panel6.Controls.Add(this.btnCerrarAyuda);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel6.Location = new System.Drawing.Point(0, 46);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(68, 42);
            this.panel6.TabIndex = 1;
            // 
            // btnCerrarAyuda
            // 
            this.btnCerrarAyuda.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnCerrarAyuda.BackgroundImage = global::Modulo_Capacitacion.Properties.Resources.apagar1;
            this.btnCerrarAyuda.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnCerrarAyuda.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrarAyuda.ForeColor = System.Drawing.SystemColors.Control;
            this.btnCerrarAyuda.Location = new System.Drawing.Point(17, 3);
            this.btnCerrarAyuda.Name = "btnCerrarAyuda";
            this.btnCerrarAyuda.Size = new System.Drawing.Size(34, 38);
            this.btnCerrarAyuda.TabIndex = 28;
            this.btnCerrarAyuda.UseVisualStyleBackColor = true;
            this.btnCerrarAyuda.Click += new System.EventHandler(this.button1_Click);
            // 
            // gbAyuda
            // 
            this.gbAyuda.Controls.Add(this.label1);
            this.gbAyuda.Controls.Add(this.txtFiltrar);
            this.gbAyuda.Controls.Add(this.dgvAyuda);
            this.gbAyuda.ForeColor = System.Drawing.SystemColors.Control;
            this.gbAyuda.Location = new System.Drawing.Point(15, 13);
            this.gbAyuda.Name = "gbAyuda";
            this.gbAyuda.Size = new System.Drawing.Size(699, 315);
            this.gbAyuda.TabIndex = 0;
            this.gbAyuda.TabStop = false;
            this.gbAyuda.Text = "Temas";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(99, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Filtrar:";
            // 
            // txtFiltrar
            // 
            this.txtFiltrar.Location = new System.Drawing.Point(153, 23);
            this.txtFiltrar.Name = "txtFiltrar";
            this.txtFiltrar.Size = new System.Drawing.Size(446, 20);
            this.txtFiltrar.TabIndex = 1;
            this.txtFiltrar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFiltrar_KeyPress);
            this.txtFiltrar.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtFiltrar_KeyUp);
            // 
            // dgvAyuda
            // 
            this.dgvAyuda.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAyuda.Location = new System.Drawing.Point(8, 56);
            this.dgvAyuda.Name = "dgvAyuda";
            this.dgvAyuda.ReadOnly = true;
            this.dgvAyuda.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.SystemColors.ControlText;
            this.dgvAyuda.Size = new System.Drawing.Size(682, 253);
            this.dgvAyuda.TabIndex = 0;
            this.dgvAyuda.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvAyuda_CellMouseDoubleClick);
            // 
            // pnlProgreso
            // 
            this.pnlProgreso.Controls.Add(this.groupBox3);
            this.pnlProgreso.Location = new System.Drawing.Point(710, 420);
            this.pnlProgreso.Name = "pnlProgreso";
            this.pnlProgreso.Size = new System.Drawing.Size(20, 23);
            this.pnlProgreso.TabIndex = 10;
            this.pnlProgreso.Visible = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.progressBar1);
            this.groupBox3.Location = new System.Drawing.Point(20, 16);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(556, 57);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Procesando";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(25, 20);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(506, 23);
            this.progressBar1.TabIndex = 0;
            // 
            // cmbAuxi
            // 
            this.cmbAuxi.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmbAuxi.FormattingEnabled = true;
            this.cmbAuxi.Items.AddRange(new object[] {
            "",
            "Exede",
            "Cumple",
            "Reforzar",
            "En Entrenamiento",
            "No Cumple",
            "No Aplica",
            "No Evalúa",
            "Cumple Act."});
            this.cmbAuxi.Location = new System.Drawing.Point(716, 367);
            this.cmbAuxi.Name = "cmbAuxi";
            this.cmbAuxi.Size = new System.Drawing.Size(121, 21);
            this.cmbAuxi.TabIndex = 11;
            this.cmbAuxi.SelectedIndexChanged += new System.EventHandler(this.cmbAuxi_SelectedIndexChanged);
            this.cmbAuxi.DropDownClosed += new System.EventHandler(this.cmbAuxi_DropDownClosed);
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(205, 19);
            this.txtCodigo.MaxLength = 3;
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(36, 20);
            this.txtCodigo.TabIndex = 4;
            this.txtCodigo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodigo_KeyDown);
            // 
            // ActualizacionDeCompetenciasYNecesidadesDeCapacitacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(870, 589);
            this.Controls.Add(this.cmbAuxi);
            this.Controls.Add(this.pnlProgreso);
            this.Controls.Add(this.pnlAyuda);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "ActualizacionDeCompetenciasYNecesidadesDeCapacitacion";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.IngreDeCursosRealizados_Load);
            this.Shown += new System.EventHandler(this.IngreDeCursosRealizados_Shown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrilla)).EndInit();
            this.pnlAyuda.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.gbAyuda.ResumeLayout(false);
            this.gbAyuda.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAyuda)).EndInit();
            this.pnlProgreso.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private Label LBPerfil;
        private Panel panel2;
        private Panel panel3;
        private Button BT_Salir;
        private Button BT_Limpiar;
        private Button BT_Guardar;
        private Button btnAyuda;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel4;
        private Panel panel5;
        private DataGridView dgvGrilla;
        private Panel pnlAyuda;
        private GroupBox gbAyuda;
        private DataGridView dgvAyuda;
        private Label label1;
        private TextBox txtFiltrar;
        private Panel panel6;
        private Button btnCerrarAyuda;
        private GroupBox groupBox1;
        private Button btnBuscar;
        private GroupBox groupBox2;
        private RadioButton rbSector;
        private RadioButton rbPerfil;
        private ComboBox cmbOrganizar;
        private Label label2;
        private TextBox txtDescTema;
        private TextBox txtTema;
        private Panel pnlProgreso;
        private GroupBox groupBox3;
        private ProgressBar progressBar1;
        private ComboBox cmbAuxi;
        private Button button1;
        private ToolTip toolTip1;
        private DataGridViewTextBoxColumn Clave;
        private DataGridViewTextBoxColumn Perfil;
        private DataGridViewTextBoxColumn DescPerfil;
        private DataGridViewTextBoxColumn Legajo;
        private DataGridViewTextBoxColumn Nombre;
        private DataGridViewTextBoxColumn Curso;
        private DataGridViewTextBoxColumn DescCurso;
        private DataGridViewTextBoxColumn Necesario;
        private DataGridViewTextBoxColumn Deseable;
        private DataGridViewTextBoxColumn idCalificacion;
        private DataGridViewTextBoxColumn idCalificacionAnterior;
        private DataGridViewTextBoxColumn Calificacion;
        private DataGridViewTextBoxColumn Observaciones;
        private DataGridViewTextBoxColumn MarcarActualizacion;
        private DataGridViewTextBoxColumn Marca;
        private TextBox txtCodigo;
    }
}