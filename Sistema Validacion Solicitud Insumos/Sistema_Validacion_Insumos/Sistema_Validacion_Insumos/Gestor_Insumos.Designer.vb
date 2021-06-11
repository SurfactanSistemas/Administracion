<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Gestor_Insumos
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.label1 = New System.Windows.Forms.Label()
        Me.dgv_SolicitudesInsumos = New Util.DBDataGridView()
        Me.btn_Cerrar = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txt_Filtro = New System.Windows.Forms.TextBox()
        Me.Chk_IncluyeRechazadas = New System.Windows.Forms.CheckBox()
        Me.Chk_IncluyeAprobados = New System.Windows.Forms.CheckBox()
        Me.Nro_Insumo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Fecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Solicitante = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Observaciones = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Planta = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EstadoPedido = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.panel1.SuspendLayout()
        CType(Me.dgv_SolicitudesInsumos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'panel1
        '
        Me.panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(34, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.panel1.Controls.Add(Me.Label2)
        Me.panel1.Controls.Add(Me.label1)
        Me.panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.panel1.Location = New System.Drawing.Point(0, 0)
        Me.panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.panel1.Name = "panel1"
        Me.panel1.Size = New System.Drawing.Size(1070, 49)
        Me.panel1.TabIndex = 9
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(836, 12)
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
        Me.label1.Location = New System.Drawing.Point(4, 12)
        Me.label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(142, 20)
        Me.label1.TabIndex = 0
        Me.label1.Text = "Gestor Insumos"
        '
        'dgv_SolicitudesInsumos
        '
        Me.dgv_SolicitudesInsumos.AllowUserToAddRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_SolicitudesInsumos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgv_SolicitudesInsumos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_SolicitudesInsumos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Nro_Insumo, Me.Fecha, Me.Solicitante, Me.Observaciones, Me.Planta, Me.EstadoPedido})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(232, Byte), Integer))
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv_SolicitudesInsumos.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgv_SolicitudesInsumos.DoubleBuffered = True
        Me.dgv_SolicitudesInsumos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dgv_SolicitudesInsumos.Location = New System.Drawing.Point(8, 110)
        Me.dgv_SolicitudesInsumos.Margin = New System.Windows.Forms.Padding(4)
        Me.dgv_SolicitudesInsumos.Name = "dgv_SolicitudesInsumos"
        Me.dgv_SolicitudesInsumos.OrdenamientoColumnasHabilitado = True
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_SolicitudesInsumos.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgv_SolicitudesInsumos.RowHeadersWidth = 15
        Me.dgv_SolicitudesInsumos.RowTemplate.Height = 20
        Me.dgv_SolicitudesInsumos.ShowCellToolTips = False
        Me.dgv_SolicitudesInsumos.SinClickDerecho = False
        Me.dgv_SolicitudesInsumos.Size = New System.Drawing.Size(1049, 447)
        Me.dgv_SolicitudesInsumos.TabIndex = 10
        '
        'btn_Cerrar
        '
        Me.btn_Cerrar.Location = New System.Drawing.Point(945, 56)
        Me.btn_Cerrar.Name = "btn_Cerrar"
        Me.btn_Cerrar.Size = New System.Drawing.Size(112, 49)
        Me.btn_Cerrar.TabIndex = 11
        Me.btn_Cerrar.Text = "CERRAR"
        Me.btn_Cerrar.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(5, 56)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(39, 17)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "Filtro"
        '
        'txt_Filtro
        '
        Me.txt_Filtro.Location = New System.Drawing.Point(8, 81)
        Me.txt_Filtro.Name = "txt_Filtro"
        Me.txt_Filtro.Size = New System.Drawing.Size(476, 22)
        Me.txt_Filtro.TabIndex = 13
        '
        'Chk_IncluyeRechazadas
        '
        Me.Chk_IncluyeRechazadas.AutoSize = True
        Me.Chk_IncluyeRechazadas.Location = New System.Drawing.Point(491, 57)
        Me.Chk_IncluyeRechazadas.Name = "Chk_IncluyeRechazadas"
        Me.Chk_IncluyeRechazadas.Size = New System.Drawing.Size(150, 21)
        Me.Chk_IncluyeRechazadas.TabIndex = 14
        Me.Chk_IncluyeRechazadas.Text = "Incluir Rechazados"
        Me.Chk_IncluyeRechazadas.UseVisualStyleBackColor = True
        '
        'Chk_IncluyeAprobados
        '
        Me.Chk_IncluyeAprobados.AutoSize = True
        Me.Chk_IncluyeAprobados.Location = New System.Drawing.Point(491, 81)
        Me.Chk_IncluyeAprobados.Name = "Chk_IncluyeAprobados"
        Me.Chk_IncluyeAprobados.Size = New System.Drawing.Size(140, 21)
        Me.Chk_IncluyeAprobados.TabIndex = 15
        Me.Chk_IncluyeAprobados.Text = "Incluir Aprobados"
        Me.Chk_IncluyeAprobados.UseVisualStyleBackColor = True
        '
        'Nro_Insumo
        '
        Me.Nro_Insumo.DataPropertyName = "Solicitud"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.NullValue = Nothing
        Me.Nro_Insumo.DefaultCellStyle = DataGridViewCellStyle2
        Me.Nro_Insumo.HeaderText = "Nro. Soli."
        Me.Nro_Insumo.Name = "Nro_Insumo"
        Me.Nro_Insumo.ReadOnly = True
        Me.Nro_Insumo.Width = 50
        '
        'Fecha
        '
        Me.Fecha.DataPropertyName = "Fecha"
        Me.Fecha.HeaderText = "Fecha"
        Me.Fecha.Name = "Fecha"
        Me.Fecha.ReadOnly = True
        Me.Fecha.Width = 70
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
        'Observaciones
        '
        Me.Observaciones.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Observaciones.DataPropertyName = "Observaciones"
        Me.Observaciones.HeaderText = "Observaciones"
        Me.Observaciones.Name = "Observaciones"
        Me.Observaciones.ReadOnly = True
        '
        'Planta
        '
        Me.Planta.DataPropertyName = "Planta"
        Me.Planta.HeaderText = "Planta"
        Me.Planta.Name = "Planta"
        Me.Planta.ReadOnly = True
        Me.Planta.Width = 50
        '
        'EstadoPedido
        '
        Me.EstadoPedido.DataPropertyName = "EstadoPedido"
        Me.EstadoPedido.HeaderText = "EstadoPedido"
        Me.EstadoPedido.Name = "EstadoPedido"
        Me.EstadoPedido.ReadOnly = True
        Me.EstadoPedido.Visible = False
        '
        'Gestor_Insumos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1070, 570)
        Me.Controls.Add(Me.Chk_IncluyeAprobados)
        Me.Controls.Add(Me.Chk_IncluyeRechazadas)
        Me.Controls.Add(Me.txt_Filtro)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btn_Cerrar)
        Me.Controls.Add(Me.dgv_SolicitudesInsumos)
        Me.Controls.Add(Me.panel1)
        Me.Name = "Gestor_Insumos"
        Me.panel1.ResumeLayout(False)
        Me.panel1.PerformLayout()
        CType(Me.dgv_SolicitudesInsumos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents panel1 As System.Windows.Forms.Panel
    Private WithEvents Label2 As System.Windows.Forms.Label
    Private WithEvents label1 As System.Windows.Forms.Label
    Friend WithEvents dgv_SolicitudesInsumos As Util.DBDataGridView
    Friend WithEvents btn_Cerrar As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txt_Filtro As System.Windows.Forms.TextBox
    Friend WithEvents Chk_IncluyeRechazadas As System.Windows.Forms.CheckBox
    Friend WithEvents Chk_IncluyeAprobados As System.Windows.Forms.CheckBox
    Friend WithEvents Nro_Insumo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Fecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Solicitante As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Observaciones As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Planta As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EstadoPedido As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
