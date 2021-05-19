Imports System.Runtime.CompilerServices

Module ExtensionesTipoFecha

    <Extension()> _
    Function estaVacia(ByVal fecha As String, Optional ByVal separador As String = "/") As Boolean
        Return fecha.Replace(separador, "").Trim() = ""
    End Function

    <Extension()> _
    Function esMenorA(ByVal fecha1 As String, ByVal fecha2 As String) As Boolean
        Return Helper.ordenaFecha(fecha1) < Helper.ordenaFecha(fecha2)
    End Function

    <Extension()> _
    Function esMayorA(ByVal fecha1 As String, ByVal fecha2 As String) As Boolean
        Return Helper.ordenaFecha(fecha1) > Helper.ordenaFecha(fecha2)
    End Function

    <Extension()> _
    Function esIgualA(ByVal fecha1 As String, ByVal fecha2 As String) As Boolean
        Return Helper.ordenaFecha(fecha1) = Helper.ordenaFecha(fecha2)
    End Function

    <Extension()> _
    Function esMenorOIgualA(ByVal fecha1 As String, ByVal fecha2 As String) As Boolean
        Return fecha1.esMenorA(fecha2) Or fecha1.esIgualA(fecha2)
    End Function

    <Extension()> _
    Function esMayorOIgualA(ByVal fecha1 As String, ByVal fecha2 As String) As Boolean
        Return fecha1.esMayorA(fecha2) Or fecha1.esIgualA(fecha2)
    End Function

End Module
