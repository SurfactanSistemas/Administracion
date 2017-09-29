<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ArchivosRelacionados
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.LayoutPrincipal = New System.Windows.Forms.TableLayoutPanel()
        Me.LayoutCabecera = New System.Windows.Forms.TableLayoutPanel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.LayoutCuerpoPrincipal = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtFechaAux = New System.Windows.Forms.MaskedTextBox()
        Me.dgvProductos = New System.Windows.Forms.DataGridView()
        Me.Fecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Observacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Icono = New System.Windows.Forms.DataGridViewImageColumn()
        Me.RutaArchivo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtDescripcionCliente = New System.Windows.Forms.TextBox()
        Me.txtCliente = New System.Windows.Forms.TextBox()
        Me.txtNroProforma = New System.Windows.Forms.TextBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.LayoutPrincipal.SuspendLayout()
        Me.LayoutCabecera.SuspendLayout()
        Me.LayoutCuerpoPrincipal.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.dgvProductos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'LayoutPrincipal
        '
        Me.LayoutPrincipal.BackColor = System.Drawing.SystemColors.Control
        Me.LayoutPrincipal.ColumnCount = 1
        Me.LayoutPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.LayoutPrincipal.Controls.Add(Me.LayoutCabecera, 0, 0)
        Me.LayoutPrincipal.Controls.Add(Me.LayoutCuerpoPrincipal, 0, 1)
        Me.LayoutPrincipal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutPrincipal.Location = New System.Drawing.Point(0, 0)
        Me.LayoutPrincipal.Margin = New System.Windows.Forms.Padding(0)
        Me.LayoutPrincipal.Name = "LayoutPrincipal"
        Me.LayoutPrincipal.RowCount = 2
        Me.LayoutPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45.0!))
        Me.LayoutPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.LayoutPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.LayoutPrincipal.Size = New System.Drawing.Size(668, 455)
        Me.LayoutPrincipal.TabIndex = 2
        '
        'LayoutCabecera
        '
        Me.LayoutCabecera.BackColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.LayoutCabecera.ColumnCount = 3
        Me.LayoutCabecera.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 241.0!))
        Me.LayoutCabecera.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.LayoutCabecera.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 180.0!))
        Me.LayoutCabecera.Controls.Add(Me.Label3, 0, 0)
        Me.LayoutCabecera.Controls.Add(Me.Label1, 0, 0)
        Me.LayoutCabecera.Controls.Add(Me.Label2, 2, 0)
        Me.LayoutCabecera.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutCabecera.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold)
        Me.LayoutCabecera.ForeColor = System.Drawing.SystemColors.Control
        Me.LayoutCabecera.Location = New System.Drawing.Point(0, 0)
        Me.LayoutCabecera.Margin = New System.Windows.Forms.Padding(0)
        Me.LayoutCabecera.Name = "LayoutCabecera"
        Me.LayoutCabecera.RowCount = 1
        Me.LayoutCabecera.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.LayoutCabecera.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45.0!))
        Me.LayoutCabecera.Size = New System.Drawing.Size(668, 45)
        Me.LayoutCabecera.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label3.Font = New System.Drawing.Font("Calibri", 14.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.Location = New System.Drawing.Point(241, 0)
        Me.Label3.Margin = New System.Windows.Forms.Padding(0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(247, 45)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "- Archivos Relacionados -"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Font = New System.Drawing.Font("Calibri", 14.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Margin = New System.Windows.Forms.Padding(0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(241, 45)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Sistema de Exportaciones"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label2.Font = New System.Drawing.Font("Calibri", 16.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(491, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(174, 45)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "SURFACTAN S.A."
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LayoutCuerpoPrincipal
        '
        Me.LayoutCuerpoPrincipal.ColumnCount = 1
        Me.LayoutCuerpoPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.LayoutCuerpoPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.LayoutCuerpoPrincipal.Controls.Add(Me.Panel1, 0, 0)
        Me.LayoutCuerpoPrincipal.Controls.Add(Me.Panel2, 0, 1)
        Me.LayoutCuerpoPrincipal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutCuerpoPrincipal.Location = New System.Drawing.Point(0, 45)
        Me.LayoutCuerpoPrincipal.Margin = New System.Windows.Forms.Padding(0)
        Me.LayoutCuerpoPrincipal.Name = "LayoutCuerpoPrincipal"
        Me.LayoutCuerpoPrincipal.RowCount = 2
        Me.LayoutCuerpoPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.LayoutCuerpoPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 69.0!))
        Me.LayoutCuerpoPrincipal.Size = New System.Drawing.Size(668, 410)
        Me.LayoutCuerpoPrincipal.TabIndex = 1
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(95, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(82, Byte), Integer))
        Me.Panel1.Controls.Add(Me.txtFechaAux)
        Me.Panel1.Controls.Add(Me.dgvProductos)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.txtDescripcionCliente)
        Me.Panel1.Controls.Add(Me.txtCliente)
        Me.Panel1.Controls.Add(Me.txtNroProforma)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(668, 344)
        Me.Panel1.TabIndex = 2
        '
        'txtFechaAux
        '
        Me.txtFechaAux.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtFechaAux.Location = New System.Drawing.Point(495, 276)
        Me.txtFechaAux.Mask = "LL-00000-000"
        Me.txtFechaAux.Name = "txtFechaAux"
        Me.txtFechaAux.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtFechaAux.Size = New System.Drawing.Size(79, 13)
        Me.txtFechaAux.TabIndex = 9
        Me.txtFechaAux.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtFechaAux.Visible = False
        '
        'dgvProductos
        '
        Me.dgvProductos.AllowUserToAddRows = False
        Me.dgvProductos.AllowUserToDeleteRows = False
        Me.dgvProductos.AllowUserToOrderColumns = True
        Me.dgvProductos.AllowUserToResizeRows = False
        Me.dgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvProductos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Fecha, Me.Observacion, Me.Icono, Me.RutaArchivo})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvProductos.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvProductos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.dgvProductos.Location = New System.Drawing.Point(48, 50)
        Me.dgvProductos.MultiSelect = False
        Me.dgvProductos.Name = "dgvProductos"
        Me.dgvProductos.RowTemplate.Height = 40
        Me.dgvProductos.Size = New System.Drawing.Size(574, 281)
        Me.dgvProductos.TabIndex = 8
        '
        'Fecha
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Fecha.DefaultCellStyle = DataGridViewCellStyle1
        Me.Fecha.HeaderText = "Fecha"
        Me.Fecha.MaxInputLength = 12
        Me.Fecha.MinimumWidth = 100
        Me.Fecha.Name = "Fecha"
        Me.Fecha.ReadOnly = True
        Me.Fecha.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Observacion
        '
        Me.Observacion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.Observacion.DefaultCellStyle = DataGridViewCellStyle2
        Me.Observacion.HeaderText = "Observación"
        Me.Observacion.Name = "Observacion"
        Me.Observacion.ReadOnly = True
        Me.Observacion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Icono
        '
        Me.Icono.HeaderText = ""
        Me.Icono.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom
        Me.Icono.Name = "Icono"
        Me.Icono.ReadOnly = True
        Me.Icono.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Icono.Width = 50
        '
        'RutaArchivo
        '
        Me.RutaArchivo.HeaderText = "Tipo"
        Me.RutaArchivo.Name = "RutaArchivo"
        Me.RutaArchivo.Visible = False
        Me.RutaArchivo.Width = 80
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label6.ForeColor = System.Drawing.SystemColors.Control
        Me.Label6.Location = New System.Drawing.Point(213, 19)
        Me.Label6.Margin = New System.Windows.Forms.Padding(0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(57, 18)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "Cliente:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label4.ForeColor = System.Drawing.SystemColors.Control
        Me.Label4.Location = New System.Drawing.Point(45, 20)
        Me.Label4.Margin = New System.Windows.Forms.Padding(0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(70, 18)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Proforma:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtDescripcionCliente
        '
        Me.txtDescripcionCliente.Enabled = False
        Me.txtDescripcionCliente.Location = New System.Drawing.Point(356, 18)
        Me.txtDescripcionCliente.Name = "txtDescripcionCliente"
        Me.txtDescripcionCliente.ReadOnly = True
        Me.txtDescripcionCliente.Size = New System.Drawing.Size(266, 20)
        Me.txtDescripcionCliente.TabIndex = 0
        '
        'txtCliente
        '
        Me.txtCliente.Location = New System.Drawing.Point(271, 18)
        Me.txtCliente.MaxLength = 6
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.ReadOnly = True
        Me.txtCliente.Size = New System.Drawing.Size(79, 20)
        Me.txtCliente.TabIndex = 0
        '
        'txtNroProforma
        '
        Me.txtNroProforma.Location = New System.Drawing.Point(125, 19)
        Me.txtNroProforma.MaxLength = 6
        Me.txtNroProforma.Name = "txtNroProforma"
        Me.txtNroProforma.Size = New System.Drawing.Size(79, 20)
        Me.txtNroProforma.TabIndex = 0
        Me.txtNroProforma.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.btnCerrar)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(3, 347)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(662, 63)
        Me.Panel2.TabIndex = 3
        '
        'btnCerrar
        '
        Me.btnCerrar.Location = New System.Drawing.Point(283, 9)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(81, 45)
        Me.btnCerrar.TabIndex = 0
        Me.btnCerrar.Text = "Cerrar"
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'ArchivosRelacionados
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(668, 455)
        Me.Controls.Add(Me.LayoutPrincipal)
        Me.Name = "ArchivosRelacionados"
        Me.LayoutPrincipal.ResumeLayout(False)
        Me.LayoutCabecera.ResumeLayout(False)
        Me.LayoutCuerpoPrincipal.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dgvProductos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LayoutPrincipal As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents LayoutCabecera As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents LayoutCuerpoPrincipal As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents txtFechaAux As System.Windows.Forms.MaskedTextBox
    Friend WithEvents dgvProductos As System.Windows.Forms.DataGridView
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtDescripcionCliente As System.Windows.Forms.TextBox
    Friend WithEvents txtCliente As System.Windows.Forms.TextBox
    Friend WithEvents txtNroProforma As System.Windows.Forms.TextBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents Fecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Observacion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Icono As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents RutaArchivo As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
