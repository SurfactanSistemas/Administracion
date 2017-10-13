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




End Module
