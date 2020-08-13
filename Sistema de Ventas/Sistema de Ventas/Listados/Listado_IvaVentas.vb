Imports Util
Imports Util.Clases.Query
Imports Util.Clases.Helper

Public Class Listado_IvaVentas




    Private Sub btn_Cerrar_Click(sender As Object, e As EventArgs) Handles btn_Cerrar.Click
        Close()

    End Sub

    Private Sub txt_DesdeFecha_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_DesdeFecha.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                If ValidaFecha(txt_DesdeFecha.Text) = "S" Then
                    txt_HastaFecha.Focus()
                Else
                    MsgBox("La fecha desde es infalida, verificar")
                    txt_DesdeFecha.SelectAll()
                    txt_DesdeFecha.Focus()
                End If

            Case Keys.Escape
                txt_DesdeFecha.Text = ""
        End Select
    End Sub

    Private Sub txt_HastaFecha_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_HastaFecha.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                If ValidaFecha(txt_HastaFecha.Text) = "S" Then

                Else
                    MsgBox("La fecha hasta es infalida, verificar")
                    txt_HastaFecha.SelectAll()
                    txt_HastaFecha.Focus()
                End If

            Case Keys.Escape
                txt_HastaFecha.Text = ""
        End Select
    End Sub

    Private Sub btn_Aceptar_Click(sender As Object, e As EventArgs) Handles btn_Aceptar.Click

        If ValidaFecha(txt_DesdeFecha.Text) = "N" And ValidaFecha(txt_HastaFecha.Text) = "N" Then
            MsgBox("Verificar los campos fecha, son invalidos")
            txt_DesdeFecha.Focus()
            txt_DesdeFecha.SelectAll()
            Exit Sub
        Else
            If ValidaFecha(txt_DesdeFecha.Text) = "N" Then
                MsgBox("Verificar la fecha del campo desde, es invalida")
                txt_DesdeFecha.Focus()
                txt_DesdeFecha.SelectAll()
                Exit Sub
            End If
            If ValidaFecha(txt_HastaFecha.Text) = "N" Then
                MsgBox("Verificar la fecha del campo hasta, es invalida")
                txt_HastaFecha.Focus()
                txt_HastaFecha.SelectAll()
                Exit Sub
            End If

        End If

        Dim WDesde As String = ordenaFecha(txt_DesdeFecha.Text)

        Dim WHasta As String = ordenaFecha(txt_HastaFecha.Text)

