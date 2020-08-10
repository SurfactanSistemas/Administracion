<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ComposicionProducto
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
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtProducto = New System.Windows.Forms.MaskedTextBox()
        Me.lblDescProducto = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblVersion = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblFecha = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lblEstado = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.lblResponsable = New System.Windows.Forms.Label()
        Me.btnGrabar = New System.Windows.Forms.Button()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.btnConsulta = New System.Windows.Forms.Button()
        Me.btnRevalida = New System.Windows.Forms.Button()
        Me.btnBloqueo = New System.Windows.Forms.Button()
        Me.btnDatosAdicionales = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtRefLaboratorio = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtObservaciones = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtControlCambios = New System.Windows.Forms.TextBox()
        Me.btnCaratula = New System.Windows.Forms.Button()
        Me.btnPTConSedronar = New System.Windows.Forms.Button()
        Me.btnComposicionSedronar = New System.Windows.Forms.Button()
        Me.dgvComponentes = New Util.DBDataGridView()
        Me.Tipo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Terminado = New Util.MyMaskedTextBoxColumn()
        Me.Articulo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cantidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.panel1.SuspendLayout()
        CType(Me.dgvComponentes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'panel1
        '
        Me.panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(34, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.panel1.Controls.Add(Me.Label2)
        Me.panel1.Controls.Add(Me.label1)
        Me.panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.panel1.Location = New System.Drawing.Point(0, 0)
        Me.panel1.Name = "panel1"
        Me.panel1.Size = New System.Drawing.Size(710, 40)
        Me.panel1.TabIndex = 40
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(534, 10)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(155, 20)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "SURFACTAN S.A."
        '
        'label1
        '
        Me.label1.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.label1.AutoSize = True
        Me.label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.label1.ForeColor = System.Drawing.Color.White
        Me.label1.Location = New System.Drawing.Point(21, 12)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(210, 17)
        Me.label1.TabIndex = 0
        Me.label1.Text = "COMPOSICIÓN DE PRODUCTO"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(15, 49)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(68, 13)
        Me.Label3.TabIndex = 42
        Me.Label3.Text = "PRODUCTO"
        '
        'txtProducto
        '
        Me.txtProducto.Location = New System.Drawing.Point(89, 46)
        Me.txtProducto.Mask = ">LL-00000-000"
        Me.txtProducto.Name = "txtProducto"
        Me.txtProducto.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtProducto.Size = New System.Drawing.Size(79, 20)
        Me.txtProducto.TabIndex = 43
        Me.txtProducto.Text = "PT99999999"
        Me.txtProducto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblDescProducto
        '
        Me.lblDescProducto.BackColor = System.Drawing.Color.Cyan
        Me.lblDescProducto.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDescProducto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescProducto.Location = New System.Drawing.Point(174, 46)
        Me.lblDescProducto.Name = "lblDescProducto"
        Me.lblDescProducto.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.lblDescProducto.Size = New System.Drawing.Size(522, 21)
        Me.lblDescProducto.TabIndex = 42
        Me.lblDescProducto.Text = "PRODUCTO"
        Me.lblDescProducto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(15, 76)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(55, 13)
        Me.Label5.TabIndex = 42
        Me.Label5.Text = "VERSIÓN"
        '
        'lblVersion
        '
        Me.lblVersion.BackColor = System.Drawing.Color.Cyan
        Me.lblVersion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblVersion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVersion.Location = New System.Drawing.Point(74, 72)
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.Size = New System.Drawing.Size(29, 21)
        Me.lblVersion.TabIndex = 42
        Me.lblVersion.Text = "1"
        Me.lblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(115, 76)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(42, 13)
        Me.Label7.TabIndex = 42
        Me.Label7.Text = "FECHA"
        '
        'lblFecha
        '
        Me.lblFecha.BackColor = System.Drawing.Color.Cyan
        Me.lblFecha.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFecha.Location = New System.Drawing.Point(163, 72)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(87, 21)
        Me.lblFecha.TabIndex = 42
        Me.lblFecha.Text = "00/00/0000"
        Me.lblFecha.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(260, 76)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(51, 13)
        Me.Label9.TabIndex = 42
        Me.Label9.Text = "ESTADO"
        '
        'lblEstado
        '
        Me.lblEstado.BackColor = System.Drawing.Color.Cyan
        Me.lblEstado.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblEstado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstado.Location = New System.Drawing.Point(317, 72)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.lblEstado.Size = New System.Drawing.Size(28, 21)
        Me.lblEstado.TabIndex = 42
        Me.lblEstado.Text = "N"
        Me.lblEstado.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(355, 76)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(86, 13)
        Me.Label11.TabIndex = 42
        Me.Label11.Text = "RESPONSABLE"
        '
        'lblResponsable
        '
        Me.lblResponsable.BackColor = System.Drawing.Color.Cyan
        Me.lblResponsable.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblResponsable.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblResponsable.Location = New System.Drawing.Point(447, 72)
        Me.lblResponsable.Name = "lblResponsable"
        Me.lblResponsable.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.lblResponsable.Size = New System.Drawing.Size(249, 21)
        Me.lblResponsable.TabIndex = 42
        Me.lblResponsable.Text = "N"
        Me.lblResponsable.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnGrabar
        '
        Me.btnGrabar.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnGrabar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGrabar.Location = New System.Drawing.Point(38, 420)
        Me.btnGrabar.Name = "btnGrabar"
        Me.btnGrabar.Size = New System.Drawing.Size(95, 43)
        Me.btnGrabar.TabIndex = 44
        Me.btnGrabar.Text = "GRABAR"
        Me.btnGrabar.UseVisualStyleBackColor = True
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnLimpiar.Location = New System.Drawing.Point(146, 420)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(95, 43)
        Me.btnLimpiar.TabIndex = 44
        Me.btnLimpiar.Text = "LIMPIAR"
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'btnCerrar
        '
        Me.btnCerrar.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnCerrar.Location = New System.Drawing.Point(254, 420)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(95, 43)
        Me.btnCerrar.TabIndex = 44
        Me.btnCerrar.Text = "CERRAR"
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'btnConsulta
        '
        Me.btnConsulta.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnConsulta.Location = New System.Drawing.Point(362, 420)
        Me.btnConsulta.Name = "btnConsulta"
        Me.btnConsulta.Size = New System.Drawing.Size(95, 43)
        Me.btnConsulta.TabIndex = 44
        Me.btnConsulta.Text = "CONSULTA"
        Me.btnConsulta.UseVisualStyleBackColor = True
        '
        'btnRevalida
        '
        Me.btnRevalida.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnRevalida.Location = New System.Drawing.Point(470, 420)
        Me.btnRevalida.Name = "btnRevalida"
        Me.btnRevalida.Size = New System.Drawing.Size(95, 43)
        Me.btnRevalida.TabIndex = 44
        Me.btnRevalida.Text = "REVALIDA"
        Me.btnRevalida.UseVisualStyleBackColor = True
        '
        'btnBloqueo
        '
        Me.btnBloqueo.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnBloqueo.Location = New System.Drawing.Point(578, 420)
        Me.btnBloqueo.Name = "btnBloqueo"
        Me.btnBloqueo.Size = New System.Drawing.Size(95, 43)
        Me.btnBloqueo.TabIndex = 44
        Me.btnBloqueo.Text = "BLOQUEO"
        Me.btnBloqueo.UseVisualStyleBackColor = True
        '
        'btnDatosAdicionales
        '
        Me.btnDatosAdicionales.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnDatosAdicionales.Location = New System.Drawing.Point(361, 324)
        Me.btnDatosAdicionales.Name = "btnDatosAdicionales"
        Me.btnDatosAdicionales.Size = New System.Drawing.Size(95, 37)
        Me.btnDatosAdicionales.TabIndex = 44
        Me.btnDatosAdicionales.Text = "DATOS ADICIONALES"
        Me.btnDatosAdicionales.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(25, 343)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(111, 13)
        Me.Label4.TabIndex = 42
        Me.Label4.Text = "REF. LABORATORIO"
        '
        'txtRefLaboratorio
        '
        Me.txtRefLaboratorio.Location = New System.Drawing.Point(142, 339)
        Me.txtRefLaboratorio.Name = "txtRefLaboratorio"
        Me.txtRefLaboratorio.Size = New System.Drawing.Size(129, 20)
        Me.txtRefLaboratorio.TabIndex = 45
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(38, 368)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(98, 13)
        Me.Label6.TabIndex = 42
        Me.Label6.Text = "OBSERVACIONES"
        '
        'txtObservaciones
        '
        Me.txtObservaciones.Location = New System.Drawing.Point(142, 364)
        Me.txtObservaciones.Name = "txtObservaciones"
        Me.txtObservaciones.Size = New System.Drawing.Size(415, 20)
        Me.txtObservaciones.TabIndex = 45
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(8, 393)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(128, 13)
        Me.Label8.TabIndex = 42
        Me.Label8.Text = "CONTROL DE CAMBIOS"
        '
        'txtControlCambios
        '
        Me.txtControlCambios.Location = New System.Drawing.Point(142, 389)
        Me.txtControlCambios.Name = "txtControlCambios"
        Me.txtControlCambios.Size = New System.Drawing.Size(415, 20)
        Me.txtControlCambios.TabIndex = 45
        '
        'btnCaratula
        '
        Me.btnCaratula.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnCaratula.Location = New System.Drawing.Point(462, 324)
        Me.btnCaratula.Name = "btnCaratula"
        Me.btnCaratula.Size = New System.Drawing.Size(95, 37)
        Me.btnCaratula.TabIndex = 44
        Me.btnCaratula.Text = "CARÁTULA"
        Me.btnCaratula.UseVisualStyleBackColor = True
        '
        'btnPTConSedronar
        '
        Me.btnPTConSedronar.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnPTConSedronar.Location = New System.Drawing.Point(563, 324)
        Me.btnPTConSedronar.Name = "btnPTConSedronar"
        Me.btnPTConSedronar.Size = New System.Drawing.Size(143, 37)
        Me.btnPTConSedronar.TabIndex = 44
        Me.btnPTConSedronar.Text = "PT's CON MP SEDRONAR"
        Me.btnPTConSedronar.UseVisualStyleBackColor = True
        '
        'btnComposicionSedronar
        '
        Me.btnComposicionSedronar.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnComposicionSedronar.Location = New System.Drawing.Point(563, 367)
        Me.btnComposicionSedronar.Name = "btnComposicionSedronar"
        Me.btnComposicionSedronar.Size = New System.Drawing.Size(143, 42)
        Me.btnComposicionSedronar.TabIndex = 44
        Me.btnComposicionSedronar.Text = "COMPOSICIÓN % SEDRONAR"
        Me.btnComposicionSedronar.UseVisualStyleBackColor = True
        '
        'dgvComponentes
        '
        Me.dgvComponentes.AllowUserToAddRows = False
        Me.dgvComponentes.AllowUserToDeleteRows = False
        Me.dgvComponentes.AllowUserToResizeColumns = False
        Me.dgvComponentes.AllowUserToResizeRows = False
        Me.dgvComponentes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvComponentes.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Tipo, Me.Terminado, Me.Articulo, Me.Descripcion, Me.Cantidad})
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(232, Byte), Integer))
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvComponentes.DefaultCellStyle = DataGridViewCellStyle8
        Me.dgvComponentes.DoubleBuffered = True
        Me.dgvComponentes.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dgvComponentes.Location = New System.Drawing.Point(4, 98)
        Me.dgvComponentes.Name = "dgvComponentes"
        Me.dgvComponentes.OrdenamientoColumnasHabilitado = False
        Me.dgvComponentes.RowHeadersWidth = 15
        Me.dgvComponentes.RowTemplate.Height = 20
        Me.dgvComponentes.ShowCellToolTips = False
        Me.dgvComponentes.SinClickDerecho = False
        Me.dgvComponentes.Size = New System.Drawing.Size(702, 221)
        Me.dgvComponentes.TabIndex = 41
        '
        'Tipo
        '
        Me.Tipo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Tipo.DataPropertyName = "Tipo"
        Me.Tipo.HeaderText = "Tipo"
        Me.Tipo.MaxInputLength = 1
        Me.Tipo.Name = "Tipo"
        Me.Tipo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Tipo.Width = 34
        '
        'Terminado
        '
        Me.Terminado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Terminado.DataPropertyName = "Terminado"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Terminado.DefaultCellStyle = DataGridViewCellStyle5
        Me.Terminado.HeaderText = "Prod. Term."
        Me.Terminado.IncludeLiterals = True
        Me.Terminado.IncludePrompt = True
        Me.Terminado.Mask = ">LL-00000-000"
        Me.Terminado.Name = "Terminado"
        Me.Terminado.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.Terminado.ReadOnly = True
        Me.Terminado.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Terminado.ValidatingType = Nothing
        Me.Terminado.Width = 68
        '
        'Articulo
        '
        Me.Articulo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Articulo.DataPropertyName = "Articulo"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Articulo.DefaultCellStyle = DataGridViewCellStyle6
        Me.Articulo.HeaderText = "Mat. Prima"
        Me.Articulo.Name = "Articulo"
        Me.Articulo.ReadOnly = True
        Me.Articulo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Articulo.Width = 63
        '
        'Descripcion
        '
        Me.Descripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Descripcion.DataPropertyName = "Descripcion"
        Me.Descripcion.HeaderText = "Descripcion"
        Me.Descripcion.Name = "Descripcion"
        Me.Descripcion.ReadOnly = True
        Me.Descripcion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Cantidad
        '
        Me.Cantidad.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Cantidad.DataPropertyName = "Cantidad"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle7.Format = "N5"
        DataGridViewCellStyle7.NullValue = "0"
        Me.Cantidad.DefaultCellStyle = DataGridViewCellStyle7
        Me.Cantidad.HeaderText = "Cantidad"
        Me.Cantidad.Name = "Cantidad"
        Me.Cantidad.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Cantidad.Width = 55
        '
        'ComposicionProducto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(710, 471)
        Me.Controls.Add(Me.txtControlCambios)
        Me.Controls.Add(Me.txtObservaciones)
        Me.Controls.Add(Me.txtRefLaboratorio)
        Me.Controls.Add(Me.btnComposicionSedronar)
        Me.Controls.Add(Me.btnPTConSedronar)
        Me.Controls.Add(Me.btnCaratula)
        Me.Controls.Add(Me.btnDatosAdicionales)
        Me.Controls.Add(Me.btnBloqueo)
        Me.Controls.Add(Me.btnConsulta)
        Me.Controls.Add(Me.btnCerrar)
        Me.Controls.Add(Me.btnRevalida)
        Me.Controls.Add(Me.btnLimpiar)
        Me.Controls.Add(Me.btnGrabar)
        Me.Controls.Add(Me.txtProducto)
        Me.Controls.Add(Me.lblResponsable)
        Me.Controls.Add(Me.lblEstado)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.lblFecha)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.lblVersion)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.lblDescProducto)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.dgvComponentes)
        Me.Controls.Add(Me.panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Location = New System.Drawing.Point(20, 20)
        Me.MaximizeBox = False
        Me.Name = "ComposicionProducto"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.panel1.ResumeLayout(False)
        Me.panel1.PerformLayout()
        CType(Me.dgvComponentes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents panel1 As System.Windows.Forms.Panel
    Private WithEvents Label2 As System.Windows.Forms.Label
    Private WithEvents label1 As System.Windows.Forms.Label
    Friend WithEvents dgvComponentes As Util.DBDataGridView
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtProducto As System.Windows.Forms.MaskedTextBox
    Friend WithEvents lblDescProducto As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblVersion As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lblFecha As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lblEstado As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents lblResponsable As System.Windows.Forms.Label
    Friend WithEvents btnGrabar As System.Windows.Forms.Button
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents btnConsulta As System.Windows.Forms.Button
    Friend WithEvents btnRevalida As System.Windows.Forms.Button
    Friend WithEvents btnBloqueo As System.Windows.Forms.Button
    Friend WithEvents btnDatosAdicionales As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtRefLaboratorio As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtObservaciones As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtControlCambios As System.Windows.Forms.TextBox
    Friend WithEvents btnCaratula As System.Windows.Forms.Button
    Friend WithEvents btnPTConSedronar As System.Windows.Forms.Button
    Friend WithEvents btnComposicionSedronar As System.Windows.Forms.Button
    Friend WithEvents Tipo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Terminado As Util.MyMaskedTextBoxColumn
    Friend WithEvents Articulo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Descripcion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cantidad As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
