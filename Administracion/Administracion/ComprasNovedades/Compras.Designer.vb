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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PanelPrincipal = New System.Windows.Forms.Panel()
        Me.txt_NroPresup = New Administracion.CustomTextBox()
        Me.CustomLabel3 = New Administracion.CustomLabel()
        Me.btn_Adjuntar = New System.Windows.Forms.Button()
        Me.ckMarcaDifCambio = New System.Windows.Forms.CheckBox()
        Me.ckChequeRechazado = New System.Windows.Forms.CheckBox()
        Me.CustomButton1 = New Administracion.CustomButton()
        Me.txtVtoCAI = New System.Windows.Forms.MaskedTextBox()
        Me.txtFechaIVA = New System.Windows.Forms.MaskedTextBox()
        Me.txtFechaVto2 = New System.Windows.Forms.MaskedTextBox()
        Me.txtFechaVto1 = New System.Windows.Forms.MaskedTextBox()
        Me.txtFechaEmision = New System.Windows.Forms.MaskedTextBox()
        Me.CBLetra = New System.Windows.Forms.ComboBox()
        Me.txtNumero = New Administracion.CustomTextBox()
        Me.CustomLabel4 = New Administracion.CustomLabel()
        Me.txtCAI = New Administracion.CustomTextBox()
        Me.lblCredito = New Administracion.CustomLabel()
        Me.txtNombreProveedor = New Administracion.CustomTextBox()
        Me.CustomLabel5 = New Administracion.CustomLabel()
        Me.txtCodigoProveedor = New Administracion.CustomTextBox()
        Me.lblDebito = New Administracion.CustomLabel()
        Me.txtNroInterno = New Administracion.CustomTextBox()
        Me.CustomLabel6 = New Administracion.CustomLabel()
        Me.lblCai = New Administracion.CustomLabel()
        Me.CustomLabel7 = New Administracion.CustomLabel()
        Me.lblVtoCai = New Administracion.CustomLabel()
        Me.CustomLabel2 = New Administracion.CustomLabel()
        Me.CustomLabel9 = New Administracion.CustomLabel()
        Me.CustomLabel1 = New Administracion.CustomLabel()
        Me.CustomLabel10 = New Administracion.CustomLabel()
        Me.CustomLabel11 = New Administracion.CustomLabel()
        Me.CustomLabel12 = New Administracion.CustomLabel()
        Me.CustomLabel13 = New Administracion.CustomLabel()
        Me.CustomLabel14 = New Administracion.CustomLabel()
        Me.txtIVA10 = New Administracion.CustomTextBox()
        Me.CustomLabel15 = New Administracion.CustomLabel()
        Me.txtDespacho = New Administracion.CustomTextBox()
        Me.CustomLabel16 = New Administracion.CustomLabel()
        Me.txtIVA21 = New Administracion.CustomTextBox()
        Me.CustomLabel17 = New Administracion.CustomLabel()
        Me.txtIVA27 = New Administracion.CustomTextBox()
        Me.CustomLabel18 = New Administracion.CustomLabel()
        Me.txtNoGravado = New Administracion.CustomTextBox()
        Me.CustomLabel19 = New Administracion.CustomLabel()
        Me.txtTotal = New Administracion.CustomTextBox()
        Me.CustomLabel20 = New Administracion.CustomLabel()
        Me.txtNeto = New Administracion.CustomTextBox()
        Me.CustomLabel21 = New Administracion.CustomLabel()
        Me.txtIVARG = New Administracion.CustomTextBox()
        Me.CustomLabel22 = New Administracion.CustomLabel()
        Me.txtPercIB = New Administracion.CustomTextBox()
        Me.CustomLabel23 = New Administracion.CustomLabel()
        Me.txtParidad = New Administracion.CustomTextBox()
        Me.cmbFormaPago = New Administracion.CustomComboBox()
        Me.txtRemito = New Administracion.CustomTextBox()
        Me.cmbTipo = New Administracion.CustomComboBox()
        Me.txtPunto = New Administracion.CustomTextBox()
        Me.txtTipo = New Administracion.CustomTextBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnApertura = New Administracion.CustomButton()
        Me.btnConsulta = New Administracion.CustomButton()
        Me.btnCerrar = New Administracion.CustomButton()
        Me.btnAgregar = New Administracion.CustomButton()
        Me.btnEliminar = New Administracion.CustomButton()
        Me.btnConsultaNroFactura = New Administracion.CustomButton()
        Me.btnLimpiar = New Administracion.CustomButton()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.gbTipo.SuspendLayout()
        CType(Me.gridAsientos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.PanelPrincipal.SuspendLayout()
        Me.SuspendLayout()
        '
        'chkSoloIVA
        '
        Me.chkSoloIVA.AutoSize = True
        Me.chkSoloIVA.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.chkSoloIVA.ForeColor = System.Drawing.SystemColors.Control
        Me.chkSoloIVA.Location = New System.Drawing.Point(961, 180)
        Me.chkSoloIVA.Margin = New System.Windows.Forms.Padding(4)
        Me.chkSoloIVA.Name = "chkSoloIVA"
        Me.chkSoloIVA.Size = New System.Drawing.Size(97, 27)
        Me.chkSoloIVA.TabIndex = 24
        Me.chkSoloIVA.Text = "Sólo IVA"
        Me.chkSoloIVA.UseVisualStyleBackColor = True
        '
        'gbTipo
        '
        Me.gbTipo.Controls.Add(Me.optNacion)
        Me.gbTipo.Controls.Add(Me.optCtaCte)
        Me.gbTipo.Controls.Add(Me.optEfectivo)
        Me.gbTipo.ForeColor = System.Drawing.SystemColors.Control
        Me.gbTipo.Location = New System.Drawing.Point(599, 149)
        Me.gbTipo.Margin = New System.Windows.Forms.Padding(4)
        Me.gbTipo.Name = "gbTipo"
        Me.gbTipo.Padding = New System.Windows.Forms.Padding(4)
        Me.gbTipo.Size = New System.Drawing.Size(293, 53)
        Me.gbTipo.TabIndex = 25
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
        'gridAsientos
        '
        Me.gridAsientos.AllowUserToDeleteRows = False
        Me.gridAsientos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridAsientos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Cuenta, Me.Descripcion, Me.Debito, Me.Credito})
        Me.gridAsientos.Location = New System.Drawing.Point(53, 276)
        Me.gridAsientos.Margin = New System.Windows.Forms.Padding(4)
        Me.gridAsientos.Name = "gridAsientos"
        Me.gridAsientos.RowHeadersWidth = 15
        Me.gridAsientos.RowTemplate.Height = 21
        Me.gridAsientos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.gridAsientos.Size = New System.Drawing.Size(979, 297)
        Me.gridAsientos.TabIndex = 52
        '
        'Cuenta
        '
        Me.Cuenta.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Cuenta.DefaultCellStyle = DataGridViewCellStyle1
        Me.Cuenta.HeaderText = "Cuenta"
        Me.Cuenta.Name = "Cuenta"
        Me.Cuenta.Width = 82
        '
        'Descripcion
        '
        Me.Descripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Descripcion.HeaderText = "Descripción"
        Me.Descripcion.Name = "Descripcion"
        Me.Descripcion.ReadOnly = True
        '
        'Debito
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Debito.DefaultCellStyle = DataGridViewCellStyle2
        Me.Debito.HeaderText = "Débito"
        Me.Debito.Name = "Debito"
        Me.Debito.Width = 120
        '
        'Credito
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Credito.DefaultCellStyle = DataGridViewCellStyle3
        Me.Credito.HeaderText = "Crédito"
        Me.Credito.Name = "Credito"
        Me.Credito.Width = 120
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1081, 62)
        Me.Panel1.TabIndex = 62
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.Control
        Me.Label2.Location = New System.Drawing.Point(817, 15)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(195, 33)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "SURFACTAN S.A."
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.Control
        Me.Label1.Location = New System.Drawing.Point(36, 20)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(362, 24)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Ingreso de Comprobantes de Proveedores"
        '
        'PanelPrincipal
        '
        Me.PanelPrincipal.BackColor = System.Drawing.Color.FromArgb(CType(CType(95, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(82, Byte), Integer))
        Me.PanelPrincipal.Controls.Add(Me.txt_NroPresup)
        Me.PanelPrincipal.Controls.Add(Me.CustomLabel3)
        Me.PanelPrincipal.Controls.Add(Me.btn_Adjuntar)
        Me.PanelPrincipal.Controls.Add(Me.ckMarcaDifCambio)
        Me.PanelPrincipal.Controls.Add(Me.ckChequeRechazado)
        Me.PanelPrincipal.Controls.Add(Me.CustomButton1)
        Me.PanelPrincipal.Controls.Add(Me.txtVtoCAI)
        Me.PanelPrincipal.Controls.Add(Me.txtFechaIVA)
        Me.PanelPrincipal.Controls.Add(Me.txtFechaVto2)
        Me.PanelPrincipal.Controls.Add(Me.txtFechaVto1)
        Me.PanelPrincipal.Controls.Add(Me.txtFechaEmision)
        Me.PanelPrincipal.Controls.Add(Me.CBLetra)
        Me.PanelPrincipal.Controls.Add(Me.txtNumero)
        Me.PanelPrincipal.Controls.Add(Me.CustomLabel4)
        Me.PanelPrincipal.Controls.Add(Me.txtCAI)
        Me.PanelPrincipal.Controls.Add(Me.lblCredito)
        Me.PanelPrincipal.Controls.Add(Me.txtNombreProveedor)
        Me.PanelPrincipal.Controls.Add(Me.CustomLabel5)
        Me.PanelPrincipal.Controls.Add(Me.txtCodigoProveedor)
        Me.PanelPrincipal.Controls.Add(Me.lblDebito)
        Me.PanelPrincipal.Controls.Add(Me.txtNroInterno)
        Me.PanelPrincipal.Controls.Add(Me.CustomLabel6)
        Me.PanelPrincipal.Controls.Add(Me.lblCai)
        Me.PanelPrincipal.Controls.Add(Me.CustomLabel7)
        Me.PanelPrincipal.Controls.Add(Me.lblVtoCai)
        Me.PanelPrincipal.Controls.Add(Me.CustomLabel2)
        Me.PanelPrincipal.Controls.Add(Me.CustomLabel9)
        Me.PanelPrincipal.Controls.Add(Me.CustomLabel1)
        Me.PanelPrincipal.Controls.Add(Me.CustomLabel10)
        Me.PanelPrincipal.Controls.Add(Me.CustomLabel11)
        Me.PanelPrincipal.Controls.Add(Me.CustomLabel12)
        Me.PanelPrincipal.Controls.Add(Me.CustomLabel13)
        Me.PanelPrincipal.Controls.Add(Me.gridAsientos)
        Me.PanelPrincipal.Controls.Add(Me.CustomLabel14)
        Me.PanelPrincipal.Controls.Add(Me.txtIVA10)
        Me.PanelPrincipal.Controls.Add(Me.CustomLabel15)
        Me.PanelPrincipal.Controls.Add(Me.txtDespacho)
        Me.PanelPrincipal.Controls.Add(Me.CustomLabel16)
        Me.PanelPrincipal.Controls.Add(Me.txtIVA21)
        Me.PanelPrincipal.Controls.Add(Me.CustomLabel17)
        Me.PanelPrincipal.Controls.Add(Me.txtIVA27)
        Me.PanelPrincipal.Controls.Add(Me.CustomLabel18)
        Me.PanelPrincipal.Controls.Add(Me.txtNoGravado)
        Me.PanelPrincipal.Controls.Add(Me.CustomLabel19)
        Me.PanelPrincipal.Controls.Add(Me.txtTotal)
        Me.PanelPrincipal.Controls.Add(Me.CustomLabel20)
        Me.PanelPrincipal.Controls.Add(Me.txtNeto)
        Me.PanelPrincipal.Controls.Add(Me.CustomLabel21)
        Me.PanelPrincipal.Controls.Add(Me.txtIVARG)
        Me.PanelPrincipal.Controls.Add(Me.CustomLabel22)
        Me.PanelPrincipal.Controls.Add(Me.txtPercIB)
        Me.PanelPrincipal.Controls.Add(Me.CustomLabel23)
        Me.PanelPrincipal.Controls.Add(Me.txtParidad)
        Me.PanelPrincipal.Controls.Add(Me.chkSoloIVA)
        Me.PanelPrincipal.Controls.Add(Me.cmbFormaPago)
        Me.PanelPrincipal.Controls.Add(Me.gbTipo)
        Me.PanelPrincipal.Controls.Add(Me.txtRemito)
        Me.PanelPrincipal.Controls.Add(Me.cmbTipo)
        Me.PanelPrincipal.Controls.Add(Me.txtPunto)
        Me.PanelPrincipal.Controls.Add(Me.txtTipo)
        Me.PanelPrincipal.Location = New System.Drawing.Point(0, 60)
        Me.PanelPrincipal.Margin = New System.Windows.Forms.Padding(4)
        Me.PanelPrincipal.Name = "PanelPrincipal"
        Me.PanelPrincipal.Size = New System.Drawing.Size(1085, 625)
        Me.PanelPrincipal.TabIndex = 63
        '
        'txt_NroPresup
        '
        Me.txt_NroPresup.Cleanable = True
        Me.txt_NroPresup.Empty = False
        Me.txt_NroPresup.EnterIndex = 6
        Me.txt_NroPresup.LabelAssociationKey = 7
        Me.txt_NroPresup.Location = New System.Drawing.Point(1000, 148)
        Me.txt_NroPresup.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_NroPresup.MaxLength = 8
        Me.txt_NroPresup.Name = "txt_NroPresup"
        Me.txt_NroPresup.ReadOnly = True
        Me.txt_NroPresup.Size = New System.Drawing.Size(70, 22)
        Me.txt_NroPresup.TabIndex = 68
        Me.txt_NroPresup.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txt_NroPresup.Validator = Administracion.ValidatorType.Numeric
        '
        'CustomLabel3
        '
        Me.CustomLabel3.AutoSize = True
        Me.CustomLabel3.ControlAssociationKey = 7
        Me.CustomLabel3.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.CustomLabel3.ForeColor = System.Drawing.SystemColors.Control
        Me.CustomLabel3.Location = New System.Drawing.Point(894, 147)
        Me.CustomLabel3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.CustomLabel3.Name = "CustomLabel3"
        Me.CustomLabel3.Size = New System.Drawing.Size(109, 23)
        Me.CustomLabel3.TabIndex = 67
        Me.CustomLabel3.Text = "Nro. Presup."
        '
        'btn_Adjuntar
        '
        Me.btn_Adjuntar.AllowDrop = True
        Me.btn_Adjuntar.BackgroundImage = Global.Administracion.My.Resources.Resources.images
        Me.btn_Adjuntar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btn_Adjuntar.Location = New System.Drawing.Point(795, 41)
        Me.btn_Adjuntar.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_Adjuntar.Name = "btn_Adjuntar"
        Me.btn_Adjuntar.Size = New System.Drawing.Size(60, 38)
        Me.btn_Adjuntar.TabIndex = 66
        Me.ToolTip1.SetToolTip(Me.btn_Adjuntar, "Adjuntar Documento")
        Me.btn_Adjuntar.UseVisualStyleBackColor = True
        '
        'ckMarcaDifCambio
        '
        Me.ckMarcaDifCambio.AutoSize = True
        Me.ckMarcaDifCambio.Font = New System.Drawing.Font("Calibri", 10.0!, System.Drawing.FontStyle.Bold)
        Me.ckMarcaDifCambio.ForeColor = System.Drawing.SystemColors.Control
        Me.ckMarcaDifCambio.Location = New System.Drawing.Point(819, 241)
        Me.ckMarcaDifCambio.Margin = New System.Windows.Forms.Padding(4)
        Me.ckMarcaDifCambio.Name = "ckMarcaDifCambio"
        Me.ckMarcaDifCambio.Size = New System.Drawing.Size(232, 25)
        Me.ckMarcaDifCambio.TabIndex = 65
        Me.ckMarcaDifCambio.Text = "Marcar como Dif. de Cambio"
        Me.ckMarcaDifCambio.UseVisualStyleBackColor = True
        '
        'ckChequeRechazado
        '
        Me.ckChequeRechazado.AutoSize = True
        Me.ckChequeRechazado.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.ckChequeRechazado.ForeColor = System.Drawing.SystemColors.Control
        Me.ckChequeRechazado.Location = New System.Drawing.Point(619, 241)
        Me.ckChequeRechazado.Margin = New System.Windows.Forms.Padding(4)
        Me.ckChequeRechazado.Name = "ckChequeRechazado"
        Me.ckChequeRechazado.Size = New System.Drawing.Size(181, 27)
        Me.ckChequeRechazado.TabIndex = 65
        Me.ckChequeRechazado.Text = "Cheque Rechazado"
        Me.ckChequeRechazado.UseVisualStyleBackColor = True
        '
        'CustomButton1
        '
        Me.CustomButton1.BackColor = System.Drawing.SystemColors.Control
        Me.CustomButton1.BackgroundImage = Global.Administracion.My.Resources.Resources.Consulta_Dat_N1
        Me.CustomButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.CustomButton1.Cleanable = False
        Me.CustomButton1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CustomButton1.EnterIndex = -1
        Me.CustomButton1.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.CustomButton1.FlatAppearance.BorderSize = 0
        Me.CustomButton1.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.Control
        Me.CustomButton1.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control
        Me.CustomButton1.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control
        Me.CustomButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CustomButton1.LabelAssociationKey = -1
        Me.CustomButton1.Location = New System.Drawing.Point(999, 78)
        Me.CustomButton1.Margin = New System.Windows.Forms.Padding(4)
        Me.CustomButton1.Name = "CustomButton1"
        Me.CustomButton1.Size = New System.Drawing.Size(41, 28)
        Me.CustomButton1.TabIndex = 64
        Me.ToolTip1.SetToolTip(Me.CustomButton1, "Consultar Detalles de Remitos")
        Me.CustomButton1.UseVisualStyleBackColor = False
        '
        'txtVtoCAI
        '
        Me.txtVtoCAI.Location = New System.Drawing.Point(955, 48)
        Me.txtVtoCAI.Margin = New System.Windows.Forms.Padding(4)
        Me.txtVtoCAI.Mask = "00/00/0000"
        Me.txtVtoCAI.Name = "txtVtoCAI"
        Me.txtVtoCAI.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtVtoCAI.Size = New System.Drawing.Size(108, 22)
        Me.txtVtoCAI.TabIndex = 63
        Me.txtVtoCAI.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtVtoCAI.ValidatingType = GetType(Date)
        '
        'txtFechaIVA
        '
        Me.txtFechaIVA.Location = New System.Drawing.Point(425, 84)
        Me.txtFechaIVA.Margin = New System.Windows.Forms.Padding(4)
        Me.txtFechaIVA.Mask = "00/00/0000"
        Me.txtFechaIVA.Name = "txtFechaIVA"
        Me.txtFechaIVA.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtFechaIVA.Size = New System.Drawing.Size(108, 22)
        Me.txtFechaIVA.TabIndex = 63
        Me.txtFechaIVA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtFechaIVA.ValidatingType = GetType(Date)
        '
        'txtFechaVto2
        '
        Me.txtFechaVto2.Location = New System.Drawing.Point(308, 110)
        Me.txtFechaVto2.Margin = New System.Windows.Forms.Padding(4)
        Me.txtFechaVto2.Mask = "00/00/0000"
        Me.txtFechaVto2.Name = "txtFechaVto2"
        Me.txtFechaVto2.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtFechaVto2.Size = New System.Drawing.Size(108, 22)
        Me.txtFechaVto2.TabIndex = 63
        Me.txtFechaVto2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.txtFechaVto2, "Calculado a partir de Fecha IVA")
        Me.txtFechaVto2.ValidatingType = GetType(Date)
        Me.txtFechaVto2.Visible = False
        '
        'txtFechaVto1
        '
        Me.txtFechaVto1.Location = New System.Drawing.Point(191, 110)
        Me.txtFechaVto1.Margin = New System.Windows.Forms.Padding(4)
        Me.txtFechaVto1.Mask = "00/00/0000"
        Me.txtFechaVto1.Name = "txtFechaVto1"
        Me.txtFechaVto1.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtFechaVto1.Size = New System.Drawing.Size(108, 22)
        Me.txtFechaVto1.TabIndex = 63
        Me.txtFechaVto1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.txtFechaVto1, "Calculado a partir de Fecha IVA")
        Me.txtFechaVto1.ValidatingType = GetType(Date)
        '
        'txtFechaEmision
        '
        Me.txtFechaEmision.Location = New System.Drawing.Point(191, 81)
        Me.txtFechaEmision.Margin = New System.Windows.Forms.Padding(4)
        Me.txtFechaEmision.Mask = "00/00/0000"
        Me.txtFechaEmision.Name = "txtFechaEmision"
        Me.txtFechaEmision.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtFechaEmision.Size = New System.Drawing.Size(108, 22)
        Me.txtFechaEmision.TabIndex = 63
        Me.txtFechaEmision.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtFechaEmision.ValidatingType = GetType(Date)
        '
        'CBLetra
        '
        Me.CBLetra.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBLetra.FormattingEnabled = True
        Me.CBLetra.Items.AddRange(New Object() {"", "A", "B", "C", "X", "M", "I"})
        Me.CBLetra.Location = New System.Drawing.Point(384, 48)
        Me.CBLetra.Margin = New System.Windows.Forms.Padding(4)
        Me.CBLetra.Name = "CBLetra"
        Me.CBLetra.Size = New System.Drawing.Size(47, 24)
        Me.CBLetra.TabIndex = 62
        '
        'txtNumero
        '
        Me.txtNumero.Cleanable = True
        Me.txtNumero.Empty = False
        Me.txtNumero.EnterIndex = 6
        Me.txtNumero.LabelAssociationKey = 7
        Me.txtNumero.Location = New System.Drawing.Point(669, 49)
        Me.txtNumero.Margin = New System.Windows.Forms.Padding(4)
        Me.txtNumero.MaxLength = 8
        Me.txtNumero.Name = "txtNumero"
        Me.txtNumero.Size = New System.Drawing.Size(120, 22)
        Me.txtNumero.TabIndex = 33
        Me.txtNumero.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtNumero.Validator = Administracion.ValidatorType.Numeric
        '
        'CustomLabel4
        '
        Me.CustomLabel4.AutoSize = True
        Me.CustomLabel4.ControlAssociationKey = 4
        Me.CustomLabel4.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.CustomLabel4.ForeColor = System.Drawing.SystemColors.Control
        Me.CustomLabel4.Location = New System.Drawing.Point(132, 50)
        Me.CustomLabel4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.CustomLabel4.Name = "CustomLabel4"
        Me.CustomLabel4.Size = New System.Drawing.Size(44, 23)
        Me.CustomLabel4.TabIndex = 3
        Me.CustomLabel4.Text = "Tipo"
        '
        'txtCAI
        '
        Me.txtCAI.Cleanable = True
        Me.txtCAI.Empty = True
        Me.txtCAI.EnterIndex = -1
        Me.txtCAI.LabelAssociationKey = 3
        Me.txtCAI.Location = New System.Drawing.Point(892, 17)
        Me.txtCAI.Margin = New System.Windows.Forms.Padding(4)
        Me.txtCAI.MaxLength = 14
        Me.txtCAI.Name = "txtCAI"
        Me.txtCAI.Size = New System.Drawing.Size(156, 22)
        Me.txtCAI.TabIndex = 35
        Me.txtCAI.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtCAI.Validator = Administracion.ValidatorType.None
        Me.txtCAI.Visible = False
        '
        'lblCredito
        '
        Me.lblCredito.BackColor = System.Drawing.SystemColors.Control
        Me.lblCredito.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCredito.ControlAssociationKey = -1
        Me.lblCredito.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblCredito.Location = New System.Drawing.Point(873, 585)
        Me.lblCredito.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCredito.Name = "lblCredito"
        Me.lblCredito.Size = New System.Drawing.Size(156, 25)
        Me.lblCredito.TabIndex = 61
        Me.lblCredito.Text = "0,00"
        Me.lblCredito.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.lblCredito, "Total de Créditos")
        '
        'txtNombreProveedor
        '
        Me.txtNombreProveedor.Cleanable = True
        Me.txtNombreProveedor.Empty = False
        Me.txtNombreProveedor.EnterIndex = -1
        Me.txtNombreProveedor.LabelAssociationKey = 2
        Me.txtNombreProveedor.Location = New System.Drawing.Point(549, 17)
        Me.txtNombreProveedor.Margin = New System.Windows.Forms.Padding(4)
        Me.txtNombreProveedor.Name = "txtNombreProveedor"
        Me.txtNombreProveedor.Size = New System.Drawing.Size(284, 22)
        Me.txtNombreProveedor.TabIndex = 28
        Me.txtNombreProveedor.Validator = Administracion.ValidatorType.None
        '
        'CustomLabel5
        '
        Me.CustomLabel5.AutoSize = True
        Me.CustomLabel5.ControlAssociationKey = 5
        Me.CustomLabel5.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.CustomLabel5.ForeColor = System.Drawing.SystemColors.Control
        Me.CustomLabel5.Location = New System.Drawing.Point(324, 50)
        Me.CustomLabel5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.CustomLabel5.Name = "CustomLabel5"
        Me.CustomLabel5.Size = New System.Drawing.Size(51, 23)
        Me.CustomLabel5.TabIndex = 4
        Me.CustomLabel5.Text = "Letra"
        '
        'txtCodigoProveedor
        '
        Me.txtCodigoProveedor.Cleanable = True
        Me.txtCodigoProveedor.Empty = False
        Me.txtCodigoProveedor.EnterIndex = 2
        Me.txtCodigoProveedor.LabelAssociationKey = 2
        Me.txtCodigoProveedor.Location = New System.Drawing.Point(428, 17)
        Me.txtCodigoProveedor.Margin = New System.Windows.Forms.Padding(4)
        Me.txtCodigoProveedor.MaxLength = 11
        Me.txtCodigoProveedor.Name = "txtCodigoProveedor"
        Me.txtCodigoProveedor.Size = New System.Drawing.Size(112, 22)
        Me.txtCodigoProveedor.TabIndex = 27
        Me.txtCodigoProveedor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.txtCodigoProveedor, "Doble Click: Abrir Consulta de Proveedores")
        Me.txtCodigoProveedor.Validator = Administracion.ValidatorType.None
        '
        'lblDebito
        '
        Me.lblDebito.BackColor = System.Drawing.SystemColors.Control
        Me.lblDebito.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDebito.ControlAssociationKey = -1
        Me.lblDebito.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblDebito.Location = New System.Drawing.Point(709, 585)
        Me.lblDebito.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDebito.Name = "lblDebito"
        Me.lblDebito.Size = New System.Drawing.Size(156, 25)
        Me.lblDebito.TabIndex = 60
        Me.lblDebito.Text = "0,00"
        Me.lblDebito.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.lblDebito, "Total de Debitos")
        '
        'txtNroInterno
        '
        Me.txtNroInterno.Cleanable = True
        Me.txtNroInterno.Empty = True
        Me.txtNroInterno.EnterIndex = 1
        Me.txtNroInterno.LabelAssociationKey = 1
        Me.txtNroInterno.Location = New System.Drawing.Point(191, 17)
        Me.txtNroInterno.Margin = New System.Windows.Forms.Padding(4)
        Me.txtNroInterno.MaxLength = 6
        Me.txtNroInterno.Name = "txtNroInterno"
        Me.txtNroInterno.Size = New System.Drawing.Size(109, 22)
        Me.txtNroInterno.TabIndex = 26
        Me.txtNroInterno.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtNroInterno.Validator = Administracion.ValidatorType.Numeric
        '
        'CustomLabel6
        '
        Me.CustomLabel6.AutoSize = True
        Me.CustomLabel6.ControlAssociationKey = 6
        Me.CustomLabel6.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.CustomLabel6.ForeColor = System.Drawing.SystemColors.Control
        Me.CustomLabel6.Location = New System.Drawing.Point(437, 50)
        Me.CustomLabel6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.CustomLabel6.Name = "CustomLabel6"
        Me.CustomLabel6.Size = New System.Drawing.Size(57, 23)
        Me.CustomLabel6.TabIndex = 5
        Me.CustomLabel6.Text = "Punto"
        '
        'lblCai
        '
        Me.lblCai.AutoSize = True
        Me.lblCai.ControlAssociationKey = 3
        Me.lblCai.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.lblCai.ForeColor = System.Drawing.SystemColors.Control
        Me.lblCai.Location = New System.Drawing.Point(840, 18)
        Me.lblCai.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCai.Name = "lblCai"
        Me.lblCai.Size = New System.Drawing.Size(52, 23)
        Me.lblCai.TabIndex = 2
        Me.lblCai.Text = "C.A.I."
        Me.lblCai.Visible = False
        '
        'CustomLabel7
        '
        Me.CustomLabel7.AutoSize = True
        Me.CustomLabel7.ControlAssociationKey = 7
        Me.CustomLabel7.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.CustomLabel7.ForeColor = System.Drawing.SystemColors.Control
        Me.CustomLabel7.Location = New System.Drawing.Point(584, 50)
        Me.CustomLabel7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.CustomLabel7.Name = "CustomLabel7"
        Me.CustomLabel7.Size = New System.Drawing.Size(75, 23)
        Me.CustomLabel7.TabIndex = 6
        Me.CustomLabel7.Text = "Número"
        '
        'lblVtoCai
        '
        Me.lblVtoCai.AutoSize = True
        Me.lblVtoCai.ControlAssociationKey = 8
        Me.lblVtoCai.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.lblVtoCai.ForeColor = System.Drawing.SystemColors.Control
        Me.lblVtoCai.Location = New System.Drawing.Point(863, 50)
        Me.lblVtoCai.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblVtoCai.Name = "lblVtoCai"
        Me.lblVtoCai.Size = New System.Drawing.Size(89, 23)
        Me.lblVtoCai.TabIndex = 8
        Me.lblVtoCai.Text = "Vto. C.A.I."
        Me.lblVtoCai.Visible = False
        '
        'CustomLabel2
        '
        Me.CustomLabel2.AutoSize = True
        Me.CustomLabel2.ControlAssociationKey = 2
        Me.CustomLabel2.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.CustomLabel2.ForeColor = System.Drawing.SystemColors.Control
        Me.CustomLabel2.Location = New System.Drawing.Point(323, 18)
        Me.CustomLabel2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.CustomLabel2.Name = "CustomLabel2"
        Me.CustomLabel2.Size = New System.Drawing.Size(93, 23)
        Me.CustomLabel2.TabIndex = 1
        Me.CustomLabel2.Text = "Proveedor"
        '
        'CustomLabel9
        '
        Me.CustomLabel9.AutoSize = True
        Me.CustomLabel9.ControlAssociationKey = 9
        Me.CustomLabel9.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.CustomLabel9.ForeColor = System.Drawing.SystemColors.Control
        Me.CustomLabel9.Location = New System.Drawing.Point(51, 81)
        Me.CustomLabel9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.CustomLabel9.Name = "CustomLabel9"
        Me.CustomLabel9.Size = New System.Drawing.Size(122, 23)
        Me.CustomLabel9.TabIndex = 9
        Me.CustomLabel9.Text = "Fecha Emisión"
        '
        'CustomLabel1
        '
        Me.CustomLabel1.AutoSize = True
        Me.CustomLabel1.ControlAssociationKey = 1
        Me.CustomLabel1.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.CustomLabel1.ForeColor = System.Drawing.SystemColors.Control
        Me.CustomLabel1.Location = New System.Drawing.Point(67, 18)
        Me.CustomLabel1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.CustomLabel1.Name = "CustomLabel1"
        Me.CustomLabel1.Size = New System.Drawing.Size(108, 23)
        Me.CustomLabel1.TabIndex = 0
        Me.CustomLabel1.Text = "Nro. Interno"
        '
        'CustomLabel10
        '
        Me.CustomLabel10.AutoSize = True
        Me.CustomLabel10.ControlAssociationKey = 10
        Me.CustomLabel10.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.CustomLabel10.ForeColor = System.Drawing.SystemColors.Control
        Me.CustomLabel10.Location = New System.Drawing.Point(329, 81)
        Me.CustomLabel10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.CustomLabel10.Name = "CustomLabel10"
        Me.CustomLabel10.Size = New System.Drawing.Size(87, 23)
        Me.CustomLabel10.TabIndex = 10
        Me.CustomLabel10.Text = "Fecha IVA"
        '
        'CustomLabel11
        '
        Me.CustomLabel11.AutoSize = True
        Me.CustomLabel11.ControlAssociationKey = 11
        Me.CustomLabel11.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.CustomLabel11.ForeColor = System.Drawing.SystemColors.Control
        Me.CustomLabel11.Location = New System.Drawing.Point(545, 81)
        Me.CustomLabel11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.CustomLabel11.Name = "CustomLabel11"
        Me.CustomLabel11.Size = New System.Drawing.Size(68, 23)
        Me.CustomLabel11.TabIndex = 11
        Me.CustomLabel11.Text = "Remito"
        '
        'CustomLabel12
        '
        Me.CustomLabel12.AutoSize = True
        Me.CustomLabel12.ControlAssociationKey = 12
        Me.CustomLabel12.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.CustomLabel12.ForeColor = System.Drawing.SystemColors.Control
        Me.CustomLabel12.Location = New System.Drawing.Point(81, 112)
        Me.CustomLabel12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.CustomLabel12.Name = "CustomLabel12"
        Me.CustomLabel12.Size = New System.Drawing.Size(93, 23)
        Me.CustomLabel12.TabIndex = 12
        Me.CustomLabel12.Text = "Fecha Vto."
        '
        'CustomLabel13
        '
        Me.CustomLabel13.AutoSize = True
        Me.CustomLabel13.ControlAssociationKey = 13
        Me.CustomLabel13.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.CustomLabel13.ForeColor = System.Drawing.SystemColors.Control
        Me.CustomLabel13.Location = New System.Drawing.Point(449, 113)
        Me.CustomLabel13.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.CustomLabel13.Name = "CustomLabel13"
        Me.CustomLabel13.Size = New System.Drawing.Size(81, 23)
        Me.CustomLabel13.TabIndex = 13
        Me.CustomLabel13.Text = "Moneda:"
        '
        'CustomLabel14
        '
        Me.CustomLabel14.AutoSize = True
        Me.CustomLabel14.ControlAssociationKey = 14
        Me.CustomLabel14.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.CustomLabel14.ForeColor = System.Drawing.SystemColors.Control
        Me.CustomLabel14.Location = New System.Drawing.Point(787, 112)
        Me.CustomLabel14.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.CustomLabel14.Name = "CustomLabel14"
        Me.CustomLabel14.Size = New System.Drawing.Size(70, 23)
        Me.CustomLabel14.TabIndex = 14
        Me.CustomLabel14.Text = "Paridad"
        '
        'txtIVA10
        '
        Me.txtIVA10.Cleanable = True
        Me.txtIVA10.Empty = False
        Me.txtIVA10.EnterIndex = 20
        Me.txtIVA10.LabelAssociationKey = 23
        Me.txtIVA10.Location = New System.Drawing.Point(489, 208)
        Me.txtIVA10.Margin = New System.Windows.Forms.Padding(4)
        Me.txtIVA10.Name = "txtIVA10"
        Me.txtIVA10.Size = New System.Drawing.Size(100, 22)
        Me.txtIVA10.TabIndex = 51
        Me.txtIVA10.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtIVA10.Validator = Administracion.ValidatorType.Float
        '
        'CustomLabel15
        '
        Me.CustomLabel15.AutoSize = True
        Me.CustomLabel15.ControlAssociationKey = 15
        Me.CustomLabel15.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.CustomLabel15.ForeColor = System.Drawing.SystemColors.Control
        Me.CustomLabel15.Location = New System.Drawing.Point(56, 144)
        Me.CustomLabel15.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.CustomLabel15.Name = "CustomLabel15"
        Me.CustomLabel15.Size = New System.Drawing.Size(118, 23)
        Me.CustomLabel15.TabIndex = 15
        Me.CustomLabel15.Text = "Importe Neto"
        '
        'txtDespacho
        '
        Me.txtDespacho.Cleanable = True
        Me.txtDespacho.Empty = True
        Me.txtDespacho.EnterIndex = 21
        Me.txtDespacho.LabelAssociationKey = 22
        Me.txtDespacho.Location = New System.Drawing.Point(715, 210)
        Me.txtDespacho.Margin = New System.Windows.Forms.Padding(4)
        Me.txtDespacho.MaxLength = 20
        Me.txtDespacho.Name = "txtDespacho"
        Me.txtDespacho.Size = New System.Drawing.Size(325, 22)
        Me.txtDespacho.TabIndex = 50
        Me.txtDespacho.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtDespacho.Validator = Administracion.ValidatorType.None
        '
        'CustomLabel16
        '
        Me.CustomLabel16.AutoSize = True
        Me.CustomLabel16.ControlAssociationKey = 19
        Me.CustomLabel16.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.CustomLabel16.ForeColor = System.Drawing.SystemColors.Control
        Me.CustomLabel16.Location = New System.Drawing.Point(339, 144)
        Me.CustomLabel16.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.CustomLabel16.Name = "CustomLabel16"
        Me.CustomLabel16.Size = New System.Drawing.Size(143, 23)
        Me.CustomLabel16.TabIndex = 16
        Me.CustomLabel16.Text = "Importe IVA 21%"
        '
        'txtIVA21
        '
        Me.txtIVA21.Cleanable = True
        Me.txtIVA21.Empty = False
        Me.txtIVA21.EnterIndex = 17
        Me.txtIVA21.LabelAssociationKey = 19
        Me.txtIVA21.Location = New System.Drawing.Point(489, 143)
        Me.txtIVA21.Margin = New System.Windows.Forms.Padding(4)
        Me.txtIVA21.Name = "txtIVA21"
        Me.txtIVA21.Size = New System.Drawing.Size(100, 22)
        Me.txtIVA21.TabIndex = 49
        Me.txtIVA21.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtIVA21.Validator = Administracion.ValidatorType.Float
        '
        'CustomLabel17
        '
        Me.CustomLabel17.AutoSize = True
        Me.CustomLabel17.ControlAssociationKey = 16
        Me.CustomLabel17.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.CustomLabel17.ForeColor = System.Drawing.SystemColors.Control
        Me.CustomLabel17.Location = New System.Drawing.Point(60, 176)
        Me.CustomLabel17.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.CustomLabel17.Name = "CustomLabel17"
        Me.CustomLabel17.Size = New System.Drawing.Size(118, 23)
        Me.CustomLabel17.TabIndex = 17
        Me.CustomLabel17.Text = "IVA R.G. 3337"
        '
        'txtIVA27
        '
        Me.txtIVA27.Cleanable = True
        Me.txtIVA27.Empty = False
        Me.txtIVA27.EnterIndex = 18
        Me.txtIVA27.LabelAssociationKey = 20
        Me.txtIVA27.Location = New System.Drawing.Point(489, 175)
        Me.txtIVA27.Margin = New System.Windows.Forms.Padding(4)
        Me.txtIVA27.Name = "txtIVA27"
        Me.txtIVA27.Size = New System.Drawing.Size(100, 22)
        Me.txtIVA27.TabIndex = 48
        Me.txtIVA27.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtIVA27.Validator = Administracion.ValidatorType.Float
        '
        'CustomLabel18
        '
        Me.CustomLabel18.AutoSize = True
        Me.CustomLabel18.ControlAssociationKey = 17
        Me.CustomLabel18.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.CustomLabel18.ForeColor = System.Drawing.SystemColors.Control
        Me.CustomLabel18.Location = New System.Drawing.Point(25, 207)
        Me.CustomLabel18.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.CustomLabel18.Name = "CustomLabel18"
        Me.CustomLabel18.Size = New System.Drawing.Size(148, 23)
        Me.CustomLabel18.TabIndex = 18
        Me.CustomLabel18.Text = "Importe Perc. I.B."
        '
        'txtNoGravado
        '
        Me.txtNoGravado.Cleanable = True
        Me.txtNoGravado.Empty = False
        Me.txtNoGravado.EnterIndex = 19
        Me.txtNoGravado.LabelAssociationKey = 21
        Me.txtNoGravado.Location = New System.Drawing.Point(191, 238)
        Me.txtNoGravado.Margin = New System.Windows.Forms.Padding(4)
        Me.txtNoGravado.Name = "txtNoGravado"
        Me.txtNoGravado.Size = New System.Drawing.Size(108, 22)
        Me.txtNoGravado.TabIndex = 47
        Me.txtNoGravado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtNoGravado.Validator = Administracion.ValidatorType.Float
        '
        'CustomLabel19
        '
        Me.CustomLabel19.AutoSize = True
        Me.CustomLabel19.ControlAssociationKey = 18
        Me.CustomLabel19.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.CustomLabel19.ForeColor = System.Drawing.SystemColors.Control
        Me.CustomLabel19.Location = New System.Drawing.Point(364, 241)
        Me.CustomLabel19.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.CustomLabel19.Name = "CustomLabel19"
        Me.CustomLabel19.Size = New System.Drawing.Size(116, 23)
        Me.CustomLabel19.TabIndex = 19
        Me.CustomLabel19.Text = "Importe Total"
        '
        'txtTotal
        '
        Me.txtTotal.BackColor = System.Drawing.SystemColors.Window
        Me.txtTotal.Cleanable = True
        Me.txtTotal.Empty = False
        Me.txtTotal.Enabled = False
        Me.txtTotal.EnterIndex = -1
        Me.txtTotal.LabelAssociationKey = 18
        Me.txtTotal.Location = New System.Drawing.Point(489, 240)
        Me.txtTotal.Margin = New System.Windows.Forms.Padding(4)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.ReadOnly = True
        Me.txtTotal.Size = New System.Drawing.Size(100, 22)
        Me.txtTotal.TabIndex = 46
        Me.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtTotal.Validator = Administracion.ValidatorType.Float
        '
        'CustomLabel20
        '
        Me.CustomLabel20.AutoSize = True
        Me.CustomLabel20.ControlAssociationKey = 20
        Me.CustomLabel20.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.CustomLabel20.ForeColor = System.Drawing.SystemColors.Control
        Me.CustomLabel20.Location = New System.Drawing.Point(339, 176)
        Me.CustomLabel20.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.CustomLabel20.Name = "CustomLabel20"
        Me.CustomLabel20.Size = New System.Drawing.Size(143, 23)
        Me.CustomLabel20.TabIndex = 20
        Me.CustomLabel20.Text = "Importe IVA 27%"
        '
        'txtNeto
        '
        Me.txtNeto.Cleanable = True
        Me.txtNeto.Empty = False
        Me.txtNeto.EnterIndex = 14
        Me.txtNeto.LabelAssociationKey = 15
        Me.txtNeto.Location = New System.Drawing.Point(191, 143)
        Me.txtNeto.Margin = New System.Windows.Forms.Padding(4)
        Me.txtNeto.Name = "txtNeto"
        Me.txtNeto.Size = New System.Drawing.Size(108, 22)
        Me.txtNeto.TabIndex = 45
        Me.txtNeto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtNeto.Validator = Administracion.ValidatorType.Float
        '
        'CustomLabel21
        '
        Me.CustomLabel21.AutoSize = True
        Me.CustomLabel21.ControlAssociationKey = 21
        Me.CustomLabel21.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.CustomLabel21.ForeColor = System.Drawing.SystemColors.Control
        Me.CustomLabel21.Location = New System.Drawing.Point(7, 239)
        Me.CustomLabel21.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.CustomLabel21.Name = "CustomLabel21"
        Me.CustomLabel21.Size = New System.Drawing.Size(171, 23)
        Me.CustomLabel21.TabIndex = 21
        Me.CustomLabel21.Text = "Importe No Gravado"
        '
        'txtIVARG
        '
        Me.txtIVARG.Cleanable = True
        Me.txtIVARG.Empty = False
        Me.txtIVARG.EnterIndex = 15
        Me.txtIVARG.LabelAssociationKey = 16
        Me.txtIVARG.Location = New System.Drawing.Point(191, 175)
        Me.txtIVARG.Margin = New System.Windows.Forms.Padding(4)
        Me.txtIVARG.Name = "txtIVARG"
        Me.txtIVARG.Size = New System.Drawing.Size(108, 22)
        Me.txtIVARG.TabIndex = 44
        Me.txtIVARG.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtIVARG.Validator = Administracion.ValidatorType.Float
        '
        'CustomLabel22
        '
        Me.CustomLabel22.AutoSize = True
        Me.CustomLabel22.ControlAssociationKey = 23
        Me.CustomLabel22.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.CustomLabel22.ForeColor = System.Drawing.SystemColors.Control
        Me.CustomLabel22.Location = New System.Drawing.Point(324, 210)
        Me.CustomLabel22.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.CustomLabel22.Name = "CustomLabel22"
        Me.CustomLabel22.Size = New System.Drawing.Size(158, 23)
        Me.CustomLabel22.TabIndex = 22
        Me.CustomLabel22.Text = "Importe IVA 10.5%"
        '
        'txtPercIB
        '
        Me.txtPercIB.Cleanable = True
        Me.txtPercIB.Empty = False
        Me.txtPercIB.EnterIndex = 16
        Me.txtPercIB.LabelAssociationKey = 17
        Me.txtPercIB.Location = New System.Drawing.Point(191, 206)
        Me.txtPercIB.Margin = New System.Windows.Forms.Padding(4)
        Me.txtPercIB.Name = "txtPercIB"
        Me.txtPercIB.ReadOnly = True
        Me.txtPercIB.Size = New System.Drawing.Size(108, 22)
        Me.txtPercIB.TabIndex = 43
        Me.txtPercIB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtPercIB.Validator = Administracion.ValidatorType.Float
        '
        'CustomLabel23
        '
        Me.CustomLabel23.AutoSize = True
        Me.CustomLabel23.ControlAssociationKey = 22
        Me.CustomLabel23.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.CustomLabel23.ForeColor = System.Drawing.SystemColors.Control
        Me.CustomLabel23.Location = New System.Drawing.Point(616, 212)
        Me.CustomLabel23.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.CustomLabel23.Name = "CustomLabel23"
        Me.CustomLabel23.Size = New System.Drawing.Size(87, 23)
        Me.CustomLabel23.TabIndex = 23
        Me.CustomLabel23.Text = "Despacho"
        '
        'txtParidad
        '
        Me.txtParidad.Cleanable = True
        Me.txtParidad.Empty = True
        Me.txtParidad.EnterIndex = 13
        Me.txtParidad.LabelAssociationKey = 14
        Me.txtParidad.Location = New System.Drawing.Point(868, 111)
        Me.txtParidad.Margin = New System.Windows.Forms.Padding(4)
        Me.txtParidad.Name = "txtParidad"
        Me.txtParidad.Size = New System.Drawing.Size(180, 22)
        Me.txtParidad.TabIndex = 42
        Me.txtParidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtParidad.Validator = Administracion.ValidatorType.PositiveFloat
        '
        'cmbFormaPago
        '
        Me.cmbFormaPago.Cleanable = True
        Me.cmbFormaPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFormaPago.Empty = False
        Me.cmbFormaPago.EnterIndex = 12
        Me.cmbFormaPago.FormattingEnabled = True
        Me.cmbFormaPago.Items.AddRange(New Object() {"", "Pesos", "Cláusula Dólar"})
        Me.cmbFormaPago.LabelAssociationKey = 13
        Me.cmbFormaPago.Location = New System.Drawing.Point(551, 111)
        Me.cmbFormaPago.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbFormaPago.Name = "cmbFormaPago"
        Me.cmbFormaPago.Size = New System.Drawing.Size(208, 24)
        Me.cmbFormaPago.TabIndex = 41
        Me.cmbFormaPago.Validator = Administracion.ValidatorType.None
        '
        'txtRemito
        '
        Me.txtRemito.Cleanable = True
        Me.txtRemito.Empty = True
        Me.txtRemito.EnterIndex = 11
        Me.txtRemito.LabelAssociationKey = 11
        Me.txtRemito.Location = New System.Drawing.Point(624, 80)
        Me.txtRemito.Margin = New System.Windows.Forms.Padding(4)
        Me.txtRemito.MaxLength = 30
        Me.txtRemito.Name = "txtRemito"
        Me.txtRemito.Size = New System.Drawing.Size(367, 22)
        Me.txtRemito.TabIndex = 39
        Me.ToolTip1.SetToolTip(Me.txtRemito, "Doble Click: Consultar detalles de Remitos")
        Me.txtRemito.Validator = Administracion.ValidatorType.None
        '
        'cmbTipo
        '
        Me.cmbTipo.Cleanable = True
        Me.cmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipo.Empty = False
        Me.cmbTipo.EnterIndex = 3
        Me.cmbTipo.FormattingEnabled = True
        Me.cmbTipo.Items.AddRange(New Object() {"", "FC", "ND", "NC", "DI", "OC"})
        Me.cmbTipo.LabelAssociationKey = 4
        Me.cmbTipo.Location = New System.Drawing.Point(191, 49)
        Me.cmbTipo.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbTipo.Name = "cmbTipo"
        Me.cmbTipo.Size = New System.Drawing.Size(108, 24)
        Me.cmbTipo.TabIndex = 30
        Me.cmbTipo.Validator = Administracion.ValidatorType.None
        '
        'txtPunto
        '
        Me.txtPunto.Cleanable = True
        Me.txtPunto.Empty = False
        Me.txtPunto.EnterIndex = 5
        Me.txtPunto.LabelAssociationKey = 6
        Me.txtPunto.Location = New System.Drawing.Point(505, 49)
        Me.txtPunto.Margin = New System.Windows.Forms.Padding(4)
        Me.txtPunto.MaxLength = 4
        Me.txtPunto.Name = "txtPunto"
        Me.txtPunto.Size = New System.Drawing.Size(65, 22)
        Me.txtPunto.TabIndex = 32
        Me.txtPunto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtPunto.Validator = Administracion.ValidatorType.Numeric
        '
        'txtTipo
        '
        Me.txtTipo.Cleanable = True
        Me.txtTipo.Empty = False
        Me.txtTipo.EnterIndex = 4
        Me.txtTipo.LabelAssociationKey = 4
        Me.txtTipo.Location = New System.Drawing.Point(195, 49)
        Me.txtTipo.Margin = New System.Windows.Forms.Padding(4)
        Me.txtTipo.MaxLength = 2
        Me.txtTipo.Name = "txtTipo"
        Me.txtTipo.Size = New System.Drawing.Size(33, 22)
        Me.txtTipo.TabIndex = 29
        Me.txtTipo.Validator = Administracion.ValidatorType.None
        Me.txtTipo.Visible = False
        '
        'btnApertura
        '
        Me.btnApertura.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnApertura.Cleanable = False
        Me.btnApertura.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnApertura.EnterIndex = -1
        Me.btnApertura.FlatAppearance.BorderSize = 0
        Me.btnApertura.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.Control
        Me.btnApertura.LabelAssociationKey = -1
        Me.btnApertura.Location = New System.Drawing.Point(613, 702)
        Me.btnApertura.Margin = New System.Windows.Forms.Padding(4)
        Me.btnApertura.Name = "btnApertura"
        Me.btnApertura.Size = New System.Drawing.Size(203, 53)
        Me.btnApertura.TabIndex = 59
        Me.btnApertura.Text = "Apertura"
        Me.ToolTip1.SetToolTip(Me.btnApertura, "Ingresar detalles de Apertura")
        Me.btnApertura.UseVisualStyleBackColor = True
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
        Me.btnConsulta.Location = New System.Drawing.Point(384, 702)
        Me.btnConsulta.Margin = New System.Windows.Forms.Padding(4)
        Me.btnConsulta.Name = "btnConsulta"
        Me.btnConsulta.Size = New System.Drawing.Size(92, 53)
        Me.btnConsulta.TabIndex = 58
        Me.ToolTip1.SetToolTip(Me.btnConsulta, "Consulta de Proveedores/Cuentas Contables")
        Me.btnConsulta.UseVisualStyleBackColor = True
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
        Me.btnCerrar.Location = New System.Drawing.Point(499, 702)
        Me.btnCerrar.Margin = New System.Windows.Forms.Padding(4)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(92, 53)
        Me.btnCerrar.TabIndex = 57
        Me.ToolTip1.SetToolTip(Me.btnCerrar, "Cerrar")
        Me.btnCerrar.UseVisualStyleBackColor = True
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
        Me.btnAgregar.Location = New System.Drawing.Point(40, 702)
        Me.btnAgregar.Margin = New System.Windows.Forms.Padding(4)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(92, 53)
        Me.btnAgregar.TabIndex = 53
        Me.ToolTip1.SetToolTip(Me.btnAgregar, "Aceptar")
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'btnEliminar
        '
        Me.btnEliminar.BackgroundImage = Global.Administracion.My.Resources.Resources.eliminar
        Me.btnEliminar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnEliminar.Cleanable = False
        Me.btnEliminar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnEliminar.EnterIndex = -1
        Me.btnEliminar.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnEliminar.FlatAppearance.BorderSize = 0
        Me.btnEliminar.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.Control
        Me.btnEliminar.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control
        Me.btnEliminar.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control
        Me.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEliminar.LabelAssociationKey = -1
        Me.btnEliminar.Location = New System.Drawing.Point(155, 702)
        Me.btnEliminar.Margin = New System.Windows.Forms.Padding(4)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(92, 53)
        Me.btnEliminar.TabIndex = 54
        Me.ToolTip1.SetToolTip(Me.btnEliminar, "Eliminar Comprobante")
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'btnConsultaNroFactura
        '
        Me.btnConsultaNroFactura.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnConsultaNroFactura.Cleanable = False
        Me.btnConsultaNroFactura.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnConsultaNroFactura.EnterIndex = -1
        Me.btnConsultaNroFactura.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnConsultaNroFactura.FlatAppearance.BorderSize = 0
        Me.btnConsultaNroFactura.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.Control
        Me.btnConsultaNroFactura.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control
        Me.btnConsultaNroFactura.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control
        Me.btnConsultaNroFactura.LabelAssociationKey = -1
        Me.btnConsultaNroFactura.Location = New System.Drawing.Point(839, 702)
        Me.btnConsultaNroFactura.Margin = New System.Windows.Forms.Padding(4)
        Me.btnConsultaNroFactura.Name = "btnConsultaNroFactura"
        Me.btnConsultaNroFactura.Size = New System.Drawing.Size(203, 53)
        Me.btnConsultaNroFactura.TabIndex = 56
        Me.btnConsultaNroFactura.Text = "Consulta Nro. de Factura"
        Me.ToolTip1.SetToolTip(Me.btnConsultaNroFactura, "Consultar Comprobante  por Nro de Factura")
        Me.btnConsultaNroFactura.UseVisualStyleBackColor = True
        Me.btnConsultaNroFactura.Visible = False
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
        Me.btnLimpiar.Location = New System.Drawing.Point(269, 702)
        Me.btnLimpiar.Margin = New System.Windows.Forms.Padding(4)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(92, 53)
        Me.btnLimpiar.TabIndex = 55
        Me.ToolTip1.SetToolTip(Me.btnLimpiar, "Limpiar Formulario")
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'Compras
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1081, 761)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.PanelPrincipal)
        Me.Controls.Add(Me.btnApertura)
        Me.Controls.Add(Me.btnConsulta)
        Me.Controls.Add(Me.btnCerrar)
        Me.Controls.Add(Me.btnAgregar)
        Me.Controls.Add(Me.btnEliminar)
        Me.Controls.Add(Me.btnConsultaNroFactura)
        Me.Controls.Add(Me.btnLimpiar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.Name = "Compras"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.gbTipo.ResumeLayout(False)
        Me.gbTipo.PerformLayout()
        CType(Me.gridAsientos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.PanelPrincipal.ResumeLayout(False)
        Me.PanelPrincipal.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CustomLabel1 As Administracion.CustomLabel
    Friend WithEvents CustomLabel2 As Administracion.CustomLabel
    Friend WithEvents lblCai As Administracion.CustomLabel
    Friend WithEvents CustomLabel4 As Administracion.CustomLabel
    Friend WithEvents CustomLabel5 As Administracion.CustomLabel
    Friend WithEvents CustomLabel6 As Administracion.CustomLabel
    Friend WithEvents CustomLabel7 As Administracion.CustomLabel
    Friend WithEvents lblVtoCai As Administracion.CustomLabel
    Friend WithEvents CustomLabel9 As Administracion.CustomLabel
    Friend WithEvents CustomLabel10 As Administracion.CustomLabel
    Friend WithEvents CustomLabel11 As Administracion.CustomLabel
    Friend WithEvents CustomLabel12 As Administracion.CustomLabel
    Friend WithEvents CustomLabel13 As Administracion.CustomLabel
    Friend WithEvents CustomLabel14 As Administracion.CustomLabel
    Friend WithEvents CustomLabel15 As Administracion.CustomLabel
    Friend WithEvents CustomLabel16 As Administracion.CustomLabel
    Friend WithEvents CustomLabel17 As Administracion.CustomLabel
    Friend WithEvents CustomLabel18 As Administracion.CustomLabel
    Friend WithEvents CustomLabel19 As Administracion.CustomLabel
    Friend WithEvents CustomLabel20 As Administracion.CustomLabel
    Friend WithEvents CustomLabel21 As Administracion.CustomLabel
    Friend WithEvents CustomLabel22 As Administracion.CustomLabel
    Friend WithEvents CustomLabel23 As Administracion.CustomLabel
    Friend WithEvents chkSoloIVA As System.Windows.Forms.CheckBox
    Friend WithEvents gbTipo As System.Windows.Forms.GroupBox
    Friend WithEvents optNacion As System.Windows.Forms.RadioButton
    Friend WithEvents optCtaCte As System.Windows.Forms.RadioButton
    Friend WithEvents optEfectivo As System.Windows.Forms.RadioButton
    Friend WithEvents txtNroInterno As Administracion.CustomTextBox
    Friend WithEvents txtCodigoProveedor As Administracion.CustomTextBox
    Friend WithEvents txtNombreProveedor As Administracion.CustomTextBox
    Friend WithEvents txtTipo As Administracion.CustomTextBox
    Friend WithEvents cmbTipo As Administracion.CustomComboBox
    Friend WithEvents txtPunto As Administracion.CustomTextBox
    Friend WithEvents txtNumero As Administracion.CustomTextBox
    Friend WithEvents txtCAI As Administracion.CustomTextBox
    Friend WithEvents txtRemito As Administracion.CustomTextBox
    Friend WithEvents cmbFormaPago As Administracion.CustomComboBox
    Friend WithEvents txtParidad As Administracion.CustomTextBox
    Friend WithEvents txtPercIB As Administracion.CustomTextBox
    Friend WithEvents txtIVARG As Administracion.CustomTextBox
    Friend WithEvents txtNeto As Administracion.CustomTextBox
    Friend WithEvents txtTotal As Administracion.CustomTextBox
    Friend WithEvents txtIVA21 As Administracion.CustomTextBox
    Friend WithEvents txtIVA27 As Administracion.CustomTextBox
    Friend WithEvents txtNoGravado As Administracion.CustomTextBox
    Friend WithEvents txtDespacho As Administracion.CustomTextBox
    Friend WithEvents txtIVA10 As Administracion.CustomTextBox
    Friend WithEvents gridAsientos As System.Windows.Forms.DataGridView
    Friend WithEvents btnCerrar As Administracion.CustomButton
    Friend WithEvents btnConsultaNroFactura As Administracion.CustomButton
    Friend WithEvents btnLimpiar As Administracion.CustomButton
    Friend WithEvents btnEliminar As Administracion.CustomButton
    Friend WithEvents btnAgregar As Administracion.CustomButton
    Friend WithEvents btnConsulta As Administracion.CustomButton
    Friend WithEvents btnApertura As Administracion.CustomButton
    Friend WithEvents lblDebito As Administracion.CustomLabel
    Friend WithEvents lblCredito As Administracion.CustomLabel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PanelPrincipal As System.Windows.Forms.Panel
    Friend WithEvents CBLetra As System.Windows.Forms.ComboBox
    Friend WithEvents txtFechaEmision As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtVtoCAI As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtFechaIVA As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtFechaVto2 As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtFechaVto1 As System.Windows.Forms.MaskedTextBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents CustomButton1 As Administracion.CustomButton
    Friend WithEvents ckChequeRechazado As System.Windows.Forms.CheckBox
    Friend WithEvents ckMarcaDifCambio As System.Windows.Forms.CheckBox
    Friend WithEvents btn_Adjuntar As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Cuenta As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Descripcion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Debito As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Credito As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txt_NroPresup As Administracion.CustomTextBox
    Friend WithEvents CustomLabel3 As Administracion.CustomLabel
End Class
