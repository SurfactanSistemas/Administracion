Namespace Entidades

    Public Class Ensayo
        Public Shared Function TraerDescripcion(ByVal Ensayo As Object) As String

            Dim WBase As String = IIf(_EsPellital, "Pelitall_II", "Surfactan_II")
            Dim WEnsayo As DataRow = GetSingle("SELECT Descripcion FROM Ensayos WHERE Codigo = '" & Ensayo & "'", WBase)

            If WEnsayo IsNot Nothing Then Return Trim(OrDefault(WEnsayo.Item("Descripcion"), ""))

            Return ""

        End Function
    End Class

End Namespace