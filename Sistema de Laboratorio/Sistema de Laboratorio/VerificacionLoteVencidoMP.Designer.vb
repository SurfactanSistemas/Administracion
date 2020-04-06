<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class VerificacionLoteVencidoMP
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle39 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle27 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle28 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle29 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle30 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle31 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle32 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle33 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle34 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle35 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle36 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle37 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle38 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.btnAjustes = New System.Windows.Forms.Button()
        Me.btnVolver = New System.Windows.Forms.Button()
        Me.pnlContrasena = New System.Windows.Forms.Panel()
        Me.btnpnlVolver = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtpnlContrasena = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.DGV_Verificacion = New ConsultasVarias.DBDataGridView()
        Me.Check = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.TipoMov = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MPrima = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PlantaOrigen = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Lote = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PlantaHoja = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Hoja = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Fecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Stock = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SI = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SII = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SIII = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SIV = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SV = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SVI = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SVII = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Tipo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DiferenciaEnDIas = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pnlContrasena.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.DGV_Verificacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnAjustes
        '
        Me.btnAjustes.Location = New System.Drawing.Point(11, 52)
        Me.btnAjustes.Name = "btnAjustes"
        Me.btnAjustes.Size = New System.Drawing.Size(75, 23)
        Me.btnAjustes.TabIndex = 0
        Me.btnAjustes.Text = "Ajustes"
        Me.btnAjustes.UseVisualStyleBackColor = True
        '
        'btnVolver
        '
        Me.btnVolver.Location = New System.Drawing.Point(703, 52)
        Me.btnVolver.Name = "btnVolver"
        Me.btnVolver.Size = New System.Drawing.Size(75, 23)
        Me.btnVolver.TabIndex = 1
        Me.btnVolver.Text = "Volver"
        Me.btnVolver.UseVisualStyleBackColor = True
        '
        'pnlContrasena
        '
        Me.pnlContrasena.Controls.Add(Me.btnpnlVolver)
        Me.pnlContrasena.Controls.Add(Me.Panel2)
        Me.pnlContrasena.Controls.Add(Me.txtpnlContrasena)
        Me.pnlContrasena.Controls.Add(Me.Label1)
        Me.pnlContrasena.Location = New System.Drawing.Point(253, 189)
        Me.pnlContrasena.Name = "pnlContrasena"
        Me.pnlContrasena.Size = New System.Drawing.Size(281, 131)
        Me.pnlContrasena.TabIndex = 3
        '
        'btnpnlVolver
        '
        Me.btnpnlVolver.Location = New System.Drawing.Point(103, 102)
        Me.btnpnlVolver.Name = "btnpnlVolver"
        Me.btnpnlVolver.Size = New System.Drawing.Size(75, 23)
        Me.btnpnlVolver.TabIndex = 3
        Me.btnpnlVolver.Text = "Volver"
        Me.btnpnlVolver.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(281, 37)
        Me.Panel2.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.Control
        Me.Label4.Location = New System.Drawing.Point(51, 6)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(179, 24)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "SURFACTAN S.A."
        '
        'txtpnlContrasena
        '
        Me.txtpnlContrasena.Location = New System.Drawing.Point(56, 76)
        Me.txtpnlContrasena.Name = "txtpnlContrasena"
        Me.txtpnlContrasena.Size = New System.Drawing.Size(166, 20)
        Me.txtpnlContrasena.TabIndex = 1
        Me.txtpnlContrasena.UseSystemPasswordChar = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(81, 46)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(107, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Ingresa la clave"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.Panel3.Controls.Add(Me.Label3)
        Me.Panel3.Controls.Add(Me.Label2)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(790, 46)
        Me.Panel3.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.Control
        Me.Label3.Location = New System.Drawing.Point(12, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(257, 20)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Verificacion de Lotes Vencidos"
        '
        'Label2
        '
        Me.Label2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.Control
        Me.Label2.Location = New System.Drawing.Point(599, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(179, 24)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "SURFACTAN S.A."
        '
        'BackgroundWorker1
        '
        Me.BackgroundWorker1.WorkerReportsProgress = True
        Me.BackgroundWorker1.WorkerSupportsCancellation = True
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(93, 62)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(210, 12)
        Me.ProgressBar1.TabIndex = 5
        '
        'Timer1
        '
        Me.Timer1.Interval = 2000
        '
        'DGV_Verificacion
        '
        Me.DGV_Verificacion.AllowUserToAddRows = False
        Me.DGV_Verificacion.AllowUserToDeleteRows = False
        Me.DGV_Verificacion.AllowUserToResizeColumns = False
        Me.DGV_Verificacion.AllowUserToResizeRows = False
        Me.DGV_Verificacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_Verificacion.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Check, Me.TipoMov, Me.MPrima, Me.Descripcion, Me.PlantaOrigen, Me.Lote, Me.PlantaHoja, Me.Hoja, Me.Fecha, Me.Stock, Me.SI, Me.SII, Me.SIII, Me.SIV, Me.SV, Me.SVI, Me.SVII, Me.Tipo, Me.DiferenciaEnDIas})
        DataGridViewCellStyle39.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle39.BackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(232, Byte), Integer))
        DataGridViewCellStyle39.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle39.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle39.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle39.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle39.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGV_Verificacion.DefaultCellStyle = DataGridViewCellStyle39
        Me.DGV_Verificacion.DoubleBuffered = True
        Me.DGV_Verificacion.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.DGV_Verificacion.Location = New System.Drawing.Point(11, 81)
        Me.DGV_Verificacion.Name = "DGV_Verificacion"
        Me.DGV_Verificacion.OrdenamientoColumnasHabilitado = True
        Me.DGV_Verificacion.RowHeadersWidth = 15
        Me.DGV_Verificacion.RowTemplate.Height = 20
        Me.DGV_Verificacion.ShowCellToolTips = False
        Me.DGV_Verificacion.SinClickDerecho = False
        Me.DGV_Verificacion.Size = New System.Drawing.Size(767, 417)
        Me.DGV_Verificacion.TabIndex = 2
        '
        'Check
        '
        Me.Check.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Check.FalseValue = "false"
        Me.Check.HeaderText = ""
        Me.Check.Name = "Check"
        Me.Check.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Check.TrueValue = "true"
        Me.Check.Width = 19
        '
        'TipoMov
        '
        Me.TipoMov.HeaderText = "TipoMov"
        Me.TipoMov.Name = "TipoMov"
        Me.TipoMov.Visible = False
        '
        'MPrima
        '
        Me.MPrima.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.MPrima.HeaderText = "M. Prima"
        Me.MPrima.Name = "MPrima"
        Me.MPrima.Width = 73
        '
        'Descripcion
        '
        Me.Descripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Descripcion.HeaderText = "Descripcion"
        Me.Descripcion.Name = "Descripcion"
        Me.Descripcion.Width = 88
        '
        'PlantaOrigen
        '
        Me.PlantaOrigen.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        DataGridViewCellStyle27.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.PlantaOrigen.DefaultCellStyle = DataGridViewCellStyle27
        Me.PlantaOrigen.HeaderText = "Planta O."
        Me.PlantaOrigen.Name = "PlantaOrigen"
        Me.PlantaOrigen.Width = 76
        '
        'Lote
        '
        Me.Lote.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        DataGridViewCellStyle28.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Lote.DefaultCellStyle = DataGridViewCellStyle28
        Me.Lote.HeaderText = "Lote"
        Me.Lote.Name = "Lote"
        Me.Lote.Width = 53
        '
        'PlantaHoja
        '
        Me.PlantaHoja.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        DataGridViewCellStyle29.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.PlantaHoja.DefaultCellStyle = DataGridViewCellStyle29
        Me.PlantaHoja.HeaderText = "Planta H."
        Me.PlantaHoja.Name = "PlantaHoja"
        Me.PlantaHoja.Width = 76
        '
        'Hoja
        '
        Me.Hoja.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        DataGridViewCellStyle30.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Hoja.DefaultCellStyle = DataGridViewCellStyle30
        Me.Hoja.HeaderText = "Hoja"
        Me.Hoja.Name = "Hoja"
        Me.Hoja.Width = 54
        '
        'Fecha
        '
        Me.Fecha.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Fecha.HeaderText = "Fecha"
        Me.Fecha.Name = "Fecha"
        Me.Fecha.Width = 62
        '
        'Stock
        '
        Me.Stock.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        DataGridViewCellStyle31.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Stock.DefaultCellStyle = DataGridViewCellStyle31
        Me.Stock.HeaderText = "Stock"
        Me.Stock.Name = "Stock"
        Me.Stock.Width = 60
        '
        'SI
        '
        Me.SI.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        DataGridViewCellStyle32.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.SI.DefaultCellStyle = DataGridViewCellStyle32
        Me.SI.HeaderText = "SI"
        Me.SI.Name = "SI"
        Me.SI.Width = 42
        '
        'SII
        '
        Me.SII.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        DataGridViewCellStyle33.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.SII.DefaultCellStyle = DataGridViewCellStyle33
        Me.SII.HeaderText = "SII"
        Me.SII.Name = "SII"
        Me.SII.Width = 45
        '
        'SIII
        '
        Me.SIII.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        DataGridViewCellStyle34.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.SIII.DefaultCellStyle = DataGridViewCellStyle34
        Me.SIII.HeaderText = "SIII"
        Me.SIII.Name = "SIII"
        Me.SIII.Width = 48
        '
        'SIV
        '
        Me.SIV.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        DataGridViewCellStyle35.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.SIV.DefaultCellStyle = DataGridViewCellStyle35
        Me.SIV.HeaderText = "SIV"
        Me.SIV.Name = "SIV"
        Me.SIV.Width = 49
        '
        'SV
        '
        Me.SV.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        DataGridViewCellStyle36.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.SV.DefaultCellStyle = DataGridViewCellStyle36
        Me.SV.HeaderText = "SV"
        Me.SV.Name = "SV"
        Me.SV.Width = 46
        '
        'SVI
        '
        Me.SVI.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        DataGridViewCellStyle37.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.SVI.DefaultCellStyle = DataGridViewCellStyle37
        Me.SVI.HeaderText = "SVI"
        Me.SVI.Name = "SVI"
        Me.SVI.Width = 49
        '
        'SVII
        '
        Me.SVII.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        DataGridViewCellStyle38.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.SVII.DefaultCellStyle = DataGridViewCellStyle38
        Me.SVII.HeaderText = "SVII"
        Me.SVII.Name = "SVII"
        Me.SVII.Width = 52
        '
        'Tipo
        '
        Me.Tipo.HeaderText = "Tipo"
        Me.Tipo.Name = "Tipo"
        Me.Tipo.Visible = False
        '
        'DiferenciaEnDIas
        '
        Me.DiferenciaEnDIas.HeaderText = "DiferenciaEnDIas"
        Me.DiferenciaEnDIas.Name = "DiferenciaEnDIas"
        Me.DiferenciaEnDIas.Visible = False
        '
        'VerificacionLoteVencidoMP
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(790, 510)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.pnlContrasena)
        Me.Controls.Add(Me.DGV_Verificacion)
        Me.Controls.Add(Me.btnVolver)
        Me.Controls.Add(Me.btnAjustes)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "VerificacionLoteVencidoMP"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.pnlContrasena.ResumeLayout(False)
        Me.pnlContrasena.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.DGV_Verificacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnAjustes As System.Windows.Forms.Button
    Friend WithEvents btnVolver As System.Windows.Forms.Button
    Friend WithEvents DGV_Verificacion As ConsultasVarias.DBDataGridView
    Friend WithEvents pnlContrasena As System.Windows.Forms.Panel
    Friend WithEvents txtpnlContrasena As System.Windows.Forms.TextBox
    Private WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents btnpnlVolver As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Check As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents TipoMov As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MPrima As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Descripcion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PlantaOrigen As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Lote As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PlantaHoja As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Hoja As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Fecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Stock As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SI As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SII As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SIII As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SIV As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SV As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SVI As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SVII As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Tipo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DiferenciaEnDIas As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
