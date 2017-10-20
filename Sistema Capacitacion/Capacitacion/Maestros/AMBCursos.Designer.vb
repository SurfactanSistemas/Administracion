<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AMBCursos
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
        Dim DataGridViewCellStyle21 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle22 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.LayoutPrincipal = New System.Windows.Forms.TableLayoutPanel()
        Me.LayoutCabecera = New System.Windows.Forms.TableLayoutPanel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnSiguienteRegistro = New System.Windows.Forms.Button()
        Me.btnPrimerRegistro = New System.Windows.Forms.Button()
        Me.btnUltimoRegistro = New System.Windows.Forms.Button()
        Me.btnAnteriorRegistro = New System.Windows.Forms.Button()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.btnPantalla = New System.Windows.Forms.Button()
        Me.btnConsulta = New System.Windows.Forms.Button()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.dgvCursos = New System.Windows.Forms.DataGridView()
        Me.Curso = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Horas = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtDescripcion = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtTema = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GrupoConsultaII = New System.Windows.Forms.GroupBox()
        Me.lstConsulta = New System.Windows.Forms.ListBox()
        Me.btnCerrarConsulta = New System.Windows.Forms.Button()
        Me.txtAyuda = New System.Windows.Forms.TextBox()
        Me.lstFiltrada = New System.Windows.Forms.ListBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.GrupoConsulta = New System.Windows.Forms.Panel()
        Me.GrupoImpresion = New System.Windows.Forms.Panel()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.ckIntervaloTemas = New System.Windows.Forms.RadioButton()
        Me.ckTodosTemas = New System.Windows.Forms.RadioButton()
        Me.ckTemaActual = New System.Windows.Forms.RadioButton()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.txtHasta = New System.Windows.Forms.TextBox()
        Me.txtDesde = New System.Windows.Forms.TextBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.LayoutPrincipal.SuspendLayout()
        Me.LayoutCabecera.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.dgvCursos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrupoConsultaII.SuspendLayout()
        Me.GrupoConsulta.SuspendLayout()
        Me.GrupoImpresion.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'LayoutPrincipal
        '
        Me.LayoutPrincipal.BackColor = System.Drawing.SystemColors.Control
        Me.LayoutPrincipal.ColumnCount = 1
        Me.LayoutPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.LayoutPrincipal.Controls.Add(Me.LayoutCabecera, 0, 0)
        Me.LayoutPrincipal.Controls.Add(Me.Panel2, 0, 2)
        Me.LayoutPrincipal.Controls.Add(Me.Panel1, 0, 1)
        Me.LayoutPrincipal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutPrincipal.Location = New System.Drawing.Point(0, 0)
        Me.LayoutPrincipal.Margin = New System.Windows.Forms.Padding(0)
        Me.LayoutPrincipal.Name = "LayoutPrincipal"
        Me.LayoutPrincipal.RowCount = 3
        Me.LayoutPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45.0!))
        Me.LayoutPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.LayoutPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 97.0!))
        Me.LayoutPrincipal.Size = New System.Drawing.Size(711, 438)
        Me.LayoutPrincipal.TabIndex = 2
        '
        'LayoutCabecera
        '
        Me.LayoutCabecera.BackColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.LayoutCabecera.ColumnCount = 3
        Me.LayoutCabecera.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 270.0!))
        Me.LayoutCabecera.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.LayoutCabecera.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 180.0!))
        Me.LayoutCabecera.Controls.Add(Me.Label3, 0, 0)
        Me.LayoutCabecera.Controls.Add(Me.Label2, 2, 0)
        Me.LayoutCabecera.Controls.Add(Me.Label1, 0, 0)
        Me.LayoutCabecera.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutCabecera.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold)
        Me.LayoutCabecera.ForeColor = System.Drawing.SystemColors.Control
        Me.LayoutCabecera.Location = New System.Drawing.Point(0, 0)
        Me.LayoutCabecera.Margin = New System.Windows.Forms.Padding(0)
        Me.LayoutCabecera.Name = "LayoutCabecera"
        Me.LayoutCabecera.RowCount = 1
        Me.LayoutCabecera.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.LayoutCabecera.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45.0!))
        Me.LayoutCabecera.Size = New System.Drawing.Size(711, 45)
        Me.LayoutCabecera.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label3.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.Location = New System.Drawing.Point(270, 0)
        Me.Label3.Margin = New System.Windows.Forms.Padding(0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(261, 45)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "- Ingreso de Cursos -"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Font = New System.Drawing.Font("Calibri", 14.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Margin = New System.Windows.Forms.Padding(0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(270, 45)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Sistema de Capacitaciones"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label2.Font = New System.Drawing.Font("Calibri", 16.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(534, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(174, 45)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "SURFACTAN S.A."
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.GroupBox1)
        Me.Panel2.Controls.Add(Me.btnCerrar)
        Me.Panel2.Controls.Add(Me.btnPantalla)
        Me.Panel2.Controls.Add(Me.btnConsulta)
        Me.Panel2.Controls.Add(Me.btnLimpiar)
        Me.Panel2.Controls.Add(Me.btnEliminar)
        Me.Panel2.Controls.Add(Me.btnAceptar)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(3, 344)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(705, 91)
        Me.Panel2.TabIndex = 2
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox1.Controls.Add(Me.btnSiguienteRegistro)
        Me.GroupBox1.Controls.Add(Me.btnPrimerRegistro)
        Me.GroupBox1.Controls.Add(Me.btnUltimoRegistro)
        Me.GroupBox1.Controls.Add(Me.btnAnteriorRegistro)
        Me.GroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBox1.Location = New System.Drawing.Point(492, 5)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(200, 78)
        Me.GroupBox1.TabIndex = 22
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Navegar por Tareas"
        '
        'btnSiguienteRegistro
        '
        Me.btnSiguienteRegistro.BackgroundImage = Global.Capacitacion.My.Resources.Resources.SiguienteRegistro
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
        Me.btnPrimerRegistro.BackgroundImage = Global.Capacitacion.My.Resources.Resources.PrimerRegistro
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
        Me.btnUltimoRegistro.BackgroundImage = Global.Capacitacion.My.Resources.Resources.UltimoRegistro
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
        Me.ToolTip1.SetToolTip(Me.btnUltimoRegistro, "Último registro")
        Me.btnUltimoRegistro.UseVisualStyleBackColor = True
        '
        'btnAnteriorRegistro
        '
        Me.btnAnteriorRegistro.BackgroundImage = Global.Capacitacion.My.Resources.Resources.AnteriorRegistro
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
        'btnCerrar
        '
        Me.btnCerrar.BackgroundImage = Global.Capacitacion.My.Resources.Resources.Salir2
        Me.btnCerrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCerrar.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnCerrar.FlatAppearance.BorderSize = 0
        Me.btnCerrar.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.Control
        Me.btnCerrar.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control
        Me.btnCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control
        Me.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCerrar.Location = New System.Drawing.Point(413, 21)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(66, 47)
        Me.btnCerrar.TabIndex = 0
        Me.ToolTip1.SetToolTip(Me.btnCerrar, "Cerrar Formulario")
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'btnPantalla
        '
        Me.btnPantalla.BackgroundImage = Global.Capacitacion.My.Resources.Resources.Screen_preview
        Me.btnPantalla.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnPantalla.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnPantalla.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnPantalla.FlatAppearance.BorderSize = 0
        Me.btnPantalla.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.Control
        Me.btnPantalla.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control
        Me.btnPantalla.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control
        Me.btnPantalla.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPantalla.Location = New System.Drawing.Point(334, 21)
        Me.btnPantalla.Name = "btnPantalla"
        Me.btnPantalla.Size = New System.Drawing.Size(66, 47)
        Me.btnPantalla.TabIndex = 0
        Me.ToolTip1.SetToolTip(Me.btnPantalla, "Listado de Sectores por Pantalla")
        Me.btnPantalla.UseVisualStyleBackColor = True
        '
        'btnConsulta
        '
        Me.btnConsulta.BackgroundImage = Global.Capacitacion.My.Resources.Resources.Consulta_Dat_N1
        Me.btnConsulta.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnConsulta.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnConsulta.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnConsulta.FlatAppearance.BorderSize = 0
        Me.btnConsulta.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.Control
        Me.btnConsulta.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control
        Me.btnConsulta.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control
        Me.btnConsulta.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnConsulta.Location = New System.Drawing.Point(255, 21)
        Me.btnConsulta.Name = "btnConsulta"
        Me.btnConsulta.Size = New System.Drawing.Size(66, 47)
        Me.btnConsulta.TabIndex = 0
        Me.ToolTip1.SetToolTip(Me.btnConsulta, "Consultar Sectores")
        Me.btnConsulta.UseVisualStyleBackColor = True
        '
        'btnLimpiar
        '
        Me.btnLimpiar.BackgroundImage = Global.Capacitacion.My.Resources.Resources.Limpiar
        Me.btnLimpiar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnLimpiar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnLimpiar.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnLimpiar.FlatAppearance.BorderSize = 0
        Me.btnLimpiar.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.Control
        Me.btnLimpiar.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control
        Me.btnLimpiar.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control
        Me.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLimpiar.Location = New System.Drawing.Point(176, 21)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(66, 47)
        Me.btnLimpiar.TabIndex = 0
        Me.ToolTip1.SetToolTip(Me.btnLimpiar, "Limpiar Formulario")
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'btnEliminar
        '
        Me.btnEliminar.BackgroundImage = Global.Capacitacion.My.Resources.Resources.eliminar
        Me.btnEliminar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnEliminar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnEliminar.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnEliminar.FlatAppearance.BorderSize = 0
        Me.btnEliminar.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.Control
        Me.btnEliminar.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control
        Me.btnEliminar.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control
        Me.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEliminar.Location = New System.Drawing.Point(97, 21)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(66, 47)
        Me.btnEliminar.TabIndex = 0
        Me.ToolTip1.SetToolTip(Me.btnEliminar, "Eliminar Sector")
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'btnAceptar
        '
        Me.btnAceptar.BackgroundImage = Global.Capacitacion.My.Resources.Resources.Aceptar_N2
        Me.btnAceptar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnAceptar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAceptar.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnAceptar.FlatAppearance.BorderSize = 0
        Me.btnAceptar.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.Control
        Me.btnAceptar.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control
        Me.btnAceptar.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control
        Me.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAceptar.Location = New System.Drawing.Point(18, 21)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(66, 47)
        Me.btnAceptar.TabIndex = 0
        Me.ToolTip1.SetToolTip(Me.btnAceptar, "Grabar / Actualizar Sector")
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(95, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(82, Byte), Integer))
        Me.Panel1.Controls.Add(Me.dgvCursos)
        Me.Panel1.Controls.Add(Me.txtDescripcion)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.txtTema)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 45)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(711, 296)
        Me.Panel1.TabIndex = 1
        '
        'dgvCursos
        '
        Me.dgvCursos.AllowUserToAddRows = False
        Me.dgvCursos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCursos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Curso, Me.Descripcion, Me.Horas})
        Me.dgvCursos.Location = New System.Drawing.Point(24, 56)
        Me.dgvCursos.Name = "dgvCursos"
        Me.dgvCursos.Size = New System.Drawing.Size(663, 206)
        Me.dgvCursos.TabIndex = 2
        '
        'Curso
        '
        DataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Curso.DefaultCellStyle = DataGridViewCellStyle21
        Me.Curso.HeaderText = "Curso"
        Me.Curso.Name = "Curso"
        Me.Curso.Width = 50
        '
        'Descripcion
        '
        Me.Descripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Descripcion.HeaderText = "Decripcion"
        Me.Descripcion.Name = "Descripcion"
        '
        'Horas
        '
        DataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Horas.DefaultCellStyle = DataGridViewCellStyle22
        Me.Horas.HeaderText = "Cant. Hs"
        Me.Horas.Name = "Horas"
        '
        'txtDescripcion
        '
        Me.txtDescripcion.BackColor = System.Drawing.SystemColors.Window
        Me.txtDescripcion.Enabled = False
        Me.txtDescripcion.Location = New System.Drawing.Point(291, 20)
        Me.txtDescripcion.MaxLength = 90
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.ReadOnly = True
        Me.txtDescripcion.Size = New System.Drawing.Size(347, 20)
        Me.txtDescripcion.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label5.ForeColor = System.Drawing.SystemColors.Control
        Me.Label5.Location = New System.Drawing.Point(213, 24)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(78, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Descripción:"
        '
        'txtTema
        '
        Me.txtTema.Location = New System.Drawing.Point(131, 20)
        Me.txtTema.Name = "txtTema"
        Me.txtTema.Size = New System.Drawing.Size(80, 20)
        Me.txtTema.TabIndex = 1
        Me.txtTema.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label4.ForeColor = System.Drawing.SystemColors.Control
        Me.Label4.Location = New System.Drawing.Point(79, 24)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(42, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Tema:"
        '
        'GrupoConsultaII
        '
        Me.GrupoConsultaII.BackColor = System.Drawing.Color.FromArgb(CType(CType(95, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(82, Byte), Integer))
        Me.GrupoConsultaII.Controls.Add(Me.lstConsulta)
        Me.GrupoConsultaII.Controls.Add(Me.btnCerrarConsulta)
        Me.GrupoConsultaII.Controls.Add(Me.txtAyuda)
        Me.GrupoConsultaII.Controls.Add(Me.lstFiltrada)
        Me.GrupoConsultaII.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GrupoConsultaII.ForeColor = System.Drawing.SystemColors.Control
        Me.GrupoConsultaII.Location = New System.Drawing.Point(20, 19)
        Me.GrupoConsultaII.Name = "GrupoConsultaII"
        Me.GrupoConsultaII.Size = New System.Drawing.Size(334, 208)
        Me.GrupoConsultaII.TabIndex = 3
        Me.GrupoConsultaII.TabStop = False
        Me.GrupoConsultaII.Text = "Consultas de Temas"
        '
        'lstConsulta
        '
        Me.lstConsulta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lstConsulta.FormattingEnabled = True
        Me.lstConsulta.Location = New System.Drawing.Point(13, 50)
        Me.lstConsulta.Name = "lstConsulta"
        Me.lstConsulta.Size = New System.Drawing.Size(308, 121)
        Me.lstConsulta.TabIndex = 1
        '
        'btnCerrarConsulta
        '
        Me.btnCerrarConsulta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.btnCerrarConsulta.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnCerrarConsulta.Location = New System.Drawing.Point(130, 179)
        Me.btnCerrarConsulta.Name = "btnCerrarConsulta"
        Me.btnCerrarConsulta.Size = New System.Drawing.Size(75, 23)
        Me.btnCerrarConsulta.TabIndex = 3
        Me.btnCerrarConsulta.Text = "Cerrar"
        Me.ToolTip1.SetToolTip(Me.btnCerrarConsulta, "Cerrar Ventana de Consulta")
        Me.btnCerrarConsulta.UseVisualStyleBackColor = True
        '
        'txtAyuda
        '
        Me.txtAyuda.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtAyuda.Location = New System.Drawing.Point(13, 24)
        Me.txtAyuda.Name = "txtAyuda"
        Me.txtAyuda.Size = New System.Drawing.Size(308, 20)
        Me.txtAyuda.TabIndex = 2
        '
        'lstFiltrada
        '
        Me.lstFiltrada.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lstFiltrada.FormattingEnabled = True
        Me.lstFiltrada.Location = New System.Drawing.Point(13, 50)
        Me.lstFiltrada.Name = "lstFiltrada"
        Me.lstFiltrada.Size = New System.Drawing.Size(308, 121)
        Me.lstFiltrada.TabIndex = 0
        '
        'GrupoConsulta
        '
        Me.GrupoConsulta.BackColor = System.Drawing.Color.FromArgb(CType(CType(95, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(82, Byte), Integer))
        Me.GrupoConsulta.Controls.Add(Me.GrupoConsultaII)
        Me.GrupoConsulta.Location = New System.Drawing.Point(168, 99)
        Me.GrupoConsulta.Name = "GrupoConsulta"
        Me.GrupoConsulta.Size = New System.Drawing.Size(375, 241)
        Me.GrupoConsulta.TabIndex = 4
        Me.GrupoConsulta.Visible = False
        '
        'GrupoImpresion
        '
        Me.GrupoImpresion.BackColor = System.Drawing.Color.FromArgb(CType(CType(95, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(82, Byte), Integer))
        Me.GrupoImpresion.Controls.Add(Me.GroupBox2)
        Me.GrupoImpresion.Location = New System.Drawing.Point(163, 158)
        Me.GrupoImpresion.Name = "GrupoImpresion"
        Me.GrupoImpresion.Size = New System.Drawing.Size(385, 123)
        Me.GrupoImpresion.TabIndex = 6
        Me.GrupoImpresion.Visible = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.GroupBox3)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Button2)
        Me.GroupBox2.Controls.Add(Me.Button1)
        Me.GroupBox2.Controls.Add(Me.txtHasta)
        Me.GroupBox2.Controls.Add(Me.txtDesde)
        Me.GroupBox2.ForeColor = System.Drawing.SystemColors.Control
        Me.GroupBox2.Location = New System.Drawing.Point(8, 3)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(368, 116)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.ckIntervaloTemas)
        Me.GroupBox3.Controls.Add(Me.ckTodosTemas)
        Me.GroupBox3.Controls.Add(Me.ckTemaActual)
        Me.GroupBox3.ForeColor = System.Drawing.SystemColors.Control
        Me.GroupBox3.Location = New System.Drawing.Point(12, 13)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox3.Size = New System.Drawing.Size(170, 91)
        Me.GroupBox3.TabIndex = 3
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Tipo Reporte"
        '
        'ckIntervaloTemas
        '
        Me.ckIntervaloTemas.AutoSize = True
        Me.ckIntervaloTemas.Location = New System.Drawing.Point(18, 61)
        Me.ckIntervaloTemas.Name = "ckIntervaloTemas"
        Me.ckIntervaloTemas.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ckIntervaloTemas.Size = New System.Drawing.Size(135, 17)
        Me.ckIntervaloTemas.TabIndex = 0
        Me.ckIntervaloTemas.Text = "Por Intervalo de Temas"
        Me.ckIntervaloTemas.UseVisualStyleBackColor = True
        '
        'ckTodosTemas
        '
        Me.ckTodosTemas.AutoSize = True
        Me.ckTodosTemas.Location = New System.Drawing.Point(18, 42)
        Me.ckTodosTemas.Name = "ckTodosTemas"
        Me.ckTodosTemas.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ckTodosTemas.Size = New System.Drawing.Size(106, 17)
        Me.ckTodosTemas.TabIndex = 0
        Me.ckTodosTemas.Text = "Todos los Temas"
        Me.ckTodosTemas.UseVisualStyleBackColor = True
        '
        'ckTemaActual
        '
        Me.ckTemaActual.AutoSize = True
        Me.ckTemaActual.Checked = True
        Me.ckTemaActual.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.ckTemaActual.Location = New System.Drawing.Point(18, 23)
        Me.ckTemaActual.Name = "ckTemaActual"
        Me.ckTemaActual.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ckTemaActual.Size = New System.Drawing.Size(99, 17)
        Me.ckTemaActual.TabIndex = 0
        Me.ckTemaActual.TabStop = True
        Me.ckTemaActual.Text = "Sólo este Tema"
        Me.ckTemaActual.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label7.Location = New System.Drawing.Point(199, 49)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(79, 13)
        Me.Label7.TabIndex = 2
        Me.Label7.Text = "Hasta Tema:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label6.Location = New System.Drawing.Point(196, 23)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(82, 13)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "Desde Tema:"
        '
        'Button1
        '
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.ForeColor = System.Drawing.SystemColors.Control
        Me.Button1.Location = New System.Drawing.Point(191, 74)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(99, 23)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Generar Reporte"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'txtHasta
        '
        Me.txtHasta.Location = New System.Drawing.Point(278, 46)
        Me.txtHasta.Name = "txtHasta"
        Me.txtHasta.Size = New System.Drawing.Size(67, 20)
        Me.txtHasta.TabIndex = 0
        '
        'txtDesde
        '
        Me.txtDesde.Location = New System.Drawing.Point(278, 20)
        Me.txtDesde.Name = "txtDesde"
        Me.txtDesde.Size = New System.Drawing.Size(67, 20)
        Me.txtDesde.TabIndex = 0
        '
        'Button2
        '
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.ForeColor = System.Drawing.SystemColors.Control
        Me.Button2.Location = New System.Drawing.Point(296, 74)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(64, 23)
        Me.Button2.TabIndex = 1
        Me.Button2.Text = "Cancelar"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'AMBCursos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(711, 438)
        Me.Controls.Add(Me.GrupoImpresion)
        Me.Controls.Add(Me.GrupoConsulta)
        Me.Controls.Add(Me.LayoutPrincipal)
        Me.Name = "AMBCursos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.LayoutPrincipal.ResumeLayout(False)
        Me.LayoutCabecera.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dgvCursos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrupoConsultaII.ResumeLayout(False)
        Me.GrupoConsultaII.PerformLayout()
        Me.GrupoConsulta.ResumeLayout(False)
        Me.GrupoImpresion.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LayoutPrincipal As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents LayoutCabecera As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtTema As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents btnPantalla As System.Windows.Forms.Button
    Friend WithEvents btnConsulta As System.Windows.Forms.Button
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents btnEliminar As System.Windows.Forms.Button
    Friend WithEvents GrupoConsultaII As System.Windows.Forms.GroupBox
    Friend WithEvents txtAyuda As System.Windows.Forms.TextBox
    Friend WithEvents lstConsulta As System.Windows.Forms.ListBox
    Friend WithEvents lstFiltrada As System.Windows.Forms.ListBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents btnCerrarConsulta As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnSiguienteRegistro As System.Windows.Forms.Button
    Friend WithEvents btnPrimerRegistro As System.Windows.Forms.Button
    Friend WithEvents btnUltimoRegistro As System.Windows.Forms.Button
    Friend WithEvents btnAnteriorRegistro As System.Windows.Forms.Button
    Friend WithEvents GrupoConsulta As System.Windows.Forms.Panel
    Friend WithEvents dgvCursos As System.Windows.Forms.DataGridView
    Friend WithEvents Curso As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Descripcion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Horas As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GrupoImpresion As System.Windows.Forms.Panel
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents ckIntervaloTemas As System.Windows.Forms.RadioButton
    Friend WithEvents ckTodosTemas As System.Windows.Forms.RadioButton
    Friend WithEvents ckTemaActual As System.Windows.Forms.RadioButton
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents txtHasta As System.Windows.Forms.TextBox
    Friend WithEvents txtDesde As System.Windows.Forms.TextBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
End Class
