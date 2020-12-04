Public Class IngresoDatosAdicMP
    Dim consultaIndice As Integer = -1
    Dim PagLstbox As Integer = 1
    ReadOnly TipoProducto As String

    Dim PermisoGrabar As Boolean
    Sub New(ByVal TipoProductoLLamadaMenu As String, ByVal ID As String)

        TipoProducto = TipoProductoLLamadaMenu

        InitializeComponent()

        If (TipoProducto = "MP") Then
            TabControl1.TabPages.Remove(TabPage6)
            TabControl1.TabPages.Remove(TabPage7)
        End If

        If (TipoProducto = "PT") Then
            masktxtCodigo.Mask = ">LL-00000-000"
            txtTipoEtiqueta.Visible = True
            lblTipoEtiqueta.Visible = True
            cbxTipoProducto.Items.Clear()
            With cbxTipoProducto.Items
                .Add("")
                .Add("Neutro")
                .Add("Acido Debil")
                .Add("Acido Fuerte")
                .Add("Basico Debil")
                .Add("Basico Fuerte")
            End With
            Label1.Text = "Prod. Terminado"
        End If

        Dim SQLCnslt As String = "SELECT Escritura FROM PermisosPerfiles WHERE ID = '" & ID & "' AND Sistema = 'LABORATORIO' AND Perfil = '" & Operador.Perfil & "' AND Planta = '" & Operador.Base & "' ORDER BY ID"
        Dim Row As DataRow = GetSingle(SQLCnslt, "SurfactanSa")
        If Row IsNot Nothing Then
            PermisoGrabar = Row.Item("Escritura")
        End If

    End Sub

    Private Sub masktxtCodigo_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles masktxtCodigo.KeyDown

        If (e.KeyData = Keys.Enter) Then
            If (Trim(masktxtCodigo.Text.Replace(" ", "").Replace("-", "")) <> "") Then
                Try

                    Dim CodigoArticulo As String = masktxtCodigo.Text
                    Dim sqlConsulta As String
                    If (TipoProducto = "MP") Then
                        sqlConsulta = "SELECT * FROM Articulo WHERE Codigo = '" & UCase(masktxtCodigo.Text) & "'"
                    Else
                        sqlConsulta = "SELECT * FROM Terminado WHERE Codigo = '" & UCase(masktxtCodigo.Text) & "'"
                    End If

                    Dim tabla As DataTable = GetAll(sqlConsulta)

                    btnLimpiar_Click(Nothing, Nothing)
                    If tabla IsNot Nothing Then
                        If (tabla.Rows.Count > 0) Then
                            masktxtCodigo.Text = CodigoArticulo
                            If (TipoProducto = "PT") Then
                                txtTipoEtiqueta.Text = IIf(IsDBNull(tabla.Rows(0).Item("Tipoeti").ToString()), "", tabla.Rows(0).Item("Tipoeti").ToString().Trim())
                            End If
                            txtNombreArticulo.Text = tabla.Rows(0).Item("Descripcion").ToString().Trim()
                            txtClase.Text = IIf(IsDBNull(tabla.Rows(0).Item("Clase").ToString()), "", tabla.Rows(0).Item("Clase").ToString().Trim())
                            txtNroNacionesUnidas.Text = IIf(IsDBNull(tabla.Rows(0).Item("Naciones").ToString()), "", tabla.Rows(0).Item("Naciones").ToString().Trim())
                            txtSecundario.Text = IIf(IsDBNull(tabla.Rows(0).Item("Secundario").ToString()), "", tabla.Rows(0).Item("Secundario").ToString().Trim())
                            txtRiesgo.Text = IIf(IsDBNull(tabla.Rows(0).Item("Riesgo").ToString()), "", tabla.Rows(0).Item("Riesgo").ToString().Trim())
                            txtIntervencion.Text = IIf(IsDBNull(tabla.Rows(0).Item("Intervencion").ToString()), "", tabla.Rows(0).Item("Intervencion").ToString().Trim())
                            txtEmbalaje.Text = IIf(IsDBNull(tabla.Rows(0).Item("Embalaje").ToString()), "", tabla.Rows(0).Item("Embalaje").ToString().Trim())
                            txtCaracteristicas.Text = IIf(IsDBNull(tabla.Rows(0).Item("Descrionu").ToString()), "", tabla.Rows(0).Item("Descrionu").ToString().Trim())

                            cbxEstado.SelectedIndex = IIf(IsDBNull(tabla.Rows(0).Item("EstadoProducto")), "0", tabla.Rows(0).Item("EstadoProducto"))
                            cbxTipoProducto.SelectedIndex = IIf(IsDBNull(tabla.Rows(0).Item("TipoProducto")), "0", tabla.Rows(0).Item("TipoProducto"))

                            CargarTab()
                        Else
                            masktxtCodigo.Text = CodigoArticulo
                        End If
                    End If


                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try

            End If
        End If
        If (e.KeyData = Keys.Escape) Then
            masktxtCodigo.Text = ""
        End If
    End Sub

    Private Sub CargarTab()
        Try

            Dim sqlConsulta As String
            If (TipoProducto = "MP") Then
                sqlConsulta = "SELECT * FROM DatosEtiquetaMP WHERE Articulo = '" & UCase(masktxtCodigo.Text) & "' ORDER BY Renglon"
            Else
                sqlConsulta = "SELECT * FROM DatosEtiqueta WHERE Terminado = '" & UCase(masktxtCodigo.Text) & "' ORDER BY Renglon"
            End If

            Dim tabla As DataTable = GetAll(sqlConsulta)

            If tabla IsNot Nothing Then
                cbxPalabraAdvertencia.SelectedIndex = tabla.Rows(0).Item("Palabra")
                cbxExplosivo1.SelectedIndex = tabla.Rows(0).Item("Pictograma1")
                cbxInflamable2.SelectedIndex = tabla.Rows(0).Item("Pictograma2")
                cbxCarburante3.SelectedIndex = tabla.Rows(0).Item("Pictograma3")
                cbxGasesBajo4.SelectedIndex = tabla.Rows(0).Item("Pictograma4")
                cbxCorrosivo5.SelectedIndex = tabla.Rows(0).Item("Pictograma5")
                cbxToxico6.SelectedIndex = tabla.Rows(0).Item("Pictograma6")
                cbxPeligro7.SelectedIndex = tabla.Rows(0).Item("Pictograma7")
                cbxPeligroPLASalud8.SelectedIndex = tabla.Rows(0).Item("Pictograma8")
                cbxMedioAmbiente9.SelectedIndex = tabla.Rows(0).Item("Pictograma9")
            End If

            Dim cantidadRenglonesDenomi As Integer = 0
            Dim YaCargoDenominaciones As Boolean = False

            'CARGO LOS RENGLONES PARA DENOMINACIONES
            DGV_DemoCompPeligrosos.Rows.Clear()
            For i = DGV_DemoCompPeligrosos.Rows.Count To 100
                DGV_DemoCompPeligrosos.Rows.Add("")
            Next

            For i As Integer = 0 To tabla.Rows.Count - 1

                Select Case tabla.Rows(i).Item("Tipo")
                    Case "1"

                        If (TipoProducto = "PT") Then
                            sqlConsulta = "SELECT FraseH Codigo, Descripcion = TRIM(Descripcion1H) + ' ' + TRIM(Descripcion2H) + ' ' + TRIM(Descripcion3H), Observaciones FROM DatosEtiqueta WHERE Tipo = 1 AND Terminado = '" & UCase(masktxtCodigo.Text) & "' ORDER BY Renglon"
                        Else
                            sqlConsulta = "SELECT FraseH Codigo, Descripcion = TRIM(Descripcion1H) + ' ' + TRIM(Descripcion2H) + ' ' + TRIM(Descripcion3H), Observaciones FROM DatosEtiquetaMP WHERE Tipo = 1 AND Articulo = '" & UCase(masktxtCodigo.Text) & "' ORDER BY Renglon"
                        End If

                        Dim tablaH As DataTable = GetAll(sqlConsulta)
                        If tablaH IsNot Nothing Then
                            If (tablaH.Rows.Count > 0) Then
                                DGV_FrasesH.DataSource = tablaH

                            End If
                        End If




                    Case "2"
                        If (TipoProducto = "PT") Then
                            sqlConsulta = "SELECT FraseP Codigo, Descripcion = TRIM(Descripcion1P) + ' ' + TRIM(Descripcion2P) + ' ' + TRIM(Descripcion3P), Observaciones FROM DatosEtiqueta WHERE Tipo = 2 AND Terminado = '" & UCase(masktxtCodigo.Text) & "' ORDER BY Renglon"
                        Else
                            sqlConsulta = "SELECT FraseP Codigo, Descripcion = TRIM(Descripcion1P) + ' ' + TRIM(Descripcion2P) + ' ' + TRIM(Descripcion3P), Observaciones FROM DatosEtiquetaMP WHERE Tipo = 2 AND Articulo = '" & UCase(masktxtCodigo.Text) & "' ORDER BY Renglon"
                        End If

                        Dim tablaP As DataTable = GetAll(sqlConsulta)
                        If tablaP IsNot Nothing Then
                            If (tablaP.Rows.Count > 0) Then
                                DGV_FrasesP.DataSource = tablaP
                            End If
                        End If



                    Case "3"
                        If YaCargoDenominaciones = False Then
                            If (TipoProducto = "PT") Then
                                sqlConsulta = "SELECT Denominacion FROM DatosEtiqueta WHERE Tipo = 3 AND Terminado = '" & UCase(masktxtCodigo.Text) & "' ORDER BY Renglon"
                            Else
                                sqlConsulta = "SELECT Denominacion FROM DatosEtiquetaMP WHERE Tipo = 3 AND Articulo = '" & UCase(masktxtCodigo.Text) & "' ORDER BY Renglon"
                            End If

                            Dim tablade As DataTable = GetAll(sqlConsulta)
                            If tablade.Rows.Count > 0 Then
                                For Each row As DataRow In tablade.Rows
                                    DGV_DemoCompPeligrosos.Rows(cantidadRenglonesDenomi).Cells("Denominacion").Value = Trim(OrDefault(row.Item("Denominacion"), ""))
                                    cantidadRenglonesDenomi += 1
                                Next
                            End If
                            YaCargoDenominaciones = True
                        End If

                End Select
            Next






            'BUSCO LAS FRASES EN INGLES PORQUE NO SE GUARDAN EN LA MISMA TABLA

            If (TipoProducto = "PT") Then

                For Each row As DataGridViewRow In DGV_FrasesH.Rows
                    AgregarInglesHP(row.Cells("Codigo").Value, "FraseHINGLES")
                Next

                For Each row As DataGridViewRow In DGV_FrasesP.Rows
                    AgregarInglesHP(row.Cells("CodigoFraseP").Value, "FrasePINGLES")
                Next

            End If





            'Dim sqlConsulta As String
            'Dim tabla As New DataTable


            'Dim cmd As New SqlCommand
            'Dim dr As SqlDataReader

            If (TipoProducto = "PT") Then
                sqlConsulta = "SELECT * FROM DatosEtiquetaIngles WHERE Terminado = '" & UCase(masktxtCodigo.Text) & "' ORDER BY Renglon"
                tabla = GetAll(sqlConsulta)

                For i As Integer = 0 To tabla.Rows.Count
                    Select Case tabla.Rows(i).Item("Tipo")
                        Case "4"
                            sqlConsulta = "SELECT FraseHIngles Codigo, Descripcion = TRIM(Descripcion1HIngles) + ' ' + TRIM(Descripcion2HIngles) + ' ' + TRIM(Descripcion3HIngles) FROM DatosEtiquetaIngles WHERE Tipo = 4 AND Terminado = '" & UCase(masktxtCodigo.Text) & "' ORDER BY Renglon"
                            Dim tablaHIngles As DataTable = GetAll(sqlConsulta)

                            If (tablaHIngles.Rows.Count > 0) Then
                                DGV_FrasesHIngles.DataSource = tablaHIngles
                            End If
                        Case "5"
                            sqlConsulta = "SELECT FrasePIngles Codigo, Descripcion = TRIM(Descripcion1PIngles) + ' ' + TRIM(Descripcion2PIngles) + ' ' + TRIM(Descripcion3PIngles) FROM DatosEtiquetaIngles WHERE Tipo = 5 AND Terminado = '" & UCase(masktxtCodigo.Text) & "' ORDER BY Renglon"
                            Dim tablaPIngles As DataTable = GetAll(sqlConsulta)
                            If (tablaPIngles.Rows.Count > 0) Then
                                DGV_FrasesPIngles.DataSource = tablaPIngles
                            End If
                    End Select
                Next
            End If
        Catch ex2 As Exception

        End Try



    End Sub



    Private Sub btnLimpiar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnLimpiar.Click

        masktxtCodigo.Text = ""

        txtNombreArticulo.Text = ""
        txtClase.Text = ""
        txtNroNacionesUnidas.Text = ""
        txtSecundario.Text = ""
        txtRiesgo.Text = ""
        txtIntervencion.Text = ""
        txtEmbalaje.Text = ""
        txtCaracteristicas.Text = ""
        txtTipoEtiqueta.Text = ""


        cbxEstado.SelectedIndex = 0
        cbxTipoProducto.SelectedIndex = 0
        cbxPalabraAdvertencia.SelectedIndex = 0
        cbxExplosivo1.SelectedIndex = 0
        cbxInflamable2.SelectedIndex = 0
        cbxCarburante3.SelectedIndex = 0
        cbxGasesBajo4.SelectedIndex = 0
        cbxCorrosivo5.SelectedIndex = 0
        cbxToxico6.SelectedIndex = 0
        cbxPeligro7.SelectedIndex = 0
        cbxPeligroPLASalud8.SelectedIndex = 0
        cbxMedioAmbiente9.SelectedIndex = 0


        Dim tabla As DataTable = TryCast(DGV_FrasesH.DataSource, DataTable) ' Traigo la referencia a la tabla
        If tabla IsNot Nothing Then tabla.Rows.Clear() ' y la limpio, o que tambien cambia los valores de la original

        tabla = TryCast(DGV_FrasesP.DataSource, DataTable)
        If tabla IsNot Nothing Then tabla.Rows.Clear()

        For Each row As DataGridViewRow In DGV_DemoCompPeligrosos.Rows
            row.Cells(0).Value = ""
        Next

        tabla = TryCast(DGV_FrasesHIngles.DataSource, DataTable)
        If tabla IsNot Nothing Then tabla.Rows.Clear()

        tabla = TryCast(DGV_FrasesPIngles.DataSource, DataTable)
        If tabla IsNot Nothing Then tabla.Rows.Clear()

        masktxtCodigo.Focus()
    End Sub



    Private Sub btnConsultarDatos_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnConsultarDatos.Click

        If (TipoProducto = "MP") Then
            LstboxConsultaDatos.Items.Clear()
            LstboxConsultaDatos.Items.Add("Materias Primas")
            LstboxConsultaDatos.Items.Add("Frases H")
            LstboxConsultaDatos.Items.Add("Frases P")

        Else
            LstboxConsultaDatos.Items.Clear()
            LstboxConsultaDatos.Items.Add("Productos Terminados")
            LstboxConsultaDatos.Items.Add("Frases H")
            LstboxConsultaDatos.Items.Add("Frases P")

        End If
        pnlConsultarDatos.Visible = True
        DGV_Consulta.SendToBack()
        LstboxConsultaDatos.BringToFront()

    End Sub

    Private Sub btnVolverConsultarDatos_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnVolverConsultarDatos.Click
        pnlConsultarDatos.Visible = False
        txtConsultaDatos.Visible = False
        PagLstbox = 1



    End Sub

    Private Sub txtConsultaDatos_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtConsultaDatos.KeyUp

        Dim datos As DataTable = TryCast(DGV_Consulta.DataSource, DataTable)

        If datos IsNot Nothing Then datos.DefaultView.RowFilter = String.Format("Codigo LIKE '%{0}%' OR Descripcion LIKE '%{0}%'", txtConsultaDatos.Text)

    End Sub

    Private Sub btnAnteriorPag_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAnteriorPag.Click
        txtConsultaDatos.Visible = False
        DGV_Consulta.Visible = False

        With LstboxConsultaDatos.Items
            .Clear()
            If TipoProducto = "MP" Then : .Add("Materias Primas") : Else : .Add("Productos Terminados") : End If
            .Add("Frases H")
            .Add("Frases P")
        End With

        consultaIndice = -1
        PagLstbox = 1
        DGV_Consulta.SendToBack()
        LstboxConsultaDatos.BringToFront()
    End Sub

    Private Sub DGV_Consulta_CellDoubleClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles DGV_Consulta.CellDoubleClick

        Try
            Select Case consultaIndice
                Case "0"
                    masktxtCodigo.Text = DGV_Consulta.CurrentRow.Cells("Codigo1").Value.ToString()
                    masktxtCodigo_KeyDown(Nothing, New KeyEventArgs(Keys.Enter))
                    DGV_Consulta.SendToBack()
                    LstboxConsultaDatos.BringToFront()
                    txtConsultaDatos.Visible = False
                    pnlConsultarDatos.Visible = False
                    PagLstbox = 1
                Case "1"
                    Dim tabla As DataTable = TryCast(DGV_FrasesH.DataSource, DataTable)

                    If (tabla Is Nothing) Then ' Creo las columbas de la tabla, porque si la tabla esta vacia no tiene formato
                        tabla = New DataTable
                        tabla.Columns.Add("Codigo")
                        tabla.Columns.Add("Descripcion")
                        tabla.Columns.Add("Observaciones")
                        DGV_FrasesH.DataSource = tabla
                    End If
                    Dim dr As DataRow
                    dr = tabla.NewRow()
                    dr(0) = DGV_Consulta.CurrentRow.Cells(0).Value
                    dr(1) = DGV_Consulta.CurrentRow.Cells(1).Value
                    dr(2) = DGV_Consulta.CurrentRow.Cells(2).Value
                    If VerRepetidosenDGV(consultaIndice, dr(0)) Then
                        tabla.Rows.Add(dr)
                        If (TipoProducto = "PT") Then
                            AgregarInglesHP(DGV_Consulta.CurrentRow.Cells(0).Value.ToString(), "FraseHINGLES")
                        End If
                    End If

                Case "2"
                    Dim tabla As DataTable = TryCast(DGV_FrasesP.DataSource, DataTable)

                    If (tabla Is Nothing) Then ' Creo las columbas de la tabla, porque si la tabla esta vacia no tiene formato
                        tabla = New DataTable
                        tabla.Columns.Add("Codigo")
                        tabla.Columns.Add("Descripcion")
                        tabla.Columns.Add("Observaciones")
                        DGV_FrasesP.DataSource = tabla
                    End If
                    Dim dr As DataRow
                    dr = tabla.NewRow()
                    dr(0) = DGV_Consulta.CurrentRow.Cells(0).Value
                    dr(1) = DGV_Consulta.CurrentRow.Cells(1).Value
                    dr(2) = DGV_Consulta.CurrentRow.Cells(2).Value
                    If VerRepetidosenDGV(consultaIndice, dr(0)) Then
                        tabla.Rows.Add(dr)
                        If (TipoProducto = "PT") Then
                            AgregarInglesHP(DGV_Consulta.CurrentRow.Cells(0).Value.ToString(), "FrasePINGLES")
                        End If
                    End If

            End Select

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub AgregarInglesHP(ByVal WCodigo As String, ByVal QueTabla As String)
        Try

            Dim sqlConsulta As String
            Select Case QueTabla
                Case "FraseHINGLES"
                    Dim tabla As DataTable = TryCast(DGV_FrasesHIngles.DataSource, DataTable)

                    If (tabla Is Nothing) Then ' Creo las columbas de la tabla, porque si la tabla esta vacia no tiene formato
                        tabla = New DataTable
                        tabla.Columns.Add("Codigo")
                        tabla.Columns.Add("Descripcion")
                        DGV_FrasesHIngles.DataSource = tabla
                    End If
                    sqlConsulta = "SELECT Codigo, Descripcion = TRIM(DescripcionIngles) + ' ' + TRIM(DescripcionInglesII) + ' ' + TRIM(DescripcionInglesIII) FROM FrasehIngles WHERE Codigo = '" & WCodigo & "'"
                    Dim tabla2 As DataTable = GetAll(sqlConsulta)
                    If (tabla2.Rows.Count) Then
                        For Each datar As DataRow In tabla2.Rows
                            Dim dr As DataRow
                            dr = tabla.NewRow()
                            dr(0) = datar.Item("Codigo")
                            dr(1) = datar.Item("Descripcion")
                            tabla.Rows.Add(dr)

                        Next
                    Else
                        MsgBox("Esta Frase no esta ingresada en ingles")
                    End If

                Case "FrasePINGLES"
                    Dim tabla As DataTable = TryCast(DGV_FrasesPIngles.DataSource, DataTable)

                    If (tabla Is Nothing) Then ' Creo las columbas de la tabla, porque si la tabla esta vacia no tiene formato
                        tabla = New DataTable
                        tabla.Columns.Add("Codigo")
                        tabla.Columns.Add("Descripcion")
                        DGV_FrasesPIngles.DataSource = tabla
                    End If
                    sqlConsulta = "SELECT Codigo, Descripcion = TRIM(DescripcionIngles) + ' ' + TRIM(DescripcionInglesII) + ' ' + TRIM(DescripcionInglesIII) FROM FrasePIngles WHERE Codigo = '" & WCodigo & "'"

                    Dim tabla2 As DataTable = GetAll(sqlConsulta)
                    If (tabla2.Rows.Count) Then
                        For Each datar As DataRow In tabla2.Rows
                            Dim dr As DataRow
                            dr = tabla.NewRow()
                            dr(0) = datar.Item("Codigo")
                            dr(1) = datar.Item("Descripcion")
                            tabla.Rows.Add(dr)

                        Next
                    Else
                        MsgBox("Esta Frase no esta ingresada en ingles")
                    End If
            End Select

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try

    End Sub

    Private Sub btnGrabar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnGrabar.Click
        Dim ControlPictogramas As Boolean = ValidarCbxPictogramas()
        If ControlPictogramas Then
            Dim sqlconsulta As String
            Try
                If (TipoProducto = "PT") Then
                    sqlconsulta = "DELETE FROM DatosEtiqueta WHERE Terminado = '" & masktxtCodigo.Text & "'"
                    ExecuteNonQueries("SurfactanSA", sqlconsulta)
                    sqlconsulta = "DELETE FROM DatosEtiquetaIngles WHERE Terminado = '" & masktxtCodigo.Text & "'"
                Else
                    sqlconsulta = "DELETE FROM DatosEtiquetaMp WHERE Articulo = '" & masktxtCodigo.Text & "'"
                End If

                ExecuteNonQueries("SurfactanSA", sqlconsulta)

                Dim ClaveVariable As String
                Dim Renglon = 1
                For i As Integer = 1 To 100
                    If (TipoProducto = "PT") Then
                        If (DGV_FrasesH.Rows.Count > 0) AndAlso i <= DGV_FrasesH.Rows.Count AndAlso DGV_FrasesH.Rows.Item(i - 1).Cells("Codigo").Value <> "" Then

                            ClaveVariable = masktxtCodigo.Text.Trim() + Renglon.ToString().PadLeft(3, "0")

                            sqlconsulta = "INSERT INTO DatosEtiqueta( Clave, Terminado, Renglon, Palabra, Pictograma1,"
                            sqlconsulta &= " Pictograma2, Pictograma3, Pictograma4, Pictograma5, Pictograma6,"
                            sqlconsulta &= " Pictograma7, Pictograma8, Pictograma9, Tipo, FraseH, Descripcion1H,"
                            sqlconsulta &= " Descripcion2H, Descripcion3H, FraseP, Descripcion1P , Descripcion2P,"
                            sqlconsulta &= " Descripcion3P, Observaciones, Denominacion) Values( '" & ClaveVariable & "' ,"
                            sqlconsulta &= " '" & masktxtCodigo.Text & "' , '" & Renglon & "' , '" & cbxPalabraAdvertencia.SelectedIndex & "' ,"
                            sqlconsulta &= " '" & cbxExplosivo1.SelectedIndex & "' , '" & cbxInflamable2.SelectedIndex & "' ,"
                            sqlconsulta &= " '" & cbxCarburante3.SelectedIndex & "' , '" & cbxGasesBajo4.SelectedIndex & "' ,"
                            sqlconsulta &= " '" & cbxCorrosivo5.SelectedIndex & "' , '" & cbxToxico6.SelectedIndex & "' ,"
                            sqlconsulta &= " '" & cbxPeligro7.SelectedIndex & "' , '" & cbxPeligroPLASalud8.SelectedIndex & "' ,"
                            sqlconsulta &= " '" & cbxMedioAmbiente9.SelectedIndex & "' , '" & "1" & "' , '" & DGV_FrasesH.Rows.Item(i - 1).Cells("Codigo").Value.ToString() & "' ,"
                            sqlconsulta &= " '" & Trim(DGV_FrasesH.Rows.Item(i - 1).Cells("DescripcionH").Value.ToString().PadRight(450).Substring(0, 250)) & "' , '" & Trim(DGV_FrasesH.Rows.Item(i - 1).Cells("DescripcionH").Value.ToString().PadRight(450).Substring(250, 100)) & "' ,"
                            sqlconsulta &= " '" & Trim(DGV_FrasesH.Rows.Item(i - 1).Cells("DescripcionH").Value.ToString().PadRight(450).Substring(350, 100)) & "' , '" & "" & "' ,"
                            sqlconsulta &= " '" & "" & "' , '" & "" & "' , '" & "" & "' , '" & DGV_FrasesH.Rows.Item(i - 1).Cells("ObservacionesH").Value.ToString() & "' , '" & "" & "' )"

                            ExecuteNonQueries("SurfactanSA", sqlconsulta)
                            Renglon = Renglon + 1

                        End If

                        If DGV_FrasesP.Rows.Count > 0 AndAlso i <= DGV_FrasesP.Rows.Count AndAlso DGV_FrasesP.Rows.Item(i - 1).Cells("CodigoFraseP").Value <> "" Then
                            ClaveVariable = masktxtCodigo.Text.Trim() + Renglon.ToString().PadLeft(3, "0")

                            sqlconsulta = "INSERT INTO DatosEtiqueta( Clave, Terminado, Renglon, Palabra, Pictograma1,"
                            sqlconsulta &= " Pictograma2, Pictograma3, Pictograma4, Pictograma5, Pictograma6,"
                            sqlconsulta &= " Pictograma7, Pictograma8, Pictograma9, Tipo, FraseH, Descripcion1H,"
                            sqlconsulta &= " Descripcion2H, Descripcion3H, FraseP, Descripcion1P , Descripcion2P,"
                            sqlconsulta &= " Descripcion3P, Observaciones, Denominacion) Values( '" & ClaveVariable & "' ,"
                            sqlconsulta &= " '" & masktxtCodigo.Text & "' , '" & Renglon & "' , '" & cbxPalabraAdvertencia.SelectedIndex & "' ,"
                            sqlconsulta &= " '" & cbxExplosivo1.SelectedIndex & "' , '" & cbxInflamable2.SelectedIndex & "' ,"
                            sqlconsulta &= " '" & cbxCarburante3.SelectedIndex & "' , '" & cbxGasesBajo4.SelectedIndex & "' ,"
                            sqlconsulta &= " '" & cbxCorrosivo5.SelectedIndex & "' , '" & cbxToxico6.SelectedIndex & "' ,"
                            sqlconsulta &= " '" & cbxPeligro7.SelectedIndex & "' , '" & cbxPeligroPLASalud8.SelectedIndex & "' ,"
                            sqlconsulta &= " '" & cbxMedioAmbiente9.SelectedIndex & "' , '" & "2" & "' , '" & "" & "' ,"
                            sqlconsulta &= " '" & "" & "' , '" & "" & "' ,"
                            sqlconsulta &= " '" & "" & "' , '" & DGV_FrasesP.Rows.Item(i - 1).Cells("CodigoFraseP").Value.ToString() & "' ,"
                            sqlconsulta &= " '" & Trim(DGV_FrasesP.Rows.Item(i - 1).Cells("DescripcionFraseP").Value.ToString().PadRight(450).Substring(0, 249)) & "' , '" & Trim(DGV_FrasesP.Rows.Item(i - 1).Cells("DescripcionFraseP").Value.ToString().PadRight(450).Substring(250, 100)) & "' ,"
                            sqlconsulta &= " '" & Trim(DGV_FrasesP.Rows.Item(i - 1).Cells("DescripcionFraseP").Value.ToString().PadRight(450).Substring(350, 100)) & "' , '" & DGV_FrasesP.Rows.Item(i - 1).Cells("Observaciones").Value.ToString() & "' , '" & "" & "' )"

                            ExecuteNonQueries("SurfactanSA", sqlconsulta)

                            Renglon = Renglon + 1

                        End If

                        If (OrDefault(DGV_DemoCompPeligrosos.Rows(i - 1).Cells(0).Value, "") <> "") Then

                            ClaveVariable = masktxtCodigo.Text.Trim() & Renglon.ToString().PadLeft(3, "0")
                            sqlconsulta = "INSERT INTO DatosEtiqueta( Clave, Terminado, Renglon, Palabra, Pictograma1,"
                            sqlconsulta &= " Pictograma2, Pictograma3, Pictograma4, Pictograma5, Pictograma6,"
                            sqlconsulta &= " Pictograma7, Pictograma8, Pictograma9, Tipo, FraseH, Descripcion1H,"
                            sqlconsulta &= " Descripcion2H, Descripcion3H, FraseP, Descripcion1P , Descripcion2P,"
                            sqlconsulta &= " Descripcion3P, Observaciones, Denominacion) Values( '" & ClaveVariable & "' ,"
                            sqlconsulta &= " '" & masktxtCodigo.Text & "' , '" & Renglon & "' , '" & cbxPalabraAdvertencia.SelectedIndex & "' ,"
                            sqlconsulta &= " '" & cbxExplosivo1.SelectedIndex & "' , '" & cbxInflamable2.SelectedIndex & "' ,"
                            sqlconsulta &= " '" & cbxCarburante3.SelectedIndex & "' , '" & cbxGasesBajo4.SelectedIndex & "' ,"
                            sqlconsulta &= " '" & cbxCorrosivo5.SelectedIndex & "' , '" & cbxToxico6.SelectedIndex & "' ,"
                            sqlconsulta &= " '" & cbxPeligro7.SelectedIndex & "' , '" & cbxPeligroPLASalud8.SelectedIndex & "' ,"
                            sqlconsulta &= " '" & cbxMedioAmbiente9.SelectedIndex & "' , '" & "3" & "' , '" & "" & "' ,"
                            sqlconsulta &= " '" & "" & "' , '" & "" & "' ,"
                            sqlconsulta &= " '" & "" & "' , '" & "" & "' ,"
                            sqlconsulta &= " '" & "" & "' , '" & "" & "' ,"
                            sqlconsulta &= " '" & "" & "' , '" & "" & "' , '" & Trim(DGV_DemoCompPeligrosos.Rows.Item(i - 1).Cells("Denominacion").Value.ToString()) & "' )"

                            ExecuteNonQueries("SurfactanSA", sqlconsulta)

                            Renglon = Renglon + 1

                        End If

                        If (DGV_FrasesHIngles.Rows.Count > 0) AndAlso i <= DGV_FrasesHIngles.Rows.Count Then

                            ClaveVariable = masktxtCodigo.Text.Trim() + Renglon.ToString().PadLeft(3, "0")

                            sqlconsulta = "INSERT INTO DatosEtiquetaIngles (Clave ,Terminado ,Renglon ,Tipo ,"
                            sqlconsulta &= "FraseHIngles ,Descripcion1HIngles ,Descripcion2HIngles ,Descripcion3HIngles ,"
                            sqlconsulta &= "FrasePIngles ,Descripcion1PIngles ,Descripcion2PIngles ,Descripcion3PIngles )"
                            sqlconsulta &= "Values ('" & ClaveVariable & "', '" & masktxtCodigo.Text & "', '" & Renglon & "',"
                            sqlconsulta &= "'" & "4" & "', '" & DGV_FrasesHIngles.Rows.Item(i - 1).Cells("CodigoFraseHINgles").Value.ToString() & "', '" & Trim(DGV_FrasesHIngles.Rows.Item(i - 1).Cells("DescripcionFraseHINgles").Value.ToString().PadRight(450).Substring(0, 250)) & "',"
                            sqlconsulta &= "'" & Trim(DGV_FrasesHIngles.Rows.Item(i - 1).Cells("DescripcionFraseHINgles").Value.ToString().PadRight(450).Substring(250, 100)) & "', '" & Trim(DGV_FrasesHIngles.Rows.Item(i - 1).Cells("DescripcionFraseHINgles").Value.ToString().PadRight(450).Substring(350, 100)) & "',"
                            sqlconsulta &= "'" & "" & "',"
                            sqlconsulta &= "'" & "" & "',"
                            sqlconsulta &= "'" & "" & "',"
                            sqlconsulta &= "'" & "" & "')"

                            ExecuteNonQueries("SurfactanSA", sqlconsulta)

                            Renglon = Renglon + 1

                        End If

                        If (DGV_FrasesHIngles.Rows.Count > 0) AndAlso i <= DGV_FrasesHIngles.Rows.Count Then

                            ClaveVariable = masktxtCodigo.Text.Trim() + Renglon.ToString().PadLeft(3, "0")

                            sqlconsulta = "INSERT INTO DatosEtiquetaIngles (Clave ,Terminado ,Renglon ,Tipo ,"
                            sqlconsulta &= "FraseHIngles ,Descripcion1HIngles ,Descripcion2HIngles ,Descripcion3HIngles ,"
                            sqlconsulta &= "FrasePIngles ,Descripcion1PIngles ,Descripcion2PIngles ,Descripcion3PIngles )"
                            sqlconsulta &= "Values ('" & ClaveVariable & "', '" & masktxtCodigo.Text & "', '" & Renglon & "',"
                            sqlconsulta &= "'" & "5" & "',"
                            sqlconsulta &= "'" & "" & "',"
                            sqlconsulta &= "'" & "" & "',"
                            sqlconsulta &= "'" & "" & "',"
                            sqlconsulta &= "'" & "" & "',"
                            sqlconsulta &= "'" & DGV_FrasesPIngles.Rows.Item(i - 1).Cells("CodigoFrasesPIngles").Value.ToString() & "', '" & Trim(DGV_FrasesPIngles.Rows.Item(i - 1).Cells("DescripcionFrasesPIngles").Value.ToString().PadRight(450).Substring(0, 250)) & "',"
                            sqlconsulta &= "'" & Trim(DGV_FrasesPIngles.Rows.Item(i - 1).Cells("DescripcionFrasesPIngles").Value.ToString().PadRight(450).Substring(250, 100)) & "', '" & Trim(DGV_FrasesPIngles.Rows.Item(i - 1).Cells("DescripcionFrasesPIngles").Value.ToString().PadRight(450).Substring(350, 100)) & "')"

                            ExecuteNonQueries("SurfactanSA", sqlconsulta)

                            Renglon = Renglon + 1

                        End If

                    Else
                        If (DGV_FrasesH.Rows.Count > 0) AndAlso i <= DGV_FrasesH.Rows.Count AndAlso DGV_FrasesH.Rows.Item(i - 1).Cells("Codigo").Value <> "" Then
                            ClaveVariable = masktxtCodigo.Text.Trim() + Renglon.ToString().PadLeft(3, "0")

                            sqlconsulta = "INSERT INTO DatosEtiquetaMp( Clave, Articulo, Renglon, Palabra, Pictograma1,"
                            sqlconsulta &= " Pictograma2, Pictograma3, Pictograma4, Pictograma5, Pictograma6,"
                            sqlconsulta &= " Pictograma7, Pictograma8, Pictograma9, Tipo, FraseH, Descripcion1H,"
                            sqlconsulta &= " Descripcion2H, Descripcion3H, FraseP, Descripcion1P , Descripcion2P,"
                            sqlconsulta &= " Descripcion3P, Observaciones, Denominacion) Values( '" & ClaveVariable & "' ,"
                            sqlconsulta &= " '" & masktxtCodigo.Text & "' , '" & Renglon & "' , '" & cbxPalabraAdvertencia.SelectedIndex & "' ,"
                            sqlconsulta &= " '" & cbxExplosivo1.SelectedIndex & "' , '" & cbxInflamable2.SelectedIndex & "' ,"
                            sqlconsulta &= " '" & cbxCarburante3.SelectedIndex & "' , '" & cbxGasesBajo4.SelectedIndex & "' ,"
                            sqlconsulta &= " '" & cbxCorrosivo5.SelectedIndex & "' , '" & cbxToxico6.SelectedIndex & "' ,"
                            sqlconsulta &= " '" & cbxPeligro7.SelectedIndex & "' , '" & cbxPeligroPLASalud8.SelectedIndex & "' ,"
                            sqlconsulta &= " '" & cbxMedioAmbiente9.SelectedIndex & "' , '" & "1" & "' , '" & DGV_FrasesH.Rows.Item(i - 1).Cells("Codigo").Value.ToString() & "' ,"
                            sqlconsulta &= " '" & Trim(DGV_FrasesH.Rows.Item(i - 1).Cells("DescripcionH").Value.ToString().PadRight(450).Substring(0, 250)) & "' , '" & Trim(DGV_FrasesH.Rows.Item(i - 1).Cells("DescripcionH").Value.ToString().PadRight(450).Substring(250, 100)) & "' ,"
                            sqlconsulta &= " '" & Trim(DGV_FrasesH.Rows.Item(i - 1).Cells("DescripcionH").Value.ToString().PadRight(450).Substring(350, 100)) & "' , '" & "" & "' ,"
                            sqlconsulta &= " '" & "" & "' , '" & "" & "' , '" & "" & "' , '" & DGV_FrasesH.Rows.Item(i - 1).Cells("ObservacionesH").Value.ToString() & "' , '" & "" & "' )"

                            ExecuteNonQueries("SurfactanSA", sqlconsulta)
                            Renglon = Renglon + 1

                        End If

                        If DGV_FrasesP.Rows.Count > 0 AndAlso i <= DGV_FrasesP.Rows.Count AndAlso DGV_FrasesP.Rows.Item(i - 1).Cells("CodigoFraseP").Value <> "" Then
                            ClaveVariable = masktxtCodigo.Text.Trim() + Renglon.ToString().PadLeft(3, "0")

                            sqlconsulta = "INSERT INTO DatosEtiquetaMp( Clave, Articulo, Renglon, Palabra, Pictograma1,"
                            sqlconsulta &= " Pictograma2, Pictograma3, Pictograma4, Pictograma5, Pictograma6,"
                            sqlconsulta &= " Pictograma7, Pictograma8, Pictograma9, Tipo, FraseH, Descripcion1H,"
                            sqlconsulta &= " Descripcion2H, Descripcion3H, FraseP, Descripcion1P , Descripcion2P,"
                            sqlconsulta &= " Descripcion3P, Observaciones, Denominacion) Values( '" & ClaveVariable & "' ,"
                            sqlconsulta &= " '" & masktxtCodigo.Text & "' , '" & Renglon & "' , '" & cbxPalabraAdvertencia.SelectedIndex & "' ,"
                            sqlconsulta &= " '" & cbxExplosivo1.SelectedIndex & "' , '" & cbxInflamable2.SelectedIndex & "' ,"
                            sqlconsulta &= " '" & cbxCarburante3.SelectedIndex & "' , '" & cbxGasesBajo4.SelectedIndex & "' ,"
                            sqlconsulta &= " '" & cbxCorrosivo5.SelectedIndex & "' , '" & cbxToxico6.SelectedIndex & "' ,"
                            sqlconsulta &= " '" & cbxPeligro7.SelectedIndex & "' , '" & cbxPeligroPLASalud8.SelectedIndex & "' ,"
                            sqlconsulta &= " '" & cbxMedioAmbiente9.SelectedIndex & "' , '" & "2" & "' , '" & "" & "' ,"
                            sqlconsulta &= " '" & "" & "' , '" & "" & "' ,"
                            sqlconsulta &= " '" & "" & "' , '" & DGV_FrasesP.Rows.Item(i - 1).Cells("CodigoFraseP").Value.ToString() & "' ,"
                            sqlconsulta &= " '" & Trim(DGV_FrasesP.Rows.Item(i - 1).Cells("DescripcionFraseP").Value.ToString().PadRight(450).Substring(0, 249)) & "' , '" & Trim(DGV_FrasesP.Rows.Item(i - 1).Cells("DescripcionFraseP").Value.ToString().PadRight(450).Substring(250, 100)) & "' ,"
                            sqlconsulta &= " '" & Trim(DGV_FrasesP.Rows.Item(i - 1).Cells("DescripcionFraseP").Value.ToString().PadRight(450).Substring(350, 100)) & "' , '" & DGV_FrasesP.Rows.Item(i - 1).Cells("Observaciones").Value.ToString() & "' , '" & "" & "' )"

                            ExecuteNonQueries("SurfactanSA", sqlconsulta)

                            Renglon = Renglon + 1

                        End If

                        If (OrDefault(DGV_DemoCompPeligrosos.Rows(i - 1).Cells(0).Value, "") <> "") Then

                            ClaveVariable = masktxtCodigo.Text.Trim() & Renglon.ToString().PadLeft(3, "0")
                            sqlconsulta = "INSERT INTO DatosEtiquetaMp( Clave, Articulo, Renglon, Palabra, Pictograma1,"
                            sqlconsulta = sqlconsulta & " Pictograma2, Pictograma3, Pictograma4, Pictograma5, Pictograma6,"
                            sqlconsulta = sqlconsulta & " Pictograma7, Pictograma8, Pictograma9, Tipo, FraseH, Descripcion1H,"
                            sqlconsulta = sqlconsulta & " Descripcion2H, Descripcion3H, FraseP, Descripcion1P , Descripcion2P,"
                            sqlconsulta = sqlconsulta & " Descripcion3P, Observaciones, Denominacion) Values( '" & ClaveVariable & "' ,"
                            sqlconsulta = sqlconsulta & " '" & masktxtCodigo.Text & "' , '" & Renglon & "' , '" & cbxPalabraAdvertencia.SelectedIndex & "' ,"
                            sqlconsulta = sqlconsulta & " '" & cbxExplosivo1.SelectedIndex & "' , '" & cbxInflamable2.SelectedIndex & "' ,"
                            sqlconsulta = sqlconsulta & " '" & cbxCarburante3.SelectedIndex & "' , '" & cbxGasesBajo4.SelectedIndex & "' ,"
                            sqlconsulta = sqlconsulta & " '" & cbxCorrosivo5.SelectedIndex & "' , '" & cbxToxico6.SelectedIndex & "' ,"
                            sqlconsulta = sqlconsulta & " '" & cbxPeligro7.SelectedIndex & "' , '" & cbxPeligroPLASalud8.SelectedIndex & "' ,"
                            sqlconsulta = sqlconsulta & " '" & cbxMedioAmbiente9.SelectedIndex & "' , '" & "3" & "' , '" & "" & "' ,"
                            sqlconsulta = sqlconsulta & " '" & "" & "' , '" & "" & "' ,"
                            sqlconsulta = sqlconsulta & " '" & "" & "' , '" & "" & "' ,"
                            sqlconsulta = sqlconsulta & " '" & "" & "' , '" & "" & "' ,"
                            sqlconsulta = sqlconsulta & " '" & "" & "' , '" & "" & "' , '" & Trim(DGV_DemoCompPeligrosos.Rows.Item(i - 1).Cells("Denominacion").Value.ToString()) & "' )"

                            ExecuteNonQueries("SurfactanSA", sqlconsulta)

                            Renglon = Renglon + 1

                        End If
                    End If

                Next

                If (TipoProducto = "PT") Then
                    sqlconsulta = "SELECT * FROM Terminado WHERE Codigo = '" & masktxtCodigo.Text.Trim() & "'"
                Else
                    sqlconsulta = "SELECT * FROM Articulo WHERE Codigo = '" & masktxtCodigo.Text.Trim() & "'"
                End If

                Dim dr As DataRow = GetSingle(sqlconsulta)

                Dim VarNaciones As String = ""
                Dim VarClase As String = ""
                Dim VarIntervencion As String = ""
                Dim VarEmbalaje As String = ""
                Dim VarCaracteristicas As String = ""
                Dim VarSecundario As String = ""
                Dim VarRiesgo As String = ""
                Dim VarTipoProducto As Integer = 0
                Dim VarEstadoProducto As Integer = 0
                Dim VarTipoEtiqueta As String = ""

                If (dr IsNot Nothing) Then

                    If (TipoProducto = "PT") Then
                        VarTipoEtiqueta = IIf(IsDBNull(dr.Item("Tipoeti")), "", dr.Item("Tipoeti"))
                    End If
                    VarNaciones = IIf(IsDBNull(dr.Item("Naciones")), "", dr.Item("Naciones"))
                    VarClase = IIf(IsDBNull(dr.Item("Clase")), "", dr.Item("Clase"))
                    VarIntervencion = IIf(IsDBNull(dr.Item("Intervencion")), "", dr.Item("Intervencion"))
                    VarEmbalaje = IIf(IsDBNull(dr.Item("Embalaje")), "", dr.Item("Embalaje"))
                    VarCaracteristicas = IIf(IsDBNull(dr.Item("Descrionu")), "", dr.Item("Descrionu"))
                    VarSecundario = IIf(IsDBNull(dr.Item("Secundario")), "", dr.Item("Secundario"))
                    VarRiesgo = IIf(IsDBNull(dr.Item("Riesgo")), "", dr.Item("Riesgo"))
                    VarTipoProducto = IIf(IsDBNull(dr.Item("TipoProducto")), "0", dr.Item("TipoProducto"))
                    VarEstadoProducto = IIf(IsDBNull(dr.Item("EstadoProducto")), "0", dr.Item("EstadoProducto"))

                End If

                Dim Grabar As String = "No"

                If (VarTipoEtiqueta.Trim() <> txtTipoEtiqueta.Text.Trim()) Then
                    Grabar = "Si"
                End If
                If (VarNaciones.Trim() <> txtNroNacionesUnidas.Text.Trim()) Then
                    Grabar = "Si"
                End If
                If (VarClase.Trim() <> txtClase.Text.Trim()) Then
                    Grabar = "Si"
                End If
                If (VarIntervencion.Trim() <> txtIntervencion.Text.Trim()) Then
                    Grabar = "Si"
                End If
                If (VarEmbalaje.Trim() <> txtEmbalaje.Text.Trim()) Then
                    Grabar = "Si"
                End If
                If (VarCaracteristicas.Trim() <> txtCaracteristicas.Text.Trim()) Then
                    Grabar = "Si"
                End If
                If (VarSecundario.Trim() <> txtSecundario.Text.Trim()) Then
                    Grabar = "Si"
                End If
                If (VarRiesgo.Trim() <> txtRiesgo.Text.Trim()) Then
                    Grabar = "Si"
                End If
                If (VarTipoProducto <> cbxTipoProducto.SelectedIndex) Then
                    Grabar = "Si"
                End If
                If (VarEstadoProducto <> cbxEstado.SelectedIndex) Then
                    Grabar = "Si"
                End If

                If (Grabar = "Si") Then

                    Dim Mensaje, estilo, titulo, Response, RespuestaUsuario
                    Mensaje = "¿Desea actualizar los datos Onu"
                    estilo = vbYesNo + vbInformation + vbDefaultButton2
                    titulo = "Datos Onu"

                    Response = MsgBox(Mensaje, estilo, titulo)

                    RespuestaUsuario = IIf(Response = vbYes, "Si", "No")

                    If (RespuestaUsuario = "Si") Then
                        Dim EmpresasAgrabar(7) As String
                        EmpresasAgrabar(0) = "SurfactanSA"
                        EmpresasAgrabar(1) = "surfactan_II"
                        EmpresasAgrabar(2) = "Surfactan_III"
                        EmpresasAgrabar(3) = "Surfactan_IV"
                        EmpresasAgrabar(4) = "Surfactan_V"
                        EmpresasAgrabar(5) = "Surfactan_VI"
                        EmpresasAgrabar(6) = "Surfactan_VII"

                        If (TipoProducto = "PT") Then
                            For i As Integer = 0 To 6
                                sqlconsulta = "UPDATE Terminado SET "
                                sqlconsulta &= "Tipoeti = '" & txtTipoEtiqueta.Text.Trim() & "',"
                                sqlconsulta &= "Naciones = '" & txtNroNacionesUnidas.Text.Trim() & "',"
                                sqlconsulta &= "Clase = '" & txtClase.Text.Trim() & "',"
                                sqlconsulta &= "Intervencion = '" & txtIntervencion.Text.Trim() & "',"
                                sqlconsulta &= "Embalaje = '" & txtEmbalaje.Text.Trim() & "',"
                                sqlconsulta &= "DescriOnu = '" & txtCaracteristicas.Text.Trim() & "',"
                                sqlconsulta &= "Secundario = '" & txtSecundario.Text.Trim() & "',"
                                sqlconsulta &= "Riesgo = '" & txtRiesgo.Text.Trim() & "',"
                                sqlconsulta &= "EstadoProducto = '" & cbxEstado.SelectedIndex & "',"
                                sqlconsulta &= "TipoProducto = '" & cbxTipoProducto.SelectedIndex & "'"
                                sqlconsulta &= " WHERE Codigo = '" & masktxtCodigo.Text.Trim() & "'"
                                ExecuteNonQueries(EmpresasAgrabar(i), {sqlconsulta})
                            Next
                        Else
                            For i As Integer = 0 To 6
                                sqlconsulta = "UPDATE Articulo SET "
                                sqlconsulta &= "Naciones = '" & txtNroNacionesUnidas.Text.Trim() & "',"
                                sqlconsulta &= "Clase = '" & txtClase.Text.Trim() & "',"
                                sqlconsulta &= "Intervencion = '" & txtIntervencion.Text.Trim() & "',"
                                sqlconsulta &= "Embalaje = '" & txtEmbalaje.Text.Trim() & "',"
                                sqlconsulta &= "DescriOnu = '" & txtCaracteristicas.Text.Trim() & "',"
                                sqlconsulta &= "Secundario = '" & txtSecundario.Text.Trim() & "',"
                                sqlconsulta &= "Riesgo = '" & txtRiesgo.Text.Trim() & "',"
                                sqlconsulta &= "EstadoProducto = '" & cbxEstado.SelectedIndex & "',"
                                sqlconsulta &= "TipoProducto = '" & cbxTipoProducto.SelectedIndex & "'"
                                sqlconsulta &= " WHERE Codigo = '" & masktxtCodigo.Text.Trim() & "'"

                                ExecuteNonQueries(EmpresasAgrabar(i), {sqlconsulta})
                            Next

                        End If
                    End If
                End If

                Dim Palabra As Integer
                Dim LugarImpresionI As Integer = 0
                Dim LugarImpresionII As Integer = 0
                Dim LugarImpresionIII As Integer = 0
                Dim imprecionI(1000) As String
                Dim imprecionII(1000) As String
                Dim imprecionIII(1000) As String
                Dim ImpreFrase(100) As String
                Dim LugarFrase As Integer = 1
                Dim EntraVarios As Char = "N"
                Dim Corte As Integer = 80
                Dim hasta, HastaII, HastaIII As Integer

                If (TipoProducto = "PT") Then
                    sqlconsulta = "SELECT * FROM DatosEtiqueta WHERE Terminado = '" & masktxtCodigo.Text & "'"
                Else
                    sqlconsulta = "SELECT * FROM DatosEtiquetaMp WHERE Articulo = '" & masktxtCodigo.Text & "'"
                End If

                Dim tabla As DataTable = GetAll(sqlconsulta, "SurfactanSA")

                For Each fila As DataRow In tabla.Rows

                    Dim Logo(10) As Integer

                    Palabra = fila.Item("Palabra")
                    Logo(0) = fila.Item("Pictograma1")
                    Logo(1) = fila.Item("Pictograma2")
                    Logo(2) = fila.Item("Pictograma3")
                    Logo(3) = fila.Item("Pictograma4")
                    Logo(4) = fila.Item("Pictograma5")
                    Logo(5) = fila.Item("Pictograma6")
                    Logo(6) = fila.Item("Pictograma7")
                    Logo(7) = fila.Item("Pictograma8")
                    Logo(8) = fila.Item("Pictograma9")

                    Select Case fila.Item("Tipo").ToString()
                        Case "1"
                            If (fila.Item("Descripcion1H") <> "") Then
                                LugarImpresionI = LugarImpresionI + 1
                                imprecionI(LugarImpresionI) = fila.Item("Descripcion1H")
                            End If
                            If (fila.Item("Descripcion2H") <> "") Then
                                LugarImpresionI = LugarImpresionI + 1
                                imprecionI(LugarImpresionI) = fila.Item("Descripcion2H")
                            End If
                            If (fila.Item("Descripcion3H") <> "") Then
                                LugarImpresionI = LugarImpresionI + 1
                                imprecionI(LugarImpresionI) = fila.Item("Descripcion3H")
                            End If
                        Case "2"
                            If (fila.Item("Descripcion1P") <> "") Then
                                LugarImpresionII = LugarImpresionII + 1
                                imprecionII(LugarImpresionII) = fila.Item("Descripcion1P")
                            End If
                            If (fila.Item("Descripcion2P") <> "") Then
                                LugarImpresionII = LugarImpresionII + 1
                                imprecionII(LugarImpresionII) = fila.Item("Descripcion2P")
                            End If
                            If (fila.Item("Descripcion3P") <> "") Then
                                LugarImpresionII = LugarImpresionII + 1
                                imprecionII(LugarImpresionII) = fila.Item("Descripcion3P")
                            End If
                            If (fila.Item("Observaciones") <> "") Then
                                LugarImpresionII = LugarImpresionII + 1
                                imprecionII(LugarImpresionII) = fila.Item("Observaciones")
                            End If
                        Case "3"
                            If (fila.Item("Denominacion") <> "") Then
                                LugarImpresionIII = LugarImpresionIII + 1
                                imprecionIII(LugarImpresionIII) = fila.Item("Denominacion")
                            End If
                    End Select

                Next

                For i As Integer = 1 To 99
                    If (Trim(OrDefault(imprecionIII(i), "")) <> "") Then
                        EntraVarios = "S"
                        ImpreFrase(LugarFrase) = ImpreFrase(LugarFrase) & "" & Trim(imprecionIII(i)) & ""

                        If (ImpreFrase(LugarFrase).Length > Corte) Then
                            Do

                                HastaIII = ImpreFrase(LugarFrase).Length
                                HastaII = ImpreFrase(LugarFrase).Length
                                For j As Integer = 1 To HastaIII
                                    If (Asc(Mid(ImpreFrase(LugarFrase), j, 1)) >= 65 And Asc(Mid(ImpreFrase(LugarFrase), j, 1)) <= 90) Then
                                        HastaII = HastaII + 0.5
                                    End If
                                Next
                                If (HastaII > Corte) Then
                                    For j As Integer = HastaIII - 1 To 1 Step -1
                                        If (Mid(ImpreFrase(LugarFrase), j, 1) = " " Or Mid(ImpreFrase(LugarFrase), j, 1) = "-" Or Mid(ImpreFrase(LugarFrase), j, 1) = "+" Or Mid(ImpreFrase(LugarFrase), j, 1) = "," Or Mid(ImpreFrase(LugarFrase), j, 1) = "/") Then
                                            Dim auxi As String = Mid(ImpreFrase(LugarFrase), 1, j)
                                            HastaIII = auxi.Length
                                            HastaII = 0
                                            For k As Integer = 1 To HastaIII
                                                HastaII = HastaII + 1
                                                If (Asc(Mid(auxi, k, 1)) >= 65 And Asc(Mid(auxi, k, 1)) <= 90) Then
                                                    HastaII = HastaII + 0.5
                                                End If
                                            Next
                                            If HastaII <= Corte Then
                                                auxi = ImpreFrase(LugarFrase)
                                                ImpreFrase(LugarFrase) = Mid(ImpreFrase(LugarFrase), 1, j)
                                                LugarFrase = LugarFrase + 1
                                                ImpreFrase(LugarFrase) = ImpreFrase(LugarFrase) + Mid(auxi, j + 1, Corte)
                                            End If
                                        End If

                                    Next
                                End If
                            Loop

                        End If
                    End If
                Next

                If EntraVarios = "S" Then
                    LugarFrase = LugarFrase + 1
                End If

                Dim EntraH As String = "N"

                For Ciclo = 1 To 99

                    If Trim(imprecionI(Ciclo)) <> "" Then

                        If EntraH = "N" Then
                            ImpreFrase(LugarFrase) = "INDICACIONES DE PELIGRO : "
                        End If
                        EntraH = "S"
                        ImpreFrase(LugarFrase) = ImpreFrase(LugarFrase) + Trim(imprecionI(Ciclo)) + " "

                        Do

                            HastaIII = Len(ImpreFrase(LugarFrase))

                            HastaII = Len(ImpreFrase(LugarFrase))
                            For Da = 1 To HastaIII
                                If Asc(Mid$(ImpreFrase(LugarFrase), Da, 1)) >= 65 And Asc(Mid$(ImpreFrase(LugarFrase), Da, 1)) <= 90 Then
                                    HastaII = HastaII + 0.5
                                End If
                            Next Da

                            If HastaII > Corte Then

                                For Da = HastaIII - 1 To 1 Step -1
                                    If Mid$(ImpreFrase(LugarFrase), Da, 1) = Space$(1) Or Mid$(ImpreFrase(LugarFrase), Da, 1) = "-" Or Mid$(ImpreFrase(LugarFrase), Da, 1) = "+" Or Mid$(ImpreFrase(LugarFrase), Da, 1) = "," Or Mid$(ImpreFrase(LugarFrase), Da, 1) = "/" Then

                                        Dim Auxi As String = Mid$(ImpreFrase(LugarFrase), 1, Da)
                                        HastaIII = Len(Auxi)
                                        HastaII = 0
                                        For DaIII = 1 To HastaIII
                                            HastaII = HastaII + 1
                                            If Asc(Mid$(Auxi, DaIII, 1)) >= 65 And Asc(Mid$(Auxi, DaIII, 1)) <= 90 Then
                                                HastaII = HastaII + 0.5
                                            End If
                                        Next DaIII
                                        If HastaII <= Corte Then
                                            Auxi = ImpreFrase(LugarFrase)
                                            ImpreFrase(LugarFrase) = Mid$(ImpreFrase(LugarFrase), 1, Da)
                                            LugarFrase = LugarFrase + 1
                                            ImpreFrase(LugarFrase) = ImpreFrase(LugarFrase) + Mid$(Auxi, Da + 1, Corte)
                                            Exit For
                                        End If

                                    End If
                                Next Da

                            Else

                                Exit Do

                            End If
                        Loop
                    End If

                Next Ciclo

                If EntraH = "S" Then
                    LugarFrase = LugarFrase + 1
                End If


                Dim EntraP As String = "N"

                For Ciclo = 1 To 99

                    If Trim(imprecionII(Ciclo)) <> "" Then

                        If EntraP = "N" Then
                            ImpreFrase(LugarFrase) = "DECLARACIONES DE PRUDENCIA : "
                        End If
                        EntraP = "S"
                        ImpreFrase(LugarFrase) = ImpreFrase(LugarFrase) + Trim(imprecionII(Ciclo)) + " "

                        Do

                            HastaIII = Len(ImpreFrase(LugarFrase))

                            HastaII = Len(ImpreFrase(LugarFrase))
                            For Da = 1 To HastaIII
                                If Asc(Mid$(ImpreFrase(LugarFrase), Da, 1)) >= 65 And Asc(Mid$(ImpreFrase(LugarFrase), Da, 1)) <= 90 Then
                                    HastaII = HastaII + 0.5
                                End If
                            Next Da

                            If HastaII > Corte Then

                                For Da = HastaIII - 1 To 1 Step -1
                                    If Mid$(ImpreFrase(LugarFrase), Da, 1) = Space$(1) Or Mid$(ImpreFrase(LugarFrase), Da, 1) = "-" Or Mid$(ImpreFrase(LugarFrase), Da, 1) = "+" Or Mid$(ImpreFrase(LugarFrase), Da, 1) = "," Or Mid$(ImpreFrase(LugarFrase), Da, 1) = "/" Then

                                        Dim Auxi As String = Mid$(ImpreFrase(LugarFrase), 1, Da)
                                        HastaIII = Len(Auxi)
                                        HastaII = 0
                                        For DaIII = 1 To HastaIII
                                            HastaII = HastaII + 1
                                            If Asc(Mid$(Auxi, DaIII, 1)) >= 65 And Asc(Mid$(Auxi, DaIII, 1)) <= 90 Then
                                                HastaII = HastaII + 0.5
                                            End If
                                        Next DaIII
                                        If HastaII <= Corte Then
                                            Auxi = ImpreFrase(LugarFrase)
                                            ImpreFrase(LugarFrase) = Mid$(ImpreFrase(LugarFrase), 1, Da)
                                            LugarFrase = LugarFrase + 1
                                            ImpreFrase(LugarFrase) = ImpreFrase(LugarFrase) + Mid$(Auxi, Da + 1, Corte)
                                            Exit For
                                        End If

                                    End If
                                Next Da

                            Else

                                Exit Do

                            End If
                        Loop
                    End If

                Next Ciclo

                For Ciclo = 1 To 10

                    If Trim(ImpreFrase(Ciclo)) <> "" Then
                        For CicloII = 1 To hasta

                            If Mid$(ImpreFrase(Ciclo), CicloII, 1) = Space$(1) Then
                                ImpreFrase(Ciclo) = Mid$(ImpreFrase(Ciclo), 1, CicloII) + " " + Mid$(ImpreFrase(Ciclo), CicloII + 1, Corte)
                                hasta = Len(Trim(ImpreFrase(Ciclo)))
                                CicloII = CicloII + 1
                                If CicloII = Corte Or hasta = Corte Then
                                    Exit For
                                End If
                            End If

                        Next CicloII

                        ImpreFrase(Ciclo) = Trim(ImpreFrase(Ciclo))

                    End If

                Next Ciclo

                ImpreFrase(8) = ""
                If Palabra = 1 Then
                    ImpreFrase(8) = "PELIGRO"
                End If
                If (TipoProducto = "PT") Then
                    sqlconsulta = "UPDATE DatosEtiqueta SET "
                    sqlconsulta &= "Frase1 = '" & ImpreFrase(1).left(80) & "',"
                    sqlconsulta &= "Frase2 = '" & ImpreFrase(2).left(80) & "',"
                    sqlconsulta &= "Frase3 = '" & ImpreFrase(3).left(80) & "',"
                    sqlconsulta &= "Frase4 = '" & ImpreFrase(4).left(80) & "',"
                    sqlconsulta &= "Frase5 = '" & ImpreFrase(5).left(80) & "',"
                    sqlconsulta &= "Frase6 = '" & ImpreFrase(6).left(80) & "',"
                    sqlconsulta &= "Frase7 = '" & ImpreFrase(7).left(80) & "',"
                    sqlconsulta &= "Frase8 = '" & ImpreFrase(8).left(80) & "'"
                    sqlconsulta &= " Where Terminado = '" & masktxtCodigo.Text & "'"
                Else
                    sqlconsulta = "UPDATE DatosEtiquetaMp SET "
                    sqlconsulta &= "Frase1 = '" & ImpreFrase(1).left(80) & "',"
                    sqlconsulta &= "Frase2 = '" & ImpreFrase(2).left(80) & "',"
                    sqlconsulta &= "Frase3 = '" & ImpreFrase(3).left(80) & "',"
                    sqlconsulta &= "Frase4 = '" & ImpreFrase(4).left(80) & "',"
                    sqlconsulta &= "Frase5 = '" & ImpreFrase(5).left(80) & "',"
                    sqlconsulta &= "Frase6 = '" & ImpreFrase(6).left(80) & "',"
                    sqlconsulta &= "Frase7 = '" & ImpreFrase(7).left(80) & "',"
                    sqlconsulta &= "Frase8 = '" & ImpreFrase(8).left(80) & "'"
                    sqlconsulta &= " Where Articulo = '" & masktxtCodigo.Text & "'"
                End If

                If Palabra = 2 Then ImpreFrase(8) = "ATENCION"

                ExecuteNonQueries("SurfactanSA", sqlconsulta)

                If (TipoProducto = "PT") Then

                    ' genera etiquetas para colorantes 14 renglones
                    ' a 100 caracteres
                    LugarImpresionI = 0
                    LugarImpresionII = 0
                    LugarImpresionIII = 0

                    sqlconsulta = "SELECT * FROM DatosEtiqueta WHERE Terminado = '" & masktxtCodigo.Text.Trim() & "' ORDER BY Clave"

                    Dim row As DataRow = GetSingle(sqlconsulta)

                    If row IsNot Nothing Then

                        Dim Logo(10) As Integer

                        Palabra = row.Item("Palabra")
                        Logo(0) = row.Item("Pictograma1")
                        Logo(1) = row.Item("Pictograma2")
                        Logo(2) = row.Item("Pictograma3")
                        Logo(3) = row.Item("Pictograma4")
                        Logo(4) = row.Item("Pictograma5")
                        Logo(5) = row.Item("Pictograma6")
                        Logo(6) = row.Item("Pictograma7")
                        Logo(7) = row.Item("Pictograma8")
                        Logo(8) = row.Item("Pictograma9")

                        Select Case row.Item("Tipo").ToString()
                            Case "1"
                                If (row.Item("Descripcion1H") <> "") Then
                                    LugarImpresionI = LugarImpresionI + 1
                                    imprecionI(LugarImpresionI) = row.Item("Descripcion1H")
                                End If
                                If (row.Item("Descripcion2H") <> "") Then
                                    LugarImpresionI = LugarImpresionI + 1
                                    imprecionI(LugarImpresionI) = row.Item("Descripcion2H")
                                End If
                                If (row.Item("Descripcion3H") <> "") Then
                                    LugarImpresionI = LugarImpresionI + 1
                                    imprecionI(LugarImpresionI) = row.Item("Descripcion3H")
                                End If
                            Case "2"
                                If (row.Item("Descripcion1P") <> "") Then
                                    LugarImpresionII = LugarImpresionII + 1
                                    imprecionII(LugarImpresionII) = row.Item("Descripcion1P")
                                End If
                                If (row.Item("Descripcion2P") <> "") Then
                                    LugarImpresionII = LugarImpresionII + 1
                                    imprecionII(LugarImpresionII) = row.Item("Descripcion2P")
                                End If
                                If (row.Item("Descripcion3P") <> "") Then
                                    LugarImpresionII = LugarImpresionII + 1
                                    imprecionII(LugarImpresionII) = row.Item("Descripcion3P")
                                End If
                                If (row.Item("Observaciones") <> "") Then
                                    LugarImpresionII = LugarImpresionII + 1
                                    imprecionII(LugarImpresionII) = row.Item("Observaciones")
                                End If
                            Case "3"
                                If (row.Item("Denominacion") <> "") Then
                                    LugarImpresionIII = LugarImpresionIII + 1
                                    imprecionIII(LugarImpresionIII) = row.Item("Denominacion")
                                End If
                        End Select
                    End If

                    LugarFrase = 1
                    Corte = 100
                    EntraVarios = "N"

                    For Ciclo = 1 To 99

                        If Trim(imprecionIII(Ciclo)) <> "" Then

                            EntraVarios = "S"
                            ImpreFrase(LugarFrase) = ImpreFrase(LugarFrase) + Trim(imprecionIII(Ciclo)) + " "

                            If Len(ImpreFrase(LugarFrase)) > Corte Then

                                Do

                                    HastaIII = Len(ImpreFrase(LugarFrase))

                                    HastaII = Len(ImpreFrase(LugarFrase))
                                    For Da = 1 To HastaIII
                                        If Asc(Mid$(ImpreFrase(LugarFrase), Da, 1)) >= 65 And Asc(Mid$(ImpreFrase(LugarFrase), Da, 1)) <= 90 Then
                                            HastaII = HastaII + 0.5
                                        End If
                                    Next Da

                                    If HastaII > Corte Then

                                        For Da = HastaIII - 1 To 1 Step -1
                                            If Mid$(ImpreFrase(LugarFrase), Da, 1) = Space$(1) Or Mid$(ImpreFrase(LugarFrase), Da, 1) = "-" Or Mid$(ImpreFrase(LugarFrase), Da, 1) = "+" Or Mid$(ImpreFrase(LugarFrase), Da, 1) = "," Or Mid$(ImpreFrase(LugarFrase), Da, 1) = "/" Then

                                                Dim Auxi As String = Mid$(ImpreFrase(LugarFrase), 1, Da)
                                                HastaIII = Len(Auxi)
                                                HastaII = 0
                                                For DaIII = 1 To HastaIII
                                                    HastaII = HastaII + 1
                                                    If Asc(Mid$(Auxi, DaIII, 1)) >= 65 And Asc(Mid$(Auxi, DaIII, 1)) <= 90 Then
                                                        HastaII = HastaII + 0.5
                                                    End If
                                                Next DaIII
                                                If HastaII <= Corte Then
                                                    Auxi = ImpreFrase(LugarFrase)
                                                    ImpreFrase(LugarFrase) = Mid$(ImpreFrase(LugarFrase), 1, Da)
                                                    LugarFrase = LugarFrase + 1
                                                    ImpreFrase(LugarFrase) = ImpreFrase(LugarFrase) + Mid$(Auxi, Da + 1, Corte)
                                                    Exit For
                                                End If

                                            End If
                                        Next Da

                                    Else

                                        Exit Do

                                    End If
                                Loop

                            End If
                        End If

                    Next Ciclo

                    If EntraVarios = "S" Then
                        LugarFrase = LugarFrase + 1
                    End If

                    EntraH = "N"

                    For Ciclo = 1 To 99

                        If Trim(imprecionI(Ciclo)) <> "" Then

                            If EntraH = "N" Then
                                ImpreFrase(LugarFrase) = "INDICACIONES DE PELIGRO : "
                            End If
                            EntraH = "S"
                            ImpreFrase(LugarFrase) = ImpreFrase(LugarFrase) + Trim(imprecionI(Ciclo)) + " "

                            Do

                                HastaIII = Len(ImpreFrase(LugarFrase))

                                HastaII = Len(ImpreFrase(LugarFrase))
                                For Da = 1 To HastaIII
                                    If Asc(Mid$(ImpreFrase(LugarFrase), Da, 1)) >= 65 And Asc(Mid$(ImpreFrase(LugarFrase), Da, 1)) <= 90 Then
                                        HastaII = HastaII + 0.5
                                    End If
                                Next Da

                                If HastaII > Corte Then

                                    For Da = HastaIII - 1 To 1 Step -1
                                        If Mid$(ImpreFrase(LugarFrase), Da, 1) = Space$(1) Or Mid$(ImpreFrase(LugarFrase), Da, 1) = "-" Or Mid$(ImpreFrase(LugarFrase), Da, 1) = "+" Or Mid$(ImpreFrase(LugarFrase), Da, 1) = "," Or Mid$(ImpreFrase(LugarFrase), Da, 1) = "/" Then

                                            Dim Auxi As String = Mid$(ImpreFrase(LugarFrase), 1, Da)
                                            HastaIII = Len(Auxi)
                                            HastaII = 0
                                            For DaIII = 1 To HastaIII
                                                HastaII = HastaII + 1
                                                If Asc(Mid$(Auxi, DaIII, 1)) >= 65 And Asc(Mid$(Auxi, DaIII, 1)) <= 90 Then
                                                    HastaII = HastaII + 0.5
                                                End If
                                            Next DaIII
                                            If HastaII <= Corte Then
                                                Auxi = ImpreFrase(LugarFrase)
                                                ImpreFrase(LugarFrase) = Mid$(ImpreFrase(LugarFrase), 1, Da)
                                                LugarFrase = LugarFrase + 1
                                                ImpreFrase(LugarFrase) = ImpreFrase(LugarFrase) + Mid$(Auxi, Da + 1, Corte)
                                                Exit For
                                            End If

                                        End If
                                    Next Da

                                Else

                                    Exit Do

                                End If
                            Loop
                        End If

                    Next Ciclo

                    If EntraH = "S" Then
                        LugarFrase = LugarFrase + 1
                    End If


                    EntraP = "N"

                    For Ciclo = 1 To 99

                        If Trim(imprecionII(Ciclo)) <> "" Then

                            If EntraP = "N" Then
                                ImpreFrase(LugarFrase) = "DECLARACIONES DE PRUDENCIA : "
                            End If
                            EntraP = "S"
                            ImpreFrase(LugarFrase) = ImpreFrase(LugarFrase) + Trim(imprecionII(Ciclo)) + " "

                            Do

                                HastaIII = Len(ImpreFrase(LugarFrase))

                                HastaII = Len(ImpreFrase(LugarFrase))
                                For Da = 1 To HastaIII
                                    If Asc(Mid$(ImpreFrase(LugarFrase), Da, 1)) >= 65 And Asc(Mid$(ImpreFrase(LugarFrase), Da, 1)) <= 90 Then
                                        HastaII = HastaII + 0.5
                                    End If
                                Next Da

                                If HastaII > Corte Then

                                    For Da = HastaIII - 1 To 1 Step -1
                                        If Mid$(ImpreFrase(LugarFrase), Da, 1) = Space$(1) Or Mid$(ImpreFrase(LugarFrase), Da, 1) = "-" Or Mid$(ImpreFrase(LugarFrase), Da, 1) = "+" Or Mid$(ImpreFrase(LugarFrase), Da, 1) = "," Or Mid$(ImpreFrase(LugarFrase), Da, 1) = "/" Then

                                            Dim Auxi As String = Mid$(ImpreFrase(LugarFrase), 1, Da)
                                            HastaIII = Len(Auxi)
                                            HastaII = 0
                                            For DaIII = 1 To HastaIII
                                                HastaII = HastaII + 1
                                                If Asc(Mid$(Auxi, DaIII, 1)) >= 65 And Asc(Mid$(Auxi, DaIII, 1)) <= 90 Then
                                                    HastaII = HastaII + 0.5
                                                End If
                                            Next DaIII
                                            If HastaII <= Corte Then
                                                Auxi = ImpreFrase(LugarFrase)
                                                ImpreFrase(LugarFrase) = Mid$(ImpreFrase(LugarFrase), 1, Da)
                                                LugarFrase = LugarFrase + 1
                                                ImpreFrase(LugarFrase) = ImpreFrase(LugarFrase) + Mid$(Auxi, Da + 1, Corte)
                                                Exit For
                                            End If

                                        End If
                                    Next Da

                                Else

                                    Exit Do

                                End If
                            Loop
                        End If

                    Next Ciclo

                    For Ciclo = 1 To 10

                        If Trim(ImpreFrase(Ciclo)) <> "" Then

                            For CicloII = 1 To hasta

                                If Mid$(ImpreFrase(Ciclo), CicloII, 1) = Space$(1) Then
                                    ImpreFrase(Ciclo) = Mid$(ImpreFrase(Ciclo), 1, CicloII) + " " + Mid$(ImpreFrase(Ciclo), CicloII + 1, Corte)
                                    hasta = Len(Trim(ImpreFrase(Ciclo)))
                                    CicloII = CicloII + 1
                                    If CicloII = Corte Or hasta = Corte Then
                                        Exit For
                                    End If
                                End If

                            Next CicloII

                            ImpreFrase(Ciclo) = Trim(ImpreFrase(Ciclo))

                        End If

                    Next Ciclo

                    ImpreFrase(15) = ""
                    If Palabra = 1 Then
                        ImpreFrase(15) = "PELIGRO"
                    End If
                    If Palabra = 2 Then
                        ImpreFrase(15) = "ATENCION"
                    End If

                    sqlconsulta = "DELETE DatosEtiquetaImpre WHERE Terminado = '" & masktxtCodigo.Text.Trim() & "'"

                    ExecuteNonQueries("SurfactanSA", sqlconsulta)

                    sqlconsulta = "INSERT INTO DatosEtiquetaImpre (Terminado, Pictograma1, Pictograma2, Pictograma3,"
                    sqlconsulta &= "Pictograma4, Pictograma5, Pictograma6, Pictograma7, Pictograma8,"
                    sqlconsulta &= "Pictograma9, Frase9, Frase10, Frase11, Frase12, Frase13, Frase14,"
                    sqlconsulta &= "Frase15, Frase16, Frase17, Frase18, Frase19, Frase20, Frase21,"
                    sqlconsulta &= "Frase22, Frase23) Values('" & masktxtCodigo.Text & "',"
                    sqlconsulta &= "'" & cbxExplosivo1.SelectedIndex.ToString() & "',"
                    sqlconsulta &= "'" & cbxInflamable2.SelectedIndex.ToString() & "',"
                    sqlconsulta &= "'" & cbxCarburante3.SelectedIndex.ToString() & "',"
                    sqlconsulta &= "'" & cbxGasesBajo4.SelectedIndex.ToString() & "',"
                    sqlconsulta &= "'" & cbxCorrosivo5.SelectedIndex.ToString() & "',"
                    sqlconsulta &= "'" & cbxToxico6.SelectedIndex.ToString() & "',"
                    sqlconsulta &= "'" & cbxPeligro7.SelectedIndex.ToString() & "',"
                    sqlconsulta &= "'" & cbxPeligroPLASalud8.SelectedIndex.ToString() & "',"
                    sqlconsulta &= "'" & cbxMedioAmbiente9.SelectedIndex.ToString() & "',"
                    sqlconsulta &= "'" & ImpreFrase(1).left(100) & "',"
                    sqlconsulta &= "'" & ImpreFrase(2).left(100) & "',"
                    sqlconsulta &= "'" & ImpreFrase(3).left(100) & "',"
                    sqlconsulta &= "'" & ImpreFrase(4).left(100) & "',"
                    sqlconsulta &= "'" & ImpreFrase(5).left(100) & "',"
                    sqlconsulta &= "'" & ImpreFrase(6).left(100) & "',"
                    sqlconsulta &= "'" & ImpreFrase(7).left(100) & "',"
                    sqlconsulta &= "'" & ImpreFrase(8).left(100) & "',"
                    sqlconsulta &= "'" & ImpreFrase(9).left(100) & "',"
                    sqlconsulta &= "'" & ImpreFrase(10).left(100) & "',"
                    sqlconsulta &= "'" & ImpreFrase(11).left(100) & "',"
                    sqlconsulta &= "'" & ImpreFrase(12).left(100) & "',"
                    sqlconsulta &= "'" & ImpreFrase(13).left(100) & "',"
                    sqlconsulta &= "'" & ImpreFrase(14).left(100) & "',"
                    sqlconsulta &= "'" & ImpreFrase(15).left(100) & "')"

                    ExecuteNonQueries("SurfactanSA", sqlconsulta)

                    '
                    ' Arma frase en inlgles
                    '
                    ' Genera etiquetas para colorantes 8 renglones
                    ' a 80 caracteres
                    '

                    LugarImpresionI = 0
                    LugarImpresionII = 0
                    LugarImpresionIII = 0


                    sqlconsulta = "SELECT * FROM DatosEtiqueta WHERE Terminado = '" & masktxtCodigo.Text.Trim() & "' ORDER BY Clave"

                    dr = GetSingle(sqlconsulta, "SurfactanSA")

                    If (dr IsNot Nothing) Then

                        Dim Logo(10) As Integer

                        Palabra = dr.Item("Palabra")
                        Logo(0) = dr.Item("Pictograma1")
                        Logo(1) = dr.Item("Pictograma2")
                        Logo(2) = dr.Item("Pictograma3")
                        Logo(3) = dr.Item("Pictograma4")
                        Logo(4) = dr.Item("Pictograma5")
                        Logo(5) = dr.Item("Pictograma6")
                        Logo(6) = dr.Item("Pictograma7")
                        Logo(7) = dr.Item("Pictograma8")
                        Logo(8) = dr.Item("Pictograma9")
                    End If


                    sqlconsulta = "SELECT * FROM DatosEtiquetaIngles WHERE Terminado = '" & masktxtCodigo.Text.Trim() & "' ORDER BY Clave"

                    dr = GetSingle(sqlconsulta, "SurfactanSA")
                    If dr IsNot Nothing Then
                        Select Case dr.Item("Tipo").ToString()
                            Case "4"
                                If (dr.Item("Descripcion1HIngles") <> "") Then
                                    LugarImpresionI = LugarImpresionI + 1
                                    imprecionI(LugarImpresionI) = dr.Item("Descripcion1HIngles")
                                End If
                                If (dr.Item("Descripcion2HIngles") <> "") Then
                                    LugarImpresionI = LugarImpresionI + 1
                                    imprecionI(LugarImpresionI) = dr.Item("Descripcion2HIngles")
                                End If
                                If (dr.Item("Descripcion3HIngles") <> "") Then
                                    LugarImpresionI = LugarImpresionI + 1
                                    imprecionI(LugarImpresionI) = dr.Item("Descripcion3HIngles")
                                End If
                            Case "5"
                                If (dr.Item("Descripcion1PIngles") <> "") Then
                                    LugarImpresionII = LugarImpresionII + 1
                                    imprecionII(LugarImpresionII) = dr.Item("Descripcion1PIngles")
                                End If
                                If (dr.Item("Descripcion2PIngles") <> "") Then
                                    LugarImpresionII = LugarImpresionII + 1
                                    imprecionII(LugarImpresionII) = dr.Item("Descripcion2PIngles")
                                End If
                                If (dr.Item("Descripcion3PIngles") <> "") Then
                                    LugarImpresionII = LugarImpresionII + 1
                                    imprecionII(LugarImpresionII) = dr.Item("Descripcion3PIngles")
                                End If


                        End Select
                    End If


                    LugarFrase = 1

                    Corte = 80

                    EntraVarios = "N"

                    For Ciclo = 1 To 99

                        If Trim(imprecionIII(Ciclo)) <> "" Then

                            EntraVarios = "S"
                            ImpreFrase(LugarFrase) = ImpreFrase(LugarFrase) + Trim(imprecionIII(Ciclo)) + " "

                            If Len(ImpreFrase(LugarFrase)) > Corte Then

                                Do

                                    HastaIII = Len(ImpreFrase(LugarFrase))

                                    HastaII = Len(ImpreFrase(LugarFrase))
                                    For Da = 1 To HastaIII
                                        If Asc(Mid$(ImpreFrase(LugarFrase), Da, 1)) >= 65 And Asc(Mid$(ImpreFrase(LugarFrase), Da, 1)) <= 90 Then
                                            HastaII = HastaII + 0.5
                                        End If
                                    Next Da

                                    If HastaII > Corte Then

                                        For Da = HastaIII - 1 To 1 Step -1
                                            If Mid$(ImpreFrase(LugarFrase), Da, 1) = Space$(1) Or Mid$(ImpreFrase(LugarFrase), Da, 1) = "-" Or Mid$(ImpreFrase(LugarFrase), Da, 1) = "+" Or Mid$(ImpreFrase(LugarFrase), Da, 1) = "," Or Mid$(ImpreFrase(LugarFrase), Da, 1) = "/" Then

                                                Dim Auxi As String = Mid$(ImpreFrase(LugarFrase), 1, Da)
                                                HastaIII = Len(Auxi)
                                                HastaII = 0
                                                For DaIII = 1 To HastaIII
                                                    HastaII = HastaII + 1
                                                    If Asc(Mid$(Auxi, DaIII, 1)) >= 65 And Asc(Mid$(Auxi, DaIII, 1)) <= 90 Then
                                                        HastaII = HastaII + 0.5
                                                    End If
                                                Next DaIII
                                                If HastaII <= Corte Then
                                                    Auxi = ImpreFrase(LugarFrase)
                                                    ImpreFrase(LugarFrase) = Mid$(ImpreFrase(LugarFrase), 1, Da)
                                                    LugarFrase = LugarFrase + 1
                                                    ImpreFrase(LugarFrase) = ImpreFrase(LugarFrase) + Mid$(Auxi, Da + 1, Corte)
                                                    Exit For
                                                End If

                                            End If
                                        Next Da

                                    Else

                                        Exit Do

                                    End If
                                Loop

                            End If
                        End If

                    Next Ciclo

                    If EntraVarios = "S" Then
                        LugarFrase = LugarFrase + 1
                    End If

                    EntraH = "N"

                    For Ciclo = 1 To 99

                        If Trim(imprecionI(Ciclo)) <> "" Then

                            If EntraH = "N" Then
                                ImpreFrase(LugarFrase) = "HAZARD STATEMENTS : "
                            End If
                            EntraH = "S"
                            ImpreFrase(LugarFrase) = ImpreFrase(LugarFrase) + Trim(imprecionI(Ciclo)) + " "

                            Do

                                HastaIII = Len(ImpreFrase(LugarFrase))

                                HastaII = Len(ImpreFrase(LugarFrase))
                                For Da = 1 To HastaIII
                                    If Asc(Mid$(ImpreFrase(LugarFrase), Da, 1)) >= 65 And Asc(Mid$(ImpreFrase(LugarFrase), Da, 1)) <= 90 Then
                                        HastaII = HastaII + 0.5
                                    End If
                                Next Da

                                If HastaII > Corte Then

                                    For Da = HastaIII - 1 To 1 Step -1
                                        If Mid$(ImpreFrase(LugarFrase), Da, 1) = Space$(1) Or Mid$(ImpreFrase(LugarFrase), Da, 1) = "-" Or Mid$(ImpreFrase(LugarFrase), Da, 1) = "+" Or Mid$(ImpreFrase(LugarFrase), Da, 1) = "," Or Mid$(ImpreFrase(LugarFrase), Da, 1) = "/" Then

                                            Dim Auxi As String = Mid$(ImpreFrase(LugarFrase), 1, Da)
                                            HastaIII = Len(Auxi)
                                            HastaII = 0
                                            For DaIII = 1 To HastaIII
                                                HastaII = HastaII + 1
                                                If Asc(Mid$(Auxi, DaIII, 1)) >= 65 And Asc(Mid$(Auxi, DaIII, 1)) <= 90 Then
                                                    HastaII = HastaII + 0.5
                                                End If
                                            Next DaIII
                                            If HastaII <= Corte Then
                                                Auxi = ImpreFrase(LugarFrase)
                                                ImpreFrase(LugarFrase) = Mid$(ImpreFrase(LugarFrase), 1, Da)
                                                LugarFrase = LugarFrase + 1
                                                ImpreFrase(LugarFrase) = ImpreFrase(LugarFrase) + Mid$(Auxi, Da + 1, Corte)
                                                Exit For
                                            End If

                                        End If
                                    Next Da

                                Else

                                    Exit Do

                                End If
                            Loop
                        End If

                    Next Ciclo

                    If EntraH = "S" Then
                        LugarFrase = LugarFrase + 1
                    End If


                    EntraP = "N"

                    For Ciclo = 1 To 99

                        If Trim(imprecionII(Ciclo)) <> "" Then

                            If EntraP = "N" Then
                                ImpreFrase(LugarFrase) = "PRECAUTIONARY STATEMENTS : "
                            End If
                            EntraP = "S"
                            ImpreFrase(LugarFrase) = ImpreFrase(LugarFrase) + Trim(imprecionII(Ciclo)) + " "

                            Do

                                HastaIII = Len(ImpreFrase(LugarFrase))

                                HastaII = Len(ImpreFrase(LugarFrase))
                                For Da = 1 To HastaIII
                                    If Asc(Mid$(ImpreFrase(LugarFrase), Da, 1)) >= 65 And Asc(Mid$(ImpreFrase(LugarFrase), Da, 1)) <= 90 Then
                                        HastaII = HastaII + 0.5
                                    End If
                                Next Da

                                If HastaII > Corte Then

                                    For Da = HastaIII - 1 To 1 Step -1
                                        If Mid$(ImpreFrase(LugarFrase), Da, 1) = Space$(1) Or Mid$(ImpreFrase(LugarFrase), Da, 1) = "-" Or Mid$(ImpreFrase(LugarFrase), Da, 1) = "+" Or Mid$(ImpreFrase(LugarFrase), Da, 1) = "," Or Mid$(ImpreFrase(LugarFrase), Da, 1) = "/" Then

                                            Dim Auxi As String = Mid$(ImpreFrase(LugarFrase), 1, Da)
                                            HastaIII = Len(Auxi)
                                            HastaII = 0
                                            For DaIII = 1 To HastaIII
                                                HastaII = HastaII + 1
                                                If Asc(Mid$(Auxi, DaIII, 1)) >= 65 And Asc(Mid$(Auxi, DaIII, 1)) <= 90 Then
                                                    HastaII = HastaII + 0.5
                                                End If
                                            Next DaIII
                                            If HastaII <= Corte Then
                                                Auxi = ImpreFrase(LugarFrase)
                                                ImpreFrase(LugarFrase) = Mid$(ImpreFrase(LugarFrase), 1, Da)
                                                LugarFrase = LugarFrase + 1
                                                ImpreFrase(LugarFrase) = ImpreFrase(LugarFrase) + Mid$(Auxi, Da + 1, Corte)
                                                Exit For
                                            End If

                                        End If
                                    Next Da

                                Else

                                    Exit Do

                                End If
                            Loop
                        End If

                    Next Ciclo

                    For Ciclo = 1 To 10

                        If Trim(ImpreFrase(Ciclo)) <> "" Then

                            For CicloII = 1 To hasta

                                If Mid$(ImpreFrase(Ciclo), CicloII, 1) = Space$(1) Then
                                    ImpreFrase(Ciclo) = Mid$(ImpreFrase(Ciclo), 1, CicloII) + " " + Mid$(ImpreFrase(Ciclo), CicloII + 1, Corte)
                                    hasta = Len(Trim(ImpreFrase(Ciclo)))
                                    CicloII = CicloII + 1
                                    If CicloII = Corte Or hasta = Corte Then
                                        Exit For
                                    End If
                                End If

                            Next CicloII

                            ImpreFrase(Ciclo) = Trim(ImpreFrase(Ciclo))

                        End If

                    Next Ciclo

                    ImpreFrase(8) = ""
                    If Palabra = 1 Then
                        ImpreFrase(8) = "DANGER"
                    End If
                    If Palabra = 2 Then
                        ImpreFrase(8) = "WARNING"
                    End If


                    sqlconsulta = "UPDATE DatosEtiquetaImpre SET "
                    sqlconsulta = sqlconsulta & "Frase1Ingles = '" & ImpreFrase(1).left(80) & "',"
                    sqlconsulta = sqlconsulta & "Frase2Ingles = '" & ImpreFrase(2).left(80) & "',"
                    sqlconsulta = sqlconsulta & "Frase3Ingles = '" & ImpreFrase(3).left(80) & "',"
                    sqlconsulta = sqlconsulta & "Frase4Ingles = '" & ImpreFrase(4).left(80) & "',"
                    sqlconsulta = sqlconsulta & "Frase5Ingles = '" & ImpreFrase(5).left(80) & "',"
                    sqlconsulta = sqlconsulta & "Frase6Ingles = '" & ImpreFrase(6).left(80) & "',"
                    sqlconsulta = sqlconsulta & "Frase7Ingles = '" & ImpreFrase(7).left(80) & "',"
                    sqlconsulta = sqlconsulta & "Frase8Ingles = '" & ImpreFrase(8).left(80) & "'"
                    sqlconsulta = sqlconsulta & " WHERE Terminado = '" + masktxtCodigo.Text.Trim() + "'"

                    ExecuteNonQueries("SurfactanSA", sqlconsulta)


                    '
                    ' genera etiquetas para colorantes 14 renglones
                    ' a 100 caracteres
                    '

                    LugarImpresionI = 0
                    LugarImpresionII = 0
                    LugarImpresionIII = 0


                    sqlconsulta = "SELECT * FROM DatosEtiqueta WHERE Terminado = '" & masktxtCodigo.Text.Trim() & "' ORDER BY Clave"


                    dr = GetSingle(sqlconsulta, "SurfactanSA")
                    If dr IsNot Nothing Then

                        Dim Logo(10) As Integer

                        Palabra = dr.Item("Palabra")
                        Logo(0) = dr.Item("Pictograma1")
                        Logo(1) = dr.Item("Pictograma2")
                        Logo(2) = dr.Item("Pictograma3")
                        Logo(3) = dr.Item("Pictograma4")
                        Logo(4) = dr.Item("Pictograma5")
                        Logo(5) = dr.Item("Pictograma6")
                        Logo(6) = dr.Item("Pictograma7")
                        Logo(7) = dr.Item("Pictograma8")
                        Logo(8) = dr.Item("Pictograma9")
                    End If


                    sqlconsulta = "SELECT * FROM DatosEtiquetaIngles WHERE Terminado = '" & masktxtCodigo.Text.Trim() & "' ORDER BY Clave"

                    dr = GetSingle(sqlconsulta, "SurfactanSA")

                    If dr IsNot Nothing Then
                        Select Case dr.Item("Tipo").ToString()
                            Case "4"
                                If (dr.Item("Descripcion1HIngles") <> "") Then
                                    LugarImpresionI = LugarImpresionI + 1
                                    imprecionI(LugarImpresionI) = dr.Item("Descripcion1HIngles")
                                End If
                                If (dr.Item("Descripcion2HIngles") <> "") Then
                                    LugarImpresionI = LugarImpresionI + 1
                                    imprecionI(LugarImpresionI) = dr.Item("Descripcion2HIngles")
                                End If
                                If (dr.Item("Descripcion3HIngles") <> "") Then
                                    LugarImpresionI = LugarImpresionI + 1
                                    imprecionI(LugarImpresionI) = dr.Item("Descripcion3HIngles")
                                End If
                            Case "5"
                                If (dr.Item("Descripcion1PIngles") <> "") Then
                                    LugarImpresionII = LugarImpresionII + 1
                                    imprecionII(LugarImpresionII) = dr.Item("Descripcion1PIngles")
                                End If
                                If (dr.Item("Descripcion2PIngles") <> "") Then
                                    LugarImpresionII = LugarImpresionII + 1
                                    imprecionII(LugarImpresionII) = dr.Item("Descripcion2PIngles")
                                End If
                                If (dr.Item("Descripcion3PIngles") <> "") Then
                                    LugarImpresionII = LugarImpresionII + 1
                                    imprecionII(LugarImpresionII) = dr.Item("Descripcion3PIngles")
                                End If


                        End Select
                    End If
                    LugarFrase = 1

                    Corte = 100

                    EntraVarios = "N"

                    For Ciclo = 1 To 99

                        If Trim(imprecionIII(Ciclo)) <> "" Then

                            EntraVarios = "S"
                            ImpreFrase(LugarFrase) = ImpreFrase(LugarFrase) + Trim(imprecionIII(Ciclo)) + " "

                            If Len(ImpreFrase(LugarFrase)) > Corte Then

                                Do

                                    HastaIII = Len(ImpreFrase(LugarFrase))

                                    HastaII = Len(ImpreFrase(LugarFrase))
                                    For Da = 1 To HastaIII
                                        If Asc(Mid$(ImpreFrase(LugarFrase), Da, 1)) >= 65 And Asc(Mid$(ImpreFrase(LugarFrase), Da, 1)) <= 90 Then
                                            HastaII = HastaII + 0.5
                                        End If
                                    Next Da

                                    If HastaII > Corte Then

                                        For Da = HastaIII - 1 To 1 Step -1
                                            If Mid$(ImpreFrase(LugarFrase), Da, 1) = Space$(1) Or Mid$(ImpreFrase(LugarFrase), Da, 1) = "-" Or Mid$(ImpreFrase(LugarFrase), Da, 1) = "+" Or Mid$(ImpreFrase(LugarFrase), Da, 1) = "," Or Mid$(ImpreFrase(LugarFrase), Da, 1) = "/" Then

                                                Dim Auxi As String = Mid$(ImpreFrase(LugarFrase), 1, Da)
                                                HastaIII = Len(Auxi)
                                                HastaII = 0
                                                For DaIII = 1 To HastaIII
                                                    HastaII = HastaII + 1
                                                    If Asc(Mid$(Auxi, DaIII, 1)) >= 65 And Asc(Mid$(Auxi, DaIII, 1)) <= 90 Then
                                                        HastaII = HastaII + 0.5
                                                    End If
                                                Next DaIII
                                                If HastaII <= Corte Then
                                                    Auxi = ImpreFrase(LugarFrase)
                                                    ImpreFrase(LugarFrase) = Mid$(ImpreFrase(LugarFrase), 1, Da)
                                                    LugarFrase = LugarFrase + 1
                                                    ImpreFrase(LugarFrase) = ImpreFrase(LugarFrase) + Mid$(Auxi, Da + 1, Corte)
                                                    Exit For
                                                End If

                                            End If
                                        Next Da

                                    Else

                                        Exit Do

                                    End If
                                Loop

                            End If
                        End If

                    Next Ciclo

                    If EntraVarios = "S" Then
                        LugarFrase = LugarFrase + 1
                    End If

                    EntraH = "N"

                    For Ciclo = 1 To 99

                        If Trim(imprecionI(Ciclo)) <> "" Then

                            If EntraH = "N" Then
                                ImpreFrase(LugarFrase) = "HAZARD STATEMENTS : "
                            End If
                            EntraH = "S"
                            ImpreFrase(LugarFrase) = ImpreFrase(LugarFrase) + Trim(imprecionI(Ciclo)) + " "

                            Do

                                HastaIII = Len(ImpreFrase(LugarFrase))

                                HastaII = Len(ImpreFrase(LugarFrase))
                                For Da = 1 To HastaIII
                                    If Asc(Mid$(ImpreFrase(LugarFrase), Da, 1)) >= 65 And Asc(Mid$(ImpreFrase(LugarFrase), Da, 1)) <= 90 Then
                                        HastaII = HastaII + 0.5
                                    End If
                                Next Da

                                If HastaII > Corte Then

                                    For Da = HastaIII - 1 To 1 Step -1
                                        If Mid$(ImpreFrase(LugarFrase), Da, 1) = Space$(1) Or Mid$(ImpreFrase(LugarFrase), Da, 1) = "-" Or Mid$(ImpreFrase(LugarFrase), Da, 1) = "+" Or Mid$(ImpreFrase(LugarFrase), Da, 1) = "," Or Mid$(ImpreFrase(LugarFrase), Da, 1) = "/" Then

                                            Dim Auxi As String = Mid$(ImpreFrase(LugarFrase), 1, Da)
                                            HastaIII = Len(Auxi)
                                            HastaII = 0
                                            For DaIII = 1 To HastaIII
                                                HastaII = HastaII + 1
                                                If Asc(Mid$(Auxi, DaIII, 1)) >= 65 And Asc(Mid$(Auxi, DaIII, 1)) <= 90 Then
                                                    HastaII = HastaII + 0.5
                                                End If
                                            Next DaIII
                                            If HastaII <= Corte Then
                                                Auxi = ImpreFrase(LugarFrase)
                                                ImpreFrase(LugarFrase) = Mid$(ImpreFrase(LugarFrase), 1, Da)
                                                LugarFrase = LugarFrase + 1
                                                ImpreFrase(LugarFrase) = ImpreFrase(LugarFrase) + Mid$(Auxi, Da + 1, Corte)
                                                Exit For
                                            End If

                                        End If
                                    Next Da

                                Else

                                    Exit Do

                                End If
                            Loop
                        End If

                    Next Ciclo

                    If EntraH = "S" Then
                        LugarFrase = LugarFrase + 1
                    End If


                    EntraP = "N"

                    For Ciclo = 1 To 99

                        If Trim(imprecionII(Ciclo)) <> "" Then

                            If EntraP = "N" Then
                                ImpreFrase(LugarFrase) = "PRECAUTIONARY STATEMENTS : "
                            End If
                            EntraP = "S"
                            ImpreFrase(LugarFrase) = ImpreFrase(LugarFrase) + Trim(imprecionII(Ciclo)) + " "

                            Do

                                HastaIII = Len(ImpreFrase(LugarFrase))

                                HastaII = Len(ImpreFrase(LugarFrase))
                                For Da = 1 To HastaIII
                                    If Asc(Mid$(ImpreFrase(LugarFrase), Da, 1)) >= 65 And Asc(Mid$(ImpreFrase(LugarFrase), Da, 1)) <= 90 Then
                                        HastaII = HastaII + 0.5
                                    End If
                                Next Da

                                If HastaII > Corte Then

                                    For Da = HastaIII - 1 To 1 Step -1
                                        If Mid$(ImpreFrase(LugarFrase), Da, 1) = Space$(1) Or Mid$(ImpreFrase(LugarFrase), Da, 1) = "-" Or Mid$(ImpreFrase(LugarFrase), Da, 1) = "+" Or Mid$(ImpreFrase(LugarFrase), Da, 1) = "," Or Mid$(ImpreFrase(LugarFrase), Da, 1) = "/" Then

                                            Dim Auxi As String = Mid$(ImpreFrase(LugarFrase), 1, Da)
                                            HastaIII = Len(Auxi)
                                            HastaII = 0
                                            For DaIII = 1 To HastaIII
                                                HastaII = HastaII + 1
                                                If Asc(Mid$(Auxi, DaIII, 1)) >= 65 And Asc(Mid$(Auxi, DaIII, 1)) <= 90 Then
                                                    HastaII = HastaII + 0.5
                                                End If
                                            Next DaIII
                                            If HastaII <= Corte Then
                                                Auxi = ImpreFrase(LugarFrase)
                                                ImpreFrase(LugarFrase) = Mid$(ImpreFrase(LugarFrase), 1, Da)
                                                LugarFrase = LugarFrase + 1
                                                ImpreFrase(LugarFrase) = ImpreFrase(LugarFrase) + Mid$(Auxi, Da + 1, Corte)
                                                Exit For
                                            End If

                                        End If
                                    Next Da

                                Else

                                    Exit Do

                                End If
                            Loop
                        End If

                    Next Ciclo

                    For Ciclo = 1 To 10

                        If Trim(ImpreFrase(Ciclo)) <> "" Then

                            For CicloII = 1 To hasta

                                If Mid$(ImpreFrase(Ciclo), CicloII, 1) = Space$(1) Then
                                    ImpreFrase(Ciclo) = Mid$(ImpreFrase(Ciclo), 1, CicloII) + " " + Mid$(ImpreFrase(Ciclo), CicloII + 1, Corte)
                                    hasta = Len(Trim(ImpreFrase(Ciclo)))
                                    CicloII = CicloII + 1
                                    If CicloII = Corte Or hasta = Corte Then
                                        Exit For
                                    End If
                                End If

                            Next CicloII

                            ImpreFrase(Ciclo) = Trim(ImpreFrase(Ciclo))

                        End If

                    Next Ciclo

                    ImpreFrase(15) = ""
                    If Palabra = 1 Then
                        ImpreFrase(15) = "DANGER"
                    End If
                    If Palabra = 2 Then
                        ImpreFrase(15) = "WARNING"
                    End If

                    sqlconsulta = "UPDATE DatosEtiquetaImpre SET "
                    sqlconsulta &= "Frase9Ingles = '" & ImpreFrase(1).left(100) & "',"
                    sqlconsulta &= "Frase10Ingles = '" & ImpreFrase(2).left(100) & "',"
                    sqlconsulta &= "Frase11Ingles = '" & ImpreFrase(3).left(100) & "',"
                    sqlconsulta &= "Frase12Ingles = '" & ImpreFrase(4).left(100) & "',"
                    sqlconsulta &= "Frase13Ingles = '" & ImpreFrase(5).left(100) & "',"
                    sqlconsulta &= "Frase14Ingles = '" & ImpreFrase(6).left(100) & "',"
                    sqlconsulta &= "Frase15Ingles = '" & ImpreFrase(7).left(100) & "',"
                    sqlconsulta &= "Frase16Ingles = '" & ImpreFrase(8).left(100) & "',"
                    sqlconsulta &= "Frase17Ingles = '" & ImpreFrase(9).left(100) & "',"
                    sqlconsulta &= "Frase18Ingles = '" & ImpreFrase(10).left(100) & "',"
                    sqlconsulta &= "Frase19Ingles = '" & ImpreFrase(11).left(100) & "',"
                    sqlconsulta &= "Frase20Ingles = '" & ImpreFrase(12).left(100) & "',"
                    sqlconsulta &= "Frase21Ingles = '" & ImpreFrase(13).left(100) & "',"
                    sqlconsulta &= "Frase22Ingles = '" & ImpreFrase(14).left(100) & "',"
                    sqlconsulta &= "Frase23Ingles = '" & ImpreFrase(15).left(100) & "'"
                    sqlconsulta &= " Where Terminado = '" & masktxtCodigo.Text.Trim() & "'"

                    ExecuteNonQueries("SurfactanSA", sqlconsulta)

                End If

                btnLimpiar_Click(Nothing, Nothing)
            Catch ex As Exception
                If (TipoProducto = "PT") Then
                    MsgBox("Verifique que el Producto Terminado no este vacio o mal escrito")
                Else
                    MsgBox("Verifique que Articulo no este vacio o mal escrito")
                End If

            End Try
        End If

    End Sub

    Private Sub btnImprimirReporte_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnImprimirReporte.Click

        If (TipoProducto = "PT") Then

            With New VistaPrevia
                .Reporte = New ReporteDatosAdicionalesPT()
                .Mostrar()
            End With

        Else

            With New VistaPrevia
                .Reporte = New ReporteDatosAdiciolesMP()
                .Mostrar()
            End With
        End If

    End Sub

    Private Sub masktxtCodigo_MouseDoubleClick(ByVal sender As Object, ByVal e As MouseEventArgs) Handles masktxtCodigo.MouseDoubleClick
        btnConsultarDatos_Click(Nothing, Nothing)
        LstboxConsultaDatos.SelectedIndex = 0
        LstboxConsultaDatos_MouseClick(Nothing, Nothing)
    End Sub

    Private Sub btnVolver_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnVolver.Click
        Close()
    End Sub
    
    Private Sub cbxExplosivo1_DropDownClosed(ByVal sender As Object, ByVal e As EventArgs) Handles cbxExplosivo1.DropDownClosed, cbxToxico6.DropDownClosed, cbxPeligroPLASalud8.DropDownClosed, cbxPeligro7.DropDownClosed, cbxMedioAmbiente9.DropDownClosed, cbxInflamable2.DropDownClosed, cbxCorrosivo5.DropDownClosed, cbxCarburante3.DropDownClosed, cbxGasesBajo4.DropDownClosed
        Dim i As Integer = 0
        Dim x As Integer() = {0, 0, 0, 0, 0, 0}
        For Each o As ComboBox In TabPage1.Controls.OfType(Of ComboBox)()
            If o.SelectedIndex > 0 Then
                i += 1
                x(o.SelectedIndex) += 1
            End If
        Next
        If (i > 5) Then
            MsgBox("No puede haber mas de 5 pictogramas")
            TryCast(sender, ComboBox).SelectedIndex = 0
        End If
        For j As Integer = 1 To 5
            If (x(j) > 1) Then
                MsgBox("Esta repitiendo Pictogramas en el valor " & j)
                TryCast(sender, ComboBox).SelectedIndex = 0
            End If

        Next
    End Sub

    Private Sub IngresoDatosAdicMP_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        Text = ""

        With pnlConsultarDatos
            .Location = New Point(161, 132)
            .Size = New Size(495, 274)
        End With

        btnLimpiar_Click(Nothing, Nothing)
        If PermisoGrabar = False Then
            btnGrabar.Enabled = False
        End If

    End Sub

    Private Function ValidarCbxPictogramas() As Boolean
        Dim MaxPictogramas As Integer = 0
        Dim conteo As Integer() = {0, 0, 0, 0, 0, 0}
        For Each Cbx As ComboBox In TabPage1.Controls.OfType(Of ComboBox)()
            If Cbx.SelectedIndex > 0 Then
                conteo(Cbx.SelectedIndex) += 1
                MaxPictogramas += 1
            End If
        Next
        If (MaxPictogramas > 5) Then
            MsgBox("No puede haber mas de 5 pictogramas")
            Return False
        End If
        For j As Integer = 1 To 5
            If (conteo(j) > 1) Then
                MsgBox("Esta repitiendo Pictogramas en el valor " & j)
                Return False
            End If
        Next
        Return True
    End Function

    Private Function VerRepetidosenDGV(ByVal Tipo As Integer, ByVal WCodigo As String) As Boolean
        Select Case Tipo
            Case "1"

                Dim existe As Boolean = _ExisteFrase(DGV_FrasesH, WCodigo)

                If existe Then
                    MsgBox("Esa frase H ya se encuentra en la lista")
                    Return False
                End If

            Case "2"

                Dim existe As Boolean = _ExisteFrase(DGV_FrasesP, WCodigo)

                If existe Then
                    MsgBox("Esa frase P ya se encuentra en la lista")
                    Return False
                End If

        End Select

        Return True

    End Function

    Private Function _ExisteFrase(ByVal datos As DataGridView, WCodigo As String) As Boolean
        Return datos.Rows.Cast(Of DataGridViewRow).ToList.Exists(Function(r) r.Cells(0).Value = WCodigo)
    End Function

    Private Sub DGV_FrasesH_RowHeaderMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DGV_FrasesH.RowHeaderMouseDoubleClick
        Dim tabla As DataTable = TryCast(DGV_FrasesH.DataSource, DataTable)
        Dim codigoH As String
        codigoH = DGV_FrasesH.CurrentRow.Cells("Codigo").Value.ToString().Trim()
        If MsgBox("¿Desea eliminar la frase H : " & codigoH & " ?", vbYesNo) = vbYes Then
            tabla.Rows.RemoveAt(DGV_FrasesH.CurrentRow.Index)

            If (TipoProducto = "PT") Then
                Dim tabla2 As DataTable = TryCast(DGV_FrasesHIngles.DataSource, DataTable)

                Dim RowABorrar As DataRow = tabla2.Rows.Cast(Of DataRow).First(Function(r) r.Item("Codigo") = codigoH)

                If RowABorrar IsNot Nothing Then tabla2.Rows.Remove(RowABorrar)
            End If
        End If

    End Sub

    Private Sub DGV_FrasesP_RowHeaderMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DGV_FrasesP.RowHeaderMouseDoubleClick
        Dim tabla As DataTable = TryCast(DGV_FrasesP.DataSource, DataTable)
        Dim WCodigo As String
        WCodigo = DGV_FrasesP.CurrentRow.Cells("CodigoFraseP").Value.ToString().Trim()
        If MsgBox("¿Desea eliminar la frase P : " & WCodigo & " ?", vbYesNo) = vbYes Then

            tabla.Rows.RemoveAt(DGV_FrasesP.CurrentRow.Index)

            If (TipoProducto = "PT") Then
                Dim tabla2 As DataTable = TryCast(DGV_FrasesPIngles.DataSource, DataTable)

                Dim RowABorrar As DataRow = tabla2.Rows.Cast(Of DataRow).First(Function(r) r.Item("Codigo") = WCodigo)

                If RowABorrar IsNot Nothing Then tabla2.Rows.Remove(RowABorrar)
            End If

        End If
    End Sub

    Private Sub txtTipoEtiqueta_KeyDown(sender As Object, e As KeyEventArgs) Handles txtTipoEtiqueta.KeyDown
        Select Case e.KeyData
            Case Keys.Enter

                txtNroNacionesUnidas.Focus()

            Case Keys.Escape

                txtTipoEtiqueta.Text = ""

        End Select
    End Sub

    Private Sub txtNroNacionesUnidas_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNroNacionesUnidas.KeyDown
        Select Case e.KeyData
            Case Keys.Enter

                txtClase.Focus()

            Case Keys.Escape

                txtNroNacionesUnidas.Text = ""

        End Select
    End Sub

    Private Sub txtClase_KeyDown(sender As Object, e As KeyEventArgs) Handles txtClase.KeyDown
        Select Case e.KeyData
            Case Keys.Enter

                txtSecundario.Focus()

            Case Keys.Escape

                txtClase.Text = ""

        End Select
    End Sub

    Private Sub txtSecundario_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSecundario.KeyDown
        Select Case e.KeyData
            Case Keys.Enter

                txtRiesgo.Focus()

            Case Keys.Escape
                txtSecundario.Text = ""
        End Select
    End Sub

    Private Sub txtRiesgo_KeyDown(sender As Object, e As KeyEventArgs) Handles txtRiesgo.KeyDown
        Select Case e.KeyData
            Case Keys.Enter

                txtIntervencion.Focus()

            Case Keys.Escape
                txtRiesgo.Text = ""
        End Select
    End Sub

    Private Sub txtIntervencion_KeyDown(sender As Object, e As KeyEventArgs) Handles txtIntervencion.KeyDown
        Select Case e.KeyData
            Case Keys.Enter

                txtEmbalaje.Focus()

            Case Keys.Escape
                txtIntervencion.Text = ""
        End Select
    End Sub

    Private Sub txtEmbalaje_KeyDown(sender As Object, e As KeyEventArgs) Handles txtEmbalaje.KeyDown
        Select Case e.KeyData
            Case Keys.Enter

                txtCaracteristicas.Focus()

            Case Keys.Escape
                txtEmbalaje.Text = ""
        End Select
    End Sub

    Private Sub txtCaracteristicas_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCaracteristicas.KeyDown
        Select Case e.KeyData
            Case Keys.Enter

                cbxEstado.Focus()

            Case Keys.Escape
                txtCaracteristicas.Text = ""
        End Select
    End Sub

    Private Sub cbxEstado_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxEstado.KeyDown
        Select Case e.KeyData
            Case Keys.Enter

                cbxTipoProducto.Focus()

            Case Keys.Escape
                cbxEstado.SelectedIndex = 0
        End Select
    End Sub

    Private Sub cbxTipoProducto_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxTipoProducto.KeyDown
        Select Case e.KeyData
            Case Keys.Escape
                cbxTipoProducto.SelectedIndex = 0
        End Select
    End Sub

    Private Sub LstboxConsultaDatos_MouseClick(sender As Object, e As MouseEventArgs) Handles LstboxConsultaDatos.MouseClick
        If (PagLstbox = 1) Then

            LstboxConsultaDatos.BringToFront()
            DGV_Consulta.SendToBack()
            txtConsultaDatos.Text = ""

            Dim tabla As New DataTable
            Dim sqlConsulta As String

            Select Case LstboxConsultaDatos.SelectedIndex
                Case 0
                    consultaIndice = 0

                    If (TipoProducto = "PT") Then
                        sqlConsulta = "SELECT Codigo, Descripcion FROM Terminado ORDER BY Codigo"
                    Else
                        sqlConsulta = "SELECT Codigo, Descripcion FROM Articulo ORDER BY Codigo"
                    End If

                    tabla = GetAll(sqlConsulta)

                Case 1
                    consultaIndice = 1

                    sqlConsulta = "SELECT Codigo, Descripcion,Observa Observaciones FROM FraseH ORDER BY Codigo"

                    tabla = GetAll(sqlConsulta, "SurfactanSA")

                Case 2
                    consultaIndice = 2

                    sqlConsulta = "SELECT Codigo, Descripcion, Observa Observaciones FROM FraseP ORDER BY Codigo"

                    tabla = GetAll(sqlConsulta, "SurfactanSA")

            End Select

            If tabla.Rows.Count > 0 Then DGV_Consulta.DataSource = tabla

            PagLstbox = 2

            LstboxConsultaDatos.Items.Clear()

            DGV_Consulta.BringToFront()
            LstboxConsultaDatos.SendToBack()

            DGV_Consulta.Visible = True
            txtConsultaDatos.Visible = True
            txtConsultaDatos.Focus()

        End If
    End Sub
End Class