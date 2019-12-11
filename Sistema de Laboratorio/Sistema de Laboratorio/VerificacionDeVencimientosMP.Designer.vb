<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class VerificacionDeVencimientosMP
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
        Me.mastxtFecha = New System.Windows.Forms.MaskedTextBox()
        Me.mastxtDesdeArt = New System.Windows.Forms.MaskedTextBox()
        Me.mastxtHastaArt = New System.Windows.Forms.MaskedTextBox()
        Me.txtDias = New System.Windows.Forms.TextBox()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnVolver = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.rabtnPantalla = New System.Windows.Forms.RadioButton()
        Me.rabtnImpresora = New System.Windows.Forms.RadioButton()
        Me.prgbar = New System.Windows.Forms.ProgressBar()
        Me.btnBuscarDesde = New System.Windows.Forms.Button()
        Me.btnBuscarHasta = New System.Windows.Forms.Button()
        Me.pnlAyuda = New System.Windows.Forms.Panel()
        Me.txtAyuda = New System.Windows.Forms.TextBox()
        Me.btnPnlVolver = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.DGV_Ayuda = New ConsultasVarias.DBDataGridView()
        Me.Codigo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1.SuspendLayout()
        Me.pnlAyuda.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.DGV_Ayuda, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'mastxtFecha
        '
        Me.mastxtFecha.Location = New System.Drawing.Point(119, 76)
        Me.mastxtFecha.Mask = "00/00/0000"
        Me.mastxtFecha.Name = "mastxtFecha"
        Me.mastxtFecha.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.mastxtFecha.Size = New System.Drawing.Size(100, 20)
        Me.mastxtFecha.TabIndex = 0
        Me.mastxtFecha.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'mastxtDesdeArt
        '
        Me.mastxtDesdeArt.Location = New System.Drawing.Point(119, 117)
        Me.mastxtDesdeArt.Mask = ">LL-000-000"
        Me.mastxtDesdeArt.Name = "mastxtDesdeArt"
        Me.mastxtDesdeArt.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.mastxtDesdeArt.Size = New System.Drawing.Size(100, 20)
        Me.mastxtDesdeArt.TabIndex = 1
        Me.mastxtDesdeArt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'mastxtHastaArt
        '
        Me.mastxtHastaArt.Location = New System.Drawing.Point(119, 156)
        Me.mastxtHastaArt.Mask = ">LL-000-000"
        Me.mastxtHastaArt.Name = "mastxtHastaArt"
        Me.mastxtHastaArt.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.mastxtHastaArt.Size = New System.Drawing.Size(100, 20)
        Me.mastxtHastaArt.TabIndex = 2
        Me.mastxtHastaArt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtDias
        '
        Me.txtDias.Location = New System.Drawing.Point(119, 199)
        Me.txtDias.Name = "txtDias"
        Me.txtDias.Size = New System.Drawing.Size(100, 20)
        Me.txtDias.TabIndex = 3
        Me.txtDias.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(389, 97)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(75, 23)
        Me.btnAceptar.TabIndex = 4
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'btnVolver
        '
        Me.btnVolver.Location = New System.Drawing.Point(389, 138)
        Me.btnVolver.Name = "btnVolver"
        Me.btnVolver.Size = New System.Drawing.Size(75, 23)
        Me.btnVolver.TabIndex = 5
        Me.btnVolver.Text = "Volver"
        Me.btnVolver.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(27, 79)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(37, 13)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Fecha"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(25, 120)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 13)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Desde Articulo"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(27, 159)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(70, 13)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "HastaArticulo"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(27, 201)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(28, 13)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Dias"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(496, 70)
        Me.Panel1.TabIndex = 11
        '
        'Label6
        '
        Me.Label6.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.Control
        Me.Label6.Location = New System.Drawing.Point(12, 9)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(246, 20)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "Verificacion de Vencimientos "
        '
        'Label5
        '
        Me.Label5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.Control
        Me.Label5.Location = New System.Drawing.Point(305, 35)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(179, 24)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "SURFACTAN S.A."
        '
        'rabtnPantalla
        '
        Me.rabtnPantalla.AutoSize = True
        Me.rabtnPantalla.Checked = True
        Me.rabtnPantalla.Location = New System.Drawing.Point(271, 121)
        Me.rabtnPantalla.Name = "rabtnPantalla"
        Me.rabtnPantalla.Size = New System.Drawing.Size(63, 17)
        Me.rabtnPantalla.TabIndex = 12
        Me.rabtnPantalla.TabStop = True
        Me.rabtnPantalla.Text = "Pantalla"
        Me.rabtnPantalla.UseVisualStyleBackColor = True
        '
        'rabtnImpresora
        '
        Me.rabtnImpresora.AutoSize = True
        Me.rabtnImpresora.Location = New System.Drawing.Point(271, 166)
        Me.rabtnImpresora.Name = "rabtnImpresora"
        Me.rabtnImpresora.Size = New System.Drawing.Size(71, 17)
        Me.rabtnImpresora.TabIndex = 13
        Me.rabtnImpresora.Text = "Impresora"
        Me.rabtnImpresora.UseVisualStyleBackColor = True
        '
        'prgbar
        '
        Me.prgbar.Location = New System.Drawing.Point(234, 73)
        Me.prgbar.Maximum = 500
        Me.prgbar.Name = "prgbar"
        Me.prgbar.Size = New System.Drawing.Size(250, 18)
        Me.prgbar.TabIndex = 14
        Me.prgbar.Visible = False
        '
        'btnBuscarDesde
        '
        Me.btnBuscarDesde.Location = New System.Drawing.Point(226, 117)
        Me.btnBuscarDesde.Name = "btnBuscarDesde"
        Me.btnBuscarDesde.Size = New System.Drawing.Size(20, 20)
        Me.btnBuscarDesde.TabIndex = 15
        Me.btnBuscarDesde.UseVisualStyleBackColor = True
        '
        'btnBuscarHasta
        '
        Me.btnBuscarHasta.Location = New System.Drawing.Point(226, 156)
        Me.btnBuscarHasta.Name = "btnBuscarHasta"
        Me.btnBuscarHasta.Size = New System.Drawing.Size(20, 20)
        Me.btnBuscarHasta.TabIndex = 16
        Me.btnBuscarHasta.UseVisualStyleBackColor = True
        '
        'pnlAyuda
        '
        Me.pnlAyuda.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlAyuda.Controls.Add(Me.txtAyuda)
        Me.pnlAyuda.Controls.Add(Me.btnPnlVolver)
        Me.pnlAyuda.Controls.Add(Me.Panel2)
        Me.pnlAyuda.Controls.Add(Me.DGV_Ayuda)
        Me.pnlAyuda.Location = New System.Drawing.Point(43, 3)
        Me.pnlAyuda.Name = "pnlAyuda"
        Me.pnlAyuda.Size = New System.Drawing.Size(420, 242)
        Me.pnlAyuda.TabIndex = 3
        Me.pnlAyuda.Visible = False
        '
        'txtAyuda
        '
        Me.txtAyuda.Location = New System.Drawing.Point(10, 34)
        Me.txtAyuda.Name = "txtAyuda"
        Me.txtAyuda.Size = New System.Drawing.Size(399, 20)
        Me.txtAyuda.TabIndex = 3
        '
        'btnPnlVolver
        '
        Me.btnPnlVolver.Location = New System.Drawing.Point(164, 211)
        Me.btnPnlVolver.Name = "btnPnlVolver"
        Me.btnPnlVolver.Size = New System.Drawing.Size(75, 22)
        Me.btnPnlVolver.TabIndex = 2
        Me.btnPnlVolver.Text = "Volver"
        Me.btnPnlVolver.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(416, 29)
        Me.Panel2.TabIndex = 1
        '
        'Label7
        '
        Me.Label7.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.Control
        Me.Label7.Location = New System.Drawing.Point(5, 4)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(59, 20)
        Me.Label7.TabIndex = 3
        Me.Label7.Text = "Ayuda"
        '
        'DGV_Ayuda
        '
        Me.DGV_Ayuda.AllowUserToAddRows = False
        Me.DGV_Ayuda.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_Ayuda.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Codigo, Me.Descripcion})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(232, Byte), Integer))
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGV_Ayuda.DefaultCellStyle = DataGridViewCellStyle3
        Me.DGV_Ayuda.DoubleBuffered = True
        Me.DGV_Ayuda.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.DGV_Ayuda.Location = New System.Drawing.Point(10, 58)
        Me.DGV_Ayuda.Name = "DGV_Ayuda"
        Me.DGV_Ayuda.OrdenamientoColumnasHabilitado = True
        Me.DGV_Ayuda.RowHeadersWidth = 15
        Me.DGV_Ayuda.RowTemplate.Height = 20
        Me.DGV_Ayuda.ShowCellToolTips = False
        Me.DGV_Ayuda.SinClickDerecho = False
        Me.DGV_Ayuda.Size = New System.Drawing.Size(399, 150)
        Me.DGV_Ayuda.TabIndex = 0
        '
        'Codigo
        '
        Me.Codigo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Codigo.DataPropertyName = "Codigo"
        Me.Codigo.HeaderText = "Codigo"
        Me.Codigo.Name = "Codigo"
        Me.Codigo.Width = 65
        '
        'Descripcion
        '
        Me.Descripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Descripcion.DataPropertyName = "Descripcion"
        Me.Descripcion.HeaderText = "Descripcion"
        Me.Descripcion.Name = "Descripcion"
        '
        'VerificacionDeVencimientosMP
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(496, 244)
        Me.Controls.Add(Me.pnlAyuda)
        Me.Controls.Add(Me.btnBuscarHasta)
        Me.Controls.Add(Me.btnBuscarDesde)
        Me.Controls.Add(Me.prgbar)
        Me.Controls.Add(Me.rabtnImpresora)
        Me.Controls.Add(Me.rabtnPantalla)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnVolver)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.txtDias)
        Me.Controls.Add(Me.mastxtHastaArt)
        Me.Controls.Add(Me.mastxtDesdeArt)
        Me.Controls.Add(Me.mastxtFecha)
        Me.Name = "VerificacionDeVencimientosMP"
        Me.Text = "VerificacionDeVencimientosMP"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.pnlAyuda.ResumeLayout(False)
        Me.pnlAyuda.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.DGV_Ayuda, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents mastxtFecha As System.Windows.Forms.MaskedTextBox
    Friend WithEvents mastxtDesdeArt As System.Windows.Forms.MaskedTextBox
    Friend WithEvents mastxtHastaArt As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtDias As System.Windows.Forms.TextBox
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents btnVolver As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents rabtnPantalla As System.Windows.Forms.RadioButton
    Friend WithEvents rabtnImpresora As System.Windows.Forms.RadioButton
    Friend WithEvents prgbar As System.Windows.Forms.ProgressBar
    Friend WithEvents btnBuscarDesde As System.Windows.Forms.Button
    Friend WithEvents btnBuscarHasta As System.Windows.Forms.Button
    Friend WithEvents pnlAyuda As System.Windows.Forms.Panel
    Friend WithEvents btnPnlVolver As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents DGV_Ayuda As ConsultasVarias.DBDataGridView
    Friend WithEvents txtAyuda As System.Windows.Forms.TextBox
    Friend WithEvents Codigo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Descripcion As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
