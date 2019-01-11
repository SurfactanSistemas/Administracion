Imports System.ComponentModel
Imports Microsoft.VisualBasic.CompilerServices
Imports SAC.My.Resources

<DesignerGenerated()> _
Partial Class NuevoCentro
    Inherits Form

    'Form overrides dispose to clean up the component list.
    <DebuggerNonUserCode()> _
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
    Private components As IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New Container()
        Me.Panel1 = New Panel()
        Me.Label2 = New Label()
        Me.Label1 = New Label()
        Me.Label3 = New Label()
        Me.txtCodigo = New TextBox()
        Me.Label4 = New Label()
        Me.txtDescripcion = New TextBox()
        Me.btnGrabar = New Button()
        Me.btnEliminar = New Button()
        Me.btnCerrar = New Button()
        Me.btnLimpiar = New Button()
        Me.txtResponsable = New TextBox()
        Me.Label5 = New Label()
        Me.lblDescResponsable = New Label()
        Me.btnConsultaResp = New Button()
        Me.ToolTip1 = New ToolTip(Me.components)
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = DockStyle.Top
        Me.Panel1.Location = New Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New Size(511, 50)
        Me.Panel1.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New Font("Calibri", 11.25!, FontStyle.Bold, GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = SystemColors.Control
        Me.Label2.Location = New Point(25, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New Size(114, 18)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Responsable SAC"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New Font("Calibri", 11.25!, FontStyle.Bold, GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = SystemColors.Control
        Me.Label1.Location = New Point(391, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New Size(108, 18)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "SURFACTAN S.A."
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New Point(65, 69)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New Size(40, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Código"
        '
        'txtCodigo
        '
        Me.txtCodigo.Location = New Point(118, 66)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Size = New Size(55, 20)
        Me.txtCodigo.TabIndex = 1
        Me.txtCodigo.TextAlign = HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New Point(42, 100)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New Size(63, 13)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Descripción"
        '
        'txtDescripcion
        '
        Me.txtDescripcion.Location = New Point(118, 96)
        Me.txtDescripcion.MaxLength = 50
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New Size(362, 20)
        Me.txtDescripcion.TabIndex = 2
        '
        'btnGrabar
        '
        Me.btnGrabar.Location = New Point(45, 195)
        Me.btnGrabar.Name = "btnGrabar"
        Me.btnGrabar.Size = New Size(93, 29)
        Me.btnGrabar.TabIndex = 5
        Me.btnGrabar.Text = "Grabar"
        Me.btnGrabar.UseVisualStyleBackColor = True
        '
        'btnEliminar
        '
        Me.btnEliminar.Location = New Point(154, 195)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New Size(93, 29)
        Me.btnEliminar.TabIndex = 5
        Me.btnEliminar.Text = "Eliminar"
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'btnCerrar
        '
        Me.btnCerrar.Location = New Point(372, 195)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New Size(93, 29)
        Me.btnCerrar.TabIndex = 5
        Me.btnCerrar.Text = "Cerrar"
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Location = New Point(263, 195)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New Size(93, 29)
        Me.btnLimpiar.TabIndex = 5
        Me.btnLimpiar.Text = "Limpiar"
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'txtResponsable
        '
        Me.txtResponsable.Location = New Point(146, 129)
        Me.txtResponsable.MaxLength = 50
        Me.txtResponsable.Name = "txtResponsable"
        Me.txtResponsable.Size = New Size(38, 20)
        Me.txtResponsable.TabIndex = 3
        Me.txtResponsable.TextAlign = HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New Point(31, 133)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New Size(69, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Responsable"
        '
        'lblDescResponsable
        '
        Me.lblDescResponsable.BackColor = Color.Cyan
        Me.lblDescResponsable.BorderStyle = BorderStyle.Fixed3D
        Me.lblDescResponsable.Location = New Point(190, 129)
        Me.lblDescResponsable.Name = "lblDescResponsable"
        Me.lblDescResponsable.Size = New Size(290, 21)
        Me.lblDescResponsable.TabIndex = 4
        Me.lblDescResponsable.TextAlign = ContentAlignment.MiddleLeft
        '
        'btnConsultaResp
        '
        Me.btnConsultaResp.BackgroundImage = Consulta_Dat_N1
        Me.btnConsultaResp.BackgroundImageLayout = ImageLayout.Zoom
        Me.btnConsultaResp.FlatAppearance.BorderColor = SystemColors.Control
        Me.btnConsultaResp.FlatAppearance.BorderSize = 0
        Me.btnConsultaResp.FlatAppearance.MouseDownBackColor = SystemColors.Control
        Me.btnConsultaResp.FlatAppearance.MouseOverBackColor = SystemColors.Control
        Me.btnConsultaResp.FlatStyle = FlatStyle.Flat
        Me.btnConsultaResp.Location = New Point(118, 127)
        Me.btnConsultaResp.Name = "btnConsultaResp"
        Me.btnConsultaResp.Size = New Size(26, 24)
        Me.btnConsultaResp.TabIndex = 5
        Me.ToolTip1.SetToolTip(Me.btnConsultaResp, "Abrir consulta de Responsables SAC")
        Me.btnConsultaResp.UseVisualStyleBackColor = True
        '
        'NuevoCentro
        '
        Me.AutoScaleDimensions = New SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = AutoScaleMode.Font
        Me.ClientSize = New Size(511, 249)
        Me.Controls.Add(Me.btnLimpiar)
        Me.Controls.Add(Me.btnCerrar)
        Me.Controls.Add(Me.btnEliminar)
        Me.Controls.Add(Me.btnConsultaResp)
        Me.Controls.Add(Me.btnGrabar)
        Me.Controls.Add(Me.lblDescResponsable)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtResponsable)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtDescripcion)
        Me.Controls.Add(Me.txtCodigo)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Panel1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "NuevoCentro"
        Me.StartPosition = FormStartPosition.CenterParent
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txtCodigo As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtDescripcion As TextBox
    Friend WithEvents btnGrabar As Button
    Friend WithEvents btnEliminar As Button
    Friend WithEvents btnCerrar As Button
    Friend WithEvents btnLimpiar As Button
    Friend WithEvents txtResponsable As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents lblDescResponsable As Label
    Friend WithEvents btnConsultaResp As Button
    Friend WithEvents ToolTip1 As ToolTip
End Class
