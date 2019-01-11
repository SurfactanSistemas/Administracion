Imports System.ComponentModel
Imports Microsoft.VisualBasic.CompilerServices
Imports SAC.My.Resources

<DesignerGenerated()> _
Partial Class ContinuarSalirMsgBox
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
        Me.btnContinuar = New Button()
        Me.btnSalir = New Button()
        Me.Label1 = New Label()
        Me.Panel1 = New Panel()
        Me.SuspendLayout()
        '
        'btnContinuar
        '
        Me.btnContinuar.DialogResult = DialogResult.OK
        Me.btnContinuar.Location = New Point(36, 98)
        Me.btnContinuar.Name = "btnContinuar"
        Me.btnContinuar.Size = New Size(183, 27)
        Me.btnContinuar.TabIndex = 0
        Me.btnContinuar.Text = "Continuar"
        Me.btnContinuar.UseVisualStyleBackColor = True
        '
        'btnSalir
        '
        Me.btnSalir.DialogResult = DialogResult.Cancel
        Me.btnSalir.Location = New Point(235, 98)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New Size(183, 27)
        Me.btnSalir.TabIndex = 0
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Font = New Font("Microsoft Sans Serif", 10.0!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New Point(33, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New Size(300, 86)
        Me.Label1.TabIndex = 1
        Me.Label1.TextAlign = ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.Panel1.BackgroundImage = exm
        Me.Panel1.BackgroundImageLayout = ImageLayout.Zoom
        Me.Panel1.Location = New Point(339, 18)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New Size(79, 62)
        Me.Panel1.TabIndex = 2
        '
        'ContinuarSalirMsgBox
        '
        Me.AcceptButton = Me.btnContinuar
        Me.AutoScaleDimensions = New SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = AutoScaleMode.Font
        Me.CancelButton = Me.btnSalir
        Me.ClientSize = New Size(455, 137)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.btnContinuar)
        Me.FormBorderStyle = FormBorderStyle.FixedDialog
        Me.HelpButton = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ContinuarSalirMsgBox"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = FormStartPosition.CenterParent
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnContinuar As Button
    Friend WithEvents btnSalir As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel1 As Panel
End Class
