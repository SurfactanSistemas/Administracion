Imports Util.Clases
Imports Util.Clases.Query
Imports Util.Clases.Helper
Public Class MinutaBaja_Modificacion
    'Si modifica los mails modificar tambien en MinutaAgenda
    Dim Mails As String = "drodriguez@surfactan.com.ar;hmuller@surfactan.com.ar"
    Dim ID As Integer

    Sub New(ByVal IdTabla As Integer, ByVal DesCliente As String)

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        ID = IdTabla
        txt_ClienteDes.Text = DesCliente

        Dim Row As DataRow = GetSingle("SELECT * FROM DevolucionEnvMinutas WHERE ID ='" & ID & "'")
        If Row IsNot Nothing Then
            txt_Cliente.Text = Row("Cliente")

            If Row("Tipo") = "HojaRu" Then
                cbx_Tipo.SelectedIndex = 0
            Else
                cbx_Tipo.SelectedIndex = 1
            End If

            txt_Cantidad.Text = Row("CantEnvRetirar")

            txt_fecha.Text = Row("FechaRetirar")

        End If
    End Sub

    Private Sub btn_Baja_Click(sender As Object, e As EventArgs) Handles btn_Baja.Click
        If MsgBox("¿Seguro que desea eliminar la minuta?", vbYesNoCancel) = MsgBoxResult.Yes Then
            Try
                Dim SQLCnslt As String = "DELETE FROM DevolucionEnvMinutas WHERE ID ='" & ID & "'"
                ExecuteNonQueries("SurfactanSa", SQLCnslt)
                Close()
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub btn_Cancelar_Click(sender As Object, e As EventArgs) Handles btn_Cancelar.Click
        Close()
    End Sub

    Private Sub btn_Modificar_Click(sender As Object, e As EventArgs) Handles btn_Modificar.Click
        Try


            Dim SQLCnslt As String = ""
            If cbx_Tipo.SelectedIndex = 0 Then
                SQLCnslt = "UPDATE DevolucionEnvMinutas SET " _
                                    & "Tipo = '" & "HojaRu" & "', " _
                                    & "Fecha = '" & Date.Today.ToString("dd/MM/yyyy") & "', " _
                                    & "FechaOrd = '" & ordenaFecha(Date.Today.ToString("dd/MM/yyyy")) & "', " _
                                    & "WDate = '" & Date.Today.ToString("yyyy-MM-dd") & "',  " _
                                    & "FechaRetirar = '" & "" & "', " _
                                    & "CantEnvRetirar = '" & Val(txt_Cantidad.Text) & "' " _
                                    & "WHERE ID = '" & ID & "'"

            Else

                If ValidaFecha(txt_fecha.Text) = "S" Then

                    SQLCnslt = "UPDATE DevolucionEnvMinutas SET " _
                                       & "Tipo = '" & "Camion" & "', " _
                                       & "Fecha = '" & Date.Today.ToString("dd/MM/yyyy") & "', " _
                                       & "FechaOrd = '" & ordenaFecha(Date.Today.ToString("dd/MM/yyyy")) & "', " _
                                       & "WDate = '" & Date.Today.ToString("yyyy-MM-dd") & "',  " _
                                       & "FechaRetirar = '" & txt_fecha.Text & "', " _
                                       & "CantEnvRetirar = '" & Val(txt_Cantidad.Text) & "' " _
                                       & "WHERE ID = '" & ID & "'"


                Else
                    MsgBox("El campo de fecha a retirar es invalido, verificar.")
                    Exit Sub
                End If
            End If

            ExecuteNonQueries({SQLCnslt}, "SurfactanSa")
            If cbx_Tipo.SelectedIndex = 1 Then
                _Generarmails(txt_Cliente.Text, txt_ClienteDes.Text, txt_fecha.Text, Val(txt_Cantidad.Text))
            End If
            Close()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub _Generarmails(ByVal Cliente As String, ByVal DesCliente As String, ByVal FechaRetirar As String, ByVal CantRetirar As String)

        Dim Cuerpo As String = "Se solicita el envio de un camion para retirar la cantidad de " & CantRetirar & " contenedores" _
                               & ", a el cliente " & DesCliente & " (" & Cliente & "). Se acordo que sea enviado" _
                               & " el dia " & FechaRetirar & "."


        Helper._EnviarEmail(Mails, "SOLICITUD DE ENVIO DE CAMION", Cuerpo, {}, True)
    End Sub
End Class