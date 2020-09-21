Imports Util
Imports Util.Clases.Query
Imports Util.Clases.Helper

Public Class Listado_Analisis_Devolucionesvb

    Private Sub btn_Aceptar_Click(sender As Object, e As EventArgs) Handles btn_Aceptar.Click


        If ValidaFecha(txt_Desde.Text) <> "S" Then
            MsgBox("La fecha desde es una fecha invalida, verificar")
            If ValidaFecha(txt_Hasta.Text) <> "S" Then
                MsgBox("La fecha hasta es una fecha invalida, verificar")
            End If
            Exit Sub
        Else
            If ValidaFecha(txt_Hasta.Text) <> "S" Then
                MsgBox("La fecha hasta es una fecha invalida, verificar")
                Exit Sub
            End If
        End If





        Dim WDesde As String = ordenaFecha(txt_Desde.Text)
        Dim WHasta As String = ordenaFecha(txt_Hasta.Text)


        Dim ListaSQLCnslt As New List(Of String)

        Dim SQLCnslt As String = "SELECT Numero, Articulo, Cantidad, Cliente, Fecha, Clave, Lote1 " _
                                    & "FROM Estadistica " _
                                    & "WHERE OrdFecha >= '" & WDesde & "' " _
                                    & "AND OrdFecha <= '" & WHasta & "' " _
                                    & "AND Tipo = '" & "2" & "' " _
                                    & "AND Linea <> '" & "50" & "'"
        Dim TablaEstadistica As DataTable = GetAll(SQLCnslt, Operador.Base)

        If TablaEstadistica.Rows.Count > 0 Then

            For Each RowEstadistica As DataRow In TablaEstadistica.Rows

                Dim ZNumero As String = RowEstadistica.Item("Numero")
                Dim ZArticulo As String = RowEstadistica.Item("Articulo")
                Dim ZClave As String = RowEstadistica.Item("Clave")
                Dim ZNroEntrada = ""
                Dim ZFechaEntrada = ""
                Dim ZNroPedido = ""
                Dim ZFechaPedido = ""
                Dim ZLoteOriginal = ""

                SQLCnslt = "Select Remito " _
                          & "FROM CtaCte " _
                          & "WHERE Numero = '" & ZNumero & "' " _
                          & "AND Tipo = '" & "02" & "'"

                Dim RowCtaCte As DataRow = GetSingle(SQLCnslt)

                If RowCtaCte IsNot Nothing Then
                    ZNroEntrada = RowCtaCte.Item("Remito")
                End If


                Dim VectorEmpresa(2) As String

                VectorEmpresa(0) = "SurfactanSa"
                VectorEmpresa(1) = "Surfactan_III"
                VectorEmpresa(2) = "Surfactan_V"


                For i = 0 To 2

                    Dim ZZArticulo As String = ZArticulo

                    If Microsoft.VisualBasic.Left$(ZArticulo, 2) = "PT" Then
                        ZZArticulo = "NK-" + Microsoft.VisualBasic.Right$(ZArticulo, 9)
                    Else
                        If Microsoft.VisualBasic.Left$(ZArticulo, 2) = "DY" Then
                            ZZArticulo = "DK-" + Microsoft.VisualBasic.Right$(ZArticulo, 9)
                        Else
                            If Microsoft.VisualBasic.Left$(ZArticulo, 2) = "DQ" Then
                                ZZArticulo = "NQ-" + Microsoft.VisualBasic.Right$(ZArticulo, 9)
                            Else
                                If Microsoft.VisualBasic.Left$(ZArticulo, 2) = "DS" Then
                                    ZZArticulo = "NS-" + Microsoft.VisualBasic.Right$(ZArticulo, 9)
                                End If
                            End If
                        End If
                    End If

                    SQLCnslt = "SELECT Fecha, Pedido, Lote " _
                                & "FROM " & VectorEmpresa(i) & ".dbo.EntDev " _
                                & "WHERE Codigo = '" & ZNroEntrada & "' " _
                                & "AND Terminado = '" & ZZArticulo & "'"

                    Dim RowEntDev As DataRow = GetSingle(SQLCnslt)
                    If RowEntDev IsNot Nothing Then
                        ZFechaEntrada = RowEntDev.Item("Fecha")
                        ZNroPedido = RowEntDev.Item("Pedido")
                        ZLoteOriginal = RowEntDev.Item("Lote")
                        Exit For
                    End If

                Next


                Dim ZObservaDevol As String = ""

                SQLCnslt = "SELECT Fecha, Observaciones " _
                            & "FROM PedidoDevol " _
                            & "WHERE Pedido = '" & ZNroPedido & "' " _
                            & "AND NroDev = '" & ZNroEntrada & "'"

                Dim RowPediDevol As DataRow = GetSingle(SQLCnslt, Operador.Base)

                If RowPediDevol IsNot Nothing Then
                    ZFechaPedido = RowPediDevol.Item("Fecha")
                    ZObservaDevol = RowPediDevol.Item("Observaciones")

                End If

                SQLCnslt = "UPDATE Estadistica SET " _
                            & "NroEntrada = '" & ZNroEntrada & "', " _
                            & "FechaEntrada = '" & ZFechaEntrada & "', " _
                            & "NroPedido = '" & ZNroPedido & "', " _
                            & "FechaPedido = '" & ZFechaPedido & "', " _
                            & "ObservaDevol = '" & ZObservaDevol & "', " _
                            & "LoteOriginal = '" & ZLoteOriginal & "' " _
                            & "Where Clave = '" & ZClave & "'"

                ListaSQLCnslt.Add(SQLCnslt)

            Next

        End If

        ExecuteNonQueries(Operador.Base, ListaSQLCnslt.ToArray())


        Dim WTitulo As String = "entre el " & txt_Desde.Text & " hasta el " & txt_Hasta.Text





        Dim WFormula As String = "{Estadistica.OrdFecha} >= '" & WDesde & "' AND {Estadistica.OrdFecha} <= '" & WHasta & "' " _
                                 & "AND {Estadistica.Tipo} = 2 AND {Estadistica.Linea} <> 50"


        With New VistaPrevia
            .Reporte = New Reporte_ListadoAnalisis_Devoluciones()
            .Reporte.SetParameterValue(0, WTitulo)
            .Formula = WFormula

            If rabtn_Pantalla.Checked Then
                .Mostrar()
            Else
                .Imprimir()
            End If

        End With


    End Sub

    Private Sub Listado_Analisis_Devolucionesvb_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        txt_Desde.Focus()
    End Sub


    Private Sub txt_Desde_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_Desde.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                If ValidaFecha(txt_Desde.Text) = "S" Then
                    txt_Hasta.Focus()
                Else
                    MsgBox("La fecha desde es una fecha invalida, verificar")
                    txt_Desde.SelectAll()
                    txt_Desde.Focus()
                End If
            Case Keys.Escape
                txt_Desde.Text = ""
        End Select
    End Sub

    Private Sub txt_Hasta_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_Hasta.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                If ValidaFecha(txt_Hasta.Text) = "S" Then

                Else
                    MsgBox("La fecha hasta es una fecha invalida, verificar")
                    txt_Hasta.SelectAll()
                    txt_Hasta.Focus()
                End If
            Case Keys.Escape
                txt_Hasta.Text = ""
        End Select
    End Sub
End Class