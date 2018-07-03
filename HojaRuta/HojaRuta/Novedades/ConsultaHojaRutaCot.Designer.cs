using System.ComponentModel;
using System.Windows.Forms;

namespace HojaRuta.Novedades
{
    partial class ConsultaHojaRutaCot
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
            this.LBChofer = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgvPedidos = new System.Windows.Forms.DataGridView();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnPedidos = new System.Windows.Forms.Button();
            this.btnConsulta = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnCheckList = new System.Windows.Forms.Button();
            this.btnCot = new System.Windows.Forms.Button();
            this.cmbEstado = new System.Windows.Forms.ComboBox();
            this.cmbTipoPedido = new System.Windows.Forms.ComboBox();
            this.txtFecha = new System.Windows.Forms.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.LFechaAviso = new System.Windows.Forms.Label();
            this.txtKilos = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCamion = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtRetiraProv = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtHoraViaje = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtNroViaje = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtChofer = new System.Windows.Forms.TextBox();
            this.txtDesCamion = new System.Windows.Forms.TextBox();
            this.txtNroHoja = new System.Windows.Forms.TextBox();
            this.txtDesChofer = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.Pedido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Razon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remito = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Segur = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Kilos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Bultos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Envases = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Observacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Integridad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Archivo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedidos)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(139)))), ((int)(((byte)(82)))));
            this.panel1.Controls.Add(this.LBChofer);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(906, 39);
            this.panel1.TabIndex = 2;
            // 
            // LBChofer
            // 
            this.LBChofer.AutoSize = true;
            this.LBChofer.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBChofer.ForeColor = System.Drawing.Color.White;
            this.LBChofer.Location = new System.Drawing.Point(22, 11);
            this.LBChofer.Name = "LBChofer";
            this.LBChofer.Size = new System.Drawing.Size(107, 19);
            this.LBChofer.TabIndex = 0;
            this.LBChofer.Text = "HOJA DE RUTA";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(74)))), ((int)(((byte)(95)))));
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 39);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(906, 433);
            this.panel2.TabIndex = 3;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.Control;
            this.panel3.Controls.Add(this.dgvPedidos);
            this.panel3.Controls.Add(this.btnCerrar);
            this.panel3.Controls.Add(this.button1);
            this.panel3.Controls.Add(this.btnLimpiar);
            this.panel3.Controls.Add(this.btnPedidos);
            this.panel3.Controls.Add(this.btnConsulta);
            this.panel3.Controls.Add(this.btnGuardar);
            this.panel3.Controls.Add(this.groupBox2);
            this.panel3.Location = new System.Drawing.Point(10, 9);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(886, 412);
            this.panel3.TabIndex = 0;
            // 
            // dgvPedidos
            // 
            this.dgvPedidos.AllowUserToAddRows = false;
            this.dgvPedidos.AllowUserToDeleteRows = false;
            this.dgvPedidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPedidos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Pedido,
            this.Cliente,
            this.Razon,
            this.Remito,
            this.Segur,
            this.Kilos,
            this.Bultos,
            this.Envases,
            this.Observacion,
            this.COT,
            this.Integridad,
            this.Archivo});
            this.dgvPedidos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvPedidos.Location = new System.Drawing.Point(7, 178);
            this.dgvPedidos.Name = "dgvPedidos";
            this.dgvPedidos.ReadOnly = true;
            this.dgvPedidos.RowHeadersWidth = 15;
            this.dgvPedidos.RowTemplate.Height = 18;
            this.dgvPedidos.Size = new System.Drawing.Size(872, 178);
            this.dgvPedidos.TabIndex = 41;
            // 
            // btnCerrar
            // 
            this.btnCerrar.BackgroundImage = global::HojaRuta.Properties.Resources.Fin21;
            this.btnCerrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.ForeColor = System.Drawing.SystemColors.Control;
            this.btnCerrar.Location = new System.Drawing.Point(483, 365);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(40, 40);
            this.btnCerrar.TabIndex = 40;
            this.toolTip1.SetToolTip(this.btnCerrar, "Cerrar");
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::HojaRuta.Properties.Resources.Imprimir;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.SystemColors.Control;
            this.button1.Location = new System.Drawing.Point(364, 365);
            this.button1.Margin = new System.Windows.Forms.Padding(0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(40, 40);
            this.button1.TabIndex = 39;
            this.toolTip1.SetToolTip(this.button1, "Imprimir Hoja de Ruta");
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackgroundImage = global::HojaRuta.Properties.Resources.LimpiarPant1;
            this.btnLimpiar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.ForeColor = System.Drawing.SystemColors.Control;
            this.btnLimpiar.Location = new System.Drawing.Point(423, 365);
            this.btnLimpiar.Margin = new System.Windows.Forms.Padding(0);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(40, 40);
            this.btnLimpiar.TabIndex = 39;
            this.toolTip1.SetToolTip(this.btnLimpiar, "Limpiar Formulario");
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnPedidos
            // 
            this.btnPedidos.BackgroundImage = global::HojaRuta.Properties.Resources.Modificar1;
            this.btnPedidos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnPedidos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPedidos.ForeColor = System.Drawing.SystemColors.Control;
            this.btnPedidos.Location = new System.Drawing.Point(743, 365);
            this.btnPedidos.Margin = new System.Windows.Forms.Padding(0);
            this.btnPedidos.Name = "btnPedidos";
            this.btnPedidos.Size = new System.Drawing.Size(40, 40);
            this.btnPedidos.TabIndex = 38;
            this.toolTip1.SetToolTip(this.btnPedidos, "Pedidos");
            this.btnPedidos.UseVisualStyleBackColor = true;
            this.btnPedidos.Visible = false;
            this.btnPedidos.Click += new System.EventHandler(this.btnPedidos_Click);
            // 
            // btnConsulta
            // 
            this.btnConsulta.BackgroundImage = global::HojaRuta.Properties.Resources.buscar;
            this.btnConsulta.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnConsulta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConsulta.ForeColor = System.Drawing.SystemColors.Control;
            this.btnConsulta.Location = new System.Drawing.Point(836, 365);
            this.btnConsulta.Margin = new System.Windows.Forms.Padding(0);
            this.btnConsulta.Name = "btnConsulta";
            this.btnConsulta.Size = new System.Drawing.Size(40, 40);
            this.btnConsulta.TabIndex = 38;
            this.toolTip1.SetToolTip(this.btnConsulta, "Abrir Consulta");
            this.btnConsulta.UseVisualStyleBackColor = true;
            this.btnConsulta.Visible = false;
            this.btnConsulta.Click += new System.EventHandler(this.btnConsulta_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackgroundImage = global::HojaRuta.Properties.Resources.Grabar;
            this.btnGuardar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.ForeColor = System.Drawing.SystemColors.Control;
            this.btnGuardar.Location = new System.Drawing.Point(783, 365);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(0);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(40, 40);
            this.btnGuardar.TabIndex = 38;
            this.toolTip1.SetToolTip(this.btnGuardar, "Grabar");
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Visible = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnCheckList);
            this.groupBox2.Controls.Add(this.btnCot);
            this.groupBox2.Controls.Add(this.cmbEstado);
            this.groupBox2.Controls.Add(this.cmbTipoPedido);
            this.groupBox2.Controls.Add(this.txtFecha);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.LFechaAviso);
            this.groupBox2.Controls.Add(this.txtKilos);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtCamion);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.txtRetiraProv);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.txtHoraViaje);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtNroViaje);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtChofer);
            this.groupBox2.Controls.Add(this.txtDesCamion);
            this.groupBox2.Controls.Add(this.txtNroHoja);
            this.groupBox2.Controls.Add(this.txtDesChofer);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(9, 18);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(867, 149);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // btnCheckList
            // 
            this.btnCheckList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheckList.Location = new System.Drawing.Point(757, 114);
            this.btnCheckList.Name = "btnCheckList";
            this.btnCheckList.Size = new System.Drawing.Size(26, 20);
            this.btnCheckList.TabIndex = 5;
            this.btnCheckList.Text = "Check List Exportación";
            this.btnCheckList.UseVisualStyleBackColor = true;
            this.btnCheckList.Visible = false;
            this.btnCheckList.Click += new System.EventHandler(this.btnCheckList_Click);
            // 
            // btnCot
            // 
            this.btnCot.Location = new System.Drawing.Point(719, 114);
            this.btnCot.Name = "btnCot";
            this.btnCot.Size = new System.Drawing.Size(32, 19);
            this.btnCot.TabIndex = 5;
            this.btnCot.Text = "C.O.T.";
            this.btnCot.UseVisualStyleBackColor = true;
            this.btnCot.Visible = false;
            this.btnCot.Click += new System.EventHandler(this.btnCot_Click);
            // 
            // cmbEstado
            // 
            this.cmbEstado.FormattingEnabled = true;
            this.cmbEstado.Items.AddRange(new object[] {
            "Pendiente",
            "Confirmada"});
            this.cmbEstado.Location = new System.Drawing.Point(614, 18);
            this.cmbEstado.Name = "cmbEstado";
            this.cmbEstado.Size = new System.Drawing.Size(91, 21);
            this.cmbEstado.TabIndex = 4;
            this.cmbEstado.DropDownClosed += new System.EventHandler(this.cmbEstado_DropDownClosed);
            this.cmbEstado.Enter += new System.EventHandler(this.cmbEstado_Enter);
            this.cmbEstado.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbEstado_KeyDown);
            // 
            // cmbTipoPedido
            // 
            this.cmbTipoPedido.FormattingEnabled = true;
            this.cmbTipoPedido.Items.AddRange(new object[] {
            "Total",
            "Químicos",
            "Colorantes",
            "Farma",
            "Pigmentos"});
            this.cmbTipoPedido.Location = new System.Drawing.Point(447, 18);
            this.cmbTipoPedido.Name = "cmbTipoPedido";
            this.cmbTipoPedido.Size = new System.Drawing.Size(94, 21);
            this.cmbTipoPedido.TabIndex = 4;
            this.cmbTipoPedido.DropDownClosed += new System.EventHandler(this.cmbTipoPedido_DropDownClosed);
            this.cmbTipoPedido.Enter += new System.EventHandler(this.cmbTipoPedido_Enter);
            this.cmbTipoPedido.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbTipoPedido_KeyDown);
            // 
            // txtFecha
            // 
            this.txtFecha.Location = new System.Drawing.Point(254, 18);
            this.txtFecha.Mask = "00/00/0000";
            this.txtFecha.Name = "txtFecha";
            this.txtFecha.PromptChar = ' ';
            this.txtFecha.Size = new System.Drawing.Size(83, 20);
            this.txtFecha.TabIndex = 3;
            this.txtFecha.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtFecha.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFecha_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(555, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 18);
            this.label4.TabIndex = 1;
            this.label4.Text = "Estado:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(355, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 18);
            this.label3.TabIndex = 1;
            this.label3.Text = "Tipo Pedido:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(198, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Fecha:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(716, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 18);
            this.label5.TabIndex = 1;
            this.label5.Text = "Total Kilos:";
            // 
            // LFechaAviso
            // 
            this.LFechaAviso.AutoSize = true;
            this.LFechaAviso.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LFechaAviso.Location = new System.Drawing.Point(40, 19);
            this.LFechaAviso.Name = "LFechaAviso";
            this.LFechaAviso.Size = new System.Drawing.Size(70, 18);
            this.LFechaAviso.TabIndex = 1;
            this.LFechaAviso.Text = "Nro. Hoja:";
            // 
            // txtKilos
            // 
            this.txtKilos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKilos.Location = new System.Drawing.Point(792, 18);
            this.txtKilos.MaxLength = 6;
            this.txtKilos.Name = "txtKilos";
            this.txtKilos.Size = new System.Drawing.Size(60, 20);
            this.txtKilos.TabIndex = 2;
            this.txtKilos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtKilos.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtKilos_KeyDown);
            this.txtKilos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SoloNumerosDecimales);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(467, 53);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 18);
            this.label6.TabIndex = 2;
            this.label6.Text = "Camión:";
            // 
            // txtCamion
            // 
            this.txtCamion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCamion.Location = new System.Drawing.Point(527, 52);
            this.txtCamion.MaxLength = 6;
            this.txtCamion.Name = "txtCamion";
            this.txtCamion.Size = new System.Drawing.Size(40, 20);
            this.txtCamion.TabIndex = 2;
            this.txtCamion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCamion.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCamion_KeyDown);
            this.txtCamion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SoloNumerosEnteros);
            this.txtCamion.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtCamion_MouseDoubleClick);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(166, 85);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 18);
            this.label8.TabIndex = 2;
            this.label8.Text = "Retira Prov:";
            // 
            // txtRetiraProv
            // 
            this.txtRetiraProv.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRetiraProv.Location = new System.Drawing.Point(246, 84);
            this.txtRetiraProv.MaxLength = 6;
            this.txtRetiraProv.Name = "txtRetiraProv";
            this.txtRetiraProv.Size = new System.Drawing.Size(609, 20);
            this.txtRetiraProv.TabIndex = 2;
            this.txtRetiraProv.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtRetiraProv_KeyDown);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(11, 115);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(99, 18);
            this.label9.TabIndex = 2;
            this.label9.Text = "Hora del Viaje:";
            // 
            // txtHoraViaje
            // 
            this.txtHoraViaje.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHoraViaje.Location = new System.Drawing.Point(115, 114);
            this.txtHoraViaje.MaxLength = 6;
            this.txtHoraViaje.Name = "txtHoraViaje";
            this.txtHoraViaje.Size = new System.Drawing.Size(40, 20);
            this.txtHoraViaje.TabIndex = 2;
            this.txtHoraViaje.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtHoraViaje.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtHoraViaje_KeyDown);
            this.txtHoraViaje.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SoloNumerosDecimales);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(17, 85);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(93, 18);
            this.label7.TabIndex = 2;
            this.label7.Text = "Nro. de Viaje:";
            // 
            // txtNroViaje
            // 
            this.txtNroViaje.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNroViaje.Location = new System.Drawing.Point(115, 84);
            this.txtNroViaje.MaxLength = 6;
            this.txtNroViaje.Name = "txtNroViaje";
            this.txtNroViaje.Size = new System.Drawing.Size(40, 20);
            this.txtNroViaje.TabIndex = 2;
            this.txtNroViaje.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtNroViaje.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNroViaje_KeyDown);
            this.txtNroViaje.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SoloNumerosEnteros);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(56, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Chofer:";
            // 
            // txtChofer
            // 
            this.txtChofer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtChofer.Location = new System.Drawing.Point(115, 52);
            this.txtChofer.MaxLength = 6;
            this.txtChofer.Name = "txtChofer";
            this.txtChofer.Size = new System.Drawing.Size(40, 20);
            this.txtChofer.TabIndex = 2;
            this.txtChofer.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtChofer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtChofer_KeyDown);
            this.txtChofer.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SoloNumerosEnteros);
            this.txtChofer.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtChofer_MouseDoubleClick);
            // 
            // txtDesCamion
            // 
            this.txtDesCamion.BackColor = System.Drawing.Color.LightCyan;
            this.txtDesCamion.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDesCamion.Location = new System.Drawing.Point(573, 52);
            this.txtDesCamion.Name = "txtDesCamion";
            this.txtDesCamion.Size = new System.Drawing.Size(282, 20);
            this.txtDesCamion.TabIndex = 2;
            // 
            // txtNroHoja
            // 
            this.txtNroHoja.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNroHoja.Location = new System.Drawing.Point(115, 18);
            this.txtNroHoja.MaxLength = 6;
            this.txtNroHoja.Name = "txtNroHoja";
            this.txtNroHoja.Size = new System.Drawing.Size(69, 20);
            this.txtNroHoja.TabIndex = 2;
            this.txtNroHoja.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtNroHoja.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNroHoja_KeyDown);
            this.txtNroHoja.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SoloNumerosEnteros);
            // 
            // txtDesChofer
            // 
            this.txtDesChofer.BackColor = System.Drawing.Color.LightCyan;
            this.txtDesChofer.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDesChofer.Location = new System.Drawing.Point(161, 52);
            this.txtDesChofer.Name = "txtDesChofer";
            this.txtDesChofer.Size = new System.Drawing.Size(282, 20);
            this.txtDesChofer.TabIndex = 2;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Pedido
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Pedido.DefaultCellStyle = dataGridViewCellStyle1;
            this.Pedido.HeaderText = "Pedido";
            this.Pedido.MaxInputLength = 6;
            this.Pedido.Name = "Pedido";
            this.Pedido.ReadOnly = true;
            this.Pedido.Width = 50;
            // 
            // Cliente
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Cliente.DefaultCellStyle = dataGridViewCellStyle2;
            this.Cliente.HeaderText = "Cliente";
            this.Cliente.MaxInputLength = 6;
            this.Cliente.Name = "Cliente";
            this.Cliente.ReadOnly = true;
            this.Cliente.Width = 60;
            // 
            // Razon
            // 
            this.Razon.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Razon.HeaderText = "Razon";
            this.Razon.MinimumWidth = 100;
            this.Razon.Name = "Razon";
            this.Razon.ReadOnly = true;
            // 
            // Remito
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Remito.DefaultCellStyle = dataGridViewCellStyle3;
            this.Remito.HeaderText = "Remito";
            this.Remito.Name = "Remito";
            this.Remito.ReadOnly = true;
            this.Remito.Width = 70;
            // 
            // Segur
            // 
            this.Segur.HeaderText = "Segur";
            this.Segur.Name = "Segur";
            this.Segur.ReadOnly = true;
            // 
            // Kilos
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Kilos.DefaultCellStyle = dataGridViewCellStyle4;
            this.Kilos.HeaderText = "Kilos";
            this.Kilos.Name = "Kilos";
            this.Kilos.ReadOnly = true;
            this.Kilos.Width = 70;
            // 
            // Bultos
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Bultos.DefaultCellStyle = dataGridViewCellStyle5;
            this.Bultos.HeaderText = "Bultos";
            this.Bultos.Name = "Bultos";
            this.Bultos.ReadOnly = true;
            this.Bultos.Width = 50;
            // 
            // Envases
            // 
            this.Envases.HeaderText = "Envases a";
            this.Envases.MaxInputLength = 30;
            this.Envases.Name = "Envases";
            this.Envases.ReadOnly = true;
            // 
            // Observacion
            // 
            this.Observacion.HeaderText = "Observacion";
            this.Observacion.MaxInputLength = 30;
            this.Observacion.Name = "Observacion";
            this.Observacion.ReadOnly = true;
            // 
            // COT
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.COT.DefaultCellStyle = dataGridViewCellStyle6;
            this.COT.HeaderText = "COT";
            this.COT.MaxInputLength = 10;
            this.COT.Name = "COT";
            this.COT.ReadOnly = true;
            this.COT.Width = 80;
            // 
            // Integridad
            // 
            this.Integridad.HeaderText = "Integridad";
            this.Integridad.Name = "Integridad";
            this.Integridad.ReadOnly = true;
            this.Integridad.Visible = false;
            // 
            // Archivo
            // 
            this.Archivo.HeaderText = "Archivo";
            this.Archivo.Name = "Archivo";
            this.Archivo.ReadOnly = true;
            this.Archivo.Visible = false;
            // 
            // ConsultaHojaRutaCot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(906, 472);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Location = new System.Drawing.Point(5, 5);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(922, 511);
            this.MinimumSize = new System.Drawing.Size(922, 511);
            this.Name = "ConsultaHojaRutaCot";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Load += new System.EventHandler(this.ConsultaHojaRutaCot_Load);
            this.Shown += new System.EventHandler(this.ConsultaHojaRutaCot_Shown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedidos)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private Label LBChofer;
        private Panel panel2;
        private Panel panel3;
        private Button btnCerrar;
        private Button btnLimpiar;
        private Button btnGuardar;
        private GroupBox groupBox2;
        private Label LFechaAviso;
        private Label label2;
        private TextBox txtDesChofer;
        private TextBox txtNroHoja;
        private MaskedTextBox txtFecha;
        private Label label1;
        private ComboBox cmbTipoPedido;
        private Label label4;
        private Label label3;
        private ComboBox cmbEstado;
        private Label label5;
        private TextBox txtKilos;
        private Label label6;
        private TextBox txtCamion;
        private TextBox txtChofer;
        private TextBox txtDesCamion;
        private Label label8;
        private TextBox txtRetiraProv;
        private Label label9;
        private TextBox txtHoraViaje;
        private Label label7;
        private TextBox txtNroViaje;
        private Button btnCot;
        private DataGridView dgvPedidos;
        private Button btnConsulta;
        private ToolTip toolTip1;
        private Button btnPedidos;
        private Button btnCheckList;
        private Timer timer1;
        private Button button1;
        private DataGridViewTextBoxColumn Pedido;
        private DataGridViewTextBoxColumn Cliente;
        private DataGridViewTextBoxColumn Razon;
        private DataGridViewTextBoxColumn Remito;
        private DataGridViewTextBoxColumn Segur;
        private DataGridViewTextBoxColumn Kilos;
        private DataGridViewTextBoxColumn Bultos;
        private DataGridViewTextBoxColumn Envases;
        private DataGridViewTextBoxColumn Observacion;
        private DataGridViewTextBoxColumn COT;
        private DataGridViewTextBoxColumn Integridad;
        private DataGridViewTextBoxColumn Archivo;
    }
}