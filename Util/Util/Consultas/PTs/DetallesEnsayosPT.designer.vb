<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DetallesEnsayosPT
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
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtCodigo = New System.Windows.Forms.MaskedTextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtLote = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtLoteProv = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtFecha = New System.Windows.Forms.MaskedTextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtCantidad = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtInforme = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtProveedor = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtOrden = New System.Windows.Forms.TextBox()
        Me.txtDescMP = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.txtSaldo = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtConfecciono = New System.Windows.Forms.TextBox()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Ensayo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ValorStd = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ValorReg = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Desde = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Hasta = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Valor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1031, 62)
        Me.Panel1.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.Control
        Me.Label2.Location = New System.Drawing.Point(33, 20)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(323, 23)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "ENSAYOS DE PRODUCTOS TERMINADOS"
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.Control
        Me.Label1.Location = New System.Drawing.Point(871, 20)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(140, 23)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "SURFACTAN S.A."
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Ensayo, Me.ValorStd, Me.ValorReg, Me.Desde, Me.Hasta, Me.Valor})
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.DataGridView1.Location = New System.Drawing.Point(0, 147)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersWidth = 10
        Me.DataGridView1.RowTemplate.Height = 20
        Me.DataGridView1.ShowCellToolTips = False
        Me.DataGridView1.Size = New System.Drawing.Size(1031, 364)
        Me.DataGridView1.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(17, 73)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 17)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Código:"
        '
        'txtCodigo
        '
        Me.txtCodigo.Location = New System.Drawing.Point(80, 68)
        Me.txtCodigo.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtCodigo.Mask = ">LL-00000-000"
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.ReadOnly = True
        Me.txtCodigo.Size = New System.Drawing.Size(105, 22)
        Me.txtCodigo.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(9, 111)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(57, 17)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Partida:"
        '
        'txtLote
        '
        Me.txtLote.Location = New System.Drawing.Point(75, 106)
        Me.txtLote.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtLote.Name = "txtLote"
        Me.txtLote.ReadOnly = True
        Me.txtLote.Size = New System.Drawing.Size(81, 22)
        Me.txtLote.TabIndex = 9
        Me.txtLote.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(76, 137)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(73, 17)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Lote Prov:"
        Me.Label5.Visible = False
        '
        'txtLoteProv
        '
        Me.txtLoteProv.Location = New System.Drawing.Point(159, 132)
        Me.txtLoteProv.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtLoteProv.Name = "txtLoteProv"
        Me.txtLoteProv.ReadOnly = True
        Me.txtLoteProv.Size = New System.Drawing.Size(149, 22)
        Me.txtLoteProv.TabIndex = 9
        Me.txtLoteProv.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtLoteProv.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(661, 71)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(51, 17)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Fecha:"
        '
        'txtFecha
        '
        Me.txtFecha.Location = New System.Drawing.Point(720, 66)
        Me.txtFecha.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtFecha.Mask = "00/00/0000"
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.ReadOnly = True
        Me.txtFecha.Size = New System.Drawing.Size(88, 22)
        Me.txtFecha.TabIndex = 7
        Me.txtFecha.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(389, 111)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(68, 17)
        Me.Label7.TabIndex = 8
        Me.Label7.Text = "Cantidad:"
        '
        'txtCantidad
        '
        Me.txtCantidad.Location = New System.Drawing.Point(461, 106)
        Me.txtCantidad.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtCantidad.Name = "txtCantidad"
        Me.txtCantidad.ReadOnly = True
        Me.txtCantidad.Size = New System.Drawing.Size(108, 22)
        Me.txtCantidad.TabIndex = 9
        Me.txtCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(19, 137)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(59, 17)
        Me.Label8.TabIndex = 8
        Me.Label8.Text = "Informe:"
        Me.Label8.Visible = False
        '
        'txtInforme
        '
        Me.txtInforme.Location = New System.Drawing.Point(41, 132)
        Me.txtInforme.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtInforme.Name = "txtInforme"
        Me.txtInforme.ReadOnly = True
        Me.txtInforme.Size = New System.Drawing.Size(12, 22)
        Me.txtInforme.TabIndex = 9
        Me.txtInforme.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtInforme.Visible = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(27, 137)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(41, 17)
        Me.Label9.TabIndex = 8
        Me.Label9.Text = "Prov:"
        Me.Label9.Visible = False
        '
        'txtProveedor
        '
        Me.txtProveedor.BackColor = System.Drawing.Color.FromArgb(CType(CType(14, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.txtProveedor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtProveedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProveedor.Location = New System.Drawing.Point(37, 132)
        Me.txtProveedor.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtProveedor.Name = "txtProveedor"
        Me.txtProveedor.ReadOnly = True
        Me.txtProveedor.Size = New System.Drawing.Size(21, 23)
        Me.txtProveedor.TabIndex = 9
        Me.txtProveedor.Visible = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(23, 137)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(52, 17)
        Me.Label10.TabIndex = 8
        Me.Label10.Text = "Orden:"
        Me.Label10.Visible = False
        '
        'txtOrden
        '
        Me.txtOrden.Location = New System.Drawing.Point(41, 132)
        Me.txtOrden.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtOrden.Name = "txtOrden"
        Me.txtOrden.ReadOnly = True
        Me.txtOrden.Size = New System.Drawing.Size(12, 22)
        Me.txtOrden.TabIndex = 9
        Me.txtOrden.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtOrden.Visible = False
        '
        'txtDescMP
        '
        Me.txtDescMP.BackColor = System.Drawing.Color.Cyan
        Me.txtDescMP.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDescMP.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescMP.Location = New System.Drawing.Point(195, 68)
        Me.txtDescMP.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtDescMP.Name = "txtDescMP"
        Me.txtDescMP.ReadOnly = True
        Me.txtDescMP.Size = New System.Drawing.Size(457, 23)
        Me.txtDescMP.TabIndex = 9
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(813, 97)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(217, 44)
        Me.Button1.TabIndex = 10
        Me.Button1.Text = "CERRAR VENTANA ENSAYOS"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'txtSaldo
        '
        Me.txtSaldo.Location = New System.Drawing.Point(640, 106)
        Me.txtSaldo.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtSaldo.Name = "txtSaldo"
        Me.txtSaldo.ReadOnly = True
        Me.txtSaldo.Size = New System.Drawing.Size(108, 22)
        Me.txtSaldo.TabIndex = 12
        Me.txtSaldo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(584, 111)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(48, 17)
        Me.Label11.TabIndex = 11
        Me.Label11.Text = "Saldo:"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(167, 111)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(90, 17)
        Me.Label12.TabIndex = 8
        Me.Label12.Text = "Confeccionó:"
        '
        'txtConfecciono
        '
        Me.txtConfecciono.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtConfecciono.Location = New System.Drawing.Point(260, 106)
        Me.txtConfecciono.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtConfecciono.Name = "txtConfecciono"
        Me.txtConfecciono.ReadOnly = True
        Me.txtConfecciono.Size = New System.Drawing.Size(119, 22)
        Me.txtConfecciono.TabIndex = 9
        '
        'BackgroundWorker1
        '
        Me.BackgroundWorker1.WorkerReportsProgress = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(813, 65)
        Me.Button2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(217, 30)
        Me.Button2.TabIndex = 10
        Me.Button2.Text = "VER HOJA PROD."
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Ensayo
        '
        Me.Ensayo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Ensayo.DataPropertyName = "Ensayo"
        Me.Ensayo.HeaderText = "Ensayo"
        Me.Ensayo.Name = "Ensayo"
        Me.Ensayo.ReadOnly = True
        Me.Ensayo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Ensayo.Width = 61
        '
        'ValorStd
        '
        Me.ValorStd.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.ValorStd.DataPropertyName = "ValorStd"
        Me.ValorStd.HeaderText = "Valor Standard"
        Me.ValorStd.Name = "ValorStd"
        Me.ValorStd.ReadOnly = True
        Me.ValorStd.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'ValorReg
        '
        Me.ValorReg.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.ValorReg.DataPropertyName = "ValorReg"
        Me.ValorReg.HeaderText = "Valor Registrado"
        Me.ValorReg.MinimumWidth = 120
        Me.ValorReg.Name = "ValorReg"
        Me.ValorReg.ReadOnly = True
        Me.ValorReg.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ValorReg.Width = 120
        '
        'Desde
        '
        Me.Desde.DataPropertyName = "Desde"
        Me.Desde.HeaderText = "Desde"
        Me.Desde.Name = "Desde"
        Me.Desde.ReadOnly = True
        Me.Desde.Width = 60
        '
        'Hasta
        '
        Me.Hasta.DataPropertyName = "Hasta"
        Me.Hasta.HeaderText = "Hasta"
        Me.Hasta.Name = "Hasta"
        Me.Hasta.ReadOnly = True
        Me.Hasta.Width = 60
        '
        'Valor
        '
        Me.Valor.DataPropertyName = "Valor"
        Me.Valor.HeaderText = "Valor"
        Me.Valor.Name = "Valor"
        Me.Valor.ReadOnly = True
        Me.Valor.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Valor.Visible = False
        '
        'DetallesEnsayosPT
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1031, 511)
        Me.Controls.Add(Me.txtSaldo)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.txtDescMP)
        Me.Controls.Add(Me.txtProveedor)
        Me.Controls.Add(Me.txtLoteProv)
        Me.Controls.Add(Me.txtOrden)
        Me.Controls.Add(Me.txtInforme)
        Me.Controls.Add(Me.txtConfecciono)
        Me.Controls.Add(Me.txtCantidad)
        Me.Controls.Add(Me.txtLote)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtFecha)
        Me.Controls.Add(Me.txtCodigo)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DetallesEnsayosPT"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtCodigo As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtLote As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtLoteProv As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtFecha As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtCantidad As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtInforme As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtProveedor As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtOrden As System.Windows.Forms.TextBox
    Friend WithEvents txtDescMP As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents txtSaldo As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtConfecciono As System.Windows.Forms.TextBox
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Ensayo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ValorStd As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ValorReg As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Desde As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Hasta As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Valor As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
