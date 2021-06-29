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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txt_VtoDespacho = New System.Windows.Forms.MaskedTextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txt_ImpoLetra = New System.Windows.Forms.TextBox()
        Me.btn_FinIngreso = New System.Windows.Forms.Button()
        Me.cbx_EntregaII = New System.Windows.Forms.ComboBox()
        Me.cbx_EntregaI = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cbx_PagoLetra = New System.Windows.Forms.ComboBox()
        Me.txt_VtoLetraII = New System.Windows.Forms.MaskedTextBox()
        Me.txt_VtoLetra = New System.Windows.Forms.MaskedTextBox()
        Me.Cbx_PagoDespacho = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txt_ImpoDespacho = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txt_FechaLlegada = New System.Windows.Forms.MaskedTextBox()
        Me.txt_FechaEmbarque = New System.Windows.Forms.MaskedTextBox()
        Me.DGV_Observaciones = New Util.DBDataGridView()
        Me.Fecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Observaciones = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.label1 = New System.Windows.Forms.Label()
        CType(Me.DGV_Observaciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(364, 397)
        Me.Label13.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(227, 17)
        Me.Label13.TabIndex = 53
        Me.Label13.Text = "Fecha Prevista de Pago Despacho"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Label13.Visible = False
        '
        'txt_VtoDespacho
        '
        Me.txt_VtoDespacho.Location = New System.Drawing.Point(368, 421)
        Me.txt_VtoDespacho.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_VtoDespacho.Mask = "00/00/0000"
        Me.txt_VtoDespacho.Name = "txt_VtoDespacho"
        Me.txt_VtoDespacho.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txt_VtoDespacho.Size = New System.Drawing.Size(92, 22)
        Me.txt_VtoDespacho.TabIndex = 52
        Me.txt_VtoDespacho.Visible = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(712, 421)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(109, 17)
        Me.Label12.TabIndex = 51
        Me.Label12.Text = "Estado de Letra"
        '
        'txt_ImpoLetra
        '
        Me.txt_ImpoLetra.Location = New System.Drawing.Point(716, 291)
        Me.txt_ImpoLetra.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_ImpoLetra.Name = "txt_ImpoLetra"
        Me.txt_ImpoLetra.Size = New System.Drawing.Size(132, 22)
        Me.txt_ImpoLetra.TabIndex = 50
        '
        'btn_FinIngreso
        '
        Me.btn_FinIngreso.Location = New System.Drawing.Point(500, 421)
        Me.btn_FinIngreso.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_FinIngreso.Name = "btn_FinIngreso"
        Me.btn_FinIngreso.Size = New System.Drawing.Size(176, 41)
        Me.btn_FinIngreso.TabIndex = 49
        Me.btn_FinIngreso.Text = "FIN DE INGRESO"
        Me.btn_FinIngreso.UseVisualStyleBackColor = True
        '
        'cbx_EntregaII
        '
        Me.cbx_EntregaII.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbx_EntregaII.FormattingEnabled = True
        Me.cbx_EntregaII.Items.AddRange(New Object() {"Pendiente", "Entregado"})
        Me.cbx_EntregaII.Location = New System.Drawing.Point(189, 421)
        Me.cbx_EntregaII.Margin = New System.Windows.Forms.Padding(4)
        Me.cbx_EntregaII.Name = "cbx_EntregaII"
        Me.cbx_EntregaII.Size = New System.Drawing.Size(160, 24)
        Me.cbx_EntregaII.TabIndex = 48
        '
        'cbx_EntregaI
        '
        Me.cbx_EntregaI.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbx_EntregaI.FormattingEnabled = True
        Me.cbx_EntregaI.Items.AddRange(New Object() {"Pendiente", "Entregado"})
        Me.cbx_EntregaI.Location = New System.Drawing.Point(8, 421)
        Me.cbx_EntregaI.Margin = New System.Windows.Forms.Padding(4)
        Me.cbx_EntregaI.Name = "cbx_EntregaI"
        Me.cbx_EntregaI.Size = New System.Drawing.Size(160, 24)
        Me.cbx_EntregaI.TabIndex = 47
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(185, 397)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(169, 17)
        Me.Label11.TabIndex = 46
        Me.Label11.Text = "Documento de Embarque"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(4, 397)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(147, 17)
        Me.Label10.TabIndex = 45
        Me.Label10.Text = "Certificado de Analisis"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(712, 373)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(253, 17)
        Me.Label9.TabIndex = 44
        Me.Label9.Text = "Fecha Real de Vencimiento de la Letra"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(712, 319)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(157, 17)
        Me.Label8.TabIndex = 43
        Me.Label8.Text = "Vencimiento de la Letra"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(712, 271)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(127, 17)
        Me.Label7.TabIndex = 42
        Me.Label7.Text = "Importe de la Letra"
        '
        'cbx_PagoLetra
        '
        Me.cbx_PagoLetra.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbx_PagoLetra.FormattingEnabled = True
        Me.cbx_PagoLetra.Items.AddRange(New Object() {"Pendiente", "Efectuado"})
        Me.cbx_PagoLetra.Location = New System.Drawing.Point(716, 441)
        Me.cbx_PagoLetra.Margin = New System.Windows.Forms.Padding(4)
        Me.cbx_PagoLetra.Name = "cbx_PagoLetra"
        Me.cbx_PagoLetra.Size = New System.Drawing.Size(160, 24)
        Me.cbx_PagoLetra.TabIndex = 41
        '
        'txt_VtoLetraII
        '
        Me.txt_VtoLetraII.Location = New System.Drawing.Point(716, 393)
        Me.txt_VtoLetraII.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_VtoLetraII.Mask = "00/00/0000"
        Me.txt_VtoLetraII.Name = "txt_VtoLetraII"
        Me.txt_VtoLetraII.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txt_VtoLetraII.Size = New System.Drawing.Size(92, 22)
        Me.txt_VtoLetraII.TabIndex = 40
        '
        'txt_VtoLetra
        '
        Me.txt_VtoLetra.Location = New System.Drawing.Point(716, 339)
        Me.txt_VtoLetra.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_VtoLetra.Mask = "00/00/0000"
        Me.txt_VtoLetra.Name = "txt_VtoLetra"
        Me.txt_VtoLetra.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txt_VtoLetra.Size = New System.Drawing.Size(92, 22)
        Me.txt_VtoLetra.TabIndex = 39
        '
        'Cbx_PagoDespacho
        '
        Me.Cbx_PagoDespacho.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cbx_PagoDespacho.FormattingEnabled = True
        Me.Cbx_PagoDespacho.Items.AddRange(New Object() {"Pendiente", "Efectuado"})
        Me.Cbx_PagoDespacho.Location = New System.Drawing.Point(716, 242)
        Me.Cbx_PagoDespacho.Margin = New System.Windows.Forms.Padding(4)
        Me.Cbx_PagoDespacho.Name = "Cbx_PagoDespacho"
        Me.Cbx_PagoDespacho.Size = New System.Drawing.Size(160, 24)
        Me.Cbx_PagoDespacho.TabIndex = 38
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(712, 222)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(140, 17)
        Me.Label6.TabIndex = 37
        Me.Label6.Text = "Estado de Despacho"
        '
        'txt_ImpoDespacho
        '
        Me.txt_ImpoDespacho.Location = New System.Drawing.Point(716, 191)
        Me.txt_ImpoDespacho.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_ImpoDespacho.Name = "txt_ImpoDespacho"
        Me.txt_ImpoDespacho.Size = New System.Drawing.Size(132, 22)
        Me.txt_ImpoDespacho.TabIndex = 36
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(712, 171)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(143, 17)
        Me.Label5.TabIndex = 35
        Me.Label5.Text = "Importe de Despacho"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(712, 118)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(164, 17)
        Me.Label4.TabIndex = 34
        Me.Label4.Text = "Fecha Prevista de Arribo"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(712, 61)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(136, 17)
        Me.Label3.TabIndex = 33
        Me.Label3.Text = "Fecha de Embarque"
        '
        'txt_FechaLlegada
        '
        Me.txt_FechaLlegada.Location = New System.Drawing.Point(716, 138)
        Me.txt_FechaLlegada.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_FechaLlegada.Mask = "00/00/0000"
        Me.txt_FechaLlegada.Name = "txt_FechaLlegada"
        Me.txt_FechaLlegada.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txt_FechaLlegada.Size = New System.Drawing.Size(92, 22)
        Me.txt_FechaLlegada.TabIndex = 32
        '
        'txt_FechaEmbarque
        '
        Me.txt_FechaEmbarque.Location = New System.Drawing.Point(716, 80)
        Me.txt_FechaEmbarque.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_FechaEmbarque.Mask = "00/00/0000"
        Me.txt_FechaEmbarque.Name = "txt_FechaEmbarque"
        Me.txt_FechaEmbarque.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txt_FechaEmbarque.Size = New System.Drawing.Size(92, 22)
        Me.txt_FechaEmbarque.TabIndex = 31
        '
        'DGV_Observaciones
        '
        Me.DGV_Observaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_Observaciones.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Fecha, Me.Observaciones})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(232, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGV_Observaciones.DefaultCellStyle = DataGridViewCellStyle2
        Me.DGV_Observaciones.DoubleBuffered = True
        Me.DGV_Observaciones.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.DGV_Observaciones.Location = New System.Drawing.Point(13, 61)
        Me.DGV_Observaciones.Margin = New System.Windows.Forms.Padding(4)
        Me.DGV_Observaciones.Name = "DGV_Observaciones"
        Me.DGV_Observaciones.OrdenamientoColumnasHabilitado = True
        Me.DGV_Observaciones.RowHeadersWidth = 15
        Me.DGV_Observaciones.RowTemplate.Height = 20
        Me.DGV_Observaciones.ShowCellToolTips = False
        Me.DGV_Observaciones.SinClickDerecho = False
        Me.DGV_Observaciones.Size = New System.Drawing.Size(685, 322)
        Me.DGV_Observaciones.TabIndex = 30
        '
        'Fecha
        '
        Me.Fecha.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Fecha.HeaderText = "Fecha"
        Me.Fecha.MaxInputLength = 12
        Me.Fecha.Name = "Fecha"
        Me.Fecha.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Fecha.Width = 76
        '
        'Observaciones
        '
        Me.Observaciones.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Observaciones.DefaultCellStyle = DataGridViewCellStyle1
        Me.Observaciones.HeaderText = "Observaciones"
        Me.Observaciones.MaxInputLength = 80
        Me.Observaciones.Name = "Observaciones"
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
        Me.panel1.Size = New System.Drawing.Size(968, 49)
        Me.panel1.TabIndex = 54
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(756, 23)
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
        Me.label1.Location = New System.Drawing.Point(16, 11)
        Me.label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(238, 20)
        Me.label1.TabIndex = 0
        Me.label1.Text = "Ingresos de Observaciones"
        '
        'IngresoObservaciones_Orden
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(968, 473)
        Me.Controls.Add(Me.panel1)
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
        Me.Controls.Add(Me.DGV_Observaciones)
        Me.Name = "IngresoObservaciones_Orden"
        CType(Me.DGV_Observaciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panel1.ResumeLayout(False)
        Me.panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txt_VtoDespacho As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txt_ImpoLetra As System.Windows.Forms.TextBox
    Friend WithEvents btn_FinIngreso As System.Windows.Forms.Button
    Friend WithEvents cbx_EntregaII As System.Windows.Forms.ComboBox
    Friend WithEvents cbx_EntregaI As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cbx_PagoLetra As System.Windows.Forms.ComboBox
    Friend WithEvents txt_VtoLetraII As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txt_VtoLetra As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Cbx_PagoDespacho As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txt_ImpoDespacho As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txt_FechaLlegada As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txt_FechaEmbarque As System.Windows.Forms.MaskedTextBox
    Friend WithEvents DGV_Observaciones As Util.DBDataGridView
    Friend WithEvents Fecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Observaciones As System.Windows.Forms.DataGridViewTextBoxColumn
    Private WithEvents panel1 As System.Windows.Forms.Panel
    Private WithEvents Label2 As System.Windows.Forms.Label
    Private WithEvents label1 As System.Windows.Forms.Label
End Class
