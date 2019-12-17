Imports System.IO
Imports ConsultasVarias
Imports ConsultasVarias.Interfaces

Public Class IngresoEspecificacionesPT : Implements IIngresoParametrosEspecificaciones, IListaConsultas, IAyudaPTs, IAyudaEnsayos, IIngresoClaveSeguridad

    Enum TipoProcesosIngEspecif
        Revalida
        GrabaVersion
    End Enum

    Private WAutorizado As Boolean = False
    Private WTipoProceso As TipoProcesosIngEspecif = Nothing

    Private Sub btnLimpiar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnLimpiar.Click
        For Each control As Control In {txtControlCambios, txtDescTerminado, txtEtapa, txtTerminado, txtTipoProceso, txtDescEtapa}
            control.Text = ""
        Next

        dgvProcedimientos.Rows.Clear()
        dgvEspecif.Rows.Clear()
        dgvEspecifIngles.Rows.Clear()

        TabControl1.SelectTab(1)

        WAutorizado = False
        WTipoProceso = Nothing

        btnHistorialCambios.Visible = False

        txtTerminado.Focus()
    End Sub

    Private Sub IngresoEspecificacionesPT_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        btnLimpiar_Click(Nothing, Nothing)
    End Sub

    Private Sub txtTerminado_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtTerminado.KeyDown

        If e.KeyData = Keys.Enter Then

            txtDescTerminado.Text = ""

            If txtTerminado.Text.Replace(" ", "").Length < 12 Then Exit Sub

            If Operador.Base <> "Surfactan_III" Then

                _CargarDatosPTNoFarma()

            Else
                _CargarDatosPTFarma()
            End If

        ElseIf e.KeyData = Keys.Escape Then
            txtTerminado.Text = ""
        End If

    End Sub

    Private Sub _CargarDatosPTNoFarma()

        Dim WTerminado As DataRow = GetSingle("SELECT Descripcion FROM Terminado Where Codigo = '" & txtTerminado.Text & "'")

        If WTerminado IsNot Nothing Then
            txtEtapa.Text = "99"
            txtDescTerminado.Text = Trim(OrDefault(WTerminado.Item("Descripcion"), "")).ToUpper
            txtEtapa_KeyDown(Nothing, New KeyEventArgs(Keys.Enter))
        End If

    End Sub

    Private Sub _CargarDatosPTFarma()

        Dim WCodigo = txtTerminado.Text

        btnLimpiar_Click(Nothing, Nothing)

        txtTerminado.Text = WCodigo

        If txtTerminado.Text.Replace(" ", "").Length < 12 Then : Return : End If

        Dim WTerminado As DataRow = GetSingle("SELECT Descripcion FROM Terminado WHERE Codigo = '" & txtTerminado.Text & "'")

        If WTerminado Is Nothing Then Return

        txtDescTerminado.Text = WTerminado.Item("Descripcion")

        With txtEtapa
            .Focus()
            .SelectionStart = 0
            .SelectionLength = .Text.Length
        End With

    End Sub

    Private Sub txtEtapa_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtEtapa.KeyDown

        If e.KeyData = Keys.Enter Then

            If Val(txtEtapa.Text) = 0 Then : Exit Sub : End If

            If Operador.Base = "Surfactan_III" Then
                _CargarDatosEspecifFarma()
            Else
                _CargarDatosEspecifNoFarma()
            End If

            Dim WBaseII = "Surfactan_II"

            If _EsPellital() Then WBaseII = "Pelitall_II"

            For Each row As DataGridViewRow In dgvEspecif.Rows
                With row
                    Dim WEns As String = OrDefault(.Cells("Ensayo").Value, "0")
                    Dim WEnsayo As DataRow = GetSingle("SELECT Descripcion FROM Ensayos WHERE Codigo = '" & WEns & "'", WBaseII)

                    If WEnsayo IsNot Nothing Then
                        .Cells("Especificacion").Value = Trim(OrDefault(WEnsayo.Item("Descripcion"), ""))

                        If Val(txtEtapa.Text) = 99 And Operador.Base = "Surfactan_III" Then dgvEspecifIngles.Rows(.Index).Cells("EspecificacionIngles").Value = Trim(OrDefault(WEnsayo.Item("Descripcion"), ""))

                    End If

                End With
            Next

        ElseIf e.KeyData = Keys.Escape Then
            txtEtapa.Text = ""
        End If

    End Sub

    Private Sub _CargarDatosEspecifNoFarma()
        
        Dim WCargaVNoFarma As DataTable = GetAll("SELECT * FROM CargaVNoFarma WHERE Terminado = '" & txtTerminado.Text & "' And Paso = '" & txtEtapa.Text & "' Order By Clave", "Surfactan_II")

        dgvEspecif.Rows.Clear()

        If WCargaVNoFarma.Rows.Count = 0 Then Return

        For Each row As DataRow In WCargaVNoFarma.Rows
            With row
                Dim WEns = OrDefault(.Item("Ensayo"), 0)
                Dim WEspecificacion = OrDefault(.Item("Valor"), "")
                Dim WControlCambio = OrDefault(.Item("ControlCambio"), "")
                Dim WFarmacopea = OrDefault(.Item("Farmacopea"), "")
                Dim WTipoEspecif = OrDefault(.Item("TipoEspecif"), "0")
                Dim WDesdeEspecif As String = OrDefault(.Item("DesdeEspecif"), "")
                Dim WHastaEspecif As String = OrDefault(.Item("HastaEspecif"), "")
                Dim WUnidadEspecif = OrDefault(.Item("UnidadEspecif"), "")
                Dim WMenorIgualEspecif = OrDefault(.Item("MenorIgualEspecif"), "0")
                Dim WInformaEspecif = OrDefault(.Item("InformaEspecif"), "0")
                Dim WFormulaEspecif = OrDefault(.Item("FormulaEspecif"), "")
                Dim WImpreParametro = _GenerarImpreParametro(WTipoEspecif, WDesdeEspecif, WHastaEspecif, WUnidadEspecif, WMenorIgualEspecif)

                If Val(WTipoEspecif) = 0 And WImpreParametro <> "" Then WImpreParametro &= " (c)"

                Dim r = dgvEspecif.Rows.Add

                txtControlCambios.Text = Trim(WControlCambio)

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
                    .Cells("FormulaEspecif").Value = WFormulaEspecif

                    For i = 1 To 10
                        .Cells("Variable" & i).Value = Trim(OrDefault(row.Item("Variable" & i), ""))
                    Next

                End With

            End With

        Next

        dgvEspecifIngles.Rows.Clear()

        btnHistorialCambios.Visible = (Operador.Base = "Surfactan_III" And Val(txtEtapa.Text) = 99) Or Operador.Base <> "Surfactan_III"

        If Val(txtEtapa.Text) = 99 Then

            '
            ' Para cargar unicamente cuando se este consultando las especificaciones de etapa 99.
            '
            Dim WCargaVIngles As DataTable = GetAll("SELECT Valor, Farmacopea, UnidadEspecif FROM CargaVNoFarmaIngles WHERE Terminado = '" & txtTerminado.Text & "' And Paso = '99' Order By Clave", "Surfactan_II")

            If WCargaVIngles.Rows.Count = 0 Then Return

            For Each row As DataRow In WCargaVIngles.Rows
                With row
                    Dim WEspecificacion = Trim(OrDefault(.Item("Valor"), ""))
                    Dim WFarmacopea = Trim(OrDefault(.Item("Farmacopea"), ""))
                    Dim WUnidadEspecif = Trim(OrDefault(.Item("UnidadEspecif"), ""))

                    Dim r = dgvEspecifIngles.Rows.Add

                    With dgvEspecifIngles.Rows(r)
                        .Cells("EnsayoIngles").Value = dgvEspecif.Rows(r).Cells("Ensayo").Value
                        .Cells("EspecificacionIngles").Value = ""
                        .Cells("DescEnsayoIngles").Value = Trim(WEspecificacion)
                        .Cells("FarmacopeaIngles").Value = Trim(WFarmacopea)
                        .Cells("UnidadEspecifIngles").Value = WUnidadEspecif
                    End With

                End With

            Next

        End If

        TabControl1.SelectTab(1)

    End Sub

    Private Sub _CargarDatosEspecifFarma()

        Dim WProcedimientos As DataTable = GetAll("SELECT Articulo, PTerminado, Letra, Descripcion, Cantidad, TipoProceso, DesEtapa FROM CargaIII WHERE Terminado = '" & txtTerminado.Text & "' AND Paso = '" & txtEtapa.Text & "' AND ISNULL(Tipo, '') <> 'N' Order By Terminado, Paso, Renglon")

        dgvProcedimientos.Rows.Clear()

        For Each r As DataRow In WProcedimientos.Rows

            Dim WArticulo As String = OrDefault(r.Item("Articulo"), "")
            Dim WTerminado As String = OrDefault(r.Item("PTerminado"), "")
            Dim WLetra As String = OrDefault(r.Item("Letra"), "")
            Dim WDescripcion As String = OrDefault(r.Item("Descripcion"), "")
            Dim WCantidad As String = OrDefault(r.Item("Cantidad"), "0")
            Dim WTipoProceso As String = Trim(OrDefault(r.Item("TipoProceso"), ""))
            Dim WDescEtapa As String = Trim(OrDefault(r.Item("DesEtapa"), ""))

            Dim _r = dgvProcedimientos.Rows.Add

            txtTipoProceso.Text = WTipoProceso
            txtDescEtapa.Text = WDescEtapa

            With dgvProcedimientos.Rows(_r)
                .Cells("Articulo").Value = WArticulo
                .Cells("Terminado").Value = WTerminado
                .Cells("Letra").Value = WLetra
                .Cells("Descripcion").Value = WDescripcion
                .Cells("Cantidad").Value = formatonumerico(WCantidad, 4)
            End With

        Next

        Dim WCargaV As DataTable = GetAll("SELECT * FROM CargaV WHERE Terminado = '" & txtTerminado.Text & "' And Paso = '" & txtEtapa.Text & "' Order By Clave")

        dgvEspecif.Rows.Clear()

        If WCargaV.Rows.Count = 0 Then Return

        For Each row As DataRow In WCargaV.Rows
            With row
                Dim WEns = OrDefault(.Item("Ensayo"), 0)
                Dim WEspecificacion = OrDefault(.Item("Valor"), "")
                Dim WControlCambio = OrDefault(.Item("ControlCambio"), "")
                Dim WFarmacopea = OrDefault(.Item("Farmacopea"), "")
                Dim WTipoEspecif = OrDefault(.Item("TipoEspecif"), "0")
                Dim WDesdeEspecif As String = OrDefault(.Item("DesdeEspecif"), "")
                Dim WHastaEspecif As String = OrDefault(.Item("HastaEspecif"), "")
                Dim WUnidadEspecif = OrDefault(.Item("UnidadEspecif"), "")
                Dim WMenorIgualEspecif = OrDefault(.Item("MenorIgualEspecif"), "0")
                Dim WInformaEspecif = OrDefault(.Item("InformaEspecif"), "0")
                Dim WFormulaEspecif = OrDefault(.Item("FormulaEspecif"), "")
                Dim WImpreParametro = _GenerarImpreParametro(WTipoEspecif, WDesdeEspecif, WHastaEspecif, WUnidadEspecif, WMenorIgualEspecif)

                If Val(WTipoEspecif) = 0 And WImpreParametro <> "" Then WImpreParametro &= " (c)"

                Dim r = dgvEspecif.Rows.Add

                txtControlCambios.Text = Trim(WControlCambio)

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
                    .Cells("FormulaEspecif").Value = WFormulaEspecif

                    For i = 1 To 10
                        .Cells("Variable" & i).Value = Trim(OrDefault(row.Item("Variable" & i), ""))
                    Next

                End With

            End With

        Next

        dgvEspecifIngles.Rows.Clear()

        btnHistorialCambios.Visible = (Operador.Base = "Surfactan_III" And Val(txtEtapa.Text) = 99) Or Operador.Base <> "Surfactan_III"

        If Val(txtEtapa.Text) = 99 Then

            '
            ' Para cargar unicamente cuando se este consultando las especificaciones de etapa 99.
            '
            Dim WCargaVIngles As DataTable = GetAll("SELECT Valor, Farmacopea, UnidadEspecif FROM CargaVIngles WHERE Terminado = '" & txtTerminado.Text & "' And Paso = '99' Order By Clave")

            If WCargaVIngles.Rows.Count = 0 Then Return

            For Each row As DataRow In WCargaVIngles.Rows
                With row
                    Dim WEspecificacion = Trim(OrDefault(.Item("Valor"), ""))
                    Dim WFarmacopea = Trim(OrDefault(.Item("Farmacopea"), ""))
                    Dim WUnidadEspecif = Trim(OrDefault(.Item("UnidadEspecif"), ""))

                    Dim r = dgvEspecifIngles.Rows.Add

                    With dgvEspecifIngles.Rows(r)
                        .Cells("EnsayoIngles").Value = dgvEspecif.Rows(r).Cells("Ensayo").Value
                        .Cells("EspecificacionIngles").Value = ""
                        .Cells("DescEnsayoIngles").Value = Trim(WEspecificacion)
                        .Cells("FarmacopeaIngles").Value = Trim(WFarmacopea)
                        .Cells("UnidadEspecifIngles").Value = WUnidadEspecif
                    End With

                End With

            Next

        End If

        TabControl1.SelectTab(1)
    End Sub

    Private Function _GenerarImpreParametro(ByVal wTipoEspecif As String, ByVal wDesdeEspecif As String, ByVal wHastaEspecif As String, ByVal wUnidadEspecif As String, ByVal wMenorIgualEspecif As String) As String

        wTipoEspecif = OrDefault(Trim(wTipoEspecif), "")
        wDesdeEspecif = OrDefault(Trim(wDesdeEspecif), "")
        wHastaEspecif = OrDefault(Trim(wHastaEspecif), "")
        wUnidadEspecif = OrDefault(Trim(wUnidadEspecif), "")
        wMenorIgualEspecif = OrDefault(Trim(wMenorIgualEspecif), "")

        If Trim(wDesdeEspecif) = "" And Trim(wHastaEspecif) = "" Then Return "Cumple Ensayo"

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
        If e.RowIndex < 0 Or e.ColumnIndex < 0 Then Exit Sub

        With dgvEspecif.CurrentRow

            Dim WTipo As Integer = Val(OrDefault(.Cells("TipoEspecif").Value, 0))
            Dim WInforma As Integer = Val(OrDefault(.Cells("InformaEspecif").Value, 0))
            Dim WDesde As String = Trim(OrDefault(.Cells("DesdeEspecif").Value, "0"))
            Dim WHasta As String = Trim(OrDefault(.Cells("HastaEspecif").Value, "0"))
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

            If .Index >= dgvEspecif.Rows.Count - 1 Then dgvEspecif.Rows.Add()

            dgvEspecif.CurrentCell = dgvEspecif.Rows(.Index + 1).Cells("Ensayo")

            dgvEspecif.Focus()

        End With

    End Sub

    Public Sub _ProcesarIngresoParametrosEspecificaciones(ByVal WParametro As String, ByVal Tipo As Integer, ByVal Informa As Integer, ByVal MenorIgual As Integer, ByVal Desde As String, ByVal Hasta As String, ByVal Unidad As String, ByVal WFarmacopea As String, ByVal Formula As String, ByVal ParametrosFormula() As String) Implements IIngresoParametrosEspecificaciones._ProcesarIngresoParametrosEspecificaciones
        With dgvEspecif.CurrentRow
            .Cells("DescEnsayo").Value = WParametro
            .Cells("TipoEspecif").Value = Tipo
            .Cells("InformaEspecif").Value = Informa
            .Cells("DesdeEspecif").Value = Desde.ToString.Replace(",", ".")
            .Cells("HastaEspecif").Value = Hasta.ToString.Replace(",", ".")
            .Cells("MenorIgualEspecif").Value = MenorIgual
            .Cells("UnidadEspecif").Value = Unidad
            .Cells("Farmacopea").Value = WFarmacopea
            .Cells("FormulaEspecif").Value = Formula

            Dim WImpreParametro = _GenerarImpreParametro(Tipo, Desde, Hasta, Unidad, MenorIgual)


            If Val(Tipo) = 0 And WImpreParametro <> "" Then WImpreParametro &= " (c)"

            .Cells("Parametro").Value = WImpreParametro

            For i = 1 To ParametrosFormula.Count - 1
                .Cells("Variable" & i).Value = Trim(ParametrosFormula(i))
            Next

        End With

    End Sub

    Private Sub btnGrabar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnGrabar.Click
        '
        ' Pido clave de Seguridad para autorizar el Proceso. Si se encuentra autorizado, prosigo con la grabación.
        '
        If Not WAutorizado Then

            WTipoProceso = TipoProcesosIngEspecif.GrabaVersion

            With New IngresoClaveSeguridad
                .Show(Me)
            End With

            Exit Sub

        End If

        If Operador.Base = "Surfactan_III" Then
            _GrabarVersionEspecificacionPTFarma()
        Else
            _GrabarEspecificacionPTNoFarma()
        End If

        btnLimpiar.PerformClick()

    End Sub

