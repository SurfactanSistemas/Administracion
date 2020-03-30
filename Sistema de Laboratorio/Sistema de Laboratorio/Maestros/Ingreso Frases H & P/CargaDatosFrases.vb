Imports System.IO

Public Class CargaDatosFrases
    Dim FRASE As String
    Sub New(ByVal FRASEHP As String, Optional ByVal Codigo As String = "", Optional ByVal Descripcion As String = "", Optional ByVal Observacion As String = "")

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        FRASE = FRASEHP

        If Codigo <> "" Then
            txtCodigo.Text = Trim(Codigo)
            txtDescripcion.Text = Trim(Descripcion)
            txtObservaciones.Text = Trim(Observacion)
        End If

    End Sub

  
    Private Sub btnGrabar_Click(sender As Object, e As EventArgs) Handles btnGrabar.Click
        Dim SQLCnlst As String = ""

        txtDescripcion.Text = txtDescripcion.Text.Trim().PadRight(450, " ") 'Rellenamos los espacios vacio con " " para poder hacer el substring
        If FRASE = "H" Then
            SQLCnlst = "SELECT * FROM FraseH WHERE Codigo = '" & txtCodigo.Text & "'"
            Dim row As DataRow = GetSingle(SQLCnlst)
            If row Is Nothing Then
                SQLCnlst = "INSERT INTO FraseH (Codigo , Descripcion, DescripcionII, DescripcionIII, Observa) values ('" & txtCodigo.Text.Trim() & " ', '" & txtDescripcion.Text.Substring(0, 249).Trim() & "', '" & txtDescripcion.Text.Substring(250, 100).Trim() & "', '" & txtDescripcion.Text.Substring(350, 100).Trim() & "', '" & txtObservaciones.Text.Trim() & "')"

            Else
                SQLCnlst = "UPDATE FraseH SET Descripcion = '" & txtDescripcion.Text.Substring(0, 249).Trim() & "' , DescripcionII = '" & txtDescripcion.Text.Substring(250, 100).Trim() & "' , DescripcionIII = '" & txtDescripcion.Text.Substring(350, 100).Trim() & "' , Observa = '" & txtObservaciones.Text.Trim() & "'   WHERE Codigo = '" & txtCodigo.Text.Trim() & "'"

            End If
        Else
            SQLCnlst = "SELECT * FROM FraseP WHERE Codigo = '" & txtCodigo.Text & "'"
            Dim row As DataRow = GetSingle(SQLCnlst)
            If row Is Nothing Then
                SQLCnlst = "INSERT INTO FraseP (Codigo ,  Descripcion, DescripcionII, DescripcionIII, Observa) values ('" & txtCodigo.Text.Trim() & " ', '" & txtDescripcion.Text.Substring(0, 249).Trim() & "', '" & txtDescripcion.Text.Substring(250, 100).Trim() & "', '" & txtDescripcion.Text.Substring(350, 100).Trim() & "', '" & txtObservaciones.Text.Trim() & "' "

            Else
                SQLCnlst = "UPDATE FraseP SET Descripcion = '" & txtDescripcion.Text.Substring(0, 249).Trim() & "' , DescripcionII = '" & txtDescripcion.Text.Substring(250, 100).Trim() & "' , DescripcionIII = '" & txtDescripcion.Text.Substring(350, 100).Trim() & "' , Observa = '" & txtObservaciones.Text.Trim() & "'   WHERE Codigo = '" & txtCodigo.Text.Trim() & "'"

            End If
        End If

        ExecuteNonQueries(SQLCnlst)

        Dim Woner As IFrasesHP = TryCast(Owner, IFrasesHP)

        If Woner IsNot Nothing Then
            Woner.ProcesarFrases()
        End If

        Close()
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Close()
    End Sub
End Class