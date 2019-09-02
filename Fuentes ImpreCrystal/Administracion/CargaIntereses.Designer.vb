<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CargaIntereses
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
        Me.gridCtaCte = New System.Windows.Forms.DataGridView()
        Me.fechaOriginal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.desProveOriginal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.facturaOriginal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cuota = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.fecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.saldo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.intereses = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ivaIntereses = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.referencia = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clave = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nroInterno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnCancela = New WindowsApplication1.CustomButton()
        Me.btnGraba = New WindowsApplication1.CustomButton()
        CType(Me.gridCtaCte, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gridCtaCte
        '
        Me.gridCtaCte.AllowUserToAddRows = False
        Me.gridCtaCte.AllowUserToDeleteRows = False
        Me.gridCtaCte.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader
        Me.gridCtaCte.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridCtaCte.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.fechaOriginal, Me.desProveOriginal, Me.facturaOriginal, Me.cuota, Me.fecha, Me.saldo, Me.intereses, Me.ivaIntereses, Me.referencia, Me.clave, Me.nroInterno})
        Me.gridCtaCte.Location = New System.Drawing.Point(12, 12)
        Me.gridCtaCte.Name = "gridCtaCte"
        Me.gridCtaCte.Size = New System.Drawing.Size(760, 468)
        Me.gridCtaCte.StandardTab = True
        Me.gridCtaCte.TabIndex = 1
        '
        'fechaOriginal
        '
        Me.fechaOriginal.HeaderText = "Fecha Original"
        Me.fechaOriginal.Name = "fechaOriginal"
        Me.fechaOriginal.ReadOnly = True
        '
        'desProveOriginal
        '
        Me.desProveOriginal.HeaderText = "DesProveOriginal"
        Me.desProveOriginal.Name = "desProveOriginal"
        Me.desProveOriginal.ReadOnly = True
        Me.desProveOriginal.Width = 114
        '
        'facturaOriginal
        '
        Me.facturaOriginal.HeaderText = "FacturaOriginal"
        Me.facturaOriginal.Name = "facturaOriginal"
        Me.facturaOriginal.ReadOnly = True
        Me.facturaOriginal.Width = 103
        '
        'cuota
        '
        Me.cuota.HeaderText = "Cuota"
        Me.cuota.Name = "cuota"
        Me.cuota.ReadOnly = True
        Me.cuota.Width = 60
        '
        'fecha
        '
        Me.fecha.HeaderText = "Vencimiento"
        Me.fecha.Name = "fecha"
        Me.fecha.ReadOnly = True
        Me.fecha.Width = 90
        '
        'saldo
        '
        Me.saldo.HeaderText = "Saldo"
        Me.saldo.Name = "saldo"
        Me.saldo.ReadOnly = True
        Me.saldo.Width = 59
        '
        'intereses
        '
        Me.intereses.HeaderText = "Intereses"
        Me.intereses.Name = "intereses"
        Me.intereses.Width = 75
        '
        'ivaIntereses
        '
        Me.ivaIntereses.HeaderText = "Iva Intereses"
        Me.ivaIntereses.Name = "ivaIntereses"
        Me.ivaIntereses.Width = 93
        '
        'referencia
        '
        Me.referencia.HeaderText = "Referencia"
        Me.referencia.Name = "referencia"
        Me.referencia.Width = 84
        '
        'clave
        '
        Me.clave.HeaderText = "Clave"
        Me.clave.Name = "clave"
        Me.clave.Visible = False
        Me.clave.Width = 59
        '
        'nroInterno
        '
        Me.nroInterno.HeaderText = "N° Interno"
        Me.nroInterno.Name = "nroInterno"
        Me.nroInterno.Visible = False
        Me.nroInterno.Width = 80
        '
        'btnCancela
        '
        Me.btnCancela.Cleanable = False
        Me.btnCancela.EnterIndex = -1
        Me.btnCancela.LabelAssociationKey = -1
        Me.btnCancela.Location = New System.Drawing.Point(385, 496)
        Me.btnCancela.Name = "btnCancela"
        Me.btnCancela.Size = New System.Drawing.Size(122, 42)
        Me.btnCancela.TabIndex = 3
        Me.btnCancela.Text = "Cancela"
        Me.btnCancela.UseVisualStyleBackColor = True
        '
        'btnGraba
        '
        Me.btnGraba.Cleanable = False
        Me.btnGraba.EnterIndex = -1
        Me.btnGraba.LabelAssociationKey = -1
        Me.btnGraba.Location = New System.Drawing.Point(248, 496)
        Me.btnGraba.Name = "btnGraba"
        Me.btnGraba.Size = New System.Drawing.Size(122, 42)
        Me.btnGraba.TabIndex = 2
        Me.btnGraba.Text = "Graba"
        Me.btnGraba.UseVisualStyleBackColor = True
        '
        'CargaIntereses
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 562)
        Me.Controls.Add(Me.btnCancela)
        Me.Controls.Add(Me.btnGraba)
        Me.Controls.Add(Me.gridCtaCte)
        Me.Name = "CargaIntereses"
        Me.Text = "Actualizacion de Deuda de Pyme Nacion"
        CType(Me.gridCtaCte, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gridCtaCte As System.Windows.Forms.DataGridView
    Friend WithEvents btnGraba As WindowsApplication1.CustomButton
    Friend WithEvents btnCancela As WindowsApplication1.CustomButton
    Friend WithEvents fechaOriginal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents desProveOriginal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents facturaOriginal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cuota As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents fecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents saldo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents intereses As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ivaIntereses As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents referencia As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clave As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents nroInterno As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
