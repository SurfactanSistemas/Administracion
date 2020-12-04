Imports System.Configuration
Imports System.IO
Imports System.Text.RegularExpressions
Imports Util

Imports CrystalDecisions.Shared
Imports info.lundin.math
Imports Laboratorio.Clases
Imports Laboratorio.Entidades

Public Class IngresoEnsayosIntermediosPT : Implements INotasEnsayosProductosTerminados, IIngresoClaveSeguridad, IIngresoMotivoDesvio, IAyudaPruebasAnteriores, IEnsayosMonoComponente

    Private WNotas As New List(Of String)
    Private WEsPorDesvio As Boolean = False
    Private WMotivoDesvio As String = ""
    Private WMotivoClaveSeguridad As TiposSolicitudClaveSeguridad = TiposSolicitudClaveSeguridad.General
    Private WActualizacionBloqueada As Boolean = False
    Private WIDOperadorAnalista As String = ""
    Private WNoGrabaIniciales As Boolean = False
    Private WAutorizaActualizacionBloqueado As Boolean = False
    Private ReadOnly PATH_ENSAYOS_INTERMEDIOS As String = ConfigurationManager.AppSettings("PATH_ENSAYOS_INTERMEDIOS").ToString()
    Private ReadOnly DESTINATARIOS_AVISO_ENSAYOS_INTERMEDIOS As String = ConfigurationManager.AppSettings("DESTINATARIOS_AVISO_ENSAYOS_INTERMEDIOS").ToString()

    Private Const RUTA_TEMP As String = "C:/tempEnsayosIntermedios/"
    Private BaseEspecif As String = Base
    Private TablaPrueTer As String = "PrueTerFarma"
    Private TablaCargaV As String = "CargaV"
    Private TablaCargaVIng As String = "CargaVIngles"



    Dim PermisoGrabar As Boolean = False
    Sub New(Optional ByVal ID As String = "0")

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        If Val(ID) <> 0 Then
            Dim SQLCnslt As String = "SELECT Escritura FROM PermisosPerfiles WHERE ID = '" & ID & "' AND Sistema = 'LABORATORIO' AND Perfil = '" & Operador.Perfil & "' AND Planta = '" & Operador.Base & "' ORDER BY ID"
            Dim Row As DataRow = GetSingle(SQLCnslt, "SurfactanSa")
            If Row IsNot Nothing Then
                PermisoGrabar = Row.Item("Escritura")
            End If
        End If

    End Sub


    Private Sub btnCerrar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCerrar.Click
        Close()
    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnLimpiar.Click
        For Each c As Control In {txtFechaRevalida, txtArchivo, txtCodigo, txtSubEtapa, txtConfecciono, txtEnvases, txtComponente, txtLotePartida, txtCantidadEtiquetas, txtDesvio, txtEtapa, txtFecha, txtLibros, txtOOS, txtPaginas, txtPartida, lblTipoProceso, txtFechaVto, lblDescEtapa, txtEspecifActual, txtEspecifOrig, txtRevalida, txtKilos}
            c.Text = ""
        Next
        dgvEnsayos.Rows.Clear()

        WNotas = New List(Of String)
        For i = 0 To 8
            WNotas.Add("")
        Next

        WEsPorDesvio = False
        WMotivoDesvio = ""

        txtSubEtapa.Visible = False

        WMotivoClaveSeguridad = TiposSolicitudClaveSeguridad.General
        WActualizacionBloqueada = False
        WAutorizaActualizacionBloqueado = False
        btnRevalida.Enabled = False
        txtComponente.Enabled = False
        txtLotePartida.Enabled = False
        btnNotasCertAnalisis.Enabled = False
        btnReimprimir.Visible = False
        btnPoolEnsayos.Enabled = False
        gbDatosAdicionales.Visible = False

        txtEtapa.ReadOnly = Not EsFarma()

        txtPartida.Focus()

        verificarPermiso()

    End Sub

    Private Sub verificarPermiso()
        If PermisoGrabar = False Then
            btnGrabar.Enabled = False
            btnActualizarEspecif.Enabled = False

            txtLibros.ReadOnly = True
            txtPaginas.ReadOnly = True
            txtEnvases.ReadOnly = True
            txtComponente.ReadOnly = True
            txtLotePartida.ReadOnly = True
            txtOOS.ReadOnly = True
            txtDesvio.ReadOnly = True
            txtCantidadEtiquetas.ReadOnly = True
            txtArchivo.ReadOnly = True
            txtConfecciono.ReadOnly = True

        End If
    End Sub
    Private Sub IngresoEnsayosIntermediosPT_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        If Not EsFarma() Then
            TablaPrueTer = "PrueTerNoFarma"
            TablaCargaV = "CargaVNoFarma"
            TablaCargaVIng = "CargaVNoFarmaIngles"
            BaseEspecif = "Surfactan_II"
        End If
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

            If EsFarma() Then
                Dim WCargaIII As DataRow = GetSingle("SELECT TipoProceso FROM CargaIII WHERE Terminado = '" & txtCodigo.Text & "' And Paso in ('1', '01')")

                If WCargaIII IsNot Nothing Then
                    lblTipoProceso.Text = OrDefault(WCargaIII.Item("TipoProceso"), "").ToString.Trim.ToUpper
                End If

                txtEtapa.Focus()
            Else
                txtEtapa.Text = "99"
                txtEtapa_KeyDown(Nothing, New KeyEventArgs(Keys.Enter))
            End If

            '
            ' En caso de que se encuentre actualizada la Hoja, sea monocomponente y tenga un único componente, traemos los datos del mismo.
            '

            ' ¿Mono componente?
            If ProductoTerminado.EsMono(txtCodigo.Text) Then

                Dim WComponentes As DataRow = GetSingle("SELECT Tipo, Articulo, Terminado, Lote1, Lote2, Lote3 FROM Hoja WHERE Hoja = '" & txtPartida.Text & "' AND Renglon = 1")
                Dim WLote As String = ""
                ' ¿Tiene mas de un componente?
                For i = 1 To 3
                    Dim x As String = Trim(OrDefault(WComponentes.Item("Lote" & i), ""))

                    If Val(x) <> 0 Then
                        If WLote = "" Then
                            WLote = x
                        Else
                            ' Significa que tiene mas de un lote.
                            Exit Sub
                        End If
                    End If

                Next

                With WComponentes
                    txtComponente.Text = IIf(UCase(OrDefault(.Item("Tipo"), "M") = "T"), .Item("Terminado"), .Item("Articulo"))
                End With

                txtLotePartida.Text = WLote

            End If

        ElseIf e.KeyData = Keys.Escape Then
            txtPartida.Text = ""
        End If

    End Sub

    Private Sub txtEtapa_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtEtapa.KeyDown, txtRevalida.KeyDown, txtKilos.KeyDown, txtEspecifOrig.KeyDown, txtEspecifActual.KeyDown, txtSubEtapa.KeyDown

        If e.KeyData = Keys.Enter Then
            If Val(txtEtapa.Text) = 0 Then : Exit Sub : End If
            If Val(txtPartida.Text) = 0 Then : Exit Sub : End If

            WMotivoDesvio = ""

            btnGrabar.Text = "GRABAR"

            _CrearCarpetaEtapaIntermedia()

            Dim WEtapa, WPartida, WCodigo, WSubEtapa As String

            WEtapa = txtEtapa.Text
            WPartida = txtPartida.Text
            WCodigo = txtCodigo.Text
            WSubEtapa = txtSubEtapa.Text

            btnLimpiar_Click(Nothing, Nothing)

            txtEtapa.Text = WEtapa
            txtCodigo.Text = WCodigo
            txtPartida.Text = WPartida
            txtSubEtapa.Text = WSubEtapa

            Dim WExiste As DataRow

            Dim WCargaVSubEtapas As DataRow = GetSingle("SELECT SubEtapas FROM " & TablaCargaV & " WHERE Terminado = '" & txtCodigo.Text & "' And Paso = '" & txtEtapa.Text & "' Order By Clave", BaseEspecif)

            Dim WSubEtapas As Boolean = False

            If WCargaVSubEtapas IsNot Nothing Then WSubEtapas = Val(OrDefault(WCargaVSubEtapas.Item("SubEtapas"), "")) = 1

            txtSubEtapa.Visible = WSubEtapas

            If Val(txtEtapa.Text) = 99 Then
                txtSubEtapa.Visible = False
                WExiste = GetSingle("SELECT TOP 1 Clave FROM " & TablaPrueTer & " WHERE Partida = '" + txtPartida.Text + "'")
            Else
                '
                ' En ésta parte únicamente entrarían los productos de Planta III.
                '
                WExiste = GetSingle("SELECT TOP 1 Clave FROM PrueterfarmaIntermedio WHERE Producto = '" + txtCodigo.Text + "' And Paso = '" & txtEtapa.Text & "' And SubEtapa = '" & Val(txtSubEtapa.Text) & "'")

            End If

            lblTipoProceso.Text = ""

            If EsFarma() Then
                Dim WCargaIII As DataRow = GetSingle("SELECT TipoProceso FROM CargaIII WHERE Terminado = '" & txtCodigo.Text & "' And Paso in ('1', '01')")

                If WCargaIII IsNot Nothing Then
                    lblTipoProceso.Text = OrDefault(WCargaIII.Item("TipoProceso"), "").ToString.Trim.ToUpper
                End If

            End If

            If WExiste IsNot Nothing Then

                btnReimprimir.Visible = True

                Dim WPrueterFarma As DataTable

                If Val(txtEtapa.Text) = 99 Then
                    WPrueterFarma = GetAll("SELECT * FROM " & TablaPrueTer & " WHERE Partida = '" & txtPartida.Text & "' And Producto = '" & txtCodigo.Text & "' Order By Clave")
                Else
                    '
                    ' En ésta parte únicamente entrarían los productos de Planta III.
                    '
                    WPrueterFarma = GetAll("SELECT * FROM PrueterFarmaIntermedio WHERE Partida = '" & txtPartida.Text & "' And Producto = '" & txtCodigo.Text & "' And Paso = '" & txtEtapa.Text & "' And SubEtapa = '" & Val(txtSubEtapa.Text) & "' Order By Clave")
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

                        Dim WResultado As String
                        Dim WFarmacopea = OrDefault(.Item("Farmacopea"), "")
                        Dim WTipoEspecif = OrDefault(.Item("TipoEspecif"), "")
                        Dim WDesdeEspecif = OrDefault(.Item("DesdeEspecif"), "")
                        Dim WHastaEspecif = OrDefault(.Item("HastaEspecif"), "")
                        Dim WUnidadEspecif = OrDefault(.Item("UnidadEspecif"), "")
                        Dim WMenorIgualEspecif = OrDefault(.Item("MenorIgualEspecif"), "")
                        Dim WInformaEspecif = OrDefault(.Item("InformaEspecif"), "")
                        Dim WFormulaEspecif = OrDefault(.Item("FormulaEspecif"), "")
                        Dim WImpreResultado = _GenerarImpreParametro(WDesdeEspecif, WHastaEspecif, WUnidadEspecif, WMenorIgualEspecif, WInformaEspecif)

                        Dim WOperador = OrDefault(.Item("OperadorLabora"), "")
                        Dim WValor = Trim(OrDefault(.Item("ValorReal"), ""))

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

                        Dim WDescripcion As String

                        WResultado = _GenerarImpreResultado(WTipoEspecif, WDesdeEspecif, WHastaEspecif, WUnidadEspecif, WValor)

                        Dim r = dgvEnsayos.Rows.Add

                        With dgvEnsayos.Rows(r)
                            .Cells("Ensayo").Value = WEns
                            .Cells("Valor").Value = Trim(UCase(WValor))
                            .Cells("ValorBandera").Value = Trim(UCase(WValor))
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

                            .Cells("OperadorLabora").Value = Trim(WOperador)

                            Dim rowOP As DataRow = GetSingle("SELECT Iniciales FROM Operador WHERE Operador = '" & WOperador & "'", "SurfactanSa")
                            If rowOP IsNot Nothing Then
                                .Cells("OperadorIniciales").Value = OrDefault(rowOP.Item("Iniciales"), "")
                            Else
                                .Cells("OperadorIniciales").Value = ""
                            End If

                            For i = 1 To 10
                                .Cells("Variable" & i).Value = Trim(WFormulas(i, 1))
                                .Cells("VariableValor" & i).Value = WFormulas(i, 2)
                            Next

                            .Cells("Decimales").Value = ""

                            Dim WDecimales As String = .Cells("Decimales").Value

                            If WDecimales.Trim = "" Then
                                WDecimales = _CalcularCantidadDecimales(WDesdeEspecif)
                                If Val(WDecimales) < _CalcularCantidadDecimales(WHastaEspecif) Then WDecimales = _CalcularCantidadDecimales(WHastaEspecif)
                            End If

                            .Cells("Resultado").Value = WResultado
                            .Cells("Valor").Value = WValor

                            If Double.TryParse(WValor, Nothing) Then
                                .Cells("Valor").Value = formatonumerico(WValor, WDecimales)
                            End If

                            .Cells("Decimales").Value = WDecimales

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

                If EsFarma() Then
                    Dim _Notas As DataRow = GetSingle("SELECT Nota1, Nota2, Nota3, Nota4, Nota5, Nota6, Nota7, Nota8, Nota9 FROM PrueterFarmaIntermedio WHERE Partida = '" & txtPartida.Text & "' And Producto = '" & txtCodigo.Text & "' And Paso = '" & txtEtapa.Text & "'")

                    WNotas.Clear()

                    If _Notas IsNot Nothing Then

                        For i = 0 To 8

                            Dim WContenido As String = OrDefault(_Notas.Item("Nota" & i + 1), "")

                            WNotas.Add(Trim(WContenido))

                        Next

                    End If

                End If

                btnGrabar.Text = "ACTUALIZAR"

            Else

                Dim WCargaV As DataTable = GetAll("SELECT * FROM " & TablaCargaV & " WHERE Terminado = '" & txtCodigo.Text & "' And Paso = '" & txtEtapa.Text & "' Order By Clave", BaseEspecif)

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
                        Dim WImpreParametro = _GenerarImpreParametro(WDesdeEspecif, WHastaEspecif, WUnidadEspecif, WMenorIgualEspecif, WInformaEspecif)

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
                Dim WCargaVIngles As DataTable = GetAll("SELECT Valor, UnidadEspecif FROM " & TablaCargaVIng & " WHERE Terminado = '" & txtCodigo.Text & "' And Paso = '" & txtEtapa.Text & "' Order By Clave", BaseEspecif)

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

            If EsFarma() Then

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

                txtFechaVto.Text = ProductoTerminado.CalcularFechaElabVto(txtCodigo.Text, txtPartida.Text, True)(1)

                '
                ' Cargamos en caso de que no tenga, el componente si es monoproducto.
                '
                If ProductoTerminado.EsMono(txtCodigo.Text) Then
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
            End If

            If dgvEnsayos.Rows.Count > 0 Then
                btnPoolEnsayos.Enabled = True
                dgvEnsayos.CurrentCell = dgvEnsayos.Item("Valor", 0)
                If txtSubEtapa.Visible And Val(txtSubEtapa.Text) = 0 Then
                    txtSubEtapa.Focus()
                Else
                    dgvEnsayos.Focus()
                End If
            Else
                txtSubEtapa.Visible = False
                txtEtapa.Focus()
            End If

        ElseIf e.KeyData = Keys.Escape Then
            txtEtapa.Text = ""
        End If

        'PONGO EN BLANCO LAS INICIALES PARA CONSTATAR EN LA GRABACION DESPUES
        WIDOperadorAnalista = ""

    End Sub

    Private Sub _CrearCarpetaEtapaIntermedia()
        Directory.CreateDirectory(_CarpetaEtapaIntermedia)
    End Sub

    Private Function _GenerarImpreParametro(ByVal wDesdeEspecif As String, ByVal wHastaEspecif As String, ByVal wUnidadEspecif As String, ByVal wMenorIgualEspecif As String, ByVal WInformaEspecif As String) As String
        If Val(wDesdeEspecif) = 0 And Val(wHastaEspecif) = 0 Then Return "Cumple Ensayo"
        If Trim(wDesdeEspecif) = "" And Trim(wHastaEspecif) = "" Then Return ""

        wDesdeEspecif = Trim(wDesdeEspecif)
        wHastaEspecif = Trim(wHastaEspecif)
        wUnidadEspecif = Trim(wUnidadEspecif)
        wMenorIgualEspecif = Trim(wMenorIgualEspecif)
        WInformaEspecif = Trim(WInformaEspecif)

        If {99, 999, 9999, 99999}.Contains(Val(wHastaEspecif)) Then wHastaEspecif = "9999"

        If Val(wDesdeEspecif) <> 0 Or Val(wHastaEspecif) <> 9999 Then

            If Val(WInformaEspecif) = 0 Then Return "Informativo"

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

    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, ByVal keyData As Keys) As Boolean

        With dgvEnsayos
            If .Focused Or .IsCurrentCellInEditMode Then ' Detectamos los ENTER tanto si solo estan en foco o si estan en edición una celda.
                .CommitEdit(DataGridViewDataErrorContexts.Commit) ' Guardamos todos los datos que no hayan sido confirmados.

                If .CurrentCell Is Nothing Then Return False

                Dim iCol = .CurrentCell.ColumnIndex
                Dim iRow = .CurrentCell.RowIndex

                If msg.WParam.ToInt32() = Keys.Enter Then

                    If Not _ProcesarValorGrilla(.CurrentCell) Then Return True

                    Select Case iCol
                        Case 2
                            If iRow = .Rows.Count - 1 Then

                                ' .CurrentCell = .Rows(iRow).Cells(iCol + 1)
                                txtLibros.Focus()

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

                            Dim WTipo As String
                            Dim WDesde As String
                            Dim WHasta As String
                            Dim WUnidad As String
                            Dim WFormula As String
                            Dim WDecimales As String
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
                                        If WDialogResult = DialogResult.OK Then
                                            WValor = .Valor
                                            WVariables = .Variables
                                        Else
                                            Return False
                                        End If
                                    End With

                                End If

                                Dim WResultado As String = _GenerarImpreResultado(WTipo, WDesde, WHasta, WUnidad, WValor)

                                WDecimales = _CalcularCantidadDecimales(WDesde)
                                If Val(WDecimales) < _CalcularCantidadDecimales(WHasta) Then WDecimales = _CalcularCantidadDecimales(WHasta)

                                .Cells("Resultado").Value = WResultado
                                .Cells("Valor").Value = WValor

                                If Double.TryParse(WValor, Nothing) Then
                                    .Cells("Valor").Value = formatonumerico(WValor, WDecimales)
                                End If

                                .Cells("Decimales").Value = WDecimales

                                For i = 1 To 10
                                    .Cells("VariableValor" & i).Value = Trim(OrDefault(WVariables(i, 2), ""))
                                Next

                            End With

                            If Not _ValidarDato(dgvEnsayos.Rows(.RowIndex)) Then
                                MsgBox("Resultado fuera de especificación", MsgBoxStyle.Information)
                                Return False
                            End If

                        End If

                End Select

                If .RowIndex + 1 = dgvEnsayos.Rows.Count Then txtLibros.Focus()

            End With

            Return True

        Catch ex As FormatoNoNumericoException
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
            Return False
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
            Return False
        End Try

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
            ' Recalculamos los valores de las celdas que se calculen por Fórmula.
            '
            _RecalcularFormulas()

            If WActualizacionBloqueada Then

                WMotivoClaveSeguridad = TiposSolicitudClaveSeguridad.ActualizarEnsayoBloqueado

                Dim frm As New IngresoClaveSeguridad()
                frm.ShowDialog(Me)

                txtPartida.Focus()

                Exit Sub

            ElseIf WIDOperadorAnalista = "" Then

                WMotivoClaveSeguridad = TiposSolicitudClaveSeguridad.ActualizarEnsayoNoBloqueado

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

                WEsPorDesvio = True

            End If

            If txtDesvio.Text.Trim <> "" And Not WEsPorDesvio Then

                If MsgBox("Ha indicado información de Desvío para este Producto y etapa." & vbCrLf & vbCrLf & vbCrLf & "Si ésto es correcto ¿Desea Continuar con la Grabación del Ensayo?", MsgBoxStyle.YesNoCancel) <> MsgBoxResult.Yes Then
                    WEsPorDesvio = False
                    Exit Sub
                End If

                Dim mot As New IngresoMotivoDesvio(WMotivoDesvio)

                If mot.ShowDialog(Me) <> DialogResult.OK Then Exit Sub

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

            Dim WLiberada = ""

            If WNotas Is Nothing OrElse WNotas.Count = 0 Then
                For i = 0 To 9
                    WNotas.Add("")
                Next
            End If

            Dim WRenglon = 0

            Dim WTipoProceso As String = Trim(lblTipoProceso.Text)

            Dim WEsUnaActualizacion As Boolean

            Dim WTabla As String = IIf(Val(txtEtapa.Text) = 99, "Prueterfarma", "PrueterfarmaIntermedio")

            If Val(txtEtapa.Text) = 99 Then
                WTabla = TablaPrueTer
            End If

            Dim WPrueterFarma As DataRow

            WPrueterFarma = GetSingle("SELECT TOP 1 Clave FROM PrueterFarmaIntermedio WHERE Partida = '" & WPartida & "' And Producto = '" & WCodigo & "' And Paso = '" & WEtapa & "' And subEtapa = '" & Val(txtSubEtapa.Text) & "'")

            If Val(WEtapa) = 99 Then

                'If Operador.EsFarma Then WPrueterFarma = GetSingle("SELECT TOP 1 Clave FROM PrueterFarmaIntermedio WHERE Partida = '" & WPartida & "' And Producto = '" & WCodigo & "' And SubEtapa = ''")

                WSqls.Add("DELETE FROM " & TablaPrueTer & " WHERE Partida = '" & WPartida & "' And Producto = '" & WCodigo & "'")

            Else

                WSqls.Add("UPDATE PrueterfarmaIntermedio SET SubEtapa = '0' WHERE SubEtapa IS NULL Or SubEtapa = ''")
                WSqls.Add("DELETE FROM PrueterfarmaIntermedio WHERE Partida = '" & WPartida & "' And Producto = '" & WCodigo & "' And Paso = '" & WEtapa & "' And subEtapa = '" & Val(txtSubEtapa.Text) & "'")

            End If

            WEsUnaActualizacion = WPrueterFarma IsNot Nothing

            For Each row As DataGridViewRow In dgvEnsayos.Rows
                With row
                    Dim WEns As String = OrDefault(.Cells("Ensayo").Value, 0)
                    Dim WEspecificacion As String = OrDefault(.Cells("Especificacion").Value, "")
                    Dim WValor As String = OrDefault(.Cells("Valor").Value, "")
                    Dim WValorBandera As String = OrDefault(.Cells("ValorBandera").Value, "")
                    Dim WResultado As String
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



                    Dim WOperadorLabora As String = WIDOperadorAnalista ' Se lo obtiene cuando se valida la contraseña.

                    Dim WFormulas(10, 2) As String

                    For i = 1 To 10
                        WFormulas(i, 1) = Trim(OrDefault(.Cells("Variable" & i).Value, ""))
                        WFormulas(i, 2) = Trim(OrDefault(.Cells("VariableValor" & i).Value, "")).Replace(",", ".")
                    Next

                    WResultado = _GenerarImpreResultado(WTipoEspecif, WDesdeEspecif, WHastaEspecif, WUnidadEspecif, WValor)

                    WRenglon += 1

                    Dim WClave = "1" & WCodigo & txtPartida.Ceros(6) & IIf(Val(txtEtapa.Text) = 99, "", txtEtapa.Ceros(2)) & WRenglon.Ceros(2)

                    If Val(txtEtapa.Text) <> 99 Then WClave = "1" & WCodigo & txtPartida.Ceros(6) & txtEtapa.Ceros(2) & txtSubEtapa.Ceros(2) & WRenglon.Ceros(2)

                    Dim ZSql = ""

                    ZSql = ZSql & "INSERT INTO " & WTabla & " ("
                    ZSql = ZSql & "Clave ,"
                    If Val(txtEtapa.Text) <> 99 Then ZSql = ZSql & "Paso , SubEtapa ,"
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

                    ZSql = ZSql & "Liberada ,"
                    ZSql = ZSql & "OperadorLabora)"
                    ZSql = ZSql & "Values ("
                    ZSql = ZSql & "'" & WClave & "',"
                    If Val(txtEtapa.Text) <> 99 Then ZSql = ZSql & "'" & Trim(txtEtapa.Text) & "', '" & Val(txtSubEtapa.Text) & "',"
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

                    If WNoGrabaIniciales = False Then
                        If WValorBandera <> WValor Then
                            ZSql = ZSql & "'" & WLiberada & "',"
                            ZSql = ZSql & "'" & WOperadorLabora & "')"
                        Else
                            ZSql = ZSql & "'" & WLiberada & "',"
                            ZSql = ZSql & "'" & Trim(.Cells("OperadorLabora").Value) & "')"
                        End If
                    Else
                        ZSql = ZSql & "'" & WLiberada & "',"
                        ZSql = ZSql & "'" & Trim(.Cells("OperadorLabora").Value) & "')"
                    End If


                    WSqls.Add(ZSql)

                End With

            Next

            With WNotas
                WSqls.Add("UPDATE " & WTabla & " SET " &
                          "WDate = '" & Date.Now.ToString("dd-MM-yyyy") & "'," &
                          "Operador = '" & Codigo & "'," &
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

            If Val(txtEtapa.Text) <> 99 Then

                _GuardarNuevaVersionPDFConEnsayosIntermedios()

                _EnviarAvisoEnsayosIntermedios(WEsUnaActualizacion)

            Else

                Dim WImpre() As String = _PrepararInformacionRegistroEnsayoFinalPT()

                '
                ' REALIZAMOS IMPRESION CON REDUCCION AL 80%
                '
                If EsFarma() Then _GenerarReporteResultadosCalidad(txtPartida.Text, 1, WImpre(0), WImpre(1), WImpre(2), WImpre(3))
                '
                ' REALIZAMOS IMPRESION CON REDUCCION AL 100%
                '
                _GenerarReporteResultadosCalidad(txtPartida.Text, 4, WImpre(0), WImpre(1), WImpre(2), WImpre(3))

                '
                ' EXPORTAMOS EL PDF DE LA ETAPA FINAL.
                '
                _GenerarReporteResultadosCalidad(txtPartida.Text, 3, WImpre(0), WImpre(1), WImpre(2), WImpre(3))

            End If

            btnLimpiar.PerformClick()

            txtPartida.Focus()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub _EnviarAvisoEnsayosIntermedios(Optional ByVal EsActualizacion As Boolean = False)

        Directory.CreateDirectory(RUTA_TEMP)

        Dim frm As New Util.VistaPrevia

        With frm
            .Reporte = New ValoresEnsayosIntermediosPTFarma
            .Formula = "{PrueterFarmaIntermedio.Producto} = '" & txtCodigo.Text & "' And {PrueterFarmaIntermedio.Paso} = " & txtEtapa.Text & " And {PrueterFarmaIntermedio.Partida} = " & txtPartida.Text & " And {PrueterFarmaIntermedio.Producto} = {Terminado.Codigo}"

            Dim nombreArchivo = String.Format("{0} {1} - Etapa {2}.pdf", txtCodigo.Text, txtPartida.Ceros(6), txtEtapa.Ceros(2))

            File.Delete(RUTA_TEMP & nombreArchivo)

            .Exportar(nombreArchivo, ExportFormatType.PortableDocFormat, RUTA_TEMP)

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

        Dim frm As Util.VistaPrevia = New Util.VistaPrevia

        With frm
            .Reporte = New ValoresEnsayosIntermediosPTFarma
            .Formula = "{PrueterFarmaIntermedio.Partida} = " & txtPartida.Text & " AND {Prueterfarmaintermedio.Paso} = " & txtEtapa.Text & " AND {Prueterfarmaintermedio.Producto} = '" & txtCodigo.Text & "' AND {Prueterfarmaintermedio.Producto} = {Terminado.Codigo}"
        End With

        frm.Exportar(String.Format("{0}-{1}-{2}", txtCodigo.Text, txtPartida.Ceros(6), Date.Now.ToString("yyyyMMdd-HHmm")), ExportFormatType.PortableDocFormat, String.Format("{0}", _CarpetaEtapaIntermedia))

    End Sub

    Private Sub _RecalcularFormulas()

        Dim WTipo As String

        For Each row As DataGridViewRow In dgvEnsayos.Rows
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

    '
    ' Validamos los valores ingresados.
    '
    ' Se validan los datos para aquellos Prductos para los que se han definido
    ' las especificaciones por Sistema. En los casos de aquellos productos que no,
    ' se deja sin validación como hasta el dia de hoy.
    '
    Private Function _ValidarValoresIngresados() As Boolean

        ' ReSharper disable once LoopCanBeConvertedToQuery
        For Each row As DataGridViewRow In dgvEnsayos.Rows
            If Not _ValidarDato(row) Then Return False
        Next

        Return True

    End Function

    Private Function _ValidarDato(ByVal row As DataGridViewRow, Optional ByVal ModoSilencioso As Boolean = False) As Boolean

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
                            If Not ModoSilencioso Then
                                Throw New FormatoNoNumericoException("Hay un error de Formato en el valor proporcionado. " & vbCrLf & vbCrLf & "Se esperaba un valor numérico.")
                            Else
                                Return False
                            End If
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

            Dim WValido As Double = 0

            If Not Double.TryParse(wValor.ToString, WValido) Then Return ""

            Dim WDecimales As Short = _CalcularCantidadDecimales(wDesdeEspecif, 0)

            If WDecimales < _CalcularCantidadDecimales(wHastaEspecif, 0) Then WDecimales = _CalcularCantidadDecimales(wHastaEspecif, 0)

            wValor = formatonumerico(wValor, WDecimales)

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
        If txtLibros.Text.Trim = "" Then Throw New Exception("No se ha informado la información de Libros correspondiente.")
        If txtPaginas.Text.Trim = "" Then Throw New Exception("No se ha informado la información de Páginas correspondiente.")
        If txtConfecciono.Text.Trim = "" Then Throw New Exception("No se ha informado quién Confecciona el ingreso de Ensayos.")

        '
        ' Verificamos Datos Ingresados.
        '
        Dim WTerminado As DataRow = GetSingle("SELECT Codigo FROM Terminado WHERE Codigo = '" & txtCodigo.Text & "'")
        If WTerminado Is Nothing Then Throw New Exception("El Código de Producto Terminado es inválido.")

        Dim WHoja As DataRow = GetSingle("SELECT Producto FROM Hoja WHERE Hoja = '" & txtPartida.Text & "' And Renglon in ('1', '01')")

        If WHoja Is Nothing Then Throw New Exception("La Hoja indicada es Inexistente.")

        If WHoja.Item("Producto").ToString.ToUpper <> txtCodigo.Text.ToUpper Then Throw New Exception("El Código de Producto Terminado indicado no se corresponde con el indicado en la Hoja de Producción.")

        If EsFarma() Then
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
            ' Validamos en caso de tener informado un componente si tiene o no un lote/partida valido/a.
            '
            If txtComponente.Text.Trim <> "" Then

                Dim WLongitud As Short = txtComponente.Text.Replace(" ", "").Length

                If WLongitud = 10 Or WLongitud = 12 Then
                    Dim WComp As DataRow

                    If WLongitud = 10 Then
                        WComp = GetSingle("SELECT Codigo FROM Articulo WHERE Codigo = '" & txtComponente.Text & "'")
                    Else
                        WComp = GetSingle("SELECT Codigo FROM Terminado WHERE Codigo = '" & txtComponente.Text & "'")
                    End If

                    If WComp Is Nothing Then Throw New Exception("El código del Componente, no es un codigo válido.")

                    Dim WLotePartida As DataRow = Nothing

                    For Each empresa As String In Conexion.Empresas
                        If WLongitud = 10 Then
                            WLotePartida = GetSingle("SELECT Laudo FROM Laudo WHERE Articulo = '" & txtComponente.Text & "' And Laudo = '" & txtLotePartida.Text & "' And Renglon = '1'", empresa)
                        Else
                            WLotePartida = GetSingle("SELECT Hoja FROM Hoja WHERE Producto = '" & txtComponente.Text & "' And Hoja = '" & txtLotePartida.Text & "' And Renglon = '1'", empresa)
                        End If
                        If WLotePartida IsNot Nothing Then Exit For
                    Next

                    If WLotePartida Is Nothing Then Throw New Exception("El Lote/Partida indicado para el Componente, no es válido.")

                Else
                    Throw New Exception("El código del Componente, no es un codigo válido.")
                End If

            End If
        End If

        '
        ' Verificamos en caso de que ya se encuentre grabado, si tenia algun dato como Pendiente. En caso de que no, se pide la clave de seguridad para poder actualizar.
        '
        Dim WDatos As DataTable

        If Val(txtEtapa.Text) = 99 Then
            WDatos = GetAll("SELECT ValorReal FROM " & TablaPrueTer & " WHERE Producto = '" & txtCodigo.Text & "' AND Partida = '" & txtPartida.Text & "' ORDER BY Clave")
        Else
            WDatos = GetAll("SELECT ValorReal FROM PrueterFarmaIntermedio WHERE Producto = '" & txtCodigo.Text & "' AND Partida = '" & txtPartida.Text & "' AND Paso = '" & txtEtapa.Text & "' And SubEtapa = '" & Val(txtSubEtapa.Text) & "' ORDER BY Clave")
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

        WNoGrabaIniciales = False
        WIDOperadorAnalista = ""

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

                Dim WDatos As DataRow = GetSingle("SELECT Operador, GrabaV, FechaGrabaV FROM Operador WHERE Clave = '" & UCase(WClave) & "'", "SurfactanSa")

                If WDatos IsNot Nothing Then
                    Dim WGrabaV As String = OrDefault(WDatos.Item("GrabaV"), "")
                    If WGrabaV.ToUpper = "S" Then
                        WAutorizaActualizacionBloqueado = True
                        WIDOperadorAnalista = OrDefault(WDatos.Item("Operador"), "")
                        WNoGrabaIniciales = True
                        btnGrabar.PerformClick()
                        Exit Sub
                    End If
                End If

                MsgBox("Clave Incorrecta")
                Dim frm As New IngresoClaveSeguridad
                frm.ShowDialog(Me)

            Case TiposSolicitudClaveSeguridad.ActualizarEnsayoNoBloqueado

                Dim WDatos As DataRow = GetSingle("SELECT Operador, AnalistaLab FROM Operador WHERE Clave = '" & UCase(WClave) & "'", "SurfactanSa")

                If WDatos IsNot Nothing Then
                    Dim AnalistasLabPermiso As String = OrDefault(WDatos.Item("AnalistaLab"), "")
                    If AnalistasLabPermiso.ToUpper = "S" Then
                        WIDOperadorAnalista = OrDefault(WDatos.Item("Operador"), "")
                        btnGrabar_Click(Nothing, Nothing)
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

    Private Sub btnActualizarEspecif_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnActualizarEspecif.Click

        Dim WPrueterFarmaI As DataTable

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
                WImpreParametro = _GenerarImpreParametro(WDesdeEspecif, WHastaEspecif, WUnidadEspecif, WMenorIgualEspecif, WInformaEspecif)

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

                        .Cells("Decimales").Value = _CalcularCantidadDecimales(WValor, 2) 'IIf(WValor.Trim = "", "2", "0")

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
                WImpreParametro = _GenerarImpreParametro(WDesdeEspecif, WHastaEspecif, WUnidadEspecif, WMenorIgualEspecif, WInformaEspecif)

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

    Private Function _CalcularCantidadDecimales(ByVal WValor As String, Optional ByVal _Default As Short = 0) As Short

        If Double.TryParse(WValor, Nothing) Then
            Dim aux As Integer = WValor.Trim.IndexOfAny({",", "."})

            If aux > 0 Then
                Dim t As String = _Right(WValor, WValor.Trim.Replace(".", "").Replace(",", "").Length - aux)
                Return t.Length
            End If
        End If

        Return _Default

    End Function

    Private Sub btnImprimirEnsayosIngresados_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnRevalida.Click, btnReimprimir.Click

        If Val(txtEtapa.Text) = 99 Then

            Dim WImpre() As String = _PrepararInformacionRegistroEnsayoFinalPT()

            _GenerarReporteResultadosCalidad(txtPartida.Text, 2, WImpre(0), WImpre(1), WImpre(2), WImpre(3))

        Else

            With New VistaPrevia
                .Reporte = New ValoresEnsayosIntermediosPTFarma
                .Formula = "{PrueterFarmaIntermedio.Producto} = '" & txtCodigo.Text & "' And {PrueterFarmaIntermedio.Paso} = " & txtEtapa.Text & " And {PrueterFarmaIntermedio.Partida} = " & txtPartida.Text & " And {PrueterFarmaIntermedio.Producto} = {Terminado.Codigo}"
                .Mostrar()
            End With

        End If

    End Sub

    Private Function _PrepararInformacionRegistroEnsayoFinalPT() As String()

        '
        ' Reprocesamos y Actualizamos las descripciones de los parámetros para que estén al dia con las posibles modificaciones.
        '
        Dim WPrueterFarmaI As DataTable = GetAll("SELECT Clave, TipoEspecif, DesdeEspecif, HastaEspecif, UnidadEspecif, MenorIgualEspecif, InformaEspecif, Valor FROM " & TablaPrueTer & " WHERE Partida = '" & txtPartida.Text & "' ORDER By Clave")

        Dim WClave, WDesdeEspecif, WHastaEspecif, WUnidadEspecif, WMenorIgualEspecif, WImpreParametro As String

        For Each row As DataRow In WPrueterFarmaI.Rows
            With row
                WClave = OrDefault(.Item("Clave"), "")
                WDesdeEspecif = OrDefault(.Item("DesdeEspecif"), "")
                WHastaEspecif = OrDefault(.Item("HastaEspecif"), "")
                WUnidadEspecif = OrDefault(.Item("UnidadEspecif"), "")
                WMenorIgualEspecif = OrDefault(.Item("MenorIgualEspecif"), "")
                Dim WValor = Trim(OrDefault(.Item("Valor"), ""))
                Dim WInformaEspecif = Trim(OrDefault(.Item("InformaEspecif"), ""))
                WImpreParametro = _GenerarImpreParametro(WDesdeEspecif, WHastaEspecif, WUnidadEspecif, WMenorIgualEspecif, WInformaEspecif)

                If WClave.Trim <> "" Then
                    ExecuteNonQueries({"UPDATE " & TablaPrueTer & " SET  Impre1 = '" & WImpreParametro & "', Impre2 = '" & WValor & "' WHERE Clave = '" & WClave & "'"})
                End If

            End With
        Next

        '
        ' Calculamos las Cantidades.
        '
        Dim WTeorico As String
        WTeorico = "0"
        Dim WHoja As DataRow = GetSingle("SELECT Teorico FROM Hoja WHERE Hoja = '" & txtPartida.Text & "' And Renglon = 1")
        If WHoja IsNot Nothing Then
            WTeorico = OrDefault(WHoja.Item("Teorico"), "0")
        End If

        WTeorico = formatonumerico(WTeorico)

        ExecuteNonQueries(String.Format("UPDATE " & TablaCargaV & " SET ImpreTerminado = '{0}', Partida = '{1}', FechaIng = '{2}', CantidadPartida = '{3}', ImprePaso = '99' WHERE Terminado = '{0}'", txtCodigo.Text, txtPartida.Text, txtFecha.Text, WTeorico))

        '
        ' Calculamos las Fechas de Elaboracion y Vencimiento.
        '
        Dim WPasaMono As Short = 0
        Dim WEsFazon As Boolean
        Dim WImpre1, WImpre2, WImpre3, WImpre4 As String

        Dim WMono As DataRow = GetSingle("SELECT Tipo FROM CodigoMono WHERE Codigo = '" & txtCodigo.Text & "'", "SurfactanSa")
        If WMono IsNot Nothing Then WPasaMono = OrDefault(WMono.Item("Tipo"), 0)

        Dim WTer As String = Mid(txtCodigo.Text, 4, 5)
        WEsFazon = Val(WTer) > 2999 And Val(WTer) < 4000
        WImpre1 = "F.Reanálisis:"

        If WPasaMono > 0 And WEsFazon Then
            Dim WDatos As String() = ProductoTerminado._CalculaMonoOtro(txtPartida.Text, Base)
            Dim WTipoVencimiento As Short = Val(WDatos(2))
            WImpre1 = IIf(WTipoVencimiento = 1, "F.Reanálisis:", "F.Vencimiento:")
        End If

        Dim WDatosII As String() = ProductoTerminado.CalcularFechaElabVto(txtCodigo.Text, txtPartida.Text)

        WImpre2 = WDatosII(1)
        WImpre3 = ""
        WImpre4 = ""

        If Trim(WDatosII(0)) <> "" Then
            WImpre3 = "F.Elaboración:"
            WImpre4 = WDatosII(0)
        End If

        Return {WImpre1, WImpre2, WImpre3, WImpre4}

    End Function

    Private Sub _GenerarReporteResultadosCalidad(ByVal wPartida As Integer, ByVal wTipoSalida As Integer, ByVal wFechaVto As String, ByVal wImpreFechaVto As String, ByVal wFechaElabora As String, ByVal wImpreFechaElaboracion As String)

        With New VistaPrevia

            If {0, 1}.Contains(wTipoSalida) Then
                .Reporte = New imprecalidadresultadoReduccionAl80
            ElseIf EsFarma() Then
                .Reporte = New imprecalidadresultado
            Else
                .Reporte = New imprecalidadresultadoNoFarma
            End If

            .Reporte.SetParameterValue("FechaVto", wFechaVto)
            .Reporte.SetParameterValue("ImpreFechaVto", wImpreFechaVto)
            .Reporte.SetParameterValue("FechaElabora", wFechaElabora)
            .Reporte.SetParameterValue("ImpreFechaElaboracion", wImpreFechaElaboracion)

            .Base = Base

            If EsFarma() Then
                .Formula = "{Prueterfarma.Partida} = " & wPartida & " And {Hoja.Hoja} = {Prueterfarma.Partida} And {Hoja.Renglon} = 1"
            Else
                .Formula = "{PrueterNofarma.Partida} = " & wPartida & " And {Hoja.Hoja} = {PrueterNofarma.Partida} And {Hoja.Renglon} = 1"
            End If

            Select Case wTipoSalida
                Case 0, 1, 4
                    .Imprimir()
                Case 2
                    .Mostrar()
                Case 3
                    .Exportar(String.Format("{0}-{1}-{2}", txtCodigo.Text, txtPartida.Ceros(6), Date.Now.ToString("yyyyMMdd-HHmm")), ExportFormatType.PortableDocFormat, String.Format("{0}", _CarpetaEtapaIntermedia))
            End Select

        End With

    End Sub

    Private Sub NumerosConComas(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles txtKilos.KeyPress
        If Not Char.IsNumber(e.KeyChar) And Not Char.IsControl(e.KeyChar) And Not (CChar(".")) = e.KeyChar Then
            e.Handled = True
        End If
    End Sub

    Private Sub btnNotasAnteriores_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnNotasAnteriores.Click
        With New NotasAnterioresFarmaPT(txtPartida.Text, txtEtapa.Text)
            .ShowDialog(Me)
        End With
    End Sub

    Private Sub txtComponente_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtComponente.KeyDown

        If e.KeyData = Keys.Enter Then
            Dim longitud As Integer = txtComponente.Text.Replace(" ", "").Length

            If longitud = 10 Or longitud = 12 Then

                Dim WComp As DataRow

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

    Private Sub txtLotePartida_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtLotePartida.KeyDown

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
                        txtOOS.Focus()
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
                txtOOS.Focus()
            End If

        ElseIf e.KeyData = Keys.Escape Then
            txtLotePartida.Text = ""
        End If

    End Sub

    Private Sub btnNotasCertAnalisis_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnNotasCertAnalisis.Click
        With New NotasCertificadosAnalisisFarmaPT(txtPartida.Text, PermisoGrabar)
            .ShowDialog(Me)
        End With
    End Sub

    Private Sub btnImprimirEnsayosIngresados_Click_1(ByVal sender As Object, ByVal e As EventArgs) Handles btnImprimirEnsayosIngresados.Click
        With New PDFVersionesPTFarma(txtPartida.Text)
            .ShowDialog(Me)
        End With
    End Sub

    Private Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnPoolEnsayos.Click
        With New ListaPoolEnsayos(txtCodigo.Text, txtPartida.Text, txtEtapa.Text, dgvEnsayos.Rows)
            .ShowDialog(Me)
        End With
    End Sub

    Public Sub _ProcesarAyudaPruebasAnteriores(LotePartida As String) Implements IAyudaPruebasAnteriores._ProcesarAyudaPruebasAnteriores
        txtPartida.Text = LotePartida
        txtPartida_KeyDown(Nothing, New KeyEventArgs(Keys.Enter))
        txtEtapa.Text = "99"
        txtEtapa_KeyDown(Nothing, New KeyEventArgs(Keys.Enter))
    End Sub

    Private Sub btnConsulta_Click(sender As Object, e As EventArgs) Handles btnConsulta.Click
        Dim WDatos As DataTable = GetAll("SELECT ptf.Fecha, ptf.Partida as LotePartida, ptf.Producto As Codigo, t.Descripcion FROM " & TablaPrueTer & " ptf INNER JOIN Terminado t ON t.Codigo = ptf.Producto AND ptf.Renglon = 1 ORDER BY ptf.FechaOrd DESC, ptf.Partida DESC")
        With New AyudaPruebasAnteriores(WDatos)
            .ShowDialog(Me)
        End With
    End Sub

    Private Sub txtPartida_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles txtPartida.MouseDoubleClick
        btnConsulta_Click(Nothing, Nothing)
    End Sub

    Private Sub txtLibros_KeyDown(sender As Object, e As KeyEventArgs) Handles txtLibros.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                If txtLibros.Text <> "" Then
                    txtPaginas.Focus()
                End If


            Case Keys.Escape

                txtLibros.Text = ""
        End Select
    End Sub

    Private Sub txtPaginas_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPaginas.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                If txtPaginas.Text <> "" Then

                    txtEnvases.Focus()

                End If

            Case Keys.Escape

                txtPaginas.Text = ""
        End Select
    End Sub

    Private Sub txtEnvases_KeyDown(sender As Object, e As KeyEventArgs) Handles txtEnvases.KeyDown
        Select Case e.KeyData
            Case Keys.Enter

                If txtComponente.Enabled Then
                    txtComponente.Focus()
                Else
                    txtCantidadEtiquetas.Focus()
                End If

            Case Keys.Escape

                txtEnvases.Text = ""
        End Select
    End Sub

    Private Sub txtCantidadEtiquetas_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCantidadEtiquetas.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                txtArchivo.Focus()
            Case Keys.Escape
                txtCantidadEtiquetas.Text = ""

        End Select
    End Sub

    Private Sub txtOOS_KeyDown(sender As Object, e As KeyEventArgs) Handles txtOOS.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                txtDesvio.Focus()
            Case Keys.Escape
                txtOOS.Text = ""
        End Select
    End Sub

    Private Sub txtDesvio_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDesvio.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                txtCantidadEtiquetas.Focus()
            Case Keys.Escape
                txtDesvio.Text = ""
        End Select
    End Sub

    Private Sub txtArchivo_KeyDown(sender As Object, e As KeyEventArgs) Handles txtArchivo.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                txtConfecciono.Focus()
            Case Keys.Escape
                txtArchivo.Text = ""
        End Select
    End Sub

    Private Sub btnTraerDatosEnsayosComponente_Click(sender As Object, e As EventArgs) Handles btnTraerDatosEnsayosComponente.Click

        If Val(txtLotePartida.Text) = 0 Then Exit Sub

        Dim frm As New EnsayosMonocomponente(txtComponente.Text, txtLotePartida.Text)

        frm.Show(Me)

    End Sub

    Public Sub _ProcesarEnsayosMonoComponente(datos As DataGridViewRow) Implements IEnsayosMonoComponente._ProcesarEnsayosMonoComponente
        Dim WTipoDatoI, WTipoDatoII As String
        Dim WValor, WResultado, WDesde, WHasta, WMenorIgual, WInforma, WFormula, WUnidad As String
        Dim WVariables(10), WVariablesValores(10) As String

        If dgvEnsayos.Rows.Count = 0 Then Exit Sub

        If dgvEnsayos.SelectedRows.Count = 0 Then dgvEnsayos.Rows(0).Selected = True

        WTipoDatoI = dgvEnsayos.SelectedRows(0).Cells("TipoEspecif").Value
        WTipoDatoII = datos.Cells("TipoEspecif").Value

        WValor = Trim(datos.Cells("Valor").Value)
        WDesde = Trim(datos.Cells("DesdeEspecif").Value)
        WHasta = Trim(datos.Cells("HastaEspecif").Value)
        WMenorIgual = Trim(datos.Cells("MenorIgualEspecif").Value)
        WInforma = Trim(datos.Cells("InformaEspecif").Value)
        WFormula = Trim(datos.Cells("FormulaEspecif").Value)
        WUnidad = Trim(datos.Cells("UnidadEspecif").Value)

        WResultado = _GenerarImpreResultado(WTipoDatoII, WDesde, WHasta, WUnidad, WValor)

        For r As Integer = 1 To 10
            WVariables(r) = Trim(datos.Cells("Variable" & r).Value)
            WVariablesValores(r) = Trim(datos.Cells("VariableValor" & r).Value)
        Next

        '
        ' Se agrega los datos unicamente si son iguales o si el tipo de dato entrante 
        ' es 'Formula' y el saliente es 'Numerico'.
        '
        If (Val(WTipoDatoI) = Val(WTipoDatoII)) Or (Val(WTipoDatoI) = 1 And Val(WTipoDatoII) = 2) Then

            Dim row As DataGridViewRow = dgvEnsayos.SelectedRows(0)

            row.Cells("TipoEspecif").Value = WTipoDatoII
            row.Cells("Valor").Value = WValor
            row.Cells("Resultado").Value = WResultado
            row.Cells("DesdeEspecif").Value = WDesde
            row.Cells("HastaEspecif").Value = WHasta
            row.Cells("MenorIgualEspecif").Value = WMenorIgual
            row.Cells("InformaEspecif").Value = WInforma
            row.Cells("FormulaEspecif").Value = WFormula

            For r As Integer = 1 To 10
                row.Cells("Variable" & r).Value = WVariables(r)
                row.Cells("VariableValor" & r).Value = WVariablesValores(r)
            Next

            dgvEnsayos.ClearSelection()

            If dgvEnsayos.Rows.Count > row.Index + 1 Then
                dgvEnsayos.Rows(row.Index + 1).Selected = True
            End If
        Else
            MsgBox("Los tipos de datos no son compatibles entre si", MsgBoxStyle.Exclamation)
        End If

    End Sub
End Class
Friend Class FormatoNoNumericoException
    Inherits Exception

    Sub New(ByVal Msg As String)
        MyBase.New(Msg)
    End Sub

End Class