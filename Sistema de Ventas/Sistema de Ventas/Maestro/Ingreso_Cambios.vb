Imports Util
Imports Util.Clases.Query
Imports Util.Clases.Helper
Public Class Ingreso_Cambios: Implements IConsultaCambios

    Private Sub Ingreso_Cambios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        mastxtFecha.Text = Date.Today.ToString("dd/MM/yyyy")

    End Sub

    Private Sub NumerosConComas(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtReflex120.KeyPress, txtReflex90.KeyPress, txtReflex60.KeyPress, txtReflex30.KeyPress, txtDivisa.KeyPress, txtEuro.KeyPress, txtDolar.KeyPress
        If Not Char.IsNumber(e.KeyChar) And Not Char.IsControl(e.KeyChar) And Not (CChar(".")) = e.KeyChar Then
            e.Handled = True
        End If
    End Sub


    Private Sub mastxtFecha_KeyDown(sender As Object, e As KeyEventArgs) Handles mastxtFecha.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                If _ValidarFecha(mastxtFecha.Text) Then
                    txtDolar.Focus()
                    txtDolar.Select()
                End If

            Case Keys.Escape
                mastxtFecha.Text = ""
        End Select
    End Sub

    Private Sub txtDolar_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDolar.KeyDown
        Select Case e.KeyData
            Case Keys.Enter

                txtEuro.Focus()
                txtEuro.Select()

            Case Keys.Escape
                txtDolar.Text = "0.000"
        End Select
    End Sub

    Private Sub txtEuro_KeyDown(sender As Object, e As KeyEventArgs) Handles txtEuro.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                txtDivisa.Focus()
                txtDivisa.Select()
            Case Keys.Escape
                txtEuro.Text = "0.000"
        End Select
    End Sub

    Private Sub txtDivisa_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDivisa.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                txtReflex30.Focus()
                txtReflex30.Select()
            Case Keys.Escape
                txtDivisa.Text = "0.000"
        End Select
    End Sub

    Private Sub txtReflex30_KeyDown(sender As Object, e As KeyEventArgs) Handles txtReflex30.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                txtReflex60.Focus()
                txtReflex60.Select()
            Case Keys.Escape
                txtReflex30.Text = "0.000"
        End Select
    End Sub

    Private Sub txtReflex60_KeyDown(sender As Object, e As KeyEventArgs) Handles txtReflex60.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                txtReflex90.Focus()
                txtReflex90.Select()
            Case Keys.Escape
                txtReflex60.Text = "0.000"
        End Select
    End Sub

    Private Sub txtReflex90_KeyDown(sender As Object, e As KeyEventArgs) Handles txtReflex90.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                txtReflex120.Focus()
                txtReflex120.Select()
            Case Keys.Escape
                txtReflex90.Text = "0.000"
        End Select
    End Sub

    Private Sub txtReflex120_KeyDown(sender As Object, e As KeyEventArgs) Handles txtReflex120.KeyDown
        Select Case e.KeyData
        Case Keys.Escape
                txtReflex120.Text = "0.000"
        End Select
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Close()
    End Sub

    Private Sub Consulta_Click(sender As Object, e As EventArgs) Handles Consulta.Click
        With Consulta_Cambios
            .Show(Me)
        End With
    End Sub

    Public Sub PasarDatos(Fecha As String, Dolar As String, Euro As String, divisa As String, Reflex30 As String, Reflex60 As String, Reflex90 As String, Reflex120 As String) Implements IConsultaCambios.PasarDatos
        mastxtFecha.Text = Fecha
        txtDolar.Text = Dolar
        txtEuro.Text = Euro
        txtDivisa.Text = divisa
        txtReflex30.Text = Reflex30
        txtReflex60.Text = Reflex60
        txtReflex90.Text = Reflex90
        txtReflex120.Text = Reflex120
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim SQLCnslt As String
        Dim Existe As String = "N"
        If mastxtFecha.Text <> "" Then
            If ValidaFecha(mastxtFecha.Text) = "S" Then
                SQLCnslt = "SELECT Fecha FROM Cambios WHERE OrdFecha = '" & ordenaFecha(mastxtFecha.Text) & "'"
                Dim row As DataRow = GetSingle(SQLCnslt, "SurfactanSa")
                If row IsNot Nothing Then
                    Existe = "S"
                End If

                If Existe = "S" Then
                    If MsgBox("Desea Borrar el Registro para la fecha: " & mastxtFecha.Text, vbYesNo) = vbYes Then
                        SQLCnslt = "DELETE Cambios WHERE OrdFecha = '" & ordenaFecha(mastxtFecha.Text) & "'"
                        ExecuteNonQueries({SQLCnslt})

                    End If
                End If
            End If
        End If
        
    End Sub


    Private Sub btnGrabar_Click(sender As Object, e As EventArgs) Handles btnGrabar.Click
        If mastxtFecha.Text <> "" Then
            If Val(txtDolar.Text) > 0 And Val(txtDivisa.Text) > 0 Then
                Dim SQLcnslt As String = "SELECT Fecha FROM Cambios WHERE OrdFecha = '" & ordenaFecha(mastxtFecha.Text) & "'"
                Dim row As DataRow = GetSingle(SQLcnslt)
                If row IsNot Nothing Then
                    SQLcnslt = "UPDATE Cambios SET Cambio = '" & eliminaComas(txtDolar.Text) & "', " _
                             & " CambioII = '" & eliminaComas(txtEuro.Text) & "', " _
                             & " CambioDivisa = '" & eliminaComas(txtDivisa.Text) & "', " _
                             & " CambioIII = '" & eliminaComas(txtReflex30.Text) & "', " _
                             & " CambioIV = '" & eliminaComas(txtReflex60.Text) & "', " _
                             & " CambioV = '" & eliminaComas(txtReflex90.Text) & "', " _
                             & " CambioVI = '" & eliminaComas(txtReflex120.Text) & "' " _
                             & "WHERE OrdFecha = '" & ordenaFecha(mastxtFecha.Text) & "'"
                Else
                    SQLcnslt = "INSERT INTO Cambios (Fecha, Cambio, OrdFecha, CambioII, CambioDivisa, " _
                             & "CambioIII, CambioIV, CambioV, CambioVI) VALUES('" & mastxtFecha.Text & "', " _
                             & "'" & eliminaComas(txtDolar.Text) & "', '" & ordenaFecha(mastxtFecha.Text) & "', '" & eliminaComas(txtEuro.Text) & "', " _
                             & "'" & eliminaComas(txtDivisa.Text) & "', '" & eliminaComas(txtReflex30.Text) & "', '" & eliminaComas(txtReflex60.Text) & "', " _
                             & "'" & eliminaComas(txtReflex90.Text) & "', '" & eliminaComas(txtReflex120.Text) & "')"
                End If

                ExecuteNonQueries({SQLcnslt})
            Else
                MsgBox("Asegurese de que esten cargadas las paridad para DOLAR y para U$S Divisa", vbOK)
            End If
        End If
    End Sub

    Function eliminaComas(ByVal numero As String)
        Return numero.Replace(",", ".")
    End Function
    
    Private Sub btnListado_Click(sender As Object, e As EventArgs) Handles btnListado.Click
        With Listar_Cambios
            .Show()
        End With
    End Sub
End Class