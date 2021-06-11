<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MostrarFactura
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
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txt_NroInterno = New System.Windows.Forms.TextBox()
        Me.txt_CodigoProveedor = New System.Windows.Forms.TextBox()
        Me.txtNombreProveedor = New System.Windows.Forms.TextBox()
        Me.txtCAI = New System.Windows.Forms.TextBox()
        Me.txtTipo = New System.Windows.Forms.TextBox()
        Me.txtPunto = New System.Windows.Forms.TextBox()
        Me.txtNumero = New System.Windows.Forms.TextBox()
        Me.txtVtoCAI = New System.Windows.Forms.TextBox()
        Me.txtFechaEmision = New System.Windows.Forms.TextBox()
        Me.txtFechaIVA = New System.Windows.Forms.TextBox()
        Me.txtRemito = New System.Windows.Forms.TextBox()
        Me.txtFechaVto1 = New System.Windows.Forms.TextBox()
        Me.txtFechaVto2 = New System.Windows.Forms.TextBox()
        Me.txtParidad = New System.Windows.Forms.TextBox()
        Me.txtNeto = New System.Windows.Forms.TextBox()
        Me.txtIVA21 = New System.Windows.Forms.TextBox()
        Me.txtIVA27 = New System.Windows.Forms.TextBox()
        Me.txtIVARG = New System.Windows.Forms.TextBox()
        Me.txtIVA10 = New System.Windows.Forms.TextBox()
        Me.txtPercIB = New System.Windows.Forms.TextBox()
        Me.txtTotal = New System.Windows.Forms.TextBox()
        Me.txtNoGravado = New System.Windows.Forms.TextBox()
        Me.lblCredito = New System.Windows.Forms.TextBox()
        Me.lblDebito = New System.Windows.Forms.TextBox()
        Me.gridAsientos = New Util.DBDataGridView()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblCai = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lblVtoCai = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.gbTipo = New System.Windows.Forms.GroupBox()
        Me.optNacion = New System.Windows.Forms.RadioButton()
        Me.optCtaCte = New System.Windows.Forms.RadioButton()
        Me.optEfectivo = New System.Windows.Forms.RadioButton()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.txtDespacho = New System.Windows.Forms.TextBox()
        Me.cmbTipo = New System.Windows.Forms.ComboBox()
        Me.CBLetra = New System.Windows.Forms.ComboBox()
        Me.cmbFormaPago = New System.Windows.Forms.ComboBox()
        Me.Cuenta = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Debito = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Credito = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1.SuspendLayout()
        CType(Me.gridAsientos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbTipo.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(894, 60)
        Me.Panel1.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.Control
        Me.Label2.Location = New System.Drawing.Point(689, 24)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(192, 25)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "SURFACTAN S.A."
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.Control
        Me.Label1.Location = New System.Drawing.Point(4, 9)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(140, 25)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Vista Factura"
        '
        'txt_NroInterno
        '
        Me.txt_NroInterno.Location = New System.Drawing.Point(95, 75)
        Me.txt_NroInterno.Name = "txt_NroInterno"
        Me.txt_NroInterno.Size = New System.Drawing.Size(100, 22)
        Me.txt_NroInterno.TabIndex = 4
        '
        'txt_CodigoProveedor
        '
        Me.txt_CodigoProveedor.Location = New System.Drawing.Point(282, 75)
        Me.txt_CodigoProveedor.Name = "txt_CodigoProveedor"
        Me.txt_CodigoProveedor.Size = New System.Drawing.Size(100, 22)
        Me.txt_CodigoProveedor.TabIndex = 5
        '
        'txtNombreProveedor
        '
        Me.txtNombreProveedor.Location = New System.Drawing.Point(388, 75)
        Me.txtNombreProveedor.Name = "txtNombreProveedor"
        Me.txtNombreProveedor.Size = New System.Drawing.Size(272, 22)
        Me.txtNombreProveedor.TabIndex = 6
        '
        'txtCAI
        '
        Me.txtCAI.Location = New System.Drawing.Point(709, 75)
        Me.txtCAI.Name = "txtCAI"
        Me.txtCAI.Size = New System.Drawing.Size(172, 22)
        Me.txtCAI.TabIndex = 7
        Me.txtCAI.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtCAI.Visible = False
        '
        'txtTipo
        '
        Me.txtTipo.Location = New System.Drawing.Point(48, 108)
        Me.txtTipo.Name = "txtTipo"
        Me.txtTipo.Size = New System.Drawing.Size(30, 22)
        Me.txtTipo.TabIndex = 8
        '
        'txtPunto
        '
        Me.txtPunto.Location = New System.Drawing.Point(397, 105)
        Me.txtPunto.Name = "txtPunto"
        Me.txtPunto.Size = New System.Drawing.Size(100, 22)
        Me.txtPunto.TabIndex = 10
        Me.txtPunto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtNumero
        '
        Me.txtNumero.Location = New System.Drawing.Point(583, 105)
        Me.txtNumero.Name = "txtNumero"
        Me.txtNumero.Size = New System.Drawing.Size(100, 22)
        Me.txtNumero.TabIndex = 11
        Me.txtNumero.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtVtoCAI
        '
        Me.txtVtoCAI.Location = New System.Drawing.Point(756, 105)
        Me.txtVtoCAI.Name = "txtVtoCAI"
        Me.txtVtoCAI.Size = New System.Drawing.Size(100, 22)
        Me.txtVtoCAI.TabIndex = 12
        Me.txtVtoCAI.Visible = False
        '
        'txtFechaEmision
        '
        Me.txtFechaEmision.Location = New System.Drawing.Point(112, 145)
        Me.txtFechaEmision.Name = "txtFechaEmision"
        Me.txtFechaEmision.Size = New System.Drawing.Size(100, 22)
        Me.txtFechaEmision.TabIndex = 13
        '
        'txtFechaIVA
        '
        Me.txtFechaIVA.Location = New System.Drawing.Point(310, 145)
        Me.txtFechaIVA.Name = "txtFechaIVA"
        Me.txtFechaIVA.Size = New System.Drawing.Size(100, 22)
        Me.txtFechaIVA.TabIndex = 14
        '
        'txtRemito
        '
        Me.txtRemito.Location = New System.Drawing.Point(494, 145)
        Me.txtRemito.Name = "txtRemito"
        Me.txtRemito.Size = New System.Drawing.Size(100, 22)
        Me.txtRemito.TabIndex = 15
        '
        'txtFechaVto1
        '
        Me.txtFechaVto1.Location = New System.Drawing.Point(84, 176)
        Me.txtFechaVto1.Name = "txtFechaVto1"
        Me.txtFechaVto1.Size = New System.Drawing.Size(100, 22)
        Me.txtFechaVto1.TabIndex = 16
        '
        'txtFechaVto2
        '
        Me.txtFechaVto2.Location = New System.Drawing.Point(190, 176)
        Me.txtFechaVto2.Name = "txtFechaVto2"
        Me.txtFechaVto2.Size = New System.Drawing.Size(100, 22)
        Me.txtFechaVto2.TabIndex = 17
        '
        'txtParidad
        '
        Me.txtParidad.Location = New System.Drawing.Point(582, 173)
        Me.txtParidad.Name = "txtParidad"
        Me.txtParidad.Size = New System.Drawing.Size(155, 22)
        Me.txtParidad.TabIndex = 19
        Me.txtParidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtNeto
        '
        Me.txtNeto.Location = New System.Drawing.Point(149, 213)
        Me.txtNeto.Name = "txtNeto"
        Me.txtNeto.Size = New System.Drawing.Size(100, 22)
        Me.txtNeto.TabIndex = 20
        Me.txtNeto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtIVA21
        '
        Me.txtIVA21.Location = New System.Drawing.Point(408, 213)
        Me.txtIVA21.Name = "txtIVA21"
        Me.txtIVA21.Size = New System.Drawing.Size(100, 22)
        Me.txtIVA21.TabIndex = 21
        Me.txtIVA21.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtIVA27
        '
        Me.txtIVA27.Location = New System.Drawing.Point(408, 241)
        Me.txtIVA27.Name = "txtIVA27"
        Me.txtIVA27.Size = New System.Drawing.Size(100, 22)
        Me.txtIVA27.TabIndex = 23
        Me.txtIVA27.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtIVARG
        '
        Me.txtIVARG.Location = New System.Drawing.Point(149, 241)
        Me.txtIVARG.Name = "txtIVARG"
        Me.txtIVARG.Size = New System.Drawing.Size(100, 22)
        Me.txtIVARG.TabIndex = 22
        Me.txtIVARG.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtIVA10
        '
        Me.txtIVA10.Location = New System.Drawing.Point(408, 268)
        Me.txtIVA10.Name = "txtIVA10"
        Me.txtIVA10.Size = New System.Drawing.Size(100, 22)
        Me.txtIVA10.TabIndex = 25
        Me.txtIVA10.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPercIB
        '
        Me.txtPercIB.Location = New System.Drawing.Point(149, 268)
        Me.txtPercIB.Name = "txtPercIB"
        Me.txtPercIB.Size = New System.Drawing.Size(100, 22)
        Me.txtPercIB.TabIndex = 24
        Me.txtPercIB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotal
        '
        Me.txtTotal.Location = New System.Drawing.Point(408, 296)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.Size = New System.Drawing.Size(100, 22)
        Me.txtTotal.TabIndex = 27
        Me.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtNoGravado
        '
        Me.txtNoGravado.Location = New System.Drawing.Point(149, 296)
        Me.txtNoGravado.Name = "txtNoGravado"
        Me.txtNoGravado.Size = New System.Drawing.Size(100, 22)
        Me.txtNoGravado.TabIndex = 26
        Me.txtNoGravado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblCredito
        '
        Me.lblCredito.Location = New System.Drawing.Point(769, 501)
        Me.lblCredito.Name = "lblCredito"
        Me.lblCredito.Size = New System.Drawing.Size(100, 22)
        Me.lblCredito.TabIndex = 29
        Me.lblCredito.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblDebito
        '
        Me.lblDebito.Location = New System.Drawing.Point(637, 501)
        Me.lblDebito.Name = "lblDebito"
        Me.lblDebito.Size = New System.Drawing.Size(100, 22)
        Me.lblDebito.TabIndex = 28
        Me.lblDebito.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'gridAsientos
        '
        Me.gridAsientos.AllowUserToAddRows = False
        Me.gridAsientos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridAsientos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Cuenta, Me.Descripcion, Me.Debito, Me.Credito})
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(232, Byte), Integer))
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gridAsientos.DefaultCellStyle = DataGridViewCellStyle8
        Me.gridAsientos.DoubleBuffered = True
        Me.gridAsientos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.gridAsientos.Location = New System.Drawing.Point(9, 324)
        Me.gridAsientos.Name = "gridAsientos"
        Me.gridAsientos.OrdenamientoColumnasHabilitado = True
        Me.gridAsientos.ReadOnly = True
        Me.gridAsientos.RowHeadersWidth = 15
        Me.gridAsientos.RowTemplate.Height = 20
        Me.gridAsientos.ShowCellToolTips = False
        Me.gridAsientos.SinClickDerecho = False
        Me.gridAsientos.Size = New System.Drawing.Size(860, 157)
        Me.gridAsientos.TabIndex = 30
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 78)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(83, 17)
        Me.Label3.TabIndex = 31
        Me.Label3.Text = "Nro. Interno"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(202, 78)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(74, 17)
        Me.Label4.TabIndex = 32
        Me.Label4.Text = "Proveedor"
        '
        'lblCai
        '
        Me.lblCai.AutoSize = True
        Me.lblCai.Location = New System.Drawing.Point(666, 78)
        Me.lblCai.Name = "lblCai"
        Me.lblCai.Size = New System.Drawing.Size(37, 17)
        Me.lblCai.TabIndex = 33
        Me.lblCai.Text = "C.A.I"
        Me.lblCai.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 108)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(36, 17)
        Me.Label6.TabIndex = 34
        Me.Label6.Text = "Tipo"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(178, 108)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(41, 17)
        Me.Label7.TabIndex = 35
        Me.Label7.Text = "Letra"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(346, 108)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(45, 17)
        Me.Label8.TabIndex = 36
        Me.Label8.Text = "Punto"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(519, 108)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(58, 17)
        Me.Label9.TabIndex = 37
        Me.Label9.Text = "Numero"
        '
        'lblVtoCai
        '
        Me.lblVtoCai.AutoSize = True
        Me.lblVtoCai.Location = New System.Drawing.Point(689, 108)
        Me.lblVtoCai.Name = "lblVtoCai"
        Me.lblVtoCai.Size = New System.Drawing.Size(62, 17)
        Me.lblVtoCai.TabIndex = 38
        Me.lblVtoCai.Text = "Vto C.A.I"
        Me.lblVtoCai.Visible = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(6, 148)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(100, 17)
        Me.Label11.TabIndex = 39
        Me.Label11.Text = "Fecha Emisión"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(232, 148)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(72, 17)
        Me.Label12.TabIndex = 40
        Me.Label12.Text = "Fecha IVA"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(436, 148)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(52, 17)
        Me.Label13.TabIndex = 41
        Me.Label13.Text = "Remito"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(6, 179)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(72, 17)
        Me.Label14.TabIndex = 42
        Me.Label14.Text = "Fecha Vto"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(310, 179)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(59, 17)
        Me.Label15.TabIndex = 43
        Me.Label15.Text = "Moneda"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(519, 176)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(57, 17)
        Me.Label16.TabIndex = 44
        Me.Label16.Text = "Paridad"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(6, 216)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(89, 17)
        Me.Label17.TabIndex = 45
        Me.Label17.Text = "Importe Neto"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(6, 244)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(98, 17)
        Me.Label18.TabIndex = 46
        Me.Label18.Text = "IVA R.G. 3337"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(6, 271)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(112, 17)
        Me.Label19.TabIndex = 47
        Me.Label19.Text = "Importe Perc. I.B"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(6, 299)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(137, 17)
        Me.Label20.TabIndex = 48
        Me.Label20.Text = "Importe No Grabado"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(279, 299)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(91, 17)
        Me.Label21.TabIndex = 52
        Me.Label21.Text = "Importe Total"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(279, 271)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(124, 17)
        Me.Label22.TabIndex = 51
        Me.Label22.Text = "Importe IVA 10.5%"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(279, 244)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(112, 17)
        Me.Label23.TabIndex = 50
        Me.Label23.Text = "Importe IVA 27%"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(279, 218)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(112, 17)
        Me.Label24.TabIndex = 49
        Me.Label24.Text = "Importe IVA 21%"
        '
        'gbTipo
        '
        Me.gbTipo.Controls.Add(Me.optNacion)
        Me.gbTipo.Controls.Add(Me.optCtaCte)
        Me.gbTipo.Controls.Add(Me.optEfectivo)
        Me.gbTipo.ForeColor = System.Drawing.SystemColors.ControlText
        Me.gbTipo.Location = New System.Drawing.Point(522, 210)
        Me.gbTipo.Margin = New System.Windows.Forms.Padding(4)
        Me.gbTipo.Name = "gbTipo"
        Me.gbTipo.Padding = New System.Windows.Forms.Padding(4)
        Me.gbTipo.Size = New System.Drawing.Size(293, 53)
        Me.gbTipo.TabIndex = 53
        Me.gbTipo.TabStop = False
        Me.gbTipo.Text = "Tipo"
        '
        'optNacion
        '
        Me.optNacion.AutoSize = True
        Me.optNacion.Location = New System.Drawing.Point(197, 20)
        Me.optNacion.Margin = New System.Windows.Forms.Padding(4)
        Me.optNacion.Name = "optNacion"
        Me.optNacion.Size = New System.Drawing.Size(73, 21)
        Me.optNacion.TabIndex = 2
        Me.optNacion.Text = "Nación"
        Me.optNacion.UseVisualStyleBackColor = True
        '
        'optCtaCte
        '
        Me.optCtaCte.AutoSize = True
        Me.optCtaCte.Checked = True
        Me.optCtaCte.Location = New System.Drawing.Point(101, 20)
        Me.optCtaCte.Margin = New System.Windows.Forms.Padding(4)
        Me.optCtaCte.Name = "optCtaCte"
        Me.optCtaCte.Size = New System.Drawing.Size(83, 21)
        Me.optCtaCte.TabIndex = 1
        Me.optCtaCte.TabStop = True
        Me.optCtaCte.Text = "Cta. Cte."
        Me.optCtaCte.UseVisualStyleBackColor = True
        '
        'optEfectivo
        '
        Me.optEfectivo.AutoSize = True
        Me.optEfectivo.Location = New System.Drawing.Point(8, 20)
        Me.optEfectivo.Margin = New System.Windows.Forms.Padding(4)
        Me.optEfectivo.Name = "optEfectivo"
        Me.optEfectivo.Size = New System.Drawing.Size(79, 21)
        Me.optEfectivo.TabIndex = 0
        Me.optEfectivo.Text = "Efectivo"
        Me.optEfectivo.UseVisualStyleBackColor = True
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(519, 273)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(72, 17)
        Me.Label25.TabIndex = 55
        Me.Label25.Text = "Despacho"
        '
        'txtDespacho
        '
        Me.txtDespacho.Location = New System.Drawing.Point(597, 273)
        Me.txtDespacho.Name = "txtDespacho"
        Me.txtDespacho.Size = New System.Drawing.Size(272, 22)
        Me.txtDespacho.TabIndex = 54
        '
        'cmbTipo
        '
        Me.cmbTipo.FormattingEnabled = True
        Me.cmbTipo.Items.AddRange(New Object() {"", "FC", "ND", "NC", "DI", "OC"})
        Me.cmbTipo.Location = New System.Drawing.Point(48, 106)
        Me.cmbTipo.Name = "cmbTipo"
        Me.cmbTipo.Size = New System.Drawing.Size(121, 24)
        Me.cmbTipo.TabIndex = 56
        '
        'CBLetra
        '
        Me.CBLetra.FormattingEnabled = True
        Me.CBLetra.Items.AddRange(New Object() {"", "A", "B", "C", "X", "M", "I"})
        Me.CBLetra.Location = New System.Drawing.Point(235, 106)
        Me.CBLetra.Name = "CBLetra"
        Me.CBLetra.Size = New System.Drawing.Size(71, 24)
        Me.CBLetra.TabIndex = 57
        '
        'cmbFormaPago
        '
        Me.cmbFormaPago.FormattingEnabled = True
        Me.cmbFormaPago.Items.AddRange(New Object() {"", "Pesos", "Cláusula Dólar"})
        Me.cmbFormaPago.Location = New System.Drawing.Point(375, 176)
        Me.cmbFormaPago.Name = "cmbFormaPago"
        Me.cmbFormaPago.Size = New System.Drawing.Size(122, 24)
        Me.cmbFormaPago.TabIndex = 58
        '
        'Cuenta
        '
        Me.Cuenta.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Cuenta.DefaultCellStyle = DataGridViewCellStyle5
        Me.Cuenta.HeaderText = "Cuenta"
        Me.Cuenta.Name = "Cuenta"
        Me.Cuenta.ReadOnly = True
        Me.Cuenta.Width = 82
        '
        'Descripcion
        '
        Me.Descripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Descripcion.HeaderText = "Descripcion"
        Me.Descripcion.Name = "Descripcion"
        Me.Descripcion.ReadOnly = True
        '
        'Debito
        '
        Me.Debito.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle6.Format = "N2"
        DataGridViewCellStyle6.NullValue = Nothing
        Me.Debito.DefaultCellStyle = DataGridViewCellStyle6
        Me.Debito.HeaderText = "Debito"
        Me.Debito.Name = "Debito"
        Me.Debito.ReadOnly = True
        Me.Debito.Width = 78
        '
        'Credito
        '
        Me.Credito.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle7.Format = "N2"
        DataGridViewCellStyle7.NullValue = Nothing
        Me.Credito.DefaultCellStyle = DataGridViewCellStyle7
        Me.Credito.HeaderText = "Credito"
        Me.Credito.Name = "Credito"
        Me.Credito.ReadOnly = True
        Me.Credito.Width = 82
        '
        'MostrarFactura
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(894, 551)
        Me.Controls.Add(Me.cmbFormaPago)
        Me.Controls.Add(Me.CBLetra)
        Me.Controls.Add(Me.cmbTipo)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.txtDespacho)
        Me.Controls.Add(Me.gbTipo)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.lblVtoCai)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.lblCai)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.gridAsientos)
        Me.Controls.Add(Me.lblCredito)
        Me.Controls.Add(Me.lblDebito)
        Me.Controls.Add(Me.txtTotal)
        Me.Controls.Add(Me.txtNoGravado)
        Me.Controls.Add(Me.txtIVA10)
        Me.Controls.Add(Me.txtPercIB)
        Me.Controls.Add(Me.txtIVA27)
        Me.Controls.Add(Me.txtIVARG)
        Me.Controls.Add(Me.txtIVA21)
        Me.Controls.Add(Me.txtNeto)
        Me.Controls.Add(Me.txtParidad)
        Me.Controls.Add(Me.txtFechaVto2)
        Me.Controls.Add(Me.txtFechaVto1)
        Me.Controls.Add(Me.txtRemito)
        Me.Controls.Add(Me.txtFechaIVA)
        Me.Controls.Add(Me.txtFechaEmision)
        Me.Controls.Add(Me.txtVtoCAI)
        Me.Controls.Add(Me.txtNumero)
        Me.Controls.Add(Me.txtPunto)
        Me.Controls.Add(Me.txtTipo)
        Me.Controls.Add(Me.txtCAI)
        Me.Controls.Add(Me.txtNombreProveedor)
        Me.Controls.Add(Me.txt_CodigoProveedor)
        Me.Controls.Add(Me.txt_NroInterno)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "MostrarFactura"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.gridAsientos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbTipo.ResumeLayout(False)
        Me.gbTipo.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt_NroInterno As System.Windows.Forms.TextBox
    Friend WithEvents txt_CodigoProveedor As System.Windows.Forms.TextBox
    Friend WithEvents txtNombreProveedor As System.Windows.Forms.TextBox
    Friend WithEvents txtCAI As System.Windows.Forms.TextBox
    Friend WithEvents txtTipo As System.Windows.Forms.TextBox
    Friend WithEvents txtPunto As System.Windows.Forms.TextBox
    Friend WithEvents txtNumero As System.Windows.Forms.TextBox
    Friend WithEvents txtVtoCAI As System.Windows.Forms.TextBox
    Friend WithEvents txtFechaEmision As System.Windows.Forms.TextBox
    Friend WithEvents txtFechaIVA As System.Windows.Forms.TextBox
    Friend WithEvents txtRemito As System.Windows.Forms.TextBox
    Friend WithEvents txtFechaVto1 As System.Windows.Forms.TextBox
    Friend WithEvents txtFechaVto2 As System.Windows.Forms.TextBox
    Friend WithEvents txtParidad As System.Windows.Forms.TextBox
    Friend WithEvents txtNeto As System.Windows.Forms.TextBox
    Friend WithEvents txtIVA21 As System.Windows.Forms.TextBox
    Friend WithEvents txtIVA27 As System.Windows.Forms.TextBox
    Friend WithEvents txtIVARG As System.Windows.Forms.TextBox
    Friend WithEvents txtIVA10 As System.Windows.Forms.TextBox
    Friend WithEvents txtPercIB As System.Windows.Forms.TextBox
    Friend WithEvents txtTotal As System.Windows.Forms.TextBox
    Friend WithEvents txtNoGravado As System.Windows.Forms.TextBox
    Friend WithEvents lblCredito As System.Windows.Forms.TextBox
    Friend WithEvents lblDebito As System.Windows.Forms.TextBox
    Friend WithEvents gridAsientos As Util.DBDataGridView
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblCai As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lblVtoCai As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents gbTipo As System.Windows.Forms.GroupBox
    Friend WithEvents optNacion As System.Windows.Forms.RadioButton
    Friend WithEvents optCtaCte As System.Windows.Forms.RadioButton
    Friend WithEvents optEfectivo As System.Windows.Forms.RadioButton
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents txtDespacho As System.Windows.Forms.TextBox
    Friend WithEvents cmbTipo As System.Windows.Forms.ComboBox
    Friend WithEvents CBLetra As System.Windows.Forms.ComboBox
    Friend WithEvents cmbFormaPago As System.Windows.Forms.ComboBox
    Friend WithEvents Cuenta As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Descripcion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Debito As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Credito As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
