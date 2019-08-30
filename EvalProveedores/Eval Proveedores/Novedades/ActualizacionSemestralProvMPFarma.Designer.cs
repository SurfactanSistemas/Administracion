using System;
using System.ComponentModel;
using ConsultasVarias;

namespace Eval_Proveedores.Novedades
{
    partial class ActualizacionSemestralProvMPFarma
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle29 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle30 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle25 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle26 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle27 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle28 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.LB_TitEva = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copiarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copiarConCabecerasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.BT_Salir = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.btnPantalla = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblTipoListado = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TB_Desde = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TB_Hasta = new System.Windows.Forms.MaskedTextBox();
            this.LB_Titulo = new System.Windows.Forms.Label();
            this.pnlClave = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtClave = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.ckIncluirSinMovimientos = new System.Windows.Forms.CheckBox();
            this.ckFaltanteActualizacion = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ckPellital = new System.Windows.Forms.CheckBox();
            this.ckPlantaVII = new System.Windows.Forms.CheckBox();
            this.ckPlantaVI = new System.Windows.Forms.CheckBox();
            this.ckPlantaV = new System.Windows.Forms.CheckBox();
            this.ckPlantaIV = new System.Windows.Forms.CheckBox();
            this.ckPlantaIII = new System.Windows.Forms.CheckBox();
            this.ckPlantaII = new System.Windows.Forms.CheckBox();
            this.ckPlantaI = new System.Windows.Forms.CheckBox();
            this.ckTodos = new System.Windows.Forms.CheckBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.DGV_EvalSemProve = new ConsultasVarias.DBDataGridView();
            this.Proveedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MarcaPerformance = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Razon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Articulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Movimientos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Aprobados = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Desvios = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rechazados = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CertificadosOk = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EnvasesOk = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PorCert = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PorEnv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PorcTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Retrasos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EvaCal = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.FechaEvaluaProvMPFarmaII = new ConsultasVarias.MyMaskedTextBoxColumn();
            this.VerEvalua = new System.Windows.Forms.DataGridViewLinkColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.pnlClave.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_EvalSemProve)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(74)))), ((int)(((byte)(95)))));
            this.panel1.Controls.Add(this.LB_TitEva);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(966, 39);
            this.panel1.TabIndex = 4;
            // 
            // LB_TitEva
            // 
            this.LB_TitEva.AutoSize = true;
            this.LB_TitEva.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LB_TitEva.ForeColor = System.Drawing.Color.White;
            this.LB_TitEva.Location = new System.Drawing.Point(22, 11);
            this.LB_TitEva.Name = "LB_TitEva";
            this.LB_TitEva.Size = new System.Drawing.Size(678, 19);
            this.LB_TitEva.TabIndex = 0;
            this.LB_TitEva.Text = "ACTUALIZACION SEMESTRAL DE CALIFICACIÓN DE PROVEEDORES DE MATERIA PRIMA PARA FARM" +
                "A";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copiarToolStripMenuItem,
            this.copiarConCabecerasToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(190, 48);
            // 
            // copiarToolStripMenuItem
            // 
            this.copiarToolStripMenuItem.Name = "copiarToolStripMenuItem";
            this.copiarToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.copiarToolStripMenuItem.Text = "Copiar";
            this.copiarToolStripMenuItem.Click += new System.EventHandler(this.copiarToolStripMenuItem_Click);
            // 
            // copiarConCabecerasToolStripMenuItem
            // 
            this.copiarConCabecerasToolStripMenuItem.Name = "copiarConCabecerasToolStripMenuItem";
            this.copiarConCabecerasToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.copiarConCabecerasToolStripMenuItem.Text = "Copiar con Cabeceras";
            this.copiarConCabecerasToolStripMenuItem.Click += new System.EventHandler(this.copiarConCabecerasToolStripMenuItem_Click);
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::Eval_Proveedores.Properties.Resources.buscar;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.SystemColors.Control;
            this.button1.Location = new System.Drawing.Point(334, 47);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(46, 48);
            this.button1.TabIndex = 8;
            this.toolTip1.SetToolTip(this.button1, "Buscar");
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // BT_Salir
            // 
            this.BT_Salir.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.BT_Salir.BackgroundImage = global::Eval_Proveedores.Properties.Resources.Fin21;
            this.BT_Salir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BT_Salir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BT_Salir.ForeColor = System.Drawing.SystemColors.Control;
            this.BT_Salir.Location = new System.Drawing.Point(513, 510);
            this.BT_Salir.Name = "BT_Salir";
            this.BT_Salir.Size = new System.Drawing.Size(40, 40);
            this.BT_Salir.TabIndex = 79;
            this.toolTip1.SetToolTip(this.BT_Salir, "Cerrar Ventana");
            this.BT_Salir.UseVisualStyleBackColor = true;
            this.BT_Salir.Click += new System.EventHandler(this.BT_Salir_Click);
            // 
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button2.BackgroundImage = global::Eval_Proveedores.Properties.Resources.Aceptar_N2;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.SystemColors.Control;
            this.button2.Location = new System.Drawing.Point(413, 510);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(40, 40);
            this.button2.TabIndex = 79;
            this.toolTip1.SetToolTip(this.button2, "Grabar");
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnImprimir
            // 
            this.btnImprimir.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnImprimir.BackgroundImage = global::Eval_Proveedores.Properties.Resources.Imprimir;
            this.btnImprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImprimir.ForeColor = System.Drawing.SystemColors.Control;
            this.btnImprimir.Location = new System.Drawing.Point(855, 501);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(40, 40);
            this.btnImprimir.TabIndex = 79;
            this.toolTip1.SetToolTip(this.btnImprimir, "Imprimir Resumen");
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Visible = false;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // btnPantalla
            // 
            this.btnPantalla.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnPantalla.BackgroundImage = global::Eval_Proveedores.Properties.Resources.Screen_preview;
            this.btnPantalla.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnPantalla.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPantalla.ForeColor = System.Drawing.SystemColors.Control;
            this.btnPantalla.Location = new System.Drawing.Point(788, 510);
            this.btnPantalla.Name = "btnPantalla";
            this.btnPantalla.Size = new System.Drawing.Size(40, 40);
            this.btnPantalla.TabIndex = 79;
            this.toolTip1.SetToolTip(this.btnPantalla, "Resumen por Pantalla");
            this.btnPantalla.UseVisualStyleBackColor = true;
            this.btnPantalla.Visible = false;
            this.btnPantalla.Click += new System.EventHandler(this.btnPantalla_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblTipoListado
            // 
            this.lblTipoListado.Font = new System.Drawing.Font("Calibri", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipoListado.Location = new System.Drawing.Point(241, 149);
            this.lblTipoListado.Name = "lblTipoListado";
            this.lblTipoListado.Size = new System.Drawing.Size(302, 18);
            this.lblTipoListado.TabIndex = 83;
            this.lblTipoListado.Text = "LISTADO DE PROVEEDORES";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(67, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 18);
            this.label3.TabIndex = 3;
            this.label3.Text = "Desde:";
            // 
            // TB_Desde
            // 
            this.TB_Desde.Location = new System.Drawing.Point(125, 61);
            this.TB_Desde.Mask = "00/00/0000";
            this.TB_Desde.Name = "TB_Desde";
            this.TB_Desde.Size = new System.Drawing.Size(71, 20);
            this.TB_Desde.TabIndex = 4;
            this.TB_Desde.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TB_Desde.ValidatingType = typeof(System.DateTime);
            this.TB_Desde.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TB_Desde_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(203, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 18);
            this.label1.TabIndex = 5;
            this.label1.Text = "Hasta:";
            // 
            // TB_Hasta
            // 
            this.TB_Hasta.Location = new System.Drawing.Point(256, 61);
            this.TB_Hasta.Mask = "00/00/0000";
            this.TB_Hasta.Name = "TB_Hasta";
            this.TB_Hasta.Size = new System.Drawing.Size(71, 20);
            this.TB_Hasta.TabIndex = 6;
            this.TB_Hasta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TB_Hasta.ValidatingType = typeof(System.DateTime);
            this.TB_Hasta.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TB_Hasta_KeyDown);
            // 
            // LB_Titulo
            // 
            this.LB_Titulo.AutoSize = true;
            this.LB_Titulo.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LB_Titulo.Location = new System.Drawing.Point(68, 149);
            this.LB_Titulo.Name = "LB_Titulo";
            this.LB_Titulo.Size = new System.Drawing.Size(171, 18);
            this.LB_Titulo.TabIndex = 12;
            this.LB_Titulo.Text = "LISTADO DE PROVEEDORES";
            // 
            // pnlClave
            // 
            this.pnlClave.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlClave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(139)))), ((int)(((byte)(82)))));
            this.pnlClave.Controls.Add(this.groupBox1);
            this.pnlClave.Controls.Add(this.button3);
            this.pnlClave.Location = new System.Drawing.Point(383, 231);
            this.pnlClave.MaximumSize = new System.Drawing.Size(200, 100);
            this.pnlClave.Name = "pnlClave";
            this.pnlClave.Size = new System.Drawing.Size(200, 100);
            this.pnlClave.TabIndex = 81;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtClave);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Location = new System.Drawing.Point(14, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(173, 56);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Clave";
            // 
            // txtClave
            // 
            this.txtClave.Location = new System.Drawing.Point(24, 21);
            this.txtClave.Name = "txtClave";
            this.txtClave.Size = new System.Drawing.Size(124, 20);
            this.txtClave.TabIndex = 0;
            this.txtClave.UseSystemPasswordChar = true;
            this.txtClave.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtClave_KeyDown);
            // 
            // button3
            // 
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button3.Location = new System.Drawing.Point(65, 71);
            this.button3.Margin = new System.Windows.Forms.Padding(0);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(70, 22);
            this.button3.TabIndex = 77;
            this.button3.Text = "Cancelar";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // ckIncluirSinMovimientos
            // 
            this.ckIncluirSinMovimientos.Location = new System.Drawing.Point(397, 54);
            this.ckIncluirSinMovimientos.Name = "ckIncluirSinMovimientos";
            this.ckIncluirSinMovimientos.Size = new System.Drawing.Size(202, 34);
            this.ckIncluirSinMovimientos.TabIndex = 82;
            this.ckIncluirSinMovimientos.Text = "Incluir Proveedores Sin Movimientos";
            this.ckIncluirSinMovimientos.UseVisualStyleBackColor = true;
            // 
            // ckFaltanteActualizacion
            // 
            this.ckFaltanteActualizacion.Location = new System.Drawing.Point(397, 83);
            this.ckFaltanteActualizacion.Name = "ckFaltanteActualizacion";
            this.ckFaltanteActualizacion.Size = new System.Drawing.Size(162, 34);
            this.ckFaltanteActualizacion.TabIndex = 82;
            this.ckFaltanteActualizacion.Text = "Mostrar sólo faltantes de Actualización";
            this.ckFaltanteActualizacion.UseVisualStyleBackColor = true;
            this.ckFaltanteActualizacion.Visible = false;
            this.ckFaltanteActualizacion.CheckedChanged += new System.EventHandler(this.ckIncluirSinMovimientos_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ckPellital);
            this.groupBox2.Controls.Add(this.ckPlantaVII);
            this.groupBox2.Controls.Add(this.ckPlantaVI);
            this.groupBox2.Controls.Add(this.ckPlantaV);
            this.groupBox2.Controls.Add(this.ckPlantaIV);
            this.groupBox2.Controls.Add(this.ckPlantaIII);
            this.groupBox2.Controls.Add(this.ckPlantaII);
            this.groupBox2.Controls.Add(this.ckPlantaI);
            this.groupBox2.Controls.Add(this.ckTodos);
            this.groupBox2.Location = new System.Drawing.Point(593, 45);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(280, 83);
            this.groupBox2.TabIndex = 84;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Empresas";
            // 
            // ckPellital
            // 
            this.ckPellital.AutoSize = true;
            this.ckPellital.Location = new System.Drawing.Point(195, 60);
            this.ckPellital.Name = "ckPellital";
            this.ckPellital.Size = new System.Drawing.Size(56, 17);
            this.ckPellital.TabIndex = 91;
            this.ckPellital.Text = "Pellital";
            this.ckPellital.UseVisualStyleBackColor = true;
            this.ckPellital.CheckedChanged += new System.EventHandler(this.Plantas_CheckedChanged);
            // 
            // ckPlantaVII
            // 
            this.ckPlantaVII.AutoSize = true;
            this.ckPlantaVII.Location = new System.Drawing.Point(195, 37);
            this.ckPlantaVII.Name = "ckPlantaVII";
            this.ckPlantaVII.Size = new System.Drawing.Size(72, 17);
            this.ckPlantaVII.TabIndex = 90;
            this.ckPlantaVII.Text = "Planta VII";
            this.ckPlantaVII.UseVisualStyleBackColor = true;
            this.ckPlantaVII.CheckedChanged += new System.EventHandler(this.Plantas_CheckedChanged);
            // 
            // ckPlantaVI
            // 
            this.ckPlantaVI.AutoSize = true;
            this.ckPlantaVI.Location = new System.Drawing.Point(195, 14);
            this.ckPlantaVI.Name = "ckPlantaVI";
            this.ckPlantaVI.Size = new System.Drawing.Size(69, 17);
            this.ckPlantaVI.TabIndex = 93;
            this.ckPlantaVI.Text = "Planta VI";
            this.ckPlantaVI.UseVisualStyleBackColor = true;
            this.ckPlantaVI.CheckedChanged += new System.EventHandler(this.Plantas_CheckedChanged);
            // 
            // ckPlantaV
            // 
            this.ckPlantaV.AutoSize = true;
            this.ckPlantaV.Location = new System.Drawing.Point(108, 61);
            this.ckPlantaV.Name = "ckPlantaV";
            this.ckPlantaV.Size = new System.Drawing.Size(66, 17);
            this.ckPlantaV.TabIndex = 92;
            this.ckPlantaV.Text = "Planta V";
            this.ckPlantaV.UseVisualStyleBackColor = true;
            this.ckPlantaV.CheckedChanged += new System.EventHandler(this.Plantas_CheckedChanged);
            // 
            // ckPlantaIV
            // 
            this.ckPlantaIV.AutoSize = true;
            this.ckPlantaIV.Location = new System.Drawing.Point(108, 37);
            this.ckPlantaIV.Name = "ckPlantaIV";
            this.ckPlantaIV.Size = new System.Drawing.Size(69, 17);
            this.ckPlantaIV.TabIndex = 89;
            this.ckPlantaIV.Text = "Planta IV";
            this.ckPlantaIV.UseVisualStyleBackColor = true;
            this.ckPlantaIV.CheckedChanged += new System.EventHandler(this.Plantas_CheckedChanged);
            // 
            // ckPlantaIII
            // 
            this.ckPlantaIII.AutoSize = true;
            this.ckPlantaIII.Location = new System.Drawing.Point(108, 14);
            this.ckPlantaIII.Name = "ckPlantaIII";
            this.ckPlantaIII.Size = new System.Drawing.Size(68, 17);
            this.ckPlantaIII.TabIndex = 86;
            this.ckPlantaIII.Text = "Planta III";
            this.ckPlantaIII.UseVisualStyleBackColor = true;
            this.ckPlantaIII.CheckedChanged += new System.EventHandler(this.Plantas_CheckedChanged);
            // 
            // ckPlantaII
            // 
            this.ckPlantaII.AutoSize = true;
            this.ckPlantaII.Location = new System.Drawing.Point(19, 61);
            this.ckPlantaII.Name = "ckPlantaII";
            this.ckPlantaII.Size = new System.Drawing.Size(65, 17);
            this.ckPlantaII.TabIndex = 85;
            this.ckPlantaII.Text = "Planta II";
            this.ckPlantaII.UseVisualStyleBackColor = true;
            this.ckPlantaII.CheckedChanged += new System.EventHandler(this.Plantas_CheckedChanged);
            // 
            // ckPlantaI
            // 
            this.ckPlantaI.AutoSize = true;
            this.ckPlantaI.Location = new System.Drawing.Point(19, 38);
            this.ckPlantaI.Name = "ckPlantaI";
            this.ckPlantaI.Size = new System.Drawing.Size(62, 17);
            this.ckPlantaI.TabIndex = 88;
            this.ckPlantaI.Text = "Planta I";
            this.ckPlantaI.UseVisualStyleBackColor = true;
            this.ckPlantaI.CheckedChanged += new System.EventHandler(this.Plantas_CheckedChanged);
            // 
            // ckTodos
            // 
            this.ckTodos.AutoSize = true;
            this.ckTodos.Location = new System.Drawing.Point(19, 15);
            this.ckTodos.Name = "ckTodos";
            this.ckTodos.Size = new System.Drawing.Size(56, 17);
            this.ckTodos.TabIndex = 87;
            this.ckTodos.Text = "Todos";
            this.ckTodos.UseVisualStyleBackColor = true;
            this.ckTodos.CheckedChanged += new System.EventHandler(this.ckTodos_CheckedChanged);
            this.ckTodos.Click += new System.EventHandler(this.ckTodos_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(237, 144);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(636, 28);
            this.progressBar1.TabIndex = 80;
            // 
            // DGV_EvalSemProve
            // 
            this.DGV_EvalSemProve.AllowUserToAddRows = false;
            this.DGV_EvalSemProve.AllowUserToDeleteRows = false;
            this.DGV_EvalSemProve.AllowUserToResizeRows = false;
            this.DGV_EvalSemProve.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV_EvalSemProve.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle16;
            this.DGV_EvalSemProve.ColumnHeadersHeight = 34;
            this.DGV_EvalSemProve.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Proveedor,
            this.MarcaPerformance,
            this.Razon,
            this.Articulo,
            this.Movimientos,
            this.Aprobados,
            this.Desvios,
            this.Rechazados,
            this.CertificadosOk,
            this.EnvasesOk,
            this.PorCert,
            this.PorEnv,
            this.PorcTotal,
            this.Retrasos,
            this.EvaCal,
            this.FechaEvaluaProvMPFarmaII,
            this.VerEvalua});
            this.DGV_EvalSemProve.ContextMenuStrip = this.contextMenuStrip1;
            dataGridViewCellStyle29.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle29.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle29.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle29.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle29.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle29.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle29.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGV_EvalSemProve.DefaultCellStyle = dataGridViewCellStyle29;
            this.DGV_EvalSemProve.DoubleBuffered = true;
            this.DGV_EvalSemProve.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.DGV_EvalSemProve.Location = new System.Drawing.Point(6, 183);
            this.DGV_EvalSemProve.Name = "DGV_EvalSemProve";
            dataGridViewCellStyle30.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle30.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle30.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle30.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle30.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle30.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV_EvalSemProve.RowHeadersDefaultCellStyle = dataGridViewCellStyle30;
            this.DGV_EvalSemProve.RowHeadersWidth = 15;
            this.DGV_EvalSemProve.RowTemplate.Height = 18;
            this.DGV_EvalSemProve.ShowCellToolTips = false;
            this.DGV_EvalSemProve.SinClickDerecho = false;
            this.DGV_EvalSemProve.Size = new System.Drawing.Size(954, 312);
            this.DGV_EvalSemProve.TabIndex = 9;
            this.DGV_EvalSemProve.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_EvalSemProve_CellClick);
            this.DGV_EvalSemProve.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_EvalSemProve_CellDoubleClick);
            this.DGV_EvalSemProve.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_EvalSemProve_CellEnter);
            // 
            // Proveedor
            // 
            this.Proveedor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Proveedor.DataPropertyName = "CodProve";
            this.Proveedor.HeaderText = "CodigoProve";
            this.Proveedor.Name = "Proveedor";
            this.Proveedor.ReadOnly = true;
            this.Proveedor.Width = 93;
            // 
            // MarcaPerformance
            // 
            this.MarcaPerformance.FalseValue = "0";
            this.MarcaPerformance.HeaderText = "";
            this.MarcaPerformance.Name = "MarcaPerformance";
            this.MarcaPerformance.TrueValue = "1";
            this.MarcaPerformance.Visible = false;
            this.MarcaPerformance.Width = 20;
            // 
            // Razon
            // 
            this.Razon.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Razon.DataPropertyName = "DescProve";
            this.Razon.HeaderText = "Proveedor";
            this.Razon.MinimumWidth = 100;
            this.Razon.Name = "Razon";
            this.Razon.ReadOnly = true;
            // 
            // Articulo
            // 
            this.Articulo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Articulo.HeaderText = "Articulo";
            this.Articulo.MinimumWidth = 70;
            this.Articulo.Name = "Articulo";
            this.Articulo.ReadOnly = true;
            this.Articulo.Width = 70;
            // 
            // Movimientos
            // 
            this.Movimientos.DataPropertyName = "Items";
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Movimientos.DefaultCellStyle = dataGridViewCellStyle17;
            this.Movimientos.HeaderText = "Items";
            this.Movimientos.Name = "Movimientos";
            this.Movimientos.ReadOnly = true;
            this.Movimientos.Visible = false;
            this.Movimientos.Width = 40;
            // 
            // Aprobados
            // 
            this.Aprobados.DataPropertyName = "Aprobado";
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Aprobados.DefaultCellStyle = dataGridViewCellStyle18;
            this.Aprobados.HeaderText = "Aprob.";
            this.Aprobados.Name = "Aprobados";
            this.Aprobados.ReadOnly = true;
            this.Aprobados.Width = 40;
            // 
            // Desvios
            // 
            this.Desvios.DataPropertyName = "Desviado";
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Desvios.DefaultCellStyle = dataGridViewCellStyle19;
            this.Desvios.HeaderText = "Desv.";
            this.Desvios.Name = "Desvios";
            this.Desvios.ReadOnly = true;
            this.Desvios.Width = 40;
            // 
            // Rechazados
            // 
            this.Rechazados.DataPropertyName = "Rechazado";
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Rechazados.DefaultCellStyle = dataGridViewCellStyle20;
            this.Rechazados.HeaderText = "Rech.";
            this.Rechazados.Name = "Rechazados";
            this.Rechazados.ReadOnly = true;
            this.Rechazados.Width = 40;
            // 
            // CertificadosOk
            // 
            this.CertificadosOk.DataPropertyName = "Certificado";
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.CertificadosOk.DefaultCellStyle = dataGridViewCellStyle21;
            this.CertificadosOk.HeaderText = "Cert.";
            this.CertificadosOk.Name = "CertificadosOk";
            this.CertificadosOk.ReadOnly = true;
            this.CertificadosOk.Width = 40;
            // 
            // EnvasesOk
            // 
            this.EnvasesOk.DataPropertyName = "Enviado";
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.EnvasesOk.DefaultCellStyle = dataGridViewCellStyle22;
            this.EnvasesOk.HeaderText = "Env.";
            this.EnvasesOk.Name = "EnvasesOk";
            this.EnvasesOk.ReadOnly = true;
            this.EnvasesOk.Width = 40;
            // 
            // PorCert
            // 
            this.PorCert.DataPropertyName = "PorcCert";
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.PorCert.DefaultCellStyle = dataGridViewCellStyle23;
            this.PorCert.HeaderText = "%Cert.";
            this.PorCert.Name = "PorCert";
            this.PorCert.ReadOnly = true;
            this.PorCert.Width = 40;
            // 
            // PorEnv
            // 
            this.PorEnv.DataPropertyName = "PorcEnv";
            dataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.PorEnv.DefaultCellStyle = dataGridViewCellStyle24;
            this.PorEnv.HeaderText = "%Env.";
            this.PorEnv.Name = "PorEnv";
            this.PorEnv.ReadOnly = true;
            this.PorEnv.Width = 40;
            // 
            // PorcTotal
            // 
            this.PorcTotal.DataPropertyName = "PorcTotal";
            dataGridViewCellStyle25.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.PorcTotal.DefaultCellStyle = dataGridViewCellStyle25;
            this.PorcTotal.HeaderText = "%";
            this.PorcTotal.Name = "PorcTotal";
            this.PorcTotal.ReadOnly = true;
            this.PorcTotal.Width = 40;
            // 
            // Retrasos
            // 
            this.Retrasos.DataPropertyName = "Atraso";
            dataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Retrasos.DefaultCellStyle = dataGridViewCellStyle26;
            this.Retrasos.HeaderText = "Atraso";
            this.Retrasos.Name = "Retrasos";
            this.Retrasos.ReadOnly = true;
            this.Retrasos.Width = 40;
            // 
            // EvaCal
            // 
            this.EvaCal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewCellStyle27.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.EvaCal.DefaultCellStyle = dataGridViewCellStyle27;
            this.EvaCal.DividerWidth = 1;
            this.EvaCal.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.EvaCal.HeaderText = "Calidad";
            this.EvaCal.Items.AddRange(new object[] {
            "",
            "APROBADO FARMA",
            "RECHAZADO FARMA",
            "EVENTUAL FARMA"});
            this.EvaCal.MinimumWidth = 100;
            this.EvaCal.Name = "EvaCal";
            // 
            // FechaEvaluaProvMPFarmaII
            // 
            dataGridViewCellStyle28.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.FechaEvaluaProvMPFarmaII.DefaultCellStyle = dataGridViewCellStyle28;
            this.FechaEvaluaProvMPFarmaII.HeaderText = "Fecha Evalua";
            this.FechaEvaluaProvMPFarmaII.IncludeLiterals = true;
            this.FechaEvaluaProvMPFarmaII.IncludePrompt = true;
            this.FechaEvaluaProvMPFarmaII.Mask = "00/00/0000";
            this.FechaEvaluaProvMPFarmaII.MinimumWidth = 70;
            this.FechaEvaluaProvMPFarmaII.Name = "FechaEvaluaProvMPFarmaII";
            this.FechaEvaluaProvMPFarmaII.PromptChar = ' ';
            this.FechaEvaluaProvMPFarmaII.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.FechaEvaluaProvMPFarmaII.ValidatingType = null;
            this.FechaEvaluaProvMPFarmaII.Width = 70;
            // 
            // VerEvalua
            // 
            this.VerEvalua.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.VerEvalua.HeaderText = "Ver Evaluación";
            this.VerEvalua.MinimumWidth = 70;
            this.VerEvalua.Name = "VerEvalua";
            this.VerEvalua.ReadOnly = true;
            this.VerEvalua.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.VerEvalua.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.VerEvalua.Text = "Ver Evaluación";
            this.VerEvalua.UseColumnTextForLinkValue = true;
            this.VerEvalua.Width = 96;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(67, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(195, 13);
            this.label2.TabIndex = 85;
            this.label2.Text = "FILTRAR POR TIPO PRODUCTO";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "TODOS",
            "FARMA",
            "FOOD",
            "VETERINARIO",
            "OTROS"});
            this.comboBox1.Location = new System.Drawing.Point(271, 101);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 86;
            // 
            // ActualizacionSemestralProvMPFarma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(966, 562);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.ckFaltanteActualizacion);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ckIncluirSinMovimientos);
            this.Controls.Add(this.TB_Desde);
            this.Controls.Add(this.pnlClave);
            this.Controls.Add(this.lblTipoListado);
            this.Controls.Add(this.btnPantalla);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.TB_Hasta);
            this.Controls.Add(this.BT_Salir);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.DGV_EvalSemProve);
            this.Controls.Add(this.LB_Titulo);
            this.Location = new System.Drawing.Point(20, 20);
            this.MinimumSize = new System.Drawing.Size(884, 601);
            this.Name = "ActualizacionSemestralProvMPFarma";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ActSemProv_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.pnlClave.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_EvalSemProve)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label LB_TitEva;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem copiarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copiarConCabecerasToolStripMenuItem;
        private System.Windows.Forms.Label lblTipoListado;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox TB_Desde;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox TB_Hasta;
        private System.Windows.Forms.Button button1;
        private DBDataGridView DGV_EvalSemProve;
        private System.Windows.Forms.Label LB_Titulo;
        private System.Windows.Forms.Button BT_Salir;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Button btnPantalla;
        private System.Windows.Forms.Panel pnlClave;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtClave;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.CheckBox ckIncluirSinMovimientos;
        private System.Windows.Forms.CheckBox ckFaltanteActualizacion;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox ckPellital;
        private System.Windows.Forms.CheckBox ckPlantaVII;
        private System.Windows.Forms.CheckBox ckPlantaVI;
        private System.Windows.Forms.CheckBox ckPlantaV;
        private System.Windows.Forms.CheckBox ckPlantaIV;
        private System.Windows.Forms.CheckBox ckPlantaIII;
        private System.Windows.Forms.CheckBox ckPlantaII;
        private System.Windows.Forms.CheckBox ckPlantaI;
        private System.Windows.Forms.CheckBox ckTodos;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Proveedor;
        private System.Windows.Forms.DataGridViewCheckBoxColumn MarcaPerformance;
        private System.Windows.Forms.DataGridViewTextBoxColumn Razon;
        private System.Windows.Forms.DataGridViewTextBoxColumn Articulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Movimientos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Aprobados;
        private System.Windows.Forms.DataGridViewTextBoxColumn Desvios;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rechazados;
        private System.Windows.Forms.DataGridViewTextBoxColumn CertificadosOk;
        private System.Windows.Forms.DataGridViewTextBoxColumn EnvasesOk;
        private System.Windows.Forms.DataGridViewTextBoxColumn PorCert;
        private System.Windows.Forms.DataGridViewTextBoxColumn PorEnv;
        private System.Windows.Forms.DataGridViewTextBoxColumn PorcTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn Retrasos;
        private System.Windows.Forms.DataGridViewComboBoxColumn EvaCal;
        private MyMaskedTextBoxColumn FechaEvaluaProvMPFarmaII;
        private System.Windows.Forms.DataGridViewLinkColumn VerEvalua;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}