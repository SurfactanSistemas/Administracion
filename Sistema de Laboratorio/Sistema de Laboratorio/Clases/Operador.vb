﻿Module Operador
    Public Property Base As String
    
    Private _IDBase As Short
    Public ReadOnly Property IDBase() As Short
        Get
            Return ConsultasVarias.Clases.Helper._IdEmpresaSegunBase(Base)
        End Get
    End Property

    Public Property Codigo As Integer
    Public Property Clave As String
    Public Property Descripcion As String

    Public Function EsFarma() As Boolean
        Return Base = "Surfactan_III"
    End Function

End Module
