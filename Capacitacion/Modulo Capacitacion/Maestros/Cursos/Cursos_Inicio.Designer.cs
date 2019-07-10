using System.ComponentModel;
using System.Windows.Forms;

namespace Modulo_Capacitacion.Maestros.Cursos
{
    partial class Cursos_Inicio
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.P_Verde = new System.Windows.Forms.Panel();
            this.P_Filtrado = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TBFiltro = new System.Windows.Forms.TextBox();
            this.dgvTemas = new System.Windows.Forms.DataGridView();
            this.Clave = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tema = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Curs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DescCurso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Horas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CMS_Curso = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.claveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.temaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.descripcionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cursoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.horaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.BTAgregarCurso = new System.Windows.Forms.Button();
            this.btnMostrarCursos = new System.Windows.Forms.Button();
            this.BTModifCurso = new System.Windows.Forms.Button();
            this.Bt_Fin = new System.Windows.Forms.Button();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.BT_Eliminar = new System.Windows.Forms.Button();
            this.pnlCursos = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblTema = new System.Windows.Forms.Label();
            this.btnCerrarCursos = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dgvCursos = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.P_Verde.SuspendLayout();
            this.P_Filtrado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTemas)).BeginInit();
            this.CMS_Curso.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.pnlCursos.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCursos)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(74)))), ((int)(((byte)(95)))));
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(851, 50);
            this.panel1.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(9, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "CURSOS";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(695, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "SURFACTAN S.A.";
            // 
            // P_Verde
            // 
            this.P_Verde.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.P_Verde.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(139)))), ((int)(((byte)(82)))));
            this.P_Verde.Controls.Add(this.P_Filtrado);
            this.P_Verde.Location = new System.Drawing.Point(0, 50);
            this.P_Verde.Margin = new System.Windows.Forms.Padding(0);
            this.P_Verde.Name = "P_Verde";
            this.P_Verde.Size = new System.Drawing.Size(851, 51);
            this.P_Verde.TabIndex = 6;
            // 
            // P_Filtrado
            // 
            this.P_Filtrado.Controls.Add(this.button1);
            this.P_Filtrado.Controls.Add(this.label5);
            this.P_Filtrado.Controls.Add(this.txtCodigo);
            this.P_Filtrado.Controls.Add(this.label3);
            this.P_Filtrado.Controls.Add(this.TBFiltro);
            this.P_Filtrado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.P_Filtrado.Location = new System.Drawing.Point(0, 0);
            this.P_Filtrado.Name = "P_Filtrado";
            this.P_Filtrado.Size = new System.Drawing.Size(851, 51);
            this.P_Filtrado.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(135, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 19);
            this.label5.TabIndex = 1;
            this.label5.Text = "Código:";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(200, 16);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(89, 20);
            this.txtCodigo.TabIndex = 1;
            this.txtCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCodigo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodigo_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(297, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 19);
            this.label3.TabIndex = 1;
            this.label3.Text = "Filtrar:";
            // 
            // TBFiltro
            // 
            this.TBFiltro.Location = new System.Drawing.Point(352, 16);
            this.TBFiltro.Name = "TBFiltro";
            this.TBFiltro.Size = new System.Drawing.Size(350, 20);
            this.TBFiltro.TabIndex = 1;
            this.TBFiltro.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TBFiltro_KeyDown);
            this.TBFiltro.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TBFiltro_KeyUp);
            // 
            // dgvTemas
            // 
            this.dgvTemas.AllowUserToAddRows = false;
            this.dgvTemas.AllowUserToDeleteRows = false;
            this.dgvTemas.AllowUserToResizeRows = false;
            this.dgvTemas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvTemas.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvTemas.ColumnHeadersHeight = 20;
            this.dgvTemas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Clave,
            this.Tema,
            this.Descripcion,
            this.Curs,
            this.DescCurso,
            this.Horas});
            this.dgvTemas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTemas.Location = new System.Drawing.Point(83, 0);
            this.dgvTemas.Margin = new System.Windows.Forms.Padding(0);
            this.dgvTemas.Name = "dgvTemas";
            this.dgvTemas.ReadOnly = true;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTemas.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvTemas.RowHeadersWidth = 15;
            this.dgvTemas.Size = new System.Drawing.Size(768, 471);
            this.dgvTemas.TabIndex = 7;
            this.dgvTemas.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvTemas_CellMouseDoubleClick);
            this.dgvTemas.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DGV_Cursos_RowHeaderMouseDoubleClick);
            // 
            // Clave
            // 
            this.Clave.DataPropertyName = "Clave";
            this.Clave.HeaderText = "Clave";
            this.Clave.Name = "Clave";
            this.Clave.ReadOnly = true;
            this.Clave.Visible = false;
            this.Clave.Width = 59;
            // 
            // Tema
            // 
            this.Tema.DataPropertyName = "Tema";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Tema.DefaultCellStyle = dataGridViewCellStyle5;
            this.Tema.HeaderText = "Tema";
            this.Tema.Name = "Tema";
            this.Tema.ReadOnly = true;
            this.Tema.Width = 59;
            // 
            // Descripcion
            // 
            this.Descripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Descripcion.DataPropertyName = "Descripcion";
            this.Descripcion.HeaderText = "Descripcion";
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.ReadOnly = true;
            // 
            // Curs
            // 
            this.Curs.DataPropertyName = "Curso";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Curs.DefaultCellStyle = dataGridViewCellStyle6;
            this.Curs.HeaderText = "Tema";
            this.Curs.Name = "Curs";
            this.Curs.ReadOnly = true;
            this.Curs.Visible = false;
            this.Curs.Width = 59;
            // 
            // DescCurso
            // 
            this.DescCurso.DataPropertyName = "CursoDesc";
            this.DescCurso.HeaderText = "Descripcion";
            this.DescCurso.Name = "DescCurso";
            this.DescCurso.ReadOnly = true;
            this.DescCurso.Visible = false;
            this.DescCurso.Width = 88;
            // 
            // Horas
            // 
            this.Horas.DataPropertyName = "Horas";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Horas.DefaultCellStyle = dataGridViewCellStyle7;
            this.Horas.HeaderText = "Horas";
            this.Horas.Name = "Horas";
            this.Horas.ReadOnly = true;
            this.Horas.Visible = false;
            this.Horas.Width = 60;
            // 
            // CMS_Curso
            // 
            this.CMS_Curso.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.claveToolStripMenuItem,
            this.temaToolStripMenuItem,
            this.descripcionToolStripMenuItem,
            this.cursoToolStripMenuItem,
            this.horaToolStripMenuItem});
            this.CMS_Curso.Name = "CMS_Curso";
            this.CMS_Curso.Size = new System.Drawing.Size(68, 114);
            // 
            // claveToolStripMenuItem
            // 
            this.claveToolStripMenuItem.Name = "claveToolStripMenuItem";
            this.claveToolStripMenuItem.Size = new System.Drawing.Size(67, 22);
            // 
            // temaToolStripMenuItem
            // 
            this.temaToolStripMenuItem.Name = "temaToolStripMenuItem";
            this.temaToolStripMenuItem.Size = new System.Drawing.Size(67, 22);
            // 
            // descripcionToolStripMenuItem
            // 
            this.descripcionToolStripMenuItem.Name = "descripcionToolStripMenuItem";
            this.descripcionToolStripMenuItem.Size = new System.Drawing.Size(67, 22);
            // 
            // cursoToolStripMenuItem
            // 
            this.cursoToolStripMenuItem.Name = "cursoToolStripMenuItem";
            this.cursoToolStripMenuItem.Size = new System.Drawing.Size(67, 22);
            // 
            // horaToolStripMenuItem
            // 
            this.horaToolStripMenuItem.Name = "horaToolStripMenuItem";
            this.horaToolStripMenuItem.Size = new System.Drawing.Size(67, 22);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.P_Verde, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 51F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(851, 572);
            this.tableLayoutPanel1.TabIndex = 22;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 83F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 768F));
            this.tableLayoutPanel2.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.dgvTemas, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 101);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(851, 471);
            this.tableLayoutPanel2.TabIndex = 7;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.BTAgregarCurso);
            this.panel2.Controls.Add(this.btnMostrarCursos);
            this.panel2.Controls.Add(this.BTModifCurso);
            this.panel2.Controls.Add(this.Bt_Fin);
            this.panel2.Controls.Add(this.btnImprimir);
            this.panel2.Controls.Add(this.BT_Eliminar);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(83, 471);
            this.panel2.TabIndex = 0;
            // 
            // BTAgregarCurso
            // 
            this.BTAgregarCurso.BackgroundImage = global::Modulo_Capacitacion.Properties.Resources.agregar_cursos;
            this.BTAgregarCurso.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BTAgregarCurso.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTAgregarCurso.ForeColor = System.Drawing.SystemColors.Control;
            this.BTAgregarCurso.Location = new System.Drawing.Point(16, 9);
            this.BTAgregarCurso.Name = "BTAgregarCurso";
            this.BTAgregarCurso.Size = new System.Drawing.Size(51, 67);
            this.BTAgregarCurso.TabIndex = 18;
            this.BTAgregarCurso.UseVisualStyleBackColor = true;
            this.BTAgregarCurso.Click += new System.EventHandler(this.BTAgregarCurso_Click);
            // 
            // btnMostrarCursos
            // 
            this.btnMostrarCursos.BackgroundImage = global::Modulo_Capacitacion.Properties.Resources.editar_cursos;
            this.btnMostrarCursos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnMostrarCursos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMostrarCursos.ForeColor = System.Drawing.SystemColors.Control;
            this.btnMostrarCursos.Location = new System.Drawing.Point(16, 100);
            this.btnMostrarCursos.Margin = new System.Windows.Forms.Padding(0);
            this.btnMostrarCursos.Name = "btnMostrarCursos";
            this.btnMostrarCursos.Size = new System.Drawing.Size(49, 57);
            this.btnMostrarCursos.TabIndex = 19;
            this.btnMostrarCursos.UseVisualStyleBackColor = true;
            this.btnMostrarCursos.Click += new System.EventHandler(this.btnMostrarCursos_Click);
            // 
            // BTModifCurso
            // 
            this.BTModifCurso.BackgroundImage = global::Modulo_Capacitacion.Properties.Resources.editar_cursos;
            this.BTModifCurso.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BTModifCurso.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTModifCurso.ForeColor = System.Drawing.SystemColors.Control;
            this.BTModifCurso.Location = new System.Drawing.Point(47, 437);
            this.BTModifCurso.Margin = new System.Windows.Forms.Padding(0);
            this.BTModifCurso.Name = "BTModifCurso";
            this.BTModifCurso.Size = new System.Drawing.Size(25, 25);
            this.BTModifCurso.TabIndex = 19;
            this.BTModifCurso.UseVisualStyleBackColor = true;
            this.BTModifCurso.Visible = false;
            this.BTModifCurso.Click += new System.EventHandler(this.BTModifCurso_Click);
            // 
            // Bt_Fin
            // 
            this.Bt_Fin.BackgroundImage = global::Modulo_Capacitacion.Properties.Resources.apagar;
            this.Bt_Fin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Bt_Fin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Bt_Fin.ForeColor = System.Drawing.SystemColors.Control;
            this.Bt_Fin.Location = new System.Drawing.Point(19, 355);
            this.Bt_Fin.Margin = new System.Windows.Forms.Padding(0);
            this.Bt_Fin.Name = "Bt_Fin";
            this.Bt_Fin.Size = new System.Drawing.Size(45, 50);
            this.Bt_Fin.TabIndex = 21;
            this.Bt_Fin.UseVisualStyleBackColor = true;
            this.Bt_Fin.Click += new System.EventHandler(this.Bt_Fin_Click);
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackgroundImage = global::Modulo_Capacitacion.Properties.Resources.imprimir;
            this.btnImprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImprimir.ForeColor = System.Drawing.SystemColors.Control;
            this.btnImprimir.Location = new System.Drawing.Point(16, 267);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(50, 65);
            this.btnImprimir.TabIndex = 20;
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // BT_Eliminar
            // 
            this.BT_Eliminar.BackgroundImage = global::Modulo_Capacitacion.Properties.Resources.eliminar;
            this.BT_Eliminar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BT_Eliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BT_Eliminar.ForeColor = System.Drawing.SystemColors.Control;
            this.BT_Eliminar.Location = new System.Drawing.Point(16, 179);
            this.BT_Eliminar.Name = "BT_Eliminar";
            this.BT_Eliminar.Size = new System.Drawing.Size(50, 65);
            this.BT_Eliminar.TabIndex = 20;
            this.BT_Eliminar.UseVisualStyleBackColor = true;
            this.BT_Eliminar.Click += new System.EventHandler(this.BT_Eliminar_Click);
            // 
            // pnlCursos
            // 
            this.pnlCursos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(139)))), ((int)(((byte)(82)))));
            this.pnlCursos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCursos.Controls.Add(this.panel3);
            this.pnlCursos.Controls.Add(this.groupBox1);
            this.pnlCursos.Location = new System.Drawing.Point(118, 125);
            this.pnlCursos.Name = "pnlCursos";
            this.pnlCursos.Size = new System.Drawing.Size(638, 373);
            this.pnlCursos.TabIndex = 23;
            this.pnlCursos.Visible = false;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.Control;
            this.panel3.Controls.Add(this.lblTema);
            this.panel3.Controls.Add(this.btnCerrarCursos);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 323);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(636, 48);
            this.panel3.TabIndex = 1;
            // 
            // lblTema
            // 
            this.lblTema.AutoSize = true;
            this.lblTema.Location = new System.Drawing.Point(526, 16);
            this.lblTema.Name = "lblTema";
            this.lblTema.Size = new System.Drawing.Size(13, 13);
            this.lblTema.TabIndex = 23;
            this.lblTema.Text = "0";
            this.lblTema.Visible = false;
            // 
            // btnCerrarCursos
            // 
            this.btnCerrarCursos.BackgroundImage = global::Modulo_Capacitacion.Properties.Resources.apagar;
            this.btnCerrarCursos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnCerrarCursos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrarCursos.ForeColor = System.Drawing.SystemColors.Control;
            this.btnCerrarCursos.Location = new System.Drawing.Point(300, 4);
            this.btnCerrarCursos.Margin = new System.Windows.Forms.Padding(0);
            this.btnCerrarCursos.Name = "btnCerrarCursos";
            this.btnCerrarCursos.Size = new System.Drawing.Size(36, 41);
            this.btnCerrarCursos.TabIndex = 22;
            this.btnCerrarCursos.UseVisualStyleBackColor = true;
            this.btnCerrarCursos.Click += new System.EventHandler(this.btnCerrarCursos_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.dgvCursos);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Location = new System.Drawing.Point(8, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(617, 302);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tema: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(284, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 18);
            this.label4.TabIndex = 2;
            this.label4.Text = "Cursos";
            // 
            // dgvCursos
            // 
            this.dgvCursos.AllowUserToAddRows = false;
            this.dgvCursos.AllowUserToDeleteRows = false;
            this.dgvCursos.AllowUserToResizeRows = false;
            this.dgvCursos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCursos.Location = new System.Drawing.Point(5, 42);
            this.dgvCursos.Name = "dgvCursos";
            this.dgvCursos.ReadOnly = true;
            this.dgvCursos.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.SystemColors.ControlText;
            this.dgvCursos.Size = new System.Drawing.Size(607, 254);
            this.dgvCursos.TabIndex = 0;
            this.dgvCursos.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvCursos_CellMouseDoubleClick);
            this.dgvCursos.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvCursos_RowHeaderMouseDoubleClick);
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 2;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.SystemColors.Control;
            this.button1.Location = new System.Drawing.Point(708, 14);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(80, 25);
            this.button1.TabIndex = 2;
            this.button1.Text = "Limpiar Filtro";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Cursos_Inicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(851, 572);
            this.Controls.Add(this.pnlCursos);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MinimumSize = new System.Drawing.Size(830, 509);
            this.Name = "Cursos_Inicio";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Cursos_Inicio_Load);
            this.Shown += new System.EventHandler(this.Cursos_Inicio_Shown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.P_Verde.ResumeLayout(false);
            this.P_Filtrado.ResumeLayout(false);
            this.P_Filtrado.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTemas)).EndInit();
            this.CMS_Curso.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.pnlCursos.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCursos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private Label label2;
        private Label label1;
        private Panel P_Verde;
        private TextBox TBFiltro;
        private DataGridView dgvTemas;
        private Button Bt_Fin;
        private Button BT_Eliminar;
        private Button BTModifCurso;
        private Button BTAgregarCurso;
        private ContextMenuStrip CMS_Curso;
        private ToolStripMenuItem claveToolStripMenuItem;
        private ToolStripMenuItem temaToolStripMenuItem;
        private ToolStripMenuItem descripcionToolStripMenuItem;
        private ToolStripMenuItem cursoToolStripMenuItem;
        private ToolStripMenuItem horaToolStripMenuItem;
        private Panel P_Filtrado;
        private Label label3;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private Panel panel2;
        private Button btnImprimir;
        private DataGridViewTextBoxColumn Clave;
        private DataGridViewTextBoxColumn Tema;
        private DataGridViewTextBoxColumn Descripcion;
        private DataGridViewTextBoxColumn Curs;
        private DataGridViewTextBoxColumn DescCurso;
        private DataGridViewTextBoxColumn Horas;
        private Panel pnlCursos;
        private GroupBox groupBox1;
        private DataGridView dgvCursos;
        private Label label4;
        private Panel panel3;
        private Button btnCerrarCursos;
        private Button btnMostrarCursos;
        private Label label5;
        private TextBox txtCodigo;
        private Label lblTema;
        private Button button1;
    }
}