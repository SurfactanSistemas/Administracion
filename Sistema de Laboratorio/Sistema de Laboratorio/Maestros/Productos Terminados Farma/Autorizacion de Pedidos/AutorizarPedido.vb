Imports ConsultasVarias
Imports ConsultasVarias.Clases

Public Class AutorizarPedido
    Private Pedido As String

    Sub New(ByVal Pedido As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.Pedido = Pedido
    End Sub

    Private Sub AutorizarPedido_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        For Each lbl As Label In GroupBox1.Controls.OfType(Of Label).Where(Function(c) _Left(c.Name, 3) = "lbl")
            lbl.BackColor = Globales.WBackColorTerciario
            lbl.Text = ""
        Next

        lblPedido.Text = Pedido
        Dim WCamposLotes As String = ""

        For i = 1 To 12
            WCamposLotes &= "p.Lote" & i & ", p.CantiLote" & i & ","
        Next

        WCamposLotes = WCamposLotes.TrimEnd(",")

        Dim WDatos As DataTable = GetAll("SELECT p.Pedido, Producto = p.Terminado, t.Descripcion, Cantidad = (p.Cantidad - p.Facturado), AEntregar = p.Cantidad1, p.Renglon, p.Cliente, c.Razon, p.Fecha, p.FecEntrega, Tipo = CASE p.TipoPed WHEN 0 THEN 'NORMAL' WHEN 1 THEN 'A FECHA' WHEN 2 THEN 'FECHA LIMITE' WHEN 3 THEN 'URGENTE' WHEN 4 THEN 'RETIRA CLIENTE' WHEN 5 THEN 'MUESTRA' ELSE '' END, " & WCamposLotes & ", Partidas = CASE WHEN ISNULL(Lote1, 0) <> 0 And ISNULL(Lote2, 0) <> 0 THEN -1 ELSE Lote1 END from Pedido p INNER JOIN Cliente c ON c.Cliente = p.Cliente INNER JOIN Terminado t ON t.Codigo = p.Terminado where p.Pedido = '" & Pedido & "' ORDER BY p.Renglon", "SurfactanSa")

        For Each row As Datarow In WDatos.Rows
            With row
                If .Item("Renglon") = 1 Then
                    lblCliente.Text = Trim(OrDefault(.Item("Cliente"), ""))
                    lblFecha.Text = Trim(OrDefault(.Item("Fecha"), "00/00/0000"))
                    lblFecEntrega.Text = Trim(OrDefault(.Item("FecEntrega"), "00/00/0000"))
                    lblDescCliente.Text = Trim(OrDefault(.Item("Razon"), ""))
                    lblTipoPedido.Text = Trim(OrDefault(.Item("Tipo"), ""))
                End If

                Dim WProducto, WDescripcion, WCantidad, WEntrega, WPartida As String

                WProducto = OrDefault(row.Item("Producto"), "")
                WDescripcion = OrDefault(row.Item("Descripcion"), "")
                WCantidad = formatonumerico(OrDefault(row.Item("Cantidad"), "0"))
                WEntrega = formatonumerico(OrDefault(row.Item("AEntregar"), "0"))
                WPartida = OrDefault(row.Item("Partidas"), "0")

                If Val(OrDefault(.Item("Lote1"), "")) <> 0 And Val(OrDefault(.Item("Lote2"), "")) <> 0 Then

                    With dgvDatos.Rows(dgvDatos.Rows.Add)
                        .Cells("Producto").Value = WProducto
                        .Cells("Descripcion").Value = WDescripcion
                        .Cells("Cantidad").Value = WCantidad
                        .Cells("Entregar").Value = WEntrega
                        .Cells("Partida").Value = IIf(Val(WPartida) = -1, "VARIOS", WPartida)
                        .Cells("Canti").Value = ""
                    End With

                    For x = 1 To 12

                        WPartida = OrDefault(.Item("Lote" & x), "")

                        If Val(WPartida) <> 0 Then
                            Dim r = dgvDatos.Rows.Add

                            WProducto = ""
                            WDescripcion = ""
                            WCantidad = ""
                            WEntrega = OrDefault(row.Item("CantiLote" & x), "0")

                            If Val(WEntrega) = 0 Then Continue For

                            With dgvDatos.Rows(r)
                                .Cells("Producto").Value = WProducto
                                .Cells("Descripcion").Value = WDescripcion
                                .Cells("Cantidad").Value = "" 'formatonumerico(WCantidad)
                                .Cells("Canti").Value = formatonumerico(WEntrega)
                                .Cells("Partida").Value = WPartida

                                Dim WVenc() As String = _DeterminarVencimientos(WPartida)

                                .Cells("Venc75").Value = WVenc(0)
                                .Cells("Revalida").Value = WVenc(1)
                                .DefaultCellStyle.BackColor = Globales.WBackColorCuaternario
                            End With
                        End If
                    Next
                Else

                    With dgvDatos.Rows(dgvDatos.Rows.Add)
                        .Cells("Producto").Value = WProducto
                        .Cells("Descripcion").Value = WDescripcion
                        .Cells("Cantidad").Value = WCantidad
                        .Cells("Entregar").Value = WEntrega
                        .Cells("Partida").Value = WPartida
                        .Cells("Canti").Value = WEntrega

                        Dim WVenc() As String = _DeterminarVencimientos(OrDefault(row.Item("Lote1"), ""))

                        .Cells("Venc75").Value = WVenc(0)
                        .Cells("Revalida").Value = WVenc(1)
                    End With

                End If

            End With
        Next

    End Sub

    Private Function _DeterminarVencimientos(ByVal Partida As String) As String()
        Dim WVenc() As String = {"", ""}

        Dim WFecha, WMeses, WRevalida, WMesesRevalida, WFechaRevalida As String
        Dim WVida, WMes, WAnio As Short

        Dim WHoja As DataRow = GetSingle("SELECT h.Fecha, h.FechaRevalida, h.MesesRevalida, h.Revalida, Meses = t.Vida FROM Hoja h INNER JOIN Terminado t ON t.Codigo = h.Producto WHERE h.Hoja = '" & Partida & "' AND Renglon = 1")

        If WHoja IsNot Nothing Then
            With WHoja
                WFecha = OrDefault(.Item("Fecha"), "")
                WFechaRevalida = OrDefault(.Item("FechaRevalida"), "")
                WMesesRevalida = OrDefault(.Item("MesesRevalida"), "")
                WRevalida = OrDefault(.Item("Revalida"), "")
                WMeses = OrDefault(.Item("Meses"), "")

                '
                ' Verificamos el 75%.
                '
                If Val(WRevalida) <> 0 Then
                    WVida = Val(WMesesRevalida) * 0.75
                    WMes = Val(Mid(WFechaRevalida, 4, 2))
                    WAnio = Val(_Right(WFechaRevalida, 4))

                    WVenc(1) = "S"

                Else
                    WVida = Val(WMeses) * 0.75
                    WMes = Val(Mid(WFecha, 4, 2))
                    WAnio = Val(_Right(WFecha, 4))
                End If

                For CicloVida = 1 To WVida
                    WMes = WMes + 1
                    If WMes > 12 Then
                        WAnio = WAnio + 1
                        WMes = 1
                    End If
                Next CicloVida

                Dim Auxi As String = WAnio.ToString.PadLeft(4, "0") & WMes.ToString.PadLeft(2, "0") & "01"

                If Val(Auxi) < Val(Date.Now.ToString("yyyyMMdd")) Then
                    WVenc(0) = "S"
                End If

            End With

        End If

        Return WVenc

    End Function

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Close()
    End Sub

    Private Sub btnAutorizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAutorizar.Click
        If MsgBox("¿Se encuentra seguro de querér autorizar el actual Pedido?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            ExecuteNonQueries("SurfactanSa", {"UPDATE Pedido SET MarcaFactura = '1' WHERE Pedido = '" & Pedido & "'"})
            Close()
        End If
    End Sub

    Private Sub dgvDatos_CellMouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvDatos.CellMouseDoubleClick
        If e.ColumnIndex = dgvDatos.Columns("Partida").Index Then
            Dim WPartida As String = OrDefault(dgvDatos.CurrentCell.Value, "")

            If Val(WPartida) = 0 Then Exit Sub

            With New DetallesHojaProduccion(WPartida)
                .ShowDialog(Me)
            End With

        End If
    End Sub

    Private Sub dgvDatos_CellMouseEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDatos.CellMouseEnter
        If e.ColumnIndex = dgvDatos.Columns("Partida").Index Then
            ToolTip1.Show("Haga Doble Click sobre la partida para ver los detalles de la Hoja de Producción, sus ensayos y movimientos.", sender, 10000)
        End If
    End Sub
End Class