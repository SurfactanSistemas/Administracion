Public Class ActualizarMailCoaCliente
    Private Cliente As String = ""
    Sub New(ByVal Cliente As String)

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me.Cliente = Cliente
    End Sub

    Private Sub btnMasTarde_Click(sender As Object, e As EventArgs) Handles btnMasTarde.Click
        DialogResult = Windows.Forms.DialogResult.Cancel
        Close()
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click

        ExecuteNonQueries({"UPDATE Cliente SET EmailCoa = '" & TextBox1.Text & "' WHERE Cliente = '" & Cliente & "'"})

        DialogResult = Windows.Forms.DialogResult.OK

        Close()

    End Sub

    Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnAceptar_Click(Nothing, Nothing)
        End If
    End Sub
End Class