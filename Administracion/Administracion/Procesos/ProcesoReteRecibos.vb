Imports System.Data.SqlClient
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
                    WCampo5 = WComproGanan

                    escritor.Write(WCampo1 + WCampo2 + WCampo3 + WCampo4 + WCampo6 + WCampo5 + vbCrLf)

                Next

                escritor.Close()

                MsgBox("Proceso Finalizado de Retenciones de Ganancias", MsgBoxStyle.Information)

            Case Else
                Dim tabla As DataTable
                Dim Vector(10000, 20) As String
                Dim ZRetIb(100, 3) As Double
                Dim WIndice = 0

                ZRetIb(1, 2) = 901
                ZRetIb(2, 2) = 902
                ZRetIb(3, 2) = 904
                ZRetIb(4, 2) = 919
                ZRetIb(5, 2) = 921
                ZRetIb(6, 2) = 923
                ZRetIb(7, 2) = 924

                tabla = _TraerRetencionesIBRecibos(ordDesde, ordHasta) 'SQLConnector.retrieveDataTable("procesoReteIbrecibos", ordDesde, ordHasta)

                For Each row As DataRow In tabla.Rows

                    With row

                        Vector(WIndice, 0) = .Item("Cuit")
                        Vector(WIndice, 2) = .Item("Fecha")
                        Vector(WIndice, 3) = IIf(IsDBNull(.Item("ComproIB")), "", .Item("ComproIB"))
                        Vector(WIndice, 4) = Str$(.Item("RetOtra"))
                        Vector(WIndice, 5) = Str$(.Item("Recibo"))

                        ZRetIb(1, 1) = IIf(IsDBNull(.Item("RetIb1")), 0, .Item("RetIb1"))
                        ZRetIb(2, 1) = IIf(IsDBNull(.Item("RetIb2")), 0, .Item("RetIb2"))
                        ZRetIb(3, 1) = IIf(IsDBNull(.Item("RetIb3")), 0, .Item("RetIb3"))
                        ZRetIb(4, 1) = IIf(IsDBNull(.Item("RetIb4")), 0, .Item("RetIb4"))
                        ZRetIb(5, 1) = IIf(IsDBNull(.Item("RetIb5")), 0, .Item("RetIb5"))
                        ZRetIb(6, 1) = IIf(IsDBNull(.Item("RetIb6")), 0, .Item("RetIb6"))
                        ZRetIb(7, 1) = IIf(IsDBNull(.Item("RetIb7")), 0, .Item("RetIb7"))

                        Vector(WIndice, 6) = Str$(ZRetIb(1, 1))
                        Vector(WIndice, 7) = Str$(ZRetIb(2, 1))
                        Vector(WIndice, 8) = Str$(ZRetIb(3, 1))
                        Vector(WIndice, 9) = Str$(ZRetIb(4, 1))
                        Vector(WIndice, 10) = Str$(ZRetIb(5, 1))
                        Vector(WIndice, 11) = Str$(ZRetIb(6, 1))
                        Vector(WIndice, 12) = Str$(ZRetIb(7, 1))

                        ZRetIb(1, 3) = IIf(IsDBNull(.Item("NroRetIb1")), 0, .Item("NroRetIb1"))
                        ZRetIb(2, 3) = IIf(IsDBNull(.Item("NroRetIb2")), 0, .Item("NroRetIb2"))
                        ZRetIb(3, 3) = IIf(IsDBNull(.Item("NroRetIb3")), 0, .Item("NroRetIb3"))
                        ZRetIb(4, 3) = IIf(IsDBNull(.Item("NroRetIb4")), 0, .Item("NroRetIb4"))
                        ZRetIb(5, 3) = IIf(IsDBNull(.Item("NroRetIb5")), 0, .Item("NroRetIb5"))
                        ZRetIb(6, 3) = IIf(IsDBNull(.Item("NroRetIb6")), 0, .Item("NroRetIb6"))
                        ZRetIb(7, 3) = IIf(IsDBNull(.Item("NroRetIb7")), 0, .Item("NroRetIb7"))

                        Vector(WIndice, 13) = Str$(ZRetIb(1, 3))
                        Vector(WIndice, 14) = Str$(ZRetIb(2, 3))
                        Vector(WIndice, 15) = Str$(ZRetIb(3, 3))
                        Vector(WIndice, 16) = Str$(ZRetIb(4, 3))
                        Vector(WIndice, 17) = Str$(ZRetIb(5, 3))
                        Vector(WIndice, 18) = Str$(ZRetIb(6, 3))
                        Vector(WIndice, 19) = Str$(ZRetIb(7, 3))

                    End With

                    WIndice += 1

                Next

                Dim WRetOtra = ""

                For i = 0 To WIndice

                    WCuit = Vector(i, 0)
                    WCuit = _left(WCuit, 13)
                    WFecha = Vector(i, 2)
                    WComproIb = Vector(i, 3)
                    WImporte = Vector(i, 4)
                    WRecibo = Vector(i, 5)
                    WRetOtra = Vector(i, 4)

                    WImporte = Proceso.formatonumerico(WImporte)
                    WImporte = WImporte.Replace(".", ",")

                    ZRetIb(1, 1) = Val(Vector(i, 6))
                    ZRetIb(2, 1) = Val(Vector(i, 7))
                    ZRetIb(3, 1) = Val(Vector(i, 8))
                    ZRetIb(4, 1) = Val(Vector(i, 9))
                    ZRetIb(5, 1) = Val(Vector(i, 10))
                    ZRetIb(6, 1) = Val(Vector(i, 11))
                    ZRetIb(7, 1) = Val(Vector(i, 12))

                    ZRetIb(1, 3) = Val(Vector(i, 13))
                    ZRetIb(2, 3) = Val(Vector(i, 14))
                    ZRetIb(3, 3) = Val(Vector(i, 15))
                    ZRetIb(4, 3) = Val(Vector(i, 16))
                    ZRetIb(5, 3) = Val(Vector(i, 17))
                    ZRetIb(6, 3) = Val(Vector(i, 18))
                    ZRetIb(7, 3) = Val(Vector(i, 19))

                    For x = 1 To 7

                        If ZRetIb(x, 1) <> 0 Then
                            WRetOtra = "0"
                        End If

                    Next

                    If Val(WRetOtra) <> 0 Then

                        WCampo1 = "902"
                        WCampo2 = WCuit
                        WCampo3 = Trim(WFecha)
                        WCampo4 = "0001"
                        WCampo5 = ceros(WComproIb, 16)
                        WCampo6 = "R"
                        WCampo7 = "A"
                        WCampo8 = ceros(WRecibo, 20)
                        WCampo9 = ceros(WImporte, 11)

                        escritor.Write(WCampo1 + WCampo2 + WCampo3 + WCampo4 + WCampo5 + WCampo6 + WCampo7 + WCampo8 + WCampo9 + vbCrLf)

                    Else

                        For j = 1 To 7

                            If ZRetIb(j, 1) <> 0 Then

                                WImporte = Str$(ZRetIb(j, 1))
                                WComproIb = Str$(ZRetIb(j, 3))

                                WImporte = Proceso.formatonumerico(WImporte)
                                WImporte = WImporte.Replace(".", ",")

                                WCampo1 = Str$(ZRetIb(j, 2))
                                WCampo1 = ceros(WCampo1, 3)
                                WCampo2 = WCuit
                                WCampo3 = Trim(WFecha)
                                WCampo4 = "0001"
                                WCampo5 = ceros(WComproIb, 16)
                                WCampo6 = "R"
                                WCampo7 = "A"
                                WCampo8 = ceros(WRecibo, 20)
                                WCampo9 = ceros(WImporte, 11)

                                escritor.Write(WCampo1 + WCampo2 + WCampo3 + WCampo4 + WCampo5 + WCampo6 + WCampo7 + WCampo8 + WCampo9 + vbCrLf)

                            End If

                        Next

                    End If

                Next

                escritor.Close()

                MsgBox("Proceso Finalizado de Retenciones de Ingresos Brutos", MsgBoxStyle.Information)


        End Select

    End Sub

    Private Function _TraerRetencionesIBRecibos(ByVal WDesde As String, ByVal WHasta As String) As DataTable

        Dim tabla As New DataTable

        Dim cn = New SqlConnection()
        Dim cm = New SqlCommand("SELECT r.Fecha, r.ComproIb, r.RetOtra, r.Recibo, cli.Cuit, " & _
                                              " RetIb1,RetIb2,RetIb3,RetIb4,RetIb5,RetIb6,RetIb7, NroRetIb1, NroRetIb2, " & _
                                              " NroRetIb3, NroRetIb4, NroRetIb5, NroRetIb6, NroRetIb7 FROM Recibos r JOIN Cliente cli ON cli.Cliente = r.Cliente WHERE FechaOrd BETWEEN " & WDesde & " AND " & WHasta & " AND RetOtra <> 0 AND Renglon = 1")
        Dim dr As SqlDataReader

        Try

            cn.ConnectionString = Proceso._ConectarA
            cn.Open()
            cm.Connection = cn

            dr = cm.ExecuteReader()

            If dr.HasRows Then

                tabla.Load(dr)

            End If

        Catch ex As Exception
            Throw New Exception("Hubo un problema al querer consultar la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

        Return tabla
    End Function

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