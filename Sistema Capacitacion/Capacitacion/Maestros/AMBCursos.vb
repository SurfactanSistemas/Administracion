Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine

Public Class AMBCursos
    Private Const TABLA_CURSOS = "Tema"
    Private Const TABLA_TEMAS = "Curso"

    Private WClavesCursos(1000) As String

    Private Sub AMBCursos_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        btnLimpiar.PerformClick()
    End Sub

    Private Function _TraerProximoCodigoTarea() As String

        Dim WUltimo = "0"
        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT MAX(Curso) as Ultimo FROM " & TABLA_CURSOS)
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

        ' Limpiamos todos los campos del tipo Texto.
        For Each txt As TextBox In {txtTema, txtDescripcion, txtAyuda, txtDesde, txtHasta}
            txt.Text = ""
        Next

        GrupoConsulta.Visible = False
        GrupoImpresion.Visible = False

        ckTemaActual.Checked = True

        dgvCursos.Rows.Clear()

        dgvCursos.Rows.Add()

        txtTema.Focus()
    End Sub

    Private Sub NumerosConComas(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Not Char.IsNumber(e.KeyChar) And Not Char.IsControl(e.KeyChar) And Not (CChar(".")) = e.KeyChar Then
            e.Handled = True
        End If
    End Sub

    Private Sub SoloNumero(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTema.KeyPress, txtHasta.KeyPress, txtDesde.KeyPress
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
                            WClavesCursos(WRenglon) = WCodigo
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
        txtTema.Focus()
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

        txtTema.Text = WClavesCursos(lstConsulta.SelectedIndex)

        txtTema_KeyDown(Nothing, New KeyEventArgs(Keys.Enter))

        btnCerrarConsulta.PerformClick()
    End Sub

    Private Sub AMBCursos_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        txtTema.Focus()
    End Sub

    Private Sub txtTema_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTema.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txtTema.Text) = "" Then
                btnConsulta.PerformClick()
                Exit Sub
            End If

            Try
                _TraerTarea(txtTema.Text)
                Exit Sub
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical)
                Exit Sub
            End Try

            txtDescripcion.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtTema.Text = ""
        End If

    End Sub

    Private Sub _TraerTarea(ByVal codigo As String)
        codigo = Trim(codigo)

        If codigo = "" Then : Exit Sub : End If

        btnLimpiar.PerformClick()

        Dim WCodigo, WDescripcionTema, WCurso, WDescripcionCurso, WHorasCurso, WRenglon
        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT t.Descripcion as DescriTema FROM " & TABLA_TEMAS & " as t WHERE t.Codigo = '" & codigo & "'")

        Dim dr As SqlDataReader

        Try
            WCodigo = codigo
            WDescripcionTema = ""
            WCurso = ""
            WDescripcionCurso = ""
            WHorasCurso = ""
            WRenglon = 0

            cn.ConnectionString = Helper._ConectarA
            cn.Open()
            cm.Connection = cn

            dr = cm.ExecuteReader()

            If dr.HasRows Then
                dr.Read()
                WDescripcionTema = IIf(IsDBNull(dr.Item("DescriTema")), "", dr.Item("DescriTema"))

                dr.Close()

                ' Buscamos los cursos que se tengan asociados.
                cm.CommandText = "SELECT c.Tema as Curso, c.Descripcion as DescriCurso, c.Horas FROM " & TABLA_CURSOS & " as c WHERE c.Curso = '" & codigo & "' ORDER BY c.Tema"

                dr = cm.ExecuteReader

                If dr.HasRows Then
                    While dr.Read()

                        With dr

                            WCurso = IIf(IsDBNull(.Item("Curso")), "", .Item("Curso"))
                            WDescripcionCurso = IIf(IsDBNull(.Item("DescriCurso")), "", .Item("DescriCurso"))
                            WHorasCurso = IIf(IsDBNull(.Item("Horas")), "", .Item("Horas"))

                        End With

                        With dgvCursos.Rows(WRenglon)
                            .Cells("Curso").Value = WCurso
                            .Cells("Descripcion").Value = WDescripcionCurso
                            .Cells("Horas").Value = Helper.formatonumerico(WHorasCurso)
                            WRenglon = dgvCursos.Rows.Add
                        End With
                    End While
                End If

            End If

        Catch ex As Exception
            Throw New Exception("Hubo un problema al querer consultar la información del Tarea indicado." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

        txtTema.Text = WCodigo
        txtDescripcion.Text = Trim(WDescripcionTema)

        ' Nos posicionamos automaticamente en la grilla de cursos.
        If dgvCursos.Rows.Count > 0 Then
            dgvCursos.CurrentCell = dgvCursos.Rows(0).Cells(0)
            dgvCursos.Focus()
        End If

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
        With VistaPrevia
            .Reporte = New ListadoCursos
            .Formula = _Formula
            .Mostrar()
        End With
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click

        If Not _DatosValidos() Then : Exit Sub : End If

        Dim WCurso, WDescripcionCurso, WHorasTema, WTema, WDescripcionTema, WClave
        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("")
        Dim trans As SqlTransaction = Nothing

        Try
            WCurso = ""
            WDescripcionCurso = ""
            WHorasTema = ""
            WTema = ""
            WDescripcionTema = ""
            WClave = ""

            WCurso = Trim(txtTema.Text)

            cn.ConnectionString = Helper._ConectarA
            cn.Open()
            cm.Connection = cn
            trans = cn.BeginTransaction
            cm.Transaction = trans

            cm.CommandText = "DELETE FROM " & TABLA_CURSOS & " WHERE Curso = '" & WCurso & "'"
            cm.ExecuteNonQuery()

            For Each row As DataGridViewRow In dgvCursos.Rows
                With row
                    If Not .IsNewRow Then
                        If Val(.Cells("Curso").Value) > 0 Then

                            WHorasTema = Helper.formatonumerico(.Cells("Horas").Value)
                            WTema = Trim(.Cells("Curso").Value)
                            WDescripcionTema = Trim(.Cells("Descripcion").Value)
                            WDescripcionTema = _Left(WDescripcionTema, 90)

                            WClave = Helper.ceros(WCurso, 4) & Helper.ceros(WTema, 4)

                            cm.CommandText = "INSERT INTO " & TABLA_CURSOS & " (Clave, Tema, Descripcion, Curso, Horas) " _
                                           & "VALUES ('" & WClave & "', " & WTema & ", '" & WDescripcionTema & "', " & WCurso & ", " & WHorasTema & ")"

                            cm.ExecuteNonQuery()
                        End If
                    End If
                End With
            Next

            trans.Commit()

        Catch ex As Exception
            If Not IsNothing(trans) Then
                trans.Rollback()
            End If
            MsgBox("Hubo un problema al querer grabar el Curso indicado en la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        Finally

            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

        ' Si llegamos hasta acá estariamos sin problemas. Confirmamos los cambios.

        MsgBox("Curso Guardado con exito", MsgBoxStyle.Information)
        btnLimpiar.PerformClick()

        Me.Close()
        CursosPrincipal.btnCargarTodos.PerformClick()

    End Sub

    Private Function _DatosValidos() As Boolean

        If Trim(txtTema.Text) = "" Then
            Return False
        End If

        ' Confirmamos todas las celdas antes de validarlas.
        dgvCursos.CommitEdit(DataGridViewDataErrorContexts.Commit)

        For Each row As DataGridViewRow In dgvCursos.Rows
            With row

                ' Eliminamos los renglones nuevos.
                If Not .IsNewRow Then

                    If Trim(.Cells("Curso").Value) <> "" Then
                        If Trim(.Cells("Descripcion").Value) = "" Then
                            MsgBox("Todos los cursos deben tener una descripción", MsgBoxStyle.Critical)
                            Return False
                        End If
                        If Val(.Cells("Horas").Value) = 0 Then
                            MsgBox("Todos los cursos deben tener una cantidad de h", MsgBoxStyle.Critical)
                            Return False
                        End If
                    End If

                End If

            End With
        Next

        Return True
    End Function

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        If Trim(txtTema.Text) = "" Then : Exit Sub : End If

        If MsgBox("¿Esta seguro de querer eliminar este Curso?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
            Exit Sub
        End If

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("DELETE FROM " & TABLA_CURSOS & " WHERE Curso = '" & Trim(txtTema.Text) & "'")

        Try

            cn.ConnectionString = Helper._ConectarA
            cn.Open()
            cm.Connection = cn

            cm.ExecuteNonQuery()

        Catch ex As Exception
            'Throw New Exception("Hubo un problema al querer consultar la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
            MsgBox("Hubo un problema al querer eliminar el Curso de la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message, MsgBoxStyle.Critical)
        Finally

            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

        MsgBox("Curso eliminadado con exito", MsgBoxStyle.Information)
        btnLimpiar.PerformClick()
        Me.Close()
        CursosPrincipal.btnCargarTodos.PerformClick()

    End Sub

    Private Sub btnPrimerRegistro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrimerRegistro.Click
        If Trim(txtTema.Text) = "" Then
            txtTema.Text = "1"
        End If

        Dim WCodigo = txtTema.Text

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT MIN(Curso) as PrimerRegistro FROM " & TABLA_CURSOS & " WHERE Curso > 0")
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

        txtTema.Text = WCodigo

        txtTema_KeyDown(Nothing, New KeyEventArgs(Keys.Enter))

    End Sub

    Private Sub btnUltimoRegistro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUltimoRegistro.Click
        If Trim(txtTema.Text) = "" Then
            txtTema.Text = "1"
        End If

        Dim WCodigo = txtTema.Text

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT MAX(Curso) as UltimoRegistro FROM " & TABLA_CURSOS)
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

        txtTema.Text = WCodigo

        txtTema_KeyDown(Nothing, New KeyEventArgs(Keys.Enter))

    End Sub

    Private Sub btnAnteriorRegistro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAnteriorRegistro.Click
        If Trim(txtTema.Text) = "" Then
            txtTema.Text = "1"
        End If

        Dim WCodigo = txtTema.Text

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT TOP 1 Curso as AnteriorRegistro FROM " & TABLA_CURSOS & " WHERE Curso < " & Trim(txtTema.Text) & " ORDER BY Curso DESC")
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

        txtTema.Text = WCodigo

        txtTema_KeyDown(Nothing, New KeyEventArgs(Keys.Enter))
    End Sub

    Private Sub btnSiguienteRegistro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSiguienteRegistro.Click

        If Trim(txtTema.Text) = "" Then
            txtTema.Text = "1"
        End If

        Dim WCodigo = txtTema.Text

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT TOP 1 Curso as SiguienteRegistro FROM " & TABLA_CURSOS & " WHERE Curso > " & Trim(txtTema.Text) & " ORDER BY Curso")
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

        txtTema.Text = WCodigo

        txtTema_KeyDown(Nothing, New KeyEventArgs(Keys.Enter))
    End Sub

    Private Sub txtDescripcion_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDescripcion.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txtDescripcion.Text) = "" Then : Exit Sub : End If

            'txtHoras.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtDescripcion.Text = ""
        End If

    End Sub

    Private Sub txtTema_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtTema.MouseDoubleClick
        btnConsulta.PerformClick()
    End Sub

    Private Sub ckIntervaloTemas_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckIntervaloTemas.CheckedChanged
        If ckIntervaloTemas.Checked Then
            txtDesde.Focus()
        End If
    End Sub

    Private Sub txtDesde_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDesde.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txtDesde.Text) = "" Then
                txtDesde.Text = "0"
            End If

            txtHasta.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtDesde.Text = ""
        End If

    End Sub

    Private Sub txtHasta_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtHasta.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txtHasta.Text) = "" Then
                txtHasta.Text = "99999999"
            End If

            txtDesde.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtHasta.Text = ""
        End If

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim _Formula As String = ""

        If ckTemaActual.Checked Then

            If Trim(txtTema.Text) = "" Or Val(txtTema.Text) = 0 Then : Exit Sub : End If

            _Formula = "{Tema.Curso}=" & Trim(txtTema.Text)

        ElseIf ckTodosTemas.Checked Then

            _Formula = "{Tema.Curso}>0"

        ElseIf ckIntervaloTemas.Checked Then

            If Trim(txtDesde.Text) = "" Then
                txtDesde.Text = "1"
            End If

            If Trim(txtHasta.Text) = "" Then
                txtHasta.Text = "999999999"
            End If

            _Formula = "{Tema.Curso} in " & Trim(txtDesde.Text) & " to " & Trim(txtHasta.Text)

        End If

        _Imprimir(_Formula)

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        GrupoImpresion.Visible = False
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

        With dgvCursos
            If .Focused Or .IsCurrentCellInEditMode Then ' Detectamos los ENTER tanto si solo estan en foco o si estan en edición una celda.
                .CommitEdit(DataGridViewDataErrorContexts.Commit) ' Guardamos todos los datos que no hayan sido confirmados.

                Dim iCol As Integer = .CurrentCell.ColumnIndex
                Dim iRow As Integer = .CurrentCell.RowIndex
                Dim valor As String = .CurrentCell.Value

                ' Limitamos los caracteres permitidos para cada una de las columnas.
                Select Case iCol
                    Case 0
                        If Not _EsNumeroOControl(keyData) Then
                            Return True
                        End If
                    Case 2
                        If Not _EsDecimalOControl(keyData) Then
                            Return True
                        End If
                    Case Else

                End Select

                If msg.WParam.ToInt32() = Keys.Enter Then

                    If valor <> "" Then

                        Select Case iCol
                            Case 0
                                If _NroCursoEnUso(valor, iRow) Then
                                    MsgBox("El Nro de Curso, ya se encuentra utilizado.", MsgBoxStyle.Information)
                                    Return True
                                End If
                            Case 2
                                .CurrentCell.Value = Helper.formatonumerico(valor)
                            Case Else

                        End Select
                    Else
                        Select Case iCol
                            Case 0, 1, 2
                                Return True
                            Case Else

                        End Select
                    End If

                    Select Case iCol
                        Case 2

                            Try
                                .CurrentCell = .Rows(iRow + 1).Cells(0)
                            Catch ex As Exception
                                .Rows.Add()
                                .CurrentCell = .Rows(iRow + 1).Cells(0)
                            End Try

                        Case Else
                            .CurrentCell = .Rows(iRow).Cells(iCol + 1)
                    End Select

                    Return True

                ElseIf msg.WParam.ToInt32() = Keys.Escape Then
                    .Rows(iRow).Cells(iCol).Value = ""

                    If iCol = 2 Then
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

    Private Function _NroCursoEnUso(ByVal NroCurso As String, ByVal iRow As Integer) As Boolean

        For Each row As DataGridViewRow In dgvCursos.Rows
            With row

                If Val(.Cells("Curso").Value) = Val(NroCurso) And .Index <> iRow Then
                    Return True
                End If

            End With
        Next

        Return False

    End Function

    Private Sub dgvCursos_RowHeaderMouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvCursos.RowHeaderMouseDoubleClick

        If MsgBox("¿Está seguro de que quiere eliminar el curso indicado?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
            Exit Sub
        End If

        Dim row As DataGridViewRow = dgvCursos.Rows(e.RowIndex)

        dgvCursos.Rows.Remove(row)

    End Sub

    Public Sub _AbrirParaModificar()
        Dim temp = txtTema.Text
        Me.Show()
        txtTema.Text = temp
        txtTema_KeyDown(Nothing, New KeyEventArgs(Keys.Enter))
    End Sub
End Class