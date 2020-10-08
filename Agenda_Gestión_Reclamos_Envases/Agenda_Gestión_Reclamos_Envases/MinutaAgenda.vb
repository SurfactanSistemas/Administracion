Imports Util
Imports Util.Clases
Imports Util.Clases.Query
Imports Util.Clases.Helper

Public Class MinutaAgenda
    'Si modifica los mails modificar tambien en MinutaBaja_Modificacion
    Dim Mails As String = "drodriguez@surfactan.com.ar;hmuller@surfactan.com.ar"
    Sub New(ByVal Cliente As String, ByVal DesCliente As String)

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        txt_Cliente.Text = Cliente
        txt_ClienteDes.Text = DesCliente



    End Sub

    Private Sub SoloNumero(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_Cantidad.KeyPress
        If Not Char.IsNumber(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub MinutaAgenda_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        txt_Cantidad.Focus()
    End Sub


    Private Sub btn_HojaRuta_Click(sender As Object, e As EventArgs) Handles btn_HojaRuta.Click

        If Val(txt_Cantidad.Text) > 0 Then


            If MsgBox("¿Desea asignar que para la siguiente hoja de ruta del cliente " & txt_ClienteDes.Text & "," _
                              & "se retiren la cantidad de " & txt_Cantidad.Text & " contenedores?", vbYesNo) = vbYes Then

                Dim SQLCnslt As String = "SELECT ID, CantEnvRetirar, Fecha " _
                                         & "FROM DevolucionEnvMinutas " _
                                         & "WHERE Cliente = '" & txt_Cliente.Text & "' " _
                                         & "AND Tipo = 'HojaRu' " _
                                         & "AND CantEnvIngresan = 0"

                Dim RowDevo As DataRow = GetSingle(SQLCnslt, "SurfactanSa")

                If RowDevo IsNot Nothing Then
                    If MsgBox("Ya se agendo que para la siguiente Hoja de Ruta para el cliente, se retire la cantidad de " & RowDevo.Item("CantEnvRetirar") & " " _
                           & "envases. Fecha de solicitud " & RowDevo.Item("Fecha") & " ¿Desea sobre escribir la solicitud con los nuevos valores?", vbYesNo) = vbYes Then


                        SQLCnslt = "UPDATE DevolucionEnvMinutas SET " _
                                     & "Fecha = '" & Date.Today.ToString("dd/MM/yyyy") & "', " _
                                     & "FechaOrd = '" & ordenaFecha(Date.Today.ToString("dd/MM/yyyy")) & "', " _
                                     & "WDate = '" & Date.Today.ToString("yyyy-MM-dd") & "',  " _
                                     & "CantEnvRetirar = '" & Val(txt_Cantidad.Text) & "' " _
                                     & "WHERE ID = '" & RowDevo.Item("ID") & "'"


                        ExecuteNonQueries({SQLCnslt}, "SurfactanSa")

                        SacarDeAgenda(txt_Cliente.Text)

                        Exit Sub
                    Else
                        Exit Sub
                    End If
                End If


                SQLCnslt = "INSERT INTO DevolucionEnvMinutas ( " _
                                         & "Tipo, " _
                                         & "Cliente, " _
                                         & "NroHojaRuta, " _
                                         & "NroRemito, " _
                                         & "Fecha, " _
                                         & "FechaOrd, " _
                                         & "WDate, " _
                                         & "FechaRetirar, " _
                                         & "CantEnvRetirar," _
                                         & "CantEnvIngresan)" _
                                         & "VALUES( " _
                                         & "'" & "HojaRu" & "', " _
                                         & "'" & txt_Cliente.Text & "', " _
                                         & "'" & "" & "', " _
                                         & "'" & "" & "', " _
                                         & "'" & Date.Today.ToString("dd/MM/yyyy") & "', " _
                                         & "'" & ordenaFecha(Date.Today.ToString("dd/MM/yyyy")) & "', " _
                                         & "'" & Date.Today.ToString("yyyy-MM-dd") & "', " _
                                         & "'" & "" & "', " _
                                         & "'" & Val(txt_Cantidad.Text) & "', " _
                                         & "'" & 0 & "')"

                ExecuteNonQueries({SQLCnslt}, "SurfactanSa")

                SacarDeAgenda(txt_Cliente.Text)

            End If
        End If

    End Sub

    Private Sub btn_Camion_Click(sender As Object, e As EventArgs) Handles btn_Camion.Click

        If Val(txt_Cantidad.Text) > 0 Then
            If ValidaFecha(txt_fecha.Text) = "S" Then
                If MsgBox("¿Desea asignar que envie un camion al cliente " & txt_ClienteDes.Text & "," _
                     & "para que se retiren la cantidad de " & txt_Cantidad.Text & " contenedores?", vbYesNo) = vbYes Then

                    Dim Cliente As String = txt_Cliente.Text
                    Dim FechaRetirar As String = txt_fecha.Text
                    Dim CantEnvRetirar As String = txt_Cantidad.Text


                    Dim SQLCnslt As String = "SELECT ID, CantEnvRetirar, FechaRetirar " _
                                             & "FROM DevolucionEnvMinutas " _
                                             & "WHERE Cliente = '" & txt_Cliente.Text & "' " _
                                             & "AND Tipo = 'Camion' " _
                                             & "AND CantEnvIngresan = 0"
                    Dim RowDevo As DataRow = GetSingle(SQLCnslt, "SurfactanSa")

                    If RowDevo IsNot Nothing Then
                        If MsgBox("Ya existe una solicitud de camion para el cliente, para retirar la cantidad de " & RowDevo.Item("CantEnvRetirar") & " " _
                               & "envases el dia de " & RowDevo.Item("FechaRetirar") & ". ¿Desea sobre escribir la solicitud con los nuevos valores?", vbYesNo) = vbYes Then


                            SQLCnslt = "UPDATE DevolucionEnvMinutas SET " _
                                         & "Fecha = '" & Date.Today.ToString("dd/MM/yyyy") & "', " _
                                         & "FechaOrd = '" & ordenaFecha(Date.Today.ToString("dd/MM/yyyy")) & "', " _
                                         & "WDate = '" & Date.Today.ToString("yyyy-MM-dd") & "',  " _
                                         & "FechaRetirar = '" & txt_fecha.Text & "', " _
                                         & "CantEnvRetirar = '" & Val(txt_Cantidad.Text) & "' " _
                                         & "WHERE ID = '" & RowDevo.Item("ID") & "'"


                            ExecuteNonQueries({SQLCnslt}, "SurfactanSa")

                 
                            _Generarmails(Cliente, txt_ClienteDes.Text, FechaRetirar, CantEnvRetirar)

                            SacarDeAgenda(Cliente)

                            Exit Sub
                        Else
                            Exit Sub
                        End If
                    End If




                    SQLCnslt = "INSERT INTO DevolucionEnvMinutas ( " _
                                             & "Tipo, " _
                                             & "Cliente, " _
                                             & "NroHojaRuta, " _
                                             & "NroRemito, " _
                                             & "Fecha, " _
                                             & "FechaOrd, " _
                                             & "WDate, " _
                                             & "FechaRetirar, " _
                                             & "CantEnvRetirar," _
                                             & "CantEnvIngresan)" _
                                             & "VALUES( " _
                                             & "'" & "Camion" & "', " _
                                             & "'" & txt_Cliente.Text & "', " _
                                             & "'" & "" & "', " _
                                             & "'" & "" & "', " _
                                             & "'" & Date.Today.ToString("dd/MM/yyyy") & "', " _
                                             & "'" & ordenaFecha(Date.Today.ToString("dd/MM/yyyy")) & "', " _
                                             & "'" & Date.Today.ToString("yyyy-MM-dd") & "', " _
                                             & "'" & txt_fecha.Text & "', " _
                                             & "'" & Val(txt_Cantidad.Text) & "', " _
                                             & "'" & 0 & "')"

                    ExecuteNonQueries({SQLCnslt}, "SurfactanSa")


                    _Generarmails(Cliente, txt_ClienteDes.Text, FechaRetirar, CantEnvRetirar)

                    SacarDeAgenda(Cliente)

                End If
            Else
                MsgBox("La Fecha a Retirar es invalida, verificar")
                txt_fecha.Focus()
                txt_fecha.SelectAll()
                Exit Sub
            End If

        End If


    End Sub

    Private Sub btn_Cerrar_Click(sender As Object, e As EventArgs) Handles btn_Cerrar.Click
        Close()
    End Sub


    Private Sub _Generarmails(ByVal Cliente As String, ByVal DesCliente As String, ByVal FechaRetirar As String, ByVal CantRetirar As String)

        Dim Cuerpo As String = "Se solicita el envio de un camion para retirar la cantidad de " & CantRetirar & " contenedores" _
                               & ", a el cliente " & DesCliente & " (" & Cliente & "). Se acordo que sea enviado" _
                               & " el dia " & FechaRetirar & "."


        Helper._EnviarEmail(Mails, "SOLICITUD DE ENVIO DE CAMION", Cuerpo, {}, True)
    End Sub

    Private Sub SacarDeAgenda(ByVal CodigoCli As String)
        Dim WOwner As IBorrarDeAgenda = TryCast(Owner, IBorrarDeAgenda)

        If WOwner IsNot Nothing Then
            WOwner.BorrarDeAgenda(CodigoCli)
            Close()
        End If

        Dim WOwner2 As IMinutaDirecta = TryCast(Owner, IMinutaDirecta)

        If WOwner2 IsNot Nothing Then
            WOwner2.CerrarIngresoAgenda()
            Close()
        End If

    End Sub

End Class