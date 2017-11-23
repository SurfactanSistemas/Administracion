Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports ClasesCompartidas

Public Class PedirClaveAutorizacion
    Public Property Autorizado As Boolean

    Private Sub TextBox1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox1.KeyDown

        If e.KeyCode = Keys.Enter And Trim(TextBox1.Text) <> "" Then
            _VerificarAutorizacion()
        End If
    End Sub

    Private Sub _VerificarAutorizacion()
        Me.Autorizado = False
        Dim clave As String = Trim(TextBox1.Text)

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT Clave FROM Operador WHERE (Clave = '" & UCase(clave) & "' OR Clave = '" & LCase(clave) & "') and GrabaIV = 'S'")
        Dim dr As SqlDataReader

        SQLConnector.conexionSql(cn, cm)

        Try

            dr = cm.ExecuteReader()

            If dr.HasRows Then

                dr.Read()

                Me.Autorizado = True
                Me.Close()
            Else
                Me.Autorizado = False
                MsgBox("La clave ingresada no es correcta.", vbInformation)
                TextBox1.Focus()
            End If

        Catch ex As Exception
            MsgBox("Hubo un problema al querer consultar la Base de Datos.", MsgBoxStyle.Critical)
            Me.Autorizado = False
            TextBox1.Focus()
            Exit Sub
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try
    End Sub

    Private Sub PedirClaveAutorizacion_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        TextBox1.Focus()
    End Sub
End Class
