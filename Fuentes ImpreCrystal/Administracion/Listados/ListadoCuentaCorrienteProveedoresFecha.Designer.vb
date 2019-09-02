<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ListadoCuentaCorrienteProveedoresFecha
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
        Me.lstAyuda = New WindowsApplication1.CustomListBox()
        Me.txtAyuda = New WindowsApplication1.CustomTextBox()
        Me.btnConsulta = New WindowsApplication1.CustomButton()
        Me.btnCancela = New WindowsApplication1.CustomButton()
        Me.btnAcepta = New WindowsApplication1.CustomButton()
        Me.txtHastaProveedor = New WindowsApplication1.CustomTextBox()
        Me.txtDesdeProveedor = New WindowsApplication1.CustomTextBox()
        Me.CustomLabel2 = New WindowsApplication1.CustomLabel()
        Me.CustomLabel1 = New WindowsApplication1.CustomLabel()
        Me.txtFechaEmision = New System.Windows.Forms.MaskedTextBox()
        Me.CustomLabel3 = New WindowsApplication1.CustomLabel()
        Me.Grupo2 = New System.Windows.Forms.GroupBox()
        Me.opcImpesora = New System.Windows.Forms.RadioButton()
        Me.opcPantalla = New System.Windows.Forms.RadioButton()
        Me.Grupo2.SuspendLayout()
        Me.SuspendLayout()
        '
        'lstAyuda
        '
        Me.lstAyuda.Cleanable = False
        Me.lstAyuda.EnterIndex = -1
        Me.lstAyuda.FormattingEnabled = True
        Me.lstAyuda.LabelAssociationKey = -1
        Me.lstAyuda.Location = New System.Drawing.Point(28, 296)
        Me.lstAyuda.Name = "lstAyuda"
        Me.lstAyuda.Size = New System.Drawing.Size(417, 147)
        Me.lstAyuda.TabIndex = 37
        Me.lstAyuda.Visible = False
        '
        'txtAyuda
        '
        Me.txtAyuda.Cleanable = False
        Me.txtAyuda.Empty = True
        Me.txtAyuda.EnterIndex = -1
        Me.txtAyuda.LabelAssociationKey = -1
        Me.txtAyuda.Location = New System.Drawing.Point(28, 270)
        Me.txtAyuda.Name = "txtAyuda"
        Me.txtAyuda.Size = New System.Drawing.Size(417, 20)
        Me.txtAyuda.TabIndex = 36
        Me.txtAyuda.Validator = WindowsApplication1.ValidatorType.None
        Me.txtAyuda.Visible = False
        '
        'btnConsulta
        '
        Me.btnConsulta.Cleanable = False
        Me.btnConsulta.EnterIndex = -1
        Me.btnConsulta.LabelAssociationKey = -1
        Me.btnConsulta.Location = New System.Drawing.Point(325, 208)
        Me.btnConsulta.Name = "btnConsulta"
        Me.btnConsulta.Size = New System.Drawing.Size(120, 40)
        Me.btnConsulta.TabIndex = 35
        Me.btnConsulta.Text = "Consulta"
        Me.btnConsulta.UseVisualStyleBackColor = True
        '
        'btnCancela
        '
        Me.btnCancela.Cleanable = False
        Me.btnCancela.EnterIndex = -1
        Me.btnCancela.LabelAssociationKey = -1
        Me.btnCancela.Location = New System.Drawing.Point(183, 208)
        Me.btnCancela.Name = "btnCancela"
        Me.btnCancela.Size = New System.Drawing.Size(120, 40)
        Me.btnCancela.TabIndex = 34
        Me.btnCancela.Text = "Cancela"
        Me.btnCancela.UseVisualStyleBackColor = True
        '
        'btnAcepta
        '
        Me.btnAcepta.Cleanable = False
        Me.btnAcepta.EnterIndex = -1
        Me.btnAcepta.LabelAssociationKey = -1
        Me.btnAcepta.Location = New System.Drawing.Point(32, 207)
        Me.btnAcepta.Name = "btnAcepta"
        Me.btnAcepta.Size = New System.Drawing.Size(120, 41)
        Me.btnAcepta.TabIndex = 33
        Me.btnAcepta.Text = "Acepta"
        Me.btnAcepta.UseVisualStyleBackColor = True
        '
        'txtHastaProveedor
        '
        Me.txtHastaProveedor.Cleanable = False
        Me.txtHastaProveedor.Empty = True
        Me.txtHastaProveedor.EnterIndex = -1
        Me.txtHastaProveedor.LabelAssociationKey = -1
        Me.txtHastaProveedor.Location = New System.Drawing.Point(232, 92)
        Me.txtHastaProveedor.Name = "txtHastaProveedor"
        Me.txtHastaProveedor.Size = New System.Drawing.Size(100, 20)
        Me.txtHastaProveedor.TabIndex = 2
        Me.txtHastaProveedor.Validator = WindowsApplication1.ValidatorType.None
        '
        'txtDesdeProveedor
        '
        Me.txtDesdeProveedor.Cleanable = False
        Me.txtDesdeProveedor.Empty = True
        Me.txtDesdeProveedor.EnterIndex = -1
        Me.txtDesdeProveedor.LabelAssociationKey = -1
        Me.txtDesdeProveedor.Location = New System.Drawing.Point(232, 54)
        Me.txtDesdeProveedor.Name = "txtDesdeProveedor"
        Me.txtDesdeProveedor.Size = New System.Drawing.Size(100, 20)
        Me.txtDesdeProveedor.TabIndex = 1
        Me.txtDesdeProveedor.Validator = WindowsApplication1.ValidatorType.None
        '
        'CustomLabel2
        '
        Me.CustomLabel2.AutoSize = True
        Me.CustomLabel2.ControlAssociationKey = -1
        Me.CustomLabel2.Location = New System.Drawing.Point(101, 95)
        Me.CustomLabel2.Name = "CustomLabel2"
        Me.CustomLabel2.Size = New System.Drawing.Size(87, 13)
        Me.CustomLabel2.TabIndex = 31
        Me.CustomLabel2.Text = "Hasta Proveedor"
        '
        'CustomLabel1
        '
        Me.CustomLabel1.AutoSize = True
        Me.CustomLabel1.ControlAssociationKey = -1
        Me.CustomLabel1.Location = New System.Drawing.Point(101, 57)
        Me.CustomLabel1.Name = "CustomLabel1"
        Me.CustomLabel1.Size = New System.Drawing.Size(90, 13)
        Me.CustomLabel1.TabIndex = 30
        Me.CustomLabel1.Text = "Desde Proveedor"
        '
        'txtFechaEmision
        '
        Me.txtFechaEmision.Location = New System.Drawing.Point(232, 12)
        Me.txtFechaEmision.Mask = "##/##/####"
        Me.txtFechaEmision.Name = "txtFechaEmision"
        Me.txtFechaEmision.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtFechaEmision.Size = New System.Drawing.Size(106, 20)
        Me.txtFechaEmision.TabIndex = 0
        '
        'CustomLabel3
        '
        Me.CustomLabel3.AutoSize = True
        Me.CustomLabel3.ControlAssociationKey = -1
        Me.CustomLabel3.Location = New System.Drawing.Point(101, 15)
        Me.CustomLabel3.Name = "CustomLabel3"
        Me.CustomLabel3.Size = New System.Drawing.Size(76, 13)
        Me.CustomLabel3.TabIndex = 46
        Me.CustomLabel3.Text = "Fecha Emision"
        '
        'Grupo2
        '
        Me.Grupo2.Controls.Add(Me.opcImpesora)
        Me.Grupo2.Controls.Add(Me.opcPantalla)
        Me.Grupo2.Location = New System.Drawing.Point(33, 136)
        Me.Grupo2.Name = "Grupo2"
        Me.Grupo2.Size = New System.Drawing.Size(410, 49)
        Me.Grupo2.TabIndex = 47
        Me.Grupo2.TabStop = False
        Me.Grupo2.Text = "Destino"
        '
        'opcImpesora
        '
        Me.opcImpesora.AutoSize = True
        Me.opcImpesora.Location = New System.Drawing.Point(237, 17)
        Me.opcImpesora.Name = "opcImpesora"
        Me.opcImpesora.Size = New System.Drawing.Size(71, 17)
        Me.opcImpesora.TabIndex = 20
        Me.opcImpesora.TabStop = True
        Me.opcImpesora.Text = "Impresora"
        Me.opcImpesora.UseVisualStyleBackColor = True
        '
        'opcPantalla
        '
        Me.opcPantalla.AutoSize = True
        Me.opcPantalla.Location = New System.Drawing.Point(103, 17)
        Me.opcPantalla.Name = "opcPantalla"
        Me.opcPantalla.Size = New System.Drawing.Size(63, 17)
        Me.opcPantalla.TabIndex = 19
        Me.opcPantalla.TabStop = True
        Me.opcPantalla.Text = "Pantalla"
        Me.opcPantalla.UseVisualStyleBackColor = True
        '
        'ListadoCuentaCorrienteProveedoresFecha
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(477, 345)
        Me.Controls.Add(Me.Grupo2)
        Me.Controls.Add(Me.txtFechaEmision)
        Me.Controls.Add(Me.CustomLabel3)
        Me.Controls.Add(Me.lstAyuda)
        Me.Controls.Add(Me.txtAyuda)
        Me.Controls.Add(Me.btnConsulta)
        Me.Controls.Add(Me.btnCancela)
        Me.Controls.Add(Me.btnAcepta)
        Me.Controls.Add(Me.txtHastaProveedor)
        Me.Controls.Add(Me.txtDesdeProveedor)
        Me.Controls.Add(Me.CustomLabel2)
        Me.Controls.Add(Me.CustomLabel1)
        Me.Name = "ListadoCuentaCorrienteProveedoresFecha"
        Me.Text = "Listado de Cuenta Corriente de Proveedores a Fecha"
        Me.Grupo2.ResumeLayout(False)
        Me.Grupo2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lstAyuda As WindowsApplication1.CustomListBox
    Friend WithEvents txtAyuda As WindowsApplication1.CustomTextBox
    Friend WithEvents btnConsulta As WindowsApplication1.CustomButton
    Friend WithEvents btnCancela As WindowsApplication1.CustomButton
    Friend WithEvents btnAcepta As WindowsApplication1.CustomButton
    Friend WithEvents txtHastaProveedor As WindowsApplication1.CustomTextBox
    Friend WithEvents txtDesdeProveedor As WindowsApplication1.CustomTextBox
    Friend WithEvents CustomLabel2 As WindowsApplication1.CustomLabel
    Friend WithEvents CustomLabel1 As WindowsApplication1.CustomLabel
    Friend WithEvents txtFechaEmision As System.Windows.Forms.MaskedTextBox
    Friend WithEvents CustomLabel3 As WindowsApplication1.CustomLabel
    Friend WithEvents Grupo2 As System.Windows.Forms.GroupBox
    Friend WithEvents opcImpesora As System.Windows.Forms.RadioButton
    Friend WithEvents opcPantalla As System.Windows.Forms.RadioButton
End Class
