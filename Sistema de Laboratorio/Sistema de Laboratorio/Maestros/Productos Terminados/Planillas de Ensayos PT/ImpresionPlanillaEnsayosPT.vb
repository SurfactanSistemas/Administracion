Imports Util
Imports Util.Interfaces

Public Class ImpresionPlanillaEnsayosPT : Implements IAyudaPTs

    Private Sub btnAyuda_Click(sender As Object, e As EventArgs) Handles btnAyuda.Click
        With New AyudaPTs
            .ShowDialog(Me)
        End With
    End Sub

    Public Sub _ProcesarAyudaPTs(Codigo As String, wDescripcion As String) Implements IAyudaPTs._ProcesarAyudaPTs
        txtCodigo.Text = Codigo
        txtCodigo_KeyDown(Nothing, New KeyEventArgs(Keys.Enter))
        If Val(txtEtapa.Text) <> 0 Then txtEtapa_KeyDown(Nothing, New KeyEventArgs(Keys.Enter))
    End Sub

    Private Sub txtCodigo_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCodigo.KeyDown

        If e.KeyData = Keys.Enter Then

            lblDescTerminado.Text = ""
            dgvEspecif.Rows.Clear()

            If txtCodigo.Text.Replace(" ", "").Length > 12 Then : Exit Sub : End If

            Dim WTerminado As DataRow = GetSingle("SELECT Descripcion FROM Terminado WHERE Codigo = '" & txtCodigo.Text & "'")
            If WTerminado Is Nothing Then Exit Sub

            lblDescTerminado.Text = Trim(OrDefault(WTerminado.Item("Descripcion"), "")).ToUpper

            '
            ' Determino si es un Código de Producto para Planta 3.
            '
            If Not _EsProductoPlanta3() Then
                txtEtapa.Text = "99"
            End If

            If Val(txtEtapa.Text) > 0 Then txtEtapa_KeyDown(Nothing, New KeyEventArgs(Keys.Enter))

            txtEtapa.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtCodigo.Text = ""
        End If

    End Sub

    Private Function _EsProductoPlanta3() As Boolean
        Dim WCodigo As Integer = Val(Mid(txtCodigo.Text, 4, 5))

        Return (WCodigo >= 25000 And WCodigo <= 259999) Or (WCodigo >= 3000 And WCodigo <= 3999)

    End Function

    Private Sub NumerosConComas(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtEtapa.KeyPress
        If Not Char.IsNumber(e.KeyChar) And Not Char.IsControl(e.KeyChar) And Not (CChar(".")) = e.KeyChar Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtEtapa_KeyDown(sender As Object, e As KeyEventArgs) Handles txtEtapa.KeyDown

        If e.KeyData = Keys.Enter Then
            If Val(txtEtapa.Text) = 0 Then : Exit Sub : End If

            '
            ' Chequeamos que se haya cargado el producto por el cual consultar.
            '
            If txtCodigo.Text.Replace(" ", "").Length < 12 Then
                MsgBox("El Producto Terminado indicado no es un código correcto.", MsgBoxStyle.Exclamation)
                txtCodigo.Focus()
                Exit Sub
            End If

            '
            ' Verificamos que haya especificaciones cargadas para la etapa indicada.
            '
            If _EsProductoPlanta3() Then
                _CargarDatosEspecifFarma()
            Else
                _CargarDatosEspecifNoFarma()
            End If

            For Each row As DataGridViewRow In dgvEspecif.Rows
                With row
                    .Cells("Descripcion").Value = _TraerDescripcionEnsayo(.Cells("Ensayo").Value)
                End With
            Next

        ElseIf e.KeyData = Keys.Escape Then
            txtEtapa.Text = ""
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

    Private Sub _CargarDatosEspecifNoFarma()

        Dim WCargaVNoFarma As DataTable = GetAll("SELECT * FROM CargaVNoFarma WHERE Terminado = '" & txtCodigo.Text & "' And Paso = '" & txtEtapa.Text & "' Order By Clave", "Surfactan_II")

        dgvEspecif.Rows.Clear()

        If WCargaVNoFarma.Rows.Count > 0 Then

            For Each row As DataRow In WCargaVNoFarma.Rows
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
                        .Cells("TipoEspecif").Value = OrDefault(row.Item("TipoEspecif"), 0)
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

        Else

            '
            ' Traemos los datos en el formato viejo y lo ajustamos para presentarlo como el nuevo.
            '
            Dim WEspecificacionesUnifica As DataRow = GetSingle("SELECT * FROM EspecifUnifica WHERE Producto = '" & txtCodigo.Text & "'", "Surfactan_II")


            '
            ' Creamos la Tabla en memoria.
            '
            Dim WCargaVFormatoViejo As New DataTable
            Dim WCargaVFormatoViejoIngles As New DataTable

            For Each c As String In {"Ensayo", "Valor", "ControlCambio", "Farmacopea", "TipoEspecif", "DesdeEspecif", "HastaEspecif", "UnidadEspecif", "MenorIgualEspecif", "InformaEspecif", "FormulaEspecif"}
                WCargaVFormatoViejo.Columns.Add(c)
                WCargaVFormatoViejoIngles.Columns.Add(c)
            Next

            For i = 1 To 10
                WCargaVFormatoViejo.Columns.Add("Variable" & i)
            Next

            If WEspecificacionesUnifica Is Nothing Then
                dgvEspecif.Rows.Clear()
                dgvEspecif.Rows.Add()
                dgvEspecif.Focus()
                Exit Sub
            End If

            '
            ' Transformamos la información vieja al Formato nuevo.
            '
            Dim WEnsayo, WValor, WDesde, WHasta, WTipoEspecif, WInformaEspecif As String

            For i = 1 To 10

                With WEspecificacionesUnifica

                    WEnsayo = Trim(OrDefault(.Item("Ensayo" & i), ""))

                    If Val(WEnsayo) = 0 Then Continue For

                    WValor = Trim(OrDefault(.Item("Valor" & i), ""))
                    WDesde = Trim(OrDefault(.Item("Desde" & i), ""))
                    WHasta = Trim(OrDefault(.Item("Hasta" & i), ""))

                    WTipoEspecif = IIf(WDesde = "" And WHasta = "", "0", "1")
                    WInformaEspecif = IIf(Val(WTipoEspecif) = 0, "0", "1")

                End With

                Dim r As DataRow = WCargaVFormatoViejo.NewRow

                With r
                    .Item("Ensayo") = WEnsayo
                    .Item("Valor") = WValor
                    .Item("DesdeEspecif") = WDesde
                    .Item("HastaEspecif") = WHasta
                    .Item("TipoEspecif") = WTipoEspecif
                    .Item("InformaEspecif") = WInformaEspecif
                End With

                WCargaVFormatoViejo.Rows.Add(r)

            Next

            _PoblarEspecificaciones(WCargaVFormatoViejo)

            'HAGO LO MISMO PARA LOS DOBLE NUMERO

            For i = 1 To 10

                With WEspecificacionesUnifica

                    WEnsayo = Trim(OrDefault(.Item("Ensayo" & i), ""))

                    If Val(WEnsayo) = 0 Then Continue For

                    WValor = Trim(OrDefault(.Item("Valor" & i), ""))
                    WDesde = Trim(OrDefault(.Item("Desde" & i), ""))
                    WHasta = Trim(OrDefault(.Item("Hasta" & i), ""))

                    WTipoEspecif = IIf(WDesde = "" And WHasta = "", "0", "1")
                    WInformaEspecif = IIf(Val(WTipoEspecif) = 0, "0", "1")

                End With

                Dim r As DataRow = WCargaVFormatoViejo.NewRow

                With r
                    .Item("Ensayo") = WEnsayo
                    .Item("Valor") = WValor
                    .Item("DesdeEspecif") = WDesde
                    .Item("HastaEspecif") = WHasta
                    .Item("TipoEspecif") = WTipoEspecif
                    .Item("InformaEspecif") = WInformaEspecif
                End With

                WCargaVFormatoViejo.Rows.Add(r)

            Next

        End If

    End Sub


    Private Sub _PoblarEspecificaciones(WCargaV As DataTable)

        dgvEspecif.Rows.Clear()

        '
        ' En caso de tener datos en el formato nuevo, los cargamos. Sino traemos y parseamos los datos del formato viejo al nuevo.
        '
        If WCargaV.Rows.Count > 0 Then

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
                        .Cells("TipoEspecif").Value = OrDefault(row.Item("TipoEspecif"), 0)
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

            dgvEspecif.Rows.Add()

        End If
    End Sub

    Private Sub _CargarDatosEspecifFarma()

        Dim WCargaV As DataTable = GetAll("SELECT * FROM CargaV WHERE Terminado = '" & txtCodigo.Text & "' And Paso = '" & txtEtapa.Text & "' Order By Clave", "Surfactan_III")

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
                    .Cells("TipoEspecif").Value = OrDefault(row.Item("TipoEspecif"), 0)
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

    End Sub

    Private Function _GenerarImpreParametro(ByVal WTipoEspecif As String, ByVal wDesdeEspecif As String, ByVal wHastaEspecif As String, ByVal wUnidadEspecif As String, ByVal wMenorIgualEspecif As String, ByVal WInformaEspecif As String) As String

        WTipoEspecif = OrDefault(Trim(WTipoEspecif), "")
        wDesdeEspecif = OrDefault(Trim(wDesdeEspecif), "")
        wHastaEspecif = OrDefault(Trim(wHastaEspecif), "")
        wUnidadEspecif = OrDefault(Trim(wUnidadEspecif), "")
        wMenorIgualEspecif = OrDefault(Trim(wMenorIgualEspecif), "")

        If Val(WInformaEspecif) = 0 And Val(WTipoEspecif) = 2 Then
            If Val(wDesdeEspecif) <> 0 Or Val(wHastaEspecif) <> 9999 Then

                If Val(wDesdeEspecif) <> 0 And Val(wHastaEspecif) <> 0 Then
                    Return String.Format("Informativo ({0} - {1} {2})", wDesdeEspecif, wHastaEspecif, wUnidadEspecif)
                End If

                If Val(wDesdeEspecif) = 0 And Val(wHastaEspecif) <> 0 Then

                    If Val(wMenorIgualEspecif) = 1 Then
                        Return String.Format("Informativo (Máximo {0} {1})", wHastaEspecif, wUnidadEspecif)
                    End If

                    Return String.Format("Informativo (Menor a {0} {1})", wHastaEspecif, wUnidadEspecif)

                End If

                If Val(wDesdeEspecif) <> 0 And Val(wHastaEspecif) = 9999 Then

                    If Val(wMenorIgualEspecif) = 1 Then
                        Return String.Format("Informativo (Mínimo {0} {1})", wDesdeEspecif, wUnidadEspecif)
                    End If

                    Return String.Format("Informativo (Mayor a {0} {1})", wHastaEspecif, wUnidadEspecif)

                End If

            End If
            Return "Informativo"
        End If

        If Val(wDesdeEspecif) = 0 And Val(wHastaEspecif) = 0 Then Return "Cumple Ensayo"

        If Val(wDesdeEspecif) <> 0 Or Val(wHastaEspecif) <> 9999 Then

            If Val(wDesdeEspecif) <> 0 And Val(wHastaEspecif) <> 0 Then
                Return String.Format("{0} - {1} {2}", wDesdeEspecif, wHastaEspecif, wUnidadEspecif)
            End If

            If Val(wDesdeEspecif) = 0 And Val(wHastaEspecif) <> 0 Then

                If Val(wMenorIgualEspecif) = 1 Then
                    Return String.Format("Máximo {0} {1}", wHastaEspecif, wUnidadEspecif)
                End If

                Return String.Format("Menor a {0} {1}", wHastaEspecif, wUnidadEspecif)

            End If

            If Val(wDesdeEspecif) <> 0 And Val(wHastaEspecif) = 9999 Then

                If Val(wMenorIgualEspecif) = 1 Then
                    Return String.Format("Mínimo {0} {1}", wDesdeEspecif, wUnidadEspecif)
                End If

                Return String.Format("Mayor a {0} {1}", wHastaEspecif, wUnidadEspecif)

            End If

        End If

        Return ""
    End Function

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        If dgvEspecif.Rows.Count = 0 Then Exit Sub

        Dim Renglon As Integer = 1
        Dim WTabla As DataTable = New DBAuxi.PlanilllaEnsayosDataTable

        For Each row As DataGridViewRow In dgvEspecif.Rows
            Dim r As DataRow = WTabla.NewRow

            With r
                .Item("Ensayo") = row.Cells("Ensayo").Value
                .Item("DescEnsayo") = row.Cells("Descripcion").Value
                .Item("DescParametro") = row.Cells("DescParametros").Value
                .Item("Parametro") = row.Cells("Parametro").Value
                .Item("Titulo") = "Producto Terminado"
                .Item("Codigo") = txtCodigo.Text
                .Item("Descripcion") = lblDescTerminado.Text
                .Item("Etapa") = txtEtapa.Ceros(2)
                .Item("Renglon") = Renglon
                .Item("Variables") = ""
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
                            .Item("Titulo") = "Producto Terminado"
                            .Item("Codigo") = txtCodigo.Text
                            .Item("Descripcion") = lblDescTerminado.Text
                            .Item("Etapa") = txtEtapa.Ceros(2)
                            .Item("Renglon") = Renglon
                        End With
                        WTabla.Rows.Add(d)
                    End If
                Next
            End If


            Renglon += 1
        Next

        With New Util.VistaPrevia
            .Reporte = New PlanillaEnsayos
            .Reporte.SetDataSource(WTabla)
            '.Mostrar()
            .Imprimir()
        End With

    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Close()
    End Sub

    Private Sub ImpresionPlanillaEnsayosPT_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtCodigo.Text = ""
        txtEtapa.Text = ""
        lblDescTerminado.Text = ""
    End Sub

    Private Sub ImpresionPlanillaEnsayosPT_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        txtCodigo.Focus()
    End Sub
End Class