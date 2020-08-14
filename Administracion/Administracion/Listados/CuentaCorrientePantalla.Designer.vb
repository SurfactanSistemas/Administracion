Imports Util

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
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.GRilla = New Util.DBDataGridView()
        Me.Tipo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Letra = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Punto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Numero = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Fecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Debito = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Credito = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Saldo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Vencimiento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OrdFecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OrdVencimiento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Importe = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MarcaVirtual = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Impre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NroInterno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.opcCompleto = New System.Windows.Forms.RadioButton()
        Me.opcPendiente = New System.Windows.Forms.RadioButton()
        Me.pnlSelectivo = New System.Windows.Forms.Panel()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtFechaSelectivo = New System.Windows.Forms.MaskedTextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.gbSaldoCtaCliente = New System.Windows.Forms.GroupBox()
        Me.CBProveedorSelectivo = New System.Windows.Forms.CheckBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblTotalNC = New System.Windows.Forms.Label()
        Me.lblTotalPagos = New System.Windows.Forms.Label()
        Me.lblTotalND = New System.Windows.Forms.Label()
        Me.lblTotalFC = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnGrabarSelectivo = New Administracion.CustomButton()
        Me.btnCerrarFechaSelectivo = New Administracion.CustomButton()
        Me.btnLimpiar = New Administracion.CustomButton()
        Me.btnCancela = New Administracion.CustomButton()
        Me.btnConsulta = New Administracion.CustomButton()
        Me.CustomLabel1 = New Administracion.CustomLabel()
        Me.lblClienteAsociado = New Administracion.CustomLabel()
        Me.lblSaldoCuentaProveedor = New Administracion.CustomLabel()
        Me.lblAceptaTransferencia = New Administracion.CustomLabel()
        Me.lblAceptaCheque = New Administracion.CustomLabel()
        Me.CustomLabel3 = New Administracion.CustomLabel()
        Me.txtProveedor = New Administracion.CustomTextBox()
        Me.txtRazon = New Administracion.CustomTextBox()
        Me.CustomLabel2 = New Administracion.CustomLabel()
        Me.txtSaldo = New Administracion.CustomTextBox()
        CType(Me.GRilla, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlSelectivo.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.gbSaldoCtaCliente.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GRilla
        '
        Me.GRilla.AllowUserToAddRows = False
        Me.GRilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GRilla.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Tipo, Me.Letra, Me.Punto, Me.Numero, Me.Fecha, Me.Debito, Me.Credito, Me.Saldo, Me.Vencimiento, Me.OrdFecha, Me.OrdVencimiento, Me.Importe, Me.MarcaVirtual, Me.Impre, Me.NroInterno})
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(232, Byte), Integer))
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GRilla.DefaultCellStyle = DataGridViewCellStyle11
        Me.GRilla.DoubleBuffered = True
        Me.GRilla.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.GRilla.Location = New System.Drawing.Point(46, 149)
        Me.GRilla.Name = "GRilla"
        Me.GRilla.OrdenamientoColumnasHabilitado = True
        Me.GRilla.RowHeadersWidth = 15
        Me.GRilla.ShowCellToolTips = False
        Me.GRilla.SinClickDerecho = True
        Me.GRilla.Size = New System.Drawing.Size(652, 258)
        Me.GRilla.StandardTab = True
        Me.GRilla.TabIndex = 1
        '
        'Tipo
        '
        Me.Tipo.DataPropertyName = "Tipo"
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft
        Me.Tipo.DefaultCellStyle = DataGridViewCellStyle1
        Me.Tipo.HeaderText = "Tipo"
        Me.Tipo.Name = "Tipo"
        Me.Tipo.ReadOnly = True
        Me.Tipo.Width = 50
        '
        'Letra
        '
        Me.Letra.DataPropertyName = "Letra"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft
        Me.Letra.DefaultCellStyle = DataGridViewCellStyle2
        Me.Letra.HeaderText = "Letra"
        Me.Letra.Name = "Letra"
        Me.Letra.ReadOnly = True
        Me.Letra.Visible = False
        Me.Letra.Width = 50
        '
        'Punto
        '
        Me.Punto.DataPropertyName = "Punto"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        Me.Punto.DefaultCellStyle = DataGridViewCellStyle3
        Me.Punto.HeaderText = "Punto"
        Me.Punto.Name = "Punto"
        Me.Punto.ReadOnly = True
        Me.Punto.Visible = False
        Me.Punto.Width = 50
        '
        'Numero
        '
        Me.Numero.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Numero.DataPropertyName = "Numero"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        Me.Numero.DefaultCellStyle = DataGridViewCellStyle4
        Me.Numero.HeaderText = "Numero"
        Me.Numero.Name = "Numero"
        Me.Numero.ReadOnly = True
        '
        'Fecha
        '
        Me.Fecha.DataPropertyName = "Fecha"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        Me.Fecha.DefaultCellStyle = DataGridViewCellStyle5
        Me.Fecha.HeaderText = "Fecha"
        Me.Fecha.Name = "Fecha"
        Me.Fecha.ReadOnly = True
        '
        'Debito
        '
        Me.Debito.DataPropertyName = "Debito"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle6.Format = "N2"
        Me.Debito.DefaultCellStyle = DataGridViewCellStyle6
        Me.Debito.HeaderText = "Debito"
        Me.Debito.Name = "Debito"
        '
        'Credito
        '
        Me.Credito.DataPropertyName = "Credito"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle7.Format = "N2"
        Me.Credito.DefaultCellStyle = DataGridViewCellStyle7
        Me.Credito.HeaderText = "Crédito"
        Me.Credito.Name = "Credito"
        '
        'Saldo
        '
        Me.Saldo.DataPropertyName = "Saldo"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        DataGridViewCellStyle8.Format = "N2"
        DataGridViewCellStyle8.NullValue = Nothing
        Me.Saldo.DefaultCellStyle = DataGridViewCellStyle8
        Me.Saldo.HeaderText = "Saldo"
        Me.Saldo.Name = "Saldo"
        Me.Saldo.ReadOnly = True
        '
        'Vencimiento
        '
        Me.Vencimiento.DataPropertyName = "Vencimiento"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        Me.Vencimiento.DefaultCellStyle = DataGridViewCellStyle9
        Me.Vencimiento.HeaderText = "Vencimiento"
        Me.Vencimiento.Name = "Vencimiento"
        Me.Vencimiento.ReadOnly = True
        '
        'OrdFecha
        '
        Me.OrdFecha.DataPropertyName = "OrdFecha"
        Me.OrdFecha.HeaderText = "OrdFecha"
        Me.OrdFecha.Name = "OrdFecha"
        Me.OrdFecha.Visible = False
        '
        'OrdVencimiento
        '
        Me.OrdVencimiento.DataPropertyName = "OrdVencimiento"
        Me.OrdVencimiento.HeaderText = "OrdVencimiento"
        Me.OrdVencimiento.Name = "OrdVencimiento"
        Me.OrdVencimiento.Visible = False
        '
        'Importe
        '
        Me.Importe.DataPropertyName = "Importe"
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        DataGridViewCellStyle10.Format = "N2"
        DataGridViewCellStyle10.NullValue = Nothing
        Me.Importe.DefaultCellStyle = DataGridViewCellStyle10
        Me.Importe.HeaderText = "Importe"
        Me.Importe.Name = "Importe"
        Me.Importe.ReadOnly = True
        Me.Importe.Visible = False
        '
        'MarcaVirtual
        '
        Me.MarcaVirtual.DataPropertyName = "MarcaVirtual"
        Me.MarcaVirtual.HeaderText = "MarcaVirtual"
        Me.MarcaVirtual.Name = "MarcaVirtual"
        Me.MarcaVirtual.ReadOnly = True
        Me.MarcaVirtual.Visible = False
        '
        'Impre
        '
        Me.Impre.DataPropertyName = "Impre"
        Me.Impre.HeaderText = "Impre"
        Me.Impre.Name = "Impre"
        Me.Impre.ReadOnly = True
        Me.Impre.Visible = False
        '
        'NroInterno
        '
        Me.NroInterno.DataPropertyName = "NroInterno"
        Me.NroInterno.HeaderText = "NroInterno"
        Me.NroInterno.Name = "NroInterno"
        Me.NroInterno.ReadOnly = True
        Me.NroInterno.Visible = False
        '
        'opcCompleto
        '
        Me.opcCompleto.AutoSize = True
        Me.opcCompleto.BackColor = System.Drawing.Color.FromArgb(CType(CType(95, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(82, Byte), Integer))
        Me.opcCompleto.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.opcCompleto.ForeColor = System.Drawing.SystemColors.Control
        Me.opcCompleto.Location = New System.Drawing.Point(383, 29)
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
        Me.opcPendiente.Location = New System.Drawing.Point(278, 29)
        Me.opcPendiente.Name = "opcPendiente"
        Me.opcPendiente.Size = New System.Drawing.Size(91, 22)
        Me.opcPendiente.TabIndex = 23
        Me.opcPendiente.TabStop = True
        Me.opcPendiente.Text = "Pendiente"
        Me.opcPendiente.UseVisualStyleBackColor = False
        '
        'pnlSelectivo
        '
        Me.pnlSelectivo.Controls.Add(Me.GroupBox2)
        Me.pnlSelectivo.Location = New System.Drawing.Point(227, 206)
        Me.pnlSelectivo.Name = "pnlSelectivo"
        Me.pnlSelectivo.Size = New System.Drawing.Size(299, 111)
        Me.pnlSelectivo.TabIndex = 32
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.txtFechaSelectivo)
        Me.GroupBox2.Controls.Add(Me.btnGrabarSelectivo)
        Me.GroupBox2.Controls.Add(Me.btnCerrarFechaSelectivo)
        Me.GroupBox2.Location = New System.Drawing.Point(5, 3)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(288, 105)
        Me.GroupBox2.TabIndex = 34
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Asignar a Pago Semanal"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(47, 35)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(84, 13)
        Me.Label7.TabIndex = 34
        Me.Label7.Text = "Confirmar Fecha"
        '
        'txtFechaSelectivo
        '
        Me.txtFechaSelectivo.Location = New System.Drawing.Point(135, 32)
        Me.txtFechaSelectivo.Mask = "00/00/0000"
        Me.txtFechaSelectivo.Name = "txtFechaSelectivo"
        Me.txtFechaSelectivo.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtFechaSelectivo.Size = New System.Drawing.Size(106, 20)
        Me.txtFechaSelectivo.TabIndex = 33
        Me.txtFechaSelectivo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(753, 39)
        Me.Panel1.TabIndex = 29
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.Control
        Me.Label2.Location = New System.Drawing.Point(587, 6)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(156, 26)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "SURFACTAN S.A."
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.Control
        Me.Label1.Location = New System.Drawing.Point(9, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(221, 18)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Cuenta Corrientes de Proveedores"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(95, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(82, Byte), Integer))
        Me.Panel2.Controls.Add(Me.Label11)
        Me.Panel2.Controls.Add(Me.Label12)
        Me.Panel2.Controls.Add(Me.Label10)
        Me.Panel2.Controls.Add(Me.Label9)
        Me.Panel2.Controls.Add(Me.Label8)
        Me.Panel2.Controls.Add(Me.gbSaldoCtaCliente)
        Me.Panel2.Controls.Add(Me.CBProveedorSelectivo)
        Me.Panel2.Controls.Add(Me.lblAceptaTransferencia)
        Me.Panel2.Controls.Add(Me.lblAceptaCheque)
        Me.Panel2.Controls.Add(Me.CustomLabel3)
        Me.Panel2.Controls.Add(Me.txtProveedor)
        Me.Panel2.Controls.Add(Me.txtRazon)
        Me.Panel2.Controls.Add(Me.CustomLabel2)
        Me.Panel2.Controls.Add(Me.opcCompleto)
        Me.Panel2.Controls.Add(Me.txtSaldo)
        Me.Panel2.Controls.Add(Me.opcPendiente)
        Me.Panel2.Location = New System.Drawing.Point(0, 38)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(754, 107)
        Me.Panel2.TabIndex = 30
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.ForeColor = System.Drawing.SystemColors.Control
        Me.Label11.Location = New System.Drawing.Point(490, 84)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(164, 13)
        Me.Label11.TabIndex = 26
        Me.Label11.Text = "Cta Cte Cancelada por OP Virtual"
        Me.Label11.Visible = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.ForeColor = System.Drawing.SystemColors.Control
        Me.Label12.Location = New System.Drawing.Point(423, 84)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(27, 13)
        Me.Label12.TabIndex = 26
        Me.Label12.Text = "Ref:"
        Me.Label12.Visible = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.ForeColor = System.Drawing.SystemColors.Control
        Me.Label10.Location = New System.Drawing.Point(693, 84)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(54, 13)
        Me.Label10.TabIndex = 26
        Me.Label10.Text = "OP Virtual"
        Me.Label10.Visible = False
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.GreenYellow
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label9.ForeColor = System.Drawing.Color.GreenYellow
        Me.Label9.Location = New System.Drawing.Point(456, 82)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(28, 17)
        Me.Label9.TabIndex = 25
        Me.Label9.Text = "   "
        Me.Label9.Visible = False
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.LightBlue
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label8.ForeColor = System.Drawing.Color.LightBlue
        Me.Label8.Location = New System.Drawing.Point(659, 82)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(28, 17)
        Me.Label8.TabIndex = 25
        Me.Label8.Text = "   "
        Me.Label8.Visible = False
        '
        'gbSaldoCtaCliente
        '
        Me.gbSaldoCtaCliente.Controls.Add(Me.lblClienteAsociado)
        Me.gbSaldoCtaCliente.Controls.Add(Me.lblSaldoCuentaProveedor)
        Me.gbSaldoCtaCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbSaldoCtaCliente.ForeColor = System.Drawing.SystemColors.Control
        Me.gbSaldoCtaCliente.Location = New System.Drawing.Point(517, 34)
        Me.gbSaldoCtaCliente.Name = "gbSaldoCtaCliente"
        Me.gbSaldoCtaCliente.Size = New System.Drawing.Size(207, 43)
        Me.gbSaldoCtaCliente.TabIndex = 1
        Me.gbSaldoCtaCliente.TabStop = False
        Me.gbSaldoCtaCliente.Text = "Saldo Cuenta Cliente"
        Me.ToolTip1.SetToolTip(Me.gbSaldoCtaCliente, "Cliente Asociado (Doble Click para abrir Facturas)")
        Me.gbSaldoCtaCliente.Visible = False
        '
        'CBProveedorSelectivo
        '
        Me.CBProveedorSelectivo.AutoSize = True
        Me.CBProveedorSelectivo.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.CBProveedorSelectivo.ForeColor = System.Drawing.SystemColors.Control
        Me.CBProveedorSelectivo.Location = New System.Drawing.Point(517, 5)
        Me.CBProveedorSelectivo.Name = "CBProveedorSelectivo"
        Me.CBProveedorSelectivo.Size = New System.Drawing.Size(217, 22)
        Me.CBProveedorSelectivo.TabIndex = 0
        Me.CBProveedorSelectivo.Text = "Seleccionar para Pago Semanal"
        Me.CBProveedorSelectivo.UseVisualStyleBackColor = True
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
        Me.GroupBox1.Location = New System.Drawing.Point(394, 413)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(320, 105)
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
        'btnGrabarSelectivo
        '
        Me.btnGrabarSelectivo.BackColor = System.Drawing.SystemColors.Control
        Me.btnGrabarSelectivo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnGrabarSelectivo.Cleanable = False
        Me.btnGrabarSelectivo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnGrabarSelectivo.EnterIndex = -1
        Me.btnGrabarSelectivo.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnGrabarSelectivo.FlatAppearance.BorderSize = 0
        Me.btnGrabarSelectivo.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(95, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(82, Byte), Integer))
        Me.btnGrabarSelectivo.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control
        Me.btnGrabarSelectivo.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control
        Me.btnGrabarSelectivo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGrabarSelectivo.LabelAssociationKey = -1
        Me.btnGrabarSelectivo.Location = New System.Drawing.Point(65, 63)
        Me.btnGrabarSelectivo.Name = "btnGrabarSelectivo"
        Me.btnGrabarSelectivo.Size = New System.Drawing.Size(75, 36)
        Me.btnGrabarSelectivo.TabIndex = 32
        Me.btnGrabarSelectivo.UseVisualStyleBackColor = False
        '
        'btnCerrarFechaSelectivo
        '
        Me.btnCerrarFechaSelectivo.BackColor = System.Drawing.SystemColors.Control
        Me.btnCerrarFechaSelectivo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnCerrarFechaSelectivo.Cleanable = False
        Me.btnCerrarFechaSelectivo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCerrarFechaSelectivo.EnterIndex = -1
        Me.btnCerrarFechaSelectivo.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnCerrarFechaSelectivo.FlatAppearance.BorderSize = 0
        Me.btnCerrarFechaSelectivo.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(95, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(82, Byte), Integer))
        Me.btnCerrarFechaSelectivo.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control
        Me.btnCerrarFechaSelectivo.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control
        Me.btnCerrarFechaSelectivo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCerrarFechaSelectivo.LabelAssociationKey = -1
        Me.btnCerrarFechaSelectivo.Location = New System.Drawing.Point(148, 63)
        Me.btnCerrarFechaSelectivo.Name = "btnCerrarFechaSelectivo"
        Me.btnCerrarFechaSelectivo.Size = New System.Drawing.Size(75, 36)
        Me.btnCerrarFechaSelectivo.TabIndex = 32
        Me.ToolTip1.SetToolTip(Me.btnCerrarFechaSelectivo, "Cerrar")
        Me.btnCerrarFechaSelectivo.UseVisualStyleBackColor = False
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
        Me.btnCancela.Location = New System.Drawing.Point(342, 443)
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
        Me.btnConsulta.Location = New System.Drawing.Point(213, 443)
        Me.btnConsulta.Name = "btnConsulta"
        Me.btnConsulta.Size = New System.Drawing.Size(93, 50)
        Me.btnConsulta.TabIndex = 26
        Me.ToolTip1.SetToolTip(Me.btnConsulta, "Abrir Consulta")
        Me.btnConsulta.UseVisualStyleBackColor = False
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
        'lblAceptaTransferencia
        '
        Me.lblAceptaTransferencia.BackColor = System.Drawing.SystemColors.Highlight
        Me.lblAceptaTransferencia.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblAceptaTransferencia.ControlAssociationKey = -1
        Me.lblAceptaTransferencia.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lblAceptaTransferencia.ForeColor = System.Drawing.SystemColors.Control
        Me.lblAceptaTransferencia.Location = New System.Drawing.Point(235, 62)
        Me.lblAceptaTransferencia.Name = "lblAceptaTransferencia"
        Me.lblAceptaTransferencia.Size = New System.Drawing.Size(135, 24)
        Me.lblAceptaTransferencia.TabIndex = 3
        Me.lblAceptaTransferencia.Text = "ACEPTA TRANSF."
        Me.lblAceptaTransferencia.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblAceptaTransferencia.Visible = False
        '
        'lblAceptaCheque
        '
        Me.lblAceptaCheque.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.lblAceptaCheque.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblAceptaCheque.ControlAssociationKey = -1
        Me.lblAceptaCheque.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lblAceptaCheque.ForeColor = System.Drawing.SystemColors.Control
        Me.lblAceptaCheque.Location = New System.Drawing.Point(94, 62)
        Me.lblAceptaCheque.Name = "lblAceptaCheque"
        Me.lblAceptaCheque.Size = New System.Drawing.Size(135, 24)
        Me.lblAceptaCheque.TabIndex = 3
        Me.lblAceptaCheque.Text = "ACEPTA E-CHEQ"
        Me.lblAceptaCheque.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblAceptaCheque.Visible = False
        '
        'CustomLabel3
        '
        Me.CustomLabel3.AutoSize = True
        Me.CustomLabel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(95, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(82, Byte), Integer))
        Me.CustomLabel3.ControlAssociationKey = -1
        Me.CustomLabel3.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.CustomLabel3.ForeColor = System.Drawing.SystemColors.Control
        Me.CustomLabel3.Location = New System.Drawing.Point(21, 7)
        Me.CustomLabel3.Name = "CustomLabel3"
        Me.CustomLabel3.Size = New System.Drawing.Size(73, 18)
        Me.CustomLabel3.TabIndex = 3
        Me.CustomLabel3.Text = "Proveedor"
        '
        'txtProveedor
        '
        Me.txtProveedor.BackColor = System.Drawing.SystemColors.Control
        Me.txtProveedor.Cleanable = False
        Me.txtProveedor.Empty = True
        Me.txtProveedor.EnterIndex = -1
        Me.txtProveedor.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtProveedor.LabelAssociationKey = -1
        Me.txtProveedor.Location = New System.Drawing.Point(94, 6)
        Me.txtProveedor.MaxLength = 11
        Me.txtProveedor.Name = "txtProveedor"
        Me.txtProveedor.Size = New System.Drawing.Size(108, 20)
        Me.txtProveedor.TabIndex = 0
        Me.txtProveedor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.txtProveedor, "Doble Click: Abrir Consulta de Proveedores")
        Me.txtProveedor.Validator = Administracion.ValidatorType.None
        '
        'txtRazon
        '
        Me.txtRazon.BackColor = System.Drawing.Color.Gainsboro
        Me.txtRazon.Cleanable = False
        Me.txtRazon.Empty = True
        Me.txtRazon.EnterIndex = -1
        Me.txtRazon.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRazon.LabelAssociationKey = -1
        Me.txtRazon.Location = New System.Drawing.Point(208, 6)
        Me.txtRazon.Name = "txtRazon"
        Me.txtRazon.ReadOnly = True
        Me.txtRazon.Size = New System.Drawing.Size(298, 20)
        Me.txtRazon.TabIndex = 6
        Me.txtRazon.Validator = Administracion.ValidatorType.None
        '
        'CustomLabel2
        '
        Me.CustomLabel2.AutoSize = True
        Me.CustomLabel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(95, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(82, Byte), Integer))
        Me.CustomLabel2.ControlAssociationKey = -1
        Me.CustomLabel2.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.CustomLabel2.ForeColor = System.Drawing.SystemColors.Control
        Me.CustomLabel2.Location = New System.Drawing.Point(21, 29)
        Me.CustomLabel2.Name = "CustomLabel2"
        Me.CustomLabel2.Size = New System.Drawing.Size(42, 18)
        Me.CustomLabel2.TabIndex = 8
        Me.CustomLabel2.Text = "Saldo"
        '
        'txtSaldo
        '
        Me.txtSaldo.Cleanable = False
        Me.txtSaldo.Empty = True
        Me.txtSaldo.EnterIndex = -1
        Me.txtSaldo.LabelAssociationKey = -1
        Me.txtSaldo.Location = New System.Drawing.Point(94, 28)
        Me.txtSaldo.Name = "txtSaldo"
        Me.txtSaldo.ReadOnly = True
        Me.txtSaldo.Size = New System.Drawing.Size(108, 20)
        Me.txtSaldo.TabIndex = 7
        Me.txtSaldo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtSaldo.Validator = Administracion.ValidatorType.None
        '
        'CuentaCorrientePantalla
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(753, 523)
        Me.Controls.Add(Me.pnlSelectivo)
        Me.Controls.Add(Me.btnLimpiar)
        Me.Controls.Add(Me.btnCancela)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnConsulta)
        Me.Controls.Add(Me.CustomLabel1)
        Me.Controls.Add(Me.GRilla)
        Me.Controls.Add(Me.Panel2)
        Me.Location = New System.Drawing.Point(5, 5)
        Me.MaximizeBox = False
        Me.Name = "CuentaCorrientePantalla"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        CType(Me.GRilla, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlSelectivo.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
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
    Friend WithEvents GRilla As DBDataGridView
    Friend WithEvents CustomLabel3 As Administracion.CustomLabel
    Friend WithEvents txtProveedor As Administracion.CustomTextBox
    Friend WithEvents CustomLabel1 As Administracion.CustomLabel
    Friend WithEvents txtRazon As Administracion.CustomTextBox
    Friend WithEvents txtSaldo As Administracion.CustomTextBox
    Friend WithEvents CustomLabel2 As Administracion.CustomLabel
    Friend WithEvents opcCompleto As System.Windows.Forms.RadioButton
    Friend WithEvents opcPendiente As System.Windows.Forms.RadioButton
    Friend WithEvents btnConsulta As Administracion.CustomButton
    Friend WithEvents btnCancela As Administracion.CustomButton
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents CBProveedorSelectivo As System.Windows.Forms.CheckBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
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
    Friend WithEvents pnlSelectivo As System.Windows.Forms.Panel
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtFechaSelectivo As System.Windows.Forms.MaskedTextBox
    Friend WithEvents btnGrabarSelectivo As Administracion.CustomButton
    Friend WithEvents btnCerrarFechaSelectivo As Administracion.CustomButton
    Friend WithEvents Tipo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Letra As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Punto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Numero As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Fecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Debito As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Credito As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Saldo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Vencimiento As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OrdFecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OrdVencimiento As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Importe As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MarcaVirtual As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Impre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NroInterno As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents lblAceptaCheque As Administracion.CustomLabel
    Friend WithEvents lblAceptaTransferencia As Administracion.CustomLabel
End Class
