<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class IngresoTalonInventario
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
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtNroMovimiento = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dgvTalones = New System.Windows.Forms.DataGridView()
        Me.Talon = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Tipo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Terminado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Articulo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Lote = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cantidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Ubicacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Observaciones = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnGrabar = New System.Windows.Forms.Button()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.txtTerminadoAux = New System.Windows.Forms.MaskedTextBox()
        Me.txtArticuloAux = New System.Windows.Forms.MaskedTextBox()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvTalones, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.Panel1.Size = New System.Drawing.Size(812, 54)
        Me.Panel1.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Calibri", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.Control
        Me.Label2.Location = New System.Drawing.Point(582, 14)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(158, 27)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "SURFACTAN S.A."
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.Control
        Me.Label1.Location = New System.Drawing.Point(25, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(217, 19)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Ingreso de Talón de Inventario"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtNroMovimiento)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Location = New System.Drawing.Point(16, 56)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(780, 48)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        '
        'txtNroMovimiento
        '
        Me.txtNroMovimiento.Location = New System.Drawing.Point(132, 16)
        Me.txtNroMovimiento.Name = "txtNroMovimiento"
        Me.txtNroMovimiento.Size = New System.Drawing.Size(78, 20)
        Me.txtNroMovimiento.TabIndex = 1
        Me.txtNroMovimiento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(23, 17)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(103, 18)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Nº Movimiento"
        '
        'dgvTalones
        '
        Me.dgvTalones.AllowUserToAddRows = False
        Me.dgvTalones.AllowUserToDeleteRows = False
        Me.dgvTalones.AllowUserToResizeColumns = False
        Me.dgvTalones.AllowUserToResizeRows = False
        Me.dgvTalones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvTalones.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Talon, Me.Tipo, Me.Terminado, Me.Articulo, Me.Descripcion, Me.Lote, Me.Cantidad, Me.Ubicacion, Me.Observaciones})
        Me.dgvTalones.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dgvTalones.Location = New System.Drawing.Point(16, 112)
        Me.dgvTalones.Name = "dgvTalones"
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle10.NullValue = Nothing
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvTalones.RowHeadersDefaultCellStyle = DataGridViewCellStyle10
        Me.dgvTalones.RowHeadersWidth = 15
        Me.dgvTalones.RowTemplate.Height = 18
        Me.dgvTalones.ShowCellToolTips = False
        Me.dgvTalones.Size = New System.Drawing.Size(780, 239)
        Me.dgvTalones.TabIndex = 2
        '
        'Talon
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Talon.DefaultCellStyle = DataGridViewCellStyle6
        Me.Talon.HeaderText = "Talon"
        Me.Talon.Name = "Talon"
        Me.Talon.Width = 50
        '
        'Tipo
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Tipo.DefaultCellStyle = DataGridViewCellStyle7
        Me.Tipo.HeaderText = "Tipo"
        Me.Tipo.Name = "Tipo"
        Me.Tipo.Width = 40
        '
        'Terminado
        '
        Me.Terminado.HeaderText = "Terminado"
        Me.Terminado.Name = "Terminado"
        Me.Terminado.Width = 80
        '
        'Articulo
        '
        Me.Articulo.HeaderText = "Articulo"
        Me.Articulo.Name = "Articulo"
        Me.Articulo.Width = 80
        '
        'Descripcion
        '
        Me.Descripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Descripcion.HeaderText = "Descripcion"
        Me.Descripcion.Name = "Descripcion"
        Me.Descripcion.ReadOnly = True
        '
        'Lote
        '
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Lote.DefaultCellStyle = DataGridViewCellStyle8
        Me.Lote.HeaderText = "Lote"
        Me.Lote.Name = "Lote"
        Me.Lote.Width = 50
        '
        'Cantidad
        '
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Cantidad.DefaultCellStyle = DataGridViewCellStyle9
        Me.Cantidad.HeaderText = "Cantidad"
        Me.Cantidad.Name = "Cantidad"
        Me.Cantidad.Width = 70
        '
        'Ubicacion
        '
        Me.Ubicacion.HeaderText = "Ubicacion"
        Me.Ubicacion.Name = "Ubicacion"
        '
        'Observaciones
        '
        Me.Observaciones.HeaderText = "Observaciones"
        Me.Observaciones.Name = "Observaciones"
        Me.Observaciones.Width = 150
        '
        'btnGrabar
        '
        Me.btnGrabar.Location = New System.Drawing.Point(231, 359)
        Me.btnGrabar.Name = "btnGrabar"
        Me.btnGrabar.Size = New System.Drawing.Size(90, 45)
        Me.btnGrabar.TabIndex = 3
        Me.btnGrabar.Text = "Grabar"
        Me.btnGrabar.UseVisualStyleBackColor = True
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Location = New System.Drawing.Point(361, 359)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(90, 45)
        Me.btnLimpiar.TabIndex = 3
        Me.btnLimpiar.Text = "Limpiar"
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'btnCerrar
        '
        Me.btnCerrar.Location = New System.Drawing.Point(491, 359)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(90, 45)
        Me.btnCerrar.TabIndex = 3
        Me.btnCerrar.Text = "Cerrar"
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'txtTerminadoAux
        '
        Me.txtTerminadoAux.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtTerminadoAux.Location = New System.Drawing.Point(587, 286)
        Me.txtTerminadoAux.Mask = "AA-00000-000"
        Me.txtTerminadoAux.Name = "txtTerminadoAux"
        Me.txtTerminadoAux.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtTerminadoAux.Size = New System.Drawing.Size(76, 13)
        Me.txtTerminadoAux.TabIndex = 4
        Me.txtTerminadoAux.Visible = False
        '
        'txtArticuloAux
        '
        Me.txtArticuloAux.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtArticuloAux.Location = New System.Drawing.Point(669, 286)
        Me.txtArticuloAux.Mask = "AA-000-000"
        Me.txtArticuloAux.Name = "txtArticuloAux"
        Me.txtArticuloAux.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtArticuloAux.Size = New System.Drawing.Size(74, 13)
        Me.txtArticuloAux.TabIndex = 4
        Me.txtArticuloAux.Visible = False
        '
        'IngresoTalonInventario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(812, 413)
        Me.Controls.Add(Me.txtArticuloAux)
        Me.Controls.Add(Me.txtTerminadoAux)
        Me.Controls.Add(Me.btnCerrar)
        Me.Controls.Add(Me.btnLimpiar)
        Me.Controls.Add(Me.btnGrabar)
        Me.Controls.Add(Me.dgvTalones)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Panel1)
        Me.Location = New System.Drawing.Point(10, 10)
        Me.MaximizeBox = False
        Me.Name = "IngresoTalonInventario"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgvTalones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtNroMovimiento As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dgvTalones As System.Windows.Forms.DataGridView
    Friend WithEvents btnGrabar As System.Windows.Forms.Button
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents txtTerminadoAux As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtArticuloAux As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Talon As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Tipo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Terminado As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Articulo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Descripcion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Lote As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cantidad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Ubicacion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Observaciones As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