#Region "PT NO FARMA"
    Private Sub _GrabarVersionEspecificacionPTNOFarma()


        Dim WConsultas As New List(Of String)

        '
        ' Recuperamos las notas viejas, para mantenerlas cuando se actualicen los datos luego.
        '
        Dim WNotas As DataRow = GetSingle("SELECT Observacion1, Observacion2, Observacion3, Observacion4, Observacion5, Observacion6, Observacion7, Observacion8, Observacion9, Observacion10 FROM CargaVNoFarma WHERE Terminado = '" & txtTerminado.Text & "' And Paso = '" & txtEtapa.Text & "' And Renglon = 1", "Surfactan_II")

        '
        ' Borramos el registro anterior si lo hubiese.
        '
        WConsultas.Add("DELETE FROM CargaVNoFarma WHERE Terminado = '" & txtTerminado.Text & "' And Paso = '" & txtEtapa.Text & "'")

        Dim WDescPaso, WCorte As String

        WDescPaso = "CONTROL PARCIAL PASO: " + Trim(txtEtapa.Text)
        WCorte = "0"

        If Val(txtEtapa.Text) = 99 Then
            WDescPaso = "CONTROL FINAL"
            WCorte = "1"
        End If

        Dim ZLugar, ZLugarII, WRenglon As Integer
        Dim ZGrabaEspe(1000, 3) As String

        For i = 0 To 1000
            For x = 0 To 3
                ZGrabaEspe(i, x) = ""
            Next
        Next
        ZLugar = 0
        ZLugarII = 0
        WRenglon = 0

        '
        ' Grabamos los datos de cada renglon.
        '
        For Each row As DataGridViewRow In dgvEspecif.Rows

            Dim WEnsayo, WDescEnsayo, WValor, WFarmacopea, WUnidadEspecif, WDesdeEspecif, WHastaEspecif, WTipoEspecif, WInformaEspecif, WMenorIgualEspecif As String
            Dim WFormulaEspecif, WVariable1, WVariable2, WVariable3, WVariable4, WVariable5, WVariable6, WVariable7, WVariable8, WVariable9, WVariable10 As String

            With row
                WEnsayo = OrDefault(.Cells("Ensayo").Value, "")

                If Trim(WEnsayo) = "" Then Continue For

                WDescEnsayo = OrDefault(.Cells("Especificacion").Value, "")
                WValor = OrDefault(.Cells("DescEnsayo").Value, "")
                WFarmacopea = OrDefault(.Cells("Farmacopea").Value, "")
                WUnidadEspecif = OrDefault(.Cells("UnidadEspecif").Value, "")
                WDesdeEspecif = OrDefault(.Cells("DesdeEspecif").Value, "")
                WHastaEspecif = OrDefault(.Cells("HastaEspecif").Value, "")
                WTipoEspecif = OrDefault(.Cells("TipoEspecif").Value, "0")
                WInformaEspecif = OrDefault(.Cells("InformaEspecif").Value, "0")
                WMenorIgualEspecif = OrDefault(.Cells("MenorIgualEspecif").Value, "0")
                WFormulaEspecif = OrDefault(.Cells("FormulaEspecif").Value, "")
                WVariable1 = OrDefault(.Cells("Variable1").Value, "")
                WVariable2 = OrDefault(.Cells("Variable2").Value, "")
                WVariable3 = OrDefault(.Cells("Variable3").Value, "")
                WVariable4 = OrDefault(.Cells("Variable4").Value, "")
                WVariable5 = OrDefault(.Cells("Variable5").Value, "")
                WVariable6 = OrDefault(.Cells("Variable6").Value, "")
                WVariable7 = OrDefault(.Cells("Variable7").Value, "")
                WVariable8 = OrDefault(.Cells("Variable8").Value, "")
                WVariable9 = OrDefault(.Cells("Variable9").Value, "")
                WVariable10 = OrDefault(.Cells("Variable10").Value, "")

                Dim ZSql, XPaso, Auxi As String

                WRenglon += 1

                XPaso = txtEtapa.Text.PadLeft(4, "0")
                Auxi = WRenglon.ToString.PadLeft(2, "0")

                Dim WClave = txtTerminado.Text + XPaso + Auxi

                ZSql = ""
                ZSql = ZSql & "INSERT INTO CargaVNoFarma ("
                ZSql = ZSql & "Clave ,"
                ZSql = ZSql & "Terminado ,"
                ZSql = ZSql & "Paso ,"
                ZSql = ZSql & "DesPaso ,"
                ZSql = ZSql & "ControlCambio ,"
                ZSql = ZSql & "Renglon ,"
                ZSql = ZSql & "Ensayo ,"
                ZSql = ZSql & "DesEnsayo ,"
                ZSql = ZSql & "Valor ,"
                ZSql = ZSql & "TipoEspecif ,"
                ZSql = ZSql & "InformaEspecif ,"
                ZSql = ZSql & "MenorIgualEspecif ,"
                ZSql = ZSql & "Farmacopea ,"
                ZSql = ZSql & "UnidadEspecif ,"
                ZSql = ZSql & "DesdeEspecif ,"
                ZSql = ZSql & "HastaEspecif ,"
                ZSql = ZSql & "FormulaEspecif ,"
                ZSql = ZSql & "Variable1 ,"
                ZSql = ZSql & "Variable2 ,"
                ZSql = ZSql & "Variable3 ,"
                ZSql = ZSql & "Variable4 ,"
                ZSql = ZSql & "Variable5 ,"
                ZSql = ZSql & "Variable6 ,"
                ZSql = ZSql & "Variable7 ,"
                ZSql = ZSql & "Variable8 ,"
                ZSql = ZSql & "Variable9 ,"
                ZSql = ZSql & "Variable10 ,"
                ZSql = ZSql & "Corte )"
                ZSql = ZSql & "Values ("
                ZSql = ZSql & "'" & WClave & "',"
                ZSql = ZSql & "'" & txtTerminado.Text & "',"
                ZSql = ZSql & "'" & txtEtapa.Text & "',"
                ZSql = ZSql & "'" & WDescPaso & "',"
                ZSql = ZSql & "'" & txtControlCambios.Text & "',"
                ZSql = ZSql & "'" & Trim(Str$(WRenglon)) & "',"
                ZSql = ZSql & "'" & WEnsayo & "',"
                ZSql = ZSql & "'" & WDescEnsayo & "',"
                ZSql = ZSql & "'" & WValor & "',"
                ZSql = ZSql & "'" & WTipoEspecif & "',"
                ZSql = ZSql & "'" & WInformaEspecif & "',"
                ZSql = ZSql & "'" & WMenorIgualEspecif & "',"
                ZSql = ZSql & "'" & WFarmacopea & "',"
                ZSql = ZSql & "'" & WUnidadEspecif & "',"
                ZSql = ZSql & "'" & WDesdeEspecif & "',"
                ZSql = ZSql & "'" & WHastaEspecif & "',"
                ZSql = ZSql & "'" & WFormulaEspecif & "',"
                ZSql = ZSql & "'" & WVariable1 & "',"
                ZSql = ZSql & "'" & WVariable2 & "',"
                ZSql = ZSql & "'" & WVariable3 & "',"
                ZSql = ZSql & "'" & WVariable4 & "',"
                ZSql = ZSql & "'" & WVariable5 & "',"
                ZSql = ZSql & "'" & WVariable6 & "',"
                ZSql = ZSql & "'" & WVariable7 & "',"
                ZSql = ZSql & "'" & WVariable8 & "',"
                ZSql = ZSql & "'" & WVariable9 & "',"
                ZSql = ZSql & "'" & WVariable10 & "',"
                ZSql = ZSql & "'" & WCorte & "')"

                WConsultas.Add(ZSql)

                '
                ' Guardamos las especificaciones para actualizarlas luego.
                '
                ZLugarII = ZLugarII + 1
                If ZLugarII = 1 Then
                    ZLugar = ZLugar + 1
                    ZGrabaEspe(ZLugar, 1) = WEnsayo
                    ZGrabaEspe(ZLugar, 2) = WValor
                    ZGrabaEspe(ZLugar, 3) = ""
                Else
                    If ZGrabaEspe(ZLugar, 1) = WEnsayo Then
                        ZGrabaEspe(ZLugar, 3) = WValor
                        ZLugarII = 0
                    Else
                        ZLugarII = 1
                        ZLugar = ZLugar + 1
                        ZGrabaEspe(ZLugar, 1) = WEnsayo
                        ZGrabaEspe(ZLugar, 2) = WValor
                        ZGrabaEspe(ZLugar, 3) = ""
                    End If
                End If

            End With
        Next

        '
        ' En caso de ser Etapa 99, se actualizan las especificaciones en ingles.
        '
        If Val(txtEtapa.Text) = 99 Then

            WRenglon = 0

            WConsultas.Add("DELETE FROM CargaVNoFarmaIngles WHERE Terminado = '" & txtTerminado.Text & "' And Paso = '99'")

            '
            ' Grabamos los datos de cada renglon.
            '
            For Each row As DataGridViewRow In dgvEspecifIngles.Rows

                Dim WValor, WFarmacopea, WUnidadEspecif As String

                With row

                    WValor = OrDefault(.Cells("DescEnsayoIngles").Value, "")
                    WFarmacopea = OrDefault(.Cells("FarmacopeaIngles").Value, "")
                    WUnidadEspecif = OrDefault(.Cells("UnidadEspecifIngles").Value, "")

                    Dim ZSql, XPaso, Auxi As String

                    WRenglon += 1

                    XPaso = txtEtapa.Text.PadLeft(4, "0")
                    Auxi = WRenglon.ToString.PadLeft(2, "0")

                    Dim WClave = txtTerminado.Text + XPaso + Auxi

                    ZSql = ""
                    ZSql = ZSql & "INSERT INTO CargaVNoFarmaIngles ("
                    ZSql = ZSql & "Clave ,"
                    ZSql = ZSql & "Terminado ,"
                    ZSql = ZSql & "Paso ,"
                    ZSql = ZSql & "Renglon ,"
                    ZSql = ZSql & "Valor ,"
                    ZSql = ZSql & "Farmacopea ,"
                    ZSql = ZSql & "UnidadEspecif "
                    ZSql = ZSql & ")"
                    ZSql = ZSql & "Values ("
                    ZSql = ZSql & "'" & WClave & "',"
                    ZSql = ZSql & "'" & txtTerminado.Text & "',"
                    ZSql = ZSql & "'" & txtEtapa.Text & "',"
                    ZSql = ZSql & "'" & Trim(Str$(WRenglon)) & "',"
                    ZSql = ZSql & "'" & WValor & "',"
                    ZSql = ZSql & "'" & WFarmacopea & "',"
                    ZSql = ZSql & "'" & WUnidadEspecif & "'"
                    ZSql = ZSql & ")"

                    WConsultas.Add(ZSql)

                End With
            Next
        End If

        Dim WObservacion(10) As String

        If WNotas IsNot Nothing Then
            For i = 1 To 10
                WObservacion(i) = OrDefault(WNotas.Item("Observacion" & i), "")
            Next
        End If

        '
        ' Actualizamos las Notas para mantener Histórico.
        '
        WConsultas.Add("UPDATE CargaVNoFarma SET Observacion1 = '" & Trim(WObservacion(1)) & "', Observacion2 = '" & Trim(WObservacion(2)) & "', Observacion3 = '" & Trim(WObservacion(3)) & "', Observacion4 = '" & Trim(WObservacion(4)) & "', Observacion5 = '" & Trim(WObservacion(5)) & "', Observacion6 = '" & Trim(WObservacion(6)) & "', Observacion7 = '" & Trim(WObservacion(7)) & "', Observacion8 = '" & Trim(WObservacion(8)) & "', Observacion9 = '" & Trim(WObservacion(9)) & "', Observacion10 = '" & Trim(WObservacion(10)) & "' WHERE Terminado = '" & txtTerminado.Text & "' And Paso = '" & txtEtapa.Text & "'")

        ExecuteNonQueries("Surfactan_II", WConsultas.ToArray)

    End Sub

    Private Sub _GrabarEspecificacionPTNoFarma()

        Dim WSQLs As New List(Of String)
        Dim sql As String = ""
        Dim WActualiza As Boolean = False

        Dim WEspecif As DataRow = GetSingle("SELECT Version FROM EspecifUnifica WHERE Producto = '" & txtTerminado.Text & "'", "Surfactan_II")

        If WEspecif IsNot Nothing Then

            If MsgBox("¿Desea actualizar la Versión de la Especificación?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

                sql = _PreparaGuardarVersionPTNoFarma(txtTerminado.Text)

                WSQLs.Add(sql)

                sql = _PreparaActualizarVersionPTNoFarma(txtTerminado.Text)

                WSQLs.Add(sql)

                WActualiza = True
            Else
                sql = _PreparaActualizarPTNoFarma(txtTerminado.Text)
                WSQLs.Add(sql)
            End If
        Else
            sql = _PrepararAltaEspecificacionPTNoFarma(txtTerminado.Text)
            WSQLs.Add(sql)
        End If

        sql = _ActualizarFamiliaProducto("NK", txtTerminado.Text.right(10))
        WSQLs.Add(sql)
        sql = _ActualizarFamiliaProducto("RE", txtTerminado.Text.right(10))
        WSQLs.Add(sql)

        WSQLs.Add("UPDATE EspecifUnifica SET Operador = '" & Operador.Codigo & "' WHERE Producto = '" & txtTerminado.Text & "' OR Producto = '" & "NK" & txtTerminado.Text.right(10) & "' Or Producto = '" & "RE" & txtTerminado.Text.right(10) & "'")

        Dim WExisteHojaTecnica As Boolean = False
        '
        ' Verificamos si existe la Hoja Técnica.
        '
        WExisteHojaTecnica = File.Exists("\\193.168.0.2\W\Impresion pdf\DOC" + Mid(txtTerminado.Text, 4, 5) + txtTerminado.Text.right(3) + "*.pdf")

        '
        ' Si Actualizó versión, actualizo información en las demás plantas.
        '
        If WActualiza Then
            For Each Emp As String In {"SurfactanSa", "Surfactan_II", "Surfactan_III", "Surfactan_IV", "Surfactan_V", "Surfactan_VI", "Surfactan_VII"}
                sql = _PreparaGuardarVersionPTNoFarmaEnPlantas(txtTerminado.Text, Emp)
                WSQLs.Add(sql)
                sql = _PreparaGuardarVersionPTNoFarmaEnPlantas("NK" & txtTerminado.Text.right(10), Emp)
                WSQLs.Add(sql)
                sql = _PreparaGuardarVersionPTNoFarmaEnPlantas("RE" & txtTerminado.Text.right(10), Emp)
                WSQLs.Add(sql)

                If Not WExisteHojaTecnica Then
                    sql = String.Format("UPDATE {0}.dbo.Terminado SET EstadoHoja = 'N' WHERE Codigo = '{1}'", Emp, txtTerminado.Text)
                    WSQLs.Add(sql)
                End If
            Next
        End If

        ExecuteNonQueries("Surfactan_II", WSQLs.ToArray)

        _GrabarVersionEspecificacionPTNOFarma()

        With New IngresoDatosMostrarEnCertificadosAnalisis(txtTerminado.Text, "S00102", True)
            .ShowDialog(Me)
        End With

        btnLimpiar_Click(Nothing, Nothing)

    End Sub

    Private Function _PreparaGuardarVersionPTNoFarmaEnPlantas(ByVal Terminado As String, ByVal Empresa As String) As String
        Return String.Format("UPDATE T SET T.VersionII = E.Version, T.FechaVersionII = E.Fecha, T.EstadoII = E.Estado, T.ObservaII = E.Observaciones FROM {1}.dbo.Terminado T INNER JOIN Surfactan_II.dbo.EspecifUnifica E ON T.Codigo COLLATE DATABASE_DEFAULT = E.Producto COLLATE DATABASE_DEFAULT WHERE T.Codigo COLLATE DATABASE_DEFAULT = '{0}'", Terminado, Empresa)
    End Function

    Private Function _ActualizarFamiliaProducto(ByVal Prefijo As String, ByVal Terminado As String) As String

        Dim WProducto As String = Prefijo & Terminado
        Dim WEspecif As DataRow = GetSingle("SELECT Version FROM EspecifUnifica WHERE Producto = '" & WProducto & "'", "Surfactan_II")

        If WEspecif IsNot Nothing Then
            Return _PreparaGuardarVersionPTNoFarma(WProducto)
        Else
            Return _PrepararAltaEspecificacionPTNoFarma(WProducto)
        End If

    End Function

    Private Function _PrepararAltaEspecificacionPTNoFarma(ByVal Terminado As String) As String

        Dim sql As String = "INSERT INTO EspecifUnifica ("

        Dim columnas As String = ""
        Dim valores As String = ""

        For i = 1 To 10

            columnas &= "Ensayo" & i & ","
            columnas &= "Valor" & i & ", Valor" & i & i & ","
            columnas &= "Desde" & i & ","
            columnas &= "Hasta" & i & ","

        Next

        For i = 1 To dgvEspecif.Rows.Count

            With dgvEspecif.Rows(i)
                valores &= "'" & Trim(OrDefault(.Cells("Ensayo").Value, "")) & "',"

                Dim WValor As String = OrDefault(.Cells("DescEnsayo").Value, "").ToString.Trim.PadRight(100, " ")

                valores &= "'" & WValor.left(50) & "', '" & WValor.right(50) & "' ,"
                valores &= "'" & Trim(OrDefault(.Cells("DesdeEspecif").Value, "")) & "',"
                valores &= "'" & Trim(OrDefault(.Cells("HastaEspecif").Value, "")) & "',"

            End With

        Next

        For i = dgvEspecif.Rows.Count + 1 To 10

            valores &= "''," ' Ensayo
            valores &= "'',''," ' Valores
            valores &= "''," ' Desde
            valores &= "''," ' Hasta

        Next

        sql &= columnas
        sql &= "Producto, WDate, Fecha, Version, Observaciones, ControlCambio, Estado"
        sql &= ") VALUES ("
        sql &= valores
        sql &= "'" & txtTerminado.Text & "', '" & Date.Now.ToString("MM-dd-yyyy") & "', '" & Date.Now.ToString("dd/MM/yyyy") & "', '1', '', '" & txtControlCambios.Text.left(100) & "', 'S'"
        sql &= ")"

        Return sql

    End Function

    Private Function _PreparaGuardarVersionPTNoFarma(ByVal Terminado As String) As String

        Dim sql As String = "INSERT INTO EspecifUnificaVersion ("

        Dim columnas As String = ""

        For i = 1 To 10

            columnas &= "Ensayo" & i & ","
            columnas &= "Valor" & i & ", Valor" & i & i & ","
            columnas &= "Desde" & i & ","
            columnas &= "Hasta" & i & ","

        Next

        sql &= columnas
        sql &= "Clave, [Version], Producto, WDate, FechaInicio, FechaFinal, Observaciones, ControlCambio"
        sql &= ") SELECT "
        sql &= columnas
        sql &= "FORMAT([Version], '0000') + '' + Producto, [Version], Producto, '" & Date.Now.ToString("MM-dd-yyyy") & "', Fecha, '" & Date.Now.ToString("dd/MM/yyyy") & "', Observaciones, ControlCambio"
        sql &= " FROM EspecifUnifica WHERE Producto = '" & Terminado & "'"

        Return sql
    End Function

    Private Function _PreparaActualizarVersionPTNoFarma(ByVal Terminado As String) As String

        Dim sql As String = "UPDATE EspecifUnifica SET "

        Dim columnas As String = ""

        For i = 1 To dgvEspecif.Rows.Count

            With dgvEspecif.Rows(i - 1)

                columnas &= "Ensayo" & i & " = '" & OrDefault(.Cells("Ensayo").Value, "") & "',"

                Dim WValor As String = OrDefault(.Cells("DescEnsayo").Value, "").ToString.Trim.PadRight(100, " ")

                columnas &= "Valor" & i & " = '" & WValor.left(50) & "', Valor" & i & i & " = '" & WValor.right(50) & "',"
                columnas &= "Desde" & i & " = '" & Trim(OrDefault(.Cells("DesdeEspecif").Value, "")) & "',"
                columnas &= "Hasta" & i & " = '" & Trim(OrDefault(.Cells("HastaEspecif").Value, "")) & "',"

            End With

        Next

        For i = dgvEspecif.Rows.Count + 1 To 10

            columnas &= "Ensayo" & i & " = '',"
            columnas &= "Valor" & i & " = '', Valor" & i & i & " = '',"
            columnas &= "Desde" & i & " = '',"
            columnas &= "Hasta" & i & " = '',"

        Next

        sql &= columnas
        sql &= "WDate = '" & Date.Now.ToString("MM-dd-yyyy") & "', Fecha = '" & Date.Now.ToString("dd/MM/yyyy") & "', Observaciones = '', ControlCambio = '" & txtControlCambios.Text.left(100) & "', Version = Version + 1, Estado = 'S' "
        sql &= " WHERE Producto = '" & Terminado & "'"

        Return sql

    End Function

    Private Function _PreparaActualizarPTNoFarma(ByVal Terminado As String) As String

        Dim sql As String = "UPDATE EspecifUnifica SET "

        Dim columnas As String = ""

        For i = 1 To dgvEspecif.Rows.Count

            With dgvEspecif.Rows(i - 1)

                columnas &= "Ensayo" & i & " = '" & OrDefault(.Cells("Ensayo").Value, "") & "',"

                Dim WValor As String = OrDefault(.Cells("DescEnsayo").Value, "").ToString.Trim.PadRight(100, " ")

                columnas &= "Valor" & i & " = '" & WValor.left(50) & "', Valor" & i & i & " = '" & WValor.right(50) & "',"
                columnas &= "Desde" & i & " = '" & Trim(OrDefault(.Cells("DesdeEspecif").Value, "")) & "',"
                columnas &= "Hasta" & i & " = '" & Trim(OrDefault(.Cells("HastaEspecif").Value, "")) & "',"

            End With

        Next

        For i = dgvEspecif.Rows.Count + 1 To 10

            columnas &= "Ensayo" & i & " = '',"
            columnas &= "Valor" & i & " = '', Valor" & i & i & " = '',"
            columnas &= "Desde" & i & " = '',"
            columnas &= "Hasta" & i & " = '',"

        Next

        sql &= columnas
        sql &= "WDate = '" & Date.Now.ToString("MM-dd-yyyy") & "', Fecha = '" & Date.Now.ToString("dd/MM/yyyy") & "', Observaciones = '', ControlCambio = '" & txtControlCambios.Text.left(100) & "', Estado = 'S' "
        sql &= " WHERE Producto = '" & Terminado & "'"

        Return sql

    End Function

#End Region

    Private Sub _GrabarVersionEspecificacionPTFarma()


        Dim WConsultas As New List(Of String)

        '
        ' Recuperamos las notas viejas, para mantenerlas cuando se actualicen los datos luego.
        '
        Dim WNotas As DataRow = GetSingle("SELECT Observacion1, Observacion2, Observacion3, Observacion4, Observacion5, Observacion6, Observacion7, Observacion8, Observacion9, Observacion10 FROM CargaV WHERE Terminado = '" & txtTerminado.Text & "' And Paso = '" & txtEtapa.Text & "' And Renglon = 1")

        '
        ' Borramos el registro anterior si lo hubiese.
        '
        WConsultas.Add("DELETE FROM CargaV WHERE Terminado = '" & txtTerminado.Text & "' And Paso = '" & txtEtapa.Text & "'")

        Dim WDescPaso, WCorte As String

        WDescPaso = "CONTROL PARCIAL PASO: " + Trim(txtEtapa.Text)
        WCorte = "0"

        If Val(txtEtapa.Text) = 99 Then
            WDescPaso = "CONTROL FINAL"
            WCorte = "1"
        End If

        Dim ZLugar, ZLugarII, WRenglon As Integer
        Dim ZGrabaEspe(1000, 3) As String

        For i = 0 To 1000
            For x = 0 To 3
                ZGrabaEspe(i, x) = ""
            Next
        Next
        ZLugar = 0
        ZLugarII = 0
        WRenglon = 0

        '
        ' Grabamos los datos de cada renglon.
        '
        For Each row As DataGridViewRow In dgvEspecif.Rows

            Dim WEnsayo, WDescEnsayo, WValor, WFarmacopea, WUnidadEspecif, WDesdeEspecif, WHastaEspecif, WTipoEspecif, WInformaEspecif, WMenorIgualEspecif As String
            Dim WFormulaEspecif, WVariable1, WVariable2, WVariable3, WVariable4, WVariable5, WVariable6, WVariable7, WVariable8, WVariable9, WVariable10 As String

            With row
                WEnsayo = OrDefault(.Cells("Ensayo").Value, "")

                If Trim(WEnsayo) = "" Then Continue For

                WDescEnsayo = OrDefault(.Cells("Especificacion").Value, "")
                WValor = OrDefault(.Cells("DescEnsayo").Value, "")
                WFarmacopea = OrDefault(.Cells("Farmacopea").Value, "")
                WUnidadEspecif = OrDefault(.Cells("UnidadEspecif").Value, "")
                WDesdeEspecif = OrDefault(.Cells("DesdeEspecif").Value, "")
                WHastaEspecif = OrDefault(.Cells("HastaEspecif").Value, "")
                WTipoEspecif = OrDefault(.Cells("TipoEspecif").Value, "0")
                WInformaEspecif = OrDefault(.Cells("InformaEspecif").Value, "0")
                WMenorIgualEspecif = OrDefault(.Cells("MenorIgualEspecif").Value, "0")
                WFormulaEspecif = OrDefault(.Cells("FormulaEspecif").Value, "")
                WVariable1 = OrDefault(.Cells("Variable1").Value, "")
                WVariable2 = OrDefault(.Cells("Variable2").Value, "")
                WVariable3 = OrDefault(.Cells("Variable3").Value, "")
                WVariable4 = OrDefault(.Cells("Variable4").Value, "")
                WVariable5 = OrDefault(.Cells("Variable5").Value, "")
                WVariable6 = OrDefault(.Cells("Variable6").Value, "")
                WVariable7 = OrDefault(.Cells("Variable7").Value, "")
                WVariable8 = OrDefault(.Cells("Variable8").Value, "")
                WVariable9 = OrDefault(.Cells("Variable9").Value, "")
                WVariable10 = OrDefault(.Cells("Variable10").Value, "")

                Dim ZSql, XPaso, Auxi As String

                WRenglon += 1

                XPaso = txtEtapa.Text.PadLeft(4, "0")
                Auxi = WRenglon.ToString.PadLeft(2, "0")

                Dim WClave = txtTerminado.Text + XPaso + Auxi

                ZSql = ""
                ZSql = ZSql & "INSERT INTO CargaV ("
                ZSql = ZSql & "Clave ,"
                ZSql = ZSql & "Terminado ,"
                ZSql = ZSql & "Paso ,"
                ZSql = ZSql & "DesPaso ,"
                ZSql = ZSql & "ControlCambio ,"
                ZSql = ZSql & "Renglon ,"
                ZSql = ZSql & "Ensayo ,"
                ZSql = ZSql & "DesEnsayo ,"
                ZSql = ZSql & "Valor ,"
                ZSql = ZSql & "TipoEspecif ,"
                ZSql = ZSql & "InformaEspecif ,"
                ZSql = ZSql & "MenorIgualEspecif ,"
                ZSql = ZSql & "Farmacopea ,"
                ZSql = ZSql & "UnidadEspecif ,"
                ZSql = ZSql & "DesdeEspecif ,"
                ZSql = ZSql & "HastaEspecif ,"
                ZSql = ZSql & "FormulaEspecif ,"
                ZSql = ZSql & "Variable1 ,"
                ZSql = ZSql & "Variable2 ,"
                ZSql = ZSql & "Variable3 ,"
                ZSql = ZSql & "Variable4 ,"
                ZSql = ZSql & "Variable5 ,"
                ZSql = ZSql & "Variable6 ,"
                ZSql = ZSql & "Variable7 ,"
                ZSql = ZSql & "Variable8 ,"
                ZSql = ZSql & "Variable9 ,"
                ZSql = ZSql & "Variable10 ,"
                ZSql = ZSql & "Corte )"
                ZSql = ZSql & "Values ("
                ZSql = ZSql & "'" & WClave & "',"
                ZSql = ZSql & "'" & txtTerminado.Text & "',"
                ZSql = ZSql & "'" & txtEtapa.Text & "',"
                ZSql = ZSql & "'" & WDescPaso & "',"
                ZSql = ZSql & "'" & txtControlCambios.Text & "',"
                ZSql = ZSql & "'" & Trim(Str$(WRenglon)) & "',"
                ZSql = ZSql & "'" & WEnsayo & "',"
                ZSql = ZSql & "'" & WDescEnsayo & "',"
                ZSql = ZSql & "'" & WValor & "',"
                ZSql = ZSql & "'" & WTipoEspecif & "',"
                ZSql = ZSql & "'" & WInformaEspecif & "',"
                ZSql = ZSql & "'" & WMenorIgualEspecif & "',"
                ZSql = ZSql & "'" & WFarmacopea & "',"
                ZSql = ZSql & "'" & WUnidadEspecif & "',"
                ZSql = ZSql & "'" & WDesdeEspecif & "',"
                ZSql = ZSql & "'" & WHastaEspecif & "',"
                ZSql = ZSql & "'" & WFormulaEspecif & "',"
                ZSql = ZSql & "'" & WVariable1 & "',"
                ZSql = ZSql & "'" & WVariable2 & "',"
                ZSql = ZSql & "'" & WVariable3 & "',"
                ZSql = ZSql & "'" & WVariable4 & "',"
                ZSql = ZSql & "'" & WVariable5 & "',"
                ZSql = ZSql & "'" & WVariable6 & "',"
                ZSql = ZSql & "'" & WVariable7 & "',"
                ZSql = ZSql & "'" & WVariable8 & "',"
                ZSql = ZSql & "'" & WVariable9 & "',"
                ZSql = ZSql & "'" & WVariable10 & "',"
                ZSql = ZSql & "'" & WCorte & "')"

                WConsultas.Add(ZSql)

                '
                ' Guardamos las especificaciones para actualizarlas luego.
                '
                ZLugarII = ZLugarII + 1
                If ZLugarII = 1 Then
                    ZLugar = ZLugar + 1
                    ZGrabaEspe(ZLugar, 1) = WEnsayo
                    ZGrabaEspe(ZLugar, 2) = WValor
                    ZGrabaEspe(ZLugar, 3) = ""
                Else
                    If ZGrabaEspe(ZLugar, 1) = WEnsayo Then
                        ZGrabaEspe(ZLugar, 3) = WValor
                        ZLugarII = 0
                    Else
                        ZLugarII = 1
                        ZLugar = ZLugar + 1
                        ZGrabaEspe(ZLugar, 1) = WEnsayo
                        ZGrabaEspe(ZLugar, 2) = WValor
                        ZGrabaEspe(ZLugar, 3) = ""
                    End If
                End If

            End With
        Next

        '
        ' En caso de ser Etapa 99, se actualizan las especificaciones en ingles.
        '
        If Val(txtEtapa.Text) = 99 Then

            WRenglon = 0

            WConsultas.Add("DELETE FROM CargaVIngles WHERE Terminado = '" & txtTerminado.Text & "' And Paso = '99'")

            '
            ' Grabamos los datos de cada renglon.
            '
            For Each row As DataGridViewRow In dgvEspecifIngles.Rows

                Dim WValor, WFarmacopea, WUnidadEspecif As String

                With row

                    WValor = OrDefault(.Cells("DescEnsayoIngles").Value, "")
                    WFarmacopea = OrDefault(.Cells("FarmacopeaIngles").Value, "")
                    WUnidadEspecif = OrDefault(.Cells("UnidadEspecifIngles").Value, "")

                    Dim ZSql, XPaso, Auxi As String

                    WRenglon += 1

                    XPaso = txtEtapa.Text.PadLeft(4, "0")
                    Auxi = WRenglon.ToString.PadLeft(2, "0")

                    Dim WClave = txtTerminado.Text + XPaso + Auxi

                    ZSql = ""
                    ZSql = ZSql & "INSERT INTO CargaVIngles ("
                    ZSql = ZSql & "Clave ,"
                    ZSql = ZSql & "Terminado ,"
                    ZSql = ZSql & "Paso ,"
                    ZSql = ZSql & "Renglon ,"
                    ZSql = ZSql & "Valor ,"
                    ZSql = ZSql & "Farmacopea ,"
                    ZSql = ZSql & "UnidadEspecif "
                    ZSql = ZSql & ")"
                    ZSql = ZSql & "Values ("
                    ZSql = ZSql & "'" & WClave & "',"
                    ZSql = ZSql & "'" & txtTerminado.Text & "',"
                    ZSql = ZSql & "'" & txtEtapa.Text & "',"
                    ZSql = ZSql & "'" & Trim(Str$(WRenglon)) & "',"
                    ZSql = ZSql & "'" & WValor & "',"
                    ZSql = ZSql & "'" & WFarmacopea & "',"
                    ZSql = ZSql & "'" & WUnidadEspecif & "'"
                    ZSql = ZSql & ")"

                    WConsultas.Add(ZSql)

                End With
            Next
        End If

        Dim WObservacion(10) As String

        If WNotas IsNot Nothing Then
            For i = 1 To 10
                WObservacion(i) = OrDefault(WNotas.Item("Observacion" & i), "")
            Next
        End If

        '
        ' Actualizamos las Notas para mantener Histórico.
        '
        WConsultas.Add("UPDATE CargaV SET Observacion1 = '" & Trim(WObservacion(1)) & "', Observacion2 = '" & Trim(WObservacion(2)) & "', Observacion3 = '" & Trim(WObservacion(3)) & "', Observacion4 = '" & Trim(WObservacion(4)) & "', Observacion5 = '" & Trim(WObservacion(5)) & "', Observacion6 = '" & Trim(WObservacion(6)) & "', Observacion7 = '" & Trim(WObservacion(7)) & "', Observacion8 = '" & Trim(WObservacion(8)) & "', Observacion9 = '" & Trim(WObservacion(9)) & "', Observacion10 = '" & Trim(WObservacion(10)) & "' WHERE Terminado = '" & txtTerminado.Text & "' And Paso = '" & txtEtapa.Text & "'")

        ExecuteNonQueries(WConsultas.ToArray)

        '
        ' Si es la Etapa final la que se está grabando, se guarda la especificacion vigente y se agrega una nueva versión.
        '
        If Val(txtEtapa.Text) = 99 Then
            _ActualizarVersionEspecificacion(ZGrabaEspe)
        End If

        '
        ' Una vez actualizadas las Etapas y sus Versiones, en el caso de que corresponda, es necesario actualizar el Registro de Producción.
        '
        _ActualizarRegistroProduccion()

        '
        ' Mostramos por Pantalla la impresión de Especificaciones (también las de inglés).
        '
        btnImpresion_Click(Nothing, Nothing)
    End Sub

    Private Sub _ActualizarRegistroProduccion()

        Dim WVersion, WFechaVersion, WControlCambio, WImprePlanilla, WImprePlanillaII, WImprePlanillaIII, WMetodo, WLibera, WLimpieza, WEpp, WHumedad, WPeso, WEquipo, WArticulo, WPTerminado, WLetra, WDescripcion, WCantidad, WDescEquipo, WPoe, WIdentificacion, WPoeLimpieza, WArea, ZTipoProceso As String
        WVersion = ""
        WFechaVersion = ""
        WControlCambio = ""
        WImprePlanilla = ""
        WImprePlanillaII = ""
        WImprePlanillaIII = ""
        WMetodo = ""
        WLibera = ""
        WLimpieza = ""
        WEpp = ""
        WHumedad = ""
        WPeso = ""
        WEquipo = ""
        WArticulo = ""
        WPTerminado = ""
        WLetra = ""
        WDescripcion = ""
        WCantidad = ""
        WDescEquipo = ""
        WPoe = ""
        WIdentificacion = ""
        WPoeLimpieza = ""
        WArea = ""
        ZTipoProceso = ""
        '
        ' Extraemos los datos de CargaIII.
        '
        Dim WCargaIII As DataTable = GetAll("SELECT Version, FechaVersion, ControlCambio, ImprimePlanilla, ImprimePlanillaII, ImprimePlanillaIII, Metodo, Libera, Limpieza, Epp, Humedad, Peso, Equipo, Articulo, PTerminado, Letra, Descripcion, Cantidad, TipoProceso FROM CargaIII WHERE Terminado = '" & txtTerminado.Text & "' And Paso = '" & txtEtapa.Text & "' and ISNULL(Tipo, '') <> 'N'  Order by Terminado, Paso, Renglon")

        '
        ' Extraemos los datos de CargaV.
        '
        Dim WCargaV As DataTable = GetAll("SELECT Ensayo, Valor, Farmacopea, UnidadEspecif, DesdeEspecif, HastaEspecif, TipoEspecif, InformaEspecif, MenorIgualEspecif FROM CargaV WHERE Terminado = '" & txtTerminado.Text & "' and Paso = '" & txtEtapa.Text & "' Order by Terminado, Paso, Renglon")

        Dim WDatosAnalisis(100, 11) As String

        Dim WRenglon As Integer = 0

        For Each row As DataRow In WCargaV.Rows

            Dim WEnsayo, WValor, WFarmacopea, WUnidadEspecif, WDesdeEspecif, WHastaEspecif, WTipoEspecif, WInformaEspecif, WMenorIgualEspecif, WImpreResultado, WMaximo As String

            With row

                WEnsayo = OrDefault(.Item("Ensayo"), "")
                WValor = OrDefault(.Item("Valor"), "")
                WFarmacopea = OrDefault(.Item("Farmacopea"), "")
                WUnidadEspecif = OrDefault(.Item("UnidadEspecif"), "")
                WDesdeEspecif = OrDefault(.Item("DesdeEspecif"), "")
                WHastaEspecif = OrDefault(.Item("HastaEspecif"), "")
                WTipoEspecif = OrDefault(.Item("TipoEspecif"), "9")
                WInformaEspecif = OrDefault(.Item("InformaEspecif"), "1")
                WMenorIgualEspecif = OrDefault(.Item("MenorIgualEspecif"), "0")
                WMaximo = OrDefault(.Item("MenorIgualEspecif"), "")
                WImpreResultado = ""

                WRenglon += 1

                WDatosAnalisis(WRenglon, 1) = Trim(WEnsayo)
                WDatosAnalisis(WRenglon, 2) = _TraerDescEnsayo(WEnsayo)
                WDatosAnalisis(WRenglon, 3) = Trim(WValor)
                WDatosAnalisis(WRenglon, 4) = Trim(WFarmacopea)
                WDatosAnalisis(WRenglon, 5) = Trim(WUnidadEspecif)
                WDatosAnalisis(WRenglon, 6) = Trim(WDesdeEspecif)
                WDatosAnalisis(WRenglon, 7) = Trim(WHastaEspecif)

                WDatosAnalisis(WRenglon, 8) = ""

                If Val(WTipoEspecif) = 0 Then
                    WDatosAnalisis(WRenglon, 8) = "C"
                ElseIf Val(WTipoEspecif) = 1 Then
                    WDatosAnalisis(WRenglon, 8) = "N"
                End If

                WDatosAnalisis(WRenglon, 9) = IIf(Val(WInformaEspecif) = 1, "S", "N")

                WDatosAnalisis(WRenglon, 10) = Trim(WMenorIgualEspecif)

                If Val(WDesdeEspecif) = 0 And Val(WHastaEspecif) <> 0 Then
                    If Val(WHastaEspecif) < 9999 Then
                        WDatosAnalisis(WRenglon, 10) = IIf(Val(WMenorIgualEspecif) = 1, "S", "N")
                    End If
                End If

                If Val(WDesdeEspecif) <> 0 And Val(WHastaEspecif) = 9999 Then
                    WDatosAnalisis(WRenglon, 10) = IIf(Val(WMenorIgualEspecif) = 1, "S", "N")
                End If

                If Trim(WDesdeEspecif) <> "" And Trim(WHastaEspecif) <> "" Then
                    If Trim(WDesdeEspecif) <> "0" Or Trim(WHastaEspecif) <> "9999" Then

                        If Val(WDesdeEspecif) <> 0 And Val(WHastaEspecif) <> 0 Then
                            WImpreResultado = "Entre " & Trim(WDesdeEspecif) & " - " & Trim(WHastaEspecif) & " " & Trim(WUnidadEspecif)
                        End If

                        If Val(WDesdeEspecif) = 0 And Val(WHastaEspecif) <> 0 Then

                            WImpreResultado = IIf(Val(WMaximo) = 1, "Máximo ", "Menor a ")

                            WImpreResultado &= Trim(WHastaEspecif) & " " & Trim(WUnidadEspecif)

                        End If

                        If Val(WDesdeEspecif) <> 0 And Val(WHastaEspecif) = 9999 Then

                            WImpreResultado = IIf(Val(WMaximo) = 1, "Mínimo ", "Mayor a ")

                            WImpreResultado &= Trim(WDesdeEspecif) & " " & Trim(WUnidadEspecif)

                        End If

                        If Val(WTipoEspecif) = 0 Then
                            WImpreResultado &= "C"
                        End If

                    End If

                End If

                WDatosAnalisis(WRenglon, 11) = Trim(WImpreResultado)

            End With

        Next

        '
        ' Grabamos los datos para actualizar el registro de Producción.
        '

        If WCargaIII.Rows.Count = 0 Then Exit Sub

        Dim WConsultas As New List(Of String)

        WConsultas.Add("DELETE FROM CargaIII WHERE Terminado = '" & txtTerminado.Text & "' And Paso = '" & txtEtapa.Text & "'")

        WRenglon = 0

        '
        ' Grabamos el Equipo a utilizar.
        '
        WEquipo = Trim(OrDefault(WCargaIII.Rows(0).Item("Equipo"), ""))
        WLibera = Trim(OrDefault(WCargaIII.Rows(0).Item("Libera"), ""))
        ZTipoProceso = Trim(OrDefault(WCargaIII.Rows(0).Item("TipoProceso"), ""))

        WDescEquipo = ""
        WPoe = ""
        WIdentificacion = ""
        WPoeLimpieza = ""
        WArea = ""

        Dim WEq As DataRow = GetSingle("SELECT Descripcion, Poe, Identificacion, PoeLimpieza, Area FROM Equipo WHERE Codigo = '" & WEquipo & "'")

        If WEq IsNot Nothing Then
            With WEq
                WDescEquipo = Trim(OrDefault(.Item("Descripcion"), ""))
                WPoe = Trim(OrDefault(.Item("Poe"), ""))
                WIdentificacion = Trim(OrDefault(.Item("Identificacion"), ""))
                WPoeLimpieza = Trim(OrDefault(.Item("PoeLimpieza"), ""))
                WArea = Trim(OrDefault(.Item("Area"), ""))
            End With
        End If

        Dim ZZItem, WClave, XDescripcion As String
        Dim WImprePeso, WImpreHumedad, WDesEpp, WTipo As String

        WImprePeso = ""
        WImpreHumedad = ""
        WDesEpp = ""
        WTipo = ""

        Dim WMatAuxi As DataRow = GetSingle("SELECT Descripcion FROM MaterialAuxiliar WHERE Codigo = '" & WEpp & "'")

        If WMatAuxi IsNot Nothing Then
            WDesEpp = Trim(OrDefault(WMatAuxi.Item("Descripcion"), ""))
        End If

        Dim ZSql, Auxi, XPaso As String
        XPaso = ""
        Dim WItem As Integer = 0

        If Val(WEquipo) <> 0 Then
            WItem += 1

            WArticulo = ""
            WPTerminado = ""
            WLetra = "G"
            XDescripcion = " Utilizar Equipo : " + WIdentificacion
            WCantidad = ""

            '
            ' Primer Renglón.
            '
            WRenglon += 1
            Auxi = WRenglon.ToString.PadLeft(2, "0")
            XPaso = txtEtapa.Text.PadLeft(4, "0")

            WClave = txtTerminado.Text + XPaso + Auxi

            WTipo = "N"
            ZZItem = Trim(Str$(Val(txtEtapa.Text))) + "." + Trim(Str$(WItem))

            ZSql = _GenerarConsultaCargaIII(WRenglon, WEquipo, WEpp, ZZItem, WClave, WArticulo, WPTerminado, WLetra, XDescripcion, WCantidad, WPeso, WTipo, WDesEpp, WImprePeso, WLibera, WLimpieza, WMetodo, WHumedad, WImpreHumedad, WItem)

            WConsultas.Add(ZSql)

            '
            ' Segundo Renglón.
            '
            XDescripcion = " Operar Equipo segun POE " + WPoe
            If Trim(WArea) <> "" Then
                XDescripcion = XDescripcion + "  Area: " + WArea
            End If

            WRenglon += 1
            Auxi = WRenglon.ToString.PadLeft(2, "0")

            WClave = txtTerminado.Text + XPaso + Auxi

            WTipo = "N"
            ZZItem = ""

            ZSql = _GenerarConsultaCargaIII(WRenglon, WEquipo, WEpp, ZZItem, WClave, WArticulo, WPTerminado, WLetra, XDescripcion, WCantidad, WPeso, WTipo, WDesEpp, WImprePeso, WLibera, WLimpieza, WMetodo, WHumedad, WImpreHumedad, WItem)

            WConsultas.Add(ZSql)

            '
            ' Tercer Renglón.
            '
            XDescripcion = ""

            WRenglon += 1
            Auxi = WRenglon.ToString.PadLeft(2, "0")

            WClave = txtTerminado.Text + XPaso + Auxi

            WTipo = "N"
            ZZItem = ""

            ZSql = _GenerarConsultaCargaIII(WRenglon, WEquipo, WEpp, ZZItem, WClave, WArticulo, WPTerminado, WLetra, XDescripcion, WCantidad, WPeso, WTipo, WDesEpp, WImprePeso, WLibera, WLimpieza, WMetodo, WHumedad, WImpreHumedad, WItem)

            WConsultas.Add(ZSql)

        End If

        '
        ' Grabamos Liberación.
        '
        If Val(WLibera) <> 0 Then

            WItem += 1

            WArticulo = ""
            WPTerminado = ""
            WLetra = "D"
            XDescripcion = " Se debe liberar el área / equipo          Planilla :.........."
            WCantidad = ""

            '
            ' Primer Renglón.
            '
            WRenglon += 1
            Auxi = WRenglon.ToString.PadLeft(2, "0")
            XPaso = txtEtapa.Text.PadLeft(4, "0")

            WClave = txtTerminado.Text + XPaso + Auxi

            WTipo = "N"
            ZZItem = Trim(Str$(Val(txtEtapa.Text))) + "." + Trim(Str$(WItem))

            ZSql = _GenerarConsultaCargaIII(WRenglon, WEquipo, WEpp, ZZItem, WClave, WArticulo, WPTerminado, WLetra, XDescripcion, WCantidad, WPeso, WTipo, WDesEpp, WImprePeso, WLibera, WLimpieza, WMetodo, WHumedad, WImpreHumedad, WItem)

            WConsultas.Add(ZSql)

            '
            ' Segundo Renglón.
            '
            XDescripcion = ""

            WRenglon += 1
            Auxi = WRenglon.ToString.PadLeft(2, "0")

            WClave = txtTerminado.Text + XPaso + Auxi

            WTipo = "N"
            ZZItem = ""

            ZSql = _GenerarConsultaCargaIII(WRenglon, WEquipo, WEpp, ZZItem, WClave, WArticulo, WPTerminado, WLetra, XDescripcion, WCantidad, WPeso, WTipo, WDesEpp, WImprePeso, WLibera, WLimpieza, WMetodo, WHumedad, WImpreHumedad, WItem)

            WConsultas.Add(ZSql)

        End If

        Dim WBlanco, WImpreItem, WDescriI, WDescriII As String

        WBlanco = ""
        WImpreItem = ""
        WDescriI = ""
        WDescriII = ""
        Dim WNumFila As Integer = 0

        For Each row As DataRow In WCargaIII.Rows
            With row
                WVersion = OrDefault(.Item("Version"), "0")
                WFechaVersion = OrDefault(.Item("FechaVersion"), "  /  /    ")
                WControlCambio = OrDefault(.Item("ControlCambio"), "")
                WImprePlanilla = OrDefault(.Item("ImprimePlanilla"), "0")
                WImprePlanillaII = OrDefault(.Item("ImprimePlanillaII"), "0")
                WImprePlanillaIII = OrDefault(.Item("ImprimePlanillaIII"), "0")
                WMetodo = OrDefault(.Item("Metodo"), "")
                WLibera = OrDefault(.Item("Libera"), "")
                WLimpieza = OrDefault(.Item("Limpieza"), "")
                WEpp = OrDefault(.Item("Epp"), "")
                WHumedad = OrDefault(.Item("Humedad"), "")
                WPeso = OrDefault(.Item("Peso"), "")
                WEquipo = OrDefault(.Item("Equipo"), "")
                WArticulo = OrDefault(.Item("Articulo"), "")
                WPTerminado = OrDefault(.Item("PTerminado"), "")
                WLetra = OrDefault(.Item("Letra"), "")
                XDescripcion = Trim(OrDefault(.Item("Descripcion"), ""))
                WCantidad = formatonumerico(OrDefault(.Item("Cantidad"), "0"), 5)

                WNumFila += 1

                If WBlanco = "" Then
                    WItem += 1
                    WImpreItem = "S"
                End If

                WTipo = "S"

                If WImpreItem = "S" Then
                    ZZItem = Trim(txtEtapa.Text) & "." & WItem
                    WImpreItem = "N"
                Else
                    ZZItem = ""
                End If

                If Val(WPeso) = 1 And WNumFila = 1 Then
                    WImprePeso = "S"
                Else
                    WImprePeso = ""
                End If

                If Val(WHumedad) = 1 And WNumFila = 1 Then
                    WImpreHumedad = "S"
                Else
                    WImpreHumedad = ""
                End If

                WRenglon += 1
                Auxi = WRenglon.ToString.PadLeft(2, "0")

                WClave = txtTerminado.Text + XPaso + Auxi

                ZSql = _GenerarConsultaCargaIII(WRenglon, WEquipo, WEpp, ZZItem, WClave, WArticulo, WPTerminado, WLetra, XDescripcion, WCantidad, WPeso, WTipo, WDesEpp, WImprePeso, WLibera, WLimpieza, WMetodo, WHumedad, WImpreHumedad, WItem)

                WConsultas.Add(ZSql)

                WImprePeso = ""
                WImpreHumedad = ""

                If Trim(XDescripcion) = "" Then
                    WBlanco = ""
                Else
                    WBlanco = "N"
                End If

                If Trim(XDescripcion) = "SOLICITAR CONTROL INTERMEDIO a LAB CC" Or UCase(Trim(XDescripcion)) = "REGISTRO DE RESULTADOS" Then
                    For i = 1 To 100

                        WDescriI = Trim(WDatosAnalisis(i, 2))
                        If Trim(WDatosAnalisis(i, 11)) <> "" Then
                            WDescriII = Trim(WDatosAnalisis(i, 3)) + " (" + Trim(WDatosAnalisis(i, 11)) + ")"
                        Else
                            WDescriII = Trim(WDatosAnalisis(i, 3))
                        End If

                        If UCase(Trim(XDescripcion)) = "REGISTRO DE RESULTADOS" Then

                            If Trim(WDatosAnalisis(i, 11)) <> "" Then WDescriII &= ":"

                            WDescriII &= "..................."

                        End If

                        If Trim(WDescriI) <> "" Then

                            WArticulo = ""
                            WPTerminado = ""
                            REM Letra = ""
                            REM XDescripcion = DescriI + ":" + DescriII
                            XDescripcion = "Método " + WDescriI + " : " + WDescriII
                            WCantidad = ""

                            WRenglon += 1
                            Auxi = WRenglon.ToString.PadLeft(2, "0")

                            WClave = txtTerminado.Text + XPaso + Auxi

                            WTipo = "N"
                            ZZItem = ""

                            ZSql = _GenerarConsultaCargaIII(WRenglon, WEquipo, WEpp, ZZItem, WClave, WArticulo, WPTerminado, WLetra, XDescripcion, WCantidad, WPeso, WTipo, WDesEpp, WImprePeso, WLibera, WLimpieza, WMetodo, WHumedad, WImpreHumedad, WItem)

                            WConsultas.Add(ZSql)

                        End If

                    Next
                End If

            End With
        Next

        If Val(WPeso) = 1 Then

            WItem += 1

            WArticulo = ""
            WPTerminado = ""
            WLetra = ""
            XDescripcion = " Registrar Tipo de Envase y peso neto en tabla : "
            WCantidad = ""

            WRenglon += 1
            Auxi = WRenglon.ToString.PadLeft(2, "0")

            WClave = txtTerminado.Text + XPaso + Auxi

            WTipo = "N"
            ZZItem = Trim(txtEtapa.Text) & "." & WItem

            ZSql = _GenerarConsultaCargaIII(WRenglon, WEquipo, WEpp, ZZItem, WClave, WArticulo, WPTerminado, WLetra, XDescripcion, WCantidad, WPeso, WTipo, WDesEpp, WImprePeso, WLibera, WLimpieza, WMetodo, WHumedad, WImpreHumedad, WItem)

            WConsultas.Add(ZSql)

            WLetra = "X"
            XDescripcion = " REGISTRO DE PESOS POR ENVASE"

            WRenglon += 1
            Auxi = WRenglon.ToString.PadLeft(2, "0")

            WClave = txtTerminado.Text + XPaso + Auxi

            ZZItem = ""

            ZSql = _GenerarConsultaCargaIII(WRenglon, WEquipo, WEpp, ZZItem, WClave, WArticulo, WPTerminado, WLetra, XDescripcion, WCantidad, WPeso, WTipo, WDesEpp, WImprePeso, WLibera, WLimpieza, WMetodo, WHumedad, WImpreHumedad, WItem)

            WConsultas.Add(ZSql)

            WLetra = ""
            XDescripcion = ""

            WRenglon += 1
            Auxi = WRenglon.ToString.PadLeft(2, "0")

            WClave = txtTerminado.Text + XPaso + Auxi

            ZSql = _GenerarConsultaCargaIII(WRenglon, WEquipo, WEpp, ZZItem, WClave, WArticulo, WPTerminado, WLetra, XDescripcion, WCantidad, WPeso, WTipo, WDesEpp, WImprePeso, WLibera, WLimpieza, WMetodo, WHumedad, WImpreHumedad, WItem)

            WConsultas.Add(ZSql)

        End If

        If Val(WLimpieza) = 1 Then

            WItem += 1

            WArticulo = ""
            WPTerminado = ""
            WLetra = "G"
            XDescripcion = " Se debe realizar la limpieza del equipo segun POE : " + Trim(WPoeLimpieza) + " Metodo:" + Trim(WMetodo)
            WCantidad = ""

            WRenglon += 1
            Auxi = WRenglon.ToString.PadLeft(2, "0")

            WClave = txtTerminado.Text + XPaso + Auxi

            WTipo = "N"
            ZZItem = Trim(txtEtapa.Text) & "." & WItem

            ZSql = _GenerarConsultaCargaIII(WRenglon, WEquipo, WEpp, ZZItem, WClave, WArticulo, WPTerminado, WLetra, XDescripcion, WCantidad, WPeso, WTipo, WDesEpp, WImprePeso, WLibera, WLimpieza, WMetodo, WHumedad, WImpreHumedad, WItem)

            WConsultas.Add(ZSql)

            XDescripcion = " Registrar en Bitacora"
            ZZItem = ""

            WRenglon += 1
            Auxi = WRenglon.ToString.PadLeft(2, "0")

            WClave = txtTerminado.Text + XPaso + Auxi

            ZSql = _GenerarConsultaCargaIII(WRenglon, WEquipo, WEpp, ZZItem, WClave, WArticulo, WPTerminado, WLetra, XDescripcion, WCantidad, WPeso, WTipo, WDesEpp, WImprePeso, WLibera, WLimpieza, WMetodo, WHumedad, WImpreHumedad, WItem)

            WConsultas.Add(ZSql)

            WLetra = ""
            XDescripcion = ""

            WRenglon += 1
            Auxi = WRenglon.ToString.PadLeft(2, "0")

            WClave = txtTerminado.Text + XPaso + Auxi

            ZSql = _GenerarConsultaCargaIII(WRenglon, WEquipo, WEpp, ZZItem, WClave, WArticulo, WPTerminado, WLetra, XDescripcion, WCantidad, WPeso, WTipo, WDesEpp, WImprePeso, WLibera, WLimpieza, WMetodo, WHumedad, WImpreHumedad, WItem)

            WConsultas.Add(ZSql)

        End If

        ZSql = ""
        ZSql = ZSql & "UPDATE CargaIII SET "
        ZSql = ZSql & " ImprimePLanilla = " & "'" & Str$(WImprePlanilla) & "',"
        ZSql = ZSql & " ImprimePLanillaII = " & "'" & Str$(WImprePlanillaII) & "',"
        ZSql = ZSql & " ImprimePLanillaIII = " & "'" & Str$(WImprePlanillaIII) & "',"
        ZSql = ZSql & " ControlCambio = " & "'" & WControlCambio & "',"
        ZSql = ZSql & " TipoProceso = " & "'" & ZTipoProceso & "'"
        ZSql = ZSql & " Where Terminado = " & "'" & txtTerminado.Text & "'"

        WConsultas.Add(ZSql)

        Dim WOrdFechaVersion = ordenaFecha(WFechaVersion)

        ZSql = ""
        ZSql = ZSql + "UPDATE CargaIII SET "
        ZSql = ZSql + " Version = " + "'" + WVersion + "',"
        ZSql = ZSql + " FechaVersion = " + "'" + WFechaVersion + "',"
        ZSql = ZSql + " OrdFechaVersion = " + "'" + WOrdFechaVersion + "'"
        ZSql = ZSql + " Where Terminado = " + "'" + txtTerminado.Text + "'"

        WConsultas.Add(ZSql)

        ExecuteNonQueries(WConsultas.ToArray)

    End Sub

    Private Function _TraerDescEnsayo(ByVal Ensayo As String) As String

        Dim WEnsayo As DataRow = GetSingle("SELECT Descripcion FROM Ensayos WHERE Codigo = '" & Trim(Ensayo) & "'")

        If WEnsayo IsNot Nothing Then Trim(OrDefault(WEnsayo.Item("Descripcion"), ""))

        Return ""

    End Function

    Private Function _GenerarConsultaCargaIII(ByVal WRenglon As Integer, ByVal WEquipo As String, ByVal WEpp As String, ByVal WItem As String, ByVal WClave As String, ByVal WArticulo As String, ByVal WPTerminado As String, ByVal WLetra As String, ByVal XDescripcion As String, ByVal WCantidad As String, ByVal WPeso As String, ByVal WTipo As String, ByVal WDesEpp As String, ByVal WImprePeso As String, ByVal WLibera As String, ByVal WLimpieza As String, ByVal WMetodo As String, ByVal WHumedad As String, ByVal WImpreHumedad As String, ByVal Item As Integer) As String
        Dim ZSql As String

        ZSql = ""
        ZSql = ZSql & "INSERT INTO CargaIII ("
        ZSql = ZSql & "Clave ,"
        ZSql = ZSql & "Terminado ,"
        ZSql = ZSql & "Paso ,"
        ZSql = ZSql & "Renglon ,"
        ZSql = ZSql & "Articulo ,"
        ZSql = ZSql & "PTerminado ,"
        ZSql = ZSql & "Letra ,"
        ZSql = ZSql & "Descripcion ,"
        ZSql = ZSql & "Cantidad ,"
        ZSql = ZSql & "Equipo ,"
        ZSql = ZSql & "Peso ,"
        ZSql = ZSql & "Tipo ,"
        ZSql = ZSql & "Item ,"
        ZSql = ZSql & "Epp ,"
        ZSql = ZSql & "DesEpp ,"
        ZSql = ZSql & "CorteItem ,"
        ZSql = ZSql & "ImprePeso ,"
        ZSql = ZSql & "Libera ,"
        ZSql = ZSql & "Limpieza ,"
        ZSql = ZSql & "Metodo ,"
        ZSql = ZSql & "Humedad ,"
        ZSql = ZSql & "ImpreHumedad )"
        ZSql = ZSql & "Values ("
        ZSql = ZSql & "'" & WClave & "',"
        ZSql = ZSql & "'" & txtTerminado.Text & "',"
        ZSql = ZSql & "'" & txtEtapa.Text & "',"
        ZSql = ZSql & "'" & Str$(WRenglon) & "',"
        ZSql = ZSql & "'" & WArticulo & "',"
        ZSql = ZSql & "'" & WPTerminado & "',"
        ZSql = ZSql & "'" & WLetra & "',"
        ZSql = ZSql & "'" & _Left(XDescripcion, 70) & "',"
        ZSql = ZSql & "'" & WCantidad & "',"
        ZSql = ZSql & "'" & WEquipo & "',"
        ZSql = ZSql & "'" & WPeso & "',"
        ZSql = ZSql & "'" & WTipo & "',"
        ZSql = ZSql & "'" & WItem & "',"
        ZSql = ZSql & "'" & WEpp & "',"
        ZSql = ZSql & "'" & _Left(WDesEpp, 50) & "',"
        ZSql = ZSql & "'" & Trim(Str$(Item)) & "',"
        ZSql = ZSql & "'" & WImprePeso & "',"
        ZSql = ZSql & "'" & WLibera & "',"
        ZSql = ZSql & "'" & WLimpieza & "',"
        ZSql = ZSql & "'" & WMetodo & "',"
        ZSql = ZSql & "'" & WHumedad & "',"
        ZSql = ZSql & "'" & WImpreHumedad & "')"

        Return ZSql

    End Function

    Private Sub _ActualizarVersionEspecificacion(ByVal ZGrabaEspe As String(,))

        Dim ZSql As String = ""
        Dim ZVersion As String = ""
        Dim WConsultasII As New List(Of String)

        Dim WEspecifUnifica As DataTable = GetAll("SELECT Ensayo1, Ensayo2, Ensayo3, Ensayo4, Ensayo5, Ensayo6, Ensayo7, Ensayo8, Ensayo9, Ensayo10, " _
                                                  & " Valor1, Valor2, Valor3, Valor4, Valor5, Valor6, Valor7, Valor8, Valor9, Valor10, " _
                                                  & " Valor11, Valor22, Valor33, Valor44, Valor55, Valor66, Valor77, Valor88, Valor99, Valor1010, " _
                                                  & " Fecha, Version " _
                                                  & " FROM EspecifUnifica WHERE Producto = '" & txtTerminado.Text & "'", "Surfactan_II")

        For Each row As DataRow In WEspecifUnifica.Rows

            Dim ZEnsayo1, ZEnsayo2, ZEnsayo3, ZEnsayo4, ZEnsayo5, ZEnsayo6, ZEnsayo7, ZEnsayo8, ZEnsayo9, ZEnsayo10 As String
            Dim ZValor1, ZValor2, ZValor3, ZValor4, ZValor5, ZValor6, ZValor7, ZValor8, ZValor9, ZValor10 As String
            Dim ZValor11, ZValor22, ZValor33, ZValor44, ZValor55, ZValor66, ZValor77, ZValor88, ZValor99, ZValor1010 As String
            Dim ZFechaInicio, ZFechaFinal, ZObservaciones As String
            ZObservaciones = ""

            With row
                ZEnsayo1 = OrDefault(.Item("Ensayo1"), "")
                ZEnsayo2 = OrDefault(.Item("Ensayo2"), "")
                ZEnsayo3 = OrDefault(.Item("Ensayo3"), "")
                ZEnsayo4 = OrDefault(.Item("Ensayo4"), "")
                ZEnsayo5 = OrDefault(.Item("Ensayo5"), "")
                ZEnsayo6 = OrDefault(.Item("Ensayo6"), "")
                ZEnsayo7 = OrDefault(.Item("Ensayo7"), "")
                ZEnsayo8 = OrDefault(.Item("Ensayo8"), "")
                ZEnsayo9 = OrDefault(.Item("Ensayo9"), "")
                ZEnsayo10 = OrDefault(.Item("Ensayo10"), "")
                ZValor1 = OrDefault(.Item("Valor1"), "")
                ZValor2 = OrDefault(.Item("Valor2"), "")
                ZValor3 = OrDefault(.Item("Valor3"), "")
                ZValor4 = OrDefault(.Item("Valor4"), "")
                ZValor5 = OrDefault(.Item("Valor5"), "")
                ZValor6 = OrDefault(.Item("Valor6"), "")
                ZValor7 = OrDefault(.Item("Valor7"), "")
                ZValor8 = OrDefault(.Item("Valor8"), "")
                ZValor9 = OrDefault(.Item("Valor9"), "")
                ZValor10 = OrDefault(.Item("Valor10"), "")
                ZValor11 = OrDefault(.Item("Valor11"), "")
                ZValor22 = OrDefault(.Item("Valor22"), "")
                ZValor33 = OrDefault(.Item("Valor33"), "")
                ZValor44 = OrDefault(.Item("Valor44"), "")
                ZValor55 = OrDefault(.Item("Valor55"), "")
                ZValor66 = OrDefault(.Item("Valor66"), "")
                ZValor77 = OrDefault(.Item("Valor77"), "")
                ZValor88 = OrDefault(.Item("Valor88"), "")
                ZValor99 = OrDefault(.Item("Valor99"), "")
                ZValor1010 = OrDefault(.Item("Valor1010"), "")
                ZFechaInicio = OrDefault(.Item("Fecha"), "")
                ZVersion = OrDefault(.Item("Version"), "")
                ZFechaFinal = Date.Now.ToString("dd/MM/yyyy")

                ZVersion = ZVersion.Trim.PadLeft(4, "0")

                Dim ZClave = ZVersion + txtTerminado.Text

                ZSql = ""
                ZSql = ZSql & "INSERT INTO EspecifUnificaVersion ("
                ZSql = ZSql & "Clave, "
                ZSql = ZSql & "Version, "
                ZSql = ZSql & "Producto, "
                ZSql = ZSql & "Ensayo1, Valor1, "
                ZSql = ZSql & "Ensayo2, Valor2, "
                ZSql = ZSql & "Ensayo3, Valor3, "
                ZSql = ZSql & "Ensayo4, Valor4, "
                ZSql = ZSql & "Ensayo5, Valor5, "
                ZSql = ZSql & "Ensayo6, Valor6, "
                ZSql = ZSql & "Ensayo7, Valor7, "
                ZSql = ZSql & "Ensayo8, Valor8, "
                ZSql = ZSql & "Ensayo9, Valor9, "
                ZSql = ZSql & "Ensayo10, Valor10, "
                ZSql = ZSql & "Valor11 , "
                ZSql = ZSql & "Valor22 , "
                ZSql = ZSql & "Valor33 , "
                ZSql = ZSql & "Valor44 , "
                ZSql = ZSql & "Valor55 , "
                ZSql = ZSql & "Valor66 , "
                ZSql = ZSql & "Valor77 , "
                ZSql = ZSql & "Valor88 , "
                ZSql = ZSql & "Valor99 , "
                ZSql = ZSql & "Valor1010 , "
                ZSql = ZSql & "FechaInicio , "
                ZSql = ZSql & "FechaFinal , "
                ZSql = ZSql & "ControlCambio , "
                ZSql = ZSql & "Observaciones) "
                ZSql = ZSql & "Values ("
                ZSql = ZSql & "'" & ZClave & "',"
                ZSql = ZSql & "'" & ZVersion & "',"
                ZSql = ZSql & "'" & txtTerminado.Text & "',"
                ZSql = ZSql & "'" & ZEnsayo1 & "'," & "'" & ZValor1 & "',"
                ZSql = ZSql & "'" & ZEnsayo2 & "'," & "'" & ZValor2 & "',"
                ZSql = ZSql & "'" & ZEnsayo3 & "'," & "'" & ZValor3 & "',"
                ZSql = ZSql & "'" & ZEnsayo4 & "'," & "'" & ZValor4 & "',"
                ZSql = ZSql & "'" & ZEnsayo5 & "'," & "'" & ZValor5 & "',"
                ZSql = ZSql & "'" & ZEnsayo6 & "'," & "'" & ZValor6 & "',"
                ZSql = ZSql & "'" & ZEnsayo7 & "'," & "'" & ZValor7 & "',"
                ZSql = ZSql & "'" & ZEnsayo8 & "'," & "'" & ZValor8 & "',"
                ZSql = ZSql & "'" & ZEnsayo9 & "'," & "'" & ZValor9 & "',"
                ZSql = ZSql & "'" & ZEnsayo10 & "'," & "'" & ZValor10 & "',"
                ZSql = ZSql & "'" & ZValor11 & "',"
                ZSql = ZSql & "'" & ZValor22 & "',"
                ZSql = ZSql & "'" & ZValor33 & "',"
                ZSql = ZSql & "'" & ZValor44 & "',"
                ZSql = ZSql & "'" & ZValor55 & "',"
                ZSql = ZSql & "'" & ZValor66 & "',"
                ZSql = ZSql & "'" & ZValor77 & "',"
                ZSql = ZSql & "'" & ZValor88 & "',"
                ZSql = ZSql & "'" & ZValor99 & "',"
                ZSql = ZSql & "'" & ZValor1010 & "',"
                ZSql = ZSql & "'" & ZFechaInicio & "',"
                ZSql = ZSql & "'" & ZFechaFinal & "',"
                ZSql = ZSql & "'" & txtControlCambios.Text & "',"
                ZSql = ZSql & "'" & ZObservaciones & "')"

                WConsultasII.Add(ZSql)

                ZVersion = Trim(Str$(Val(ZVersion) + 1))
                Dim ZFecha As String = Date.Now.ToString("dd/MM/yyyy")
                Dim WDate As String = Date.Now.ToString("MM-dd-yyyy")

                ZSql = ""
                ZSql = ZSql & "UPDATE EspecifUnifica SET "
                ZSql = ZSql & "Producto = " & "'" & txtTerminado.Text & "',"
                ZSql = ZSql & "Ensayo1 = " & "'" & ZGrabaEspe(1, 1) & "',"
                ZSql = ZSql & "Valor1 = " & "'" & ZGrabaEspe(1, 2) & "',"
                ZSql = ZSql & "Ensayo2 = " & "'" & ZGrabaEspe(2, 1) & "',"
                ZSql = ZSql & "Valor2 = " & "'" & ZGrabaEspe(2, 2) & "',"
                ZSql = ZSql & "Ensayo3 = " & "'" & ZGrabaEspe(3, 1) & "',"
                ZSql = ZSql & "Valor3 = " & "'" & ZGrabaEspe(3, 2) & "',"
                ZSql = ZSql & "Ensayo4 = " & "'" & ZGrabaEspe(4, 1) & "',"
                ZSql = ZSql & "Valor4 = " & "'" & ZGrabaEspe(4, 2) & "',"
                ZSql = ZSql & "Ensayo5 = " & "'" & ZGrabaEspe(5, 1) & "',"
                ZSql = ZSql & "Valor5 = " & "'" & ZGrabaEspe(5, 2) & "',"
                ZSql = ZSql & "Ensayo6 = " & "'" & ZGrabaEspe(6, 1) & "',"
                ZSql = ZSql & "Valor6 = " & "'" & ZGrabaEspe(6, 2) & "',"
                ZSql = ZSql & "Ensayo7 = " & "'" & ZGrabaEspe(7, 1) & "',"
                ZSql = ZSql & "Valor7 = " & "'" & ZGrabaEspe(7, 2) & "',"
                ZSql = ZSql & "Ensayo8 = " & "'" & ZGrabaEspe(8, 1) & "',"
                ZSql = ZSql & "Valor8 = " & "'" & ZGrabaEspe(8, 2) & "',"
                ZSql = ZSql & "Ensayo9 = " & "'" & ZGrabaEspe(9, 1) & "',"
                ZSql = ZSql & "Valor9 = " & "'" & ZGrabaEspe(9, 2) & "',"
                ZSql = ZSql & "Ensayo10 = " & "'" & ZGrabaEspe(10, 1) & "',"
                ZSql = ZSql & "Valor10 = " & "'" & ZGrabaEspe(10, 2) & "',"
                ZSql = ZSql & "WDate = " & "'" & WDate & "',"
                ZSql = ZSql & "Valor11 = " & "'" & ZGrabaEspe(1, 3) & "',"
                ZSql = ZSql & "Valor22 = " & "'" & ZGrabaEspe(2, 3) & "',"
                ZSql = ZSql & "Valor33 = " & "'" & ZGrabaEspe(3, 3) & "',"
                ZSql = ZSql & "Valor44 = " & "'" & ZGrabaEspe(4, 3) & "',"
                ZSql = ZSql & "Valor55 = " & "'" & ZGrabaEspe(5, 3) & "',"
                ZSql = ZSql & "Valor66 = " & "'" & ZGrabaEspe(6, 3) & "',"
                ZSql = ZSql & "Valor77 = " & "'" & ZGrabaEspe(7, 3) & "',"
                ZSql = ZSql & "Valor88 = " & "'" & ZGrabaEspe(8, 3) & "',"
                ZSql = ZSql & "Valor99 = " & "'" & ZGrabaEspe(9, 3) & "',"
                ZSql = ZSql & "Valor1010 = " & "'" & ZGrabaEspe(10, 3) & "',"
                ZSql = ZSql & "Version = " & "'" & ZVersion & "',"
                ZSql = ZSql & "Fecha = " & "'" & ZFecha & "',"
                ZSql = ZSql & "Estado = " & "'" & "S" & "',"
                ZSql = ZSql & "ControlCambio = " & "'" & txtControlCambios.Text & "',"
                ZSql = ZSql & "Observaciones = " & "'" & "" & "'"
                ZSql = ZSql & " Where Producto = " & "'" & txtTerminado.Text & "'"

                WConsultasII.Add(ZSql)

            End With

        Next

        '
        ' En caso de que no exista una versión vigente, se la toma como primera versión.
        '
        If WEspecifUnifica.Rows.Count = 0 Then
            ZVersion = "1"
            Dim ZFecha As String = Date.Now.ToString("dd/MM/yyyy")
            Dim WDate As String = Date.Now.ToString("MM-dd-yyyy")

            ZSql = ""
            ZSql = ZSql & "UPDATE EspecifUnifica SET "
            ZSql = ZSql & "Producto = " & "'" & txtTerminado.Text & "',"
            ZSql = ZSql & "Ensayo1 = " & "'" & ZGrabaEspe(1, 1) & "',"
            ZSql = ZSql & "Valor1 = " & "'" & ZGrabaEspe(1, 2) & "',"
            ZSql = ZSql & "Ensayo2 = " & "'" & ZGrabaEspe(2, 1) & "',"
            ZSql = ZSql & "Valor2 = " & "'" & ZGrabaEspe(2, 2) & "',"
            ZSql = ZSql & "Ensayo3 = " & "'" & ZGrabaEspe(3, 1) & "',"
            ZSql = ZSql & "Valor3 = " & "'" & ZGrabaEspe(3, 2) & "',"
            ZSql = ZSql & "Ensayo4 = " & "'" & ZGrabaEspe(4, 1) & "',"
            ZSql = ZSql & "Valor4 = " & "'" & ZGrabaEspe(4, 2) & "',"
            ZSql = ZSql & "Ensayo5 = " & "'" & ZGrabaEspe(5, 1) & "',"
            ZSql = ZSql & "Valor5 = " & "'" & ZGrabaEspe(5, 2) & "',"
            ZSql = ZSql & "Ensayo6 = " & "'" & ZGrabaEspe(6, 1) & "',"
            ZSql = ZSql & "Valor6 = " & "'" & ZGrabaEspe(6, 2) & "',"
            ZSql = ZSql & "Ensayo7 = " & "'" & ZGrabaEspe(7, 1) & "',"
            ZSql = ZSql & "Valor7 = " & "'" & ZGrabaEspe(7, 2) & "',"
            ZSql = ZSql & "Ensayo8 = " & "'" & ZGrabaEspe(8, 1) & "',"
            ZSql = ZSql & "Valor8 = " & "'" & ZGrabaEspe(8, 2) & "',"
            ZSql = ZSql & "Ensayo9 = " & "'" & ZGrabaEspe(9, 1) & "',"
            ZSql = ZSql & "Valor9 = " & "'" & ZGrabaEspe(9, 2) & "',"
            ZSql = ZSql & "Ensayo10 = " & "'" & ZGrabaEspe(10, 1) & "',"
            ZSql = ZSql & "Valor10 = " & "'" & ZGrabaEspe(10, 2) & "',"
            ZSql = ZSql & "WDate = " & "'" & WDate & "',"
            ZSql = ZSql & "Valor11 = " & "'" & ZGrabaEspe(1, 3) & "',"
            ZSql = ZSql & "Valor22 = " & "'" & ZGrabaEspe(2, 3) & "',"
            ZSql = ZSql & "Valor33 = " & "'" & ZGrabaEspe(3, 3) & "',"
            ZSql = ZSql & "Valor44 = " & "'" & ZGrabaEspe(4, 3) & "',"
            ZSql = ZSql & "Valor55 = " & "'" & ZGrabaEspe(5, 3) & "',"
            ZSql = ZSql & "Valor66 = " & "'" & ZGrabaEspe(6, 3) & "',"
            ZSql = ZSql & "Valor77 = " & "'" & ZGrabaEspe(7, 3) & "',"
            ZSql = ZSql & "Valor88 = " & "'" & ZGrabaEspe(8, 3) & "',"
            ZSql = ZSql & "Valor99 = " & "'" & ZGrabaEspe(9, 3) & "',"
            ZSql = ZSql & "Valor1010 = " & "'" & ZGrabaEspe(10, 3) & "',"
            ZSql = ZSql & "Version = " & "'" & ZVersion & "',"
            ZSql = ZSql & "Fecha = " & "'" & ZFecha & "',"
            ZSql = ZSql & "Estado = " & "'" & "S" & "',"
            ZSql = ZSql & "ControlCambio = " & "'" & txtControlCambios.Text & "',"
            ZSql = ZSql & "Observaciones = " & "'" & "" & "'"
            ZSql = ZSql & " Where Producto = " & "'" & txtTerminado.Text & "'"

            WConsultasII.Add(ZSql)

        End If

        ZSql = ""
        ZSql = ZSql & "UPDATE EspecifUnifica SET "
        ZSql = ZSql & " Operador = '" & Operador.Codigo & "'"
        ZSql = ZSql & " Where Producto = '" + txtTerminado.Text & "'"

        WConsultasII.Add(ZSql)

        ExecuteNonQueries("Surfactan_II", WConsultasII.ToArray)

        For Each emp As String In {"SurfactanSa", "Surfactan_II", "Surfactan_III", "Surfactan_IV", "Surfactan_V", "Surfactan_VI", "Surfactan_VII"}

            ZSql = ""
            ZSql = ZSql & "UPDATE Terminado SET "
            ZSql = ZSql & "VersionII = " + "'" + ZVersion + "',"
            ZSql = ZSql & "FechaVersionII = " + "'" + Date.Now.ToString("dd/MM/yyyy") + "',"
            ZSql = ZSql & "EstadoII = " + "'" + "S" + "',"
            ZSql = ZSql & "ObservaII = " + "'" + "" + "'"
            ZSql = ZSql & " Where Codigo = " + "'" + txtTerminado.Text + "'"

            ExecuteNonQueries(emp, {ZSql})

        Next
    End Sub

    Private Sub btnConsultas_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnConsultas.Click
        With New ListaConsultas("Productos Terminados", "Ensayos")
            .Show(Me)
        End With
    End Sub

    Public Sub _ProcesarListaConsultas(ByVal Opcion As Integer) Implements IListaConsultas._ProcesarListaConsultas

        Select Case Opcion
            Case 0
                With New AyudaPTs
                    .Show(Me)
                End With
            Case 1
                With New AyudaEnsayos
                    .Show(Me)
                End With
        End Select

    End Sub

    Public Sub _ProcesarAyudaPTs(ByVal Codigo As String, ByVal WDescripcion As String) Implements IAyudaPTs._ProcesarAyudaPTs
        txtTerminado.Text = Codigo
        txtTerminado_KeyDown(Nothing, New KeyEventArgs(Keys.Enter))
    End Sub

    Public Sub _ProcesarAyudaEnsayos(ByVal Codigo As String, ByVal WDescripcion As String) Implements IAyudaEnsayos._ProcesarAyudaEnsayos
        Dim _r As Integer = -1

        For Each row As DataGridViewRow In dgvEspecif.Rows
            If Trim(OrDefault(row.Cells("Ensayo").Value, "")) = "" Then
                _r = row.Index
                Exit For
            End If
        Next

        If _r = -1 Then _r = dgvEspecif.Rows.Add

        dgvEspecif.Rows(_r).Cells("Ensayo").Value = Codigo
        dgvEspecif.Rows(_r).Cells("Especificacion").Value = WDescripcion
        dgvEspecif.CurrentCell = dgvEspecif.Rows(_r).Cells("Ensayo")

        dgvEspecif.Focus()

    End Sub

    Private Sub btnNotas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNotas.Click
        With New NotasCertificadosAnalisis(txtTerminado.Text)
            .Show(Me)
        End With
    End Sub

    Private Sub IngresoEspecificacionesPT_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        txtTerminado.Focus()
    End Sub

    Private Sub btnRevalidar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRevalidar.Click

        If Val(txtEtapa.Text) = 99 Then

            '
            ' Pido clave de Seguridad para autorizar el Proceso. Si se encuentra autorizado, prosigo con la grabación.
            '
            If Not WAutorizado Then

                WTipoProceso = TipoProcesosIngEspecif.Revalida

                With New IngresoClaveSeguridad
                    .Show(Me)
                End With

                Exit Sub

            End If

            ExecuteNonQueries("Surfactan_II", {"UPDATE EspecifUnifica SET Estado = 'S' WHERE Producto = '" & txtTerminado.Text & "'"})

            '
            ' Recorro todas las empresas de Surfactan y coloco como que se encuentra valida la Especificacion.
            '
            For Each emp As String In {"SurfactanSa", "Surfactan_II", "Surfactan_III", "Surfactan_IV", "Surfactan_V", "Surfactan_VI", "Surfactan_VII"}
                ExecuteNonQueries(emp, {"UPDATE Terminado SET EstadoII = 'S' WHERE Codigo = '" & txtTerminado.Text & "'"})
            Next

            btnLimpiar.PerformClick()

        End If

    End Sub

    Public Sub _ProcesarIngresoClaveSeguridad(ByVal WClave As Object) Implements IIngresoClaveSeguridad._ProcesarIngresoClaveSeguridad
        Dim WOperador As DataRow = GetSingle("SELECT * FROM Operador WHERE UPPER(Clave) = '" & WClave & "'")

        Dim WGrabaII As String = ""

        If WOperador IsNot Nothing Then
            WGrabaII = UCase(Trim(OrDefault(WOperador.Item("GrabaII"), "")))
        End If

        Select Case WTipoProceso
            Case TipoProcesosIngEspecif.Revalida

                WAutorizado = WGrabaII = "S" Or UCase(WClave) = "AUTORIZA"

                btnRevalidar.PerformClick()

            Case TipoProcesosIngEspecif.GrabaVersion

                WAutorizado = WGrabaII = "S"

                btnGrabar.PerformClick()

        End Select

    End Sub

    Private Sub dgvEspecif_RowHeaderMouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvEspecif.RowHeaderMouseDoubleClick
        If e.RowIndex < 0 Then Exit Sub

        If MsgBox("¿Seguro de querer eliminar este Ensayo?", MsgBoxStyle.YesNo) <> MsgBoxResult.Yes Then Exit Sub

        With dgvEspecif
            .Rows.Remove(.CurrentRow)

            If .Rows.Count = 0 Then .Rows.Add()

            If e.RowIndex - 1 >= .Rows.Count - 1 Then
                .Rows.Add()
            End If

            .CurrentCell = .Rows(0).Cells("Ensayo")
            .Focus()
        End With

    End Sub




    Private Function _EsNumero(ByVal keycode As Integer) As Boolean
        Return (keycode >= 48 And keycode <= 57) Or (keycode >= 96 And keycode <= 105)
    End Function

    Private Function _EsControl(ByVal keycode) As Boolean
        Dim valido As Boolean = False

        Select Case keycode
            Case Keys.Enter, Keys.Escape, Keys.Right, Keys.Left, Keys.Back
                valido = True
            Case Else
                valido = False
        End Select

        Return valido
    End Function

    Private Function _EsDecimal(ByVal keycode As Integer) As Boolean
        Return (keycode >= 48 And keycode <= 57) Or (keycode >= 96 And keycode <= 105) Or (keycode = 110 Or keycode = 190)
    End Function

    Private Function _EsNumeroOControl(ByVal keycode) As Boolean
        Dim valido As Boolean = False

        If _EsNumero(CInt(keycode)) Or _EsControl(keycode) Then
            valido = True
        Else
            valido = False
        End If

        Return valido
    End Function

    Private Function _EsDecimalOControl(ByVal keycode) As Boolean
        Dim valido As Boolean = False

        If _EsDecimal(CInt(keycode)) Or _EsControl(keycode) Then
            valido = True
        Else
            valido = False
        End If

        Return valido
    End Function

    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean

        With dgvEspecif
            If .Focused Or .IsCurrentCellInEditMode Then ' Detectamos los ENTER tanto si solo estan en foco o si estan en edición una celda.
                .CommitEdit(DataGridViewDataErrorContexts.Commit) ' Guardamos todos los datos que no hayan sido confirmados.

                Dim iCol = .CurrentCell.ColumnIndex
                Dim iRow = .CurrentCell.RowIndex
                Dim valor As String = OrDefault(.CurrentCell.Value, "")

                ' Limitamos los caracteres permitidos para cada una de las columnas.
                Select Case iCol
                    Case 0
                        If Not _EsNumeroOControl(keyData) Then
                            Return True
                        End If
                    Case -1
                        If Not _EsDecimalOControl(keyData) Then
                            Return True
                        End If
                    Case Else

                End Select

                If msg.WParam.ToInt32() = Keys.Enter Then


                    Select Case iCol
                        Case 0

                            If Val(valor) = 0 Then Return True

                            Dim WEnsayo As DataRow = GetSingle("SELECT Descripcion FROM Ensayos WHERE Codigo = '" & valor & "'", "Surfactan_II")

                            If WEnsayo Is Nothing Then Return True

                            .Rows(iRow).Cells("Especificacion").Value = Trim(OrDefault(WEnsayo.Item("Descripcion"), ""))

                    End Select


                    Select Case iCol
                        Case 2

                            If iRow >= .Rows.Count - 1 Then
                                .Rows.Add()
                            End If

                            .CurrentCell = .Rows(iRow + 1).Cells("Ensayo")

                        Case Else
                            .CurrentCell = .Rows(iRow).Cells("DescEnsayo")

                            If Trim(OrDefault(.Rows(iRow).Cells("DescEnsayo").Value, "")) = "" Then
                                dgvEspecif_CellDoubleClick(Nothing, New DataGridViewCellEventArgs(iCol, iRow))
                            End If

                    End Select

                    Return True

                ElseIf msg.WParam.ToInt32() = Keys.Escape Then

                    If iCol = 0 Then

                        .Rows(iRow).Cells(iCol).Value = ""

                        If iCol = 2 Then
                            .CurrentCell = .Rows(iRow).Cells(iCol - 1)
                        Else
                            .CurrentCell = .Rows(iRow).Cells(iCol + 1)
                        End If

                    End If

                    .CurrentCell = .Rows(iRow).Cells(iCol)

                End If
            End If

        End With

        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

    Private Sub btnImpresion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImpresion.Click
        Dim WTerminado As DataRow = GetSingle("SELECT Vida FROM Terminado WHERE Codigo = '" & txtTerminado.Text & "'")

        If WTerminado Is Nothing Then Exit Sub

        Dim WVida As String = OrDefault(WTerminado.Item("Vida"), "0")

        Dim WCargaV As DataTable = GetAll("SELECT Valor, Clave, MenorIgualEspecif, InformaEspecif, TipoEspecif, UnidadEspecif, DesdeEspecif, HastaEspecif, Farmacopea, Ensayo FROM CargaV WHERE Terminado = '" & txtTerminado.Text & "' And Paso = '" & txtEtapa.Text & "' Order by Clave")

        If WCargaV.Rows.Count = 0 Then Exit Sub

        Dim WSqls As New List(Of String)

        WSqls.Add(String.Format("UPDATE CargaV SET Partida = '0', ImprePaso = Paso, CantidadPartida = '' WHERE Terminado = '{0}'", txtTerminado.Text))

        For Each row As DataRow In WCargaV.Rows
            Dim WObservacion1 As String = ""

            With row

                WObservacion1 = _GenerarImpreParametro(OrDefault(.Item("TipoEspecif"), ""), OrDefault(.Item("DesdeEspecif"), ""), OrDefault(.Item("HastaEspecif"), ""), OrDefault(.Item("UnidadEspecif"), ""), OrDefault(.Item("MenorIgualEspecif"), ""))

                WSqls.Add(String.Format("UPDATE CargaV SET Observacion1 = '{1}' WHERE Clave = '{0}'", .Item("Clave"), _Left(WObservacion1.Trim, 100)))

            End With

        Next

        ExecuteNonQueries(WSqls.ToArray)

        With New VistaPrevia
            .Reporte = New ImpreEspecificacionesPT
            .Formula = "{CargaV.Terminado}='" & txtTerminado.Text & "' And {CargaV.Paso} <> 99"
            '.Formula = "{CargaV.Terminado}='" & txtTerminado.Text & "' And {CargaV.Paso}=" & txtEtapa.Text & ""
            .Mostrar()
        End With

        Dim WEspecIngles As DataRow = GetSingle("SELECT Clave FROM CargaVIngles WHERE Terminado = '" & txtTerminado.Text & "' And Paso <> 99")

        If WEspecIngles Is Nothing Then Exit Sub

        With New VistaPrevia
            .Reporte = New ImpreEspecificacionesPTIngles
            .Formula = "{CargaV.Terminado}='" & txtTerminado.Text & "' And {CargaV.Paso} <> 99"
            .Mostrar()
        End With

    End Sub

    Private Sub btnHistorialCambios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHistorialCambios.Click

        With New HistorialCambios("T", txtTerminado.Text)
            .Show(Me)
        End With

    End Sub
End Class