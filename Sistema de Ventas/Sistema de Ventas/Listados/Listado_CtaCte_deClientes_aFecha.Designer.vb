<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Listado_CtaCte_deClientes_aFecha
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
        Me.txt_Fecha = New System.Windows.Forms.MaskedTextBox()
        Me.txt_Desde = New System.Windows.Forms.TextBox()
        Me.txt_Hasta = New System.Windows.Forms.TextBox()
        Me.rabtn_Pantalla = New System.Windows.Forms.RadioButton()
        Me.rabtn_Imprimir = New System.Windows.Forms.RadioButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rabtn_Completo = New System.Windows.Forms.RadioButton()
        Me.rabtn_Pendiente = New System.Windows.Forms.RadioButton()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.rabtn_Dolares = New System.Windows.Forms.RadioButton()
        Me.rabtn_Pesos = New System.Windows.Forms.RadioButton()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.rabtn_Total = New System.Windows.Forms.RadioButton()
        Me.rabtn_Documentos = New System.Windows.Forms.RadioButton()
        Me.rabtn_CtaCte = New System.Windows.Forms.RadioButton()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btn_Aceptar = New System.Windows.Forms.Button()
        Me.btn_Consulta = New System.Windows.Forms.Button()
        Me.btn_Cerrar = New System.Windows.Forms.Button()
        Me.panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
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
        Me.panel1.Size = New System.Drawing.Size(382, 50)
        Me.panel1.TabIndex = 40
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(227, 30)
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
        Me.label1.Location = New System.Drawing.Point(3, 6)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(361, 17)
        Me.label1.TabIndex = 0
        Me.label1.Text = "Listado de Cuenta Corriente de Clientes a Fecha"
        '
        'txt_Fecha
        '
        Me.txt_Fecha.Location = New System.Drawing.Point(115, 66)
        Me.txt_Fecha.Mask = "00/00/0000"
        Me.txt_Fecha.Name = "txt_Fecha"
        Me.txt_Fecha.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txt_Fecha.Size = New System.Drawing.Size(69, 20)
        Me.txt_Fecha.TabIndex = 41
        '
        'txt_Desde
        '
        Me.txt_Desde.Location = New System.Drawing.Point(115, 92)
        Me.txt_Desde.MaxLength = 6
        Me.txt_Desde.Name = "txt_Desde"
        Me.txt_Desde.Size = New System.Drawing.Size(48, 20)
        Me.txt_Desde.TabIndex = 42
        '
        'txt_Hasta
        '
        Me.txt_Hasta.Location = New System.Drawing.Point(115, 118)
        Me.txt_Hasta.MaxLength = 6
        Me.txt_Hasta.Name = "txt_Hasta"
        Me.txt_Hasta.Size = New System.Drawing.Size(48, 20)
        Me.txt_Hasta.TabIndex = 43
        '
        'rabtn_Pantalla
        '
        Me.rabtn_Pantalla.AutoSize = True
        Me.rabtn_Pantalla.Checked = True
        Me.rabtn_Pantalla.Location = New System.Drawing.Point(44, 153)
        Me.rabtn_Pantalla.Name = "rabtn_Pantalla"
        Me.rabtn_Pantalla.Size = New System.Drawing.Size(63, 17)
        Me.rabtn_Pantalla.TabIndex = 44
        Me.rabtn_Pantalla.TabStop = True
        Me.rabtn_Pantalla.Text = "Pantalla"
        Me.rabtn_Pantalla.UseVisualStyleBackColor = True
        '
        'rabtn_Imprimir
        '
        Me.rabtn_Imprimir.AutoSize = True
        Me.rabtn_Imprimir.Location = New System.Drawing.Point(113, 153)
        Me.rabtn_Imprimir.Name = "rabtn_Imprimir"
        Me.rabtn_Imprimir.Size = New System.Drawing.Size(60, 17)
        Me.rabtn_Imprimir.TabIndex = 45
        Me.rabtn_Imprimir.Text = "Imprimir"
        Me.rabtn_Imprimir.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rabtn_Completo)
        Me.GroupBox1.Controls.Add(Me.rabtn_Pendiente)
        Me.GroupBox1.Location = New System.Drawing.Point(24, 183)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(179, 59)
        Me.GroupBox1.TabIndex = 46
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Tipo de Listado"
        '
        'rabtn_Completo
        '
        Me.rabtn_Completo.AutoSize = True
        Me.rabtn_Completo.Location = New System.Drawing.Point(20, 39)
        Me.rabtn_Completo.Name = "rabtn_Completo"
        Me.rabtn_Completo.Size = New System.Drawing.Size(69, 17)
        Me.rabtn_Completo.TabIndex = 49
        Me.rabtn_Completo.Text = "Completo"
        Me.rabtn_Completo.UseVisualStyleBackColor = True
        '
        'rabtn_Pendiente
        '
        Me.rabtn_Pendiente.AutoSize = True
        Me.rabtn_Pendiente.Checked = True
        Me.rabtn_Pendiente.Location = New System.Drawing.Point(20, 16)
        Me.rabtn_Pendiente.Name = "rabtn_Pendiente"
        Me.rabtn_Pendiente.Size = New System.Drawing.Size(73, 17)
        Me.rabtn_Pendiente.TabIndex = 48
        Me.rabtn_Pendiente.TabStop = True
        Me.rabtn_Pendiente.Text = "Pendiente"
        Me.rabtn_Pendiente.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.rabtn_Dolares)
        Me.GroupBox2.Controls.Add(Me.rabtn_Pesos)
        Me.GroupBox2.Location = New System.Drawing.Point(215, 210)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(151, 59)
        Me.GroupBox2.TabIndex = 47
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Moneda"
        '
        'rabtn_Dolares
        '
        Me.rabtn_Dolares.AutoSize = True
        Me.rabtn_Dolares.Location = New System.Drawing.Point(16, 39)
        Me.rabtn_Dolares.Name = "rabtn_Dolares"
        Me.rabtn_Dolares.Size = New System.Drawing.Size(61, 17)
        Me.rabtn_Dolares.TabIndex = 47
        Me.rabtn_Dolares.Text = "Dolares"
        Me.rabtn_Dolares.UseVisualStyleBackColor = True
        '
        'rabtn_Pesos
        '
        Me.rabtn_Pesos.AutoSize = True
        Me.rabtn_Pesos.Checked = True
        Me.rabtn_Pesos.Location = New System.Drawing.Point(16, 16)
        Me.rabtn_Pesos.Name = "rabtn_Pesos"
        Me.rabtn_Pesos.Size = New System.Drawing.Size(54, 17)
        Me.rabtn_Pesos.TabIndex = 46
        Me.rabtn_Pesos.TabStop = True
        Me.rabtn_Pesos.Text = "Pesos"
        Me.rabtn_Pesos.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.rabtn_Total)
        Me.GroupBox3.Controls.Add(Me.rabtn_Documentos)
        Me.GroupBox3.Controls.Add(Me.rabtn_CtaCte)
        Me.GroupBox3.Location = New System.Drawing.Point(215, 127)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(151, 83)
        Me.GroupBox3.TabIndex = 47
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Tipos de Comprobantes"
        '
        'rabtn_Total
        '
        Me.rabtn_Total.AutoSize = True
        Me.rabtn_Total.Location = New System.Drawing.Point(6, 62)
        Me.rabtn_Total.Name = "rabtn_Total"
        Me.rabtn_Total.Size = New System.Drawing.Size(49, 17)
        Me.rabtn_Total.TabIndex = 48
        Me.rabtn_Total.Text = "Total"
        Me.rabtn_Total.UseVisualStyleBackColor = True
        '
        'rabtn_Documentos
        '
        Me.rabtn_Documentos.AutoSize = True
        Me.rabtn_Documentos.Location = New System.Drawing.Point(6, 39)
        Me.rabtn_Documentos.Name = "rabtn_Documentos"
        Me.rabtn_Documentos.Size = New System.Drawing.Size(85, 17)
        Me.rabtn_Documentos.TabIndex = 47
        Me.rabtn_Documentos.Text = "Documentos"
        Me.rabtn_Documentos.UseVisualStyleBackColor = True
        '
        'rabtn_CtaCte
        '
        Me.rabtn_CtaCte.AutoSize = True
        Me.rabtn_CtaCte.Checked = True
        Me.rabtn_CtaCte.Location = New System.Drawing.Point(6, 19)
        Me.rabtn_CtaCte.Name = "rabtn_CtaCte"
        Me.rabtn_CtaCte.Size = New System.Drawing.Size(63, 17)
        Me.rabtn_CtaCte.TabIndex = 46
        Me.rabtn_CtaCte.TabStop = True
        Me.rabtn_CtaCte.Text = "Cta. Cte"
        Me.rabtn_CtaCte.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(36, 69)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(37, 13)
        Me.Label3.TabIndex = 48
        Me.Label3.Text = "Fecha"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(36, 95)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(74, 13)
        Me.Label4.TabIndex = 49
        Me.Label4.Text = "Desde Codigo"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(36, 121)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(71, 13)
        Me.Label5.TabIndex = 50
        Me.Label5.Text = "Hasta Codigo"
        '
        'btn_Aceptar
        '
        Me.btn_Aceptar.Location = New System.Drawing.Point(215, 54)
        Me.btn_Aceptar.Name = "btn_Aceptar"
        Me.btn_Aceptar.Size = New System.Drawing.Size(75, 33)
        Me.btn_Aceptar.TabIndex = 51
        Me.btn_Aceptar.Text = "ACEPTAR"
        Me.btn_Aceptar.UseVisualStyleBackColor = True
        '
        'btn_Consulta
        '
        Me.btn_Consulta.Location = New System.Drawing.Point(215, 90)
        Me.btn_Consulta.Name = "btn_Consulta"
        Me.btn_Consulta.Size = New System.Drawing.Size(75, 33)
        Me.btn_Consulta.TabIndex = 52
        Me.btn_Consulta.Text = "CONSULTA"
        Me.btn_Consulta.UseVisualStyleBackColor = True
        '
        'btn_Cerrar
        '
        Me.btn_Cerrar.Location = New System.Drawing.Point(296, 74)
        Me.btn_Cerrar.Name = "btn_Cerrar"
        Me.btn_Cerrar.Size = New System.Drawing.Size(75, 33)
        Me.btn_Cerrar.TabIndex = 53
        Me.btn_Cerrar.Text = "CERRAR"
        Me.btn_Cerrar.UseVisualStyleBackColor = True
        '
        'Listado_CtaCte_deClientes_aFecha
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(382, 274)
        Me.Controls.Add(Me.btn_Cerrar)
        Me.Controls.Add(Me.btn_Consulta)
        Me.Controls.Add(Me.btn_Aceptar)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.rabtn_Imprimir)
        Me.Controls.Add(Me.rabtn_Pantalla)
        Me.Controls.Add(Me.txt_Hasta)
        Me.Controls.Add(Me.txt_Desde)
        Me.Controls.Add(Me.txt_Fecha)
        Me.Controls.Add(Me.panel1)
        Me.Location = New System.Drawing.Point(20, 20)
        Me.Name = "Listado_CtaCte_deClientes_aFecha"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.panel1.ResumeLayout(False)
        Me.panel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents panel1 As System.Windows.Forms.Panel
    Private WithEvents Label2 As System.Windows.Forms.Label
    Private WithEvents label1 As System.Windows.Forms.Label
    Friend WithEvents txt_Fecha As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txt_Desde As System.Windows.Forms.TextBox
    Friend WithEvents txt_Hasta As System.Windows.Forms.TextBox
    Friend WithEvents rabtn_Pantalla As System.Windows.Forms.RadioButton
    Friend WithEvents rabtn_Imprimir As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rabtn_Completo As System.Windows.Forms.RadioButton
    Friend WithEvents rabtn_Pendiente As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents rabtn_Dolares As System.Windows.Forms.RadioButton
    Friend WithEvents rabtn_Pesos As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents rabtn_Total As System.Windows.Forms.RadioButton
    Friend WithEvents rabtn_Documentos As System.Windows.Forms.RadioButton
    Friend WithEvents rabtn_CtaCte As System.Windows.Forms.RadioButton
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btn_Aceptar As System.Windows.Forms.Button
    Friend WithEvents btn_Consulta As System.Windows.Forms.Button
    Friend WithEvents btn_Cerrar As System.Windows.Forms.Button
End Class
