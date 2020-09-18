Imports Util
Imports Util.Clases.Query
Imports Util.Clases.Helper
Public Class ProyeccionCtaCteFecha

    Private Sub btn_Aceptar_Click(sender As Object, e As EventArgs) Handles btn_Aceptar.Click

        Dim TablaPeriodo As New DataTable
        With TablaPeriodo.Columns
            .Add("Anio")
            .Add("Mes")
        End With




        Dim WAno As Integer = Val(Microsoft.VisualBasic.Right$(txt_DesdeFecha.Text, 4))
        Dim WMes As Integer = Val(Mid$(txt_DesdeFecha.Text, 4, 2))
        Dim WDia As Integer = Val(Microsoft.VisualBasic.Left$(txt_DesdeFecha.Text, 2))

        Dim WAnoII As Integer = Val(Microsoft.VisualBasic.Right$(txt_HastaFecha.Text, 4))
        Dim WMesII As Integer = Val(Mid$(txt_HastaFecha.Text, 4, 2))
        Dim WDiaII As Integer = Val(Microsoft.VisualBasic.Left$(txt_HastaFecha.Text, 2))

        Dim ZZLugar As Integer = 0

        Do
            TablaPeriodo.Rows.Add(WAno, WMes)


            If WAno = WAnoII And WMes = WMesII Then
                Exit Do
            End If

            WMes = WMes + 1
            If WMes > 12 Then
                WAno = WAno + 1
                WMes = 1
            End If

        Loop

        Dim WRenglon As Integer = 1
        Dim TablaReporteProDias As DataTable = New DBAuxi.TablaProyectaDiasDataTable()

        For Each RowPeriodo As DataRow In TablaPeriodo.Rows


            Dim WWClave As String
            Dim WWFecha As String = ""
            Dim WWImpo1 As Double = 0
            Dim WWImpo2 As Double = 0
            Dim WWImpo3 As Double = 0
            Dim WWImpo4 As Double = 0
            Dim WWImpo5 As Double = 0
            Dim WWImpo6 As Double = 0
            Dim WWImpo7 As Double = 0


            Dim WAuxiAnio As String = Trim(RowPeriodo.Item("Anio"))
            Dim WAuxiMes As String = Trim(RowPeriodo.Item("Mes"))

            WAuxiMes = WAuxiMes.PadLeft(2, "0")
            WAuxiAnio = WAuxiAnio.PadLeft(4, "0")

            Dim WFecha As String = WAuxiAnio & WAuxiMes & "31"
            Dim WFechaII As String = ""
            Select Case Val(WAuxiMes)
                Case 1, 3, 5, 7, 8, 10, 12
                    WFechaII = "31" & "/" & WAuxiMes & "/" & WAuxiAnio
                Case 2
                    WFechaII = "28" & "/" & WAuxiMes & "/" & WAuxiAnio
                Case Else
                    WFechaII = "30" & "/" & WAuxiMes & "/" & WAuxiAnio
            End Select

            Dim Fecha As String = WAuxiMes & "/" & WAuxiAnio

            WWFecha = Fecha

            ' ZZDatos(ZZZCiclo, 1) = WAuxiMes + "/" + WAuxiAnio

            Dim SQLCnslt As String = "UPDATE CtaCte SET ProyectaSaldo = '" & "0" & "'"

            ExecuteNonQueries({SQLCnslt}, Operador.Base)

            SQLCnslt = "UPDATE CtaCte SET " _
                        & "ProyectaSaldo = Saldo" _
                        & " Where Tipo < '" & "06" & "'" _
                        & " and OrdFecha <= '" & WFecha & "'"

            ExecuteNonQueries({SQLCnslt}, Operador.Base)




            Dim Renglon As Integer = 0
            Dim TRecibosAux As New DataTable
            With TRecibosAux.Columns
                .Add("Tipo")
                .Add("Numero")
                .Add("Importe")
                .Add("Clave")
                .Add("Recibo")
                .Add("Cliente")
            End With

            SQLCnslt = "Select Importe1, Fechaord, Clave, Tipo1, Numero1, Importe1, Cliente, Recibo" _
                        & " FROM Recibos" _
                        & " Where Recibos.Importe1 <> 0 " _
                        & " and Recibos.FechaOrd > " & "'" & WFecha + "'" _
                        & " Order by Recibos.Clave"
            Dim TablaRecibos As DataTable = GetAll(SQLCnslt, Operador.Base)
            If TablaRecibos.Rows.Count > 0 Then

                For Each RowReci As DataRow In TablaRecibos.Rows

                  
                    If WFecha < RowReci.Item("FechaOrd") Then

                        If RowReci.Item("Importe1") <> 0 Then

                            TRecibosAux.Rows.Add()
                            
                            TRecibosAux.Rows(Renglon).Item("Tipo") = RowReci.Item("Tipo1")
                            TRecibosAux.Rows(Renglon).Item("Numero") = RowReci.Item("Numero1")
                            TRecibosAux.Rows(Renglon).Item("Importe") = Str$(RowReci.Item("Importe1"))
                            TRecibosAux.Rows(Renglon).Item("Clave") = RowReci.Item("Clave")
                            TRecibosAux.Rows(Renglon).Item("Recibo") = RowReci.Item("Recibo")
                            TRecibosAux.Rows(Renglon).Item("Cliente") = RowReci.Item("Cliente")

                            Renglon += 1


                        End If

                    End If

                        


                Next
               

            End If
            Dim WParidad As Double = 0
            Dim XClave As String = ""
            For Each RowReci As DataRow In TRecibosAux.Rows


                Dim WTipo As String = RowReci.Item("Tipo").ToString().PadLeft(2, "0")
                Dim WNumero As String = RowReci.Item("Numero").ToString().PadLeft(8, "0")
                Dim WImporte As Double = Val(RowReci.Item("Importe"))
                XClave = RowReci.Item("Clave")
                Dim XRecibo As String = RowReci.Item("Recibo")
                Dim WCliente As String = RowReci.Item("Cliente")
                
                Dim WClave As String = WTipo + WNumero + "01"

                Dim WProv As Integer = 0


                SQLCnslt = "SELECT Provincia FROM Cliente WHERE Cliente = '" & WCliente & "'"
                Dim RowCli As DataRow = GetSingle(SQLCnslt, Operador.Base)
                If RowCli IsNot Nothing Then

                    WProv = RowCli.Item("Provincia")

                End If

                If WProv = 24 Then
                    WAuxiAnio = XRecibo.PadLeft(8, "0")

                    Dim ClaveCtacte As String = "06" + WAuxiAnio + "01"
                    SQLCnslt = "SELECT * FROM Ctacte WHERE Clave = '" & ClaveCtacte & "'"
                    Dim RowCtaCte06 As DataRow = GetSingle(SQLCnslt, Operador.Base)
                    If RowCtaCte06 IsNot Nothing Then
                        WParidad = Str$(RowCtaCte06.Item("Paridad"))
                        Else
                        ClaveCtacte = "07" + WAuxiAnio + "01"
                        SQLCnslt = "SELECT * FROM Ctacte WHERE Clave = '" & ClaveCtacte & "'"
                        Dim RowCtaCte07 As DataRow = GetSingle(SQLCnslt, Operador.Base)
                        If RowCtaCte07 IsNot Nothing Then
                            WParidad = Str$(RowCtaCte07.Item("Paridad"))
                        End If
                    End If
                End If

                Dim ZZImporte As Double = 0

                If WProv = 24 And WParidad <> 0 Then
                    ZZImporte = (WImporte / Val(WParidad))
                Else
                    ZZImporte = WImporte
                End If

                SQLCnslt = "UPDATE CtaCte SET " _
                            & "ProyectaSaldo = ProyectaSaldo + '" & Str$(WImporte) & "'" _
                            & " Where Clave = '" & WClave & "'"

                ExecuteNonQueries({SQLCnslt}, Operador.Base)

            Next


            WAno = Val(Microsoft.VisualBasic.Right$(txt_DesdeFecha.Text, 4))
            WMes = Val(Mid$(txt_DesdeFecha.Text, 4, 2))
            WDia = Val(Microsoft.VisualBasic.Left$(txt_DesdeFecha.Text, 2))
            XClave = WAno & WMes & WDia
            WParidad = 0

            SQLCnslt = "SELECT Cambio FROM Cambios WHERE OrdFecha <= '" & XClave & "' ORDER BY OrdFecha"
            Dim TablaCambio As DataTable = GetAll(SQLCnslt, Operador.Base)
            If TablaCambio.Rows.Count > 0 Then
                For Each RowCambios As DataRow In TablaCambio.Rows
                    WParidad = Str$(RowCambios.Item("Cambio"))
                Next
                
            End If


            Dim ListaTrabajo As New List(Of String)
          
            SQLCnslt = "Select Clave" _
                        & " FROM CtaCte" _
                        & " WHERE ProyectaSaldo <> 0 "
            Dim TablaTra As DataTable = GetAll(SQLCnslt, Operador.Base)
            If TablaTra.Rows.Count > 0 Then

                For Each RowTra As DataRow In TablaTra.Rows
                    ListaTrabajo.Add(RowTra.Item("Clave"))
                Next
                
            End If



            For i = 0 To ListaTrabajo.Count - 1
                
                SQLCnslt = "Select Cliente, ProyectaSaldo, Fecha, Total, TotalUs" _
                            & " FROM CtaCte" _
                            & " Where Clave = '" & ListaTrabajo(i) & "'"

                Dim RowCtaCte As DataRow = GetSingle(SQLCnslt, Operador.Base)
                If RowCtaCte IsNot Nothing Then

                    Dim ZZCliente As String = RowCtaCte.Item("Cliente")
                    Dim ZZImporte As Double = RowCtaCte.Item("ProyectaSaldo")
                    Dim ZZFecha As String = RowCtaCte.Item("Fecha")
                    Dim ZZTotal As Double = RowCtaCte.Item("Total")
                    Dim ZZTotalUs As Double = RowCtaCte.Item("Totalus")

                    Dim WRazon As String = ""
                    Dim WProv As Integer = 0

                    If Trim(ZZCliente) <> "" Then
                        SQLCnslt = "SELECT Razon, Provincia FROM Cliente WHERE Cliente = '" & ZZCliente & "'"
                        Dim Rowclien As DataRow = GetSingle(SQLCnslt, Operador.Base)
                        If Rowclien IsNot Nothing Then
                            WRazon = Rowclien.Item("Razon")
                            WProv = Rowclien.Item("Provincia")
                        End If
                    Else
                        WProv = 1
                    End If

                    If rabtn_Pesos.Checked Then
                        If WProv = 24 And WParidad <> 0 Then
                            ZZImporte = ZZImporte * Val(WParidad)
                        End If
                    End If

                    If rabtn_Dolares.Checked Then
                        If ZZTotalUs <> 0 Then
                            Dim Pari As Double = ZZTotal / ZZTotalUs
                            ZZImporte = ZZImporte / Pari
                        End If
                    End If

                    Dim XFecha As Date = ZZFecha
                    Dim ZZDias As Integer = DateDiff("d", XFecha, WFechaII)

                    If ZZDias <= 30 Then
                        WWImpo1 = WWImpo1 + ZZImporte
                    Else
                        If ZZDias <= 60 Then
                            WWImpo2 = WWImpo2 + ZZImporte
                        Else
                            If ZZDias <= 90 Then
                                WWImpo3 = WWImpo3 + ZZImporte
                            Else
                                If ZZDias <= 120 Then
                                    WWImpo4 = WWImpo4 + ZZImporte
                                Else
                                    If ZZDias <= 150 Then
                                        WWImpo5 = WWImpo5 + ZZImporte
                                    Else
                                        If ZZDias <= 180 Then
                                            WWImpo6 = WWImpo6 + ZZImporte
                                        Else
                                            WWImpo7 = WWImpo7 + ZZImporte
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If



            Next

            TablaReporteProDias.Rows.Add()

            TablaReporteProDias.Rows(WRenglon - 1).Item("Clave") = WRenglon
            TablaReporteProDias.Rows(WRenglon - 1).Item("Fecha") = WWFecha
            TablaReporteProDias.Rows(WRenglon - 1).Item("Impo1") = formatonumerico(WWImpo1)
            TablaReporteProDias.Rows(WRenglon - 1).Item("Impo2") = formatonumerico(WWImpo2)
            TablaReporteProDias.Rows(WRenglon - 1).Item("Impo3") = formatonumerico(WWImpo3)
            TablaReporteProDias.Rows(WRenglon - 1).Item("Impo4") = formatonumerico(WWImpo4)
            TablaReporteProDias.Rows(WRenglon - 1).Item("Impo5") = formatonumerico(WWImpo5)
            TablaReporteProDias.Rows(WRenglon - 1).Item("Impo6") = formatonumerico(WWImpo6)
            TablaReporteProDias.Rows(WRenglon - 1).Item("Impo7") = formatonumerico(WWImpo7)
            TablaReporteProDias.Rows(WRenglon - 1).Item("Empresa") = 1


            WRenglon += 1

            Next

            

        Dim WTitulo As String = ""

        If rabtn_Pesos.Checked Then
            WTitulo = WTitulo + "Pesos"
        End If
        If rabtn_Dolares.Checked Then
            WTitulo = WTitulo + "Dolares"
        End If

        WTitulo = WTitulo + " al " + txt_DesdeFecha.Text

        With New VistaPrevia
            .Reporte = New Reporte_ProyeccionCtaCteAFecha()
            .Reporte.SetDataSource(TablaReporteProDias)
           

            If rabtn_Pantalla.Checked Then
                .Mostrar()
            Else
                .Imprimir()
            End If
        End With


    End Sub

    Private Sub ProyeccionCtaCteFecha_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        txt_DesdeFecha.Focus()
    End Sub

    Private Sub txt_DesdeFecha_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_DesdeFecha.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                If ValidaFecha(txt_DesdeFecha.Text) = "S" Then
                    txt_HastaFecha.Focus()
                Else
                    MsgBox("La fecha desde es invalida, verificar")
                    txt_DesdeFecha.SelectAll()
                End If
            Case Keys.Escape
                txt_DesdeFecha.Text = ""
        End Select
    End Sub

    Private Sub txt_HastaFecha_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_HastaFecha.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                If ValidaFecha(txt_HastaFecha.Text) <> "S" Then
                    MsgBox("La fecha hasta es invalida, verificar")
                    txt_HastaFecha.SelectAll()
                End If
            Case Keys.Escape
                txt_HastaFecha.Text = ""
        End Select
    End Sub
End Class