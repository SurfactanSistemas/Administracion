Imports ClasesCompartidas
Imports System.IO
Imports Microsoft.Office.Interop.Outlook

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


    Private Sub btnCancela_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancela.Click
        Me.Hide()
        MenuPrincipal.Show()
    End Sub


    Private Sub btnAceptaRetePago_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptaRetePago.Click

        If Trim(txtNombre.Text) = "" Then Exit Sub

        Select Case TipoProceso.SelectedIndex
            Case 0
                txtNombre.Text = _Left(txtNombre.Text, 50)
            Case 1
                txtNombre.Text = _Left(txtNombre.Text, 8)
        End Select

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
                    WImporte = ceros(Str$(CamposReteGanan.Importe), 16)
                    WImporte = WImporte.Replace(",", ".")

                    Select Case CamposReteGanan.tipo
                        Case 1
                            WCampo6 = "116"
                        Case 2
                            WCampo6 = "27 "
                        Case 4
                            WCampo6 = "124"
                        Case 5
                            WCampo6 = "094"
                        Case 6
                            WCampo6 = "95 "
                        Case Else
                            WCampo6 = "78 "
                    End Select
                    WBase = ceros(Str$(CamposReteGanan.Importe), 14)
                    WBase = WBase.Replace(",", ".")
                    WRetencion = ceros(redondeo(CamposReteGanan.retencion), 14)
                    WRetencion = WRetencion.Replace(",", ".")
                    'WCuit = agregaespacios((CamposReteGanan.cuit), 20)
                    WCuit = CamposReteGanan.cuit

                    WCuit = WCuit.Replace("-", "")

                    WCuit = ceros(WCuit, 11)

                    WSucursal = "0001"
                    'WOrden = ceros(CamposReteGanan.orden, 8)
                    WOrden = ceros(CamposReteGanan.orden, 16)

                    WCampo1 = "06"
                    WCampo2 = WFecha
                    WCampo3 = WCertificado
                    WCampo4 = WImporte
                    WCampo5 = "217"
                    WCampo7 = "1"
                    WCampo8 = ceros(WBase, 14)
                    WCampo9 = WFecha
                    WCampo10 = "01 "
                    WCampo11 = ceros(WRetencion, 14)
                    WCampo12 = "000000"
                    WCampo13 = Space$(10)
                    WCampo14 = "80"
                    WCampo15 = WCuit.PadRight(20)
                    WCampo16 = ceros(WCertificado, 14)
                    WCampo17 = Space$(30)
                    WCampo18 = "0"
                    WCampo19 = Space$(11)
                    WCampo20 = Space$(11)

                    escritor.Write(WCampo1 + WCampo2 + WCampo3 + WCampo4 + WCampo5 + WCampo6 + WCampo7 + WCampo8 + WCampo9 + WCampo10 + WCampo11 + WCampo12 + WCampo13 + WCampo14 + WCampo15 + WCampo16 + WCampo17 + WCampo18 + WCampo19 + WCampo20 + vbCrLf)

                Next

                escritor.Close()

                MsgBox("Proceso Finalizado de Ganancias", MsgBoxStyle.Information)

        End Select

    End Sub

    Private Function _Left(ByVal texto As String, ByVal longitud As Integer) As String
        Return Microsoft.VisualBasic.Left(texto, longitud)
    End Function

    Private Sub txtDesde_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDesde.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txtDesde.Text.Replace("/", "")) = "" Then : Exit Sub : End If

            If Proceso._ValidarFecha(txtDesde.Text) Then
                txtHasta.Focus()
            End If

        ElseIf e.KeyData = Keys.Escape Then
            txtDesde.Clear()
        End If

    End Sub

    Private Sub txtHasta_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtHasta.KeyDown
        If e.KeyData = Keys.Enter Then
            If Trim(txtHasta.Text.Replace("/", "")) = "" Then : Exit Sub : End If

            If Proceso._ValidarFecha(txtHasta.Text) Then
                With TipoProceso
                    .DroppedDown = True
                    .Focus()
                End With
            End If

        ElseIf e.KeyData = Keys.Escape Then
            txtHasta.Clear()
        End If
    End Sub

    Private Sub txtNombre_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNombre.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txtNombre.Text) = "" Then : Exit Sub : End If

            txtDesde.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtNombre.Text = ""
        End If

    End Sub

    Private Sub ProcesoRetencionesPagos_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        txtDesde.Focus()
    End Sub

    Private Sub TipoProceso_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TipoProceso.KeyDown

        If e.KeyData = Keys.Enter Then

            txtNombre.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            TipoProceso.SelectedIndex = 0
        End If

    End Sub

    Private Sub TipoProceso_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TipoProceso.SelectedIndexChanged

        With txtNombre
            Select Case TipoProceso.SelectedIndex
                Case 0
                    .MaxLength = 50
                Case 1
                    .MaxLength = 8
            End Select
        End With

    End Sub

    Private Sub TipoProceso_DropDownClosed(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TipoProceso.DropDownClosed

        txtNombre.Focus()

    End Sub
End Class