Public Class DetalleCompraCuentaCorriente
    Public tipo, punto, numero, letra, fecha, impresion As String
    Public saldo, total, paridad As Double
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
        saldo = restante
        total = valorTotal
        numInterno = interno
        proveedor = prov
        pago = pago2
        paridad = paridad2
    End Sub

    Public Function igualA(ByVal cuenta As DetalleCompraCuentaCorriente)
        Return tipo = cuenta.tipo And
            punto = cuenta.punto And
            numero = cuenta.numero And
            letra = cuenta.letra And
            fecha = cuenta.fecha And
            saldo = cuenta.saldo And
            numInterno = cuenta.numInterno And
            codigoProveedor() = cuenta.codigoProveedor
    End Function

    Public Function codigoProveedor()
        If IsNothing(proveedor) Then
            Return ""
        End If
        Return proveedor.id
    End Function

    Public Overrides Function ToString() As String
        Return impresion & " - " & letra & " - " & punto & " - " & numero & " - " & fecha & " - " & asDoubleString(saldo).PadLeft(10, "_")
    End Function

    Private Function asDoubleString(ByVal value) As String
        Dim originalString As String = value.ToString
        If originalString.IndexOf(",") = -1 Then
            Return originalString & "," & "".PadLeft(2, "0")
        Else
            Dim difference As Integer = originalString.Count - originalString.IndexOf(",") - 1
            If difference < 2 Then
                Return originalString & "".PadLeft(2 - difference, "0")
            End If
        End If
        Return originalString
        Return value.ToString
    End Function

    Public Function esClausulaDolar()
        Return pago = 2
    End Function

    Public Function montoDolar()
        Return saldo / paridad
    End Function
End Class
