Imports System.Data.SqlClient

Public Class IngresoPruebasEnsayo

    Private Sub IngresoOrdenTrabajo_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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

        For Each _ck As CheckBox In _CamposCheckboxs()
            _ck.Checked = False
        Next

        For Each _m As MaskedTextBox In {txtOrden, txtFecha}
            _m.Clear()
        Next

        For Each _c As ComboBox In {cmbPlanta, cmbTipoCalculo}
            _c.SelectedIndex = 0
        Next

        pnlConsulta.Visible = False

        For Each grid As DataGridView In {dgvFormula, dgvCosto, dgvProceso, dgvLaboratorio, dgvRevisiones}

            With grid
                .Rows.Clear()
                .Rows.Add()
            End With

        Next

    End Sub

    Private Function _CamposCheckboxs() As CheckBox()
        Return _CamposAVerificar().ToArray.Union(_CamposInformativos).ToArray
    End Function

    Private Function _CamposAVerificar() As CheckBox()

        Return {ckAVerificarI, ckAVerificarII, ckAVerificarIII, ckAVerificarIV, ckAVerificarV, _
                ckAVerificarVI, ckAVerificarVII, ckAVerificarVIII, ckAVerificarIX, ckAVerificarX, _
                ckAVerificarXI, ckAVerificarXII}
    End Function

    Private Function _CamposInformativos() As CheckBox()

        Return {ckInformativoI, ckInformativoII, ckInformativoIII, ckInformativoIV, ckInformativoV, _
                ckInformativoVI, ckInformativoVII, ckInformativoVIII, ckInformativoIX, ckInformativoX, _
                ckInformativoXI, ckInformativoXII}
    End Function

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
        Return {txtVersion, txtCantidad, txtRealizado, txtRealizadoII, txtAyuda, txtCostoTotal, txtCostoPorKilo}.Union(_CamposRequisitos).ToArray.Union(_CamposComentarios).ToArray
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

    Private Sub txtEncargado_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRealizado.KeyDown, TextBox1.KeyDown, txtCantidad.KeyDown

        If e.KeyData = Keys.Enter Then
            '    If Trim(txtEncargado.Text) = "" Then : Exit Sub : End If

            'TabControl1.SelectedIndex = 1

        ElseIf e.KeyData = Keys.Escape Then
            txtRealizado.Text = ""
        End If

    End Sub

    Private Sub btnConsultas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultas.Click

        Try
            _CargarClientes()

            pnlConsulta.Visible = True
            lstConsulta.Visible = True
            lstFiltrada.Visible = False
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
        Dim WAux = 0

        Try
            WIndice.Items.Clear()
            lstConsulta.Items.Clear()
            lstFiltrada.Items.Clear()

            cn.ConnectionString = Helper._ConectarA("SurfactanSA")
            cn.Open()
            cm.Connection = cn

            cm.CommandText = "SELECT Count(*) as Total FROM Cliente"

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

            cm.CommandText = "SELECT Cliente, Razon FROM Cliente WHERE Cliente is not null AND Razon is not null"

            dr = cm.ExecuteReader()

            If dr.HasRows Then

                Do While dr.Read()

                    With dr

                        WRazones(WAux) = .Item("Razon")
                        WClaves(WAux) = .Item("Cliente")

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
        _FiltrarDinamicamente()
    End Sub

    Private Sub lstConsulta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstConsulta.Click

        Try
            Dim WValor = lstConsulta.SelectedItem

            If IsNothing(WValor) OrElse Trim(WValor) = "" Then Exit Sub

            'Dim WClave = ""

            'WClave = WIndice.Items(lstConsulta.SelectedIndex)

            'txtCliente.Text = WClave
            'txtDescCliente.Text = _TraerNombreCliente(WClave)

            btnCerrarConsulta.PerformClick()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrarConsulta.Click
        pnlConsulta.Visible = False
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

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click, Button3.Click

        Try
            If Trim(txtOrden.Text).Replace("-", "") = "" OrElse Trim(txtOrden.Text).Length < 8 Then Exit Sub

            ' Eliminamos las comas que pudiesen existir para que no rompa la Consulta SQL.
            For Each txt As TextBox In _CamposDeTexto()
                txt.Text = txt.Text.Replace(",", " ")
            Next

            If _ExisteEnsayo() Then

                _ActualizarOrdenTrabajo()

            Else

                _AltaOrdenTrabajo()

            End If

            btnLimpiar.PerformClick()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub _AltaOrdenTrabajo()
        'Dim ZSQL = ""
        'Dim cn As SqlConnection = New SqlConnection()
        'Dim cm As SqlCommand = New SqlCommand("")
        'Dim WDescripciones(5) As String
        'Dim WObservaciones(3) As String
        'Dim WRequisitos(6) As String
        'Dim WReferencias(2) As String

        'Try

        '    cn.ConnectionString = Helper._ConectarA
        '    cn.Open()
        '    cm.Connection = cn

        '    WDescripciones = _PrepararDescripciones()
        '    WObservaciones = _PrepararObservaciones()
        '    WRequisitos = _PrepararRequisitos()
        '    WReferencias = _PrepararReferencias()

        '    ZSQL = ""
        '    ZSQL = ZSQL & "INSERT INTO OrdenTrabajo ("
        '    ZSQL = ZSQL & "Orden ,"
        '    ZSQL = ZSQL & "Fecha ,"
        '    ZSQL = ZSQL & "OrdFecha ,"
        '    ZSQL = ZSQL & "FechaEntrega ,"
        '    ZSQL = ZSQL & "OrdFechaEntrega ,"
        '    ZSQL = ZSQL & "Cliente ,"
        '    ZSQL = ZSQL & "Observaciones ,"
        '    ZSQL = ZSQL & "Material ,"
        '    ZSQL = ZSQL & "Muestra ,"
        '    ZSQL = ZSQL & "Uso ,"
        '    ZSQL = ZSQL & "DescripcionI ,"
        '    ZSQL = ZSQL & "DescripcionII ,"
        '    ZSQL = ZSQL & "DescripcionIII ,"
        '    ZSQL = ZSQL & "DescripcionIV ,"
        '    ZSQL = ZSQL & "DescripcionV ,"
        '    ZSQL = ZSQL & "DescripcionVI ,"
        '    ZSQL = ZSQL & "ObservacionesI ,"
        '    ZSQL = ZSQL & "ObservacionesII ,"
        '    ZSQL = ZSQL & "ObservacionesIII ,"
        '    ZSQL = ZSQL & "ObservacionesIV ,"
        '    ZSQL = ZSQL & "ObservacionesV ,"
        '    ZSQL = ZSQL & "ObservacionesVI ,"
        '    ZSQL = ZSQL & "Encargado ,"
        '    ZSQL = ZSQL & "RequisitoI ,"
        '    ZSQL = ZSQL & "RequisitoII ,"
        '    ZSQL = ZSQL & "RequisitoIII ,"
        '    ZSQL = ZSQL & "RequisitoIV ,"
        '    ZSQL = ZSQL & "RequisitoV ,"
        '    ZSQL = ZSQL & "RequisitoVI ,"
        '    ZSQL = ZSQL & "ReferenciaI ,"
        '    ZSQL = ZSQL & "ReferenciaII ,"
        '    ZSQL = ZSQL & "Aplicacion ,"
        '    ZSQL = ZSQL & "Estabilidad )"
        '    ZSQL = ZSQL & "Values ("
        '    ZSQL = ZSQL & "'" & txtOrden.Text & "',"
        '    ZSQL = ZSQL & "'" & txtFecha.Text & "',"
        '    ZSQL = ZSQL & "'" & Helper.ordenaFecha(txtFecha.Text) & "',"
        '    ZSQL = ZSQL & "'" & txtFechaComprometida.Text & "',"
        '    ZSQL = ZSQL & "'" & Helper.ordenaFecha(txtFechaComprometida.Text) & "',"
        '    ZSQL = ZSQL & "'" & txtCliente.Text & "',"
        '    ZSQL = ZSQL & "'" & txtObservaciones.Text & "',"
        '    ZSQL = ZSQL & "'" & txtMaterial.Text & "',"
        '    ZSQL = ZSQL & "'" & txtMuestra.Text & "',"
        '    ZSQL = ZSQL & "'" & txtUso.Text & "',"
        '    ZSQL = ZSQL & "'" & WDescripciones(1) & "',"
        '    ZSQL = ZSQL & "'" & WDescripciones(2) & "',"
        '    ZSQL = ZSQL & "'" & WDescripciones(3) & "',"
        '    ZSQL = ZSQL & "'" & WDescripciones(4) & "',"
        '    ZSQL = ZSQL & "'" & WDescripciones(5) & "',"
        '    ZSQL = ZSQL & "'',"
        '    ZSQL = ZSQL & "'" & WObservaciones(1) & "',"
        '    ZSQL = ZSQL & "'" & WObservaciones(2) & "',"
        '    ZSQL = ZSQL & "'" & WObservaciones(3) & "',"
        '    ZSQL = ZSQL & "'',"
        '    ZSQL = ZSQL & "'',"
        '    ZSQL = ZSQL & "'',"
        '    ZSQL = ZSQL & "'" & txtEncargado.Text & "',"
        '    ZSQL = ZSQL & "'" & WRequisitos(1) & "',"
        '    ZSQL = ZSQL & "'" & WRequisitos(2) & "',"
        '    ZSQL = ZSQL & "'" & WRequisitos(3) & "',"
        '    ZSQL = ZSQL & "'" & WRequisitos(4) & "',"
        '    ZSQL = ZSQL & "'" & WRequisitos(5) & "',"
        '    ZSQL = ZSQL & "'" & WRequisitos(6) & "',"
        '    ZSQL = ZSQL & "'" & WReferencias(1) & "',"
        '    ZSQL = ZSQL & "'" & WReferencias(2) & "',"
        '    ZSQL = ZSQL & "'" & Str$(cmbAplicacion.SelectedIndex) & "',"
        '    ZSQL = ZSQL & "'" & Str$(cmbEstabilidad.SelectedIndex) & "')"

        '    cm.CommandText = ZSQL
        '    cm.ExecuteNonQuery()

        'Catch ex As Exception
        '    Throw New Exception("Hubo un problema al querer consultar la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        'Finally

        '    cn.Close()
        '    cn = Nothing
        '    cm = Nothing

        'End Try
    End Sub

    Private Sub _ActualizarOrdenTrabajo()
        'Dim ZSQL = ""
        'Dim cn As SqlConnection = New SqlConnection()
        'Dim cm As SqlCommand = New SqlCommand("")
        'Dim WDescripciones(5) As String
        'Dim WObservaciones(3) As String
        'Dim WRequisitos(6) As String
        'Dim WReferencias(2) As String

        'Try

        '    cn.ConnectionString = Helper._ConectarA
        '    cn.Open()
        '    cm.Connection = cn

        '    WDescripciones = _PrepararDescripciones()
        '    WObservaciones = _PrepararObservaciones()
        '    WRequisitos = _PrepararRequisitos()
        '    WReferencias = _PrepararReferencias()

        '    ZSQL = ""
        '    ZSQL = ZSQL & "UPDATE OrdenTrabajo SET "
        '    ZSQL = ZSQL & " Fecha = " & "'" & txtFecha.Text & "',"
        '    ZSQL = ZSQL & " OrdFecha = " & "'" & Helper.ordenaFecha(txtFecha.Text) & "',"
        '    ZSQL = ZSQL & " FechaEntrega = " & "'" & txtFechaComprometida.Text & "',"
        '    ZSQL = ZSQL & " OrdFechaEntrega = " & "'" & Helper.ordenaFecha(txtFechaComprometida.Text) & "',"
        '    ZSQL = ZSQL & " Cliente = " & "'" & txtCliente.Text & "',"
        '    ZSQL = ZSQL & " Observaciones = " & "'" & txtObservaciones.Text & "',"
        '    ZSQL = ZSQL & " Material = " & "'" & txtMaterial.Text & "',"
        '    ZSQL = ZSQL & " Muestra = " & "'" & txtMuestra.Text & "',"
        '    ZSQL = ZSQL & " Uso = " & "'" & txtUso.Text & "',"
        '    ZSQL = ZSQL & " DescripcionI = " & "'" & WDescripciones(1) & "',"
        '    ZSQL = ZSQL & " DescripcionII = " & "'" & WDescripciones(2) & "',"
        '    ZSQL = ZSQL & " DescripcionIII = " & "'" & WDescripciones(3) & "',"
        '    ZSQL = ZSQL & " DescripcionIV = " & "'" & WDescripciones(4) & "',"
        '    ZSQL = ZSQL & " DescripcionV = " & "'" & WDescripciones(5) & "',"
        '    ZSQL = ZSQL & " DescripcionVI = " & "'',"
        '    ZSQL = ZSQL & " ObservacionesI = " & "'" & WObservaciones(1) & "',"
        '    ZSQL = ZSQL & " ObservacionesII = " & "'" & WObservaciones(2) & "',"
        '    ZSQL = ZSQL & " ObservacionesIII = " & "'" & WObservaciones(3) & "',"
        '    ZSQL = ZSQL & " ObservacionesIV = " & "'',"
        '    ZSQL = ZSQL & " ObservacionesV = " & "'',"
        '    ZSQL = ZSQL & " ObservacionesVI = " & "'',"
        '    ZSQL = ZSQL & " Encargado = " & "'" & txtEncargado.Text & "',"
        '    ZSQL = ZSQL & " RequisitoI = " & "'" & WRequisitos(1) & "',"
        '    ZSQL = ZSQL & " RequisitoII = " & "'" & WRequisitos(2) & "',"
        '    ZSQL = ZSQL & " RequisitoIII = " & "'" & WRequisitos(3) & "',"
        '    ZSQL = ZSQL & " RequisitoIV = " & "'" & WRequisitos(4) & "',"
        '    ZSQL = ZSQL & " RequisitoV = " & "'" & WRequisitos(5) & "',"
        '    ZSQL = ZSQL & " RequisitoVI = " & "'" & WRequisitos(6) & "',"
        '    ZSQL = ZSQL & " ReferenciaI = " & "'" & WReferencias(1) & "',"
        '    ZSQL = ZSQL & " ReferenciaII = " & "'" & WReferencias(2) & "',"
        '    ZSQL = ZSQL & " Aplicacion = " & "'" & Str$(cmbAplicacion.SelectedIndex) & "',"
        '    ZSQL = ZSQL & " Estabilidad = " & "'" & Str$(cmbEstabilidad.SelectedIndex) & "'"
        '    ZSQL = ZSQL & " Where Orden = " & "'" & txtOrden.Text & "'"

        '    cm.CommandText = ZSQL
        '    cm.ExecuteNonQuery()

        'Catch ex As Exception
        '    Throw New Exception("Hubo un problema al querer consultar la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        'Finally

        '    cn.Close()
        '    cn = Nothing
        '    cm = Nothing

        'End Try

    End Sub

    Private Function _ExisteEnsayo() As Boolean

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT Orden FROM OrdenTrabajo WHERE Orden = '" & UCase(txtOrden.Text) & "'")
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

        If _ExisteEnsayo() Then

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

        'Dim cn As SqlConnection = New SqlConnection()
        'Dim cm As SqlCommand = New SqlCommand("")

        'Try

        '    'cn.ConnectionString = Helper._ConectarA
        '    'cn.Open()
        '    'cm.Connection = cn

        '    'cm.CommandText = "DELETE FROM OrdenTrabajo WHERE Orden = '" & txtOrden.Text & "'"

        '    'cm.ExecuteNonQuery()

        'Catch ex As Exception
        '    Throw New Exception("Hubo un problema al querer consultar la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        'Finally

        '    cn.Close()
        '    cn = Nothing
        '    cm = Nothing

        'End Try

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

                    If iCol = 4 Then
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

                    If iCol = 4 Then
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

                    If iCol = 4 Then
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

            End Select

            dgvFormula.Rows(iRow).Cells(iCol).Value = UCase(valor)

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

    Private Sub txtVersion_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtVersion.KeyDown, txtComentariosXII.KeyDown, txtComentariosXI.KeyDown, txtComentariosX.KeyDown, txtComentariosIX.KeyDown, txtComentariosVIII.KeyDown, txtComentariosVII.KeyDown, txtComentariosVI.KeyDown, txtComentariosV.KeyDown, txtComentariosIV.KeyDown, txtRequisitosI.KeyDown, txtComentariosIII.KeyDown, txtComentariosII.KeyDown, txtComentariosI.KeyDown, txtRequisitosXII.KeyDown, txtRequisitosII.KeyDown, txtRequisitosIII.KeyDown, txtRequisitosIV.KeyDown, txtRequisitosV.KeyDown, txtRequisitosVI.KeyDown, txtRequisitosVII.KeyDown, txtRequisitosVIII.KeyDown, txtRequisitosIX.KeyDown, txtRequisitosX.KeyDown, txtRequisitosXI.KeyDown

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

                txtFecha.Focus()
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Exclamation)
            End Try

        ElseIf e.KeyData = Keys.Escape Then
            txtVersion.Text = ""
        End If

    End Sub

    Private Sub _TraerDatosEntrada(Optional ByVal WVersion As String = "")

        If String.IsNullOrEmpty(WVersion) Then
            WVersion = txtVersion.Text
        End If

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT Requisito, Informativo, AVerificar, Comentario FROM CargaEnsayoVI WHERE Orden = '" & txtOrden.Text & "' AND Version = '" & WVersion & "'")
        Dim dr As SqlDataReader
        Dim WRequisito = "", WInformativo = "", WAVerificar = "", WComentario = ""
        Dim WIndice = 0
        Dim WRequisitos = {txtRequisitosI, txtRequisitosII, txtRequisitosIII, txtRequisitosIV, txtRequisitosV, _
                           txtRequisitosVI, txtRequisitosVII, txtRequisitosVIII, txtRequisitosIX, txtRequisitosX, _
                           txtRequisitosXI, txtRequisitosXII}
        Dim WComentarios = {txtComentariosI, txtComentariosII, txtComentariosIII, txtComentariosIV, txtComentariosV, _
                           txtComentariosVI, txtComentariosVII, txtComentariosVIII, txtComentariosIX, txtComentariosX, _
                           txtComentariosXI, txtComentariosXII}
        Dim WInformativos = {ckInformativoI, ckInformativoII, ckInformativoIII, ckInformativoIV, ckInformativoV, _
                           ckInformativoVI, ckInformativoVII, ckInformativoVIII, ckInformativoIX, ckInformativoX, _
                           ckInformativoXI, ckInformativoXII}
        Dim WAVerificarlos = {ckAVerificarI, ckAVerificarII, ckAVerificarIII, ckAVerificarIV, ckAVerificarV, _
                           ckAVerificarVI, ckAVerificarVII, ckAVerificarVIII, ckAVerificarIX, ckAVerificarX, _
                           ckAVerificarXI, ckAVerificarXII}

        Try

            cn.ConnectionString = Helper._ConectarA
            cn.Open()
            cm.Connection = cn

            dr = cm.ExecuteReader()

            If dr.HasRows Then

                Do While dr.Read()

                    With dr

                        WRequisito = IIf(IsDBNull(.Item("Requisito")), "", .Item("Requisito"))
                        WInformativo = IIf(IsDBNull(.Item("Informativo")), 0, .Item("Informativo"))
                        WAVerificar = IIf(IsDBNull(.Item("AVerificar")), 0, .Item("AVerificar"))
                        WComentario = IIf(IsDBNull(.Item("Comentario")), "", .Item("Comentario"))

                    End With

                    If WIndice < 12 Then

                        WRequisitos(WIndice).Text = Trim(WRequisito)
                        WComentarios(WIndice).Text = Trim(WComentario)
                        WInformativos(WIndice).Checked = Val(WInformativo) = 1
                        WAVerificarlos(WIndice).Checked = Val(WAVerificar) = 1

                        WIndice += 1

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
        Dim cm As SqlCommand = New SqlCommand("SELECT Version, Etapa, Fecha, Participantes, Resultados, Acciones, Responsables, Estado FROM CargaEnsayoV WHERE Orden = '" & txtOrden.Text & "' AND Version = '" & txtVersion.Text & "'")
        Dim dr As SqlDataReader
        Dim WVersion = "", WEtapa = "", WFecha = "", WParticipantes = "", WResultados = "", WAcciones = "", WResponsables = "", WEstado = ""
        Dim WIndice = 0

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

                    WIndice = dgvRevisiones.Rows.Add

                    ' Cargamos los datos de la Formula.
                    With dgvRevisiones.Rows(WIndice)

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

                dgvRevisiones.Rows.Add()
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
        Dim cm As SqlCommand = New SqlCommand("SELECT Ensayo, Descripcion, Esperado, Resultado FROM CargaEnsayoIV WHERE Orden = '" & txtOrden.Text & "' AND Version = '" & WVersion & "'")
        Dim dr As SqlDataReader
        Dim WEnsayo = "", WDescripcion = "", WEsperado = "", WResultado = ""
        Dim WIndice = 0

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

                    WIndice = dgvLaboratorio.Rows.Add

                    ' Cargamos los datos de la Formula.
                    With dgvLaboratorio.Rows(WIndice)

                        .Cells("LaboratorioEnsayo").Value = UCase(WEnsayo)
                        .Cells("LaboratorioDescripcion").Value = Trim(WDescripcion)
                        .Cells("LaboratorioRequerido").Value = Trim(WEsperado)
                        .Cells("LaboratorioResultado").Value = Trim(WResultado)

                    End With

                Loop

                If Not dr.IsClosed Then
                    dr.Close()
                End If

                cm.CommandText = "SELECT Ensayo, Descripcion, Resultado FROM OrdenTrabajoII WHERE Orden = '" & txtOrden.Text & "'"

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

                        WIndice = dgvLaboratorio.Rows.Add

                        ' Cargamos los datos de la Formula.
                        With dgvLaboratorio.Rows(WIndice)

                            .Cells("LaboratorioEnsayo").Value = UCase(WEnsayo)
                            .Cells("LaboratorioDescripcion").Value = Trim(WDescripcion)
                            .Cells("LaboratorioRequerido").Value = Trim(WResultado)
                            .Cells("LaboratorioResultado").Value = Trim(WEsperado)

                        End With

                    Loop

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
            End If

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
        Dim cm As SqlCommand = New SqlCommand("SELECT Etapa, Instrucciones, Equipo, Temperatura, Tiempo, Control, Seguridad FROM CargaEnsayoIII WHERE Orden = '" & txtOrden.Text & "' AND Version = '" & WVersion & "'")
        Dim dr As SqlDataReader
        Dim WEtapa = "", WInstrucciones = "", WEquipo = "", WTemperatura = "", WTiempo = "", WControl = "", WSeguridad = ""
        Dim WIndice = 0

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

                    WIndice = dgvProceso.Rows.Add

                    ' Cargamos los datos de la Formula.
                    With dgvProceso.Rows(WIndice)

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

                    txtCantidad.Text = Helper.formatonumerico(txtCantidad.Text, 3)

                    txtRealizado.Text = Trim(txtRealizado.Text)
                    txtRealizadoII.Text = Trim(txtRealizadoII.Text)

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
        Dim cm As SqlCommand = New SqlCommand("SELECT Tipo, Articulo, Terminado, Descripcion, Cantidad, Lote, Stock, Costo FROM CargaEnsayoII WHERE Orden = '" & txtOrden.Text & "' AND Version = '" & WVersion & "' ORDER BY Articulo, Terminado")
        Dim dr As SqlDataReader
        Dim WTipo = "", WArticulo = "", WTerminado = "", WDescripcion = "", WCantidad = "", WLote = "", WStock = "", WCosto = ""
        Dim WIndice = 0

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

                        WCantidad = Helper.formatonumerico(WCantidad, 3)
                        WCosto = Helper.formatonumerico(WCosto)

                    End With

                    WIndice = dgvFormula.Rows.Add

                    ' Cargamos los datos de la Formula.
                    With dgvFormula.Rows(WIndice)

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
                    With dgvCosto.Rows(WIndice)

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

    Private Sub SoloNumero(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtVersion.KeyPress, txtRequisitosV.KeyPress, txtRequisitosIV.KeyPress, txtRequisitosIII.KeyPress, txtRequisitosII.KeyPress, txtComentariosXII.KeyPress, txtComentariosXI.KeyPress, txtComentariosX.KeyPress, txtComentariosIX.KeyPress, txtComentariosVIII.KeyPress, txtComentariosVII.KeyPress, txtComentariosVI.KeyPress, txtComentariosV.KeyPress, txtComentariosIV.KeyPress, txtComentariosIII.KeyPress, txtComentariosII.KeyPress, txtComentariosI.KeyPress, txtRequisitosXII.KeyPress, txtRequisitosXI.KeyPress, txtRequisitosX.KeyPress, txtRequisitosIX.KeyPress, txtRequisitosVIII.KeyPress, txtRequisitosVII.KeyPress, txtRequisitosVI.KeyPress, txtRequisitosI.KeyPress
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

                If WImporte <> 0 Then

                    .Cells("CostoImporte").Value = Helper.formatonumerico(Str$(WImporte))

                    WCostoTotal += WImporte

                End If

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

    Private Function _TraerParidad(ByVal fecha As String) As Double

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT Cambio FROM Cambios WHERE Fecha = '" & fecha & "'")
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
            Throw New Exception("Hubo un problema al querer consultar la paridad del dia " & fecha & " en la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
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
End Class