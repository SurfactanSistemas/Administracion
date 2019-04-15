Imports System.Configuration
Imports System.IO
Imports CrystalDecisions.Shared
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

                Dim WTipoLlamada As Integer = Environment.GetCommandLineArgs(1)

                
                Select Case WTipoLlamada
                    Case 1

                        Dim WTipo As String = Environment.GetCommandLineArgs(2)
                        Dim WNumero As String = Environment.GetCommandLineArgs(3)
                        Dim WAnio As String = Environment.GetCommandLineArgs(4)

                        With New NuevoSac(WTipo, WNumero, WAnio, True)
                            .Show()
                        End With

                    Case 2 ' Envío de SAC por Mail

                        Dim WTipo As String = Environment.GetCommandLineArgs(2)
                        Dim WNumero As String = Environment.GetCommandLineArgs(3)
                        Dim WAnio As String = Environment.GetCommandLineArgs(4)
                        Dim WDirecciones As String = Environment.GetCommandLineArgs(5)
                        Dim WAsunto As String = Environment.GetCommandLineArgs(6)
                        Dim WCuerpoMsj As String = Environment.GetCommandLineArgs(7)

                        Dim frm As New ConsultasVarias.VistaPrevia

                        With frm

                            .Reporte = New NuevoSACAmbos

                            .Formula = "{CargaSac.Tipo} = " & WTipo & " And {CargaSac.Numero} = " & WNumero & " And {CargaSac.Ano} = " & WAnio & ""

                        End With

                        ConsultasVarias.Clases.Conexion.EmpresaDeTrabajo = "SurfactanSa"
                        ConsultasVarias.Clases.Helper._ExportarReporte(frm, ConsultasVarias.Clases.Enumeraciones.FormatoExportacion.PDF, WTipo & WNumero & WAnio & ".pdf", "C:\TempReclamos\")

                        If IO.File.Exists("C:\TempReclamos\" & WTipo & WNumero & WAnio & ".pdf") Then
                            ConsultasVarias.Clases.Helper._EnviarEmail(WDirecciones, WAsunto, WCuerpoMsj, {"C:\TempReclamos\" & WTipo & WNumero & WAnio & ".pdf"}, False)
                        End If

                    Case 3

                        Dim WNumero As String = Environment.GetCommandLineArgs(2)
                        Dim WDirecciones As String = Environment.GetCommandLineArgs(3)
                        Dim WAsunto As String = Environment.GetCommandLineArgs(4)
                        Dim WCuerpoMsj As String = Environment.GetCommandLineArgs(5)

                        Dim frm As New ConsultasVarias.VistaPrevia

                        With frm

                            .Reporte = New ReclamoClienteAvisoMail

                            .Formula = "{CentroReclamos.Numero} = " & WNumero & ""

                        End With

                        ConsultasVarias.Clases.Conexion.EmpresaDeTrabajo = "SurfactanSa"
                        ConsultasVarias.Clases.Helper._ExportarReporte(frm, ConsultasVarias.Clases.Enumeraciones.FormatoExportacion.PDF, WNumero & "Reclamo.pdf", "C:\TempReclamos\")

                        If IO.File.Exists("C:\TempReclamos\" & WNumero & "Reclamo.pdf") Then
                            ConsultasVarias.Clases.Helper._EnviarEmail(WDirecciones, WAsunto, WCuerpoMsj, {"C:\TempReclamos\" & WNumero & "Reclamo.pdf"}, False)
                        End If
                    Case 4

                        Dim WNumero As String = Environment.GetCommandLineArgs(2)
                        Dim WDirecciones As String = Environment.GetCommandLineArgs(3)
                        Dim WAsunto As String = Environment.GetCommandLineArgs(4)
                        Dim WCuerpoMsj As String = Environment.GetCommandLineArgs(5)

                        Dim frm As New ConsultasVarias.VistaPrevia

                        With frm
                            .Reporte = New ReporteINCIndividual
                            .Formula = "{CargaIncidencias.Incidencia} = " & WNumero

                            .Reporte.SetParameterValue("MostrarPosiblesUsos", 1)
                            .Reporte.SetParameterValue("MostrarAcciones", 0)

                            Dim WNombreArchivo = String.Format("INC {0} - {1}", WNumero.PadLeft(4, "0"), Date.Now.ToString("dd-MM-yyyy"))

                            Dim WRuta = "C:/tempIndice/"

                            WNombreArchivo &= ".pdf"

                            If Directory.Exists(WRuta) Then Directory.Delete(WRuta, True)

                            Directory.CreateDirectory(WRuta)

                            ConsultasVarias.Clases.Conexion.EmpresaDeTrabajo = "SurfactanSa"
                            ConsultasVarias.Clases.Helper._ExportarReporte(frm, ConsultasVarias.Clases.Enumeraciones.FormatoExportacion.PDF, WNombreArchivo, WRuta)

                            If File.Exists(WRuta & WNombreArchivo) Then
                                ConsultasVarias.Clases.Helper._EnviarEmail(WDirecciones, WAsunto, WCuerpoMsj, {WRuta & WNombreArchivo}, False)
                            End If

                        End With

                End Select

                btnCancel_Click(Nothing, Nothing)


            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            btnCancel_Click(Nothing, Nothing)
        End Try

    End Sub

    Private Sub btnAccept_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAccept.Click

        'Globals.empresa = cmbEntity.SelectedItem

        Conexion.EmpresaDeTrabajo = CType(cmbEntity.SelectedItem, DataRowView).Item("Base")

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