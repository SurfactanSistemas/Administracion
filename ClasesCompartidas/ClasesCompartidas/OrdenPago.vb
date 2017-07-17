Public Class OrdenPago
    Public tipo As Integer
    Public paridad, importe, retIVA, retIB, retIBCiudad, retGanancias As Double
    Public nroOrden, fecha, fechaParidad, observaciones, certIb, certIbCABA, certIVA As String
    Public banco As Banco
    Public proveedor As Proveedor
    Public formaPagos As New List(Of FormaPago)
    Public pagos As New List(Of Pago)

    Public Sub New(ByVal numero As String, ByVal tipoOrden As Integer, ByVal valParidad As Double, ByVal total As Double,
                   ByVal IVA As Double, ByVal IB As Double, ByVal IBCiudad As Double, ByVal IG As Double, ByVal fechaOrd As String,
                   ByVal fechaPar As String, ByVal obs As String, ByVal ban As Banco, ByVal prov As Proveedor, Optional ByVal _CertIb As String = "", Optional ByVal _CertIbCABA As String = "", Optional ByVal _CertIVA As String = "")
        nroOrden = numero
        tipo = tipoOrden
        paridad = valParidad
        importe = total
        retIVA = IVA
        retIB = IB
        retIBCiudad = IBCiudad
        retGanancias = IG
        fecha = fechaOrd
        fechaParidad = fechaPar
        observaciones = obs
        banco = ban
        proveedor = prov
        certIb = _CertIb
        certIbCABA = _CertIbCABA
        certIVA = _CertIVA
    End Sub

    Public Function codigoBanco() As Short
        If IsNothing(banco) Then
            Return 0
        Else
            Return banco.id
        End If
    End Function

    Public Function codigoProveedor()
        If IsNothing(proveedor) Then
            Return ""
        Else
            Return proveedor.id
        End If
    End Function
End Class
