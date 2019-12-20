<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EspecificacionesMPPorVersion
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.dgvEnsayos = New ConsultasVarias.DBDataGridView()
        Me.Ensayo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Valor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnSigVersion = New System.Windows.Forms.Button()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.btnAntVersion = New System.Windows.Forms.Button()
        Me.btnImprimir = New System.Windows.Forms.Button()
        Me.btnConsulta = New System.Windows.Forms.Button()
        Me.txtFinal = New System.Windows.Forms.MaskedTextBox()
        Me.txtInicio = New System.Windows.Forms.MaskedTextBox()
        Me.txtControlCambios = New System.Windows.Forms.TextBox()
        Me.txtVersion = New System.Windows.Forms.TextBox()
        Me.lblDescMP = New System.Windows.Forms.Label()
        Me.txtCodigo = New System.Windows.Forms.MaskedTextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblClasificacion = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.dgvEnsayos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(873, 49)
        Me.Panel1.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.Control
        Me.Label2.Location = New System.Drawing.Point(683, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(179, 24)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "SURFACTAN S.A."
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.Control
        Me.Label1.Location = New System.Drawing.Point(12, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(188, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "SISTEMA DE LABORATORIO"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.dgvEnsayos, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.GroupBox1, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 49)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 107.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(873, 468)
        Me.TableLayoutPanel1.TabIndex = 3
        '
        'dgvEnsayos
        '
        Me.dgvEnsayos.AllowUserToAddRows = False
        Me.dgvEnsayos.AllowUserToDeleteRows = False
        Me.dgvEnsayos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvEnsayos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Ensayo, Me.Descripcion, Me.Valor})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(232, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvEnsayos.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvEnsayos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvEnsayos.DoubleBuffered = True
        Me.dgvEnsayos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dgvEnsayos.Location = New System.Drawing.Point(3, 110)
        Me.dgvEnsayos.Name = "dgvEnsayos"
        Me.dgvEnsayos.OrdenamientoColumnasHabilitado = False
        Me.dgvEnsayos.ReadOnly = True
        Me.dgvEnsayos.RowHeadersWidth = 15
        Me.dgvEnsayos.RowTemplate.Height = 20
        Me.dgvEnsayos.ShowCellToolTips = False
        Me.dgvEnsayos.SinClickDerecho = True
        Me.dgvEnsayos.Size = New System.Drawing.Size(867, 355)
        Me.dgvEnsayos.TabIndex = 0
        '
        'Ensayo
        '
        Me.Ensayo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Ensayo.DefaultCellStyle = DataGridViewCellStyle1
        Me.Ensayo.HeaderText = "Ensayo"
        Me.Ensayo.MinimumWidth = 30
        Me.Ensayo.Name = "Ensayo"
        Me.Ensayo.ReadOnly = True
        Me.Ensayo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Ensayo.Width = 48
        '
        'Descripcion
        '
        Me.Descripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Descripcion.HeaderText = "Descripción"
        Me.Descripcion.MinimumWidth = 200
        Me.Descripcion.Name = "Descripcion"
        Me.Descripcion.ReadOnly = True
        Me.Descripcion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Valor
        '
        Me.Valor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Valor.HeaderText = "Valor Standard"
        Me.Valor.MinimumWidth = 180
        Me.Valor.Name = "Valor"
        Me.Valor.ReadOnly = True
        Me.Valor.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Valor.Width = 180
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnSigVersion)
        Me.GroupBox1.Controls.Add(Me.btnCerrar)
        Me.GroupBox1.Controls.Add(Me.btnLimpiar)
        Me.GroupBox1.Controls.Add(Me.btnAntVersion)
        Me.GroupBox1.Controls.Add(Me.btnImprimir)
        Me.GroupBox1.Controls.Add(Me.btnConsulta)
        Me.GroupBox1.Controls.Add(Me.txtFinal)
        Me.GroupBox1.Controls.Add(Me.txtInicio)
        Me.GroupBox1.Controls.Add(Me.txtControlCambios)
        Me.GroupBox1.Controls.Add(Me.txtVersion)
        Me.GroupBox1.Controls.Add(Me.lblClasificacion)
        Me.GroupBox1.Controls.Add(Me.lblDescMP)
        Me.GroupBox1.Controls.Add(Me.txtCodigo)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(10, 3)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(10, 3, 10, 5)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(853, 99)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        '
        'btnSigVersion
        '
        Me.btnSigVersion.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnSigVersion.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSigVersion.Location = New System.Drawing.Point(743, 70)
        Me.btnSigVersion.Name = "btnSigVersion"
        Me.btnSigVersion.Size = New System.Drawing.Size(87, 26)
        Me.btnSigVersion.TabIndex = 5
        Me.btnSigVersion.Text = "SIG. VERSIÓN"
        Me.btnSigVersion.UseVisualStyleBackColor = True
        '
        'btnCerrar
        '
        Me.btnCerrar.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnCerrar.Location = New System.Drawing.Point(743, 41)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(87, 26)
        Me.btnCerrar.TabIndex = 5
        Me.btnCerrar.Text = "CERRAR"
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnLimpiar.Location = New System.Drawing.Point(743, 13)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(87, 26)
        Me.btnLimpiar.TabIndex = 5
        Me.btnLimpiar.Text = "LIMPIAR"
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'btnAntVersion
        '
        Me.btnAntVersion.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnAntVersion.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAntVersion.Location = New System.Drawing.Point(650, 70)
        Me.btnAntVersion.Name = "btnAntVersion"
        Me.btnAntVersion.Size = New System.Drawing.Size(87, 26)
        Me.btnAntVersion.TabIndex = 5
        Me.btnAntVersion.Text = "ANT. VERSIÓN"
        Me.btnAntVersion.UseVisualStyleBackColor = True
        '
        'btnImprimir
        '
        Me.btnImprimir.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnImprimir.Location = New System.Drawing.Point(650, 41)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(87, 26)
        Me.btnImprimir.TabIndex = 5
        Me.btnImprimir.Text = "IMPRIMIR"
        Me.btnImprimir.UseVisualStyleBackColor = True
        '
        'btnConsulta
        '
        Me.btnConsulta.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnConsulta.Location = New System.Drawing.Point(650, 13)
        Me.btnConsulta.Name = "btnConsulta"
        Me.btnConsulta.Size = New System.Drawing.Size(87, 26)
        Me.btnConsulta.TabIndex = 5
        Me.btnConsulta.Text = "CONSULTA"
        Me.btnConsulta.UseVisualStyleBackColor = True
        '
        'txtFinal
        '
        Me.txtFinal.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtFinal.Location = New System.Drawing.Point(319, 43)
        Me.txtFinal.Mask = "00/00/0000"
        Me.txtFinal.Name = "txtFinal"
        Me.txtFinal.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtFinal.Size = New System.Drawing.Size(68, 20)
        Me.txtFinal.TabIndex = 4
        Me.txtFinal.Text = "99999999"
        Me.txtFinal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtInicio
        '
        Me.txtInicio.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtInicio.Location = New System.Drawing.Point(219, 43)
        Me.txtInicio.Mask = "00/00/0000"
        Me.txtInicio.Name = "txtInicio"
        Me.txtInicio.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtInicio.Size = New System.Drawing.Size(68, 20)
        Me.txtInicio.TabIndex = 4
        Me.txtInicio.Text = "99999999"
        Me.txtInicio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtControlCambios
        '
        Me.txtControlCambios.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtControlCambios.Location = New System.Drawing.Point(156, 67)
        Me.txtControlCambios.MaxLength = 2
        Me.txtControlCambios.Name = "txtControlCambios"
        Me.txtControlCambios.Size = New System.Drawing.Size(488, 20)
        Me.txtControlCambios.TabIndex = 3
        '
        'txtVersion
        '
        Me.txtVersion.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtVersion.Location = New System.Drawing.Point(84, 43)
        Me.txtVersion.MaxLength = 2
        Me.txtVersion.Name = "txtVersion"
        Me.txtVersion.Size = New System.Drawing.Size(36, 20)
        Me.txtVersion.TabIndex = 3
        Me.txtVersion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblDescMP
        '
        Me.lblDescMP.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblDescMP.BackColor = System.Drawing.Color.Cyan
        Me.lblDescMP.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDescMP.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescMP.Location = New System.Drawing.Point(156, 19)
        Me.lblDescMP.Name = "lblDescMP"
        Me.lblDescMP.Padding = New System.Windows.Forms.Padding(3)
        Me.lblDescMP.Size = New System.Drawing.Size(488, 21)
        Me.lblDescMP.TabIndex = 2
        Me.lblDescMP.Text = "Label4"
        '
        'txtCodigo
        '
        Me.txtCodigo.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtCodigo.Location = New System.Drawing.Point(84, 19)
        Me.txtCodigo.Mask = ">LL-000-000"
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtCodigo.Size = New System.Drawing.Size(66, 20)
        Me.txtCodigo.TabIndex = 1
        Me.txtCodigo.Text = "AA100100"
        '
        'Label7
        '
        Me.Label7.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(293, 47)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(20, 13)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "AL"
        '
        'Label6
        '
        Me.Label6.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(153, 47)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(60, 13)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "VIGENCIA:"
        '
        'Label8
        '
        Me.Label8.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(22, 71)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(131, 13)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "CONTROL DE CAMBIOS:"
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(22, 47)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(58, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "VERSIÓN:"
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(22, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(52, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "CODIGO:"
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(393, 47)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(89, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "CLASIFICACIÓN:"
        '
        'lblClasificacion
        '
        Me.lblClasificacion.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblClasificacion.BackColor = System.Drawing.Color.Cyan
        Me.lblClasificacion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblClasificacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblClasificacion.Location = New System.Drawing.Point(488, 42)
        Me.lblClasificacion.Name = "lblClasificacion"
        Me.lblClasificacion.Padding = New System.Windows.Forms.Padding(3)
        Me.lblClasificacion.Size = New System.Drawing.Size(156, 21)
        Me.lblClasificacion.TabIndex = 2
        Me.lblClasificacion.Text = "Label4"
        '
        'EspecificacionesMPPorVersion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(873, 517)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "EspecificacionesMPPorVersion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.dgvEnsayos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents dgvEnsayos As ConsultasVarias.DBDataGridView
    Friend WithEvents Ensayo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Descripcion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Valor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtCodigo As System.Windows.Forms.MaskedTextBox
    Friend WithEvents lblDescMP As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtVersion As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtFinal As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtInicio As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtControlCambios As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents btnConsulta As System.Windows.Forms.Button
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents btnImprimir As System.Windows.Forms.Button
    Friend WithEvents btnSigVersion As System.Windows.Forms.Button
    Friend WithEvents btnAntVersion As System.Windows.Forms.Button
    Friend WithEvents lblClasificacion As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class