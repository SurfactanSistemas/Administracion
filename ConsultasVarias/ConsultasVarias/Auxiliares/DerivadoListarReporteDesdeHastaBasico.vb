Public Class DerivadoListarReporteDesdeHastaBasico
    Inherits ListarReporteDesdeHastaBasico

    Public Shadows Property ClientSize As SizeF
        Get
            Return MyBase.ClientSize
        End Get
        Set(ByVal value As SizeF)

        End Set
    End Property

End Class