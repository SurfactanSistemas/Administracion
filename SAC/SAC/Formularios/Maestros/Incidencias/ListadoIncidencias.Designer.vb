<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ListadoIncidencias
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnNuevaIncidencia = New System.Windows.Forms.Button()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.btnFiltrar = New System.Windows.Forms.Button()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.clbTipos = New System.Windows.Forms.CheckedListBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.clbEstados = New System.Windows.Forms.CheckedListBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtHasta = New System.Windows.Forms.MaskedTextBox()
        Me.txtDesde = New System.Windows.Forms.MaskedTextBox()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.dgvIncidencias = New System.Windows.Forms.DataGridView()
        Me.Incidencia = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Renglon = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Tipo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DescTipo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Fecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FechaOrd = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Estado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DescEstado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Titulo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Referencia = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Producto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Lote = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ClaveSAC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.dgvIncidencias, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.Panel1.Size = New System.Drawing.Size(968, 50)
        Me.Panel1.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.Control
        Me.Label2.Location = New System.Drawing.Point(25, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(303, 18)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "LISTADO DE INFORMES DE NO CONFORMIDADES"
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Calibri", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.Control
        Me.Label1.Location = New System.Drawing.Point(815, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(143, 24)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "SURFACTAN S.A."
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnNuevaIncidencia)
        Me.GroupBox1.Controls.Add(Me.btnCerrar)
        Me.GroupBox1.Controls.Add(Me.btnFiltrar)
        Me.GroupBox1.Controls.Add(Me.GroupBox4)
        Me.GroupBox1.Controls.Add(Me.GroupBox3)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(10, 10)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(10)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(948, 172)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "PARÁMETROS DE FILTRO"
        '
        'btnNuevaIncidencia
        '
        Me.btnNuevaIncidencia.Location = New System.Drawing.Point(752, 31)
        Me.btnNuevaIncidencia.Name = "btnNuevaIncidencia"
        Me.btnNuevaIncidencia.Size = New System.Drawing.Size(113, 33)
        Me.btnNuevaIncidencia.TabIndex = 3
        Me.btnNuevaIncidencia.Text = "NUEVO IINFORME"
        Me.btnNuevaIncidencia.UseVisualStyleBackColor = True
        '
        'btnCerrar
        '
        Me.btnCerrar.Location = New System.Drawing.Point(809, 79)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(97, 43)
        Me.btnCerrar.TabIndex = 3
        Me.btnCerrar.Text = "CERRAR"
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'btnFiltrar
        '
        Me.btnFiltrar.Location = New System.Drawing.Point(638, 30)
        Me.btnFiltrar.Name = "btnFiltrar"
        Me.btnFiltrar.Size = New System.Drawing.Size(108, 31)
        Me.btnFiltrar.TabIndex = 3
        Me.btnFiltrar.Text = "FILTRAR"
        Me.btnFiltrar.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Button2)
        Me.GroupBox4.Controls.Add(Me.clbTipos)
        Me.GroupBox4.Location = New System.Drawing.Point(433, 25)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(196, 141)
        Me.GroupBox4.TabIndex = 1
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Tipo de Informe de NC"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(16, 115)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(164, 20)
        Me.Button2.TabIndex = 5
        Me.Button2.Text = "Editar Tipos de INC"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'clbTipos
        '
        Me.clbTipos.CheckOnClick = True
        Me.clbTipos.FormattingEnabled = True
        Me.clbTipos.Items.AddRange(New Object() {"TODAS", "INCIDENCIA GENERAL MP/PT", "INCIDENCIA POR RECHAZO DE MP"})
        Me.clbTipos.Location = New System.Drawing.Point(16, 18)
        Me.clbTipos.Name = "clbTipos"
        Me.clbTipos.Size = New System.Drawing.Size(164, 94)
        Me.clbTipos.TabIndex = 2
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Button1)
        Me.GroupBox3.Controls.Add(Me.clbEstados)
        Me.GroupBox3.Location = New System.Drawing.Point(231, 25)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(196, 140)
        Me.GroupBox3.TabIndex = 1
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Estado de Informe de NC"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(19, 115)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(159, 20)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = "Editar Estados"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'clbEstados
        '
        Me.clbEstados.CheckOnClick = True
        Me.clbEstados.FormattingEnabled = True
        Me.clbEstados.Location = New System.Drawing.Point(19, 18)
        Me.clbEstados.Name = "clbEstados"
        Me.clbEstados.Size = New System.Drawing.Size(159, 94)
        Me.clbEstados.TabIndex = 1
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.txtHasta)
        Me.GroupBox2.Controls.Add(Me.txtDesde)
        Me.GroupBox2.Location = New System.Drawing.Point(11, 24)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.GroupBox2.Size = New System.Drawing.Size(207, 50)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Entre Fechas"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(95, 24)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(16, 13)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Al"
        '
        'txtHasta
        '
        Me.txtHasta.Location = New System.Drawing.Point(117, 20)
        Me.txtHasta.Mask = "00/00/0000"
        Me.txtHasta.Name = "txtHasta"
        Me.txtHasta.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtHasta.Size = New System.Drawing.Size(67, 20)
        Me.txtHasta.TabIndex = 0
        Me.txtHasta.Text = "00000000"
        Me.txtHasta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtDesde
        '
        Me.txtDesde.Location = New System.Drawing.Point(22, 20)
        Me.txtDesde.Mask = "00/00/0000"
        Me.txtDesde.Name = "txtDesde"
        Me.txtDesde.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtDesde.Size = New System.Drawing.Size(67, 20)
        Me.txtDesde.TabIndex = 0
        Me.txtDesde.Text = "00000000"
        Me.txtDesde.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.GroupBox1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.dgvIncidencias, 0, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 50)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 192.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(968, 447)
        Me.TableLayoutPanel1.TabIndex = 5
        '
        'dgvIncidencias
        '
        Me.dgvIncidencias.AllowUserToAddRows = False
        Me.dgvIncidencias.AllowUserToDeleteRows = False
        Me.dgvIncidencias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvIncidencias.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Incidencia, Me.Renglon, Me.Tipo, Me.DescTipo, Me.Fecha, Me.FechaOrd, Me.Estado, Me.DescEstado, Me.Titulo, Me.Referencia, Me.Producto, Me.Lote, Me.ClaveSAC})
        Me.dgvIncidencias.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvIncidencias.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dgvIncidencias.Location = New System.Drawing.Point(3, 195)
        Me.dgvIncidencias.Name = "dgvIncidencias"
        Me.dgvIncidencias.ReadOnly = True
        Me.dgvIncidencias.RowHeadersWidth = 15
        Me.dgvIncidencias.RowTemplate.Height = 20
        Me.dgvIncidencias.ShowCellToolTips = False
        Me.dgvIncidencias.Size = New System.Drawing.Size(962, 249)
        Me.dgvIncidencias.TabIndex = 3
        '
        'Incidencia
        '
        Me.Incidencia.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Incidencia.DataPropertyName = "Incidencia"
        Me.Incidencia.HeaderText = "Nro"
        Me.Incidencia.Name = "Incidencia"
        Me.Incidencia.ReadOnly = True
        Me.Incidencia.Width = 49
        '
        'Renglon
        '
        Me.Renglon.DataPropertyName = "Renglon"
        Me.Renglon.HeaderText = "Renglon"
        Me.Renglon.Name = "Renglon"
        Me.Renglon.ReadOnly = True
        Me.Renglon.Visible = False
        '
        'Tipo
        '
        Me.Tipo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Tipo.DataPropertyName = "Tipo"
        Me.Tipo.HeaderText = "Tipo"
        Me.Tipo.Name = "Tipo"
        Me.Tipo.ReadOnly = True
        Me.Tipo.Visible = False
        '
        'DescTipo
        '
        Me.DescTipo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DescTipo.DataPropertyName = "DescTipo"
        Me.DescTipo.HeaderText = "Tipo"
        Me.DescTipo.Name = "DescTipo"
        Me.DescTipo.ReadOnly = True
        Me.DescTipo.Width = 53
        '
        'Fecha
        '
        Me.Fecha.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Fecha.DataPropertyName = "Fecha"
        Me.Fecha.HeaderText = "Fecha"
        Me.Fecha.Name = "Fecha"
        Me.Fecha.ReadOnly = True
        Me.Fecha.Width = 62
        '
        'FechaOrd
        '
        Me.FechaOrd.DataPropertyName = "FechaOrd"
        Me.FechaOrd.HeaderText = "FechaOrd"
        Me.FechaOrd.Name = "FechaOrd"
        Me.FechaOrd.ReadOnly = True
        Me.FechaOrd.Visible = False
        '
        'Estado
        '
        Me.Estado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Estado.DataPropertyName = "Estado"
        Me.Estado.HeaderText = "Estado"
        Me.Estado.Name = "Estado"
        Me.Estado.ReadOnly = True
        Me.Estado.Visible = False
        '
        'DescEstado
        '
        Me.DescEstado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DescEstado.DataPropertyName = "DescEstado"
        Me.DescEstado.HeaderText = "Estado"
        Me.DescEstado.Name = "DescEstado"
        Me.DescEstado.ReadOnly = True
        Me.DescEstado.Width = 65
        '
        'Titulo
        '
        Me.Titulo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Titulo.DataPropertyName = "Titulo"
        Me.Titulo.HeaderText = "Título"
        Me.Titulo.MinimumWidth = 350
        Me.Titulo.Name = "Titulo"
        Me.Titulo.ReadOnly = True
        '
        'Referencia
        '
        Me.Referencia.DataPropertyName = "Referencia"
        Me.Referencia.HeaderText = "Referencia"
        Me.Referencia.MinimumWidth = 350
        Me.Referencia.Name = "Referencia"
        Me.Referencia.ReadOnly = True
        Me.Referencia.Width = 350
        '
        'Producto
        '
        Me.Producto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Producto.DataPropertyName = "Producto"
        Me.Producto.HeaderText = "Producto"
        Me.Producto.Name = "Producto"
        Me.Producto.ReadOnly = True
        Me.Producto.Visible = False
        '
        'Lote
        '
        Me.Lote.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Lote.DataPropertyName = "Lote"
        Me.Lote.HeaderText = "Lote/Partida"
        Me.Lote.Name = "Lote"
        Me.Lote.ReadOnly = True
        Me.Lote.Visible = False
        '
        'ClaveSAC
        '
        Me.ClaveSAC.DataPropertyName = "ClaveSAC"
        Me.ClaveSAC.HeaderText = "ClaveSAC"
        Me.ClaveSAC.Name = "ClaveSAC"
        Me.ClaveSAC.ReadOnly = True
        Me.ClaveSAC.Visible = False
        '
        'ListadoIncidencias
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(968, 497)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "ListadoIncidencias"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.dgvIncidencias, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtHasta As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtDesde As System.Windows.Forms.MaskedTextBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents btnFiltrar As System.Windows.Forms.Button
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents dgvIncidencias As System.Windows.Forms.DataGridView
    Friend WithEvents btnNuevaIncidencia As System.Windows.Forms.Button
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Incidencia As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Renglon As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Tipo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DescTipo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Fecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FechaOrd As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Estado As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DescEstado As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Titulo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Referencia As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Producto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Lote As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ClaveSAC As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clbTipos As System.Windows.Forms.CheckedListBox
    Friend WithEvents clbEstados As System.Windows.Forms.CheckedListBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
