Imports System.Runtime.CompilerServices

Namespace Clases
    Public Module ExtMethods

        <Extension()>
        Public Function Ceros(ByVal obj As String, ByVal length As Byte) As String
            Return obj.Trim.PadLeft(length, "0")
        End Function

    End Module

End Namespace
