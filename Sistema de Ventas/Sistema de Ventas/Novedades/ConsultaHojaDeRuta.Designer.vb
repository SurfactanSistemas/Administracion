<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ConsultaHojaDeRuta
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
        Me.txtNroHoja = New System.Windows.Forms.TextBox()
        Me.txtFecha = New System.Windows.Forms.MaskedTextBox()
        Me.txtTotalPesos = New System.Windows.Forms.TextBox()
        Me.txtTotalKilos = New System.Windows.Forms.TextBox()
        Me.txtChofer = New System.Windows.Forms.TextBox()
        Me.txtCamion = New System.Windows.Forms.TextBox()
        Me.txtNroViaje = New System.Windows.Forms.TextBox()
        Me.txtRetiraProv = New System.Windows.Forms.TextBox()
        Me.txtChoferDesc = New System.Windows.Forms.TextBox()
        Me.txtCamionDesc = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.btnImprimir = New System.Windows.Forms.Button()
        Me.btnBuscarFecha = New System.Windows.Forms.Button()
        Me.DGV_HojaRuta = New Util.DBDataGridView()
        Me.Pedido = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Razon = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Remito = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Kilos = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Pesos = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Clase = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Provincia = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Direccion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Comprobante = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Clave = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Integridad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Archivo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.panel1 = New System.Windows.Forms.Panel()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.btnCerrar = New System.Windows.Forms.Button()
        CType(Me.DGV_HojaRuta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtNroHoja
        '
        Me.txtNroHoja.Location = New System.Drawing.Point(78, 42)
        Me.txtNroHoja.Name = "txtNroHoja"
        Me.txtNroHoja.Size = New System.Drawing.Size(100, 20)
        Me.txtNroHoja.TabIndex = 0
        '
        'txtFecha
        '
        Me.txtFecha.Location = New System.Drawing.Point(227, 41)
        Me.txtFecha.Mask = "00/00/0000"
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtFecha.Size = New System.Drawing.Size(68, 20)
        Me.txtFecha.TabIndex = 1
        '
        'txtTotalPesos
        '
        Me.txtTotalPesos.Location = New System.Drawing.Point(398, 42)
        Me.txtTotalPesos.Name = "txtTotalPesos"
        Me.txtTotalPesos.Size = New System.Drawing.Size(100, 20)
        Me.txtTotalPesos.TabIndex = 2
        '
        'txtTotalKilos
        '
        Me.txtTotalKilos.Location = New System.Drawing.Point(571, 41)
        Me.txtTotalKilos.Name = "txtTotalKilos"
        Me.txtTotalKilos.Size = New System.Drawing.Size(100, 20)
        Me.txtTotalKilos.TabIndex = 3
        '
        'txtChofer
        '
        Me.txtChofer.Location = New System.Drawing.Point(78, 68)
        Me.txtChofer.Name = "txtChofer"
        Me.txtChofer.Size = New System.Drawing.Size(100, 20)
        Me.txtChofer.TabIndex = 4
        '
        'txtCamion
        '
        Me.txtCamion.Location = New System.Drawing.Point(459, 68)
        Me.txtCamion.Name = "txtCamion"
        Me.txtCamion.Size = New System.Drawing.Size(100, 20)
        Me.txtCamion.TabIndex = 5
        '
        'txtNroViaje
        '
        Me.txtNroViaje.Location = New System.Drawing.Point(78, 94)
        Me.txtNroViaje.Name = "txtNroViaje"
        Me.txtNroViaje.Size = New System.Drawing.Size(100, 20)
        Me.txtNroViaje.TabIndex = 6
        '
        'txtRetiraProv
        '
        Me.txtRetiraProv.Location = New System.Drawing.Point(253, 93)
        Me.txtRetiraProv.Name = "txtRetiraProv"
        Me.txtRetiraProv.Size = New System.Drawing.Size(464, 20)
        Me.txtRetiraProv.TabIndex = 7
        '
        'txtChoferDesc
        '
        Me.txtChoferDesc.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtChoferDesc.Location = New System.Drawing.Point(184, 67)
        Me.txtChoferDesc.Name = "txtChoferDesc"
        Me.txtChoferDesc.ReadOnly = True
        Me.txtChoferDesc.Size = New System.Drawing.Size(221, 20)
        Me.txtChoferDesc.TabIndex = 8
        '
        'txtCamionDesc
        '
        Me.txtCamionDesc.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtCamionDesc.Location = New System.Drawing.Point(565, 68)
        Me.txtCamionDesc.Name = "txtCamionDesc"
        Me.txtCamionDesc.ReadOnly = True
        Me.txtCamionDesc.Size = New System.Drawing.Size(221, 20)
        Me.txtCamionDesc.TabIndex = 9
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 45)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 13)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Nro. Hoja"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(184, 45)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(37, 13)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Fecha"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(329, 45)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(63, 13)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "Total Pesos"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(509, 45)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(56, 13)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "Total Kilos"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(20, 71)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(38, 13)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "Chofer"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(414, 71)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(42, 13)
        Me.Label6.TabIndex = 15
        Me.Label6.Text = "Camion"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(1, 97)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(68, 13)
        Me.Label7.TabIndex = 16
        Me.Label7.Text = "Nro. de Viaje"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(184, 97)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(63, 13)
        Me.Label8.TabIndex = 17
        Me.Label8.Text = "Retira Prov."
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Location = New System.Drawing.Point(469, 463)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(75, 23)
        Me.btnLimpiar.TabIndex = 19
        Me.btnLimpiar.Text = "Limpiar"
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'btnImprimir
        '
        Me.btnImprimir.Location = New System.Drawing.Point(334, 463)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(75, 23)
        Me.btnImprimir.TabIndex = 20
        Me.btnImprimir.Text = "Imprimir"
        Me.btnImprimir.UseVisualStyleBackColor = True
        '
        'btnBuscarFecha
        '
        Me.btnBuscarFecha.Location = New System.Drawing.Point(143, 463)
        Me.btnBuscarFecha.Name = "btnBuscarFecha"
        Me.btnBuscarFecha.Size = New System.Drawing.Size(141, 23)
        Me.btnBuscarFecha.TabIndex = 21
        Me.btnBuscarFecha.Text = "Buscar Rango Fechas"
        Me.btnBuscarFecha.UseVisualStyleBackColor = True
        '
        'DGV_HojaRuta
        '
        Me.DGV_HojaRuta.AllowUserToAddRows = False
        Me.DGV_HojaRuta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_HojaRuta.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Pedido, Me.Cliente, Me.Razon, Me.Remito, Me.Kilos, Me.Pesos, Me.Clase, Me.Provincia, Me.Direccion, Me.Comprobante, Me.Clave, Me.Integridad, Me.Archivo})
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(232, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGV_HojaRuta.DefaultCellStyle = DataGridViewCellStyle1
        Me.DGV_HojaRuta.DoubleBuffered = True
        Me.DGV_HojaRuta.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.DGV_HojaRuta.Location = New System.Drawing.Point(4, 119)
        Me.DGV_HojaRuta.Name = "DGV_HojaRuta"
        Me.DGV_HojaRuta.OrdenamientoColumnasHabilitado = True
        Me.DGV_HojaRuta.RowHeadersWidth = 15
        Me.DGV_HojaRuta.RowTemplate.Height = 20
        Me.DGV_HojaRuta.ShowCellToolTips = False
        Me.DGV_HojaRuta.SinClickDerecho = False
        Me.DGV_HojaRuta.Size = New System.Drawing.Size(789, 341)
        Me.DGV_HojaRuta.TabIndex = 18
        '
        'Pedido
        '
        Me.Pedido.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Pedido.DataPropertyName = "Pedido"
        Me.Pedido.HeaderText = "Pedido"
        Me.Pedido.Name = "Pedido"
        Me.Pedido.Width = 65
        '
        'Cliente
        '
        Me.Cliente.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Cliente.DataPropertyName = "Cliente"
        Me.Cliente.HeaderText = "Cliente"
        Me.Cliente.Name = "Cliente"
        Me.Cliente.Width = 64
        '
        'Razon
        '
        Me.Razon.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Razon.DataPropertyName = "Razon"
        Me.Razon.HeaderText = "Razon"
        Me.Razon.Name = "Razon"
        Me.Razon.Width = 63
        '
        'Remito
        '
        Me.Remito.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Remito.DataPropertyName = "Remito"
        Me.Remito.HeaderText = "Remito"
        Me.Remito.Name = "Remito"
        Me.Remito.Width = 65
        '
        'Kilos
        '
        Me.Kilos.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Kilos.DataPropertyName = "Kilos"
        Me.Kilos.HeaderText = "Kilos"
        Me.Kilos.Name = "Kilos"
        Me.Kilos.Width = 54
        '
        'Pesos
        '
        Me.Pesos.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Pesos.DataPropertyName = "Pesos"
        Me.Pesos.HeaderText = "      $"
        Me.Pesos.Name = "Pesos"
        Me.Pesos.Width = 56
        '
        'Clase
        '
        Me.Clase.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Clase.DataPropertyName = "Clase"
        Me.Clase.HeaderText = "Clase"
        Me.Clase.Name = "Clase"
        Me.Clase.Width = 58
        '
        'Provincia
        '
        Me.Provincia.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Provincia.DataPropertyName = "Provincia"
        Me.Provincia.HeaderText = "Provincia"
        Me.Provincia.Name = "Provincia"
        Me.Provincia.Width = 76
        '
        'Direccion
        '
        Me.Direccion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Direccion.DataPropertyName = "Direccion"
        Me.Direccion.HeaderText = "Direccion"
        Me.Direccion.Name = "Direccion"
        Me.Direccion.Width = 77
        '
        'Comprobante
        '
        Me.Comprobante.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Comprobante.DataPropertyName = "Comprobante"
        Me.Comprobante.HeaderText = "Comprobante"
        Me.Comprobante.Name = "Comprobante"
        Me.Comprobante.Width = 95
        '
        'Clave
        '
        Me.Clave.DataPropertyName = "Clave"
        Me.Clave.HeaderText = "Clave"
        Me.Clave.Name = "Clave"
        Me.Clave.Visible = False
        '
        'Integridad
        '
        Me.Integridad.DataPropertyName = "Integridad"
        Me.Integridad.HeaderText = "Integridad"
        Me.Integridad.Name = "Integridad"
        Me.Integridad.Visible = False
        '
        'Archivo
        '
        Me.Archivo.DataPropertyName = "Archivo"
        Me.Archivo.HeaderText = "Archivo"
        Me.Archivo.Name = "Archivo"
        Me.Archivo.Visible = False
        '
        'panel1
        '
        Me.panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(34, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.panel1.Controls.Add(Me.Label9)
        Me.panel1.Controls.Add(Me.Label10)
        Me.panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.panel1.Location = New System.Drawing.Point(0, 0)
        Me.panel1.Name = "panel1"
        Me.panel1.Size = New System.Drawing.Size(808, 40)
        Me.panel1.TabIndex = 22
        '
        'Label9
        '
        Me.Label9.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(632, 10)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(155, 20)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "SURFACTAN S.A."
        '
        'Label10
        '
        Me.Label10.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(21, 12)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(171, 17)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "Consulta Hoja de Ruta"
        '
        'btnCerrar
        '
        Me.btnCerrar.Location = New System.Drawing.Point(571, 463)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(75, 23)
        Me.btnCerrar.TabIndex = 23
        Me.btnCerrar.Text = "Cerrar"
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'ConsultaHojaDeRuta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(808, 490)
        Me.Controls.Add(Me.btnCerrar)
        Me.Controls.Add(Me.panel1)
        Me.Controls.Add(Me.btnBuscarFecha)
        Me.Controls.Add(Me.btnImprimir)
        Me.Controls.Add(Me.btnLimpiar)
        Me.Controls.Add(Me.DGV_HojaRuta)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtCamionDesc)
        Me.Controls.Add(Me.txtChoferDesc)
        Me.Controls.Add(Me.txtRetiraProv)
        Me.Controls.Add(Me.txtNroViaje)
        Me.Controls.Add(Me.txtCamion)
        Me.Controls.Add(Me.txtChofer)
        Me.Controls.Add(Me.txtTotalKilos)
        Me.Controls.Add(Me.txtTotalPesos)
        Me.Controls.Add(Me.txtFecha)
        Me.Controls.Add(Me.txtNroHoja)
        Me.Location = New System.Drawing.Point(20, 20)
        Me.Name = "ConsultaHojaDeRuta"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        CType(Me.DGV_HojaRuta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panel1.ResumeLayout(False)
        Me.panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtNroHoja As System.Windows.Forms.TextBox
    Friend WithEvents txtFecha As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtTotalPesos As System.Windows.Forms.TextBox
    Friend WithEvents txtTotalKilos As System.Windows.Forms.TextBox
    Friend WithEvents txtChofer As System.Windows.Forms.TextBox
    Friend WithEvents txtCamion As System.Windows.Forms.TextBox
    Friend WithEvents txtNroViaje As System.Windows.Forms.TextBox
    Friend WithEvents txtRetiraProv As System.Windows.Forms.TextBox
    Friend WithEvents txtChoferDesc As System.Windows.Forms.TextBox
    Friend WithEvents txtCamionDesc As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents DGV_HojaRuta As Util.DBDataGridView
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents btnImprimir As System.Windows.Forms.Button
    Friend WithEvents Pedido As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cliente As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Razon As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Remito As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Kilos As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Pesos As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Clase As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Provincia As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Direccion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Comprobante As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Clave As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Integridad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Archivo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnBuscarFecha As System.Windows.Forms.Button
    Private WithEvents panel1 As System.Windows.Forms.Panel
    Private WithEvents Label9 As System.Windows.Forms.Label
    Private WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
End Class
