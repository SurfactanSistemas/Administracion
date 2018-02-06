﻿Imports System.Data.SqlClient
Imports ClasesCompartidas
Imports System.IO

Public Class ProcesoReteRecibos

    Dim nombreArchivo As String

    Dim ordDesde As String
    Dim ordHasta As String


    Dim WCuit As String
    Dim WFecha As String
    Dim WImporte As String
    Dim WComproIva As String
    Dim WComproGanan As String
    Dim WComproIb As String
    Dim WRecibo As String

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

    Private Sub ProcesoReteRecibos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Label2.Text = Globals.NombreEmpresa()
        txtDesde.Text = "  /  /    "
        txtHasta.Text = "  /  /    "

        TipoProceso.Items.Clear()
        TipoProceso.Items.Add("Iva")
        TipoProceso.Items.Add("Ganancias")
        TipoProceso.Items.Add("Ingresos Brutos")

        TipoProceso.SelectedIndex = 0

    End Sub


    Private Sub txtdesde_KeyPress(ByVal sender As Object, _
                ByVal e As System.Windows.Forms.KeyPressEventArgs)

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
                ByVal e As System.Windows.Forms.KeyPressEventArgs)

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
                   ByVal e As System.Windows.Forms.KeyPressEventArgs)

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

    Private Sub btnAcepta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAcepta.Click

        If Trim(txtNombre.Text) = "" Then Exit Sub

        txtNombre.Text = Trim(txtNombre.Text)

        If FolderBrowserDialog1.ShowDialog() = DialogResult.OK Then
            nombreArchivo = FolderBrowserDialog1.SelectedPath
        End If

        nombreArchivo = nombreArchivo + "\" + txtNombre.Text + ".txt"

        File.Create(nombreArchivo).Dispose()

        Dim escritor As New System.IO.StreamWriter(nombreArchivo)

        ordDesde = ordenaFecha(txtDesde.Text)
        ordHasta = ordenaFecha(txtHasta.Text)

        Select Case TipoProceso.SelectedIndex
            Case 0
                Dim tabla As DataTable
                tabla = SQLConnector.retrieveDataTable("procesoReteIva", ordDesde, ordHasta)

                For Each row As DataRow In tabla.Rows

                    Dim CamposReteIva As New ProcesoReteIvaRecibos(row.Item(0).ToString, row.Item(1), row.Item(2).ToString, row.Item(3).ToString, row.Item(4).ToString, row.Item(5).ToString, row.Item(6).ToString)

                    WCuit = leederecha(CamposReteIva.cuit, 13)
                    WFecha = CamposReteIva.fecha
                    WComproIva = ceros(CamposReteIva.comproiva, 16)
                    WImporte = ceros(CamposReteIva.retiva, 16)
                    WImporte = WImporte.Replace(",", ".")

                    WCampo1 = "248"
                    WCampo2 = WCuit
                    WCampo3 = WFecha
                    WCampo4 = WComproIva
                    WCampo5 = WImporte

                    escritor.Write(WCampo1 + WCampo2 + WCampo3 + WCampo4 + WCampo5 + vbCrLf)

                Next

                escritor.Close()

                MsgBox("Proceso Finalizado de Retenciones de Iva", MsgBoxStyle.Information)

            Case 1
                Dim tabla As DataTable
                tabla = SQLConnector.retrieveDataTable("procesoReteGananII_recibos", ordDesde, ordHasta)

                For Each row As DataRow In tabla.Rows

                    Dim CamposReteGanancias As New ProcesoReteGenanciasRecibo(row.Item(0).ToString, row.Item(1), row.Item(2).ToString, row.Item(3).ToString, row.Item(4).ToString, row.Item(5).ToString, row.Item(6).ToString)

                    WCuit = sacaguiones(CamposReteGanancias.cuit)
                    WFecha = CamposReteGanancias.fecha
                    WCuit = _left(WCuit, 13)
                    'WFecha = "01/01/2016"
                    WComproGanan = ceros(CamposReteGanancias.comproganan, 30)
                    WImporte = ceros(CamposReteGanancias.retganancias, 15)

                    WCampo1 = "1"
                    WCampo2 = WCuit
                    WCampo3 = WFecha
                    WCampo4 = "078"
                    WCampo6 = WImporte.Replace(",", ".")
                    WCampo5 = WComproganan

                    escritor.Write(WCampo1 + WCampo2 + WCampo3 + WCampo4 + WCampo6 + WCampo5 + vbCrLf)

                Next

                escritor.Close()

                MsgBox("Proceso Finalizado de Retenciones de Ganancias", MsgBoxStyle.Information)

            Case Else
                Dim tabla As DataTable
                tabla = SQLConnector.retrieveDataTable("procesoReteIbrecibos", ordDesde, ordHasta)

                For Each row As DataRow In tabla.Rows

                    Dim CamposReteIb As New ProcesoReteIbRecibos(row.Item(0).ToString, row.Item(1), row.Item(2).ToString, row.Item(3).ToString, row.Item(4).ToString, row.Item(5).ToString, row.Item(6).ToString)

                    WCuit = leederecha(CamposReteIb.cuit, 13)
                    WFecha = CamposReteIb.fecha
                    WFecha = "01/01/2016"
                    WComproIb = ceros(CamposReteIb.comproib, 16)
                    WImporte = ceros(formatonumerico(redondeo(CamposReteIb.retotra), "########0.#0", "."), 11)
                    WRecibo = "121212121"

                    WCampo1 = "902"
                    WCampo2 = WCuit
                    WCampo3 = WFecha
                    WCampo4 = "0001"
                    WCampo5 = WComproIb
                    WCampo6 = "R"
                    WCampo7 = "A"
                    WCampo8 = WRecibo
                    WCampo9 = WImporte

                    escritor.Write(WCampo1 + WCampo2 + WCampo3 + WCampo4 + WCampo5 + WCampo6 + WCampo7 + WCampo8 + WCampo9 + vbCrLf)

                Next

                escritor.Close()

                MsgBox("Proceso Finalizado de Retenciones de Ingresos Brutos", MsgBoxStyle.Information)


        End Select

    End Sub

    Private Function _left(ByVal s As String, ByVal i As Integer) As String
        Return Microsoft.VisualBasic.Left(s, i)
    End Function

    Private Sub txtDesde_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDesde.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txtDesde.Text) = "" Then : Exit Sub : End If

            If Proceso._ValidarFecha(txtDesde.Text) Then
                txtHasta.Focus()
            End If

        ElseIf e.KeyData = Keys.Escape Then
            txtDesde.Text = ""
        End If

    End Sub

    Private Sub txtHasta_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtHasta.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txtHasta.Text) = "" Then : Exit Sub : End If

            If Proceso._ValidarFecha(txtHasta.Text) Then

                With TipoProceso
                    .DroppedDown = True
                    .Focus()
                End With

            End If

        ElseIf e.KeyData = Keys.Escape Then
            txtHasta.Text = ""
        End If

    End Sub

    Private Sub TipoProceso_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TipoProceso.KeyDown

        If e.KeyData = Keys.Enter Then

            txtNombre.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            TipoProceso.SelectedIndex = 0
        End If

    End Sub

    Private Sub TipoProceso_DropDownClosed(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TipoProceso.DropDownClosed
        txtNombre.Focus()
    End Sub

    Private Sub ProcesoReteRecibos_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        txtDesde.Focus()
    End Sub
End Class