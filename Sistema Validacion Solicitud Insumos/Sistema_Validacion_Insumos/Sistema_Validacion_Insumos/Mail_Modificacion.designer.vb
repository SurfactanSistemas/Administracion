<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Mail_Modificacion
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
        Me.btn_Enviar = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.txt_Asunto = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txt_Cuerpo = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txt_NroSolicitud = New System.Windows.Forms.TextBox()
        Me.btn_AdjuntarArchivos = New System.Windows.Forms.Button()
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
        Me.panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.panel1.Name = "panel1"
        Me.panel1.Size = New System.Drawing.Size(659, 49)
        Me.panel1.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(424, 12)
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
        Me.label1.Location = New System.Drawing.Point(28, 15)
        Me.label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(114, 20)
        Me.label1.TabIndex = 0
        Me.label1.Text = "ENVIO MAIL"
        '
        'btn_Enviar
        '
        Me.btn_Enviar.Location = New System.Drawing.Point(203, 314)
        Me.btn_Enviar.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_Enviar.Name = "btn_Enviar"
        Me.btn_Enviar.Size = New System.Drawing.Size(100, 43)
        Me.btn_Enviar.TabIndex = 7
        Me.btn_Enviar.Text = "ENVIAR"
        Me.btn_Enviar.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(381, 314)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(100, 43)
        Me.Button1.TabIndex = 8
        Me.Button1.Text = "CANCELAR"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'txt_Asunto
        '
        Me.txt_Asunto.Location = New System.Drawing.Point(95, 91)
        Me.txt_Asunto.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_Asunto.Name = "txt_Asunto"
        Me.txt_Asunto.Size = New System.Drawing.Size(547, 22)
        Me.txt_Asunto.TabIndex = 9
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(1, 95)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(52, 17)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Asunto"
        '
        'txt_Cuerpo
        '
        Me.txt_Cuerpo.Location = New System.Drawing.Point(95, 124)
        Me.txt_Cuerpo.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_Cuerpo.Multiline = True
        Me.txt_Cuerpo.Name = "txt_Cuerpo"
        Me.txt_Cuerpo.Size = New System.Drawing.Size(547, 181)
        Me.txt_Cuerpo.TabIndex = 11
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(1, 128)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(54, 17)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Cuerpo"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(1, 63)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(88, 17)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "Nro Solicitud"
        '
        'txt_NroSolicitud
        '
        Me.txt_NroSolicitud.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txt_NroSolicitud.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_NroSolicitud.Location = New System.Drawing.Point(95, 59)
        Me.txt_NroSolicitud.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_NroSolicitud.Name = "txt_NroSolicitud"
        Me.txt_NroSolicitud.ReadOnly = True
        Me.txt_NroSolicitud.Size = New System.Drawing.Size(59, 23)
        Me.txt_NroSolicitud.TabIndex = 14
        '
        'btn_AdjuntarArchivos
        '
        Me.btn_AdjuntarArchivos.AllowDrop = True
        Me.btn_AdjuntarArchivos.Location = New System.Drawing.Point(5, 314)
        Me.btn_AdjuntarArchivos.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_AdjuntarArchivos.Name = "btn_AdjuntarArchivos"
        Me.btn_AdjuntarArchivos.Size = New System.Drawing.Size(101, 43)
        Me.btn_AdjuntarArchivos.TabIndex = 16
        Me.btn_AdjuntarArchivos.Text = "ADJUNTAR ARCHIVO"
        Me.btn_AdjuntarArchivos.UseVisualStyleBackColor = True
        '
        'Mail_Reclamo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(659, 363)
        Me.Controls.Add(Me.btn_AdjuntarArchivos)
        Me.Controls.Add(Me.txt_NroSolicitud)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txt_Cuerpo)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txt_Asunto)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btn_Enviar)
        Me.Controls.Add(Me.panel1)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "Mail_Reclamo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.panel1.ResumeLayout(False)
        Me.panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents panel1 As System.Windows.Forms.Panel
    Private WithEvents Label2 As System.Windows.Forms.Label
    Private WithEvents label1 As System.Windows.Forms.Label
    Friend WithEvents btn_Enviar As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents txt_Asunto As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txt_Cuerpo As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txt_NroSolicitud As System.Windows.Forms.TextBox
    Friend WithEvents btn_AdjuntarArchivos As System.Windows.Forms.Button
End Class
