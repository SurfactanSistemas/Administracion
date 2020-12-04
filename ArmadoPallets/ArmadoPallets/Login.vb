Imports System.Configuration
Imports ArmadoPallets.Clases
Imports Util
Imports Util.Clases.Conexion
Imports Util.Clases.Query

Public Class Login
    
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Close()
    End Sub

    Private Sub Login_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cmbEntity.SelectedIndex = 0
        txtPsw.Text = ""
        EmpresaDeTrabajo = "surfactansa"
    End Sub

    Private Sub btnAccept_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAccept.Click

        'Globals.empresa = cmbEntity.SelectedItem

        Conexion.EmpresaDeTrabajo = cmbEntity.SelectedItem

        ' Validamos la contraseña

        If Not Conexion._Login(txtPsw.Text) Then
            MsgBox("La contraseña no es correcta.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        Dim WOperador As DataRow = GetSingle("SELECT Operador, Descripcion, SistemaExportacion FROM Operador WHERE UPPER(Clave) = '" & txtPsw.Text & "'", "SurfactanSa")

        If IsNothing(WOperador) Then Throw New Exception("Clave Errónea")


        With WOperador
            Operador.Base = "SurfactanSa"
            Operador.Codigo = IIf(IsDBNull(.Item("Operador")), 0, .Item("Operador"))
            Operador.Clave = txtPsw.Text.Trim
            Operador.Descripcion = IIf(IsDBNull(.Item("Descripcion")), "", .Item("Descripcion"))
        End With
        
        If Helper._EsPellital Then
            ' En caso de ser PELLITAL, validamos que la conexion se haga desde una pc con Permisos. Los mismos se definen segun nombre de PC.

            If Not _PermisosPellitalValidos() Then

                MsgBox("No tiene los permisos necesarios para poder ingresar a esta Empresa.", MsgBoxStyle.Exclamation)

                Exit Sub

            End If

        End If

        ListadoProformas.Show()

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