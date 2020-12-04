Imports Laboratorio.MenuPrincipal
Imports Util.Clases
Imports Util.Clases.Query
Public Class EditarPermisos

    Sub New(ByVal Perfil As String, ByVal Sistema As String, ByVal Planta As String)

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        txt_Perfil.Text = UCase(Perfil)
        txt_Sistema.Text = UCase(Sistema)
        txt_Planta.Text = UCase(Planta)
    End Sub

    Private Sub CargarVentanasGuardadas()
        Dim SQLCnslt As String = "SELECT ID, Lectura, Escritura FROM PermisosPerfiles WHERE Sistema = '" & Trim(txt_Sistema.Text) & "' AND Perfil = '" & Trim(txt_Perfil.Text) & "' AND Planta = '" & Trim(txt_Planta.Text) & "' AND Visible = '1' ORDER BY ID"
        Dim TablaDatos As DataTable = GetAll(SQLCnslt, "SurfactanSA")

        If TablaDatos.Rows.Count > 0 Then
            For Each Row As DataRow In TablaDatos.Rows

                Dim Lectura As Boolean = Row.Item("Lectura")
                Dim Escritura As Boolean = Row.Item("Escritura")

                For Each Dgv_row As DataGridViewRow In dgv_Opciones.Rows
                    If Dgv_row.Cells("ID").Value = Row.Item("ID") Then
                        With Dgv_row

                            DGV_OpcionesHabilitadas.Rows.Add(False, .Cells("ID").Value, .Cells("Nombre").Value,
                                                             .Cells("IDPadre").Value, .Cells("NombrePadre").Value, Lectura, Escritura)

                            dgv_Opciones.Rows.Remove(Dgv_row)
                            Exit For
                        End With

                    End If

                Next
            Next
        End If

    End Sub



    Private Sub GrabarPrimerPermiso()
        Dim ListSQLs As New List(Of String)

        Dim SQLCnslt As String

        For Each Dgv_row As DataGridViewRow In dgv_Opciones.Rows
            With Dgv_row
                SQLCnslt = "INSERT INTO PermisosPerfiles(Sistema,Perfil,Planta,ID,Visible,Lectura,Escritura,WDate) Values(" _
                            & "'" & Trim(txt_Sistema.Text) & "', '" & Trim(txt_Perfil.Text) & "', '" & Trim(txt_Planta.Text) & "', '" & .Cells("ID").Value & "', '0', '0', '0', '" & Date.Today.ToString("yyyy-MM-dd") & "')"

                ListSQLs.Add(SQLCnslt)
            End With

        Next

        ExecuteNonQueries("SurfactanSA", ListSQLs.ToArray())
    End Sub


    Private Sub btn_Habilitar_Click(sender As Object, e As EventArgs) Handles btn_Habilitar.Click
        Dim ListaASacar As New List(Of Integer)

        dgv_Opciones.EndEdit(DataGridViewDataErrorContexts.Commit)

        For Each Dgv_row As DataGridViewRow In dgv_Opciones.Rows
            If Dgv_row.Cells("check1").Value Then

                With Dgv_row
                    Dim WIdpadre As String = Helper.OrDefault(.Cells("IDPadre").Value, "").ToString()
                    DGV_OpcionesHabilitadas.Rows.Add(False, .Cells("ID").Value, .Cells("Nombre").Value,
                                                     .Cells("IDPadre").Value, .Cells("NombrePadre").Value, True, False)
                    'dgv_Opciones.Rows.Remove(Dgv_row)
                    Dgv_row.Visible = False
                    ListaASacar.Add(Dgv_row.Index)
                    IncluirPadreAHabilitado(WIdpadre, ListaASacar)
                End With

            End If
        Next

        ListaASacar.Sort()
        ListaASacar.Reverse()
        For Each Index As Integer In ListaASacar
            dgv_Opciones.Rows.RemoveAt(Index)
        Next

        BloquearPadresOpcionesHabilitadas()

    End Sub

    Private Sub IncluirPadreAHabilitado(ByVal IDPadre As String, ByRef ListaASacar As List(Of Integer))
        Dim Primeravuelta As String = ""

        Do
            If Primeravuelta = IDPadre Then
                Exit Do
            End If

            If IDPadre = "" Then
                Exit Do
            End If

            For Each Dgv_row As DataGridViewRow In dgv_Opciones.Rows
                Primeravuelta = IDPadre
                If Dgv_row.Cells("ID").Value = IDPadre Then

                    If Not ListaASacar.Contains(Dgv_row.Index) Then

                        ListaASacar.Add(Dgv_row.Index)

                        With Dgv_row

                            DGV_OpcionesHabilitadas.Rows.Add(False, .Cells("ID").Value, .Cells("Nombre").Value,
                                                             .Cells("IDPadre").Value, .Cells("NombrePadre").Value, False, False)

                            IDPadre = .Cells("IDPadre").Value
                            Dgv_row.Visible = False

                            ' If Not ListaASacar.Contains(Dgv_row.Index) Then
                            '     ListaASacar.Add(Dgv_row.Index)
                            ' End If

                        End With

                        Exit For

                    End If

                End If
            Next
        Loop

    End Sub

    Private Sub btn_Cancelar_Click(sender As Object, e As EventArgs) Handles btn_Cancelar.Click
        Close()
    End Sub

    Private Sub btn_Grabar_Click(sender As Object, e As EventArgs) Handles btn_Grabar.Click
        Dim ListSQLs As New List(Of String)

        Dim SQLCnslt As String


        SQLCnslt = "UPDATE PermisosPerfiles SET Visible = '0', Lectura = '0', Escritura = '0', WDate = '" & Date.Today.ToString("yyyy-MM-dd") & "' WHERE Sistema = '" & Trim(txt_Sistema.Text) & "' AND Perfil = '" & Trim(txt_Perfil.Text) & "' AND Planta = '" & Trim(txt_Planta.Text) & "'"
        ListSQLs.Add(SQLCnslt)

        For Each dgv_row As DataGridViewRow In DGV_OpcionesHabilitadas.Rows
            With dgv_row
                Dim Lectura As Integer = 0
                Dim Escritura As Integer = 0
                If .Cells("Lectura").Value = True Then
                    Lectura = 1
                End If

                If .Cells("Escritura").Value = True Then
                    Escritura = 1
                End If


                SQLCnslt = "UPDATE PermisosPerfiles SET Visible = '1', Lectura = '" & Lectura & "', Escritura = '" & Escritura & "', WDate = '" & Date.Today.ToString("yyyy-MM-dd") & "' WHERE Sistema = '" & Trim(txt_Sistema.Text) & "' AND Perfil = '" & Trim(txt_Perfil.Text) & "' AND Planta = '" & Trim(txt_Planta.Text) & "' AND ID = '" & .Cells("IDHab").Value & "'"
                ListSQLs.Add(SQLCnslt)
            End With

        Next

        ExecuteNonQueries("SurfactanSa", ListSQLs.ToArray())
        Close()
    End Sub

    Private Sub btn_DesHabilitar_Click(sender As Object, e As EventArgs) Handles btn_DesHabilitar.Click
        Dim ListaASacar As New List(Of Integer)



        For Each Dgv_row As DataGridViewRow In DGV_OpcionesHabilitadas.Rows
            If Dgv_row.Cells("check").Value = True Then
                With Dgv_row
                    Dim WIdpadre As String = .Cells("IDPadrehab").Value
                    dgv_Opciones.Rows.Add(False, .Cells("IDHab").Value, .Cells("NombreHab").Value,
                                                     .Cells("IDPadrehab").Value, .Cells("OpcionPreviaHab").Value)
                    ' DGV_OpcionesHabilitadas.Rows.Remove(Dgv_row)

                    Dgv_row.Visible = False
                    ListaASacar.Add(Dgv_row.Index)
                    VerificarPadreAlDeshabilitar(WIdpadre, ListaASacar)
                End With

            End If
        Next

        ListaASacar.Sort()
        ListaASacar.Reverse()
        For Each Index As Integer In ListaASacar
            DGV_OpcionesHabilitadas.Rows.RemoveAt(Index)
        Next

        If DGV_OpcionesHabilitadas.Rows.Count = 1 Then
            If DGV_OpcionesHabilitadas.Rows(0).Cells("Check").ReadOnly = True Then
                With DGV_OpcionesHabilitadas.Rows(0)
                    dgv_Opciones.Rows.Add(False, .Cells("IDHab").Value, .Cells("NombreHab").Value,
                                                         .Cells("IDPadrehab").Value, .Cells("OpcionPreviaHab").Value)
                End With
                DGV_OpcionesHabilitadas.Rows.RemoveAt(0)
            End If
        End If

        BloquearPadresOpciones()

    End Sub


    Private Sub VerificarPadreAlDeshabilitar(ByVal IDPadre As String, ByRef ListaASacar As List(Of Integer))
        Dim CantDeHijos As Integer = 0
        Dim CantDehijosSeleccionados As Integer = 0
        For Each Dgv_row As DataGridViewRow In DGV_OpcionesHabilitadas.Rows
            If Dgv_row.Cells("IDPadreHab").Value = IDPadre Then
                CantDeHijos += 1
                If Dgv_row.Cells("Check").Value Then
                    CantDehijosSeleccionados += 1
                End If
            End If
        Next

        If (CantDeHijos - CantDehijosSeleccionados) = 0 Then
            For Each Dgv_row As DataGridViewRow In DGV_OpcionesHabilitadas.Rows

                If Dgv_row.Cells("IDHab").Value = IDPadre Then

                    If Not ListaASacar.Contains(Dgv_row.Index) Then

                        ListaASacar.Add(Dgv_row.Index)

                        With Dgv_row

                            dgv_Opciones.Rows.Add(False, .Cells("IDHab").Value, .Cells("NombreHab").Value,
                                                             .Cells("IDPadrehab").Value, .Cells("OpcionPreviaHab").Value)
                            ' dgv_Opciones.Rows.Remove(Dgv_row)
                            Dgv_row.Visible = False

                        End With

                        Exit For

                    End If

                End If
            Next
        End If

    End Sub


    Private Sub EditarPermisos_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim TablaItems As DataTable

        Select Case txt_Sistema.Text
            Case "LABORATORIO"
                TablaItems = Laboratorio.MenuPrincipal.ItemsMenu()
        End Select


        For Each row As DataRow In TablaItems.Rows
            With row
                dgv_Opciones.Rows.Add(False, .Item("ID"), .Item("Nombre"), .Item("IDPadre"), .Item("NombrePadre"))
            End With
        Next

        Dim SQLCnslt As String = "SELECT ID FROM PermisosPerfiles WHERE Sistema = '" & Trim(txt_Sistema.Text) & "' AND Perfil = '" & Trim(txt_Perfil.Text) & "' AND Planta = '" & Trim(txt_Planta.Text) & "'"
        Dim TablaDatos As DataTable = GetAll(SQLCnslt, "SurfactanSA")



        If TablaDatos.Rows.Count = 0 Then
            GrabarPrimerPermiso()
        Else
            CargarVentanasGuardadas()
            BloquearPadresOpcionesHabilitadas()
        End If

        BloquearPadresOpciones()

    End Sub

    Private Sub BloquearPadresOpciones()
        For Each Row As DataGridViewRow In dgv_Opciones.Rows

            If TieneHijo_DgvOpcion(Row.Cells("ID").Value) Then

                Row.DefaultCellStyle.BackColor = Color.DarkCyan
                Row.Cells("Check1").ReadOnly = True

            End If
        Next
    End Sub
    Private Function TieneHijo_DgvOpcion(ByVal ID As String) As Boolean
        For Each row As DataGridViewRow In dgv_Opciones.Rows
            If Val(row.Cells("IDPadre").Value) = Val(ID) Then
                Return True
            End If
        Next
        Return False
    End Function

    Private Sub BloquearPadresOpcionesHabilitadas()
        For Each Row As DataGridViewRow In DGV_OpcionesHabilitadas.Rows

            If TieneHijo_DgvOpcionHabilitadas(Row.Cells("IDHab").Value) Then

                Row.DefaultCellStyle.BackColor = Color.DarkCyan
                Row.Cells("Check").ReadOnly = True

            End If
        Next
    End Sub
    Private Function TieneHijo_DgvOpcionHabilitadas(ByVal ID As String) As Boolean
        For Each row As DataGridViewRow In DGV_OpcionesHabilitadas.Rows
            If Val(row.Cells("IDPadreHab").Value) = Val(ID) Then
                Return True
            End If
        Next
        Return False
    End Function
    
End Class