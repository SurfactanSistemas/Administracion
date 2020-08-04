<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AltaAgenda
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
        Me.lblDescCliente = New System.Windows.Forms.Label()
        Me.txtCliente = New System.Windows.Forms.MaskedTextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtFecha = New System.Windows.Forms.MaskedTextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtHora = New System.Windows.Forms.DateTimePicker()
        Me.txtObservacion = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnMinuta = New System.Windows.Forms.Button()
        Me.btnAyuda = New System.Windows.Forms.Button()
        Me.btnCtaCte = New System.Windows.Forms.Button()
        Me.btnDatosCliente = New System.Windows.Forms.Button()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
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
        Me.panel1.Size = New System.Drawing.Size(550, 40)
        Me.panel1.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(374, 10)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(155, 20)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "SURFACTAN S.A."
        '
        'label1
        '
        Me.label1.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.label1.AutoSize = True
        Me.label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.label1.ForeColor = System.Drawing.Color.White
        Me.label1.Location = New System.Drawing.Point(21, 12)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(105, 17)
        Me.label1.TabIndex = 0
        Me.label1.Text = "ALTA AGENDA"
        '
        'lblDescCliente
        '
        Me.lblDescCliente.BackColor = System.Drawing.Color.Cyan
        Me.lblDescCliente.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDescCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescCliente.Location = New System.Drawing.Point(139, 53)
        Me.lblDescCliente.Name = "lblDescCliente"
        Me.lblDescCliente.Size = New System.Drawing.Size(356, 23)
        Me.lblDescCliente.TabIndex = 6
        Me.lblDescCliente.Text = "CLIENTE"
        Me.lblDescCliente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCliente
        '
        Me.txtCliente.Location = New System.Drawing.Point(87, 54)
        Me.txtCliente.Mask = ">L00000"
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtCliente.Size = New System.Drawing.Size(46, 20)
        Me.txtCliente.TabIndex = 7
        Me.txtCliente.Text = "A99999"
        Me.txtCliente.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(29, 58)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(52, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "CLIENTE"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(39, 87)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(42, 13)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "FECHA"
        '
        'txtFecha
        '
        Me.txtFecha.Location = New System.Drawing.Point(87, 83)
        Me.txtFecha.Mask = "00/00/0000"
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtFecha.Size = New System.Drawing.Size(66, 20)
        Me.txtFecha.TabIndex = 7
        Me.txtFecha.Text = "00000000"
        Me.txtFecha.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(159, 87)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(57, 13)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "HORARIO"
        '
        'txtHora
        '
        Me.txtHora.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtHora.CustomFormat = "HH:mm"
        Me.txtHora.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.txtHora.Location = New System.Drawing.Point(222, 83)
        Me.txtHora.Name = "txtHora"
        Me.txtHora.Size = New System.Drawing.Size(52, 20)
        Me.txtHora.TabIndex = 8
        Me.txtHora.Value = New Date(2020, 8, 3, 14, 8, 0, 0)
        '
        'txtObservacion
        '
        Me.txtObservacion.Location = New System.Drawing.Point(134, 115)
        Me.txtObservacion.MaxLength = 50
        Me.txtObservacion.Name = "txtObservacion"
        Me.txtObservacion.Size = New System.Drawing.Size(361, 20)
        Me.txtObservacion.TabIndex = 9
        Me.txtObservacion.Text = "LLAMAR EL LUNES TEMPRANO"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(31, 118)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(98, 13)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "OBSERVACIONES"
        '
        'btnMinuta
        '
        Me.btnMinuta.Location = New System.Drawing.Point(97, 150)
        Me.btnMinuta.Name = "btnMinuta"
        Me.btnMinuta.Size = New System.Drawing.Size(87, 35)
        Me.btnMinuta.TabIndex = 10
        Me.btnMinuta.Text = "MINUTA"
        Me.btnMinuta.UseVisualStyleBackColor = True
        '
        'btnAyuda
        '
        Me.btnAyuda.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAyuda.Location = New System.Drawing.Point(367, 150)
        Me.btnAyuda.Name = "btnAyuda"
        Me.btnAyuda.Size = New System.Drawing.Size(87, 35)
        Me.btnAyuda.TabIndex = 10
        Me.btnAyuda.Text = "AYUDA CLIENTES"
        Me.btnAyuda.UseVisualStyleBackColor = True
        '
        'btnCtaCte
        '
        Me.btnCtaCte.Location = New System.Drawing.Point(187, 150)
        Me.btnCtaCte.Name = "btnCtaCte"
        Me.btnCtaCte.Size = New System.Drawing.Size(87, 35)
        Me.btnCtaCte.TabIndex = 10
        Me.btnCtaCte.Text = "CTA CTE"
        Me.btnCtaCte.UseVisualStyleBackColor = True
        '
        'btnDatosCliente
        '
        Me.btnDatosCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDatosCliente.Location = New System.Drawing.Point(277, 150)
        Me.btnDatosCliente.Name = "btnDatosCliente"
        Me.btnDatosCliente.Size = New System.Drawing.Size(87, 35)
        Me.btnDatosCliente.TabIndex = 10
        Me.btnDatosCliente.Text = "DATOS CLIENTE"
        Me.btnDatosCliente.UseVisualStyleBackColor = True
        '
        'btnSalir
        '
        Me.btnSalir.Location = New System.Drawing.Point(457, 150)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(87, 35)
        Me.btnSalir.TabIndex = 10
        Me.btnSalir.Text = "SALIR"
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'btnGuardar
        '
        Me.btnGuardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGuardar.Location = New System.Drawing.Point(7, 150)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(87, 35)
        Me.btnGuardar.TabIndex = 10
        Me.btnGuardar.Text = "GUARDAR"
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(260, 76)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 30)
        Me.Label3.TabIndex = 11
        '
        'AltaAgenda
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(550, 194)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.btnDatosCliente)
        Me.Controls.Add(Me.btnCtaCte)
        Me.Controls.Add(Me.btnAyuda)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.btnMinuta)
        Me.Controls.Add(Me.txtObservacion)
        Me.Controls.Add(Me.txtHora)
        Me.Controls.Add(Me.txtFecha)
        Me.Controls.Add(Me.txtCliente)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lblDescCliente)
        Me.Controls.Add(Me.panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "AltaAgenda"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.panel1.ResumeLayout(False)
        Me.panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents panel1 As System.Windows.Forms.Panel
    Private WithEvents Label2 As System.Windows.Forms.Label
    Private WithEvents label1 As System.Windows.Forms.Label
    Friend WithEvents lblDescCliente As System.Windows.Forms.Label
    Friend WithEvents txtCliente As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtFecha As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtHora As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtObservacion As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btnMinuta As System.Windows.Forms.Button
    Friend WithEvents btnAyuda As System.Windows.Forms.Button
    Friend WithEvents btnCtaCte As System.Windows.Forms.Button
    Friend WithEvents btnDatosCliente As System.Windows.Forms.Button
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
