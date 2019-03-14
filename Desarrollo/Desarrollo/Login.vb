Imports System.Configuration
Imports Desarrollo.Clases

Public Class Login

    Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
        Close()
    End Sub

    Private Sub Login_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        cmbEntity.SelectedIndex = 0
        txtPsw.Text = ""
    End Sub

    Private Sub btnAccept_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAccept.Click

        'Globals.empresa = cmbEntity.SelectedItem

        Conexion.EmpresaDeTrabajo = cmbEntity.SelectedItem

        ' Validamos la contraseña | Proceso 4 = "Desarrollo".

        If Not Conexion._Login(txtPsw.Text, 4) Then
            MsgBox("La contraseña no es correcta.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        If _EsPellital() Then
            ' En caso de ser PELLITAL, validamos que la conexion se haga desde una pc con Permisos. Los mismos se definen segun nombre de PC.

            If Not _PermisosPellitalValidos() Then

                MsgBox("No tiene los permisos necesarios para poder ingresar a esta Empresa.", MsgBoxStyle.Exclamation)

                Exit Sub

            End If

        End If

        MenuPrincipal.Show()

        '_MenuPrincipal.Close()

        '_MenuPrincipal = New MenuPrincipal

        '_MenuPrincipal.Show()

        Close()

    End Sub

    Private Function _PermisosPellitalValidos() As Boolean

        Dim WPermitidos() = ConfigurationManager.AppSettings("PERMISOS_PELLITAL").ToString.Split(",")
        Dim WNombrePC = getNombrePC()

        Return (From N In WPermitidos Where UCase(Trim(N)) = UCase(Trim(WNombrePC))).Any()

    End Function

    Private Sub Login_Shown(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Shown
        txtPsw.Focus()
    End Sub

    Private Sub txtPsw_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtPsw.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txtPsw.Text) = "" Then : Exit Sub : End If

            btnAccept.PerformClick()

        ElseIf e.KeyData = Keys.Escape Then
            txtPsw.Text = ""
        End If

    End Sub

End Class