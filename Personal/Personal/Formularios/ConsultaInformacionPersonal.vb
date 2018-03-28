Imports System.Data.SqlClient

Public Class ConsultaInformacionPersonal
    
     Private Const YMARGEN = 1.5
     Private Const XMARGEN = 3
     Private WRow, Wcol As Integer
    
    Private Sub IngresoOrdenTrabajo_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        btnLimpiar.PerformClick()
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Close()
    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        ' Limpiamos los campos.
        _LimpiarCampos()

        WRow = -1
        Wcol = -1
        TabControl1.SelectedIndex = 0
        txtDni.Focus()
    End Sub

    Private Sub _LimpiarCampos()

        For Each _txt As TextBox In _CamposDeTexto()
            _txt.Text = ""
        Next

        For Each _m As MaskedTextBox In _
            {txtFechaCasamiento, txtFechaEgreso, txtFechaIngreso, txtFechaNacimiento, txtFechaNacimientoConyugue, txtFechaAux}
            _m.Clear()
        Next

        For Each _c As ComboBox In {cmbCategoria, cmbEstado, cmbUbicacion}
            _c.SelectedIndex = 0
        Next

        With dgvHijos.Rows
            .Clear
            .Add
        End With

        With dgvEducacion.Rows
            .Clear
            '.Add
        End With

        With dgvIndumentaria.Rows
            .Clear
            '.Add
        End With

        txtFechaAux.Visible=False
        pnlConsulta.Visible = False
    End Sub

    Private Function _CamposDeTexto() As TextBox()
        Return _
            {txtDni, txtCalle, txtNumero, txtDpto, txtCodPostal, txtLocalidad, txtAclaracion, txtNombreCompletoConyugue,
             txtEdadConyugue, txtDniConyugue, txtSueldoBruto, txtAyuda, txtNombreCompleto, txtLegajo, txtEdad}
    End Function

    Private Sub IngresoOrdenTrabajo_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles MyBase.Shown
        txtDni.Focus
    End Sub

    Private Sub txtDni_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) _
        Handles txtDni.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txtDni.Text) = "" Then : Exit Sub :
            End If

            ' Rutina para cargar los datos.
            Try

                _CargarDatos()

                txtFechaNacimiento.Focus

            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Exclamation)
            End Try
        ElseIf e.KeyData = Keys.Escape Then
            txtDni.Text = ""
        End If
    End Sub

    Private Sub _CargarDatos()

        Try
            ' Busco los datos provenientes del Legajo.
            _CargarDatosLegajo()

            ' Busco los Datos Personales.
            _CargarDatosPersonales()

            ' Cargo los datos de los Hijos
            _CargarDatosHijos()

            ' Recalculamos edad de Hijos.
             Dim WFecha As String

            For Each row As DataGridViewRow In dgvHijos.Rows
                With row
                    WFecha = IIf(IsNothing(.Cells("FechaNacimientoHijo").Value), "", .Cells("FechaNacimientoHijo").Value)        

                    If not WFecha.estaVacia then
                        
                        .Cells("EdadHijo").Value = _CalcularEdad(WFecha)

                    End If

                End With
            Next

            ' Recalculamos edad de Conyuge.
            If Not txtFechaNacimientoConyugue.Text.estaVacia then
                txtEdadConyugue.Text = _CalcularEdad(txtFechaNacimientoConyugue.Text)
            End If

            ' Recalculamos edad del Personal.
            If Not txtFechaNacimiento.Text.estaVacia then
                txtEdad.Text = _CalcularEdad(txtFechaNacimiento.Text)
            End If

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Private Sub _CargarDatosHijos()

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT * FROM PersonalHijos WHERE Dni = '" & txtDni.Text & "'")
        Dim dr As SqlDataReader
        Dim WNombre, WApellido, WDni, WEdad, WFechaNac As String
        Dim WFila As Short

        Try

            cn.ConnectionString = Helper._ConectarA
            cn.Open()
            cm.Connection = cn

            dr = cm.ExecuteReader()

            dgvHijos.Rows.Clear
            WFila = 0

            With dr
                If .HasRows Then

                    Do While .Read()

                        WNombre = IIf(IsDBNull(.Item("Nombre")), "", .Item("Nombre"))
                        WApellido = IIf(IsDBNull(.Item("Apellido")), "", .Item("Apellido"))
                        WDni = IIf(IsDBNull(.Item("DniHijo")), "", .Item("DniHijo"))
                        WEdad = IIf(IsDBNull(.Item("Edad")), "", .Item("Edad"))
                        WFechaNac = IIf(IsDBNull(.Item("FechaNac")), "", .Item("FechaNac"))

                        WFila = dgvHijos.Rows.Add

                        dgvHijos.Rows(WFila).Cells("NombreHijo").Value = Trim(WNombre)
                        dgvHijos.Rows(WFila).Cells("ApellidoHijo").Value = Trim(WApellido)
                        dgvHijos.Rows(WFila).Cells("DniHijo").Value = Trim(WDni)
                        dgvHijos.Rows(WFila).Cells("EdadHijo").Value = Trim(WEdad)
                        dgvHijos.Rows(WFila).Cells("FechaNacimientoHijo").Value = Trim(WFechaNac)

                    Loop

                End If
            End With

            dgvHijos.Rows.Add

        Catch ex As Exception
            Throw _
                New Exception(
                    "Hubo un problema al querer consultar la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try
    End Sub

    Private Sub _CargarDatosPersonales()

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT * FROM Personal WHERE Dni = '" & txtDni.Text & "'")
        Dim dr As SqlDataReader
        Dim WFila As Short
        Dim WObsPrimaria, WObsSecundaria, WObsTerciaria As String

        Try

            cn.ConnectionString = Helper._ConectarA
            cn.Open()
            cm.Connection = cn

            dr = cm.ExecuteReader()

            dgvIndumentaria.Rows.Clear

            If dr.HasRows Then
                With dr
                    .Read

                    txtFechaNacimiento.Text = IIf(IsDBNull(.Item("FechaNac")), "", .Item("FechaNac"))
                    txtCalle.Text = IIf(IsDBNull(.Item("Calle")), "", .Item("Calle"))
                    txtNumero.Text = IIf(IsDBNull(.Item("Numero")), "", .Item("Numero"))
                    txtDpto.Text = IIf(IsDBNull(.Item("Dpto")), "", .Item("Dpto"))
                    txtCodPostal.Text = IIf(IsDBNull(.Item("Postal")), "", .Item("Postal"))
                    txtLocalidad.Text = IIf(IsDBNull(.Item("Localidad")), "", .Item("Localidad"))
                    txtAclaracion.Text = IIf(IsDBNull(.Item("Aclaracion")), "", .Item("Aclaracion"))
                    txtNombreCompletoConyugue.Text = IIf(IsDBNull(.Item("ConyugeNombre")), "", .Item("ConyugeNombre"))
                    txtEdadConyugue.Text = IIf(IsDBNull(.Item("ConyugeEdad")), "", .Item("ConyugeEdad"))
                    txtDniConyugue.Text = IIf(IsDBNull(.Item("ConyugeDni")), "", .Item("ConyugeDni"))
                    txtFechaNacimientoConyugue.Text = IIf(IsDBNull(.Item("ConyugeFechaNac")), "",
                                                          .Item("ConyugeFechaNac"))
                    txtFechaCasamiento.Text = IIf(IsDBNull(.Item("FechaCasamiento")), "", .Item("FechaCasamiento"))
                    cmbEstado.SelectedIndex = IIf(IsDBNull(.Item("Estado")), 0, .Item("Estado"))
                    cmbCategoria.SelectedIndex = IIf(IsDBNull(.Item("Categoria")), 0, .Item("Categoria"))
                    cmbUbicacion.SelectedIndex = IIf(IsDBNull(.Item("Ubicacion")), 0, .Item("Ubicacion"))
                    txtSueldoBruto.Text = IIf(IsDBNull(.Item("SueldoBruto")), "0", .Item("SueldoBruto"))
                    txtSueldoBruto.Text = Helper.formatonumerico(txtSueldoBruto.Text)

                    ' Cargo Informacion de la Indumentaria.
                    WFila = 0

                    ' Buzo: 1, Camisa: 2, Campera: 3, Pantalón: 4, Remera: 5, Zapato: 6
                    Dim WIndumentaria As String() = {"", "Buzo", "Camisa", "Campera", "Pantalon", "Remera", "Zapato"}
                    Dim WItem, WTalle, WObs As String

                    For i = 1 to 6

                        WItem = WIndumentaria(i)

                        WFila = dgvIndumentaria.Rows.Add
                        dgvIndumentaria.Rows(WFila).Cells("Indumentaria").Value = WItem

                        WTalle = IIf(IsDBNull(.Item(WItem)), "", .Item(WItem))
                        dgvIndumentaria.Rows(wfila).Cells("Talle").Value = Trim(WTalle)

                        WObs = IIf(IsDBNull(.Item("Obs" & WItem)), "", .Item("Obs" & WItem))
                        dgvIndumentaria.Rows(wfila).Cells("ObservacionesIndumentaria").Value = Trim(WObs)
                        dgvIndumentaria.Rows(WFila).Cells("TipoInd").Value = Str$(i)

                    Next

                    ' Obtenemos los datos de los Estudios.
                    WObsPrimaria = IIf(IsDBNull(.Item("ObsPrimaria")), "", .Item("ObsPrimaria"))
                    WObsSecundaria = IIf(IsDBNull(.Item("ObsSecundaria")), "", .Item("ObsSecundaria"))
                    WObsTerciaria = IIf(IsDBNull(.Item("ObsTerciaria")), "", .Item("ObsTerciaria"))


                    For Each row As DataGridViewRow In dgvEducacion.Rows

                        Select Case val(row.Cells("IdFormacion").Value)
                            Case 1 ' Primaria
                                row.Cells("ObservacionesFormacion").Value = Trim(WObsPrimaria)
                            Case 2 ' Secundaria
                                row.Cells("ObservacionesFormacion").Value = Trim(WObsSecundaria)
                            Case 3 ' Terciaria
                                row.Cells("ObservacionesFormacion").Value = Trim(WObsTerciaria)
                            Case Else
                                row.Cells("ObservacionesFormacion").Value = ""
                        End Select

                    Next

                    for Each txt As TextBox In _CamposDeTexto
                        txt.Text = Trim(txt.Text)
                    Next

                End With
            Else
                ' Buzo: 1, Camisa: 2, Campera: 3, Pantalón: 4, Remera: 5, Zapato: 6
                    Dim WIndumentaria As String() = {"", "Buzo", "Camisa", "Campera", "Pantalon", "Remera", "Zapato"}
                    Dim WItem, WTalle, WObs As String

                    For i = 1 to 6

                        WItem = WIndumentaria(i)

                        WFila = dgvIndumentaria.Rows.Add
                        dgvIndumentaria.Rows(WFila).Cells("Indumentaria").Value = WItem

                        WTalle = ""
                        dgvIndumentaria.Rows(wfila).Cells("Talle").Value = Trim(WTalle)

                        WObs = ""
                        dgvIndumentaria.Rows(wfila).Cells("ObservacionesIndumentaria").Value = Trim(WObs)
                        dgvIndumentaria.Rows(WFila).Cells("TipoInd").Value = Str$(i)

                    Next
            End If

        Catch ex As Exception
            Throw _
                New Exception(
                    "Hubo un problema al querer consultar la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try
    End Sub

    Private Sub _CargarDatosLegajo()

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT Codigo, FechaVersion, FIngreso, FEgreso, Descripcion, " _
                                              & " EstaI, EstaII, EstaIII, EstadoI, EstadoII, EstadoIII " _
                                              & " FROM Legajo WHERE Dni = '" & txtDni.Text & "' AND Renglon = 1")
        Dim dr As SqlDataReader
        Dim _
            WLegajoActual,
            WLegajos,
            WAux,
            WFechaVersion,
            WFechaVersionOrd,
            WNombreCompleto,
            WFechaIngreso,
            WFechaEgreso,
            WEstado As String
        Dim WFilaFormacion As Short

        Try

            cn.ConnectionString = Helper._ConectarA
            cn.Open()
            cm.Connection = cn

            dr = cm.ExecuteReader()

            If dr.HasRows Then

                WLegajos = ""

                Do While dr.Read

                    With dr

                        WFechaVersion = IIf(IsDBNull(.Item("FechaVersion")), "", .Item("FechaVersion"))
                        WAux = Helper.ordenaFecha(WFechaVersion)
                        WLegajoActual = IIf(IsDBNull(.Item("Codigo")), "", .Item("Codigo"))

                        WLegajos &= IIf(Trim(wlegajos) <> "", " - " & WLegajoActual, WLegajoActual)

                        If Val(WAux) > Val(WFechaVersionOrd) then

                            WFechaVersionOrd = WAux

                            WNombreCompleto = IIf(IsDBNull(.Item("Descripcion")), "", .Item("Descripcion"))
                            WFechaIngreso = IIf(IsDBNull(.Item("FIngreso")), "", .Item("FIngreso"))
                            WFechaEgreso = IIf(IsDBNull(.Item("FEgreso")), "", .Item("FEgreso"))

                            dgvEducacion.Rows.Clear

                            ' Grabamos Primaria.
                            WEstado = IIf(IsDBNull(.Item("EstaI")), "", .Item("EstaI"))

                            Select Case Val(WEstado)
                                Case 1, 2, 8

                                    WFilaFormacion = dgvEducacion.Rows.Add

                                    dgvEducacion.Rows(WFilaFormacion).Cells("TipoFormacion").Value = "Primaria"
                                    dgvEducacion.Rows(WFilaFormacion).Cells("TituloFormacion").Value = "" _
                                    'IIf(IsDBNull(.Item("EstadoI")), "", .Item("EstadoI"))
                                    dgvEducacion.Rows(WFilaFormacion).Cells("IdFormacion").Value = "1" _
                                    'IIf(IsDBNull(.Item("EstadoI")), "", .Item("EstadoI"))

                                Case Else
                                    WEstado = ""
                            End Select

                            ' Grabamos Secundaria
                            WEstado = IIf(IsDBNull(.Item("EstaII")), "", .Item("EstaII"))

                            Select Case Val(WEstado)
                                Case 1, 2, 8

                                    WFilaFormacion = dgvEducacion.Rows.Add

                                    dgvEducacion.Rows(WFilaFormacion).Cells("TipoFormacion").Value = "Secundaria"
                                    dgvEducacion.Rows(WFilaFormacion).Cells("TituloFormacion").Value =
                                        IIf(IsDBNull(.Item("EstadoII")), "", .Item("EstadoII"))
                                    dgvEducacion.Rows(WFilaFormacion).Cells("IdFormacion").Value = "2"

                                Case Else
                                    WEstado = ""
                            End Select

                            ' Grabamos Terciaria/Universitaria
                            WEstado = IIf(IsDBNull(.Item("EstaIII")), "", .Item("EstaIII"))

                            Select Case Val(WEstado)
                                Case 1, 2, 8

                                    WFilaFormacion = dgvEducacion.Rows.Add

                                    dgvEducacion.Rows(WFilaFormacion).Cells("TipoFormacion").Value =
                                        "Terciaria/Universitaria"
                                    dgvEducacion.Rows(WFilaFormacion).Cells("TituloFormacion").Value =
                                        IIf(IsDBNull(.Item("EstadoIII")), "", .Item("EstadoIII"))
                                    dgvEducacion.Rows(WFilaFormacion).Cells("IdFormacion").Value = "3"

                                Case Else
                                    WEstado = ""
                            End Select

                        End If

                    End With

                Loop

                txtLegajo.Text = WLegajos
                txtFechaIngreso.Text = WFechaIngreso
                txtFechaEgreso.Text = IIf(WFechaEgreso = "00/00/0000", "  /  /    ", WFechaEgreso)
                txtNombreCompleto.Text = trim(WNombreCompleto)

            End If

        Catch ex As Exception
            Throw _
                New Exception(
                    "Hubo un problema al querer consultar la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try
    End Sub

    Private Sub txtNombreCompleto_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) _
        Handles txtNombreCompleto.KeyDown


        If e.KeyData = Keys.Enter Then
            If Trim(txtNombreCompleto.Text) = "" Then : Exit Sub :
            End If

            txtFechaNacimiento.Focus

        ElseIf e.KeyData = Keys.Escape Then
            txtNombreCompleto.Text = ""
        End If
    End Sub

    Private Sub txtFechaNacimiento_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) _
        Handles txtFechaNacimiento.KeyDown

        If e.KeyData = Keys.Enter Then
            'If txtFechaNacimiento.Text.estaVacia Then : Exit Sub : End If

            If Helper._ValidarFecha(txtFechaNacimiento.Text) then
                txtEdad.Text = _CalcularEdad(txtFechaNacimiento.Text)
                txtCalle.Focus
            End If

        ElseIf e.KeyData = Keys.Escape Then
            txtFechaNacimiento.Text = ""
        End If
    End Sub

    Private Sub txtCalle_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) _
        Handles txtCalle.KeyDown

        If e.KeyData = Keys.Enter Then
            'If Trim(txtCalle.Text) = "" Then : Exit Sub : End If

            txtNumero.Focus

        ElseIf e.KeyData = Keys.Escape Then
            txtCalle.Text = ""
        End If
    End Sub

    Private Sub txtNumero_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) _
        Handles txtNumero.KeyDown

        If e.KeyData = Keys.Enter Then
            'If Trim(txtNumero.Text) = "" Then : Exit Sub : End If

            txtDpto.Focus

        ElseIf e.KeyData = Keys.Escape Then
            txtNumero.Text = ""
        End If
    End Sub

    Private Sub txtDpto_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) _
        Handles txtDpto.KeyDown

        If e.KeyData = Keys.Enter Then
            'If Trim(txtDpto.Text) = "" Then : Exit Sub : End If

            txtCodPostal.Focus

        ElseIf e.KeyData = Keys.Escape Then
            txtDpto.Text = ""
        End If
    End Sub

    Private Sub txtCodPostal_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) _
        Handles txtCodPostal.KeyDown

        If e.KeyData = Keys.Enter Then
            'If Trim(txtCodPostal.Text) = "" Then : Exit Sub : End If

            txtLocalidad.Focus

        ElseIf e.KeyData = Keys.Escape Then
            txtCodPostal.Text = ""
        End If
    End Sub

    Private Sub txtLocalidad_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) _
        Handles txtLocalidad.KeyDown

        If e.KeyData = Keys.Enter Then
            'If Trim(txtLocalidad.Text) = "" Then : Exit Sub : End If

            txtAclaracion.Focus

        ElseIf e.KeyData = Keys.Escape Then
            txtLocalidad.Text = ""
        End If
    End Sub

    Private Sub txtAclaracion_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) _
        Handles txtAclaracion.KeyDown

        If e.KeyData = Keys.Enter Then
            'If Trim(txtAclaracion.Text) = "" Then : Exit Sub : End If

            txtFechaIngreso.Focus

        ElseIf e.KeyData = Keys.Escape Then
            txtAclaracion.Text = ""
        End If
    End Sub

    Private Sub txtFechaIngreso_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) _
        Handles txtFechaIngreso.KeyDown

        If e.KeyData = Keys.Enter Then
            'If Trim(txtFechaEgreso.Text) = "" Then : Exit Sub : End If

            txtFechaEgreso.Focus

        ElseIf e.KeyData = Keys.Escape Then
            txtFechaEgreso.Clear
        End If
    End Sub

    Private Sub txtFechaEgreso_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) _
        Handles txtFechaEgreso.KeyDown

        If e.KeyData = Keys.Enter Then
            'If Trim(txtFechaEgreso.Text) = "" Then : Exit Sub : End If

            TabControl1.SelectTab(1)

            txtNombreCompletoConyugue.Focus

        ElseIf e.KeyData = Keys.Escape Then
            txtFechaEgreso.Text = ""
        End If
    End Sub

    Private Sub txtNombreCompletoConyugue_KeyDown(ByVal sender As System.Object,
                                                  ByVal e As System.Windows.Forms.KeyEventArgs) _
        Handles txtNombreCompletoConyugue.KeyDown

        If e.KeyData = Keys.Enter Then
            'If Trim(txtNombreCompletoConyugue.Text) = "" Then : Exit Sub : End If

            txtEdadConyugue.Focus

        ElseIf e.KeyData = Keys.Escape Then
            txtNombreCompletoConyugue.Text = ""
        End If
    End Sub

    Private Sub txtEdadConyugue_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) _
        Handles txtEdadConyugue.KeyDown

        If e.KeyData = Keys.Enter Then
            'If Trim(txtEdadConyugue.Text) = "" Then : Exit Sub : End If

            txtDniConyugue.Focus

        ElseIf e.KeyData = Keys.Escape Then
            txtEdadConyugue.Text = ""
        End If
    End Sub

    Private Sub txtDniConyugue_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) _
        Handles txtDniConyugue.KeyDown

        If e.KeyData = Keys.Enter Then
            'If Trim(txtDniConyugue.Text) = "" Then : Exit Sub : End If

            txtFechaNacimientoConyugue.Focus

        ElseIf e.KeyData = Keys.Escape Then
            txtDniConyugue.Text = ""
        End If
    End Sub

    Private Sub txtFechaNacimientoConyugue_KeyDown(ByVal sender As System.Object,
                                                   ByVal e As System.Windows.Forms.KeyEventArgs) _
        Handles txtFechaNacimientoConyugue.KeyDown

        If e.KeyData = Keys.Enter Then
            'If Trim(txtFechaNacimientoConyugue.Text) = "" Then : Exit Sub : End If

            ' Validamos la fecha introducida sólo en los casos en que haya colocado alguna.
            If Not txtFechaNacimientoConyugue.Text.estaVacia then
                If Helper._ValidarFecha(txtFechaNacimientoConyugue.Text) then
                    txtEdadConyugue.Text = _CalcularEdad(txtFechaNacimientoConyugue.Text)
                    txtFechaCasamiento.Focus
                Else
                    Exit Sub
                End If
            Else
                txtFechaCasamiento.Focus
            End If

        ElseIf e.KeyData = Keys.Escape Then
            txtFechaNacimientoConyugue.Clear
        End If
    End Sub

    Private Sub txtFechaCasamiento_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) _
        Handles txtFechaCasamiento.KeyDown

        If e.KeyData = Keys.Enter Then
            'If Trim(txtFechaCasamiento.Text) = "" Then : Exit Sub : End If

            If Not txtFechaCasamiento.Text.estaVacia then

                If Not Helper._ValidarFecha(txtFechaCasamiento.Text) then

                    Exit Sub

                End If

            End If

            With dgvHijos
                .CurrentCell = .Rows(0).Cells(0)
                .Focus
            End With

        ElseIf e.KeyData = Keys.Escape Then
            txtFechaCasamiento.Clear
        End If
    End Sub

    'Private Sub txtLegajo_KeyDown( ByVal sender As System.Object,  ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtLegajo.KeyDown

    '    If e.KeyData = Keys.Enter Then
    '     If Trim(txtLegajo.Text) = "" Then : Exit Sub : End If


    '    ElseIf e.KeyData = Keys.Escape Then
    '        txtLegajo.Text = ""
    '    End If

    'End Sub

    Private Sub txtSueldoBruto_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) _
        Handles txtSueldoBruto.KeyDown

        If e.KeyData = Keys.Enter Then
            'If Trim(txtSueldoBruto.Text) = "" Then : Exit Sub : End If

            txtSueldoBruto.Text = Helper.formatonumerico(txtSueldoBruto.Text)

            With dgvIndumentaria
                .CurrentCell = .Rows(0).Cells(0)
                .Focus
            End With

        ElseIf e.KeyData = Keys.Escape Then
            txtSueldoBruto.Text = ""
        End If
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles TabControl1.SelectedIndexChanged
        Select Case TabControl1.SelectedIndex
            Case 0
                txtDni.Focus
            Case 1
                txtNombreCompletoConyugue.Focus
            Case 2
                txtSueldoBruto.Focus
            Case 3
                dgvEducacion.Focus
        End Select
    End Sub

    Private Sub cmbEstado_DropDownClosed(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles cmbEstado.DropDownClosed

        With cmbCategoria
            .DroppedDown = True
            .Focus
        End With
    End Sub

    Private Sub cmbEstado_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles cmbEstado.SelectedIndexChanged

        Select Case cmbEstado.SelectedIndex
            Case 1
                cmbCategoria.DataSource =
                    Configuration.ConfigurationManager.AppSettings("CAT_EN_CCT").Split(",").ToArray()
            Case 2
                cmbCategoria.DataSource =
                    Configuration.ConfigurationManager.AppSettings("CAT_FUERA_CCT").Split(",").ToArray()
            Case Else
                cmbCategoria.DataSource = {"", "", "", ""}
        End Select
    End Sub

    Private Sub cmbCategoria_DropDownClosed(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles cmbCategoria.DropDownClosed
        txtSueldoBruto.Focus
    End Sub

    Private Sub btnAceptar_Click( ByVal sender As System.Object,  ByVal e As System.EventArgs) Handles btnAceptar.Click

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("")
        Dim trans As SqlTransaction = Nothing
        Dim WDni, WFechaNac, WFechaNacOrd, WCalle, WNumero, WDpto, WPostal, WLocalidad, WAclaracion, _
            WConyugeNombre, WConyugeEdad, WConyugeDni, WConyugeFechaNac, WConyugeFechaNacOrd, _
            WFechaCasamiento, WFechaCasamientoOrd, WEstado, WCategoria, WUbicacion, WZapato, WRemera, _
            WBuzo, WCampera, WPantalon, WCamisa, WObsZapato, WObsRemera, WObsBuzo, WObsCampera, _
            WObsPantalon, WObsCamisa, WObsPrimaria, WObsSecundaria, WObsTerciaria, ZSql As String
        Dim WSueldoBruto As Double

        Try
            WDni = txtDni.Text
            WFechaNac = txtFechaNacimiento.Text
            WFechaNacOrd = Helper.ordenaFecha(WFechaNac)
            WCalle = Trim(txtCalle.Text)
            WNumero = Trim(txtNumero.Text)
            WDpto = Trim(txtDpto.Text)
            WPostal = Trim(txtCodPostal.Text)
            WLocalidad = Trim(txtLocalidad.Text)
            WAclaracion = Trim(txtAclaracion.Text)
            WConyugeNombre = Trim(txtNombreCompletoConyugue.Text)
            WConyugeEdad = Trim(txtEdadConyugue.Text)
            WConyugeDni = Trim(txtDniConyugue.Text)
            WConyugeFechaNac = txtFechaNacimientoConyugue.Text
            WConyugeFechaNacOrd = Helper.ordenaFecha(WConyugeFechaNac)
            WFechaCasamiento = txtFechaCasamiento.Text
            WFechaCasamientoOrd = Helper.ordenafecha(WFechaCasamiento)
            WEstado = cmbEstado.SelectedIndex
            WCategoria = cmbCategoria.SelectedIndex
            WUbicacion = cmbUbicacion.SelectedIndex
            WSueldoBruto = Val(Helper.formatonumerico(txtSueldoBruto.Text))
            
            For Each row As DataGridViewRow In dgvIndumentaria.Rows

                Select Val(row.Cells("TipoInd").Value)

                    Case 1
                        WBuzo = row.Cells("Talle").Value
                        WObsBuzo = row.Cells("ObservacionesIndumentaria").Value
                    Case 2
                        WCamisa = row.Cells("Talle").Value
                        WObsCamisa = row.Cells("ObservacionesIndumentaria").Value
                    Case 3
                        WCampera  = row.Cells("Talle").Value
                        WObsCampera = row.Cells("ObservacionesIndumentaria").Value
                    Case 4
                        WPantalon = row.Cells("Talle").Value
                        WObsPantalon = row.Cells("ObservacionesIndumentaria").Value
                    Case 5
                        WRemera = row.Cells("Talle").Value
                        WObsRemera = row.Cells("ObservacionesIndumentaria").Value
                    Case 6
                        WZapato = row.Cells("Talle").Value
                        WObsZapato = row.Cells("ObservacionesIndumentaria").Value
                    
                End Select

            Next

            For Each row As DataGridViewRow In dgvEducacion.Rows

                Select Case Val(row.Cells("IdFormacion").Value)

                    Case 1
                        WObsPrimaria = row.Cells("ObservacionesFormacion").Value
                    Case 2
                        WObsSecundaria = row.Cells("ObservacionesFormacion").Value
                    Case 3
                        WObsTerciaria = row.Cells("ObservacionesFormacion").Value
                End Select

            Next

            cn.ConnectionString = Helper._ConectarA
            cn.Open()
            trans = cn.BeginTransaction
            cm.Connection = cn
            cm.Transaction = trans

            cm.CommandText = "DELETE FROM Personal WHERE Dni = '" & WDni & "'"
            cm.ExecuteNonQuery

            ZSql = ""
            ZSql = "INSERT INTO Personal "
            ZSql &= " ("
            ZSql &= " Dni,"
            ZSql &= " FechaNac,"
            ZSql &= " FechaNacOrd,"
            ZSql &= " Calle,"
            ZSql &= " Numero,"
            ZSql &= " Dpto,"
            ZSql &= " Postal,"
            ZSql &= " Localidad,"
            ZSql &= " Aclaracion,"
            ZSql &= " ConyugeNombre,"
            ZSql &= " ConyugeEdad,"
            ZSql &= " ConyugeDni,"
            ZSql &= " ConyugeFechaNac,"
            ZSql &= " ConyugeFechaNacOrd,"
            ZSql &= " FechaCasamiento,"
            ZSql &= " FechaCasamientoOrd,"
            ZSql &= " Estado,"
            ZSql &= " Categoria,"
            ZSql &= " SueldoBruto,"
            ZSql &= " Ubicacion,"
            ZSql &= " Zapato,"
            ZSql &= " Remera,"
            ZSql &= " Buzo,"
            ZSql &= " Campera,"
            ZSql &= " Pantalon,"
            ZSql &= " Camisa,"
            ZSql &= " ObsZapato,"
            ZSql &= " ObsRemera,"
            ZSql &= " ObsBuzo,"
            ZSql &= " ObsCampera,"
            ZSql &= " ObsPantalon,"
            ZSql &= " ObsCamisa,"
            ZSql &= " ObsPrimaria,"
            ZSql &= " ObsSecundaria,"
            ZSql &= " ObsTerciaria "
            ZSql &= ") VALUES ("
            ZSql &= "'" & WDni & "',"
            ZSql &= "'" & WFechaNac & "',"
            ZSql &= "'" & WFechaNacOrd & "',"
            ZSql &= "'" & WCalle & "',"
            ZSql &= "'" & WNumero & "',"
            ZSql &= "'" & WDpto & "',"
            ZSql &= "'" & WPostal & "',"
            ZSql &= "'" & WLocalidad & "',"
            ZSql &= "'" & WAclaracion & "',"
            ZSql &= "'" & WConyugeNombre & "',"
            ZSql &= "'" & WConyugeEdad & "',"
            ZSql &= "'" & WConyugeDni & "',"
            ZSql &= "'" & WConyugeFechaNac & "',"
            ZSql &= "'" & WConyugeFechaNacOrd & "',"
            ZSql &= "'" & WFechaCasamiento & "',"
            ZSql &= "'" & WFechaCasamientoOrd & "',"
            ZSql &= "'" & WEstado & "',"
            ZSql &= "'" & WCategoria & "',"
            ZSql &= "" & Str$(WSueldoBruto) & ","
            ZSql &= "'" & WUbicacion & "',"
            ZSql &= "'" & WZapato & "',"
            ZSql &= "'" & WRemera & "',"
            ZSql &= "'" & WBuzo & "',"
            ZSql &= "'" & WCampera & "',"
            ZSql &= "'" & WPantalon & "',"
            ZSql &= "'" & WCamisa & "',"
            ZSql &= "'" & WObsZapato & "',"
            ZSql &= "'" & WObsRemera & "',"
            ZSql &= "'" & WObsBuzo & "',"
            ZSql &= "'" & WObsCampera & "',"
            ZSql &= "'" & WObsPantalon & "',"
            ZSql &= "'" & WObsCamisa & "',"
            ZSql &= "'" & WObsPrimaria & "',"
            ZSql &= "'" & WObsSecundaria & "',"
            ZSql &= "'" & WObsTerciaria & "'"
            ZSql &= "" & ")" & ""

            cm.CommandText=ZSql
            cm.ExecuteNonQuery

            cm.CommandText = "DELETE FROM PersonalHijos WHERE Dni = '" & WDni & "'"
            cm.ExecuteNonQuery

            Dim WClave, WNombre, WApellido, WEdad, WDniHijo, WFechaNacimientoHijo, WFechaNacimientoHijoOrd, WRenglon As String
            Dim XRenglon As Short = 0

            For Each row As DataGridViewRow In dgvHijos.Rows

                XRenglon += 1

                WClave = WDni + Helper.ceros(XRenglon, 2)

                With row

                    WNombre = IIf(IsNothing(.Cells("NombreHijo").Value), "", .Cells("NombreHijo").Value)
                    WApellido = IIf(IsNothing(.Cells("ApellidoHijo").Value), "", .Cells("ApellidoHijo").Value)
                    WEdad = IIf(IsNothing(.Cells("EdadHijo").Value), "", .Cells("EdadHijo").Value)
                    WDnihijo = IIf(IsNothing(.Cells("DniHijo").Value), "", .Cells("DniHijo").Value)
                    WFechaNacimientoHijo = IIf(IsNothing(.Cells("FechaNacimientoHijo").Value), "", .Cells("FechaNacimientoHijo").Value)
                    WFechaNacimientoHijoOrd = Helper.ordenaFecha(WFechaNacimientoHijo)

                    If Trim(WNombre) ="" and Trim(WApellido)="" then Continue For

                    ZSql = ""
                    ZSql = "INSERT INTO PersonalHijos "
                    ZSql &= " ("
                    ZSql &= " Clave,"
                    ZSql &= " Dni,"
                    ZSql &= " Renglon,"
                    ZSql &= " Nombre,"
                    ZSql &= " Apellido,"
                    ZSql &= " DniHijo,"
                    ZSql &= " Edad,"
                    ZSql &= " FechaNac,"
                    ZSql &= " FechaNacOrd"
                    ZSql &= ") VALUES ("
                    ZSql &= "'" & WClave & "',"
                    ZSql &= "'" & WDni & "',"
                    ZSql &= "'" & WRenglon & "',"
                    ZSql &= "'" & WNombre & "',"
                    ZSql &= "'" & WApellido & "',"
                    ZSql &= "'" & WDniHijo & "',"
                    ZSql &= "'" & WEdad & "',"
                    ZSql &= "'" & WFechaNacimientoHijo & "',"
                    ZSql &= "'" & WFechaNacimientoHijoOrd & "'"
                    ZSql &= "" & ")" & ""

                    cm.CommandText=ZSql
                    cm.ExecuteNonQuery

                End With

            Next

            trans.Commit

            btnLimpiar.PerformClick

        Catch ex As Exception

            If Not IsNothing(trans) then
                trans.Rollback
            End If

            MsgBox("Hubo un problema al querer consultar la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message, MsgBoxStyle.Exclamation)
        Finally

            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try
        
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

    'Private Function _EsDecimal(ByVal keycode As Integer) As Boolean
    '    Return (keycode >= 48 And keycode <= 57) Or (keycode >= 96 And keycode <= 105) Or (keycode = 110 Or keycode = 190)
    'End Function

    Private Function _EsNumeroOControl(ByVal keycode) As Boolean
        Dim valido As Boolean = False

        If _EsNumero(CInt(keycode)) Or _EsControl(keycode) Then
            valido = True
        Else
            valido = False
        End If

        Return valido
    End Function

    'Private Function _EsDecimalOControl(ByVal keycode) As Boolean
    '    Dim valido As Boolean = False

    '    If _EsDecimal(CInt(keycode)) Or _EsControl(keycode) Then
    '        valido = True
    '    Else
    '        valido = False
    '    End If

    '    Return valido
    'End Function

    
        
    'With txtCodigo
    '    .CurrentCell = .Rows(iRow).Cells(iCol + 1)

    '    Dim _location As Point = .GetCellDisplayRectangle(2, iRow, False).Location

    '    .ClearSelection()
    '	 .CurrentCell.Style.SelectionBackColor = Color.White ' Evitamos que se vea la seleccion de la celda.
    '    _location.Y += .Location.Y + (.CurrentCell.Size.Height / 4) - YMARGEN
    '    _location.X += .Location.X + (.CurrentCell.Size.Width - txtFechaAux.Size.Width) - XMARGEN
    '    txtFechaAux.Location = _location
    '    txtFechaAux.Text = .Rows(iRow).Cells(2).Value
    '    WRow = iRow
    '    Wcol = iCol
    '    txtFechaAux.Visible = True
    '    txtFechaAux.Focus()
    'End With

    Private Sub txtFechaAux_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFechaAux.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txtFechaAux.Text.Replace("/", "")) = "" Then : Exit Sub : End If
            
            If Helper._ValidarFecha(Trim(txtFechaAux.Text)) And WRow >= 0 And Wcol >= 0 Then

                With dgvHijos
                    .Rows(WRow).Cells(4).Value = txtFechaAux.Text

                    Try
                        .CurrentCell = .Rows(WRow + 1).Cells(0)
                    Catch ex As Exception
                        .Rows.Add
                        .CurrentCell = .Rows(WRow + 1).Cells(0)
                    End Try
                    
                    .Focus()

                    txtFechaAux.Visible = False
                    txtFechaAux.Location = New Point(680, 390) ' Lo reubicamos lejos de la grilla.
                End With
                
            End If

            Dim WFecha As String

            For Each row As DataGridViewRow In dgvHijos.Rows
                With row
                    WFecha = IIf(IsNothing(.Cells("FechaNacimientoHijo").Value), "", .Cells("FechaNacimientoHijo").Value)        

                    If not WFecha.estaVacia then
                        
                        .Cells("EdadHijo").Value = _CalcularEdad(WFecha)

                    End If

                End With
            Next

        ElseIf e.KeyData = Keys.Escape Then
            txtFechaAux.Text = ""
        End If

    End Sub

    Private Sub txtCodigo_CellEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvHijos.CellEnter
        With dgvHijos
            If e.ColumnIndex = 4 Then
                .ClearSelection()
                .CurrentCell.Style.SelectionBackColor = Color.White ' Evitamos que se vea la seleccion de la celda.
                Dim _location As Point = .GetCellDisplayRectangle(4, e.RowIndex, False).Location

                _location.Y += .Location.Y + (.CurrentCell.Size.Height / 4) - YMARGEN
                _location.X += .Location.X + (.CurrentCell.Size.Width - txtFechaAux.Size.Width) - XMARGEN
                txtFechaAux.Location = _location
                txtFechaAux.Text = .Rows(e.RowIndex).Cells(4).Value
                WRow = e.RowIndex
                Wcol = e.ColumnIndex
                txtFechaAux.Visible = True
                txtFechaAux.Focus()
            End If
        End With
    End Sub
    
    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean

        With dgvHijos
            If .Focused Or .IsCurrentCellInEditMode Then ' Detectamos los ENTER tanto si solo estan en foco o si estan en edición una celda.
                .CommitEdit(DataGridViewDataErrorContexts.Commit) ' Guardamos todos los datos que no hayan sido confirmados.

                Dim iCol = .CurrentCell.ColumnIndex
                Dim iRow = .CurrentCell.RowIndex
                Dim valor = IIf(IsNothing(.CurrentCell.Value), "", .CurrentCell.Value)
                Dim NUM_COLS = 5
                ' Limitamos los caracteres permitidos para cada una de las columnas.
                Select Case iCol
                    Case 2,3
                        If Not _EsNumeroOControl(keyData) Then
                            Return True
                        End If
                    'Case 4
                    '    If Not _EsDecimalOControl(keyData) Then
                    '        Return True
                    '    End If
                    'Case Else

                End Select

                If msg.WParam.ToInt32() = Keys.Enter Then

                    If valor <> "" Then
                        
                        Select Case iCol
                            Case 0
                                Dim _apellido As String = IIf(IsNothing(.Rows(iRow).Cells(iCol + 1).value), "", .Rows(iRow).Cells(iCol + 1).value)

                                If Trim(_apellido) = "" then
                                    Try
                                        .Rows(iRow).Cells(iCol + 1).value = .Rows(iRow - 1).Cells(iCol + 1).value
                                    Catch ex As Exception
                                        .Rows(iRow).Cells(iCol + 1).value = ""
                                    End Try
                                End If
                        
                        End Select

                    End If

                    Select Case iCol
                        Case NUM_COLS -1
                            
                            Try
                                .CurrentCell = .Rows(iRow + 1).Cells(0)
                            Catch ex As Exception
                                .Rows.Add
                                .CurrentCell = .Rows(iRow + 1).Cells(0)
                            End Try

                        Case Else
                            .CurrentCell = .Rows(iRow).Cells(iCol + 1)
                    End Select

                    Return True

                ElseIf msg.WParam.ToInt32() = Keys.Escape Then
                    .Rows(iRow).Cells(iCol).Value = ""

                    If iCol = NUM_COLS - 1 Then
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
      
    Private Sub dgvHijos_RowHeaderMouseDoubleClick( ByVal sender As System.Object,  ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvHijos.RowHeaderMouseDoubleClick

        Try
            With dgvHijos
                Dim iRow As Short = e.RowIndex
                If MsgBox("¿Está seguro de que quiere eliminar el registro?", MsgBoxStyle.YesNo) = MsgBoxResult.No then Exit Sub
                .Rows.Remove(.Rows(iRow))
                If .Rows.Count = 0 then
                    .Rows.Add
                End If
            End With
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
        
    End Sub

    Private Function _CalcularEdad(ByVal WFecha As String) As String

        Try
            If WFecha.estaVacia then Return ""

            Dim WDia, WMes, WAnio As Short
            Dim WNacimiento As Date

            WDia = Mid(wfecha, 1, 2)
            WMes = Mid(wfecha, 4, 2)
            WAnio = Mid(wfecha, 7, 4)

            WNacimiento = New Date(WAnio, WMes, WDia)

            If Date.Compare(WNacimiento, Date.Now) > 0 then Return 0

            Return Date.Now.AddTicks(-WNacimiento.Ticks).Year - 1

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
            Return ""
        End Try

    End Function

    Private Sub ConsultaInformacionPersonal_FormClosing( ByVal sender As System.Object,  ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing

        If Trim(txtDni.Text) = "" then Exit Sub

        If MsgBox("¿Está seguro de que quiere cerrar el formulario? Se perderán aquellos datos que no se hayan guardado.", MsgBoxStyle.YesNo) = MsgBoxResult.No then
            e.Cancel = True
        End If

    End Sub

    Private Sub btnConsultas_Click( ByVal sender As System.Object,  ByVal e As System.EventArgs) Handles btnConsultas.Click
        
        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("")
        Dim dr As SqlDataReader
        Dim WVector(1,2) As String
        Dim WRenglon As Integer = 0

        Try

            lstConsulta.Items.Clear
            lstFiltrada.Items.Clear

            cn.ConnectionString = Helper._ConectarA
            cn.Open()
            cm.Connection = cn

            Array.Clear(WVector, 0, WVector.Length)
            cm.CommandText="SELECT COUNT(Distinct Dni) as Total FROM Legajo WHERE Dni <> '' and Dni <> 0"
            
            dr = cm.ExecuteReader()
            dr.Read

            If dr.Item("Total") = 0 then Exit Sub

            ReDim WVector(dr.Item("Total") - 1, 2)

            If Not dr.IsClosed then
                dr.Close
            End If

            cm.CommandText = "SELECT Distinct Dni, Descripcion FROM Legajo WHERE Dni <> '' and Dni <> 0 Order by Descripcion"
            dr = cm.ExecuteReader()

            If dr.HasRows Then

                Do While dr.Read()

                    WVector(WRenglon, 1) = dr.Item("Dni")
                    WVector(WRenglon, 2) = dr.Item("Descripcion")

                    WRenglon += 1
                Loop

            End If

            For i = 0 to WRenglon - 1
                lstConsulta.Items.Add(WVector(i, 1).PadRight(15) & Trim(WVector(i, 2)))
                WIndice.Items.Add(WVector(i, 1))
            Next

            pnlConsulta.Visible=True
            txtAyuda.Text = ""
            txtAyuda.Focus
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
		    origen.Visible = false

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
    
    Private Sub lstConsulta_Click( ByVal sender As System.Object,  ByVal e As System.EventArgs) Handles lstConsulta.Click

        Try
            
            If lstConsulta.SelectedItem = "" then Exit Sub

            txtDni.Text = WIndice.Items(lstConsulta.SelectedIndex)

            txtDni_KeyDown(Nothing, New KeyEventArgs(Keys.Enter))

            pnlConsulta.Visible=False

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub btnCerrarConsulta_Click( ByVal sender As System.Object,  ByVal e As System.EventArgs) Handles btnCerrarConsulta.Click
        pnlConsulta.Visible=False
        txtDni.Focus
    End Sub

    Private Sub btnEliminar_Click( ByVal sender As System.Object,  ByVal e As System.EventArgs) Handles btnEliminar.Click

        If Trim(txtDni.Text) = "" then Exit Sub

        If MsgBox("¿Seguro de que quiere eliminar los datos del Personal?", MsgBoxStyle.YesNo) = MsgBoxResult.No then Exit Sub

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("DELETE FROM Personal WHERE Dni = '" & txtDni.Text & "'")
        Dim trans As SqlTransaction = Nothing

        Try

            cn.ConnectionString = Helper._ConectarA
            cn.Open()
            trans = cn.BeginTransaction
            cm.Connection = cn
            cm.Transaction=trans

            cm.ExecuteNonQuery

            cm.CommandText = "DELETE FROM PersonalHijos WHERE Dni = '" & txtDni.Text & "'"
            cm.ExecuteNonQuery

            trans.Commit

            btnLimpiar.PerformClick

        Catch ex As Exception
            If Not IsNothing(trans) then
                trans.Rollback
            End If
            Throw New Exception("Hubo un problema al querer consultar la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        Finally

            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try
        
    End Sub
End Class