Imports System.Runtime.CompilerServices

Module AuxiExtensiones
    
    <Extension()>
    Public Function Ceros(ByVal txt As TextBox, ByVal longitud As Object) As String
        Return txt.Text.PadLeft(longitud, "0")
    End Function

    <Extension()>
    Public Function Ceros(ByVal obj As Object, ByVal longitud As Object) As String
        Return obj.ToString.PadLeft(longitud, "0")
    End Function

    <Extension()>
    Public Function left(ByVal obj As Object, ByVal longitud As Object) As String
        Return Microsoft.VisualBasic.Left$(obj.ToString, longitud)
    End Function

End Module
