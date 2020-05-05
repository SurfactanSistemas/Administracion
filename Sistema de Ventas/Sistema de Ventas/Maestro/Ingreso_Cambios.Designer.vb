<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Ingreso_Cambios
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
        Me.panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.label1 = New System.Windows.Forms.Label()
        Me.mastxtFecha = New System.Windows.Forms.MaskedTextBox()
        Me.txtDolar = New System.Windows.Forms.TextBox()
        Me.txtEuro = New System.Windows.Forms.TextBox()
        Me.txtDivisa = New System.Windows.Forms.TextBox()
        Me.txtReflex30 = New System.Windows.Forms.TextBox()
        Me.txtReflex60 = New System.Windows.Forms.TextBox()
        Me.txtReflex90 = New System.Windows.Forms.TextBox()
        Me.txtReflex120 = New System.Windows.Forms.TextBox()
        Me.btnGrabar = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Consulta = New System.Windows.Forms.Button()
        Me.btnListado = New System.Windows.Forms.Button()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'panel1
        '
        Me.panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(34, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.panel1.Controls.Add(Me.Label2)
        Me.panel1.Controls.Add(Me.label1)
        Me.panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.panel1.Location = New System.Drawing.Point(0, 0)
        Me.panel1.Name = "panel1"
        Me.panel1.Size = New System.Drawing.Size(340, 49)
        Me.panel1.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(173, 26)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(155, 20)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "SURFACTAN S.A."
        '
        'label1
        '
        Me.label1.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.label1.AutoSize = True
        Me.label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold)
        Me.label1.ForeColor = System.Drawing.Color.White
        Me.label1.Location = New System.Drawing.Point(12, 9)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(151, 17)
        Me.label1.TabIndex = 0
        Me.label1.Text = "Ingreso de Cambios"
        '
        'mastxtFecha
        '
        Me.mastxtFecha.Location = New System.Drawing.Point(104, 73)
        Me.mastxtFecha.Mask = "00/00/0000"
        Me.mastxtFecha.Name = "mastxtFecha"
        Me.mastxtFecha.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.mastxtFecha.Size = New System.Drawing.Size(69, 20)
        Me.mastxtFecha.TabIndex = 5
        Me.mastxtFecha.Text = "00000000"
        '
        'txtDolar
        '
        Me.txtDolar.Location = New System.Drawing.Point(104, 99)
        Me.txtDolar.Name = "txtDolar"
        Me.txtDolar.Size = New System.Drawing.Size(69, 20)
        Me.txtDolar.TabIndex = 6
        Me.txtDolar.Text = "0.000"
        Me.txtDolar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtEuro
        '
        Me.txtEuro.Location = New System.Drawing.Point(104, 125)
        Me.txtEuro.Name = "txtEuro"
        Me.txtEuro.Size = New System.Drawing.Size(69, 20)
        Me.txtEuro.TabIndex = 7
        Me.txtEuro.Text = "0.000"
        Me.txtEuro.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtDivisa
        '
        Me.txtDivisa.Location = New System.Drawing.Point(104, 151)
        Me.txtDivisa.Name = "txtDivisa"
        Me.txtDivisa.Size = New System.Drawing.Size(69, 20)
        Me.txtDivisa.TabIndex = 8
        Me.txtDivisa.Text = "0.000"
        Me.txtDivisa.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtReflex30
        '
        Me.txtReflex30.Location = New System.Drawing.Point(252, 73)
        Me.txtReflex30.Name = "txtReflex30"
        Me.txtReflex30.Size = New System.Drawing.Size(69, 20)
        Me.txtReflex30.TabIndex = 9
        Me.txtReflex30.Text = "0.000"
        Me.txtReflex30.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtReflex60
        '
        Me.txtReflex60.Location = New System.Drawing.Point(252, 99)
        Me.txtReflex60.Name = "txtReflex60"
        Me.txtReflex60.Size = New System.Drawing.Size(69, 20)
        Me.txtReflex60.TabIndex = 10
        Me.txtReflex60.Text = "0.000"
        Me.txtReflex60.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtReflex90
        '
        Me.txtReflex90.Location = New System.Drawing.Point(252, 125)
        Me.txtReflex90.Name = "txtReflex90"
        Me.txtReflex90.Size = New System.Drawing.Size(69, 20)
        Me.txtReflex90.TabIndex = 11
        Me.txtReflex90.Text = "0.000"
        Me.txtReflex90.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtReflex120
        '
        Me.txtReflex120.Location = New System.Drawing.Point(252, 151)
        Me.txtReflex120.Name = "txtReflex120"
        Me.txtReflex120.Size = New System.Drawing.Size(69, 20)
        Me.txtReflex120.TabIndex = 12
        Me.txtReflex120.Text = "0.000"
        Me.txtReflex120.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnGrabar
        '
        Me.btnGrabar.Location = New System.Drawing.Point(33, 203)
        Me.btnGrabar.Name = "btnGrabar"
        Me.btnGrabar.Size = New System.Drawing.Size(75, 23)
        Me.btnGrabar.TabIndex = 13
        Me.btnGrabar.Text = "Grabar"
        Me.btnGrabar.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(117, 203)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 14
        Me.Button2.Text = "Eliminar"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Consulta
        '
        Me.Consulta.Location = New System.Drawing.Point(33, 232)
        Me.Consulta.Name = "Consulta"
        Me.Consulta.Size = New System.Drawing.Size(75, 23)
        Me.Consulta.TabIndex = 15
        Me.Consulta.Text = "Consulta"
        Me.Consulta.UseVisualStyleBackColor = True
        '
        'btnListado
        '
        Me.btnListado.Location = New System.Drawing.Point(117, 232)
        Me.btnListado.Name = "btnListado"
        Me.btnListado.Size = New System.Drawing.Size(75, 23)
        Me.btnListado.TabIndex = 16
        Me.btnListado.Text = "Listado"
        Me.btnListado.UseVisualStyleBackColor = True
        '
        'btnCerrar
        '
        Me.btnCerrar.Location = New System.Drawing.Point(198, 203)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(75, 23)
        Me.btnCerrar.TabIndex = 17
        Me.btnCerrar.Text = "Cerrar"
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(2, 76)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(37, 13)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "Fecha"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(2, 102)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(88, 13)
        Me.Label4.TabIndex = 19
        Me.Label4.Text = "Paridad del Dolar"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(2, 128)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(85, 13)
        Me.Label5.TabIndex = 20
        Me.Label5.Text = "Paridad del Euro"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(2, 154)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(99, 13)
        Me.Label6.TabIndex = 21
        Me.Label6.Text = "Paridad U$S Divisa"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(182, 76)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(52, 13)
        Me.Label7.TabIndex = 22
        Me.Label7.Text = "Reflex 30"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(182, 102)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(52, 13)
        Me.Label8.TabIndex = 23
        Me.Label8.Text = "Reflex 60"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(182, 128)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(52, 13)
        Me.Label9.TabIndex = 24
        Me.Label9.Text = "Reflex 90"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(182, 154)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(58, 13)
        Me.Label10.TabIndex = 25
        Me.Label10.Text = "Reflex 120"
        '
        'Ingreso_Cambios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(340, 268)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btnCerrar)
        Me.Controls.Add(Me.btnListado)
        Me.Controls.Add(Me.Consulta)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.btnGrabar)
        Me.Controls.Add(Me.txtReflex120)
        Me.Controls.Add(Me.txtReflex90)
        Me.Controls.Add(Me.txtReflex60)
        Me.Controls.Add(Me.txtReflex30)
        Me.Controls.Add(Me.txtDivisa)
        Me.Controls.Add(Me.txtEuro)
        Me.Controls.Add(Me.txtDolar)
        Me.Controls.Add(Me.mastxtFecha)
        Me.Controls.Add(Me.panel1)
        Me.Location = New System.Drawing.Point(20, 20)
        Me.Name = "Ingreso_Cambios"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.panel1.ResumeLayout(False)
        Me.panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents panel1 As System.Windows.Forms.Panel
    Private WithEvents Label2 As System.Windows.Forms.Label
    Private WithEvents label1 As System.Windows.Forms.Label
    Friend WithEvents mastxtFecha As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtDolar As System.Windows.Forms.TextBox
    Friend WithEvents txtEuro As System.Windows.Forms.TextBox
    Friend WithEvents txtDivisa As System.Windows.Forms.TextBox
    Friend WithEvents txtReflex30 As System.Windows.Forms.TextBox
    Friend WithEvents txtReflex60 As System.Windows.Forms.TextBox
    Friend WithEvents txtReflex90 As System.Windows.Forms.TextBox
    Friend WithEvents txtReflex120 As System.Windows.Forms.TextBox
    Friend WithEvents btnGrabar As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Consulta As System.Windows.Forms.Button
    Friend WithEvents btnListado As System.Windows.Forms.Button
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
End Class
