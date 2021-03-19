Public Interface IGrabadoDeFormula
    Sub _GrabarFormulaMod(ByVal Formula As String, ByVal ParametrosFormula() As String, ByVal Descripcion As String, Optional ByVal Renglon As Integer = 0, Optional _
                          ByVal Modificado As Boolean = False, Optional ByVal adic1 As String = "", Optional ByVal adic2 As String = "", Optional ByVal adic3 As String = "", Optional ByVal decadic1 As String = "", Optional ByVal decadic2 As String = "", Optional ByVal decadic3 As String = "")
    Sub _GrabarFormula(Formula As String, ParametrosFormula As String(), Descripcion As String, Optional Renglon As Integer = 0, Optional ByVal Adicionales(,) As String = Nothing)

End Interface
