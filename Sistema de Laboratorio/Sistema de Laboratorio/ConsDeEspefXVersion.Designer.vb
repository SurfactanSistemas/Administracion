<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ConsDeEspefXVersion
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
        Me.mastxtCodigo = New System.Windows.Forms.MaskedTextBox()
        Me.txtVersion = New System.Windows.Forms.TextBox()
        Me.txtFechaDesde = New System.Windows.Forms.TextBox()
        Me.txtFechaHasta = New System.Windows.Forms.TextBox()
        Me.btnAnteriorVersion = New System.Windows.Forms.Button()
        Me.btnSiguienteVersion = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.btnImprimir = New System.Windows.Forms.Button()
        Me.btnVolver = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtControlDeCambios = New System.Windows.Forms.TextBox()
        Me.DGV_ConsultaVersiones = New ConsultasVarias.DBDataGridView()
        Me.Ensayo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ValorEstandar = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Desde = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Hasta = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        CType(Me.DGV_ConsultaVersiones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'mastxtCodigo
        '
        Me.mastxtCodigo.Location = New System.Drawing.Point(62, 54)
        Me.mastxtCodigo.Mask = ">LL-00000-000"
        Me.mastxtCodigo.Name = "mastxtCodigo"
        Me.mastxtCodigo.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.mastxtCodigo.Size = New System.Drawing.Size(82, 20)
        Me.mastxtCodigo.TabIndex = 0
        Me.mastxtCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtVersion
        '
        Me.txtVersion.Location = New System.Drawing.Point(263, 54)
        Me.txtVersion.Name = "txtVersion"
        Me.txtVersion.Size = New System.Drawing.Size(57, 20)
        Me.txtVersion.TabIndex = 1
        '
        'txtFechaDesde
        '
        Me.txtFechaDesde.BackColor = System.Drawing.Color.Cyan
        Me.txtFechaDesde.Enabled = False
        Me.txtFechaDesde.Location = New System.Drawing.Point(602, 54)
        Me.txtFechaDesde.Name = "txtFechaDesde"
        Me.txtFechaDesde.Size = New System.Drawing.Size(79, 20)
        Me.txtFechaDesde.TabIndex = 2
        '
        'txtFechaHasta
        '
        Me.txtFechaHasta.BackColor = System.Drawing.Color.Cyan
        Me.txtFechaHasta.Enabled = False
        Me.txtFechaHasta.Location = New System.Drawing.Point(687, 54)
        Me.txtFechaHasta.Name = "txtFechaHasta"
        Me.txtFechaHasta.Size = New System.Drawing.Size(79, 20)
        Me.txtFechaHasta.TabIndex = 3
        '
        'btnAnteriorVersion
        '
        Me.btnAnteriorVersion.Location = New System.Drawing.Point(337, 52)
        Me.btnAnteriorVersion.Name = "btnAnteriorVersion"
        Me.btnAnteriorVersion.Size = New System.Drawing.Size(59, 22)
        Me.btnAnteriorVersion.TabIndex = 4
        Me.btnAnteriorVersion.Text = "Anterior"
        Me.btnAnteriorVersion.UseVisualStyleBackColor = True
        '
        'btnSiguienteVersion
        '
        Me.btnSiguienteVersion.Location = New System.Drawing.Point(402, 52)
        Me.btnSiguienteVersion.Name = "btnSiguienteVersion"
        Me.btnSiguienteVersion.Size = New System.Drawing.Size(59, 22)
        Me.btnSiguienteVersion.TabIndex = 5
        Me.btnSiguienteVersion.Text = "Siguiente"
        Me.btnSiguienteVersion.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(19, 57)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Codigo"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(212, 57)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Version"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(559, 57)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(37, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Fecha"
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Location = New System.Drawing.Point(532, 388)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(75, 23)
        Me.btnLimpiar.TabIndex = 9
        Me.btnLimpiar.Text = "Limpiar"
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'btnImprimir
        '
        Me.btnImprimir.Location = New System.Drawing.Point(641, 388)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(75, 23)
        Me.btnImprimir.TabIndex = 10
        Me.btnImprimir.Text = "Imprimir"
        Me.btnImprimir.UseVisualStyleBackColor = True
        '
        'btnVolver
        '
        Me.btnVolver.Location = New System.Drawing.Point(745, 388)
        Me.btnVolver.Name = "btnVolver"
        Me.btnVolver.Size = New System.Drawing.Size(75, 23)
        Me.btnVolver.TabIndex = 11
        Me.btnVolver.Text = "Volver"
        Me.btnVolver.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(15, 393)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(98, 13)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Control de Cambios"
        '
        'txtControlDeCambios
        '
        Me.txtControlDeCambios.BackColor = System.Drawing.Color.Cyan
        Me.txtControlDeCambios.Enabled = False
        Me.txtControlDeCambios.Location = New System.Drawing.Point(117, 390)
        Me.txtControlDeCambios.Name = "txtControlDeCambios"
        Me.txtControlDeCambios.Size = New System.Drawing.Size(386, 20)
        Me.txtControlDeCambios.TabIndex = 13
        '
        'DGV_ConsultaVersiones
        '
        Me.DGV_ConsultaVersiones.AllowUserToAddRows = False
        Me.DGV_ConsultaVersiones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_ConsultaVersiones.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Ensayo, Me.Descripcion, Me.ValorEstandar, Me.Desde, Me.Hasta})
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(232, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGV_ConsultaVersiones.DefaultCellStyle = DataGridViewCellStyle1
        Me.DGV_ConsultaVersiones.DoubleBuffered = True
        Me.DGV_ConsultaVersiones.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.DGV_ConsultaVersiones.Location = New System.Drawing.Point(13, 83)
        Me.DGV_ConsultaVersiones.Name = "DGV_ConsultaVersiones"
        Me.DGV_ConsultaVersiones.OrdenamientoColumnasHabilitado = True
        Me.DGV_ConsultaVersiones.RowHeadersWidth = 15
        Me.DGV_ConsultaVersiones.RowTemplate.Height = 20
        Me.DGV_ConsultaVersiones.ShowCellToolTips = False
        Me.DGV_ConsultaVersiones.SinClickDerecho = False
        Me.DGV_ConsultaVersiones.Size = New System.Drawing.Size(812, 299)
        Me.DGV_ConsultaVersiones.TabIndex = 14
        '
        'Ensayo
        '
        Me.Ensayo.DataPropertyName = "Ensayo"
        Me.Ensayo.HeaderText = "Ensayo"
        Me.Ensayo.Name = "Ensayo"
        '
        'Descripcion
        '
        Me.Descripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Descripcion.DataPropertyName = "Descripcion"
        Me.Descripcion.HeaderText = "Descripcion"
        Me.Descripcion.Name = "Descripcion"
        Me.Descripcion.Width = 88
        '
        'ValorEstandar
        '
        Me.ValorEstandar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.ValorEstandar.DataPropertyName = "ValorEstandar"
        Me.ValorEstandar.HeaderText = "Valor Estandar"
        Me.ValorEstandar.Name = "ValorEstandar"
        Me.ValorEstandar.Width = 101
        '
        'Desde
        '
        Me.Desde.DataPropertyName = "Desde"
        Me.Desde.HeaderText = "Desde"
        Me.Desde.Name = "Desde"
        '
        'Hasta
        '
        Me.Hasta.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Hasta.DataPropertyName = "Hasta"
        Me.Hasta.HeaderText = "Hasta"
        Me.Hasta.Name = "Hasta"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Location = New System.Drawing.Point(-5, -5)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(952, 53)
        Me.Panel1.TabIndex = 15
        '
        'Label6
        '
        Me.Label6.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.Control
        Me.Label6.Location = New System.Drawing.Point(14, 14)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(342, 20)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "Consulta de Especificaciones por Version"
        '
        'Label5
        '
        Me.Label5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.Control
        Me.Label5.Location = New System.Drawing.Point(651, 14)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(179, 24)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "SURFACTAN S.A."
        '
        'ConsDeEspefXVersion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(832, 418)
        Me.Controls.Add(Me.DGV_ConsultaVersiones)
        Me.Controls.Add(Me.txtControlDeCambios)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.btnVolver)
        Me.Controls.Add(Me.btnImprimir)
        Me.Controls.Add(Me.btnLimpiar)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnSiguienteVersion)
        Me.Controls.Add(Me.btnAnteriorVersion)
        Me.Controls.Add(Me.txtFechaHasta)
        Me.Controls.Add(Me.txtFechaDesde)
        Me.Controls.Add(Me.txtVersion)
        Me.Controls.Add(Me.mastxtCodigo)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "ConsDeEspefXVersion"
        Me.Text = "ConsDeEspefXVersion"
        CType(Me.DGV_ConsultaVersiones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents mastxtCodigo As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtVersion As System.Windows.Forms.TextBox
    Friend WithEvents txtFechaDesde As System.Windows.Forms.TextBox
    Friend WithEvents txtFechaHasta As System.Windows.Forms.TextBox
    Friend WithEvents btnAnteriorVersion As System.Windows.Forms.Button
    Friend WithEvents btnSiguienteVersion As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents btnImprimir As System.Windows.Forms.Button
    Friend WithEvents btnVolver As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtControlDeCambios As System.Windows.Forms.TextBox
    Friend WithEvents DGV_ConsultaVersiones As ConsultasVarias.DBDataGridView
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Ensayo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Descripcion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ValorEstandar As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Desde As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Hasta As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
