Imports System.Runtime.CompilerServices

Module ExtensionesTipoFecha

    ''' <summary>
    ''' Verifica que la fecha tenga algun tipo de valor, mas allá de los separadores.
    ''' </summary>
    <Extension()>
    Function estaVacia(ByVal fecha As String, Optional ByVal separador As String = "/") As Boolean
        Return fecha.Replace(separador, "").Trim() = ""
    End Function

    ''' <summary>
    ''' Verifica si `fecha1` es MENOR a `fecha2`
    ''' </summary>
    <Extension()>
    Function esMenorA(ByVal fecha1 As String, ByVal fecha2 As String) As Boolean
        Return Helper.ordenaFecha(fecha1) < Helper.ordenaFecha(fecha2)
    End Function

    ''' <summary>
    ''' Verifica si `fecha1` es MAYOR a `fecha2`
    ''' </summary>
    <Extension()>
    Function esMayorA(ByVal fecha1 As String, ByVal fecha2 As String) As Boolean
        Return Helper.ordenaFecha(fecha1) > Helper.ordenaFecha(fecha2)
    End Function

    ''' <summary>
    ''' Verifica si `fecha1` es IGUAL a `fecha2`
    ''' </summary>
    <Extension()>
    Function esIgualA(ByVal fecha1 As String, ByVal fecha2 As String) As Boolean
        Return Helper.ordenaFecha(fecha1) = Helper.ordenaFecha(fecha2)
    End Function

    ''' <summary>
    ''' Verifica si `fecha1` es MENOR O IGUAL a `fecha2`
    ''' </summary>
    <Extension()>
    Function esMenorOIgualA(ByVal fecha1 As String, ByVal fecha2 As String) As Boolean
        Return fecha1.esMenorA(fecha2) Or fecha1.esIgualA(fecha2)
    End Function

    ''' <summary>
    ''' Verifica si `fecha1` es MAYOR O IGUAL a `fecha2`
    ''' </summary>
    <Extension()>
    Function esMayorOIgualA(ByVal fecha1 As String, ByVal fecha2 As String) As Boolean
        Return fecha1.esMayorA(fecha2) Or fecha1.esIgualA(fecha2)
    End Function

End Module
