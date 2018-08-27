Imports System.Configuration
Imports Sedronar.Clases

Public Class Login

    Private _MenuPrincipal As Form = New MenuPrincipal

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Close()
    End Sub

    Private Sub Login_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim tabla As New DataTable

        With tabla
            With .Columns
                .Add("Empresa")
                .Add("Base")
            End With
            With .Rows
                .Add("SURFACTAN I", "SurfactanSa")
                .Add("SURFACTAN II", "Surfactan_II")
                .Add("SURFACTAN III", "Surfactan_III")
                .Add("SURFACTAN IV", "Surfactan_IV")
                .Add("SURFACTAN V", "Surfactan_V")
                .Add("SURFACTAN VI", "Surfactan_VI")
                .Add("SURFACTAN VII", "Surfactan_VII")
                .Add("PELLITAL I", "PellitalSa")
                .Add("PELLITAL II", "Pelitall_II") ' Está escrito asi en el servidor.
                .Add("PELLITAL III", "Pelitall_III")
                .Add("PELLITAL V", "Pelitall_V")
            End With
        End With

        With cmbEntity
            .DataSource = tabla
            .DisplayMember = "Empresa"
            .ValueMember = "Base"
            .SelectedIndex = 0
        End With

        txtPsw.Text = ""

    End Sub

    Private Sub btnAccept_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAccept.Click

        'Globals.empresa = cmbEntity.SelectedItem

        If txtPsw.Text.Trim = "" Then Exit Sub
        
        Conexion.EmpresaDeTrabajo = cmbEntity.SelectedValue

        ' Validamos la contraseña | Proceso 4 = "Sedronar".

        If Not Conexion._Login(txtPsw.Text, 4) Then
            MsgBox("La contraseña no es correcta.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        If Helper._EsPellital Then
            ' En caso de ser PELLITAL, validamos que la conexion se haga desde una pc con Permisos. Los mismos se definen segun nombre de PC.

            If Not _PermisosPellitalValidos() Then

                MsgBox("No tiene los permisos necesarios para poder ingresar a esta Empresa.", MsgBoxStyle.Exclamation)

                Exit Sub

            End If

        End If

        MenuPrincipal.Show()

        Close()
    End Sub

    Private Function _PermisosPellitalValidos() As Boolean

        Dim WPermitidos() = ConfigurationManager.AppSettings("PERMISOS_PELLITAL").ToString.Split(",")
        Dim WNombrePC = Helper.getNombrePC

        Return (From N In WPermitidos Where UCase(Trim(N)) = UCase(Trim(WNombrePC))).Any()

    End Function

    Private Sub Login_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        txtPsw.Focus()
    End Sub

    Private Sub txtPsw_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPsw.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txtPsw.Text) = "" Then : Exit Sub : End If

            btnAccept.PerformClick()

        ElseIf e.KeyData = Keys.Escape Then
            txtPsw.Text = ""
        End If

    End Sub

End Class