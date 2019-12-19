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
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
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
        Me.pnlCertifAnaliyEstadoEtiquet = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.mastxtVencimiento_pnlIngreCertif = New System.Windows.Forms.MaskedTextBox()
        Me.btnAceptar_IngreCert = New System.Windows.Forms.Button()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.txtEstadoEnvases5 = New System.Windows.Forms.TextBox()
        Me.txtCertifAnalisis2 = New System.Windows.Forms.TextBox()
        Me.panel5 = New System.Windows.Forms.Panel()
        Me.rabtnNO_EstadoEnvases5 = New System.Windows.Forms.RadioButton()
        Me.rabtnSI_EstadoEnvases5 = New System.Windows.Forms.RadioButton()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.rabtnNO_CertifAnalisis2 = New System.Windows.Forms.RadioButton()
        Me.rabtnSI_CertifAnalisis2 = New System.Windows.Forms.RadioButton()
        Me.EstadoEnvases5 = New System.Windows.Forms.Label()
        Me.CertifAnalisis2 = New System.Windows.Forms.Label()
        Me.pnlAyudaProv = New System.Windows.Forms.Panel()
        Me.btnVolver_pnlAyudaProv = New System.Windows.Forms.Button()
        Me.DGV_AyudaProv = New ConsultasVarias.DBDataGridView()
        Me.AyudaArticulo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AyudaDescripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AyudaSaldo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NroOrden = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.btnGrabar = New System.Windows.Forms.Button()
        Me.btnLimpiarForm = New System.Windows.Forms.Button()
        Me.btnBuscarProv = New System.Windows.Forms.Button()
        Me.btnVolver = New System.Windows.Forms.Button()
        Me.pnlBuscarProveedor = New System.Windows.Forms.Panel()
        Me.txtBuscardorProv = New System.Windows.Forms.TextBox()
        Me.btnVolver_PnlProveedores = New System.Windows.Forms.Button()
        Me.DGV_Proveedores = New ConsultasVarias.DBDataGridView()
        Me.CodigoProv = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DescripcionProv = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.Label23 = New System.Windows.Forms.Label()
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
        Me.pnlCertifAnaliyEstadoEtiquet.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.panel5.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.pnlAyudaProv.SuspendLayout()
        CType(Me.DGV_AyudaProv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel7.SuspendLayout()
        Me.pnlBuscarProveedor.SuspendLayout()
        CType(Me.DGV_Proveedores, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel8.SuspendLayout()
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
        Me.Panel1.Size = New System.Drawing.Size(788, 54)
        Me.Panel1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.Control
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(396, 20)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Informe de Recepcion de Drogas de Laboratorio"
        '
        'Label2
        '
        Me.Label2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.Control
        Me.Label2.Location = New System.Drawing.Point(597, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(179, 24)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "SURFACTAN S.A."
        '
        'txtNroInforme
        '
        Me.txtNroInforme.Location = New System.Drawing.Point(102, 59)
        Me.txtNroInforme.MaxLength = 6
        Me.txtNroInforme.Name = "txtNroInforme"
        Me.txtNroInforme.Size = New System.Drawing.Size(100, 20)
        Me.txtNroInforme.TabIndex = 1
        Me.txtNroInforme.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'mastxtFecha
        '
        Me.mastxtFecha.Location = New System.Drawing.Point(273, 60)
        Me.mastxtFecha.Mask = "00/00/0000"
        Me.mastxtFecha.Name = "mastxtFecha"
        Me.mastxtFecha.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.mastxtFecha.Size = New System.Drawing.Size(100, 20)
        Me.mastxtFecha.TabIndex = 2
        Me.mastxtFecha.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtOrdenCompra
        '
        Me.txtOrdenCompra.Location = New System.Drawing.Point(555, 59)
        Me.txtOrdenCompra.MaxLength = 6
        Me.txtOrdenCompra.Name = "txtOrdenCompra"
        Me.txtOrdenCompra.Size = New System.Drawing.Size(100, 20)
        Me.txtOrdenCompra.TabIndex = 3
        Me.txtOrdenCompra.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtProveedor
        '
        Me.txtProveedor.Location = New System.Drawing.Point(102, 97)
        Me.txtProveedor.MaxLength = 11
        Me.txtProveedor.Name = "txtProveedor"
        Me.txtProveedor.Size = New System.Drawing.Size(100, 20)
        Me.txtProveedor.TabIndex = 4
        Me.txtProveedor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtDescripcionProv
        '
        Me.txtDescripcionProv.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtDescripcionProv.Enabled = False
        Me.txtDescripcionProv.Location = New System.Drawing.Point(208, 97)
        Me.txtDescripcionProv.Name = "txtDescripcionProv"
        Me.txtDescripcionProv.Size = New System.Drawing.Size(256, 20)
        Me.txtDescripcionProv.TabIndex = 5
        '
        'txtRemito
        '
        Me.txtRemito.Location = New System.Drawing.Point(555, 97)
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
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(232, Byte), Integer))
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGV_InformeRecepcion.DefaultCellStyle = DataGridViewCellStyle10
        Me.DGV_InformeRecepcion.DoubleBuffered = True
        Me.DGV_InformeRecepcion.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.DGV_InformeRecepcion.Location = New System.Drawing.Point(13, 134)
        Me.DGV_InformeRecepcion.Name = "DGV_InformeRecepcion"
        Me.DGV_InformeRecepcion.OrdenamientoColumnasHabilitado = True
        Me.DGV_InformeRecepcion.RowHeadersWidth = 15
        Me.DGV_InformeRecepcion.RowTemplate.Height = 20
        Me.DGV_InformeRecepcion.ShowCellToolTips = False
        Me.DGV_InformeRecepcion.SinClickDerecho = False
        Me.DGV_InformeRecepcion.Size = New System.Drawing.Size(763, 288)
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
        Me.txtOrden.Location = New System.Drawing.Point(16, 440)
        Me.txtOrden.Name = "txtOrden"
        Me.txtOrden.Size = New System.Drawing.Size(60, 20)
        Me.txtOrden.TabIndex = 8
        '
        'mastxtMateriaPrima
        '
        Me.mastxtMateriaPrima.Enabled = False
        Me.mastxtMateriaPrima.Location = New System.Drawing.Point(82, 440)
        Me.mastxtMateriaPrima.Mask = ">LL-000-000"
        Me.mastxtMateriaPrima.Name = "mastxtMateriaPrima"
        Me.mastxtMateriaPrima.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.mastxtMateriaPrima.Size = New System.Drawing.Size(100, 20)
        Me.mastxtMateriaPrima.TabIndex = 9
        '
        'txtDescripcionMP
        '
        Me.txtDescripcionMP.Enabled = False
        Me.txtDescripcionMP.Location = New System.Drawing.Point(188, 440)
        Me.txtDescripcionMP.Name = "txtDescripcionMP"
        Me.txtDescripcionMP.Size = New System.Drawing.Size(177, 20)
        Me.txtDescripcionMP.TabIndex = 10
        '
        'txtCantIngre
        '
        Me.txtCantIngre.Location = New System.Drawing.Point(371, 440)
        Me.txtCantIngre.MaxLength = 8
        Me.txtCantIngre.Name = "txtCantIngre"
        Me.txtCantIngre.Size = New System.Drawing.Size(100, 20)
        Me.txtCantIngre.TabIndex = 11
        '
        'txtSaldoOC
        '
        Me.txtSaldoOC.Enabled = False
        Me.txtSaldoOC.Location = New System.Drawing.Point(477, 440)
        Me.txtSaldoOC.Name = "txtSaldoOC"
        Me.txtSaldoOC.Size = New System.Drawing.Size(72, 20)
        Me.txtSaldoOC.TabIndex = 12
        '
        'txtDescOC
        '
        Me.txtDescOC.Location = New System.Drawing.Point(555, 440)
        Me.txtDescOC.MaxLength = 8
        Me.txtDescOC.Name = "txtDescOC"
        Me.txtDescOC.Size = New System.Drawing.Size(68, 20)
        Me.txtDescOC.TabIndex = 13
        '
        'txtEnvase
        '
        Me.txtEnvase.Location = New System.Drawing.Point(629, 440)
        Me.txtEnvase.MaxLength = 8
        Me.txtEnvase.Name = "txtEnvase"
        Me.txtEnvase.Size = New System.Drawing.Size(69, 20)
        Me.txtEnvase.TabIndex = 14
        '
        'txtEtiqueta
        '
        Me.txtEtiqueta.Location = New System.Drawing.Point(718, 440)
        Me.txtEtiqueta.Name = "txtEtiqueta"
        Me.txtEtiqueta.Size = New System.Drawing.Size(58, 20)
        Me.txtEtiqueta.TabIndex = 15
        Me.txtEtiqueta.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(10, 63)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(80, 13)
        Me.Label3.TabIndex = 16
        Me.Label3.Text = "Nro. de Informe"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(13, 100)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(56, 13)
        Me.Label4.TabIndex = 17
        Me.Label4.Text = "Proveedor"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(230, 63)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(37, 13)
        Me.Label5.TabIndex = 18
        Me.Label5.Text = "Fecha"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(476, 62)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(75, 13)
        Me.Label6.TabIndex = 19
        Me.Label6.Text = "Orden Compra"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(509, 100)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(40, 13)
        Me.Label7.TabIndex = 20
        Me.Label7.Text = "Remito"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(13, 425)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(36, 13)
        Me.Label8.TabIndex = 21
        Me.Label8.Text = "Orden"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(79, 425)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(71, 13)
        Me.Label9.TabIndex = 22
        Me.Label9.Text = "Materia Prima"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(185, 425)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(63, 13)
        Me.Label10.TabIndex = 23
        Me.Label10.Text = "Descripcion"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(368, 425)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(62, 13)
        Me.Label11.TabIndex = 24
        Me.Label11.Text = "Cant, Ingre."
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(474, 425)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(57, 13)
        Me.Label12.TabIndex = 25
        Me.Label12.Text = "Saldo O/C"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(552, 425)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(58, 13)
        Me.Label13.TabIndex = 26
        Me.Label13.Text = "Desc. O/C"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(626, 424)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(43, 13)
        Me.Label14.TabIndex = 27
        Me.Label14.Text = "Envase"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(715, 425)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(46, 13)
        Me.Label15.TabIndex = 28
        Me.Label15.Text = "Etiqueta"
        Me.Label15.Visible = False
        '
        'PnlEstadoEnvases
        '
        Me.PnlEstadoEnvases.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
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
        Me.PnlEstadoEnvases.Location = New System.Drawing.Point(111, 109)
        Me.PnlEstadoEnvases.Name = "PnlEstadoEnvases"
        Me.PnlEstadoEnvases.Size = New System.Drawing.Size(638, 335)
        Me.PnlEstadoEnvases.TabIndex = 29
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.Panel4.Controls.Add(Me.Label20)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(634, 53)
        Me.Panel4.TabIndex = 17
        '
        'Label20
        '
        Me.Label20.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.SystemColors.Control
        Me.Label20.Location = New System.Drawing.Point(9, 14)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(255, 20)
        Me.Label20.TabIndex = 3
        Me.Label20.Text = "Ingreso de Estado de Envases"
        '
        'txtCantRechazada
        '
        Me.txtCantRechazada.Location = New System.Drawing.Point(170, 302)
        Me.txtCantRechazada.Name = "txtCantRechazada"
        Me.txtCantRechazada.Size = New System.Drawing.Size(100, 20)
        Me.txtCantRechazada.TabIndex = 16
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(17, 305)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(107, 13)
        Me.Label19.TabIndex = 15
        Me.Label19.Text = "Cantidad Rechazada"
        '
        'btnAceptar_pnlEstadoEnvases
        '
        Me.btnAceptar_pnlEstadoEnvases.Location = New System.Drawing.Point(451, 219)
        Me.btnAceptar_pnlEstadoEnvases.Name = "btnAceptar_pnlEstadoEnvases"
        Me.btnAceptar_pnlEstadoEnvases.Size = New System.Drawing.Size(75, 23)
        Me.btnAceptar_pnlEstadoEnvases.TabIndex = 14
        Me.btnAceptar_pnlEstadoEnvases.Text = "Aceptar"
        Me.btnAceptar_pnlEstadoEnvases.UseVisualStyleBackColor = True
        '
        'txtEstadoEnvases1
        '
        Me.txtEstadoEnvases1.Location = New System.Drawing.Point(364, 124)
        Me.txtEstadoEnvases1.MaxLength = 100
        Me.txtEstadoEnvases1.Multiline = True
        Me.txtEstadoEnvases1.Name = "txtEstadoEnvases1"
        Me.txtEstadoEnvases1.Size = New System.Drawing.Size(260, 32)
        Me.txtEstadoEnvases1.TabIndex = 13
        '
        'txtCertifAnalisis
        '
        Me.txtCertifAnalisis.Location = New System.Drawing.Point(364, 78)
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
        Me.pnlEstadoEnvases4.Location = New System.Drawing.Point(235, 255)
        Me.pnlEstadoEnvases4.Name = "pnlEstadoEnvases4"
        Me.pnlEstadoEnvases4.Size = New System.Drawing.Size(114, 32)
        Me.pnlEstadoEnvases4.TabIndex = 11
        '
        'rabtnNOCum_EstadoEnvases4
        '
        Me.rabtnNOCum_EstadoEnvases4.AutoSize = True
        Me.rabtnNOCum_EstadoEnvases4.Location = New System.Drawing.Point(97, 10)
        Me.rabtnNOCum_EstadoEnvases4.Name = "rabtnNOCum_EstadoEnvases4"
        Me.rabtnNOCum_EstadoEnvases4.Size = New System.Drawing.Size(14, 13)
        Me.rabtnNOCum_EstadoEnvases4.TabIndex = 1
        Me.rabtnNOCum_EstadoEnvases4.UseVisualStyleBackColor = True
        '
        'rabtnCum_EstadoEnvases4
        '
        Me.rabtnCum_EstadoEnvases4.AutoSize = True
        Me.rabtnCum_EstadoEnvases4.Checked = True
        Me.rabtnCum_EstadoEnvases4.Location = New System.Drawing.Point(22, 10)
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
        Me.pnlEstadoEnvases3.Location = New System.Drawing.Point(235, 211)
        Me.pnlEstadoEnvases3.Name = "pnlEstadoEnvases3"
        Me.pnlEstadoEnvases3.Size = New System.Drawing.Size(114, 32)
        Me.pnlEstadoEnvases3.TabIndex = 10
        '
        'rabtnNOCum_EstadoEnvases3
        '
        Me.rabtnNOCum_EstadoEnvases3.AutoSize = True
        Me.rabtnNOCum_EstadoEnvases3.Location = New System.Drawing.Point(97, 10)
        Me.rabtnNOCum_EstadoEnvases3.Name = "rabtnNOCum_EstadoEnvases3"
        Me.rabtnNOCum_EstadoEnvases3.Size = New System.Drawing.Size(14, 13)
        Me.rabtnNOCum_EstadoEnvases3.TabIndex = 1
        Me.rabtnNOCum_EstadoEnvases3.UseVisualStyleBackColor = True
        '
        'rabtnCum_EstadoEnvases3
        '
        Me.rabtnCum_EstadoEnvases3.AutoSize = True
        Me.rabtnCum_EstadoEnvases3.Checked = True
        Me.rabtnCum_EstadoEnvases3.Location = New System.Drawing.Point(22, 10)
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
        Me.pnlEstadoEnvases2.Location = New System.Drawing.Point(235, 168)
        Me.pnlEstadoEnvases2.Name = "pnlEstadoEnvases2"
        Me.pnlEstadoEnvases2.Size = New System.Drawing.Size(114, 32)
        Me.pnlEstadoEnvases2.TabIndex = 9
        '
        'rabtnNOCum_EstadoEnvases2
        '
        Me.rabtnNOCum_EstadoEnvases2.AutoSize = True
        Me.rabtnNOCum_EstadoEnvases2.Location = New System.Drawing.Point(97, 10)
        Me.rabtnNOCum_EstadoEnvases2.Name = "rabtnNOCum_EstadoEnvases2"
        Me.rabtnNOCum_EstadoEnvases2.Size = New System.Drawing.Size(14, 13)
        Me.rabtnNOCum_EstadoEnvases2.TabIndex = 1
        Me.rabtnNOCum_EstadoEnvases2.UseVisualStyleBackColor = True
        '
        'rabtnCum_EstadoEnvases2
        '
        Me.rabtnCum_EstadoEnvases2.AutoSize = True
        Me.rabtnCum_EstadoEnvases2.Checked = True
        Me.rabtnCum_EstadoEnvases2.Location = New System.Drawing.Point(22, 10)
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
        Me.pnlEstadoEnvases1.Location = New System.Drawing.Point(235, 124)
        Me.pnlEstadoEnvases1.Name = "pnlEstadoEnvases1"
        Me.pnlEstadoEnvases1.Size = New System.Drawing.Size(114, 32)
        Me.pnlEstadoEnvases1.TabIndex = 9
        '
        'rabtnNOCum_EstadoEnvases1
        '
        Me.rabtnNOCum_EstadoEnvases1.AutoSize = True
        Me.rabtnNOCum_EstadoEnvases1.Location = New System.Drawing.Point(97, 10)
        Me.rabtnNOCum_EstadoEnvases1.Name = "rabtnNOCum_EstadoEnvases1"
        Me.rabtnNOCum_EstadoEnvases1.Size = New System.Drawing.Size(14, 13)
        Me.rabtnNOCum_EstadoEnvases1.TabIndex = 1
        Me.rabtnNOCum_EstadoEnvases1.UseVisualStyleBackColor = True
        '
        'rabtnCum_EstadoEnvases1
        '
        Me.rabtnCum_EstadoEnvases1.AutoSize = True
        Me.rabtnCum_EstadoEnvases1.Checked = True
        Me.rabtnCum_EstadoEnvases1.Location = New System.Drawing.Point(22, 10)
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
        Me.pnlCertifAnali.Location = New System.Drawing.Point(234, 79)
        Me.pnlCertifAnali.Name = "pnlCertifAnali"
        Me.pnlCertifAnali.Size = New System.Drawing.Size(114, 32)
        Me.pnlCertifAnali.TabIndex = 8
        '
        'rabtnNOCum_CertifAnalisis
        '
        Me.rabtnNOCum_CertifAnalisis.AutoSize = True
        Me.rabtnNOCum_CertifAnalisis.Location = New System.Drawing.Point(97, 10)
        Me.rabtnNOCum_CertifAnalisis.Name = "rabtnNOCum_CertifAnalisis"
        Me.rabtnNOCum_CertifAnalisis.Size = New System.Drawing.Size(14, 13)
        Me.rabtnNOCum_CertifAnalisis.TabIndex = 1
        Me.rabtnNOCum_CertifAnalisis.UseVisualStyleBackColor = True
        '
        'rabtnCum_CertifAnalisis
        '
        Me.rabtnCum_CertifAnalisis.AutoSize = True
        Me.rabtnCum_CertifAnalisis.Checked = True
        Me.rabtnCum_CertifAnalisis.Location = New System.Drawing.Point(22, 10)
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
        Me.lblCertifAnalisis.Location = New System.Drawing.Point(17, 85)
        Me.lblCertifAnalisis.MaximumSize = New System.Drawing.Size(220, 40)
        Me.lblCertifAnalisis.Name = "lblCertifAnalisis"
        Me.lblCertifAnalisis.Size = New System.Drawing.Size(66, 13)
        Me.lblCertifAnalisis.TabIndex = 3
        Me.lblCertifAnalisis.Text = "CertifAnalisis"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(296, 61)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(59, 13)
        Me.Label18.TabIndex = 2
        Me.Label18.Text = "No Cumple"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(231, 61)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(42, 13)
        Me.Label17.TabIndex = 1
        Me.Label17.Text = "Cumple"
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
        Me.btnAceptar_pnlAviso.Location = New System.Drawing.Point(178, 158)
        Me.btnAceptar_pnlAviso.Name = "btnAceptar_pnlAviso"
        Me.btnAceptar_pnlAviso.Size = New System.Drawing.Size(75, 23)
        Me.btnAceptar_pnlAviso.TabIndex = 6
        Me.btnAceptar_pnlAviso.Text = "Aceptar"
        Me.btnAceptar_pnlAviso.UseVisualStyleBackColor = True
        '
        'lblAviso3
        '
        Me.lblAviso3.AutoSize = True
        Me.lblAviso3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAviso3.ForeColor = System.Drawing.Color.Red
        Me.lblAviso3.Location = New System.Drawing.Point(15, 130)
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
        Me.lblAviso2.Location = New System.Drawing.Point(25, 86)
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
        Me.lblAviso1.Location = New System.Drawing.Point(15, 43)
        Me.lblAviso1.Name = "lblAviso1"
        Me.lblAviso1.Size = New System.Drawing.Size(418, 17)
        Me.lblAviso1.TabIndex = 0
        Me.lblAviso1.Text = "A CONFIRMADO QUE DEJA PENDIENTE DE RECEPCION"
        '
        'pnlCertifAnaliyEstadoEtiquet
        '
        Me.pnlCertifAnaliyEstadoEtiquet.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlCertifAnaliyEstadoEtiquet.Controls.Add(Me.Panel2)
        Me.pnlCertifAnaliyEstadoEtiquet.Controls.Add(Me.mastxtVencimiento_pnlIngreCertif)
        Me.pnlCertifAnaliyEstadoEtiquet.Controls.Add(Me.btnAceptar_IngreCert)
        Me.pnlCertifAnaliyEstadoEtiquet.Controls.Add(Me.Label21)
        Me.pnlCertifAnaliyEstadoEtiquet.Controls.Add(Me.txtEstadoEnvases5)
        Me.pnlCertifAnaliyEstadoEtiquet.Controls.Add(Me.txtCertifAnalisis2)
        Me.pnlCertifAnaliyEstadoEtiquet.Controls.Add(Me.panel5)
        Me.pnlCertifAnaliyEstadoEtiquet.Controls.Add(Me.Panel3)
        Me.pnlCertifAnaliyEstadoEtiquet.Controls.Add(Me.EstadoEnvases5)
        Me.pnlCertifAnaliyEstadoEtiquet.Controls.Add(Me.CertifAnalisis2)
        Me.pnlCertifAnaliyEstadoEtiquet.Location = New System.Drawing.Point(167, 123)
        Me.pnlCertifAnaliyEstadoEtiquet.Name = "pnlCertifAnaliyEstadoEtiquet"
        Me.pnlCertifAnaliyEstadoEtiquet.Size = New System.Drawing.Size(570, 191)
        Me.pnlCertifAnaliyEstadoEtiquet.TabIndex = 30
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.Panel2.Controls.Add(Me.Label22)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(566, 46)
        Me.Panel2.TabIndex = 20
        '
        'Label22
        '
        Me.Label22.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.SystemColors.Control
        Me.Label22.Location = New System.Drawing.Point(3, 7)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(452, 20)
        Me.Label22.TabIndex = 3
        Me.Label22.Text = "Ingreso de Certificado de Analisis y Estado de Envases"
        '
        'mastxtVencimiento_pnlIngreCertif
        '
        Me.mastxtVencimiento_pnlIngreCertif.Location = New System.Drawing.Point(143, 149)
        Me.mastxtVencimiento_pnlIngreCertif.Mask = "00/00/0000"
        Me.mastxtVencimiento_pnlIngreCertif.Name = "mastxtVencimiento_pnlIngreCertif"
        Me.mastxtVencimiento_pnlIngreCertif.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.mastxtVencimiento_pnlIngreCertif.Size = New System.Drawing.Size(100, 20)
        Me.mastxtVencimiento_pnlIngreCertif.TabIndex = 19
        Me.mastxtVencimiento_pnlIngreCertif.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnAceptar_IngreCert
        '
        Me.btnAceptar_IngreCert.Location = New System.Drawing.Point(295, 148)
        Me.btnAceptar_IngreCert.Name = "btnAceptar_IngreCert"
        Me.btnAceptar_IngreCert.Size = New System.Drawing.Size(75, 23)
        Me.btnAceptar_IngreCert.TabIndex = 18
        Me.btnAceptar_IngreCert.Text = "Aceptar"
        Me.btnAceptar_IngreCert.UseVisualStyleBackColor = True
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(24, 152)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(65, 13)
        Me.Label21.TabIndex = 16
        Me.Label21.Text = "Vencimiento"
        '
        'txtEstadoEnvases5
        '
        Me.txtEstadoEnvases5.Location = New System.Drawing.Point(289, 101)
        Me.txtEstadoEnvases5.MaxLength = 50
        Me.txtEstadoEnvases5.Multiline = True
        Me.txtEstadoEnvases5.Name = "txtEstadoEnvases5"
        Me.txtEstadoEnvases5.Size = New System.Drawing.Size(260, 32)
        Me.txtEstadoEnvases5.TabIndex = 15
        '
        'txtCertifAnalisis2
        '
        Me.txtCertifAnalisis2.Location = New System.Drawing.Point(289, 54)
        Me.txtCertifAnalisis2.MaxLength = 50
        Me.txtCertifAnalisis2.Multiline = True
        Me.txtCertifAnalisis2.Name = "txtCertifAnalisis2"
        Me.txtCertifAnalisis2.Size = New System.Drawing.Size(260, 32)
        Me.txtCertifAnalisis2.TabIndex = 14
        '
        'panel5
        '
        Me.panel5.Controls.Add(Me.rabtnNO_EstadoEnvases5)
        Me.panel5.Controls.Add(Me.rabtnSI_EstadoEnvases5)
        Me.panel5.Location = New System.Drawing.Point(142, 101)
        Me.panel5.Name = "panel5"
        Me.panel5.Size = New System.Drawing.Size(141, 32)
        Me.panel5.TabIndex = 13
        '
        'rabtnNO_EstadoEnvases5
        '
        Me.rabtnNO_EstadoEnvases5.AutoSize = True
        Me.rabtnNO_EstadoEnvases5.Location = New System.Drawing.Point(97, 10)
        Me.rabtnNO_EstadoEnvases5.Name = "rabtnNO_EstadoEnvases5"
        Me.rabtnNO_EstadoEnvases5.Size = New System.Drawing.Size(39, 17)
        Me.rabtnNO_EstadoEnvases5.TabIndex = 1
        Me.rabtnNO_EstadoEnvases5.Text = "No"
        Me.rabtnNO_EstadoEnvases5.UseVisualStyleBackColor = True
        '
        'rabtnSI_EstadoEnvases5
        '
        Me.rabtnSI_EstadoEnvases5.AutoSize = True
        Me.rabtnSI_EstadoEnvases5.Checked = True
        Me.rabtnSI_EstadoEnvases5.Location = New System.Drawing.Point(22, 10)
        Me.rabtnSI_EstadoEnvases5.Name = "rabtnSI_EstadoEnvases5"
        Me.rabtnSI_EstadoEnvases5.Size = New System.Drawing.Size(34, 17)
        Me.rabtnSI_EstadoEnvases5.TabIndex = 0
        Me.rabtnSI_EstadoEnvases5.TabStop = True
        Me.rabtnSI_EstadoEnvases5.Text = "Si"
        Me.rabtnSI_EstadoEnvases5.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.rabtnNO_CertifAnalisis2)
        Me.Panel3.Controls.Add(Me.rabtnSI_CertifAnalisis2)
        Me.Panel3.Location = New System.Drawing.Point(142, 55)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(141, 32)
        Me.Panel3.TabIndex = 12
        '
        'rabtnNO_CertifAnalisis2
        '
        Me.rabtnNO_CertifAnalisis2.AutoSize = True
        Me.rabtnNO_CertifAnalisis2.Location = New System.Drawing.Point(97, 10)
        Me.rabtnNO_CertifAnalisis2.Name = "rabtnNO_CertifAnalisis2"
        Me.rabtnNO_CertifAnalisis2.Size = New System.Drawing.Size(39, 17)
        Me.rabtnNO_CertifAnalisis2.TabIndex = 1
        Me.rabtnNO_CertifAnalisis2.Text = "No"
        Me.rabtnNO_CertifAnalisis2.UseVisualStyleBackColor = True
        '
        'rabtnSI_CertifAnalisis2
        '
        Me.rabtnSI_CertifAnalisis2.AutoSize = True
        Me.rabtnSI_CertifAnalisis2.Checked = True
        Me.rabtnSI_CertifAnalisis2.Location = New System.Drawing.Point(22, 10)
        Me.rabtnSI_CertifAnalisis2.Name = "rabtnSI_CertifAnalisis2"
        Me.rabtnSI_CertifAnalisis2.Size = New System.Drawing.Size(34, 17)
        Me.rabtnSI_CertifAnalisis2.TabIndex = 0
        Me.rabtnSI_CertifAnalisis2.TabStop = True
        Me.rabtnSI_CertifAnalisis2.Text = "Si"
        Me.rabtnSI_CertifAnalisis2.UseVisualStyleBackColor = True
        '
        'EstadoEnvases5
        '
        Me.EstadoEnvases5.AutoSize = True
        Me.EstadoEnvases5.Location = New System.Drawing.Point(18, 111)
        Me.EstadoEnvases5.MaximumSize = New System.Drawing.Size(200, 40)
        Me.EstadoEnvases5.Name = "EstadoEnvases5"
        Me.EstadoEnvases5.Size = New System.Drawing.Size(99, 13)
        Me.EstadoEnvases5.TabIndex = 2
        Me.EstadoEnvases5.Text = "Estado de Envases"
        '
        'CertifAnalisis2
        '
        Me.CertifAnalisis2.AutoSize = True
        Me.CertifAnalisis2.Location = New System.Drawing.Point(15, 65)
        Me.CertifAnalisis2.MaximumSize = New System.Drawing.Size(200, 40)
        Me.CertifAnalisis2.Name = "CertifAnalisis2"
        Me.CertifAnalisis2.Size = New System.Drawing.Size(87, 13)
        Me.CertifAnalisis2.TabIndex = 1
        Me.CertifAnalisis2.Text = "Certif. de Analisis"
        '
        'pnlAyudaProv
        '
        Me.pnlAyudaProv.Controls.Add(Me.btnVolver_pnlAyudaProv)
        Me.pnlAyudaProv.Controls.Add(Me.DGV_AyudaProv)
        Me.pnlAyudaProv.Controls.Add(Me.Panel7)
        Me.pnlAyudaProv.Location = New System.Drawing.Point(107, 86)
        Me.pnlAyudaProv.Name = "pnlAyudaProv"
        Me.pnlAyudaProv.Size = New System.Drawing.Size(471, 253)
        Me.pnlAyudaProv.TabIndex = 32
        '
        'btnVolver_pnlAyudaProv
        '
        Me.btnVolver_pnlAyudaProv.Location = New System.Drawing.Point(186, 223)
        Me.btnVolver_pnlAyudaProv.Name = "btnVolver_pnlAyudaProv"
        Me.btnVolver_pnlAyudaProv.Size = New System.Drawing.Size(75, 23)
        Me.btnVolver_pnlAyudaProv.TabIndex = 2
        Me.btnVolver_pnlAyudaProv.Text = "Volver"
        Me.btnVolver_pnlAyudaProv.UseVisualStyleBackColor = True
        '
        'DGV_AyudaProv
        '
        Me.DGV_AyudaProv.AllowUserToAddRows = False
        Me.DGV_AyudaProv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_AyudaProv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.AyudaArticulo, Me.AyudaDescripcion, Me.AyudaSaldo, Me.NroOrden})
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(232, Byte), Integer))
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGV_AyudaProv.DefaultCellStyle = DataGridViewCellStyle11
        Me.DGV_AyudaProv.DoubleBuffered = True
        Me.DGV_AyudaProv.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.DGV_AyudaProv.Location = New System.Drawing.Point(10, 56)
        Me.DGV_AyudaProv.Name = "DGV_AyudaProv"
        Me.DGV_AyudaProv.OrdenamientoColumnasHabilitado = True
        Me.DGV_AyudaProv.RowHeadersWidth = 15
        Me.DGV_AyudaProv.RowTemplate.Height = 20
        Me.DGV_AyudaProv.ShowCellToolTips = False
        Me.DGV_AyudaProv.SinClickDerecho = False
        Me.DGV_AyudaProv.Size = New System.Drawing.Size(451, 160)
        Me.DGV_AyudaProv.TabIndex = 1
        '
        'AyudaArticulo
        '
        Me.AyudaArticulo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.AyudaArticulo.DataPropertyName = "AyudaArticulo"
        Me.AyudaArticulo.HeaderText = "Materia Prima"
        Me.AyudaArticulo.Name = "AyudaArticulo"
        Me.AyudaArticulo.Width = 96
        '
        'AyudaDescripcion
        '
        Me.AyudaDescripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.AyudaDescripcion.DataPropertyName = "AyudaDescripcion"
        Me.AyudaDescripcion.HeaderText = "Descripcion"
        Me.AyudaDescripcion.Name = "AyudaDescripcion"
        '
        'AyudaSaldo
        '
        Me.AyudaSaldo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.AyudaSaldo.DataPropertyName = "AyudaSaldo"
        Me.AyudaSaldo.HeaderText = "Saldo"
        Me.AyudaSaldo.Name = "AyudaSaldo"
        Me.AyudaSaldo.Width = 59
        '
        'NroOrden
        '
        Me.NroOrden.DataPropertyName = "NroOrden"
        Me.NroOrden.HeaderText = "NroOrden"
        Me.NroOrden.Name = "NroOrden"
        Me.NroOrden.Visible = False
        '
        'Panel7
        '
        Me.Panel7.BackColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.Panel7.Controls.Add(Me.Label16)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel7.Location = New System.Drawing.Point(0, 0)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(471, 47)
        Me.Panel7.TabIndex = 0
        '
        'Label16
        '
        Me.Label16.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.SystemColors.Control
        Me.Label16.Location = New System.Drawing.Point(9, 11)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(249, 20)
        Me.Label16.TabIndex = 4
        Me.Label16.Text = "Ayuda Ordenes por Proveedor"
        '
        'btnGrabar
        '
        Me.btnGrabar.Location = New System.Drawing.Point(95, 467)
        Me.btnGrabar.Name = "btnGrabar"
        Me.btnGrabar.Size = New System.Drawing.Size(75, 23)
        Me.btnGrabar.TabIndex = 33
        Me.btnGrabar.Text = "Grabar"
        Me.btnGrabar.UseVisualStyleBackColor = True
        '
        'btnLimpiarForm
        '
        Me.btnLimpiarForm.Location = New System.Drawing.Point(176, 467)
        Me.btnLimpiarForm.Name = "btnLimpiarForm"
        Me.btnLimpiarForm.Size = New System.Drawing.Size(75, 23)
        Me.btnLimpiarForm.TabIndex = 34
        Me.btnLimpiarForm.Text = "Limpiar"
        Me.btnLimpiarForm.UseVisualStyleBackColor = True
        '
        'btnBuscarProv
        '
        Me.btnBuscarProv.BackgroundImage = Global.Laboratorio.My.Resources.Resources.Consulta_Dat_N1
        Me.btnBuscarProv.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnBuscarProv.FlatAppearance.BorderSize = 0
        Me.btnBuscarProv.Location = New System.Drawing.Point(68, 91)
        Me.btnBuscarProv.Name = "btnBuscarProv"
        Me.btnBuscarProv.Size = New System.Drawing.Size(33, 35)
        Me.btnBuscarProv.TabIndex = 35
        Me.btnBuscarProv.UseVisualStyleBackColor = True
        '
        'btnVolver
        '
        Me.btnVolver.Location = New System.Drawing.Point(337, 466)
        Me.btnVolver.Name = "btnVolver"
        Me.btnVolver.Size = New System.Drawing.Size(75, 23)
        Me.btnVolver.TabIndex = 36
        Me.btnVolver.Text = "Volver"
        Me.btnVolver.UseVisualStyleBackColor = True
        '
        'pnlBuscarProveedor
        '
        Me.pnlBuscarProveedor.Controls.Add(Me.txtBuscardorProv)
        Me.pnlBuscarProveedor.Controls.Add(Me.btnVolver_PnlProveedores)
        Me.pnlBuscarProveedor.Controls.Add(Me.DGV_Proveedores)
        Me.pnlBuscarProveedor.Controls.Add(Me.Panel8)
        Me.pnlBuscarProveedor.Location = New System.Drawing.Point(72, 119)
        Me.pnlBuscarProveedor.Name = "pnlBuscarProveedor"
        Me.pnlBuscarProveedor.Size = New System.Drawing.Size(498, 308)
        Me.pnlBuscarProveedor.TabIndex = 37
        '
        'txtBuscardorProv
        '
        Me.txtBuscardorProv.Location = New System.Drawing.Point(10, 63)
        Me.txtBuscardorProv.Name = "txtBuscardorProv"
        Me.txtBuscardorProv.Size = New System.Drawing.Size(476, 20)
        Me.txtBuscardorProv.TabIndex = 3
        '
        'btnVolver_PnlProveedores
        '
        Me.btnVolver_PnlProveedores.Location = New System.Drawing.Point(201, 280)
        Me.btnVolver_PnlProveedores.Name = "btnVolver_PnlProveedores"
        Me.btnVolver_PnlProveedores.Size = New System.Drawing.Size(75, 23)
        Me.btnVolver_PnlProveedores.TabIndex = 2
        Me.btnVolver_PnlProveedores.Text = "Volver"
        Me.btnVolver_PnlProveedores.UseVisualStyleBackColor = True
        '
        'DGV_Proveedores
        '
        Me.DGV_Proveedores.AllowUserToAddRows = False
        Me.DGV_Proveedores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_Proveedores.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CodigoProv, Me.DescripcionProv})
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle12.BackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(232, Byte), Integer))
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGV_Proveedores.DefaultCellStyle = DataGridViewCellStyle12
        Me.DGV_Proveedores.DoubleBuffered = True
        Me.DGV_Proveedores.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.DGV_Proveedores.Location = New System.Drawing.Point(10, 89)
        Me.DGV_Proveedores.Name = "DGV_Proveedores"
        Me.DGV_Proveedores.OrdenamientoColumnasHabilitado = True
        Me.DGV_Proveedores.RowHeadersWidth = 15
        Me.DGV_Proveedores.RowTemplate.Height = 20
        Me.DGV_Proveedores.ShowCellToolTips = False
        Me.DGV_Proveedores.SinClickDerecho = False
        Me.DGV_Proveedores.Size = New System.Drawing.Size(476, 187)
        Me.DGV_Proveedores.TabIndex = 1
        '
        'CodigoProv
        '
        Me.CodigoProv.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.CodigoProv.DataPropertyName = "CodigoProv"
        Me.CodigoProv.HeaderText = "Codigo"
        Me.CodigoProv.MinimumWidth = 100
        Me.CodigoProv.Name = "CodigoProv"
        '
        'DescripcionProv
        '
        Me.DescripcionProv.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DescripcionProv.DataPropertyName = "DescripcionProv"
        Me.DescripcionProv.HeaderText = "Descripcion"
        Me.DescripcionProv.Name = "DescripcionProv"
        '
        'Panel8
        '
        Me.Panel8.BackColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.Panel8.Controls.Add(Me.Label23)
        Me.Panel8.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel8.Location = New System.Drawing.Point(0, 0)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(498, 54)
        Me.Panel8.TabIndex = 0
        '
        'Label23
        '
        Me.Label23.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.SystemColors.Control
        Me.Label23.Location = New System.Drawing.Point(6, 18)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(201, 20)
        Me.Label23.TabIndex = 3
        Me.Label23.Text = "Busqueda de Proveedor"
        '
        'InformeRecepcionDrogaLAB
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(788, 496)
        Me.Controls.Add(Me.pnlBuscarProveedor)
        Me.Controls.Add(Me.PnlEstadoEnvases)
        Me.Controls.Add(Me.btnVolver)
        Me.Controls.Add(Me.btnBuscarProv)
        Me.Controls.Add(Me.btnLimpiarForm)
        Me.Controls.Add(Me.btnGrabar)
        Me.Controls.Add(Me.pnlAyudaProv)
        Me.Controls.Add(Me.pnlCertifAnaliyEstadoEtiquet)
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
        Me.Location = New System.Drawing.Point(10, 20)
        Me.Name = "InformeRecepcionDrogaLAB"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "InformeRecepcionDrogaLAB"
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
        Me.pnlCertifAnaliyEstadoEtiquet.ResumeLayout(False)
        Me.pnlCertifAnaliyEstadoEtiquet.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.panel5.ResumeLayout(False)
        Me.panel5.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.pnlAyudaProv.ResumeLayout(False)
        CType(Me.DGV_AyudaProv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel7.ResumeLayout(False)
        Me.Panel7.PerformLayout()
        Me.pnlBuscarProveedor.ResumeLayout(False)
        Me.pnlBuscarProveedor.PerformLayout()
        CType(Me.DGV_Proveedores, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel8.ResumeLayout(False)
        Me.Panel8.PerformLayout()
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
    Friend WithEvents pnlCertifAnaliyEstadoEtiquet As System.Windows.Forms.Panel
    Friend WithEvents txtEstadoEnvases5 As System.Windows.Forms.TextBox
    Friend WithEvents txtCertifAnalisis2 As System.Windows.Forms.TextBox
    Friend WithEvents panel5 As System.Windows.Forms.Panel
    Friend WithEvents rabtnNO_EstadoEnvases5 As System.Windows.Forms.RadioButton
    Friend WithEvents rabtnSI_EstadoEnvases5 As System.Windows.Forms.RadioButton
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents rabtnNO_CertifAnalisis2 As System.Windows.Forms.RadioButton
    Friend WithEvents rabtnSI_CertifAnalisis2 As System.Windows.Forms.RadioButton
    Friend WithEvents EstadoEnvases5 As System.Windows.Forms.Label
    Friend WithEvents CertifAnalisis2 As System.Windows.Forms.Label
    Friend WithEvents mastxtVencimiento_pnlIngreCertif As System.Windows.Forms.MaskedTextBox
    Friend WithEvents btnAceptar_IngreCert As System.Windows.Forms.Button
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents pnlAviso As System.Windows.Forms.Panel
    Friend WithEvents btnAceptar_pnlAviso As System.Windows.Forms.Button
    Friend WithEvents lblAviso3 As System.Windows.Forms.Label
    Friend WithEvents lblAviso2 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents lblAviso1 As System.Windows.Forms.Label
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents pnlAyudaProv As System.Windows.Forms.Panel
    Friend WithEvents DGV_AyudaProv As ConsultasVarias.DBDataGridView
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents btnVolver_pnlAyudaProv As System.Windows.Forms.Button
    Friend WithEvents AyudaArticulo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AyudaDescripcion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AyudaSaldo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NroOrden As System.Windows.Forms.DataGridViewTextBoxColumn
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
    Friend WithEvents pnlBuscarProveedor As System.Windows.Forms.Panel
    Friend WithEvents btnVolver_PnlProveedores As System.Windows.Forms.Button
    Friend WithEvents DGV_Proveedores As ConsultasVarias.DBDataGridView
    Friend WithEvents Panel8 As System.Windows.Forms.Panel
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents txtBuscardorProv As System.Windows.Forms.TextBox
    Friend WithEvents CodigoProv As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DescripcionProv As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