'        Dim tablaCliente As New DataTable
'        With tablaCliente.Columns
'            .Add("Cliente")
'            .Add("")
'            .Add("WCodIbuTucu")
'            .Add("")
'        End With

        ' If Dada = 9999 Then
        '
        '     Erase ZZClientes
        '     ZZLugar = 0
        '
        '
        '     spCliente = "ListaClienteConsulta"
        '     rstCliente = db.OpenRecordset(spCliente, dbOpenSnapshot, dbSQLPassThrough)
        '
        '     With rstCliente
        '         .MoveFirst()
        '         Do
        '             If .EOF = False Then
        '                 ZZLugar = ZZLugar + 1
        '                 ZZClientes(ZZLugar) = rstCliente!Cliente
        '                 .MoveNext()
        '             Else
        '                 Exit Do
        '             End If
        '         Loop
        '     End With
        '     rstCliente.Close()
        '
        '     For Ciclo = 1 To ZZLugar
        '
        '         ZZClie = ZZClientes(Ciclo)
        '
        '         spCliente = "ConsultaCliente " + "'" + ZZClie + "'"
        '         rstCliente = db.OpenRecordset(spCliente, dbOpenSnapshot, dbSQLPassThrough)
        '         If rstCliente.RecordCount > 0 Then
        '             WCodIbTucu = IIf(IsNull(rstCliente!IbTucu), "0", rstCliente!IbTucu)
        '             rstCliente.Close()
        '         End If
        '         If WPorceCm05Tucu = 0 Then
        '             WPorceCm05Tucu = 1
        '         End If
        '         Select Case WCodIbTucu
        '             Case 1, 2, 3
        '                 WImpoIbTucu = 0.0175 * WPorceCm05Tucu
        '                 Call redondeo(WImpoIbTucu)
        '                 WImpoPorceIbTucu = 1.75
        '             Case 4
        '                 WImpoIbTucu = WNeto * 0.035
        '                 Call redondeo(WImpoIbTucu)
        '                 WImpoPorceIbTucu = 3.5
        '             Case 5
        '                 WImpoIbTucu = WNeto * 0.025
        '                 Call redondeo(WImpoIbTucu)
        '                 WImpoPorceIbTucu = 2.5
        '             Case Else
        '                 WImpoIbTucu = 0
        '         End Select
        '
        '     Next Ciclo
        '
        ' End If


        Dim listaSQLCnslt As New List(Of String)

        Dim SQLCnslt As String = "UPDATE Ctacte SET ImpoIbTucu = 0 WHERE ImpoIbTucu IS NULL"

        listaSQLCnslt.Add(SQLCnslt)

        SQLCnslt = "UPDATE Ctacte SET ImpoIbCiudad = 0 WHERE ImpoIbCiudad IS NULL"
        listaSQLCnslt.Add(SQLCnslt)

        SQLCnslt = "UPDATE Ctacte SET Importe4 = 0,Importe5	= 0,Importe6 = 0,Importe7 = 0  ,Importe8 = 0"
        listaSQLCnslt.Add(SQLCnslt)

        SQLCnslt = "UPDATE  Ctacte SET Importe4	= Neto, Importe5 = Iva1,Importe6 = Iva2,Importe7 = 0,Importe8 = ImpoIb " _
                    & "WHERE OrdFecha >= '" & WDesde & "' AND OrdFecha <= '" & WHasta & "' and Iva1 <> '0'"
        listaSQLCnslt.Add(SQLCnslt)

        SQLCnslt = "UPDATE Ctacte SET Importe4 = 0, Importe5 = 0, Importe6 = 0, Importe7 = Neto, Importe8 = ImpoIb " _
            & "WHERE OrdFecha >= '" & WDesde & "' AND OrdFecha <= '" & WHasta & "' and Iva1 = '0'"
        listaSQLCnslt.Add(SQLCnslt)

        ExecuteNonQueries(listaSQLCnslt.ToArray(), Operador.Base)

        Dim WTitulo As String = "del " + txt_DesdeFecha.Text + " al " + txt_HastaFecha.Text


        Dim WFormula As String = "{CtaCte.OrdFecha} >= '" & WDesde & "' AND {CtaCte.OrdFecha} <= '" & WHasta & "'" _
         & " AND (({CtaCte.Tipo} >= '01' AND {CtaCte.Tipo} <= '05') OR {CtaCte.Tipo} = '60')"


        With New VistaPrevia
            .Reporte = New ReporteIvaVentas()
            .Reporte.SetParameterValue(0, Operador.Base)
            .Reporte.SetParameterValue(1, WTitulo)
            .Formula = WFormula

            If rabtn_Pantalla.Checked Then
                .Mostrar()
            Else : .Imprimir()
            End If
        End With

        
    End Sub

    Private Sub btn_Consulta_Click(sender As Object, e As EventArgs) Handles btn_Consulta.Click

        If ValidaFecha(txt_DesdeFecha.Text) = "N" And ValidaFecha(txt_HastaFecha.Text) = "N" Then
            MsgBox("Verificar los campos fecha, son invalidos")
            txt_DesdeFecha.Focus()
            txt_DesdeFecha.SelectAll()
            Exit Sub
        Else
            If ValidaFecha(txt_DesdeFecha.Text) = "N" Then
                MsgBox("Verificar la fecha del campo desde, es invalida")
                txt_DesdeFecha.Focus()
                txt_DesdeFecha.SelectAll()
                Exit Sub
            End If
            If ValidaFecha(txt_HastaFecha.Text) = "N" Then
                MsgBox("Verificar la fecha del campo hasta, es invalida")
                txt_HastaFecha.Focus()
                txt_HastaFecha.SelectAll()
                Exit Sub
            End If

        End If




        Dim WDesde As String = ordenaFecha(txt_DesdeFecha.Text)

        Dim WHasta As String = ordenaFecha(txt_HastaFecha.Text)


        '
        '            For Ciclo = 1 To ZZLugar
        '
        '                ZZClie = ZZClientes(Ciclo)
        '
        '                spCliente = "ConsultaCliente " + "'" + ZZClie + "'"
        '                rstCliente = db.OpenRecordset(spCliente, dbOpenSnapshot, dbSQLPassThrough)
        '                If rstCliente.RecordCount > 0 Then
        '                    WCodIbTucu = IIf(IsNull(rstCliente!IbTucu), "0", rstCliente!IbTucu)
        '                    rstCliente.Close()
        '                End If
        '                If WPorceCm05Tucu = 0 Then
        '                    WPorceCm05Tucu = 1
        '                End If
        '                Select Case WCodIbTucu
        '                    Case 1, 2, 3
        '                        WImpoIbTucu = 0.0175 * WPorceCm05Tucu
        '                        Call redondeo(WImpoIbTucu)
        '                        WImpoPorceIbTucu = 1.75
        '                    Case 4
        '                        WImpoIbTucu = WNeto * 0.035
        '                        Call redondeo(WImpoIbTucu)
        '                        WImpoPorceIbTucu = 3.5
        '                    Case 5
        '                        WImpoIbTucu = WNeto * 0.025
        '                        Call redondeo(WImpoIbTucu)
        '                        WImpoPorceIbTucu = 2.5
        '                    Case Else
        '                        WImpoIbTucu = 0
        '                End Select
        '
        '            Next Ciclo
        '
        '        End If



        Dim listaSQLCnslt As New List(Of String)

        Dim SQLCnslt = "UPDATE Ctacte SET ImpoIbTucu = '0' WHERE ImpoIbTucu IS NULL"

        listaSQLCnslt.Add(SQLCnslt)


        SQLCnslt = "UPDATE Ctacte SET ImpoIbCiudad = '0' WHERE ImpoIbCiudad IS NULL"
        listaSQLCnslt.Add(SQLCnslt)

        SQLCnslt = "UPDATE Ctacte SET Importe4 = '0',Importe5 = '0',Importe6 = '0',Importe7 = '0',Importe8 = '0'"
        listaSQLCnslt.Add(SQLCnslt)

        SQLCnslt = "UPDATE  Ctacte SET Importe4	= Neto, Importe5 = Iva1,Importe6 = Iva2,Importe7 = '0',Importe8 = ImpoIb " _
                    & "WHERE OrdFecha >= '" & WDesde & "' AND OrdFecha <= '" & WHasta & "' AND Iva1 <> '0'"
        listaSQLCnslt.Add(SQLCnslt)

        SQLCnslt = "UPDATE Ctacte SET Importe4 = '0', Importe5 = '0', Importe6 = '0', Importe7 = Neto, Importe8 = ImpoIb " _
            & "WHERE OrdFecha >= '" & WDesde & "' AND OrdFecha <= '" & WHasta & "' AND Iva1 = '0'"
        listaSQLCnslt.Add(SQLCnslt)

        ExecuteNonQueries(listaSQLCnslt.ToArray(), Operador.Base)


        Dim WTitulo As String = "Del " & txt_DesdeFecha.Text & " al " & txt_HastaFecha.Text


        Dim WFormula As String = "{CtaCte.OrdFecha} >= '" & WDesde & "' AND {CtaCte.OrdFecha} <= '" & WHasta & "' " _
                                 & "AND {CtaCte.Importe5} <> 0 AND {CtaCte.Tipo} = '04'"

        With New VistaPrevia
            .Reporte = New ReporteAnalisisND()
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

    Private Sub Listado_IvaVentas_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        txt_DesdeFecha.Focus()
    End Sub
End Class