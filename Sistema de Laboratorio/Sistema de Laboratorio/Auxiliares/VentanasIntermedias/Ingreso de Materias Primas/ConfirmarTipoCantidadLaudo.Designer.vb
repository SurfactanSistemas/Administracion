<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ConfirmarTipoCantidadLaudo
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
        Me.btnConfirmar = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtLaudo = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtCantidad = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rbRechazado = New System.Windows.Forms.RadioButton()
        Me.rbPorDesvio = New System.Windows.Forms.RadioButton()
        Me.rbAprobado = New System.Windows.Forms.RadioButton()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(366, 49)
        Me.Panel1.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.Control
        Me.Label1.Location = New System.Drawing.Point(17, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(187, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "CONFIRMAR DATOS LAUDO"
        '
        'btnConfirmar
        '
        Me.btnConfirmar.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnConfirmar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnConfirmar.Location = New System.Drawing.Point(69, 170)
        Me.btnConfirmar.Name = "btnConfirmar"
        Me.btnConfirmar.Size = New System.Drawing.Size(111, 43)
        Me.btnConfirmar.TabIndex = 4
        Me.btnConfirmar.Text = "CONFIRMAR"
        Me.btnConfirmar.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Button2.Location = New System.Drawing.Point(186, 170)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(111, 43)
        Me.Button2.TabIndex = 4
        Me.Button2.Text = "CANCELAR"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(15, 70)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(74, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "NRO LAUDO:"
        '
        'txtLaudo
        '
        Me.txtLaudo.Location = New System.Drawing.Point(95, 67)
        Me.txtLaudo.MaxLength = 6
        Me.txtLaudo.Name = "txtLaudo"
        Me.txtLaudo.Size = New System.Drawing.Size(56, 20)
        Me.txtLaudo.TabIndex = 6
        Me.txtLaudo.Text = "999999"
        Me.txtLaudo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(157, 70)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(122, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "CANTIDAD A LAUDAR:"
        '
        'txtCantidad
        '
        Me.txtCantidad.Location = New System.Drawing.Point(285, 66)
        Me.txtCantidad.MaxLength = 6
        Me.txtCantidad.Name = "txtCantidad"
        Me.txtCantidad.Size = New System.Drawing.Size(67, 20)
        Me.txtCantidad.TabIndex = 6
        Me.txtCantidad.Text = "999999"
        Me.txtCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbRechazado)
        Me.GroupBox1.Controls.Add(Me.rbPorDesvio)
        Me.GroupBox1.Controls.Add(Me.rbAprobado)
        Me.GroupBox1.Location = New System.Drawing.Point(15, 99)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(336, 59)
        Me.GroupBox1.TabIndex = 7
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "ESTADO DEL LAUDO"
        '
        'rbRechazado
        '
        Me.rbRechazado.AutoSize = True
        Me.rbRechazado.Location = New System.Drawing.Point(222, 24)
        Me.rbRechazado.Name = "rbRechazado"
        Me.rbRechazado.Size = New System.Drawing.Size(92, 17)
        Me.rbRechazado.TabIndex = 0
        Me.rbRechazado.TabStop = True
        Me.rbRechazado.Text = "RECHAZADO"
        Me.rbRechazado.UseVisualStyleBackColor = True
        '
        'rbPorDesvio
        '
        Me.rbPorDesvio.AutoSize = True
        Me.rbPorDesvio.Location = New System.Drawing.Point(119, 24)
        Me.rbPorDesvio.Name = "rbPorDesvio"
        Me.rbPorDesvio.Size = New System.Drawing.Size(91, 17)
        Me.rbPorDesvio.TabIndex = 0
        Me.rbPorDesvio.TabStop = True
        Me.rbPorDesvio.Text = "POR DESVÍO"
        Me.rbPorDesvio.UseVisualStyleBackColor = True
        '
        'rbAprobado
        '
        Me.rbAprobado.AutoSize = True
        Me.rbAprobado.Location = New System.Drawing.Point(22, 24)
        Me.rbAprobado.Name = "rbAprobado"
        Me.rbAprobado.Size = New System.Drawing.Size(85, 17)
        Me.rbAprobado.TabIndex = 0
        Me.rbAprobado.TabStop = True
        Me.rbAprobado.Text = "APROBADO"
        Me.rbAprobado.UseVisualStyleBackColor = True
        '
        'ConfirmarTipoCantidadLaudo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(366, 219)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.txtCantidad)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtLaudo)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.btnConfirmar)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ConfirmarTipoCantidadLaudo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnConfirmar As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtLaudo As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtCantidad As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rbRechazado As System.Windows.Forms.RadioButton
    Friend WithEvents rbPorDesvio As System.Windows.Forms.RadioButton
    Friend WithEvents rbAprobado As System.Windows.Forms.RadioButton
End Class
