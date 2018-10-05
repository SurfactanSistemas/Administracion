Public Class IndiceGralSac

    Private Sub IndiceGralSac_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        _CargarTiposSolicitud()
        _CargarEmisores()
        ' _CargarResponsables()
        _CargarCentros()

        txtAnio.Text = Date.Now.ToString("yyyy")

        cmbOrdenI.SelectedIndex = 0
        cmbOrdenII.SelectedIndex = 1
        cmbOrdenIII.SelectedIndex = 2

        For Each clb As CheckedListBox In {clbCentros, clbEmisores, clbEstados, clbOrigenes, clbResponsables, clbTiposSolicitud}
            clb.SetItemChecked(0, True)
        Next

    End Sub

    Private Sub _CargarResponsables()
        'Throw New NotImplementedException
    End Sub

    Private Sub _CargarCentros()
        Dim WCentros As DataTable = GetAll("SELECT Codigo, LTRIM(RTRIM(Descripcion)) Descripcion FROM CentroSac WHERE ISNULL(Descripcion, '') <> '' ORDER BY Descripcion")

        Dim WTemp As New DataTable

        With WTemp
            .Columns.Add("Codigo")
            .Columns.Add("Descripcion")
            .Rows.Add(0, "Todos")
        End With

        WTemp.Load(WCentros.CreateDataReader, LoadOption.OverwriteChanges)

        CType(clbCentros, ListBox).DataSource = WTemp
        CType(clbCentros, ListBox).DisplayMember = "Descripcion"
        CType(clbCentros, ListBox).ValueMember = "Codigo"

    End Sub

    Private Sub _CargarEmisores()
        Dim WEmisores As DataTable = GetAll("SELECT Codigo, LTRIM(RTRIM(Descripcion)) Descripcion FROM ResponsableSac WHERE ISNULL(Descripcion, '') <> '' ORDER BY Descripcion")

        Dim WTemp As New DataTable

        With WTemp
            .Columns.Add("Codigo")
            .Columns.Add("Descripcion")
            .Rows.Add(0, "Todos")
        End With

        WTemp.Load(WEmisores.CreateDataReader, LoadOption.OverwriteChanges)

        CType(clbEmisores, ListBox).DataSource = WTemp
        CType(clbEmisores, ListBox).DisplayMember = "Descripcion"
        CType(clbEmisores, ListBox).ValueMember = "Codigo"

        Dim WResponsables As DataTable = WTemp.Copy

        CType(clbResponsables, ListBox).DataSource = WResponsables
        CType(clbResponsables, ListBox).DisplayMember = "Descripcion"
        CType(clbResponsables, ListBox).ValueMember = "Codigo"

    End Sub

    Private Sub _CargarTiposSolicitud()
        Dim WTipos As DataTable = GetAll("SELECT Codigo, LTRIM(RTRIM(Descripcion)) Descripcion FROM TipoSac ORDER BY Descripcion")

        Dim WTiposII As New DataTable

        With WTiposII
            .Columns.Add("Codigo")
            .Columns.Add("Descripcion")
            .Rows.Add(0, "Todos")
        End With

        WTiposII.Load(WTipos.CreateDataReader, LoadOption.OverwriteChanges)

        CType(clbTiposSolicitud, ListBox).DataSource = WTiposII
        CType(clbTiposSolicitud, ListBox).DisplayMember = "Descripcion"
        CType(clbTiposSolicitud, ListBox).ValueMember = "Codigo"

        'For Each row As datarow In WTipos.Rows
        '    With row
        '        clbTiposSolicitud.Items.Add(.Item("Descripcion"))
        '    End With
        'Next
        
    End Sub
    
    Private Sub clbEstados_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles clbEstados.Click

        'For i As Integer = 0 To clbEstados.Items.Count - 1
        '    clbEstados.SetItemChecked(i, True)
        '    MsgBox(clbEstados.GetItemCheckState(i))
        'Next

    End Sub

    Private Sub clbEstados_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        With clbEstados
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

    Private Sub clbOrigenes_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles clbEstados.MouseUp
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

    Private Sub clbCentros_ItemCheck(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ItemCheckEventArgs) Handles clbTiposSolicitud.ItemCheck, clbResponsables.ItemCheck, clbOrigenes.ItemCheck, clbEstados.ItemCheck, clbEmisores.ItemCheck, clbCentros.ItemCheck
        If e.Index = 0 And e.NewValue = CheckState.Checked Then
            For i = 1 To CType(sender, CheckedListBox).Items.Count - 1
                CType(sender, CheckedListBox).SetItemChecked(i, True)
            Next
        End If
    End Sub

    Private Sub txtFiltrar_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFiltrar.KeyPress
        Dim tabla As DataTable = CType(dgvListado.DataSource, DataTable)

        If Not IsNothing(tabla) Then
            tabla.DefaultView.RowFilter = String.Format("Tipo LIKE '%{0}%' " &
                                                        "Or Convert(Ano, System.String) LIKE '%{0}%'" &
                                                        "Or Convert(Numero, System.String) LIKE '%{0}%'" &
                                                        "Or Fecha LIKE '%{0}%'" &
                                                        "Or Estado LIKE '%{0}%'" &
                                                        "Or Titulo LIKE '%{0}%'" &
                                                        "Or Referencia LIKE '%{0}%'" &
                                                        "Or Centro LIKE '%{0}%'" &
                                                        "Or Origen LIKE '%{0}%'" &
                                                        "Or Emisor LIKE '%{0}%'" &
                                                        "Or Responsable LIKE '%{0}%'" &
                                                        "", txtFiltrar.Text)
        End If

    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Dim WSql As String = ""

        WSql = "SELECT cs.Tipo as idTipo, Tipo = ts.Descripcion, cs.Titulo, cs.Referencia, " &
               "cs.Fecha, Estado = CASE ISNULL(cs.Estado, 0) WHEN 0 THEN '' WHEN 1 THEN 'Iniciada' WHEN 2 THEN 'Investig.' WHEN 3 THEN 'Implement.' WHEN 4 THEN 'Imp. a Verficar' WHEN 5 THEN 'Imp. Verificada' WHEN 6 THEN 'Cerrada' END , " &
               " Anio = cs.Ano, cs.Numero, idCentro = cs.Centro, Centro = ces.Descripcion FROM CargaSac cs LEFT OUTER JOIN TipoSac ts ON ts.Codigo = cs.Tipo " &
               " LEFT OUTER JOIN CentroSac ces ON ces.Codigo = cs.Centro"

        Dim wWhere As String = " WHERE cs.Ano = " & txtAnio.Text
        
        If Not clbTiposSolicitud.CheckedIndices.Contains(0) Then
            Dim ZTipo As String = ""

            For Each row As DataRowView In clbTiposSolicitud.CheckedItems
                ZTipo &= row.Item("Codigo") & ","
            Next

            wWhere &= " And cs.Tipo IN " & String.Format("({0})", ZTipo.Remove(ZTipo.Length - 1, 1))

        End If

        If Not clbEstados.CheckedIndices.Contains(0) Then
            Dim ZTipo As String = ""

            For Each row As Object In clbEstados.CheckedIndices
                ZTipo &= row & ","
            Next

            wWhere &= " And cs.Estado IN " & String.Format("({0})", ZTipo.Remove(ZTipo.Length - 1, 1))

        End If

        If Not clbOrigenes.CheckedIndices.Contains(0) Then
            Dim ZTipo As String = ""

            For Each row As Object In clbOrigenes.CheckedIndices
                ZTipo &= row & ","
            Next

            wWhere &= " And cs.Origen IN " & String.Format("({0})", ZTipo.Remove(ZTipo.Length - 1, 1))

        End If

        If Not clbEmisores.CheckedIndices.Contains(0) Then
            Dim ZTipo As String = ""

            For Each row As DataRowView In clbEmisores.CheckedItems
                ZTipo &= row.Item("Codigo") & ","
            Next

            wWhere &= " And cs.ResponsableEmisor IN " & String.Format("({0})", ZTipo.Remove(ZTipo.Length - 1, 1))

        End If

        If Not clbResponsables.CheckedIndices.Contains(0) Then
            Dim ZTipo As String = ""

            For Each row As DataRowView In clbResponsables.CheckedItems
                ZTipo &= row.Item("Codigo") & ","
            Next

            wWhere &= " And cs.ResponsableDestino IN " & String.Format("({0})", ZTipo.Remove(ZTipo.Length - 1, 1))

        End If

        If Not clbCentros.CheckedIndices.Contains(0) Then
            Dim ZTipo As String = ""

            For Each row As DataRowView In clbCentros.CheckedItems
                ZTipo &= row.Item("Codigo") & ","
            Next

            wWhere &= " And cs.Centro IN " & String.Format("({0})", ZTipo.Remove(ZTipo.Length - 1, 1))

        End If

        WSql &= wWhere

        '
        ' Ordenamiento.
        '
        Dim WOrden As String = " Order by "

        Select Case cmbOrdenI.SelectedIndex
            Case 2, 4
                WOrden &= IIf(cmbOrdenI.SelectedIndex = 2, "cs.Centro", "cs.ResponsableDestino") & ","
            Case Else
                WOrden &= "cs." & cmbOrdenI.SelectedItem & ","

        End Select

        Select Case cmbOrdenII.SelectedIndex
            Case 2, 4
                WOrden &= IIf(cmbOrdenII.SelectedIndex = 2, "cs.Centro", "cs.ResponsableDestino") & ","
            Case Else
                WOrden &= "cs." & cmbOrdenII.SelectedItem & ","

        End Select

        Select Case cmbOrdenIII.SelectedIndex
            Case 2, 4
                WOrden &= IIf(cmbOrdenIII.SelectedIndex = 2, "cs.Centro", "cs.ResponsableDestino") & ","
            Case Else
                WOrden &= "cs." & cmbOrdenIII.SelectedItem & ","

        End Select

        WSql &= WOrden.Remove(WOrden.Length - 1, 1)

        Dim tabla As DataTable = Query.GetAll(WSql)

        dgvListado.DataSource = tabla

    End Sub

End Class