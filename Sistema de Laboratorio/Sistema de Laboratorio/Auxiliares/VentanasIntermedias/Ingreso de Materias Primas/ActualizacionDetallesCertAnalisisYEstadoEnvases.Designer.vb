<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ActualizacionDetallesCertAnalisisYEstadoEnvases
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rbNoCertificadoAnalisis = New System.Windows.Forms.RadioButton()
        Me.rbSiCertificadoAnalisis = New System.Windows.Forms.RadioButton()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.rbNoEstadoEnvases = New System.Windows.Forms.RadioButton()
        Me.rbSiEstadoEnvases = New System.Windows.Forms.RadioButton()
        Me.txtCertificado2 = New System.Windows.Forms.TextBox()
        Me.txtEstado2 = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtFechaVencimiento = New System.Windows.Forms.MaskedTextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmbTipoVencimiento = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtFechaElaboracion = New System.Windows.Forms.MaskedTextBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(581, 49)
        Me.Panel1.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.Control
        Me.Label1.Location = New System.Drawing.Point(6, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(569, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "ACTUALIZACIÓN DE DETALLES DE CERTIFICADO DE ANÁLISIS Y ESTADO DE ENVASES"
        '
        'Button1
        '
        Me.Button1.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(159, 204)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(128, 37)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = "CONFIRMAR"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 66)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(175, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "¿CUENTA CON CERT. ANÁLISIS?"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbNoCertificadoAnalisis)
        Me.GroupBox1.Controls.Add(Me.rbSiCertificadoAnalisis)
        Me.GroupBox1.Location = New System.Drawing.Point(240, 54)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(118, 33)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        '
        'rbNoCertificadoAnalisis
        '
        Me.rbNoCertificadoAnalisis.AutoSize = True
        Me.rbNoCertificadoAnalisis.Checked = True
        Me.rbNoCertificadoAnalisis.Location = New System.Drawing.Point(67, 10)
        Me.rbNoCertificadoAnalisis.Name = "rbNoCertificadoAnalisis"
        Me.rbNoCertificadoAnalisis.Size = New System.Drawing.Size(41, 17)
        Me.rbNoCertificadoAnalisis.TabIndex = 1
        Me.rbNoCertificadoAnalisis.TabStop = True
        Me.rbNoCertificadoAnalisis.Text = "NO"
        Me.rbNoCertificadoAnalisis.UseVisualStyleBackColor = True
        '
        'rbSiCertificadoAnalisis
        '
        Me.rbSiCertificadoAnalisis.AutoSize = True
        Me.rbSiCertificadoAnalisis.Location = New System.Drawing.Point(16, 10)
        Me.rbSiCertificadoAnalisis.Name = "rbSiCertificadoAnalisis"
        Me.rbSiCertificadoAnalisis.Size = New System.Drawing.Size(35, 17)
        Me.rbSiCertificadoAnalisis.TabIndex = 0
        Me.rbSiCertificadoAnalisis.Text = "SI"
        Me.rbSiCertificadoAnalisis.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 98)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(221, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "¿CORRECTO ESTADO DE LOS ENVASES?"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.rbNoEstadoEnvases)
        Me.GroupBox2.Controls.Add(Me.rbSiEstadoEnvases)
        Me.GroupBox2.Location = New System.Drawing.Point(240, 86)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(118, 33)
        Me.GroupBox2.TabIndex = 6
        Me.GroupBox2.TabStop = False
        '
        'rbNoEstadoEnvases
        '
        Me.rbNoEstadoEnvases.AutoSize = True
        Me.rbNoEstadoEnvases.Checked = True
        Me.rbNoEstadoEnvases.Location = New System.Drawing.Point(67, 10)
        Me.rbNoEstadoEnvases.Name = "rbNoEstadoEnvases"
        Me.rbNoEstadoEnvases.Size = New System.Drawing.Size(41, 17)
        Me.rbNoEstadoEnvases.TabIndex = 1
        Me.rbNoEstadoEnvases.TabStop = True
        Me.rbNoEstadoEnvases.Text = "NO"
        Me.rbNoEstadoEnvases.UseVisualStyleBackColor = True
        '
        'rbSiEstadoEnvases
        '
        Me.rbSiEstadoEnvases.AutoSize = True
        Me.rbSiEstadoEnvases.Location = New System.Drawing.Point(16, 10)
        Me.rbSiEstadoEnvases.Name = "rbSiEstadoEnvases"
        Me.rbSiEstadoEnvases.Size = New System.Drawing.Size(35, 17)
        Me.rbSiEstadoEnvases.TabIndex = 0
        Me.rbSiEstadoEnvases.Text = "SI"
        Me.rbSiEstadoEnvases.UseVisualStyleBackColor = True
        '
        'txtCertificado2
        '
        Me.txtCertificado2.Location = New System.Drawing.Point(368, 61)
        Me.txtCertificado2.Name = "txtCertificado2"
        Me.txtCertificado2.Size = New System.Drawing.Size(188, 20)
        Me.txtCertificado2.TabIndex = 7
        '
        'txtEstado2
        '
        Me.txtEstado2.Location = New System.Drawing.Point(368, 95)
        Me.txtEstado2.Name = "txtEstado2"
        Me.txtEstado2.Size = New System.Drawing.Size(188, 20)
        Me.txtEstado2.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(13, 137)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(140, 13)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "FECHA DE VENCIMIENTO:"
        '
        'txtFechaVencimiento
        '
        Me.txtFechaVencimiento.Location = New System.Drawing.Point(168, 133)
        Me.txtFechaVencimiento.Mask = "00/00/0000"
        Me.txtFechaVencimiento.Name = "txtFechaVencimiento"
        Me.txtFechaVencimiento.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtFechaVencimiento.Size = New System.Drawing.Size(66, 20)
        Me.txtFechaVencimiento.TabIndex = 8
        Me.txtFechaVencimiento.Text = "99999999"
        Me.txtFechaVencimiento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(253, 137)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(109, 13)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "TIPO VENCIMIENTO"
        '
        'cmbTipoVencimiento
        '
        Me.cmbTipoVencimiento.FormattingEnabled = True
        Me.cmbTipoVencimiento.Items.AddRange(New Object() {"VENCIMIENTO", "REANÁLISIS"})
        Me.cmbTipoVencimiento.Location = New System.Drawing.Point(368, 133)
        Me.cmbTipoVencimiento.Name = "cmbTipoVencimiento"
        Me.cmbTipoVencimiento.Size = New System.Drawing.Size(188, 21)
        Me.cmbTipoVencimiento.TabIndex = 9
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(13, 173)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(142, 13)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "FECHA DE ELABORACIÓN:"
        '
        'txtFechaElaboracion
        '
        Me.txtFechaElaboracion.Location = New System.Drawing.Point(168, 169)
        Me.txtFechaElaboracion.Mask = "00/00/0000"
        Me.txtFechaElaboracion.Name = "txtFechaElaboracion"
        Me.txtFechaElaboracion.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtFechaElaboracion.Size = New System.Drawing.Size(66, 20)
        Me.txtFechaElaboracion.TabIndex = 8
        Me.txtFechaElaboracion.Text = "99999999"
        Me.txtFechaElaboracion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Button2
        '
        Me.Button2.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Button2.Location = New System.Drawing.Point(293, 204)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(128, 37)
        Me.Button2.TabIndex = 4
        Me.Button2.Text = "CANCELAR"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'ActualizacionDetallesCertAnalisisYEstadoEnvases
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(581, 250)
        Me.Controls.Add(Me.cmbTipoVencimiento)
        Me.Controls.Add(Me.txtFechaElaboracion)
        Me.Controls.Add(Me.txtFechaVencimiento)
        Me.Controls.Add(Me.txtEstado2)
        Me.Controls.Add(Me.txtCertificado2)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ActualizacionDetallesCertAnalisisYEstadoEnvases"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rbNoCertificadoAnalisis As System.Windows.Forms.RadioButton
    Friend WithEvents rbSiCertificadoAnalisis As System.Windows.Forms.RadioButton
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents rbNoEstadoEnvases As System.Windows.Forms.RadioButton
    Friend WithEvents rbSiEstadoEnvases As System.Windows.Forms.RadioButton
    Friend WithEvents txtCertificado2 As System.Windows.Forms.TextBox
    Friend WithEvents txtEstado2 As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtFechaVencimiento As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmbTipoVencimiento As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtFechaElaboracion As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
End Class
