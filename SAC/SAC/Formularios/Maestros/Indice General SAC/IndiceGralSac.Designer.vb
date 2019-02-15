Imports System.ComponentModel
Imports Microsoft.VisualBasic.CompilerServices

<DesignerGenerated()> _
Partial Class IndiceGralSac
    Inherits Form

    'Form overrides dispose to clean up the component list.
    <DebuggerNonUserCode()> _
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
    Private components As IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dgvListado = New System.Windows.Forms.DataGridView()
        Me.Tipo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idTipo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Anio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Numero = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Fecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Estado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Titulo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Referencia = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Centro = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Origen = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Emisor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Responsable = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CopiarConCabecerasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CopiarSóloDatosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.GroupBox9 = New System.Windows.Forms.GroupBox()
        Me.txtAnio = New System.Windows.Forms.TextBox()
        Me.txtHastaAnio = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btnNuevaSolicitud = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.GroupBox8 = New System.Windows.Forms.GroupBox()
        Me.clbCentros = New System.Windows.Forms.CheckedListBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cmbOrdenIII = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmbOrdenII = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmbOrdenI = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.clbResponsables = New System.Windows.Forms.CheckedListBox()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.clbEmisores = New System.Windows.Forms.CheckedListBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.clbTiposSolicitud = New System.Windows.Forms.CheckedListBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.clbOrigenes = New System.Windows.Forms.CheckedListBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.clbEstados = New System.Windows.Forms.CheckedListBox()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel1.SuspendLayout()
        CType(Me.dgvListado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.GroupBox9.SuspendLayout()
        Me.GroupBox8.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1145, 50)
        Me.Panel1.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.Control
        Me.Label2.Location = New System.Drawing.Point(25, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(145, 18)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Índice General de SAC"
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.Control
        Me.Label1.Location = New System.Drawing.Point(1025, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(108, 18)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "SURFACTAN S.A."
        '
        'dgvListado
        '
        Me.dgvListado.AllowUserToAddRows = False
        Me.dgvListado.AllowUserToDeleteRows = False
        Me.dgvListado.AllowUserToResizeRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvListado.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvListado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvListado.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Tipo, Me.idTipo, Me.Anio, Me.Numero, Me.Fecha, Me.Estado, Me.Titulo, Me.Referencia, Me.Centro, Me.Origen, Me.Emisor, Me.Responsable})
        Me.dgvListado.ContextMenuStrip = Me.ContextMenuStrip1
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvListado.DefaultCellStyle = DataGridViewCellStyle7
        Me.dgvListado.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvListado.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dgvListado.Location = New System.Drawing.Point(3, 239)
        Me.dgvListado.Name = "dgvListado"
        Me.dgvListado.ReadOnly = True
        Me.dgvListado.RowHeadersWidth = 15
        Me.dgvListado.RowTemplate.Height = 20
        Me.dgvListado.ShowCellToolTips = False
        Me.dgvListado.Size = New System.Drawing.Size(1139, 253)
        Me.dgvListado.TabIndex = 2
        '
        'Tipo
        '
        Me.Tipo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Tipo.DataPropertyName = "Tipo"
        Me.Tipo.HeaderText = "Tipo"
        Me.Tipo.MaxInputLength = 14
        Me.Tipo.Name = "Tipo"
        Me.Tipo.ReadOnly = True
        Me.Tipo.Width = 53
        '
        'idTipo
        '
        Me.idTipo.HeaderText = "idTipo"
        Me.idTipo.Name = "idTipo"
        Me.idTipo.ReadOnly = True
        Me.idTipo.Visible = False
        '
        'Anio
        '
        Me.Anio.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Anio.DataPropertyName = "Anio"
        Me.Anio.HeaderText = "Año"
        Me.Anio.Name = "Anio"
        Me.Anio.ReadOnly = True
        Me.Anio.Width = 51
        '
        'Numero
        '
        Me.Numero.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Numero.DataPropertyName = "Numero"
        Me.Numero.HeaderText = "Nro"
        Me.Numero.Name = "Numero"
        Me.Numero.ReadOnly = True
        Me.Numero.Width = 49
        '
        'Fecha
        '
        Me.Fecha.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Fecha.DataPropertyName = "Fecha"
        DataGridViewCellStyle3.Format = "d"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.Fecha.DefaultCellStyle = DataGridViewCellStyle3
        Me.Fecha.HeaderText = "Fecha"
        Me.Fecha.Name = "Fecha"
        Me.Fecha.ReadOnly = True
        Me.Fecha.Width = 62
        '
        'Estado
        '
        Me.Estado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Estado.DataPropertyName = "Estado"
        Me.Estado.HeaderText = "Estado"
        Me.Estado.Name = "Estado"
        Me.Estado.ReadOnly = True
        Me.Estado.Width = 65
        '
        'Titulo
        '
        Me.Titulo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Titulo.DataPropertyName = "Titulo"
        Me.Titulo.HeaderText = "Titulo"
        Me.Titulo.Name = "Titulo"
        Me.Titulo.ReadOnly = True
        '
        'Referencia
        '
        Me.Referencia.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Referencia.DataPropertyName = "Referencia"
        Me.Referencia.HeaderText = "Referencia"
        Me.Referencia.MinimumWidth = 200
        Me.Referencia.Name = "Referencia"
        Me.Referencia.ReadOnly = True
        Me.Referencia.Width = 200
        '
        'Centro
        '
        Me.Centro.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Centro.DataPropertyName = "Centro"
        Me.Centro.HeaderText = "Centro"
        Me.Centro.Name = "Centro"
        Me.Centro.ReadOnly = True
        Me.Centro.Width = 63
        '
        'Origen
        '
        Me.Origen.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Origen.DataPropertyName = "Origen"
        Me.Origen.HeaderText = "Origen"
        Me.Origen.Name = "Origen"
        Me.Origen.ReadOnly = True
        Me.Origen.Width = 63
        '
        'Emisor
        '
        Me.Emisor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Emisor.DataPropertyName = "Emisor"
        Me.Emisor.HeaderText = "Emisor"
        Me.Emisor.Name = "Emisor"
        Me.Emisor.ReadOnly = True
        Me.Emisor.Width = 63
        '
        'Responsable
        '
        Me.Responsable.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Responsable.DataPropertyName = "Responsable"
        Me.Responsable.HeaderText = "Resp."
        Me.Responsable.Name = "Responsable"
        Me.Responsable.ReadOnly = True
        Me.Responsable.Width = 60
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CopiarConCabecerasToolStripMenuItem, Me.CopiarSóloDatosToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(229, 48)
        '
        'CopiarConCabecerasToolStripMenuItem
        '
        Me.CopiarConCabecerasToolStripMenuItem.Name = "CopiarConCabecerasToolStripMenuItem"
        Me.CopiarConCabecerasToolStripMenuItem.Size = New System.Drawing.Size(228, 22)
        Me.CopiarConCabecerasToolStripMenuItem.Text = "Copiar Incluyendo Cabeceras"
        '
        'CopiarSóloDatosToolStripMenuItem
        '
        Me.CopiarSóloDatosToolStripMenuItem.Name = "CopiarSóloDatosToolStripMenuItem"
        Me.CopiarSóloDatosToolStripMenuItem.Size = New System.Drawing.Size(228, 22)
        Me.CopiarSóloDatosToolStripMenuItem.Text = "Copiar Sólo Datos"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.Panel2)
        Me.GroupBox1.Location = New System.Drawing.Point(10, 10)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(10)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1125, 216)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Parámetros"
        '
        'Panel2
        '
        Me.Panel2.AutoScroll = True
        Me.Panel2.Controls.Add(Me.GroupBox9)
        Me.Panel2.Controls.Add(Me.Button1)
        Me.Panel2.Controls.Add(Me.btnNuevaSolicitud)
        Me.Panel2.Controls.Add(Me.btnCancelar)
        Me.Panel2.Controls.Add(Me.btnAceptar)
        Me.Panel2.Controls.Add(Me.GroupBox8)
        Me.Panel2.Controls.Add(Me.GroupBox2)
        Me.Panel2.Controls.Add(Me.GroupBox7)
        Me.Panel2.Controls.Add(Me.GroupBox6)
        Me.Panel2.Controls.Add(Me.GroupBox3)
        Me.Panel2.Controls.Add(Me.GroupBox5)
        Me.Panel2.Controls.Add(Me.GroupBox4)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(3, 16)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1119, 197)
        Me.Panel2.TabIndex = 5
        '
        'GroupBox9
        '
        Me.GroupBox9.Controls.Add(Me.txtAnio)
        Me.GroupBox9.Controls.Add(Me.txtHastaAnio)
        Me.GroupBox9.Controls.Add(Me.Label6)
        Me.GroupBox9.Controls.Add(Me.Label7)
        Me.GroupBox9.Location = New System.Drawing.Point(19, 12)
        Me.GroupBox9.Name = "GroupBox9"
        Me.GroupBox9.Size = New System.Drawing.Size(240, 47)
        Me.GroupBox9.TabIndex = 8
        Me.GroupBox9.TabStop = False
        '
        'txtAnio
        '
        Me.txtAnio.Location = New System.Drawing.Point(82, 16)
        Me.txtAnio.MaxLength = 4
        Me.txtAnio.Name = "txtAnio"
        Me.txtAnio.Size = New System.Drawing.Size(38, 20)
        Me.txtAnio.TabIndex = 1
        Me.txtAnio.Text = "0000"
        Me.txtAnio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtHastaAnio
        '
        Me.txtHastaAnio.Location = New System.Drawing.Point(183, 16)
        Me.txtHastaAnio.MaxLength = 4
        Me.txtHastaAnio.Name = "txtHastaAnio"
        Me.txtHastaAnio.Size = New System.Drawing.Size(38, 20)
        Me.txtHastaAnio.TabIndex = 1
        Me.txtHastaAnio.Text = "0000"
        Me.txtHastaAnio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(19, 21)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(60, 13)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Desde Año"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(123, 20)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(57, 13)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Hasta Año"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(785, 43)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(181, 33)
        Me.Button1.TabIndex = 7
        Me.Button1.Text = "Exportar Indice"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'btnNuevaSolicitud
        '
        Me.btnNuevaSolicitud.Location = New System.Drawing.Point(924, 6)
        Me.btnNuevaSolicitud.Name = "btnNuevaSolicitud"
        Me.btnNuevaSolicitud.Size = New System.Drawing.Size(181, 33)
        Me.btnNuevaSolicitud.TabIndex = 6
        Me.btnNuevaSolicitud.Text = "CONSULTA / NUEVA SOLICITUD"
        Me.btnNuevaSolicitud.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(973, 43)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(132, 33)
        Me.btnCancelar.TabIndex = 5
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(785, 6)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(132, 33)
        Me.btnAceptar.TabIndex = 5
        Me.btnAceptar.Text = "FILTRAR"
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'GroupBox8
        '
        Me.GroupBox8.Controls.Add(Me.clbCentros)
        Me.GroupBox8.Location = New System.Drawing.Point(944, 77)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(167, 107)
        Me.GroupBox8.TabIndex = 4
        Me.GroupBox8.TabStop = False
        Me.GroupBox8.Text = "Centro"
        '
        'clbCentros
        '
        Me.clbCentros.CheckOnClick = True
        Me.clbCentros.FormattingEnabled = True
        Me.clbCentros.Location = New System.Drawing.Point(10, 18)
        Me.clbCentros.Name = "clbCentros"
        Me.clbCentros.Size = New System.Drawing.Size(147, 79)
        Me.clbCentros.TabIndex = 2
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cmbOrdenIII)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.cmbOrdenII)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.cmbOrdenI)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Location = New System.Drawing.Point(265, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(500, 47)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Orden"
        '
        'cmbOrdenIII
        '
        Me.cmbOrdenIII.FormattingEnabled = True
        Me.cmbOrdenIII.Items.AddRange(New Object() {"Tipo", "Numero", "Sector", "Estado", "Responsable"})
        Me.cmbOrdenIII.Location = New System.Drawing.Point(396, 15)
        Me.cmbOrdenIII.Name = "cmbOrdenIII"
        Me.cmbOrdenIII.Size = New System.Drawing.Size(92, 21)
        Me.cmbOrdenIII.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(346, 19)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(48, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Terciario"
        '
        'cmbOrdenII
        '
        Me.cmbOrdenII.FormattingEnabled = True
        Me.cmbOrdenII.Items.AddRange(New Object() {"Tipo", "Numero", "Sector", "Estado", "Responsable"})
        Me.cmbOrdenII.Location = New System.Drawing.Point(246, 15)
        Me.cmbOrdenII.Name = "cmbOrdenII"
        Me.cmbOrdenII.Size = New System.Drawing.Size(92, 21)
        Me.cmbOrdenII.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(183, 19)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(61, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Secundario"
        '
        'cmbOrdenI
        '
        Me.cmbOrdenI.FormattingEnabled = True
        Me.cmbOrdenI.Items.AddRange(New Object() {"Tipo", "Numero", "Sector", "Estado", "Responsable"})
        Me.cmbOrdenI.Location = New System.Drawing.Point(84, 15)
        Me.cmbOrdenI.Name = "cmbOrdenI"
        Me.cmbOrdenI.Size = New System.Drawing.Size(92, 21)
        Me.cmbOrdenI.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(37, 19)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Primario"
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.clbResponsables)
        Me.GroupBox7.Location = New System.Drawing.Point(771, 77)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(167, 107)
        Me.GroupBox7.TabIndex = 4
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "Responsable"
        '
        'clbResponsables
        '
        Me.clbResponsables.Location = New System.Drawing.Point(21, 18)
        Me.clbResponsables.Name = "clbResponsables"
        Me.clbResponsables.Size = New System.Drawing.Size(120, 79)
        Me.clbResponsables.TabIndex = 0
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.clbEmisores)
        Me.GroupBox6.Location = New System.Drawing.Point(598, 77)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(167, 107)
        Me.GroupBox6.TabIndex = 3
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Emisor"
        '
        'clbEmisores
        '
        Me.clbEmisores.CheckOnClick = True
        Me.clbEmisores.FormattingEnabled = True
        Me.clbEmisores.Location = New System.Drawing.Point(10, 18)
        Me.clbEmisores.Name = "clbEmisores"
        Me.clbEmisores.Size = New System.Drawing.Size(147, 79)
        Me.clbEmisores.TabIndex = 2
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.clbTiposSolicitud)
        Me.GroupBox3.Location = New System.Drawing.Point(9, 76)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(202, 107)
        Me.GroupBox3.TabIndex = 3
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Tipos de Solicitud"
        '
        'clbTiposSolicitud
        '
        Me.clbTiposSolicitud.CheckOnClick = True
        Me.clbTiposSolicitud.FormattingEnabled = True
        Me.clbTiposSolicitud.Location = New System.Drawing.Point(10, 18)
        Me.clbTiposSolicitud.Name = "clbTiposSolicitud"
        Me.clbTiposSolicitud.Size = New System.Drawing.Size(180, 79)
        Me.clbTiposSolicitud.TabIndex = 2
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.clbOrigenes)
        Me.GroupBox5.Location = New System.Drawing.Point(425, 77)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(167, 107)
        Me.GroupBox5.TabIndex = 3
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Origen"
        '
        'clbOrigenes
        '
        Me.clbOrigenes.CheckOnClick = True
        Me.clbOrigenes.FormattingEnabled = True
        Me.clbOrigenes.Items.AddRange(New Object() {"Total", "Auditoría", "Reclamo", "I. de No Conformidad", "Proceso / Sist", "Otro"})
        Me.clbOrigenes.Location = New System.Drawing.Point(10, 18)
        Me.clbOrigenes.Name = "clbOrigenes"
        Me.clbOrigenes.Size = New System.Drawing.Size(147, 79)
        Me.clbOrigenes.TabIndex = 2
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.clbEstados)
        Me.GroupBox4.Location = New System.Drawing.Point(217, 76)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(202, 107)
        Me.GroupBox4.TabIndex = 3
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Estado"
        '
        'clbEstados
        '
        Me.clbEstados.CheckOnClick = True
        Me.clbEstados.FormattingEnabled = True
        Me.clbEstados.Items.AddRange(New Object() {"Total", "Iniciada", "Investigación", "Implementación", "Implementación a Verificar", "Implementación Verificada", "Cerrada"})
        Me.clbEstados.Location = New System.Drawing.Point(10, 18)
        Me.clbEstados.Name = "clbEstados"
        Me.clbEstados.Size = New System.Drawing.Size(180, 79)
        Me.clbEstados.TabIndex = 2
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.dgvListado, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.GroupBox1, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 50)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 236.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1145, 495)
        Me.TableLayoutPanel1.TabIndex = 4
        '
        'IndiceGralSac
        '
        Me.ClientSize = New System.Drawing.Size(1145, 545)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "IndiceGralSac"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "IndiceGralSac"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dgvListado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.GroupBox9.ResumeLayout(False)
        Me.GroupBox9.PerformLayout()
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents dgvListado As DataGridView
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents cmbOrdenIII As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents cmbOrdenII As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents cmbOrdenI As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtAnio As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents clbTiposSolicitud As CheckedListBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents clbOrigenes As CheckedListBox
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents clbEstados As CheckedListBox
    Friend WithEvents GroupBox6 As GroupBox
    Friend WithEvents clbEmisores As CheckedListBox
    Friend WithEvents GroupBox7 As GroupBox
    Friend WithEvents clbResponsables As CheckedListBox
    Friend WithEvents GroupBox8 As GroupBox
    Friend WithEvents clbCentros As CheckedListBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents btnCancelar As Button
    Friend WithEvents btnAceptar As Button
    Friend WithEvents Tipo As DataGridViewTextBoxColumn
    Friend WithEvents idTipo As DataGridViewTextBoxColumn
    Friend WithEvents Anio As DataGridViewTextBoxColumn
    Friend WithEvents Numero As DataGridViewTextBoxColumn
    Friend WithEvents Fecha As DataGridViewTextBoxColumn
    Friend WithEvents Estado As DataGridViewTextBoxColumn
    Friend WithEvents Titulo As DataGridViewTextBoxColumn
    Friend WithEvents Referencia As DataGridViewTextBoxColumn
    Friend WithEvents Centro As DataGridViewTextBoxColumn
    Friend WithEvents Origen As DataGridViewTextBoxColumn
    Friend WithEvents Emisor As DataGridViewTextBoxColumn
    Friend WithEvents Responsable As DataGridViewTextBoxColumn
    Friend WithEvents btnNuevaSolicitud As Button
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents CopiarConCabecerasToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CopiarSóloDatosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Button1 As Button
    Friend WithEvents Label7 As Label
    Friend WithEvents txtHastaAnio As TextBox
    Friend WithEvents GroupBox9 As GroupBox
End Class
