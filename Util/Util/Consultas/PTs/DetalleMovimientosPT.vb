﻿Imports System.ComponentModel
Imports Util.Clases
Imports Util.Clases.Query
Imports Util.Clases.Helper
Imports Util.Clases.Globales

Public Class DetalleMovimientosPT

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

        For Each c As Control In {txtCodigo, txtDescPT, txtFecha, txtFechaCierre, txtLotePartida, txtPartiOriginal, txtSaldo}
            c.TabStop = False
        Next

        txtDescPT.BackColor = Globales.WBackColorTerciario

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

        If WLote <> 0 Then
            With BackgroundWorker1
                If Not .IsBusy Then .RunWorkerAsync()
            End With
        End If
    End Sub


    Private Function _ObtenerEmpresaOriginal(ByVal _Lote As Object) As Object
        For Each empresa As Object In ComboBox1.Items

            Dim emp As String = CType(empresa, DataRowView).Item("Base")

            Dim WHoja1 As DataRow = GetSingle("SELECT Producto, Fecha FROM Hoja WHERE Hoja = '" & WLote & "' And Renglon IN ('1', '01') ", emp)

            If WHoja1 IsNot Nothing Then Return empresa

        Next

        Return Nothing
    End Function

    Private Sub BackgroundWorker1_DoWork(ByVal sender As Object, ByVal e As DoWorkEventArgs) Handles BackgroundWorker1.DoWork

        Dim WCodPT As String = ""
        Dim WReventa As Object = 0
        Dim WFechaCierre As String = ""
        Dim WFechaCierreOrd As String = ""
        Dim WDescPT As String = ""
        Dim WTipoPT As String = ""
        Dim WPartiOrig As String = ""
        Dim Auxi = ""
        Dim WMarca = ""

        Dim WMovimientos As New DataTable

        With WMovimientos.Columns
            .Add("Tipo")
            .Add("Fecha")
            .Add("FechaOrd", GetType(Integer))
            .Add("Numero", GetType(Double))
            .Add("Entrada")
            .Add("Salida")
            .Add("Observaciones")
            .Add("TipoMov")
            .Add("Marca")
        End With

        Dim WFiltroMarca As String = " And ISNULL(Marca, '') <> 'X' "

        If WIncluirHistorico Then WFiltroMarca = ""

        Dim empresa As String = CType(ComboBox1.SelectedItem, DataRowView).Item("Base")

        Dim WEmpresaOrig As DataRowView = _ObtenerEmpresaOriginal(WLote)

        WMarca = ""

        Dim WHoja1 As DataRow = GetSingle("SELECT TOP 1 Producto, Fecha FROM Hoja WHERE Hoja = '" & WLote & "' And ISNULL(Lote1, 0) <> 0 ", WEmpresaOrig.Item("Base"))

        txtFecha.Text = OrDefault(WHoja1.Item("Fecha"), "")

        WCodPT = OrDefault(WHoja1.Item("Producto"), "")

        WTipoPT = WCodPT.ToString.Substring(0, 2)

        Dim WTerminado As DataRow = GetSingle("SELECT FechaCierre, Descripcion FROM Terminado WHERE Codigo = '" & WCodPT & "'", empresa)

        With WTerminado
            WDescPT = OrDefault(.Item("Descripcion"), "")
            WFechaCierre = OrDefault(.Item("FechaCierre"), "")
            WFechaCierreOrd = ordenaFecha(WFechaCierre)
        End With

        txtCodigo.Text = WCodPT
        txtDescPT.Text = WDescPT
        txtFechaCierre.Text = WFechaCierre
        txtLotePartida.Text = WLote
        txtPartiOriginal.Text = Trim(WPartiOrig)
        txtSaldo.Text = ""

        Auxi = WLote

        '
        ' Busco la o las Hojas que correspondan con el Lote o PartiOrig segun sea o no Reventa.
        '

        Dim WHojas2 As DataRow = GetSingle("SELECT TOP 1 * FROM Hoja WHERE Producto = '" & WCodPT & "' And Hoja = '" & Auxi & "' And ISNULL(Lote1, 0) <> 0" & WFiltroMarca, empresa)

        Dim WDescr, WNumero, WFecha, WFechaOrd, WObservaciones, WLiberada As String
        WMarca = ""
        If WHojas2 IsNot Nothing Then

            With WHojas2
                WDescr = "Hoja"
                WObservaciones = ""
                WNumero = OrDefault(.Item("Hoja"), "0")
                WLiberada = OrDefault(.Item("Real"), 0)

                WMarca = OrDefault(.Item("Marca"), "")

                If OrDefault(.Item("RealAnt"), 0) <> 0 And UCase(Trim(WMarca)) = "X" Then
                    WLiberada = OrDefault(.Item("RealAnt"), 0)
                End If

                If WLiberada = 0 Then
                    WLiberada = OrDefault(.Item("Teorico"), 0)
                End If

                WLiberada = formatonumerico(WLiberada)
                WFecha = OrDefault(.Item("Fecha"), "")


                If OrDefault(.Item("FechaFinal"), "").ToString.Replace("/", "").Trim <> "" Then
                    WFecha = OrDefault(.Item("FechaFinal"), "")
                End If

                WFechaOrd = ordenaFecha(WFecha)

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

        End If

        '
        ' Busco uso en Hojas de Producción posteriores a la Fecha de Cierre
        '

        Dim WHojas As DataTable = GetAll("SELECT * FROM Hoja WHERE Tipo = 'T' And Terminado = '" & WCodPT & "' " & WFiltroMarca & " And (Lote1 = '" & WLote & "' Or Lote2 = '" & WLote & "' Or Lote3 = '" & WLote & "')", empresa)

        For Each row As DataRow In WHojas.Rows
            WMarca = ""
            With row
                For i = 1 To 3
                    Auxi = OrDefault(.Item("Lote" & i), 0)

                    If Val(Auxi) = Val(WLote) Then
                        WLiberada = OrDefault(.Item("Canti" & i), 0)
                        WLiberada = formatonumerico(WLiberada)
                        WNumero = OrDefault(.Item("Hoja"), 0)
                        WFecha = OrDefault(.Item("Fecha"), "")
                        WMarca = OrDefault(.Item("Marca"), "")

                        If OrDefault(.Item("FechaFinal"), "").ToString.Replace("/", "").Trim <> "" Then
                            WFecha = OrDefault(.Item("FechaFinal"), "")
                        End If

                        WFechaOrd = ordenaFecha(WFecha)
                        WObservaciones = ""
                        WDescr = "Hoja"

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

        Dim WMovVars As DataTable = GetAll("SELECT * FROM MovVar WHERE Tipo = 'T' " & WFiltroMarca & " And Lote = '" & WLote & "'", empresa)

        WMarca = ""
        For Each row As DataRow In WMovVars.Rows
            With row

                WLiberada = OrDefault(.Item("Cantidad"), 0)
                WLiberada = formatonumerico(WLiberada)
                Auxi = OrDefault(.Item("Movi"), "")
                WNumero = OrDefault(.Item("Codigo"), 0)
                WFecha = OrDefault(.Item("Fecha"), "")
                WFechaOrd = ordenaFecha(WFecha)
                WObservaciones = OrDefault(.Item("Observaciones"), "")
                WMarca = OrDefault(.Item("Marca"), "")
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

                    WDescr = "Guía Int."

                    Auxi = OrDefault(.Item("TipoMov"), -1)

                    If {1, 2}.Contains(Val(Auxi)) Then WDescr = "Mov. Var"

                    .Item("TipoMov") = WDescr
                    .Item("Marca") = WMarca
                End With
                WMovimientos.Rows.Add(r)

            End With
        Next

        '
        ' Busco uso en Movimientos Varios.
        '

        Dim WGuiasInt As DataTable = GetAll("SELECT * FROM Guia WHERE Tipo = 'T' " & WFiltroMarca & " And (Lote = '" & WLote & "' Or Partida = '" & WLote & "')", empresa)
        WMarca = ""
        For Each row As DataRow In WGuiasInt.Rows
            With row

                WLiberada = OrDefault(.Item("Cantidad"), 0)
                WMarca = OrDefault(.Item("Marca"), "")

                If OrDefault(.Item("CantidadAnt"), 0) <> 0 And UCase(Trim(WMarca)) = "X" Then
                    WLiberada = OrDefault(.Item("CantidadAnt"), 0)
                End If

                WLiberada = formatonumerico(WLiberada)
                WNumero = OrDefault(.Item("Codigo"), 0)
                WFecha = OrDefault(.Item("Fecha"), "")

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

        Dim WMovLab As DataTable = GetAll("SELECT * FROM MovLab WHERE Tipo = 'T' " & WFiltroMarca & " And Lote = '" & WLote & "'", empresa)
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
                End With
                WMovimientos.Rows.Add(r)

            End With
        Next

        Auxi = WCodPT

        If WFiltroMarca <> "" Then WFiltroMarca = " And ISNULL(e.Marca, '') <> 'X'"

        Dim WEstadisticas As DataTable = GetAll("SELECT Cliente = c.Cliente + '  ' + RTRIM(c.Razon), e.Marca, e.Tipo, e.TipoPro, e.Fecha, e.Numero, e.Cliente, e.LoteAdicional, e.Lote1, e.Lote2, e.Lote3, e.Lote4, e.Lote5, e.Canti1, e.Canti2, e.Canti3, e.Canti4, e.Canti5 FROM Estadistica e LEFT OUTER JOIN Cliente c ON c.Cliente = e.Cliente WHERE e.Articulo = '" & Auxi & "' " & WFiltroMarca & "", empresa)
        WMarca = ""
        For Each row As DataRow In WEstadisticas.Rows

            Dim XLotes(12, 2) As String
            Dim WTipo

            With row
                WTipo = OrDefault(.Item("Tipo"), 0)
                Auxi = OrDefault(.Item("TipoPro"), 0)
                WFecha = OrDefault(.Item("Fecha"), "")
                WFechaOrd = ordenaFecha(WFecha)
                WNumero = OrDefault(.Item("Numero"), "")
                WMarca = OrDefault(.Item("Marca"), "")
                WObservaciones = OrDefault(.Item("Cliente"), "")

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

                        If Val(WTipo) = 1 Then
                            .Item("Salida") = formatonumerico(WLiberada)
                            .Item("Entrada") = ""
                            .Item("TipoMov") = "Fact."
                        Else
                            .Item("Entrada") = formatonumerico(WLiberada)
                            .Item("Salida") = ""
                            .Item("TipoMov") = "Devol."
                        End If

                        .Item("Observaciones") = WObservaciones
                        .Item("Marca") = WMarca

                    End With
                    WMovimientos.Rows.Add(r)

                End If

            Next

        Next

        If WFiltroMarca <> "" Then WFiltroMarca = " And ISNULL(Marca, '') <> 'X' "

        Dim WConsignaciones As DataTable = GetAll("SELECT * FROM Consig WHERE Terminado = '" & WCodPT & "' and ISNULL(Cantidad, 0) <> 0 And Lote = '" & WLote & "'" & WFiltroMarca, empresa)
        WMarca = ""
        For Each row As DataRow In WConsignaciones.Rows
            With row
                WLiberada = OrDefault(.Item("Cantidad"), 0) - OrDefault(.Item("Facturado"), 0)
                WLiberada = formatonumerico(WLiberada)
                WNumero = OrDefault(.Item("Codigo"), 0)
                WFecha = OrDefault(.Item("Fecha"), "")
                WMarca = OrDefault(.Item("Marca"), "")
                WFechaOrd = ordenaFecha(WFecha)
                WObservaciones = Trim(OrDefault(.Item("Cliente"), "") & " " & OrDefault(.Item("Observaciones"), ""))
                WDescr = "Rem. Con."

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
            End With
        Next


        Dim WSaldo As Double = 0

        For Each m As DataRow In WMovimientos.Rows
            If m.Item("Marca") <> "X" Then
                WSaldo += Val(m.Item("Entrada"))
                WSaldo -= Val(m.Item("Salida"))
            End If
        Next

        txtSaldo.Text = formatonumerico(WSaldo)

        WMovimientos.DefaultView.Sort = "FechaOrd ASC, Numero ASC"

        BackgroundWorker1.ReportProgress(1, WMovimientos)

    End Sub

    Private Sub SoloNumero(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtLotePartida.KeyPress
        If Not Char.IsNumber(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
        Close()
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        Button1.Focus()
    End Sub

    Private Sub BackgroundWorker1_ProgressChanged(ByVal sender As System.Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged
        DataGridView1.DataSource = TryCast(e.UserState, DataTable)

        txtLotePartida.Focus()

    End Sub

    Private Sub DataGridView1_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        If e.RowIndex < 0 Then Exit Sub

        Dim WTipo = OrDefault(DataGridView1.CurrentRow.Cells("Tipo").Value, 0)
        Dim WLaudo = OrDefault(DataGridView1.CurrentRow.Cells("LotePartida").Value, 0)

        If WTipo = 1 Then
            With New DetallesHojaProduccion(WLaudo)
                .Show(Me)
            End With
        End If

    End Sub

    Private Sub txtLotePartida_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtLotePartida.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txtLotePartida.Text) = "" Then : Exit Sub : End If

            WLote = txtLotePartida.Text

            ComboBox1.SelectedItem = _ObtenerEmpresaOriginal(WLote)

            If Not BackgroundWorker1.IsBusy Then BackgroundWorker1.RunWorkerAsync()

        ElseIf e.KeyData = Keys.Escape Then
            txtLotePartida.Text = ""
        End If

    End Sub

    Private Sub DetalleMovimientosPT_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        txtLotePartida.Focus()
    End Sub

    Private Sub ComboBox1_DropDownClosed(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.DropDownClosed
        If Not BackgroundWorker1.IsBusy Then BackgroundWorker1.RunWorkerAsync()
    End Sub

End Class