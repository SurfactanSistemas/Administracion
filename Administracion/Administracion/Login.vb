Imports System.Configuration
Imports System.Net
Imports ClasesCompartidas
Imports EvaluacionProvMPFarma

Public Class Login
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Close()
    End Sub

    Private Sub Login_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            btnAccept.PerformClick()
        End If
    End Sub

    Private Sub Login_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cmbEntity.DataSource = Globals.connectionStringNames()

        If Environment.GetCommandLineArgs().Length > 1 Then

            Globals.empresa = "SURFACTAN"

            With New EvaluacionProveedorMateriaPrima("", True)
                .Show()
            End With

            Close()

        End If

    End Sub

    Private Function validarCampos()
        Dim validador As New Validator
        validador.validate(Me)
        validador.alsoValidate(Globals.connectionWorksFor(cmbEntity.Text), "La conexión con la base de datos falló")
        Return validador.flush()
    End Function

    Private Sub btnAccept_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAccept.Click
        If validarCampos() Then
            Globals.empresa = cmbEntity.Text

            If Proceso._EsPellital Then
                ' En caso de ser PELLITAL, validamos que la conexion se haga desde una pc con Permisos. Los mismos se definen segun nombre de PC.

                If Not _PermisosPellitalValidos() Then

                    MsgBox("No tiene los permisos necesarios para poder ingresar a esta Empresa.", MsgBoxStyle.Exclamation)

                    Exit Sub

                End If

            End If

            Util.Operador.Base = IIf(_EsPellital, "pellitalSa", "SurfactanSa")

            MenuPrincipal.Show()
            Close()
        End If
    End Sub

    Private Function _PermisosPellitalValidos() As Boolean

        Dim WPermitidos() = ConfigurationManager.AppSettings("PERMISOS_PELLITAL").ToString.Split(",")
        Dim WNombrePC = Proceso.getNombrePC

        Return (From N In WPermitidos Where UCase(Trim(N)) = UCase(Trim(WNombrePC))).Any()

    End Function
End Class