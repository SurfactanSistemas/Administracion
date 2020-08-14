Public Interface ICentroImportaciones_auxiliar
    Sub PasaFiltro(ByVal Filtro As String)
    Sub Pasafechas(ByVal Desde As String, ByVal Hasta As String)

    Sub PasaOrden(ByVal Orden As String, ByVal Planta As String)

    Sub PasaCarpeta(ByVal Carpeta As String, ByVal Planta As String)

    Sub PasaTXTDjai(ByVal Fecha As String)
End Interface
