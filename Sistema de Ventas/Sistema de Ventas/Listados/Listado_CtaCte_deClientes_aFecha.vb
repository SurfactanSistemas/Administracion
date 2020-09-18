Imports Util
Imports Util.Clases.Query
Imports Util.Clases.Helper

Public Class Listado_CtaCte_deClientes_aFecha : Implements IBuscarClienteCashFlow

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
            txt_Desde.Text = CodigoCliente
            txt_Hasta.Text = CodigoCliente
        Else
            If Accion = "Desde" Then
                txt_Desde.Text = CodigoCliente
            End If
            If Accion = "Hasta" Then
                txt_Hasta.Text = CodigoCliente
            End If
        End If
    End Sub

    Private Sub btn_Aceptar_Click(sender As Object, e As EventArgs) Handles btn_Aceptar.Click
        If ValidaFecha(txt_Fecha.Text) <> "S" Then
            MsgBox("El campo fecha es un valor invalido verificar")
            txt_Fecha.Focus()
            txt_Fecha.SelectAll()
            Exit Sub
        End If


        Dim TablaReciAux As New DataTable
        With TablaReciAux.Columns
            .Add("Tipo")
            .Add("Numero")
            .Add("Importe")
            .Add("Clave")
            .Add("Recibo")
            .Add("Cliente")
        End With


       
        Dim WFecha As String = ordenaFecha(txt_Fecha.Text)

        txt_Desde.Text = UCase(txt_Desde.Text)
        txt_Hasta.Text = UCase(txt_Hasta.Text)

        
        Dim SQLCnslt As String = "Update Ctacte SET Tipo = '06' WHERE Tipo = 6"
        ExecuteNonQueries({SQLCnslt}, Operador.Base)

        SQLCnslt = "Update Ctacte SET Tipo = '07' WHERE Tipo = 7"
        ExecuteNonQueries({SQLCnslt}, Operador.Base)


        Dim TablaReporteCtaCteCliFecha As DataTable = New DBAuxi.TablaReporteCtaCteCliFechaDataTable()

        Dim Renglon As Integer = 0



        SQLCnslt = "Select Tipo, Numero, Cliente, Fecha, Impre, Total, Saldo, TotalUS, SaldoUS, Clave " _
            & "From Ctacte " _
            & "WHERE Cliente >= '" & txt_Desde.Text & "' AND Cliente <= '" & txt_Hasta.Text & "' " _
            & "AND OrdFecha <= '" & WFecha & "' "

        If rabtn_CtaCte.Checked Then
            SQLCnslt = SQLCnslt & "AND Tipo < 50 "
        End If

        If rabtn_Documentos.Checked Then
            SQLCnslt = SQLCnslt & "AND Tipo >= 50 AND Tipo <> 60 "
        End If

        SQLCnslt = SQLCnslt & "ORDER BY Cliente,  Ordfecha, Numero"

        Dim Tablactacte As DataTable = GetAll(SQLCnslt, Operador.Base)
        If Tablactacte.Rows.Count > 0 Then

            For Each RowCtaCte As DataRow In Tablactacte.Rows

                Dim Wtipo As String = RowCtaCte.Item("Tipo")
                Dim WImpre As String = RowCtaCte.Item("Impre")
                Dim WNumero As String = RowCtaCte.Item("Numero")
                Dim WCliente As String = RowCtaCte.Item("Cliente")
                Dim XFecha As String = RowCtaCte.Item("Fecha")
                Dim WTotal As Double = RowCtaCte.Item("Total")
                ' Dim WSaldo As Double = RowCtaCte.Item("Saldo")
                Dim WTotalUs As Double = RowCtaCte.Item("TotalUs")
                ' Dim WSaldoUs As Double = RowCtaCte.Item("SaldoUs")
                Dim WOrdFecha = ordenaFecha(XFecha)

                Dim WClave As String = RowCtaCte.Item("Clave")


                Dim WNume As String = WNumero.PadLeft(8, "0")
                Dim WClaveImpre As String = WCliente & WOrdFecha & Wtipo & WNume


                Dim WImporte1 As Double
                Dim WImporte2 As Double
                Dim WImporte3 As Double
                If RowCtaCte.Item("Total") > 0 Then
                    WImporte1 = RowCtaCte.Item("Total")
                    WImporte2 = 0
                Else
                    WImporte1 = 0
                    WImporte2 = RowCtaCte.Item("Total")
                End If
                WImporte3 = RowCtaCte.Item("Saldo")


                TablaReporteCtaCteCliFecha.Rows.Add()
                TablaReporteCtaCteCliFecha.Rows(Renglon).Item("Numero") = WNumero
                TablaReporteCtaCteCliFecha.Rows(Renglon).Item("Cliente") = WCliente
                TablaReporteCtaCteCliFecha.Rows(Renglon).Item("Fecha") = XFecha
                TablaReporteCtaCteCliFecha.Rows(Renglon).Item("Impre") = WImpre
                TablaReporteCtaCteCliFecha.Rows(Renglon).Item("ClaveImpre") = WClaveImpre
                TablaReporteCtaCteCliFecha.Rows(Renglon).Item("Clave") = WClave
                TablaReporteCtaCteCliFecha.Rows(Renglon).Item("Razon") = ""
                TablaReporteCtaCteCliFecha.Rows(Renglon).Item("Importe1") = WImporte1
                TablaReporteCtaCteCliFecha.Rows(Renglon).Item("Importe2") = WImporte2
                TablaReporteCtaCteCliFecha.Rows(Renglon).Item("Importe3") = WImporte3
                TablaReporteCtaCteCliFecha.Rows(Renglon).Item("Total") = WTotal
                TablaReporteCtaCteCliFecha.Rows(Renglon).Item("TotalUS") = WTotalUs

                Renglon += 1

            Next

        End If



        SQLCnslt = "SELECT Tipo1, Numero1, Importe1, Clave, Recibo, Cliente " _
                   & "FROM Recibos " _
                   & "WHERE Cliente >= '" & txt_Desde.Text & "' and Cliente <= '" & txt_Hasta.Text & "' " _
                   & "AND FechaOrd > '" & WFecha & "' " _
                     & "AND Importe1 <> 0 " _
                   & "Order by Clave"

        Renglon = 0

        Dim TablaReci As DataTable = GetAll(SQLCnslt, Operador.Base)
        If TablaReci.Rows.Count > 0 Then

            For Each RowReci As DataRow In TablaReci.Rows

                TablaReciAux.Rows.Add()
                TablaReciAux.Rows(Renglon).Item("Tipo") = RowReci.Item("Tipo1")
                TablaReciAux.Rows(Renglon).Item("Numero") = RowReci.Item("Numero1")
                TablaReciAux.Rows(Renglon).Item("Importe") = RowReci.Item("Importe1")
                TablaReciAux.Rows(Renglon).Item("Clave") = RowReci.Item("Clave")
                TablaReciAux.Rows(Renglon).Item("Recibo") = RowReci.Item("Recibo")
                TablaReciAux.Rows(Renglon).Item("Cliente") = RowReci.Item("Cliente")

                Renglon += 1
            Next

        End If

        Dim WProv As Integer = 0
        Dim WParidad As Double = 0
        For Each RowAux As DataRow In TablaReciAux.Rows

            Dim ZTipo As String = (RowAux.Item("Tipo")).ToString().PadLeft(2, "0")
            Dim ZNumero As String = (RowAux.Item("Numero")).ToString().PadLeft(8, "0")
            Dim ZImporte As Double = RowAux.Item("Importe")
            Dim ZClave As String = RowAux.Item("Clave")
            Dim ZRecibo As String = RowAux.Item("Recibo")
            Dim ZCliente As String = RowAux.Item("Cliente")


            Dim WClave As String = ZTipo + ZNumero + "01"


            WProv = 0
            WParidad = 0

            SQLCnslt = "SELECT Provincia FROM Cliente WHERE Cliente = '" & ZCliente & "'"
            Dim RowClie As DataRow = GetSingle(SQLCnslt, Operador.Base)
            If RowClie IsNot Nothing Then

                WProv = RowClie.Item("Provincia")

            End If

            If WProv = 24 Then
                Dim Auxi1 As String = ZRecibo.PadLeft(8, "0")

                Dim ClaveCtacte As String = "06" & Auxi1 & "01"

                SQLCnslt = "SELECT Paridad FROM Ctacte WHERE Clave = '" & ClaveCtacte & "'"
                Dim RowCtaCte As DataRow = GetSingle(SQLCnslt, Operador.Base)
                If RowCtaCte IsNot Nothing Then
                    WParidad = RowCtaCte.Item("Paridad")

                Else
                    ClaveCtacte = "07" & Auxi1 & "01"
                    SQLCnslt = "SELECT Paridad FROM Ctacte WHERE Clave = '" & ClaveCtacte & "'"
                    Dim RowCtaCte07 As DataRow = GetSingle(SQLCnslt, Operador.Base)
                    If RowCtaCte07 IsNot Nothing Then
                        WParidad = RowCtaCte.Item("Paridad")
                    End If
                End If
            End If

            For Each row As DataRow In TablaReporteCtaCteCliFecha.Rows
                If row.Item("Clave") = WClave Then
                    If WProv = 24 And WParidad <> 0 Then
                        row.Item("Importe3") = row.Item("Importe3") + (ZImporte / WParidad)
                    Else
                        row.Item("Importe3") = row.Item("Importe3") + ZImporte
                    End If
                End If
            Next


        Next


        WParidad = 0


        SQLCnslt = "SELECT Cambio FROM Cambios WHERE OrdFecha <= '" & WFecha & "' ORDER BY OrdFecha"
        Dim TablaCambios As DataTable = GetAll(SQLCnslt, Operador.Base)
        If TablaCambios.Rows.Count > 0 Then
            For i = (TablaCambios.Rows.Count - 1) To TablaCambios.Rows.Count - 1
                WParidad = Str$(TablaCambios.Rows(i).Item("Cambio"))
            Next
        End If



        For Each rowRep As DataRow In TablaReporteCtaCteCliFecha.Rows

            WProv = 0

            SQLCnslt = "SELECT Razon, Provincia FROM Cliente WHERE Cliente = '" & rowRep.Item("Cliente") & "'"

            Dim RowClie As DataRow = GetSingle(SQLCnslt, Operador.Base)
            If RowClie IsNot Nothing Then
                rowRep.Item("Razon") = RowClie.Item("Razon")
                WProv = RowClie.Item("Provincia")
            End If

            If rabtn_Pesos.Checked Then
                If WProv = 24 And WParidad <> 0 Then
                    rowRep.Item("Importe3") = rowRep.Item("Importe3") * WParidad
                End If
            End If

            If rabtn_Dolares.Checked Then
                If rowRep.Item("TotalUs") <> 0 Then
                    Dim Pari As Double = rowRep.Item("Total") / rowRep.Item("TotalUs")
                    rowRep.Item("Importe1") = rowRep.Item("Importe1") / Pari
                    rowRep.Item("Importe2") = rowRep.Item("Importe2") / Pari
                    rowRep.Item("Importe3") = rowRep.Item("Importe3") / Pari
                End If

            End If

        Next

       


    

        Dim WTitulo As String = ""

        If rabtn_CtaCte.Checked Then
            WTitulo = "Cuenta Corriente - "
        End If
        If rabtn_Documentos.Checked Then
            WTitulo = "Documentos - "
        End If
        If rabtn_Total.Checked Then
            WTitulo = "Total - "
        End If

        If rabtn_Pesos.Checked Then
            WTitulo = WTitulo + "Pesos"
        End If
        If rabtn_Dolares.Checked Then
            WTitulo = WTitulo + "Dolares"
        End If

        WTitulo = WTitulo & " al " & txt_Fecha.Text

        
        Dim WFormula As String
        If rabtn_Pendiente.Checked Then
            WFormula = "{TablaReporteCtaCteCliFecha.Importe3} <> 0.00"
        Else
            WFormula = "{TablaReporteCtaCteCliFecha.Importe3} <> 999999.99"
        End If

        With New VistaPrevia
            .Reporte = New ReporteCtaCte_ClientesAFecha()
            .Reporte.SetDataSource(TablaReporteCtaCteCliFecha)
            .Reporte.SetParameterValue(0, Operador.Base)
            .Reporte.SetParameterValue(1, WTitulo)
            .Formula = WFormula

            If rabtn_Pantalla.Checked Then
                .Mostrar()
            Else
                .Imprimir()
            End If
        End With
        
    End Sub

    
    Private Sub txt_Fecha_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_Fecha.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                If ValidaFecha(txt_Fecha.Text) <> "S" Then
                    MsgBox("El campo fecha es un valor invalido verificar")
                    txt_Fecha.Focus()
                    txt_Fecha.SelectAll()
                    Exit Sub
                Else
                    txt_Desde.Focus()
                End If
            Case Keys.Escape
                txt_Fecha.Text = ""
        End Select
    End Sub

    Private Sub txt_Desde_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_Desde.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                
                    txt_Hasta.Focus()

            Case Keys.Escape
                    txt_Desde.Text = ""
        End Select
    End Sub

    Private Sub txt_Hasta_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_Hasta.KeyDown
        Select Case e.KeyData
            Case Keys.Escape
                txt_Desde.Text = ""

        End Select
    End Sub
End Class