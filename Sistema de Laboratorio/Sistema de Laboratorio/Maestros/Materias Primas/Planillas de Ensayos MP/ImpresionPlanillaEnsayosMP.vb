Imports Util.Interfaces

Public Class ImpresionPlanillaEnsayosMP : Implements Util.Interfaces.IAyudaMPs

    Private Sub btnAyuda_Click(sender As Object, e As EventArgs) Handles btnAyuda.Click
        With New Util.AyudaMPs
            .ShowDialog(Me)
        End With
    End Sub

    Public Sub _ProcesarAyudaMPs(Codigo As String, Descripcion As String) Implements IAyudaMPs._ProcesarAyudaMPs
        txtCodigo.Text = Codigo
        txtCodigo_KeyDown(Nothing, New KeyEventArgs(Keys.Enter))
    End Sub

    Private Sub txtCodigo_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCodigo.KeyDown

        If e.KeyData = Keys.Enter Then

            lblDescripcion.Text = ""
            dgvEspecif.Rows.Clear()

            If txtCodigo.Text.Replace(" ", "").Length > 12 Then : Exit Sub : End If

            Dim WTerminado As DataRow = GetSingle("SELECT Descripcion FROM Articulo WHERE Codigo = '" & txtCodigo.Text & "'")
            If WTerminado Is Nothing Then Exit Sub

            lblDescripcion.Text = Trim(OrDefault(WTerminado.Item("Descripcion"), "")).ToUpper

            '
            ' Chequeamos que se haya cargado el producto por el cual consultar.
            '
            If txtCodigo.Text.Replace(" ", "").Length < 10 Then
                MsgBox("El código de Materia Prima indicado no es correcto.", MsgBoxStyle.Exclamation)
                txtCodigo.Focus()
                Exit Sub
            End If

            '
            ' Verificamos que haya especificaciones cargadas para la etapa indicada.
            '
            _CargarDatosEspecifMP()

            If dgvEspecif.Rows.Count = 0 Then
                MsgBox("No se han actualizado las especificaciones de la Materia Prima al Nuevo Formato.")
                Exit Sub
            End If

        ElseIf e.KeyData = Keys.Escape Then
            txtCodigo.Text = ""
        End If

    End Sub

    Private Sub SoloNumero(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCantPooles.KeyPress
        If Not Char.IsNumber(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Function _TraerDescripcionEnsayo(ByVal _Ens As Object)

        Dim WEns As String = OrDefault(_Ens, "0")

        Dim WBaseII = "Surfactan_II"
        If _EsPellital() Then WBaseII = "Pelitall_II"

        Dim WEnsayo As DataRow = GetSingle("SELECT Descripcion FROM Ensayos WHERE Codigo = '" & WEns & "'", WBaseII)

        If WEnsayo IsNot Nothing Then
            Return Trim(OrDefault(WEnsayo.Item("Descripcion"), ""))
        End If

        Return ""
    End Function


    Private Sub _CargarDatosEspecifMP()

        Dim WEtapa As String = IIf(rbFinal.Checked, "99", "1")

        Dim WCargaV As DataTable = GetAll("SELECT * FROM CargaVMP WHERE Articulo = '" & txtCodigo.Text & "' And Paso = '" & WEtapa & "' Order By Clave", "Surfactan_II")

        dgvEspecif.Rows.Clear()

        If WCargaV.Rows.Count = 0 Then Return

        For Each row As DataRow In WCargaV.Rows
            With row
                Dim WEns = OrDefault(.Item("Ensayo"), 0)
                Dim WEspecificacion = OrDefault(.Item("Valor"), "")
                Dim WTipoEspecif = OrDefault(.Item("TipoEspecif"), "0")
                Dim WDesdeEspecif As String = OrDefault(.Item("DesdeEspecif"), "")
                Dim WHastaEspecif As String = OrDefault(.Item("HastaEspecif"), "")
                Dim WUnidadEspecif = OrDefault(.Item("UnidadEspecif"), "")
                Dim WMenorIgualEspecif = OrDefault(.Item("MenorIgualEspecif"), "0")
                Dim WInformaEspecif = OrDefault(.Item("InformaEspecif"), "0")
                Dim WImpreParametro = _GenerarImpreParametro(WTipoEspecif, WDesdeEspecif, WHastaEspecif, WUnidadEspecif, WMenorIgualEspecif, WInformaEspecif)

                If Val(WTipoEspecif) = 0 And WImpreParametro <> "" Then WImpreParametro &= " (c)"

                Dim r = dgvEspecif.Rows.Add

                With dgvEspecif.Rows(r)
                    .Cells("Ensayo").Value = WEns
                    .Cells("Descripcion").Value = ""
                    .Cells("DescParametros").Value = Trim(WEspecificacion)
                    .Cells("Parametro").Value = Trim(WImpreParametro)
                    .Cells("Var1").Value = OrDefault(row.Item("Variable1"), "")
                    .Cells("Var2").Value = OrDefault(row.Item("Variable2"), "")
                    .Cells("Var3").Value = OrDefault(row.Item("Variable3"), "")
                    .Cells("Var4").Value = OrDefault(row.Item("Variable4"), "")
                    .Cells("Var5").Value = OrDefault(row.Item("Variable5"), "")
                    .Cells("Var6").Value = OrDefault(row.Item("Variable6"), "")
                    .Cells("Var7").Value = OrDefault(row.Item("Variable7"), "")
                    .Cells("Var8").Value = OrDefault(row.Item("Variable8"), "")
                    .Cells("Var9").Value = OrDefault(row.Item("Variable9"), "")
                    .Cells("Var10").Value = OrDefault(row.Item("Variable10"), "")
                End With

            End With

        Next

        For Each row As DataGridViewRow In dgvEspecif.Rows
            With row
                .Cells("Descripcion").Value = _TraerDescripcionEnsayo(.Cells("Ensayo").Value)
            End With
        Next

        txtCantPooles.Enabled = rbPool.Checked

        If rbPool.Checked Then txtCantPooles.Focus()

    End Sub

    Private Function _GenerarImpreParametro(ByVal wTipoEspecif As String, ByVal wDesdeEspecif As String, ByVal wHastaEspecif As String, ByVal wUnidadEspecif As String, ByVal wMenorIgualEspecif As String, ByVal WInformaEspecif As String) As String

        wDesdeEspecif = OrDefault(Trim(wDesdeEspecif), "")
        wHastaEspecif = OrDefault(Trim(wHastaEspecif), "")
        wUnidadEspecif = OrDefault(Trim(wUnidadEspecif), "")
        wMenorIgualEspecif = OrDefault(Trim(wMenorIgualEspecif), "")

        If Val(WInformaEspecif) = 0 And Val(wTipoEspecif) = 2 Then
            If Val(wDesdeEspecif) <> 0 Or Val(wHastaEspecif) <> 9999 Then

                If Val(wDesdeEspecif) <> 0 And Val(wHastaEspecif) = 9999 Then

                    If Val(wMenorIgualEspecif) = 1 Then
                        Return String.Format("Informativo (Mínimo {0} {1})", wDesdeEspecif, wUnidadEspecif)
                    End If

                    Return String.Format("Informativo (Mayor a {0} {1})", wHastaEspecif, wUnidadEspecif)

                End If

                If Val(wDesdeEspecif) <> 0 And Val(wHastaEspecif) <> 0 Then
                    Return String.Format("Informativo ({0} - {1} {2})", wDesdeEspecif, wHastaEspecif, wUnidadEspecif)
                End If

                If Val(wDesdeEspecif) = 0 And Val(wHastaEspecif) <> 0 Then

                    If Val(wMenorIgualEspecif) = 1 Then
                        Return String.Format("Informativo (Máximo {0} {1})", wHastaEspecif, wUnidadEspecif)
                    End If

                    Return String.Format("Informativo (Menor a {0} {1})", wHastaEspecif, wUnidadEspecif)

                End If

            End If
            Return "Informativo"
        End If

        If Val(wDesdeEspecif) = 0 And Val(wHastaEspecif) = 0 Then Return "Cumple Ensayo"

        If Val(wDesdeEspecif) <> 0 Or Val(wHastaEspecif) <> 9999 Then

            If Val(wDesdeEspecif) <> 0 And Val(wHastaEspecif) = 9999 Then

                If Val(wMenorIgualEspecif) = 1 Then Return String.Format("Mínimo {0} {1}", wDesdeEspecif, wUnidadEspecif)

                Return String.Format("Mayor a {0} {1}", wHastaEspecif, wUnidadEspecif)

            End If

            If Val(wDesdeEspecif) <> 0 And Val(wHastaEspecif) <> 0 Then
                Return String.Format("{0} - {1} {2}", wDesdeEspecif, wHastaEspecif, wUnidadEspecif)
            End If

            If Val(wDesdeEspecif) = 0 And Val(wHastaEspecif) <> 0 Then

                If Val(wMenorIgualEspecif) = 1 Then
                    Return String.Format("Máximo {0} {1}", wHastaEspecif, wUnidadEspecif)
                End If

                Return String.Format("Menor a {0} {1}", wHastaEspecif, wUnidadEspecif)

            End If

        End If

        Return ""
    End Function

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        If dgvEspecif.Rows.Count = 0 Then Exit Sub

        Dim Renglon As Integer = 1
        Dim WTabla As DataTable = New DBAuxi.PlanilllaEnsayosDataTable

        txtCantPooles.Text = Val(txtCantPooles.Text)

        If Val(txtCantPooles.Text) = 0 Then txtCantPooles.Text = 1

        Dim WCantPooles As Integer = 0

        For x As Integer = 1 To Val(txtCantPooles.Text)

            WCantPooles += 1

            For Each row As DataGridViewRow In dgvEspecif.Rows
                Dim r As DataRow = WTabla.NewRow
                With r
                    .Item("Ensayo") = row.Cells("Ensayo").Value
                    .Item("DescEnsayo") = row.Cells("Descripcion").Value
                    .Item("DescParametro") = row.Cells("DescParametros").Value
                    .Item("Parametro") = row.Cells("Parametro").Value
                    .Item("Titulo") = "Materia Prima"
                    .Item("Codigo") = txtCodigo.Text
                    .Item("Descripcion") = lblDescripcion.Text
                    .Item("Etapa") = IIf(rbFinal.Checked, "FINAL", "POOL")
                    .Item("Renglon") = Renglon
                    .Item("Variables") = ""
                    .Item("Pool") = IIf(rbFinal.Checked, "", WCantPooles)
                End With
                WTabla.Rows.Add(r)

                If row.Cells("TipoEspecif").Value = 2 Then
                    For i = 1 To 10
                        If Trim(row.Cells("Var" & i).Value) <> "" Then
                            Dim d As DataRow = WTabla.NewRow
                            With d
                                '.Item("Ensayo") = "" 'row.Cells("Ensayo").Value
                                .Item("Variables") = row.Cells("Var" & i).Value
                                .Item("DescParametro") = "" 'row.Cells("DescParametros").Value
                                .Item("Parametro") = "" 'row.Cells("Parametro").Value
                                .Item("Titulo") = "Materia Prima"
                                .Item("Codigo") = txtCodigo.Text
                                .Item("Descripcion") = lblDescripcion.Text
                                .Item("Etapa") = IIf(rbFinal.Checked, "FINAL", "POOL")
                                .Item("Renglon") = Renglon
                                .Item("Pool") = IIf(rbFinal.Checked, "", WCantPooles)
                            End With
                            WTabla.Rows.Add(d)
                        End If
                    Next
                End If

                Renglon += 1
            Next
        Next

        With New Util.VistaPrevia
            .Reporte = New PlanillaEnsayosMP
            .Reporte.SetDataSource(WTabla)
            '.Mostrar()
            .Imprimir()
        End With

    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Close()
    End Sub

    Private Sub ImpresionPlanillaEnsayosMP_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtCodigo.Text = ""
        lblDescripcion.Text = ""
    End Sub

    Private Sub ImpresionPlanillaEnsayosMP_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        txtCodigo.Focus()
    End Sub

    Private Sub rbFinal_Click(sender As Object, e As EventArgs) Handles rbPool.Click, rbFinal.Click
        _CargarDatosEspecifMP()
    End Sub
End Class