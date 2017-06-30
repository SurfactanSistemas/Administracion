Imports System.Data.SqlClient

Public Class CarpetasPagos

    Private _Carpetas As New List(Of Object)

    Public Function Carpetas() As List(Of Object)
        Return _Carpetas
    End Function

    Public Sub Carpetas(ByVal _C As List(Of Object))
        _Carpetas = _C
    End Sub

    Private Sub _ValidarCarpeta(ByVal _Carpeta As String)
        ' Compruebo que no se haya validado antes.
        Dim _C As Object = _Carpetas.FindLast(Function(c) c(0) = _Carpeta)

        If Not IsNothing(_C) Then

            If _C(2) = True Then ' La carpeta ya fue controlada y existe.
                Exit Sub
            End If

        End If

        ' Seguimos en caso de que no se la haya validado con anterioridad.
        Dim _Empresas As New List(Of String) From {"SurfactanSA", "surfactan_II", "Surfactan_III", _
                                                   "Surfactan_IV", "Surfactan_V", "Surfactan_VI", "Surfactan_VII"}
        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT Carpeta, Proveedor FROM Orden WHERE Carpeta = '" & _Carpeta & "'")
        Dim dr As SqlDataReader

        For Each _Empresa As String In _Empresas
            Try
                cn.ConnectionString = _ObtenerConnectionString(_Empresa)
                cm.Connection = cn
                dr = cm.ExecuteReader()

                If dr.HasRows Then
                    dr.Read()
                    _Carpetas.Add({_Carpeta, dr.Item("Proveedor"), True}) ' {Numero de Referencia de Carpeta, Carpeta Válida}.
                    Exit For
                Else
                    MsgBox("Carpeta invalida.", MsgBoxStyle.Information)
                    _Carpetas.Add({_Carpeta, "", False}) ' {Numero de Referencia de Carpeta, Carpeta Válida}.
                    cn.Close()
                    Exit For
                End If

            Catch ex As Exception
                MsgBox("Hubo un problema al querer consultar la Base de Datos.", MsgBoxStyle.Critical)
            Finally

                cn.Close()

            End Try
        Next

        cn.Close()
        cn = Nothing
        cm = Nothing
        dr = Nothing

    End Sub

    Private Function _ObtenerConnectionString(ByVal _Empresa As String)
        Return "Data Source=193.168.0.7;Initial Catalog=" & _Empresa & ";User ID=usuarioadmin; Password=usuarioadmin"
    End Function

    Private Sub CarpetasPagos_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        txtCarpeta1.Focus()
    End Sub

    Private Sub txtCarpeta1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCarpeta1.KeyDown
        If e.KeyData = Keys.Enter Then

            If Trim(txtCarpeta1.Text) <> "" Then
                Me._ValidarCarpeta(Trim(txtCarpeta1.Text))
            End If

            _SaltarA(txtCarpeta2)
        End If
    End Sub

    Private Sub txtCarpeta2_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCarpeta2.KeyDown
        If e.KeyData = Keys.Enter Then

            If Trim(txtCarpeta2.Text) <> "" Then
                Me._ValidarCarpeta(Trim(txtCarpeta2.Text))
            End If

            _SaltarA(txtCarpeta3)
        End If
    End Sub

    Private Sub txtCarpeta3_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCarpeta3.KeyDown
        If e.KeyData = Keys.Enter Then

            If Trim(txtCarpeta3.Text) <> "" Then
                Me._ValidarCarpeta(Trim(txtCarpeta3.Text))
            End If

            _SaltarA(txtCarpeta4)
        End If
    End Sub

    Private Sub txtCarpeta4_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCarpeta4.KeyDown
        If e.KeyData = Keys.Enter Then

            If Trim(txtCarpeta4.Text) <> "" Then
                Me._ValidarCarpeta(Trim(txtCarpeta4.Text))
            End If

            _SaltarA(txtCarpeta5)
        End If
    End Sub

    Private Sub txtCarpeta5_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCarpeta5.KeyDown
        If e.KeyData = Keys.Enter Then

            If Trim(txtCarpeta5.Text) <> "" Then
                Me._ValidarCarpeta(Trim(txtCarpeta5.Text))
            End If

            _SaltarA(txtCarpeta6)
        End If
    End Sub

    Private Sub txtCarpeta6_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyData = Keys.Enter Then

            If Trim(txtCarpeta6.Text) <> "" Then
                Me._ValidarCarpeta(Trim(txtCarpeta6.Text))
            End If

            _SaltarA(txtCarpeta7)
        End If
    End Sub

    Private Sub txtCarpeta7_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyData = Keys.Enter Then

            If Trim(txtCarpeta7.Text) <> "" Then
                Me._ValidarCarpeta(Trim(txtCarpeta7.Text))
            End If

            _SaltarA(txtCarpeta8)
        End If
    End Sub

    Private Sub txtCarpeta8_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCarpeta6.KeyDown
        If e.KeyData = Keys.Enter Then
            If Trim(txtCarpeta1.Text) <> "" Then
                Me._ValidarCarpeta(Trim(txtCarpeta1.Text))
            End If
            _SaltarA(txtCarpeta9)
        End If
    End Sub

    Private Sub txtCarpeta9_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCarpeta7.KeyDown
        If e.KeyData = Keys.Enter Then

            If Trim(txtCarpeta9.Text) <> "" Then
                Me._ValidarCarpeta(Trim(txtCarpeta9.Text))
            End If

            _SaltarA(txtCarpeta10)
        End If
    End Sub

    Private Sub txtCarpeta10_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCarpeta8.KeyDown
        If e.KeyData = Keys.Enter Then

            If Trim(txtCarpeta10.Text) <> "" Then
                Me._ValidarCarpeta(Trim(txtCarpeta10.Text))
            End If

            Me.Close()
        End If
    End Sub

    Private Sub _SaltarA(ByRef SiguienteControl As Control)
        SiguienteControl.Focus()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If _CarpetasValidas() Then
            Me.Close()
        End If
    End Sub

    Private Function _CarpetasValidas() As Boolean
        Dim Carpetas As New List(Of Object) ' Se guardarán las carpetas validadas.
        Dim cantCarpetas As Integer = 0
        Dim _Valor As String = ""
        Dim c As Object = Nothing

        ' Recorro todos los campos disponibles para carpetas.
        For Each _txtCarpeta As TextBox In Me.Panel2.Controls.OfType(Of TextBox)()
            ' Compruebo que contenga datos

            If Trim(_txtCarpeta.Text) <> "" Then

                cantCarpetas += 1 ' Controlamos la cantidad de carpetas ingresadas.

                _Valor = Trim(_txtCarpeta.Text)

                c = _Carpetas.FindLast(Function(_c) _c(0) = _Valor) ' Buscamos si se la validó con anterioridad.

                If Not IsNothing(c) Then

                    If c(2) = True Then ' En caso de que si, se controla de que esté marcada como válida.
                        Carpetas.Add(c)
                    End If

                Else
                    ' En caso de que el valor de la carpeta no se haya encontrado
                    ' pudo haber sido por falta de validacion anterior, asi que se fuerza la validación
                    ' de dicha carpeta y se vuelve a verificar de que sea una carpeta valida.
                    Me._ValidarCarpeta(Trim(_txtCarpeta.Text))
                    c = _Carpetas.FindLast(Function(_c) _c(0) = _Valor)

                    If Not IsNothing(c) Then

                        If c(2) = True Then
                            Carpetas.Add(c)
                        End If

                    End If

                End If
            End If
        Next

        ' Una vez recorridos todos los campos y controlado todas las carpetas,
        'se verifica que el numero de carpetas ingresadas sea el mismo que el de carpetas validas.


        If cantCarpetas <> _Carpetas.Count() Then
            MsgBox("No se ha podido validar el total de las carpetas indicadas." & vbCrLf & vbCrLf _
                 & "Vuelva a verificar e inténtelo nuevamente.", MsgBoxStyle.Critical)
            Return False
        Else
            ' Salimos una vez que todas las carpetas se encuentren validadas.
            Return True
        End If

    End Function

    Private Sub CarpetasPagos_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        If e.KeyData = Keys.Escape Then
            Me.Close()
        End If

    End Sub

    Private Sub CarpetasPagos_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        e.Cancel = Not _CarpetasValidas() ' Cancelamos el cierre en caso de que no hayan carpetas validas.
    End Sub
End Class