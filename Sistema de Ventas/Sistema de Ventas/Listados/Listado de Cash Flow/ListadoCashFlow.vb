Imports System.Diagnostics.Eventing.Reader
Imports Util
Imports Util.Clases.Query
Imports Util.Clases.Helper
Public Class ListadoCashFlow : Implements IBuscarClienteCashFlow


    Private Sub btn_Cerrar_Click(sender As Object, e As EventArgs) Handles btn_Cerrar.Click
        Close()
    End Sub

    Private Sub btn_Aceptar_Click(sender As Object, e As EventArgs) Handles btn_Aceptar.Click

        txt_DesdeCodigo.Text = UCase(txt_DesdeCodigo.Text)
        txt_HastaCodigo.Text = UCase(txt_HastaCodigo.Text)


        'CHEQUEAMOS QUE EL CODIGO SEA VALIDO SINO SALIMOS DE LA RUTINA
        If txt_DesdeCodigo.Text < "A00000" Or txt_DesdeCodigo.Text > "Z99999" Then
            MsgBox("El codigo Desde no es un valor valido,verificar")
            Exit Sub
        Else
            If txt_HastaCodigo.Text < "A00000" Or txt_HastaCodigo.Text > "Z99999" Then
                MsgBox("El codigo Hasta no es un valor valido,verificar")
                Exit Sub
            End If
        End If



        'VALIDAMOS QUE LA FECHA SEA CORRECTA SINO SALIMOS DE LA RUTINA
        If ValidaFecha(txt_Vence1Fecha.Text) = "N" Then
            MsgBox("La fecha 1 no es valida,verificar")
            Exit Sub
        Else
            If ValidaFecha(txt_Vence2Fecha.Text) = "N" Then
                MsgBox("La fecha 2 no es valida,verificar")
                Exit Sub
            Else
                If ValidaFecha(txt_Vence3Fecha.Text) = "N" Then
                    MsgBox("La fecha 3 no es valida,verificar")
                    Exit Sub
                Else
                    If ValidaFecha(txt_Vence4Fecha.Text) = "N" Then
                        MsgBox("La fecha 4 no es valida,verificar")
                        Exit Sub
                    End If
                End If
            End If
        End If


        Dim WOrdFecha1 As String = ordenaFecha(txt_Vence1Fecha.Text)
        Dim WOrdFecha2 As String = ordenaFecha(txt_Vence2Fecha.Text)
        Dim WOrdFecha3 As String = ordenaFecha(txt_Vence3Fecha.Text)
        Dim WOrdFecha4 As String = ordenaFecha(txt_Vence4Fecha.Text)

        Dim TablaCashFlow As DataTable = New DBAuxi.TablaCashFlowDataTable()


        Dim SQLCnslt As String = "SELECT Saldo, Saldous, Cliente, Tipo, Vencimiento, Vencimiento1, Importe1, Importe2," _
                                 & "Importe3, Importe4, Importe5, Importe6 FROM CtaCte " _
                                 & "WHERE Cliente >= '" & txt_DesdeCodigo.Text & "' AND Cliente <= '" & txt_HastaCodigo.Text & "' " _
                                 & "Order by Numero"

        Dim TablaAux As DataTable = GetAll(SQLCnslt, "SurfactanSa")


        If TablaAux.Rows.Count > 0 Then
            For Each RowAux As DataRow In TablaAux.Rows

                Dim WSaldo As Double = 0

                If rabtn_Pesos.Checked Then
                    WSaldo = RowAux.Item("Saldo")
                Else
                    WSaldo = RowAux.Item("Saldous")
                End If

                If WSaldo <> 0 Then
                    Dim WPasa As String = "N"

                    If rabtn_CtaCte.Checked Then
                        If RowAux.Item("Tipo") < 50 Then
                            WPasa = "S"
                        End If
                    End If

                    If rabtn_Documentos.Checked Then
                        If RowAux.Item("Tipo") >= 50 And RowAux.Item("Tipo") <> 60 Then
                            WPasa = "S"
                        End If
                    End If

                    If rabtn_Total.Checked Then

                        WPasa = "S"
                    End If


                    If WPasa = "S" Then
                        Dim WVencimiento As String = ""
                        If rabtn_Vencimiento1.Checked Then
                            WVencimiento = ordenaFecha(RowAux.Item("Vencimiento"))
                        Else
                            WVencimiento = ordenaFecha(RowAux.Item("Vencimiento1"))
                        End If

                        Dim WCliente As String = RowAux.Item("Cliente")

                        Dim Existe As String = "N"
                        'REVISAMOS SI SE ENCUENTRA EN LA TABLA
                        For Each RowTabla As DataRow In TablaCashFlow.Rows
                            If RowTabla.Item("Cliente") = WCliente Then
                                Existe = "S"
                            End If
                        Next
                        'SINO SE ENCUENTRA LO AGREGAMOS
                        If Existe = "N" Then
                            TablaCashFlow.Rows.Add(RowAux.Item("Cliente"), "", 0, 0, 0, 0, 0, 0)
                        End If

                        'ACUMULAMOS EL SALDO SEGUN CORRESPONDA
                        For Each RowTabla As DataRow In TablaCashFlow.Rows

                            If RowTabla.Item("Cliente") = WCliente Then

                                RowTabla.Item("Importe6") = RowTabla.Item("Importe6") + WSaldo
                                If WVencimiento <= WOrdFecha1 Then
                                    RowTabla.Item("Importe1") = RowTabla.Item("Importe1") + WSaldo
                                Else
                                    If WVencimiento <= WOrdFecha2 Then
                                        RowTabla.Item("Importe2") = RowTabla.Item("Importe2") + WSaldo
                                    Else
                                        If WVencimiento <= WOrdFecha3 Then
                                            RowTabla.Item("Importe3") = RowTabla.Item("Importe3") + WSaldo
                                        Else
                                            If WVencimiento <= WOrdFecha4 Then
                                                RowTabla.Item("Importe4") = RowTabla.Item("Importe4") + WSaldo
                                            Else
                                                RowTabla.Item("Importe5") = RowTabla.Item("Importe5") + WSaldo
                                            End If

                                        End If
                                    End If
                                End If
                            End If
                        Next



                    End If
                End If
            Next


            'COMPLETAMOS EL CAMPO DE RAZON DE CADA CLIENTE
            For Each RowTabla As DataRow In TablaCashFlow.Rows
                SQLCnslt = "SELECT Razon FROM CLIENTE WHERE Cliente = '" & RowTabla.Item("Cliente") & "'"
                Dim RowCliente As DataRow = GetSingle(SQLCnslt, "SurfactanSa")

                If RowCliente IsNot Nothing Then
                    RowTabla.Item("Razon") = RowCliente.Item("Razon")
                End If
            Next



            With New VistaPrevia
                .Reporte = New ReporteCashFlow()
                .Reporte.SetDataSource(TablaCashFlow)
                .Reporte.SetParameterValue(0, Operador.Base)
                .Reporte.SetParameterValue(1, txt_Vence1Fecha.Text)
                .Reporte.SetParameterValue(2, txt_Vence2Fecha.Text)
                .Reporte.SetParameterValue(3, txt_Vence3Fecha.Text)
                .Reporte.SetParameterValue(4, txt_Vence4Fecha.Text)

                If rabtn_Pantalla.Checked Then
                    .Mostrar()
                Else
                    .Imprimir()
                End If

            End With

        End If

    End Sub

    Private Sub txt_DesdeCodigo_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_DesdeCodigo.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                If txt_DesdeCodigo.Text = "" Then
                    txt_DesdeCodigo.Text = "A00000"
                    txt_HastaCodigo.Focus()
                Else
                    If txt_DesdeCodigo.Text.Length < 6 Then
                        MsgBox("No es un codigo valido, verificar")
                        txt_DesdeCodigo.SelectAll()
                        txt_DesdeCodigo.Focus()
                    Else
                        If txt_DesdeCodigo.Text.Length = 6 Then
                            If txt_DesdeCodigo.Text >= "A00000" And txt_DesdeCodigo.Text >= "Z99999" Then
                                txt_HastaCodigo.Focus()
                            End If
                        Else
                            MsgBox("No es un codigo valido, verificar")
                            txt_DesdeCodigo.SelectAll()
                            txt_DesdeCodigo.Focus()
                        End If
                    End If
                End If
            Case Keys.Escape
                txt_DesdeCodigo.Text = ""
        End Select
    End Sub

    Private Sub txt_HastaCodigo_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_HastaCodigo.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                If txt_HastaCodigo.Text = "" Then
                    txt_HastaCodigo.Text = "Z99999"
                    txt_Vence1Fecha.Focus()
                Else
                    If txt_HastaCodigo.Text.Length < 6 Then
                        MsgBox("No es un codigo valido, verificar")
                        txt_HastaCodigo.SelectAll()
                        txt_HastaCodigo.Focus()
                    Else
                        If txt_HastaCodigo.Text.Length = 6 Then
                            If txt_HastaCodigo.Text >= "A00000" And txt_HastaCodigo.Text >= "Z99999" Then
                                txt_Vence1Fecha.Focus()
                            End If
                        Else
                            MsgBox("No es un codigo valido, verificar")
                            txt_HastaCodigo.SelectAll()
                            txt_HastaCodigo.Focus()
                        End If
                    End If
                End If
            Case Keys.Escape
                txt_HastaCodigo.Text = ""
        End Select
    End Sub

    Private Sub txt_Vence1Fecha_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_Vence1Fecha.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                If ValidaFecha(txt_Vence1Fecha.Text) = "S" Then
                    txt_Vence2Fecha.Focus()
                Else
                    MsgBox("La fecha es invalida, verifique")
                    txt_Vence1Fecha.SelectAll()
                    txt_Vence1Fecha.Focus()
                End If
            Case Keys.Escape
                txt_Vence1Fecha.Text = ""
        End Select
    End Sub


    Private Sub txt_Vence2Fecha_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_Vence2Fecha.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                If ValidaFecha(txt_Vence2Fecha.Text) = "S" Then
                    txt_Vence3Fecha.Focus()
                Else
                    MsgBox("La fecha es invalida, verifique")
                    txt_Vence2Fecha.SelectAll()
                    txt_Vence2Fecha.Focus()
                End If
            Case Keys.Escape
                txt_Vence2Fecha.Text = ""
        End Select
    End Sub

    Private Sub txt_Vence3Fecha_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_Vence3Fecha.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                If ValidaFecha(txt_Vence3Fecha.Text) = "S" Then
                    txt_Vence4Fecha.Focus()
                Else
                    MsgBox("La fecha es invalida, verifique")
                    txt_Vence3Fecha.SelectAll()
                    txt_Vence3Fecha.Focus()
                End If
            Case Keys.Escape
                txt_Vence3Fecha.Text = ""
        End Select
    End Sub

    Private Sub txt_Vence4Fecha_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_Vence4Fecha.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                If ValidaFecha(txt_Vence4Fecha.Text) = "N" Then

                    MsgBox("La fecha es invalida, verifique")
                    txt_Vence4Fecha.SelectAll()
                    txt_Vence4Fecha.Focus()
                Else
                    btn_Aceptar_Click(Nothing, Nothing)
                End If
            Case Keys.Escape
                txt_Vence4Fecha.Text = ""
        End Select
    End Sub

    Private Sub btn_Consulta_Click(sender As Object, e As EventArgs) Handles btn_Consulta.Click
        With ConsultaCliente
            .Show(Me)
        End With
    End Sub

    Public Sub CompletaCliente(CodigoCliente As String, Accion As String) Implements IBuscarClienteCashFlow.CompletaCliente
        If Accion = "Ambos" Then
            txt_HastaCodigo.Text = CodigoCliente
            txt_DesdeCodigo.Text = CodigoCliente
        End If

        If Accion = "Desde" Then
            txt_DesdeCodigo.Text = CodigoCliente
        End If

        If Accion = "Hasta" Then
            txt_HastaCodigo.Text = CodigoCliente
        End If
    End Sub
End Class