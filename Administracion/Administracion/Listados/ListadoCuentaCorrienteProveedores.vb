Imports ClasesCompartidas

Public Class ListadoCuentaCorrienteProveedores

    Enum Reporte
        Imprimir
        Pantalla
    End Enum

    Private Sub ListadoCuentaCorrienteProveedores_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Label2.Text = Globals.NombreEmpresa()
        txtDesdeProveedor.Text = "0"
        txtHastaProveedor.Text = "99999999999"
        opcPendiente.Checked = True
        opcCompleto.Checked = False
    End Sub

    Private Sub txtdesdeproveedor_KeyPress(ByVal sender As Object, _
                   ByVal e As System.Windows.Forms.KeyPressEventArgs) _
                   Handles txtDesdeProveedor.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            txtHastaProveedor.Text = txtDesdeProveedor.Text
            txtHastaProveedor.Focus()
        ElseIf e.KeyChar = Convert.ToChar(Keys.Escape) Then
            e.Handled = True
            txtDesdeProveedor.Text = ""
        End If
        If Not IsNumeric(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txthastaproveedor_KeyPress(ByVal sender As Object, _
                   ByVal e As System.Windows.Forms.KeyPressEventArgs) _
                   Handles txtHastaProveedor.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            txtDesdeProveedor.Focus()
        ElseIf e.KeyChar = Convert.ToChar(Keys.Escape) Then
            e.Handled = True
            txtHastaProveedor.Text = ""
        End If
        If Not IsNumeric(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub btnCancela_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancela.Click
        Me.Close()
        MenuPrincipal.Show()
    End Sub

    Private Sub btnConsulta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsulta.Click

        Me.Size = New System.Drawing.Size(606, 505)

        lstAyuda.DataSource = DAOProveedor.buscarProveedoresActivoPorNombre("")

        txtAyuda.Text = ""
        txtAyuda.Visible = True
        lstAyuda.Visible = True

        txtAyuda.Focus()

    End Sub

    Private Sub mostrarProveedor(ByVal proveedor As Proveedor)
        txtDesdeProveedor.Text = proveedor.id
        txtHastaProveedor.Text = proveedor.id
        txtDesdeProveedor.Focus()
    End Sub

    Private Sub lstAyuda_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstAyuda.Click
        mostrarProveedor(lstAyuda.SelectedValue)
    End Sub

    Private Sub _Imprimir(ByVal TipoImpresion As Reporte)
        Dim txtUno As String

        Dim txtFormula As String
        Dim x As Char = Chr(34)
        Dim WSuma As Double
        Dim WOrden As Integer
        Dim txtCorte As String = ""
        Dim txtLLave As Integer = 0
        Dim txtEmpresa As String

        SQLConnector.retrieveDataTable("limpiar_impCtaCtePrvNet")


        REM Reviso el cual esta checkeado asi le pongo los valores a Tipo
        Dim WTipo As Char
        WTipo = "T"
        If (opcPendiente.Checked) Then
            WTipo = "P"
        End If

        txtEmpresa = "Surfactan S.A."

        If Proceso._EsPellital() Then
            txtEmpresa = "Pellital S.A."
        End If

        Dim tabla As DataTable
        tabla = SQLConnector.retrieveDataTable("buscar_cuenta_corriente_proveedores_desdehasta", txtDesdeProveedor.Text, txtHastaProveedor.Text, WTipo)

        For Each row As DataRow In tabla.Rows

            Dim CCPrv As New CtaCteProveedoresDeudaDesdeHasta(row.Item(0).ToString, row.Item(1).ToString, row.Item(2).ToString, row.Item(3).ToString, row.Item(4), row.Item(5), row.Item(6).ToString, row.Item(7).ToString, row.Item(8).ToString, row.Item(9).ToString, row.Item(10), row.Item(11).ToString, row.Item(12).ToString)

            If txtLLave = 0 Then
                txtLLave = 1
                txtCorte = CCPrv.Proveedor
                WSuma = 0
                WOrden = 0
            End If

            If txtCorte <> CCPrv.Proveedor Then
                txtCorte = CCPrv.Proveedor
                WSuma = 0
                WOrden = 0
            End If

            WSuma = WSuma + CCPrv.saldo
            WOrden = WOrden + 1
            SQLConnector.executeProcedure("alta_impCtaCtePrvNet", CCPrv.Clave, CCPrv.Proveedor, CCPrv.Tipo, CCPrv.letra, CCPrv.punto, CCPrv.numero, CCPrv.total, CCPrv.saldo, CCPrv.fecha, CCPrv.vencimiento, CCPrv.VencimientoII, CCPrv.Impre, CCPrv.nroInterno, txtEmpresa, WSuma, WOrden, "", "", "", "", 0, 0, 0, 0, 0, "", 0, 0, 0, 0, 0, 0, 0, 0)

        Next

        Dim WDesde, WHasta

        WDesde = txtDesdeProveedor.Text
        WHasta = txtHastaProveedor.Text

        If Trim(WDesde) = "" Then
            WDesde = "0"
        End If

        If Trim(WHasta) = "" Then
            WHasta = "99999999999"
        End If

        txtUno = "{ImpCtaCtePrvNet.Proveedor} in " & x & WDesde & x & " to " & x & WHasta & x
        txtFormula = txtUno

        Dim viewer As New ReportViewer("Listado de Corriente de Proveedres", Globals.reportPathWithName("wccprvnet.rpt"), txtFormula)


        Select Case TipoImpresion
            Case Reporte.Imprimir
                viewer.imprimirReporte()
            Case Reporte.Pantalla
                viewer.Show()
        End Select

    End Sub

    ' Rutinas de Filtrado Dinámico.
    Private Sub _FiltrarDinamicamente()
        Dim origen As ListBox = lstAyuda
        Dim final As ListBox = lstFiltrada
        Dim cadena As String = Trim(txtAyuda.Text)

        final.Items.Clear()

        If UCase(Trim(cadena)) <> "" Then

            For Each item In origen.Items

                If UCase(item.ToString()).Contains(UCase(Trim(cadena))) Then

                    final.Items.Add(item)

                End If

            Next

            final.Visible = True

        Else

            final.Visible = False

        End If
    End Sub

    Private Sub lstFiltrada_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstFiltrada.MouseClick
        Dim origen As ListBox = lstAyuda
        Dim filtrado As ListBox = lstFiltrada
        Dim texto As TextBox = txtAyuda

        ' Buscamos el texto exacto del item seleccionado y seleccionamos el mismo item segun su indice en la lista de origen.
        origen.SelectedIndex = origen.FindStringExact(filtrado.SelectedItem.ToString)

        ' Llamamos al evento que tenga asosiado el control de origen.
        lstAyuda_Click(Nothing, Nothing)


        ' Sacamos de vista los resultados filtrados.
        filtrado.Visible = False
        texto.Text = ""
    End Sub

    Private Sub txtAyuda_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAyuda.TextChanged
        _FiltrarDinamicamente()
    End Sub

    Private Sub txtDesdeProveedor_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtDesdeProveedor.MouseDoubleClick, txtHastaProveedor.MouseDoubleClick
        btnConsulta.PerformClick()
    End Sub


    Private Sub SoloNumero(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDesdeProveedor.KeyPress, txtHastaProveedor.KeyPress
        If Not Char.IsNumber(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub btnPorPantalla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPorPantalla.Click
        _Imprimir(Reporte.Pantalla)
    End Sub

    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
        _Imprimir(Reporte.Imprimir)
    End Sub
End Class