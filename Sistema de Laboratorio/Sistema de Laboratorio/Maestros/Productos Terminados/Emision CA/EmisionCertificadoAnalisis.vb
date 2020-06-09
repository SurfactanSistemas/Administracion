Imports Util
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports Laboratorio.Entidades

Public Class EmisionCertificadoAnalisis : Implements IAyudaGeneral

    Private ReadOnly WDescParametrosIngles As New Dictionary(Of String, String) From {{"Menor a", "Less than"}, {"Mayor a", "Greater than"}, {"Máximo", "Maximum"}, {"Mínimo", "Minimum"}, {"Informativo", "Informative"}, {"Cumple Ensayo", "Conform to test"}, {"Cumple", "Complies"}}

    Private Sub btnLimpiar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnLimpiar.Click
        For Each c As Control In {txtCliente, txtPartida, txtCantidad, lblDescCliente, lblDescProducto, lblDescProductocliente, lblTerminado}
            c.Text = ""
        Next
        cmbIdioma.SelectedIndex = 0
        cmbTipoSalida.SelectedIndex = 0

        txtPartida.Focus()
    End Sub

    Private Sub EmisionCertificadoAnalisis_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        btnLimpiar_Click(Nothing, Nothing)
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCerrar.Click
        Close()
    End Sub

    Private Sub EmisionCertificadoAnalisis_Shown(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Shown
        txtPartida.Focus()
    End Sub

    Private Sub txtCliente_MouseDoubleClick(ByVal sender As Object, ByVal e As MouseEventArgs) Handles txtCliente.MouseDoubleClick
        Dim WCliente As DataTable = GetAll("SELECT Cliente Codigo, Razon Descripcion FROM Cliente WHERE Razon <> '' ORDER BY Razon")
        With New AyudaGeneral(WCliente)
            .ShowDialog(Me)
        End With
    End Sub

    Public Sub _ProcesarAyudaGeneral(ByVal row As DataGridViewRow) Implements IAyudaGeneral._ProcesarAyudaGeneral
        txtCliente.Text = row.Cells("Codigo").Value
        lblDescCliente.Text = row.Cells("Descripcion").Value
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAceptar.Click

        If Val(txtCantidad.Text) = 0 Then txtCantidad.Text = "1"
        If txtCliente.Text.Trim = "" Then txtCliente.Text = "S00102"

        '
        ' Buscamos la Información del Cliente.
        '
        Dim WCliente As DataRow = GetSingle("SELECT Idioma, Razon FROM Cliente WHERE Cliente = '" & txtCliente.Text & "'", "SurfactanSA")

        If WCliente Is Nothing Then
            MsgBox("El Cliente no es válido", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        Dim WBase As String = "Surfactan_III"
        Dim WTablaAltaCert As String = "AltaCertificadoFarma"
        Dim WTablaPrueter As String = "PrueterFarma"
        Dim WTablaCargaV As String = "CargaV"

        If Not EsFarma() Then
            WBase = "Surfactan_II"
            WTablaAltaCert = "AltaCertificadoNoFarma"
            WTablaPrueter = "PrueterNoFarma"
            WTablaCargaV = "CargaVNoFarma"
        End If

        '
        ' Buscamos la Información de la Prueba.
        '
        Dim WPrueterFarma As DataTable = GetAll("SELECT * FROM " & WTablaPrueter & " WHERE Partida = '" & txtPartida.Text & "' ORDER BY Renglon", Base)

        If WPrueterFarma.Rows.Count = 0 Then
            MsgBox("No se ha encontrado pruebas ingresadas para el Lote Indicado.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        '
        ' Agrego la fila para mostrar el Valor.
        '
        WPrueterFarma.Columns.Add("Marca")
        WPrueterFarma.Columns.Add("Std")
        WPrueterFarma.Columns.Add("StdII")

        '
        ' Modificamos el idioma del Certificado en caso de que el Cliente tenga idioma inglés cargado en su Ficha. Sino, dejamos el que hayan indicado.
        '
        If OrDefault(WCliente.Item("Idioma"), 0) = 1 Then cmbIdioma.SelectedIndex = 1

        '
        ' Definimos las abreviaturas según idioma seleccionado.
        '
        Dim ZZMes() As String = _AbreviaturasMesesSegunIdioma()

        '
        ' Buscamos los datos del Alta de Certificado. En caso de no tener definido, buscamos los de Surfactan.
        '
        Dim WAltaCertificado As DataTable = GetAll("SELECT Renglon, Marca FROM " & WTablaAltaCert & " WHERE Terminado = '" & lblTerminado.Text & "' And Cliente = '" & txtCliente.Text & "' ORDER BY Renglon", WBase)
        If WAltaCertificado.Rows.Count = 0 Then WAltaCertificado = GetAll("SELECT Renglon, Marca FROM " & WTablaAltaCert & " WHERE Terminado = '" & lblTerminado.Text & "' And Cliente = 'S00102' ORDER BY Renglon", WBase)

        '
        ' Controlamos que por lo menos hayan cargado los genéricos.
        '
        If WAltaCertificado.Rows.Count = 0 Then
            MsgBox("No se encuentra definido el Certificado de Análisis para este Producto.", MsgBoxStyle.Exclamation)
            Exit Sub
        Else
            For Each row As DataRow In WPrueterFarma.Rows
                With row
                    Dim r() As DataRow = WAltaCertificado.Select("Renglon = '" & .Item("Renglon").ToString.Ceros(2) & "'")
                    If r.Length > 0 Then .Item("Marca") = OrDefault(r(0).Item("Marca"), "")
                End With
            Next
        End If

        '
        ' Cargo los datos de CargaV.
        '
        Dim WCargaV As DataTable = GetAll("SELECT cv.*, StdII = cv.Valor, DescEnsayo = e.Descripcion FROM " & WTablaCargaV & " cv LEFT OUTER JOIN Ensayos e ON e.Codigo = cv.Ensayo WHERE cv.Terminado = '" & lblTerminado.Text & "' And cv.Paso = '99' ORDER BY cv.Renglon", WBase)

        '
        ' En caso de que sea Inglés el Idioma definido, se reemplaza los valores y unidades.
        '
        If cmbIdioma.SelectedIndex = 1 Then
            _ReemplazarConInfoEnIngles(WCargaV)
        End If

        '
        ' Determino qué valor y cómo se va a mostrar.
        '
        For Each row As DataRow In WPrueterFarma.Rows
            With row
                If Val(OrDefault(.Item("Estado"), "")) = 199 Then
                    .Item("Valor") = Trim(OrDefault(.Item("Resultado"), ""))
                    .Item("Std") = ""
                Else
                    .Item("Std") = Trim(OrDefault(.Item("Valor"), ""))

                    If cmbIdioma.SelectedIndex = 1 And Val(OrDefault(.Item("TipoEspecif"), "")) = 1 Then
                        .Item("Valor") = String.Format("{0} {1}", Trim(OrDefault(.Item("ValorReal"), "")), Trim(OrDefault(.Item("UnidadEspecif"), "")))
                    Else
                        .Item("Valor") = Trim(OrDefault(.Item("Resultado"), ""))
                    End If

                    .Item("Valor") = Trim(.Item("Valor"))

                End If
            End With
        Next

        '
        ' Calculamos la Fecha de Elaboración y Vencimiento.
        '
        Dim WFechaElaboracion, WFechaVencimiento, WLoteOriginal As String
        Dim WDatos As String() = ProductoTerminado.CalcularFechaElabVto(lblTerminado.Text, txtPartida.Text, True)
        WFechaElaboracion = WDatos(0)
        WFechaVencimiento = WDatos(1)
        WLoteOriginal = WDatos(2)

        '
        ' Para ajustar descripción de Parámetros.
        '
        For Each row As DataRow In WPrueterFarma.Rows
            With row

                .Item("Std") = ProductoTerminado._GenerarImpreParametro(
                        OrDefault(.Item("TipoEspecif"), ""),
                        OrDefault(.Item("DesdeEspecif"), ""),
                        OrDefault(.Item("HastaEspecif"), ""),
                        OrDefault(.Item("UnidadEspecif"), ""),
                        OrDefault(.Item("MenorIgualEspecif"), ""),
                        OrDefault(.Item("InformaEspecif"), ""))

                '
                ' Ajustamos en caso de que sea el certificado en inglés.
                '
                If cmbIdioma.SelectedIndex = 1 Then
                    .Item("Std") = _ReemplazarDescripcionParametroPorIngles(.Item("Std"))

                    If OrDefault(.Item("Valor"), "").ToString.Contains("Cumple") Then .Item("Valor") = "Complies"

                End If

            End With
        Next

        '
        ' Traemos la descripción del Producto Terminado segun el idioma.
        '
        Dim WDescTerminado As String = _TraerDescripcionTerminado()

        Dim dt As DataTable = New DBAuxi.CertificadoDataTable
        Dim index As Short = 0
        Dim WImpreFecha, WImpreFechaII As String

        If txtCliente.Text <> "L00118" Then
            WImpreFechaII = ZZMes(Val(Mid(WFechaElaboracion, 4, 2))) & " " & _Right(WFechaElaboracion, 4)
            WImpreFecha = ZZMes(Val(Mid(WFechaVencimiento, 4, 2))) & " " & _Right(WFechaVencimiento, 4)
        Else
            WImpreFechaII = _Left(WFechaElaboracion, 2) & " " & ZZMes(Val(Mid(WFechaElaboracion, 4, 2))) & " " & _Right(WFechaElaboracion, 4)
            WImpreFecha = _Left(WFechaVencimiento, 2) & " " & ZZMes(Val(Mid(WFechaVencimiento, 4, 2))) & " " & _Right(WFechaVencimiento, 4)
        End If

        For Each row As DataRow In WPrueterFarma.Rows
            With row
                If OrDefault(.Item("Marca"), "") <> "S" Then Continue For

                index += 1

                Dim r As DataRow = dt.NewRow
                Dim WStdII As String = ""

                Dim res() As DataRow = WCargaV.Select("Renglon = '" & .Item("Renglon") & "'")
                If res.Count > 0 Then
                    WStdII = Trim(OrDefault(res(0).Item("Valor"), ""))
                    If Not EsFarma() Then
                        WStdII = Trim(OrDefault(res(0).Item("DescEnsayo"), "")) & IIf(WStdII <> "", " ( " & WStdII & " )", "")
                    End If
                End If

                r.Item("Clave") = txtPartida.Text & index.ToString.PadLeft(2, "0")
                r.Item("Partida") = txtPartida.Text
                r.Item("Renglon") = index
                r.Item("Razon") = WCliente.Item("Razon")
                r.Item("Orden") = ""
                r.Item("Terminado") = lblTerminado.Text
                r.Item("Descripcion") = _Left(WDescTerminado, 50)
                r.Item("DescripcionAmpliada") = _Left(WDescTerminado, 100)
                r.Item("Fecha") = WImpreFecha
                r.Item("FechaII") = WImpreFechaII
                r.Item("Cantidad") = Val(formatonumerico(txtCantidad.Text))
                r.Item("Examen") = ""
                r.Item("ExamenII") = ""
                r.Item("ValorPartidaI") = .Item("Valor")
                r.Item("ValorPartidaII") = .Item("Farmacopea")
                r.Item("ValorNormalI") = WStdII
                r.Item("ValorNormalII") = .Item("Std")
                r.Item("Observaciones1") = ""
                r.Item("Observaciones2") = ""
                r.Item("Observaciones3") = ""
                r.Item("Observaciones4") = ""
                r.Item("Observaciones5") = ""
                r.Item("Observaciones6") = ""
                r.Item("Metodo") = .Item("Codigo")
                r.Item("Empresa") = ""

                dt.Rows.Add(r)
            End With
        Next

        For i = dt.Rows.Count + 1 To 28

            index += 1

            Dim r As DataRow = dt.NewRow

            r.Item("Clave") = txtPartida.Text & index.ToString.PadLeft(2, "0")
            r.Item("Partida") = txtPartida.Text
            r.Item("Renglon") = index
            r.Item("Razon") = WCliente.Item("Razon")
            r.Item("Orden") = ""
            r.Item("Terminado") = lblTerminado.Text
            r.Item("Descripcion") = _Left(WDescTerminado, 50)
            r.Item("DescripcionAmpliada") = _Left(WDescTerminado, 100)
            r.Item("Fecha") = WImpreFecha
            r.Item("FechaII") = WImpreFechaII
            r.Item("Cantidad") = Val(formatonumerico(txtCantidad.Text))
            r.Item("Examen") = ""
            r.Item("ExamenII") = ""
            r.Item("ValorPartidaI") = ""
            r.Item("ValorPartidaII") = ""
            r.Item("ValorNormalI") = ""
            r.Item("ValorNormalII") = ""
            r.Item("Observaciones1") = ""
            r.Item("Observaciones2") = ""
            r.Item("Observaciones3") = ""
            r.Item("Observaciones4") = ""
            r.Item("Observaciones5") = ""
            r.Item("Observaciones6") = ""
            r.Item("Metodo") = 0
            r.Item("Empresa") = ""

            dt.Rows.Add(r)

        Next

        Dim dv As DataView = New DataView(dt)
        Dim WMetodos As DataTable = dv.ToTable(True, "Metodo")
        Dim WNotasExternas As DataTable = New DataView(WPrueterFarma).ToTable(True, "NotaExterna1", "NotaExterna2", "NotaExterna3")
        Dim WImpreMetodos As String = ""
        Dim WImpreNotasExternas As String = ""

        If WMetodos.Rows.Count > 0 Then
            WImpreMetodos &= "Metodología Interna: "
            For Each row As DataRow In WMetodos.Rows
                If row.Item("Metodo") <> 0 Then WImpreMetodos &= row.Item("Metodo") & ", "
            Next
            WImpreMetodos = Trim(WImpreMetodos).TrimEnd(",")
        End If

        With WNotasExternas
            If .Rows.Count > 0 Then
                For Each row As DataRow In .Rows
                    WImpreNotasExternas &= Trim(OrDefault(row.Item("NotaExterna1"), "")) & " "
                    WImpreNotasExternas &= Trim(OrDefault(row.Item("NotaExterna2"), "")) & " "
                    WImpreNotasExternas &= Trim(OrDefault(row.Item("NotaExterna3"), "")) & " "
                Next
                WImpreNotasExternas = Trim(WImpreNotasExternas)
            End If
        End With

        Dim WImpreCargaVNotas As String = _ObtenerNotasExtrasDePT()

        Dim WImpreVto As String = IIf(cmbIdioma.SelectedIndex = 1, "Retest Date:", "F.Reanálisis:")

        '
        ' Verificamos si tiene Lote Original.
        '
        Dim WDatosMono() As String = ProductoTerminado._CalculaMonoOtro(txtPartida.Text, Base)
        Dim WDatosMonoInfo As DataRow = ProductoTerminado.EsMonoInfo(lblTerminado.Text)

        If WDatosMonoInfo IsNot Nothing Then
            If WDatosMonoInfo.Item("Tipo") > 0 And ProductoTerminado.EsFazon(lblTerminado.Text) Then
                If Val(WDatosMono(3)) <> 1 Then
                    WImpreVto = IIf(cmbIdioma.SelectedIndex = 1, "Expiry Date:", "F.Vencimiento:")
                End If
            End If
        End If

        Dim WTerminado As DataRow = GetSingle("SELECT CodRnpa FROM Terminado WHERE Codigo = '" & lblTerminado.Text & "'")
        Dim WCodRNPA As String = ""
        If WTerminado IsNot Nothing Then WCodRNPA = Trim(OrDefault(WTerminado.Item("CodRnpa"), ""))

        If WDatosMono IsNot Nothing AndAlso WDatosMono(3) <> "" Then WLoteOriginal = Trim(WDatosMono(3))

        If WLoteOriginal.Trim <> "" Then WLoteOriginal = "Ref: " & WLoteOriginal

        Dim rpt As ReportDocument = Nothing
        Dim WTipoRepote As Short = 0

        '
        ' En caso de tener lugar, mandamos en una misma hoja. Caso contrario, enviamos en dos hojas.
        '
        If dt.Rows.Count <= 28 Then

            rpt = New certificadonuevofarma
            With rpt
                .SetDataSource(dt)
                .SetParameterValue("MetodoInterno", WImpreMetodos & Space(10) & WLoteOriginal)

                .SetParameterValue("Nota2", WImpreNotasExternas)
                .SetParameterValue("Nota3", "")
                .SetParameterValue("Nota6", WImpreCargaVNotas)
                .SetParameterValue("ImpreVto", WImpreVto)
                .SetParameterValue("CodRnpa", WCodRNPA)
                .SetParameterValue("EnIngles", cmbIdioma.SelectedIndex = 1)

                Dim WImprePagina As String = IIf(cmbIdioma.SelectedIndex <> 1, "Página 1/1", "Page 1/1")
                .SetParameterValue("ImprePagina", WImprePagina)

            End With

            WTipoRepote = 1
            _GenerarCertificadoAnalisisFarma(rpt, WTipoRepote, txtPartida.Text, cmbTipoSalida.SelectedIndex)

        Else

            Dim WImprePagina As String = ""

            If WImpreCargaVNotas.Trim = "" Then
                WImprePagina = IIf(cmbIdioma.SelectedIndex <> 1, "Página 1/1", "Page 1/1")
            Else
                WImprePagina = IIf(cmbIdioma.SelectedIndex <> 1, "Página 1/2", "Page 1/2")
            End If

            rpt = New certificadonuevofarmaprimero
            With rpt

                .SetDataSource(dt)
                .SetParameterValue("MetodoInterno", WImpreMetodos)
                .SetParameterValue("ImpreVto", WImpreVto)
                .SetParameterValue("CodRnpa", WCodRNPA)

                If WLoteOriginal.Trim <> "" Then
                    .SetParameterValue("Nota2", WLoteOriginal)
                    .SetParameterValue("Nota3", WImpreNotasExternas)
                Else
                    .SetParameterValue("Nota2", WImpreNotasExternas)
                    .SetParameterValue("Nota3", "")
                End If

                .SetParameterValue("ImprePagina", WImprePagina)
                .SetParameterValue("EnIngles", cmbIdioma.SelectedIndex = 1)

            End With

            WTipoRepote = 2
            _GenerarCertificadoAnalisisFarma(rpt, WTipoRepote, txtPartida.Text, cmbTipoSalida.SelectedIndex)

            If WImpreCargaVNotas.Trim <> "" Then

                WImprePagina = IIf(cmbIdioma.SelectedIndex <> 1, "Página 2/2", "Page 2/2")
                rpt = New certificadonuevofarmasegunda

                With rpt

                    .SetDataSource(dt)
                    .SetParameterValue("ImpreVto", WImpreVto)
                    .SetParameterValue("CodRnpa", WCodRNPA)
                    .SetParameterValue("MetodoInterno", WImpreMetodos)
                    .SetParameterValue("Nota6", WImpreCargaVNotas)
                    .SetParameterValue("ImprePagina", WImprePagina)
                    .SetParameterValue("EnIngles", cmbIdioma.SelectedIndex = 1)

                End With

                WTipoRepote = 3
                _GenerarCertificadoAnalisisFarma(rpt, WTipoRepote, txtPartida.Text, cmbTipoSalida.SelectedIndex)

            End If

        End If

    End Sub

    Private Sub _GenerarCertificadoAnalisisFarma(ByVal rpt As ReportDocument, ByVal WTipoReporte As Integer, ByVal wPartida As Integer, ByVal wTipoSalida As Integer, Optional ByVal WNombrePDF As String = "")

        'rpt.SetParameterValue("MostrarLogo", 0)
        'rpt.SetParameterValue("MostrarPie", 0)

        rpt.SetParameterValue("MostrarLogo", 1)
        rpt.SetParameterValue("MostrarPie", 1)

        With New VistaPrevia
            .Reporte = rpt
            .Base = Base
            Dim WNombre As String = WNombrePDF

            If WNombre.Trim = "" Then

                WNombre = "Certificado " & wPartida
                Select Case WTipoReporte
                    Case 2
                        WNombre &= " - Primera"
                    Case 3
                        WNombre &= " - Segunda"
                End Select

            End If

            If Not UCase(WNombre).EndsWith("PDF") And WNombre.Trim <> "" Then WNombre &= ".pdf"

            Select Case wTipoSalida
                Case 0
                    .Mostrar()
                Case 1
                    .Imprimir()
                Case 2
                    .Exportar(WNombre, ExportFormatType.PortableDocFormat)
            End Select

        End With

    End Sub

    Private Function _ObtenerNotasExtrasDePT() As String
        Dim WImpreCargaVNotas As String = ""
        Dim WCargaVNotas As DataTable

        Dim WTablaCargaVNotas As String = "CargaVNotas"
        Dim WTablaCargaVNotasIng As String = "CargaVNotasIngles"
        Dim WBase As String = "Surfactan_III"

        If Not EsFarma() Then
            WTablaCargaVNotas = "CargaVNoFarmaNotas"
            WTablaCargaVNotasIng = "CargaVNoFarmaNotasIngles"
            WBase = "Surfactan_II"
        End If

        If cmbIdioma.SelectedIndex = 1 Then
            WCargaVNotas = GetAll("SELECT Nota, Renglon, Observacion FROM " & WTablaCargaVNotasIng & " WHERE Terminado = '" & lblTerminado.Text & "' ORDER BY Nota, Renglon", WBase)
        Else
            WCargaVNotas = GetAll("SELECT Nota, Renglon, Observacion FROM " & WTablaCargaVNotas & " WHERE Terminado = '" & lblTerminado.Text & "' ORDER BY Nota, Renglon", WBase)
        End If

        If WCargaVNotas.Rows.Count > 0 Then
            Dim WRenglonesCargaVNotas As DataTable = New DataView(WCargaVNotas).ToTable(True, "Nota")

            For Each r As DataRow In WRenglonesCargaVNotas.Rows
                Dim n() As DataRow = WCargaVNotas.Select("Nota = '" & r.Item("Nota") & "'", "Renglon")
                For Each _n As DataRow In n
                    WImpreCargaVNotas &= Trim(_n.Item("Observacion")) & " "
                Next
                WImpreCargaVNotas &= vbCrLf
            Next
        End If
        Return WImpreCargaVNotas.PadRight(500, " ")
    End Function

    Private Function _TraerDescripcionTerminado() As String
        Dim WDato As DataRow = Nothing

        If cmbIdioma.SelectedIndex = 1 Then
            If txtCliente.Text = "L00118" Then
                WDato = GetSingle("SELECT Descripcion = RTRIM(Linea2)  + ' ' + RTRIM(Linea3) FROM etilehman WHERE Codigo = '" & lblTerminado.Text & "'", "SurfactanSA")
            Else
                WDato = GetSingle("SELECT Descripcion = RTRIM(DescriEtiquetaIngles) + ' ' + RTRIM(DescripcionIngles) FROM Terminado WHERE Codigo = '" & lblTerminado.Text & "'")
            End If
        Else
            WDato = GetSingle("SELECT Descripcion = CASE WHEN RTRIM(ISNULL(DescriEtiqueta, '')) <> '' THEN RTRIM(DescriEtiqueta) ELSE Descripcion END FROM Terminado WHERE Codigo = '" & lblTerminado.Text & "'")
        End If

        If WDato IsNot Nothing Then Return Trim(OrDefault(WDato.Item("Descripcion"), ""))

        Return ""
    End Function

    Private Function _ReemplazarDescripcionParametroPorIngles(ByVal Parametro As String) As String

        For Each pair As KeyValuePair(Of String, String) In WDescParametrosIngles
            If Parametro.Contains(pair.Key) Then
                Return Parametro.Replace(pair.Key, pair.Value)
            End If
        Next

        Return Parametro

    End Function

    Private Sub _ReemplazarConInfoEnIngles(ByRef WCargaV As DataTable)

        Dim WTablaCargaVIng As String = "CargaVIngles"
        Dim WBase As String = "Surfactan_III"

        If Not EsFarma() Then
            WTablaCargaVIng = "CargaVNoFarmaIngles"
            WBase = "Surfactan_II"
        End If

        Dim WCargaVIngles As DataTable = GetAll("SELECT Renglon, Valor, UnidadEspecif FROM " & WTablaCargaVIng & " WHERE Terminado  = '" & lblTerminado.Text & "' And Paso = '99' Order by Renglon", WBase)

        For Each row As DataRow In WCargaVIngles.Rows
            Dim fila() As DataRow = WCargaV.Select("Renglon = '" & row.Item("Renglon") & "'")

            If fila.Count > 0 Then
                fila(0).Item("Valor") = row.Item("Valor")
                fila(0).Item("UnidadEspecif") = row.Item("UnidadEspecif")
            End If
        Next

        If WCargaVIngles.Rows.Count = 0 Then
            MsgBox("No se han cargado las especificaciones en Inglés para el Codigo: '" & lblTerminado.Text & "'", MsgBoxStyle.Exclamation)
        End If

    End Sub

    Private Function _AbreviaturasMesesSegunIdioma() As String()

        Dim ZZMes() As String = New String(12) {}

        If cmbIdioma.SelectedIndex = 1 Then

            ZZMes(1) = "Jan."
            ZZMes(2) = "Feb."
            ZZMes(3) = "Mar."
            ZZMes(4) = "Apr."
            ZZMes(5) = "May"
            ZZMes(6) = "Jun."
            ZZMes(7) = "Jul."
            ZZMes(8) = "Aug."
            ZZMes(9) = "Sep."
            ZZMes(10) = "Oct."
            ZZMes(11) = "Nov."
            ZZMes(12) = "Dec."

        Else

            ZZMes(1) = "Enero"
            ZZMes(2) = "Febr."
            ZZMes(3) = "Marzo"
            ZZMes(4) = "Abril"
            ZZMes(5) = "Mayo "
            ZZMes(6) = "Junio"
            ZZMes(7) = "Julio"
            ZZMes(8) = "Agos."
            ZZMes(9) = "Sept."
            ZZMes(10) = "Oct. "
            ZZMes(11) = "Nov. "
            ZZMes(12) = "Dic. "

        End If
        Return ZZMes
    End Function

    Private Sub txtPartida_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPartida.KeyDown

        If e.KeyData = Keys.Enter Then
            If Val(txtPartida.Text) = 0 Then : Exit Sub : End If

            Dim WHoja As DataRow = GetSingle("SELECT h.Producto, t.Descripcion FROM Hoja h INNER JOIN Terminado t On t.Codigo = h.Producto WHERE h.Hoja = '" & txtPartida.Text & "' And h.Renglon = 1")

            lblTerminado.Text = ""
            lblDescProducto.Text = ""
            lblDescProductocliente.Text = ""

            If WHoja IsNot Nothing Then
                With WHoja
                    lblTerminado.Text = OrDefault(.Item("Producto"), "")
                    lblDescProducto.Text = OrDefault(.Item("Descripcion"), "")
                    lblDescProductocliente.Text = _TraerDescripcionTerminado()
                End With

                txtCliente.Focus()

            End If

        ElseIf e.KeyData = Keys.Escape Then
            txtPartida.Text = ""
        End If

    End Sub

    Private Sub txtCliente_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCliente.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txtCliente.Text) = "" Then : Exit Sub : End If

            lblDescCliente.Text = ""

            Dim WCliente As DataRow = GetSingle("SELECT Razon FROM Cliente WHERE Cliente = '" & txtCliente.Text & "'")

            If WCliente Is Nothing Then Exit Sub

            lblDescCliente.Text = Trim(OrDefault(WCliente.Item("Razon"), ""))

            txtCantidad.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtCliente.Text = ""
        End If

    End Sub

    Private Sub SoloNumero(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles txtCantidad.KeyPress, txtPartida.KeyPress
        If Not Char.IsNumber(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

End Class