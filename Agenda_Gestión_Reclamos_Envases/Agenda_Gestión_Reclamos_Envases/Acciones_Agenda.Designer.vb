<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Acciones_Agenda
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
        Me.txt_ClienteDes = New System.Windows.Forms.TextBox()
        Me.txt_Cliente = New System.Windows.Forms.TextBox()
        Me.txt_Observaciones = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txt_DatosContacto = New System.Windows.Forms.TextBox()
        Me.btn_Cerrar = New System.Windows.Forms.Button()
        Me.txt_Fecha = New System.Windows.Forms.MaskedTextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btn_BorrarDeAgenda = New System.Windows.Forms.Button()
        Me.btn_ModificarAgenda = New System.Windows.Forms.Button()
        Me.btn_PedidosPendientes = New System.Windows.Forms.Button()
        Me.btn_Minutas = New System.Windows.Forms.Button()
        Me.btn_Mail = New System.Windows.Forms.Button()
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
        Me.panel1.Size = New System.Drawing.Size(515, 50)
        Me.panel1.TabIndex = 129
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(360, 30)
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
        Me.label1.Size = New System.Drawing.Size(157, 17)
        Me.label1.TabIndex = 0
        Me.label1.Text = "Acciones por Cliente"
        '
        'txt_ClienteDes
        '
        Me.txt_ClienteDes.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txt_ClienteDes.Location = New System.Drawing.Point(79, 58)
        Me.txt_ClienteDes.Name = "txt_ClienteDes"
        Me.txt_ClienteDes.ReadOnly = True
        Me.txt_ClienteDes.Size = New System.Drawing.Size(278, 20)
        Me.txt_ClienteDes.TabIndex = 133
        '
        'txt_Cliente
        '
        Me.txt_Cliente.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txt_Cliente.Location = New System.Drawing.Point(8, 58)
        Me.txt_Cliente.Name = "txt_Cliente"
        Me.txt_Cliente.ReadOnly = True
        Me.txt_Cliente.Size = New System.Drawing.Size(65, 20)
        Me.txt_Cliente.TabIndex = 132
        '
        'txt_Observaciones
        '
        Me.txt_Observaciones.Location = New System.Drawing.Point(8, 101)
        Me.txt_Observaciones.MaxLength = 300
        Me.txt_Observaciones.Multiline = True
        Me.txt_Observaciones.Name = "txt_Observaciones"
        Me.txt_Observaciones.Size = New System.Drawing.Size(349, 86)
        Me.txt_Observaciones.TabIndex = 134
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(5, 84)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(78, 13)
        Me.Label3.TabIndex = 135
        Me.Label3.Text = "Observaciones"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(5, 190)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(96, 13)
        Me.Label4.TabIndex = 136
        Me.Label4.Text = "Datos de Contacto"
        '
        'txt_DatosContacto
        '
        Me.txt_DatosContacto.Location = New System.Drawing.Point(6, 205)
        Me.txt_DatosContacto.Multiline = True
        Me.txt_DatosContacto.Name = "txt_DatosContacto"
        Me.txt_DatosContacto.ReadOnly = True
        Me.txt_DatosContacto.Size = New System.Drawing.Size(503, 154)
        Me.txt_DatosContacto.TabIndex = 137
        '
        'btn_Cerrar
        '
        Me.btn_Cerrar.Location = New System.Drawing.Point(442, 94)
        Me.btn_Cerrar.Name = "btn_Cerrar"
        Me.btn_Cerrar.Size = New System.Drawing.Size(67, 27)
        Me.btn_Cerrar.TabIndex = 138
        Me.btn_Cerrar.Text = "CERRAR"
        Me.btn_Cerrar.UseVisualStyleBackColor = True
        '
        'txt_Fecha
        '
        Me.txt_Fecha.Location = New System.Drawing.Point(417, 58)
        Me.txt_Fecha.Mask = "00/00/0000"
        Me.txt_Fecha.Name = "txt_Fecha"
        Me.txt_Fecha.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txt_Fecha.Size = New System.Drawing.Size(69, 20)
        Me.txt_Fecha.TabIndex = 139
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(374, 61)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(37, 13)
        Me.Label5.TabIndex = 140
        Me.Label5.Text = "Fecha"
        '
        'btn_BorrarDeAgenda
        '
        Me.btn_BorrarDeAgenda.Location = New System.Drawing.Point(442, 150)
        Me.btn_BorrarDeAgenda.Name = "btn_BorrarDeAgenda"
        Me.btn_BorrarDeAgenda.Size = New System.Drawing.Size(67, 49)
        Me.btn_BorrarDeAgenda.TabIndex = 141
        Me.btn_BorrarDeAgenda.Text = "BORRAR DE AGENDA"
        Me.btn_BorrarDeAgenda.UseVisualStyleBackColor = True
        '
        'btn_ModificarAgenda
        '
        Me.btn_ModificarAgenda.Location = New System.Drawing.Point(363, 94)
        Me.btn_ModificarAgenda.Name = "btn_ModificarAgenda"
        Me.btn_ModificarAgenda.Size = New System.Drawing.Size(76, 27)
        Me.btn_ModificarAgenda.TabIndex = 142
        Me.btn_ModificarAgenda.Text = "MODIFICAR "
        Me.btn_ModificarAgenda.UseVisualStyleBackColor = True
        '
        'btn_PedidosPendientes
        '
        Me.btn_PedidosPendientes.Location = New System.Drawing.Point(363, 129)
        Me.btn_PedidosPendientes.Name = "btn_PedidosPendientes"
        Me.btn_PedidosPendientes.Size = New System.Drawing.Size(76, 40)
        Me.btn_PedidosPendientes.TabIndex = 143
        Me.btn_PedidosPendientes.Text = "PED. PENDIENTES"
        Me.btn_PedidosPendientes.UseVisualStyleBackColor = True
        '
        'btn_Minutas
        '
        Me.btn_Minutas.Location = New System.Drawing.Point(364, 172)
        Me.btn_Minutas.Name = "btn_Minutas"
        Me.btn_Minutas.Size = New System.Drawing.Size(75, 27)
        Me.btn_Minutas.TabIndex = 144
        Me.btn_Minutas.Text = "MINUTAS"
        Me.btn_Minutas.UseVisualStyleBackColor = True
        '
        'btn_Mail
        '
        Me.btn_Mail.Location = New System.Drawing.Point(442, 122)
        Me.btn_Mail.Name = "btn_Mail"
        Me.btn_Mail.Size = New System.Drawing.Size(67, 27)
        Me.btn_Mail.TabIndex = 145
        Me.btn_Mail.Text = "MAIL"
        Me.btn_Mail.UseVisualStyleBackColor = True
        '
        'Acciones_Agenda
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(515, 363)
        Me.Controls.Add(Me.btn_Mail)
        Me.Controls.Add(Me.btn_Minutas)
        Me.Controls.Add(Me.btn_PedidosPendientes)
        Me.Controls.Add(Me.btn_ModificarAgenda)
        Me.Controls.Add(Me.btn_BorrarDeAgenda)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txt_Fecha)
        Me.Controls.Add(Me.btn_Cerrar)
        Me.Controls.Add(Me.txt_DatosContacto)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txt_Observaciones)
        Me.Controls.Add(Me.txt_ClienteDes)
        Me.Controls.Add(Me.txt_Cliente)
        Me.Controls.Add(Me.panel1)
        Me.Name = "Acciones_Agenda"
        Me.panel1.ResumeLayout(False)
        Me.panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents panel1 As System.Windows.Forms.Panel
    Private WithEvents Label2 As System.Windows.Forms.Label
    Private WithEvents label1 As System.Windows.Forms.Label
    Friend WithEvents txt_ClienteDes As System.Windows.Forms.TextBox
    Friend WithEvents txt_Cliente As System.Windows.Forms.TextBox
    Friend WithEvents txt_Observaciones As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txt_DatosContacto As System.Windows.Forms.TextBox
    Friend WithEvents btn_Cerrar As System.Windows.Forms.Button
    Friend WithEvents txt_Fecha As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btn_BorrarDeAgenda As System.Windows.Forms.Button
    Friend WithEvents btn_ModificarAgenda As System.Windows.Forms.Button
    Friend WithEvents btn_PedidosPendientes As System.Windows.Forms.Button
    Friend WithEvents btn_Minutas As System.Windows.Forms.Button
    Friend WithEvents btn_Mail As System.Windows.Forms.Button
End Class
