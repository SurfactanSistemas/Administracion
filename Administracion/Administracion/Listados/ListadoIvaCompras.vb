Imports ClasesCompartidas
Imports System.IO

Public Class ListadoIvaCompras


    Private Sub ListadoIvaCompras_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Label2.Text = Globals.NombreEmpresa()
        txtDesdeFecha.Text = "  /  /    "
        txthastafecha.Text = "  /  /    "

        TipoListado.Items.Clear()

        TipoListado.Items.Clear()
        TipoListado.Items.Add("C/Apertura")
        TipoListado.Items.Add("S/Apertura")

        TipoListado.SelectedIndex = 0

    End Sub

    Private Sub txtdesdefecha_KeyPress(ByVal sender As Object, _
                ByVal e As System.Windows.Forms.KeyPressEventArgs) _
                Handles txtDesdeFecha.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            If ValidaFecha(txtDesdeFecha.Text) = "S" Then
                txthastafecha.Focus()
            End If
        ElseIf e.KeyChar = Convert.ToChar(Keys.Escape) Then
            e.Handled = True
            txtDesdeFecha.Text = "  /  /    "
            Me.txtDesdeFecha.SelectionStart = 0
        End If
    End Sub

    Private Sub txthastafecha_KeyPress(ByVal sender As Object, _
                ByVal e As System.Windows.Forms.KeyPressEventArgs) _
                Handles txthastafecha.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            If ValidaFecha(txthastafecha.Text) = "S" Then
                txtDesdeFecha.Focus()
            End If
        ElseIf e.KeyChar = Convert.ToChar(Keys.Escape) Then
            e.Handled = True
            txthastafecha.Text = "  /  /    "
            Me.txthastafecha.SelectionStart = 0
        End If
    End Sub

    Private Sub btnCancela_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancela.Click
        Me.Close()
        MenuPrincipal.Show()
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
        Dim txtDesdefechaOrd, txtHastafechaOrd
        Dim txtGraba As String
        Dim varNeto As Double

        Dim txtTitulo, txtTituloII, txtImpre, txtOrdFecha As String


        SQLConnector.retrieveDataTable("limpiar_ListaIvaCompras")

        txtEmpresa = "Surfactan S.A."

        txtDesdefechaOrd = ordenaFecha(txtDesdeFecha.Text)
        txtHastafechaOrd = ordenaFecha(txthastafecha.Text)

        txtTitulo = "Surfactan S.A."
        txtTituloII = "Desde el " + txtDesdeFecha.Text + " hasta el " + txthastafecha.Text

        If Proceso._EsPellital() Then
            txtEmpresa = "Pellital S.A."
            txtTitulo = "Pellital S.A."
        End If

        Dim tabla As DataTable
        tabla = SQLConnector.retrieveDataTable("Lee_Ivacomp", txtDesdefechaOrd, txtHastafechaOrd)

        For Each row As DataRow In tabla.Rows

            Dim CampoIvaComp As New LeeIvaComp(row.Item(0), row.Item(1), row.Item(2),
                                            row.Item(3), row.Item(4), row.Item(5),
                                            row.Item(6), row.Item(7), row.Item(8),
                                            row.Item(9), row.Item(10), row.Item(11), row.Item(12),
                                            row.Item(13), row.Item(14), row.Item(15), row.Item(16), row.Item(17))


            txtGraba = "S"

            Dim tablaII As DataTable
            tablaII = SQLConnector.retrieveDataTable("Lee_IvacompAdicional", CampoIvaComp.NroInterno)

            For Each rowII As DataRow In tablaII.Rows

                Dim CampoIvaCompAdicional As New LeeIvaCompAdicional(rowII.Item(0), rowII.Item(1), rowII.Item(2),
                                                rowII.Item(3), rowII.Item(4), rowII.Item(5),
                                                rowII.Item(6), rowII.Item(7), rowII.Item(8),
                                                rowII.Item(9), rowII.Item(10), rowII.Item(11), rowII.Item(12),
                                                rowII.Item(13), rowII.Item(14))

                txtGraba = "N"

                txtOrdFecha = ordenaFecha(CampoIvaComp.fecha)

                SQLConnector.executeProcedure("alta_ListaIvaCompras", CampoIvaComp.NroInterno, CampoIvaComp.proveedor, CampoIvaCompAdicional.tipo,
                                               CampoIvaCompAdicional.letra, ceros(CampoIvaCompAdicional.punto, 4), ceros(CampoIvaCompAdicional.numero, 8),
                                               CampoIvaCompAdicional.fecha, CampoIvaComp.periodo,
                                               CampoIvaCompAdicional.neto, CampoIvaCompAdicional.iva21, CampoIvaCompAdicional.perceiva,
                                               CampoIvaCompAdicional.iva27, CampoIvaCompAdicional.iva105,
                                               CampoIvaCompAdicional.perceib, CampoIvaCompAdicional.exento, CampoIvaCompAdicional.tipo,
                                               txtOrdFecha, txtTitulo, txtTituloII, CampoIvaCompAdicional.razon, CampoIvaCompAdicional.cuit)

            Next


            If txtGraba = "S" Then

                txtOrdFecha = ordenaFecha(CampoIvaComp.fecha)
                varNeto = CampoIvaComp.neto
                If CampoIvaComp.soloiva = 1 Then
                    varNeto = 0
                End If

                Select Case Val(CampoIvaComp.tipo)
                    Case 1
                        txtImpre = "FC"
                    Case 2
                        txtImpre = "N/D"
                    Case Else
                        txtImpre = "N/C"
                End Select



                SQLConnector.executeProcedure("alta_ListaIvaCompras", CampoIvaComp.NroInterno, CampoIvaComp.proveedor, CampoIvaComp.tipo,
                                               CampoIvaComp.letra, CampoIvaComp.punto, CampoIvaComp.numero, CampoIvaComp.fecha, CampoIvaComp.periodo,
                                               varNeto, CampoIvaComp.iva21, CampoIvaComp.iva5, CampoIvaComp.iva27, CampoIvaComp.iva105,
                                               CampoIvaComp.ib, CampoIvaComp.exento, txtImpre, txtOrdFecha, txtTitulo, txtTituloII, CampoIvaComp.nombre, CampoIvaComp.cuit)

            End If

        Next


        'txtUno = "{ListaIvaCompras.OrdFecha} in " + x + txtDesdefechaOrd + x + " to " + x + txtHastafechaOrd + x
        txtFormula = "" 'txtUno

        Dim viewer As New ReportViewer("Listado de Iva Compras", Globals.reportPathWithName("wIvaCompNet.rpt"), txtFormula)

        With viewer

            Select Case TipoImpresion
                Case Reporte.Pantalla
                    .ShowDialog()
                Case Reporte.Imprimir
                    .imprimirReporte()
            End Select

        End With
    End Sub

    Private Sub btnPantalla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPantalla.Click
        _Imprimir(Reporte.Pantalla)
    End Sub

    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
        _Imprimir(Reporte.Imprimir)
    End Sub
End Class