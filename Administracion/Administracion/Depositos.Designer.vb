<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Depositos
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
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.gridCheques = New System.Windows.Forms.DataGridView()
        Me.tipo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.numero = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.fecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.importe = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ClaveCheque = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rbVentaCheques = New System.Windows.Forms.RadioButton()
        Me.rbDepósito = New System.Windows.Forms.RadioButton()
        Me.btnEliminarFila = New System.Windows.Forms.Button()
        Me.txtFechaAcreditacion = New System.Windows.Forms.MaskedTextBox()
        Me.txtFecha = New System.Windows.Forms.MaskedTextBox()
        Me.txtAyuda = New System.Windows.Forms.TextBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.lstSeleccion = New Administracion.CustomListBox()
        Me.txtImporte = New Administracion.CustomTextBox()
        Me.CustomLabel3 = New Administracion.CustomLabel()
        Me.CustomLabel4 = New Administracion.CustomLabel()
        Me.CustomLabel7 = New Administracion.CustomLabel()
        Me.CustomLabel5 = New Administracion.CustomLabel()
        Me.lblTotal = New Administracion.CustomLabel()
        Me.txtCodigoBanco = New Administracion.CustomTextBox()
        Me.CustomLabel1 = New Administracion.CustomLabel()
        Me.txtNroDeposito = New Administracion.CustomTextBox()
        Me.txtDescripcionBanco = New Administracion.CustomTextBox()
        Me.CustomLabel6 = New Administracion.CustomLabel()
        Me.lstFiltrado = New Administracion.CustomListBox()
        Me.lstConsulta = New Administracion.CustomListBox()
        Me.btnCerrar = New Administracion.CustomButton()
        Me.btnConsulta = New Administracion.CustomButton()
        Me.btnChequeTerceros = New Administracion.CustomButton()
        Me.btnLimpiar = New Administracion.CustomButton()
        Me.btnImpresion = New Administracion.CustomButton()
        Me.btnAgregar = New Administracion.CustomButton()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.rbChFisicos = New System.Windows.Forms.RadioButton()
        Me.rbChElectronicos = New System.Windows.Forms.RadioButton()
        CType(Me.gridCheques, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'gridCheques
        '
        Me.gridCheques.AllowUserToAddRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gridCheques.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.gridCheques.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridCheques.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.tipo, Me.numero, Me.fecha, Me.nombre, Me.importe, Me.ClaveCheque})
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gridCheques.DefaultCellStyle = DataGridViewCellStyle5
        Me.gridCheques.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.gridCheques.Location = New System.Drawing.Point(8, 133)
        Me.gridCheques.Name = "gridCheques"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gridCheques.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.gridCheques.RowHeadersWidth = 22
        Me.gridCheques.ShowCellToolTips = False
        Me.gridCheques.Size = New System.Drawing.Size(446, 206)
        Me.gridCheques.StandardTab = True
        Me.gridCheques.TabIndex = 0
        '
        'tipo
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.tipo.DefaultCellStyle = DataGridViewCellStyle2
        Me.tipo.HeaderText = "Tipo"
        Me.tipo.MaxInputLength = 31
        Me.tipo.Name = "tipo"
        Me.tipo.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.tipo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.tipo.Width = 50
        '
        'numero
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.numero.DefaultCellStyle = DataGridViewCellStyle3
        Me.numero.HeaderText = "Numero"
        Me.numero.Name = "numero"
        Me.numero.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.numero.Width = 80
        '
        'fecha
        '
        Me.fecha.HeaderText = "Fecha"
        Me.fecha.Name = "fecha"
        Me.fecha.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.fecha.Width = 80
        '
        'nombre
        '
        Me.nombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.nombre.HeaderText = "Nombre"
        Me.nombre.Name = "nombre"
        Me.nombre.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'importe
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.importe.DefaultCellStyle = DataGridViewCellStyle4
        Me.importe.HeaderText = "Importe"
        Me.importe.Name = "importe"
        Me.importe.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.importe.Width = 110
        '
        'ClaveCheque
        '
        Me.ClaveCheque.HeaderText = "ClaveCheque"
        Me.ClaveCheque.Name = "ClaveCheque"
        Me.ClaveCheque.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ClaveCheque.Visible = False
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(0, -10)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(772, 44)
        Me.Panel1.TabIndex = 17
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.Control
        Me.Label2.Location = New System.Drawing.Point(616, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(156, 26)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "SURFACTAN S.A."
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.Control
        Me.Label1.Location = New System.Drawing.Point(21, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(151, 19)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Ingreso de Depósitos"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(95, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(82, Byte), Integer))
        Me.Panel2.Controls.Add(Me.GroupBox2)
        Me.Panel2.Controls.Add(Me.GroupBox1)
        Me.Panel2.Controls.Add(Me.btnEliminarFila)
        Me.Panel2.Controls.Add(Me.lstSeleccion)
        Me.Panel2.Controls.Add(Me.txtFechaAcreditacion)
        Me.Panel2.Controls.Add(Me.txtFecha)
        Me.Panel2.Controls.Add(Me.txtImporte)
        Me.Panel2.Controls.Add(Me.CustomLabel3)
        Me.Panel2.Controls.Add(Me.CustomLabel4)
        Me.Panel2.Controls.Add(Me.CustomLabel7)
        Me.Panel2.Controls.Add(Me.CustomLabel5)
        Me.Panel2.Controls.Add(Me.lblTotal)
        Me.Panel2.Controls.Add(Me.txtCodigoBanco)
        Me.Panel2.Controls.Add(Me.CustomLabel1)
        Me.Panel2.Controls.Add(Me.txtNroDeposito)
        Me.Panel2.Controls.Add(Me.gridCheques)
        Me.Panel2.Controls.Add(Me.txtDescripcionBanco)
        Me.Panel2.Controls.Add(Me.CustomLabel6)
        Me.Panel2.Controls.Add(Me.lstFiltrado)
        Me.Panel2.Controls.Add(Me.lstConsulta)
        Me.Panel2.Controls.Add(Me.txtAyuda)
        Me.Panel2.Location = New System.Drawing.Point(0, 34)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(772, 373)
        Me.Panel2.TabIndex = 18
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbVentaCheques)
        Me.GroupBox1.Controls.Add(Me.rbDepósito)
        Me.GroupBox1.ForeColor = System.Drawing.SystemColors.Control
        Me.GroupBox1.Location = New System.Drawing.Point(125, 86)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(244, 41)
        Me.GroupBox1.TabIndex = 22
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Tipo Operación"
        '
        'rbVentaCheques
        '
        Me.rbVentaCheques.AutoSize = True
        Me.rbVentaCheques.Location = New System.Drawing.Point(106, 15)
        Me.rbVentaCheques.Name = "rbVentaCheques"
        Me.rbVentaCheques.Size = New System.Drawing.Size(113, 17)
        Me.rbVentaCheques.TabIndex = 0
        Me.rbVentaCheques.Text = "Venta de Cheques"
        Me.rbVentaCheques.UseVisualStyleBackColor = True
        '
        'rbDepósito
        '
        Me.rbDepósito.AutoSize = True
        Me.rbDepósito.Checked = True
        Me.rbDepósito.Location = New System.Drawing.Point(12, 15)
        Me.rbDepósito.Name = "rbDepósito"
        Me.rbDepósito.Size = New System.Drawing.Size(67, 17)
        Me.rbDepósito.TabIndex = 0
        Me.rbDepósito.TabStop = True
        Me.rbDepósito.Text = "Depósito"
        Me.rbDepósito.UseVisualStyleBackColor = True
        '
        'btnEliminarFila
        '
        Me.btnEliminarFila.Location = New System.Drawing.Point(8, 101)
        Me.btnEliminarFila.Name = "btnEliminarFila"
        Me.btnEliminarFila.Size = New System.Drawing.Size(111, 31)
        Me.btnEliminarFila.TabIndex = 21
        Me.btnEliminarFila.Text = "Eliminar Fila"
        Me.btnEliminarFila.UseVisualStyleBackColor = True
        '
        'txtFechaAcreditacion
        '
        Me.txtFechaAcreditacion.Location = New System.Drawing.Point(139, 61)
        Me.txtFechaAcreditacion.Mask = "00/00/0000"
        Me.txtFechaAcreditacion.Name = "txtFechaAcreditacion"
        Me.txtFechaAcreditacion.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtFechaAcreditacion.Size = New System.Drawing.Size(75, 20)
        Me.txtFechaAcreditacion.TabIndex = 18
        Me.txtFechaAcreditacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtFechaAcreditacion.ValidatingType = GetType(Date)
        '
        'txtFecha
        '
        Me.txtFecha.Location = New System.Drawing.Point(269, 5)
        Me.txtFecha.Mask = "00/00/0000"
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtFecha.Size = New System.Drawing.Size(100, 20)
        Me.txtFecha.TabIndex = 17
        Me.txtFecha.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtFecha.ValidatingType = GetType(Date)
        '
        'txtAyuda
        '
        Me.txtAyuda.Location = New System.Drawing.Point(459, 9)
        Me.txtAyuda.Name = "txtAyuda"
        Me.txtAyuda.Size = New System.Drawing.Size(304, 20)
        Me.txtAyuda.TabIndex = 19
        Me.txtAyuda.Visible = False
        '
        'lstSeleccion
        '
        Me.lstSeleccion.Cleanable = False
        Me.lstSeleccion.EnterIndex = -1
        Me.lstSeleccion.FormattingEnabled = True
        Me.lstSeleccion.Items.AddRange(New Object() {"Bancos", "Cheques de Terceros"})
        Me.lstSeleccion.LabelAssociationKey = -1
        Me.lstSeleccion.Location = New System.Drawing.Point(459, 9)
        Me.lstSeleccion.Name = "lstSeleccion"
        Me.lstSeleccion.Size = New System.Drawing.Size(305, 355)
        Me.lstSeleccion.TabIndex = 14
        Me.lstSeleccion.Visible = False
        '
        'txtImporte
        '
        Me.txtImporte.Cleanable = True
        Me.txtImporte.Empty = False
        Me.txtImporte.EnterIndex = 5
        Me.txtImporte.LabelAssociationKey = 5
        Me.txtImporte.Location = New System.Drawing.Point(281, 61)
        Me.txtImporte.MaxLength = 10000
        Me.txtImporte.Name = "txtImporte"
        Me.txtImporte.Size = New System.Drawing.Size(89, 20)
        Me.txtImporte.TabIndex = 16
        Me.txtImporte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtImporte.Validator = Administracion.ValidatorType.PositiveFloat
        '
        'CustomLabel3
        '
        Me.CustomLabel3.AutoSize = True
        Me.CustomLabel3.ControlAssociationKey = 1
        Me.CustomLabel3.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.CustomLabel3.ForeColor = System.Drawing.SystemColors.Control
        Me.CustomLabel3.Location = New System.Drawing.Point(14, 6)
        Me.CustomLabel3.Name = "CustomLabel3"
        Me.CustomLabel3.Size = New System.Drawing.Size(94, 18)
        Me.CustomLabel3.TabIndex = 3
        Me.CustomLabel3.Text = "Nro. Depósito"
        '
        'CustomLabel4
        '
        Me.CustomLabel4.AutoSize = True
        Me.CustomLabel4.ControlAssociationKey = 3
        Me.CustomLabel4.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.CustomLabel4.ForeColor = System.Drawing.SystemColors.Control
        Me.CustomLabel4.Location = New System.Drawing.Point(15, 34)
        Me.CustomLabel4.Name = "CustomLabel4"
        Me.CustomLabel4.Size = New System.Drawing.Size(45, 18)
        Me.CustomLabel4.TabIndex = 4
        Me.CustomLabel4.Text = "Banco"
        '
        'CustomLabel7
        '
        Me.CustomLabel7.AutoSize = True
        Me.CustomLabel7.ControlAssociationKey = 5
        Me.CustomLabel7.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.CustomLabel7.ForeColor = System.Drawing.SystemColors.Control
        Me.CustomLabel7.Location = New System.Drawing.Point(220, 62)
        Me.CustomLabel7.Name = "CustomLabel7"
        Me.CustomLabel7.Size = New System.Drawing.Size(58, 18)
        Me.CustomLabel7.TabIndex = 15
        Me.CustomLabel7.Text = "Importe"
        '
        'CustomLabel5
        '
        Me.CustomLabel5.AutoSize = True
        Me.CustomLabel5.ControlAssociationKey = 4
        Me.CustomLabel5.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.CustomLabel5.ForeColor = System.Drawing.SystemColors.Control
        Me.CustomLabel5.Location = New System.Drawing.Point(12, 62)
        Me.CustomLabel5.Name = "CustomLabel5"
        Me.CustomLabel5.Size = New System.Drawing.Size(125, 18)
        Me.CustomLabel5.TabIndex = 5
        Me.CustomLabel5.Text = "Fecha Acreditación"
        '
        'lblTotal
        '
        Me.lblTotal.BackColor = System.Drawing.SystemColors.Control
        Me.lblTotal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTotal.ControlAssociationKey = -1
        Me.lblTotal.Location = New System.Drawing.Point(238, 342)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(216, 22)
        Me.lblTotal.TabIndex = 2
        Me.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtCodigoBanco
        '
        Me.txtCodigoBanco.Cleanable = True
        Me.txtCodigoBanco.Empty = False
        Me.txtCodigoBanco.EnterIndex = 3
        Me.txtCodigoBanco.LabelAssociationKey = 3
        Me.txtCodigoBanco.Location = New System.Drawing.Point(63, 33)
        Me.txtCodigoBanco.MaxLength = 5
        Me.txtCodigoBanco.Name = "txtCodigoBanco"
        Me.txtCodigoBanco.Size = New System.Drawing.Size(71, 20)
        Me.txtCodigoBanco.TabIndex = 3
        Me.txtCodigoBanco.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.txtCodigoBanco, "Doble Click: Abrir Consulta de Bancos")
        Me.txtCodigoBanco.Validator = Administracion.ValidatorType.None
        '
        'CustomLabel1
        '
        Me.CustomLabel1.BackColor = System.Drawing.SystemColors.Control
        Me.CustomLabel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.CustomLabel1.ControlAssociationKey = -1
        Me.CustomLabel1.Location = New System.Drawing.Point(8, 342)
        Me.CustomLabel1.Name = "CustomLabel1"
        Me.CustomLabel1.Size = New System.Drawing.Size(218, 22)
        Me.CustomLabel1.TabIndex = 1
        Me.CustomLabel1.Text = "Tipo de Doc.:  1) Ef.    2) U$S    3)  Ch Terc."
        Me.CustomLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtNroDeposito
        '
        Me.txtNroDeposito.Cleanable = True
        Me.txtNroDeposito.Empty = False
        Me.txtNroDeposito.EnterIndex = 1
        Me.txtNroDeposito.LabelAssociationKey = 1
        Me.txtNroDeposito.Location = New System.Drawing.Point(114, 5)
        Me.txtNroDeposito.MaxLength = 6
        Me.txtNroDeposito.Name = "txtNroDeposito"
        Me.txtNroDeposito.Size = New System.Drawing.Size(96, 20)
        Me.txtNroDeposito.TabIndex = 1
        Me.txtNroDeposito.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtNroDeposito.Validator = Administracion.ValidatorType.Positive
        '
        'txtDescripcionBanco
        '
        Me.txtDescripcionBanco.Cleanable = True
        Me.txtDescripcionBanco.Empty = False
        Me.txtDescripcionBanco.Enabled = False
        Me.txtDescripcionBanco.EnterIndex = -1
        Me.txtDescripcionBanco.LabelAssociationKey = 3
        Me.txtDescripcionBanco.Location = New System.Drawing.Point(140, 33)
        Me.txtDescripcionBanco.MaxLength = 50
        Me.txtDescripcionBanco.Name = "txtDescripcionBanco"
        Me.txtDescripcionBanco.Size = New System.Drawing.Size(230, 20)
        Me.txtDescripcionBanco.TabIndex = 6
        Me.txtDescripcionBanco.TabStop = False
        Me.txtDescripcionBanco.Validator = Administracion.ValidatorType.None
        '
        'CustomLabel6
        '
        Me.CustomLabel6.AutoSize = True
        Me.CustomLabel6.ControlAssociationKey = 2
        Me.CustomLabel6.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.CustomLabel6.ForeColor = System.Drawing.SystemColors.Control
        Me.CustomLabel6.Location = New System.Drawing.Point(219, 6)
        Me.CustomLabel6.Name = "CustomLabel6"
        Me.CustomLabel6.Size = New System.Drawing.Size(44, 18)
        Me.CustomLabel6.TabIndex = 7
        Me.CustomLabel6.Text = "Fecha"
        '
        'lstFiltrado
        '
        Me.lstFiltrado.Cleanable = True
        Me.lstFiltrado.EnterIndex = -1
        Me.lstFiltrado.FormattingEnabled = True
        Me.lstFiltrado.LabelAssociationKey = -1
        Me.lstFiltrado.Location = New System.Drawing.Point(459, 31)
        Me.lstFiltrado.Name = "lstFiltrado"
        Me.lstFiltrado.Size = New System.Drawing.Size(305, 329)
        Me.lstFiltrado.TabIndex = 20
        Me.lstFiltrado.Visible = False
        '
        'lstConsulta
        '
        Me.lstConsulta.Cleanable = True
        Me.lstConsulta.EnterIndex = -1
        Me.lstConsulta.FormattingEnabled = True
        Me.lstConsulta.LabelAssociationKey = -1
        Me.lstConsulta.Location = New System.Drawing.Point(459, 31)
        Me.lstConsulta.Name = "lstConsulta"
        Me.lstConsulta.Size = New System.Drawing.Size(305, 329)
        Me.lstConsulta.TabIndex = 8
        Me.lstConsulta.Visible = False
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
        Me.btnCerrar.Location = New System.Drawing.Point(391, 422)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(110, 50)
        Me.btnCerrar.TabIndex = 13
        Me.ToolTip1.SetToolTip(Me.btnCerrar, "Cerrar")
        Me.btnCerrar.UseVisualStyleBackColor = True
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
        Me.btnConsulta.Location = New System.Drawing.Point(155, 422)
        Me.btnConsulta.Name = "btnConsulta"
        Me.btnConsulta.Size = New System.Drawing.Size(110, 50)
        Me.btnConsulta.TabIndex = 12
        Me.ToolTip1.SetToolTip(Me.btnConsulta, "Abrir Consulta")
        Me.btnConsulta.UseVisualStyleBackColor = True
        '
        'btnChequeTerceros
        '
        Me.btnChequeTerceros.BackgroundImage = Global.Administracion.My.Resources.Resources.check_icon
        Me.btnChequeTerceros.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnChequeTerceros.Cleanable = False
        Me.btnChequeTerceros.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnChequeTerceros.EnterIndex = -1
        Me.btnChequeTerceros.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnChequeTerceros.FlatAppearance.BorderSize = 0
        Me.btnChequeTerceros.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.Control
        Me.btnChequeTerceros.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control
        Me.btnChequeTerceros.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control
        Me.btnChequeTerceros.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnChequeTerceros.LabelAssociationKey = -1
        Me.btnChequeTerceros.Location = New System.Drawing.Point(625, 422)
        Me.btnChequeTerceros.Name = "btnChequeTerceros"
        Me.btnChequeTerceros.Size = New System.Drawing.Size(110, 50)
        Me.btnChequeTerceros.TabIndex = 11
        Me.ToolTip1.SetToolTip(Me.btnChequeTerceros, "Consultar Cheques de terceros")
        Me.btnChequeTerceros.UseVisualStyleBackColor = True
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
        Me.btnLimpiar.Location = New System.Drawing.Point(509, 422)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(110, 50)
        Me.btnLimpiar.TabIndex = 11
        Me.ToolTip1.SetToolTip(Me.btnLimpiar, "Limpiar Formulario")
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'btnImpresion
        '
        Me.btnImpresion.BackgroundImage = Global.Administracion.My.Resources.Resources.imprimir
        Me.btnImpresion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnImpresion.Cleanable = False
        Me.btnImpresion.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnImpresion.EnterIndex = -1
        Me.btnImpresion.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnImpresion.FlatAppearance.BorderSize = 0
        Me.btnImpresion.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.Control
        Me.btnImpresion.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control
        Me.btnImpresion.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control
        Me.btnImpresion.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnImpresion.LabelAssociationKey = -1
        Me.btnImpresion.Location = New System.Drawing.Point(273, 422)
        Me.btnImpresion.Name = "btnImpresion"
        Me.btnImpresion.Size = New System.Drawing.Size(110, 50)
        Me.btnImpresion.TabIndex = 10
        Me.ToolTip1.SetToolTip(Me.btnImpresion, "Imprimir Deposito")
        Me.btnImpresion.UseVisualStyleBackColor = True
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
        Me.btnAgregar.Location = New System.Drawing.Point(37, 422)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(110, 50)
        Me.btnAgregar.TabIndex = 9
        Me.ToolTip1.SetToolTip(Me.btnAgregar, "Aceptar")
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.rbChElectronicos)
        Me.GroupBox2.Controls.Add(Me.rbChFisicos)
        Me.GroupBox2.ForeColor = System.Drawing.SystemColors.Control
        Me.GroupBox2.Location = New System.Drawing.Point(376, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(77, 111)
        Me.GroupBox2.TabIndex = 23
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Tipos de cheques"
        '
        'rbChFisicos
        '
        Me.rbChFisicos.AutoSize = True
        Me.rbChFisicos.Checked = True
        Me.rbChFisicos.Location = New System.Drawing.Point(6, 31)
        Me.rbChFisicos.Name = "rbChFisicos"
        Me.rbChFisicos.Size = New System.Drawing.Size(57, 17)
        Me.rbChFisicos.TabIndex = 0
        Me.rbChFisicos.TabStop = True
        Me.rbChFisicos.Text = "Fisicos"
        Me.rbChFisicos.UseVisualStyleBackColor = True
        '
        'rbChElectronicos
        '
        Me.rbChElectronicos.AutoSize = True
        Me.rbChElectronicos.Location = New System.Drawing.Point(5, 65)
        Me.rbChElectronicos.Name = "rbChElectronicos"
        Me.rbChElectronicos.Size = New System.Drawing.Size(55, 17)
        Me.rbChElectronicos.TabIndex = 1
        Me.rbChElectronicos.Text = "Electr."
        Me.rbChElectronicos.UseVisualStyleBackColor = True
        '
        'Depositos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(772, 480)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.btnCerrar)
        Me.Controls.Add(Me.btnConsulta)
        Me.Controls.Add(Me.btnChequeTerceros)
        Me.Controls.Add(Me.btnLimpiar)
        Me.Controls.Add(Me.btnImpresion)
        Me.Controls.Add(Me.btnAgregar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Location = New System.Drawing.Point(5, 5)
        Me.MaximizeBox = False
        Me.Name = "Depositos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        CType(Me.gridCheques, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gridCheques As System.Windows.Forms.DataGridView
    Friend WithEvents CustomLabel1 As Administracion.CustomLabel
    Friend WithEvents lblTotal As Administracion.CustomLabel
    Friend WithEvents CustomLabel3 As Administracion.CustomLabel
    Friend WithEvents CustomLabel4 As Administracion.CustomLabel
    Friend WithEvents CustomLabel5 As Administracion.CustomLabel
    Friend WithEvents txtCodigoBanco As Administracion.CustomTextBox
    Friend WithEvents txtNroDeposito As Administracion.CustomTextBox
    Friend WithEvents txtDescripcionBanco As Administracion.CustomTextBox
    Friend WithEvents CustomLabel6 As Administracion.CustomLabel
    Friend WithEvents lstConsulta As Administracion.CustomListBox
    Friend WithEvents btnAgregar As Administracion.CustomButton
    Friend WithEvents btnImpresion As Administracion.CustomButton
    Friend WithEvents btnLimpiar As Administracion.CustomButton
    Friend WithEvents btnConsulta As Administracion.CustomButton
    Friend WithEvents btnCerrar As Administracion.CustomButton
    Friend WithEvents lstSeleccion As Administracion.CustomListBox
    Friend WithEvents CustomLabel7 As Administracion.CustomLabel
    Friend WithEvents txtImporte As Administracion.CustomTextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents txtFecha As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtFechaAcreditacion As System.Windows.Forms.MaskedTextBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents txtAyuda As System.Windows.Forms.TextBox
    Friend WithEvents lstFiltrado As Administracion.CustomListBox
    Friend WithEvents btnChequeTerceros As Administracion.CustomButton
    Friend WithEvents tipo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents numero As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents fecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents nombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents importe As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ClaveCheque As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnEliminarFila As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rbVentaCheques As System.Windows.Forms.RadioButton
    Friend WithEvents rbDepósito As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents rbChElectronicos As System.Windows.Forms.RadioButton
    Friend WithEvents rbChFisicos As System.Windows.Forms.RadioButton
End Class
