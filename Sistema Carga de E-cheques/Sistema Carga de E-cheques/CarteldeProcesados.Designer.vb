<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CarteldeProcesados
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
        Me.lbl_Cargados = New System.Windows.Forms.Label()
        Me.lbl_NoCargados = New System.Windows.Forms.Label()
        Me.lbl_Total = New System.Windows.Forms.Label()
        Me.btn_Aceptar = New System.Windows.Forms.Button()
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
        Me.panel1.Size = New System.Drawing.Size(490, 49)
        Me.panel1.TabIndex = 7
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(256, 12)
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
        Me.label1.Size = New System.Drawing.Size(103, 20)
        Me.label1.TabIndex = 0
        Me.label1.Text = "Resultados"
        '
        'lbl_Cargados
        '
        Me.lbl_Cargados.AutoSize = True
        Me.lbl_Cargados.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Cargados.ForeColor = System.Drawing.Color.Green
        Me.lbl_Cargados.Location = New System.Drawing.Point(27, 75)
        Me.lbl_Cargados.Name = "lbl_Cargados"
        Me.lbl_Cargados.Size = New System.Drawing.Size(206, 25)
        Me.lbl_Cargados.TabIndex = 8
        Me.lbl_Cargados.Text = "Cantidad Grabados:"
        '
        'lbl_NoCargados
        '
        Me.lbl_NoCargados.AutoSize = True
        Me.lbl_NoCargados.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_NoCargados.ForeColor = System.Drawing.Color.Red
        Me.lbl_NoCargados.Location = New System.Drawing.Point(27, 123)
        Me.lbl_NoCargados.Name = "lbl_NoCargados"
        Me.lbl_NoCargados.Size = New System.Drawing.Size(244, 25)
        Me.lbl_NoCargados.TabIndex = 9
        Me.lbl_NoCargados.Text = "Cantidad NO Grabados:"
        '
        'lbl_Total
        '
        Me.lbl_Total.AutoSize = True
        Me.lbl_Total.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Total.Location = New System.Drawing.Point(27, 171)
        Me.lbl_Total.Name = "lbl_Total"
        Me.lbl_Total.Size = New System.Drawing.Size(161, 25)
        Me.lbl_Total.TabIndex = 10
        Me.lbl_Total.Text = "Cantidad Total:"
        '
        'btn_Aceptar
        '
        Me.btn_Aceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Aceptar.Location = New System.Drawing.Point(191, 226)
        Me.btn_Aceptar.Name = "btn_Aceptar"
        Me.btn_Aceptar.Size = New System.Drawing.Size(124, 53)
        Me.btn_Aceptar.TabIndex = 11
        Me.btn_Aceptar.Text = "ACEPTAR"
        Me.btn_Aceptar.UseVisualStyleBackColor = True
        '
        'CarteldeProcesados
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(490, 307)
        Me.Controls.Add(Me.btn_Aceptar)
        Me.Controls.Add(Me.lbl_Total)
        Me.Controls.Add(Me.lbl_NoCargados)
        Me.Controls.Add(Me.lbl_Cargados)
        Me.Controls.Add(Me.panel1)
        Me.Name = "CarteldeProcesados"
        Me.panel1.ResumeLayout(False)
        Me.panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents panel1 As System.Windows.Forms.Panel
    Private WithEvents Label2 As System.Windows.Forms.Label
    Private WithEvents label1 As System.Windows.Forms.Label
    Friend WithEvents lbl_Cargados As System.Windows.Forms.Label
    Friend WithEvents lbl_NoCargados As System.Windows.Forms.Label
    Friend WithEvents lbl_Total As System.Windows.Forms.Label
    Friend WithEvents btn_Aceptar As System.Windows.Forms.Button
End Class
