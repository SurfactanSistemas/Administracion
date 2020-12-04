Imports Util
Imports Util.Clases
Imports Util.Interfaces

Public Class IngresoEspecificacionesMP : Implements IIngresoParametrosEspecificaciones, IListaConsultas, IAyudaMPs, IAyudaEnsayos, IIngresoClaveSeguridad

    Enum TipoProcesosIngEspecif
        Revalida
        GrabaVersion
    End Enum

    Private WAutorizado As Boolean = False
    Private WActualizaVersion As Boolean = False
    Private WTipoProceso As TipoProcesosIngEspecif = Nothing
    Private IDOperadorGrabacion As Short = 0

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


    Private Sub btnLimpiar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnLimpiar.Click
        For Each control As Control In {txtControlCambios, txtDescTerminado, txtCodigo, txtCondicionMuestreo, txtDescIngles, txtCas, txtFecha, txtOperador, txtVersion}
            control.Text = ""
        Next

        dgvEspecif.Rows.Clear()
        dgvEspecifIngles.Rows.Clear()

        TabControl1.SelectTab(0)

        WAutorizado = False
        WTipoProceso = Nothing

        txtCodigo.Focus()
    End Sub

    Private Sub IngresoEspecificacionesPT_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        txtDescTerminado.BackColor = Globales.WBackColorTerciario
        btnLimpiar_Click(Nothing, Nothing)

        If PermisoGrabar = False Then

            btnGrabar.Enabled = False
            btnAgregarRenglon.Enabled = False
            btnImpresion.Enabled = False
            btnConsultas.Enabled = False
            dgvEspecif.ReadOnly = True
            dgvEspecifIngles.ReadOnly = True
        End If


    End Sub

    Private Sub txtCodigo_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtCodigo.KeyDown

        If e.KeyData = Keys.Enter Then

            txtDescTerminado.Text = ""

            If txtCodigo.Text.Replace(" ", "").Length < 10 Then Exit Sub

            _CargarDatosMP()

        ElseIf e.KeyData = Keys.Escape Then
            txtCodigo.Text = ""
        End If

    End Sub

    Private Sub _CargarDatosMP()

        Dim WMp As DataRow = GetSingle("SELECT Descripcion FROM Articulo Where Codigo = '" & txtCodigo.Text & "'")

        If WMp IsNot Nothing Then
            txtDescTerminado.Text = Trim(OrDefault(WMp.Item("Descripcion"), "")).ToUpper
            txtEtapa_KeyDown(New KeyEventArgs(Keys.Enter))
        End If

    End Sub

    Private Sub txtEtapa_KeyDown(ByVal e As KeyEventArgs)

        If e.KeyData = Keys.Enter Then

            _CargarDatosEspecifMP()

            Dim WBaseII = "Surfactan_II"

            If _EsPellital() Then WBaseII = "Pelitall_II"

            For Each row As DataGridViewRow In dgvEspecif.Rows
                With row
                    Dim WEns As String = OrDefault(.Cells("Ensayo").Value, "0")

                    If Val(WEns) = 0 Then
                        If .Index <= dgvEspecifIngles.Rows.Count - 1 Then dgvEspecifIngles.Rows(.Index).Cells("DescEnsayoIngles").Value = ""

                        Continue For
                    End If

                    Dim WEnsayo As DataRow = GetSingle("SELECT Descripcion FROM Ensayos WHERE Codigo = '" & WEns & "'", WBaseII)

                    'SI LA CANTIDAD DE FILAS DE DATOS EN INGLES ES MENOR A LAS FILAS EN ENSAYOS
                    'ES PORQUE NO TENIA DATOS GUARDADOS ENTONCES LE AGREGAMOS LAS FILAS SINO NO SE AGREGA NADA

                    If dgvEspecifIngles.Rows.Count < dgvEspecif.Rows.Count Then dgvEspecifIngles.Rows.Add()




                    If WEnsayo IsNot Nothing Then

                        .Cells("Especificacion").Value = Trim(OrDefault(WEnsayo.Item("Descripcion"), ""))

                        If .Index <= dgvEspecifIngles.Rows.Count - 1 Then
                            dgvEspecifIngles.Rows(.Index).Cells("NroRenglonIngles").Value = dgvEspecif.Rows(.Index).Cells("NroRenglon").Value
                            dgvEspecifIngles.Rows(.Index).Cells("EnsayoIngles").Value = dgvEspecif.Rows(.Index).Cells("Ensayo").Value
                            dgvEspecifIngles.Rows(.Index).Cells("EspecificacionIngles").Value = Trim(OrDefault(WEnsayo.Item("Descripcion"), ""))
                        End If

                    End If

                End With
            Next

        End If

    End Sub

    Private Sub _CargarDatosEspecifMP()

        Dim WCargaV As DataTable = GetAll("SELECT * FROM CargaVMP WHERE Articulo = '" & txtCodigo.Text & "' Order By Clave", "Surfactan_II")

        dgvEspecif.Rows.Clear()

        '
        ' En caso de tener datos en el formato nuevo, los cargamos. Sino traemos y parseamos los datos del formato viejo al nuevo.
        '
        If WCargaV.Rows.Count > 0 Then

            _PoblarEspecificaciones(WCargaV)

            '
            ' Cargamos los valores en Inglés.
            '
            Dim WCargaVIngles As DataTable = GetAll("SELECT Valor, Farmacopea, UnidadEspecif FROM CargaVMPIngles WHERE Articulo = '" & txtCodigo.Text & "' And Paso = '99' Order By Clave", "Surfactan_II")

            If WCargaVIngles.Rows.Count = 0 Then Return

            _PoblarEspecificacionesIngles(WCargaVIngles)


        Else

            '
            ' Traemos los datos en el formato viejo y lo ajustamos para presentarlo como el nuevo.
            '
            Dim WEspecificacionesUnifica As DataRow = GetSingle("SELECT * FROM EspecificacionesUnifica WHERE Producto = '" & txtCodigo.Text & "'", "Surfactan_II")
            Dim WEspecificacionesUnificaII As DataRow = GetSingle("SELECT * FROM EspecificacionesUnificaII WHERE Producto = '" & txtCodigo.Text & "'", "Surfactan_II")
            Dim WEspecificacionesUnificaIII As DataRow = GetSingle("SELECT * FROM EspecificacionesUnificaIII WHERE Producto = '" & txtCodigo.Text & "'", "Surfactan_II")

            '
            ' Creamos la Tabla en memoria.
            '
            Dim WCargaVFormatoViejo As New DataTable
            Dim WCargaVFormatoViejoIngles As New DataTable

            For Each c As String In {"Ensayo", "Valor", "ControlCambio", "Farmacopea", "TipoEspecif", "DesdeEspecif", "HastaEspecif", "UnidadEspecif", "MenorIgualEspecif", "InformaEspecif", "FormulaEspecif", "FechaGrabacion", "Version", "Operador"}
                WCargaVFormatoViejo.Columns.Add(c)
                WCargaVFormatoViejoIngles.Columns.Add(c)
            Next

            For i = 1 To 10
                WCargaVFormatoViejo.Columns.Add("Variable" & i)
            Next

            If WEspecificacionesUnifica Is Nothing Then
                txtVersion.Text = "1"
                txtFecha.Text = Date.Now.ToString("dd/MM/yyyy")
                dgvEspecifIngles.Rows.Clear()
                dgvEspecifIngles.Rows.Add()
                dgvEspecif.Rows.Clear()
                dgvEspecif.Rows.Add()
                dgvEspecif.Focus()
                Exit Sub
            End If

            '
            ' Transformamos la información vieja al Formato nuevo.
            '
            Dim WEnsayo, WValor, WDesde, WHasta, WTipoEspecif, WInformaEspecif, WFecha, WVersion, WOperador As String

            For i = 1 To 20

                With WEspecificacionesUnifica

                    WEnsayo = Trim(OrDefault(.Item("Ensayo" & i), ""))

                    If Val(WEnsayo) = 0 Then Continue For

                    WFecha = OrDefault(.Item("Fecha"), "")
                    WVersion = OrDefault(.Item("Version"), "")
                    WOperador = OrDefault(.Item("Operador"), "")

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
                    .Item("FechaGrabacion") = WFecha
                    .Item("Version") = WVersion
                    .Item("Operador") = WOperador
                End With

                WCargaVFormatoViejo.Rows.Add(r)

            Next

            If WEspecificacionesUnificaIII IsNot Nothing Then

                For i = 21 To 30

                    With WEspecificacionesUnificaIII

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

                With WEspecificacionesUnificaIII
                    txtCondicionMuestreo.Text = Trim(OrDefault(.Item("Muestreo"), "")) & " " _
                                                & Trim(OrDefault(.Item("MuestreoII"), "")) & " " _
                                                & Trim(OrDefault(.Item("MuestreoIII"), ""))
                End With

            End If

            _PoblarEspecificaciones(WCargaVFormatoViejo)

            txtVersion.Text = Trim(OrDefault(WEspecificacionesUnifica.Item("Version"), ""))
            txtFecha.Text = Trim(OrDefault(WEspecificacionesUnifica.Item("Fecha"), "  /  /    "))
            txtControlCambios.Text = Trim(OrDefault(WEspecificacionesUnifica.Item("ControlCambio"), ""))

            If WEspecificacionesUnificaII IsNot Nothing Then

                '
                ' Especificaciones en Inglés.
                '
                For i = 1 To 30

                    With WEspecificacionesUnificaII

                        WEnsayo = ""

                        WValor = Trim(OrDefault(.Item("IValor" & i), ""))

                        If WValor = "" Then Continue For

                        WDesde = ""
                        WHasta = ""

                        WTipoEspecif = ""
                        WInformaEspecif = ""

                    End With

                    Dim r As DataRow = WCargaVFormatoViejoIngles.NewRow

                    With r
                        .Item("Ensayo") = WEnsayo
                        .Item("Valor") = WValor
                        .Item("DesdeEspecif") = WDesde
                        .Item("HastaEspecif") = WHasta
                        .Item("TipoEspecif") = WTipoEspecif
                        .Item("InformaEspecif") = WInformaEspecif
                    End With

                    WCargaVFormatoViejoIngles.Rows.Add(r)

                Next

                _PoblarEspecificacionesIngles(WCargaVFormatoViejoIngles)

                txtDescIngles.Text = Trim(OrDefault(WEspecificacionesUnificaII.Item("DescripcionIngles"), ""))
                txtCas.Text = Trim(OrDefault(WEspecificacionesUnificaII.Item("Cas"), ""))

            End If
        End If

        TabControl1.SelectTab(0)
    End Sub

    Private Sub _PoblarEspecificacionesIngles(WCargaVIngles As DataTable)

        Dim WNroRenglon As Integer = 1


        dgvEspecifIngles.Rows.Clear()

        For Each row As DataRow In WCargaVIngles.Rows
            With row
                Dim WEspecificacion = Trim(OrDefault(.Item("Valor"), ""))
                Dim WFarmacopea = Trim(OrDefault(.Item("Farmacopea"), ""))
                Dim WUnidadEspecif = Trim(OrDefault(.Item("UnidadEspecif"), ""))

                Dim r = dgvEspecifIngles.Rows.Add

                With dgvEspecifIngles.Rows(r)
                    .Cells("NroRenglonIngles").Value = WNroRenglon
                    .Cells("EnsayoIngles").Value = ""
                    If dgvEspecif.Rows.Count > r Then .Cells("EnsayoIngles").Value = dgvEspecif.Rows(r).Cells("Ensayo").Value
                    .Cells("EspecificacionIngles").Value = ""
                    .Cells("DescEnsayoIngles").Value = Trim(WEspecificacion)
                    .Cells("FarmacopeaIngles").Value = Trim(WFarmacopea)
                    .Cells("UnidadEspecifIngles").Value = WUnidadEspecif
                End With

            End With
            WNroRenglon += 1
        Next

        For i = dgvEspecifIngles.Rows.Count To dgvEspecif.Rows.Count - 1
            dgvEspecifIngles.Rows.Add(dgvEspecif.Rows(i).Cells("Ensayo").Value)
        Next

    End Sub

    Private Sub _PoblarEspecificaciones(WCargaV As DataTable)

        Dim WNroRenglon As Integer = 1
        Dim WOperador As String = ""

        dgvEspecif.Rows.Clear()

        '
        ' En caso de tener datos en el formato nuevo, los cargamos. Sino traemos y parseamos los datos del formato viejo al nuevo.
        '
        If WCargaV.Rows.Count > 0 Then

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
                    Dim WImpreParametro = _GenerarImpreParametro(WDesdeEspecif, WHastaEspecif, WUnidadEspecif, WMenorIgualEspecif, WInformaEspecif)

                    If Val(WTipoEspecif) = 0 And WImpreParametro <> "" Then WImpreParametro &= " (c)"

                    Dim r = dgvEspecif.Rows.Add

                    txtControlCambios.Text = Trim(WControlCambio)

                    With dgvEspecif.Rows(r)
                        .Cells("NroRenglon").Value = WNroRenglon
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

                    WOperador = Trim(OrDefault(.Item("Operador"), ""))

                    txtFecha.Text = OrDefault(.Item("FechaGrabacion"), "  /  /    ")
                    txtVersion.Text = OrDefault(.Item("Version"), "")
                End With
                WNroRenglon += 1

            Next

            If Val(WOperador) > 0 Then
                Dim temp As DataRow = GetSingle("SELECT Descripcion FROM Operador WHERE Operador = '" & WOperador & "'", "Surfactan_II")
                If temp IsNot Nothing Then txtOperador.Text = Trim(OrDefault(temp.Item("Descripcion"), "")).ToUpper
            End If

            If Val(ordenaFecha(txtFecha.Text)) = 0 Then txtFecha.Text = Date.Now.ToString("dd/MM/yyyy")
            If Val(txtVersion.Text) = 0 Then txtVersion.Text = "1"

        End If
    End Sub

    Private Function _GenerarImpreParametro(ByVal wDesdeEspecif As String, ByVal wHastaEspecif As String, ByVal wUnidadEspecif As String, ByVal wMenorIgualEspecif As String, ByVal WInformaEspecif As String) As String

        wDesdeEspecif = OrDefault(Trim(wDesdeEspecif), "")
        wHastaEspecif = OrDefault(Trim(wHastaEspecif), "")
        wUnidadEspecif = OrDefault(Trim(wUnidadEspecif), "")
        wMenorIgualEspecif = OrDefault(Trim(wMenorIgualEspecif), "")
        WInformaEspecif = OrDefault(Trim(WInformaEspecif), "")

        If Val(wDesdeEspecif) = 0 And Val(wHastaEspecif) = 0 Then Return "Cumple Ensayo"

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

            Dim frm As New IngresoParametrosEspecificaciones(WEnsayo, WDescEnsayo, WParametro, WTipo, WInforma,
                                                             WMenorIgual, WDesde, WHasta, WUnidad, WFarmacopea,
                                                             WFormula, WParametrosFormula)
            frm.ShowDialog(Me)

            dgvEspecif.CurrentCell = dgvEspecif.Rows(.Index).Cells("Ensayo")

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

            Dim WImpreParametro = _GenerarImpreParametro(Desde, Hasta, Unidad, MenorIgual, Informa)


            If Val(Tipo) = 0 And WImpreParametro <> "" Then WImpreParametro &= " (c)"

            .Cells("Parametro").Value = WImpreParametro

            For i = 1 To ParametrosFormula.Count - 1
                .Cells("Variable" & i).Value = Trim(ParametrosFormula(i))
            Next

            'si no tiene esa fila se la agregamos
            Dim index As Integer = dgvEspecif.CurrentRow.Index
            If index > dgvEspecifIngles.Rows.Count - 1 Then
                dgvEspecifIngles.Rows.Add()
            End If
            dgvEspecifIngles.Rows(index).Cells("EnsayoIngles").Value = .Cells("Ensayo").Value
            dgvEspecifIngles.Rows(index).Cells("EspecificacionIngles").Value = .Cells("Especificacion").Value
            dgvEspecifIngles.Rows(index).Cells("FarmacopeaIngles").Value = .Cells("Farmacopea").Value
            dgvEspecifIngles.Rows(index).Cells("UnidadEspecifIngles").Value = .Cells("UnidadEspecif").Value

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

        Dim WSqls As New List(Of String)

        '
        ' Generamos la grabación en el formato viejo.
        '
        WSqls.AddRange(_PrepararGrabarEnFormatoViejo())

        If WActualizaVersion Then
            WSqls.Add("INSERT INTO CargaVMPVersion (Clave,Articulo,Paso,Renglon,Fecha,Ensayo,Valor,DesEnsayo,Partida,CantidadPartida,DesPaso," _
                      & "Corte,ImprePaso,ControlCambio,[Version],Resultado,ObservaI,ObservaII,ObservaIII,ObservaIV,ImpreTerminado,fechaing," _
                      & "UnidadEspecif,TipoEspecif,DesdeEspecif,HastaEspecif,DesEnsayoII,Farmacopea,observacion1,observacion2,observacion3," _
                      & "observacion4,observacion5,observacion6,observacion7,observacion8,observacion9,observacion10,InformaEspecif," _
                      & "MenorIgualEspecif,FormulaEspecif,Variable1,Variable2,Variable3,Variable4,Variable5,Variable6,Variable7," _
                      & "Variable8,Variable9,Variable10,FechaGrabacion,MetAnaliticoTrazas,FechaInicio,FechaFinal, Operador)" _
                      & "SELECT Clave,Articulo,Paso,Renglon,FechaGrabacion,Ensayo,Valor,DesEnsayo,Partida,CantidadPartida,DesPaso," _
                      & "Corte,ImprePaso,ControlCambio,[Version],Resultado,ObservaI,ObservaII,ObservaIII,ObservaIV,ImpreTerminado," _
                      & "fechaing,UnidadEspecif,TipoEspecif,DesdeEspecif,HastaEspecif,DesEnsayoII,Farmacopea,observacion1,observacion2," _
                      & "observacion3,observacion4,observacion5,observacion6,observacion7,observacion8,observacion9,observacion10," _
                      & "InformaEspecif,MenorIgualEspecif,FormulaEspecif,Variable1,Variable2,Variable3,Variable4,Variable5,Variable6," _
                      & "Variable7,Variable8,Variable9,Variable10,FechaGrabacion,MetAnaliticoTrazas, FechaGrabacion," _
                      & "'" & Date.Now.ToString("dd/MM/yyyy") & "', Operador FROM CargaVMP WHERE Articulo = '" & txtCodigo.Text & "'")
        End If

        '
        ' Generamos la grabación en nuevo formato.
        '
        WSqls.AddRange(_PrepararGrabarEnFormatoNuevo())

        If WActualizaVersion Then
            WSqls.Add("UPDATE CargaVMP SET Version = [Version] + 1, FechaGrabacion = '" & Date.Now.ToString("dd/MM/yyyy") & "'," _
                      & "Operador = '" & IDOperadorGrabacion & "' WHERE Articulo = '" & txtCodigo.Text & "'")
        End If

        '
        ' Grabamos
        '
        ExecuteNonQueries("Surfactan_II", WSqls.ToArray)

        btnLimpiar.PerformClick()

    End Sub

    Private Function _PrepararGrabarEnFormatoNuevo() As IEnumerable(Of String)
        Dim WConsultas As New List(Of String)

        '
        ' Recuperamos las notas viejas, para mantenerlas cuando se actualicen los datos luego.
        '
        Dim WNotas As DataRow = GetSingle("SELECT Observacion1, Observacion2, Observacion3, Observacion4, Observacion5, Observacion6, Observacion7, " _
                                          & "Observacion8, Observacion9, Observacion10 FROM CargaVMP WHERE Articulo = '" & txtCodigo.Text & "'" _
                                          & "And Paso = '99' And Renglon = 1", "Surfactan_II")

        '
        ' Borramos el registro anterior si lo hubiese.
        '
        WConsultas.Add("DELETE FROM CargaVMP WHERE Articulo = '" & txtCodigo.Text & "' And Paso = '99'")

        Dim WDescPaso, WCorte As String

        WDescPaso = "CONTROL FINAL"
        WCorte = "1"

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

        If Val(ordenaFecha(txtFecha.Text)) = 0 Then txtFecha.Text = Date.Now.ToString("dd/MM/yyyy")

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

                XPaso = "0099"
                Auxi = WRenglon.ToString.PadLeft(2, "0")

                Dim WClave = txtCodigo.Text + XPaso + Auxi

                ZSql = ""
                ZSql = ZSql & "INSERT INTO CargaVMP ("
                ZSql = ZSql & "Clave ,"
                ZSql = ZSql & "Articulo ,"
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
                ZSql = ZSql & "FechaGrabacion ,"
                ZSql = ZSql & "[Version] ,"
                ZSql = ZSql & "Operador ,"
                ZSql = ZSql & "Corte )"
                ZSql = ZSql & "Values ("
                ZSql = ZSql & "'" & WClave & "',"
                ZSql = ZSql & "'" & txtCodigo.Text & "',"
                ZSql = ZSql & "'" & "99" & "',"
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
                ZSql = ZSql & "'" & txtFecha.Text & "',"
                ZSql = ZSql & "'" & txtVersion.Text & "',"
                ZSql = ZSql & "'" & IDOperadorGrabacion & "',"
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
        ' En caso de las MP, siempre se las va a tratar como de Etapa 99, por tanto se actualizan las especificaciones en ingles.
        '
        WRenglon = 0

        WConsultas.Add("DELETE FROM CargaVMPIngles WHERE Articulo = '" & txtCodigo.Text & "' And Paso = '99'")

        '
        ' Grabamos los datos de cada renglon.
        '
        For Each row As DataGridViewRow In dgvEspecifIngles.Rows

            Dim WDescripcionEnsayo, WValor, WFarmacopea, WUnidadEspecif As String

            With row

                WDescripcionEnsayo = OrDefault(.Cells("EspecificacionIngles").Value, "")
                WValor = OrDefault(.Cells("DescEnsayoIngles").Value, "")
                WFarmacopea = OrDefault(.Cells("FarmacopeaIngles").Value, "")
                WUnidadEspecif = OrDefault(.Cells("UnidadEspecifIngles").Value, "")

                If WDescripcionEnsayo.Trim = "" Then Continue For

                Dim ZSql, XPaso, Auxi As String

                WRenglon += 1

                XPaso = "0099"
                Auxi = WRenglon.ToString.PadLeft(2, "0")

                Dim WClave = txtCodigo.Text + XPaso + Auxi

                ZSql = ""
                ZSql = ZSql & "INSERT INTO CargaVMPIngles ("
                ZSql = ZSql & "Clave ,"
                ZSql = ZSql & "Articulo ,"
                ZSql = ZSql & "Paso ,"
                ZSql = ZSql & "Renglon ,"
                ZSql = ZSql & "Valor ,"
                ZSql = ZSql & "Farmacopea ,"
                ZSql = ZSql & "UnidadEspecif "
                ZSql = ZSql & ")"
                ZSql = ZSql & "Values ("
                ZSql = ZSql & "'" & WClave & "',"
                ZSql = ZSql & "'" & txtCodigo.Text & "',"
                ZSql = ZSql & "'" & "99" & "',"
                ZSql = ZSql & "'" & Trim(Str$(WRenglon)) & "',"
                ZSql = ZSql & "'" & WValor & "',"
                ZSql = ZSql & "'" & WFarmacopea & "',"
                ZSql = ZSql & "'" & WUnidadEspecif & "'"
                ZSql = ZSql & ")"

                WConsultas.Add(ZSql)

            End With
        Next

        Dim WObservacion(10) As String

        If WNotas IsNot Nothing Then
            For i = 1 To 10
                WObservacion(i) = OrDefault(WNotas.Item("Observacion" & i), "")
            Next
        End If

        '
        ' Actualizamos las Notas para mantener Histórico.
        '
        WConsultas.Add("UPDATE CargaVMP SET Observacion1 = '" & Trim(WObservacion(1)) & "', Observacion2 = '" & Trim(WObservacion(2)) & "'," _
                       & "Observacion3 = '" & Trim(WObservacion(3)) & "', Observacion4 = '" & Trim(WObservacion(4)) & "'," _
                       & "Observacion5 = '" & Trim(WObservacion(5)) & "', Observacion6 = '" & Trim(WObservacion(6)) & "'," _
                       & "Observacion7 = '" & Trim(WObservacion(7)) & "', Observacion8 = '" & Trim(WObservacion(8)) & "'," _
                       & "Observacion9 = '" & Trim(WObservacion(9)) & "', Observacion10 = '" & Trim(WObservacion(10)) & "' " _
                       & "WHERE Articulo = '" & txtCodigo.Text & "' And Paso = '99'")

        Return WConsultas

    End Function

    Private Function _PrepararGrabarEnFormatoViejo() As IEnumerable(Of String)
        Dim WSqls As New List(Of String)

        Dim sql As String

        For i = dgvEspecif.Rows.Count + 1 To 30
            dgvEspecif.Rows.Add()
        Next

        For i = dgvEspecifIngles.Rows.Count + 1 To dgvEspecif.Rows.Count
            dgvEspecifIngles.Rows.Add()
        Next

        WActualizaVersion = False

        If GetSingle("SELECT Producto FROM EspecificacionesUnifica WHERE Producto = '" & txtCodigo.Text & "'", "Surfactan_II") IsNot Nothing Then
            If MsgBox("¿Desea actualizar la Versión de las Especificaciones?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

                ''
                '' Preparamos la actualizacion de las versiones.
                ''
                sql = _PrepararGuardarVersionFormatoViejoI()
                WSqls.Add(sql)

                sql = _PrepararGuardarVersionFormatoViejoII()
                WSqls.Add(sql)

                sql = _PrepararActualizacionVersionFormatoViejo()
                WSqls.Add(sql)

                WActualizaVersion = True

            Else

                sql = _PrepararSinActualizacionVersionFormatoViejo()
                WSqls.Add(sql)

            End If

        Else

            sql = _PrepararAltaPrimeraVersionFormatoViejo()
            WSqls.Add(sql)

        End If

        WSqls.Add("DELETE FROM EspecificacionesUnificaII WHERE Producto = '" & txtCodigo.Text & "'")

        sql = _PrepararAltaPrimeraVersionFormatoViejoII()
        WSqls.Add(sql)

        WSqls.Add("DELETE FROM EspecificacionesUnificaIII WHERE Producto = '" & txtCodigo.Text & "'")

        sql = _PrepararAltaPrimeraVersionFormatoViejoIII()
        WSqls.Add(sql)

        Return WSqls
    End Function

    Private Function _PrepararAltaPrimeraVersionFormatoViejoII() As String
        Dim sql As String

        sql = "INSERT INTO EspecificacionesUnificaII ("

        Dim columnas As String = ""
        Dim valores As String = ""

        For i = 1 To 30
            columnas &= "IValor" & i & ","
        Next

        For i = 1 To 30
            With dgvEspecifIngles.Rows(i - 1)
                valores &= "'" & Trim(OrDefault(.Cells("DescEnsayoIngles").Value, "")) & "',"
            End With
        Next

        sql &= columnas
        sql &= " Producto, DescripcionIngles, Cas"
        sql &= ") VALUES (" & valores & ""
        sql &= " '" & txtCodigo.Text & "', '" & txtDescIngles.Text.Trim & "', '" & txtCas.Text.Trim & "')"
        Return sql
    End Function

    Private Function _PrepararAltaPrimeraVersionFormatoViejoIII() As String
        Dim sql As String

        sql = "INSERT INTO EspecificacionesUnificaIII ("

        Dim columnas As String = ""
        Dim valores As String = ""

        For i = 21 To 30

            columnas &= "Ensayo" & i & ","
            columnas &= "Valor" & i & ","
            columnas &= "Desde" & i & ","
            columnas &= "Hasta" & i & ","

        Next

        For i = 21 To 30
            With dgvEspecif.Rows(i - 1)
                valores &= "'" & Trim(OrDefault(.Cells("Ensayo").Value, "")) & "',"
                valores &= "'" & Trim(OrDefault(.Cells("DescEnsayo").Value, "")) & "',"
                valores &= "'" & Trim(OrDefault(.Cells("DesdeEspecif").Value, "")) & "',"
                valores &= "'" & Trim(OrDefault(.Cells("HastaEspecif").Value, "")) & "',"
            End With
        Next

        txtCondicionMuestreo.Text = txtCondicionMuestreo.Text.PadRight(150, " ")
        Dim WCondicion As String = txtCondicionMuestreo.Text

        sql &= columnas
        sql &= " Producto, Muestreo, MuestreoII, MuestreoIII"
        sql &= ") VALUES (" & valores & ""
        sql &= " '" & txtCodigo.Text & "', '" & WCondicion.left(50).Trim & "', '" & Mid(WCondicion, 51, 50).Trim & "', '" & WCondicion.right(50).Trim & "')"
        Return sql
    End Function

    Private Function _PrepararSinActualizacionVersionFormatoViejo() As String

        Dim columnas As String = ""

        For i = 1 To 20
            With dgvEspecif.Rows(i - 1)
                columnas &= "Ensayo" & i & " = '" & Trim(OrDefault(.Cells("Ensayo").Value, "")) & "',"
                columnas &= "Valor" & i & "  = '" & Trim(OrDefault(.Cells("DescEnsayo").Value, "")) & "',"
                columnas &= "Desde" & i & "  = '" & Trim(OrDefault(.Cells("DesdeEspecif").Value, "")) & "',"
                columnas &= "Hasta" & i & "  = '" & Trim(OrDefault(.Cells("HastaEspecif").Value, "")) & "',"
            End With
        Next

        Return String.Format("UPDATE EspecificacionesUnifica SET {0} WDate = '{1}', Fecha = '{2}', Operador = '{3}', ControlCambio = '{4}'" _
                             & "WHERE Producto = '{5}'", columnas, Date.Now.ToString("MM-dd-yyyy"), Date.Now.ToString("dd/MM/yyyy"),
                             IDOperadorGrabacion, txtControlCambios.Text.Trim, txtCodigo.Text)
    End Function

    Private Function _PrepararActualizacionVersionFormatoViejo() As String

        Dim columnas As String = ""

        For i = 1 To 20
            With dgvEspecif.Rows(i - 1)
                columnas &= "Ensayo" & i & " = '" & Trim(OrDefault(.Cells("Ensayo").Value, "")) & "',"
                columnas &= "Valor" & i & "  = '" & Trim(OrDefault(.Cells("DescEnsayo").Value, "")) & "',"
                columnas &= "Desde" & i & "  = '" & Trim(OrDefault(.Cells("DesdeEspecif").Value, "")) & "',"
                columnas &= "Hasta" & i & "  = '" & Trim(OrDefault(.Cells("HastaEspecif").Value, "")) & "',"
            End With
        Next

        Return String.Format("UPDATE EspecificacionesUnifica SET {0} WDate = '{1}', Version = Version + 1, Fecha = '{2}', Operador = '{3}'," _
                             & "ControlCambio = '{4}' WHERE Producto = '{5}'", columnas, Date.Now.ToString("MM-dd-yyyy"),
                             Date.Now.ToString("dd/MM/yyyy"), IDOperadorGrabacion, txtControlCambios.Text.Trim, txtCodigo.Text)
    End Function

    Private Function _PrepararAltaPrimeraVersionFormatoViejo() As String
        Dim sql As String

        sql = "INSERT INTO EspecificacionesUnifica ("

        Dim columnas As String = ""
        Dim valores As String = ""

        For i = 1 To 20

            columnas &= "Ensayo" & i & ","
            columnas &= "Valor" & i & ","
            columnas &= "Desde" & i & ","
            columnas &= "Hasta" & i & ","

        Next

        For i = 1 To 20
            With dgvEspecif.Rows(i - 1)
                valores &= "'" & Trim(OrDefault(.Cells("Ensayo").Value, "")) & "',"
                valores &= "'" & Trim(OrDefault(.Cells("DescEnsayo").Value, "")) & "',"
                valores &= "'" & Trim(OrDefault(.Cells("DesdeEspecif").Value, "")) & "',"
                valores &= "'" & Trim(OrDefault(.Cells("HastaEspecif").Value, "")) & "',"
            End With
        Next

        sql &= columnas
        sql &= "[Version], Producto, WDate, FechaInicio, FechaFinal, ControlCambio, Operador"
        sql &= ") VALUES (" & valores & ""
        sql &= " Version = 1, '" & txtCodigo.Text & "', '" & Date.Now.ToString("MM-dd-yyyy") & "', Fecha, '" & Date.Now.ToString("dd/MM/yyyy") & "', '" _
                         & txtControlCambios.Text.Trim & "', '" & IDOperadorGrabacion & "')"
        Return sql
    End Function

    Private Function _PrepararGuardarVersionFormatoViejoI() As String
        Dim sql As String

        sql = "INSERT INTO EspecificacionesUnificaVersion ("

        Dim columnas As String = ""
        Dim valores As String = ""

        For i = 1 To 20

            columnas &= "Ensayo" & i & ","
            valores &= "Ensayo" & i & ","

            If i > 10 Then
                columnas &= "ZValor" & (i - 10) & ","
            Else
                columnas &= "Valor" & i & ","
            End If

            valores &= "Valor" & i & ","

            columnas &= "Desde" & i & ","
            valores &= "Desde" & i & ","

            columnas &= "Hasta" & i & ","
            valores &= "Hasta" & i & ","

        Next

        sql &= columnas
        sql &= "Clave, [Version], Producto, WDate, FechaInicio, FechaFinal, ControlCambio"
        sql &= ") SELECT "
        sql &= valores
        sql &= "FORMAT([Version], '0000') + '' + Producto, [Version], Producto, '" & Date.Now.ToString("MM-dd-yyyy") & "', Fecha," _
                & "'" & Date.Now.ToString("dd/MM/yyyy") & "', ControlCambio"
        sql &= " FROM EspecificacionesUnifica WHERE Producto = '" & txtCodigo.Text & "'"

        Return sql

    End Function

    Private Function _PrepararGuardarVersionFormatoViejoII() As String
        Dim sql As String

        sql = "INSERT INTO EspecificacionesUnificaVersionII ("

        Dim columnas As String = ""

        For i = 21 To 30

            columnas &= "Ensayo" & i & ","
            columnas &= "Valor" & i & ","
            columnas &= "Desde" & i & ","
            columnas &= "Hasta" & i & ","

        Next

        sql &= columnas
        sql &= "Clave, [Version], Producto"
        sql &= ") SELECT "
        sql &= columnas
        sql &= "FORMAT(EspecificacionesUnifica.[Version], '0000') + '' + EspecificacionesUnifica.Producto, "
        sql &= "EspecificacionesUnifica.[Version], EspecificacionesUnifica.Producto"
        sql &= " FROM EspecificacionesUnificaIII INNER JOIN EspecificacionesUnifica ON "
        sql &= "EspecificacionesUnifica.Producto = EspecificacionesUnificaIII.Producto WHERE EspecificacionesUnificaIII.Producto = '" & txtCodigo.Text & "'"
        Return sql

    End Function

    Private Sub btnConsultas_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnConsultas.Click
        With New ListaConsultas("Materias Primas", "Ensayos")
            .Show(Me)
        End With
    End Sub

    Public Sub _ProcesarListaConsultas(ByVal Opcion As Integer) Implements IListaConsultas._ProcesarListaConsultas

        Select Case Opcion
            Case 0
                With New AyudaMPs
                    .Show(Me)
                End With
            Case 1
                With New AyudaEnsayos
                    .Show(Me)
                End With
        End Select

    End Sub

    Public Sub _ProcesarAyudaMPs(ByVal Codigo As String, ByVal WDescripcion As String) Implements IAyudaMPs._ProcesarAyudaMPs
        txtCodigo.Text = Codigo
        txtCodigo_KeyDown(Nothing, New KeyEventArgs(Keys.Enter))
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

    Private Sub IngresoEspecificacionesPT_Shown(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Shown
        txtCodigo.Focus()
    End Sub

    Public Sub _ProcesarIngresoClaveSeguridad(ByVal WClave As Object) Implements IIngresoClaveSeguridad._ProcesarIngresoClaveSeguridad
        Dim WOperador As DataRow = GetSingle("SELECT Operador, GrabaII FROM Operador WHERE UPPER(Clave) = '" & WClave & "'")

        Dim WGrabaII As String = ""

        IDOperadorGrabacion = 0

        If WOperador IsNot Nothing Then
            WGrabaII = UCase(Trim(OrDefault(WOperador.Item("GrabaII"), "")))
            IDOperadorGrabacion = WOperador.Item("Operador")
        End If

        Select Case WTipoProceso

            Case TipoProcesosIngEspecif.GrabaVersion

                WAutorizado = WGrabaII = "S"

                btnGrabar.PerformClick()

        End Select

    End Sub

    Private Sub dgvEspecif_RowHeaderMouseDoubleClick(ByVal sender As Object, ByVal e As DataGridViewCellMouseEventArgs) Handles dgvEspecif.RowHeaderMouseDoubleClick
        If e.RowIndex < 0 Then Exit Sub

        If MsgBox("¿Seguro de querer eliminar este Ensayo?", MsgBoxStyle.YesNo) <> MsgBoxResult.Yes Then Exit Sub

        Dim rIndex As Integer

        With dgvEspecif
            rIndex = .CurrentRow.Index
            dgvEspecifIngles.Rows.RemoveAt(rIndex)
            .Rows.Remove(.CurrentRow)
            _OrdenarNroRenglon()
            _OrdenarNroRenglonIngles()
            If .Rows.Count = 0 Then .Rows.Add("1")
            If dgvEspecifIngles.Rows.Count = 0 Then dgvEspecifIngles.Rows.Add("1")
        End With

    End Sub

    Private Sub _OrdenarNroRenglon()
        Dim WNroRenglon As Integer = 1

        For Each Row As DataGridViewRow In dgvEspecif.Rows
            Row.Cells("NroRenglon").Value = WNroRenglon
            WNroRenglon += 1
        Next

        'Nos movemos para que el cambio se vea
        Dim _rRenglon As Integer
        If dgvEspecif.CurrentRow IsNot Nothing Then
            _rRenglon = dgvEspecif.CurrentRow.Index
        End If
        If dgvEspecif.Rows.Count <> 0 Then
            dgvEspecif.CurrentCell = dgvEspecif.Rows(_rRenglon).Cells(2)
            dgvEspecif.CurrentCell = dgvEspecif.Rows(_rRenglon).Cells(1)
        End If


    End Sub


    Private Sub _OrdenarNroRenglonIngles()
        Dim WNroRenglon As Integer = 1

        For Each Row As DataGridViewRow In dgvEspecifIngles.Rows
            Row.Cells("NroRenglonIngles").Value = WNroRenglon
            WNroRenglon += 1
        Next

        'Nos movemos para que el cambio se vea
        Dim _rRenglon As Integer
        If dgvEspecifIngles.CurrentRow IsNot Nothing Then
            _rRenglon = dgvEspecifIngles.CurrentRow.Index
        End If
        If dgvEspecifIngles.Rows.Count <> 0 Then
            dgvEspecifIngles.CurrentCell = dgvEspecifIngles.Rows(_rRenglon).Cells(2)
            dgvEspecifIngles.CurrentCell = dgvEspecifIngles.Rows(_rRenglon).Cells(1)
        End If

    End Sub

    Private Function _EsNumero(ByVal keycode As Integer) As Boolean
        Return (keycode >= 48 And keycode <= 57) Or (keycode >= 96 And keycode <= 105)
    End Function

    Private Function _EsControl(ByVal keycode) As Boolean
        Dim valido As Boolean

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
        Return _EsNumero(CInt(keycode)) Or _EsControl(keycode)
    End Function

    Private Function _EsDecimalOControl(ByVal keycode) As Boolean
        Return _EsDecimal(CInt(keycode)) Or _EsControl(keycode)
    End Function

    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, ByVal keyData As Keys) As Boolean

        With dgvEspecif
            If .Focused Or .IsCurrentCellInEditMode Then ' Detectamos los ENTER tanto si solo estan en foco o si estan en edición una celda.
                .CommitEdit(DataGridViewDataErrorContexts.Commit) ' Guardamos todos los datos que no hayan sido confirmados.

                Dim iCol = .CurrentCell.ColumnIndex
                Dim iRow = .CurrentCell.RowIndex
                Dim valor As String = OrDefault(.CurrentCell.Value, "")

                ' Limitamos los caracteres permitidos para cada una de las columnas.
                Select Case iCol
                    Case 1
                        If Not _EsNumeroOControl(keyData) Then
                            Return True
                        End If
                    Case -1
                        If Not _EsDecimalOControl(keyData) Then
                            Return True
                        End If

                End Select

                If msg.WParam.ToInt32() = Keys.Enter Then


                    Select Case iCol
                        Case 1

                            If Val(valor) = 0 Then Return True

                            Dim WEnsayo As DataRow = GetSingle("SELECT Descripcion FROM Ensayos WHERE Codigo = '" & valor & "'", "Surfactan_II")

                            If WEnsayo Is Nothing Then Return True

                            .Rows(iRow).Cells("Especificacion").Value = Trim(OrDefault(WEnsayo.Item("Descripcion"), ""))

                    End Select


                    Select Case iCol
                        Case 3

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

                    If iCol = 1 Then

                        .Rows(iRow).Cells(iCol).Value = ""

                        If iCol = 3 Then
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

    Private Sub btnHistorialCambios_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnHistorialCambios.Click

        With New HistorialCambios("M", txtCodigo.Text)
            .Show(Me)
        End With

    End Sub

    Private Sub btnAgregarRenglon_Click(sender As Object, e As EventArgs) Handles btnAgregarRenglon.Click
        With dgvEspecif
            If .SelectedRows.Count = 1 Then
                Dim DesdeRenglon As Integer = .CurrentRow.Index
                _MoverDatosGrillaUnRenglon(DesdeRenglon)
                _MoverDatosGrillaINGLESUnRenglon(DesdeRenglon)
                .CurrentCell = .Rows(DesdeRenglon + 1).Cells(0)
                .Focus()
            End If
        End With
    End Sub

    Private Sub _MoverDatosGrillaUnRenglon(ByVal DesdeRenglon As Integer)
        Dim indexAnterior = dgvEspecif.Rows.Count - 1
        dgvEspecif.Rows.Add()
        Dim IndexDondeCopio As Integer = dgvEspecif.Rows.Count - 1
        Do
            Dim WFilaDondeCopio As DataGridViewRow = dgvEspecif.Rows(IndexDondeCopio)

            With WFilaDondeCopio
                If DesdeRenglon = indexAnterior Then
                    .Cells("NroRenglon").Value = DesdeRenglon + 2

                    For Each c As String In {"Ensayo", "Especificacion", "DescEnsayo", "Farmacopea", "TipoEspecif", "DesdeEspecif",
                                             "HastaEspecif", "UnidadEspecif", "MenorIgualEspecif", "InformaEspecif", "Parametro",
                                             "FormulaEspecif", "Variable1", "Variable2", "Variable3", "Variable4", "Variable5",
                                             "Variable6", "Variable7", "Variable8", "Variable9", "Variable10"}
                        .Cells(c).Value = ""
                    Next

                    Exit Do

                Else

                    Dim WFilaDesdeDondeCopio As DataGridViewRow = dgvEspecif.Rows(indexAnterior)

                    .Cells("NroRenglon").Value = WFilaDesdeDondeCopio.Cells("NroRenglon").Value + 1
                    .Cells("Ensayo").Value = WFilaDesdeDondeCopio.Cells("Ensayo").Value
                    .Cells("Especificacion").Value = WFilaDesdeDondeCopio.Cells("Especificacion").Value
                    .Cells("DescEnsayo").Value = WFilaDesdeDondeCopio.Cells("DescEnsayo").Value
                    .Cells("Farmacopea").Value = WFilaDesdeDondeCopio.Cells("Farmacopea").Value
                    .Cells("TipoEspecif").Value = WFilaDesdeDondeCopio.Cells("TipoEspecif").Value
                    .Cells("DesdeEspecif").Value = WFilaDesdeDondeCopio.Cells("DesdeEspecif").Value
                    .Cells("HastaEspecif").Value = WFilaDesdeDondeCopio.Cells("HastaEspecif").Value
                    .Cells("UnidadEspecif").Value = WFilaDesdeDondeCopio.Cells("UnidadEspecif").Value()
                    .Cells("MenorIgualEspecif").Value = WFilaDesdeDondeCopio.Cells("MenorIgualEspecif").Value
                    .Cells("InformaEspecif").Value = WFilaDesdeDondeCopio.Cells("InformaEspecif").Value
                    .Cells("Parametro").Value = WFilaDesdeDondeCopio.Cells("Parametro").Value
                    .Cells("FormulaEspecif").Value = WFilaDesdeDondeCopio.Cells("FormulaEspecif").Value
                    .Cells("Variable1").Value = WFilaDesdeDondeCopio.Cells("Variable1").Value
                    .Cells("Variable2").Value = WFilaDesdeDondeCopio.Cells("Variable2").Value
                    .Cells("Variable3").Value = WFilaDesdeDondeCopio.Cells("Variable3").Value
                    .Cells("Variable4").Value = WFilaDesdeDondeCopio.Cells("Variable4").Value
                    .Cells("Variable5").Value = WFilaDesdeDondeCopio.Cells("Variable5").Value
                    .Cells("Variable6").Value = WFilaDesdeDondeCopio.Cells("Variable6").Value
                    .Cells("Variable7").Value = WFilaDesdeDondeCopio.Cells("Variable7").Value
                    .Cells("Variable8").Value = WFilaDesdeDondeCopio.Cells("Variable8").Value
                    .Cells("Variable9").Value = WFilaDesdeDondeCopio.Cells("Variable9").Value
                    .Cells("Variable10").Value = WFilaDesdeDondeCopio.Cells("Variable10").Value

                    indexAnterior -= 1
                    IndexDondeCopio -= 1

                End If

            End With

        Loop

    End Sub

    Private Sub _MoverDatosGrillaINGLESUnRenglon(ByVal DesdeRenglon As Integer)
        Dim indexAnterior = dgvEspecifIngles.Rows.Count - 1
        dgvEspecifIngles.Rows.Add()
        Dim IndexDondeCopio As Integer = dgvEspecifIngles.Rows.Count - 1
        Do
            Dim WDondeCopio As DataGridViewRow = dgvEspecifIngles.Rows(IndexDondeCopio)
            If DesdeRenglon = indexAnterior Then

                WDondeCopio.Cells("NroRenglonIngles").Value = DesdeRenglon + 2
                WDondeCopio.Cells("EnsayoIngles").Value = ""
                WDondeCopio.Cells("EspecificacionIngles").Value = ""
                WDondeCopio.Cells("DescEnsayoIngles").Value = ""
                WDondeCopio.Cells("FarmacopeaIngles").Value = ""
                WDondeCopio.Cells("UnidadEspecifIngles").Value = ""

                Exit Do

            Else

                Dim WDesdeDondeCopio As DataGridViewRow = dgvEspecifIngles.Rows(indexAnterior)

                WDondeCopio.Cells("NroRenglonIngles").Value = WDesdeDondeCopio.Cells("NroRenglonIngles").Value + 1
                WDondeCopio.Cells("EnsayoIngles").Value = WDesdeDondeCopio.Cells("EnsayoIngles").Value
                WDondeCopio.Cells("EspecificacionIngles").Value = WDesdeDondeCopio.Cells("EspecificacionIngles").Value
                WDondeCopio.Cells("DescEnsayoIngles").Value = WDesdeDondeCopio.Cells("DescEnsayoIngles").Value
                WDondeCopio.Cells("FarmacopeaIngles").Value = WDesdeDondeCopio.Cells("FarmacopeaIngles").Value
                WDondeCopio.Cells("UnidadEspecifIngles").Value = WDesdeDondeCopio.Cells("UnidadEspecifIngles").Value()

                indexAnterior -= 1
                IndexDondeCopio -= 1

            End If

        Loop
    End Sub

    Private Sub btnNotas_Click(sender As Object, e As EventArgs) Handles btnNotas.Click
        If txtCodigo.Text.Replace(" ", "").Length = 10 Then
            With New NotasCertificadosAnalisis(txtCodigo.Text, True, PermisoGrabar)
                .Show(Me)
            End With
        End If
    End Sub

    Private Sub btnImpresion_Click(sender As Object, e As EventArgs) Handles btnImpresion.Click
        Dim WArticulo As DataRow = GetSingle("SELECT Codigo FROM Articulo WHERE Codigo = '" & txtCodigo.Text & "'")

        If WArticulo Is Nothing Then Exit Sub

        Dim WCargaV As DataTable = GetAll("SELECT Valor, Clave, MenorIgualEspecif, InformaEspecif, TipoEspecif, UnidadEspecif, DesdeEspecif, HastaEspecif, Farmacopea, InformaEspecif, Ensayo FROM CargaVMP WHERE Articulo = '" & txtCodigo.Text & "' Order by Clave", "Surfactan_II")

        If WCargaV.Rows.Count = 0 Then Exit Sub

        Dim WSqls As New List(Of String)

        WSqls.Add(String.Format("UPDATE CargaVMP SET Partida = '0', ImprePaso = Paso, CantidadPartida = '' WHERE Articulo = '{0}'", txtCodigo.Text))

        For Each row As DataRow In WCargaV.Rows
            Dim WObservacion1 As String

            With row

                WObservacion1 = _GenerarImpreParametro(OrDefault(.Item("DesdeEspecif"), ""), OrDefault(.Item("HastaEspecif"), ""), OrDefault(.Item("UnidadEspecif"), ""), OrDefault(.Item("MenorIgualEspecif"), ""), OrDefault(.Item("InformaEspecif"), ""))

                WSqls.Add(String.Format("UPDATE CargaVMP SET Observacion1 = '{1}' WHERE Clave = '{0}'", .Item("Clave"), _Left(WObservacion1.Trim, 100)))

            End With

        Next

        ExecuteNonQueries("Surfactan_II", WSqls.ToArray)

        With New VistaPrevia
            .Reporte = New ImpreEspecificacionesMP
            .Formula = "{CargaV.Articulo}='" & txtCodigo.Text & "'"
            .Base = "Surfactan_II"
            .Mostrar()
        End With

        Dim WEspecIngles As DataRow = GetSingle("SELECT Clave FROM CargaVMPIngles WHERE Articulo = '" & txtCodigo.Text & "'", "Surfactan_II")

        If WEspecIngles Is Nothing Then Exit Sub

        With New VistaPrevia
            .Base = "Surfactan_II"
            .Reporte = New ImpreEspecificacionesMPIngles
            .Formula = "{CargaV.Articulo}='" & txtCodigo.Text & "'"
            .Mostrar()
        End With
    End Sub
End Class