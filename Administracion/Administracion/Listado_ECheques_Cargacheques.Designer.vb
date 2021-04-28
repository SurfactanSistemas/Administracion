<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Listado_ECheques_Cargacheques
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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.dvg_ECheques = New Util.DBDataGridView()
        Me.Clave = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NroCheque = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BancoEmisor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Importe = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FechaPago = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CuitEmisor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Emisor_Razon = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dvg_ECheques, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dvg_ECheques
        '
        Me.dvg_ECheques.AllowUserToAddRows = False
        Me.dvg_ECheques.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dvg_ECheques.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Clave, Me.NroCheque, Me.BancoEmisor, Me.Importe, Me.FechaPago, Me.CuitEmisor, Me.Emisor_Razon})
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(232, Byte), Integer))
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dvg_ECheques.DefaultCellStyle = DataGridViewCellStyle4
        Me.dvg_ECheques.DoubleBuffered = True
        Me.dvg_ECheques.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dvg_ECheques.Location = New System.Drawing.Point(7, 2)
        Me.dvg_ECheques.Name = "dvg_ECheques"
        Me.dvg_ECheques.OrdenamientoColumnasHabilitado = True
        Me.dvg_ECheques.RowHeadersWidth = 15
        Me.dvg_ECheques.RowTemplate.Height = 20
        Me.dvg_ECheques.ShowCellToolTips = False
        Me.dvg_ECheques.SinClickDerecho = False
        Me.dvg_ECheques.Size = New System.Drawing.Size(899, 230)
        Me.dvg_ECheques.TabIndex = 7
        '
        'Clave
        '
        Me.Clave.HeaderText = "Clave"
        Me.Clave.Name = "Clave"
        Me.Clave.ReadOnly = True
        Me.Clave.Visible = False
        '
        'NroCheque
        '
        Me.NroCheque.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.NroCheque.DefaultCellStyle = DataGridViewCellStyle1
        Me.NroCheque.HeaderText = "Nro. Cheque"
        Me.NroCheque.Name = "NroCheque"
        Me.NroCheque.ReadOnly = True
        Me.NroCheque.Width = 117
        '
        'BancoEmisor
        '
        Me.BancoEmisor.HeaderText = "Banco Emisor"
        Me.BancoEmisor.Name = "BancoEmisor"
        Me.BancoEmisor.ReadOnly = True
        Me.BancoEmisor.Width = 124
        '
        'Importe
        '
        Me.Importe.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.Format = "N2"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.Importe.DefaultCellStyle = DataGridViewCellStyle2
        Me.Importe.HeaderText = "Importe"
        Me.Importe.Name = "Importe"
        Me.Importe.ReadOnly = True
        Me.Importe.Width = 84
        '
        'FechaPago
        '
        Me.FechaPago.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.FechaPago.HeaderText = "Fecha Pago"
        Me.FechaPago.Name = "FechaPago"
        Me.FechaPago.ReadOnly = True
        Me.FechaPago.Width = 113
        '
        'CuitEmisor
        '
        Me.CuitEmisor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.CuitEmisor.DefaultCellStyle = DataGridViewCellStyle3
        Me.CuitEmisor.HeaderText = "Cuit Emisor"
        Me.CuitEmisor.Name = "CuitEmisor"
        Me.CuitEmisor.ReadOnly = True
        Me.CuitEmisor.Width = 108
        '
        'Emisor_Razon
        '
        Me.Emisor_Razon.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Emisor_Razon.HeaderText = "Emisor Razon"
        Me.Emisor_Razon.Name = "Emisor_Razon"
        Me.Emisor_Razon.ReadOnly = True
        Me.Emisor_Razon.Width = 125
        '
        'Listado_ECheques_Cargacheques
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(910, 236)
        Me.Controls.Add(Me.dvg_ECheques)
        Me.Location = New System.Drawing.Point(100, 10)
        Me.Name = "Listado_ECheques_Cargacheques"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Listado E-Cheques"
        CType(Me.dvg_ECheques, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dvg_ECheques As Util.DBDataGridView
    Friend WithEvents Clave As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NroCheque As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BancoEmisor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Importe As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FechaPago As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CuitEmisor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Emisor_Razon As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
