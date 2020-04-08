<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InformeRecepcionDrogaLAB
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtNroInforme = New System.Windows.Forms.TextBox()
        Me.mastxtFecha = New System.Windows.Forms.MaskedTextBox()
        Me.txtOrdenCompra = New System.Windows.Forms.TextBox()
        Me.txtProveedor = New System.Windows.Forms.TextBox()
        Me.txtDescripcionProv = New System.Windows.Forms.TextBox()
        Me.txtRemito = New System.Windows.Forms.TextBox()
        Me.DGV_InformeRecepcion = New ConsultasVarias.DBDataGridView()
        Me.Orden = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Producto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CantIngre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SaldoOC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DescOC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Envase = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DescripcionEnvase = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Etiqueta = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Certificado1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Certificado2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Estado1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Estado2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FechaVencimiento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EstadoEnvI = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ObservaI = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EstadoEnvIII = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ObservaIII = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EstadoEnvV = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EstadoEnvVII = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EstadoEnvIX = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CantidadEnv = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtOrden = New System.Windows.Forms.TextBox()
        Me.mastxtMateriaPrima = New System.Windows.Forms.MaskedTextBox()
        Me.txtDescripcionMP = New System.Windows.Forms.TextBox()
        Me.txtCantIngre = New System.Windows.Forms.TextBox()
        Me.txtSaldoOC = New System.Windows.Forms.TextBox()
        Me.txtDescOC = New System.Windows.Forms.TextBox()
        Me.txtEnvase = New System.Windows.Forms.TextBox()
        Me.txtEtiqueta = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.PnlEstadoEnvases = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txtCantRechazada = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.btnAceptar_pnlEstadoEnvases = New System.Windows.Forms.Button()
        Me.txtEstadoEnvases1 = New System.Windows.Forms.TextBox()
        Me.txtCertifAnalisis = New System.Windows.Forms.TextBox()
        Me.pnlEstadoEnvases4 = New System.Windows.Forms.Panel()
        Me.rabtnNOCum_EstadoEnvases4 = New System.Windows.Forms.RadioButton()
        Me.rabtnCum_EstadoEnvases4 = New System.Windows.Forms.RadioButton()
        Me.pnlEstadoEnvases3 = New System.Windows.Forms.Panel()
        Me.rabtnNOCum_EstadoEnvases3 = New System.Windows.Forms.RadioButton()
        Me.rabtnCum_EstadoEnvases3 = New System.Windows.Forms.RadioButton()
        Me.pnlEstadoEnvases2 = New System.Windows.Forms.Panel()
        Me.rabtnNOCum_EstadoEnvases2 = New System.Windows.Forms.RadioButton()
        Me.rabtnCum_EstadoEnvases2 = New System.Windows.Forms.RadioButton()
        Me.pnlEstadoEnvases1 = New System.Windows.Forms.Panel()
        Me.rabtnNOCum_EstadoEnvases1 = New System.Windows.Forms.RadioButton()
        Me.rabtnCum_EstadoEnvases1 = New System.Windows.Forms.RadioButton()
        Me.pnlCertifAnali = New System.Windows.Forms.Panel()
        Me.rabtnNOCum_CertifAnalisis = New System.Windows.Forms.RadioButton()
        Me.rabtnCum_CertifAnalisis = New System.Windows.Forms.RadioButton()
        Me.lblEstadoEnvases4 = New System.Windows.Forms.Label()
        Me.lblEstadoEnvases3 = New System.Windows.Forms.Label()
        Me.lblEstadoEnvases2 = New System.Windows.Forms.Label()
        Me.lblEstadoEnvases1 = New System.Windows.Forms.Label()
        Me.lblCertifAnalisis = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.pnlAviso = New System.Windows.Forms.Panel()
        Me.btnAceptar_pnlAviso = New System.Windows.Forms.Button()
        Me.lblAviso3 = New System.Windows.Forms.Label()
        Me.lblAviso2 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.lblAviso1 = New System.Windows.Forms.Label()
        Me.btnGrabar = New System.Windows.Forms.Button()
        Me.btnLimpiarForm = New System.Windows.Forms.Button()
        Me.btnBuscarProv = New System.Windows.Forms.Button()
        Me.btnVolver = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        CType(Me.DGV_InformeRecepcion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnlEstadoEnvases.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.pnlEstadoEnvases4.SuspendLayout()
        Me.pnlEstadoEnvases3.SuspendLayout()
        Me.pnlEstadoEnvases2.SuspendLayout()
        Me.pnlEstadoEnvases1.SuspendLayout()
        Me.pnlCertifAnali.SuspendLayout()
        Me.pnlAviso.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(788, 45)
        Me.Panel1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.Control
        Me.Label1.Location = New System.Drawing.Point(24, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(326, 18)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Informe de Recepcion de Drogas de Laboratorio"
        '
        'Label2
        '
        Me.Label2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.Control
        Me.Label2.Location = New System.Drawing.Point(609, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(155, 20)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "SURFACTAN S.A."
        '
        'txtNroInforme
        '
        Me.txtNroInforme.Location = New System.Drawing.Point(116, 60)
        Me.txtNroInforme.MaxLength = 6
        Me.txtNroInforme.Name = "txtNroInforme"
        Me.txtNroInforme.Size = New System.Drawing.Size(48, 20)
        Me.txtNroInforme.TabIndex = 1
        Me.txtNroInforme.Text = "999999"
        Me.txtNroInforme.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'mastxtFecha
        '
        Me.mastxtFecha.Location = New System.Drawing.Point(238, 60)
        Me.mastxtFecha.Mask = "00/00/0000"
        Me.mastxtFecha.Name = "mastxtFecha"
        Me.mastxtFecha.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.mastxtFecha.Size = New System.Drawing.Size(71, 20)
        Me.mastxtFecha.TabIndex = 2
        Me.mastxtFecha.Text = "99999999"
        Me.mastxtFecha.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtOrdenCompra
        '
        Me.txtOrdenCompra.Location = New System.Drawing.Point(436, 60)
        Me.txtOrdenCompra.MaxLength = 6
        Me.txtOrdenCompra.Name = "txtOrdenCompra"
        Me.txtOrdenCompra.Size = New System.Drawing.Size(53, 20)
        Me.txtOrdenCompra.TabIndex = 3
        Me.txtOrdenCompra.Text = "999999"
        Me.txtOrdenCompra.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtProveedor
        '
        Me.txtProveedor.Location = New System.Drawing.Point(155, 89)
        Me.txtProveedor.MaxLength = 11
        Me.txtProveedor.Name = "txtProveedor"
        Me.txtProveedor.Size = New System.Drawing.Size(100, 20)
        Me.txtProveedor.TabIndex = 4
        Me.txtProveedor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtDescripcionProv
        '
        Me.txtDescripcionProv.BackColor = System.Drawing.Color.Cyan
        Me.txtDescripcionProv.Enabled = False
        Me.txtDescripcionProv.Location = New System.Drawing.Point(261, 89)
        Me.txtDescripcionProv.Name = "txtDescripcionProv"
        Me.txtDescripcionProv.Size = New System.Drawing.Size(513, 20)
        Me.txtDescripcionProv.TabIndex = 5
        '
        'txtRemito
        '
        Me.txtRemito.Location = New System.Drawing.Point(570, 60)
        Me.txtRemito.MaxLength = 8
        Me.txtRemito.Name = "txtRemito"
        Me.txtRemito.Size = New System.Drawing.Size(100, 20)
        Me.txtRemito.TabIndex = 6
        Me.txtRemito.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'DGV_InformeRecepcion
        '
        Me.DGV_InformeRecepcion.AllowDrop = True
        Me.DGV_InformeRecepcion.AllowUserToAddRows = False
        Me.DGV_InformeRecepcion.AllowUserToDeleteRows = False
        Me.DGV_InformeRecepcion.AllowUserToResizeColumns = False
        Me.DGV_InformeRecepcion.AllowUserToResizeRows = False
        Me.DGV_InformeRecepcion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_InformeRecepcion.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Orden, Me.Producto, Me.Descripcion, Me.CantIngre, Me.SaldoOC, Me.DescOC, Me.Envase, Me.DescripcionEnvase, Me.Etiqueta, Me.Certificado1, Me.Certificado2, Me.Estado1, Me.Estado2, Me.FechaVencimiento, Me.EstadoEnvI, Me.ObservaI, Me.EstadoEnvIII, Me.ObservaIII, Me.EstadoEnvV, Me.EstadoEnvVII, Me.EstadoEnvIX, Me.CantidadEnv})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(232, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGV_InformeRecepcion.DefaultCellStyle = DataGridViewCellStyle2
        Me.DGV_InformeRecepcion.DoubleBuffered = True
        Me.DGV_InformeRecepcion.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.DGV_InformeRecepcion.Location = New System.Drawing.Point(13, 120)
        Me.DGV_InformeRecepcion.Name = "DGV_InformeRecepcion"
        Me.DGV_InformeRecepcion.OrdenamientoColumnasHabilitado = True
        Me.DGV_InformeRecepcion.RowHeadersWidth = 15
        Me.DGV_InformeRecepcion.RowTemplate.Height = 20
        Me.DGV_InformeRecepcion.ShowCellToolTips = False
        Me.DGV_InformeRecepcion.SinClickDerecho = False
        Me.DGV_InformeRecepcion.Size = New System.Drawing.Size(763, 265)
        Me.DGV_InformeRecepcion.TabIndex = 7
        '
        'Orden
        '
        Me.Orden.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Orden.DataPropertyName = "Orden"
        Me.Orden.HeaderText = "Orden"
        Me.Orden.Name = "Orden"
        Me.Orden.Width = 61
        '
        'Producto
        '
        Me.Producto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Producto.DataPropertyName = "Producto"
        Me.Producto.HeaderText = "Producto"
        Me.Producto.Name = "Producto"
        Me.Producto.Width = 75
        '
        'Descripcion
        '
        Me.Descripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Descripcion.DataPropertyName = "Descripcion"
        Me.Descripcion.HeaderText = "Descripcion"
        Me.Descripcion.Name = "Descripcion"
        Me.Descripcion.Width = 88
        '
        'CantIngre
        '
        Me.CantIngre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.CantIngre.DataPropertyName = "CantIngre"
        Me.CantIngre.HeaderText = "Cant. Ingre."
        Me.CantIngre.Name = "CantIngre"
        Me.CantIngre.Width = 87
        '
        'SaldoOC
        '
        Me.SaldoOC.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.SaldoOC.DataPropertyName = "SaldoOC"
        Me.SaldoOC.HeaderText = "Saldo O/C"
        Me.SaldoOC.Name = "SaldoOC"
        Me.SaldoOC.Width = 82
        '
        'DescOC
        '
        Me.DescOC.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DescOC.DataPropertyName = "DescOC"
        Me.DescOC.HeaderText = "Desc. O/C"
        Me.DescOC.Name = "DescOC"
        Me.DescOC.Width = 83
        '
        'Envase
        '
        Me.Envase.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Envase.DataPropertyName = "Envase"
        Me.Envase.HeaderText = "Envase"
        Me.Envase.Name = "Envase"
        Me.Envase.Width = 68
        '
        'DescripcionEnvase
        '
        Me.DescripcionEnvase.DataPropertyName = "DescripcionEnvase"
        Me.DescripcionEnvase.HeaderText = "Desc. Envase"
        Me.DescripcionEnvase.Name = "DescripcionEnvase"
        '
        'Etiqueta
        '
        Me.Etiqueta.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Etiqueta.DataPropertyName = "Etiqueta"
        Me.Etiqueta.HeaderText = "Etiqueta"
        Me.Etiqueta.Name = "Etiqueta"
        Me.Etiqueta.Width = 71
        '
        'Certificado1
        '
        Me.Certificado1.HeaderText = "Certificado1"
        Me.Certificado1.Name = "Certificado1"
        Me.Certificado1.Visible = False
        '
        'Certificado2
        '
        Me.Certificado2.HeaderText = "Certificado2"
        Me.Certificado2.Name = "Certificado2"
        Me.Certificado2.Visible = False
        '
        'Estado1
        '
        Me.Estado1.HeaderText = "Estado1"
        Me.Estado1.Name = "Estado1"
        Me.Estado1.Visible = False
        '
        'Estado2
        '
        Me.Estado2.HeaderText = "Estado2"
        Me.Estado2.Name = "Estado2"
        Me.Estado2.Visible = False
        '
        'FechaVencimiento
        '
        Me.FechaVencimiento.HeaderText = "FechaVencimiento"
        Me.FechaVencimiento.Name = "FechaVencimiento"
        Me.FechaVencimiento.Visible = False
        '
        'EstadoEnvI
        '
        Me.EstadoEnvI.HeaderText = "EstadoEnvI"
        Me.EstadoEnvI.Name = "EstadoEnvI"
        Me.EstadoEnvI.Visible = False
        '
        'ObservaI
        '
        Me.ObservaI.HeaderText = "ObservaI"
        Me.ObservaI.Name = "ObservaI"
        Me.ObservaI.Visible = False
        '
        'EstadoEnvIII
        '
        Me.EstadoEnvIII.HeaderText = "EstadoEnvIII"
        Me.EstadoEnvIII.Name = "EstadoEnvIII"
        Me.EstadoEnvIII.Visible = False
        '
        'ObservaIII
        '
        Me.ObservaIII.HeaderText = "ObservaIII"
        Me.ObservaIII.Name = "ObservaIII"
        Me.ObservaIII.Visible = False
        '
        'EstadoEnvV
        '
        Me.EstadoEnvV.HeaderText = "EstadoEnvV"
        Me.EstadoEnvV.Name = "EstadoEnvV"
        Me.EstadoEnvV.Visible = False
        '
        'EstadoEnvVII
        '
        Me.EstadoEnvVII.HeaderText = "EstadoEnvVII"
        Me.EstadoEnvVII.Name = "EstadoEnvVII"
        Me.EstadoEnvVII.Visible = False
        '
        'EstadoEnvIX
        '
        Me.EstadoEnvIX.HeaderText = "EstadoEnvIX"
        Me.EstadoEnvIX.Name = "EstadoEnvIX"
        Me.EstadoEnvIX.Visible = False
        '
        'CantidadEnv
        '
        Me.CantidadEnv.HeaderText = "CantidadEnv"
        Me.CantidadEnv.Name = "CantidadEnv"
        Me.CantidadEnv.Visible = False
        '
        'txtOrden
        '
        Me.txtOrden.Enabled = False
        Me.txtOrden.Location = New System.Drawing.Point(13, 412)
        Me.txtOrden.MaxLength = 6
        Me.txtOrden.Name = "txtOrden"
        Me.txtOrden.Size = New System.Drawing.Size(46, 20)
        Me.txtOrden.TabIndex = 8
        Me.txtOrden.Text = "999999"
        Me.txtOrden.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'mastxtMateriaPrima
        '
        Me.mastxtMateriaPrima.Enabled = False
        Me.mastxtMateriaPrima.Location = New System.Drawing.Point(66, 412)
        Me.mastxtMateriaPrima.Mask = ">LL-000-000"
        Me.mastxtMateriaPrima.Name = "mastxtMateriaPrima"
        Me.mastxtMateriaPrima.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.mastxtMateriaPrima.Size = New System.Drawing.Size(65, 20)
        Me.mastxtMateriaPrima.TabIndex = 9
        Me.mastxtMateriaPrima.Text = "AA999999"
        Me.mastxtMateriaPrima.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtDescripcionMP
        '
        Me.txtDescripcionMP.Enabled = False
        Me.txtDescripcionMP.Location = New System.Drawing.Point(138, 412)
        Me.txtDescripcionMP.Name = "txtDescripcionMP"
        Me.txtDescripcionMP.Size = New System.Drawing.Size(309, 20)
        Me.txtDescripcionMP.TabIndex = 10
        '
        'txtCantIngre
        '
        Me.txtCantIngre.Location = New System.Drawing.Point(454, 412)
        Me.txtCantIngre.MaxLength = 8
        Me.txtCantIngre.Name = "txtCantIngre"
        Me.txtCantIngre.Size = New System.Drawing.Size(58, 20)
        Me.txtCantIngre.TabIndex = 11
        Me.txtCantIngre.Text = "99999.99"
        Me.txtCantIngre.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSaldoOC
        '
        Me.txtSaldoOC.Enabled = False
        Me.txtSaldoOC.Location = New System.Drawing.Point(519, 412)
        Me.txtSaldoOC.Name = "txtSaldoOC"
        Me.txtSaldoOC.Size = New System.Drawing.Size(58, 20)
        Me.txtSaldoOC.TabIndex = 12
        Me.txtSaldoOC.Text = "99999.99"
        Me.txtSaldoOC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtDescOC
        '
        Me.txtDescOC.Location = New System.Drawing.Point(584, 412)
        Me.txtDescOC.MaxLength = 8
        Me.txtDescOC.Name = "txtDescOC"
        Me.txtDescOC.Size = New System.Drawing.Size(58, 20)
        Me.txtDescOC.TabIndex = 13
        Me.txtDescOC.Text = "99999.99"
        Me.txtDescOC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtEnvase
        '
        Me.txtEnvase.Location = New System.Drawing.Point(649, 412)
        Me.txtEnvase.MaxLength = 8
        Me.txtEnvase.Name = "txtEnvase"
        Me.txtEnvase.Size = New System.Drawing.Size(58, 20)
        Me.txtEnvase.TabIndex = 14
        Me.txtEnvase.Text = "9999"
        Me.txtEnvase.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtEtiqueta
        '
        Me.txtEtiqueta.Location = New System.Drawing.Point(714, 412)
        Me.txtEtiqueta.Name = "txtEtiqueta"
        Me.txtEtiqueta.Size = New System.Drawing.Size(58, 20)
        Me.txtEtiqueta.TabIndex = 15
        Me.txtEtiqueta.Text = "9999"
        Me.txtEtiqueta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtEtiqueta.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(17, 64)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(83, 13)
        Me.Label3.TabIndex = 16
        Me.Label3.Text = "NRO INFORME"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(15, 93)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(75, 13)
        Me.Label4.TabIndex = 17
        Me.Label4.Text = "PROVEEDOR"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(180, 64)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(42, 13)
        Me.Label5.TabIndex = 18
        Me.Label5.Text = "FECHA"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(325, 64)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(95, 13)
        Me.Label6.TabIndex = 19
        Me.Label6.Text = "ORDEN COMPRA"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(505, 64)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(49, 13)
        Me.Label7.TabIndex = 20
        Me.Label7.Text = "REMITO"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(13, 395)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(46, 13)
        Me.Label8.TabIndex = 21
        Me.Label8.Text = "ORDEN"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(64, 395)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(67, 13)
        Me.Label9.TabIndex = 22
        Me.Label9.Text = "MAT PRIMA"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(137, 395)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(80, 13)
        Me.Label10.TabIndex = 23
        Me.Label10.Text = "DESCRIPCION"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(450, 395)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(61, 13)
        Me.Label11.TabIndex = 24
        Me.Label11.Text = "CANT. ING"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(513, 395)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(66, 13)
        Me.Label12.TabIndex = 25
        Me.Label12.Text = "SALDO O/C"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(582, 395)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(62, 13)
        Me.Label13.TabIndex = 26
        Me.Label13.Text = "DESC. O/C"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(653, 395)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(50, 13)
        Me.Label14.TabIndex = 27
        Me.Label14.Text = "ENVASE"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(715, 395)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(61, 13)
        Me.Label15.TabIndex = 28
        Me.Label15.Text = "ETIQUETA"
        Me.Label15.Visible = False
        '
        'PnlEstadoEnvases
        '
        Me.PnlEstadoEnvases.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PnlEstadoEnvases.Controls.Add(Me.Panel4)
        Me.PnlEstadoEnvases.Controls.Add(Me.txtCantRechazada)
        Me.PnlEstadoEnvases.Controls.Add(Me.Label19)
        Me.PnlEstadoEnvases.Controls.Add(Me.btnAceptar_pnlEstadoEnvases)
        Me.PnlEstadoEnvases.Controls.Add(Me.txtEstadoEnvases1)
        Me.PnlEstadoEnvases.Controls.Add(Me.txtCertifAnalisis)
        Me.PnlEstadoEnvases.Controls.Add(Me.pnlEstadoEnvases4)
        Me.PnlEstadoEnvases.Controls.Add(Me.pnlEstadoEnvases3)
        Me.PnlEstadoEnvases.Controls.Add(Me.pnlEstadoEnvases2)
        Me.PnlEstadoEnvases.Controls.Add(Me.pnlEstadoEnvases1)
        Me.PnlEstadoEnvases.Controls.Add(Me.pnlCertifAnali)
        Me.PnlEstadoEnvases.Controls.Add(Me.lblEstadoEnvases4)
        Me.PnlEstadoEnvases.Controls.Add(Me.lblEstadoEnvases3)
        Me.PnlEstadoEnvases.Controls.Add(Me.lblEstadoEnvases2)
        Me.PnlEstadoEnvases.Controls.Add(Me.lblEstadoEnvases1)
        Me.PnlEstadoEnvases.Controls.Add(Me.lblCertifAnalisis)
        Me.PnlEstadoEnvases.Controls.Add(Me.Label18)
        Me.PnlEstadoEnvases.Controls.Add(Me.Label17)
        Me.PnlEstadoEnvases.Location = New System.Drawing.Point(94, 95)
        Me.PnlEstadoEnvases.Name = "PnlEstadoEnvases"
        Me.PnlEstadoEnvases.Size = New System.Drawing.Size(601, 306)
        Me.PnlEstadoEnvases.TabIndex = 29
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.Panel4.Controls.Add(Me.Label20)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(599, 48)
        Me.Panel4.TabIndex = 17
        '
        'Label20
        '
        Me.Label20.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.SystemColors.Control
        Me.Label20.Location = New System.Drawing.Point(216, 15)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(167, 18)
        Me.Label20.TabIndex = 3
        Me.Label20.Text = "ESTADO DE ENVASES"
        '
        'txtCantRechazada
        '
        Me.txtCantRechazada.Location = New System.Drawing.Point(453, 171)
        Me.txtCantRechazada.Name = "txtCantRechazada"
        Me.txtCantRechazada.Size = New System.Drawing.Size(100, 20)
        Me.txtCantRechazada.TabIndex = 16
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(316, 174)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(131, 13)
        Me.Label19.TabIndex = 15
        Me.Label19.Text = "CANTIDAD RECHAZADA"
        '
        'btnAceptar_pnlEstadoEnvases
        '
        Me.btnAceptar_pnlEstadoEnvases.Location = New System.Drawing.Point(318, 205)
        Me.btnAceptar_pnlEstadoEnvases.Name = "btnAceptar_pnlEstadoEnvases"
        Me.btnAceptar_pnlEstadoEnvases.Size = New System.Drawing.Size(270, 46)
        Me.btnAceptar_pnlEstadoEnvases.TabIndex = 14
        Me.btnAceptar_pnlEstadoEnvases.Text = "CONFIRMAR DATOS"
        Me.btnAceptar_pnlEstadoEnvases.UseVisualStyleBackColor = True
        '
        'txtEstadoEnvases1
        '
        Me.txtEstadoEnvases1.Location = New System.Drawing.Point(297, 123)
        Me.txtEstadoEnvases1.MaxLength = 100
        Me.txtEstadoEnvases1.Multiline = True
        Me.txtEstadoEnvases1.Name = "txtEstadoEnvases1"
        Me.txtEstadoEnvases1.Size = New System.Drawing.Size(290, 32)
        Me.txtEstadoEnvases1.TabIndex = 13
        '
        'txtCertifAnalisis
        '
        Me.txtCertifAnalisis.Location = New System.Drawing.Point(10, 14)
        Me.txtCertifAnalisis.MaxLength = 100
        Me.txtCertifAnalisis.Multiline = True
        Me.txtCertifAnalisis.Name = "txtCertifAnalisis"
        Me.txtCertifAnalisis.Size = New System.Drawing.Size(260, 32)
        Me.txtCertifAnalisis.TabIndex = 12
        '
        'pnlEstadoEnvases4
        '
        Me.pnlEstadoEnvases4.Controls.Add(Me.rabtnNOCum_EstadoEnvases4)
        Me.pnlEstadoEnvases4.Controls.Add(Me.rabtnCum_EstadoEnvases4)
        Me.pnlEstadoEnvases4.Location = New System.Drawing.Point(215, 255)
        Me.pnlEstadoEnvases4.Name = "pnlEstadoEnvases4"
        Me.pnlEstadoEnvases4.Size = New System.Drawing.Size(76, 32)
        Me.pnlEstadoEnvases4.TabIndex = 11
        '
        'rabtnNOCum_EstadoEnvases4
        '
        Me.rabtnNOCum_EstadoEnvases4.AutoSize = True
        Me.rabtnNOCum_EstadoEnvases4.Location = New System.Drawing.Point(47, 10)
        Me.rabtnNOCum_EstadoEnvases4.Name = "rabtnNOCum_EstadoEnvases4"
        Me.rabtnNOCum_EstadoEnvases4.Size = New System.Drawing.Size(14, 13)
        Me.rabtnNOCum_EstadoEnvases4.TabIndex = 1
        Me.rabtnNOCum_EstadoEnvases4.UseVisualStyleBackColor = True
        '
        'rabtnCum_EstadoEnvases4
        '
        Me.rabtnCum_EstadoEnvases4.AutoSize = True
        Me.rabtnCum_EstadoEnvases4.Checked = True
        Me.rabtnCum_EstadoEnvases4.Location = New System.Drawing.Point(15, 10)
        Me.rabtnCum_EstadoEnvases4.Name = "rabtnCum_EstadoEnvases4"
        Me.rabtnCum_EstadoEnvases4.Size = New System.Drawing.Size(14, 13)
        Me.rabtnCum_EstadoEnvases4.TabIndex = 0
        Me.rabtnCum_EstadoEnvases4.TabStop = True
        Me.rabtnCum_EstadoEnvases4.UseVisualStyleBackColor = True
        '
        'pnlEstadoEnvases3
        '
        Me.pnlEstadoEnvases3.Controls.Add(Me.rabtnNOCum_EstadoEnvases3)
        Me.pnlEstadoEnvases3.Controls.Add(Me.rabtnCum_EstadoEnvases3)
        Me.pnlEstadoEnvases3.Location = New System.Drawing.Point(215, 211)
        Me.pnlEstadoEnvases3.Name = "pnlEstadoEnvases3"
        Me.pnlEstadoEnvases3.Size = New System.Drawing.Size(76, 32)
        Me.pnlEstadoEnvases3.TabIndex = 10
        '
        'rabtnNOCum_EstadoEnvases3
        '
        Me.rabtnNOCum_EstadoEnvases3.AutoSize = True
        Me.rabtnNOCum_EstadoEnvases3.Location = New System.Drawing.Point(47, 10)
        Me.rabtnNOCum_EstadoEnvases3.Name = "rabtnNOCum_EstadoEnvases3"
        Me.rabtnNOCum_EstadoEnvases3.Size = New System.Drawing.Size(14, 13)
        Me.rabtnNOCum_EstadoEnvases3.TabIndex = 1
        Me.rabtnNOCum_EstadoEnvases3.UseVisualStyleBackColor = True
        '
        'rabtnCum_EstadoEnvases3
        '
        Me.rabtnCum_EstadoEnvases3.AutoSize = True
        Me.rabtnCum_EstadoEnvases3.Checked = True
        Me.rabtnCum_EstadoEnvases3.Location = New System.Drawing.Point(15, 10)
        Me.rabtnCum_EstadoEnvases3.Name = "rabtnCum_EstadoEnvases3"
        Me.rabtnCum_EstadoEnvases3.Size = New System.Drawing.Size(14, 13)
        Me.rabtnCum_EstadoEnvases3.TabIndex = 0
        Me.rabtnCum_EstadoEnvases3.TabStop = True
        Me.rabtnCum_EstadoEnvases3.UseVisualStyleBackColor = True
        '
        'pnlEstadoEnvases2
        '
        Me.pnlEstadoEnvases2.Controls.Add(Me.rabtnNOCum_EstadoEnvases2)
        Me.pnlEstadoEnvases2.Controls.Add(Me.rabtnCum_EstadoEnvases2)
        Me.pnlEstadoEnvases2.Location = New System.Drawing.Point(215, 168)
        Me.pnlEstadoEnvases2.Name = "pnlEstadoEnvases2"
        Me.pnlEstadoEnvases2.Size = New System.Drawing.Size(76, 32)
        Me.pnlEstadoEnvases2.TabIndex = 9
        '
        'rabtnNOCum_EstadoEnvases2
        '
        Me.rabtnNOCum_EstadoEnvases2.AutoSize = True
        Me.rabtnNOCum_EstadoEnvases2.Location = New System.Drawing.Point(47, 10)
        Me.rabtnNOCum_EstadoEnvases2.Name = "rabtnNOCum_EstadoEnvases2"
        Me.rabtnNOCum_EstadoEnvases2.Size = New System.Drawing.Size(14, 13)
        Me.rabtnNOCum_EstadoEnvases2.TabIndex = 1
        Me.rabtnNOCum_EstadoEnvases2.UseVisualStyleBackColor = True
        '
        'rabtnCum_EstadoEnvases2
        '
        Me.rabtnCum_EstadoEnvases2.AutoSize = True
        Me.rabtnCum_EstadoEnvases2.Checked = True
        Me.rabtnCum_EstadoEnvases2.Location = New System.Drawing.Point(15, 10)
        Me.rabtnCum_EstadoEnvases2.Name = "rabtnCum_EstadoEnvases2"
        Me.rabtnCum_EstadoEnvases2.Size = New System.Drawing.Size(14, 13)
        Me.rabtnCum_EstadoEnvases2.TabIndex = 0
        Me.rabtnCum_EstadoEnvases2.TabStop = True
        Me.rabtnCum_EstadoEnvases2.UseVisualStyleBackColor = True
        '
        'pnlEstadoEnvases1
        '
        Me.pnlEstadoEnvases1.Controls.Add(Me.rabtnNOCum_EstadoEnvases1)
        Me.pnlEstadoEnvases1.Controls.Add(Me.rabtnCum_EstadoEnvases1)
        Me.pnlEstadoEnvases1.Location = New System.Drawing.Point(215, 124)
        Me.pnlEstadoEnvases1.Name = "pnlEstadoEnvases1"
        Me.pnlEstadoEnvases1.Size = New System.Drawing.Size(76, 32)
        Me.pnlEstadoEnvases1.TabIndex = 9
        '
        'rabtnNOCum_EstadoEnvases1
        '
        Me.rabtnNOCum_EstadoEnvases1.AutoSize = True
        Me.rabtnNOCum_EstadoEnvases1.Location = New System.Drawing.Point(47, 10)
        Me.rabtnNOCum_EstadoEnvases1.Name = "rabtnNOCum_EstadoEnvases1"
        Me.rabtnNOCum_EstadoEnvases1.Size = New System.Drawing.Size(14, 13)
        Me.rabtnNOCum_EstadoEnvases1.TabIndex = 1
        Me.rabtnNOCum_EstadoEnvases1.UseVisualStyleBackColor = True
        '
        'rabtnCum_EstadoEnvases1
        '
        Me.rabtnCum_EstadoEnvases1.AutoSize = True
        Me.rabtnCum_EstadoEnvases1.Checked = True
        Me.rabtnCum_EstadoEnvases1.Location = New System.Drawing.Point(15, 10)
        Me.rabtnCum_EstadoEnvases1.Name = "rabtnCum_EstadoEnvases1"
        Me.rabtnCum_EstadoEnvases1.Size = New System.Drawing.Size(14, 13)
        Me.rabtnCum_EstadoEnvases1.TabIndex = 0
        Me.rabtnCum_EstadoEnvases1.TabStop = True
        Me.rabtnCum_EstadoEnvases1.UseVisualStyleBackColor = True
        '
        'pnlCertifAnali
        '
        Me.pnlCertifAnali.Controls.Add(Me.rabtnNOCum_CertifAnalisis)
        Me.pnlCertifAnali.Controls.Add(Me.rabtnCum_CertifAnalisis)
        Me.pnlCertifAnali.Location = New System.Drawing.Point(215, 79)
        Me.pnlCertifAnali.Name = "pnlCertifAnali"
        Me.pnlCertifAnali.Size = New System.Drawing.Size(76, 32)
        Me.pnlCertifAnali.TabIndex = 8
        '
        'rabtnNOCum_CertifAnalisis
        '
        Me.rabtnNOCum_CertifAnalisis.AutoSize = True
        Me.rabtnNOCum_CertifAnalisis.Location = New System.Drawing.Point(47, 10)
        Me.rabtnNOCum_CertifAnalisis.Name = "rabtnNOCum_CertifAnalisis"
        Me.rabtnNOCum_CertifAnalisis.Size = New System.Drawing.Size(14, 13)
        Me.rabtnNOCum_CertifAnalisis.TabIndex = 1
        Me.rabtnNOCum_CertifAnalisis.UseVisualStyleBackColor = True
        '
        'rabtnCum_CertifAnalisis
        '
        Me.rabtnCum_CertifAnalisis.AutoSize = True
        Me.rabtnCum_CertifAnalisis.Checked = True
        Me.rabtnCum_CertifAnalisis.Location = New System.Drawing.Point(15, 10)
        Me.rabtnCum_CertifAnalisis.Name = "rabtnCum_CertifAnalisis"
        Me.rabtnCum_CertifAnalisis.Size = New System.Drawing.Size(14, 13)
        Me.rabtnCum_CertifAnalisis.TabIndex = 0
        Me.rabtnCum_CertifAnalisis.TabStop = True
        Me.rabtnCum_CertifAnalisis.UseVisualStyleBackColor = True
        '
        'lblEstadoEnvases4
        '
        Me.lblEstadoEnvases4.AutoSize = True
        Me.lblEstadoEnvases4.Location = New System.Drawing.Point(17, 261)
        Me.lblEstadoEnvases4.MaximumSize = New System.Drawing.Size(220, 40)
        Me.lblEstadoEnvases4.Name = "lblEstadoEnvases4"
        Me.lblEstadoEnvases4.Size = New System.Drawing.Size(87, 13)
        Me.lblEstadoEnvases4.TabIndex = 7
        Me.lblEstadoEnvases4.Text = "EstadoEnvases4"
        '
        'lblEstadoEnvases3
        '
        Me.lblEstadoEnvases3.AutoSize = True
        Me.lblEstadoEnvases3.Location = New System.Drawing.Point(17, 217)
        Me.lblEstadoEnvases3.MaximumSize = New System.Drawing.Size(220, 40)
        Me.lblEstadoEnvases3.Name = "lblEstadoEnvases3"
        Me.lblEstadoEnvases3.Size = New System.Drawing.Size(87, 13)
        Me.lblEstadoEnvases3.TabIndex = 6
        Me.lblEstadoEnvases3.Text = "EstadoEnvases3"
        '
        'lblEstadoEnvases2
        '
        Me.lblEstadoEnvases2.AutoSize = True
        Me.lblEstadoEnvases2.Location = New System.Drawing.Point(17, 174)
        Me.lblEstadoEnvases2.MaximumSize = New System.Drawing.Size(220, 40)
        Me.lblEstadoEnvases2.Name = "lblEstadoEnvases2"
        Me.lblEstadoEnvases2.Size = New System.Drawing.Size(87, 13)
        Me.lblEstadoEnvases2.TabIndex = 5
        Me.lblEstadoEnvases2.Text = "EstadoEnvases2"
        '
        'lblEstadoEnvases1
        '
        Me.lblEstadoEnvases1.AutoSize = True
        Me.lblEstadoEnvases1.Location = New System.Drawing.Point(17, 130)
        Me.lblEstadoEnvases1.MaximumSize = New System.Drawing.Size(220, 40)
        Me.lblEstadoEnvases1.Name = "lblEstadoEnvases1"
        Me.lblEstadoEnvases1.Size = New System.Drawing.Size(87, 13)
        Me.lblEstadoEnvases1.TabIndex = 4
        Me.lblEstadoEnvases1.Text = "EstadoEnvases1"
        '
        'lblCertifAnalisis
        '
        Me.lblCertifAnalisis.AutoSize = True
        Me.lblCertifAnalisis.Location = New System.Drawing.Point(38, 85)
        Me.lblCertifAnalisis.MaximumSize = New System.Drawing.Size(220, 40)
        Me.lblCertifAnalisis.Name = "lblCertifAnalisis"
        Me.lblCertifAnalisis.Size = New System.Drawing.Size(66, 13)
        Me.lblCertifAnalisis.TabIndex = 3
        Me.lblCertifAnalisis.Text = "CertifAnalisis"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(262, 61)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(70, 13)
        Me.Label18.TabIndex = 2
        Me.Label18.Text = "NO CUMPLE"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(196, 61)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(51, 13)
        Me.Label17.TabIndex = 1
        Me.Label17.Text = "CUMPLE"
        '
        'pnlAviso
        '
        Me.pnlAviso.Controls.Add(Me.btnAceptar_pnlAviso)
        Me.pnlAviso.Controls.Add(Me.lblAviso3)
        Me.pnlAviso.Controls.Add(Me.lblAviso2)
        Me.pnlAviso.Controls.Add(Me.Label25)
        Me.pnlAviso.Controls.Add(Me.lblAviso1)
        Me.pnlAviso.Location = New System.Drawing.Point(202, 120)
        Me.pnlAviso.Name = "pnlAviso"
        Me.pnlAviso.Size = New System.Drawing.Size(451, 196)
        Me.pnlAviso.TabIndex = 31
        '
        'btnAceptar_pnlAviso
        '
        Me.btnAceptar_pnlAviso.Location = New System.Drawing.Point(162, 127)
        Me.btnAceptar_pnlAviso.Name = "btnAceptar_pnlAviso"
        Me.btnAceptar_pnlAviso.Size = New System.Drawing.Size(127, 50)
        Me.btnAceptar_pnlAviso.TabIndex = 6
        Me.btnAceptar_pnlAviso.Text = "ACEPTAR"
        Me.btnAceptar_pnlAviso.UseVisualStyleBackColor = True
        '
        'lblAviso3
        '
        Me.lblAviso3.AutoSize = True
        Me.lblAviso3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAviso3.ForeColor = System.Drawing.Color.Red
        Me.lblAviso3.Location = New System.Drawing.Point(16, 103)
        Me.lblAviso3.Name = "lblAviso3"
        Me.lblAviso3.Size = New System.Drawing.Size(410, 17)
        Me.lblAviso3.TabIndex = 5
        Me.lblAviso3.Text = "DEBERA CUMPLIR CON LA ENTREGA DE LOS MISMOS"
        '
        'lblAviso2
        '
        Me.lblAviso2.AutoSize = True
        Me.lblAviso2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAviso2.ForeColor = System.Drawing.Color.Red
        Me.lblAviso2.Location = New System.Drawing.Point(26, 70)
        Me.lblAviso2.Name = "lblAviso2"
        Me.lblAviso2.Size = New System.Drawing.Size(379, 17)
        Me.lblAviso2.TabIndex = 4
        Me.lblAviso2.Text = "LA CANTIDAD DE 10 KGS. Y QUE EL PROVEEDOR"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.ForeColor = System.Drawing.Color.Red
        Me.Label25.Location = New System.Drawing.Point(174, 9)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(98, 20)
        Me.Label25.TabIndex = 3
        Me.Label25.Text = "ATENCION"
        '
        'lblAviso1
        '
        Me.lblAviso1.AutoSize = True
        Me.lblAviso1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAviso1.ForeColor = System.Drawing.Color.Red
        Me.lblAviso1.Location = New System.Drawing.Point(16, 37)
        Me.lblAviso1.Name = "lblAviso1"
        Me.lblAviso1.Size = New System.Drawing.Size(418, 17)
        Me.lblAviso1.TabIndex = 0
        Me.lblAviso1.Text = "A CONFIRMADO QUE DEJA PENDIENTE DE RECEPCION"
        '
        'btnGrabar
        '
        Me.btnGrabar.Location = New System.Drawing.Point(152, 445)
        Me.btnGrabar.Name = "btnGrabar"
        Me.btnGrabar.Size = New System.Drawing.Size(140, 37)
        Me.btnGrabar.TabIndex = 33
        Me.btnGrabar.Text = "GRABAR"
        Me.btnGrabar.UseVisualStyleBackColor = True
        '
        'btnLimpiarForm
        '
        Me.btnLimpiarForm.Location = New System.Drawing.Point(324, 445)
        Me.btnLimpiarForm.Name = "btnLimpiarForm"
        Me.btnLimpiarForm.Size = New System.Drawing.Size(140, 37)
        Me.btnLimpiarForm.TabIndex = 34
        Me.btnLimpiarForm.Text = "LIMPIAR"
        Me.btnLimpiarForm.UseVisualStyleBackColor = True
        '
        'btnBuscarProv
        '
        Me.btnBuscarProv.BackgroundImage = Global.Laboratorio.My.Resources.Resources.Consulta_Dat_N1
        Me.btnBuscarProv.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnBuscarProv.FlatAppearance.BorderSize = 0
        Me.btnBuscarProv.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBuscarProv.Location = New System.Drawing.Point(106, 86)
        Me.btnBuscarProv.Name = "btnBuscarProv"
        Me.btnBuscarProv.Size = New System.Drawing.Size(33, 29)
        Me.btnBuscarProv.TabIndex = 35
        Me.btnBuscarProv.UseVisualStyleBackColor = True
        '
        'btnVolver
        '
        Me.btnVolver.Location = New System.Drawing.Point(496, 444)
        Me.btnVolver.Name = "btnVolver"
        Me.btnVolver.Size = New System.Drawing.Size(140, 37)
        Me.btnVolver.TabIndex = 36
        Me.btnVolver.Text = "CERRAR"
        Me.btnVolver.UseVisualStyleBackColor = True
        '
        'InformeRecepcionDrogaLAB
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(788, 496)
        Me.Controls.Add(Me.PnlEstadoEnvases)
        Me.Controls.Add(Me.btnVolver)
        Me.Controls.Add(Me.btnBuscarProv)
        Me.Controls.Add(Me.btnLimpiarForm)
        Me.Controls.Add(Me.btnGrabar)
        Me.Controls.Add(Me.pnlAviso)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtEtiqueta)
        Me.Controls.Add(Me.txtEnvase)
        Me.Controls.Add(Me.txtDescOC)
        Me.Controls.Add(Me.txtSaldoOC)
        Me.Controls.Add(Me.txtCantIngre)
        Me.Controls.Add(Me.txtDescripcionMP)
        Me.Controls.Add(Me.mastxtMateriaPrima)
        Me.Controls.Add(Me.txtOrden)
        Me.Controls.Add(Me.DGV_InformeRecepcion)
        Me.Controls.Add(Me.txtRemito)
        Me.Controls.Add(Me.txtDescripcionProv)
        Me.Controls.Add(Me.txtProveedor)
        Me.Controls.Add(Me.txtOrdenCompra)
        Me.Controls.Add(Me.mastxtFecha)
        Me.Controls.Add(Me.txtNroInforme)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Location = New System.Drawing.Point(20, 20)
        Me.MaximizeBox = False
        Me.Name = "InformeRecepcionDrogaLAB"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.DGV_InformeRecepcion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PnlEstadoEnvases.ResumeLayout(False)
        Me.PnlEstadoEnvases.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.pnlEstadoEnvases4.ResumeLayout(False)
        Me.pnlEstadoEnvases4.PerformLayout()
        Me.pnlEstadoEnvases3.ResumeLayout(False)
        Me.pnlEstadoEnvases3.PerformLayout()
        Me.pnlEstadoEnvases2.ResumeLayout(False)
        Me.pnlEstadoEnvases2.PerformLayout()
        Me.pnlEstadoEnvases1.ResumeLayout(False)
        Me.pnlEstadoEnvases1.PerformLayout()
        Me.pnlCertifAnali.ResumeLayout(False)
        Me.pnlCertifAnali.PerformLayout()
        Me.pnlAviso.ResumeLayout(False)
        Me.pnlAviso.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtNroInforme As System.Windows.Forms.TextBox
    Friend WithEvents mastxtFecha As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtOrdenCompra As System.Windows.Forms.TextBox
    Friend WithEvents txtProveedor As System.Windows.Forms.TextBox
    Friend WithEvents txtDescripcionProv As System.Windows.Forms.TextBox
    Friend WithEvents txtRemito As System.Windows.Forms.TextBox
    Friend WithEvents DGV_InformeRecepcion As ConsultasVarias.DBDataGridView
    Friend WithEvents txtOrden As System.Windows.Forms.TextBox
    Friend WithEvents mastxtMateriaPrima As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtDescripcionMP As System.Windows.Forms.TextBox
    Friend WithEvents txtCantIngre As System.Windows.Forms.TextBox
    Friend WithEvents txtSaldoOC As System.Windows.Forms.TextBox
    Friend WithEvents txtDescOC As System.Windows.Forms.TextBox
    Friend WithEvents txtEnvase As System.Windows.Forms.TextBox
    Friend WithEvents txtEtiqueta As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents PnlEstadoEnvases As System.Windows.Forms.Panel
    Friend WithEvents btnAceptar_pnlEstadoEnvases As System.Windows.Forms.Button
    Friend WithEvents txtEstadoEnvases1 As System.Windows.Forms.TextBox
    Friend WithEvents txtCertifAnalisis As System.Windows.Forms.TextBox
    Friend WithEvents pnlEstadoEnvases4 As System.Windows.Forms.Panel
    Friend WithEvents rabtnNOCum_EstadoEnvases4 As System.Windows.Forms.RadioButton
    Friend WithEvents rabtnCum_EstadoEnvases4 As System.Windows.Forms.RadioButton
    Friend WithEvents pnlEstadoEnvases3 As System.Windows.Forms.Panel
    Friend WithEvents rabtnNOCum_EstadoEnvases3 As System.Windows.Forms.RadioButton
    Friend WithEvents rabtnCum_EstadoEnvases3 As System.Windows.Forms.RadioButton
    Friend WithEvents pnlEstadoEnvases2 As System.Windows.Forms.Panel
    Friend WithEvents rabtnNOCum_EstadoEnvases2 As System.Windows.Forms.RadioButton
    Friend WithEvents rabtnCum_EstadoEnvases2 As System.Windows.Forms.RadioButton
    Friend WithEvents pnlEstadoEnvases1 As System.Windows.Forms.Panel
    Friend WithEvents rabtnNOCum_EstadoEnvases1 As System.Windows.Forms.RadioButton
    Friend WithEvents rabtnCum_EstadoEnvases1 As System.Windows.Forms.RadioButton
    Friend WithEvents pnlCertifAnali As System.Windows.Forms.Panel
    Friend WithEvents rabtnNOCum_CertifAnalisis As System.Windows.Forms.RadioButton
    Friend WithEvents rabtnCum_CertifAnalisis As System.Windows.Forms.RadioButton
    Friend WithEvents lblEstadoEnvases4 As System.Windows.Forms.Label
    Friend WithEvents lblEstadoEnvases3 As System.Windows.Forms.Label
    Friend WithEvents lblEstadoEnvases2 As System.Windows.Forms.Label
    Friend WithEvents lblEstadoEnvases1 As System.Windows.Forms.Label
    Friend WithEvents lblCertifAnalisis As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtCantRechazada As System.Windows.Forms.TextBox
    Friend WithEvents pnlAviso As System.Windows.Forms.Panel
    Friend WithEvents btnAceptar_pnlAviso As System.Windows.Forms.Button
    Friend WithEvents lblAviso3 As System.Windows.Forms.Label
    Friend WithEvents lblAviso2 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents lblAviso1 As System.Windows.Forms.Label
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents btnGrabar As System.Windows.Forms.Button
    Friend WithEvents btnLimpiarForm As System.Windows.Forms.Button
    Friend WithEvents btnBuscarProv As System.Windows.Forms.Button
    Friend WithEvents btnVolver As System.Windows.Forms.Button
    Friend WithEvents Orden As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Producto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Descripcion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CantIngre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SaldoOC As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DescOC As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Envase As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DescripcionEnvase As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Etiqueta As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Certificado1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Certificado2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Estado1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Estado2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FechaVencimiento As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EstadoEnvI As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ObservaI As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EstadoEnvIII As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ObservaIII As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EstadoEnvV As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EstadoEnvVII As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EstadoEnvIX As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CantidadEnv As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
