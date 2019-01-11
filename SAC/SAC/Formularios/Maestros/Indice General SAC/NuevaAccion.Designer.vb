Imports System.ComponentModel
Imports Microsoft.VisualBasic.CompilerServices

<DesignerGenerated()> _
Partial Class NuevaAccion
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
        Me.Panel1 = New Panel()
        Me.Label17 = New Label()
        Me.Label18 = New Label()
        Me.Label2 = New Label()
        Me.txtResponsable = New TextBox()
        Me.lblDescResponsable = New Label()
        Me.Label4 = New Label()
        Me.txtPlazo = New MaskedTextBox()
        Me.Label5 = New Label()
        Me.txtAccionCorrectiva = New TextBox()
        Me.btnGrabar = New Button()
        Me.btnEliminar = New Button()
        Me.btnCerrar = New Button()
        Me.lblRestantes = New Label()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Label17)
        Me.Panel1.Controls.Add(Me.Label18)
        Me.Panel1.Dock = DockStyle.Top
        Me.Panel1.Location = New Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New Size(461, 36)
        Me.Panel1.TabIndex = 1
        '
        'Label17
        '
        Me.Label17.Anchor = CType(((AnchorStyles.Top Or AnchorStyles.Bottom) _
                    Or AnchorStyles.Left), AnchorStyles)
        Me.Label17.AutoSize = True
        Me.Label17.Font = New Font("Calibri", 11.25!, FontStyle.Bold, GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = SystemColors.Control
        Me.Label17.Location = New Point(25, 9)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New Size(76, 18)
        Me.Label17.TabIndex = 0
        Me.Label17.Text = "Acción SAC"
        '
        'Label18
        '
        Me.Label18.Anchor = CType(((AnchorStyles.Top Or AnchorStyles.Bottom) _
                    Or AnchorStyles.Right), AnchorStyles)
        Me.Label18.AutoSize = True
        Me.Label18.Font = New Font("Calibri", 11.25!, FontStyle.Bold, GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = SystemColors.Control
        Me.Label18.Location = New Point(341, 9)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New Size(108, 18)
        Me.Label18.TabIndex = 0
        Me.Label18.Text = "SURFACTAN S.A."
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New Point(34, 51)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New Size(72, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Responsable:"
        '
        'txtResponsable
        '
        Me.txtResponsable.Location = New Point(108, 47)
        Me.txtResponsable.Name = "txtResponsable"
        Me.txtResponsable.Size = New Size(39, 20)
        Me.txtResponsable.TabIndex = 3
        '
        'lblDescResponsable
        '
        Me.lblDescResponsable.BackColor = Color.Cyan
        Me.lblDescResponsable.BorderStyle = BorderStyle.Fixed3D
        Me.lblDescResponsable.Font = New Font("Microsoft Sans Serif", 8.25!, FontStyle.Bold, GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescResponsable.Location = New Point(153, 47)
        Me.lblDescResponsable.Name = "lblDescResponsable"
        Me.lblDescResponsable.Size = New Size(174, 20)
        Me.lblDescResponsable.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New Point(328, 51)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New Size(36, 13)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Plazo:"
        '
        'txtPlazo
        '
        Me.txtPlazo.Location = New Point(370, 47)
        Me.txtPlazo.Mask = "00/00/0000"
        Me.txtPlazo.Name = "txtPlazo"
        Me.txtPlazo.PromptChar = ChrW(32)
        Me.txtPlazo.Size = New Size(68, 20)
        Me.txtPlazo.TabIndex = 4
        Me.txtPlazo.TextAlign = HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New Point(12, 77)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New Size(94, 13)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Acción Correctiva:"
        '
        'txtAccionCorrectiva
        '
        Me.txtAccionCorrectiva.Font = New Font("Microsoft Sans Serif", 10.0!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))
        Me.txtAccionCorrectiva.Location = New Point(108, 72)
        Me.txtAccionCorrectiva.MaxLength = 120
        Me.txtAccionCorrectiva.Multiline = True
        Me.txtAccionCorrectiva.Name = "txtAccionCorrectiva"
        Me.txtAccionCorrectiva.Size = New Size(330, 72)
        Me.txtAccionCorrectiva.TabIndex = 3
        '
        'btnGrabar
        '
        Me.btnGrabar.Location = New Point(56, 172)
        Me.btnGrabar.Name = "btnGrabar"
        Me.btnGrabar.Size = New Size(112, 32)
        Me.btnGrabar.TabIndex = 5
        Me.btnGrabar.Text = "Grabar"
        Me.btnGrabar.UseVisualStyleBackColor = True
        '
        'btnEliminar
        '
        Me.btnEliminar.Location = New Point(174, 172)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New Size(112, 32)
        Me.btnEliminar.TabIndex = 5
        Me.btnEliminar.Text = "Eliminar"
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'btnCerrar
        '
        Me.btnCerrar.Location = New Point(292, 172)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New Size(112, 32)
        Me.btnCerrar.TabIndex = 5
        Me.btnCerrar.Text = "Cerrar"
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'lblRestantes
        '
        Me.lblRestantes.BackColor = SystemColors.ControlLight
        Me.lblRestantes.BorderStyle = BorderStyle.Fixed3D
        Me.lblRestantes.Font = New Font("Microsoft Sans Serif", 7.0!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))
        Me.lblRestantes.Location = New Point(277, 147)
        Me.lblRestantes.Name = "lblRestantes"
        Me.lblRestantes.Size = New Size(161, 17)
        Me.lblRestantes.TabIndex = 2
        Me.lblRestantes.Text = "Caracteres Restantes: 0/120"
        Me.lblRestantes.TextAlign = ContentAlignment.TopRight
        '
        'NuevaAccion
        '
        Me.AutoScaleDimensions = New SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = AutoScaleMode.Font
        Me.ClientSize = New Size(461, 214)
        Me.Controls.Add(Me.btnCerrar)
        Me.Controls.Add(Me.btnEliminar)
        Me.Controls.Add(Me.btnGrabar)
        Me.Controls.Add(Me.txtPlazo)
        Me.Controls.Add(Me.txtAccionCorrectiva)
        Me.Controls.Add(Me.txtResponsable)
        Me.Controls.Add(Me.lblDescResponsable)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblRestantes)
        Me.Controls.Add(Me.Panel1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "NuevaAccion"
        Me.StartPosition = FormStartPosition.CenterParent
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label17 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtResponsable As TextBox
    Friend WithEvents lblDescResponsable As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents txtPlazo As MaskedTextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtAccionCorrectiva As TextBox
    Friend WithEvents btnGrabar As Button
    Friend WithEvents btnEliminar As Button
    Friend WithEvents btnCerrar As Button
    Friend WithEvents lblRestantes As Label
End Class
