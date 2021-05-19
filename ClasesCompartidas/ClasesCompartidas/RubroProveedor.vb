Public Class RubroProveedor
    Public codigo As Integer
    Public descripcion As String

    Public Sub New(ByVal cod As Integer, ByVal nombre As String)
        codigo = cod
        descripcion = nombre
    End Sub

    Public Overrides Function ToString() As String
        Return descripcion
    End Function

    Public ReadOnly Property valueMember As Integer
        Get
            Return codigo
        End Get
    End Property
End Class
