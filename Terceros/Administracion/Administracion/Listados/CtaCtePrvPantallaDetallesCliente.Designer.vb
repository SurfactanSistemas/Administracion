<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CtaCtePrvPantallaDetallesCliente
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtSaldo = New Administracion.CustomTextBox()
        Me.CustomLabel2 = New Administracion.CustomLabel()
        Me.txtRazon = New Administracion.CustomTextBox()
        Me.CustomLabel1 = New Administracion.CustomLabel()
        Me.txtProveedor = New Administracion.CustomTextBox()
        Me.CustomLabel3 = New Administracion.CustomLabel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.DGVDetalles = New System.Windows.Forms.DataGridView()
        Me.Tipo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Número = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Fecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.WSaldo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.DGVDetalles, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 0, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(296, 373)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(78, 58)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'Cancel_Button
        '
        Me.Cancel_Button.BackgroundImage = Global.Administracion.My.Resources.Resources.Salir2
        Me.Cancel_Button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Cancel_Button.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.Cancel_Button.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control
        Me.Cancel_Button.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control
        Me.Cancel_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Cancel_Button.Location = New System.Drawing.Point(3, 3)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(67, 52)
        Me.Cancel_Button.TabIndex = 1
        Me.ToolTip1.SetToolTip(Me.Cancel_Button, "Cerrar Ventana")
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(669, 50)
        Me.Panel1.TabIndex = 39
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.Control
        Me.Label2.Location = New System.Drawing.Point(493, 10)
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
        Me.Label1.Location = New System.Drawing.Point(27, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(145, 19)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Detalles de Facturas"
        '
        'txtSaldo
        '
        Me.txtSaldo.Cleanable = False
        Me.txtSaldo.Empty = True
        Me.txtSaldo.EnterIndex = -1
        Me.txtSaldo.LabelAssociationKey = -1
        Me.txtSaldo.Location = New System.Drawing.Point(136, 88)
        Me.txtSaldo.Name = "txtSaldo"
        Me.txtSaldo.ReadOnly = True
        Me.txtSaldo.Size = New System.Drawing.Size(87, 20)
        Me.txtSaldo.TabIndex = 35
        Me.txtSaldo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtSaldo.Validator = Administracion.ValidatorType.None
        '
        'CustomLabel2
        '
        Me.CustomLabel2.AutoSize = True
        Me.CustomLabel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(95, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(82, Byte), Integer))
        Me.CustomLabel2.ControlAssociationKey = -1
        Me.CustomLabel2.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.CustomLabel2.ForeColor = System.Drawing.SystemColors.Control
        Me.CustomLabel2.Location = New System.Drawing.Point(63, 91)
        Me.CustomLabel2.Name = "CustomLabel2"
        Me.CustomLabel2.Size = New System.Drawing.Size(42, 18)
        Me.CustomLabel2.TabIndex = 36
        Me.CustomLabel2.Text = "Saldo"
        '
        'txtRazon
        '
        Me.txtRazon.BackColor = System.Drawing.Color.Gainsboro
        Me.txtRazon.Cleanable = False
        Me.txtRazon.Empty = True
        Me.txtRazon.EnterIndex = -1
        Me.txtRazon.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRazon.LabelAssociationKey = -1
        Me.txtRazon.Location = New System.Drawing.Point(229, 14)
        Me.txtRazon.Name = "txtRazon"
        Me.txtRazon.ReadOnly = True
        Me.txtRazon.Size = New System.Drawing.Size(391, 20)
        Me.txtRazon.TabIndex = 34
        Me.txtRazon.Validator = Administracion.ValidatorType.None
        '
        'CustomLabel1
        '
        Me.CustomLabel1.AutoSize = True
        Me.CustomLabel1.ControlAssociationKey = -1
        Me.CustomLabel1.Location = New System.Drawing.Point(373, 100)
        Me.CustomLabel1.Name = "CustomLabel1"
        Me.CustomLabel1.Size = New System.Drawing.Size(0, 13)
        Me.CustomLabel1.TabIndex = 33
        '
        'txtProveedor
        '
        Me.txtProveedor.BackColor = System.Drawing.SystemColors.Control
        Me.txtProveedor.Cleanable = False
        Me.txtProveedor.Empty = True
        Me.txtProveedor.EnterIndex = -1
        Me.txtProveedor.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtProveedor.LabelAssociationKey = -1
        Me.txtProveedor.Location = New System.Drawing.Point(136, 64)
        Me.txtProveedor.MaxLength = 11
        Me.txtProveedor.Name = "txtProveedor"
        Me.txtProveedor.ReadOnly = True
        Me.txtProveedor.Size = New System.Drawing.Size(87, 20)
        Me.txtProveedor.TabIndex = 31
        Me.txtProveedor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtProveedor.Validator = Administracion.ValidatorType.None
        '
        'CustomLabel3
        '
        Me.CustomLabel3.AutoSize = True
        Me.CustomLabel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(95, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(82, Byte), Integer))
        Me.CustomLabel3.ControlAssociationKey = -1
        Me.CustomLabel3.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.CustomLabel3.ForeColor = System.Drawing.SystemColors.Control
        Me.CustomLabel3.Location = New System.Drawing.Point(63, 67)
        Me.CustomLabel3.Name = "CustomLabel3"
        Me.CustomLabel3.Size = New System.Drawing.Size(53, 18)
        Me.CustomLabel3.TabIndex = 32
        Me.CustomLabel3.Text = "Cliente"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(95, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(82, Byte), Integer))
        Me.Panel2.Controls.Add(Me.DGVDetalles)
        Me.Panel2.Controls.Add(Me.txtRazon)
        Me.Panel2.Location = New System.Drawing.Point(0, 50)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(669, 317)
        Me.Panel2.TabIndex = 40
        '
        'DGVDetalles
        '
        Me.DGVDetalles.AllowUserToAddRows = False
        Me.DGVDetalles.AllowUserToDeleteRows = False
        Me.DGVDetalles.AllowUserToResizeColumns = False
        Me.DGVDetalles.AllowUserToResizeRows = False
        Me.DGVDetalles.CausesValidation = False
        Me.DGVDetalles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVDetalles.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Tipo, Me.Número, Me.Fecha, Me.WSaldo})
        Me.DGVDetalles.Location = New System.Drawing.Point(66, 77)
        Me.DGVDetalles.Name = "DGVDetalles"
        Me.DGVDetalles.ReadOnly = True
        Me.DGVDetalles.ShowCellErrors = False
        Me.DGVDetalles.ShowCellToolTips = False
        Me.DGVDetalles.ShowEditingIcon = False
        Me.DGVDetalles.ShowRowErrors = False
        Me.DGVDetalles.Size = New System.Drawing.Size(554, 214)
        Me.DGVDetalles.TabIndex = 35
        Me.DGVDetalles.UseWaitCursor = True
        '
        'Tipo
        '
        Me.Tipo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Tipo.FillWeight = 50.0!
        Me.Tipo.HeaderText = "Tipo"
        Me.Tipo.Name = "Tipo"
        Me.Tipo.ReadOnly = True
        '
        'Número
        '
        Me.Número.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Número.HeaderText = "Número"
        Me.Número.Name = "Número"
        Me.Número.ReadOnly = True
        '
        'Fecha
        '
        Me.Fecha.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Fecha.HeaderText = "Fecha"
        Me.Fecha.Name = "Fecha"
        Me.Fecha.ReadOnly = True
        '
        'WSaldo
        '
        Me.WSaldo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle1.Format = "N2"
        DataGridViewCellStyle1.NullValue = Nothing
        Me.WSaldo.DefaultCellStyle = DataGridViewCellStyle1
        Me.WSaldo.HeaderText = "Saldo"
        Me.WSaldo.Name = "WSaldo"
        Me.WSaldo.ReadOnly = True
        Me.WSaldo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'CtaCtePrvPantallaDetallesCliente
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(670, 441)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.txtSaldo)
        Me.Controls.Add(Me.CustomLabel2)
        Me.Controls.Add(Me.CustomLabel1)
        Me.Controls.Add(Me.txtProveedor)
        Me.Controls.Add(Me.CustomLabel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "CtaCtePrvPantallaDetallesCliente"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.DGVDetalles, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtSaldo As Administracion.CustomTextBox
    Friend WithEvents CustomLabel2 As Administracion.CustomLabel
    Friend WithEvents txtRazon As Administracion.CustomTextBox
    Friend WithEvents CustomLabel1 As Administracion.CustomLabel
    Friend WithEvents txtProveedor As Administracion.CustomTextBox
    Friend WithEvents CustomLabel3 As Administracion.CustomLabel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents DGVDetalles As System.Windows.Forms.DataGridView
    Friend WithEvents Tipo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Número As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Fecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WSaldo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip

End Class
