﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ListadoCuentaCorrienteProveedoresFecha
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
        Me.lstAyuda = New Administracion.CustomListBox()
        Me.txtAyuda = New Administracion.CustomTextBox()
        Me.btnConsulta = New Administracion.CustomButton()
        Me.btnCancela = New Administracion.CustomButton()
        Me.txtDesdeProveedor = New Administracion.CustomTextBox()
        Me.CustomLabel1 = New Administracion.CustomLabel()
        Me.txtFechaEmision = New System.Windows.Forms.MaskedTextBox()
        Me.CustomLabel3 = New Administracion.CustomLabel()
        Me.txtRazon = New Administracion.CustomTextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnPantalla = New Administracion.CustomButton()
        Me.btnImprimir = New Administracion.CustomButton()
        Me.lstFiltrada = New Administracion.CustomListBox()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'lstAyuda
        '
        Me.lstAyuda.Cleanable = False
        Me.lstAyuda.EnterIndex = -1
        Me.lstAyuda.FormattingEnabled = True
        Me.lstAyuda.LabelAssociationKey = -1
        Me.lstAyuda.Location = New System.Drawing.Point(105, 291)
        Me.lstAyuda.Name = "lstAyuda"
        Me.lstAyuda.Size = New System.Drawing.Size(417, 147)
        Me.lstAyuda.TabIndex = 37
        Me.lstAyuda.Visible = False
        '
        'txtAyuda
        '
        Me.txtAyuda.Cleanable = False
        Me.txtAyuda.Empty = True
        Me.txtAyuda.EnterIndex = -1
        Me.txtAyuda.LabelAssociationKey = -1
        Me.txtAyuda.Location = New System.Drawing.Point(105, 265)
        Me.txtAyuda.Name = "txtAyuda"
        Me.txtAyuda.Size = New System.Drawing.Size(417, 20)
        Me.txtAyuda.TabIndex = 36
        Me.txtAyuda.Validator = Administracion.ValidatorType.None
        Me.txtAyuda.Visible = False
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
        Me.btnConsulta.Location = New System.Drawing.Point(216, 208)
        Me.btnConsulta.Name = "btnConsulta"
        Me.btnConsulta.Size = New System.Drawing.Size(86, 40)
        Me.btnConsulta.TabIndex = 35
        Me.ToolTip1.SetToolTip(Me.btnConsulta, "Consulta de Proveedores")
        Me.btnConsulta.UseVisualStyleBackColor = True
        '
        'btnCancela
        '
        Me.btnCancela.BackgroundImage = Global.Administracion.My.Resources.Resources.Salir2
        Me.btnCancela.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnCancela.Cleanable = False
        Me.btnCancela.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCancela.EnterIndex = -1
        Me.btnCancela.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnCancela.FlatAppearance.BorderSize = 0
        Me.btnCancela.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.Control
        Me.btnCancela.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control
        Me.btnCancela.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control
        Me.btnCancela.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancela.LabelAssociationKey = -1
        Me.btnCancela.Location = New System.Drawing.Point(108, 208)
        Me.btnCancela.Name = "btnCancela"
        Me.btnCancela.Size = New System.Drawing.Size(86, 40)
        Me.btnCancela.TabIndex = 34
        Me.ToolTip1.SetToolTip(Me.btnCancela, "Cerrar")
        Me.btnCancela.UseVisualStyleBackColor = True
        '
        'txtDesdeProveedor
        '
        Me.txtDesdeProveedor.Cleanable = False
        Me.txtDesdeProveedor.Empty = True
        Me.txtDesdeProveedor.EnterIndex = -1
        Me.txtDesdeProveedor.LabelAssociationKey = -1
        Me.txtDesdeProveedor.Location = New System.Drawing.Point(173, 82)
        Me.txtDesdeProveedor.MaxLength = 11
        Me.txtDesdeProveedor.Name = "txtDesdeProveedor"
        Me.txtDesdeProveedor.Size = New System.Drawing.Size(100, 20)
        Me.txtDesdeProveedor.TabIndex = 1
        Me.ToolTip1.SetToolTip(Me.txtDesdeProveedor, "Doble Click: Abrir Consulta de Proveedores")
        Me.txtDesdeProveedor.Validator = Administracion.ValidatorType.None
        '
        'CustomLabel1
        '
        Me.CustomLabel1.AutoSize = True
        Me.CustomLabel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(95, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(82, Byte), Integer))
        Me.CustomLabel1.ControlAssociationKey = -1
        Me.CustomLabel1.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.CustomLabel1.ForeColor = System.Drawing.SystemColors.Control
        Me.CustomLabel1.Location = New System.Drawing.Point(99, 85)
        Me.CustomLabel1.Name = "CustomLabel1"
        Me.CustomLabel1.Size = New System.Drawing.Size(73, 18)
        Me.CustomLabel1.TabIndex = 30
        Me.CustomLabel1.Text = "Proveedor"
        '
        'txtFechaEmision
        '
        Me.txtFechaEmision.Location = New System.Drawing.Point(173, 43)
        Me.txtFechaEmision.Mask = "##/##/####"
        Me.txtFechaEmision.Name = "txtFechaEmision"
        Me.txtFechaEmision.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtFechaEmision.Size = New System.Drawing.Size(100, 20)
        Me.txtFechaEmision.TabIndex = 0
        '
        'CustomLabel3
        '
        Me.CustomLabel3.AutoSize = True
        Me.CustomLabel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(95, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(82, Byte), Integer))
        Me.CustomLabel3.ControlAssociationKey = -1
        Me.CustomLabel3.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.CustomLabel3.ForeColor = System.Drawing.SystemColors.Control
        Me.CustomLabel3.Location = New System.Drawing.Point(76, 43)
        Me.CustomLabel3.Name = "CustomLabel3"
        Me.CustomLabel3.Size = New System.Drawing.Size(96, 18)
        Me.CustomLabel3.TabIndex = 46
        Me.CustomLabel3.Text = "Fecha Emision"
        '
        'txtRazon
        '
        Me.txtRazon.BackColor = System.Drawing.Color.Silver
        Me.txtRazon.Cleanable = False
        Me.txtRazon.Empty = True
        Me.txtRazon.EnterIndex = -1
        Me.txtRazon.LabelAssociationKey = -1
        Me.txtRazon.Location = New System.Drawing.Point(282, 82)
        Me.txtRazon.Name = "txtRazon"
        Me.txtRazon.Size = New System.Drawing.Size(269, 20)
        Me.txtRazon.TabIndex = 48
        Me.txtRazon.Validator = Administracion.ValidatorType.None
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(628, 50)
        Me.Panel1.TabIndex = 49
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.Control
        Me.Label2.Location = New System.Drawing.Point(449, 11)
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
        Me.Label1.Location = New System.Drawing.Point(27, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(365, 19)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Listado de Cuenta Corriente de Proveedores a Fecha"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(95, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(82, Byte), Integer))
        Me.Panel2.Controls.Add(Me.txtFechaEmision)
        Me.Panel2.Controls.Add(Me.CustomLabel1)
        Me.Panel2.Controls.Add(Me.txtRazon)
        Me.Panel2.Controls.Add(Me.txtDesdeProveedor)
        Me.Panel2.Controls.Add(Me.CustomLabel3)
        Me.Panel2.Location = New System.Drawing.Point(1, 50)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(627, 147)
        Me.Panel2.TabIndex = 50
        '
        'btnPantalla
        '
        Me.btnPantalla.BackgroundImage = Global.Administracion.My.Resources.Resources.Screen_preview
        Me.btnPantalla.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnPantalla.Cleanable = False
        Me.btnPantalla.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnPantalla.EnterIndex = -1
        Me.btnPantalla.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnPantalla.FlatAppearance.BorderSize = 0
        Me.btnPantalla.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.Control
        Me.btnPantalla.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control
        Me.btnPantalla.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control
        Me.btnPantalla.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPantalla.LabelAssociationKey = -1
        Me.btnPantalla.Location = New System.Drawing.Point(324, 208)
        Me.btnPantalla.Name = "btnPantalla"
        Me.btnPantalla.Size = New System.Drawing.Size(86, 40)
        Me.btnPantalla.TabIndex = 35
        Me.ToolTip1.SetToolTip(Me.btnPantalla, "Mostrar Reporte por Pantalla")
        Me.btnPantalla.UseVisualStyleBackColor = True
        '
        'btnImprimir
        '
        Me.btnImprimir.BackgroundImage = Global.Administracion.My.Resources.Resources.imprimir
        Me.btnImprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnImprimir.Cleanable = False
        Me.btnImprimir.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnImprimir.EnterIndex = -1
        Me.btnImprimir.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnImprimir.FlatAppearance.BorderSize = 0
        Me.btnImprimir.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.Control
        Me.btnImprimir.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control
        Me.btnImprimir.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control
        Me.btnImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnImprimir.LabelAssociationKey = -1
        Me.btnImprimir.Location = New System.Drawing.Point(432, 208)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(86, 40)
        Me.btnImprimir.TabIndex = 35
        Me.ToolTip1.SetToolTip(Me.btnImprimir, "Imprimir Reporte")
        Me.btnImprimir.UseVisualStyleBackColor = True
        '
        'lstFiltrada
        '
        Me.lstFiltrada.Cleanable = False
        Me.lstFiltrada.EnterIndex = -1
        Me.lstFiltrada.FormattingEnabled = True
        Me.lstFiltrada.LabelAssociationKey = -1
        Me.lstFiltrada.Location = New System.Drawing.Point(105, 291)
        Me.lstFiltrada.Name = "lstFiltrada"
        Me.lstFiltrada.Size = New System.Drawing.Size(417, 147)
        Me.lstFiltrada.TabIndex = 51
        Me.lstFiltrada.Visible = False
        '
        'ListadoCuentaCorrienteProveedoresFecha
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(627, 259)
        Me.Controls.Add(Me.lstFiltrada)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.lstAyuda)
        Me.Controls.Add(Me.txtAyuda)
        Me.Controls.Add(Me.btnImprimir)
        Me.Controls.Add(Me.btnPantalla)
        Me.Controls.Add(Me.btnConsulta)
        Me.Controls.Add(Me.btnCancela)
        Me.Controls.Add(Me.Panel2)
        Me.Name = "ListadoCuentaCorrienteProveedoresFecha"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lstAyuda As Administracion.CustomListBox
    Friend WithEvents txtAyuda As Administracion.CustomTextBox
    Friend WithEvents btnConsulta As Administracion.CustomButton
    Friend WithEvents btnCancela As Administracion.CustomButton
    Friend WithEvents txtDesdeProveedor As Administracion.CustomTextBox
    Friend WithEvents CustomLabel1 As Administracion.CustomLabel
    Friend WithEvents txtFechaEmision As System.Windows.Forms.MaskedTextBox
    Friend WithEvents CustomLabel3 As Administracion.CustomLabel
    Friend WithEvents txtRazon As Administracion.CustomTextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents lstFiltrada As Administracion.CustomListBox
    Friend WithEvents btnPantalla As Administracion.CustomButton
    Friend WithEvents btnImprimir As Administracion.CustomButton
End Class
