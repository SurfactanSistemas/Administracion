Imports ConsultasVarias.Clases.Query

Public Class AgregarRubro

    Sub New(ByVal Accion As Integer, Optional ByVal Descripcion As String = "")

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        If Accion = 0 Then
            Dim SQLCnslt As String = "SELECT NuevoCodigo = Max(Rubro) + 1 FROM Rubros "
            Dim row As DataRow = GetSingle(SQLCnslt)

            If row IsNot Nothing Then
                txtCodigo.Text = row.Item("NuevoCodigo")
            End If
        Else
            txtCodigo.Text = Accion
            txtDescripcion.Text = Descripcion
        End If
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Close()
    End Sub

    Private Sub btnGrabar_Click(sender As Object, e As EventArgs) Handles btnGrabar.Click
        If txtDescripcion.Text <> "" Then
            Dim SQLCnslt As String = "SELECT Rubro FROM Rubros WHERE Rubro = '" & txtCodigo.Text & "'"
            Dim Row As DataRow = GetSingle(SQLCnslt)

            If Row IsNot Nothing Then
                SQLCnslt = "UPDATE Rubros SET Nombre = '" & txtDescripcion.Text & "' WHERE Rubro = '" & txtCodigo.Text & "'"

            Else
                SQLCnslt = "INSERT INTO Rubros (Rubro, Nombre) VALUES ('" & txtCodigo.Text & "' , '" & txtDescripcion.Text & "') "
            End If
            ExecuteNonQueries({SQLCnslt})
            Dim WOwner As IAgregarRubro = TryCast(Owner, IAgregarRubro)
            If WOwner IsNot Nothing Then
                WOwner._ProcesarDatosRubro()
            End If
            Close()
        End If
    End Sub

    Private Sub AgregarRubro_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        txtDescripcion.Focus()
    End Sub
End Class