Namespace Entidades
    Public Class EspecificacionesMP

        Public Shared Function ExisteVersion(ByVal Codigo As String, ByVal Version As Byte) As Boolean

            Dim WBase As String = IIf(_EsPellital, "Pelitall_II", "Surfactan_II")

            Return GetSingle(String.Format("SELECT Producto FROM EspecificacionesUnificaVersion WHERE Producto = '{0}' And Version = '{1}'", Codigo, Version), WBase) IsNot Nothing

        End Function

        Public Shared Function PorVersion(ByVal Codigo As String, ByVal Version As Byte) As DataRow
            Dim WBase As String = IIf(_EsPellital, "Pelitall_II", "Surfactan_II")
            Dim WColumnas As String = ColumnasConsultaEspecificacionPorVersion()
            Dim WEspecificacion As DataTable = PrepararTablaEspecificaciones()

            Dim Wvalores As DataRow = GetSingle(String.Format("SELECT {0} FROM EspecificacionesUnificaVersion e LEFT OUTER JOIN EspecificacionesUnificaVersionII e2 ON e2.Producto = e.Producto And e2.Version = e.Version WHERE e.Producto = '{1}' And e.Version = '{2}'", WColumnas, Codigo, Version), WBase)

            If Wvalores IsNot Nothing Then

                WEspecificacion.ImportRow(Wvalores)

                Dim row As DataRow = WEspecificacion.Rows(0)

                row = _CompletarDescripcionesEnsayos(row)

                Return row

            End If

            Return Nothing
        End Function

        Public Shared Sub MostrarVersionPorPantalla(ByVal Codigo As String, ByVal Version As Byte)
            Dim WBase As String = IIf(_EsPellital, "Pelitall_II", "Surfactan_II")
            Dim WDatos As DataRow = PorVersion(Codigo, Version)

            If WDatos Is Nothing Then Exit Sub

            Dim WArt As DataRow = MatPrima.Info(Codigo, {"Descripcion"})

            Dim WDescripcion As String = ""

            If WArt IsNot Nothing Then WDescripcion = Trim(OrDefault(WArt.Item("Descripcion"), ""))

            Dim WColumnas As String = ""
            Dim WValores As String = ""

            With WDatos
                For i = 1 To 10
                    WColumnas &= "Codigo" & i & ","
                    WValores &= "'" & .Item("Ensayo" & i) & "',"

                    WColumnas &= "Descri" & i & ","
                    WValores &= "'" & .Item("Descripcion" & i) & "',"

                    WColumnas &= "Valor" & i & ","
                    WValores &= "'" & .Item("Valor" & i) & "',"

                    WColumnas &= "Codigo" & i + 10 & ","
                    WValores &= "'" & .Item("Ensayo" & i + 10) & "',"

                    WColumnas &= "Descri" & i + 10 & ","
                    WValores &= "'" & .Item("Descripcion" & i + 10) & "',"

                    WColumnas &= "ZValor" & i & ","
                    WValores &= "'" & .Item("Valor" & i + 10) & "',"

                    WColumnas &= "Codigo" & i + 20 & ","
                    WValores &= "'" & .Item("Ensayo" & i + 20) & "',"

                    WColumnas &= "Descri" & i + 20 & ","
                    WValores &= "'" & .Item("Descripcion" & i + 20) & "',"

                    WColumnas &= "ZValor1" & i + 20 & ","
                    WValores &= "'" & .Item("Valor" & i + 20) & "',"
                Next

                WColumnas = WColumnas.TrimEnd(",")
                WValores = WValores.TrimEnd(",")

                Dim WSql As String = String.Format("INSERT INTO ListaEspe (Codigo, Version, Responsable, Fecha, {0}, Descripcion) VALUES ('{1}', '{2}', '{3}', '{4}', {5}, '{6}')", WColumnas, Codigo, .Item("Version"), .Item("FechaInicio"), .Item("FechaFinal"), WValores, WDescripcion)

                ExecuteNonQueries(WBase, {"DELETE FROM ListaEspe", WSql})

                With New VistaPrevia()
                    .Base = WBase
                    .Reporte = IIf(_EsPellital, New ReporteEspecificacionVersionPellital, New ReporteEspecificacionVersion)
                    .Mostrar()
                End With

            End With

        End Sub

        Private Shared Function _CompletarDescripcionesEnsayos(ByVal row As DataRow) As DataRow

            For i = 1 To 30
                Dim Ens As Integer = OrDefault(row.Item("Ensayo" & i), 0)
                If Ens <> 0 Then row.Item("Descripcion" & i) = Ensayo.TraerDescripcion(Ens)
            Next

            Return row

        End Function

        Private Shared Function ColumnasConsultaEspecificacionPorVersion() As String
            Dim WColumnas As String = "e.Producto, e.Version, e.FechaInicio, e.FechaFinal, e.ControlCambio, "

            For i = 1 To 10
                WColumnas &= String.Format("e.Ensayo{0}, e.Valor{0}, e.Ensayo{1}, e.ZValor{0} As Valor{1}, e2.Ensayo{2}, e2.Valor{2}, ", i, i + 10, i + 20)
            Next

            Return WColumnas.TrimEnd(" ", ",")
        End Function

        Private Shared Function PrepararTablaEspecificaciones() As DataTable

            Dim tabla As New DataTable

            For i = 1 To 30
                tabla.Columns.Add("Ensayo" & i)
                tabla.Columns.Add("Descripcion" & i)
                tabla.Columns.Add("Valor" & i)
            Next

            tabla.Columns.Add("Producto")
            tabla.Columns.Add("Version")
            tabla.Columns.Add("FechaInicio")
            tabla.Columns.Add("FechaFinal")
            tabla.Columns.Add("ControlCambio")

            Return tabla

        End Function

    End Class
End Namespace
