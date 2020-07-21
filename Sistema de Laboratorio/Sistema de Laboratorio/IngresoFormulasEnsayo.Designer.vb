<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class IngresoFormulasEnsayo
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.DGV_Formulas = New Util.DBDataGridView()
        Me.txtBuscador = New System.Windows.Forms.TextBox()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.btnVolver = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Renglon = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Formula = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AnalistaLab = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Analista = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CheckVerificado = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        CType(Me.DGV_Formulas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'DGV_Formulas
        '
        Me.DGV_Formulas.AllowUserToAddRows = False
        Me.DGV_Formulas.AllowUserToDeleteRows = False
        Me.DGV_Formulas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_Formulas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Renglon, Me.Descripcion, Me.Formula, Me.AnalistaLab, Me.Analista, Me.CheckVerificado})
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(232, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGV_Formulas.DefaultCellStyle = DataGridViewCellStyle1
        Me.DGV_Formulas.DoubleBuffered = True
        Me.DGV_Formulas.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.DGV_Formulas.Location = New System.Drawing.Point(3, 147)
        Me.DGV_Formulas.Name = "DGV_Formulas"
        Me.DGV_Formulas.OrdenamientoColumnasHabilitado = True
        Me.DGV_Formulas.RowHeadersWidth = 15
        Me.DGV_Formulas.RowTemplate.Height = 20
        Me.DGV_Formulas.ShowCellToolTips = False
        Me.DGV_Formulas.SinClickDerecho = False
        Me.DGV_Formulas.Size = New System.Drawing.Size(583, 202)
        Me.DGV_Formulas.TabIndex = 0
        '
        'txtBuscador
        '
        Me.txtBuscador.Location = New System.Drawing.Point(4, 121)
        Me.txtBuscador.Name = "txtBuscador"
        Me.txtBuscador.Size = New System.Drawing.Size(582, 20)
        Me.txtBuscador.TabIndex = 1
        '
        'btnAgregar
        '
        Me.btnAgregar.Location = New System.Drawing.Point(4, 77)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(75, 37)
        Me.btnAgregar.TabIndex = 2
        Me.btnAgregar.Text = "AGREGAR FORMULA"
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'btnVolver
        '
        Me.btnVolver.Location = New System.Drawing.Point(511, 78)
        Me.btnVolver.Name = "btnVolver"
        Me.btnVolver.Size = New System.Drawing.Size(75, 37)
        Me.btnVolver.TabIndex = 3
        Me.btnVolver.Text = "VOLVER"
        Me.btnVolver.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(598, 71)
        Me.Panel1.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.Control
        Me.Label1.Location = New System.Drawing.Point(9, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(214, 17)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Ingreso Formulas de Ensayo"
        '
        'Label2
        '
        Me.Label2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.Control
        Me.Label2.Location = New System.Drawing.Point(407, 34)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(179, 24)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "SURFACTAN S.A."
        '
        'Renglon
        '
        Me.Renglon.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Renglon.DataPropertyName = "Renglon"
        Me.Renglon.HeaderText = "Renglon"
        Me.Renglon.Name = "Renglon"
        Me.Renglon.ReadOnly = True
        Me.Renglon.Visible = False
        Me.Renglon.Width = 53
        '
        'Descripcion
        '
        Me.Descripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Descripcion.DataPropertyName = "Descripcion"
        Me.Descripcion.HeaderText = "Descripcion"
        Me.Descripcion.Name = "Descripcion"
        Me.Descripcion.ReadOnly = True
        '
        'Formula
        '
        Me.Formula.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Formula.DataPropertyName = "Formula"
        Me.Formula.HeaderText = "Formula"
        Me.Formula.Name = "Formula"
        Me.Formula.ReadOnly = True
        Me.Formula.Width = 69
        '
        'AnalistaLab
        '
        Me.AnalistaLab.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.AnalistaLab.DataPropertyName = "AnalistaLab"
        Me.AnalistaLab.HeaderText = "AnalistaLab"
        Me.AnalistaLab.Name = "AnalistaLab"
        Me.AnalistaLab.ReadOnly = True
        Me.AnalistaLab.Visible = False
        Me.AnalistaLab.Width = 87
        '
        'Analista
        '
        Me.Analista.DataPropertyName = "Analista"
        Me.Analista.HeaderText = "Analista"
        Me.Analista.Name = "Analista"
        Me.Analista.ReadOnly = True
        '
        'CheckVerificado
        '
        Me.CheckVerificado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.CheckVerificado.DataPropertyName = "CheckVerificado"
        Me.CheckVerificado.FalseValue = "0"
        Me.CheckVerificado.HeaderText = "Verificado"
        Me.CheckVerificado.Name = "CheckVerificado"
        Me.CheckVerificado.ReadOnly = True
        Me.CheckVerificado.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.CheckVerificado.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.CheckVerificado.TrueValue = "1"
        Me.CheckVerificado.Width = 79
        '
        'IngresoFormulasEnsayo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(598, 354)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnVolver)
        Me.Controls.Add(Me.btnAgregar)
        Me.Controls.Add(Me.txtBuscador)
        Me.Controls.Add(Me.DGV_Formulas)
        Me.Name = "IngresoFormulasEnsayo"
        CType(Me.DGV_Formulas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DGV_Formulas As Util.DBDataGridView
    Friend WithEvents txtBuscador As System.Windows.Forms.TextBox
    Friend WithEvents btnAgregar As System.Windows.Forms.Button
    Friend WithEvents btnVolver As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Renglon As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Descripcion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Formula As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AnalistaLab As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Analista As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CheckVerificado As System.Windows.Forms.DataGridViewCheckBoxColumn
End Class
