Public Class SinParidadException
    Inherits Exception

    Public Sub New(ByVal mensage As String)

        MyBase.New(mensage)

    End Sub

    Public Sub New()

        MyBase.New()

    End Sub

End Class
