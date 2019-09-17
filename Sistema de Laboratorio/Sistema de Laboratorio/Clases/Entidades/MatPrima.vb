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

    End Class
End Namespace
