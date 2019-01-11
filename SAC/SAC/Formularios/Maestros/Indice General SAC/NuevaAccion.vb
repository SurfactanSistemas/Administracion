Public Class NuevaAccion

    Private WTipo As Object
    Private WAnio As Object
    Private WNumero As Object
    Private WNroAccion As Object

    Sub New(ByVal _Tipo As Object, ByVal _Anio As Object, ByVal _Numero As Object, ByVal _NroAccion As Object)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        WTipo = _Tipo
        WAnio = _Anio
        WNumero = _Numero
        WNroAccion = _NroAccion

        '
        ' Chequemos si es un campo del registro Viejo.
        '

        If Val(WNroAccion) <= 12 Then ' Nuevo Juego de Registros.

            Dim WAccion As DataRow = GetSingle(String.Format("SELECT Accion = LTRIM(RTRIM(cs2.Accion{0}1)) + ' ' + LTRIM(RTRIM(cs2.Accion{0}2)), cs2.Responsable{0} As Responsable, cs2.Plazo{0} As Plazo, LTRIM(RTRIM(rs.Descripcion)) As DescResponsable FROM CargaSacII cs2 LEFT OUTER JOIN ResponsableSac rs ON rs.Codigo = cs2.Responsable{0} WHERE cs2.Tipo = '{1}' And cs2.Numero = '{2}' And cs2.Ano = '{3}'", WNroAccion, WTipo, WNumero, WAnio))

            If Not IsNothing(WAccion) Then
                With WAccion
                    txtResponsable.Text = OrDefault(.Item("Responsable"), "")
                    lblDescResponsable.Text = OrDefault(.Item("DescResponsable"), "")
                    txtPlazo.Text = OrDefault(.Item("Plazo"), "")
                    txtAccionCorrectiva.Text = OrDefault(.Item("Accion"), "")
                End With
            End If
        Else

            Close()

        End If

        For Each t As Control In {txtResponsable, txtPlazo, txtAccionCorrectiva, lblDescResponsable}
            t.Text = t.Text.Trim
        Next

        lblRestantes.Text = String.Format("Caracteres Restantes: {0}/120", 120 - txtAccionCorrectiva.Text.Length)

    End Sub

    Private Sub Button3_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCerrar.Click
        Close()
    End Sub

    Private Sub txtAccionCorrectiva_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtAccionCorrectiva.KeyUp
        lblRestantes.Text = String.Format("Caracteres Restantes: {0}/120", 120 - txtAccionCorrectiva.Text.Length)
    End Sub

    Private Sub NuevaAccion_Shown(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Shown
        txtResponsable.Focus()
    End Sub

    Private Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnGrabar.Click

        '
        ' Actualizamos Segun sea tabla vieja o no.
        '
        txtAccionCorrectiva.Text = txtAccionCorrectiva.Text.PadRight(120, " ")

        Dim WAccionI = txtAccionCorrectiva.Text.Substring(0, 60)
        Dim WAccionII = txtAccionCorrectiva.Text.Substring(60, 60)

        Dim ZSql As String = String.Format("UPDATE CargaSacII SET Responsable{0} = '{1}', Plazo{0} = '{2}', Accion{0}1 = '{3}', Accion{0}2 = '{4}' WHERE Tipo = '{5}' and Ano = '{6}' And Numero = '{7}'",
                                            WNroAccion, txtResponsable.Text, txtPlazo.Text, WAccionI, WAccionII, WTipo, WAnio, WNumero)

        ExecuteNonQueries(ZSql)


        Dim WWOwner = CType(Owner, INuevaAccion)

        If Not IsNothing(WWOwner) Then
            WWOwner._ProcesarNuevaAccion()
        End If

        Close()

    End Sub

    Private Sub txtResponsable_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtResponsable.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txtResponsable.Text) = "" Then : Exit Sub : End If

            lblDescResponsable.Text = ""

            Dim WResp As DataRow = GetSingle("SELECT Descripcion FROM ResponsableSac WHERE Codigo = '" & txtResponsable.Text & "'")

            If Not IsNothing(WResp) Then
                lblDescResponsable.Text = OrDefault(WResp.Item("Descripcion"), "")

                txtPlazo.Focus()

            End If

        ElseIf e.KeyData = Keys.Escape Then
            txtResponsable.Text = ""
        End If

    End Sub

    Private Sub txtPlazo_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtPlazo.KeyDown

        If e.KeyData = Keys.Enter Then
            If txtPlazo.Text.Replace(" ", "").Replace("/", "").Length = 8 Then
                If Not _ValidarFecha(txtPlazo.Text) Then Exit Sub
            End If

            txtAccionCorrectiva.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtPlazo.Text = ""
        End If

    End Sub

    Private Sub Button2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnEliminar.Click

        Dim WResp = txtResponsable.Text
        Dim WPlazo = txtPlazo.Text
        Dim WAccion = txtAccionCorrectiva.Text

        Try
            txtResponsable.Text = ""
            txtPlazo.Text = ""
            txtAccionCorrectiva.Text = ""

            btnGrabar.PerformClick()

        Catch ex As Exception

            txtResponsable.Text = WResp
            txtPlazo.Text = WPlazo
            txtAccionCorrectiva.Text = WAccion

            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
End Class