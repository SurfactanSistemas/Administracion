Module modulo
    Public Function OrDefault(ByVal valor As Object, ByVal valorXDefecto As Object) As Object
        Return IIf(valor Is Nothing OrElse IsDBNull(valor), valorXDefecto, valor)
    End Function
End Module
