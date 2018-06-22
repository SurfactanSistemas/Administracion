<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ListadoCuentaCorrienteProveedores
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
        Me.Grupo1 = New System.Windows.Forms.GroupBox()
        Me.opcCompleto = New System.Windows.Forms.RadioButton()
        Me.opcPendiente = New System.Windows.Forms.RadioButton()
        Me.lstAyuda = New Administracion.CustomListBox()
        Me.txtAyuda = New Administracion.CustomTextBox()
        Me.btnConsulta = New Administracion.CustomButton()
        Me.btnCancela = New Administracion.CustomButton()
        Me.txtHastaProveedor = New Administracion.CustomTextBox()
        Me.txtDesdeProveedor = New Administracion.CustomTextBox()
        Me.CustomLabel2 = New Administracion.CustomLabel()
        Me.CustomLabel1 = New Administracion.CustomLabel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnPorPantalla = New Administracion.CustomButton()
        Me.btnImprimir = New Administracion.CustomButton()
        Me.lstFiltrada = New Administracion.CustomListBox()
        Me.Grupo1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Grupo1
        '
        Me.Grupo1.BackColor = System.Drawing.Color.FromArgb(CType(CType(95, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(82, Byte), Integer))
        Me.Grupo1.Controls.Add(Me.opcCompleto)
        Me.Grupo1.Controls.Add(Me.opcPendiente)
        Me.Grupo1.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Grupo1.ForeColor = System.Drawing.SystemColors.Control
        Me.Grupo1.Location = New System.Drawing.Point(90, 133)
        Me.Grupo1.Name = "Grupo1"
        Me.Grupo1.Size = New System.Drawing.Size(410, 50)
        Me.Grupo1.TabIndex = 20
        Me.Grupo1.TabStop = False
        Me.Grupo1.Text = "Tipo de Listado"
        '
        'opcCompleto
        '
        Me.opcCompleto.AutoSize = True
        Me.opcCompleto.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.opcCompleto.ForeColor = System.Drawing.SystemColors.Control
        Me.opcCompleto.Location = New System.Drawing.Point(237, 17)
        Me.opcCompleto.Name = "opcCompleto"
        Me.opcCompleto.Size = New System.Drawing.Size(87, 22)
        Me.opcCompleto.TabIndex = 22
        Me.opcCompleto.TabStop = True
        Me.opcCompleto.Text = "Completo"
        Me.opcCompleto.UseVisualStyleBackColor = True
        '
        'opcPendiente
        '
        Me.opcPendiente.AutoSize = True
        Me.opcPendiente.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.opcPendiente.ForeColor = System.Drawing.SystemColors.Control
        Me.opcPendiente.Location = New System.Drawing.Point(103, 17)
        Me.opcPendiente.Name = "opcPendiente"
        Me.opcPendiente.Size = New System.Drawing.Size(91, 22)
        Me.opcPendiente.TabIndex = 21
        Me.opcPendiente.TabStop = True
        Me.opcPendiente.Text = "Pendiente"
        Me.opcPendiente.UseVisualStyleBackColor = True
        '
        'lstAyuda
        '
        Me.lstAyuda.Cleanable = False
        Me.lstAyuda.EnterIndex = -1
        Me.lstAyuda.FormattingEnabled = True
        Me.lstAyuda.LabelAssociationKey = -1
        Me.lstAyuda.Location = New System.Drawing.Point(48, 314)
        Me.lstAyuda.Name = "lstAyuda"
        Me.lstAyuda.Size = New System.Drawing.Size(495, 147)
        Me.lstAyuda.TabIndex = 27
        Me.lstAyuda.Visible = False
        '
        'txtAyuda
        '
        Me.txtAyuda.Cleanable = False
        Me.txtAyuda.Empty = True
        Me.txtAyuda.EnterIndex = -1
        Me.txtAyuda.LabelAssociationKey = -1
        Me.txtAyuda.Location = New System.Drawing.Point(48, 288)
        Me.txtAyuda.Name = "txtAyuda"
        Me.txtAyuda.Size = New System.Drawing.Size(495, 20)
        Me.txtAyuda.TabIndex = 26
        Me.txtAyuda.Validator = Administracion.ValidatorType.None
        Me.txtAyuda.Visible = False
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
        Me.btnConsulta.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control
        Me.btnConsulta.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control
        Me.btnConsulta.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnConsulta.LabelAssociationKey = -1
        Me.btnConsulta.Location = New System.Drawing.Point(83, 222)
        Me.btnConsulta.Name = "btnConsulta"
        Me.btnConsulta.Size = New System.Drawing.Size(89, 40)
        Me.btnConsulta.TabIndex = 25
        Me.ToolTip1.SetToolTip(Me.btnConsulta, "Consulta de Proveedores")
        Me.btnConsulta.UseVisualStyleBackColor = True
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
        Me.btnCancela.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control
        Me.btnCancela.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control
        Me.btnCancela.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancela.LabelAssociationKey = -1
        Me.btnCancela.Location = New System.Drawing.Point(203, 222)
        Me.btnCancela.Name = "btnCancela"
        Me.btnCancela.Size = New System.Drawing.Size(81, 40)
        Me.btnCancela.TabIndex = 24
        Me.ToolTip1.SetToolTip(Me.btnCancela, "Cerrar")
        Me.btnCancela.UseVisualStyleBackColor = True
        '
        'txtHastaProveedor
        '
        Me.txtHastaProveedor.Cleanable = False
        Me.txtHastaProveedor.Empty = True
        Me.txtHastaProveedor.EnterIndex = -1
        Me.txtHastaProveedor.LabelAssociationKey = -1
        Me.txtHastaProveedor.Location = New System.Drawing.Point(286, 100)
        Me.txtHastaProveedor.MaxLength = 11
        Me.txtHastaProveedor.Name = "txtHastaProveedor"
        Me.txtHastaProveedor.Size = New System.Drawing.Size(100, 20)
        Me.txtHastaProveedor.TabIndex = 1
        Me.ToolTip1.SetToolTip(Me.txtHastaProveedor, "Doble Click: Abrir Consulta de Proveedores")
        Me.txtHastaProveedor.Validator = Administracion.ValidatorType.None
        '
        'txtDesdeProveedor
        '
        Me.txtDesdeProveedor.Cleanable = False
        Me.txtDesdeProveedor.Empty = True
        Me.txtDesdeProveedor.EnterIndex = -1
        Me.txtDesdeProveedor.LabelAssociationKey = -1
        Me.txtDesdeProveedor.Location = New System.Drawing.Point(286, 62)
        Me.txtDesdeProveedor.MaxLength = 11
        Me.txtDesdeProveedor.Name = "txtDesdeProveedor"
        Me.txtDesdeProveedor.Size = New System.Drawing.Size(100, 20)
        Me.txtDesdeProveedor.TabIndex = 0
        Me.ToolTip1.SetToolTip(Me.txtDesdeProveedor, "Doble Click: Abrir Consulta de Proveedores")
        Me.txtDesdeProveedor.Validator = Administracion.ValidatorType.None
        '
        'CustomLabel2
        '
        Me.CustomLabel2.AutoSize = True
        Me.CustomLabel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(95, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(82, Byte), Integer))
        Me.CustomLabel2.ControlAssociationKey = -1
        Me.CustomLabel2.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.CustomLabel2.ForeColor = System.Drawing.SystemColors.Control
        Me.CustomLabel2.Location = New System.Drawing.Point(149, 103)
        Me.CustomLabel2.Name = "CustomLabel2"
        Me.CustomLabel2.Size = New System.Drawing.Size(110, 18)
        Me.CustomLabel2.TabIndex = 17
        Me.CustomLabel2.Text = "Hasta Proveedor"
        '
        'CustomLabel1
        '
        Me.CustomLabel1.AutoSize = True
        Me.CustomLabel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(95, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(82, Byte), Integer))
        Me.CustomLabel1.ControlAssociationKey = -1
        Me.CustomLabel1.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.CustomLabel1.ForeColor = System.Drawing.SystemColors.Control
        Me.CustomLabel1.Location = New System.Drawing.Point(149, 65)
        Me.CustomLabel1.Name = "CustomLabel1"
        Me.CustomLabel1.Size = New System.Drawing.Size(115, 18)
        Me.CustomLabel1.TabIndex = 16
        Me.CustomLabel1.Text = "Desde Proveedor"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(590, 50)
        Me.Panel1.TabIndex = 28
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.Control
        Me.Label2.Location = New System.Drawing.Point(367, 10)
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
        Me.Label1.Size = New System.Drawing.Size(310, 19)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Listado de Cuenta Corriente de Proveedores"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(95, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(82, Byte), Integer))
        Me.Panel2.Location = New System.Drawing.Point(0, 50)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(590, 155)
        Me.Panel2.TabIndex = 29
        '
        'btnPorPantalla
        '
        Me.btnPorPantalla.BackgroundImage = Global.Administracion.My.Resources.Resources.Screen_preview
        Me.btnPorPantalla.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnPorPantalla.Cleanable = False
        Me.btnPorPantalla.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnPorPantalla.EnterIndex = -1
        Me.btnPorPantalla.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnPorPantalla.FlatAppearance.BorderSize = 0
        Me.btnPorPantalla.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control
        Me.btnPorPantalla.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control
        Me.btnPorPantalla.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPorPantalla.LabelAssociationKey = -1
        Me.btnPorPantalla.Location = New System.Drawing.Point(315, 220)
        Me.btnPorPantalla.Name = "btnPorPantalla"
        Me.btnPorPantalla.Size = New System.Drawing.Size(81, 40)
        Me.btnPorPantalla.TabIndex = 24
        Me.ToolTip1.SetToolTip(Me.btnPorPantalla, "Mostrar reporte por pantalla")
        Me.btnPorPantalla.UseVisualStyleBackColor = True
        '
        'btnImprimir
        '
        Me.btnImprimir.BackgroundImage = Global.Administracion.My.Resources.Resources.imprimir
        Me.btnImprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnImprimir.Cleanable = False
        Me.btnImprimir.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnImprimir.EnterIndex = -1
        Me.btnImprimir.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnImprimir.FlatAppearance.BorderSize = 0
        Me.btnImprimir.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control
        Me.btnImprimir.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control
        Me.btnImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnImprimir.LabelAssociationKey = -1
        Me.btnImprimir.Location = New System.Drawing.Point(427, 222)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(81, 40)
        Me.btnImprimir.TabIndex = 24
        Me.ToolTip1.SetToolTip(Me.btnImprimir, "Imprimir reporte")
        Me.btnImprimir.UseVisualStyleBackColor = True
        '
        'lstFiltrada
        '
        Me.lstFiltrada.Cleanable = False
        Me.lstFiltrada.EnterIndex = -1
        Me.lstFiltrada.FormattingEnabled = True
        Me.lstFiltrada.LabelAssociationKey = -1
        Me.lstFiltrada.Location = New System.Drawing.Point(48, 314)
        Me.lstFiltrada.Name = "lstFiltrada"
        Me.lstFiltrada.Size = New System.Drawing.Size(495, 147)
        Me.lstFiltrada.TabIndex = 30
        Me.lstFiltrada.Visible = False
        '
        'ListadoCuentaCorrienteProveedores
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(590, 277)
        Me.Controls.Add(Me.lstFiltrada)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.lstAyuda)
        Me.Controls.Add(Me.txtAyuda)
        Me.Controls.Add(Me.btnConsulta)
        Me.Controls.Add(Me.btnImprimir)
        Me.Controls.Add(Me.btnPorPantalla)
        Me.Controls.Add(Me.btnCancela)
        Me.Controls.Add(Me.Grupo1)
        Me.Controls.Add(Me.txtHastaProveedor)
        Me.Controls.Add(Me.txtDesdeProveedor)
        Me.Controls.Add(Me.CustomLabel2)
        Me.Controls.Add(Me.CustomLabel1)
        Me.Controls.Add(Me.Panel2)
        Me.Name = "ListadoCuentaCorrienteProveedores"
        Me.Grupo1.ResumeLayout(False)
        Me.Grupo1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtHastaProveedor As Administracion.CustomTextBox
    Friend WithEvents txtDesdeProveedor As Administracion.CustomTextBox
    Friend WithEvents CustomLabel2 As Administracion.CustomLabel
    Friend WithEvents CustomLabel1 As Administracion.CustomLabel
    Friend WithEvents Grupo1 As System.Windows.Forms.GroupBox
    Friend WithEvents opcCompleto As System.Windows.Forms.RadioButton
    Friend WithEvents opcPendiente As System.Windows.Forms.RadioButton
    Friend WithEvents btnConsulta As Administracion.CustomButton
    Friend WithEvents btnCancela As Administracion.CustomButton
    Friend WithEvents lstAyuda As Administracion.CustomListBox
    Friend WithEvents txtAyuda As Administracion.CustomTextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents lstFiltrada As Administracion.CustomListBox
    Friend WithEvents btnPorPantalla As Administracion.CustomButton
    Friend WithEvents btnImprimir As Administracion.CustomButton
End Class
