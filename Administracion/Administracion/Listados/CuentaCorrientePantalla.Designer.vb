<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CuentaCorrientePantalla
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.GRilla = New System.Windows.Forms.DataGridView()
        Me.Tipo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Letra = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Punto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Numero = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Importe = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Saldo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Fecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Vencimiento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.opcCompleto = New System.Windows.Forms.RadioButton()
        Me.opcPendiente = New System.Windows.Forms.RadioButton()
        Me.boxPantallaProveedores = New System.Windows.Forms.GroupBox()
        Me.lstFiltrada = New Administracion.CustomListBox()
        Me.lstAyuda = New Administracion.CustomListBox()
        Me.txtAyuda = New Administracion.CustomTextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.gbSaldoCtaCliente = New System.Windows.Forms.GroupBox()
        Me.lblClienteAsociado = New Administracion.CustomLabel()
        Me.lblSaldoCuentaProveedor = New Administracion.CustomLabel()
        Me.CBProveedorSelectivo = New System.Windows.Forms.CheckBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnCancela = New Administracion.CustomButton()
        Me.btnConsulta = New Administracion.CustomButton()
        Me.txtProveedor = New Administracion.CustomTextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblTotalNC = New System.Windows.Forms.Label()
        Me.lblTotalPagos = New System.Windows.Forms.Label()
        Me.lblTotalND = New System.Windows.Forms.Label()
        Me.lblTotalFC = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtSaldo = New Administracion.CustomTextBox()
        Me.CustomLabel2 = New Administracion.CustomLabel()
        Me.txtRazon = New Administracion.CustomTextBox()
        Me.CustomLabel1 = New Administracion.CustomLabel()
        Me.CustomLabel3 = New Administracion.CustomLabel()
        Me.btnLimpiar = New Administracion.CustomButton()
        CType(Me.GRilla, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.boxPantallaProveedores.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.gbSaldoCtaCliente.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GRilla
        '
        Me.GRilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GRilla.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Tipo, Me.Letra, Me.Punto, Me.Numero, Me.Importe, Me.Saldo, Me.Fecha, Me.Vencimiento})
        Me.GRilla.Location = New System.Drawing.Point(47, 149)
        Me.GRilla.Name = "GRilla"
        Me.GRilla.Size = New System.Drawing.Size(695, 346)
        Me.GRilla.StandardTab = True
        Me.GRilla.TabIndex = 1
        '
        'Tipo
        '
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft
        Me.Tipo.DefaultCellStyle = DataGridViewCellStyle9
        Me.Tipo.HeaderText = "Tipo"
        Me.Tipo.Name = "Tipo"
        Me.Tipo.ReadOnly = True
        Me.Tipo.Width = 50
        '
        'Letra
        '
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft
        Me.Letra.DefaultCellStyle = DataGridViewCellStyle10
        Me.Letra.HeaderText = "Letra"
        Me.Letra.Name = "Letra"
        Me.Letra.ReadOnly = True
        Me.Letra.Width = 50
        '
        'Punto
        '
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        Me.Punto.DefaultCellStyle = DataGridViewCellStyle11
        Me.Punto.HeaderText = "Punto"
        Me.Punto.Name = "Punto"
        Me.Punto.ReadOnly = True
        Me.Punto.Width = 50
        '
        'Numero
        '
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        Me.Numero.DefaultCellStyle = DataGridViewCellStyle12
        Me.Numero.HeaderText = "Numero"
        Me.Numero.Name = "Numero"
        Me.Numero.ReadOnly = True
        '
        'Importe
        '
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        Me.Importe.DefaultCellStyle = DataGridViewCellStyle13
        Me.Importe.HeaderText = "Importe"
        Me.Importe.Name = "Importe"
        Me.Importe.ReadOnly = True
        '
        'Saldo
        '
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        Me.Saldo.DefaultCellStyle = DataGridViewCellStyle14
        Me.Saldo.HeaderText = "Saldo"
        Me.Saldo.Name = "Saldo"
        Me.Saldo.ReadOnly = True
        '
        'Fecha
        '
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        Me.Fecha.DefaultCellStyle = DataGridViewCellStyle15
        Me.Fecha.HeaderText = "Fecha"
        Me.Fecha.Name = "Fecha"
        Me.Fecha.ReadOnly = True
        '
        'Vencimiento
        '
        DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        Me.Vencimiento.DefaultCellStyle = DataGridViewCellStyle16
        Me.Vencimiento.HeaderText = "Vencimiento"
        Me.Vencimiento.Name = "Vencimiento"
        Me.Vencimiento.ReadOnly = True
        '
        'opcCompleto
        '
        Me.opcCompleto.AutoSize = True
        Me.opcCompleto.BackColor = System.Drawing.Color.FromArgb(CType(CType(95, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(82, Byte), Integer))
        Me.opcCompleto.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.opcCompleto.ForeColor = System.Drawing.SystemColors.Control
        Me.opcCompleto.Location = New System.Drawing.Point(425, 91)
        Me.opcCompleto.Name = "opcCompleto"
        Me.opcCompleto.Size = New System.Drawing.Size(87, 22)
        Me.opcCompleto.TabIndex = 24
        Me.opcCompleto.TabStop = True
        Me.opcCompleto.Text = "Completo"
        Me.opcCompleto.UseVisualStyleBackColor = False
        '
        'opcPendiente
        '
        Me.opcPendiente.AutoSize = True
        Me.opcPendiente.BackColor = System.Drawing.Color.FromArgb(CType(CType(95, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(82, Byte), Integer))
        Me.opcPendiente.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.opcPendiente.ForeColor = System.Drawing.SystemColors.Control
        Me.opcPendiente.Location = New System.Drawing.Point(320, 91)
        Me.opcPendiente.Name = "opcPendiente"
        Me.opcPendiente.Size = New System.Drawing.Size(91, 22)
        Me.opcPendiente.TabIndex = 23
        Me.opcPendiente.TabStop = True
        Me.opcPendiente.Text = "Pendiente"
        Me.opcPendiente.UseVisualStyleBackColor = False
        '
        'boxPantallaProveedores
        '
        Me.boxPantallaProveedores.Controls.Add(Me.lstFiltrada)
        Me.boxPantallaProveedores.Controls.Add(Me.lstAyuda)
        Me.boxPantallaProveedores.Controls.Add(Me.txtAyuda)
        Me.boxPantallaProveedores.Location = New System.Drawing.Point(136, 180)
        Me.boxPantallaProveedores.Name = "boxPantallaProveedores"
        Me.boxPantallaProveedores.Size = New System.Drawing.Size(541, 304)
        Me.boxPantallaProveedores.TabIndex = 27
        Me.boxPantallaProveedores.TabStop = False
        Me.boxPantallaProveedores.Visible = False
        '
        'lstFiltrada
        '
        Me.lstFiltrada.Cleanable = False
        Me.lstFiltrada.EnterIndex = -1
        Me.lstFiltrada.FormattingEnabled = True
        Me.lstFiltrada.LabelAssociationKey = -1
        Me.lstFiltrada.Location = New System.Drawing.Point(62, 38)
        Me.lstFiltrada.Name = "lstFiltrada"
        Me.lstFiltrada.Size = New System.Drawing.Size(417, 251)
        Me.lstFiltrada.TabIndex = 30
        Me.lstFiltrada.Visible = False
        '
        'lstAyuda
        '
        Me.lstAyuda.Cleanable = False
        Me.lstAyuda.EnterIndex = -1
        Me.lstAyuda.FormattingEnabled = True
        Me.lstAyuda.LabelAssociationKey = -1
        Me.lstAyuda.Location = New System.Drawing.Point(62, 38)
        Me.lstAyuda.Name = "lstAyuda"
        Me.lstAyuda.Size = New System.Drawing.Size(417, 251)
        Me.lstAyuda.TabIndex = 29
        '
        'txtAyuda
        '
        Me.txtAyuda.Cleanable = False
        Me.txtAyuda.Empty = True
        Me.txtAyuda.EnterIndex = -1
        Me.txtAyuda.LabelAssociationKey = -1
        Me.txtAyuda.Location = New System.Drawing.Point(62, 13)
        Me.txtAyuda.Name = "txtAyuda"
        Me.txtAyuda.Size = New System.Drawing.Size(417, 20)
        Me.txtAyuda.TabIndex = 28
        Me.txtAyuda.Validator = Administracion.ValidatorType.None
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(779, 50)
        Me.Panel1.TabIndex = 29
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.Control
        Me.Label2.Location = New System.Drawing.Point(605, 10)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(156, 26)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "SURFACTAN S.A."
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.Control
        Me.Label1.Location = New System.Drawing.Point(27, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(242, 19)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Cuenta Corrientes de Proveedores"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(95, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(82, Byte), Integer))
        Me.Panel2.Controls.Add(Me.gbSaldoCtaCliente)
        Me.Panel2.Controls.Add(Me.CBProveedorSelectivo)
        Me.Panel2.Location = New System.Drawing.Point(0, 50)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(777, 88)
        Me.Panel2.TabIndex = 30
        '
        'gbSaldoCtaCliente
        '
        Me.gbSaldoCtaCliente.Controls.Add(Me.lblClienteAsociado)
        Me.gbSaldoCtaCliente.Controls.Add(Me.lblSaldoCuentaProveedor)
        Me.gbSaldoCtaCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbSaldoCtaCliente.ForeColor = System.Drawing.SystemColors.Control
        Me.gbSaldoCtaCliente.Location = New System.Drawing.Point(557, 39)
        Me.gbSaldoCtaCliente.Name = "gbSaldoCtaCliente"
        Me.gbSaldoCtaCliente.Size = New System.Drawing.Size(207, 43)
        Me.gbSaldoCtaCliente.TabIndex = 1
        Me.gbSaldoCtaCliente.TabStop = False
        Me.gbSaldoCtaCliente.Text = "Saldo Cuenta Cliente"
        Me.ToolTip1.SetToolTip(Me.gbSaldoCtaCliente, "Cliente Asociado (Doble Click para abrir Facturas)")
        Me.gbSaldoCtaCliente.Visible = False
        '
        'lblClienteAsociado
        '
        Me.lblClienteAsociado.AutoSize = True
        Me.lblClienteAsociado.BackColor = System.Drawing.Color.FromArgb(CType(CType(95, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(82, Byte), Integer))
        Me.lblClienteAsociado.ControlAssociationKey = -1
        Me.lblClienteAsociado.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.lblClienteAsociado.ForeColor = System.Drawing.SystemColors.Control
        Me.lblClienteAsociado.Location = New System.Drawing.Point(34, 17)
        Me.lblClienteAsociado.Name = "lblClienteAsociado"
        Me.lblClienteAsociado.Size = New System.Drawing.Size(26, 18)
        Me.lblClienteAsociado.TabIndex = 32
        Me.lblClienteAsociado.Text = "      "
        Me.lblClienteAsociado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ToolTip1.SetToolTip(Me.lblClienteAsociado, "Cliente Asociado (Doble Click para abrir Facturas)")
        '
        'lblSaldoCuentaProveedor
        '
        Me.lblSaldoCuentaProveedor.AutoSize = True
        Me.lblSaldoCuentaProveedor.BackColor = System.Drawing.Color.FromArgb(CType(CType(95, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(82, Byte), Integer))
        Me.lblSaldoCuentaProveedor.ControlAssociationKey = -1
        Me.lblSaldoCuentaProveedor.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.lblSaldoCuentaProveedor.ForeColor = System.Drawing.SystemColors.Control
        Me.lblSaldoCuentaProveedor.Location = New System.Drawing.Point(97, 15)
        Me.lblSaldoCuentaProveedor.MinimumSize = New System.Drawing.Size(100, 20)
        Me.lblSaldoCuentaProveedor.Name = "lblSaldoCuentaProveedor"
        Me.lblSaldoCuentaProveedor.Size = New System.Drawing.Size(100, 20)
        Me.lblSaldoCuentaProveedor.TabIndex = 31
        Me.lblSaldoCuentaProveedor.Text = "0.00"
        Me.lblSaldoCuentaProveedor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ToolTip1.SetToolTip(Me.lblSaldoCuentaProveedor, "Cliente Asociado (Doble Click para abrir Facturas)")
        '
        'CBProveedorSelectivo
        '
        Me.CBProveedorSelectivo.AutoSize = True
        Me.CBProveedorSelectivo.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.CBProveedorSelectivo.ForeColor = System.Drawing.SystemColors.Control
        Me.CBProveedorSelectivo.Location = New System.Drawing.Point(557, 14)
        Me.CBProveedorSelectivo.Name = "CBProveedorSelectivo"
        Me.CBProveedorSelectivo.Size = New System.Drawing.Size(217, 22)
        Me.CBProveedorSelectivo.TabIndex = 0
        Me.CBProveedorSelectivo.Text = "Seleccionar para Pago Semanal"
        Me.CBProveedorSelectivo.UseVisualStyleBackColor = True
        '
        'btnCancela
        '
        Me.btnCancela.BackColor = System.Drawing.SystemColors.Control
        Me.btnCancela.BackgroundImage = Global.Administracion.My.Resources.Resources.Salir2
        Me.btnCancela.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnCancela.Cleanable = False
        Me.btnCancela.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCancela.EnterIndex = -1
        Me.btnCancela.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnCancela.FlatAppearance.BorderSize = 0
        Me.btnCancela.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(95, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(82, Byte), Integer))
        Me.btnCancela.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control
        Me.btnCancela.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control
        Me.btnCancela.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancela.LabelAssociationKey = -1
        Me.btnCancela.Location = New System.Drawing.Point(342, 542)
        Me.btnCancela.Name = "btnCancela"
        Me.btnCancela.Size = New System.Drawing.Size(93, 50)
        Me.btnCancela.TabIndex = 28
        Me.ToolTip1.SetToolTip(Me.btnCancela, "Cerrar")
        Me.btnCancela.UseVisualStyleBackColor = False
        '
        'btnConsulta
        '
        Me.btnConsulta.BackColor = System.Drawing.SystemColors.Control
        Me.btnConsulta.BackgroundImage = Global.Administracion.My.Resources.Resources.Consulta_Dat_N1
        Me.btnConsulta.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnConsulta.Cleanable = False
        Me.btnConsulta.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnConsulta.EnterIndex = -1
        Me.btnConsulta.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnConsulta.FlatAppearance.BorderSize = 0
        Me.btnConsulta.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(95, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(82, Byte), Integer))
        Me.btnConsulta.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control
        Me.btnConsulta.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control
        Me.btnConsulta.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnConsulta.LabelAssociationKey = -1
        Me.btnConsulta.Location = New System.Drawing.Point(213, 542)
        Me.btnConsulta.Name = "btnConsulta"
        Me.btnConsulta.Size = New System.Drawing.Size(93, 50)
        Me.btnConsulta.TabIndex = 26
        Me.ToolTip1.SetToolTip(Me.btnConsulta, "Abrir Consulta")
        Me.btnConsulta.UseVisualStyleBackColor = False
        '
        'txtProveedor
        '
        Me.txtProveedor.BackColor = System.Drawing.SystemColors.Control
        Me.txtProveedor.Cleanable = False
        Me.txtProveedor.Empty = True
        Me.txtProveedor.EnterIndex = -1
        Me.txtProveedor.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtProveedor.LabelAssociationKey = -1
        Me.txtProveedor.Location = New System.Drawing.Point(136, 64)
        Me.txtProveedor.MaxLength = 11
        Me.txtProveedor.Name = "txtProveedor"
        Me.txtProveedor.Size = New System.Drawing.Size(108, 20)
        Me.txtProveedor.TabIndex = 0
        Me.txtProveedor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.txtProveedor, "Doble Click: Abrir Consulta de Proveedores")
        Me.txtProveedor.Validator = Administracion.ValidatorType.None
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblTotalNC)
        Me.GroupBox1.Controls.Add(Me.lblTotalPagos)
        Me.GroupBox1.Controls.Add(Me.lblTotalND)
        Me.GroupBox1.Controls.Add(Me.lblTotalFC)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Location = New System.Drawing.Point(394, 501)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(320, 122)
        Me.GroupBox1.TabIndex = 31
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Montos detallados por periodo"
        Me.GroupBox1.Visible = False
        '
        'lblTotalNC
        '
        Me.lblTotalNC.Location = New System.Drawing.Point(86, 61)
        Me.lblTotalNC.Name = "lblTotalNC"
        Me.lblTotalNC.Size = New System.Drawing.Size(183, 17)
        Me.lblTotalNC.TabIndex = 1
        Me.lblTotalNC.Text = "$ 0.00"
        Me.lblTotalNC.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTotalPagos
        '
        Me.lblTotalPagos.Location = New System.Drawing.Point(86, 80)
        Me.lblTotalPagos.Name = "lblTotalPagos"
        Me.lblTotalPagos.Size = New System.Drawing.Size(183, 17)
        Me.lblTotalPagos.TabIndex = 1
        Me.lblTotalPagos.Text = "$ 0.00"
        Me.lblTotalPagos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTotalND
        '
        Me.lblTotalND.Location = New System.Drawing.Point(86, 41)
        Me.lblTotalND.Name = "lblTotalND"
        Me.lblTotalND.Size = New System.Drawing.Size(183, 17)
        Me.lblTotalND.TabIndex = 1
        Me.lblTotalND.Text = "$ 0.00"
        Me.lblTotalND.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTotalFC
        '
        Me.lblTotalFC.Location = New System.Drawing.Point(86, 24)
        Me.lblTotalFC.Name = "lblTotalFC"
        Me.lblTotalFC.Size = New System.Drawing.Size(183, 13)
        Me.lblTotalFC.TabIndex = 1
        Me.lblTotalFC.Text = "$ 0.00"
        Me.lblTotalFC.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(51, 83)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(37, 13)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Pagos"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(51, 64)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(22, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "NC"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(51, 43)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(23, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "ND"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(51, 24)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(20, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "FC"
        '
        'txtSaldo
        '
        Me.txtSaldo.Cleanable = False
        Me.txtSaldo.Empty = True
        Me.txtSaldo.EnterIndex = -1
        Me.txtSaldo.LabelAssociationKey = -1
        Me.txtSaldo.Location = New System.Drawing.Point(136, 88)
        Me.txtSaldo.Name = "txtSaldo"
        Me.txtSaldo.ReadOnly = True
        Me.txtSaldo.Size = New System.Drawing.Size(108, 20)
        Me.txtSaldo.TabIndex = 7
        Me.txtSaldo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtSaldo.Validator = Administracion.ValidatorType.None
        '
        'CustomLabel2
        '
        Me.CustomLabel2.AutoSize = True
        Me.CustomLabel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(95, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(82, Byte), Integer))
        Me.CustomLabel2.ControlAssociationKey = -1
        Me.CustomLabel2.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.CustomLabel2.ForeColor = System.Drawing.SystemColors.Control
        Me.CustomLabel2.Location = New System.Drawing.Point(63, 91)
        Me.CustomLabel2.Name = "CustomLabel2"
        Me.CustomLabel2.Size = New System.Drawing.Size(42, 18)
        Me.CustomLabel2.TabIndex = 8
        Me.CustomLabel2.Text = "Saldo"
        '
        'txtRazon
        '
        Me.txtRazon.BackColor = System.Drawing.Color.Gainsboro
        Me.txtRazon.Cleanable = False
        Me.txtRazon.Empty = True
        Me.txtRazon.EnterIndex = -1
        Me.txtRazon.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRazon.LabelAssociationKey = -1
        Me.txtRazon.Location = New System.Drawing.Point(250, 64)
        Me.txtRazon.Name = "txtRazon"
        Me.txtRazon.ReadOnly = True
        Me.txtRazon.Size = New System.Drawing.Size(298, 20)
        Me.txtRazon.TabIndex = 6
        Me.txtRazon.Validator = Administracion.ValidatorType.None
        '
        'CustomLabel1
        '
        Me.CustomLabel1.AutoSize = True
        Me.CustomLabel1.ControlAssociationKey = -1
        Me.CustomLabel1.Location = New System.Drawing.Point(373, 100)
        Me.CustomLabel1.Name = "CustomLabel1"
        Me.CustomLabel1.Size = New System.Drawing.Size(0, 13)
        Me.CustomLabel1.TabIndex = 5
        '
        'CustomLabel3
        '
        Me.CustomLabel3.AutoSize = True
        Me.CustomLabel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(95, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(82, Byte), Integer))
        Me.CustomLabel3.ControlAssociationKey = -1
        Me.CustomLabel3.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.CustomLabel3.ForeColor = System.Drawing.SystemColors.Control
        Me.CustomLabel3.Location = New System.Drawing.Point(63, 67)
        Me.CustomLabel3.Name = "CustomLabel3"
        Me.CustomLabel3.Size = New System.Drawing.Size(73, 18)
        Me.CustomLabel3.TabIndex = 3
        Me.CustomLabel3.Text = "Proveedor"
        '
        'btnLimpiar
        '
        Me.btnLimpiar.BackColor = System.Drawing.SystemColors.Control
        Me.btnLimpiar.BackgroundImage = Global.Administracion.My.Resources.Resources.Limpiar
        Me.btnLimpiar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnLimpiar.Cleanable = False
        Me.btnLimpiar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnLimpiar.EnterIndex = -1
        Me.btnLimpiar.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnLimpiar.FlatAppearance.BorderSize = 0
        Me.btnLimpiar.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(95, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(82, Byte), Integer))
        Me.btnLimpiar.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control
        Me.btnLimpiar.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control
        Me.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLimpiar.LabelAssociationKey = -1
        Me.btnLimpiar.Location = New System.Drawing.Point(471, 542)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(93, 50)
        Me.btnLimpiar.TabIndex = 28
        Me.btnLimpiar.UseVisualStyleBackColor = False
        '
        'CuentaCorrientePantalla
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(777, 635)
        Me.Controls.Add(Me.btnLimpiar)
        Me.Controls.Add(Me.btnCancela)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.boxPantallaProveedores)
        Me.Controls.Add(Me.btnConsulta)
        Me.Controls.Add(Me.opcCompleto)
        Me.Controls.Add(Me.opcPendiente)
        Me.Controls.Add(Me.txtSaldo)
        Me.Controls.Add(Me.CustomLabel2)
        Me.Controls.Add(Me.txtRazon)
        Me.Controls.Add(Me.CustomLabel1)
        Me.Controls.Add(Me.txtProveedor)
        Me.Controls.Add(Me.CustomLabel3)
        Me.Controls.Add(Me.GRilla)
        Me.Controls.Add(Me.Panel2)
        Me.Name = "CuentaCorrientePantalla"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.GRilla, System.ComponentModel.ISupportInitialize).EndInit()
        Me.boxPantallaProveedores.ResumeLayout(False)
        Me.boxPantallaProveedores.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.gbSaldoCtaCliente.ResumeLayout(False)
        Me.gbSaldoCtaCliente.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GRilla As System.Windows.Forms.DataGridView
    Friend WithEvents CustomLabel3 As Administracion.CustomLabel
    Friend WithEvents txtProveedor As Administracion.CustomTextBox
    Friend WithEvents CustomLabel1 As Administracion.CustomLabel
    Friend WithEvents txtRazon As Administracion.CustomTextBox
    Friend WithEvents txtSaldo As Administracion.CustomTextBox
    Friend WithEvents CustomLabel2 As Administracion.CustomLabel
    Friend WithEvents opcCompleto As System.Windows.Forms.RadioButton
    Friend WithEvents opcPendiente As System.Windows.Forms.RadioButton
    Friend WithEvents btnConsulta As Administracion.CustomButton
    Friend WithEvents boxPantallaProveedores As System.Windows.Forms.GroupBox
    Friend WithEvents lstAyuda As Administracion.CustomListBox
    Friend WithEvents txtAyuda As Administracion.CustomTextBox
    Friend WithEvents btnCancela As Administracion.CustomButton
    Friend WithEvents Tipo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Letra As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Punto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Numero As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Importe As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Saldo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Fecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Vencimiento As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents CBProveedorSelectivo As System.Windows.Forms.CheckBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents lstFiltrada As Administracion.CustomListBox
    Friend WithEvents gbSaldoCtaCliente As System.Windows.Forms.GroupBox
    Friend WithEvents lblSaldoCuentaProveedor As Administracion.CustomLabel
    Friend WithEvents lblClienteAsociado As Administracion.CustomLabel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblTotalNC As System.Windows.Forms.Label
    Friend WithEvents lblTotalND As System.Windows.Forms.Label
    Friend WithEvents lblTotalFC As System.Windows.Forms.Label
    Friend WithEvents lblTotalPagos As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btnLimpiar As Administracion.CustomButton
End Class
