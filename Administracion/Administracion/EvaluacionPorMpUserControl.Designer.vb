<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EvaluacionPorMpUserControl
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbCalificacion = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblDescComercial = New System.Windows.Forms.Label()
        Me.lblDescripcion = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblCodigo = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtFechaAux = New System.Windows.Forms.MaskedTextBox()
        Me.dgvItemsEvaluados = New ConsultasVarias.DBDataGridView()
        Me.cmbAux = New System.Windows.Forms.ComboBox()
        Me.Req = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Requisitos = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Solicitado = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.FechaSolicitado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Entrego = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.FechaEntrego = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Aprobo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FechaAprobo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Vto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Aclaraciones = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Doc = New System.Windows.Forms.DataGridViewLinkColumn()
        Me.DocPath = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.dgvItemsEvaluados, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(25, 55)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(128, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Calificación de Proveedor"
        '
        'cmbCalificacion
        '
        Me.cmbCalificacion.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbCalificacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCalificacion.FormattingEnabled = True
        Me.cmbCalificacion.Items.AddRange(New Object() {"NO DEFINIDO", "APROBADO", "NO APROBADO", "APROBADO POR ÚNICA VEZ"})
        Me.cmbCalificacion.Location = New System.Drawing.Point(169, 51)
        Me.cmbCalificacion.Name = "cmbCalificacion"
        Me.cmbCalificacion.Size = New System.Drawing.Size(680, 21)
        Me.cmbCalificacion.TabIndex = 2
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblDescComercial)
        Me.GroupBox1.Controls.Add(Me.lblDescripcion)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.lblCodigo)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.cmbCalificacion)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(873, 78)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        '
        'lblDescComercial
        '
        Me.lblDescComercial.BackColor = System.Drawing.Color.Cyan
        Me.lblDescComercial.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDescComercial.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescComercial.Location = New System.Drawing.Point(248, 30)
        Me.lblDescComercial.Name = "lblDescComercial"
        Me.lblDescComercial.Size = New System.Drawing.Size(601, 16)
        Me.lblDescComercial.TabIndex = 4
        Me.lblDescComercial.Text = "Label3"
        '
        'lblDescripcion
        '
        Me.lblDescripcion.BackColor = System.Drawing.Color.Cyan
        Me.lblDescripcion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDescripcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescripcion.Location = New System.Drawing.Point(248, 12)
        Me.lblDescripcion.Name = "lblDescripcion"
        Me.lblDescripcion.Size = New System.Drawing.Size(601, 16)
        Me.lblDescripcion.TabIndex = 4
        Me.lblDescripcion.Text = "Label3"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(163, 30)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(84, 13)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "Desc Comercial:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(163, 12)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(66, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Descripción:"
        '
        'lblCodigo
        '
        Me.lblCodigo.BackColor = System.Drawing.Color.Cyan
        Me.lblCodigo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCodigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCodigo.Location = New System.Drawing.Point(75, 12)
        Me.lblCodigo.Name = "lblCodigo"
        Me.lblCodigo.Size = New System.Drawing.Size(78, 16)
        Me.lblCodigo.TabIndex = 4
        Me.lblCodigo.Text = "Label3"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(25, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Código"
        '
        'BackgroundWorker1
        '
        Me.BackgroundWorker1.WorkerReportsProgress = True
        Me.BackgroundWorker1.WorkerSupportsCancellation = True
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.GroupBox1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 84.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(879, 475)
        Me.TableLayoutPanel1.TabIndex = 4
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.cmbAux)
        Me.Panel1.Controls.Add(Me.txtFechaAux)
        Me.Panel1.Controls.Add(Me.dgvItemsEvaluados)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 87)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(873, 385)
        Me.Panel1.TabIndex = 4
        '
        'txtFechaAux
        '
        Me.txtFechaAux.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtFechaAux.Location = New System.Drawing.Point(676, 31)
        Me.txtFechaAux.Mask = "00/00/0000"
        Me.txtFechaAux.Name = "txtFechaAux"
        Me.txtFechaAux.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtFechaAux.Size = New System.Drawing.Size(58, 13)
        Me.txtFechaAux.TabIndex = 2
        Me.txtFechaAux.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtFechaAux.Visible = False
        '
        'dgvItemsEvaluados
        '
        Me.dgvItemsEvaluados.AllowUserToAddRows = False
        Me.dgvItemsEvaluados.AllowUserToDeleteRows = False
        Me.dgvItemsEvaluados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvItemsEvaluados.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Req, Me.Requisitos, Me.Solicitado, Me.FechaSolicitado, Me.Entrego, Me.FechaEntrego, Me.Aprobo, Me.FechaAprobo, Me.Vto, Me.Aclaraciones, Me.Doc, Me.DocPath})
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(232, Byte), Integer))
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvItemsEvaluados.DefaultCellStyle = DataGridViewCellStyle6
        Me.dgvItemsEvaluados.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvItemsEvaluados.DoubleBuffered = True
        Me.dgvItemsEvaluados.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dgvItemsEvaluados.Location = New System.Drawing.Point(0, 0)
        Me.dgvItemsEvaluados.Name = "dgvItemsEvaluados"
        Me.dgvItemsEvaluados.RowHeadersWidth = 15
        Me.dgvItemsEvaluados.RowTemplate.Height = 20
        Me.dgvItemsEvaluados.ShowCellToolTips = False
        Me.dgvItemsEvaluados.SinClickDerecho = False
        Me.dgvItemsEvaluados.Size = New System.Drawing.Size(873, 385)
        Me.dgvItemsEvaluados.TabIndex = 0
        '
        'cmbAux
        '
        Me.cmbAux.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAux.FormattingEnabled = True
        Me.cmbAux.Items.AddRange(New Object() {"", "APROBADO", "NO APLICA"})
        Me.cmbAux.Location = New System.Drawing.Point(338, 79)
        Me.cmbAux.Name = "cmbAux"
        Me.cmbAux.Size = New System.Drawing.Size(121, 21)
        Me.cmbAux.TabIndex = 3
        Me.cmbAux.Visible = False
        '
        'Req
        '
        Me.Req.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Req.DefaultCellStyle = DataGridViewCellStyle1
        Me.Req.HeaderText = "Nro"
        Me.Req.Name = "Req"
        Me.Req.ReadOnly = True
        Me.Req.Width = 49
        '
        'Requisitos
        '
        Me.Requisitos.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Requisitos.HeaderText = "Requisitos"
        Me.Requisitos.MinimumWidth = 200
        Me.Requisitos.Name = "Requisitos"
        Me.Requisitos.ReadOnly = True
        Me.Requisitos.Width = 200
        '
        'Solicitado
        '
        Me.Solicitado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Solicitado.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Solicitado.HeaderText = "Solicitado"
        Me.Solicitado.Name = "Solicitado"
        Me.Solicitado.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Solicitado.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Solicitado.Width = 78
        '
        'FechaSolicitado
        '
        Me.FechaSolicitado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(232, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText
        Me.FechaSolicitado.DefaultCellStyle = DataGridViewCellStyle2
        Me.FechaSolicitado.HeaderText = "Fecha"
        Me.FechaSolicitado.MinimumWidth = 75
        Me.FechaSolicitado.Name = "FechaSolicitado"
        Me.FechaSolicitado.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.FechaSolicitado.Width = 75
        '
        'Entrego
        '
        Me.Entrego.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Entrego.HeaderText = "Entrego"
        Me.Entrego.Name = "Entrego"
        Me.Entrego.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Entrego.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Entrego.Width = 69
        '
        'FechaEntrego
        '
        Me.FechaEntrego.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.FechaEntrego.DefaultCellStyle = DataGridViewCellStyle3
        Me.FechaEntrego.HeaderText = "Fecha"
        Me.FechaEntrego.MinimumWidth = 75
        Me.FechaEntrego.Name = "FechaEntrego"
        Me.FechaEntrego.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.FechaEntrego.Width = 75
        '
        'Aprobo
        '
        Me.Aprobo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Aprobo.HeaderText = "Aprobo"
        Me.Aprobo.MinimumWidth = 100
        Me.Aprobo.Name = "Aprobo"
        Me.Aprobo.ReadOnly = True
        Me.Aprobo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'FechaAprobo
        '
        Me.FechaAprobo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.FechaAprobo.DefaultCellStyle = DataGridViewCellStyle4
        Me.FechaAprobo.HeaderText = "Fecha"
        Me.FechaAprobo.MinimumWidth = 75
        Me.FechaAprobo.Name = "FechaAprobo"
        Me.FechaAprobo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.FechaAprobo.Width = 75
        '
        'Vto
        '
        Me.Vto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Vto.DataPropertyName = "Vto"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Vto.DefaultCellStyle = DataGridViewCellStyle5
        Me.Vto.HeaderText = "Vto"
        Me.Vto.MinimumWidth = 75
        Me.Vto.Name = "Vto"
        Me.Vto.ReadOnly = True
        Me.Vto.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Vto.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Vto.Width = 75
        '
        'Aclaraciones
        '
        Me.Aclaraciones.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Aclaraciones.HeaderText = "Aclaraciones"
        Me.Aclaraciones.MaxInputLength = 150
        Me.Aclaraciones.MinimumWidth = 200
        Me.Aclaraciones.Name = "Aclaraciones"
        Me.Aclaraciones.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Aclaraciones.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Aclaraciones.Width = 200
        '
        'Doc
        '
        Me.Doc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Doc.HeaderText = "Doc"
        Me.Doc.MinimumWidth = 100
        Me.Doc.Name = "Doc"
        Me.Doc.ReadOnly = True
        Me.Doc.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Doc.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Doc.Text = "Ver Archivo"
        Me.Doc.UseColumnTextForLinkValue = True
        '
        'DocPath
        '
        Me.DocPath.HeaderText = "DocPath"
        Me.DocPath.Name = "DocPath"
        Me.DocPath.ReadOnly = True
        Me.DocPath.Visible = False
        '
        'EvaluacionPorMpUserControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.DoubleBuffered = True
        Me.Name = "EvaluacionPorMpUserControl"
        Me.Size = New System.Drawing.Size(879, 475)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dgvItemsEvaluados, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvItemsEvaluados As ConsultasVarias.DBDataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbCalificacion As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblCodigo As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblDescripcion As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblDescComercial As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents txtFechaAux As System.Windows.Forms.MaskedTextBox
    Friend WithEvents cmbAux As System.Windows.Forms.ComboBox
    Friend WithEvents Req As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Requisitos As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Solicitado As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents FechaSolicitado As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Entrego As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents FechaEntrego As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Aprobo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FechaAprobo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Vto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Aclaraciones As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Doc As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents DocPath As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
