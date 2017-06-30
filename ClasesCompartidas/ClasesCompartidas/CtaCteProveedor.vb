Public Class CtaCteProveedor
    Public fechaOriginal, desProveedorOriginal, factura, cuota, fecha, referencia, clave, nroInterno As String
    Public saldo, intereses, ivaIntereses As Double


    Public Sub New(ByVal fechaOri As String,
                ByVal desProvOriginal As String,
                ByVal fact As String,
                ByVal cuot As String,
                ByVal fech As String,
                ByVal sald As Double,
                ByVal interes As Double,
                ByVal ivaInteres As Double,
                ByVal ref As String,
                ByVal clav As String,
                ByVal numInterno As String)
        fechaOriginal = fechaOri
        desProveedorOriginal = desProvOriginal
        factura = fact
        cuota = cuot
        fecha = fech
        referencia = ref
        clave = clav
        nroInterno = numInterno
        saldo = sald
        intereses = interes
        ivaIntereses = ivaInteres
    End Sub
End Class
