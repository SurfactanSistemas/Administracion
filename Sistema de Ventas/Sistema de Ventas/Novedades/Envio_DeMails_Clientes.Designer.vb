<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Envio_DeMails_Clientes
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
        Me.txt_Asunto = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txt_CuerpoEMail = New System.Windows.Forms.TextBox()
        Me.txt_LineaExtraI = New System.Windows.Forms.TextBox()
        Me.txt_LineaExtraII = New System.Windows.Forms.TextBox()
        Me.txt_LineaExtraIII = New System.Windows.Forms.TextBox()
        Me.txt_LineaExtraIV = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btn_AdjunArchivo = New System.Windows.Forms.Button()
        Me.btn_Cerrar = New System.Windows.Forms.Button()
        Me.btn_Aceptar = New System.Windows.Forms.Button()
        Me.ProgressBar2 = New System.Windows.Forms.ProgressBar()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.OFDAdjuntarArchivo = New System.Windows.Forms.OpenFileDialog()
        Me.txt_NombreArchivoAdjunto = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
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
        Me.panel1.Size = New System.Drawing.Size(553, 55)
        Me.panel1.TabIndex = 34
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(398, 32)
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
        Me.label1.Size = New System.Drawing.Size(190, 17)
        Me.label1.TabIndex = 0
        Me.label1.Text = "Envio de Mails a Clientes"
        '
        'txt_Asunto
        '
        Me.txt_Asunto.Location = New System.Drawing.Point(88, 72)
        Me.txt_Asunto.Name = "txt_Asunto"
        Me.txt_Asunto.Size = New System.Drawing.Size(337, 20)
        Me.txt_Asunto.TabIndex = 35
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(23, 75)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 13)
        Me.Label3.TabIndex = 36
        Me.Label3.Text = "Asunto"
        '
        'txt_CuerpoEMail
        '
        Me.txt_CuerpoEMail.Location = New System.Drawing.Point(88, 98)
        Me.txt_CuerpoEMail.Multiline = True
        Me.txt_CuerpoEMail.Name = "txt_CuerpoEMail"
        Me.txt_CuerpoEMail.Size = New System.Drawing.Size(337, 138)
        Me.txt_CuerpoEMail.TabIndex = 37
        '
        'txt_LineaExtraI
        '
        Me.txt_LineaExtraI.Location = New System.Drawing.Point(88, 243)
        Me.txt_LineaExtraI.Name = "txt_LineaExtraI"
        Me.txt_LineaExtraI.Size = New System.Drawing.Size(337, 20)
        Me.txt_LineaExtraI.TabIndex = 38
        '
        'txt_LineaExtraII
        '
        Me.txt_LineaExtraII.Location = New System.Drawing.Point(88, 269)
        Me.txt_LineaExtraII.Name = "txt_LineaExtraII"
        Me.txt_LineaExtraII.Size = New System.Drawing.Size(337, 20)
        Me.txt_LineaExtraII.TabIndex = 39
        '
        'txt_LineaExtraIII
        '
        Me.txt_LineaExtraIII.Location = New System.Drawing.Point(88, 295)
        Me.txt_LineaExtraIII.Name = "txt_LineaExtraIII"
        Me.txt_LineaExtraIII.Size = New System.Drawing.Size(337, 20)
        Me.txt_LineaExtraIII.TabIndex = 40
        '
        'txt_LineaExtraIV
        '
        Me.txt_LineaExtraIV.Location = New System.Drawing.Point(88, 321)
        Me.txt_LineaExtraIV.Name = "txt_LineaExtraIV"
        Me.txt_LineaExtraIV.Size = New System.Drawing.Size(337, 20)
        Me.txt_LineaExtraIV.TabIndex = 41
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(23, 101)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(47, 13)
        Me.Label4.TabIndex = 42
        Me.Label4.Text = "Mensaje"
        '
        'btn_AdjunArchivo
        '
        Me.btn_AdjunArchivo.Location = New System.Drawing.Point(475, 342)
        Me.btn_AdjunArchivo.Name = "btn_AdjunArchivo"
        Me.btn_AdjunArchivo.Size = New System.Drawing.Size(75, 46)
        Me.btn_AdjunArchivo.TabIndex = 116
        Me.btn_AdjunArchivo.Text = "ADJUNTAR ARCHIVO"
        Me.btn_AdjunArchivo.UseVisualStyleBackColor = True
        '
        'btn_Cerrar
        '
        Me.btn_Cerrar.Location = New System.Drawing.Point(460, 124)
        Me.btn_Cerrar.Name = "btn_Cerrar"
        Me.btn_Cerrar.Size = New System.Drawing.Size(75, 46)
        Me.btn_Cerrar.TabIndex = 115
        Me.btn_Cerrar.Text = "CERRAR"
        Me.btn_Cerrar.UseVisualStyleBackColor = True
        '
        'btn_Aceptar
        '
        Me.btn_Aceptar.Location = New System.Drawing.Point(460, 72)
        Me.btn_Aceptar.Name = "btn_Aceptar"
        Me.btn_Aceptar.Size = New System.Drawing.Size(75, 46)
        Me.btn_Aceptar.TabIndex = 114
        Me.btn_Aceptar.Text = "ACEPTAR"
        Me.btn_Aceptar.UseVisualStyleBackColor = True
        '
        'ProgressBar2
        '
        Me.ProgressBar2.Location = New System.Drawing.Point(113, 382)
        Me.ProgressBar2.Name = "ProgressBar2"
        Me.ProgressBar2.Size = New System.Drawing.Size(356, 18)
        Me.ProgressBar2.TabIndex = 118
        Me.ProgressBar2.Visible = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.SystemColors.Control
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(13, 382)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(94, 13)
        Me.Label8.TabIndex = 117
        Me.Label8.Text = "Enviando Correos:"
        Me.Label8.Visible = False
        '
        'OFDAdjuntarArchivo
        '
        Me.OFDAdjuntarArchivo.FileName = "OpenFileDialog1"
        '
        'txt_NombreArchivoAdjunto
        '
        Me.txt_NombreArchivoAdjunto.AllowDrop = True
        Me.txt_NombreArchivoAdjunto.Location = New System.Drawing.Point(112, 356)
        Me.txt_NombreArchivoAdjunto.Name = "txt_NombreArchivoAdjunto"
        Me.txt_NombreArchivoAdjunto.ReadOnly = True
        Me.txt_NombreArchivoAdjunto.Size = New System.Drawing.Size(357, 20)
        Me.txt_NombreArchivoAdjunto.TabIndex = 119
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(13, 359)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(85, 13)
        Me.Label5.TabIndex = 120
        Me.Label5.Text = "Archivo Adjunto:"
        '
        'Envio_DeMails_Clientes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(553, 412)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txt_NombreArchivoAdjunto)
        Me.Controls.Add(Me.ProgressBar2)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.btn_AdjunArchivo)
        Me.Controls.Add(Me.btn_Cerrar)
        Me.Controls.Add(Me.btn_Aceptar)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txt_LineaExtraIV)
        Me.Controls.Add(Me.txt_LineaExtraIII)
        Me.Controls.Add(Me.txt_LineaExtraII)
        Me.Controls.Add(Me.txt_LineaExtraI)
        Me.Controls.Add(Me.txt_CuerpoEMail)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txt_Asunto)
        Me.Controls.Add(Me.panel1)
        Me.Location = New System.Drawing.Point(20, 20)
        Me.Name = "Envio_DeMails_Clientes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.panel1.ResumeLayout(False)
        Me.panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents panel1 As System.Windows.Forms.Panel
    Private WithEvents Label2 As System.Windows.Forms.Label
    Private WithEvents label1 As System.Windows.Forms.Label
    Friend WithEvents txt_Asunto As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txt_CuerpoEMail As System.Windows.Forms.TextBox
    Friend WithEvents txt_LineaExtraI As System.Windows.Forms.TextBox
    Friend WithEvents txt_LineaExtraII As System.Windows.Forms.TextBox
    Friend WithEvents txt_LineaExtraIII As System.Windows.Forms.TextBox
    Friend WithEvents txt_LineaExtraIV As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btn_AdjunArchivo As System.Windows.Forms.Button
    Friend WithEvents btn_Cerrar As System.Windows.Forms.Button
    Friend WithEvents btn_Aceptar As System.Windows.Forms.Button
    Friend WithEvents ProgressBar2 As System.Windows.Forms.ProgressBar
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents OFDAdjuntarArchivo As System.Windows.Forms.OpenFileDialog
    Friend WithEvents txt_NombreArchivoAdjunto As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
End Class
