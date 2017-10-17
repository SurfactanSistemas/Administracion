<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class HistorialProforma
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
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.LayoutPrincipal = New System.Windows.Forms.TableLayoutPanel()
        Me.LayoutCabecera = New System.Windows.Forms.TableLayoutPanel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.LayoutCuerpoPrincipal = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtNroProforma = New System.Windows.Forms.TextBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.GrupoNuevaObs = New System.Windows.Forms.GroupBox()
        Me.txtUsuario = New System.Windows.Forms.TextBox()
        Me.txtObservacion = New System.Windows.Forms.TextBox()
        Me.WClaveObservacion = New System.Windows.Forms.TextBox()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.btnCerrarFormObs = New System.Windows.Forms.Button()
        Me.btnEnviarPorEmail = New System.Windows.Forms.Button()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtFecha = New System.Windows.Forms.MaskedTextBox()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtFechaAux = New System.Windows.Forms.MaskedTextBox()
        Me.dgvHistorial = New System.Windows.Forms.DataGridView()
        Me.Fecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Observacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Usuario = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Clave = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FechaOrd = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NroObservacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.MaskedTextBox1 = New System.Windows.Forms.MaskedTextBox()
        Me.dgvArchivos = New System.Windows.Forms.DataGridView()
        Me.FechaCreacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NombreArchivo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Icono = New System.Windows.Forms.DataGridViewImageColumn()
        Me.RutaArchivo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.GrupoEspecificacion = New System.Windows.Forms.GroupBox()
        Me.txtUsuarioEspecificacion = New System.Windows.Forms.TextBox()
        Me.cmbTipoEspecificacion = New System.Windows.Forms.ComboBox()
        Me.txtEspecificacion = New System.Windows.Forms.TextBox()
        Me.WNroEspecificacion = New System.Windows.Forms.TextBox()
        Me.btnEliminarEspecificacion = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnCerrarFormularioEspecificacion = New System.Windows.Forms.Button()
        Me.btnEnviarEmailEspecificacion = New System.Windows.Forms.Button()
        Me.btnLimpiarFormularioEspecificacion = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtFechaEspecificacion = New System.Windows.Forms.MaskedTextBox()
        Me.btnAgregarEspecificacion = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.dgvEspecificaciones = New System.Windows.Forms.DataGridView()
        Me.FechaEspecificacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Especificacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TipoEspecificacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UsuarioEspecificacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RenglonEspecificacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NroEspecificacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtCliente = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtDescripcionCliente = New System.Windows.Forms.TextBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnNuevaEspecificacion = New System.Windows.Forms.Button()
        Me.btnNuevaObservacion = New System.Windows.Forms.Button()
        Me.btnArchivos = New System.Windows.Forms.Button()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.PegarArchivosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LayoutPrincipal.SuspendLayout()
        Me.LayoutCabecera.SuspendLayout()
        Me.LayoutCuerpoPrincipal.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GrupoNuevaObs.SuspendLayout()
        CType(Me.dgvHistorial, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.dgvArchivos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage3.SuspendLayout()
        Me.GrupoEspecificacion.SuspendLayout()
        CType(Me.dgvEspecificaciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
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
        Me.LayoutPrincipal.Size = New System.Drawing.Size(654, 523)
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
        Me.LayoutCabecera.Size = New System.Drawing.Size(654, 45)
        Me.LayoutCabecera.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label3.Font = New System.Drawing.Font("Calibri", 14.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.Location = New System.Drawing.Point(241, 0)
        Me.Label3.Margin = New System.Windows.Forms.Padding(0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(233, 45)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "- Historial de Proforma -"
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
        Me.Label2.Location = New System.Drawing.Point(477, 0)
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
        Me.LayoutCuerpoPrincipal.Controls.Add(Me.Panel1, 0, 0)
        Me.LayoutCuerpoPrincipal.Controls.Add(Me.Panel2, 0, 1)
        Me.LayoutCuerpoPrincipal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutCuerpoPrincipal.Location = New System.Drawing.Point(0, 45)
        Me.LayoutCuerpoPrincipal.Margin = New System.Windows.Forms.Padding(0)
        Me.LayoutCuerpoPrincipal.Name = "LayoutCuerpoPrincipal"
        Me.LayoutCuerpoPrincipal.RowCount = 2
        Me.LayoutCuerpoPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 84.58244!))
        Me.LayoutCuerpoPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.41756!))
        Me.LayoutCuerpoPrincipal.Size = New System.Drawing.Size(654, 478)
        Me.LayoutCuerpoPrincipal.TabIndex = 1
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(95, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(82, Byte), Integer))
        Me.Panel1.Controls.Add(Me.txtNroProforma)
        Me.Panel1.Controls.Add(Me.TabControl1)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.txtCliente)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.txtDescripcionCliente)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(654, 404)
        Me.Panel1.TabIndex = 2
        '
        'txtNroProforma
        '
        Me.txtNroProforma.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtNroProforma.Location = New System.Drawing.Point(119, 13)
        Me.txtNroProforma.MaxLength = 6
        Me.txtNroProforma.Name = "txtNroProforma"
        Me.txtNroProforma.Size = New System.Drawing.Size(79, 20)
        Me.txtNroProforma.TabIndex = 0
        Me.txtNroProforma.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.ItemSize = New System.Drawing.Size(209, 30)
        Me.TabControl1.Location = New System.Drawing.Point(10, 47)
        Me.TabControl1.Margin = New System.Windows.Forms.Padding(0)
        Me.TabControl1.Multiline = True
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.Padding = New System.Drawing.Point(0, 0)
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(634, 349)
        Me.TabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.TabControl1.TabIndex = 11
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.FromArgb(CType(CType(95, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(82, Byte), Integer))
        Me.TabPage1.Controls.Add(Me.GrupoNuevaObs)
        Me.TabPage1.Controls.Add(Me.txtFechaAux)
        Me.TabPage1.Controls.Add(Me.dgvHistorial)
        Me.TabPage1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.TabPage1.Location = New System.Drawing.Point(4, 34)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(626, 311)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "HISTORIAL"
        '
        'GrupoNuevaObs
        '
        Me.GrupoNuevaObs.Controls.Add(Me.txtUsuario)
        Me.GrupoNuevaObs.Controls.Add(Me.txtObservacion)
        Me.GrupoNuevaObs.Controls.Add(Me.WClaveObservacion)
        Me.GrupoNuevaObs.Controls.Add(Me.btnEliminar)
        Me.GrupoNuevaObs.Controls.Add(Me.Label14)
        Me.GrupoNuevaObs.Controls.Add(Me.btnCerrarFormObs)
        Me.GrupoNuevaObs.Controls.Add(Me.btnEnviarPorEmail)
        Me.GrupoNuevaObs.Controls.Add(Me.btnLimpiar)
        Me.GrupoNuevaObs.Controls.Add(Me.Label13)
        Me.GrupoNuevaObs.Controls.Add(Me.txtFecha)
        Me.GrupoNuevaObs.Controls.Add(Me.btnAceptar)
        Me.GrupoNuevaObs.Controls.Add(Me.Label5)
        Me.GrupoNuevaObs.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GrupoNuevaObs.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrupoNuevaObs.ForeColor = System.Drawing.SystemColors.Control
        Me.GrupoNuevaObs.Location = New System.Drawing.Point(121, 44)
        Me.GrupoNuevaObs.Name = "GrupoNuevaObs"
        Me.GrupoNuevaObs.Size = New System.Drawing.Size(390, 251)
        Me.GrupoNuevaObs.TabIndex = 10
        Me.GrupoNuevaObs.TabStop = False
        Me.GrupoNuevaObs.Text = "Ingreso de Nueva Observación"
        Me.GrupoNuevaObs.Visible = False
        '
        'txtUsuario
        '
        Me.txtUsuario.BackColor = System.Drawing.SystemColors.Window
        Me.txtUsuario.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtUsuario.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUsuario.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtUsuario.Location = New System.Drawing.Point(246, 39)
        Me.txtUsuario.MaxLength = 20
        Me.txtUsuario.Name = "txtUsuario"
        Me.txtUsuario.Size = New System.Drawing.Size(118, 20)
        Me.txtUsuario.TabIndex = 0
        Me.ToolTip1.SetToolTip(Me.txtUsuario, "Total")
        '
        'txtObservacion
        '
        Me.txtObservacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtObservacion.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtObservacion.Location = New System.Drawing.Point(17, 94)
        Me.txtObservacion.MaxLength = 1000
        Me.txtObservacion.Multiline = True
        Me.txtObservacion.Name = "txtObservacion"
        Me.txtObservacion.Size = New System.Drawing.Size(357, 85)
        Me.txtObservacion.TabIndex = 0
        Me.ToolTip1.SetToolTip(Me.txtObservacion, "Descripción en Inglés del Monto Total")
        '
        'WClaveObservacion
        '
        Me.WClaveObservacion.BackColor = System.Drawing.SystemColors.Window
        Me.WClaveObservacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.WClaveObservacion.ForeColor = System.Drawing.SystemColors.ControlText
        Me.WClaveObservacion.Location = New System.Drawing.Point(121, 66)
        Me.WClaveObservacion.MaxLength = 20
        Me.WClaveObservacion.Name = "WClaveObservacion"
        Me.WClaveObservacion.ReadOnly = True
        Me.WClaveObservacion.Size = New System.Drawing.Size(19, 20)
        Me.WClaveObservacion.TabIndex = 0
        Me.WClaveObservacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.WClaveObservacion.Visible = False
        '
        'btnEliminar
        '
        Me.btnEliminar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEliminar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnEliminar.Location = New System.Drawing.Point(92, 185)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(68, 41)
        Me.btnEliminar.TabIndex = 0
        Me.btnEliminar.Text = "Eliminar"
        Me.ToolTip1.SetToolTip(Me.btnEliminar, "Eliminar Observación")
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label14.ForeColor = System.Drawing.SystemColors.Control
        Me.Label14.Location = New System.Drawing.Point(31, 66)
        Me.Label14.Margin = New System.Windows.Forms.Padding(0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(89, 18)
        Me.Label14.TabIndex = 3
        Me.Label14.Text = "Observacion:"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnCerrarFormObs
        '
        Me.btnCerrarFormObs.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCerrarFormObs.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnCerrarFormObs.Location = New System.Drawing.Point(305, 185)
        Me.btnCerrarFormObs.Name = "btnCerrarFormObs"
        Me.btnCerrarFormObs.Size = New System.Drawing.Size(68, 41)
        Me.btnCerrarFormObs.TabIndex = 0
        Me.btnCerrarFormObs.Text = "Cerrar"
        Me.ToolTip1.SetToolTip(Me.btnCerrarFormObs, "Cerrar Formulario de Observaciones")
        Me.btnCerrarFormObs.UseVisualStyleBackColor = True
        '
        'btnEnviarPorEmail
        '
        Me.btnEnviarPorEmail.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEnviarPorEmail.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnEnviarPorEmail.Location = New System.Drawing.Point(234, 185)
        Me.btnEnviarPorEmail.Name = "btnEnviarPorEmail"
        Me.btnEnviarPorEmail.Size = New System.Drawing.Size(68, 41)
        Me.btnEnviarPorEmail.TabIndex = 0
        Me.btnEnviarPorEmail.Text = "Enviar Email"
        Me.btnEnviarPorEmail.UseVisualStyleBackColor = True
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLimpiar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnLimpiar.Location = New System.Drawing.Point(163, 185)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(68, 41)
        Me.btnLimpiar.TabIndex = 0
        Me.btnLimpiar.Text = "Limpiar"
        Me.ToolTip1.SetToolTip(Me.btnLimpiar, "Limpiar Formulario")
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label13.ForeColor = System.Drawing.SystemColors.Control
        Me.Label13.Location = New System.Drawing.Point(183, 40)
        Me.Label13.Margin = New System.Windows.Forms.Padding(0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(60, 18)
        Me.Label13.TabIndex = 3
        Me.Label13.Text = "Usuario:"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtFecha
        '
        Me.txtFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFecha.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtFecha.Location = New System.Drawing.Point(92, 39)
        Me.txtFecha.Mask = "00/00/0000"
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtFecha.Size = New System.Drawing.Size(72, 20)
        Me.txtFecha.TabIndex = 6
        Me.txtFecha.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnAceptar
        '
        Me.btnAceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnAceptar.Location = New System.Drawing.Point(18, 185)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(71, 41)
        Me.btnAceptar.TabIndex = 0
        Me.btnAceptar.Text = "Aceptar"
        Me.ToolTip1.SetToolTip(Me.btnAceptar, "Grabar / Actualizar Proforma")
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label5.ForeColor = System.Drawing.SystemColors.Control
        Me.Label5.Location = New System.Drawing.Point(33, 40)
        Me.Label5.Margin = New System.Windows.Forms.Padding(0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(48, 18)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Fecha:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtFechaAux
        '
        Me.txtFechaAux.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtFechaAux.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtFechaAux.Location = New System.Drawing.Point(498, 244)
        Me.txtFechaAux.Mask = "LL-00000-000"
        Me.txtFechaAux.Name = "txtFechaAux"
        Me.txtFechaAux.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtFechaAux.Size = New System.Drawing.Size(79, 13)
        Me.txtFechaAux.TabIndex = 9
        Me.txtFechaAux.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtFechaAux.Visible = False
        '
        'dgvHistorial
        '
        Me.dgvHistorial.AllowUserToAddRows = False
        Me.dgvHistorial.AllowUserToDeleteRows = False
        Me.dgvHistorial.AllowUserToOrderColumns = True
        Me.dgvHistorial.AllowUserToResizeRows = False
        Me.dgvHistorial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvHistorial.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Fecha, Me.Observacion, Me.Usuario, Me.Clave, Me.FechaOrd, Me.NroObservacion})
        Me.dgvHistorial.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.dgvHistorial.Location = New System.Drawing.Point(23, 18)
        Me.dgvHistorial.MultiSelect = False
        Me.dgvHistorial.Name = "dgvHistorial"
        Me.dgvHistorial.Size = New System.Drawing.Size(574, 281)
        Me.dgvHistorial.TabIndex = 8
        '
        'Fecha
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Fecha.DefaultCellStyle = DataGridViewCellStyle1
        Me.Fecha.HeaderText = "Fecha"
        Me.Fecha.MaxInputLength = 12
        Me.Fecha.Name = "Fecha"
        Me.Fecha.ReadOnly = True
        Me.Fecha.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Fecha.Width = 80
        '
        'Observacion
        '
        Me.Observacion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.Observacion.DefaultCellStyle = DataGridViewCellStyle2
        Me.Observacion.HeaderText = "Observación"
        Me.Observacion.MaxInputLength = 100
        Me.Observacion.Name = "Observacion"
        Me.Observacion.ReadOnly = True
        Me.Observacion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Usuario
        '
        Me.Usuario.HeaderText = "Usuario"
        Me.Usuario.Name = "Usuario"
        Me.Usuario.ReadOnly = True
        Me.Usuario.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Clave
        '
        Me.Clave.HeaderText = "Clave"
        Me.Clave.Name = "Clave"
        Me.Clave.Visible = False
        '
        'FechaOrd
        '
        Me.FechaOrd.HeaderText = "FechaOrd"
        Me.FechaOrd.Name = "FechaOrd"
        Me.FechaOrd.Visible = False
        '
        'NroObservacion
        '
        Me.NroObservacion.HeaderText = "NroObservacion"
        Me.NroObservacion.Name = "NroObservacion"
        Me.NroObservacion.Visible = False
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.FromArgb(CType(CType(95, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(82, Byte), Integer))
        Me.TabPage2.Controls.Add(Me.MaskedTextBox1)
        Me.TabPage2.Controls.Add(Me.dgvArchivos)
        Me.TabPage2.Location = New System.Drawing.Point(4, 34)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(626, 311)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "ARCHIVOS RELACIONADOS"
        '
        'MaskedTextBox1
        '
        Me.MaskedTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.MaskedTextBox1.Location = New System.Drawing.Point(471, 241)
        Me.MaskedTextBox1.Mask = "LL-00000-000"
        Me.MaskedTextBox1.Name = "MaskedTextBox1"
        Me.MaskedTextBox1.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.MaskedTextBox1.Size = New System.Drawing.Size(79, 13)
        Me.MaskedTextBox1.TabIndex = 11
        Me.MaskedTextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.MaskedTextBox1.Visible = False
        '
        'dgvArchivos
        '
        Me.dgvArchivos.AllowDrop = True
        Me.dgvArchivos.AllowUserToAddRows = False
        Me.dgvArchivos.AllowUserToDeleteRows = False
        Me.dgvArchivos.AllowUserToOrderColumns = True
        Me.dgvArchivos.AllowUserToResizeRows = False
        Me.dgvArchivos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvArchivos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.FechaCreacion, Me.NombreArchivo, Me.Icono, Me.RutaArchivo})
        Me.dgvArchivos.ContextMenuStrip = Me.ContextMenuStrip1
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvArchivos.DefaultCellStyle = DataGridViewCellStyle5
        Me.dgvArchivos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.dgvArchivos.Location = New System.Drawing.Point(23, 18)
        Me.dgvArchivos.MultiSelect = False
        Me.dgvArchivos.Name = "dgvArchivos"
        Me.dgvArchivos.RowTemplate.Height = 40
        Me.dgvArchivos.Size = New System.Drawing.Size(574, 281)
        Me.dgvArchivos.TabIndex = 10
        '
        'FechaCreacion
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.FechaCreacion.DefaultCellStyle = DataGridViewCellStyle3
        Me.FechaCreacion.HeaderText = "Fecha de Creación"
        Me.FechaCreacion.MaxInputLength = 12
        Me.FechaCreacion.MinimumWidth = 100
        Me.FechaCreacion.Name = "FechaCreacion"
        Me.FechaCreacion.ReadOnly = True
        Me.FechaCreacion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.FechaCreacion.Width = 120
        '
        'NombreArchivo
        '
        Me.NombreArchivo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.NombreArchivo.DefaultCellStyle = DataGridViewCellStyle4
        Me.NombreArchivo.HeaderText = "Nombre de Archivo"
        Me.NombreArchivo.Name = "NombreArchivo"
        Me.NombreArchivo.ReadOnly = True
        Me.NombreArchivo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Icono
        '
        Me.Icono.HeaderText = ""
        Me.Icono.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom
        Me.Icono.Name = "Icono"
        Me.Icono.ReadOnly = True
        Me.Icono.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Icono.Width = 50
        '
        'RutaArchivo
        '
        Me.RutaArchivo.HeaderText = "Tipo"
        Me.RutaArchivo.Name = "RutaArchivo"
        Me.RutaArchivo.Visible = False
        Me.RutaArchivo.Width = 80
        '
        'TabPage3
        '
        Me.TabPage3.BackColor = System.Drawing.Color.FromArgb(CType(CType(95, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(82, Byte), Integer))
        Me.TabPage3.Controls.Add(Me.GrupoEspecificacion)
        Me.TabPage3.Controls.Add(Me.dgvEspecificaciones)
        Me.TabPage3.Location = New System.Drawing.Point(4, 34)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(626, 311)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "ESPECIFICACIONES"
        '
        'GrupoEspecificacion
        '
        Me.GrupoEspecificacion.Controls.Add(Me.txtUsuarioEspecificacion)
        Me.GrupoEspecificacion.Controls.Add(Me.cmbTipoEspecificacion)
        Me.GrupoEspecificacion.Controls.Add(Me.txtEspecificacion)
        Me.GrupoEspecificacion.Controls.Add(Me.WNroEspecificacion)
        Me.GrupoEspecificacion.Controls.Add(Me.btnEliminarEspecificacion)
        Me.GrupoEspecificacion.Controls.Add(Me.Label7)
        Me.GrupoEspecificacion.Controls.Add(Me.btnCerrarFormularioEspecificacion)
        Me.GrupoEspecificacion.Controls.Add(Me.btnEnviarEmailEspecificacion)
        Me.GrupoEspecificacion.Controls.Add(Me.btnLimpiarFormularioEspecificacion)
        Me.GrupoEspecificacion.Controls.Add(Me.Label10)
        Me.GrupoEspecificacion.Controls.Add(Me.Label8)
        Me.GrupoEspecificacion.Controls.Add(Me.txtFechaEspecificacion)
        Me.GrupoEspecificacion.Controls.Add(Me.btnAgregarEspecificacion)
        Me.GrupoEspecificacion.Controls.Add(Me.Label9)
        Me.GrupoEspecificacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GrupoEspecificacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrupoEspecificacion.ForeColor = System.Drawing.SystemColors.Control
        Me.GrupoEspecificacion.Location = New System.Drawing.Point(121, 44)
        Me.GrupoEspecificacion.Name = "GrupoEspecificacion"
        Me.GrupoEspecificacion.Size = New System.Drawing.Size(390, 251)
        Me.GrupoEspecificacion.TabIndex = 11
        Me.GrupoEspecificacion.TabStop = False
        Me.GrupoEspecificacion.Text = "Ingreso de Nueva Especificación"
        Me.GrupoEspecificacion.Visible = False
        '
        'txtUsuarioEspecificacion
        '
        Me.txtUsuarioEspecificacion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtUsuarioEspecificacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtUsuarioEspecificacion.Location = New System.Drawing.Point(248, 67)
        Me.txtUsuarioEspecificacion.MaxLength = 20
        Me.txtUsuarioEspecificacion.Name = "txtUsuarioEspecificacion"
        Me.txtUsuarioEspecificacion.Size = New System.Drawing.Size(123, 20)
        Me.txtUsuarioEspecificacion.TabIndex = 8
        '
        'cmbTipoEspecificacion
        '
        Me.cmbTipoEspecificacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoEspecificacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cmbTipoEspecificacion.FormattingEnabled = True
        Me.cmbTipoEspecificacion.Items.AddRange(New Object() {"", "Envase", "Entrega", "Varios"})
        Me.cmbTipoEspecificacion.Location = New System.Drawing.Point(248, 40)
        Me.cmbTipoEspecificacion.Name = "cmbTipoEspecificacion"
        Me.cmbTipoEspecificacion.Size = New System.Drawing.Size(123, 21)
        Me.cmbTipoEspecificacion.TabIndex = 7
        '
        'txtEspecificacion
        '
        Me.txtEspecificacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEspecificacion.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtEspecificacion.Location = New System.Drawing.Point(17, 94)
        Me.txtEspecificacion.MaxLength = 1000
        Me.txtEspecificacion.Multiline = True
        Me.txtEspecificacion.Name = "txtEspecificacion"
        Me.txtEspecificacion.Size = New System.Drawing.Size(357, 85)
        Me.txtEspecificacion.TabIndex = 0
        Me.ToolTip1.SetToolTip(Me.txtEspecificacion, "Descripción en Inglés del Monto Total")
        '
        'WNroEspecificacion
        '
        Me.WNroEspecificacion.BackColor = System.Drawing.SystemColors.Window
        Me.WNroEspecificacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.WNroEspecificacion.ForeColor = System.Drawing.SystemColors.ControlText
        Me.WNroEspecificacion.Location = New System.Drawing.Point(121, 67)
        Me.WNroEspecificacion.MaxLength = 20
        Me.WNroEspecificacion.Name = "WNroEspecificacion"
        Me.WNroEspecificacion.ReadOnly = True
        Me.WNroEspecificacion.Size = New System.Drawing.Size(19, 20)
        Me.WNroEspecificacion.TabIndex = 0
        Me.WNroEspecificacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.WNroEspecificacion.Visible = False
        '
        'btnEliminarEspecificacion
        '
        Me.btnEliminarEspecificacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEliminarEspecificacion.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnEliminarEspecificacion.Location = New System.Drawing.Point(92, 185)
        Me.btnEliminarEspecificacion.Name = "btnEliminarEspecificacion"
        Me.btnEliminarEspecificacion.Size = New System.Drawing.Size(68, 41)
        Me.btnEliminarEspecificacion.TabIndex = 0
        Me.btnEliminarEspecificacion.Text = "Eliminar"
        Me.ToolTip1.SetToolTip(Me.btnEliminarEspecificacion, "Eliminar Especificación")
        Me.btnEliminarEspecificacion.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label7.ForeColor = System.Drawing.SystemColors.Control
        Me.Label7.Location = New System.Drawing.Point(31, 68)
        Me.Label7.Margin = New System.Windows.Forms.Padding(0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(98, 18)
        Me.Label7.TabIndex = 3
        Me.Label7.Text = "Especificación:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnCerrarFormularioEspecificacion
        '
        Me.btnCerrarFormularioEspecificacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCerrarFormularioEspecificacion.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnCerrarFormularioEspecificacion.Location = New System.Drawing.Point(305, 185)
        Me.btnCerrarFormularioEspecificacion.Name = "btnCerrarFormularioEspecificacion"
        Me.btnCerrarFormularioEspecificacion.Size = New System.Drawing.Size(68, 41)
        Me.btnCerrarFormularioEspecificacion.TabIndex = 0
        Me.btnCerrarFormularioEspecificacion.Text = "Cerrar"
        Me.ToolTip1.SetToolTip(Me.btnCerrarFormularioEspecificacion, "Cerrar Formulario de Especificaciones")
        Me.btnCerrarFormularioEspecificacion.UseVisualStyleBackColor = True
        '
        'btnEnviarEmailEspecificacion
        '
        Me.btnEnviarEmailEspecificacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEnviarEmailEspecificacion.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnEnviarEmailEspecificacion.Location = New System.Drawing.Point(234, 185)
        Me.btnEnviarEmailEspecificacion.Name = "btnEnviarEmailEspecificacion"
        Me.btnEnviarEmailEspecificacion.Size = New System.Drawing.Size(68, 41)
        Me.btnEnviarEmailEspecificacion.TabIndex = 0
        Me.btnEnviarEmailEspecificacion.Text = "Enviar Email"
        Me.ToolTip1.SetToolTip(Me.btnEnviarEmailEspecificacion, "Enviar Especificación por Email")
        Me.btnEnviarEmailEspecificacion.UseVisualStyleBackColor = True
        '
        'btnLimpiarFormularioEspecificacion
        '
        Me.btnLimpiarFormularioEspecificacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLimpiarFormularioEspecificacion.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnLimpiarFormularioEspecificacion.Location = New System.Drawing.Point(163, 185)
        Me.btnLimpiarFormularioEspecificacion.Name = "btnLimpiarFormularioEspecificacion"
        Me.btnLimpiarFormularioEspecificacion.Size = New System.Drawing.Size(68, 41)
        Me.btnLimpiarFormularioEspecificacion.TabIndex = 0
        Me.btnLimpiarFormularioEspecificacion.Text = "Limpiar"
        Me.ToolTip1.SetToolTip(Me.btnLimpiarFormularioEspecificacion, "Limpiar Formulario")
        Me.btnLimpiarFormularioEspecificacion.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label10.ForeColor = System.Drawing.SystemColors.Control
        Me.Label10.Location = New System.Drawing.Point(183, 68)
        Me.Label10.Margin = New System.Windows.Forms.Padding(0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(60, 18)
        Me.Label10.TabIndex = 3
        Me.Label10.Text = "Usuario:"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label8.ForeColor = System.Drawing.SystemColors.Control
        Me.Label8.Location = New System.Drawing.Point(204, 40)
        Me.Label8.Margin = New System.Windows.Forms.Padding(0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(39, 18)
        Me.Label8.TabIndex = 3
        Me.Label8.Text = "Tipo:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtFechaEspecificacion
        '
        Me.txtFechaEspecificacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFechaEspecificacion.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtFechaEspecificacion.Location = New System.Drawing.Point(92, 39)
        Me.txtFechaEspecificacion.Mask = "00/00/0000"
        Me.txtFechaEspecificacion.Name = "txtFechaEspecificacion"
        Me.txtFechaEspecificacion.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtFechaEspecificacion.Size = New System.Drawing.Size(72, 20)
        Me.txtFechaEspecificacion.TabIndex = 6
        Me.txtFechaEspecificacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnAgregarEspecificacion
        '
        Me.btnAgregarEspecificacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAgregarEspecificacion.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnAgregarEspecificacion.Location = New System.Drawing.Point(18, 185)
        Me.btnAgregarEspecificacion.Name = "btnAgregarEspecificacion"
        Me.btnAgregarEspecificacion.Size = New System.Drawing.Size(71, 41)
        Me.btnAgregarEspecificacion.TabIndex = 0
        Me.btnAgregarEspecificacion.Text = "Aceptar"
        Me.ToolTip1.SetToolTip(Me.btnAgregarEspecificacion, "Grabar / Actualizar Especificación")
        Me.btnAgregarEspecificacion.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label9.ForeColor = System.Drawing.SystemColors.Control
        Me.Label9.Location = New System.Drawing.Point(33, 40)
        Me.Label9.Margin = New System.Windows.Forms.Padding(0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(48, 18)
        Me.Label9.TabIndex = 5
        Me.Label9.Text = "Fecha:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dgvEspecificaciones
        '
        Me.dgvEspecificaciones.AllowUserToAddRows = False
        Me.dgvEspecificaciones.AllowUserToDeleteRows = False
        Me.dgvEspecificaciones.AllowUserToOrderColumns = True
        Me.dgvEspecificaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvEspecificaciones.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.FechaEspecificacion, Me.Especificacion, Me.TipoEspecificacion, Me.UsuarioEspecificacion, Me.RenglonEspecificacion, Me.NroEspecificacion})
        Me.dgvEspecificaciones.Location = New System.Drawing.Point(23, 18)
        Me.dgvEspecificaciones.Name = "dgvEspecificaciones"
        Me.dgvEspecificaciones.ReadOnly = True
        Me.dgvEspecificaciones.Size = New System.Drawing.Size(574, 281)
        Me.dgvEspecificaciones.TabIndex = 0
        '
        'FechaEspecificacion
        '
        Me.FechaEspecificacion.HeaderText = "Fecha"
        Me.FechaEspecificacion.MaxInputLength = 10
        Me.FechaEspecificacion.Name = "FechaEspecificacion"
        Me.FechaEspecificacion.ReadOnly = True
        '
        'Especificacion
        '
        Me.Especificacion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Especificacion.HeaderText = "Especificacion"
        Me.Especificacion.MaxInputLength = 100
        Me.Especificacion.Name = "Especificacion"
        Me.Especificacion.ReadOnly = True
        '
        'TipoEspecificacion
        '
        Me.TipoEspecificacion.HeaderText = "Tipo"
        Me.TipoEspecificacion.Name = "TipoEspecificacion"
        Me.TipoEspecificacion.ReadOnly = True
        '
        'UsuarioEspecificacion
        '
        Me.UsuarioEspecificacion.HeaderText = "Usuario"
        Me.UsuarioEspecificacion.Name = "UsuarioEspecificacion"
        Me.UsuarioEspecificacion.ReadOnly = True
        '
        'RenglonEspecificacion
        '
        Me.RenglonEspecificacion.HeaderText = "Renglon"
        Me.RenglonEspecificacion.MaxInputLength = 3
        Me.RenglonEspecificacion.Name = "RenglonEspecificacion"
        Me.RenglonEspecificacion.ReadOnly = True
        Me.RenglonEspecificacion.Visible = False
        '
        'NroEspecificacion
        '
        Me.NroEspecificacion.HeaderText = "NroEspecificacion"
        Me.NroEspecificacion.Name = "NroEspecificacion"
        Me.NroEspecificacion.ReadOnly = True
        Me.NroEspecificacion.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label4.ForeColor = System.Drawing.SystemColors.Control
        Me.Label4.Location = New System.Drawing.Point(39, 14)
        Me.Label4.Margin = New System.Windows.Forms.Padding(0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(70, 18)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Proforma:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCliente
        '
        Me.txtCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtCliente.Location = New System.Drawing.Point(265, 13)
        Me.txtCliente.MaxLength = 6
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.ReadOnly = True
        Me.txtCliente.Size = New System.Drawing.Size(79, 20)
        Me.txtCliente.TabIndex = 0
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label6.ForeColor = System.Drawing.SystemColors.Control
        Me.Label6.Location = New System.Drawing.Point(207, 14)
        Me.Label6.Margin = New System.Windows.Forms.Padding(0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(57, 18)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "Cliente:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtDescripcionCliente
        '
        Me.txtDescripcionCliente.Enabled = False
        Me.txtDescripcionCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtDescripcionCliente.Location = New System.Drawing.Point(350, 13)
        Me.txtDescripcionCliente.Name = "txtDescripcionCliente"
        Me.txtDescripcionCliente.ReadOnly = True
        Me.txtDescripcionCliente.Size = New System.Drawing.Size(266, 20)
        Me.txtDescripcionCliente.TabIndex = 0
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.btnNuevaEspecificacion)
        Me.Panel2.Controls.Add(Me.btnNuevaObservacion)
        Me.Panel2.Controls.Add(Me.btnArchivos)
        Me.Panel2.Controls.Add(Me.btnCerrar)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(3, 407)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(648, 68)
        Me.Panel2.TabIndex = 3
        '
        'btnNuevaEspecificacion
        '
        Me.btnNuevaEspecificacion.Location = New System.Drawing.Point(334, 12)
        Me.btnNuevaEspecificacion.Name = "btnNuevaEspecificacion"
        Me.btnNuevaEspecificacion.Size = New System.Drawing.Size(88, 45)
        Me.btnNuevaEspecificacion.TabIndex = 1
        Me.btnNuevaEspecificacion.Text = "Nueva Especificación"
        Me.ToolTip1.SetToolTip(Me.btnNuevaEspecificacion, "Abrir Formulario para Agregar una nueva Especificación")
        Me.btnNuevaEspecificacion.UseVisualStyleBackColor = True
        '
        'btnNuevaObservacion
        '
        Me.btnNuevaObservacion.Location = New System.Drawing.Point(118, 12)
        Me.btnNuevaObservacion.Name = "btnNuevaObservacion"
        Me.btnNuevaObservacion.Size = New System.Drawing.Size(88, 45)
        Me.btnNuevaObservacion.TabIndex = 1
        Me.btnNuevaObservacion.Text = "Nueva Observación"
        Me.btnNuevaObservacion.UseVisualStyleBackColor = True
        '
        'btnArchivos
        '
        Me.btnArchivos.Location = New System.Drawing.Point(226, 12)
        Me.btnArchivos.Name = "btnArchivos"
        Me.btnArchivos.Size = New System.Drawing.Size(88, 45)
        Me.btnArchivos.TabIndex = 0
        Me.btnArchivos.Text = "Carpeta de Archivos"
        Me.ToolTip1.SetToolTip(Me.btnArchivos, "Abrir Carpeta de Archivos relacionados a la Proforma actual")
        Me.btnArchivos.UseVisualStyleBackColor = True
        '
        'btnCerrar
        '
        Me.btnCerrar.Location = New System.Drawing.Point(442, 14)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(88, 45)
        Me.btnCerrar.TabIndex = 0
        Me.btnCerrar.Text = "Cerrar"
        Me.ToolTip1.SetToolTip(Me.btnCerrar, "Cerrar Formulario")
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PegarArchivosToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(162, 26)
        '
        'PegarArchivosToolStripMenuItem
        '
        Me.PegarArchivosToolStripMenuItem.Name = "PegarArchivosToolStripMenuItem"
        Me.PegarArchivosToolStripMenuItem.Size = New System.Drawing.Size(161, 22)
        Me.PegarArchivosToolStripMenuItem.Text = "Pegar Archivo(s)"
        '
        'HistorialProforma
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(654, 523)
        Me.Controls.Add(Me.LayoutPrincipal)
        Me.MaximizeBox = False
        Me.Name = "HistorialProforma"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Proforma"
        Me.LayoutPrincipal.ResumeLayout(False)
        Me.LayoutCabecera.ResumeLayout(False)
        Me.LayoutCuerpoPrincipal.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.GrupoNuevaObs.ResumeLayout(False)
        Me.GrupoNuevaObs.PerformLayout()
        CType(Me.dgvHistorial, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        CType(Me.dgvArchivos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage3.ResumeLayout(False)
        Me.GrupoEspecificacion.ResumeLayout(False)
        Me.GrupoEspecificacion.PerformLayout()
        CType(Me.dgvEspecificaciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.ContextMenuStrip1.ResumeLayout(False)
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
    Friend WithEvents dgvHistorial As System.Windows.Forms.DataGridView
    Friend WithEvents txtFechaAux As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtUsuario As System.Windows.Forms.TextBox
    Friend WithEvents txtObservacion As System.Windows.Forms.TextBox
    Friend WithEvents WClaveObservacion As System.Windows.Forms.TextBox
    Friend WithEvents btnEliminar As System.Windows.Forms.Button
    Friend WithEvents btnArchivos As System.Windows.Forms.Button
    Friend WithEvents GrupoNuevaObs As System.Windows.Forms.GroupBox
    Friend WithEvents btnNuevaObservacion As System.Windows.Forms.Button
    Friend WithEvents btnCerrarFormObs As System.Windows.Forms.Button
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents MaskedTextBox1 As System.Windows.Forms.MaskedTextBox
    Friend WithEvents dgvArchivos As System.Windows.Forms.DataGridView
    Friend WithEvents Fecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Observacion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Usuario As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Clave As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FechaOrd As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NroObservacion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FechaCreacion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NombreArchivo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Icono As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents RutaArchivo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnEnviarPorEmail As System.Windows.Forms.Button
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents dgvEspecificaciones As System.Windows.Forms.DataGridView
    Friend WithEvents GrupoEspecificacion As System.Windows.Forms.GroupBox
    Friend WithEvents cmbTipoEspecificacion As System.Windows.Forms.ComboBox
    Friend WithEvents txtEspecificacion As System.Windows.Forms.TextBox
    Friend WithEvents WNroEspecificacion As System.Windows.Forms.TextBox
    Friend WithEvents btnEliminarEspecificacion As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btnCerrarFormularioEspecificacion As System.Windows.Forms.Button
    Friend WithEvents btnEnviarEmailEspecificacion As System.Windows.Forms.Button
    Friend WithEvents btnLimpiarFormularioEspecificacion As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtFechaEspecificacion As System.Windows.Forms.MaskedTextBox
    Friend WithEvents btnAgregarEspecificacion As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents btnNuevaEspecificacion As System.Windows.Forms.Button
    Friend WithEvents txtUsuarioEspecificacion As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents FechaEspecificacion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Especificacion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TipoEspecificacion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UsuarioEspecificacion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RenglonEspecificacion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NroEspecificacion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents PegarArchivosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
