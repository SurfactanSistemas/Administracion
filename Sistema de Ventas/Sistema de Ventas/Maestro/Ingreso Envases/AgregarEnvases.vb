Imports Util.Clases.Query
Public Class AgregarEnvases

    Sub New(ByVal Codigo As Integer, Optional ByVal Descripcion As String = "", Optional ByVal Abreviatura As String = "", Optional ByVal Kilos As String = "", Optional ByVal Tipo As String = "", Optional ByVal Peso As String = "")

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        If Codigo = 0 Then
            Dim SQLCnslt As String = "SELECT NuevoCodigo = Max(Envases)  + 1 FROM Envases WHERE Envases < 9999 "
            Dim row As DataRow = GetSingle(SQLCnslt)

            If row IsNot Nothing Then
                txtCodigo.Text = row.Item("NuevoCodigo")
                cbxTipo.SelectedIndex = 0
            End If
        Else
            txtCodigo.Text = Codigo
            txtDescripcion.Text = Descripcion
            txtAbreviatura.Text = Abreviatura
            txtKilos.Text = Kilos
            If Tipo = "" Then Tipo = 0
            cbxTipo.SelectedIndex = Tipo
            txtPeso.Text = Peso
        End If
    End Sub

    Private Sub NumerosConComas(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtKilos.KeyPress, txtPeso.KeyPress
        If Not Char.IsNumber(e.KeyChar) And Not Char.IsControl(e.KeyChar) And Not (CChar(".")) = e.KeyChar Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtDescripcion_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDescripcion.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                txtAbreviatura.Focus()
            Case Keys.Escape
                txtDescripcion.Text = ""
        End Select
    End Sub

    Private Sub txtAbreviatura_KeyDown(sender As Object, e As KeyEventArgs) Handles txtAbreviatura.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                txtKilos.Focus()
            Case Keys.Escape
                txtAbreviatura.Text = ""
        End Select
    End Sub

    Private Sub txtKilos_KeyDown(sender As Object, e As KeyEventArgs) Handles txtKilos.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                cbxTipo.Focus()
            Case Keys.Escape
                txtKilos.Text = ""
        End Select
    End Sub

   

    Private Sub txtPeso_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPeso.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                btnGrabar_Click(Nothing, Nothing)
            Case Keys.Escape
                txtPeso.Text = ""
        End Select
    End Sub

    Private Sub btnGrabar_Click(sender As Object, e As EventArgs) Handles btnGrabar.Click
        If txtDescripcion.Text <> "" Then
            Dim SQLCnslt As String = "SELECT Envases FROM Envases WHERE Envases = '" & txtCodigo.Text & "'"
            Dim Row As DataRow = GetSingle(SQLCnslt)

            PonerenCeros()
            If Row IsNot Nothing Then
                SQLCnslt = "UPDATE Envases SET Descripcion = '" & txtDescripcion.Text & "' ,  Abreviatura = '" & txtAbreviatura.Text & "' , Kilos = '" & txtKilos.Text & "' ,  Tipo = '" & cbxTipo.SelectedIndex & "' ,  Peso = '" & txtPeso.Text & "' WHERE Envases = '" & txtCodigo.Text & "'"

            Else
                SQLCnslt = "INSERT INTO Envases (Envases, Descripcion,Abreviatura,Kilos,Tipo,Peso) VALUES ('" & txtCodigo.Text & "' , '" & txtDescripcion.Text & "' , '" & txtAbreviatura.Text & "' , '" & txtKilos.Text & "' , '" & cbxTipo.SelectedIndex & "' , '" & txtPeso.Text & "' ) "
            End If
            ExecuteNonQueries({SQLCnslt})
            Dim WOwner As IAgregarEnvase = TryCast(Owner, IAgregarEnvase)
            If WOwner IsNot Nothing Then
                WOwner._ProcesarDatosEnvases()
            End If
            Close()
        End If
    End Sub


    Private Sub PonerenCeros()
        If Trim(txtKilos.Text) = "" Then
            txtKilos.Text = 0
        End If
      
        If Trim(txtPeso.Text) = "" Then
            txtPeso.Text = 0
        End If

    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Close()
    End Sub

    Private Sub AgregarEnvases_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        txtDescripcion.Focus()
    End Sub

   
    Private Sub cbxTipo_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxTipo.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                txtPeso.Focus()
        End Select
    End Sub
End Class