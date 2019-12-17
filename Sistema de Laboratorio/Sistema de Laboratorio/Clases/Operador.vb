Module Operador
    Public Property Base As String
    Public Property Codigo As Integer
    Public Property Clave As String
    Public Property Descripcion As String

    Public Function EsFarma() As Boolean
        Return Base = "Surfactan_III"
    End Function
End Module
