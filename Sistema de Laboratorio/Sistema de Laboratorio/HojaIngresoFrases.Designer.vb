<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class HojaIngresoFrases
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.btnVolver = New System.Windows.Forms.Button()
        Me.btnImprimir = New System.Windows.Forms.Button()
        Me.btnListar = New System.Windows.Forms.Button()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.btnGrabar = New System.Windows.Forms.Button()
        Me.txtObservacion = New System.Windows.Forms.TextBox()
        Me.txtDescripcion = New System.Windows.Forms.TextBox()
        Me.txtCodigo = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.LblTitulo = New System.Windows.Forms.Label()
        Me.pnlListar = New System.Windows.Forms.Panel()
        Me.DGV_ListadoI = New ConsultasVarias.DBDataGridView()
        Me.Codigo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Observa = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnVolPnlListar = New System.Windows.Forms.Button()
        Me.txtBuscadorListar = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.pnlListar.SuspendLayout()
        CType(Me.DGV_ListadoI, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnVolver
        '
        Me.btnVolver.Location = New System.Drawing.Point(496, 253)
        Me.btnVolver.Name = "btnVolver"
        Me.btnVolver.Size = New System.Drawing.Size(60, 60)
        Me.btnVolver.TabIndex = 23
        Me.btnVolver.TabStop = False
        Me.btnVolver.Text = "Volver"
        Me.btnVolver.UseVisualStyleBackColor = True
        '
        'btnImprimir
        '
        Me.btnImprimir.Location = New System.Drawing.Point(400, 254)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(60, 60)
        Me.btnImprimir.TabIndex = 22
        Me.btnImprimir.TabStop = False
        Me.btnImprimir.Text = "Imprimir"
        Me.btnImprimir.UseVisualStyleBackColor = True
        '
        'btnListar
        '
        Me.btnListar.Location = New System.Drawing.Point(302, 254)
        Me.btnListar.Name = "btnListar"
        Me.btnListar.Size = New System.Drawing.Size(60, 60)
        Me.btnListar.TabIndex = 21
        Me.btnListar.TabStop = False
        Me.btnListar.Text = "Listar"
        Me.btnListar.UseVisualStyleBackColor = True
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Location = New System.Drawing.Point(205, 254)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(60, 60)
        Me.btnLimpiar.TabIndex = 20
        Me.btnLimpiar.TabStop = False
        Me.btnLimpiar.Text = "Limpiar"
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'btnEliminar
        '
        Me.btnEliminar.Location = New System.Drawing.Point(109, 254)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(60, 60)
        Me.btnEliminar.TabIndex = 19
        Me.btnEliminar.TabStop = False
        Me.btnEliminar.Text = "Eliminar"
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'btnGrabar
        '
        Me.btnGrabar.Location = New System.Drawing.Point(15, 254)
        Me.btnGrabar.Name = "btnGrabar"
        Me.btnGrabar.Size = New System.Drawing.Size(60, 60)
        Me.btnGrabar.TabIndex = 18
        Me.btnGrabar.TabStop = False
        Me.btnGrabar.Text = "Grabar"
        Me.btnGrabar.UseVisualStyleBackColor = True
        '
        'txtObservacion
        '
        Me.txtObservacion.Location = New System.Drawing.Point(159, 205)
        Me.txtObservacion.MaxLength = 50
        Me.txtObservacion.Name = "txtObservacion"
        Me.txtObservacion.Size = New System.Drawing.Size(397, 20)
        Me.txtObservacion.TabIndex = 17
        '
        'txtDescripcion
        '
        Me.txtDescripcion.Location = New System.Drawing.Point(159, 100)
        Me.txtDescripcion.MaxLength = 450
        Me.txtDescripcion.Multiline = True
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(397, 92)
        Me.txtDescripcion.TabIndex = 16
        '
        'txtCodigo
        '
        Me.txtCodigo.Location = New System.Drawing.Point(159, 62)
        Me.txtCodigo.MaxLength = 50
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Size = New System.Drawing.Size(112, 20)
        Me.txtCodigo.TabIndex = 15
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 208)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(78, 13)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "Observaciones"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 100)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 13)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "Descripcion"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 65)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Codigo"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.LblTitulo)
        Me.Panel1.Location = New System.Drawing.Point(-7, -8)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(581, 64)
        Me.Panel1.TabIndex = 24
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.Control
        Me.Label4.Location = New System.Drawing.Point(385, 29)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(168, 22)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "SURFACTAN S.A"
        '
        'LblTitulo
        '
        Me.LblTitulo.AutoSize = True
        Me.LblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTitulo.ForeColor = System.Drawing.SystemColors.Control
        Me.LblTitulo.Location = New System.Drawing.Point(23, 31)
        Me.LblTitulo.Name = "LblTitulo"
        Me.LblTitulo.Size = New System.Drawing.Size(63, 20)
        Me.LblTitulo.TabIndex = 0
        Me.LblTitulo.Text = "Label4"
        '
        'pnlListar
        '
        Me.pnlListar.Controls.Add(Me.DGV_ListadoI)
        Me.pnlListar.Controls.Add(Me.btnVolPnlListar)
        Me.pnlListar.Controls.Add(Me.txtBuscadorListar)
        Me.pnlListar.Controls.Add(Me.Label5)
        Me.pnlListar.Location = New System.Drawing.Point(15, 62)
        Me.pnlListar.Name = "pnlListar"
        Me.pnlListar.Size = New System.Drawing.Size(534, 163)
        Me.pnlListar.TabIndex = 25
        '
        'DGV_ListadoI
        '
        Me.DGV_ListadoI.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_ListadoI.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Codigo, Me.Descripcion, Me.Observa})
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(232, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGV_ListadoI.DefaultCellStyle = DataGridViewCellStyle1
        Me.DGV_ListadoI.DoubleBuffered = True
        Me.DGV_ListadoI.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.DGV_ListadoI.Location = New System.Drawing.Point(26, 54)
        Me.DGV_ListadoI.Name = "DGV_ListadoI"
        Me.DGV_ListadoI.OrdenamientoColumnasHabilitado = True
        Me.DGV_ListadoI.ReadOnly = True
        Me.DGV_ListadoI.RowHeadersWidth = 15
        Me.DGV_ListadoI.RowTemplate.Height = 20
        Me.DGV_ListadoI.ShowCellToolTips = False
        Me.DGV_ListadoI.SinClickDerecho = False
        Me.DGV_ListadoI.Size = New System.Drawing.Size(485, 150)
        Me.DGV_ListadoI.TabIndex = 5
        '
        'Codigo
        '
        Me.Codigo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Codigo.DataPropertyName = "Codigo"
        Me.Codigo.HeaderText = "Codigo"
        Me.Codigo.Name = "Codigo"
        Me.Codigo.ReadOnly = True
        Me.Codigo.Width = 65
        '
        'Descripcion
        '
        Me.Descripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Descripcion.DataPropertyName = "Descripcion"
        Me.Descripcion.HeaderText = "Descripcion"
        Me.Descripcion.Name = "Descripcion"
        Me.Descripcion.ReadOnly = True
        Me.Descripcion.Width = 88
        '
        'Observa
        '
        Me.Observa.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Observa.DataPropertyName = "Observa"
        Me.Observa.HeaderText = "Observaciones"
        Me.Observa.Name = "Observa"
        Me.Observa.ReadOnly = True
        Me.Observa.Width = 103
        '
        'btnVolPnlListar
        '
        Me.btnVolPnlListar.Location = New System.Drawing.Point(201, 219)
        Me.btnVolPnlListar.Name = "btnVolPnlListar"
        Me.btnVolPnlListar.Size = New System.Drawing.Size(121, 26)
        Me.btnVolPnlListar.TabIndex = 3
        Me.btnVolPnlListar.Text = "Volver"
        Me.btnVolPnlListar.UseVisualStyleBackColor = True
        '
        'txtBuscadorListar
        '
        Me.txtBuscadorListar.Location = New System.Drawing.Point(26, 28)
        Me.txtBuscadorListar.Name = "txtBuscadorListar"
        Me.txtBuscadorListar.Size = New System.Drawing.Size(485, 20)
        Me.txtBuscadorListar.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(28, 8)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(52, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Buscador"
        '
        'HojaIngresoFrases
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(568, 324)
        Me.Controls.Add(Me.pnlListar)
        Me.Controls.Add(Me.btnVolver)
        Me.Controls.Add(Me.btnImprimir)
        Me.Controls.Add(Me.btnListar)
        Me.Controls.Add(Me.btnLimpiar)
        Me.Controls.Add(Me.btnEliminar)
        Me.Controls.Add(Me.btnGrabar)
        Me.Controls.Add(Me.txtObservacion)
        Me.Controls.Add(Me.txtDescripcion)
        Me.Controls.Add(Me.txtCodigo)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "HojaIngresoFrases"
        Me.Text = "HojaIngresoFRASES1"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.pnlListar.ResumeLayout(False)
        Me.pnlListar.PerformLayout()
        CType(Me.DGV_ListadoI, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnVolver As System.Windows.Forms.Button
    Friend WithEvents btnImprimir As System.Windows.Forms.Button
    Friend WithEvents btnListar As System.Windows.Forms.Button
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents btnEliminar As System.Windows.Forms.Button
    Friend WithEvents btnGrabar As System.Windows.Forms.Button
    Friend WithEvents txtObservacion As System.Windows.Forms.TextBox
    Friend WithEvents txtDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents LblTitulo As System.Windows.Forms.Label
    Friend WithEvents pnlListar As System.Windows.Forms.Panel
    Friend WithEvents txtBuscadorListar As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnVolPnlListar As System.Windows.Forms.Button
    Friend WithEvents DGV_ListadoI As ConsultasVarias.DBDataGridView
    Friend WithEvents Codigo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Descripcion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Observa As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
