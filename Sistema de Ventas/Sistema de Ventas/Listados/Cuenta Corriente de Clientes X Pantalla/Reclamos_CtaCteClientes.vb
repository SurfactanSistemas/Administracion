Imports Util
Imports Util.Clases.Query


Public Class Reclamos_CtaCteClientes

    Dim Cliente As String = ""
    Sub New(ByVal CodCliente As String, ByVal DesCliente As String)

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Cliente = CodCliente
        txt_Cliente.Text = CodCliente & " - " & DesCliente

        REM  If Val(Solicitud.Text) <> 0 Then
        Dim SQLCnslt As String = "Select Observacion" _
                                & " FROM reclamo" _
                                & " Where codigo = '" & Cliente & "'" _
                                & " Order by Codigo"
        Dim RowReclamo As DataRow = GetSingle(SQLCnslt, Operador.Base)

        If RowReclamo IsNot Nothing Then
            Dim Texto As String = IIf(IsDBNull(RowReclamo.Item("Observacion")), " ", RowReclamo.Item("Observacion"))

            txt_Reclamos.Text = Texto

        Else

        End If

    End Sub

 
    Private Sub btn_Aceptar_Click(sender As Object, e As EventArgs) Handles btn_Aceptar.Click

        Dim listaSQLCnslt As New List(Of String)

        Dim SQLCnslt As String = "DELETE reclamo" _
                                & " Where codigo = '" & Cliente & "'"
        
        listaSQLCnslt.Add(SQLCnslt)

        SQLCnslt = "INSERT INTO reclamo (" _
        & "Codigo ," _
        & "Observacion )" _
        & "Values ('" & Cliente & "'," _
        & "'" & txt_Reclamos.Text & "')"

        listaSQLCnslt.Add(SQLCnslt)

        ExecuteNonQueries(listaSQLCnslt.ToArray(), Operador.Base)

        Close()

    End Sub
End Class