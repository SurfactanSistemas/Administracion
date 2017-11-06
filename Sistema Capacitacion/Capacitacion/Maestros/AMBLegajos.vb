Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine

Public Class AMBLegajos
    Private Const TABLA_Legajos = "Tema"
    Private Const TABLA_TEMAS = "Curso"

    Private WClavesLegajos(1000) As String

    '
    '   DATATABLES PARA FILTRAR DINÁMICAMENTE.
    '
    Private DT_Cursos As New DataTable

    Private Sub AMBLegajos_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        TabControl1.SelectTab(0)

        'dgvConocimientos.Rows.Add()

        'btnLimpiar.PerformClick()
    End Sub

    Private Function _TraerProximoCodigoTarea() As String

        Dim WUltimo = "0"
        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT MAX(Curso) as Ultimo FROM " & TABLA_Legajos)
        Dim dr As SqlDataReader

        Try

            cn.ConnectionString = Helper._ConectarA
            cn.Open()
            cm.Connection = cn

            dr = cm.ExecuteReader()

            If dr.HasRows Then
                dr.Read()

                WUltimo = IIf(IsDBNull(dr.Item("Ultimo")), 0, dr.Item("Ultimo"))

            End If

        Catch ex As Exception
            Throw New Exception("Hubo un problema al querer traer el próximo codigo de Tarea desde la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

        Return WUltimo + 1
    End Function

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click

        GrupoObservacionesII.Visible = False
        GrupoObservacionesI.Visible = False
        AtencionNoActualizado.Visible = False

        _LimpiarTodo()

        txtLegajo.Focus()
    End Sub

    Private Sub NumerosConComas(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Not Char.IsNumber(e.KeyChar) And Not Char.IsControl(e.KeyChar) And Not (CChar(".")) = e.KeyChar Then
            e.Handled = True
        End If
    End Sub

    Private Sub SoloNumero(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtLegajo.KeyPress, txtHasta.KeyPress, txtDesde.KeyPress, txtNroVersion.KeyPress, txtSectorDescripcion.KeyPress, txtPerfilVersion.KeyPress, txtPerfilDescripcion.KeyPress, txtPerfil.KeyPress, txtTareasIII.KeyPress, txtSector.KeyPress, txtTareasII.KeyPress, txtTareasI.KeyPress, txtDescriIII.KeyPress, txtObservaII.KeyPress, txtDescriII.KeyPress, txtObservaI.KeyPress, txtDescriI.KeyPress, txtEquivalenciasII.KeyPress, txtEquivalenciasI.KeyPress, txtOtrosII.KeyPress, txtOtrosI.KeyPress, txtFisica.KeyPress, txtObservaV.KeyPress, txtDescriV.KeyPress, txtObservaIV.KeyPress, txtDescriIV.KeyPress, txtObservaIII.KeyPress, txtEstadoX.KeyPress, txtEstadoIX.KeyPress, txtEstadoVIII.KeyPress, txtEstadoVII.KeyPress, txtEstadoVI.KeyPress, txtEstadoV.KeyPress, txtEstadoIV.KeyPress, txtEstadoIII.KeyPress, txtEstadoII.KeyPress, txtEstadoI.KeyPress
        If Not Char.IsNumber(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub btnConsulta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsulta.Click
        GrupoImpresion.Visible = False
        GrupoConsulta.Visible = True

        Dim WCodigo, WDescripcion, WRenglon

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT Codigo, Descripcion FROM " & TABLA_TEMAS & " ORDER BY Codigo")
        Dim dr As SqlDataReader

        Try
            WCodigo = ""
            WDescripcion = ""
            lstConsulta.Items.Clear()
            lstFiltrada.Items.Clear()
            lstFiltrada.Visible = False
            WRenglon = 0

            cn.ConnectionString = Helper._ConectarA
            cn.Open()
            cm.Connection = cn

            dr = cm.ExecuteReader()

            If dr.HasRows Then

                Do While dr.Read()

                    With dr

                        WCodigo = IIf(IsDBNull(.Item("Codigo")), "", Trim(.Item("Codigo")))
                        WDescripcion = IIf(IsDBNull(.Item("Descripcion")), "", Trim(.Item("Descripcion")))

                        If WCodigo <> "" And WDescripcion <> "" Then
                            lstConsulta.Items.Add(WDescripcion)
                            WClavesLegajos(WRenglon) = WCodigo
                            WRenglon += 1
                        End If

                    End With

                Loop

            End If

        Catch ex As Exception
            Throw New Exception("Hubo un problema al querer consultar los temas disponibles en la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

        lstConsulta.Visible = True
        txtAyuda.Text = ""
        txtAyuda.Focus()

    End Sub

    Private Sub btnCerrarConsulta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrarConsulta.Click
        GrupoConsulta.Visible = False
        txtLegajo.Focus()
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
        If lstConsulta.SelectedItem = "" Then : Exit Sub : End If

        txtLegajo.Text = WClavesLegajos(lstConsulta.SelectedIndex)

        txtTema_KeyDown(Nothing, New KeyEventArgs(Keys.Enter))

        btnCerrarConsulta.PerformClick()
    End Sub

    Private Sub AMBLegajos_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        txtLegajo.Focus()
    End Sub

    Private Sub txtTema_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNroVersion.KeyDown, txtSectorDescripcion.KeyDown, txtPerfilVersion.KeyDown, txtPerfilDescripcion.KeyDown, txtTareasIII.KeyDown, txtSector.KeyDown, txtTareasII.KeyDown, txtTareasI.KeyDown, txtDescriIII.KeyDown, txtObservaII.KeyDown, txtDescriII.KeyDown, txtObservaI.KeyDown, txtDescriI.KeyDown, txtEquivalenciasII.KeyDown, txtEquivalenciasI.KeyDown, txtOtrosII.KeyDown, txtOtrosI.KeyDown, txtFisica.KeyDown, txtObservaV.KeyDown, txtDescriV.KeyDown, txtObservaIV.KeyDown, txtDescriIV.KeyDown, txtObservaIII.KeyDown, txtEstadoX.KeyDown, txtEstadoIX.KeyDown, txtEstadoVIII.KeyDown, txtEstadoVII.KeyDown, txtEstadoVI.KeyDown, txtEstadoV.KeyDown, txtEstadoIV.KeyDown, txtEstadoIII.KeyDown, txtEstadoII.KeyDown, txtEstadoI.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txtLegajo.Text) = "" Then
                btnConsulta.PerformClick()
                Exit Sub
            End If

            Try
                _TraerTarea(txtLegajo.Text)
                Exit Sub
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical)
                Exit Sub
            End Try

            txtDescripcion.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtLegajo.Text = ""
        End If

    End Sub

    Private Sub _TraerTarea(ByVal codigo As String)
        'codigo = Trim(codigo)

        'If codigo = "" Then : Exit Sub : End If

        'btnLimpiar.PerformClick()

        'Dim WCodigo, WDescripcionTema, WCurso, WDescripcionCurso, WHorasCurso, WRenglon
        'Dim cn As SqlConnection = New SqlConnection()
        'Dim cm As SqlCommand = New SqlCommand("SELECT t.Descripcion as DescriTema FROM " & TABLA_TEMAS & " as t WHERE t.Codigo = '" & codigo & "'")

        'Dim dr As SqlDataReader

        'Try
        '    WCodigo = codigo
        '    WDescripcionTema = ""
        '    WCurso = ""
        '    WDescripcionCurso = ""
        '    WHorasCurso = ""
        '    WRenglon = 0

        '    cn.ConnectionString = Helper._ConectarA
        '    cn.Open()
        '    cm.Connection = cn

        '    dr = cm.ExecuteReader()

        '    If dr.HasRows Then
        '        dr.Read()
        '        WDescripcionTema = IIf(IsDBNull(dr.Item("DescriTema")), "", dr.Item("DescriTema"))

        '        dr.Close()

        '        ' Buscamos los Legajos que se tengan asociados.
        '        cm.CommandText = "SELECT c.Tema as Curso, c.Descripcion as DescriCurso, c.Horas FROM " & TABLA_Legajos & " as c WHERE c.Curso = '" & codigo & "' ORDER BY c.Tema"

        '        dr = cm.ExecuteReader

        '        If dr.HasRows Then
        '            While dr.Read()

        '                With dr

        '                    WCurso = IIf(IsDBNull(.Item("Curso")), "", .Item("Curso"))
        '                    WDescripcionCurso = IIf(IsDBNull(.Item("DescriCurso")), "", .Item("DescriCurso"))
        '                    WHorasCurso = IIf(IsDBNull(.Item("Horas")), "", .Item("Horas"))

        '                End With

        '                With 'dgvLegajos.Rows(WRenglon)
        '                    .Cells("Curso").Value = WCurso
        '                    .Cells("Descripcion").Value = WDescripcionCurso
        '                    .Cells("Horas").Value = Helper.formatonumerico(WHorasCurso)
        '                    WRenglon = 'dgvLegajos.Rows.Add
        '                End With
        '            End While
        '        End If

        '    End If

        'Catch ex As Exception
        '    Throw New Exception("Hubo un problema al querer consultar la información del Tarea indicado." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        'Finally

        '    dr = Nothing
        '    cn.Close()
        '    cn = Nothing
        '    cm = Nothing

        'End Try

        'txtLegajo.Text = WCodigo
        'txtDescripcion.Text = Trim(WDescripcionTema)

        '' Nos posicionamos automaticamente en la grilla de Legajos.
        'If 'dgvLegajos.Rows.Count > 0 Then
        '    'dgvLegajos.CurrentCell = 'dgvLegajos.Rows(0).Cells(0)
        '    'dgvLegajos.Focus()
        'End If

    End Sub

    Private Function _TraerResponsableSac(ByVal CodigoResponsable) As String
        Dim desc = ""

        If Val(CodigoResponsable) = 0 Then
            Return ""
        End If

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT Descripcion FROM ResponsableSAC WHERE Codigo = '" & Trim(CodigoResponsable) & "'")
        Dim dr As SqlDataReader

        Try

            cn.ConnectionString = Helper._ConectarA
            cn.Open()
            cm.Connection = cn

            dr = cm.ExecuteReader()

            If dr.HasRows Then

                dr.Read()

                desc = IIf(IsDBNull(dr.Item("Descripcion")), "", Trim(dr.Item("Descripcion")))

            End If

        Catch ex As Exception
            Throw New Exception("Hubo un problema al querer consultar la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

        Return desc
    End Function

    Private Sub btnPantalla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPantalla.Click
        ckTemaActual.Checked = True
        txtDesde.Text = ""
        txtHasta.Text = ""
        GrupoConsulta.Visible = False
        GrupoImpresion.Visible = True
    End Sub

    Private Sub _Imprimir(Optional ByVal _Formula As String = "")
        'With VistaPrevia
        '    .Reporte = New ListadoLegajos
        '    .Formula = _Formula
        '    .Mostrar()
        'End With
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click

        'If Not _DatosValidos() Then : Exit Sub : End If

        'Dim WCurso, WDescripcionCurso, WHorasTema, WTema, WDescripcionTema, WClave
        'Dim cn As SqlConnection = New SqlConnection()
        'Dim cm As SqlCommand = New SqlCommand("")
        'Dim trans As SqlTransaction = Nothing

        'Try
        '    WCurso = ""
        '    WDescripcionCurso = ""
        '    WHorasTema = ""
        '    WTema = ""
        '    WDescripcionTema = ""
        '    WClave = ""

        '    WCurso = Trim(txtLegajo.Text)

        '    cn.ConnectionString = Helper._ConectarA
        '    cn.Open()
        '    cm.Connection = cn
        '    trans = cn.BeginTransaction
        '    cm.Transaction = trans

        '    cm.CommandText = "DELETE FROM " & TABLA_Legajos & " WHERE Curso = '" & WCurso & "'"
        '    cm.ExecuteNonQuery()

        '    For Each row As DataGridViewRow In 'dgvLegajos.Rows
        '        With row
        '            If Not .IsNewRow Then
        '                If Val(.Cells("Curso").Value) > 0 Then

        '                    WHorasTema = Helper.formatonumerico(.Cells("Horas").Value)
        '                    WTema = Trim(.Cells("Curso").Value)
        '                    WDescripcionTema = Trim(.Cells("Descripcion").Value)
        '                    WDescripcionTema = _Left(WDescripcionTema, 90)

        '                    WClave = Helper.ceros(WCurso, 4) & Helper.ceros(WTema, 4)

        '                    cm.CommandText = "INSERT INTO " & TABLA_Legajos & " (Clave, Tema, Descripcion, Curso, Horas) " _
        '                                   & "VALUES ('" & WClave & "', " & WTema & ", '" & WDescripcionTema & "', " & WCurso & ", " & WHorasTema & ")"

        '                    cm.ExecuteNonQuery()
        '                End If
        '            End If
        '        End With
        '    Next

        '    trans.Commit()

        'Catch ex As Exception
        '    If Not IsNothing(trans) Then
        '        trans.Rollback()
        '    End If
        '    MsgBox("Hubo un problema al querer grabar el Curso indicado en la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message, MsgBoxStyle.Critical)
        '    Exit Sub
        'Finally

        '    cn.Close()
        '    cn = Nothing
        '    cm = Nothing

        'End Try

        '' Si llegamos hasta acá estariamos sin problemas. Confirmamos los cambios.

        'MsgBox("Curso Guardado con exito", MsgBoxStyle.Information)
        'btnLimpiar.PerformClick()

        'Me.Close()
        'LegajosPrincipal.btnCargarTodos.PerformClick()

    End Sub

    Private Function _DatosValidos() As Boolean

        'If Trim(txtLegajo.Text) = "" Then
        '    Return False
        'End If

        '' Confirmamos todas las celdas antes de validarlas.
        ''dgvLegajos.CommitEdit(DataGridViewDataErrorContexts.Commit)

        'For Each row As DataGridViewRow In 'dgvLegajos.Rows
        '    With row

        '        ' Eliminamos los renglones nuevos.
        '        If Not .IsNewRow Then

        '            If Trim(.Cells("Curso").Value) <> "" Then
        '                If Trim(.Cells("Descripcion").Value) = "" Then
        '                    MsgBox("Todos los Legajos deben tener una descripción", MsgBoxStyle.Critical)
        '                    Return False
        '                End If
        '                If Val(.Cells("Horas").Value) = 0 Then
        '                    MsgBox("Todos los Legajos deben tener una cantidad de h", MsgBoxStyle.Critical)
        '                    Return False
        '                End If
        '            End If

        '        End If

        '    End With
        'Next

        Return True
    End Function

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        'If Trim(txtLegajo.Text) = "" Then : Exit Sub : End If

        'If MsgBox("¿Esta seguro de querer eliminar este Curso?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
        '    Exit Sub
        'End If

        'Dim cn As SqlConnection = New SqlConnection()
        'Dim cm As SqlCommand = New SqlCommand("DELETE FROM " & TABLA_Legajos & " WHERE Curso = '" & Trim(txtLegajo.Text) & "'")

        'Try

        '    cn.ConnectionString = Helper._ConectarA
        '    cn.Open()
        '    cm.Connection = cn

        '    cm.ExecuteNonQuery()

        'Catch ex As Exception
        '    'Throw New Exception("Hubo un problema al querer consultar la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        '    MsgBox("Hubo un problema al querer eliminar el Curso de la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message, MsgBoxStyle.Critical)
        'Finally

        '    cn.Close()
        '    cn = Nothing
        '    cm = Nothing

        'End Try

        'MsgBox("Curso eliminadado con exito", MsgBoxStyle.Information)
        'btnLimpiar.PerformClick()
        'Me.Close()
        'LegajosPrincipal.btnCargarTodos.PerformClick()

    End Sub

    Private Sub btnPrimerRegistro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrimerRegistro.Click
        If Trim(txtLegajo.Text) = "" Then
            txtLegajo.Text = "1"
        End If

        Dim WCodigo = txtLegajo.Text

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT MIN(Curso) as PrimerRegistro FROM " & TABLA_Legajos & " WHERE Curso > 0")
        Dim dr As SqlDataReader

        Try

            cn.ConnectionString = Helper._ConectarA
            cn.Open()
            cm.Connection = cn

            dr = cm.ExecuteReader()

            If dr.HasRows Then

                dr.Read()

                WCodigo = dr.Item("PrimerRegistro")

            End If

        Catch ex As Exception
            MsgBox("Hubo un problema al querer consultar la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

        txtLegajo.Text = WCodigo

        txtTema_KeyDown(Nothing, New KeyEventArgs(Keys.Enter))

    End Sub

    Private Sub btnUltimoRegistro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUltimoRegistro.Click
        If Trim(txtLegajo.Text) = "" Then
            txtLegajo.Text = "1"
        End If

        Dim WCodigo = txtLegajo.Text

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT MAX(Curso) as UltimoRegistro FROM " & TABLA_Legajos)
        Dim dr As SqlDataReader

        Try

            cn.ConnectionString = Helper._ConectarA
            cn.Open()
            cm.Connection = cn

            dr = cm.ExecuteReader()

            If dr.HasRows Then

                dr.Read()

                WCodigo = dr.Item("UltimoRegistro")

            End If

        Catch ex As Exception
            MsgBox("Hubo un problema al querer consultar la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

        txtLegajo.Text = WCodigo

        txtTema_KeyDown(Nothing, New KeyEventArgs(Keys.Enter))

    End Sub

    Private Sub btnAnteriorRegistro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAnteriorRegistro.Click
        If Trim(txtLegajo.Text) = "" Then
            txtLegajo.Text = "1"
        End If

        Dim WCodigo = txtLegajo.Text

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT TOP 1 Curso as AnteriorRegistro FROM " & TABLA_Legajos & " WHERE Curso < " & Trim(txtLegajo.Text) & " ORDER BY Curso DESC")
        Dim dr As SqlDataReader

        Try

            cn.ConnectionString = Helper._ConectarA
            cn.Open()
            cm.Connection = cn

            dr = cm.ExecuteReader()

            If dr.HasRows Then

                dr.Read()

                WCodigo = dr.Item("AnteriorRegistro")

            End If

        Catch ex As Exception
            MsgBox("Hubo un problema al querer consultar la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

        txtLegajo.Text = WCodigo

        txtTema_KeyDown(Nothing, New KeyEventArgs(Keys.Enter))
    End Sub

    Private Sub btnSiguienteRegistro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSiguienteRegistro.Click

        If Trim(txtLegajo.Text) = "" Then
            txtLegajo.Text = "1"
        End If

        Dim WCodigo = txtLegajo.Text

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT TOP 1 Curso as SiguienteRegistro FROM " & TABLA_Legajos & " WHERE Curso > " & Trim(txtLegajo.Text) & " ORDER BY Curso")
        Dim dr As SqlDataReader

        Try

            cn.ConnectionString = Helper._ConectarA
            cn.Open()
            cm.Connection = cn

            dr = cm.ExecuteReader()

            If dr.HasRows Then

                dr.Read()

                WCodigo = dr.Item("SiguienteRegistro")

            End If

        Catch ex As Exception
            MsgBox("Hubo un problema al querer consultar la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

        txtLegajo.Text = WCodigo

        txtTema_KeyDown(Nothing, New KeyEventArgs(Keys.Enter))
    End Sub

    Private Sub txtDescripcion_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDescripcion.KeyDown, txtFiltroCurso.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txtDescripcion.Text) = "" Then : Exit Sub : End If

            'txtHoras.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtDescripcion.Text = ""
        End If

    End Sub

    'Private Sub txtTema_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtTema.MouseDoubleClick
    '    btnConsulta.PerformClick()
    'End Sub

    'Private Sub ckIntervaloTemas_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckIntervaloTemas.CheckedChanged
    '    If ckIntervaloTemas.Checked Then
    '        txtDesde.Focus()
    '    End If
    'End Sub

    'Private Sub txtDesde_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDesde.KeyDown

    '    If e.KeyData = Keys.Enter Then
    '        If Trim(txtDesde.Text) = "" Then
    '            txtDesde.Text = "0"
    '        End If

    '        txtHasta.Focus()

    '    ElseIf e.KeyData = Keys.Escape Then
    '        txtDesde.Text = ""
    '    End If

    'End Sub

    'Private Sub txtHasta_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtHasta.KeyDown

    '    If e.KeyData = Keys.Enter Then
    '        If Trim(txtHasta.Text) = "" Then
    '            txtHasta.Text = "99999999"
    '        End If

    '        txtDesde.Focus()

    '    ElseIf e.KeyData = Keys.Escape Then
    '        txtHasta.Text = ""
    '    End If

    'End Sub

    'Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

    '    Dim _Formula As String = ""

    '    If ckTemaActual.Checked Then

    '        If Trim(txtTema.Text) = "" Or Val(txtTema.Text) = 0 Then : Exit Sub : End If

    '        _Formula = "{Tema.Curso}=" & Trim(txtTema.Text)

    '    ElseIf ckTodosTemas.Checked Then

    '        _Formula = "{Tema.Curso}>0"

    '    ElseIf ckIntervaloTemas.Checked Then

    '        If Trim(txtDesde.Text) = "" Then
    '            txtDesde.Text = "1"
    '        End If

    '        If Trim(txtHasta.Text) = "" Then
    '            txtHasta.Text = "999999999"
    '        End If

    '        _Formula = "{Tema.Curso} in " & Trim(txtDesde.Text) & " to " & Trim(txtHasta.Text)

    '    End If

    '    _Imprimir(_Formula)

    'End Sub

    'Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
    '    GrupoImpresion.Visible = False
    'End Sub

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

        'With 'dgvLegajos
        '    If .Focused Or .IsCurrentCellInEditMode Then ' Detectamos los ENTER tanto si solo estan en foco o si estan en edición una celda.
        '        .CommitEdit(DataGridViewDataErrorContexts.Commit) ' Guardamos todos los datos que no hayan sido confirmados.

        '        Dim iCol As Integer = .CurrentCell.ColumnIndex
        '        Dim iRow As Integer = .CurrentCell.RowIndex
        '        Dim valor As String = .CurrentCell.Value

        '        ' Limitamos los caracteres permitidos para cada una de las columnas.
        '        Select Case iCol
        '            Case 0
        '                If Not _EsNumeroOControl(keyData) Then
        '                    Return True
        '                End If
        '            Case 2
        '                If Not _EsDecimalOControl(keyData) Then
        '                    Return True
        '                End If
        '            Case Else

        '        End Select

        '        If msg.WParam.ToInt32() = Keys.Enter Then

        '            If valor <> "" Then

        '                Select Case iCol
        '                    Case 0
        '                        If _NroCursoEnUso(valor, iRow) Then
        '                            MsgBox("El Nro de Curso, ya se encuentra utilizado.", MsgBoxStyle.Information)
        '                            Return True
        '                        End If
        '                    Case 2
        '                        .CurrentCell.Value = Helper.formatonumerico(valor)
        '                    Case Else

        '                End Select
        '            Else
        '                Select Case iCol
        '                    Case 0, 1, 2
        '                        Return True
        '                    Case Else

        '                End Select
        '            End If

        '            Select Case iCol
        '                Case 2

        '                    Try
        '                        .CurrentCell = .Rows(iRow + 1).Cells(0)
        '                    Catch ex As Exception
        '                        .Rows.Add()
        '                        .CurrentCell = .Rows(iRow + 1).Cells(0)
        '                    End Try

        '                Case Else
        '                    .CurrentCell = .Rows(iRow).Cells(iCol + 1)
        '            End Select

        '            Return True

        '        ElseIf msg.WParam.ToInt32() = Keys.Escape Then
        '            .Rows(iRow).Cells(iCol).Value = ""

        '            If iCol = 2 Then
        '                .CurrentCell = .Rows(iRow).Cells(iCol - 1)
        '            Else
        '                .CurrentCell = .Rows(iRow).Cells(iCol + 1)
        '            End If

        '            .CurrentCell = .Rows(iRow).Cells(iCol)
        '        End If
        '    End If

        'End With

        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

    Private Function _NroCursoEnUso(ByVal NroCurso As String, ByVal iRow As Integer) As Boolean

        'For Each row As DataGridViewRow In 'dgvLegajos.Rows
        '    With row

        '        If Val(.Cells("Curso").Value) = Val(NroCurso) And .Index <> iRow Then
        '            Return True
        '        End If

        '    End With
        'Next

        Return False

    End Function

    Private Sub dgvLegajos_RowHeaderMouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) 'Handles dgvLegajos.RowHeaderMouseDoubleClick

        'If MsgBox("¿Está seguro de que quiere eliminar el curso indicado?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
        '    Exit Sub
        'End If

        'Dim row As DataGridViewRow = 'dgvLegajos.Rows(e.RowIndex)

        'dgvLegajos.Rows.Remove(row)

    End Sub

    Public Sub _AbrirParaModificar()
        Dim temp = txtLegajo.Text
        Me.Show()
        txtLegajo.Text = temp
        txtTema_KeyDown(Nothing, New KeyEventArgs(Keys.Enter))
    End Sub

    Private Sub CheckBox8_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckDeseableIV.CheckedChanged, ckDeseableVIII.CheckedChanged, ckDeseableVII.CheckedChanged, ckDeseableVI.CheckedChanged, ckDeseableV.CheckedChanged

    End Sub

    Private Sub btnObservaciones_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnObservaciones.Click
        GrupoObservacionesII.Visible = True
    End Sub

    Private Sub txtPerfil_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPerfil.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txtPerfil.Text) = "" Then : Exit Sub : End If

            Try

                If Not Globales._ExisteTarea(txtPerfil.Text) Then
                    Exit Sub
                End If

                _CargarPerfil()

            Catch ex As Exception

            End Try

        ElseIf e.KeyData = Keys.Escape Then
            txtPerfil.Text = ""
        End If

    End Sub

    Private Sub _LimpiarPerfil()

        For Each txt As TextBox In {txtPerfil, txtPerfilDescripcion, txtPerfilVersion, txtSector, txtSectorDescripcion, _
                                    txtTareasI, txtTareasII, txtTareasIII, txtDescriI, txtDescriII, txtDescriIII, _
                                    txtDescriIV, txtDescriV, txtObservaI, txtObservaII, txtObservaIII, txtObservaIV, _
                                    txtObservaV, txtFisica, txtOtrosI, txtOtrosII, txtEquivalenciasI, txtEquivalenciasII, _
                                    txtObservaII1, txtObservaII2, txtObservaII3, txtObservaII4, txtObservaII5}

            txt.Text = ""

        Next

        For Each ck As CheckBox In {ckNecesarioI, ckNecesarioII, ckNecesarioIII, ckNecesarioIV, ckNecesarioV, ckNecesarioVI, _
                                    ckNecesarioVII, ckNecesarioVIII, ckDeseableI, ckDeseableII, ckDeseableIII, ckDeseableIV, _
                                    ckDeseableV, ckDeseableVI, ckDeseableVII, ckDeseableVIII}

            ck.Checked = False

        Next

    End Sub

    Private Sub _CargarPerfil()

        If Trim(txtPerfil.Text) = "" Then : Exit Sub : End If

        Dim WPerfil, WDescripcion, WSector, WDesSector, WTareasI, WTareasII, WTareasIII, WDescriI, WDescriII, WDescriIII, WDescriIV, WDescriV, WObservaI, WObservaII, WObservaIII, WObservaIV, WObservaV, WNecesariaI, WNecesariaII, WNecesariaIII, WNecesariaIV, WNecesariaV, WNecesariaVI, WNecesariaVII, WNecesariaVIII, WDeseableI, WDeseableII, WDeseableIII, WDeseableIV, WDeseableV, WDeseableVI, WDeseableVII, WDeseableVIII, WEquivalenciasI, WEquivalenciasII, WFisica, WOtrosI, WOtrosII, WPerfilVersion

        WPerfil = Trim(txtPerfil.Text)

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT *, Sector.Descripcion as DesSector FROM Tarea, Sector WHERE Tarea.Codigo = '" & WPerfil & "' AND Tarea.Renglon = 1 AND Tarea.Sector = Sector.Codigo ORDER BY Tarea.Codigo, Renglon")
        Dim dr As SqlDataReader


        WDescripcion = ""
        WSector = ""
        WDesSector = ""
        WTareasI = ""
        WTareasII = ""
        WTareasIII = ""
        WDescriI = ""
        WDescriII = ""
        WDescriIII = ""
        WDescriIV = ""
        WDescriV = ""
        WObservaI = ""
        WObservaII = ""
        WObservaIII = ""
        WObservaIV = ""
        WObservaV = ""
        WNecesariaI = ""
        WNecesariaII = ""
        WNecesariaIII = ""
        WNecesariaIV = ""
        WNecesariaV = ""
        WNecesariaVI = ""
        WNecesariaVII = ""
        WNecesariaVIII = ""
        WDeseableI = ""
        WDeseableII = ""
        WDeseableIII = ""
        WDeseableIV = ""
        WDeseableV = ""
        WDeseableVI = ""
        WDeseableVII = ""
        WDeseableVIII = ""
        WEquivalenciasI = ""
        WEquivalenciasII = ""
        WFisica = ""
        WOtrosI = ""
        WOtrosII = ""
        WPerfilVersion = ""

        _LimpiarPerfil()

        Try

            cn.ConnectionString = Helper._ConectarA
            cn.Open()
            cm.Connection = cn

            dr = cm.ExecuteReader()

            If dr.HasRows Then

                dr.Read()

                With dr

                    WDescripcion = IIf(IsDBNull(.Item("Descripcion")), "", .Item("Descripcion"))
                    WSector = IIf(IsDBNull(.Item("Sector")), "", .Item("Sector"))
                    WDesSector = IIf(IsDBNull(.Item("DesSector")), "", .Item("DesSector"))
                    WTareasI = IIf(IsDBNull(.Item("TareasI")), "", .Item("TareasI"))
                    WTareasII = IIf(IsDBNull(.Item("TareasII")), "", .Item("TareasII"))
                    WTareasIII = IIf(IsDBNull(.Item("TareasIII")), "", .Item("TareasIII"))
                    WDescriI = IIf(IsDBNull(.Item("DescriI")), "", .Item("DescriI"))
                    WDescriII = IIf(IsDBNull(.Item("DescriII")), "", .Item("DescriII"))
                    WDescriIII = IIf(IsDBNull(.Item("DescriIII")), "", .Item("DescriIII"))
                    WDescriIV = IIf(IsDBNull(.Item("DescriIV")), "", .Item("DescriIV"))
                    WDescriV = IIf(IsDBNull(.Item("DescriV")), "", .Item("DescriV"))
                    WObservaI = IIf(IsDBNull(.Item("ObservaI")), "", .Item("ObservaI"))
                    WObservaII = IIf(IsDBNull(.Item("ObservaII")), "", .Item("ObservaII"))
                    WObservaIII = IIf(IsDBNull(.Item("ObservaIII")), "", .Item("ObservaIII"))
                    WObservaIV = IIf(IsDBNull(.Item("ObservaIV")), "", .Item("ObservaIV"))
                    WObservaV = IIf(IsDBNull(.Item("ObservaV")), "", .Item("ObservaV"))
                    WNecesariaI = IIf(IsDBNull(.Item("NecesariaI")), "0", .Item("NecesariaI"))
                    WNecesariaII = IIf(IsDBNull(.Item("NecesariaII")), "0", .Item("NecesariaII"))
                    WNecesariaIII = IIf(IsDBNull(.Item("NecesariaIII")), "0", .Item("NecesariaIII"))
                    WNecesariaIV = IIf(IsDBNull(.Item("NecesariaIV")), "0", .Item("NecesariaIV"))
                    WNecesariaV = IIf(IsDBNull(.Item("NecesariaV")), "0", .Item("NecesariaV"))
                    WNecesariaVI = IIf(IsDBNull(.Item("NecesariaVI")), "0", .Item("NecesariaVI"))
                    WNecesariaVII = IIf(IsDBNull(.Item("NecesariaVII")), "0", .Item("NecesariaVII"))
                    WNecesariaVIII = IIf(IsDBNull(.Item("NecesariaVIII")), "0", .Item("NecesariaVIII"))
                    WDeseableI = IIf(IsDBNull(.Item("DeseableI")), "0", .Item("DeseableI"))
                    WDeseableII = IIf(IsDBNull(.Item("DeseableII")), "0", .Item("DeseableII"))
                    WDeseableIII = IIf(IsDBNull(.Item("DeseableIII")), "0", .Item("DeseableIII"))
                    WDeseableIV = IIf(IsDBNull(.Item("DeseableIV")), "0", .Item("DeseableIV"))
                    WDeseableV = IIf(IsDBNull(.Item("DeseableV")), "0", .Item("DeseableV"))
                    WDeseableVI = IIf(IsDBNull(.Item("DeseableVI")), "0", .Item("DeseableVI"))
                    WDeseableVII = IIf(IsDBNull(.Item("DeseableVII")), "0", .Item("DeseableVII"))
                    WDeseableVIII = IIf(IsDBNull(.Item("DeseableVIII")), "0", .Item("DeseableVIII"))
                    WEquivalenciasI = IIf(IsDBNull(.Item("Equivalencias")), "", .Item("Equivalencias"))
                    WEquivalenciasII = IIf(IsDBNull(.Item("EquivalenciasII")), "", .Item("EquivalenciasII"))
                    WFisica = IIf(IsDBNull(.Item("Fisica")), "", .Item("Fisica"))
                    WOtrosI = IIf(IsDBNull(.Item("OtrosI")), "", .Item("OtrosI"))
                    WOtrosII = IIf(IsDBNull(.Item("OtrosII")), "", .Item("OtrosII"))
                    WPerfilVersion = IIf(IsDBNull(.Item("Version")), "", .Item("Version"))

                End With

            End If

        Catch ex As Exception
            Throw New Exception("Hubo un problema al querer consultar la informacion del Perfil desde la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

        txtPerfil.Text = WPerfil
        txtPerfilDescripcion.Text = Trim(WDescripcion)
        txtPerfilVersion.Text = Trim(WPerfilVersion)
        txtSector.Text = Trim(WSector)
        txtSectorDescripcion.Text = Trim(WDesSector)
        txtTareasI.Text = Trim(WTareasI)
        txtTareasII.Text = Trim(WTareasII)
        txtTareasIII.Text = Trim(WTareasIII)

        txtDescriI.Text = Trim(WDescriI)
        txtDescriII.Text = Trim(WDescriII)
        txtDescriIII.Text = Trim(WDescriIII)
        txtDescriIV.Text = Trim(WDescriIV)
        txtDescriV.Text = Trim(WDescriV)

        txtObservaI.Text = Trim(WObservaI)
        txtObservaII.Text = Trim(WObservaII)
        txtObservaIII.Text = Trim(WObservaIII)
        txtObservaIV.Text = Trim(WObservaIV)
        txtObservaV.Text = Trim(WObservaV)

        txtFisica.Text = Trim(WFisica)
        txtOtrosI.Text = Trim(WOtrosI)
        txtOtrosII.Text = Trim(WOtrosII)

        txtEquivalenciasI.Text = Trim(WEquivalenciasI)
        txtEquivalenciasII.Text = Trim(WEquivalenciasII)

        ckNecesarioI.Checked = IIf(Val(WNecesariaI) = 0, False, True)
        ckNecesarioII.Checked = IIf(Val(WNecesariaII) = 0, False, True)
        ckNecesarioIII.Checked = IIf(Val(WNecesariaIII) = 0, False, True)
        ckNecesarioIV.Checked = IIf(Val(WNecesariaIV) = 0, False, True)
        ckNecesarioV.Checked = IIf(Val(WNecesariaV) = 0, False, True)
        ckNecesarioVI.Checked = IIf(Val(WNecesariaVI) = 0, False, True)
        ckNecesarioVII.Checked = IIf(Val(WNecesariaVII) = 0, False, True)
        ckNecesarioVIII.Checked = IIf(Val(WNecesariaVIII) = 0, False, True)

        ckDeseableI.Checked = IIf(Val(WDeseableI) = 0, False, True)
        ckDeseableII.Checked = IIf(Val(WDeseableII) = 0, False, True)
        ckDeseableIII.Checked = IIf(Val(WDeseableIII) = 0, False, True)
        ckDeseableIV.Checked = IIf(Val(WDeseableIV) = 0, False, True)
        ckDeseableV.Checked = IIf(Val(WDeseableV) = 0, False, True)
        ckDeseableVI.Checked = IIf(Val(WDeseableVI) = 0, False, True)
        ckDeseableVII.Checked = IIf(Val(WDeseableVII) = 0, False, True)
        ckDeseableVIII.Checked = IIf(Val(WDeseableVIII) = 0, False, True)

    End Sub

    Private Sub _CargarPerfilSegunVersion()

        If Trim(txtPerfil.Text) = "" Then : Exit Sub : End If

        Dim WPerfil, WDescripcion, WSector, WDesSector, WTareasI, WTareasII, WTareasIII, WDescriI, WDescriII, WDescriIII, WDescriIV, WDescriV, WObservaI, WObservaII, WObservaIII, WObservaIV, WObservaV, WNecesariaI, WNecesariaII, WNecesariaIII, WNecesariaIV, WNecesariaV, WNecesariaVI, WNecesariaVII, WNecesariaVIII, WDeseableI, WDeseableII, WDeseableIII, WDeseableIV, WDeseableV, WDeseableVI, WDeseableVII, WDeseableVIII, WEquivalenciasI, WEquivalenciasII, WFisica, WOtrosI, WOtrosII, WPerfilVersion

        WPerfil = Trim(txtPerfil.Text)

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT *, Sector.Descripcion as DesSector FROM TareaVersion, Sector WHERE TareaVersion.Codigo = '" & WPerfil & "' AND TareaVersion.Version = '" & Trim(txtPerfilVersion.Text) & "' AND TareaVersion.Renglon = 1 AND TareaVersion.Sector = Sector.Codigo ORDER BY TareaVersion.Codigo, Renglon")
        Dim dr As SqlDataReader


        WDescripcion = ""
        WSector = ""
        WDesSector = ""
        WTareasI = ""
        WTareasII = ""
        WTareasIII = ""
        WDescriI = ""
        WDescriII = ""
        WDescriIII = ""
        WDescriIV = ""
        WDescriV = ""
        WObservaI = ""
        WObservaII = ""
        WObservaIII = ""
        WObservaIV = ""
        WObservaV = ""
        WNecesariaI = ""
        WNecesariaII = ""
        WNecesariaIII = ""
        WNecesariaIV = ""
        WNecesariaV = ""
        WNecesariaVI = ""
        WNecesariaVII = ""
        WNecesariaVIII = ""
        WDeseableI = ""
        WDeseableII = ""
        WDeseableIII = ""
        WDeseableIV = ""
        WDeseableV = ""
        WDeseableVI = ""
        WDeseableVII = ""
        WDeseableVIII = ""
        WEquivalenciasI = ""
        WEquivalenciasII = ""
        WFisica = ""
        WOtrosI = ""
        WOtrosII = ""
        WPerfilVersion = ""

        _LimpiarPerfil()

        Try

            cn.ConnectionString = Helper._ConectarA
            cn.Open()
            cm.Connection = cn

            dr = cm.ExecuteReader()

            If dr.HasRows Then

                dr.Read()

                With dr

                    WDescripcion = IIf(IsDBNull(.Item("Descripcion")), "", .Item("Descripcion"))
                    WSector = IIf(IsDBNull(.Item("Sector")), "", .Item("Sector"))
                    WDesSector = IIf(IsDBNull(.Item("DesSector")), "", .Item("DesSector"))
                    WTareasI = IIf(IsDBNull(.Item("TareasI")), "", .Item("TareasI"))
                    WTareasII = IIf(IsDBNull(.Item("TareasII")), "", .Item("TareasII"))
                    WTareasIII = IIf(IsDBNull(.Item("TareasIII")), "", .Item("TareasIII"))
                    WDescriI = IIf(IsDBNull(.Item("DescriI")), "", .Item("DescriI"))
                    WDescriII = IIf(IsDBNull(.Item("DescriII")), "", .Item("DescriII"))
                    WDescriIII = IIf(IsDBNull(.Item("DescriIII")), "", .Item("DescriIII"))
                    WDescriIV = IIf(IsDBNull(.Item("DescriIV")), "", .Item("DescriIV"))
                    WDescriV = IIf(IsDBNull(.Item("DescriV")), "", .Item("DescriV"))
                    WObservaI = IIf(IsDBNull(.Item("ObservaI")), "", .Item("ObservaI"))
                    WObservaII = IIf(IsDBNull(.Item("ObservaII")), "", .Item("ObservaII"))
                    WObservaIII = IIf(IsDBNull(.Item("ObservaIII")), "", .Item("ObservaIII"))
                    WObservaIV = IIf(IsDBNull(.Item("ObservaIV")), "", .Item("ObservaIV"))
                    WObservaV = IIf(IsDBNull(.Item("ObservaV")), "", .Item("ObservaV"))
                    WNecesariaI = IIf(IsDBNull(.Item("NecesariaI")), "0", .Item("NecesariaI"))
                    WNecesariaII = IIf(IsDBNull(.Item("NecesariaII")), "0", .Item("NecesariaII"))
                    WNecesariaIII = IIf(IsDBNull(.Item("NecesariaIII")), "0", .Item("NecesariaIII"))
                    WNecesariaIV = IIf(IsDBNull(.Item("NecesariaIV")), "0", .Item("NecesariaIV"))
                    WNecesariaV = IIf(IsDBNull(.Item("NecesariaV")), "0", .Item("NecesariaV"))
                    WNecesariaVI = IIf(IsDBNull(.Item("NecesariaVI")), "0", .Item("NecesariaVI"))
                    WNecesariaVII = IIf(IsDBNull(.Item("NecesariaVII")), "0", .Item("NecesariaVII"))
                    WNecesariaVIII = IIf(IsDBNull(.Item("NecesariaVIII")), "0", .Item("NecesariaVIII"))
                    WDeseableI = IIf(IsDBNull(.Item("DeseableI")), "0", .Item("DeseableI"))
                    WDeseableII = IIf(IsDBNull(.Item("DeseableII")), "0", .Item("DeseableII"))
                    WDeseableIII = IIf(IsDBNull(.Item("DeseableIII")), "0", .Item("DeseableIII"))
                    WDeseableIV = IIf(IsDBNull(.Item("DeseableIV")), "0", .Item("DeseableIV"))
                    WDeseableV = IIf(IsDBNull(.Item("DeseableV")), "0", .Item("DeseableV"))
                    WDeseableVI = IIf(IsDBNull(.Item("DeseableVI")), "0", .Item("DeseableVI"))
                    WDeseableVII = IIf(IsDBNull(.Item("DeseableVII")), "0", .Item("DeseableVII"))
                    WDeseableVIII = IIf(IsDBNull(.Item("DeseableVIII")), "0", .Item("DeseableVIII"))
                    WEquivalenciasI = IIf(IsDBNull(.Item("Equivalencias")), "", .Item("Equivalencias"))
                    WEquivalenciasII = IIf(IsDBNull(.Item("EquivalenciasII")), "", .Item("EquivalenciasII"))
                    WFisica = IIf(IsDBNull(.Item("Fisica")), "", .Item("Fisica"))
                    WOtrosI = IIf(IsDBNull(.Item("OtrosI")), "", .Item("OtrosI"))
                    WOtrosII = IIf(IsDBNull(.Item("OtrosII")), "", .Item("OtrosII"))
                    WPerfilVersion = IIf(IsDBNull(.Item("Version")), "", .Item("Version"))

                End With

            End If

        Catch ex As Exception
            Throw New Exception("Hubo un problema al querer consultar la informacion del Perfil desde la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

        txtPerfil.Text = WPerfil
        txtPerfilDescripcion.Text = Trim(WDescripcion)
        txtPerfilVersion.Text = Trim(WPerfilVersion)
        txtSector.Text = Trim(WSector)
        txtSectorDescripcion.Text = Trim(WDesSector)
        txtTareasI.Text = Trim(WTareasI)
        txtTareasII.Text = Trim(WTareasII)
        txtTareasIII.Text = Trim(WTareasIII)

        txtDescriI.Text = Trim(WDescriI)
        txtDescriII.Text = Trim(WDescriII)
        txtDescriIII.Text = Trim(WDescriIII)
        txtDescriIV.Text = Trim(WDescriIV)
        txtDescriV.Text = Trim(WDescriV)

        txtObservaI.Text = Trim(WObservaI)
        txtObservaII.Text = Trim(WObservaII)
        txtObservaIII.Text = Trim(WObservaIII)
        txtObservaIV.Text = Trim(WObservaIV)
        txtObservaV.Text = Trim(WObservaV)

        txtFisica.Text = Trim(WFisica)
        txtOtrosI.Text = Trim(WOtrosI)
        txtOtrosII.Text = Trim(WOtrosII)

        txtEquivalenciasI.Text = Trim(WEquivalenciasI)
        txtEquivalenciasII.Text = Trim(WEquivalenciasII)

        ckNecesarioI.Checked = IIf(Val(WNecesariaI) = 0, False, True)
        ckNecesarioII.Checked = IIf(Val(WNecesariaII) = 0, False, True)
        ckNecesarioIII.Checked = IIf(Val(WNecesariaIII) = 0, False, True)
        ckNecesarioIV.Checked = IIf(Val(WNecesariaIV) = 0, False, True)
        ckNecesarioV.Checked = IIf(Val(WNecesariaV) = 0, False, True)
        ckNecesarioVI.Checked = IIf(Val(WNecesariaVI) = 0, False, True)
        ckNecesarioVII.Checked = IIf(Val(WNecesariaVII) = 0, False, True)
        ckNecesarioVIII.Checked = IIf(Val(WNecesariaVIII) = 0, False, True)

        ckDeseableI.Checked = IIf(Val(WDeseableI) = 0, False, True)
        ckDeseableII.Checked = IIf(Val(WDeseableII) = 0, False, True)
        ckDeseableIII.Checked = IIf(Val(WDeseableIII) = 0, False, True)
        ckDeseableIV.Checked = IIf(Val(WDeseableIV) = 0, False, True)
        ckDeseableV.Checked = IIf(Val(WDeseableV) = 0, False, True)
        ckDeseableVI.Checked = IIf(Val(WDeseableVI) = 0, False, True)
        ckDeseableVII.Checked = IIf(Val(WDeseableVII) = 0, False, True)
        ckDeseableVIII.Checked = IIf(Val(WDeseableVIII) = 0, False, True)

    End Sub

    Private Sub txtLegajo_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtLegajo.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txtLegajo.Text) = "" Then : Exit Sub : End If

            _traerLegajo()

            txtLegajo.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtLegajo.Text = ""
        End If

    End Sub

    Private Sub _traerLegajo()

        If Trim(txtLegajo.Text) = "" Then : Exit Sub : End If

        Dim WLegajo = Trim(txtLegajo.Text)
        Dim WFechaVersion, WPerfilVersion, WVersion, WDescripcion, WFechaEgreso, WFIngreso, WPerfil, WEstadoI, WEstadoII, WEstadoIII, WEstadoIV, WEstadoV, WEstadoVI, WEstadoVII, WEstadoVIII, WEstadoIX, WEstadoX, WEstaI, WEstaII, WEstaIII, WEstaIV, WEstaV, WEstaVI, WEstaVII, WEstaVIII, WEstaIX, WEstaX
        Dim WObservaI1, WObservaI2, WObservaI3, WObservaI4, WObservaI5, WObservaII1, WObservaII2, WObservaII3, WObservaII4, WObservaII5, WActualizado, WTareaVersion

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT *, Tarea.Version as TareaVersion FROM Legajo, Tarea WHERE Legajo.Codigo = '" & WLegajo & "' AND Legajo.Perfil = Tarea.Codigo ")
        Dim dr As SqlDataReader

        WVersion = ""
        WPerfilVersion = ""
        WDescripcion = ""
        WFechaVersion = ""
        WVersion = ""
        WFIngreso = ""
        WFechaEgreso = ""
        WPerfil = ""
        WEstadoI = ""
        WEstadoII = ""
        WEstadoIII = ""
        WEstadoIV = ""
        WEstadoV = ""
        WEstadoVI = ""
        WEstadoVII = ""
        WEstadoVIII = ""
        WEstadoIX = ""
        WEstadoX = ""
        WEstaI = ""
        WEstaII = ""
        WEstaIII = ""
        WEstaIV = ""
        WEstaV = ""
        WEstaVI = ""
        WEstaVII = ""
        WEstaVIII = ""
        WEstaIX = ""
        WEstaX = ""

        WObservaI1 = ""
        WObservaI2 = ""
        WObservaI3 = ""
        WObservaI4 = ""
        WObservaI5 = ""
        WObservaII1 = ""
        WObservaII2 = ""
        WObservaII3 = ""
        WObservaII4 = ""
        WObservaII5 = ""

        WActualizado = ""
        WTareaVersion = ""

        _LimpiarTodo()

        Try

            cn.ConnectionString = Helper._ConectarA
            cn.Open()
            cm.Connection = cn

            dr = cm.ExecuteReader()

            If dr.HasRows Then

                With dr
                    .Read()

                    WVersion = IIf(IsDBNull(.Item("Version")), "", .Item("Version"))
                    WDescripcion = IIf(IsDBNull(.Item("Descripcion")), "", .Item("Descripcion"))
                    WFechaVersion = IIf(IsDBNull(.Item("FechaVersion")), "", .Item("FechaVersion"))
                    WVersion = IIf(IsDBNull(.Item("Version")), "", .Item("Version"))
                    WFIngreso = IIf(IsDBNull(.Item("FIngreso")), "", .Item("FIngreso"))
                    WFechaEgreso = IIf(IsDBNull(.Item("Fegreso")), "00/00/0000", .Item("Fegreso"))
                    WPerfil = IIf(IsDBNull(.Item("Perfil")), "0", .Item("Perfil"))
                    WEstadoI = IIf(IsDBNull(.Item("EstadoI")), "", .Item("EstadoI"))
                    WEstadoII = IIf(IsDBNull(.Item("EstadoII")), "", .Item("EstadoII"))
                    WEstadoIII = IIf(IsDBNull(.Item("EstadoIII")), "", .Item("EstadoIII"))
                    WEstadoIV = IIf(IsDBNull(.Item("EstadoIV")), "", .Item("EstadoIV"))
                    WEstadoV = IIf(IsDBNull(.Item("EstadoV")), "", .Item("EstadoV"))
                    WEstadoVI = IIf(IsDBNull(.Item("EstadoVI")), "", .Item("EstadoVI"))
                    WEstadoVII = IIf(IsDBNull(.Item("EstadoVII")), "", .Item("EstadoVII"))
                    WEstadoVIII = IIf(IsDBNull(.Item("EstadoVIII")), "", .Item("EstadoVIII"))
                    WEstadoIX = IIf(IsDBNull(.Item("EstadoIX")), "", .Item("EstadoIX"))
                    WEstadoX = IIf(IsDBNull(.Item("EstadoX")), "", .Item("EstadoX"))
                    WEstaI = IIf(IsDBNull(.Item("EstaI")), "", .Item("EstaI"))
                    WEstaII = IIf(IsDBNull(.Item("EstaII")), "", .Item("EstaII"))
                    WEstaIII = IIf(IsDBNull(.Item("EstaIII")), "", .Item("EstaIII"))
                    WEstaIV = IIf(IsDBNull(.Item("EstaIV")), "", .Item("EstaIV"))
                    WEstaV = IIf(IsDBNull(.Item("EstaV")), "", .Item("EstaV"))
                    WEstaVI = IIf(IsDBNull(.Item("EstaVI")), "", .Item("EstaVI"))
                    WEstaVII = IIf(IsDBNull(.Item("EstaVII")), "", .Item("EstaVII"))
                    WEstaVIII = IIf(IsDBNull(.Item("EstaVIII")), "", .Item("EstaVIII"))
                    WEstaIX = IIf(IsDBNull(.Item("EstaIX")), "", .Item("EstaIX"))
                    WEstaX = IIf(IsDBNull(.Item("EstaX")), "", .Item("EstaX"))

                    WObservaI1 = IIf(IsDBNull(.Item("ObservaI1")), "", .Item("ObservaI1"))
                    WObservaI2 = IIf(IsDBNull(.Item("ObservaI2")), "", .Item("ObservaI2"))
                    WObservaI3 = IIf(IsDBNull(.Item("ObservaI3")), "", .Item("ObservaI3"))
                    WObservaI4 = IIf(IsDBNull(.Item("ObservaI4")), "", .Item("ObservaI4"))
                    WObservaI5 = IIf(IsDBNull(.Item("ObservaI5")), "", .Item("ObservaI5"))
                    WObservaII1 = IIf(IsDBNull(.Item("ObservaII1")), "", .Item("ObservaII1"))
                    WObservaII2 = IIf(IsDBNull(.Item("ObservaII2")), "", .Item("ObservaII2"))
                    WObservaII3 = IIf(IsDBNull(.Item("ObservaII3")), "", .Item("ObservaII3"))
                    WObservaII4 = IIf(IsDBNull(.Item("ObservaII4")), "", .Item("ObservaII4"))
                    WObservaII5 = IIf(IsDBNull(.Item("ObservaII5")), "", .Item("ObservaII5"))
                    WActualizado = IIf(IsDBNull(.Item("Actualizado")), "", .Item("Actualizado"))
                    WTareaVersion = IIf(IsDBNull(.Item("TareaVersion")), "0", .Item("TareaVersion"))

                End With

            End If

        Catch ex As Exception
            Throw New Exception("Hubo un problema al querer consultar el legajo en la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

        txtLegajo.Text = Trim(WLegajo)
        txtNroVersion.Text = Trim(WVersion)
        txtDescripcion.Text = Trim(WDescripcion)
        txtFechaVersion.Text = Trim(WFechaVersion)
        txtFechaIngreso.Text = Trim(WFIngreso)
        txtFechaEgreso.Text = Trim(WFechaEgreso)
        txtPerfil.Text = Trim(WPerfil)
        txtEstadoI.Text = Trim(WEstadoI)
        txtEstadoII.Text = Trim(WEstadoII)
        txtEstadoIII.Text = Trim(WEstadoIII)
        txtEstadoIV.Text = Trim(WEstadoIV)
        txtEstadoV.Text = Trim(WEstadoV)
        txtEstadoVI.Text = Trim(WEstadoVI)
        txtEstadoVII.Text = Trim(WEstadoVII)
        txtEstadoVIII.Text = Trim(WEstadoVIII)
        txtEstadoIX.Text = Trim(WEstadoIX)
        txtEstadoX.Text = Trim(WEstadoX)
        cmbEstaI.SelectedIndex = Val(WEstaI)
        cmbEstaII.SelectedIndex = Val(WEstaII)
        cmbEstaIII.SelectedIndex = Val(WEstaIII)
        cmbEstaIV.SelectedIndex = Val(WEstaIV)
        cmbEstaV.SelectedIndex = Val(WEstaV)
        cmbEstaVI.SelectedIndex = Val(WEstaVI)
        cmbEstaVII.SelectedIndex = Val(WEstaVII)
        cmbEstaVIII.SelectedIndex = Val(WEstaVIII)
        cmbEstaIX.selectedindex = Val(WEstaIX)
        cmbEstaX.SelectedIndex = Val(WEstaX)

        txtObservaI1.Text = Trim(WObservaI1)
        txtObservaI2.Text = Trim(WObservaI2)
        txtObservaI3.Text = Trim(WObservaI3)
        txtObservaI4.Text = Trim(WObservaI4)
        txtObservaI5.Text = Trim(WObservaI5)
        txtObservaII1.Text = Trim(WObservaII1)
        txtObservaII2.Text = Trim(WObservaII2)
        txtObservaII3.Text = Trim(WObservaII3)
        txtObservaII4.Text = Trim(WObservaII4)
        txtObservaII5.Text = Trim(WObservaII5)

        If UCase(WActualizado) = "N" Then
            AtencionNoActualizado.Visible = True
            MsgBox("ATENCION: SE ACTUALIZÓ LA VERSIÓN DEL PERFIL, PERO AUN NO ASI LA CALIFICACIÓN", MsgBoxStyle.Information)
        Else
            AtencionNoActualizado.Visible = False
        End If

        ' Ahora falta traer los datos del perfil.
        If Val(WTareaVersion) = Val(WPerfilVersion) Or Val(WTareaVersion) = 0 Or Val(WPerfilVersion) = 0 Then

            txtPerfilVersion.Text = WTareaVersion

            _CargarPerfil()


            If Val(WPerfil) <> 0 Then
                _CargarConocimientos()
            End If

        Else

            txtPerfilVersion.Text = WPerfilVersion

            _CargarPerfilSegunVersion()


            If Val(WPerfil) <> 0 Then
                _CargarConocimientosSegunVersion()
            End If

        End If

        '
        ' CARGAMOS LOS CURSOS REALIZADOS.
        '
        _CargarCursosRealizados()


    End Sub

    Private Sub _AsignarCurso(ByVal dt As DataTable)
        If IsNothing(dt) Then : Exit Sub : End If

        Dim WCurso, WDescriCurso, WRealizado, WAnio, WObservaciones, WHoras, WRowIndex

        For Each row As DataRow In dt.Rows

            With row

                WCurso = .Item("Curso")
                WDescriCurso = .Item("Descripcion")
                WRealizado = .Item("Realizado")
                WAnio = .Item("Ano")
                WObservaciones = .Item("ObservacionesII")
                WHoras = .Item("Horas")

            End With

            WRowIndex = dgvCursosRealizados.Rows.Add

            With dgvCursosRealizados.Rows(WRowIndex)

                .Cells("TemaRealizado").Value = Trim(WCurso)
                .Cells("DescripcionRealizado").Value = Trim(WDescriCurso)
                .Cells("Realizado").Value = Trim(WRealizado)
                .Cells("HorasRealizado").Value = Helper.formatonumerico(WHoras)
                .Cells("AnioRealizado").Value = Trim(WAnio)
                .Cells("ObservacionesRealizado").Value = Trim(WObservaciones)

            End With
        Next

    End Sub

    Private Sub _CargarCursosRealizados()

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT cr.Curso, c.Descripcion, cr.Horas, cr.Realizado, cr.Ano, cr.ObservacionesII FROM Cronograma as cr, Curso as c WHERE cr.Legajo = '" & Trim(txtLegajo.Text) & "' AND cr.Realizado <> 0 AND cr.Curso = c.Codigo")
        Dim dr As SqlDataReader

        Try
            
            dgvCursosRealizados.Rows.Clear()
            DT_Cursos.Rows.Clear()

            cn.ConnectionString = Helper._ConectarA
            cn.Open()
            cm.Connection = cn

            dr = cm.ExecuteReader()

            If dr.HasRows Then

                DT_Cursos.Load(dr)

                _AsignarCurso(DT_Cursos)
                
            End If

        Catch ex As Exception
            Throw New Exception("Hubo un problema al querer consultar los cursos realizados desde la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

    End Sub

    Private Sub _CargarConocimientosSegunVersion()
        If Trim(txtPerfil.Text) = "" Then : Exit Sub : End If

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT Legajo.Curso, Legajo.EstaCurso as EstaCurso, TareaVersion.NecesariaCurso, TareaVersion.DeseableCurso, Curso.Descripcion FROM Legajo, TareaVersion, Curso WHERE Legajo.Codigo = '" & Trim(txtLegajo.Text) & "' AND TareaVersion.Version = '" & Val(txtPerfilVersion.Text) & "' AND Legajo.Curso = Tarea.Curso AND Legajo.Perfil = TareaVersion.Codigo AND Legajo.Curso = Curso.Codigo ORDER BY Legajo.Curso")
        Dim dr As SqlDataReader
        Dim WRowIndex, WEstaCurso, WCurso, WDescriCurso, WNecesario, WDeseable
        Dim WEstados() = {"", "Exede", "Cumple", "Reforzar", "En Entrenamiento", "No Cumple", "No Aplica", "No Evalua", "Cumple Act."}

        Try
            dgvConocimientos.Rows.Clear()

            WRowIndex = 0

            WEstaCurso = 0
            WCurso = ""
            WDescriCurso = ""
            WNecesario = ""
            WDeseable = ""

            cn.ConnectionString = Helper._ConectarA
            cn.Open()
            cm.Connection = cn

            dr = cm.ExecuteReader()

            If dr.HasRows Then

                Do While dr.Read()

                    WEstaCurso = 0
                    WCurso = ""
                    WDescriCurso = ""
                    WNecesario = ""
                    WDeseable = ""

                    WCurso = IIf(IsDBNull(dr.Item("Curso")), "", dr.Item("Curso"))
                    WDescriCurso = IIf(IsDBNull(dr.Item("Descripcion")), "", dr.Item("Descripcion"))
                    WNecesario = IIf(IsDBNull(dr.Item("NecesariaCurso")), "", dr.Item("NecesariaCurso"))
                    WDeseable = IIf(IsDBNull(dr.Item("DeseableCurso")), "", dr.Item("DeseableCurso"))
                    WEstaCurso = IIf(IsDBNull(dr.Item("EstaCurso")), "", dr.Item("EstaCurso"))

                    WRowIndex = dgvConocimientos.Rows.Add

                    With dgvConocimientos.Rows(WRowIndex)

                        .Cells("Tema").Value = Trim(WCurso)
                        .Cells("DescripcionTema").Value = Trim(WDescriCurso)
                        .Cells("EstadoTema").Value = WEstados(Val(WEstaCurso))

                        If UCase(Trim(WNecesario)) = "X" Then
                            .Cells("TipoNecesidad").Value = "Necesario"
                        ElseIf UCase(Trim(WDeseable)) = "X" Then
                            .Cells("TipoNecesidad").Value = "Deseable"
                        Else
                            .Cells("TipoNecesidad").Value = ""
                        End If

                    End With

                Loop

            End If

        Catch ex As Exception
            Throw New Exception("Hubo un problema al querer consultar la informacionde los conocimientos desde la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

    End Sub

    Private Sub _CargarConocimientos()
        If Trim(txtPerfil.Text) = "" Then : Exit Sub : End If

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT Legajo.Curso, Legajo.EstaCurso as EstaCurso, Tarea.NecesariaCurso, Tarea.DeseableCurso, Curso.Descripcion FROM Legajo, Tarea, Curso WHERE Legajo.Codigo = '" & Trim(txtLegajo.Text) & "' AND Legajo.Curso = Tarea.Curso AND Legajo.Perfil = Tarea.Codigo AND Legajo.Curso = Curso.Codigo ORDER BY Legajo.Curso")
        Dim dr As SqlDataReader
        Dim WRowIndex, WEstaCurso, WCurso, WDescriCurso, WNecesario, WDeseable
        Dim WEstados() = {"", "Exede", "Cumple", "Reforzar", "En Entrenamiento", "No Cumple", "No Aplica", "No Evalua", "Cumple Act."}

        Try
            dgvConocimientos.Rows.Clear()

            WRowIndex = 0

            WEstaCurso = 0
            WCurso = ""
            WDescriCurso = ""
            WNecesario = ""
            WDeseable = ""

            cn.ConnectionString = Helper._ConectarA
            cn.Open()
            cm.Connection = cn

            dr = cm.ExecuteReader()

            If dr.HasRows Then


                Do While dr.Read()

                    WEstaCurso = 0
                    WCurso = ""
                    WDescriCurso = ""
                    WNecesario = ""
                    WDeseable = ""

                    WCurso = IIf(IsDBNull(dr.Item("Curso")), "", dr.Item("Curso"))
                    WDescriCurso = IIf(IsDBNull(dr.Item("Descripcion")), "", dr.Item("Descripcion"))
                    WNecesario = IIf(IsDBNull(dr.Item("NecesariaCurso")), "", dr.Item("NecesariaCurso"))
                    WDeseable = IIf(IsDBNull(dr.Item("DeseableCurso")), "", dr.Item("DeseableCurso"))
                    WEstaCurso = IIf(IsDBNull(dr.Item("EstaCurso")), "", dr.Item("EstaCurso"))

                    WRowIndex = dgvConocimientos.Rows.Add

                    With dgvConocimientos.Rows(WRowIndex)

                        .Cells("Tema").Value = Trim(WCurso)
                        .Cells("DescripcionTema").Value = Trim(WDescriCurso)
                        .Cells("EstadoTema").Value = WEstados(Val(WEstaCurso))

                        If UCase(Trim(WNecesario)) = "X" Then
                            .Cells("TipoNecesidad").Value = "Necesario"
                        ElseIf UCase(Trim(WDeseable)) = "X" Then
                            .Cells("TipoNecesidad").Value = "Deseable"
                        Else
                            .Cells("TipoNecesidad").Value = ""
                        End If

                    End With

                Loop

            End If

        Catch ex As Exception
            Throw New Exception("Hubo un problema al querer consultar la informacionde los conocimientos desde la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

    End Sub

    Private Sub _LimpiarLegajoInfo()
        For Each txt As TextBox In {txtLegajo, txtDescripcion, txtNroVersion, txtObservaII1, txtObservaII2, _
                                    txtObservaII3, txtObservaII4, txtEstadoI, txtEstadoII, txtEstadoIII, txtEstadoIV, txtEstadoV, txtEstadoVI, txtEstadoVII, _
                                    txtEstadoVIII, txtEstadoIX, txtEstadoX}
            txt.Text = ""
        Next

        For Each txt As MaskedTextBox In {txtFechaEgreso, txtFechaIngreso, txtFechaVersion}
            txt.Clear()
        Next
    End Sub

    Private Sub _LimpiarTodo()
        _LimpiarLegajoInfo()
        _LimpiarPerfil()
    End Sub

    Private Sub btnCerrarObservacionesI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrarObservacionesI.Click
        GrupoObservacionesI.Visible = False
    End Sub

    Private Sub btnCerrarObservaciones_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrarObservaciones.Click
        GrupoObservacionesII.Visible = False
    End Sub

    Private Sub cmbFiltroCurso_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbFiltroCurso.SelectedIndexChanged

        Select Case cmbFiltroCurso.SelectedIndex
            Case 1
                GrupoDesdeHasta.Visible = False
                txtFiltroCurso.Text = ""
                txtFiltroCurso.Focus()
            Case 2, 3
                GrupoDesdeHasta.Visible = True
                cmbDesdeCurso.Focus()
                cmbDesdeCurso.DroppedDown = True
            Case Else
                Exit Sub
        End Select

    End Sub

    Private Sub cmbDesdeCurso_DropDownClosed(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbDesdeCurso.DropDownClosed
        cmbHastaCurso.Focus()
        cmbHastaCurso.DroppedDown = True
    End Sub

    Private Sub cmbHastaCurso_DropDownClosed(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbHastaCurso.DropDownClosed
        If cmbHastaCurso.SelectedValue Is Nothing OrElse cmbDesdeCurso.SelectedValue Is Nothing Then : Exit Sub : End If
        If cmbHastaCurso.SelectedValue < cmbDesdeCurso.SelectedValue Then
            MsgBox("El valor debe ser posterior al valor 'Desde'")
            cmbHastaCurso.Focus()
            cmbHastaCurso.DroppedDown = True
        End If
    End Sub
End Class