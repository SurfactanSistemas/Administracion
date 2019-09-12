Namespace Entidades
    Public Class MatPrima

        Public Shared Function Info(ByVal Codigo As String, ByVal Columnas() As String) As DataRow
            Dim WBase As String = IIf(_EsPellital, "Pellital_III", "SurfactanSa")
            Dim WArt As DataRow = GetSingle(String.Format("SELECT {1} FROM Articulo WHERE Codigo = '{0}'", Codigo, String.Join(",", Columnas)), WBase)

            Return WArt
        End Function
    End Class
End Namespace
