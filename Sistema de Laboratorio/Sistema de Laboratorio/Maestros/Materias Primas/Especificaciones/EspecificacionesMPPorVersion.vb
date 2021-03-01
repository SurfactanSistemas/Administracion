Imports Util
Imports Util.Interfaces
Imports Laboratorio.Entidades

Public Class EspecificacionesMPPorVersion : Implements IAyudaMPs

    Private Sub EspecificacionesMPPorVersion_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        btnLimpiar.PerformClick()
    End Sub

    Private Sub SoloNumero(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles txtVersion.KeyPress
        If Not Char.IsNumber(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnLimpiar.Click

        For Each c As Control In {txtCodigo, txtControlCambios, txtFinal, txtInicio, txtVersion, lblDescMP, lblClasificacion}
            c.Text = ""
        Next

        dgvEnsayos.Rows.Clear()

        txtCodigo.Focus()

    End Sub

    Private Sub btnCerrar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCerrar.Click
        Close()
    End Sub

    Private Sub btnConsulta_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnConsulta.Click
        With New AyudaMPs
            .Show(Me)
        End With
    End Sub

    Public Sub _ProcesarAyudaMPs(ByVal Codigo As String, ByVal Descripcion As String) Implements IAyudaMPs._ProcesarAyudaMPs
        btnLimpiar_Click(Nothing, Nothing)
        txtCodigo.Text = Codigo
        txtCodigo_KeyDown(Nothing, New KeyEventArgs(Keys.Enter))
    End Sub

    Private Sub txtCodigo_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtCodigo.KeyDown

        If e.KeyData = Keys.Enter Then
            If txtCodigo.Text.Replace(" ", "").Length < 10 Then : Exit Sub : End If

            Dim WArt As DataRow = MatPrima.Info(txtCodigo.Text, {"Codigo", "Descripcion", "ClasificacionFarma"})

            btnLimpiar_Click(Nothing, Nothing)

            If WArt Is Nothing Then Exit Sub

            With WArt

                Dim WCodigo As String = UCase(Trim(OrDefault(.Item("Codigo"), "")))
                Dim WDescripcion As String = UCase(Trim(OrDefault(.Item("Descripcion"), "")))
                Dim WClasificacion As Char = Trim(OrDefault(.Item("ClasificacionFarma"), ""))

                txtCodigo.Text = WCodigo
                lblDescMP.Text = WDescripcion
                lblClasificacion.Text = MatPrima.DescripcionClasificacion(WClasificacion)

            End With

            txtVersion.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtCodigo.Text = ""
        End If

    End Sub

    Private Sub EspecificacionesMPPorVersion_Shown(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Shown
        txtCodigo.Focus()
    End Sub

    Private Sub txtVersion_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtVersion.KeyDown

        If e.KeyData = Keys.Enter Then
            If Val(txtVersion.Text) = 0 Then : Exit Sub : End If

            Dim WEspecificacionesUnificaVersion As DataRow = EspecificacionesMP.PorVersion(txtCodigo.Text, txtVersion.Text)

            _AsignarValoresAGrilla(WEspecificacionesUnificaVersion)

        ElseIf e.KeyData = Keys.Escape Then
            txtVersion.Text = ""
        End If

    End Sub

    Private Sub _AsignarValoresAGrilla(ByVal WEspecificacionesUnificaVersion As DataRow)

        dgvEnsayos.Rows.Clear()

        If WEspecificacionesUnificaVersion Is Nothing Then Exit Sub

        With WEspecificacionesUnificaVersion

            For i = 1 To 30

                Dim WEnsayo As String = OrDefault(.Item("Ensayo" & i), "")

                If Val(WEnsayo) <> 0 Then

                    Dim WDescripcion As String = Trim(OrDefault(.Item("Descripcion" & i), ""))
                    Dim WValor As String = Trim(OrDefault(.Item("Valor" & i), ""))

                    dgvEnsayos.Rows.Add(WEnsayo, WDescripcion, WValor)

                End If

            Next

            txtInicio.Text = OrDefault(.Item("FechaInicio"), "")
            txtFinal.Text = OrDefault(.Item("FechaFinal"), "")
            txtControlCambios.Text = Trim(OrDefault(.Item("ControlCambio"), ""))

        End With

    End Sub

    Private Sub btnAntVersion_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAntVersion.Click
        If Val(txtVersion.Text) <= 1 Then Exit Sub

        txtVersion.Text = Val(txtVersion.Text) - 1

        txtVersion_KeyDown(Nothing, New KeyEventArgs(Keys.Enter))

    End Sub

    Private Sub btnSigVersion_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSigVersion.Click

        If EspecificacionesMP.ExisteVersion(txtCodigo.Text, Val(txtVersion.Text) + 1) Then

            txtVersion.Text = Val(txtVersion.Text) + 1

        End If

        txtVersion_KeyDown(Nothing, New KeyEventArgs(Keys.Enter))

    End Sub

    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
        Try
            EspecificacionesMP.MostrarVersionPorPantalla(txtCodigo.Text, txtVersion.Text)
        Catch ex As Exception

        End Try


    End Sub

End Class