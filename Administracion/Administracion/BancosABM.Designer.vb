<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BancosABM
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.txtFiltrar = New System.Windows.Forms.TextBox()
        Me.LBConsulta_Filtrada = New System.Windows.Forms.ListBox()
        Me.LBConsulta = New System.Windows.Forms.ListBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnSiguienteRegistro = New System.Windows.Forms.Button()
        Me.btnPrimerRegistro = New System.Windows.Forms.Button()
        Me.btnUltimoRegistro = New System.Windows.Forms.Button()
        Me.btnAnteriorRegistro = New System.Windows.Forms.Button()
        Me.btnListado = New System.Windows.Forms.Button()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.btnConsulta = New System.Windows.Forms.Button()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.LBConsulta_Opciones = New System.Windows.Forms.ListBox()
        Me.CustomLabel3 = New Administracion.CustomLabel()
        Me.CustomLabel2 = New Administracion.CustomLabel()
        Me.CustomLabel1 = New Administracion.CustomLabel()
        Me.txtDescripcion = New Administracion.CustomTextBox()
        Me.txtCuenta = New Administracion.CustomTextBox()
        Me.txtNombre = New Administracion.CustomTextBox()
        Me.txtCodigo = New Administracion.CustomTextBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(-1, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(582, 50)
        Me.Panel1.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.Control
        Me.Label2.Location = New System.Drawing.Point(400, 10)
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
        Me.Label1.Location = New System.Drawing.Point(27, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(132, 19)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Ingreso de Bancos"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(95, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(82, Byte), Integer))
        Me.Panel2.Location = New System.Drawing.Point(-1, 50)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(582, 88)
        Me.Panel2.TabIndex = 1
        '
        'txtFiltrar
        '
        Me.txtFiltrar.Location = New System.Drawing.Point(21, 263)
        Me.txtFiltrar.Name = "txtFiltrar"
        Me.txtFiltrar.Size = New System.Drawing.Size(538, 20)
        Me.txtFiltrar.TabIndex = 62
        Me.txtFiltrar.Text = "Buscar..."
        '
        'LBConsulta_Filtrada
        '
        Me.LBConsulta_Filtrada.FormattingEnabled = True
        Me.LBConsulta_Filtrada.Location = New System.Drawing.Point(21, 289)
        Me.LBConsulta_Filtrada.Name = "LBConsulta_Filtrada"
        Me.LBConsulta_Filtrada.Size = New System.Drawing.Size(538, 147)
        Me.LBConsulta_Filtrada.TabIndex = 61
        Me.LBConsulta_Filtrada.Visible = False
        '
        'LBConsulta
        '
        Me.LBConsulta.FormattingEnabled = True
        Me.LBConsulta.Location = New System.Drawing.Point(21, 289)
        Me.LBConsulta.Name = "LBConsulta"
        Me.LBConsulta.Size = New System.Drawing.Size(538, 147)
        Me.LBConsulta.TabIndex = 60
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnSiguienteRegistro)
        Me.GroupBox1.Controls.Add(Me.btnPrimerRegistro)
        Me.GroupBox1.Controls.Add(Me.btnUltimoRegistro)
        Me.GroupBox1.Controls.Add(Me.btnAnteriorRegistro)
        Me.GroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBox1.Location = New System.Drawing.Point(359, 153)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(200, 80)
        Me.GroupBox1.TabIndex = 69
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Navegar por Bancos"
        '
        'btnSiguienteRegistro
        '
        Me.btnSiguienteRegistro.BackgroundImage = Global.Administracion.My.Resources.Resources.SiguienteRegistro
        Me.btnSiguienteRegistro.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnSiguienteRegistro.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSiguienteRegistro.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnSiguienteRegistro.FlatAppearance.BorderSize = 0
        Me.btnSiguienteRegistro.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.Control
        Me.btnSiguienteRegistro.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control
        Me.btnSiguienteRegistro.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control
        Me.btnSiguienteRegistro.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSiguienteRegistro.ForeColor = System.Drawing.SystemColors.Control
        Me.btnSiguienteRegistro.Location = New System.Drawing.Point(103, 23)
        Me.btnSiguienteRegistro.Name = "btnSiguienteRegistro"
        Me.btnSiguienteRegistro.Size = New System.Drawing.Size(40, 40)
        Me.btnSiguienteRegistro.TabIndex = 14
        Me.ToolTip1.SetToolTip(Me.btnSiguienteRegistro, "Siguiente Registro")
        Me.btnSiguienteRegistro.UseVisualStyleBackColor = True
        '
        'btnPrimerRegistro
        '
        Me.btnPrimerRegistro.BackgroundImage = Global.Administracion.My.Resources.Resources.PrimerRegistro
        Me.btnPrimerRegistro.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnPrimerRegistro.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnPrimerRegistro.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnPrimerRegistro.FlatAppearance.BorderSize = 0
        Me.btnPrimerRegistro.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.Control
        Me.btnPrimerRegistro.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control
        Me.btnPrimerRegistro.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control
        Me.btnPrimerRegistro.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPrimerRegistro.ForeColor = System.Drawing.SystemColors.Control
        Me.btnPrimerRegistro.Location = New System.Drawing.Point(11, 23)
        Me.btnPrimerRegistro.Name = "btnPrimerRegistro"
        Me.btnPrimerRegistro.Size = New System.Drawing.Size(40, 40)
        Me.btnPrimerRegistro.TabIndex = 14
        Me.ToolTip1.SetToolTip(Me.btnPrimerRegistro, "Primer Registro")
        Me.btnPrimerRegistro.UseVisualStyleBackColor = True
        '
        'btnUltimoRegistro
        '
        Me.btnUltimoRegistro.BackgroundImage = Global.Administracion.My.Resources.Resources.UltimoRegistro
        Me.btnUltimoRegistro.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnUltimoRegistro.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnUltimoRegistro.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnUltimoRegistro.FlatAppearance.BorderSize = 0
        Me.btnUltimoRegistro.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.Control
        Me.btnUltimoRegistro.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control
        Me.btnUltimoRegistro.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control
        Me.btnUltimoRegistro.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnUltimoRegistro.ForeColor = System.Drawing.SystemColors.Control
        Me.btnUltimoRegistro.Location = New System.Drawing.Point(149, 23)
        Me.btnUltimoRegistro.Name = "btnUltimoRegistro"
        Me.btnUltimoRegistro.Size = New System.Drawing.Size(40, 40)
        Me.btnUltimoRegistro.TabIndex = 14
        Me.ToolTip1.SetToolTip(Me.btnUltimoRegistro, "Ultimo Registro")
        Me.btnUltimoRegistro.UseVisualStyleBackColor = True
        '
        'btnAnteriorRegistro
        '
        Me.btnAnteriorRegistro.BackgroundImage = Global.Administracion.My.Resources.Resources.AnteriorRegistro
        Me.btnAnteriorRegistro.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnAnteriorRegistro.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAnteriorRegistro.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnAnteriorRegistro.FlatAppearance.BorderSize = 0
        Me.btnAnteriorRegistro.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.Control
        Me.btnAnteriorRegistro.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control
        Me.btnAnteriorRegistro.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control
        Me.btnAnteriorRegistro.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAnteriorRegistro.ForeColor = System.Drawing.SystemColors.Control
        Me.btnAnteriorRegistro.Location = New System.Drawing.Point(57, 23)
        Me.btnAnteriorRegistro.Name = "btnAnteriorRegistro"
        Me.btnAnteriorRegistro.Size = New System.Drawing.Size(40, 40)
        Me.btnAnteriorRegistro.TabIndex = 14
        Me.ToolTip1.SetToolTip(Me.btnAnteriorRegistro, "Anterior Registro")
        Me.btnAnteriorRegistro.UseVisualStyleBackColor = True
        '
        'btnListado
        '
        Me.btnListado.BackgroundImage = Global.Administracion.My.Resources.Resources.Informe
        Me.btnListado.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnListado.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnListado.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnListado.FlatAppearance.BorderSize = 0
        Me.btnListado.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.Control
        Me.btnListado.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control
        Me.btnListado.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control
        Me.btnListado.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnListado.ForeColor = System.Drawing.SystemColors.Control
        Me.btnListado.Location = New System.Drawing.Point(245, 144)
        Me.btnListado.Name = "btnListado"
        Me.btnListado.Size = New System.Drawing.Size(105, 42)
        Me.btnListado.TabIndex = 67
        Me.ToolTip1.SetToolTip(Me.btnListado, "Listado")
        Me.btnListado.UseVisualStyleBackColor = True
        '
        'btnLimpiar
        '
        Me.btnLimpiar.BackgroundImage = Global.Administracion.My.Resources.Resources.Limpiar
        Me.btnLimpiar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnLimpiar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnLimpiar.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnLimpiar.FlatAppearance.BorderSize = 0
        Me.btnLimpiar.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.Control
        Me.btnLimpiar.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control
        Me.btnLimpiar.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control
        Me.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLimpiar.ForeColor = System.Drawing.SystemColors.Control
        Me.btnLimpiar.Location = New System.Drawing.Point(22, 199)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(105, 42)
        Me.btnLimpiar.TabIndex = 68
        Me.ToolTip1.SetToolTip(Me.btnLimpiar, "Limpiar Formulario")
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'btnCerrar
        '
        Me.btnCerrar.BackgroundImage = Global.Administracion.My.Resources.Resources.Salir2
        Me.btnCerrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCerrar.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnCerrar.FlatAppearance.BorderSize = 0
        Me.btnCerrar.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.Control
        Me.btnCerrar.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control
        Me.btnCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control
        Me.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCerrar.ForeColor = System.Drawing.SystemColors.Control
        Me.btnCerrar.Location = New System.Drawing.Point(245, 199)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(105, 42)
        Me.btnCerrar.TabIndex = 66
        Me.ToolTip1.SetToolTip(Me.btnCerrar, "Cerrar")
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'btnConsulta
        '
        Me.btnConsulta.BackgroundImage = Global.Administracion.My.Resources.Resources.Consulta_Dat_N1
        Me.btnConsulta.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnConsulta.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnConsulta.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnConsulta.FlatAppearance.BorderSize = 0
        Me.btnConsulta.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.Control
        Me.btnConsulta.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control
        Me.btnConsulta.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control
        Me.btnConsulta.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnConsulta.ForeColor = System.Drawing.SystemColors.Control
        Me.btnConsulta.Location = New System.Drawing.Point(133, 199)
        Me.btnConsulta.Name = "btnConsulta"
        Me.btnConsulta.Size = New System.Drawing.Size(105, 42)
        Me.btnConsulta.TabIndex = 64
        Me.ToolTip1.SetToolTip(Me.btnConsulta, "Consultar Bancos/Cuentas Contables")
        Me.btnConsulta.UseVisualStyleBackColor = True
        '
        'btnEliminar
        '
        Me.btnEliminar.BackgroundImage = Global.Administracion.My.Resources.Resources.eliminar
        Me.btnEliminar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnEliminar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnEliminar.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnEliminar.FlatAppearance.BorderSize = 0
        Me.btnEliminar.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.Control
        Me.btnEliminar.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control
        Me.btnEliminar.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control
        Me.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEliminar.ForeColor = System.Drawing.SystemColors.Control
        Me.btnEliminar.Location = New System.Drawing.Point(134, 144)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(105, 42)
        Me.btnEliminar.TabIndex = 65
        Me.ToolTip1.SetToolTip(Me.btnEliminar, "Eliminar")
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'btnAgregar
        '
        Me.btnAgregar.BackColor = System.Drawing.SystemColors.Control
        Me.btnAgregar.BackgroundImage = Global.Administracion.My.Resources.Resources.Aceptar_N2
        Me.btnAgregar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnAgregar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAgregar.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnAgregar.FlatAppearance.BorderSize = 0
        Me.btnAgregar.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.Control
        Me.btnAgregar.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control
        Me.btnAgregar.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control
        Me.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAgregar.ForeColor = System.Drawing.SystemColors.Control
        Me.btnAgregar.Location = New System.Drawing.Point(23, 144)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(105, 42)
        Me.btnAgregar.TabIndex = 63
        Me.ToolTip1.SetToolTip(Me.btnAgregar, "Aceptar")
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'LBConsulta_Opciones
        '
        Me.LBConsulta_Opciones.FormattingEnabled = True
        Me.LBConsulta_Opciones.Items.AddRange(New Object() {"Bancos", "Cuentas Contables"})
        Me.LBConsulta_Opciones.Location = New System.Drawing.Point(21, 289)
        Me.LBConsulta_Opciones.Name = "LBConsulta_Opciones"
        Me.LBConsulta_Opciones.Size = New System.Drawing.Size(537, 147)
        Me.LBConsulta_Opciones.TabIndex = 70
        '
        'CustomLabel3
        '
        Me.CustomLabel3.AutoSize = True
        Me.CustomLabel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(95, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(82, Byte), Integer))
        Me.CustomLabel3.ControlAssociationKey = 3
        Me.CustomLabel3.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CustomLabel3.ForeColor = System.Drawing.SystemColors.Control
        Me.CustomLabel3.Location = New System.Drawing.Point(21, 104)
        Me.CustomLabel3.Name = "CustomLabel3"
        Me.CustomLabel3.Size = New System.Drawing.Size(111, 18)
        Me.CustomLabel3.TabIndex = 48
        Me.CustomLabel3.Text = "Cuenta Contable"
        '
        'CustomLabel2
        '
        Me.CustomLabel2.AutoSize = True
        Me.CustomLabel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(95, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(82, Byte), Integer))
        Me.CustomLabel2.ControlAssociationKey = 2
        Me.CustomLabel2.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CustomLabel2.ForeColor = System.Drawing.SystemColors.Control
        Me.CustomLabel2.Location = New System.Drawing.Point(169, 68)
        Me.CustomLabel2.Name = "CustomLabel2"
        Me.CustomLabel2.Size = New System.Drawing.Size(59, 18)
        Me.CustomLabel2.TabIndex = 47
        Me.CustomLabel2.Text = "Nombre"
        '
        'CustomLabel1
        '
        Me.CustomLabel1.AutoSize = True
        Me.CustomLabel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(95, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(82, Byte), Integer))
        Me.CustomLabel1.ControlAssociationKey = 1
        Me.CustomLabel1.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CustomLabel1.ForeColor = System.Drawing.SystemColors.Control
        Me.CustomLabel1.Location = New System.Drawing.Point(21, 68)
        Me.CustomLabel1.Name = "CustomLabel1"
        Me.CustomLabel1.Size = New System.Drawing.Size(51, 18)
        Me.CustomLabel1.TabIndex = 46
        Me.CustomLabel1.Text = "Código"
        '
        'txtDescripcion
        '
        Me.txtDescripcion.Cleanable = True
        Me.txtDescripcion.Empty = True
        Me.txtDescripcion.Enabled = False
        Me.txtDescripcion.EnterIndex = -1
        Me.txtDescripcion.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescripcion.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtDescripcion.LabelAssociationKey = 3
        Me.txtDescripcion.Location = New System.Drawing.Point(229, 103)
        Me.txtDescripcion.MaxLength = 50
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(326, 23)
        Me.txtDescripcion.TabIndex = 45
        Me.txtDescripcion.TabStop = False
        Me.txtDescripcion.Validator = Administracion.ValidatorType.None
        '
        'txtCuenta
        '
        Me.txtCuenta.Cleanable = True
        Me.txtCuenta.Empty = False
        Me.txtCuenta.EnterIndex = 3
        Me.txtCuenta.LabelAssociationKey = 3
        Me.txtCuenta.Location = New System.Drawing.Point(136, 103)
        Me.txtCuenta.MaxLength = 10
        Me.txtCuenta.Name = "txtCuenta"
        Me.txtCuenta.Size = New System.Drawing.Size(79, 20)
        Me.txtCuenta.TabIndex = 44
        Me.ToolTip1.SetToolTip(Me.txtCuenta, "Doble Click: Abrir Consulta de Cuentas Contables")
        Me.txtCuenta.Validator = Administracion.ValidatorType.NotEmpty
        '
        'txtNombre
        '
        Me.txtNombre.Cleanable = True
        Me.txtNombre.Empty = False
        Me.txtNombre.EnterIndex = 2
        Me.txtNombre.LabelAssociationKey = 2
        Me.txtNombre.Location = New System.Drawing.Point(229, 67)
        Me.txtNombre.MaxLength = 50
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(326, 20)
        Me.txtNombre.TabIndex = 43
        Me.txtNombre.Validator = Administracion.ValidatorType.NotEmpty
        '
        'txtCodigo
        '
        Me.txtCodigo.Cleanable = True
        Me.txtCodigo.Empty = False
        Me.txtCodigo.EnterIndex = 1
        Me.txtCodigo.LabelAssociationKey = 1
        Me.txtCodigo.Location = New System.Drawing.Point(78, 67)
        Me.txtCodigo.MaxLength = 5
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Size = New System.Drawing.Size(79, 20)
        Me.txtCodigo.TabIndex = 42
        Me.txtCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.txtCodigo, "Doble Click: Abrir Consulta de Bancos")
        Me.txtCodigo.Validator = Administracion.ValidatorType.Numeric
        '
        'BancosABM
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(580, 456)
        Me.Controls.Add(Me.LBConsulta_Opciones)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnListado)
        Me.Controls.Add(Me.btnLimpiar)
        Me.Controls.Add(Me.btnCerrar)
        Me.Controls.Add(Me.btnConsulta)
        Me.Controls.Add(Me.btnEliminar)
        Me.Controls.Add(Me.btnAgregar)
        Me.Controls.Add(Me.txtFiltrar)
        Me.Controls.Add(Me.LBConsulta_Filtrada)
        Me.Controls.Add(Me.LBConsulta)
        Me.Controls.Add(Me.CustomLabel3)
        Me.Controls.Add(Me.CustomLabel2)
        Me.Controls.Add(Me.CustomLabel1)
        Me.Controls.Add(Me.txtDescripcion)
        Me.Controls.Add(Me.txtCuenta)
        Me.Controls.Add(Me.txtNombre)
        Me.Controls.Add(Me.txtCodigo)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.Name = "BancosABM"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents txtFiltrar As System.Windows.Forms.TextBox
    Friend WithEvents LBConsulta_Filtrada As System.Windows.Forms.ListBox
    Friend WithEvents LBConsulta As System.Windows.Forms.ListBox
    Friend WithEvents CustomLabel3 As Administracion.CustomLabel
    Friend WithEvents CustomLabel2 As Administracion.CustomLabel
    Friend WithEvents CustomLabel1 As Administracion.CustomLabel
    Friend WithEvents txtDescripcion As Administracion.CustomTextBox
    Friend WithEvents txtCuenta As Administracion.CustomTextBox
    Friend WithEvents txtNombre As Administracion.CustomTextBox
    Friend WithEvents txtCodigo As Administracion.CustomTextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnSiguienteRegistro As System.Windows.Forms.Button
    Friend WithEvents btnPrimerRegistro As System.Windows.Forms.Button
    Friend WithEvents btnUltimoRegistro As System.Windows.Forms.Button
    Friend WithEvents btnAnteriorRegistro As System.Windows.Forms.Button
    Friend WithEvents btnListado As System.Windows.Forms.Button
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents btnConsulta As System.Windows.Forms.Button
    Friend WithEvents btnEliminar As System.Windows.Forms.Button
    Friend WithEvents btnAgregar As System.Windows.Forms.Button
    Friend WithEvents LBConsulta_Opciones As System.Windows.Forms.ListBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
End Class
