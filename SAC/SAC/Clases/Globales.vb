Module Globales

    Public ReadOnly WBackColorSecundario = Color.FromArgb(12, 217, 232)
    Public ReadOnly WBackColorTerciario = Color.FromArgb(0, 170, 255)
    Private _Empresas As List(Of String)

    Public ReadOnly Property Empresas() As List(Of String)
        Get
            Dim WEmp As New List(Of String) From {"SurfactanSa", "Surfactan_II", "Surfactan_III", "Surfactan_IV" _
               , "Surfactan_V", "Surfactan_VI", "Surfactan_VII"}

            If _EsPellital() Then
                WEmp = New List(Of String) From {"PellitalSa", "Pelitall_II", "Pellital_III", "Pellital_V"}
            End If

            Return WEmp
        End Get
    End Property

    Enum TipoIncidencias
        SinAsignar
        General
        RechazoMP
    End Enum

End Module
