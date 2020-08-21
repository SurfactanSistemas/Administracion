<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Reclamos_CtaCteClientes
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
        Me.txt_Reclamos = New System.Windows.Forms.TextBox()
        Me.btn_Aceptar = New System.Windows.Forms.Button()
        Me.txt_Cliente = New System.Windows.Forms.TextBox()
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
        Me.panel1.Size = New System.Drawing.Size(376, 50)
        Me.panel1.TabIndex = 39
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(221, 30)
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
        Me.label1.Size = New System.Drawing.Size(78, 17)
        Me.label1.TabIndex = 0
        Me.label1.Text = "Reclamos"
        '
        'txt_Reclamos
        '
        Me.txt_Reclamos.Location = New System.Drawing.Point(6, 86)
        Me.txt_Reclamos.Multiline = True
        Me.txt_Reclamos.Name = "txt_Reclamos"
        Me.txt_Reclamos.Size = New System.Drawing.Size(358, 256)
        Me.txt_Reclamos.TabIndex = 40
        '
        'btn_Aceptar
        '
        Me.btn_Aceptar.Location = New System.Drawing.Point(139, 348)
        Me.btn_Aceptar.Name = "btn_Aceptar"
        Me.btn_Aceptar.Size = New System.Drawing.Size(89, 33)
        Me.btn_Aceptar.TabIndex = 41
        Me.btn_Aceptar.Text = "ACEPTAR"
        Me.btn_Aceptar.UseVisualStyleBackColor = True
        '
        'txt_Cliente
        '
        Me.txt_Cliente.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txt_Cliente.Location = New System.Drawing.Point(6, 60)
        Me.txt_Cliente.Name = "txt_Cliente"
        Me.txt_Cliente.Size = New System.Drawing.Size(264, 20)
        Me.txt_Cliente.TabIndex = 42
        '
        'Reclamos_CtaCteClientes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(376, 383)
        Me.Controls.Add(Me.txt_Cliente)
        Me.Controls.Add(Me.btn_Aceptar)
        Me.Controls.Add(Me.txt_Reclamos)
        Me.Controls.Add(Me.panel1)
        Me.Name = "Reclamos_CtaCteClientes"
        Me.panel1.ResumeLayout(False)
        Me.panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents panel1 As System.Windows.Forms.Panel
    Private WithEvents Label2 As System.Windows.Forms.Label
    Private WithEvents label1 As System.Windows.Forms.Label
    Friend WithEvents txt_Reclamos As System.Windows.Forms.TextBox
    Friend WithEvents btn_Aceptar As System.Windows.Forms.Button
    Friend WithEvents txt_Cliente As System.Windows.Forms.TextBox
End Class
