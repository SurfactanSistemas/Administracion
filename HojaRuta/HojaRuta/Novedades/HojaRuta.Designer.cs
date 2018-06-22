namespace HojaRuta.Novedades
{
    partial class HojaRuta
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.LBChofer = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.LFechaAviso = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNroHoja = new System.Windows.Forms.TextBox();
            this.txtDesChofer = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFecha = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbTipoPedido = new System.Windows.Forms.ComboBox();
            this.cmbEstado = new System.Windows.Forms.ComboBox();
            this.txtKilos = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtChofer = new System.Windows.Forms.TextBox();
            this.txtDesCamion = new System.Windows.Forms.TextBox();
            this.txtCamion = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtNroViaje = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtRetiraProv = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtHoraViaje = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnCot = new System.Windows.Forms.Button();
            this.dgvPedidos = new System.Windows.Forms.DataGridView();
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
            this.btnConsulta = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedidos)).BeginInit();
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
            this.panel3.Controls.Add(this.btnLimpiar);
            this.panel3.Controls.Add(this.btnConsulta);
            this.panel3.Controls.Add(this.btnGuardar);
            this.panel3.Controls.Add(this.groupBox2);
            this.panel3.Location = new System.Drawing.Point(10, 9);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(886, 412);
            this.panel3.TabIndex = 0;
            // 
            // btnCerrar
            // 
            this.btnCerrar.BackgroundImage = global::HojaRuta.Properties.Resources.Fin21;
            this.btnCerrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.ForeColor = System.Drawing.SystemColors.Control;
            this.btnCerrar.Location = new System.Drawing.Point(521, 364);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(40, 40);
            this.btnCerrar.TabIndex = 40;
            this.toolTip1.SetToolTip(this.btnCerrar, "Cerrar");
            this.btnCerrar.UseVisualStyleBackColor = true;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackgroundImage = global::HojaRuta.Properties.Resources.LimpiarPant1;
            this.btnLimpiar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.ForeColor = System.Drawing.SystemColors.Control;
            this.btnLimpiar.Location = new System.Drawing.Point(456, 364);
            this.btnLimpiar.Margin = new System.Windows.Forms.Padding(0);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(40, 40);
            this.btnLimpiar.TabIndex = 39;
            this.toolTip1.SetToolTip(this.btnLimpiar, "Limpiar Formulario");
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackgroundImage = global::HojaRuta.Properties.Resources.Grabar;
            this.btnGuardar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.ForeColor = System.Drawing.SystemColors.Control;
            this.btnGuardar.Location = new System.Drawing.Point(326, 364);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(0);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(40, 40);
            this.btnGuardar.TabIndex = 38;
            this.toolTip1.SetToolTip(this.btnGuardar, "Grabar");
            this.btnGuardar.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
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
            // txtNroHoja
            // 
            this.txtNroHoja.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNroHoja.Location = new System.Drawing.Point(115, 18);
            this.txtNroHoja.MaxLength = 6;
            this.txtNroHoja.Name = "txtNroHoja";
            this.txtNroHoja.Size = new System.Drawing.Size(69, 20);
            this.txtNroHoja.TabIndex = 2;
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
            this.cmbTipoPedido.Click += new System.EventHandler(this.cmbTipoPedido_Click);
            this.cmbTipoPedido.Enter += new System.EventHandler(this.cmbTipoPedido_Enter);
            this.cmbTipoPedido.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbTipoPedido_KeyDown);
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
            this.cmbEstado.Click += new System.EventHandler(this.cmbEstado_Click);
            this.cmbEstado.Enter += new System.EventHandler(this.cmbEstado_Enter);
            this.cmbEstado.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbEstado_KeyDown);
            // 
            // txtKilos
            // 
            this.txtKilos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKilos.Location = new System.Drawing.Point(792, 18);
            this.txtKilos.MaxLength = 6;
            this.txtKilos.Name = "txtKilos";
            this.txtKilos.Size = new System.Drawing.Size(60, 20);
            this.txtKilos.TabIndex = 2;
            this.txtKilos.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtKilos_KeyDown);
            this.txtKilos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SoloNumerosDecimales);
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
            // txtChofer
            // 
            this.txtChofer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtChofer.Location = new System.Drawing.Point(115, 52);
            this.txtChofer.MaxLength = 6;
            this.txtChofer.Name = "txtChofer";
            this.txtChofer.Size = new System.Drawing.Size(40, 20);
            this.txtChofer.TabIndex = 2;
            this.txtChofer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtChofer_KeyDown);
            this.txtChofer.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SoloNumerosEnteros);
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
            // txtCamion
            // 
            this.txtCamion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCamion.Location = new System.Drawing.Point(527, 52);
            this.txtCamion.MaxLength = 6;
            this.txtCamion.Name = "txtCamion";
            this.txtCamion.Size = new System.Drawing.Size(40, 20);
            this.txtCamion.TabIndex = 2;
            this.txtCamion.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCamion_KeyDown);
            this.txtCamion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SoloNumerosEnteros);
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
            // txtNroViaje
            // 
            this.txtNroViaje.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNroViaje.Location = new System.Drawing.Point(115, 84);
            this.txtNroViaje.MaxLength = 6;
            this.txtNroViaje.Name = "txtNroViaje";
            this.txtNroViaje.Size = new System.Drawing.Size(40, 20);
            this.txtNroViaje.TabIndex = 2;
            this.txtNroViaje.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNroViaje_KeyDown);
            this.txtNroViaje.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SoloNumerosEnteros);
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
            // txtHoraViaje
            // 
            this.txtHoraViaje.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHoraViaje.Location = new System.Drawing.Point(115, 115);
            this.txtHoraViaje.MaxLength = 6;
            this.txtHoraViaje.Name = "txtHoraViaje";
            this.txtHoraViaje.Size = new System.Drawing.Size(40, 20);
            this.txtHoraViaje.TabIndex = 2;
            this.txtHoraViaje.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtHoraViaje_KeyDown);
            this.txtHoraViaje.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SoloNumerosDecimales);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(11, 117);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(99, 18);
            this.label9.TabIndex = 2;
            this.label9.Text = "Hora del Viaje:";
            // 
            // btnCot
            // 
            this.btnCot.Location = new System.Drawing.Point(719, 109);
            this.btnCot.Name = "btnCot";
            this.btnCot.Size = new System.Drawing.Size(105, 34);
            this.btnCot.TabIndex = 5;
            this.btnCot.Text = "C.O.T.";
            this.btnCot.UseVisualStyleBackColor = true;
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
            this.COT});
            this.dgvPedidos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvPedidos.Location = new System.Drawing.Point(7, 178);
            this.dgvPedidos.Name = "dgvPedidos";
            this.dgvPedidos.RowHeadersWidth = 15;
            this.dgvPedidos.Size = new System.Drawing.Size(872, 178);
            this.dgvPedidos.TabIndex = 41;
            // 
            // Pedido
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Pedido.DefaultCellStyle = dataGridViewCellStyle6;
            this.Pedido.HeaderText = "Pedido";
            this.Pedido.MaxInputLength = 6;
            this.Pedido.Name = "Pedido";
            this.Pedido.Width = 70;
            // 
            // Cliente
            // 
            this.Cliente.HeaderText = "Cliente";
            this.Cliente.MaxInputLength = 6;
            this.Cliente.Name = "Cliente";
            this.Cliente.ReadOnly = true;
            this.Cliente.Width = 70;
            // 
            // Razon
            // 
            this.Razon.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Razon.HeaderText = "Razon";
            this.Razon.Name = "Razon";
            this.Razon.ReadOnly = true;
            // 
            // Remito
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Remito.DefaultCellStyle = dataGridViewCellStyle7;
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
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Kilos.DefaultCellStyle = dataGridViewCellStyle8;
            this.Kilos.HeaderText = "Kilos";
            this.Kilos.Name = "Kilos";
            this.Kilos.ReadOnly = true;
            this.Kilos.Width = 70;
            // 
            // Bultos
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Bultos.DefaultCellStyle = dataGridViewCellStyle9;
            this.Bultos.HeaderText = "Bultos";
            this.Bultos.Name = "Bultos";
            this.Bultos.Width = 50;
            // 
            // Envases
            // 
            this.Envases.HeaderText = "Envases a";
            this.Envases.MaxInputLength = 30;
            this.Envases.Name = "Envases";
            // 
            // Observacion
            // 
            this.Observacion.HeaderText = "Observacion";
            this.Observacion.MaxInputLength = 30;
            this.Observacion.Name = "Observacion";
            // 
            // COT
            // 
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.COT.DefaultCellStyle = dataGridViewCellStyle10;
            this.COT.HeaderText = "COT";
            this.COT.MaxInputLength = 10;
            this.COT.Name = "COT";
            this.COT.Width = 80;
            // 
            // btnConsulta
            // 
            this.btnConsulta.BackgroundImage = global::HojaRuta.Properties.Resources.buscar;
            this.btnConsulta.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnConsulta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConsulta.ForeColor = System.Drawing.SystemColors.Control;
            this.btnConsulta.Location = new System.Drawing.Point(391, 364);
            this.btnConsulta.Margin = new System.Windows.Forms.Padding(0);
            this.btnConsulta.Name = "btnConsulta";
            this.btnConsulta.Size = new System.Drawing.Size(40, 40);
            this.btnConsulta.TabIndex = 38;
            this.toolTip1.SetToolTip(this.btnConsulta, "Abrir Consulta");
            this.btnConsulta.UseVisualStyleBackColor = true;
            // 
            // HojaRuta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(906, 472);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "HojaRuta";
            this.Load += new System.EventHandler(this.HojaRuta_Load);
            this.Shown += new System.EventHandler(this.HojaRuta_Shown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedidos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label LBChofer;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label LFechaAviso;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDesChofer;
        private System.Windows.Forms.TextBox txtNroHoja;
        private System.Windows.Forms.MaskedTextBox txtFecha;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbTipoPedido;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbEstado;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtKilos;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCamion;
        private System.Windows.Forms.TextBox txtChofer;
        private System.Windows.Forms.TextBox txtDesCamion;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtRetiraProv;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtHoraViaje;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtNroViaje;
        private System.Windows.Forms.Button btnCot;
        private System.Windows.Forms.DataGridView dgvPedidos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pedido;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn Razon;
        private System.Windows.Forms.DataGridViewTextBoxColumn Remito;
        private System.Windows.Forms.DataGridViewTextBoxColumn Segur;
        private System.Windows.Forms.DataGridViewTextBoxColumn Kilos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Bultos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Envases;
        private System.Windows.Forms.DataGridViewTextBoxColumn Observacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn COT;
        private System.Windows.Forms.Button btnConsulta;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}