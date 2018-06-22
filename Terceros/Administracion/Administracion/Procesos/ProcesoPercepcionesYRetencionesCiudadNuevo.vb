Imports System.Data.SqlClient
Imports ClasesCompartidas
Imports System.IO

Public Class ProcesoPercepcionesYRetencionesCiudadNuevo


    Dim nombreArchivo As String

    Dim ordDesde As String
    Dim ordHasta As String


    Dim WCuit As String
    Dim WFecha As String
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
    Dim WCampo12 As String
    Dim WCampo13 As String
    Dim WCampo14 As String
    Dim WCampo15 As String
    Dim WCampo16 As String
    Dim WCampo17 As String
    Dim WCampo18 As String
    Dim WCampo19 As String
    Dim WCampo20 As String
    Dim WCampo21 As String

    Private Sub ProcesoPercepciones_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Label2.Text = Globals.NombreEmpresa()
        txtDesde.Text = "  /  /    "
        txtHasta.Text = "  /  /    "
        
    End Sub


    Private Sub btnCancela_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancela.Click
        Me.Hide()
        MenuPrincipal.Show()
    End Sub


    Private Sub btnAcepta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAcepta.Click
        Dim Vector(10000, 21) As String
        Dim VectorEntra(10000, 2) As String
        Dim WIndice = 0, WIndiceEntra = 0
        Dim escritor As System.IO.StreamWriter

        ProgressBar1.Value = 0
        GroupBox1.Visible = True

        If FolderBrowserDialog1.ShowDialog() = DialogResult.OK Then
            nombreArchivo = FolderBrowserDialog1.SelectedPath
        Else
            Exit Sub
        End If

        nombreArchivo = nombreArchivo + "\Ciudad.txt"

        ordDesde = ordenaFecha(txtDesde.Text)
        ordHasta = ordenaFecha(txtHasta.Text)

        'Try
        '_ModificarCtaCteImporteIva0()

        escritor = New StreamWriter(nombreArchivo)

        Dim tabla As DataTable
        tabla = _TraerCtaCtesIbCiudad(ordDesde, ordHasta) 'SQLConnector.retrieveDataTable("procesoperceibtucuman", ordDesde, ordHasta)

        WIndice = 0
        WIndiceEntra = 0

        ProgressBar1.Step = 1
        ProgressBar1.Maximum = tabla.Rows.Count * 2 + 1

        Dim WClave = "", WTipo = "", WImpoIb = "", WNombre = "", WPostal = "", WAlicuota = 0.0
        Dim WIva1 = 0.0, WIva2 = 0.0, WImpoIbTucu = 0.0, WImpoIbCiudad = 0.0, WTotal = 0.0

        For Each WCtaCte As DataRow In tabla.Rows

            With WCtaCte

                Vector(WIndice, 1) = IIf(IsDBNull(.Item("Clave")), "", .Item("Clave"))
                Vector(WIndice, 2) = IIf(IsDBNull(.Item("Fecha")), "", .Item("Fecha"))
                Vector(WIndice, 3) = IIf(IsDBNull(.Item("Tipo")), "", .Item("Tipo"))
                Vector(WIndice, 4) = IIf(IsDBNull(.Item("Numero")), "", .Item("Numero"))
                Vector(WIndice, 5) = IIf(IsDBNull(.Item("Cliente")), "", .Item("Cliente"))

                WNeto = IIf(IsDBNull(.Item("Neto")), "0", .Item("Neto"))
                WIva1 = IIf(IsDBNull(.Item("Iva1")), 0, .Item("Iva1"))
                WIva2 = IIf(IsDBNull(.Item("Iva2")), 0, .Item("Iva2"))
                WImpoIb = IIf(IsDBNull(.Item("ImpoIb")), 0, .Item("ImpoIb"))
                WImpoIbTucu = IIf(IsDBNull(.Item("ImpoIbTucu")), 0, .Item("ImpoIbTucu"))
                WImpoIbCiudad = IIf(IsDBNull(.Item("ImpoIbCiudad")), 0, .Item("ImpoIbCiudad"))
                WTotal = IIf(IsDBNull(.Item("Total")), 0, .Item("Total"))

                WNeto = Val(Proceso.formatonumerico(WNeto))
                WIva1 = Val(Proceso.formatonumerico(WIva1))
                WIva2 = Val(Proceso.formatonumerico(WIva2))
                WImpoIb = Val(Proceso.formatonumerico(WImpoIb))
                WImpoIbTucu = Val(Proceso.formatonumerico(WImpoIbTucu))
                WImpoIbCiudad = Val(Proceso.formatonumerico(WImpoIbCiudad))

                WAlicuota = WImpoIbCiudad / (WNeto / 100)

                WAlicuota = Val(Proceso.formatonumerico(WAlicuota))

                WNeto = WImpoIbCiudad / WAlicuota * 100

                WTotal = WNeto + WIva1 + WIva2 + WImpoIb + WImpoIbTucu + WImpoIbCiudad

                Vector(WIndice, 6) = Proceso.formatonumerico(WNeto)
                Vector(WIndice, 7) = Proceso.formatonumerico(WIva1)
                Vector(WIndice, 8) = Proceso.formatonumerico(WIva2)
                Vector(WIndice, 9) = Proceso.formatonumerico(WImpoIb)
                Vector(WIndice, 10) = Proceso.formatonumerico(WImpoIbTucu)
                Vector(WIndice, 11) = Proceso.formatonumerico(WImpoIbCiudad)
                Vector(WIndice, 12) = Proceso.formatonumerico(WTotal)
                Vector(WIndice, 13) = Proceso.formatonumerico(WAlicuota)

                Vector(WIndice, 14) = IIf(IsDBNull(.Item("Cuit")), "0", .Item("Cuit"))
                Vector(WIndice, 15) = IIf(IsDBNull(.Item("NroIbCiudad")), "0", .Item("NroIbCiudad"))
                Vector(WIndice, 16) = IIf(IsDBNull(.Item("Razon")), "", .Item("Razon"))
                Vector(WIndice, 17) = IIf(IsDBNull(.Item("Postal")), "", .Item("Postal"))
                Vector(WIndice, 18) = IIf(IsDBNull(.Item("IbCiudadII")), "0", .Item("IbCiudadII"))

            End With

            WIndice += 1

            ProgressBar1.Increment(1)

        Next

        Dim WNroIbCiudad = "", WIbCiudadII = 0.0, WOtros = 0.0, WIva = 0.0
        Dim WImpre = ""

        For i = 0 To WIndice

            WClave = Vector(i, 1)

            If Trim(WClave) = "" Then Continue For

            WFecha = Vector(i, 2)
            WTipo = Vector(i, 3)
            WNumero = Vector(i, 4)
            WNeto = Val(Vector(i, 6))
            WIva1 = Val(Vector(i, 7))
            WIva2 = Val(Vector(i, 8))
            WImpoIb = Val(Vector(i, 9))
            WImpoIbTucu = Val(Vector(i, 10))
            WImpoIbCiudad = Val(Vector(i, 11))
            WTotal = Val(Vector(i, 12))
            WAlicuota = Val(Vector(i, 13))
            WCuit = Vector(i, 14)
            WNroIbCiudad = Vector(i, 15)
            WNombre = Vector(i, 16)
            WPostal = Vector(i, 17)
            WIbCiudadII = Val(Vector(i, 18))

            If WImpoIbCiudad <= 0 Then Continue For

            WImpoIbCiudad = Val(Proceso.formatonumerico(WImpoIbCiudad))
            WNeto = Val(Proceso.formatonumerico(WNeto))
            WPorceIb = Val(Proceso.formatonumerico(WAlicuota))

            WOtros = WImpoIbCiudad + WImpoIb + WImpoIbTucu
            WIva = WIva1 + WIva2

            WOtros = Val(Proceso.formatonumerico(WOtros))
            WIva = Val(Proceso.formatonumerico(WIva))

            WNumero = ceros(WNumero, 12)
            WNumero = _Left("00090000000" & _Right(WNumero, 5) & Space(16), 16)

            WCuit = WCuit.Replace("-", "")

            WCuit = ceros(WCuit, 11)
            WPostal = ceros(WPostal, 4)
            WIbCiudadII = ceros(WIbCiudadII, 1)
            WNombre = _Left(WNombre & Space(30), 30)
            WNombre = UCase(WNombre).Replace("Ñ", "N")

            WCampo1 = "2"

            WCampo2 = "029"

            WCampo3 = WFecha

            Select Case Val(WTipo)
                Case 1, 77
                    WCampo4 = "01"
                Case Else
                    WCampo4 = "02"
            End Select

            WCampo5 = "A"

            WCampo6 = WNumero

            WCampo7 = WFecha

            WCampo8 = Proceso.formatonumerico(WTotal)
            WCampo8 = ceros(WCampo8, 16)
            WCampo8 = WCampo8.Replace(".", ",")

            WCampo9 = Space(16)

            WCampo10 = "3"

            WCampo11 = WCuit


            Select Case Val(WIbCiudadII)
                Case 1
                    WCampo12 = "1"
                Case 2
                    WCampo12 = "2"
                Case 3
                    WCampo12 = "4"
                Case 4
                    WCampo12 = "5"
                Case Else
                    WCampo12 = "0"
            End Select

            If Val(WIbCiudadII) <> 4 Then
                WCampo13 = "0" & ceros(WNroIbCiudad, 10)
            Else
                WCampo13 = WCuit
            End If

            WCampo14 = "1"
            WCampo15 = WNombre

            WCampo16 = Proceso.formatonumerico(WOtros)
            WCampo16 = ceros(WCampo16, 16)
            WCampo16 = WCampo16.Replace(".", ",")

            WCampo17 = Proceso.formatonumerico(WIva)
            WCampo17 = ceros(WCampo17, 16)
            WCampo17 = WCampo17.Replace(".", ",")

            WCampo18 = Proceso.formatonumerico(WNeto)
            WCampo18 = ceros(WCampo18, 16)
            WCampo18 = WCampo18.Replace(".", ",")

            WCampo19 = Proceso.formatonumerico(WPorceIb)
            WCampo19 = ceros(WCampo19, 5)
            WCampo19 = WCampo19.Replace(".", ",")

            WCampo20 = Proceso.formatonumerico(WImpoIbCiudad)
            WCampo20 = ceros(WCampo20, 16)
            WCampo20 = WCampo20.Replace(".", ",")

            WCampo21 = WCampo20

            WImpre = WCampo1 & WCampo2 & WCampo3 & WCampo4 & WCampo5 & WCampo6 & WCampo7 & WCampo8 & WCampo9 & WCampo10 & WCampo11 & WCampo12 & WCampo13 & WCampo14 & WCampo15 & WCampo16 & WCampo17 & WCampo18 & WCampo19 & WCampo20 & WCampo21

            VectorEntra(WIndiceEntra, 1) = WFecha
            VectorEntra(WIndiceEntra, 2) = WImpre

            WIndiceEntra += 1

        Next

        Array.Clear(Vector, 0, Vector.Length)
        WIndice = 0

        tabla.Rows.Clear()

        tabla = _TraerPagos(ordDesde, ordHasta)

        Dim WOrden = "", WImporte = 0.0, WRetencion = 0.0, WCertificadoIbCiudad = "", WRetIbCiudad = 0.0, WProveedor = "", WNroIb = ""

        For Each WPago As DataRow In tabla.Rows

            With WPago
                WRetIbCiudad = IIf(IsDBNull(.Item("RetIbCiudad")), 0, .Item("RetIbCiudad"))

                If WRetIbCiudad = 0 Then Continue For

                WOrden = IIf(IsDBNull(.Item("Orden")), "", .Item("Orden"))
                WProveedor = IIf(IsDBNull(.Item("Proveedor")), "", .Item("Proveedor"))
                WFecha = IIf(IsDBNull(.Item("Fecha")), "", .Item("Fecha"))
                WImporte = IIf(IsDBNull(.Item("Importe")), 0, .Item("Importe"))
                WRetencion = IIf(IsDBNull(.Item("Retencion")), 0, .Item("Retencion"))
                WCertificadoIbCiudad = IIf(IsDBNull(.Item("CertificadoIbCiudad")), "", .Item("CertificadoIbCiudad"))
                WRetIbCiudad = IIf(IsDBNull(.Item("RetIbCiudad")), 0, .Item("RetIbCiudad"))

                WNombre = IIf(IsDBNull(.Item("Nombre")), "", .Item("Nombre"))
                WIva = IIf(IsDBNull(.Item("Iva")), 0, .Item("Iva"))
                WNroIb = IIf(IsDBNull(.Item("NroIb")), "0", .Item("NroIb"))
                WCuit = IIf(IsDBNull(.Item("Cuit")), "", .Item("Cuit"))
                WIbCiudadII = IIf(IsDBNull(.Item("IbCiudadII")), 0, .Item("IbCiudadII"))

            End With

            Vector(WIndice, 1) = WOrden
            Vector(WIndice, 2) = WProveedor
            Vector(WIndice, 3) = WFecha
            Vector(WIndice, 4) = Proceso.formatonumerico(WImporte)
            Vector(WIndice, 5) = Proceso.formatonumerico(WRetencion)
            Vector(WIndice, 6) = Proceso.formatonumerico(WRetIbCiudad)
            Vector(WIndice, 7) = WCertificadoIbCiudad
            Vector(WIndice, 8) = WNombre
            Vector(WIndice, 9) = Proceso.formatonumerico(WIva)

            WNroIb = WNroIb.Replace("-", "")

            Vector(WIndice, 10) = WNroIb
            Vector(WIndice, 11) = WCuit
            Vector(WIndice, 12) = WIbCiudadII

            WIndice += 1
        Next

        WCuit = ""
        WNombre = ""
        WPostal = ""

        Dim WOrdenPago As DataTable
        Dim WBase = 0.0, WImporte1 = 0.0, WTipoIva = 0

        For i = 0 To WIndice

            WOrden = Vector(i, 1)
            WNumero = WOrden
            WProveedor = Vector(i, 2)
            WFecha = Vector(i, 3)
            WTotal = Val(Vector(i, 4))
            WImpoIb = Vector(i, 5)
            WImpoIbCiudad = Val(Vector(i, 6))
            WNroIbCiudad = Val(Vector(i, 7))
            WNombre = Vector(i, 8)
            WIva = Val(Vector(i, 9))
            WTipoIva = Val(Vector(i, 9))
            WNroIb = Vector(i, 10)
            WCuit = Vector(i, 11)
            WIbCiudadII = Val(Vector(i, 12))


            If Val(WImpoIbCiudad) = 0 Then Continue For

            WNumero = ceros(WNumero, 12)
            WNumero = _Left("0001" & WNumero & Space(16), 16)

            WImpoIbCiudad = Val(Proceso.formatonumerico(WImpoIbCiudad))

            WTotal = Val(Proceso.formatonumerico(WTotal))

            WNeto = WTotal

            If Val(WIva) = 2 Then
                WNeto = WTotal / 1.21
            End If

            WNeto = Proceso.formatonumerico(WNeto)

            WIva1 = WTotal - Val(WNeto)

            WIva2 = 0

            WIva1 = Val(Proceso.formatonumerico(WIva1))

            WPorceIb = Proceso.formatonumerico(2.5)

            WOtros = Val(Proceso.formatonumerico(WOtros))

            WIva = Val(Proceso.formatonumerico(WIva1))

            WCuit = WCuit.Replace("-", "")

            WCuit = ceros(WCuit, 11)
            WPostal = ceros(WPostal, 4)

            WNombre = _Left(WNombre & Space(30), 30)
            WNombre = UCase(WNombre).Replace("Ñ", "N")

            WCampo1 = "1"
            WCampo2 = "029"
            WCampo3 = WFecha
            WCampo4 = "03"
            WCampo5 = " "
            WCampo6 = WNumero
            WCampo7 = WFecha
            
            WCampo9 = ceros(WNroIbCiudad, 16)
            WCampo10 = "2"
            WCampo11 = WCuit

            Select Case Val(WIbCiudadII)
                Case 1
                    WCampo12 = "1"
                Case 2
                    WCampo12 = "2"
                Case 3
                    WCampo12 = "4"
                Case 4
                    WCampo12 = "5"
                Case Else
                    WCampo12 = "0"
            End Select

            WCampo13 = "0" & ceros(WNroIb, 10)
            WCampo14 = "1"
            WCampo15 = WNombre
            WOtros = 0
            WCampo16 = Proceso.formatonumerico(WOtros)
            WCampo16 = ceros(WCampo16, 16)
            WCampo16 = WCampo16.Replace(".", ",")
            WCampo17 = Proceso.formatonumerico(WIva)
            WCampo17 = ceros(WCampo17, 16)
            WCampo17 = WCampo17.Replace(".", ",")

            WCampo18 = Proceso.formatonumerico(WNeto)
            WCampo18 = ceros(WCampo18, 16)
            WCampo18 = WCampo18.Replace(".", ",")

            WOrdenPago = _TraerOrdenPago(WOrden)

            'If Val(WOrden) = 125588 Then Stop

            WBase = 0.0
            WImporte1 = 0.0

            For Each _WFila As DataRow In WOrdenPago.Rows

                With _WFila

                    WImporte1 = IIf(IsDBNull(.Item("Importe1")), 0, .Item("Importe1"))

                    If Val(WTipoIva) = 2 Then
                        WImporte1 = WImporte1 / 1.21
                    End If

                    WImporte1 = Val(Proceso.formatonumerico(WImporte1))

                    WBase += WImporte1

                End With

            Next

            WAlicuota = WImpoIbCiudad / (WBase / 100)

            WAlicuota = Val(Proceso.formatonumerico(WAlicuota))

            WImpoIbCiudad = Val(WNeto) * (WAlicuota / 100)

            WImpoIbCiudad = Val(Proceso.formatonumerico(WImpoIbCiudad))

            WTotal = WTotal - WImpoIbCiudad + WImpoIbCiudad

            WTotal = Val(Proceso.formatonumerico(WTotal))

            WCampo8 = Proceso.formatonumerico(WTotal)
            WCampo8 = ceros(WCampo8, 16)
            WCampo8 = WCampo8.Replace(".", ",")

            WCampo19 = Proceso.formatonumerico(WAlicuota)
            WCampo19 = ceros(WCampo19, 5)
            WCampo19 = WCampo19.Replace(".", ",")

            If WAlicuota = 6 Then
                WCampo2 = "016"
            End If

            WCampo20 = Proceso.formatonumerico(WImpoIbCiudad)
            WCampo20 = ceros(WCampo20, 16)
            WCampo20 = WCampo20.Replace(".", ",")
            WCampo21 = WCampo20

            WImpre = WCampo1 & WCampo2 & WCampo3 & WCampo4 & WCampo5 & WCampo6 & WCampo7 & WCampo8 & WCampo9 & WCampo10 & WCampo11 & WCampo12 & WCampo13 & WCampo14 & WCampo15 & WCampo16 & WCampo17 & WCampo18 & WCampo19 & WCampo20 & WCampo21

            VectorEntra(WIndiceEntra, 1) = WFecha
            VectorEntra(WIndiceEntra, 2) = WImpre

            WIndiceEntra += 1

        Next

        Dim WTemp1 = "", WTemp2 = ""

        For i = 0 To WIndiceEntra

            For j = 1 To WIndiceEntra

                If VectorEntra(i, 1) > VectorEntra(j, 1) Then

                    WTemp1 = VectorEntra(i, 1)
                    WTemp2 = VectorEntra(i, 2)

                    VectorEntra(i, 1) = VectorEntra(j, 1)
                    VectorEntra(i, 2) = VectorEntra(j, 2)

                    VectorEntra(j, 1) = WTemp1
                    VectorEntra(j, 2) = WTemp2

                End If

            Next

        Next

        For i = 0 To WIndiceEntra

            If String.IsNullOrEmpty(VectorEntra(i, 2)) Then Continue For

            escritor.Write(VectorEntra(i, 2) & vbCrLf)
        Next

        escritor.Dispose()

        GroupBox1.Visible = False

        MsgBox("Proceso Finalizado de Percepciones de Ingresoe Brutos", MsgBoxStyle.Information)

        'Catch ex As Exception

        '    If Not IsNothing(escritor) Then
        '        ' ReSharper disable once VBWarnings::BC42104
        '        escritor.Dispose()
        '    End If

        '    MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        '    Exit Sub
        'End Try
    End Sub

    Private Function _TraerOrdenPago(ByVal wOrden As String) As DataTable

        Dim tabla As New DataTable

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT Importe1 FROM Pagos WHERE Orden = '" & wOrden & "' AND TipoReg='1' ORDER BY Renglon")
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
            Throw New Exception("Hubo un problema al querer consultar la Orden de Pago desde la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

        Return tabla
    End Function

    Private Function _TraerPagos(ByVal WDesde As String, ByVal WHasta As String) As DataTable

        Dim tabla As New DataTable
        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT p.Orden, p.Proveedor, p.Fecha, p.Importe, p.Retencion, p.CertificadoIbCiudad, p.RetIbCiudad, " & _
                                              " pr.Nombre, pr.Iva, pr.NroIb, pr.Cuit, pr.IbCiudadII FROM Pagos p JOIN Proveedor pr ON pr.Proveedor = p.Proveedor " & _
                                              " WHERE FechaOrd BETWEEN " & WDesde & " AND " & WHasta & " AND p.Renglon = '01'")
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
            Throw New Exception("Hubo un problema al querer consultar los Pagos desde la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

        Return tabla
    End Function

    Private Function _TraerCtaCtesIbCiudad(ByVal WDesde As String, ByVal WHasta As String) As DataTable

        Dim tabla As New DataTable

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT c.Clave, c.Fecha, c.Tipo, c.Numero, c.Cliente, c.Neto, c.Iva1, c.Iva2, c.ImpoIb, c.ImpoIbTucu, c.ImpoIbCiudad, c.Total," & _
                                              " cli.Cuit, cli.NroIbCiudad, cli.Razon, cli.Localidad, cli.Postal, cli.IbCiudadII" & _
                                              " FROM CtaCte as c JOIN Cliente as cli ON cli.Cliente = c.Cliente" & _
                                              " WHERE c.OrdFecha BETWEEN " & WDesde & " AND " & WHasta & " AND c.ImpoIbCiudad <> 0")
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
            Throw New Exception("Hubo un problema al querer consultar las Ctas Ctes desde la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

        Return tabla
    End Function

    Private Function _Left(ByVal wClave As String, ByVal i As Integer) As String
        Return Microsoft.VisualBasic.Left(wClave, i)
    End Function

    Private Function _Right(ByVal wClave As String, ByVal i As Integer) As String
        Return Microsoft.VisualBasic.Right(wClave, i)
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
                txtDesde.Focus()
            End If

        ElseIf e.KeyData = Keys.Escape Then
            txtHasta.Text = ""
        End If

    End Sub

    Private Sub ProcesoPercepciones_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        txtDesde.Focus()
    End Sub

End Class