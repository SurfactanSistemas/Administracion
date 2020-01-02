Namespace Entidades
    Public Class MatPrima

        Public Shared Function Info(ByVal Codigo As String, ByVal Columnas() As String) As DataRow
            Dim WBase As String = IIf(_EsPellital, "Pellital_III", "SurfactanSa")
            Dim WArt As DataRow = GetSingle(String.Format("SELECT {1} FROM Articulo WHERE Codigo = '{0}'", Codigo, String.Join(",", Columnas)), WBase)

            Return WArt
        End Function

        Public Shared Function Clasificacion(ByVal Codigo As String)
            Dim WClasificacion As Char = ""

            Dim WArt As DataRow = Info(Codigo, {"ClasificacionFarma"})

            If WArt IsNot Nothing Then WClasificacion = OrDefault(WArt.Item("ClasificacionFarma"), "")

            Return DescripcionClasificacion(WClasificacion)
        End Function

        Public Shared Function DescripcionClasificacion(ByVal Clasificacion As String)

            Select Case Val(Clasificacion)
                Case 1
                    Return "FARMA"
                Case 2
                    Return "FOOD"
                Case 3
                    Return "VETERINARIO"
                Case 4
                    Return "ENVASE"
                Case Else
                    Return ""
            End Select

        End Function

        Public Shared Function _TraerProximaNumeracion(ByVal Estado As TiposEstadoLaudoMP) As String

            Dim WMax, WMin As String

            WMin = _NumeracionMinimaPorPlanta(Estado)
            WMax = _NumeracionMaximaPorPlanta(Estado)

            Dim WUlt As DataRow = GetSingle(String.Format("SELECT MAX(Laudo) Ultimo FROM Laudo WHERE Laudo BETWEEN '{0}' And '{1}'", WMin, WMax))

            Return Val(OrDefault(WUlt.Item("Ultimo"), "")) + 1
        End Function

        Private Shared Function _NumeracionMinimaPorPlanta(ByVal Estado As TiposEstadoLaudoMP) As String
            Dim WEsPorDesvio As Boolean = Estado = TiposEstadoLaudoMP.AprobadoPorDesvio
            Dim WEsPorRechazo As Boolean = Estado = TiposEstadoLaudoMP.Rechazado

            Select Case UCase(Operador.Base)

                Case "SURFACTANSA"
                    If WEsPorDesvio Then Return "190000"
                    If WEsPorRechazo Then Return "70000"
                    Return "100000"
                Case "SURFACTAN_II"
                    If WEsPorDesvio Then Return "290000"
                    If WEsPorRechazo Then Return "74000"
                    Return "200000"
                Case "SURFACTAN_III"
                    If WEsPorDesvio Then Return "390000"
                    If WEsPorRechazo Then Return "78000"
                    Return "300000"
                Case "SURFACTAN_IV"
                    If WEsPorDesvio Then Return "490000"
                    If WEsPorRechazo Then Return "75000"
                    Return "400000"
                Case "SURFACTAN_V"
                    If WEsPorDesvio Then Return "590000"
                    If WEsPorRechazo Then Return "72000"
                    Return "500000"
                Case "SURFACTAN_VI"
                    If WEsPorDesvio Then Return "570000"
                    If WEsPorRechazo Then Return "72400"
                    Return "520000"
                Case "SURFACTAN_VII"
                    If WEsPorDesvio Then Return "580000"
                    If WEsPorRechazo Then Return "72700"
                    Return "540000"
                Case "PELLITALSA"
                    If WEsPorDesvio Then Return "690000"
                    If WEsPorRechazo Then Return "71000"
                    Return "600000"
                Case "PELITALL_II"
                    If WEsPorDesvio Then Return "790000"
                    If WEsPorRechazo Then Return "76000"
                    Return "700000"
                Case "PELLITAL_III"
                    If WEsPorDesvio Then Return "890000"
                    If WEsPorRechazo Then Return "73000"
                    Return "800000"
                Case "PELLITAL_V"
                    If WEsPorDesvio Then Return "692000"
                    If WEsPorRechazo Then Return "71300"
                    Return "650000"

            End Select
            Return ""
        End Function

        Private Shared Function _NumeracionMaximaPorPlanta(ByVal Estado As TiposEstadoLaudoMP) As String
            Dim WEsPorDesvio As Boolean = Estado = TiposEstadoLaudoMP.AprobadoPorDesvio
            Dim WEsPorRechazo As Boolean = Estado = TiposEstadoLaudoMP.Rechazado

            Select Case UCase(Operador.Base)

                Case "SURFACTANSA"
                    If WEsPorDesvio Then Return "189999"
                    If WEsPorRechazo Then Return "70999"
                    Return "194999"
                Case "SURFACTAN_II"
                    If WEsPorDesvio Then Return "294999"
                    If WEsPorRechazo Then Return "74999"
                    Return "289999"
                Case "SURFACTAN_III"
                    If WEsPorDesvio Then Return "394999"
                    If WEsPorRechazo Then Return "78999"
                    Return "389999"
                Case "SURFACTAN_IV"
                    If WEsPorDesvio Then Return "494999"
                    If WEsPorRechazo Then Return "75999"
                    Return "489999"
                Case "SURFACTAN_V"
                    If WEsPorDesvio Then Return "594999"
                    If WEsPorRechazo Then Return "72399"
                    Return "519999"
                Case "SURFACTAN_VI"
                    If WEsPorDesvio Then Return "574999"
                    If WEsPorRechazo Then Return "72699"
                    Return "539999"
                Case "SURFACTAN_VII"
                    If WEsPorDesvio Then Return "584999"
                    If WEsPorRechazo Then Return "72999"
                    Return "559999"
                Case "PELLITALSA"
                    If WEsPorDesvio Then Return "694999"
                    If WEsPorRechazo Then Return "71999"
                    Return "689999"
                Case "PELITALL_II"
                    If WEsPorDesvio Then Return "794999"
                    If WEsPorRechazo Then Return "76999"
                    Return "789999"
                Case "PELLITAL_III"
                    If WEsPorDesvio Then Return "894999"
                    If WEsPorRechazo Then Return "73999"
                    Return "889999"
                Case "PELLITAL_V"
                    If WEsPorDesvio Then Return "694999"
                    If WEsPorRechazo Then Return "71999"
                    Return "689999"

            End Select
            Return ""
        End Function

    End Class
End Namespace
