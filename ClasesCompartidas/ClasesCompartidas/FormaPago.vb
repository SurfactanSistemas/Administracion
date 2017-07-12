Public Class FormaPago
    Public banco As Short
    Public tipo, numero, fecha, nombre, cuit As String
    Public importe As Double

    Public Sub New(ByVal tipoForma As String, ByVal codBanco As Short, ByVal numeroCheque As String,
                   ByVal fechaCheque As String, ByVal descripcion As String, ByVal valor As Double, Optional ByVal _cuit As String = "")
        tipo = tipoForma
        banco = codBanco
        numero = numeroCheque
        fecha = fechaCheque
        nombre = descripcion
        importe = valor
        cuit = _cuit

    End Sub
End Class
