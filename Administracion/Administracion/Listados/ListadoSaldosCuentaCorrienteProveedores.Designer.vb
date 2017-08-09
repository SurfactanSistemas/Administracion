<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ListadoSaldosCuentaCorrienteProveedores
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
        Me.txtDesdeProveedor = New Administracion.CustomTextBox()
        Me.CustomLabel1 = New Administracion.CustomLabel()
        Me.CustomLabel2 = New Administracion.CustomLabel()
        Me.txtHastaProveedor = New Administracion.CustomTextBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnConsulta = New Administracion.CustomButton()
        Me.btnCancela = New Administracion.CustomButton()
        Me.btnPantalla = New Administracion.CustomButton()
        Me.btnImprimir = New Administracion.CustomButton()
        Me.lstFiltrada = New Administracion.CustomListBox()
        Me.lstAyuda = New Administracion.CustomListBox()
        Me.txtAyuda = New Administracion.CustomTextBox()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(587, 50)
        Me.Panel1.TabIndex = 23
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.Control
        Me.Label2.Location = New System.Drawing.Point(417, 9)
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
        Me.Label1.Location = New System.Drawing.Point(16, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(379, 19)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Listado de Saldos de Cuenta Corriente de Proveedores"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(95, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(82, Byte), Integer))
        Me.Panel2.Controls.Add(Me.txtDesdeProveedor)
        Me.Panel2.Controls.Add(Me.CustomLabel1)
        Me.Panel2.Controls.Add(Me.CustomLabel2)
        Me.Panel2.Controls.Add(Me.txtHastaProveedor)
        Me.Panel2.Location = New System.Drawing.Point(-2, 47)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(589, 132)
        Me.Panel2.TabIndex = 25
        '
        'txtDesdeProveedor
        '
        Me.txtDesdeProveedor.Cleanable = False
        Me.txtDesdeProveedor.Empty = True
        Me.txtDesdeProveedor.EnterIndex = -1
        Me.txtDesdeProveedor.LabelAssociationKey = -1
        Me.txtDesdeProveedor.Location = New System.Drawing.Point(311, 36)
        Me.txtDesdeProveedor.MaxLength = 11
        Me.txtDesdeProveedor.Name = "txtDesdeProveedor"
        Me.txtDesdeProveedor.Size = New System.Drawing.Size(100, 20)
        Me.txtDesdeProveedor.TabIndex = 14
        Me.ToolTip1.SetToolTip(Me.txtDesdeProveedor, "Desde Código de Proveedor")
        Me.txtDesdeProveedor.Validator = Administracion.ValidatorType.None
        '
        'CustomLabel1
        '
        Me.CustomLabel1.AutoSize = True
        Me.CustomLabel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(95, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(82, Byte), Integer))
        Me.CustomLabel1.ControlAssociationKey = -1
        Me.CustomLabel1.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.CustomLabel1.ForeColor = System.Drawing.SystemColors.Control
        Me.CustomLabel1.Location = New System.Drawing.Point(174, 39)
        Me.CustomLabel1.Name = "CustomLabel1"
        Me.CustomLabel1.Size = New System.Drawing.Size(115, 18)
        Me.CustomLabel1.TabIndex = 12
        Me.CustomLabel1.Text = "Desde Proveedor"
        '
        'CustomLabel2
        '
        Me.CustomLabel2.AutoSize = True
        Me.CustomLabel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(95, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(82, Byte), Integer))
        Me.CustomLabel2.ControlAssociationKey = -1
        Me.CustomLabel2.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.CustomLabel2.ForeColor = System.Drawing.SystemColors.Control
        Me.CustomLabel2.Location = New System.Drawing.Point(174, 73)
        Me.CustomLabel2.Name = "CustomLabel2"
        Me.CustomLabel2.Size = New System.Drawing.Size(110, 18)
        Me.CustomLabel2.TabIndex = 13
        Me.CustomLabel2.Text = "Hasta Proveedor"
        '
        'txtHastaProveedor
        '
        Me.txtHastaProveedor.Cleanable = False
        Me.txtHastaProveedor.Empty = True
        Me.txtHastaProveedor.EnterIndex = -1
        Me.txtHastaProveedor.LabelAssociationKey = -1
        Me.txtHastaProveedor.Location = New System.Drawing.Point(311, 70)
        Me.txtHastaProveedor.MaxLength = 11
        Me.txtHastaProveedor.Name = "txtHastaProveedor"
        Me.txtHastaProveedor.Size = New System.Drawing.Size(100, 20)
        Me.txtHastaProveedor.TabIndex = 15
        Me.ToolTip1.SetToolTip(Me.txtHastaProveedor, "Hasta Código de Proveedor")
        Me.txtHastaProveedor.Validator = Administracion.ValidatorType.None
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
        Me.btnConsulta.Location = New System.Drawing.Point(195, 187)
        Me.btnConsulta.Name = "btnConsulta"
        Me.btnConsulta.Size = New System.Drawing.Size(86, 40)
        Me.btnConsulta.TabIndex = 22
        Me.ToolTip1.SetToolTip(Me.btnConsulta, "Abrir Consulta de Proveedores")
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
        Me.btnCancela.Location = New System.Drawing.Point(84, 187)
        Me.btnCancela.Name = "btnCancela"
        Me.btnCancela.Size = New System.Drawing.Size(86, 40)
        Me.btnCancela.TabIndex = 19
        Me.ToolTip1.SetToolTip(Me.btnCancela, "Cerrar")
        Me.btnCancela.UseVisualStyleBackColor = True
        '
        'btnPantalla
        '
        Me.btnPantalla.BackgroundImage = Global.Administracion.My.Resources.Resources.Screen_preview
        Me.btnPantalla.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnPantalla.Cleanable = False
        Me.btnPantalla.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnPantalla.EnterIndex = -1
        Me.btnPantalla.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnPantalla.FlatAppearance.BorderSize = 0
        Me.btnPantalla.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control
        Me.btnPantalla.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control
        Me.btnPantalla.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPantalla.LabelAssociationKey = -1
        Me.btnPantalla.Location = New System.Drawing.Point(306, 187)
        Me.btnPantalla.Name = "btnPantalla"
        Me.btnPantalla.Size = New System.Drawing.Size(86, 40)
        Me.btnPantalla.TabIndex = 22
        Me.ToolTip1.SetToolTip(Me.btnPantalla, "Mostrar Reporte por Pantalla")
        Me.btnPantalla.UseVisualStyleBackColor = True
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
        Me.btnImprimir.Location = New System.Drawing.Point(417, 187)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(86, 40)
        Me.btnImprimir.TabIndex = 22
        Me.ToolTip1.SetToolTip(Me.btnImprimir, "Imprimir Reporte")
        Me.btnImprimir.UseVisualStyleBackColor = True
        '
        'lstFiltrada
        '
        Me.lstFiltrada.Cleanable = False
        Me.lstFiltrada.EnterIndex = -1
        Me.lstFiltrada.FormattingEnabled = True
        Me.lstFiltrada.LabelAssociationKey = -1
        Me.lstFiltrada.Location = New System.Drawing.Point(82, 274)
        Me.lstFiltrada.Name = "lstFiltrada"
        Me.lstFiltrada.Size = New System.Drawing.Size(417, 147)
        Me.lstFiltrada.TabIndex = 26
        Me.lstFiltrada.Visible = False
        '
        'lstAyuda
        '
        Me.lstAyuda.Cleanable = False
        Me.lstAyuda.EnterIndex = -1
        Me.lstAyuda.FormattingEnabled = True
        Me.lstAyuda.LabelAssociationKey = -1
        Me.lstAyuda.Location = New System.Drawing.Point(82, 274)
        Me.lstAyuda.Name = "lstAyuda"
        Me.lstAyuda.Size = New System.Drawing.Size(417, 147)
        Me.lstAyuda.TabIndex = 21
        Me.lstAyuda.Visible = False
        '
        'txtAyuda
        '
        Me.txtAyuda.Cleanable = False
        Me.txtAyuda.Empty = True
        Me.txtAyuda.EnterIndex = -1
        Me.txtAyuda.LabelAssociationKey = -1
        Me.txtAyuda.Location = New System.Drawing.Point(82, 248)
        Me.txtAyuda.Name = "txtAyuda"
        Me.txtAyuda.Size = New System.Drawing.Size(417, 20)
        Me.txtAyuda.TabIndex = 20
        Me.txtAyuda.Validator = Administracion.ValidatorType.None
        Me.txtAyuda.Visible = False
        '
        'ListadoSaldosCuentaCorrienteProveedores
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(586, 239)
        Me.Controls.Add(Me.lstFiltrada)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnImprimir)
        Me.Controls.Add(Me.btnPantalla)
        Me.Controls.Add(Me.btnConsulta)
        Me.Controls.Add(Me.lstAyuda)
        Me.Controls.Add(Me.txtAyuda)
        Me.Controls.Add(Me.btnCancela)
        Me.Controls.Add(Me.Panel2)
        Me.Name = "ListadoSaldosCuentaCorrienteProveedores"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CustomLabel1 As Administracion.CustomLabel
    Friend WithEvents CustomLabel2 As Administracion.CustomLabel
    Friend WithEvents txtDesdeProveedor As Administracion.CustomTextBox
    Friend WithEvents txtHastaProveedor As Administracion.CustomTextBox
    Friend WithEvents btnCancela As Administracion.CustomButton
    Friend WithEvents txtAyuda As Administracion.CustomTextBox
    Friend WithEvents lstAyuda As Administracion.CustomListBox
    Friend WithEvents btnConsulta As Administracion.CustomButton
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents lstFiltrada As Administracion.CustomListBox
    Friend WithEvents btnPantalla As Administracion.CustomButton
    Friend WithEvents btnImprimir As Administracion.CustomButton
End Class
