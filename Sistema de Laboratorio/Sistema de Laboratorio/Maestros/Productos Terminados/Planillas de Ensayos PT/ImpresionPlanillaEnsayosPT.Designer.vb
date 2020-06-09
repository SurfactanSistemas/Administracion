<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ImpresionPlanillaEnsayosPT
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnImprimir = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtCodigo = New System.Windows.Forms.MaskedTextBox()
        Me.lblDescTerminado = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtEtapa = New System.Windows.Forms.TextBox()
        Me.btnAyuda = New System.Windows.Forms.Button()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.dgvEspecif = New Util.DBDataGridView()
        Me.Ensayo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DescParametros = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Parametro = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TipoEspecif = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Var1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Var2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Var3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Var4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Var5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Var6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Var7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Var8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Var9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Var10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1.SuspendLayout()
        CType(Me.dgvEspecif, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.Panel1.Size = New System.Drawing.Size(593, 49)
        Me.Panel1.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.Control
        Me.Label2.Location = New System.Drawing.Point(403, 12)
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
        Me.Label1.Size = New System.Drawing.Size(363, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "PLANILLA DE ENSAYOS A REALIZAR EN LABORATORIO"
        '
        'btnImprimir
        '
        Me.btnImprimir.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnImprimir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnImprimir.Location = New System.Drawing.Point(172, 291)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(116, 45)
        Me.btnImprimir.TabIndex = 4
        Me.btnImprimir.Text = "IMPRIMIR"
        Me.btnImprimir.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(11, 60)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(43, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Código:"
        '
        'txtCodigo
        '
        Me.txtCodigo.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtCodigo.Location = New System.Drawing.Point(81, 56)
        Me.txtCodigo.Mask = ">LL-00000-000"
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtCodigo.Size = New System.Drawing.Size(77, 20)
        Me.txtCodigo.TabIndex = 6
        Me.txtCodigo.Text = "PT99999999"
        Me.txtCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblDescTerminado
        '
        Me.lblDescTerminado.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblDescTerminado.BackColor = System.Drawing.Color.Cyan
        Me.lblDescTerminado.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDescTerminado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescTerminado.Location = New System.Drawing.Point(162, 55)
        Me.lblDescTerminado.Name = "lblDescTerminado"
        Me.lblDescTerminado.Size = New System.Drawing.Size(349, 23)
        Me.lblDescTerminado.TabIndex = 5
        Me.lblDescTerminado.Text = "Código:"
        Me.lblDescTerminado.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(514, 60)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(38, 13)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Etapa:"
        '
        'txtEtapa
        '
        Me.txtEtapa.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.txtEtapa.Location = New System.Drawing.Point(555, 56)
        Me.txtEtapa.MaxLength = 2
        Me.txtEtapa.Name = "txtEtapa"
        Me.txtEtapa.Size = New System.Drawing.Size(26, 20)
        Me.txtEtapa.TabIndex = 7
        Me.txtEtapa.Text = "99"
        Me.txtEtapa.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnAyuda
        '
        Me.btnAyuda.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnAyuda.BackgroundImage = Global.Laboratorio.My.Resources.Resources.Consulta_Dat_N1
        Me.btnAyuda.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnAyuda.FlatAppearance.BorderSize = 0
        Me.btnAyuda.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAyuda.Location = New System.Drawing.Point(53, 56)
        Me.btnAyuda.Name = "btnAyuda"
        Me.btnAyuda.Size = New System.Drawing.Size(24, 21)
        Me.btnAyuda.TabIndex = 4
        Me.btnAyuda.UseVisualStyleBackColor = True
        '
        'btnCerrar
        '
        Me.btnCerrar.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnCerrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCerrar.Location = New System.Drawing.Point(304, 291)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(116, 45)
        Me.btnCerrar.TabIndex = 4
        Me.btnCerrar.Text = "CERRAR"
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'dgvEspecif
        '
        Me.dgvEspecif.AllowUserToAddRows = False
        Me.dgvEspecif.AllowUserToDeleteRows = False
        Me.dgvEspecif.AllowUserToOrderColumns = True
        Me.dgvEspecif.AllowUserToResizeColumns = False
        Me.dgvEspecif.AllowUserToResizeRows = False
        Me.dgvEspecif.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvEspecif.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvEspecif.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Ensayo, Me.Descripcion, Me.DescParametros, Me.Parametro, Me.TipoEspecif, Me.Var1, Me.Var2, Me.Var3, Me.Var4, Me.Var5, Me.Var6, Me.Var7, Me.Var8, Me.Var9, Me.Var10})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(232, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvEspecif.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvEspecif.DoubleBuffered = True
        Me.dgvEspecif.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dgvEspecif.Location = New System.Drawing.Point(9, 86)
        Me.dgvEspecif.Name = "dgvEspecif"
        Me.dgvEspecif.OrdenamientoColumnasHabilitado = False
        Me.dgvEspecif.RowHeadersWidth = 15
        Me.dgvEspecif.RowTemplate.Height = 20
        Me.dgvEspecif.ShowCellToolTips = False
        Me.dgvEspecif.SinClickDerecho = False
        Me.dgvEspecif.Size = New System.Drawing.Size(575, 200)
        Me.dgvEspecif.TabIndex = 3
        '
        'Ensayo
        '
        Me.Ensayo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Ensayo.DataPropertyName = "Ensayo"
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle1.Format = "#00"
        DataGridViewCellStyle1.NullValue = Nothing
        Me.Ensayo.DefaultCellStyle = DataGridViewCellStyle1
        Me.Ensayo.HeaderText = "Ens"
        Me.Ensayo.Name = "Ensayo"
        Me.Ensayo.ReadOnly = True
        Me.Ensayo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Ensayo.Width = 34
        '
        'Descripcion
        '
        Me.Descripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Descripcion.DataPropertyName = "Descripcion"
        Me.Descripcion.HeaderText = "Descripción"
        Me.Descripcion.Name = "Descripcion"
        Me.Descripcion.ReadOnly = True
        Me.Descripcion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DescParametros
        '
        Me.DescParametros.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DescParametros.HeaderText = "Desc. Parámetros"
        Me.DescParametros.MinimumWidth = 115
        Me.DescParametros.Name = "DescParametros"
        Me.DescParametros.ReadOnly = True
        Me.DescParametros.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DescParametros.Width = 115
        '
        'Parametro
        '
        Me.Parametro.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Parametro.DataPropertyName = "Parametro"
        Me.Parametro.HeaderText = "Parámetro"
        Me.Parametro.Name = "Parametro"
        Me.Parametro.ReadOnly = True
        Me.Parametro.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Parametro.Width = 64
        '
        'TipoEspecif
        '
        Me.TipoEspecif.HeaderText = "TipoEspecif"
        Me.TipoEspecif.Name = "TipoEspecif"
        Me.TipoEspecif.Visible = False
        '
        'Var1
        '
        Me.Var1.HeaderText = "Var1"
        Me.Var1.Name = "Var1"
        Me.Var1.Visible = False
        '
        'Var2
        '
        Me.Var2.HeaderText = "Var2"
        Me.Var2.Name = "Var2"
        Me.Var2.Visible = False
        '
        'Var3
        '
        Me.Var3.HeaderText = "Var3"
        Me.Var3.Name = "Var3"
        Me.Var3.Visible = False
        '
        'Var4
        '
        Me.Var4.HeaderText = "Var4"
        Me.Var4.Name = "Var4"
        Me.Var4.Visible = False
        '
        'Var5
        '
        Me.Var5.HeaderText = "Var5"
        Me.Var5.Name = "Var5"
        Me.Var5.Visible = False
        '
        'Var6
        '
        Me.Var6.HeaderText = "Var6"
        Me.Var6.Name = "Var6"
        Me.Var6.Visible = False
        '
        'Var7
        '
        Me.Var7.HeaderText = "Var7"
        Me.Var7.Name = "Var7"
        Me.Var7.Visible = False
        '
        'Var8
        '
        Me.Var8.HeaderText = "Var8"
        Me.Var8.Name = "Var8"
        Me.Var8.Visible = False
        '
        'Var9
        '
        Me.Var9.HeaderText = "Var9"
        Me.Var9.Name = "Var9"
        Me.Var9.Visible = False
        '
        'Var10
        '
        Me.Var10.HeaderText = "Var10"
        Me.Var10.Name = "Var10"
        Me.Var10.Visible = False
        '
        'ImpresionPlanillaEnsayosPT
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(593, 341)
        Me.Controls.Add(Me.txtEtapa)
        Me.Controls.Add(Me.txtCodigo)
        Me.Controls.Add(Me.lblDescTerminado)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btnAyuda)
        Me.Controls.Add(Me.btnCerrar)
        Me.Controls.Add(Me.btnImprimir)
        Me.Controls.Add(Me.dgvEspecif)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ImpresionPlanillaEnsayosPT"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dgvEspecif, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dgvEspecif As Util.DBDataGridView
    Friend WithEvents btnImprimir As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtCodigo As System.Windows.Forms.MaskedTextBox
    Friend WithEvents lblDescTerminado As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtEtapa As System.Windows.Forms.TextBox
    Friend WithEvents btnAyuda As System.Windows.Forms.Button
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents Ensayo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Descripcion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DescParametros As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Parametro As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TipoEspecif As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Var1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Var2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Var3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Var4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Var5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Var6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Var7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Var8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Var9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Var10 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
