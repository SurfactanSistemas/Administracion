Public Class IngresoEspecificacionesPT : Implements IIngresoParametrosEspecificaciones

    Private Sub btnLimpiar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnLimpiar.Click
        For Each control As Control In {txtControlCambios, txtDescTerminado, txtEtapa, txtTerminado, txtTipoProceso}
            control.Text = ""
        Next

        dgvProcedimientos.Rows.Clear()

        txtTerminado.Focus()
    End Sub

    Private Sub IngresoEspecificacionesPT_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        btnLimpiar_Click(Nothing, Nothing)
    End Sub

    Private Sub txtTerminado_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtTerminado.KeyDown

        If e.KeyData = Keys.Enter Then

            txtDescTerminado.Text = ""

            If txtTerminado.Text.Replace(" ", "").Length < 12 Then : Exit Sub : End If

            Dim WTerminado As DataRow = GetSingle("SELECT Descripcion FROM Terminado WHERE Codigo = '" & txtTerminado.Text & "'")

            If WTerminado Is Nothing Then Exit Sub

            txtDescTerminado.Text = WTerminado.Item("Descripcion")

            With txtEtapa
                .Focus()
                .SelectionStart = 0
                .SelectionLength = .Text.Length
            End With

        ElseIf e.KeyData = Keys.Escape Then
            txtTerminado.Text = ""
        End If

    End Sub

    Private Sub txtEtapa_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtEtapa.KeyDown

        If e.KeyData = Keys.Enter Then
            If Val(txtEtapa.Text) = 0 Then : Exit Sub : End If

            Dim WProcedimientos As DataTable = GetAll("SELECT Articulo, PTerminado, Letra, Descripcion, Cantidad FROM CargaIII WHERE Terminado = '" & txtTerminado.Text & "' AND Paso = '" & txtEtapa.Text & "' AND ISNULL(Tipo, '') <> 'N' Order By Terminado, Paso, Renglon")

            For Each r As DataRow In WProcedimientos.Rows

                Dim WArticulo As String = OrDefault(r.Item("Articulo"), "")
                Dim WTerminado As String = OrDefault(r.Item("PTerminado"), "")
                Dim WLetra As String = OrDefault(r.Item("Letra"), "")
                Dim WDescripcion As String = OrDefault(r.Item("Descripcion"), "")
                Dim WCantidad As String = OrDefault(r.Item("Cantidad"), "0")

                Dim _r = dgvProcedimientos.Rows.Add

                With dgvProcedimientos.Rows(_r)
                    .Cells("Articulo").Value = WArticulo
                    .Cells("Terminado").Value = WTerminado
                    .Cells("Letra").Value = WLetra
                    .Cells("Descripcion").Value = WDescripcion
                    .Cells("Cantidad").Value = formatonumerico(WCantidad, 4)
                End With

            Next

            Dim WCargaV As DataTable = GetAll("SELECT * FROM CargaV WHERE Terminado = '" & txtTerminado.Text & "' And Paso = '" & txtEtapa.Text & "' Order By Clave")

            If WCargaV.Rows.Count = 0 Then Exit Sub

            dgvEspecif.Rows.Clear()

            For Each row As DataRow In WCargaV.Rows
                With row
                    Dim WEns = OrDefault(.Item("Ensayo"), 0)
                    Dim WEspecificacion = OrDefault(.Item("Valor"), "")
                    Dim WFarmacopea = OrDefault(.Item("Farmacopea"), "")
                    Dim WTipoEspecif = OrDefault(.Item("TipoEspecif"), "0")
                    Dim WDesdeEspecif = OrDefault(.Item("DesdeEspecif"), "")
                    Dim WHastaEspecif = OrDefault(.Item("HastaEspecif"), "")
                    Dim WUnidadEspecif = OrDefault(.Item("UnidadEspecif"), "")
                    Dim WMenorIgualEspecif = OrDefault(.Item("MenorIgualEspecif"), "0")
                    Dim WInformaEspecif = OrDefault(.Item("InformaEspecif"), "0")
                    Dim WImpreParametro = _GenerarImpreParametro(WTipoEspecif, WDesdeEspecif, WHastaEspecif, WUnidadEspecif, WMenorIgualEspecif)

                    If Val(WTipoEspecif) = 0 And WImpreParametro <> "" Then WImpreParametro &= " (c)"

                    Dim r = dgvEspecif.Rows.Add

                    With dgvEspecif.Rows(r)
                        .Cells("Ensayo").Value = WEns
                        .Cells("Especificacion").Value = ""
                        .Cells("DescEnsayo").Value = Trim(WEspecificacion)
                        .Cells("Farmacopea").Value = Trim(WFarmacopea)
                        .Cells("TipoEspecif").Value = WTipoEspecif
                        .Cells("DesdeEspecif").Value = WDesdeEspecif
                        .Cells("HastaEspecif").Value = WHastaEspecif
                        .Cells("UnidadEspecif").Value = WUnidadEspecif
                        .Cells("MenorIgualEspecif").Value = WMenorIgualEspecif
                        .Cells("InformaEspecif").Value = WInformaEspecif
                        .Cells("Parametro").Value = Trim(WImpreParametro)
                    End With

                End With

            Next

            Dim WBaseII As String = "Surfactan_II"

            If _EsPellital() Then WBaseII = "Pelitall_II"

            For Each row As DataGridViewRow In dgvEspecif.Rows
                With row
                    Dim WEns As String = OrDefault(.Cells("Ensayo").Value, "0")
                    Dim WEnsayo As DataRow = GetSingle("SELECT Descripcion FROM Ensayos WHERE Codigo = '" & WEns & "'", WBaseII)

                    If WEnsayo IsNot Nothing Then .Cells("Especificacion").Value = Trim(OrDefault(WEnsayo.Item("Descripcion"), ""))

                End With
            Next

        ElseIf e.KeyData = Keys.Escape Then
            txtEtapa.Text = ""
        End If

    End Sub

    Private Function _GenerarImpreParametro(ByVal wTipoEspecif As Object, ByVal wDesdeEspecif As Object, ByVal wHastaEspecif As Object, ByVal wUnidadEspecif As Object, ByVal wMenorIgualEspecif As Object) As String
        If Trim(wDesdeEspecif) = "" And Trim(wHastaEspecif) = "" Then Return ""

        wTipoEspecif = Trim(wTipoEspecif)
        wDesdeEspecif = Trim(wDesdeEspecif)
        wHastaEspecif = Trim(wHastaEspecif)
        wUnidadEspecif = Trim(wUnidadEspecif)
        wMenorIgualEspecif = Trim(wMenorIgualEspecif)

        If Val(wDesdeEspecif) <> 0 Or Val(wHastaEspecif) <> 9999 Then

            If Val(wDesdeEspecif) <> 0 And Val(wHastaEspecif) <> 0 Then
                Return String.Format("{0} - {1} {2}", wDesdeEspecif, wHastaEspecif, wUnidadEspecif)
            End If

            If Val(wDesdeEspecif) = 0 And Val(wHastaEspecif) <> 0 Then

                If Val(wMenorIgualEspecif) = 1 Then Return String.Format("Máximo {0} {1}", wHastaEspecif, wUnidadEspecif)

                Return String.Format("Menor a {0} {1}", wHastaEspecif, wUnidadEspecif)

            End If

            If Val(wDesdeEspecif) <> 0 And Val(wHastaEspecif) = 9999 Then

                If Val(wMenorIgualEspecif) = 1 Then Return String.Format("Mínimo {0} {1}", wHastaEspecif, wUnidadEspecif)

                Return String.Format("Mayor a {0} {1}", wHastaEspecif, wUnidadEspecif)

            End If

        End If

        Return ""
    End Function

    Private Sub btnSalir_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSalir.Click
        If MsgBox("¿Está seguro de querer cerrar la ventana? " & vbCrLf & vbCrLf & " Todos los datos que no hayan sido guardados, se perderán.", MsgBoxStyle.YesNo) <> MsgBoxResult.Yes Then Exit Sub
        Close()
    End Sub

    Private Sub dgvEspecif_CellDoubleClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles dgvEspecif.CellDoubleClick
        If e.RowIndex < 0 Then Exit Sub

        With dgvEspecif.CurrentRow

            Dim WTipo As Integer = Val(OrDefault(.Cells("TipoEspecif").Value, 0))
            Dim WInforma As Integer = Val(OrDefault(.Cells("InformaEspecif").Value, 0))
            Dim WDesde As Double = Trim(OrDefault(.Cells("DesdeEspecif").Value, "0")).toDbl
            Dim WHasta As Double = Trim(OrDefault(.Cells("HastaEspecif").Value, "0")).toDbl
            Dim WMenorIgual As Integer = Val(OrDefault(.Cells("MenorIgualEspecif").Value, 0))
            Dim WUnidad As String = OrDefault(.Cells("UnidadEspecif").Value, "")
            Dim WFarmacopea As String = OrDefault(.Cells("Farmacopea").Value, "")
            Dim WEnsayo As Integer = OrDefault(.Cells("Ensayo").Value, 0)
            Dim WDescEnsayo As String = OrDefault(.Cells("Especificacion").Value, "")
            Dim WParametro As String = OrDefault(.Cells("DescEnsayo").Value, "")
            Dim WFormula As String = OrDefault(.Cells("FormulaEspecif").Value, "")
            Dim WParametrosFormula(10) As String

            For i = 1 To 10
                WParametrosFormula(i) = Trim(OrDefault(.Cells("Variable" & i).Value, ""))
            Next

            Dim frm As New IngresoParametrosEspecificaciones(WEnsayo, WDescEnsayo, WParametro, WTipo, WInforma, WMenorIgual, WDesde, WHasta, WUnidad, WFarmacopea, WFormula, WParametrosFormula)
            frm.ShowDialog(Me)

        End With

    End Sub

    Public Sub _ProcesarIngresoParametrosEspecificaciones(ByVal WParametro As String, ByVal Tipo As Integer, ByVal Informa As Integer, ByVal MenorIgual As Integer, ByVal Desde As Double, ByVal Hasta As Double, ByVal Unidad As String, ByVal WFarmacopea As String, ByVal Formula As String, ByVal ParametrosFormula() As String) Implements IIngresoParametrosEspecificaciones._ProcesarIngresoParametrosEspecificaciones
        With dgvEspecif.CurrentRow
            .Cells("DescEnsayo").Value = WParametro
            .Cells("TipoEspecif").Value = Tipo
            .Cells("InformaEspecif").Value = Informa
            .Cells("DesdeEspecif").Value = Desde.ToString.Replace(",", ".")
            .Cells("HastaEspecif").Value = Hasta.ToString.Replace(",", ".")
            .Cells("MenorIgualEspecif").Value = MenorIgual
            .Cells("UnidadEspecif").Value = Unidad
            .Cells("Farmacopea").Value = WFarmacopea
            .Cells("FormulaEspecif").Value = WFarmacopea

            For i = 1 To ParametrosFormula.Count - 1
                .Cells("Variable" & i).Value = Trim(ParametrosFormula(i))
            Next

        End With

    End Sub
End Class