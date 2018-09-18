Imports System.Configuration
Imports Inventario.Clases

Public Class Login

    Private _MenuPrincipal As Form = New MenuPrincipal

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Close()
    End Sub

    Private Sub Login_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim tabla As New DataTable

        With tabla
            .Columns.Add("Descripcion")
            .Columns.Add("Base")
            .Rows.Add("SURFACTAN I", "1")
            .Rows.Add("PELLITAL I", "2")
            .Rows.Add("SURFACTAN II", "3")
            .Rows.Add("PELLITAL II", "4")
            .Rows.Add("SURFACTAN III", "5")
            .Rows.Add("PELLITAL III", "8")
            .Rows.Add("SURFACTAN IV", "6")
            .Rows.Add("SURFACTAN V", "7")
            .Rows.Add("PELLITAL V", "9")
            .Rows.Add("SURFACTAN VI", "10")
            .Rows.Add("SURFACTAN VII", "11")
        End With

        With cmbEntity
            .DataSource = tabla
            .DisplayMember = "Descripcion"
            .ValueMember = "Base"
            .SelectedIndex = 0
        End With

        txtPsw.Text = ""
    End Sub

    Private Sub btnAccept_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAccept.Click

        'Globals.empresa = cmbEntity.SelectedItem

        Conexion.EmpresaDeTrabajo = ObtenerEmpresaTrabajoPorId(cmbEntity.SelectedValue)

        ' Validamos la contraseña | Proceso 4 = "Inventario".

        If Not Conexion._Login(txtPsw.Text, cmbEntity.SelectedValue) Then
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

        _MenuPrincipal.Close()

        Dim WInHabilita As Boolean = Not {"POLOK", "OLULA", "GRANADA"}.Contains(txtPsw.Text.ToUpper)

        _MenuPrincipal = New MenuPrincipal(WInHabilita)

        _MenuPrincipal.Show()

        Close()

    End Sub

    Private Function ObtenerEmpresaTrabajoPorId(ByVal WIDEmpresa As Object) As String
        Return Conexion.DeterminarSegunIDIDBasePara(WIDEmpresa)
    End Function

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