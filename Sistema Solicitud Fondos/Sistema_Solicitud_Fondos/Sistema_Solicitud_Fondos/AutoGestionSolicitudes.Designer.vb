<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AutoGestionSolicitudes
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btn_Cerrar = New System.Windows.Forms.Button()
        Me.txt_Filtro = New System.Windows.Forms.TextBox()
        Me.DGV_Solicitudes = New Util.DBDataGridView()
        Me.btn_ImprimeListado = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txt_TotalDolares = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txt_TotalPesos = New System.Windows.Forms.TextBox()
        Me.chk_Rechazados = New System.Windows.Forms.CheckBox()
        Me.btn_EliminarSolicitud = New System.Windows.Forms.Button()
        Me.txt_Fecha_Desde = New System.Windows.Forms.MaskedTextBox()
        Me.txt_Fecha_Hasta = New System.Windows.Forms.MaskedTextBox()
        Me.lbl_Desde = New System.Windows.Forms.Label()
        Me.lbl_Hasta = New System.Windows.Forms.Label()
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
        Me.OrdenPago = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.panel1.SuspendLayout()
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
        Me.panel1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.panel1.Name = "panel1"
        Me.panel1.Size = New System.Drawing.Size(1467, 49)
        Me.panel1.TabIndex = 7
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(1232, 12)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(192, 25)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "SURFACTAN S.A."
        '
        'label1
        '
        Me.label1.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.label1.AutoSize = True
        Me.label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold)
        Me.label1.ForeColor = System.Drawing.Color.White
        Me.label1.Location = New System.Drawing.Point(28, 15)
        Me.label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(300, 20)
        Me.label1.TabIndex = 0
        Me.label1.Text = "AUTOGESTION DE SOLICITUDES"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(11, 54)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(39, 17)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "Filtro"
        '
        'btn_Cerrar
        '
        Me.btn_Cerrar.Location = New System.Drawing.Point(1361, 53)
        Me.btn_Cerrar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btn_Cerrar.Name = "btn_Cerrar"
        Me.btn_Cerrar.Size = New System.Drawing.Size(100, 41)
        Me.btn_Cerrar.TabIndex = 14
        Me.btn_Cerrar.Text = "CERRAR"
        Me.btn_Cerrar.UseVisualStyleBackColor = True
        '
        'txt_Filtro
        '
        Me.txt_Filtro.Location = New System.Drawing.Point(9, 78)
        Me.txt_Filtro.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txt_Filtro.Name = "txt_Filtro"
        Me.txt_Filtro.Size = New System.Drawing.Size(565, 22)
        Me.txt_Filtro.TabIndex = 13
        '
        'DGV_Solicitudes
        '
        Me.DGV_Solicitudes.AllowUserToAddRows = False
        Me.DGV_Solicitudes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_Solicitudes.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.NroSolicitud, Me.Solicitante, Me.Fecha, Me.OrdFecha, Me.Tipo, Me.Destino, Me.Titulo, Me.Moneda, Me.Importe, Me.FechaRequerida, Me.OrdFechaRequerida, Me.Estado, Me.OrdenPago})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(232, Byte), Integer))
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGV_Solicitudes.DefaultCellStyle = DataGridViewCellStyle3
        Me.DGV_Solicitudes.DoubleBuffered = True
        Me.DGV_Solicitudes.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.DGV_Solicitudes.Location = New System.Drawing.Point(9, 110)
        Me.DGV_Solicitudes.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.DGV_Solicitudes.Name = "DGV_Solicitudes"
        Me.DGV_Solicitudes.OrdenamientoColumnasHabilitado = True
        Me.DGV_Solicitudes.RowHeadersWidth = 15
        Me.DGV_Solicitudes.RowTemplate.Height = 20
        Me.DGV_Solicitudes.ShowCellToolTips = False
        Me.DGV_Solicitudes.SinClickDerecho = False
        Me.DGV_Solicitudes.Size = New System.Drawing.Size(1452, 353)
        Me.DGV_Solicitudes.TabIndex = 12
        '
        'btn_ImprimeListado
        '
        Me.btn_ImprimeListado.Location = New System.Drawing.Point(28, 468)
        Me.btn_ImprimeListado.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btn_ImprimeListado.Name = "btn_ImprimeListado"
        Me.btn_ImprimeListado.Size = New System.Drawing.Size(100, 47)
        Me.btn_ImprimeListado.TabIndex = 21
        Me.btn_ImprimeListado.Text = "IMPRIME LISTADO"
        Me.btn_ImprimeListado.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(1196, 483)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(93, 17)
        Me.Label5.TabIndex = 20
        Me.Label5.Text = "Total Dolares"
        '
        'txt_TotalDolares
        '
        Me.txt_TotalDolares.BackColor = System.Drawing.Color.Cyan
        Me.txt_TotalDolares.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_TotalDolares.Location = New System.Drawing.Point(1297, 479)
        Me.txt_TotalDolares.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txt_TotalDolares.Name = "txt_TotalDolares"
        Me.txt_TotalDolares.ReadOnly = True
        Me.txt_TotalDolares.Size = New System.Drawing.Size(164, 23)
        Me.txt_TotalDolares.TabIndex = 19
        Me.txt_TotalDolares.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(920, 483)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(83, 17)
        Me.Label4.TabIndex = 18
        Me.Label4.Text = "Total Pesos"
        '
        'txt_TotalPesos
        '
        Me.txt_TotalPesos.BackColor = System.Drawing.Color.Cyan
        Me.txt_TotalPesos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_TotalPesos.Location = New System.Drawing.Point(1012, 479)
        Me.txt_TotalPesos.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txt_TotalPesos.Name = "txt_TotalPesos"
        Me.txt_TotalPesos.ReadOnly = True
        Me.txt_TotalPesos.Size = New System.Drawing.Size(164, 23)
        Me.txt_TotalPesos.TabIndex = 17
        Me.txt_TotalPesos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'chk_Rechazados
        '
        Me.chk_Rechazados.AutoSize = True
        Me.chk_Rechazados.Location = New System.Drawing.Point(585, 74)
        Me.chk_Rechazados.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.chk_Rechazados.Name = "chk_Rechazados"
        Me.chk_Rechazados.Size = New System.Drawing.Size(126, 21)
        Me.chk_Rechazados.TabIndex = 22
        Me.chk_Rechazados.Text = "Incluir Historico"
        Me.chk_Rechazados.UseVisualStyleBackColor = True
        '
        'btn_EliminarSolicitud
        '
        Me.btn_EliminarSolicitud.Location = New System.Drawing.Point(812, 468)
        Me.btn_EliminarSolicitud.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btn_EliminarSolicitud.Name = "btn_EliminarSolicitud"
        Me.btn_EliminarSolicitud.Size = New System.Drawing.Size(100, 47)
        Me.btn_EliminarSolicitud.TabIndex = 23
        Me.btn_EliminarSolicitud.Text = "ELIMINAR SOLICITUD"
        Me.btn_EliminarSolicitud.UseVisualStyleBackColor = True
        '
        'txt_Fecha_Desde
        '
        Me.txt_Fecha_Desde.Location = New System.Drawing.Point(757, 74)
        Me.txt_Fecha_Desde.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txt_Fecha_Desde.Mask = "00/00/0000"
        Me.txt_Fecha_Desde.Name = "txt_Fecha_Desde"
        Me.txt_Fecha_Desde.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txt_Fecha_Desde.Size = New System.Drawing.Size(85, 22)
        Me.txt_Fecha_Desde.TabIndex = 24
        Me.txt_Fecha_Desde.Visible = False
        '
        'txt_Fecha_Hasta
        '
        Me.txt_Fecha_Hasta.Location = New System.Drawing.Point(852, 73)
        Me.txt_Fecha_Hasta.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txt_Fecha_Hasta.Mask = "00/00/0000"
        Me.txt_Fecha_Hasta.Name = "txt_Fecha_Hasta"
        Me.txt_Fecha_Hasta.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txt_Fecha_Hasta.Size = New System.Drawing.Size(85, 22)
        Me.txt_Fecha_Hasta.TabIndex = 25
        Me.txt_Fecha_Hasta.Visible = False
        '
        'lbl_Desde
        '
        Me.lbl_Desde.AutoSize = True
        Me.lbl_Desde.Location = New System.Drawing.Point(757, 53)
        Me.lbl_Desde.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_Desde.Name = "lbl_Desde"
        Me.lbl_Desde.Size = New System.Drawing.Size(49, 17)
        Me.lbl_Desde.TabIndex = 26
        Me.lbl_Desde.Text = "Desde"
        Me.lbl_Desde.Visible = False
        '
        'lbl_Hasta
        '
        Me.lbl_Hasta.AutoSize = True
        Me.lbl_Hasta.Location = New System.Drawing.Point(848, 53)
        Me.lbl_Hasta.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_Hasta.Name = "lbl_Hasta"
        Me.lbl_Hasta.Size = New System.Drawing.Size(45, 17)
        Me.lbl_Hasta.TabIndex = 27
        Me.lbl_Hasta.Text = "Hasta"
        Me.lbl_Hasta.Visible = False
        '
        'NroSolicitud
        '
        Me.NroSolicitud.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.NroSolicitud.DataPropertyName = "NroSolicitud"
        Me.NroSolicitud.HeaderText = "Nro Soli"
        Me.NroSolicitud.Name = "NroSolicitud"
        Me.NroSolicitud.ReadOnly = True
        Me.NroSolicitud.Width = 87
        '
        'Solicitante
        '
        Me.Solicitante.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Solicitante.DataPropertyName = "Solicitante"
        Me.Solicitante.HeaderText = "Solicitante"
        Me.Solicitante.Name = "Solicitante"
        Me.Solicitante.ReadOnly = True
        Me.Solicitante.Width = 102
        '
        'Fecha
        '
        Me.Fecha.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Fecha.DataPropertyName = "Fecha"
        Me.Fecha.HeaderText = "Fecha"
        Me.Fecha.Name = "Fecha"
        Me.Fecha.ReadOnly = True
        Me.Fecha.Width = 76
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
        Me.Tipo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Tipo.DataPropertyName = "Tipo"
        Me.Tipo.HeaderText = "Tipo"
        Me.Tipo.Name = "Tipo"
        Me.Tipo.ReadOnly = True
        Me.Tipo.Width = 65
        '
        'Destino
        '
        Me.Destino.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Destino.DataPropertyName = "Destino"
        Me.Destino.HeaderText = "Destino"
        Me.Destino.Name = "Destino"
        Me.Destino.ReadOnly = True
        Me.Destino.Width = 85
        '
        'Titulo
        '
        Me.Titulo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Titulo.DataPropertyName = "Titulo"
        Me.Titulo.HeaderText = "Titulo"
        Me.Titulo.Name = "Titulo"
        Me.Titulo.Width = 72
        '
        'Moneda
        '
        Me.Moneda.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Moneda.DataPropertyName = "Moneda"
        Me.Moneda.HeaderText = "Moneda"
        Me.Moneda.Name = "Moneda"
        Me.Moneda.ReadOnly = True
        Me.Moneda.Width = 88
        '
        'Importe
        '
        Me.Importe.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Importe.DataPropertyName = "Importe"
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle1.Format = "N2"
        DataGridViewCellStyle1.NullValue = Nothing
        Me.Importe.DefaultCellStyle = DataGridViewCellStyle1
        Me.Importe.HeaderText = "Importe"
        Me.Importe.Name = "Importe"
        Me.Importe.ReadOnly = True
        Me.Importe.Width = 84
        '
        'FechaRequerida
        '
        Me.FechaRequerida.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.FechaRequerida.DataPropertyName = "FechaRequerida"
        Me.FechaRequerida.HeaderText = "Fecha Requerida"
        Me.FechaRequerida.Name = "FechaRequerida"
        Me.FechaRequerida.ReadOnly = True
        Me.FechaRequerida.Width = 134
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
        Me.Estado.DataPropertyName = "Estado"
        Me.Estado.HeaderText = "Estado"
        Me.Estado.Name = "Estado"
        '
        'OrdenPago
        '
        Me.OrdenPago.DataPropertyName = "OrdenPago"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.OrdenPago.DefaultCellStyle = DataGridViewCellStyle2
        Me.OrdenPago.HeaderText = "Nro. Orden"
        Me.OrdenPago.Name = "OrdenPago"
        Me.OrdenPago.Width = 60
        '
        'AutoGestionSolicitudes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1467, 518)
        Me.Controls.Add(Me.lbl_Hasta)
        Me.Controls.Add(Me.lbl_Desde)
        Me.Controls.Add(Me.txt_Fecha_Hasta)
        Me.Controls.Add(Me.txt_Fecha_Desde)
        Me.Controls.Add(Me.btn_EliminarSolicitud)
        Me.Controls.Add(Me.chk_Rechazados)
        Me.Controls.Add(Me.btn_ImprimeListado)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txt_TotalDolares)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txt_TotalPesos)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btn_Cerrar)
        Me.Controls.Add(Me.txt_Filtro)
        Me.Controls.Add(Me.DGV_Solicitudes)
        Me.Controls.Add(Me.panel1)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "AutoGestionSolicitudes"
        Me.panel1.ResumeLayout(False)
        Me.panel1.PerformLayout()
        CType(Me.DGV_Solicitudes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents panel1 As System.Windows.Forms.Panel
    Private WithEvents Label2 As System.Windows.Forms.Label
    Private WithEvents label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btn_Cerrar As System.Windows.Forms.Button
    Friend WithEvents txt_Filtro As System.Windows.Forms.TextBox
    Friend WithEvents DGV_Solicitudes As Util.DBDataGridView
    Friend WithEvents btn_ImprimeListado As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txt_TotalDolares As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txt_TotalPesos As System.Windows.Forms.TextBox
    Friend WithEvents chk_Rechazados As System.Windows.Forms.CheckBox
    Friend WithEvents btn_EliminarSolicitud As System.Windows.Forms.Button
    Friend WithEvents txt_Fecha_Desde As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txt_Fecha_Hasta As System.Windows.Forms.MaskedTextBox
    Friend WithEvents lbl_Desde As System.Windows.Forms.Label
    Friend WithEvents lbl_Hasta As System.Windows.Forms.Label
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
    Friend WithEvents OrdenPago As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
