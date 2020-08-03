<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Listado_PT_SinVentas
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
        Me.txt_HastaFecha = New System.Windows.Forms.MaskedTextBox()
        Me.txt_DesdeFecha = New System.Windows.Forms.MaskedTextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.rabtn_Impresora = New System.Windows.Forms.RadioButton()
        Me.rabtn_Pantalla = New System.Windows.Forms.RadioButton()
        Me.btn_Cerrar = New System.Windows.Forms.Button()
        Me.btn_Aceptar = New System.Windows.Forms.Button()
        Me.txt_DesdeTer = New System.Windows.Forms.MaskedTextBox()
        Me.txt_HastaTer = New System.Windows.Forms.MaskedTextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btn_Consulta = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txt_Porcentaje = New System.Windows.Forms.TextBox()
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
        Me.panel1.Size = New System.Drawing.Size(353, 55)
        Me.panel1.TabIndex = 32
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(198, 32)
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
        Me.label1.Location = New System.Drawing.Point(3, 8)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(282, 17)
        Me.label1.TabIndex = 0
        Me.label1.Text = "Listado de Verificacion PT Sin Ventas"
        '
        'txt_HastaFecha
        '
        Me.txt_HastaFecha.Location = New System.Drawing.Point(130, 164)
        Me.txt_HastaFecha.Mask = "00/00/0000"
        Me.txt_HastaFecha.Name = "txt_HastaFecha"
        Me.txt_HastaFecha.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txt_HastaFecha.Size = New System.Drawing.Size(68, 20)
        Me.txt_HastaFecha.TabIndex = 93
        '
        'txt_DesdeFecha
        '
        Me.txt_DesdeFecha.Location = New System.Drawing.Point(130, 136)
        Me.txt_DesdeFecha.Mask = "00/00/0000"
        Me.txt_DesdeFecha.Name = "txt_DesdeFecha"
        Me.txt_DesdeFecha.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txt_DesdeFecha.Size = New System.Drawing.Size(68, 20)
        Me.txt_DesdeFecha.TabIndex = 92
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(28, 167)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(68, 13)
        Me.Label4.TabIndex = 91
        Me.Label4.Text = "Hasta Fecha"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(28, 136)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(71, 13)
        Me.Label3.TabIndex = 90
        Me.Label3.Text = "Desde Fecha"
        '
        'rabtn_Impresora
        '
        Me.rabtn_Impresora.AutoSize = True
        Me.rabtn_Impresora.Location = New System.Drawing.Point(146, 221)
        Me.rabtn_Impresora.Name = "rabtn_Impresora"
        Me.rabtn_Impresora.Size = New System.Drawing.Size(71, 17)
        Me.rabtn_Impresora.TabIndex = 89
        Me.rabtn_Impresora.Text = "Impresora"
        Me.rabtn_Impresora.UseVisualStyleBackColor = True
        '
        'rabtn_Pantalla
        '
        Me.rabtn_Pantalla.AutoSize = True
        Me.rabtn_Pantalla.Checked = True
        Me.rabtn_Pantalla.Location = New System.Drawing.Point(38, 220)
        Me.rabtn_Pantalla.Name = "rabtn_Pantalla"
        Me.rabtn_Pantalla.Size = New System.Drawing.Size(63, 17)
        Me.rabtn_Pantalla.TabIndex = 88
        Me.rabtn_Pantalla.TabStop = True
        Me.rabtn_Pantalla.Text = "Pantalla"
        Me.rabtn_Pantalla.UseVisualStyleBackColor = True
        '
        'btn_Cerrar
        '
        Me.btn_Cerrar.Location = New System.Drawing.Point(246, 127)
        Me.btn_Cerrar.Name = "btn_Cerrar"
        Me.btn_Cerrar.Size = New System.Drawing.Size(75, 46)
        Me.btn_Cerrar.TabIndex = 87
        Me.btn_Cerrar.Text = "CERRAR"
        Me.btn_Cerrar.UseVisualStyleBackColor = True
        '
        'btn_Aceptar
        '
        Me.btn_Aceptar.Location = New System.Drawing.Point(246, 75)
        Me.btn_Aceptar.Name = "btn_Aceptar"
        Me.btn_Aceptar.Size = New System.Drawing.Size(75, 46)
        Me.btn_Aceptar.TabIndex = 86
        Me.btn_Aceptar.Text = "ACEPTAR"
        Me.btn_Aceptar.UseVisualStyleBackColor = True
        '
        'txt_DesdeTer
        '
        Me.txt_DesdeTer.Location = New System.Drawing.Point(130, 72)
        Me.txt_DesdeTer.Mask = ">LL-00000-000"
        Me.txt_DesdeTer.Name = "txt_DesdeTer"
        Me.txt_DesdeTer.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txt_DesdeTer.Size = New System.Drawing.Size(79, 20)
        Me.txt_DesdeTer.TabIndex = 94
        '
        'txt_HastaTer
        '
        Me.txt_HastaTer.Location = New System.Drawing.Point(130, 98)
        Me.txt_HastaTer.Mask = ">LL-00000-000"
        Me.txt_HastaTer.Name = "txt_HastaTer"
        Me.txt_HastaTer.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txt_HastaTer.Size = New System.Drawing.Size(79, 20)
        Me.txt_HastaTer.TabIndex = 95
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(28, 75)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(91, 13)
        Me.Label5.TabIndex = 96
        Me.Label5.Text = "Desde Terminado"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(28, 101)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(91, 13)
        Me.Label6.TabIndex = 97
        Me.Label6.Text = "Desde Terminado"
        '
        'btn_Consulta
        '
        Me.btn_Consulta.Location = New System.Drawing.Point(246, 179)
        Me.btn_Consulta.Name = "btn_Consulta"
        Me.btn_Consulta.Size = New System.Drawing.Size(75, 46)
        Me.btn_Consulta.TabIndex = 98
        Me.btn_Consulta.Text = "CONSULTA"
        Me.btn_Consulta.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(28, 196)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(58, 13)
        Me.Label7.TabIndex = 99
        Me.Label7.Text = "Porcentaje"
        '
        'txt_Porcentaje
        '
        Me.txt_Porcentaje.Location = New System.Drawing.Point(130, 193)
        Me.txt_Porcentaje.MaxLength = 6
        Me.txt_Porcentaje.Name = "txt_Porcentaje"
        Me.txt_Porcentaje.Size = New System.Drawing.Size(68, 20)
        Me.txt_Porcentaje.TabIndex = 100
        '
        'Listado_PT_SinVentas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(353, 261)
        Me.Controls.Add(Me.txt_Porcentaje)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.btn_Consulta)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txt_HastaTer)
        Me.Controls.Add(Me.txt_DesdeTer)
        Me.Controls.Add(Me.txt_HastaFecha)
        Me.Controls.Add(Me.txt_DesdeFecha)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.rabtn_Impresora)
        Me.Controls.Add(Me.rabtn_Pantalla)
        Me.Controls.Add(Me.btn_Cerrar)
        Me.Controls.Add(Me.btn_Aceptar)
        Me.Controls.Add(Me.panel1)
        Me.Location = New System.Drawing.Point(20, 20)
        Me.Name = "Listado_PT_SinVentas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.panel1.ResumeLayout(False)
        Me.panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents panel1 As System.Windows.Forms.Panel
    Private WithEvents Label2 As System.Windows.Forms.Label
    Private WithEvents label1 As System.Windows.Forms.Label
    Friend WithEvents txt_HastaFecha As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txt_DesdeFecha As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents rabtn_Impresora As System.Windows.Forms.RadioButton
    Friend WithEvents rabtn_Pantalla As System.Windows.Forms.RadioButton
    Friend WithEvents btn_Cerrar As System.Windows.Forms.Button
    Friend WithEvents btn_Aceptar As System.Windows.Forms.Button
    Friend WithEvents txt_DesdeTer As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txt_HastaTer As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btn_Consulta As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txt_Porcentaje As System.Windows.Forms.TextBox
End Class
