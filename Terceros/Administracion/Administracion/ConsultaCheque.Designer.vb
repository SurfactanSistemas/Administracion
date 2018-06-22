<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ConsultaCheque
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.gridCheque = New System.Windows.Forms.DataGridView()
        Me.Cheque = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Banco = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Importe = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FechaComprobante = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.fechaCheque = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.comprobante = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.observaciones = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cmbTipo = New System.Windows.Forms.ComboBox()
        Me.CustomLabel1 = New Administracion.CustomLabel()
        Me.txtCheque = New Administracion.CustomTextBox()
        Me.btnProceso = New Administracion.CustomButton()
        Me.btnCerrar = New Administracion.CustomButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.CustomButton1 = New Administracion.CustomButton()
        CType(Me.gridCheque, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'gridCheque
        '
        Me.gridCheque.AllowUserToAddRows = False
        Me.gridCheque.AllowUserToDeleteRows = False
        Me.gridCheque.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.gridCheque.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridCheque.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Cheque, Me.Banco, Me.Importe, Me.FechaComprobante, Me.fechaCheque, Me.comprobante, Me.observaciones})
        Me.gridCheque.Location = New System.Drawing.Point(13, 40)
        Me.gridCheque.Name = "gridCheque"
        Me.gridCheque.ReadOnly = True
        Me.gridCheque.RowHeadersVisible = False
        Me.gridCheque.RowHeadersWidth = 5
        Me.gridCheque.Size = New System.Drawing.Size(760, 293)
        Me.gridCheque.StandardTab = True
        Me.gridCheque.TabIndex = 2
        '
        'Cheque
        '
        Me.Cheque.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Cheque.HeaderText = "Cheque"
        Me.Cheque.Name = "Cheque"
        Me.Cheque.ReadOnly = True
        Me.Cheque.Width = 69
        '
        'Banco
        '
        Me.Banco.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Banco.FillWeight = 70.0!
        Me.Banco.HeaderText = "Banco"
        Me.Banco.MaxInputLength = 50
        Me.Banco.Name = "Banco"
        Me.Banco.ReadOnly = True
        '
        'Importe
        '
        Me.Importe.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Importe.DefaultCellStyle = DataGridViewCellStyle1
        Me.Importe.HeaderText = "Importe"
        Me.Importe.Name = "Importe"
        Me.Importe.ReadOnly = True
        Me.Importe.Width = 67
        '
        'FechaComprobante
        '
        Me.FechaComprobante.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.FechaComprobante.HeaderText = "Fecha Comp."
        Me.FechaComprobante.Name = "FechaComprobante"
        Me.FechaComprobante.ReadOnly = True
        Me.FechaComprobante.Width = 95
        '
        'fechaCheque
        '
        Me.fechaCheque.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.fechaCheque.HeaderText = "Fecha Cheque"
        Me.fechaCheque.Name = "fechaCheque"
        Me.fechaCheque.ReadOnly = True
        Me.fechaCheque.Width = 102
        '
        'comprobante
        '
        Me.comprobante.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.comprobante.HeaderText = "Comp."
        Me.comprobante.Name = "comprobante"
        Me.comprobante.ReadOnly = True
        Me.comprobante.Width = 62
        '
        'observaciones
        '
        Me.observaciones.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.observaciones.FillWeight = 130.0!
        Me.observaciones.HeaderText = "Observaciones"
        Me.observaciones.Name = "observaciones"
        Me.observaciones.ReadOnly = True
        '
        'cmbTipo
        '
        Me.cmbTipo.FormattingEnabled = True
        Me.cmbTipo.Items.AddRange(New Object() {"Cheque Terceros", "Cheques Propios"})
        Me.cmbTipo.Location = New System.Drawing.Point(363, 10)
        Me.cmbTipo.Name = "cmbTipo"
        Me.cmbTipo.Size = New System.Drawing.Size(255, 21)
        Me.cmbTipo.TabIndex = 1
        '
        'CustomLabel1
        '
        Me.CustomLabel1.AutoSize = True
        Me.CustomLabel1.ControlAssociationKey = -1
        Me.CustomLabel1.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.CustomLabel1.ForeColor = System.Drawing.SystemColors.Control
        Me.CustomLabel1.Location = New System.Drawing.Point(169, 12)
        Me.CustomLabel1.Name = "CustomLabel1"
        Me.CustomLabel1.Size = New System.Drawing.Size(56, 18)
        Me.CustomLabel1.TabIndex = 7
        Me.CustomLabel1.Text = "Cheque"
        '
        'txtCheque
        '
        Me.txtCheque.Cleanable = False
        Me.txtCheque.Empty = True
        Me.txtCheque.EnterIndex = -1
        Me.txtCheque.LabelAssociationKey = -1
        Me.txtCheque.Location = New System.Drawing.Point(236, 11)
        Me.txtCheque.MaxLength = 8
        Me.txtCheque.Name = "txtCheque"
        Me.txtCheque.Size = New System.Drawing.Size(121, 20)
        Me.txtCheque.TabIndex = 0
        Me.txtCheque.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtCheque.Validator = Administracion.ValidatorType.None
        '
        'btnProceso
        '
        Me.btnProceso.BackgroundImage = Global.Administracion.My.Resources.Resources.Aceptar_N2
        Me.btnProceso.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnProceso.Cleanable = False
        Me.btnProceso.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnProceso.EnterIndex = -1
        Me.btnProceso.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnProceso.FlatAppearance.BorderSize = 0
        Me.btnProceso.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.Control
        Me.btnProceso.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control
        Me.btnProceso.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control
        Me.btnProceso.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnProceso.LabelAssociationKey = -1
        Me.btnProceso.Location = New System.Drawing.Point(214, 430)
        Me.btnProceso.Name = "btnProceso"
        Me.btnProceso.Size = New System.Drawing.Size(59, 60)
        Me.btnProceso.TabIndex = 4
        Me.ToolTip1.SetToolTip(Me.btnProceso, "Aceptar")
        Me.btnProceso.UseVisualStyleBackColor = True
        '
        'btnCerrar
        '
        Me.btnCerrar.BackgroundImage = Global.Administracion.My.Resources.Resources.Salir2
        Me.btnCerrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnCerrar.Cleanable = False
        Me.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCerrar.EnterIndex = -1
        Me.btnCerrar.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnCerrar.FlatAppearance.BorderSize = 0
        Me.btnCerrar.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.Control
        Me.btnCerrar.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control
        Me.btnCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control
        Me.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCerrar.LabelAssociationKey = -1
        Me.btnCerrar.Location = New System.Drawing.Point(512, 430)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(59, 60)
        Me.btnCerrar.TabIndex = 3
        Me.ToolTip1.SetToolTip(Me.btnCerrar, "Cerrar")
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(786, 50)
        Me.Panel1.TabIndex = 8
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.Control
        Me.Label2.Location = New System.Drawing.Point(603, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(156, 26)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "SURFACTAN S.A."
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.Control
        Me.Label1.Location = New System.Drawing.Point(27, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(144, 19)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Consulta de Cheque"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(95, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(82, Byte), Integer))
        Me.Panel2.Controls.Add(Me.gridCheque)
        Me.Panel2.Controls.Add(Me.CustomLabel1)
        Me.Panel2.Controls.Add(Me.txtCheque)
        Me.Panel2.Controls.Add(Me.cmbTipo)
        Me.Panel2.Location = New System.Drawing.Point(0, 50)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(786, 367)
        Me.Panel2.TabIndex = 9
        '
        'CustomButton1
        '
        Me.CustomButton1.BackgroundImage = Global.Administracion.My.Resources.Resources.Limpiar
        Me.CustomButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.CustomButton1.Cleanable = False
        Me.CustomButton1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CustomButton1.EnterIndex = -1
        Me.CustomButton1.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.CustomButton1.FlatAppearance.BorderSize = 0
        Me.CustomButton1.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.Control
        Me.CustomButton1.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control
        Me.CustomButton1.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control
        Me.CustomButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CustomButton1.LabelAssociationKey = -1
        Me.CustomButton1.Location = New System.Drawing.Point(363, 430)
        Me.CustomButton1.Name = "CustomButton1"
        Me.CustomButton1.Size = New System.Drawing.Size(59, 60)
        Me.CustomButton1.TabIndex = 4
        Me.ToolTip1.SetToolTip(Me.CustomButton1, "Limpiar Formulario")
        Me.CustomButton1.UseVisualStyleBackColor = True
        '
        'ConsultaCheque
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 502)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnCerrar)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.CustomButton1)
        Me.Controls.Add(Me.btnProceso)
        Me.Name = "ConsultaCheque"
        CType(Me.gridCheque, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gridCheque As System.Windows.Forms.DataGridView
    Friend WithEvents btnCerrar As Administracion.CustomButton
    Friend WithEvents btnProceso As Administracion.CustomButton
    Friend WithEvents cmbTipo As System.Windows.Forms.ComboBox
    Friend WithEvents txtCheque As Administracion.CustomTextBox
    Friend WithEvents CustomLabel1 As Administracion.CustomLabel
    Friend WithEvents Cheque As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Banco As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Importe As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FechaComprobante As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents fechaCheque As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents comprobante As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents observaciones As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents CustomButton1 As Administracion.CustomButton
End Class
