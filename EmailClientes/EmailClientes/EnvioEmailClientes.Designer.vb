<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EnvioEmailClientes
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtAsunto = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtCuerpoEmail = New System.Windows.Forms.TextBox()
        Me.txtLineaExtraI = New System.Windows.Forms.TextBox()
        Me.txtLineaExtraII = New System.Windows.Forms.TextBox()
        Me.txtLineaExtraIII = New System.Windows.Forms.TextBox()
        Me.txtLineaExtraIV = New System.Windows.Forms.TextBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.txtDestinatarios = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.btnAdjuntar = New System.Windows.Forms.Button()
        Me.txtNombreArchivoAdjunto = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.OFDAdjuntarArchivo = New System.Windows.Forms.OpenFileDialog()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnEnviar = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.pnlDestinatarios = New System.Windows.Forms.Panel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.cmbTipoProv = New System.Windows.Forms.ComboBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Enviar = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Proveedor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Razon = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Email = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TipoProv = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.ProgressBar2 = New System.Windows.Forms.ProgressBar()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.pnlDestinatarios.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(854, 50)
        Me.Panel1.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.Control
        Me.Label2.Location = New System.Drawing.Point(475, 11)
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
        Me.Label1.Location = New System.Drawing.Point(20, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(178, 19)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Envío de Email a Clientes"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.FromArgb(CType(CType(95, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(82, Byte), Integer))
        Me.Label3.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label3.ForeColor = System.Drawing.SystemColors.Control
        Me.Label3.Location = New System.Drawing.Point(68, 15)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 18)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Asunto:"
        '
        'txtAsunto
        '
        Me.txtAsunto.Location = New System.Drawing.Point(133, 14)
        Me.txtAsunto.Name = "txtAsunto"
        Me.txtAsunto.Size = New System.Drawing.Size(474, 20)
        Me.txtAsunto.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.FromArgb(CType(CType(95, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(82, Byte), Integer))
        Me.Label4.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label4.ForeColor = System.Drawing.SystemColors.Control
        Me.Label4.Location = New System.Drawing.Point(56, 132)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(66, 18)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Mensaje:"
        '
        'txtCuerpoEmail
        '
        Me.txtCuerpoEmail.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCuerpoEmail.Location = New System.Drawing.Point(132, 104)
        Me.txtCuerpoEmail.Multiline = True
        Me.txtCuerpoEmail.Name = "txtCuerpoEmail"
        Me.txtCuerpoEmail.Size = New System.Drawing.Size(473, 165)
        Me.txtCuerpoEmail.TabIndex = 5
        '
        'txtLineaExtraI
        '
        Me.txtLineaExtraI.Location = New System.Drawing.Point(132, 275)
        Me.txtLineaExtraI.Name = "txtLineaExtraI"
        Me.txtLineaExtraI.Size = New System.Drawing.Size(473, 20)
        Me.txtLineaExtraI.TabIndex = 6
        '
        'txtLineaExtraII
        '
        Me.txtLineaExtraII.Location = New System.Drawing.Point(132, 297)
        Me.txtLineaExtraII.Name = "txtLineaExtraII"
        Me.txtLineaExtraII.Size = New System.Drawing.Size(473, 20)
        Me.txtLineaExtraII.TabIndex = 6
        '
        'txtLineaExtraIII
        '
        Me.txtLineaExtraIII.Location = New System.Drawing.Point(132, 319)
        Me.txtLineaExtraIII.Name = "txtLineaExtraIII"
        Me.txtLineaExtraIII.Size = New System.Drawing.Size(473, 20)
        Me.txtLineaExtraIII.TabIndex = 6
        '
        'txtLineaExtraIV
        '
        Me.txtLineaExtraIV.Location = New System.Drawing.Point(132, 341)
        Me.txtLineaExtraIV.Name = "txtLineaExtraIV"
        Me.txtLineaExtraIV.Size = New System.Drawing.Size(473, 20)
        Me.txtLineaExtraIV.TabIndex = 6
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(95, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(82, Byte), Integer))
        Me.Panel2.Controls.Add(Me.ProgressBar2)
        Me.Panel2.Controls.Add(Me.txtDestinatarios)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.Button6)
        Me.Panel2.Controls.Add(Me.btnAdjuntar)
        Me.Panel2.Controls.Add(Me.txtNombreArchivoAdjunto)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.txtLineaExtraIV)
        Me.Panel2.Controls.Add(Me.txtAsunto)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.Label8)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.txtLineaExtraIII)
        Me.Panel2.Controls.Add(Me.txtCuerpoEmail)
        Me.Panel2.Controls.Add(Me.txtLineaExtraII)
        Me.Panel2.Controls.Add(Me.txtLineaExtraI)
        Me.Panel2.Location = New System.Drawing.Point(0, 42)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(649, 432)
        Me.Panel2.TabIndex = 8
        '
        'txtDestinatarios
        '
        Me.txtDestinatarios.Location = New System.Drawing.Point(133, 40)
        Me.txtDestinatarios.Multiline = True
        Me.txtDestinatarios.Name = "txtDestinatarios"
        Me.txtDestinatarios.Size = New System.Drawing.Size(449, 59)
        Me.txtDestinatarios.TabIndex = 8
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.FromArgb(CType(CType(95, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(82, Byte), Integer))
        Me.Label6.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label6.ForeColor = System.Drawing.SystemColors.Control
        Me.Label6.Location = New System.Drawing.Point(30, 40)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(94, 18)
        Me.Label6.TabIndex = 7
        Me.Label6.Text = "Destinatarios:"
        '
        'Button6
        '
        Me.Button6.AllowDrop = True
        Me.Button6.BackgroundImage = Global.EmailClientes.My.Resources.Resources.add
        Me.Button6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Button6.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button6.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(95, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(82, Byte), Integer))
        Me.Button6.FlatAppearance.BorderSize = 0
        Me.Button6.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(95, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(82, Byte), Integer))
        Me.Button6.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(95, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(82, Byte), Integer))
        Me.Button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button6.Location = New System.Drawing.Point(587, 51)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(44, 36)
        Me.Button6.TabIndex = 0
        Me.Button6.UseVisualStyleBackColor = True
        '
        'btnAdjuntar
        '
        Me.btnAdjuntar.AllowDrop = True
        Me.btnAdjuntar.BackgroundImage = Global.EmailClientes.My.Resources.Resources.Attachment1
        Me.btnAdjuntar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnAdjuntar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAdjuntar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(95, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(82, Byte), Integer))
        Me.btnAdjuntar.FlatAppearance.BorderSize = 0
        Me.btnAdjuntar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(95, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(82, Byte), Integer))
        Me.btnAdjuntar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(95, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(82, Byte), Integer))
        Me.btnAdjuntar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAdjuntar.Location = New System.Drawing.Point(48, 374)
        Me.btnAdjuntar.Name = "btnAdjuntar"
        Me.btnAdjuntar.Size = New System.Drawing.Size(66, 52)
        Me.btnAdjuntar.TabIndex = 0
        Me.ToolTip1.SetToolTip(Me.btnAdjuntar, "Adjuntar un Archivo al Email")
        Me.btnAdjuntar.UseVisualStyleBackColor = True
        '
        'txtNombreArchivoAdjunto
        '
        Me.txtNombreArchivoAdjunto.AllowDrop = True
        Me.txtNombreArchivoAdjunto.Location = New System.Drawing.Point(248, 368)
        Me.txtNombreArchivoAdjunto.Name = "txtNombreArchivoAdjunto"
        Me.txtNombreArchivoAdjunto.ReadOnly = True
        Me.txtNombreArchivoAdjunto.Size = New System.Drawing.Size(357, 20)
        Me.txtNombreArchivoAdjunto.TabIndex = 6
        Me.ToolTip1.SetToolTip(Me.txtNombreArchivoAdjunto, "Doble Click: Abrir y buscar archivos")
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.FromArgb(CType(CType(95, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(82, Byte), Integer))
        Me.Label5.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label5.ForeColor = System.Drawing.SystemColors.Control
        Me.Label5.Location = New System.Drawing.Point(130, 369)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(112, 18)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Archivo Adjunto:"
        '
        'OFDAdjuntarArchivo
        '
        Me.OFDAdjuntarArchivo.FileName = "OpenFileDialog1"
        '
        'btnCancelar
        '
        Me.btnCancelar.BackgroundImage = Global.EmailClientes.My.Resources.Resources.Salir2
        Me.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCancelar.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnCancelar.FlatAppearance.BorderSize = 0
        Me.btnCancelar.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.Control
        Me.btnCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control
        Me.btnCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control
        Me.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancelar.Location = New System.Drawing.Point(352, 480)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(67, 40)
        Me.btnCancelar.TabIndex = 7
        Me.ToolTip1.SetToolTip(Me.btnCancelar, "Cancelar Envio de Email")
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnEnviar
        '
        Me.btnEnviar.BackgroundImage = Global.EmailClientes.My.Resources.Resources.Aceptar_N2
        Me.btnEnviar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnEnviar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnEnviar.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnEnviar.FlatAppearance.BorderSize = 0
        Me.btnEnviar.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.Control
        Me.btnEnviar.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control
        Me.btnEnviar.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control
        Me.btnEnviar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEnviar.Location = New System.Drawing.Point(229, 480)
        Me.btnEnviar.Name = "btnEnviar"
        Me.btnEnviar.Size = New System.Drawing.Size(67, 40)
        Me.btnEnviar.TabIndex = 7
        Me.ToolTip1.SetToolTip(Me.btnEnviar, "Enviar Email")
        Me.btnEnviar.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.Control
        Me.Button1.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control
        Me.Button1.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Button1.Location = New System.Drawing.Point(294, 10)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(67, 40)
        Me.Button1.TabIndex = 9
        Me.Button1.Text = "Cerrar"
        Me.ToolTip1.SetToolTip(Me.Button1, "Cancelar Envio de Email")
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Button2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button2.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.Button2.FlatAppearance.BorderSize = 0
        Me.Button2.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.Control
        Me.Button2.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control
        Me.Button2.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Button2.Location = New System.Drawing.Point(171, 10)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(67, 40)
        Me.Button2.TabIndex = 8
        Me.Button2.Text = "Aceptar"
        Me.ToolTip1.SetToolTip(Me.Button2, "Enviar Email")
        Me.Button2.UseVisualStyleBackColor = True
        '
        'pnlDestinatarios
        '
        Me.pnlDestinatarios.BackColor = System.Drawing.Color.FromArgb(CType(CType(95, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(82, Byte), Integer))
        Me.pnlDestinatarios.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlDestinatarios.Controls.Add(Me.GroupBox1)
        Me.pnlDestinatarios.Controls.Add(Me.Panel4)
        Me.pnlDestinatarios.Location = New System.Drawing.Point(56, 37)
        Me.pnlDestinatarios.Name = "pnlDestinatarios"
        Me.pnlDestinatarios.Size = New System.Drawing.Size(536, 405)
        Me.pnlDestinatarios.TabIndex = 9
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.ProgressBar1)
        Me.GroupBox1.Controls.Add(Me.Button5)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Button3)
        Me.GroupBox1.Controls.Add(Me.Button4)
        Me.GroupBox1.Controls.Add(Me.cmbTipoProv)
        Me.GroupBox1.Controls.Add(Me.DataGridView1)
        Me.GroupBox1.Location = New System.Drawing.Point(14, -1)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(30)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(502, 336)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        '
        'Button5
        '
        Me.Button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button5.ForeColor = System.Drawing.SystemColors.Control
        Me.Button5.Location = New System.Drawing.Point(139, 53)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(114, 21)
        Me.Button5.TabIndex = 4
        Me.Button5.Text = "Limpiar Grupo"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.Control
        Me.Label7.Location = New System.Drawing.Point(34, 18)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(138, 15)
        Me.Label7.TabIndex = 3
        Me.Label7.Text = "Filtrar por Tipo Prov."
        '
        'Button3
        '
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.ForeColor = System.Drawing.SystemColors.Control
        Me.Button3.Location = New System.Drawing.Point(19, 53)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(114, 21)
        Me.Button3.TabIndex = 2
        Me.Button3.Text = "Marcar Grupo"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.ForeColor = System.Drawing.SystemColors.Control
        Me.Button4.Location = New System.Drawing.Point(354, 16)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(114, 21)
        Me.Button4.TabIndex = 2
        Me.Button4.Text = "Mostrar Todos"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'cmbTipoProv
        '
        Me.cmbTipoProv.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoProv.FormattingEnabled = True
        Me.cmbTipoProv.Location = New System.Drawing.Point(180, 16)
        Me.cmbTipoProv.Name = "cmbTipoProv"
        Me.cmbTipoProv.Size = New System.Drawing.Size(168, 21)
        Me.cmbTipoProv.TabIndex = 1
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Enviar, Me.Proveedor, Me.Razon, Me.Email, Me.TipoProv})
        Me.DataGridView1.Location = New System.Drawing.Point(6, 80)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersWidth = 10
        Me.DataGridView1.Size = New System.Drawing.Size(490, 245)
        Me.DataGridView1.TabIndex = 0
        '
        'Enviar
        '
        Me.Enviar.HeaderText = ""
        Me.Enviar.MaxInputLength = 1
        Me.Enviar.Name = "Enviar"
        Me.Enviar.ReadOnly = True
        Me.Enviar.Width = 20
        '
        'Proveedor
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Proveedor.DefaultCellStyle = DataGridViewCellStyle3
        Me.Proveedor.HeaderText = "Proveedor"
        Me.Proveedor.Name = "Proveedor"
        Me.Proveedor.ReadOnly = True
        '
        'Razon
        '
        Me.Razon.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Razon.HeaderText = "Razon"
        Me.Razon.MinimumWidth = 165
        Me.Razon.Name = "Razon"
        Me.Razon.ReadOnly = True
        '
        'Email
        '
        Me.Email.HeaderText = "Email"
        Me.Email.Name = "Email"
        Me.Email.ReadOnly = True
        Me.Email.Width = 150
        '
        'TipoProv
        '
        Me.TipoProv.HeaderText = "TipoProv"
        Me.TipoProv.Name = "TipoProv"
        Me.TipoProv.ReadOnly = True
        Me.TipoProv.Visible = False
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.SystemColors.Control
        Me.Panel4.Controls.Add(Me.Button1)
        Me.Panel4.Controls.Add(Me.Button2)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel4.Location = New System.Drawing.Point(0, 340)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(532, 61)
        Me.Panel4.TabIndex = 0
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(264, 53)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(231, 20)
        Me.ProgressBar1.TabIndex = 5
        Me.ProgressBar1.Visible = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.FromArgb(CType(CType(95, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(82, Byte), Integer))
        Me.Label8.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label8.ForeColor = System.Drawing.SystemColors.Control
        Me.Label8.Location = New System.Drawing.Point(123, 398)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(120, 18)
        Me.Label8.TabIndex = 4
        Me.Label8.Text = "Enviando Correos:"
        Me.Label8.Visible = False
        '
        'ProgressBar2
        '
        Me.ProgressBar2.Location = New System.Drawing.Point(250, 396)
        Me.ProgressBar2.Name = "ProgressBar2"
        Me.ProgressBar2.Size = New System.Drawing.Size(354, 24)
        Me.ProgressBar2.TabIndex = 9
        Me.ProgressBar2.Visible = False
        '
        'EnvioEmailProveedores
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(648, 524)
        Me.Controls.Add(Me.pnlDestinatarios)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnEnviar)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.Location = New System.Drawing.Point(10, 10)
        Me.MaximizeBox = False
        Me.Name = "EnvioEmailProveedores"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.pnlDestinatarios.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtAsunto As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtCuerpoEmail As System.Windows.Forms.TextBox
    Friend WithEvents txtLineaExtraI As System.Windows.Forms.TextBox
    Friend WithEvents txtLineaExtraII As System.Windows.Forms.TextBox
    Friend WithEvents txtLineaExtraIII As System.Windows.Forms.TextBox
    Friend WithEvents txtLineaExtraIV As System.Windows.Forms.TextBox
    Friend WithEvents btnEnviar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents btnAdjuntar As System.Windows.Forms.Button
    Friend WithEvents OFDAdjuntarArchivo As System.Windows.Forms.OpenFileDialog
    Friend WithEvents txtNombreArchivoAdjunto As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents txtDestinatarios As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents pnlDestinatarios As System.Windows.Forms.Panel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents cmbTipoProv As System.Windows.Forms.ComboBox
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Enviar As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Proveedor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Razon As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Email As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TipoProv As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents ProgressBar2 As System.Windows.Forms.ProgressBar
    Friend WithEvents Label8 As System.Windows.Forms.Label
End Class
