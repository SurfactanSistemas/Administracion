<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AutorizarOrdenTrabajo
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
        Me.cbxRespuesta = New System.Windows.Forms.ComboBox()
        Me.txtObservacionesAutorizo = New System.Windows.Forms.TextBox()
        Me.cbxDestino = New System.Windows.Forms.ComboBox()
        Me.txtCodDesarrollo = New System.Windows.Forms.MaskedTextBox()
        Me.txtObservacionesLaboratorio = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.panel1 = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnGrabar = New System.Windows.Forms.Button()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cbxRespuesta
        '
        Me.cbxRespuesta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxRespuesta.FormattingEnabled = True
        Me.cbxRespuesta.Items.AddRange(New Object() {"", "Aceptada", "Rechazada"})
        Me.cbxRespuesta.Location = New System.Drawing.Point(143, 47)
        Me.cbxRespuesta.Name = "cbxRespuesta"
        Me.cbxRespuesta.Size = New System.Drawing.Size(121, 21)
        Me.cbxRespuesta.TabIndex = 0
        '
        'txtObservacionesAutorizo
        '
        Me.txtObservacionesAutorizo.Location = New System.Drawing.Point(143, 84)
        Me.txtObservacionesAutorizo.MaxLength = 150
        Me.txtObservacionesAutorizo.Multiline = True
        Me.txtObservacionesAutorizo.Name = "txtObservacionesAutorizo"
        Me.txtObservacionesAutorizo.Size = New System.Drawing.Size(253, 50)
        Me.txtObservacionesAutorizo.TabIndex = 1
        '
        'cbxDestino
        '
        Me.cbxDestino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxDestino.FormattingEnabled = True
        Me.cbxDestino.Items.AddRange(New Object() {"", "Desarrollo", "Laboratorio"})
        Me.cbxDestino.Location = New System.Drawing.Point(143, 150)
        Me.cbxDestino.Name = "cbxDestino"
        Me.cbxDestino.Size = New System.Drawing.Size(121, 21)
        Me.cbxDestino.TabIndex = 2
        '
        'txtCodDesarrollo
        '
        Me.txtCodDesarrollo.Location = New System.Drawing.Point(143, 187)
        Me.txtCodDesarrollo.Mask = ">AA-00000"
        Me.txtCodDesarrollo.Name = "txtCodDesarrollo"
        Me.txtCodDesarrollo.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtCodDesarrollo.Size = New System.Drawing.Size(57, 20)
        Me.txtCodDesarrollo.TabIndex = 3
        '
        'txtObservacionesLaboratorio
        '
        Me.txtObservacionesLaboratorio.Location = New System.Drawing.Point(143, 221)
        Me.txtObservacionesLaboratorio.MaxLength = 150
        Me.txtObservacionesLaboratorio.Multiline = True
        Me.txtObservacionesLaboratorio.Name = "txtObservacionesLaboratorio"
        Me.txtObservacionesLaboratorio.Size = New System.Drawing.Size(253, 50)
        Me.txtObservacionesLaboratorio.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 54)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Respuesta"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 84)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(78, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Observaciones"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(9, 153)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(43, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Destino"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(9, 194)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(105, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Codigo de Desarrollo"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(9, 228)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(130, 13)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Observaciones laboratorio"
        '
        'panel1
        '
        Me.panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(34, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.panel1.Controls.Add(Me.Label6)
        Me.panel1.Controls.Add(Me.Label7)
        Me.panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.panel1.Location = New System.Drawing.Point(0, 0)
        Me.panel1.Name = "panel1"
        Me.panel1.Size = New System.Drawing.Size(412, 40)
        Me.panel1.TabIndex = 10
        '
        'Label6
        '
        Me.Label6.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(251, 20)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(155, 20)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "SURFACTAN S.A."
        '
        'Label7
        '
        Me.Label7.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(9, 9)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(232, 17)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Autorizacion de Orden Trabajo"
        '
        'btnGrabar
        '
        Me.btnGrabar.Location = New System.Drawing.Point(60, 277)
        Me.btnGrabar.Name = "btnGrabar"
        Me.btnGrabar.Size = New System.Drawing.Size(117, 41)
        Me.btnGrabar.TabIndex = 11
        Me.btnGrabar.Text = "Grabar"
        Me.btnGrabar.UseVisualStyleBackColor = True
        '
        'btnCerrar
        '
        Me.btnCerrar.Location = New System.Drawing.Point(223, 277)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(117, 41)
        Me.btnCerrar.TabIndex = 12
        Me.btnCerrar.Text = "Cerrar"
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'AutorizarOrdenTrabajo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(412, 335)
        Me.Controls.Add(Me.btnCerrar)
        Me.Controls.Add(Me.btnGrabar)
        Me.Controls.Add(Me.panel1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtObservacionesLaboratorio)
        Me.Controls.Add(Me.txtCodDesarrollo)
        Me.Controls.Add(Me.cbxDestino)
        Me.Controls.Add(Me.txtObservacionesAutorizo)
        Me.Controls.Add(Me.cbxRespuesta)
        Me.Name = "AutorizarOrdenTrabajo"
        Me.panel1.ResumeLayout(False)
        Me.panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cbxRespuesta As System.Windows.Forms.ComboBox
    Friend WithEvents txtObservacionesAutorizo As System.Windows.Forms.TextBox
    Friend WithEvents cbxDestino As System.Windows.Forms.ComboBox
    Friend WithEvents txtCodDesarrollo As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtObservacionesLaboratorio As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Private WithEvents panel1 As System.Windows.Forms.Panel
    Private WithEvents Label6 As System.Windows.Forms.Label
    Private WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btnGrabar As System.Windows.Forms.Button
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
End Class
