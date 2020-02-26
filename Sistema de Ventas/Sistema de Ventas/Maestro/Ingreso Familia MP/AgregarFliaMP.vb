Imports ConsultasVarias.Clases.Query
Public Class AgregarFliaMP
    Sub New(ByVal Accion As Integer, Optional ByVal Descripcion As String = "")

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        If Accion = 0 Then
            Dim SQLCnslt As String = "SELECT NuevoCodigo = Max(Linea) + 1 FROM LineasMp "
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
            Dim SQLCnslt As String = "SELECT Linea FROM LineasMp WHERE Linea = '" & txtCodigo.Text & "'"
            Dim Row As DataRow = GetSingle(SQLCnslt)

            If Row IsNot Nothing Then
                SQLCnslt = "UPDATE LineasMp SET Nombre = '" & txtDescripcion.Text & "' WHERE Linea = '" & txtCodigo.Text & "'"

            Else
                SQLCnslt = "INSERT INTO LineasMp (Linea, Nombre) VALUES ('" & txtCodigo.Text & "' , '" & txtDescripcion.Text & "') "
            End If
            ExecuteNonQueries({SQLCnslt})
            Dim WOwner As IAgregarFliaMP = TryCast(Owner, IAgregarFliaMP)
            If WOwner IsNot Nothing Then
                WOwner._ProcesarDatosFliaMP()
            End If
            Close()
        End If
    End Sub

    Private Sub AgregarFliaMP_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        txtDescripcion.Focus()
    End Sub
End Class