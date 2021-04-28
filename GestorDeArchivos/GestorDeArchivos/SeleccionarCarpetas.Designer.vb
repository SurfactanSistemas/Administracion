<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SeleccionarCarpetas
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.chk_General = New System.Windows.Forms.CheckBox()
        Me.chk_Proforma = New System.Windows.Forms.CheckBox()
        Me.chk_SIMI = New System.Windows.Forms.CheckBox()
        Me.chk_OrdenCompra = New System.Windows.Forms.CheckBox()
        Me.chk_PackingList = New System.Windows.Forms.CheckBox()
        Me.chk_COAS = New System.Windows.Forms.CheckBox()
        Me.chk_BL = New System.Windows.Forms.CheckBox()
        Me.chk_INVOICE = New System.Windows.Forms.CheckBox()
        Me.btn_Aceptar = New System.Windows.Forms.Button()
        Me.CANCELAR = New System.Windows.Forms.Button()
        Me.gbx_Carpetas = New System.Windows.Forms.GroupBox()
        Me.chk_Despacho = New System.Windows.Forms.CheckBox()
        Me.Panel1.SuspendLayout()
        Me.gbx_Carpetas.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(327, 42)
        Me.Panel1.TabIndex = 62
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.Control
        Me.Label1.Location = New System.Drawing.Point(8, 10)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(161, 24)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Elija donde copiar"
        '
        'chk_General
        '
        Me.chk_General.AutoSize = True
        Me.chk_General.Location = New System.Drawing.Point(23, 28)
        Me.chk_General.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.chk_General.Name = "chk_General"
        Me.chk_General.Size = New System.Drawing.Size(81, 21)
        Me.chk_General.TabIndex = 63
        Me.chk_General.Text = "General"
        Me.chk_General.UseVisualStyleBackColor = True
        '
        'chk_Proforma
        '
        Me.chk_Proforma.AutoSize = True
        Me.chk_Proforma.Location = New System.Drawing.Point(23, 57)
        Me.chk_Proforma.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.chk_Proforma.Name = "chk_Proforma"
        Me.chk_Proforma.Size = New System.Drawing.Size(88, 21)
        Me.chk_Proforma.TabIndex = 64
        Me.chk_Proforma.Text = "Proforma"
        Me.chk_Proforma.UseVisualStyleBackColor = True
        '
        'chk_SIMI
        '
        Me.chk_SIMI.AutoSize = True
        Me.chk_SIMI.Location = New System.Drawing.Point(23, 85)
        Me.chk_SIMI.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.chk_SIMI.Name = "chk_SIMI"
        Me.chk_SIMI.Size = New System.Drawing.Size(56, 21)
        Me.chk_SIMI.TabIndex = 65
        Me.chk_SIMI.Text = "SIMI"
        Me.chk_SIMI.UseVisualStyleBackColor = True
        '
        'chk_OrdenCompra
        '
        Me.chk_OrdenCompra.AutoSize = True
        Me.chk_OrdenCompra.Location = New System.Drawing.Point(23, 113)
        Me.chk_OrdenCompra.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.chk_OrdenCompra.Name = "chk_OrdenCompra"
        Me.chk_OrdenCompra.Size = New System.Drawing.Size(123, 21)
        Me.chk_OrdenCompra.TabIndex = 66
        Me.chk_OrdenCompra.Text = "Orden Compra"
        Me.chk_OrdenCompra.UseVisualStyleBackColor = True
        '
        'chk_PackingList
        '
        Me.chk_PackingList.AutoSize = True
        Me.chk_PackingList.Location = New System.Drawing.Point(151, 28)
        Me.chk_PackingList.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.chk_PackingList.Name = "chk_PackingList"
        Me.chk_PackingList.Size = New System.Drawing.Size(106, 21)
        Me.chk_PackingList.TabIndex = 67
        Me.chk_PackingList.Text = "Packing List"
        Me.chk_PackingList.UseVisualStyleBackColor = True
        '
        'chk_COAS
        '
        Me.chk_COAS.AutoSize = True
        Me.chk_COAS.Location = New System.Drawing.Point(151, 57)
        Me.chk_COAS.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.chk_COAS.Name = "chk_COAS"
        Me.chk_COAS.Size = New System.Drawing.Size(68, 21)
        Me.chk_COAS.TabIndex = 68
        Me.chk_COAS.Text = "COAS"
        Me.chk_COAS.UseVisualStyleBackColor = True
        '
        'chk_BL
        '
        Me.chk_BL.AutoSize = True
        Me.chk_BL.Location = New System.Drawing.Point(151, 85)
        Me.chk_BL.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.chk_BL.Name = "chk_BL"
        Me.chk_BL.Size = New System.Drawing.Size(47, 21)
        Me.chk_BL.TabIndex = 69
        Me.chk_BL.Text = "BL"
        Me.chk_BL.UseVisualStyleBackColor = True
        '
        'chk_INVOICE
        '
        Me.chk_INVOICE.AutoSize = True
        Me.chk_INVOICE.Location = New System.Drawing.Point(151, 113)
        Me.chk_INVOICE.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.chk_INVOICE.Name = "chk_INVOICE"
        Me.chk_INVOICE.Size = New System.Drawing.Size(84, 21)
        Me.chk_INVOICE.TabIndex = 70
        Me.chk_INVOICE.Text = "INVOICE"
        Me.chk_INVOICE.UseVisualStyleBackColor = True
        '
        'btn_Aceptar
        '
        Me.btn_Aceptar.Location = New System.Drawing.Point(55, 217)
        Me.btn_Aceptar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btn_Aceptar.Name = "btn_Aceptar"
        Me.btn_Aceptar.Size = New System.Drawing.Size(100, 28)
        Me.btn_Aceptar.TabIndex = 71
        Me.btn_Aceptar.Text = "ACEPTAR"
        Me.btn_Aceptar.UseVisualStyleBackColor = True
        '
        'CANCELAR
        '
        Me.CANCELAR.Location = New System.Drawing.Point(180, 215)
        Me.CANCELAR.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CANCELAR.Name = "CANCELAR"
        Me.CANCELAR.Size = New System.Drawing.Size(100, 28)
        Me.CANCELAR.TabIndex = 72
        Me.CANCELAR.Text = "CANCELAR"
        Me.CANCELAR.UseVisualStyleBackColor = True
        '
        'gbx_Carpetas
        '
        Me.gbx_Carpetas.Controls.Add(Me.chk_Despacho)
        Me.gbx_Carpetas.Controls.Add(Me.chk_General)
        Me.gbx_Carpetas.Controls.Add(Me.chk_Proforma)
        Me.gbx_Carpetas.Controls.Add(Me.chk_SIMI)
        Me.gbx_Carpetas.Controls.Add(Me.chk_INVOICE)
        Me.gbx_Carpetas.Controls.Add(Me.chk_OrdenCompra)
        Me.gbx_Carpetas.Controls.Add(Me.chk_BL)
        Me.gbx_Carpetas.Controls.Add(Me.chk_PackingList)
        Me.gbx_Carpetas.Controls.Add(Me.chk_COAS)
        Me.gbx_Carpetas.Location = New System.Drawing.Point(19, 47)
        Me.gbx_Carpetas.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.gbx_Carpetas.Name = "gbx_Carpetas"
        Me.gbx_Carpetas.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.gbx_Carpetas.Size = New System.Drawing.Size(289, 162)
        Me.gbx_Carpetas.TabIndex = 73
        Me.gbx_Carpetas.TabStop = False
        Me.gbx_Carpetas.Text = "GroupBox1"
        '
        'chk_Despacho
        '
        Me.chk_Despacho.AutoSize = True
        Me.chk_Despacho.Location = New System.Drawing.Point(95, 139)
        Me.chk_Despacho.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.chk_Despacho.Name = "chk_Despacho"
        Me.chk_Despacho.Size = New System.Drawing.Size(94, 21)
        Me.chk_Despacho.TabIndex = 71
        Me.chk_Despacho.Text = "Despacho"
        Me.chk_Despacho.UseVisualStyleBackColor = True
        '
        'SeleccionarCarpetas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(327, 251)
        Me.Controls.Add(Me.gbx_Carpetas)
        Me.Controls.Add(Me.CANCELAR)
        Me.Controls.Add(Me.btn_Aceptar)
        Me.Controls.Add(Me.Panel1)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "SeleccionarCarpetas"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.gbx_Carpetas.ResumeLayout(False)
        Me.gbx_Carpetas.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents chk_General As System.Windows.Forms.CheckBox
    Friend WithEvents chk_Proforma As System.Windows.Forms.CheckBox
    Friend WithEvents chk_SIMI As System.Windows.Forms.CheckBox
    Friend WithEvents chk_OrdenCompra As System.Windows.Forms.CheckBox
    Friend WithEvents chk_PackingList As System.Windows.Forms.CheckBox
    Friend WithEvents chk_COAS As System.Windows.Forms.CheckBox
    Friend WithEvents chk_BL As System.Windows.Forms.CheckBox
    Friend WithEvents chk_INVOICE As System.Windows.Forms.CheckBox
    Friend WithEvents btn_Aceptar As System.Windows.Forms.Button
    Friend WithEvents CANCELAR As System.Windows.Forms.Button
    Friend WithEvents gbx_Carpetas As System.Windows.Forms.GroupBox
    Friend WithEvents chk_Despacho As System.Windows.Forms.CheckBox
End Class
