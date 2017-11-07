<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ComparacionEntreFamiliasPeriodos
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.cmbPeriodoComparacion = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbTipoComparacion = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbValoresUnicos = New System.Windows.Forms.ComboBox()
        Me.cmbCompararValores = New System.Windows.Forms.ComboBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'cmbPeriodoComparacion
        '
        Me.cmbPeriodoComparacion.FormattingEnabled = True
        Me.cmbPeriodoComparacion.Items.AddRange(New Object() {"", "Por Mes", "Por Bimestre", "Por Trimestre", "Por Semestre"})
        Me.cmbPeriodoComparacion.Location = New System.Drawing.Point(163, 33)
        Me.cmbPeriodoComparacion.Name = "cmbPeriodoComparacion"
        Me.cmbPeriodoComparacion.Size = New System.Drawing.Size(152, 21)
        Me.cmbPeriodoComparacion.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 36)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(150, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Tipo Periodo de Comparación:"
        '
        'cmbTipoComparacion
        '
        Me.cmbTipoComparacion.FormattingEnabled = True
        Me.cmbTipoComparacion.Items.AddRange(New Object() {"", "Valor único", "Entre Valores"})
        Me.cmbTipoComparacion.Location = New System.Drawing.Point(163, 67)
        Me.cmbTipoComparacion.Name = "cmbTipoComparacion"
        Me.cmbTipoComparacion.Size = New System.Drawing.Size(152, 21)
        Me.cmbTipoComparacion.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 71)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(111, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Tipo de Comparación:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(331, 71)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(111, 13)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Campo(s) a Comparar:"
        '
        'cmbValoresUnicos
        '
        Me.cmbValoresUnicos.FormattingEnabled = True
        Me.cmbValoresUnicos.Items.AddRange(New Object() {"", "Ventas (u$s)", "Kilos Vendidos", "Factor (Ventas / Costos)", "Precio Promedio", "Stock", "Rotacion", "Porcentaje ( % Venta periodo - Promedio Ventas Gral.)", "Pedidos", "Atrasos", "% Atrasos"})
        Me.cmbValoresUnicos.Location = New System.Drawing.Point(448, 67)
        Me.cmbValoresUnicos.Name = "cmbValoresUnicos"
        Me.cmbValoresUnicos.Size = New System.Drawing.Size(152, 21)
        Me.cmbValoresUnicos.TabIndex = 0
        '
        'cmbCompararValores
        '
        Me.cmbCompararValores.FormattingEnabled = True
        Me.cmbCompararValores.Items.AddRange(New Object() {"", "Comparación N° Pedidos / N° Atrasos.", "Progresión de Atrasos.", "Progresión de Pedidos / Atrasos.", "Progresión de Ventas Periodicas / Ventas Promedio."})
        Me.cmbCompararValores.Location = New System.Drawing.Point(448, 67)
        Me.cmbCompararValores.Name = "cmbCompararValores"
        Me.cmbCompararValores.Size = New System.Drawing.Size(152, 21)
        Me.cmbCompararValores.TabIndex = 0
        Me.cmbCompararValores.Visible = False
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(163, 121)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(193, 32)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "Generar Reporte"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'ComparacionEntreFamiliasPeriodos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(779, 427)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmbCompararValores)
        Me.Controls.Add(Me.cmbValoresUnicos)
        Me.Controls.Add(Me.cmbTipoComparacion)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmbPeriodoComparacion)
        Me.Name = "ComparacionEntreFamiliasPeriodos"
        Me.Text = "ComparacionEntreFamiliasPeriodos"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmbPeriodoComparacion As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbTipoComparacion As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbValoresUnicos As System.Windows.Forms.ComboBox
    Friend WithEvents cmbCompararValores As System.Windows.Forms.ComboBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
