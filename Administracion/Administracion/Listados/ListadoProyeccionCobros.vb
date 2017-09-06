Imports ClasesCompartidas
Imports System.IO

Public Class ListadoProyeccionCobros

    Private Sub ListadoProyeccionCobros_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtAyuda.Text = ""
        txtDesdeProveedor.Text = "0"
        txtHastaProveedor.Text = "99999999999"
        txtFecha1.Text = "  /  /    "
        txtFecha2.Text = "  /  /    "
        txtFecha3.Text = "  /  /    "
        txtFecha4.Text = "  /  /    "
    End Sub

    Private Sub txtdesdeproveedor_KeyPress(ByVal sender As Object, _
                   ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDesdeProveedor.KeyPress

        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
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
                   ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtHastaProveedor.KeyPress

        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            txtFecha1.Focus()
        ElseIf e.KeyChar = Convert.ToChar(Keys.Escape) Then
            e.Handled = True
            txtHastaProveedor.Text = ""
        End If
        If Not IsNumeric(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtfecha1_KeyPress(ByVal sender As Object, _
                   ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFecha1.KeyPress

        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            If ValidaFecha(txtFecha1.Text) = "S" Then
                txtFecha2.Focus()
            End If
        ElseIf e.KeyChar = Convert.ToChar(Keys.Escape) Then
            e.Handled = True
            txtFecha1.Text = "  /  /    "
        End If
    End Sub

    Private Sub txtfecha2_KeyPress(ByVal sender As Object, _
                   ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFecha2.KeyPress

        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            If ValidaFecha(txtFecha2.Text) = "S" Then
                txtFecha3.Focus()
            End If
        ElseIf e.KeyChar = Convert.ToChar(Keys.Escape) Then
            e.Handled = True
            txtFecha2.Text = "  /  /    "
        End If
    End Sub

    Private Sub txtfecha3_KeyPress(ByVal sender As Object, _
                   ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFecha3.KeyPress

        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            If ValidaFecha(txtFecha3.Text) = "S" Then
                txtFecha4.Focus()
            End If
        ElseIf e.KeyChar = Convert.ToChar(Keys.Escape) Then
            e.Handled = True
            txtFecha3.Text = "  /  /    "
        End If
    End Sub

    Private Sub txtfecha4_KeyPress(ByVal sender As Object, _
                   ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFecha4.KeyPress

        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            If ValidaFecha(txtFecha4.Text) = "S" Then
                txtDesdeProveedor.Focus()
            End If
        ElseIf e.KeyChar = Convert.ToChar(Keys.Escape) Then
            e.Handled = True
            txtFecha4.Text = "  /  /    "
        End If
    End Sub





    Private Sub btnCancela_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancela.Click
        Me.Close()
        MenuPrincipal.Show()
    End Sub

    Private Sub btnConsulta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsulta.Click

        Me.Size = New System.Drawing.Size(645, 580)

        lstAyuda.DataSource = DAOProveedor.buscarProveedoresActivoPorNombre

        txtAyuda.Text = ""
        txtAyuda.Visible = True
        lstAyuda.Visible = True

        txtAyuda.Focus()

    End Sub

    Private Sub txtAyuda_KeyPress(ByVal sender As Object, _
                   ByVal e As System.Windows.Forms.KeyPressEventArgs)

        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            lstAyuda.DataSource = DAOProveedor.buscarProveedoresActivoPorNombre(txtAyuda.Text)
        ElseIf e.KeyChar = Convert.ToChar(Keys.Escape) Then
            e.Handled = True
            txtAyuda.Text = ""
        End If
    End Sub

    Private Sub mostrarProveedor(ByVal proveedor As Proveedor)
        txtDesdeProveedor.Text = proveedor.id
        txtHastaProveedor.Text = proveedor.id
        txtDesdeProveedor.Focus()
    End Sub

    Private Sub lstAyuda_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstAyuda.Click
        mostrarProveedor(lstAyuda.SelectedValue)
    End Sub

    Enum Reporte
        Imprimir
        Pantalla
    End Enum

    Private Sub _Imprimir(ByVal TipoImpresion As Reporte)
        Dim txtUno As String

        Dim txtEmpresa As String
        Dim txtFormula As String
        Dim x As Char = Chr(34)
        Dim txtfechaOrd1, txtfechaOrd2, txtfechaOrd3, txtfechaOrd4 As String
        Dim txtcompara As String
        Dim txtimpo1, txtimpo2, txtimpo3, txtimpo4, txtimpo5 As Double



        SQLConnector.retrieveDataTable("limpiar_impCtaCtePrvNet")

        txtEmpresa = "Surfactan S.A."

        txtfechaOrd1 = ordenaFecha(txtFecha1.Text)
        txtfechaOrd2 = ordenaFecha(txtFecha2.Text)
        txtfechaOrd3 = ordenaFecha(txtFecha3.Text)
        txtfechaOrd4 = ordenaFecha(txtFecha4.Text)


        Dim tabla As DataTable
        tabla = SQLConnector.retrieveDataTable("buscar_cuenta_corriente_proveedores_desdehasta", txtDesdeProveedor.Text, txtHastaProveedor.Text, "P")

        For Each row As DataRow In tabla.Rows

            Dim CCPrv As New CtaCteProveedoresDeudaDesdeHasta(row.Item(0).ToString, row.Item(1).ToString, row.Item(2).ToString, row.Item(3).ToString, row.Item(4), row.Item(5), row.Item(6).ToString, row.Item(7).ToString, row.Item(8).ToString, row.Item(9).ToString, row.Item(10), row.Item(11).ToString, row.Item(12).ToString)

            txtcompara = ordenaFecha(CCPrv.vencimiento)
            txtimpo1 = 0
            txtimpo2 = 0
            txtimpo3 = 0
            txtimpo4 = 0
            txtimpo5 = 0

            If txtcompara <= txtfechaOrd1 Then
                txtimpo1 = txtimpo1 + CCPrv.saldo
            Else
                If txtcompara <= txtfechaOrd2 Then
                    txtimpo2 = txtimpo2 + CCPrv.saldo
                Else
                    If txtcompara <= txtfechaOrd3 Then
                        txtimpo3 = txtimpo3 + CCPrv.saldo
                    Else
                        If txtcompara <= txtfechaOrd4 Then
                            txtimpo4 = txtimpo4 + CCPrv.saldo
                        Else
                            txtimpo5 = txtimpo5 + CCPrv.saldo
                        End If
                    End If
                End If
            End If

            SQLConnector.executeProcedure("alta_impCtaCtePrvNet", CCPrv.Clave, CCPrv.Proveedor, CCPrv.Tipo, CCPrv.letra, CCPrv.punto, CCPrv.numero, CCPrv.total, CCPrv.saldo, CCPrv.fecha, CCPrv.vencimiento, CCPrv.VencimientoII, CCPrv.Impre, CCPrv.nroInterno, txtEmpresa, 0, 0, txtFecha1.Text, txtFecha2.Text, txtFecha3.Text, txtFecha4.Text, txtimpo1, txtimpo2, txtimpo3, txtimpo4, txtimpo5, "", 0, 0, 0, 0, 0, 0, 0, 0)
        Next










        txtUno = "{ImpCtaCtePrvNet.Proveedor} in " + x + "0" + x + " to " + x + "99999999999" + x
        txtFormula = txtUno

        Dim viewer As New ReportViewer("Proyeccion de Cobros de Corriente de Proveedres", Globals.reportPathWithName("wProyccprvnet.rpt"), txtFormula)


        Select Case TipoImpresion
            Case Reporte.Imprimir
                viewer.imprimirReporte()
            Case Reporte.Pantalla
                viewer.Show()
            Case Else

        End Select

    End Sub

    Private Sub txtDesdeProveedor_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtDesdeProveedor.MouseDoubleClick
        btnConsulta.PerformClick()
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

    Private Sub SoloNumero(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDesdeProveedor.KeyPress, txtHastaProveedor.KeyPress
        If Not Char.IsNumber(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtDesdeProveedor_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDesdeProveedor.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txtDesdeProveedor.Text) = "" Then
                btnConsulta.PerformClick()
                Exit Sub
            End If
            txtHastaProveedor.Text = txtDesdeProveedor.Text
            txtHastaProveedor.Focus()
        ElseIf e.KeyData = Keys.Escape Then
            txtDesdeProveedor.Text = ""
        End If

    End Sub

    Private Sub txtHastaProveedor_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtHastaProveedor.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txtHastaProveedor.Text) = "" Then
                btnConsulta.PerformClick()
                Exit Sub
            End If
            txtFecha1.Focus()
        ElseIf e.KeyData = Keys.Escape Then
            txtHastaProveedor.Text = ""
        End If

    End Sub

    Private Sub btnPantalla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPantalla.Click
        _Imprimir(Reporte.Pantalla)
    End Sub

    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
        _Imprimir(Reporte.Imprimir)
    End Sub

    Private Sub ListadoProyeccionCobros_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        txtDesdeProveedor.Focus()
    End Sub
End Class