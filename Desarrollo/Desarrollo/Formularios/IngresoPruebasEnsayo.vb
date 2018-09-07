Imports System.Data.SqlClient
Imports System.IO
Imports Desarrollo.Clases
Imports Microsoft.VisualBasic.FileIO

Public Class IngresoPruebasEnsayo

    Private Const EXTENSIONES_PERMITIDAS = "*.docx|*.doc|*.xls|*.xlsx|*.xlsm|*.pdf|*.bmp|*.png|*.jpg|*.jpeg|*.ico|*.txt"
    Private WAuxiOT = "", WAuxiCargaIII = "", WAuxiCargaV = ""

    Private Sub IngresoOrdenTrabajo_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        For Each dgv As DataGridView In {dgvArchivos, dgvCosto, dgvFormula, dgvLaboratorio, dgvProceso, dgvRevisiones}
            For Each c As DataGridViewColumn In dgv.Columns
                c.SortMode = DataGridViewColumnSortMode.NotSortable
            Next
        Next

        btnLimpiar.PerformClick()
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Close()
    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        
        With cmbPlanta.Items

            .Clear()
            .Add("")

            If Helper._EsPellital Then

                .Add("Planta II")
                .Add("Planta V")

            Else

                .Add("Planta II")
                .Add("Planta I")
                .Add("Planta III")

            End If

        End With

        ' Limpiamos los campos.
        _LimpiarCampos()

        ' Posicionamos en Orden y mostramos la primer pestaña.
        TabControl1.SelectedIndex = 0
        txtOrden.Focus()

    End Sub

    Private Sub _LimpiarCampos()

        For Each _txt As TextBox In _CamposDeTexto()
            _txt.Text = ""
        Next
        
        For Each _m As MaskedTextBox In {txtOrden, txtFecha}
            _m.Clear()
        Next

        For Each _c As ComboBox In {cmbPlanta, cmbTipoCalculo}
            _c.SelectedIndex = 0
        Next

        pnlConsulta.Visible = False
        pnlHojaPiloto.Visible = False
        txtDescripcionHojaPiloto.Text = ""

        For Each grid As DataGridView In {dgvFormula, dgvCosto, dgvProceso, dgvLaboratorio, dgvRevisiones, dgvArchivos}

            With grid
                .Rows.Clear()
                .Rows.Add()
            End With

        Next

        For i As Integer = 0 To 200
            dgvRevisiones.Rows.Add()
        Next

        For Each _nota As RichTextBox In {txtNotasProceso, txtNotasLaboratorio, txtNotasEnsayosAdicionales, txtNotasDocumentacion}
            _nota.LoadFile(Configuration.ConfigurationManager.AppSettings("BUSCAR_NOTAS_1") & "blanco.rtf")
        Next

    End Sub

    Private Function _CamposComentarios() As TextBox()

        Return {txtComentariosI, txtComentariosII, txtComentariosIII, txtComentariosIV, txtComentariosV, _
                txtComentariosVI, txtComentariosVII, txtComentariosVIII, txtComentariosIX, txtComentariosX, _
                txtComentariosXI, txtComentariosXII}
    End Function

    Private Function _CamposRequisitos() As TextBox()

        Return {txtRequisitosI, txtRequisitosII, txtRequisitosIII, txtRequisitosIV, txtRequisitosV, _
                txtRequisitosVI, txtRequisitosVII, txtRequisitosVIII, txtRequisitosIX, txtRequisitosX, _
                txtRequisitosXI, txtRequisitosXII}
    End Function

    Private Function _CamposDeTexto() As TextBox()
        Return {txtVersion, txtCantidad, txtDescripcionHojaPiloto, txtHojaProduccion, txtRealizado, txtRealizadoII, txtAyuda, txtCostoTotal, txtCostoPorKilo}.Union(_CamposRequisitos).ToArray.Union(_CamposComentarios).ToArray
    End Function

    Private Sub txtOrden_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtOrden.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txtOrden.Text.Replace("-", "")) = "" Then : Exit Sub : End If

            Try
                txtOrden.Text = UCase(txtOrden.Text)

                If Trim(txtOrden.Text).Length < 8 Then Exit Sub

                Dim WOrden = txtOrden.Text
                btnLimpiar.PerformClick()
                txtOrden.Text = WOrden

                If Not _ExisteEnsayo() Then

                    txtOrden.Focus()

                    Exit Sub

                End If

                txtVersion.Focus()

            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Exclamation)
            End Try

        ElseIf e.KeyData = Keys.Escape Then
            txtOrden.Text = ""
        End If

    End Sub

    'Private Sub _CargarOrdenTrabajo()
    '    Dim WOrden = txtOrden.Text, WAux = ""
    '    Dim cn As SqlConnection = New SqlConnection()
    '    Dim cm As SqlCommand = New SqlCommand("")
    '    Dim dr As SqlDataReader

    '    Try
    '        btnLimpiar.PerformClick()
    '        txtOrden.Text = WOrden
    '        cn.ConnectionString = Helper._ConectarA
    '        cn.Open()
    '        cm.Connection = cn
    '        cm.CommandText = "SELECT * FROM OrdenTrabajo WHERE Orden = '" & txtOrden.Text & "'"

    '        dr = cm.ExecuteReader()

    '        If dr.HasRows Then

    '            With dr
    '                .Read()

    '                For Each txt As TextBox In _CamposDeTexto()
    '                    txt.Text = Trim(txt.Text)
    '                Next
    '            End With
    '        End If

    '    Catch ex As Exception
    '        Throw New Exception("Hubo un problema al querer consultar la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
    '    Finally

    '        dr = Nothing
    '        cn.Close()
    '        cn = Nothing
    '        cm = Nothing

    '    End Try

    'End Sub

    Private Sub IngresoOrdenTrabajo_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        txtOrden.Focus()
    End Sub

    Private Sub txtFecha_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFecha.KeyDown

        If e.KeyData = Keys.Enter Then

            If txtFecha.Text.estaVacia Then : Exit Sub : End If

            If Helper._ValidarFecha(txtFecha.Text) Then
                txtCantidad.Focus()
            End If

        ElseIf e.KeyData = Keys.Escape Then
            txtFecha.Clear()
        End If

    End Sub


    Private Sub btnConsultas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultas.Click

        Try
            '_CargarClientes()

            pnlConsulta.Visible = True
            lstOpciones.Visible = True
            lstConsulta.Visible = True
            lstFiltrada.Visible = False
            Label16.Visible=False
            txtBuscarEnTodosLosCampos.Visible=False
            txtBuscarEnTodosLosCampos.Text=""
            txtAyuda.Text = ""
            txtAyuda.Focus()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub _CargarClientes()

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("")
        Dim dr As SqlDataReader
        Dim WRazones(), WClaves() As String
        Dim WAux = 0, WClave = "", WRazon = ""

        Try
            WIndice.Items.Clear()
            lstConsulta.Items.Clear()
            lstFiltrada.Items.Clear()

            cn.ConnectionString = Helper._ConectarA()
            cn.Open()
            cm.Connection = cn

            cm.CommandText = "SELECT Count(DISTINCT Cliente) as Total FROM OrdenTrabajo WHERE Cliente <> '' AND Cliente IS NOT NULL"

            dr = cm.ExecuteReader

            If dr.HasRows Then

                dr.Read()

                ReDim WRazones(dr.Item("Total") - 1)
                ReDim WClaves(dr.Item("Total") - 1)

            Else
                Exit Sub
            End If

            If Not dr.IsClosed Then
                dr.Close()
            End If

            cm.CommandText = "SELECT DISTINCT OT.Cliente, C.Razon FROM OrdenTrabajo as OT FULL OUTER JOIN Cliente as C ON OT.Cliente = C.Cliente WHERE Ot.Cliente <> ''"

            dr = cm.ExecuteReader()

            If dr.HasRows Then

                Do While dr.Read()

                    WClave = ""
                    WRazon = ""

                    With dr

                        WRazon = IIf(IsDBNull(.Item("Razon")), "", .Item("Razon"))
                        WClave = IIf(IsDBNull(.Item("Cliente")), "", .Item("Cliente"))

                        WRazones(WAux) = UCase(Trim(WClave)) & Space(5) & Trim(WRazon)
                        WClaves(WAux) = WClave

                        WAux += 1

                    End With

                Loop

                lstConsulta.Items.AddRange(WRazones)
                WIndice.Items.AddRange(WClaves)

            End If

        Catch ex As Exception
            Throw New Exception("Hubo un problema al querer consultar la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

    End Sub


    ' Rutinas de Filtrado Dinámico.
    Private Sub _FiltrarDinamicamente()
        Dim origen As ListBox = lstConsulta
        Dim final As ListBox = lstFiltrada
        Dim cadena As String = Trim(txtAyuda.Text)

        final.Items.Clear()

        If UCase(Trim(cadena)) <> "" Then

            For Each item In origen.Items

                If UCase(item.ToString()).Contains(UCase(Trim(cadena))) Then

                    final.Items.Add(item)

                End If

            Next

            final.Visible = True
            origen.Visible = False

        Else

            final.Visible = False
            origen.Visible = True

        End If
    End Sub

    Private Sub lstFiltrada_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstFiltrada.MouseClick
        Dim origen As ListBox = lstConsulta
        Dim filtrado As ListBox = lstFiltrada
        Dim texto As TextBox = txtAyuda

        If IsNothing(filtrado.SelectedItem) Then : Exit Sub : End If

        ' Buscamos el texto exacto del item seleccionado y seleccionamos el mismo item segun su indice en la lista de origen.
        origen.SelectedItem = filtrado.SelectedItem

        ' Llamamos al evento que tenga asosiado el control de origen.
        lstConsulta_Click(Nothing, Nothing)


        ' Sacamos de vista los resultados filtrados.
        filtrado.Visible = False
        texto.Text = ""
    End Sub

    Private Sub txtAyuda_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAyuda.TextChanged
        
        '
        ' Filtramos de manera normal sólo por contenido mostrado en pantalla.
        '
        _FiltrarDinamicamente()

        ''
        '' Filtramos por el contenido de todos los campos guardados en el ensayo.
        ''
        '_FiltrarPorTodosLosCampos()

    End Sub

    Private Sub _FiltrarPorTodosLosCampos(ByVal WBuscar As String)
        '
        ' Buscamos todos las Ordenes con sus versiones mas recientes.
        '
        Dim WEnsayos(1,2) As String
        Dim XIndice As Integer = 0
        Dim WBuscarEn As String()

        Dim WObservaciones = "", WCliente = "", WDesCliente = "", WVersion = ""
        Dim WListar As New List(Of Object())

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT COUNT(DISTINCT Orden) Total FROM CargaEnsayo")
        Dim dr As SqlDataReader

        WAuxiOT = ""
        WBuscarEn = New String() {"Observaciones", "Material", "Muestra", "Uso", "DescripcionI", "DescripcionII", "DescripcionIII", "DescripcionIV", "DescripcionV", "ObservacionesI", "ObservacionesII", "ObservacionesIII", "RequisitoI", "RequisitoII", "RequisitoIII", "RequisitoIV", "RequisitoV", "RequisitoVI", "ReferenciaI", "ReferenciaII"}
        For Each WCampo As String In WBuscarEn
            If (WAuxiOT.Trim() <> "") Then WAuxiOT &= " OR "

            WAuxiOT &= "ot." & WCampo & " LIKE '%" & WBuscar.Trim() & "%'"

        Next
        WAuxiOT = WAuxiOT.TrimEnd(",", " ")

        WBuscarEn = New String() {"Etapa", "Instrucciones", "Equipo", "Temperatura", "Tiempo", "Control", "Seguridad"}

        WAuxiCargaIII = ""

        For Each WCampo As String In WBuscarEn
            If (WAuxiCargaIII.Trim() <> "") Then WAuxiCargaIII &= " OR "

            WAuxiCargaIII &= "c3." & WCampo & " LIKE '%" & WBuscar.Trim() & "%'"

        Next

        WAuxiCargaIII = WAuxiCargaIII.TrimEnd(",", " ")

        WBuscarEn = New String() {"Version", "Etapa", "Fecha", "Participantes", "Resultados", "Acciones", "Responsables", "Estado"}

        WAuxiCargaV = ""

        For Each WCampo As String In WBuscarEn
            If (WAuxiCargaV.Trim() <> "") Then WAuxiCargaV &= " OR "

            WAuxiCargaV &= "c5." & WCampo & " LIKE '%" & WBuscar.Trim() & "%'"

        Next

        WAuxiCargaV = WAuxiCargaV.TrimEnd(",", " ")

        Try
            Enabled = False
            Opacity = 90

            cn.ConnectionString = Helper._ConectarA
            cn.Open()
            cm.Connection = cn

            dr = cm.ExecuteReader()

            Array.Clear(WEnsayos, 0, WEnsayos.Length)

            If dr.HasRows Then
                dr.Read()

                '
                ' Redimensiono el array para el total de Ensayos.
                '
                ReDim WEnsayos(dr.Item("Total"), 2)

                If Not dr.IsClosed Then dr.Close()

                cm.CommandText = "SELECT Orden, Max(Version) Version FROM CargaEnsayo GROUP BY Orden ORDER BY Orden"
                dr = cm.ExecuteReader()

                If dr.HasRows Then

                    '
                    ' Cargo el array con los datos de los ensayos y sus versiones mas actuales.
                    '
                    XIndice = 0

                    While dr.Read()
                        XIndice += 1
                        WEnsayos(XIndice, 1) = dr.Item("Orden")
                        WEnsayos(XIndice, 2) = dr.Item("Version")
                    End While

                    'For i = 0 to XIndice

                    If Not dr.IsClosed Then dr.Close()

                    '
                    ' Busco coincidencias en OrdenTrabajo
                    '

                    cm.CommandText = "SELECT ot.Orden, ot.Observaciones, ot.Cliente, ISNULL(Cliente.Razon, '') as DesCliente, Max(ce.Version) Version FROM OrdenTrabajo ot INNER JOIN CargaEnsayo ce ON ot.Orden = ce.Orden LEFT OUTER JOIN Cliente ON ot.Cliente = Cliente.Cliente WHERE " & WAuxiOT & " GROUP BY ot.Orden, ot.Observaciones, ot.Cliente, Cliente.Razon"

                    dr = cm.ExecuteReader

                    If dr.HasRows Then

                        While dr.Read()

                            WObservaciones = dr.Item("Observaciones")
                            WCliente = dr.Item("Cliente")
                            WDesCliente = dr.Item("DesCliente")
                            WVersion = dr.Item("Version")

                            WListar.Add({dr.Item("Orden"), WVersion, WObservaciones, WCliente, WDesCliente})

                        End While

                    End If

                    If Not dr.IsClosed Then dr.Close()

                    '
                    ' Busco Coincidencias en CargaEnsayosIII
                    '

                    cm.CommandText = "SELECT c3.Orden, c3.Version, ISNULL(ot.Observaciones, '') Observaciones, ISNULL(ot.Cliente, '') Cliente, ISNULL(cli.Razon, '') DesCliente FROM CargaEnsayoIII c3 INNER JOIN (SELECT Orden, MAX(Version) Actual FROM CargaEnsayo GROUP BY Orden) ce ON c3.Orden = ce.Orden LEFT OUTER JOIN OrdenTrabajo ot ON c3.Orden = ot.Orden LEFT OUTER JOIN Cliente cli ON ot.Cliente = cli.Cliente WHERE c3.Version = ce.Actual AND " & WAuxiCargaIII

                    dr = cm.ExecuteReader

                    If dr.HasRows Then

                        While dr.Read()
                            WObservaciones = dr.Item("Observaciones")
                            WCliente = dr.Item("Cliente")
                            WDesCliente = dr.Item("DesCliente")
                            WVersion = dr.Item("Version")

                            If Not WListar.Exists(Function(x) x(0) = dr.Item("Orden")) Then WListar.Add({dr.Item("Orden"), WVersion, WObservaciones, WCliente, WDesCliente})
                        End While

                    End If

                    If Not dr.IsClosed Then dr.Close()
                    '
                    ' Busco Coincidencias en CargaEnsayoV.
                    '

                    cm.CommandText = "SELECT c5.Orden, ce.Actual as Version, ISNULL(ot.Observaciones, '') Observaciones, ISNULL(ot.Cliente, '') Cliente, ISNULL(cli.Razon, '') DesCliente FROM CargaEnsayoV c5 INNER JOIN (SELECT Orden, Max(Version) Actual FROM CargaEnsayo GROUP BY Orden) ce ON c5.Orden = ce.Orden LEFT OUTER JOIN OrdenTrabajo ot ON c5.Orden = ot.Orden LEFT OUTER JOIN Cliente cli ON ot.Cliente = cli.Cliente WHERE " & WAuxiCargaV

                    dr = cm.ExecuteReader

                    If dr.HasRows Then
                        While dr.Read()
                            WObservaciones = dr.Item("Observaciones")
                            WCliente = dr.Item("Cliente")
                            WDesCliente = dr.Item("DesCliente")
                            WVersion = dr.Item("Version")

                            If Not WListar.Exists(Function(x) x(0) = dr.Item("Orden")) Then WListar.Add({dr.Item("Orden"), WVersion, WObservaciones, WCliente, WDesCliente})
                        End While
                    End If

                    'Next

                    Dim WTemp = ""
                    lstConsulta.Items.Clear()
                    WIndice.Items.Clear()

                    If WListar.Count > 0 Then

                        For Each WEnsayo As Object In WListar.OrderBy(Function(x) x(0)).ToList

                            WTemp = WEnsayo(0).trim() & "/" & WEnsayo(1).trim() ' Orden / Version
                            WIndice.Items.Add(WTemp)

                            lstConsulta.Items.Add(WTemp.PadRight(15) & Space(5) & WEnsayo(2).trim() & Space(5) & WEnsayo(4).trim())

                        Next

                    End If

                End If

            End If

        Catch ex As Exception
            Throw New Exception("Hubo un problema al querer consultar la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

        Enabled = True
        Opacity = 100
        
    End Sub

    Private Sub lstConsulta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstConsulta.Click

        Try
            Dim WValor As String = lstConsulta.SelectedItem

            If IsNothing(WValor) OrElse Trim(WValor) = "" Then Exit Sub

            If lstOpciones.SelectedIndex = 0 Then
                Dim WOrden = "", WVersion = ""

                WOrden = WValor.SliceLeft(8)
                WVersion = WValor.Substring(9, 4)

                txtOrden.Text = WOrden
                txtVersion.Text = Val(WVersion)

                txtVersion_KeyDown(Nothing, New KeyEventArgs(Keys.Enter))

            ElseIf lstOpciones.SelectedIndex = 1 Then

                If WIndice.Items.Count > 0 Then

                    WValor = WValor.Substring(0, 6)

                    _CargarOrdenesTrabajoParaCliente(WValor)

                    WIndice.Items.Clear()

                    txtAyuda.Text = ""
                    txtAyuda.Focus()

                    Exit Sub

                Else

                    Dim WOrden = "", WVersion = ""

                    WOrden = WValor.SliceLeft(8)
                    WVersion = WValor.Substring(9, 4)

                    txtOrden.Text = WOrden
                    txtVersion.Text = Val(WVersion)

                    txtVersion_KeyDown(Nothing, New KeyEventArgs(Keys.Enter))

                End If

            End If

            btnCerrarConsulta.PerformClick()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub _CargarOrdenesTrabajoParaCliente(ByVal wValor As String)
        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand()
        Dim dr As SqlDataReader
        Dim WTemp = "", WOrden = "", WVersion = "", WObservaciones = "", WDescCliente = ""
        Dim WItem As String = ""

        Try
            lstConsulta.Items.Clear()
            WIndice.Items.Clear()

            cn.ConnectionString = Helper._ConectarA
            cn.Open()
            cm.Connection = cn

            cm.CommandText = "SELECT CE.Orden, CE.Version, OT.Observaciones, ISNULL(C.Razon, '') " _
                                              & " as DesCliente FROM CargaEnsayo as CE, OrdenTrabajo as OT " _
                                              & " FULL OUTER JOIN Cliente as C ON OT.Cliente = C.Cliente WHERE CE.Orden <> '  -     ' " _
                                              & " AND OT.Cliente = '" & wValor & "' AND CE.Orden = OT.Orden ORDER BY CE.Clave, ce.Orden, ce.Version"
            dr = cm.ExecuteReader()

            If dr.HasRows Then

                Do While dr.Read()

                    WItem = ""
                    WTemp = ""

                    WOrden = IIf(IsDBNull(dr.Item("Orden")), "", dr.Item("Orden"))
                    WVersion = IIf(IsDBNull(dr.Item("Version")), "", dr.Item("Version"))
                    WObservaciones = IIf(IsDBNull(dr.Item("Observaciones")), "", dr.Item("Observaciones"))
                    WDescCliente = IIf(IsDBNull(dr.Item("DesCliente")), "", dr.Item("DesCliente"))

                    WTemp = Trim(WOrden) & "/" & Trim(WVersion)

                    WItem = WTemp.PadRight(15) & Space(5) & Trim(WObservaciones)

                    If Trim(WDescCliente) <> "" Then
                        WItem &= Space(5) & "(" & Trim(WDescCliente) & ")"
                    End If

                    lstConsulta.Items.Add(WItem)
                    WIndice.Items.Add(WTemp)

                Loop

            End If

        Catch ex As Exception
            Throw New Exception("Hubo un problema al querer consultar la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrarConsulta.Click
        pnlConsulta.Visible = False
        lstConsulta.Visible = True
        lstOpciones.Visible = True
        lstFiltrada.Visible = False
        txtAyuda.Text = ""
        'txtObservaciones.Focus()
    End Sub

    'Private Sub btnNotasAplicacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    '    Dim WArchivo1 = Configuration.ConfigurationManager.AppSettings("BUSCAR_NOTAS_1") & "A" & txtOrden.Text.Trim & ".rtf"
    '    Dim WArchivo2 = Configuration.ConfigurationManager.AppSettings("BUSCAR_NOTAS_2") & "A" & txtOrden.Text.Trim & ".rtf"

    '    ' Varificamos los dos destinos, ya que dependiendo donde se haya grabado puede existir en alguno de estos dos lugares.
    '    If File.Exists(WArchivo1) Then

    '        txtNota.LoadFile(WArchivo1)

    '    ElseIf File.Exists(WArchivo2) Then

    '        txtNota.LoadFile(WArchivo2)
    '    Else

    '        txtNota.LoadFile(Configuration.ConfigurationManager.AppSettings("BUSCAR_NOTAS_1") & "Blanco.rtf")

    '    End If

    '    rbAplicacion.Checked = True
    '    pnlNotas.Visible = True

    'End Sub

    'Private Sub btnCerrarNota_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrarNota.Click

    '    Try
    '        ' Para mantener compatibilidad con sistema Viejo.
    '        Dim WArchivo = Configuration.ConfigurationManager.AppSettings("BUSCAR_NOTAS_1")
    '        Dim WArchivo2 = Configuration.ConfigurationManager.AppSettings("BUSCAR_NOTAS_2")

    '        If rbAplicacion.Checked Then

    '            WArchivo &= "A"
    '            WArchivo2 &= "A"

    '        ElseIf rbEstabilidad.Checked Then

    '            WArchivo &= "E"
    '            WArchivo2 &= "E"

    '        Else
    '            Exit Sub
    '        End If

    '        WArchivo &= txtOrden.Text & ".rtf"
    '        WArchivo2 &= txtOrden.Text & ".rtf"

    '        txtNota.SaveFile(WArchivo)
    '        txtNota.SaveFile(WArchivo2)

    '    Catch ex As Exception
    '        MsgBox(ex.Message, MsgBoxStyle.Exclamation)
    '    End Try

    '    pnlNotas.Visible = False
    'End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click

        'Try
        If Trim(txtOrden.Text).Replace("-", "") = "" OrElse Trim(txtOrden.Text).Length < 8 Then Exit Sub

        ' Eliminamos las comas que pudiesen existir para que no rompa la Consulta SQL.
        For Each txt As TextBox In _CamposDeTexto()
            txt.Text = txt.Text.Replace(",", " ")
        Next

        GuardarVersionDeOrdenTrabajo()

        btnLimpiar.PerformClick()

        'Catch ex As Exception
        '    MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        'End Try

    End Sub

    Private Sub GuardarVersionDeOrdenTrabajo()
        Dim WOrden = "", WVersion = "", WOrdFecha = ""
        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("")
        Dim trans As SqlTransaction = Nothing
        Dim ZSql = "", WClave = ""

        'Try

        cn.ConnectionString = Helper._ConectarA
        cn.Open()
        trans = cn.BeginTransaction
        cm.Connection = cn
        cm.Transaction = trans

        ' Limpiamos la información de la versión anteriormente guardada.
        cm.CommandText = "DELETE CargaEnsayo WHERE Orden = '" & txtOrden.Text & "' AND Version = '" & txtVersion.Text & "'"
        cm.ExecuteNonQuery()

        cm.CommandText = "DELETE CargaEnsayoII WHERE Orden = '" & txtOrden.Text & "' AND Version = '" & txtVersion.Text & "'"
        cm.ExecuteNonQuery()

        cm.CommandText = "DELETE CargaEnsayoIII WHERE Orden = '" & txtOrden.Text & "' AND Version = '" & txtVersion.Text & "'"
        cm.ExecuteNonQuery()

        cm.CommandText = "DELETE CargaEnsayoIV WHERE Orden = '" & txtOrden.Text & "' AND Version = '" & txtVersion.Text & "'"
        cm.ExecuteNonQuery()

        cm.CommandText = "DELETE CargaEnsayoV WHERE Orden = '" & txtOrden.Text & "'" ' AND Version = '" & txtVersion.Text & "'"
        cm.ExecuteNonQuery()

        cm.CommandText = "DELETE CargaEnsayoVI WHERE Orden = '" & txtOrden.Text & "' AND Version = '" & txtVersion.Text & "'"
        cm.ExecuteNonQuery()

        ' Guardamos los datos generales de la version.

        WOrden = UCase(txtOrden.Text)
        WVersion = Helper.ceros(txtVersion.Text, 4)
        WClave = WOrden & WVersion
        WOrdFecha = Helper.ordenaFecha(txtFecha.Text)

        ZSql = ""
        ZSql = ZSql & "INSERT INTO CargaEnsayo ("
        ZSql = ZSql & "Clave ,"
        ZSql = ZSql & "Orden ,"
        ZSql = ZSql & "Version ,"
        ZSql = ZSql & "Fecha ,"
        ZSql = ZSql & "OrdFecha ,"
        ZSql = ZSql & "Cantidad ,"
        ZSql = ZSql & "Realizado ,"
        ZSql = ZSql & "RealizadoII ,"
        ZSql = ZSql & "Visto )"
        ZSql = ZSql & "Values ("
        ZSql = ZSql & "'" & WClave & "',"
        ZSql = ZSql & "'" & WOrden & "',"
        ZSql = ZSql & "'" & txtVersion.Text & "',"
        ZSql = ZSql & "'" & txtFecha.Text & "',"
        ZSql = ZSql & "'" & WOrdFecha & "',"
        ZSql = ZSql & "'" & txtCantidad.Text & "',"
        ZSql = ZSql & "'" & txtRealizado.Text & "',"
        ZSql = ZSql & "'" & txtRealizadoII.Text & "',"
        ZSql = ZSql & "'" & txtVisto.Text & "')"

        cm.CommandText = ZSql
        cm.ExecuteNonQuery()

        ' Guardamos datos de la Fórmula.
        Dim ZTipo = "", ZArticulo = "", ZTerminado = "", ZDescripcion = "", ZCantidad = "", ZLote = "", ZStock = "", ZCosto = "", ZPartiOri = "", WRenglon = ""
        For Each _row As DataGridViewRow In dgvFormula.Rows

            With _row

                ZTipo = IIf(IsNothing(.Cells("TipoFormula").Value), "", .Cells("TipoFormula").Value)
                ZArticulo = IIf(IsNothing(.Cells("ArticuloFormula").Value), "", .Cells("ArticuloFormula").Value)
                ZTerminado = IIf(IsNothing(.Cells("TerminadoFormula").Value), "", .Cells("TerminadoFormula").Value)
                ZDescripcion = IIf(IsNothing(.Cells("DescripcionFormula").Value), "", .Cells("DescripcionFormula").Value)
                ZCantidad = IIf(IsNothing(.Cells("CantidadFormula").Value), "", .Cells("CantidadFormula").Value)
                ZLote = IIf(IsNothing(.Cells("LoteFormula").Value), "", .Cells("LoteFormula").Value)
                ZStock = IIf(IsNothing(.Cells("StockFormula").Value), "", .Cells("StockFormula").Value)

                ZPartiOri = ""

                If Trim(ZTipo) <> "" And (Trim(ZArticulo) <> "" Or Trim(ZTerminado) <> "") And Trim(ZCantidad) <> "" Then

                    ZCosto = IIf(IsNothing(dgvCosto.Rows(.Index).Cells("CostoCosto").Value), "", Helper.formatonumerico(dgvCosto.Rows(.Index).Cells("CostoCosto").Value))

                    WRenglon = Helper.ceros(.Index + 1, 2)
                    WClave = WOrden & WVersion & WRenglon

                    ZSql = ""
                    ZSql = ZSql + "INSERT INTO CargaEnsayoII ("
                    ZSql = ZSql + "Clave ,"
                    ZSql = ZSql + "Orden ,"
                    ZSql = ZSql + "Version ,"
                    ZSql = ZSql + "Renglon ,"
                    ZSql = ZSql + "Tipo ,"
                    ZSql = ZSql + "Articulo ,"
                    ZSql = ZSql + "Terminado ,"
                    ZSql = ZSql + "Descripcion ,"
                    ZSql = ZSql + "Cantidad ,"
                    ZSql = ZSql + "Costo ,"
                    ZSql = ZSql + "Lote ,"
                    ZSql = ZSql + "Stock ,"
                    ZSql = ZSql + "PartiOri )"
                    ZSql = ZSql + "Values ("
                    ZSql = ZSql + "'" + WClave + "',"
                    ZSql = ZSql + "'" + txtOrden.Text + "',"
                    ZSql = ZSql + "'" + txtVersion.Text + "',"
                    ZSql = ZSql + "'" + Str$(CInt(WRenglon)) + "',"
                    ZSql = ZSql + "'" + ZTipo + "',"
                    ZSql = ZSql + "'" + ZArticulo + "',"
                    ZSql = ZSql + "'" + ZTerminado + "',"
                    ZSql = ZSql + "'" + ZDescripcion + "',"
                    ZSql = ZSql + "'" + ZCantidad + "',"
                    ZSql = ZSql + "'" + ZCosto + "',"
                    ZSql = ZSql + "'" + ZLote + "',"
                    ZSql = ZSql + "'" + ZStock + "',"
                    ZSql = ZSql + "'" + ZPartiOri + "')"

                    cm.CommandText = ZSql
                    cm.ExecuteNonQuery()

                End If

            End With

        Next

        ' Guardamos los datos del Proceso.
        Dim WEtapa = "", WInstrucciones = "", WEquipo = "", WTemperatura = "", WTiempo = "", WControl = "", WSeguridad = ""
        For Each _row As DataGridViewRow In dgvProceso.Rows

            With _row

                WEtapa = IIf(IsNothing(.Cells("ProcesoEtapa").Value), "", .Cells("ProcesoEtapa").Value)
                WInstrucciones = IIf(IsNothing(.Cells("ProcesoDetallesTrabajo").Value), "", .Cells("ProcesoDetallesTrabajo").Value)
                WEquipo = IIf(IsNothing(.Cells("ProcesoEquipo").Value), "", .Cells("ProcesoEquipo").Value)
                WTemperatura = IIf(IsNothing(.Cells("ProcesoTemperatura").Value), "", .Cells("ProcesoTemperatura").Value)
                WTiempo = IIf(IsNothing(.Cells("ProcesoTiempo").Value), "", .Cells("ProcesoTiempo").Value)
                WControl = IIf(IsNothing(.Cells("ProcesoControl").Value), "", .Cells("ProcesoControl").Value)
                WSeguridad = IIf(IsNothing(.Cells("ProcesoSeguridad").Value), "", .Cells("ProcesoSeguridad").Value)

                If WEtapa <> "" Or WInstrucciones <> "" Or WEquipo <> "" Or WTemperatura <> "" Or WTiempo <> "" Or WControl <> "" Or WSeguridad <> "" Then

                    WRenglon = Helper.ceros(.Index + 1, 2)

                    WClave = WOrden & WVersion & WRenglon

                    ZSql = ""
                    ZSql = ZSql & "INSERT INTO CargaEnsayoIII ("
                    ZSql = ZSql & "Clave ,"
                    ZSql = ZSql & "Orden ,"
                    ZSql = ZSql & "Version ,"
                    ZSql = ZSql & "Renglon ,"
                    ZSql = ZSql & "Etapa ,"
                    ZSql = ZSql & "Instrucciones ,"
                    ZSql = ZSql & "Equipo ,"
                    ZSql = ZSql & "Temperatura ,"
                    ZSql = ZSql & "Tiempo ,"
                    ZSql = ZSql & "Control ,"
                    ZSql = ZSql & "Seguridad )"
                    ZSql = ZSql & "Values ("
                    ZSql = ZSql & "'" & WClave & "',"
                    ZSql = ZSql & "'" & txtOrden.Text & "',"
                    ZSql = ZSql & "'" & txtVersion.Text & "',"
                    ZSql = ZSql & "'" & Str$(CInt(WRenglon)) & "',"
                    ZSql = ZSql & "'" & WEtapa & "',"
                    ZSql = ZSql & "'" & WInstrucciones & "',"
                    ZSql = ZSql & "'" & WEquipo & "',"
                    ZSql = ZSql & "'" & WTemperatura & "',"
                    ZSql = ZSql & "'" & WTiempo & "',"
                    ZSql = ZSql & "'" & WControl & "',"
                    ZSql = ZSql & "'" & WSeguridad & "')"

                    cm.CommandText = ZSql
                    cm.ExecuteNonQuery()

                End If

            End With

        Next

        ' Guardamos los datos de Laboratorio.
        Dim WEnsayo = "", WDescripcion = "", WEsperado = "", WResultado = ""
        For Each _row As DataGridViewRow In dgvLaboratorio.Rows

            With _row

                WEnsayo = IIf(IsNothing(.Cells("LaboratorioEnsayo").Value), "", .Cells("LaboratorioEnsayo").Value)
                WDescripcion = IIf(IsNothing(.Cells("LaboratorioDescripcion").Value), "", .Cells("LaboratorioDescripcion").Value)
                WEsperado = IIf(IsNothing(.Cells("LaboratorioRequerido").Value), "", .Cells("LaboratorioRequerido").Value)
                WResultado = IIf(IsNothing(.Cells("LaboratorioResultado").Value), "", .Cells("LaboratorioResultado").Value)

                If WEnsayo <> "" Or WDescripcion <> "" Or WEsperado <> "" Or WResultado <> "" Then

                    WRenglon = Helper.ceros(.Index + 1, 2)

                    WClave = WOrden & WVersion & WRenglon

                    ZSql = ""
                    ZSql = ZSql & "INSERT INTO CargaEnsayoIV ("
                    ZSql = ZSql & "Clave ,"
                    ZSql = ZSql & "Orden ,"
                    ZSql = ZSql & "Version ,"
                    ZSql = ZSql & "Renglon ,"
                    ZSql = ZSql & "Ensayo ,"
                    ZSql = ZSql & "Descripcion ,"
                    ZSql = ZSql & "Esperado ,"
                    ZSql = ZSql & "Resultado )"
                    ZSql = ZSql & "Values ("
                    ZSql = ZSql & "'" & WClave & "',"
                    ZSql = ZSql & "'" & txtOrden.Text & "',"
                    ZSql = ZSql & "'" & txtVersion.Text & "',"
                    ZSql = ZSql & "'" & Str$(CInt(WRenglon)) & "',"
                    ZSql = ZSql & "'" & WEnsayo & "',"
                    ZSql = ZSql & "'" & WDescripcion & "',"
                    ZSql = ZSql & "'" & WEsperado & "',"
                    ZSql = ZSql & "'" & WResultado & "')"

                    cm.CommandText = ZSql
                    cm.ExecuteNonQuery()

                End If

            End With

        Next

        ' Guardamos los datos de Revisiones.
        Dim ZVersion = "", ZEtapa = "", ZFecha = "", ZParticipantes = "", ZResultados = "", ZAcciones = "", ZResponsables = "", ZEstado = ""
        For Each _row As DataGridViewRow In dgvRevisiones.Rows

            With _row

                ZVersion = IIf(IsNothing(.Cells("RevisionesVersion").Value), "", .Cells("RevisionesVersion").Value)
                ZEtapa = IIf(IsNothing(.Cells("RevisionesEtapa").Value), "", .Cells("RevisionesEtapa").Value)
                ZFecha = IIf(IsNothing(.Cells("RevisionesFecha").Value), "", .Cells("RevisionesFecha").Value)
                ZParticipantes = IIf(IsNothing(.Cells("RevisionesParticipantes").Value), "", .Cells("RevisionesParticipantes").Value)
                ZResultados = IIf(IsNothing(.Cells("RevisionesResultados").Value), "", .Cells("RevisionesResultados").Value)
                ZAcciones = IIf(IsNothing(.Cells("RevisionesAcciones").Value), "", .Cells("RevisionesAcciones").Value)
                ZResponsables = IIf(IsNothing(.Cells("RevisionesResponsables").Value), "", .Cells("RevisionesResponsables").Value)
                ZEstado = IIf(IsNothing(.Cells("RevisionesEstado").Value), "", .Cells("RevisionesEstado").Value)

                If ZVersion <> "" Or ZEtapa <> "" Or ZFecha <> "" Or ZParticipantes <> "" Or ZResultados <> "" Or ZAcciones <> "" Or ZResponsables <> "" Or ZEstado <> "" Then

                    WRenglon = Helper.ceros(.Index + 1, 2)
                    WClave = WOrden & WRenglon

                    ZSql = ""
                    ZSql = ZSql + "INSERT INTO CargaEnsayoV ("
                    ZSql = ZSql + "Clave ,"
                    ZSql = ZSql + "Orden ,"
                    ZSql = ZSql + "Renglon ,"
                    ZSql = ZSql + "Version ,"
                    ZSql = ZSql + "Etapa ,"
                    ZSql = ZSql + "Fecha ,"
                    ZSql = ZSql + "Participantes ,"
                    ZSql = ZSql + "Resultados ,"
                    ZSql = ZSql + "Acciones ,"
                    ZSql = ZSql + "Responsables ,"
                    ZSql = ZSql + "Estado )"
                    ZSql = ZSql + "Values ("
                    ZSql = ZSql + "'" + WClave + "',"
                    ZSql = ZSql + "'" + txtOrden.Text + "',"
                    ZSql = ZSql + "'" + Str$(CInt(WRenglon)) + "',"
                    ZSql = ZSql + "'" + ZVersion + "',"
                    ZSql = ZSql + "'" + ZEtapa + "',"
                    ZSql = ZSql + "'" + ZFecha + "',"
                    ZSql = ZSql + "'" + ZParticipantes + "',"
                    ZSql = ZSql + "'" + ZResultados + "',"
                    ZSql = ZSql + "'" + ZAcciones + "',"
                    ZSql = ZSql + "'" + ZResponsables + "',"
                    ZSql = ZSql + "'" + ZEstado + "')"

                    cm.CommandText = ZSql
                    cm.ExecuteNonQuery()

                End If

            End With

        Next

        ' Guardamos los datos de los Requisitos.
        Dim ZRequisito = "", ZInformativo = "", ZAVerificar = "", ZComentario = ""

        For iRow = 1 To 12

            Select Case iRow
                Case 1
                    ZRequisito = txtRequisitosI.Text
                    ZInformativo = "0"
                    ZAVerificar = "0"
                    ZComentario = txtComentariosI.Text
                Case 2
                    ZRequisito = txtRequisitosII.Text
                    ZInformativo = "0"
                    ZAVerificar = "0"
                    ZComentario = txtComentariosII.Text
                Case 3
                    ZRequisito = txtRequisitosIII.Text
                    ZInformativo = "0"
                    ZAVerificar = "0"
                    ZComentario = txtComentariosIII.Text
                Case 4
                    ZRequisito = txtRequisitosIV.Text
                    ZInformativo = "0"
                    ZAVerificar = "0"
                    ZComentario = txtComentariosIV.Text
                Case 5
                    ZRequisito = txtRequisitosV.Text
                    ZInformativo = "0"
                    ZAVerificar = "0"
                    ZComentario = txtComentariosV.Text
                Case 6
                    ZRequisito = txtRequisitosVI.Text
                    ZInformativo = "0"
                    ZAVerificar = "0"
                    ZComentario = txtComentariosVI.Text
                Case 7
                    ZRequisito = txtRequisitosVII.Text
                    ZInformativo = "0"
                    ZAVerificar = "0"
                    ZComentario = txtComentariosVII.Text
                Case 8
                    ZRequisito = txtRequisitosVIII.Text
                    ZInformativo = "0"
                    ZAVerificar = "0"
                    ZComentario = txtComentariosVIII.Text
                Case 9
                    ZRequisito = txtRequisitosIX.Text
                    ZInformativo = "0"
                    ZAVerificar = "0"
                    ZComentario = txtComentariosIX.Text
                Case 10
                    ZRequisito = txtRequisitosX.Text
                    ZInformativo = "0"
                    ZAVerificar = "0"
                    ZComentario = txtComentariosX.Text
                Case 11
                    ZRequisito = txtRequisitosXI.Text
                    ZInformativo = "0"
                    ZAVerificar = "0"
                    ZComentario = txtComentariosXI.Text
                Case 12
                    ZRequisito = txtRequisitosXII.Text
                    ZInformativo = "0"
                    ZAVerificar = "0"
                    ZComentario = txtComentariosXII.Text
            End Select

            WRenglon = Helper.ceros(iRow, 2)

            WClave = WOrden & WVersion & WRenglon

            ZSql = ""
            ZSql = ZSql + "INSERT INTO CargaEnsayoVI ("
            ZSql = ZSql + "Clave ,"
            ZSql = ZSql + "Orden ,"
            ZSql = ZSql + "Version ,"
            ZSql = ZSql + "Renglon ,"
            ZSql = ZSql + "Requisito ,"
            ZSql = ZSql + "Informativo ,"
            ZSql = ZSql + "AVerificar ,"
            ZSql = ZSql + "Comentario )"
            ZSql = ZSql + "Values ("
            ZSql = ZSql + "'" + WClave + "',"
            ZSql = ZSql + "'" + txtOrden.Text + "',"
            ZSql = ZSql + "'" + txtVersion.Text + "',"
            ZSql = ZSql + "'" + Str$(WRenglon) + "',"
            ZSql = ZSql + "'" + ZRequisito + "',"
            ZSql = ZSql + "'" + ZInformativo + "',"
            ZSql = ZSql + "'" + ZAVerificar + "',"
            ZSql = ZSql + "'" + ZComentario + "')"

            cm.CommandText = ZSql
            cm.ExecuteNonQuery()

        Next iRow

        ' Guardamos las anotaciones.
        Dim WDestino = Configuration.ConfigurationManager.AppSettings("BUSCAR_NOTAS_1")
        txtNotasProceso.SaveFile(WDestino & "P" & WOrden & WVersion & ".rtf")
        txtNotasLaboratorio.SaveFile(WDestino & "E" & WOrden & WVersion & ".rtf")
        txtNotasEnsayosAdicionales.SaveFile(WDestino & "C" & WOrden & WVersion & ".rtf")
        txtNotasDocumentacion.SaveFile(WDestino & "V" & WOrden & WVersion & ".rtf")

        trans.Commit()

        'Catch ex As Exception
        '    If Not IsNothing(trans) Then
        '        trans.Rollback()
        '    End If
        '    Throw New Exception("Hubo un problema al querer Guardar la Versión de la Orden de Trabajo en la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        'Finally


        '    cn.Close()
        '    cn = Nothing
        '    cm = Nothing

        'End Try

    End Sub

    Private Function _ExisteEnsayo() As Boolean

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT Orden FROM CargaEnsayo WHERE Orden = '" & UCase(txtOrden.Text) & "'")
        Dim dr As SqlDataReader

        Try

            cn.ConnectionString = Helper._ConectarA
            cn.Open()
            cm.Connection = cn

            dr = cm.ExecuteReader()

            Return dr.HasRows

        Catch ex As Exception
            Throw New Exception("Hubo un problema al querer consultar la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

    End Function

    Private Function _ExisteEnsayo(ByVal WVersion As String) As Boolean

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT Orden FROM CargaEnsayo WHERE Orden = '" & UCase(txtOrden.Text) & "' AND Version = '" & WVersion & "'")
        Dim dr As SqlDataReader

        Try

            cn.ConnectionString = Helper._ConectarA
            cn.Open()
            cm.Connection = cn

            dr = cm.ExecuteReader()

            Return dr.HasRows

        Catch ex As Exception
            Throw New Exception("Hubo un problema al querer consultar la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

    End Function

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click

        If Trim(txtOrden.Text).Replace("-", "") = "" Then Exit Sub

        If _ExisteEnsayo(txtVersion.Text) Then

            If MsgBox("¿Está seguro de querer Eliminar por completo este Ensayo?", vbYesNo) = MsgBoxResult.No Then Exit Sub

            Try

                _EliminarEnsayo()

                btnLimpiar.PerformClick()

                MsgBox("Se ha eliminado satisfactoriamente el Ensayo.", MsgBoxStyle.Information)

            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Exclamation)
            End Try

        End If

    End Sub

    Private Sub _EliminarEnsayo()

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("")

        Try

            cn.ConnectionString = Helper._ConectarA
            cn.Open()
            cm.Connection = cn

            cm.CommandText = "DELETE CargaEnsayo WHERE Orden = '" & txtOrden.Text & "' AND Version = '" & txtVersion.Text & "'"
            cm.ExecuteNonQuery()

            cm.CommandText = "DELETE CargaEnsayoII WHERE Orden = '" & txtOrden.Text & "' AND Version = '" & txtVersion.Text & "'"
            cm.ExecuteNonQuery()

            cm.CommandText = "DELETE CargaEnsayoIII WHERE Orden = '" & txtOrden.Text & "' AND Version = '" & txtVersion.Text & "'"
            cm.ExecuteNonQuery()

            cm.CommandText = "DELETE CargaEnsayoIV WHERE Orden = '" & txtOrden.Text & "' AND Version = '" & txtVersion.Text & "'"
            cm.ExecuteNonQuery()

            cm.CommandText = "DELETE CargaEnsayoV WHERE Orden = '" & txtOrden.Text & "' AND Version = '" & txtVersion.Text & "'"
            cm.ExecuteNonQuery()

            cm.CommandText = "DELETE CargaEnsayoVI WHERE Orden = '" & txtOrden.Text & "' AND Version = '" & txtVersion.Text & "'"
            cm.ExecuteNonQuery()

        Catch ex As Exception
            Throw New Exception("Hubo un problema al querer Eliminar la Versión " & txtVersion.Text & " de la Orden de Trabajo " & txtOrden.Text & " consultar la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        Finally

            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

    End Sub

    'Grillas



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

        With dgvFormula
            If .Focused Or .IsCurrentCellInEditMode Then ' Detectamos los ENTER tanto si solo estan en foco o si estan en edición una celda.
                .CommitEdit(DataGridViewDataErrorContexts.Commit) ' Guardamos todos los datos que no hayan sido confirmados.

                Dim iCol = .CurrentCell.ColumnIndex
                Dim iRow = .CurrentCell.RowIndex
                Dim valor As String = IIf(IsNothing(.CurrentCell.Value), "", .CurrentCell.Value)

                ' Limitamos los caracteres permitidos para cada una de las columnas.
                Select Case iCol
                    Case 5
                        If Not _EsNumeroOControl(keyData) Then
                            Return True
                        End If
                    Case 4
                        If Not _EsDecimalOControl(keyData) Then
                            Return True
                        End If
                End Select

                If msg.WParam.ToInt32() = Keys.Enter Then

                    '
                    ' Chequeamos que el Evento en la Celda, se produzca sin errores. En caso de error, se detiene
                    ' el evento.
                    '
                    Return _EventosGrillaFormula(valor, iCol, iRow)

                ElseIf msg.WParam.ToInt32() = Keys.Escape Then
                    .Rows(iRow).Cells(iCol).Value = ""

                    If iCol = .ColumnCount - 1 Then
                        .CurrentCell = .Rows(iRow).Cells(iCol - 1)
                    Else
                        .CurrentCell = .Rows(iRow).Cells(iCol + 1)
                    End If

                    .CurrentCell = .Rows(iRow).Cells(iCol)
                End If
            End If

        End With

        With dgvProceso
            If .Focused Or .IsCurrentCellInEditMode Then ' Detectamos los ENTER tanto si solo estan en foco o si estan en edición una celda.
                .CommitEdit(DataGridViewDataErrorContexts.Commit) ' Guardamos todos los datos que no hayan sido confirmados.

                Dim iCol = .CurrentCell.ColumnIndex
                Dim iRow = .CurrentCell.RowIndex
                Dim valor As String = IIf(IsNothing(.CurrentCell.Value), "", .CurrentCell.Value)

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
                End Select

                If msg.WParam.ToInt32() = Keys.Enter Then

                    'If valor <> "" Then
                    '
                    ' Chequeamos que el Evento en la Celda, se produzca sin errores. En caso de error, se detiene
                    ' el evento.
                    '
                    Return _EventosGrillaProceso(valor, iCol, iRow)


                ElseIf msg.WParam.ToInt32() = Keys.Escape Then
                    .Rows(iRow).Cells(iCol).Value = ""

                    If iCol = .ColumnCount - 1 Then
                        .CurrentCell = .Rows(iRow).Cells(iCol - 1)
                    Else
                        .CurrentCell = .Rows(iRow).Cells(iCol + 1)
                    End If

                    .CurrentCell = .Rows(iRow).Cells(iCol)
                End If
            End If

        End With

        With dgvLaboratorio
            If .Focused Or .IsCurrentCellInEditMode Then ' Detectamos los ENTER tanto si solo estan en foco o si estan en edición una celda.
                .CommitEdit(DataGridViewDataErrorContexts.Commit) ' Guardamos todos los datos que no hayan sido confirmados.

                Dim iCol = .CurrentCell.ColumnIndex
                Dim iRow = .CurrentCell.RowIndex
                Dim valor As String = IIf(IsNothing(.CurrentCell.Value), "", .CurrentCell.Value)

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
                End Select

                If msg.WParam.ToInt32() = Keys.Enter Then

                    'If valor <> "" Then
                    '
                    ' Chequeamos que el Evento en la Celda, se produzca sin errores. En caso de error, se detiene
                    ' el evento.
                    '
                    Return _EventosGrillaLaboratorio(valor, iCol, iRow)


                ElseIf msg.WParam.ToInt32() = Keys.Escape Then
                    .Rows(iRow).Cells(iCol).Value = ""

                    If iCol = .ColumnCount - 1 Then
                        .CurrentCell = .Rows(iRow).Cells(iCol - 1)
                    Else
                        .CurrentCell = .Rows(iRow).Cells(iCol + 1)
                    End If

                    .CurrentCell = .Rows(iRow).Cells(iCol)
                End If
            End If

        End With

        With dgvRevisiones
            If .Focused Or .IsCurrentCellInEditMode Then ' Detectamos los ENTER tanto si solo estan en foco o si estan en edición una celda.
                .CommitEdit(DataGridViewDataErrorContexts.Commit) ' Guardamos todos los datos que no hayan sido confirmados.

                Dim iCol = .CurrentCell.ColumnIndex
                Dim iRow = .CurrentCell.RowIndex
                Dim valor As String = IIf(IsNothing(.CurrentCell.Value), "", .CurrentCell.Value)

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
                End Select

                If msg.WParam.ToInt32() = Keys.Enter Then

                    'If valor <> "" Then
                    '
                    ' Chequeamos que el Evento en la Celda, se produzca sin errores. En caso de error, se detiene
                    ' el evento.
                    '
                    Return _EventosGrillaRevisiones(valor, iCol, iRow)


                ElseIf msg.WParam.ToInt32() = Keys.Escape Then
                    .Rows(iRow).Cells(iCol).Value = ""

                    If iCol = .ColumnCount - 1 Then
                        .CurrentCell = .Rows(iRow).Cells(iCol - 1)
                    Else
                        .CurrentCell = .Rows(iRow).Cells(iCol + 1)
                    End If

                    .CurrentCell = .Rows(iRow).Cells(iCol)
                End If
            End If

        End With

        With dgvCosto
            If .Focused Or .IsCurrentCellInEditMode Then ' Detectamos los ENTER tanto si solo estan en foco o si estan en edición una celda.
                .CommitEdit(DataGridViewDataErrorContexts.Commit) ' Guardamos todos los datos que no hayan sido confirmados.

                Dim iCol = .CurrentCell.ColumnIndex
                Dim iRow = .CurrentCell.RowIndex
                Dim valor As String = IIf(IsNothing(.CurrentCell.Value), "", .CurrentCell.Value)

                ' Limitamos los caracteres permitidos para cada una de las columnas.
                Select Case iCol
                    Case -1
                        If Not _EsNumeroOControl(keyData) Then
                            Return True
                        End If
                    Case 5
                        If Not _EsDecimalOControl(keyData) Then
                            Return True
                        End If
                End Select

                If msg.WParam.ToInt32() = Keys.Enter Then

                    'If valor <> "" Then
                    '
                    ' Chequeamos que el Evento en la Celda, se produzca sin errores. En caso de error, se detiene
                    ' el evento.
                    '
                    Return _EventosGrillaCosto(valor, iCol, iRow)


                ElseIf msg.WParam.ToInt32() = Keys.Escape Then
                    .Rows(iRow).Cells(iCol).Value = ""

                    If iCol = .ColumnCount - 1 Then
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

    Private Function _EventosGrillaCosto(ByVal valor As String, ByVal iCol As Integer, ByVal iRow As Integer) As Boolean

        Try
            With dgvCosto

                Select Case iCol

                    Case 5

                        _RecalcularImportesYCostosTotales()

                        .CurrentCell = .Rows(iRow).Cells(iCol + 1)

                    Case 6

                        If IsNothing(.Rows(iRow).Cells(0).Value) OrElse Val(.Rows(iRow).Cells(0).Value) = 0 Then
                            Return False
                        End If

                        If iRow + 1 > .Rows.Count - 1 Then

                            .Rows.Add()

                        End If

                        .CurrentCell = .Rows(iRow + 1).Cells(0)

                    Case Else

                        If iCol = 0 AndAlso Val(valor) = 0 Then
                            Return False
                        End If

                        .CurrentCell = .Rows(iRow).Cells(iCol + 1)

                End Select

            End With

            Return True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
            Return False
        End Try

    End Function

    Private Function _EventosGrillaRevisiones(ByVal valor As String, ByVal iCol As Integer, ByVal iRow As Integer) As Boolean

        Try
            With dgvRevisiones


                Select Case iCol

                    Case 7

                        'If IsNothing(.Rows(iRow).Cells(0).Value) OrElse Val(.Rows(iRow).Cells(0).Value) = 0 Then
                        '    Return False
                        'End If

                        If iRow + 1 > .Rows.Count - 1 Then

                            .Rows.Add()

                        End If

                        .CurrentCell = .Rows(iRow + 1).Cells(0)

                    Case Else

                        If iCol = 0 AndAlso Val(valor) = 0 Then
                            Return False
                        End If

                        .CurrentCell = .Rows(iRow).Cells(iCol + 1)

                End Select

            End With

            Return True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
            Return False
        End Try

    End Function

    Private Function _EventosGrillaLaboratorio(ByVal valor As String, ByVal iCol As Integer, ByVal iRow As Integer) As Boolean
        Try
            With dgvLaboratorio

                Select Case iCol
                    Case 0

                        If Val(valor) = 0 Then
                            Return False
                        End If

                        Dim WDesc = _TraerDescripcionEnsayo(valor)

                        If Trim(WDesc) = "" Then Return False

                        .Rows(iRow).Cells("LaboratorioDescripcion").Value = WDesc

                        .CurrentCell = .Rows(iRow).Cells("LaboratorioRequerido")

                    Case 3
                        If iRow + 1 > .Rows.Count - 1 Then

                            If IsNothing(.Rows(iRow).Cells(0).Value) OrElse Val(.Rows(iRow).Cells(0).Value) = 0 Then
                                Return False
                            End If

                            .Rows.Add()

                        End If

                        .CurrentCell = .Rows(iRow + 1).Cells(0)

                    Case Else

                        .CurrentCell = .Rows(iRow).Cells(iCol + 1)

                End Select

            End With

            Return True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
            Return False
        End Try

    End Function

    Private Function _EventosGrillaProceso(ByVal valor As String, ByVal iCol As Integer, ByVal iRow As Integer) As Boolean

        Try
            With dgvProceso

                Select Case iCol
                    Case 6
                        If iRow + 1 > .Rows.Count - 1 Then

                            If IsNothing(.Rows(iRow).Cells(0).Value) OrElse Val(.Rows(iRow).Cells(0).Value) = 0 Then
                                Return False
                            End If

                            .Rows.Add()

                        End If

                        .CurrentCell = .Rows(iRow + 1).Cells(0)

                    Case Else

                        If iCol = 0 And Val(valor) = 0 Then
                            Return False
                        End If

                        .CurrentCell = .Rows(iRow).Cells(iCol + 1)

                End Select

            End With

            Return True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
            Return False
        End Try

    End Function

    Private Function _EventosGrillaFormula(ByVal valor As String, ByVal iCol As Integer, ByVal iRow As Integer) As Boolean
        Dim WArticuloTemplate As String = "  -     -   "
        Dim WTerminadoTemplate As String = "  -   -   "
        Try

            Select Case iCol
                Case 0

                    If String.IsNullOrEmpty(valor) Or String.IsNullOrWhiteSpace(valor) Then
                        Return False
                    End If

                    Dim WTipo = UCase(valor.SliceLeft(1))

                    If Not WTipo.StartsWith("T") And Not WTipo.StartsWith("M") And Not WTipo.StartsWith("O") Then
                        Return False
                    End If

                    With dgvFormula

                        Select Case WTipo
                            Case "T"

                                .Rows(iRow).Cells("ArticuloFormula").Value = WArticuloTemplate

                                .CurrentCell = .Rows(iRow).Cells("TerminadoFormula")

                            Case "M"

                                .Rows(iRow).Cells("TerminadoFormula").Value = WTerminadoTemplate

                                .CurrentCell = .Rows(iRow).Cells("ArticuloFormula")

                            Case "O"

                                .Rows(iRow).Cells("ArticuloFormula").Value = WArticuloTemplate
                                .Rows(iRow).Cells("TerminadoFormula").Value = WTerminadoTemplate

                                .CurrentCell = .Rows(iRow).Cells("DescripcionFormula")

                        End Select

                    End With


                Case 1 ' Celda Articulo

                    Dim WDescArticulo As String = _TraerDescripcionArticulo(valor)

                    If Trim(WDescArticulo) = "" Then Return False

                    With dgvFormula
                        .Rows(iRow).Cells("DescripcionFormula").Value = Trim(WDescArticulo)
                        .CurrentCell = .Rows(iRow).Cells("CantidadFormula")
                    End With

                Case 2 ' Celda Terminado

                    Dim WDescTerminado As String = _TraerDescripcionTerminado(valor)

                    If Trim(WDescTerminado) = "" Then Return False

                    With dgvFormula
                        .Rows(iRow).Cells("DescripcionFormula").Value = Trim(WDescTerminado)
                        .CurrentCell = .Rows(iRow).Cells("CantidadFormula")
                    End With
                Case 6

                    If Trim(valor) <> "" And UCase(Trim(valor)) <> "S" Then
                        Return False
                    End If

                    With dgvFormula

                        If iRow + 1 > .Rows.Count - 1 Then

                            If IsNothing(.Rows(iRow).Cells(0).Value) OrElse Trim(.Rows(iRow).Cells(0).Value) = "" Then
                                Return False
                            End If

                            .Rows.Add()

                        End If

                        .CurrentCell = .Rows(iRow + 1).Cells(0)

                    End With

                Case 4
                    With dgvFormula
                        .Rows(iRow).Cells(iCol).Value = Helper.formatonumerico(valor, 3)
                        .CurrentCell = .Rows(iRow).Cells(iCol + 1)
                    End With
                Case Else
                    With dgvFormula
                        .CurrentCell = .Rows(iRow).Cells(iCol + 1)
                    End With
            End Select

            dgvFormula.Rows(iRow).Cells(iCol).Value = UCase(dgvFormula.Rows(iRow).Cells(iCol).Value)

            Return True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
            Return False
        End Try
    End Function

    Private Function _TraerDescripcionArticulo(ByVal valor As String) As String

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT Descripcion FROM Articulo WHERE Codigo = '" & UCase(valor) & "'")
        Dim dr As SqlDataReader
        Dim WDesc = ""
        Try

            If String.IsNullOrEmpty(valor) Or String.IsNullOrWhiteSpace(valor) Or valor.Length < 10 Then
                Return WDesc
            End If

            cn.ConnectionString = Helper._ConectarA
            cn.Open()
            cm.Connection = cn

            dr = cm.ExecuteReader()

            If dr.HasRows Then
                dr.Read()

                WDesc = IIf(IsDBNull(dr.Item("Descripcion")), "", dr.Item("Descripcion"))

            End If

        Catch ex As Exception
            Throw New Exception("Hubo un problema al querer traer el nombre del Articulo desde la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

        Return WDesc

    End Function

    Private Function _TraerDescripcionTerminado(ByVal valor As String) As String

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT Descripcion FROM Terminado WHERE Codigo = '" & UCase(valor) & "'")
        Dim dr As SqlDataReader
        Dim WDesc = ""
        Try

            If String.IsNullOrEmpty(valor) Or String.IsNullOrWhiteSpace(valor) Or valor.Length < 12 Then
                Return WDesc
            End If

            cn.ConnectionString = Helper._ConectarA
            cn.Open()
            cm.Connection = cn

            dr = cm.ExecuteReader()

            If dr.HasRows Then
                dr.Read()

                WDesc = IIf(IsDBNull(dr.Item("Descripcion")), "", dr.Item("Descripcion"))

            End If

        Catch ex As Exception
            Throw New Exception("Hubo un problema al querer traer el Nombre del Producto Terminado desde la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

        Return WDesc

    End Function

    Private Sub txtVersion_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtVersion.KeyDown

        If e.KeyData = Keys.Enter Then

            Try
                If Val(txtVersion.Text) = 0 Then : Exit Sub : End If

                ' Verificamos nuevamente que exista la orden.

                If Not _ExisteEnsayo() Then

                    btnLimpiar.PerformClick()

                    txtOrden.Focus()
                    Exit Sub
                End If

                Dim WOrden = txtOrden.Text, WVersion = txtVersion.Text

                btnLimpiar.PerformClick()

                txtOrden.Text = WOrden
                txtVersion.Text = WVersion

                ' Buscamos los datos de la orden segun la version.

                ' Cargamos los datos generales.
                _TraerDatosOrdenPorVersion()
                ' Cargamos los datos de la Formula.
                _TraerDatosFormulaYCosto()
                ' Cargamos los datos de Proceso.
                _TraerDatosProceso()
                ' Cargamos los datos de Laboratorio.
                _TraerDatosLaboratorio()
                ' Cargamos los datos de las Revisiones.
                _TraerDatosRevisiones()
                ' Cargamos los Datos de Entrada.
                _TraerDatosEntrada()
                ' Cargamos los Archivos RFT.
                _CargarRFTs()
                ' Cargamos los Archivos Relacionados.
                _CargarArchivosRelacionados

                txtFecha.Focus()
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Exclamation)
            End Try

        ElseIf e.KeyData = Keys.Escape Then
            txtVersion.Text = ""
        End If

    End Sub

    Private Sub _CargarRFTs()
        Try

            txtNotasProceso.LoadFile(_BuscarArchivo("P"))
            txtNotasLaboratorio.LoadFile(_BuscarArchivo("E"))
            txtNotasEnsayosAdicionales.LoadFile(_BuscarArchivo("C"))
            txtNotasDocumentacion.LoadFile(_BuscarArchivo("V"))

        Catch ex As Exception
            Throw New Exception("Hubo un problema al querer recuperar los archivos RFT asociados a esta Orden de Trabajo." & vbCrLf & vbCrLf & " Motivo: " & ex.Message)
        End Try
    End Sub

    Private Function _BuscarArchivo(ByVal WPrefijo As String) As String

        If String.IsNullOrEmpty(WPrefijo) Then Throw New Exception("Nombre de Archivo Incorrecto")

        Dim WRutaI = "", WRutaII = "", WNombreArchivo = ""

        WNombreArchivo = UCase(WPrefijo) & txtOrden.Text & Helper.ceros(txtVersion.Text, 4) & ".rtf"

        WRutaI = Configuration.ConfigurationManager.AppSettings("BUSCAR_NOTAS_1")
        WRutaII = Configuration.ConfigurationManager.AppSettings("BUSCAR_NOTAS_2")

        If File.Exists(WRutaI & WNombreArchivo) Then

            Return WRutaI & WNombreArchivo

        ElseIf File.Exists(WRutaII & WNombreArchivo) Then

            Return WRutaII & WNombreArchivo

        Else

            Return WRutaI & "blanco.rtf"

        End If

    End Function

    Private Sub _TraerDatosEntrada(Optional ByVal WVersion As String = "")

        If String.IsNullOrEmpty(WVersion) Then
            WVersion = txtVersion.Text
        End If

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT Requisito, Informativo, AVerificar, Comentario FROM CargaEnsayoVI WHERE Orden = '" & txtOrden.Text & "' AND Version = '" & WVersion & "' ORDER BY Clave")
        Dim dr As SqlDataReader
        Dim WRequisito = "", WComentario = ""
        Dim XIndice = 0
        Dim WRequisitos = {txtRequisitosI, txtRequisitosII, txtRequisitosIII, txtRequisitosIV, txtRequisitosV, _
                           txtRequisitosVI, txtRequisitosVII, txtRequisitosVIII, txtRequisitosIX, txtRequisitosX, _
                           txtRequisitosXI, txtRequisitosXII}
        Dim WComentarios = {txtComentariosI, txtComentariosII, txtComentariosIII, txtComentariosIV, txtComentariosV, _
                           txtComentariosVI, txtComentariosVII, txtComentariosVIII, txtComentariosIX, txtComentariosX, _
                           txtComentariosXI, txtComentariosXII}

        Try

            cn.ConnectionString = Helper._ConectarA
            cn.Open()
            cm.Connection = cn

            dr = cm.ExecuteReader()

            If dr.HasRows Then

                Do While dr.Read()

                    With dr

                        WRequisito = IIf(IsDBNull(.Item("Requisito")), "", .Item("Requisito"))
                        WComentario = IIf(IsDBNull(.Item("Comentario")), "", .Item("Comentario"))

                    End With

                    If XIndice < 12 Then

                        WRequisitos(XIndice).Text = Trim(WRequisito)
                        WComentarios(XIndice).Text = Trim(WComentario)

                        XIndice += 1

                    End If

                Loop

            End If

        Catch ex As Exception
            Throw New Exception("Hubo un problema al querer consultar los Datos de Entrada desde la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

    End Sub

    Private Sub _TraerDatosRevisiones()
        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT Version, Etapa, Fecha, Participantes, Resultados, Acciones, Responsables, Estado FROM CargaEnsayoV WHERE Orden = '" & txtOrden.Text & "' ORDER BY Orden, Renglon")
        Dim dr As SqlDataReader
        Dim WVersion = "", WEtapa = "", WFecha = "", WParticipantes = "", WResultados = "", WAcciones = "", WResponsables = "", WEstado = ""
        Dim XIndice = 0

        Try

            cn.ConnectionString = Helper._ConectarA
            cn.Open()
            cm.Connection = cn

            dr = cm.ExecuteReader()

            If dr.HasRows Then

                dgvRevisiones.Rows.Clear()

                Do While dr.Read()

                    With dr
                        WVersion = IIf(IsDBNull(.Item("Version")), "", .Item("Version"))
                        WEtapa = IIf(IsDBNull(.Item("Etapa")), "", .Item("Etapa"))
                        WFecha = IIf(IsDBNull(.Item("Fecha")), "", .Item("Fecha"))
                        WParticipantes = IIf(IsDBNull(.Item("Participantes")), "", .Item("Participantes"))
                        WResultados = IIf(IsDBNull(.Item("Resultados")), "", .Item("Resultados"))
                        WAcciones = IIf(IsDBNull(.Item("Acciones")), "", .Item("Acciones"))
                        WResponsables = IIf(IsDBNull(.Item("Responsables")), "", .Item("Responsables"))
                        WEstado = IIf(IsDBNull(.Item("Estado")), "", .Item("Estado"))

                    End With

                    XIndice = dgvRevisiones.Rows.Add

                    ' Cargamos los datos de la Formula.
                    With dgvRevisiones.Rows(XIndice)

                        .Cells("RevisionesVersion").Value = Trim(WVersion)
                        .Cells("RevisionesEtapa").Value = Trim(WEtapa)
                        .Cells("RevisionesFecha").Value = Trim(WFecha)
                        .Cells("RevisionesParticipantes").Value = Trim(WParticipantes)
                        .Cells("RevisionesResultados").Value = Trim(WResultados)
                        .Cells("RevisionesAcciones").Value = Trim(WAcciones)
                        .Cells("RevisionesResponsables").Value = Trim(WResponsables)
                        .Cells("RevisionesEstado").Value = Trim(WEstado)

                    End With

                Loop

                'dgvRevisiones.Rows.Add()

                For i As Integer = 0 To 200
                    dgvRevisiones.Rows.Add()
                Next

            End If

        Catch ex As Exception
            Throw New Exception("Hubo un problema al querer consultar las Revisiones de la Orden de Trabajo desde la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

    End Sub

    Private Sub _TraerDatosLaboratorio(Optional ByVal WVersion As String = "")

        If String.IsNullOrEmpty(WVersion) Then
            WVersion = txtVersion.Text
        End If

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT Ensayo, Descripcion, Esperado, Resultado FROM CargaEnsayoIV WHERE Orden = '" & txtOrden.Text & "' AND Version = '" & WVersion & "' ORDER BY Clave")
        Dim dr As SqlDataReader
        Dim WEnsayo = "", WDescripcion = "", WEsperado = "", WResultado = ""
        Dim XIndice = 0

        Try

            cn.ConnectionString = Helper._ConectarA
            cn.Open()
            cm.Connection = cn

            dr = cm.ExecuteReader()

            If dr.HasRows Then

                dgvLaboratorio.Rows.Clear()

                Do While dr.Read()

                    With dr

                        WEnsayo = IIf(IsDBNull(.Item("Ensayo")), "", .Item("Ensayo"))

                        WEnsayo = Str$(Val(WEnsayo))

                        WDescripcion = IIf(IsDBNull(.Item("Descripcion")), "", .Item("Descripcion"))
                        WEsperado = IIf(IsDBNull(.Item("Esperado")), "", .Item("Esperado"))
                        WResultado = IIf(IsDBNull(.Item("Resultado")), "", .Item("Resultado"))

                    End With

                    XIndice = dgvLaboratorio.Rows.Add

                    ' Cargamos los datos de la Formula.
                    With dgvLaboratorio.Rows(XIndice)

                        .Cells("LaboratorioEnsayo").Value = IIf(Val(WEnsayo) = 0, "", WEnsayo)
                        .Cells("LaboratorioDescripcion").Value = Trim(WDescripcion)
                        .Cells("LaboratorioRequerido").Value = Trim(WEsperado)
                        .Cells("LaboratorioResultado").Value = Trim(WResultado)

                    End With

                Loop

            Else

                If Not dr.IsClosed Then
                    dr.Close()
                End If

                cm.CommandText = "SELECT Ensayo, Descripcion, Resultado FROM OrdenTrabajoII WHERE Orden = '" & txtOrden.Text & "' ORDER BY Clave"

                dr = cm.ExecuteReader

                If dr.HasRows Then

                    Do While dr.Read()

                        With dr

                            WEnsayo = IIf(IsDBNull(.Item("Ensayo")), "", .Item("Ensayo"))

                            WEnsayo = Str$(Val(WEnsayo))

                            WDescripcion = IIf(IsDBNull(.Item("Descripcion")), "", .Item("Descripcion"))
                            WEsperado = ""
                            WResultado = IIf(IsDBNull(.Item("Resultado")), "", .Item("Resultado"))

                        End With

                        XIndice = dgvLaboratorio.Rows.Add

                        ' Cargamos los datos de la Formula.
                        With dgvLaboratorio.Rows(XIndice)

                            .Cells("LaboratorioEnsayo").Value = UCase(WEnsayo)
                            .Cells("LaboratorioDescripcion").Value = Trim(WDescripcion)
                            .Cells("LaboratorioRequerido").Value = Trim(WResultado)
                            .Cells("LaboratorioResultado").Value = Trim(WEsperado)

                        End With

                    Loop

                End If

            End If

            For Each _row As DataGridViewRow In dgvLaboratorio.Rows

                With _row

                    WEnsayo = .Cells("LaboratorioEnsayo").Value

                    If Val(WEnsayo) <> 0 Then

                        .Cells("LaboratorioDescripcion").Value = _TraerDescripcionEnsayo(WEnsayo)

                    End If

                End With

            Next

            dgvLaboratorio.Rows.Add()

        Catch ex As Exception
            Throw New Exception("Hubo un problema al querer consultar los datos de Laboratorio desde la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

    End Sub

    Private Function _TraerDescripcionEnsayo(ByVal wEnsayo As String) As String
        If String.IsNullOrEmpty(wEnsayo) Or String.IsNullOrWhiteSpace(wEnsayo) Then Return ""
        Dim WDesc = ""
        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT Descripcion FROM Ensayos WHERE Codigo = '" & Trim(wEnsayo) & "'")
        Dim dr As SqlDataReader

        Try

            cn.ConnectionString = Helper._ConectarA
            cn.Open()
            cm.Connection = cn

            dr = cm.ExecuteReader()

            If dr.HasRows Then

                dr.Read()

                WDesc = IIf(IsDBNull(dr.Item("Descripcion")), "", dr.Item("Descripcion"))
                WDesc = Trim(WDesc)

            End If

        Catch ex As Exception
            Throw New Exception("Hubo un problema al querer traer la descripción del ensayo " & wEnsayo & " desde la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

        Return WDesc
    End Function

    Private Sub _TraerDatosProceso(Optional ByVal WVersion As String = "")

        If String.IsNullOrEmpty(WVersion) Then
            WVersion = txtVersion.Text
        End If

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT Etapa, Instrucciones, Equipo, Temperatura, Tiempo, Control, Seguridad FROM CargaEnsayoIII WHERE Orden = '" & txtOrden.Text & "' AND Version = '" & WVersion & "' ORDER BY Clave")
        Dim dr As SqlDataReader
        Dim WEtapa = "", WInstrucciones = "", WEquipo = "", WTemperatura = "", WTiempo = "", WControl = "", WSeguridad = ""
        Dim XIndice = 0

        Try

            cn.ConnectionString = Helper._ConectarA
            cn.Open()
            cm.Connection = cn

            dr = cm.ExecuteReader()

            If dr.HasRows Then

                dgvProceso.Rows.Clear()

                Do While dr.Read()

                    With dr
                        WEtapa = IIf(IsDBNull(.Item("Etapa")), "", .Item("Etapa"))
                        WInstrucciones = IIf(IsDBNull(.Item("Instrucciones")), "", .Item("Instrucciones"))
                        WEquipo = IIf(IsDBNull(.Item("Equipo")), "", .Item("Equipo"))
                        WTemperatura = IIf(IsDBNull(.Item("Temperatura")), "", .Item("Temperatura"))
                        WTiempo = IIf(IsDBNull(.Item("Tiempo")), "", .Item("Tiempo"))
                        WControl = IIf(IsDBNull(.Item("Control")), "", .Item("Control"))
                        WSeguridad = IIf(IsDBNull(.Item("Seguridad")), "", .Item("Seguridad"))

                    End With

                    XIndice = dgvProceso.Rows.Add

                    ' Cargamos los datos de la Formula.
                    With dgvProceso.Rows(XIndice)

                        .Cells("ProcesoEtapa").Value = UCase(WEtapa)
                        .Cells("ProcesoDetallesTrabajo").Value = Trim(WInstrucciones)
                        .Cells("ProcesoEquipo").Value = Trim(WEquipo)
                        .Cells("ProcesoTemperatura").Value = Trim(WTemperatura)
                        .Cells("ProcesoTiempo").Value = Trim(WTiempo)
                        .Cells("ProcesoControl").Value = Trim(WControl)
                        .Cells("ProcesoSeguridad").Value = Trim(WSeguridad)

                    End With

                Loop

                dgvProceso.Rows.Add()
            End If

        Catch ex As Exception
            Throw New Exception("Hubo un problema al querer consultar los datos de la Fórmula desde la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

    End Sub

    Private Sub _TraerDatosOrdenPorVersion()

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT Fecha, Cantidad, Realizado, RealizadoII, Visto FROM CargaEnsayo WHERE Orden = '" & txtOrden.Text & "' AND Version = '" & txtVersion.Text & "'")
        Dim dr As SqlDataReader

        Try

            cn.ConnectionString = Helper._ConectarA
            cn.Open()
            cm.Connection = cn

            dr = cm.ExecuteReader()

            If dr.HasRows Then
                dr.Read()

                With dr

                    txtFecha.Text = IIf(IsDBNull(.Item("Fecha")), "", .Item("Fecha"))
                    txtCantidad.Text = IIf(IsDBNull(.Item("Cantidad")), "", .Item("Cantidad"))
                    txtRealizado.Text = IIf(IsDBNull(.Item("Realizado")), "", .Item("Realizado"))
                    txtRealizadoII.Text = IIf(IsDBNull(.Item("RealizadoII")), "", .Item("RealizadoII"))
                    txtVisto.Text = IIf(IsDBNull(.Item("Visto")), "", .Item("Visto"))

                    txtCantidad.Text = Helper.formatonumerico(txtCantidad.Text, 3)

                    txtRealizado.Text = Trim(txtRealizado.Text)
                    txtRealizadoII.Text = Trim(txtRealizadoII.Text)
                    txtVisto.Text = Trim(txtVisto.Text)

                End With


            End If

        Catch ex As Exception
            Throw New Exception("Hubo un problema al querer consultar los datos Generales de la Orden de Trabajo " & txtOrden.Text & " Version " & Str$(Val(txtVersion.Text)) & " en la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

    End Sub

    Private Sub _TraerDatosFormulaYCosto(Optional ByVal WVersion As String = "")

        If String.IsNullOrEmpty(WVersion) Then
            WVersion = txtVersion.Text
        End If

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT Tipo, Articulo, Terminado, Descripcion, Cantidad, Lote, Stock, Costo, Hoja FROM CargaEnsayoII WHERE Orden = '" & txtOrden.Text & "' AND Version = '" & WVersion & "' ORDER BY Clave")
        Dim dr As SqlDataReader
        Dim WTipo = "", WArticulo = "", WTerminado = "", WDescripcion = "", WCantidad = "", WLote = "", WStock = "", WCosto = "", WHoja = ""
        Dim XIndice = 0

        Try

            cn.ConnectionString = Helper._ConectarA
            cn.Open()
            cm.Connection = cn

            dr = cm.ExecuteReader()

            If dr.HasRows Then

                dgvFormula.Rows.Clear()
                dgvCosto.Rows.Clear()

                Do While dr.Read()

                    For Each _W In {WTipo, WArticulo, WTerminado, WDescripcion, WCantidad, WLote, WStock}
                        _W = ""
                    Next

                    With dr
                        WTipo = IIf(IsDBNull(.Item("Tipo")), "", .Item("Tipo"))
                        WArticulo = IIf(IsDBNull(.Item("Articulo")), "", .Item("Articulo"))
                        WTerminado = IIf(IsDBNull(.Item("Terminado")), "", .Item("Terminado"))
                        WDescripcion = IIf(IsDBNull(.Item("Descripcion")), "", .Item("Descripcion"))
                        WCantidad = IIf(IsDBNull(.Item("Cantidad")), "", .Item("Cantidad"))
                        WLote = IIf(IsDBNull(.Item("Lote")), "", .Item("Lote"))
                        WStock = IIf(IsDBNull(.Item("Stock")), "", .Item("Stock"))
                        WCosto = IIf(IsDBNull(.Item("Costo")), "", .Item("Costo"))
                        WHoja = IIf(IsDBNull(.Item("Hoja")), "", .Item("Hoja"))

                        WCantidad = Helper.formatonumerico(WCantidad, 3)
                        WCosto = Helper.formatonumerico(WCosto)

                    End With

                    txtHojaProduccion.Text = WHoja

                    XIndice = dgvFormula.Rows.Add

                    ' Cargamos los datos de la Formula.
                    With dgvFormula.Rows(XIndice)

                        .Cells("TipoFormula").Value = UCase(WTipo)
                        .Cells("ArticuloFormula").Value = WArticulo
                        .Cells("TerminadoFormula").Value = WTerminado
                        .Cells("DescripcionFormula").Value = Trim(WDescripcion)
                        .Cells("CantidadFormula").Value = Helper.formatonumerico(WCantidad, 3)
                        .Cells("LoteFormula").Value = Trim(WLote)
                        .Cells("StockFormula").Value = Trim(WStock)

                    End With

                    ' Cargamos los datos de los costos.
                    dgvCosto.Rows.Add()
                    With dgvCosto.Rows(XIndice)

                        .Cells("CostoTipo").Value = UCase(WTipo)
                        .Cells("CostoArticulo").Value = WArticulo
                        .Cells("CostoTerminado").Value = WTerminado
                        .Cells("CostoDescripcion").Value = Trim(WDescripcion)
                        .Cells("CostoCantidad").Value = Helper.formatonumerico(WCantidad, 3)
                        .Cells("CostoCosto").Value = Helper.formatonumerico(WCosto)
                        .Cells("CostoImporte").Value = Helper.formatonumerico(Val(WCantidad) * Val(WCosto))

                    End With

                Loop

                dgvFormula.Rows.Add()
                dgvCosto.Rows.Add()

            End If

        Catch ex As Exception
            Throw New Exception("Hubo un problema al querer consultar los datos de la Fórmula desde la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

    End Sub

    Private Sub NumerosConComas(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCantidad.KeyPress
        If Not Char.IsNumber(e.KeyChar) And Not Char.IsControl(e.KeyChar) And Not (CChar(".")) = e.KeyChar Then
            e.Handled = True
        End If
    End Sub

    Private Sub SoloNumero(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtVersion.KeyPress
        If Not Char.IsNumber(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub btnRecalculaCosto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRecalculaCosto.Click

        Dim WCosto = 0.0, WTerminado = "", WMateriaPrima = "", WTipo = ""
        Dim WindiceCosto = 0

        Try

            dgvCosto.Rows.Clear()

            For Each _Formula As DataGridViewRow In dgvFormula.Rows

                WTerminado = ""
                WMateriaPrima = ""
                WTipo = ""
                WCosto = 0.0

                If IsNothing(_Formula.Cells("TipoFormula").Value) Then Continue For

                WTipo = _Formula.Cells("TipoFormula").Value

                If Trim(WTipo) = "" Then Continue For


                Select Case UCase(WTipo)
                    Case "T"

                        WTerminado = _Formula.Cells("TerminadoFormula").Value

                        'WCosto = (ZZCantidad * ZZCosto * Val(WVector))
                        'Costo = Costo + WCosto

                        WCosto = _CalcularCostoProducto(WTerminado)

                    Case "M"

                        WMateriaPrima = _Formula.Cells("ArticuloFormula").Value

                        WCosto = _CalcularCostoMP(WMateriaPrima)

                    Case Else
                        Continue For
                End Select

                WindiceCosto = dgvCosto.Rows.Add

                With dgvCosto.Rows(WindiceCosto)
                    .Cells("CostoTipo").Value = _Formula.Cells("TipoFormula").Value
                    .Cells("CostoArticulo").Value = _Formula.Cells("ArticuloFormula").Value
                    .Cells("CostoTerminado").Value = _Formula.Cells("TerminadoFormula").Value
                    .Cells("CostoDescripcion").Value = _Formula.Cells("DescripcionFormula").Value
                    .Cells("CostoCantidad").Value = _Formula.Cells("CantidadFormula").Value
                    .Cells("CostoCosto").Value = Helper.formatonumerico(Str$(WCosto))
                    .Cells("CostoImporte").Value = ""
                End With


            Next

            _RecalcularImportesYCostosTotales()

        Catch ex As Exception

            MsgBox("Hubo un problema al querer Recalcular los Costos de la Orden de Trabajo. Motivo: " & ex.Message, MsgBoxStyle.Exclamation)

        End Try
    End Sub

    Private Function _CalcularCostoMP(ByVal WMateriaPrima As String) As Double
        If cmbTipoCalculo.SelectedIndex = 0 Then
            Return _CalcularCostoStandardEstimado(WMateriaPrima)
        Else
            Return _CalcularCostoUltimaCompra(WMateriaPrima)
        End If
    End Function

    Private Sub _RecalcularImportesYCostosTotales()
        Dim WCostoTotal = 0.0, WCantidad = 0.0, WCosto = 0.0, WImporte = 0.0


        For Each _row As DataGridViewRow In dgvCosto.Rows

            WCosto = 0.0
            WCantidad = 0.0
            WImporte = 0.0

            With _row

                If IsNothing(.Cells("CostoCantidad").Value) Or IsNothing(.Cells("CostoCosto")) Then Continue For

                WCantidad = Val(Helper.formatonumerico(.Cells("CostoCantidad").Value))
                WCosto = Val(Helper.formatonumerico(.Cells("CostoCosto").Value))

                WImporte = WCantidad * WCosto

                'If WImporte <> 0 Then

                .Cells("CostoImporte").Value = Helper.formatonumerico(Str$(WImporte))

                WCostoTotal += WImporte

                'End If

            End With

        Next

        txtCostoTotal.Text = Str$(WCostoTotal)
        txtCostoPorKilo.Text = "0.00"

        If Val(txtCantidad.Text) <> 0 Then
            txtCostoPorKilo.Text = Str$(WCostoTotal / Val(Helper.formatonumerico(txtCantidad.Text)))
        End If

        txtCostoTotal.Text = Helper.formatonumerico(txtCostoTotal.Text)
        txtCostoPorKilo.Text = Helper.formatonumerico(txtCostoPorKilo.Text)

    End Sub

    Private Function _CalcularCostoUltimaCompra(ByVal wMateriaPrima As String) As Double

        If String.IsNullOrEmpty(wMateriaPrima) Then Return 0

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT Costo1, WCosto1, ZCosto1, OrdenI, OrdenII, OrdenIII, PtaOrdenI, PtaOrdenII, PtaOrdenIII FROM Articulo WHERE Codigo = '" & wMateriaPrima & "'")
        Dim dr As SqlDataReader
        Dim WCOstoFinal = 0.0, WCosto = 0.0, WCosto1 = 0.0, ZCosto1 = 0.0, WOrden() = {"", "", ""}, WPtaOrden() = {"", "", ""}, WFechaOrd = {0, 0, 0}
        'Dim WMoneda = ""

        Try

            cn.ConnectionString = Helper._ConectarA
            cn.Open()
            cm.Connection = cn

            dr = cm.ExecuteReader()

            If dr.HasRows Then
                dr.Read()

                With dr

                    WCosto = IIf(IsDBNull(.Item("Costo1")), 0.0, .Item("Costo1"))
                    WCOstoFinal = WCosto

                    WCosto1 = IIf(IsDBNull(.Item("WCosto1")), 0.0, .Item("WCosto1"))
                    ZCosto1 = IIf(IsDBNull(.Item("ZCosto1")), 0.0, .Item("ZCosto1"))

                    WOrden(0) = IIf(IsDBNull(.Item("OrdenI")), "0", .Item("OrdenI"))
                    WOrden(1) = IIf(IsDBNull(.Item("OrdenII")), "0", .Item("OrdenII"))
                    WOrden(2) = IIf(IsDBNull(.Item("OrdenIII")), "0", .Item("OrdenIII"))

                    WPtaOrden(0) = IIf(IsDBNull(.Item("PtaOrdenI")), "0", .Item("PtaOrdenI"))
                    WPtaOrden(1) = IIf(IsDBNull(.Item("PtaOrdenII")), "0", .Item("PtaOrdenII"))
                    WPtaOrden(2) = IIf(IsDBNull(.Item("PtaOrdenIII")), "0", .Item("PtaOrdenIII"))

                End With

                If Not dr.IsClosed Then
                    dr.Close()
                End If

                ' Recuperamos el tipo de Moneda.
                If Val(WOrden(0)) <> 0 And Val(WPtaOrden(0)) <> 0 Then

                    If cn.IsOpened Then
                        cn.Close()
                    End If

                    cn.ConnectionString = Helper._ConectarA(CInt(WPtaOrden(0)))
                    cn.Open()
                    cm.Connection = cn
                    cm.CommandText = "SELECT Fecha, Moneda FROM Orden WHERE Orden = '" & WOrden(0) & "'"

                    dr = cm.ExecuteReader

                    If dr.HasRows Then
                        dr.Read()

                        WFechaOrd(0) = Helper.ordenaFecha(dr.Item("Fecha"))

                        'Select Case dr.Item("Moneda")
                        '    Case 0
                        '        WMoneda = "U$S"
                        '    Case 1
                        '        WMoneda = "$"
                        '    Case Else
                        '        WMoneda = "Eur"
                        'End Select

                    End If

                End If

                ' Recuperamos el tipo de Moneda.
                If Val(WOrden(1)) <> 0 And Val(WPtaOrden(1)) <> 0 Then

                    If cn.IsOpened Then
                        cn.Close()
                    End If

                    cn.ConnectionString = Helper._ConectarA(CInt(WPtaOrden(1)))
                    cn.Open()
                    cm.Connection = cn
                    cm.CommandText = "SELECT Fecha FROM Orden WHERE Orden = '" & WOrden(1) & "'"

                    dr = cm.ExecuteReader

                    If dr.HasRows Then
                        dr.Read()

                        WFechaOrd(1) = Helper.ordenaFecha(dr.Item("Fecha"))

                    End If

                End If

                ' Recuperamos el tipo de Moneda.
                If Val(WOrden(2)) <> 0 And Val(WPtaOrden(2)) <> 0 Then

                    If cn.IsOpened Then
                        cn.Close()
                    End If

                    cn.ConnectionString = Helper._ConectarA(CInt(WPtaOrden(2)))
                    cn.Open()
                    cm.Connection = cn
                    cm.CommandText = "SELECT Fecha FROM Orden WHERE Orden = '" & WOrden(2) & "'"

                    dr = cm.ExecuteReader

                    If dr.HasRows Then
                        dr.Read()

                        WFechaOrd(2) = Helper.ordenaFecha(dr.Item("Fecha"))

                    End If

                End If

                If WFechaOrd(0) <> 0 And WFechaOrd(0) > WFechaOrd(1) And WFechaOrd(0) > WFechaOrd(2) Then
                    WCOstoFinal = WCosto
                End If

                If WFechaOrd(1) <> 0 And WFechaOrd(1) > WFechaOrd(0) And WFechaOrd(1) > WFechaOrd(2) Then

                    Dim WParidad As Double = _TraerParidad(Helper.DesOrdenaFecha(WFechaOrd(1)))

                    If WParidad <> 0 Then

                        WCOstoFinal = WCosto1 / WParidad

                    End If

                End If

                If WFechaOrd(2) <> 0 And WFechaOrd(2) > WFechaOrd(0) And WFechaOrd(2) > WFechaOrd(1) Then
                    WCOstoFinal = ZCosto1
                End If
            End If

        Catch ex As Exception
            Throw New Exception("Hubo un problema al querer calcular el Costo según última Compra del " & wMateriaPrima & " desde la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

        Return WCOstoFinal

    End Function

    Private Function _TraerParidad(ByVal Wfecha As String) As Double

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT Cambio FROM Cambios WHERE Fecha = '" & Wfecha & "'")
        Dim dr As SqlDataReader

        Dim WParidad As Double = 0.0

        Try

            cn.ConnectionString = Helper._ConectarA("SurfactanSa")
            cn.Open()
            cm.Connection = cn

            dr = cm.ExecuteReader()

            If dr.HasRows Then

                dr.Read()

                WParidad = dr.Item("Cambio")

            End If

        Catch ex As Exception
            Throw New Exception("Hubo un problema al querer consultar la paridad del dia " & Wfecha & " en la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

        Return WParidad

    End Function

    Private Function _CalcularCostoStandardEstimado(ByVal WMateriaPrima As String) As Double

        If String.IsNullOrEmpty(WMateriaPrima) Then Return 0

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT Costo2 FROM Articulo WHERE Codigo = '" & WMateriaPrima & "'")
        Dim dr As SqlDataReader

        Try

            cn.ConnectionString = Helper._ConectarA
            cn.Open()
            cm.Connection = cn

            dr = cm.ExecuteReader()

            If dr.HasRows Then
                dr.Read()

                Return IIf(IsDBNull(dr.Item("Costo2")), 0, dr.Item("Costo2"))

            Else

                Return 0

            End If

        Catch ex As Exception
            Throw New Exception("Hubo un problema al querer consultar el Costo Standard y Estimado del " & WMateriaPrima & " en la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

    End Function

    Private Function _CalcularCostoProducto(ByVal wProducto As String) As Double

        Dim WCosto = 0.0
        Dim XCosto2 = 0.0
        Dim WProductos(100, 2) As String
        Dim WMateriasPrimas(100, 3) As String
        Dim WTipo = "", WArticulo1 = "", WArticulo2 = "", WCantidad = 0.0, WVector = 0.0
        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand()
        Dim dr As SqlDataReader
        Dim WIndiceProductos = 1
        Dim WIndiceMateriasPrimas = 0

        Try
            WProductos(1, 1) = wProducto
            WProductos(1, 2) = "1"

            cn.ConnectionString = Helper._ConectarA
            cn.Open()
            cm.Connection = cn

            dr = Nothing

            For i = 1 To WProductos.Length

                If Not IsNothing(WProductos(i, 1)) AndAlso Trim(WProductos(i, 1)) <> "" Then

                    cm.CommandText = "SELECT Tipo, Articulo1, Articulo2, Cantidad FROM Composicion WHERE Terminado = '" & WProductos(i, 1) & "' ORDER BY Clave"

                    dr = cm.ExecuteReader()

                    If dr.HasRows Then

                        With dr
                            Do While .Read()

                                WTipo = IIf(IsDBNull(.Item("Tipo")), "", .Item("Tipo"))
                                WArticulo1 = IIf(IsDBNull(.Item("Articulo1")), "", .Item("Articulo1"))
                                WArticulo2 = IIf(IsDBNull(.Item("Articulo2")), "", .Item("Articulo2"))
                                WCantidad = IIf(IsDBNull(.Item("Cantidad")), "", .Item("Cantidad"))


                                Select Case UCase(WTipo)
                                    Case "T"

                                        If UCase(wProducto) <> UCase(WArticulo2) Then

                                            WIndiceProductos += 1
                                            WProductos(WIndiceProductos, 1) = WArticulo2
                                            WProductos(WIndiceProductos, 2) = Str$(WCantidad * Val(WProductos(i, 2)))

                                        End If

                                    Case "M"

                                        WIndiceMateriasPrimas += 1
                                        WMateriasPrimas(WIndiceMateriasPrimas, 1) = WArticulo1
                                        WMateriasPrimas(WIndiceMateriasPrimas, 2) = Str$(WCantidad)
                                        WMateriasPrimas(WIndiceMateriasPrimas, 3) = Str$(Val(WProductos(i, 2)))

                                    Case Else
                                        Continue For
                                End Select

                            Loop

                            If Not .IsClosed Then
                                .Close()
                            End If

                        End With

                    End If
                Else
                    Exit For
                End If

            Next

            If Not IsNothing(dr) AndAlso Not dr.IsClosed Then
                dr.Close()
            End If

            For i = 1 To WIndiceMateriasPrimas

                WArticulo1 = WMateriasPrimas(i, 1)
                WCantidad = Val(WMateriasPrimas(i, 2))
                WVector = Val(WMateriasPrimas(i, 3))

                XCosto2 = _CalcularCostoMP(WArticulo1) * WCantidad * WVector

                WCosto += XCosto2

            Next

        Catch ex As Exception
            Throw New Exception("Hubo un problema al querer consultar la Composición del " & wProducto & " la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

        Return WCosto

    End Function

    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged

        Select Case TabControl1.SelectedIndex
            Case 0
                With dgvFormula
                    .CurrentCell = .Rows(0).Cells(0)
                    .Focus()
                End With
            Case 1
                With dgvProceso
                    .CurrentCell = .Rows(0).Cells(0)
                    .Focus()
                End With
            Case 2
                With dgvLaboratorio
                    .CurrentCell = .Rows(0).Cells(0)
                    .Focus()
                End With
            Case 4
                With dgvRevisiones
                    .CurrentCell = .Rows(0).Cells(0)
                    .Focus()
                End With
            Case 5
                btnRecalculaCosto.PerformClick()

                If dgvCosto.Rows.Count > 0 Then
                    With dgvCosto
                        .CurrentCell = .Rows(0).Cells(0)
                        .Focus()
                    End With
                End If

        End Select

    End Sub

    Private Sub cmbTipoCalculo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTipoCalculo.SelectedIndexChanged
        btnRecalculaCosto.PerformClick()
    End Sub

    Private Sub btnLeerVersionAntFormula_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLeerVersionAntFormula.Click

        If Val(txtVersion.Text) > 1 Then

            _TraerDatosFormulaYCosto(Val(txtVersion.Text) - 1)

        End If

    End Sub

    Private Sub btnLeeVersionAntProceso_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLeeVersionAntProceso.Click

        If Val(txtVersion.Text) > 1 Then

            _TraerDatosProceso(Val(txtVersion.Text) - 1)
            
        End If

    End Sub

    Private Sub btnLeerVersionAntLab_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLeerVersionAntLab.Click

        If Val(txtVersion.Text) > 1 Then

            _TraerDatosLaboratorio(Val(txtVersion.Text) - 1)

        End If

    End Sub

    Private Sub btnLeerVersionAntDatosEntrada_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLeerVersionAntDatosEntrada.Click

        If Val(txtVersion.Text) > 1 Then

            _TraerDatosEntrada(Val(txtVersion.Text) - 1)

        End If

    End Sub

    Private Sub btnImprimeProceso_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimeProceso.Click

        With VistaPrevia
            .DesdeArchivo(Configuration.ConfigurationManager.AppSettings("reportsLocation") & "listaproceso.rpt")
            .Formula = "{CargaEnsayoIII.Orden}='" & txtOrden.Text & "' AND {CargaEnsayoIII.Version}='" & txtVersion.Text & "'"
            .Mostrar()
        End With

    End Sub

    Private Sub lstOpciones_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstOpciones.MouseClick
        Try
            Label16.Visible = False
            With txtBuscarEnTodosLosCampos
                .Text = ""
                .Visible = False
            End With

            If lstOpciones.SelectedIndex = 0 Then

                _CargarConsultaEnsayos()

                Label16.Visible = true
                With txtBuscarEnTodosLosCampos
                    .Text = ""
                    .Visible = True
                End With

            ElseIf lstOpciones.SelectedIndex = 1 Then

                _CargarClientes()

            End If

            pnlConsulta.Visible = True
            lstOpciones.Visible = False
            lstFiltrada.Visible = False
            lstConsulta.Visible = True
            txtAyuda.Text = ""
            txtAyuda.Focus()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
            pnlConsulta.Visible = False
            lstOpciones.Visible = True
            lstFiltrada.Visible = False
            lstConsulta.Visible = True
        End Try
    End Sub

    Private Sub _CargarConsultaEnsayos()
        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand()
        Dim dr As SqlDataReader
        Dim WTemp = "", WOrden = "", WVersion = "", WObservaciones = "", WDescCliente = ""
        Dim WItem As String = ""

        Try
            lstConsulta.Items.Clear()
            WIndice.Items.Clear()

            cn.ConnectionString = Helper._ConectarA
            cn.Open()
            cm.Connection = cn

            cm.CommandText = "SELECT CE.Orden, CE.Version, OT.Observaciones, ISNULL(C.Razon, '') " _
                                              & " as DesCliente FROM CargaEnsayo as CE, OrdenTrabajo as OT " _
                                              & " FULL OUTER JOIN Cliente as C ON OT.Cliente = C.Cliente WHERE CE.Orden <> '  -     ' " _
                                              & " AND CE.Orden = OT.Orden ORDER BY CE.Clave, ce.Orden, ce.Version"
            dr = cm.ExecuteReader()

            If dr.HasRows Then

                Do While dr.Read()

                    WItem = ""
                    WTemp = ""

                    WOrden = IIf(IsDBNull(dr.Item("Orden")), "", dr.Item("Orden"))
                    WVersion = IIf(IsDBNull(dr.Item("Version")), "", dr.Item("Version"))
                    WObservaciones = IIf(IsDBNull(dr.Item("Observaciones")), "", dr.Item("Observaciones"))
                    WDescCliente = IIf(IsDBNull(dr.Item("DesCliente")), "", dr.Item("DesCliente"))

                    WTemp = Trim(WOrden) & "/" & Trim(WVersion)

                    WItem = WTemp.PadRight(15) & Space(5) & Trim(WObservaciones)

                    If Trim(WDescCliente) <> "" Then
                        WItem &= Space(5) & "(" & Trim(WDescCliente) & ")"
                    End If

                    lstConsulta.Items.Add(WItem)
                    WIndice.Items.Add(WTemp)

                Loop

            End If

        Catch ex As Exception
            Throw New Exception("Hubo un problema al querer consultar la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

    End Sub

    Private Sub txtRequisitosI_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRequisitosI.KeyDown

        If e.KeyData = Keys.Enter Then
            'If Trim(txtRequisitosI.Text) = "" Then : Exit Sub : End If

            txtComentariosI.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtRequisitosI.Text = ""
        End If

    End Sub

    Private Sub txtComentariosI_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtComentariosI.KeyDown

        If e.KeyData = Keys.Enter Then
            'If Trim(txtRequisitosI.Text) = "" Then : Exit Sub : End If

            txtRequisitosII.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtComentariosI.Text = ""
        End If

    End Sub

    Private Sub txtRequisitosII_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRequisitosII.KeyDown

        If e.KeyData = Keys.Enter Then
            'If Trim(txtRequisitosI.Text) = "" Then : Exit Sub : End If

            txtComentariosII.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtRequisitosII.Text = ""
        End If

    End Sub

    Private Sub txtComentariosII_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtComentariosII.KeyDown

        If e.KeyData = Keys.Enter Then
            'If Trim(txtRequisitosI.Text) = "" Then : Exit Sub : End If

            txtRequisitosIII.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtComentariosII.Text = ""
        End If

    End Sub

    Private Sub txtRequisitosIII_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRequisitosIII.KeyDown

        If e.KeyData = Keys.Enter Then
            'If Trim(txtRequisitosI.Text) = "" Then : Exit Sub : End If

            txtComentariosIII.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtRequisitosIII.Text = ""
        End If

    End Sub

    Private Sub txtComentariosIII_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtComentariosIII.KeyDown

        If e.KeyData = Keys.Enter Then
            'If Trim(txtRequisitosI.Text) = "" Then : Exit Sub : End If

            txtRequisitosIV.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtComentariosIII.Text = ""
        End If

    End Sub

    Private Sub txtRequisitosIV_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRequisitosIV.KeyDown

        If e.KeyData = Keys.Enter Then
            'If Trim(txtRequisitosI.Text) = "" Then : Exit Sub : End If

            txtComentariosIV.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtRequisitosIV.Text = ""
        End If

    End Sub

    Private Sub txtComentariosIV_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtComentariosIV.KeyDown

        If e.KeyData = Keys.Enter Then
            'If Trim(txtRequisitosI.Text) = "" Then : Exit Sub : End If

            txtRequisitosV.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtComentariosIV.Text = ""
        End If

    End Sub

    Private Sub txtRequisitosV_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRequisitosV.KeyDown

        If e.KeyData = Keys.Enter Then
            'If Trim(txtRequisitosI.Text) = "" Then : Exit Sub : End If

            txtComentariosV.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtRequisitosV.Text = ""
        End If

    End Sub

    Private Sub txtComentariosV_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtComentariosV.KeyDown

        If e.KeyData = Keys.Enter Then
            'If Trim(txtRequisitosI.Text) = "" Then : Exit Sub : End If

            txtRequisitosVI.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtComentariosV.Text = ""
        End If

    End Sub

    Private Sub txtRequisitosVI_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRequisitosVI.KeyDown

        If e.KeyData = Keys.Enter Then
            'If Trim(txtRequisitosI.Text) = "" Then : Exit Sub : End If

            txtComentariosVI.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtRequisitosVI.Text = ""
        End If

    End Sub

    Private Sub txtComentariosVI_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtComentariosVI.KeyDown

        If e.KeyData = Keys.Enter Then
            'If Trim(txtRequisitosI.Text) = "" Then : Exit Sub : End If

            txtRequisitosVII.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtComentariosVI.Text = ""
        End If

    End Sub

    Private Sub txtRequisitosVII_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRequisitosVII.KeyDown

        If e.KeyData = Keys.Enter Then
            'If Trim(txtRequisitosI.Text) = "" Then : Exit Sub : End If

            txtComentariosVII.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtRequisitosVII.Text = ""
        End If

    End Sub

    Private Sub txtComentariosVII_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtComentariosVII.KeyDown

        If e.KeyData = Keys.Enter Then
            'If Trim(txtRequisitosI.Text) = "" Then : Exit Sub : End If

            txtRequisitosVIII.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtComentariosVII.Text = ""
        End If

    End Sub


    Private Sub txtRequisitosVIII_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRequisitosVIII.KeyDown

        If e.KeyData = Keys.Enter Then
            'If Trim(txtRequisitosI.Text) = "" Then : Exit Sub : End If

            txtComentariosVIII.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtRequisitosVIII.Text = ""
        End If

    End Sub

    Private Sub txtComentariosVIII_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtComentariosVIII.KeyDown

        If e.KeyData = Keys.Enter Then
            'If Trim(txtRequisitosI.Text) = "" Then : Exit Sub : End If

            txtRequisitosIX.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtComentariosVIII.Text = ""
        End If

    End Sub


    Private Sub txtRequisitosIX_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRequisitosIX.KeyDown

        If e.KeyData = Keys.Enter Then
            'If Trim(txtRequisitosI.Text) = "" Then : Exit Sub : End If

            txtComentariosIX.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtRequisitosIX.Text = ""
        End If

    End Sub

    Private Sub txtComentariosIX_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtComentariosIX.KeyDown

        If e.KeyData = Keys.Enter Then
            'If Trim(txtRequisitosI.Text) = "" Then : Exit Sub : End If

            txtRequisitosX.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtComentariosIX.Text = ""
        End If

    End Sub

    Private Sub txtRequisitosX_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRequisitosX.KeyDown

        If e.KeyData = Keys.Enter Then
            'If Trim(txtRequisitosI.Text) = "" Then : Exit Sub : End If

            txtComentariosX.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtRequisitosX.Text = ""
        End If

    End Sub

    Private Sub txtComentariosX_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtComentariosX.KeyDown

        If e.KeyData = Keys.Enter Then
            'If Trim(txtRequisitosI.Text) = "" Then : Exit Sub : End If

            txtRequisitosXI.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtComentariosX.Text = ""
        End If

    End Sub

    Private Sub txtRequisitosXI_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRequisitosXI.KeyDown

        If e.KeyData = Keys.Enter Then
            'If Trim(txtRequisitosI.Text) = "" Then : Exit Sub : End If

            txtComentariosXI.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtRequisitosXI.Text = ""
        End If

    End Sub

    Private Sub txtComentariosXI_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtComentariosXI.KeyDown

        If e.KeyData = Keys.Enter Then
            'If Trim(txtRequisitosI.Text) = "" Then : Exit Sub : End If

            txtRequisitosXII.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtComentariosXI.Text = ""
        End If

    End Sub

    Private Sub txtRequisitosXII_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRequisitosXII.KeyDown

        If e.KeyData = Keys.Enter Then
            'If Trim(txtRequisitosI.Text) = "" Then : Exit Sub : End If

            txtComentariosXII.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtRequisitosXII.Text = ""
        End If

    End Sub

    Private Sub txtComentariosXII_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtComentariosXII.KeyDown

        If e.KeyData = Keys.Enter Then
            'If Trim(txtRequisitosI.Text) = "" Then : Exit Sub : End If

            txtRequisitosI.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtComentariosXII.Text = ""
        End If

    End Sub

    Private Sub txtCantidad_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCantidad.KeyDown
        If e.KeyData = Keys.Enter Then
            '    If Trim(txtEncargado.Text) = "" Then : Exit Sub : End If

            TabControl1.SelectedIndex = 0

            txtCantidad.Text = Helper.formatonumerico(txtCantidad.Text, 4)

            With dgvFormula
                If .Rows.Count > 0 Then
                    .CurrentCell = .Rows(0).Cells(0)
                    .Focus()
                End If
            End With

        ElseIf e.KeyData = Keys.Escape Then
            txtCantidad.Text = ""
        End If
    End Sub

    Private Sub btnHojaPiloto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHojaPiloto.Click

        pnlHojaPiloto.Visible = True
        txtDescripcionHojaPiloto.Text = ""
        txtDescripcionHojaPiloto.Focus()

    End Sub

    Private Sub txtDescripcionHojaPiloto_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDescripcionHojaPiloto.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txtDescripcionHojaPiloto.Text) = "" Then : Exit Sub : End If

            Try
                _GenerarHojaPiloto()

                'btnLimpiar.PerformClick()

            Catch ex As Exception
                MsgBox("Se detuvo la generación de Hoja Piloto." & vbCrLf & vbCrLf & " Motivo: " & ex.Message, MsgBoxStyle.Exclamation)
            End Try
        ElseIf e.KeyData = Keys.Escape Then
            txtDescripcionHojaPiloto.Text = ""
        End If

    End Sub

    Private Sub _GenerarHojaPiloto()

        Dim WEmpresa = 0
        Dim WTipo = "", WArticulo = "", WTerminado = "", WCantidad = "", WLote = "0", WHoja = 0, WCodigo = "", WDescripcion = ""
        Dim WClave = "", WRenglon = 0, WFecha = "", WProducto = "", WTeorico = "0", WReal = "0", WFechaIng = "", WFechaIngOrd = "", WWDate = "", WWImporte = "0", WMARCA = "", WSaldo = "0", WLote1 = "0", WCanti1 = "0", WLote2 = "0", WCanti2 = "0", WLote3 = "0", WCanti3 = "0", WCosto1 = "0", WCosto2 = "0", WCosto3 = "0", WMarcaant = "", WSaldoant = "0", WRealant = "0", WFechaOrd = "", WEquipo = "", WMarcaLabora = "", WEstado = "", WVersionI = "0", WVersionII = "0", WVersionIII = "0", WEstadoII = "", WImpreArticulo = "", WFechaInicio = "", WHoraInicio = "", WFechaFinal = "", WHoraFinal = "", WPorceDife = "0", WImpresionI = "", WImpresionII = "", WMotivoDesvio = "0", WObservaDesvio = "", WImpreReal = "0", WOperario = "0", WEstadoHoja = "0", WEtapa = "0", WFechaInicioEtapa = "", WHoraInicioEtapa = "", WTimerInicioEtapa = "0", WAlarma = "", WControlI = "0", WControlII = "0", WDesdeI = "0", WHastaI = "0", WTiempoI = "0", WTiempoII = "0", WAlarmaI = "", WAlarmaII = "", WAlarmaITiempo = "0", WAlarmaITempe = "0", WTiempoIII = "0", WTemperatura = "0", WTipoEtapa = "0", WEnvasamiento = "", WEquipoII = "0", WDesde = "0", WHasta = "0", WLista = "", WSuma1 = "0", WSuma2 = "0", WSuma3 = "0", WSuma4 = "0", WSuma5 = "0", WSuma6 = "0", WIdentificacion = "", WNroPedido = "0", WFechaVencimiento = "", WOrdFechaVencimiento = "", WRevalida = "0", WFechaRevalida = "", WOrdFechaRevalida = "", WMesesRevalida = "0", WMarcaVencida = "", WLoteColorante = "", WTipoOri = "", WImpreVersion = "0", WImpreFechaVersion = "", WLiberaFarma = "", WFechaReanalisis = "", WImpreAlmacenero = "", WSeguridad = "", WSaldoCierre = "0", WCosto = "0", ZSql = "", WDate = ""
        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("")
        Dim trans As SqlTransaction = Nothing
        Dim WPaso = 0

        'Calculamos los datos para la barra de progreso.
        prgbHojaPiloto.Visible = True
        prgbHojaPiloto.Maximum = 100
        prgbHojaPiloto.Minimum = 0
        prgbHojaPiloto.Value = 0
        WPaso = 100 / dgvFormula.Rows.Count * 0.1
        prgbHojaPiloto.Step = WPaso

        ' Verificamos que no haya ya un numero de Hoja.
        If Val(txtHojaProduccion.Text) > 0 Then
            Throw New Exception("Hoja de Producción ya ingresada")
        End If

        ' Verificamos que se haya elegido una planta.
        If cmbPlanta.SelectedIndex = 0 Then
            Throw New Exception("NO SE INFORMO PLANTA EN LA QUE SE DEBE DESCONTAR EL STOCK")
        End If

        ' Determinamos la Planta con la que trabajar.
        If Helper._EsPellital Then
            WEmpresa = 8
        Else

            Select Case cmbPlanta.SelectedIndex
                Case 1
                    WEmpresa = 3
                Case 2
                    WEmpresa = 1
                Case 3
                    WEmpresa = 5
                Case Else
                    Throw New Exception("No se ha seleccionado una Planta válida.")
            End Select

        End If

        ' Modificamos la empresa, segun casos especiales.
        If WEmpresa = 3 Then
            If UCase(txtOrden.Text).StartsWith("IF") Then
                WEmpresa = 5
            End If

            If UCase(txtOrden.Text).StartsWith("IP") Then
                WEmpresa = 1
            End If
        End If

        prgbHojaPiloto.Step += WPaso

        ' Verificamos Stock de items cargados en Fórmula.
        For Each _row As DataGridViewRow In dgvFormula.Rows

            WTipo = IIf(IsNothing(_row.Cells("TipoFormula").Value), "", _row.Cells("TipoFormula").Value)
            WArticulo = IIf(IsNothing(_row.Cells("ArticuloFormula").Value), "", _row.Cells("ArticuloFormula").Value)
            WTerminado = IIf(IsNothing(_row.Cells("TerminadoFormula").Value), "", _row.Cells("TerminadoFormula").Value)
            WCantidad = IIf(IsNothing(_row.Cells("CantidadFormula").Value), "", _row.Cells("CantidadFormula").Value)
            WLote = IIf(IsNothing(_row.Cells("LoteFormula").Value), "", _row.Cells("LoteFormula").Value)

            If Trim(WCantidad) = "" Then Continue For


            Select Case UCase(WTipo)
                Case "M"

                    If Not _StockSuficienteMP(WArticulo, WCantidad, WEmpresa) Then
                        Throw New Exception("Producto Inexistente o Stock Insuficiente del Artículo " & WArticulo)
                    End If

                Case "T"

                    If Not _StockSuficienteTerminado(WTerminado, WCantidad, WEmpresa) Then
                        Throw New Exception("Producto Inexistente o Stock Insuficiente para el Producto Terminado " & WTerminado)
                    End If

            End Select

        Next

        ' Calculamos el Siguiente Número de Hoja Correspondiente según Empresa.
        Try
            WHoja = _SiguienteNumeroHojaProduccion(WEmpresa)
            txtHojaProduccion.Text = WHoja
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try

        Try
            ' Generamos el Código y damos de alta el nuevo código en caso de no existir.

            WCodigo = txtOrden.Text & "-100"
            WDescripcion = Trim(txtDescripcionHojaPiloto.Text)

            If Not _ExisteTerminado(WCodigo, WEmpresa) Then

                _CrearTerminado(WCodigo, WDescripcion, WEmpresa)

            End If

            ' Guardamos los datos generales de la Hoja

            WFecha = Date.Now.ToString("dd/MM/yyyy")
            WFechaOrd = Helper.ordenaFecha(WFecha)
            WProducto = txtOrden.Text & "-100"
            WTeorico = Helper.formatonumerico(txtCantidad.Text, 4)
            WFechaIng = "  /  /    "
            WDate = Date.Now.ToString("MM-dd-yyyy")
            WSaldo = WTeorico
            WLote = "0"

            Try

                ' Damos de alta la Hoja.

                cn.ConnectionString = Helper._ConectarA(WEmpresa)
                cn.Open()
                trans = cn.BeginTransaction
                cm.Connection = cn
                cm.Transaction = trans

                For Each _row As DataGridViewRow In dgvFormula.Rows

                    With _row

                        WTipo = IIf(IsNothing(.Cells("TipoFormula").Value), "", .Cells("TipoFormula").Value)
                        WArticulo = IIf(IsNothing(.Cells("ArticuloFormula").Value), "", .Cells("ArticuloFormula").Value)
                        WTerminado = IIf(IsNothing(.Cells("TerminadoFormula").Value), "", .Cells("TerminadoFormula").Value)
                        WCantidad = IIf(IsNothing(.Cells("CantidadFormula").Value), "", .Cells("CantidadFormula").Value)

                        If WCantidad = "" Then Continue For

                        WRenglon = .Index + 1

                    End With

                    WClave = Helper.ceros(WHoja, 6) & Helper.ceros(WRenglon, 2)

                    ZSql = ""
                    ZSql &= "INSERT INTO Hoja (Clave,"
                    ZSql &= "Hoja,"
                    ZSql &= "Renglon,"
                    ZSql &= "Fecha,"
                    ZSql &= "Producto,"
                    ZSql &= "Cantidad,"
                    ZSql &= "Tipo,"
                    ZSql &= "Lote,"
                    ZSql &= "Articulo,"
                    ZSql &= "Terminado,"
                    ZSql &= "Teorico,"
                    ZSql &= "Real,"
                    ZSql &= "FechaIng,"
                    ZSql &= "FechaIngOrd,"
                    ZSql &= "WDate,"
                    ZSql &= "WImporte,"
                    ZSql &= "MARCA,"
                    ZSql &= "Saldo,"
                    ZSql &= "Lote1,"
                    ZSql &= "Canti1,"
                    ZSql &= "Lote2,"
                    ZSql &= "Canti2,"
                    ZSql &= "Lote3,"
                    ZSql &= "Canti3,"
                    ZSql &= "Costo1,"
                    ZSql &= "Costo2,"
                    ZSql &= "Costo3,"
                    ZSql &= "Marcaant,"
                    ZSql &= "Saldoant,"
                    ZSql &= "Realant,"
                    ZSql &= "FechaOrd,"
                    ZSql &= "Equipo,"
                    ZSql &= "MarcaLabora,"
                    ZSql &= "Estado,"
                    ZSql &= "VersionI,"
                    ZSql &= "VersionII,"
                    ZSql &= "VersionIII,"
                    ZSql &= "EstadoII,"
                    ZSql &= "ImpreArticulo,"
                    ZSql &= "FechaInicio,"
                    ZSql &= "HoraInicio,"
                    ZSql &= "FechaFinal,"
                    ZSql &= "HoraFinal,"
                    ZSql &= "PorceDife,"
                    ZSql &= "ImpresionI,"
                    ZSql &= "ImpresionII,"
                    ZSql &= "MotivoDesvio,"
                    ZSql &= "ObservaDesvio,"
                    ZSql &= "ImpreReal,"
                    ZSql &= "Operario,"
                    ZSql &= "EstadoHoja,"
                    ZSql &= "Etapa,"
                    ZSql &= "FechaInicioEtapa,"
                    ZSql &= "HoraInicioEtapa,"
                    ZSql &= "TimerInicioEtapa,"
                    ZSql &= "Alarma,"
                    ZSql &= "ControlI,"
                    ZSql &= "ControlII,"
                    ZSql &= "DesdeI,"
                    ZSql &= "HastaI,"
                    ZSql &= "TiempoI,"
                    ZSql &= "TiempoII,"
                    ZSql &= "AlarmaI,"
                    ZSql &= "AlarmaII,"
                    ZSql &= "AlarmaITiempo,"
                    ZSql &= "AlarmaITempe,"
                    ZSql &= "TiempoIII,"
                    ZSql &= "Temperatura,"
                    ZSql &= "TipoEtapa,"
                    ZSql &= "Envasamiento,"
                    ZSql &= "EquipoII,"
                    ZSql &= "Desde,"
                    ZSql &= "Hasta,"
                    ZSql &= "Lista,"
                    ZSql &= "Suma1,"
                    ZSql &= "Suma2,"
                    ZSql &= "Suma3,"
                    ZSql &= "Suma4,"
                    ZSql &= "Suma5,"
                    ZSql &= "Suma6,"
                    ZSql &= "Identificacion,"
                    ZSql &= "NroPedido,"
                    ZSql &= "FechaVencimiento,"
                    ZSql &= "OrdFechaVencimiento,"
                    ZSql &= "Revalida,"
                    ZSql &= "FechaRevalida,"
                    ZSql &= "OrdFechaRevalida,"
                    ZSql &= "MesesRevalida,"
                    ZSql &= "MarcaVencida,"
                    ZSql &= "LoteColorante,"
                    ZSql &= "TipoOri,"
                    ZSql &= "ImpreVersion,"
                    ZSql &= "ImpreFechaVersion,"
                    ZSql &= "LiberaFarma,"
                    ZSql &= "FechaReanalisis,"
                    ZSql &= "ImpreAlmacenero,"
                    ZSql &= "Seguridad,"
                    ZSql &= "SaldoCierre,"
                    ZSql &= "Costo"
                    ZSql &= ")"
                    ZSql &= "VALUES("
                    ZSql &= "'" & WClave & "',"
                    ZSql &= "" & Str$(WHoja) & ","
                    ZSql &= "" & Str$(WRenglon) & ","
                    ZSql &= "'" & WFecha & "',"
                    ZSql &= "'" & WProducto & "',"
                    ZSql &= "" & WCantidad & ","
                    ZSql &= "'" & WTipo & "',"
                    ZSql &= "" & WLote & ","
                    ZSql &= "'" & WArticulo & "',"
                    ZSql &= "'" & WTerminado & "',"
                    ZSql &= "" & WTeorico & ","
                    ZSql &= "" & WReal & ","
                    ZSql &= "'" & WFechaIng & "',"
                    ZSql &= "'" & WFechaIngOrd & "',"
                    ZSql &= "'" & WWDate & "',"
                    ZSql &= "" & WWImporte & ","
                    ZSql &= "'" & WMARCA & "',"
                    ZSql &= "" & WSaldo & ","
                    ZSql &= "" & WLote1 & ","
                    ZSql &= "" & WCanti1 & ","
                    ZSql &= "" & WLote2 & ","
                    ZSql &= "" & WCanti2 & ","
                    ZSql &= "" & WLote3 & ","
                    ZSql &= "" & WCanti3 & ","
                    ZSql &= "" & WCosto1 & ","
                    ZSql &= "" & WCosto2 & ","
                    ZSql &= "" & WCosto3 & ","
                    ZSql &= "'" & WMarcaant & "',"
                    ZSql &= "" & WSaldoant & ","
                    ZSql &= "" & WRealant & ","
                    ZSql &= "'" & WFechaOrd & "',"
                    ZSql &= "'" & WEquipo & "',"
                    ZSql &= "'" & WMarcaLabora & "',"
                    ZSql &= "'" & WEstado & "',"
                    ZSql &= "" & WVersionI & ","
                    ZSql &= "" & WVersionII & ","
                    ZSql &= "" & WVersionIII & ","
                    ZSql &= "'" & WEstadoII & "',"
                    ZSql &= "'" & WImpreArticulo & "',"
                    ZSql &= "'" & WFechaInicio & "',"
                    ZSql &= "'" & WHoraInicio & "',"
                    ZSql &= "'" & WFechaFinal & "',"
                    ZSql &= "'" & WHoraFinal & "',"
                    ZSql &= "" & WPorceDife & ","
                    ZSql &= "'" & WImpresionI & "',"
                    ZSql &= "'" & WImpresionII & "',"
                    ZSql &= "" & WMotivoDesvio & ","
                    ZSql &= "'" & WObservaDesvio & "',"
                    ZSql &= "" & WImpreReal & ","
                    ZSql &= "" & WOperario & ","
                    ZSql &= "" & WEstadoHoja & ","
                    ZSql &= "" & WEtapa & ","
                    ZSql &= "'" & WFechaInicioEtapa & "',"
                    ZSql &= "'" & WHoraInicioEtapa & "',"
                    ZSql &= "" & WTimerInicioEtapa & ","
                    ZSql &= "'" & WAlarma & "',"
                    ZSql &= "" & WControlI & ","
                    ZSql &= "" & WControlII & ","
                    ZSql &= "" & WDesdeI & ","
                    ZSql &= "" & WHastaI & ","
                    ZSql &= "" & WTiempoI & ","
                    ZSql &= "" & WTiempoII & ","
                    ZSql &= "'" & WAlarmaI & "',"
                    ZSql &= "'" & WAlarmaII & "',"
                    ZSql &= "" & WAlarmaITiempo & ","
                    ZSql &= "" & WAlarmaITempe & ","
                    ZSql &= "" & WTiempoIII & ","
                    ZSql &= "" & WTemperatura & ","
                    ZSql &= "" & WTipoEtapa & ","
                    ZSql &= "'" & WEnvasamiento & "',"
                    ZSql &= "" & WEquipoII & ","
                    ZSql &= "" & WDesde & ","
                    ZSql &= "" & WHasta & ","
                    ZSql &= "'" & WLista & "',"
                    ZSql &= "" & WSuma1 & ","
                    ZSql &= "" & WSuma2 & ","
                    ZSql &= "" & WSuma3 & ","
                    ZSql &= "" & WSuma4 & ","
                    ZSql &= "" & WSuma5 & ","
                    ZSql &= "" & WSuma6 & ","
                    ZSql &= "'" & WIdentificacion & "',"
                    ZSql &= "" & WNroPedido & ","
                    ZSql &= "'" & WFechaVencimiento & "',"
                    ZSql &= "'" & WOrdFechaVencimiento & "',"
                    ZSql &= "" & WRevalida & ","
                    ZSql &= "'" & WFechaRevalida & "',"
                    ZSql &= "'" & WOrdFechaRevalida & "',"
                    ZSql &= "" & WMesesRevalida & ","
                    ZSql &= "'" & WMarcaVencida & "',"
                    ZSql &= "'" & WLoteColorante & "',"
                    ZSql &= "'" & WTipoOri & "',"
                    ZSql &= "" & WImpreVersion & ","
                    ZSql &= "'" & WImpreFechaVersion & "',"
                    ZSql &= "'" & WLiberaFarma & "',"
                    ZSql &= "'" & WFechaReanalisis & "',"
                    ZSql &= "'" & WImpreAlmacenero & "',"
                    ZSql &= "'" & WSeguridad & "',"
                    ZSql &= "" & WSaldoCierre & ","
                    ZSql &= "" & WCosto & ")"

                    cm.CommandText = ZSql

                    cm.ExecuteNonQuery()

                    ' Actualizamos el Saldo en Proceso del Terminado
                    If WRenglon = 1 Then

                        ZSql = ""
                        ZSql = "UPDATE Terminado SET Proceso = Proceso + " & Helper.formatonumerico(txtCantidad.Text, 4) & ", WDate = '" & WDate & "' WHERE Codigo = '" & WCodigo & "'"

                        cm.CommandText = ZSql
                        cm.ExecuteNonQuery()

                    End If

                    ' Actualizamos los valores de Salidas segun el tipo

                    Select Case UCase(WTipo)
                        Case "T"

                            ZSql = ""
                            ZSql = "UPDATE Terminado SET Salidas = Salidas + " & Helper.formatonumerico(WCantidad, 3) & ", WDate = '" & WDate & "' WHERE Codigo = '" & WTerminado & "'"

                            cm.CommandText = ZSql
                            cm.ExecuteNonQuery()

                        Case "M"

                            ZSql = ""
                            ZSql = "UPDATE Articulo SET Salidas = Salidas + " & Helper.formatonumerico(txtCantidad.Text, 4) & ", WDate = '" & WDate & "' WHERE Codigo = '" & WArticulo & "'"

                            cm.CommandText = ZSql
                            cm.ExecuteNonQuery()

                    End Select

                    Threading.Thread.Sleep(100)
                    prgbHojaPiloto.Increment(1)

                Next

                ' Actualizamos datos generales de la Hoja.

                ZSql = ""
                ZSql = "UPDATE Hoja SET Equipo = '', VersionI = 0, VersionII = 0, VersionIII = 0, MarcaLabora = 'S' WHERE Hoja = '" & WHoja & "'"

                cm.CommandText = ZSql
                cm.ExecuteNonQuery()

                ' Actualizamos CargaEnsayoII

                ZSql = ""
                ZSql = "UPDATE CargaEnsayoII SET Hoja = '" & WHoja & "' WHERE Orden = '" & txtOrden.Text & "' AND Version = '" & txtVersion.Text & "'"

                cm.CommandText = ZSql
                cm.ExecuteNonQuery()

                trans.Commit()

                prgbHojaPiloto.Value = 100

                ' ACA LLAMAR A LA IMPRESION

                _ImprimirHojaPiloto()

                ' Ocultamos el Panel
                pnlHojaPiloto.Visible = False
                txtDescripcionHojaPiloto.Text = ""

            Catch ex As Exception
                If Not IsNothing(trans) Then
                    trans.Rollback()
                End If
                Throw New Exception("Hubo un problema al querer generar la Hoja Piloto en la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
            Finally

                cn.Close()
                cn = Nothing
                cm = Nothing

            End Try

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try


    End Sub

    Private Sub _ImprimirHojaPiloto()
        Dim ZSql = "", WTipo = "", WArticulo = "", WTerminado = "", WHoja = "", WLinea = "", WFecha = "", WCodigo1 = "", WCodigo2 = "", WArticulo1 = "", WArticulo2 = "", WCantidad = "", WDetalle = "", WTeorico = ""
        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("")

        Try

            cn.ConnectionString = Helper._ConectarA
            cn.Open()
            cm.Connection = cn

            cm.CommandText = "DELETE ImpreHoja"
            cm.ExecuteNonQuery()

            WHoja = txtHojaProduccion.Text

            If Val(WHoja) = 0 Then
                Throw New Exception("Número de Hoja de Produccion Inválida.")
            End If

            WTeorico = Helper.formatonumerico(txtCantidad.Text, 4)
            WCodigo1 = txtOrden.Text.SliceLeft(2)
            WCodigo2 = txtOrden.Text.SliceRight(5) & "/100"
            WFecha = txtFecha.Text

            For Each _row As DataGridViewRow In dgvFormula.Rows

                With _row

                    WTipo = IIf(IsNothing(.Cells("TipoFormula").Value), "", .Cells("TipoFormula").Value)
                    WArticulo = IIf(IsNothing(.Cells("ArticuloFormula").Value), "", .Cells("ArticuloFormula").Value)
                    WTerminado = IIf(IsNothing(.Cells("TerminadoFormula").Value), "", .Cells("TerminadoFormula").Value)
                    WDetalle = IIf(IsNothing(.Cells("DescripcionFormula").Value), "", .Cells("DescripcionFormula").Value)
                    WCantidad = IIf(IsNothing(.Cells("CantidadFormula").Value), "", .Cells("CantidadFormula").Value)

                    If Trim(WCantidad) = "" Then Continue For

                    WLinea = Str$(.Index + 1)

                End With

                If UCase(WTipo) = "M" Then
                    WArticulo1 = WArticulo.SliceLeft(2)
                    WArticulo2 = Mid$(WArticulo, 4, 3) + "-" + WArticulo.SliceRight(3)
                Else
                    WArticulo1 = WTerminado.SliceLeft(2)
                    WArticulo2 = Mid$(WTerminado, 4, 5) + "-" + WTerminado.SliceRight(3)
                End If

                ZSql = ""
                ZSql = ZSql & "INSERT INTO ImpreHoja ("
                ZSql = ZSql & "Hoja ,"
                ZSql = ZSql & "Renglon ,"
                ZSql = ZSql & "Fecha ,"
                ZSql = ZSql & "Codigo1 ,"
                ZSql = ZSql & "Codigo2 ,"
                ZSql = ZSql & "Maquina ,"
                ZSql = ZSql & "Articulo1 ,"
                ZSql = ZSql & "Articulo2 ,"
                ZSql = ZSql & "Cantidad ,"
                ZSql = ZSql & "Teorico ,"
                ZSql = ZSql & "Metodo ,"
                ZSql = ZSql & "Efluentes ,"
                ZSql = ZSql & "DesEfluentesI ,"
                ZSql = ZSql & "DesEfluentesII ,"
                ZSql = ZSql & "VersionI ,"
                ZSql = ZSql & "VersionII ,"
                ZSql = ZSql & "VersionIII ,"
                ZSql = ZSql & "Detalle ,"
                ZSql = ZSql & "Equipo )"
                ZSql = ZSql & "Values ("
                ZSql = ZSql & "'" + WHoja + "',"
                ZSql = ZSql & "'" + WLinea + "',"
                ZSql = ZSql & "'" + WFecha + "',"
                ZSql = ZSql & "'" + WCodigo1 + "',"
                ZSql = ZSql & "'" + WCodigo2 + "',"
                ZSql = ZSql & "'',"
                ZSql = ZSql & "'" + WArticulo1 + "',"
                ZSql = ZSql & "'" + WArticulo2 + "',"
                ZSql = ZSql & "'" + WCantidad + "',"
                ZSql = ZSql & "'" + WTeorico + "',"
                ZSql = ZSql & "'',"
                ZSql = ZSql & "'',"
                ZSql = ZSql & "'',"
                ZSql = ZSql & "'',"
                ZSql = ZSql & "'',"
                ZSql = ZSql & "'',"
                ZSql = ZSql & "'',"
                ZSql = ZSql & "'" + WDetalle + "',"
                ZSql = ZSql & "'')"

                cm.CommandText = ZSql
                cm.ExecuteNonQuery()

            Next

            WArticulo1 = ""
            WArticulo2 = ""
            WDetalle = ""
            WCantidad = ""

            ' Completamos las filas que falten.
            For i = Val(WLinea) + 1 To 14

                WLinea = Str$(i)

                ZSql = ""
                ZSql = ZSql & "INSERT INTO ImpreHoja ("
                ZSql = ZSql & "Hoja ,"
                ZSql = ZSql & "Renglon ,"
                ZSql = ZSql & "Fecha ,"
                ZSql = ZSql & "Codigo1 ,"
                ZSql = ZSql & "Codigo2 ,"
                ZSql = ZSql & "Maquina ,"
                ZSql = ZSql & "Articulo1 ,"
                ZSql = ZSql & "Articulo2 ,"
                ZSql = ZSql & "Cantidad ,"
                ZSql = ZSql & "Teorico ,"
                ZSql = ZSql & "Metodo ,"
                ZSql = ZSql & "Efluentes ,"
                ZSql = ZSql & "DesEfluentesI ,"
                ZSql = ZSql & "DesEfluentesII ,"
                ZSql = ZSql & "VersionI ,"
                ZSql = ZSql & "VersionII ,"
                ZSql = ZSql & "VersionIII ,"
                ZSql = ZSql & "Detalle ,"
                ZSql = ZSql & "Equipo )"
                ZSql = ZSql & "Values ("
                ZSql = ZSql & "'" + WHoja + "',"
                ZSql = ZSql & "'" + WLinea + "',"
                ZSql = ZSql & "'" + WFecha + "',"
                ZSql = ZSql & "'" + WCodigo1 + "',"
                ZSql = ZSql & "'" + WCodigo2 + "',"
                ZSql = ZSql & "'',"
                ZSql = ZSql & "'" + WArticulo1 + "',"
                ZSql = ZSql & "'" + WArticulo2 + "',"
                ZSql = ZSql & "'" + WCantidad + "',"
                ZSql = ZSql & "'" + WTeorico + "',"
                ZSql = ZSql & "'',"
                ZSql = ZSql & "'',"
                ZSql = ZSql & "'',"
                ZSql = ZSql & "'',"
                ZSql = ZSql & "'',"
                ZSql = ZSql & "'',"
                ZSql = ZSql & "'',"
                ZSql = ZSql & "'" + WDetalle + "',"
                ZSql = ZSql & "'')"

                cm.CommandText = ZSql
                cm.ExecuteNonQuery()
            Next

            ' Generamos el Reporte y lo mostramos por pantalla. > Cambiar dsp para que salga impreso directamente.
            With VistaPrevia
                .DesdeArchivo(Configuration.ConfigurationManager.AppSettings("reportslocation") & "imprehojadesarrollo.rpt")
                .Formula = "{ImpreHoja.Hoja}=" & WHoja
                .Mostrar()
            End With

        Catch ex As Exception
            Throw New Exception("Hubo un problema al querer Imprimir la Hoja Piloto para la Orden " & txtOrden.Text & " Version " & txtVersion.Text & "." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        Finally

            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

    End Sub

    Private Sub _CrearTerminado(ByVal wCodigo As String, ByVal wDescripcion As String, ByVal wEmpresa As Integer)
        If String.IsNullOrEmpty(wCodigo) Or String.IsNullOrEmpty(wDescripcion) Or wEmpresa = 0 Then
            Throw New Exception("Datos para dar de alta Nuevo Código de Terminado incorrectos.")
        End If

        Dim ZSql = "", WEmpresas() = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}

        ' Determinamos en que plantas se van a realizar las altas.
        Select Case Val(wEmpresa)

            Case 3
                WEmpresas(1) = 1
                WEmpresas(2) = 3
                WEmpresas(3) = 5
                WEmpresas(4) = 6
                WEmpresas(5) = 7

            Case 4
                WEmpresas(1) = 2
                WEmpresas(2) = 4
                WEmpresas(3) = 8
                WEmpresas(4) = 9

            Case 5
                WEmpresas(1) = 2
                WEmpresas(2) = 4
                WEmpresas(3) = 8
                WEmpresas(4) = 9

            Case 10
                WEmpresas(1) = 10

        End Select

        ' Preparamos la consulta.
        ZSql = ""
        ZSql = ZSql & "INSERT INTO Terminado ("
        ZSql = ZSql & "Codigo ,"
        ZSql = ZSql & "Descripcion ,"
        ZSql = ZSql & "Linea ,"
        ZSql = ZSql & "Unidad ,"
        ZSql = ZSql & "Inicial ,"
        ZSql = ZSql & "Entradas ,"
        ZSql = ZSql & "Salidas ,"
        ZSql = ZSql & "Minimo ,"
        ZSql = ZSql & "Deposito ,"
        ZSql = ZSql & "Pedido ,"
        ZSql = ZSql & "Envase1 ,"
        ZSql = ZSql & "Envase2 ,"
        ZSql = ZSql & "Envase3 ,"
        ZSql = ZSql & "Envase4 ,"
        ZSql = ZSql & "Envase5 ,"
        ZSql = ZSql & "Envase6 ,"
        ZSql = ZSql & "Proceso ,"
        ZSql = ZSql & "Costo ,"
        ZSql = ZSql & "Factor ,"
        ZSql = ZSql & "WDate ,"
        ZSql = ZSql & "ImpreAdi ,"
        ZSql = ZSql & "Clase ,"
        ZSql = ZSql & "Intervencion ,"
        ZSql = ZSql & "Naciones ,"
        ZSql = ZSql & "Embalaje ,"
        ZSql = ZSql & "Controla ,"
        ZSql = ZSql & "Observaciones ,"
        ZSql = ZSql & "TipoEti ,"
        ZSql = ZSql & "Escrito ,"
        ZSql = ZSql & "Minimo1 ,"
        ZSql = ZSql & "Conservacion ,"
        ZSql = ZSql & "ConservacionII ,"
        ZSql = ZSql & "Vida ,"
        ZSql = ZSql & "Seguridad ,"
        ZSql = ZSql & "Version ,"
        ZSql = ZSql & "VersionI ,"
        ZSql = ZSql & "VersionII ,"
        ZSql = ZSql & "FechaVersion ,"
        ZSql = ZSql & "FechaVersionI ,"
        ZSql = ZSql & "FechaVersionII ,"
        ZSql = ZSql & "Estado ,"
        ZSql = ZSql & "EstadoI ,"
        ZSql = ZSql & "EstadoII ,"
        ZSql = ZSql & "Observa ,"
        ZSql = ZSql & "ObservaI ,"
        ZSql = ZSql & "ObservaII ,"
        ZSql = ZSql & "Metodo ,"
        ZSql = ZSql & "Efluentes )"
        ZSql = ZSql & "Values ("
        ZSql = ZSql & "'" + wCodigo + "',"
        ZSql = ZSql & "'" + wDescripcion.SliceLeft(50) + "',"
        ZSql = ZSql & "'',"
        ZSql = ZSql & "'',"
        ZSql = ZSql & "'',"
        ZSql = ZSql & "'',"
        ZSql = ZSql & "'',"
        ZSql = ZSql & "'',"
        ZSql = ZSql & "'',"
        ZSql = ZSql & "'',"
        ZSql = ZSql & "'',"
        ZSql = ZSql & "'',"
        ZSql = ZSql & "'',"
        ZSql = ZSql & "'',"
        ZSql = ZSql & "'',"
        ZSql = ZSql & "'',"
        ZSql = ZSql & "'',"
        ZSql = ZSql & "'',"
        ZSql = ZSql & "'',"
        ZSql = ZSql & "'" & Date.Now.ToString("MM-dd-yyyy") & "',"
        ZSql = ZSql & "'',"
        ZSql = ZSql & "'',"
        ZSql = ZSql & "'',"
        ZSql = ZSql & "'',"
        ZSql = ZSql & "'',"
        ZSql = ZSql & "'',"
        ZSql = ZSql & "'',"
        ZSql = ZSql & "'',"
        ZSql = ZSql & "'',"
        ZSql = ZSql & "'',"
        ZSql = ZSql & "'',"
        ZSql = ZSql & "'',"
        ZSql = ZSql & "'',"
        ZSql = ZSql & "'',"
        ZSql = ZSql & "'',"
        ZSql = ZSql & "'',"
        ZSql = ZSql & "'',"
        ZSql = ZSql & "'',"
        ZSql = ZSql & "'',"
        ZSql = ZSql & "'',"
        ZSql = ZSql & "'',"
        ZSql = ZSql & "'',"
        ZSql = ZSql & "'',"
        ZSql = ZSql & "'',"
        ZSql = ZSql & "'',"
        ZSql = ZSql & "'',"
        ZSql = ZSql & "'',"
        ZSql = ZSql & "'')"

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("")

        Try
            If Not _VerificaConexionConTodasLasPlantas() Then
                Throw New Exception("No se ha podido verificar la conexión para todas las Plantas.")
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try



        Try
            For i = 1 To 10

                If WEmpresas(i) = 0 OrElse _ExisteTerminado(wCodigo, WEmpresas(i)) Then
                    Continue For
                End If

                cn.ConnectionString = Helper._ConectarA(WEmpresas(i))
                cn.Open()
                cm.Connection = cn
                cm.CommandText = ZSql

                cm.ExecuteNonQuery()

                ZSql = ""
                ZSql = "UPDATE Terminado SET Envase = '', Dife = '', Stock = '', FechaCierre = '', OrdFechaCierre = '', Fabrica = '', Caracteristicas = '', Carga = '', EstadoProducto = '', ListaProducto = '', ImpreEnvase1 = '', ImpreEnvase2 = '', ImpreEnvase3 = '', ImpreEnvase4 = '', ImpreEnvase5 = '', ImpreEnvase6 = '', ImpreEnvase7 = '', Precio1 = '', Precio2 = '', MarcaPrecio = '', CodigoEmpresa = '', DescriEtiqueta = '', LoteAutorizado = '', Marca = '', EstadoHoja = '', DescripcionIngles = '', DescriEtiquetaIngles = '', ConservacionIngles = '', ConservacionIIIngles = '', Sedronar = '', ImpreVto = '', Secundario = '', Riesgo = '', DescriOnu = '', responsable = '', MarcaMsds = '', FabricaII = '', FabricaIII = '', CodSedronar = '', Restriccion = '', Mono = '', PorceSedronar = '', TipoProceso = '', CodRnpa = '' WHERE Codigo ='" & wCodigo & "'"

                cm.CommandText = ZSql
                cm.ExecuteNonQuery()

                cn.Close()

            Next

        Catch ex As Exception
            Throw New Exception("Hubo un problema al querer dar de Alta al Producto " & wCodigo & " en la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        Finally

            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try


    End Sub

    Private Function _VerificaConexionConTodasLasPlantas() As Boolean

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("")

        Try

            For i = 1 To 9

                cn.ConnectionString = Helper._ConectarA(i)
                cn.Open()
                cm.Connection = cn
                cn.Close()

            Next

        Catch ex As Exception
            Throw New Exception("Hubo un problema al querer consultar la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        Finally

            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

        Return True
    End Function

    Private Function _ExisteTerminado(ByVal wCodigo As String, ByVal WEmpresa As Integer) As Boolean

        If String.IsNullOrEmpty(wCodigo) Or WEmpresa = 0 Then
            Throw New Exception("Datos del Producto " & wCodigo & " incorrectos")
        End If

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT Codigo FROM Terminado WHERE Codigo = '" & wCodigo & "'")
        Dim dr As SqlDataReader

        Try

            cn.ConnectionString = Helper._ConectarA(WEmpresa)
            cn.Open()
            cm.Connection = cn

            dr = cm.ExecuteReader()

            Return dr.HasRows

        Catch ex As Exception
            Throw New Exception("Hubo un problema al querer verificar la existencia del Producto " & wCodigo & " en la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

    End Function

    Private Function _SiguienteNumeroHojaProduccion(ByVal wEmpresa As Integer) As Integer
        Dim Whoja = 0

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT MAX(Hoja) as UltimaHoja FROM Hoja")
        Dim dr As SqlDataReader

        Try

            cn.ConnectionString = Helper._ConectarA(wEmpresa)
            cn.Open()
            cm.Connection = cn

            dr = cm.ExecuteReader()

            If dr.HasRows Then
                dr.Read()

                Whoja = dr.Item("UltimaHoja")
            
            End If

        Catch ex As Exception
            Throw New Exception("Hubo un problema al querer consultar la última Hoja de Producción en la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

        Return Whoja + 1
    End Function

    Private Function _StockSuficienteTerminado(ByVal wTerminado As String, ByVal wCantidad As String, ByVal wEmpresa As Integer) As Boolean

        If String.IsNullOrEmpty(wTerminado) Or String.IsNullOrEmpty(wCantidad) Then
            Return False
        End If

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT (Inicial + Entradas - Salidas) as Saldo FROM Terminado WHERE Codigo = '" & wTerminado & "'")
        Dim dr As SqlDataReader
        Dim XCantidad = 0.0, XSaldo = 0.0

        Try

            cn.ConnectionString = Helper._ConectarA(wEmpresa)
            cn.Open()
            cm.Connection = cn

            dr = cm.ExecuteReader()

            If dr.HasRows Then

                dr.Read()

                XCantidad = Val(Helper.formatonumerico(wCantidad))
                XSaldo = dr.Item("Saldo")

                Return XCantidad <= XSaldo

            Else
                Return False
            End If

        Catch ex As Exception
            Throw New Exception("Hubo un problema al querer consultar el Saldo de " & wTerminado & " en la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try
    End Function

    Private Function _StockSuficienteMP(ByVal wArticulo As String, ByVal wCantidad As String, ByVal Wempresa As Integer) As Boolean

        If String.IsNullOrEmpty(wArticulo) Or String.IsNullOrEmpty(wCantidad) Then
            Return False
        End If

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT (Inicial + Entradas - Salidas) as Saldo FROM Articulo WHERE Codigo = '" & wArticulo & "'")
        Dim dr As SqlDataReader
        Dim XCantidad = 0.0, XSaldo = 0.0

        Try

            cn.ConnectionString = Helper._ConectarA(Wempresa)
            cn.Open()
            cm.Connection = cn

            dr = cm.ExecuteReader()

            If dr.HasRows Then

                dr.Read()

                XCantidad = Val(Helper.formatonumerico(wCantidad))
                XSaldo = dr.Item("Saldo")

                Return XCantidad <= XSaldo

            Else
                Return False
            End If

        Catch ex As Exception
            Throw New Exception("Hubo un problema al querer consultar el Saldo de " & wArticulo & " en la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

    End Function

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If Val(txtHojaProduccion.Text) > 0 Then
            _ImprimirHojaPiloto()
        End If
    End Sub

    Private Sub btnCancelarHojaPiloto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelarHojaPiloto.Click
        txtDescripcionHojaPiloto.Text = ""
        pnlHojaPiloto.Visible = False
    End Sub

    Private Sub IngresoPruebasEnsayo_FormClosing( ByVal sender As System.Object,  ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing

        If Trim(txtOrden.Text.Replace("-", "")) = "" Then Exit Sub

        If MsgBox("¿Esta seguro de querer salir? Los dato que no se hayan guardado se perderán", MsgBoxStyle.YesNo) = MsgBoxResult.Yes then exit sub

        e.Cancel = True

        txtOrden.Focus

    End Sub

    Private Sub dgvArchivos_CellMouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvArchivos.CellMouseDoubleClick
        If e.RowIndex < 0 then Exit Sub
        With dgvArchivos.Rows(e.RowIndex)
            If Not IsNothing(.Cells("RutaArchivo").Value) Then

                Try
                    Process.Start(.Cells("RutaArchivo").Value, "f")
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try

            End If
        End With
    End Sub

    
    Private Sub dgvArchivos_DragEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles dgvArchivos.DragEnter
        _PermitirDrag(e)
    End Sub

    Private Sub _PermitirDrag(ByVal e As System.Windows.Forms.DragEventArgs)
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Copy
        End If
    End Sub

    Private Sub _ProcesarDragDeArchivo(ByVal e As System.Windows.Forms.DragEventArgs)

        Dim WRutaArchivosRelacionados = _RutaCarpetaArchivos() & "\" & txtOrden.Text
        Dim archivos() As String = e.Data.GetData(DataFormats.FileDrop)
        Dim WDestino As String = ""
        Dim WCantCorrectas = 0

        If archivos.Length = 0 Then : Exit Sub : End If

        If not Directory.Exists(WRutaArchivosRelacionados) then
            Try
                Directory.CreateDirectory(WRutaArchivosRelacionados)
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Exclamation)
                Exit sub
            End Try
        End If

        For Each archivo In archivos

            If File.Exists(archivo) Then

                If EXTENSIONES_PERMITIDAS.Contains(Path.GetExtension(archivo).ToLower()) Then

                    WDestino = WRutaArchivosRelacionados & "\" & Path.GetFileName(archivo)

                    Try
                        If Not File.Exists(WDestino) Then
                            File.Copy(archivo, WDestino)
                            WCantCorrectas += 1
                        Else
                            If MsgBox("El Archivo " & Path.GetFileName(archivo) & ", ya existe en la carpeta. ¿Desea sobreescribir el archivo existente?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                                File.Copy(archivo, WDestino, True)
                                WCantCorrectas += 1
                            End If
                        End If

                    Catch ex As Exception
                        MsgBox(ex.Message, MsgBoxStyle.Critical)
                        Exit Sub
                    End Try

                End If

            End If

        Next

        If WCantCorrectas > 0 Then
            MsgBox("Se subieron correctamente " & WCantCorrectas & " Archivo(s)", MsgBoxStyle.Information)
        End If

        _CargarArchivosRelacionados()

    End Sub

    Private Sub dgvArchivos_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles dgvArchivos.DragDrop
        _ProcesarDragDeArchivo(e)
    End Sub

    Private Function _RutaCarpetaArchivos()
        Return Configuration.ConfigurationManager.AppSettings("ARCHIVOS_RELACIONADOS")
    End Function

    Private Sub _CargarArchivosRelacionados()
        Dim WRutaArchivosRelacionados As String = ""
        
        If Not Directory.Exists(_RutaCarpetaArchivos) Then
            Throw New Exception("No se ha logrado tener acceso a la Carpeta Compartida de Archivos Relacionados.")
        End If

        WRutaArchivosRelacionados = _RutaCarpetaArchivos() & "\" & txtOrden.Text

        ' Creamos la Carpeta en caso de que no exista aún.
        If Not Directory.Exists(WRutaArchivosRelacionados) Then
            Try
                Directory.CreateDirectory(WRutaArchivosRelacionados)
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End If

        Dim InfoArchivo As FileInfo

        dgvArchivos.Rows.Clear()

        ' Recorremos unicamente aquellos archivos que tengan una extensión que esté entre las permitidas por la aplicación.
        For Each WNombreArchivo As String In Directory.GetFiles(WRutaArchivosRelacionados).Where(Function(s) EXTENSIONES_PERMITIDAS.Contains(Path.GetExtension(s).ToLower()))

            InfoArchivo = FileSystem.GetFileInfo(WNombreArchivo)

            With InfoArchivo
                dgvArchivos.Rows.Add(.CreationTime.ToString("dd/MM/yyyy"), UCase(.Name), _ObtenerIconoSegunTipoArchivo(.Extension), .FullName)
            End With

        Next

    End Sub

    Private Function _ObtenerIconoSegunTipoArchivo(ByVal extension As String)
        Dim Wicono = Nothing

        'My.Resources.pdf_icon


        Select Case UCase(extension)

            Case ".DOC", ".DOCX"
                Wicono = My.Resources.Word_icon
            Case ".XLS", ".XLSX", ".XLSM"
                Wicono = My.Resources.Excel_icon
            Case ".PDF"
                Wicono = My.Resources.pdf_icono
            Case ".JPG", ".JPEG", ".BMP", ".ICO", ".PNG"
                Wicono = My.Resources.imagen_icono
            Case ".TXT"
                Wicono = My.Resources.txt_icono
            Case Else
                Wicono = My.Resources.archivo_default
        End Select


        Return Wicono
    End Function

    Private Sub txtBuscarEnTodosLosCampos_KeyDown( ByVal sender As System.Object,  ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBuscarEnTodosLosCampos.KeyDown
        
        If e.KeyData = Keys.Enter Then
	        If Trim(txtBuscarEnTodosLosCampos.Text) = "" Then : Exit Sub : End If

            _FiltrarPorTodosLosCampos(txtbuscarentodosloscampos.Text)

        ElseIf e.KeyData = Keys.Escape Then
            txtBuscarEnTodosLosCampos.Text = ""
        End If
        
    End Sub

    Private Sub dgvRevisiones_RowHeaderMouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvRevisiones.RowHeaderMouseDoubleClick

        If e.RowIndex < -1 Then Exit Sub

        If MsgBox("¿Quiere eliminar la fila?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Dim WRow = dgvRevisiones.Rows(e.RowIndex)

            dgvRevisiones.Rows.Remove(WRow)
        End If

    End Sub
End Class