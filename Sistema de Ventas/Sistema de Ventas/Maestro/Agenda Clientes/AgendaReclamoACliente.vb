Imports Util.Clases.Query
Imports Util.Clases.Helper
Public Class AgendaReclamoACliente
    Private ReadOnly WCliente As String

    Sub New(ByVal Cliente As String)

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        WCliente = Cliente
    End Sub

    Private Sub AgendaReclamoACliente_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim WReclamo As DataRow = GetSingle("Select r.Observacion, c.Razon FROM Reclamo r INNER JOIN Cliente c ON c.Cliente = r.Codigo WHERE r.Codigo = '" & WCliente & "'")

        If WReclamo IsNot Nothing Then
            lblRazon.Text = WReclamo("Razon")
            txtObservacion.Text = Trim(OrDefault(WReclamo("Observacion"), ""))
        End If

    End Sub

    Private Sub AgendaReclamoACliente_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        txtObservacion.Focus()
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Dim WSql As New List(Of String)

        WSql.Add("DELETE FROM Reclamo WHERE Codigo = '" & WCliente & "'")
        WSql.Add("INSERT INTO Reclamo (Codigo, Observacion) VALUES ('" & WCliente & "', '" & txtObservacion.Text.Trim & "')")

        ExecuteNonQueries(WSql.ToArray)

        Close()

    End Sub
End Class