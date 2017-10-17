Imports System.Data.SqlClient

Public Class Login

    Private Sub Login_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Globales.Operador = ""
    End Sub

    Private Sub btnAcceder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAcceder.Click

        txtClave.Text = Trim(txtClave.Text)

        If Trim(txtClave.Text) = "" Then : Exit Sub : End If

        Try
            _Acceder()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try

        ' Salimos si no encontramos a un usuario con esa contraseña.
        If Trim(Globales.Operador) = "" Then

            MsgBox("La clave introducida no es una Clave Válida. Por favor, inténte nuevamente.", MsgBoxStyle.Information)

            txtClave.Focus()
            txtClave.SelectAll()
            Exit Sub
        End If

        MenuPrincipal.Show()
        Hide()

    End Sub

    Private Sub _Acceder()
        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT Operador FROM Operador WHERE Clave = '" & UCase(txtClave.Text) & "' Or Clave = '" & LCase(txtClave.Text) & "'")
        Dim dr As SqlDataReader

        Try

            cn.ConnectionString = Helper._ConectarA
            cn.Open()
            cm.Connection = cn

            dr = cm.ExecuteReader()

            If dr.HasRows Then
                dr.Read()

                Globales.Operador = IIf(IsDBNull(dr.Item("Operador")), "", Trim(dr.Item("Operador")))

            End If

        Catch ex As Exception
            Throw New Exception("Hubo un problema al querer consultar la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

    End Sub

    Private Sub txtClave_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtClave.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txtClave.Text) = "" Then : Exit Sub : End If

            btnAcceder.PerformClick()

        ElseIf e.KeyData = Keys.Escape Then
            txtClave.Text = ""
        End If

    End Sub
End Class
