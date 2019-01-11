Imports System.Configuration
Imports SAC.Clases

Public Class Login

    Private WAbiertoporComando As Boolean = False

    Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
        Close()
    End Sub

    Private Sub Login_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load

        Dim tabla As New DataTable
        With tabla
            .Columns.Add("Empresa")
            .Columns.Add("Base")
            .Rows.Add("SURFACTAN S.A.", "SurfactanSa")
            .Rows.Add("PELLITAL S.A.", "Pellital_III")
        End With

        With cmbEntity
            .DataSource = tabla
            .DisplayMember = "Empresa"
            .ValueMember = "Base"
            .SelectedIndex = 0
        End With

        txtPsw.Text = ""

        Try
            '
            ' Chequeamos que se haya abierto por linea de comandos.
            '
            If Environment.GetCommandLineArgs.Length > 1 Then
                Dim WTipo As String = Environment.GetCommandLineArgs(1)
                Dim WNumero As String = Environment.GetCommandLineArgs(2)
                Dim WAnio As String = Environment.GetCommandLineArgs(3)

                With New NuevoSac(WTipo, WNumero, WAnio, True)
                    .Show()
                End With

                btnCancel_Click(Nothing, Nothing)
            End If
        Catch ex As Exception
            btnCancel_Click(Nothing, Nothing)
        End Try

    End Sub

    Private Sub btnAccept_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAccept.Click

        'Globals.empresa = cmbEntity.SelectedItem

        Conexion.EmpresaDeTrabajo = cmbEntity.SelectedValue

        ' Validamos la contraseña.

        If Not Conexion._Login(txtPsw.Text, 4) Then
            MsgBox("La contraseña no es correcta.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        If _EsPellital Then
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
        Dim WNombrePC = getNombrePC

        Return (From N In WPermitidos Where UCase(Trim(N)) = UCase(Trim(WNombrePC))).Any()

    End Function

    Private Sub Login_Shown(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Shown
        If WAbiertoporComando Then
            btnCancel_Click(Nothing, Nothing)
        End If
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