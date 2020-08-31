Imports Util
Imports Util.Clases.Query
Imports Util.Clases.Helper

Public Class Listado_OrdCompra_Pendientes_deMP : Implements IConsulta_MP

    Private Sub btn_Cerrar_Click(sender As Object, e As EventArgs) Handles btn_Cerrar.Click
        Close()
    End Sub

    Private Sub btn_Consulta_Click(sender As Object, e As EventArgs) Handles btn_Consulta.Click
        With New Consulta_MP
            .Show(Me)
        End With
    End Sub

    Public Sub PasaCodigo(Codigo As String, Accion As String) Implements IConsulta_MP.PasaCodigo

        If Accion = "Ambos" Then
            txt_DesdeCodigo.Text = Codigo
            txt_HastaCodigo.Text = Codigo
        End If

        If Accion = "Desde" Then
            txt_DesdeCodigo.Text = Codigo
        End If

        If Accion = "Hasta" Then
            txt_HastaCodigo.Text = Codigo
        End If

    End Sub

    Private Sub txt_DesdeCodigo_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_DesdeCodigo.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                If txt_DesdeCodigo.Text.Length = 10 Then
                    txt_DesdeCodigo.Text = UCase(txt_DesdeCodigo.Text)
                    txt_HastaCodigo.Focus()
                Else
                    If Trim(txt_DesdeCodigo.Text.Replace("-", "")) = "" Then
                        txt_DesdeCodigo.Text = "AA-000-000"
                        txt_HastaCodigo.Focus()
                    End If
                End If
            Case Keys.Escape
                txt_DesdeCodigo.Text = ""
        End Select
    End Sub

    Private Sub txt_HastaCodigo_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_HastaCodigo.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                If txt_HastaCodigo.Text.Length = 10 Then
                    txt_HastaCodigo.Text = UCase(txt_HastaCodigo.Text)
                Else
                    If Trim(txt_HastaCodigo.Text.Replace("-", "")) = "" Then
                        txt_HastaCodigo.Text = "ZZ-999-999"

                    End If
                End If

            Case Keys.Escape
                txt_HastaCodigo.Text = ""
        End Select
    End Sub

    Private Sub btn_Aceptar_Click(sender As Object, e As EventArgs) Handles btn_Aceptar.Click

        Dim TablaListaOrden As New DataTable
        With TablaListaOrden.Columns
            .Add("Orden")
            .Add("Fecha")
            .Add("Proveedor")
            .Add("Articulo")
            .Add("Cantidad")
            .Add("Fecha2")
            .Add("Saldo")
            .Add("Carpeta")
            .Add("Renglon")
            .Add("NumeroPedido")
            .Add("FechaPedido")
            .Add("TipoPedido")
        End With





        Dim SQLCnslt As String = "DELETE ListaOrdenII"

        ExecuteNonQueries({SQLCnslt}, Operador.Base)


        Dim vectorEmpresas(2) As String
        vectorEmpresas(1) = "SurfactanSa"
        vectorEmpresas(2) = "Surfactan_IV"

        
        For CicloEmpresa = 1 To 2
            
            SQLCnslt = "UPDATE Orden SET Saldo = Cantidad - Recibida"

            ExecuteNonQueries({SQLCnslt}, vectorEmpresas(CicloEmpresa))

            Dim TablaOrdenes As New DataTable
            With TablaOrdenes.Columns
                .Add("Orden")
                .Add("FechaOrd")
            End With


            SQLCnslt = "SELECT Clave, Orden, Fecha2, Cantidad, Recibida FROM Orden ORDER BY Orden"
            Dim TablaOrden As DataTable = GetAll(SQLCnslt, vectorEmpresas(CicloEmpresa))
            If TablaOrden.Rows.Count > 0 Then

                For Each RowOrden As DataRow In TablaOrden.Rows
                    
                    Dim WClave As String = RowOrden.Item("Clave")
                    Dim WOrden As String = RowOrden.Item("Orden")
                    Dim WFecha2 As String = RowOrden.Item("Fecha2")
                    Dim WSaldo As Double = RowOrden.Item("Cantidad") - RowOrden.Item("Recibida")
                    If Val(WSaldo) > 0 Then

                        Dim Entra As String = "S"

                        For XX = 0 To TablaOrdenes.Rows.Count - 1

                            If TablaOrdenes.Rows(XX).Item("Orden") = WOrden Then
                                Entra = "N"
                                Exit For
                            End If

                        Next XX

                        If Entra = "S" Then

                            Dim FechaOrd As String = Microsoft.VisualBasic.Right$(WFecha2, 4) & Mid$(WFecha2, 4, 2) & Microsoft.VisualBasic.Left$(WFecha2, 2)
                            TablaOrdenes.Rows.Add(WOrden, FechaOrd)

                        End If

                    End If
                            
                Next
                

            End If

            For XX = 0 To TablaOrdenes.Rows.Count - 1
                Dim WOrden As String = TablaOrdenes.Rows(XX).Item("Orden")
                Dim WFecha2 As String = TablaOrdenes.Rows(XX).Item("FechaOrd")

                SQLCnslt = "UPDATE  Orden SET OrdFecha2 = '" & WFecha2 & "' WHERE Orden = '" & WOrden & "'"

                ExecuteNonQueries({SQLCnslt}, vectorEmpresas(CicloEmpresa))
            Next XX

            SQLCnslt = "Select PedidoImpo, FechaImpo, TipoImpo, Orden, Fecha, Proveedor,  " _
                        & "Articulo, Cantidad, Fecha2, Saldo,Carpeta, Renglon" _
                        & " FROM Orden" _
                        & " Where Orden.Saldo > 0" _
                        & " and Orden.Articulo >= '" & txt_DesdeCodigo.Text & "'" _
                        & " and Orden.Articulo <= '" & txt_HastaCodigo.Text & "'" _
                        & " Order by Orden.Clave"

            Dim lugar As Integer = 0
            Dim TablaOrd As DataTable = GetAll(SQLCnslt, vectorEmpresas(CicloEmpresa))
            If TablaOrd.Rows.Count > 0 Then

                For Each RowOrd As DataRow In TablaOrd.Rows

                    Dim ZNumeroPedido As String = IIf(IsDBNull(RowOrd.Item("PedidoImpo")), "", RowOrd.Item("PedidoImpo"))
                    Dim ZFechaPedido As String = IIf(IsDBNull(RowOrd.Item("FechaImpo")), "", RowOrd.Item("FechaImpo"))
                    Dim ZTipoPedido As String = IIf(IsDBNull(RowOrd.Item("TipoImpo")), "", RowOrd.Item("TipoImpo"))


                    TablaListaOrden.Rows.Add()
                    TablaListaOrden.Rows(lugar).Item("Orden") = RowOrd.Item("Orden")
                    TablaListaOrden.Rows(lugar).Item("Fecha") = RowOrd.Item("Fecha")
                    TablaListaOrden.Rows(lugar).Item("Proveedor") = RowOrd.Item("Proveedor")
                    TablaListaOrden.Rows(lugar).Item("Articulo") = RowOrd.Item("Articulo")
                    TablaListaOrden.Rows(lugar).Item("Cantidad") = RowOrd.Item("Cantidad")
                    TablaListaOrden.Rows(lugar).Item("Fecha2") = RowOrd.Item("Fecha2")
                    TablaListaOrden.Rows(lugar).Item("Saldo") = RowOrd.Item("Saldo")
                    TablaListaOrden.Rows(lugar).Item("Carpeta") = RowOrd.Item("Carpeta")
                    TablaListaOrden.Rows(lugar).Item("Renglon") = RowOrd.Item("Renglon")
                    TablaListaOrden.Rows(lugar).Item("NumeroPedido") = ZNumeroPedido
                    TablaListaOrden.Rows(lugar).Item("FechaPedido") = ZFechaPedido
                    TablaListaOrden.Rows(lugar).Item("TipoPedido") = ZTipoPedido

                    lugar += 1
                  

                Next
                
            End If

        Next CicloEmpresa


        For Each RowLisOrd As DataRow In TablaListaOrden.Rows

            Dim WClave As String = "1234567891"
            Dim WOrden As Integer = RowLisOrd.Item("Orden")
            Dim WFecha As String = RowLisOrd.Item("Fecha")
            Dim WProveedor As String = RowLisOrd.Item("Proveedor")
            Dim WArticulo As String = RowLisOrd.Item("Articulo")
            Dim WCantidad As Double = RowLisOrd.Item("Cantidad")
            Dim WFechaEntrega As String = RowLisOrd.Item("Fecha2")
            Dim WSaldo As Double = RowLisOrd.Item("Saldo")
            Dim WCarpeta As Integer = RowLisOrd.Item("Carpeta")
            Dim WRenglon As Integer = RowLisOrd.Item("Renglon")
            Dim WNumeroPedido As String = RowLisOrd.Item("NumeroPedido")
            Dim WFechaPedido As String = RowLisOrd.Item("FechaPedido")
            Dim WTipoPedido As Integer = RowLisOrd.Item("TipoPedido")

            Dim LugarObserva As Integer = 0
            Dim TablaListObserva As New DataTable
            With TablaListObserva.Columns
                .Add("Texto1")
                .Add("Texto2")
            End With

            SQLCnslt = "SELECT Texto1, Texto2" _
                        & " FROM ObservaOrden" _
                        & " WHERE Carpeta = '" & WCarpeta & "'" _
                        & " ORDER BY Clave"

            Dim TablaObrserva As DataTable = GetAll(SQLCnslt, Operador.Base)
            If TablaObrserva.Rows.Count > 0 Then
                For Each RowTob As DataRow In TablaObrserva.Rows

                    TablaListObserva.Rows.Add(RowTob.Item("Texto1"), RowTob.Item("Texto2"))
                    LugarObserva += 1

                Next
            End If

            If LugarObserva = 0 Then
                LugarObserva = 1
            End If

            Dim Renglon As Integer = 0
            For Each RowTob As DataRow In TablaListObserva.Rows

                Dim WTexto1 As String = RowTob.Item("Texto1")
                Dim WTexto2 As String = Trim(RowTob.Item("Texto2"))
                If WTexto2.Length > 50 Then
                    WTexto2 = WTexto2.Substring(0, 50)
                End If


                Dim WRenglonII As Integer = Renglon

                SQLCnslt = "INSERT INTO ListaOrdenII (" _
                & "Clave ," _
                & "Orden ," _
                & "Renglon ," _
                & "RenglonII ," _
                & "Fecha ," _
                & "Proveedor ," _
                & "Articulo ," _
                & "Cantidad ," _
                & "FechaEntrega ," _
                & "Saldo ," _
                & "Carpeta ," _
                & "Texto1 ," _
                & "Texto2 ," _
                & "PedidoImpo ," _
                & "FechaImpo ," _
                & "TipoImpo )" _
                & "Values (" _
                & "'" & WClave & "'," _
                & "'" & WOrden & "'," _
                & "'" & WRenglon & "'," _
                & "'" & WRenglonII & "'," _
                & "'" & WFecha & "'," _
                & "'" & WProveedor & "'," _
                & "'" & WArticulo & "'," _
                & "'" & WCantidad & "'," _
                & "'" & WFechaEntrega & "'," _
                & "'" & WSaldo & "'," _
                & "'" & WCarpeta & "'," _
                & "'" & WTexto1 & "'," _
                & "'" & Wtexto2 & "'," _
                & "'" & WNumeroPedido & "'," _
                & "'" & WFechaPedido & "'," _
                & "'" & WTipoPedido & "')"

                ExecuteNonQueries({SQLCnslt}, Operador.Base)
            
            Next

        Next

        REM Listado.GroupSelectionFormula = "{Orden.Articulo} in " + Chr$(34) + Desde.Text + Chr$(34) + " to " + Chr$(34) + Hasta.Text + Chr$(34)
        With New VistaPrevia
            .Reporte = New Reporte_Listadado_OCPendientes_deMP
            .Reporte.SetParameterValue(0, Operador.Base)

            If rabtn_Pantalla.Checked Then
                .Mostrar()
            Else
                .Imprimir()
            End If
        End With
        
    End Sub
End Class