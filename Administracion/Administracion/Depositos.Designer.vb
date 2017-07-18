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
        Me.components = New System.ComponentModel.Container()
        Me.gridCheques = New System.Windows.Forms.DataGridView()
        Me.tipo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.numero = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.fecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.importe = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ClaveCheque = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtImporte = New Administracion.CustomTextBox()
        Me.CustomLabel7 = New Administracion.CustomLabel()
        Me.lstSeleccion = New Administracion.CustomListBox()
        Me.btnCerrar = New Administracion.CustomButton()
        Me.btnConsulta = New Administracion.CustomButton()
        Me.btnLimpiar = New Administracion.CustomButton()
        Me.btnImpresion = New Administracion.CustomButton()
        Me.btnAgregar = New Administracion.CustomButton()
        Me.lstConsulta = New Administracion.CustomListBox()
        Me.CustomLabel6 = New Administracion.CustomLabel()
        Me.txtDescripcionBanco = New Administracion.CustomTextBox()
        Me.txtNroDeposito = New Administracion.CustomTextBox()
        Me.txtCodigoBanco = New Administracion.CustomTextBox()
        Me.CustomLabel5 = New Administracion.CustomLabel()
        Me.CustomLabel4 = New Administracion.CustomLabel()
        Me.CustomLabel3 = New Administracion.CustomLabel()
        Me.lblTotal = New Administracion.CustomLabel()
        Me.CustomLabel1 = New Administracion.CustomLabel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.txtFechaAcreditacion = New System.Windows.Forms.MaskedTextBox()
        Me.txtFecha = New System.Windows.Forms.MaskedTextBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        CType(Me.gridCheques, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'gridCheques
        '
        Me.gridCheques.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridCheques.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.tipo, Me.numero, Me.fecha, Me.nombre, Me.importe, Me.ClaveCheque})
        Me.gridCheques.Location = New System.Drawing.Point(25, 123)
        Me.gridCheques.Name = "gridCheques"
        Me.gridCheques.Size = New System.Drawing.Size(743, 350)
        Me.gridCheques.StandardTab = True
        Me.gridCheques.TabIndex = 0
        '
        'tipo
        '
        Me.tipo.HeaderText = "Tipo"
        Me.tipo.Name = "tipo"
        Me.tipo.Width = 65
        '
        'numero
        '
        Me.numero.HeaderText = "Numero"
        Me.numero.Name = "numero"
        Me.numero.ReadOnly = True
        Me.numero.Width = 145
        '
        'fecha
        '
        Me.fecha.HeaderText = "Fecha"
        Me.fecha.Name = "fecha"
        Me.fecha.ReadOnly = True
        '
        'nombre
        '
        Me.nombre.HeaderText = "Nombre"
        Me.nombre.Name = "nombre"
        Me.nombre.ReadOnly = True
        Me.nombre.Width = 280
        '
        'importe
        '
        Me.importe.HeaderText = "Importe"
        Me.importe.Name = "importe"
        Me.importe.Width = 110
        '
        'ClaveCheque
        '
        Me.ClaveCheque.HeaderText = "ClaveCheque"
        Me.ClaveCheque.Name = "ClaveCheque"
        Me.ClaveCheque.Visible = False
        '
        'txtImporte
        '
        Me.txtImporte.Cleanable = True
        Me.txtImporte.Empty = False
        Me.txtImporte.EnterIndex = 5
        Me.txtImporte.LabelAssociationKey = 5
        Me.txtImporte.Location = New System.Drawing.Point(300, 79)
        Me.txtImporte.MaxLength = 10
        Me.txtImporte.Name = "txtImporte"
        Me.txtImporte.Size = New System.Drawing.Size(89, 20)
        Me.txtImporte.TabIndex = 16
        Me.txtImporte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtImporte.Validator = Administracion.ValidatorType.PositiveFloat
        '
        'CustomLabel7
        '
        Me.CustomLabel7.AutoSize = True
        Me.CustomLabel7.ControlAssociationKey = 5
        Me.CustomLabel7.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.CustomLabel7.ForeColor = System.Drawing.SystemColors.Control
        Me.CustomLabel7.Location = New System.Drawing.Point(239, 80)
        Me.CustomLabel7.Name = "CustomLabel7"
        Me.CustomLabel7.Size = New System.Drawing.Size(58, 18)
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
        Me.lstSeleccion.Location = New System.Drawing.Point(395, 14)
        Me.lstSeleccion.Name = "lstSeleccion"
        Me.lstSeleccion.Size = New System.Drawing.Size(373, 95)
        Me.lstSeleccion.TabIndex = 14
        Me.lstSeleccion.Visible = False
        '
        'btnCerrar
        '
        Me.btnCerrar.BackgroundImage = Global.Administracion.My.Resources.Resources.Salir2
        Me.btnCerrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnCerrar.Cleanable = False
        Me.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCerrar.EnterIndex = -1
        Me.btnCerrar.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnCerrar.FlatAppearance.BorderSize = 0
        Me.btnCerrar.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.Control
        Me.btnCerrar.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control
        Me.btnCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control
        Me.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCerrar.LabelAssociationKey = -1
        Me.btnCerrar.Location = New System.Drawing.Point(482, 570)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(110, 50)
        Me.btnCerrar.TabIndex = 13
        Me.ToolTip1.SetToolTip(Me.btnCerrar, "Cerrar")
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'btnConsulta
        '
        Me.btnConsulta.BackgroundImage = Global.Administracion.My.Resources.Resources.Consulta_Dat_N1
        Me.btnConsulta.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnConsulta.Cleanable = False
        Me.btnConsulta.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnConsulta.EnterIndex = -1
        Me.btnConsulta.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnConsulta.FlatAppearance.BorderSize = 0
        Me.btnConsulta.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.Control
        Me.btnConsulta.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control
        Me.btnConsulta.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control
        Me.btnConsulta.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnConsulta.LabelAssociationKey = -1
        Me.btnConsulta.Location = New System.Drawing.Point(198, 570)
        Me.btnConsulta.Name = "btnConsulta"
        Me.btnConsulta.Size = New System.Drawing.Size(110, 50)
        Me.btnConsulta.TabIndex = 12
        Me.ToolTip1.SetToolTip(Me.btnConsulta, "Abrir Consulta")
        Me.btnConsulta.UseVisualStyleBackColor = True
        '
        'btnLimpiar
        '
        Me.btnLimpiar.BackgroundImage = Global.Administracion.My.Resources.Resources.Limpiar
        Me.btnLimpiar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnLimpiar.Cleanable = False
        Me.btnLimpiar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnLimpiar.EnterIndex = -1
        Me.btnLimpiar.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnLimpiar.FlatAppearance.BorderSize = 0
        Me.btnLimpiar.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.Control
        Me.btnLimpiar.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control
        Me.btnLimpiar.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control
        Me.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLimpiar.LabelAssociationKey = -1
        Me.btnLimpiar.Location = New System.Drawing.Point(624, 570)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(110, 50)
        Me.btnLimpiar.TabIndex = 11
        Me.ToolTip1.SetToolTip(Me.btnLimpiar, "Limpiar Formulario")
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'btnImpresion
        '
        Me.btnImpresion.BackgroundImage = Global.Administracion.My.Resources.Resources.imprimir
        Me.btnImpresion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnImpresion.Cleanable = False
        Me.btnImpresion.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnImpresion.EnterIndex = -1
        Me.btnImpresion.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnImpresion.FlatAppearance.BorderSize = 0
        Me.btnImpresion.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.Control
        Me.btnImpresion.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control
        Me.btnImpresion.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control
        Me.btnImpresion.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnImpresion.LabelAssociationKey = -1
        Me.btnImpresion.Location = New System.Drawing.Point(340, 570)
        Me.btnImpresion.Name = "btnImpresion"
        Me.btnImpresion.Size = New System.Drawing.Size(110, 50)
        Me.btnImpresion.TabIndex = 10
        Me.ToolTip1.SetToolTip(Me.btnImpresion, "Imprimir Deposito")
        Me.btnImpresion.UseVisualStyleBackColor = True
        '
        'btnAgregar
        '
        Me.btnAgregar.BackgroundImage = Global.Administracion.My.Resources.Resources.Aceptar_N2
        Me.btnAgregar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnAgregar.Cleanable = False
        Me.btnAgregar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAgregar.EnterIndex = -1
        Me.btnAgregar.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnAgregar.FlatAppearance.BorderSize = 0
        Me.btnAgregar.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.Control
        Me.btnAgregar.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control
        Me.btnAgregar.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control
        Me.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAgregar.LabelAssociationKey = -1
        Me.btnAgregar.Location = New System.Drawing.Point(56, 570)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(110, 50)
        Me.btnAgregar.TabIndex = 9
        Me.ToolTip1.SetToolTip(Me.btnAgregar, "Aceptar")
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'lstConsulta
        '
        Me.lstConsulta.Cleanable = True
        Me.lstConsulta.EnterIndex = -1
        Me.lstConsulta.FormattingEnabled = True
        Me.lstConsulta.LabelAssociationKey = -1
        Me.lstConsulta.Location = New System.Drawing.Point(395, 14)
        Me.lstConsulta.Name = "lstConsulta"
        Me.lstConsulta.Size = New System.Drawing.Size(373, 95)
        Me.lstConsulta.TabIndex = 8
        Me.lstConsulta.Visible = False
        '
        'CustomLabel6
        '
        Me.CustomLabel6.AutoSize = True
        Me.CustomLabel6.ControlAssociationKey = 2
        Me.CustomLabel6.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.CustomLabel6.ForeColor = System.Drawing.SystemColors.Control
        Me.CustomLabel6.Location = New System.Drawing.Point(239, 25)
        Me.CustomLabel6.Name = "CustomLabel6"
        Me.CustomLabel6.Size = New System.Drawing.Size(44, 18)
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
        Me.txtDescripcionBanco.Location = New System.Drawing.Point(159, 53)
        Me.txtDescripcionBanco.MaxLength = 50
        Me.txtDescripcionBanco.Name = "txtDescripcionBanco"
        Me.txtDescripcionBanco.Size = New System.Drawing.Size(230, 20)
        Me.txtDescripcionBanco.TabIndex = 6
        Me.txtDescripcionBanco.TabStop = False
        Me.txtDescripcionBanco.Validator = Administracion.ValidatorType.None
        '
        'txtNroDeposito
        '
        Me.txtNroDeposito.Cleanable = True
        Me.txtNroDeposito.Empty = False
        Me.txtNroDeposito.EnterIndex = 1
        Me.txtNroDeposito.LabelAssociationKey = 1
        Me.txtNroDeposito.Location = New System.Drawing.Point(134, 23)
        Me.txtNroDeposito.MaxLength = 6
        Me.txtNroDeposito.Name = "txtNroDeposito"
        Me.txtNroDeposito.Size = New System.Drawing.Size(96, 20)
        Me.txtNroDeposito.TabIndex = 1
        Me.txtNroDeposito.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtNroDeposito.Validator = Administracion.ValidatorType.Positive
        '
        'txtCodigoBanco
        '
        Me.txtCodigoBanco.Cleanable = True
        Me.txtCodigoBanco.Empty = False
        Me.txtCodigoBanco.EnterIndex = 3
        Me.txtCodigoBanco.LabelAssociationKey = 3
        Me.txtCodigoBanco.Location = New System.Drawing.Point(82, 53)
        Me.txtCodigoBanco.MaxLength = 5
        Me.txtCodigoBanco.Name = "txtCodigoBanco"
        Me.txtCodigoBanco.Size = New System.Drawing.Size(71, 20)
        Me.txtCodigoBanco.TabIndex = 3
        Me.txtCodigoBanco.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.txtCodigoBanco, "Doble Click: Abrir Consulta de Bancos")
        Me.txtCodigoBanco.Validator = Administracion.ValidatorType.None
        '
        'CustomLabel5
        '
        Me.CustomLabel5.AutoSize = True
        Me.CustomLabel5.ControlAssociationKey = 4
        Me.CustomLabel5.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.CustomLabel5.ForeColor = System.Drawing.SystemColors.Control
        Me.CustomLabel5.Location = New System.Drawing.Point(31, 80)
        Me.CustomLabel5.Name = "CustomLabel5"
        Me.CustomLabel5.Size = New System.Drawing.Size(125, 18)
        Me.CustomLabel5.TabIndex = 5
        Me.CustomLabel5.Text = "Fecha Acreditación"
        '
        'CustomLabel4
        '
        Me.CustomLabel4.AutoSize = True
        Me.CustomLabel4.ControlAssociationKey = 3
        Me.CustomLabel4.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.CustomLabel4.ForeColor = System.Drawing.SystemColors.Control
        Me.CustomLabel4.Location = New System.Drawing.Point(34, 54)
        Me.CustomLabel4.Name = "CustomLabel4"
        Me.CustomLabel4.Size = New System.Drawing.Size(45, 18)
        Me.CustomLabel4.TabIndex = 4
        Me.CustomLabel4.Text = "Banco"
        '
        'CustomLabel3
        '
        Me.CustomLabel3.AutoSize = True
        Me.CustomLabel3.ControlAssociationKey = 1
        Me.CustomLabel3.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.CustomLabel3.ForeColor = System.Drawing.SystemColors.Control
        Me.CustomLabel3.Location = New System.Drawing.Point(34, 24)
        Me.CustomLabel3.Name = "CustomLabel3"
        Me.CustomLabel3.Size = New System.Drawing.Size(94, 18)
        Me.CustomLabel3.TabIndex = 3
        Me.CustomLabel3.Text = "Nro. Depósito"
        '
        'lblTotal
        '
        Me.lblTotal.BackColor = System.Drawing.SystemColors.Control
        Me.lblTotal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTotal.ControlAssociationKey = -1
        Me.lblTotal.Location = New System.Drawing.Point(552, 476)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(216, 15)
        Me.lblTotal.TabIndex = 2
        Me.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CustomLabel1
        '
        Me.CustomLabel1.AutoSize = True
        Me.CustomLabel1.BackColor = System.Drawing.SystemColors.Control
        Me.CustomLabel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.CustomLabel1.ControlAssociationKey = -1
        Me.CustomLabel1.Location = New System.Drawing.Point(328, 476)
        Me.CustomLabel1.Name = "CustomLabel1"
        Me.CustomLabel1.Size = New System.Drawing.Size(218, 15)
        Me.CustomLabel1.TabIndex = 1
        Me.CustomLabel1.Text = "Tipo de Doc.:  1) Ef.    2) U$S    3)  Ch Terc."
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(793, 50)
        Me.Panel1.TabIndex = 17
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.Control
        Me.Label2.Location = New System.Drawing.Point(616, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(156, 26)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "SURFACTAN S.A."
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.Control
        Me.Label1.Location = New System.Drawing.Point(21, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(151, 19)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Ingreso de Depósitos"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(95, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(82, Byte), Integer))
        Me.Panel2.Controls.Add(Me.txtFechaAcreditacion)
        Me.Panel2.Controls.Add(Me.txtFecha)
        Me.Panel2.Controls.Add(Me.txtImporte)
        Me.Panel2.Controls.Add(Me.CustomLabel3)
        Me.Panel2.Controls.Add(Me.lstSeleccion)
        Me.Panel2.Controls.Add(Me.CustomLabel4)
        Me.Panel2.Controls.Add(Me.CustomLabel7)
        Me.Panel2.Controls.Add(Me.CustomLabel5)
        Me.Panel2.Controls.Add(Me.lblTotal)
        Me.Panel2.Controls.Add(Me.txtCodigoBanco)
        Me.Panel2.Controls.Add(Me.CustomLabel1)
        Me.Panel2.Controls.Add(Me.txtNroDeposito)
        Me.Panel2.Controls.Add(Me.gridCheques)
        Me.Panel2.Controls.Add(Me.lstConsulta)
        Me.Panel2.Controls.Add(Me.txtDescripcionBanco)
        Me.Panel2.Controls.Add(Me.CustomLabel6)
        Me.Panel2.Location = New System.Drawing.Point(0, 50)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(793, 503)
        Me.Panel2.TabIndex = 18
        '
        'txtFechaAcreditacion
        '
        Me.txtFechaAcreditacion.Location = New System.Drawing.Point(158, 78)
        Me.txtFechaAcreditacion.Mask = "00/00/0000"
        Me.txtFechaAcreditacion.Name = "txtFechaAcreditacion"
        Me.txtFechaAcreditacion.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtFechaAcreditacion.Size = New System.Drawing.Size(75, 20)
        Me.txtFechaAcreditacion.TabIndex = 18
        Me.txtFechaAcreditacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtFechaAcreditacion.ValidatingType = GetType(Date)
        '
        'txtFecha
        '
        Me.txtFecha.Location = New System.Drawing.Point(289, 24)
        Me.txtFecha.Mask = "00/00/0000"
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtFecha.Size = New System.Drawing.Size(100, 20)
        Me.txtFecha.TabIndex = 17
        Me.txtFecha.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtFecha.ValidatingType = GetType(Date)
        '
        'Depositos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(790, 635)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.btnCerrar)
        Me.Controls.Add(Me.btnConsulta)
        Me.Controls.Add(Me.btnLimpiar)
        Me.Controls.Add(Me.btnImpresion)
        Me.Controls.Add(Me.btnAgregar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.Name = "Depositos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.gridCheques, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gridCheques As System.Windows.Forms.DataGridView
    Friend WithEvents CustomLabel1 As Administracion.CustomLabel
    Friend WithEvents lblTotal As Administracion.CustomLabel
    Friend WithEvents CustomLabel3 As Administracion.CustomLabel
    Friend WithEvents CustomLabel4 As Administracion.CustomLabel
    Friend WithEvents CustomLabel5 As Administracion.CustomLabel
    Friend WithEvents txtCodigoBanco As Administracion.CustomTextBox
    Friend WithEvents txtNroDeposito As Administracion.CustomTextBox
    Friend WithEvents txtDescripcionBanco As Administracion.CustomTextBox
    Friend WithEvents CustomLabel6 As Administracion.CustomLabel
    Friend WithEvents lstConsulta As Administracion.CustomListBox
    Friend WithEvents btnAgregar As Administracion.CustomButton
    Friend WithEvents btnImpresion As Administracion.CustomButton
    Friend WithEvents btnLimpiar As Administracion.CustomButton
    Friend WithEvents btnConsulta As Administracion.CustomButton
    Friend WithEvents btnCerrar As Administracion.CustomButton
    Friend WithEvents lstSeleccion As Administracion.CustomListBox
    Friend WithEvents CustomLabel7 As Administracion.CustomLabel
    Friend WithEvents txtImporte As Administracion.CustomTextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents txtFecha As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtFechaAcreditacion As System.Windows.Forms.MaskedTextBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents tipo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents numero As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents fecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents nombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents importe As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ClaveCheque As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
