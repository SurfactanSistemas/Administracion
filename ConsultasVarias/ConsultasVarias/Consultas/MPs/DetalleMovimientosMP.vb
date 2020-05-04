Imports System.ComponentModel
Imports ConsultasVarias.Clases
Imports ConsultasVarias.Clases.Query
Imports ConsultasVarias.Clases.Helper
Imports ConsultasVarias.Clases.Globales

Public Class DetalleMovimientosMP

    Dim WLote As Object = 0
    Dim WIncluirHistorico As Boolean = False
    Private ZEmpresas As New DataTable

    Sub New(Optional ByVal _Lote As Object = 0, Optional ByVal IncluirHistorico As Boolean = False)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        WLote = _Lote
        WIncluirHistorico = IncluirHistorico

        txtLotePartida.ReadOnly = WLote <> 0

    End Sub

    Private Sub DetalleMovimientosMP_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load

        CheckForIllegalCrossThreadCalls = False

        For Each c As Control In {txtCodigo, txtDescMP, txtFecha, txtFechaCierre, txtLotePartida, txtPartiOriginal, txtSaldo}
            c.TabStop = False
        Next

        txtDescMP.BackColor = Globales.WBackColorTerciario

        For Each c As DataGridViewColumn In DataGridView1.Columns
            c.SortMode = DataGridViewColumnSortMode.NotSortable
        Next

        With DataGridView1
            .DefaultCellStyle.BackColor = Globales.WBackColorSecundario
            .DefaultCellStyle.SelectionBackColor = Globales.WBackColorTerciario
            .DefaultCellStyle.SelectionForeColor = Color.White
        End With

        txtSaldo.BackColor = Globales.WBackColorTerciario

        With ZEmpresas
            .Columns.Add("Id", GetType(Integer))
            .Columns.Add("Descripcion")
            .Columns.Add("Base")
            .Rows.Add(1, "SURFACTAN I", "SurfactanSa")
            .Rows.Add(2, "SURFACTAN II", "Surfactan_II")
            .Rows.Add(3, "SURFACTAN III", "Surfactan_III")
            .Rows.Add(4, "SURFACTAN IV", "Surfactan_IV")
            .Rows.Add(5, "SURFACTAN V", "Surfactan_V")
            .Rows.Add(6, "SURFACTAN VI", "Surfactan_VI")
            .Rows.Add(7, "SURFACTAN VII", "Surfactan_VII")
        End With

        With ComboBox1
            .DataSource = ZEmpresas
            .DisplayMember = "Descripcion"
            .ValueMember = "Base"
            If .Items.Count > 0 Then
                .SelectedItem = _ObtenerEmpresaOriginal(WLote)
            End If
        End With

        If Val(WLote) <> 0 Then
            With BackgroundWorker1
                If Not .IsBusy Then .RunWorkerAsync()
            End With
        Else
            txtCodigo.Text = "  -     -   "
            txtFecha.Text = "  /  /    "
            txtFechaCierre.Text = txtFecha.Text
        End If

    End Sub

    Private Function _ObtenerEmpresaOriginal(ByVal _Lote As Object) As Object
        For Each empresa As Object In ComboBox1.Items

            Dim emp As String = CType(empresa, DataRowView).Item("Base")

            Dim WLaudo As DataRow = GetSingle("SELECT Articulo, Fecha, PartiOri FROM Laudo WHERE Laudo = '" & WLote & "' And Renglon IN ('1', '01')", emp)

            If WLaudo IsNot Nothing Then Return empresa

        Next
        
        Return Nothing
    End Function

    Private Sub BackgroundWorker1_DoWork(ByVal sender As Object, ByVal e As DoWorkEventArgs) Handles BackgroundWorker1.DoWork

        Dim WCodMP As String = ""
        Dim WReventa As Object = 0
        Dim WFechaCierre As String = ""
        Dim WFechaCierreOrd As String = ""
        Dim WDescMP As String = ""
        Dim WTipoMat As String = ""
        Dim WMarca As String = ""
        Dim WPartiOrig As String = ""
        Dim Auxi = ""

        Dim WMovimientos As New DataTable

        With WMovimientos.Columns
            .Add("Tipo")
            .Add("TipoMov")
            .Add("Observaciones")
            .Add("Numero", GetType(Double))
            .Add("Fecha")
            .Add("FechaOrd", GetType(Integer))
            .Add("Entrada")
            .Add("Salida")
            .Add("Marca")
        End With

        Dim WFiltroMarca As String = " And ISNULL(Marca, '') <> 'X' "

        If WIncluirHistorico Then WFiltroMarca = ""

        Dim empresa As String = CType(ComboBox1.SelectedItem, DataRowView).Item("Base")

        Dim WEmpresaOrig As DataRowView = _ObtenerEmpresaOriginal(WLote)

        Dim WLaudo As DataRow = GetSingle("SELECT Articulo, Fecha, PartiOri FROM Laudo WHERE Laudo = '" & WLote & "' And Renglon IN ('1', '01')", WEmpresaOrig.Item("Base"))

        txtFecha.Text = OrDefault(WLaudo.Item("Fecha"), "")
        WPartiOrig = OrDefault(WLaudo.Item("PartiOri"), "")

        WCodMP = OrDefault(WLaudo.Item("Articulo"), "")

        WTipoMat = WCodMP.ToString.Substring(0, 2)

        Dim WArticulo As DataRow = GetSingle("SELECT Reventa, FechaCierre, Descripcion FROM Articulo WHERE Codigo = '" & WCodMP & "'", empresa)

        With WArticulo
            WReventa = OrDefault(.Item("Reventa"), 0)
            WDescMP = OrDefault(.Item("Descripcion"), "")
            WFechaCierre = OrDefault(.Item("FechaCierre"), "")
            WFechaCierreOrd = ordenaFecha(WFechaCierre)
        End With

        txtCodigo.Text = WCodMP
        txtDescMP.Text = WDescMP
        txtFechaCierre.Text = WFechaCierre
        txtLotePartida.Text = WLote
        txtPartiOriginal.Text = Trim(WPartiOrig)
        txtSaldo.Text = ""

        If Val(WReventa) = 1 Then WTipoMat = "DY"

        Auxi = WLote

        ' Busco el Número de Lote según la Partida Original.
        Select Case UCase(WTipoMat)
            Case "DY", "DS", "DQ"

                Auxi = WPartiOrig

                Dim WAuxi As DataRow = GetSingle("SELECT Laudo As Lote FROM Laudo WHERE Articulo = '" & WCodMP & "' And PartiOri = '" & WPartiOrig & "' And Renglon IN ('1', '01')", empresa)

                If WAuxi Is Nothing Then
                    WAuxi = GetSingle("SELECT Lote FROM Guia WHERE Articulo = '" & WCodMP & "' And PartiOri = '" & WPartiOrig & "'", empresa)
                End If

                If WAuxi IsNot Nothing Then
                    Auxi = OrDefault(WAuxi.Item("Lote"), 0)
                End If

            Case "DK", "NS", "NQ"

                Dim WAuxi2 As String = WTipoMat & "00" & Microsoft.VisualBasic.Right(WCodMP, 7)
                Auxi = WPartiOrig

                Dim WAuxi As DataRow = GetSingle("SELECT Lote FROM EntDev WHERE Terminado = '" & WAuxi2 & "' And Codigo = '" & WPartiOrig & "'", empresa)

                If WAuxi IsNot Nothing Then Auxi = OrDefault(WAuxi.Item("Lote"), 0)

        End Select

        '
        ' Busco el o los Laudos que se correspondan con el Lote o PartiOrig segun sea o no Reventa.
        '
        Dim WSql As String = ""
        If Val(WReventa) = 1 And Trim(WPartiOrig) <> "" Then
            WSql = "SELECT Laudo, Liberada, LiberadaAnt, Marca, Fecha, Orden FROM Laudo WHERE Articulo = '" & WCodMP & "' And PartiOri = '" & WPartiOrig & "'"
        Else
            WSql = "SELECT Laudo, Liberada, LiberadaAnt, Marca, Fecha, Orden FROM Laudo WHERE Articulo = '" & WCodMP & "' And Laudo = '" & Auxi & "'"
        End If

        Dim WLaudos As DataTable = GetAll(WSql, empresa)

        Dim WDescr, WNumero, WFecha, WFechaOrd, WObservaciones, WLiberada As String
        WMarca = ""
        If WLaudos.Rows.Count > 0 Then

            For Each row As DataRow In WLaudos.Rows
                With row
                    WDescr = "Laudo"
                    WObservaciones = ""
                    WNumero = OrDefault(.Item("Laudo"), "0")
                    WLiberada = OrDefault(.Item("Liberada"), 0)
                    WMarca = OrDefault(.Item("Marca"), "")
                    If WFiltroMarca = "" And WMarca = "X" Then WLiberada = OrDefault(.Item("LiberadaAnt"), 0)

                    WLiberada = formatonumerico(WLiberada)
                    WFecha = OrDefault(.Item("Fecha"), "")
                    WFechaOrd = ordenaFecha(WFecha)

                    Auxi = OrDefault(.Item("Orden"), 0)

                    Dim WOrden As DataRow = GetSingle("SELECT p.Nombre FROM Orden o LEFT OUTER JOIN Proveedor p ON p.Proveedor = o.Proveedor And o.Renglon = 1 WHERE Orden = '" & Auxi & "'", empresa)

                    If WOrden IsNot Nothing Then WObservaciones = Trim(OrDefault(WOrden.Item("Nombre"), ""))
                End With

                If Val(WLiberada) <> 0 Then
                    Dim r = WMovimientos.NewRow
                    With r
                        .Item("Tipo") = "1"
                        .Item("Fecha") = WFecha
                        .Item("FechaOrd") = WFechaOrd
                        .Item("Numero") = WNumero
                        .Item("Entrada") = formatonumerico(WLiberada)
                        .Item("Salida") = ""
                        .Item("Observaciones") = WObservaciones
                        .Item("TipoMov") = WDescr
                        .Item("Marca") = WMarca
                    End With
                    WMovimientos.Rows.Add(r)
                End If

            Next

        End If

        '
        ' Busco uso en Hojas de Producción posteriores a la Fecha de Cierre
        '

        Dim WHojas As DataTable = GetAll("SELECT Fecha, Hoja, Canti1, Canti2, Canti3, Lote1, Lote2, Lote3, Marca FROM Hoja WHERE Tipo = 'M' " & WFiltroMarca & " And (RIGHT(Fecha, 4) + SUBSTRING(Fecha, 4, 2) + LEFT(Fecha, 2)) >= '" & WFechaCierreOrd & "' And (Lote1 = '" & WLote & "' Or Lote2 = '" & WLote & "' Or Lote3 = '" & WLote & "')", empresa)
        WMarca = ""
        For Each row As DataRow In WHojas.Rows
            With row
                For i = 1 To 3
                    Auxi = OrDefault(.Item("Lote" & i), 0)

                    If Val(Auxi) = Val(WLote) Then
                        WLiberada = OrDefault(.Item("Canti" & i), 0)
                        WLiberada = formatonumerico(WLiberada)
                        WNumero = OrDefault(.Item("Hoja"), 0)
                        WFecha = OrDefault(.Item("Fecha"), "")
                        WFechaOrd = ordenaFecha(WFecha)
                        WObservaciones = ""
                        WDescr = "Hoja"
                        WMarca = OrDefault(.Item("Marca"), "")

                        Dim r = WMovimientos.NewRow
                        With r
                            .Item("Tipo") = "2"
                            .Item("Fecha") = WFecha
                            .Item("FechaOrd") = WFechaOrd
                            .Item("Numero") = WNumero
                            .Item("Salida") = formatonumerico(WLiberada)
                            .Item("Entrada") = ""
                            .Item("Observaciones") = WObservaciones
                            .Item("TipoMov") = WDescr
                            .Item("Marca") = WMarca
                        End With
                        WMovimientos.Rows.Add(r)

                    End If

                Next
            End With
        Next

        '
        ' Busco uso en Movimientos Varios.
        '

        Dim WMovVars As DataTable = GetAll("SELECT Cantidad, Marca, Movi, Codigo, Fecha, Observaciones FROM MovVar WHERE Tipo = 'M' " & WFiltroMarca & " And Lote = '" & WLote & "'", empresa)
        WMarca = ""
        For Each row As DataRow In WMovVars.Rows
            With row

                WLiberada = OrDefault(.Item("Cantidad"), 0)

                'If WFiltroMarca = "" And OrDefault(.Item("Marca"), "") = "X" Then WLiberada = OrDefault(.Item("CantidadAnt"), 0)

                WLiberada = formatonumerico(WLiberada)
                Auxi = OrDefault(.Item("Movi"), "")
                WNumero = OrDefault(.Item("Codigo"), 0)
                WFecha = OrDefault(.Item("Fecha"), "")
                WMarca = OrDefault(.Item("Marca"), "")
                WFechaOrd = ordenaFecha(WFecha)
                WObservaciones = OrDefault(.Item("Observaciones"), "")
                WDescr = "Mov. Var"

                Dim r = WMovimientos.NewRow
                With r
                    .Item("Tipo") = "0"
                    .Item("Fecha") = WFecha
                    .Item("FechaOrd") = WFechaOrd
                    .Item("Numero") = WNumero
                    .Item("Salida") = IIf(Auxi = "E", "", formatonumerico(WLiberada))
                    .Item("Entrada") = IIf(Auxi = "S", "", formatonumerico(WLiberada))
                    .Item("Observaciones") = WObservaciones

                    WDescr = "Mov. Var"
                    Auxi = OrDefault(.Item("TipoMov"), -1)

                    If {0, 1}.Contains(Val(Auxi)) Then WDescr = "Guía Int."

                    .Item("TipoMov") = WDescr
                    .Item("Marca") = WMarca
                End With
                WMovimientos.Rows.Add(r)

            End With
        Next

        '
        ' Busco uso en Movimientos Varios.
        '

        Dim WGuiasInt As DataTable = GetAll("SELECT Cantidad, CantidadAnt, Marca, Codigo, Fecha, Movi, TipoMov, Destino FROM Guia WHERE Tipo = 'M' " & WFiltroMarca & " And (Lote = '" & WLote & "' Or Partida = '" & WLote & "' Or (PartiOri = '" & WPartiOrig & "' And PartiOri <> ''))", empresa)
        WMarca = ""
        For Each row As DataRow In WGuiasInt.Rows
            With row

                WLiberada = OrDefault(.Item("Cantidad"), 0)

                If WFiltroMarca = "" And OrDefault(.Item("Marca"), "") = "X" Then WLiberada = OrDefault(.Item("CantidadAnt"), 0)

                WLiberada = formatonumerico(WLiberada)
                WNumero = OrDefault(.Item("Codigo"), 0)
                WFecha = OrDefault(.Item("Fecha"), "")
                WMarca = OrDefault(.Item("Marca"), "")
                WFechaOrd = ordenaFecha(WFecha)
                WObservaciones = ""
                WDescr = "Guía Int."
                Dim WMovi = OrDefault(.Item("Movi"), "")
                Dim WTipoMov = OrDefault(.Item("TipoMov"), "")

                If UCase(WMovi) = "S" Then
                    Auxi = OrDefault(.Item("Destino"), "")
                    Select Case Val(Auxi)
                        Case 1
                            WObservaciones = "Envio a Surfactan"
                        Case 2
                            WObservaciones = "Envio a Pellital"
                        Case 3
                            WObservaciones = "Envio a Surfactan II"
                        Case 4
                            WObservaciones = "Envio a Pellital II"
                        Case 5
                            WObservaciones = "Envio a Surfactan III"
                        Case 6
                            WObservaciones = "Envio a Surfactan IV"
                        Case 7
                            WObservaciones = "Envio a Surfactan V"
                        Case 8
                            WObservaciones = "Envio a Pellital V"
                        Case 9
                            WObservaciones = "Envio a Pellital IV"
                        Case 10
                            WObservaciones = "Envio a Surfactan VI"
                        Case 11
                            WObservaciones = "Envio a Surfactan VII"
                        Case Else
                    End Select

                Else
                    Select Case Val(WTipoMov)
                        Case 1
                            WObservaciones = "Recepcion de Surfactan"
                        Case 2
                            WObservaciones = "Recepcion de Pellital"
                        Case 3
                            WObservaciones = "Recepcion de Surfactan II"
                        Case 4
                            WObservaciones = "Recepcion de Pellital II"
                        Case 5
                            WObservaciones = "Recepcion de Surfactan III"
                        Case 6
                            WObservaciones = "Recepcion de Surfactan IV"
                        Case 7
                            WObservaciones = "Recepcion de Surfactan V"
                        Case 8
                            WObservaciones = "Recepcion de Pellital V"
                        Case 9
                            WObservaciones = "Recepcion de Pellital IV"
                        Case 10
                            WObservaciones = "Recepcion de Surfactan VI"
                        Case 11
                            WObservaciones = "Recepcion de Surfactan VII"
                        Case Else
                    End Select

                End If

                WDescr = "Guía Int."

                If Val(WNumero) > 900000 Then
                    WDescr = "Préstamo"
                    WNumero = Val(WNumero) - 900000
                End If

                Dim r = WMovimientos.NewRow
                With r
                    .Item("Tipo") = "0"
                    .Item("Fecha") = WFecha
                    .Item("FechaOrd") = WFechaOrd
                    .Item("Numero") = WNumero
                    .Item("Salida") = IIf(WMovi = "E", "", formatonumerico(WLiberada))
                    .Item("Entrada") = IIf(WMovi = "S", "", formatonumerico(WLiberada))
                    .Item("Observaciones") = WObservaciones
                    .Item("TipoMov") = WDescr
                    .Item("Marca") = WMarca
                End With
                WMovimientos.Rows.Add(r)

            End With
        Next

        '
        ' Busco uso en Movimientos de Laboratorio.
        '

        Dim WMovLab As DataTable = GetAll("SELECT Cantidad, Codigo, Movi, Fecha, Marca, Observaciones FROM MovLab WHERE Tipo = 'M' " & WFiltroMarca & " And Lote = '" & WLote & "'", empresa)
        WMarca = ""
        For Each row As DataRow In WMovLab.Rows
            With row

                WLiberada = OrDefault(.Item("Cantidad"), 0)

                WLiberada = formatonumerico(WLiberada)
                Auxi = OrDefault(.Item("Movi"), "")
                WNumero = OrDefault(.Item("Codigo"), 0)
                WFecha = OrDefault(.Item("Fecha"), "")
                WMarca = OrDefault(.Item("Marca"), "")
                WFechaOrd = ordenaFecha(WFecha)
                WObservaciones = OrDefault(.Item("Observaciones"), "")
                WDescr = "Mov. Lab."

                Dim r = WMovimientos.NewRow
                With r
                    .Item("Tipo") = "0"
                    .Item("Fecha") = WFecha
                    .Item("FechaOrd") = WFechaOrd
                    .Item("Numero") = WNumero
                    .Item("Salida") = IIf(Auxi = "E", "", formatonumerico(WLiberada))
                    .Item("Entrada") = IIf(Auxi = "S", "", formatonumerico(WLiberada))
                    .Item("Observaciones") = WObservaciones
                    .Item("TipoMov") = WDescr
                    .Item("Marca") = WMarca
                End With
                WMovimientos.Rows.Add(r)

            End With
        Next

        Auxi = WCodMP

        If WTipoMat = "DK" Then Auxi = "DY-" & Microsoft.VisualBasic.Right(WCodMP, 7)
        If WTipoMat = "NS" Then Auxi = "DS-" & Microsoft.VisualBasic.Right(WCodMP, 7)
        If WTipoMat = "NQ" Then Auxi = "DQ-" & Microsoft.VisualBasic.Right(WCodMP, 7)

        If WFiltroMarca <> "" Then WFiltroMarca = " And e.Marca <> 'X' "

        Dim WEstadisticas As DataTable = GetAll("SELECT Cliente = c.Razon, e.Marca, e.Tipo, e.TipoPro, e.Fecha, e.Numero, e.Cliente, e.LoteAdicional, e.Lote1, e.Lote2, e.Lote3, e.Lote4, e.Lote5, e.Canti1, e.Canti2, e.Canti3, e.Canti4, e.Canti5 FROM Estadistica e LEFT OUTER JOIN Cliente c ON c.Cliente = e.Cliente WHERE e.TipoProDy = 'M' " & WFiltroMarca & " And e.ArticuloDy = '" & Auxi & "'", empresa)
        WMarca = ""
        For Each row As DataRow In WEstadisticas.Rows

            Dim XLotes(12, 2) As String
            Dim WTipo

            With row
                WTipo = OrDefault(.Item("Tipo"), 0)
                Auxi = OrDefault(.Item("TipoPro"), 0)

                WFecha = ""
                WFechaOrd = ""
                WNumero = ""
                WObservaciones = ""

                Select Case UCase(WTipoMat)
                    Case "DK", "NS", "NK"
                        If WTipo = 2 Then
                            WFecha = OrDefault(.Item("Fecha"), "")
                            WFechaOrd = ordenaFecha(WFecha)
                            WNumero = OrDefault(.Item("Numero"), "")
                            WMarca = OrDefault(.Item("Marca"), "")
                            WObservaciones = OrDefault(.Item("Cliente"), "")
                            WLiberada = Math.Abs(Val(formatonumerico(OrDefault(.Item("Canti1"), "0"))))

                            WDescr = "Devol."

                            Dim r = WMovimientos.NewRow
                            With r
                                .Item("Tipo") = "0"
                                .Item("Fecha") = WFecha
                                .Item("FechaOrd") = WFechaOrd
                                .Item("Numero") = WNumero
                                .Item("Salida") = formatonumerico(WLiberada)
                                .Item("Entrada") = ""
                                .Item("Observaciones") = WObservaciones
                                .Item("TipoMov") = WDescr
                                .Item("Marca") = WMarca
                            End With
                            WMovimientos.Rows.Add(r)

                        End If
                    Case Else
                        If (WTipo = 2 And Auxi = WTipoMat) Or WTipo = 1 Then
                            WFecha = OrDefault(.Item("Fecha"), "")
                            WFechaOrd = ordenaFecha(WFecha)
                            WNumero = OrDefault(.Item("Numero"), "")
                            WObservaciones = OrDefault(.Item("Cliente"), "")
                            WMarca = OrDefault(.Item("Marca"), "")

                            WDescr = "Devol."

                            For i = 1 To 5
                                XLotes(i, 1) = OrDefault(.Item("Lote" & i), "")
                                XLotes(i, 2) = OrDefault(.Item("Canti" & i), "")
                            Next

                            Dim WLoteAdicional As String = OrDefault(.Item("LoteAdicional"), "")
                            WLoteAdicional = WLoteAdicional.PadRight(98, "0")

                            XLotes(6, 1) = Mid$(WLoteAdicional, 1, 8)
                            XLotes(6, 2) = Mid$(WLoteAdicional, 9, 6)
                            XLotes(7, 1) = Mid$(WLoteAdicional, 15, 8)
                            XLotes(7, 2) = Mid$(WLoteAdicional, 23, 6)
                            XLotes(8, 1) = Mid$(WLoteAdicional, 29, 8)
                            XLotes(8, 2) = Mid$(WLoteAdicional, 37, 6)
                            XLotes(9, 1) = Mid$(WLoteAdicional, 43, 8)
                            XLotes(9, 2) = Mid$(WLoteAdicional, 51, 6)
                            XLotes(10, 1) = Mid$(WLoteAdicional, 57, 8)
                            XLotes(10, 2) = Mid$(WLoteAdicional, 65, 6)
                            XLotes(11, 1) = Mid$(WLoteAdicional, 71, 8)
                            XLotes(11, 2) = Mid$(WLoteAdicional, 79, 6)
                            XLotes(12, 1) = Mid$(WLoteAdicional, 85, 8)
                            XLotes(12, 2) = Mid$(WLoteAdicional, 93, 6)

                        End If
                End Select

            End With

            For i = 1 To 12

                Auxi = XLotes(i, 1)

                If Val(Auxi) = WLote Then

                    WLiberada = Math.Abs(Val(formatonumerico(XLotes(i, 2))))

                    Dim r = WMovimientos.NewRow
                    With r
                        .Item("Tipo") = "0"
                        .Item("Fecha") = WFecha
                        .Item("FechaOrd") = WFechaOrd
                        .Item("Numero") = WNumero

                        If Val(WTipo) = 2 Then
                            .Item("Entrada") = formatonumerico(WLiberada)
                            .Item("Salida") = ""
                            .Item("TipoMov") = "Devol."
                        Else
                            .Item("Salida") = formatonumerico(WLiberada)
                            .Item("Entrada") = ""
                            .Item("TipoMov") = "Fact."
                        End If

                        .Item("Observaciones") = WObservaciones
                        .Item("Marca") = WMarca

                    End With
                    WMovimientos.Rows.Add(r)

                End If

            Next

        Next

        Dim WSaldo As Double = 0

        For Each m As DataRow In WMovimientos.Rows
            If OrDefault(m.Item("Marca"), "") <> "X" Then
                WSaldo += Val(m.Item("Entrada"))
                WSaldo -= Val(m.Item("Salida"))
            End If
        Next

        txtSaldo.Text = formatonumerico(WSaldo)

        WMovimientos.DefaultView.Sort = "FechaOrd ASC, Numero ASC"

        BackgroundWorker1.ReportProgress(1, WMovimientos)

    End Sub

    Private Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
        Close()
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        Button1.Focus()
    End Sub

    Private Sub BackgroundWorker1_ProgressChanged(ByVal sender As System.Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged

        DataGridView1.DataSource = TryCast(e.UserState, DataTable)

        Dim c As DataGridViewColumn = DataGridView1.Columns("Marca")
        If c IsNot Nothing Then c.Visible = False

    End Sub

    Private Sub DataGridView1_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        If e.RowIndex < 0 Then Exit Sub

        Dim WTipo = OrDefault(DataGridView1.CurrentRow.Cells("Tipo").Value, 0)
        Dim WLaudo = OrDefault(DataGridView1.CurrentRow.Cells("LotePartida").Value, 0)

        If WTipo = 1 Then
            With New DetallesEnsayosMP(WLaudo)
                .Show(Me)
            End With
        End If

        If WTipo = 2 Then
            With New DetallesHojaProduccion(WLaudo)
                .Show(Me)
            End With
        End If

    End Sub

    Private Sub DetalleMovimientosMP_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        txtLotePartida.Focus()
    End Sub

    Private Sub txtLotePartida_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtLotePartida.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txtLotePartida.Text) = "" Then : Exit Sub : End If

            WLote = txtLotePartida.Text

            ComboBox1.SelectedItem = _ObtenerEmpresaOriginal(WLote)

            With BackgroundWorker1
                If Not .IsBusy Then .RunWorkerAsync()
            End With

        ElseIf e.KeyData = Keys.Escape Then
            txtLotePartida.Text = ""
        End If

    End Sub

    Private Sub ComboBox1_DropDownClosed(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.DropDownClosed
        If Not BackgroundWorker1.IsBusy Then BackgroundWorker1.RunWorkerAsync()
    End Sub
End Class