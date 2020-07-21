<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class IngresoGastosImportacion
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.label1 = New System.Windows.Forms.Label()
        Me.txt_Carpeta = New System.Windows.Forms.TextBox()
        Me.txt_OrdenCompra = New System.Windows.Forms.TextBox()
        Me.txt_Origen = New System.Windows.Forms.TextBox()
        Me.cbx_TipoCosto = New System.Windows.Forms.ComboBox()
        Me.cbx_Moneda = New System.Windows.Forms.ComboBox()
        Me.cbx_Transporte = New System.Windows.Forms.ComboBox()
        Me.cbx_Estado = New System.Windows.Forms.ComboBox()
        Me.btn_Limpiar = New System.Windows.Forms.Button()
        Me.btn_Consulta = New System.Windows.Forms.Button()
        Me.btn_Graba = New System.Windows.Forms.Button()
        Me.btn_Cerrar = New System.Windows.Forms.Button()
        Me.txt_Concepto = New System.Windows.Forms.TextBox()
        Me.txt_Descripcion = New System.Windows.Forms.TextBox()
        Me.txt_Importe = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txt_Fecha = New System.Windows.Forms.MaskedTextBox()
        Me.btn_IngresaObservaciones = New System.Windows.Forms.Button()
        Me.btn_Derechos = New System.Windows.Forms.Button()
        Me.btn_Ok = New System.Windows.Forms.Button()
        Me.lbl_EmpresaConeccion = New System.Windows.Forms.Label()
        Me.txt_fila = New System.Windows.Forms.TextBox()
        Me.DGV_GastosImportacion = New Util.DBDataGridView()
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
        Me.panel1.Size = New System.Drawing.Size(603, 40)
        Me.panel1.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(427, 10)
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
        Me.label1.Size = New System.Drawing.Size(230, 17)
        Me.label1.TabIndex = 0
        Me.label1.Text = "Ingreso Gastos de Importacion"
        '
        'txt_Carpeta
        '
        Me.txt_Carpeta.Location = New System.Drawing.Point(100, 46)
        Me.txt_Carpeta.MaxLength = 6
        Me.txt_Carpeta.Name = "txt_Carpeta"
        Me.txt_Carpeta.Size = New System.Drawing.Size(100, 20)
        Me.txt_Carpeta.TabIndex = 5
        '
        'txt_OrdenCompra
        '
        Me.txt_OrdenCompra.Location = New System.Drawing.Point(100, 72)
        Me.txt_OrdenCompra.MaxLength = 6
        Me.txt_OrdenCompra.Name = "txt_OrdenCompra"
        Me.txt_OrdenCompra.Size = New System.Drawing.Size(100, 20)
        Me.txt_OrdenCompra.TabIndex = 6
        '
        'txt_Origen
        '
        Me.txt_Origen.Location = New System.Drawing.Point(100, 100)
        Me.txt_Origen.MaxLength = 30
        Me.txt_Origen.Name = "txt_Origen"
        Me.txt_Origen.Size = New System.Drawing.Size(100, 20)
        Me.txt_Origen.TabIndex = 8
        '
        'cbx_TipoCosto
        '
        Me.cbx_TipoCosto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbx_TipoCosto.FormattingEnabled = True
        Me.cbx_TipoCosto.Items.AddRange(New Object() {"", "FOB", "CIF", "CFR", "CPT", "EXW", "FCA"})
        Me.cbx_TipoCosto.Location = New System.Drawing.Point(270, 72)
        Me.cbx_TipoCosto.Name = "cbx_TipoCosto"
        Me.cbx_TipoCosto.Size = New System.Drawing.Size(121, 21)
        Me.cbx_TipoCosto.TabIndex = 9
        '
        'cbx_Moneda
        '
        Me.cbx_Moneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbx_Moneda.FormattingEnabled = True
        Me.cbx_Moneda.Items.AddRange(New Object() {"Dolar", "Euro"})
        Me.cbx_Moneda.Location = New System.Drawing.Point(270, 100)
        Me.cbx_Moneda.Name = "cbx_Moneda"
        Me.cbx_Moneda.Size = New System.Drawing.Size(121, 21)
        Me.cbx_Moneda.TabIndex = 10
        '
        'cbx_Transporte
        '
        Me.cbx_Transporte.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbx_Transporte.FormattingEnabled = True
        Me.cbx_Transporte.Items.AddRange(New Object() {"", "Maritimo", "Terrestre", "Aereo"})
        Me.cbx_Transporte.Location = New System.Drawing.Point(464, 46)
        Me.cbx_Transporte.Name = "cbx_Transporte"
        Me.cbx_Transporte.Size = New System.Drawing.Size(121, 21)
        Me.cbx_Transporte.TabIndex = 11
        '
        'cbx_Estado
        '
        Me.cbx_Estado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbx_Estado.FormattingEnabled = True
        Me.cbx_Estado.Items.AddRange(New Object() {"", "Actualizada"})
        Me.cbx_Estado.Location = New System.Drawing.Point(464, 73)
        Me.cbx_Estado.Name = "cbx_Estado"
        Me.cbx_Estado.Size = New System.Drawing.Size(121, 21)
        Me.cbx_Estado.TabIndex = 12
        '
        'btn_Limpiar
        '
        Me.btn_Limpiar.Location = New System.Drawing.Point(258, 401)
        Me.btn_Limpiar.Name = "btn_Limpiar"
        Me.btn_Limpiar.Size = New System.Drawing.Size(75, 42)
        Me.btn_Limpiar.TabIndex = 14
        Me.btn_Limpiar.Text = "LIMPIAR PANTALLA"
        Me.btn_Limpiar.UseVisualStyleBackColor = True
        '
        'btn_Consulta
        '
        Me.btn_Consulta.Location = New System.Drawing.Point(96, 401)
        Me.btn_Consulta.Name = "btn_Consulta"
        Me.btn_Consulta.Size = New System.Drawing.Size(75, 42)
        Me.btn_Consulta.TabIndex = 15
        Me.btn_Consulta.Text = "CONSULTA"
        Me.btn_Consulta.UseVisualStyleBackColor = True
        '
        'btn_Graba
        '
        Me.btn_Graba.Location = New System.Drawing.Point(15, 401)
        Me.btn_Graba.Name = "btn_Graba"
        Me.btn_Graba.Size = New System.Drawing.Size(75, 42)
        Me.btn_Graba.TabIndex = 17
        Me.btn_Graba.Text = "GRABAR"
        Me.btn_Graba.UseVisualStyleBackColor = True
        '
        'btn_Cerrar
        '
        Me.btn_Cerrar.Location = New System.Drawing.Point(339, 401)
        Me.btn_Cerrar.Name = "btn_Cerrar"
        Me.btn_Cerrar.Size = New System.Drawing.Size(75, 42)
        Me.btn_Cerrar.TabIndex = 19
        Me.btn_Cerrar.Text = "CERRAR"
        Me.btn_Cerrar.UseVisualStyleBackColor = True
        '
        'txt_Concepto
        '
        Me.txt_Concepto.Location = New System.Drawing.Point(13, 375)
        Me.txt_Concepto.MaxLength = 6
        Me.txt_Concepto.Name = "txt_Concepto"
        Me.txt_Concepto.Size = New System.Drawing.Size(100, 20)
        Me.txt_Concepto.TabIndex = 20
        '
        'txt_Descripcion
        '
        Me.txt_Descripcion.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txt_Descripcion.Location = New System.Drawing.Point(119, 375)
        Me.txt_Descripcion.Name = "txt_Descripcion"
        Me.txt_Descripcion.ReadOnly = True
        Me.txt_Descripcion.Size = New System.Drawing.Size(281, 20)
        Me.txt_Descripcion.TabIndex = 21
        '
        'txt_Importe
        '
        Me.txt_Importe.Location = New System.Drawing.Point(406, 375)
        Me.txt_Importe.MaxLength = 10
        Me.txt_Importe.Name = "txt_Importe"
        Me.txt_Importe.Size = New System.Drawing.Size(89, 20)
        Me.txt_Importe.TabIndex = 22
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(7, 49)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 13)
        Me.Label3.TabIndex = 23
        Me.Label3.Text = "Carpeta"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(206, 103)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(46, 13)
        Me.Label4.TabIndex = 24
        Me.Label4.Text = "Moneda"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(403, 359)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(42, 13)
        Me.Label6.TabIndex = 26
        Me.Label6.Text = "Importe"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(116, 359)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(63, 13)
        Me.Label7.TabIndex = 27
        Me.Label7.Text = "Descripcion"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(10, 359)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(53, 13)
        Me.Label8.TabIndex = 28
        Me.Label8.Text = "Concepto"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(400, 76)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(40, 13)
        Me.Label9.TabIndex = 29
        Me.Label9.Text = "Estado"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(206, 75)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(58, 13)
        Me.Label10.TabIndex = 30
        Me.Label10.Text = "Tipo Costo"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(7, 103)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(38, 13)
        Me.Label11.TabIndex = 31
        Me.Label11.Text = "Origen"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(219, 50)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(37, 13)
        Me.Label12.TabIndex = 32
        Me.Label12.Text = "Fecha"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(400, 49)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(58, 13)
        Me.Label13.TabIndex = 33
        Me.Label13.Text = "Transporte"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(4, 75)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(90, 13)
        Me.Label14.TabIndex = 34
        Me.Label14.Text = "Orden de Compra"
        '
        'txt_Fecha
        '
        Me.txt_Fecha.Location = New System.Drawing.Point(270, 45)
        Me.txt_Fecha.Mask = "00/00/0000"
        Me.txt_Fecha.Name = "txt_Fecha"
        Me.txt_Fecha.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txt_Fecha.Size = New System.Drawing.Size(66, 20)
        Me.txt_Fecha.TabIndex = 35
        '
        'btn_IngresaObservaciones
        '
        Me.btn_IngresaObservaciones.Location = New System.Drawing.Point(119, 449)
        Me.btn_IngresaObservaciones.Name = "btn_IngresaObservaciones"
        Me.btn_IngresaObservaciones.Size = New System.Drawing.Size(189, 30)
        Me.btn_IngresaObservaciones.TabIndex = 36
        Me.btn_IngresaObservaciones.Text = "INGRESA OBSERVACIONES"
        Me.btn_IngresaObservaciones.UseVisualStyleBackColor = True
        '
        'btn_Derechos
        '
        Me.btn_Derechos.Location = New System.Drawing.Point(177, 401)
        Me.btn_Derechos.Name = "btn_Derechos"
        Me.btn_Derechos.Size = New System.Drawing.Size(75, 42)
        Me.btn_Derechos.TabIndex = 37
        Me.btn_Derechos.Text = "DERECHOS"
        Me.btn_Derechos.UseVisualStyleBackColor = True
        '
        'btn_Ok
        '
        Me.btn_Ok.Location = New System.Drawing.Point(507, 100)
        Me.btn_Ok.Name = "btn_Ok"
        Me.btn_Ok.Size = New System.Drawing.Size(75, 42)
        Me.btn_Ok.TabIndex = 38
        Me.btn_Ok.Text = "OK"
        Me.btn_Ok.UseVisualStyleBackColor = True
        '
        'lbl_EmpresaConeccion
        '
        Me.lbl_EmpresaConeccion.AutoSize = True
        Me.lbl_EmpresaConeccion.Location = New System.Drawing.Point(468, 466)
        Me.lbl_EmpresaConeccion.Name = "lbl_EmpresaConeccion"
        Me.lbl_EmpresaConeccion.Size = New System.Drawing.Size(39, 13)
        Me.lbl_EmpresaConeccion.TabIndex = 39
        Me.lbl_EmpresaConeccion.Text = "Label5"
        '
        'txt_fila
        '
        Me.txt_fila.Location = New System.Drawing.Point(501, 375)
        Me.txt_fila.Name = "txt_fila"
        Me.txt_fila.Size = New System.Drawing.Size(21, 20)
        Me.txt_fila.TabIndex = 40
        Me.txt_fila.Visible = False
        '
        'DGV_GastosImportacion
        '
        Me.DGV_GastosImportacion.AllowUserToAddRows = False
        Me.DGV_GastosImportacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_GastosImportacion.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Concepto, Me.Descripcion, Me.Importe})
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(232, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGV_GastosImportacion.DefaultCellStyle = DataGridViewCellStyle1
        Me.DGV_GastosImportacion.DoubleBuffered = True
        Me.DGV_GastosImportacion.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.DGV_GastosImportacion.Location = New System.Drawing.Point(13, 133)
        Me.DGV_GastosImportacion.Name = "DGV_GastosImportacion"
        Me.DGV_GastosImportacion.OrdenamientoColumnasHabilitado = True
        Me.DGV_GastosImportacion.RowHeadersWidth = 15
        Me.DGV_GastosImportacion.RowTemplate.Height = 20
        Me.DGV_GastosImportacion.ShowCellToolTips = False
        Me.DGV_GastosImportacion.SinClickDerecho = False
        Me.DGV_GastosImportacion.Size = New System.Drawing.Size(482, 224)
        Me.DGV_GastosImportacion.TabIndex = 13
        '
        'Concepto
        '
        Me.Concepto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Concepto.DataPropertyName = "Concepto"
        Me.Concepto.HeaderText = "Concepto"
        Me.Concepto.Name = "Concepto"
        Me.Concepto.Width = 78
        '
        'Descripcion
        '
        Me.Descripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Descripcion.DataPropertyName = "Descripcion"
        Me.Descripcion.HeaderText = "Descripcion"
        Me.Descripcion.Name = "Descripcion"
        '
        'Importe
        '
        Me.Importe.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Importe.DataPropertyName = "Importe"
        Me.Importe.HeaderText = "Importe"
        Me.Importe.Name = "Importe"
        Me.Importe.Width = 67
        '
        'IngresoGastosImportacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(603, 484)
        Me.Controls.Add(Me.txt_fila)
        Me.Controls.Add(Me.lbl_EmpresaConeccion)
        Me.Controls.Add(Me.btn_Ok)
        Me.Controls.Add(Me.btn_Derechos)
        Me.Controls.Add(Me.btn_IngresaObservaciones)
        Me.Controls.Add(Me.txt_Fecha)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txt_Importe)
        Me.Controls.Add(Me.txt_Descripcion)
        Me.Controls.Add(Me.txt_Concepto)
        Me.Controls.Add(Me.btn_Cerrar)
        Me.Controls.Add(Me.btn_Graba)
        Me.Controls.Add(Me.btn_Consulta)
        Me.Controls.Add(Me.btn_Limpiar)
        Me.Controls.Add(Me.DGV_GastosImportacion)
        Me.Controls.Add(Me.cbx_Estado)
        Me.Controls.Add(Me.cbx_Transporte)
        Me.Controls.Add(Me.cbx_Moneda)
        Me.Controls.Add(Me.cbx_TipoCosto)
        Me.Controls.Add(Me.txt_Origen)
        Me.Controls.Add(Me.txt_OrdenCompra)
        Me.Controls.Add(Me.txt_Carpeta)
        Me.Controls.Add(Me.panel1)
        Me.Location = New System.Drawing.Point(20, 20)
        Me.Name = "IngresoGastosImportacion"
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
    Friend WithEvents txt_Carpeta As System.Windows.Forms.TextBox
    Friend WithEvents txt_OrdenCompra As System.Windows.Forms.TextBox
    Friend WithEvents txt_Origen As System.Windows.Forms.TextBox
    Friend WithEvents cbx_TipoCosto As System.Windows.Forms.ComboBox
    Friend WithEvents cbx_Moneda As System.Windows.Forms.ComboBox
    Friend WithEvents cbx_Transporte As System.Windows.Forms.ComboBox
    Friend WithEvents cbx_Estado As System.Windows.Forms.ComboBox
    Friend WithEvents DGV_GastosImportacion As Util.DBDataGridView
    Friend WithEvents btn_Limpiar As System.Windows.Forms.Button
    Friend WithEvents btn_Consulta As System.Windows.Forms.Button
    Friend WithEvents btn_Graba As System.Windows.Forms.Button
    Friend WithEvents btn_Cerrar As System.Windows.Forms.Button
    Friend WithEvents txt_Concepto As System.Windows.Forms.TextBox
    Friend WithEvents txt_Descripcion As System.Windows.Forms.TextBox
    Friend WithEvents txt_Importe As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txt_Fecha As System.Windows.Forms.MaskedTextBox
    Friend WithEvents btn_IngresaObservaciones As System.Windows.Forms.Button
    Friend WithEvents btn_Derechos As System.Windows.Forms.Button
    Friend WithEvents btn_Ok As System.Windows.Forms.Button
    Friend WithEvents lbl_EmpresaConeccion As System.Windows.Forms.Label
    Friend WithEvents txt_fila As System.Windows.Forms.TextBox
    Friend WithEvents Concepto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Descripcion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Importe As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
