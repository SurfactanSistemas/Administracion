<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CuentaCorrientePantalla
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.GRilla = New System.Windows.Forms.DataGridView()
        Me.Tipo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Letra = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Punto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Numero = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Importe = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Saldo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Fecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Vencimiento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.opcCompleto = New System.Windows.Forms.RadioButton()
        Me.opcPendiente = New System.Windows.Forms.RadioButton()
        Me.boxPantallaProveedores = New System.Windows.Forms.GroupBox()
        Me.lstAyuda = New WindowsApplication1.CustomListBox()
        Me.txtAyuda = New WindowsApplication1.CustomTextBox()
        Me.btnCancela = New WindowsApplication1.CustomButton()
        Me.btnConsulta = New WindowsApplication1.CustomButton()
        Me.txtSaldo = New WindowsApplication1.CustomTextBox()
        Me.CustomLabel2 = New WindowsApplication1.CustomLabel()
        Me.txtRazon = New WindowsApplication1.CustomTextBox()
        Me.CustomLabel1 = New WindowsApplication1.CustomLabel()
        Me.txtProveedor = New WindowsApplication1.CustomTextBox()
        Me.CustomLabel3 = New WindowsApplication1.CustomLabel()
        CType(Me.GRilla, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.boxPantallaProveedores.SuspendLayout()
        Me.SuspendLayout()
        '
        'GRilla
        '
        Me.GRilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GRilla.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Tipo, Me.Letra, Me.Punto, Me.Numero, Me.Importe, Me.Saldo, Me.Fecha, Me.Vencimiento})
        Me.GRilla.Location = New System.Drawing.Point(26, 72)
        Me.GRilla.Name = "GRilla"
        Me.GRilla.Size = New System.Drawing.Size(742, 383)
        Me.GRilla.StandardTab = True
        Me.GRilla.TabIndex = 1
        '
        'Tipo
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft
        Me.Tipo.DefaultCellStyle = DataGridViewCellStyle1
        Me.Tipo.HeaderText = "Tipo"
        Me.Tipo.Name = "Tipo"
        Me.Tipo.ReadOnly = True
        Me.Tipo.Width = 50
        '
        'Letra
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft
        Me.Letra.DefaultCellStyle = DataGridViewCellStyle2
        Me.Letra.HeaderText = "Letra"
        Me.Letra.Name = "Letra"
        Me.Letra.ReadOnly = True
        Me.Letra.Width = 50
        '
        'Punto
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        Me.Punto.DefaultCellStyle = DataGridViewCellStyle3
        Me.Punto.HeaderText = "Punto"
        Me.Punto.Name = "Punto"
        Me.Punto.ReadOnly = True
        Me.Punto.Width = 50
        '
        'Numero
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        Me.Numero.DefaultCellStyle = DataGridViewCellStyle4
        Me.Numero.HeaderText = "Numero"
        Me.Numero.Name = "Numero"
        Me.Numero.ReadOnly = True
        '
        'Importe
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        Me.Importe.DefaultCellStyle = DataGridViewCellStyle5
        Me.Importe.HeaderText = "Importe"
        Me.Importe.Name = "Importe"
        Me.Importe.ReadOnly = True
        '
        'Saldo
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        Me.Saldo.DefaultCellStyle = DataGridViewCellStyle6
        Me.Saldo.HeaderText = "Saldo"
        Me.Saldo.Name = "Saldo"
        Me.Saldo.ReadOnly = True
        '
        'Fecha
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        Me.Fecha.DefaultCellStyle = DataGridViewCellStyle7
        Me.Fecha.HeaderText = "Fecha"
        Me.Fecha.Name = "Fecha"
        Me.Fecha.ReadOnly = True
        '
        'Vencimiento
        '
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        Me.Vencimiento.DefaultCellStyle = DataGridViewCellStyle8
        Me.Vencimiento.HeaderText = "Vencimiento"
        Me.Vencimiento.Name = "Vencimiento"
        Me.Vencimiento.ReadOnly = True
        '
        'opcCompleto
        '
        Me.opcCompleto.AutoSize = True
        Me.opcCompleto.Location = New System.Drawing.Point(353, 39)
        Me.opcCompleto.Name = "opcCompleto"
        Me.opcCompleto.Size = New System.Drawing.Size(69, 17)
        Me.opcCompleto.TabIndex = 24
        Me.opcCompleto.TabStop = True
        Me.opcCompleto.Text = "Completo"
        Me.opcCompleto.UseVisualStyleBackColor = True
        '
        'opcPendiente
        '
        Me.opcPendiente.AutoSize = True
        Me.opcPendiente.Location = New System.Drawing.Point(219, 39)
        Me.opcPendiente.Name = "opcPendiente"
        Me.opcPendiente.Size = New System.Drawing.Size(73, 17)
        Me.opcPendiente.TabIndex = 23
        Me.opcPendiente.TabStop = True
        Me.opcPendiente.Text = "Pendiente"
        Me.opcPendiente.UseVisualStyleBackColor = True
        '
        'boxPantallaProveedores
        '
        Me.boxPantallaProveedores.Controls.Add(Me.lstAyuda)
        Me.boxPantallaProveedores.Controls.Add(Me.txtAyuda)
        Me.boxPantallaProveedores.Location = New System.Drawing.Point(133, 83)
        Me.boxPantallaProveedores.Name = "boxPantallaProveedores"
        Me.boxPantallaProveedores.Size = New System.Drawing.Size(541, 349)
        Me.boxPantallaProveedores.TabIndex = 27
        Me.boxPantallaProveedores.TabStop = False
        Me.boxPantallaProveedores.Visible = False
        '
        'lstAyuda
        '
        Me.lstAyuda.Cleanable = False
        Me.lstAyuda.EnterIndex = -1
        Me.lstAyuda.FormattingEnabled = True
        Me.lstAyuda.LabelAssociationKey = -1
        Me.lstAyuda.Location = New System.Drawing.Point(61, 39)
        Me.lstAyuda.Name = "lstAyuda"
        Me.lstAyuda.Size = New System.Drawing.Size(417, 303)
        Me.lstAyuda.TabIndex = 29
        '
        'txtAyuda
        '
        Me.txtAyuda.Cleanable = False
        Me.txtAyuda.Empty = True
        Me.txtAyuda.EnterIndex = -1
        Me.txtAyuda.LabelAssociationKey = -1
        Me.txtAyuda.Location = New System.Drawing.Point(61, 13)
        Me.txtAyuda.Name = "txtAyuda"
        Me.txtAyuda.Size = New System.Drawing.Size(417, 20)
        Me.txtAyuda.TabIndex = 28
        Me.txtAyuda.Validator = WindowsApplication1.ValidatorType.None
        '
        'btnCancela
        '
        Me.btnCancela.Cleanable = False
        Me.btnCancela.EnterIndex = -1
        Me.btnCancela.LabelAssociationKey = -1
        Me.btnCancela.Location = New System.Drawing.Point(657, 12)
        Me.btnCancela.Name = "btnCancela"
        Me.btnCancela.Size = New System.Drawing.Size(99, 40)
        Me.btnCancela.TabIndex = 28
        Me.btnCancela.Text = "Cancela"
        Me.btnCancela.UseVisualStyleBackColor = True
        '
        'btnConsulta
        '
        Me.btnConsulta.Cleanable = False
        Me.btnConsulta.EnterIndex = -1
        Me.btnConsulta.LabelAssociationKey = -1
        Me.btnConsulta.Location = New System.Drawing.Point(542, 12)
        Me.btnConsulta.Name = "btnConsulta"
        Me.btnConsulta.Size = New System.Drawing.Size(95, 40)
        Me.btnConsulta.TabIndex = 26
        Me.btnConsulta.Text = "Consulta"
        Me.btnConsulta.UseVisualStyleBackColor = True
        '
        'txtSaldo
        '
        Me.txtSaldo.Cleanable = False
        Me.txtSaldo.Empty = True
        Me.txtSaldo.EnterIndex = -1
        Me.txtSaldo.LabelAssociationKey = -1
        Me.txtSaldo.Location = New System.Drawing.Point(93, 36)
        Me.txtSaldo.Name = "txtSaldo"
        Me.txtSaldo.ReadOnly = True
        Me.txtSaldo.Size = New System.Drawing.Size(108, 20)
        Me.txtSaldo.TabIndex = 7
        Me.txtSaldo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtSaldo.Validator = WindowsApplication1.ValidatorType.None
        '
        'CustomLabel2
        '
        Me.CustomLabel2.AutoSize = True
        Me.CustomLabel2.ControlAssociationKey = -1
        Me.CustomLabel2.Location = New System.Drawing.Point(20, 39)
        Me.CustomLabel2.Name = "CustomLabel2"
        Me.CustomLabel2.Size = New System.Drawing.Size(34, 13)
        Me.CustomLabel2.TabIndex = 8
        Me.CustomLabel2.Text = "Saldo"
        '
        'txtRazon
        '
        Me.txtRazon.BackColor = System.Drawing.Color.Silver
        Me.txtRazon.Cleanable = False
        Me.txtRazon.Empty = True
        Me.txtRazon.EnterIndex = -1
        Me.txtRazon.LabelAssociationKey = -1
        Me.txtRazon.Location = New System.Drawing.Point(207, 12)
        Me.txtRazon.Name = "txtRazon"
        Me.txtRazon.Size = New System.Drawing.Size(320, 20)
        Me.txtRazon.TabIndex = 6
        Me.txtRazon.Validator = WindowsApplication1.ValidatorType.None
        '
        'CustomLabel1
        '
        Me.CustomLabel1.AutoSize = True
        Me.CustomLabel1.ControlAssociationKey = -1
        Me.CustomLabel1.Location = New System.Drawing.Point(330, 39)
        Me.CustomLabel1.Name = "CustomLabel1"
        Me.CustomLabel1.Size = New System.Drawing.Size(0, 13)
        Me.CustomLabel1.TabIndex = 5
        '
        'txtProveedor
        '
        Me.txtProveedor.Cleanable = False
        Me.txtProveedor.Empty = True
        Me.txtProveedor.EnterIndex = -1
        Me.txtProveedor.LabelAssociationKey = -1
        Me.txtProveedor.Location = New System.Drawing.Point(93, 12)
        Me.txtProveedor.Name = "txtProveedor"
        Me.txtProveedor.Size = New System.Drawing.Size(108, 20)
        Me.txtProveedor.TabIndex = 0
        Me.txtProveedor.Validator = WindowsApplication1.ValidatorType.None
        '
        'CustomLabel3
        '
        Me.CustomLabel3.AutoSize = True
        Me.CustomLabel3.ControlAssociationKey = -1
        Me.CustomLabel3.Location = New System.Drawing.Point(20, 15)
        Me.CustomLabel3.Name = "CustomLabel3"
        Me.CustomLabel3.Size = New System.Drawing.Size(56, 13)
        Me.CustomLabel3.TabIndex = 3
        Me.CustomLabel3.Text = "Proveedor"
        '
        'CuentaCorrientePantalla
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(777, 477)
        Me.Controls.Add(Me.btnCancela)
        Me.Controls.Add(Me.boxPantallaProveedores)
        Me.Controls.Add(Me.btnConsulta)
        Me.Controls.Add(Me.opcCompleto)
        Me.Controls.Add(Me.opcPendiente)
        Me.Controls.Add(Me.txtSaldo)
        Me.Controls.Add(Me.CustomLabel2)
        Me.Controls.Add(Me.txtRazon)
        Me.Controls.Add(Me.CustomLabel1)
        Me.Controls.Add(Me.txtProveedor)
        Me.Controls.Add(Me.CustomLabel3)
        Me.Controls.Add(Me.GRilla)
        Me.Name = "CuentaCorrientePantalla"
        Me.Text = "Cuenta Corrientes de Proveedores"
        CType(Me.GRilla, System.ComponentModel.ISupportInitialize).EndInit()
        Me.boxPantallaProveedores.ResumeLayout(False)
        Me.boxPantallaProveedores.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GRilla As System.Windows.Forms.DataGridView
    Friend WithEvents CustomLabel3 As WindowsApplication1.CustomLabel
    Friend WithEvents txtProveedor As WindowsApplication1.CustomTextBox
    Friend WithEvents CustomLabel1 As WindowsApplication1.CustomLabel
    Friend WithEvents txtRazon As WindowsApplication1.CustomTextBox
    Friend WithEvents txtSaldo As WindowsApplication1.CustomTextBox
    Friend WithEvents CustomLabel2 As WindowsApplication1.CustomLabel
    Friend WithEvents opcCompleto As System.Windows.Forms.RadioButton
    Friend WithEvents opcPendiente As System.Windows.Forms.RadioButton
    Friend WithEvents btnConsulta As WindowsApplication1.CustomButton
    Friend WithEvents boxPantallaProveedores As System.Windows.Forms.GroupBox
    Friend WithEvents lstAyuda As WindowsApplication1.CustomListBox
    Friend WithEvents txtAyuda As WindowsApplication1.CustomTextBox
    Friend WithEvents btnCancela As WindowsApplication1.CustomButton
    Friend WithEvents Tipo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Letra As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Punto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Numero As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Importe As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Saldo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Fecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Vencimiento As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
