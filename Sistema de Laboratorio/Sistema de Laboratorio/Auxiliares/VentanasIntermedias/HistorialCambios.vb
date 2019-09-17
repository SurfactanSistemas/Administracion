Public Class HistorialCambios

    Sub New(ByVal Tipo As Char, ByVal Codigo As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        Dim WDatos As New DataTable

        If UCase(Tipo) = "M" Then

        Else
            WDatos = _TraerHistorialCambiosPT(Codigo)
        End If

        If WDatos.Rows.Count = 0 Then Close()

        dgvVersiones.DataSource = WDatos

    End Sub

    Private Function _TraerHistorialCambiosPT(ByVal codigo As String) As DataTable
        
        Dim WBase As String = IIf(_EsPellital, "Pelitall_II", "Surfactan_II")

        Return GetAll("SELECT Version, FechaInicio, FechaFinal, RTRIM(ControlCambio) As ControlCambio FROM EspecifUnificaVersion WHERE Producto = '" & codigo & "' Order by Version", WBase)

    End Function

End Class