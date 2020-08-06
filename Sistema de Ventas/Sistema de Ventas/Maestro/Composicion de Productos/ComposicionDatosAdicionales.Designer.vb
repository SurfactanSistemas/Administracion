<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ComposicionDatosAdicionales
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
        Me.panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.label1 = New System.Windows.Forms.Label()
        Me.txtRiesgo = New System.Windows.Forms.TextBox()
        Me.txtRSec = New System.Windows.Forms.TextBox()
        Me.txtClase = New System.Windows.Forms.TextBox()
        Me.txtEmbalaje = New System.Windows.Forms.TextBox()
        Me.txtFIntervension = New System.Windows.Forms.TextBox()
        Me.txtCaracteristicas = New System.Windows.Forms.TextBox()
        Me.txtNUnidas = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbCarga = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmbEstado = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtVidaUtil = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.ckRestriccion = New System.Windows.Forms.CheckBox()
        Me.panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'panel1
        '
        Me.panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(34, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.panel1.Controls.Add(Me.Label2)
        Me.panel1.Controls.Add(Me.label1)
        Me.panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.panel1.Location = New System.Drawing.Point(0, 0)
        Me.panel1.Name = "panel1"
        Me.panel1.Size = New System.Drawing.Size(425, 40)
        Me.panel1.TabIndex = 41
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(249, 10)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(155, 20)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "SURFACTAN S.A."
        '
        'label1
        '
        Me.label1.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.label1.AutoSize = True
        Me.label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.label1.ForeColor = System.Drawing.Color.White
        Me.label1.Location = New System.Drawing.Point(21, 12)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(150, 17)
        Me.label1.TabIndex = 0
        Me.label1.Text = "DATOS ADICIONALES"
        '
        'txtRiesgo
        '
        Me.txtRiesgo.Location = New System.Drawing.Point(245, 107)
        Me.txtRiesgo.MaxLength = 10
        Me.txtRiesgo.Name = "txtRiesgo"
        Me.txtRiesgo.Size = New System.Drawing.Size(74, 20)
        Me.txtRiesgo.TabIndex = 53
        Me.txtRiesgo.Text = "0000000000"
        '
        'txtRSec
        '
        Me.txtRSec.Location = New System.Drawing.Point(97, 107)
        Me.txtRSec.MaxLength = 10
        Me.txtRSec.Name = "txtRSec"
        Me.txtRSec.Size = New System.Drawing.Size(74, 20)
        Me.txtRSec.TabIndex = 54
        Me.txtRSec.Text = "0000000000"
        '
        'txtClase
        '
        Me.txtClase.Location = New System.Drawing.Point(97, 80)
        Me.txtClase.MaxLength = 10
        Me.txtClase.Name = "txtClase"
        Me.txtClase.Size = New System.Drawing.Size(199, 20)
        Me.txtClase.TabIndex = 55
        Me.txtClase.Text = "000000000000000000000000000000"
        '
        'txtEmbalaje
        '
        Me.txtEmbalaje.Location = New System.Drawing.Point(245, 53)
        Me.txtEmbalaje.MaxLength = 10
        Me.txtEmbalaje.Name = "txtEmbalaje"
        Me.txtEmbalaje.Size = New System.Drawing.Size(74, 20)
        Me.txtEmbalaje.TabIndex = 56
        Me.txtEmbalaje.Text = "0000000000"
        '
        'txtFIntervension
        '
        Me.txtFIntervension.Location = New System.Drawing.Point(126, 163)
        Me.txtFIntervension.MaxLength = 10
        Me.txtFIntervension.Name = "txtFIntervension"
        Me.txtFIntervension.Size = New System.Drawing.Size(286, 20)
        Me.txtFIntervension.TabIndex = 57
        Me.txtFIntervension.Text = "0000000000"
        '
        'txtCaracteristicas
        '
        Me.txtCaracteristicas.Location = New System.Drawing.Point(126, 135)
        Me.txtCaracteristicas.MaxLength = 10
        Me.txtCaracteristicas.Name = "txtCaracteristicas"
        Me.txtCaracteristicas.Size = New System.Drawing.Size(286, 20)
        Me.txtCaracteristicas.TabIndex = 58
        Me.txtCaracteristicas.Text = "0000000000"
        '
        'txtNUnidas
        '
        Me.txtNUnidas.Location = New System.Drawing.Point(97, 53)
        Me.txtNUnidas.MaxLength = 10
        Me.txtNUnidas.Name = "txtNUnidas"
        Me.txtNUnidas.Size = New System.Drawing.Size(74, 20)
        Me.txtNUnidas.TabIndex = 59
        Me.txtNUnidas.Text = "0000000000"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(191, 111)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(48, 13)
        Me.Label12.TabIndex = 46
        Me.Label12.Text = "RIESGO"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(52, 111)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(39, 13)
        Me.Label10.TabIndex = 47
        Me.Label10.Text = "R.SEC"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(50, 84)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(41, 13)
        Me.Label8.TabIndex = 48
        Me.Label8.Text = "CLASE"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(19, 167)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(100, 13)
        Me.Label14.TabIndex = 49
        Me.Label14.Text = "F. INTERVENSIÓN"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(177, 57)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(62, 13)
        Me.Label6.TabIndex = 50
        Me.Label6.Text = "EMBALAJE"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(13, 139)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(106, 13)
        Me.Label13.TabIndex = 51
        Me.Label13.Text = "CARACTERISTICAS"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(29, 57)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(62, 13)
        Me.Label4.TabIndex = 52
        Me.Label4.Text = "N. UNIDAS"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(31, 197)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 13)
        Me.Label3.TabIndex = 49
        Me.Label3.Text = "CARGA"
        '
        'cmbCarga
        '
        Me.cmbCarga.FormattingEnabled = True
        Me.cmbCarga.Items.AddRange(New Object() {"", "ALCALINO", "ÁCIDO", "NO INÓNICO / ALCALINO", "NEUTRO"})
        Me.cmbCarga.Location = New System.Drawing.Point(79, 193)
        Me.cmbCarga.Name = "cmbCarga"
        Me.cmbCarga.Size = New System.Drawing.Size(120, 21)
        Me.cmbCarga.TabIndex = 60
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(205, 197)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(109, 13)
        Me.Label5.TabIndex = 49
        Me.Label5.Text = "ESTADO DEL PROD"
        '
        'cmbEstado
        '
        Me.cmbEstado.FormattingEnabled = True
        Me.cmbEstado.Items.AddRange(New Object() {"", "POLVO", "LÍQUIDO", "METAL", "PASTA"})
        Me.cmbEstado.Location = New System.Drawing.Point(320, 193)
        Me.cmbEstado.Name = "cmbEstado"
        Me.cmbEstado.Size = New System.Drawing.Size(92, 21)
        Me.cmbEstado.TabIndex = 60
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(16, 227)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(59, 13)
        Me.Label7.TabIndex = 47
        Me.Label7.Text = "VIDA ÚTIL"
        '
        'txtVidaUtil
        '
        Me.txtVidaUtil.Location = New System.Drawing.Point(81, 223)
        Me.txtVidaUtil.MaxLength = 2
        Me.txtVidaUtil.Name = "txtVidaUtil"
        Me.txtVidaUtil.Size = New System.Drawing.Size(22, 20)
        Me.txtVidaUtil.TabIndex = 54
        Me.txtVidaUtil.Text = "00"
        Me.txtVidaUtil.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(109, 227)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(38, 13)
        Me.Label9.TabIndex = 47
        Me.Label9.Text = "Meses"
        '
        'btnAceptar
        '
        Me.btnAceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.Location = New System.Drawing.Point(75, 262)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(134, 48)
        Me.btnAceptar.TabIndex = 61
        Me.btnAceptar.Text = "ACEPTAR"
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(215, 262)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(134, 48)
        Me.Button2.TabIndex = 61
        Me.Button2.Text = "CANCELAR"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'ckRestriccion
        '
        Me.ckRestriccion.AutoSize = True
        Me.ckRestriccion.Location = New System.Drawing.Point(208, 225)
        Me.ckRestriccion.Name = "ckRestriccion"
        Me.ckRestriccion.Size = New System.Drawing.Size(99, 17)
        Me.ckRestriccion.TabIndex = 62
        Me.ckRestriccion.Text = "RESTRICCIÓN"
        Me.ckRestriccion.UseVisualStyleBackColor = True
        '
        'ComposicionDatosAdicionales
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(425, 322)
        Me.Controls.Add(Me.ckRestriccion)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.cmbEstado)
        Me.Controls.Add(Me.cmbCarga)
        Me.Controls.Add(Me.txtRiesgo)
        Me.Controls.Add(Me.txtVidaUtil)
        Me.Controls.Add(Me.txtRSec)
        Me.Controls.Add(Me.txtClase)
        Me.Controls.Add(Me.txtEmbalaje)
        Me.Controls.Add(Me.txtFIntervension)
        Me.Controls.Add(Me.txtCaracteristicas)
        Me.Controls.Add(Me.txtNUnidas)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ComposicionDatosAdicionales"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.panel1.ResumeLayout(False)
        Me.panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents panel1 As System.Windows.Forms.Panel
    Private WithEvents Label2 As System.Windows.Forms.Label
    Private WithEvents label1 As System.Windows.Forms.Label
    Friend WithEvents txtRiesgo As System.Windows.Forms.TextBox
    Friend WithEvents txtRSec As System.Windows.Forms.TextBox
    Friend WithEvents txtClase As System.Windows.Forms.TextBox
    Friend WithEvents txtEmbalaje As System.Windows.Forms.TextBox
    Friend WithEvents txtFIntervension As System.Windows.Forms.TextBox
    Friend WithEvents txtCaracteristicas As System.Windows.Forms.TextBox
    Friend WithEvents txtNUnidas As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbCarga As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmbEstado As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtVidaUtil As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents ckRestriccion As System.Windows.Forms.CheckBox
End Class
