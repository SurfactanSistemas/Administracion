<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ListadoCashFlow
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
        Me.txt_DesdeCodigo = New System.Windows.Forms.TextBox()
        Me.txt_HastaCodigo = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.panel1 = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txt_Vence1Fecha = New System.Windows.Forms.MaskedTextBox()
        Me.txt_Vence2Fecha = New System.Windows.Forms.MaskedTextBox()
        Me.txt_Vence3Fecha = New System.Windows.Forms.MaskedTextBox()
        Me.txt_Vence4Fecha = New System.Windows.Forms.MaskedTextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btn_Aceptar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.rabtn_Impresora = New System.Windows.Forms.RadioButton()
        Me.rabtn_Pantalla = New System.Windows.Forms.RadioButton()
        Me.btn_Consulta = New System.Windows.Forms.Button()
        Me.btn_Cerrar = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.rabtn_Dolares = New System.Windows.Forms.RadioButton()
        Me.rabtn_Pesos = New System.Windows.Forms.RadioButton()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.rabtn_Total = New System.Windows.Forms.RadioButton()
        Me.rabtn_Documentos = New System.Windows.Forms.RadioButton()
        Me.rabtn_CtaCte = New System.Windows.Forms.RadioButton()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.rabtn_Vencimiento2 = New System.Windows.Forms.RadioButton()
        Me.rabtn_Vencimiento1 = New System.Windows.Forms.RadioButton()
        Me.panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'txt_DesdeCodigo
        '
        Me.txt_DesdeCodigo.Location = New System.Drawing.Point(88, 28)
        Me.txt_DesdeCodigo.MaxLength = 6
        Me.txt_DesdeCodigo.Name = "txt_DesdeCodigo"
        Me.txt_DesdeCodigo.Size = New System.Drawing.Size(100, 20)
        Me.txt_DesdeCodigo.TabIndex = 0
        '
        'txt_HastaCodigo
        '
        Me.txt_HastaCodigo.Location = New System.Drawing.Point(88, 54)
        Me.txt_HastaCodigo.MaxLength = 6
        Me.txt_HastaCodigo.Name = "txt_HastaCodigo"
        Me.txt_HastaCodigo.Size = New System.Drawing.Size(100, 20)
        Me.txt_HastaCodigo.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 31)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(74, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Desde Codigo"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(8, 57)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(71, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Hasta Codigo"
        '
        'panel1
        '
        Me.panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(34, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.panel1.Controls.Add(Me.Label4)
        Me.panel1.Controls.Add(Me.Label5)
        Me.panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.panel1.Location = New System.Drawing.Point(0, 0)
        Me.panel1.Name = "panel1"
        Me.panel1.Size = New System.Drawing.Size(401, 40)
        Me.panel1.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(225, 10)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(155, 20)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "SURFACTAN S.A."
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(21, 12)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(162, 17)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Listado de Cash Flow"
        '
        'txt_Vence1Fecha
        '
        Me.txt_Vence1Fecha.Location = New System.Drawing.Point(68, 111)
        Me.txt_Vence1Fecha.Mask = "00/00/0000"
        Me.txt_Vence1Fecha.Name = "txt_Vence1Fecha"
        Me.txt_Vence1Fecha.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txt_Vence1Fecha.Size = New System.Drawing.Size(70, 20)
        Me.txt_Vence1Fecha.TabIndex = 6
        '
        'txt_Vence2Fecha
        '
        Me.txt_Vence2Fecha.Location = New System.Drawing.Point(68, 137)
        Me.txt_Vence2Fecha.Mask = "00/00/0000"
        Me.txt_Vence2Fecha.Name = "txt_Vence2Fecha"
        Me.txt_Vence2Fecha.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txt_Vence2Fecha.Size = New System.Drawing.Size(70, 20)
        Me.txt_Vence2Fecha.TabIndex = 7
        '
        'txt_Vence3Fecha
        '
        Me.txt_Vence3Fecha.Location = New System.Drawing.Point(68, 163)
        Me.txt_Vence3Fecha.Mask = "00/00/0000"
        Me.txt_Vence3Fecha.Name = "txt_Vence3Fecha"
        Me.txt_Vence3Fecha.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txt_Vence3Fecha.Size = New System.Drawing.Size(70, 20)
        Me.txt_Vence3Fecha.TabIndex = 8
        '
        'txt_Vence4Fecha
        '
        Me.txt_Vence4Fecha.Location = New System.Drawing.Point(68, 189)
        Me.txt_Vence4Fecha.Mask = "00/00/0000"
        Me.txt_Vence4Fecha.Name = "txt_Vence4Fecha"
        Me.txt_Vence4Fecha.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txt_Vence4Fecha.Size = New System.Drawing.Size(70, 20)
        Me.txt_Vence4Fecha.TabIndex = 9
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btn_Aceptar)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.rabtn_Impresora)
        Me.GroupBox1.Controls.Add(Me.rabtn_Pantalla)
        Me.GroupBox1.Controls.Add(Me.txt_Vence2Fecha)
        Me.GroupBox1.Controls.Add(Me.txt_Vence4Fecha)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txt_Vence1Fecha)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txt_Vence3Fecha)
        Me.GroupBox1.Controls.Add(Me.txt_HastaCodigo)
        Me.GroupBox1.Controls.Add(Me.txt_DesdeCodigo)
        Me.GroupBox1.Location = New System.Drawing.Point(11, 46)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(219, 315)
        Me.GroupBox1.TabIndex = 10
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Control Listado"
        '
        'btn_Aceptar
        '
        Me.btn_Aceptar.Location = New System.Drawing.Point(65, 254)
        Me.btn_Aceptar.Name = "btn_Aceptar"
        Me.btn_Aceptar.Size = New System.Drawing.Size(75, 42)
        Me.btn_Aceptar.TabIndex = 13
        Me.btn_Aceptar.Text = "ACEPTAR"
        Me.btn_Aceptar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(47, 90)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(113, 13)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Parametros de Fechas"
        '
        'rabtn_Impresora
        '
        Me.rabtn_Impresora.AutoSize = True
        Me.rabtn_Impresora.Location = New System.Drawing.Point(117, 222)
        Me.rabtn_Impresora.Name = "rabtn_Impresora"
        Me.rabtn_Impresora.Size = New System.Drawing.Size(71, 17)
        Me.rabtn_Impresora.TabIndex = 11
        Me.rabtn_Impresora.Text = "Impresora"
        Me.rabtn_Impresora.UseVisualStyleBackColor = True
        '
        'rabtn_Pantalla
        '
        Me.rabtn_Pantalla.AutoSize = True
        Me.rabtn_Pantalla.Checked = True
        Me.rabtn_Pantalla.Location = New System.Drawing.Point(28, 222)
        Me.rabtn_Pantalla.Name = "rabtn_Pantalla"
        Me.rabtn_Pantalla.Size = New System.Drawing.Size(63, 17)
        Me.rabtn_Pantalla.TabIndex = 10
        Me.rabtn_Pantalla.TabStop = True
        Me.rabtn_Pantalla.Text = "Pantalla"
        Me.rabtn_Pantalla.UseVisualStyleBackColor = True
        '
        'btn_Consulta
        '
        Me.btn_Consulta.Location = New System.Drawing.Point(237, 48)
        Me.btn_Consulta.Name = "btn_Consulta"
        Me.btn_Consulta.Size = New System.Drawing.Size(75, 42)
        Me.btn_Consulta.TabIndex = 11
        Me.btn_Consulta.Text = "CONSULTA"
        Me.btn_Consulta.UseVisualStyleBackColor = True
        '
        'btn_Cerrar
        '
        Me.btn_Cerrar.Location = New System.Drawing.Point(318, 48)
        Me.btn_Cerrar.Name = "btn_Cerrar"
        Me.btn_Cerrar.Size = New System.Drawing.Size(75, 42)
        Me.btn_Cerrar.TabIndex = 12
        Me.btn_Cerrar.Text = "CERRAR"
        Me.btn_Cerrar.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.rabtn_Dolares)
        Me.GroupBox2.Controls.Add(Me.rabtn_Pesos)
        Me.GroupBox2.Location = New System.Drawing.Point(237, 94)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(156, 75)
        Me.GroupBox2.TabIndex = 13
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Moneda"
        '
        'rabtn_Dolares
        '
        Me.rabtn_Dolares.AutoSize = True
        Me.rabtn_Dolares.Location = New System.Drawing.Point(16, 42)
        Me.rabtn_Dolares.Name = "rabtn_Dolares"
        Me.rabtn_Dolares.Size = New System.Drawing.Size(61, 17)
        Me.rabtn_Dolares.TabIndex = 13
        Me.rabtn_Dolares.Text = "Dolares"
        Me.rabtn_Dolares.UseVisualStyleBackColor = True
        '
        'rabtn_Pesos
        '
        Me.rabtn_Pesos.AutoSize = True
        Me.rabtn_Pesos.Checked = True
        Me.rabtn_Pesos.Location = New System.Drawing.Point(16, 19)
        Me.rabtn_Pesos.Name = "rabtn_Pesos"
        Me.rabtn_Pesos.Size = New System.Drawing.Size(54, 17)
        Me.rabtn_Pesos.TabIndex = 12
        Me.rabtn_Pesos.TabStop = True
        Me.rabtn_Pesos.Text = "Pesos"
        Me.rabtn_Pesos.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.rabtn_Total)
        Me.GroupBox3.Controls.Add(Me.rabtn_Documentos)
        Me.GroupBox3.Controls.Add(Me.rabtn_CtaCte)
        Me.GroupBox3.Location = New System.Drawing.Point(237, 175)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(156, 90)
        Me.GroupBox3.TabIndex = 14
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Tipo de Listado"
        '
        'rabtn_Total
        '
        Me.rabtn_Total.AutoSize = True
        Me.rabtn_Total.Location = New System.Drawing.Point(16, 65)
        Me.rabtn_Total.Name = "rabtn_Total"
        Me.rabtn_Total.Size = New System.Drawing.Size(49, 17)
        Me.rabtn_Total.TabIndex = 16
        Me.rabtn_Total.Text = "Total"
        Me.rabtn_Total.UseVisualStyleBackColor = True
        '
        'rabtn_Documentos
        '
        Me.rabtn_Documentos.AutoSize = True
        Me.rabtn_Documentos.Location = New System.Drawing.Point(16, 42)
        Me.rabtn_Documentos.Name = "rabtn_Documentos"
        Me.rabtn_Documentos.Size = New System.Drawing.Size(85, 17)
        Me.rabtn_Documentos.TabIndex = 15
        Me.rabtn_Documentos.Text = "Documentos"
        Me.rabtn_Documentos.UseVisualStyleBackColor = True
        '
        'rabtn_CtaCte
        '
        Me.rabtn_CtaCte.AutoSize = True
        Me.rabtn_CtaCte.Checked = True
        Me.rabtn_CtaCte.Location = New System.Drawing.Point(16, 19)
        Me.rabtn_CtaCte.Name = "rabtn_CtaCte"
        Me.rabtn_CtaCte.Size = New System.Drawing.Size(66, 17)
        Me.rabtn_CtaCte.TabIndex = 14
        Me.rabtn_CtaCte.TabStop = True
        Me.rabtn_CtaCte.Text = "Cta. Cte."
        Me.rabtn_CtaCte.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.rabtn_Vencimiento2)
        Me.GroupBox4.Controls.Add(Me.rabtn_Vencimiento1)
        Me.GroupBox4.Location = New System.Drawing.Point(237, 271)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(156, 90)
        Me.GroupBox4.TabIndex = 14
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Vencimiento"
        '
        'rabtn_Vencimiento2
        '
        Me.rabtn_Vencimiento2.AutoSize = True
        Me.rabtn_Vencimiento2.Location = New System.Drawing.Point(16, 42)
        Me.rabtn_Vencimiento2.Name = "rabtn_Vencimiento2"
        Me.rabtn_Vencimiento2.Size = New System.Drawing.Size(92, 17)
        Me.rabtn_Vencimiento2.TabIndex = 15
        Me.rabtn_Vencimiento2.Text = "Vencimiento 2"
        Me.rabtn_Vencimiento2.UseVisualStyleBackColor = True
        '
        'rabtn_Vencimiento1
        '
        Me.rabtn_Vencimiento1.AutoSize = True
        Me.rabtn_Vencimiento1.Checked = True
        Me.rabtn_Vencimiento1.Location = New System.Drawing.Point(16, 19)
        Me.rabtn_Vencimiento1.Name = "rabtn_Vencimiento1"
        Me.rabtn_Vencimiento1.Size = New System.Drawing.Size(92, 17)
        Me.rabtn_Vencimiento1.TabIndex = 14
        Me.rabtn_Vencimiento1.TabStop = True
        Me.rabtn_Vencimiento1.Text = "Vencimiento 1"
        Me.rabtn_Vencimiento1.UseVisualStyleBackColor = True
        '
        'ListadoCashFlow
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(401, 366)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.btn_Cerrar)
        Me.Controls.Add(Me.btn_Consulta)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.panel1)
        Me.Location = New System.Drawing.Point(20, 20)
        Me.MaximumSize = New System.Drawing.Size(417, 405)
        Me.MinimumSize = New System.Drawing.Size(417, 405)
        Me.Name = "ListadoCashFlow"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.panel1.ResumeLayout(False)
        Me.panel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txt_DesdeCodigo As System.Windows.Forms.TextBox
    Friend WithEvents txt_HastaCodigo As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Private WithEvents panel1 As System.Windows.Forms.Panel
    Private WithEvents Label4 As System.Windows.Forms.Label
    Private WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txt_Vence1Fecha As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txt_Vence2Fecha As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txt_Vence3Fecha As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txt_Vence4Fecha As System.Windows.Forms.MaskedTextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_Aceptar As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents rabtn_Impresora As System.Windows.Forms.RadioButton
    Friend WithEvents rabtn_Pantalla As System.Windows.Forms.RadioButton
    Friend WithEvents btn_Consulta As System.Windows.Forms.Button
    Friend WithEvents btn_Cerrar As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents rabtn_Dolares As System.Windows.Forms.RadioButton
    Friend WithEvents rabtn_Pesos As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents rabtn_Total As System.Windows.Forms.RadioButton
    Friend WithEvents rabtn_Documentos As System.Windows.Forms.RadioButton
    Friend WithEvents rabtn_CtaCte As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents rabtn_Vencimiento2 As System.Windows.Forms.RadioButton
    Friend WithEvents rabtn_Vencimiento1 As System.Windows.Forms.RadioButton
End Class
