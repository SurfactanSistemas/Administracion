<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SaldoDe_CtaCte_deCliente
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.rabtn_Total = New System.Windows.Forms.RadioButton()
        Me.rabtn_Documentos = New System.Windows.Forms.RadioButton()
        Me.rabtn_CtaCte = New System.Windows.Forms.RadioButton()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.rabtn_Dolares = New System.Windows.Forms.RadioButton()
        Me.rabtn_Pesos = New System.Windows.Forms.RadioButton()
        Me.txt_Hasta = New System.Windows.Forms.TextBox()
        Me.rabtn_Impresora = New System.Windows.Forms.RadioButton()
        Me.txt_Desde = New System.Windows.Forms.TextBox()
        Me.rabtn_Pantalla = New System.Windows.Forms.RadioButton()
        Me.panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.label1 = New System.Windows.Forms.Label()
        Me.btn_Cerrar = New System.Windows.Forms.Button()
        Me.btn_Consulta = New System.Windows.Forms.Button()
        Me.btn_Aceptar = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.GroupBox4)
        Me.GroupBox1.Controls.Add(Me.GroupBox3)
        Me.GroupBox1.Controls.Add(Me.txt_Hasta)
        Me.GroupBox1.Controls.Add(Me.rabtn_Impresora)
        Me.GroupBox1.Controls.Add(Me.txt_Desde)
        Me.GroupBox1.Controls.Add(Me.rabtn_Pantalla)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 46)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(337, 220)
        Me.GroupBox1.TabIndex = 12
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Control Listado"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(9, 51)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(71, 13)
        Me.Label4.TabIndex = 17
        Me.Label4.Text = "Hasta Codigo"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(9, 25)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(74, 13)
        Me.Label3.TabIndex = 16
        Me.Label3.Text = "Desde Codigo"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.rabtn_Total)
        Me.GroupBox4.Controls.Add(Me.rabtn_Documentos)
        Me.GroupBox4.Controls.Add(Me.rabtn_CtaCte)
        Me.GroupBox4.Location = New System.Drawing.Point(6, 74)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(142, 140)
        Me.GroupBox4.TabIndex = 14
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Tipo de Listado"
        '
        'rabtn_Total
        '
        Me.rabtn_Total.AutoSize = True
        Me.rabtn_Total.Location = New System.Drawing.Point(6, 107)
        Me.rabtn_Total.Name = "rabtn_Total"
        Me.rabtn_Total.Size = New System.Drawing.Size(49, 17)
        Me.rabtn_Total.TabIndex = 20
        Me.rabtn_Total.Text = "Total"
        Me.rabtn_Total.UseVisualStyleBackColor = True
        '
        'rabtn_Documentos
        '
        Me.rabtn_Documentos.AutoSize = True
        Me.rabtn_Documentos.Location = New System.Drawing.Point(6, 70)
        Me.rabtn_Documentos.Name = "rabtn_Documentos"
        Me.rabtn_Documentos.Size = New System.Drawing.Size(85, 17)
        Me.rabtn_Documentos.TabIndex = 18
        Me.rabtn_Documentos.Text = "Documentos"
        Me.rabtn_Documentos.UseVisualStyleBackColor = True
        '
        'rabtn_CtaCte
        '
        Me.rabtn_CtaCte.AutoSize = True
        Me.rabtn_CtaCte.Checked = True
        Me.rabtn_CtaCte.Location = New System.Drawing.Point(6, 29)
        Me.rabtn_CtaCte.Name = "rabtn_CtaCte"
        Me.rabtn_CtaCte.Size = New System.Drawing.Size(60, 17)
        Me.rabtn_CtaCte.TabIndex = 17
        Me.rabtn_CtaCte.TabStop = True
        Me.rabtn_CtaCte.Text = "Cta Cte"
        Me.rabtn_CtaCte.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.rabtn_Dolares)
        Me.GroupBox3.Controls.Add(Me.rabtn_Pesos)
        Me.GroupBox3.Location = New System.Drawing.Point(166, 74)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(130, 124)
        Me.GroupBox3.TabIndex = 13
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Moneda"
        '
        'rabtn_Dolares
        '
        Me.rabtn_Dolares.AutoSize = True
        Me.rabtn_Dolares.Location = New System.Drawing.Point(25, 70)
        Me.rabtn_Dolares.Name = "rabtn_Dolares"
        Me.rabtn_Dolares.Size = New System.Drawing.Size(61, 17)
        Me.rabtn_Dolares.TabIndex = 18
        Me.rabtn_Dolares.Text = "Dolares"
        Me.rabtn_Dolares.UseVisualStyleBackColor = True
        '
        'rabtn_Pesos
        '
        Me.rabtn_Pesos.AutoSize = True
        Me.rabtn_Pesos.Checked = True
        Me.rabtn_Pesos.Location = New System.Drawing.Point(25, 29)
        Me.rabtn_Pesos.Name = "rabtn_Pesos"
        Me.rabtn_Pesos.Size = New System.Drawing.Size(54, 17)
        Me.rabtn_Pesos.TabIndex = 17
        Me.rabtn_Pesos.TabStop = True
        Me.rabtn_Pesos.Text = "Pesos"
        Me.rabtn_Pesos.UseVisualStyleBackColor = True
        '
        'txt_Hasta
        '
        Me.txt_Hasta.Location = New System.Drawing.Point(89, 48)
        Me.txt_Hasta.MaxLength = 6
        Me.txt_Hasta.Name = "txt_Hasta"
        Me.txt_Hasta.Size = New System.Drawing.Size(100, 20)
        Me.txt_Hasta.TabIndex = 6
        '
        'rabtn_Impresora
        '
        Me.rabtn_Impresora.AutoSize = True
        Me.rabtn_Impresora.Location = New System.Drawing.Point(225, 47)
        Me.rabtn_Impresora.Name = "rabtn_Impresora"
        Me.rabtn_Impresora.Size = New System.Drawing.Size(71, 17)
        Me.rabtn_Impresora.TabIndex = 10
        Me.rabtn_Impresora.Text = "Impresora"
        Me.rabtn_Impresora.UseVisualStyleBackColor = True
        '
        'txt_Desde
        '
        Me.txt_Desde.Location = New System.Drawing.Point(89, 22)
        Me.txt_Desde.MaxLength = 6
        Me.txt_Desde.Name = "txt_Desde"
        Me.txt_Desde.Size = New System.Drawing.Size(100, 20)
        Me.txt_Desde.TabIndex = 5
        '
        'rabtn_Pantalla
        '
        Me.rabtn_Pantalla.AutoSize = True
        Me.rabtn_Pantalla.Checked = True
        Me.rabtn_Pantalla.Location = New System.Drawing.Point(225, 19)
        Me.rabtn_Pantalla.Name = "rabtn_Pantalla"
        Me.rabtn_Pantalla.Size = New System.Drawing.Size(63, 17)
        Me.rabtn_Pantalla.TabIndex = 9
        Me.rabtn_Pantalla.TabStop = True
        Me.rabtn_Pantalla.Text = "Pantalla"
        Me.rabtn_Pantalla.UseVisualStyleBackColor = True
        '
        'panel1
        '
        Me.panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(34, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.panel1.Controls.Add(Me.Label2)
        Me.panel1.Controls.Add(Me.label1)
        Me.panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.panel1.Location = New System.Drawing.Point(0, 0)
        Me.panel1.Name = "panel1"
        Me.panel1.Size = New System.Drawing.Size(442, 40)
        Me.panel1.TabIndex = 13
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(287, 20)
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
        Me.label1.Location = New System.Drawing.Point(3, 13)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(286, 17)
        Me.label1.TabIndex = 0
        Me.label1.Text = "Saldo de Cuenta Corriente de Clientes"
        '
        'btn_Cerrar
        '
        Me.btn_Cerrar.Location = New System.Drawing.Point(355, 175)
        Me.btn_Cerrar.Name = "btn_Cerrar"
        Me.btn_Cerrar.Size = New System.Drawing.Size(75, 46)
        Me.btn_Cerrar.TabIndex = 17
        Me.btn_Cerrar.Text = "CERRAR"
        Me.btn_Cerrar.UseVisualStyleBackColor = True
        '
        'btn_Consulta
        '
        Me.btn_Consulta.Location = New System.Drawing.Point(355, 116)
        Me.btn_Consulta.Name = "btn_Consulta"
        Me.btn_Consulta.Size = New System.Drawing.Size(75, 46)
        Me.btn_Consulta.TabIndex = 16
        Me.btn_Consulta.Text = "CONSULTA"
        Me.btn_Consulta.UseVisualStyleBackColor = True
        '
        'btn_Aceptar
        '
        Me.btn_Aceptar.Location = New System.Drawing.Point(355, 53)
        Me.btn_Aceptar.Name = "btn_Aceptar"
        Me.btn_Aceptar.Size = New System.Drawing.Size(75, 46)
        Me.btn_Aceptar.TabIndex = 15
        Me.btn_Aceptar.Text = "ACEPTAR"
        Me.btn_Aceptar.UseVisualStyleBackColor = True
        '
        'SaldoDe_CtaCte_deCliente
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(442, 274)
        Me.Controls.Add(Me.btn_Cerrar)
        Me.Controls.Add(Me.btn_Consulta)
        Me.Controls.Add(Me.btn_Aceptar)
        Me.Controls.Add(Me.panel1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Location = New System.Drawing.Point(20, 20)
        Me.Name = "SaldoDe_CtaCte_deCliente"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.panel1.ResumeLayout(False)
        Me.panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents rabtn_Total As System.Windows.Forms.RadioButton
    Friend WithEvents rabtn_Documentos As System.Windows.Forms.RadioButton
    Friend WithEvents rabtn_CtaCte As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents rabtn_Dolares As System.Windows.Forms.RadioButton
    Friend WithEvents rabtn_Pesos As System.Windows.Forms.RadioButton
    Friend WithEvents txt_Hasta As System.Windows.Forms.TextBox
    Friend WithEvents rabtn_Impresora As System.Windows.Forms.RadioButton
    Friend WithEvents txt_Desde As System.Windows.Forms.TextBox
    Friend WithEvents rabtn_Pantalla As System.Windows.Forms.RadioButton
    Private WithEvents panel1 As System.Windows.Forms.Panel
    Private WithEvents Label2 As System.Windows.Forms.Label
    Private WithEvents label1 As System.Windows.Forms.Label
    Friend WithEvents btn_Cerrar As System.Windows.Forms.Button
    Friend WithEvents btn_Consulta As System.Windows.Forms.Button
    Friend WithEvents btn_Aceptar As System.Windows.Forms.Button
End Class
