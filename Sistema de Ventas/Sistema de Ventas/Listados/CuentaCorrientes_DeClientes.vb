Imports Util
Imports Util.Clases.Query
Imports Util.Clases.Helper

Public Class CuentaCorrientes_DeClientes : Implements IBuscarClienteCashFlow

    Private Sub btn_Cerrar_Click(sender As Object, e As EventArgs) Handles btn_Cerrar.Click
        Close()
    End Sub

    Private Sub btn_Aceptar_Click(sender As Object, e As EventArgs) Handles btn_Aceptar.Click
        Try

            Dim WTitulo As String = ""

            If cbx_TipoCliente.SelectedIndex = 1 Then
                rabtn_Pesos.Checked = False
                rabtn_Dolares.Checked = True
            End If


            If rabtn_CtaCte.Checked = True Then
                WTitulo = "Cuenta Corriente - "
            End If
            If rabtn_Documentos.Checked = True Then
                WTitulo = "Documentos - "
            End If
            If rabtn_Diferencia.Checked = True Then
                WTitulo = "Diferencia Cambio - "
            End If
            If rabtn_Total.Checked = True Then
                WTitulo = "Total - "
            End If

            If cbx_TipoCliente.SelectedIndex = 1 Then
                WTitulo = "Exterior - "
            End If

            If rabtn_Pesos.Checked = True Then
                WTitulo = WTitulo + "Pesos"
            End If
            If rabtn_Dolares.Checked = True Then
                WTitulo = WTitulo + "Dolares"
            End If


            txt_Desde.Text = UCase(txt_Desde.Text)
            txt_Hasta.Text = UCase(txt_Hasta.Text)

            Dim WAno As String = Microsoft.VisualBasic.Right$(txt_DesdeFecha.Text, 4)
            Dim WMes As String = Microsoft.VisualBasic.Mid$(txt_DesdeFecha.Text, 4, 2)
            Dim WDia As String = Microsoft.VisualBasic.Left$(txt_DesdeFecha.Text, 2)
            Dim WDesdeFecha As String = WAno & WMes & WDia
            WAno = Microsoft.VisualBasic.Right$(txt_HastaFecha.Text, 4)
            WMes = Microsoft.VisualBasic.Mid$(txt_HastaFecha.Text, 4, 2)
            WDia = Microsoft.VisualBasic.Left$(txt_HastaFecha.Text, 2)
            Dim WHastaFecha As String = WAno & WMes & WDia

            Dim ListaSQLCnslt As New List(Of String)
            Dim SQLCnslt As String = "UPDATE Ctacte SET Tipo = '06' WHERE Tipo = '6'"

            ListaSQLCnslt.Add(SQLCnslt)

            SQLCnslt = "UPDATE Ctacte SET Tipo = '07' WHERE Tipo = '7'"

            ListaSQLCnslt.Add(SQLCnslt)

            SQLCnslt = "UPDATE Ctacte SET Importe1 = '0', Importe2 = '0', Importe3 = '0'"

            ListaSQLCnslt.Add(SQLCnslt)


            If rabtn_CtaCte.Checked = True Or rabtn_Diferencia.Checked = True Then
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

            If rabtn_Total.Checked = True Then
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


            Dim ZZSaldoIni As Integer = 0


            Dim tablaReporteCtaCte As DataTable = New DBAuxi.tablaReporteCtaCteDataTable()

            'With tablaReporteCtaCte.Columns
            '    .Add("Cliente")
            '    .Add("Razon")
            '    .Add("Impre")
            '    .Add("Numero")
            '    .Add("Fecha")
            '    .Add("Vencimiento")
            '    .Add("Vencimiento1")
            '    .Add("OrdVencimiento")
            '    .Add("Claveimpre")
            '    .Add("Importe1")
            '    .Add("Importe2")
            '    .Add("Importe3")
            '    .Add("Importe4")
            'End With



            SQLCnslt = "SELECT clave, cliente, tipo, impre, numero, renglon, Fecha, vencimiento, vencimiento1, total, " _
                 & " saldo, totalus, saldous, ordfecha, ordvencimiento, ordvencimiento1, Importe1, importe2, importe3, importe4 " _
                 & " FROM Ctacte" _
                 & " WHERE Cliente >=  '" & txt_Desde.Text & "'" _
                 & " AND Cliente <= '" & txt_Hasta.Text & "'"


            If Trim(WDesdeFecha.Replace("/", "")) <> "" And Trim(WHastaFecha.Replace("/", "")) <> "" Then
                'SQLCnslt = SQLCnslt & "AND OrdFecha >= '" & WDesdeFecha & "' AND OrdFecha <= '" & WHastaFecha & "'"
                SQLCnslt = SQLCnslt & "AND ((OrdFecha >= '" & WDesdeFecha & "' AND OrdFecha <= '" & WHastaFecha & "') " _
                                       & "OR (OrdVencimiento >= '" & WDesdeFecha & "' AND OrdVencimiento <= '" & WHastaFecha & "'))"
            End If

            SQLCnslt = SQLCnslt & "ORDER BY Cliente"

            Dim Acumulado As Double = 0
            Dim ClienteAnterior As String = "A00000"
            Dim tablaCtaCte As DataTable = GetAll(SQLCnslt, Operador.Base)

            If tablaCtaCte.Rows.Count > 0 Then
                For Each Row As DataRow In tablaCtaCte.Rows


                    Dim WPasa As String = "N"
                    If rabtn_CtaCte.Checked = True Then
                        If Row.Item("Tipo") < 50 Or Row.Item("Tipo") = 60 Then
                            WPasa = "S"
                        End If
                    End If

                    If rabtn_Documentos.Checked = True Then
                        If Row.Item("Tipo") >= 50 And Row.Item("Tipo") <> 60 Then
                            WPasa = "S"
                        End If
                    End If

                    If rabtn_Diferencia.Checked = True Then
                        If Row.Item("Tipo") = 4 And Row.Item("Impre") = "ND" Then
                            WPasa = "S"
                        End If
                        If Row.Item("Tipo") = 5 And Row.Item("Impre") = "NC" Then
                            WPasa = "S"
                        End If
                    End If

                    If rabtn_Total.Checked = True Then
                        WPasa = "S"
                    End If

                    Dim WTipo As String = Row.Item("Tipo")
                    Dim WImpre As String = Row.Item("Impre")
                    Dim WNumero As String = Row.Item("Numero")
                    ' Dim WRenglon As String = Row.Item("Renglon")
                    Dim WCliente As String = Row.Item("Cliente")
                    Dim WFecha As String = Row.Item("Fecha")

                    Dim Wvencimiento As String = Row.Item("Vencimiento")
                    Dim WVencimiento1 As String = Row.Item("Vencimiento1")
                    ' Dim WTotal As String = Row.Item("Total")
                    ' Dim WTotalUs As String = Row.Item("Totalus")
                    '  Dim WSaldo As String = Row.Item("Saldo")
                    ' Dim WSaldoUs As String = Row.Item("Saldous")

                    Dim WOrdFecha As String = Row.Item("OrdFecha")
                    Dim WOrdVencimiento As String = Row.Item("OrdVencimiento")
                    ' Dim WOrdVencimiento1 As String = Row.Item("OrdVencimiento1")

                    Dim WImporte1 As String = Row.Item("Importe1")
                    Dim WImporte2 As String = Row.Item("Importe2")
                    Dim WImporte3 As String
                    If cbx_TipoFecha.SelectedIndex = 1 Then
                        WImporte3 = Row.Item("Total")
                    Else
                        WImporte3 = Row.Item("Importe3")
                    End If
                    Dim WImporte4 As String = Row.Item("Importe4")


                    '  Dim WClave As String = Row.Item("Clave")
                    If WPasa = "S" Then

                        If rabtn_Tipo2_Completo.Checked = True Or Row.Item("Importe3") <> 0 Then

                            If cbx_TipoFecha.SelectedIndex = 0 Or (Row.Item("OrdFecha") >= WDesdeFecha And Row.Item("OrdFecha") <= WHastaFecha) Then



                                Dim Posicion As Integer = tablaReporteCtaCte.Rows.Count

                                tablaReporteCtaCte.Rows.Add()

                                With tablaReporteCtaCte.Rows(Posicion)
                                    .Item("Cliente") = WCliente
                                    .Item("Razon") = ""
                                    .Item("Impre") = WImpre
                                    .Item("Numero") = WNumero
                                    .Item("Fecha") = WFecha
                                    .Item("FechaOrd") = ordenaFecha(WFecha)
                                    .Item("Vencimiento") = Wvencimiento
                                    .Item("Vencimiento1") = WVencimiento1
                                    .Item("OrdVencimiento") = WOrdVencimiento
                                    .Item("Claveimpre") = WCliente & WOrdFecha & WTipo & WNumero.PadLeft(8, "0")
                                    .Item("Importe1") = Val(formatonumerico(WImporte1))
                                    .Item("Importe2") = Val(formatonumerico(WImporte2))
                                    .Item("Importe3") = Val(formatonumerico(WImporte3))

                                    If ClienteAnterior <> WCliente Then
                                        Acumulado = 0
                                    End If
                                    ClienteAnterior = WCliente

                                    Acumulado = Acumulado + Val(formatonumerico(WImporte3))
                                    WImporte4 = Acumulado
                                    '.Item("Importe4") = Val(formatonumerico(WImporte4))
                                    .Item("Importe4") = WImporte4
                                End With



                            End If

                            If cbx_TipoFecha.SelectedIndex = 1 And Row.Item("OrdFecha") < WDesdeFecha Then
                                ZZSaldoIni = ZZSaldoIni + Row.Item("Total")
                            End If

                        End If

                    End If





                    If cbx_TipoFecha.SelectedIndex = 1 Then



                        Dim Posicion As Integer = tablaReporteCtaCte.Rows.Count

                        tablaReporteCtaCte.Rows.Add()

                        With tablaReporteCtaCte.Rows(Posicion)
                            .Item("Cliente") = WCliente
                            .Item("Razon") = ""
                            .Item("Impre") = "SI"
                            .Item("Numero") = "00000000"
                            .Item("Fecha") = "00/00/0000"
                            .Item("FechaOrd") = "00000000"
                            .Item("Vencimiento") = ""
                            .Item("Vencimiento1") = ""
                            .Item("OrdVencimiento") = ""
                            .Item("Claveimpre") = WCliente & "00000000" & "01" & "00000000"
                            .Item("Importe1") = 0
                            .Item("Importe2") = 0
                            .Item("Importe3") = ZZSaldoIni
                            .Item("Importe4") = 0
                        End With


                    End If


                Next

                Dim ListaFilas_ABorrar As New List(Of Integer)
                Dim Posiciones As Integer = 0

                For Each Row_Rep As DataRow In tablaReporteCtaCte.Rows


                    Dim WRazon As String = ""
                    Dim WProvincia As Integer
                    SQLCnslt = "SELECT Razon, Provincia FROM Cliente WHERE Cliente = '" & Row_Rep.Item("Cliente") & "'"

                    Dim RowCli As DataRow = GetSingle(SQLCnslt, Operador.Base)
                    If RowCli IsNot Nothing Then
                        WRazon = RowCli.Item("Razon")
                        Row_Rep.Item("Razon") = WRazon
                        WProvincia = RowCli("Provincia")
                    End If


                    If cbx_TipoCliente.SelectedIndex = 1 And WProvincia <> 24 Then

                        ListaFilas_ABorrar.Add(Posiciones)
                    End If
                    Posiciones += 1
                Next


                'CONSULTAR SI ESTA BIEN ESTA LOGICA
                If ListaFilas_ABorrar.Count > 0 Then

                    ListaFilas_ABorrar.Sort()
                    ListaFilas_ABorrar.Reverse()


                    ' For i = ListaFilas_ABorrar.Count To 0
                    '     tablaCtaCte.Rows.RemoveAt(i)
                    ' Next
                    For i = 0 To (ListaFilas_ABorrar.Count - 1)

                        tablaReporteCtaCte.Rows.RemoveAt(ListaFilas_ABorrar(i))
                    Next
                End If
               


            End If



            WTitulo = ""

            If rabtn_CtaCte.Checked = True Then
                WTitulo = "Cuenta Corriente - "
            End If
            If rabtn_Documentos.Checked = True Then
                WTitulo = "Documentos - "
            End If
            If rabtn_Total.Checked = True Then
                WTitulo = "Total - "
            End If
            If rabtn_Diferencia.Checked = True Then
                WTitulo = "Diferencia Cambio - "
            End If

            If cbx_TipoCliente.SelectedIndex = 1 Then
                WTitulo = "Exterior - "
            End If

            If rabtn_Pesos.Checked = True Then
                WTitulo = WTitulo + "Pesos"
            Else
                WTitulo = WTitulo + "Dolares"
            End If

            Dim NombreBase As String = Operador.Base



            Dim Formula As String = "{tablaReporteCtaCte.Cliente} >= '" & txt_Desde.Text & "' AND {tablaReporteCtaCte.Cliente} <=  '" & txt_Hasta.Text & "'"


            ' If chk_FechaVto.Checked Then
            '     Formula = Formula + " AND {tablaReporteCtaCte.OrdVencimiento} >= '" & DesdeFecha & "' AND {tablaReporteCtaCte.OrdVencimiento} <=  '" & HastaFecha & "'"
            ' Else
            '     Formula = Formula + " AND {tablaReporteCtaCte.FechaOrd} >= '" & DesdeFecha & "' AND {tablaReporteCtaCte.FechaOrd} <=  '" & HastaFecha & "'"
            ' End If


            If Trim(WDesdeFecha.Replace("/", "")) <> "" And Trim(WHastaFecha.Replace("/", "")) <> "" Then
                Formula = Formula + " AND (({tablaReporteCtaCte.OrdVencimiento} >= '" & WDesdeFecha & "' AND {tablaReporteCtaCte.OrdVencimiento} <=  '" & WHastaFecha & "') " _
                    & " OR ({tablaReporteCtaCte.FechaOrd} >= '" & WDesdeFecha & "' AND {tablaReporteCtaCte.FechaOrd} <=  '" & WHastaFecha & "'))"
            End If



            With New VistaPrevia
                .Reporte = New ReporteListado_CtaCte
                .Reporte.SetDataSource(tablaReporteCtaCte)
                .Reporte.SetParameterValue(0, NombreBase)
                .Reporte.SetParameterValue(1, WTitulo)
                .Formula = Formula

                If rabtn_Pantalla.Checked = True Then
                    .Mostrar()
                Else
                    .Imprimir()
                End If
            End With

        Catch ex As Exception
            MsgBox(ex.TargetSite)
        End Try



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

    Private Sub CuentaCorrientes_DeClientes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
   

        cbx_TipoFecha.SelectedIndex = 0

        cbx_TipoCliente.SelectedIndex = 0

        txt_Desde.Text = ""
        txt_Hasta.Text = ""
        txt_DesdeFecha.Text = "  /  /    "
        txt_HastaFecha.Text = "  /  /    "
    
    End Sub

    
    Private Sub txt_Desde_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_Desde.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                txt_Desde.Text = UCase(txt_Desde.Text)
                txt_Hasta.Focus()
            Case Keys.Escape
                txt_Desde.Text = ""
        End Select
       
    End Sub

    Private Sub txt_Hasta_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_Hasta.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                txt_Hasta.Text = UCase(txt_Hasta.Text)
                txt_DesdeFecha.Focus()
            Case Keys.Escape
                txt_Hasta.Text = ""
        End Select
    End Sub

    Private Sub txt_DesdeFecha_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_DesdeFecha.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                If txt_DesdeFecha.Text.Length = 10 Then
                    If ValidaFecha(txt_DesdeFecha.Text) = "S" Then
                        txt_HastaFecha.Focus()
                        Exit Sub
                    End If

                End If
                MsgBox("Fecha incorrecta, verificar")
                txt_DesdeFecha.Focus()
            Case Keys.Escape
                txt_DesdeFecha.Text = ""
        End Select
        
    End Sub

    Private Sub txt_HastaFecha_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_HastaFecha.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                If txt_HastaFecha.Text.Length = 10 Then
                    If ValidaFecha(txt_HastaFecha.Text) = "S" Then
                        Exit Sub

                    End If

                End If
                MsgBox("Fecha incorrecta, verificar")
                txt_HastaFecha.Focus()
            Case Keys.Escape
                txt_DesdeFecha.Text = ""
        End Select
    End Sub



   



End Class