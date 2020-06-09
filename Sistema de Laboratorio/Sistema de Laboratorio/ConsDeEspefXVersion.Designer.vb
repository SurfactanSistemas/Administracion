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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
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
        Me.DGV_ConsultaVersiones = New Util.DBDataGridView()
        Me.Ensayo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ValorEstandar = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Desde = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Hasta = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtDescTerminado = New System.Windows.Forms.TextBox()
        CType(Me.DGV_ConsultaVersiones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'mastxtCodigo
        '
        Me.mastxtCodigo.Location = New System.Drawing.Point(88, 54)
        Me.mastxtCodigo.Mask = ">LL-00000-000"
        Me.mastxtCodigo.Name = "mastxtCodigo"
        Me.mastxtCodigo.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.mastxtCodigo.Size = New System.Drawing.Size(78, 20)
        Me.mastxtCodigo.TabIndex = 0
        Me.mastxtCodigo.Text = "PT99999999"
        Me.mastxtCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtVersion
        '
        Me.txtVersion.Location = New System.Drawing.Point(88, 82)
        Me.txtVersion.MaxLength = 2
        Me.txtVersion.Name = "txtVersion"
        Me.txtVersion.Size = New System.Drawing.Size(57, 20)
        Me.txtVersion.TabIndex = 1
        '
        'txtFechaDesde
        '
        Me.txtFechaDesde.BackColor = System.Drawing.Color.Cyan
        Me.txtFechaDesde.Enabled = False
        Me.txtFechaDesde.Location = New System.Drawing.Point(423, 82)
        Me.txtFechaDesde.Name = "txtFechaDesde"
        Me.txtFechaDesde.Size = New System.Drawing.Size(79, 20)
        Me.txtFechaDesde.TabIndex = 2
        '
        'txtFechaHasta
        '
        Me.txtFechaHasta.BackColor = System.Drawing.Color.Cyan
        Me.txtFechaHasta.Enabled = False
        Me.txtFechaHasta.Location = New System.Drawing.Point(513, 82)
        Me.txtFechaHasta.Name = "txtFechaHasta"
        Me.txtFechaHasta.Size = New System.Drawing.Size(79, 20)
        Me.txtFechaHasta.TabIndex = 3
        '
        'btnAnteriorVersion
        '
        Me.btnAnteriorVersion.Location = New System.Drawing.Point(171, 79)
        Me.btnAnteriorVersion.Name = "btnAnteriorVersion"
        Me.btnAnteriorVersion.Size = New System.Drawing.Size(97, 27)
        Me.btnAnteriorVersion.TabIndex = 4
        Me.btnAnteriorVersion.Text = "ANTERIOR"
        Me.btnAnteriorVersion.UseVisualStyleBackColor = True
        '
        'btnSiguienteVersion
        '
        Me.btnSiguienteVersion.Location = New System.Drawing.Point(272, 79)
        Me.btnSiguienteVersion.Name = "btnSiguienteVersion"
        Me.btnSiguienteVersion.Size = New System.Drawing.Size(97, 27)
        Me.btnSiguienteVersion.TabIndex = 5
        Me.btnSiguienteVersion.Text = "SIGUIENTE"
        Me.btnSiguienteVersion.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(28, 57)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "CODIGO"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(28, 86)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "VERSION"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(375, 86)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "FECHA"
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Location = New System.Drawing.Point(508, 417)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(101, 46)
        Me.btnLimpiar.TabIndex = 9
        Me.btnLimpiar.Text = "LIMPIAR"
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'btnImprimir
        '
        Me.btnImprimir.Location = New System.Drawing.Point(615, 417)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(101, 46)
        Me.btnImprimir.TabIndex = 10
        Me.btnImprimir.Text = "IMPRIMIR"
        Me.btnImprimir.UseVisualStyleBackColor = True
        '
        'btnVolver
        '
        Me.btnVolver.Location = New System.Drawing.Point(722, 417)
        Me.btnVolver.Name = "btnVolver"
        Me.btnVolver.Size = New System.Drawing.Size(101, 46)
        Me.btnVolver.TabIndex = 11
        Me.btnVolver.Text = "CERRAR"
        Me.btnVolver.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(15, 421)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(128, 13)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "CONTROL DE CAMBIOS"
        '
        'txtControlDeCambios
        '
        Me.txtControlDeCambios.BackColor = System.Drawing.Color.Cyan
        Me.txtControlDeCambios.Enabled = False
        Me.txtControlDeCambios.Location = New System.Drawing.Point(147, 417)
        Me.txtControlDeCambios.Multiline = True
        Me.txtControlDeCambios.Name = "txtControlDeCambios"
        Me.txtControlDeCambios.Size = New System.Drawing.Size(355, 46)
        Me.txtControlDeCambios.TabIndex = 13
        '
        'DGV_ConsultaVersiones
        '
        Me.DGV_ConsultaVersiones.AllowUserToAddRows = False
        Me.DGV_ConsultaVersiones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_ConsultaVersiones.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Ensayo, Me.Descripcion, Me.ValorEstandar, Me.Desde, Me.Hasta})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(232, Byte), Integer))
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGV_ConsultaVersiones.DefaultCellStyle = DataGridViewCellStyle3
        Me.DGV_ConsultaVersiones.DoubleBuffered = True
        Me.DGV_ConsultaVersiones.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.DGV_ConsultaVersiones.Location = New System.Drawing.Point(13, 112)
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
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(839, 47)
        Me.Panel1.TabIndex = 15
        '
        'Label6
        '
        Me.Label6.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.Control
        Me.Label6.Location = New System.Drawing.Point(23, 14)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(283, 18)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "Consulta de Especificaciones por Version"
        '
        'Label5
        '
        Me.Label5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.Control
        Me.Label5.Location = New System.Drawing.Point(660, 14)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(155, 20)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "SURFACTAN S.A."
        '
        'txtDescTerminado
        '
        Me.txtDescTerminado.BackColor = System.Drawing.Color.Cyan
        Me.txtDescTerminado.Enabled = False
        Me.txtDescTerminado.Location = New System.Drawing.Point(172, 53)
        Me.txtDescTerminado.Name = "txtDescTerminado"
        Me.txtDescTerminado.Size = New System.Drawing.Size(633, 20)
        Me.txtDescTerminado.TabIndex = 13
        '
        'ConsDeEspefXVersion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(839, 475)
        Me.Controls.Add(Me.DGV_ConsultaVersiones)
        Me.Controls.Add(Me.txtDescTerminado)
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
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "ConsDeEspefXVersion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
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
    Friend WithEvents DGV_ConsultaVersiones As Util.DBDataGridView
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Ensayo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Descripcion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ValorEstandar As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Desde As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Hasta As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtDescTerminado As System.Windows.Forms.TextBox
End Class