Public Class ConsDeEspefXVersion

    Private Sub mastxtCodigo_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles mastxtCodigo.KeyDown
        Select Case e.KeyData
            Case Keys.Enter

                txtDescTerminado.Text = ""

                Dim wter As DataRow = GetSingle("SELECT Descripcion FROM Terminado WHERE Codigo = '" & mastxtCodigo.Text & "'")

                If wter IsNot Nothing Then
                    txtDescTerminado.Text = Trim(UCase(wter.Item("Descripcion")))
                Else
                    Exit Sub
                End If

                txtVersion.Focus()
            Case Keys.Escape
                mastxtCodigo.Text = ""
        End Select
    End Sub

    Private Sub SoloNumero(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles txtVersion.KeyPress
        If Not Char.IsNumber(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtVersion_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtVersion.KeyDown
        Select Case e.KeyData
            Case Keys.Escape
                txtVersion.Text = ""
            Case Keys.Enter
                Try
                    If (mastxtCodigo.Text.Replace("-", "").Trim() <> "") Then

                        _LimpiarGrilla()

                        Dim VersionMax = _BuscarVersionMax()
                        If txtVersion.Text > VersionMax Then
                            txtVersion.Text = VersionMax
                        End If

                        If DebeMOstrar(txtVersion.Text) Then

                            Dim SQLConsulta As String

                            SQLConsulta = "SELECT * FROM EspecifUnificaVersion WHERE Producto = '" & mastxtCodigo.Text.Trim() & "'"
                            SQLConsulta = SQLConsulta & "AND Version = '" & txtVersion.Text.Trim() & "'"

                            Dim tabla As DataRow = GetSingle(SQLConsulta, "Surfactan_II")

                            If tabla IsNot Nothing Then

                                For i As Integer = 1 To 10
                                    If Val(OrDefault(tabla.Item("Ensayo" & i), "")) <> 0 Then DGV_ConsultaVersiones.Rows.Item(i - 1).Cells("Ensayo").Value = OrDefault(tabla.Item("Ensayo" & i), "")
                                    DGV_ConsultaVersiones.Rows.Item(i - 1).Cells("ValorEstandar").Value = tabla.Item("Valor" & i) & OrDefault(tabla.Item("Valor" & i & i), "")
                                    DGV_ConsultaVersiones.Rows.Item(i - 1).Cells("Desde").Value = tabla.Item("Desde" & i)
                                    DGV_ConsultaVersiones.Rows.Item(i - 1).Cells("Hasta").Value = tabla.Item("Hasta" & i)
                                Next

                                txtFechaDesde.Text = tabla.Item("FechaInicio")
                                txtFechaHasta.Text = tabla.Item("FechaFinal")
                                txtControlDeCambios.Text = OrDefault(tabla.Item("ControlCambio"), "")

                            End If

                            CargarDescripciones()

                        Else
                            For i As Integer = 1 To 10
                                DGV_ConsultaVersiones.Rows.Item(i - 1).Cells("Ensayo").Value = ""
                                DGV_ConsultaVersiones.Rows.Item(i - 1).Cells("Descripcion").Value = ""
                                DGV_ConsultaVersiones.Rows.Item(i - 1).Cells("ValorEstandar").Value = ""
                                DGV_ConsultaVersiones.Rows.Item(i - 1).Cells("Desde").Value = ""
                                DGV_ConsultaVersiones.Rows.Item(i - 1).Cells("Hasta").Value = ""
                            Next
                            txtFechaDesde.Text = ""
                            txtFechaHasta.Text = ""
                            txtControlDeCambios.Text = ""

                        End If
                    End If
                Catch ex As Exception

                End Try

        End Select
    End Sub

    Private Sub CargarDescripciones()

        For Each row As DataGridViewRow In DGV_ConsultaVersiones.Rows
            With row

                Dim e As Integer = Val(OrDefault(row.Cells("Ensayo").Value, ""))

                If e = 0 Then Continue For

                Dim WEnsayo As DataRow = GetSingle("SELECT Descripcion FROM Ensayos WHERE Codigo = '" & e & "'")

                If WEnsayo IsNot Nothing Then row.Cells("Descripcion").Value = Trim(OrDefault(WEnsayo.Item("Descripcion"), ""))

            End With
        Next

    End Sub

    Private Function DebeMOstrar(ByVal Version As Integer) As Boolean

        Dim SQLConsulta As String

        Version = Version + 1

        SQLConsulta = "SELECT Version FROM EspecifUnificaVersion WHERE Producto = '" & mastxtCodigo.Text.Trim() & "'"
        SQLConsulta = SQLConsulta & " AND Version = '" & Version & "'"

        Dim tabla As DataRow = GetSingle(SQLConsulta, "Surfactan_II")

        Return tabla IsNot Nothing

    End Function

    Private Sub btnSiguienteVersion_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSiguienteVersion.Click

        If mastxtCodigo.Text.Replace(" ", "").Length = 12 Then
            txtVersion.Text = Val(txtVersion.Text) + 1
            txtVersion_KeyDown(Nothing, New KeyEventArgs(Keys.Enter))
        End If

    End Sub

    Private Sub btnAnteriorVersion_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAnteriorVersion.Click

        If mastxtCodigo.Text.Replace(" ", "").Length = 12 AndAlso Val(txtVersion.Text) > 1 Then
            txtVersion.Text = txtVersion.Text - 1
            txtVersion_KeyDown(Nothing, New KeyEventArgs(Keys.Enter))
        End If

    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnLimpiar.Click
        txtDescTerminado.Text = ""
        mastxtCodigo.Text = ""
        txtVersion.Text = ""

        _LimpiarGrilla()

        txtFechaDesde.Text = ""
        txtFechaHasta.Text = ""
        txtControlDeCambios.Text = ""

        mastxtCodigo.Focus()

    End Sub

    Private Sub _LimpiarGrilla()

        With DGV_ConsultaVersiones
            .Rows.Clear()

            For i As Short = 1 To 10 : DGV_ConsultaVersiones.Rows.Add("", "", "", "", "") : Next

        End With

    End Sub

    Private Sub btnImprimir_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnImprimir.Click
        Dim tablaReporte As New DataTable
        With tablaReporte.Columns
            .Add("Codigo")
            .Add("DescripcionPT")
            .Add("Version")
            .Add("FechaDesde")
            .Add("FechaHasta")
            .Add("Ensayo")
            .Add("Descripcion")
            .Add("Valor")
        End With
        For i As Integer = 0 To 9
            tablaReporte.Rows.Add()
            tablaReporte.Rows(i).Item("Codigo") = mastxtCodigo.Text.Trim()
            tablaReporte.Rows(i).Item("Version") = txtVersion.Text.Trim()
            tablaReporte.Rows(i).Item("FechaDesde") = txtFechaDesde.Text.Trim()
            tablaReporte.Rows(i).Item("FechaHasta") = txtFechaHasta.Text.Trim()

            tablaReporte.Rows(i).Item("Ensayo") = DGV_ConsultaVersiones.Rows.Item(i).Cells("Ensayo").Value
            tablaReporte.Rows(i).Item("Descripcion") = DGV_ConsultaVersiones.Rows.Item(i).Cells("Descripcion").Value
            tablaReporte.Rows(i).Item("Valor") = DGV_ConsultaVersiones.Rows.Item(i).Cells("ValorEstandar").Value
        Next
        Try

            Dim SQLConsulta As String

            SQLConsulta = "SELECT Descripcion FROM Terminado WHERE Codigo = '" & mastxtCodigo.Text.Trim() & "'"

            Dim tabla As New DataTable
            tabla = GetAll(SQLConsulta, "Surfactan_II")
            If (tabla.Rows.Count > 0) Then
                For i As Integer = 0 To 9
                    tablaReporte.Rows(i).Item("DescripcionPT") = tabla.Rows(0).Item("Descripcion")
                Next

            End If
        Catch ex As Exception

        End Try

        With New VistaPrevia
            .Reporte = New ReporteEspecifXVersion()
            .Reporte.SetDataSource(tablaReporte)
            .Imprimir()
        End With

    End Sub

    Private Function _BuscarVersionMax() As Integer
        Dim SQLCnslt As String

        SQLCnslt = "SELECT VersionMax = MAX(Version) FROM EspecifUnificaVersion WHERE Producto = '" & mastxtCodigo.Text.Trim() & "'"

        Dim row As DataRow = GetSingle(SQLCnslt, "Surfactan_II")

        If row IsNot Nothing Then Return row.Item("VersionMax")

        Return 0

    End Function

    Private Sub btnVolver_Click(sender As Object, e As EventArgs) Handles btnVolver.Click
        Close()
    End Sub

    Private Sub ConsDeEspefXVersion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        mastxtCodigo.Text = ""
    End Sub

    Private Sub ConsDeEspefXVersion_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        mastxtCodigo.Focus()
    End Sub
End Class