<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Centro_Importaciones
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.label1 = New System.Windows.Forms.Label()
        Me.btn_Exportacion = New System.Windows.Forms.Button()
        Me.btn_Djai = New System.Windows.Forms.Button()
        Me.btn_Actualiza = New System.Windows.Forms.Button()
        Me.cbx_Ordenamiento = New System.Windows.Forms.ComboBox()
        Me.cbx_FiltroI = New System.Windows.Forms.ComboBox()
        Me.cbx_FiltroII = New System.Windows.Forms.ComboBox()
        Me.cbx_FiltroIII = New System.Windows.Forms.ComboBox()
        Me.cbx_Activas = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.chk_LetraPendiente = New System.Windows.Forms.CheckBox()
        Me.txt_SumaDespacho = New System.Windows.Forms.TextBox()
        Me.txt_SumaLetra = New System.Windows.Forms.TextBox()
        Me.txt_Articulo = New System.Windows.Forms.TextBox()
        Me.lbl_Articulo = New System.Windows.Forms.Label()
        Me.lbl_ArticuloKg = New System.Windows.Forms.Label()
        Me.DGV_Muestra = New Util.DBDataGridView()
        Me.Orden = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Pta = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Fecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Proveedor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Mon = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Carpeta = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DJai = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Origen = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Incoterms = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Transporte = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FLLegada = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TPago = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Despacho = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PagoDes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LetraTotal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PagoLetra = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.VtoLetra = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.USPagadoLetra = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FEmbarque = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SaldoLetra = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ProveedorCod = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.panel1.SuspendLayout()
        CType(Me.DGV_Muestra, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'panel1
        '
        Me.panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(34, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.panel1.Controls.Add(Me.Label2)
        Me.panel1.Controls.Add(Me.label1)
        Me.panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.panel1.Location = New System.Drawing.Point(0, 0)
        Me.panel1.Name = "panel1"
        Me.panel1.Size = New System.Drawing.Size(980, 50)
        Me.panel1.TabIndex = 36
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(825, 30)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(155, 20)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "SURFACTAN S.A."
        '
        'label1
        '
        Me.label1.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.label1.AutoSize = True
        Me.label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold)
        Me.label1.ForeColor = System.Drawing.Color.White
        Me.label1.Location = New System.Drawing.Point(3, 6)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(180, 17)
        Me.label1.TabIndex = 0
        Me.label1.Text = "Modificacion de Precios"
        '
        'btn_Exportacion
        '
        Me.btn_Exportacion.Location = New System.Drawing.Point(6, 56)
        Me.btn_Exportacion.Name = "btn_Exportacion"
        Me.btn_Exportacion.Size = New System.Drawing.Size(101, 23)
        Me.btn_Exportacion.TabIndex = 37
        Me.btn_Exportacion.Text = "EXPORTACION"
        Me.btn_Exportacion.UseVisualStyleBackColor = True
        '
        'btn_Djai
        '
        Me.btn_Djai.Location = New System.Drawing.Point(6, 85)
        Me.btn_Djai.Name = "btn_Djai"
        Me.btn_Djai.Size = New System.Drawing.Size(101, 23)
        Me.btn_Djai.TabIndex = 38
        Me.btn_Djai.Text = "TXT DJAI"
        Me.btn_Djai.UseVisualStyleBackColor = True
        '
        'btn_Actualiza
        '
        Me.btn_Actualiza.Location = New System.Drawing.Point(878, 85)
        Me.btn_Actualiza.Name = "btn_Actualiza"
        Me.btn_Actualiza.Size = New System.Drawing.Size(75, 23)
        Me.btn_Actualiza.TabIndex = 39
        Me.btn_Actualiza.Text = "ACTUALIZA"
        Me.btn_Actualiza.UseVisualStyleBackColor = True
        '
        'cbx_Ordenamiento
        '
        Me.cbx_Ordenamiento.FormattingEnabled = True
        Me.cbx_Ordenamiento.Items.AddRange(New Object() {"Orden", "Planta", "Fecha", "Proveedor", "Moneda", "Carpeta", "DJai", "Origen", "Incoterms", "Tipo", "Fecha LLegada", "Tipo Pago", "Despacho", "Pago Des", "Letra", "Pago Letra", "Vto.Letra"})
        Me.cbx_Ordenamiento.Location = New System.Drawing.Point(192, 56)
        Me.cbx_Ordenamiento.Name = "cbx_Ordenamiento"
        Me.cbx_Ordenamiento.Size = New System.Drawing.Size(121, 21)
        Me.cbx_Ordenamiento.TabIndex = 40
        '
        'cbx_FiltroI
        '
        Me.cbx_FiltroI.FormattingEnabled = True
        Me.cbx_FiltroI.Items.AddRange(New Object() {"", "Orden", "Fecha", "Proveedor", "Carpeta", "DJai", "Origen", "Incoterms", "Transporte", "F.LLegada", "T.Pago", "Pago Despacho", "Pago Letra", "Vto. Letra", "M.Prima"})
        Me.cbx_FiltroI.Location = New System.Drawing.Point(363, 56)
        Me.cbx_FiltroI.Name = "cbx_FiltroI"
        Me.cbx_FiltroI.Size = New System.Drawing.Size(121, 21)
        Me.cbx_FiltroI.TabIndex = 41
        '
        'cbx_FiltroII
        '
        Me.cbx_FiltroII.FormattingEnabled = True
        Me.cbx_FiltroII.Items.AddRange(New Object() {"", "Planta", "Fecha", "Proveedor", "Origen", "Incoterms", "Transporte", "F.LLegada", "T.Pago", "Pago Despacho", "Pago Letra", "Vto. Letra"})
        Me.cbx_FiltroII.Location = New System.Drawing.Point(490, 57)
        Me.cbx_FiltroII.Name = "cbx_FiltroII"
        Me.cbx_FiltroII.Size = New System.Drawing.Size(121, 21)
        Me.cbx_FiltroII.TabIndex = 42
        '
        'cbx_FiltroIII
        '
        Me.cbx_FiltroIII.FormattingEnabled = True
        Me.cbx_FiltroIII.Items.AddRange(New Object() {"", "Planta", "Fecha", "Proveedor", "Origen", "Incoterms", "Transporte", "F.LLegada", "T.Pago", "Pago Despacho", "Pago Letra", "Vto. Letra"})
        Me.cbx_FiltroIII.Location = New System.Drawing.Point(617, 58)
        Me.cbx_FiltroIII.Name = "cbx_FiltroIII"
        Me.cbx_FiltroIII.Size = New System.Drawing.Size(121, 21)
        Me.cbx_FiltroIII.TabIndex = 43
        '
        'cbx_Activas
        '
        Me.cbx_Activas.FormattingEnabled = True
        Me.cbx_Activas.Items.AddRange(New Object() {"Activas", "Cerradas"})
        Me.cbx_Activas.Location = New System.Drawing.Point(850, 57)
        Me.cbx_Activas.Name = "cbx_Activas"
        Me.cbx_Activas.Size = New System.Drawing.Size(121, 21)
        Me.cbx_Activas.TabIndex = 44
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(328, 59)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(29, 13)
        Me.Label3.TabIndex = 45
        Me.Label3.Text = "Filtro"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(113, 59)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(73, 13)
        Me.Label4.TabIndex = 46
        Me.Label4.Text = "Ordenamiento"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(113, 90)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(65, 13)
        Me.Label5.TabIndex = 47
        Me.Label5.Text = "$ Despacho"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(308, 90)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(55, 13)
        Me.Label6.TabIndex = 48
        Me.Label6.Text = "U$S Letra"
        '
        'chk_LetraPendiente
        '
        Me.chk_LetraPendiente.AutoSize = True
        Me.chk_LetraPendiente.Location = New System.Drawing.Point(744, 60)
        Me.chk_LetraPendiente.Name = "chk_LetraPendiente"
        Me.chk_LetraPendiente.Size = New System.Drawing.Size(101, 17)
        Me.chk_LetraPendiente.TabIndex = 49
        Me.chk_LetraPendiente.Text = "Letra Pendiente"
        Me.chk_LetraPendiente.UseVisualStyleBackColor = True
        '
        'txt_SumaDespacho
        '
        Me.txt_SumaDespacho.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txt_SumaDespacho.Location = New System.Drawing.Point(184, 85)
        Me.txt_SumaDespacho.Name = "txt_SumaDespacho"
        Me.txt_SumaDespacho.ReadOnly = True
        Me.txt_SumaDespacho.Size = New System.Drawing.Size(100, 20)
        Me.txt_SumaDespacho.TabIndex = 50
        '
        'txt_SumaLetra
        '
        Me.txt_SumaLetra.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txt_SumaLetra.Location = New System.Drawing.Point(363, 85)
        Me.txt_SumaLetra.Name = "txt_SumaLetra"
        Me.txt_SumaLetra.ReadOnly = True
        Me.txt_SumaLetra.Size = New System.Drawing.Size(100, 20)
        Me.txt_SumaLetra.TabIndex = 51
        '
        'txt_Articulo
        '
        Me.txt_Articulo.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txt_Articulo.Location = New System.Drawing.Point(565, 85)
        Me.txt_Articulo.Name = "txt_Articulo"
        Me.txt_Articulo.ReadOnly = True
        Me.txt_Articulo.Size = New System.Drawing.Size(100, 20)
        Me.txt_Articulo.TabIndex = 53
        '
        'lbl_Articulo
        '
        Me.lbl_Articulo.AutoSize = True
        Me.lbl_Articulo.Location = New System.Drawing.Point(517, 90)
        Me.lbl_Articulo.Name = "lbl_Articulo"
        Me.lbl_Articulo.Size = New System.Drawing.Size(42, 13)
        Me.lbl_Articulo.TabIndex = 52
        Me.lbl_Articulo.Text = "Articulo"
        '
        'lbl_ArticuloKg
        '
        Me.lbl_ArticuloKg.AutoSize = True
        Me.lbl_ArticuloKg.Location = New System.Drawing.Point(671, 88)
        Me.lbl_ArticuloKg.Name = "lbl_ArticuloKg"
        Me.lbl_ArticuloKg.Size = New System.Drawing.Size(28, 13)
        Me.lbl_ArticuloKg.TabIndex = 54
        Me.lbl_ArticuloKg.Text = "Kgs."
        '
        'DGV_Muestra
        '
        Me.DGV_Muestra.AllowUserToAddRows = False
        Me.DGV_Muestra.AllowUserToDeleteRows = False
        Me.DGV_Muestra.AllowUserToOrderColumns = True
        Me.DGV_Muestra.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_Muestra.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Orden, Me.Pta, Me.Fecha, Me.Proveedor, Me.Mon, Me.Carpeta, Me.DJai, Me.Origen, Me.Incoterms, Me.Transporte, Me.FLLegada, Me.TPago, Me.Despacho, Me.PagoDes, Me.LetraTotal, Me.PagoLetra, Me.VtoLetra, Me.USPagadoLetra, Me.FEmbarque, Me.SaldoLetra, Me.ProveedorCod})
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(232, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGV_Muestra.DefaultCellStyle = DataGridViewCellStyle1
        Me.DGV_Muestra.DoubleBuffered = True
        Me.DGV_Muestra.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.DGV_Muestra.Location = New System.Drawing.Point(6, 115)
        Me.DGV_Muestra.Name = "DGV_Muestra"
        Me.DGV_Muestra.OrdenamientoColumnasHabilitado = True
        Me.DGV_Muestra.RowHeadersWidth = 15
        Me.DGV_Muestra.RowTemplate.Height = 20
        Me.DGV_Muestra.ShowCellToolTips = False
        Me.DGV_Muestra.SinClickDerecho = False
        Me.DGV_Muestra.Size = New System.Drawing.Size(965, 361)
        Me.DGV_Muestra.TabIndex = 55
        '
        'Orden
        '
        Me.Orden.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Orden.HeaderText = "Orden"
        Me.Orden.Name = "Orden"
        Me.Orden.Width = 61
        '
        'Pta
        '
        Me.Pta.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Pta.HeaderText = "Pta"
        Me.Pta.Name = "Pta"
        Me.Pta.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Pta.Width = 48
        '
        'Fecha
        '
        Me.Fecha.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Fecha.HeaderText = "Fecha"
        Me.Fecha.Name = "Fecha"
        Me.Fecha.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Fecha.Width = 62
        '
        'Proveedor
        '
        Me.Proveedor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Proveedor.HeaderText = "Proveedor"
        Me.Proveedor.Name = "Proveedor"
        Me.Proveedor.Width = 81
        '
        'Mon
        '
        Me.Mon.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Mon.HeaderText = "Mon"
        Me.Mon.Name = "Mon"
        Me.Mon.Width = 53
        '
        'Carpeta
        '
        Me.Carpeta.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Carpeta.HeaderText = "Carpeta"
        Me.Carpeta.Name = "Carpeta"
        Me.Carpeta.Width = 69
        '
        'DJai
        '
        Me.DJai.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DJai.HeaderText = "DJai"
        Me.DJai.Name = "DJai"
        Me.DJai.Width = 53
        '
        'Origen
        '
        Me.Origen.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Origen.HeaderText = "Origen"
        Me.Origen.Name = "Origen"
        Me.Origen.Width = 63
        '
        'Incoterms
        '
        Me.Incoterms.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Incoterms.HeaderText = "Incoterms"
        Me.Incoterms.Name = "Incoterms"
        Me.Incoterms.Width = 78
        '
        'Transporte
        '
        Me.Transporte.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Transporte.HeaderText = "Transporte"
        Me.Transporte.Name = "Transporte"
        Me.Transporte.Width = 83
        '
        'FLLegada
        '
        Me.FLLegada.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.FLLegada.HeaderText = "F.LLegada"
        Me.FLLegada.Name = "FLLegada"
        Me.FLLegada.Width = 83
        '
        'TPago
        '
        Me.TPago.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.TPago.HeaderText = "T.Pago"
        Me.TPago.Name = "TPago"
        Me.TPago.Width = 67
        '
        'Despacho
        '
        Me.Despacho.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Despacho.HeaderText = "Despacho"
        Me.Despacho.Name = "Despacho"
        Me.Despacho.Width = 81
        '
        'PagoDes
        '
        Me.PagoDes.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.PagoDes.HeaderText = "Pago Des"
        Me.PagoDes.Name = "PagoDes"
        Me.PagoDes.Width = 73
        '
        'LetraTotal
        '
        Me.LetraTotal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.LetraTotal.HeaderText = "Letra Total"
        Me.LetraTotal.Name = "LetraTotal"
        Me.LetraTotal.Width = 77
        '
        'PagoLetra
        '
        Me.PagoLetra.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.PagoLetra.HeaderText = "Pago Letra"
        Me.PagoLetra.Name = "PagoLetra"
        Me.PagoLetra.Width = 78
        '
        'VtoLetra
        '
        Me.VtoLetra.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.VtoLetra.HeaderText = "Vto Letra"
        Me.VtoLetra.Name = "VtoLetra"
        Me.VtoLetra.Width = 69
        '
        'USPagadoLetra
        '
        Me.USPagadoLetra.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.USPagadoLetra.HeaderText = "U$S Pagado Letra"
        Me.USPagadoLetra.Name = "USPagadoLetra"
        Me.USPagadoLetra.Width = 110
        '
        'FEmbarque
        '
        Me.FEmbarque.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.FEmbarque.HeaderText = "F.Embarque"
        Me.FEmbarque.Name = "FEmbarque"
        Me.FEmbarque.Width = 89
        '
        'SaldoLetra
        '
        Me.SaldoLetra.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.SaldoLetra.HeaderText = "Saldo Letra"
        Me.SaldoLetra.Name = "SaldoLetra"
        Me.SaldoLetra.Width = 79
        '
        'ProveedorCod
        '
        Me.ProveedorCod.HeaderText = "ProveedorCod"
        Me.ProveedorCod.Name = "ProveedorCod"
        Me.ProveedorCod.Visible = False
        '
        'Centro_Importaciones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(980, 488)
        Me.Controls.Add(Me.DGV_Muestra)
        Me.Controls.Add(Me.lbl_ArticuloKg)
        Me.Controls.Add(Me.txt_Articulo)
        Me.Controls.Add(Me.lbl_Articulo)
        Me.Controls.Add(Me.txt_SumaLetra)
        Me.Controls.Add(Me.txt_SumaDespacho)
        Me.Controls.Add(Me.chk_LetraPendiente)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cbx_Activas)
        Me.Controls.Add(Me.cbx_FiltroIII)
        Me.Controls.Add(Me.cbx_FiltroII)
        Me.Controls.Add(Me.cbx_FiltroI)
        Me.Controls.Add(Me.cbx_Ordenamiento)
        Me.Controls.Add(Me.btn_Actualiza)
        Me.Controls.Add(Me.btn_Djai)
        Me.Controls.Add(Me.btn_Exportacion)
        Me.Controls.Add(Me.panel1)
        Me.Location = New System.Drawing.Point(20, 20)
        Me.Name = "Centro_Importaciones"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.panel1.ResumeLayout(False)
        Me.panel1.PerformLayout()
        CType(Me.DGV_Muestra, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents panel1 As System.Windows.Forms.Panel
    Private WithEvents Label2 As System.Windows.Forms.Label
    Private WithEvents label1 As System.Windows.Forms.Label
    Friend WithEvents btn_Exportacion As System.Windows.Forms.Button
    Friend WithEvents btn_Djai As System.Windows.Forms.Button
    Friend WithEvents btn_Actualiza As System.Windows.Forms.Button
    Friend WithEvents cbx_Ordenamiento As System.Windows.Forms.ComboBox
    Friend WithEvents cbx_FiltroI As System.Windows.Forms.ComboBox
    Friend WithEvents cbx_FiltroII As System.Windows.Forms.ComboBox
    Friend WithEvents cbx_FiltroIII As System.Windows.Forms.ComboBox
    Friend WithEvents cbx_Activas As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents chk_LetraPendiente As System.Windows.Forms.CheckBox
    Friend WithEvents txt_SumaDespacho As System.Windows.Forms.TextBox
    Friend WithEvents txt_SumaLetra As System.Windows.Forms.TextBox
    Friend WithEvents txt_Articulo As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Articulo As System.Windows.Forms.Label
    Friend WithEvents lbl_ArticuloKg As System.Windows.Forms.Label
    Friend WithEvents DGV_Muestra As Util.DBDataGridView
    Friend WithEvents Orden As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Pta As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Fecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Proveedor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Mon As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Carpeta As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DJai As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Origen As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Incoterms As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Transporte As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FLLegada As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TPago As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Despacho As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PagoDes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LetraTotal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PagoLetra As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VtoLetra As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents USPagadoLetra As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FEmbarque As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SaldoLetra As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ProveedorCod As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
