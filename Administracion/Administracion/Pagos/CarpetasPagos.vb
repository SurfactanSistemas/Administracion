Imports System.Data.SqlClient

Public Class CarpetasPagos

    Private _Carpetas(10) As String

    Public Function Carpetas() As String()
        Return _Carpetas
    End Function

    Public Sub Carpetas(ByVal _C As String())
        _Carpetas = _C
    End Sub

    Private Function _ValidarCarpeta(ByVal _Carpeta As String) As Boolean
        Dim valida = False
        ' Seguimos en caso de que no se la haya validado con anterioridad.
        Dim _Empresas = Proceso.Empresas
        Dim cn = New SqlConnection()
        Dim cm = New SqlCommand("SELECT Carpeta, Proveedor FROM Orden WHERE Carpeta = '" & _Carpeta & "'")
        Dim dr As SqlDataReader

        For Each _Empresa As String In _Empresas
            Try
                cn.ConnectionString = _ObtenerConnectionString(_Empresa)
                cn.Open()
                cm.Connection = cn
                dr = cm.ExecuteReader()

                If dr.HasRows Then
                    valida = True
                    Exit For
                End If

            Catch ex As Exception
                MsgBox("Hubo un problema al querer validar la carpeta indicada en la Base de Datos.", MsgBoxStyle.Critical)
            Finally

                cn.Close()

            End Try
        Next

        cn.Close()
        cn = Nothing
        cm = Nothing
        dr = Nothing

        Return valida

    End Function

    Private Function _ObtenerConnectionString(ByVal _Empresa As String)
        Dim cs = Configuration.ConfigurationManager.ConnectionStrings(ClasesCompartidas.Globals.empresa).ToString
        Dim Wrem = "SurfactanSA"

        If Proceso._EsPellital Then
            Wrem = "Pellital_III"
        End If

        Return cs.Replace("Catalog=" & Wrem, "Catalog=" & _Empresa) '"Data Source=193.168.0.7;Initial Catalog=" & _Empresa & ";User ID=usuarioadmin; Password=usuarioadmin"
    End Function

    Private Sub CarpetasPagos_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        txtCarpeta1.Focus()
    End Sub

    Private Sub txtCarpeta1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCarpeta1.KeyDown
        If e.KeyData = Keys.Enter Then

            If Trim(txtCarpeta1.Text) <> "" Then
                If _ValidarCarpeta(Trim(txtCarpeta1.Text)) Then

                    _Carpetas(1) = txtCarpeta1.Text

                    _SaltarA(txtCarpeta2)
                Else
                    txtCarpeta1.Focus()
                End If
            Else
                _SaltarA(txtCarpeta2)
            End If

        End If
    End Sub

    Private Sub txtCarpeta2_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCarpeta2.KeyDown
        If e.KeyData = Keys.Enter Then
            If Trim(txtCarpeta2.Text) <> "" Then
                If _ValidarCarpeta(Trim(txtCarpeta2.Text)) Then

                    _Carpetas(2) = txtCarpeta2.Text

                    _SaltarA(txtCarpeta3)
                Else
                    txtCarpeta2.Focus()
                End If
            Else
                _SaltarA(txtCarpeta3)
            End If
        End If
    End Sub

    Private Sub txtCarpeta3_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCarpeta3.KeyDown
        If e.KeyData = Keys.Enter Then
            If Trim(txtCarpeta3.Text) <> "" Then
                If _ValidarCarpeta(Trim(txtCarpeta3.Text)) Then

                    _Carpetas(3) = txtCarpeta3.Text

                    _SaltarA(txtCarpeta4)
                Else
                    txtCarpeta3.Focus()
                End If
            Else
                _SaltarA(txtCarpeta4)
            End If
        End If
    End Sub

    Private Sub txtCarpeta4_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCarpeta4.KeyDown
        If e.KeyData = Keys.Enter Then
            If Trim(txtCarpeta4.Text) <> "" Then
                If _ValidarCarpeta(Trim(txtCarpeta4.Text)) Then

                    _Carpetas(4) = txtCarpeta4.Text

                    _SaltarA(txtCarpeta5)
                Else
                    txtCarpeta4.Focus()
                End If
            Else
                _SaltarA(txtCarpeta5)
            End If
        End If
    End Sub

    Private Sub txtCarpeta5_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCarpeta5.KeyDown
        If e.KeyData = Keys.Enter Then
            If Trim(txtCarpeta5.Text) <> "" Then
                If _ValidarCarpeta(Trim(txtCarpeta5.Text)) Then

                    _Carpetas(5) = txtCarpeta5.Text

                    _SaltarA(txtCarpeta6)
                Else
                    txtCarpeta5.Focus()
                End If
            Else
                _SaltarA(txtCarpeta6)
            End If
        End If
    End Sub

    Private Sub txtCarpeta6_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyData = Keys.Enter Then
            If Trim(txtCarpeta6.Text) <> "" Then
                If _ValidarCarpeta(Trim(txtCarpeta6.Text)) Then

                    _Carpetas(6) = txtCarpeta6.Text

                    _SaltarA(txtCarpeta7)
                Else
                    txtCarpeta6.Focus()
                End If
            Else
                _SaltarA(txtCarpeta7)
            End If
        End If
    End Sub

    Private Sub txtCarpeta7_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyData = Keys.Enter Then
            If Trim(txtCarpeta7.Text) <> "" Then
                If _ValidarCarpeta(Trim(txtCarpeta7.Text)) Then

                    _Carpetas(7) = txtCarpeta7.Text

                    _SaltarA(txtCarpeta8)
                Else
                    txtCarpeta7.Focus()
                End If
            Else
                _SaltarA(txtCarpeta8)
            End If
        End If
    End Sub

    Private Sub txtCarpeta8_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCarpeta6.KeyDown
        If e.KeyData = Keys.Enter Then
            If Trim(txtCarpeta8.Text) <> "" Then
                If _ValidarCarpeta(Trim(txtCarpeta8.Text)) Then

                    _Carpetas(8) = txtCarpeta8.Text

                    _SaltarA(txtCarpeta9)
                Else
                    txtCarpeta8.Focus()
                End If
            Else
                _SaltarA(txtCarpeta9)
            End If
        End If
    End Sub

    Private Sub txtCarpeta9_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCarpeta7.KeyDown
        If e.KeyData = Keys.Enter Then
            If Trim(txtCarpeta9.Text) <> "" Then
                If _ValidarCarpeta(Trim(txtCarpeta9.Text)) Then

                    _Carpetas(9) = txtCarpeta9.Text

                    _SaltarA(txtCarpeta10)
                Else
                    txtCarpeta9.Focus()
                End If
            Else
                _SaltarA(txtCarpeta10)
            End If
        End If
    End Sub

    Private Sub txtCarpeta10_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCarpeta8.KeyDown
        If e.KeyData = Keys.Enter Then

            If Trim(txtCarpeta10.Text) <> "" Then
                If _ValidarCarpeta(Trim(txtCarpeta10.Text)) Then

                    _Carpetas(10) = txtCarpeta10.Text

                    Me.Close()
                Else
                    txtCarpeta10.Focus()
                End If
            Else
                Me.Close()
            End If

        End If
    End Sub

    Private Sub _SaltarA(ByRef SiguienteControl As Control)
        SiguienteControl.Focus()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If ValidarTodosLosTextBox() Then
            _AsignarCarpetas()
            Me.Close()
        End If
    End Sub
    
    Private Sub CarpetasPagos_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If ValidarTodosLosTextBox() Then
            _AsignarCarpetas()
        End If
    End Sub


    Private Sub _AsignarCarpetas()
        _Carpetas(1) = txtCarpeta1.Text
        _Carpetas(2) = txtCarpeta2.Text
        _Carpetas(3) = txtCarpeta3.Text
        _Carpetas(4) = txtCarpeta4.Text
        _Carpetas(5) = txtCarpeta5.Text
        _Carpetas(6) = txtCarpeta6.Text
        _Carpetas(7) = txtCarpeta7.Text
        _Carpetas(8) = txtCarpeta8.Text
        _Carpetas(9) = txtCarpeta9.Text
        _Carpetas(10) = txtCarpeta10.Text
    End Sub

    Private Sub CarpetasPagos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        For i = 1 To 10
            Panel2.Controls("txtCarpeta" & i).Text = Trim(_Carpetas(i))
            AddHandler Panel2.Controls("txtCarpeta" & i).KeyPress, AddressOf SoloNumero
        Next
    End Sub

    Private Sub SoloNumero(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Not Char.IsNumber(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub


    Private Function ValidarTodosLosTextBox() As Boolean
        Dim Respuesta As Boolean = True
        For Each control As TextBox In Me.Panel2.Controls.OfType(Of TextBox)()
            If Trim(control.Text) <> "" Then
                If Not _ValidarCarpeta(Trim(control.Text)) Then
                    MsgBox("Se detecto una carpeta no valida." & vbCrLf _
                           & "Puede revisar los numeros ingresados y dar Enter " _
                           & "en el campo para saber si es valido", vbExclamation, vbOK)
                    Respuesta = False
                    Return Respuesta
                End If
            End If

        Next

        Return Respuesta
    End Function

End Class