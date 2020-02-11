Public Interface IGrabadoDeFormula
    Sub _GrabarFormulaMod(ByVal Formula As String, ByVal ParametrosFormula() As String, ByVal Descripcion As String, Optional ByVal Renglon As Integer = 0, Optional _
                          ByVal Modificado As Boolean = False)
    Sub _GrabarFormula(Formula As String, ParametrosFormula As String(), Descripcion As String, Optional Renglon As Integer = 0)

End Interface
