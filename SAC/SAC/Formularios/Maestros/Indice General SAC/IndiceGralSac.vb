Public Class IndiceGralSac : Implements INuevoSAC

    Private WDatosSac As DataTable

    Private Sub IndiceGralSac_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        _CargarTiposSolicitud()
        _CargarEmisores()
        _CargarCentros()

        cmbOrdenI.SelectedIndex = 0
        cmbOrdenII.SelectedIndex = 1
        cmbOrdenIII.SelectedIndex = 2

        txtAnio.Text = Date.Now.ToString("yyyy")

        For Each o As CheckedListBox In {clbCentros, clbEmisores, clbEstados, clbOrigenes, clbResponsables, clbTiposSolicitud}
            For i As Integer = 0 To o.Items.Count - 1
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

    Private Sub clbCheckedListBoxs_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles clbEstados.MouseUp, clbCentros.MouseUp, clbEmisores.MouseUp, clbOrigenes.MouseUp, clbResponsables.MouseUp, clbTiposSolicitud.MouseUp
        With CType(sender, CheckedListBox)
            If .SelectedIndex = 0 Then
                For i As Integer = 1 To .Items.Count - 1

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

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Close()
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click

        '
        ' Chequeamos que tenga un año indicado, sino indicamos por defecto el año actual.
        '
        If txtAnio.Text.Length < 4 Or txtAnio.Text.Trim = "" Then txtAnio.Text = Date.Now.ToString("yyyy")


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
                                             " And cs.ResponsableDestino IN ({3}) And cs.Estado IN ({4}) And cs.Origen IN ({5}) And cs.Ano = '{6}' ",
                                             WCentros, WTiposSolicitud, WEmisores, WResponsables, WEstados, WOrigenes, txtAnio.Text)

        '
        ' Eliminamos las posibilidades de colapso entre los ordenamientos.
        '
        If WOrdenI.Contains(WOrdenII) Then WOrdenII = ""
        If WOrdenI.Contains(WOrdenIII) Then WOrdenIII = ""

        If WOrdenII.Contains(WOrdenIII) Then WOrdenIII = ""

        '
        ' Armamos la cadena de Ordenamiento.
        '
        Dim WOrderBy As String = "ORDER BY "

        If WOrdenI.Trim <> "" Then WOrderBy &= WOrdenI & ","
        If WOrdenII.Trim <> "" Then WOrderBy &= WOrdenII & ","
        If WOrdenIII.Trim <> "" Then WOrderBy &= WOrdenIII & ","

        WOrderBy = WOrderBy.Remove(WOrderBy.Length - 1, 1)

        WDatosSac = Query.GetAll("SELECT cs.Tipo As idTipo, LTRIM(RTRIM(t.Descripcion)) Tipo, cs.Ano As Anio, cs.Fecha, cs.Numero, LTRIM(RTRIM(cs.Referencia)) Referencia, " &
                                 " Estado = CASE cs.Estado WHEN 1 THEN 'Iniciada' WHEN 2 THEN 'Investig.' WHEN 3 THEN 'Implement.' WHEN 4 THEN 'Implem. A Ver.' WHEN 5 THEN 'Implem. Verif.' ELSE 'Cerrada' END, " &
                                 " Origen = CASE cs.Origen WHEN 1 THEN 'Auditoría' WHEN 2 THEN 'Reclamo' WHEN 3 THEN 'I. No Conf.' WHEN 4 THEN 'Proc./Sist.' WHEN 5 THEN 'Otro' END, " &
                                 " LTRIM(RTRIM(cs.Titulo)) Titulo, LTRIM(RTRIM(ce.Descripcion)) Centro, LTRIM(RTRIM(rs.Descripcion)) Emisor, LTRIM(RTRIM(rs2.Descripcion)) Responsable " &
                                 " FROM CargaSac As cs INNER JOIN TipoSac t ON t.Codigo = cs.Tipo " &
                                 " LEFT OUTER JOIN CentroSac ce ON ce.Codigo = cs.Centro " &
                                 " LEFT OUTER JOIN ResponsableSac rs ON rs.Codigo = cs.ResponsableEmisor " &
                                 " LEFT OUTER JOIN ResponsableSac rs2 ON rs2.Codigo = cs.ResponsableDestino " &
                                 " " & WWhere & " " & WOrderBy)

        'dgvListado.DataSource = WDatosSac

        dgvListado.Rows.Clear()

        For Each row As DataRow In WDatosSac.Rows
            Dim i = dgvListado.Rows.Add

            With dgvListado.Rows(i)
                For Each c As DataGridViewColumn In dgvListado.Columns()
                    .Cells(c.Name).Value = OrDefault(row.Item(c.Name), "")
                Next
            End With

        Next

        dgvListado.GetType.InvokeMember("DoubleBuffered", Reflection.BindingFlags.NonPublic Or Reflection.BindingFlags.Instance Or System.Reflection.BindingFlags.SetProperty, Nothing, dgvListado, New Object() {True})

    End Sub

    Private Function _GenerarStringOrdenamiento(ByVal cmb As ComboBox)

        Dim WString As String = ""

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

        Dim WString As String = ""

        For Each o As Object In clb.CheckedItems
            WString &= CType(o, DataRowView).Item("Codigo") & ","
        Next

        WString = WString.Remove(WString.Length - 1, 1)
        Return WString

    End Function

    Private Function _GenerarStringConsultaII(ByVal clb As CheckedListBox) As String

        Dim WString As String = ""

        For i As Integer = 1 To clb.Items.Count - 1
            If clb.GetItemCheckState(i) = CheckState.Checked Then
                WString &= i & ","
            End If
        Next

        WString = WString.Remove(WString.Length - 1, 1)
        Return WString

    End Function

    Private Sub dgvListado_SortCompare(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewSortCompareEventArgs) Handles dgvListado.SortCompare

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

    Private Sub dgvListado_CellMouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvListado.CellMouseDoubleClick

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

    Private Sub txtAnio_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtAnio.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txtAnio.Text).Length < 4 Then : Exit Sub : End If

            btnAceptar.PerformClick()

        ElseIf e.KeyData = Keys.Escape Then
            txtAnio.Text = ""
        End If

    End Sub

    Private Sub btnNuevaSolicitud_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevaSolicitud.Click
        Dim frm As New NuevoSac
        frm.Show(Me)
    End Sub

    Public Sub _ProcesarNuevoSAC(ByVal WTipo As Object, ByVal WNumero As Object, ByVal WAnio As Object) Implements INuevoSAC._ProcesarNuevoSAC
        btnAceptar.PerformClick()
    End Sub
End Class