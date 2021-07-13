using System.ComponentModel;
using System.Windows.Forms;


namespace Modulo_Capacitacion.Novedades
{
    partial class IngresoDeCursosRealizados
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.LBPerfil = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgvGrilla = new Util.DBDataGridView();
            this.Legajo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DNI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sector = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Observaciones = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.asignarNuevoLegajoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copiarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copiarConCabecerasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarFilaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel5 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnAyudaCursos = new System.Windows.Forms.Button();
            this.btnAyuda = new System.Windows.Forms.Button();
            this.btnAyudaTema = new System.Windows.Forms.Button();
            this.txtFecha = new System.Windows.Forms.MaskedTextBox();
            this.LFechaAviso = new System.Windows.Forms.Label();
            this.txtDesTema = new System.Windows.Forms.TextBox();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.txtCurso = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbTipoProgramacion = new System.Windows.Forms.ComboBox();
            this.txtTemas = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtInstructor = new System.Windows.Forms.TextBox();
            this.cmbTipo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtHoras = new System.Windows.Forms.TextBox();
            this.txtActividad = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDesCurso = new System.Windows.Forms.TextBox();
            this.txtTema = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.pnlAyuda = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.btnCerrarAyuda = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gbLegajos = new System.Windows.Forms.GroupBox();
            this.cmbTipoLegajos = new System.Windows.Forms.ComboBox();
            this.dgvAyuda = new System.Windows.Forms.DataGridView();
            this.label9 = new System.Windows.Forms.Label();
            this.txtAyuda = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrilla)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.pnlAyuda.SuspendLayout();
            this.panel7.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gbLegajos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAyuda)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(139)))), ((int)(((byte)(82)))));
            this.panel1.Controls.Add(this.LBPerfil);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(803, 39);
            this.panel1.TabIndex = 7;
            // 
            // LBPerfil
            // 
            this.LBPerfil.AutoSize = true;
            this.LBPerfil.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBPerfil.ForeColor = System.Drawing.Color.White;
            this.LBPerfil.Location = new System.Drawing.Point(22, 11);
            this.LBPerfil.Name = "LBPerfil";
            this.LBPerfil.Size = new System.Drawing.Size(239, 19);
            this.LBPerfil.TabIndex = 0;
            this.LBPerfil.Text = "INGRESO DE CURSOS REALIZADOS";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(74)))), ((int)(((byte)(95)))));
            this.panel2.Controls.Add(this.tableLayoutPanel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 39);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(803, 550);
            this.panel2.TabIndex = 8;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel5, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel4, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(10);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 71F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(803, 550);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.Control;
            this.panel3.Controls.Add(this.dgvGrilla);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 160);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(797, 316);
            this.panel3.TabIndex = 3;
            // 
            // dgvGrilla
            // 
            this.dgvGrilla.AllowUserToAddRows = false;
            this.dgvGrilla.AllowUserToDeleteRows = false;
            this.dgvGrilla.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvGrilla.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvGrilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGrilla.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Legajo,
            this.Nombre,
            this.DNI,
            this.Sector,
            this.Observaciones});
            this.dgvGrilla.ContextMenuStrip = this.contextMenuStrip1;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(217)))), ((int)(((byte)(232)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(170)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvGrilla.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvGrilla.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvGrilla.DoubleBuffered = true;
            this.dgvGrilla.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvGrilla.Location = new System.Drawing.Point(0, 0);
            this.dgvGrilla.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.dgvGrilla.Name = "dgvGrilla";
            this.dgvGrilla.OrdenamientoColumnasHabilitado = false;
            this.dgvGrilla.RowHeadersWidth = 15;
            this.dgvGrilla.ShowCellToolTips = false;
            this.dgvGrilla.SinClickDerecho = false;
            this.dgvGrilla.Size = new System.Drawing.Size(797, 316);
            this.dgvGrilla.TabIndex = 36;
            this.dgvGrilla.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvGrilla_RowHeaderMouseDoubleClick);
            this.dgvGrilla.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dgvGrilla_MouseDown);
            // 
            // Legajo
            // 
            this.Legajo.DataPropertyName = "Legajo";
            this.Legajo.HeaderText = "Legajo";
            this.Legajo.Name = "Legajo";
            this.Legajo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Legajo.Width = 45;
            // 
            // Nombre
            // 
            this.Nombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Nombre.DataPropertyName = "Descripcion";
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Nombre.Width = 50;
            // 
            // DNI
            // 
            this.DNI.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.DNI.DefaultCellStyle = dataGridViewCellStyle2;
            this.DNI.HeaderText = "DNI";
            this.DNI.MinimumWidth = 100;
            this.DNI.Name = "DNI";
            this.DNI.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Sector
            // 
            this.Sector.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Sector.DataPropertyName = "Sector";
            this.Sector.HeaderText = "Sector";
            this.Sector.Name = "Sector";
            this.Sector.ReadOnly = true;
            this.Sector.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Sector.Width = 44;
            // 
            // Observaciones
            // 
            this.Observaciones.DataPropertyName = "Observaciones";
            this.Observaciones.HeaderText = "Observaciones";
            this.Observaciones.MaxInputLength = 50;
            this.Observaciones.MinimumWidth = 300;
            this.Observaciones.Name = "Observaciones";
            this.Observaciones.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Observaciones.Width = 300;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.asignarNuevoLegajoToolStripMenuItem,
            this.copiarToolStripMenuItem,
            this.copiarConCabecerasToolStripMenuItem,
            this.eliminarFilaToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(191, 92);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // asignarNuevoLegajoToolStripMenuItem
            // 
            this.asignarNuevoLegajoToolStripMenuItem.Name = "asignarNuevoLegajoToolStripMenuItem";
            this.asignarNuevoLegajoToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.asignarNuevoLegajoToolStripMenuItem.Text = "Asignar Nuevo Legajo";
            this.asignarNuevoLegajoToolStripMenuItem.Click += new System.EventHandler(this.asignarNuevoLegajoToolStripMenuItem_Click);
            // 
            // copiarToolStripMenuItem
            // 
            this.copiarToolStripMenuItem.Name = "copiarToolStripMenuItem";
            this.copiarToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.copiarToolStripMenuItem.Text = "Copiar";
            this.copiarToolStripMenuItem.Click += new System.EventHandler(this.copiarToolStripMenuItem_Click);
            // 
            // copiarConCabecerasToolStripMenuItem
            // 
            this.copiarConCabecerasToolStripMenuItem.Name = "copiarConCabecerasToolStripMenuItem";
            this.copiarConCabecerasToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.copiarConCabecerasToolStripMenuItem.Text = "Copiar con Cabeceras";
            this.copiarConCabecerasToolStripMenuItem.Click += new System.EventHandler(this.copiarConCabecerasToolStripMenuItem_Click);
            // 
            // eliminarFilaToolStripMenuItem
            // 
            this.eliminarFilaToolStripMenuItem.Name = "eliminarFilaToolStripMenuItem";
            this.eliminarFilaToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.eliminarFilaToolStripMenuItem.Text = "Eliminar Fila";
            this.eliminarFilaToolStripMenuItem.Click += new System.EventHandler(this.eliminarFilaToolStripMenuItem_Click);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.SystemColors.Control;
            this.panel5.Controls.Add(this.button1);
            this.panel5.Controls.Add(this.button2);
            this.panel5.Controls.Add(this.btnImprimir);
            this.panel5.Controls.Add(this.btnLimpiar);
            this.panel5.Controls.Add(this.btnGuardar);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(3, 479);
            this.panel5.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(797, 68);
            this.panel5.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(583, 16);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(174, 36);
            this.button1.TabIndex = 1;
            this.button1.Text = "CARGAR ARCHIVOS RELACIONADOS";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackgroundImage = global::Modulo_Capacitacion.Properties.Resources.apagar1;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(444, 10);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(65, 49);
            this.button2.TabIndex = 0;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackgroundImage = global::Modulo_Capacitacion.Properties.Resources.imprimir;
            this.btnImprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnImprimir.FlatAppearance.BorderSize = 0;
            this.btnImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImprimir.Location = new System.Drawing.Point(350, 10);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(65, 49);
            this.btnImprimir.TabIndex = 0;
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackgroundImage = global::Modulo_Capacitacion.Properties.Resources.limpiar;
            this.btnLimpiar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnLimpiar.FlatAppearance.BorderSize = 0;
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.Location = new System.Drawing.Point(256, 10);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(65, 49);
            this.btnLimpiar.TabIndex = 0;
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackgroundImage = global::Modulo_Capacitacion.Properties.Resources.Aceptar_N2;
            this.btnGuardar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Location = new System.Drawing.Point(162, 10);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(65, 49);
            this.btnGuardar.TabIndex = 0;
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.Control;
            this.panel4.Controls.Add(this.btnAyudaCursos);
            this.panel4.Controls.Add(this.btnAyuda);
            this.panel4.Controls.Add(this.btnAyudaTema);
            this.panel4.Controls.Add(this.txtFecha);
            this.panel4.Controls.Add(this.LFechaAviso);
            this.panel4.Controls.Add(this.txtDesTema);
            this.panel4.Controls.Add(this.txtCodigo);
            this.panel4.Controls.Add(this.txtCurso);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.cmbTipoProgramacion);
            this.panel4.Controls.Add(this.txtTemas);
            this.panel4.Controls.Add(this.label10);
            this.panel4.Controls.Add(this.label8);
            this.panel4.Controls.Add(this.txtInstructor);
            this.panel4.Controls.Add(this.cmbTipo);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.label7);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.txtHoras);
            this.panel4.Controls.Add(this.txtActividad);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.txtDesCurso);
            this.panel4.Controls.Add(this.txtTema);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(3, 3);
            this.panel4.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(797, 157);
            this.panel4.TabIndex = 4;
            // 
            // btnAyudaCursos
            // 
            this.btnAyudaCursos.BackgroundImage = global::Modulo_Capacitacion.Properties.Resources.Consulta_Dat_N1;
            this.btnAyudaCursos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAyudaCursos.FlatAppearance.BorderSize = 0;
            this.btnAyudaCursos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAyudaCursos.Location = new System.Drawing.Point(524, 4);
            this.btnAyudaCursos.Name = "btnAyudaCursos";
            this.btnAyudaCursos.Size = new System.Drawing.Size(26, 30);
            this.btnAyudaCursos.TabIndex = 55;
            this.btnAyudaCursos.UseVisualStyleBackColor = true;
            this.btnAyudaCursos.Click += new System.EventHandler(this.btnAyudaCursos_Click);
            // 
            // btnAyuda
            // 
            this.btnAyuda.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAyuda.FlatAppearance.BorderSize = 0;
            this.btnAyuda.Location = new System.Drawing.Point(622, 75);
            this.btnAyuda.Name = "btnAyuda";
            this.btnAyuda.Size = new System.Drawing.Size(162, 45);
            this.btnAyuda.TabIndex = 0;
            this.btnAyuda.Text = "Asignar Legajos";
            this.btnAyuda.UseVisualStyleBackColor = true;
            this.btnAyuda.Click += new System.EventHandler(this.btnAyuda_Click);
            // 
            // btnAyudaTema
            // 
            this.btnAyudaTema.BackgroundImage = global::Modulo_Capacitacion.Properties.Resources.Consulta_Dat_N1;
            this.btnAyudaTema.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAyudaTema.FlatAppearance.BorderSize = 0;
            this.btnAyudaTema.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAyudaTema.Location = new System.Drawing.Point(200, 6);
            this.btnAyudaTema.Name = "btnAyudaTema";
            this.btnAyudaTema.Size = new System.Drawing.Size(26, 30);
            this.btnAyudaTema.TabIndex = 54;
            this.btnAyudaTema.UseVisualStyleBackColor = true;
            this.btnAyudaTema.Click += new System.EventHandler(this.btnAyudaTema_Click);
            // 
            // txtFecha
            // 
            this.txtFecha.Location = new System.Drawing.Point(91, 43);
            this.txtFecha.Mask = "00/00/0000";
            this.txtFecha.Name = "txtFecha";
            this.txtFecha.PromptChar = ' ';
            this.txtFecha.Size = new System.Drawing.Size(86, 20);
            this.txtFecha.TabIndex = 53;
            this.txtFecha.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtFecha.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFecha_KeyDown);
            // 
            // LFechaAviso
            // 
            this.LFechaAviso.AutoSize = true;
            this.LFechaAviso.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LFechaAviso.Location = new System.Drawing.Point(20, 10);
            this.LFechaAviso.Name = "LFechaAviso";
            this.LFechaAviso.Size = new System.Drawing.Size(55, 18);
            this.LFechaAviso.TabIndex = 4;
            this.LFechaAviso.Text = "Codigo:";
            // 
            // txtDesTema
            // 
            this.txtDesTema.Enabled = false;
            this.txtDesTema.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDesTema.Location = new System.Drawing.Point(233, 9);
            this.txtDesTema.Name = "txtDesTema";
            this.txtDesTema.ReadOnly = true;
            this.txtDesTema.Size = new System.Drawing.Size(234, 20);
            this.txtDesTema.TabIndex = 52;
            // 
            // txtCodigo
            // 
            this.txtCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigo.Location = new System.Drawing.Point(89, 9);
            this.txtCodigo.MaxLength = 6;
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(54, 20);
            this.txtCodigo.TabIndex = 5;
            this.txtCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCodigo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodigo_KeyDown);
            // 
            // txtCurso
            // 
            this.txtCurso.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCurso.Location = new System.Drawing.Point(523, 9);
            this.txtCurso.Name = "txtCurso";
            this.txtCurso.Size = new System.Drawing.Size(27, 20);
            this.txtCurso.TabIndex = 51;
            this.txtCurso.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCurso.Visible = false;
            this.txtCurso.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TB_CodCurso_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 18);
            this.label1.TabIndex = 6;
            this.label1.Text = "Fecha";
            // 
            // cmbTipoProgramacion
            // 
            this.cmbTipoProgramacion.FormattingEnabled = true;
            this.cmbTipoProgramacion.Items.AddRange(new object[] {
            "Programada",
            "No Programada"});
            this.cmbTipoProgramacion.Location = new System.Drawing.Point(664, 43);
            this.cmbTipoProgramacion.Name = "cmbTipoProgramacion";
            this.cmbTipoProgramacion.Size = new System.Drawing.Size(121, 21);
            this.cmbTipoProgramacion.TabIndex = 50;
            this.cmbTipoProgramacion.DropDownClosed += new System.EventHandler(this.cmbTipoProgramacion_DropDownClosed);
            this.cmbTipoProgramacion.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbTipoProgramacion_KeyDown);
            // 
            // txtTemas
            // 
            this.txtTemas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTemas.Location = new System.Drawing.Point(89, 126);
            this.txtTemas.MaxLength = 100;
            this.txtTemas.Name = "txtTemas";
            this.txtTemas.Size = new System.Drawing.Size(695, 20);
            this.txtTemas.TabIndex = 34;
            this.txtTemas.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTemas_KeyDown);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(535, 44);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(123, 18);
            this.label10.TabIndex = 49;
            this.label10.Text = "Tipo Programación";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(385, 44);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 18);
            this.label8.TabIndex = 49;
            this.label8.Text = "Tipo";
            // 
            // txtInstructor
            // 
            this.txtInstructor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInstructor.Location = new System.Drawing.Point(89, 75);
            this.txtInstructor.MaxLength = 50;
            this.txtInstructor.Name = "txtInstructor";
            this.txtInstructor.Size = new System.Drawing.Size(527, 20);
            this.txtInstructor.TabIndex = 35;
            this.txtInstructor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtInstructor_KeyDown);
            // 
            // cmbTipo
            // 
            this.cmbTipo.FormattingEnabled = true;
            this.cmbTipo.Items.AddRange(new object[] {
            "Interna",
            "Externa"});
            this.cmbTipo.Location = new System.Drawing.Point(425, 43);
            this.cmbTipo.Name = "cmbTipo";
            this.cmbTipo.Size = new System.Drawing.Size(84, 21);
            this.cmbTipo.TabIndex = 48;
            this.cmbTipo.DropDownClosed += new System.EventHandler(this.cmbTipo_DropDownClosed);
            this.cmbTipo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbTipo_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(15, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 18);
            this.label2.TabIndex = 37;
            this.label2.Text = "Instructor";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(233, 44);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 18);
            this.label7.TabIndex = 46;
            this.label7.Text = "Horas";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(15, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 18);
            this.label3.TabIndex = 38;
            this.label3.Text = "Contenido";
            // 
            // txtHoras
            // 
            this.txtHoras.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHoras.Location = new System.Drawing.Point(286, 43);
            this.txtHoras.MaxLength = 6;
            this.txtHoras.Name = "txtHoras";
            this.txtHoras.Size = new System.Drawing.Size(54, 20);
            this.txtHoras.TabIndex = 47;
            this.txtHoras.Text = "1";
            this.txtHoras.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtHoras.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtHoras_KeyDown);
            this.txtHoras.Leave += new System.EventHandler(this.txtHoras_Leave);
            // 
            // txtActividad
            // 
            this.txtActividad.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtActividad.Location = new System.Drawing.Point(90, 101);
            this.txtActividad.MaxLength = 50;
            this.txtActividad.Name = "txtActividad";
            this.txtActividad.Size = new System.Drawing.Size(526, 20);
            this.txtActividad.TabIndex = 39;
            this.txtActividad.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtActividad_KeyDown);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(479, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 18);
            this.label6.TabIndex = 44;
            this.label6.Text = "Curso";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(15, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 18);
            this.label4.TabIndex = 40;
            this.label4.Text = "Actividad";
            // 
            // txtDesCurso
            // 
            this.txtDesCurso.Enabled = false;
            this.txtDesCurso.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDesCurso.Location = new System.Drawing.Point(556, 9);
            this.txtDesCurso.Name = "txtDesCurso";
            this.txtDesCurso.ReadOnly = true;
            this.txtDesCurso.Size = new System.Drawing.Size(228, 20);
            this.txtDesCurso.TabIndex = 43;
            // 
            // txtTema
            // 
            this.txtTema.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTema.Location = new System.Drawing.Point(199, 9);
            this.txtTema.Name = "txtTema";
            this.txtTema.Size = new System.Drawing.Size(28, 20);
            this.txtTema.TabIndex = 41;
            this.txtTema.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTema.Visible = false;
            this.txtTema.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TB_CodTema_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(155, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 18);
            this.label5.TabIndex = 42;
            this.label5.Text = "Tema:";
            // 
            // pnlAyuda
            // 
            this.pnlAyuda.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(139)))), ((int)(((byte)(82)))));
            this.pnlAyuda.Controls.Add(this.panel7);
            this.pnlAyuda.Controls.Add(this.groupBox1);
            this.pnlAyuda.Location = new System.Drawing.Point(120, 118);
            this.pnlAyuda.Name = "pnlAyuda";
            this.pnlAyuda.Size = new System.Drawing.Size(560, 373);
            this.pnlAyuda.TabIndex = 9;
            this.pnlAyuda.Visible = false;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.SystemColors.Control;
            this.panel7.Controls.Add(this.btnCerrarAyuda);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel7.Location = new System.Drawing.Point(0, 324);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(560, 49);
            this.panel7.TabIndex = 1;
            // 
            // btnCerrarAyuda
            // 
            this.btnCerrarAyuda.BackgroundImage = global::Modulo_Capacitacion.Properties.Resources.apagar1;
            this.btnCerrarAyuda.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnCerrarAyuda.FlatAppearance.BorderSize = 0;
            this.btnCerrarAyuda.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrarAyuda.Location = new System.Drawing.Point(253, 6);
            this.btnCerrarAyuda.Name = "btnCerrarAyuda";
            this.btnCerrarAyuda.Size = new System.Drawing.Size(50, 37);
            this.btnCerrarAyuda.TabIndex = 1;
            this.btnCerrarAyuda.UseVisualStyleBackColor = true;
            this.btnCerrarAyuda.Click += new System.EventHandler(this.btnCerrarAyuda_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.gbLegajos);
            this.groupBox1.Controls.Add(this.dgvAyuda);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtAyuda);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Location = new System.Drawing.Point(14, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(528, 311);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ayuda";
            // 
            // gbLegajos
            // 
            this.gbLegajos.Controls.Add(this.cmbTipoLegajos);
            this.gbLegajos.ForeColor = System.Drawing.SystemColors.Control;
            this.gbLegajos.Location = new System.Drawing.Point(26, 264);
            this.gbLegajos.Name = "gbLegajos";
            this.gbLegajos.Size = new System.Drawing.Size(481, 38);
            this.gbLegajos.TabIndex = 3;
            this.gbLegajos.TabStop = false;
            this.gbLegajos.Text = "Legajos:";
            this.gbLegajos.Visible = false;
            // 
            // cmbTipoLegajos
            // 
            this.cmbTipoLegajos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoLegajos.FormattingEnabled = true;
            this.cmbTipoLegajos.Items.AddRange(new object[] {
            "Que Tengan Asignado el Tema",
            "Todos"});
            this.cmbTipoLegajos.Location = new System.Drawing.Point(131, 11);
            this.cmbTipoLegajos.Name = "cmbTipoLegajos";
            this.cmbTipoLegajos.Size = new System.Drawing.Size(218, 21);
            this.cmbTipoLegajos.TabIndex = 0;
            this.cmbTipoLegajos.DropDownClosed += new System.EventHandler(this.comboBox1_DropDownClosed);
            // 
            // dgvAyuda
            // 
            this.dgvAyuda.AllowUserToAddRows = false;
            this.dgvAyuda.AllowUserToDeleteRows = false;
            this.dgvAyuda.AllowUserToResizeRows = false;
            this.dgvAyuda.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAyuda.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvAyuda.Location = new System.Drawing.Point(26, 50);
            this.dgvAyuda.Name = "dgvAyuda";
            this.dgvAyuda.ReadOnly = true;
            this.dgvAyuda.RowHeadersWidth = 5;
            this.dgvAyuda.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.SystemColors.ControlText;
            this.dgvAyuda.Size = new System.Drawing.Size(483, 214);
            this.dgvAyuda.TabIndex = 2;
            this.dgvAyuda.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvAyuda_CellMouseDoubleClick);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(19, 27);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 13);
            this.label9.TabIndex = 1;
            this.label9.Text = "Filtrar:";
            // 
            // txtAyuda
            // 
            this.txtAyuda.Location = new System.Drawing.Point(66, 24);
            this.txtAyuda.Name = "txtAyuda";
            this.txtAyuda.Size = new System.Drawing.Size(443, 20);
            this.txtAyuda.TabIndex = 0;
            this.txtAyuda.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAyuda_KeyDown);
            this.txtAyuda.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtAyuda_KeyUp);
            // 
            // IngresoDeCursosRealizados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(803, 589);
            this.Controls.Add(this.pnlAyuda);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "IngresoDeCursosRealizados";
            this.Load += new System.EventHandler(this.IngresoDeCursosRealizados_Load);
            this.Shown += new System.EventHandler(this.IngresoDeCursosRealizados_Shown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrilla)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.pnlAyuda.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbLegajos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAyuda)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private Label LBPerfil;
        private Panel panel2;
        private Panel panel3;
        private TextBox txtTemas;
        private Label label1;
        private Label LFechaAviso;
        private TextBox txtCodigo;
        private TextBox txtInstructor;
        private Util.DBDataGridView dgvGrilla;
        private TextBox txtDesTema;
        private TextBox txtCurso;
        private ComboBox cmbTipoProgramacion;
        private Label label8;
        private ComboBox cmbTipo;
        private Label label7;
        private TextBox txtHoras;
        private Label label6;
        private TextBox txtDesCurso;
        private Label label5;
        private TextBox txtTema;
        private Label label4;
        private TextBox txtActividad;
        private Label label3;
        private Label label2;
        private MaskedTextBox txtFecha;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel4;
        private Panel panel5;
        private Button button2;
        private Button btnLimpiar;
        private Button btnGuardar;
        private Panel pnlAyuda;
        private GroupBox groupBox1;
        private DataGridView dgvAyuda;
        private Label label9;
        private TextBox txtAyuda;
        private Button btnAyuda;
        private Panel panel7;
        private Button btnCerrarAyuda;
        private Button btnAyudaTema;
        private Button btnAyudaCursos;
        private Label label10;
        private GroupBox gbLegajos;
        private ComboBox cmbTipoLegajos;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem copiarToolStripMenuItem;
        private ToolStripMenuItem copiarConCabecerasToolStripMenuItem;
        private ToolStripMenuItem eliminarFilaToolStripMenuItem;
        private ToolStripMenuItem asignarNuevoLegajoToolStripMenuItem;
        private Button btnImprimir;
        private Button button1;
        private DataGridViewTextBoxColumn Legajo;
        private DataGridViewTextBoxColumn Nombre;
        private DataGridViewTextBoxColumn DNI;
        private DataGridViewTextBoxColumn Sector;
        private DataGridViewTextBoxColumn Observaciones;
    }
}