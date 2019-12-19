Public Class ImpresionEtiquetasMuestras
    Dim tablaInforme As New DataTable


    Private Sub btnVolver_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVolver.Click
        Me.Close()
    End Sub

    Private Sub txtInforme_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtInforme.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                If (txtInforme.Text <> "") Then
                    _BuscarInforme(txtInforme.Text)
                End If


            Case Keys.Escape
                txtInforme.Text = ""
        End Select
    End Sub

    Private Sub mastxtFecha_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles mastxtFecha.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                If (ValidaFecha(mastxtFecha.Text) = "S") Then
                    txtAnalista.Focus()
                Else
                    MsgBox("Ingrese un fecha valida")
                    mastxtFecha.Focus()
                End If

            Case Keys.Escape
                txtInforme.Text = ""
        End Select
    End Sub

    Private Sub mastxtFecha_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mastxtFecha.Leave
        If (ValidaFecha(mastxtFecha.Text) = "S") Then
            txtAnalista.Focus()
        Else
            MsgBox("Ingrese un fecha valida")
            mastxtFecha.Focus()
        End If
    End Sub

    Private Sub txtAnalista_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtAnalista.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                If (txtAnalista.Text <> "") Then
                    TxtCantEtiq.Focus()
                End If
            Case Keys.Escape
                txtAnalista.Text = ""
        End Select

    End Sub


    Private Sub SoloNumero(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCantEtiq.KeyPress, txtInforme.KeyPress
        If Not Char.IsNumber(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub TxtCantEtiq_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCantEtiq.KeyDown

        Select Case e.KeyData

            Case Keys.Escape
                TxtCantEtiq.Text = ""
        End Select

    End Sub

    Private Sub _BuscarInforme(ByVal NumInforme As String)

        Dim SQLCnsl As String
        SQLCnsl = "SELECT Articulo = i.Articulo, DescripcionLista = i.Articulo + ' ' + CASE i.NombreComercial WHEN NULL THEN a.Descripcion ELSE i.NombreComercial END, "
        SQLCnsl = SQLCnsl & "Descripcion = CASE i.NombreComercial WHEN NULL THEN a.Descripcion ELSE i.NombreComercial END, Lote1, Lote2, Lote3, Lote4, Lote5,"
        SQLCnsl = SQLCnsl & "i.Lote6, i.Lote7, i.Lote8, i.Lote9, i.Lote10, i.Lote11, i.Lote12, i.Lote13, i.Lote14, i.Lote15, i.Lote16, i.Lote17, i.Lote18, i.Lote19, i.Lote20 "
        SQLCnsl = SQLCnsl & "FROM Informe AS i INNER JOIN Articulo AS a ON i.Articulo = a.Codigo WHERE i.Informe = '" & txtInforme.Text & "' "
        tablaInforme = GetAll(SQLCnsl)
        LtbMP.DataSource = tablaInforme
        If (LtbMP.Items.Count > 1) Then
            LtbMP.DisplayMember = "DescripcionLista"
            LtbMP.Visible = True
        Else
            If (LtbMP.Items.Count = 1) Then
                txtCodigoMP.Text = CType(LtbMP.SelectedItem, DataRowView).Item("Articulo")
                txtDescripcionMP.Text = CType(LtbMP.SelectedItem, DataRowView).Item("Descripcion")
                LtbLotes.Items.Clear()
                For i As Integer = 1 To 20
                    If (Trim(OrDefault(CType(LtbMP.SelectedItem, DataRowView).Item("Lote" & i), "")) <> "") Then
                        LtbLotes.Items.Add(CType(LtbMP.SelectedItem, DataRowView).Item("Lote" & i))
                    End If
                Next
                If (LtbLotes.Items.Count > 1) Then
                    LtbLotes.Visible = True
                Else
                    If (LtbLotes.Items.Count = 1) Then
                        txtLote.Text = LtbLotes.Items(0)
                        mastxtFecha.Text = Today
                    Else
                        MsgBox("No tiene lote cargados puede cargarlo a mano")
                        txtLote.Enabled = True
                        txtLote.Focus()
                    End If
                End If
            Else
                MsgBox("Este Informe no contiene Materias Primas")
            End If
        End If

    End Sub

    Private Sub _buscarLote()

    End Sub



    Private Sub ImpresionEtiquetasMuestras_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LtbMP.Visible = False
        LtbLotes.Visible = False
        '        With tablaInforme.Columns
        '            .Add("")
        '        End With
    End Sub



    Private Sub LtbMP_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles LtbMP.MouseClick
        txtCodigoMP.Text = CType(LtbMP.SelectedItem, DataRowView).Item("Articulo")
        txtDescripcionMP.Text = CType(LtbMP.SelectedItem, DataRowView).Item("Descripcion")
        LtbMP.Visible = False
        LtbLotes.Items.Clear()
        For i As Integer = 1 To 20
            If (Trim(OrDefault(CType(LtbMP.SelectedItem, DataRowView).Item("Lote" & i), "")) <> "") Then
                LtbLotes.Items.Add(CType(LtbMP.SelectedItem, DataRowView).Item("Lote" & i))
            End If
        Next
        If (LtbLotes.Items.Count > 1) Then
            LtbLotes.Visible = True
        Else
            If (LtbLotes.Items.Count = 1) Then
                txtLote.Text = LtbLotes.Items(0)
                mastxtFecha.Text = Today
                txtAnalista.Focus()
            Else
                MsgBox("No tiene lote cargados puede cargarlo a mano")
                txtLote.Enabled = True
                txtLote.Focus()
            End If
        End If
    End Sub


    Private Sub LtbLotes_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles LtbLotes.MouseClick
        txtLote.Text = LtbLotes.SelectedItem
        LtbLotes.Visible = False
        mastxtFecha.Text = Today
        txtAnalista.Focus()
    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        txtInforme.Text = ""
        txtCodigoMP.Text = ""
        txtDescripcionMP.Text = ""
        txtLote.Text = ""
        mastxtFecha.Text = ""
        txtAnalista.Text = ""
        TxtCantEtiq.Text = ""
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If (_chekeoDatos()) Then
            With New VistaPrevia
                .Reporte = New ReporteImpresionEtiquetasMuestras()
                Dim CantHojas As Double = TxtCantEtiq.Text / 4
                CantHojas = Math.Ceiling(CantHojas)
                Dim contador As Integer = 1
                For i As Integer = 1 To CantHojas
                    .Reporte.SetParameterValue(0, txtCodigoMP.Text)
                    .Reporte.SetParameterValue(1, txtDescripcionMP.Text)
                    .Reporte.SetParameterValue(2, mastxtFecha.Text)
                    .Reporte.SetParameterValue(3, txtLote.Text)
                    .Reporte.SetParameterValue(4, txtAnalista.Text)
                    .Reporte.SetParameterValue(5, TxtCantEtiq.Text)
                    .Reporte.SetParameterValue(6, txtInforme.Text)
                    If (contador > TxtCantEtiq.Text) Then
                        .Reporte.SetParameterValue(7, -1)
                    Else
                        .Reporte.SetParameterValue(7, contador)
                        contador = contador + 1
                    End If
                    If (contador > TxtCantEtiq.Text) Then
                        .Reporte.SetParameterValue(8, -1)
                    Else
                        .Reporte.SetParameterValue(8, contador)
                        contador = contador + 1
                    End If
                    If (contador > TxtCantEtiq.Text) Then
                        .Reporte.SetParameterValue(9, -1)
                    Else
                        .Reporte.SetParameterValue(9, contador)
                        contador = contador + 1
                    End If
                    If (contador > TxtCantEtiq.Text) Then
                        .Reporte.SetParameterValue(10, -1)
                    Else
                        .Reporte.SetParameterValue(10, contador)
                        contador = contador + 1
                    End If
                    .Imprimir()
                Next

            End With
        End If
    End Sub

    Private Function _chekeoDatos() As Boolean
        If (txtInforme.Text <> "" And txtCodigoMP.Text <> "" And txtDescripcionMP.Text <> "") Then
            If (txtLote.Text <> "" And txtAnalista.Text <> "" And mastxtFecha.Text <> "" And TxtCantEtiq.Text <> "") Then
                If (TxtCantEtiq.Text > 0) Then
                    Return True
                End If
            End If
        End If
        Return False
    End Function
End Class