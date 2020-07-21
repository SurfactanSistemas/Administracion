<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class IngresoObservaciones_Orden
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
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.DGV_Observaciones = New Util.DBDataGridView()
        Me.panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.label1 = New System.Windows.Forms.Label()
        Me.txt_FechaEmbarque = New System.Windows.Forms.MaskedTextBox()
        Me.txt_FechaLlegada = New System.Windows.Forms.MaskedTextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txt_ImpoDespacho = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Cbx_PagoDespacho = New System.Windows.Forms.ComboBox()
        Me.txt_VtoLetra = New System.Windows.Forms.MaskedTextBox()
        Me.txt_VtoLetraII = New System.Windows.Forms.MaskedTextBox()
        Me.cbx_PagoLetra = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cbx_EntregaI = New System.Windows.Forms.ComboBox()
        Me.cbx_EntregaII = New System.Windows.Forms.ComboBox()
        Me.btn_FinIngreso = New System.Windows.Forms.Button()
        Me.txt_ImpoLetra = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txt_VtoDespacho = New System.Windows.Forms.MaskedTextBox()
        Me.Fecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Observaciones = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.DGV_Observaciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'DGV_Observaciones
        '
        Me.DGV_Observaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_Observaciones.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Fecha, Me.Observaciones})
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(232, Byte), Integer))
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGV_Observaciones.DefaultCellStyle = DataGridViewCellStyle6
        Me.DGV_Observaciones.DoubleBuffered = True
        Me.DGV_Observaciones.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.DGV_Observaciones.Location = New System.Drawing.Point(12, 46)
        Me.DGV_Observaciones.Name = "DGV_Observaciones"
        Me.DGV_Observaciones.OrdenamientoColumnasHabilitado = True
        Me.DGV_Observaciones.RowHeadersWidth = 15
        Me.DGV_Observaciones.RowTemplate.Height = 20
        Me.DGV_Observaciones.ShowCellToolTips = False
        Me.DGV_Observaciones.SinClickDerecho = False
        Me.DGV_Observaciones.Size = New System.Drawing.Size(514, 262)
        Me.DGV_Observaciones.TabIndex = 0
        '
        'panel1
        '
        Me.panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(34, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.panel1.Controls.Add(Me.Label2)
        Me.panel1.Controls.Add(Me.label1)
        Me.panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.panel1.Location = New System.Drawing.Point(0, 0)
        Me.panel1.Name = "panel1"
        Me.panel1.Size = New System.Drawing.Size(727, 40)
        Me.panel1.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(568, 19)
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
        Me.label1.Size = New System.Drawing.Size(206, 17)
        Me.label1.TabIndex = 0
        Me.label1.Text = "Ingresos de Observaciones"
        '
        'txt_FechaEmbarque
        '
        Me.txt_FechaEmbarque.Location = New System.Drawing.Point(539, 62)
        Me.txt_FechaEmbarque.Mask = "00/00/0000"
        Me.txt_FechaEmbarque.Name = "txt_FechaEmbarque"
        Me.txt_FechaEmbarque.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txt_FechaEmbarque.Size = New System.Drawing.Size(70, 20)
        Me.txt_FechaEmbarque.TabIndex = 7
        '
        'txt_FechaLlegada
        '
        Me.txt_FechaLlegada.Location = New System.Drawing.Point(539, 109)
        Me.txt_FechaLlegada.Mask = "00/00/0000"
        Me.txt_FechaLlegada.Name = "txt_FechaLlegada"
        Me.txt_FechaLlegada.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txt_FechaLlegada.Size = New System.Drawing.Size(70, 20)
        Me.txt_FechaLlegada.TabIndex = 8
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(536, 46)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(103, 13)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Fecha de Embarque"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(536, 93)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(123, 13)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Fecha Prevista de Arribo"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(536, 136)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(109, 13)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Importe de Despacho"
        '
        'txt_ImpoDespacho
        '
        Me.txt_ImpoDespacho.Location = New System.Drawing.Point(539, 152)
        Me.txt_ImpoDespacho.Name = "txt_ImpoDespacho"
        Me.txt_ImpoDespacho.Size = New System.Drawing.Size(100, 20)
        Me.txt_ImpoDespacho.TabIndex = 12
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(536, 177)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(107, 13)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "Estado de Despacho"
        '
        'Cbx_PagoDespacho
        '
        Me.Cbx_PagoDespacho.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cbx_PagoDespacho.FormattingEnabled = True
        Me.Cbx_PagoDespacho.Items.AddRange(New Object() {"Pendiente", "Efectuado"})
        Me.Cbx_PagoDespacho.Location = New System.Drawing.Point(539, 193)
        Me.Cbx_PagoDespacho.Name = "Cbx_PagoDespacho"
        Me.Cbx_PagoDespacho.Size = New System.Drawing.Size(121, 21)
        Me.Cbx_PagoDespacho.TabIndex = 14
        '
        'txt_VtoLetra
        '
        Me.txt_VtoLetra.Location = New System.Drawing.Point(539, 272)
        Me.txt_VtoLetra.Mask = "00/00/0000"
        Me.txt_VtoLetra.Name = "txt_VtoLetra"
        Me.txt_VtoLetra.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txt_VtoLetra.Size = New System.Drawing.Size(70, 20)
        Me.txt_VtoLetra.TabIndex = 15
        '
        'txt_VtoLetraII
        '
        Me.txt_VtoLetraII.Location = New System.Drawing.Point(539, 316)
        Me.txt_VtoLetraII.Mask = "00/00/0000"
        Me.txt_VtoLetraII.Name = "txt_VtoLetraII"
        Me.txt_VtoLetraII.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txt_VtoLetraII.Size = New System.Drawing.Size(70, 20)
        Me.txt_VtoLetraII.TabIndex = 16
        '
        'cbx_PagoLetra
        '
        Me.cbx_PagoLetra.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbx_PagoLetra.FormattingEnabled = True
        Me.cbx_PagoLetra.Items.AddRange(New Object() {"Pendiente", "Efectuado"})
        Me.cbx_PagoLetra.Location = New System.Drawing.Point(539, 355)
        Me.cbx_PagoLetra.Name = "cbx_PagoLetra"
        Me.cbx_PagoLetra.Size = New System.Drawing.Size(121, 21)
        Me.cbx_PagoLetra.TabIndex = 17
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(536, 217)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(95, 13)
        Me.Label7.TabIndex = 18
        Me.Label7.Text = "Importe de la Letra"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(536, 256)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(118, 13)
        Me.Label8.TabIndex = 19
        Me.Label8.Text = "Vencimiento de la Letra"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(536, 300)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(191, 13)
        Me.Label9.TabIndex = 20
        Me.Label9.Text = "Fecha Real de Vencimiento de la Letra"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(5, 319)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(110, 13)
        Me.Label10.TabIndex = 21
        Me.Label10.Text = "Certificado de Analisis"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(141, 319)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(128, 13)
        Me.Label11.TabIndex = 22
        Me.Label11.Text = "Documento de Embarque"
        '
        'cbx_EntregaI
        '
        Me.cbx_EntregaI.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbx_EntregaI.FormattingEnabled = True
        Me.cbx_EntregaI.Items.AddRange(New Object() {"Pendiente", "Entregado"})
        Me.cbx_EntregaI.Location = New System.Drawing.Point(8, 339)
        Me.cbx_EntregaI.Name = "cbx_EntregaI"
        Me.cbx_EntregaI.Size = New System.Drawing.Size(121, 21)
        Me.cbx_EntregaI.TabIndex = 23
        '
        'cbx_EntregaII
        '
        Me.cbx_EntregaII.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbx_EntregaII.FormattingEnabled = True
        Me.cbx_EntregaII.Items.AddRange(New Object() {"Pendiente", "Entregado"})
        Me.cbx_EntregaII.Location = New System.Drawing.Point(144, 339)
        Me.cbx_EntregaII.Name = "cbx_EntregaII"
        Me.cbx_EntregaII.Size = New System.Drawing.Size(121, 21)
        Me.cbx_EntregaII.TabIndex = 24
        '
        'btn_FinIngreso
        '
        Me.btn_FinIngreso.Location = New System.Drawing.Point(354, 327)
        Me.btn_FinIngreso.Name = "btn_FinIngreso"
        Me.btn_FinIngreso.Size = New System.Drawing.Size(132, 33)
        Me.btn_FinIngreso.TabIndex = 25
        Me.btn_FinIngreso.Text = "FIN DE INGRESO"
        Me.btn_FinIngreso.UseVisualStyleBackColor = True
        '
        'txt_ImpoLetra
        '
        Me.txt_ImpoLetra.Location = New System.Drawing.Point(539, 233)
        Me.txt_ImpoLetra.Name = "txt_ImpoLetra"
        Me.txt_ImpoLetra.Size = New System.Drawing.Size(100, 20)
        Me.txt_ImpoLetra.TabIndex = 26
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(536, 339)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(82, 13)
        Me.Label12.TabIndex = 27
        Me.Label12.Text = "Estado de Letra"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(275, 319)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(173, 13)
        Me.Label13.TabIndex = 29
        Me.Label13.Text = "Fecha Prevista de Pago Despacho"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Label13.Visible = False
        '
        'txt_VtoDespacho
        '
        Me.txt_VtoDespacho.Location = New System.Drawing.Point(278, 339)
        Me.txt_VtoDespacho.Mask = "00/00/0000"
        Me.txt_VtoDespacho.Name = "txt_VtoDespacho"
        Me.txt_VtoDespacho.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txt_VtoDespacho.Size = New System.Drawing.Size(70, 20)
        Me.txt_VtoDespacho.TabIndex = 28
        Me.txt_VtoDespacho.Visible = False
        '
        'Fecha
        '
        Me.Fecha.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Fecha.HeaderText = "Fecha"
        Me.Fecha.MaxInputLength = 12
        Me.Fecha.Name = "Fecha"
        Me.Fecha.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Fecha.Width = 62
        '
        'Observaciones
        '
        Me.Observaciones.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Observaciones.DefaultCellStyle = DataGridViewCellStyle5
        Me.Observaciones.HeaderText = "Observaciones"
        Me.Observaciones.MaxInputLength = 80
        Me.Observaciones.Name = "Observaciones"
        '
        'IngresoObservaciones_Orden
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(727, 381)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.txt_VtoDespacho)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.txt_ImpoLetra)
        Me.Controls.Add(Me.btn_FinIngreso)
        Me.Controls.Add(Me.cbx_EntregaII)
        Me.Controls.Add(Me.cbx_EntregaI)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.cbx_PagoLetra)
        Me.Controls.Add(Me.txt_VtoLetraII)
        Me.Controls.Add(Me.txt_VtoLetra)
        Me.Controls.Add(Me.Cbx_PagoDespacho)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txt_ImpoDespacho)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txt_FechaLlegada)
        Me.Controls.Add(Me.txt_FechaEmbarque)
        Me.Controls.Add(Me.panel1)
        Me.Controls.Add(Me.DGV_Observaciones)
        Me.Name = "IngresoObservaciones_Orden"
        CType(Me.DGV_Observaciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panel1.ResumeLayout(False)
        Me.panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DGV_Observaciones As Util.DBDataGridView
    Private WithEvents panel1 As System.Windows.Forms.Panel
    Private WithEvents Label2 As System.Windows.Forms.Label
    Private WithEvents label1 As System.Windows.Forms.Label
    Friend WithEvents txt_FechaEmbarque As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txt_FechaLlegada As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txt_ImpoDespacho As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Cbx_PagoDespacho As System.Windows.Forms.ComboBox
    Friend WithEvents txt_VtoLetra As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txt_VtoLetraII As System.Windows.Forms.MaskedTextBox
    Friend WithEvents cbx_PagoLetra As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cbx_EntregaI As System.Windows.Forms.ComboBox
    Friend WithEvents cbx_EntregaII As System.Windows.Forms.ComboBox
    Friend WithEvents btn_FinIngreso As System.Windows.Forms.Button
    Friend WithEvents txt_ImpoLetra As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txt_VtoDespacho As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Fecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Observaciones As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
