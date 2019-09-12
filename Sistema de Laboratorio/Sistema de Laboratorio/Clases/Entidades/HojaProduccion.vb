Imports Laboratorio.Clases

Namespace Entidades
    Public Class HojaProduccion

        Public Shared Function Info(ByVal Partida As String, ByVal Columnas() As String, Optional ByVal Base As String = "") As DataTable
            Return GetAll(String.Format("SELECT {1} FROM Hoja WHERE Hoja = '{0}' ORDER BY Clave", Partida, String.Join(",", Columnas)), Base)
        End Function

        Public Shared Function SingleInfo(ByVal Columnas() As String, ByVal Condicion() As String, Optional ByVal Base As String = "") As DataRow

            For i = 0 To Condicion.Length - 1
                Condicion(i) = String.Format("({0})", Condicion(i))
            Next

            Return GetSingle(String.Format("SELECT {1} FROM Hoja WHERE {0} ORDER BY Clave", String.Join(" And ", Condicion), String.Join(",", Columnas)), Base)

        End Function

        Public Shared Function EmpresaOrigen(ByVal Partida As String) As String

            For Each empresa As String In Conexion.Empresas
                Dim WHoja As DataRow = GetSingle("SELECT Hoja FROM Hoja WHERE Hoja = '" & Partida & "'", empresa)

                If WHoja IsNot Nothing Then
                    Return empresa
                End If
            Next

            Return ""
        End Function

    End Class
End Namespace
