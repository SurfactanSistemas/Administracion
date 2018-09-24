<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AjusteInventarioMPMovVarios
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
        Me.btnProcesar = New System.Windows.Forms.Button()
        Me.btnProcesarPT = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnProcesar
        '
        Me.btnProcesar.Location = New System.Drawing.Point(33, 53)
        Me.btnProcesar.Name = "btnProcesar"
        Me.btnProcesar.Size = New System.Drawing.Size(107, 37)
        Me.btnProcesar.TabIndex = 0
        Me.btnProcesar.Text = "Procesar MP's"
        Me.btnProcesar.UseVisualStyleBackColor = True
        '
        'btnProcesarPT
        '
        Me.btnProcesarPT.Location = New System.Drawing.Point(167, 53)
        Me.btnProcesarPT.Name = "btnProcesarPT"
        Me.btnProcesarPT.Size = New System.Drawing.Size(107, 37)
        Me.btnProcesarPT.TabIndex = 0
        Me.btnProcesarPT.Text = "Procesar PT's"
        Me.btnProcesarPT.UseVisualStyleBackColor = True
        '
        'AjusteInventarioMPMovVarios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(307, 143)
        Me.Controls.Add(Me.btnProcesarPT)
        Me.Controls.Add(Me.btnProcesar)
        Me.Name = "AjusteInventarioMPMovVarios"
        Me.Text = "AjusteInventarioMPMovVar"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnProcesar As System.Windows.Forms.Button
    Friend WithEvents btnProcesarPT As System.Windows.Forms.Button
End Class
