Imports Util
Imports Util.Clases.Query
Imports Util.Clases.Helper

Public Class Ventana_auxiliar : Implements IConsulta_MP

    Dim WAccion As Integer
    Dim Wcbx_ActivaPosition As Integer
    Dim TablaFiltro As New DataTable

          

    Sub New(ByVal Accion As Integer, Optional ByVal cbx_Activas As Integer = 0)

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        With TablaFiltro.Columns
            .Add("pasar")
            .Add("mostrar")
        End With

        WAccion = Accion
        Wcbx_ActivaPosition = cbx_Activas

        Select Case Accion
            Case 1
                TabControl1.Size = New Size(241, 85)
                Me.Size = New Size(261, 176)

                txt_FiltroOrden.Focus()

                TabControl1.TabPages.Remove(TabControl1.TabPages(7))
                TabControl1.TabPages.Remove(TabControl1.TabPages(6))
                TabControl1.TabPages.Remove(TabControl1.TabPages(5))
                TabControl1.TabPages.Remove(TabControl1.TabPages(4))
                TabControl1.TabPages.Remove(TabControl1.TabPages(3))
                TabControl1.TabPages.Remove(TabControl1.TabPages(2))
                TabControl1.TabPages.Remove(TabControl1.TabPages(1))

            Case 2
                TabControl1.Size = New Size(241, 85)
                Me.Size = New Size(261, 176)

                TabControl1.TabPages.Remove(TabControl1.TabPages(7))
                TabControl1.TabPages.Remove(TabControl1.TabPages(6))
                TabControl1.TabPages.Remove(TabControl1.TabPages(5))
                TabControl1.TabPages.Remove(TabControl1.TabPages(4))
                TabControl1.TabPages.Remove(TabControl1.TabPages(3))
                TabControl1.TabPages.Remove(TabControl1.TabPages(2))
                TabControl1.TabPages.Remove(TabControl1.TabPages(0))

            Case 3

                TabControl1.Size = New Size(241, 85)
                Me.Size = New Size(261, 176)

                txt_DesdeFecha.Focus()

                TabControl1.TabPages.Remove(TabControl1.TabPages(7))
                TabControl1.TabPages.Remove(TabControl1.TabPages(6))
                TabControl1.TabPages.Remove(TabControl1.TabPages(5))
                TabControl1.TabPages.Remove(TabControl1.TabPages(4))
                TabControl1.TabPages.Remove(TabControl1.TabPages(3))
                TabControl1.TabPages.Remove(TabControl1.TabPages(1))
                TabControl1.TabPages.Remove(TabControl1.TabPages(0))

            Case 4, 6, 7


                TablaFiltro.Rows.Clear()

                Dim VectorEmpre(7) As String

                VectorEmpre(1) = "SurfactanSa"
                VectorEmpre(2) = "Surfactan_II"
                VectorEmpre(3) = "Surfactan_III"
                VectorEmpre(4) = "Surfactan_V"
                VectorEmpre(5) = "Surfactan_VI"
                VectorEmpre(6) = "Surfactan_VII"


                For i = 1 To 6



                    Dim Pasa As Integer = 0
                    Dim Corte As String = ""
                    Dim SQLCnslt As String

                    Select Case Accion
                        Case 4
                            SQLCnslt = "SELECT Proveedor FROM Orden " _
                                        & "WHERE Tipo = 1 AND Cantidad <> 0 " _
                                        & "ORDER BY Proveedor"
                        Case 6
                            SQLCnslt = "SELECT Djai FROM Orden " _
                                        & " WHERE Tipo = 1 AND Cantidad <> 0 " _
                                        & " ORDER BY Djai"
                        Case 7
                            SQLCnslt = "SELECT Origen FROM Orden " _
                                        & "WHERE Tipo = 1 AND Cantidad <> 0 " _
                                        & "ORDER BY Origen"
                        Case Else
                    End Select




                    Dim TablaConsulta As DataTable = GetAll(SQLCnslt, VectorEmpre(i))

                    If TablaConsulta.Rows.Count > 0 Then

                        For Each RowConsulta As DataRow In TablaConsulta.Rows
                            Dim ZZCompara As String = ""

                            Select Case Accion
                                Case 4
                                    ZZCompara = RowConsulta.Item("Proveedor")
                                Case 6
                                    Dim ZDJai As String = IIf(IsDBNull(RowConsulta.Item("DJai")), "", RowConsulta.Item("DJai"))
                                    ZZCompara = ZDJai
                                Case 7
                                    ZZCompara = RowConsulta.Item("Origen")
                            End Select

                            If Trim(ZZCompara) <> "" Then

                                If Pasa = 0 Then
                                    Pasa = 1
                                    Corte = ZZCompara
                                End If

                                If Corte <> ZZCompara Then

                                    Dim ZZEntra As String = "S"
                                    For x = 0 To TablaFiltro.Rows.Count - 1
                                        If Corte = TablaFiltro.Rows(x).Item(0) Then
                                            ZZEntra = "N"
                                            Exit For
                                        End If
                                    Next


                                    If ZZEntra = "S" Then

                                        TablaFiltro.Rows.Add(Corte, Corte)

                                    End If
                                    Corte = ZZCompara
                                End If

                            End If





                        Next


                    End If

                Next





                If Accion = 4 Then
                    For Each Row As DataRow In TablaFiltro.Rows
                        Dim ZZProveedor As String = Row.Item(0)

                        Dim SQLCnslt As String = "SELECT Nombre FROM Proveedor " _
                                                    & "WHERE Proveedor = '" & ZZProveedor & "'"
                        Dim RowProv As DataRow = GetSingle(SQLCnslt, Operador.Base)
                        If RowProv IsNot Nothing Then
                            Row.Item(1) = RowProv.Item("Nombre")

                        End If
                    Next
                End If


                lbx_467.Items.Add("")
                For Each Row As DataRow In TablaFiltro.Rows
                    lbx_467.Items.Add(Row.Item(1))
                Next


                TabControl1.Size = New Size(313, 204)
                Me.Size = New Size(328, 242)

                TabControl1.TabPages.Remove(TabControl1.TabPages(7))
                TabControl1.TabPages.Remove(TabControl1.TabPages(6))
                TabControl1.TabPages.Remove(TabControl1.TabPages(5))
                TabControl1.TabPages.Remove(TabControl1.TabPages(4))
                TabControl1.TabPages.Remove(TabControl1.TabPages(2))
                TabControl1.TabPages.Remove(TabControl1.TabPages(1))
                TabControl1.TabPages.Remove(TabControl1.TabPages(0))

            Case 5

                TabControl1.Size = New Size(241, 85)
                Me.Size = New Size(261, 176)

                txt_Carpeta.Focus()

                TabControl1.TabPages.Remove(TabControl1.TabPages(7))
                TabControl1.TabPages.Remove(TabControl1.TabPages(6))
                TabControl1.TabPages.Remove(TabControl1.TabPages(5))
                TabControl1.TabPages.Remove(TabControl1.TabPages(3))
                TabControl1.TabPages.Remove(TabControl1.TabPages(2))
                TabControl1.TabPages.Remove(TabControl1.TabPages(1))
                TabControl1.TabPages.Remove(TabControl1.TabPages(0))


            Case 8, 9, 11, 12, 13
                Select Case Accion


                    Case 8

                        lbl_Cambiar.Text = "Incoterms"

                        cbx_8al13.Items.Clear()
                        cbx_8al13.Items.Add("")
                        cbx_8al13.Items.Add("FOB")
                        cbx_8al13.Items.Add("CIF")
                        cbx_8al13.Items.Add("CFR")
                        cbx_8al13.Items.Add("CPT")
                        cbx_8al13.Items.Add("EXW")
                        cbx_8al13.Items.Add("FCA")


                    Case 9

                        lbl_Cambiar.Text = "Transporte"

                        cbx_8al13.Items.Clear()
                        cbx_8al13.Items.Add("")
                        cbx_8al13.Items.Add("Maritmo")
                        cbx_8al13.Items.Add("Terrestre")
                        cbx_8al13.Items.Add("Aere")


                    Case 11

                        lbl_Cambiar.Text = "T.Pago"


                        cbx_8al13.Items.Clear()
                        cbx_8al13.Items.Add("")
                        cbx_8al13.Items.Add("Pago Anti.")
                        cbx_8al13.Items.Add("A la vista")
                        cbx_8al13.Items.Add("Cta.Cte.")


                    Case 12

                        lbl_Cambiar.Text = "Pago Despacho"

                        cbx_8al13.Items.Clear()
                        cbx_8al13.Items.Add("")
                        cbx_8al13.Items.Add("Pendiente")
                        cbx_8al13.Items.Add("Pagado")

                        '                        ZZFiltro(1, 1) = "0"
                        '                        ZZFiltro(2, 1) = "1"


                    Case 13

                        lbl_Cambiar.Text = "Pago Letra"

                        cbx_8al13.Items.Clear()
                        cbx_8al13.Items.Add("")
                        cbx_8al13.Items.Add("Pendiente")
                        cbx_8al13.Items.Add("Pagado")

                        '                        ZZFiltro(1, 1) = "0"
                        '                        ZZFiltro(2, 1) = "1"

                End Select

                TabControl1.Size = New Size(241, 85)
                Me.Size = New Size(261, 176)

                TabControl1.TabPages.Remove(TabControl1.TabPages(7))
                TabControl1.TabPages.Remove(TabControl1.TabPages(6))
                TabControl1.TabPages.Remove(TabControl1.TabPages(4))
                TabControl1.TabPages.Remove(TabControl1.TabPages(3))
                TabControl1.TabPages.Remove(TabControl1.TabPages(2))
                TabControl1.TabPages.Remove(TabControl1.TabPages(1))
                TabControl1.TabPages.Remove(TabControl1.TabPages(0))

            Case 10


                TabPage2.Text = "Fecha LLegada"
                TabControl1.Size = New Size(241, 85)
                Me.Size = New Size(261, 176)

                txt_DesdeFecha.Focus()

                TabControl1.TabPages.Remove(TabControl1.TabPages(7))
                TabControl1.TabPages.Remove(TabControl1.TabPages(6))
                TabControl1.TabPages.Remove(TabControl1.TabPages(5))
                TabControl1.TabPages.Remove(TabControl1.TabPages(4))
                TabControl1.TabPages.Remove(TabControl1.TabPages(3))
                TabControl1.TabPages.Remove(TabControl1.TabPages(1))
                TabControl1.TabPages.Remove(TabControl1.TabPages(0))

            Case 14

                TabPage2.Text = "Vto Letra"
                TabControl1.Size = New Size(241, 85)
                Me.Size = New Size(261, 176)

                txt_DesdeFecha.Focus()

                TabControl1.TabPages.Remove(TabControl1.TabPages(7))
                TabControl1.TabPages.Remove(TabControl1.TabPages(6))
                TabControl1.TabPages.Remove(TabControl1.TabPages(5))
                TabControl1.TabPages.Remove(TabControl1.TabPages(4))
                TabControl1.TabPages.Remove(TabControl1.TabPages(3))
                TabControl1.TabPages.Remove(TabControl1.TabPages(1))
                TabControl1.TabPages.Remove(TabControl1.TabPages(0))

            Case 15

                TabControl1.Size = New Size(241, 85)
                Me.Size = New Size(261, 176)

                txt_Articulo.Focus()

                TabControl1.TabPages.Remove(TabControl1.TabPages(7))
                TabControl1.TabPages.Remove(TabControl1.TabPages(5))
                TabControl1.TabPages.Remove(TabControl1.TabPages(4))
                TabControl1.TabPages.Remove(TabControl1.TabPages(3))
                TabControl1.TabPages.Remove(TabControl1.TabPages(2))
                TabControl1.TabPages.Remove(TabControl1.TabPages(1))
                TabControl1.TabPages.Remove(TabControl1.TabPages(0))

            Case 20


                TabControl1.Size = New Size(241, 85)
                Me.Size = New Size(261, 176)

                txt_Articulo.Focus()

                TabControl1.TabPages.Remove(TabControl1.TabPages(6))
                TabControl1.TabPages.Remove(TabControl1.TabPages(5))
                TabControl1.TabPages.Remove(TabControl1.TabPages(4))
                TabControl1.TabPages.Remove(TabControl1.TabPages(3))
                TabControl1.TabPages.Remove(TabControl1.TabPages(2))
                TabControl1.TabPages.Remove(TabControl1.TabPages(1))
                TabControl1.TabPages.Remove(TabControl1.TabPages(0))
        End Select



    End Sub



    Private Sub SoloNumero(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_FiltroOrden.KeyPress, txt_Carpeta.KeyPress
        If Not Char.IsNumber(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub







    Public Sub PasaCodigo(Codigo As String, Accion As String) Implements IConsulta_MP.PasaCodigo
        txt_Articulo.Text = Codigo
    End Sub

    Private Sub lbx_467_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lbx_467.MouseDoubleClick
        If lbx_467.SelectedIndex <> 0 Then

            Dim WOwner As ICentroImportaciones_auxiliar = TryCast(Owner, ICentroImportaciones_auxiliar)
            If WOwner IsNot Nothing Then
                If WAccion = 4 Or WAccion = 6 Or WAccion = 7 Then

                    WOwner.PasaFiltro(TablaFiltro.Rows(lbx_467.SelectedIndex).Item("pasar"))
                End If

            End If
        End If

    End Sub



    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        With New Consulta_MP(1)
            .Show(Me)
        End With
    End Sub

    Private Sub btn_Aceptar_Click(sender As Object, e As EventArgs) Handles btn_Aceptar.Click

        Dim VectorEmpre(6) As String

        VectorEmpre(1) = "SurfactanSa"
        VectorEmpre(2) = "Surfactan_II"
        VectorEmpre(3) = "Surfactan_III"
        VectorEmpre(4) = "Surfactan_V"
        VectorEmpre(5) = "Surfactan_VI"
        VectorEmpre(6) = "Surfactan_VII"



        Select Case WAccion
            Case 1

                For i = 1 To 6

                    Dim SQLCnslt As String = "SELECT  Recibida, pagoletra " _
                        & " FROM Orden " _
                        & " Where Orden.Orden = '" & Trim(txt_FiltroOrden.Text) & "'" _
                        & " and fechaord >=20140101"

                    Dim RowOrden As DataRow = GetSingle(SQLCnslt, VectorEmpre(i))
                    If RowOrden IsNot Nothing Then


                        Dim ZEntra As String
                        If Wcbx_ActivaPosition <> 1 Then
                            If RowOrden.Item("Recibida") <> 0 And RowOrden.Item("PagoLetra") = 1 Then
                                ZEntra = "N"
                            Else
                                ZEntra = "S"
                            End If
                        Else
                            If RowOrden.Item("Recibida") <> 0 And RowOrden.Item("PagoLetra") = 1 Then
                                ZEntra = "S"
                            Else
                                ZEntra = "N"
                            End If
                        End If

                        If ZEntra = "S" Then

                            Dim WOwner As ICentroImportaciones_auxiliar = TryCast(Owner, ICentroImportaciones_auxiliar)
                            If WOwner IsNot Nothing Then

                                WOwner.PasaOrden(txt_FiltroOrden.Text, VectorEmpre(i))
                                Me.Close()
                                Exit Sub
                            End If

                        End If

                    End If

                Next

                MsgBox("No se encontro la Orden, verificar")

                txt_FiltroOrden.Focus()
                txt_FiltroOrden.SelectAll()


            Case 2

                Dim WOwner As ICentroImportaciones_auxiliar = TryCast(Owner, ICentroImportaciones_auxiliar)
                If WOwner IsNot Nothing Then

                    WOwner.PasaFiltro(cbx_Empresa.SelectedIndex)

                End If


            Case 3


                Dim VerificaDesde As String = ValidaFecha(txt_DesdeFecha.Text)
                Dim VerificaHasta As String = ValidaFecha(txt_HastaFecha.Text)

                If VerificaDesde <> "S" Or VerificaHasta <> "S" Then

                    If VerificaDesde <> "S" Then
                        MsgBox("Fecha desde es invalida, verificar")
                    End If

                    If VerificaDesde <> "S" Then
                        MsgBox("Fecha hasta es invalida, verificar")
                    End If
                    Exit Sub
                End If

                Dim WDesdeFecha As String = ordenaFecha(txt_DesdeFecha.Text)
                Dim WHastaFecha As String = ordenaFecha(txt_HastaFecha.Text)


                Dim WOwner As ICentroImportaciones_auxiliar = TryCast(Owner, ICentroImportaciones_auxiliar)
                If WOwner IsNot Nothing Then

                    WOwner.pasafechas(WDesdeFecha, WHastaFecha)

                End If

            Case 5

                For i = 1 To 6

                    Dim SQLCnslt As String = "SELECT  Recibida, pagoletra " _
                           & " FROM Orden " _
                           & " Where Carpeta = '" & Trim(txt_Carpeta.Text) & "'" _
                           & " and fechaord >=20140101"

                    Dim RowOrden As DataRow = GetSingle(SQLCnslt, VectorEmpre(i))
                    If RowOrden IsNot Nothing Then


                        Dim ZEntra As String
                        If Wcbx_ActivaPosition <> 1 Then
                            If RowOrden.Item("Recibida") <> 0 And RowOrden.Item("PagoLetra") = 1 Then
                                ZEntra = "N"
                            Else
                                ZEntra = "S"
                            End If
                        Else
                            If RowOrden.Item("Recibida") <> 0 And RowOrden.Item("PagoLetra") = 1 Then
                                ZEntra = "S"
                            Else
                                ZEntra = "N"
                            End If
                        End If

                        If ZEntra = "S" Then

                            Dim WOwner As ICentroImportaciones_auxiliar = TryCast(Owner, ICentroImportaciones_auxiliar)
                            If WOwner IsNot Nothing Then

                                WOwner.PasaCarpeta(txt_Carpeta.Text, VectorEmpre(i))
                                Me.Close()
                                Exit Sub
                            End If

                        End If

                    End If

                Next

                MsgBox("No se encontro la Carpeta, verificar")

                txt_Carpeta.Focus()
                txt_Carpeta.SelectAll()


            Case 8

                Dim WOwner As ICentroImportaciones_auxiliar = TryCast(Owner, ICentroImportaciones_auxiliar)
                If WOwner IsNot Nothing Then

                    WOwner.PasaFiltro(cbx_8al13.SelectedIndex)

                End If

            Case 9

                Dim WOwner As ICentroImportaciones_auxiliar = TryCast(Owner, ICentroImportaciones_auxiliar)
                If WOwner IsNot Nothing Then

                    WOwner.PasaFiltro(cbx_8al13.SelectedIndex)

                End If

            Case 10

                Dim VerificaDesde As String = ValidaFecha(txt_DesdeFecha.Text)
                Dim VerificaHasta As String = ValidaFecha(txt_HastaFecha.Text)

                If VerificaDesde <> "S" Or VerificaHasta <> "S" Then

                    If VerificaDesde <> "S" Then
                        MsgBox("Fecha desde es invalida, verificar")
                    End If

                    If VerificaDesde <> "S" Then
                        MsgBox("Fecha hasta es invalida, verificar")
                    End If
                    Exit Sub
                End If

                Dim WDesdeFecha As String = ordenaFecha(txt_DesdeFecha.Text)
                Dim WHastaFecha As String = ordenaFecha(txt_HastaFecha.Text)


                Dim WOwner As ICentroImportaciones_auxiliar = TryCast(Owner, ICentroImportaciones_auxiliar)
                If WOwner IsNot Nothing Then

                    WOwner.pasafechas(WDesdeFecha, WHastaFecha)

                End If

            Case 11

                Dim WOwner As ICentroImportaciones_auxiliar = TryCast(Owner, ICentroImportaciones_auxiliar)
                If WOwner IsNot Nothing Then

                    WOwner.PasaFiltro(cbx_8al13.SelectedIndex)

                End If

            Case 12

                Dim WOwner As ICentroImportaciones_auxiliar = TryCast(Owner, ICentroImportaciones_auxiliar)
                If WOwner IsNot Nothing Then
                    'Le resto uno para que las opciones se iguales a los valores 0 y 1
                    WOwner.PasaFiltro(cbx_8al13.SelectedIndex - 1)

                End If

            Case 13
                Dim WOwner As ICentroImportaciones_auxiliar = TryCast(Owner, ICentroImportaciones_auxiliar)
                If WOwner IsNot Nothing Then
                    'Le resto uno para que las opciones se iguales a los valores 0 y 1
                    WOwner.PasaFiltro(cbx_8al13.SelectedIndex - 1)

                End If

            Case 14

                Dim VerificaDesde As String = ValidaFecha(txt_DesdeFecha.Text)
                Dim VerificaHasta As String = ValidaFecha(txt_HastaFecha.Text)

                If VerificaDesde <> "S" Or VerificaHasta <> "S" Then

                    If VerificaDesde <> "S" Then
                        MsgBox("Fecha desde es invalida, verificar")
                    End If

                    If VerificaDesde <> "S" Then
                        MsgBox("Fecha hasta es invalida, verificar")
                    End If
                    Exit Sub
                End If

                Dim WDesdeFecha As String = ordenaFecha(txt_DesdeFecha.Text)
                Dim WHastaFecha As String = ordenaFecha(txt_HastaFecha.Text)


                Dim WOwner As ICentroImportaciones_auxiliar = TryCast(Owner, ICentroImportaciones_auxiliar)
                If WOwner IsNot Nothing Then

                    WOwner.pasafechas(WDesdeFecha, WHastaFecha)

                End If

            Case 15

                Dim WOwner As ICentroImportaciones_auxiliar = TryCast(Owner, ICentroImportaciones_auxiliar)
                If WOwner IsNot Nothing Then

                    WOwner.PasaFiltro(txt_Articulo.Text)

                End If

            Case 20
                Dim WOwner As ICentroImportaciones_auxiliar = TryCast(Owner, ICentroImportaciones_auxiliar)
                If WOwner IsNot Nothing Then

                    WOwner.PasaTXTDjai(txt_Informar.Text)

                End If

        End Select
    End Sub

End Class