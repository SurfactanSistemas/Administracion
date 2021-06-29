<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Listados_Pagos_SinImprimir
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txt_FechaHasta = New System.Windows.Forms.MaskedTextBox()
        Me.txt_FechaDesde = New System.Windows.Forms.MaskedTextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btn_Cerrar = New System.Windows.Forms.Button()
        Me.btn_Aceptar = New System.Windows.Forms.Button()
        Me.dgv_Pagos = New Util.DBDataGridView()
        Me.NroPago = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Fecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Destino = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.QuienHizo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ImprimirSeleccionadasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.cbx_QuienHizo = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.optTransferencias = New System.Windows.Forms.RadioButton()
        Me.optAnticipos = New System.Windows.Forms.RadioButton()
        Me.optChequeRechazado = New System.Windows.Forms.RadioButton()
        Me.optVarios = New System.Windows.Forms.RadioButton()
        Me.optCtaCte = New System.Windows.Forms.RadioButton()
        Me.btn_ImprimirTodo = New System.Windows.Forms.Button()
        Me.panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgv_Pagos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
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
        Me.panel1.Size = New System.Drawing.Size(747, 59)
        Me.panel1.TabIndex = 9
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(551, 34)
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
        Me.label1.Location = New System.Drawing.Point(3, 9)
        Me.label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(237, 20)
        Me.label1.TabIndex = 0
        Me.label1.Text = "Listado Pagos Sin Imprimir"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txt_FechaHasta)
        Me.GroupBox1.Controls.Add(Me.txt_FechaDesde)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 66)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(303, 64)
        Me.GroupBox1.TabIndex = 10
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Fechas"
        '
        'txt_FechaHasta
        '
        Me.txt_FechaHasta.Location = New System.Drawing.Point(207, 28)
        Me.txt_FechaHasta.Mask = "00/00/0000"
        Me.txt_FechaHasta.Name = "txt_FechaHasta"
        Me.txt_FechaHasta.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txt_FechaHasta.Size = New System.Drawing.Size(83, 22)
        Me.txt_FechaHasta.TabIndex = 3
        Me.txt_FechaHasta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txt_FechaDesde
        '
        Me.txt_FechaDesde.Location = New System.Drawing.Point(65, 28)
        Me.txt_FechaDesde.Mask = "00/00/0000"
        Me.txt_FechaDesde.Name = "txt_FechaDesde"
        Me.txt_FechaDesde.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txt_FechaDesde.Size = New System.Drawing.Size(83, 22)
        Me.txt_FechaDesde.TabIndex = 2
        Me.txt_FechaDesde.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(156, 31)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(45, 17)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Hasta"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(10, 31)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(49, 17)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Desde"
        '
        'btn_Cerrar
        '
        Me.btn_Cerrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Cerrar.Location = New System.Drawing.Point(504, 102)
        Me.btn_Cerrar.Name = "btn_Cerrar"
        Me.btn_Cerrar.Size = New System.Drawing.Size(117, 38)
        Me.btn_Cerrar.TabIndex = 12
        Me.btn_Cerrar.Text = "CERRAR"
        Me.btn_Cerrar.UseVisualStyleBackColor = True
        '
        'btn_Aceptar
        '
        Me.btn_Aceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Aceptar.Location = New System.Drawing.Point(504, 62)
        Me.btn_Aceptar.Name = "btn_Aceptar"
        Me.btn_Aceptar.Size = New System.Drawing.Size(117, 38)
        Me.btn_Aceptar.TabIndex = 11
        Me.btn_Aceptar.Text = "BUSCAR"
        Me.btn_Aceptar.UseVisualStyleBackColor = True
        '
        'dgv_Pagos
        '
        Me.dgv_Pagos.AllowUserToAddRows = False
        Me.dgv_Pagos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_Pagos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.NroPago, Me.Fecha, Me.Destino, Me.QuienHizo})
        Me.dgv_Pagos.ContextMenuStrip = Me.ContextMenuStrip1
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(232, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv_Pagos.DefaultCellStyle = DataGridViewCellStyle1
        Me.dgv_Pagos.DoubleBuffered = True
        Me.dgv_Pagos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dgv_Pagos.Location = New System.Drawing.Point(12, 144)
        Me.dgv_Pagos.Name = "dgv_Pagos"
        Me.dgv_Pagos.OrdenamientoColumnasHabilitado = True
        Me.dgv_Pagos.RowHeadersWidth = 15
        Me.dgv_Pagos.RowTemplate.Height = 20
        Me.dgv_Pagos.ShowCellToolTips = False
        Me.dgv_Pagos.SinClickDerecho = False
        Me.dgv_Pagos.Size = New System.Drawing.Size(732, 267)
        Me.dgv_Pagos.TabIndex = 13
        '
        'NroPago
        '
        Me.NroPago.DataPropertyName = "NroPago"
        Me.NroPago.HeaderText = "Nro. "
        Me.NroPago.Name = "NroPago"
        Me.NroPago.ReadOnly = True
        Me.NroPago.Width = 70
        '
        'Fecha
        '
        Me.Fecha.DataPropertyName = "Fecha"
        Me.Fecha.HeaderText = "Fecha"
        Me.Fecha.Name = "Fecha"
        Me.Fecha.ReadOnly = True
        Me.Fecha.Width = 70
        '
        'Destino
        '
        Me.Destino.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Destino.DataPropertyName = "Destino"
        Me.Destino.HeaderText = "Destino"
        Me.Destino.Name = "Destino"
        '
        'QuienHizo
        '
        Me.QuienHizo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.QuienHizo.DataPropertyName = "QuienHizo"
        Me.QuienHizo.HeaderText = "Hizo"
        Me.QuienHizo.Name = "QuienHizo"
        Me.QuienHizo.ReadOnly = True
        Me.QuienHizo.Width = 65
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ImprimirSeleccionadasToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(234, 28)
        '
        'ImprimirSeleccionadasToolStripMenuItem
        '
        Me.ImprimirSeleccionadasToolStripMenuItem.Name = "ImprimirSeleccionadasToolStripMenuItem"
        Me.ImprimirSeleccionadasToolStripMenuItem.Size = New System.Drawing.Size(233, 24)
        Me.ImprimirSeleccionadasToolStripMenuItem.Text = "Imprimir Seleccionadas"
        '
        'cbx_QuienHizo
        '
        Me.cbx_QuienHizo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbx_QuienHizo.FormattingEnabled = True
        Me.cbx_QuienHizo.Items.AddRange(New Object() {"Todos", "Alejandro", "Lucas", "Sergio", "Liliana"})
        Me.cbx_QuienHizo.Location = New System.Drawing.Point(322, 102)
        Me.cbx_QuienHizo.Name = "cbx_QuienHizo"
        Me.cbx_QuienHizo.Size = New System.Drawing.Size(181, 24)
        Me.cbx_QuienHizo.TabIndex = 14
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(319, 82)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(98, 17)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Quien las hizo"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.optTransferencias)
        Me.GroupBox2.Controls.Add(Me.optAnticipos)
        Me.GroupBox2.Controls.Add(Me.optChequeRechazado)
        Me.GroupBox2.Controls.Add(Me.optVarios)
        Me.GroupBox2.Controls.Add(Me.optCtaCte)
        Me.GroupBox2.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.GroupBox2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.GroupBox2.Location = New System.Drawing.Point(184, 181)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Size = New System.Drawing.Size(323, 122)
        Me.GroupBox2.TabIndex = 35
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Tipo de Orden de Pago"
        '
        'optTransferencias
        '
        Me.optTransferencias.AutoSize = True
        Me.optTransferencias.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold)
        Me.optTransferencias.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.optTransferencias.Location = New System.Drawing.Point(185, 58)
        Me.optTransferencias.Margin = New System.Windows.Forms.Padding(4)
        Me.optTransferencias.Name = "optTransferencias"
        Me.optTransferencias.Size = New System.Drawing.Size(118, 22)
        Me.optTransferencias.TabIndex = 4
        Me.optTransferencias.Text = "Transferencias"
        Me.optTransferencias.UseVisualStyleBackColor = True
        '
        'optAnticipos
        '
        Me.optAnticipos.AutoSize = True
        Me.optAnticipos.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold)
        Me.optAnticipos.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.optAnticipos.Location = New System.Drawing.Point(185, 30)
        Me.optAnticipos.Margin = New System.Windows.Forms.Padding(4)
        Me.optAnticipos.Name = "optAnticipos"
        Me.optAnticipos.Size = New System.Drawing.Size(87, 22)
        Me.optAnticipos.TabIndex = 3
        Me.optAnticipos.Text = "Anticipos"
        Me.optAnticipos.UseVisualStyleBackColor = True
        '
        'optChequeRechazado
        '
        Me.optChequeRechazado.AutoSize = True
        Me.optChequeRechazado.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold)
        Me.optChequeRechazado.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.optChequeRechazado.Location = New System.Drawing.Point(15, 86)
        Me.optChequeRechazado.Margin = New System.Windows.Forms.Padding(4)
        Me.optChequeRechazado.Name = "optChequeRechazado"
        Me.optChequeRechazado.Size = New System.Drawing.Size(124, 22)
        Me.optChequeRechazado.TabIndex = 2
        Me.optChequeRechazado.Text = "Ch. Rechazados"
        Me.optChequeRechazado.UseVisualStyleBackColor = True
        '
        'optVarios
        '
        Me.optVarios.AutoSize = True
        Me.optVarios.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold)
        Me.optVarios.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.optVarios.Location = New System.Drawing.Point(15, 58)
        Me.optVarios.Margin = New System.Windows.Forms.Padding(4)
        Me.optVarios.Name = "optVarios"
        Me.optVarios.Size = New System.Drawing.Size(106, 22)
        Me.optVarios.TabIndex = 1
        Me.optVarios.Text = "Pagos Varios"
        Me.optVarios.UseVisualStyleBackColor = True
        '
        'optCtaCte
        '
        Me.optCtaCte.AutoSize = True
        Me.optCtaCte.Checked = True
        Me.optCtaCte.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold)
        Me.optCtaCte.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.optCtaCte.Location = New System.Drawing.Point(15, 30)
        Me.optCtaCte.Margin = New System.Windows.Forms.Padding(4)
        Me.optCtaCte.Name = "optCtaCte"
        Me.optCtaCte.Size = New System.Drawing.Size(120, 22)
        Me.optCtaCte.TabIndex = 0
        Me.optCtaCte.TabStop = True
        Me.optCtaCte.Text = "Pagos Cta. Cte."
        Me.optCtaCte.UseVisualStyleBackColor = True
        '
        'btn_ImprimirTodo
        '
        Me.btn_ImprimirTodo.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_ImprimirTodo.Location = New System.Drawing.Point(627, 62)
        Me.btn_ImprimirTodo.Name = "btn_ImprimirTodo"
        Me.btn_ImprimirTodo.Size = New System.Drawing.Size(117, 78)
        Me.btn_ImprimirTodo.TabIndex = 36
        Me.btn_ImprimirTodo.Text = "IMPRIMIR"
        Me.btn_ImprimirTodo.UseVisualStyleBackColor = True
        '
        'Listados_Pagos_SinImprimir
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(747, 420)
        Me.Controls.Add(Me.btn_ImprimirTodo)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cbx_QuienHizo)
        Me.Controls.Add(Me.dgv_Pagos)
        Me.Controls.Add(Me.btn_Cerrar)
        Me.Controls.Add(Me.btn_Aceptar)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.panel1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Location = New System.Drawing.Point(20, 20)
        Me.Name = "Listados_Pagos_SinImprimir"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.panel1.ResumeLayout(False)
        Me.panel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgv_Pagos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents panel1 As System.Windows.Forms.Panel
    Private WithEvents Label2 As System.Windows.Forms.Label
    Private WithEvents label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txt_FechaHasta As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txt_FechaDesde As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btn_Cerrar As System.Windows.Forms.Button
    Friend WithEvents btn_Aceptar As System.Windows.Forms.Button
    Friend WithEvents dgv_Pagos As Util.DBDataGridView
    Friend WithEvents cbx_QuienHizo As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents NroPago As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Fecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Destino As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QuienHizo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ImprimirSeleccionadasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents optTransferencias As System.Windows.Forms.RadioButton
    Friend WithEvents optAnticipos As System.Windows.Forms.RadioButton
    Friend WithEvents optChequeRechazado As System.Windows.Forms.RadioButton
    Friend WithEvents optVarios As System.Windows.Forms.RadioButton
    Friend WithEvents optCtaCte As System.Windows.Forms.RadioButton
    Friend WithEvents btn_ImprimirTodo As System.Windows.Forms.Button
End Class
