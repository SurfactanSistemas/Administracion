Imports Util.Clases
Imports Util.Clases.Query
Imports Util.Clases.Helper

Public Class IngresoPedido
    Private WDireccionesEntrega As New DireccionesEntregaCliente
    Private WEspecificacionesPedidoCliente As New EspecificacionesPedidoCliente

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Close()
    End Sub

    Private Sub SoloNumero(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPedido.KeyPress, txtVersion.KeyPress
        If Not Char.IsNumber(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
    
    Private Sub NumerosConComas(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtHora.KeyPress, txtModPrecio.KeyPress
        If Not Char.IsNumber(e.KeyChar) And Not Char.IsControl(e.KeyChar) And Not (CChar(".")) = e.KeyChar Then
            e.Handled = True
        End If
    End Sub
    
    Private Sub txtPedido_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPedido.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txtPedido.Text) = "" Then : Exit Sub : End If

            Dim WPedido As String = txtPedido.Text

            btnLimpiar_Click(Nothing, Nothing)

            txtPedido.Text = WPedido

            Dim Ped As DataTable = GetAll("SELECT * FROM Pedido WHERE Pedido  = '" & txtPedido.Text & "' ORDER BY Renglon")

            For Each row As DataRow In Ped.Rows
                With row
                    txtFecha.Text = OrDefault(.Item("Fecha"), "")
                    txtFechaEntrega.Text = OrDefault(.Item("FecEntrega"), "")
                    txtVersion.Text = OrDefault(.Item("Version"), "1")
                    txtCliente.Text = OrDefault(.Item("Cliente"), "")
                    cmbTipoPedido.SelectedIndex = Val(OrDefault(.Item("TipoPed"), ""))
                    txtOrdenCpa.Text = OrDefault(.Item("OrdenCpa"), "")
                    cmbVia.SelectedIndex = Val(OrDefault(.Item("Via"), ""))
                End With

                Dim r As Short = dgvItems.Rows.Add

                With dgvItems.Rows(r)
                    .Cells("Terminado").Value = OrDefault(row("Terminado"), "")
                    .Cells("Descripcion").Value = OrDefault(row("NombreComercial"), "")
                    .Cells("Cantidad").Value = String.Format("{0:N2}", OrDefault(row("Cantidad"), "0"))
                    .Cells("Envase1").Value = OrDefault(row("Envase1"), "")
                    .Cells("Envase2").Value = OrDefault(row("Envase2"), "")
                    .Cells("Envase3").Value = OrDefault(row("Envase3"), "")
                    .Cells("Canti1").Value = OrDefault(row("Canti1"), "")
                    .Cells("Canti2").Value = OrDefault(row("Canti2"), "")
                    .Cells("Canti3").Value = OrDefault(row("Canti3"), "")
                    .Cells("Especificaciones").Value = OrDefault(row("Especificaciones"), "")
                    .Cells("NombreComercial").Value = OrDefault(row("NombreComercial"), "")
                    .Cells("OrdenTrabajo").Value = OrDefault(row("OrdenTrabajo"), "")
                    .Cells("Referencia").Value = OrDefault(row("Referencia"), "")

                    .Cells("Precio").Value = String.Format("{0:N2}", "0")

                    Dim WTipoProd As String = "M"

                    If Not {"PT", "YQ", "YF", "YP", "YH", "PE"}.Contains(.Cells("Terminado").Value) Then WTipoProd = "T"

                    If WTipoProd = "M" Then

                        Dim Art As String = Helper.Left(.Cells("Terminado").Value, 3) & Helper.Right(.Cells("Terminado").Value, 7)

                        Dim Prec As DataRow = GetSingle("SELECT Precio FROM PreciosMP WHERE Cliente = '" & txtCliente.Text & "' AND Articulo = '" & Art & "'")

                        If Prec IsNot Nothing AndAlso Not {5, 6}.Contains(cmbTipoPedido.SelectedIndex) Then
                            .Cells("Precio").Value = String.Format("{0:N2}", OrDefault(Prec("Precio"), "0"))
                        End If

                        If Trim(.Cells("Descripcion").Value) = "" Then

                            Dim WArt As DataRow = GetSingle("SELECT Descripcion FROM Articulo WHERE Codigo = '" & Art & "'")

                            If WArt IsNot Nothing Then .Cells("Descripcion").Value = Trim(OrDefault(WArt("Descripcion"), ""))

                        End If

                    Else
                        Dim Prec As DataRow = GetSingle("SELECT Precio, Descripcion FROM Precios WHERE Cliente = '" & txtCliente.Text & "' AND Terminado = '" & .Cells("Terminado").Value & "'")

                        If Prec IsNot Nothing Then

                            If Not {5, 6}.Contains(cmbTipoPedido.SelectedIndex) Then
                                .Cells("Precio").Value = String.Format("{0:N2}", OrDefault(Prec("Precio"), "0"))
                            End If

                            .Cells("Descripcion").Value = Trim(OrDefault(Prec("Descripcion"), ""))

                            If Trim(.Cells("Descripcion").Value) = "" Then

                                Dim WTer As DataRow = GetSingle("SELECT Descripcion FROM Terminado WHERE Codigo = '" & .Cells("Terminado").Value & "'")

                                If WTer IsNot Nothing Then .Cells("Descripcion").Value = Trim(OrDefault(WTer("Descripcion"), ""))

                            End If

                        End If


                    End If

                End With

            Next

            txtCliente_KeyDown(Nothing, New KeyEventArgs(Keys.Enter))

            txtCliente.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtPedido.Text = ""
        End If

    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click

        For Each c As Control In {txtPedido, txtCliente, txtCondPago, txtFecha, txtFechaEntrega, txtHora, txtModPrecio, txtObservaciones, txtOrdenCpa, txtVersion, lblDescCliente, lblDescCondPago, lblDisponible, lblPedido, lblProduccion, lblSI, lblSII, lblSIII, lblSIV, lblStock, lblSV, lblSVI, lblSVII}
            c.Text = ""
        Next

        dgvItems.Rows.Clear()
        dgvEnvases.Rows.Clear()
        dgvEnvasesII.Rows.Clear()

        For i = 0 To 2
            dgvEnvasesII.Rows.Add("", "")
        Next

        Dim Ped As DataRow = GetSingle("SELECT Max(Pedido) As Maximo FROM Pedido")

        If Ped IsNot Nothing Then txtPedido.Text = OrDefault(Ped("Maximo"), "0")

        txtPedido.Focus()

    End Sub

    Private Sub IngresoPedido_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        txtPedido.Focus()
    End Sub

    Private Sub IngresoPedido_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btnLimpiar_Click(Nothing, Nothing)
    End Sub

    Private Sub txtCliente_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCliente.KeyDown

        If e.KeyData = Keys.Enter Then
            WDireccionesEntrega = New DireccionesEntregaCliente
            WEspecificacionesPedidoCliente = New EspecificacionesPedidoCliente

            lblDescCliente.Text = ""

            Dim Cli As DataRow = GetSingle("SELECT c.Razon, c.Pago1, DescCondPago = p.Nombre, c.Precio, c.DirEntrega, c.DirEntregaII, c.DirEntregaIII, c.DirEntregaIV, c.DirEntregaV, c.Especif1, c.Especif2, c.Especif3, c.Especif4, c.Especif5, c.Especif6, c.Especif7, c.Especif8, c.Especif9 FROM Cliente c LEFT OUTER JOIN Pago p ON p.Pago = c.Pago1 WHERE c.Cliente = '" & txtCliente.Text & "'")

            If Cli Is Nothing Then Exit Sub

            lblDescCliente.Text = Trim(OrDefault(Cli("Razon"), "")).ToUpper

            With WDireccionesEntrega

                .DirEntrega = Trim(OrDefault(Cli("DirEntrega"), "")).ToUpper
                .DirEntregaII = Trim(OrDefault(Cli("DirEntregaII"), "")).ToUpper
                .DirEntregaIII = Trim(OrDefault(Cli("DirEntregaIII"), "")).ToUpper
                .DirEntregaIV = Trim(OrDefault(Cli("DirEntregaIV"), "")).ToUpper
                .DirEntregaV = Trim(OrDefault(Cli("DirEntregaV"), "")).ToUpper

                .DireccionSeleccionada = 0

            End With

            With WEspecificacionesPedidoCliente
                .Especif1 = Trim(OrDefault(Cli("Especif1"), "")).ToUpper
                .Especif2 = Trim(OrDefault(Cli("Especif2"), "")).ToUpper
                .Especif3 = Trim(OrDefault(Cli("Especif3"), "")).ToUpper
                .Especif4 = Trim(OrDefault(Cli("Especif4"), "")).ToUpper
                .Especif5 = Trim(OrDefault(Cli("Especif5"), "")).ToUpper
                .Especif6 = Trim(OrDefault(Cli("Especif6"), "")).ToUpper
                .Especif7 = Trim(OrDefault(Cli("Especif7"), "")).ToUpper
                .Especif8 = Trim(OrDefault(Cli("Especif8"), "")).ToUpper
                .Especif9 = Trim(OrDefault(Cli("Especif9"), "")).ToUpper
            End With

            txtModPrecio.Text = String.Format("{0:N2}", formatonumerico(OrDefault(Cli("Precio"), "")))
            txtCondPago.Text = OrDefault(Cli("Pago1"), "")
            lblDescCondPago.Text = Trim(OrDefault(Cli("DescCondPago"), "")).ToUpper

            txtFechaEntrega.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtCliente.Text = ""
        End If

    End Sub

    Private Sub dgvItems_RowHeaderMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvItems.RowHeaderMouseDoubleClick
        If e.ColumnIndex <> -1 Then Exit Sub

        With dgvEnvasesII
            .Rows(0).Cells("CodigoEnvase").Value = dgvItems.CurrentRow.Cells("Envase1").Value
            .Rows(0).Cells("CantidadEnvase").Value = dgvItems.CurrentRow.Cells("Canti1").Value
            .Rows(1).Cells("CodigoEnvase").Value = dgvItems.CurrentRow.Cells("Envase2").Value
            .Rows(1).Cells("CantidadEnvase").Value = dgvItems.CurrentRow.Cells("Canti2").Value
            .Rows(2).Cells("CodigoEnvase").Value = dgvItems.CurrentRow.Cells("Envase3").Value
            .Rows(2).Cells("CantidadEnvase").Value = dgvItems.CurrentRow.Cells("Canti3").Value
        End With

        Dim WProducto As String

        With dgvItems.CurrentRow
            WProducto = .Cells("Terminado").Value
        End With

        If WProducto.Replace("-", "").Trim = "" Then Exit Sub

        '
        ' Calculamos los Kilos pedidos.
        '
        Dim WStockPed As DataRow = GetSingle("SELECT SUM(Cantidad - Facturado) As Total FROM Pedido WHERE Terminado = '" & WProducto & "' And Pedido <> '" & txtPedido.Text & "' GROUP BY Terminado")
        
        lblPedido.Text = String.Format("{0:N2}", IIf(WStockPed IsNot Nothing, WStockPed(0), 0))

        '
        ' Determinamos el tipo de Producto.
        '
        Dim WTipoProd As String = "M"

        If Not {"PT", "YQ", "YF", "YP", "YH", "PE"}.Contains(dgvItems.CurrentRow.Cells("Terminado").Value) Then WTipoProd = "T"

        '
        ' Calculamos el Stock dependiendo del tipo de Prod.
        '
        For Each c As Control In {lblSI, lblSII, lblSIII, lblSIV, lblSV, lblSVI, lblSVII}
            c.Text = "0,00"
        Next

        If WTipoProd = "M" Then
            Dim WStockMp As DataRow = GetSingle("SELECT (Inicial + Entradas - Salidas) FROM Articulo WHERE Codigo = '" & Helper.Left(WProducto, 3) & Helper.Right(WProducto, 7) & "'")
            lblSI.Text = String.Format("{0:N2}", IIf(WStockMp IsNot Nothing, WStockMp(0), 0))
        Else

            Dim WStockSI As DataRow = GetSingle("SELECT (Inicial + Entradas - Salidas) FROM Terminado WHERE Codigo = '" & WProducto & "'")
            If WStockSI IsNot Nothing Then lblSI.Text = String.Format("{0:N2}", WStockSI(0))

            Dim WStockSII As DataRow = GetSingle("SELECT (Inicial + Entradas - Salidas) FROM Terminado WHERE Codigo = '" & WProducto & "'", "Surfactan_II")
            If WStockSII IsNot Nothing Then lblSII.Text = String.Format("{0:N2}", WStockSII(0))

            Dim WStockSIII As DataRow = GetSingle("SELECT (Inicial + Entradas - Salidas) FROM Terminado WHERE Codigo = '" & WProducto & "'", "Surfactan_III")
            If WStockSIII IsNot Nothing Then lblSIII.Text = String.Format("{0:N2}", WStockSIII(0))

            Dim WStockSIV As DataRow = GetSingle("SELECT (Inicial + Entradas - Salidas) FROM Terminado WHERE Codigo = '" & WProducto & "'", "Surfactan_IV")
            If WStockSIV IsNot Nothing Then lblSIV.Text = String.Format("{0:N2}", WStockSIV(0))

            Dim WStockSV As DataRow = GetSingle("SELECT (Inicial + Entradas - Salidas) FROM Terminado WHERE Codigo = '" & WProducto & "'", "Surfactan_V")
            If WStockSV IsNot Nothing Then lblSV.Text = String.Format("{0:N2}", WStockSV(0))

            Dim WStockSVI As DataRow = GetSingle("SELECT (Inicial + Entradas - Salidas) FROM Terminado WHERE Codigo = '" & WProducto & "'", "Surfactan_VI")
            If WStockSVI IsNot Nothing Then lblSVI.Text = String.Format("{0:N2}", WStockSVI(0))

            Dim WStockSVII As DataRow = GetSingle("SELECT (Inicial + Entradas - Salidas) FROM Terminado WHERE Codigo = '" & WProducto & "'", "Surfactan_VII")
            If WStockSVII IsNot Nothing Then lblSVII.Text = String.Format("{0:N2}", WStockSVII(0))

        End If

        lblStock.Text = String.Format("{0:N2}", {lblSI, lblSII, lblSIII, lblSIV, lblSV, lblSVI, lblSVII}.Sum(Function(l) Val(formatonumerico(l.Text))))

        lblProduccion.Text = "0,00"

        lblDisponible.Text = String.Format("{0:N2}", Val(formatonumerico(lblStock.Text)) - Val(formatonumerico(lblPedido.Text)) + Val(formatonumerico(lblProduccion.Text)))

        _CargaEnvases(WProducto)

    End Sub

    Private Sub _CargaEnvases(ByVal Producto As String)
        '
        ' Determinamos el tipo de Producto.
        '
        Dim WTipoProd As String = "M"

        If Not {"PT", "YQ", "YF", "YP", "YH", "PE"}.Contains(Producto) Then WTipoProd = "T"

        dgvEnvases.Rows.Clear()

        For i = 1 To 6
            dgvEnvases.Rows.Add("", "", "")
        Next

        If WTipoProd = "T" Then
            Dim WEnvs As DataRow = GetSingle("SELECT Envase1, Envase2, Envase3, Envase4, Envase5, Envase6 FROM Terminado WHERE Codigo = '" & Producto & "'")

            If WEnvs IsNot Nothing Then

                For i = 1 To 6
                    Dim Cod As String = OrDefault(WEnvs("Envase" & i), "")

                    If Val(Cod) = 0 Then Continue For

                    dgvEnvases.Rows(i - 1).Cells("Cod").Value = Cod

                    Dim WEnv As DataRow = GetSingle("SELECT Abreviatura, kilos FROM Envases WHERE Envases = '" & Cod & "'")
                    If WEnv IsNot Nothing Then
                        dgvEnvases.Rows(i - 1).Cells("Desc").Value = OrDefault(WEnv("abreviatura"), "")
                        dgvEnvases.Rows(i - 1).Cells("Kg").Value = OrDefault(WEnv("Kg"), "")
                    End If
                Next

            End If

        End If

        If dgvEnvases.Rows(0).Cells("Cod").Value = "" Then
            dgvEnvases.Rows(0).Cells("Cod").Value = "99"
            dgvEnvases.Rows(0).Cells("Desc").Value = "Indist."
            dgvEnvases.Rows(0).Cells("Kg").Value = "0"
        End If

    End Sub
End Class

Public Class DireccionesEntregaCliente
    Property DirEntrega As String
    Property DirEntregaII As String
    Property DirEntregaIII As String
    Property DirEntregaIV As String
    Property DirEntregaV As String
    Property DireccionSeleccionada As Short
End Class

Public Class EspecificacionesPedidoCliente
    Property Especif1 As String
    Property Especif2 As String
    Property Especif3 As String
    Property Especif4 As String
    Property Especif5 As String
    Property Especif6 As String
    Property Especif7 As String
    Property Especif8 As String
    Property Especif9 As String
End Class