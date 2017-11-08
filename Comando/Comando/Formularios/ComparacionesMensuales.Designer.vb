<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ComparacionesMensuales
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
        Me.btnGenerar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbTipoComparacion = New System.Windows.Forms.ComboBox()
        Me.cmbTipoGrafico = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnGenerar
        '
        Me.btnGenerar.Location = New System.Drawing.Point(431, 318)
        Me.btnGenerar.Name = "btnGenerar"
        Me.btnGenerar.Size = New System.Drawing.Size(153, 38)
        Me.btnGenerar.TabIndex = 0
        Me.btnGenerar.Text = "Generar Informe"
        Me.btnGenerar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(24, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(93, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Tipo Comparacion"
        '
        'cmbTipoComparacion
        '
        Me.cmbTipoComparacion.FormattingEnabled = True
        Me.cmbTipoComparacion.Items.AddRange(New Object() {"", "Trimestral"})
        Me.cmbTipoComparacion.Location = New System.Drawing.Point(129, 17)
        Me.cmbTipoComparacion.Name = "cmbTipoComparacion"
        Me.cmbTipoComparacion.Size = New System.Drawing.Size(142, 21)
        Me.cmbTipoComparacion.TabIndex = 2
        '
        'cmbTipoGrafico
        '
        Me.cmbTipoGrafico.FormattingEnabled = True
        Me.cmbTipoGrafico.Items.AddRange(New Object() {"", "Barras", "Pastel"})
        Me.cmbTipoGrafico.Location = New System.Drawing.Point(411, 17)
        Me.cmbTipoGrafico.Name = "cmbTipoGrafico"
        Me.cmbTipoGrafico.Size = New System.Drawing.Size(142, 21)
        Me.cmbTipoGrafico.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(334, 21)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Tipo Gráfico"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.PictureBox1)
        Me.GroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBox1.Location = New System.Drawing.Point(35, 69)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(548, 232)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Vista Previa (Sólo a modo Ilustrativo)"
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(55, 22)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(438, 198)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'ComparacionesMensuales
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(610, 368)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cmbTipoGrafico)
        Me.Controls.Add(Me.cmbTipoComparacion)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnGenerar)
        Me.Name = "ComparacionesMensuales"
        Me.Text = "ComparacionesMensuales"
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnGenerar As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbTipoComparacion As System.Windows.Forms.ComboBox
    Friend WithEvents cmbTipoGrafico As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
End Class
