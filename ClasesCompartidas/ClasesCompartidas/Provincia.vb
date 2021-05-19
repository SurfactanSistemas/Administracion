Public Class Provincia
    Public id As Integer
    Public nombre As String

    Public Sub New(ByVal codigo As Integer, ByVal descripcion As String)
        id = codigo
        nombre = descripcion
    End Sub

    Public Overrides Function ToString() As String
        Return nombre
    End Function

    Public ReadOnly Property valueMember As Integer
        Get
            Return id
        End Get
    End Property
End Class
