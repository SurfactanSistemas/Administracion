Public Class ListadoEspecificacionesMPAFecha

    Private Sub txtDesdeMes_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtHastaMP.KeyDown, txtHastaMes.KeyDown, txtDesdeMP.KeyDown, txtDesdeMes.KeyDown
        Dim WControl As MaskedTextBox = TryCast(sender, MaskedTextBox)

        If e.KeyData = Keys.Enter Then

            Dim WDestino As Control = Nothing

            Select Case WControl.Name.Replace("txt", "")

                Case "DesdeMes"
                    If Val(WControl.Text) = 0 Then WControl.Text = "1"
                    WControl.Text = Val(WControl.Text)
                    WDestino = txtHastaMes
                Case "HastaMes"
                    If Val(WControl.Text) = 0 Then WControl.Text = "12"
                    WControl.Text = Val(WControl.Text)
                    WDestino = txtDesdeMP
                Case "DesdeMP"
                    If WControl.Text.Replace(" ", "").Length = 2 Then WControl.Text = "AA-000-000"
                    If WControl.Text.Replace(" ", "").Length < 10 Then Exit Sub
                    WDestino = txtHastaMP
                Case "HastaMP"
                    If WControl.Text.Replace(" ", "").Length = 2 Then WControl.Text = "ZZ-999-999"
                    If WControl.Text.Replace(" ", "").Length < 10 Then Exit Sub
                    WDestino = txtDesdeMes

            End Select

            If WDestino IsNot Nothing Then WDestino.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            If WControl IsNot Nothing Then WControl.Text = ""
        End If

    End Sub

    Private Sub ListadoEspecificacionesMPAFecha_Shown(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Shown
        txtDesdeMes.Focus()
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCerrar.Click
        Close()
    End Sub

    Private Sub ListadoEspecificacionesMPAFecha_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        txtHastaMes.Text = Date.Now.Month
        With ProgressBar1
            .Value = 0
            .Visible = False
        End With

    End Sub

    Private Sub btnAceptar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAceptar.Click

        Dim WSqls As New List(Of String)

        WSqls.Add("UPDATE EspecificacionesUnifica SET DesEmpresa = '', Titulo = '', Marca = ''")

        Dim WEmpresa, WTitulo, WBase As String

        WBase = IIf(_EsPellital, "Pelitall_II", "Surfactan_II")
        WEmpresa = IIf(_EsPellital, "Pellital S.A.", "Surfactan S.A.")
        WTitulo = String.Format("de {0} a {1} Meses", txtDesdeMes.Ceros(2), txtHastaMes.Ceros(2))

        WSqls.Add(String.Format("UPDATE EspecificacionesUnifica SET DesEmpresa = '{0}', Titulo = '{1}', Marca = 'S' WHERE (right(Fecha, 4) + '' + SUBSTRING(Fecha,4,2)) BETWEEN '{2}{3}' AND  '{2}{4}'", WEmpresa, WTitulo, Date.Now.ToString("yyyy"), txtDesdeMes.Ceros(2), txtHastaMes.Ceros(2)))

        ExecuteNonQueries(WBase, WSqls.ToArray)

        With New VistaPrevia()
            .Reporte = New ReporteListadoEspecificacionesMPAFecha
            .Formula = "{EspecificacionesUnifica.Marca} = 'S'"
            .Base = WBase
            .Mostrar()
        End With

    End Sub
End Class