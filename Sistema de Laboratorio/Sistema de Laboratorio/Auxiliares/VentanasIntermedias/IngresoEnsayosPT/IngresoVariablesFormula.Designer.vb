<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class IngresoVariablesFormula
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dgvVariables = New Util.DBDataGridView()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtDecimales = New System.Windows.Forms.TextBox()
        Me.txtFormula = New System.Windows.Forms.TextBox()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.txtValorEstandar = New System.Windows.Forms.TextBox()
        Me.lblValorEstandar = New System.Windows.Forms.Label()
        Me.IdVariable = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Variable = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.WValor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ReferenciaARenglon = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1.SuspendLayout()
        CType(Me.dgvVariables, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(428, 49)
        Me.Panel1.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.Control
        Me.Label2.Location = New System.Drawing.Point(234, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(179, 24)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "SURFACTAN S.A."
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.Control
        Me.Label1.Location = New System.Drawing.Point(14, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(146, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "VALORES VARIABLES"
        '
        'dgvVariables
        '
        Me.dgvVariables.AllowUserToAddRows = False
        Me.dgvVariables.AllowUserToDeleteRows = False
        Me.dgvVariables.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvVariables.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IdVariable, Me.Variable, Me.WValor, Me.ReferenciaARenglon})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(232, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvVariables.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvVariables.DoubleBuffered = True
        Me.dgvVariables.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dgvVariables.Location = New System.Drawing.Point(10, 108)
        Me.dgvVariables.Name = "dgvVariables"
        Me.dgvVariables.OrdenamientoColumnasHabilitado = True
        Me.dgvVariables.RowHeadersWidth = 15
        Me.dgvVariables.RowTemplate.Height = 20
        Me.dgvVariables.ShowCellToolTips = False
        Me.dgvVariables.SinClickDerecho = False
        Me.dgvVariables.Size = New System.Drawing.Size(409, 168)
        Me.dgvVariables.TabIndex = 5
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.txtFormula)
        Me.GroupBox1.Location = New System.Drawing.Point(10, 51)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(409, 54)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "FÓRMULA"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtDecimales)
        Me.GroupBox2.Font = New System.Drawing.Font("MS UI Gothic", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(341, 8)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(62, 42)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Decimales"
        '
        'txtDecimales
        '
        Me.txtDecimales.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDecimales.Location = New System.Drawing.Point(15, 14)
        Me.txtDecimales.MaxLength = 2
        Me.txtDecimales.Name = "txtDecimales"
        Me.txtDecimales.Size = New System.Drawing.Size(33, 20)
        Me.txtDecimales.TabIndex = 0
        Me.txtDecimales.Text = "2"
        Me.txtDecimales.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtFormula
        '
        Me.txtFormula.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFormula.Location = New System.Drawing.Point(11, 21)
        Me.txtFormula.Name = "txtFormula"
        Me.txtFormula.ReadOnly = True
        Me.txtFormula.Size = New System.Drawing.Size(324, 20)
        Me.txtFormula.TabIndex = 0
        Me.txtFormula.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnAceptar
        '
        Me.btnAceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.Location = New System.Drawing.Point(87, 308)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(119, 33)
        Me.btnAceptar.TabIndex = 7
        Me.btnAceptar.Text = "ACEPTAR"
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(222, 308)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(119, 33)
        Me.btnCancelar.TabIndex = 7
        Me.btnCancelar.Text = "CANCELAR"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'txtValorEstandar
        '
        Me.txtValorEstandar.Location = New System.Drawing.Point(201, 282)
        Me.txtValorEstandar.Name = "txtValorEstandar"
        Me.txtValorEstandar.Size = New System.Drawing.Size(100, 20)
        Me.txtValorEstandar.TabIndex = 8
        Me.txtValorEstandar.Visible = False
        '
        'lblValorEstandar
        '
        Me.lblValorEstandar.AutoSize = True
        Me.lblValorEstandar.Location = New System.Drawing.Point(119, 285)
        Me.lblValorEstandar.Name = "lblValorEstandar"
        Me.lblValorEstandar.Size = New System.Drawing.Size(76, 13)
        Me.lblValorEstandar.TabIndex = 9
        Me.lblValorEstandar.Text = "Valor Estandar"
        Me.lblValorEstandar.Visible = False
        '
        'IdVariable
        '
        Me.IdVariable.HeaderText = "ID"
        Me.IdVariable.MinimumWidth = 40
        Me.IdVariable.Name = "IdVariable"
        Me.IdVariable.ReadOnly = True
        Me.IdVariable.Width = 40
        '
        'Variable
        '
        Me.Variable.HeaderText = "Variable"
        Me.Variable.MinimumWidth = 200
        Me.Variable.Name = "Variable"
        Me.Variable.ReadOnly = True
        Me.Variable.Width = 200
        '
        'WValor
        '
        Me.WValor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.WValor.DefaultCellStyle = DataGridViewCellStyle1
        Me.WValor.HeaderText = "Valor"
        Me.WValor.Name = "WValor"
        Me.WValor.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'ReferenciaARenglon
        '
        Me.ReferenciaARenglon.HeaderText = "ReferenciaARenglon"
        Me.ReferenciaARenglon.Name = "ReferenciaARenglon"
        Me.ReferenciaARenglon.Visible = False
        '
        'IngresoVariablesFormula
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(428, 350)
        Me.Controls.Add(Me.lblValorEstandar)
        Me.Controls.Add(Me.txtValorEstandar)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.dgvVariables)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "IngresoVariablesFormula"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dgvVariables, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dgvVariables As Util.DBDataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents txtFormula As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtDecimales As System.Windows.Forms.TextBox
    Friend WithEvents txtValorEstandar As System.Windows.Forms.TextBox
    Friend WithEvents lblValorEstandar As System.Windows.Forms.Label
    Friend WithEvents IdVariable As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Variable As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WValor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReferenciaARenglon As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
