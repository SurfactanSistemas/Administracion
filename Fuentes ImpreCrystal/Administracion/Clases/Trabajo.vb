Public Class Trabajo
    Public ReadOnly Codigo As String
    Public ReadOnly Proceso As String
    Public ReadOnly Destino As String
    Public ReadOnly Planta As Integer
    Public ReadOnly Orden As Integer
    Public ReadOnly Nombre As String
    Sub New(ByVal Codigo, ByVal Proceso, ByVal Destino, ByVal Planta, ByVal Orden, ByVal Nombre)
        Me.Codigo = Codigo
        Me.Proceso = Proceso
        Me.Destino = Destino
        Me.Planta = Planta
        Me.Orden = Orden
        Me.Nombre = Nombre
    End Sub
End Class
