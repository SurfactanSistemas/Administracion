<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ConsultaCompras
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
        Me.CLBFiltrado = New Administracion.CustomListBox()
        Me.lstConsulta = New Administracion.CustomListBox()
        Me.txtConsulta = New Administracion.CustomTextBox()
        Me.lstSeleccion = New Administracion.CustomListBox()
        Me.SuspendLayout()
        '
        'CLBFiltrado
        '
        Me.CLBFiltrado.Cleanable = True
        Me.CLBFiltrado.EnterIndex = 0
        Me.CLBFiltrado.FormattingEnabled = True
        Me.CLBFiltrado.LabelAssociationKey = -1
        Me.CLBFiltrado.Location = New System.Drawing.Point(0, 25)
        Me.CLBFiltrado.Name = "CLBFiltrado"
        Me.CLBFiltrado.Size = New System.Drawing.Size(394, 251)
        Me.CLBFiltrado.TabIndex = 5
        Me.CLBFiltrado.Visible = False
        '
        'lstConsulta
        '
        Me.lstConsulta.Cleanable = False
        Me.lstConsulta.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lstConsulta.EnterIndex = -1
        Me.lstConsulta.FormattingEnabled = True
        Me.lstConsulta.LabelAssociationKey = -1
        Me.lstConsulta.Location = New System.Drawing.Point(0, 25)
        Me.lstConsulta.Name = "lstConsulta"
        Me.lstConsulta.Size = New System.Drawing.Size(394, 251)
        Me.lstConsulta.TabIndex = 4
        Me.lstConsulta.Visible = False
        '
        'txtConsulta
        '
        Me.txtConsulta.Cleanable = False
        Me.txtConsulta.Dock = System.Windows.Forms.DockStyle.Top
        Me.txtConsulta.Empty = True
        Me.txtConsulta.EnterIndex = -1
        Me.txtConsulta.LabelAssociationKey = -1
        Me.txtConsulta.Location = New System.Drawing.Point(0, 0)
        Me.txtConsulta.Name = "txtConsulta"
        Me.txtConsulta.Size = New System.Drawing.Size(394, 20)
        Me.txtConsulta.TabIndex = 2
        Me.txtConsulta.Validator = Administracion.ValidatorType.None
        Me.txtConsulta.Visible = False
        '
        'lstSeleccion
        '
        Me.lstSeleccion.Cleanable = False
        Me.lstSeleccion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lstSeleccion.EnterIndex = -1
        Me.lstSeleccion.FormattingEnabled = True
        Me.lstSeleccion.Items.AddRange(New Object() {"Proveedores", "Cuentas Contables"})
        Me.lstSeleccion.LabelAssociationKey = -1
        Me.lstSeleccion.Location = New System.Drawing.Point(0, 0)
        Me.lstSeleccion.Name = "lstSeleccion"
        Me.lstSeleccion.Size = New System.Drawing.Size(394, 25)
        Me.lstSeleccion.TabIndex = 0
        '
        'ConsultaCompras
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(394, 276)
        Me.Controls.Add(Me.txtConsulta)
        Me.Controls.Add(Me.lstSeleccion)
        Me.Controls.Add(Me.CLBFiltrado)
        Me.Controls.Add(Me.lstConsulta)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "ConsultaCompras"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Consulta Compras"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lstSeleccion As Administracion.CustomListBox
    Friend WithEvents txtConsulta As Administracion.CustomTextBox
    Friend WithEvents lstConsulta As Administracion.CustomListBox
    Friend WithEvents CLBFiltrado As Administracion.CustomListBox
End Class
