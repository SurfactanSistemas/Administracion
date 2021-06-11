<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Vista_Insumos
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
        Me.panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.label1 = New System.Windows.Forms.Label()
        Me.dgv_Insumos = New Util.DBDataGridView()
        Me.Cantidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txt_NroSoli = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txt_Fecha = New System.Windows.Forms.MaskedTextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txt_Planta = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txt_Solicitante = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txt_FechaEntrega = New System.Windows.Forms.MaskedTextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txt_Observaciones = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txt_Comentarios = New System.Windows.Forms.TextBox()
        Me.btn_Autorizar = New System.Windows.Forms.Button()
        Me.btn_Rechazar = New System.Windows.Forms.Button()
        Me.btn_Cerrar = New System.Windows.Forms.Button()
        Me.btn_Grabar = New System.Windows.Forms.Button()
        Me.cbx_Tipo = New System.Windows.Forms.ComboBox()
        Me.panel1.SuspendLayout()
        CType(Me.dgv_Insumos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'panel1
        '
        Me.panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(34, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.panel1.Controls.Add(Me.Label2)
        Me.panel1.Controls.Add(Me.label1)
        Me.panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.panel1.Location = New System.Drawing.Point(0, 0)
        Me.panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.panel1.Name = "panel1"
        Me.panel1.Size = New System.Drawing.Size(741, 49)
        Me.panel1.TabIndex = 10
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(507, 12)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(192, 25)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "SURFACTAN S.A."
        '
        'label1
        '
        Me.label1.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.label1.AutoSize = True
        Me.label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold)
        Me.label1.ForeColor = System.Drawing.Color.White
        Me.label1.Location = New System.Drawing.Point(4, 12)
        Me.label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(158, 20)
        Me.label1.TabIndex = 0
        Me.label1.Text = "Solicitud Insumos"
        '
        'dgv_Insumos
        '
        Me.dgv_Insumos.AllowUserToAddRows = False
        Me.dgv_Insumos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_Insumos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Cantidad, Me.Descripcion})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(232, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv_Insumos.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgv_Insumos.DoubleBuffered = True
        Me.dgv_Insumos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dgv_Insumos.Location = New System.Drawing.Point(8, 161)
        Me.dgv_Insumos.Name = "dgv_Insumos"
        Me.dgv_Insumos.OrdenamientoColumnasHabilitado = True
        Me.dgv_Insumos.RowHeadersWidth = 15
        Me.dgv_Insumos.RowTemplate.Height = 20
        Me.dgv_Insumos.ShowCellToolTips = False
        Me.dgv_Insumos.SinClickDerecho = False
        Me.dgv_Insumos.Size = New System.Drawing.Size(725, 272)
        Me.dgv_Insumos.TabIndex = 11
        '
        'Cantidad
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle1.Format = "N2"
        DataGridViewCellStyle1.NullValue = Nothing
        Me.Cantidad.DefaultCellStyle = DataGridViewCellStyle1
        Me.Cantidad.HeaderText = "Cantidad"
        Me.Cantidad.Name = "Cantidad"
        Me.Cantidad.Width = 70
        '
        'Descripcion
        '
        Me.Descripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Descripcion.HeaderText = "Descripcion"
        Me.Descripcion.MaxInputLength = 50
        Me.Descripcion.Name = "Descripcion"
        '
        'txt_NroSoli
        '
        Me.txt_NroSoli.Location = New System.Drawing.Point(114, 61)
        Me.txt_NroSoli.Name = "txt_NroSoli"
        Me.txt_NroSoli.ReadOnly = True
        Me.txt_NroSoli.Size = New System.Drawing.Size(100, 22)
        Me.txt_NroSoli.TabIndex = 12
        Me.txt_NroSoli.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(5, 64)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(88, 17)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "Nro Solicitud"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(319, 64)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(47, 17)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "Fecha"
        '
        'txt_Fecha
        '
        Me.txt_Fecha.Location = New System.Drawing.Point(372, 61)
        Me.txt_Fecha.Mask = "00/00/0000"
        Me.txt_Fecha.Name = "txt_Fecha"
        Me.txt_Fecha.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txt_Fecha.ReadOnly = True
        Me.txt_Fecha.Size = New System.Drawing.Size(87, 22)
        Me.txt_Fecha.TabIndex = 15
        Me.txt_Fecha.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(579, 64)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(48, 17)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "Planta"
        '
        'txt_Planta
        '
        Me.txt_Planta.Location = New System.Drawing.Point(633, 61)
        Me.txt_Planta.Name = "txt_Planta"
        Me.txt_Planta.ReadOnly = True
        Me.txt_Planta.Size = New System.Drawing.Size(100, 22)
        Me.txt_Planta.TabIndex = 17
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(5, 98)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(73, 17)
        Me.Label6.TabIndex = 18
        Me.Label6.Text = "Solicitante"
        '
        'txt_Solicitante
        '
        Me.txt_Solicitante.Location = New System.Drawing.Point(114, 95)
        Me.txt_Solicitante.MaxLength = 30
        Me.txt_Solicitante.Name = "txt_Solicitante"
        Me.txt_Solicitante.ReadOnly = True
        Me.txt_Solicitante.Size = New System.Drawing.Size(412, 22)
        Me.txt_Solicitante.TabIndex = 19
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(543, 96)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(101, 17)
        Me.Label7.TabIndex = 20
        Me.Label7.Text = "Fecha Entraga"
        '
        'txt_FechaEntrega
        '
        Me.txt_FechaEntrega.Location = New System.Drawing.Point(650, 93)
        Me.txt_FechaEntrega.Mask = "00/00/0000"
        Me.txt_FechaEntrega.Name = "txt_FechaEntrega"
        Me.txt_FechaEntrega.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txt_FechaEntrega.ReadOnly = True
        Me.txt_FechaEntrega.Size = New System.Drawing.Size(83, 22)
        Me.txt_FechaEntrega.TabIndex = 21
        Me.txt_FechaEntrega.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(532, 132)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(36, 17)
        Me.Label8.TabIndex = 22
        Me.Label8.Text = "Tipo"
        '
        'txt_Observaciones
        '
        Me.txt_Observaciones.Location = New System.Drawing.Point(114, 131)
        Me.txt_Observaciones.MaxLength = 100
        Me.txt_Observaciones.Name = "txt_Observaciones"
        Me.txt_Observaciones.ReadOnly = True
        Me.txt_Observaciones.Size = New System.Drawing.Size(417, 22)
        Me.txt_Observaciones.TabIndex = 23
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(5, 134)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(103, 17)
        Me.Label9.TabIndex = 24
        Me.Label9.Text = "Observaciones"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(12, 453)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(87, 17)
        Me.Label10.TabIndex = 26
        Me.Label10.Text = "Comentarios"
        '
        'txt_Comentarios
        '
        Me.txt_Comentarios.Location = New System.Drawing.Point(117, 450)
        Me.txt_Comentarios.MaxLength = 350
        Me.txt_Comentarios.Multiline = True
        Me.txt_Comentarios.Name = "txt_Comentarios"
        Me.txt_Comentarios.Size = New System.Drawing.Size(616, 94)
        Me.txt_Comentarios.TabIndex = 25
        '
        'btn_Autorizar
        '
        Me.btn_Autorizar.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btn_Autorizar.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Autorizar.Location = New System.Drawing.Point(225, 563)
        Me.btn_Autorizar.Name = "btn_Autorizar"
        Me.btn_Autorizar.Size = New System.Drawing.Size(130, 43)
        Me.btn_Autorizar.TabIndex = 27
        Me.btn_Autorizar.Text = "AUTORIZAR"
        Me.btn_Autorizar.UseVisualStyleBackColor = False
        '
        'btn_Rechazar
        '
        Me.btn_Rechazar.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btn_Rechazar.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Rechazar.ForeColor = System.Drawing.SystemColors.Control
        Me.btn_Rechazar.Location = New System.Drawing.Point(393, 563)
        Me.btn_Rechazar.Name = "btn_Rechazar"
        Me.btn_Rechazar.Size = New System.Drawing.Size(130, 43)
        Me.btn_Rechazar.TabIndex = 28
        Me.btn_Rechazar.Text = "RECHAZAR"
        Me.btn_Rechazar.UseVisualStyleBackColor = False
        '
        'btn_Cerrar
        '
        Me.btn_Cerrar.Location = New System.Drawing.Point(561, 563)
        Me.btn_Cerrar.Name = "btn_Cerrar"
        Me.btn_Cerrar.Size = New System.Drawing.Size(130, 43)
        Me.btn_Cerrar.TabIndex = 29
        Me.btn_Cerrar.Text = "CERRAR"
        Me.btn_Cerrar.UseVisualStyleBackColor = True
        '
        'btn_Grabar
        '
        Me.btn_Grabar.Location = New System.Drawing.Point(55, 563)
        Me.btn_Grabar.Name = "btn_Grabar"
        Me.btn_Grabar.Size = New System.Drawing.Size(130, 43)
        Me.btn_Grabar.TabIndex = 30
        Me.btn_Grabar.Text = "GRABAR"
        Me.btn_Grabar.UseVisualStyleBackColor = True
        '
        'cbx_Tipo
        '
        Me.cbx_Tipo.Enabled = False
        Me.cbx_Tipo.FormattingEnabled = True
        Me.cbx_Tipo.Items.AddRange(New Object() {"Insumos/Repuestos", "Servicios", "Sistemas"})
        Me.cbx_Tipo.Location = New System.Drawing.Point(566, 128)
        Me.cbx_Tipo.Name = "cbx_Tipo"
        Me.cbx_Tipo.Size = New System.Drawing.Size(167, 24)
        Me.cbx_Tipo.TabIndex = 31
        '
        'Vista_Insumos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(741, 615)
        Me.Controls.Add(Me.cbx_Tipo)
        Me.Controls.Add(Me.btn_Grabar)
        Me.Controls.Add(Me.btn_Cerrar)
        Me.Controls.Add(Me.btn_Rechazar)
        Me.Controls.Add(Me.btn_Autorizar)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txt_Comentarios)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txt_Observaciones)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txt_FechaEntrega)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txt_Solicitante)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txt_Planta)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txt_Fecha)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txt_NroSoli)
        Me.Controls.Add(Me.dgv_Insumos)
        Me.Controls.Add(Me.panel1)
        Me.Name = "Vista_Insumos"
        Me.panel1.ResumeLayout(False)
        Me.panel1.PerformLayout()
        CType(Me.dgv_Insumos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents panel1 As System.Windows.Forms.Panel
    Private WithEvents Label2 As System.Windows.Forms.Label
    Private WithEvents label1 As System.Windows.Forms.Label
    Friend WithEvents dgv_Insumos As Util.DBDataGridView
    Friend WithEvents txt_NroSoli As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txt_Fecha As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txt_Planta As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txt_Solicitante As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txt_FechaEntrega As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txt_Observaciones As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txt_Comentarios As System.Windows.Forms.TextBox
    Friend WithEvents btn_Autorizar As System.Windows.Forms.Button
    Friend WithEvents btn_Rechazar As System.Windows.Forms.Button
    Friend WithEvents btn_Cerrar As System.Windows.Forms.Button
    Friend WithEvents btn_Grabar As System.Windows.Forms.Button
    Friend WithEvents cbx_Tipo As System.Windows.Forms.ComboBox
    Friend WithEvents Cantidad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Descripcion As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
