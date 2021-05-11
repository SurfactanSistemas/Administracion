Imports Microsoft.Office.Core

Public Class Listado_Echeques_UsadosXFecha

    Private Sub mastxt_DesdeFecha_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_DesdeFecha.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                If txt_DesdeFecha.Text.Replace("/", "").Length = 8 Then
                    If ValidaFecha(txt_DesdeFecha.Text) = "S" Then
                        txt_HastaFecha.Focus()
                    Else
                        MsgBox("No es una fecha valida", vbExclamation)
                    End If
                End If
            Case Keys.Escape
                txt_DesdeFecha.Text = ""
        End Select
    End Sub

    Private Sub txt_HastaFecha_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_HastaFecha.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                If txt_HastaFecha.Text.Replace("/", "").Length = 8 Then
                    If ValidaFecha(txt_HastaFecha.Text) = "S" Then
                        If ordenaFecha(txt_DesdeFecha.Text) > ordenaFecha(txt_HastaFecha.Text) Then
                            MsgBox("La fecha desde no puede ser mayor a la fecha hasta", vbExclamation)
                        End If
                    Else
                        MsgBox("No es una fecha valida", vbExclamation)
                    End If
                End If
            Case Keys.Escape
                txt_HastaFecha.Text = ""
        End Select
    End Sub

    Private Sub btn_Aceptar_Click(sender As Object, e As EventArgs) Handles btn_Aceptar.Click



        If ValidaFecha(txt_DesdeFecha.Text) = "S" Then
            If ValidaFecha(txt_HastaFecha.Text) = "S" Then
                If ordenaFecha(txt_DesdeFecha.Text) > ordenaFecha(txt_HastaFecha.Text) Then
                    MsgBox("La fecha desde no puede ser mayor a la fecha hasta", vbExclamation)
                    Exit Sub
                End If
            Else
                MsgBox("La fecha Hasta es invalida, verificar", vbExclamation)
                txt_HastaFecha.Focus()
                Exit Sub
            End If
        Else
            MsgBox("La fecha Desde es invalida, verificar", vbExclamation)
            txt_DesdeFecha.Focus()
            Exit Sub
        End If




        Dim WFechaDesdeOrd As String = ordenaFecha(txt_DesdeFecha.Text)
        Dim WFechaHastaOrd As String = ordenaFecha(txt_HastaFecha.Text)

        Dim SQLCnslt As String

        Dim TablaReporte As DataTable = New DBAuxi.EChequesSinUsarAFechaDataTable()


        SQLCnslt = "SELECT Recibo, Clave, Numero2, Banco2, Importe2, Fecha2, Estado2, Cliente " _
                            & " FROM RecibosProvi " _
                            & "WHERE Tipo2 = '07' " _
                            & "AND FechaOrd >= '" & WFechaDesdeOrd & "' AND Fechaord <= '" & WFechaHastaOrd & "'" _
                            & "ORDER BY Recibo DESC"




        Dim TablaEcheques As DataTable = GetAll(SQLCnslt, "SurfactanSa")

        If TablaEcheques.Rows.Count > 0 Then
            For Each row As DataRow In TablaEcheques.Rows
                With row

                    Dim WRecibo As String = .Item("Recibo")

                    Dim WClave As String = .Item("Clave")
                    Dim WNroCheque As String = .Item("Numero2")
                    Dim WBanco As String = .Item("Banco2")
                    Dim WImporte As Double = .Item("Importe2")
                    Dim WFechaPago As String = .Item("Fecha2")


                    Dim WCliente As String = .Item("Cliente")
                    Dim WRazonCliente As String = ""

                    SQLCnslt = "SELECT Razon FROM Cliente WHERE Cliente = '" & WCliente & "'"
                    Dim RowCliente As DataRow = GetSingle(SQLCnslt, "SurfactanSa")
                    If RowCliente IsNot Nothing Then
                        WRazonCliente = RowCliente.Item("Razon")
                    End If
                    
                    TablaReporte.Rows.Add(WRecibo, WClave, WNroCheque, WBanco, WImporte, WFechaPago, WCliente, WRazonCliente)

                End With

            Next
        End If
        If TablaReporte.Rows.Count > 0 Then
            With New VistaPrevia
                .Reporte = New ReporteListadoEchequesUsadosAFecha
                .Reporte.SetDataSource(TablaReporte)
                If rabtn_Pantalla.Checked = True Then
                    .Mostrar()
                Else
                    .Imprimir()
                End If

            End With
        End If
    End Sub
End Class