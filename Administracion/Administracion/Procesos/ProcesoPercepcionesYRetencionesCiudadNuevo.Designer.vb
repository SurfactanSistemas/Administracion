<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ProcesoPercepcionesYRetencionesCiudadNuevo
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
        Me.txtHasta = New System.Windows.Forms.MaskedTextBox()
        Me.txtDesde = New System.Windows.Forms.MaskedTextBox()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.CustomLabel4 = New Administracion.CustomLabel()
        Me.CustomLabel3 = New Administracion.CustomLabel()
        Me.CustomLabel2 = New Administracion.CustomLabel()
        Me.CustomLabel1 = New Administracion.CustomLabel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.CustomLabel5 = New Administracion.CustomLabel()
        Me.txtNombre = New Administracion.CustomTextBox()
        Me.TipoProceso = New Administracion.CustomComboBox()
        Me.LugarProceso = New Administracion.CustomComboBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnCancela = New Administracion.CustomButton()
        Me.btnAcepta = New Administracion.CustomButton()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtHasta
        '
        Me.txtHasta.Location = New System.Drawing.Point(411, 14)
        Me.txtHasta.Mask = "##/##/####"
        Me.txtHasta.Name = "txtHasta"
        Me.txtHasta.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtHasta.Size = New System.Drawing.Size(106, 20)
        Me.txtHasta.TabIndex = 19
        Me.txtHasta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtDesde
        '
        Me.txtDesde.Location = New System.Drawing.Point(174, 14)
        Me.txtDesde.Mask = "##/##/####"
        Me.txtDesde.Name = "txtDesde"
        Me.txtDesde.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtDesde.Size = New System.Drawing.Size(106, 20)
        Me.txtDesde.TabIndex = 18
        Me.txtDesde.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'CustomLabel4
        '
        Me.CustomLabel4.AutoSize = True
        Me.CustomLabel4.ControlAssociationKey = -1
        Me.CustomLabel4.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.CustomLabel4.ForeColor = System.Drawing.SystemColors.Control
        Me.CustomLabel4.Location = New System.Drawing.Point(-5, 52)
        Me.CustomLabel4.Name = "CustomLabel4"
        Me.CustomLabel4.Size = New System.Drawing.Size(41, 18)
        Me.CustomLabel4.TabIndex = 17
        Me.CustomLabel4.Text = "Lugar"
        '
        'CustomLabel3
        '
        Me.CustomLabel3.AutoSize = True
        Me.CustomLabel3.ControlAssociationKey = -1
        Me.CustomLabel3.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.CustomLabel3.ForeColor = System.Drawing.SystemColors.Control
        Me.CustomLabel3.Location = New System.Drawing.Point(97, 51)
        Me.CustomLabel3.Name = "CustomLabel3"
        Me.CustomLabel3.Size = New System.Drawing.Size(59, 18)
        Me.CustomLabel3.TabIndex = 11
        Me.CustomLabel3.Text = "Nombre"
        '
        'CustomLabel2
        '
        Me.CustomLabel2.AutoSize = True
        Me.CustomLabel2.ControlAssociationKey = -1
        Me.CustomLabel2.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.CustomLabel2.ForeColor = System.Drawing.SystemColors.Control
        Me.CustomLabel2.Location = New System.Drawing.Point(310, 16)
        Me.CustomLabel2.Name = "CustomLabel2"
        Me.CustomLabel2.Size = New System.Drawing.Size(81, 18)
        Me.CustomLabel2.TabIndex = 10
        Me.CustomLabel2.Text = "Hasta Fecha"
        '
        'CustomLabel1
        '
        Me.CustomLabel1.AutoSize = True
        Me.CustomLabel1.ControlAssociationKey = -1
        Me.CustomLabel1.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.CustomLabel1.ForeColor = System.Drawing.SystemColors.Control
        Me.CustomLabel1.Location = New System.Drawing.Point(70, 16)
        Me.CustomLabel1.Name = "CustomLabel1"
        Me.CustomLabel1.Size = New System.Drawing.Size(86, 18)
        Me.CustomLabel1.TabIndex = 8
        Me.CustomLabel1.Text = "Desde Fecha"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(586, 50)
        Me.Panel1.TabIndex = 28
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
        Me.Label1.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.SystemColors.Control
        Me.Label1.Location = New System.Drawing.Point(14, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(360, 18)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Proceso de Percepciones y Retenciones de Ciudad Bs. As."
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(95, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(82, Byte), Integer))
        Me.Panel2.Controls.Add(Me.GroupBox1)
        Me.Panel2.Controls.Add(Me.CustomLabel1)
        Me.Panel2.Controls.Add(Me.CustomLabel2)
        Me.Panel2.Controls.Add(Me.CustomLabel3)
        Me.Panel2.Controls.Add(Me.CustomLabel5)
        Me.Panel2.Controls.Add(Me.CustomLabel4)
        Me.Panel2.Controls.Add(Me.txtDesde)
        Me.Panel2.Controls.Add(Me.txtHasta)
        Me.Panel2.Controls.Add(Me.txtNombre)
        Me.Panel2.Controls.Add(Me.TipoProceso)
        Me.Panel2.Controls.Add(Me.LugarProceso)
        Me.Panel2.Location = New System.Drawing.Point(0, 50)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(586, 118)
        Me.Panel2.TabIndex = 29
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.ProgressBar1)
        Me.GroupBox1.ForeColor = System.Drawing.SystemColors.Control
        Me.GroupBox1.Location = New System.Drawing.Point(308, 41)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(209, 39)
        Me.GroupBox1.TabIndex = 23
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Progreso"
        Me.GroupBox1.Visible = False
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(20, 17)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(172, 14)
        Me.ProgressBar1.TabIndex = 22
        '
        'CustomLabel5
        '
        Me.CustomLabel5.AutoSize = True
        Me.CustomLabel5.ControlAssociationKey = -1
        Me.CustomLabel5.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.CustomLabel5.ForeColor = System.Drawing.SystemColors.Control
        Me.CustomLabel5.Location = New System.Drawing.Point(-37, 75)
        Me.CustomLabel5.Name = "CustomLabel5"
        Me.CustomLabel5.Size = New System.Drawing.Size(87, 18)
        Me.CustomLabel5.TabIndex = 17
        Me.CustomLabel5.Text = "Tipo Proceso"
        '
        'txtNombre
        '
        Me.txtNombre.Cleanable = False
        Me.txtNombre.Empty = True
        Me.txtNombre.EnterIndex = -1
        Me.txtNombre.LabelAssociationKey = -1
        Me.txtNombre.Location = New System.Drawing.Point(174, 50)
        Me.txtNombre.MaxLength = 8
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(106, 20)
        Me.txtNombre.TabIndex = 20
        Me.txtNombre.Validator = Administracion.ValidatorType.None
        '
        'TipoProceso
        '
        Me.TipoProceso.Cleanable = False
        Me.TipoProceso.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.TipoProceso.Empty = False
        Me.TipoProceso.EnterIndex = -1
        Me.TipoProceso.FormattingEnabled = True
        Me.TipoProceso.Items.AddRange(New Object() {"Cobranzas", "Facturación"})
        Me.TipoProceso.LabelAssociationKey = -1
        Me.TipoProceso.Location = New System.Drawing.Point(56, 75)
        Me.TipoProceso.Name = "TipoProceso"
        Me.TipoProceso.Size = New System.Drawing.Size(22, 21)
        Me.TipoProceso.TabIndex = 21
        Me.TipoProceso.Validator = Administracion.ValidatorType.None
        '
        'LugarProceso
        '
        Me.LugarProceso.Cleanable = False
        Me.LugarProceso.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.LugarProceso.Empty = False
        Me.LugarProceso.EnterIndex = -1
        Me.LugarProceso.FormattingEnabled = True
        Me.LugarProceso.LabelAssociationKey = -1
        Me.LugarProceso.Location = New System.Drawing.Point(56, 51)
        Me.LugarProceso.Name = "LugarProceso"
        Me.LugarProceso.Size = New System.Drawing.Size(22, 21)
        Me.LugarProceso.TabIndex = 21
        Me.LugarProceso.Validator = Administracion.ValidatorType.None
        '
        'btnCancela
        '
        Me.btnCancela.BackgroundImage = Global.Administracion.My.Resources.Resources.Salir2
        Me.btnCancela.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnCancela.Cleanable = False
        Me.btnCancela.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCancela.EnterIndex = -1
        Me.btnCancela.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnCancela.FlatAppearance.BorderSize = 0
        Me.btnCancela.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.Control
        Me.btnCancela.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control
        Me.btnCancela.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control
        Me.btnCancela.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancela.LabelAssociationKey = -1
        Me.btnCancela.Location = New System.Drawing.Point(307, 191)
        Me.btnCancela.Name = "btnCancela"
        Me.btnCancela.Size = New System.Drawing.Size(77, 49)
        Me.btnCancela.TabIndex = 23
        Me.ToolTip1.SetToolTip(Me.btnCancela, "Cerrar")
        Me.btnCancela.UseVisualStyleBackColor = True
        '
        'btnAcepta
        '
        Me.btnAcepta.BackgroundImage = Global.Administracion.My.Resources.Resources.Aceptar_N2
        Me.btnAcepta.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnAcepta.Cleanable = False
        Me.btnAcepta.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAcepta.EnterIndex = -1
        Me.btnAcepta.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnAcepta.FlatAppearance.BorderSize = 0
        Me.btnAcepta.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.Control
        Me.btnAcepta.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control
        Me.btnAcepta.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control
        Me.btnAcepta.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAcepta.LabelAssociationKey = -1
        Me.btnAcepta.Location = New System.Drawing.Point(194, 191)
        Me.btnAcepta.Name = "btnAcepta"
        Me.btnAcepta.Size = New System.Drawing.Size(77, 49)
        Me.btnAcepta.TabIndex = 22
        Me.ToolTip1.SetToolTip(Me.btnAcepta, "Aceptar")
        Me.btnAcepta.UseVisualStyleBackColor = True
        '
        'ProcesoPercepcionesYRetencionesCiudadNuevo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(579, 260)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.btnCancela)
        Me.Controls.Add(Me.btnAcepta)
        Me.Name = "ProcesoPercepcionesYRetencionesCiudadNuevo"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CustomLabel1 As Administracion.CustomLabel
    Friend WithEvents CustomLabel2 As Administracion.CustomLabel
    Friend WithEvents CustomLabel3 As Administracion.CustomLabel
    Friend WithEvents CustomLabel4 As Administracion.CustomLabel
    Friend WithEvents txtHasta As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtDesde As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtNombre As Administracion.CustomTextBox
    Friend WithEvents LugarProceso As Administracion.CustomComboBox
    Friend WithEvents btnAcepta As Administracion.CustomButton
    Friend WithEvents btnCancela As Administracion.CustomButton
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents CustomLabel5 As Administracion.CustomLabel
    Friend WithEvents TipoProceso As Administracion.CustomComboBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
End Class
