Imports ConsultasVarias.Clases.Query
Imports ConsultasVarias.Clases.Helper
Public Class OrdenesTrabajoDesarrollo : Implements IOrdenDeTrabajoDesarrollo




    Private Sub BuscarDatos()
        DGV_OrdenesDesarrollo.Rows.Clear()

        Dim WDesde, WHasta As String
        If Trim(txtFechaDesde.Text.Replace("/", "")) <> "" And Trim(txtFechaHasta.Text.Replace("/", "")) <> "" Then
            WDesde = ordenaFecha(txtFechaDesde.Text)
            WHasta = ordenaFecha(txtFechaHasta.Text)
        Else
            WDesde = "00000000"
            WHasta = "99999999"
        End If


        Dim SQLCnslt As String = ""
        Select Case cbxEstado.SelectedItem
            Case "Todos"
                SQLCnslt = "SELECT Vendedor, Pedido, Fecha, Observaciones, Respuesta, Destino, EstadoLabora, Cliente " _
                           & "FROM PedidoOrdenTrabajo WHERE OrdFecha >= '" & WDesde & "' AND OrdFecha <= '" & WHasta & "' " _
                           & "ORDER BY Pedido"

            Case "Pendientes Aprobar"
                SQLCnslt = "SELECT Vendedor, Pedido, Fecha, Observaciones, Respuesta, Destino, EstadoLabora, Cliente " _
                           & "FROM PedidoOrdenTrabajo WHERE OrdFecha >= '" & WDesde & "' AND OrdFecha <= '" & WHasta & "' " _
                           & "AND Respuesta = 0 " _
                           & "ORDER BY Pedido"

            Case "Aprobados"
                SQLCnslt = "SELECT Vendedor, Pedido, Fecha, Observaciones, Respuesta, Destino, EstadoLabora, Cliente " _
                           & "FROM PedidoOrdenTrabajo WHERE OrdFecha >= '" & WDesde & "' AND OrdFecha <= '" & WHasta & "' " _
                           & "AND Respuesta = 1 " _
                           & "ORDER BY Pedido"

            Case "Rechazados"
                SQLCnslt = "SELECT Vendedor, Pedido, Fecha, Observaciones, Respuesta, Destino, EstadoLabora, Cliente " _
                           & "FROM PedidoOrdenTrabajo WHERE OrdFecha >= '" & WDesde & "' AND OrdFecha <= '" & WHasta & "' " _
                           & "AND Respuesta = 2 " _
                           & "ORDER BY Pedido"

            Case "Aprobados Laboratorio"
                SQLCnslt = "SELECT Vendedor, Pedido, Fecha, Observaciones, Respuesta, Destino, EstadoLabora, Cliente " _
                           & "FROM PedidoOrdenTrabajo WHERE OrdFecha >= '" & WDesde & "' AND OrdFecha <= '" & WHasta & "' " _
                           & "AND Respuesta = 1 " _
                           & "AND Destino = 2 " _
                           & "ORDER BY Pedido"

            Case "Aprobados Laboratorio Pendientes"
                SQLCnslt = "SELECT Vendedor, Pedido, Fecha, Observaciones, Respuesta, Destino, EstadoLabora, Cliente " _
                           & "FROM PedidoOrdenTrabajo WHERE OrdFecha >= '" & WDesde & "' AND OrdFecha <= '" & WHasta & "' " _
                           & "AND Respuesta = 1 " _
                           & "AND Destino = 2 " _
                           & "AND EstadoLabora <> 'N' " _
                           & "ORDER BY Pedido"

            Case "Aprobados Laboratorio Finalizado"
                SQLCnslt = "SELECT Vendedor, Pedido, Fecha, Observaciones, Respuesta, Destino, EstadoLabora, Cliente " _
                           & "FROM PedidoOrdenTrabajo WHERE OrdFecha >= '" & WDesde & "' AND OrdFecha <= '" & WHasta & "' " _
                           & "AND Respuesta = 1 " _
                           & "AND Destino = 2 " _
                           & "AND EstadoLabora = 'N' " _
                           & "ORDER BY Pedido"

            Case "Aprobados Desarrollo"
                SQLCnslt = "SELECT Vendedor, Pedido, Fecha, Observaciones, Respuesta, Destino, EstadoLabora, Cliente " _
                           & "FROM PedidoOrdenTrabajo WHERE OrdFecha >= '" & WDesde & "' AND OrdFecha <= '" & WHasta & "' " _
                           & "AND Respuesta = 1 " _
                           & "AND Destino = 1 " _
                           & "ORDER BY Pedido"

        End Select

        Dim tabla As DataTable = GetAll(SQLCnslt, "SurfactanSa")
        If tabla.Rows.Count > 0 Then
            For Each Row As DataRow In tabla.Rows
                With Row
                    If Val(txtVendedor.Text) = 0 Or Val(txtVendedor.Text) = Row.Item("Vendedor") Then
                        Dim WNroPedido As String = .Item("Pedido").ToString().PadLeft(6, "0")

                        Dim WRazon As String = ""
                        SQLCnslt = "SELECT Razon FROM Cliente WHERE Cliente = '" & .Item("Cliente") & "'"
                        Dim rowCliente As DataRow = GetSingle(SQLCnslt, "SurfactanSa")
                        If rowCliente IsNot Nothing Then
                            WRazon = rowCliente.Item("Razon")
                        End If

                        Dim WNombreVendedor As String = ""
                        SQLCnslt = "SELECT Nombre FROM Vendedor WHERE Vendedor = '" & .Item("Vendedor") & "'"
                        Dim rowVendedor As DataRow = GetSingle(SQLCnslt, "SurfactanSa")
                        If rowVendedor IsNot Nothing Then
                            WNombreVendedor = rowVendedor.Item("Nombre")
                        End If

                        Dim WEstado As String = ""
                        Select Case .Item("Respuesta")
                            Case 0
                                WEstado = "Pendiente de Aprobar"
                            Case 1
                                WEstado = "Aprobada"
                                If .Item("Destino") = 1 Then
                                    WEstado = "Desarrollo"
                                End If
                                If .Item("Destino") = 2 Then
                                    If .Item("EstadoLabora") = "N" Then
                                        WEstado = "Laboratorio Finalizado"
                                    Else
                                        WEstado = "Laboratorio Pendiente"
                                    End If
                                End If
                            Case 2
                                WEstado = "Rechazada"

                        End Select

                        DGV_OrdenesDesarrollo.Rows.Add(WNroPedido, .Item("Fecha"), Trim(WRazon), Trim(WNombreVendedor), Trim(.Item("Observaciones")), WEstado)

                    End If
                End With


            Next
        End If


    End Sub

    Private Sub OrdenesTrabajoDesarrollo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cbxEstado.SelectedIndex = 0
        BuscarDatos()
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Close()
    End Sub

    Private Sub btnFiltrar_Click(sender As Object, e As EventArgs) Handles btnFiltrar.Click
        BuscarDatos()
    End Sub

    Private Sub txtVendedor_KeyDown(sender As Object, e As KeyEventArgs) Handles txtVendedor.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                If txtVendedor.Text <> 0 Then
                    Dim SQLCnslt As String = "SELECT Nombre FROM Vendedor WHERE Vendedor = '" & txtVendedor.Text & "'"
                    Dim row As DataRow = GetSingle(SQLCnslt, "SurfactanSa")
                    If row IsNot Nothing Then
                        txtDesripcion.Text = row.Item("Nombre")
                    Else
                        MsgBox("Codigo incorrecto de vendedor")
                        txtVendedor.Focus()
                    End If
                End If
            Case Keys.Escape
                txtVendedor.Text = ""

        End Select
    End Sub



    Private Sub SoloNumero(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtVendedor.KeyPress
        If Not Char.IsNumber(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub



    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        With New IngresoPedidoDesarrollo
            .Show(Me)
        End With
    End Sub

    Private Sub DGV_OrdenesDesarrollo_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGV_OrdenesDesarrollo.CellDoubleClick
        With New IngresoPedidoDesarrollo(DGV_OrdenesDesarrollo.CurrentRow.Cells("Pedido").Value.ToString())
            .Show(Me)
        End With
    End Sub

    Private Sub DGV_OrdenesDesarrollo_RowHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DGV_OrdenesDesarrollo.RowHeaderMouseClick
        If MsgBox("¿Desea borrar el pedido numero " & DGV_OrdenesDesarrollo.CurrentRow.Cells("Pedido").Value & "?", vbYesNo) = vbYes Then
            Dim SQLCnsl As String = "DELETE FROM PedidoOrdenTrabajo WHERE Pedido = '" & Val(DGV_OrdenesDesarrollo.CurrentRow.Cells("Pedido").Value) & "'"
            ExecuteNonQueries({SQLCnsl}, "SurfactanSa")
            btnFiltrar_Click(Nothing, Nothing)
        End If
    End Sub

    Public Sub _ProcesarDatosOrdenDesarrollo() Implements IOrdenDeTrabajoDesarrollo._ProcesarDatosOrdenDesarrollo
        btnFiltrar_Click(Nothing, Nothing)
    End Sub
End Class