Imports CrystalDecisions.Shared

Public Class ListadoPTVencidos

    Private Sub mastxtDesde_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles mastxtDesde.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                mastxtHasta.Focus()
            Case Keys.Escape
                mastxtDesde.Text = ""
        End Select
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAceptar.Click

        If (Trim(mastxtDesde.Text.Replace("-", "")) = "") Then mastxtDesde.Text = "AA-00000-000"
        If (Trim(mastxtHasta.Text.Replace("-", "")) = "") Then mastxtHasta.Text = "ZZ-99999-999"

        Dim Renglon As Integer = 0
        Dim TablaReporte As New DataTable
        Dim sqlconsulta As String

        With TablaReporte.Columns
            .Add("Codigo")
            .Add("Descripcion")
            .Add("Lote")
            .Add("Fecha")
            .Add("Cantidad")
            .Add("Planta")
            .Add("Meses")
            .Add("Revalida")
            .Add("FechaRevalida")
            .Add("MesesRevalida")
            .Add("DesEmpresa")
            .Add("QueHojaEs")
        End With

        Dim Empresas(7) As String
        Empresas(0) = "SurfactanSA"
        Empresas(1) = "surfactan_II"
        Empresas(2) = "Surfactan_III"
        Empresas(3) = "Surfactan_IV"
        Empresas(4) = "Surfactan_V"
        Empresas(5) = "Surfactan_VI"
        Empresas(6) = "Surfactan_VII"

        For i As Integer = 0 To 6
            sqlconsulta = "SELECT Hoja, Producto, Revalida, Mesesrevalida, Fecha, "
            sqlconsulta = sqlconsulta & "Fecharevalida, Saldo ,Descripcion = Terminado.Descripcion ,Vida = Terminado.Vida "
            sqlconsulta = sqlconsulta & "FROM Hoja INNER JOIN Terminado ON Terminado.Codigo = Hoja.Producto WHERE Hoja.Marca <> 'X' AND Saldo <> '0' "
            sqlconsulta = sqlconsulta & "AND Renglon = '1' AND Producto BETWEEN '" & mastxtDesde.Text.Trim() & "' "
            sqlconsulta = sqlconsulta & "AND '" & mastxtHasta.Text.Trim() & "' AND (Marcavencida = 'S' OR Marcavencida = 'V')"
            Dim tablaARecorrerH = GetAll(sqlconsulta, Empresas(i))

            If (tablaARecorrerH.Rows.Count > 0) Then
                For Row = 0 To tablaARecorrerH.Rows.Count - 1
                    Dim Fila As DataRow = TablaReporte.NewRow()
                    Fila.Item("Codigo") = tablaARecorrerH(Row).Item("Producto")
                    Fila.Item("Descripcion") = tablaARecorrerH(Row).Item("Descripcion")
                    Fila.Item("Lote") = tablaARecorrerH(Row).Item("Hoja")
                    Fila.Item("Fecha") = tablaARecorrerH(Row).Item("Fecha")
                    Fila.Item("Cantidad") = redondeo(tablaARecorrerH(Row).Item("Saldo"))
                    Fila.Item("Planta") = (i + 1).ToString().PadLeft(4, "0")
                    Fila.Item("Meses") = IIf(IsDBNull(tablaARecorrerH(Row).Item("Vida")), "0", tablaARecorrerH(Row).Item("Vida"))
                    Fila.Item("Revalida") = IIf(IsDBNull(tablaARecorrerH(Row).Item("Revalida")), "0", tablaARecorrerH(Row).Item("Revalida"))
                    Fila.Item("FechaRevalida") = IIf(IsDBNull(tablaARecorrerH(Row).Item("FechaRevalida")), "  /  /    ", tablaARecorrerH(Row).Item("FechaRevalida"))
                    Fila.Item("MesesRevalida") = IIf(IsDBNull(tablaARecorrerH(Row).Item("MesesRevalida")), "0", tablaARecorrerH(Row).Item("MesesRevalida"))
                    Fila.Item("DesEmpresa") = Empresas(i)
                    Fila.Item("QueHojaEs") = "H"

                    TablaReporte.Rows.Add(Fila)

                    Renglon = Renglon + 1
                Next
            End If
        Next

        For i As Integer = 0 To 6

            sqlconsulta = "SELECT Guia.Codigo, Saldo, Lote, Terminado, Descripcion = Terminado.Descripcion, Vida = Terminado.Vida "
            sqlconsulta = sqlconsulta & "FROM Guia INNER JOIN Terminado ON Terminado.Codigo = Guia.Terminado "
            sqlconsulta = sqlconsulta & "WHERE Guia.Marca <> 'X' AND Saldo <> '0' AND Tipo = 'T' AND Movi = 'E' "
            sqlconsulta = sqlconsulta & "AND Terminado >= '" & mastxtDesde.Text.Trim() & "' "
            sqlconsulta = sqlconsulta & "AND Terminado <= '" & mastxtHasta.Text.Trim() & "' "
            sqlconsulta = sqlconsulta & "AND (MarcaVencida = 'S' OR MarcaVencida = 'V')"

            Dim tablaARecorrerG As DataTable = GetAll(sqlconsulta, Empresas(i))

            For Row = 0 To tablaARecorrerG.Rows.Count - 1
                Dim Fila As DataRow = TablaReporte.NewRow()

                Fila.Item("Codigo") = tablaARecorrerG(Row).Item("Terminado")
                Fila.Item("Descripcion") = tablaARecorrerG(Row).Item("Descripcion")
                Fila.Item("Lote") = tablaARecorrerG(Row).Item("Lote")
                Fila.Item("Cantidad") = redondeo(tablaARecorrerG(Row).Item("Saldo"))
                Fila.Item("Planta") = (i + 1).ToString().PadLeft(4, "0")
                Fila.Item("Meses") = IIf(IsDBNull(tablaARecorrerG(Row).Item("Vida")), "0", tablaARecorrerG(Row).Item("Vida"))
                Fila.Item("DesEmpresa") = Empresas(i)
                Fila.Item("QueHojaEs") = "G"

                TablaReporte.Rows.Add(Fila)

                Renglon = Renglon + 1
            Next
        Next

        For i As Integer = 0 To Renglon - 1
            If (TablaReporte.Rows(i).Item("QueHojaEs") = "G") Then
                For j As Integer = 0 To 6
                    sqlconsulta = "SELECT Fecha, Revalida, FechaRevalida, MesesRevalida "
                    sqlconsulta = sqlconsulta & "FROM HOJA WHERE '" & TablaReporte.Rows(i).Item("Lote") & "'= Hoja "
                    sqlconsulta = sqlconsulta & "AND '" & TablaReporte.Rows(i).Item("Codigo") & "' = Producto"

                    Dim row As DataRow = GetSingle(sqlconsulta, Empresas(j))

                    If (row IsNot Nothing) Then
                        TablaReporte.Rows(i).Item("Fecha") = IIf(IsDBNull(row.Item("Fecha")), "  /  /    ", row.Item("Fecha"))
                        TablaReporte.Rows(i).Item("Revalida") = IIf(IsDBNull(row.Item("Revalida")), "0", row.Item("Revalida"))
                        TablaReporte.Rows(i).Item("FechaRevalida") = IIf(IsDBNull(row.Item("FechaRevalida")), "  /  /    ", row.Item("FechaRevalida"))
                        TablaReporte.Rows(i).Item("MesesRevalida") = IIf(IsDBNull(row.Item("MesesRevalida")), "0", row.Item("MesesRevalida"))
                    End If

                Next
            End If
        Next


        With New VistaPrevia
            .Reporte = New ReporteListaPTVencidos()
            .Reporte.SetDataSource(TablaReporte)
            If (rabPantalla.Checked = True) Then
                .Mostrar()
            Else
                If (rabImprimir.Checked = True) Then
                    .Imprimir()
                Else
                    .Exportar("", ExportFormatType.Excel, "")
                End If
            End If
        End With


    End Sub

    Private Sub mastxtHasta_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles mastxtHasta.KeyDown
        Select Case e.KeyData
            Case Keys.Escape
                mastxtHasta.Text = ""
        End Select
    End Sub

    Private Sub ListadoPTVencidos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        mastxtDesde.Text = ""
        mastxtHasta.Text = ""
    End Sub

    Private Sub ListadoPTVencidos_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        mastxtDesde.Focus()
    End Sub
End Class