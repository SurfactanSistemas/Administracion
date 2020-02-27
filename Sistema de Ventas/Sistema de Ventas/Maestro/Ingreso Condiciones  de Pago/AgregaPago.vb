Imports ConsultasVarias.Clases.Query
Public Class AgregaPago

    Sub New(ByVal Codigo As Integer, Optional ByVal Nombre As String = "", Optional ByVal Dias As String = "", Optional ByVal Plazo As String = "", Optional ByVal Tasa As String = "", Optional ByVal Descuento As String = "")

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        If Codigo = 0 Then
            Dim SQLCnslt As String = "SELECT NuevoCodigo = Max(Pago) + 1 FROM Pago "
            Dim row As DataRow = GetSingle(SQLCnslt)

            If row IsNot Nothing Then
                txtCodigo.Text = row.Item("NuevoCodigo")
            End If
        Else
            txtCodigo.Text = Codigo
            txtNombre.Text = Nombre
            txtDias.Text = Dias
            txtPlazo.Text = Plazo
            txtTasa.Text = Tasa
            txtDescuento.Text = Descuento
        End If
    End Sub



    Private Sub SoloNumero(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDias.KeyPress, txtTasa.KeyPress, txtPlazo.KeyPress, txtDescuento.KeyPress
        If Not Char.IsNumber(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub



    Private Sub btnGrabar_Click(sender As Object, e As EventArgs) Handles btnGrabar.Click
        If txtNombre.Text <> "" Then
            Dim SQLCnslt As String = "SELECT Pago FROM Pago WHERE Pago = '" & txtCodigo.Text & "'"
            Dim Row As DataRow = GetSingle(SQLCnslt)

            If Row IsNot Nothing Then
                SQLCnslt = "UPDATE Pago SET Nombre = '" & txtNombre.Text & "', Dias = '" & txtDias.Text & "' , Plazo = '" & txtPlazo.Text & "' , Tasa = '" & txtTasa.Text & "' , Descuento = '" & txtDescuento.Text & "' WHERE Pago = '" & txtCodigo.Text & "'"

            Else
                SQLCnslt = "INSERT INTO Pago (Pago, Nombre, Dias, Plazo, Tasa, Descuento) VALUES ('" & txtCodigo.Text & "' , '" & txtNombre.Text & "',  '" & txtDias.Text & "' , '" & txtPlazo.Text & "' ,  '" & txtTasa.Text & "' , '" & txtDescuento.Text & "' ) "
            End If
            ExecuteNonQueries({SQLCnslt})
            Dim WOwner As IAgregarPago = TryCast(Owner, IAgregarPago)
            If WOwner IsNot Nothing Then
                WOwner._ProcesarDatosPago()
            End If
            Close()
        End If
    End Sub

    Private Sub AgregaPago_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        txtNombre.Focus()
    End Sub
End Class