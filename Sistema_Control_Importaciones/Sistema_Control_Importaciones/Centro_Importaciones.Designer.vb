﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.DGV_Muestra = New Util.DBDataGridView()
        Me.lbl_ArticuloKg = New System.Windows.Forms.Label()
        Me.txt_Articulo = New System.Windows.Forms.TextBox()
        Me.lbl_Articulo = New System.Windows.Forms.Label()
        Me.txt_SumaLetra = New System.Windows.Forms.TextBox()
        Me.txt_SumaDespacho = New System.Windows.Forms.TextBox()
        Me.chk_LetraPendiente = New System.Windows.Forms.CheckBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cbx_Activas = New System.Windows.Forms.ComboBox()
        Me.cbx_FiltroIII = New System.Windows.Forms.ComboBox()
        Me.cbx_FiltroII = New System.Windows.Forms.ComboBox()
        Me.cbx_FiltroI = New System.Windows.Forms.ComboBox()
        Me.btn_Actualiza = New System.Windows.Forms.Button()
        Me.btn_Djai = New System.Windows.Forms.Button()
        Me.btn_Exportacion = New System.Windows.Forms.Button()
        Me.panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.label1 = New System.Windows.Forms.Label()
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
        Me.txt_Filtro = New System.Windows.Forms.TextBox()
        CType(Me.DGV_Muestra, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'DGV_Muestra
        '
        Me.DGV_Muestra.AllowUserToAddRows = False
        Me.DGV_Muestra.AllowUserToDeleteRows = False
        Me.DGV_Muestra.AllowUserToOrderColumns = True
        Me.DGV_Muestra.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_Muestra.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Orden, Me.Pta, Me.Fecha, Me.Proveedor, Me.Mon, Me.Carpeta, Me.DJai, Me.Origen, Me.Incoterms, Me.Transporte, Me.FLLegada, Me.TPago, Me.Despacho, Me.PagoDes, Me.LetraTotal, Me.PagoLetra, Me.VtoLetra, Me.USPagadoLetra, Me.FEmbarque, Me.SaldoLetra, Me.ProveedorCod})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(232, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGV_Muestra.DefaultCellStyle = DataGridViewCellStyle2
        Me.DGV_Muestra.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.DGV_Muestra.DoubleBuffered = True
        Me.DGV_Muestra.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.DGV_Muestra.Location = New System.Drawing.Point(0, 145)
        Me.DGV_Muestra.Margin = New System.Windows.Forms.Padding(4)
        Me.DGV_Muestra.Name = "DGV_Muestra"
        Me.DGV_Muestra.OrdenamientoColumnasHabilitado = True
        Me.DGV_Muestra.RowHeadersWidth = 15
        Me.DGV_Muestra.RowTemplate.Height = 20
        Me.DGV_Muestra.ShowCellToolTips = False
        Me.DGV_Muestra.SinClickDerecho = False
        Me.DGV_Muestra.Size = New System.Drawing.Size(1580, 780)
        Me.DGV_Muestra.TabIndex = 72
        '
        'lbl_ArticuloKg
        '
        Me.lbl_ArticuloKg.AutoSize = True
        Me.lbl_ArticuloKg.Location = New System.Drawing.Point(895, 112)
        Me.lbl_ArticuloKg.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_ArticuloKg.Name = "lbl_ArticuloKg"
        Me.lbl_ArticuloKg.Size = New System.Drawing.Size(36, 17)
        Me.lbl_ArticuloKg.TabIndex = 71
        Me.lbl_ArticuloKg.Text = "Kgs."
        '
        'txt_Articulo
        '
        Me.txt_Articulo.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txt_Articulo.Location = New System.Drawing.Point(753, 109)
        Me.txt_Articulo.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_Articulo.Name = "txt_Articulo"
        Me.txt_Articulo.ReadOnly = True
        Me.txt_Articulo.Size = New System.Drawing.Size(132, 22)
        Me.txt_Articulo.TabIndex = 70
        '
        'lbl_Articulo
        '
        Me.lbl_Articulo.AutoSize = True
        Me.lbl_Articulo.Location = New System.Drawing.Point(689, 115)
        Me.lbl_Articulo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_Articulo.Name = "lbl_Articulo"
        Me.lbl_Articulo.Size = New System.Drawing.Size(55, 17)
        Me.lbl_Articulo.TabIndex = 69
        Me.lbl_Articulo.Text = "Articulo"
        '
        'txt_SumaLetra
        '
        Me.txt_SumaLetra.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txt_SumaLetra.Location = New System.Drawing.Point(484, 109)
        Me.txt_SumaLetra.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_SumaLetra.Name = "txt_SumaLetra"
        Me.txt_SumaLetra.ReadOnly = True
        Me.txt_SumaLetra.Size = New System.Drawing.Size(132, 22)
        Me.txt_SumaLetra.TabIndex = 68
        '
        'txt_SumaDespacho
        '
        Me.txt_SumaDespacho.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txt_SumaDespacho.Location = New System.Drawing.Point(245, 109)
        Me.txt_SumaDespacho.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_SumaDespacho.Name = "txt_SumaDespacho"
        Me.txt_SumaDespacho.ReadOnly = True
        Me.txt_SumaDespacho.Size = New System.Drawing.Size(132, 22)
        Me.txt_SumaDespacho.TabIndex = 67
        '
        'chk_LetraPendiente
        '
        Me.chk_LetraPendiente.AutoSize = True
        Me.chk_LetraPendiente.Location = New System.Drawing.Point(992, 78)
        Me.chk_LetraPendiente.Margin = New System.Windows.Forms.Padding(4)
        Me.chk_LetraPendiente.Name = "chk_LetraPendiente"
        Me.chk_LetraPendiente.Size = New System.Drawing.Size(131, 21)
        Me.chk_LetraPendiente.TabIndex = 66
        Me.chk_LetraPendiente.Text = "Letra Pendiente"
        Me.chk_LetraPendiente.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(411, 115)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(72, 17)
        Me.Label6.TabIndex = 65
        Me.Label6.Text = "U$S Letra"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(151, 115)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(84, 17)
        Me.Label5.TabIndex = 64
        Me.Label5.Text = "$ Despacho"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(437, 77)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(39, 17)
        Me.Label3.TabIndex = 63
        Me.Label3.Text = "Filtro"
        '
        'cbx_Activas
        '
        Me.cbx_Activas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbx_Activas.FormattingEnabled = True
        Me.cbx_Activas.Items.AddRange(New Object() {"Activas", "Cerradas"})
        Me.cbx_Activas.Location = New System.Drawing.Point(1133, 74)
        Me.cbx_Activas.Margin = New System.Windows.Forms.Padding(4)
        Me.cbx_Activas.Name = "cbx_Activas"
        Me.cbx_Activas.Size = New System.Drawing.Size(160, 24)
        Me.cbx_Activas.TabIndex = 62
        '
        'cbx_FiltroIII
        '
        Me.cbx_FiltroIII.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbx_FiltroIII.FormattingEnabled = True
        Me.cbx_FiltroIII.Items.AddRange(New Object() {"", "Planta", "Fecha", "Proveedor", "Origen", "Incoterms", "Transporte", "F.LLegada", "T.Pago", "Pago Despacho", "Pago Letra", "Vto. Letra"})
        Me.cbx_FiltroIII.Location = New System.Drawing.Point(823, 75)
        Me.cbx_FiltroIII.Margin = New System.Windows.Forms.Padding(4)
        Me.cbx_FiltroIII.Name = "cbx_FiltroIII"
        Me.cbx_FiltroIII.Size = New System.Drawing.Size(160, 24)
        Me.cbx_FiltroIII.TabIndex = 61
        '
        'cbx_FiltroII
        '
        Me.cbx_FiltroII.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbx_FiltroII.FormattingEnabled = True
        Me.cbx_FiltroII.Items.AddRange(New Object() {"", "Planta", "Fecha", "Proveedor", "Origen", "Incoterms", "Transporte", "F.LLegada", "T.Pago", "Pago Despacho", "Pago Letra", "Vto. Letra"})
        Me.cbx_FiltroII.Location = New System.Drawing.Point(653, 74)
        Me.cbx_FiltroII.Margin = New System.Windows.Forms.Padding(4)
        Me.cbx_FiltroII.Name = "cbx_FiltroII"
        Me.cbx_FiltroII.Size = New System.Drawing.Size(160, 24)
        Me.cbx_FiltroII.TabIndex = 60
        '
        'cbx_FiltroI
        '
        Me.cbx_FiltroI.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbx_FiltroI.FormattingEnabled = True
        Me.cbx_FiltroI.Items.AddRange(New Object() {"", "Orden", "Planta", "Fecha", "Proveedor", "Carpeta", "DJai", "Origen", "Incoterms", "Transporte", "F.LLegada", "T.Pago", "Pago Despacho", "Pago Letra", "Vto. Letra", "M.Prima"})
        Me.cbx_FiltroI.Location = New System.Drawing.Point(484, 73)
        Me.cbx_FiltroI.Margin = New System.Windows.Forms.Padding(4)
        Me.cbx_FiltroI.Name = "cbx_FiltroI"
        Me.cbx_FiltroI.Size = New System.Drawing.Size(160, 24)
        Me.cbx_FiltroI.TabIndex = 59
        '
        'btn_Actualiza
        '
        Me.btn_Actualiza.Location = New System.Drawing.Point(1171, 109)
        Me.btn_Actualiza.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_Actualiza.Name = "btn_Actualiza"
        Me.btn_Actualiza.Size = New System.Drawing.Size(100, 28)
        Me.btn_Actualiza.TabIndex = 58
        Me.btn_Actualiza.Text = "ACTUALIZA"
        Me.btn_Actualiza.UseVisualStyleBackColor = True
        '
        'btn_Djai
        '
        Me.btn_Djai.Location = New System.Drawing.Point(8, 109)
        Me.btn_Djai.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_Djai.Name = "btn_Djai"
        Me.btn_Djai.Size = New System.Drawing.Size(135, 28)
        Me.btn_Djai.TabIndex = 57
        Me.btn_Djai.Text = "TXT DJAI"
        Me.btn_Djai.UseVisualStyleBackColor = True
        '
        'btn_Exportacion
        '
        Me.btn_Exportacion.Location = New System.Drawing.Point(8, 73)
        Me.btn_Exportacion.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_Exportacion.Name = "btn_Exportacion"
        Me.btn_Exportacion.Size = New System.Drawing.Size(135, 28)
        Me.btn_Exportacion.TabIndex = 56
        Me.btn_Exportacion.Text = "EXPORTACION"
        Me.btn_Exportacion.UseVisualStyleBackColor = True
        '
        'panel1
        '
        Me.panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(34, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.panel1.Controls.Add(Me.Label2)
        Me.panel1.Controls.Add(Me.label1)
        Me.panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.panel1.Location = New System.Drawing.Point(0, 0)
        Me.panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.panel1.Name = "panel1"
        Me.panel1.Size = New System.Drawing.Size(1580, 62)
        Me.panel1.TabIndex = 73
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(1373, 37)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(192, 25)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "SURFACTAN S.A."
        '
        'label1
        '
        Me.label1.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.label1.AutoSize = True
        Me.label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold)
        Me.label1.ForeColor = System.Drawing.Color.White
        Me.label1.Location = New System.Drawing.Point(4, 7)
        Me.label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(215, 20)
        Me.label1.TabIndex = 0
        Me.label1.Text = "Centro de Importaciones"
        '
        'Orden
        '
        Me.Orden.DataPropertyName = "Orden"
        Me.Orden.HeaderText = "Orden"
        Me.Orden.Name = "Orden"
        Me.Orden.ReadOnly = True
        Me.Orden.Width = 60
        '
        'Pta
        '
        Me.Pta.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Pta.DataPropertyName = "Pta"
        Me.Pta.HeaderText = "Pta"
        Me.Pta.Name = "Pta"
        Me.Pta.ReadOnly = True
        Me.Pta.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Pta.Width = 58
        '
        'Fecha
        '
        Me.Fecha.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Fecha.DataPropertyName = "Fecha"
        Me.Fecha.HeaderText = "Fecha"
        Me.Fecha.Name = "Fecha"
        Me.Fecha.ReadOnly = True
        Me.Fecha.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Fecha.Width = 76
        '
        'Proveedor
        '
        Me.Proveedor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Proveedor.DataPropertyName = "Proveedor"
        Me.Proveedor.HeaderText = "Proveedor"
        Me.Proveedor.Name = "Proveedor"
        Me.Proveedor.ReadOnly = True
        Me.Proveedor.Width = 103
        '
        'Mon
        '
        Me.Mon.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Mon.DataPropertyName = "Mon"
        Me.Mon.HeaderText = "Mon"
        Me.Mon.Name = "Mon"
        Me.Mon.ReadOnly = True
        Me.Mon.Width = 64
        '
        'Carpeta
        '
        Me.Carpeta.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Carpeta.DataPropertyName = "Carpeta"
        Me.Carpeta.HeaderText = "Carpeta"
        Me.Carpeta.Name = "Carpeta"
        Me.Carpeta.ReadOnly = True
        Me.Carpeta.Width = 87
        '
        'DJai
        '
        Me.DJai.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DJai.DataPropertyName = "DJai"
        Me.DJai.HeaderText = "DJai"
        Me.DJai.Name = "DJai"
        Me.DJai.ReadOnly = True
        Me.DJai.Width = 65
        '
        'Origen
        '
        Me.Origen.DataPropertyName = "Origen"
        Me.Origen.HeaderText = "Origen"
        Me.Origen.Name = "Origen"
        Me.Origen.ReadOnly = True
        Me.Origen.Width = 80
        '
        'Incoterms
        '
        Me.Incoterms.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Incoterms.DataPropertyName = "Incoterms"
        Me.Incoterms.HeaderText = "Incoterms"
        Me.Incoterms.Name = "Incoterms"
        Me.Incoterms.ReadOnly = True
        Me.Incoterms.Width = 98
        '
        'Transporte
        '
        Me.Transporte.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Transporte.DataPropertyName = "Transporte"
        Me.Transporte.HeaderText = "Transporte"
        Me.Transporte.Name = "Transporte"
        Me.Transporte.ReadOnly = True
        Me.Transporte.Width = 107
        '
        'FLLegada
        '
        Me.FLLegada.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.FLLegada.DataPropertyName = "FLLegada"
        Me.FLLegada.HeaderText = "F.LLegada"
        Me.FLLegada.Name = "FLLegada"
        Me.FLLegada.ReadOnly = True
        Me.FLLegada.Width = 105
        '
        'TPago
        '
        Me.TPago.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.TPago.HeaderText = "T.Pago"
        Me.TPago.Name = "TPago"
        Me.TPago.ReadOnly = True
        Me.TPago.Width = 83
        '
        'Despacho
        '
        Me.Despacho.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Despacho.DataPropertyName = "Despacho"
        Me.Despacho.HeaderText = "Despacho"
        Me.Despacho.Name = "Despacho"
        Me.Despacho.ReadOnly = True
        Me.Despacho.Width = 101
        '
        'PagoDes
        '
        Me.PagoDes.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.PagoDes.DataPropertyName = "PagoDes"
        Me.PagoDes.HeaderText = "Pago Des"
        Me.PagoDes.Name = "PagoDes"
        Me.PagoDes.ReadOnly = True
        Me.PagoDes.Width = 99
        '
        'LetraTotal
        '
        Me.LetraTotal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.LetraTotal.DataPropertyName = "LetraTotal"
        Me.LetraTotal.HeaderText = "Letra Total"
        Me.LetraTotal.Name = "LetraTotal"
        Me.LetraTotal.ReadOnly = True
        Me.LetraTotal.Width = 106
        '
        'PagoLetra
        '
        Me.PagoLetra.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.PagoLetra.DataPropertyName = "PagoLetra"
        Me.PagoLetra.HeaderText = "Pago Letra"
        Me.PagoLetra.Name = "PagoLetra"
        Me.PagoLetra.ReadOnly = True
        Me.PagoLetra.Width = 107
        '
        'VtoLetra
        '
        Me.VtoLetra.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.VtoLetra.DataPropertyName = "VtoLetra"
        Me.VtoLetra.HeaderText = "Vto Letra"
        Me.VtoLetra.Name = "VtoLetra"
        Me.VtoLetra.ReadOnly = True
        Me.VtoLetra.Width = 95
        '
        'USPagadoLetra
        '
        Me.USPagadoLetra.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.USPagadoLetra.DataPropertyName = "USPagadoLetra"
        Me.USPagadoLetra.HeaderText = "U$S Pagado Letra"
        Me.USPagadoLetra.Name = "USPagadoLetra"
        Me.USPagadoLetra.ReadOnly = True
        Me.USPagadoLetra.Width = 141
        '
        'FEmbarque
        '
        Me.FEmbarque.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.FEmbarque.DataPropertyName = "FEmbarque"
        Me.FEmbarque.HeaderText = "F.Embarque"
        Me.FEmbarque.Name = "FEmbarque"
        Me.FEmbarque.ReadOnly = True
        Me.FEmbarque.Width = 114
        '
        'SaldoLetra
        '
        Me.SaldoLetra.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.SaldoLetra.DataPropertyName = "SaldoLetra"
        Me.SaldoLetra.HeaderText = "Saldo Letra"
        Me.SaldoLetra.Name = "SaldoLetra"
        Me.SaldoLetra.ReadOnly = True
        Me.SaldoLetra.Width = 101
        '
        'ProveedorCod
        '
        Me.ProveedorCod.DataPropertyName = "ProveedorCod"
        Me.ProveedorCod.HeaderText = "ProveedorCod"
        Me.ProveedorCod.Name = "ProveedorCod"
        Me.ProveedorCod.ReadOnly = True
        Me.ProveedorCod.Visible = False
        '
        'txt_Filtro
        '
        Me.txt_Filtro.Location = New System.Drawing.Point(277, 72)
        Me.txt_Filtro.Name = "txt_Filtro"
        Me.txt_Filtro.Size = New System.Drawing.Size(100, 22)
        Me.txt_Filtro.TabIndex = 74
        '
        'Centro_Importaciones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1580, 925)
        Me.Controls.Add(Me.txt_Filtro)
        Me.Controls.Add(Me.panel1)
        Me.Controls.Add(Me.DGV_Muestra)
        Me.Controls.Add(Me.lbl_ArticuloKg)
        Me.Controls.Add(Me.txt_Articulo)
        Me.Controls.Add(Me.lbl_Articulo)
        Me.Controls.Add(Me.txt_SumaLetra)
        Me.Controls.Add(Me.txt_SumaDespacho)
        Me.Controls.Add(Me.chk_LetraPendiente)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cbx_Activas)
        Me.Controls.Add(Me.cbx_FiltroIII)
        Me.Controls.Add(Me.cbx_FiltroII)
        Me.Controls.Add(Me.cbx_FiltroI)
        Me.Controls.Add(Me.btn_Actualiza)
        Me.Controls.Add(Me.btn_Djai)
        Me.Controls.Add(Me.btn_Exportacion)
        Me.Name = "Centro_Importaciones"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.DGV_Muestra, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panel1.ResumeLayout(False)
        Me.panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DGV_Muestra As Util.DBDataGridView
    Friend WithEvents lbl_ArticuloKg As System.Windows.Forms.Label
    Friend WithEvents txt_Articulo As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Articulo As System.Windows.Forms.Label
    Friend WithEvents txt_SumaLetra As System.Windows.Forms.TextBox
    Friend WithEvents txt_SumaDespacho As System.Windows.Forms.TextBox
    Friend WithEvents chk_LetraPendiente As System.Windows.Forms.CheckBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cbx_Activas As System.Windows.Forms.ComboBox
    Friend WithEvents cbx_FiltroIII As System.Windows.Forms.ComboBox
    Friend WithEvents cbx_FiltroII As System.Windows.Forms.ComboBox
    Friend WithEvents cbx_FiltroI As System.Windows.Forms.ComboBox
    Friend WithEvents btn_Actualiza As System.Windows.Forms.Button
    Friend WithEvents btn_Djai As System.Windows.Forms.Button
    Friend WithEvents btn_Exportacion As System.Windows.Forms.Button
    Private WithEvents panel1 As System.Windows.Forms.Panel
    Private WithEvents Label2 As System.Windows.Forms.Label
    Private WithEvents label1 As System.Windows.Forms.Label
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
    Friend WithEvents txt_Filtro As System.Windows.Forms.TextBox

End Class
