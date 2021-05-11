Public Class Listado_ECheques_SinUsar




    
    Private Sub btn_Aceptar_Click(sender As Object, e As EventArgs) Handles btn_Aceptar.Click
        Dim SQLCnslt As String

        Dim TablaReporte As DataTable = New DBAuxi.EChequesSinUsarDataTable()


        SQLCnslt = "SELECT Clave, NroCheque, BancoEmisor, Importe, FechaPago, OrdFechaPago, CuitEmisor, Emisor_Razon, " _
                            & "FechaEmisor, OrdFechaEmisor, Caracter_Cheque, Modo_Cheque, Endoso_Documento, Endoso_Razon, FechaGrabacion " _
                            & " FROM Carga_ChequesE " _
                            & "WHERE Marca_usado <> 'X' " _
                            & "ORDER BY OrdFechaGrabacion desc"



        Dim TablaEcheques As DataTable = GetAll(SQLCnslt, "SurfactanSa")

        If TablaEcheques.Rows.Count > 0 Then
            For Each row As DataRow In TablaEcheques.Rows
                With row

                    Dim WClave As String = .Item("Clave")
                    Dim WNroCheque As String = .Item("NroCheque")
                    Dim WBanco As String = .Item("BancoEmisor")
                    Dim WImporte As Double = .Item("Importe")
                    Dim WFechaPago As String = .Item("FechaPago")


                    Dim WCuitEmisor As String = .Item("Endoso_Documento")
                    Dim WRazonEmisor As String = .Item("Endoso_Razon")
                    Dim WFechaGrabacion As String = .Item("FechaGrabacion")

                    If WCuitEmisor = "" Then
                        WCuitEmisor = .Item("CuitEmisor")
                        WRazonEmisor = .Item("Emisor_Razon")
                    End If

                    TablaReporte.Rows.Add(WClave, WNroCheque, WBanco, WImporte, WFechaPago, WCuitEmisor, WRazonEmisor, WFechaGrabacion)

                End With

            Next
        End If
        If TablaReporte.Rows.Count > 0 Then
            With New VistaPrevia
                .Reporte = New ReporteEchequesSinUsar
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