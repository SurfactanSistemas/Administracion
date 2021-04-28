<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class inicio
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.txtAccion = New System.Windows.Forms.TextBox()
        Me.txtRuta = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txt_Mail = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txt_TituloMail = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txt_CuerpoMail = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txt_ContraUsuario = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(223, 310)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(100, 28)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Aceptar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'txtAccion
        '
        Me.txtAccion.Location = New System.Drawing.Point(135, 39)
        Me.txtAccion.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtAccion.Name = "txtAccion"
        Me.txtAccion.Size = New System.Drawing.Size(48, 22)
        Me.txtAccion.TabIndex = 1
        Me.txtAccion.Text = "4"
        '
        'txtRuta
        '
        Me.txtRuta.Location = New System.Drawing.Point(135, 71)
        Me.txtRuta.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtRuta.Name = "txtRuta"
        Me.txtRuta.Size = New System.Drawing.Size(376, 22)
        Me.txtRuta.TabIndex = 2
        Me.txtRuta.Text = "C:\Users\soporte3\Desktop\Gestor de archivos caso 4"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 43)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(102, 17)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Tipo de Accion"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(69, 75)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 17)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Ruta"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(69, 156)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(33, 17)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Mail"
        '
        'txt_Mail
        '
        Me.txt_Mail.Location = New System.Drawing.Point(135, 153)
        Me.txt_Mail.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txt_Mail.Name = "txt_Mail"
        Me.txt_Mail.Size = New System.Drawing.Size(376, 22)
        Me.txt_Mail.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(53, 188)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(72, 17)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Titulo Mail"
        '
        'txt_TituloMail
        '
        Me.txt_TituloMail.Location = New System.Drawing.Point(135, 185)
        Me.txt_TituloMail.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txt_TituloMail.Name = "txt_TituloMail"
        Me.txt_TituloMail.Size = New System.Drawing.Size(376, 22)
        Me.txt_TituloMail.TabIndex = 7
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(47, 220)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(83, 17)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Cuerpo Mail"
        '
        'txt_CuerpoMail
        '
        Me.txt_CuerpoMail.Location = New System.Drawing.Point(135, 217)
        Me.txt_CuerpoMail.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txt_CuerpoMail.Multiline = True
        Me.txt_CuerpoMail.Name = "txt_CuerpoMail"
        Me.txt_CuerpoMail.Size = New System.Drawing.Size(376, 58)
        Me.txt_CuerpoMail.TabIndex = 9
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(28, 107)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(103, 17)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Contra Usuario"
        '
        'txt_ContraUsuario
        '
        Me.txt_ContraUsuario.Location = New System.Drawing.Point(135, 103)
        Me.txt_ContraUsuario.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txt_ContraUsuario.Name = "txt_ContraUsuario"
        Me.txt_ContraUsuario.Size = New System.Drawing.Size(376, 22)
        Me.txt_ContraUsuario.TabIndex = 11
        Me.txt_ContraUsuario.Text = "olula"
        '
        'inicio
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(540, 348)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txt_ContraUsuario)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txt_CuerpoMail)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txt_TituloMail)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txt_Mail)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtRuta)
        Me.Controls.Add(Me.txtAccion)
        Me.Controls.Add(Me.Button1)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "inicio"
        Me.Text = "inicio"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents txtAccion As System.Windows.Forms.TextBox
    Friend WithEvents txtRuta As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txt_Mail As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txt_TituloMail As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txt_CuerpoMail As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txt_ContraUsuario As System.Windows.Forms.TextBox
End Class
