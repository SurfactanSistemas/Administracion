<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ConsultaTiposDeCambios
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
        Me.CalendarControl = New System.Windows.Forms.MonthCalendar()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtReflex120 = New System.Windows.Forms.TextBox()
        Me.txtReflex90 = New System.Windows.Forms.TextBox()
        Me.txtReflex60 = New System.Windows.Forms.TextBox()
        Me.txtReflex30 = New System.Windows.Forms.TextBox()
        Me.txtDivisa = New System.Windows.Forms.TextBox()
        Me.txtEuro = New System.Windows.Forms.TextBox()
        Me.txtDolar = New System.Windows.Forms.TextBox()
        Me.mastxtFecha = New System.Windows.Forms.MaskedTextBox()
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
        Me.panel1.Size = New System.Drawing.Size(547, 49)
        Me.panel1.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(380, 26)
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
        Me.label1.Size = New System.Drawing.Size(160, 17)
        Me.label1.TabIndex = 0
        Me.label1.Text = "Consulta de Cambios"
        '
        'CalendarControl
        '
        Me.CalendarControl.Location = New System.Drawing.Point(15, 55)
        Me.CalendarControl.MaxSelectionCount = 1
        Me.CalendarControl.Name = "CalendarControl"
        Me.CalendarControl.TabIndex = 6
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(398, 157)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(58, 13)
        Me.Label10.TabIndex = 41
        Me.Label10.Text = "Reflex 120"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(398, 131)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(52, 13)
        Me.Label9.TabIndex = 40
        Me.Label9.Text = "Reflex 90"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(398, 105)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(52, 13)
        Me.Label8.TabIndex = 39
        Me.Label8.Text = "Reflex 60"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(398, 79)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(52, 13)
        Me.Label7.TabIndex = 38
        Me.Label7.Text = "Reflex 30"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(213, 157)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(99, 13)
        Me.Label6.TabIndex = 37
        Me.Label6.Text = "Paridad U$S Divisa"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(213, 131)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(85, 13)
        Me.Label5.TabIndex = 36
        Me.Label5.Text = "Paridad del Euro"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(213, 105)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(88, 13)
        Me.Label4.TabIndex = 35
        Me.Label4.Text = "Paridad del Dolar"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(213, 79)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(37, 13)
        Me.Label3.TabIndex = 34
        Me.Label3.Text = "Fecha"
        '
        'txtReflex120
        '
        Me.txtReflex120.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtReflex120.Location = New System.Drawing.Point(463, 154)
        Me.txtReflex120.Name = "txtReflex120"
        Me.txtReflex120.ReadOnly = True
        Me.txtReflex120.Size = New System.Drawing.Size(80, 20)
        Me.txtReflex120.TabIndex = 33
        Me.txtReflex120.Text = "0.000"
        Me.txtReflex120.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtReflex90
        '
        Me.txtReflex90.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtReflex90.Location = New System.Drawing.Point(463, 128)
        Me.txtReflex90.Name = "txtReflex90"
        Me.txtReflex90.ReadOnly = True
        Me.txtReflex90.Size = New System.Drawing.Size(80, 20)
        Me.txtReflex90.TabIndex = 32
        Me.txtReflex90.Text = "0.000"
        Me.txtReflex90.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtReflex60
        '
        Me.txtReflex60.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtReflex60.Location = New System.Drawing.Point(463, 102)
        Me.txtReflex60.Name = "txtReflex60"
        Me.txtReflex60.ReadOnly = True
        Me.txtReflex60.Size = New System.Drawing.Size(80, 20)
        Me.txtReflex60.TabIndex = 31
        Me.txtReflex60.Text = "0.000"
        Me.txtReflex60.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtReflex30
        '
        Me.txtReflex30.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtReflex30.Location = New System.Drawing.Point(463, 76)
        Me.txtReflex30.Name = "txtReflex30"
        Me.txtReflex30.ReadOnly = True
        Me.txtReflex30.Size = New System.Drawing.Size(80, 20)
        Me.txtReflex30.TabIndex = 30
        Me.txtReflex30.Text = "0.000"
        Me.txtReflex30.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtDivisa
        '
        Me.txtDivisa.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDivisa.Location = New System.Drawing.Point(315, 154)
        Me.txtDivisa.Name = "txtDivisa"
        Me.txtDivisa.ReadOnly = True
        Me.txtDivisa.Size = New System.Drawing.Size(80, 20)
        Me.txtDivisa.TabIndex = 29
        Me.txtDivisa.Text = "0.000"
        Me.txtDivisa.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtEuro
        '
        Me.txtEuro.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEuro.Location = New System.Drawing.Point(315, 128)
        Me.txtEuro.Name = "txtEuro"
        Me.txtEuro.ReadOnly = True
        Me.txtEuro.Size = New System.Drawing.Size(80, 20)
        Me.txtEuro.TabIndex = 28
        Me.txtEuro.Text = "0.000"
        Me.txtEuro.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtDolar
        '
        Me.txtDolar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDolar.Location = New System.Drawing.Point(315, 102)
        Me.txtDolar.Name = "txtDolar"
        Me.txtDolar.ReadOnly = True
        Me.txtDolar.Size = New System.Drawing.Size(80, 20)
        Me.txtDolar.TabIndex = 27
        Me.txtDolar.Text = "0.000"
        Me.txtDolar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'mastxtFecha
        '
        Me.mastxtFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mastxtFecha.Location = New System.Drawing.Point(315, 76)
        Me.mastxtFecha.Mask = "00/00/0000"
        Me.mastxtFecha.Name = "mastxtFecha"
        Me.mastxtFecha.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.mastxtFecha.ReadOnly = True
        Me.mastxtFecha.Size = New System.Drawing.Size(80, 20)
        Me.mastxtFecha.TabIndex = 26
        '
        'ConsultaTiposDeCambios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(547, 225)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtReflex120)
        Me.Controls.Add(Me.txtReflex90)
        Me.Controls.Add(Me.txtReflex60)
        Me.Controls.Add(Me.txtReflex30)
        Me.Controls.Add(Me.txtDivisa)
        Me.Controls.Add(Me.txtEuro)
        Me.Controls.Add(Me.txtDolar)
        Me.Controls.Add(Me.mastxtFecha)
        Me.Controls.Add(Me.CalendarControl)
        Me.Controls.Add(Me.panel1)
        Me.Location = New System.Drawing.Point(20, 20)
        Me.Name = "ConsultaTiposDeCambios"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.panel1.ResumeLayout(False)
        Me.panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents panel1 As System.Windows.Forms.Panel
    Private WithEvents Label2 As System.Windows.Forms.Label
    Private WithEvents label1 As System.Windows.Forms.Label
    Friend WithEvents CalendarControl As System.Windows.Forms.MonthCalendar
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtReflex120 As System.Windows.Forms.TextBox
    Friend WithEvents txtReflex90 As System.Windows.Forms.TextBox
    Friend WithEvents txtReflex60 As System.Windows.Forms.TextBox
    Friend WithEvents txtReflex30 As System.Windows.Forms.TextBox
    Friend WithEvents txtDivisa As System.Windows.Forms.TextBox
    Friend WithEvents txtEuro As System.Windows.Forms.TextBox
    Friend WithEvents txtDolar As System.Windows.Forms.TextBox
    Friend WithEvents mastxtFecha As System.Windows.Forms.MaskedTextBox
End Class
