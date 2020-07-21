<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class IngresoGastosDeImportacionParcial
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
        Me.panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.label1 = New System.Windows.Forms.Label()
        Me.txt_Fecha = New System.Windows.Forms.MaskedTextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txt_NroMovimiento = New System.Windows.Forms.TextBox()
        Me.txt_Orden = New System.Windows.Forms.TextBox()
        Me.txt_Carpeta = New System.Windows.Forms.TextBox()
        Me.txt_fila = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txt_Importe = New System.Windows.Forms.TextBox()
        Me.txt_Descripcion = New System.Windows.Forms.TextBox()
        Me.txt_Concepto = New System.Windows.Forms.TextBox()
        Me.DGV_GastosImportacion = New Util.DBDataGridView()
        Me.btn_Articulos = New System.Windows.Forms.Button()
        Me.btn_Cerrar = New System.Windows.Forms.Button()
        Me.btn_Graba = New System.Windows.Forms.Button()
        Me.btn_Consulta = New System.Windows.Forms.Button()
        Me.btn_Limpiar = New System.Windows.Forms.Button()
        Me.txt_Empresa = New System.Windows.Forms.TextBox()
        Me.Concepto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Importe = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.panel1.SuspendLayout()
        CType(Me.DGV_GastosImportacion, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.panel1.Size = New System.Drawing.Size(505, 40)
        Me.panel1.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(329, 10)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(155, 20)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "SURFACTAN S.A."
        '
        'label1
        '
        Me.label1.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.label1.AutoSize = True
        Me.label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold)
        Me.label1.ForeColor = System.Drawing.Color.White
        Me.label1.Location = New System.Drawing.Point(3, 13)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(285, 17)
        Me.label1.TabIndex = 0
        Me.label1.Text = "Ingreso Gastos de Importacion Parcial"
        '
        'txt_Fecha
        '
        Me.txt_Fecha.Location = New System.Drawing.Point(112, 76)
        Me.txt_Fecha.Mask = "00/00/0000"
        Me.txt_Fecha.Name = "txt_Fecha"
        Me.txt_Fecha.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txt_Fecha.Size = New System.Drawing.Size(66, 20)
        Me.txt_Fecha.TabIndex = 43
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(267, 80)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(36, 13)
        Me.Label14.TabIndex = 42
        Me.Label14.Text = "Orden"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(35, 79)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(37, 13)
        Me.Label12.TabIndex = 41
        Me.Label12.Text = "Fecha"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(4, 50)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(102, 13)
        Me.Label11.TabIndex = 40
        Me.Label11.Text = "Nro. de  Movimiento"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(267, 50)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 13)
        Me.Label3.TabIndex = 39
        Me.Label3.Text = "Carpeta"
        '
        'txt_NroMovimiento
        '
        Me.txt_NroMovimiento.Location = New System.Drawing.Point(112, 47)
        Me.txt_NroMovimiento.MaxLength = 30
        Me.txt_NroMovimiento.Name = "txt_NroMovimiento"
        Me.txt_NroMovimiento.Size = New System.Drawing.Size(100, 20)
        Me.txt_NroMovimiento.TabIndex = 38
        '
        'txt_Orden
        '
        Me.txt_Orden.Location = New System.Drawing.Point(377, 77)
        Me.txt_Orden.MaxLength = 6
        Me.txt_Orden.Name = "txt_Orden"
        Me.txt_Orden.Size = New System.Drawing.Size(68, 20)
        Me.txt_Orden.TabIndex = 37
        '
        'txt_Carpeta
        '
        Me.txt_Carpeta.Location = New System.Drawing.Point(321, 47)
        Me.txt_Carpeta.MaxLength = 6
        Me.txt_Carpeta.Name = "txt_Carpeta"
        Me.txt_Carpeta.Size = New System.Drawing.Size(100, 20)
        Me.txt_Carpeta.TabIndex = 36
        '
        'txt_fila
        '
        Me.txt_fila.Location = New System.Drawing.Point(467, 371)
        Me.txt_fila.Name = "txt_fila"
        Me.txt_fila.Size = New System.Drawing.Size(21, 20)
        Me.txt_fila.TabIndex = 51
        Me.txt_fila.Visible = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(3, 329)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(53, 13)
        Me.Label8.TabIndex = 50
        Me.Label8.Text = "Concepto"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(109, 329)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(63, 13)
        Me.Label7.TabIndex = 49
        Me.Label7.Text = "Descripcion"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(396, 329)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(42, 13)
        Me.Label6.TabIndex = 48
        Me.Label6.Text = "Importe"
        '
        'txt_Importe
        '
        Me.txt_Importe.Location = New System.Drawing.Point(399, 345)
        Me.txt_Importe.MaxLength = 10
        Me.txt_Importe.Name = "txt_Importe"
        Me.txt_Importe.Size = New System.Drawing.Size(89, 20)
        Me.txt_Importe.TabIndex = 47
        '
        'txt_Descripcion
        '
        Me.txt_Descripcion.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txt_Descripcion.Location = New System.Drawing.Point(112, 345)
        Me.txt_Descripcion.Name = "txt_Descripcion"
        Me.txt_Descripcion.ReadOnly = True
        Me.txt_Descripcion.Size = New System.Drawing.Size(281, 20)
        Me.txt_Descripcion.TabIndex = 46
        '
        'txt_Concepto
        '
        Me.txt_Concepto.Location = New System.Drawing.Point(6, 345)
        Me.txt_Concepto.MaxLength = 6
        Me.txt_Concepto.Name = "txt_Concepto"
        Me.txt_Concepto.Size = New System.Drawing.Size(100, 20)
        Me.txt_Concepto.TabIndex = 45
        '
        'DGV_GastosImportacion
        '
        Me.DGV_GastosImportacion.AllowUserToAddRows = False
        Me.DGV_GastosImportacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_GastosImportacion.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Concepto, Me.Descripcion, Me.Importe})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(232, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGV_GastosImportacion.DefaultCellStyle = DataGridViewCellStyle2
        Me.DGV_GastosImportacion.DoubleBuffered = True
        Me.DGV_GastosImportacion.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.DGV_GastosImportacion.Location = New System.Drawing.Point(18, 103)
        Me.DGV_GastosImportacion.Name = "DGV_GastosImportacion"
        Me.DGV_GastosImportacion.OrdenamientoColumnasHabilitado = True
        Me.DGV_GastosImportacion.RowHeadersWidth = 15
        Me.DGV_GastosImportacion.RowTemplate.Height = 20
        Me.DGV_GastosImportacion.ShowCellToolTips = False
        Me.DGV_GastosImportacion.SinClickDerecho = False
        Me.DGV_GastosImportacion.Size = New System.Drawing.Size(482, 224)
        Me.DGV_GastosImportacion.TabIndex = 44
        '
        'btn_Articulos
        '
        Me.btn_Articulos.Location = New System.Drawing.Point(208, 371)
        Me.btn_Articulos.Name = "btn_Articulos"
        Me.btn_Articulos.Size = New System.Drawing.Size(75, 42)
        Me.btn_Articulos.TabIndex = 56
        Me.btn_Articulos.Text = "ARTICULO"
        Me.btn_Articulos.UseVisualStyleBackColor = True
        '
        'btn_Cerrar
        '
        Me.btn_Cerrar.Location = New System.Drawing.Point(370, 371)
        Me.btn_Cerrar.Name = "btn_Cerrar"
        Me.btn_Cerrar.Size = New System.Drawing.Size(75, 42)
        Me.btn_Cerrar.TabIndex = 55
        Me.btn_Cerrar.Text = "CERRAR"
        Me.btn_Cerrar.UseVisualStyleBackColor = True
        '
        'btn_Graba
        '
        Me.btn_Graba.Location = New System.Drawing.Point(46, 371)
        Me.btn_Graba.Name = "btn_Graba"
        Me.btn_Graba.Size = New System.Drawing.Size(75, 42)
        Me.btn_Graba.TabIndex = 54
        Me.btn_Graba.Text = "GRABAR"
        Me.btn_Graba.UseVisualStyleBackColor = True
        '
        'btn_Consulta
        '
        Me.btn_Consulta.Location = New System.Drawing.Point(127, 371)
        Me.btn_Consulta.Name = "btn_Consulta"
        Me.btn_Consulta.Size = New System.Drawing.Size(75, 42)
        Me.btn_Consulta.TabIndex = 53
        Me.btn_Consulta.Text = "CONSULTA"
        Me.btn_Consulta.UseVisualStyleBackColor = True
        '
        'btn_Limpiar
        '
        Me.btn_Limpiar.Location = New System.Drawing.Point(289, 371)
        Me.btn_Limpiar.Name = "btn_Limpiar"
        Me.btn_Limpiar.Size = New System.Drawing.Size(75, 42)
        Me.btn_Limpiar.TabIndex = 52
        Me.btn_Limpiar.Text = "LIMPIAR PANTALLA"
        Me.btn_Limpiar.UseVisualStyleBackColor = True
        '
        'txt_Empresa
        '
        Me.txt_Empresa.Location = New System.Drawing.Point(322, 77)
        Me.txt_Empresa.Name = "txt_Empresa"
        Me.txt_Empresa.Size = New System.Drawing.Size(49, 20)
        Me.txt_Empresa.TabIndex = 57
        '
        'Concepto
        '
        Me.Concepto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Concepto.DataPropertyName = "Concepto"
        Me.Concepto.HeaderText = "Concepto"
        Me.Concepto.Name = "Concepto"
        Me.Concepto.ReadOnly = True
        Me.Concepto.Width = 78
        '
        'Descripcion
        '
        Me.Descripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Descripcion.DataPropertyName = "Descripcion"
        Me.Descripcion.HeaderText = "Descripcion"
        Me.Descripcion.Name = "Descripcion"
        Me.Descripcion.ReadOnly = True
        '
        'Importe
        '
        Me.Importe.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Importe.DataPropertyName = "Importe"
        Me.Importe.HeaderText = "Importe"
        Me.Importe.Name = "Importe"
        Me.Importe.ReadOnly = True
        Me.Importe.Width = 67
        '
        'IngresoGastosDeImportacionParcial
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(505, 417)
        Me.Controls.Add(Me.txt_Empresa)
        Me.Controls.Add(Me.btn_Articulos)
        Me.Controls.Add(Me.btn_Cerrar)
        Me.Controls.Add(Me.btn_Graba)
        Me.Controls.Add(Me.btn_Consulta)
        Me.Controls.Add(Me.btn_Limpiar)
        Me.Controls.Add(Me.txt_fila)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txt_Importe)
        Me.Controls.Add(Me.txt_Descripcion)
        Me.Controls.Add(Me.txt_Concepto)
        Me.Controls.Add(Me.DGV_GastosImportacion)
        Me.Controls.Add(Me.txt_Fecha)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txt_NroMovimiento)
        Me.Controls.Add(Me.txt_Orden)
        Me.Controls.Add(Me.txt_Carpeta)
        Me.Controls.Add(Me.panel1)
        Me.Location = New System.Drawing.Point(20, 20)
        Me.Name = "IngresoGastosDeImportacionParcial"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.panel1.ResumeLayout(False)
        Me.panel1.PerformLayout()
        CType(Me.DGV_GastosImportacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents panel1 As System.Windows.Forms.Panel
    Private WithEvents Label2 As System.Windows.Forms.Label
    Private WithEvents label1 As System.Windows.Forms.Label
    Friend WithEvents txt_Fecha As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txt_NroMovimiento As System.Windows.Forms.TextBox
    Friend WithEvents txt_Orden As System.Windows.Forms.TextBox
    Friend WithEvents txt_Carpeta As System.Windows.Forms.TextBox
    Friend WithEvents txt_fila As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txt_Importe As System.Windows.Forms.TextBox
    Friend WithEvents txt_Descripcion As System.Windows.Forms.TextBox
    Friend WithEvents txt_Concepto As System.Windows.Forms.TextBox
    Friend WithEvents DGV_GastosImportacion As Util.DBDataGridView
    Friend WithEvents btn_Articulos As System.Windows.Forms.Button
    Friend WithEvents btn_Cerrar As System.Windows.Forms.Button
    Friend WithEvents btn_Graba As System.Windows.Forms.Button
    Friend WithEvents btn_Consulta As System.Windows.Forms.Button
    Friend WithEvents btn_Limpiar As System.Windows.Forms.Button
    Friend WithEvents txt_Empresa As System.Windows.Forms.TextBox
    Friend WithEvents Concepto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Descripcion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Importe As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
