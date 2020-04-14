Public Class ListadoEspecifPTFecha

    Private Sub btnVolver_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnVolver.Click
        Close()
    End Sub

    Private Sub mastxtFechaDesde_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles mastxtFechaDesde.KeyDown
        If (Trim(mastxtFechaDesde.Text.Replace("/", "")) <> "") Then
            Select Case e.KeyData
                Case Keys.Enter
                    If (IsDate(mastxtFechaDesde.Text)) Then
                        mastxtFechaHasta.Focus()
                    Else
                        MsgBox("No es una fecha valida")
                    End If
                Case Keys.Escape
                    mastxtFechaDesde.Text = ""

            End Select
        End If
    End Sub

    Private Sub mastxtFechaHasta_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles mastxtFechaHasta.KeyDown
        If (Trim(mastxtFechaHasta.Text.Replace("/", "")) <> "") Then
            Select Case e.KeyData
                Case Keys.Enter
                    If (IsDate(mastxtFechaHasta.Text)) Then
                        mastxtDePT.Focus()
                    Else
                        MsgBox("No es una fecha valida")
                    End If
                Case Keys.Escape
                    mastxtFechaHasta.Text = ""


            End Select
        End If
    End Sub

    Private Sub mastxtDePT_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles mastxtDePT.KeyDown
        If (Trim(mastxtDePT.Text.Replace("-", "")) <> "") Then
            Select Case e.KeyData
                Case Keys.Enter
                    mastxtAPT.Focus()

                Case Keys.Escape
                    mastxtDePT.Text = ""
            End Select
        End If
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAceptar.Click

        If Val(ordenaFecha(mastxtFechaDesde.Text)) = 0 OrElse Val(ordenaFecha(mastxtFechaHasta.Text)) = 0 Then
            MsgBox("Debe ingresar un rango de Fechas válidas.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        If Trim(mastxtDePT.Text.Replace("-", "")) = "" Then mastxtDePT.Text = "AA-00000-000"

        If Trim(mastxtAPT.Text.Replace("-", "")) = "" Then mastxtAPT.Text = "ZZ-99999-999"

        Dim FechaDesde As String = ordenaFecha(mastxtFechaDesde.Text.Trim())
        Dim FechaHasta As String = ordenaFecha(mastxtFechaHasta.Text.Trim())

        Dim sqlconsulta As String = "SELECT e.Producto, t.Descripcion, e.Fecha, e.Version FROM EspecifUnifica e INNER JOIN Terminado t ON t.Codigo = e.Producto where RIGHT(e.fecha, 4) + '' + SUBSTRING(e.Fecha, 4, 2) + left(e.Fecha, 2) between '" & FechaDesde & "' and '" & FechaHasta & "' and e.Producto between '" & mastxtDePT.Text.Trim() & "' and '" & mastxtAPT.Text.Trim() & "' "

        Dim datos As DataTable = GetAll(sqlconsulta, "Surfactan_II")
        With datos.Columns
            .Add("Titulo")
            .Add("Descripcion")
        End With

        For Each row As DataRow In datos.Rows
            row.Item("Titulo") = "DE " & mastxtFechaDesde.Text & " A " & mastxtFechaHasta.Text
        Next

        With New VistaPrevia
            .Reporte = New ReporteListadoEspecifPTaFecha()
            .Reporte.SetDataSource(datos)

            If (rabPantalla.Checked = True) Then
                .Mostrar()
            Else
                .Imprimir()
            End If
        End With

    End Sub

    Private Sub mastxtAPT_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles mastxtAPT.KeyDown
        Select Case e.KeyData
            Case Keys.Escape
                mastxtAPT.Text = ""
        End Select
    End Sub

    Private Sub ListadoEspecifPTFecha_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Text = ""
    End Sub
End Class