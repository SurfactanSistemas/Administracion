﻿Imports System.Data.SqlClient
Imports ClasesCompartidas
Imports System.IO

Public Class ProcesoCiti

    Dim nombreArchivo As String
    Dim ordDesde As String
    Dim ordHasta As String
    Dim WCuit As String
    Dim WFecha As String

    Dim WCampo1, WCampo2, WCampo3, WCampo4, WCampo5, _
        WCampo6, WCampo7, WCampo8, WCampo9, WCampo10, _
        WCampo11, WCampo12, WCampo13, WCampo14, WCampo15, WCampo16, _
        WCampo17, WCampo18, WCampo19, WCampo20, WCampo21, WCampo22, _
        WCampo23, WCampo24, WCampo25 As String

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
        Dim VectorII(10000, 21) As String
        Dim WIndice = 0, WIndice2 = 0
        Dim WDestino, nombreArchivo2 As String
        Dim escritor As System.IO.StreamWriter = Nothing
        Dim escritor2 As System.IO.StreamWriter = Nothing

        ProgressBar1.Value = 0
        GroupBox1.Visible = True

        If FolderBrowserDialog1.ShowDialog() = DialogResult.OK Then
            WDestino = FolderBrowserDialog1.SelectedPath
        Else
            Exit Sub
        End If

        Try
            nombreArchivo = WDestino & "\" & "REGINFO_CV_CABECERA" & ".txt"

            ordDesde = ordenaFecha(txtDesde.Text)
            ordHasta = ordenaFecha(txtHasta.Text)

            ' Grabamos la cabecera.

            WCampo1 = "30549165083"

            If Proceso._EsPellital() Then
                WCampo1 = "30610524598"
            End If

            WCampo1 &= Mid(ordHasta, 1, 4) & Mid(ordHasta, 5, 2)

            WCampo2 = "".PadRight(2, "0")
            WCampo3 = "N"
            WCampo4 = WCampo3
            WCampo5 = "2"
            WCampo6 = "".PadRight(15, "0")
            WCampo7 = "".PadRight(15, "0")
            WCampo8 = "".PadRight(15, "0")
            WCampo9 = "".PadRight(15, "0")
            WCampo10 = "".PadRight(15, "0")
            WCampo11 = "".PadRight(15, "0")
            WCampo12 = "".PadRight(15, "0")

            escritor = New StreamWriter(nombreArchivo)
            With escritor
                .Write(WCampo1 & WCampo2 & WCampo3 & WCampo4 & WCampo5 & WCampo6 & WCampo7 & WCampo8 & WCampo9 & WCampo10 & WCampo11 & WCampo12 & vbCrLf)
                .Dispose()
            End With

            ' Procesa Compras CBTE.

            nombreArchivo = WDestino & "\" & "REGINFO_CV_COMPRAS_CBTE" & ".txt"
            nombreArchivo2 = WDestino & "\" & "REGINFO_CV_COMPRAS_CBTEnRO" & ".txt"

            escritor = New StreamWriter(nombreArchivo)
            escritor2 = New StreamWriter(nombreArchivo2)

            Dim tabla As DataTable
            tabla = _TraerComprasCBTE()

            WIndice = 0

            ProgressBar1.Step = 1
            ProgressBar1.Maximum = tabla.Rows.Count * 2 + 1

            Dim WIva, ZNeto As Double

            For Each WImputac As DataRow In tabla.Rows

                With WImputac

                    WFecha = IIf(IsDBNull(.Item("Periodo")), "", .Item("Periodo"))
                    WFecha = Proceso.ordenaFecha(WFecha)

                    ' Salteamos el registro en caso que el Periodo se encuentre por fuera del rango solicitado.
                    If Val(WFecha) < Val(ordDesde) Or Val(WFecha) > ordHasta Then Continue For

                    WIndice += 1

                    'If .Item("NroInterno") = 155009 Then Stop

                    Vector(WIndice, 1) = IIf(IsDBNull(.Item("Letra")), "", .Item("Letra"))
                    Vector(WIndice, 2) = IIf(IsDBNull(.Item("Tipo")), "", .Item("Tipo"))
                    Vector(WIndice, 3) = IIf(IsDBNull(.Item("Punto")), "", .Item("Punto"))
                    Vector(WIndice, 4) = IIf(IsDBNull(.Item("Numero")), "", .Item("Numero"))
                    Vector(WIndice, 5) = IIf(IsDBNull(.Item("Fecha")), "", .Item("Fecha"))
                    Vector(WIndice, 6) = IIf(IsDBNull(.Item("Proveedor")), "", .Item("Proveedor"))
                    Vector(WIndice, 7) = IIf(IsDBNull(.Item("Neto")), "", .Item("Neto"))
                    Vector(WIndice, 8) = IIf(IsDBNull(.Item("Exento")), "", .Item("Exento"))
                    Vector(WIndice, 9) = IIf(IsDBNull(.Item("Iva21")), "", .Item("Iva21"))
                    Vector(WIndice, 10) = IIf(IsDBNull(.Item("Iva5")), "", .Item("Iva5"))
                    Vector(WIndice, 11) = IIf(IsDBNull(.Item("Iva27")), "", .Item("Iva27"))
                    Vector(WIndice, 12) = IIf(IsDBNull(.Item("Ib")), "", .Item("Ib"))
                    Vector(WIndice, 13) = IIf(IsDBNull(.Item("Despacho")), "", .Item("Despacho"))
                    Vector(WIndice, 14) = IIf(IsDBNull(.Item("NroInterno")), "", .Item("NroInterno"))
                    Vector(WIndice, 15) = IIf(IsDBNull(.Item("Fecha")), "", .Item("Fecha"))
                    Vector(WIndice, 16) = IIf(IsDBNull(.Item("Iva105")), "", .Item("Iva105"))
                    Vector(WIndice, 17) = ""
                    Vector(WIndice, 18) = ""

                    If Val(Vector(WIndice, 3)) = 0 Then
                        Vector(WIndice, 3) = "1"
                    End If

                    If Val(WFecha) < 20130101 Then
                        Vector(WIndice, 5) = ordDesde
                    Else
                        Vector(WIndice, 5) = Proceso.ordenaFecha(Vector(WIndice, 5))
                    End If

                    WIva = 0

                    WIva += Val(Proceso.formatonumerico(Vector(WIndice, 9))) ' Iva 21
                    WIva += Val(Proceso.formatonumerico(Vector(WIndice, 11))) ' Iva 27
                    WIva += Val(Proceso.formatonumerico(Vector(WIndice, 16))) ' Iva 10.5


                    If Val(Vector(WIndice, 7)) = 0 And WIva <> 0 And Trim(Vector(WIndice, 13)) = "" Then

                        ZNeto = 0

                        ZNeto += Val(Proceso.formatonumerico(Vector(WIndice, 9))) / 21 * 100
                        ZNeto += Val(Proceso.formatonumerico(Vector(WIndice, 11))) / 27 * 100
                        ZNeto += Val(Proceso.formatonumerico(Vector(WIndice, 16))) / 10.5 * 100

                        Vector(WIndice, 7) = Proceso.formatonumerico(ZNeto)

                    End If

                End With

                ProgressBar1.Increment(1)

            Next

            Dim WDespacho, WLetra, WTipo, WPunto, WNumero, WProveedor, WNeto, WExento, WIva5, WIva21, WIva27, WIva105, WIb, WNroInterno As String
            Dim WImpre = ""
            Dim WIvaCompAdicional As DataTable

            WDespacho = ""
            WLetra = ""
            WTipo = ""
            WPunto = ""
            WNumero = ""
            WProveedor = ""
            WNeto = ""
            WExento = ""
            WIva5 = ""
            WIva21 = ""
            WIva27 = ""
            WIva105 = ""
            WIb = ""
            WNroInterno = ""

            WIndice2 = 0

            For i = 1 To WIndice

                WNroInterno = Vector(i, 14)

                ' Buscamos los datos de la Factura en IvaCompAdicional en caso de existir.
                WIvaCompAdicional = _TraerDatosIvaCompAdicional(WNroInterno)

                'If WIndice2 = 70 Then Stop

                If WIvaCompAdicional.Rows.Count > 0 Then

                    ' Agregamos una por una las facturas al nuevo Vector.
                    For Each WAdicional As DataRow In WIvaCompAdicional.Rows
                        WIndice2 += 1

                        With WAdicional

                            VectorII(WIndice2, 1) = IIf(IsDBNull(.Item("Letra")), "", .Item("Letra"))
                            VectorII(WIndice2, 2) = IIf(IsDBNull(.Item("Tipo")), "", .Item("Tipo"))
                            VectorII(WIndice2, 3) = IIf(IsDBNull(.Item("Punto")), "", .Item("Punto"))
                            VectorII(WIndice2, 4) = IIf(IsDBNull(.Item("Numero")), "", .Item("Numero"))
                            VectorII(WIndice2, 5) = IIf(IsDBNull(.Item("Fecha")), "", .Item("Fecha"))
                            VectorII(WIndice2, 6) = ""
                            VectorII(WIndice2, 7) = IIf(IsDBNull(.Item("Neto")), "", .Item("Neto"))
                            VectorII(WIndice2, 8) = IIf(IsDBNull(.Item("Exento")), "", .Item("Exento"))
                            VectorII(WIndice2, 9) = IIf(IsDBNull(.Item("Iva21")), "", .Item("Iva21"))
                            VectorII(WIndice2, 10) = IIf(IsDBNull(.Item("PerceIb")), "", .Item("PerceIb"))
                            VectorII(WIndice2, 11) = IIf(IsDBNull(.Item("Iva27")), "", .Item("Iva27"))
                            VectorII(WIndice2, 12) = IIf(IsDBNull(.Item("PerceIva")), "", .Item("PerceIva"))
                            VectorII(WIndice2, 13) = ""
                            VectorII(WIndice2, 14) = WNroInterno
                            VectorII(WIndice2, 15) = IIf(IsDBNull(.Item("Fecha")), "", .Item("Fecha"))
                            VectorII(WIndice2, 16) = IIf(IsDBNull(.Item("Iva105")), "", .Item("Iva105"))
                            VectorII(WIndice2, 17) = IIf(IsDBNull(.Item("Cuit")), "", .Item("Cuit"))
                            VectorII(WIndice2, 18) = IIf(IsDBNull(.Item("Razon")), "", .Item("Razon"))

                            If Val(VectorII(WIndice2, 3)) = 0 Then
                                VectorII(WIndice2, 3) = "1"
                            End If

                            Select Case UCase(VectorII(WIndice2, 2))
                                Case "NC", "C"
                                    VectorII(WIndice2, 2) = "03"
                                Case "ND", "D"
                                    VectorII(WIndice2, 2) = "02"
                                Case Else
                                    VectorII(WIndice2, 2) = "01"
                            End Select

                            VectorII(WIndice2, 5) = Proceso.ordenaFecha(VectorII(WIndice2, 5))

                        End With

                    Next

                Else
                    ' En caso de no tener facturas en IvaCompAdicional, solo pasamos los datos al nuevo Vector.
                    WIndice2 += 1

                    For j = 1 To 18

                        VectorII(WIndice2, j) = Vector(i, j)

                    Next

                End If

            Next

            Dim ZSuma, ZTotal, ZImpo, ZAlicuota, ZResto As Double
            Dim WRazon, WCodigoExento As String
            Dim XProveedor As DataRow

            ZSuma = 0
            ZTotal = 0
            ZImpo = 0
            ZAlicuota = 0
            ZResto = 0
            ' Procesamos las Sumas.
            For i = 1 To WIndice2

                WLetra = VectorII(i, 1)
                WTipo = VectorII(i, 2)
                WPunto = VectorII(i, 3)
                WNumero = VectorII(i, 4)
                WFecha = VectorII(i, 5)
                WProveedor = VectorII(i, 6)
                WNeto = VectorII(i, 7)
                WExento = VectorII(i, 8)
                WIva21 = VectorII(i, 9)
                WIva5 = VectorII(i, 10)
                WIva27 = VectorII(i, 11)
                WIb = VectorII(i, 12)
                WDespacho = VectorII(i, 13)
                WNroInterno = VectorII(i, 14)
                WIva105 = VectorII(i, 16)
                WCuit = VectorII(i, 17)
                WRazon = VectorII(i, 18)

                'If i = 71 Then Stop

                WNeto = CInt(Val(Proceso.formatonumerico(WNeto)) * 100)
                WExento = CInt(Val(Proceso.formatonumerico(WExento)) * 100)
                WIva21 = CInt(Val(Proceso.formatonumerico(WIva21)) * 100)
                WIva5 = CInt(Val(Proceso.formatonumerico(WIva5)) * 100)
                WIva27 = CInt(Val(Proceso.formatonumerico(WIva27)) * 100)
                WIva105 = CInt(Val(Proceso.formatonumerico(WIva105)) * 100)
                WIb = CInt(Val(Proceso.formatonumerico(WIb)) * 100)

                WDespacho = Trim(WDespacho).Replace(" ", "")
                WDespacho = _Left(WDespacho & Space(16), 16)

                If Trim(WDespacho) <> "" Then
                    WDespacho = _Left(Trim(WDespacho) & "".PadRight(16, "0"), 16)
                End If

                WLetra = UCase(WLetra)

                If WLetra = "B" Or WLetra = "C" Then
                    WExento = "0"
                End If

                WIva = 0
                Select Case WProveedor
                    Case "10065511620", "10070956507", "10065786411"
                        WIva += Val(Proceso.formatonumerico(WIva21))
                        WIva += Val(Proceso.formatonumerico(WIva27))
                        WIva += Val(Proceso.formatonumerico(WIva105))

                        WIva27 = Str$(WIva)
                        WIva21 = 0
                        WIva105 = 0

                    Case "10053718600", "10050001091", "10099924210", "10050000845"

                        WIva += Val(Proceso.formatonumerico(WIva21))
                        WIva += Val(Proceso.formatonumerico(WIva27))
                        WIva += Val(Proceso.formatonumerico(WIva105))

                        WIva105 = Str$(WIva)
                        WIva21 = 0
                        WIva27 = 0

                End Select

                WIva = 0

                WIva += Val(Proceso.formatonumerico(WIva21))
                WIva += Val(Proceso.formatonumerico(WIva27))
                WIva += Val(Proceso.formatonumerico(WIva105))

                If WIva = 0 Then
                    WNeto = Str$(Val(Proceso.formatonumerico(WNeto)) + Val(Proceso.formatonumerico(WExento)))
                    WExento = "0"
                End If

                ZTotal = 0
                ZResto = 0

                'If i = 35 Then Stop

                ZTotal = Val(WNeto) + Val(WExento) + Val(WIva21) + Val(WIva5) + Val(WIva27) + Val(WIva105) + Val(WIb)

                If Trim(WDespacho) <> "" And Val(WNeto) = 0 Then

                    ZImpo = CInt(Val(Proceso.formatonumerico(WIva21)) / 21 * 100)

                    ZTotal += ZImpo

                End If

                WCodigoExento = " "

                If Val(WIva) = 0 Then
                    WCodigoExento = "N"
                End If

                ZAlicuota = 0

                If Val(WIva21) <> 0 Then
                    ZAlicuota += 1
                End If

                If Val(WIva27) <> 0 Then
                    ZAlicuota += 1
                End If

                If Val(WIva105) <> 0 Then
                    ZAlicuota += 1
                End If

                If Val(WIva) = 0 And Val(WNeto) <> 0 Then
                    ZAlicuota += 1
                End If

                If WLetra = "B" Or WLetra = "C" Then
                    ZAlicuota = 0
                End If

                If Trim(WProveedor) <> "" Then

                    XProveedor = _TraerDatosProveedor(WProveedor)

                    If Not IsNothing(XProveedor) Then

                        With XProveedor
                            WRazon = IIf(IsDBNull(.Item("Razon")), "", .Item("Razon"))
                            WCuit = IIf(IsDBNull(.Item("Cuit")), "", .Item("Cuit"))
                        End With

                    End If

                End If

                WRazon = _Left(WRazon & Space(30), 30)

                WCampo1 = WFecha
                WCampo2 = ""

                Select Case UCase(WLetra)
                    Case "A"
                        Select Case Val(WTipo)
                            Case 1
                                WCampo2 = "1"
                            Case 2
                                WCampo2 = "2"
                            Case 3
                                WCampo2 = "3"
                            Case Else
                                WCampo2 = "0"
                        End Select
                    Case "B"
                        Select Case Val(WTipo)
                            Case 1
                                WCampo2 = "6"
                            Case 2
                                WCampo2 = "7"
                            Case 3
                                WCampo2 = "8"
                            Case Else
                                WCampo2 = "0"
                        End Select
                    Case "C"
                        Select Case Val(WTipo)
                            Case 1
                                WCampo2 = "11"
                            Case 2
                                WCampo2 = "12"
                            Case 3
                                WCampo2 = "13"
                            Case Else
                                WCampo2 = "0"
                        End Select
                    Case "M"
                        Select Case Val(WTipo)
                            Case 1
                                WCampo2 = "51"
                            Case 2
                                WCampo2 = "52"
                            Case 3
                                WCampo2 = "53"
                            Case Else
                                WCampo2 = "0"
                        End Select
                End Select

                If Trim(WDespacho) <> "" Then
                    WCampo2 = "66"
                    WPunto = "0"
                    WNumero = "0"
                End If

                WCampo2 = ceros(WCampo2, 3)

                WCampo3 = ceros(WPunto, 5)

                WCampo4 = ceros(WNumero, 20)

                WCampo5 = WDespacho

                WCampo6 = "80"

                WCuit = WCuit.Replace("-", "")
                WCampo7 = ceros(WCuit, 20)

                WCampo8 = WRazon

                WCampo9 = Str$(Math.Abs(ZTotal))

                WCampo9 = ceros(WCampo9, 15)

                WCampo10 = Str$(Math.Abs(ZResto))

                WCampo10 = ceros(WCampo10, 15)

                WCampo12 = Proceso.formatonumerico(WExento)

                WCampo12 = Str$(Math.Abs(Val(WCampo12)))

                WCampo12 = ceros(WCampo12, 15)

                WCampo13 = ceros("0", 15)

                WCampo14 = Proceso.formatonumerico(WIb)

                WCampo14 = Str$(Math.Abs(Val(WCampo14)))

                WCampo14 = ceros(WCampo14, 15)

                WCampo15 = ceros("0", 15)

                WCampo16 = ceros("0", 15)

                WCampo17 = "PES"

                WCampo18 = ceros("1000000", 10)

                WCampo19 = Str$(ZAlicuota)

                If WLetra = "A" Or WLetra = "M" Then
                    If ZAlicuota = 0 Then
                        WCampo19 = "1"
                    End If
                End If

                WCampo19 = ceros(WCampo19, 1)

                WCampo20 = WCodigoExento

                WCampo21 = Proceso.formatonumerico(WIva)

                WCampo21 = Str$(Math.Abs(Val(WCampo21)))

                WCampo21 = ceros(WCampo21, 15)

                WCampo22 = ceros("0", 15)

                WCampo23 = ceros("0", 11)

                WCampo24 = Space(30)

                WCampo25 = ceros("0", 15)

                'If ZSuma = 704 Then Stop

                If Val(WCuit) <> 0 Then

                    ZSuma += 1

                    WImpre = WCampo1 & WCampo2 & WCampo3 & WCampo4 & WCampo5 & _
                            WCampo6 & WCampo7 & WCampo8 & WCampo9 & WCampo10 & _
                            WCampo11 & WCampo12 & WCampo13 & WCampo14 & WCampo15 & _
                            WCampo16 & WCampo17 & WCampo18 & WCampo19 & WCampo20 & _
                            WCampo21 & WCampo22 & WCampo23 & WCampo24 & WCampo25

                    escritor.Write(WImpre & vbCrLf)
                    escritor2.Write(Str$(ZSuma) & " " & WNroInterno & " " & WImpre & vbCrLf)

                End If

                ProgressBar1.Increment(1)
            Next

            ' Procesamos las Alicuotas.

            escritor.Dispose()
            escritor2.Dispose()

            nombreArchivo = WDestino & "\" & "REGINFO_CV_COMPRAS_ALICUOTAS" & ".txt"
            nombreArchivo2 = WDestino & "\" & "REGINFO_CV_COMPRAS_ALICUOTASNro" & ".txt"

            escritor = New StreamWriter(nombreArchivo)
            escritor2 = New StreamWriter(nombreArchivo2)

            ZSuma = 0
            ZResto = 0
            For i = 1 To WIndice2

                WLetra = VectorII(i, 1)
                WLetra = UCase(WLetra)

                If WLetra <> "A" And WLetra <> "M" Then Continue For

                WTipo = VectorII(i, 2)
                WPunto = VectorII(i, 3)
                WNumero = VectorII(i, 4)
                WFecha = VectorII(i, 5)
                WProveedor = VectorII(i, 6)
                WNeto = VectorII(i, 7)
                WExento = VectorII(i, 8)
                WIva21 = VectorII(i, 9)
                WIva5 = VectorII(i, 10)
                WIva27 = VectorII(i, 11)
                WIb = VectorII(i, 12)
                WDespacho = VectorII(i, 13)
                WNroInterno = VectorII(i, 14)
                WIva105 = VectorII(i, 16)
                WCuit = VectorII(i, 17)
                WRazon = VectorII(i, 18)

                'If i = 71 Then Stop

                WNeto = Proceso.formatonumerico(WNeto)
                WNeto = Str$(Int(Math.Abs(Val(WNeto)) * 100))

                WExento = Proceso.formatonumerico(WExento)
                WExento = Str$(Int(Math.Abs(Val(WExento)) * 100))

                WIva21 = Proceso.formatonumerico(WIva21)
                WIva21 = Str$(Int(Math.Abs(Val(WIva21)) * 100))

                WIva5 = Proceso.formatonumerico(WIva5)
                WIva5 = Str$(Int(Math.Abs(Val(WIva5)) * 100))

                WIva27 = Proceso.formatonumerico(WIva27)
                WIva27 = Str$(Int(Math.Abs(Val(WIva27)) * 100))

                WIva105 = Proceso.formatonumerico(WIva105)
                WIva105 = Str$(Int(Math.Abs(Val(WIva105)) * 100))

                WIb = Proceso.formatonumerico(WIb)
                WIb = Str$(Int(Math.Abs(Val(WIb)) * 100))

                WDespacho = Trim(WDespacho).Replace(" ", "")
                WDespacho = _Left(WDespacho & Space(16), 16)

                If Trim(WDespacho) <> "" Then
                    WDespacho = _Left(Trim(WDespacho) & "".PadRight(16, "0"), 16)
                End If

                If WLetra = "B" Or WLetra = "C" Then
                    ZResto = Val(WExento)
                    WExento = "0"
                End If

                Select Case Trim(WProveedor)
                    Case "10065511620", "10070956507", "10065786411"
                        WIva = Val(WIva21) + Val(WIva27) + Val(WIva105)
                        WIva27 = WIva
                        WIva21 = 0
                        WIva105 = 0
                    Case "10053718600", "10050001091", "10099924210", "10050000845"
                        WIva = Val(WIva21) + Val(WIva27) + Val(WIva105)
                        WIva105 = WIva
                        WIva21 = 0
                        WIva27 = 0
                End Select

                WIva = Val(WIva21) + Val(WIva27) + Val(WIva105)

                If WIva = 0 Then
                    WNeto = Val(WNeto) + Val(WExento)
                    WExento = 0
                End If

                ZTotal = Val(WNeto) + Val(WExento) + Val(WIva21) + Val(WIva5) + Val(WIva27) + Val(WIva105) + Val(WIb)

                WCodigoExento = " "

                If WIva = 0 Then
                    WCodigoExento = "N"
                End If

                ZAlicuota = 0
                If Val(WIva21) <> 0 Then
                    ZAlicuota += 1
                End If
                If Val(WIva27) <> 0 Then
                    ZAlicuota += 1
                End If
                If Val(WIva105) <> 0 Then
                    ZAlicuota += 1
                End If
                If WIva = 0 And Val(WNeto) <> 0 Then
                    ZAlicuota += 1
                End If
                If WLetra = "B" Or WLetra = "C" Then
                    ZAlicuota = 0
                End If

                If Trim(WProveedor) <> "" Then

                    XProveedor = _TraerDatosProveedor(WProveedor)

                    If Not IsNothing(XProveedor) Then

                        With XProveedor
                            WRazon = IIf(IsDBNull(.Item("Razon")), "", .Item("Razon"))
                            WCuit = IIf(IsDBNull(.Item("Cuit")), "", .Item("Cuit"))
                        End With

                    End If

                End If

                WRazon = _Left(WRazon & Space(30), 30)

                If Val(WCuit) <> 0 And Trim(WDespacho) = "" Then

                    'If ZSuma = 332 Then Stop

                    Select Case UCase(WLetra)
                        Case "A"

                            Select Case Val(WTipo)
                                Case 1
                                    WCampo1 = "1"
                                Case 2
                                    WCampo1 = "2"
                                Case 3
                                    WCampo1 = "3"
                                Case Else
                                    WCampo1 = "0"
                            End Select

                        Case "M"

                            Select Case Val(WTipo)
                                Case 1
                                    WCampo1 = "51"
                                Case 2
                                    WCampo1 = "52"
                                Case 3
                                    WCampo1 = "53"
                                Case Else
                                    WCampo1 = "0"
                            End Select

                        Case Else
                            WCampo1 = "0"
                    End Select

                    If Trim(WDespacho) <> "" Then
                        WCampo1 = "066"
                        WPunto = "0"
                        WNumero = "0"
                    End If

                    WCampo1 = ceros(WCampo1, 3)

                    WCampo2 = ceros(WPunto, 5)

                    WCampo3 = ceros(WNumero, 20)

                    WCampo4 = "80"

                    WCuit = WCuit.Replace("-", "")
                    WCampo5 = ceros(WCuit, 20)

                    If Val(WIva21) <> 0 Then

                        If ZAlicuota = 1 Then

                            WCampo6 = Str$(Math.Abs(Val(WNeto)))

                        Else

                            ZImpo = CInt(Val(WIva21) / 21 * 100)
                            WCampo6 = Str$(Math.Abs(ZImpo))

                        End If

                        WCampo6 = ceros(WCampo6, 15)

                        WCampo7 = "0005"

                        WCampo8 = Str$(Math.Abs(Val(WIva21)))
                        WCampo8 = ceros(WCampo8, 15)

                        ZSuma += 1

                        WImpre = WCampo1 & WCampo2 & WCampo3 & WCampo4 & WCampo5 & WCampo6 & WCampo7 & WCampo8 & vbCrLf

                        escritor.Write(WImpre)
                        escritor2.Write(Str$(ZSuma) & " " & WNroInterno & " " & WImpre)

                    End If

                    If Val(WIva105) <> 0 Then

                        If ZAlicuota = 1 Then

                            WCampo6 = Str$(Math.Abs(Val(WNeto)))

                        Else

                            ZImpo = CInt(Val(WIva105) / 10.5 * 100)
                            WCampo6 = Str$(Math.Abs(ZImpo))

                        End If

                        WCampo6 = ceros(WCampo6, 15)

                        WCampo7 = "0004"

                        WCampo8 = Str$(Math.Abs(Val(WIva105)))
                        WCampo8 = ceros(WCampo8, 15)

                        'If ZSuma = 62 Then Stop

                        ZSuma += 1

                        WImpre = WCampo1 & WCampo2 & WCampo3 & WCampo4 & WCampo5 & WCampo6 & WCampo7 & WCampo8 & vbCrLf

                        escritor.Write(WImpre)
                        escritor2.Write(Str$(ZSuma) & " " & WNroInterno & " " & WImpre)

                    End If

                    If Val(WIva27) <> 0 Then

                        If ZAlicuota = 1 Then

                            WCampo6 = Str$(Math.Abs(Val(WNeto)))

                        Else

                            ZImpo = CInt(Val(WIva27) / 27 * 100)
                            WCampo6 = Str$(Math.Abs(ZImpo))

                        End If

                        WCampo6 = ceros(WCampo6, 15)

                        WCampo7 = "0006"

                        WCampo8 = Str$(Math.Abs(Val(WIva27)))
                        WCampo8 = ceros(WCampo8, 15)

                        ZSuma += 1

                        WImpre = WCampo1 & WCampo2 & WCampo3 & WCampo4 & WCampo5 & WCampo6 & WCampo7 & WCampo8 & vbCrLf

                        escritor.Write(WImpre)
                        escritor2.Write(Str$(ZSuma) & " " & WNroInterno & " " & WImpre)

                    End If

                    If WIva = 0 And Val(WNeto) <> 0 Then

                        WCampo6 = Str$(Math.Abs(Val(WNeto)))

                        WCampo6 = ceros(WCampo6, 15)

                        WCampo7 = "0003"

                        WCampo8 = "0"
                        WCampo8 = ceros(WCampo8, 15)

                        ZSuma += 1

                        WImpre = WCampo1 & WCampo2 & WCampo3 & WCampo4 & WCampo5 & WCampo6 & WCampo7 & WCampo8 & vbCrLf

                        escritor.Write(WImpre)
                        escritor2.Write(Str$(ZSuma) & " " & WNroInterno & " " & WImpre)

                    End If


                End If

                ProgressBar1.Increment(1)

            Next

            escritor.Dispose()
            escritor2.Dispose()

            ' Procesamos las Importaciones.

            nombreArchivo = WDestino & "\" & "REGINFO_CV_COMPRAS_IMPORTACIONES" & ".txt"

            escritor = New StreamWriter(nombreArchivo)

            For i = 1 To WIndice2

                WDespacho = VectorII(i, 13)

                If Trim(WDespacho) = "" Then Continue For

                WTipo = VectorII(i, 2)
                WPunto = VectorII(i, 3)
                WNumero = VectorII(i, 4)
                WFecha = VectorII(i, 5)
                WProveedor = VectorII(i, 6)
                WNeto = VectorII(i, 7)
                WExento = VectorII(i, 8)
                WIva21 = VectorII(i, 9)
                WIva5 = VectorII(i, 10)
                WIva27 = VectorII(i, 11)
                WIb = VectorII(i, 12)
                WDespacho = VectorII(i, 13)
                WNroInterno = VectorII(i, 14)
                WIva105 = VectorII(i, 16)
                WCuit = VectorII(i, 17)
                WRazon = VectorII(i, 18)

                'If i = 71 Then Stop

                WNeto = Proceso.formatonumerico(WNeto)
                WNeto = Str$(Int(Math.Abs(Val(WNeto)) * 100))

                WExento = Proceso.formatonumerico(WExento)
                WExento = Str$(Int(Math.Abs(Val(WExento)) * 100))

                WIva21 = Proceso.formatonumerico(WIva21)
                WIva21 = Str$(Int(Math.Abs(Val(WIva21)) * 100))

                WIva5 = Proceso.formatonumerico(WIva5)
                WIva5 = Str$(Int(Math.Abs(Val(WIva5)) * 100))

                WIva27 = Proceso.formatonumerico(WIva27)
                WIva27 = Str$(Int(Math.Abs(Val(WIva27)) * 100))

                WIva105 = Proceso.formatonumerico(WIva105)
                WIva105 = Str$(Int(Math.Abs(Val(WIva105)) * 100))

                WIb = Proceso.formatonumerico(WIb)
                WIb = Str$(Int(Math.Abs(Val(WIb)) * 100))

                WDespacho = WDespacho.Replace(" ", "")

                If Trim(WDespacho) <> "" Then
                    WDespacho = _Left(Trim(WDespacho) & ceros("0", 16), 16)
                End If

                If WLetra = "B" Or WLetra = "C" Then
                    ZResto = Val(WExento)
                    WExento = "0"
                End If

                Select Case Trim(WProveedor)
                    Case "10065511620", "10070956507", "10065786411"
                        WIva = Val(WIva21) + Val(WIva27) + Val(WIva105)
                        WIva27 = WIva
                        WIva21 = 0
                        WIva105 = 0
                    Case "10053718600", "10050001091", "10099924210", "10050000845"
                        WIva = Val(WIva21) + Val(WIva27) + Val(WIva105)
                        WIva105 = WIva
                        WIva21 = 0
                        WIva27 = 0
                End Select

                WIva = Val(WIva21) + Val(WIva27) + Val(WIva105)

                If WIva = 0 Then
                    WNeto = Val(WNeto) + Val(WExento)
                    WExento = 0
                End If

                ZTotal = Val(WNeto) + Val(WExento) + Val(WIva21) + Val(WIva5) + Val(WIva27) + Val(WIva105) + Val(WIb)

                WCodigoExento = " "

                If WIva = 0 Then
                    WCodigoExento = "N"
                End If

                ZAlicuota = 1

                If Trim(WProveedor) <> "" Then

                    XProveedor = _TraerDatosProveedor(WProveedor)

                    If Not IsNothing(XProveedor) Then

                        With XProveedor
                            WRazon = IIf(IsDBNull(.Item("Razon")), "", .Item("Razon"))
                            WCuit = IIf(IsDBNull(.Item("Cuit")), "", .Item("Cuit"))
                        End With

                    End If

                End If

                WRazon = _Left(WRazon & Space(30), 30)

                If Val(WNeto) <> 0 Then
                    ZImpo = Val(WNeto)
                Else
                    ZImpo = CInt(Val(WIva21) / 21 * 100)
                End If
                WCampo1 = WDespacho

                WCampo2 = Str$(Math.Abs(ZImpo))
                WCampo2 = ceros(WCampo2, 15)

                WCampo3 = "0005"

                WCampo4 = Str$(Math.Abs(Val(WIva21)))
                WCampo4 = ceros(WCampo4, 15)

                escritor.Write(WCampo1 & WCampo2 & WCampo3 & WCampo4 & vbCrLf)

                ProgressBar1.Increment(1)

            Next

            escritor.Dispose()

            ' Procesamos las VENTAS CBTE.
            Array.Clear(Vector, 0, Vector.Length)
            WIndice = 0

            nombreArchivo = WDestino & "\" & "REGINFO_CV_VENTAS_CBTE" & ".txt"

            escritor = New StreamWriter(nombreArchivo)

            tabla = _TraerCtaCte(ordDesde, ordHasta)

            Dim WCLiente, WIva1, WIva2, WImpoIbTucu, WImpoIbCiudad, WImpoIb, WVencimiento, WMes, WAnio As String

            For Each WCtaCte As DataRow In tabla.Rows

                With WCtaCte
                    WTipo = IIf(IsDBNull(.Item("Tipo")), "", .Item("Tipo"))
                    WNumero = IIf(IsDBNull(.Item("Numero")), "", .Item("Numero"))
                    WFecha = IIf(IsDBNull(.Item("Fecha")), "", .Item("Fecha"))
                    WCliente = IIf(IsDBNull(.Item("Cliente")), "", .Item("Cliente"))
                    WNeto = IIf(IsDBNull(.Item("Neto")), "", .Item("Neto"))
                    WIva1 = IIf(IsDBNull(.Item("Iva1")), "", .Item("Iva1"))
                    WIva2 = IIf(IsDBNull(.Item("Iva2")), "", .Item("Iva2"))
                    WImpoIbTucu = IIf(IsDBNull(.Item("ImpoIbTucu")), "", .Item("ImpoIbTucu"))
                    WImpoIbCiudad = IIf(IsDBNull(.Item("ImpoIbCiudad")), "", .Item("ImpoIbCiudad"))
                    WImpoIb = IIf(IsDBNull(.Item("ImpoIb")), "", .Item("ImpoIb"))
                    WVencimiento = IIf(IsDBNull(.Item("Vencimiento")), "", .Item("Vencimiento"))
                    WRazon = IIf(IsDBNull(.Item("Razon")), "", .Item("Razon"))
                    WCuit = IIf(IsDBNull(.Item("Cuit")), "", .Item("Cuit"))
                End With

                WIndice += 1

                Vector(WIndice, 1) = "A"
                Vector(WIndice, 2) = WTipo
                Vector(WIndice, 3) = "0009"

                If Proceso._EsPellital() Then
                    Vector(WIndice, 3) = "0006"
                End If


                Select Case Val(WNumero)

                    Case Is < 200000
                        Vector(WIndice, 4) = Str(Val(WNumero) - 100000)

                    Case Is < 300000
                        Vector(WIndice, 1) = "A"
                        Vector(WIndice, 4) = Str(Val(WNumero) - 200000)

                    Case Is < 810000
                        Vector(WIndice, 4) = Str(Val(WNumero) - 800000)

                    Case Else
                        Vector(WIndice, 4) = Str(Val(WNumero) - 810000)

                End Select

                Vector(WIndice, 5) = Proceso.ordenaFecha(WFecha)
                Vector(WIndice, 6) = WCLiente
                Vector(WIndice, 7) = Proceso.formatonumerico(WNeto)
                Vector(WIndice, 8) = Proceso.formatonumerico(WIva1)
                Vector(WIndice, 9) = Proceso.formatonumerico(WIva2)
                Vector(WIndice, 10) = Proceso.formatonumerico(WImpoIbTucu)
                Vector(WIndice, 11) = Proceso.formatonumerico(WImpoIbCiudad)
                Vector(WIndice, 12) = Proceso.formatonumerico(WImpoIb)

                WMes = Mid$(WFecha, 4, 2)
                WAnio = Mid$(WFecha, 7, 4)

                If Val(WMes) = 12 Then
                    Vector(WIndice, 13) = WAnio & WMes & "31"
                Else
                    Vector(WIndice, 13) = WAnio & ceros((Val(WMes) + 1), 2) & "01"
                End If

                Vector(WIndice, 14) = WNumero
                Vector(WIndice, 15) = Proceso.ordenaFecha(WVencimiento)
                Vector(WIndice, 16) = WRazon
                Vector(WIndice, 17) = WCuit

            Next

            Dim WNumero2 As String

            ZTotal = 0
            WIva = 0

            For i = 1 To WIndice

                WLetra = Vector(i, 1)
                WTipo = Vector(i, 2)
                WPunto = Vector(i, 3)
                WNumero = Vector(i, 4)
                WFecha = Vector(i, 5)
                WCLiente = Vector(i, 6)
                WNeto = Vector(i, 7)
                WIva1 = Vector(i, 8)
                WIva2 = Vector(i, 9)
                WImpoIbTucu = Vector(i, 10)
                WImpoIbCiudad = Vector(i, 11)
                WImpoIb = Vector(i, 12)
                WVencimiento = Vector(i, 13)
                WNumero2 = Vector(i, 14)
                WRazon = Vector(i, 16)
                WCuit = Vector(i, 17)

                WNeto = Proceso.formatonumerico(WNeto)
                WNeto = Str$(Int(Math.Abs(Val(WNeto)) * 100))

                WIva1 = Proceso.formatonumerico(WIva1)
                WIva1 = Str$(Int(Math.Abs(Val(WIva1)) * 100))

                WIva2 = Proceso.formatonumerico(WIva2)
                WIva2 = Str$(Int(Math.Abs(Val(WIva2)) * 100))

                WImpoIbTucu = Proceso.formatonumerico(WImpoIbTucu)
                WImpoIbTucu = Str$(Int(Math.Abs(Val(WImpoIbTucu)) * 100))

                WImpoIbCiudad = Proceso.formatonumerico(WImpoIbCiudad)
                WImpoIbCiudad = Str$(Int(Math.Abs(Val(WImpoIbCiudad)) * 100))

                WImpoIb = Proceso.formatonumerico(WImpoIb)
                WImpoIb = Str$(Int(Math.Abs(Val(WImpoIb)) * 100))

                WExento = "0"

                ZTotal = Val(WNeto) + Val(WIva1) + Val(WIva2) + Val(WImpoIbTucu) + Val(WImpoIbCiudad) + Val(WImpoIb)
                WIva = Val(WIva1) + Val(WIva2)

                WCodigoExento = " "

                If WIva = 0 Then
                    WCodigoExento = "N"
                End If

                WRazon = _Left(Trim(WRazon) & Space(30), 30)
                WCuit = WCuit.Replace("-", "")

                WCampo1 = WFecha

                Select Case WLetra
                    Case "A"
                        Select Case Val(WTipo)
                            Case 1, 3
                                WCampo2 = "001"
                            Case 4
                                WCampo2 = "002"
                            Case 2, 5
                                WCampo2 = "003"
                            Case Else
                                WCampo2 = "000"
                        End Select
                    Case "B"
                        Select Case Val(WTipo)
                            Case 1, 3
                                WCampo2 = "006"
                            Case 4
                                WCampo2 = "007"
                            Case 2, 5
                                WCampo2 = "008"
                            Case Else
                                WCampo2 = "000"
                        End Select
                    Case "C"
                        Select Case Val(WTipo)
                            Case 1
                                WCampo2 = "011"
                            Case 2
                                WCampo2 = "012"
                            Case 3
                                WCampo2 = "013"
                            Case Else
                                WCampo2 = "000"
                        End Select
                    Case "M"
                        Select Case Val(WTipo)
                            Case 1
                                WCampo2 = "051"
                            Case 2
                                WCampo2 = "052"
                            Case 3
                                WCampo2 = "053"
                            Case Else
                                WCampo2 = "000"
                        End Select
                    Case Else
                        WCampo2 = "000"
                End Select

                If Val(WNumero2) > 800000 Or Val(WNumero2) > 810000 Then
                    WCampo2 = "019"
                    WPunto = "00003"
                End If

                WCampo3 = ceros(WPunto, 5)
                WCampo4 = ceros(WNumero, 20)
                WCampo5 = ceros(WNumero, 20)
                WCampo6 = "80"
                WCampo7 = ceros(WCuit, 20)
                WCampo8 = WRazon

                WCampo9 = Str$(Math.Abs(ZTotal))
                WCampo9 = ceros(WCampo9, 15)

                WCampo10 = ceros("0", 15)

                WCampo11 = ceros("0", 15)

                WCampo12 = Str$(Math.Abs(Val(WExento)))
                WCampo12 = ceros(WCampo12, 15)

                WCampo13 = ceros("0", 15)

                ZTotal = Val(WImpoIbTucu) + Val(WImpoIbCiudad) + Val(WImpoIb)

                WCampo14 = Str$(Math.Abs(ZTotal))
                WCampo14 = ceros(WCampo14, 15)

                WCampo15 = ceros("0", 15)
                WCampo16 = ceros("0", 15)

                WCampo17 = "PES"

                WCampo18 = ceros("1000000", 10)

                WCampo19 = "1"

                WCampo20 = WCodigoExento

                WCampo21 = ceros("0", 15)

                WCampo22 = WVencimiento

                If Val(WCampo2) = 19 Then
                    WCampo22 = ceros("0", 8)
                End If

                escritor.Write(WCampo1 & WCampo2 & WCampo3 & WCampo4 & WCampo5 & WCampo6 & WCampo7 & WCampo8 & WCampo9 & WCampo10 & _
                               WCampo11 & WCampo12 & WCampo13 & WCampo14 & WCampo15 & WCampo16 & WCampo17 & WCampo18 & WCampo19 & _
                               WCampo20 & WCampo21 & WCampo22 & vbCrLf)

                ProgressBar1.Increment(1)

            Next

            escritor.Dispose()

            ' Procesamos las Alicuotas de Ventas CBTE.

            nombreArchivo = WDestino & "\" & "REGINFO_CV_VENTAS_ALICUOTAS" & ".txt"

            escritor = New StreamWriter(nombreArchivo)

            For i = 1 To WIndice


                WLetra = Vector(i, 1)
                WTipo = Vector(i, 2)
                WPunto = Vector(i, 3)
                WNumero = Vector(i, 4)
                WFecha = Vector(i, 5)
                WCLiente = Vector(i, 6)
                WNeto = Vector(i, 7)
                WIva1 = Vector(i, 8)
                WIva2 = Vector(i, 9)
                WImpoIbTucu = Vector(i, 10)
                WImpoIbCiudad = Vector(i, 11)
                WImpoIb = Vector(i, 12)
                WVencimiento = Vector(i, 13)
                WNumero2 = Vector(i, 14)
                WRazon = Vector(i, 16)
                WCuit = Vector(i, 17)

                WNeto = Proceso.formatonumerico(WNeto)
                WNeto = Str$(Int(Math.Abs(Val(WNeto)) * 100))

                WIva1 = Proceso.formatonumerico(WIva1)
                WIva1 = Str$(Int(Math.Abs(Val(WIva1)) * 100))

                WIva2 = Proceso.formatonumerico(WIva2)
                WIva2 = Str$(Int(Math.Abs(Val(WIva2)) * 100))

                WImpoIbTucu = Proceso.formatonumerico(WImpoIbTucu)
                WImpoIbTucu = Str$(Int(Math.Abs(Val(WImpoIbTucu)) * 100))

                WImpoIbCiudad = Proceso.formatonumerico(WImpoIbCiudad)
                WImpoIbCiudad = Str$(Int(Math.Abs(Val(WImpoIbCiudad)) * 100))

                WImpoIb = Proceso.formatonumerico(WImpoIb)
                WImpoIb = Str$(Int(Math.Abs(Val(WImpoIb)) * 100))

                WExento = "0"

                ZTotal = Val(WNeto) + Val(WIva1) + Val(WIva2) + Val(WImpoIbTucu) + Val(WImpoIbCiudad) + Val(WImpoIb)
                WIva = Val(WIva1) + Val(WIva2)

                WCodigoExento = " "

                If WIva = 0 Then
                    WCodigoExento = "N"
                End If

                WRazon = _Left(Trim(WRazon) & Space(30), 30)
                WCuit = WCuit.Replace("-", "")

                Select Case UCase(WLetra)
                    Case "A"
                        Select Case Val(WTipo)
                            Case 1, 3
                                WCampo1 = "001"
                            Case 4
                                WCampo1 = "002"
                            Case 2, 5
                                WCampo1 = "003"
                            Case Else
                                WCampo1 = "000"
                        End Select
                    Case "B"
                        Select Case Val(WTipo)
                            Case 1, 3
                                WCampo1 = "006"
                            Case 4
                                WCampo1 = "007"
                            Case 2, 5
                                WCampo1 = "008"
                            Case Else
                                WCampo1 = "000"
                        End Select
                    Case "C"
                        Select Case Val(WTipo)
                            Case 1
                                WCampo1 = "011"
                            Case 2
                                WCampo1 = "012"
                            Case 3
                                WCampo1 = "013"
                            Case Else
                                WCampo1 = "000"
                        End Select
                    Case "M"
                        Select Case Val(WTipo)
                            Case 1
                                WCampo1 = "051"
                            Case 2
                                WCampo1 = "052"
                            Case 3
                                WCampo1 = "053"
                            Case Else
                                WCampo1 = "000"
                        End Select
                    Case Else
                        WCampo1 = "000"
                End Select

                If Val(WNumero2) > 800000 Or Val(WNumero2) > 810000 Then
                    WCampo1 = "019"
                    WPunto = "00003"
                End If

                WCampo2 = ceros(WPunto, 5)
                WCampo3 = ceros(WNumero, 20)

                WCampo4 = Str$(Math.Abs(Val(WNeto)))
                WCampo4 = ceros(WCampo4, 15)

                WCampo5 = "0005"

                If WIva = 0 Then WCampo5 = "0003"

                WCampo6 = Str$(Math.Abs(WIva))
                WCampo6 = ceros(WCampo6, 15)

                escritor.Write(WCampo1 & WCampo2 & WCampo3 & WCampo4 & WCampo5 & WCampo6 & vbCrLf)

                ProgressBar1.Increment(1)

            Next

            escritor.Dispose()

            GroupBox1.Visible = False

            MsgBox("Finalizado Proceso CITI", MsgBoxStyle.Information)

        Catch ex As Exception

            If Not IsNothing(escritor) Then
                ' ReSharper disable once VBWarnings::BC42104
                escritor.Dispose()
            End If
            If Not IsNothing(escritor2) Then
                ' ReSharper disable once VBWarnings::BC42104
                escritor2.Dispose()
            End If

            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
            Exit Sub
        End Try
    End Sub

    Private Function _TraerCtaCte(ByVal WDesde As String, ByVal WHasta As String) As DataTable
        Dim tabla As New DataTable

        Dim cn = New SqlConnection()
        Dim cm = New SqlCommand("SELECT c.Tipo, c.Numero, c.Fecha, c.Cliente, c.Neto, c.Iva1, c.Iva2, c.ImpoIbTucu, c.ImpoIbCiudad, c.ImpoIb, c.Vencimiento, " & _
                                              " cli.Razon, cli.Cuit" & _
                                              " FROM CtaCte as c JOIN Cliente as cli ON cli.Cliente = c.Cliente " & _
                                              " WHERE c.OrdFecha BETWEEN " & WDesde & " AND " & WHasta & "" & _
                                              " AND (c.Tipo IN('01','02','03','04','05') OR c.Tipo IN('1','2','3','4','5'))")
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
            Throw New Exception("Hubo un problema al querer consultar los datos de las Cuentas Corrientes desde la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

        Return tabla
    End Function

    Private Function _TraerDatosProveedor(ByVal wProveedor As String) As DataRow
        Dim tabla As New DataTable

        Dim cn = New SqlConnection()
        Dim cm = New SqlCommand("SELECT Nombre as Razon, Cuit" & _
                                              " FROM Proveedor" & _
                                              " WHERE Proveedor = '" & wProveedor & "'")
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
            Throw New Exception("Hubo un problema al querer consultar los datos en IvaCompAdicional desde la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

        If tabla.Rows.Count > 0 Then
            Return tabla.Rows(0)
        Else
            Return Nothing
        End If
    End Function

    Private Function _TraerDatosIvaCompAdicional(ByVal wNroInterno As String) As DataTable
        Dim tabla As New DataTable

        Dim cn = New SqlConnection()
        Dim cm = New SqlCommand("SELECT Letra, Tipo, Punto, Numero, fecha, Neto, Exento, Iva21, Iva27, Iva105, PerceIb, PerceIva, Razon, Cuit" & _
                                              " FROM IvaCompAdicional" & _
                                              " WHERE NroInterno = '" & wNroInterno & "' ORDER BY Renglon")
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
            Throw New Exception("Hubo un problema al querer consultar los datos en IvaCompAdicional desde la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

        Return tabla
    End Function

    Private Function _TraerComprasCBTE() As DataTable

        Dim tabla As New DataTable

        Dim cn = New SqlConnection()
        Dim cm = New SqlCommand("SELECT Letra, Tipo, Punto, Numero, fecha, Proveedor, Neto, Periodo, Exento, Iva5, Iva21, Iva27, Iva105, Ib, Despacho, NroInterno" & _
                                              " FROM IvaComp" & _
                                              " WHERE Letra IN('A', 'B', 'C', 'M') AND Tipo IN('01', '02', '03')")
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
            Throw New Exception("Hubo un problema al querer consultar las Facturas desde la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
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

    Private Sub ProcesoPercepciones_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        txtDesde.Focus()
    End Sub

    Private Sub txtNombre_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNombre.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txtNombre.Text) = "" Then : Exit Sub : End If

            txtDesde.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtNombre.Text = ""
        End If

    End Sub
End Class