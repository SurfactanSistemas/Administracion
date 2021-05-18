Public Class DetalleCompraCuentaCorriente
    Public tipo, punto, numero, letra, fecha, impresion As String
    Public saldo As String
    Public total, paridad As Double
    Public numInterno, pago As Integer
    Public proveedor As Proveedor

    Public Sub New(ByVal tipoDoc As String, ByVal tipoImpre As String, ByVal punt As String, ByVal nro As String, ByVal letraString As String,
                   ByVal fechaString As String, ByVal restante As Double, ByVal valorTotal As Double,
                   ByVal interno As String, ByVal prov As Proveedor, ByVal pago2 As Integer, ByVal paridad2 As Double)
        tipo = tipoDoc
        impresion = tipoImpre
        punto = punt
        numero = nro
        letra = letraString
        fecha = fechaString
        saldo = restante.ToString
        total = valorTotal
        numInterno = CInt(interno)
        proveedor = prov
        pago = pago2
        paridad = paridad2
    End Sub

    Public Function codigoProveedor() As String
        If IsNothing(proveedor) Then
            Return ""
        End If
        Return proveedor.id
    End Function

    Public Overrides Function ToString() As String
        Return impresion & " - " & letra & " - " & punto & " - " & numero & " - " & fecha & " - " & asDoubleString(saldo).PadLeft(10, CType("_", Char))
    End Function

    Private Function asDoubleString(ByVal value As String) As String
        Dim originalString As String = value.ToString
        If originalString.IndexOf(",") = -1 Then
            Return originalString & "," & "".PadLeft(2, CType("0", Char))
        Else
            Dim difference As Integer = originalString.Count - originalString.IndexOf(",") - 1
            If difference < 2 Then
                Return originalString & "".PadLeft(2 - difference, CType("0", Char))
            End If
        End If
        Return originalString
        Return value.ToString
    End Function

    Public Function esClausulaDolar() As Boolean
        Return pago = 2
    End Function

    Public Function montoDolar() As Double
        Return Val(saldo) / paridad
    End Function
End Class
