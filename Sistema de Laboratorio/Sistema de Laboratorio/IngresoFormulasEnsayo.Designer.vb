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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.DGV_Formulas = New Util.DBDataGridView()
        Me.Renglon = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Formula = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AnalistaLab = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Analista = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CheckVerificado = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.txtBuscador = New System.Windows.Forms.TextBox()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.btnVolver = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblTerminado = New System.Windows.Forms.Label()
        Me.lblDescTerminado = New System.Windows.Forms.Label()
        Me.btnPlanillaValidaciones = New System.Windows.Forms.Button()
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
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(232, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGV_Formulas.DefaultCellStyle = DataGridViewCellStyle2
        Me.DGV_Formulas.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.DGV_Formulas.DoubleBuffered = True
        Me.DGV_Formulas.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.DGV_Formulas.Location = New System.Drawing.Point(0, 145)
        Me.DGV_Formulas.Name = "DGV_Formulas"
        Me.DGV_Formulas.OrdenamientoColumnasHabilitado = True
        Me.DGV_Formulas.RowHeadersWidth = 15
        Me.DGV_Formulas.RowTemplate.Height = 20
        Me.DGV_Formulas.ShowCellToolTips = False
        Me.DGV_Formulas.SinClickDerecho = False
        Me.DGV_Formulas.Size = New System.Drawing.Size(589, 239)
        Me.DGV_Formulas.TabIndex = 0
        '
        'Renglon
        '
        Me.Renglon.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Renglon.DataPropertyName = "Renglon"
        Me.Renglon.HeaderText = "Renglon"
        Me.Renglon.Name = "Renglon"
        Me.Renglon.ReadOnly = True
        Me.Renglon.Visible = False
        '
        'Descripcion
        '
        Me.Descripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Descripcion.DataPropertyName = "Descripcion"
        Me.Descripcion.HeaderText = "Descripcion"
        Me.Descripcion.MinimumWidth = 200
        Me.Descripcion.Name = "Descripcion"
        Me.Descripcion.ReadOnly = True
        '
        'Formula
        '
        Me.Formula.DataPropertyName = "Formula"
        Me.Formula.HeaderText = "Formula"
        Me.Formula.Name = "Formula"
        Me.Formula.ReadOnly = True
        Me.Formula.Width = 150
        '
        'AnalistaLab
        '
        Me.AnalistaLab.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.AnalistaLab.DataPropertyName = "AnalistaLab"
        Me.AnalistaLab.HeaderText = "AnalistaLab"
        Me.AnalistaLab.Name = "AnalistaLab"
        Me.AnalistaLab.ReadOnly = True
        Me.AnalistaLab.Visible = False
        '
        'Analista
        '
        Me.Analista.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Analista.DataPropertyName = "Analista"
        Me.Analista.HeaderText = "Analista"
        Me.Analista.Name = "Analista"
        Me.Analista.ReadOnly = True
        Me.Analista.Width = 69
        '
        'CheckVerificado
        '
        Me.CheckVerificado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.CheckVerificado.DataPropertyName = "CheckVerificado"
        Me.CheckVerificado.FalseValue = "0"
        Me.CheckVerificado.HeaderText = "Verif."
        Me.CheckVerificado.IndeterminateValue = "0"
        Me.CheckVerificado.Name = "CheckVerificado"
        Me.CheckVerificado.ReadOnly = True
        Me.CheckVerificado.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.CheckVerificado.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.CheckVerificado.TrueValue = "1"
        Me.CheckVerificado.Width = 56
        '
        'txtBuscador
        '
        Me.txtBuscador.Location = New System.Drawing.Point(3, 121)
        Me.txtBuscador.Name = "txtBuscador"
        Me.txtBuscador.Size = New System.Drawing.Size(582, 20)
        Me.txtBuscador.TabIndex = 1
        '
        'btnAgregar
        '
        Me.btnAgregar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAgregar.Location = New System.Drawing.Point(3, 78)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(158, 37)
        Me.btnAgregar.TabIndex = 2
        Me.btnAgregar.Text = "AGREGAR FORMULA"
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'btnVolver
        '
        Me.btnVolver.Location = New System.Drawing.Point(167, 78)
        Me.btnVolver.Name = "btnVolver"
        Me.btnVolver.Size = New System.Drawing.Size(140, 37)
        Me.btnVolver.TabIndex = 3
        Me.btnVolver.Text = "CERRAR"
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
        Me.Panel1.Size = New System.Drawing.Size(589, 39)
        Me.Panel1.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.Control
        Me.Label1.Location = New System.Drawing.Point(11, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(235, 17)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "INGRESO FÓRMULAS DE ENSAYO"
        '
        'Label2
        '
        Me.Label2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.Control
        Me.Label2.Location = New System.Drawing.Point(400, 7)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(179, 24)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "SURFACTAN S.A."
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(11, 51)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(68, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "PRODUCTO"
        '
        'lblTerminado
        '
        Me.lblTerminado.BackColor = System.Drawing.Color.Cyan
        Me.lblTerminado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTerminado.Location = New System.Drawing.Point(85, 46)
        Me.lblTerminado.Name = "lblTerminado"
        Me.lblTerminado.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.lblTerminado.Size = New System.Drawing.Size(85, 23)
        Me.lblTerminado.TabIndex = 6
        Me.lblTerminado.Text = "PT-99999-999"
        Me.lblTerminado.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblDescTerminado
        '
        Me.lblDescTerminado.BackColor = System.Drawing.Color.Cyan
        Me.lblDescTerminado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblDescTerminado.Location = New System.Drawing.Point(176, 46)
        Me.lblDescTerminado.Name = "lblDescTerminado"
        Me.lblDescTerminado.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.lblDescTerminado.Size = New System.Drawing.Size(403, 23)
        Me.lblDescTerminado.TabIndex = 6
        Me.lblDescTerminado.Text = "PT-99999-999"
        Me.lblDescTerminado.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnPlanillaValidaciones
        '
        Me.btnPlanillaValidaciones.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPlanillaValidaciones.Location = New System.Drawing.Point(404, 78)
        Me.btnPlanillaValidaciones.Name = "btnPlanillaValidaciones"
        Me.btnPlanillaValidaciones.Size = New System.Drawing.Size(181, 37)
        Me.btnPlanillaValidaciones.TabIndex = 2
        Me.btnPlanillaValidaciones.Text = "PLANILLA VALIDACIONES"
        Me.btnPlanillaValidaciones.UseVisualStyleBackColor = True
        '
        'IngresoFormulasEnsayo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(589, 384)
        Me.Controls.Add(Me.lblDescTerminado)
        Me.Controls.Add(Me.lblTerminado)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnVolver)
        Me.Controls.Add(Me.btnPlanillaValidaciones)
        Me.Controls.Add(Me.btnAgregar)
        Me.Controls.Add(Me.txtBuscador)
        Me.Controls.Add(Me.DGV_Formulas)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "IngresoFormulasEnsayo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
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
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblTerminado As System.Windows.Forms.Label
    Friend WithEvents lblDescTerminado As System.Windows.Forms.Label
    Friend WithEvents btnPlanillaValidaciones As System.Windows.Forms.Button
End Class
