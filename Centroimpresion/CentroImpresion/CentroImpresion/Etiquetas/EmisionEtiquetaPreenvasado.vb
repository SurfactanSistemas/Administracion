Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class EmisionEtiquetaPreenvasado

    Private WPorLineaCmd As Boolean = False
    Private WImpresora As String = ""
    Private WIDEtiq As Integer = 0

    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Sub New(ByVal Lote As String, ByVal CantEti As String, ByVal CantXEnv As String, ByVal Impresora As String, Optional ByVal PorLineaCmd As Boolean = False, Optional ByVal IDEtiq As String = "")

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        WPorLineaCmd = PorLineaCmd
        txtLote.Text = Lote
        txtCantEtiq.Text = CantEti
        txtCantidadPorEnvase.Text = CantXEnv
        WImpresora = Impresora
        WIDEtiq = Val(IDEtiq)

    End Sub

    Private Sub EmisionEtiquetaPreenvasado_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        If WPorLineaCmd Then
            btnEmitir_Click(Nothing, Nothing)
            Close()
        Else
            btnLimpiar_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnLimpiar.Click
        For Each c As Control In {txtLote, txtCantEtiq, txtCantidadPorEnvase, txtDescTerminado, txtTerminado}
            c.Text = ""
        Next

        txtLote.Focus()

    End Sub

    Private Sub btnCerrar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCerrar.Click
        Close()
    End Sub

    Public Sub btnEmitir_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnEmitir.Click

        If Val(txtCantEtiq.Text) = 0 Then txtCantEtiq.Text = "1"

        If Val(txtCantidadPorEnvase.Text) = 0 And Not WPorLineaCmd Then
            MsgBox("Debe indicar la cantidad de Kgs por envase.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        txtLote_KeyDown(Nothing, New KeyEventArgs(Keys.Enter))

        'Dim WEtiqueta As DataTable = New DBAuxi.EtiquetaDataTable

        'Dim WTer As DataRow = GetSingle("SELECT Descripcion FROM Terminado WHERE Codigo = '" & txtTerminado.Text & "'")
        'Dim WDescTerminado As String = ""
        'If WTer IsNot Nothing Then
        '    WDescTerminado = Trim(OrDefault(WTer.Item("Descripcion"), ""))
        'End If

        'For i = 1 To Val(txtCantEtiq.Text)
        '    Dim r As DataRow = WEtiqueta.NewRow

        '    With r
        '        .Item("Codigo") = i
        '        .Item("Terminado") = txtTerminado.Text
        '        .Item("Lote") = txtLote.Text
        '        .Item("Cantidad") = Val(formatonumerico(txtCantidadPorEnvase.Text))
        '        .Item("Nombre") = WDescTerminado
        '        .Item("CodBarra") = "*" & txtLote.Text.PadLeft(6, "0") & txtTerminado.Text & "*"
        '    End With

        '    WEtiqueta.Rows.Add(r)
        'Next

        'Dim rpt As New EtiPreenvasadoGral

        'rpt.SetDataSource(WEtiqueta)

        ''With New VistaPreviaDS(WEtiqueta)
        ''    .Show()
        ''End With

        'If Not WPorLineaCmd Then WImpresora = ""

        'With New VistaPrevia(WImpresora)
        '    .Reporte = rpt
        '    .Imprimir()
        'End With

        If Val(txtCantEtiq.Text) = 0 Then txtCantEtiq.Text = "1"
        If Val(txtCantidadPorEnvase.Text) = 0 Then txtCantidadPorEnvase.Text = "1"
        
        Dim WTipoPro = "PT"
        Dim Auxi As String = Mid(txtTerminado.Text, 4, 5)

        If Not txtTerminado.Text.StartsWith("PT") Then
            Select Case Helper.Left(txtTerminado.Text, 2)
                Case "DY", "DS"
                    WTipoPro = "CO"
                Case "QC", "YF"
                    WTipoPro = "FA"
                Case "YQ", "YH", "YP"
                    WTipoPro = "PT"
            End Select
        Else
            If (Val(Auxi) > 0 And Val(Auxi) < 999) Or (Val(Auxi) > 11000 And Val(Auxi) < 12999) Then
                WTipoPro = "CO"
            ElseIf Val(Auxi) > 25000 And Val(Auxi) < 25999 Then
                WTipoPro = "FA"
            ElseIf Val(Auxi) > 2300 And Val(Auxi) < 2399 Then
                WTipoPro = "BI"
            End If
        End If

        '
        ' Calculamos las Fechas de Elaboración y Vencimiento del Mono Componente.
        '
        Dim WTara As Double = 0 'Val(formatonumerico(txtTara.Text))
        Dim WNeto As Double = Val(formatonumerico(txtCantidadPorEnvase.Text))
        Dim WBruto As Double = 0

        If WTara = 0 Then
            If WTipoPro = "FA" Then WBruto = WNeto
        Else
            WBruto = WTara + WNeto
        End If

        Dim WLugarImpreI, WLugarImpreII, WLugarImpreIII As Integer
        Dim WImpreI(999), WImpreII(999), WImpreIII(999), WPalabra, WLogo(9) As String

        WLugarImpreI = 0
        WLugarImpreII = 0
        WLugarImpreIII = 0

        For i = 0 To 999
            WImpreI(i) = ""
            WImpreII(i) = ""
            WImpreIII(i) = ""
        Next

        For i = 0 To 9
            WLogo(i) = ""
        Next

        '
        ' Comprobamos que se hayan cargado los datos de Peligrosidad.
        '
        Dim WClaveProd = ""

        WClaveProd = Helper.Left(txtTerminado.Text, 2).ToUpper()

        If WClaveProd.StartsWith("Y") Then
            WClaveProd = Helper.Left(txtTerminado.Text, 2)
        ElseIf WClaveProd <> "SE" Then
            WClaveProd = "PT"
        End If

        For i = 1 To 999
            Dim WDatosEtiquetas As DataTable = GetAll("SELECT Palabra, Tipo, Pictograma1, Pictograma2, Pictograma3, Pictograma4, Pictograma5, Pictograma6, Pictograma7, Pictograma8, Pictograma9, " _
                                                      & " Descripcion1h, Descripcion2h, Descripcion3h, Descripcion1p, Descripcion2p, Descripcion3p, Observaciones, Denominacion FROM DatosEtiqueta WHERE Clave = '" & WClaveProd & Mid(txtTerminado.Text, 3, 10) & i.ToString.PadLeft(3, "0") & "'")

            For Each row As DataRow In WDatosEtiquetas.Rows
                With row
                    WPalabra = OrDefault(.Item("Palabra"), "")

                    For x = 1 To 9
                        WLogo(x) = OrDefault(.Item("Pictograma" & x), "0")
                    Next

                    Dim WTipo As Integer = OrDefault(.Item("Tipo"), 0)


                    Select Case WTipo
                        Case 1

                            Dim WImpreAuxi As String = OrDefault(.Item("Descripcion1h"), "")

                            If WImpreAuxi <> "" Then
                                WLugarImpreI += 1
                                WImpreI(WLugarImpreI) = Trim(WImpreAuxi)
                            End If

                            WImpreAuxi = OrDefault(.Item("Descripcion2h"), "")

                            If WImpreAuxi <> "" Then
                                WLugarImpreI += 1
                                WImpreI(WLugarImpreI) = Trim(WImpreAuxi)
                            End If

                            WImpreAuxi = OrDefault(.Item("Descripcion3h"), "")

                            If WImpreAuxi <> "" Then
                                WLugarImpreI += 1
                                WImpreI(WLugarImpreI) = Trim(WImpreAuxi)
                            End If

                        Case 2

                            Dim WImpreAuxi As String = OrDefault(.Item("Descripcion1p"), "")

                            If WImpreAuxi <> "" Then
                                WLugarImpreII += 1
                                WImpreII(WLugarImpreII) = Trim(WImpreAuxi)
                            End If

                            WImpreAuxi = OrDefault(.Item("Descripcion2p"), "")

                            If WImpreAuxi <> "" Then
                                WLugarImpreII += 1
                                WImpreII(WLugarImpreII) = Trim(WImpreAuxi)
                            End If

                            WImpreAuxi = OrDefault(.Item("Descripcion3p"), "")

                            If WImpreAuxi <> "" Then
                                WLugarImpreII += 1
                                WImpreII(WLugarImpreII) = Trim(WImpreAuxi)
                            End If

                            WImpreAuxi = OrDefault(.Item("Observaciones"), "")

                            If WImpreAuxi <> "" Then
                                WLugarImpreII += 1
                                WImpreII(WLugarImpreII) = Trim(WImpreAuxi)
                            End If

                        Case 3

                            Dim WImpreAuxi As String = OrDefault(.Item("Denominacion"), "")

                            If WImpreAuxi <> "" Then
                                WLugarImpreIII += 1
                                WImpreIII(WLugarImpreIII) = Trim(WImpreAuxi)
                            End If

                    End Select

                End With
            Next

            If WDatosEtiquetas.Rows.Count = 0 Then Exit For

        Next

        '
        ' Formateo las Frases. (Se copia exactamente como se encontraba en el sistema viejo.
        '
        Dim ZZImpreFrase(99) As String
        Dim LugarFrase = 1
        Dim ZZCorte As Integer = 115
        Dim ZZHastaII, ZZHastaIII As Integer

        If WTipoPro <> "CO" Then
            ZZCorte = 185
        End If

        Dim ZZEntraVarios As String = "N"

        For Ciclo = 1 To 99

            If Trim(WImpreIII(Ciclo)) <> "" Then

                ZZEntraVarios = "S"
                ZZImpreFrase(LugarFrase) = ZZImpreFrase(LugarFrase) + Trim(WImpreIII(Ciclo)) + " "

                If Len(ZZImpreFrase(LugarFrase)) > ZZCorte Then

                    Do

                        ZZHastaIII = Len(ZZImpreFrase(LugarFrase))

                        ZZHastaII = Len(ZZImpreFrase(LugarFrase))
                        For Da = 1 To ZZHastaIII
                            If Asc(Mid$(ZZImpreFrase(LugarFrase), Da, 1)) >= 65 And Asc(Mid$(ZZImpreFrase(LugarFrase), Da, 1)) <= 90 Then
                                ZZHastaII = ZZHastaII + 0.5
                            End If
                        Next Da

                        If ZZHastaII > ZZCorte Then

                            For Da = ZZHastaIII - 1 To 1 Step -1
                                If Mid$(ZZImpreFrase(LugarFrase), Da, 1) = Space$(1) Or Mid$(ZZImpreFrase(LugarFrase), Da, 1) = "-" Or Mid$(ZZImpreFrase(LugarFrase), Da, 1) = "+" Or Mid$(ZZImpreFrase(LugarFrase), Da, 1) = "," Or Mid$(ZZImpreFrase(LugarFrase), Da, 1) = "/" Then

                                    Auxi = Mid$(ZZImpreFrase(LugarFrase), 1, Da)
                                    ZZHastaIII = Len(Auxi)
                                    ZZHastaII = 0
                                    For DaIII = 1 To ZZHastaIII
                                        ZZHastaII = ZZHastaII + 1
                                        If Asc(Mid$(Auxi, DaIII, 1)) >= 65 And Asc(Mid$(Auxi, DaIII, 1)) <= 90 Then
                                            ZZHastaII = ZZHastaII + 0.5
                                        End If
                                    Next DaIII
                                    If ZZHastaII <= ZZCorte Then
                                        Auxi = ZZImpreFrase(LugarFrase)
                                        ZZImpreFrase(LugarFrase) = Mid$(ZZImpreFrase(LugarFrase), 1, Da)
                                        LugarFrase = LugarFrase + 1
                                        ZZImpreFrase(LugarFrase) = ZZImpreFrase(LugarFrase) + Mid$(Auxi, Da + 1, ZZCorte)
                                        Exit For
                                    End If

                                End If
                            Next Da

                        Else

                            Exit Do

                        End If
                    Loop

                End If
            End If

        Next Ciclo

        If ZZEntraVarios = "S" Then
            LugarFrase = LugarFrase + 1
        End If

        '
        ' Formateo las Frases H. Se copia exactamente como se encontraba en el sistema viejo.
        '
        Dim ZZEntraH As String = "N"

        For Ciclo = 1 To 99

            If Trim(WImpreI(Ciclo)) <> "" Then

                If ZZEntraH = "N" Then
                    ZZImpreFrase(LugarFrase) = "INDICACIONES DE PELIGRO : "
                End If
                ZZEntraH = "S"
                ZZImpreFrase(LugarFrase) = ZZImpreFrase(LugarFrase) + Trim(WImpreI(Ciclo)) + " "

                Do

                    ZZHastaIII = Len(ZZImpreFrase(LugarFrase))

                    ZZHastaII = Len(ZZImpreFrase(LugarFrase))
                    For Da = 1 To ZZHastaIII
                        If Asc(Mid$(ZZImpreFrase(LugarFrase), Da, 1)) >= 65 And Asc(Mid$(ZZImpreFrase(LugarFrase), Da, 1)) <= 90 Then
                            ZZHastaII = ZZHastaII + 0.5
                        End If
                    Next Da

                    If ZZHastaII > ZZCorte Then

                        For Da = ZZHastaIII - 1 To 1 Step -1
                            If Mid$(ZZImpreFrase(LugarFrase), Da, 1) = Space$(1) Or Mid$(ZZImpreFrase(LugarFrase), Da, 1) = "-" Or Mid$(ZZImpreFrase(LugarFrase), Da, 1) = "+" Or Mid$(ZZImpreFrase(LugarFrase), Da, 1) = "," Or Mid$(ZZImpreFrase(LugarFrase), Da, 1) = "/" Then

                                Auxi = Mid$(ZZImpreFrase(LugarFrase), 1, Da)
                                ZZHastaIII = Len(Auxi)
                                ZZHastaII = 0
                                For DaIII = 1 To ZZHastaIII
                                    ZZHastaII = ZZHastaII + 1
                                    If Asc(Mid$(Auxi, DaIII, 1)) >= 65 And Asc(Mid$(Auxi, DaIII, 1)) <= 90 Then
                                        ZZHastaII = ZZHastaII + 0.5
                                    End If
                                Next DaIII
                                If ZZHastaII <= ZZCorte Then
                                    Auxi = ZZImpreFrase(LugarFrase)
                                    ZZImpreFrase(LugarFrase) = Mid$(ZZImpreFrase(LugarFrase), 1, Da)
                                    LugarFrase = LugarFrase + 1
                                    ZZImpreFrase(LugarFrase) = ZZImpreFrase(LugarFrase) + Mid$(Auxi, Da + 1, ZZCorte)
                                    Exit For
                                End If

                            End If
                        Next Da

                    Else

                        Exit Do

                    End If
                Loop
            End If

        Next Ciclo

        If ZZEntraH = "S" Then
            LugarFrase = LugarFrase + 1
        End If

        '
        ' Formateo las frases P. Se copia exactamente como se encontraba en el sistema viejo.
        '
        Dim ZZEntraP As String = "N"

        For Ciclo = 1 To 99

            If Trim(WImpreII(Ciclo)) <> "" Then

                If ZZEntraP = "N" Then
                    ZZImpreFrase(LugarFrase) = "DECLARACIONES DE PRUDENCIA : "
                End If

                ZZEntraP = "S"
                ZZImpreFrase(LugarFrase) = ZZImpreFrase(LugarFrase) + Trim(WImpreII(Ciclo)) + " "

                Do

                    ZZHastaIII = Len(ZZImpreFrase(LugarFrase))

                    ZZHastaII = Len(ZZImpreFrase(LugarFrase))
                    For Da = 1 To ZZHastaIII
                        If Asc(Mid$(ZZImpreFrase(LugarFrase), Da, 1)) >= 65 And Asc(Mid$(ZZImpreFrase(LugarFrase), Da, 1)) <= 90 Then
                            ZZHastaII = ZZHastaII + 0.5
                        End If
                    Next Da

                    If ZZHastaII > ZZCorte Then

                        For Da = ZZHastaIII - 1 To 1 Step -1
                            If Mid$(ZZImpreFrase(LugarFrase), Da, 1) = Space$(1) Or Mid$(ZZImpreFrase(LugarFrase), Da, 1) = "-" Or Mid$(ZZImpreFrase(LugarFrase), Da, 1) = "+" Or Mid$(ZZImpreFrase(LugarFrase), Da, 1) = "," Or Mid$(ZZImpreFrase(LugarFrase), Da, 1) = "/" Then

                                Auxi = Mid$(ZZImpreFrase(LugarFrase), 1, Da)
                                ZZHastaIII = Len(Auxi)
                                ZZHastaII = 0
                                For DaIII = 1 To ZZHastaIII
                                    ZZHastaII = ZZHastaII + 1
                                    If Asc(Mid$(Auxi, DaIII, 1)) >= 65 And Asc(Mid$(Auxi, DaIII, 1)) <= 90 Then
                                        ZZHastaII = ZZHastaII + 0.5
                                    End If
                                Next DaIII
                                If ZZHastaII <= ZZCorte Then
                                    Auxi = ZZImpreFrase(LugarFrase)
                                    ZZImpreFrase(LugarFrase) = Mid$(ZZImpreFrase(LugarFrase), 1, Da)
                                    LugarFrase = LugarFrase + 1
                                    ZZImpreFrase(LugarFrase) = ZZImpreFrase(LugarFrase) + Mid$(Auxi, Da + 1, ZZCorte)
                                    Exit For
                                End If

                            End If
                        Next Da

                    Else

                        Exit Do

                    End If
                Loop
            End If

        Next Ciclo

        '
        ' YA TERMINADO PROCESAMIENTO DE DATOS PARA LAS ETIQUETAS, SIGO CON LA GRABACIÓN DE LOS DATOS EN LAS TABLAS TEMPORALES PARA LA IMPRESION DE ETIQUETAS.
        '

        '
        ' Grabamos los datos en EtiquetaII.
        '
        Dim WEtiquetaII As DataTable = New DBAuxi.EtiquetaDataTable

        For i = 1 To Val(txtCantEtiq.Text)

            Dim _r As DataRow = WEtiquetaII.NewRow

            With _r

                .Item("Codigo") = i
                .Item("Terminado") = txtTerminado.Text
                .Item("Lote") = txtLote.Text
                .Item("Cliente") = ""
                .Item("Cantidad") = Val(formatonumerico(txtCantidadPorEnvase.Text))
                .Item("Nombre") = "" 'IIf(WNombreLargo = "", WNombreI, "")
                .Item("NombreII") = "" 'IIf(WNombreLargo = "", WNombreII, "")
                .Item("NombreIII") = "" 'IIf(WNombreLargo = "", WNombreIII, "")
                .Item("Impre2") = ""
                .Item("ImpreDirEntrega") = ""

                .Item("Razon") = "" 'WRazonI
                .Item("RazonII") = "" 'WRazonII
                .Item("RazonIII") = "" 'WRazonIII
                .Item("Clase") = "" 'WClase
                .Item("Intervencion") = "" 'WIntervencion
                .Item("DescriOnu") = "" 'WDescriOnu
                .Item("Naciones") = "" 'WNaciones
                .Item("Embalaje") = "" 'WEmbalaje
                .Item("Bruto") = WBruto
                .Item("Tara") = WTara
                .Item("Neto") = WNeto
                .Item("Observaciones") = "" 'WObservaciones
                .Item("Elaboracion") = "" 'Helper.Right(WElaboracion, 7)
                .Item("Vencimiento") = "" 'Helper.Right(WVencimiento, 7)

                .Item("ConservacionII") = ""

                .Item("Conservacion") = ""

                .Item("NombreFarmaII") = "" 'WDescripcionFarma

                .Item("Impre1") = Mid(txtTerminado.Text, 4, 5) & Helper.Right(txtTerminado.Text, 3) & ""
                .Item("NombreFarmaI") = txtLote.Text.PadLeft(6, "0")

                .Item("TipoPro") = Helper.Left(txtTerminado.Text, 2)

                .Item("ImpreOC") = ""

                .Item("Neti") = 0

                .Item("Foto1") = 0
                .Item("Foto2") = 0
                .Item("Foto3") = 0
                .Item("Foto4") = 0
                .Item("Foto5") = 0

                For x = 1 To 9
                    If Val(WLogo(x)) <> 0 Then

                        Select Case Val(WLogo(x))
                            Case 1
                                .Item("Foto1") = x
                            Case 2
                                .Item("Foto2") = x
                            Case 3
                                .Item("Foto3") = x
                            Case 4
                                .Item("Foto4") = x
                            Case 5
                                .Item("Foto5") = x
                        End Select

                    End If
                Next

                .Item("ImpreNumero") = ""

                Dim WUltEtiBarra As DataRow = Nothing
                Dim WUltEtiq As Integer = 0

                For Each empresa As String In Empresas

                    WUltEtiBarra = GetSingle("SELECT ISNULL(UltimaEtiqBarra, 0) as Ultima FROM Hoja WHERE Hoja = '" & txtLote.Text & "'", empresa)

                    If WUltEtiBarra IsNot Nothing Then
                        WUltEtiq = OrDefault(WUltEtiBarra.Item("Ultima"), 0)
                        ExecuteNonQueries(empresa, {"UPDATE Hoja SET UltimaEtiqBarra = (ISNULL(UltimaEtiqBarra, 0) + 1) WHERE Hoja = '" & txtLote.Text & "'"})
                        Exit For
                    End If

                Next

                WUltEtiq += 1

                .Item("CodBarra") = "*" & txtLote.Text.PadLeft(6, "0") + txtTerminado.Text & WUltEtiq.ToString.PadLeft(4, "0") & "*"

                If WIDEtiq <> 0 Then
                    ExecuteNonQueries({"UPDATE ProcesoCentroImpresion SET CodBarra = '" & .Item("CodBarra").ToString.Trim("*") & "' WHERE ID = '" & WIDEtiq & "'"})
                End If

            End With

            WEtiquetaII.Rows.Add(_r)

        Next

        '
        ' Grabamos los datos de EtiquetaIII.
        '
        Dim WEtiquetaIII As DataTable = New DBAuxi.EtiquetaIIDataTable

        For i = 1 To Val(txtCantEtiq.Text)

            Dim _r As DataRow = WEtiquetaIII.NewRow

            With _r
                .Item("Codigo") = i

                For x = 1 To 10
                    .Item("Frase" & x) = ZZImpreFrase(x)
                Next

            End With

            WEtiquetaIII.Rows.Add(_r)

        Next

        '
        ' Grabamos los datos de EtiquetaIV
        '
        Dim WEtiquetaIV As DataTable = New DBAuxi.EtiquetaIIIDataTable

        For i = 1 To Val(txtCantEtiq.Text)

            Dim _r As DataRow = WEtiquetaIV.NewRow

            With _r
                .Item("Codigo") = i

                For x = 11 To 19
                    .Item("Frase" & x) = ZZImpreFrase(x)
                Next

                .Item("Frase20") = ""

                If Val(WPalabra) = 1 Then
                    .Item("Frase20") = "PELIGRO"
                End If

                If Val(WPalabra) = 2 Then
                    .Item("Frase20") = "ATENCIÓN"
                End If

            End With

            WEtiquetaIV.Rows.Add(_r)

        Next

        Dim WPictograma As New DBAuxi.PictogramaDataTable
        Dim WPictograma1 As New DBAuxi.Pictograma1DataTable
        Dim WPictograma2 As New DBAuxi.Pictograma2DataTable
        Dim WPictograma3 As New DBAuxi.Pictograma3DataTable
        Dim WPictograma4 As New DBAuxi.Pictograma4DataTable

        For Each pic As DataTable In {WPictograma, WPictograma1, WPictograma2, WPictograma3, WPictograma4}

            pic.Rows.Add(0, "", Application.StartupPath & "\SGA\SB_SGA0.png")

            For i = 1 To 9

                Dim r As DataRow = pic.NewRow

                With r
                    .Item("Codigo") = i
                    .Item("Imagen") = Application.StartupPath & "\SGA\SB_SGA" & i & ".png"
                End With

                pic.Rows.Add(r)

            Next
        Next

        Dim rpt As ReportDocument

        Dim ds As New DataSet

        rpt = New etinuevanormachicaPreenvasado

        Dim p As ParameterFields = rpt.ParameterFields

        ds.Tables.Add(WEtiquetaII)
        ds.Tables.Add(WEtiquetaIII)
        ds.Tables.Add(WEtiquetaIV)
        ds.Tables.Add(WPictograma)
        ds.Tables.Add(WPictograma1)
        ds.Tables.Add(WPictograma2)
        ds.Tables.Add(WPictograma3)
        ds.Tables.Add(WPictograma4)

        rpt.SetDataSource(ds)

        For Each _p As ParameterField In p
            rpt.ParameterFields(_p.Name).CurrentValues = _p.CurrentValues
        Next

        If Not WPorLineaCmd Then WImpresora = ""

        With New VistaPrevia(WImpresora)
            .Reporte = rpt
            .Imprimir()
        End With

        'With New VistaPrevia
        '    .Reporte = rpt
        '    '.Mostrar()
        '    .Imprimir()
        'End With

        'MsgBox("Funciono")

        'With New VistaPreviaDS(WPictograma)
        '    .Show()
        'End With

        If Not WPorLineaCmd Then btnLimpiar.PerformClick()

    End Sub

    Public Sub txtLote_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtLote.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txtLote.Text) = "" Then : Exit Sub : End If

            Dim WHoja As DataRow = Nothing

            For Each empresa As String In Empresas
                WHoja = GetSingle("SELECT Producto FROM Hoja WHERE Hoja = '" & txtLote.Text & "'", empresa)

                If WHoja IsNot Nothing Then Exit For
            Next

            If WHoja IsNot Nothing Then

                txtTerminado.Text = WHoja.Item("Producto")

                Dim WTer As DataRow = GetSingle("SELECT Descripcion FROM Terminado WHERE Codigo = '" & txtTerminado.Text & "'")

                If WTer Is Nothing And Not WPorLineaCmd Then
                    MsgBox("No se encuentra el Producto Terminado asociado.", MsgBoxStyle.Exclamation)
                    Exit Sub
                End If

                txtDescTerminado.Text = Trim(OrDefault(WTer.Item("Descripcion"), ""))

                txtCantidadPorEnvase.Focus()

            Else
                If Not WPorLineaCmd Then MsgBox("No se encontró la Hoja de Producción a la que hizo referencia.", MsgBoxStyle.Exclamation)
                txtLote.Focus()
            End If

        ElseIf e.KeyData = Keys.Escape Then
            txtLote.Text = ""
        End If

    End Sub

    Private Sub txtCantidadPorEnvase_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtCantidadPorEnvase.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txtCantidadPorEnvase.Text) = "" Then : Exit Sub : End If

            txtCantidadPorEnvase.Text = formatonumerico(txtCantidadPorEnvase.Text)

            txtCantEtiq.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtCantidadPorEnvase.Text = ""
        End If

    End Sub

    Private Sub SoloNumero(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles txtLote.KeyPress, txtCantEtiq.KeyPress
        If Not Char.IsNumber(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub NumerosConComas(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles txtCantidadPorEnvase.KeyPress
        If Not Char.IsNumber(e.KeyChar) And Not Char.IsControl(e.KeyChar) And Not (CChar(".")) = e.KeyChar Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtCantEtiq_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtCantEtiq.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txtCantEtiq.Text) = "" Then : Exit Sub : End If

            txtLote.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtCantEtiq.Text = ""
        End If

    End Sub

    Private Sub EmisionEtiquetaPreenvasado_Shown(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Shown
        txtLote.Focus()
    End Sub
End Class