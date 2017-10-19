Imports System.Data.SqlClient

Public Class AMBCursos
    Private Const TABLA_CURSOS = "Tema"

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
        For Each txt As TextBox In {txtCodigo, txtDescripcion, txtAyuda, txtHoras}
            txt.Text = ""
        Next

        GrupoConsulta.Visible = False
        Try
            txtCodigo.Text = _TraerProximoCodigoTarea()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        txtCodigo.Focus()
    End Sub

    Private Sub NumerosConComas(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtHoras.KeyPress
        If Not Char.IsNumber(e.KeyChar) And Not Char.IsControl(e.KeyChar) And Not (CChar(".")) = e.KeyChar Then
            e.Handled = True
        End If
    End Sub

    Private Sub SoloNumero(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodigo.KeyPress
        If Not Char.IsNumber(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub btnConsulta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsulta.Click
        GrupoConsulta.Visible = True

        Dim WCodigo, WDescripcion, WRenglon

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT Curso, Descripcion FROM " & TABLA_CURSOS & " ORDER BY Curso")
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

                        WCodigo = IIf(IsDBNull(.Item("Curso")), "", Trim(.Item("Curso")))
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
            Throw New Exception("Hubo un problema al querer consultar la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
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
        txtCodigo.Focus()
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

        txtCodigo.Text = WClavesCursos(lstConsulta.SelectedIndex)

        txtCodigo_KeyDown(Nothing, New KeyEventArgs(Keys.Enter))

        btnCerrarConsulta.PerformClick()
    End Sub

    Private Sub AMBCursos_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        txtCodigo.Focus()
    End Sub

    Private Sub txtCodigo_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodigo.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txtCodigo.Text) = "" Then
                btnConsulta.PerformClick()
                Exit Sub
            End If

            Try
                _TraerTarea(txtCodigo.Text)
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical)
                Exit Sub
            End Try

            txtDescripcion.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtCodigo.Text = ""
        End If

    End Sub

    Private Sub _TraerTarea(ByVal codigo As String)
        codigo = Trim(codigo)

        If codigo = "" Then : Exit Sub : End If

        btnLimpiar.PerformClick()

        Dim WCodigo, WDescripcion, WHoras
        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT * FROM " & TABLA_CURSOS & " WHERE Curso = '" & codigo & "'")
        Dim dr As SqlDataReader

        Try
            WCodigo = codigo
            WDescripcion = ""
            WHoras = ""

            cn.ConnectionString = Helper._ConectarA
            cn.Open()
            cm.Connection = cn

            dr = cm.ExecuteReader()

            If dr.HasRows Then
                dr.Read()

                With dr
                    WDescripcion = IIf(IsDBNull(dr.Item("Descripcion")), "", dr.Item("Descripcion"))
                    WHoras = IIf(IsDBNull(dr.Item("Horas")), "0", dr.Item("Horas"))

                End With

            End If

        Catch ex As Exception
            Throw New Exception("Hubo un problema al querer consultar la información del Tarea indicado." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

        txtCodigo.Text = WCodigo
        txtDescripcion.Text = Trim(WDescripcion)
        txtHoras.Text = Helper.formatonumerico(WHoras)

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
        With VistaPrevia
            '.Reporte = New ListadoCursos
            '.Formula = "{Curso.Codigo} > 0"
            .Mostrar()
        End With
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click

        If Not _DatosValidos() Then : Exit Sub : End If

        Dim WCodigo, WDescripcion, WTemaI, WTemaII, WTemaIII, WResponsable, WResponsableII, WResponsableIII, WHoras, WTipo
        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT Codigo FROM " & TABLA_CURSOS & " WHERE Codigo = '" & Trim(txtCodigo.Text) & "'")
        Dim dr As SqlDataReader

        Try
            WCodigo = Trim(txtCodigo.Text)
            WDescripcion = _Left(txtDescripcion.Text, 90)
            WHoras = Helper.formatonumerico(txtHoras.Text)

            cn.ConnectionString = Helper._ConectarA
            cn.Open()
            cm.Connection = cn

            dr = cm.ExecuteReader()

            If dr.HasRows Then

                ' Actualizamos
                'cm.CommandText = "UPDATE " & TABLA_CURSOS & " SET Descripcion = '" & WDescripcion & "', TemaI = '" & WTemaI & "', TemaII = '" & WTemaII & "', TemaIII = '" & WTemaIII & "', Responsable = '" & WResponsable & "', ResponsableII = " & WResponsableII & ", ResponsableIII = " & WResponsableIII & ", ResponsableIV = 0, Horas = " & WHoras & ", Tipo = " & WTipo & " WHERE Codigo = '" & Trim(txtCodigo.Text) & "'"
            Else

                ' Damos de Alta.
                'cm.CommandText = "INSERT INTO " & TABLA_CURSOS & " (Codigo, Descripcion, TemaI, TemaII, TemaIII, Responsable, Horas, Tipo, ResponsableII, ResponsableIII, ResponsableIV) VALUES " _
                '                & "(" & WCodigo & ", '" & WDescripcion & "', '" & WTemaI & "', '" & WTemaII & "', '" & WTemaIII & "', '" & WResponsable & "', " & WHoras & ", " & WTipo & ", " & WResponsableII & ", " & WResponsableIII & ", 0)"
            End If

            dr.Close()
            'cm.ExecuteNonQuery()

        Catch ex As Exception
            'Throw New Exception("Hubo un problema al querer grabar el Sector indicado en la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
            MsgBox("Hubo un problema al querer grabar el Tema indicado en la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

        MsgBox("Tarea Guardada con exito", MsgBoxStyle.Information)
        btnLimpiar.PerformClick()

    End Sub

    Private Function _DatosValidos() As Boolean

        If Trim(txtCodigo.Text) = "" Then
            Return False
        End If

        If Trim(txtDescripcion.Text) = "" Then
            MsgBox("La tarea debe tener una descripción", MsgBoxStyle.Information)
            Return False
        End If

        Return True
    End Function

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        If Trim(txtCodigo.Text) = "" Then : Exit Sub : End If

        If MsgBox("¿Esta seguro de querer eliminar la Tarea indicada?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
            Exit Sub
        End If

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("DELETE FROM " & TABLA_CURSOS & " WHERE Clave = '" & Trim(txtCodigo.Text) & "'")

        Try

            cn.ConnectionString = Helper._ConectarA
            cn.Open()
            cm.Connection = cn

            cm.ExecuteNonQuery()

        Catch ex As Exception
            'Throw New Exception("Hubo un problema al querer consultar la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
            MsgBox("Hubo un problema al querer eliminar la Tarea en la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message, MsgBoxStyle.Critical)
        Finally

            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

        MsgBox("Tarea eliminada con exito", MsgBoxStyle.Information)
        btnLimpiar.PerformClick()

    End Sub

    Private Sub btnPrimerRegistro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrimerRegistro.Click
        If Trim(txtCodigo.Text) = "" Then
            txtCodigo.Text = "1"
        End If

        Dim WCodigo = txtCodigo.Text

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

        txtCodigo.Text = WCodigo

        txtCodigo_KeyDown(Nothing, New KeyEventArgs(Keys.Enter))

    End Sub

    Private Sub btnUltimoRegistro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUltimoRegistro.Click
        If Trim(txtCodigo.Text) = "" Then
            txtCodigo.Text = "1"
        End If

        Dim WCodigo = txtCodigo.Text

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

        txtCodigo.Text = WCodigo

        txtCodigo_KeyDown(Nothing, New KeyEventArgs(Keys.Enter))

    End Sub

    Private Sub btnAnteriorRegistro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAnteriorRegistro.Click
        If Trim(txtCodigo.Text) = "" Then
            txtCodigo.Text = "1"
        End If

        Dim WCodigo = txtCodigo.Text

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT TOP 1 Curso as AnteriorRegistro FROM " & TABLA_CURSOS & " WHERE Curso < " & Trim(txtCodigo.Text) & " ORDER BY Curso DESC")
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

        txtCodigo.Text = WCodigo

        txtCodigo_KeyDown(Nothing, New KeyEventArgs(Keys.Enter))
    End Sub

    Private Sub btnSiguienteRegistro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSiguienteRegistro.Click

        If Trim(txtCodigo.Text) = "" Then
            txtCodigo.Text = "1"
        End If

        Dim WCodigo = txtCodigo.Text

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT TOP 1 Curso as SiguienteRegistro FROM " & TABLA_CURSOS & " WHERE Curso > " & Trim(txtCodigo.Text) & " ORDER BY Curso")
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

        txtCodigo.Text = WCodigo

        txtCodigo_KeyDown(Nothing, New KeyEventArgs(Keys.Enter))
    End Sub

    Private Sub txtDescripcion_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDescripcion.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txtDescripcion.Text) = "" Then : Exit Sub : End If

            txtHoras.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtDescripcion.Text = ""
        End If

    End Sub

    Private Sub txtCodigo_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtCodigo.MouseDoubleClick
        btnConsulta.PerformClick()
    End Sub

    Private Sub cmbTipo_DropDownClosed(ByVal sender As System.Object, ByVal e As System.EventArgs)
        txtHoras.Focus()
    End Sub
End Class