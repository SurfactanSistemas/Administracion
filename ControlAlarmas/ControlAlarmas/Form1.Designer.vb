<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.Surfac1Encendido = New System.Windows.Forms.CheckBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.btnSurfac1 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnSurfac2 = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnSurfac3 = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnSurfac5 = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnPellital = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Surfac2Encendido = New System.Windows.Forms.CheckBox()
        Me.Surfac3Encendido = New System.Windows.Forms.CheckBox()
        Me.Surfac5Encendido = New System.Windows.Forms.CheckBox()
        Me.PellitalEncendido = New System.Windows.Forms.CheckBox()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Surfac1Encendido
        '
        Me.Surfac1Encendido.AutoSize = True
        Me.Surfac1Encendido.Location = New System.Drawing.Point(12, 202)
        Me.Surfac1Encendido.Name = "Surfac1Encendido"
        Me.Surfac1Encendido.Size = New System.Drawing.Size(114, 17)
        Me.Surfac1Encendido.TabIndex = 2
        Me.Surfac1Encendido.Text = "Surfac1Encendido"
        Me.Surfac1Encendido.UseVisualStyleBackColor = True
        Me.Surfac1Encendido.Visible = False
        '
        'Timer1
        '
        Me.Timer1.Interval = 500
        '
        'btnSurfac1
        '
        Me.btnSurfac1.BackgroundImage = CType(resources.GetObject("btnSurfac1.BackgroundImage"), System.Drawing.Image)
        Me.btnSurfac1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnSurfac1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSurfac1.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnSurfac1.FlatAppearance.BorderSize = 0
        Me.btnSurfac1.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control
        Me.btnSurfac1.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control
        Me.btnSurfac1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSurfac1.Location = New System.Drawing.Point(47, 32)
        Me.btnSurfac1.Name = "btnSurfac1"
        Me.btnSurfac1.Size = New System.Drawing.Size(106, 123)
        Me.btnSurfac1.TabIndex = 0
        Me.btnSurfac1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(43, 145)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(114, 38)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "SURFACTAN PTA 1"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnSurfac2
        '
        Me.btnSurfac2.BackgroundImage = CType(resources.GetObject("btnSurfac2.BackgroundImage"), System.Drawing.Image)
        Me.btnSurfac2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnSurfac2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSurfac2.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnSurfac2.FlatAppearance.BorderSize = 0
        Me.btnSurfac2.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control
        Me.btnSurfac2.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control
        Me.btnSurfac2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSurfac2.Location = New System.Drawing.Point(201, 32)
        Me.btnSurfac2.Name = "btnSurfac2"
        Me.btnSurfac2.Size = New System.Drawing.Size(106, 123)
        Me.btnSurfac2.TabIndex = 0
        Me.btnSurfac2.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(197, 145)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(114, 38)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "SURFACTAN PTA 2"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnSurfac3
        '
        Me.btnSurfac3.BackgroundImage = CType(resources.GetObject("btnSurfac3.BackgroundImage"), System.Drawing.Image)
        Me.btnSurfac3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnSurfac3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSurfac3.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnSurfac3.FlatAppearance.BorderSize = 0
        Me.btnSurfac3.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control
        Me.btnSurfac3.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control
        Me.btnSurfac3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSurfac3.Location = New System.Drawing.Point(355, 32)
        Me.btnSurfac3.Name = "btnSurfac3"
        Me.btnSurfac3.Size = New System.Drawing.Size(106, 123)
        Me.btnSurfac3.TabIndex = 0
        Me.btnSurfac3.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(351, 145)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(114, 38)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "SURFACTAN PTA 3"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnSurfac5
        '
        Me.btnSurfac5.BackgroundImage = CType(resources.GetObject("btnSurfac5.BackgroundImage"), System.Drawing.Image)
        Me.btnSurfac5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnSurfac5.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSurfac5.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnSurfac5.FlatAppearance.BorderSize = 0
        Me.btnSurfac5.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control
        Me.btnSurfac5.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control
        Me.btnSurfac5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSurfac5.Location = New System.Drawing.Point(509, 32)
        Me.btnSurfac5.Name = "btnSurfac5"
        Me.btnSurfac5.Size = New System.Drawing.Size(106, 123)
        Me.btnSurfac5.TabIndex = 0
        Me.btnSurfac5.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(505, 145)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(114, 38)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "SURFACTAN PTA 5"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnPellital
        '
        Me.btnPellital.BackgroundImage = CType(resources.GetObject("btnPellital.BackgroundImage"), System.Drawing.Image)
        Me.btnPellital.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnPellital.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnPellital.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnPellital.FlatAppearance.BorderSize = 0
        Me.btnPellital.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control
        Me.btnPellital.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control
        Me.btnPellital.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPellital.Location = New System.Drawing.Point(681, 34)
        Me.btnPellital.Name = "btnPellital"
        Me.btnPellital.Size = New System.Drawing.Size(106, 123)
        Me.btnPellital.TabIndex = 0
        Me.btnPellital.UseVisualStyleBackColor = True
        Me.btnPellital.Visible = False
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(677, 147)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(114, 38)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "PELLITAL"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Label5.Visible = False
        '
        'Surfac2Encendido
        '
        Me.Surfac2Encendido.AutoSize = True
        Me.Surfac2Encendido.Location = New System.Drawing.Point(126, 202)
        Me.Surfac2Encendido.Name = "Surfac2Encendido"
        Me.Surfac2Encendido.Size = New System.Drawing.Size(114, 17)
        Me.Surfac2Encendido.TabIndex = 2
        Me.Surfac2Encendido.Text = "Surfac2Encendido"
        Me.Surfac2Encendido.UseVisualStyleBackColor = True
        Me.Surfac2Encendido.Visible = False
        '
        'Surfac3Encendido
        '
        Me.Surfac3Encendido.AutoSize = True
        Me.Surfac3Encendido.Location = New System.Drawing.Point(240, 202)
        Me.Surfac3Encendido.Name = "Surfac3Encendido"
        Me.Surfac3Encendido.Size = New System.Drawing.Size(114, 17)
        Me.Surfac3Encendido.TabIndex = 2
        Me.Surfac3Encendido.Text = "Surfac3Encendido"
        Me.Surfac3Encendido.UseVisualStyleBackColor = True
        Me.Surfac3Encendido.Visible = False
        '
        'Surfac5Encendido
        '
        Me.Surfac5Encendido.AutoSize = True
        Me.Surfac5Encendido.Location = New System.Drawing.Point(354, 202)
        Me.Surfac5Encendido.Name = "Surfac5Encendido"
        Me.Surfac5Encendido.Size = New System.Drawing.Size(114, 17)
        Me.Surfac5Encendido.TabIndex = 2
        Me.Surfac5Encendido.Text = "Surfac5Encendido"
        Me.Surfac5Encendido.UseVisualStyleBackColor = True
        Me.Surfac5Encendido.Visible = False
        '
        'PellitalEncendido
        '
        Me.PellitalEncendido.AutoSize = True
        Me.PellitalEncendido.Location = New System.Drawing.Point(468, 202)
        Me.PellitalEncendido.Name = "PellitalEncendido"
        Me.PellitalEncendido.Size = New System.Drawing.Size(107, 17)
        Me.PellitalEncendido.TabIndex = 2
        Me.PellitalEncendido.Text = "PellitalEncendido"
        Me.PellitalEncendido.UseVisualStyleBackColor = True
        Me.PellitalEncendido.Visible = False
        '
        'Timer2
        '
        Me.Timer2.Enabled = True
        Me.Timer2.Interval = 500
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(305, 195)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(332, 25)
        Me.Label6.TabIndex = 4
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(575, 12)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 5
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(662, 231)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PellitalEncendido)
        Me.Controls.Add(Me.Surfac5Encendido)
        Me.Controls.Add(Me.Surfac3Encendido)
        Me.Controls.Add(Me.Surfac2Encendido)
        Me.Controls.Add(Me.Surfac1Encendido)
        Me.Controls.Add(Me.btnPellital)
        Me.Controls.Add(Me.btnSurfac5)
        Me.Controls.Add(Me.btnSurfac3)
        Me.Controls.Add(Me.btnSurfac2)
        Me.Controls.Add(Me.btnSurfac1)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form1"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Control de Alarmas"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnSurfac1 As System.Windows.Forms.Button
    Friend WithEvents Surfac1Encendido As System.Windows.Forms.CheckBox
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnSurfac2 As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnSurfac3 As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnSurfac5 As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnPellital As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Surfac2Encendido As System.Windows.Forms.CheckBox
    Friend WithEvents Surfac3Encendido As System.Windows.Forms.CheckBox
    Friend WithEvents Surfac5Encendido As System.Windows.Forms.CheckBox
    Friend WithEvents PellitalEncendido As System.Windows.Forms.CheckBox
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents Timer2 As System.Windows.Forms.Timer
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button

End Class
