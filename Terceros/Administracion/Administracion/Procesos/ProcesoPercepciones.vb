Imports System.Data.SqlClient
Imports ClasesCompartidas
Imports System.IO

Public Class ProcesoPercepciones


    Dim nombreArchivo As String

    Dim ordDesde As String
    Dim ordHasta As String


    Dim WCuit As String
    Dim WFecha As String
    Dim WTipoFac As String
    Dim WNumero As String
    Dim WNeto As String
    Dim WPorceIb As String

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
        Label2.Text = Proceso.NombreEmpresa()
        txtDesde.Text = "  /  /    "
        txtHasta.Text = "  /  /    "

        LugarProceso.Items.Clear()
        LugarProceso.Items.Add("Buenos Aires")
        LugarProceso.Items.Add("Tucuman")

        LugarProceso.SelectedIndex = 0
        TipoProceso.SelectedIndex = 0

    End Sub


    Private Sub btnCancela_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancela.Click
        Me.Hide()
        MenuPrincipal.Show()
    End Sub


    Private Sub btnAcepta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAcepta.Click
        Dim Vector(10000, 15) As String
        Dim WIndice = 0
        Dim XCodigo = "A0009000"
        Dim nombreArchivo1, nombreArchivo2, nombreArchivo3 As String
        Dim escritor, escritor1, escritor2, escritor3 As System.IO.StreamWriter

        If Proceso._EsPellital() Then
            XCodigo = "A0006000"
        End If

        ProgressBar1.Value = 0
        GroupBox1.Visible = True

        If Trim(txtNombre.Text) = "" And LugarProceso.SelectedIndex = 0 Then Exit Sub

        If FolderBrowserDialog1.ShowDialog() = DialogResult.OK Then
            nombreArchivo = FolderBrowserDialog1.SelectedPath
        Else
            Exit Sub
        End If

        If LugarProceso.SelectedIndex = 0 Then

            If LugarProceso.SelectedIndex = 0 Then
                REM XNombre = WDir + "\AR-30610524598-" + Nombre.Text + "-7-LOTE1.txt"
                nombreArchivo = nombreArchivo + "\AR-30549165083-" + txtNombre.Text + "7-LOTE1.txt"

                If Proceso._EsPellital() Then
                    nombreArchivo = nombreArchivo + "\AR-30610524598-" + txtNombre.Text + "7-LOTE1.txt"
                End If

            Else
                nombreArchivo = nombreArchivo + "\" + txtNombre.Text + ".txt"
            End If

        Else

            nombreArchivo &= "\"
            nombreArchivo1 = nombreArchivo & "\" & "Datos.txt"
            nombreArchivo2 = nombreArchivo & "\" & "RetPer.txt"
            nombreArchivo3 = nombreArchivo & "\" & "NcFact.txt"

        End If

        ordDesde = ordenaFecha(txtDesde.Text)
        ordHasta = ordenaFecha(txtHasta.Text)

        Try
            _ModificarCtaCteImporteIva0()

            Select Case LugarProceso.SelectedIndex
                Case 0 ' Buenos Aires.

                    File.Create(nombreArchivo).Dispose()

                    escritor = New System.IO.StreamWriter(nombreArchivo)
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

                    Dim WClave = "", WTipo = "", WImpoIb = "", WRecibo = 0, WSale = ""
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

                Case Else ' TUCUMAN

                    escritor1 = New StreamWriter(nombreArchivo1)
                    escritor2 = New StreamWriter(nombreArchivo2)
                    escritor3 = New StreamWriter(nombreArchivo3)

                    Dim ZEntra(1000) As String
                    Dim ZLugarEntra = 0
                    Dim WEntra = ""

                    Dim tabla As DataTable
                    tabla = _TraerCtaCtesIbTucuman(ordDesde, ordHasta) 'SQLConnector.retrieveDataTable("procesoperceibtucuman", ordDesde, ordHasta)

                    WIndice = 0

                    ProgressBar1.Step = 1
                    ProgressBar1.Maximum = tabla.Rows.Count * 2 + 1

                    For Each WCtaCte As DataRow In tabla.Rows

                        With WCtaCte

                            Vector(WIndice, 1) = IIf(IsDBNull(.Item("OrdFecha")), "", .Item("OrdFecha"))
                            Vector(WIndice, 2) = IIf(IsDBNull(.Item("Cliente")), "", .Item("Cliente"))
                            Vector(WIndice, 3) = IIf(IsDBNull(.Item("Tipo")), "", .Item("Tipo"))
                            Vector(WIndice, 4) = IIf(IsDBNull(.Item("Numero")), "", .Item("Numero"))
                            Vector(WIndice, 5) = IIf(IsDBNull(.Item("Neto")), "", .Item("Neto"))
                            Vector(WIndice, 6) = IIf(IsDBNull(.Item("ImpoIbTucu")), "", .Item("ImpoIbTucu"))
                            Vector(WIndice, 7) = IIf(IsDBNull(.Item("Cuit")), "", .Item("Cuit"))
                            Vector(WIndice, 8) = IIf(IsDBNull(.Item("NroIbTucu")), "", .Item("NroIbTucu"))
                            Vector(WIndice, 9) = IIf(IsDBNull(.Item("Razon")), "", .Item("Razon"))
                            Vector(WIndice, 10) = IIf(IsDBNull(.Item("Direccion")), "", .Item("Direccion"))
                            Vector(WIndice, 11) = IIf(IsDBNull(.Item("Localidad")), "", .Item("Localidad"))
                            Vector(WIndice, 12) = IIf(IsDBNull(.Item("Provincia")), "", .Item("Provincia"))
                            Vector(WIndice, 13) = IIf(IsDBNull(.Item("Postal")), "", .Item("Postal"))
                            Vector(WIndice, 14) = IIf(IsDBNull(.Item("IbTucu")), "0", .Item("IbTucu"))
                            Vector(WIndice, 15) = IIf(IsDBNull(.Item("PorceCm05Tucu")), "0", .Item("PorceCm05Tucu"))

                            If Vector(WIndice, 15) = 0 Then
                                Vector(WIndice, 15) = "1"
                            End If

                        End With

                        WIndice += 1

                        ProgressBar1.Increment(1)
                    Next

                    Dim WCliente = "", WTipo = "", WImpoIb = "", WNroIbTucu = "", WNombre = "", WDomicilio = "", WPuerta = "", WLocalidad = "", WProvincia = "", WPostal = "", WCodIBTucu = "", WPorceCm05Tucu = ""

                    For i = 0 To WIndice

                        WFecha = Vector(i, 1)

                        If Trim(WFecha) = "" Then Continue For

                        WCliente = Vector(i, 2)
                        WTipo = Vector(i, 3)
                        WNumero = Vector(i, 4)
                        WNeto = Vector(i, 5)
                        WImpoIb = Vector(i, 6)
                        WPorceIb = "1.75"

                        WCuit = Vector(i, 7)
                        WCuit = WCuit.Replace("-", "")

                        WNroIbTucu = Vector(i, 8)
                        WNombre = Vector(i, 9)
                        WDomicilio = Vector(i, 10)
                        WPuerta = "00000"
                        WLocalidad = Vector(i, 11)
                        WProvincia = Vector(i, 12)
                        WPostal = Vector(i, 13)
                        WCodIBTucu = Vector(i, 14)
                        WPorceCm05Tucu = Vector(i, 15)


                        Select Case Val(WCodIBTucu)
                            Case 1, 2, 3

                                If Val(WPorceCm05Tucu) <> 1 Then

                                    WNeto = Val(WNeto.Replace(",", ".")) * Val(WPorceCm05Tucu.Replace(",", "."))

                                End If

                        End Select

                        If Val(WNroIbTucu) = 0 Then
                            WNroIbTucu = "99999999999"
                        End If

                        WImpoIb = Proceso.formatonumerico(WImpoIb)

                        WNeto = Proceso.formatonumerico(WNeto)

                        WNeto = Str$(Val(WNeto))

                        WNeto = WNeto.Replace(",", ".")

                        If WImpoIb.EndsWith("0") Then
                            WImpoIb = Mid(WImpoIb, 1, WImpoIb.Length - 1)
                        End If

                        WPorceIb = ceros(WPorceIb, 6)
                        WImpoIb = ceros(WImpoIb, 15)
                        WNeto = ceros(WNeto, 15)
                        WNumero = ceros(WNumero, 8)
                        WCuit = ceros(WCuit, 11)
                        WPostal = ceros(WPostal, 4)
                        WNroIbTucu = ceros(WNroIbTucu, 11)

                        WCampo1 = WFecha

                        WCampo2 = "80"

                        WCampo3 = WCuit

                        Select Case Val(WTipo)
                            Case 1, 3
                                WCampo4 = "01"
                            Case 4
                                WCampo4 = "02"
                            Case Else
                                WCampo4 = "03"
                        End Select

                        WCampo5 = "A"

                        WCampo6 = "0009"

                        WCampo7 = "000" & Microsoft.VisualBasic.Right$(WNumero, 5)

                        WCampo8 = WNeto

                        WCampo9 = WPorceIb

                        WCampo10 = WImpoIb

                        WCampo11 = ""

                        escritor1.Write(WCampo1 + WCampo2 + WCampo3 + WCampo4 + WCampo5 + WCampo6 + WCampo7 + WCampo8 + WCampo9 + WCampo10 + WCampo11 + vbCrLf)

                        WEntra = "S"

                        For j = 0 To ZLugarEntra

                            If ZEntra(ZLugarEntra) = WCliente Then
                                WEntra = "N"
                                Exit For
                            End If

                        Next

                        If WEntra = "S" Then

                            WCampo1 = "80"
                            WCampo2 = WCuit
                            WCampo3 = WNombre.PadRight(40)
                            WCampo3 = Mid(WCampo3, 1, 40)

                            WCampo4 = WDomicilio.PadRight(40)
                            WCampo4 = Mid(WCampo4, 1, 40)
                            WCampo5 = WPuerta

                            WCampo6 = WLocalidad.PadRight(15)
                            WCampo6 = Mid(WCampo6, 1, 15)

                            WCampo7 = _ImpreProvincia(WProvincia)
                            WCampo7 = Mid(WCampo7.PadRight(15), 1, 15)

                            WCampo8 = WNroIbTucu.PadRight(11)
                            WCampo8 = Mid(WCampo8, 1, 11)

                            WCampo9 = Space(4) & WPostal

                            escritor2.Write(WCampo1 & WCampo2 & WCampo3 & WCampo4 & WCampo5 & WCampo6 & WCampo7 & WCampo8 & WCampo9 & vbCrLf)

                            ZLugarEntra += 1
                            ZEntra(ZLugarEntra) = WCliente

                        End If

                        ProgressBar1.Increment(1)

                    Next

                    escritor1.Dispose()
                    escritor2.Dispose()
                    escritor3.Dispose()

                    GroupBox1.Visible = False

                    MsgBox("Proceso Finalizado de Percepciones de Ingresoe Brutos", MsgBoxStyle.Information)

            End Select

        Catch ex As Exception
            If Not IsNothing(escritor) Then
                ' ReSharper disable once VBWarnings::BC42104
                escritor.Dispose()
            End If

            If Not IsNothing(escritor1) Then
                ' ReSharper disable once VBWarnings::BC42104
                escritor1.Dispose()
            End If
            If Not IsNothing(escritor2) Then
                ' ReSharper disable once VBWarnings::BC42104
                escritor2.Dispose()
            End If
            If Not IsNothing(escritor3) Then
                ' ReSharper disable once VBWarnings::BC42104
                escritor3.Dispose()
            End If


            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
            Exit Sub
        End Try
    End Sub

    Private Function _ImpreProvincia(ByVal WNum As Object)
        Dim provincia(25) As String

        provincia(0) = "Capital Federal"
        provincia(1) = "Buenos Aires"
        provincia(2) = "Catamarca"
        provincia(3) = "Cordoba"
        provincia(4) = "Corrientes"
        provincia(5) = "Chaco"
        provincia(6) = "Chubut"
        provincia(7) = "Entre Rios"
        provincia(8) = "Formosa"
        provincia(9) = "Jujuy"
        provincia(10) = "La Pampa"
        provincia(11) = "La Rioja"
        provincia(12) = "Mendoza"
        provincia(13) = "Misiones"
        provincia(14) = "Neuquen"
        provincia(15) = "Rio Negro"
        provincia(16) = "Salta"
        provincia(17) = "San Juan"
        provincia(18) = "San Luis"
        provincia(19) = "Santa Cruz"
        provincia(20) = "Santa Fe"
        provincia(21) = "Santiago del Estero"
        provincia(22) = "Tucuman"
        provincia(23) = "Tierra del Fuego"
        provincia(24) = "Exterior"
        provincia(25) = ""

        Return provincia(WNum)

    End Function

    Private Function _TraerCtaCtesIbTucuman(ByVal WDesde As String, ByVal WHasta As String) As DataTable

        Dim tabla As New DataTable

        Dim cn = New SqlConnection()
        Dim cm = New SqlCommand("SELECT c.OrdFecha, c.Cliente, c.Tipo, c.Numero, c.Neto, c.ImpoIbTucu," & _
                                              " cli.Cuit, cli.NroIbTucu, cli.Razon, cli.Direccion, cli.Localidad," & _
                                              " cli.Provincia, cli.Postal, cli.IbTucu, cli.PorceCm05Tucu" & _
                                              " FROM CtaCte as c JOIN Cliente as cli ON cli.Cliente = c.Cliente" & _
                                              " WHERE c.OrdFecha BETWEEN " & WDesde & " AND " & WHasta & " AND c.ImpoIbTucu > 0")
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
            Throw New Exception("Hubo un problema al querer consultar las Ctas Ctes (Tucumán) desde la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

        Return tabla
    End Function

    Private Function _TraerCtasCtes(ByVal WDesde As String, ByVal WHasta As String) As DataTable
        Dim tabla As New DataTable

        Dim cn = New SqlConnection()
        Dim cm = New SqlCommand("SELECT r.Clave, r.Fecha, r.Tipo, r.Numero, r.Cliente, c.Cuit FROM CtaCte r JOIN Cliente c ON c.Cliente = r.Cliente WHERE r.OrdFecha BETWEEN " & WDesde & " AND " & WHasta & " ORDER BY r.Numero")
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

    Private Function _TraerReciboFactura(ByVal WTipo As String, ByVal WNum As String) As DataTable

        Dim cn = New SqlConnection()
        Dim cm = New SqlCommand("SELECT Recibo FROM Recibos WHERE Tipo1 = '" & WTipo & "' AND Numero1 = '" & WNum & "'")
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

    Private Function _TraerCtaCte(ByVal WTipo As String, ByVal WNum As String) As DataRow

        WNumero = Proceso.ceros(WNumero, 8)

        Dim cn = New SqlConnection()
        Dim cm = New SqlCommand("SELECT Neto, ImpoIb FROM CtaCte WHERE Clave = '" & WTipo & WNum & "01" & "'")
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

        Dim cn = New SqlConnection()
        Dim cm = New SqlCommand("SELECT r.Clave, r.Fecha, r.Tipo1 as Tipo, r.Numero1 as Numero, r.Cliente, c.Cuit FROM Recibos r JOIN Cliente c ON c.Cliente = r.Cliente WHERE FechaOrd BETWEEN " & WDesde & " AND " & WHasta & " AND TipoReg = '1' ORDER BY Clave")
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

        Dim cn = New SqlConnection()
        Dim cm = New SqlCommand("")

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

            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

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