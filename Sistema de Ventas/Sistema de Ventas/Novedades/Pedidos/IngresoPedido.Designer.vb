<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class IngresoPedido
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmbVia = New System.Windows.Forms.ComboBox()
        Me.btnBloquearPedido = New System.Windows.Forms.Button()
        Me.btnPedidoPellital = New System.Windows.Forms.Button()
        Me.cmbTipoPedido = New System.Windows.Forms.ComboBox()
        Me.txtCliente = New System.Windows.Forms.MaskedTextBox()
        Me.txtFechaEntrega = New System.Windows.Forms.MaskedTextBox()
        Me.txtFecha = New System.Windows.Forms.MaskedTextBox()
        Me.txtVersion = New System.Windows.Forms.TextBox()
        Me.txtHora = New System.Windows.Forms.TextBox()
        Me.txtOrdenCpa = New System.Windows.Forms.TextBox()
        Me.txtObservaciones = New System.Windows.Forms.TextBox()
        Me.txtModPrecio = New System.Windows.Forms.TextBox()
        Me.txtPedido = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtCondPago = New System.Windows.Forms.Label()
        Me.lblDescCondPago = New System.Windows.Forms.Label()
        Me.lblDescCliente = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.lblSVII = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.lblSIV = New System.Windows.Forms.Label()
        Me.lblSVI = New System.Windows.Forms.Label()
        Me.lblDisponible = New System.Windows.Forms.Label()
        Me.lblSIII = New System.Windows.Forms.Label()
        Me.lblSV = New System.Windows.Forms.Label()
        Me.lblProduccion = New System.Windows.Forms.Label()
        Me.lblSII = New System.Windows.Forms.Label()
        Me.lblPedido = New System.Windows.Forms.Label()
        Me.lblSI = New System.Windows.Forms.Label()
        Me.lblStock = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.btnGrabar = New System.Windows.Forms.Button()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.btnConsultas = New System.Windows.Forms.Button()
        Me.btnEspecificacionesEntrega = New System.Windows.Forms.Button()
        Me.btnImpresion = New System.Windows.Forms.Button()
        Me.btnDatosAdicionales = New System.Windows.Forms.Button()
        Me.btnBajaPedido = New System.Windows.Forms.Button()
        Me.dgvItems = New Util.DBDataGridView()
        Me.Terminado = New Util.MyMaskedTextBoxColumn()
        Me.Descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cantidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Precio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Envase1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Canti1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Envase2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Canti2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Envase3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Canti3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Especificaciones = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NombreComercial = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OrdenTrabajo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Referencia = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvEnvasesII = New Util.DBDataGridView()
        Me.CodigoEnvase = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CantidadEnvase = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvEnvases = New Util.DBDataGridView()
        Me.Cod = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Desc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Kg = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.dgvItems, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvEnvasesII, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvEnvases, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'panel1
        '
        Me.panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(34, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.panel1.Controls.Add(Me.Label2)
        Me.panel1.Controls.Add(Me.label1)
        Me.panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.panel1.Location = New System.Drawing.Point(0, 0)
        Me.panel1.Name = "panel1"
        Me.panel1.Size = New System.Drawing.Size(745, 40)
        Me.panel1.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(569, 10)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(155, 20)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "SURFACTAN S.A."
        '
        'label1
        '
        Me.label1.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.label1.AutoSize = True
        Me.label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.label1.ForeColor = System.Drawing.Color.White
        Me.label1.Location = New System.Drawing.Point(21, 12)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(150, 17)
        Me.label1.TabIndex = 0
        Me.label1.Text = "INGRESO DE PEDIDO"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.cmbVia)
        Me.GroupBox1.Controls.Add(Me.btnBloquearPedido)
        Me.GroupBox1.Controls.Add(Me.btnPedidoPellital)
        Me.GroupBox1.Controls.Add(Me.cmbTipoPedido)
        Me.GroupBox1.Controls.Add(Me.txtCliente)
        Me.GroupBox1.Controls.Add(Me.txtFechaEntrega)
        Me.GroupBox1.Controls.Add(Me.txtFecha)
        Me.GroupBox1.Controls.Add(Me.txtVersion)
        Me.GroupBox1.Controls.Add(Me.txtHora)
        Me.GroupBox1.Controls.Add(Me.txtOrdenCpa)
        Me.GroupBox1.Controls.Add(Me.txtObservaciones)
        Me.GroupBox1.Controls.Add(Me.txtModPrecio)
        Me.GroupBox1.Controls.Add(Me.txtPedido)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtCondPago)
        Me.GroupBox1.Controls.Add(Me.lblDescCondPago)
        Me.GroupBox1.Controls.Add(Me.lblDescCliente)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 42)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(733, 147)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        '
        'cmbVia
        '
        Me.cmbVia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbVia.FormattingEnabled = True
        Me.cmbVia.Items.AddRange(New Object() {"", "TERRESTRE", "MARÍTIMO", "AEREO"})
        Me.cmbVia.Location = New System.Drawing.Point(411, 114)
        Me.cmbVia.Name = "cmbVia"
        Me.cmbVia.Size = New System.Drawing.Size(130, 21)
        Me.cmbVia.TabIndex = 3
        '
        'btnBloquearPedido
        '
        Me.btnBloquearPedido.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBloquearPedido.Location = New System.Drawing.Point(491, 12)
        Me.btnBloquearPedido.Name = "btnBloquearPedido"
        Me.btnBloquearPedido.Size = New System.Drawing.Size(116, 23)
        Me.btnBloquearPedido.TabIndex = 9
        Me.btnBloquearPedido.Text = "BLOQUEAR PEDIDO"
        Me.btnBloquearPedido.UseVisualStyleBackColor = True
        '
        'btnPedidoPellital
        '
        Me.btnPedidoPellital.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPedidoPellital.Location = New System.Drawing.Point(612, 12)
        Me.btnPedidoPellital.Name = "btnPedidoPellital"
        Me.btnPedidoPellital.Size = New System.Drawing.Size(116, 23)
        Me.btnPedidoPellital.TabIndex = 9
        Me.btnPedidoPellital.Text = "PEDIDO PELLITAL"
        Me.btnPedidoPellital.UseVisualStyleBackColor = True
        '
        'cmbTipoPedido
        '
        Me.cmbTipoPedido.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoPedido.FormattingEnabled = True
        Me.cmbTipoPedido.Items.AddRange(New Object() {"NORMAL", "A FECHA", "FECHA LÍMITE", "URGENTE", "RETIRA CLIENTE", "MUESTRA", "MUESTRA RETIRA"})
        Me.cmbTipoPedido.Location = New System.Drawing.Point(597, 40)
        Me.cmbTipoPedido.Name = "cmbTipoPedido"
        Me.cmbTipoPedido.Size = New System.Drawing.Size(130, 21)
        Me.cmbTipoPedido.TabIndex = 3
        '
        'txtCliente
        '
        Me.txtCliente.Location = New System.Drawing.Point(69, 40)
        Me.txtCliente.Mask = ">L00000"
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtCliente.Size = New System.Drawing.Size(48, 20)
        Me.txtCliente.TabIndex = 2
        Me.txtCliente.Text = "A99999"
        Me.txtCliente.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtFechaEntrega
        '
        Me.txtFechaEntrega.Location = New System.Drawing.Point(118, 65)
        Me.txtFechaEntrega.Mask = "00/00/0000"
        Me.txtFechaEntrega.Name = "txtFechaEntrega"
        Me.txtFechaEntrega.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtFechaEntrega.Size = New System.Drawing.Size(67, 20)
        Me.txtFechaEntrega.TabIndex = 2
        Me.txtFechaEntrega.Text = "00000000"
        Me.txtFechaEntrega.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtFecha
        '
        Me.txtFecha.Location = New System.Drawing.Point(172, 16)
        Me.txtFecha.Mask = "00/00/0000"
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtFecha.Size = New System.Drawing.Size(67, 20)
        Me.txtFecha.TabIndex = 2
        Me.txtFecha.Text = "00000000"
        Me.txtFecha.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtVersion
        '
        Me.txtVersion.Location = New System.Drawing.Point(306, 16)
        Me.txtVersion.Name = "txtVersion"
        Me.txtVersion.Size = New System.Drawing.Size(23, 20)
        Me.txtVersion.TabIndex = 1
        Me.txtVersion.Text = "00"
        Me.txtVersion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtHora
        '
        Me.txtHora.Location = New System.Drawing.Point(235, 65)
        Me.txtHora.Name = "txtHora"
        Me.txtHora.Size = New System.Drawing.Size(48, 20)
        Me.txtHora.TabIndex = 1
        Me.txtHora.Text = "000000"
        Me.txtHora.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtOrdenCpa
        '
        Me.txtOrdenCpa.Location = New System.Drawing.Point(118, 114)
        Me.txtOrdenCpa.Name = "txtOrdenCpa"
        Me.txtOrdenCpa.Size = New System.Drawing.Size(111, 20)
        Me.txtOrdenCpa.TabIndex = 1
        Me.txtOrdenCpa.Text = "000000"
        '
        'txtObservaciones
        '
        Me.txtObservaciones.Location = New System.Drawing.Point(118, 89)
        Me.txtObservaciones.Name = "txtObservaciones"
        Me.txtObservaciones.Size = New System.Drawing.Size(609, 20)
        Me.txtObservaciones.TabIndex = 1
        Me.txtObservaciones.Text = "000000"
        '
        'txtModPrecio
        '
        Me.txtModPrecio.Location = New System.Drawing.Point(323, 114)
        Me.txtModPrecio.Name = "txtModPrecio"
        Me.txtModPrecio.Size = New System.Drawing.Size(48, 20)
        Me.txtModPrecio.TabIndex = 1
        Me.txtModPrecio.Text = "000000"
        Me.txtModPrecio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPedido
        '
        Me.txtPedido.Location = New System.Drawing.Point(69, 16)
        Me.txtPedido.Name = "txtPedido"
        Me.txtPedido.Size = New System.Drawing.Size(48, 20)
        Me.txtPedido.TabIndex = 1
        Me.txtPedido.Text = "000000"
        Me.txtPedido.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(245, 20)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(55, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "VERSIÓN"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(124, 20)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(42, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "FECHA"
        '
        'txtCondPago
        '
        Me.txtCondPago.BackColor = System.Drawing.Color.Cyan
        Me.txtCondPago.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.txtCondPago.Location = New System.Drawing.Point(369, 65)
        Me.txtCondPago.Name = "txtCondPago"
        Me.txtCondPago.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.txtCondPago.Size = New System.Drawing.Size(32, 21)
        Me.txtCondPago.TabIndex = 0
        Me.txtCondPago.Text = "CLIENTE"
        Me.txtCondPago.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblDescCondPago
        '
        Me.lblDescCondPago.BackColor = System.Drawing.Color.Cyan
        Me.lblDescCondPago.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDescCondPago.Location = New System.Drawing.Point(405, 65)
        Me.lblDescCondPago.Name = "lblDescCondPago"
        Me.lblDescCondPago.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.lblDescCondPago.Size = New System.Drawing.Size(322, 21)
        Me.lblDescCondPago.TabIndex = 0
        Me.lblDescCondPago.Text = "CLIENTE"
        Me.lblDescCondPago.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblDescCliente
        '
        Me.lblDescCliente.BackColor = System.Drawing.Color.Cyan
        Me.lblDescCliente.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDescCliente.Location = New System.Drawing.Point(124, 40)
        Me.lblDescCliente.Name = "lblDescCliente"
        Me.lblDescCliente.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.lblDescCliente.Size = New System.Drawing.Size(385, 21)
        Me.lblDescCliente.TabIndex = 0
        Me.lblDescCliente.Text = "CLIENTE"
        Me.lblDescCliente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(515, 44)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(76, 13)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "TIPO PEDIDO"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(191, 69)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(38, 13)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "HORA"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(14, 69)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(97, 13)
        Me.Label14.TabIndex = 0
        Me.Label14.Text = "FECHA ENTREGA"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(379, 118)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(24, 13)
        Me.Label17.TabIndex = 0
        Me.Label17.Text = "VÍA"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(237, 118)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(78, 13)
        Me.Label16.TabIndex = 0
        Me.Label16.Text = "MOD. PRECIO"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(14, 118)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(95, 13)
        Me.Label15.TabIndex = 0
        Me.Label15.Text = "ORDEN COMPRA"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(14, 92)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(98, 13)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "OBSERVACIONES"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(289, 69)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(74, 13)
        Me.Label11.TabIndex = 0
        Me.Label11.Text = "COND. PAGO"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(14, 44)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(52, 13)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "CLIENTE"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(14, 20)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "PEDIDO"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label39)
        Me.GroupBox2.Controls.Add(Me.Label33)
        Me.GroupBox2.Controls.Add(Me.Label21)
        Me.GroupBox2.Controls.Add(Me.Label38)
        Me.GroupBox2.Controls.Add(Me.Label32)
        Me.GroupBox2.Controls.Add(Me.Label20)
        Me.GroupBox2.Controls.Add(Me.Label37)
        Me.GroupBox2.Controls.Add(Me.Label31)
        Me.GroupBox2.Controls.Add(Me.Label19)
        Me.GroupBox2.Controls.Add(Me.Label30)
        Me.GroupBox2.Controls.Add(Me.lblSVII)
        Me.GroupBox2.Controls.Add(Me.Label18)
        Me.GroupBox2.Controls.Add(Me.lblSIV)
        Me.GroupBox2.Controls.Add(Me.lblSVI)
        Me.GroupBox2.Controls.Add(Me.lblDisponible)
        Me.GroupBox2.Controls.Add(Me.lblSIII)
        Me.GroupBox2.Controls.Add(Me.lblSV)
        Me.GroupBox2.Controls.Add(Me.lblProduccion)
        Me.GroupBox2.Controls.Add(Me.lblSII)
        Me.GroupBox2.Controls.Add(Me.lblPedido)
        Me.GroupBox2.Controls.Add(Me.lblSI)
        Me.GroupBox2.Controls.Add(Me.lblStock)
        Me.GroupBox2.Location = New System.Drawing.Point(6, 329)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(349, 92)
        Me.GroupBox2.TabIndex = 7
        Me.GroupBox2.TabStop = False
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Font = New System.Drawing.Font("Arial", 6.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label39.Location = New System.Drawing.Point(246, 53)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(23, 11)
        Me.Label39.TabIndex = 0
        Me.Label39.Text = "SVII"
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Font = New System.Drawing.Font("Arial", 6.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.Location = New System.Drawing.Point(150, 72)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(20, 11)
        Me.Label33.TabIndex = 0
        Me.Label33.Text = "SIV"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Arial", 6.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(15, 72)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(63, 11)
        Me.Label21.TabIndex = 0
        Me.Label21.Text = "DISPONIBLE"
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Font = New System.Drawing.Font("Arial", 6.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label38.Location = New System.Drawing.Point(249, 34)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(20, 11)
        Me.Label38.TabIndex = 0
        Me.Label38.Text = "SVI"
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Font = New System.Drawing.Font("Arial", 6.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.Location = New System.Drawing.Point(150, 53)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(20, 11)
        Me.Label32.TabIndex = 0
        Me.Label32.Text = "SIII"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Arial", 6.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(6, 53)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(70, 11)
        Me.Label20.TabIndex = 0
        Me.Label20.Text = "PRODUCCIÓN"
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Font = New System.Drawing.Font("Arial", 6.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label37.Location = New System.Drawing.Point(252, 15)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(17, 11)
        Me.Label37.TabIndex = 0
        Me.Label37.Text = "SV"
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("Arial", 6.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.Location = New System.Drawing.Point(153, 34)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(17, 11)
        Me.Label31.TabIndex = 0
        Me.Label31.Text = "SII"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Arial", 6.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(35, 34)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(41, 11)
        Me.Label19.TabIndex = 0
        Me.Label19.Text = "PEDIDO"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Arial", 6.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.Location = New System.Drawing.Point(156, 15)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(14, 11)
        Me.Label30.TabIndex = 0
        Me.Label30.Text = "SI"
        '
        'lblSVII
        '
        Me.lblSVII.BackColor = System.Drawing.Color.Cyan
        Me.lblSVII.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblSVII.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSVII.Location = New System.Drawing.Point(273, 51)
        Me.lblSVII.Name = "lblSVII"
        Me.lblSVII.Size = New System.Drawing.Size(66, 17)
        Me.lblSVII.TabIndex = 0
        Me.lblSVII.Text = "999.999,99"
        Me.lblSVII.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Arial", 6.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(40, 15)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(37, 11)
        Me.Label18.TabIndex = 0
        Me.Label18.Text = "STOCK"
        '
        'lblSIV
        '
        Me.lblSIV.BackColor = System.Drawing.Color.Cyan
        Me.lblSIV.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblSIV.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSIV.Location = New System.Drawing.Point(174, 70)
        Me.lblSIV.Name = "lblSIV"
        Me.lblSIV.Size = New System.Drawing.Size(66, 17)
        Me.lblSIV.TabIndex = 0
        Me.lblSIV.Text = "999.999,99"
        Me.lblSIV.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblSVI
        '
        Me.lblSVI.BackColor = System.Drawing.Color.Cyan
        Me.lblSVI.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblSVI.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSVI.Location = New System.Drawing.Point(273, 32)
        Me.lblSVI.Name = "lblSVI"
        Me.lblSVI.Size = New System.Drawing.Size(66, 17)
        Me.lblSVI.TabIndex = 0
        Me.lblSVI.Text = "999.999,99"
        Me.lblSVI.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblDisponible
        '
        Me.lblDisponible.BackColor = System.Drawing.Color.Cyan
        Me.lblDisponible.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDisponible.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDisponible.Location = New System.Drawing.Point(80, 70)
        Me.lblDisponible.Name = "lblDisponible"
        Me.lblDisponible.Size = New System.Drawing.Size(66, 17)
        Me.lblDisponible.TabIndex = 0
        Me.lblDisponible.Text = "999.999,99"
        Me.lblDisponible.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblSIII
        '
        Me.lblSIII.BackColor = System.Drawing.Color.Cyan
        Me.lblSIII.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblSIII.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSIII.Location = New System.Drawing.Point(174, 51)
        Me.lblSIII.Name = "lblSIII"
        Me.lblSIII.Size = New System.Drawing.Size(66, 17)
        Me.lblSIII.TabIndex = 0
        Me.lblSIII.Text = "999.999,99"
        Me.lblSIII.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblSV
        '
        Me.lblSV.BackColor = System.Drawing.Color.Cyan
        Me.lblSV.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblSV.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSV.Location = New System.Drawing.Point(273, 13)
        Me.lblSV.Name = "lblSV"
        Me.lblSV.Size = New System.Drawing.Size(66, 17)
        Me.lblSV.TabIndex = 0
        Me.lblSV.Text = "999.999,99"
        Me.lblSV.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblProduccion
        '
        Me.lblProduccion.BackColor = System.Drawing.Color.Cyan
        Me.lblProduccion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblProduccion.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProduccion.Location = New System.Drawing.Point(80, 51)
        Me.lblProduccion.Name = "lblProduccion"
        Me.lblProduccion.Size = New System.Drawing.Size(66, 17)
        Me.lblProduccion.TabIndex = 0
        Me.lblProduccion.Text = "999.999,99"
        Me.lblProduccion.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblSII
        '
        Me.lblSII.BackColor = System.Drawing.Color.Cyan
        Me.lblSII.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblSII.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSII.Location = New System.Drawing.Point(174, 32)
        Me.lblSII.Name = "lblSII"
        Me.lblSII.Size = New System.Drawing.Size(66, 17)
        Me.lblSII.TabIndex = 0
        Me.lblSII.Text = "999.999,99"
        Me.lblSII.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblPedido
        '
        Me.lblPedido.BackColor = System.Drawing.Color.Cyan
        Me.lblPedido.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblPedido.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPedido.Location = New System.Drawing.Point(80, 32)
        Me.lblPedido.Name = "lblPedido"
        Me.lblPedido.Size = New System.Drawing.Size(66, 17)
        Me.lblPedido.TabIndex = 0
        Me.lblPedido.Text = "999.999,99"
        Me.lblPedido.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblSI
        '
        Me.lblSI.BackColor = System.Drawing.Color.Cyan
        Me.lblSI.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblSI.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSI.Location = New System.Drawing.Point(174, 13)
        Me.lblSI.Name = "lblSI"
        Me.lblSI.Size = New System.Drawing.Size(66, 17)
        Me.lblSI.TabIndex = 0
        Me.lblSI.Text = "999.999,99"
        Me.lblSI.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblStock
        '
        Me.lblStock.BackColor = System.Drawing.Color.Cyan
        Me.lblStock.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblStock.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStock.Location = New System.Drawing.Point(80, 13)
        Me.lblStock.Name = "lblStock"
        Me.lblStock.Size = New System.Drawing.Size(66, 17)
        Me.lblStock.TabIndex = 0
        Me.lblStock.Text = "999.999,99"
        Me.lblStock.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.dgvEnvasesII)
        Me.GroupBox3.Controls.Add(Me.dgvEnvases)
        Me.GroupBox3.Controls.Add(Me.Label40)
        Me.GroupBox3.Location = New System.Drawing.Point(590, 184)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(149, 235)
        Me.GroupBox3.TabIndex = 8
        Me.GroupBox3.TabStop = False
        '
        'Label40
        '
        Me.Label40.BackColor = System.Drawing.Color.Cyan
        Me.Label40.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label40.Font = New System.Drawing.Font("Arial", 6.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label40.Location = New System.Drawing.Point(10, 152)
        Me.Label40.Name = "Label40"
        Me.Label40.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.Label40.Size = New System.Drawing.Size(128, 15)
        Me.Label40.TabIndex = 0
        Me.Label40.Text = "99 - ENV. INDISTINTO"
        Me.Label40.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnGrabar
        '
        Me.btnGrabar.Location = New System.Drawing.Point(19, 427)
        Me.btnGrabar.Name = "btnGrabar"
        Me.btnGrabar.Size = New System.Drawing.Size(108, 51)
        Me.btnGrabar.TabIndex = 9
        Me.btnGrabar.Text = "GRABAR"
        Me.btnGrabar.UseVisualStyleBackColor = True
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Location = New System.Drawing.Point(133, 427)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(108, 51)
        Me.btnLimpiar.TabIndex = 9
        Me.btnLimpiar.Text = "LIMPIAR"
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'btnCerrar
        '
        Me.btnCerrar.Location = New System.Drawing.Point(618, 427)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(108, 51)
        Me.btnCerrar.TabIndex = 9
        Me.btnCerrar.Text = "CERRAR"
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'btnConsultas
        '
        Me.btnConsultas.Location = New System.Drawing.Point(247, 427)
        Me.btnConsultas.Name = "btnConsultas"
        Me.btnConsultas.Size = New System.Drawing.Size(108, 51)
        Me.btnConsultas.TabIndex = 9
        Me.btnConsultas.Text = "CONSULTAS"
        Me.btnConsultas.UseVisualStyleBackColor = True
        '
        'btnEspecificacionesEntrega
        '
        Me.btnEspecificacionesEntrega.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEspecificacionesEntrega.Location = New System.Drawing.Point(361, 334)
        Me.btnEspecificacionesEntrega.Name = "btnEspecificacionesEntrega"
        Me.btnEspecificacionesEntrega.Size = New System.Drawing.Size(225, 38)
        Me.btnEspecificacionesEntrega.TabIndex = 9
        Me.btnEspecificacionesEntrega.Text = "ESPECIFICACIONES DE ENTREGA"
        Me.btnEspecificacionesEntrega.UseVisualStyleBackColor = True
        '
        'btnImpresion
        '
        Me.btnImpresion.Location = New System.Drawing.Point(361, 427)
        Me.btnImpresion.Name = "btnImpresion"
        Me.btnImpresion.Size = New System.Drawing.Size(108, 51)
        Me.btnImpresion.TabIndex = 9
        Me.btnImpresion.Text = "IMPRESIÓN"
        Me.btnImpresion.UseVisualStyleBackColor = True
        '
        'btnDatosAdicionales
        '
        Me.btnDatosAdicionales.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDatosAdicionales.Location = New System.Drawing.Point(475, 427)
        Me.btnDatosAdicionales.Name = "btnDatosAdicionales"
        Me.btnDatosAdicionales.Size = New System.Drawing.Size(137, 51)
        Me.btnDatosAdicionales.TabIndex = 9
        Me.btnDatosAdicionales.Text = "DATOS ADICIONALES"
        Me.btnDatosAdicionales.UseVisualStyleBackColor = True
        '
        'btnBajaPedido
        '
        Me.btnBajaPedido.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBajaPedido.Location = New System.Drawing.Point(361, 374)
        Me.btnBajaPedido.Name = "btnBajaPedido"
        Me.btnBajaPedido.Size = New System.Drawing.Size(225, 41)
        Me.btnBajaPedido.TabIndex = 9
        Me.btnBajaPedido.Text = "BAJA DE PEDIDO"
        Me.btnBajaPedido.UseVisualStyleBackColor = True
        '
        'dgvItems
        '
        Me.dgvItems.AllowUserToAddRows = False
        Me.dgvItems.AllowUserToDeleteRows = False
        Me.dgvItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvItems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Terminado, Me.Descripcion, Me.Cantidad, Me.Precio, Me.Envase1, Me.Canti1, Me.Envase2, Me.Canti2, Me.Envase3, Me.Canti3, Me.Especificaciones, Me.NombreComercial, Me.OrdenTrabajo, Me.Referencia})
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle14.BackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(232, Byte), Integer))
        DataGridViewCellStyle14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle14.Padding = New System.Windows.Forms.Padding(5, 0, 5, 0)
        DataGridViewCellStyle14.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle14.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvItems.DefaultCellStyle = DataGridViewCellStyle14
        Me.dgvItems.DoubleBuffered = True
        Me.dgvItems.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dgvItems.Location = New System.Drawing.Point(6, 195)
        Me.dgvItems.Name = "dgvItems"
        Me.dgvItems.OrdenamientoColumnasHabilitado = False
        Me.dgvItems.RowHeadersWidth = 15
        Me.dgvItems.RowTemplate.Height = 20
        Me.dgvItems.ShowCellToolTips = False
        Me.dgvItems.SinClickDerecho = False
        Me.dgvItems.Size = New System.Drawing.Size(580, 133)
        Me.dgvItems.TabIndex = 6
        '
        'Terminado
        '
        Me.Terminado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Terminado.DataPropertyName = "Terminado"
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Terminado.DefaultCellStyle = DataGridViewCellStyle11
        Me.Terminado.HeaderText = "Producto"
        Me.Terminado.IncludeLiterals = True
        Me.Terminado.IncludePrompt = True
        Me.Terminado.Mask = ">LL-00000-000"
        Me.Terminado.Name = "Terminado"
        Me.Terminado.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.Terminado.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Terminado.ValidatingType = Nothing
        Me.Terminado.Width = 66
        '
        'Descripcion
        '
        Me.Descripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Descripcion.DataPropertyName = "Descripcion"
        Me.Descripcion.HeaderText = "Descripción"
        Me.Descripcion.MinimumWidth = 100
        Me.Descripcion.Name = "Descripcion"
        Me.Descripcion.ReadOnly = True
        Me.Descripcion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Cantidad
        '
        Me.Cantidad.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Cantidad.DataPropertyName = "Cantidad"
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle12.Format = "N2"
        DataGridViewCellStyle12.NullValue = "0"
        DataGridViewCellStyle12.Padding = New System.Windows.Forms.Padding(0, 0, 5, 0)
        Me.Cantidad.DefaultCellStyle = DataGridViewCellStyle12
        Me.Cantidad.HeaderText = "Cantidad"
        Me.Cantidad.Name = "Cantidad"
        Me.Cantidad.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Cantidad.Width = 65
        '
        'Precio
        '
        Me.Precio.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Precio.DataPropertyName = "Precio"
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle13.Format = "N2"
        DataGridViewCellStyle13.NullValue = "0"
        DataGridViewCellStyle13.Padding = New System.Windows.Forms.Padding(0, 0, 5, 0)
        Me.Precio.DefaultCellStyle = DataGridViewCellStyle13
        Me.Precio.HeaderText = "Precio"
        Me.Precio.Name = "Precio"
        Me.Precio.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Precio.Width = 53
        '
        'Envase1
        '
        Me.Envase1.DataPropertyName = "Envase1"
        Me.Envase1.HeaderText = "Envase1"
        Me.Envase1.Name = "Envase1"
        Me.Envase1.ReadOnly = True
        Me.Envase1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Envase1.Visible = False
        '
        'Canti1
        '
        Me.Canti1.DataPropertyName = "Canti1"
        Me.Canti1.HeaderText = "Canti1"
        Me.Canti1.Name = "Canti1"
        Me.Canti1.ReadOnly = True
        Me.Canti1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Canti1.Visible = False
        '
        'Envase2
        '
        Me.Envase2.DataPropertyName = "Envase2"
        Me.Envase2.HeaderText = "Envase2"
        Me.Envase2.Name = "Envase2"
        Me.Envase2.ReadOnly = True
        Me.Envase2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Envase2.Visible = False
        '
        'Canti2
        '
        Me.Canti2.DataPropertyName = "Canti2"
        Me.Canti2.HeaderText = "Canti2"
        Me.Canti2.Name = "Canti2"
        Me.Canti2.ReadOnly = True
        Me.Canti2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Canti2.Visible = False
        '
        'Envase3
        '
        Me.Envase3.DataPropertyName = "Envase3"
        Me.Envase3.HeaderText = "Envase3"
        Me.Envase3.Name = "Envase3"
        Me.Envase3.ReadOnly = True
        Me.Envase3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Envase3.Visible = False
        '
        'Canti3
        '
        Me.Canti3.DataPropertyName = "Canti3"
        Me.Canti3.HeaderText = "Canti3"
        Me.Canti3.Name = "Canti3"
        Me.Canti3.ReadOnly = True
        Me.Canti3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Canti3.Visible = False
        '
        'Especificaciones
        '
        Me.Especificaciones.DataPropertyName = "Especificaciones"
        Me.Especificaciones.HeaderText = "Especificaciones"
        Me.Especificaciones.Name = "Especificaciones"
        Me.Especificaciones.ReadOnly = True
        Me.Especificaciones.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Especificaciones.Visible = False
        '
        'NombreComercial
        '
        Me.NombreComercial.DataPropertyName = "NombreComercial"
        Me.NombreComercial.HeaderText = "NombreComercial"
        Me.NombreComercial.Name = "NombreComercial"
        Me.NombreComercial.ReadOnly = True
        Me.NombreComercial.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.NombreComercial.Visible = False
        '
        'OrdenTrabajo
        '
        Me.OrdenTrabajo.DataPropertyName = "OrdenTrabajo"
        Me.OrdenTrabajo.HeaderText = "OrdenTrabajo"
        Me.OrdenTrabajo.Name = "OrdenTrabajo"
        Me.OrdenTrabajo.ReadOnly = True
        Me.OrdenTrabajo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.OrdenTrabajo.Visible = False
        '
        'Referencia
        '
        Me.Referencia.DataPropertyName = "Referencia"
        Me.Referencia.HeaderText = "Referencia"
        Me.Referencia.Name = "Referencia"
        Me.Referencia.ReadOnly = True
        Me.Referencia.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Referencia.Visible = False
        '
        'dgvEnvasesII
        '
        Me.dgvEnvasesII.AllowUserToAddRows = False
        Me.dgvEnvasesII.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvEnvasesII.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvEnvasesII.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvEnvasesII.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CodigoEnvase, Me.CantidadEnvase})
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(232, Byte), Integer))
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.5!)
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvEnvasesII.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgvEnvasesII.DoubleBuffered = True
        Me.dgvEnvasesII.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dgvEnvasesII.Location = New System.Drawing.Point(10, 168)
        Me.dgvEnvasesII.Name = "dgvEnvasesII"
        Me.dgvEnvasesII.OrdenamientoColumnasHabilitado = False
        Me.dgvEnvasesII.ReadOnly = True
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvEnvasesII.RowHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.dgvEnvasesII.RowHeadersWidth = 5
        Me.dgvEnvasesII.RowTemplate.Height = 20
        Me.dgvEnvasesII.ShowCellToolTips = False
        Me.dgvEnvasesII.SinClickDerecho = False
        Me.dgvEnvasesII.Size = New System.Drawing.Size(128, 59)
        Me.dgvEnvasesII.TabIndex = 1
        '
        'CodigoEnvase
        '
        Me.CodigoEnvase.DataPropertyName = "CodigoEnvase"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.CodigoEnvase.DefaultCellStyle = DataGridViewCellStyle2
        Me.CodigoEnvase.HeaderText = "Cod"
        Me.CodigoEnvase.Name = "CodigoEnvase"
        Me.CodigoEnvase.ReadOnly = True
        Me.CodigoEnvase.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.CodigoEnvase.Width = 60
        '
        'CantidadEnvase
        '
        Me.CantidadEnvase.DataPropertyName = "CantidadEnvase"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.CantidadEnvase.DefaultCellStyle = DataGridViewCellStyle3
        Me.CantidadEnvase.HeaderText = "Cant."
        Me.CantidadEnvase.Name = "CantidadEnvase"
        Me.CantidadEnvase.ReadOnly = True
        Me.CantidadEnvase.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.CantidadEnvase.Width = 60
        '
        'dgvEnvases
        '
        Me.dgvEnvases.AllowUserToAddRows = False
        Me.dgvEnvases.AllowUserToDeleteRows = False
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvEnvases.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgvEnvases.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvEnvases.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Cod, Me.Desc, Me.Kg})
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(232, Byte), Integer))
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.5!)
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvEnvases.DefaultCellStyle = DataGridViewCellStyle9
        Me.dgvEnvases.DoubleBuffered = True
        Me.dgvEnvases.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dgvEnvases.Location = New System.Drawing.Point(5, 11)
        Me.dgvEnvases.Name = "dgvEnvases"
        Me.dgvEnvases.OrdenamientoColumnasHabilitado = False
        Me.dgvEnvases.ReadOnly = True
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvEnvases.RowHeadersDefaultCellStyle = DataGridViewCellStyle10
        Me.dgvEnvases.RowHeadersWidth = 5
        Me.dgvEnvases.RowTemplate.Height = 20
        Me.dgvEnvases.ShowCellToolTips = False
        Me.dgvEnvases.SinClickDerecho = False
        Me.dgvEnvases.Size = New System.Drawing.Size(139, 133)
        Me.dgvEnvases.TabIndex = 0
        '
        'Cod
        '
        Me.Cod.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Cod.DataPropertyName = "Cod"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Cod.DefaultCellStyle = DataGridViewCellStyle7
        Me.Cod.HeaderText = "Cod"
        Me.Cod.Name = "Cod"
        Me.Cod.ReadOnly = True
        Me.Cod.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Cod.Width = 28
        '
        'Desc
        '
        Me.Desc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Desc.DataPropertyName = "Desc"
        Me.Desc.HeaderText = "Desc"
        Me.Desc.Name = "Desc"
        Me.Desc.ReadOnly = True
        Me.Desc.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Kg
        '
        Me.Kg.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Kg.DataPropertyName = "Kg"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Kg.DefaultCellStyle = DataGridViewCellStyle8
        Me.Kg.HeaderText = "Kg"
        Me.Kg.Name = "Kg"
        Me.Kg.ReadOnly = True
        Me.Kg.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Kg.Width = 22
        '
        'IngresoPedido
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(745, 490)
        Me.Controls.Add(Me.btnImpresion)
        Me.Controls.Add(Me.btnBajaPedido)
        Me.Controls.Add(Me.btnDatosAdicionales)
        Me.Controls.Add(Me.btnEspecificacionesEntrega)
        Me.Controls.Add(Me.btnConsultas)
        Me.Controls.Add(Me.btnCerrar)
        Me.Controls.Add(Me.btnLimpiar)
        Me.Controls.Add(Me.btnGrabar)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.dgvItems)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.panel1)
        Me.Controls.Add(Me.GroupBox3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Location = New System.Drawing.Point(10, 10)
        Me.MaximizeBox = False
        Me.Name = "IngresoPedido"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.panel1.ResumeLayout(False)
        Me.panel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.dgvItems, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvEnvasesII, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvEnvases, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents panel1 As System.Windows.Forms.Panel
    Private WithEvents Label2 As System.Windows.Forms.Label
    Private WithEvents label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtPedido As System.Windows.Forms.TextBox
    Friend WithEvents txtFecha As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtVersion As System.Windows.Forms.TextBox
    Friend WithEvents txtCliente As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblDescCliente As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cmbTipoPedido As System.Windows.Forms.ComboBox
    Friend WithEvents txtFechaEntrega As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtHora As System.Windows.Forms.TextBox
    Friend WithEvents txtCondPago As System.Windows.Forms.Label
    Friend WithEvents lblDescCondPago As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtObservaciones As System.Windows.Forms.TextBox
    Friend WithEvents cmbVia As System.Windows.Forms.ComboBox
    Friend WithEvents txtOrdenCpa As System.Windows.Forms.TextBox
    Friend WithEvents txtModPrecio As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents dgvItems As Util.DBDataGridView
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents lblStock As System.Windows.Forms.Label
    Friend WithEvents lblDisponible As System.Windows.Forms.Label
    Friend WithEvents lblProduccion As System.Windows.Forms.Label
    Friend WithEvents lblPedido As System.Windows.Forms.Label
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents lblSVII As System.Windows.Forms.Label
    Friend WithEvents lblSIV As System.Windows.Forms.Label
    Friend WithEvents lblSVI As System.Windows.Forms.Label
    Friend WithEvents lblSIII As System.Windows.Forms.Label
    Friend WithEvents lblSV As System.Windows.Forms.Label
    Friend WithEvents lblSII As System.Windows.Forms.Label
    Friend WithEvents lblSI As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents dgvEnvases As Util.DBDataGridView
    Friend WithEvents Cod As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Desc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Kg As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgvEnvasesII As Util.DBDataGridView
    Friend WithEvents CodigoEnvase As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CantidadEnvase As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents btnGrabar As System.Windows.Forms.Button
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents btnConsultas As System.Windows.Forms.Button
    Friend WithEvents btnEspecificacionesEntrega As System.Windows.Forms.Button
    Friend WithEvents btnImpresion As System.Windows.Forms.Button
    Friend WithEvents btnDatosAdicionales As System.Windows.Forms.Button
    Friend WithEvents btnBajaPedido As System.Windows.Forms.Button
    Friend WithEvents btnBloquearPedido As System.Windows.Forms.Button
    Friend WithEvents btnPedidoPellital As System.Windows.Forms.Button
    Friend WithEvents Terminado As Util.MyMaskedTextBoxColumn
    Friend WithEvents Descripcion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cantidad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Precio As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Envase1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Canti1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Envase2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Canti2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Envase3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Canti3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Especificaciones As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NombreComercial As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OrdenTrabajo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Referencia As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
