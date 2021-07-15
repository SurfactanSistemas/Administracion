<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EnviarDocumentacion
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txt_Coas = New System.Windows.Forms.TextBox()
        Me.txt_PackingList = New System.Windows.Forms.TextBox()
        Me.txt_CertificadoOrigen = New System.Windows.Forms.TextBox()
        Me.txt_FacturaOriginal = New System.Windows.Forms.TextBox()
        Me.txt_BLOriginal = New System.Windows.Forms.TextBox()
        Me.btn_Imprimir = New System.Windows.Forms.Button()
        Me.btn_Cancelar = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txt_Orden = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txt_Provee = New System.Windows.Forms.TextBox()
        Me.txt_DesProvee = New System.Windows.Forms.TextBox()
        Me.panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'panel1
        '
        Me.panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(34, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.panel1.Controls.Add(Me.Label2)
        Me.panel1.Controls.Add(Me.label1)
        Me.panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.panel1.Location = New System.Drawing.Point(0, 0)
        Me.panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.panel1.Name = "panel1"
        Me.panel1.Size = New System.Drawing.Size(529, 62)
        Me.panel1.TabIndex = 75
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(322, 37)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(192, 25)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "SURFACTAN S.A."
        '
        'label1
        '
        Me.label1.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.label1.AutoSize = True
        Me.label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold)
        Me.label1.ForeColor = System.Drawing.Color.White
        Me.label1.Location = New System.Drawing.Point(4, 7)
        Me.label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(198, 20)
        Me.label1.TabIndex = 0
        Me.label1.Text = "Enviar Documentacion"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txt_Coas)
        Me.GroupBox1.Controls.Add(Me.txt_PackingList)
        Me.GroupBox1.Controls.Add(Me.txt_CertificadoOrigen)
        Me.GroupBox1.Controls.Add(Me.txt_FacturaOriginal)
        Me.GroupBox1.Controls.Add(Me.txt_BLOriginal)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 128)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(505, 205)
        Me.GroupBox1.TabIndex = 76
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Documentacion"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(15, 150)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(46, 17)
        Me.Label7.TabIndex = 9
        Me.Label7.Text = "COAS"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(15, 122)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(84, 17)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "Packing List"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(15, 94)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(142, 17)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "Certificado de Origen"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(15, 66)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(109, 17)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Factura Original"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(15, 38)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(78, 17)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "BL Original"
        '
        'txt_Coas
        '
        Me.txt_Coas.Location = New System.Drawing.Point(162, 147)
        Me.txt_Coas.Name = "txt_Coas"
        Me.txt_Coas.Size = New System.Drawing.Size(337, 22)
        Me.txt_Coas.TabIndex = 4
        '
        'txt_PackingList
        '
        Me.txt_PackingList.Location = New System.Drawing.Point(162, 119)
        Me.txt_PackingList.Name = "txt_PackingList"
        Me.txt_PackingList.Size = New System.Drawing.Size(337, 22)
        Me.txt_PackingList.TabIndex = 3
        '
        'txt_CertificadoOrigen
        '
        Me.txt_CertificadoOrigen.Location = New System.Drawing.Point(162, 91)
        Me.txt_CertificadoOrigen.Name = "txt_CertificadoOrigen"
        Me.txt_CertificadoOrigen.Size = New System.Drawing.Size(337, 22)
        Me.txt_CertificadoOrigen.TabIndex = 2
        '
        'txt_FacturaOriginal
        '
        Me.txt_FacturaOriginal.Location = New System.Drawing.Point(162, 63)
        Me.txt_FacturaOriginal.Name = "txt_FacturaOriginal"
        Me.txt_FacturaOriginal.Size = New System.Drawing.Size(337, 22)
        Me.txt_FacturaOriginal.TabIndex = 1
        '
        'txt_BLOriginal
        '
        Me.txt_BLOriginal.Location = New System.Drawing.Point(162, 35)
        Me.txt_BLOriginal.Name = "txt_BLOriginal"
        Me.txt_BLOriginal.Size = New System.Drawing.Size(337, 22)
        Me.txt_BLOriginal.TabIndex = 0
        '
        'btn_Imprimir
        '
        Me.btn_Imprimir.Location = New System.Drawing.Point(133, 339)
        Me.btn_Imprimir.Name = "btn_Imprimir"
        Me.btn_Imprimir.Size = New System.Drawing.Size(107, 34)
        Me.btn_Imprimir.TabIndex = 0
        Me.btn_Imprimir.Text = "IMPRIMIR"
        Me.btn_Imprimir.UseVisualStyleBackColor = True
        '
        'btn_Cancelar
        '
        Me.btn_Cancelar.Location = New System.Drawing.Point(297, 339)
        Me.btn_Cancelar.Name = "btn_Cancelar"
        Me.btn_Cancelar.Size = New System.Drawing.Size(107, 34)
        Me.btn_Cancelar.TabIndex = 77
        Me.btn_Cancelar.Text = "CANCELAR"
        Me.btn_Cancelar.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(27, 72)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(48, 17)
        Me.Label8.TabIndex = 79
        Me.Label8.Text = "Orden"
        '
        'txt_Orden
        '
        Me.txt_Orden.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txt_Orden.Location = New System.Drawing.Point(114, 69)
        Me.txt_Orden.Name = "txt_Orden"
        Me.txt_Orden.ReadOnly = True
        Me.txt_Orden.Size = New System.Drawing.Size(77, 22)
        Me.txt_Orden.TabIndex = 78
        Me.txt_Orden.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(27, 103)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(74, 17)
        Me.Label9.TabIndex = 81
        Me.Label9.Text = "Proveedor"
        '
        'txt_Provee
        '
        Me.txt_Provee.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txt_Provee.Location = New System.Drawing.Point(114, 100)
        Me.txt_Provee.Name = "txt_Provee"
        Me.txt_Provee.ReadOnly = True
        Me.txt_Provee.Size = New System.Drawing.Size(95, 22)
        Me.txt_Provee.TabIndex = 80
        Me.txt_Provee.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_DesProvee
        '
        Me.txt_DesProvee.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txt_DesProvee.Location = New System.Drawing.Point(215, 100)
        Me.txt_DesProvee.Name = "txt_DesProvee"
        Me.txt_DesProvee.ReadOnly = True
        Me.txt_DesProvee.Size = New System.Drawing.Size(302, 22)
        Me.txt_DesProvee.TabIndex = 82
        '
        'EnviarDocumentacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(529, 383)
        Me.Controls.Add(Me.txt_DesProvee)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txt_Provee)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txt_Orden)
        Me.Controls.Add(Me.btn_Cancelar)
        Me.Controls.Add(Me.btn_Imprimir)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.panel1)
        Me.Name = "EnviarDocumentacion"
        Me.panel1.ResumeLayout(False)
        Me.panel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents panel1 As System.Windows.Forms.Panel
    Private WithEvents Label2 As System.Windows.Forms.Label
    Private WithEvents label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txt_Coas As System.Windows.Forms.TextBox
    Friend WithEvents txt_PackingList As System.Windows.Forms.TextBox
    Friend WithEvents txt_CertificadoOrigen As System.Windows.Forms.TextBox
    Friend WithEvents txt_FacturaOriginal As System.Windows.Forms.TextBox
    Friend WithEvents txt_BLOriginal As System.Windows.Forms.TextBox
    Friend WithEvents btn_Imprimir As System.Windows.Forms.Button
    Friend WithEvents btn_Cancelar As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txt_Orden As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txt_Provee As System.Windows.Forms.TextBox
    Friend WithEvents txt_DesProvee As System.Windows.Forms.TextBox
End Class
