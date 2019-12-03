Imports System.Configuration
Imports System.Data.OleDb
Imports System.Data.SqlClient

Public Class IngresoDatosAdicMP
    Dim consultaIndice As Integer = -1
    Dim PagLstbox As Integer = 1
    Dim TipoProducto As String
    Dim ComprobarEnter As String = ""

    Sub New(ByVal TipoProductoLLamadaMenu)

        TipoProducto = TipoProductoLLamadaMenu

        InitializeComponent()

        If (TipoProducto = "MP") Then
            Me.TabControl1.TabPages.Remove(TabPage6)
            Me.TabControl1.TabPages.Remove(TabPage7)
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


    End Sub

    Private Sub masktxtCodigo_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles masktxtCodigo.KeyDown

        If (e.KeyData = Keys.Enter) Then
            If (Trim(masktxtCodigo.Text.Replace(" ", "").Replace("-", "")) <> "") Then
                Try
                    Dim cn As New SqlConnection(ConfigurationManager.ConnectionStrings("LOCAL").ToString())
                    cn.Open()
                    Dim CodigoArticulo As String = masktxtCodigo.Text
                    ComprobarEnter = CodigoArticulo
                    Dim sqlConsulta As String
                    If (TipoProducto = "MP") Then
                        sqlConsulta = "SELECT * FROM Articulo WHERE Codigo = '" & UCase(masktxtCodigo.Text) & "'"
                    Else
                        sqlConsulta = "SELECT * FROM Terminado WHERE Codigo = '" & UCase(masktxtCodigo.Text) & "'"
                    End If

                    Dim tabla As New DataTable
                    Dim cmd As New SqlCommand(sqlConsulta, cn)
                    Dim dr As SqlDataReader = cmd.ExecuteReader()
                    btnLimpiar_Click(Nothing, Nothing)
                    tabla.Load(dr)
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
                        cn.Close()

                        CargarTab()
                    Else
                        masktxtCodigo.Text = CodigoArticulo
                    End If

                Catch ex As Exception

                End Try

            End If
        End If
        If (e.KeyData = Keys.Escape) Then
            masktxtCodigo.Text = ""
        End If
    End Sub

    Private Sub CargarTab()
        Try
            Dim cn As New SqlConnection(ConfigurationManager.ConnectionStrings("LOCAL").ToString())
            cn.Open()
            Dim sqlConsulta As String
            If (TipoProducto = "MP") Then
                sqlConsulta = "SELECT * FROM DatosEtiquetaMP WHERE Articulo = '" & UCase(masktxtCodigo.Text) & "' ORDER BY Renglon"
            Else
                sqlConsulta = "SELECT * FROM DatosEtiqueta WHERE Terminado = '" & UCase(masktxtCodigo.Text) & "' ORDER BY Renglon"
            End If

            Dim cmd As New SqlCommand(sqlConsulta, cn)
            Dim tabla As New DataTable
            Dim dr As SqlDataReader = cmd.ExecuteReader()
            tabla.Load(dr)


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




            For i As Integer = 0 To tabla.Rows.Count

                Select Case tabla.Rows(i).Item("Tipo")
                    Case "1"

                        If (TipoProducto = "PT") Then
                            sqlConsulta = "SELECT FraseH Codigo, Descripcion = TRIM(Descripcion1H) + ' ' + TRIM(Descripcion2H) + ' ' + TRIM(Descripcion3H), Observaciones FROM DatosEtiqueta WHERE Tipo = 1 AND Terminado = '" & UCase(masktxtCodigo.Text) & "' ORDER BY Renglon"
                        Else
                            sqlConsulta = "SELECT FraseH Codigo, Descripcion = TRIM(Descripcion1H) + ' ' + TRIM(Descripcion2H) + ' ' + TRIM(Descripcion3H), Observaciones FROM DatosEtiquetaMP WHERE Tipo = 1 AND Articulo = '" & UCase(masktxtCodigo.Text) & "' ORDER BY Renglon"
                        End If

                        cmd = New SqlCommand(sqlConsulta, cn)
                        dr = cmd.ExecuteReader()
                        Dim tablaH As New DataTable
                        tablaH.Load(dr)
                        If (tablaH.Rows.Count > 0) Then
                            DGV_FrasesH.DataSource = tablaH
                        End If
                        


                    Case "2"
                        If (TipoProducto = "PT") Then
                            sqlConsulta = "SELECT FraseP Codigo, Descripcion = TRIM(Descripcion1P) + ' ' + TRIM(Descripcion2P) + ' ' + TRIM(Descripcion3P), Observaciones FROM DatosEtiqueta WHERE Tipo = 2 AND Terminado = '" & UCase(masktxtCodigo.Text) & "' ORDER BY Renglon"
                        Else
                            sqlConsulta = "SELECT FraseP Codigo, Descripcion = TRIM(Descripcion1P) + ' ' + TRIM(Descripcion2P) + ' ' + TRIM(Descripcion3P), Observaciones FROM DatosEtiquetaMP WHERE Tipo = 2 AND Articulo = '" & UCase(masktxtCodigo.Text) & "' ORDER BY Renglon"
                        End If
                        cmd = New SqlCommand(sqlConsulta, cn)
                        dr = cmd.ExecuteReader()
                        Dim tablaP As New DataTable
                        tablaP.Load(dr)
                        If (tablaP.Rows.Count > 0) Then
                            DGV_FrasesP.DataSource = tablaP
                        End If


                    Case "3"
                        DGV_DemoCompPeligrosos.Rows.Clear()
                        If (TipoProducto = "PT") Then
                            sqlConsulta = "SELECT Denominacion FROM DatosEtiqueta WHERE Tipo = 3 AND Terminado = '" & UCase(masktxtCodigo.Text) & "' ORDER BY Renglon"
                        Else
                            sqlConsulta = "SELECT Denominacion FROM DatosEtiquetaMP WHERE Tipo = 3 AND Articulo = '" & UCase(masktxtCodigo.Text) & "' ORDER BY Renglon"
                        End If

                        cmd = New SqlCommand(sqlConsulta, cn)
                        dr = cmd.ExecuteReader()
                        If dr.HasRows Then
                            While dr.Read()
                                DGV_DemoCompPeligrosos.Rows.Add(Trim(OrDefault(dr.Item("Denominacion"), "")))
                            End While
                            dr.Close()
                        End If

                End Select
            Next
           


        Catch ex As Exception
            For i = DGV_DemoCompPeligrosos.Rows.Count + 1 To 100
                DGV_DemoCompPeligrosos.Rows.Add("")
            Next
            Try
                Dim cn As New SqlConnection(ConfigurationManager.ConnectionStrings("LOCAL").ToString())
                cn.Open()
                Dim sqlConsulta As String
                Dim tabla As New DataTable


                Dim cmd As New SqlCommand
                Dim dr As SqlDataReader

                If (TipoProducto = "PT") Then
                    sqlConsulta = "SELECT * FROM DatosEtiquetaIngles WHERE Terminado = '" & UCase(masktxtCodigo.Text) & "' ORDER BY Renglon"
                    cmd = New SqlCommand(sqlConsulta, cn)
                    dr = cmd.ExecuteReader()
                    tabla.Load(dr)
                    For i As Integer = 0 To tabla.Rows.Count
                        Select Case tabla.Rows(i).Item("Tipo")
                            Case "4"
                                sqlConsulta = "SELECT FraseHIngles Codigo, Descripcion = TRIM(Descripcion1HIngles) + ' ' + TRIM(Descripcion2HIngles) + ' ' + TRIM(Descripcion3HIngles) FROM DatosEtiquetaIngles WHERE Tipo = 4 AND Terminado = '" & UCase(masktxtCodigo.Text) & "' ORDER BY Renglon"
                                cmd = New SqlCommand(sqlConsulta, cn)
                                dr = cmd.ExecuteReader()
                                Dim tablaHIngles As New DataTable
                                tablaHIngles.Load(dr)
                                If (tablaHIngles.Rows.Count > 0) Then
                                    DGV_FrasesHIngles.DataSource = tablaHIngles
                                End If
                            Case "5"
                                sqlConsulta = "SELECT FrasePIngles Codigo, Descripcion = TRIM(Descripcion1PIngles) + ' ' + TRIM(Descripcion2PIngles) + ' ' + TRIM(Descripcion3PIngles) FROM DatosEtiquetaIngles WHERE Tipo = 5 AND Terminado = '" & UCase(masktxtCodigo.Text) & "' ORDER BY Renglon"
                                cmd = New SqlCommand(sqlConsulta, cn)
                                dr = cmd.ExecuteReader()
                                Dim tablaPIngles As New DataTable
                                tablaPIngles.Load(dr)
                                If (tablaPIngles.Rows.Count > 0) Then
                                    DGV_FrasesPIngles.DataSource = tablaPIngles
                                End If
                        End Select
                    Next
                End If
            Catch ex2 As Exception
                
            End Try
            
        End Try

    End Sub



    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click

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



    Private Sub btnConsultarDatos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultarDatos.Click

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

    Private Sub btnVolverConsultarDatos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVolverConsultarDatos.Click
        pnlConsultarDatos.Visible = False
        txtConsultaDatos.Visible = False
        PagLstbox = 1



    End Sub

    Private Sub LstboxConsultaDatos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LstboxConsultaDatos.Click




        If (PagLstbox = 1) Then
            LstboxConsultaDatos.BringToFront()
            DGV_Consulta.SendToBack()
            Select Case LstboxConsultaDatos.SelectedIndex
                Case "0"
                    Try
                        consultaIndice = 0
                        LstboxConsultaDatos.Items.Clear()
                        Dim cn As New SqlConnection(ConfigurationManager.ConnectionStrings("LOCAL").ToString())
                        cn.Open()
                        Dim tabla As New DataTable
                        Dim sqlConsulta As String
                        If (TipoProducto = "PT") Then
                            sqlConsulta = "SELECT Codigo, Descripcion FROM Terminado ORDER BY Codigo"
                        Else
                            sqlConsulta = "SELECT Codigo, Descripcion FROM Articulo ORDER BY Codigo"
                        End If

                        Dim cmd As New SqlCommand(sqlConsulta, cn)

                        Dim dr As SqlDataReader = cmd.ExecuteReader()
                        tabla.Load(dr)
                        If (tabla.Rows.Count > 0) Then
                            DGV_Consulta.DataSource = tabla

                        End If
                        '                      

                    Catch ex As Exception

                    End Try
                Case "1"
                    Try
                        consultaIndice = 1
                        LstboxConsultaDatos.Items.Clear()
                        Dim cn As New SqlConnection(ConfigurationManager.ConnectionStrings("LOCAL").ToString())
                        cn.Open()
                        Dim tabla As New DataTable
                        Dim sqlConsulta As String
                        sqlConsulta = "SELECT Codigo, Descripcion,Observa Observaciones FROM FraseH ORDER BY Codigo"
                        Dim cmd As New SqlCommand(sqlConsulta, cn)

                        Dim dr As SqlDataReader = cmd.ExecuteReader()
                        tabla.Load(dr)
                        If (tabla.Rows.Count > 0) Then
                            DGV_Consulta.DataSource = tabla

                        End If
                        '                      
                    Catch ex As Exception

                    End Try
                Case "2"
                    Try
                        consultaIndice = 2
                        LstboxConsultaDatos.Items.Clear()
                        Dim cn As New SqlConnection(ConfigurationManager.ConnectionStrings("LOCAL").ToString())
                        cn.Open()
                        Dim tabla As New DataTable
                        Dim sqlConsulta As String
                        sqlConsulta = "SELECT Codigo, Descripcion, Observa Observaciones FROM FraseP ORDER BY Codigo"
                        Dim cmd As New SqlCommand(sqlConsulta, cn)

                        Dim dr As SqlDataReader = cmd.ExecuteReader()
                        tabla.Load(dr)
                        If (tabla.Rows.Count > 0) Then
                            DGV_Consulta.DataSource = tabla

                        End If
                        '                       
                    Catch ex As Exception

                    End Try
            End Select
            PagLstbox = 2
            DGV_Consulta.BringToFront()
            LstboxConsultaDatos.SendToBack()
            txtConsultaDatos.Visible = True
            txtConsultaDatos.Focus()
        Else



        End If
    End Sub

    Private Sub txtConsultaDatos_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtConsultaDatos.KeyUp
        Dim cn As New SqlConnection(ConfigurationManager.ConnectionStrings("LOCAL").ToString())
        cn.Open()
        Dim sqlconsulta As String
        Dim tabla As New DataTable


        Select Case consultaIndice
            Case "0"
                Try
                    LstboxConsultaDatos.Items.Clear()
                    If (TipoProducto = "PT") Then
                        sqlconsulta = "SELECT Codigo, Descripcion FROM Terminado WHERE Descripcion LIKE  '%" + txtConsultaDatos.Text.Trim() + "%' OR Codigo LIKE '%" + txtConsultaDatos.Text.Trim() + "%' ORDER BY Codigo"
                    Else
                        sqlconsulta = "SELECT Codigo, Descripcion FROM Articulo WHERE Descripcion LIKE  '%" + txtConsultaDatos.Text.Trim() + "%' OR Codigo LIKE '%" + txtConsultaDatos.Text.Trim() + "%' ORDER BY Codigo"
                    End If

                    Dim cmd As New SqlCommand(sqlconsulta, cn)
                    Dim dr As SqlDataReader = cmd.ExecuteReader()
                    tabla.Load(dr)
                    Dim tabla2 = TryCast(DGV_Consulta.DataSource, DataTable)
                    If tabla2 IsNot Nothing Then tabla2.Rows.Clear()
                    'DGV_FrasesH.DataSource = Nothing
                    If (tabla.Rows.Count > 0) Then
                        DGV_Consulta.DataSource = tabla

                    End If
                    '                 
                Catch ex As Exception

                End Try


            Case "1"
                Try
                    LstboxConsultaDatos.Items.Clear()
                    sqlconsulta = "SELECT Codigo, Descripcion, Observa Observaciones FROM FraseH WHERE Descripcion LIKE  '%" + txtConsultaDatos.Text.Trim() + "%' OR Codigo LIKE '%" + txtConsultaDatos.Text.Trim() + "%' ORDER BY Codigo"
                    Dim cmd As New SqlCommand(sqlconsulta, cn)
                    Dim dr As SqlDataReader = cmd.ExecuteReader()
                    tabla.Load(dr)
                    Dim tabla2 = TryCast(DGV_Consulta.DataSource, DataTable)
                    If tabla2 IsNot Nothing Then tabla2.Rows.Clear()
                    'DGV_FrasesH.DataSource = Nothing
                    If (tabla.Rows.Count > 0) Then
                        DGV_Consulta.DataSource = tabla

                    End If
                    '                  
                Catch ex As Exception

                End Try


            Case "2"
                Try
                    LstboxConsultaDatos.Items.Clear()
                    sqlconsulta = "SELECT Codigo, Descripcion, Observa Observaciones FROM FraseP WHERE Descripcion LIKE  '%" + txtConsultaDatos.Text.Trim() + "%' OR Codigo LIKE '%" + txtConsultaDatos.Text.Trim() + "%' ORDER BY Codigo"
                    Dim cmd As New SqlCommand(sqlconsulta, cn)
                    Dim dr As SqlDataReader = cmd.ExecuteReader()
                    tabla.Load(dr)
                    'DGV_FrasesP.DataSource = Nothing
                    Dim tabla2 = TryCast(DGV_Consulta.DataSource, DataTable)
                    If tabla2 IsNot Nothing Then tabla2.Rows.Clear()
                    If (tabla.Rows.Count > 0) Then
                        DGV_Consulta.DataSource = tabla

                    End If
                Catch ex As Exception

                End Try

        End Select

    End Sub

    Private Sub btnAnteriorPag_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAnteriorPag.Click
        txtConsultaDatos.Visible = False
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
        consultaIndice = -1
        PagLstbox = 1
        DGV_Consulta.SendToBack()
        LstboxConsultaDatos.BringToFront()
    End Sub

    Private Sub DGV_Consulta_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV_Consulta.CellDoubleClick

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

        End Try

    End Sub

    Private Sub AgregarInglesHP(ByVal Codigo As String, ByVal QueTabla As String)
        Try
            Dim cn As New SqlConnection(ConfigurationManager.ConnectionStrings("LOCAL").ToString())
            cn.Open()
            Dim sqlConsulta As String
            Dim cmd As New SqlCommand
            Dim datar As SqlDataReader
            Select Case QueTabla
                Case "FraseHINGLES"
                    Dim tabla As DataTable = TryCast(DGV_FrasesHIngles.DataSource, DataTable)

                    If (tabla Is Nothing) Then ' Creo las columbas de la tabla, porque si la tabla esta vacia no tiene formato
                        tabla = New DataTable
                        tabla.Columns.Add("Codigo")
                        tabla.Columns.Add("Descripcion")
                        DGV_FrasesHIngles.DataSource = tabla
                    End If
                    sqlConsulta = "SELECT Codigo, Descripcion = TRIM(DescripcionIngles) + ' ' + TRIM(DescripcionInglesII) + ' ' + TRIM(DescripcionInglesIII) FROM FrasehIngles WHERE Codigo = '" & Codigo & "'"
                    cmd = New SqlCommand(sqlConsulta, cn)
                    datar = cmd.ExecuteReader()
                    If (datar.HasRows) Then
                        datar.Read()
                        Dim dr As DataRow
                        dr = tabla.NewRow()
                        dr(0) = datar.Item("Codigo")
                        dr(1) = datar.Item("Descripcion")
                        tabla.Rows.Add(dr)
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
                    sqlConsulta = "SELECT Codigo, Descripcion = TRIM(DescripcionIngles) + ' ' + TRIM(DescripcionInglesII) + ' ' + TRIM(DescripcionInglesIII) FROM FrasePIngles WHERE Codigo = '" & Codigo & "'"
                    cmd = New SqlCommand(sqlConsulta, cn)
                    datar = cmd.ExecuteReader()
                    If (datar.HasRows) Then
                        datar.Read()
                        Dim dr As DataRow
                        dr = tabla.NewRow()
                        dr(0) = datar.Item("Codigo")
                        dr(1) = datar.Item("Descripcion")
                        tabla.Rows.Add(dr)
                    Else
                        MsgBox("Esta Frase no esta ingresada en ingles")
                    End If
            End Select

        Catch ex As Exception

        End Try
        
    End Sub

    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        Dim ControlPictogramas As Boolean = ValidarCbxPictogramas()
        If ControlPictogramas Then
            Dim sqlconsulta As String
            Try
                Dim cn As New SqlConnection(ConfigurationManager.ConnectionStrings("LOCAL").ToString())
                cn.Open()
                If (TipoProducto = "PT") Then
                    sqlconsulta = "DELETE FROM DatosEtiqueta WHERE Terminado = '" + masktxtCodigo.Text + "'"
                    Dim cmd2 As New SqlCommand(sqlconsulta, cn)
                    cmd2.ExecuteNonQuery()
                    sqlconsulta = "DELETE FROM DatosEtiquetaIngles WHERE Terminado = '" + masktxtCodigo.Text + "'"
                Else
                    sqlconsulta = "DELETE FROM DatosEtiquetaMp WHERE Articulo = '" + masktxtCodigo.Text + "'"
                End If


                Dim cmd As New SqlCommand(sqlconsulta, cn)
                cmd.ExecuteNonQuery()
                Dim ClaveVariable As String
                Dim Renglon = 1
                For i As Integer = 1 To 100
                    If (TipoProducto = "PT") Then
                        If (DGV_FrasesH.Rows.Count > -1) Then
                            If (i <= DGV_FrasesH.Rows.Count) Then
                                ' If Not DGV_FrasesH.Rows.Item(i - 1) Is Nothing Then
                                If DGV_FrasesH.Rows.Item(i - 1).Cells("Codigo").Value <> "" Then

                                    ClaveVariable = masktxtCodigo.Text.Trim() + Renglon.ToString().PadLeft(3, "0")

                                    sqlconsulta = "INSERT INTO DatosEtiqueta( Clave, Terminado, Renglon, Palabra, Pictograma1,"
                                    sqlconsulta = sqlconsulta & " Pictograma2, Pictograma3, Pictograma4, Pictograma5, Pictograma6,"
                                    sqlconsulta = sqlconsulta & " Pictograma7, Pictograma8, Pictograma9, Tipo, FraseH, Descripcion1H,"
                                    sqlconsulta = sqlconsulta & " Descripcion2H, Descripcion3H, FraseP, Descripcion1P , Descripcion2P,"
                                    sqlconsulta = sqlconsulta & " Descripcion3P, Observaciones, Denominacion) Values( '" & ClaveVariable & "' ,"
                                    sqlconsulta = sqlconsulta & " '" & masktxtCodigo.Text & "' , '" & Renglon & "' , '" & cbxPalabraAdvertencia.SelectedIndex & "' ,"
                                    sqlconsulta = sqlconsulta & " '" & cbxExplosivo1.SelectedIndex & "' , '" & cbxInflamable2.SelectedIndex & "' ,"
                                    sqlconsulta = sqlconsulta & " '" & cbxCarburante3.SelectedIndex & "' , '" & cbxGasesBajo4.SelectedIndex & "' ,"
                                    sqlconsulta = sqlconsulta & " '" & cbxCorrosivo5.SelectedIndex & "' , '" & cbxToxico6.SelectedIndex & "' ,"
                                    sqlconsulta = sqlconsulta & " '" & cbxPeligro7.SelectedIndex & "' , '" & cbxPeligroPLASalud8.SelectedIndex & "' ,"
                                    sqlconsulta = sqlconsulta & " '" & cbxMedioAmbiente9.SelectedIndex & "' , '" & "1" & "' , '" & DGV_FrasesH.Rows.Item(i - 1).Cells("Codigo").Value.ToString() & "' ,"
                                    sqlconsulta = sqlconsulta & " '" & Trim(DGV_FrasesH.Rows.Item(i - 1).Cells("DescripcionH").Value.ToString().PadRight(450).Substring(0, 250)) & "' , '" & Trim(DGV_FrasesH.Rows.Item(i - 1).Cells("DescripcionH").Value.ToString().PadRight(450).Substring(250, 100)) & "' ,"
                                    sqlconsulta = sqlconsulta & " '" & Trim(DGV_FrasesH.Rows.Item(i - 1).Cells("DescripcionH").Value.ToString().PadRight(450).Substring(350, 100)) & "' , '" & "" & "' ,"
                                    sqlconsulta = sqlconsulta & " '" & "" & "' , '" & "" & "' , '" & "" & "' , '" & DGV_FrasesH.Rows.Item(i - 1).Cells("ObservacionesH").Value.ToString() & "' , '" & "" & "' )"

                                    cmd = New SqlCommand(sqlconsulta, cn)
                                    cmd.ExecuteNonQuery()
                                    Renglon = Renglon + 1


                                End If
                            End If
                        End If

                        If (DGV_FrasesP.Rows.Count > -1) Then
                            If (i <= DGV_FrasesP.Rows.Count) Then

                                'If Not DGV_FrasesP.Rows.Item(i) Is Nothing Then
                                If DGV_FrasesP.Rows.Item(i - 1).Cells("CodigoFraseP").Value <> "" Then
                                    ClaveVariable = masktxtCodigo.Text.Trim() + Renglon.ToString().PadLeft(3, "0")

                                    sqlconsulta = "INSERT INTO DatosEtiqueta( Clave, Terminado, Renglon, Palabra, Pictograma1,"
                                    sqlconsulta = sqlconsulta & " Pictograma2, Pictograma3, Pictograma4, Pictograma5, Pictograma6,"
                                    sqlconsulta = sqlconsulta & " Pictograma7, Pictograma8, Pictograma9, Tipo, FraseH, Descripcion1H,"
                                    sqlconsulta = sqlconsulta & " Descripcion2H, Descripcion3H, FraseP, Descripcion1P , Descripcion2P,"
                                    sqlconsulta = sqlconsulta & " Descripcion3P, Observaciones, Denominacion) Values( '" & ClaveVariable & "' ,"
                                    sqlconsulta = sqlconsulta & " '" & masktxtCodigo.Text & "' , '" & Renglon & "' , '" & cbxPalabraAdvertencia.SelectedIndex & "' ,"
                                    sqlconsulta = sqlconsulta & " '" & cbxExplosivo1.SelectedIndex & "' , '" & cbxInflamable2.SelectedIndex & "' ,"
                                    sqlconsulta = sqlconsulta & " '" & cbxCarburante3.SelectedIndex & "' , '" & cbxGasesBajo4.SelectedIndex & "' ,"
                                    sqlconsulta = sqlconsulta & " '" & cbxCorrosivo5.SelectedIndex & "' , '" & cbxToxico6.SelectedIndex & "' ,"
                                    sqlconsulta = sqlconsulta & " '" & cbxPeligro7.SelectedIndex & "' , '" & cbxPeligroPLASalud8.SelectedIndex & "' ,"
                                    sqlconsulta = sqlconsulta & " '" & cbxMedioAmbiente9.SelectedIndex & "' , '" & "2" & "' , '" & "" & "' ,"
                                    sqlconsulta = sqlconsulta & " '" & "" & "' , '" & "" & "' ,"
                                    sqlconsulta = sqlconsulta & " '" & "" & "' , '" & DGV_FrasesP.Rows.Item(i - 1).Cells("CodigoFraseP").Value.ToString() & "' ,"
                                    sqlconsulta = sqlconsulta & " '" & Trim(DGV_FrasesP.Rows.Item(i - 1).Cells("DescripcionFraseP").Value.ToString().PadRight(450).Substring(0, 249)) + "' , '" & Trim(DGV_FrasesP.Rows.Item(i - 1).Cells("DescripcionFraseP").Value.ToString().PadRight(450).Substring(250, 100)) & "' ,"
                                    sqlconsulta = sqlconsulta & " '" & Trim(DGV_FrasesP.Rows.Item(i - 1).Cells("DescripcionFraseP").Value.ToString().PadRight(450).Substring(350, 100)) + "' , '" & DGV_FrasesP.Rows.Item(i - 1).Cells("Observaciones").Value.ToString() & "' , '" & "" & "' )"
                                    cmd = New SqlCommand(sqlconsulta, cn)
                                    cmd.ExecuteNonQuery()

                                    Renglon = Renglon + 1
                                End If
                            End If

                        End If

                        If (OrDefault(DGV_DemoCompPeligrosos.Rows(i - 1).Cells(0).Value, "") <> "") Then

                            ClaveVariable = masktxtCodigo.Text.Trim() & Renglon.ToString().PadLeft(3, "0")
                            sqlconsulta = "INSERT INTO DatosEtiqueta( Clave, Terminado, Renglon, Palabra, Pictograma1,"
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
                            cmd = New SqlCommand(sqlconsulta, cn)
                            cmd.ExecuteNonQuery()

                            Renglon = Renglon + 1

                        End If

                        If (DGV_FrasesHIngles.Rows.Count > -1) Then
                            If (i <= DGV_FrasesHIngles.Rows.Count) Then

                                ClaveVariable = masktxtCodigo.Text.Trim() + Renglon.ToString().PadLeft(3, "0")

                                sqlconsulta = "INSERT INTO DatosEtiquetaIngles (Clave ,Terminado ,Renglon ,Tipo ,"
                                sqlconsulta = sqlconsulta & "FraseHIngles ,Descripcion1HIngles ,Descripcion2HIngles ,Descripcion3HIngles ,"
                                sqlconsulta = sqlconsulta & "FrasePIngles ,Descripcion1PIngles ,Descripcion2PIngles ,Descripcion3PIngles )"
                                sqlconsulta = sqlconsulta & "Values ('" & ClaveVariable & "', '" & masktxtCodigo.Text & "', '" & Renglon & "',"
                                sqlconsulta = sqlconsulta & "'" & "4" & "', '" & DGV_FrasesHIngles.Rows.Item(i - 1).Cells("CodigoFraseHINgles").Value.ToString() + "', '" & Trim(DGV_FrasesHIngles.Rows.Item(i - 1).Cells("DescripcionFraseHINgles").Value.ToString().PadRight(450).Substring(0, 250)) & "',"
                                sqlconsulta = sqlconsulta & "'" & Trim(DGV_FrasesHIngles.Rows.Item(i - 1).Cells("DescripcionFraseHINgles").Value.ToString().PadRight(450).Substring(250, 100)) & "', '" & Trim(DGV_FrasesHIngles.Rows.Item(i - 1).Cells("DescripcionFraseHINgles").Value.ToString().PadRight(450).Substring(350, 100)) & "',"
                                sqlconsulta = sqlconsulta & "'" & "" & "',"
                                sqlconsulta = sqlconsulta & "'" & "" & "',"
                                sqlconsulta = sqlconsulta & "'" & "" & "',"
                                sqlconsulta = sqlconsulta & "'" & "" & "')"

                                cmd = New SqlCommand(sqlconsulta, cn)
                                cmd.ExecuteNonQuery()

                                Renglon = Renglon + 1

                            End If
                        End If

                        If (DGV_FrasesHIngles.Rows.Count > -1) Then
                            If (i <= DGV_FrasesHIngles.Rows.Count) Then

                                ClaveVariable = masktxtCodigo.Text.Trim() + Renglon.ToString().PadLeft(3, "0")

                                sqlconsulta = "INSERT INTO DatosEtiquetaIngles (Clave ,Terminado ,Renglon ,Tipo ,"
                                sqlconsulta = sqlconsulta & "FraseHIngles ,Descripcion1HIngles ,Descripcion2HIngles ,Descripcion3HIngles ,"
                                sqlconsulta = sqlconsulta & "FrasePIngles ,Descripcion1PIngles ,Descripcion2PIngles ,Descripcion3PIngles )"
                                sqlconsulta = sqlconsulta & "Values ('" & ClaveVariable & "', '" & masktxtCodigo.Text & "', '" & Renglon & "',"
                                sqlconsulta = sqlconsulta & "'" & "5" & "',"
                                sqlconsulta = sqlconsulta & "'" & "" & "',"
                                sqlconsulta = sqlconsulta & "'" & "" & "',"
                                sqlconsulta = sqlconsulta & "'" & "" & "',"
                                sqlconsulta = sqlconsulta & "'" & "" & "',"
                                sqlconsulta = sqlconsulta & "'" & DGV_FrasesPIngles.Rows.Item(i - 1).Cells("CodigoFrasesPIngles").Value.ToString() + "', '" & Trim(DGV_FrasesPIngles.Rows.Item(i - 1).Cells("DescripcionFrasesPIngles").Value.ToString().PadRight(450).Substring(0, 250)) & "',"
                                sqlconsulta = sqlconsulta & "'" & Trim(DGV_FrasesPIngles.Rows.Item(i - 1).Cells("DescripcionFrasesPIngles").Value.ToString().PadRight(450).Substring(250, 100)) & "', '" & Trim(DGV_FrasesPIngles.Rows.Item(i - 1).Cells("DescripcionFrasesPIngles").Value.ToString().PadRight(450).Substring(350, 100)) & "')"
                                

                                cmd = New SqlCommand(sqlconsulta, cn)
                                cmd.ExecuteNonQuery()

                                Renglon = Renglon + 1

                            End If
                        End If
                        

                    Else
                        If (DGV_FrasesH.Rows.Count > -1) Then
                            If (i <= DGV_FrasesH.Rows.Count) Then
                                ' If Not DGV_FrasesH.Rows.Item(i - 1) Is Nothing Then
                                If DGV_FrasesH.Rows.Item(i - 1).Cells("Codigo").Value <> "" Then
                                    ClaveVariable = masktxtCodigo.Text.Trim() + Renglon.ToString().PadLeft(3, "0")

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
                                    sqlconsulta = sqlconsulta & " '" & cbxMedioAmbiente9.SelectedIndex & "' , '" & "1" & "' , '" & DGV_FrasesH.Rows.Item(i - 1).Cells("Codigo").Value.ToString() & "' ,"
                                    sqlconsulta = sqlconsulta & " '" & Trim(DGV_FrasesH.Rows.Item(i - 1).Cells("DescripcionH").Value.ToString().PadRight(450).Substring(0, 250)) & "' , '" & Trim(DGV_FrasesH.Rows.Item(i - 1).Cells("DescripcionH").Value.ToString().PadRight(450).Substring(250, 100)) & "' ,"
                                    sqlconsulta = sqlconsulta & " '" & Trim(DGV_FrasesH.Rows.Item(i - 1).Cells("DescripcionH").Value.ToString().PadRight(450).Substring(350, 100)) & "' , '" & "" & "' ,"
                                    sqlconsulta = sqlconsulta & " '" & "" & "' , '" & "" & "' , '" & "" & "' , '" & DGV_FrasesH.Rows.Item(i - 1).Cells("ObservacionesH").Value.ToString() & "' , '" & "" & "' )"

                                    cmd = New SqlCommand(sqlconsulta, cn)
                                    cmd.ExecuteNonQuery()
                                    Renglon = Renglon + 1


                                End If
                            End If
                        End If

                        If (DGV_FrasesP.Rows.Count > -1) Then
                            If (i <= DGV_FrasesP.Rows.Count) Then

                                'If Not DGV_FrasesP.Rows.Item(i) Is Nothing Then
                                If DGV_FrasesP.Rows.Item(i - 1).Cells("CodigoFraseP").Value <> "" Then
                                    ClaveVariable = masktxtCodigo.Text.Trim() + Renglon.ToString().PadLeft(3, "0")

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
                                    sqlconsulta = sqlconsulta & " '" & cbxMedioAmbiente9.SelectedIndex & "' , '" & "2" & "' , '" & "" & "' ,"
                                    sqlconsulta = sqlconsulta & " '" & "" & "' , '" & "" & "' ,"
                                    sqlconsulta = sqlconsulta & " '" & "" & "' , '" & DGV_FrasesP.Rows.Item(i - 1).Cells("CodigoFraseP").Value.ToString() & "' ,"
                                    sqlconsulta = sqlconsulta & " '" & Trim(DGV_FrasesP.Rows.Item(i - 1).Cells("DescripcionFraseP").Value.ToString().PadRight(450).Substring(0, 249)) + "' , '" & Trim(DGV_FrasesP.Rows.Item(i - 1).Cells("DescripcionFraseP").Value.ToString().PadRight(450).Substring(250, 100)) & "' ,"
                                    sqlconsulta = sqlconsulta & " '" & Trim(DGV_FrasesP.Rows.Item(i - 1).Cells("DescripcionFraseP").Value.ToString().PadRight(450).Substring(350, 100)) + "' , '" & DGV_FrasesP.Rows.Item(i - 1).Cells("Observaciones").Value.ToString() & "' , '" & "" & "' )"
                                    cmd = New SqlCommand(sqlconsulta, cn)
                                    cmd.ExecuteNonQuery()

                                    Renglon = Renglon + 1
                                End If
                            End If

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
                            cmd = New SqlCommand(sqlconsulta, cn)
                            cmd.ExecuteNonQuery()

                            Renglon = Renglon + 1

                        End If
                    End If


                Next

                If (TipoProducto = "PT") Then
                    sqlconsulta = "SELECT * FROM Terminado WHERE Codigo = '" + masktxtCodigo.Text.Trim() + "'"
                Else
                    sqlconsulta = "SELECT * FROM Articulo WHERE Codigo = '" + masktxtCodigo.Text.Trim() + "'"
                End If


                cmd = New SqlCommand(sqlconsulta, cn)
                Dim dr As SqlDataReader
                dr = cmd.ExecuteReader()

                Dim VarNaciones As String
                Dim VarClase As String
                Dim VarIntervencion As String
                Dim VarEmbalaje As String
                Dim VarCaracteristicas As String
                Dim VarSecundario As String
                Dim VarRiesgo As String
                Dim VarTipoProducto As Integer
                Dim VarEstadoProducto As Integer
                Dim VarTipoEtiqueta As String

                If (dr.Read() <> Nothing) Then

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


                    ' Display message.
                    Response = MsgBox(Mensaje, estilo, titulo)
                    If Response = vbYes Then    ' User chose Yes.
                        RespuestaUsuario = "Si"    ' Perform some action.
                    Else    ' User chose No.
                        RespuestaUsuario = "No"    ' Perform some action.
                    End If

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
                                sqlconsulta = sqlconsulta + "Tipoeti = '" & txtTipoEtiqueta.Text.Trim() & "',"
                                sqlconsulta = sqlconsulta + "Naciones = '" & txtNroNacionesUnidas.Text.Trim() & "',"
                                sqlconsulta = sqlconsulta + "Clase = '" & txtClase.Text.Trim() & "',"
                                sqlconsulta = sqlconsulta + "Intervencion = '" & txtIntervencion.Text.Trim() & "',"
                                sqlconsulta = sqlconsulta + "Embalaje = '" & txtEmbalaje.Text.Trim() & "',"
                                sqlconsulta = sqlconsulta + "DescriOnu = '" & txtCaracteristicas.Text.Trim() & "',"
                                sqlconsulta = sqlconsulta + "Secundario = '" & txtSecundario.Text.Trim() & "',"
                                sqlconsulta = sqlconsulta + "Riesgo = '" & txtRiesgo.Text.Trim() & "',"
                                sqlconsulta = sqlconsulta + "EstadoProducto = '" & cbxEstado.SelectedIndex & "',"
                                sqlconsulta = sqlconsulta + "TipoProducto = '" & cbxTipoProducto.SelectedIndex & "'"
                                sqlconsulta = sqlconsulta + " WHERE Codigo = '" & masktxtCodigo.Text.Trim() & "'"
                                ExecuteNonQueries(EmpresasAgrabar(i), {sqlconsulta})
                            Next
                        Else
                            For i As Integer = 0 To 6
                                sqlconsulta = "UPDATE Articulo SET "
                                sqlconsulta = sqlconsulta + "Naciones = '" & txtNroNacionesUnidas.Text.Trim() & "',"
                                sqlconsulta = sqlconsulta + "Clase = '" & txtClase.Text.Trim() & "',"
                                sqlconsulta = sqlconsulta + "Intervencion = '" & txtIntervencion.Text.Trim() & "',"
                                sqlconsulta = sqlconsulta + "Embalaje = '" & txtEmbalaje.Text.Trim() & "',"
                                sqlconsulta = sqlconsulta + "DescriOnu = '" & txtCaracteristicas.Text.Trim() & "',"
                                sqlconsulta = sqlconsulta + "Secundario = '" & txtSecundario.Text.Trim() & "',"
                                sqlconsulta = sqlconsulta + "Riesgo = '" & txtRiesgo.Text.Trim() & "',"
                                sqlconsulta = sqlconsulta + "EstadoProducto = '" & cbxEstado.SelectedIndex & "',"
                                sqlconsulta = sqlconsulta + "TipoProducto = '" & cbxTipoProducto.SelectedIndex & "'"
                                sqlconsulta = sqlconsulta + " WHERE Codigo = '" & masktxtCodigo.Text.Trim() & "'"
                                ExecuteNonQueries(EmpresasAgrabar(i), {sqlconsulta})
                            Next

                        End If
                    End If
                End If


                dr.Close()


                Dim Palabra As Integer
                Dim LugarImpresion As Integer = 0
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
                Dim AA1 As String


                For i As Integer = 1 To 999
                    Dim clave As String = masktxtCodigo.Text + i.ToString().PadLeft(3, "0")
                    If (TipoProducto = "PT") Then
                        sqlconsulta = "SELECT * FROM DatosEtiqueta WHERE Clave = '" + clave + "'"
                    Else
                        sqlconsulta = "SELECT * FROM DatosEtiquetaMp WHERE Clave = '" + clave + "'"
                    End If

                    cmd = New SqlCommand(sqlconsulta, cn)

                    dr = cmd.ExecuteReader()

                    If (dr.Read()) Then

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


                        Select Case dr.Item("Tipo").ToString()
                            Case "1"
                                If (dr.Item("Descripcion1H") <> "") Then
                                    LugarImpresionI = LugarImpresionI + 1
                                    imprecionI(LugarImpresionI) = dr.Item("Descripcion1H")
                                End If
                                If (dr.Item("Descripcion2H") <> "") Then
                                    LugarImpresionI = LugarImpresionI + 1
                                    imprecionI(LugarImpresionI) = dr.Item("Descripcion2H")
                                End If
                                If (dr.Item("Descripcion3H") <> "") Then
                                    LugarImpresionI = LugarImpresionI + 1
                                    imprecionI(LugarImpresionI) = dr.Item("Descripcion3H")
                                End If
                            Case "2"
                                If (dr.Item("Descripcion1P") <> "") Then
                                    LugarImpresionII = LugarImpresionII + 1
                                    imprecionII(LugarImpresionII) = dr.Item("Descripcion1P")
                                End If
                                If (dr.Item("Descripcion2P") <> "") Then
                                    LugarImpresionII = LugarImpresionII + 1
                                    imprecionII(LugarImpresionII) = dr.Item("Descripcion2P")
                                End If
                                If (dr.Item("Descripcion3P") <> "") Then
                                    LugarImpresionII = LugarImpresionII + 1
                                    imprecionII(LugarImpresionII) = dr.Item("Descripcion3P")
                                End If
                                If (dr.Item("Observaciones") <> "") Then
                                    LugarImpresionII = LugarImpresionII + 1
                                    imprecionII(LugarImpresionII) = dr.Item("Observaciones")
                                End If
                            Case "3"
                                If (dr.Item("Denominacion") <> "") Then
                                    LugarImpresionIII = LugarImpresionIII + 1
                                    imprecionIII(LugarImpresionIII) = dr.Item("Denominacion")
                                End If
                        End Select
                    End If
                    dr.Close()
                Next
                'Erase ImpreFrase
                For i As Integer = 1 To 99
                    If (Trim(OrDefault(imprecionIII(i), "")) <> "") Then
                        EntraVarios = "S"
                        ImpreFrase(LugarFrase) = ImpreFrase(LugarFrase) + "" + Trim(imprecionIII(i)) + ""

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
                        AA1 = Trim(imprecionI(Ciclo))
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
                        AA1 = Trim(imprecionII(Ciclo))
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
                        For CicloII = 1 To Hasta

                            If Mid$(ImpreFrase(Ciclo), CicloII, 1) = Space$(1) Then
                                ImpreFrase(Ciclo) = Mid$(ImpreFrase(Ciclo), 1, CicloII) + " " + Mid$(ImpreFrase(Ciclo), CicloII + 1, Corte)
                                Hasta = Len(Trim(ImpreFrase(Ciclo)))
                                CicloII = CicloII + 1
                                If CicloII = Corte Or Hasta = Corte Then
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
                If Palabra = 2 Then
                    ImpreFrase(8) = "ATENCION"
                End If
                If (TipoProducto = "PT") Then
                    sqlconsulta = "UPDATE DatosEtiqueta SET "
                    sqlconsulta = sqlconsulta + "Frase1 = '" + ImpreFrase(1).left(80) + "',"
                    sqlconsulta = sqlconsulta + "Frase2 = '" + ImpreFrase(2).left(80) + "',"
                    sqlconsulta = sqlconsulta + "Frase3 = '" + ImpreFrase(3).left(80) + "',"
                    sqlconsulta = sqlconsulta + "Frase4 = '" + ImpreFrase(4).left(80) + "',"
                    sqlconsulta = sqlconsulta + "Frase5 = '" + ImpreFrase(5).left(80) + "',"
                    sqlconsulta = sqlconsulta + "Frase6 = '" + ImpreFrase(6).left(80) + "',"
                    sqlconsulta = sqlconsulta + "Frase7 = '" + ImpreFrase(7).left(80) + "',"
                    sqlconsulta = sqlconsulta + "Frase8 = '" + ImpreFrase(8).left(80) + "'"
                    sqlconsulta = sqlconsulta + " Where Terminado = '" + masktxtCodigo.Text + "'"
                Else
                    sqlconsulta = "UPDATE DatosEtiquetaMp SET "
                    sqlconsulta = sqlconsulta + "Frase1 = '" + ImpreFrase(1).left(80) + "',"
                    sqlconsulta = sqlconsulta + "Frase2 = '" + ImpreFrase(2).left(80) + "',"
                    sqlconsulta = sqlconsulta + "Frase3 = '" + ImpreFrase(3).left(80) + "',"
                    sqlconsulta = sqlconsulta + "Frase4 = '" + ImpreFrase(4).left(80) + "',"
                    sqlconsulta = sqlconsulta + "Frase5 = '" + ImpreFrase(5).left(80) + "',"
                    sqlconsulta = sqlconsulta + "Frase6 = '" + ImpreFrase(6).left(80) + "',"
                    sqlconsulta = sqlconsulta + "Frase7 = '" + ImpreFrase(7).left(80) + "',"
                    sqlconsulta = sqlconsulta + "Frase8 = '" + ImpreFrase(8).left(80) + "'"
                    sqlconsulta = sqlconsulta + " Where Articulo = '" + masktxtCodigo.Text + "'"
                End If

                
                cmd = New SqlCommand(sqlconsulta, cn)
                cmd.ExecuteNonQuery()

                If (TipoProducto = "PT") Then

                    ' genera etiquetas para colorantes 14 renglones
                    ' a 100 caracteres
                    LugarImpresion = 0
                    LugarImpresionI = 0
                    LugarImpresionII = 0
                    LugarImpresionIII = 0
                    

                    sqlconsulta = "SELECT * FROM DatosEtiqueta WHERE Terminado = '" & masktxtCodigo.Text.Trim() & "' ORDER BY Clave"
               
                cmd = New SqlCommand(sqlconsulta, cn)

                dr = cmd.ExecuteReader()

                    If (dr.Read()) Then

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


                        Select Case dr.Item("Tipo").ToString()
                            Case "1"
                                If (dr.Item("Descripcion1H") <> "") Then
                                    LugarImpresionI = LugarImpresionI + 1
                                    imprecionI(LugarImpresionI) = dr.Item("Descripcion1H")
                                End If
                                If (dr.Item("Descripcion2H") <> "") Then
                                    LugarImpresionI = LugarImpresionI + 1
                                    imprecionI(LugarImpresionI) = dr.Item("Descripcion2H")
                                End If
                                If (dr.Item("Descripcion3H") <> "") Then
                                    LugarImpresionI = LugarImpresionI + 1
                                    imprecionI(LugarImpresionI) = dr.Item("Descripcion3H")
                                End If
                            Case "2"
                                If (dr.Item("Descripcion1P") <> "") Then
                                    LugarImpresionII = LugarImpresionII + 1
                                    imprecionII(LugarImpresionII) = dr.Item("Descripcion1P")
                                End If
                                If (dr.Item("Descripcion2P") <> "") Then
                                    LugarImpresionII = LugarImpresionII + 1
                                    imprecionII(LugarImpresionII) = dr.Item("Descripcion2P")
                                End If
                                If (dr.Item("Descripcion3P") <> "") Then
                                    LugarImpresionII = LugarImpresionII + 1
                                    imprecionII(LugarImpresionII) = dr.Item("Descripcion3P")
                                End If
                                If (dr.Item("Observaciones") <> "") Then
                                    LugarImpresionII = LugarImpresionII + 1
                                    imprecionII(LugarImpresionII) = dr.Item("Observaciones")
                                End If
                            Case "3"
                                If (dr.Item("Denominacion") <> "") Then
                                    LugarImpresionIII = LugarImpresionIII + 1
                                    imprecionIII(LugarImpresionIII) = dr.Item("Denominacion")
                                End If
                        End Select
                    End If
                    dr.Close()

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
                            AA1 = Trim(imprecionI(Ciclo))
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
                            AA1 = Trim(imprecionII(Ciclo))
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
                    cmd = New SqlCommand(sqlconsulta, cn)
                    cmd.ExecuteNonQuery()

                    sqlconsulta = "INSERT INTO DatosEtiquetaImpre (Terminado, Pictograma1, Pictograma2, Pictograma3,"
                    sqlconsulta = sqlconsulta & "Pictograma4, Pictograma5, Pictograma6, Pictograma7, Pictograma8,"
                    sqlconsulta = sqlconsulta & "Pictograma9, Frase9, Frase10, Frase11, Frase12, Frase13, Frase14,"
                    sqlconsulta = sqlconsulta & "Frase15, Frase16, Frase17, Frase18, Frase19, Frase20, Frase21,"
                    sqlconsulta = sqlconsulta & "Frase22, Frase23) Values('" & masktxtCodigo.Text & "',"
                    sqlconsulta = sqlconsulta & "'" & cbxExplosivo1.SelectedIndex.ToString() & "',"
                    sqlconsulta = sqlconsulta & "'" & cbxInflamable2.SelectedIndex.ToString() & "',"
                    sqlconsulta = sqlconsulta & "'" & cbxCarburante3.SelectedIndex.ToString() & "',"
                    sqlconsulta = sqlconsulta & "'" & cbxGasesBajo4.SelectedIndex.ToString() & "',"
                    sqlconsulta = sqlconsulta & "'" & cbxCorrosivo5.SelectedIndex.ToString() & "',"
                    sqlconsulta = sqlconsulta & "'" & cbxToxico6.SelectedIndex.ToString() & "',"
                    sqlconsulta = sqlconsulta & "'" & cbxPeligro7.SelectedIndex.ToString() & "',"
                    sqlconsulta = sqlconsulta & "'" & cbxPeligroPLASalud8.SelectedIndex.ToString() & "',"
                    sqlconsulta = sqlconsulta & "'" & cbxMedioAmbiente9.SelectedIndex.ToString() & "',"
                    sqlconsulta = sqlconsulta & "'" & ImpreFrase(1).left(100) & "',"
                    sqlconsulta = sqlconsulta & "'" & ImpreFrase(2).left(100) & "',"
                    sqlconsulta = sqlconsulta & "'" & ImpreFrase(3).left(100) & "',"
                    sqlconsulta = sqlconsulta & "'" & ImpreFrase(4).left(100) & "',"
                    sqlconsulta = sqlconsulta & "'" & ImpreFrase(5).left(100) & "',"
                    sqlconsulta = sqlconsulta & "'" & ImpreFrase(6).left(100) & "',"
                    sqlconsulta = sqlconsulta & "'" & ImpreFrase(7).left(100) & "',"
                    sqlconsulta = sqlconsulta & "'" & ImpreFrase(8).left(100) & "',"
                    sqlconsulta = sqlconsulta & "'" & ImpreFrase(9).left(100) & "',"
                    sqlconsulta = sqlconsulta & "'" & ImpreFrase(10).left(100) & "',"
                    sqlconsulta = sqlconsulta & "'" & ImpreFrase(11).left(100) & "',"
                    sqlconsulta = sqlconsulta & "'" & ImpreFrase(12).left(100) & "',"
                    sqlconsulta = sqlconsulta & "'" & ImpreFrase(13).left(100) & "',"
                    sqlconsulta = sqlconsulta & "'" & ImpreFrase(14).left(100) & "',"
                    sqlconsulta = sqlconsulta & "'" & ImpreFrase(15).left(100) & "')"

                    cmd = New SqlCommand(sqlconsulta, cn)
                    cmd.ExecuteNonQuery()

                    '
                    ' arma frase en inlgles
                    '
                    '
                    '
                    '
                    ' genera etiquetas para colorantes 8 renglones
                    ' a 80 caracteres
                    '
                    dr.Close()

                    LugarImpresion = 0
                    LugarImpresionI = 0
                    LugarImpresionII = 0
                    LugarImpresionIII = 0


                    sqlconsulta = "SELECT * FROM DatosEtiqueta WHERE Terminado = '" & masktxtCodigo.Text.Trim() & "' ORDER BY Clave"

                    cmd = New SqlCommand(sqlconsulta, cn)

                    dr = cmd.ExecuteReader()

                    If (dr.Read()) Then

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

                    dr.Close()

                    sqlconsulta = "SELECT * FROM DatosEtiquetaIngles WHERE Terminado = '" & masktxtCodigo.Text.Trim() & "' ORDER BY Clave"

                    cmd = New SqlCommand(sqlconsulta, cn)

                    dr = cmd.ExecuteReader()

                    If (dr.Read()) Then
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
                            AA1 = Trim(imprecionI(Ciclo))
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
                            AA1 = Trim(imprecionII(Ciclo))
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
                    dr.Close()
                    cmd = New SqlCommand(sqlconsulta, cn)
                    cmd.ExecuteNonQuery()



                    '
                    ' genera etiquetas para colorantes 14 renglones
                    ' a 100 caracteres
                    '

                    LugarImpresion = 0
                    LugarImpresionI = 0
                    LugarImpresionII = 0
                    LugarImpresionIII = 0


                    sqlconsulta = "SELECT * FROM DatosEtiqueta WHERE Terminado = '" & masktxtCodigo.Text.Trim() & "' ORDER BY Clave"

                    cmd = New SqlCommand(sqlconsulta, cn)

                    dr = cmd.ExecuteReader()

                    If (dr.Read()) Then

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

                    dr.Close()

                    sqlconsulta = "SELECT * FROM DatosEtiquetaIngles WHERE Terminado = '" & masktxtCodigo.Text.Trim() & "' ORDER BY Clave"

                    cmd = New SqlCommand(sqlconsulta, cn)

                    dr = cmd.ExecuteReader()

                    If (dr.Read()) Then
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
                            AA1 = Trim(imprecionI(Ciclo))
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
                            AA1 = Trim(imprecionII(Ciclo))
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
                    sqlconsulta = sqlconsulta & "Frase9Ingles = '" & ImpreFrase(1).left(100) & "',"
                    sqlconsulta = sqlconsulta & "Frase10Ingles = '" & ImpreFrase(2).left(100) & "',"
                    sqlconsulta = sqlconsulta & "Frase11Ingles = '" & ImpreFrase(3).left(100) & "',"
                    sqlconsulta = sqlconsulta & "Frase12Ingles = '" & ImpreFrase(4).left(100) & "',"
                    sqlconsulta = sqlconsulta & "Frase13Ingles = '" & ImpreFrase(5).left(100) & "',"
                    sqlconsulta = sqlconsulta & "Frase14Ingles = '" & ImpreFrase(6).left(100) & "',"
                    sqlconsulta = sqlconsulta & "Frase15Ingles = '" & ImpreFrase(7).left(100) & "',"
                    sqlconsulta = sqlconsulta & "Frase16Ingles = '" & ImpreFrase(8).left(100) & "',"
                    sqlconsulta = sqlconsulta & "Frase17Ingles = '" & ImpreFrase(9).left(100) & "',"
                    sqlconsulta = sqlconsulta & "Frase18Ingles = '" & ImpreFrase(10).left(100) & "',"
                    sqlconsulta = sqlconsulta & "Frase19Ingles = '" & ImpreFrase(11).left(100) & "',"
                    sqlconsulta = sqlconsulta & "Frase20Ingles = '" & ImpreFrase(12).left(100) & "',"
                    sqlconsulta = sqlconsulta & "Frase21Ingles = '" & ImpreFrase(13).left(100) & "',"
                    sqlconsulta = sqlconsulta & "Frase22Ingles = '" & ImpreFrase(14).left(100) & "',"
                    sqlconsulta = sqlconsulta & "Frase23Ingles = '" & ImpreFrase(15).left(100) & "'"
                    sqlconsulta = sqlconsulta & " Where Terminado = '" & masktxtCodigo.Text.Trim() & "'"

                    dr.Close()

                    cmd = New SqlCommand(sqlconsulta, cn)
                    cmd.ExecuteNonQuery()
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

    Private Sub btnImprimirReporte_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimirReporte.Click

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

    Private Sub masktxtCodigo_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles masktxtCodigo.MouseDoubleClick
        pnlConsultarDatos.Visible = True
        txtConsultaDatos.Visible = True
        DGV_Consulta.BringToFront()
        LstboxConsultaDatos.SendToBack()
        Try
            consultaIndice = 0
            LstboxConsultaDatos.Items.Clear()
            Dim cn As New SqlConnection(ConfigurationManager.ConnectionStrings("LOCAL").ToString())
            cn.Open()
            Dim tabla As New DataTable
            Dim sqlConsulta As String
            If (TipoProducto = "MP") Then
                sqlConsulta = "SELECT Codigo, Descripcion FROM Articulo ORDER BY Codigo"
            Else
                sqlConsulta = "SELECT Codigo, Descripcion FROM Terminado ORDER BY Codigo"
            End If

            Dim cmd As New SqlCommand(sqlConsulta, cn)

            Dim dr As SqlDataReader = cmd.ExecuteReader()
            tabla.Load(dr)
            If (tabla.Rows.Count > 0) Then
                DGV_Consulta.DataSource = tabla

            End If



        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnVolver_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVolver.Click
        Me.Close()
    End Sub



 

    Private Sub DGV_FrasesH_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV_FrasesH.CellDoubleClick

        Dim tabla As DataTable = TryCast(DGV_FrasesH.DataSource, DataTable)
        Dim codigoH As String
        codigoH = DGV_FrasesH.CurrentRow.Cells("Codigo").Value.ToString().Trim()
        tabla.Rows.RemoveAt(DGV_FrasesH.CurrentRow.Index)
        Try
            If (TipoProducto = "PT") Then
                Dim tabla2 As DataTable = TryCast(DGV_FrasesHIngles.DataSource, DataTable)
                Dim RowABorrar As DataRow
                For Each row As DataRow In tabla2.Rows
                    If ((row.Item("Codigo").ToString()).Trim() = codigoH) Then

                        RowABorrar = row
                        'tabla2.Rows.Remove(row)
                    End If
                Next
                tabla2.Rows.Remove(RowABorrar)
            End If
        Catch ex As Exception

        End Try

        
    End Sub

 


    Private Sub DGV_FrasesP_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV_FrasesP.CellDoubleClick
        Dim tabla As DataTable = TryCast(DGV_FrasesP.DataSource, DataTable)
        Dim codigo As String
        codigo = DGV_FrasesP.CurrentRow.Cells("CodigoFraseP").Value.ToString().Trim()
        tabla.Rows.RemoveAt(DGV_FrasesP.CurrentRow.Index)
        Try
            If (TipoProducto = "PT") Then
                Dim tabla2 As DataTable = TryCast(DGV_FrasesPIngles.DataSource, DataTable)
                Dim RowABorrar As DataRow
                For Each row As DataRow In tabla2.Rows
                    If ((row.Item("Codigo").ToString()).Trim() = codigo) Then

                        RowABorrar = row
                        'tabla2.Rows.Remove(row)
                    End If
                Next
                tabla2.Rows.Remove(RowABorrar)
            End If
        Catch ex As Exception

        End Try
    End Sub


    Private Sub masktxtCodigo_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles masktxtCodigo.Leave
        If (ComprobarEnter = "" Or ComprobarEnter <> masktxtCodigo.Text) Then
            masktxtCodigo_KeyDown(Nothing, New KeyEventArgs(Keys.Enter))
        End If
    End Sub

    
    Private Sub cbxExplosivo1_DropDownClosed(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbxExplosivo1.DropDownClosed, cbxToxico6.DropDownClosed, cbxPeligroPLASalud8.DropDownClosed, cbxPeligro7.DropDownClosed, cbxMedioAmbiente9.DropDownClosed, cbxInflamable2.DropDownClosed, cbxCorrosivo5.DropDownClosed, cbxCarburante3.DropDownClosed, cbxGasesBajo4.DropDownClosed
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

    Private Sub IngresoDatosAdicMP_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        btnLimpiar_Click(Nothing, Nothing)
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

    Private Function VerRepetidosenDGV(ByVal Tipo As Integer, ByVal Codigo As String) As Boolean
        Select Case Tipo
            Case "1"
                For Each row As DataGridViewRow In DGV_FrasesH.Rows
                    If (row.Cells(0).Value.ToString().Trim() = Codigo.Trim()) Then
                        MsgBox("Esa frase H ya se encuentra en la lista")
                        Return False
                    End If
                Next
            Case "2"
                For Each row As DataGridViewRow In DGV_FrasesP.Rows
                    If (row.Cells(0).Value = Codigo) Then
                        MsgBox("Esa frase P ya se encuentra en la lista")
                        Return False
                    End If
                Next
        End Select
        Return True
    End Function

   
End Class