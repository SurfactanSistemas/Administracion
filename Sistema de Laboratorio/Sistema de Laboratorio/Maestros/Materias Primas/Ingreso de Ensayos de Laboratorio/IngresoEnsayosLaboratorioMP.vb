Imports System.Configuration
Imports System.IO
Imports System.Text.RegularExpressions
Imports Util
Imports Util.Clases
Imports CrystalDecisions.Shared
Imports info.lundin.math
Imports Laboratorio.Entidades

Public Class IngresoEnsayosLaboratorioMP : Implements IIngresoClaveSeguridad, IAyudaPruebasAnteriores



    Private WNotas As New List(Of String)
    Private WEsPorDesvio As Boolean = False
    Private WEsPorRechazo As Boolean = False
    Private WMotivoDesvio As String = ""
    Private WMotivoClaveSeguridad As TiposSolicitudClaveSeguridad = TiposSolicitudClaveSeguridad.General
    Private WActualizacionBloqueada As Boolean = False
    Private WIDOperadorAnalista As String = ""
    Private WNoGrabaIniciales As Boolean = False
    Private WAutorizaActualizacionBloqueado As Boolean = False
    Private WActualiza As Boolean = False

    Private ReadOnly PATH_ENSAYOS_INTERMEDIOS As String = ConfigurationManager.AppSettings("PATH_ENSAYOS_INTERMEDIOS_MP").ToString()

	Private TablaPrueTer As String = "PrurTerFarma"
    Private TablaCargaV As String = "CargaV"

	Private WEnvase, WCert1, WCert2, WEstado1, WEstado2, WVenc, WFechaElab, WTipoVenc, WCantidadLaudo, WProcedencia, WNroDespacho As String

    Dim PermisoGrabar As Boolean
    Sub New(ByVal ID As String)

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Dim SQLCnslt As String = "SELECT Escritura FROM PermisosPerfiles WHERE ID = '" & ID & "' AND Sistema = 'LABORATORIO' AND Perfil = '" & Operador.Perfil & "' AND Planta = '" & Operador.Base & "' ORDER BY ID"
        Dim Row As DataRow = GetSingle(SQLCnslt, "SurfactanSa")
        If Row IsNot Nothing Then
            PermisoGrabar = Row.Item("Escritura")
        End If


    End Sub
	Private Sub btnCerrar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCerrar.Click
		Close()
	End Sub

	Private Sub btnLimpiar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnLimpiar.Click
		For Each c As Control In {txtFechaRevalida, txtArchivo, txtCodigo, txtConfecciono, txtEnvases, txtComponente, txtLotePartida, txtCantidadEtiquetas, txtDesvio, txtDescMP, txtEtapa, txtFecha, txtLibros, txtOrden, txtInforme, txtOOS, txtPaginas, txtPartida, lblTipoProceso, txtFechaVto, lblDescEtapa, txtEspecifActual, txtEspecifOrig, txtRevalida, txtKilos, txtLoteProveedor}
			c.Text = ""
		Next
		dgvEnsayos.Rows.Clear()

		WNotas = New List(Of String)
		For i = 0 To 8
			WNotas.Add("")
		Next

		WEsPorDesvio = False
		WEsPorRechazo = False
		WMotivoDesvio = ""

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

		txtCodigo.Focus()
		btnGrabar.Enabled = True

		btnGrabar.Text = "GRABAR"

        WActualiza = False

        If PermisoGrabar = False Then

            btnGrabar.Enabled = False

        End If

	End Sub

	Private Sub IngresoEnsayosIntermediosPT_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
		If Not EsFarma() Then
			TablaPrueTer = "PrueTerNoFarma"
			TablaCargaV = "CargaVNoFarma"
		End If
		dgvEnsayos.InhabilitarOrdenamientoColumnas()
		btnLimpiar_Click(Nothing, Nothing)
	End Sub

	Private Sub IngresoEnsayosIntermediosPT_Shown(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Shown
		txtCodigo.Focus()
	End Sub

	Private Sub txtPartida_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtPartida.KeyDown

		If e.KeyData = Keys.Enter Then
			If Trim(txtPartida.Text) = "" Then : Exit Sub : End If

			Dim WLaudo As DataRow = GetSingle("SELECT Articulo, Orden, Informe FROM Laudo WHERE Laudo = '" & txtPartida.Text & "' And Renglon in ('1', '01')")

			If IsNothing(WLaudo) Then Exit Sub

			With WLaudo
				txtCodigo.Text = OrDefault(.Item("Articulo"), "")
				txtOrden.Text = OrDefault(.Item("Orden"), "")
				txtInforme.Text = OrDefault(.Item("Informe"), "")
			End With
			txtEtapa.Text = "99"
			lblTipoProceso.Text = ""

			txtEtapa_KeyDown(Nothing, New KeyEventArgs(Keys.Enter))


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

			Dim WEtapa, WPartida, WCodigo As String

			WEtapa = txtEtapa.Text
			WPartida = txtPartida.Text
			WCodigo = txtCodigo.Text
			Dim WOrden As String = txtOrden.Text
			Dim WInforme As String = txtInforme.Text

			btnLimpiar_Click(Nothing, Nothing)

			txtEtapa.Text = WEtapa
			txtCodigo.Text = WCodigo
			txtPartida.Text = WPartida
			txtOrden.Text = WOrden
			txtInforme.Text = WInforme

			Dim WExiste As DataRow = Nothing

			If Val(txtEtapa.Text) = 99 Then
				WExiste = GetSingle("SELECT Clave = Prueba FROM PrueArt WHERE Lote = '" + txtPartida.Text + "'")
			End If

			If WExiste IsNot Nothing Then

				btnReimprimir.Visible = True

				Dim WPrueterFarma As DataTable = Nothing
				Dim BuscaEnTablaVieja As Boolean = False

				If Val(txtEtapa.Text) = 99 Then
					WPrueterFarma = GetAll("SELECT * FROM PrueArtNuevo WHERE LotePartida = '" & txtPartida.Text & "' And Producto = '" & txtCodigo.Text & "' Order By Prueba")
				End If

				If WPrueterFarma.Rows.Count = 0 Then
					BuscaEnTablaVieja = True
					If Val(txtEtapa.Text) = 99 Then
						WPrueterFarma = GetAll("SELECT * FROM PrueArt WHERE Lote = '" & txtPartida.Text & "' And Producto = '" & txtCodigo.Text & "' Order By Prueba")
					End If
				End If

				dgvEnsayos.Rows.Clear()

				If BuscaEnTablaVieja = False Then

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

							Dim WOperadorID = Trim(OrDefault(.Item("OperadorLabora"), ""))

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

							WResultado = _GenerarImpreResultado(WTipoEspecif, WDesdeEspecif, WHastaEspecif, WUnidadEspecif, WValor)

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


								.Cells("OperadorID").Value = WOperadorID
								.Cells("ValorBandera").Value = .Cells("Valor").Value

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

					'Buscamos las iniciales de el Operario de Laboratorio

					Dim SQLCnslt As String
					For Each row As DataGridViewRow In dgvEnsayos.Rows
						With row
							If Trim(.Cells("OperadorID").Value) <> "" Then

								SQLCnslt = "SELECT Iniciales FROM Operador WHERE Operador = '" & .Cells("OperadorID").Value & "'"
								Dim RowIniciales As DataRow = GetSingle(SQLCnslt, "SurfactanSa")
								If RowIniciales IsNot Nothing Then
									.Cells("OperadorIniciales").Value = RowIniciales.Item("Iniciales")
								End If
							End If
						End With
					Next

					btnGrabar.Enabled = False
					btnGrabar.Text = "ACTUALIZAR"
					
					txtLotePartida.Focus()

				Else

					If WPrueterFarma.Rows.Count = 0 Then Exit Sub

					Dim SQLCnslt As String

					SQLCnslt = "SELECT * FROM PrueArt WHERE Lote = '" & txtPartida.Text & "' And Producto = '" & txtCodigo.Text & "' Order By Prueba"

					Dim row As DataRow = GetSingle(SQLCnslt)

					If row IsNot Nothing Then
						SQLCnslt = "SELECT * FROM EspecificacionesUnifica WHERE Producto = '" & txtCodigo.Text & "'"
						Dim RowEspecifacionesI As DataRow = GetSingle(SQLCnslt, "Surfactan_II")
						SQLCnslt = "SELECT * FROM EspecificacionesUnificaIII WHERE Producto = '" & txtCodigo.Text & "'"
						Dim RowEspecifacionesIII As DataRow = GetSingle(SQLCnslt, "Surfactan_II")

						For i = 1 To 30

							Dim WEnsayo As Integer
							Dim WEspecificacion As String
							Dim WResultado As String

							If i < 21 Then

								If RowEspecifacionesI.Item("Ensayo" & i) <> 0 Then

									WEnsayo = Trim(RowEspecifacionesI.Item("Ensayo" & i))

									WEspecificacion = Trim(RowEspecifacionesI.Item("Valor" & i))

									WResultado = Trim(row.Item("Valor" & i))
									dgvEnsayos.Rows.Add(WEnsayo, WEspecificacion, "", "", "", WResultado)

								End If
							Else

								If RowEspecifacionesIII.Item("Ensayo" & i) <> 0 Then

									WEnsayo = Trim(RowEspecifacionesIII.Item("Ensayo" & i))

									WEspecificacion = Trim(RowEspecifacionesIII.Item("Valor" & i))

									WResultado = Trim(row.Item("Valor" & i))
									dgvEnsayos.Rows.Add(WEnsayo, WEspecificacion, "", "", "", WResultado)

								End If

							End If

						Next

						btnGrabar.Enabled = False

					End If

				End If

				WActualiza = True

			Else
				_CargarEspecificacionesGenerales()
			End If

			_BuscarDescripcionArticulo()

		ElseIf e.KeyData = Keys.Escape Then
			txtEtapa.Text = ""
		End If

	End Sub


	Private Sub _BuscarDescripcionArticulo()
		If txtCodigo.Text.Replace(" ", "").Length < 10 Then : Exit Sub : End If

		Dim WMP As DataRow = GetSingle("SELECT Descripcion FROM Articulo WHERE Codigo = '" & txtCodigo.Text & "'")

		txtDescMP.Text = ""

		If WMP IsNot Nothing Then

			txtDescMP.Text = Trim(OrDefault(WMP.Item("Descripcion"), "")).ToUpper
		End If

	End Sub

	Private Sub _CargarEspecificacionesGenerales()

		Dim WCargaV As DataTable = GetAll("SELECT * FROM CargaVMP WHERE Articulo = '" & txtCodigo.Text & "' And Paso = '99' Order By Clave", "Surfactan_II")

		If WCargaV.Rows.Count = 0 Then Return

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
		Dim WCargaVIngles As DataTable = GetAll("SELECT Valor, UnidadEspecif FROM CargaVMPIngles WHERE Articulo = '" & txtCodigo.Text & "' And Paso = '99' Order By Clave", "Surfactan_II")

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

								'CurrentCell = .Rows(iRow).Cells(iCol + 1)
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

				If .RowIndex + 1 = dgvEnsayos.Rows.Count Then
					txtLibros.Focus()
				End If

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

	Private Sub SoloNumero(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles txtPartida.KeyPress, txtEtapa.KeyPress, txtRevalida.KeyPress, txtEspecifActual.KeyPress, txtEspecifOrig.KeyPress, txtCantidadEtiquetas.KeyPress, txtMeses.KeyPress, txtInforme.KeyPress, txtOrden.KeyPress
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

			Else

				If WIDOperadorAnalista = "" Then

					WMotivoClaveSeguridad = TiposSolicitudClaveSeguridad.ActualizarEnsayoNoBloqueado

					Dim frm As New IngresoClaveSeguridad()
					frm.ShowDialog(Me)

					txtPartida.Focus()

					Exit Sub

				End If

			End If

			WEsPorRechazo = False

			If Not _ValidarValoresIngresados() And Not WEsPorDesvio Then

				Dim WResult As MsgBoxResult = MsgBox("Algunos de los valores indicados, no se encuentran dentro de los valores especificados para esta Materia Prima." & vbCrLf & vbCrLf & vbCrLf & "¿Desea Continuar con la Grabación por Desvío?", MsgBoxStyle.YesNoCancel)

				If WResult = MsgBoxResult.Cancel Then Exit Sub

				WEsPorDesvio = WResult = MsgBoxResult.Yes

				WEsPorRechazo = Not WEsPorDesvio

			End If

			Dim Est As TiposEstadoLaudoMP = TiposEstadoLaudoMP.Aprobado

			If WEsPorDesvio Then Est = TiposEstadoLaudoMP.AprobadoPorDesvio
			If WEsPorRechazo Then Est = TiposEstadoLaudoMP.Rechazado

			If WActualiza = False Then
				txtPartida.Text = MatPrima._TraerProximaNumeracion(Est)
			End If

			WEnvase = ""
			WCert1 = ""
			WCert2 = ""
			WEstado1 = ""
			WEstado2 = ""
			WVenc = ""
			WFechaElab = ""
			WTipoVenc = ""

			WCantidadLaudo = _CalcularSaldoOCInforme()

			'
			' Obtenemos los datos del Informe de Recepción.
			'
			With New ConfirmarTipoCantidadLaudo(Est)
				.txtLaudo.Text = txtPartida.Text
				.txtCantidad.Text = WCantidadLaudo

				Dim result As DialogResult = .ShowDialog(Me)

				If result = DialogResult.OK Then

					If Val(formatonumerico(.txtCantidad.Text)) > Val(formatonumerico(WCantidadLaudo)) Then
						MsgBox("La cantidad a Laudar SUPERA al saldo que se encuentra disponible en el Informe de Recepción indicado." & vbCrLf & vbCrLf & "Saldo disponible (Inf. Recepción): " & formatonumerico(WCantidadLaudo), MsgBoxStyle.Exclamation)
						txtPartida.Text = ""
						Exit Sub
					ElseIf Val(formatonumerico(.txtCantidad.Text)) < Val(formatonumerico(WCantidadLaudo)) Then
						If MsgBox("La cantidad a Laudar es MENOR al saldo que se encuentra disponible en el Informe de Recepción indicado." & vbCrLf & vbCrLf & "Saldo disponible (Inf. Recepción): " & formatonumerico(WCantidadLaudo) & vbCrLf & vbCrLf & "¿Desea seguir con la grabación?", MsgBoxStyle.YesNoCancel) <> MsgBoxResult.Yes Then
							txtPartida.Text = ""
							Exit Sub
						End If
					End If

					txtPartida.Text = .txtLaudo.Text
					WCantidadLaudo = formatonumerico(.txtCantidad.Text)
					WEsPorDesvio = .rbPorDesvio.Checked
					WEsPorRechazo = .rbRechazado.Checked
				Else
					txtPartida.Text = ""
					Exit Sub
				End If

			End With

			Dim WSqls As New List(Of String)

			'
			' Preparamos la grabación en el Formato Viejo.
			'
			WSqls.AddRange(_PrepararGrabacionFormatoViejo)

			_CrearCarpetaEtapaIntermedia()

			Dim WPartida = txtPartida.Text
			Dim WCodigo = txtCodigo.Text
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

			Dim WEsUnaActualizacion As Boolean

			Dim WTabla As String = "PrueArtNuevo"

			Dim WPruartNuevo As DataRow

			WPruartNuevo = GetSingle("SELECT TOP 1 Clave FROM PrueArtNuevo WHERE LotePartida = '" & WPartida & "' And Producto = '" & WCodigo & "'")

			WEsUnaActualizacion = WPruartNuevo Is Nothing

			If WEsUnaActualizacion Then

				WSqls.Add("DELETE FROM PrueArtNuevo WHERE LotePartida = '" & WPartida & "' And Producto = '" & WCodigo & "'")

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

						Dim WFormulas(10, 2) As String

						For i = 1 To 10
							WFormulas(i, 1) = Trim(OrDefault(.Cells("Variable" & i).Value, ""))
							WFormulas(i, 2) = Trim(OrDefault(.Cells("VariableValor" & i).Value, "")).Replace(",", ".")
						Next

						Dim WOperadorLabora As String = WIDOperadorAnalista

						WResultado = _GenerarImpreResultado(WTipoEspecif, WDesdeEspecif, WHastaEspecif, WUnidadEspecif, WValor)

						WRenglon += 1

						Dim WClave = "1" & WCodigo & txtPartida.Ceros(6) & WRenglon.Ceros(2)
						Dim ZSql = ""

						ZSql = ZSql & "INSERT INTO " & WTabla & " ("
						ZSql = ZSql & "Clave ,"
						ZSql = ZSql & "Tipo ,"
						ZSql = ZSql & "Prueba ,"
						ZSql = ZSql & "LotePartida ,"
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
						ZSql = ZSql & "'" & "1" & "',"
						ZSql = ZSql & "'" & WPartida.left(6) & "',"
						ZSql = ZSql & "'" & WPartida.left(6) & "',"
						ZSql = ZSql & "'" & WRenglon.left(2) & "',"
						ZSql = ZSql & "'" & WCodigo.left(10) & "',"
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
								ZSql = ZSql & "'" & Trim(.Cells("OperadorID").Value) & "')"
							End If
						Else
							ZSql = ZSql & "'" & WLiberada & "',"
							ZSql = ZSql & "'" & Trim(.Cells("OperadorID").Value) & "')"
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
							  "CantiEti = '" & txtCantidadEtiquetas.Text.Trim & "'" &
							  " WHERE LotePartida = '" & WPartida & "' And Producto = '" & WCodigo & "' "
							  )
				End With

			Else

				WRenglon = 0

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

						Dim WFormulas(10, 2) As String

						For i = 1 To 10
							WFormulas(i, 1) = Trim(OrDefault(.Cells("Variable" & i).Value, ""))
							WFormulas(i, 2) = Trim(OrDefault(.Cells("VariableValor" & i).Value, "")).Replace(",", ".")
						Next

						Dim WOperadorLabora As String = WIDOperadorAnalista

						WResultado = _GenerarImpreResultado(WTipoEspecif, WDesdeEspecif, WHastaEspecif, WUnidadEspecif, WValor)

						WRenglon += 1

						Dim WClave = "1" & WCodigo & txtPartida.Ceros(6) & WRenglon.Ceros(2)

						Dim ZSql As String = ""
						ZSql = ZSql & "UPDATE " & WTabla & " SET "
						ZSql = ZSql & "Clave ='" & WClave & "',"
						ZSql = ZSql & "Tipo = '" & "1" & "',"
						ZSql = ZSql & "LotePartida = '" & WPartida.left(6) & "',"
						ZSql = ZSql & "Renglon = '" & WRenglon.left(2) & "',"
						ZSql = ZSql & "Producto = '" & WCodigo.left(10) & "',"
						ZSql = ZSql & "Fecha = '" & WFecha & "',"
						ZSql = ZSql & "FechaOrd = '" & WFechaOrd & "',"
						ZSql = ZSql & "Codigo = '" & WEns & "',"
						ZSql = ZSql & "Valor = '" & WEspecificacion.left(50) & "',"
						ZSql = ZSql & "Resultado = '" & WResultado.left(50) & "',"
						ZSql = ZSql & "Observaciones = '" & WObservaciones.left(100) & "',"
						ZSql = ZSql & "ValorReal = '" & WValor.left(10) & "',"
						ZSql = ZSql & "TipoEspecif = '" & WTipoEspecif.left(1) & "',"
						ZSql = ZSql & "InformaEspecif = '" & WInformaEspecif.left(1) & "',"
						ZSql = ZSql & "MenorIgualEspecif = '" & WMenorIgualEspecif.left(1) & "',"
						ZSql = ZSql & "UnidadEspecif = '" & WUnidadEspecif.left(20) & "',"
						ZSql = ZSql & "DesdeEspecif = '" & WDesdeEspecif.left(10) & "',"
						ZSql = ZSql & "HastaEspecif = '" & WHastaEspecif.left(10) & "',"
						ZSql = ZSql & "Farmacopea = '" & WFarmacopea.left(10) & "',"
						ZSql = ZSql & "PorDesvio = '" & WPorDesvio.left(1) & "',"
						ZSql = ZSql & "MotivoDesvio = '" & WMotivoDesvio.left(100) & "',"
						ZSql = ZSql & "NroDesvio = '" & WNroDesvio.left(10) & "',"
						ZSql = ZSql & "Libros = '" & WLibros.left(20) & "',"
						ZSql = ZSql & "Archiva = '" & WArchivo.left(30) & "',"
						ZSql = ZSql & "NroOOS = '" & WNroOOS.left(10) & "',"
						ZSql = ZSql & "Paginas = '" & WPaginas.left(20) & "',"
						ZSql = ZSql & "Estado = '" & "1" & "',"
						ZSql = ZSql & "Confecciono = '" & WConfecciono.left(50) & "',"
						ZSql = ZSql & "Impre1 = '" & WParametro.left(100) & "',"
						ZSql = ZSql & "Impre2 = '" & WTipoProceso.left(100) & "',"
						ZSql = ZSql & "FormulaEspecif = '" & WFormulaEspecif & "',"

						For i = 1 To 10
							ZSql = ZSql & "Variable" & i & " = '" & WFormulas(i, 1) & "',"
							ZSql = ZSql & "VariableValor" & i & " = '" & WFormulas(i, 2) & "',"
						Next

						If WNoGrabaIniciales = False Then
							If WValorBandera <> WValor Then
								ZSql = ZSql & "Liberada = '" & WLiberada & "',"
								ZSql = ZSql & "OperadorLabora = '" & WOperadorLabora & "' "
							Else
								ZSql = ZSql & "Liberada = '" & WLiberada & "',"
								ZSql = ZSql & "OperadorLabora = '" & Trim(.Cells("OperadorID").Value) & "' "
							End If
						Else
							ZSql = ZSql & "Liberada = '" & WLiberada & "',"
							ZSql = ZSql & "OperadorLabora = '" & Trim(.Cells("OperadorID").Value) & "' "
						End If

						ZSql = ZSql & "WHERE LotePartida = '" & WPartida & "' And Producto = '" & WCodigo & "' And Renglon = '" & WRenglon & "'"

						WSqls.Add(ZSql)

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
									  "CantiEti = '" & txtCantidadEtiquetas.Text.Trim & "'" &
									  " WHERE LotePartida = '" & WPartida & "' And Producto = '" & WCodigo & "' "
									  )
						End With
					End With
				Next

			End If

			ExecuteNonQueries(WSqls.ToArray)

			If WEsPorDesvio Or WEsPorRechazo Then
				With New AltaMotivoINCMP()
					.TipoResponsableBloqueados = True
					.Orden = txtOrden.Text
					.Lote = txtPartida.Text
					.LotePrv = txtLoteProveedor.Text
					.Codigo = txtCodigo.Text
					.Empresa = IDBase
					.Fecha = txtFecha.Text
					.NumeroINC = "0"
					.ShowDialog(Me)
				End With
			End If

			' todo implementar impresiones.
			
			btnLimpiar.PerformClick()

			txtCodigo.Focus()

		Catch ex As Exception
			MsgBox(ex.Message, MsgBoxStyle.Exclamation)
		End Try

	End Sub

	Private Function _CalcularSaldoOCInforme() As String
		Dim WLaudado, WInformado As Double
		WLaudado = 0
		WInformado = 0

		Dim WInf As DataRow = GetSingle("SELECT Total = SUM(Cantidad) FROM Informe WHERE Orden = '" & txtOrden.Text & "' And Articulo = '" & txtCodigo.Text & "' GROUP BY Orden, Articulo")
		If WInf IsNot Nothing Then WInformado = OrDefault(WInf.Item("Total"), 0)

		Dim WOrden As DataRow = GetSingle("SELECT Total = SUM(Liberada + Devuelta) FROM Laudo WHERE Orden = '" & txtOrden.Text & "' And Articulo = '" & txtCodigo.Text & "'")
		If WOrden IsNot Nothing Then WLaudado = OrDefault(WOrden.Item("Total"), 0)

		Return formatonumerico(WInformado - WLaudado)
	End Function

	Private Function _EsProveedorA() As Boolean
		Dim WProv As DataRow = GetSingle("SELECT p.CategoriaI FROM Orden o INNER JOIN SurfactanSa.dbo.Proveedor p ON o.Proveedor = p.Proveedor And o.Renglon = 1 WHERE o.Orden = '" & txtOrden.Text & "'")

		If WProv Is Nothing Then
			Throw New Exception("No se ha encontrado el Proveedor Vinculado a la Orden de Compra indicada.")
		End If

		Return Val(OrDefault(WProv.Item("CategoriaI"), "")) = 1
	End Function

	Private Function _PrepararGrabacionFormatoViejo() As IEnumerable(Of String)
		Dim WSqls As New List(Of String)

		WSqls.Add(_PrepararGrabacionPruArt)
		WSqls.AddRange(_PrepararGrabacionLaudo)
		WSqls.AddRange(_PrepararActualizacionSaldos)
		WSqls.AddRange(_PrepararGrabacionTraslados)

		Return WSqls
	End Function

	Private Function _PrepararGrabacionTraslados() As IEnumerable(Of String)
		Dim WSqls As New List(Of String)

		'
		' La grabación se lleva a cabo unicamente si se liberó (inclusive por Desvío).
		'
		If WEsPorRechazo Then Return WSqls

		'
		' Buscamos si tiene un destino diferente a la empresa en la que se está trabajando.
		'
		Dim WOrden As DataRow = GetSingle("SELECT Destino FROM Orden WHERE Orden = '" & txtOrden.Text & "' And Articulo = '" & txtCodigo.Text & "'")
		Dim WDestino As Integer = 0

		If WOrden IsNot Nothing Then WDestino = Val(OrDefault(WOrden.Item("Destino"), ""))

		If WDestino = 0 OrElse WDestino = Util.Clases.Helper._IdEmpresaSegunBase(Base) Then Return WSqls

		'
		' Busco próxima guía.
		'
		Dim WUltGuia As DataRow = GetSingle("SELECT Ultima = MAX(Codigo) FROM Guia WHERE TipoMov = '0'")
		Dim WCodigoGuia As String = "1"

		If WUltGuia IsNot Nothing Then WCodigoGuia = Val(OrDefault(WUltGuia.Item("Ultima"), "")) + 1

		WCantidadLaudo = formatonumerico(WCantidadLaudo)

		'
		' Graba Guia en Planta de Origen.
		'
		WSqls.Add(String.Format("INSERT INTO Guia (Clave, TipoMov, Codigo, Renglon, Fecha, Tipo, Articulo, Terminado, Cantidad, FechaOrd, Movi, Observaciones, Marca, Destino, Lote, Saldo, Partida, PartiOri, Transito, Orden, Descontar) VALUES " &
								"('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}', '{13}', '{14}', '{15}', '{16}', '{17}', '{18}', '{19}', '{20}')",
								"0" & WCodigoGuia.Ceros(6) & "01", "00", WCodigoGuia, "1", txtFecha.Text, "M", txtCodigo.Text, "  -     -   ", WCantidadLaudo, ordenaFecha(txtFecha.Text), "S", "Traslado de MP", "", WDestino, "0", "0", txtPartida.Text, "", "", "", ""))

		'
		' Actualizo las Salidas de la Ficha de MP.
		'
		WSqls.Add(String.Format("UPDATE Articulo SET Salidas = Salidas - {0} WHERE Codigo = '{1}'", WCantidadLaudo, txtCodigo.Text))

		'
		' Actualizo Saldo del Laudo de la MP.
		'
		WSqls.Add(String.Format("UPDATE Laudo SET Saldo = 0 WHERE Laudo = '{0}'", txtPartida.Text))

		'
		' Graba Guia en Planta de Destino.
		'
		Dim WEmpDestino As String = Conexion.DeterminarSegunIDIDBasePara(WDestino)

		WSqls.Add(String.Format("INSERT INTO {21}.dbo.Guia (Clave, TipoMov, Codigo, Renglon, Fecha, Tipo, Articulo, Terminado, Cantidad, FechaOrd, Movi, Observaciones, Marca, Destino, Lote, Saldo, Partida, PartiOri, Transito, Orden, Descontar) VALUES " &
								"('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}', '{13}', '{14}', '{15}', '{16}', '{17}', '{18}', '{19}', '{20}')",
								WDestino & WCodigoGuia.Ceros(6) & "01", WDestino.Ceros(2), WCodigoGuia, "1", txtFecha.Text, "M", txtCodigo.Text, "  -     -   ", WCantidadLaudo, ordenaFecha(txtFecha.Text), "E", "Traslado de MP", "", "0", txtPartida.Text, WCantidadLaudo, "0", "", "", "", "", WEmpDestino))

		'
		' Actualizo las Entradas de la Ficha de MP.
		'
		WSqls.Add(String.Format("UPDATE Articulo SET Entradas = Entradas + {0} WHERE Codigo = '{1}'", WCantidadLaudo, txtCodigo.Text))

		Return WSqls
	End Function

	Private Function _PrepararActualizacionSaldos() As IEnumerable(Of String)
		Dim WSQls As New List(Of String)

		'
		' Buscamos los datos de la Orden de Compra.
		'
		Dim WOrden As DataRow = GetSingle("SELECT o.Tipo, o.Moneda, o.Precio, a.Costo1, a.Costo3 ,a.WCosto1, a.WCosto3 FROM Orden o INNER JOIN Articulo a ON a.Codigo = o.Articulo WHERE o.Orden = '" & txtOrden.Text & "' And o.Articulo = '" & txtCodigo.Text & "'")

		Dim WTipoOrden, WMoneda, WPrecio As String

		WTipoOrden = ""
		WMoneda = ""
		WPrecio = ""

		If WOrden IsNot Nothing Then
			With WOrden
				WTipoOrden = OrDefault(.Item("Tipo"), "0")
				WMoneda = OrDefault(.Item("Moneda"), "0")
				WPrecio = OrDefault((.Item("Precio")).ToString().Replace(",", "."), "0")
			End With
		End If

		'
		' Actualizo las Entradas en Ficha de MP.
		'
		If Not WEsPorRechazo Then WSQls.Add("UPDATE Articulo SET Entradas = Entradas + " & formatonumerico(WCantidadLaudo) & " WHERE Codigo = '" & txtCodigo.Text & "'")

		'
		' Actualizo el Stock que se encuentra en laboratorio.
		'
		WSQls.Add("UPDATE Articulo SET Laboratorio = Laboratorio - " & formatonumerico(WCantidadLaudo) & " WHERE Codigo = '" & txtCodigo.Text & "'")

		Select Case Val(WTipoOrden)
			Case 1, 2
				'
				' Por mas que hayan entrado por Orden 1 y 2, actualizamos los datos de las Fichas de MP únicamente si es Tipo Orden = 1.
				'
				If Val(WTipoOrden) = 1 Then
					For Each e As String In Conexion.Empresas
						Dim empreID = Util.Clases.Helper._IdEmpresaSegunBase(e)
						WSQls.Add(String.Format("UPDATE {3}.dbo.Articulo SET PtaOrdenI = '{1}', OrdenI = '{2}' WHERE Codigo = '{0}'", txtCodigo.Text, empreID, txtOrden.Text, e))
					Next
				End If
			Case Else
				'
				' Actualizo los costos de la Ficha de MP.
				'
				Dim WCampoI, WCampoII, WCampoIII As String

				If Val(WMoneda) = 0 Then
					WCampoI = "ZCosto1"
					WCampoII = "OrdenII"
					WCampoIII = "PtaOrdenII"
				Else
					WCampoI = "WCosto1"
					WCampoII = "OrdenIII"
					WCampoIII = "PtaOrdenIII"
				End If

				For Each e As String In Conexion.Empresas
					Dim empreID = Util.Clases.Helper._IdEmpresaSegunBase(e)
					WSQls.Add(String.Format("UPDATE {3}.dbo.Articulo SET {4} = '{1}', {5} = '{2}', {6} = '{7}' WHERE Codigo = '{0}'",
											txtCodigo.Text, empreID, txtOrden.Text, e, WCampoII, WCampoIII, WCampoI, WPrecio))
				Next

		End Select

		Return WSQls
	End Function

	Private Function _PrepararGrabacionLaudo() As String()
		Dim WSqls As New List(Of String)

		Dim WClave, WSaldo, WOrigen, WInforme, WPrueba, WFecha, WOrden, WLiberada, WDevuelta, WLote, WRechazo, WFechaOrd, WLaudoOriginal, WPartiOri As String
		WOrigen = ""
		WPrueba = txtPartida.Text.Ceros(6)

		WFecha = txtFecha.Text
		WOrden = txtOrden.Text
		WInforme = txtInforme.Text
		WLote = txtPartida.Text
		WRechazo = IIf(WEsPorRechazo, txtPartida.Text, "")
		WPartiOri = txtLoteProveedor.Text
		WFechaOrd = ordenaFecha(WFecha)

		WClave = WPrueba & "01"

		If Not WEsPorRechazo Then
			WDevuelta = ""
			WLiberada = WCantidadLaudo
		Else
			WDevuelta = WCantidadLaudo
			WLiberada = ""
		End If

		'
		' Determinar Laudo Original en caso de los DY.
		'
		WLaudoOriginal = _TraerLaudoOriginal()

		' En el caso de los DY, el saldo se acumula en el Primer Laudo.
		WSaldo = IIf(Val(WLaudoOriginal) > 0, "0", WLiberada)

        WSqls.Add(String.Format("INSERT INTO Laudo (Clave, Laudo, Renglon, Fecha, Articulo, Liberada, Devuelta, Orden, Marca, Lote, Rechazo, Informe, Actualiza, WDate, Saldo, Origen, PartiOri, Envase) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}', '{13}', '{14}', '{15}', '{16}', '{17}' )",
                             WClave, WPrueba, "1", txtFecha.Text, txtCodigo.Text, WLiberada, WDevuelta, WOrden, "", WLote, WRechazo, WInforme, "N", Date.Now.ToString("MM-dd-yyyy"), WSaldo, WOrigen, WPartiOri, WEnvase))

		WSqls.Add(String.Format("UPDATE Laudo SET NroDespacho = '{0}', FechaVencimiento = '{1}', TipoVencimiento = '{2}', FechaElaboracion = '{3}', OrdFechaVencimiento = '{4}', Procedencia = '{6}', FechaOrd = '{7}' WHERE Laudo = '{5}'", WNroDespacho, WVenc, WTipoVenc, WFechaElab, ordenaFecha(WVenc), txtPartida.Text, WProcedencia, WFechaOrd))

		'
		' Actualizo los datos del Informe de Recepción.
		'
		WSqls.Add(String.Format("UPDATE Informe SET Certificado1 = '{0}', Certificado2 = '{1}', Estado1 = '{2}', Estado2 = '{3}', FechaVencimiento = '{4}', TipoVencimiento = '{5}', FechaElaboracion = '{6}', OrdFechaVencimiento = '{7}' WHERE Informe = '{8}' And Orden = '{9}' And Articulo = '{10}'",
								WCert1, WCert2, WEstado1, WEstado2, WVenc, WTipoVenc, WFechaElab, ordenaFecha(WVenc), txtInforme.Text, txtOrden.Text, txtCodigo.Text))

		'
		' Actualizo el Saldo del Lote Original del DY.
		'
		If Val(WLaudoOriginal) > 0 AndAlso Not WEsPorRechazo Then WSqls.Add("UPDATE Laudo SET Saldo = Saldo + " & WLiberada & " WHERE Laudo = '" & WLaudoOriginal & "'")

		Return WSqls.ToArray
	End Function

	Private Function _TraerLaudoOriginal() As String
		Dim WLaudoOriginal As String

		WLaudoOriginal = ""

		'
		' Comprobamos que sea un DY.
		'
		If txtCodigo.Text.StartsWith("DY") Then
			Dim DY As DataRow = GetSingle("SELECT Laudo FROM Laudo WHERE PartiOri = '" & txtLoteProveedor.Text & "' And Articulo = '" & txtCodigo.Text & "' ORDER BY Laudo")
			If DY IsNot Nothing Then WLaudoOriginal = Trim(OrDefault(DY.Item("Laudo"), ""))
		End If
		Return WLaudoOriginal
	End Function

	Private Function _PrepararGrabacionPruArt() As String
		Dim WPrueba, WProducto, WFecha, WOrden, WEnsayo, WAspecto, WObservaciones, WObserva2, WConfecciono, WLiberada, WDevuelta, WLote, WRechazo, WNueva, WFechaOrd, WDate As String

		WPrueba = IIf(WEsPorRechazo, "2", "1")
		WPrueba &= txtPartida.Text.Ceros(6)

		WProducto = txtCodigo.Text
		WFecha = txtFecha.Text
		WOrden = txtOrden.Text
		WEnsayo = ""
		WAspecto = ""
		WObservaciones = ""
		WObserva2 = ""
		WConfecciono = txtConfecciono.Text.Trim.ToUpper
		WLote = txtPartida.Text
		WRechazo = IIf(WEsPorRechazo, txtPartida.Text, "")
		WNueva = ""
		WFechaOrd = ordenaFecha(WFecha)
		WDate = Date.Now.ToString("MM-dd-yyyy")

		If Not WEsPorRechazo Then
			WDevuelta = ""
			WLiberada = WCantidadLaudo
		Else
			WDevuelta = WCantidadLaudo
			WLiberada = ""
		End If

		Dim WColumnas, WValores As String

		WColumnas = ""
		WValores = ""

		For i = 1 To dgvEnsayos.Rows.Count

			WColumnas &= "Valor" & i & ","
			WColumnas &= "ValorNumero" & i & ","

			With dgvEnsayos.Rows(i - 1)
				WValores &= "'" & .Cells("Resultado").Value & "',"
				WValores &= "'" & .Cells("Valor").Value & "',"
			End With

		Next

		For i = dgvEnsayos.Rows.Count + 1 To 30

			WColumnas &= "Valor" & i & ","
			WColumnas &= "ValorNumero" & i & ","

			WValores &= "'','',"

		Next

		WValores = WValores.TrimEnd(",")
		WColumnas = WColumnas.TrimEnd(",")

		If WActualiza = False Then
			Return String.Format("INSERT INTO PrueArt (Prueba, Producto, Fecha, Orden, Ensayo, Aspecto, Observaciones, Observa2, Confecciono, Liberada, Devuelta, Lote, Rechazo, Nueva, FechaOrd, WDate, {0}) VALUES ('{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}', '{13}', '{14}', '{15}', '{16}', {17})",
							 WColumnas, WPrueba, WProducto, WFecha, WOrden, WEnsayo, WAspecto, WObservaciones, WObserva2, WConfecciono, WLiberada, WDevuelta, WLote, WRechazo, WNueva, WFechaOrd, WDate, WValores)
		Else
			Dim SQLCnslt As String = "UPDATE PrueArt  SET Prueba = '" & WPrueba & "',"
			SQLCnslt = SQLCnslt & "Producto = '" & WProducto & "', "
			SQLCnslt = SQLCnslt & "Fecha = '" & WFecha & "', "
			SQLCnslt = SQLCnslt & "Orden = '" & WOrden & "', "
			SQLCnslt = SQLCnslt & "Ensayo = '" & WEnsayo & "', "
			SQLCnslt = SQLCnslt & "Aspecto = '" & WAspecto & "', "
			SQLCnslt = SQLCnslt & "Observaciones = '" & WObservaciones & "', "
			SQLCnslt = SQLCnslt & "Observa2 = '" & WObserva2 & "', "
			SQLCnslt = SQLCnslt & "Confecciono = '" & WConfecciono & "', "
			SQLCnslt = SQLCnslt & "Liberada = '" & WLiberada & "', "
			SQLCnslt = SQLCnslt & "Devuelta = '" & WDevuelta & "', "
			SQLCnslt = SQLCnslt & "Lote = '" & WLote & "', "
			SQLCnslt = SQLCnslt & "Rechazo = '" & WRechazo & "', "
			SQLCnslt = SQLCnslt & "Nueva = '" & WNueva & "', "
			SQLCnslt = SQLCnslt & "FechaOrd = '" & WFechaOrd & "', "
			SQLCnslt = SQLCnslt & "WDate = '" & WDate & "', "

			For i = 1 To dgvEnsayos.Rows.Count
				With dgvEnsayos.Rows(i - 1)
					SQLCnslt = SQLCnslt & "Valor" & i & " = '" & .Cells("Resultado").Value & "', "
					SQLCnslt = SQLCnslt & "ValorNumero" & i & " = '" & .Cells("Valor").Value & "', "
				End With

			Next

			For i = dgvEnsayos.Rows.Count + 1 To 30

				SQLCnslt = SQLCnslt & "Valor" & i & " = '', "
				SQLCnslt = SQLCnslt & "ValorNumero" & i & " = '',"

			Next

			SQLCnslt = SQLCnslt.TrimEnd(",")

			SQLCnslt = SQLCnslt & " WHERE Lote = '" & txtLotePartida.Text & "' And Producto = '" & txtCodigo.Text & "' "

			Return SQLCnslt
		End If
	End Function

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

		'
		' Se realizan las validaciones únicamente para aquellos Proveedores que no tengan calificación "A" y el Articulo a laudar no es un DQ.
		'
		If _EsProveedorA() Or txtCodigo.Text.left(2).ToUpper = "DQ" Then Return True

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
		If txtCodigo.Text.Replace(" ", "").Length < 10 Then Throw New Exception("No se ha cargado un Código de Producto Terminado válido.")
		If txtLibros.Text.Trim = "" Then Throw New Exception("No se ha informado la información de Libros correspondiente.")
		If txtPaginas.Text.Trim = "" Then Throw New Exception("No se ha informado la información de Páginas correspondiente.")
		If txtConfecciono.Text.Trim = "" Then Throw New Exception("No se ha informado quién Confecciona el ingreso de Ensayos.")

		'
		' Verificamos Datos Ingresados.
		'
		Dim WTerminado As DataRow = GetSingle("SELECT Codigo FROM Articulo WHERE Codigo = '" & txtCodigo.Text & "'")
		If WTerminado Is Nothing Then Throw New Exception("El Código de Materia Prima no es válida.")

		Dim WInforme As DataRow = GetSingle("SELECT Articulo FROM Informe WHERE Informe = '" & txtInforme.Text & "' And Renglon in ('1', '01')")
		If WInforme Is Nothing Then Throw New Exception("El Informe indicado es Inexistente.")

		Dim WOrden As DataRow = GetSingle("SELECT Articulo FROM Informe WHERE Informe = '" & txtInforme.Text & "' And Renglon in ('1', '01')")
		If WOrden Is Nothing Then Throw New Exception("La Orden de Compra indicada es Inexistente.")

		Dim WInformeOrden As DataRow = GetSingle("SELECT Articulo FROM Informe WHERE Informe = '" & txtInforme.Text & "' And Orden = '" & txtOrden.Text & "' And Renglon in ('1', '01')")
		If WInformeOrden Is Nothing Then Throw New Exception("El informe indicado no se corresponde con la Orden de Compra.")

		Dim WInformeArticulo As DataRow = GetSingle("SELECT Articulo FROM Informe WHERE Informe = '" & txtInforme.Text & "' And Articulo = '" & txtCodigo.Text & "'")
		If WInformeArticulo Is Nothing Then Throw New Exception("La Materia Prima no se encuentra dentro del Informe de Recepción indicado.")

		'
		' Verificamos si se ha grabado anteriormente por Desvio, en este caso se considera Bloqueado e imposible de ser actualizado por este medio.
		'
		Dim WDesvio As DataRow = GetSingle("SELECT TOP 1 PorDesvio, NroDesvio FROM PrueArtNuevo WHERE Producto = '" & txtCodigo.Text & "' AND Prueba = '" & txtPartida.Text & "'  And Renglon = 1")

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
		Dim WDatos As DataTable = GetAll("SELECT ValorReal FROM PrueArtNuevo WHERE Producto = '" & txtCodigo.Text & "' AND Prueba = '" & txtPartida.Text & "' ORDER BY Clave")

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

			Case TiposSolicitudClaveSeguridad.ActualizarEnsayoNoBloqueado

				Dim WDatos As DataRow = GetSingle("SELECT Operador, AnalistaLab FROM Operador WHERE Clave = '" & UCase(WClave) & "'", "SurfactanSa")

				If WDatos IsNot Nothing Then
					Dim AnalistasLabPermiso As String = OrDefault(WDatos.Item("AnalistaLab"), "")
					If AnalistasLabPermiso.ToUpper = "S" Then
						WIDOperadorAnalista = WDatos.Item("Operador")
						btnGrabar.PerformClick()
						Exit Sub
					End If
				End If

				MsgBox("Clave Incorrecta")

			Case Else
				MsgBox("Clave Incorrecta")
        End Select

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
                Dim WInformaEspecif = OrDefault(.Item("InformaEspecif"), "")
                Dim WValor = Trim(OrDefault(.Item("Valor"), ""))
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

	Private Sub btnImprimirEnsayosIngresados_Click_1(ByVal sender As Object, ByVal e As EventArgs) Handles btnImprimirEnsayosIngresados.Click
		With New PDFVersionesPTFarma(txtPartida.Text)
			.ShowDialog(Me)
		End With
	End Sub

	Private Sub txtCodigo_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCodigo.KeyDown

		If e.KeyData = Keys.Enter Then
			If txtCodigo.Text.Replace(" ", "").Length < 10 Then : Exit Sub : End If

			Dim WMP As DataRow = GetSingle("SELECT Descripcion FROM Articulo WHERE Codigo = '" & txtCodigo.Text & "'")

			txtDescMP.Text = ""

			If WMP IsNot Nothing Then

				txtDescMP.Text = Trim(OrDefault(WMP.Item("Descripcion"), "")).ToUpper

				_CargarEspecificacionesGenerales()

			End If

			txtOrden.Focus()

		ElseIf e.KeyData = Keys.Escape Then
			txtCodigo.Text = ""
		End If

	End Sub

	Private Sub txtOrden_KeyDown(sender As Object, e As KeyEventArgs) Handles txtOrden.KeyDown

		If e.KeyData = Keys.Enter Then
			If Val(txtOrden.Text) = 0 Then : Exit Sub : End If

			Dim WOrden As DataRow = GetSingle("SELECT Recibida, Origen FROM Orden WHERE Orden = '" & txtOrden.Text & "' And Articulo = '" & txtCodigo.Text & "'")

			If WOrden IsNot Nothing Then

				If OrDefault(WOrden.Item("Recibida"), 0) = 0 Then
					MsgBox("No hay ningún Informe de Recepción que haga referencia a esta Orden de Compra para la Materia Prima indicada.", MsgBoxStyle.Exclamation)
					Exit Sub
				End If

				txtInforme.Focus()
			End If

		ElseIf e.KeyData = Keys.Escape Then
			txtOrden.Text = ""
		End If

	End Sub

	Private Sub txtInforme_KeyDown(sender As Object, e As KeyEventArgs) Handles txtInforme.KeyDown

		If e.KeyData = Keys.Enter Then
			If Val(txtInforme.Text) = 0 Then : Exit Sub : End If
			If Val(txtOrden.Text) = 0 Then : Exit Sub : End If

			Dim WInforme As DataRow = GetSingle("SELECT i.* FROM Informe i WHERE i.Informe = '" & txtInforme.Text & "' And i.Orden = '" & txtOrden.Text & "' And i.Articulo = '" & txtCodigo.Text & "'")

			WNroDespacho = ""
			WProcedencia = ""

			If WInforme IsNot Nothing Then
				WNroDespacho = Trim(OrDefault(WInforme.Item("NroDespacho"), ""))
				WProcedencia = Trim(OrDefault(WInforme.Item("Procedencia"), ""))

				With WInforme
					WEnvase = Trim(OrDefault(.Item("Envase"), ""))
					WCert1 = Trim(OrDefault(.Item("Certificado1"), "0"))
					WCert2 = Trim(OrDefault(.Item("Certificado2"), ""))
					WEstado1 = Trim(OrDefault(.Item("Estado1"), "0"))
					WEstado2 = Trim(OrDefault(.Item("Estado2"), ""))
					WVenc = Trim(OrDefault(.Item("FechaVencimiento"), "  /  /    "))
					WFechaElab = Trim(OrDefault(.Item("FechaElaboracion"), "  /  /    "))
					WTipoVenc = Trim(OrDefault(.Item("TipoVencimiento"), "0"))
				End With

				With New ActualizacionDetallesCertAnalisisYEstadoEnvases

					.rbSiCertificadoAnalisis.Checked = Val(WCert1) = 1
					.rbSiEstadoEnvases.Checked = Val(WEstado1) = 1
					.txtCertificado2.Text = WCert2.Trim
					.txtEstado2.Text = WEstado2.Trim
					.cmbTipoVencimiento.SelectedIndex = Val(WTipoVenc)
					.txtFechaVencimiento.Text = WVenc
					.txtFechaElaboracion.Text = WFechaElab

					Dim WResult As DialogResult = .ShowDialog(Me)

					If WResult = DialogResult.OK Then
						WCert1 = IIf(.rbSiCertificadoAnalisis.Checked, "1", "0")
						WEstado1 = IIf(.rbSiEstadoEnvases.Checked, "1", "0")
						WCert2 = .txtCertificado2.Text.Trim
						WEstado2 = .txtEstado2.Text.Trim
						WTipoVenc = .cmbTipoVencimiento.SelectedIndex
						WVenc = .txtFechaVencimiento.Text
						WFechaElab = .txtFechaElaboracion.Text
					End If

				End With

				txtLoteProveedor.Focus()
			End If

		ElseIf e.KeyData = Keys.Escape Then
			txtInforme.Text = ""
		End If

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
                txtOOS.Focus()
            Case Keys.Escape
                txtEnvases.Text = ""
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



    Private Sub txtCantidadEtiquetas_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCantidadEtiquetas.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                txtArchivo.Focus()
            Case Keys.Escape
                txtCantidadEtiquetas.Text = ""
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

    Private Sub txtConfecciono_KeyDown(sender As Object, e As KeyEventArgs) Handles txtConfecciono.KeyDown
        Select Case e.KeyData
            Case Keys.Escape
                txtConfecciono.Text = ""
        End Select
    End Sub

    Private Sub txtLoteProveedor_KeyDown(sender As Object, e As KeyEventArgs) Handles txtLoteProveedor.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                '
                ' Saltar a la grilla
                '
                With dgvEnsayos
                    If .Rows.Count > 0 Then
                        .CurrentCell = .Rows(0).Cells("Valor")
                        .Focus()
                    End If
                End With
            Case Keys.Escape
                txtLoteProveedor.Text = ""
        End Select
	End Sub

    Private Sub btnConsulta_Click(sender As Object, e As EventArgs) Handles btnConsulta.Click

        Dim WDatos As DataTable = GetAll("SELECT ptf.Fecha, ptf.Lote as LotePartida, ptf.Producto As Codigo, a.Descripcion FROM PrueArt ptf INNER JOIN Articulo a ON a.Codigo = ptf.Producto ORDER BY ptf.FechaOrd DESC, ptf.Lote DESC")
        With New AyudaPruebasAnteriores(WDatos)
            .ShowDialog(Me)
        End With
    End Sub

    Public Sub _ProcesarAyudaPruebasAnteriores(LotePartida As String) Implements IAyudaPruebasAnteriores._ProcesarAyudaPruebasAnteriores
        txtPartida.Text = LotePartida
        txtPartida_KeyDown(Nothing, New KeyEventArgs(Keys.Enter))
        txtEtapa.Text = "99"
        txtEtapa_KeyDown(Nothing, New KeyEventArgs(Keys.Enter))
    End Sub

End Class