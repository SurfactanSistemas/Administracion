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
        Me.gridFormaPagos = New System.Windows.Forms.DataGridView()
        Me.Tipo2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Numero2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Fecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Banco = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Nombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Importe2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.XClave = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.XCuil = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lstSeleccion = New Administracion.CustomListBox()
        Me.CLBFiltrado = New Administracion.CustomListBox()
        Me.txtFechaParidad = New System.Windows.Forms.MaskedTextBox()
        Me.txtFecha = New System.Windows.Forms.MaskedTextBox()
        Me.CustomLabel12 = New Administracion.CustomLabel()
        Me.CustomLabel13 = New Administracion.CustomLabel()
        Me.CustomLabel1 = New Administracion.CustomLabel()
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
        Me.GroupBox1.SuspendLayout()
        CType(Me.gridPagos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridFormaPagos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
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
        Me.GroupBox1.Location = New System.Drawing.Point(22, 130)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(259, 99)
        Me.GroupBox1.TabIndex = 34
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Tipo de Orden de Pago"
        '
        'optTransferencias
        '
        Me.optTransferencias.AutoSize = True
        Me.optTransferencias.Location = New System.Drawing.Point(134, 46)
        Me.optTransferencias.Name = "optTransferencias"
        Me.optTransferencias.Size = New System.Drawing.Size(115, 22)
        Me.optTransferencias.TabIndex = 4
        Me.optTransferencias.Text = "Transferencias"
        Me.optTransferencias.UseVisualStyleBackColor = True
        '
        'optAnticipos
        '
        Me.optAnticipos.AutoSize = True
        Me.optAnticipos.Location = New System.Drawing.Point(134, 23)
        Me.optAnticipos.Name = "optAnticipos"
        Me.optAnticipos.Size = New System.Drawing.Size(84, 22)
        Me.optAnticipos.TabIndex = 3
        Me.optAnticipos.Text = "Anticipos"
        Me.optAnticipos.UseVisualStyleBackColor = True
        '
        'optChequeRechazado
        '
        Me.optChequeRechazado.AutoSize = True
        Me.optChequeRechazado.Location = New System.Drawing.Point(6, 69)
        Me.optChequeRechazado.Name = "optChequeRechazado"
        Me.optChequeRechazado.Size = New System.Drawing.Size(121, 22)
        Me.optChequeRechazado.TabIndex = 2
        Me.optChequeRechazado.Text = "Ch. Rechazados"
        Me.optChequeRechazado.UseVisualStyleBackColor = True
        '
        'optVarios
        '
        Me.optVarios.AutoSize = True
        Me.optVarios.Location = New System.Drawing.Point(6, 46)
        Me.optVarios.Name = "optVarios"
        Me.optVarios.Size = New System.Drawing.Size(103, 22)
        Me.optVarios.TabIndex = 1
        Me.optVarios.Text = "Pagos Varios"
        Me.optVarios.UseVisualStyleBackColor = True
        '
        'optCtaCte
        '
        Me.optCtaCte.AutoSize = True
        Me.optCtaCte.Checked = True
        Me.optCtaCte.Location = New System.Drawing.Point(6, 23)
        Me.optCtaCte.Name = "optCtaCte"
        Me.optCtaCte.Size = New System.Drawing.Size(117, 22)
        Me.optCtaCte.TabIndex = 0
        Me.optCtaCte.TabStop = True
        Me.optCtaCte.Text = "Pagos Cta. Cte."
        Me.optCtaCte.UseVisualStyleBackColor = True
        '
        'gridPagos
        '
        Me.gridPagos.AllowUserToAddRows = False
        Me.gridPagos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridPagos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Tipo, Me.Letra, Me.Punto, Me.Numero, Me.Importe, Me.Descripcion})
        Me.gridPagos.Location = New System.Drawing.Point(16, 247)
        Me.gridPagos.Name = "gridPagos"
        Me.gridPagos.RowHeadersWidth = 10
        Me.gridPagos.Size = New System.Drawing.Size(396, 217)
        Me.gridPagos.TabIndex = 56
        '
        'Tipo
        '
        Me.Tipo.HeaderText = "Tipo"
        Me.Tipo.Name = "Tipo"
        Me.Tipo.ReadOnly = True
        Me.Tipo.Width = 35
        '
        'Letra
        '
        Me.Letra.HeaderText = "Letra"
        Me.Letra.Name = "Letra"
        Me.Letra.ReadOnly = True
        Me.Letra.Width = 40
        '
        'Punto
        '
        Me.Punto.HeaderText = "Punto"
        Me.Punto.Name = "Punto"
        Me.Punto.ReadOnly = True
        Me.Punto.Width = 45
        '
        'Numero
        '
        Me.Numero.HeaderText = "Número"
        Me.Numero.Name = "Numero"
        Me.Numero.ReadOnly = True
        Me.Numero.Width = 70
        '
        'Importe
        '
        Me.Importe.HeaderText = "Importe"
        Me.Importe.Name = "Importe"
        Me.Importe.Width = 75
        '
        'Descripcion
        '
        Me.Descripcion.HeaderText = "Descripción"
        Me.Descripcion.Name = "Descripcion"
        Me.Descripcion.ReadOnly = True
        Me.Descripcion.Width = 115
        '
        'gridFormaPagos
        '
        Me.gridFormaPagos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridFormaPagos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Tipo2, Me.Numero2, Me.Fecha, Me.Banco, Me.Nombre, Me.Importe2, Me.XClave, Me.XCuil})
        Me.gridFormaPagos.Location = New System.Drawing.Point(414, 247)
        Me.gridFormaPagos.Name = "gridFormaPagos"
        Me.gridFormaPagos.RowHeadersWidth = 10
        Me.gridFormaPagos.Size = New System.Drawing.Size(398, 217)
        Me.gridFormaPagos.TabIndex = 57
        '
        'Tipo2
        '
        Me.Tipo2.HeaderText = "Tipo"
        Me.Tipo2.Name = "Tipo2"
        Me.Tipo2.Width = 35
        '
        'Numero2
        '
        Me.Numero2.HeaderText = "Número"
        Me.Numero2.Name = "Numero2"
        Me.Numero2.Width = 70
        '
        'Fecha
        '
        Me.Fecha.HeaderText = "Fecha"
        Me.Fecha.Name = "Fecha"
        Me.Fecha.Width = 75
        '
        'Banco
        '
        Me.Banco.HeaderText = "Banco"
        Me.Banco.Name = "Banco"
        Me.Banco.Width = 45
        '
        'Nombre
        '
        Me.Nombre.HeaderText = "Nombre"
        Me.Nombre.Name = "Nombre"
        Me.Nombre.ReadOnly = True
        Me.Nombre.Width = 80
        '
        'Importe2
        '
        Me.Importe2.HeaderText = "Importe"
        Me.Importe2.Name = "Importe2"
        Me.Importe2.Width = 80
        '
        'XClave
        '
        Me.XClave.HeaderText = "XClave"
        Me.XClave.Name = "XClave"
        Me.XClave.Visible = False
        '
        'XCuil
        '
        Me.XCuil.HeaderText = "XCuil"
        Me.XCuil.Name = "XCuil"
        Me.XCuil.Visible = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(0, -1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(828, 50)
        Me.Panel1.TabIndex = 72
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.Control
        Me.Label2.Location = New System.Drawing.Point(651, 10)
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
        Me.Label1.Location = New System.Drawing.Point(22, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(226, 19)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Ingreso de Pagos a Proveedores"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(95, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(82, Byte), Integer))
        Me.Panel2.Controls.Add(Me.lstSeleccion)
        Me.Panel2.Controls.Add(Me.CLBFiltrado)
        Me.Panel2.Controls.Add(Me.txtFechaParidad)
        Me.Panel2.Controls.Add(Me.txtFecha)
        Me.Panel2.Controls.Add(Me.CustomLabel12)
        Me.Panel2.Controls.Add(Me.CustomLabel13)
        Me.Panel2.Controls.Add(Me.CustomLabel1)
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
        Me.Panel2.Controls.Add(Me.CustomLabel11)
        Me.Panel2.Controls.Add(Me.lblGanancias)
        Me.Panel2.Controls.Add(Me.txtIVA)
        Me.Panel2.Controls.Add(Me.CustomLabel8)
        Me.Panel2.Controls.Add(Me.txtIngresosBrutos)
        Me.Panel2.Controls.Add(Me.txtGanancias)
        Me.Panel2.Controls.Add(Me.CustomLabel10)
        Me.Panel2.Controls.Add(Me.CustomLabel9)
        Me.Panel2.Controls.Add(Me.txtIBCiudad)
        Me.Panel2.Location = New System.Drawing.Point(-1, 49)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(828, 500)
        Me.Panel2.TabIndex = 73
        '
        'lstSeleccion
        '
        Me.lstSeleccion.Cleanable = False
        Me.lstSeleccion.EnterIndex = -1
        Me.lstSeleccion.FormattingEnabled = True
        Me.lstSeleccion.Items.AddRange(New Object() {"Proveedores", "Cuentas Corrientes", "Cheques Terceros", "Documentos", "Cuentas Contables"})
        Me.lstSeleccion.LabelAssociationKey = -1
        Me.lstSeleccion.Location = New System.Drawing.Point(475, 18)
        Me.lstSeleccion.Name = "lstSeleccion"
        Me.lstSeleccion.Size = New System.Drawing.Size(333, 134)
        Me.lstSeleccion.TabIndex = 66
        Me.lstSeleccion.Visible = False
        '
        'CLBFiltrado
        '
        Me.CLBFiltrado.Cleanable = True
        Me.CLBFiltrado.EnterIndex = -1
        Me.CLBFiltrado.FormattingEnabled = True
        Me.CLBFiltrado.LabelAssociationKey = -1
        Me.CLBFiltrado.Location = New System.Drawing.Point(476, 41)
        Me.CLBFiltrado.Name = "CLBFiltrado"
        Me.CLBFiltrado.Size = New System.Drawing.Size(333, 108)
        Me.CLBFiltrado.TabIndex = 73
        Me.CLBFiltrado.Visible = False
        '
        'txtFechaParidad
        '
        Me.txtFechaParidad.Location = New System.Drawing.Point(384, 129)
        Me.txtFechaParidad.Mask = "00/00/0000"
        Me.txtFechaParidad.Name = "txtFechaParidad"
        Me.txtFechaParidad.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtFechaParidad.Size = New System.Drawing.Size(79, 20)
        Me.txtFechaParidad.TabIndex = 72
        Me.txtFechaParidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtFecha
        '
        Me.txtFecha.Location = New System.Drawing.Point(255, 22)
        Me.txtFecha.Mask = "00/00/0000"
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtFecha.Size = New System.Drawing.Size(100, 20)
        Me.txtFecha.TabIndex = 72
        Me.txtFecha.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'CustomLabel12
        '
        Me.CustomLabel12.AutoSize = True
        Me.CustomLabel12.ControlAssociationKey = 13
        Me.CustomLabel12.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.CustomLabel12.ForeColor = System.Drawing.SystemColors.Control
        Me.CustomLabel12.Location = New System.Drawing.Point(343, 186)
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
        Me.CustomLabel13.Location = New System.Drawing.Point(318, 467)
        Me.CustomLabel13.Name = "CustomLabel13"
        Me.CustomLabel13.Size = New System.Drawing.Size(342, 22)
        Me.CustomLabel13.TabIndex = 71
        Me.CustomLabel13.Text = "Tipo de Doc.:   1) Ef.   2) Bco.   3) Ch. Terceros   5) US$   6) Varios"
        Me.CustomLabel13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CustomLabel1
        '
        Me.CustomLabel1.AutoSize = True
        Me.CustomLabel1.ControlAssociationKey = 1
        Me.CustomLabel1.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.CustomLabel1.ForeColor = System.Drawing.SystemColors.Control
        Me.CustomLabel1.Location = New System.Drawing.Point(22, 23)
        Me.CustomLabel1.Name = "CustomLabel1"
        Me.CustomLabel1.Size = New System.Drawing.Size(99, 18)
        Me.CustomLabel1.TabIndex = 0
        Me.CustomLabel1.Text = "Orden de Pago"
        '
        'lblDiferencia
        '
        Me.lblDiferencia.BackColor = System.Drawing.SystemColors.Control
        Me.lblDiferencia.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDiferencia.ControlAssociationKey = -1
        Me.lblDiferencia.Location = New System.Drawing.Point(666, 467)
        Me.lblDiferencia.Name = "lblDiferencia"
        Me.lblDiferencia.Size = New System.Drawing.Size(70, 22)
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
        Me.CustomLabel2.Location = New System.Drawing.Point(205, 23)
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
        Me.lblFormaPagos.Location = New System.Drawing.Point(742, 467)
        Me.lblFormaPagos.Name = "lblFormaPagos"
        Me.lblFormaPagos.Size = New System.Drawing.Size(70, 22)
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
        Me.CustomLabel3.Location = New System.Drawing.Point(48, 52)
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
        Me.lblPagos.Location = New System.Drawing.Point(242, 467)
        Me.lblPagos.Name = "lblPagos"
        Me.lblPagos.Size = New System.Drawing.Size(70, 22)
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
        Me.CustomLabel4.Location = New System.Drawing.Point(22, 79)
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
        Me.CustomLabel5.Location = New System.Drawing.Point(76, 106)
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
        Me.txtOrdenPago.Location = New System.Drawing.Point(124, 22)
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
        Me.txtProveedor.Location = New System.Drawing.Point(124, 49)
        Me.txtProveedor.MaxLength = 11
        Me.txtProveedor.Name = "txtProveedor"
        Me.txtProveedor.Size = New System.Drawing.Size(95, 20)
        Me.txtProveedor.TabIndex = 29
        Me.ToolTip1.SetToolTip(Me.txtProveedor, "Doble Click para abrir listado de Proveedores")
        Me.txtProveedor.Validator = Administracion.ValidatorType.None
        '
        'txtRazonSocial
        '
        Me.txtRazonSocial.Cleanable = True
        Me.txtRazonSocial.Empty = False
        Me.txtRazonSocial.EnterIndex = -1
        Me.txtRazonSocial.LabelAssociationKey = 3
        Me.txtRazonSocial.Location = New System.Drawing.Point(225, 49)
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
        Me.txtObservaciones.Location = New System.Drawing.Point(124, 76)
        Me.txtObservaciones.MaxLength = 50
        Me.txtObservaciones.Name = "txtObservaciones"
        Me.txtObservaciones.Size = New System.Drawing.Size(341, 20)
        Me.txtObservaciones.TabIndex = 31
        Me.txtObservaciones.Validator = Administracion.ValidatorType.None
        '
        'txtBanco
        '
        Me.txtBanco.Cleanable = True
        Me.txtBanco.Empty = True
        Me.txtBanco.Enabled = False
        Me.txtBanco.EnterIndex = 5
        Me.txtBanco.LabelAssociationKey = 5
        Me.txtBanco.Location = New System.Drawing.Point(124, 103)
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
        Me.txtNombreBanco.Location = New System.Drawing.Point(225, 103)
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
        Me.CustomLabel6.Location = New System.Drawing.Point(284, 134)
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
        Me.CustomLabel7.Location = New System.Drawing.Point(323, 161)
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
        Me.txtConsulta.Location = New System.Drawing.Point(474, 17)
        Me.txtConsulta.Name = "txtConsulta"
        Me.txtConsulta.Size = New System.Drawing.Size(333, 20)
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
        Me.lstConsulta.Location = New System.Drawing.Point(476, 41)
        Me.lstConsulta.Name = "lstConsulta"
        Me.lstConsulta.Size = New System.Drawing.Size(333, 108)
        Me.lstConsulta.TabIndex = 54
        Me.lstConsulta.Visible = False
        '
        'txtParidad
        '
        Me.txtParidad.Cleanable = True
        Me.txtParidad.Empty = True
        Me.txtParidad.EnterIndex = 7
        Me.txtParidad.LabelAssociationKey = 7
        Me.txtParidad.Location = New System.Drawing.Point(384, 156)
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
        Me.txtTotal.Location = New System.Drawing.Point(639, 210)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.ReadOnly = True
        Me.txtTotal.Size = New System.Drawing.Size(168, 20)
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
        Me.cmbTipo.Location = New System.Drawing.Point(384, 182)
        Me.cmbTipo.Name = "cmbTipo"
        Me.cmbTipo.Size = New System.Drawing.Size(81, 21)
        Me.cmbTipo.TabIndex = 39
        Me.cmbTipo.Validator = Administracion.ValidatorType.None
        Me.cmbTipo.Visible = False
        '
        'CustomLabel11
        '
        Me.CustomLabel11.AutoSize = True
        Me.CustomLabel11.ControlAssociationKey = 12
        Me.CustomLabel11.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.CustomLabel11.ForeColor = System.Drawing.SystemColors.Control
        Me.CustomLabel11.Location = New System.Drawing.Point(515, 211)
        Me.CustomLabel11.Name = "CustomLabel11"
        Me.CustomLabel11.Size = New System.Drawing.Size(118, 18)
        Me.CustomLabel11.TabIndex = 52
        Me.CustomLabel11.Text = "Total Retenciones"
        '
        'lblGanancias
        '
        Me.lblGanancias.AutoSize = True
        Me.lblGanancias.ControlAssociationKey = 8
        Me.lblGanancias.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.lblGanancias.ForeColor = System.Drawing.SystemColors.Control
        Me.lblGanancias.Location = New System.Drawing.Point(470, 159)
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
        Me.txtIVA.Location = New System.Drawing.Point(739, 185)
        Me.txtIVA.Name = "txtIVA"
        Me.txtIVA.ReadOnly = True
        Me.txtIVA.Size = New System.Drawing.Size(67, 20)
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
        Me.CustomLabel8.Location = New System.Drawing.Point(636, 159)
        Me.CustomLabel8.Name = "CustomLabel8"
        Me.CustomLabel8.Size = New System.Drawing.Size(102, 18)
        Me.CustomLabel8.TabIndex = 41
        Me.CustomLabel8.Text = "Ret. Ing. Brutos"
        '
        'txtIngresosBrutos
        '
        Me.txtIngresosBrutos.Cleanable = True
        Me.txtIngresosBrutos.Empty = False
        Me.txtIngresosBrutos.EnterIndex = -1
        Me.txtIngresosBrutos.LabelAssociationKey = 9
        Me.txtIngresosBrutos.Location = New System.Drawing.Point(739, 158)
        Me.txtIngresosBrutos.Name = "txtIngresosBrutos"
        Me.txtIngresosBrutos.ReadOnly = True
        Me.txtIngresosBrutos.Size = New System.Drawing.Size(67, 20)
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
        Me.txtGanancias.Location = New System.Drawing.Point(569, 156)
        Me.txtGanancias.Name = "txtGanancias"
        Me.txtGanancias.ReadOnly = True
        Me.txtGanancias.Size = New System.Drawing.Size(64, 20)
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
        Me.CustomLabel10.Location = New System.Drawing.Point(670, 186)
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
        Me.CustomLabel9.Location = New System.Drawing.Point(469, 186)
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
        Me.txtIBCiudad.Location = New System.Drawing.Point(569, 183)
        Me.txtIBCiudad.Name = "txtIBCiudad"
        Me.txtIBCiudad.ReadOnly = True
        Me.txtIBCiudad.Size = New System.Drawing.Size(64, 20)
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
        Me.btnCarpetas.Location = New System.Drawing.Point(369, 559)
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
        Me.btnImprimir.Location = New System.Drawing.Point(287, 559)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(50, 54)
        Me.btnImprimir.TabIndex = 79
        Me.ToolTip1.SetToolTip(Me.btnImprimir, "Imprimir")
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
        Me.btnCalcular.Location = New System.Drawing.Point(443, 559)
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
        Me.btnConsulta.Location = New System.Drawing.Point(137, 559)
        Me.btnConsulta.Name = "btnConsulta"
        Me.btnConsulta.Size = New System.Drawing.Size(50, 54)
        Me.btnConsulta.TabIndex = 77
        Me.ToolTip1.SetToolTip(Me.btnConsulta, "Consulta")
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
        Me.btnCtaCte.Location = New System.Drawing.Point(526, 559)
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
        Me.btnChequesTerceros.Location = New System.Drawing.Point(590, 559)
        Me.btnChequesTerceros.Name = "btnChequesTerceros"
        Me.btnChequesTerceros.Size = New System.Drawing.Size(106, 54)
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
        Me.btnCerrar.Location = New System.Drawing.Point(712, 559)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(50, 54)
        Me.btnCerrar.TabIndex = 76
        Me.ToolTip1.SetToolTip(Me.btnCerrar, "Cancelar y Salir")
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
        Me.btnLimpiar.Location = New System.Drawing.Point(212, 559)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(50, 54)
        Me.btnLimpiar.TabIndex = 75
        Me.ToolTip1.SetToolTip(Me.btnLimpiar, "Limpiar")
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
        Me.btnAgregar.Location = New System.Drawing.Point(62, 559)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(50, 54)
        Me.btnAgregar.TabIndex = 74
        Me.ToolTip1.SetToolTip(Me.btnAgregar, "Agregar")
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'Pagos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(824, 623)
        Me.Controls.Add(Me.btnCarpetas)
        Me.Controls.Add(Me.btnImprimir)
        Me.Controls.Add(Me.btnCalcular)
        Me.Controls.Add(Me.btnConsulta)
        Me.Controls.Add(Me.btnCtaCte)
        Me.Controls.Add(Me.btnChequesTerceros)
        Me.Controls.Add(Me.btnCerrar)
        Me.Controls.Add(Me.btnLimpiar)
        Me.Controls.Add(Me.btnAgregar)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.Name = "Pagos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.gridPagos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridFormaPagos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
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
    Friend WithEvents Tipo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Letra As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Punto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Numero As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Importe As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Descripcion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
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
    Friend WithEvents Tipo2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Numero2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Fecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Banco As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Nombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Importe2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents XClave As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents XCuil As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnChequesTerceros As Administracion.CustomButton
    Friend WithEvents btnCtaCte As Administracion.CustomButton
End Class
