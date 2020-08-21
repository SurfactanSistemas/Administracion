<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Listado_GastosImportacionXCarpeta
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
        Me.btn_Cerrar = New System.Windows.Forms.Button()
        Me.btn_Aceptar = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.rabtn_Imprimir = New System.Windows.Forms.RadioButton()
        Me.rabtn_Pantalla = New System.Windows.Forms.RadioButton()
        Me.txt_Hasta = New System.Windows.Forms.TextBox()
        Me.txt_Desde = New System.Windows.Forms.TextBox()
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
        Me.panel1.Size = New System.Drawing.Size(351, 50)
        Me.panel1.TabIndex = 41
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(196, 30)
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
        Me.label1.Size = New System.Drawing.Size(343, 17)
        Me.label1.TabIndex = 0
        Me.label1.Text = "Listado de Gastos de Importacion por Carpeta"
        '
        'btn_Cerrar
        '
        Me.btn_Cerrar.Location = New System.Drawing.Point(243, 106)
        Me.btn_Cerrar.Name = "btn_Cerrar"
        Me.btn_Cerrar.Size = New System.Drawing.Size(75, 33)
        Me.btn_Cerrar.TabIndex = 61
        Me.btn_Cerrar.Text = "CERRAR"
        Me.btn_Cerrar.UseVisualStyleBackColor = True
        '
        'btn_Aceptar
        '
        Me.btn_Aceptar.Location = New System.Drawing.Point(243, 66)
        Me.btn_Aceptar.Name = "btn_Aceptar"
        Me.btn_Aceptar.Size = New System.Drawing.Size(75, 33)
        Me.btn_Aceptar.TabIndex = 60
        Me.btn_Aceptar.Text = "ACEPTAR"
        Me.btn_Aceptar.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(11, 103)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(75, 13)
        Me.Label5.TabIndex = 59
        Me.Label5.Text = "Hasta Carpeta"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(11, 77)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(78, 13)
        Me.Label4.TabIndex = 58
        Me.Label4.Text = "Desde Carpeta"
        '
        'rabtn_Imprimir
        '
        Me.rabtn_Imprimir.AutoSize = True
        Me.rabtn_Imprimir.Location = New System.Drawing.Point(163, 106)
        Me.rabtn_Imprimir.Name = "rabtn_Imprimir"
        Me.rabtn_Imprimir.Size = New System.Drawing.Size(60, 17)
        Me.rabtn_Imprimir.TabIndex = 57
        Me.rabtn_Imprimir.Text = "Imprimir"
        Me.rabtn_Imprimir.UseVisualStyleBackColor = True
        '
        'rabtn_Pantalla
        '
        Me.rabtn_Pantalla.AutoSize = True
        Me.rabtn_Pantalla.Checked = True
        Me.rabtn_Pantalla.Location = New System.Drawing.Point(163, 77)
        Me.rabtn_Pantalla.Name = "rabtn_Pantalla"
        Me.rabtn_Pantalla.Size = New System.Drawing.Size(63, 17)
        Me.rabtn_Pantalla.TabIndex = 56
        Me.rabtn_Pantalla.TabStop = True
        Me.rabtn_Pantalla.Text = "Pantalla"
        Me.rabtn_Pantalla.UseVisualStyleBackColor = True
        '
        'txt_Hasta
        '
        Me.txt_Hasta.Location = New System.Drawing.Point(90, 100)
        Me.txt_Hasta.MaxLength = 6
        Me.txt_Hasta.Name = "txt_Hasta"
        Me.txt_Hasta.Size = New System.Drawing.Size(48, 20)
        Me.txt_Hasta.TabIndex = 55
        '
        'txt_Desde
        '
        Me.txt_Desde.Location = New System.Drawing.Point(90, 74)
        Me.txt_Desde.MaxLength = 6
        Me.txt_Desde.Name = "txt_Desde"
        Me.txt_Desde.Size = New System.Drawing.Size(48, 20)
        Me.txt_Desde.TabIndex = 54
        '
        'Listado_GastosImportacionXCarpeta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(351, 157)
        Me.Controls.Add(Me.btn_Cerrar)
        Me.Controls.Add(Me.btn_Aceptar)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.rabtn_Imprimir)
        Me.Controls.Add(Me.rabtn_Pantalla)
        Me.Controls.Add(Me.txt_Hasta)
        Me.Controls.Add(Me.txt_Desde)
        Me.Controls.Add(Me.panel1)
        Me.Location = New System.Drawing.Point(20, 20)
        Me.Name = "Listado_GastosImportacionXCarpeta"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.panel1.ResumeLayout(False)
        Me.panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents panel1 As System.Windows.Forms.Panel
    Private WithEvents Label2 As System.Windows.Forms.Label
    Private WithEvents label1 As System.Windows.Forms.Label
    Friend WithEvents btn_Cerrar As System.Windows.Forms.Button
    Friend WithEvents btn_Aceptar As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents rabtn_Imprimir As System.Windows.Forms.RadioButton
    Friend WithEvents rabtn_Pantalla As System.Windows.Forms.RadioButton
    Friend WithEvents txt_Hasta As System.Windows.Forms.TextBox
    Friend WithEvents txt_Desde As System.Windows.Forms.TextBox
End Class
