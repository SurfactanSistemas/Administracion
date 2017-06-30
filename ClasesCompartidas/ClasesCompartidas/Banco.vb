Public Class Banco
    Public id As Short
    Public nombre As String
    Public cuenta As CuentaContable

    Public Sub New(ByVal codigo As Short, ByVal descripcion As String, ByVal cuentaContable As CuentaContable)
        id = codigo
        nombre = descripcion
        cuenta = cuentaContable
    End Sub

    Public Overrides Function ToString() As String
        Return nombre
    End Function
End Class
