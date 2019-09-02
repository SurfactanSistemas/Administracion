<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Depositos
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
        Me.gridCheques = New System.Windows.Forms.DataGridView()
        Me.tipo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.numero = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.fecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.importe = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtImporte = New WindowsApplication1.CustomTextBox()
        Me.CustomLabel7 = New WindowsApplication1.CustomLabel()
        Me.lstSeleccion = New WindowsApplication1.CustomListBox()
        Me.btnCerrar = New WindowsApplication1.CustomButton()
        Me.btnConsulta = New WindowsApplication1.CustomButton()
        Me.btnLimpiar = New WindowsApplication1.CustomButton()
        Me.btnImpresion = New WindowsApplication1.CustomButton()
        Me.btnAgregar = New WindowsApplication1.CustomButton()
        Me.lstConsulta = New WindowsApplication1.CustomListBox()
        Me.txtFecha = New WindowsApplication1.CustomTextBox()
        Me.CustomLabel6 = New WindowsApplication1.CustomLabel()
        Me.txtDescripcionBanco = New WindowsApplication1.CustomTextBox()
        Me.txtNroDeposito = New WindowsApplication1.CustomTextBox()
        Me.txtCodigoBanco = New WindowsApplication1.CustomTextBox()
        Me.txtFechaAcreditacion = New WindowsApplication1.CustomTextBox()
        Me.CustomLabel5 = New WindowsApplication1.CustomLabel()
        Me.CustomLabel4 = New WindowsApplication1.CustomLabel()
        Me.CustomLabel3 = New WindowsApplication1.CustomLabel()
        Me.lblTotal = New WindowsApplication1.CustomLabel()
        Me.CustomLabel1 = New WindowsApplication1.CustomLabel()
        CType(Me.gridCheques, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gridCheques
        '
        Me.gridCheques.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridCheques.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.tipo, Me.numero, Me.fecha, Me.nombre, Me.importe})
        Me.gridCheques.Location = New System.Drawing.Point(12, 178)
        Me.gridCheques.Name = "gridCheques"
        Me.gridCheques.Size = New System.Drawing.Size(444, 350)
        Me.gridCheques.StandardTab = True
        Me.gridCheques.TabIndex = 0
        '
        'tipo
        '
        Me.tipo.HeaderText = "Tipo"
        Me.tipo.Name = "tipo"
        Me.tipo.Width = 50
        '
        'numero
        '
        Me.numero.HeaderText = "Numero"
        Me.numero.Name = "numero"
        Me.numero.ReadOnly = True
        '
        'fecha
        '
        Me.fecha.HeaderText = "Fecha"
        Me.fecha.Name = "fecha"
        Me.fecha.ReadOnly = True
        Me.fecha.Width = 60
        '
        'nombre
        '
        Me.nombre.HeaderText = "Nombre"
        Me.nombre.Name = "nombre"
        Me.nombre.ReadOnly = True
        '
        'importe
        '
        Me.importe.HeaderText = "Importe"
        Me.importe.Name = "importe"
        Me.importe.Width = 70
        '
        'txtImporte
        '
        Me.txtImporte.Cleanable = True
        Me.txtImporte.Empty = False
        Me.txtImporte.EnterIndex = 5
        Me.txtImporte.LabelAssociationKey = 5
        Me.txtImporte.Location = New System.Drawing.Point(254, 90)
        Me.txtImporte.MaxLength = 10
        Me.txtImporte.Name = "txtImporte"
        Me.txtImporte.Size = New System.Drawing.Size(80, 20)
        Me.txtImporte.TabIndex = 16
        Me.txtImporte.Validator = WindowsApplication1.ValidatorType.PositiveFloat
        '
        'CustomLabel7
        '
        Me.CustomLabel7.AutoSize = True
        Me.CustomLabel7.ControlAssociationKey = 5
        Me.CustomLabel7.Location = New System.Drawing.Point(206, 93)
        Me.CustomLabel7.Name = "CustomLabel7"
        Me.CustomLabel7.Size = New System.Drawing.Size(42, 13)
        Me.CustomLabel7.TabIndex = 15
        Me.CustomLabel7.Text = "Importe"
        '
        'lstSeleccion
        '
        Me.lstSeleccion.Cleanable = False
        Me.lstSeleccion.EnterIndex = -1
        Me.lstSeleccion.FormattingEnabled = True
        Me.lstSeleccion.Items.AddRange(New Object() {"Bancos", "Cheques de Terceros"})
        Me.lstSeleccion.LabelAssociationKey = -1
        Me.lstSeleccion.Location = New System.Drawing.Point(477, 12)
        Me.lstSeleccion.Name = "lstSeleccion"
        Me.lstSeleccion.Size = New System.Drawing.Size(301, 212)
        Me.lstSeleccion.TabIndex = 14
        Me.lstSeleccion.Visible = False
        '
        'btnCerrar
        '
        Me.btnCerrar.Cleanable = False
        Me.btnCerrar.EnterIndex = -1
        Me.btnCerrar.LabelAssociationKey = -1
        Me.btnCerrar.Location = New System.Drawing.Point(290, 147)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(100, 25)
        Me.btnCerrar.TabIndex = 13
        Me.btnCerrar.Text = "Cerrar"
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'btnConsulta
        '
        Me.btnConsulta.Cleanable = False
        Me.btnConsulta.EnterIndex = -1
        Me.btnConsulta.LabelAssociationKey = -1
        Me.btnConsulta.Location = New System.Drawing.Point(78, 147)
        Me.btnConsulta.Name = "btnConsulta"
        Me.btnConsulta.Size = New System.Drawing.Size(100, 25)
        Me.btnConsulta.TabIndex = 12
        Me.btnConsulta.Text = "Consulta"
        Me.btnConsulta.UseVisualStyleBackColor = True
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Cleanable = False
        Me.btnLimpiar.EnterIndex = -1
        Me.btnLimpiar.LabelAssociationKey = -1
        Me.btnLimpiar.Location = New System.Drawing.Point(290, 116)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(100, 25)
        Me.btnLimpiar.TabIndex = 11
        Me.btnLimpiar.Text = "Limpiar"
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'btnImpresion
        '
        Me.btnImpresion.Cleanable = False
        Me.btnImpresion.EnterIndex = -1
        Me.btnImpresion.LabelAssociationKey = -1
        Me.btnImpresion.Location = New System.Drawing.Point(184, 147)
        Me.btnImpresion.Name = "btnImpresion"
        Me.btnImpresion.Size = New System.Drawing.Size(100, 25)
        Me.btnImpresion.TabIndex = 10
        Me.btnImpresion.Text = "Impresión"
        Me.btnImpresion.UseVisualStyleBackColor = True
        '
        'btnAgregar
        '
        Me.btnAgregar.Cleanable = False
        Me.btnAgregar.EnterIndex = -1
        Me.btnAgregar.LabelAssociationKey = -1
        Me.btnAgregar.Location = New System.Drawing.Point(78, 116)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(100, 25)
        Me.btnAgregar.TabIndex = 9
        Me.btnAgregar.Text = "Agregar"
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'lstConsulta
        '
        Me.lstConsulta.Cleanable = True
        Me.lstConsulta.EnterIndex = -1
        Me.lstConsulta.FormattingEnabled = True
        Me.lstConsulta.LabelAssociationKey = -1
        Me.lstConsulta.Location = New System.Drawing.Point(477, 12)
        Me.lstConsulta.Name = "lstConsulta"
        Me.lstConsulta.Size = New System.Drawing.Size(301, 524)
        Me.lstConsulta.TabIndex = 8
        Me.lstConsulta.Visible = False
        '
        'txtFecha
        '
        Me.txtFecha.Cleanable = True
        Me.txtFecha.Empty = False
        Me.txtFecha.EnterIndex = 2
        Me.txtFecha.LabelAssociationKey = 2
        Me.txtFecha.Location = New System.Drawing.Point(245, 27)
        Me.txtFecha.MaxLength = 10
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.Size = New System.Drawing.Size(75, 20)
        Me.txtFecha.TabIndex = 2
        Me.txtFecha.Validator = WindowsApplication1.ValidatorType.DateFormat
        '
        'CustomLabel6
        '
        Me.CustomLabel6.AutoSize = True
        Me.CustomLabel6.ControlAssociationKey = 2
        Me.CustomLabel6.Location = New System.Drawing.Point(202, 30)
        Me.CustomLabel6.Name = "CustomLabel6"
        Me.CustomLabel6.Size = New System.Drawing.Size(37, 13)
        Me.CustomLabel6.TabIndex = 7
        Me.CustomLabel6.Text = "Fecha"
        '
        'txtDescripcionBanco
        '
        Me.txtDescripcionBanco.Cleanable = True
        Me.txtDescripcionBanco.Empty = False
        Me.txtDescripcionBanco.Enabled = False
        Me.txtDescripcionBanco.EnterIndex = -1
        Me.txtDescripcionBanco.LabelAssociationKey = 3
        Me.txtDescripcionBanco.Location = New System.Drawing.Point(202, 60)
        Me.txtDescripcionBanco.MaxLength = 50
        Me.txtDescripcionBanco.Name = "txtDescripcionBanco"
        Me.txtDescripcionBanco.Size = New System.Drawing.Size(254, 20)
        Me.txtDescripcionBanco.TabIndex = 6
        Me.txtDescripcionBanco.TabStop = False
        Me.txtDescripcionBanco.Validator = WindowsApplication1.ValidatorType.None
        '
        'txtNroDeposito
        '
        Me.txtNroDeposito.Cleanable = True
        Me.txtNroDeposito.Empty = False
        Me.txtNroDeposito.EnterIndex = 1
        Me.txtNroDeposito.LabelAssociationKey = 1
        Me.txtNroDeposito.Location = New System.Drawing.Point(125, 27)
        Me.txtNroDeposito.MaxLength = 6
        Me.txtNroDeposito.Name = "txtNroDeposito"
        Me.txtNroDeposito.Size = New System.Drawing.Size(71, 20)
        Me.txtNroDeposito.TabIndex = 1
        Me.txtNroDeposito.Validator = WindowsApplication1.ValidatorType.Positive
        '
        'txtCodigoBanco
        '
        Me.txtCodigoBanco.Cleanable = True
        Me.txtCodigoBanco.Empty = False
        Me.txtCodigoBanco.EnterIndex = 3
        Me.txtCodigoBanco.LabelAssociationKey = 3
        Me.txtCodigoBanco.Location = New System.Drawing.Point(125, 60)
        Me.txtCodigoBanco.MaxLength = 5
        Me.txtCodigoBanco.Name = "txtCodigoBanco"
        Me.txtCodigoBanco.Size = New System.Drawing.Size(71, 20)
        Me.txtCodigoBanco.TabIndex = 3
        Me.txtCodigoBanco.Validator = WindowsApplication1.ValidatorType.None
        '
        'txtFechaAcreditacion
        '
        Me.txtFechaAcreditacion.Cleanable = True
        Me.txtFechaAcreditacion.Empty = False
        Me.txtFechaAcreditacion.EnterIndex = 4
        Me.txtFechaAcreditacion.LabelAssociationKey = 4
        Me.txtFechaAcreditacion.Location = New System.Drawing.Point(125, 90)
        Me.txtFechaAcreditacion.MaxLength = 10
        Me.txtFechaAcreditacion.Name = "txtFechaAcreditacion"
        Me.txtFechaAcreditacion.Size = New System.Drawing.Size(75, 20)
        Me.txtFechaAcreditacion.TabIndex = 4
        Me.txtFechaAcreditacion.Validator = WindowsApplication1.ValidatorType.DateFormat
        '
        'CustomLabel5
        '
        Me.CustomLabel5.AutoSize = True
        Me.CustomLabel5.ControlAssociationKey = 4
        Me.CustomLabel5.Location = New System.Drawing.Point(20, 93)
        Me.CustomLabel5.Name = "CustomLabel5"
        Me.CustomLabel5.Size = New System.Drawing.Size(99, 13)
        Me.CustomLabel5.TabIndex = 5
        Me.CustomLabel5.Text = "Fecha Acreditación"
        '
        'CustomLabel4
        '
        Me.CustomLabel4.AutoSize = True
        Me.CustomLabel4.ControlAssociationKey = 3
        Me.CustomLabel4.Location = New System.Drawing.Point(20, 63)
        Me.CustomLabel4.Name = "CustomLabel4"
        Me.CustomLabel4.Size = New System.Drawing.Size(38, 13)
        Me.CustomLabel4.TabIndex = 4
        Me.CustomLabel4.Text = "Banco"
        '
        'CustomLabel3
        '
        Me.CustomLabel3.AutoSize = True
        Me.CustomLabel3.ControlAssociationKey = 1
        Me.CustomLabel3.Location = New System.Drawing.Point(20, 30)
        Me.CustomLabel3.Name = "CustomLabel3"
        Me.CustomLabel3.Size = New System.Drawing.Size(72, 13)
        Me.CustomLabel3.TabIndex = 3
        Me.CustomLabel3.Text = "Nro. Depósito"
        '
        'lblTotal
        '
        Me.lblTotal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTotal.ControlAssociationKey = -1
        Me.lblTotal.Location = New System.Drawing.Point(240, 538)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(216, 15)
        Me.lblTotal.TabIndex = 2
        Me.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CustomLabel1
        '
        Me.CustomLabel1.AutoSize = True
        Me.CustomLabel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.CustomLabel1.ControlAssociationKey = -1
        Me.CustomLabel1.Location = New System.Drawing.Point(16, 538)
        Me.CustomLabel1.Name = "CustomLabel1"
        Me.CustomLabel1.Size = New System.Drawing.Size(218, 15)
        Me.CustomLabel1.TabIndex = 1
        Me.CustomLabel1.Text = "Tipo de Doc.:  1) Ef.    2) U$S    3)  Ch Terc."
        '
        'Depositos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(790, 568)
        Me.Controls.Add(Me.txtImporte)
        Me.Controls.Add(Me.CustomLabel7)
        Me.Controls.Add(Me.lstSeleccion)
        Me.Controls.Add(Me.btnCerrar)
        Me.Controls.Add(Me.btnConsulta)
        Me.Controls.Add(Me.btnLimpiar)
        Me.Controls.Add(Me.btnImpresion)
        Me.Controls.Add(Me.btnAgregar)
        Me.Controls.Add(Me.lstConsulta)
        Me.Controls.Add(Me.txtFecha)
        Me.Controls.Add(Me.CustomLabel6)
        Me.Controls.Add(Me.txtDescripcionBanco)
        Me.Controls.Add(Me.txtNroDeposito)
        Me.Controls.Add(Me.txtCodigoBanco)
        Me.Controls.Add(Me.txtFechaAcreditacion)
        Me.Controls.Add(Me.CustomLabel5)
        Me.Controls.Add(Me.CustomLabel4)
        Me.Controls.Add(Me.CustomLabel3)
        Me.Controls.Add(Me.lblTotal)
        Me.Controls.Add(Me.CustomLabel1)
        Me.Controls.Add(Me.gridCheques)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.Name = "Depositos"
        Me.Text = "Ingreso de Depósitos"
        CType(Me.gridCheques, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gridCheques As System.Windows.Forms.DataGridView
    Friend WithEvents CustomLabel1 As WindowsApplication1.CustomLabel
    Friend WithEvents lblTotal As WindowsApplication1.CustomLabel
    Friend WithEvents CustomLabel3 As WindowsApplication1.CustomLabel
    Friend WithEvents CustomLabel4 As WindowsApplication1.CustomLabel
    Friend WithEvents CustomLabel5 As WindowsApplication1.CustomLabel
    Friend WithEvents txtFechaAcreditacion As WindowsApplication1.CustomTextBox
    Friend WithEvents txtCodigoBanco As WindowsApplication1.CustomTextBox
    Friend WithEvents txtNroDeposito As WindowsApplication1.CustomTextBox
    Friend WithEvents txtDescripcionBanco As WindowsApplication1.CustomTextBox
    Friend WithEvents CustomLabel6 As WindowsApplication1.CustomLabel
    Friend WithEvents txtFecha As WindowsApplication1.CustomTextBox
    Friend WithEvents lstConsulta As WindowsApplication1.CustomListBox
    Friend WithEvents btnAgregar As WindowsApplication1.CustomButton
    Friend WithEvents btnImpresion As WindowsApplication1.CustomButton
    Friend WithEvents btnLimpiar As WindowsApplication1.CustomButton
    Friend WithEvents btnConsulta As WindowsApplication1.CustomButton
    Friend WithEvents btnCerrar As WindowsApplication1.CustomButton
    Friend WithEvents lstSeleccion As WindowsApplication1.CustomListBox
    Friend WithEvents CustomLabel7 As WindowsApplication1.CustomLabel
    Friend WithEvents txtImporte As WindowsApplication1.CustomTextBox
    Friend WithEvents tipo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents numero As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents fecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents nombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents importe As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
