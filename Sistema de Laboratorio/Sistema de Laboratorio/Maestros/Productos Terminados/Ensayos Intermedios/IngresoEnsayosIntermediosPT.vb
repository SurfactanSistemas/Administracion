﻿Imports System.IO
Imports System.Text.RegularExpressions
Imports ConsultasVarias
Imports ConsultasVarias.Clases
Imports info.lundin.math

Public Class IngresoEnsayosIntermediosPT : Implements INotasEnsayosProductosTerminados, IIngresoClaveSeguridad, IIngresoMotivoDesvio

    Private WNotas As New List(Of String)
    Private WEsPorDesvio As Boolean = False
    Private WMotivoDesvio As String = ""
    Private WMotivoClaveSeguridad As TiposSolicitudClaveSeguridad = TiposSolicitudClaveSeguridad.General
    Private WActualizacionBloqueada As Boolean = False
    Private WAutorizaActualizacionBloqueado As Boolean = False
    Private ReadOnly PATH_ENSAYOS_INTERMEDIOS As String = Configuration.ConfigurationManager.AppSettings("PATH_ENSAYOS_INTERMEDIOS").ToString()
    Private ReadOnly DESTINATARIOS_AVISO_ENSAYOS_INTERMEDIOS As String = Configuration.ConfigurationManager.AppSettings("DESTINATARIOS_AVISO_ENSAYOS_INTERMEDIOS").ToString()

    Private Const RUTA_TEMP As String = "C:/tempEnsayosIntermedios/"

    Private Sub btnCerrar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCerrar.Click
        Close()
    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnLimpiar.Click
        For Each c As Control In {txtFechaRevalida, txtArchivo, txtCodigo, txtConfecciono, txtEnvases, txtComponente, txtLotePartida, txtCantidadEtiquetas, txtDesvio, txtEtapa, txtFecha, txtLibros, txtOOS, txtPaginas, txtPartida, lblTipoProceso, txtFechaVto, lblDescEtapa, txtEspecifActual, txtEspecifOrig, txtRevalida, txtKilos}
            c.Text = ""
        Next
        dgvEnsayos.Rows.Clear()

        WNotas = New List(Of String)
        For i = 0 To 8
            WNotas.Add("")
        Next

        WEsPorDesvio = False
        WMotivoDesvio = ""

        WMotivoClaveSeguridad = TiposSolicitudClaveSeguridad.General
        WActualizacionBloqueada = False
        WAutorizaActualizacionBloqueado = False
        btnRevalida.Enabled = False
        txtComponente.Enabled = False
        txtLotePartida.Enabled = False
        btnNotasCertAnalisis.Enabled = False
        btnReimprimir.Visible = False
        gbDatosAdicionales.Visible = False

        txtPartida.Focus()
    End Sub

    Private Sub IngresoEnsayosIntermediosPT_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        dgvEnsayos.InhabilitarOrdenamientoColumnas()
        btnLimpiar_Click(Nothing, Nothing)
    End Sub

    Private Sub IngresoEnsayosIntermediosPT_Shown(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Shown
        txtPartida.Focus()
    End Sub

    Private Sub txtPartida_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtPartida.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txtPartida.Text) = "" Then : Exit Sub : End If

            Dim WHoja As DataRow = GetSingle("SELECT Producto FROM Hoja WHERE Hoja = '" & txtPartida.Text & "' And Renglon in ('1', '01')")

            If IsNothing(WHoja) Then Exit Sub

            With WHoja
                txtCodigo.Text = OrDefault(.Item("Producto"), "")
            End With

            lblTipoProceso.Text = ""

            Dim WCargaIII As DataRow = GetSingle("SELECT TipoProceso FROM CargaIII WHERE Terminado = '" & txtCodigo.Text & "' And Paso in ('1', '01')")

            If WCargaIII IsNot Nothing Then
                lblTipoProceso.Text = OrDefault(WCargaIII.Item("TipoProceso"), "").ToString.Trim.ToUpper
            End If

            txtEtapa.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtPartida.Text = ""
        End If

    End Sub

    Private Sub txtEtapa_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtEtapa.KeyDown, txtRevalida.KeyDown, txtKilos.KeyDown, txtEspecifOrig.KeyDown, txtEspecifActual.KeyDown

        If e.KeyData = Keys.Enter Then
            If Val(txtEtapa.Text) = 0 Then : Exit Sub : End If
            If Val(txtPartida.Text) = 0 Then : Exit Sub : End If

            WMotivoDesvio = ""

            btnGrabar.Text = "GRABAR"

            _CrearCarpetaEtapaIntermedia()

            Dim WExiste As DataRow = Nothing

            If Val(txtEtapa.Text) = 99 Then
                WExiste = GetSingle("SELECT Clave FROM Prueterfarma WHERE Partida = '" + txtPartida.Text + "' And Renglon = '1'")
            Else
                WExiste = GetSingle("SELECT Clave FROM PrueterfarmaIntermedio WHERE Producto = '" + txtCodigo.Text + "' And Paso = '" & txtEtapa.Text & "' And Renglon = '1'")
            End If

            If WExiste IsNot Nothing Then

                btnReimprimir.Visible = True

                Dim WPrueterFarma As DataTable = Nothing

                If Val(txtEtapa.Text) = 99 Then
                    WPrueterFarma = GetAll("SELECT * FROM PrueterFarma WHERE Partida = '" & txtPartida.Text & "' And Producto = '" & txtCodigo.Text & "' Order By Clave")
                Else
                    WPrueterFarma = GetAll("SELECT * FROM PrueterFarmaIntermedio WHERE Partida = '" & txtPartida.Text & "' And Producto = '" & txtCodigo.Text & "' And Paso = '" & txtEtapa.Text & "' Order By Clave")
                End If

                dgvEnsayos.Rows.Clear()

                If WPrueterFarma.Rows.Count = 0 Then Exit Sub

                Dim WFecha = ""
                Dim WConfecciono = ""
                Dim WLibros = ""
                Dim WPaginas = ""
                Dim WNroOOS = ""
                Dim WNroDesvio = ""
                Dim WArchivo = ""
                Dim WEnvases = ""
                Dim WComponente = ""
                Dim WLotePartida = ""
                Dim WCantEtiq = 0

                For Each row As DataRow In WPrueterFarma.Rows
                    With row
                        Dim WEns = OrDefault(.Item("Codigo"), "")
                        Dim WEspecificacion = OrDefault(.Item("Valor"), "")
                        Dim WValor = Trim(OrDefault(.Item("ValorReal"), ""))
                        Dim WResultado = OrDefault(.Item("Resultado"), "")
                        Dim WFarmacopea = OrDefault(.Item("Farmacopea"), "")
                        Dim WTipoEspecif = OrDefault(.Item("TipoEspecif"), "")
                        Dim WDesdeEspecif = OrDefault(.Item("DesdeEspecif"), "")
                        Dim WHastaEspecif = OrDefault(.Item("HastaEspecif"), "")
                        Dim WUnidadEspecif = OrDefault(.Item("UnidadEspecif"), "")
                        Dim WMenorIgualEspecif = OrDefault(.Item("MenorIgualEspecif"), "")
                        Dim WInformaEspecif = OrDefault(.Item("InformaEspecif"), "")
                        Dim WFormulaEspecif = OrDefault(.Item("FormulaEspecif"), "")
                        Dim WImpreResultado = _GenerarImpreParametro(WTipoEspecif, WDesdeEspecif, WHastaEspecif, WUnidadEspecif, WMenorIgualEspecif)

                        WFecha = OrDefault(.Item("Fecha"), "")
                        WConfecciono = OrDefault(.Item("Confecciono"), "")
                        WLibros = OrDefault(.Item("Libros"), "")
                        WPaginas = OrDefault(.Item("Paginas"), "")
                        WNroOOS = OrDefault(.Item("NroOOS"), "")
                        WNroDesvio = OrDefault(.Item("NroDesvio"), "")
                        WArchivo = OrDefault(.Item("Archiva"), "")
                        WMotivoDesvio = OrDefault(.Item("MotivoDesvio"), "")
                        WEnvases = OrDefault(.Item("Envases"), "")
                        WComponente = OrDefault(.Item("Componente"), "")
                        WLotePartida = OrDefault(.Item("LotePartida"), "")
                        WCantEtiq = OrDefault(.Item("CantiEti"), 0)

                        Dim WFormulas(10, 2) As String

                        For i = 1 To 10
                            WFormulas(i, 1) = Trim(OrDefault(.Item("Variable" & i), ""))
                            WFormulas(i, 2) = Trim(OrDefault(.Item("VariableValor" & i), "0"))
                        Next

                        If Val(WTipoEspecif) = 0 And WImpreResultado <> "" Then WImpreResultado &= " (c)"

                        Dim WDescripcion = "" 'OrDefault(.Item("Ensayo"), 0)

                        If Trim(WResultado) = "" Then WResultado = _GenerarImpreResultado(WTipoEspecif, WDesdeEspecif, WHastaEspecif, WUnidadEspecif, WValor)

                        Dim r = dgvEnsayos.Rows.Add

                        With dgvEnsayos.Rows(r)
                            .Cells("Ensayo").Value = WEns
                            .Cells("Valor").Value = Trim(UCase(WValor))
                            .Cells("Resultado").Value = Trim(WResultado)
                            .Cells("Especificacion").Value = Trim(WEspecificacion)
                            .Cells("Descripcion").Value = Trim(WDescripcion)
                            .Cells("Farmacopea").Value = Trim(WFarmacopea)
                            .Cells("TipoEspecif").Value = WTipoEspecif
                            .Cells("DesdeEspecif").Value = WDesdeEspecif
                            .Cells("HastaEspecif").Value = WHastaEspecif
                            .Cells("UnidadEspecif").Value = WUnidadEspecif
                            .Cells("MenorIgualEspecif").Value = WMenorIgualEspecif
                            .Cells("InformaEspecif").Value = WInformaEspecif
                            .Cells("Parametro").Value = Trim(WImpreResultado)
                            .Cells("FormulaEspecif").Value = Trim(WFormulaEspecif)

                            For i = 1 To 10
                                .Cells("Variable" & i).Value = Trim(WFormulas(i, 1))
                                .Cells("VariableValor" & i).Value = WFormulas(i, 2)
                            Next

                            .Cells("Decimales").Value = ""

                            If Val(WTipoEspecif) = 2 Then

                                .Cells("Decimales").Value = "2"

                                .Cells("Decimales").Value = IIf(WValor.Trim = "", "2", "0")

                                Dim aux As Integer = WValor.ToString.IndexOfAny({",", "."})

                                If aux > 0 Then
                                    Dim t As String = _Right(WValor, WValor.Replace(".", "").Replace(",", "").Length - aux)
                                    .Cells("Decimales").Value = t.Length
                                End If

                            End If

                        End With

                    End With

                Next

                txtFecha.Text = Trim(WFecha)
                txtConfecciono.Text = Trim(WConfecciono).ToUpper
                txtLibros.Text = Trim(WLibros)
                txtPaginas.Text = Trim(WPaginas)
                txtOOS.Text = Trim(WNroOOS)
                txtDesvio.Text = Trim(WNroDesvio)
                txtArchivo.Text = Trim(WArchivo)
                txtComponente.Text = Trim(WComponente)
                txtEnvases.Text = Trim(WEnvases)
                txtLotePartida.Text = Trim(WLotePartida)
                If WCantEtiq > 0 Then txtCantidadEtiquetas.Text = Trim(WCantEtiq)

                Dim _Notas As DataRow = GetSingle("SELECT Nota1, Nota2, Nota3, Nota4, Nota5, Nota6, Nota7, Nota8, Nota9 FROM PrueterFarmaIntermedio WHERE Partida = '" & txtPartida.Text & "' And Producto = '" & txtCodigo.Text & "' And Paso = '" & txtEtapa.Text & "'")

                WNotas.Clear()

                If _Notas IsNot Nothing Then

                    For i = 0 To 8

                        Dim WContenido As String = OrDefault(_Notas.Item("Nota" & i + 1), "")

                        WNotas.Add(Trim(WContenido))

                    Next

                End If

                btnGrabar.Text = "ACTUALIZAR"

            Else

                Dim WCargaV As DataTable = GetAll("SELECT * FROM CargaV WHERE Terminado = '" & txtCodigo.Text & "' And Paso = '" & txtEtapa.Text & "' Order By Clave")

                If WCargaV.Rows.Count = 0 Then Exit Sub

                dgvEnsayos.Rows.Clear()

                For Each row As DataRow In WCargaV.Rows
                    With row
                        Dim WEns = OrDefault(.Item("Ensayo"), 0)
                        Dim WEspecificacion = OrDefault(.Item("Valor"), "")
                        Dim WFarmacopea = OrDefault(.Item("Farmacopea"), "")
                        Dim WTipoEspecif = OrDefault(.Item("TipoEspecif"), "")
                        Dim WDesdeEspecif = OrDefault(.Item("DesdeEspecif"), "")
                        Dim WHastaEspecif = OrDefault(.Item("HastaEspecif"), "")
                        Dim WUnidadEspecif = OrDefault(.Item("UnidadEspecif"), "")
                        Dim WMenorIgualEspecif = OrDefault(.Item("MenorIgualEspecif"), "")
                        Dim WInformaEspecif = OrDefault(.Item("InformaEspecif"), "")
                        Dim WFormula = Trim(OrDefault(.Item("FormulaEspecif"), ""))
                        Dim WImpreParametro = _GenerarImpreParametro(WTipoEspecif, WDesdeEspecif, WHastaEspecif, WUnidadEspecif, WMenorIgualEspecif)

                        Dim WFormulas(10) As String

                        For i = 1 To 10
                            WFormulas(i) = Trim(OrDefault(.Item("Variable" & i), ""))
                        Next

                        If Val(WTipoEspecif) = 0 And WImpreParametro <> "" Then WImpreParametro &= " (c)"

                        Dim WDescripcion = "" 'OrDefault(.Item("Ensayo"), 0)

                        Dim r = dgvEnsayos.Rows.Add

                        With dgvEnsayos.Rows(r)
                            .Cells("Ensayo").Value = WEns
                            .Cells("Especificacion").Value = Trim(WEspecificacion)
                            .Cells("Descripcion").Value = Trim(WDescripcion)
                            .Cells("Farmacopea").Value = Trim(WFarmacopea)
                            .Cells("TipoEspecif").Value = WTipoEspecif
                            .Cells("DesdeEspecif").Value = WDesdeEspecif
                            .Cells("HastaEspecif").Value = WHastaEspecif
                            .Cells("UnidadEspecif").Value = WUnidadEspecif
                            .Cells("MenorIgualEspecif").Value = WMenorIgualEspecif
                            .Cells("InformaEspecif").Value = WInformaEspecif
                            .Cells("Parametro").Value = Trim(WImpreParametro)
                            .Cells("FormulaEspecif").Value = Trim(WFormula)

                            For i = 1 To 10
                                .Cells("Variable" & i).Value = Trim(WFormulas(i))
                                .Cells("VariableValor" & i).Value = "0"
                            Next

                        End With

                    End With

                Next

                Dim WRenglon = 0

                '
                ' Cargamos las especificaciones en Inglés.
                '
                Dim WCargaVIngles As DataTable = GetAll("SELECT Valor, UnidadEspecif FROM CargaVIngles WHERE Terminado = '" & txtCodigo.Text & "' And Paso = '" & txtEtapa.Text & "' Order By Clave")

                For Each row As DataRow In WCargaVIngles.Rows

                    With row

                        Dim WUnidadEspecif = Trim(OrDefault(.Item("UnidadEspecif"), ""))
                        Dim WEspecificacion = Trim(OrDefault(.Item("Valor"), ""))

                        If WRenglon > dgvEnsayos.Rows.Count - 1 Then WRenglon = dgvEnsayos.Rows.Add

                        With dgvEnsayos.Rows(WRenglon)

                            If WUnidadEspecif = "" Then
                                .Cells("EspecificacionIngles").Value = WEspecificacion
                            Else
                                .Cells("EspecificacionIngles").Value = String.Format("{0} ({1})", WEspecificacion, WUnidadEspecif)
                            End If

                            .Cells("UnidadEspecif").Value = WUnidadEspecif
                        End With

                        WRenglon += 1

                    End With

                Next

                txtFecha.Text = Date.Now.ToString("dd/MM/yyyy")

            End If

            Dim WCargaIII As DataRow = GetSingle("SELECT DesEtapa FROM CargaIII WHERE Terminado = '" & txtCodigo.Text & "' And Paso = " & txtEtapa.Text & " And Renglon = 1")

            If WCargaIII IsNot Nothing Then
                lblDescEtapa.Text = OrDefault(WCargaIII.Item("DesEtapa"), "").ToString.Trim.ToUpper
            End If

            If Val(txtEtapa.Text) = 99 Then
                Dim WDatosAdicionales As DataRow = GetSingle("select h.Revalida, h.VersionIII VersionI, h.MesesRevalida, h.FechaRevalida, h.Real, t.VersionII from hoja h inner join Terminado t on t.Codigo = h.Producto where h.hoja = '" & txtPartida.Text & "'")
                If WDatosAdicionales IsNot Nothing Then
                    With WDatosAdicionales
                        txtRevalida.Text = OrDefault(.Item("Revalida"), "")
                        txtEspecifOrig.Text = OrDefault(.Item("VersionI"), "")
                        txtMeses.Text = OrDefault(.Item("MesesRevalida"), "")
                        txtFechaRevalida.Text = OrDefault(.Item("FechaRevalida"), Space(8))
                        txtEspecifActual.Text = OrDefault(.Item("VersionII"), "")
                        txtKilos.Text = formatonumerico(OrDefault(.Item("Real"), ""))
                    End With
                End If
            End If

            txtFechaVto.Text = Entidades.ProductoTerminado.CalcularFechaElabVto(txtCodigo.Text, txtPartida.Text, True)(1)

            '
            ' Cargamos en caso de que no tenga, el componente si es monoproducto.
            '
            If Entidades.ProductoTerminado.EsMono(txtCodigo.Text) Then
                Dim WComp As DataRow = GetSingle("SELECT Articulo = CASE WHEN Tipo = 'M' THEN Articulo1 ELSE Articulo2 END FROM Composicion WHERE Terminado = '" & txtCodigo.Text & "' Order by Renglon")
                If WComp IsNot Nothing Then txtComponente.Text = Trim(OrDefault(WComp.Item("Articulo"), ""))
            End If

            If Val(txtEtapa.Text) = 99 Then
                btnNotasCertAnalisis.Enabled = True
                btnRevalida.Enabled = True
                txtComponente.Enabled = True
                txtLotePartida.Enabled = True
                gbDatosAdicionales.Visible = True
            End If
            
            If dgvEnsayos.Rows.Count > 0 Then
                dgvEnsayos.CurrentCell = dgvEnsayos.Item("Valor", 0)
                dgvEnsayos.Focus()
            Else
                txtEtapa.Focus()
            End If

        ElseIf e.KeyData = Keys.Escape Then
            txtEtapa.Text = ""
        End If

    End Sub

    Private Sub _CrearCarpetaEtapaIntermedia()
        Directory.CreateDirectory(_CarpetaEtapaIntermedia)
    End Sub

    Private Function _GenerarImpreParametro(ByVal wTipoEspecif As String, ByVal wDesdeEspecif As String, ByVal wHastaEspecif As String, ByVal wUnidadEspecif As String, ByVal wMenorIgualEspecif As String) As String
        If Val(wTipoEspecif) = 0 Then Return "Cumple Ensayo"
        If Trim(wDesdeEspecif) = "" And Trim(wHastaEspecif) = "" Then Return ""

        wTipoEspecif = Trim(wTipoEspecif)
        wDesdeEspecif = Trim(wDesdeEspecif)
        wHastaEspecif = Trim(wHastaEspecif)
        wUnidadEspecif = Trim(wUnidadEspecif)
        wMenorIgualEspecif = Trim(wMenorIgualEspecif)

        If {99, 999, 9999, 99999}.Contains(Val(wHastaEspecif)) Then wHastaEspecif = "9999"

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

    Private Function _CarpetaEtapaIntermedia() As String
        Return String.Format("{0}{1}/{2}", PATH_ENSAYOS_INTERMEDIOS, txtPartida.Ceros(6), txtEtapa.Ceros(2))
    End Function

    Private Sub btnNotas_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnNotas.Click

        With New NotasEnsayosProductosTerminados
            .Partida = Val(txtPartida.Text)
            .Terminado = txtCodigo.Text
            .Etapa = Val(txtEtapa.Text)
            .Notas = WNotas
            .ShowDialog(Me)
        End With

    End Sub

    Public Sub _ProcesarNotasEnsayosProductosTerminados(ByVal _Notas As List(Of String)) Implements INotasEnsayosProductosTerminados._ProcesarNotasEnsayosProductosTerminados
        WNotas = _Notas
    End Sub

    'Private Function _EsNumero(ByVal keycode As Integer) As Boolean
    '    Return (keycode >= 48 And keycode <= 57) Or (keycode >= 96 And keycode <= 105)
    'End Function

    'Private Function _EsControl(ByVal keycode) As Boolean
    '    Dim valido As Boolean = False

    '    Select Case keycode
    '        Case Keys.Enter, Keys.Escape, Keys.Right, Keys.Left, Keys.Back
    '            valido = True
    '        Case Else
    '            valido = False
    '    End Select

    '    Return valido
    'End Function

    'Private Function _EsDecimal(ByVal keycode As Integer) As Boolean
    '    Return (keycode >= 48 And keycode <= 57) Or (keycode >= 96 And keycode <= 105) Or (keycode = 110 Or keycode = 190)
    'End Function

    'Private Function _EsNumeroOControl(ByVal keycode) As Boolean
    '    Dim valido As Boolean = False

    '    If _EsNumero(CInt(keycode)) Or _EsControl(keycode) Then
    '        valido = True
    '    Else
    '        valido = False
    '    End If

    '    Return valido
    'End Function

    'Private Function _EsDecimalOControl(ByVal keycode) As Boolean
    '    Dim valido As Boolean = False

    '    If _EsDecimal(CInt(keycode)) Or _EsControl(keycode) Then
    '        valido = True
    '    Else
    '        valido = False
    '    End If

    '    Return valido
    'End Function

    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, ByVal keyData As Keys) As Boolean

        With dgvEnsayos
            If .Focused Or .IsCurrentCellInEditMode Then ' Detectamos los ENTER tanto si solo estan en foco o si estan en edición una celda.
                .CommitEdit(DataGridViewDataErrorContexts.Commit) ' Guardamos todos los datos que no hayan sido confirmados.

                Dim iCol = .CurrentCell.ColumnIndex
                Dim iRow = .CurrentCell.RowIndex
                Dim WValor As String = UCase(OrDefault(.CurrentCell.Value, ""))

                ' Limitamos los caracteres permitidos para cada una de las columnas.
                'Select Case iCol
                '    Case 1
                '        If Not _EsNumeroOControl(keyData) Then
                '            Return True
                '        End If
                '    Case 4
                '        If Not _EsDecimalOControl(keyData) Then
                '            Return True
                '        End If
                '    Case Else

                'End Select

                If msg.WParam.ToInt32() = Keys.Enter Then

                    If Not _ProcesarValorGrilla(.CurrentCell) Then Return True

                    Select Case iCol
                        Case 2
                            If iRow = .Rows.Count - 1 Then
                                '.CurrentCell = .Rows(iRow).Cells(iCol)
                                .CurrentCell = .Rows(iRow).Cells(iCol + 1)
                            Else
                                .CurrentCell = .Rows(iRow + 1).Cells("Valor")
                            End If

                        Case Else
                            If iCol < 3 Then
                                .CurrentCell = .Rows(iRow).Cells(iCol + 1)
                            Else
                                If iRow < .Rows.Count - 1 Then
                                    .CurrentCell = .Rows(iRow + 1).Cells("Valor")
                                End If
                            End If
                    End Select

                    Return True

                ElseIf msg.WParam.ToInt32() = Keys.Escape Then
                    .Rows(iRow).Cells(iCol).Value = ""

                    If iCol = 3 Then
                        .CurrentCell = .Rows(iRow).Cells(iCol - 1)
                    Else
                        .CurrentCell = .Rows(iRow).Cells(iCol + 1)
                    End If

                    .CurrentCell = .Rows(iRow).Cells(iCol)
                End If
            End If

        End With

        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

    Private Function _ProcesarValorGrilla(ByVal WCelda As DataGridViewCell) As Boolean

        Try

            With WCelda
                Select Case dgvEnsayos.Columns(.ColumnIndex).Name.ToUpper
                    Case "VALOR"
                        Dim WValor As String = Trim(UCase(OrDefault(.Value, "")))

                        If WValor = "P" And Val(OrDefault(dgvEnsayos.Rows(.RowIndex).Cells("TipoEspecif").Value, "")) <> 2 Then
                            dgvEnsayos.Rows(.RowIndex).Cells("Valor").Value = WValor
                            dgvEnsayos.Rows(.RowIndex).Cells("Resultado").Value = "PENDIENTE"
                        Else

                            If WValor.StartsWith(".") Then WValor = "0" & WValor

                            Dim WTipo As String = ""
                            Dim WDesde As String = ""
                            Dim WHasta As String = ""
                            Dim WUnidad As String = ""
                            Dim WFormula As String = ""
                            Dim WDecimales As String = ""
                            Dim WVariables(10, 2) As String

                            With dgvEnsayos.Rows(.RowIndex)

                                WTipo = OrDefault(.Cells("TipoEspecif").Value, "")
                                WDesde = OrDefault(.Cells("DesdeEspecif").Value, "")
                                WHasta = OrDefault(.Cells("HastaEspecif").Value, "")
                                WUnidad = OrDefault(.Cells("UnidadEspecif").Value, "")
                                WFormula = Trim(OrDefault(.Cells("FormulaEspecif").Value, ""))
                                WDecimales = Trim(OrDefault(.Cells("Decimales").Value, "2"))

                                For i = 1 To 10
                                    WVariables(i, 1) = Trim(OrDefault(.Cells("Variable" & i).Value, ""))
                                    WVariables(i, 2) = Trim(OrDefault(.Cells("VariableValor" & i).Value, ""))
                                Next

                                If WFormula <> "" Then

                                    With New IngresoVariablesFormula(WFormula, WVariables, WValor, dgvEnsayos, WDecimales)
                                        Dim WDialogResult = .ShowDialog(Me)
                                        If WDialogResult = Windows.Forms.DialogResult.OK Then
                                            WValor = .Valor
                                            WVariables = .Variables
                                            WDecimales = .Decimales
                                        Else
                                            Return False
                                        End If
                                    End With

                                End If

                                Dim WResultado As String = _GenerarImpreResultado(WTipo, WDesde, WHasta, WUnidad, WValor)

                                .Cells("Resultado").Value = WResultado
                                .Cells("Valor").Value = WValor
                                .Cells("Decimales").Value = WDecimales

                                For i = 1 To 10
                                    .Cells("VariableValor" & i).Value = Trim(OrDefault(WVariables(i, 2), ""))
                                Next

                            End With

                            If Not _ValidarDato(dgvEnsayos.Rows(.RowIndex)) Then
                                MsgBox("Resultado fuera de especificación", MsgBoxStyle.Information)
                            End If

                        End If

                End Select
            End With

            Return True

        Catch ex As FormatoNoNumericoException
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try

        Return False

    End Function

    Private Sub SoloNumero(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles txtPartida.KeyPress, txtEtapa.KeyPress, txtRevalida.KeyPress, txtEspecifActual.KeyPress, txtEspecifOrig.KeyPress, txtCantidadEtiquetas.KeyPress, txtMeses.KeyPress
        If Not Char.IsNumber(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub btnGrabar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnGrabar.Click

        Try
            _ValidarDatos()

            '
            ' Recalculamos los valores de las celdas que se calculen por Formula.
            '
            _RecalcularFormulas()

            If WActualizacionBloqueada Then

                WMotivoClaveSeguridad = TiposSolicitudClaveSeguridad.ActualizarEnsayoBloqueado

                Dim frm As New IngresoClaveSeguridad()
                frm.ShowDialog(Me)

                txtPartida.Focus()

                Exit Sub

            End If

            If Not _ValidarValoresIngresados() And Not WEsPorDesvio Then

                If MsgBox("Algunos de los valores indicados, no se encuentran dentro de los valores especificados para este Producto y etapa." & vbCrLf & vbCrLf & vbCrLf & "¿Desea Continuar con la Grabación por Desvío?", MsgBoxStyle.YesNoCancel) <> MsgBoxResult.Yes Then
                    WEsPorDesvio = False
                    Exit Sub
                End If

                If Val(txtDesvio.Text) = 0 Then Throw New Exception("Se debe indicar un número de Desvío.")
                If Val(txtOOS.Text) = 0 Then Throw New Exception("Se debe indicar un número de OOS.")

                Dim mot As New IngresoMotivoDesvio(WMotivoDesvio)

                If mot.ShowDialog(Me) <> DialogResult.OK Then Exit Sub

                WMotivoClaveSeguridad = TiposSolicitudClaveSeguridad.IngresoEnsayoIntermedioPorDesvio

                Dim frm As New IngresoClaveSeguridad
                frm.ShowDialog(Me)

                txtPartida.Focus()

                Exit Sub

            End If

            If txtDesvio.Text.Trim <> "" And Not WEsPorDesvio Then

                If MsgBox("Ha indicado información de Desvío para este Producto y etapa." & vbCrLf & vbCrLf & vbCrLf & "Si ésto es correcto ¿Desea Continuar con la Grabación del Ensayo?", MsgBoxStyle.YesNoCancel) <> MsgBoxResult.Yes Then
                    WEsPorDesvio = False
                    Exit Sub
                End If

                Dim mot As New IngresoMotivoDesvio(WMotivoDesvio)

                If mot.ShowDialog(Me) <> DialogResult.OK Then Exit Sub

                WMotivoClaveSeguridad = TiposSolicitudClaveSeguridad.IngresoEnsayoIntermedioPorDesvio

                Dim frm As New IngresoClaveSeguridad
                frm.ShowDialog(Me)

            End If

            _CrearCarpetaEtapaIntermedia()

            Dim WSqls As New List(Of String)

            Dim WPartida = txtPartida.Text
            Dim WCodigo = txtCodigo.Text
            Dim WEtapa = txtEtapa.Text
            Dim WFecha = txtFecha.Text
            Dim WFechaOrd = ordenaFecha(txtFecha.Text)
            Dim WLibros = txtLibros.Text.Trim
            Dim WPaginas = txtPaginas.Text.Trim
            Dim WNroOOS = txtOOS.Text.Trim
            Dim WNroDesvio = txtDesvio.Text.Trim
            Dim WConfecciono = txtConfecciono.Text.Trim
            Dim WArchivo = txtArchivo.Text.Trim

            Dim WPorDesvio = "0"

            If WEsPorDesvio Then
                WPorDesvio = "1"
            Else
                WMotivoDesvio = ""
            End If

            'Dim WMotivoDesvio = ""
            Dim WLiberada = ""

            If WNotas Is Nothing OrElse WNotas.Count = 0 Then
                For i = 0 To 9
                    WNotas.Add("")
                Next
            End If

            Dim WRenglon = 0

            Dim WTipoProceso As String = Trim(lblTipoProceso.Text)

            Dim WEsUnaActualizacion As Boolean = False

            Dim WTabla As String = IIf(Val(txtEtapa.Text) = 99, "Prueterfarma", "PrueterfarmaIntermedio")

            Dim WPrueterFarma As DataRow = Nothing

            If Val(WEtapa) = 99 Then

                WPrueterFarma = GetSingle("SELECT TOP 1 Clave FROM PrueterFarmaIntermedio WHERE Partida = '" & WPartida & "' And Producto = '" & WCodigo & "'")

                WSqls.Add("DELETE FROM Prueterfarma WHERE Partida = '" & WPartida & "' And Producto = '" & WCodigo & "'")

            Else

                WPrueterFarma = GetSingle("SELECT TOP 1 Clave FROM PrueterFarmaIntermedio WHERE Partida = '" & WPartida & "' And Producto = '" & WCodigo & "' And Paso = '" & WEtapa & "'")

                WSqls.Add("DELETE FROM PrueterfarmaIntermedio WHERE Partida = '" & WPartida & "' And Producto = '" & WCodigo & "' And Paso = '" & WEtapa & "'")

            End If

            WEsUnaActualizacion = WPrueterFarma IsNot Nothing

            For Each row As DataGridViewRow In dgvEnsayos.Rows
                With row
                    Dim WEns As String = OrDefault(.Cells("Ensayo").Value, 0)
                    Dim WEspecificacion As String = OrDefault(.Cells("Especificacion").Value, "")
                    Dim WValor As String = OrDefault(.Cells("Valor").Value, "")
                    Dim WResultado As String = OrDefault(.Cells("Resultado").Value, "")
                    Dim WFarmacopea As String = OrDefault(.Cells("Farmacopea").Value, "")
                    Dim WTipoEspecif As String = OrDefault(.Cells("TipoEspecif").Value, 0)
                    Dim WDesdeEspecif As String = OrDefault(.Cells("DesdeEspecif").Value, "")
                    Dim WHastaEspecif As String = OrDefault(.Cells("HastaEspecif").Value, "")
                    Dim WUnidadEspecif As String = OrDefault(.Cells("UnidadEspecif").Value, "")
                    Dim WMenorIgualEspecif As String = OrDefault(.Cells("MenorIgualEspecif").Value, 0)
                    Dim WInformaEspecif As String = OrDefault(.Cells("InformaEspecif").Value, 0)
                    Dim WObservaciones As String = OrDefault(.Cells("Observaciones").Value, "")
                    Dim WFormulaEspecif As String = OrDefault(.Cells("FormulaEspecif").Value, "")
                    Dim WParametro As String = Trim(OrDefault(.Cells("Parametro").Value, ""))

                    Dim WFormulas(10, 2) As String

                    For i = 1 To 10
                        WFormulas(i, 1) = Trim(OrDefault(.Cells("Variable" & i).Value, ""))
                        WFormulas(i, 2) = Trim(OrDefault(.Cells("VariableValor" & i).Value, "")).Replace(",", ".")
                    Next

                    WResultado = _GenerarImpreResultado(WTipoEspecif, WDesdeEspecif, WHastaEspecif, WUnidadEspecif, WValor)
                    'Dim WImpreResultado = _GenerarImpreParametro(WTipoEspecif, WDesdeEspecif, WHastaEspecif, WUnidadEspecif, WMenorIgualEspecif)

                    WRenglon += 1

                    'Dim WClave = "1" & WCodigo & txtPartida.Text.PadLeft(6, "0") & txtEtapa.Text.PadLeft(2, "0") & WRenglon.ToString.PadLeft(2, "0")
                    Dim WClave = "1" & WCodigo & txtPartida.Ceros(6) & IIf(Val(txtEtapa.Text) = 99, "", txtEtapa.Ceros(2)) & WRenglon.Ceros(2)
                    Dim ZSql = ""

                    ZSql = ZSql & "INSERT INTO " & WTabla & " ("
                    ZSql = ZSql & "Clave ,"
                    If Val(txtEtapa.Text) <> 99 Then ZSql = ZSql & "Paso ,"
                    ZSql = ZSql & "Tipo ,"
                    ZSql = ZSql & "Partida ,"
                    ZSql = ZSql & "Renglon ,"
                    ZSql = ZSql & "Producto ,"
                    ZSql = ZSql & "Fecha ,"
                    ZSql = ZSql & "FechaOrd ,"
                    ZSql = ZSql & "Codigo ,"
                    ZSql = ZSql & "Valor ,"
                    ZSql = ZSql & "Resultado ,"
                    ZSql = ZSql & "Observaciones ,"
                    ZSql = ZSql & "ValorReal ,"
                    ZSql = ZSql & "TipoEspecif ,"
                    ZSql = ZSql & "InformaEspecif ,"
                    ZSql = ZSql & "MenorIgualEspecif ,"
                    ZSql = ZSql & "UnidadEspecif ,"
                    ZSql = ZSql & "DesdeEspecif ,"
                    ZSql = ZSql & "HastaEspecif ,"
                    ZSql = ZSql & "Farmacopea ,"
                    ZSql = ZSql & "PorDesvio ,"
                    ZSql = ZSql & "MotivoDesvio ,"
                    ZSql = ZSql & "NroDesvio ,"
                    ZSql = ZSql & "Libros ,"
                    ZSql = ZSql & "Archiva ,"
                    ZSql = ZSql & "NroOOS ,"
                    ZSql = ZSql & "Paginas ,"
                    ZSql = ZSql & "Estado ,"
                    ZSql = ZSql & "Confecciono ,"
                    ZSql = ZSql & "Impre1 ,"
                    ZSql = ZSql & "Impre2 ,"
                    ZSql = ZSql & "FormulaEspecif ,"

                    For i = 1 To 10
                        ZSql = ZSql & "Variable" & i & " ,"
                        ZSql = ZSql & "VariableValor" & i & " ,"
                    Next

                    ZSql = ZSql & "Liberada )"
                    ZSql = ZSql & "Values ("
                    ZSql = ZSql & "'" & WClave & "',"
                    If Val(txtEtapa.Text) <> 99 Then ZSql = ZSql & "'" & Trim(txtEtapa.Text) & "',"
                    ZSql = ZSql & "'" & "1" & "',"
                    ZSql = ZSql & "'" & WPartida.left(6) & "',"
                    ZSql = ZSql & "'" & WRenglon.left(2) & "',"
                    ZSql = ZSql & "'" & WCodigo.left(12) & "',"
                    ZSql = ZSql & "'" & WFecha & "',"
                    ZSql = ZSql & "'" & WFechaOrd & "',"
                    ZSql = ZSql & "'" & WEns & "',"
                    ZSql = ZSql & "'" & WEspecificacion.left(50) & "',"
                    ZSql = ZSql & "'" & WResultado.left(50) & "',"
                    ZSql = ZSql & "'" & WObservaciones.left(100) & "',"
                    ZSql = ZSql & "'" & WValor.left(10) & "',"
                    ZSql = ZSql & "'" & WTipoEspecif.left(1) & "',"
                    ZSql = ZSql & "'" & WInformaEspecif.left(1) & "',"
                    ZSql = ZSql & "'" & WMenorIgualEspecif.left(1) & "',"
                    ZSql = ZSql & "'" & WUnidadEspecif.left(20) & "',"
                    ZSql = ZSql & "'" & WDesdeEspecif.left(10) & "',"
                    ZSql = ZSql & "'" & WHastaEspecif.left(10) & "',"
                    ZSql = ZSql & "'" & WFarmacopea.left(10) & "',"
                    ZSql = ZSql & "'" & WPorDesvio.left(1) & "',"
                    ZSql = ZSql & "'" & WMotivoDesvio.left(100) & "',"
                    ZSql = ZSql & "'" & WNroDesvio.left(10) & "',"
                    ZSql = ZSql & "'" & WLibros.left(20) & "',"
                    ZSql = ZSql & "'" & WArchivo.left(30) & "',"
                    ZSql = ZSql & "'" & WNroOOS.left(10) & "',"
                    ZSql = ZSql & "'" & WPaginas.left(20) & "',"
                    ZSql = ZSql & "'" & "1" & "',"
                    ZSql = ZSql & "'" & WConfecciono.left(50) & "',"
                    ZSql = ZSql & "'" & WParametro.left(100) & "',"
                    ZSql = ZSql & "'" & WTipoProceso.left(100) & "',"
                    ZSql = ZSql & "'" & WFormulaEspecif & "',"

                    For i = 1 To 10
                        ZSql = ZSql & "'" & WFormulas(i, 1) & "',"
                        ZSql = ZSql & "'" & WFormulas(i, 2) & "',"
                    Next

                    ZSql = ZSql & "'" & WLiberada & "')"

                    WSqls.Add(ZSql)

                End With

            Next

            With WNotas
                WSqls.Add("UPDATE " & WTabla & " SET " &
                          "WDate = '" & Date.Now.ToString("dd-MM-yyyy") & "'," &
                          "Operador = '" & Operador.Codigo & "'," &
                          "Nota1 = '" & .Item(0) & "'," &
                          "Nota2 = '" & .Item(1) & "'," &
                          "Nota3 = '" & .Item(2) & "'," &
                          "Nota4 = '" & .Item(3) & "'," &
                          "Nota5 = '" & .Item(4) & "'," &
                          "Nota6 = '" & .Item(5) & "'," &
                          "Nota7 = '" & .Item(6) & "'," &
                          "Nota8 = '" & .Item(7) & "'," &
                          "Nota9 = '" & .Item(8) & "'," &
                          "Envases = '" & txtEnvases.Text.Trim & "'," &
                          "Componente = '" & txtComponente.Text.Trim & "'," &
                          "lotePartida = '" & txtLotePartida.Text.Trim & "'," &
                          "CantiEti = '" & txtCantidadEtiquetas.Text.Trim & "'" &
                          " WHERE Partida = '" & WPartida & "' And Producto = '" & WCodigo & "' " & IIf(Val(txtEtapa.Text) = 99, "", "And Paso = '" & WEtapa & "'")
                          )
            End With

            ExecuteNonQueries(WSqls.ToArray)

            'MsgBox("Actualizado")

            If Val(txtEtapa.Text) <> 99 Then

                _GuardarNuevaVersionPDFConEnsayosIntermedios()

                _EnviarAvisoEnsayosIntermedios(WEsUnaActualizacion)

            End If

            btnLimpiar.PerformClick()

            txtPartida.Focus()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
            '        txtPartida.Focus()
        End Try

    End Sub

    Private Sub _EnviarAvisoEnsayosIntermedios(Optional ByVal EsActualizacion As Boolean = False)

        Directory.CreateDirectory(RUTA_TEMP)

        Dim frm As New ConsultasVarias.VistaPrevia

        With frm
            .Reporte = New ValoresEnsayosIntermediosPTFarma
            .Formula = "{PrueterFarmaIntermedio.Producto} = '" & txtCodigo.Text & "' And {PrueterFarmaIntermedio.Paso} = " & txtEtapa.Text & " And {PrueterFarmaIntermedio.Partida} = " & txtPartida.Text & " And {PrueterFarmaIntermedio.Producto} = {Terminado.Codigo}"

            Dim nombreArchivo = String.Format("{0} {1} - Etapa {2}.pdf", txtCodigo.Text, txtPartida.Ceros(6), txtEtapa.Ceros(2))

            File.Delete(RUTA_TEMP & nombreArchivo)

            .Exportar(nombreArchivo, CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, RUTA_TEMP)

            Dim WTitulo, WCuerpo As String

            If EsActualizacion Then
                WTitulo = "Actualización de Ensayos Intermedios Ingresados - " & txtCodigo.Text & " - Pda " & txtPartida.Ceros(6) & " - Etapa " & txtEtapa.Ceros(2) & ""
                WCuerpo = "Se le informa sobre una actualización en el ingreso de Ensayos Intermedios para la Etapa <b>" & txtEtapa.Ceros(2) & "</b> correspondiente al Producto <b>" & txtCodigo.Text & "</b> Pda: <b>" & txtPartida.Ceros(6) & "</b> "
            Else
                WTitulo = "Ingreso de Ensayos Intermedios - " & txtCodigo.Text & " - Pda " & txtPartida.Ceros(6) & " - Etapa " & txtEtapa.Ceros(2) & ""
                WCuerpo = "Se ha registrado un nuevo ingreso de Ensayos Intermedios para la Etapa " & txtEtapa.Ceros(2) & " correspondiente al Producto " & txtCodigo.Text & " Pda: " & txtPartida.Ceros(6) & " "
            End If

            If File.Exists(RUTA_TEMP & nombreArchivo) Then
                .EnviarPorEmail(RUTA_TEMP & nombreArchivo, True, WTitulo, WCuerpo, DESTINATARIOS_AVISO_ENSAYOS_INTERMEDIOS)
            Else
                MsgBox("Ha ocurrido un inconveniente al querer generar el PDF con los ensayos intermedios.", MsgBoxStyle.Exclamation)
            End If

        End With
    End Sub

    Private Sub _GuardarNuevaVersionPDFConEnsayosIntermedios()

        Dim frm As ConsultasVarias.VistaPrevia = New ConsultasVarias.VistaPrevia

        With frm
            .Reporte = New ValoresEnsayosIntermediosPTFarma
            .Formula = "{PrueterFarmaIntermedio.Partida} = " & txtPartida.Text & " AND {Prueterfarmaintermedio.Paso} = " & txtEtapa.Text & " AND {Prueterfarmaintermedio.Producto} = '" & txtCodigo.Text & "' AND {Prueterfarmaintermedio.Producto} = {Terminado.Codigo}"
        End With

        frm.Exportar(String.Format("{0}-{1}-{2}", txtCodigo.Text, txtPartida.Ceros(6), Date.Now.ToString("yyyyMMdd-HHmm")), CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, String.Format("{0}", _CarpetaEtapaIntermedia))

    End Sub

    Private Sub _RecalcularFormulas()

        Dim WTipo As String = ""

        For Each row As Datagridviewrow In dgvEnsayos.Rows
            With row
                WTipo = OrDefault(.Cells("TipoEspecif").Value, "")

                If Val(WTipo) = 2 Then

                    Dim WFormula As String = OrDefault(.Cells("FormulaEspecif").Value, "")

                    Dim parser As New ExpressionParser()

                    For i = 1 To 10

                        Dim WValor As String = OrDefault(.Cells("VariableValor" & i).Value, "0").Replace(",", ".")

                        If WValor.StartsWith(".") Then WValor = "0" & WValor

                        parser.Values.Add("v" & i, WValor)

                    Next

                    Dim regex As New Regex("R[1-9]{1,2}")

                    For Each m As Match In regex.Matches(WFormula)

                        Dim renglon As Integer = Val(m.Value.ToString.Replace("R", ""))

                        If renglon <= dgvEnsayos.Rows.Count Then
                            parser.Values.Add(LCase(m.Value), OrDefault(dgvEnsayos.Rows(renglon - 1).Cells("Valor").Value, "0").ToString.Replace(",", ""))
                        End If

                    Next

                    .Cells("Valor").Value = formatonumerico(OrDefault(parser.Parse(WFormula), "").ToString.Replace(",", "."), OrDefault(.Cells("Decimales").Value, 2))

                    If OrDefault(.Cells("Decimales").Value, 2) = 0 Then
                        .Cells("Valor").Value = CInt(.Cells("Valor").Value.ToString.Replace(".", ","))
                    End If

                    If .Cells("Valor").Value = "NaN" Then
                        dgvEnsayos.CurrentCell = row.Cells("Valor")
                        dgvEnsayos.Focus()
                        Throw New FormatoNoNumericoException("Hay un error en los valores de las variables proporcionadas para la Fórmula. " & vbCrLf & vbCrLf & "Por favor, verifique y vuelva a intentar.")
                    End If

                End If

            End With
        Next

    End Sub

    Private Function _ValidarValoresIngresados() As Boolean
        '
        ' Validamos los valores ingresados.
        '
        ' Se validan los datos para aquellos Prductos para los que se han definido
        ' las especificaciones por Sistema. En los casos de aquellos productos que no,
        ' se deja sin validación como hasta el dia de hoy.
        '
        For Each row As DataGridViewRow In dgvEnsayos.Rows
            If Not _ValidarDato(row) Then Return False
        Next

        Return True
    End Function

    Private Function _ValidarDato(ByVal row As DataGridViewRow) As Boolean

        With row

            Dim WTipo As String = OrDefault(.Cells("TipoEspecif").Value, "")
            Dim WMenorIgual As String = OrDefault(.Cells("MenorIgualEspecif").Value, "")
            Dim WMin As Double = Val(formatonumerico(OrDefault(.Cells("DesdeEspecif").Value, ""), 10))
            Dim WMax As Double = Val(formatonumerico(OrDefault(.Cells("HastaEspecif").Value, ""), 10))
            Dim WValor As String = OrDefault(.Cells("Valor").Value, "")
            Dim WEns As String = OrDefault(.Cells("Ensayo").Value, "")

            If WEns.Trim <> "" And WValor.Trim <> "" And WTipo.Trim <> "" Then

                If Val(WTipo) = 1 Or Val(WTipo) = 2 Then

                    If WValor.ToUpper <> "P" Then

                        If Not Regex.IsMatch(WValor, "(^[\-]?\d+[\.\,]?(\d+)?$)") Then
                            dgvEnsayos.CurrentCell = row.Cells("Valor")
                            dgvEnsayos.Focus()
                            Throw New FormatoNoNumericoException("Hay un error de Formato en el valor proporcionado. " & vbCrLf & vbCrLf & "Se esperaba un valor numérico.")
                        End If

                        Dim WValorNum As Double = Val(formatonumerico(WValor, 10))

                        If Val(WMenorIgual) = 0 And (WValorNum < WMin Or WValorNum > WMax) Then Return False

                        If Val(WMenorIgual) = 1 And (WValorNum < WMin Or WValorNum >= WMax) Then Return False

                    End If

                Else

                    If Not {"S", "P", "N"}.Contains(WValor.ToUpper) Then Return False

                End If

            End If

        End With
        Return True
    End Function

    Private Function _GenerarImpreResultado(ByVal wTipoEspecif As Object, ByVal wDesdeEspecif As Object, ByVal wHastaEspecif As Object, ByVal wUnidadEspecif As Object, ByVal wValor As Object) As Object

        If wValor = "" Then Return ""

        If UCase(Trim(wValor)) = "P" Then Return "PENDIENTE"

        If Val(wTipoEspecif) = 1 Or Val(wTipoEspecif) = 2 Then

            If Val(wDesdeEspecif) = 0 And Val(wHastaEspecif) = 9999 Then Return "CUMPLE"

            Dim WValido = True
            Double.TryParse(wValor.ToString, WValido)

            If Not WValido Then Return ""

            Return String.Format("{0} {1}", wValor, wUnidadEspecif)

        Else

            Select Case UCase(wValor)
                Case "S"
                    Return "CUMPLE"
                Case "N"
                    Return "NO CUMPLE"
                Case Else
                    Return ""
            End Select

        End If

    End Function

    Private Sub _ValidarDatos()
        '
        ' Verificamos Datos Obligatorios.
        '
        If Val(txtPartida.Text) = 0 Then Throw New Exception("No se ha cargado una partida válida.")
        If txtCodigo.Text.Replace(" ", "").Length < 12 Then Throw New Exception("No se ha cargado un Código de Producto Terminado válido.")
        If Val(txtEtapa.Text) = 0 Then Throw New Exception("No se ha cargado una Etapa válida.")
        'If txtLibros.Text.Trim = "" Then Throw New Exception("No se ha informado la información de Libros correspondiente.")
        'If txtPaginas.Text.Trim = "" Then Throw New Exception("No se ha informado la información de Páginas correspondiente.")
        If txtConfecciono.Text.Trim = "" Then Throw New Exception("No se ha informado quién Confecciona el ingreso de Ensayos.")

        '
        ' Verificamos Datos Ingresados.
        '
        Dim WTerminado As DataRow = GetSingle("SELECT Codigo FROM Terminado WHERE Codigo = '" & txtCodigo.Text & "'")
        If WTerminado Is Nothing Then Throw New Exception("El Código de Producto Terminado es inválido.")

        Dim WHoja As DataRow = GetSingle("SELECT Producto FROM Hoja WHERE Hoja = '" & txtPartida.Text & "' And Renglon in ('1', '01')")

        If WHoja Is Nothing Then Throw New Exception("La Hoja indicada es Inexistente.")

        If WHoja.Item("Producto").ToString.ToUpper <> txtCodigo.Text.ToUpper Then Throw New Exception("El Código de Producto Terminado indicado no se corresponde con el indicado en la Hoja de Producción.")

        '
        ' Verificamos si se ha grabado anteriormente por Desvio, en este caso se considera Bloqueado e imposible de ser actualizado por este medio.
        '
        Dim WDesvio As DataRow = GetSingle("SELECT TOP 1 PorDesvio, NroDesvio FROM PrueterFarmaIntermedio WHERE Producto = '" & txtCodigo.Text & "' AND Partida = '" & txtPartida.Text & "' AND Paso = '" & txtEtapa.Text & "' And Renglon = 1")

        If WDesvio IsNot Nothing Then
            With WDesvio
                Dim WPorDesvio As Integer = OrDefault(.Item("PorDesvio"), 0)
                Dim WNroDesvio As String = OrDefault(.Item("NroDesvio"), "")

                If WPorDesvio = 1 And WNroDesvio.Trim <> "" Then Throw New Exception("Los resultados informados para esta Etapa, se encuentran Bloqueados debido a que fueron ingresados por Desvío.")

            End With
        End If

        '
        ' Verificamos en caso de que ya se encuentre grabado, si tenia algun dato como Pendiente. En caso de que no, se pide la clave de seguridad para poder actualizar.
        '
        Dim WDatos As DataTable = Nothing

        If Val(txtEtapa.Text) = 99 Then
            WDatos = GetAll("SELECT ValorReal FROM PrueterFarma WHERE Producto = '" & txtCodigo.Text & "' AND Partida = '" & txtPartida.Text & "' ORDER BY Clave")
        Else
            WDatos = GetAll("SELECT ValorReal FROM PrueterFarmaIntermedio WHERE Producto = '" & txtCodigo.Text & "' AND Partida = '" & txtPartida.Text & "' AND Paso = '" & txtEtapa.Text & "' ORDER BY Clave")
        End If

        If WDatos.Rows.Count > 0 Then
            Dim WBloqueado = True

            For Each row As DataRow In WDatos.Rows
                Dim WValor As String = OrDefault(row.Item("ValorReal"), "")

                If WValor.Trim.ToUpper = "P" Then WBloqueado = False

            Next

            WActualizacionBloqueada = WBloqueado And Not WAutorizaActualizacionBloqueado

        End If

    End Sub

    Public Sub _ProcesarIngresoClaveSeguridad(ByVal WClave As Object) Implements IIngresoClaveSeguridad._ProcesarIngresoClaveSeguridad


        Select Case WMotivoClaveSeguridad
            Case TiposSolicitudClaveSeguridad.IngresoEnsayoIntermedioPorDesvio
                If WClave.ToString.ToUpper = "SEGURO" Then
                    WEsPorDesvio = True
                    btnGrabar.PerformClick()
                    Exit Sub
                End If

                MsgBox("Clave Incorrecta")
                Dim frm As New IngresoClaveSeguridad
                frm.ShowDialog(Me)

            Case TiposSolicitudClaveSeguridad.ActualizarEnsayoBloqueado

                Dim WDatos As DataRow = GetSingle("SELECT GrabaV, FechaGrabaV FROM Operador WHERE Clave = '" & UCase(WClave) & "'")

                If WDatos IsNot Nothing Then
                    Dim WGrabaV As String = OrDefault(WDatos.Item("GrabaV"), "")
                    If WGrabaV.ToUpper = "S" Then
                        WAutorizaActualizacionBloqueado = True
                        btnGrabar.PerformClick()
                        Exit Sub
                    End If
                End If

                MsgBox("Clave Incorrecta")
                Dim frm As New IngresoClaveSeguridad
                frm.ShowDialog(Me)

            Case Else
                MsgBox("Clave Incorrecta")
                Dim frm As New IngresoClaveSeguridad
                frm.ShowDialog(Me)
        End Select

    End Sub

    Public Sub _ProcesarIngresoMotivoDesvio(ByVal _Motivo As Object) Implements IIngresoMotivoDesvio._ProcesarIngresoMotivoDesvio
        WMotivoDesvio = Trim(_Motivo)
    End Sub

    'Private Sub btnRegistroProd_Click(ByVal sender As Object, ByVal e As EventArgs)

    '    Try
    '        Dim WPrueterfarma As DataTable = GetAll("SELECT * FROM PrueterFarmaIntermedio WHERE Partida = '" & txtPartida.Text & "' And Producto = '" & txtCodigo.Text & "' And Paso = '" & txtEtapa.Text & "' Order By Clave")

    '        If WPrueterfarma.Rows.Count = 0 Then
    '            txtPartida.Focus()
    '            Exit Sub
    '        End If

    '        Dim WSqls As New List(Of String)

    '        Dim WPartida As String = txtPartida.Text
    '        Dim WCodigo As String = txtCodigo.Text
    '        Dim WEtapa As String = txtEtapa.Text

    '        btnLimpiar.PerformClick()

    '        txtPartida.Text = WPartida
    '        txtPartida_KeyDown(Nothing, New KeyEventArgs(Keys.Enter))

    '        txtEtapa.Text = WEtapa
    '        txtEtapa_KeyDown(Nothing, New KeyEventArgs(Keys.Enter))

    '        _ActualizarTablaEnsayos()

    '        '
    '        ' Obtenemos el Producto Original en caso de que se haya ingresado como RE/NK.
    '        '
    '        If txtCodigo.Text.ToUpper.StartsWith("RE") Or txtCodigo.Text.ToUpper.StartsWith("NK") Then
    '            Dim _Hoja As DataRow = GetSingle("SELECT ISNULL(TipoOri, '') TipoOri FROM Hoja WHERE Hoja = '" & WPartida & "' And Renglon IN ('1', '01')")

    '            If Not IsNothing(_Hoja) Then

    '                If {"PT", "RE"}.Contains(_Hoja.Item("TipoOri")) Then
    '                    WCodigo = WCodigo.Replace("RE", _Hoja.Item("TipoOri"))
    '                    WCodigo = WCodigo.Replace("NK", _Hoja.Item("TipoOri"))
    '                End If

    '            End If

    '        End If

    '        Dim WConfecciono As String = txtConfecciono.Text.left(50)

    '        WSqls.Add("UPDATE CargaV SET ObservaIV = '" & WConfecciono & "' WHERE Terminado = '" & WCodigo & "' And Paso = '" & txtEtapa.Text & "'")

    '        For Each row As DataRow In WPrueterfarma.Rows
    '            With row
    '                '
    '                ' Actualizamos los resultados y la confeccion en CargaV.
    '                '
    '                Dim WResultado As String = OrDefault(row.Item("Resultado"), "")

    '                WResultado = WResultado.left(50)

    '                WSqls.Add("UPDATE CargaV SET Resultado = '" & WResultado & "' WHERE Terminado = '" & WCodigo & "' And Paso = '" & txtEtapa.Text & "'")

    '                Dim WTipo = OrDefault(row.Item("TipoEspecif"), "")
    '                Dim WMenorIgual = OrDefault(row.Item("MenorIgualEspecif"), "")
    '                Dim WDesde = OrDefault(row.Item("DesdeEspecif"), "")
    '                Dim WHasta = OrDefault(row.Item("HastaEspecif"), "")
    '                Dim WUnidad = OrDefault(row.Item("UnidadEspecif"), "")
    '                Dim WClave = OrDefault(row.Item("Clave"), "")
    '                Dim WValor = OrDefault(row.Item("Valor"), "")

    '                Dim WImpreParametro As String = _GenerarImpreParametro(WTipo, WDesde, WHasta, WUnidad, WMenorIgual)

    '                WSqls.Add("UPDATE PrueterFarmaIntermedio SET Impre1 = '" & WImpreParametro & "', Impre2 = '" & WValor & "' WHERE Clave = '" & WClave & "'")

    '            End With
    '        Next

    '        Dim WHoja As DataRow = GetSingle("SELECT Teorico, Cantidad FROM Hoja WHERE Hoja = '" & txtPartida.Text & "'")
    '        Dim WTeorico As Double = 0

    '        If WHoja IsNot Nothing Then
    '            WTeorico = OrDefault(WHoja.Item("Teorico"), 0)
    '        End If

    '        WSqls.Add("UPDATE CargaV SET ImpreTerminado = '" & txtCodigo.Text & "', Partida = '" & txtPartida.Text & "', FechaIng = '" & txtFecha.Text & "', CantidadPartida = '" & formatonumerico(WTeorico) & "', ImprePaso = '" & txtEtapa.Text & "' WHERE Terminado = '" & txtCodigo.Text & "'")

    '        ExecuteNonQueries(WSqls.ToArray)

    '        Dim frm As New VistaPrevia

    '        With frm
    '            .Reporte = New ResultadosIntermediosPT
    '            .Formula = "{PrueterFarma.Producto} = {Terminado.Codigo} And {PrueterFarma.Paso} = " & txtEtapa.Text & " And {PrueterFarma.Codigo} = {Ensayos.Codigo} And {PrueterFarma.Partida}  = " & txtPartida.Text & ""
    '            .Mostrar()
    '        End With

    '    Catch ex As Exception
    '        MsgBox(ex.Message, MsgBoxStyle.Exclamation)
    '    End Try

    'End Sub

    'Private Sub _ActualizarTablaEnsayos()

    '    '
    '    ' Obtenemos los valores de los ensayos de las bases correspondientes, segun la empresa que se representa.
    '    '
    '    Dim WBaseEnsayos = "Surfactan_III"

    '    If Base.ToUpper.StartsWith("PELLITAL") Or Base.ToUpper.StartsWith("PELITALL") Then WBaseEnsayos = "Pelitall_II"

    '    Dim WEnsayosBase As DataTable = GetAll("SELECT Codigo, Descripcion, DescripcionII, Unidad FROM Ensayos Order By Codigo", WBaseEnsayos)

    '    Dim WSqls As New List(Of String)

    '    For Each row As DataRow In WEnsayosBase.Rows
    '        With row
    '            Dim WCodigo = OrDefault(.Item("Codigo"), "")
    '            Dim WDescripcion = OrDefault(.Item("Descripcion"), "")
    '            Dim WDescripcionII = OrDefault(.Item("DescripcionII"), "")
    '            Dim WUnidad = OrDefault(.Item("Unidad"), "")
    '            Dim ZSql = ""

    '            Dim WEnsayo As DataRow = GetSingle("SELECT Codigo FROM Ensayos WHERE Codigo = '" & WCodigo & "'")

    '            If WEnsayo Is Nothing Then
    '                ZSql = String.Format("INSERT INTO Ensayos (Codigo, Descripcion, DescripcionII, Unidad) VALUES ('{0}', '{1}', '{2}', '{3}')", WCodigo, WDescripcion, WDescripcionII, WUnidad)
    '            Else
    '                ZSql = String.Format("UPDATE Ensayos SET Descripcion = '{1}', DescripcionII = '{2}', Unidad = '{3}' WHERE Codigo = '{0}'", WCodigo, WDescripcion, WDescripcionII, WUnidad)
    '            End If

    '            WSqls.Add(ZSql)

    '        End With
    '    Next

    '    ExecuteNonQueries(WSqls.ToArray)

    'End Sub

    Private Sub btnActualizarEspecif_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnActualizarEspecif.Click

        Dim WPrueterFarmaI As DataTable = Nothing

        If Val(txtEtapa.Text) = 99 Then
            WPrueterFarmaI = GetAll("SELECT * FROM PrueTerFarma WHERE Partida = '" & txtPartida.Text & "' ORDER By Clave")
        Else
            WPrueterFarmaI = GetAll("SELECT * FROM PrueTerFarmaIntermedio WHERE Partida = '" & txtPartida.Text & "' ORDER By Clave")
        End If

        Dim WRenglon As UShort = 0

        Dim WEns, WDescripcion, WEspecificacion, WFarmacopea, WTipoEspecif, WDesdeEspecif, WHastaEspecif, WUnidadEspecif, WMenorIgualEspecif, WInformaEspecif, WImpreParametro, WFormulaEspecif As String

        For Each row As DataRow In WPrueterFarmaI.Rows
            With row
                WEns = OrDefault(.Item("Ensayo"), 0)
                WEspecificacion = OrDefault(.Item("Valor"), "")
                WFarmacopea = OrDefault(.Item("Farmacopea"), "")
                WTipoEspecif = OrDefault(.Item("TipoEspecif"), "")
                WDesdeEspecif = OrDefault(.Item("DesdeEspecif"), "")
                WHastaEspecif = OrDefault(.Item("HastaEspecif"), "")
                WUnidadEspecif = OrDefault(.Item("UnidadEspecif"), "")
                WMenorIgualEspecif = OrDefault(.Item("MenorIgualEspecif"), "")
                WInformaEspecif = OrDefault(.Item("InformaEspecif"), "")
                WFormulaEspecif = OrDefault(.Item("FormulaEspecif"), "")
                Dim WValor = Trim(OrDefault(.Item("ValorReal"), ""))
                WImpreParametro = _GenerarImpreParametro(WTipoEspecif, WDesdeEspecif, WHastaEspecif, WUnidadEspecif, WMenorIgualEspecif)

                Dim WFormulas(10, 2) As String

                For i = 1 To 10
                    WFormulas(i, 1) = Trim(OrDefault(.Item("Variable" & i), ""))
                    WFormulas(i, 2) = Trim(OrDefault(.Item("VariableValor" & i), "0"))
                Next

                If Val(WTipoEspecif) = 0 And WImpreParametro <> "" Then WImpreParametro &= " (c)"

                WDescripcion = "" 'OrDefault(.Item("Ensayo"), 0)

                If WRenglon > dgvEnsayos.Rows.Count - 1 Then WRenglon = dgvEnsayos.Rows.Add

                With dgvEnsayos.Rows(WRenglon)
                    .Cells("Ensayo").Value = WEns
                    .Cells("Especificacion").Value = Trim(WEspecificacion)
                    .Cells("Descripcion").Value = Trim(WDescripcion)
                    .Cells("Farmacopea").Value = Trim(WFarmacopea)
                    .Cells("TipoEspecif").Value = WTipoEspecif
                    .Cells("DesdeEspecif").Value = WDesdeEspecif
                    .Cells("HastaEspecif").Value = WHastaEspecif
                    .Cells("UnidadEspecif").Value = WUnidadEspecif
                    .Cells("MenorIgualEspecif").Value = WMenorIgualEspecif
                    .Cells("InformaEspecif").Value = WInformaEspecif
                    .Cells("Parametro").Value = Trim(WImpreParametro)
                    .Cells("FormulaEspecif").Value = Trim(WFormulaEspecif)

                    For i = 1 To 10
                        .Cells("Variable" & i).Value = Trim(WFormulas(i, 1))
                        .Cells("VariableValor" & i).Value = WFormulas(i, 2)
                    Next

                    .Cells("Decimales").Value = "2"

                    If Val(WTipoEspecif) = 2 Then

                        .Cells("Decimales").Value = "2"

                        .Cells("Decimales").Value = IIf(WValor.Trim = "", "2", "0")

                        Dim aux As Integer = WValor.ToString.IndexOfAny({",", "."})

                        If aux > 0 Then
                            Dim t As String = _Right(WValor, WValor.Replace(".", "").Replace(",", "").Length - aux)
                            .Cells("Decimales").Value = t.Length
                        End If

                    End If


                End With

                WRenglon += 1

            End With

        Next

        WRenglon = 0

        Dim WCargaV As DataTable = GetAll("SELECT * FROM CargaV WHERE Terminado = '" & txtCodigo.Text & "' And Paso = '" & txtEtapa.Text & "' Order by Clave")

        For Each row As DataRow In WCargaV.Rows
            With row
                WEns = OrDefault(.Item("Ensayo"), 0)
                WEspecificacion = OrDefault(.Item("Valor"), "")
                WFarmacopea = OrDefault(.Item("Farmacopea"), "")
                WTipoEspecif = OrDefault(.Item("TipoEspecif"), "")
                WDesdeEspecif = OrDefault(.Item("DesdeEspecif"), "")
                WHastaEspecif = OrDefault(.Item("HastaEspecif"), "")
                WUnidadEspecif = OrDefault(.Item("UnidadEspecif"), "")
                WMenorIgualEspecif = OrDefault(.Item("MenorIgualEspecif"), "")
                WInformaEspecif = OrDefault(.Item("InformaEspecif"), "")
                WFormulaEspecif = OrDefault(.Item("FormulaEspecif"), "")
                WImpreParametro = _GenerarImpreParametro(WTipoEspecif, WDesdeEspecif, WHastaEspecif, WUnidadEspecif, WMenorIgualEspecif)

                Dim WFormulas(10) As String

                For i = 1 To 10
                    WFormulas(i) = Trim(OrDefault(.Item("Variable" & i), ""))
                Next

                If Val(WTipoEspecif) = 0 And WImpreParametro <> "" Then WImpreParametro &= " (c)"

                WDescripcion = "" 'OrDefault(.Item("Ensayo"), 0)

                If WRenglon > dgvEnsayos.Rows.Count - 1 Then WRenglon = dgvEnsayos.Rows.Add

                With dgvEnsayos.Rows(WRenglon)
                    .Cells("Ensayo").Value = WEns
                    .Cells("Especificacion").Value = Trim(WEspecificacion)
                    .Cells("EspecificacionIngles").Value = ""
                    .Cells("Descripcion").Value = Trim(WDescripcion)
                    .Cells("Farmacopea").Value = Trim(WFarmacopea)
                    .Cells("TipoEspecif").Value = WTipoEspecif
                    .Cells("DesdeEspecif").Value = WDesdeEspecif
                    .Cells("HastaEspecif").Value = WHastaEspecif
                    .Cells("UnidadEspecif").Value = WUnidadEspecif
                    .Cells("MenorIgualEspecif").Value = WMenorIgualEspecif
                    .Cells("InformaEspecif").Value = WInformaEspecif
                    .Cells("FormulaEspecif").Value = WFormulaEspecif
                    .Cells("Parametro").Value = Trim(WImpreParametro)

                    For i = 1 To 10
                        .Cells("Variable" & i).Value = Trim(WFormulas(i))
                        .Cells("VariableValor" & i).Value = "0"
                    Next

                End With

                WRenglon += 1

            End With

        Next

        WRenglon = 0

        '
        ' Cargamos las especificaciones en Inglés.
        '
        Dim WCargaVIngles As DataTable = GetAll("SELECT Valor, UnidadEspecif FROM CargaVIngles WHERE Terminado = '" & txtCodigo.Text & "' And Paso = '" & txtEtapa.Text & "' Order By Clave")

        For Each row As DataRow In WCargaVIngles.Rows

            With row

                WUnidadEspecif = Trim(OrDefault(.Item("UnidadEspecif"), ""))
                WEspecificacion = Trim(OrDefault(.Item("Valor"), ""))

                If WRenglon > dgvEnsayos.Rows.Count - 1 Then WRenglon = dgvEnsayos.Rows.Add

                With dgvEnsayos.Rows(WRenglon)

                    If WUnidadEspecif = "" Then
                        .Cells("EspecificacionIngles").Value = WEspecificacion
                    Else
                        .Cells("EspecificacionIngles").Value = String.Format("{0} ({1})", WEspecificacion, WUnidadEspecif)
                    End If

                    .Cells("UnidadEspecif").Value = WUnidadEspecif
                End With

                WRenglon += 1

            End With

        Next

    End Sub

    Private Sub btnImprimirEnsayosIngresados_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimirEnsayosIngresados.Click, btnRevalida.Click, btnReimprimir.Click

        If Val(txtEtapa.Text) = 99 Then

            '
            ' Reprocesamos y Actualizamos las descripciones de los parámetros para que estén al dia con las posibles modificaciones.
            '
            Dim WPrueterFarmaI As DataTable = GetAll("SELECT * FROM PrueTerFarma WHERE Partida = '" & txtPartida.Text & "' ORDER By Clave")

            Dim WClave, WTipoEspecif, WDesdeEspecif, WHastaEspecif, WUnidadEspecif, WMenorIgualEspecif, WImpreParametro As String

            For Each row As DataRow In WPrueterFarmaI.Rows
                With row
                    WClave = OrDefault(.Item("Clave"), "")
                    WTipoEspecif = OrDefault(.Item("TipoEspecif"), "")
                    WDesdeEspecif = OrDefault(.Item("DesdeEspecif"), "")
                    WHastaEspecif = OrDefault(.Item("HastaEspecif"), "")
                    WUnidadEspecif = OrDefault(.Item("UnidadEspecif"), "")
                    WMenorIgualEspecif = OrDefault(.Item("MenorIgualEspecif"), "")
                    Dim WValor = Trim(OrDefault(.Item("Valor"), ""))
                    WImpreParametro = _GenerarImpreParametro(WTipoEspecif, WDesdeEspecif, WHastaEspecif, WUnidadEspecif, WMenorIgualEspecif)

                    If WClave.Trim <> "" Then
                        ExecuteNonQueries({"UPDATE Prueterfarma SET  Impre1 = '" & WImpreParametro & "', Impre2 = '" & WValor & "' WHERE Clave = '" & WClave & "'"})
                    End If

                End With
            Next

            '
            ' Calculamos las Cantidades.
            '
            Dim WCantidad, WTeorico As String
            WTeorico = "0"
            Dim WHoja As DataRow = GetSingle("SELECT Teorico FROM Hoja WHERE Hoja = '" & txtPartida.Text & "' And Renglon = 1")
            If WHoja IsNot Nothing Then
                WTeorico = OrDefault(WHoja.Item("Teorico"), "0")
            End If
            WCantidad = WTeorico & " Kg."

            ExecuteNonQueries(String.Format("UPDATE CargaV SET ImpreTerminado = '{0}', Partida = '{1}', FechaIng = '{2}', CantidadPartida = '{3}', ImprePaso = '99' WHERE Terminado = '{0}'", txtCodigo.Text, txtPartida.Text, txtFecha.Text, WTeorico))

            '
            ' Calculamos las Fechas de Elaboracion y Vencimiento.
            '
            Dim WPasaMono As Short = 0
            Dim WEsFazon As Boolean = False
            Dim WVencimiento, WImpre1, WImpre2, WImpre3, WImpre4 As String

            Dim WMono As DataRow = GetSingle("SELECT Tipo FROM CodigoMono WHERE Codigo = '" & txtCodigo.Text & "'", "SurfactanSa")
            If WMono IsNot Nothing Then WPasaMono = OrDefault(WMono.Item("Tipo"), 0)

            Dim WTer As String = Mid(txtCodigo.Text, 4, 5)
            WEsFazon = Val(WTer) > 2999 And Val(WTer) < 4000
            WImpre1 = "F.Reanálisis:"

            If WPasaMono > 0 And WEsFazon Then
                Dim WDatos As String() = Entidades.ProductoTerminado._CalculaMonoOtro(txtPartida.Text, "Surfactan_III")
                Dim WTipoVencimiento As Short = Val(WDatos(2))
                WImpre1 = IIf(WTipoVencimiento = 1, "F.Reanálisis:", "F.Vencimiento:")
            End If

            Dim WDatosII As String() = Entidades.ProductoTerminado.CalcularFechaElabVto(txtCodigo.Text, txtPartida.Text)

            WImpre2 = WDatosII(1)
            WImpre3 = ""
            WImpre4 = ""

            If Trim(WDatosII(0)) <> "" Then
                WImpre3 = "F.Elaboración:"
                WImpre4 = WDatosII(0)
            End If

            '_GenerarReporteResultadosCalidad(txtPartida.Text, 1, WImpre1, WImpre2, WImpre3, WImpre4)
            _GenerarReporteResultadosCalidad(txtPartida.Text, 2, WImpre1, WImpre2, WImpre3, WImpre4)

        Else

            With New VistaPrevia
                .Reporte = New ValoresEnsayosIntermediosPTFarma
                .Formula = "{PrueterFarmaIntermedio.Producto} = '" & txtCodigo.Text & "' And {PrueterFarmaIntermedio.Paso} = " & txtEtapa.Text & " And {PrueterFarmaIntermedio.Partida} = " & txtPartida.Text & " And {PrueterFarmaIntermedio.Producto} = {Terminado.Codigo}"
                .Mostrar()
            End With

        End If
       
    End Sub


    Private Sub _GenerarReporteResultadosCalidad(ByVal wPartida As Integer, ByVal wTipoSalida As Integer, ByVal wFechaVto As String, ByVal wImpreFechaVto As String, ByVal wFechaElabora As String, ByVal wImpreFechaElaboracion As String)

        With New VistaPrevia

            '.Reporte = New imprecalidadresultado
            If {0, 1}.Contains(wTipoSalida) Then
                .Reporte = New imprecalidadresultadoReduccionAl80
            Else
                .Reporte = New imprecalidadresultado
            End If

            .Reporte.SetParameterValue("FechaVto", wFechaVto)
            .Reporte.SetParameterValue("ImpreFechaVto", wImpreFechaVto)
            .Reporte.SetParameterValue("FechaElabora", wFechaElabora)
            .Reporte.SetParameterValue("ImpreFechaElaboracion", wImpreFechaElaboracion)
            .Formula = "{Prueterfarma.Partida} = " & wPartida & " And {Hoja.Hoja} = {Prueterfarma.Partida} And {Hoja.Renglon} = 1"

            Select Case wTipoSalida
                Case 0, 1, 4
                    .Imprimir()
                Case 2
                    .Mostrar()
                Case 3
                    .Exportar("Resultados de Calidad " & wPartida & " " & Date.Now.ToString("dd-MM-yyyy"), CrystalDecisions.Shared.ExportFormatType.WordForWindows)
            End Select

        End With

    End Sub

    Private Sub NumerosConComas(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtKilos.KeyPress
        If Not Char.IsNumber(e.KeyChar) And Not Char.IsControl(e.KeyChar) And Not (CChar(".")) = e.KeyChar Then
            e.Handled = True
        End If
    End Sub

    Private Sub btnNotasAnteriores_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNotasAnteriores.Click
        With New NotasAnterioresFarmaPT(txtPartida.Text, txtEtapa.Text)
            .ShowDialog(Me)
        End With
    End Sub

    Private Sub txtComponente_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtComponente.KeyDown

        If e.KeyData = Keys.Enter Then
            Dim longitud As Integer = txtComponente.Text.Replace(" ", "").Length

            If longitud = 10 Or longitud = 12 Then

                Dim WComp As DataRow = Nothing

                If longitud = 10 Then
                    WComp = GetSingle("SELECT Codigo FROM Articulo WHERE Codigo = '" & txtComponente.Text & "'")
                Else
                    WComp = GetSingle("SELECT Codigo FROM Terminado WHERE Codigo = '" & txtComponente.Text & "'")
                End If

                If WComp Is Nothing Then Exit Sub

                txtLotePartida.Focus()

                Exit Sub
            ElseIf longitud <> 0 Then
                Exit Sub
            End If

            txtCantidadEtiquetas.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtComponente.Text = ""
        End If

    End Sub

    Private Sub txtLotePartida_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtLotePartida.KeyDown

        If e.KeyData = Keys.Enter Then
            Dim longitud As Integer = txtComponente.Text.Replace(" ", "").Length

            If longitud = 10 Or longitud = 12 Then

                Dim WComp As DataRow = Nothing

                For Each emp As String In Conexion.Empresas
                    If longitud = 10 Then
                        WComp = GetSingle("SELECT Laudo FROM Laudo WHERE Laudo = '" & txtLotePartida.Text & "' And Renglon = '1'", emp)
                    Else
                        WComp = GetSingle("SELECT Hoja FROM Hoja WHERE Hoja = '" & txtLotePartida.Text & "'  And Renglon = '1'", emp)
                    End If

                    If WComp IsNot Nothing Then
                        txtCantidadEtiquetas.Focus()
                        Exit Sub
                    End If
                Next

                If WComp Is Nothing Then
                    MsgBox("El Lote/Partida no se corresponde con ninguno registrado en el sistema.", MsgBoxStyle.Exclamation)
                    Exit Sub
                End If
            ElseIf longitud <> 0 Then
                Exit Sub
            Else
                txtCantidadEtiquetas.Focus()
            End If

        ElseIf e.KeyData = Keys.Escape Then
            txtLotePartida.Text = ""
        End If

    End Sub

    Private Sub btnNotasCertAnalisis_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNotasCertAnalisis.Click
        With New NotasCertificadosAnalisisFarmaPT(txtPartida.Text)
            .ShowDialog(Me)
        End With
    End Sub
End Class

Friend Class FormatoNoNumericoException
    Inherits Exception

    Sub New(ByVal Msg As String)
        MyBase.New(Msg)
    End Sub

End Class