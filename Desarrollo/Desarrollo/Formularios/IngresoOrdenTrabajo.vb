Imports System.Data.SqlClient

Public Class IngresoOrdenTrabajo

    Private Sub IngresoOrdenTrabajo_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        btnLimpiar.PerformClick()
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click, Button1.Click
        Close()
    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        ' Limpiamos los campos.
        _LimpiarCampos()

        ' Limpiamos los archivos cargados en notas.

        ' Posicionamos en Orden y mostramos la primer pestaña.
        TabControl1.SelectedIndex = 0
        txtOrden.Focus()

    End Sub

    Private Sub _LimpiarCampos()

        For Each _txt As TextBox In _CamposDeTexto()
            _txt.Text = ""
        Next

        For Each _m As MaskedTextBox In {txtOrden, txtCliente, txtFecha, txtFechaComprometida}
            _m.Clear()
        Next

        For Each _c As ComboBox In {cmbAplicacion, cmbEstabilidad}
            _c.SelectedIndex = 0
        Next

        pnlConsulta.Visible = False

    End Sub

    Private Function _CamposDeTexto() As TextBox()
        Return {txtDescCliente, txtObservaciones, txtMaterial, txtMuestra, txtUso, txtObservacionesII, txtEncargado, txtRequisitosFuncionales, txtOtrosRequisitos, txtRequisitosNormasRegulaciones, txtReferencias, txtDescTrabajo, txtAyuda}
    End Function

    Private Sub txtOrden_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtOrden.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txtOrden.Text.Replace("-", "")) = "" Then : Exit Sub : End If

            Try
                txtOrden.Text = UCase(txtOrden.Text)

                If Trim(txtOrden.Text).Length < 8 Then Exit Sub

                _CargarOrdenTrabajo()

                txtFecha.Focus()

            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Exclamation)
            End Try

        ElseIf e.KeyData = Keys.Escape Then
            txtOrden.Text = ""
        End If

    End Sub

    Private Sub _CargarOrdenTrabajo()
        Dim WOrden = txtOrden.Text, WAux = ""
        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("")
        Dim dr As SqlDataReader

        Try
            btnLimpiar.PerformClick()
            txtOrden.Text = WOrden
            cn.ConnectionString = Helper._ConectarA
            cn.Open()
            cm.Connection = cn
            cm.CommandText = "SELECT * FROM OrdenTrabajo WHERE Orden = '" & txtOrden.Text & "'"

            dr = cm.ExecuteReader()

            If dr.HasRows Then

                With dr
                    .Read()

                    txtFecha.Text = IIf(IsDBNull(.Item("Fecha")), "", .Item("Fecha"))
                    txtFechaComprometida.Text = IIf(IsDBNull(.Item("FechaEntrega")), "", .Item("FechaEntrega"))
                    txtCliente.Text = IIf(IsDBNull(.Item("Cliente")), "", .Item("Cliente"))
                    txtObservaciones.Text = IIf(IsDBNull(.Item("Observaciones")), "", .Item("Observaciones"))
                    txtMaterial.Text = IIf(IsDBNull(.Item("Material")), "", .Item("Material"))
                    txtMuestra.Text = IIf(IsDBNull(.Item("Muestra")), "", .Item("Muestra"))
                    txtUso.Text = IIf(IsDBNull(.Item("Uso")), "", .Item("Uso"))

                    txtEncargado.Text = IIf(IsDBNull(.Item("Encargado")), "", .Item("Encargado"))
                    cmbAplicacion.SelectedIndex = IIf(IsDBNull(.Item("Aplicacion")), 0, .Item("Aplicacion"))
                    cmbEstabilidad.SelectedIndex = IIf(IsDBNull(.Item("Estabilidad")), 0, .Item("Estabilidad"))

                    ' Cargamos las Descripciones de Trabajo.
                    For Each _o In {"I", "II", "III", "IV", "V", "VI"}

                        WAux = IIf(IsDBNull(.Item("Descripcion" & _o)), "", .Item("Descripcion" & _o))

                        WAux = Trim(WAux)

                        If WAux <> "" Then
                            txtDescTrabajo.Text &= Trim(WAux) & " "
                        End If
                    Next

                    WAux = ""

                    ' Cargamos las Observaciones.
                    For Each _o In {"I", "II", "III"}

                        WAux = IIf(IsDBNull(.Item("Observaciones" & _o)), "", .Item("Observaciones" & _o))

                        WAux = Trim(WAux)

                        If WAux <> "" Then
                            txtObservacionesII.Text &= Trim(WAux) & " "
                        End If

                    Next

                    WAux = ""

                    ' Cargamos los Requisitos Funcionales.
                    For Each _o In {"I", "II"} ', "III", "IV", "V", "VI"}

                        WAux = IIf(IsDBNull(.Item("Requisito" & _o)), "", .Item("requisito" & _o))

                        WAux = Trim(WAux)

                        If WAux <> "" Then
                            txtRequisitosFuncionales.Text &= Trim(WAux) & " "
                        End If
                    Next

                    WAux = ""

                    ' Cargamos los Otros Requisitos.
                    For Each _o In {"III", "IV"} ', "V", "VI"}

                        WAux = IIf(IsDBNull(.Item("Requisito" & _o)), "", .Item("requisito" & _o))

                        WAux = Trim(WAux)

                        If WAux <> "" Then
                            txtOtrosRequisitos.Text &= Trim(WAux) & " "
                        End If
                    Next

                    WAux = ""

                    ' Cargamos los Requisitos Legales, Normas y/o Regulaciones.
                    For Each _o In {"V", "VI"}

                        WAux = IIf(IsDBNull(.Item("Requisito" & _o)), "", .Item("requisito" & _o))

                        WAux = Trim(WAux)

                        If WAux <> "" Then
                            txtRequisitosNormasRegulaciones.Text &= Trim(WAux) & " "
                        End If
                    Next

                    WAux = ""

                    ' Cargamos las Referencias.
                    For Each _o In {"I", "II"}

                        WAux = IIf(IsDBNull(.Item("Referencia" & _o)), "", .Item("Referencia" & _o))

                        WAux = Trim(WAux)

                        If WAux <> "" Then
                            txtReferencias.Text &= Trim(WAux) & " "
                        End If
                    Next

                End With

                For Each txt As TextBox In _CamposDeTexto()
                    txt.Text = Trim(txt.Text)
                Next

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

    Private Sub IngresoOrdenTrabajo_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        txtOrden.Focus()
    End Sub

    Private Sub txtFecha_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFecha.KeyDown

        If e.KeyData = Keys.Enter Then

            If txtFecha.Text.estaVacia Then : Exit Sub : End If

            If Helper._ValidarFecha(txtFecha.Text) Then
                txtFechaComprometida.Focus()
            End If

        ElseIf e.KeyData = Keys.Escape Then
            txtFecha.Clear()
        End If

    End Sub

    Private Sub txtFechaComprometida_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFechaComprometida.KeyDown
        If e.KeyData = Keys.Enter Then

            If txtFechaComprometida.Text.estaVacia Then : Exit Sub : End If

            If Helper._ValidarFecha(txtFechaComprometida.Text) Then

                Dim WFecha = txtFecha.Text, WFechaComprometida = txtFechaComprometida.Text

                If WFecha.esMenorOIgualA(WFechaComprometida) Then
                    txtCliente.Focus()
                Else
                    MsgBox("La fecha de Compromiso debe ser posterior o igual a la Fecha de Ingreso.")
                End If

            End If

        ElseIf e.KeyData = Keys.Escape Then
            txtFechaComprometida.Clear()
        End If
    End Sub

    Private Sub txtCliente_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCliente.KeyDown

        If e.KeyData = Keys.Enter Then

            Try
                txtCliente.Text = UCase(txtCliente.Text)

                If Trim(txtCliente.Text) = "" Then

                    txtDescCliente.Text = ""

                ElseIf Trim(txtCliente.Text).Length < 6 Then

                    txtDescCliente.Text = ""
                    Exit Sub

                Else

                    txtDescCliente.Text = _TraerNombreCliente(txtCliente.Text)

                    If Trim(txtDescCliente.Text) = "" Then Throw New Exception("Cliente Inexistente")

                End If

                txtObservaciones.Focus()

            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Exclamation)
            End Try

        ElseIf e.KeyData = Keys.Escape Then
            txtCliente.Text = ""
        End If

    End Sub

    Private Function _TraerNombreCliente(ByVal WCliente As String) As String

        WCliente = Trim(WCliente)
        Dim WDescCliente As String = ""
        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT Razon FROM Cliente WHERE Cliente = '" & WCliente & "'")
        Dim dr As SqlDataReader

        Try

            cn.ConnectionString = Helper._ConectarA
            cn.Open()
            cm.Connection = cn

            dr = cm.ExecuteReader()

            If dr.HasRows Then

                With dr
                    .Read()

                    WDescCliente = IIf(IsDBNull(.Item("Razon")), "", .Item("Razon"))

                    WDescCliente = Trim(WDescCliente)

                End With


            End If

        Catch ex As Exception
            Throw New Exception("Hubo un problema al querer consultar el nombre del Cliente en la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

        Return WDescCliente
    End Function

    Private Sub txtObservaciones_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtObservaciones.KeyDown

        If e.KeyData = Keys.Enter Then
            'If Trim(txtObservaciones.Text) = "" Then : Exit Sub : End If

            TabControl1.SelectedIndex = 0
            txtMaterial.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtObservaciones.Text = ""
        End If

    End Sub

    Private Sub txtMaterial_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtMaterial.KeyDown
        
        If e.KeyData = Keys.Enter Then
            'If Trim(txtMaterial.Text) = "" Then : Exit Sub : End If

            txtMuestra.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtMaterial.Text = ""
        End If

    End Sub

    Private Sub txtMuestra_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtMuestra.KeyDown

        If e.KeyData = Keys.Enter Then
            '    If Trim(txtMuestra.Text) = "" Then : Exit Sub : End If
            txtUso.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtMuestra.Text = ""
        End If

    End Sub

    Private Sub txtUso_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtUso.KeyDown

        If e.KeyData = Keys.Enter Then
            '    If Trim(txtUso.Text) = "" Then : Exit Sub : End If

            txtDescTrabajo.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtUso.Text = ""
        End If

    End Sub

    Private Sub txtDescTrabajo_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDescTrabajo.KeyDown

        If e.KeyData = Keys.Enter Then

            ' Se habilita que para crear una nueva linea, se debe presionar Shit + Enter, sino se pasa al siguiente control.
            If Not e.Modifiers = Keys.Shift Then
                txtObservacionesII.Focus()
            End If

        End If

    End Sub

    Private Sub txtObservacionesII_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtObservacionesII.KeyDown

        If e.KeyData = Keys.Enter Then

            ' Se habilita que para crear una nueva linea, se debe presionar Shit + Enter, sino se pasa al siguiente control.
            If Not e.Modifiers = Keys.Shift Then
                txtEncargado.Focus()
            End If

        End If

    End Sub

    Private Sub txtEncargado_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtEncargado.KeyDown

        If e.KeyData = Keys.Enter Then
            '    If Trim(txtEncargado.Text) = "" Then : Exit Sub : End If

            TabControl1.SelectedIndex = 1

            txtRequisitosFuncionales.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtEncargado.Text = ""
        End If

    End Sub

    Private Sub txtRequisitosFuncionales_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRequisitosFuncionales.KeyDown
        If e.KeyData = Keys.Enter Then

            ' Se habilita que para crear una nueva linea, se debe presionar Shit + Enter, sino se pasa al siguiente control.
            If Not e.Modifiers = Keys.Shift Then
                txtOtrosRequisitos.Focus()
            End If

        End If
    End Sub

    Private Sub txtOtrosRequisitos_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtOtrosRequisitos.KeyDown
        If e.KeyData = Keys.Enter Then

            ' Se habilita que para crear una nueva linea, se debe presionar Shit + Enter, sino se pasa al siguiente control.
            If Not e.Modifiers = Keys.Shift Then
                txtRequisitosNormasRegulaciones.Focus()
            End If

        End If
    End Sub

    Private Sub txtRequisitosNormasRegulaciones_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRequisitosNormasRegulaciones.KeyDown
        If e.KeyData = Keys.Enter Then

            ' Se habilita que para crear una nueva linea, se debe presionar Shit + Enter, sino se pasa al siguiente control.
            If Not e.Modifiers = Keys.Shift Then
                txtReferencias.Focus()
            End If

        End If
    End Sub

    Private Sub txtReferencias_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtReferencias.KeyDown
        If e.KeyData = Keys.Enter Then

            ' Se habilita que para crear una nueva linea, se debe presionar Shit + Enter, sino se pasa al siguiente control.
            If Not e.Modifiers = Keys.Shift Then

                cmbAplicacion.Focus()
                
            End If

        End If
    End Sub
    
    Private Sub cmbAplicacion_DropDownClosed(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbAplicacion.DropDownClosed
        cmbEstabilidad.Focus()
    End Sub

    Private Sub cmbAplicacion_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbAplicacion.KeyDown


        If e.KeyData = Keys.Enter Then
            'If Trim(cmbAplicacion.Text) = "" Then : Exit Sub : End If

            cmbEstabilidad.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            cmbAplicacion.SelectedIndex = 0
        End If

    End Sub

    Private Sub btnConsultas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultas.Click
        
        Try
            _CargarClientes()

            pnlConsulta.Visible = True
            lstConsulta.Visible = True
            lstFiltrada.Visible = False
            txtAyuda.Text = ""

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
        'lstConsulta_Click(Nothing, Nothing)


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

            Dim WClave = "", WNombre = ""

            WClave = WIndice.Items(lstConsulta.SelectedIndex)

            txtCliente.Text = WClave
            txtDescCliente.Text = _TraerNombreCliente(WClave)

            pnlConsulta.Visible = False

            txtObservaciones.Focus()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
End Class