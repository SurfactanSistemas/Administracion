<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Gestion_Solicitudes
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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.chk_SinFecha = New System.Windows.Forms.CheckBox()
        Me.chk_CuartaSemana = New System.Windows.Forms.CheckBox()
        Me.chk_SegundaSemana = New System.Windows.Forms.CheckBox()
        Me.chk_TercerSemana = New System.Windows.Forms.CheckBox()
        Me.chk_SemanaActual = New System.Windows.Forms.CheckBox()
        Me.txt_Filtro = New System.Windows.Forms.TextBox()
        Me.btn_Cerrar = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txt_TotalPesos = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txt_TotalDolares = New System.Windows.Forms.TextBox()
        Me.btn_ImprimeListado = New System.Windows.Forms.Button()
        Me.DGV_Solicitudes = New Util.DBDataGridView()
        Me.chk = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.NroSolicitud = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Solicitante = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Fecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OrdFecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Tipo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Destino = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Titulo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Moneda = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Importe = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FechaRequerida = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OrdFechaRequerida = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Estado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btn_Autorizar = New System.Windows.Forms.Button()
        Me.btn_Eliminar = New System.Windows.Forms.Button()
        Me.panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DGV_Solicitudes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'panel1
        '
        Me.panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(34, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.panel1.Controls.Add(Me.Label2)
        Me.panel1.Controls.Add(Me.label1)
        Me.panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.panel1.Location = New System.Drawing.Point(0, 0)
        Me.panel1.Name = "panel1"
        Me.panel1.Size = New System.Drawing.Size(915, 40)
        Me.panel1.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(739, 10)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(155, 20)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "SURFACTAN S.A."
        '
        'label1
        '
        Me.label1.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.label1.AutoSize = True
        Me.label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold)
        Me.label1.ForeColor = System.Drawing.Color.White
        Me.label1.Location = New System.Drawing.Point(21, 12)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(209, 17)
        Me.label1.TabIndex = 0
        Me.label1.Text = "GESTION DE SOLICITUDES"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chk_SinFecha)
        Me.GroupBox1.Controls.Add(Me.chk_CuartaSemana)
        Me.GroupBox1.Controls.Add(Me.chk_SegundaSemana)
        Me.GroupBox1.Controls.Add(Me.chk_TercerSemana)
        Me.GroupBox1.Controls.Add(Me.chk_SemanaActual)
        Me.GroupBox1.Location = New System.Drawing.Point(10, 44)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(348, 69)
        Me.GroupBox1.TabIndex = 7
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Rango Fechas"
        '
        'chk_SinFecha
        '
        Me.chk_SinFecha.AutoSize = True
        Me.chk_SinFecha.Location = New System.Drawing.Point(248, 31)
        Me.chk_SinFecha.Name = "chk_SinFecha"
        Me.chk_SinFecha.Size = New System.Drawing.Size(74, 17)
        Me.chk_SinFecha.TabIndex = 4
        Me.chk_SinFecha.Text = "Sin Fecha"
        Me.chk_SinFecha.UseVisualStyleBackColor = True
        '
        'chk_CuartaSemana
        '
        Me.chk_CuartaSemana.AutoSize = True
        Me.chk_CuartaSemana.Location = New System.Drawing.Point(137, 42)
        Me.chk_CuartaSemana.Name = "chk_CuartaSemana"
        Me.chk_CuartaSemana.Size = New System.Drawing.Size(99, 17)
        Me.chk_CuartaSemana.TabIndex = 3
        Me.chk_CuartaSemana.Text = "Cuarta Semana"
        Me.chk_CuartaSemana.UseVisualStyleBackColor = True
        '
        'chk_SegundaSemana
        '
        Me.chk_SegundaSemana.AutoSize = True
        Me.chk_SegundaSemana.Location = New System.Drawing.Point(137, 19)
        Me.chk_SegundaSemana.Name = "chk_SegundaSemana"
        Me.chk_SegundaSemana.Size = New System.Drawing.Size(111, 17)
        Me.chk_SegundaSemana.TabIndex = 2
        Me.chk_SegundaSemana.Text = "Segunda Semana"
        Me.chk_SegundaSemana.UseVisualStyleBackColor = True
        '
        'chk_TercerSemana
        '
        Me.chk_TercerSemana.AutoSize = True
        Me.chk_TercerSemana.Location = New System.Drawing.Point(6, 42)
        Me.chk_TercerSemana.Name = "chk_TercerSemana"
        Me.chk_TercerSemana.Size = New System.Drawing.Size(105, 17)
        Me.chk_TercerSemana.TabIndex = 1
        Me.chk_TercerSemana.Text = "Tercera Semana"
        Me.chk_TercerSemana.UseVisualStyleBackColor = True
        '
        'chk_SemanaActual
        '
        Me.chk_SemanaActual.AutoSize = True
        Me.chk_SemanaActual.Location = New System.Drawing.Point(6, 19)
        Me.chk_SemanaActual.Name = "chk_SemanaActual"
        Me.chk_SemanaActual.Size = New System.Drawing.Size(98, 17)
        Me.chk_SemanaActual.TabIndex = 0
        Me.chk_SemanaActual.Text = "Semana Actual"
        Me.chk_SemanaActual.UseVisualStyleBackColor = True
        '
        'txt_Filtro
        '
        Me.txt_Filtro.Location = New System.Drawing.Point(365, 85)
        Me.txt_Filtro.Name = "txt_Filtro"
        Me.txt_Filtro.Size = New System.Drawing.Size(538, 20)
        Me.txt_Filtro.TabIndex = 9
        '
        'btn_Cerrar
        '
        Me.btn_Cerrar.Location = New System.Drawing.Point(828, 46)
        Me.btn_Cerrar.Name = "btn_Cerrar"
        Me.btn_Cerrar.Size = New System.Drawing.Size(75, 33)
        Me.btn_Cerrar.TabIndex = 10
        Me.btn_Cerrar.Text = "CERRAR"
        Me.btn_Cerrar.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(365, 63)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(29, 13)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Filtro"
        '
        'txt_TotalPesos
        '
        Me.txt_TotalPesos.BackColor = System.Drawing.Color.Cyan
        Me.txt_TotalPesos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_TotalPesos.Location = New System.Drawing.Point(565, 441)
        Me.txt_TotalPesos.Name = "txt_TotalPesos"
        Me.txt_TotalPesos.ReadOnly = True
        Me.txt_TotalPesos.Size = New System.Drawing.Size(124, 20)
        Me.txt_TotalPesos.TabIndex = 12
        Me.txt_TotalPesos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(496, 444)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(63, 13)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "Total Pesos"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(703, 444)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(70, 13)
        Me.Label5.TabIndex = 15
        Me.Label5.Text = "Total Dolares"
        '
        'txt_TotalDolares
        '
        Me.txt_TotalDolares.BackColor = System.Drawing.Color.Cyan
        Me.txt_TotalDolares.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_TotalDolares.Location = New System.Drawing.Point(779, 441)
        Me.txt_TotalDolares.Name = "txt_TotalDolares"
        Me.txt_TotalDolares.ReadOnly = True
        Me.txt_TotalDolares.Size = New System.Drawing.Size(124, 20)
        Me.txt_TotalDolares.TabIndex = 14
        Me.txt_TotalDolares.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btn_ImprimeListado
        '
        Me.btn_ImprimeListado.Location = New System.Drawing.Point(13, 431)
        Me.btn_ImprimeListado.Name = "btn_ImprimeListado"
        Me.btn_ImprimeListado.Size = New System.Drawing.Size(75, 38)
        Me.btn_ImprimeListado.TabIndex = 16
        Me.btn_ImprimeListado.Text = "IMPRIME LISTADO"
        Me.btn_ImprimeListado.UseVisualStyleBackColor = True
        '
        'DGV_Solicitudes
        '
        Me.DGV_Solicitudes.AllowUserToAddRows = False
        Me.DGV_Solicitudes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_Solicitudes.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.chk, Me.NroSolicitud, Me.Solicitante, Me.Fecha, Me.OrdFecha, Me.Tipo, Me.Destino, Me.Titulo, Me.Moneda, Me.Importe, Me.FechaRequerida, Me.OrdFechaRequerida, Me.Estado})
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(232, Byte), Integer))
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGV_Solicitudes.DefaultCellStyle = DataGridViewCellStyle4
        Me.DGV_Solicitudes.DoubleBuffered = True
        Me.DGV_Solicitudes.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.DGV_Solicitudes.Location = New System.Drawing.Point(12, 111)
        Me.DGV_Solicitudes.Name = "DGV_Solicitudes"
        Me.DGV_Solicitudes.OrdenamientoColumnasHabilitado = True
        Me.DGV_Solicitudes.RowHeadersWidth = 15
        Me.DGV_Solicitudes.RowTemplate.Height = 20
        Me.DGV_Solicitudes.ShowCellToolTips = False
        Me.DGV_Solicitudes.SinClickDerecho = False
        Me.DGV_Solicitudes.Size = New System.Drawing.Size(891, 314)
        Me.DGV_Solicitudes.TabIndex = 8
        '
        'chk
        '
        Me.chk.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.chk.DataPropertyName = "chk"
        Me.chk.FalseValue = "false"
        Me.chk.HeaderText = ""
        Me.chk.Name = "chk"
        Me.chk.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.chk.TrueValue = "true"
        Me.chk.Width = 19
        '
        'NroSolicitud
        '
        Me.NroSolicitud.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.NroSolicitud.DataPropertyName = "NroSolicitud"
        Me.NroSolicitud.HeaderText = "Nro Soli"
        Me.NroSolicitud.Name = "NroSolicitud"
        Me.NroSolicitud.ReadOnly = True
        Me.NroSolicitud.Width = 49
        '
        'Solicitante
        '
        Me.Solicitante.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Solicitante.DataPropertyName = "Solicitante"
        Me.Solicitante.HeaderText = "Solicitante"
        Me.Solicitante.Name = "Solicitante"
        Me.Solicitante.ReadOnly = True
        Me.Solicitante.Width = 81
        '
        'Fecha
        '
        Me.Fecha.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Fecha.DataPropertyName = "Fecha"
        Me.Fecha.HeaderText = "Fecha"
        Me.Fecha.Name = "Fecha"
        Me.Fecha.ReadOnly = True
        Me.Fecha.Width = 62
        '
        'OrdFecha
        '
        Me.OrdFecha.DataPropertyName = "OrdFecha"
        Me.OrdFecha.HeaderText = "OrdFecha"
        Me.OrdFecha.Name = "OrdFecha"
        Me.OrdFecha.ReadOnly = True
        Me.OrdFecha.Visible = False
        '
        'Tipo
        '
        Me.Tipo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Tipo.DataPropertyName = "Tipo"
        Me.Tipo.HeaderText = "Tipo"
        Me.Tipo.Name = "Tipo"
        Me.Tipo.ReadOnly = True
        Me.Tipo.Width = 40
        '
        'Destino
        '
        Me.Destino.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Destino.DataPropertyName = "Destino"
        Me.Destino.HeaderText = "Destino"
        Me.Destino.Name = "Destino"
        Me.Destino.ReadOnly = True
        Me.Destino.Width = 68
        '
        'Titulo
        '
        Me.Titulo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Titulo.DataPropertyName = "Titulo"
        Me.Titulo.HeaderText = "Titulo"
        Me.Titulo.Name = "Titulo"
        Me.Titulo.Width = 58
        '
        'Moneda
        '
        Me.Moneda.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Moneda.DataPropertyName = "Moneda"
        Me.Moneda.HeaderText = "Moneda"
        Me.Moneda.Name = "Moneda"
        Me.Moneda.ReadOnly = True
        Me.Moneda.Width = 71
        '
        'Importe
        '
        Me.Importe.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Importe.DataPropertyName = "Importe"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.Format = "N2"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.Importe.DefaultCellStyle = DataGridViewCellStyle3
        Me.Importe.HeaderText = "Importe"
        Me.Importe.Name = "Importe"
        Me.Importe.ReadOnly = True
        Me.Importe.Width = 67
        '
        'FechaRequerida
        '
        Me.FechaRequerida.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.FechaRequerida.DataPropertyName = "FechaRequerida"
        Me.FechaRequerida.HeaderText = "Fecha Requerida"
        Me.FechaRequerida.Name = "FechaRequerida"
        Me.FechaRequerida.ReadOnly = True
        Me.FechaRequerida.Width = 105
        '
        'OrdFechaRequerida
        '
        Me.OrdFechaRequerida.DataPropertyName = "OrdFechaRequerida"
        Me.OrdFechaRequerida.HeaderText = "OrdFechaRequerida"
        Me.OrdFechaRequerida.Name = "OrdFechaRequerida"
        Me.OrdFechaRequerida.ReadOnly = True
        Me.OrdFechaRequerida.Visible = False
        '
        'Estado
        '
        Me.Estado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Estado.DataPropertyName = "Estado"
        Me.Estado.HeaderText = "Estado"
        Me.Estado.Name = "Estado"
        Me.Estado.ReadOnly = True
        Me.Estado.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Estado.Width = 65
        '
        'btn_Autorizar
        '
        Me.btn_Autorizar.Location = New System.Drawing.Point(115, 431)
        Me.btn_Autorizar.Name = "btn_Autorizar"
        Me.btn_Autorizar.Size = New System.Drawing.Size(82, 38)
        Me.btn_Autorizar.TabIndex = 17
        Me.btn_Autorizar.Text = "AUTORIZAR MARCADOS"
        Me.btn_Autorizar.UseVisualStyleBackColor = True
        '
        'btn_Eliminar
        '
        Me.btn_Eliminar.Location = New System.Drawing.Point(390, 431)
        Me.btn_Eliminar.Name = "btn_Eliminar"
        Me.btn_Eliminar.Size = New System.Drawing.Size(82, 38)
        Me.btn_Eliminar.TabIndex = 18
        Me.btn_Eliminar.Text = "ELIMINAR MARCADOS"
        Me.btn_Eliminar.UseVisualStyleBackColor = True
        '
        'Gestion_Solicitudes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(915, 473)
        Me.Controls.Add(Me.btn_Eliminar)
        Me.Controls.Add(Me.btn_Autorizar)
        Me.Controls.Add(Me.btn_ImprimeListado)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txt_TotalDolares)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txt_TotalPesos)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btn_Cerrar)
        Me.Controls.Add(Me.txt_Filtro)
        Me.Controls.Add(Me.DGV_Solicitudes)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.panel1)
        Me.Name = "Gestion_Solicitudes"
        Me.panel1.ResumeLayout(False)
        Me.panel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DGV_Solicitudes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents panel1 As System.Windows.Forms.Panel
    Private WithEvents Label2 As System.Windows.Forms.Label
    Private WithEvents label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents chk_SinFecha As System.Windows.Forms.CheckBox
    Friend WithEvents chk_CuartaSemana As System.Windows.Forms.CheckBox
    Friend WithEvents chk_SegundaSemana As System.Windows.Forms.CheckBox
    Friend WithEvents chk_TercerSemana As System.Windows.Forms.CheckBox
    Friend WithEvents chk_SemanaActual As System.Windows.Forms.CheckBox
    Friend WithEvents DGV_Solicitudes As Util.DBDataGridView
    Friend WithEvents txt_Filtro As System.Windows.Forms.TextBox
    Friend WithEvents btn_Cerrar As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txt_TotalPesos As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txt_TotalDolares As System.Windows.Forms.TextBox
    Friend WithEvents btn_ImprimeListado As System.Windows.Forms.Button
    Friend WithEvents btn_Autorizar As System.Windows.Forms.Button
    Friend WithEvents chk As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents NroSolicitud As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Solicitante As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Fecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OrdFecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Tipo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Destino As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Titulo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Moneda As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Importe As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FechaRequerida As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OrdFechaRequerida As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Estado As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btn_Eliminar As System.Windows.Forms.Button
End Class
