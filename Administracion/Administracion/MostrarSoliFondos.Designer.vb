<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MostrarSoliFondos
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
        Me.txt_NroSolicitud = New System.Windows.Forms.TextBox()
        Me.txt_Solicitante = New System.Windows.Forms.TextBox()
        Me.txt_Destino = New System.Windows.Forms.TextBox()
        Me.txt_Importe = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txt_DescripDestino = New System.Windows.Forms.TextBox()
        Me.dgv_FormasPago = New Util.DBDataGridView()
        Me.FormaPago = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txt_ImporteTotal = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txt_Paridad = New System.Windows.Forms.TextBox()
        Me.txt_Detalle = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.btn_Cerrar = New System.Windows.Forms.Button()
        Me.txt_DetalleDePago = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txt_Titulo = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txt_TipoParidad = New System.Windows.Forms.TextBox()
        Me.panel1.SuspendLayout()
        CType(Me.dgv_FormasPago, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.panel1.Size = New System.Drawing.Size(415, 40)
        Me.panel1.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(239, 10)
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
        Me.label1.Location = New System.Drawing.Point(12, 9)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(170, 17)
        Me.label1.TabIndex = 0
        Me.label1.Text = "MOSTRAR SOLICITUD"
        '
        'txt_NroSolicitud
        '
        Me.txt_NroSolicitud.BackColor = System.Drawing.Color.Aqua
        Me.txt_NroSolicitud.Location = New System.Drawing.Point(81, 43)
        Me.txt_NroSolicitud.Name = "txt_NroSolicitud"
        Me.txt_NroSolicitud.Size = New System.Drawing.Size(67, 20)
        Me.txt_NroSolicitud.TabIndex = 7
        Me.txt_NroSolicitud.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_Solicitante
        '
        Me.txt_Solicitante.BackColor = System.Drawing.Color.Aqua
        Me.txt_Solicitante.Location = New System.Drawing.Point(81, 69)
        Me.txt_Solicitante.Name = "txt_Solicitante"
        Me.txt_Solicitante.Size = New System.Drawing.Size(197, 20)
        Me.txt_Solicitante.TabIndex = 8
        '
        'txt_Destino
        '
        Me.txt_Destino.BackColor = System.Drawing.Color.Aqua
        Me.txt_Destino.Location = New System.Drawing.Point(81, 95)
        Me.txt_Destino.Name = "txt_Destino"
        Me.txt_Destino.Size = New System.Drawing.Size(107, 20)
        Me.txt_Destino.TabIndex = 9
        '
        'txt_Importe
        '
        Me.txt_Importe.BackColor = System.Drawing.Color.Aqua
        Me.txt_Importe.Location = New System.Drawing.Point(81, 121)
        Me.txt_Importe.Name = "txt_Importe"
        Me.txt_Importe.Size = New System.Drawing.Size(107, 20)
        Me.txt_Importe.TabIndex = 10
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(7, 46)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(70, 13)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Nro. Solicitud"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(7, 72)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(56, 13)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Solicitante"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(7, 98)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(43, 13)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "Destino"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(7, 124)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(42, 13)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "Importe"
        '
        'txt_DescripDestino
        '
        Me.txt_DescripDestino.BackColor = System.Drawing.Color.Aqua
        Me.txt_DescripDestino.Location = New System.Drawing.Point(194, 95)
        Me.txt_DescripDestino.Name = "txt_DescripDestino"
        Me.txt_DescripDestino.Size = New System.Drawing.Size(218, 20)
        Me.txt_DescripDestino.TabIndex = 15
        '
        'dgv_FormasPago
        '
        Me.dgv_FormasPago.AllowUserToAddRows = False
        Me.dgv_FormasPago.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_FormasPago.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.FormaPago})
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(232, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv_FormasPago.DefaultCellStyle = DataGridViewCellStyle1
        Me.dgv_FormasPago.DoubleBuffered = True
        Me.dgv_FormasPago.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dgv_FormasPago.Location = New System.Drawing.Point(10, 268)
        Me.dgv_FormasPago.Name = "dgv_FormasPago"
        Me.dgv_FormasPago.OrdenamientoColumnasHabilitado = True
        Me.dgv_FormasPago.RowHeadersWidth = 15
        Me.dgv_FormasPago.RowTemplate.Height = 20
        Me.dgv_FormasPago.ShowCellToolTips = False
        Me.dgv_FormasPago.SinClickDerecho = False
        Me.dgv_FormasPago.Size = New System.Drawing.Size(399, 132)
        Me.dgv_FormasPago.TabIndex = 16
        '
        'FormaPago
        '
        Me.FormaPago.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.FormaPago.HeaderText = "Formas de Pago"
        Me.FormaPago.Name = "FormaPago"
        Me.FormaPago.ReadOnly = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(7, 251)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(84, 13)
        Me.Label7.TabIndex = 17
        Me.Label7.Text = "Formas de Pago"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(7, 150)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(69, 13)
        Me.Label8.TabIndex = 19
        Me.Label8.Text = "Importe Total"
        '
        'txt_ImporteTotal
        '
        Me.txt_ImporteTotal.BackColor = System.Drawing.Color.Aqua
        Me.txt_ImporteTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_ImporteTotal.Location = New System.Drawing.Point(81, 147)
        Me.txt_ImporteTotal.Name = "txt_ImporteTotal"
        Me.txt_ImporteTotal.Size = New System.Drawing.Size(107, 20)
        Me.txt_ImporteTotal.TabIndex = 18
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(221, 124)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(43, 13)
        Me.Label9.TabIndex = 21
        Me.Label9.Text = "Paridad"
        Me.Label9.Visible = False
        '
        'txt_Paridad
        '
        Me.txt_Paridad.BackColor = System.Drawing.Color.Aqua
        Me.txt_Paridad.Location = New System.Drawing.Point(284, 121)
        Me.txt_Paridad.Name = "txt_Paridad"
        Me.txt_Paridad.Size = New System.Drawing.Size(107, 20)
        Me.txt_Paridad.TabIndex = 20
        Me.txt_Paridad.Visible = False
        '
        'txt_Detalle
        '
        Me.txt_Detalle.BackColor = System.Drawing.Color.Aqua
        Me.txt_Detalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Detalle.Location = New System.Drawing.Point(81, 201)
        Me.txt_Detalle.MaxLength = 100
        Me.txt_Detalle.Multiline = True
        Me.txt_Detalle.Name = "txt_Detalle"
        Me.txt_Detalle.Size = New System.Drawing.Size(328, 48)
        Me.txt_Detalle.TabIndex = 22
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(7, 204)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(40, 13)
        Me.Label10.TabIndex = 23
        Me.Label10.Text = "Detalle"
        '
        'btn_Cerrar
        '
        Me.btn_Cerrar.Location = New System.Drawing.Point(322, 47)
        Me.btn_Cerrar.Name = "btn_Cerrar"
        Me.btn_Cerrar.Size = New System.Drawing.Size(75, 38)
        Me.btn_Cerrar.TabIndex = 24
        Me.btn_Cerrar.Text = "CERRAR"
        Me.btn_Cerrar.UseVisualStyleBackColor = True
        '
        'txt_DetalleDePago
        '
        Me.txt_DetalleDePago.BackColor = System.Drawing.Color.Aqua
        Me.txt_DetalleDePago.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_DetalleDePago.Location = New System.Drawing.Point(75, 406)
        Me.txt_DetalleDePago.MaxLength = 100
        Me.txt_DetalleDePago.Multiline = True
        Me.txt_DetalleDePago.Name = "txt_DetalleDePago"
        Me.txt_DetalleDePago.Size = New System.Drawing.Size(328, 54)
        Me.txt_DetalleDePago.TabIndex = 25
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(12, 409)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(55, 26)
        Me.Label11.TabIndex = 26
        Me.Label11.Text = "Detalle de" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "    Pago"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(7, 178)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(33, 13)
        Me.Label12.TabIndex = 30
        Me.Label12.Text = "Titulo"
        '
        'txt_Titulo
        '
        Me.txt_Titulo.BackColor = System.Drawing.Color.Aqua
        Me.txt_Titulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Titulo.Location = New System.Drawing.Point(81, 175)
        Me.txt_Titulo.Name = "txt_Titulo"
        Me.txt_Titulo.Size = New System.Drawing.Size(328, 20)
        Me.txt_Titulo.TabIndex = 29
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(221, 150)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(56, 13)
        Me.Label13.TabIndex = 32
        Me.Label13.Text = "Tipo Dolar"
        Me.Label13.Visible = False
        '
        'txt_TipoParidad
        '
        Me.txt_TipoParidad.BackColor = System.Drawing.Color.Aqua
        Me.txt_TipoParidad.Location = New System.Drawing.Point(284, 147)
        Me.txt_TipoParidad.Name = "txt_TipoParidad"
        Me.txt_TipoParidad.Size = New System.Drawing.Size(107, 20)
        Me.txt_TipoParidad.TabIndex = 31
        Me.txt_TipoParidad.Visible = False
        '
        'MostrarSoliFondos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(415, 464)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.txt_TipoParidad)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.txt_Titulo)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.txt_DetalleDePago)
        Me.Controls.Add(Me.btn_Cerrar)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txt_Detalle)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txt_Paridad)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txt_ImporteTotal)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.dgv_FormasPago)
        Me.Controls.Add(Me.txt_DescripDestino)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txt_Importe)
        Me.Controls.Add(Me.txt_Destino)
        Me.Controls.Add(Me.txt_Solicitante)
        Me.Controls.Add(Me.txt_NroSolicitud)
        Me.Controls.Add(Me.panel1)
        Me.Name = "MostrarSoliFondos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.panel1.ResumeLayout(False)
        Me.panel1.PerformLayout()
        CType(Me.dgv_FormasPago, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents panel1 As System.Windows.Forms.Panel
    Private WithEvents Label2 As System.Windows.Forms.Label
    Private WithEvents label1 As System.Windows.Forms.Label
    Friend WithEvents txt_NroSolicitud As System.Windows.Forms.TextBox
    Friend WithEvents txt_Solicitante As System.Windows.Forms.TextBox
    Friend WithEvents txt_Destino As System.Windows.Forms.TextBox
    Friend WithEvents txt_Importe As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txt_DescripDestino As System.Windows.Forms.TextBox
    Friend WithEvents dgv_FormasPago As Util.DBDataGridView
    Friend WithEvents FormaPago As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txt_ImporteTotal As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txt_Paridad As System.Windows.Forms.TextBox
    Friend WithEvents txt_Detalle As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents btn_Cerrar As System.Windows.Forms.Button
    Friend WithEvents txt_DetalleDePago As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txt_Titulo As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txt_TipoParidad As System.Windows.Forms.TextBox
End Class
