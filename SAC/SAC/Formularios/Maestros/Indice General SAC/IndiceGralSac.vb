Imports System.IO
Imports System.Reflection
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class IndiceGralSac : Implements INuevoSAC, IExportarIndice, IExportarSac

    Private WDatosSac As DataTable

    Private Sub IndiceGralSac_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        _CargarTiposSolicitud()
        _CargarEmisores()
        _CargarCentros()

        cmbOrdenI.SelectedIndex = 0
        cmbOrdenII.SelectedIndex = 1
        cmbOrdenIII.SelectedIndex = 2

        txtAnio.Text = Date.Now.ToString("yyyy")
        txtHastaAnio.Text = Date.Now.ToString("yyyy")

        For Each o As CheckedListBox In {clbCentros, clbEmisores, clbEstados, clbOrigenes, clbResponsables, clbTiposSolicitud}
            For i = 0 To o.Items.Count - 1
                o.SetItemCheckState(i, CheckState.Checked)
            Next
        Next

        WDatosSac = Nothing

        btnAceptar.PerformClick()

    End Sub

    Private Sub _CargarCentros()
        Dim WCentros As DataTable = GetAll("SELECT Codigo, LTRIM(RTRIM(Descripcion)) Descripcion FROM CentroSac WHERE ISNULL(Descripcion, '') <> '' ORDER BY Descripcion")

        With WCentros
            .Rows.Add(0, "Todos")
            .DefaultView.Sort = "Codigo"
        End With

        CType(clbCentros, ListBox).DataSource = WCentros
        CType(clbCentros, ListBox).DisplayMember = "Descripcion"
        CType(clbCentros, ListBox).ValueMember = "Codigo"

    End Sub

    Private Sub _CargarEmisores()
        Dim WEmisores As DataTable = GetAll("SELECT Codigo, LTRIM(RTRIM(Descripcion)) Descripcion FROM ResponsableSac WHERE ISNULL(Descripcion, '') <> '' ORDER BY Descripcion")

        With WEmisores
            .Rows.Add(0, "Todos")
            .DefaultView.Sort = "Codigo"
        End With

        CType(clbEmisores, ListBox).DataSource = WEmisores
        CType(clbEmisores, ListBox).DisplayMember = "Descripcion"
        CType(clbEmisores, ListBox).ValueMember = "Codigo"

        Dim WResponsables As DataTable = WEmisores.Copy

        WResponsables.DefaultView.Sort = "Codigo"

        CType(clbResponsables, ListBox).DataSource = WResponsables
        CType(clbResponsables, ListBox).DisplayMember = "Descripcion"
        CType(clbResponsables, ListBox).ValueMember = "Codigo"

    End Sub

    Private Sub _CargarTiposSolicitud()
        Dim WTipos As DataTable = GetAll("SELECT Codigo, LTRIM(RTRIM(Descripcion)) Descripcion FROM TipoSac ORDER BY Descripcion")

        WTipos.Rows.Add(0, "Todos")

        WTipos.DefaultView.Sort = "Codigo"

        CType(clbTiposSolicitud, ListBox).DataSource = WTipos
        CType(clbTiposSolicitud, ListBox).DisplayMember = "Descripcion"
        CType(clbTiposSolicitud, ListBox).ValueMember = "Codigo"

    End Sub

    Private Sub clbCheckedListBoxs_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles clbEstados.MouseUp, clbCentros.MouseUp, clbEmisores.MouseUp, clbOrigenes.MouseUp, clbResponsables.MouseUp, clbTiposSolicitud.MouseUp
        With CType(sender, CheckedListBox)
            If .SelectedIndex = 0 Then
                For i = 1 To .Items.Count - 1

                    If .GetItemCheckState(0) = CheckState.Checked Then
                        .SetItemChecked(i, True)
                    Else
                        .SetItemChecked(i, False)
                    End If

                Next
            Else
                .SetItemChecked(0, False)
            End If
        End With
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancelar.Click
        Close()
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAceptar.Click

        '
        ' Chequeamos que tenga un año indicado, sino indicamos por defecto el año actual.
        '
        If txtAnio.Text.Length < 4 Or txtAnio.Text.Trim = "" Then txtAnio.Text = Date.Now.ToString("yyyy")
        If txtHastaAnio.Text.Length < 4 Or txtHastaAnio.Text.Trim = "" Then txtHastaAnio.Text = txtAnio.Text


        '
        ' Armamos los campos de consulta.
        '
        Dim WCentros As String = _GenerarStringConsulta(clbCentros)
        Dim WTiposSolicitud As String = _GenerarStringConsulta(clbTiposSolicitud)
        Dim WEmisores As String = _GenerarStringConsulta(clbEmisores)
        Dim WResponsables As String = _GenerarStringConsulta(clbResponsables)
        Dim WEstados As String = _GenerarStringConsultaII(clbEstados)
        Dim WOrigenes As String = _GenerarStringConsultaII(clbOrigenes)

        '
        ' Armamos los campos de Ordenamiento.
        '
        Dim WOrdenI As String = _GenerarStringOrdenamiento(cmbOrdenI)
        Dim WOrdenII As String = _GenerarStringOrdenamiento(cmbOrdenII)
        Dim WOrdenIII As String = _GenerarStringOrdenamiento(cmbOrdenIII)

        Dim WWhere As String = String.Format("WHERE cs.Centro IN ({0}) And cs.Tipo IN ({1}) And cs.ResponsableEmisor IN ({2}) " &
                                             " And cs.ResponsableDestino IN ({3}) And cs.Estado IN ({4}) And cs.Origen IN ({5}) And cs.Ano BETWEEN '{6}' And '{7}' ",
                                             WCentros, WTiposSolicitud, WEmisores, WResponsables, WEstados, WOrigenes, txtAnio.Text, txtHastaAnio.Text)

        '
        ' Eliminamos las posibilidades de colapso entre los ordenamientos.
        '
        If WOrdenI.Contains(WOrdenII) Then WOrdenII = ""
        If WOrdenI.Contains(WOrdenIII) Then WOrdenIII = ""

        If WOrdenII.Contains(WOrdenIII) Then WOrdenIII = ""

        '
        ' Armamos la cadena de Ordenamiento.
        '
        Dim WOrderBy = "ORDER BY cs.Ano desc, "

        If WOrdenI.Trim <> "" Then WOrderBy &= WOrdenI & " ,"
        If WOrdenII.Trim <> "" Then WOrderBy &= WOrdenII & " Desc,"
        If WOrdenIII.Trim <> "" Then WOrderBy &= WOrdenIII & ","

        WOrderBy = WOrderBy.Remove(WOrderBy.Length - 1, 1)

        WDatosSac = GetAll("SELECT cs.Tipo As idTipo, Tipo = CASE WHEN ISNULL(t.Abreviatura, '') = '' THEN LTRIM(RTRIM(t.Descripcion)) ELSE LTRIM(RTRIM(t.Abreviatura)) END, cs.Ano As Anio, cs.Fecha, cs.Numero, LTRIM(RTRIM(cs.Referencia)) Referencia, " &
                                 " Estado = CASE cs.Estado WHEN 1 THEN 'Iniciada' WHEN 2 THEN 'Investig.' WHEN 3 THEN 'Implement.' WHEN 4 THEN 'Implem. A Ver.' WHEN 5 THEN 'Implem. Verif.' ELSE 'Cerrada' END, " &
                                 " Origen = CASE cs.Origen WHEN 1 THEN 'Auditoría' WHEN 2 THEN 'Reclamo' WHEN 3 THEN 'I. No Conf.' WHEN 4 THEN 'Proc./Sist.' WHEN 5 THEN 'Otro' END, " &
                                 " LTRIM(RTRIM(cs.Titulo)) Titulo, LTRIM(RTRIM(ce.Descripcion)) Centro, LTRIM(RTRIM(rs.Descripcion)) Emisor, LTRIM(RTRIM(rs2.Descripcion)) Responsable " &
                                 " FROM CargaSac As cs INNER JOIN TipoSac t ON t.Codigo = cs.Tipo " &
                                 " LEFT OUTER JOIN CentroSac ce ON ce.Codigo = cs.Centro " &
                                 " LEFT OUTER JOIN ResponsableSac rs ON rs.Codigo = cs.ResponsableEmisor " &
                                 " LEFT OUTER JOIN ResponsableSac rs2 ON rs2.Codigo = cs.ResponsableDestino " &
                                 " " & WWhere & " " & WOrderBy)

        dgvListado.DataSource = WDatosSac

        dgvListado.GetType.InvokeMember("DoubleBuffered", BindingFlags.NonPublic Or BindingFlags.Instance Or BindingFlags.SetProperty, Nothing, dgvListado, New Object() {True})

    End Sub

    Private Function _GenerarStringOrdenamiento(ByVal cmb As ComboBox)

        Dim WString = ""

        With cmb
            Select Case .SelectedIndex
                Case 2, 4
                    WString = IIf(.SelectedIndex = 2, "cs.Centro", "cs.ResponsableDestino")
                Case Else
                    WString = "cs." & .SelectedItem
            End Select
        End With

        Return WString
    End Function

    Private Function _GenerarStringConsulta(ByVal clb As CheckedListBox) As String

        Dim WString = ""

        For Each o As Object In clb.CheckedItems
            WString &= CType(o, DataRowView).Item("Codigo") & ","
        Next

        WString = WString.Remove(WString.Length - 1, 1)
        Return WString

    End Function

    Private Function _GenerarStringConsultaII(ByVal clb As CheckedListBox) As String

        Dim WString = ""

        For i = 1 To clb.Items.Count - 1
            If clb.GetItemCheckState(i) = CheckState.Checked Then
                WString &= i & ","
            End If
        Next

        WString = WString.Remove(WString.Length - 1, 1)
        Return WString

    End Function

    Private Sub dgvListado_SortCompare(ByVal sender As Object, ByVal e As DataGridViewSortCompareEventArgs) Handles dgvListado.SortCompare

        dgvListado.ClearSelection()

        If e.Column.Index <> dgvListado.Columns("Fecha").Index Then Exit Sub

        Dim num1 = Val(ordenaFecha(e.CellValue1))
        Dim num2 = Val(ordenaFecha(e.CellValue2))

        If num1 < num2 Then
            e.SortResult = -1
        ElseIf num1 = num2 Then
            e.SortResult = 0
        Else
            e.SortResult = 1
        End If

        e.Handled = True

    End Sub

    Private Sub dgvListado_CellMouseDoubleClick(ByVal sender As Object, ByVal e As DataGridViewCellMouseEventArgs) Handles dgvListado.CellMouseDoubleClick

        Try

            With dgvListado.CurrentRow
                Dim WTipo As String = OrDefault(.Cells("idTipo").Value, "")
                Dim WNumero As String = OrDefault(.Cells("Numero").Value, "")
                Dim WAnio As String = OrDefault(.Cells("Anio").Value, "")

                Dim frm As New NuevoSac(WTipo, WNumero, WAnio)

                frm.Show(Me)

            End With

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub txtAnio_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtAnio.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txtAnio.Text).Length < 4 Then : Exit Sub : End If

            txtHastaAnio.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtAnio.Text = ""
        End If

    End Sub

    Private Sub btnNuevaSolicitud_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnNuevaSolicitud.Click
        Dim frm As New NuevoSac
        frm.Show(Me)
    End Sub

    Public Sub _ProcesarNuevoSAC(ByVal WTipo As Object, ByVal WNumero As Object, ByVal WAnio As Object) Implements INuevoSAC._ProcesarNuevoSAC
        btnAceptar.PerformClick()
    End Sub

    Private Sub CopiarConCabecerasToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CopiarConCabecerasToolStripMenuItem.Click
        dgvListado.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        _CopiarSeleccion()
    End Sub

    Private Sub CopiarSóloDatosToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CopiarSóloDatosToolStripMenuItem.Click
        dgvListado.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        _CopiarSeleccion()
    End Sub

    Private Sub _CopiarSeleccion()
        If dgvListado.GetCellCount(DataGridViewElementStates.Selected) > 0 Then

            dgvListado.RowHeadersVisible = False

            Dim WData = dgvListado.GetClipboardContent()

            If Not IsNothing(WData) Then
                Clipboard.SetDataObject(WData)
            End If

            dgvListado.RowHeadersVisible = True

        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
        With ExportarIndice
            .Show(Me)
        End With
    End Sub

    Private Sub _ExportarReporte(ByVal frm2 As VistaPrevia, ByVal WFormato As Object)

        With frm2

            Dim WNombreArchivo = String.Format("Indice Gral {0} al {2} - {1}", txtAnio.Text, Date.Now.ToString("dd-MM-yyyy"), txtHastaAnio.Text)

            Select Case WFormato
                Case 0 ' Imprimir
                    .Imprimir()
                Case 1 ' Mostrar por Pantalla
                    .Mostrar()
                Case 2 ' PDF
                    .Exportar(WNombreArchivo, ExportFormatType.PortableDocFormat)
                Case 3 ' Excel
                    .Exportar(WNombreArchivo, ExportFormatType.Excel)
                Case 4 ' Word
                    .Exportar(WNombreArchivo, ExportFormatType.WordForWindows)
            End Select

        End With
    End Sub

    Public Sub _ProcesarExportarIndice(ByVal WAgrupar As Boolean, ByVal WFormato As Object) Implements IExportarIndice._ProcesarExportarIndice

        Try

            If dgvListado.Rows.Count = 0 Then Exit Sub

            Dim frm As New VistaPrevia
            Dim rpt As ReportDocument

            If WAgrupar Then
                rpt = New ReporteIndiceGralAgrupados
            Else
                rpt = New ReporteIndiceGral
            End If

            Dim ds As New DetallesIndiceGral

            For Each row As DataGridViewRow In dgvListado.Rows
                Dim r As DataRow = ds.Tables("Detalles").NewRow

                With r
                    .Item("Clave") = row.Index
                    .Item("Tipo") = If(row.Cells("Tipo").Value, "")
                    .Item("idTipo") = If(row.Cells("idTipo").Value, "")
                    .Item("Año") = If(row.Cells("Anio").Value, 0)
                    .Item("Nro") = If(row.Cells("Numero").Value, 0)
                    .Item("Fecha") = If(row.Cells("Fecha").Value, "")
                    .Item("Estado") = If(row.Cells("Estado").Value, "")
                    .Item("Titulo") = If(row.Cells("Titulo").Value, "")
                    .Item("Referencia") = If(row.Cells("Referencia").Value, "")
                    .Item("Centro") = If(row.Cells("Centro").Value, "")
                    .Item("Origen") = If(row.Cells("Origen").Value, "")
                    .Item("Emisor") = If(row.Cells("Emisor").Value, "")
                    .Item("Responsable") = If(row.Cells("Responsable").Value, "")
                End With
                ds.Tables("Detalles").Rows.Add(r)
            Next

            rpt.SetDataSource(ds)

            With frm
                .Reporte = rpt
            End With

            If WFormato = 5 Then

                Dim WRuta = "C:/tempIndice/"

                If Directory.Exists(WRuta) Then Directory.Delete(WRuta, True)

                Directory.CreateDirectory(WRuta)

                Dim WNombreArchivo = String.Format("Indice Gral {0} al {2} - {1}.pdf", txtAnio.Text, Date.Now.ToString("dd-MM-yyyy"), txtHastaAnio.Text)

                frm.Exportar(WNombreArchivo, ExportFormatType.PortableDocFormat, WRuta)

                With VistaPrevia
                    .EnviarPorEmail(WRuta & WNombreArchivo)
                End With

            Else

                _ExportarReporte(frm, WFormato)

            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub txtHastaAnio_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtHastaAnio.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txtHastaAnio.Text) = "" Then txtHastaAnio.Text = txtAnio.Text

            btnAceptar.PerformClick()

        ElseIf e.KeyData = Keys.Escape Then
            txtHastaAnio.Text = ""
        End If

    End Sub


    Private Sub txtBuscador_KeyUp(sender As Object, e As KeyEventArgs) Handles txtBuscador.KeyUp
        
        Dim tabla As DataTable = TryCast(dgvListado.DataSource, DataTable)

        If tabla IsNot Nothing Then tabla.DefaultView.RowFilter = String.Format("Referencia LIKE '%{0}%' OR Titulo LIKE '%{0}%'", txtBuscador.Text)

    End Sub

    Private Sub dgvListado_MouseUp(sender As Object, e As MouseEventArgs) Handles dgvListado.MouseUp

        For Each cell As DataGridViewCell In dgvListado.SelectedCells
            dgvListado.Rows(cell.RowIndex).Selected = True

        Next



        If dgvListado.SelectedRows.Count > 1 Then
            btnExportarVarios.Visible = True
        Else
            btnExportarVarios.Visible = False
        End If
    End Sub

    Private Sub btnExportarVarios_Click(sender As Object, e As EventArgs) Handles btnExportarVarios.Click
        Dim frm As New ExportarSAC
        frm.Show(Me)
    End Sub



    Public Sub _ProcesarExportarSac(ByVal WOpcion1 As Boolean, ByVal WOpcion2 As Boolean, ByVal WFormato As Object, ByVal WOpcion3 As Boolean) Implements IExportarSac._ProcesarExportarSac

        Try

            For Each row As DataGridViewRow In dgvListado.SelectedRows

                Dim tipo As Integer

                tipo = ObtenerTipo(row.Cells("Tipo").Value)

                '
                ' Verificamos que exista la SAC.
                '
                Dim WSAC As DataRow = GetSingle("SELECT Clave FROM CargaSAC WHERE Tipo = '" & tipo & "' And Ano = '" & row.Cells("Anio").Value & "' And Numero = '" & row.Cells("Numero").Value & "'")

                If IsNothing(WSAC) Then Continue For


                '
                ' Cargamos la carátula y filtramos para el SAC indicado.
                '

                Dim frm As New VistaPrevia
                With frm
                    .Reporte = New NuevoSACCaratula
                    .Formula = "{CargaSac.Tipo} = " & tipo & " And {CargaSac.Numero} = " & row.Cells("Numero").Value & " And {CargaSac.Ano} = " & row.Cells("Anio").Value & ""
                End With

                '  _PrepararImpreSacII()

                Dim frm2 As New VistaPrevia
                With frm2
                    .Reporte = IIf(WOpcion3, New NuevoSACAcciones, New NuevoSACAccionesSinComentarios)
                    .Formula = "{ImpreSacII.Tipo} = " & tipo & " And {ImpreSacII.Numero} = " & row.Cells("Numero").Value & " And {ImpreSacII.Ano} = " & row.Cells("Anio").Value & ""
                End With

                Dim frm3 As New VistaPrevia
                With frm3
                    .Reporte = New NuevoSACSoloComentarios
                    .Formula = "{CargaSacAdicional.Tipo} = " & tipo & " And {CargaSacAdicional.Numero} = " & row.Cells("Numero").Value & " And {CargaSacAdicional.Ano} = " & row.Cells("Anio").Value & ""
                End With

                If WFormato = 3 Then
                    '
                    ' Exportamos ambos archivos en el caso que corresponda en un archivo temporal.
                    '
                    Dim WRuta = "C:/tSac/"

                    If Directory.Exists(WRuta) Then Directory.Delete(WRuta, True)

                    Directory.CreateDirectory(WRuta)

                    If WOpcion2 Then frm2.Exportar("2.pdf", ExportFormatType.PortableDocFormat, WRuta)
                    If WOpcion1 Then frm.Exportar("1.pdf", ExportFormatType.PortableDocFormat, WRuta)

                    Dim WPrefijoArchivo As String = GenerarPrefijoArchivo(tipo)

                    Dim WNombreArchivo = String.Format("{4} {0} {1} {2} - {3}.pdf", tipo, row.Cells("Numero").Value, row.Cells("Anio").Value, Date.Now.ToString("dd-MM-yyyy"), WPrefijoArchivo)

                    With VistaPrevia
                        .MergePDFs(WRuta, WNombreArchivo)
                        .EnviarPorEmail(WRuta & WNombreArchivo)
                    End With

                ElseIf WOpcion1 And WOpcion2 Then

                    With frm

                        If WOpcion3 Then
                            .Reporte = New NuevoSACAmbos
                        Else
                            .Reporte = New NuevoSACAmbosSinComentarios
                        End If

                        .Formula = "{CargaSac.Tipo} = " & tipo & " And {CargaSac.Numero} = " & row.Cells("Numero").Value & " And {CargaSac.Ano} = " & row.Cells("Anio").Value & ""

                    End With

                    _ExportarReporte(frm, WFormato)

                Else

                    If WOpcion3 And Not WOpcion2 Then _ExportarReporte(frm3, WFormato)
                    If WOpcion2 Then _ExportarReporte(frm2, WFormato)
                    If WOpcion1 Then _ExportarReporte(frm, WFormato)

                End If

            Next

        Catch ex As System.Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub


    Private Function ObtenerTipo(ByVal TipoString As String) As Integer

        Dim SQLCnslt As String = ""
        SQLCnslt = "SELECT Codigo FROM TipoSAC WHERE (Descripcion = '" & TipoString & "' Or Abreviatura = '" & TipoString & "')"

        Dim row As DataRow = GetSingle(SQLCnslt)
        Return row.Item("Codigo")
    End Function
    Private Function GenerarPrefijoArchivo(ByVal Tipo As String) As String

        Dim WPrefijoArchivo = ""

        Dim WTipo As DataRow = GetSingle("SELECT Descripcion, Abreviatura FROM TipoSac WHERE Codigo = '" & Tipo & "'")

        WPrefijoArchivo = OrDefault(WTipo.Item("Descripcion"), "")

        If OrDefault(WTipo.Item("Abreviatura"), "") <> "" Then
            WPrefijoArchivo = OrDefault(WTipo.Item("Abreviatura"), "")
        End If

        WPrefijoArchivo = Trim(WPrefijoArchivo)
        Return WPrefijoArchivo
    End Function


    Private Sub btnEstadistica_Click(sender As Object, e As EventArgs) Handles btnEstadistica.Click

        Dim TablaEstadistica As DataTable = _PrepararDatosEstadistica()
        Dim Titulo As String = "Desde año  " & txtAnio.Text & "  al  " & txtHastaAnio.Text
        Dim Tinciales As Integer = 0
        Dim TInvestig As Integer = 0
        Dim TImplemet As Integer = 0
        Dim TImpleAVer As Integer = 0
        Dim TImpleVerif As Integer = 0
        Dim TCerrados As Integer = 0

        For i = 0 To TablaEstadistica.Rows.Count - 1
            With TablaEstadistica.Rows(i)
                Tinciales += .Item("Iniciada")
                TInvestig += .Item("Investig.")
                TImplemet += .Item("Implement.")
                TImpleAVer += .Item("Imple.Aver.")
                TImpleVerif += .Item("Imple.Verif.")
                TCerrados += .Item("Cerrada")
            End With

        Next

        With New VistaPrevia

            .Reporte = New ReporteEstadistica()
            .Reporte.SetDataSource(TablaEstadistica)
            .Reporte.SetParameterValue(0, Titulo)
            .Reporte.SetParameterValue(1, Tinciales)
            .Reporte.SetParameterValue(2, TInvestig)
            .Reporte.SetParameterValue(3, TImplemet)
            .Reporte.SetParameterValue(4, TImpleAVer)
            .Reporte.SetParameterValue(5, TImpleVerif)
            .Reporte.SetParameterValue(6, TCerrados)

            '.Imprimir()
            .Mostrar()
        End With

    End Sub

    Private Function _PrepararDatosEstadistica() As DataTable
        Dim TablaEstadistica As New DataTable
        With TablaEstadistica.Columns
            .Add("Tipo")
            .Add("Iniciada")
            .Add("Investig.")
            .Add("Implement.")
            .Add("Imple.Aver.")
            .Add("Imple.Verif.")
            .Add("Cerrada")
            .Add("Total")
        End With

        Dim WTipos As DataTable = New DataView(TryCast(dgvListado.DataSource, DataTable)).ToTable(True, "Tipo")

        For Each row As Datarow In WTipos.Rows
            TablaEstadistica.Rows.Add(row.Item("Tipo"), 0, 0, 0, 0, 0, 0)
        Next

        For Each row As DataGridViewRow In dgvListado.Rows

            For Each r As DataRow In TablaEstadistica.Rows
                With r

                    Dim WEstado As String = OrDefault(row.Cells("Estado").Value, "")

                    If .Item("Tipo") = row.Cells("Tipo").Value Then

                        Dim WNombreColumna = WEstado.Replace("Implem.", "Imple.").Replace(" ", "")

                        If TablaEstadistica.Columns(WNombreColumna) IsNot Nothing Then .Item(WNombreColumna) += 1

                    End If
                End With
            Next

        Next

        For Each row As Datarow In TablaEstadistica.Rows
            With row
                .Item("Total") = Val(.Item("Iniciada")) + Val(.Item("Investig.")) + Val(.Item("Implement.")) + Val(.Item("Imple.Aver.")) + Val(.Item("Imple.Verif.")) + Val(.Item("Cerrada"))
            End With
        Next

        Return TablaEstadistica
    End Function
End Class