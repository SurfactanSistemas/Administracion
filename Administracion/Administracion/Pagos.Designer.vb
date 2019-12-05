<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Pagos
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.optTransferencias = New System.Windows.Forms.RadioButton()
        Me.optAnticipos = New System.Windows.Forms.RadioButton()
        Me.optChequeRechazado = New System.Windows.Forms.RadioButton()
        Me.optVarios = New System.Windows.Forms.RadioButton()
        Me.optCtaCte = New System.Windows.Forms.RadioButton()
        Me.gridPagos = New System.Windows.Forms.DataGridView()
        Me.Tipo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Letra = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Punto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Numero = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Importe = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ImpoNeto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CuentaContable = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MarcaDifCambio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MarcaCHR = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gridFormaPagos = New System.Windows.Forms.DataGridView()
        Me.Tipo2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Numero2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Fecha2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Banco2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Nombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Importe2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.XClave = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.XCuil = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cuenta = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UltTipo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.pnlDifCamXFactura = New System.Windows.Forms.Panel()
        Me.btnVolver = New System.Windows.Forms.Button()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.GridPagosXFacturas = New System.Windows.Forms.DataGridView()
        Me.Check = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.NumeroXFactura = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Tipo3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Letra3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Punto3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Fecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ImportePesos = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Paridad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ImporteDolares = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CustomLabel1 = New Administracion.CustomLabel()
        Me.btnDifCambioXFactura = New System.Windows.Forms.Button()
        Me.ckCalculaDifCambio = New System.Windows.Forms.CheckBox()
        Me.btnActualizarCarpetas = New System.Windows.Forms.Button()
        Me.btnEnviarAviso = New System.Windows.Forms.Button()
        Me.btnEliminarFila = New System.Windows.Forms.Button()
        Me.ckNoCalcRetenciones = New System.Windows.Forms.CheckBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btnDifeCambio = New System.Windows.Forms.Button()
        Me.pnlPedirCuenta = New System.Windows.Forms.Panel()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.WProceso = New System.Windows.Forms.Label()
        Me.txtCuenta = New Administracion.CustomTextBox()
        Me.txtFechaAux = New System.Windows.Forms.MaskedTextBox()
        Me.lstSeleccion = New Administracion.CustomListBox()
        Me.CLBFiltrado = New Administracion.CustomListBox()
        Me.txtFechaParidad = New System.Windows.Forms.MaskedTextBox()
        Me.txtFecha = New System.Windows.Forms.MaskedTextBox()
        Me.CustomLabel12 = New Administracion.CustomLabel()
        Me.CustomLabel13 = New Administracion.CustomLabel()
        Me.lblDiferencia = New Administracion.CustomLabel()
        Me.CustomLabel2 = New Administracion.CustomLabel()
        Me.lblFormaPagos = New Administracion.CustomLabel()
        Me.CustomLabel3 = New Administracion.CustomLabel()
        Me.lblPagos = New Administracion.CustomLabel()
        Me.CustomLabel4 = New Administracion.CustomLabel()
        Me.CustomLabel5 = New Administracion.CustomLabel()
        Me.txtOrdenPago = New Administracion.CustomTextBox()
        Me.txtProveedor = New Administracion.CustomTextBox()
        Me.txtRazonSocial = New Administracion.CustomTextBox()
        Me.txtObservaciones = New Administracion.CustomTextBox()
        Me.txtBanco = New Administracion.CustomTextBox()
        Me.txtNombreBanco = New Administracion.CustomTextBox()
        Me.CustomLabel6 = New Administracion.CustomLabel()
        Me.CustomLabel7 = New Administracion.CustomLabel()
        Me.txtConsulta = New Administracion.CustomTextBox()
        Me.lstConsulta = New Administracion.CustomListBox()
        Me.txtParidad = New Administracion.CustomTextBox()
        Me.txtTotal = New Administracion.CustomTextBox()
        Me.cmbTipo = New Administracion.CustomComboBox()
        Me.CustomLabel15 = New Administracion.CustomLabel()
        Me.CustomLabel16 = New Administracion.CustomLabel()
        Me.CustomLabel14 = New Administracion.CustomLabel()
        Me.CustomLabel11 = New Administracion.CustomLabel()
        Me.lblGanancias = New Administracion.CustomLabel()
        Me.txtIVA = New Administracion.CustomTextBox()
        Me.CustomLabel8 = New Administracion.CustomLabel()
        Me.txtIngresosBrutos = New Administracion.CustomTextBox()
        Me.txtGanancias = New Administracion.CustomTextBox()
        Me.CustomLabel10 = New Administracion.CustomLabel()
        Me.CustomLabel9 = New Administracion.CustomLabel()
        Me.txtIBCiudad = New Administracion.CustomTextBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnCarpetas = New Administracion.CustomButton()
        Me.btnImprimir = New Administracion.CustomButton()
        Me.btnCalcular = New Administracion.CustomButton()
        Me.btnConsulta = New Administracion.CustomButton()
        Me.btnCtaCte = New Administracion.CustomButton()
        Me.btnChequesTerceros = New Administracion.CustomButton()
        Me.btnCerrar = New Administracion.CustomButton()
        Me.btnLimpiar = New Administracion.CustomButton()
        Me.btnAgregar = New Administracion.CustomButton()
        Me.CustomLabel17 = New Administracion.CustomLabel()
        Me.GroupBox1.SuspendLayout()
        CType(Me.gridPagos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridFormaPagos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.pnlDifCamXFactura.SuspendLayout()
        CType(Me.GridPagosXFacturas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlPedirCuenta.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.optTransferencias)
        Me.GroupBox1.Controls.Add(Me.optAnticipos)
        Me.GroupBox1.Controls.Add(Me.optChequeRechazado)
        Me.GroupBox1.Controls.Add(Me.optVarios)
        Me.GroupBox1.Controls.Add(Me.optCtaCte)
        Me.GroupBox1.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.GroupBox1.ForeColor = System.Drawing.SystemColors.Control
        Me.GroupBox1.Location = New System.Drawing.Point(10, 127)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(242, 99)
        Me.GroupBox1.TabIndex = 34
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Tipo de Orden de Pago"
        '
        'optTransferencias
        '
        Me.optTransferencias.AutoSize = True
        Me.optTransferencias.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold)
        Me.optTransferencias.Location = New System.Drawing.Point(139, 47)
        Me.optTransferencias.Name = "optTransferencias"
        Me.optTransferencias.Size = New System.Drawing.Size(96, 18)
        Me.optTransferencias.TabIndex = 4
        Me.optTransferencias.Text = "Transferencias"
        Me.optTransferencias.UseVisualStyleBackColor = True
        '
        'optAnticipos
        '
        Me.optAnticipos.AutoSize = True
        Me.optAnticipos.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold)
        Me.optAnticipos.Location = New System.Drawing.Point(139, 24)
        Me.optAnticipos.Name = "optAnticipos"
        Me.optAnticipos.Size = New System.Drawing.Size(70, 18)
        Me.optAnticipos.TabIndex = 3
        Me.optAnticipos.Text = "Anticipos"
        Me.optAnticipos.UseVisualStyleBackColor = True
        '
        'optChequeRechazado
        '
        Me.optChequeRechazado.AutoSize = True
        Me.optChequeRechazado.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold)
        Me.optChequeRechazado.Location = New System.Drawing.Point(11, 70)
        Me.optChequeRechazado.Name = "optChequeRechazado"
        Me.optChequeRechazado.Size = New System.Drawing.Size(101, 18)
        Me.optChequeRechazado.TabIndex = 2
        Me.optChequeRechazado.Text = "Ch. Rechazados"
        Me.optChequeRechazado.UseVisualStyleBackColor = True
        '
        'optVarios
        '
        Me.optVarios.AutoSize = True
        Me.optVarios.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold)
        Me.optVarios.Location = New System.Drawing.Point(11, 47)
        Me.optVarios.Name = "optVarios"
        Me.optVarios.Size = New System.Drawing.Size(87, 18)
        Me.optVarios.TabIndex = 1
        Me.optVarios.Text = "Pagos Varios"
        Me.optVarios.UseVisualStyleBackColor = True
        '
        'optCtaCte
        '
        Me.optCtaCte.AutoSize = True
        Me.optCtaCte.Checked = True
        Me.optCtaCte.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold)
        Me.optCtaCte.Location = New System.Drawing.Point(11, 24)
        Me.optCtaCte.Name = "optCtaCte"
        Me.optCtaCte.Size = New System.Drawing.Size(98, 18)
        Me.optCtaCte.TabIndex = 0
        Me.optCtaCte.TabStop = True
        Me.optCtaCte.Text = "Pagos Cta. Cte."
        Me.optCtaCte.UseVisualStyleBackColor = True
        '
        'gridPagos
        '
        Me.gridPagos.AllowUserToAddRows = False
        Me.gridPagos.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gridPagos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.gridPagos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.gridPagos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Tipo, Me.Letra, Me.Punto, Me.Numero, Me.Importe, Me.Descripcion, Me.ImpoNeto, Me.CuentaContable, Me.MarcaDifCambio, Me.MarcaCHR})
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gridPagos.DefaultCellStyle = DataGridViewCellStyle6
        Me.gridPagos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.gridPagos.Location = New System.Drawing.Point(4, 236)
        Me.gridPagos.Name = "gridPagos"
        Me.gridPagos.RowHeadersWidth = 25
        Me.gridPagos.Size = New System.Drawing.Size(374, 143)
        Me.gridPagos.TabIndex = 56
        '
        'Tipo
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Tipo.DefaultCellStyle = DataGridViewCellStyle2
        Me.Tipo.HeaderText = "Tipo"
        Me.Tipo.MaxInputLength = 2
        Me.Tipo.Name = "Tipo"
        Me.Tipo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Tipo.Width = 35
        '
        'Letra
        '
        Me.Letra.HeaderText = "Letra"
        Me.Letra.MaxInputLength = 1
        Me.Letra.Name = "Letra"
        Me.Letra.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Letra.Width = 40
        '
        'Punto
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Punto.DefaultCellStyle = DataGridViewCellStyle3
        Me.Punto.HeaderText = "Punto"
        Me.Punto.MaxInputLength = 6
        Me.Punto.Name = "Punto"
        Me.Punto.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Punto.Width = 45
        '
        'Numero
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Numero.DefaultCellStyle = DataGridViewCellStyle4
        Me.Numero.HeaderText = "Número"
        Me.Numero.MaxInputLength = 8
        Me.Numero.Name = "Numero"
        Me.Numero.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Numero.Width = 70
        '
        'Importe
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Importe.DefaultCellStyle = DataGridViewCellStyle5
        Me.Importe.HeaderText = "Importe"
        Me.Importe.Name = "Importe"
        Me.Importe.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Importe.Width = 75
        '
        'Descripcion
        '
        Me.Descripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Descripcion.HeaderText = "Descripción"
        Me.Descripcion.Name = "Descripcion"
        Me.Descripcion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'ImpoNeto
        '
        Me.ImpoNeto.HeaderText = "ImpoNeto"
        Me.ImpoNeto.Name = "ImpoNeto"
        Me.ImpoNeto.ReadOnly = True
        Me.ImpoNeto.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ImpoNeto.Visible = False
        '
        'CuentaContable
        '
        Me.CuentaContable.HeaderText = "CuentaContable"
        Me.CuentaContable.Name = "CuentaContable"
        Me.CuentaContable.Visible = False
        '
        'MarcaDifCambio
        '
        Me.MarcaDifCambio.HeaderText = "MarcaDifCambio"
        Me.MarcaDifCambio.Name = "MarcaDifCambio"
        Me.MarcaDifCambio.Visible = False
        '
        'MarcaCHR
        '
        Me.MarcaCHR.HeaderText = "MarcaCHR"
        Me.MarcaCHR.Name = "MarcaCHR"
        Me.MarcaCHR.Visible = False
        '
        'gridFormaPagos
        '
        Me.gridFormaPagos.AllowUserToAddRows = False
        Me.gridFormaPagos.AllowUserToDeleteRows = False
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gridFormaPagos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.gridFormaPagos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.gridFormaPagos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Tipo2, Me.Numero2, Me.Fecha2, Me.Banco2, Me.Nombre, Me.Importe2, Me.XClave, Me.XCuil, Me.Cuenta, Me.UltTipo})
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gridFormaPagos.DefaultCellStyle = DataGridViewCellStyle13
        Me.gridFormaPagos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.gridFormaPagos.Location = New System.Drawing.Point(379, 236)
        Me.gridFormaPagos.Name = "gridFormaPagos"
        Me.gridFormaPagos.RowHeadersWidth = 25
        Me.gridFormaPagos.Size = New System.Drawing.Size(388, 143)
        Me.gridFormaPagos.TabIndex = 57
        '
        'Tipo2
        '
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle8.Format = "N2"
        DataGridViewCellStyle8.NullValue = Nothing
        Me.Tipo2.DefaultCellStyle = DataGridViewCellStyle8
        Me.Tipo2.HeaderText = "Tipo"
        Me.Tipo2.MaxInputLength = 31
        Me.Tipo2.Name = "Tipo2"
        Me.Tipo2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Tipo2.Width = 35
        '
        'Numero2
        '
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Numero2.DefaultCellStyle = DataGridViewCellStyle9
        Me.Numero2.HeaderText = "Número"
        Me.Numero2.MaxInputLength = 8
        Me.Numero2.Name = "Numero2"
        Me.Numero2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Numero2.Width = 70
        '
        'Fecha2
        '
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Fecha2.DefaultCellStyle = DataGridViewCellStyle10
        Me.Fecha2.HeaderText = "Fecha"
        Me.Fecha2.MaxInputLength = 10
        Me.Fecha2.Name = "Fecha2"
        Me.Fecha2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Fecha2.Width = 75
        '
        'Banco2
        '
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Banco2.DefaultCellStyle = DataGridViewCellStyle11
        Me.Banco2.HeaderText = "Banco"
        Me.Banco2.MaxInputLength = 3
        Me.Banco2.Name = "Banco2"
        Me.Banco2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Banco2.Width = 45
        '
        'Nombre
        '
        Me.Nombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Nombre.HeaderText = "Nombre"
        Me.Nombre.Name = "Nombre"
        Me.Nombre.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Importe2
        '
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Importe2.DefaultCellStyle = DataGridViewCellStyle12
        Me.Importe2.HeaderText = "Importe"
        Me.Importe2.Name = "Importe2"
        Me.Importe2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Importe2.Width = 80
        '
        'XClave
        '
        Me.XClave.HeaderText = "XClave"
        Me.XClave.Name = "XClave"
        Me.XClave.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.XClave.Visible = False
        '
        'XCuil
        '
        Me.XCuil.HeaderText = "XCuil"
        Me.XCuil.Name = "XCuil"
        Me.XCuil.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.XCuil.Visible = False
        '
        'Cuenta
        '
        Me.Cuenta.HeaderText = "Cuenta"
        Me.Cuenta.Name = "Cuenta"
        Me.Cuenta.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Cuenta.Visible = False
        '
        'UltTipo
        '
        Me.UltTipo.HeaderText = "UltTipo"
        Me.UltTipo.Name = "UltTipo"
        Me.UltTipo.Visible = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(95, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(82, Byte), Integer))
        Me.Panel2.Controls.Add(Me.CustomLabel17)
        Me.Panel2.Controls.Add(Me.pnlDifCamXFactura)
        Me.Panel2.Controls.Add(Me.btnDifCambioXFactura)
        Me.Panel2.Controls.Add(Me.ckCalculaDifCambio)
        Me.Panel2.Controls.Add(Me.btnActualizarCarpetas)
        Me.Panel2.Controls.Add(Me.btnEnviarAviso)
        Me.Panel2.Controls.Add(Me.btnEliminarFila)
        Me.Panel2.Controls.Add(Me.ckNoCalcRetenciones)
        Me.Panel2.Controls.Add(Me.Button1)
        Me.Panel2.Controls.Add(Me.btnDifeCambio)
        Me.Panel2.Controls.Add(Me.pnlPedirCuenta)
        Me.Panel2.Controls.Add(Me.txtFechaAux)
        Me.Panel2.Controls.Add(Me.lstSeleccion)
        Me.Panel2.Controls.Add(Me.CLBFiltrado)
        Me.Panel2.Controls.Add(Me.txtFechaParidad)
        Me.Panel2.Controls.Add(Me.txtFecha)
        Me.Panel2.Controls.Add(Me.CustomLabel12)
        Me.Panel2.Controls.Add(Me.CustomLabel13)
        Me.Panel2.Controls.Add(Me.lblDiferencia)
        Me.Panel2.Controls.Add(Me.CustomLabel2)
        Me.Panel2.Controls.Add(Me.lblFormaPagos)
        Me.Panel2.Controls.Add(Me.CustomLabel3)
        Me.Panel2.Controls.Add(Me.lblPagos)
        Me.Panel2.Controls.Add(Me.CustomLabel4)
        Me.Panel2.Controls.Add(Me.CustomLabel5)
        Me.Panel2.Controls.Add(Me.txtOrdenPago)
        Me.Panel2.Controls.Add(Me.txtProveedor)
        Me.Panel2.Controls.Add(Me.txtRazonSocial)
        Me.Panel2.Controls.Add(Me.txtObservaciones)
        Me.Panel2.Controls.Add(Me.txtBanco)
        Me.Panel2.Controls.Add(Me.txtNombreBanco)
        Me.Panel2.Controls.Add(Me.GroupBox1)
        Me.Panel2.Controls.Add(Me.gridFormaPagos)
        Me.Panel2.Controls.Add(Me.CustomLabel6)
        Me.Panel2.Controls.Add(Me.gridPagos)
        Me.Panel2.Controls.Add(Me.CustomLabel7)
        Me.Panel2.Controls.Add(Me.txtConsulta)
        Me.Panel2.Controls.Add(Me.lstConsulta)
        Me.Panel2.Controls.Add(Me.txtParidad)
        Me.Panel2.Controls.Add(Me.txtTotal)
        Me.Panel2.Controls.Add(Me.cmbTipo)
        Me.Panel2.Controls.Add(Me.CustomLabel15)
        Me.Panel2.Controls.Add(Me.CustomLabel16)
        Me.Panel2.Controls.Add(Me.CustomLabel14)
        Me.Panel2.Controls.Add(Me.CustomLabel11)
        Me.Panel2.Controls.Add(Me.lblGanancias)
        Me.Panel2.Controls.Add(Me.txtIVA)
        Me.Panel2.Controls.Add(Me.CustomLabel8)
        Me.Panel2.Controls.Add(Me.txtIngresosBrutos)
        Me.Panel2.Controls.Add(Me.txtGanancias)
        Me.Panel2.Controls.Add(Me.CustomLabel10)
        Me.Panel2.Controls.Add(Me.CustomLabel9)
        Me.Panel2.Controls.Add(Me.txtIBCiudad)
        Me.Panel2.Location = New System.Drawing.Point(-1, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(778, 447)
        Me.Panel2.TabIndex = 73
        '
        'pnlDifCamXFactura
        '
        Me.pnlDifCamXFactura.BackColor = System.Drawing.Color.FromArgb(CType(CType(95, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(82, Byte), Integer))
        Me.pnlDifCamXFactura.Controls.Add(Me.btnVolver)
        Me.pnlDifCamXFactura.Controls.Add(Me.btnAceptar)
        Me.pnlDifCamXFactura.Controls.Add(Me.GridPagosXFacturas)
        Me.pnlDifCamXFactura.Controls.Add(Me.CustomLabel1)
        Me.pnlDifCamXFactura.Location = New System.Drawing.Point(162, 76)
        Me.pnlDifCamXFactura.Name = "pnlDifCamXFactura"
        Me.pnlDifCamXFactura.Size = New System.Drawing.Size(467, 300)
        Me.pnlDifCamXFactura.TabIndex = 131
        '
        'btnVolver
        '
        Me.btnVolver.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnVolver.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnVolver.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnVolver.ForeColor = System.Drawing.SystemColors.Control
        Me.btnVolver.Location = New System.Drawing.Point(247, 257)
        Me.btnVolver.Name = "btnVolver"
        Me.btnVolver.Size = New System.Drawing.Size(76, 37)
        Me.btnVolver.TabIndex = 132
        Me.btnVolver.Text = "Volver"
        Me.ToolTip1.SetToolTip(Me.btnVolver, "Análisis Diferencia de Cambio en Orden de Pago")
        Me.btnVolver.UseVisualStyleBackColor = True
        '
        'btnAceptar
        '
        Me.btnAceptar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.ForeColor = System.Drawing.SystemColors.Control
        Me.btnAceptar.Location = New System.Drawing.Point(123, 256)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(76, 37)
        Me.btnAceptar.TabIndex = 131
        Me.btnAceptar.Text = "Aceptar"
        Me.ToolTip1.SetToolTip(Me.btnAceptar, "Análisis Diferencia de Cambio en Orden de Pago")
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'GridPagosXFacturas
        '
        Me.GridPagosXFacturas.AllowUserToAddRows = False
        Me.GridPagosXFacturas.AllowUserToDeleteRows = False
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GridPagosXFacturas.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle14
        Me.GridPagosXFacturas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.GridPagosXFacturas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Check, Me.NumeroXFactura, Me.Tipo3, Me.Letra3, Me.Punto3, Me.Fecha, Me.ImportePesos, Me.Paridad, Me.ImporteDolares})
        DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GridPagosXFacturas.DefaultCellStyle = DataGridViewCellStyle16
        Me.GridPagosXFacturas.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.GridPagosXFacturas.Location = New System.Drawing.Point(13, 32)
        Me.GridPagosXFacturas.Name = "GridPagosXFacturas"
        Me.GridPagosXFacturas.RowHeadersWidth = 25
        Me.GridPagosXFacturas.Size = New System.Drawing.Size(445, 220)
        Me.GridPagosXFacturas.TabIndex = 57
        '
        'Check
        '
        Me.Check.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.Check.FalseValue = "false"
        Me.Check.HeaderText = "Check"
        Me.Check.Name = "Check"
        Me.Check.TrueValue = "true"
        Me.Check.Width = 44
        '
        'NumeroXFactura
        '
        Me.NumeroXFactura.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.NumeroXFactura.DefaultCellStyle = DataGridViewCellStyle15
        Me.NumeroXFactura.HeaderText = "Número"
        Me.NumeroXFactura.MaxInputLength = 8
        Me.NumeroXFactura.Name = "NumeroXFactura"
        Me.NumeroXFactura.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.NumeroXFactura.Width = 50
        '
        'Tipo3
        '
        Me.Tipo3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Tipo3.HeaderText = "Tipo"
        Me.Tipo3.Name = "Tipo3"
        Me.Tipo3.Width = 53
        '
        'Letra3
        '
        Me.Letra3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Letra3.HeaderText = "Letra"
        Me.Letra3.Name = "Letra3"
        Me.Letra3.Width = 56
        '
        'Punto3
        '
        Me.Punto3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Punto3.HeaderText = "Punto"
        Me.Punto3.Name = "Punto3"
        Me.Punto3.Width = 60
        '
        'Fecha
        '
        Me.Fecha.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Fecha.HeaderText = "Fecha"
        Me.Fecha.Name = "Fecha"
        Me.Fecha.Width = 62
        '
        'ImportePesos
        '
        Me.ImportePesos.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.ImportePesos.HeaderText = "ImportePesos"
        Me.ImportePesos.Name = "ImportePesos"
        Me.ImportePesos.Width = 96
        '
        'Paridad
        '
        Me.Paridad.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Paridad.HeaderText = "Paridad"
        Me.Paridad.Name = "Paridad"
        Me.Paridad.Width = 68
        '
        'ImporteDolares
        '
        Me.ImporteDolares.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.ImporteDolares.HeaderText = "ImporteDorales"
        Me.ImporteDolares.Name = "ImporteDolares"
        Me.ImporteDolares.Width = 103
        '
        'CustomLabel1
        '
        Me.CustomLabel1.AutoSize = True
        Me.CustomLabel1.ControlAssociationKey = 1
        Me.CustomLabel1.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.CustomLabel1.ForeColor = System.Drawing.SystemColors.Control
        Me.CustomLabel1.Location = New System.Drawing.Point(10, 7)
        Me.CustomLabel1.Name = "CustomLabel1"
        Me.CustomLabel1.Size = New System.Drawing.Size(295, 18)
        Me.CustomLabel1.TabIndex = 0
        Me.CustomLabel1.Text = "Seleccione Facturas para Diferencia de Cambio"
        '
        'btnDifCambioXFactura
        '
        Me.btnDifCambioXFactura.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnDifCambioXFactura.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDifCambioXFactura.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDifCambioXFactura.ForeColor = System.Drawing.SystemColors.Control
        Me.btnDifCambioXFactura.Location = New System.Drawing.Point(100, 384)
        Me.btnDifCambioXFactura.Name = "btnDifCambioXFactura"
        Me.btnDifCambioXFactura.Size = New System.Drawing.Size(90, 56)
        Me.btnDifCambioXFactura.TabIndex = 130
        Me.btnDifCambioXFactura.Text = "Diferencia de Cambio por Factura"
        Me.ToolTip1.SetToolTip(Me.btnDifCambioXFactura, "Análisis Diferencia de Cambio en Orden de Pago")
        Me.btnDifCambioXFactura.UseVisualStyleBackColor = True
        '
        'ckCalculaDifCambio
        '
        Me.ckCalculaDifCambio.AutoSize = True
        Me.ckCalculaDifCambio.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckCalculaDifCambio.ForeColor = System.Drawing.SystemColors.Control
        Me.ckCalculaDifCambio.Location = New System.Drawing.Point(260, 210)
        Me.ckCalculaDifCambio.Name = "ckCalculaDifCambio"
        Me.ckCalculaDifCambio.Size = New System.Drawing.Size(146, 16)
        Me.ckCalculaDifCambio.TabIndex = 129
        Me.ckCalculaDifCambio.Text = "CALCULA DIF CAMBIO"
        Me.ckCalculaDifCambio.UseVisualStyleBackColor = True
        '
        'btnActualizarCarpetas
        '
        Me.btnActualizarCarpetas.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnActualizarCarpetas.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnActualizarCarpetas.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnActualizarCarpetas.ForeColor = System.Drawing.SystemColors.Control
        Me.btnActualizarCarpetas.Location = New System.Drawing.Point(465, 122)
        Me.btnActualizarCarpetas.Name = "btnActualizarCarpetas"
        Me.btnActualizarCarpetas.Size = New System.Drawing.Size(149, 23)
        Me.btnActualizarCarpetas.TabIndex = 128
        Me.btnActualizarCarpetas.Text = "ACTUALIZAR CARPETAS"
        Me.btnActualizarCarpetas.UseVisualStyleBackColor = True
        '
        'btnEnviarAviso
        '
        Me.btnEnviarAviso.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnEnviarAviso.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEnviarAviso.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEnviarAviso.ForeColor = System.Drawing.SystemColors.Control
        Me.btnEnviarAviso.Location = New System.Drawing.Point(319, 19)
        Me.btnEnviarAviso.Name = "btnEnviarAviso"
        Me.btnEnviarAviso.Size = New System.Drawing.Size(133, 23)
        Me.btnEnviarAviso.TabIndex = 128
        Me.btnEnviarAviso.Text = "ENVIAR AVISO"
        Me.btnEnviarAviso.UseVisualStyleBackColor = True
        '
        'btnEliminarFila
        '
        Me.btnEliminarFila.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnEliminarFila.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEliminarFila.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEliminarFila.ForeColor = System.Drawing.SystemColors.Control
        Me.btnEliminarFila.Location = New System.Drawing.Point(223, 412)
        Me.btnEliminarFila.Name = "btnEliminarFila"
        Me.btnEliminarFila.Size = New System.Drawing.Size(148, 23)
        Me.btnEliminarFila.TabIndex = 128
        Me.btnEliminarFila.Text = "Limpiar Fila"
        Me.ToolTip1.SetToolTip(Me.btnEliminarFila, "Análisis Diferencia de Cambio en Orden de Pago")
        Me.btnEliminarFila.UseVisualStyleBackColor = True
        '
        'ckNoCalcRetenciones
        '
        Me.ckNoCalcRetenciones.AutoSize = True
        Me.ckNoCalcRetenciones.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckNoCalcRetenciones.ForeColor = System.Drawing.SystemColors.Control
        Me.ckNoCalcRetenciones.Location = New System.Drawing.Point(412, 209)
        Me.ckNoCalcRetenciones.Name = "ckNoCalcRetenciones"
        Me.ckNoCalcRetenciones.Size = New System.Drawing.Size(159, 17)
        Me.ckNoCalcRetenciones.TabIndex = 127
        Me.ckNoCalcRetenciones.Text = "No Calcula Retenciones"
        Me.ckNoCalcRetenciones.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.SystemColors.Control
        Me.Button1.Location = New System.Drawing.Point(517, 206)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(27, 25)
        Me.Button1.TabIndex = 126
        Me.Button1.Text = "Recalcular Retenciones"
        Me.Button1.UseVisualStyleBackColor = True
        Me.Button1.Visible = False
        '
        'btnDifeCambio
        '
        Me.btnDifeCambio.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnDifeCambio.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDifeCambio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDifeCambio.ForeColor = System.Drawing.SystemColors.Control
        Me.btnDifeCambio.Location = New System.Drawing.Point(4, 384)
        Me.btnDifeCambio.Name = "btnDifeCambio"
        Me.btnDifeCambio.Size = New System.Drawing.Size(90, 56)
        Me.btnDifeCambio.TabIndex = 126
        Me.btnDifeCambio.Text = "Diferencia de Cambio"
        Me.ToolTip1.SetToolTip(Me.btnDifeCambio, "Análisis Diferencia de Cambio en Orden de Pago")
        Me.btnDifeCambio.UseVisualStyleBackColor = True
        '
        'pnlPedirCuenta
        '
        Me.pnlPedirCuenta.Controls.Add(Me.GroupBox2)
        Me.pnlPedirCuenta.Location = New System.Drawing.Point(272, 281)
        Me.pnlPedirCuenta.Name = "pnlPedirCuenta"
        Me.pnlPedirCuenta.Size = New System.Drawing.Size(217, 76)
        Me.pnlPedirCuenta.TabIndex = 125
        Me.pnlPedirCuenta.Visible = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.WProceso)
        Me.GroupBox2.Controls.Add(Me.txtCuenta)
        Me.GroupBox2.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.GroupBox2.ForeColor = System.Drawing.SystemColors.Control
        Me.GroupBox2.Location = New System.Drawing.Point(15, 3)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(187, 64)
        Me.GroupBox2.TabIndex = 7
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Cuenta"
        '
        'WProceso
        '
        Me.WProceso.AutoSize = True
        Me.WProceso.Location = New System.Drawing.Point(139, 43)
        Me.WProceso.Name = "WProceso"
        Me.WProceso.Size = New System.Drawing.Size(0, 18)
        Me.WProceso.TabIndex = 7
        Me.WProceso.Visible = False
        '
        'txtCuenta
        '
        Me.txtCuenta.Cleanable = True
        Me.txtCuenta.Empty = True
        Me.txtCuenta.EnterIndex = 1
        Me.txtCuenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtCuenta.LabelAssociationKey = 1
        Me.txtCuenta.Location = New System.Drawing.Point(46, 27)
        Me.txtCuenta.MaxLength = 6
        Me.txtCuenta.Name = "txtCuenta"
        Me.txtCuenta.Size = New System.Drawing.Size(94, 20)
        Me.txtCuenta.TabIndex = 6
        Me.txtCuenta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtCuenta.Validator = Administracion.ValidatorType.Numeric
        '
        'txtFechaAux
        '
        Me.txtFechaAux.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtFechaAux.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtFechaAux.Location = New System.Drawing.Point(530, 261)
        Me.txtFechaAux.Margin = New System.Windows.Forms.Padding(0)
        Me.txtFechaAux.Mask = "00/00/0000"
        Me.txtFechaAux.MaximumSize = New System.Drawing.Size(60, 15)
        Me.txtFechaAux.MinimumSize = New System.Drawing.Size(60, 15)
        Me.txtFechaAux.Name = "txtFechaAux"
        Me.txtFechaAux.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtFechaAux.Size = New System.Drawing.Size(60, 13)
        Me.txtFechaAux.TabIndex = 124
        Me.txtFechaAux.ValidatingType = GetType(Date)
        Me.txtFechaAux.Visible = False
        '
        'lstSeleccion
        '
        Me.lstSeleccion.Cleanable = False
        Me.lstSeleccion.EnterIndex = -1
        Me.lstSeleccion.FormattingEnabled = True
        Me.lstSeleccion.Items.AddRange(New Object() {"Proveedores", "Cuentas Corrientes", "Cheques Terceros", "Documentos", "Cuentas Contables"})
        Me.lstSeleccion.LabelAssociationKey = -1
        Me.lstSeleccion.Location = New System.Drawing.Point(465, 14)
        Me.lstSeleccion.Name = "lstSeleccion"
        Me.lstSeleccion.Size = New System.Drawing.Size(302, 134)
        Me.lstSeleccion.TabIndex = 66
        Me.lstSeleccion.Visible = False
        '
        'CLBFiltrado
        '
        Me.CLBFiltrado.Cleanable = True
        Me.CLBFiltrado.EnterIndex = -1
        Me.CLBFiltrado.FormattingEnabled = True
        Me.CLBFiltrado.LabelAssociationKey = -1
        Me.CLBFiltrado.Location = New System.Drawing.Point(465, 38)
        Me.CLBFiltrado.Name = "CLBFiltrado"
        Me.CLBFiltrado.Size = New System.Drawing.Size(302, 108)
        Me.CLBFiltrado.TabIndex = 73
        Me.CLBFiltrado.Visible = False
        '
        'txtFechaParidad
        '
        Me.txtFechaParidad.Location = New System.Drawing.Point(372, 126)
        Me.txtFechaParidad.Mask = "00/00/0000"
        Me.txtFechaParidad.Name = "txtFechaParidad"
        Me.txtFechaParidad.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtFechaParidad.Size = New System.Drawing.Size(79, 20)
        Me.txtFechaParidad.TabIndex = 72
        Me.txtFechaParidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtFecha
        '
        Me.txtFecha.Location = New System.Drawing.Point(243, 20)
        Me.txtFecha.Mask = "00/00/0000"
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtFecha.Size = New System.Drawing.Size(70, 20)
        Me.txtFecha.TabIndex = 72
        Me.txtFecha.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'CustomLabel12
        '
        Me.CustomLabel12.AutoSize = True
        Me.CustomLabel12.ControlAssociationKey = 13
        Me.CustomLabel12.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.CustomLabel12.ForeColor = System.Drawing.SystemColors.Control
        Me.CustomLabel12.Location = New System.Drawing.Point(277, 183)
        Me.CustomLabel12.Name = "CustomLabel12"
        Me.CustomLabel12.Size = New System.Drawing.Size(35, 18)
        Me.CustomLabel12.TabIndex = 67
        Me.CustomLabel12.Text = "Tipo"
        Me.CustomLabel12.Visible = False
        '
        'CustomLabel13
        '
        Me.CustomLabel13.BackColor = System.Drawing.SystemColors.Control
        Me.CustomLabel13.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.CustomLabel13.ControlAssociationKey = -1
        Me.CustomLabel13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CustomLabel13.Location = New System.Drawing.Point(379, 411)
        Me.CustomLabel13.Name = "CustomLabel13"
        Me.CustomLabel13.Size = New System.Drawing.Size(388, 22)
        Me.CustomLabel13.TabIndex = 71
        Me.CustomLabel13.Text = "Tipo de Doc.:   1) Ef.   2) Bco.   3) Ch. Terceros   5) US$   6) Varios"
        Me.CustomLabel13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblDiferencia
        '
        Me.lblDiferencia.BackColor = System.Drawing.SystemColors.Control
        Me.lblDiferencia.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDiferencia.ControlAssociationKey = -1
        Me.lblDiferencia.Location = New System.Drawing.Point(491, 384)
        Me.lblDiferencia.Name = "lblDiferencia"
        Me.lblDiferencia.Size = New System.Drawing.Size(93, 22)
        Me.lblDiferencia.TabIndex = 70
        Me.lblDiferencia.Text = "0,00"
        Me.lblDiferencia.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CustomLabel2
        '
        Me.CustomLabel2.AutoSize = True
        Me.CustomLabel2.ControlAssociationKey = 2
        Me.CustomLabel2.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.CustomLabel2.ForeColor = System.Drawing.SystemColors.Control
        Me.CustomLabel2.Location = New System.Drawing.Point(193, 21)
        Me.CustomLabel2.Name = "CustomLabel2"
        Me.CustomLabel2.Size = New System.Drawing.Size(44, 18)
        Me.CustomLabel2.TabIndex = 1
        Me.CustomLabel2.Text = "Fecha"
        '
        'lblFormaPagos
        '
        Me.lblFormaPagos.BackColor = System.Drawing.SystemColors.Control
        Me.lblFormaPagos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFormaPagos.ControlAssociationKey = -1
        Me.lblFormaPagos.Location = New System.Drawing.Point(673, 384)
        Me.lblFormaPagos.Name = "lblFormaPagos"
        Me.lblFormaPagos.Size = New System.Drawing.Size(93, 22)
        Me.lblFormaPagos.TabIndex = 69
        Me.lblFormaPagos.Text = "0,00"
        Me.lblFormaPagos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CustomLabel3
        '
        Me.CustomLabel3.AutoSize = True
        Me.CustomLabel3.ControlAssociationKey = 3
        Me.CustomLabel3.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.CustomLabel3.ForeColor = System.Drawing.SystemColors.Control
        Me.CustomLabel3.Location = New System.Drawing.Point(36, 49)
        Me.CustomLabel3.Name = "CustomLabel3"
        Me.CustomLabel3.Size = New System.Drawing.Size(73, 18)
        Me.CustomLabel3.TabIndex = 2
        Me.CustomLabel3.Text = "Proveedor"
        '
        'lblPagos
        '
        Me.lblPagos.BackColor = System.Drawing.SystemColors.Control
        Me.lblPagos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblPagos.ControlAssociationKey = -1
        Me.lblPagos.Location = New System.Drawing.Point(273, 384)
        Me.lblPagos.Name = "lblPagos"
        Me.lblPagos.Size = New System.Drawing.Size(104, 22)
        Me.lblPagos.TabIndex = 68
        Me.lblPagos.Text = "0,00"
        Me.lblPagos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CustomLabel4
        '
        Me.CustomLabel4.AutoSize = True
        Me.CustomLabel4.ControlAssociationKey = 4
        Me.CustomLabel4.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.CustomLabel4.ForeColor = System.Drawing.SystemColors.Control
        Me.CustomLabel4.Location = New System.Drawing.Point(10, 76)
        Me.CustomLabel4.Name = "CustomLabel4"
        Me.CustomLabel4.Size = New System.Drawing.Size(99, 18)
        Me.CustomLabel4.TabIndex = 3
        Me.CustomLabel4.Text = "Observaciones"
        '
        'CustomLabel5
        '
        Me.CustomLabel5.AutoSize = True
        Me.CustomLabel5.ControlAssociationKey = 5
        Me.CustomLabel5.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.CustomLabel5.ForeColor = System.Drawing.SystemColors.Control
        Me.CustomLabel5.Location = New System.Drawing.Point(64, 103)
        Me.CustomLabel5.Name = "CustomLabel5"
        Me.CustomLabel5.Size = New System.Drawing.Size(45, 18)
        Me.CustomLabel5.TabIndex = 4
        Me.CustomLabel5.Text = "Banco"
        '
        'txtOrdenPago
        '
        Me.txtOrdenPago.Cleanable = True
        Me.txtOrdenPago.Empty = True
        Me.txtOrdenPago.EnterIndex = 1
        Me.txtOrdenPago.LabelAssociationKey = 1
        Me.txtOrdenPago.Location = New System.Drawing.Point(112, 20)
        Me.txtOrdenPago.MaxLength = 6
        Me.txtOrdenPago.Name = "txtOrdenPago"
        Me.txtOrdenPago.Size = New System.Drawing.Size(75, 20)
        Me.txtOrdenPago.TabIndex = 5
        Me.txtOrdenPago.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtOrdenPago.Validator = Administracion.ValidatorType.Numeric
        '
        'txtProveedor
        '
        Me.txtProveedor.Cleanable = True
        Me.txtProveedor.Empty = False
        Me.txtProveedor.EnterIndex = 3
        Me.txtProveedor.LabelAssociationKey = 3
        Me.txtProveedor.Location = New System.Drawing.Point(112, 46)
        Me.txtProveedor.MaxLength = 11
        Me.txtProveedor.Name = "txtProveedor"
        Me.txtProveedor.Size = New System.Drawing.Size(95, 20)
        Me.txtProveedor.TabIndex = 29
        Me.txtProveedor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.txtProveedor, "Doble Click para abrir listado de Proveedores")
        Me.txtProveedor.Validator = Administracion.ValidatorType.None
        '
        'txtRazonSocial
        '
        Me.txtRazonSocial.Cleanable = True
        Me.txtRazonSocial.Empty = False
        Me.txtRazonSocial.EnterIndex = -1
        Me.txtRazonSocial.LabelAssociationKey = 3
        Me.txtRazonSocial.Location = New System.Drawing.Point(213, 46)
        Me.txtRazonSocial.Name = "txtRazonSocial"
        Me.txtRazonSocial.ReadOnly = True
        Me.txtRazonSocial.Size = New System.Drawing.Size(240, 20)
        Me.txtRazonSocial.TabIndex = 30
        Me.txtRazonSocial.Validator = Administracion.ValidatorType.None
        '
        'txtObservaciones
        '
        Me.txtObservaciones.Cleanable = True
        Me.txtObservaciones.Empty = True
        Me.txtObservaciones.EnterIndex = 4
        Me.txtObservaciones.LabelAssociationKey = 4
        Me.txtObservaciones.Location = New System.Drawing.Point(112, 73)
        Me.txtObservaciones.MaxLength = 100
        Me.txtObservaciones.Name = "txtObservaciones"
        Me.txtObservaciones.Size = New System.Drawing.Size(341, 20)
        Me.txtObservaciones.TabIndex = 31
        Me.txtObservaciones.Validator = Administracion.ValidatorType.None
        '
        'txtBanco
        '
        Me.txtBanco.Cleanable = True
        Me.txtBanco.Empty = True
        Me.txtBanco.EnterIndex = 5
        Me.txtBanco.LabelAssociationKey = 5
        Me.txtBanco.Location = New System.Drawing.Point(112, 100)
        Me.txtBanco.MaxLength = 8
        Me.txtBanco.Name = "txtBanco"
        Me.txtBanco.Size = New System.Drawing.Size(95, 20)
        Me.txtBanco.TabIndex = 32
        Me.txtBanco.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.txtBanco, "Doble Click: Abrir Consulta de Cuentas Contables")
        Me.txtBanco.Validator = Administracion.ValidatorType.Numeric
        '
        'txtNombreBanco
        '
        Me.txtNombreBanco.Cleanable = True
        Me.txtNombreBanco.Empty = True
        Me.txtNombreBanco.Enabled = False
        Me.txtNombreBanco.EnterIndex = -1
        Me.txtNombreBanco.LabelAssociationKey = 5
        Me.txtNombreBanco.Location = New System.Drawing.Point(213, 100)
        Me.txtNombreBanco.Name = "txtNombreBanco"
        Me.txtNombreBanco.ReadOnly = True
        Me.txtNombreBanco.Size = New System.Drawing.Size(240, 20)
        Me.txtNombreBanco.TabIndex = 33
        Me.txtNombreBanco.Validator = Administracion.ValidatorType.None
        '
        'CustomLabel6
        '
        Me.CustomLabel6.AutoSize = True
        Me.CustomLabel6.ControlAssociationKey = 6
        Me.CustomLabel6.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.CustomLabel6.ForeColor = System.Drawing.SystemColors.Control
        Me.CustomLabel6.Location = New System.Drawing.Point(272, 127)
        Me.CustomLabel6.Name = "CustomLabel6"
        Me.CustomLabel6.Size = New System.Drawing.Size(94, 18)
        Me.CustomLabel6.TabIndex = 35
        Me.CustomLabel6.Text = "Fecha Paridad"
        '
        'CustomLabel7
        '
        Me.CustomLabel7.AutoSize = True
        Me.CustomLabel7.ControlAssociationKey = 7
        Me.CustomLabel7.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.CustomLabel7.ForeColor = System.Drawing.SystemColors.Control
        Me.CustomLabel7.Location = New System.Drawing.Point(257, 156)
        Me.CustomLabel7.Name = "CustomLabel7"
        Me.CustomLabel7.Size = New System.Drawing.Size(55, 18)
        Me.CustomLabel7.TabIndex = 36
        Me.CustomLabel7.Text = "Paridad"
        '
        'txtConsulta
        '
        Me.txtConsulta.Cleanable = False
        Me.txtConsulta.Empty = True
        Me.txtConsulta.EnterIndex = -1
        Me.txtConsulta.LabelAssociationKey = -1
        Me.txtConsulta.Location = New System.Drawing.Point(465, 14)
        Me.txtConsulta.Name = "txtConsulta"
        Me.txtConsulta.Size = New System.Drawing.Size(300, 20)
        Me.txtConsulta.TabIndex = 55
        Me.txtConsulta.Validator = Administracion.ValidatorType.None
        Me.txtConsulta.Visible = False
        '
        'lstConsulta
        '
        Me.lstConsulta.Cleanable = False
        Me.lstConsulta.EnterIndex = -1
        Me.lstConsulta.FormattingEnabled = True
        Me.lstConsulta.LabelAssociationKey = -1
        Me.lstConsulta.Location = New System.Drawing.Point(464, 38)
        Me.lstConsulta.Name = "lstConsulta"
        Me.lstConsulta.Size = New System.Drawing.Size(303, 108)
        Me.lstConsulta.TabIndex = 54
        Me.lstConsulta.Visible = False
        '
        'txtParidad
        '
        Me.txtParidad.Cleanable = True
        Me.txtParidad.Empty = True
        Me.txtParidad.EnterIndex = 7
        Me.txtParidad.LabelAssociationKey = 7
        Me.txtParidad.Location = New System.Drawing.Point(315, 155)
        Me.txtParidad.Name = "txtParidad"
        Me.txtParidad.ReadOnly = True
        Me.txtParidad.Size = New System.Drawing.Size(81, 20)
        Me.txtParidad.TabIndex = 38
        Me.txtParidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtParidad.Validator = Administracion.ValidatorType.StrictlyPositiveFloat
        '
        'txtTotal
        '
        Me.txtTotal.Cleanable = True
        Me.txtTotal.Empty = False
        Me.txtTotal.EnterIndex = -1
        Me.txtTotal.LabelAssociationKey = 12
        Me.txtTotal.Location = New System.Drawing.Point(674, 210)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.ReadOnly = True
        Me.txtTotal.Size = New System.Drawing.Size(91, 20)
        Me.txtTotal.TabIndex = 53
        Me.txtTotal.Text = "0.00"
        Me.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtTotal.Validator = Administracion.ValidatorType.Float
        '
        'cmbTipo
        '
        Me.cmbTipo.Cleanable = True
        Me.cmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipo.Empty = True
        Me.cmbTipo.EnterIndex = -1
        Me.cmbTipo.FormattingEnabled = True
        Me.cmbTipo.Items.AddRange(New Object() {"Normal", "Cheque Rechazado"})
        Me.cmbTipo.LabelAssociationKey = 13
        Me.cmbTipo.Location = New System.Drawing.Point(315, 179)
        Me.cmbTipo.Name = "cmbTipo"
        Me.cmbTipo.Size = New System.Drawing.Size(81, 21)
        Me.cmbTipo.TabIndex = 39
        Me.cmbTipo.Validator = Administracion.ValidatorType.None
        Me.cmbTipo.Visible = False
        '
        'CustomLabel15
        '
        Me.CustomLabel15.AutoSize = True
        Me.CustomLabel15.ControlAssociationKey = 12
        Me.CustomLabel15.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CustomLabel15.ForeColor = System.Drawing.SystemColors.Control
        Me.CustomLabel15.Location = New System.Drawing.Point(425, 388)
        Me.CustomLabel15.Name = "CustomLabel15"
        Me.CustomLabel15.Size = New System.Drawing.Size(62, 15)
        Me.CustomLabel15.TabIndex = 52
        Me.CustomLabel15.Text = "Diferencia"
        '
        'CustomLabel16
        '
        Me.CustomLabel16.AutoSize = True
        Me.CustomLabel16.ControlAssociationKey = 12
        Me.CustomLabel16.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CustomLabel16.ForeColor = System.Drawing.SystemColors.Control
        Me.CustomLabel16.Location = New System.Drawing.Point(193, 388)
        Me.CustomLabel16.Name = "CustomLabel16"
        Me.CustomLabel16.Size = New System.Drawing.Size(78, 15)
        Me.CustomLabel16.TabIndex = 52
        Me.CustomLabel16.Text = "Total Debitos"
        '
        'CustomLabel14
        '
        Me.CustomLabel14.AutoSize = True
        Me.CustomLabel14.ControlAssociationKey = 12
        Me.CustomLabel14.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CustomLabel14.ForeColor = System.Drawing.SystemColors.Control
        Me.CustomLabel14.Location = New System.Drawing.Point(590, 388)
        Me.CustomLabel14.Name = "CustomLabel14"
        Me.CustomLabel14.Size = New System.Drawing.Size(82, 15)
        Me.CustomLabel14.TabIndex = 52
        Me.CustomLabel14.Text = "Total Creditos"
        '
        'CustomLabel11
        '
        Me.CustomLabel11.AutoSize = True
        Me.CustomLabel11.ControlAssociationKey = 12
        Me.CustomLabel11.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold)
        Me.CustomLabel11.ForeColor = System.Drawing.SystemColors.Control
        Me.CustomLabel11.Location = New System.Drawing.Point(577, 212)
        Me.CustomLabel11.Name = "CustomLabel11"
        Me.CustomLabel11.Size = New System.Drawing.Size(94, 14)
        Me.CustomLabel11.TabIndex = 52
        Me.CustomLabel11.Text = "Total Retenciones"
        '
        'lblGanancias
        '
        Me.lblGanancias.AutoSize = True
        Me.lblGanancias.ControlAssociationKey = 8
        Me.lblGanancias.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.lblGanancias.ForeColor = System.Drawing.SystemColors.Control
        Me.lblGanancias.Location = New System.Drawing.Point(401, 156)
        Me.lblGanancias.Name = "lblGanancias"
        Me.lblGanancias.Size = New System.Drawing.Size(93, 18)
        Me.lblGanancias.TabIndex = 40
        Me.lblGanancias.Text = "Ret. Ganancia"
        '
        'txtIVA
        '
        Me.txtIVA.Cleanable = True
        Me.txtIVA.Empty = False
        Me.txtIVA.EnterIndex = -1
        Me.txtIVA.LabelAssociationKey = 11
        Me.txtIVA.Location = New System.Drawing.Point(674, 182)
        Me.txtIVA.Name = "txtIVA"
        Me.txtIVA.ReadOnly = True
        Me.txtIVA.Size = New System.Drawing.Size(91, 20)
        Me.txtIVA.TabIndex = 51
        Me.txtIVA.Text = "0,00"
        Me.txtIVA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtIVA.Validator = Administracion.ValidatorType.Float
        '
        'CustomLabel8
        '
        Me.CustomLabel8.AutoSize = True
        Me.CustomLabel8.ControlAssociationKey = 9
        Me.CustomLabel8.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.CustomLabel8.ForeColor = System.Drawing.SystemColors.Control
        Me.CustomLabel8.Location = New System.Drawing.Point(588, 156)
        Me.CustomLabel8.Name = "CustomLabel8"
        Me.CustomLabel8.Size = New System.Drawing.Size(84, 18)
        Me.CustomLabel8.TabIndex = 41
        Me.CustomLabel8.Text = "Ret. I.Brutos"
        '
        'txtIngresosBrutos
        '
        Me.txtIngresosBrutos.Cleanable = True
        Me.txtIngresosBrutos.Empty = False
        Me.txtIngresosBrutos.EnterIndex = -1
        Me.txtIngresosBrutos.LabelAssociationKey = 9
        Me.txtIngresosBrutos.Location = New System.Drawing.Point(674, 155)
        Me.txtIngresosBrutos.Name = "txtIngresosBrutos"
        Me.txtIngresosBrutos.ReadOnly = True
        Me.txtIngresosBrutos.Size = New System.Drawing.Size(91, 20)
        Me.txtIngresosBrutos.TabIndex = 50
        Me.txtIngresosBrutos.Text = "0,00"
        Me.txtIngresosBrutos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtIngresosBrutos.Validator = Administracion.ValidatorType.Float
        '
        'txtGanancias
        '
        Me.txtGanancias.Cleanable = True
        Me.txtGanancias.Empty = False
        Me.txtGanancias.EnterIndex = -1
        Me.txtGanancias.LabelAssociationKey = 8
        Me.txtGanancias.Location = New System.Drawing.Point(495, 155)
        Me.txtGanancias.Name = "txtGanancias"
        Me.txtGanancias.ReadOnly = True
        Me.txtGanancias.Size = New System.Drawing.Size(87, 20)
        Me.txtGanancias.TabIndex = 46
        Me.txtGanancias.Text = "0,00"
        Me.txtGanancias.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtGanancias.Validator = Administracion.ValidatorType.Float
        '
        'CustomLabel10
        '
        Me.CustomLabel10.AutoSize = True
        Me.CustomLabel10.ControlAssociationKey = 11
        Me.CustomLabel10.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.CustomLabel10.ForeColor = System.Drawing.SystemColors.Control
        Me.CustomLabel10.Location = New System.Drawing.Point(604, 183)
        Me.CustomLabel10.Name = "CustomLabel10"
        Me.CustomLabel10.Size = New System.Drawing.Size(68, 18)
        Me.CustomLabel10.TabIndex = 49
        Me.CustomLabel10.Text = "Ret. I.V.A."
        '
        'CustomLabel9
        '
        Me.CustomLabel9.AutoSize = True
        Me.CustomLabel9.ControlAssociationKey = 10
        Me.CustomLabel9.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.CustomLabel9.ForeColor = System.Drawing.SystemColors.Control
        Me.CustomLabel9.Location = New System.Drawing.Point(400, 183)
        Me.CustomLabel9.Name = "CustomLabel9"
        Me.CustomLabel9.Size = New System.Drawing.Size(94, 18)
        Me.CustomLabel9.TabIndex = 47
        Me.CustomLabel9.Text = "Ret. IB Ciudad"
        '
        'txtIBCiudad
        '
        Me.txtIBCiudad.Cleanable = True
        Me.txtIBCiudad.Empty = False
        Me.txtIBCiudad.EnterIndex = -1
        Me.txtIBCiudad.LabelAssociationKey = 10
        Me.txtIBCiudad.Location = New System.Drawing.Point(495, 180)
        Me.txtIBCiudad.Name = "txtIBCiudad"
        Me.txtIBCiudad.ReadOnly = True
        Me.txtIBCiudad.Size = New System.Drawing.Size(87, 20)
        Me.txtIBCiudad.TabIndex = 48
        Me.txtIBCiudad.Text = "0,00"
        Me.txtIBCiudad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtIBCiudad.Validator = Administracion.ValidatorType.Float
        '
        'btnCarpetas
        '
        Me.btnCarpetas.BackgroundImage = Global.Administracion.My.Resources.Resources.Folder
        Me.btnCarpetas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnCarpetas.Cleanable = False
        Me.btnCarpetas.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCarpetas.EnterIndex = -1
        Me.btnCarpetas.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnCarpetas.FlatAppearance.BorderSize = 0
        Me.btnCarpetas.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.Control
        Me.btnCarpetas.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control
        Me.btnCarpetas.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control
        Me.btnCarpetas.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCarpetas.LabelAssociationKey = -1
        Me.btnCarpetas.Location = New System.Drawing.Point(353, 452)
        Me.btnCarpetas.Name = "btnCarpetas"
        Me.btnCarpetas.Size = New System.Drawing.Size(50, 54)
        Me.btnCarpetas.TabIndex = 80
        Me.ToolTip1.SetToolTip(Me.btnCarpetas, "Carpetas")
        Me.btnCarpetas.UseVisualStyleBackColor = True
        '
        'btnImprimir
        '
        Me.btnImprimir.BackgroundImage = Global.Administracion.My.Resources.Resources.imprimir
        Me.btnImprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnImprimir.Cleanable = False
        Me.btnImprimir.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnImprimir.EnterIndex = -1
        Me.btnImprimir.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnImprimir.FlatAppearance.BorderSize = 0
        Me.btnImprimir.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.Control
        Me.btnImprimir.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control
        Me.btnImprimir.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control
        Me.btnImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnImprimir.LabelAssociationKey = -1
        Me.btnImprimir.Location = New System.Drawing.Point(268, 452)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(50, 54)
        Me.btnImprimir.TabIndex = 79
        Me.ToolTip1.SetToolTip(Me.btnImprimir, "Imprimir Orden de Pago")
        Me.btnImprimir.UseVisualStyleBackColor = True
        '
        'btnCalcular
        '
        Me.btnCalcular.BackgroundImage = Global.Administracion.My.Resources.Resources.calculadora
        Me.btnCalcular.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnCalcular.Cleanable = False
        Me.btnCalcular.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCalcular.EnterIndex = -1
        Me.btnCalcular.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnCalcular.FlatAppearance.BorderSize = 0
        Me.btnCalcular.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.Control
        Me.btnCalcular.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control
        Me.btnCalcular.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control
        Me.btnCalcular.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCalcular.LabelAssociationKey = -1
        Me.btnCalcular.Location = New System.Drawing.Point(438, 452)
        Me.btnCalcular.Name = "btnCalcular"
        Me.btnCalcular.Size = New System.Drawing.Size(50, 54)
        Me.btnCalcular.TabIndex = 78
        Me.ToolTip1.SetToolTip(Me.btnCalcular, "Calcular")
        Me.btnCalcular.UseVisualStyleBackColor = True
        '
        'btnConsulta
        '
        Me.btnConsulta.BackgroundImage = Global.Administracion.My.Resources.Resources.Consulta_Dat_N1
        Me.btnConsulta.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnConsulta.Cleanable = False
        Me.btnConsulta.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnConsulta.EnterIndex = -1
        Me.btnConsulta.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnConsulta.FlatAppearance.BorderSize = 0
        Me.btnConsulta.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.Control
        Me.btnConsulta.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control
        Me.btnConsulta.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control
        Me.btnConsulta.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnConsulta.LabelAssociationKey = -1
        Me.btnConsulta.Location = New System.Drawing.Point(124, 452)
        Me.btnConsulta.Name = "btnConsulta"
        Me.btnConsulta.Size = New System.Drawing.Size(50, 54)
        Me.btnConsulta.TabIndex = 77
        Me.ToolTip1.SetToolTip(Me.btnConsulta, "Abrir Consultas")
        Me.btnConsulta.UseVisualStyleBackColor = True
        '
        'btnCtaCte
        '
        Me.btnCtaCte.BackgroundImage = Global.Administracion.My.Resources.Resources.bank
        Me.btnCtaCte.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnCtaCte.Cleanable = False
        Me.btnCtaCte.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCtaCte.EnterIndex = -1
        Me.btnCtaCte.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnCtaCte.FlatAppearance.BorderSize = 0
        Me.btnCtaCte.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.Control
        Me.btnCtaCte.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control
        Me.btnCtaCte.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control
        Me.btnCtaCte.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCtaCte.LabelAssociationKey = -1
        Me.btnCtaCte.Location = New System.Drawing.Point(522, 452)
        Me.btnCtaCte.Name = "btnCtaCte"
        Me.btnCtaCte.Size = New System.Drawing.Size(58, 54)
        Me.btnCtaCte.TabIndex = 76
        Me.ToolTip1.SetToolTip(Me.btnCtaCte, "Consultar Cuentas Corrientes")
        Me.btnCtaCte.UseVisualStyleBackColor = True
        '
        'btnChequesTerceros
        '
        Me.btnChequesTerceros.BackgroundImage = Global.Administracion.My.Resources.Resources.check_icon
        Me.btnChequesTerceros.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnChequesTerceros.Cleanable = False
        Me.btnChequesTerceros.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnChequesTerceros.EnterIndex = -1
        Me.btnChequesTerceros.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnChequesTerceros.FlatAppearance.BorderSize = 0
        Me.btnChequesTerceros.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.Control
        Me.btnChequesTerceros.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control
        Me.btnChequesTerceros.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control
        Me.btnChequesTerceros.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnChequesTerceros.LabelAssociationKey = -1
        Me.btnChequesTerceros.Location = New System.Drawing.Point(592, 452)
        Me.btnChequesTerceros.Name = "btnChequesTerceros"
        Me.btnChequesTerceros.Size = New System.Drawing.Size(89, 54)
        Me.btnChequesTerceros.TabIndex = 76
        Me.ToolTip1.SetToolTip(Me.btnChequesTerceros, "Consulta de Cheques de Terceros")
        Me.btnChequesTerceros.UseVisualStyleBackColor = True
        '
        'btnCerrar
        '
        Me.btnCerrar.BackgroundImage = Global.Administracion.My.Resources.Resources.Salir2
        Me.btnCerrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnCerrar.Cleanable = False
        Me.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCerrar.EnterIndex = -1
        Me.btnCerrar.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnCerrar.FlatAppearance.BorderSize = 0
        Me.btnCerrar.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.Control
        Me.btnCerrar.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control
        Me.btnCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control
        Me.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCerrar.LabelAssociationKey = -1
        Me.btnCerrar.Location = New System.Drawing.Point(687, 452)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(50, 54)
        Me.btnCerrar.TabIndex = 76
        Me.ToolTip1.SetToolTip(Me.btnCerrar, "Cerrar Formulario")
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'btnLimpiar
        '
        Me.btnLimpiar.BackgroundImage = Global.Administracion.My.Resources.Resources.Limpiar
        Me.btnLimpiar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnLimpiar.Cleanable = False
        Me.btnLimpiar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnLimpiar.EnterIndex = -1
        Me.btnLimpiar.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnLimpiar.FlatAppearance.BorderSize = 0
        Me.btnLimpiar.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.Control
        Me.btnLimpiar.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control
        Me.btnLimpiar.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control
        Me.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLimpiar.LabelAssociationKey = -1
        Me.btnLimpiar.Location = New System.Drawing.Point(195, 452)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(50, 54)
        Me.btnLimpiar.TabIndex = 75
        Me.ToolTip1.SetToolTip(Me.btnLimpiar, "Limpiar Formulario")
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'btnAgregar
        '
        Me.btnAgregar.BackgroundImage = Global.Administracion.My.Resources.Resources.Aceptar_N2
        Me.btnAgregar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnAgregar.Cleanable = False
        Me.btnAgregar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAgregar.EnterIndex = -1
        Me.btnAgregar.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnAgregar.FlatAppearance.BorderSize = 0
        Me.btnAgregar.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.Control
        Me.btnAgregar.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control
        Me.btnAgregar.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control
        Me.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAgregar.LabelAssociationKey = -1
        Me.btnAgregar.Location = New System.Drawing.Point(39, 452)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(50, 54)
        Me.btnAgregar.TabIndex = 74
        Me.ToolTip1.SetToolTip(Me.btnAgregar, "Ingresar Orden de Pago")
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'CustomLabel17
        '
        Me.CustomLabel17.AutoSize = True
        Me.CustomLabel17.ControlAssociationKey = 3
        Me.CustomLabel17.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.CustomLabel17.ForeColor = System.Drawing.SystemColors.Control
        Me.CustomLabel17.Location = New System.Drawing.Point(12, 20)
        Me.CustomLabel17.Name = "CustomLabel17"
        Me.CustomLabel17.Size = New System.Drawing.Size(99, 18)
        Me.CustomLabel17.TabIndex = 132
        Me.CustomLabel17.Text = "Orden de Pago"
        '
        'Pagos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(776, 509)
        Me.Controls.Add(Me.btnCarpetas)
        Me.Controls.Add(Me.btnImprimir)
        Me.Controls.Add(Me.btnCalcular)
        Me.Controls.Add(Me.btnConsulta)
        Me.Controls.Add(Me.btnCtaCte)
        Me.Controls.Add(Me.btnChequesTerceros)
        Me.Controls.Add(Me.btnCerrar)
        Me.Controls.Add(Me.btnLimpiar)
        Me.Controls.Add(Me.btnAgregar)
        Me.Controls.Add(Me.Panel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Location = New System.Drawing.Point(20, 5)
        Me.MaximizeBox = False
        Me.Name = "Pagos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Ingreso de Pagos a Proveedores                                                   " & _
            "                                                                     SURFACTAN S" & _
            ".A."
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.gridPagos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridFormaPagos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.pnlDifCamXFactura.ResumeLayout(False)
        Me.pnlDifCamXFactura.PerformLayout()
        CType(Me.GridPagosXFacturas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlPedirCuenta.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CustomLabel1 As Administracion.CustomLabel
    Friend WithEvents CustomLabel2 As Administracion.CustomLabel
    Friend WithEvents CustomLabel3 As Administracion.CustomLabel
    Friend WithEvents CustomLabel4 As Administracion.CustomLabel
    Friend WithEvents CustomLabel5 As Administracion.CustomLabel
    Friend WithEvents txtOrdenPago As Administracion.CustomTextBox
    Friend WithEvents txtRazonSocial As Administracion.CustomTextBox
    Friend WithEvents txtProveedor As Administracion.CustomTextBox
    Friend WithEvents txtObservaciones As Administracion.CustomTextBox
    Friend WithEvents txtBanco As Administracion.CustomTextBox
    Friend WithEvents txtNombreBanco As Administracion.CustomTextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents optTransferencias As System.Windows.Forms.RadioButton
    Friend WithEvents optAnticipos As System.Windows.Forms.RadioButton
    Friend WithEvents optChequeRechazado As System.Windows.Forms.RadioButton
    Friend WithEvents optVarios As System.Windows.Forms.RadioButton
    Friend WithEvents optCtaCte As System.Windows.Forms.RadioButton
    Friend WithEvents CustomLabel6 As Administracion.CustomLabel
    Friend WithEvents CustomLabel7 As Administracion.CustomLabel
    Friend WithEvents txtParidad As Administracion.CustomTextBox
    Friend WithEvents cmbTipo As Administracion.CustomComboBox
    Friend WithEvents lblGanancias As Administracion.CustomLabel
    Friend WithEvents CustomLabel8 As Administracion.CustomLabel
    Friend WithEvents txtGanancias As Administracion.CustomTextBox
    Friend WithEvents CustomLabel9 As Administracion.CustomLabel
    Friend WithEvents txtIBCiudad As Administracion.CustomTextBox
    Friend WithEvents CustomLabel10 As Administracion.CustomLabel
    Friend WithEvents txtIVA As Administracion.CustomTextBox
    Friend WithEvents txtIngresosBrutos As Administracion.CustomTextBox
    Friend WithEvents CustomLabel11 As Administracion.CustomLabel
    Friend WithEvents txtTotal As Administracion.CustomTextBox
    Friend WithEvents lstConsulta As Administracion.CustomListBox
    Friend WithEvents txtConsulta As Administracion.CustomTextBox
    Friend WithEvents gridPagos As System.Windows.Forms.DataGridView
    Friend WithEvents gridFormaPagos As System.Windows.Forms.DataGridView
    Friend WithEvents lstSeleccion As Administracion.CustomListBox
    Friend WithEvents CustomLabel12 As Administracion.CustomLabel
    Friend WithEvents lblPagos As Administracion.CustomLabel
    Friend WithEvents lblFormaPagos As Administracion.CustomLabel
    Friend WithEvents lblDiferencia As Administracion.CustomLabel
    Friend WithEvents CustomLabel13 As Administracion.CustomLabel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents btnCarpetas As Administracion.CustomButton
    Friend WithEvents btnImprimir As Administracion.CustomButton
    Friend WithEvents btnCalcular As Administracion.CustomButton
    Friend WithEvents btnConsulta As Administracion.CustomButton
    Friend WithEvents btnCerrar As Administracion.CustomButton
    Friend WithEvents btnLimpiar As Administracion.CustomButton
    Friend WithEvents btnAgregar As Administracion.CustomButton
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents txtFechaParidad As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtFecha As System.Windows.Forms.MaskedTextBox
    Friend WithEvents CLBFiltrado As Administracion.CustomListBox
    Friend WithEvents btnChequesTerceros As Administracion.CustomButton
    Friend WithEvents btnCtaCte As Administracion.CustomButton
    Friend WithEvents txtFechaAux As System.Windows.Forms.MaskedTextBox
    Friend WithEvents CustomLabel14 As Administracion.CustomLabel
    Friend WithEvents CustomLabel15 As Administracion.CustomLabel
    Friend WithEvents CustomLabel16 As Administracion.CustomLabel
    Friend WithEvents pnlPedirCuenta As System.Windows.Forms.Panel
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtCuenta As Administracion.CustomTextBox
    Friend WithEvents btnDifeCambio As System.Windows.Forms.Button
    Friend WithEvents WProceso As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Tipo2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Numero2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Fecha2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Banco2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Nombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Importe2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents XClave As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents XCuil As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cuenta As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UltTipo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ckNoCalcRetenciones As System.Windows.Forms.CheckBox
    Friend WithEvents btnEliminarFila As System.Windows.Forms.Button
    Friend WithEvents Tipo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Letra As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Punto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Numero As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Importe As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Descripcion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ImpoNeto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CuentaContable As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MarcaDifCambio As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MarcaCHR As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnEnviarAviso As System.Windows.Forms.Button
    Friend WithEvents btnActualizarCarpetas As System.Windows.Forms.Button
    Friend WithEvents ckCalculaDifCambio As System.Windows.Forms.CheckBox
    Friend WithEvents pnlDifCamXFactura As System.Windows.Forms.Panel
    Friend WithEvents GridPagosXFacturas As System.Windows.Forms.DataGridView
    Friend WithEvents btnDifCambioXFactura As System.Windows.Forms.Button
    Friend WithEvents btnVolver As System.Windows.Forms.Button
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents Check As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents NumeroXFactura As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Tipo3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Letra3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Punto3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Fecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ImportePesos As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Paridad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ImporteDolares As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomLabel17 As Administracion.CustomLabel
End Class
