<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class elegir_Listado_Prov
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
        Me.label1 = New System.Windows.Forms.Label()
        Me.rabtn_Resumido = New System.Windows.Forms.RadioButton()
        Me.rabtn_Calidad = New System.Windows.Forms.RadioButton()
        Me.btn_Aceptar = New System.Windows.Forms.Button()
        Me.btn_Cancelar = New System.Windows.Forms.Button()
        Me.panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'panel1
        '
        Me.panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(34, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.panel1.Controls.Add(Me.label1)
        Me.panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.panel1.Location = New System.Drawing.Point(0, 0)
        Me.panel1.Name = "panel1"
        Me.panel1.Size = New System.Drawing.Size(264, 40)
        Me.panel1.TabIndex = 9
        '
        'label1
        '
        Me.label1.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.label1.AutoSize = True
        Me.label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold)
        Me.label1.ForeColor = System.Drawing.Color.White
        Me.label1.Location = New System.Drawing.Point(7, 13)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(186, 17)
        Me.label1.TabIndex = 0
        Me.label1.Text = "SELECCIONAR LISTADO"
        '
        'rabtn_Resumido
        '
        Me.rabtn_Resumido.AutoSize = True
        Me.rabtn_Resumido.Checked = True
        Me.rabtn_Resumido.Location = New System.Drawing.Point(55, 60)
        Me.rabtn_Resumido.Name = "rabtn_Resumido"
        Me.rabtn_Resumido.Size = New System.Drawing.Size(72, 17)
        Me.rabtn_Resumido.TabIndex = 10
        Me.rabtn_Resumido.TabStop = True
        Me.rabtn_Resumido.Text = "Resumido"
        Me.rabtn_Resumido.UseVisualStyleBackColor = True
        '
        'rabtn_Calidad
        '
        Me.rabtn_Calidad.AutoSize = True
        Me.rabtn_Calidad.Location = New System.Drawing.Point(146, 60)
        Me.rabtn_Calidad.Name = "rabtn_Calidad"
        Me.rabtn_Calidad.Size = New System.Drawing.Size(60, 17)
        Me.rabtn_Calidad.TabIndex = 11
        Me.rabtn_Calidad.Text = "Calidad"
        Me.rabtn_Calidad.UseVisualStyleBackColor = True
        '
        'btn_Aceptar
        '
        Me.btn_Aceptar.Location = New System.Drawing.Point(49, 93)
        Me.btn_Aceptar.Name = "btn_Aceptar"
        Me.btn_Aceptar.Size = New System.Drawing.Size(75, 37)
        Me.btn_Aceptar.TabIndex = 12
        Me.btn_Aceptar.Text = "ACEPTAR"
        Me.btn_Aceptar.UseVisualStyleBackColor = True
        '
        'btn_Cancelar
        '
        Me.btn_Cancelar.Location = New System.Drawing.Point(143, 93)
        Me.btn_Cancelar.Name = "btn_Cancelar"
        Me.btn_Cancelar.Size = New System.Drawing.Size(75, 37)
        Me.btn_Cancelar.TabIndex = 13
        Me.btn_Cancelar.Text = "CANCELAR"
        Me.btn_Cancelar.UseVisualStyleBackColor = True
        '
        'elegir_Listado_Prov
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(264, 144)
        Me.Controls.Add(Me.btn_Cancelar)
        Me.Controls.Add(Me.btn_Aceptar)
        Me.Controls.Add(Me.rabtn_Calidad)
        Me.Controls.Add(Me.rabtn_Resumido)
        Me.Controls.Add(Me.panel1)
        Me.Name = "elegir_Listado_Prov"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.panel1.ResumeLayout(False)
        Me.panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents panel1 As System.Windows.Forms.Panel
    Private WithEvents label1 As System.Windows.Forms.Label
    Friend WithEvents rabtn_Resumido As System.Windows.Forms.RadioButton
    Friend WithEvents rabtn_Calidad As System.Windows.Forms.RadioButton
    Friend WithEvents btn_Aceptar As System.Windows.Forms.Button
    Friend WithEvents btn_Cancelar As System.Windows.Forms.Button
End Class
