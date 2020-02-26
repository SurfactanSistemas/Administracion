Imports ConsultasVarias.Clases.Query
Public Class AgregarVendedor
    Sub New(ByVal Codigo As Integer, Optional ByVal Nombre As String = "", Optional ByVal Email1 As String = "", Optional ByVal Email2 As String = "")

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        If Codigo = 0 Then
            Dim SQLCnslt As String = "SELECT NuevoCodigo = Max(Vendedor) + 1 FROM Vendedor "
            Dim row As DataRow = GetSingle(SQLCnslt)

            If row IsNot Nothing Then
                txtCodigo.Text = row.Item("NuevoCodigo")
            End If
        Else
            txtCodigo.Text = Codigo
            txtNombre.Text = Nombre
            txtEmail1.Text = Email1
            txtEmail2.Text = Email2
        End If
    End Sub


    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Close()
    End Sub

    Private Sub btnGrabar_Click(sender As Object, e As EventArgs) Handles btnGrabar.Click
        If txtNombre.Text <> "" Then
            Dim SQLCnslt As String = "SELECT Vendedor FROM Vendedor WHERE Vendedor = '" & txtCodigo.Text & "'"
            Dim Row As DataRow = GetSingle(SQLCnslt)

            If Row IsNot Nothing Then
                SQLCnslt = "UPDATE Vendedor SET Nombre = '" & txtNombre.Text & "', Email1 = '" & txtEmail1.Text & "' , Email2 = '" & txtEmail2.Text & "' WHERE Vendedor = '" & txtCodigo.Text & "'"

            Else
                SQLCnslt = "INSERT INTO Vendedor (Vendedor, Nombre, Email1, Email2) VALUES ('" & txtCodigo.Text & "' , '" & txtNombre.Text & "',  '" & txtEmail1.Text & "' , '" & txtEmail2.Text & "' ) "
            End If
            ExecuteNonQueries({SQLCnslt})
            Dim WOwner As IAgregarVendedores = TryCast(Owner, IAgregarVendedores)
            If WOwner IsNot Nothing Then
                WOwner._ProcesarDatosVendedores()
            End If
            Close()
        End If
    End Sub

    Private Sub AgregarVendedor_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        txtNombre.Focus()
    End Sub
End Class