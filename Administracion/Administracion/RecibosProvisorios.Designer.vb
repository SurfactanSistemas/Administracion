<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RecibosProvisorios
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
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.gridRecibos = New System.Windows.Forms.DataGridView()
        Me.Tipo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.numero = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.fecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.banco = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.importe = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Ref = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Lectora = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ClaveCheque = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ClaveBanco = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ClaveSucursal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NumeroCheque = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NroCta = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NroCuit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.chk_TraerTodosEChques = New System.Windows.Forms.CheckBox()
        Me.btn_VerEcheq = New System.Windows.Forms.Button()
        Me.txtFechaAux = New System.Windows.Forms.MaskedTextBox()
        Me.txtFecha = New System.Windows.Forms.MaskedTextBox()
        Me.CustomLabel1 = New Administracion.CustomLabel()
        Me.CustomLabel10 = New Administracion.CustomLabel()
        Me.CustomLabel2 = New Administracion.CustomLabel()
        Me.lblDiferencia = New Administracion.CustomLabel()
        Me.lblTotal = New Administracion.CustomLabel()
        Me.lstSeleccion = New Administracion.CustomListBox()
        Me.CustomLabel3 = New Administracion.CustomLabel()
        Me.txtConsulta = New Administracion.CustomTextBox()
        Me.txtRecibo = New Administracion.CustomTextBox()
        Me.txtCliente = New Administracion.CustomTextBox()
        Me.txtNombre = New Administracion.CustomTextBox()
        Me.txtRetGanancias = New Administracion.CustomTextBox()
        Me.CustomLabel4 = New Administracion.CustomLabel()
        Me.CustomLabel5 = New Administracion.CustomLabel()
        Me.txtRetIva = New Administracion.CustomTextBox()
        Me.txtTotal = New Administracion.CustomTextBox()
        Me.txtRetIB = New Administracion.CustomTextBox()
        Me.CustomLabel12 = New Administracion.CustomLabel()
        Me.CustomLabel8 = New Administracion.CustomLabel()
        Me.CustomLabel7 = New Administracion.CustomLabel()
        Me.CustomLabel9 = New Administracion.CustomLabel()
        Me.CustomLabel6 = New Administracion.CustomLabel()
        Me.txtParidad = New Administracion.CustomTextBox()
        Me.txtRetSuss = New Administracion.CustomTextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.optVarios = New System.Windows.Forms.RadioButton()
        Me.optAnticipos = New System.Windows.Forms.RadioButton()
        Me.optCtaCte = New System.Windows.Forms.RadioButton()
        Me.lstFiltrada = New Administracion.CustomListBox()
        Me.lstConsulta = New Administracion.CustomListBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnLimpiar = New Administracion.CustomButton()
        Me.btnCerrar = New Administracion.CustomButton()
        Me.btnIntereses = New Administracion.CustomButton()
        Me.btnEliminar = New Administracion.CustomButton()
        Me.btnConsulta = New Administracion.CustomButton()
        Me.btnAgregar = New Administracion.CustomButton()
        Me.btn_InformarFinCarga = New System.Windows.Forms.Button()
        CType(Me.gridRecibos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'gridRecibos
        '
        Me.gridRecibos.AllowUserToAddRows = False
        Me.gridRecibos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gridRecibos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.gridRecibos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridRecibos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Tipo, Me.numero, Me.fecha, Me.banco, Me.importe, Me.Ref, Me.Lectora, Me.ClaveCheque, Me.ClaveBanco, Me.ClaveSucursal, Me.NumeroCheque, Me.NroCta, Me.NroCuit})
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gridRecibos.DefaultCellStyle = DataGridViewCellStyle6
        Me.gridRecibos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.gridRecibos.Location = New System.Drawing.Point(28, 180)
        Me.gridRecibos.Margin = New System.Windows.Forms.Padding(4)
        Me.gridRecibos.Name = "gridRecibos"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gridRecibos.RowHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.gridRecibos.Size = New System.Drawing.Size(865, 266)
        Me.gridRecibos.TabIndex = 13
        '
        'Tipo
        '
        Me.Tipo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Tipo.DefaultCellStyle = DataGridViewCellStyle2
        Me.Tipo.FillWeight = 80.0!
        Me.Tipo.HeaderText = "Tipo"
        Me.Tipo.MaxInputLength = 31
        Me.Tipo.Name = "Tipo"
        Me.Tipo.Width = 65
        '
        'numero
        '
        Me.numero.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.numero.DefaultCellStyle = DataGridViewCellStyle3
        Me.numero.FillWeight = 120.0!
        Me.numero.HeaderText = "Numero/Cta"
        Me.numero.MaxInputLength = 8
        Me.numero.Name = "numero"
        Me.numero.Width = 120
        '
        'fecha
        '
        Me.fecha.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.fecha.DefaultCellStyle = DataGridViewCellStyle4
        Me.fecha.FillWeight = 120.0!
        Me.fecha.HeaderText = "Fecha"
        Me.fecha.MaxInputLength = 10
        Me.fecha.Name = "fecha"
        Me.fecha.Width = 110
        '
        'banco
        '
        Me.banco.HeaderText = "Banco"
        Me.banco.MaxInputLength = 20
        Me.banco.Name = "banco"
        '
        'importe
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.Format = "N2"
        DataGridViewCellStyle5.NullValue = Nothing
        Me.importe.DefaultCellStyle = DataGridViewCellStyle5
        Me.importe.HeaderText = "Importe"
        Me.importe.Name = "importe"
        '
        'Ref
        '
        Me.Ref.HeaderText = "Ref"
        Me.Ref.Name = "Ref"
        Me.Ref.ReadOnly = True
        Me.Ref.Visible = False
        '
        'Lectora
        '
        Me.Lectora.HeaderText = "Lectora"
        Me.Lectora.Name = "Lectora"
        Me.Lectora.Visible = False
        '
        'ClaveCheque
        '
        Me.ClaveCheque.HeaderText = "ClaveCheque"
        Me.ClaveCheque.Name = "ClaveCheque"
        Me.ClaveCheque.Visible = False
        '
        'ClaveBanco
        '
        Me.ClaveBanco.HeaderText = "ClaveBanco"
        Me.ClaveBanco.Name = "ClaveBanco"
        Me.ClaveBanco.Visible = False
        '
        'ClaveSucursal
        '
        Me.ClaveSucursal.HeaderText = "ClaveSucursal"
        Me.ClaveSucursal.Name = "ClaveSucursal"
        Me.ClaveSucursal.Visible = False
        '
        'NumeroCheque
        '
        Me.NumeroCheque.HeaderText = "NumeroCheque"
        Me.NumeroCheque.Name = "NumeroCheque"
        Me.NumeroCheque.Visible = False
        '
        'NroCta
        '
        Me.NroCta.HeaderText = "NroCta"
        Me.NroCta.Name = "NroCta"
        Me.NroCta.Visible = False
        '
        'NroCuit
        '
        Me.NroCuit.HeaderText = "NroCuit"
        Me.NroCuit.Name = "NroCuit"
        Me.NroCuit.Visible = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(921, 62)
        Me.Panel1.TabIndex = 119
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.Control
        Me.Label2.Location = New System.Drawing.Point(680, 15)
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
        Me.Label1.Location = New System.Drawing.Point(36, 18)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(264, 24)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Ingreso de Recibos Provisorios"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(95, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(82, Byte), Integer))
        Me.Panel2.Controls.Add(Me.btn_InformarFinCarga)
        Me.Panel2.Controls.Add(Me.chk_TraerTodosEChques)
        Me.Panel2.Controls.Add(Me.btn_VerEcheq)
        Me.Panel2.Controls.Add(Me.txtFechaAux)
        Me.Panel2.Controls.Add(Me.txtFecha)
        Me.Panel2.Controls.Add(Me.CustomLabel1)
        Me.Panel2.Controls.Add(Me.CustomLabel10)
        Me.Panel2.Controls.Add(Me.CustomLabel2)
        Me.Panel2.Controls.Add(Me.lblDiferencia)
        Me.Panel2.Controls.Add(Me.lblTotal)
        Me.Panel2.Controls.Add(Me.lstSeleccion)
        Me.Panel2.Controls.Add(Me.CustomLabel3)
        Me.Panel2.Controls.Add(Me.txtConsulta)
        Me.Panel2.Controls.Add(Me.txtRecibo)
        Me.Panel2.Controls.Add(Me.txtCliente)
        Me.Panel2.Controls.Add(Me.txtNombre)
        Me.Panel2.Controls.Add(Me.gridRecibos)
        Me.Panel2.Controls.Add(Me.txtRetGanancias)
        Me.Panel2.Controls.Add(Me.CustomLabel4)
        Me.Panel2.Controls.Add(Me.CustomLabel5)
        Me.Panel2.Controls.Add(Me.txtRetIva)
        Me.Panel2.Controls.Add(Me.txtTotal)
        Me.Panel2.Controls.Add(Me.txtRetIB)
        Me.Panel2.Controls.Add(Me.CustomLabel12)
        Me.Panel2.Controls.Add(Me.CustomLabel8)
        Me.Panel2.Controls.Add(Me.CustomLabel7)
        Me.Panel2.Controls.Add(Me.CustomLabel9)
        Me.Panel2.Controls.Add(Me.CustomLabel6)
        Me.Panel2.Controls.Add(Me.txtParidad)
        Me.Panel2.Controls.Add(Me.txtRetSuss)
        Me.Panel2.Controls.Add(Me.GroupBox1)
        Me.Panel2.Controls.Add(Me.lstFiltrada)
        Me.Panel2.Controls.Add(Me.lstConsulta)
        Me.Panel2.Location = New System.Drawing.Point(0, 62)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(921, 521)
        Me.Panel2.TabIndex = 120
        '
        'chk_TraerTodosEChques
        '
        Me.chk_TraerTodosEChques.AutoSize = True
        Me.chk_TraerTodosEChques.Location = New System.Drawing.Point(13, 500)
        Me.chk_TraerTodosEChques.Name = "chk_TraerTodosEChques"
        Me.chk_TraerTodosEChques.Size = New System.Drawing.Size(164, 21)
        Me.chk_TraerTodosEChques.TabIndex = 125
        Me.chk_TraerTodosEChques.Text = "Todos los E-cheques"
        Me.chk_TraerTodosEChques.UseVisualStyleBackColor = True
        '
        'btn_VerEcheq
        '
        Me.btn_VerEcheq.Location = New System.Drawing.Point(13, 447)
        Me.btn_VerEcheq.Name = "btn_VerEcheq"
        Me.btn_VerEcheq.Size = New System.Drawing.Size(90, 54)
        Me.btn_VerEcheq.TabIndex = 124
        Me.btn_VerEcheq.Text = "Ver E-Cheques"
        Me.btn_VerEcheq.UseVisualStyleBackColor = True
        '
        'txtFechaAux
        '
        Me.txtFechaAux.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtFechaAux.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtFechaAux.Location = New System.Drawing.Point(377, 246)
        Me.txtFechaAux.Margin = New System.Windows.Forms.Padding(0)
        Me.txtFechaAux.Mask = "00/00/0000"
        Me.txtFechaAux.MaximumSize = New System.Drawing.Size(80, 15)
        Me.txtFechaAux.MinimumSize = New System.Drawing.Size(80, 15)
        Me.txtFechaAux.Name = "txtFechaAux"
        Me.txtFechaAux.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtFechaAux.Size = New System.Drawing.Size(80, 16)
        Me.txtFechaAux.TabIndex = 123
        Me.txtFechaAux.ValidatingType = GetType(Date)
        Me.txtFechaAux.Visible = False
        '
        'txtFecha
        '
        Me.txtFecha.Location = New System.Drawing.Point(425, 9)
        Me.txtFecha.Margin = New System.Windows.Forms.Padding(4)
        Me.txtFecha.Mask = "##/##/####"
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtFecha.Size = New System.Drawing.Size(107, 22)
        Me.txtFecha.TabIndex = 2
        Me.txtFecha.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'CustomLabel1
        '
        Me.CustomLabel1.AutoSize = True
        Me.CustomLabel1.ControlAssociationKey = 1
        Me.CustomLabel1.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.CustomLabel1.ForeColor = System.Drawing.SystemColors.Control
        Me.CustomLabel1.Location = New System.Drawing.Point(60, 10)
        Me.CustomLabel1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.CustomLabel1.Name = "CustomLabel1"
        Me.CustomLabel1.Size = New System.Drawing.Size(103, 23)
        Me.CustomLabel1.TabIndex = 0
        Me.CustomLabel1.Text = "Nro. Recibo"
        '
        'CustomLabel10
        '
        Me.CustomLabel10.BackColor = System.Drawing.SystemColors.Control
        Me.CustomLabel10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.CustomLabel10.ControlAssociationKey = -1
        Me.CustomLabel10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CustomLabel10.Location = New System.Drawing.Point(265, 452)
        Me.CustomLabel10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.CustomLabel10.Name = "CustomLabel10"
        Me.CustomLabel10.Size = New System.Drawing.Size(466, 27)
        Me.CustomLabel10.TabIndex = 118
        Me.CustomLabel10.Text = "Tipo Doc.:    1) Ef.    2) Ch.    4) Varios   7) Ch. Electr"
        Me.CustomLabel10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CustomLabel2
        '
        Me.CustomLabel2.AutoSize = True
        Me.CustomLabel2.ControlAssociationKey = 3
        Me.CustomLabel2.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.CustomLabel2.ForeColor = System.Drawing.SystemColors.Control
        Me.CustomLabel2.Location = New System.Drawing.Point(55, 42)
        Me.CustomLabel2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.CustomLabel2.Name = "CustomLabel2"
        Me.CustomLabel2.Size = New System.Drawing.Size(106, 23)
        Me.CustomLabel2.TabIndex = 1
        Me.CustomLabel2.Text = "Cod. Cliente"
        '
        'lblDiferencia
        '
        Me.lblDiferencia.BackColor = System.Drawing.SystemColors.Control
        Me.lblDiferencia.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDiferencia.ControlAssociationKey = -1
        Me.lblDiferencia.Location = New System.Drawing.Point(744, 484)
        Me.lblDiferencia.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDiferencia.Name = "lblDiferencia"
        Me.lblDiferencia.Size = New System.Drawing.Size(147, 27)
        Me.lblDiferencia.TabIndex = 74
        Me.lblDiferencia.Text = "0,00"
        Me.lblDiferencia.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTotal
        '
        Me.lblTotal.BackColor = System.Drawing.SystemColors.Control
        Me.lblTotal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTotal.ControlAssociationKey = -1
        Me.lblTotal.Location = New System.Drawing.Point(744, 452)
        Me.lblTotal.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(147, 27)
        Me.lblTotal.TabIndex = 74
        Me.lblTotal.Text = "0,00"
        Me.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lstSeleccion
        '
        Me.lstSeleccion.Cleanable = False
        Me.lstSeleccion.EnterIndex = -1
        Me.lstSeleccion.FormattingEnabled = True
        Me.lstSeleccion.ItemHeight = 16
        Me.lstSeleccion.LabelAssociationKey = -1
        Me.lstSeleccion.Location = New System.Drawing.Point(543, 7)
        Me.lstSeleccion.Margin = New System.Windows.Forms.Padding(4)
        Me.lstSeleccion.Name = "lstSeleccion"
        Me.lstSeleccion.Size = New System.Drawing.Size(349, 132)
        Me.lstSeleccion.TabIndex = 78
        Me.lstSeleccion.Visible = False
        '
        'CustomLabel3
        '
        Me.CustomLabel3.AutoSize = True
        Me.CustomLabel3.ControlAssociationKey = 2
        Me.CustomLabel3.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.CustomLabel3.ForeColor = System.Drawing.SystemColors.Control
        Me.CustomLabel3.Location = New System.Drawing.Point(359, 10)
        Me.CustomLabel3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.CustomLabel3.Name = "CustomLabel3"
        Me.CustomLabel3.Size = New System.Drawing.Size(56, 23)
        Me.CustomLabel3.TabIndex = 3
        Me.CustomLabel3.Text = "Fecha"
        '
        'txtConsulta
        '
        Me.txtConsulta.Cleanable = False
        Me.txtConsulta.Empty = True
        Me.txtConsulta.EnterIndex = -1
        Me.txtConsulta.LabelAssociationKey = -1
        Me.txtConsulta.Location = New System.Drawing.Point(541, 15)
        Me.txtConsulta.Margin = New System.Windows.Forms.Padding(4)
        Me.txtConsulta.Name = "txtConsulta"
        Me.txtConsulta.Size = New System.Drawing.Size(349, 22)
        Me.txtConsulta.TabIndex = 77
        Me.txtConsulta.Validator = Administracion.ValidatorType.None
        Me.txtConsulta.Visible = False
        '
        'txtRecibo
        '
        Me.txtRecibo.Cleanable = True
        Me.txtRecibo.Empty = False
        Me.txtRecibo.EnterIndex = 1
        Me.txtRecibo.LabelAssociationKey = 1
        Me.txtRecibo.Location = New System.Drawing.Point(175, 9)
        Me.txtRecibo.Margin = New System.Windows.Forms.Padding(4)
        Me.txtRecibo.MaxLength = 6
        Me.txtRecibo.Name = "txtRecibo"
        Me.txtRecibo.Size = New System.Drawing.Size(115, 22)
        Me.txtRecibo.TabIndex = 0
        Me.txtRecibo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtRecibo.Validator = Administracion.ValidatorType.Numeric
        '
        'txtCliente
        '
        Me.txtCliente.Cleanable = True
        Me.txtCliente.Empty = False
        Me.txtCliente.EnterIndex = 3
        Me.txtCliente.LabelAssociationKey = 3
        Me.txtCliente.Location = New System.Drawing.Point(175, 41)
        Me.txtCliente.Margin = New System.Windows.Forms.Padding(4)
        Me.txtCliente.MaxLength = 6
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.Size = New System.Drawing.Size(115, 22)
        Me.txtCliente.TabIndex = 2
        Me.ToolTip1.SetToolTip(Me.txtCliente, "Doble Click: Abrir Consulta de Clientes")
        Me.txtCliente.Validator = Administracion.ValidatorType.None
        '
        'txtNombre
        '
        Me.txtNombre.Cleanable = True
        Me.txtNombre.Empty = False
        Me.txtNombre.Enabled = False
        Me.txtNombre.EnterIndex = -1
        Me.txtNombre.LabelAssociationKey = 3
        Me.txtNombre.Location = New System.Drawing.Point(299, 41)
        Me.txtNombre.Margin = New System.Windows.Forms.Padding(4)
        Me.txtNombre.MaxLength = 1000
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(233, 22)
        Me.txtNombre.TabIndex = 12
        Me.txtNombre.Validator = Administracion.ValidatorType.None
        '
        'txtRetGanancias
        '
        Me.txtRetGanancias.Cleanable = True
        Me.txtRetGanancias.Empty = False
        Me.txtRetGanancias.EnterIndex = 4
        Me.txtRetGanancias.LabelAssociationKey = 4
        Me.txtRetGanancias.Location = New System.Drawing.Point(175, 73)
        Me.txtRetGanancias.Margin = New System.Windows.Forms.Padding(4)
        Me.txtRetGanancias.Name = "txtRetGanancias"
        Me.txtRetGanancias.Size = New System.Drawing.Size(115, 22)
        Me.txtRetGanancias.TabIndex = 3
        Me.txtRetGanancias.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtRetGanancias.Validator = Administracion.ValidatorType.PositiveFloat
        '
        'CustomLabel4
        '
        Me.CustomLabel4.AutoSize = True
        Me.CustomLabel4.ControlAssociationKey = 4
        Me.CustomLabel4.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.CustomLabel4.ForeColor = System.Drawing.SystemColors.Control
        Me.CustomLabel4.Location = New System.Drawing.Point(35, 74)
        Me.CustomLabel4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.CustomLabel4.Name = "CustomLabel4"
        Me.CustomLabel4.Size = New System.Drawing.Size(127, 23)
        Me.CustomLabel4.TabIndex = 15
        Me.CustomLabel4.Text = "Ret. Ganancias"
        '
        'CustomLabel5
        '
        Me.CustomLabel5.AutoSize = True
        Me.CustomLabel5.ControlAssociationKey = 6
        Me.CustomLabel5.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.CustomLabel5.ForeColor = System.Drawing.SystemColors.Control
        Me.CustomLabel5.Location = New System.Drawing.Point(91, 106)
        Me.CustomLabel5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.CustomLabel5.Name = "CustomLabel5"
        Me.CustomLabel5.Size = New System.Drawing.Size(74, 23)
        Me.CustomLabel5.TabIndex = 16
        Me.CustomLabel5.Text = "Ret. IVA"
        '
        'txtRetIva
        '
        Me.txtRetIva.Cleanable = True
        Me.txtRetIva.Empty = False
        Me.txtRetIva.EnterIndex = 6
        Me.txtRetIva.LabelAssociationKey = 6
        Me.txtRetIva.Location = New System.Drawing.Point(175, 105)
        Me.txtRetIva.Margin = New System.Windows.Forms.Padding(4)
        Me.txtRetIva.Name = "txtRetIva"
        Me.txtRetIva.Size = New System.Drawing.Size(115, 22)
        Me.txtRetIva.TabIndex = 17
        Me.txtRetIva.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtRetIva.Validator = Administracion.ValidatorType.PositiveFloat
        '
        'txtTotal
        '
        Me.txtTotal.Cleanable = True
        Me.txtTotal.Empty = False
        Me.txtTotal.EnterIndex = 8
        Me.txtTotal.LabelAssociationKey = 9
        Me.txtTotal.Location = New System.Drawing.Point(721, 148)
        Me.txtTotal.Margin = New System.Windows.Forms.Padding(4)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.Size = New System.Drawing.Size(171, 22)
        Me.txtTotal.TabIndex = 25
        Me.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtTotal.Validator = Administracion.ValidatorType.PositiveFloat
        '
        'txtRetIB
        '
        Me.txtRetIB.Cleanable = True
        Me.txtRetIB.Empty = False
        Me.txtRetIB.EnterIndex = 5
        Me.txtRetIB.LabelAssociationKey = 5
        Me.txtRetIB.Location = New System.Drawing.Point(425, 71)
        Me.txtRetIB.Margin = New System.Windows.Forms.Padding(4)
        Me.txtRetIB.Name = "txtRetIB"
        Me.txtRetIB.ReadOnly = True
        Me.txtRetIB.Size = New System.Drawing.Size(107, 22)
        Me.txtRetIB.TabIndex = 18
        Me.txtRetIB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtRetIB.Validator = Administracion.ValidatorType.PositiveFloat
        '
        'CustomLabel12
        '
        Me.CustomLabel12.AutoSize = True
        Me.CustomLabel12.ControlAssociationKey = 9
        Me.CustomLabel12.Font = New System.Drawing.Font("Calibri", 9.25!, System.Drawing.FontStyle.Bold)
        Me.CustomLabel12.ForeColor = System.Drawing.SystemColors.Control
        Me.CustomLabel12.Location = New System.Drawing.Point(645, 490)
        Me.CustomLabel12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.CustomLabel12.Name = "CustomLabel12"
        Me.CustomLabel12.Size = New System.Drawing.Size(82, 19)
        Me.CustomLabel12.TabIndex = 24
        Me.CustomLabel12.Text = "Diferencia:"
        '
        'CustomLabel8
        '
        Me.CustomLabel8.AutoSize = True
        Me.CustomLabel8.ControlAssociationKey = 9
        Me.CustomLabel8.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.CustomLabel8.ForeColor = System.Drawing.SystemColors.Control
        Me.CustomLabel8.Location = New System.Drawing.Point(603, 149)
        Me.CustomLabel8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.CustomLabel8.Name = "CustomLabel8"
        Me.CustomLabel8.Size = New System.Drawing.Size(106, 23)
        Me.CustomLabel8.TabIndex = 24
        Me.CustomLabel8.Text = "Total Recibo"
        '
        'CustomLabel7
        '
        Me.CustomLabel7.AutoSize = True
        Me.CustomLabel7.ControlAssociationKey = 5
        Me.CustomLabel7.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.CustomLabel7.ForeColor = System.Drawing.SystemColors.Control
        Me.CustomLabel7.Location = New System.Drawing.Point(344, 73)
        Me.CustomLabel7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.CustomLabel7.Name = "CustomLabel7"
        Me.CustomLabel7.Size = New System.Drawing.Size(73, 23)
        Me.CustomLabel7.TabIndex = 19
        Me.CustomLabel7.Text = "Ret. I.B."
        '
        'CustomLabel9
        '
        Me.CustomLabel9.AutoSize = True
        Me.CustomLabel9.ControlAssociationKey = 8
        Me.CustomLabel9.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.CustomLabel9.ForeColor = System.Drawing.SystemColors.Control
        Me.CustomLabel9.Location = New System.Drawing.Point(711, 41)
        Me.CustomLabel9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.CustomLabel9.Name = "CustomLabel9"
        Me.CustomLabel9.Size = New System.Drawing.Size(70, 23)
        Me.CustomLabel9.TabIndex = 23
        Me.CustomLabel9.Text = "Paridad"
        Me.CustomLabel9.Visible = False
        '
        'CustomLabel6
        '
        Me.CustomLabel6.AutoSize = True
        Me.CustomLabel6.ControlAssociationKey = 7
        Me.CustomLabel6.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.CustomLabel6.ForeColor = System.Drawing.SystemColors.Control
        Me.CustomLabel6.Location = New System.Drawing.Point(329, 105)
        Me.CustomLabel6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.CustomLabel6.Name = "CustomLabel6"
        Me.CustomLabel6.Size = New System.Drawing.Size(87, 23)
        Me.CustomLabel6.TabIndex = 20
        Me.CustomLabel6.Text = "Ret. Suss."
        '
        'txtParidad
        '
        Me.txtParidad.Cleanable = True
        Me.txtParidad.Empty = True
        Me.txtParidad.EnterIndex = -1
        Me.txtParidad.LabelAssociationKey = 8
        Me.txtParidad.Location = New System.Drawing.Point(792, 39)
        Me.txtParidad.Margin = New System.Windows.Forms.Padding(4)
        Me.txtParidad.Name = "txtParidad"
        Me.txtParidad.Size = New System.Drawing.Size(91, 22)
        Me.txtParidad.TabIndex = 22
        Me.txtParidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtParidad.Validator = Administracion.ValidatorType.PositiveFloat
        Me.txtParidad.Visible = False
        '
        'txtRetSuss
        '
        Me.txtRetSuss.Cleanable = True
        Me.txtRetSuss.Empty = False
        Me.txtRetSuss.EnterIndex = 7
        Me.txtRetSuss.LabelAssociationKey = 7
        Me.txtRetSuss.Location = New System.Drawing.Point(425, 103)
        Me.txtRetSuss.Margin = New System.Windows.Forms.Padding(4)
        Me.txtRetSuss.Name = "txtRetSuss"
        Me.txtRetSuss.Size = New System.Drawing.Size(107, 22)
        Me.txtRetSuss.TabIndex = 21
        Me.txtRetSuss.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtRetSuss.Validator = Administracion.ValidatorType.PositiveFloat
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.optVarios)
        Me.GroupBox1.Controls.Add(Me.optAnticipos)
        Me.GroupBox1.Controls.Add(Me.optCtaCte)
        Me.GroupBox1.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.GroupBox1.ForeColor = System.Drawing.SystemColors.Control
        Me.GroupBox1.Location = New System.Drawing.Point(29, 124)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Size = New System.Drawing.Size(505, 50)
        Me.GroupBox1.TabIndex = 121
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Tipo"
        '
        'optVarios
        '
        Me.optVarios.AutoSize = True
        Me.optVarios.Location = New System.Drawing.Point(343, 17)
        Me.optVarios.Margin = New System.Windows.Forms.Padding(4)
        Me.optVarios.Name = "optVarios"
        Me.optVarios.Size = New System.Drawing.Size(80, 27)
        Me.optVarios.TabIndex = 2
        Me.optVarios.Text = "Varios"
        Me.optVarios.UseVisualStyleBackColor = True
        '
        'optAnticipos
        '
        Me.optAnticipos.AutoSize = True
        Me.optAnticipos.Location = New System.Drawing.Point(224, 17)
        Me.optAnticipos.Margin = New System.Windows.Forms.Padding(4)
        Me.optAnticipos.Name = "optAnticipos"
        Me.optAnticipos.Size = New System.Drawing.Size(105, 27)
        Me.optAnticipos.TabIndex = 1
        Me.optAnticipos.Text = "Anticipos"
        Me.optAnticipos.UseVisualStyleBackColor = True
        '
        'optCtaCte
        '
        Me.optCtaCte.AutoSize = True
        Me.optCtaCte.Checked = True
        Me.optCtaCte.Location = New System.Drawing.Point(66, 17)
        Me.optCtaCte.Margin = New System.Windows.Forms.Padding(4)
        Me.optCtaCte.Name = "optCtaCte"
        Me.optCtaCte.Size = New System.Drawing.Size(149, 27)
        Me.optCtaCte.TabIndex = 0
        Me.optCtaCte.TabStop = True
        Me.optCtaCte.Text = "Cobro Cta. Cte."
        Me.optCtaCte.UseVisualStyleBackColor = True
        '
        'lstFiltrada
        '
        Me.lstFiltrada.Cleanable = False
        Me.lstFiltrada.EnterIndex = -1
        Me.lstFiltrada.FormattingEnabled = True
        Me.lstFiltrada.ItemHeight = 16
        Me.lstFiltrada.LabelAssociationKey = -1
        Me.lstFiltrada.Location = New System.Drawing.Point(543, 41)
        Me.lstFiltrada.Margin = New System.Windows.Forms.Padding(4)
        Me.lstFiltrada.Name = "lstFiltrada"
        Me.lstFiltrada.Size = New System.Drawing.Size(349, 100)
        Me.lstFiltrada.TabIndex = 122
        Me.lstFiltrada.Visible = False
        '
        'lstConsulta
        '
        Me.lstConsulta.Cleanable = False
        Me.lstConsulta.EnterIndex = -1
        Me.lstConsulta.FormattingEnabled = True
        Me.lstConsulta.ItemHeight = 16
        Me.lstConsulta.LabelAssociationKey = -1
        Me.lstConsulta.Location = New System.Drawing.Point(541, 41)
        Me.lstConsulta.Margin = New System.Windows.Forms.Padding(4)
        Me.lstConsulta.Name = "lstConsulta"
        Me.lstConsulta.Size = New System.Drawing.Size(349, 100)
        Me.lstConsulta.TabIndex = 76
        Me.lstConsulta.Visible = False
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
        Me.btnLimpiar.Location = New System.Drawing.Point(765, 592)
        Me.btnLimpiar.Margin = New System.Windows.Forms.Padding(4)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(92, 54)
        Me.btnLimpiar.TabIndex = 125
        Me.ToolTip1.SetToolTip(Me.btnLimpiar, "Limpiar Formulario")
        Me.btnLimpiar.UseVisualStyleBackColor = True
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
        Me.btnCerrar.Location = New System.Drawing.Point(625, 592)
        Me.btnCerrar.Margin = New System.Windows.Forms.Padding(4)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(92, 54)
        Me.btnCerrar.TabIndex = 124
        Me.ToolTip1.SetToolTip(Me.btnCerrar, "Cerrar")
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'btnIntereses
        '
        Me.btnIntereses.BackgroundImage = Global.Administracion.My.Resources.Resources.calculadora
        Me.btnIntereses.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnIntereses.Cleanable = False
        Me.btnIntereses.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnIntereses.EnterIndex = -1
        Me.btnIntereses.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnIntereses.FlatAppearance.BorderSize = 0
        Me.btnIntereses.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.Control
        Me.btnIntereses.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control
        Me.btnIntereses.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control
        Me.btnIntereses.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnIntereses.LabelAssociationKey = -1
        Me.btnIntereses.Location = New System.Drawing.Point(485, 592)
        Me.btnIntereses.Margin = New System.Windows.Forms.Padding(4)
        Me.btnIntereses.Name = "btnIntereses"
        Me.btnIntereses.Size = New System.Drawing.Size(92, 54)
        Me.btnIntereses.TabIndex = 123
        Me.ToolTip1.SetToolTip(Me.btnIntereses, "Intereses")
        Me.btnIntereses.UseVisualStyleBackColor = True
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
        Me.btnEliminar.Location = New System.Drawing.Point(205, 592)
        Me.btnEliminar.Margin = New System.Windows.Forms.Padding(4)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(92, 54)
        Me.btnEliminar.TabIndex = 122
        Me.ToolTip1.SetToolTip(Me.btnEliminar, "Eliminar el Recibo Provisorio Actual")
        Me.btnEliminar.UseVisualStyleBackColor = True
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
        Me.btnConsulta.Location = New System.Drawing.Point(345, 592)
        Me.btnConsulta.Margin = New System.Windows.Forms.Padding(4)
        Me.btnConsulta.Name = "btnConsulta"
        Me.btnConsulta.Size = New System.Drawing.Size(92, 54)
        Me.btnConsulta.TabIndex = 122
        Me.ToolTip1.SetToolTip(Me.btnConsulta, "Consulta")
        Me.btnConsulta.UseVisualStyleBackColor = True
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
        Me.btnAgregar.Location = New System.Drawing.Point(65, 592)
        Me.btnAgregar.Margin = New System.Windows.Forms.Padding(4)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(92, 54)
        Me.btnAgregar.TabIndex = 121
        Me.ToolTip1.SetToolTip(Me.btnAgregar, "Aceptar")
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'btn_InformarFinCarga
        '
        Me.btn_InformarFinCarga.Location = New System.Drawing.Point(125, 447)
        Me.btn_InformarFinCarga.Name = "btn_InformarFinCarga"
        Me.btn_InformarFinCarga.Size = New System.Drawing.Size(135, 48)
        Me.btn_InformarFinCarga.TabIndex = 126
        Me.btn_InformarFinCarga.Text = "Informar Final Carga Diario"
        Me.btn_InformarFinCarga.UseVisualStyleBackColor = True
        '
        'RecibosProvisorios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(923, 655)
        Me.Controls.Add(Me.btnLimpiar)
        Me.Controls.Add(Me.btnCerrar)
        Me.Controls.Add(Me.btnIntereses)
        Me.Controls.Add(Me.btnEliminar)
        Me.Controls.Add(Me.btnConsulta)
        Me.Controls.Add(Me.btnAgregar)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Location = New System.Drawing.Point(100, 10)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "RecibosProvisorios"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        CType(Me.gridRecibos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CustomLabel1 As Administracion.CustomLabel
    Friend WithEvents CustomLabel2 As Administracion.CustomLabel
    Friend WithEvents CustomLabel3 As Administracion.CustomLabel
    Friend WithEvents txtRecibo As Administracion.CustomTextBox
    Friend WithEvents txtCliente As Administracion.CustomTextBox
    Friend WithEvents txtNombre As Administracion.CustomTextBox
    Friend WithEvents gridRecibos As System.Windows.Forms.DataGridView
    Friend WithEvents txtRetGanancias As Administracion.CustomTextBox
    Friend WithEvents CustomLabel4 As Administracion.CustomLabel
    Friend WithEvents CustomLabel5 As Administracion.CustomLabel
    Friend WithEvents txtRetIva As Administracion.CustomTextBox
    Friend WithEvents txtRetSuss As Administracion.CustomTextBox
    Friend WithEvents CustomLabel6 As Administracion.CustomLabel
    Friend WithEvents CustomLabel7 As Administracion.CustomLabel
    Friend WithEvents txtRetIB As Administracion.CustomTextBox
    Friend WithEvents txtTotal As Administracion.CustomTextBox
    Friend WithEvents CustomLabel8 As Administracion.CustomLabel
    Friend WithEvents CustomLabel9 As Administracion.CustomLabel
    Friend WithEvents txtParidad As Administracion.CustomTextBox
    Friend WithEvents lblTotal As Administracion.CustomLabel
    Friend WithEvents lstSeleccion As Administracion.CustomListBox
    Friend WithEvents txtConsulta As Administracion.CustomTextBox
    Friend WithEvents lstConsulta As Administracion.CustomListBox
    Friend WithEvents CustomLabel10 As Administracion.CustomLabel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents btnLimpiar As Administracion.CustomButton
    Friend WithEvents btnCerrar As Administracion.CustomButton
    Friend WithEvents btnIntereses As Administracion.CustomButton
    Friend WithEvents btnConsulta As Administracion.CustomButton
    Friend WithEvents btnAgregar As Administracion.CustomButton
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents optVarios As System.Windows.Forms.RadioButton
    Friend WithEvents optAnticipos As System.Windows.Forms.RadioButton
    Friend WithEvents optCtaCte As System.Windows.Forms.RadioButton
    Friend WithEvents txtFecha As System.Windows.Forms.MaskedTextBox
    Friend WithEvents lstFiltrada As Administracion.CustomListBox
    Friend WithEvents txtFechaAux As System.Windows.Forms.MaskedTextBox
    Friend WithEvents btnEliminar As Administracion.CustomButton
    Friend WithEvents lblDiferencia As Administracion.CustomLabel
    Friend WithEvents CustomLabel12 As Administracion.CustomLabel
    Friend WithEvents Tipo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents numero As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents fecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents banco As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents importe As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Ref As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Lectora As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ClaveCheque As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ClaveBanco As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ClaveSucursal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NumeroCheque As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NroCta As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NroCuit As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btn_VerEcheq As System.Windows.Forms.Button
    Friend WithEvents chk_TraerTodosEChques As System.Windows.Forms.CheckBox
    Friend WithEvents btn_InformarFinCarga As System.Windows.Forms.Button
End Class
