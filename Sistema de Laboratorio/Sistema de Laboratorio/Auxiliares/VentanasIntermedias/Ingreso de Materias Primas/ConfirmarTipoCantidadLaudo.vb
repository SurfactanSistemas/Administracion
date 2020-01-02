Public Class ConfirmarTipoCantidadLaudo

    Sub New(ByVal EstadoMP As TiposEstadoLaudoMP)

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        txtLaudo.Text = Entidades.MatPrima._TraerProximaNumeracion(EstadoMP)

        rbAprobado.Checked = EstadoMP = TiposEstadoLaudoMP.Aprobado
        rbPorDesvio.Checked = EstadoMP = TiposEstadoLaudoMP.AprobadoPorDesvio
        rbRechazado.Checked = EstadoMP = TiposEstadoLaudoMP.Rechazado

    End Sub

    Private Sub RadioButton3_Click(sender As Object, e As EventArgs) Handles rbRechazado.Click, rbPorDesvio.Click, rbAprobado.Click
        Dim fnt As Font = TryCast(sender, RadioButton).Font

        With fnt
            Dim fontStyle As FontStyle = IIf(TryCast(sender, RadioButton).Checked, fontStyle.Bold, fontStyle.Regular)

            TryCast(sender, RadioButton).Font = New Font(.Name, .Size, fontStyle)
        End With

        If rbAprobado.Checked then txtLaudo.Text = Entidades.MatPrima._TraerProximaNumeracion(TiposEstadoLaudoMP.Aprobado)
        If rbPorDesvio.Checked Then txtLaudo.Text = Entidades.MatPrima._TraerProximaNumeracion(TiposEstadoLaudoMP.AprobadoPorDesvio)
        If rbRechazado.Checked Then txtLaudo.Text = Entidades.MatPrima._TraerProximaNumeracion(TiposEstadoLaudoMP.Rechazado)

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Close()
    End Sub

    Private Sub btnConfirmar_Click(sender As Object, e As EventArgs) Handles btnConfirmar.Click
        If Val(txtLaudo.Text) = 0 Then Exit Sub
        If Val(txtCantidad.Text) = 0 Then Exit Sub

        DialogResult = Windows.Forms.DialogResult.OK

        Close()
    End Sub

    Private Sub SoloNumero(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtLaudo.KeyPress
        If Not Char.IsNumber(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub NumerosConComas(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCantidad.KeyPress
        If Not Char.IsNumber(e.KeyChar) And Not Char.IsControl(e.KeyChar) And Not (CChar(".")) = e.KeyChar Then
            e.Handled = True
        End If
    End Sub
    
    Private Sub txtLaudo_KeyDown(sender As Object, e As KeyEventArgs) Handles txtLaudo.KeyDown

        If e.KeyData = Keys.Enter Then
            If Val(txtLaudo.Text) <= 0 Then : Exit Sub : End If

            txtCantidad.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtLaudo.Text = ""
        End If

    End Sub

    Private Sub txtCantidad_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCantidad.KeyDown

        If e.KeyData = Keys.Enter Then
            If Val(txtCantidad.Text) <= 0 Then : Exit Sub : End If

            txtLaudo.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtCantidad.Text = ""
        End If

    End Sub

    Private Sub ConfirmarTipoCantidadLaudo_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        txtCantidad.Focus()
    End Sub
End Class