Imports ClasesCompartidas
Imports System.IO

Public Class ProcesoRetencionesPagos

    Dim nombreArchivo As String

    Dim ordDesde As String
    Dim ordHasta As String


    Dim WCuit As String
    Dim WFecha As String
    Dim WSucursal As String
    Dim WOrden As String
    Dim WImporte As String
    Dim WRetencion As String
    Dim WCertificado As String
    Dim WTipoProceso As String
    Dim WBase As String

    Dim WCampo1 As String
    Dim WCampo2 As String
    Dim WCampo3 As String
    Dim WCampo4 As String
    Dim WCampo5 As String
    Dim WCampo6 As String
    Dim WCampo7 As String
    Dim WCampo8 As String
    Dim WCampo9 As String
    Dim WCampo10 As String
    Dim WCampo11 As String
    Dim WCampo12 As String
    Dim WCampo13 As String
    Dim WCampo14 As String
    Dim WCampo15 As String
    Dim WCampo16 As String
    Dim WCampo17 As String
    Dim WCampo18 As String
    Dim WCampo19 As String
    Dim WCampo20 As String


    Private Sub ProcesoRetencionesPagos_Load_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Label2.Text = Globals.NombreEmpresa()
        txtDesde.Text = "  /  /    "
        txtHasta.Text = "  /  /    "

        TipoProceso.Items.Clear()
        TipoProceso.Items.Add("Ingresos Brutos")
        TipoProceso.Items.Add("Ganancias")

        TipoProceso.SelectedIndex = 0

    End Sub



    Private Sub txtdesde_KeyPress(ByVal sender As Object, _
                ByVal e As System.Windows.Forms.KeyPressEventArgs) _
                Handles txtDesde.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            If ValidaFecha(txtDesde.Text) = "S" Then
                txtHasta.Focus()
            End If
        ElseIf e.KeyChar = Convert.ToChar(Keys.Escape) Then
            e.Handled = True
            txtDesde.Text = "  /  /    "
            Me.txtDesde.SelectionStart = 0
        End If
    End Sub

    Private Sub txthasta_KeyPress(ByVal sender As Object, _
                ByVal e As System.Windows.Forms.KeyPressEventArgs) _
                Handles txtHasta.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            If ValidaFecha(txtHasta.Text) = "S" Then
                txtNombre.Focus()
            End If
        ElseIf e.KeyChar = Convert.ToChar(Keys.Escape) Then
            e.Handled = True
            txtHasta.Text = "  /  /    "
            Me.txtHasta.SelectionStart = 0
        End If
    End Sub

    Private Sub txtnombre_KeyPress(ByVal sender As Object, _
                   ByVal e As System.Windows.Forms.KeyPressEventArgs) _
                   Handles txtNombre.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            txtDesde.Focus()
        ElseIf e.KeyChar = Convert.ToChar(Keys.Escape) Then
            e.Handled = True
            txtNombre.Text = ""
        End If
    End Sub

    Private Sub btnCancela_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancela.Click
        Me.Hide()
        MenuPrincipal.Show()
    End Sub


    Private Sub btnAceptaRetePago_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptaRetePago.Click
        If FolderBrowserDialog1.ShowDialog() = DialogResult.OK Then
            nombreArchivo = FolderBrowserDialog1.SelectedPath
        End If

        If TipoProceso.SelectedIndex = 0 Then
            REM XNombre = WDir + "\AR-30610524598-" + Nombre.text + "-6-LOTE1.txt"
            If Trim(nombreArchivo) <> "" Then

                nombreArchivo = nombreArchivo + "\AR-30549165083-" + txtNombre.Text + "-6-LOTE1.txt"

                If Proceso._EsPellital() Then
                    nombreArchivo = nombreArchivo + "\AR-30610524598-" + txtNombre.Text + "-6-LOTE1.txt"
                End If

            End If
        Else
            nombreArchivo = nombreArchivo + "\" + txtNombre.Text + ".txt"
        End If

        File.Create(nombreArchivo).Dispose()

        Dim escritor As New System.IO.StreamWriter(nombreArchivo)

        ordDesde = ordenaFecha(txtDesde.Text)
        ordHasta = ordenaFecha(txtHasta.Text)

        Select Case TipoProceso.SelectedIndex
            Case 0
                Dim tabla As DataTable
                tabla = SQLConnector.retrieveDataTable("procesoReteIb", ordDesde, ordHasta)

                For Each row As DataRow In tabla.Rows

                    Dim CamposReteIb As New ProcesoReteIb(row.Item(0).ToString, row.Item(1), row.Item(2).ToString, row.Item(3).ToString, row.Item(4).ToString, row.Item(5).ToString, row.Item(6).ToString)

                    'WCuit = sacaguiones(CamposReteIb.cuit)
                    WCuit = Trim(CamposReteIb.cuit)
                    WFecha = CamposReteIb.fecha
                    WSucursal = "0001"
                    WOrden = ceros(CamposReteIb.orden, 8)
                    WImporte = ceros(formatonumerico(redondeo(CamposReteIb.retotra), "########0.#0", "."), 11)

                    escritor.Write(WCuit + WFecha + WSucursal + WOrden + WImporte + "A" + vbCrLf)

                Next

                escritor.Close()

                MsgBox("Proceso Finalizado de Ingresos Brutos", MsgBoxStyle.Information)

            Case 1
                Dim tabla As DataTable
                tabla = SQLConnector.retrieveDataTable("procesoReteGanan", ordDesde, ordHasta)

                For Each row As DataRow In tabla.Rows

                    Dim CamposReteGanan As New ProcesoReteGanancias(row.Item(0).ToString, row.Item(1), row.Item(2).ToString, row.Item(3).ToString, row.Item(4).ToString, row.Item(5).ToString, row.Item(6).ToString, row.Item(7).ToString, row.Item(8).ToString, row.Item(9).ToString)

                    WFecha = CamposReteGanan.fecha
                    WCertificado = ceros(CamposReteGanan.certificadogan, 16)
                    WImporte = ceros(formatonumerico(redondeo(CamposReteGanan.Importe), "########0.#0", "."), 16)
                    Select Case CamposReteGanan.tipo
                        Case 1
                            WTipoProceso = "116"
                        Case 2
                            WTipoProceso = "27 "
                        Case 4
                            WTipoProceso = "124"
                        Case 5
                            WTipoProceso = "094"
                        Case 6
                            WTipoProceso = "95 "
                        Case Else
                            WTipoProceso = "78 "
                    End Select
                    WBase = ceros(formatonumerico(redondeo(CamposReteGanan.Importe), "########0.#0", "."), 14)
                    WRetencion = ceros(formatonumerico(redondeo(CamposReteGanan.retencion), "########0.#0", "."), 14)
                    WCuit = agregaespacios((CamposReteGanan.cuit), 20)
                    WSucursal = "0001"
                    WOrden = ceros(CamposReteGanan.orden, 8)

                    WCampo1 = "06"
                    WCampo2 = WFecha
                    WCampo3 = WCertificado
                    WCampo4 = WImporte
                    WCampo5 = "217"
                    WCampo7 = "1"
                    WCampo8 = WBase
                    WCampo9 = WFecha
                    WCampo10 = "01 "
                    WCampo11 = WRetencion
                    WCampo12 = "000000"
                    WCampo13 = Space$(10)
                    WCampo14 = "80"
                    WCampo15 = WCuit
                    WCampo16 = WCertificado
                    WCampo17 = Space$(30)
                    WCampo18 = "0"
                    WCampo19 = Space$(11)
                    WCampo20 = Space$(11)

                    escritor.Write(WCampo1 + WCampo2 + WCampo3 + WCampo4 + WCampo5 + WCampo6 + WCampo7 + WCampo8 + WCampo9 + WCampo10 + WCampo11 + WCampo12 + WCampo1 + WCampo13 + WCampo14 + WCampo15 + WCampo16 + WCampo17 + WCampo18 + WCampo19 + WCampo20 + vbCrLf)

                Next

                escritor.Close()

                MsgBox("Proceso Finalizado de Ganancias", MsgBoxStyle.Information)

            Case Else

        End Select

    End Sub

End Class