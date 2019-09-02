<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Compras
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
        Me.chkSoloIVA = New System.Windows.Forms.CheckBox()
        Me.gbTipo = New System.Windows.Forms.GroupBox()
        Me.optNacion = New System.Windows.Forms.RadioButton()
        Me.optCtaCte = New System.Windows.Forms.RadioButton()
        Me.optEfectivo = New System.Windows.Forms.RadioButton()
        Me.gridAsientos = New System.Windows.Forms.DataGridView()
        Me.Cuenta = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Debito = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Credito = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblCredito = New WindowsApplication1.CustomLabel()
        Me.lblDebito = New WindowsApplication1.CustomLabel()
        Me.btnApertura = New WindowsApplication1.CustomButton()
        Me.btnConsulta = New WindowsApplication1.CustomButton()
        Me.btnCerrar = New WindowsApplication1.CustomButton()
        Me.btnConsultaNroFactura = New WindowsApplication1.CustomButton()
        Me.btnLimpiar = New WindowsApplication1.CustomButton()
        Me.btnEliminar = New WindowsApplication1.CustomButton()
        Me.btnAgregar = New WindowsApplication1.CustomButton()
        Me.txtIVA10 = New WindowsApplication1.CustomTextBox()
        Me.txtDespacho = New WindowsApplication1.CustomTextBox()
        Me.txtIVA21 = New WindowsApplication1.CustomTextBox()
        Me.txtIVA27 = New WindowsApplication1.CustomTextBox()
        Me.txtNoGravado = New WindowsApplication1.CustomTextBox()
        Me.txtTotal = New WindowsApplication1.CustomTextBox()
        Me.txtNeto = New WindowsApplication1.CustomTextBox()
        Me.txtIVARG = New WindowsApplication1.CustomTextBox()
        Me.txtPercIB = New WindowsApplication1.CustomTextBox()
        Me.txtParidad = New WindowsApplication1.CustomTextBox()
        Me.cmbFormaPago = New WindowsApplication1.CustomComboBox()
        Me.txtFechaVto2 = New WindowsApplication1.CustomTextBox()
        Me.txtRemito = New WindowsApplication1.CustomTextBox()
        Me.txtFechaIVA = New WindowsApplication1.CustomTextBox()
        Me.txtFechaVto1 = New WindowsApplication1.CustomTextBox()
        Me.txtFechaEmision = New WindowsApplication1.CustomTextBox()
        Me.txtCAI = New WindowsApplication1.CustomTextBox()
        Me.txtVtoCAI = New WindowsApplication1.CustomTextBox()
        Me.txtNumero = New WindowsApplication1.CustomTextBox()
        Me.txtPunto = New WindowsApplication1.CustomTextBox()
        Me.txtLetra = New WindowsApplication1.CustomTextBox()
        Me.cmbTipo = New WindowsApplication1.CustomComboBox()
        Me.txtTipo = New WindowsApplication1.CustomTextBox()
        Me.txtNombreProveedor = New WindowsApplication1.CustomTextBox()
        Me.txtCodigoProveedor = New WindowsApplication1.CustomTextBox()
        Me.txtNroInterno = New WindowsApplication1.CustomTextBox()
        Me.CustomLabel23 = New WindowsApplication1.CustomLabel()
        Me.CustomLabel22 = New WindowsApplication1.CustomLabel()
        Me.CustomLabel21 = New WindowsApplication1.CustomLabel()
        Me.CustomLabel20 = New WindowsApplication1.CustomLabel()
        Me.CustomLabel19 = New WindowsApplication1.CustomLabel()
        Me.CustomLabel18 = New WindowsApplication1.CustomLabel()
        Me.CustomLabel17 = New WindowsApplication1.CustomLabel()
        Me.CustomLabel16 = New WindowsApplication1.CustomLabel()
        Me.CustomLabel15 = New WindowsApplication1.CustomLabel()
        Me.CustomLabel14 = New WindowsApplication1.CustomLabel()
        Me.CustomLabel13 = New WindowsApplication1.CustomLabel()
        Me.CustomLabel12 = New WindowsApplication1.CustomLabel()
        Me.CustomLabel11 = New WindowsApplication1.CustomLabel()
        Me.CustomLabel10 = New WindowsApplication1.CustomLabel()
        Me.CustomLabel9 = New WindowsApplication1.CustomLabel()
        Me.CustomLabel8 = New WindowsApplication1.CustomLabel()
        Me.CustomLabel7 = New WindowsApplication1.CustomLabel()
        Me.CustomLabel6 = New WindowsApplication1.CustomLabel()
        Me.CustomLabel5 = New WindowsApplication1.CustomLabel()
        Me.CustomLabel4 = New WindowsApplication1.CustomLabel()
        Me.CustomLabel3 = New WindowsApplication1.CustomLabel()
        Me.CustomLabel2 = New WindowsApplication1.CustomLabel()
        Me.CustomLabel1 = New WindowsApplication1.CustomLabel()
        Me.gbTipo.SuspendLayout()
        CType(Me.gridAsientos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'chkSoloIVA
        '
        Me.chkSoloIVA.AutoSize = True
        Me.chkSoloIVA.Location = New System.Drawing.Point(571, 162)
        Me.chkSoloIVA.Name = "chkSoloIVA"
        Me.chkSoloIVA.Size = New System.Drawing.Size(67, 17)
        Me.chkSoloIVA.TabIndex = 24
        Me.chkSoloIVA.Text = "Sólo IVA"
        Me.chkSoloIVA.UseVisualStyleBackColor = True
        '
        'gbTipo
        '
        Me.gbTipo.Controls.Add(Me.optNacion)
        Me.gbTipo.Controls.Add(Me.optCtaCte)
        Me.gbTipo.Controls.Add(Me.optEfectivo)
        Me.gbTipo.Location = New System.Drawing.Point(205, 206)
        Me.gbTipo.Name = "gbTipo"
        Me.gbTipo.Size = New System.Drawing.Size(220, 43)
        Me.gbTipo.TabIndex = 25
        Me.gbTipo.TabStop = False
        Me.gbTipo.Text = "Tipo"
        '
        'optNacion
        '
        Me.optNacion.AutoSize = True
        Me.optNacion.Location = New System.Drawing.Point(148, 16)
        Me.optNacion.Name = "optNacion"
        Me.optNacion.Size = New System.Drawing.Size(59, 17)
        Me.optNacion.TabIndex = 2
        Me.optNacion.Text = "Nación"
        Me.optNacion.UseVisualStyleBackColor = True
        '
        'optCtaCte
        '
        Me.optCtaCte.AutoSize = True
        Me.optCtaCte.Location = New System.Drawing.Point(76, 16)
        Me.optCtaCte.Name = "optCtaCte"
        Me.optCtaCte.Size = New System.Drawing.Size(66, 17)
        Me.optCtaCte.TabIndex = 1
        Me.optCtaCte.Text = "Cta. Cte."
        Me.optCtaCte.UseVisualStyleBackColor = True
        '
        'optEfectivo
        '
        Me.optEfectivo.AutoSize = True
        Me.optEfectivo.Checked = True
        Me.optEfectivo.Location = New System.Drawing.Point(6, 16)
        Me.optEfectivo.Name = "optEfectivo"
        Me.optEfectivo.Size = New System.Drawing.Size(64, 17)
        Me.optEfectivo.TabIndex = 0
        Me.optEfectivo.TabStop = True
        Me.optEfectivo.Text = "Efectivo"
        Me.optEfectivo.UseVisualStyleBackColor = True
        '
        'gridAsientos
        '
        Me.gridAsientos.AllowUserToAddRows = False
        Me.gridAsientos.AllowUserToDeleteRows = False
        Me.gridAsientos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridAsientos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Cuenta, Me.Descripcion, Me.Debito, Me.Credito})
        Me.gridAsientos.Location = New System.Drawing.Point(23, 255)
        Me.gridAsientos.Name = "gridAsientos"
        Me.gridAsientos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.gridAsientos.Size = New System.Drawing.Size(741, 286)
        Me.gridAsientos.TabIndex = 52
        '
        'Cuenta
        '
        Me.Cuenta.HeaderText = "Cuenta"
        Me.Cuenta.Name = "Cuenta"
        '
        'Descripcion
        '
        Me.Descripcion.HeaderText = "Descripción"
        Me.Descripcion.Name = "Descripcion"
        Me.Descripcion.ReadOnly = True
        Me.Descripcion.Width = 350
        '
        'Debito
        '
        Me.Debito.HeaderText = "Débito"
        Me.Debito.Name = "Debito"
        Me.Debito.Width = 120
        '
        'Credito
        '
        Me.Credito.HeaderText = "Crédito"
        Me.Credito.Name = "Credito"
        Me.Credito.Width = 120
        '
        'lblCredito
        '
        Me.lblCredito.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCredito.ControlAssociationKey = -1
        Me.lblCredito.Location = New System.Drawing.Point(636, 546)
        Me.lblCredito.Name = "lblCredito"
        Me.lblCredito.Size = New System.Drawing.Size(117, 20)
        Me.lblCredito.TabIndex = 61
        Me.lblCredito.Text = "0,00"
        Me.lblCredito.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblDebito
        '
        Me.lblDebito.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDebito.ControlAssociationKey = -1
        Me.lblDebito.Location = New System.Drawing.Point(513, 546)
        Me.lblDebito.Name = "lblDebito"
        Me.lblDebito.Size = New System.Drawing.Size(117, 20)
        Me.lblDebito.TabIndex = 60
        Me.lblDebito.Text = "0,00"
        Me.lblDebito.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnApertura
        '
        Me.btnApertura.Cleanable = False
        Me.btnApertura.EnterIndex = -1
        Me.btnApertura.LabelAssociationKey = -1
        Me.btnApertura.Location = New System.Drawing.Point(652, 156)
        Me.btnApertura.Name = "btnApertura"
        Me.btnApertura.Size = New System.Drawing.Size(100, 25)
        Me.btnApertura.TabIndex = 59
        Me.btnApertura.Text = "Apertura"
        Me.btnApertura.UseVisualStyleBackColor = True
        '
        'btnConsulta
        '
        Me.btnConsulta.Cleanable = False
        Me.btnConsulta.EnterIndex = -1
        Me.btnConsulta.LabelAssociationKey = -1
        Me.btnConsulta.Location = New System.Drawing.Point(652, 218)
        Me.btnConsulta.Name = "btnConsulta"
        Me.btnConsulta.Size = New System.Drawing.Size(100, 25)
        Me.btnConsulta.TabIndex = 58
        Me.btnConsulta.Text = "Consulta"
        Me.btnConsulta.UseVisualStyleBackColor = True
        '
        'btnCerrar
        '
        Me.btnCerrar.Cleanable = False
        Me.btnCerrar.EnterIndex = -1
        Me.btnCerrar.LabelAssociationKey = -1
        Me.btnCerrar.Location = New System.Drawing.Point(546, 219)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(100, 25)
        Me.btnCerrar.TabIndex = 57
        Me.btnCerrar.Text = "Cerrar"
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'btnConsultaNroFactura
        '
        Me.btnConsultaNroFactura.Cleanable = False
        Me.btnConsultaNroFactura.EnterIndex = -1
        Me.btnConsultaNroFactura.LabelAssociationKey = -1
        Me.btnConsultaNroFactura.Location = New System.Drawing.Point(652, 187)
        Me.btnConsultaNroFactura.Name = "btnConsultaNroFactura"
        Me.btnConsultaNroFactura.Size = New System.Drawing.Size(126, 25)
        Me.btnConsultaNroFactura.TabIndex = 56
        Me.btnConsultaNroFactura.Text = "Consulta Nro. Factura"
        Me.btnConsultaNroFactura.UseVisualStyleBackColor = True
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Cleanable = False
        Me.btnLimpiar.EnterIndex = -1
        Me.btnLimpiar.LabelAssociationKey = -1
        Me.btnLimpiar.Location = New System.Drawing.Point(546, 188)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(100, 25)
        Me.btnLimpiar.TabIndex = 55
        Me.btnLimpiar.Text = "Limpiar"
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'btnEliminar
        '
        Me.btnEliminar.Cleanable = False
        Me.btnEliminar.EnterIndex = -1
        Me.btnEliminar.LabelAssociationKey = -1
        Me.btnEliminar.Location = New System.Drawing.Point(440, 218)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(100, 25)
        Me.btnEliminar.TabIndex = 54
        Me.btnEliminar.Text = "Eliminar"
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'btnAgregar
        '
        Me.btnAgregar.Cleanable = False
        Me.btnAgregar.EnterIndex = -1
        Me.btnAgregar.LabelAssociationKey = -1
        Me.btnAgregar.Location = New System.Drawing.Point(440, 187)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(100, 25)
        Me.btnAgregar.TabIndex = 53
        Me.btnAgregar.Text = "Agregar"
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'txtIVA10
        '
        Me.txtIVA10.Cleanable = True
        Me.txtIVA10.Empty = False
        Me.txtIVA10.EnterIndex = 22
        Me.txtIVA10.LabelAssociationKey = 23
        Me.txtIVA10.Location = New System.Drawing.Point(481, 159)
        Me.txtIVA10.Name = "txtIVA10"
        Me.txtIVA10.Size = New System.Drawing.Size(75, 20)
        Me.txtIVA10.TabIndex = 51
        Me.txtIVA10.Validator = WindowsApplication1.ValidatorType.Float
        '
        'txtDespacho
        '
        Me.txtDespacho.Cleanable = True
        Me.txtDespacho.Empty = True
        Me.txtDespacho.EnterIndex = 23
        Me.txtDespacho.LabelAssociationKey = 22
        Me.txtDespacho.Location = New System.Drawing.Point(481, 133)
        Me.txtDespacho.MaxLength = 20
        Me.txtDespacho.Name = "txtDespacho"
        Me.txtDespacho.Size = New System.Drawing.Size(190, 20)
        Me.txtDespacho.TabIndex = 50
        Me.txtDespacho.Validator = WindowsApplication1.ValidatorType.None
        '
        'txtIVA21
        '
        Me.txtIVA21.Cleanable = True
        Me.txtIVA21.Empty = False
        Me.txtIVA21.EnterIndex = 17
        Me.txtIVA21.LabelAssociationKey = 19
        Me.txtIVA21.Location = New System.Drawing.Point(300, 133)
        Me.txtIVA21.Name = "txtIVA21"
        Me.txtIVA21.Size = New System.Drawing.Size(75, 20)
        Me.txtIVA21.TabIndex = 49
        Me.txtIVA21.Validator = WindowsApplication1.ValidatorType.Float
        '
        'txtIVA27
        '
        Me.txtIVA27.Cleanable = True
        Me.txtIVA27.Empty = False
        Me.txtIVA27.EnterIndex = 19
        Me.txtIVA27.LabelAssociationKey = 20
        Me.txtIVA27.Location = New System.Drawing.Point(300, 159)
        Me.txtIVA27.Name = "txtIVA27"
        Me.txtIVA27.Size = New System.Drawing.Size(75, 20)
        Me.txtIVA27.TabIndex = 48
        Me.txtIVA27.Validator = WindowsApplication1.ValidatorType.Float
        '
        'txtNoGravado
        '
        Me.txtNoGravado.Cleanable = True
        Me.txtNoGravado.Empty = False
        Me.txtNoGravado.EnterIndex = 21
        Me.txtNoGravado.LabelAssociationKey = 21
        Me.txtNoGravado.Location = New System.Drawing.Point(300, 185)
        Me.txtNoGravado.Name = "txtNoGravado"
        Me.txtNoGravado.Size = New System.Drawing.Size(75, 20)
        Me.txtNoGravado.TabIndex = 47
        Me.txtNoGravado.Validator = WindowsApplication1.ValidatorType.Float
        '
        'txtTotal
        '
        Me.txtTotal.Cleanable = True
        Me.txtTotal.Empty = False
        Me.txtTotal.EnterIndex = -1
        Me.txtTotal.LabelAssociationKey = 18
        Me.txtTotal.Location = New System.Drawing.Point(115, 211)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.ReadOnly = True
        Me.txtTotal.Size = New System.Drawing.Size(75, 20)
        Me.txtTotal.TabIndex = 46
        Me.txtTotal.Validator = WindowsApplication1.ValidatorType.Float
        '
        'txtNeto
        '
        Me.txtNeto.Cleanable = True
        Me.txtNeto.Empty = False
        Me.txtNeto.EnterIndex = 16
        Me.txtNeto.LabelAssociationKey = 15
        Me.txtNeto.Location = New System.Drawing.Point(115, 133)
        Me.txtNeto.Name = "txtNeto"
        Me.txtNeto.Size = New System.Drawing.Size(75, 20)
        Me.txtNeto.TabIndex = 45
        Me.txtNeto.Validator = WindowsApplication1.ValidatorType.Float
        '
        'txtIVARG
        '
        Me.txtIVARG.Cleanable = True
        Me.txtIVARG.Empty = False
        Me.txtIVARG.EnterIndex = 18
        Me.txtIVARG.LabelAssociationKey = 16
        Me.txtIVARG.Location = New System.Drawing.Point(115, 159)
        Me.txtIVARG.Name = "txtIVARG"
        Me.txtIVARG.Size = New System.Drawing.Size(75, 20)
        Me.txtIVARG.TabIndex = 44
        Me.txtIVARG.Validator = WindowsApplication1.ValidatorType.Float
        '
        'txtPercIB
        '
        Me.txtPercIB.Cleanable = True
        Me.txtPercIB.Empty = False
        Me.txtPercIB.EnterIndex = 20
        Me.txtPercIB.LabelAssociationKey = 17
        Me.txtPercIB.Location = New System.Drawing.Point(115, 185)
        Me.txtPercIB.Name = "txtPercIB"
        Me.txtPercIB.Size = New System.Drawing.Size(75, 20)
        Me.txtPercIB.TabIndex = 43
        Me.txtPercIB.Validator = WindowsApplication1.ValidatorType.Float
        '
        'txtParidad
        '
        Me.txtParidad.Cleanable = True
        Me.txtParidad.Empty = True
        Me.txtParidad.Enabled = False
        Me.txtParidad.EnterIndex = 15
        Me.txtParidad.LabelAssociationKey = 14
        Me.txtParidad.Location = New System.Drawing.Point(559, 101)
        Me.txtParidad.Name = "txtParidad"
        Me.txtParidad.Size = New System.Drawing.Size(71, 20)
        Me.txtParidad.TabIndex = 42
        Me.txtParidad.Validator = WindowsApplication1.ValidatorType.PositiveFloat
        '
        'cmbFormaPago
        '
        Me.cmbFormaPago.Cleanable = True
        Me.cmbFormaPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFormaPago.Empty = False
        Me.cmbFormaPago.EnterIndex = 14
        Me.cmbFormaPago.FormattingEnabled = True
        Me.cmbFormaPago.Items.AddRange(New Object() {"", "Pesos", "Cláusula Dólar"})
        Me.cmbFormaPago.LabelAssociationKey = 13
        Me.cmbFormaPago.Location = New System.Drawing.Point(347, 99)
        Me.cmbFormaPago.Name = "cmbFormaPago"
        Me.cmbFormaPago.Size = New System.Drawing.Size(157, 21)
        Me.cmbFormaPago.TabIndex = 41
        Me.cmbFormaPago.Validator = WindowsApplication1.ValidatorType.None
        '
        'txtFechaVto2
        '
        Me.txtFechaVto2.Cleanable = True
        Me.txtFechaVto2.Empty = False
        Me.txtFechaVto2.EnterIndex = 13
        Me.txtFechaVto2.LabelAssociationKey = 12
        Me.txtFechaVto2.Location = New System.Drawing.Point(181, 100)
        Me.txtFechaVto2.MaxLength = 10
        Me.txtFechaVto2.Name = "txtFechaVto2"
        Me.txtFechaVto2.Size = New System.Drawing.Size(75, 20)
        Me.txtFechaVto2.TabIndex = 40
        Me.txtFechaVto2.Validator = WindowsApplication1.ValidatorType.DateFormat
        '
        'txtRemito
        '
        Me.txtRemito.Cleanable = True
        Me.txtRemito.Empty = True
        Me.txtRemito.EnterIndex = 11
        Me.txtRemito.LabelAssociationKey = 11
        Me.txtRemito.Location = New System.Drawing.Point(367, 74)
        Me.txtRemito.MaxLength = 30
        Me.txtRemito.Name = "txtRemito"
        Me.txtRemito.Size = New System.Drawing.Size(191, 20)
        Me.txtRemito.TabIndex = 39
        Me.txtRemito.Validator = WindowsApplication1.ValidatorType.None
        '
        'txtFechaIVA
        '
        Me.txtFechaIVA.Cleanable = True
        Me.txtFechaIVA.Empty = False
        Me.txtFechaIVA.EnterIndex = 10
        Me.txtFechaIVA.LabelAssociationKey = 10
        Me.txtFechaIVA.Location = New System.Drawing.Point(243, 74)
        Me.txtFechaIVA.MaxLength = 10
        Me.txtFechaIVA.Name = "txtFechaIVA"
        Me.txtFechaIVA.Size = New System.Drawing.Size(75, 20)
        Me.txtFechaIVA.TabIndex = 38
        Me.txtFechaIVA.Validator = WindowsApplication1.ValidatorType.DateFormat
        '
        'txtFechaVto1
        '
        Me.txtFechaVto1.Cleanable = True
        Me.txtFechaVto1.Empty = False
        Me.txtFechaVto1.EnterIndex = 12
        Me.txtFechaVto1.LabelAssociationKey = 12
        Me.txtFechaVto1.Location = New System.Drawing.Point(100, 100)
        Me.txtFechaVto1.MaxLength = 10
        Me.txtFechaVto1.Name = "txtFechaVto1"
        Me.txtFechaVto1.Size = New System.Drawing.Size(75, 20)
        Me.txtFechaVto1.TabIndex = 37
        Me.txtFechaVto1.Validator = WindowsApplication1.ValidatorType.DateFormat
        '
        'txtFechaEmision
        '
        Me.txtFechaEmision.Cleanable = True
        Me.txtFechaEmision.Empty = False
        Me.txtFechaEmision.EnterIndex = 9
        Me.txtFechaEmision.LabelAssociationKey = 9
        Me.txtFechaEmision.Location = New System.Drawing.Point(100, 74)
        Me.txtFechaEmision.MaxLength = 10
        Me.txtFechaEmision.Name = "txtFechaEmision"
        Me.txtFechaEmision.Size = New System.Drawing.Size(75, 20)
        Me.txtFechaEmision.TabIndex = 36
        Me.txtFechaEmision.Validator = WindowsApplication1.ValidatorType.DateFormat
        '
        'txtCAI
        '
        Me.txtCAI.Cleanable = True
        Me.txtCAI.Empty = True
        Me.txtCAI.EnterIndex = 3
        Me.txtCAI.LabelAssociationKey = 3
        Me.txtCAI.Location = New System.Drawing.Point(599, 17)
        Me.txtCAI.MaxLength = 14
        Me.txtCAI.Name = "txtCAI"
        Me.txtCAI.Size = New System.Drawing.Size(118, 20)
        Me.txtCAI.TabIndex = 35
        Me.txtCAI.Validator = WindowsApplication1.ValidatorType.None
        '
        'txtVtoCAI
        '
        Me.txtVtoCAI.Cleanable = True
        Me.txtVtoCAI.Empty = True
        Me.txtVtoCAI.EnterIndex = 8
        Me.txtVtoCAI.LabelAssociationKey = 8
        Me.txtVtoCAI.Location = New System.Drawing.Point(630, 44)
        Me.txtVtoCAI.MaxLength = 10
        Me.txtVtoCAI.Name = "txtVtoCAI"
        Me.txtVtoCAI.Size = New System.Drawing.Size(75, 20)
        Me.txtVtoCAI.TabIndex = 34
        Me.txtVtoCAI.Validator = WindowsApplication1.ValidatorType.DateFormat
        '
        'txtNumero
        '
        Me.txtNumero.Cleanable = True
        Me.txtNumero.Empty = False
        Me.txtNumero.EnterIndex = 7
        Me.txtNumero.LabelAssociationKey = 7
        Me.txtNumero.Location = New System.Drawing.Point(397, 45)
        Me.txtNumero.MaxLength = 8
        Me.txtNumero.Name = "txtNumero"
        Me.txtNumero.Size = New System.Drawing.Size(91, 20)
        Me.txtNumero.TabIndex = 33
        Me.txtNumero.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtNumero.Validator = WindowsApplication1.ValidatorType.Numeric
        '
        'txtPunto
        '
        Me.txtPunto.Cleanable = True
        Me.txtPunto.Empty = False
        Me.txtPunto.EnterIndex = 6
        Me.txtPunto.LabelAssociationKey = 6
        Me.txtPunto.Location = New System.Drawing.Point(277, 44)
        Me.txtPunto.MaxLength = 4
        Me.txtPunto.Name = "txtPunto"
        Me.txtPunto.Size = New System.Drawing.Size(64, 20)
        Me.txtPunto.TabIndex = 32
        Me.txtPunto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtPunto.Validator = WindowsApplication1.ValidatorType.Numeric
        '
        'txtLetra
        '
        Me.txtLetra.Cleanable = True
        Me.txtLetra.Empty = False
        Me.txtLetra.EnterIndex = 5
        Me.txtLetra.LabelAssociationKey = 5
        Me.txtLetra.Location = New System.Drawing.Point(197, 44)
        Me.txtLetra.MaxLength = 1
        Me.txtLetra.Name = "txtLetra"
        Me.txtLetra.Size = New System.Drawing.Size(33, 20)
        Me.txtLetra.TabIndex = 31
        Me.txtLetra.Validator = WindowsApplication1.ValidatorType.None
        '
        'cmbTipo
        '
        Me.cmbTipo.Cleanable = True
        Me.cmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipo.Empty = False
        Me.cmbTipo.EnterIndex = -1
        Me.cmbTipo.FormattingEnabled = True
        Me.cmbTipo.Items.AddRange(New Object() {"FC", "ND", "NC"})
        Me.cmbTipo.LabelAssociationKey = 4
        Me.cmbTipo.Location = New System.Drawing.Point(86, 43)
        Me.cmbTipo.Name = "cmbTipo"
        Me.cmbTipo.Size = New System.Drawing.Size(68, 21)
        Me.cmbTipo.TabIndex = 30
        Me.cmbTipo.Validator = WindowsApplication1.ValidatorType.None
        '
        'txtTipo
        '
        Me.txtTipo.Cleanable = True
        Me.txtTipo.Empty = False
        Me.txtTipo.EnterIndex = 4
        Me.txtTipo.LabelAssociationKey = 4
        Me.txtTipo.Location = New System.Drawing.Point(57, 44)
        Me.txtTipo.MaxLength = 2
        Me.txtTipo.Name = "txtTipo"
        Me.txtTipo.Size = New System.Drawing.Size(26, 20)
        Me.txtTipo.TabIndex = 29
        Me.txtTipo.Validator = WindowsApplication1.ValidatorType.None
        '
        'txtNombreProveedor
        '
        Me.txtNombreProveedor.Cleanable = True
        Me.txtNombreProveedor.Empty = False
        Me.txtNombreProveedor.Enabled = False
        Me.txtNombreProveedor.EnterIndex = -1
        Me.txtNombreProveedor.LabelAssociationKey = 2
        Me.txtNombreProveedor.Location = New System.Drawing.Point(313, 17)
        Me.txtNombreProveedor.Name = "txtNombreProveedor"
        Me.txtNombreProveedor.Size = New System.Drawing.Size(241, 20)
        Me.txtNombreProveedor.TabIndex = 28
        Me.txtNombreProveedor.Validator = WindowsApplication1.ValidatorType.None
        '
        'txtCodigoProveedor
        '
        Me.txtCodigoProveedor.Cleanable = True
        Me.txtCodigoProveedor.Empty = False
        Me.txtCodigoProveedor.EnterIndex = 2
        Me.txtCodigoProveedor.LabelAssociationKey = 2
        Me.txtCodigoProveedor.Location = New System.Drawing.Point(231, 17)
        Me.txtCodigoProveedor.MaxLength = 11
        Me.txtCodigoProveedor.Name = "txtCodigoProveedor"
        Me.txtCodigoProveedor.Size = New System.Drawing.Size(76, 20)
        Me.txtCodigoProveedor.TabIndex = 27
        Me.txtCodigoProveedor.Validator = WindowsApplication1.ValidatorType.None
        '
        'txtNroInterno
        '
        Me.txtNroInterno.Cleanable = True
        Me.txtNroInterno.Empty = True
        Me.txtNroInterno.EnterIndex = 1
        Me.txtNroInterno.LabelAssociationKey = 1
        Me.txtNroInterno.Location = New System.Drawing.Point(89, 17)
        Me.txtNroInterno.Name = "txtNroInterno"
        Me.txtNroInterno.Size = New System.Drawing.Size(74, 20)
        Me.txtNroInterno.TabIndex = 26
        Me.txtNroInterno.Validator = WindowsApplication1.ValidatorType.Numeric
        '
        'CustomLabel23
        '
        Me.CustomLabel23.AutoSize = True
        Me.CustomLabel23.ControlAssociationKey = 22
        Me.CustomLabel23.Location = New System.Drawing.Point(381, 136)
        Me.CustomLabel23.Name = "CustomLabel23"
        Me.CustomLabel23.Size = New System.Drawing.Size(56, 13)
        Me.CustomLabel23.TabIndex = 23
        Me.CustomLabel23.Text = "Despacho"
        '
        'CustomLabel22
        '
        Me.CustomLabel22.AutoSize = True
        Me.CustomLabel22.ControlAssociationKey = 23
        Me.CustomLabel22.Location = New System.Drawing.Point(381, 162)
        Me.CustomLabel22.Name = "CustomLabel22"
        Me.CustomLabel22.Size = New System.Drawing.Size(94, 13)
        Me.CustomLabel22.TabIndex = 22
        Me.CustomLabel22.Text = "Importe IVA 10.5%"
        '
        'CustomLabel21
        '
        Me.CustomLabel21.AutoSize = True
        Me.CustomLabel21.ControlAssociationKey = 21
        Me.CustomLabel21.Location = New System.Drawing.Point(196, 188)
        Me.CustomLabel21.Name = "CustomLabel21"
        Me.CustomLabel21.Size = New System.Drawing.Size(103, 13)
        Me.CustomLabel21.TabIndex = 21
        Me.CustomLabel21.Text = "Importe No Gravado"
        '
        'CustomLabel20
        '
        Me.CustomLabel20.AutoSize = True
        Me.CustomLabel20.ControlAssociationKey = 20
        Me.CustomLabel20.Location = New System.Drawing.Point(196, 162)
        Me.CustomLabel20.Name = "CustomLabel20"
        Me.CustomLabel20.Size = New System.Drawing.Size(85, 13)
        Me.CustomLabel20.TabIndex = 20
        Me.CustomLabel20.Text = "Importe IVA 27%"
        '
        'CustomLabel19
        '
        Me.CustomLabel19.AutoSize = True
        Me.CustomLabel19.ControlAssociationKey = 18
        Me.CustomLabel19.Location = New System.Drawing.Point(20, 214)
        Me.CustomLabel19.Name = "CustomLabel19"
        Me.CustomLabel19.Size = New System.Drawing.Size(69, 13)
        Me.CustomLabel19.TabIndex = 19
        Me.CustomLabel19.Text = "Importe Total"
        '
        'CustomLabel18
        '
        Me.CustomLabel18.AutoSize = True
        Me.CustomLabel18.ControlAssociationKey = 17
        Me.CustomLabel18.Location = New System.Drawing.Point(20, 188)
        Me.CustomLabel18.Name = "CustomLabel18"
        Me.CustomLabel18.Size = New System.Drawing.Size(89, 13)
        Me.CustomLabel18.TabIndex = 18
        Me.CustomLabel18.Text = "Importe Perc. I.B."
        '
        'CustomLabel17
        '
        Me.CustomLabel17.AutoSize = True
        Me.CustomLabel17.ControlAssociationKey = 16
        Me.CustomLabel17.Location = New System.Drawing.Point(20, 162)
        Me.CustomLabel17.Name = "CustomLabel17"
        Me.CustomLabel17.Size = New System.Drawing.Size(76, 13)
        Me.CustomLabel17.TabIndex = 17
        Me.CustomLabel17.Text = "IVA R.G. 3337"
        '
        'CustomLabel16
        '
        Me.CustomLabel16.AutoSize = True
        Me.CustomLabel16.ControlAssociationKey = 19
        Me.CustomLabel16.Location = New System.Drawing.Point(196, 136)
        Me.CustomLabel16.Name = "CustomLabel16"
        Me.CustomLabel16.Size = New System.Drawing.Size(85, 13)
        Me.CustomLabel16.TabIndex = 16
        Me.CustomLabel16.Text = "Importe IVA 21%"
        '
        'CustomLabel15
        '
        Me.CustomLabel15.AutoSize = True
        Me.CustomLabel15.ControlAssociationKey = 15
        Me.CustomLabel15.Location = New System.Drawing.Point(20, 136)
        Me.CustomLabel15.Name = "CustomLabel15"
        Me.CustomLabel15.Size = New System.Drawing.Size(68, 13)
        Me.CustomLabel15.TabIndex = 15
        Me.CustomLabel15.Text = "Importe Neto"
        '
        'CustomLabel14
        '
        Me.CustomLabel14.AutoSize = True
        Me.CustomLabel14.ControlAssociationKey = 14
        Me.CustomLabel14.Location = New System.Drawing.Point(510, 104)
        Me.CustomLabel14.Name = "CustomLabel14"
        Me.CustomLabel14.Size = New System.Drawing.Size(43, 13)
        Me.CustomLabel14.TabIndex = 14
        Me.CustomLabel14.Text = "Paridad"
        '
        'CustomLabel13
        '
        Me.CustomLabel13.AutoSize = True
        Me.CustomLabel13.ControlAssociationKey = 13
        Me.CustomLabel13.Location = New System.Drawing.Point(262, 103)
        Me.CustomLabel13.Name = "CustomLabel13"
        Me.CustomLabel13.Size = New System.Drawing.Size(79, 13)
        Me.CustomLabel13.TabIndex = 13
        Me.CustomLabel13.Text = "Forma de Pago"
        '
        'CustomLabel12
        '
        Me.CustomLabel12.AutoSize = True
        Me.CustomLabel12.ControlAssociationKey = 12
        Me.CustomLabel12.Location = New System.Drawing.Point(20, 104)
        Me.CustomLabel12.Name = "CustomLabel12"
        Me.CustomLabel12.Size = New System.Drawing.Size(59, 13)
        Me.CustomLabel12.TabIndex = 12
        Me.CustomLabel12.Text = "Fecha Vto."
        '
        'CustomLabel11
        '
        Me.CustomLabel11.AutoSize = True
        Me.CustomLabel11.ControlAssociationKey = 11
        Me.CustomLabel11.Location = New System.Drawing.Point(321, 77)
        Me.CustomLabel11.Name = "CustomLabel11"
        Me.CustomLabel11.Size = New System.Drawing.Size(40, 13)
        Me.CustomLabel11.TabIndex = 11
        Me.CustomLabel11.Text = "Remito"
        '
        'CustomLabel10
        '
        Me.CustomLabel10.AutoSize = True
        Me.CustomLabel10.ControlAssociationKey = 10
        Me.CustomLabel10.Location = New System.Drawing.Point(180, 77)
        Me.CustomLabel10.Name = "CustomLabel10"
        Me.CustomLabel10.Size = New System.Drawing.Size(57, 13)
        Me.CustomLabel10.TabIndex = 10
        Me.CustomLabel10.Text = "Fecha IVA"
        '
        'CustomLabel9
        '
        Me.CustomLabel9.AutoSize = True
        Me.CustomLabel9.ControlAssociationKey = 9
        Me.CustomLabel9.Location = New System.Drawing.Point(20, 77)
        Me.CustomLabel9.Name = "CustomLabel9"
        Me.CustomLabel9.Size = New System.Drawing.Size(76, 13)
        Me.CustomLabel9.TabIndex = 9
        Me.CustomLabel9.Text = "Fecha Emisión"
        '
        'CustomLabel8
        '
        Me.CustomLabel8.AutoSize = True
        Me.CustomLabel8.ControlAssociationKey = 8
        Me.CustomLabel8.Location = New System.Drawing.Point(569, 47)
        Me.CustomLabel8.Name = "CustomLabel8"
        Me.CustomLabel8.Size = New System.Drawing.Size(55, 13)
        Me.CustomLabel8.TabIndex = 8
        Me.CustomLabel8.Text = "Vto. C.A.I."
        '
        'CustomLabel7
        '
        Me.CustomLabel7.AutoSize = True
        Me.CustomLabel7.ControlAssociationKey = 7
        Me.CustomLabel7.Location = New System.Drawing.Point(347, 47)
        Me.CustomLabel7.Name = "CustomLabel7"
        Me.CustomLabel7.Size = New System.Drawing.Size(44, 13)
        Me.CustomLabel7.TabIndex = 6
        Me.CustomLabel7.Text = "Número"
        '
        'CustomLabel6
        '
        Me.CustomLabel6.AutoSize = True
        Me.CustomLabel6.ControlAssociationKey = 6
        Me.CustomLabel6.Location = New System.Drawing.Point(236, 47)
        Me.CustomLabel6.Name = "CustomLabel6"
        Me.CustomLabel6.Size = New System.Drawing.Size(35, 13)
        Me.CustomLabel6.TabIndex = 5
        Me.CustomLabel6.Text = "Punto"
        '
        'CustomLabel5
        '
        Me.CustomLabel5.AutoSize = True
        Me.CustomLabel5.ControlAssociationKey = 5
        Me.CustomLabel5.Location = New System.Drawing.Point(160, 47)
        Me.CustomLabel5.Name = "CustomLabel5"
        Me.CustomLabel5.Size = New System.Drawing.Size(31, 13)
        Me.CustomLabel5.TabIndex = 4
        Me.CustomLabel5.Text = "Letra"
        '
        'CustomLabel4
        '
        Me.CustomLabel4.AutoSize = True
        Me.CustomLabel4.ControlAssociationKey = 4
        Me.CustomLabel4.Location = New System.Drawing.Point(20, 47)
        Me.CustomLabel4.Name = "CustomLabel4"
        Me.CustomLabel4.Size = New System.Drawing.Size(28, 13)
        Me.CustomLabel4.TabIndex = 3
        Me.CustomLabel4.Text = "Tipo"
        '
        'CustomLabel3
        '
        Me.CustomLabel3.AutoSize = True
        Me.CustomLabel3.ControlAssociationKey = 3
        Me.CustomLabel3.Location = New System.Drawing.Point(560, 20)
        Me.CustomLabel3.Name = "CustomLabel3"
        Me.CustomLabel3.Size = New System.Drawing.Size(33, 13)
        Me.CustomLabel3.TabIndex = 2
        Me.CustomLabel3.Text = "C.A.I."
        '
        'CustomLabel2
        '
        Me.CustomLabel2.AutoSize = True
        Me.CustomLabel2.ControlAssociationKey = 2
        Me.CustomLabel2.Location = New System.Drawing.Point(169, 20)
        Me.CustomLabel2.Name = "CustomLabel2"
        Me.CustomLabel2.Size = New System.Drawing.Size(56, 13)
        Me.CustomLabel2.TabIndex = 1
        Me.CustomLabel2.Text = "Proveedor"
        '
        'CustomLabel1
        '
        Me.CustomLabel1.AutoSize = True
        Me.CustomLabel1.ControlAssociationKey = 1
        Me.CustomLabel1.Location = New System.Drawing.Point(20, 20)
        Me.CustomLabel1.Name = "CustomLabel1"
        Me.CustomLabel1.Size = New System.Drawing.Size(63, 13)
        Me.CustomLabel1.TabIndex = 0
        Me.CustomLabel1.Text = "Nro. Interno"
        '
        'Compras
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(790, 568)
        Me.Controls.Add(Me.lblCredito)
        Me.Controls.Add(Me.lblDebito)
        Me.Controls.Add(Me.btnApertura)
        Me.Controls.Add(Me.btnConsulta)
        Me.Controls.Add(Me.btnCerrar)
        Me.Controls.Add(Me.btnConsultaNroFactura)
        Me.Controls.Add(Me.btnLimpiar)
        Me.Controls.Add(Me.btnEliminar)
        Me.Controls.Add(Me.btnAgregar)
        Me.Controls.Add(Me.gridAsientos)
        Me.Controls.Add(Me.txtIVA10)
        Me.Controls.Add(Me.txtDespacho)
        Me.Controls.Add(Me.txtIVA21)
        Me.Controls.Add(Me.txtIVA27)
        Me.Controls.Add(Me.txtNoGravado)
        Me.Controls.Add(Me.txtTotal)
        Me.Controls.Add(Me.txtNeto)
        Me.Controls.Add(Me.txtIVARG)
        Me.Controls.Add(Me.txtPercIB)
        Me.Controls.Add(Me.txtParidad)
        Me.Controls.Add(Me.cmbFormaPago)
        Me.Controls.Add(Me.txtFechaVto2)
        Me.Controls.Add(Me.txtRemito)
        Me.Controls.Add(Me.txtFechaIVA)
        Me.Controls.Add(Me.txtFechaVto1)
        Me.Controls.Add(Me.txtFechaEmision)
        Me.Controls.Add(Me.txtCAI)
        Me.Controls.Add(Me.txtVtoCAI)
        Me.Controls.Add(Me.txtNumero)
        Me.Controls.Add(Me.txtPunto)
        Me.Controls.Add(Me.txtLetra)
        Me.Controls.Add(Me.cmbTipo)
        Me.Controls.Add(Me.txtTipo)
        Me.Controls.Add(Me.txtNombreProveedor)
        Me.Controls.Add(Me.txtCodigoProveedor)
        Me.Controls.Add(Me.txtNroInterno)
        Me.Controls.Add(Me.gbTipo)
        Me.Controls.Add(Me.chkSoloIVA)
        Me.Controls.Add(Me.CustomLabel23)
        Me.Controls.Add(Me.CustomLabel22)
        Me.Controls.Add(Me.CustomLabel21)
        Me.Controls.Add(Me.CustomLabel20)
        Me.Controls.Add(Me.CustomLabel19)
        Me.Controls.Add(Me.CustomLabel18)
        Me.Controls.Add(Me.CustomLabel17)
        Me.Controls.Add(Me.CustomLabel16)
        Me.Controls.Add(Me.CustomLabel15)
        Me.Controls.Add(Me.CustomLabel14)
        Me.Controls.Add(Me.CustomLabel13)
        Me.Controls.Add(Me.CustomLabel12)
        Me.Controls.Add(Me.CustomLabel11)
        Me.Controls.Add(Me.CustomLabel10)
        Me.Controls.Add(Me.CustomLabel9)
        Me.Controls.Add(Me.CustomLabel8)
        Me.Controls.Add(Me.CustomLabel7)
        Me.Controls.Add(Me.CustomLabel6)
        Me.Controls.Add(Me.CustomLabel5)
        Me.Controls.Add(Me.CustomLabel4)
        Me.Controls.Add(Me.CustomLabel3)
        Me.Controls.Add(Me.CustomLabel2)
        Me.Controls.Add(Me.CustomLabel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.Name = "Compras"
        Me.Text = "Ingreso de Comprobantes de Proveedores"
        Me.gbTipo.ResumeLayout(False)
        Me.gbTipo.PerformLayout()
        CType(Me.gridAsientos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CustomLabel1 As WindowsApplication1.CustomLabel
    Friend WithEvents CustomLabel2 As WindowsApplication1.CustomLabel
    Friend WithEvents CustomLabel3 As WindowsApplication1.CustomLabel
    Friend WithEvents CustomLabel4 As WindowsApplication1.CustomLabel
    Friend WithEvents CustomLabel5 As WindowsApplication1.CustomLabel
    Friend WithEvents CustomLabel6 As WindowsApplication1.CustomLabel
    Friend WithEvents CustomLabel7 As WindowsApplication1.CustomLabel
    Friend WithEvents CustomLabel8 As WindowsApplication1.CustomLabel
    Friend WithEvents CustomLabel9 As WindowsApplication1.CustomLabel
    Friend WithEvents CustomLabel10 As WindowsApplication1.CustomLabel
    Friend WithEvents CustomLabel11 As WindowsApplication1.CustomLabel
    Friend WithEvents CustomLabel12 As WindowsApplication1.CustomLabel
    Friend WithEvents CustomLabel13 As WindowsApplication1.CustomLabel
    Friend WithEvents CustomLabel14 As WindowsApplication1.CustomLabel
    Friend WithEvents CustomLabel15 As WindowsApplication1.CustomLabel
    Friend WithEvents CustomLabel16 As WindowsApplication1.CustomLabel
    Friend WithEvents CustomLabel17 As WindowsApplication1.CustomLabel
    Friend WithEvents CustomLabel18 As WindowsApplication1.CustomLabel
    Friend WithEvents CustomLabel19 As WindowsApplication1.CustomLabel
    Friend WithEvents CustomLabel20 As WindowsApplication1.CustomLabel
    Friend WithEvents CustomLabel21 As WindowsApplication1.CustomLabel
    Friend WithEvents CustomLabel22 As WindowsApplication1.CustomLabel
    Friend WithEvents CustomLabel23 As WindowsApplication1.CustomLabel
    Friend WithEvents chkSoloIVA As System.Windows.Forms.CheckBox
    Friend WithEvents gbTipo As System.Windows.Forms.GroupBox
    Friend WithEvents optNacion As System.Windows.Forms.RadioButton
    Friend WithEvents optCtaCte As System.Windows.Forms.RadioButton
    Friend WithEvents optEfectivo As System.Windows.Forms.RadioButton
    Friend WithEvents txtNroInterno As WindowsApplication1.CustomTextBox
    Friend WithEvents txtCodigoProveedor As WindowsApplication1.CustomTextBox
    Friend WithEvents txtNombreProveedor As WindowsApplication1.CustomTextBox
    Friend WithEvents txtTipo As WindowsApplication1.CustomTextBox
    Friend WithEvents cmbTipo As WindowsApplication1.CustomComboBox
    Friend WithEvents txtLetra As WindowsApplication1.CustomTextBox
    Friend WithEvents txtPunto As WindowsApplication1.CustomTextBox
    Friend WithEvents txtNumero As WindowsApplication1.CustomTextBox
    Friend WithEvents txtVtoCAI As WindowsApplication1.CustomTextBox
    Friend WithEvents txtCAI As WindowsApplication1.CustomTextBox
    Friend WithEvents txtFechaEmision As WindowsApplication1.CustomTextBox
    Friend WithEvents txtFechaVto1 As WindowsApplication1.CustomTextBox
    Friend WithEvents txtFechaIVA As WindowsApplication1.CustomTextBox
    Friend WithEvents txtRemito As WindowsApplication1.CustomTextBox
    Friend WithEvents txtFechaVto2 As WindowsApplication1.CustomTextBox
    Friend WithEvents cmbFormaPago As WindowsApplication1.CustomComboBox
    Friend WithEvents txtParidad As WindowsApplication1.CustomTextBox
    Friend WithEvents txtPercIB As WindowsApplication1.CustomTextBox
    Friend WithEvents txtIVARG As WindowsApplication1.CustomTextBox
    Friend WithEvents txtNeto As WindowsApplication1.CustomTextBox
    Friend WithEvents txtTotal As WindowsApplication1.CustomTextBox
    Friend WithEvents txtIVA21 As WindowsApplication1.CustomTextBox
    Friend WithEvents txtIVA27 As WindowsApplication1.CustomTextBox
    Friend WithEvents txtNoGravado As WindowsApplication1.CustomTextBox
    Friend WithEvents txtDespacho As WindowsApplication1.CustomTextBox
    Friend WithEvents txtIVA10 As WindowsApplication1.CustomTextBox
    Friend WithEvents gridAsientos As System.Windows.Forms.DataGridView
    Friend WithEvents btnCerrar As WindowsApplication1.CustomButton
    Friend WithEvents btnConsultaNroFactura As WindowsApplication1.CustomButton
    Friend WithEvents btnLimpiar As WindowsApplication1.CustomButton
    Friend WithEvents btnEliminar As WindowsApplication1.CustomButton
    Friend WithEvents btnAgregar As WindowsApplication1.CustomButton
    Friend WithEvents btnConsulta As WindowsApplication1.CustomButton
    Friend WithEvents btnApertura As WindowsApplication1.CustomButton
    Friend WithEvents Cuenta As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Descripcion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Debito As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Credito As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblDebito As WindowsApplication1.CustomLabel
    Friend WithEvents lblCredito As WindowsApplication1.CustomLabel
End Class
