Imports ConsultasVarias.Clases.Query
Public Class AgregarConcepDGastosImpor
    Sub New(ByVal Codigo As Integer, Optional ByVal Descripcion As String = "")

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        If Codigo = 0 Then
            Dim SQLCnslt As String = "SELECT NuevoCodigo = Max(Codigo) + 1 FROM Gasimpo "
            Dim row As DataRow = GetSingle(SQLCnslt)

            If row IsNot Nothing Then
                txtCodigo.Text = row.Item("NuevoCodigo")
            End If
        Else
            txtCodigo.Text = Codigo
            txtDescripcion.Text = Descripcion
        End If
    End Sub


    Private Sub txtDescripcion_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDescripcion.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                btnGrabar_Click(Nothing, Nothing)
            Case Keys.Escape
                txtDescripcion.Text = ""
        End Select
    End Sub



    Private Sub btnGrabar_Click(sender As Object, e As EventArgs) Handles btnGrabar.Click
        If txtDescripcion.Text <> "" Then
            Dim SQLCnslt As String = "SELECT Codigo FROM Gasimpo WHERE Codigo = '" & txtCodigo.Text & "'"
            Dim Row As DataRow = GetSingle(SQLCnslt)


            If Row IsNot Nothing Then
                SQLCnslt = "UPDATE Gasimpo SET Nombre = '" & txtDescripcion.Text & "'"

            Else
                SQLCnslt = "INSERT INTO Gasimpo (Codigo, Nombre) VALUES ('" & txtCodigo.Text & "' , '" & txtDescripcion.Text & "') "
            End If
            ExecuteNonQueries({SQLCnslt})
            Dim WOwner As IAgregarGastosImpo = TryCast(Owner, IAgregarGastosImpo)
            If WOwner IsNot Nothing Then
                WOwner._ProcesarDatosGastosImpo()
            End If
            Close()
        End If
    End Sub



    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Close()
    End Sub

    Private Sub AgregarGastosImpo_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        txtDescripcion.Focus()
    End Sub
End Class