<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Apertura
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
        Me.gridApertura = New System.Windows.Forms.DataGridView()
        Me.CUIT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RazonSocial = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Tipo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Letra = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Punto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Numero = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Fecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Neto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Iva21 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IVA27 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IVA105 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PercIVA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PercIB = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Exento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnAceptar = New Administracion.CustomButton()
        CType(Me.gridApertura, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gridApertura
        '
        Me.gridApertura.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridApertura.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CUIT, Me.RazonSocial, Me.Tipo, Me.Letra, Me.Punto, Me.Numero, Me.Fecha, Me.Neto, Me.Iva21, Me.IVA27, Me.IVA105, Me.PercIVA, Me.PercIB, Me.Exento})
        Me.gridApertura.Dock = System.Windows.Forms.DockStyle.Top
        Me.gridApertura.Location = New System.Drawing.Point(0, 0)
        Me.gridApertura.Name = "gridApertura"
        Me.gridApertura.RowHeadersWidth = 20
        Me.gridApertura.Size = New System.Drawing.Size(1194, 362)
        Me.gridApertura.TabIndex = 0
        '
        'CUIT
        '
        DataGridViewCellStyle1.Format = "N0"
        DataGridViewCellStyle1.NullValue = Nothing
        Me.CUIT.DefaultCellStyle = DataGridViewCellStyle1
        Me.CUIT.HeaderText = "CUIT"
        Me.CUIT.Name = "CUIT"
        '
        'RazonSocial
        '
        Me.RazonSocial.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.RazonSocial.HeaderText = "Razón Social"
        Me.RazonSocial.Name = "RazonSocial"
        '
        'Tipo
        '
        Me.Tipo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Tipo.HeaderText = "Tipo"
        Me.Tipo.Name = "Tipo"
        Me.Tipo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Tipo.Width = 53
        '
        'Letra
        '
        Me.Letra.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Letra.HeaderText = "Letra"
        Me.Letra.Name = "Letra"
        Me.Letra.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Letra.Width = 56
        '
        'Punto
        '
        Me.Punto.HeaderText = "Punto"
        Me.Punto.Name = "Punto"
        Me.Punto.Width = 60
        '
        'Numero
        '
        Me.Numero.HeaderText = "Número"
        Me.Numero.Name = "Numero"
        Me.Numero.Width = 70
        '
        'Fecha
        '
        Me.Fecha.HeaderText = "Fecha"
        Me.Fecha.Name = "Fecha"
        Me.Fecha.Width = 70
        '
        'Neto
        '
        Me.Neto.HeaderText = "Neto"
        Me.Neto.Name = "Neto"
        Me.Neto.Width = 70
        '
        'Iva21
        '
        Me.Iva21.HeaderText = "IVA 21"
        Me.Iva21.Name = "Iva21"
        Me.Iva21.Width = 70
        '
        'IVA27
        '
        Me.IVA27.HeaderText = "IVA 27"
        Me.IVA27.Name = "IVA27"
        Me.IVA27.Width = 70
        '
        'IVA105
        '
        Me.IVA105.HeaderText = "IVA 10.5"
        Me.IVA105.Name = "IVA105"
        Me.IVA105.Width = 70
        '
        'PercIVA
        '
        Me.PercIVA.HeaderText = "Perc. IVA"
        Me.PercIVA.Name = "PercIVA"
        Me.PercIVA.Width = 70
        '
        'PercIB
        '
        Me.PercIB.HeaderText = "Perc. IB"
        Me.PercIB.Name = "PercIB"
        Me.PercIB.Width = 70
        '
        'Exento
        '
        Me.Exento.HeaderText = "Exento"
        Me.Exento.Name = "Exento"
        Me.Exento.Width = 70
        '
        'btnAceptar
        '
        Me.btnAceptar.BackgroundImage = Global.Administracion.My.Resources.Resources.Aceptar_N2
        Me.btnAceptar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnAceptar.Cleanable = False
        Me.btnAceptar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAceptar.EnterIndex = -1
        Me.btnAceptar.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnAceptar.FlatAppearance.BorderSize = 0
        Me.btnAceptar.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control
        Me.btnAceptar.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control
        Me.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAceptar.LabelAssociationKey = -1
        Me.btnAceptar.Location = New System.Drawing.Point(544, 370)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(136, 47)
        Me.btnAceptar.TabIndex = 1
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'Apertura
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1194, 426)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.gridApertura)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "Apertura"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "AperturaCompras"
        CType(Me.gridApertura, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gridApertura As System.Windows.Forms.DataGridView
    Friend WithEvents btnAceptar As Administracion.CustomButton
    Friend WithEvents CUIT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RazonSocial As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Tipo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Letra As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Punto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Numero As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Fecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Neto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Iva21 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IVA27 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IVA105 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PercIVA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PercIB As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Exento As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
