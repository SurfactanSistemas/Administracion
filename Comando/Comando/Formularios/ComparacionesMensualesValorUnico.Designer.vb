<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ComparacionesMensualesValorUnico
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
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.ckVarios = New System.Windows.Forms.CheckBox()
        Me.ckFazonQuimicos = New System.Windows.Forms.CheckBox()
        Me.ckFazonFarma = New System.Windows.Forms.CheckBox()
        Me.ckFazonPellital = New System.Windows.Forms.CheckBox()
        Me.ckFarma = New System.Windows.Forms.CheckBox()
        Me.ckColorantes = New System.Windows.Forms.CheckBox()
        Me.ckQuimicos = New System.Windows.Forms.CheckBox()
        Me.ckTodas = New System.Windows.Forms.CheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbValorAComparar = New System.Windows.Forms.ComboBox()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnGenerar
        '
        Me.btnGenerar.Location = New System.Drawing.Point(572, 426)
        Me.btnGenerar.Name = "btnGenerar"
        Me.btnGenerar.Size = New System.Drawing.Size(153, 38)
        Me.btnGenerar.TabIndex = 0
        Me.btnGenerar.Text = "Generar Informe"
        Me.btnGenerar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(29, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(93, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Tipo Comparacion"
        '
        'cmbTipoComparacion
        '
        Me.cmbTipoComparacion.FormattingEnabled = True
        Me.cmbTipoComparacion.Items.AddRange(New Object() {"", "Mensual por Familia", "Mensual entre Familias", "Bimestral", "Trimestral"})
        Me.cmbTipoComparacion.Location = New System.Drawing.Point(129, 15)
        Me.cmbTipoComparacion.Name = "cmbTipoComparacion"
        Me.cmbTipoComparacion.Size = New System.Drawing.Size(142, 21)
        Me.cmbTipoComparacion.TabIndex = 2
        '
        'cmbTipoGrafico
        '
        Me.cmbTipoGrafico.FormattingEnabled = True
        Me.cmbTipoGrafico.Items.AddRange(New Object() {"", "Barras", "Pasteles", "Lineas", "Barras 3D"})
        Me.cmbTipoGrafico.Location = New System.Drawing.Point(381, 15)
        Me.cmbTipoGrafico.Name = "cmbTipoGrafico"
        Me.cmbTipoGrafico.Size = New System.Drawing.Size(142, 21)
        Me.cmbTipoGrafico.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(312, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Tipo Gráfico"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.PictureBox1)
        Me.GroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBox1.Location = New System.Drawing.Point(27, 170)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(548, 230)
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
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.ckVarios)
        Me.GroupBox2.Controls.Add(Me.ckFazonQuimicos)
        Me.GroupBox2.Controls.Add(Me.ckFazonFarma)
        Me.GroupBox2.Controls.Add(Me.ckFazonPellital)
        Me.GroupBox2.Controls.Add(Me.ckFarma)
        Me.GroupBox2.Controls.Add(Me.ckColorantes)
        Me.GroupBox2.Controls.Add(Me.ckQuimicos)
        Me.GroupBox2.Controls.Add(Me.ckTodas)
        Me.GroupBox2.Location = New System.Drawing.Point(586, 170)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(139, 230)
        Me.GroupBox2.TabIndex = 4
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Familias a Comparar"
        '
        'ckVarios
        '
        Me.ckVarios.AutoSize = True
        Me.ckVarios.Location = New System.Drawing.Point(19, 187)
        Me.ckVarios.Name = "ckVarios"
        Me.ckVarios.Size = New System.Drawing.Size(55, 17)
        Me.ckVarios.TabIndex = 0
        Me.ckVarios.Text = "Varios"
        Me.ckVarios.UseVisualStyleBackColor = True
        '
        'ckFazonQuimicos
        '
        Me.ckFazonQuimicos.AutoSize = True
        Me.ckFazonQuimicos.Location = New System.Drawing.Point(19, 164)
        Me.ckFazonQuimicos.Name = "ckFazonQuimicos"
        Me.ckFazonQuimicos.Size = New System.Drawing.Size(103, 17)
        Me.ckFazonQuimicos.TabIndex = 0
        Me.ckFazonQuimicos.Text = "Fazón Químicos"
        Me.ckFazonQuimicos.UseVisualStyleBackColor = True
        '
        'ckFazonFarma
        '
        Me.ckFazonFarma.AutoSize = True
        Me.ckFazonFarma.Location = New System.Drawing.Point(19, 141)
        Me.ckFazonFarma.Name = "ckFazonFarma"
        Me.ckFazonFarma.Size = New System.Drawing.Size(87, 17)
        Me.ckFazonFarma.TabIndex = 0
        Me.ckFazonFarma.Text = "Fazón Farma"
        Me.ckFazonFarma.UseVisualStyleBackColor = True
        '
        'ckFazonPellital
        '
        Me.ckFazonPellital.AutoSize = True
        Me.ckFazonPellital.Location = New System.Drawing.Point(19, 118)
        Me.ckFazonPellital.Name = "ckFazonPellital"
        Me.ckFazonPellital.Size = New System.Drawing.Size(88, 17)
        Me.ckFazonPellital.TabIndex = 0
        Me.ckFazonPellital.Text = "Fazon Pellital"
        Me.ckFazonPellital.UseVisualStyleBackColor = True
        '
        'ckFarma
        '
        Me.ckFarma.AutoSize = True
        Me.ckFarma.Location = New System.Drawing.Point(19, 95)
        Me.ckFarma.Name = "ckFarma"
        Me.ckFarma.Size = New System.Drawing.Size(55, 17)
        Me.ckFarma.TabIndex = 0
        Me.ckFarma.Text = "Farma"
        Me.ckFarma.UseVisualStyleBackColor = True
        '
        'ckColorantes
        '
        Me.ckColorantes.AutoSize = True
        Me.ckColorantes.Location = New System.Drawing.Point(19, 72)
        Me.ckColorantes.Name = "ckColorantes"
        Me.ckColorantes.Size = New System.Drawing.Size(76, 17)
        Me.ckColorantes.TabIndex = 0
        Me.ckColorantes.Text = "Colorantes"
        Me.ckColorantes.UseVisualStyleBackColor = True
        '
        'ckQuimicos
        '
        Me.ckQuimicos.AutoSize = True
        Me.ckQuimicos.Location = New System.Drawing.Point(19, 49)
        Me.ckQuimicos.Name = "ckQuimicos"
        Me.ckQuimicos.Size = New System.Drawing.Size(71, 17)
        Me.ckQuimicos.TabIndex = 0
        Me.ckQuimicos.Text = "Químicos"
        Me.ckQuimicos.UseVisualStyleBackColor = True
        '
        'ckTodas
        '
        Me.ckTodas.AutoSize = True
        Me.ckTodas.Location = New System.Drawing.Point(19, 26)
        Me.ckTodas.Name = "ckTodas"
        Me.ckTodas.Size = New System.Drawing.Size(56, 17)
        Me.ckTodas.TabIndex = 0
        Me.ckTodas.Text = "Todas"
        Me.ckTodas.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(34, 47)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(88, 13)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Valor a Comparar"
        '
        'cmbValorAComparar
        '
        Me.cmbValorAComparar.FormattingEnabled = True
        Me.cmbValorAComparar.Items.AddRange(New Object() {"", "Venta (U$S)", "Kilos", "Factor", "Precio Promedio", "Stock", "Rotacion", "Porcentaje", "Pedidos", "Atrasados", "% Atrasos"})
        Me.cmbValorAComparar.Location = New System.Drawing.Point(129, 43)
        Me.cmbValorAComparar.Name = "cmbValorAComparar"
        Me.cmbValorAComparar.Size = New System.Drawing.Size(142, 21)
        Me.cmbValorAComparar.TabIndex = 2
        '
        'ComparacionesMensualesValorUnico
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1066, 476)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cmbValorAComparar)
        Me.Controls.Add(Me.cmbTipoGrafico)
        Me.Controls.Add(Me.cmbTipoComparacion)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnGenerar)
        Me.Name = "ComparacionesMensualesValorUnico"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ComparacionesMensuales"
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
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
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents ckVarios As System.Windows.Forms.CheckBox
    Friend WithEvents ckFazonQuimicos As System.Windows.Forms.CheckBox
    Friend WithEvents ckFazonFarma As System.Windows.Forms.CheckBox
    Friend WithEvents ckFazonPellital As System.Windows.Forms.CheckBox
    Friend WithEvents ckFarma As System.Windows.Forms.CheckBox
    Friend WithEvents ckColorantes As System.Windows.Forms.CheckBox
    Friend WithEvents ckQuimicos As System.Windows.Forms.CheckBox
    Friend WithEvents ckTodas As System.Windows.Forms.CheckBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbValorAComparar As System.Windows.Forms.ComboBox
End Class
