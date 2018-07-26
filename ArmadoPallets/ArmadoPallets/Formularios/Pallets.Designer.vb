<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Pallets
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
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.LayoutPrincipal = New System.Windows.Forms.TableLayoutPanel()
        Me.LayoutMenu = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.txtPedido = New System.Windows.Forms.TextBox()
        Me.txtProforma = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.btnAgregarPallet = New System.Windows.Forms.Button()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.dgvPallets = New System.Windows.Forms.DataGridView()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.lblTotalKgNetos = New System.Windows.Forms.Label()
        Me.lblTotalKgBrutos = New System.Windows.Forms.Label()
        Me.lblTotalPallets = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Nro = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Pallet = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Bultos = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.KgBrutos = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.KgNetos = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Disponible = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LayoutPrincipal.SuspendLayout()
        Me.LayoutMenu.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel5.SuspendLayout()
        CType(Me.dgvPallets, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel6.SuspendLayout()
        Me.SuspendLayout()
        '
        'LayoutPrincipal
        '
        Me.LayoutPrincipal.ColumnCount = 1
        Me.LayoutPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.LayoutPrincipal.Controls.Add(Me.LayoutMenu, 0, 0)
        Me.LayoutPrincipal.Controls.Add(Me.Panel1, 0, 1)
        Me.LayoutPrincipal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutPrincipal.Location = New System.Drawing.Point(0, 0)
        Me.LayoutPrincipal.Name = "LayoutPrincipal"
        Me.LayoutPrincipal.RowCount = 2
        Me.LayoutPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46.0!))
        Me.LayoutPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.LayoutPrincipal.Size = New System.Drawing.Size(701, 418)
        Me.LayoutPrincipal.TabIndex = 1
        '
        'LayoutMenu
        '
        Me.LayoutMenu.BackColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.LayoutMenu.ColumnCount = 3
        Me.LayoutMenu.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 207.0!))
        Me.LayoutMenu.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.LayoutMenu.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 247.0!))
        Me.LayoutMenu.Controls.Add(Me.Panel4, 2, 0)
        Me.LayoutMenu.Controls.Add(Me.Panel2, 0, 0)
        Me.LayoutMenu.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutMenu.Location = New System.Drawing.Point(0, 0)
        Me.LayoutMenu.Margin = New System.Windows.Forms.Padding(0)
        Me.LayoutMenu.Name = "LayoutMenu"
        Me.LayoutMenu.RowCount = 1
        Me.LayoutMenu.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.LayoutMenu.Size = New System.Drawing.Size(701, 46)
        Me.LayoutMenu.TabIndex = 0
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.Label2)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(454, 0)
        Me.Panel4.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(247, 46)
        Me.Panel4.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Calibri", 18.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.SystemColors.Control
        Me.Label2.Location = New System.Drawing.Point(35, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(176, 29)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "SURFACTAN S.A."
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(207, 46)
        Me.Panel2.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Calibri", 14.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.SystemColors.Control
        Me.Label1.Location = New System.Drawing.Point(66, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(74, 23)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "PALLETS"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.TableLayoutPanel1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 46)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(701, 372)
        Me.Panel1.TabIndex = 1
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Panel3, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel5, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.dgvPallets, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel6, 0, 2)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 4
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 51.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 62.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(701, 372)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.txtPedido)
        Me.Panel3.Controls.Add(Me.txtProforma)
        Me.Panel3.Controls.Add(Me.Label4)
        Me.Panel3.Controls.Add(Me.Label3)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(3, 3)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(695, 45)
        Me.Panel3.TabIndex = 2
        '
        'txtPedido
        '
        Me.txtPedido.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPedido.Location = New System.Drawing.Point(268, 12)
        Me.txtPedido.Name = "txtPedido"
        Me.txtPedido.Size = New System.Drawing.Size(73, 21)
        Me.txtPedido.TabIndex = 1
        '
        'txtProforma
        '
        Me.txtProforma.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProforma.Location = New System.Drawing.Point(111, 12)
        Me.txtProforma.Name = "txtProforma"
        Me.txtProforma.Size = New System.Drawing.Size(73, 21)
        Me.txtProforma.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(207, 14)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(55, 16)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Pedido:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(39, 14)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(66, 16)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Proforma:"
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.btnAgregarPallet)
        Me.Panel5.Controls.Add(Me.btnCerrar)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel5.Location = New System.Drawing.Point(0, 310)
        Me.Panel5.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(701, 62)
        Me.Panel5.TabIndex = 1
        '
        'btnAgregarPallet
        '
        Me.btnAgregarPallet.Location = New System.Drawing.Point(224, 10)
        Me.btnAgregarPallet.Name = "btnAgregarPallet"
        Me.btnAgregarPallet.Size = New System.Drawing.Size(125, 43)
        Me.btnAgregarPallet.TabIndex = 0
        Me.btnAgregarPallet.Text = "Agregar Pallet"
        Me.btnAgregarPallet.UseVisualStyleBackColor = True
        '
        'btnCerrar
        '
        Me.btnCerrar.Location = New System.Drawing.Point(402, 10)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(75, 43)
        Me.btnCerrar.TabIndex = 0
        Me.btnCerrar.Text = "Cerrar"
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'dgvPallets
        '
        Me.dgvPallets.AllowUserToAddRows = False
        Me.dgvPallets.AllowUserToDeleteRows = False
        Me.dgvPallets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPallets.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Nro, Me.Pallet, Me.Descripcion, Me.Bultos, Me.KgBrutos, Me.KgNetos, Me.Disponible})
        Me.dgvPallets.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvPallets.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dgvPallets.Location = New System.Drawing.Point(3, 54)
        Me.dgvPallets.Name = "dgvPallets"
        Me.dgvPallets.ReadOnly = True
        Me.dgvPallets.RowHeadersWidth = 15
        Me.dgvPallets.ShowCellToolTips = False
        Me.dgvPallets.Size = New System.Drawing.Size(695, 211)
        Me.dgvPallets.TabIndex = 3
        '
        'Panel6
        '
        Me.Panel6.Controls.Add(Me.lblTotalKgNetos)
        Me.Panel6.Controls.Add(Me.lblTotalKgBrutos)
        Me.Panel6.Controls.Add(Me.lblTotalPallets)
        Me.Panel6.Controls.Add(Me.Label9)
        Me.Panel6.Controls.Add(Me.Label7)
        Me.Panel6.Controls.Add(Me.Label5)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel6.Location = New System.Drawing.Point(0, 268)
        Me.Panel6.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(701, 42)
        Me.Panel6.TabIndex = 4
        '
        'lblTotalKgNetos
        '
        Me.lblTotalKgNetos.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblTotalKgNetos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTotalKgNetos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalKgNetos.Location = New System.Drawing.Point(587, 11)
        Me.lblTotalKgNetos.Name = "lblTotalKgNetos"
        Me.lblTotalKgNetos.Size = New System.Drawing.Size(81, 21)
        Me.lblTotalKgNetos.TabIndex = 0
        Me.lblTotalKgNetos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTotalKgBrutos
        '
        Me.lblTotalKgBrutos.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblTotalKgBrutos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTotalKgBrutos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalKgBrutos.Location = New System.Drawing.Point(368, 11)
        Me.lblTotalKgBrutos.Name = "lblTotalKgBrutos"
        Me.lblTotalKgBrutos.Size = New System.Drawing.Size(71, 21)
        Me.lblTotalKgBrutos.TabIndex = 0
        Me.lblTotalKgBrutos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTotalPallets
        '
        Me.lblTotalPallets.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblTotalPallets.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTotalPallets.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalPallets.Location = New System.Drawing.Point(141, 11)
        Me.lblTotalPallets.Name = "lblTotalPallets"
        Me.lblTotalPallets.Size = New System.Drawing.Size(47, 21)
        Me.lblTotalPallets.TabIndex = 0
        Me.lblTotalPallets.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(479, 13)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(100, 16)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "Total Kg Netos:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(260, 13)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(102, 16)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Total Kg Brutos:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(33, 13)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(104, 16)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Total PALLETS:"
        '
        'Nro
        '
        Me.Nro.DataPropertyName = "Nro"
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Nro.DefaultCellStyle = DataGridViewCellStyle11
        Me.Nro.HeaderText = "Nro"
        Me.Nro.Name = "Nro"
        Me.Nro.ReadOnly = True
        '
        'Pallet
        '
        Me.Pallet.DataPropertyName = "Pallet"
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Pallet.DefaultCellStyle = DataGridViewCellStyle12
        Me.Pallet.HeaderText = "Pallet"
        Me.Pallet.Name = "Pallet"
        Me.Pallet.ReadOnly = True
        '
        'Descripcion
        '
        Me.Descripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Descripcion.DataPropertyName = "Descripcion"
        Me.Descripcion.HeaderText = "Descripcion"
        Me.Descripcion.MinimumWidth = 100
        Me.Descripcion.Name = "Descripcion"
        Me.Descripcion.ReadOnly = True
        '
        'Bultos
        '
        Me.Bultos.DataPropertyName = "Bultos"
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Bultos.DefaultCellStyle = DataGridViewCellStyle13
        Me.Bultos.HeaderText = "Bultos"
        Me.Bultos.Name = "Bultos"
        Me.Bultos.ReadOnly = True
        '
        'KgBrutos
        '
        Me.KgBrutos.DataPropertyName = "KgBrutos"
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.KgBrutos.DefaultCellStyle = DataGridViewCellStyle14
        Me.KgBrutos.HeaderText = "Kg Brutos"
        Me.KgBrutos.Name = "KgBrutos"
        Me.KgBrutos.ReadOnly = True
        '
        'KgNetos
        '
        Me.KgNetos.DataPropertyName = "KgNetos"
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.KgNetos.DefaultCellStyle = DataGridViewCellStyle15
        Me.KgNetos.HeaderText = "Kg Netos"
        Me.KgNetos.Name = "KgNetos"
        Me.KgNetos.ReadOnly = True
        '
        'Disponible
        '
        Me.Disponible.DataPropertyName = "Disponible"
        Me.Disponible.HeaderText = "Disponible el"
        Me.Disponible.Name = "Disponible"
        Me.Disponible.ReadOnly = True
        '
        'Pallets
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(701, 418)
        Me.Controls.Add(Me.LayoutPrincipal)
        Me.Location = New System.Drawing.Point(10, 10)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Pallets"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.LayoutPrincipal.ResumeLayout(False)
        Me.LayoutMenu.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        CType(Me.dgvPallets, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LayoutPrincipal As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents LayoutMenu As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents txtPedido As System.Windows.Forms.TextBox
    Friend WithEvents txtProforma As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dgvPallets As System.Windows.Forms.DataGridView
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblTotalPallets As System.Windows.Forms.Label
    Friend WithEvents lblTotalKgNetos As System.Windows.Forms.Label
    Friend WithEvents lblTotalKgBrutos As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btnAgregarPallet As System.Windows.Forms.Button
    Friend WithEvents Nro As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Pallet As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Descripcion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Bultos As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents KgBrutos As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents KgNetos As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Disponible As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
