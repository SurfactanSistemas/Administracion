using System.ComponentModel;
using System.Windows.Forms;

namespace HojaRuta.IngCamiones
{
    partial class AgModCamiones
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.LBCamion = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.TB_ObservacRuta = new System.Windows.Forms.TextBox();
            this.TB_ObservRTO = new System.Windows.Forms.TextBox();
            this.TB_EntRuta = new System.Windows.Forms.MaskedTextBox();
            this.TB_VencRuta = new System.Windows.Forms.MaskedTextBox();
            this.TB_EntRTO = new System.Windows.Forms.MaskedTextBox();
            this.TB_VencRTO = new System.Windows.Forms.MaskedTextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.TB_Patente = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.CB_Estado = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.TB_Descripcion = new System.Windows.Forms.TextBox();
            this.TB_CodCamion = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.LFechaAviso = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.TB_NombChofer = new System.Windows.Forms.ComboBox();
            this.TB_CodChofer = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.BT_Salir = new System.Windows.Forms.Button();
            this.BT_LimpiarPant = new System.Windows.Forms.Button();
            this.BT_Guardar = new System.Windows.Forms.Button();
            this.txtObsRENPRE = new System.Windows.Forms.TextBox();
            this.TB_ObservCargasPelig = new System.Windows.Forms.TextBox();
            this.TB_ObservSeguro = new System.Windows.Forms.TextBox();
            this.TB_ObservHabDominio = new System.Windows.Forms.TextBox();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.txtFechaEntregaRENPRE = new System.Windows.Forms.MaskedTextBox();
            this.TB_EntCargasPelig = new System.Windows.Forms.MaskedTextBox();
            this.TB_EntSeguro = new System.Windows.Forms.MaskedTextBox();
            this.TB_EntHabDominio = new System.Windows.Forms.MaskedTextBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.txtVencimientoRENPRE = new System.Windows.Forms.MaskedTextBox();
            this.TB_VencCargasPelig = new System.Windows.Forms.MaskedTextBox();
            this.TB_VencSeguro = new System.Windows.Forms.MaskedTextBox();
            this.TB_VencHabDominio = new System.Windows.Forms.MaskedTextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.CB_CargasPeligrosas = new System.Windows.Forms.CheckBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.TB_CodProveedor = new System.Windows.Forms.ComboBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.TB_NombProveedor = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(139)))), ((int)(((byte)(82)))));
            this.panel1.Controls.Add(this.LBCamion);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(846, 39);
            this.panel1.TabIndex = 2;
            // 
            // LBCamion
            // 
            this.LBCamion.AutoSize = true;
            this.LBCamion.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBCamion.ForeColor = System.Drawing.Color.White;
            this.LBCamion.Location = new System.Drawing.Point(22, 11);
            this.LBCamion.Name = "LBCamion";
            this.LBCamion.Size = new System.Drawing.Size(154, 19);
            this.LBCamion.TabIndex = 0;
            this.LBCamion.Text = "INGRESO DE CAMIÓN";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(74)))), ((int)(((byte)(95)))));
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 39);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(846, 503);
            this.panel2.TabIndex = 3;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.Control;
            this.panel3.Controls.Add(this.groupBox4);
            this.panel3.Controls.Add(this.TB_ObservacRuta);
            this.panel3.Controls.Add(this.TB_ObservRTO);
            this.panel3.Controls.Add(this.TB_EntRuta);
            this.panel3.Controls.Add(this.TB_VencRuta);
            this.panel3.Controls.Add(this.TB_EntRTO);
            this.panel3.Controls.Add(this.TB_VencRTO);
            this.panel3.Controls.Add(this.label15);
            this.panel3.Controls.Add(this.label14);
            this.panel3.Controls.Add(this.groupBox3);
            this.panel3.Controls.Add(this.groupBox2);
            this.panel3.Controls.Add(this.txtObsRENPRE);
            this.panel3.Controls.Add(this.TB_ObservCargasPelig);
            this.panel3.Controls.Add(this.TB_ObservSeguro);
            this.panel3.Controls.Add(this.TB_ObservHabDominio);
            this.panel3.Controls.Add(this.textBox9);
            this.panel3.Controls.Add(this.txtFechaEntregaRENPRE);
            this.panel3.Controls.Add(this.TB_EntCargasPelig);
            this.panel3.Controls.Add(this.TB_EntSeguro);
            this.panel3.Controls.Add(this.TB_EntHabDominio);
            this.panel3.Controls.Add(this.textBox8);
            this.panel3.Controls.Add(this.txtVencimientoRENPRE);
            this.panel3.Controls.Add(this.TB_VencCargasPelig);
            this.panel3.Controls.Add(this.TB_VencSeguro);
            this.panel3.Controls.Add(this.TB_VencHabDominio);
            this.panel3.Controls.Add(this.textBox7);
            this.panel3.Controls.Add(this.checkBox1);
            this.panel3.Controls.Add(this.CB_CargasPeligrosas);
            this.panel3.Controls.Add(this.textBox6);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.textBox5);
            this.panel3.Controls.Add(this.groupBox1);
            this.panel3.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel3.Location = new System.Drawing.Point(8, 10);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(830, 483);
            this.panel3.TabIndex = 0;
            this.panel3.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panel3_MouseClick);
            // 
            // TB_ObservacRuta
            // 
            this.TB_ObservacRuta.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TB_ObservacRuta.Location = new System.Drawing.Point(573, 283);
            this.TB_ObservacRuta.Name = "TB_ObservacRuta";
            this.TB_ObservacRuta.Size = new System.Drawing.Size(241, 26);
            this.TB_ObservacRuta.TabIndex = 9;
            this.TB_ObservacRuta.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TB_ObservacRuta_MouseClick);
            this.TB_ObservacRuta.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TB_ObservacRuta_KeyDown);
            // 
            // TB_ObservRTO
            // 
            this.TB_ObservRTO.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TB_ObservRTO.Location = new System.Drawing.Point(573, 317);
            this.TB_ObservRTO.Name = "TB_ObservRTO";
            this.TB_ObservRTO.Size = new System.Drawing.Size(241, 26);
            this.TB_ObservRTO.TabIndex = 12;
            this.TB_ObservRTO.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TB_ObservRTO_MouseClick);
            this.TB_ObservRTO.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TB_ObservRTO_KeyDown);
            // 
            // TB_EntRuta
            // 
            this.TB_EntRuta.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TB_EntRuta.Location = new System.Drawing.Point(464, 283);
            this.TB_EntRuta.Mask = "00/00/0000";
            this.TB_EntRuta.Name = "TB_EntRuta";
            this.TB_EntRuta.PromptChar = ' ';
            this.TB_EntRuta.Size = new System.Drawing.Size(100, 26);
            this.TB_EntRuta.TabIndex = 8;
            this.TB_EntRuta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TB_EntRuta.ValidatingType = typeof(System.DateTime);
            this.TB_EntRuta.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TB_EntRuta_KeyDown);
            // 
            // TB_VencRuta
            // 
            this.TB_VencRuta.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TB_VencRuta.Location = new System.Drawing.Point(349, 283);
            this.TB_VencRuta.Mask = "00/00/0000";
            this.TB_VencRuta.Name = "TB_VencRuta";
            this.TB_VencRuta.PromptChar = ' ';
            this.TB_VencRuta.Size = new System.Drawing.Size(100, 26);
            this.TB_VencRuta.TabIndex = 7;
            this.TB_VencRuta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TB_VencRuta.ValidatingType = typeof(System.DateTime);
            this.TB_VencRuta.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TB_VencRuta_KeyDown);
            // 
            // TB_EntRTO
            // 
            this.TB_EntRTO.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TB_EntRTO.Location = new System.Drawing.Point(464, 317);
            this.TB_EntRTO.Mask = "00/00/0000";
            this.TB_EntRTO.Name = "TB_EntRTO";
            this.TB_EntRTO.PromptChar = ' ';
            this.TB_EntRTO.Size = new System.Drawing.Size(100, 26);
            this.TB_EntRTO.TabIndex = 11;
            this.TB_EntRTO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TB_EntRTO.ValidatingType = typeof(System.DateTime);
            this.TB_EntRTO.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TB_EntRTO_MouseClick);
            this.TB_EntRTO.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TB_EntRTO_KeyDown);
            // 
            // TB_VencRTO
            // 
            this.TB_VencRTO.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TB_VencRTO.Location = new System.Drawing.Point(349, 317);
            this.TB_VencRTO.Mask = "00/00/0000";
            this.TB_VencRTO.Name = "TB_VencRTO";
            this.TB_VencRTO.PromptChar = ' ';
            this.TB_VencRTO.Size = new System.Drawing.Size(100, 26);
            this.TB_VencRTO.TabIndex = 10;
            this.TB_VencRTO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TB_VencRTO.ValidatingType = typeof(System.DateTime);
            this.TB_VencRTO.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TB_VencRTO_MouseClick);
            this.TB_VencRTO.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TB_VencRTO_KeyDown);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(22, 383);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(51, 18);
            this.label15.TabIndex = 48;
            this.label15.Text = "Seguro";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(22, 352);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(157, 18);
            this.label14.TabIndex = 47;
            this.label14.Text = "Habilitación de Dominio";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.TB_Patente);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.CB_Estado);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.TB_Descripcion);
            this.groupBox3.Controls.Add(this.TB_CodCamion);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.LFechaAviso);
            this.groupBox3.Location = new System.Drawing.Point(14, 7);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(787, 89);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "CAMIÓN";
            // 
            // TB_Patente
            // 
            this.TB_Patente.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TB_Patente.Location = new System.Drawing.Point(661, 51);
            this.TB_Patente.Name = "TB_Patente";
            this.TB_Patente.Size = new System.Drawing.Size(102, 26);
            this.TB_Patente.TabIndex = 2;
            this.TB_Patente.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TB_Patente_MouseClick);
            this.TB_Patente.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TB_Patente_KeyDown);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(597, 55);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(61, 18);
            this.label13.TabIndex = 44;
            this.label13.Text = "Patente:";
            // 
            // CB_Estado
            // 
            this.CB_Estado.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CB_Estado.FormattingEnabled = true;
            this.CB_Estado.Items.AddRange(new object[] {
            "",
            "Inhabilitado"});
            this.CB_Estado.Location = new System.Drawing.Point(339, 20);
            this.CB_Estado.Name = "CB_Estado";
            this.CB_Estado.Size = new System.Drawing.Size(233, 26);
            this.CB_Estado.TabIndex = 100;
            this.CB_Estado.MouseClick += new System.Windows.Forms.MouseEventHandler(this.CB_Estado_MouseClick);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(276, 24);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 18);
            this.label8.TabIndex = 38;
            this.label8.Text = "Estado:";
            // 
            // TB_Descripcion
            // 
            this.TB_Descripcion.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TB_Descripcion.Location = new System.Drawing.Point(149, 51);
            this.TB_Descripcion.Name = "TB_Descripcion";
            this.TB_Descripcion.Size = new System.Drawing.Size(423, 26);
            this.TB_Descripcion.TabIndex = 1;
            this.TB_Descripcion.MarginChanged += new System.EventHandler(this.TB_Descripcion_MarginChanged);
            this.TB_Descripcion.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TB_Descripcion_KeyDown);
            // 
            // TB_CodCamion
            // 
            this.TB_CodCamion.Location = new System.Drawing.Point(149, 20);
            this.TB_CodCamion.Name = "TB_CodCamion";
            this.TB_CodCamion.ReadOnly = true;
            this.TB_CodCamion.Size = new System.Drawing.Size(100, 26);
            this.TB_CodCamion.TabIndex = 101;
            this.TB_CodCamion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(46, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Descripción:";
            // 
            // LFechaAviso
            // 
            this.LFechaAviso.AutoSize = true;
            this.LFechaAviso.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LFechaAviso.Location = new System.Drawing.Point(75, 24);
            this.LFechaAviso.Name = "LFechaAviso";
            this.LFechaAviso.Size = new System.Drawing.Size(55, 18);
            this.LFechaAviso.TabIndex = 1;
            this.LFechaAviso.Text = "Codigo:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.TB_NombChofer);
            this.groupBox2.Controls.Add(this.TB_CodChofer);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(16, 172);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(583, 61);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "CHOFER";
            // 
            // TB_NombChofer
            // 
            this.TB_NombChofer.FormattingEnabled = true;
            this.TB_NombChofer.Location = new System.Drawing.Point(339, 21);
            this.TB_NombChofer.Name = "TB_NombChofer";
            this.TB_NombChofer.Size = new System.Drawing.Size(233, 26);
            this.TB_NombChofer.TabIndex = 5;
            this.TB_NombChofer.SelectedIndexChanged += new System.EventHandler(this.TB_NombChofer_SelectedIndexChanged);
            // 
            // TB_CodChofer
            // 
            this.TB_CodChofer.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TB_CodChofer.Location = new System.Drawing.Point(152, 21);
            this.TB_CodChofer.Name = "TB_CodChofer";
            this.TB_CodChofer.ReadOnly = true;
            this.TB_CodChofer.Size = new System.Drawing.Size(100, 26);
            this.TB_CodChofer.TabIndex = 6;
            this.TB_CodChofer.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TB_CodChofer.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TB_CodChofer_MouseClick);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(271, 25);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(63, 18);
            this.label9.TabIndex = 3;
            this.label9.Text = "Nombre:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(78, 25);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(55, 18);
            this.label10.TabIndex = 2;
            this.label10.Text = "Codigo:";
            // 
            // BT_Salir
            // 
            this.BT_Salir.BackgroundImage = global::HojaRuta.Properties.Resources.Fin21;
            this.BT_Salir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BT_Salir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BT_Salir.ForeColor = System.Drawing.SystemColors.Control;
            this.BT_Salir.Location = new System.Drawing.Point(143, 27);
            this.BT_Salir.Name = "BT_Salir";
            this.BT_Salir.Size = new System.Drawing.Size(40, 40);
            this.BT_Salir.TabIndex = 24;
            this.toolTip1.SetToolTip(this.BT_Salir, "Salir");
            this.BT_Salir.UseVisualStyleBackColor = true;
            this.BT_Salir.Click += new System.EventHandler(this.BT_Salir_Click);
            // 
            // BT_LimpiarPant
            // 
            this.BT_LimpiarPant.BackgroundImage = global::HojaRuta.Properties.Resources.LimpiarPant1;
            this.BT_LimpiarPant.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BT_LimpiarPant.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BT_LimpiarPant.ForeColor = System.Drawing.SystemColors.Control;
            this.BT_LimpiarPant.Location = new System.Drawing.Point(76, 27);
            this.BT_LimpiarPant.Margin = new System.Windows.Forms.Padding(0);
            this.BT_LimpiarPant.Name = "BT_LimpiarPant";
            this.BT_LimpiarPant.Size = new System.Drawing.Size(40, 40);
            this.BT_LimpiarPant.TabIndex = 23;
            this.toolTip1.SetToolTip(this.BT_LimpiarPant, "Limpiar Pantalla");
            this.BT_LimpiarPant.UseVisualStyleBackColor = true;
            this.BT_LimpiarPant.Click += new System.EventHandler(this.BT_LimpiarPant_Click);
            // 
            // BT_Guardar
            // 
            this.BT_Guardar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BT_Guardar.BackgroundImage = global::HojaRuta.Properties.Resources.Grabar;
            this.BT_Guardar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BT_Guardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BT_Guardar.ForeColor = System.Drawing.SystemColors.Control;
            this.BT_Guardar.Location = new System.Drawing.Point(9, 27);
            this.BT_Guardar.Margin = new System.Windows.Forms.Padding(0);
            this.BT_Guardar.Name = "BT_Guardar";
            this.BT_Guardar.Size = new System.Drawing.Size(40, 40);
            this.BT_Guardar.TabIndex = 22;
            this.toolTip1.SetToolTip(this.BT_Guardar, "Guardar");
            this.BT_Guardar.UseVisualStyleBackColor = true;
            this.BT_Guardar.Click += new System.EventHandler(this.BT_Guardar_Click);
            // 
            // txtObsRENPRE
            // 
            this.txtObsRENPRE.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtObsRENPRE.Location = new System.Drawing.Point(573, 446);
            this.txtObsRENPRE.Name = "txtObsRENPRE";
            this.txtObsRENPRE.Size = new System.Drawing.Size(241, 26);
            this.txtObsRENPRE.TabIndex = 21;
            // 
            // TB_ObservCargasPelig
            // 
            this.TB_ObservCargasPelig.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TB_ObservCargasPelig.Location = new System.Drawing.Point(573, 411);
            this.TB_ObservCargasPelig.Name = "TB_ObservCargasPelig";
            this.TB_ObservCargasPelig.Size = new System.Drawing.Size(241, 26);
            this.TB_ObservCargasPelig.TabIndex = 21;
            this.TB_ObservCargasPelig.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TB_ObservCargasPelig_MouseClick);
            this.TB_ObservCargasPelig.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TB_ObservCargasPelig_KeyDown);
            // 
            // TB_ObservSeguro
            // 
            this.TB_ObservSeguro.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TB_ObservSeguro.Location = new System.Drawing.Point(573, 379);
            this.TB_ObservSeguro.Name = "TB_ObservSeguro";
            this.TB_ObservSeguro.Size = new System.Drawing.Size(241, 26);
            this.TB_ObservSeguro.TabIndex = 18;
            this.TB_ObservSeguro.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TB_ObservSeguro_MouseClick);
            this.TB_ObservSeguro.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TB_ObservSeguro_KeyDown);
            // 
            // TB_ObservHabDominio
            // 
            this.TB_ObservHabDominio.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TB_ObservHabDominio.Location = new System.Drawing.Point(573, 348);
            this.TB_ObservHabDominio.Name = "TB_ObservHabDominio";
            this.TB_ObservHabDominio.Size = new System.Drawing.Size(241, 26);
            this.TB_ObservHabDominio.TabIndex = 15;
            this.TB_ObservHabDominio.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TB_ObservHabDominio_MouseClick);
            this.TB_ObservHabDominio.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TB_ObservHabDominio_KeyDown);
            // 
            // textBox9
            // 
            this.textBox9.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox9.Location = new System.Drawing.Point(573, 246);
            this.textBox9.Name = "textBox9";
            this.textBox9.ReadOnly = true;
            this.textBox9.Size = new System.Drawing.Size(241, 27);
            this.textBox9.TabIndex = 34;
            this.textBox9.Text = "              OBSERVACIONES";
            // 
            // txtFechaEntregaRENPRE
            // 
            this.txtFechaEntregaRENPRE.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFechaEntregaRENPRE.Location = new System.Drawing.Point(464, 446);
            this.txtFechaEntregaRENPRE.Mask = "00/00/0000";
            this.txtFechaEntregaRENPRE.Name = "txtFechaEntregaRENPRE";
            this.txtFechaEntregaRENPRE.PromptChar = ' ';
            this.txtFechaEntregaRENPRE.Size = new System.Drawing.Size(100, 26);
            this.txtFechaEntregaRENPRE.TabIndex = 20;
            this.txtFechaEntregaRENPRE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtFechaEntregaRENPRE.ValidatingType = typeof(System.DateTime);
            this.txtFechaEntregaRENPRE.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TB_EntCargasPelig_MouseClick);
            this.txtFechaEntregaRENPRE.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFechaEntregaRENPRE_KeyDown);
            // 
            // TB_EntCargasPelig
            // 
            this.TB_EntCargasPelig.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TB_EntCargasPelig.Location = new System.Drawing.Point(464, 411);
            this.TB_EntCargasPelig.Mask = "00/00/0000";
            this.TB_EntCargasPelig.Name = "TB_EntCargasPelig";
            this.TB_EntCargasPelig.PromptChar = ' ';
            this.TB_EntCargasPelig.Size = new System.Drawing.Size(100, 26);
            this.TB_EntCargasPelig.TabIndex = 20;
            this.TB_EntCargasPelig.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TB_EntCargasPelig.ValidatingType = typeof(System.DateTime);
            this.TB_EntCargasPelig.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TB_EntCargasPelig_MouseClick);
            this.TB_EntCargasPelig.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TB_EntCargasPelig_KeyDown);
            // 
            // TB_EntSeguro
            // 
            this.TB_EntSeguro.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TB_EntSeguro.Location = new System.Drawing.Point(464, 379);
            this.TB_EntSeguro.Mask = "00/00/0000";
            this.TB_EntSeguro.Name = "TB_EntSeguro";
            this.TB_EntSeguro.PromptChar = ' ';
            this.TB_EntSeguro.Size = new System.Drawing.Size(100, 26);
            this.TB_EntSeguro.TabIndex = 17;
            this.TB_EntSeguro.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TB_EntSeguro.ValidatingType = typeof(System.DateTime);
            this.TB_EntSeguro.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TB_EntSeguro_MouseClick);
            this.TB_EntSeguro.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TB_EntSeguro_KeyDown);
            // 
            // TB_EntHabDominio
            // 
            this.TB_EntHabDominio.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TB_EntHabDominio.Location = new System.Drawing.Point(464, 348);
            this.TB_EntHabDominio.Mask = "00/00/0000";
            this.TB_EntHabDominio.Name = "TB_EntHabDominio";
            this.TB_EntHabDominio.PromptChar = ' ';
            this.TB_EntHabDominio.Size = new System.Drawing.Size(100, 26);
            this.TB_EntHabDominio.TabIndex = 14;
            this.TB_EntHabDominio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TB_EntHabDominio.ValidatingType = typeof(System.DateTime);
            this.TB_EntHabDominio.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TB_EntHabDominio_MouseClick);
            this.TB_EntHabDominio.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TB_EntHabDominio_KeyDown);
            // 
            // textBox8
            // 
            this.textBox8.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox8.Location = new System.Drawing.Point(464, 246);
            this.textBox8.Name = "textBox8";
            this.textBox8.ReadOnly = true;
            this.textBox8.Size = new System.Drawing.Size(100, 27);
            this.textBox8.TabIndex = 33;
            this.textBox8.Text = "F. ENTREGA";
            this.textBox8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtVencimientoRENPRE
            // 
            this.txtVencimientoRENPRE.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVencimientoRENPRE.Location = new System.Drawing.Point(349, 446);
            this.txtVencimientoRENPRE.Mask = "00/00/0000";
            this.txtVencimientoRENPRE.Name = "txtVencimientoRENPRE";
            this.txtVencimientoRENPRE.PromptChar = ' ';
            this.txtVencimientoRENPRE.Size = new System.Drawing.Size(100, 26);
            this.txtVencimientoRENPRE.TabIndex = 19;
            this.txtVencimientoRENPRE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtVencimientoRENPRE.ValidatingType = typeof(System.DateTime);
            this.txtVencimientoRENPRE.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TB_VencCargasPelig_MouseClick);
            this.txtVencimientoRENPRE.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtVencimientoRENPRE_KeyDown);
            // 
            // TB_VencCargasPelig
            // 
            this.TB_VencCargasPelig.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TB_VencCargasPelig.Location = new System.Drawing.Point(349, 411);
            this.TB_VencCargasPelig.Mask = "00/00/0000";
            this.TB_VencCargasPelig.Name = "TB_VencCargasPelig";
            this.TB_VencCargasPelig.PromptChar = ' ';
            this.TB_VencCargasPelig.Size = new System.Drawing.Size(100, 26);
            this.TB_VencCargasPelig.TabIndex = 19;
            this.TB_VencCargasPelig.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TB_VencCargasPelig.ValidatingType = typeof(System.DateTime);
            this.TB_VencCargasPelig.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TB_VencCargasPelig_MouseClick);
            this.TB_VencCargasPelig.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TB_VencCargasPelig_KeyDown);
            // 
            // TB_VencSeguro
            // 
            this.TB_VencSeguro.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TB_VencSeguro.Location = new System.Drawing.Point(349, 379);
            this.TB_VencSeguro.Mask = "00/00/0000";
            this.TB_VencSeguro.Name = "TB_VencSeguro";
            this.TB_VencSeguro.PromptChar = ' ';
            this.TB_VencSeguro.Size = new System.Drawing.Size(100, 26);
            this.TB_VencSeguro.TabIndex = 16;
            this.TB_VencSeguro.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TB_VencSeguro.ValidatingType = typeof(System.DateTime);
            this.TB_VencSeguro.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TB_VencSeguro_MouseClick);
            this.TB_VencSeguro.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TB_VencSeguro_KeyDown);
            // 
            // TB_VencHabDominio
            // 
            this.TB_VencHabDominio.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TB_VencHabDominio.Location = new System.Drawing.Point(349, 348);
            this.TB_VencHabDominio.Mask = "00/00/0000";
            this.TB_VencHabDominio.Name = "TB_VencHabDominio";
            this.TB_VencHabDominio.PromptChar = ' ';
            this.TB_VencHabDominio.Size = new System.Drawing.Size(100, 26);
            this.TB_VencHabDominio.TabIndex = 13;
            this.TB_VencHabDominio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TB_VencHabDominio.ValidatingType = typeof(System.DateTime);
            this.TB_VencHabDominio.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TB_VencHabDominio_MouseClick);
            this.TB_VencHabDominio.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TB_VencHabDominio_KeyDown);
            // 
            // textBox7
            // 
            this.textBox7.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox7.Location = new System.Drawing.Point(349, 246);
            this.textBox7.Name = "textBox7";
            this.textBox7.ReadOnly = true;
            this.textBox7.Size = new System.Drawing.Size(102, 27);
            this.textBox7.TabIndex = 32;
            this.textBox7.Text = "VENCIMIENTO";
            this.textBox7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(307, 452);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(15, 14);
            this.checkBox1.TabIndex = 11;
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.Visible = false;
            this.checkBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.CB_CargasPeligrosas_MouseClick);
            // 
            // CB_CargasPeligrosas
            // 
            this.CB_CargasPeligrosas.AutoSize = true;
            this.CB_CargasPeligrosas.Location = new System.Drawing.Point(307, 417);
            this.CB_CargasPeligrosas.Name = "CB_CargasPeligrosas";
            this.CB_CargasPeligrosas.Size = new System.Drawing.Size(15, 14);
            this.CB_CargasPeligrosas.TabIndex = 11;
            this.CB_CargasPeligrosas.UseVisualStyleBackColor = true;
            this.CB_CargasPeligrosas.MouseClick += new System.Windows.Forms.MouseEventHandler(this.CB_CargasPeligrosas_MouseClick);
            // 
            // textBox6
            // 
            this.textBox6.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox6.Location = new System.Drawing.Point(284, 246);
            this.textBox6.Name = "textBox6";
            this.textBox6.ReadOnly = true;
            this.textBox6.Size = new System.Drawing.Size(60, 27);
            this.textBox6.TabIndex = 31;
            this.textBox6.Text = "APLICA";
            this.textBox6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 450);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(232, 18);
            this.label1.TabIndex = 9;
            this.label1.Text = "Habilitacion RENPRE (ex SEDRONAR)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(20, 416);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(258, 17);
            this.label7.TabIndex = 9;
            this.label7.Text = "Cert. Habilit. P/Transp de Cargas Peligrosas";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(21, 321);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(154, 18);
            this.label6.TabIndex = 8;
            this.label6.Text = "Rev. Tecnica Obligatoria";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(22, 287);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 18);
            this.label5.TabIndex = 7;
            this.label5.Text = "Ruta";
            // 
            // textBox5
            // 
            this.textBox5.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox5.Location = new System.Drawing.Point(24, 246);
            this.textBox5.Name = "textBox5";
            this.textBox5.ReadOnly = true;
            this.textBox5.Size = new System.Drawing.Size(254, 27);
            this.textBox5.TabIndex = 30;
            this.textBox5.Text = "                       CONCEPTO";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel5);
            this.groupBox1.Controls.Add(this.TB_CodProveedor);
            this.groupBox1.Controls.Add(this.panel4);
            this.groupBox1.Controls.Add(this.TB_NombProveedor);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(14, 95);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(583, 61);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "PROVEEDOR";
            // 
            // panel5
            // 
            this.panel5.Location = new System.Drawing.Point(246, 19);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(23, 32);
            this.panel5.TabIndex = 52;
            // 
            // TB_CodProveedor
            // 
            this.TB_CodProveedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.TB_CodProveedor.FormattingEnabled = true;
            this.TB_CodProveedor.Location = new System.Drawing.Point(147, 22);
            this.TB_CodProveedor.Name = "TB_CodProveedor";
            this.TB_CodProveedor.Size = new System.Drawing.Size(102, 26);
            this.TB_CodProveedor.TabIndex = 3;
            // 
            // panel4
            // 
            this.panel4.Location = new System.Drawing.Point(554, 19);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(23, 32);
            this.panel4.TabIndex = 51;
            // 
            // TB_NombProveedor
            // 
            this.TB_NombProveedor.FormattingEnabled = true;
            this.TB_NombProveedor.Location = new System.Drawing.Point(339, 22);
            this.TB_NombProveedor.Name = "TB_NombProveedor";
            this.TB_NombProveedor.Size = new System.Drawing.Size(233, 26);
            this.TB_NombProveedor.TabIndex = 4;
            this.TB_NombProveedor.SelectedIndexChanged += new System.EventHandler(this.TB_NombProveedor_SelectedIndexChanged);
            this.TB_NombProveedor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TB_NombProveedor_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(270, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 18);
            this.label4.TabIndex = 3;
            this.label4.Text = "Nombre:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(75, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "Codigo:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.BT_Salir);
            this.groupBox4.Controls.Add(this.BT_LimpiarPant);
            this.groupBox4.Controls.Add(this.BT_Guardar);
            this.groupBox4.Location = new System.Drawing.Point(620, 126);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(193, 83);
            this.groupBox4.TabIndex = 49;
            this.groupBox4.TabStop = false;
            // 
            // AgModCamiones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(846, 542);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Name = "AgModCamiones";
            this.Load += new System.EventHandler(this.AgModCamiones_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private Label LBCamion;
        private Panel panel2;
        private Panel panel3;
        private Button BT_Salir;
        private Button BT_LimpiarPant;
        private Button BT_Guardar;
        private TextBox TB_ObservCargasPelig;
        private TextBox TB_ObservSeguro;
        private TextBox TB_ObservHabDominio;
        private TextBox textBox9;
        private MaskedTextBox TB_EntCargasPelig;
        private MaskedTextBox TB_EntSeguro;
        private MaskedTextBox TB_EntHabDominio;
        private TextBox textBox8;
        private MaskedTextBox TB_VencCargasPelig;
        private MaskedTextBox TB_VencSeguro;
        private MaskedTextBox TB_VencHabDominio;
        private TextBox textBox7;
        private CheckBox CB_CargasPeligrosas;
        private TextBox textBox6;
        private Label label7;
        private Label label6;
        private Label label5;
        private TextBox textBox5;
        private GroupBox groupBox1;
        private Label label4;
        private Label label3;
        private TextBox TB_Descripcion;
        private TextBox TB_CodCamion;
        private Label label2;
        private Label LFechaAviso;
        private GroupBox groupBox2;
        private TextBox TB_CodChofer;
        private Label label9;
        private Label label10;
        private Label label8;
        private MaskedTextBox TB_EntRuta;
        private MaskedTextBox TB_VencRuta;
        private MaskedTextBox TB_EntRTO;
        private MaskedTextBox TB_VencRTO;
        private Label label15;
        private Label label14;
        private GroupBox groupBox3;
        private TextBox TB_Patente;
        private Label label13;
        private ComboBox CB_Estado;
        private TextBox TB_ObservacRuta;
        private TextBox TB_ObservRTO;
        private ToolTip toolTip1;
        private Panel panel4;
        private ComboBox TB_NombProveedor;
        private Panel panel5;
        private ComboBox TB_CodProveedor;
        private ComboBox TB_NombChofer;
        private TextBox txtObsRENPRE;
        private MaskedTextBox txtFechaEntregaRENPRE;
        private MaskedTextBox txtVencimientoRENPRE;
        private CheckBox checkBox1;
        private Label label1;
        private GroupBox groupBox4;
    }
}