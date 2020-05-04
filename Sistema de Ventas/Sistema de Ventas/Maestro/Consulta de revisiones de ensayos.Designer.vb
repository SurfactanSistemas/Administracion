<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Consulta_de_revisiones_de_ensayos
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.mastxtOrdenTrabajo = New System.Windows.Forms.MaskedTextBox()
        Me.txtCliente = New System.Windows.Forms.TextBox()
        Me.txtDescripcion = New System.Windows.Forms.TextBox()
        Me.txtObservaciones = New System.Windows.Forms.TextBox()
        Me.txtFecha = New System.Windows.Forms.TextBox()
        Me.txtFechaEntraga = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.DGV_Ensayos = New ConsultasVarias.DBDataGridView()
        Me.Version = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Etapaa = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Participantes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Resultados = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Acciones = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Responsables = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Estado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.btnConsultaOrden = New System.Windows.Forms.Button()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        CType(Me.DGV_Ensayos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(34, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(743, 61)
        Me.Panel1.TabIndex = 1
        '
        'Label6
        '
        Me.Label6.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(576, 32)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(155, 20)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "SURFACTAN S.A."
        '
        'Label7
        '
        Me.Label7.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(12, 11)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(272, 17)
        Me.Label7.TabIndex = 4
        Me.Label7.Text = "Consulta de Revisiones de  Ensayos"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 70)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(90, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Orden de Trabajo"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 96)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Cliente"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 119)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(78, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Observaciones"
        '
        'mastxtOrdenTrabajo
        '
        Me.mastxtOrdenTrabajo.Location = New System.Drawing.Point(105, 67)
        Me.mastxtOrdenTrabajo.Mask = ">LL-00000"
        Me.mastxtOrdenTrabajo.Name = "mastxtOrdenTrabajo"
        Me.mastxtOrdenTrabajo.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.mastxtOrdenTrabajo.Size = New System.Drawing.Size(56, 20)
        Me.mastxtOrdenTrabajo.TabIndex = 5
        '
        'txtCliente
        '
        Me.txtCliente.Location = New System.Drawing.Point(105, 93)
        Me.txtCliente.MaxLength = 6
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.ReadOnly = True
        Me.txtCliente.Size = New System.Drawing.Size(50, 20)
        Me.txtCliente.TabIndex = 6
        '
        'txtDescripcion
        '
        Me.txtDescripcion.Location = New System.Drawing.Point(161, 93)
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.ReadOnly = True
        Me.txtDescripcion.Size = New System.Drawing.Size(218, 20)
        Me.txtDescripcion.TabIndex = 7
        '
        'txtObservaciones
        '
        Me.txtObservaciones.Location = New System.Drawing.Point(104, 116)
        Me.txtObservaciones.Name = "txtObservaciones"
        Me.txtObservaciones.ReadOnly = True
        Me.txtObservaciones.Size = New System.Drawing.Size(275, 20)
        Me.txtObservaciones.TabIndex = 8
        '
        'txtFecha
        '
        Me.txtFecha.Location = New System.Drawing.Point(248, 67)
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.ReadOnly = True
        Me.txtFecha.Size = New System.Drawing.Size(66, 20)
        Me.txtFecha.TabIndex = 9
        '
        'txtFechaEntraga
        '
        Me.txtFechaEntraga.Location = New System.Drawing.Point(443, 67)
        Me.txtFechaEntraga.Name = "txtFechaEntraga"
        Me.txtFechaEntraga.ReadOnly = True
        Me.txtFechaEntraga.Size = New System.Drawing.Size(66, 20)
        Me.txtFechaEntraga.TabIndex = 10
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(205, 70)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(37, 13)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Fecha"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(330, 70)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(107, 13)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "Fecha Comprometida"
        '
        'DGV_Ensayos
        '
        Me.DGV_Ensayos.AllowUserToAddRows = False
        Me.DGV_Ensayos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_Ensayos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Version, Me.Etapaa, Me.Participantes, Me.Resultados, Me.Acciones, Me.Responsables, Me.Estado})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(232, Byte), Integer))
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGV_Ensayos.DefaultCellStyle = DataGridViewCellStyle3
        Me.DGV_Ensayos.DoubleBuffered = True
        Me.DGV_Ensayos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.DGV_Ensayos.Location = New System.Drawing.Point(12, 151)
        Me.DGV_Ensayos.Name = "DGV_Ensayos"
        Me.DGV_Ensayos.OrdenamientoColumnasHabilitado = True
        Me.DGV_Ensayos.RowHeadersWidth = 15
        Me.DGV_Ensayos.RowTemplate.Height = 20
        Me.DGV_Ensayos.ShowCellToolTips = False
        Me.DGV_Ensayos.SinClickDerecho = False
        Me.DGV_Ensayos.Size = New System.Drawing.Size(723, 242)
        Me.DGV_Ensayos.TabIndex = 0
        '
        'Version
        '
        Me.Version.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Version.HeaderText = "Version"
        Me.Version.Name = "Version"
        Me.Version.Width = 67
        '
        'Etapaa
        '
        Me.Etapaa.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Etapaa.HeaderText = "Etapa"
        Me.Etapaa.Name = "Etapaa"
        Me.Etapaa.Width = 60
        '
        'Participantes
        '
        Me.Participantes.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Participantes.HeaderText = "Participantes"
        Me.Participantes.Name = "Participantes"
        Me.Participantes.Width = 93
        '
        'Resultados
        '
        Me.Resultados.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Resultados.HeaderText = "Resultados"
        Me.Resultados.Name = "Resultados"
        Me.Resultados.Width = 85
        '
        'Acciones
        '
        Me.Acciones.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Acciones.HeaderText = "Acciones"
        Me.Acciones.Name = "Acciones"
        Me.Acciones.Width = 76
        '
        'Responsables
        '
        Me.Responsables.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Responsables.HeaderText = "Responsables"
        Me.Responsables.Name = "Responsables"
        Me.Responsables.Width = 99
        '
        'Estado
        '
        Me.Estado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Estado.HeaderText = "Estado"
        Me.Estado.Name = "Estado"
        Me.Estado.Width = 65
        '
        'btnCerrar
        '
        Me.btnCerrar.Location = New System.Drawing.Point(638, 67)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(97, 35)
        Me.btnCerrar.TabIndex = 13
        Me.btnCerrar.Text = "CERRAR"
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'btnConsultaOrden
        '
        Me.btnConsultaOrden.Location = New System.Drawing.Point(525, 67)
        Me.btnConsultaOrden.Name = "btnConsultaOrden"
        Me.btnConsultaOrden.Size = New System.Drawing.Size(107, 35)
        Me.btnConsultaOrden.TabIndex = 14
        Me.btnConsultaOrden.Text = "CONSULTA ORDEN"
        Me.btnConsultaOrden.UseVisualStyleBackColor = True
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Location = New System.Drawing.Point(525, 108)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(107, 35)
        Me.btnLimpiar.TabIndex = 15
        Me.btnLimpiar.Text = "LIMPIAR"
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'Consulta_de_revisiones_de_ensayos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(743, 402)
        Me.Controls.Add(Me.btnLimpiar)
        Me.Controls.Add(Me.btnConsultaOrden)
        Me.Controls.Add(Me.btnCerrar)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtFechaEntraga)
        Me.Controls.Add(Me.txtFecha)
        Me.Controls.Add(Me.txtObservaciones)
        Me.Controls.Add(Me.txtDescripcion)
        Me.Controls.Add(Me.txtCliente)
        Me.Controls.Add(Me.mastxtOrdenTrabajo)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.DGV_Ensayos)
        Me.Location = New System.Drawing.Point(20, 20)
        Me.Name = "Consulta_de_revisiones_de_ensayos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.DGV_Ensayos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DGV_Ensayos As ConsultasVarias.DBDataGridView
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Private WithEvents Label6 As System.Windows.Forms.Label
    Private WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents mastxtOrdenTrabajo As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtCliente As System.Windows.Forms.TextBox
    Friend WithEvents txtDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents txtObservaciones As System.Windows.Forms.TextBox
    Friend WithEvents txtFecha As System.Windows.Forms.TextBox
    Friend WithEvents txtFechaEntraga As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Version As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Etapaa As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Participantes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Resultados As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Acciones As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Responsables As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Estado As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents btnConsultaOrden As System.Windows.Forms.Button
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
End Class
