Imports Util
Imports Util.Clases.Query
Imports Util.Clases.Helper


Public Class SaldoDe_CtaCte_deCliente : Implements IBuscarClienteCashFlow

    Private Sub btn_Cerrar_Click(sender As Object, e As EventArgs) Handles btn_Cerrar.Click
        Close()

    End Sub

    Private Sub btn_Consulta_Click(sender As Object, e As EventArgs) Handles btn_Consulta.Click
        With ConsultaCliente
            .Show(Me)
        End With
    End Sub

    Public Sub CompletaCliente(CodigoCliente As String, Accion As String) Implements IBuscarClienteCashFlow.CompletaCliente
        If Accion = "Ambos" Then
            txt_Hasta.Text = CodigoCliente
            txt_Desde.Text = CodigoCliente
        End If

        If Accion = "Desde" Then
            txt_Desde.Text = CodigoCliente
        End If

        If Accion = "Hasta" Then
            txt_Hasta.Text = CodigoCliente
        End If
    End Sub

    Private Sub btn_Aceptar_Click(sender As Object, e As EventArgs) Handles btn_Aceptar.Click
        txt_Desde.Text = UCase(txt_Desde.Text)
        txt_Hasta.Text = UCase(txt_Hasta.Text)

        Dim ListaSQLCnslt As New List(Of String)
        Dim SQLCnslt As String = "UPDATE Ctacte SET Tipo = '06' WHERE Tipo = '6'"

        ListaSQLCnslt.Add(SQLCnslt)

        SQLCnslt = "UPDATE Ctacte SET Tipo = '07' WHERE Tipo = '7'"

        ListaSQLCnslt.Add(SQLCnslt)

        SQLCnslt = "UPDATE Ctacte SET Importe1 = '0', Importe2 = '0', Importe3 = '0'"

        ListaSQLCnslt.Add(SQLCnslt)


        If rabtn_CtaCte.Checked = True Then
            If rabtn_Pesos.Checked = True Then

                SQLCnslt = "UPDATE  Ctacte SET Importe1	= Total , Importe2 = '0' , Importe3 = Saldo " _
                             & "WHERE Cliente >= '" & txt_Desde.Text & "' AND Cliente <= '" & txt_Hasta.Text & "' " _
                             & "AND Tipo < '50' and Total > '0'"

                ListaSQLCnslt.Add(SQLCnslt)


                SQLCnslt = "UPDATE  Ctacte SET Importe1	= '0', Importe2	=Total , Importe3 = Saldo " _
                               & "WHERE Cliente >= '" & txt_Desde.Text & "' AND Cliente <= '" & txt_Hasta.Text & "' " _
                               & "AND Tipo < '50' and Total < '0'"

                ListaSQLCnslt.Add(SQLCnslt)

            Else
                SQLCnslt = "UPDATE  Ctacte SET Importe1	= TotalUs , Importe2 = '0' , Importe3 = SaldoUs " _
                                             & "WHERE Cliente >= '" & txt_Desde.Text & "' AND Cliente <= '" & txt_Hasta.Text & "' " _
                                             & "and Tipo < '50' and TotalUs > '0'"

                ListaSQLCnslt.Add(SQLCnslt)

                SQLCnslt = "UPDATE  Ctacte SET Importe1	='0', Importe2	=TotalUs , Importe3 = SaldoUs " _
                          & "WHERE Cliente >= '" & txt_Desde.Text & "' AND Cliente <= '" & txt_Hasta.Text & "' " _
                          & "AND Tipo < '50' and TotalUs < '0'"

                ListaSQLCnslt.Add(SQLCnslt)

            End If
        End If

        If rabtn_Documentos.Checked = True Then
            If rabtn_Pesos.Checked = True Then
                SQLCnslt = "UPDATE  Ctacte SET Importe1	=Total , Importe2	='0' , Importe3 = Saldo " _
                       & "WHERE Cliente >= '" & txt_Desde.Text & "' AND Cliente <= '" & txt_Hasta.Text & "' " _
                       & "AND Tipo >= '50' and Total > '0'"

                ListaSQLCnslt.Add(SQLCnslt)

                SQLCnslt = "UPDATE  Ctacte SET Importe1	= '0', Importe2	=Total , Importe3 = Saldo " _
                         & "WHERE Cliente >= '" & txt_Desde.Text & "' AND Cliente <= '" & txt_Hasta.Text & "' " _
                         & "AND Tipo >= '50' and Total < '0' "

                ListaSQLCnslt.Add(SQLCnslt)
            Else
                SQLCnslt = "UPDATE  Ctacte SET Importe1	= TotalUs, Importe2	= '0' , Importe3 = SaldoUs " _
                             & "WHERE Cliente >= '" & txt_Desde.Text & "' AND Cliente <= '" & txt_Hasta.Text & "' " _
                             & "AND Tipo >= '50' and TotalUs < '0' "

                ListaSQLCnslt.Add(SQLCnslt)

                SQLCnslt = "UPDATE  Ctacte SET Importe1	= '0', Importe2	= TotalUs , Importe3 = SaldoUs " _
                            & "WHERE Cliente >= '" & txt_Desde.Text & "' AND Cliente <= '" & txt_Hasta.Text & "' " _
                            & "AND Tipo >= '50' and TotalUs < '0'"

                ListaSQLCnslt.Add(SQLCnslt)
            End If
        End If

        If rabtn_Pesos.Checked = True Then
            If rabtn_Pesos.Checked = True Then
                SQLCnslt = "UPDATE  Ctacte SET Importe1	=Total ,Importe2 = '0' ,Importe3 = Saldo " _
                        & "WHERE Cliente >= '" & txt_Desde.Text & "' AND Cliente <= '" & txt_Hasta.Text & "' " _
                        & "AND Total > '0'"

                ListaSQLCnslt.Add(SQLCnslt)

                SQLCnslt = "UPDATE  Ctacte SET Importe1 = '0', Importe2	=Total , Importe3 = Saldo " _
                    & "WHERE Cliente >= '" & txt_Desde.Text & "' AND Cliente <= '" & txt_Hasta.Text & "' AND Total < '0'"

                ListaSQLCnslt.Add(SQLCnslt)

            Else
                SQLCnslt = "UPDATE  Ctacte SET Importe1	=TotalUs , Importe2	= '0' , Importe3 = SaldoUs " _
                       & " WHERE Cliente >= '" & txt_Desde.Text & "' AND Cliente <= '" & txt_Hasta.Text & "' and TotalUs > '0'"

                ListaSQLCnslt.Add(SQLCnslt)

                SQLCnslt = "UPDATE  Ctacte SET Importe1	= '0', Importe2	= TotalUs , Importe3 = SaldoUs " _
                    & "WHERE Cliente >= '" & txt_Desde.Text & "' AND Cliente <= '" & txt_Hasta.Text & "' and TotalUs < '0'"

                ListaSQLCnslt.Add(SQLCnslt)

            End If
        End If



        ExecuteNonQueries(ListaSQLCnslt.ToArray(), Operador.Base)

        Dim WTitulo As String = ""

        If rabtn_CtaCte.Checked = True Then
            WTitulo = "Cuenta Corriente - "
        End If
        If rabtn_Documentos.Checked = True Then
            WTitulo = "Documentos - "
        End If
        If rabtn_Total.Checked = True Then
            WTitulo = "Total - "
        End If

        If rabtn_Pesos.Checked = True Then
            WTitulo = WTitulo + "Pesos"
        End If
        If rabtn_Dolares.Checked = True Then
            WTitulo = WTitulo + "Dolares"
        End If

   



        Dim Formula As String = "{CtaCte.Cliente} >= '" & txt_Desde.Text & "' AND  {CtaCte.Cliente} <=  '" & txt_Hasta.Text & "' AND {CtaCte.Importe3}  <> 0"



        With New VistaPrevia
            .Reporte = New ReporteSaldoCtaCte
            .Reporte.SetParameterValue(0, Operador.Base)
            .Reporte.SetParameterValue(1, WTitulo)
            .Formula = Formula

            If rabtn_Impresora.Checked = True Then
                .Imprimir()
            Else
                .Mostrar()
            End If
        End With
      

    End Sub

    Private Sub txt_Desde_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_Desde.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                If Trim(txt_Desde.Text) = "" Then
                    txt_Desde.Text = "A00000"
                End If
                txt_Desde.Text = UCase(txt_Desde.Text)
                txt_Hasta.Focus()
            Case Keys.Escape
                txt_Desde.Text = ""


        End Select
    End Sub

    Private Sub txt_Hasta_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_Hasta.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                If Trim(txt_Hasta.Text) = "" Then
                    txt_Hasta.Text = "Z99999"
                End If
                txt_Hasta.Text = UCase(txt_Hasta.Text)

            Case Keys.Escape
                txt_Hasta.Text = ""


        End Select
    End Sub
End Class