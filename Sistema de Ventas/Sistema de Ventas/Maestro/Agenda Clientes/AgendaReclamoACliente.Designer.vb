<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AgendaReclamoACliente
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
        Me.lblRazon = New System.Windows.Forms.Label()
        Me.txtObservacion = New System.Windows.Forms.TextBox()
        Me.btnAceptar = New System.Windows.Forms.Button()
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
        Me.panel1.Name = "panel1"
        Me.panel1.Size = New System.Drawing.Size(536, 40)
        Me.panel1.TabIndex = 39
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(360, 10)
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
        Me.label1.Size = New System.Drawing.Size(149, 17)
        Me.label1.TabIndex = 0
        Me.label1.Text = "RECLAMO A CLIENTE"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblRazon)
        Me.GroupBox1.Location = New System.Drawing.Point(7, 43)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(519, 52)
        Me.GroupBox1.TabIndex = 40
        Me.GroupBox1.TabStop = False
        '
        'lblRazon
        '
        Me.lblRazon.BackColor = System.Drawing.Color.Cyan
        Me.lblRazon.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblRazon.Location = New System.Drawing.Point(9, 17)
        Me.lblRazon.Name = "lblRazon"
        Me.lblRazon.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.lblRazon.Size = New System.Drawing.Size(499, 25)
        Me.lblRazon.TabIndex = 0
        Me.lblRazon.Text = "Label3"
        Me.lblRazon.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtObservacion
        '
        Me.txtObservacion.Location = New System.Drawing.Point(7, 104)
        Me.txtObservacion.Multiline = True
        Me.txtObservacion.Name = "txtObservacion"
        Me.txtObservacion.Size = New System.Drawing.Size(519, 171)
        Me.txtObservacion.TabIndex = 41
        '
        'btnAceptar
        '
        Me.btnAceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.Location = New System.Drawing.Point(202, 281)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(139, 36)
        Me.btnAceptar.TabIndex = 42
        Me.btnAceptar.Text = "ACEPTAR"
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'AgendaReclamoACliente
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(536, 321)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.txtObservacion)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "AgendaReclamoACliente"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.panel1.ResumeLayout(False)
        Me.panel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents panel1 As System.Windows.Forms.Panel
    Private WithEvents Label2 As System.Windows.Forms.Label
    Private WithEvents label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblRazon As System.Windows.Forms.Label
    Friend WithEvents txtObservacion As System.Windows.Forms.TextBox
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
End Class
