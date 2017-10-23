<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Proforma
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
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.LayoutPrincipal = New System.Windows.Forms.TableLayoutPanel()
        Me.LayoutCabecera = New System.Windows.Forms.TableLayoutPanel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.LayoutCuerpoPrincipal = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GrupoConsulta = New System.Windows.Forms.GroupBox()
        Me.txtAyuda = New System.Windows.Forms.TextBox()
        Me.lstOpcionesConsulta = New System.Windows.Forms.ListBox()
        Me.lstFiltrada = New System.Windows.Forms.ListBox()
        Me.lstConsulta = New System.Windows.Forms.ListBox()
        Me.btnCerrarConsulta = New System.Windows.Forms.Button()
        Me.cmbVia = New System.Windows.Forms.ComboBox()
        Me.btnHistorialArchivosRelacionados = New System.Windows.Forms.Button()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtObservacionesIII = New System.Windows.Forms.TextBox()
        Me.txtObservacionesII = New System.Windows.Forms.TextBox()
        Me.txtObservaciones = New System.Windows.Forms.TextBox()
        Me.txtFechaAux = New System.Windows.Forms.MaskedTextBox()
        Me.dgvProductos = New System.Windows.Forms.DataGridView()
        Me.Producto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cantidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Precio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Total = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cmbEstado = New System.Windows.Forms.ComboBox()
        Me.cmbCondicion = New System.Windows.Forms.ComboBox()
        Me.txtFecha = New System.Windows.Forms.MaskedTextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtTotal = New System.Windows.Forms.TextBox()
        Me.txtSeguro = New System.Windows.Forms.TextBox()
        Me.txtFlete = New System.Windows.Forms.TextBox()
        Me.txtSubTotal = New System.Windows.Forms.TextBox()
        Me.txtDescripcionCliente = New System.Windows.Forms.TextBox()
        Me.txtCliente = New System.Windows.Forms.TextBox()
        Me.txtDescripcionTotalII = New System.Windows.Forms.TextBox()
        Me.txtDescripcionTotal = New System.Windows.Forms.TextBox()
        Me.txtPais = New System.Windows.Forms.TextBox()
        Me.txtCondicionPagoII = New System.Windows.Forms.TextBox()
        Me.txtCondicionPago = New System.Windows.Forms.TextBox()
        Me.txtViaII = New System.Windows.Forms.TextBox()
        Me.txtVia = New System.Windows.Forms.TextBox()
        Me.txtOCCliente = New System.Windows.Forms.TextBox()
        Me.txtLocalidadCliente = New System.Windows.Forms.TextBox()
        Me.txtDireccionCliente = New System.Windows.Forms.TextBox()
        Me.txtNroProforma = New System.Windows.Forms.TextBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.btnConsulta = New System.Windows.Forms.Button()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.btnVistaPrevia = New System.Windows.Forms.Button()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.LayoutPrincipal.SuspendLayout()
        Me.LayoutCabecera.SuspendLayout()
        Me.LayoutCuerpoPrincipal.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GrupoConsulta.SuspendLayout()
        CType(Me.dgvProductos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'LayoutPrincipal
        '
        Me.LayoutPrincipal.BackColor = System.Drawing.SystemColors.Control
        Me.LayoutPrincipal.ColumnCount = 1
        Me.LayoutPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.LayoutPrincipal.Controls.Add(Me.LayoutCabecera, 0, 0)
        Me.LayoutPrincipal.Controls.Add(Me.LayoutCuerpoPrincipal, 0, 1)
        Me.LayoutPrincipal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutPrincipal.Location = New System.Drawing.Point(0, 0)
        Me.LayoutPrincipal.Margin = New System.Windows.Forms.Padding(0)
        Me.LayoutPrincipal.Name = "LayoutPrincipal"
        Me.LayoutPrincipal.RowCount = 2
        Me.LayoutPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45.0!))
        Me.LayoutPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.LayoutPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.LayoutPrincipal.Size = New System.Drawing.Size(852, 623)
        Me.LayoutPrincipal.TabIndex = 1
        '
        'LayoutCabecera
        '
        Me.LayoutCabecera.BackColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.LayoutCabecera.ColumnCount = 3
        Me.LayoutCabecera.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 241.0!))
        Me.LayoutCabecera.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.LayoutCabecera.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 180.0!))
        Me.LayoutCabecera.Controls.Add(Me.Label3, 0, 0)
        Me.LayoutCabecera.Controls.Add(Me.Label1, 0, 0)
        Me.LayoutCabecera.Controls.Add(Me.Label2, 2, 0)
        Me.LayoutCabecera.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutCabecera.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold)
        Me.LayoutCabecera.ForeColor = System.Drawing.SystemColors.Control
        Me.LayoutCabecera.Location = New System.Drawing.Point(0, 0)
        Me.LayoutCabecera.Margin = New System.Windows.Forms.Padding(0)
        Me.LayoutCabecera.Name = "LayoutCabecera"
        Me.LayoutCabecera.RowCount = 1
        Me.LayoutCabecera.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.LayoutCabecera.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45.0!))
        Me.LayoutCabecera.Size = New System.Drawing.Size(852, 45)
        Me.LayoutCabecera.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label3.Font = New System.Drawing.Font("Calibri", 14.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.Location = New System.Drawing.Point(241, 0)
        Me.Label3.Margin = New System.Windows.Forms.Padding(0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(431, 45)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "- Proformas -"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Font = New System.Drawing.Font("Calibri", 14.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Margin = New System.Windows.Forms.Padding(0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(241, 45)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Sistema de Exportaciones"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label2.Font = New System.Drawing.Font("Calibri", 16.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(675, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(174, 45)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "SURFACTAN S.A."
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LayoutCuerpoPrincipal
        '
        Me.LayoutCuerpoPrincipal.ColumnCount = 1
        Me.LayoutCuerpoPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.LayoutCuerpoPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.LayoutCuerpoPrincipal.Controls.Add(Me.Panel1, 0, 0)
        Me.LayoutCuerpoPrincipal.Controls.Add(Me.Panel2, 0, 1)
        Me.LayoutCuerpoPrincipal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutCuerpoPrincipal.Location = New System.Drawing.Point(0, 45)
        Me.LayoutCuerpoPrincipal.Margin = New System.Windows.Forms.Padding(0)
        Me.LayoutCuerpoPrincipal.Name = "LayoutCuerpoPrincipal"
        Me.LayoutCuerpoPrincipal.RowCount = 2
        Me.LayoutCuerpoPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.LayoutCuerpoPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 69.0!))
        Me.LayoutCuerpoPrincipal.Size = New System.Drawing.Size(852, 578)
        Me.LayoutCuerpoPrincipal.TabIndex = 1
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(95, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(82, Byte), Integer))
        Me.Panel1.Controls.Add(Me.GrupoConsulta)
        Me.Panel1.Controls.Add(Me.cmbVia)
        Me.Panel1.Controls.Add(Me.btnHistorialArchivosRelacionados)
        Me.Panel1.Controls.Add(Me.Label15)
        Me.Panel1.Controls.Add(Me.txtObservacionesIII)
        Me.Panel1.Controls.Add(Me.txtObservacionesII)
        Me.Panel1.Controls.Add(Me.txtObservaciones)
        Me.Panel1.Controls.Add(Me.txtFechaAux)
        Me.Panel1.Controls.Add(Me.dgvProductos)
        Me.Panel1.Controls.Add(Me.cmbEstado)
        Me.Panel1.Controls.Add(Me.cmbCondicion)
        Me.Panel1.Controls.Add(Me.txtFecha)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.Label16)
        Me.Panel1.Controls.Add(Me.Label20)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Controls.Add(Me.Label19)
        Me.Panel1.Controls.Add(Me.Label18)
        Me.Panel1.Controls.Add(Me.Label17)
        Me.Panel1.Controls.Add(Me.Label13)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.Label14)
        Me.Panel1.Controls.Add(Me.Label12)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.txtTotal)
        Me.Panel1.Controls.Add(Me.txtSeguro)
        Me.Panel1.Controls.Add(Me.txtFlete)
        Me.Panel1.Controls.Add(Me.txtSubTotal)
        Me.Panel1.Controls.Add(Me.txtDescripcionCliente)
        Me.Panel1.Controls.Add(Me.txtCliente)
        Me.Panel1.Controls.Add(Me.txtDescripcionTotalII)
        Me.Panel1.Controls.Add(Me.txtDescripcionTotal)
        Me.Panel1.Controls.Add(Me.txtPais)
        Me.Panel1.Controls.Add(Me.txtCondicionPagoII)
        Me.Panel1.Controls.Add(Me.txtCondicionPago)
        Me.Panel1.Controls.Add(Me.txtViaII)
        Me.Panel1.Controls.Add(Me.txtVia)
        Me.Panel1.Controls.Add(Me.txtOCCliente)
        Me.Panel1.Controls.Add(Me.txtLocalidadCliente)
        Me.Panel1.Controls.Add(Me.txtDireccionCliente)
        Me.Panel1.Controls.Add(Me.txtNroProforma)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(852, 509)
        Me.Panel1.TabIndex = 2
        '
        'GrupoConsulta
        '
        Me.GrupoConsulta.Controls.Add(Me.txtAyuda)
        Me.GrupoConsulta.Controls.Add(Me.lstOpcionesConsulta)
        Me.GrupoConsulta.Controls.Add(Me.lstFiltrada)
        Me.GrupoConsulta.Controls.Add(Me.lstConsulta)
        Me.GrupoConsulta.Controls.Add(Me.btnCerrarConsulta)
        Me.GrupoConsulta.Location = New System.Drawing.Point(194, 177)
        Me.GrupoConsulta.Name = "GrupoConsulta"
        Me.GrupoConsulta.Size = New System.Drawing.Size(373, 321)
        Me.GrupoConsulta.TabIndex = 12
        Me.GrupoConsulta.TabStop = False
        Me.GrupoConsulta.Visible = False
        '
        'txtAyuda
        '
        Me.txtAyuda.Location = New System.Drawing.Point(15, 16)
        Me.txtAyuda.Name = "txtAyuda"
        Me.txtAyuda.Size = New System.Drawing.Size(342, 20)
        Me.txtAyuda.TabIndex = 4
        Me.txtAyuda.Visible = False
        '
        'lstOpcionesConsulta
        '
        Me.lstOpcionesConsulta.FormattingEnabled = True
        Me.lstOpcionesConsulta.Items.AddRange(New Object() {"Clientes", "Productos Terminados"})
        Me.lstOpcionesConsulta.Location = New System.Drawing.Point(15, 42)
        Me.lstOpcionesConsulta.Name = "lstOpcionesConsulta"
        Me.lstOpcionesConsulta.Size = New System.Drawing.Size(342, 225)
        Me.lstOpcionesConsulta.TabIndex = 0
        '
        'lstFiltrada
        '
        Me.lstFiltrada.FormattingEnabled = True
        Me.lstFiltrada.Location = New System.Drawing.Point(15, 42)
        Me.lstFiltrada.Name = "lstFiltrada"
        Me.lstFiltrada.Size = New System.Drawing.Size(342, 225)
        Me.lstFiltrada.TabIndex = 3
        Me.lstFiltrada.Visible = False
        '
        'lstConsulta
        '
        Me.lstConsulta.FormattingEnabled = True
        Me.lstConsulta.Location = New System.Drawing.Point(15, 42)
        Me.lstConsulta.Name = "lstConsulta"
        Me.lstConsulta.Size = New System.Drawing.Size(342, 225)
        Me.lstConsulta.TabIndex = 2
        '
        'btnCerrarConsulta
        '
        Me.btnCerrarConsulta.Location = New System.Drawing.Point(146, 272)
        Me.btnCerrarConsulta.Name = "btnCerrarConsulta"
        Me.btnCerrarConsulta.Size = New System.Drawing.Size(102, 40)
        Me.btnCerrarConsulta.TabIndex = 1
        Me.btnCerrarConsulta.Text = "Cerrar Consulta"
        Me.ToolTip1.SetToolTip(Me.btnCerrarConsulta, "Cerrar Ventana de Consulta")
        Me.btnCerrarConsulta.UseVisualStyleBackColor = True
        '
        'cmbVia
        '
        Me.cmbVia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbVia.FormattingEnabled = True
        Me.cmbVia.Items.AddRange(New Object() {"", "VIA TERRESTRE", "VIA AEREA", "VIA MARITIMA"})
        Me.cmbVia.Location = New System.Drawing.Point(493, 67)
        Me.cmbVia.Name = "cmbVia"
        Me.cmbVia.Size = New System.Drawing.Size(105, 21)
        Me.cmbVia.TabIndex = 14
        '
        'btnHistorialArchivosRelacionados
        '
        Me.btnHistorialArchivosRelacionados.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnHistorialArchivosRelacionados.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnHistorialArchivosRelacionados.ForeColor = System.Drawing.SystemColors.Control
        Me.btnHistorialArchivosRelacionados.Location = New System.Drawing.Point(662, 460)
        Me.btnHistorialArchivosRelacionados.Name = "btnHistorialArchivosRelacionados"
        Me.btnHistorialArchivosRelacionados.Size = New System.Drawing.Size(174, 38)
        Me.btnHistorialArchivosRelacionados.TabIndex = 13
        Me.btnHistorialArchivosRelacionados.Text = "Ver Historial y Archivos Relacionados"
        Me.btnHistorialArchivosRelacionados.UseVisualStyleBackColor = True
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label15.ForeColor = System.Drawing.SystemColors.Control
        Me.Label15.Location = New System.Drawing.Point(17, 119)
        Me.Label15.Margin = New System.Windows.Forms.Padding(0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(103, 18)
        Me.Label15.TabIndex = 11
        Me.Label15.Text = "Observaciones:"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtObservacionesIII
        '
        Me.txtObservacionesIII.Location = New System.Drawing.Point(133, 168)
        Me.txtObservacionesIII.MaxLength = 100
        Me.txtObservacionesIII.Name = "txtObservacionesIII"
        Me.txtObservacionesIII.Size = New System.Drawing.Size(624, 20)
        Me.txtObservacionesIII.TabIndex = 10
        '
        'txtObservacionesII
        '
        Me.txtObservacionesII.Location = New System.Drawing.Point(133, 143)
        Me.txtObservacionesII.MaxLength = 100
        Me.txtObservacionesII.Name = "txtObservacionesII"
        Me.txtObservacionesII.Size = New System.Drawing.Size(624, 20)
        Me.txtObservacionesII.TabIndex = 10
        '
        'txtObservaciones
        '
        Me.txtObservaciones.Location = New System.Drawing.Point(133, 118)
        Me.txtObservaciones.MaxLength = 100
        Me.txtObservaciones.Name = "txtObservaciones"
        Me.txtObservaciones.Size = New System.Drawing.Size(624, 20)
        Me.txtObservaciones.TabIndex = 10
        Me.ToolTip1.SetToolTip(Me.txtObservaciones, "Máximo 100 caracteres")
        '
        'txtFechaAux
        '
        Me.txtFechaAux.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtFechaAux.Location = New System.Drawing.Point(87, 228)
        Me.txtFechaAux.Mask = "LL-00000-000"
        Me.txtFechaAux.Name = "txtFechaAux"
        Me.txtFechaAux.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtFechaAux.Size = New System.Drawing.Size(79, 13)
        Me.txtFechaAux.TabIndex = 9
        Me.txtFechaAux.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtFechaAux.Visible = False
        '
        'dgvProductos
        '
        Me.dgvProductos.AllowUserToAddRows = False
        Me.dgvProductos.AllowUserToDeleteRows = False
        Me.dgvProductos.AllowUserToOrderColumns = True
        Me.dgvProductos.AllowUserToResizeRows = False
        Me.dgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvProductos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Producto, Me.Descripcion, Me.Cantidad, Me.Precio, Me.Total})
        Me.dgvProductos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.dgvProductos.Location = New System.Drawing.Point(16, 201)
        Me.dgvProductos.Name = "dgvProductos"
        Me.dgvProductos.Size = New System.Drawing.Size(820, 161)
        Me.dgvProductos.TabIndex = 8
        '
        'Producto
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Producto.DefaultCellStyle = DataGridViewCellStyle6
        Me.Producto.HeaderText = "Producto"
        Me.Producto.MaxInputLength = 12
        Me.Producto.Name = "Producto"
        Me.Producto.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Descripcion
        '
        Me.Descripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.Descripcion.DefaultCellStyle = DataGridViewCellStyle7
        Me.Descripcion.HeaderText = "Descripcion"
        Me.Descripcion.Name = "Descripcion"
        Me.Descripcion.ReadOnly = True
        Me.Descripcion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Cantidad
        '
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Cantidad.DefaultCellStyle = DataGridViewCellStyle8
        Me.Cantidad.HeaderText = "Cantidad"
        Me.Cantidad.Name = "Cantidad"
        Me.Cantidad.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Precio
        '
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Precio.DefaultCellStyle = DataGridViewCellStyle9
        Me.Precio.HeaderText = "Precio"
        Me.Precio.Name = "Precio"
        Me.Precio.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Total
        '
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Total.DefaultCellStyle = DataGridViewCellStyle10
        Me.Total.HeaderText = "Total"
        Me.Total.Name = "Total"
        Me.Total.ReadOnly = True
        Me.Total.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'cmbEstado
        '
        Me.cmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEstado.FormattingEnabled = True
        Me.cmbEstado.Items.AddRange(New Object() {"", "APROBADA"})
        Me.cmbEstado.Location = New System.Drawing.Point(665, 67)
        Me.cmbEstado.Name = "cmbEstado"
        Me.cmbEstado.Size = New System.Drawing.Size(93, 21)
        Me.cmbEstado.TabIndex = 7
        '
        'cmbCondicion
        '
        Me.cmbCondicion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCondicion.FormattingEnabled = True
        Me.cmbCondicion.Items.AddRange(New Object() {"", "FOB", "CIF", "CFR", "CPT", "EXW", "FCA"})
        Me.cmbCondicion.Location = New System.Drawing.Point(390, 92)
        Me.cmbCondicion.Name = "cmbCondicion"
        Me.cmbCondicion.Size = New System.Drawing.Size(65, 21)
        Me.cmbCondicion.TabIndex = 7
        '
        'txtFecha
        '
        Me.txtFecha.Location = New System.Drawing.Point(258, 17)
        Me.txtFecha.Mask = "00/00/0000"
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtFecha.Size = New System.Drawing.Size(72, 20)
        Me.txtFecha.TabIndex = 6
        Me.txtFecha.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label5.ForeColor = System.Drawing.SystemColors.Control
        Me.Label5.Location = New System.Drawing.Point(199, 18)
        Me.Label5.Margin = New System.Windows.Forms.Padding(0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(48, 18)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Fecha:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label6.ForeColor = System.Drawing.SystemColors.Control
        Me.Label6.Location = New System.Drawing.Point(349, 17)
        Me.Label6.Margin = New System.Windows.Forms.Padding(0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(57, 18)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "Cliente:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label8.ForeColor = System.Drawing.SystemColors.Control
        Me.Label8.Location = New System.Drawing.Point(413, 43)
        Me.Label8.Margin = New System.Windows.Forms.Padding(0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(70, 18)
        Me.Label8.TabIndex = 3
        Me.Label8.Text = "Localidad:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label16.ForeColor = System.Drawing.SystemColors.Control
        Me.Label16.Location = New System.Drawing.Point(630, 42)
        Me.Label16.Margin = New System.Windows.Forms.Padding(0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(37, 18)
        Me.Label16.TabIndex = 3
        Me.Label16.Text = "Pais:"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label20.ForeColor = System.Drawing.SystemColors.Control
        Me.Label20.Location = New System.Drawing.Point(604, 68)
        Me.Label20.Margin = New System.Windows.Forms.Padding(0)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(53, 18)
        Me.Label20.TabIndex = 3
        Me.Label20.Text = "Estado:"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label11.ForeColor = System.Drawing.SystemColors.Control
        Me.Label11.Location = New System.Drawing.Point(459, 68)
        Me.Label11.Margin = New System.Windows.Forms.Padding(0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(32, 18)
        Me.Label11.TabIndex = 3
        Me.Label11.Text = "Via:"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label19.ForeColor = System.Drawing.SystemColors.Control
        Me.Label19.Location = New System.Drawing.Point(682, 433)
        Me.Label19.Margin = New System.Windows.Forms.Padding(0)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(42, 18)
        Me.Label19.TabIndex = 3
        Me.Label19.Text = "Total:"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label18.ForeColor = System.Drawing.SystemColors.Control
        Me.Label18.Location = New System.Drawing.Point(669, 411)
        Me.Label18.Margin = New System.Windows.Forms.Padding(0)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(55, 18)
        Me.Label18.TabIndex = 3
        Me.Label18.Text = "Seguro:"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label17.ForeColor = System.Drawing.SystemColors.Control
        Me.Label17.Location = New System.Drawing.Point(680, 389)
        Me.Label17.Margin = New System.Windows.Forms.Padding(0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(44, 18)
        Me.Label17.TabIndex = 3
        Me.Label17.Text = "Flete:"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label13.ForeColor = System.Drawing.SystemColors.Control
        Me.Label13.Location = New System.Drawing.Point(659, 367)
        Me.Label13.Margin = New System.Windows.Forms.Padding(0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(65, 18)
        Me.Label13.TabIndex = 3
        Me.Label13.Text = "SubTotal:"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label10.ForeColor = System.Drawing.SystemColors.Control
        Me.Label10.Location = New System.Drawing.Point(313, 93)
        Me.Label10.Margin = New System.Windows.Forms.Padding(0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(74, 18)
        Me.Label10.TabIndex = 3
        Me.Label10.Text = "Condición:"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label14.ForeColor = System.Drawing.SystemColors.Control
        Me.Label14.Location = New System.Drawing.Point(172, 368)
        Me.Label14.Margin = New System.Windows.Forms.Padding(0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(54, 18)
        Me.Label14.TabIndex = 3
        Me.Label14.Text = "Monto:"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label12.ForeColor = System.Drawing.SystemColors.Control
        Me.Label12.Location = New System.Drawing.Point(17, 68)
        Me.Label12.Margin = New System.Windows.Forms.Padding(0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(81, 18)
        Me.Label12.TabIndex = 3
        Me.Label12.Text = "Cond. Pago:"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label9.ForeColor = System.Drawing.SystemColors.Control
        Me.Label9.Location = New System.Drawing.Point(356, 68)
        Me.Label9.Margin = New System.Windows.Forms.Padding(0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(30, 18)
        Me.Label9.TabIndex = 3
        Me.Label9.Text = "OC:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label7.ForeColor = System.Drawing.SystemColors.Control
        Me.Label7.Location = New System.Drawing.Point(17, 43)
        Me.Label7.Margin = New System.Windows.Forms.Padding(0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(70, 18)
        Me.Label7.TabIndex = 3
        Me.Label7.Text = "Dirección:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label4.ForeColor = System.Drawing.SystemColors.Control
        Me.Label4.Location = New System.Drawing.Point(17, 18)
        Me.Label4.Margin = New System.Windows.Forms.Padding(0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(70, 18)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Proforma:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTotal
        '
        Me.txtTotal.BackColor = System.Drawing.SystemColors.Window
        Me.txtTotal.Location = New System.Drawing.Point(726, 432)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.ReadOnly = True
        Me.txtTotal.Size = New System.Drawing.Size(105, 20)
        Me.txtTotal.TabIndex = 0
        Me.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSeguro
        '
        Me.txtSeguro.BackColor = System.Drawing.SystemColors.Window
        Me.txtSeguro.Location = New System.Drawing.Point(726, 410)
        Me.txtSeguro.Name = "txtSeguro"
        Me.txtSeguro.Size = New System.Drawing.Size(105, 20)
        Me.txtSeguro.TabIndex = 0
        Me.txtSeguro.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtFlete
        '
        Me.txtFlete.BackColor = System.Drawing.SystemColors.Window
        Me.txtFlete.Location = New System.Drawing.Point(726, 388)
        Me.txtFlete.Name = "txtFlete"
        Me.txtFlete.Size = New System.Drawing.Size(105, 20)
        Me.txtFlete.TabIndex = 0
        Me.txtFlete.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSubTotal
        '
        Me.txtSubTotal.BackColor = System.Drawing.SystemColors.Window
        Me.txtSubTotal.Location = New System.Drawing.Point(726, 366)
        Me.txtSubTotal.Name = "txtSubTotal"
        Me.txtSubTotal.ReadOnly = True
        Me.txtSubTotal.Size = New System.Drawing.Size(105, 20)
        Me.txtSubTotal.TabIndex = 0
        Me.txtSubTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.txtSubTotal, "Total")
        '
        'txtDescripcionCliente
        '
        Me.txtDescripcionCliente.Enabled = False
        Me.txtDescripcionCliente.Location = New System.Drawing.Point(492, 16)
        Me.txtDescripcionCliente.Name = "txtDescripcionCliente"
        Me.txtDescripcionCliente.ReadOnly = True
        Me.txtDescripcionCliente.Size = New System.Drawing.Size(266, 20)
        Me.txtDescripcionCliente.TabIndex = 0
        '
        'txtCliente
        '
        Me.txtCliente.Location = New System.Drawing.Point(407, 16)
        Me.txtCliente.MaxLength = 6
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.Size = New System.Drawing.Size(79, 20)
        Me.txtCliente.TabIndex = 0
        '
        'txtDescripcionTotalII
        '
        Me.txtDescripcionTotalII.Location = New System.Drawing.Point(229, 390)
        Me.txtDescripcionTotalII.MaxLength = 50
        Me.txtDescripcionTotalII.Name = "txtDescripcionTotalII"
        Me.txtDescripcionTotalII.Size = New System.Drawing.Size(410, 20)
        Me.txtDescripcionTotalII.TabIndex = 0
        '
        'txtDescripcionTotal
        '
        Me.txtDescripcionTotal.Location = New System.Drawing.Point(229, 367)
        Me.txtDescripcionTotal.MaxLength = 50
        Me.txtDescripcionTotal.Name = "txtDescripcionTotal"
        Me.txtDescripcionTotal.Size = New System.Drawing.Size(410, 20)
        Me.txtDescripcionTotal.TabIndex = 0
        Me.ToolTip1.SetToolTip(Me.txtDescripcionTotal, "Descripción en Inglés del Monto Total")
        '
        'txtPais
        '
        Me.txtPais.Location = New System.Drawing.Point(665, 41)
        Me.txtPais.MaxLength = 15
        Me.txtPais.Name = "txtPais"
        Me.txtPais.Size = New System.Drawing.Size(93, 20)
        Me.txtPais.TabIndex = 0
        '
        'txtCondicionPagoII
        '
        Me.txtCondicionPagoII.Location = New System.Drawing.Point(97, 92)
        Me.txtCondicionPagoII.MaxLength = 50
        Me.txtCondicionPagoII.Name = "txtCondicionPagoII"
        Me.txtCondicionPagoII.Size = New System.Drawing.Size(211, 20)
        Me.txtCondicionPagoII.TabIndex = 0
        '
        'txtCondicionPago
        '
        Me.txtCondicionPago.Location = New System.Drawing.Point(97, 67)
        Me.txtCondicionPago.MaxLength = 50
        Me.txtCondicionPago.Name = "txtCondicionPago"
        Me.txtCondicionPago.Size = New System.Drawing.Size(211, 20)
        Me.txtCondicionPago.TabIndex = 0
        Me.ToolTip1.SetToolTip(Me.txtCondicionPago, "Condición de Pago")
        '
        'txtViaII
        '
        Me.txtViaII.Location = New System.Drawing.Point(20, 411)
        Me.txtViaII.MaxLength = 20
        Me.txtViaII.Name = "txtViaII"
        Me.txtViaII.Size = New System.Drawing.Size(54, 20)
        Me.txtViaII.TabIndex = 0
        '
        'txtVia
        '
        Me.txtVia.Location = New System.Drawing.Point(20, 437)
        Me.txtVia.MaxLength = 20
        Me.txtVia.Name = "txtVia"
        Me.txtVia.Size = New System.Drawing.Size(54, 20)
        Me.txtVia.TabIndex = 0
        Me.ToolTip1.SetToolTip(Me.txtVia, "Vía de Transporte")
        '
        'txtOCCliente
        '
        Me.txtOCCliente.Location = New System.Drawing.Point(390, 67)
        Me.txtOCCliente.MaxLength = 20
        Me.txtOCCliente.Name = "txtOCCliente"
        Me.txtOCCliente.Size = New System.Drawing.Size(65, 20)
        Me.txtOCCliente.TabIndex = 0
        Me.txtOCCliente.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.txtOCCliente, "Orden de Compra de Cliente")
        '
        'txtLocalidadCliente
        '
        Me.txtLocalidadCliente.BackColor = System.Drawing.SystemColors.Window
        Me.txtLocalidadCliente.Enabled = False
        Me.txtLocalidadCliente.Location = New System.Drawing.Point(492, 42)
        Me.txtLocalidadCliente.MaxLength = 50
        Me.txtLocalidadCliente.Name = "txtLocalidadCliente"
        Me.txtLocalidadCliente.ReadOnly = True
        Me.txtLocalidadCliente.Size = New System.Drawing.Size(131, 20)
        Me.txtLocalidadCliente.TabIndex = 0
        '
        'txtDireccionCliente
        '
        Me.txtDireccionCliente.BackColor = System.Drawing.SystemColors.Window
        Me.txtDireccionCliente.Enabled = False
        Me.txtDireccionCliente.Location = New System.Drawing.Point(97, 42)
        Me.txtDireccionCliente.MaxLength = 100
        Me.txtDireccionCliente.Name = "txtDireccionCliente"
        Me.txtDireccionCliente.ReadOnly = True
        Me.txtDireccionCliente.Size = New System.Drawing.Size(309, 20)
        Me.txtDireccionCliente.TabIndex = 0
        '
        'txtNroProforma
        '
        Me.txtNroProforma.Location = New System.Drawing.Point(97, 17)
        Me.txtNroProforma.MaxLength = 6
        Me.txtNroProforma.Name = "txtNroProforma"
        Me.txtNroProforma.Size = New System.Drawing.Size(79, 20)
        Me.txtNroProforma.TabIndex = 0
        Me.txtNroProforma.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.btnCerrar)
        Me.Panel2.Controls.Add(Me.btnConsulta)
        Me.Panel2.Controls.Add(Me.btnLimpiar)
        Me.Panel2.Controls.Add(Me.btnVistaPrevia)
        Me.Panel2.Controls.Add(Me.btnEliminar)
        Me.Panel2.Controls.Add(Me.btnAceptar)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(3, 512)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(846, 63)
        Me.Panel2.TabIndex = 3
        '
        'btnCerrar
        '
        Me.btnCerrar.Location = New System.Drawing.Point(599, 9)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(81, 45)
        Me.btnCerrar.TabIndex = 0
        Me.btnCerrar.Text = "Cerrar"
        Me.ToolTip1.SetToolTip(Me.btnCerrar, "Cerrar Formulario")
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'btnConsulta
        '
        Me.btnConsulta.Location = New System.Drawing.Point(191, 9)
        Me.btnConsulta.Name = "btnConsulta"
        Me.btnConsulta.Size = New System.Drawing.Size(81, 45)
        Me.btnConsulta.TabIndex = 0
        Me.btnConsulta.Text = "Consulta"
        Me.ToolTip1.SetToolTip(Me.btnConsulta, "Abrir Consultas")
        Me.btnConsulta.UseVisualStyleBackColor = True
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Location = New System.Drawing.Point(293, 8)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(81, 45)
        Me.btnLimpiar.TabIndex = 0
        Me.btnLimpiar.Text = "Limpiar"
        Me.ToolTip1.SetToolTip(Me.btnLimpiar, "Limpiar Formulario")
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'btnVistaPrevia
        '
        Me.btnVistaPrevia.Location = New System.Drawing.Point(395, 8)
        Me.btnVistaPrevia.Name = "btnVistaPrevia"
        Me.btnVistaPrevia.Size = New System.Drawing.Size(81, 45)
        Me.btnVistaPrevia.TabIndex = 0
        Me.btnVistaPrevia.Text = "Vista Previa"
        Me.ToolTip1.SetToolTip(Me.btnVistaPrevia, "Ver Proforma por Pantalla")
        Me.btnVistaPrevia.UseVisualStyleBackColor = True
        '
        'btnEliminar
        '
        Me.btnEliminar.Location = New System.Drawing.Point(497, 9)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(81, 45)
        Me.btnEliminar.TabIndex = 0
        Me.btnEliminar.Text = "Eliminar"
        Me.ToolTip1.SetToolTip(Me.btnEliminar, "Eliminar Proforma")
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(89, 9)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(81, 45)
        Me.btnAceptar.TabIndex = 0
        Me.btnAceptar.Text = "Aceptar"
        Me.ToolTip1.SetToolTip(Me.btnAceptar, "Grabar / Actualizar Proforma")
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'Proforma
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(852, 623)
        Me.Controls.Add(Me.LayoutPrincipal)
        Me.Name = "Proforma"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Proforma"
        Me.LayoutPrincipal.ResumeLayout(False)
        Me.LayoutCabecera.ResumeLayout(False)
        Me.LayoutCuerpoPrincipal.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GrupoConsulta.ResumeLayout(False)
        Me.GrupoConsulta.PerformLayout()
        CType(Me.dgvProductos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LayoutPrincipal As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents LayoutCabecera As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents LayoutCuerpoPrincipal As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtFecha As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtDescripcionCliente As System.Windows.Forms.TextBox
    Friend WithEvents txtCliente As System.Windows.Forms.TextBox
    Friend WithEvents txtNroProforma As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtLocalidadCliente As System.Windows.Forms.TextBox
    Friend WithEvents txtDireccionCliente As System.Windows.Forms.TextBox
    Friend WithEvents cmbCondicion As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtOCCliente As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtCondicionPago As System.Windows.Forms.TextBox
    Friend WithEvents txtVia As System.Windows.Forms.TextBox
    Friend WithEvents dgvProductos As System.Windows.Forms.DataGridView
    Friend WithEvents txtFechaAux As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtSubTotal As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtDescripcionTotal As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtObservaciones As System.Windows.Forms.TextBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents btnConsulta As System.Windows.Forms.Button
    Friend WithEvents btnEliminar As System.Windows.Forms.Button
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtPais As System.Windows.Forms.TextBox
    Friend WithEvents Producto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Descripcion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cantidad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Precio As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Total As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnVistaPrevia As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents txtDescripcionTotalII As System.Windows.Forms.TextBox
    Friend WithEvents txtCondicionPagoII As System.Windows.Forms.TextBox
    Friend WithEvents txtViaII As System.Windows.Forms.TextBox
    Friend WithEvents txtObservacionesIII As System.Windows.Forms.TextBox
    Friend WithEvents txtObservacionesII As System.Windows.Forms.TextBox
    Friend WithEvents GrupoConsulta As System.Windows.Forms.GroupBox
    Friend WithEvents btnCerrarConsulta As System.Windows.Forms.Button
    Friend WithEvents lstOpcionesConsulta As System.Windows.Forms.ListBox
    Friend WithEvents lstFiltrada As System.Windows.Forms.ListBox
    Friend WithEvents lstConsulta As System.Windows.Forms.ListBox
    Friend WithEvents txtAyuda As System.Windows.Forms.TextBox
    Friend WithEvents btnHistorialArchivosRelacionados As System.Windows.Forms.Button
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtTotal As System.Windows.Forms.TextBox
    Friend WithEvents txtSeguro As System.Windows.Forms.TextBox
    Friend WithEvents txtFlete As System.Windows.Forms.TextBox
    Friend WithEvents cmbEstado As System.Windows.Forms.ComboBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents cmbVia As System.Windows.Forms.ComboBox
End Class
