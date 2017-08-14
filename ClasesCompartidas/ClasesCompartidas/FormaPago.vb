Public Class FormaPago
    Public banco As Short
    Public tipo, numero, fecha, nombre, cuit, Renglon As String
    Public importe As String

    Public Sub New(ByVal tipoForma As String, ByVal codBanco As Short, ByVal numeroCheque As String,
                   ByVal fechaCheque As String, ByVal descripcion As String, ByVal valor As String, Optional ByVal _cuit As String = "", Optional ByVal _Renglon As String = "")
        tipo = tipoForma
        banco = codBanco
        numero = numeroCheque
        fecha = fechaCheque
        nombre = descripcion
        importe = valor
        cuit = _cuit
        Renglon = Trim(_Renglon)

    End Sub
End Class
