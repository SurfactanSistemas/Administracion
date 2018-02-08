Imports System.Data.SqlClient
Imports ClasesCompartidas
Imports System.IO

Public Class ProcesoPercepciones


    Dim nombreArchivo As String

    Dim ordDesde As String
    Dim ordHasta As String


    Dim WCuit As String
    Dim WFecha As String
    Dim WImporte As String
    Dim WTipoFac As String
    Dim WNumero As String
    Dim WNeto As String
    Dim WImporteII As Double
    Dim WNetoII As Double
    Dim WPorceIb As String
    Dim WPorceIbII As Double

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

    Private Sub ProcesoPercepciones_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Label2.Text = Globals.NombreEmpresa()
        txtDesde.Text = "  /  /    "
        txtHasta.Text = "  /  /    "

        LugarProceso.Items.Clear()
        LugarProceso.Items.Add("Buenos Aires")
        LugarProceso.Items.Add("Tucuman")

        LugarProceso.SelectedIndex = 0
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
        Dim Vector(10000, 10) As String
        Dim WIndice = 0
        Dim XCodigo As String = "A0009000"

        If Proceso._EsPellital() Then
            XCodigo = "A0006000"
        End If

        ProgressBar1.Value = 0
        GroupBox1.Visible = True

        If Trim(txtNombre.Text) = "" Then Exit Sub

        If FolderBrowserDialog1.ShowDialog() = DialogResult.OK Then
            nombreArchivo = FolderBrowserDialog1.SelectedPath
        Else
            Exit Sub
        End If

        If LugarProceso.SelectedIndex = 0 Then
            REM XNombre = WDir + "\AR-30610524598-" + Nombre.Text + "-7-LOTE1.txt"
            nombreArchivo = nombreArchivo + "\AR-30549165083-" + txtNombre.Text + "7-LOTE1.txt"

            If Proceso._EsPellital() Then
                nombreArchivo = nombreArchivo + "\AR-30610524598-" + txtNombre.Text + "7-LOTE1.txt"
            End If

        Else
            nombreArchivo = nombreArchivo + "\" + txtNombre.Text + ".txt"
        End If

        File.Create(nombreArchivo).Dispose()

        Dim escritor As New System.IO.StreamWriter(nombreArchivo)
        Dim WStep = 0.0

        ordDesde = ordenaFecha(txtDesde.Text)
        ordHasta = ordenaFecha(txtHasta.Text)

        Try
            _ModificarCtaCteImporteIva0()
        
        Select Case LugarProceso.SelectedIndex
                Case 0 ' Buenos Aires.

                    Dim tabla As DataTable

                    ' Procesa Cobranzas
                    If TipoProceso.SelectedIndex = 0 Then

                        tabla = _TraerRecibos(ordDesde, ordHasta) 'SQLConnector.retrieveDataTable("procesoperceib", ordDesde, ordHasta)

                    Else
                        ' Procesa Ventas.
                        tabla = _TraerCtasCtes(ordDesde, ordHasta)

                    End If

                    ProgressBar1.Step = 1
                    ProgressBar1.Maximum = tabla.Rows.Count * 4 + 1

                    For Each row As DataRow In tabla.Rows

                        With row

                            Vector(WIndice, 0) = IIf(IsDBNull(.Item("Cuit")), "", .Item("Cuit"))
                            Vector(WIndice, 1) = IIf(IsDBNull(.Item("Clave")), "", .Item("Clave"))
                            Vector(WIndice, 2) = IIf(IsDBNull(.Item("Fecha")), "", .Item("Fecha"))
                            Vector(WIndice, 3) = IIf(IsDBNull(.Item("Tipo")), "", .Item("Tipo"))
                            Vector(WIndice, 4) = IIf(IsDBNull(.Item("Numero")), "", .Item("Numero"))
                            Vector(WIndice, 5) = IIf(IsDBNull(.Item("Cliente")), "", .Item("Cliente"))
                            Vector(WIndice, 6) = ""
                            Vector(WIndice, 7) = ""

                        End With

                        WIndice += 1

                        ProgressBar1.Increment(1)
                    Next

                    Dim WClave = "", WTipo = "", WCliente = "", WImpoIb = "", WRecibo = 0, WSale = ""
                    Dim WCtaCte As DataRow = Nothing
                    Dim WReciboFactura As DataTable = Nothing

                    For i = 0 To WIndice

                        WClave = Vector(i, 1)
                        WFecha = Vector(i, 2)
                        WTipo = Vector(i, 3)
                        WNumero = Vector(i, 4)

                        WCtaCte = _TraerCtaCte(WTipo, WNumero)

                        If Not IsNothing(WCtaCte) Then

                            WNeto = IIf(IsDBNull(WCtaCte.Item("Neto")), "0", WCtaCte.Item("Neto"))
                            WImpoIb = IIf(IsDBNull(WCtaCte.Item("ImpoIb")), "0", WCtaCte.Item("ImpoIb"))

                            If Val(WImpoIb) = 0 Then

                                Vector(i, 1) = ""
                                Vector(i, 2) = ""
                                Vector(i, 3) = ""
                                Vector(i, 4) = ""
                                Vector(i, 5) = ""
                                Vector(i, 6) = ""
                                Vector(i, 7) = ""

                            Else

                                Vector(i, 6) = Str$(WNeto)
                                Vector(i, 7) = Str$(WImpoIb)

                            End If

                        Else

                            Vector(i, 1) = ""
                            Vector(i, 2) = ""
                            Vector(i, 3) = ""
                            Vector(i, 4) = ""
                            Vector(i, 5) = ""
                            Vector(i, 6) = ""
                            Vector(i, 7) = ""

                        End If

                        ProgressBar1.Increment(1)

                    Next

                    If TipoProceso.SelectedIndex = 0 Then ' Limpiamos los Recibos en caso de que se procese Cobranzas.
                        For i = 0 To WIndice


                            WClave = Vector(i, 1)

                            If Trim(WClave) <> "" Then

                                WTipo = Vector(i, 3)
                                WNumero = Vector(i, 4)
                                WRecibo = Val(_Left(WClave, 6))
                                WSale = "N"

                                WReciboFactura = _TraerReciboFactura(WTipo, WNumero)

                                If Not IsNothing(WReciboFactura) Then

                                    For Each recibo As DataRow In WReciboFactura.Rows
                                        If Val(recibo.Item("Recibo")) < WRecibo Then
                                            WSale = "S"
                                            Exit For
                                        End If
                                    Next

                                End If

                                If WSale = "S" Then
                                    Vector(i, 1) = ""
                                    Vector(i, 2) = ""
                                    Vector(i, 3) = ""
                                    Vector(i, 4) = ""
                                    Vector(i, 5) = ""
                                    Vector(i, 6) = ""
                                    Vector(i, 7) = ""
                                End If

                            End If

                            ProgressBar1.Increment(1)

                        Next

                    End If
                    
                    For i = 0 To WIndice

                        WClave = Vector(i, 1)

                        If Trim(WClave) <> "" Then

                            WCuit = Vector(i, 0)
                            WFecha = Vector(i, 2)
                            WTipo = Vector(i, 3)
                            WNumero = Vector(i, 4)
                            WCliente = Vector(i, 5)
                            WNeto = Vector(i, 6)
                            WImpoIb = Vector(i, 7)

                            WImpoIb = Proceso.formatonumerico(WImpoIb)
                            WNeto = Proceso.formatonumerico(WNeto)

                            If Val(WImpoIb) > 0 Then

                                WNeto = ceros(WNeto, 12)
                                WImpoIb = ceros(WImpoIb, 11)

                                WTipoFac = "F"

                            Else

                                WNeto = Str$(Math.Abs(Val(WNeto)))
                                WImpoIb = Str$(Math.Abs(Val(WImpoIb)))

                                WImpoIb = Proceso.formatonumerico(WImpoIb)
                                WNeto = Proceso.formatonumerico(WNeto)

                                WNeto = ceros(WNeto, 11)
                                WImpoIb = ceros(WImpoIb, 10)

                                WNeto = "-" & WNeto
                                WImpoIb = "-" & WImpoIb

                                WTipoFac = "C"

                            End If

                            WRecibo = "00" & _Left(Vector(i, 1), 6)
                            WCuit = _Left(Vector(i, 0), 13)
                            WNumero = ceros(WNumero, 8)

                            escritor.Write(WCuit & WFecha & WTipoFac & XCodigo & _Right(WNumero, 5) & WNeto & WImpoIb & WFecha & "A" & vbCrLf)

                        End If

                        ProgressBar1.Increment(1)

                    Next


                    escritor.Close()

                    GroupBox1.Visible = False

                    MsgBox("Proceso Finalizado de Percepciones de Ingresoe Brutos", MsgBoxStyle.Information)

                Case Else
                    Dim tabla As DataTable
                    tabla = SQLConnector.retrieveDataTable("procesoperceibtucuman", ordDesde, ordHasta)

                    For Each row As DataRow In tabla.Rows

                        Dim CamposPercepcionTucuman As New ProcesoPercepcionTucuman(row.Item(0).ToString, row.Item(1), row.Item(2).ToString, row.Item(3).ToString, row.Item(4).ToString, row.Item(5).ToString, row.Item(6), row.Item(7).ToString, row.Item(8), row.Item(9))


                        WFecha = CamposPercepcionTucuman.fecha
                        WCuit = sacaguiones(CamposPercepcionTucuman.cuit)
                        WNumero = ceros(CamposPercepcionTucuman.numero, 8)
                        WNeto = ceros(formatonumerico(redondeo(CamposPercepcionTucuman.neto), "########0.#0", "."), 15)
                        WPorceIbII = 1.75
                        WPorceIb = ceros(formatonumerico(redondeo(WPorceIbII), "########0.#0", "."), 6)
                        WImporte = ceros(formatonumerico(redondeo(CamposPercepcionTucuman.impoibtucu), "########0.#0", "."), 15)


                        REM fecha
                        WCampo1 = WFecha
                        REM tipo de documento
                        WCampo2 = "80"
                        REM documento
                        WCampo3 = WCuit
                        REM tipo de comprobante
                        Select Case Val(CamposPercepcionTucuman.tipo)
                            Case 1, 3
                                WCampo4 = "01"
                            Case 4
                                WCampo4 = "02"
                            Case Else
                                WCampo4 = "03"
                        End Select
                        REM Letra de comprobante
                        WCampo5 = "A"
                        REM Punto de Venta
                        WCampo6 = "0001"
                        REM Numero del Comprobante
                        WCampo7 = WNumero
                        REM Numero del Comprobante
                        WCampo8 = WNeto
                        REM alicutoa
                        WCampo9 = WPorceIb
                        REM importe de la retencion
                        WCampo10 = WImporte
                        REM nor de ingresos brutos
                        REM Campo11 = Left$(WNroIbTucu + Space$(11), 11)
                        WCampo11 = ""

                        escritor.Write(WCampo1 + WCampo2 + WCampo3 + WCampo4 + WCampo5 + WCampo6 + WCampo7 + WCampo8 + WCampo9 + WCampo10 + WCampo11 + vbCrLf)

                    Next

                    escritor.Close()


                    MsgBox("Proceso Finalizado de Percepciones de Ingresoe Brutos", MsgBoxStyle.Information)

            End Select

        Catch ex As Exception
            escritor.Dispose()
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
            Exit Sub
        End Try
    End Sub

    Private Function _TraerCtasCtes(ByVal WDesde As String, ByVal WHasta As String) As DataTable
        Dim tabla As New DataTable

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT r.Clave, r.Fecha, r.Tipo, r.Numero, r.Cliente, c.Cuit FROM CtaCte r JOIN Cliente c ON c.Cliente = r.Cliente WHERE r.OrdFecha BETWEEN " & WDesde & " AND " & WHasta & " ORDER BY r.Numero")
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
            Throw New Exception("Hubo un problema al querer traer las Ctas Ctes desde la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

        Return tabla
    End Function

    Private Function _TraerReciboFactura(ByVal WTipo As String, ByVal WNumero As String) As DataTable

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT Recibo FROM Recibos WHERE Tipo1 = '" & WTipo & "' AND Numero1 = '" & WNumero & "'")
        Dim dr As SqlDataReader
        Dim ReciboFactura As New DataTable

        Try

            cn.ConnectionString = Proceso._ConectarA
            cn.Open()
            cm.Connection = cn

            dr = cm.ExecuteReader()

            If dr.HasRows Then

                ReciboFactura.Load(dr)

            End If

        Catch ex As Exception
            Throw New Exception("Hubo un problema al querer Consultar la Factura del Recibo en la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

        If ReciboFactura.Rows.Count > 0 Then
            Return ReciboFactura
        Else
            Return Nothing
        End If

    End Function

    Private Function _Left(ByVal wClave As String, ByVal i As Integer) As String
        Return Microsoft.VisualBasic.Left(wClave, i)
    End Function

    Private Function _Right(ByVal wClave As String, ByVal i As Integer) As String
        Return Microsoft.VisualBasic.Right(wClave, i)
    End Function

    Private Function _TraerCtaCte(ByVal WTipo As String, ByVal WNumero As String) As DataRow

        WNumero = Proceso.ceros(WNumero, 8)

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT Neto, ImpoIb FROM CtaCte WHERE Clave = '" & WTipo & WNumero & "01" & "'")
        Dim dr As SqlDataReader
        Dim CtaCte As New DataTable

        Try

            cn.ConnectionString = Proceso._ConectarA
            cn.Open()
            cm.Connection = cn

            dr = cm.ExecuteReader(CommandBehavior.SingleRow)

            If dr.HasRows Then

                CtaCte.Load(dr)

            End If

        Catch ex As Exception
            Throw New Exception("Hubo un problema al querer Consultar la Cta Cte en la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

        If CtaCte.Rows.Count > 0 Then
            Return CtaCte.Rows(0)
        Else
            Return Nothing
        End If

    End Function

    Private Function _TraerRecibos(ByVal WDesde As String, ByVal WHasta As String) As DataTable

        Dim tabla As New DataTable

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT r.Clave, r.Fecha, r.Tipo1 as Tipo, r.Numero1 as Numero, r.Cliente, c.Cuit FROM Recibos r JOIN Cliente c ON c.Cliente = r.Cliente WHERE FechaOrd BETWEEN " & WDesde & " AND " & WHasta & " AND TipoReg = '1' ORDER BY Clave")
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
            Throw New Exception("Hubo un problema al querer traer los Recibos desde la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

        Return tabla
    End Function

    Private Sub _ModificarCtaCteImporteIva0()

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("")
        Dim dr As SqlDataReader

        Try

            cn.ConnectionString = Proceso._ConectarA
            cn.Open()
            cm.Connection = cn

            cm.CommandType = CommandType.StoredProcedure
            cm.CommandText = "ModificaCtacteImporteIva0"
            cm.ExecuteNonQuery()

        Catch ex As Exception
            Throw New Exception("Hubo un problema al querer Modificar los Importes de Iva en las Cta Ctes en la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

    End Sub

    Private Sub CustomButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim viewer As New ReportViewer("Bancos", Globals.reportPathWithName("bancosnew.rpt"), "")
        viewer.Show()
        'viewer.imprimirReporte()
        'viewer.descargarComoPDF()


        ' Dim cryRpt As New ReportDocument
        'cryRpt.Load("C:\surfactan\sistemas\administracion\crystalreport\bancosnew.rpt")
        'CrystalReportViewer1.ReportSource = cryRpt
        'CrystalReportViewer1.Refresh()

        'REM cryRpt.PrintToPrinter(1, False, 1, 1)
        'cryRpt.PrintToPrinter(1, False, 1, 1)

        'Dim CrExportOptions As ExportOptions
        'Dim CrDiskFileDestinationOptions As New DiskFileDestinationOptions()
        'Dim CrFormatTypeOptions As New PdfRtfWordFormatOptions()

        'CrExportOptions = cryRpt.ExportOptions
        'With CrExportOptions
        '    .ExportDestinationType = ExportDestinationType.DiskFile
        '    .ExportFormatType = ExportFormatType.PortableDocFormat
        '    .DestinationOptions = CrDiskFileDestinationOptions
        '    .FormatOptions = CrFormatTypeOptions
        'End With

        ''Exporta y crea el pdf.
        'cryRpt.Export()

    End Sub

    Private Sub CustomButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim viewer As New ReportViewer("Bancos", "C:\surfactan\sistemas\administracion\crystalreport\bancosnew.rpt", "")
        viewer.descargarComoPDF()
        MsgBox("Descargado en: " & System.Windows.Forms.Application.StartupPath & "\Reportes")
    End Sub

    Private Sub CustomButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim viewer As New ReportViewer("Bancos", "C:\surfactan\sistemas\administracion\crystalreport\bancosnew.rpt", "")
        viewer.imprimirReporte()
    End Sub

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
                txtNombre.Focus()
            End If

        ElseIf e.KeyData = Keys.Escape Then
            txtHasta.Text = ""
        End If

    End Sub

    Private Sub txtNombre_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNombre.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txtNombre.Text) = "" Then : Exit Sub : End If

            With LugarProceso
                .DroppedDown = True
                .Focus()
            End With

        ElseIf e.KeyData = Keys.Escape Then
            txtNombre.Text = ""
        End If

    End Sub

    Private Sub LugarProceso_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles LugarProceso.KeyDown
        
        If e.KeyData = Keys.Enter Then

            With TipoProceso

                If LugarProceso.SelectedIndex = 0 Then
                    .Enabled = True
                    .DroppedDown = True
                    .Focus()
                Else
                    .Enabled = False
                End If

            End With

        ElseIf e.KeyData = Keys.Escape Then
            LugarProceso.SelectedIndex = 0
        End If

    End Sub

    Private Sub ProcesoPercepciones_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        txtDesde.Focus()
    End Sub

    Private Sub LugarProceso_DropDownClosed(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LugarProceso.DropDownClosed
        With TipoProceso

            If LugarProceso.SelectedIndex = 0 Then
                .Enabled = True
                .DroppedDown = True
                .Focus()
            Else
                .Enabled = False
            End If

        End With
    End Sub
End Class