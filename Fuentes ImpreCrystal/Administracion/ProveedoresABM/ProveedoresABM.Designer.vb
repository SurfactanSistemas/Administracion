<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ProveedoresABM
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
        Me.cmbCalificacion = New WindowsApplication1.CustomComboBox()
        Me.cmbEstado = New WindowsApplication1.CustomComboBox()
        Me.cmbCertificados = New WindowsApplication1.CustomComboBox()
        Me.txtCalificacion = New WindowsApplication1.CustomTextBox()
        Me.txtCertificados = New WindowsApplication1.CustomTextBox()
        Me.txtCAIVto = New WindowsApplication1.CustomTextBox()
        Me.txtCAI = New WindowsApplication1.CustomTextBox()
        Me.btnCUFE = New WindowsApplication1.CustomButton()
        Me.btnObservaciones = New WindowsApplication1.CustomButton()
        Me.CustomLabel29 = New WindowsApplication1.CustomLabel()
        Me.CustomLabel28 = New WindowsApplication1.CustomLabel()
        Me.CustomLabel27 = New WindowsApplication1.CustomLabel()
        Me.CustomLabel26 = New WindowsApplication1.CustomLabel()
        Me.CustomLabel25 = New WindowsApplication1.CustomLabel()
        Me.txtNroSEDRONAR2 = New WindowsApplication1.CustomTextBox()
        Me.txtCategoria = New WindowsApplication1.CustomTextBox()
        Me.txtNroSEDRONAR1 = New WindowsApplication1.CustomTextBox()
        Me.txtPorcelCABA = New WindowsApplication1.CustomTextBox()
        Me.txtPorcelProv = New WindowsApplication1.CustomTextBox()
        Me.txtNroIB = New WindowsApplication1.CustomTextBox()
        Me.txtCheque = New WindowsApplication1.CustomTextBox()
        Me.txtCuentaDescripcion = New WindowsApplication1.CustomTextBox()
        Me.txtCuenta = New WindowsApplication1.CustomTextBox()
        Me.cmbInscripcionIB = New WindowsApplication1.CustomComboBox()
        Me.cmbCategoria2 = New WindowsApplication1.CustomComboBox()
        Me.cmbCategoria1 = New WindowsApplication1.CustomComboBox()
        Me.cmbCondicionIB2 = New WindowsApplication1.CustomComboBox()
        Me.cmbCondicionIB1 = New WindowsApplication1.CustomComboBox()
        Me.cmbRubro = New WindowsApplication1.CustomComboBox()
        Me.cmbIVA = New WindowsApplication1.CustomComboBox()
        Me.CustomLabel24 = New WindowsApplication1.CustomLabel()
        Me.txtDiasPlazo = New WindowsApplication1.CustomTextBox()
        Me.CustomLabel23 = New WindowsApplication1.CustomLabel()
        Me.CustomLabel22 = New WindowsApplication1.CustomLabel()
        Me.cmbTipoProveedor = New WindowsApplication1.CustomComboBox()
        Me.txtCUIT = New WindowsApplication1.CustomTextBox()
        Me.txtObservaciones = New WindowsApplication1.CustomTextBox()
        Me.cmbRegion = New WindowsApplication1.CustomComboBox()
        Me.txtCodigoPostal = New WindowsApplication1.CustomTextBox()
        Me.txtEmail = New WindowsApplication1.CustomTextBox()
        Me.txtTelefono = New WindowsApplication1.CustomTextBox()
        Me.cmbProvincia = New WindowsApplication1.CustomComboBox()
        Me.txtLocalidad = New WindowsApplication1.CustomTextBox()
        Me.txtDireccion = New WindowsApplication1.CustomTextBox()
        Me.txtRazonSocial = New WindowsApplication1.CustomTextBox()
        Me.txtCodigo = New WindowsApplication1.CustomTextBox()
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
        Me.SuspendLayout()
        '
        'cmbCalificacion
        '
        Me.cmbCalificacion.Cleanable = True
        Me.cmbCalificacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCalificacion.Empty = True
        Me.cmbCalificacion.EnterIndex = 34
        Me.cmbCalificacion.FormattingEnabled = True
        Me.cmbCalificacion.Items.AddRange(New Object() {"", "Apto", "Condicional", "No Apto"})
        Me.cmbCalificacion.LabelAssociationKey = 29
        Me.cmbCalificacion.Location = New System.Drawing.Point(456, 438)
        Me.cmbCalificacion.Name = "cmbCalificacion"
        Me.cmbCalificacion.Size = New System.Drawing.Size(135, 21)
        Me.cmbCalificacion.TabIndex = 66
        Me.cmbCalificacion.Validator = WindowsApplication1.ValidatorType.None
        '
        'cmbEstado
        '
        Me.cmbEstado.Cleanable = True
        Me.cmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEstado.Empty = True
        Me.cmbEstado.EnterIndex = 33
        Me.cmbEstado.FormattingEnabled = True
        Me.cmbEstado.Items.AddRange(New Object() {"", "Habilitado", "Inhabilitado"})
        Me.cmbEstado.LabelAssociationKey = 28
        Me.cmbEstado.Location = New System.Drawing.Point(456, 411)
        Me.cmbEstado.Name = "cmbEstado"
        Me.cmbEstado.Size = New System.Drawing.Size(135, 21)
        Me.cmbEstado.TabIndex = 65
        Me.cmbEstado.Validator = WindowsApplication1.ValidatorType.None
        '
        'cmbCertificados
        '
        Me.cmbCertificados.Cleanable = True
        Me.cmbCertificados.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCertificados.Empty = True
        Me.cmbCertificados.EnterIndex = 31
        Me.cmbCertificados.FormattingEnabled = True
        Me.cmbCertificados.Items.AddRange(New Object() {"", "ISO 9001", "ISO 9001/14001", "ISO 17025", "SENASA"})
        Me.cmbCertificados.LabelAssociationKey = 27
        Me.cmbCertificados.Location = New System.Drawing.Point(456, 384)
        Me.cmbCertificados.Name = "cmbCertificados"
        Me.cmbCertificados.Size = New System.Drawing.Size(135, 21)
        Me.cmbCertificados.TabIndex = 64
        Me.cmbCertificados.Validator = WindowsApplication1.ValidatorType.None
        '
        'txtCalificacion
        '
        Me.txtCalificacion.Cleanable = True
        Me.txtCalificacion.Empty = True
        Me.txtCalificacion.EnterIndex = 35
        Me.txtCalificacion.LabelAssociationKey = 29
        Me.txtCalificacion.Location = New System.Drawing.Point(615, 432)
        Me.txtCalificacion.MaxLength = 10
        Me.txtCalificacion.Name = "txtCalificacion"
        Me.txtCalificacion.Size = New System.Drawing.Size(122, 20)
        Me.txtCalificacion.TabIndex = 63
        Me.txtCalificacion.Validator = WindowsApplication1.ValidatorType.DateFormat
        '
        'txtCertificados
        '
        Me.txtCertificados.Cleanable = True
        Me.txtCertificados.Empty = True
        Me.txtCertificados.EnterIndex = 32
        Me.txtCertificados.LabelAssociationKey = 27
        Me.txtCertificados.Location = New System.Drawing.Point(615, 387)
        Me.txtCertificados.MaxLength = 10
        Me.txtCertificados.Name = "txtCertificados"
        Me.txtCertificados.Size = New System.Drawing.Size(122, 20)
        Me.txtCertificados.TabIndex = 62
        Me.txtCertificados.Validator = WindowsApplication1.ValidatorType.DateFormat
        '
        'txtCAIVto
        '
        Me.txtCAIVto.Cleanable = True
        Me.txtCAIVto.Empty = True
        Me.txtCAIVto.EnterIndex = 30
        Me.txtCAIVto.LabelAssociationKey = 26
        Me.txtCAIVto.Location = New System.Drawing.Point(629, 357)
        Me.txtCAIVto.MaxLength = 10
        Me.txtCAIVto.Name = "txtCAIVto"
        Me.txtCAIVto.Size = New System.Drawing.Size(122, 20)
        Me.txtCAIVto.TabIndex = 61
        Me.txtCAIVto.Validator = WindowsApplication1.ValidatorType.DateFormat
        '
        'txtCAI
        '
        Me.txtCAI.Cleanable = True
        Me.txtCAI.Empty = True
        Me.txtCAI.EnterIndex = 29
        Me.txtCAI.LabelAssociationKey = 25
        Me.txtCAI.Location = New System.Drawing.Point(433, 357)
        Me.txtCAI.Name = "txtCAI"
        Me.txtCAI.Size = New System.Drawing.Size(122, 20)
        Me.txtCAI.TabIndex = 60
        Me.txtCAI.Validator = WindowsApplication1.ValidatorType.None
        '
        'btnCUFE
        '
        Me.btnCUFE.Cleanable = False
        Me.btnCUFE.EnterIndex = -1
        Me.btnCUFE.LabelAssociationKey = -1
        Me.btnCUFE.Location = New System.Drawing.Point(591, 459)
        Me.btnCUFE.Name = "btnCUFE"
        Me.btnCUFE.Size = New System.Drawing.Size(104, 25)
        Me.btnCUFE.TabIndex = 59
        Me.btnCUFE.Text = "CUFE"
        Me.btnCUFE.UseVisualStyleBackColor = True
        '
        'btnObservaciones
        '
        Me.btnObservaciones.Cleanable = False
        Me.btnObservaciones.EnterIndex = -1
        Me.btnObservaciones.LabelAssociationKey = -1
        Me.btnObservaciones.Location = New System.Drawing.Point(383, 459)
        Me.btnObservaciones.Name = "btnObservaciones"
        Me.btnObservaciones.Size = New System.Drawing.Size(104, 25)
        Me.btnObservaciones.TabIndex = 58
        Me.btnObservaciones.Text = "Observaciones"
        Me.btnObservaciones.UseVisualStyleBackColor = True
        '
        'CustomLabel29
        '
        Me.CustomLabel29.AutoSize = True
        Me.CustomLabel29.ControlAssociationKey = 29
        Me.CustomLabel29.Location = New System.Drawing.Point(381, 432)
        Me.CustomLabel29.Name = "CustomLabel29"
        Me.CustomLabel29.Size = New System.Drawing.Size(61, 13)
        Me.CustomLabel29.TabIndex = 57
        Me.CustomLabel29.Text = "Calificación"
        '
        'CustomLabel28
        '
        Me.CustomLabel28.AutoSize = True
        Me.CustomLabel28.ControlAssociationKey = 28
        Me.CustomLabel28.Location = New System.Drawing.Point(381, 409)
        Me.CustomLabel28.Name = "CustomLabel28"
        Me.CustomLabel28.Size = New System.Drawing.Size(40, 13)
        Me.CustomLabel28.TabIndex = 56
        Me.CustomLabel28.Text = "Estado"
        '
        'CustomLabel27
        '
        Me.CustomLabel27.AutoSize = True
        Me.CustomLabel27.ControlAssociationKey = 27
        Me.CustomLabel27.Location = New System.Drawing.Point(381, 387)
        Me.CustomLabel27.Name = "CustomLabel27"
        Me.CustomLabel27.Size = New System.Drawing.Size(62, 13)
        Me.CustomLabel27.TabIndex = 55
        Me.CustomLabel27.Text = "Certificados"
        '
        'CustomLabel26
        '
        Me.CustomLabel26.AutoSize = True
        Me.CustomLabel26.ControlAssociationKey = 26
        Me.CustomLabel26.Location = New System.Drawing.Point(573, 364)
        Me.CustomLabel26.Name = "CustomLabel26"
        Me.CustomLabel26.Size = New System.Drawing.Size(46, 13)
        Me.CustomLabel26.TabIndex = 54
        Me.CustomLabel26.Text = "Vto. CAI"
        '
        'CustomLabel25
        '
        Me.CustomLabel25.AutoSize = True
        Me.CustomLabel25.ControlAssociationKey = 25
        Me.CustomLabel25.Location = New System.Drawing.Point(380, 364)
        Me.CustomLabel25.Name = "CustomLabel25"
        Me.CustomLabel25.Size = New System.Drawing.Size(24, 13)
        Me.CustomLabel25.TabIndex = 53
        Me.CustomLabel25.Text = "CAI"
        '
        'txtNroSEDRONAR2
        '
        Me.txtNroSEDRONAR2.Cleanable = True
        Me.txtNroSEDRONAR2.Empty = True
        Me.txtNroSEDRONAR2.EnterIndex = 24
        Me.txtNroSEDRONAR2.LabelAssociationKey = 22
        Me.txtNroSEDRONAR2.Location = New System.Drawing.Point(641, 303)
        Me.txtNroSEDRONAR2.MaxLength = 10
        Me.txtNroSEDRONAR2.Name = "txtNroSEDRONAR2"
        Me.txtNroSEDRONAR2.Size = New System.Drawing.Size(58, 20)
        Me.txtNroSEDRONAR2.TabIndex = 52
        Me.txtNroSEDRONAR2.Validator = WindowsApplication1.ValidatorType.DateFormat
        '
        'txtCategoria
        '
        Me.txtCategoria.Cleanable = True
        Me.txtCategoria.Empty = True
        Me.txtCategoria.EnterIndex = 27
        Me.txtCategoria.LabelAssociationKey = 23
        Me.txtCategoria.Location = New System.Drawing.Point(357, 331)
        Me.txtCategoria.MaxLength = 10
        Me.txtCategoria.Name = "txtCategoria"
        Me.txtCategoria.Size = New System.Drawing.Size(85, 20)
        Me.txtCategoria.TabIndex = 51
        Me.txtCategoria.Validator = WindowsApplication1.ValidatorType.DateFormat
        '
        'txtNroSEDRONAR1
        '
        Me.txtNroSEDRONAR1.Cleanable = True
        Me.txtNroSEDRONAR1.Empty = True
        Me.txtNroSEDRONAR1.EnterIndex = 23
        Me.txtNroSEDRONAR1.LabelAssociationKey = 22
        Me.txtNroSEDRONAR1.Location = New System.Drawing.Point(507, 304)
        Me.txtNroSEDRONAR1.MaxLength = 15
        Me.txtNroSEDRONAR1.Name = "txtNroSEDRONAR1"
        Me.txtNroSEDRONAR1.Size = New System.Drawing.Size(58, 20)
        Me.txtNroSEDRONAR1.TabIndex = 50
        Me.txtNroSEDRONAR1.Validator = WindowsApplication1.ValidatorType.None
        '
        'txtPorcelCABA
        '
        Me.txtPorcelCABA.Cleanable = True
        Me.txtPorcelCABA.Empty = True
        Me.txtPorcelCABA.EnterIndex = 21
        Me.txtPorcelCABA.LabelAssociationKey = 20
        Me.txtPorcelCABA.Location = New System.Drawing.Point(705, 277)
        Me.txtPorcelCABA.MaxLength = 6
        Me.txtPorcelCABA.Name = "txtPorcelCABA"
        Me.txtPorcelCABA.Size = New System.Drawing.Size(58, 20)
        Me.txtPorcelCABA.TabIndex = 49
        Me.txtPorcelCABA.Validator = WindowsApplication1.ValidatorType.PositiveFloat
        '
        'txtPorcelProv
        '
        Me.txtPorcelProv.Cleanable = True
        Me.txtPorcelProv.Empty = True
        Me.txtPorcelProv.EnterIndex = 20
        Me.txtPorcelProv.LabelAssociationKey = 19
        Me.txtPorcelProv.Location = New System.Drawing.Point(539, 275)
        Me.txtPorcelProv.MaxLength = 6
        Me.txtPorcelProv.Name = "txtPorcelProv"
        Me.txtPorcelProv.Size = New System.Drawing.Size(58, 20)
        Me.txtPorcelProv.TabIndex = 48
        Me.txtPorcelProv.Validator = WindowsApplication1.ValidatorType.PositiveFloat
        '
        'txtNroIB
        '
        Me.txtNroIB.Cleanable = True
        Me.txtNroIB.Empty = True
        Me.txtNroIB.EnterIndex = 19
        Me.txtNroIB.LabelAssociationKey = 18
        Me.txtNroIB.Location = New System.Drawing.Point(384, 276)
        Me.txtNroIB.MaxLength = 20
        Me.txtNroIB.Name = "txtNroIB"
        Me.txtNroIB.Size = New System.Drawing.Size(58, 20)
        Me.txtNroIB.TabIndex = 47
        Me.txtNroIB.Validator = WindowsApplication1.ValidatorType.None
        '
        'txtCheque
        '
        Me.txtCheque.Cleanable = True
        Me.txtCheque.Empty = True
        Me.txtCheque.EnterIndex = 16
        Me.txtCheque.LabelAssociationKey = 16
        Me.txtCheque.Location = New System.Drawing.Point(131, 249)
        Me.txtCheque.MaxLength = 50
        Me.txtCheque.Name = "txtCheque"
        Me.txtCheque.Size = New System.Drawing.Size(311, 20)
        Me.txtCheque.TabIndex = 46
        Me.txtCheque.Validator = WindowsApplication1.ValidatorType.None
        '
        'txtCuentaDescripcion
        '
        Me.txtCuentaDescripcion.Cleanable = True
        Me.txtCuentaDescripcion.Empty = False
        Me.txtCuentaDescripcion.Enabled = False
        Me.txtCuentaDescripcion.EnterIndex = -1
        Me.txtCuentaDescripcion.LabelAssociationKey = 15
        Me.txtCuentaDescripcion.Location = New System.Drawing.Point(201, 226)
        Me.txtCuentaDescripcion.MaxLength = 50
        Me.txtCuentaDescripcion.Name = "txtCuentaDescripcion"
        Me.txtCuentaDescripcion.Size = New System.Drawing.Size(241, 20)
        Me.txtCuentaDescripcion.TabIndex = 45
        Me.txtCuentaDescripcion.Validator = WindowsApplication1.ValidatorType.None
        '
        'txtCuenta
        '
        Me.txtCuenta.Cleanable = True
        Me.txtCuenta.Empty = False
        Me.txtCuenta.EnterIndex = 15
        Me.txtCuenta.LabelAssociationKey = 15
        Me.txtCuenta.Location = New System.Drawing.Point(116, 226)
        Me.txtCuenta.MaxLength = 10
        Me.txtCuenta.Name = "txtCuenta"
        Me.txtCuenta.Size = New System.Drawing.Size(79, 20)
        Me.txtCuenta.TabIndex = 44
        Me.txtCuenta.Validator = WindowsApplication1.ValidatorType.NotEmpty
        '
        'cmbInscripcionIB
        '
        Me.cmbInscripcionIB.Cleanable = True
        Me.cmbInscripcionIB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbInscripcionIB.Empty = True
        Me.cmbInscripcionIB.EnterIndex = 28
        Me.cmbInscripcionIB.FormattingEnabled = True
        Me.cmbInscripcionIB.Items.AddRange(New Object() {"", "Local", "Conv. Multilateral", "No Inscripto", "Reg. Simplificado"})
        Me.cmbInscripcionIB.LabelAssociationKey = 24
        Me.cmbInscripcionIB.Location = New System.Drawing.Point(571, 329)
        Me.cmbInscripcionIB.Name = "cmbInscripcionIB"
        Me.cmbInscripcionIB.Size = New System.Drawing.Size(180, 21)
        Me.cmbInscripcionIB.TabIndex = 43
        Me.cmbInscripcionIB.Validator = WindowsApplication1.ValidatorType.None
        '
        'cmbCategoria2
        '
        Me.cmbCategoria2.Cleanable = True
        Me.cmbCategoria2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCategoria2.Empty = False
        Me.cmbCategoria2.EnterIndex = 26
        Me.cmbCategoria2.FormattingEnabled = True
        Me.cmbCategoria2.Items.AddRange(New Object() {"Sin Calificar", "Muy Bueno", "Bueno", "Regular", "Malo"})
        Me.cmbCategoria2.LabelAssociationKey = 23
        Me.cmbCategoria2.Location = New System.Drawing.Point(218, 330)
        Me.cmbCategoria2.Name = "cmbCategoria2"
        Me.cmbCategoria2.Size = New System.Drawing.Size(125, 21)
        Me.cmbCategoria2.TabIndex = 42
        Me.cmbCategoria2.Validator = WindowsApplication1.ValidatorType.None
        '
        'cmbCategoria1
        '
        Me.cmbCategoria1.Cleanable = True
        Me.cmbCategoria1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCategoria1.Empty = True
        Me.cmbCategoria1.EnterIndex = 25
        Me.cmbCategoria1.FormattingEnabled = True
        Me.cmbCategoria1.Items.AddRange(New Object() {"", "A", "B", "C", "E"})
        Me.cmbCategoria1.LabelAssociationKey = 23
        Me.cmbCategoria1.Location = New System.Drawing.Point(82, 330)
        Me.cmbCategoria1.Name = "cmbCategoria1"
        Me.cmbCategoria1.Size = New System.Drawing.Size(130, 21)
        Me.cmbCategoria1.TabIndex = 41
        Me.cmbCategoria1.Validator = WindowsApplication1.ValidatorType.None
        '
        'cmbCondicionIB2
        '
        Me.cmbCondicionIB2.Cleanable = True
        Me.cmbCondicionIB2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCondicionIB2.Empty = False
        Me.cmbCondicionIB2.EnterIndex = 18
        Me.cmbCondicionIB2.FormattingEnabled = True
        Me.cmbCondicionIB2.Items.AddRange(New Object() {"", "", "Exento", "Reteniente"})
        Me.cmbCondicionIB2.LabelAssociationKey = 17
        Me.cmbCondicionIB2.Location = New System.Drawing.Point(213, 276)
        Me.cmbCondicionIB2.Name = "cmbCondicionIB2"
        Me.cmbCondicionIB2.Size = New System.Drawing.Size(97, 21)
        Me.cmbCondicionIB2.TabIndex = 40
        Me.cmbCondicionIB2.Validator = WindowsApplication1.ValidatorType.None
        '
        'cmbCondicionIB1
        '
        Me.cmbCondicionIB1.Cleanable = True
        Me.cmbCondicionIB1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCondicionIB1.Empty = False
        Me.cmbCondicionIB1.EnterIndex = 17
        Me.cmbCondicionIB1.FormattingEnabled = True
        Me.cmbCondicionIB1.Items.AddRange(New Object() {"Bienes", "Servicio", "Exento", "Ciudad Normal", "Ciudad Riesgo"})
        Me.cmbCondicionIB1.LabelAssociationKey = 17
        Me.cmbCondicionIB1.Location = New System.Drawing.Point(100, 275)
        Me.cmbCondicionIB1.Name = "cmbCondicionIB1"
        Me.cmbCondicionIB1.Size = New System.Drawing.Size(107, 21)
        Me.cmbCondicionIB1.TabIndex = 39
        Me.cmbCondicionIB1.Validator = WindowsApplication1.ValidatorType.None
        '
        'cmbRubro
        '
        Me.cmbRubro.Cleanable = True
        Me.cmbRubro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbRubro.Empty = True
        Me.cmbRubro.EnterIndex = 22
        Me.cmbRubro.FormattingEnabled = True
        Me.cmbRubro.LabelAssociationKey = 21
        Me.cmbRubro.Location = New System.Drawing.Point(64, 304)
        Me.cmbRubro.Name = "cmbRubro"
        Me.cmbRubro.Size = New System.Drawing.Size(178, 21)
        Me.cmbRubro.TabIndex = 38
        Me.cmbRubro.Validator = WindowsApplication1.ValidatorType.None
        '
        'cmbIVA
        '
        Me.cmbIVA.Cleanable = True
        Me.cmbIVA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbIVA.Empty = True
        Me.cmbIVA.EnterIndex = 14
        Me.cmbIVA.FormattingEnabled = True
        Me.cmbIVA.Items.AddRange(New Object() {"No Inscripto", "Consumidor Final", "Resp.Inscripto", "Exento", "No Responsable", "Monotributo", "No Catalogado", ""})
        Me.cmbIVA.LabelAssociationKey = 14
        Me.cmbIVA.Location = New System.Drawing.Point(433, 198)
        Me.cmbIVA.Name = "cmbIVA"
        Me.cmbIVA.Size = New System.Drawing.Size(220, 21)
        Me.cmbIVA.TabIndex = 37
        Me.cmbIVA.Validator = WindowsApplication1.ValidatorType.None
        '
        'CustomLabel24
        '
        Me.CustomLabel24.AutoSize = True
        Me.CustomLabel24.ControlAssociationKey = 20
        Me.CustomLabel24.Location = New System.Drawing.Point(612, 278)
        Me.CustomLabel24.Name = "CustomLabel24"
        Me.CustomLabel24.Size = New System.Drawing.Size(87, 13)
        Me.CustomLabel24.TabIndex = 36
        Me.CustomLabel24.Text = "Porcel I.B. CABA"
        '
        'txtDiasPlazo
        '
        Me.txtDiasPlazo.Cleanable = True
        Me.txtDiasPlazo.Empty = True
        Me.txtDiasPlazo.EnterIndex = 9
        Me.txtDiasPlazo.LabelAssociationKey = 9
        Me.txtDiasPlazo.Location = New System.Drawing.Point(356, 110)
        Me.txtDiasPlazo.MaxLength = 20
        Me.txtDiasPlazo.Name = "txtDiasPlazo"
        Me.txtDiasPlazo.Size = New System.Drawing.Size(118, 20)
        Me.txtDiasPlazo.TabIndex = 35
        Me.txtDiasPlazo.Validator = WindowsApplication1.ValidatorType.None
        '
        'CustomLabel23
        '
        Me.CustomLabel23.AutoSize = True
        Me.CustomLabel23.ControlAssociationKey = 9
        Me.CustomLabel23.Location = New System.Drawing.Point(264, 115)
        Me.CustomLabel23.Name = "CustomLabel23"
        Me.CustomLabel23.Size = New System.Drawing.Size(74, 13)
        Me.CustomLabel23.TabIndex = 34
        Me.CustomLabel23.Text = "Días de Plazo"
        '
        'CustomLabel22
        '
        Me.CustomLabel22.AutoSize = True
        Me.CustomLabel22.ControlAssociationKey = 21
        Me.CustomLabel22.Location = New System.Drawing.Point(22, 306)
        Me.CustomLabel22.Name = "CustomLabel22"
        Me.CustomLabel22.Size = New System.Drawing.Size(36, 13)
        Me.CustomLabel22.TabIndex = 33
        Me.CustomLabel22.Text = "Rubro"
        '
        'cmbTipoProveedor
        '
        Me.cmbTipoProveedor.Cleanable = True
        Me.cmbTipoProveedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoProveedor.Empty = True
        Me.cmbTipoProveedor.EnterIndex = 13
        Me.cmbTipoProveedor.FormattingEnabled = True
        Me.cmbTipoProveedor.Items.AddRange(New Object() {"Bienes", "Servicios", "Alquileres", "Exento", "Despachante", "Locación de Obras", "Fletes", "Facturas (M)", ""})
        Me.cmbTipoProveedor.LabelAssociationKey = 13
        Me.cmbTipoProveedor.Location = New System.Drawing.Point(107, 193)
        Me.cmbTipoProveedor.Name = "cmbTipoProveedor"
        Me.cmbTipoProveedor.Size = New System.Drawing.Size(220, 21)
        Me.cmbTipoProveedor.TabIndex = 32
        Me.cmbTipoProveedor.Validator = WindowsApplication1.ValidatorType.None
        '
        'txtCUIT
        '
        Me.txtCUIT.Cleanable = True
        Me.txtCUIT.Empty = True
        Me.txtCUIT.EnterIndex = 12
        Me.txtCUIT.LabelAssociationKey = 12
        Me.txtCUIT.Location = New System.Drawing.Point(453, 162)
        Me.txtCUIT.MaxLength = 15
        Me.txtCUIT.Name = "txtCUIT"
        Me.txtCUIT.Size = New System.Drawing.Size(242, 20)
        Me.txtCUIT.TabIndex = 31
        Me.txtCUIT.Validator = WindowsApplication1.ValidatorType.None
        '
        'txtObservaciones
        '
        Me.txtObservaciones.Cleanable = True
        Me.txtObservaciones.Empty = True
        Me.txtObservaciones.EnterIndex = 11
        Me.txtObservaciones.LabelAssociationKey = 11
        Me.txtObservaciones.Location = New System.Drawing.Point(107, 162)
        Me.txtObservaciones.MaxLength = 50
        Me.txtObservaciones.Name = "txtObservaciones"
        Me.txtObservaciones.Size = New System.Drawing.Size(286, 20)
        Me.txtObservaciones.TabIndex = 30
        Me.txtObservaciones.Validator = WindowsApplication1.ValidatorType.None
        '
        'cmbRegion
        '
        Me.cmbRegion.Cleanable = True
        Me.cmbRegion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbRegion.Empty = False
        Me.cmbRegion.EnterIndex = 7
        Me.cmbRegion.FormattingEnabled = True
        Me.cmbRegion.Items.AddRange(New Object() {"Fuera Mercosur", "Mercosur"})
        Me.cmbRegion.LabelAssociationKey = 7
        Me.cmbRegion.Location = New System.Drawing.Point(549, 87)
        Me.cmbRegion.Name = "cmbRegion"
        Me.cmbRegion.Size = New System.Drawing.Size(123, 21)
        Me.cmbRegion.TabIndex = 29
        Me.cmbRegion.Validator = WindowsApplication1.ValidatorType.NotEmpty
        '
        'txtCodigoPostal
        '
        Me.txtCodigoPostal.Cleanable = True
        Me.txtCodigoPostal.Empty = True
        Me.txtCodigoPostal.EnterIndex = 6
        Me.txtCodigoPostal.LabelAssociationKey = 6
        Me.txtCodigoPostal.Location = New System.Drawing.Point(350, 84)
        Me.txtCodigoPostal.MaxLength = 4
        Me.txtCodigoPostal.Name = "txtCodigoPostal"
        Me.txtCodigoPostal.Size = New System.Drawing.Size(103, 20)
        Me.txtCodigoPostal.TabIndex = 28
        Me.txtCodigoPostal.Validator = WindowsApplication1.ValidatorType.Numeric
        '
        'txtEmail
        '
        Me.txtEmail.Cleanable = True
        Me.txtEmail.Empty = True
        Me.txtEmail.EnterIndex = 10
        Me.txtEmail.LabelAssociationKey = 10
        Me.txtEmail.Location = New System.Drawing.Point(96, 140)
        Me.txtEmail.MaxLength = 400
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(247, 20)
        Me.txtEmail.TabIndex = 27
        Me.txtEmail.Validator = WindowsApplication1.ValidatorType.None
        '
        'txtTelefono
        '
        Me.txtTelefono.Cleanable = True
        Me.txtTelefono.Empty = True
        Me.txtTelefono.EnterIndex = 8
        Me.txtTelefono.LabelAssociationKey = 8
        Me.txtTelefono.Location = New System.Drawing.Point(112, 115)
        Me.txtTelefono.MaxLength = 30
        Me.txtTelefono.Name = "txtTelefono"
        Me.txtTelefono.Size = New System.Drawing.Size(99, 20)
        Me.txtTelefono.TabIndex = 26
        Me.txtTelefono.Validator = WindowsApplication1.ValidatorType.None
        '
        'cmbProvincia
        '
        Me.cmbProvincia.Cleanable = True
        Me.cmbProvincia.DisplayMember = "asd"
        Me.cmbProvincia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbProvincia.Empty = True
        Me.cmbProvincia.EnterIndex = 5
        Me.cmbProvincia.FormattingEnabled = True
        Me.cmbProvincia.Items.AddRange(New Object() {"Capital Federal", "Buenos Aires", "Catamarca", "Cordoba", "Corrientes", "Chaco", "Chubut", "Entre Rios", "Formosa", "Jujuy", "La Pampa", "La Rioja", "Mendoza", "Misiones", "Neuquen", "Rio Negro", "Salta", "San Juan", "San Luis", "Santa Cruz", "Santa Fe", "Santiago del Estero", "Tucuman", "Tierra del Fuego", "Exterior"})
        Me.cmbProvincia.LabelAssociationKey = 5
        Me.cmbProvincia.Location = New System.Drawing.Point(117, 87)
        Me.cmbProvincia.Name = "cmbProvincia"
        Me.cmbProvincia.Size = New System.Drawing.Size(95, 21)
        Me.cmbProvincia.TabIndex = 25
        Me.cmbProvincia.Validator = WindowsApplication1.ValidatorType.NotEmpty
        '
        'txtLocalidad
        '
        Me.txtLocalidad.Cleanable = True
        Me.txtLocalidad.Empty = True
        Me.txtLocalidad.EnterIndex = 4
        Me.txtLocalidad.LabelAssociationKey = 4
        Me.txtLocalidad.Location = New System.Drawing.Point(117, 55)
        Me.txtLocalidad.MaxLength = 50
        Me.txtLocalidad.Name = "txtLocalidad"
        Me.txtLocalidad.Size = New System.Drawing.Size(90, 20)
        Me.txtLocalidad.TabIndex = 24
        Me.txtLocalidad.Validator = WindowsApplication1.ValidatorType.None
        '
        'txtDireccion
        '
        Me.txtDireccion.Cleanable = True
        Me.txtDireccion.Empty = True
        Me.txtDireccion.EnterIndex = 3
        Me.txtDireccion.LabelAssociationKey = 3
        Me.txtDireccion.Location = New System.Drawing.Point(118, 30)
        Me.txtDireccion.MaxLength = 50
        Me.txtDireccion.Name = "txtDireccion"
        Me.txtDireccion.Size = New System.Drawing.Size(77, 20)
        Me.txtDireccion.TabIndex = 23
        Me.txtDireccion.Validator = WindowsApplication1.ValidatorType.None
        '
        'txtRazonSocial
        '
        Me.txtRazonSocial.Cleanable = True
        Me.txtRazonSocial.Empty = False
        Me.txtRazonSocial.EnterIndex = 2
        Me.txtRazonSocial.LabelAssociationKey = 2
        Me.txtRazonSocial.Location = New System.Drawing.Point(337, 6)
        Me.txtRazonSocial.MaxLength = 50
        Me.txtRazonSocial.Name = "txtRazonSocial"
        Me.txtRazonSocial.Size = New System.Drawing.Size(75, 20)
        Me.txtRazonSocial.TabIndex = 22
        Me.txtRazonSocial.Validator = WindowsApplication1.ValidatorType.NotEmpty
        '
        'txtCodigo
        '
        Me.txtCodigo.Cleanable = True
        Me.txtCodigo.Empty = False
        Me.txtCodigo.EnterIndex = 1
        Me.txtCodigo.LabelAssociationKey = 1
        Me.txtCodigo.Location = New System.Drawing.Point(118, 9)
        Me.txtCodigo.MaxLength = 11
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Size = New System.Drawing.Size(103, 20)
        Me.txtCodigo.TabIndex = 21
        Me.txtCodigo.Validator = WindowsApplication1.ValidatorType.NotEmpty
        '
        'CustomLabel21
        '
        Me.CustomLabel21.AutoSize = True
        Me.CustomLabel21.ControlAssociationKey = 22
        Me.CustomLabel21.Location = New System.Drawing.Point(347, 306)
        Me.CustomLabel21.Name = "CustomLabel21"
        Me.CustomLabel21.Size = New System.Drawing.Size(145, 13)
        Me.CustomLabel21.TabIndex = 20
        Me.CustomLabel21.Text = "Nro. Inscripción SEDRONAR"
        '
        'CustomLabel20
        '
        Me.CustomLabel20.AutoSize = True
        Me.CustomLabel20.ControlAssociationKey = 24
        Me.CustomLabel20.Location = New System.Drawing.Point(464, 333)
        Me.CustomLabel20.Name = "CustomLabel20"
        Me.CustomLabel20.Size = New System.Drawing.Size(101, 13)
        Me.CustomLabel20.TabIndex = 19
        Me.CustomLabel20.Text = "Tipo Inscripción I.B."
        '
        'CustomLabel19
        '
        Me.CustomLabel19.AutoSize = True
        Me.CustomLabel19.ControlAssociationKey = 19
        Me.CustomLabel19.Location = New System.Drawing.Point(450, 278)
        Me.CustomLabel19.Name = "CustomLabel19"
        Me.CustomLabel19.Size = New System.Drawing.Size(83, 13)
        Me.CustomLabel19.TabIndex = 18
        Me.CustomLabel19.Text = "Porcel I.B. Pcia."
        '
        'CustomLabel18
        '
        Me.CustomLabel18.AutoSize = True
        Me.CustomLabel18.ControlAssociationKey = 18
        Me.CustomLabel18.Location = New System.Drawing.Point(316, 278)
        Me.CustomLabel18.Name = "CustomLabel18"
        Me.CustomLabel18.Size = New System.Drawing.Size(63, 13)
        Me.CustomLabel18.TabIndex = 17
        Me.CustomLabel18.Text = "Número I.B."
        '
        'CustomLabel17
        '
        Me.CustomLabel17.AutoSize = True
        Me.CustomLabel17.ControlAssociationKey = 14
        Me.CustomLabel17.Location = New System.Drawing.Point(353, 201)
        Me.CustomLabel17.Name = "CustomLabel17"
        Me.CustomLabel17.Size = New System.Drawing.Size(60, 13)
        Me.CustomLabel17.TabIndex = 16
        Me.CustomLabel17.Text = "Código IVA"
        '
        'CustomLabel16
        '
        Me.CustomLabel16.AutoSize = True
        Me.CustomLabel16.ControlAssociationKey = 23
        Me.CustomLabel16.Location = New System.Drawing.Point(22, 332)
        Me.CustomLabel16.Name = "CustomLabel16"
        Me.CustomLabel16.Size = New System.Drawing.Size(54, 13)
        Me.CustomLabel16.TabIndex = 15
        Me.CustomLabel16.Text = "Categoría"
        '
        'CustomLabel15
        '
        Me.CustomLabel15.AutoSize = True
        Me.CustomLabel15.ControlAssociationKey = 17
        Me.CustomLabel15.Location = New System.Drawing.Point(21, 278)
        Me.CustomLabel15.Name = "CustomLabel15"
        Me.CustomLabel15.Size = New System.Drawing.Size(73, 13)
        Me.CustomLabel15.TabIndex = 14
        Me.CustomLabel15.Text = "Condición I.B."
        '
        'CustomLabel14
        '
        Me.CustomLabel14.AutoSize = True
        Me.CustomLabel14.ControlAssociationKey = 16
        Me.CustomLabel14.Location = New System.Drawing.Point(21, 253)
        Me.CustomLabel14.Name = "CustomLabel14"
        Me.CustomLabel14.Size = New System.Drawing.Size(84, 13)
        Me.CustomLabel14.TabIndex = 13
        Me.CustomLabel14.Text = "Nombre Cheque"
        '
        'CustomLabel13
        '
        Me.CustomLabel13.AutoSize = True
        Me.CustomLabel13.ControlAssociationKey = 15
        Me.CustomLabel13.Location = New System.Drawing.Point(21, 229)
        Me.CustomLabel13.Name = "CustomLabel13"
        Me.CustomLabel13.Size = New System.Drawing.Size(86, 13)
        Me.CustomLabel13.TabIndex = 12
        Me.CustomLabel13.Text = "Cuenta Contable"
        '
        'CustomLabel12
        '
        Me.CustomLabel12.AutoSize = True
        Me.CustomLabel12.ControlAssociationKey = 13
        Me.CustomLabel12.Location = New System.Drawing.Point(21, 201)
        Me.CustomLabel12.Name = "CustomLabel12"
        Me.CustomLabel12.Size = New System.Drawing.Size(28, 13)
        Me.CustomLabel12.TabIndex = 11
        Me.CustomLabel12.Text = "Tipo"
        '
        'CustomLabel11
        '
        Me.CustomLabel11.AutoSize = True
        Me.CustomLabel11.ControlAssociationKey = 12
        Me.CustomLabel11.Location = New System.Drawing.Point(399, 167)
        Me.CustomLabel11.Name = "CustomLabel11"
        Me.CustomLabel11.Size = New System.Drawing.Size(32, 13)
        Me.CustomLabel11.TabIndex = 10
        Me.CustomLabel11.Text = "CUIT"
        '
        'CustomLabel10
        '
        Me.CustomLabel10.AutoSize = True
        Me.CustomLabel10.ControlAssociationKey = 11
        Me.CustomLabel10.Location = New System.Drawing.Point(21, 167)
        Me.CustomLabel10.Name = "CustomLabel10"
        Me.CustomLabel10.Size = New System.Drawing.Size(78, 13)
        Me.CustomLabel10.TabIndex = 9
        Me.CustomLabel10.Text = "Observaciones"
        '
        'CustomLabel9
        '
        Me.CustomLabel9.AutoSize = True
        Me.CustomLabel9.ControlAssociationKey = 10
        Me.CustomLabel9.Location = New System.Drawing.Point(21, 141)
        Me.CustomLabel9.Name = "CustomLabel9"
        Me.CustomLabel9.Size = New System.Drawing.Size(35, 13)
        Me.CustomLabel9.TabIndex = 8
        Me.CustomLabel9.Text = "e-Mail"
        '
        'CustomLabel8
        '
        Me.CustomLabel8.AutoSize = True
        Me.CustomLabel8.ControlAssociationKey = 7
        Me.CustomLabel8.Location = New System.Drawing.Point(482, 90)
        Me.CustomLabel8.Name = "CustomLabel8"
        Me.CustomLabel8.Size = New System.Drawing.Size(41, 13)
        Me.CustomLabel8.TabIndex = 7
        Me.CustomLabel8.Text = "Región"
        '
        'CustomLabel7
        '
        Me.CustomLabel7.AutoSize = True
        Me.CustomLabel7.ControlAssociationKey = 6
        Me.CustomLabel7.Location = New System.Drawing.Point(261, 90)
        Me.CustomLabel7.Name = "CustomLabel7"
        Me.CustomLabel7.Size = New System.Drawing.Size(72, 13)
        Me.CustomLabel7.TabIndex = 6
        Me.CustomLabel7.Text = "Código Postal"
        '
        'CustomLabel6
        '
        Me.CustomLabel6.AutoSize = True
        Me.CustomLabel6.ControlAssociationKey = 8
        Me.CustomLabel6.Location = New System.Drawing.Point(21, 116)
        Me.CustomLabel6.Name = "CustomLabel6"
        Me.CustomLabel6.Size = New System.Drawing.Size(49, 13)
        Me.CustomLabel6.TabIndex = 5
        Me.CustomLabel6.Text = "Teléfono"
        '
        'CustomLabel5
        '
        Me.CustomLabel5.AutoSize = True
        Me.CustomLabel5.ControlAssociationKey = 5
        Me.CustomLabel5.Location = New System.Drawing.Point(21, 90)
        Me.CustomLabel5.Name = "CustomLabel5"
        Me.CustomLabel5.Size = New System.Drawing.Size(51, 13)
        Me.CustomLabel5.TabIndex = 4
        Me.CustomLabel5.Text = "Provincia"
        '
        'CustomLabel4
        '
        Me.CustomLabel4.AutoSize = True
        Me.CustomLabel4.ControlAssociationKey = 4
        Me.CustomLabel4.Location = New System.Drawing.Point(21, 62)
        Me.CustomLabel4.Name = "CustomLabel4"
        Me.CustomLabel4.Size = New System.Drawing.Size(53, 13)
        Me.CustomLabel4.TabIndex = 3
        Me.CustomLabel4.Text = "Localidad"
        '
        'CustomLabel3
        '
        Me.CustomLabel3.AutoSize = True
        Me.CustomLabel3.ControlAssociationKey = 3
        Me.CustomLabel3.Location = New System.Drawing.Point(22, 37)
        Me.CustomLabel3.Name = "CustomLabel3"
        Me.CustomLabel3.Size = New System.Drawing.Size(52, 13)
        Me.CustomLabel3.TabIndex = 2
        Me.CustomLabel3.Text = "Dirección"
        '
        'CustomLabel2
        '
        Me.CustomLabel2.AutoSize = True
        Me.CustomLabel2.ControlAssociationKey = 2
        Me.CustomLabel2.Location = New System.Drawing.Point(241, 9)
        Me.CustomLabel2.Name = "CustomLabel2"
        Me.CustomLabel2.Size = New System.Drawing.Size(70, 13)
        Me.CustomLabel2.TabIndex = 1
        Me.CustomLabel2.Text = "Razón Social"
        '
        'CustomLabel1
        '
        Me.CustomLabel1.AutoSize = True
        Me.CustomLabel1.ControlAssociationKey = 1
        Me.CustomLabel1.Location = New System.Drawing.Point(22, 9)
        Me.CustomLabel1.Name = "CustomLabel1"
        Me.CustomLabel1.Size = New System.Drawing.Size(40, 13)
        Me.CustomLabel1.TabIndex = 0
        Me.CustomLabel1.Text = "Código"
        '
        'ProveedoresABM
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(790, 568)
        Me.Controls.Add(Me.cmbCalificacion)
        Me.Controls.Add(Me.cmbEstado)
        Me.Controls.Add(Me.cmbCertificados)
        Me.Controls.Add(Me.txtCalificacion)
        Me.Controls.Add(Me.txtCertificados)
        Me.Controls.Add(Me.txtCAIVto)
        Me.Controls.Add(Me.txtCAI)
        Me.Controls.Add(Me.btnCUFE)
        Me.Controls.Add(Me.btnObservaciones)
        Me.Controls.Add(Me.CustomLabel29)
        Me.Controls.Add(Me.CustomLabel28)
        Me.Controls.Add(Me.CustomLabel27)
        Me.Controls.Add(Me.CustomLabel26)
        Me.Controls.Add(Me.CustomLabel25)
        Me.Controls.Add(Me.txtNroSEDRONAR2)
        Me.Controls.Add(Me.txtCategoria)
        Me.Controls.Add(Me.txtNroSEDRONAR1)
        Me.Controls.Add(Me.txtPorcelCABA)
        Me.Controls.Add(Me.txtPorcelProv)
        Me.Controls.Add(Me.txtNroIB)
        Me.Controls.Add(Me.txtCheque)
        Me.Controls.Add(Me.txtCuentaDescripcion)
        Me.Controls.Add(Me.txtCuenta)
        Me.Controls.Add(Me.cmbInscripcionIB)
        Me.Controls.Add(Me.cmbCategoria2)
        Me.Controls.Add(Me.cmbCategoria1)
        Me.Controls.Add(Me.cmbCondicionIB2)
        Me.Controls.Add(Me.cmbCondicionIB1)
        Me.Controls.Add(Me.cmbRubro)
        Me.Controls.Add(Me.cmbIVA)
        Me.Controls.Add(Me.CustomLabel24)
        Me.Controls.Add(Me.txtDiasPlazo)
        Me.Controls.Add(Me.CustomLabel23)
        Me.Controls.Add(Me.CustomLabel22)
        Me.Controls.Add(Me.cmbTipoProveedor)
        Me.Controls.Add(Me.txtCUIT)
        Me.Controls.Add(Me.txtObservaciones)
        Me.Controls.Add(Me.cmbRegion)
        Me.Controls.Add(Me.txtCodigoPostal)
        Me.Controls.Add(Me.txtEmail)
        Me.Controls.Add(Me.txtTelefono)
        Me.Controls.Add(Me.cmbProvincia)
        Me.Controls.Add(Me.txtLocalidad)
        Me.Controls.Add(Me.txtDireccion)
        Me.Controls.Add(Me.txtRazonSocial)
        Me.Controls.Add(Me.txtCodigo)
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
        Me.Name = "ProveedoresABM"
        Me.Text = "Ingreso de Proveedores"
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
    Friend WithEvents txtCodigo As WindowsApplication1.CustomTextBox
    Friend WithEvents txtRazonSocial As WindowsApplication1.CustomTextBox
    Friend WithEvents txtDireccion As WindowsApplication1.CustomTextBox
    Friend WithEvents txtLocalidad As WindowsApplication1.CustomTextBox
    Friend WithEvents cmbProvincia As WindowsApplication1.CustomComboBox
    Friend WithEvents txtTelefono As WindowsApplication1.CustomTextBox
    Friend WithEvents txtEmail As WindowsApplication1.CustomTextBox
    Friend WithEvents txtCodigoPostal As WindowsApplication1.CustomTextBox
    Friend WithEvents cmbRegion As WindowsApplication1.CustomComboBox
    Friend WithEvents txtObservaciones As WindowsApplication1.CustomTextBox
    Friend WithEvents txtCUIT As WindowsApplication1.CustomTextBox
    Friend WithEvents cmbTipoProveedor As WindowsApplication1.CustomComboBox
    Friend WithEvents CustomLabel22 As WindowsApplication1.CustomLabel
    Friend WithEvents CustomLabel23 As WindowsApplication1.CustomLabel
    Friend WithEvents txtDiasPlazo As WindowsApplication1.CustomTextBox
    Friend WithEvents CustomLabel24 As WindowsApplication1.CustomLabel
    Friend WithEvents cmbIVA As WindowsApplication1.CustomComboBox
    Friend WithEvents cmbRubro As WindowsApplication1.CustomComboBox
    Friend WithEvents cmbCondicionIB1 As WindowsApplication1.CustomComboBox
    Friend WithEvents cmbCondicionIB2 As WindowsApplication1.CustomComboBox
    Friend WithEvents cmbCategoria1 As WindowsApplication1.CustomComboBox
    Friend WithEvents cmbCategoria2 As WindowsApplication1.CustomComboBox
    Friend WithEvents cmbInscripcionIB As WindowsApplication1.CustomComboBox
    Friend WithEvents txtCuentaDescripcion As WindowsApplication1.CustomTextBox
    Friend WithEvents txtCuenta As WindowsApplication1.CustomTextBox
    Friend WithEvents txtCheque As WindowsApplication1.CustomTextBox
    Friend WithEvents txtNroIB As WindowsApplication1.CustomTextBox
    Friend WithEvents txtPorcelProv As WindowsApplication1.CustomTextBox
    Friend WithEvents txtPorcelCABA As WindowsApplication1.CustomTextBox
    Friend WithEvents txtNroSEDRONAR1 As WindowsApplication1.CustomTextBox
    Friend WithEvents txtCategoria As WindowsApplication1.CustomTextBox
    Friend WithEvents txtNroSEDRONAR2 As WindowsApplication1.CustomTextBox
    Friend WithEvents CustomLabel25 As WindowsApplication1.CustomLabel
    Friend WithEvents CustomLabel26 As WindowsApplication1.CustomLabel
    Friend WithEvents CustomLabel27 As WindowsApplication1.CustomLabel
    Friend WithEvents CustomLabel28 As WindowsApplication1.CustomLabel
    Friend WithEvents CustomLabel29 As WindowsApplication1.CustomLabel
    Friend WithEvents btnObservaciones As WindowsApplication1.CustomButton
    Friend WithEvents btnCUFE As WindowsApplication1.CustomButton
    Friend WithEvents txtCAI As WindowsApplication1.CustomTextBox
    Friend WithEvents txtCAIVto As WindowsApplication1.CustomTextBox
    Friend WithEvents txtCertificados As WindowsApplication1.CustomTextBox
    Friend WithEvents txtCalificacion As WindowsApplication1.CustomTextBox
    Friend WithEvents cmbCertificados As WindowsApplication1.CustomComboBox
    Friend WithEvents cmbEstado As WindowsApplication1.CustomComboBox
    Friend WithEvents cmbCalificacion As WindowsApplication1.CustomComboBox
End Class