Module Proceso

    Public Function ordenaFecha(ByVal fecha As String)

        Dim txtOrdenaFecha As String

        txtOrdenaFecha = Right$(fecha, 4) + Mid$(fecha, 4, 2) + Left$(fecha, 2)
        Return txtOrdenaFecha

    End Function


    Public Function leederecha(ByVal leederechaII As String, ByVal largoderecha As Integer)

        Dim txtleederecha As String

        Dim subString As String = Microsoft.VisualBasic.Left(leederechaII, largoderecha)
        txtleederecha = subString

        Return txtleederecha

    End Function

    Public Function leeizquierda(ByVal leeizquierdaII As String, ByVal largoizquierda As Integer)

        Dim txtleeizquierda As String

        Dim subString As String = Right(leeizquierdaII, largoizquierda)
        txtleeizquierda = subString

        Return txtleeizquierda

    End Function

    Public Function redondeo(ByVal redondeoii As Double)

        Dim txtredondeo As Double

        Dim B As Double
        Dim B1 As Double
        Dim Valor As Double
        Dim ZZRedondeo As Double
        Dim ZZRedondeo1 As Double
        Dim Dife As Double

        B = redondeoii * 100
        B1 = redondeoii * 10000
        Valor = Int(B)
        ZZRedondeo = Int(B1)
        zzRedondeo1 = Int(B) * 100
        Dife = ZZRedondeo - ZZRedondeo1
        If Dife >= 50 Then Valor = Valor + 1
        txtredondeo = Valor / 100

        Return txtredondeo

    End Function



    Public Function ceros(ByVal campoii As String, ByVal largoii As Integer)

        Dim txtCampo As String
        Dim Variable As Integer
        Dim Cadena As String

        Variable = 1
        Cadena = ""

        While Variable <= Len(campoii) And Variable > 0

            If Mid$(campoii, Variable, 1) <> Space(1) Then
                Cadena$ = Cadena$ + Mid$(campoii, Variable, 1)
            End If
            Variable = Variable + 1

        End While

        txtCampo = Right$("000000000000000000000000000000000000000000000000000000000" + Cadena$, largoii)

        Return txtCampo

    End Function


    Public Function agregaespacios(ByVal Campo As String, ByVal largo As String)

        Dim txtCampoespacio As String

        Campo = LTrim(RTrim(Campo)) + Space(100)
        txtCampoespacio = leederecha(Campo, largo)

        Return txtCampoespacio

    End Function


    Public Function formatonumerico(ByVal valor As Double, ByVal formato As String, ByVal formatoII As String)

        Dim txtnumero As String

        txtnumero = Format(valor, formato)
        If formatoII = "." Then
            txtnumero = txtnumero.Replace(",", ".")
        End If

        Return txtnumero

    End Function


    Public Function sacaguiones(ByVal Campo As String)

        Dim txtcuit As String
        Dim Largo As Integer

        Largo = Len(Campo)
        txtcuit = ""

        For XX = 1 To Largo

            If Mid$(Campo, XX, 1) >= "0" And Mid$(Campo, XX, 1) <= "9" Then
                txtcuit = txtcuit + Mid$(Campo, XX, 1)
            End If

        Next

        Return txtcuit

    End Function



    Public Function CodigoSifere(ByVal Cuenta As String)

        Dim txtCodigo As String

        txtCodigo = ""
        Select Case Val(Cuenta)
            Case 163
                txtCodigo = "901"
            Case 164
                txtCodigo = "902"
            Case 165
                txtCodigo = "919"
            Case 166
                txtCodigo = "921"
            Case 167
                txtCodigo = "912"
            Case 168
                txtCodigo = "924"
            Case 169
                txtCodigo = "923"
            Case 170
                txtCodigo = "907"
            Case 171
                txtCodigo = "908"
            Case 172
                txtCodigo = "918"
            Case 173
                txtCodigo = "905"
            Case 174
                txtCodigo = "903"
            Case 176
                txtCodigo = "906"
            Case 177
                txtCodigo = "904"
            Case Else
                txtCodigo = ""
        End Select

        Return txtCodigo

    End Function

    Public Function ProveedorAduana(ByVal Proveedor As String)

        Dim txtAduana As String

        If Proveedor = "10069345023" Or Proveedor = "10014123562" Or Proveedor = "10022098824" Then
            txtAduana = "S"
        Else
            txtAduana = "N"
        End If

        Return txtAduana

    End Function

    Public Function ValidaFecha(ByVal fecha As String)

        Dim txtDia As Integer
        Dim txtMes As Integer
        Dim txtAno As Integer
        Dim txtValidaFecha As String

        txtDia = Val(leederecha(fecha, 2))
        txtMes = Val(Mid$(fecha, 4, 2))
        txtAno = Val(Right$(fecha, 4))

        txtValidaFecha = "S"

        If txtDia <= 0 Or txtDia > 31 Then
            txtValidaFecha = "N"
        End If

        If txtMes <= 0 Or txtMes > 12 Then
            txtValidaFecha = "N"
        End If

        If txtAno <= 1900 Then
            txtValidaFecha = "N"
        End If

        Return txtValidaFecha

    End Function



    Public Function CaculoRetencionGanancia(ByVal varTipoprv As Integer, ByVal varAcumulaNeto As Double, ByVal varAcuNeto As Double, ByVal varAcuRetenido As Double, ByVal varAcuAnticipo As Double,
                                        ByVal varAcuBruto As Double, ByVal varAcuIva As Double)

        Dim varRetencion, varBase As Double
        Dim varMinimo As Double
        Dim varAcumuladPago As Double
        Dim varAuxi, varTasa, varTope, varTope1, varSum As Double
        Dim varParametro(100) As Double
        Dim varTasa1(100) As Double

        varParametro(0) = 0
        varParametro(1) = 2000
        varParametro(2) = 4000
        varParametro(3) = 8000
        varParametro(4) = 14000
        varParametro(5) = 24000
        varParametro(6) = 1000000

        varTasa1(1) = 0.1
        varTasa1(2) = 0.14
        varTasa1(3) = 0.18
        varTasa1(4) = 0.22
        varTasa1(5) = 0.26
        varTasa1(6) = 0.26

        varRetencion = 0

        If varTipoprv = 1 Or varTipoprv = 2 Or varTipoprv = 3 Or varTipoprv = 6 Or varTipoprv = 7 Then

            varBase = varAcumulaNeto

            Select Case varTipoprv
                Case 1
                    varMinimo = 12000
                Case 2
                    varMinimo = 1200
                Case 3
                    varMinimo = 1200
                Case 6
                    varMinimo = 5000
                Case 7
                    varMinimo = 6500
                Case Else
            End Select

            varAcumuladPago = varAcumulaNeto + varBase
            varAuxi = varAcumuladPago - varMinimo

            If varAuxi <= 0 Then
                varAuxi = 0
                varRetencion = 0
            End If

            varTasa = 0.02
            If varTipoprv = 1 Then
                varTasa = 0.02
            End If
            If varTipoprv = 3 Then
                varTasa = 0.06
            End If
            If varTipoprv = 7 Then
                varTasa = 0.0025
            End If

            Select Case varTipoprv
                Case 2
                    varRetencion = 0
                    varTope = 0
                    varTope1 = 0

                    For da = 0 To 5
                        If varAuxi >= varParametro(da) And varAuxi < varParametro(da + 1) Then
                            varTope1 = varAuxi
                            varTope = varParametro(da)
                            varSum = varTope1 - varTope
                            varSum = varSum * varTasa1(da + 1)
                            varRetencion = varRetencion + varSum
                        End If
                        If varAuxi >= varParametro(da + 1) Then
                            varTope1 = varParametro(da + 1)
                            varTope = varParametro(da)
                            varSum = varTope1 - varTope
                            varSum = varSum * varTasa1(da + 1)
                            varRetencion = varRetencion + varSum
                        End If
                    Next da

                Case Else
                    varRetencion = varAuxi * varTasa

            End Select

            varRetencion = varRetencion - varAcuRetenido

            If varRetencion < 20 Then
                varRetencion = 0
            Else
                If varRetencion > varAcumulaNeto Then
                    varRetencion = 0
                End If
            End If

            redondeo(varRetencion)

        End If

        Return varRetencion

    End Function

    Public Function CaculoRetencionIngresosBrutos(ByVal varTipoIb As Integer, ByVal varPorceIb As Double, ByVal varAcumulaNeto As Double)

        Dim varRete As Double
        Dim varAcumulaIb As Double
        Dim varRetIb As Double

        varRetIb = 0

        If varTipoIb = 0 Or varTipoIb = 1 Then
            varRete = varAcumulaNeto * (varPorceIb / 100)
            varAcumulaIb = varAcumulaIb + redondeo(varRete)
            varRetIb = redondeo(varAcumulaIb)
        End If

        Return varRetIb

    End Function


    Public Function CaculoRetencionIngresosBrutosCaba(ByVal varTipoIbCaba As Integer, ByVal varPorceIbCaba As Double, ByVal varAcumulaNeto As Double)

        Dim varRete As Double
        Dim varRetIbCaba As Double
        Dim varAcumulaIb As Double

        varRetIbCaba = 0

        If varTipoIbCaba = 3 Or varTipoIbCaba = 4 Or varPorceIbCaba <> 0 Then
            If varTipoIbCaba <> 2 Then
                If varAcumulaNeto >= 300 Then
                    If varPorceIbCaba <> 0 Then
                        varRete = varAcumulaNeto * (varPorceIbCaba / 100)
                    Else
                        If varTipoIbCaba = 3 Then
                            varRete = varAcumulaNeto * (3 / 100)
                        Else
                            varRete = varAcumulaNeto * (4.5 / 100)
                        End If
                    End If
                End If
                varAcumulaIb = varAcumulaIb + redondeo(varRete)
                varRetIbcaba = varAcumulaIb
            End If
        End If

        Return varRetIbCaba

    End Function



End Module
