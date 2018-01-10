<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.TableLayoutPrincipal = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btnImprimir = New System.Windows.Forms.Button()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.btnConsultas = New System.Windows.Forms.Button()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.TableLayoutCabecera = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.txtNombres = New System.Windows.Forms.TextBox()
        Me.txtDescProveedor = New System.Windows.Forms.TextBox()
        Me.txtObservaciones = New System.Windows.Forms.TextBox()
        Me.txtProveedor = New System.Windows.Forms.TextBox()
        Me.txtApellido = New System.Windows.Forms.TextBox()
        Me.txtNroDocumento = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.pnlFotoFinal = New System.Windows.Forms.Panel()
        Me.picFoto = New System.Windows.Forms.PictureBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.pnlConsulta = New System.Windows.Forms.Panel()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lstFiltrada = New System.Windows.Forms.ListBox()
        Me.btnCerrarConsulta = New System.Windows.Forms.Button()
        Me.txtAyuda = New System.Windows.Forms.TextBox()
        Me.lstConsulta = New System.Windows.Forms.ListBox()
        Me.cmbIndices = New System.Windows.Forms.ComboBox()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.TableLayoutPrincipal.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.TableLayoutCabecera.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.pnlFotoFinal.SuspendLayout()
        CType(Me.picFoto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlConsulta.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPrincipal
        '
        Me.TableLayoutPrincipal.ColumnCount = 1
        Me.TableLayoutPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPrincipal.Controls.Add(Me.Panel4, 0, 2)
        Me.TableLayoutPrincipal.Controls.Add(Me.TableLayoutCabecera, 0, 0)
        Me.TableLayoutPrincipal.Controls.Add(Me.Panel3, 0, 1)
        Me.TableLayoutPrincipal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPrincipal.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPrincipal.Name = "TableLayoutPrincipal"
        Me.TableLayoutPrincipal.RowCount = 3
        Me.TableLayoutPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60.0!))
        Me.TableLayoutPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70.0!))
        Me.TableLayoutPrincipal.Size = New System.Drawing.Size(844, 371)
        Me.TableLayoutPrincipal.TabIndex = 0
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.btnImprimir)
        Me.Panel4.Controls.Add(Me.btnCerrar)
        Me.Panel4.Controls.Add(Me.btnLimpiar)
        Me.Panel4.Controls.Add(Me.btnConsultas)
        Me.Panel4.Controls.Add(Me.btnEliminar)
        Me.Panel4.Controls.Add(Me.btnGuardar)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(0, 301)
        Me.Panel4.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(844, 70)
        Me.Panel4.TabIndex = 2
        '
        'Button2
        '
        Me.Button2.BackgroundImage = Global.Identificaciones.My.Resources.Resources.camara_reflex
        Me.Button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Button2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(95, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(82, Byte), Integer))
        Me.Button2.FlatAppearance.BorderSize = 0
        Me.Button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(95, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(82, Byte), Integer))
        Me.Button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(95, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(82, Byte), Integer))
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Location = New System.Drawing.Point(800, 61)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(39, 26)
        Me.Button2.TabIndex = 0
        Me.ToolTip1.SetToolTip(Me.Button2, "Tomar Imagen con Camara Web")
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.BackgroundImage = Global.Identificaciones.My.Resources.Resources.Folder
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(95, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(82, Byte), Integer))
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(95, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(82, Byte), Integer))
        Me.Button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(95, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(82, Byte), Integer))
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Location = New System.Drawing.Point(800, 28)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(39, 26)
        Me.Button1.TabIndex = 0
        Me.ToolTip1.SetToolTip(Me.Button1, "Cargar Imagen desde Archivo")
        Me.Button1.UseVisualStyleBackColor = True
        '
        'btnImprimir
        '
        Me.btnImprimir.Location = New System.Drawing.Point(630, 19)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(83, 39)
        Me.btnImprimir.TabIndex = 0
        Me.btnImprimir.Text = "Imprimir Credencial"
        Me.ToolTip1.SetToolTip(Me.btnImprimir, "Imprimir Credencial")
        Me.btnImprimir.UseVisualStyleBackColor = True
        '
        'btnCerrar
        '
        Me.btnCerrar.Location = New System.Drawing.Point(526, 19)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(83, 39)
        Me.btnCerrar.TabIndex = 0
        Me.btnCerrar.Text = "Cerrar"
        Me.ToolTip1.SetToolTip(Me.btnCerrar, "Cerrar Formulario")
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Location = New System.Drawing.Point(422, 19)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(83, 39)
        Me.btnLimpiar.TabIndex = 0
        Me.btnLimpiar.Text = "Limpiar"
        Me.ToolTip1.SetToolTip(Me.btnLimpiar, "Limpiar Campos")
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'btnConsultas
        '
        Me.btnConsultas.Location = New System.Drawing.Point(318, 19)
        Me.btnConsultas.Name = "btnConsultas"
        Me.btnConsultas.Size = New System.Drawing.Size(83, 39)
        Me.btnConsultas.TabIndex = 0
        Me.btnConsultas.Text = "Consulta"
        Me.ToolTip1.SetToolTip(Me.btnConsultas, "Consulta de Proveedores")
        Me.btnConsultas.UseVisualStyleBackColor = True
        '
        'btnEliminar
        '
        Me.btnEliminar.Location = New System.Drawing.Point(214, 19)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(83, 39)
        Me.btnEliminar.TabIndex = 0
        Me.btnEliminar.Text = "Eliminar"
        Me.ToolTip1.SetToolTip(Me.btnEliminar, "Eliminar Identificación actual")
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'btnGuardar
        '
        Me.btnGuardar.Location = New System.Drawing.Point(110, 19)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(83, 39)
        Me.btnGuardar.TabIndex = 0
        Me.btnGuardar.Text = "Guardar"
        Me.ToolTip1.SetToolTip(Me.btnGuardar, "Guardar / Actualizar Identificación")
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'TableLayoutCabecera
        '
        Me.TableLayoutCabecera.ColumnCount = 2
        Me.TableLayoutCabecera.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutCabecera.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 300.0!))
        Me.TableLayoutCabecera.Controls.Add(Me.Panel2, 1, 0)
        Me.TableLayoutCabecera.Controls.Add(Me.Panel1, 0, 0)
        Me.TableLayoutCabecera.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutCabecera.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutCabecera.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutCabecera.Name = "TableLayoutCabecera"
        Me.TableLayoutCabecera.RowCount = 1
        Me.TableLayoutCabecera.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutCabecera.Size = New System.Drawing.Size(844, 60)
        Me.TableLayoutCabecera.TabIndex = 0
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(544, 0)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(300, 60)
        Me.Panel2.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Calibri", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.SystemColors.Control
        Me.Label2.Location = New System.Drawing.Point(79, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(143, 24)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "SURFACTAN S.A."
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(544, 60)
        Me.Panel1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Calibri", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.SystemColors.Control
        Me.Label1.Location = New System.Drawing.Point(34, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(364, 24)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "IDENTIFICACIONES          - Menú Principal -"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(95, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(82, Byte), Integer))
        Me.Panel3.Controls.Add(Me.Button2)
        Me.Panel3.Controls.Add(Me.txtNombres)
        Me.Panel3.Controls.Add(Me.Button1)
        Me.Panel3.Controls.Add(Me.txtDescProveedor)
        Me.Panel3.Controls.Add(Me.txtObservaciones)
        Me.Panel3.Controls.Add(Me.txtProveedor)
        Me.Panel3.Controls.Add(Me.txtApellido)
        Me.Panel3.Controls.Add(Me.txtNroDocumento)
        Me.Panel3.Controls.Add(Me.Label7)
        Me.Panel3.Controls.Add(Me.Label6)
        Me.Panel3.Controls.Add(Me.Label5)
        Me.Panel3.Controls.Add(Me.Label4)
        Me.Panel3.Controls.Add(Me.Label3)
        Me.Panel3.Controls.Add(Me.GroupBox1)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 60)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(844, 241)
        Me.Panel3.TabIndex = 1
        '
        'txtNombres
        '
        Me.txtNombres.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.txtNombres.Location = New System.Drawing.Point(365, 59)
        Me.txtNombres.MaxLength = 50
        Me.txtNombres.Name = "txtNombres"
        Me.txtNombres.Size = New System.Drawing.Size(182, 23)
        Me.txtNombres.TabIndex = 2
        '
        'txtDescProveedor
        '
        Me.txtDescProveedor.BackColor = System.Drawing.SystemColors.Control
        Me.txtDescProveedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.txtDescProveedor.Location = New System.Drawing.Point(247, 91)
        Me.txtDescProveedor.Name = "txtDescProveedor"
        Me.txtDescProveedor.ReadOnly = True
        Me.txtDescProveedor.Size = New System.Drawing.Size(300, 23)
        Me.txtDescProveedor.TabIndex = 2
        '
        'txtObservaciones
        '
        Me.txtObservaciones.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.txtObservaciones.Location = New System.Drawing.Point(139, 126)
        Me.txtObservaciones.MaxLength = 400
        Me.txtObservaciones.Multiline = True
        Me.txtObservaciones.Name = "txtObservaciones"
        Me.txtObservaciones.Size = New System.Drawing.Size(408, 86)
        Me.txtObservaciones.TabIndex = 2
        '
        'txtProveedor
        '
        Me.txtProveedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.txtProveedor.Location = New System.Drawing.Point(139, 91)
        Me.txtProveedor.MaxLength = 11
        Me.txtProveedor.Name = "txtProveedor"
        Me.txtProveedor.Size = New System.Drawing.Size(102, 23)
        Me.txtProveedor.TabIndex = 2
        '
        'txtApellido
        '
        Me.txtApellido.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.txtApellido.Location = New System.Drawing.Point(139, 59)
        Me.txtApellido.MaxLength = 30
        Me.txtApellido.Name = "txtApellido"
        Me.txtApellido.Size = New System.Drawing.Size(137, 23)
        Me.txtApellido.TabIndex = 2
        '
        'txtNroDocumento
        '
        Me.txtNroDocumento.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.txtNroDocumento.Location = New System.Drawing.Point(139, 26)
        Me.txtNroDocumento.MaxLength = 8
        Me.txtNroDocumento.Name = "txtNroDocumento"
        Me.txtNroDocumento.Size = New System.Drawing.Size(137, 23)
        Me.txtNroDocumento.TabIndex = 2
        Me.txtNroDocumento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label7.ForeColor = System.Drawing.SystemColors.Control
        Me.Label7.Location = New System.Drawing.Point(34, 128)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(99, 18)
        Me.Label7.TabIndex = 1
        Me.Label7.Text = "Observaciones"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label6.ForeColor = System.Drawing.SystemColors.Control
        Me.Label6.Location = New System.Drawing.Point(284, 61)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(71, 18)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "Nombre/s"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label5.ForeColor = System.Drawing.SystemColors.Control
        Me.Label5.Location = New System.Drawing.Point(60, 93)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(73, 18)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Proveedor"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label4.ForeColor = System.Drawing.SystemColors.Control
        Me.Label4.Location = New System.Drawing.Point(60, 61)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(73, 18)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Apellido/s"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label3.ForeColor = System.Drawing.SystemColors.Control
        Me.Label3.Location = New System.Drawing.Point(27, 28)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(106, 18)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Nro Documento"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.pnlFotoFinal)
        Me.GroupBox1.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.GroupBox1.ForeColor = System.Drawing.SystemColors.Control
        Me.GroupBox1.Location = New System.Drawing.Point(565, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(231, 228)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Foto"
        '
        'pnlFotoFinal
        '
        Me.pnlFotoFinal.BackColor = System.Drawing.Color.Transparent
        Me.pnlFotoFinal.Controls.Add(Me.picFoto)
        Me.pnlFotoFinal.Location = New System.Drawing.Point(15, 20)
        Me.pnlFotoFinal.Name = "pnlFotoFinal"
        Me.pnlFotoFinal.Size = New System.Drawing.Size(200, 200)
        Me.pnlFotoFinal.TabIndex = 0
        '
        'picFoto
        '
        Me.picFoto.Cursor = System.Windows.Forms.Cursors.Hand
        Me.picFoto.Image = Global.Identificaciones.My.Resources.Resources.sin_imagen
        Me.picFoto.Location = New System.Drawing.Point(2, 2)
        Me.picFoto.Name = "picFoto"
        Me.picFoto.Size = New System.Drawing.Size(198, 198)
        Me.picFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picFoto.TabIndex = 0
        Me.picFoto.TabStop = False
        Me.ToolTip1.SetToolTip(Me.picFoto, "Doble Click para Cargar Imagen desde Archivo")
        '
        'pnlConsulta
        '
        Me.pnlConsulta.BackColor = System.Drawing.Color.FromArgb(CType(CType(95, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(82, Byte), Integer))
        Me.pnlConsulta.Controls.Add(Me.GroupBox2)
        Me.pnlConsulta.Location = New System.Drawing.Point(91, 48)
        Me.pnlConsulta.Name = "pnlConsulta"
        Me.pnlConsulta.Size = New System.Drawing.Size(381, 272)
        Me.pnlConsulta.TabIndex = 1
        Me.pnlConsulta.Visible = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lstFiltrada)
        Me.GroupBox2.Controls.Add(Me.btnCerrarConsulta)
        Me.GroupBox2.Controls.Add(Me.txtAyuda)
        Me.GroupBox2.Controls.Add(Me.lstConsulta)
        Me.GroupBox2.Controls.Add(Me.cmbIndices)
        Me.GroupBox2.ForeColor = System.Drawing.SystemColors.Control
        Me.GroupBox2.Location = New System.Drawing.Point(9, 6)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(363, 260)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Consulta Proveedores"
        '
        'lstFiltrada
        '
        Me.lstFiltrada.FormattingEnabled = True
        Me.lstFiltrada.Location = New System.Drawing.Point(13, 49)
        Me.lstFiltrada.Name = "lstFiltrada"
        Me.lstFiltrada.Size = New System.Drawing.Size(338, 173)
        Me.lstFiltrada.TabIndex = 3
        Me.lstFiltrada.Visible = False
        '
        'btnCerrarConsulta
        '
        Me.btnCerrarConsulta.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnCerrarConsulta.Location = New System.Drawing.Point(122, 225)
        Me.btnCerrarConsulta.Name = "btnCerrarConsulta"
        Me.btnCerrarConsulta.Size = New System.Drawing.Size(118, 29)
        Me.btnCerrarConsulta.TabIndex = 0
        Me.btnCerrarConsulta.Text = "Cerrar Consulta"
        Me.btnCerrarConsulta.UseVisualStyleBackColor = True
        '
        'txtAyuda
        '
        Me.txtAyuda.Location = New System.Drawing.Point(12, 25)
        Me.txtAyuda.Name = "txtAyuda"
        Me.txtAyuda.Size = New System.Drawing.Size(338, 20)
        Me.txtAyuda.TabIndex = 2
        '
        'lstConsulta
        '
        Me.lstConsulta.FormattingEnabled = True
        Me.lstConsulta.Location = New System.Drawing.Point(12, 48)
        Me.lstConsulta.Name = "lstConsulta"
        Me.lstConsulta.Size = New System.Drawing.Size(338, 173)
        Me.lstConsulta.TabIndex = 1
        '
        'cmbIndices
        '
        Me.cmbIndices.FormattingEnabled = True
        Me.cmbIndices.Location = New System.Drawing.Point(335, 228)
        Me.cmbIndices.Name = "cmbIndices"
        Me.cmbIndices.Size = New System.Drawing.Size(18, 21)
        Me.cmbIndices.TabIndex = 0
        Me.cmbIndices.Visible = False
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(844, 371)
        Me.Controls.Add(Me.pnlConsulta)
        Me.Controls.Add(Me.TableLayoutPrincipal)
        Me.Location = New System.Drawing.Point(10, 10)
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Identificaciones - Menu Principal"
        Me.TableLayoutPrincipal.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.TableLayoutCabecera.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.pnlFotoFinal.ResumeLayout(False)
        CType(Me.picFoto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlConsulta.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPrincipal As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutCabecera As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtNroDocumento As System.Windows.Forms.TextBox
    Friend WithEvents txtNombres As System.Windows.Forms.TextBox
    Friend WithEvents txtProveedor As System.Windows.Forms.TextBox
    Friend WithEvents txtApellido As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtDescProveedor As System.Windows.Forms.TextBox
    Friend WithEvents txtObservaciones As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btnImprimir As System.Windows.Forms.Button
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents btnConsultas As System.Windows.Forms.Button
    Friend WithEvents btnEliminar As System.Windows.Forms.Button
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents pnlConsulta As System.Windows.Forms.Panel
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents lstFiltrada As System.Windows.Forms.ListBox
    Friend WithEvents txtAyuda As System.Windows.Forms.TextBox
    Friend WithEvents lstConsulta As System.Windows.Forms.ListBox
    Friend WithEvents cmbIndices As System.Windows.Forms.ComboBox
    Friend WithEvents btnCerrarConsulta As System.Windows.Forms.Button
    Friend WithEvents pnlFotoFinal As System.Windows.Forms.Panel
    Friend WithEvents picFoto As System.Windows.Forms.PictureBox
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button

End Class
