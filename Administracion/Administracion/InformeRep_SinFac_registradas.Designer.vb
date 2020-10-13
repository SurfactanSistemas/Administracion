<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InformeRep_SinFac_registradas
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
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txt_DesdeFecha = New System.Windows.Forms.MaskedTextBox()
        Me.txt_HastaFecha = New System.Windows.Forms.MaskedTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btn_Aceptar = New System.Windows.Forms.Button()
        Me.btn_Cerrar = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.Control
        Me.Label6.Location = New System.Drawing.Point(350, 6)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(156, 26)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "SURFACTAN S.A."
        '
        'txt_DesdeFecha
        '
        Me.txt_DesdeFecha.Location = New System.Drawing.Point(139, 57)
        Me.txt_DesdeFecha.Mask = "00/00/0000"
        Me.txt_DesdeFecha.Name = "txt_DesdeFecha"
        Me.txt_DesdeFecha.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txt_DesdeFecha.Size = New System.Drawing.Size(68, 20)
        Me.txt_DesdeFecha.TabIndex = 14
        '
        'txt_HastaFecha
        '
        Me.txt_HastaFecha.Location = New System.Drawing.Point(139, 96)
        Me.txt_HastaFecha.Mask = "00/00/0000"
        Me.txt_HastaFecha.Name = "txt_HastaFecha"
        Me.txt_HastaFecha.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txt_HastaFecha.Size = New System.Drawing.Size(68, 20)
        Me.txt_HastaFecha.TabIndex = 15
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(62, 60)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(71, 13)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "Desde Fecha"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(62, 99)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(68, 13)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "Hasta Fecha"
        '
        'btn_Aceptar
        '
        Me.btn_Aceptar.Location = New System.Drawing.Point(218, 58)
        Me.btn_Aceptar.Name = "btn_Aceptar"
        Me.btn_Aceptar.Size = New System.Drawing.Size(108, 54)
        Me.btn_Aceptar.TabIndex = 18
        Me.btn_Aceptar.Text = "ACEPTAR"
        Me.btn_Aceptar.UseVisualStyleBackColor = True
        '
        'btn_Cerrar
        '
        Me.btn_Cerrar.Location = New System.Drawing.Point(342, 58)
        Me.btn_Cerrar.Name = "btn_Cerrar"
        Me.btn_Cerrar.Size = New System.Drawing.Size(108, 54)
        Me.btn_Cerrar.TabIndex = 19
        Me.btn_Cerrar.Text = "CERRAR"
        Me.btn_Cerrar.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(512, 39)
        Me.Panel2.TabIndex = 30
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.Control
        Me.Label3.Location = New System.Drawing.Point(587, 6)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(156, 26)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "SURFACTAN S.A."
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.Control
        Me.Label4.Location = New System.Drawing.Point(6, 10)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(204, 18)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "INF. RECEP. S/ FAC REGISTRADAS"
        '
        'InformeRep_SinFac_registradas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(512, 135)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.btn_Cerrar)
        Me.Controls.Add(Me.btn_Aceptar)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txt_HastaFecha)
        Me.Controls.Add(Me.txt_DesdeFecha)
        Me.Name = "InformeRep_SinFac_registradas"
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txt_DesdeFecha As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txt_HastaFecha As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btn_Aceptar As System.Windows.Forms.Button
    Friend WithEvents btn_Cerrar As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
