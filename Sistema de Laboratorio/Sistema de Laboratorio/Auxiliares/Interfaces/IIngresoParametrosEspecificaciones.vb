Public Interface IIngresoParametrosEspecificaciones
    Sub _ProcesarIngresoParametrosEspecificaciones(ByVal Parametro As String, ByVal Tipo As Integer, ByVal Informa As Integer, ByVal MenorIgual As Integer, ByVal Desde As String, ByVal Hasta As String, ByVal Unidad As String, ByVal Farmacopea As String, ByVal Formula As String, ByVal ParametrosFormula() As String, ByVal Adicionales(,) As String)
End Interface
