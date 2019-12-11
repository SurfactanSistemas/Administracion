Imports System.Diagnostics.Eventing.Reader

Public Class VerificacionDeVencimientosMP
    Dim Referencia As Control
    Private Sub btnVolver_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVolver.Click
        Me.Close()
    End Sub



    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click

        If mastxtFecha.Text.Replace("/", "").Trim() = "" Then
            mastxtFecha.Text = Date.Today
        End If

        If mastxtDesdeArt.Text.Replace("-", "").Trim() = "" Then
            mastxtDesdeArt.Text = "AA-000-000"
        End If

        If mastxtHastaArt.Text.Replace("-", "").Trim() = "" Then
            mastxtHastaArt.Text = "ZZ-999-999"
        End If

        If txtDias.Text = "0" Or txtDias.Text = "" Then
            txtDias.Text = 30
        End If



            Dim TablaARellenar As New DataTable
            With TablaARellenar.Columns
                .Add("Laudo")
                .Add("Articulo")
                .Add("Cantidad")
                .Add("Saldo")
                .Add("Empresa")
                .Add("Vencimiento")
                .Add("VencimientoOrdenado")
                .Add("Fecha")
                .Add("Tipo")
            End With

            Dim TablaReporteVerificacionVenmientosMP As New DataTable
            With TablaReporteVerificacionVenmientosMP.Columns
                .Add("Laudo")
                .Add("Fecha")
                .Add("FechaOrdenada")
                .Add("Articulo")
                .Add("Cantidad")
                .Add("Saldo")
                .Add("Vencimiento")
                .Add("Empresa")
                .Add("DescripArticulo")
                .Add("Dias")
            End With

            Dim Titulo As String
            Titulo = "Del " + mastxtDesdeArt.Text + " Hasta el " + mastxtHastaArt.Text + " con diferencia de : " + txtDias.Text + " Dias"

            _CargarTablaParaElReporte(TablaARellenar, TablaReporteVerificacionVenmientosMP)


            With New VistaPrevia
                .Reporte = New ReporteVerificacionDeVencimientosMP()
                .Reporte.SetDataSource(TablaReporteVerificacionVenmientosMP)
                .Reporte.SetParameterValue("Titulo", Titulo)
                .Reporte.SetParameterValue("impreRepEmpresa", Operador.Base)
                prgbar.Visible = False
                If (rabtnPantalla.Checked = True) Then
                    .Mostrar()
                Else
                    .Imprimir()
                End If
            End With

    End Sub


    Private Sub _CargarTablaParaElReporte(ByVal TablaARellenar As DataTable, ByVal TablaReporteVerificacionVenmientosMP As DataTable)

        prgbar.Visible = True
        prgbar.Value = 0

        Dim ContadorFilas As Integer = 0
        Dim SQLCnslt As String

        'CARGO LOS LAUDOS 

        SQLCnslt = "SELECT Articulo, Liberada, Fecha, Laudo, Saldo, FechaVencimiento, OrdFechaVencimiento FROM Laudo WHERE Articulo >= "
        SQLCnslt = SQLCnslt & "'" & mastxtDesdeArt.Text & "' AND Articulo <= '" & mastxtHastaArt.Text & "' AND Saldo > 0 AND Marca <> 'X'"

        Dim TablaLaudo As DataTable = GetAll(SQLCnslt, Operador.Base)

        If TablaLaudo.Rows.Count > 0 Then
            For i As Integer = 0 To TablaLaudo.Rows.Count - 1
                TablaARellenar.Rows.Add()

                TablaARellenar.Rows(ContadorFilas).Item("Laudo") = TablaLaudo.Rows(i).Item("Laudo")
                TablaARellenar.Rows(ContadorFilas).Item("Articulo") = TablaLaudo.Rows(i).Item("Articulo")
                TablaARellenar.Rows(ContadorFilas).Item("Cantidad") = TablaLaudo.Rows(i).Item("Liberada")
                TablaARellenar.Rows(ContadorFilas).Item("Saldo") = IIf(IsDBNull(TablaLaudo.Rows(i).Item("Saldo")), "0", TablaLaudo.Rows(i).Item("Saldo"))

                TablaARellenar.Rows(ContadorFilas).Item("Empresa") = _ObtenerEmpresa(Operador.Base)

                TablaARellenar.Rows(ContadorFilas).Item("Vencimiento") = IIf(IsDBNull(TablaLaudo.Rows(i).Item("FechaVencimiento")), "", TablaLaudo.Rows(i).Item("FechaVencimiento"))
                TablaARellenar.Rows(ContadorFilas).Item("VencimientoOrdenado") = IIf(IsDBNull(TablaLaudo.Rows(i).Item("OrdFechaVencimiento")), "", TablaLaudo.Rows(i).Item("OrdFechaVencimiento"))
                TablaARellenar.Rows(ContadorFilas).Item("Fecha") = IIf(IsDBNull(TablaLaudo.Rows(i).Item("Fecha")), "", TablaLaudo.Rows(i).Item("Fecha"))
                TablaARellenar.Rows(ContadorFilas).Item("Tipo") = "L"

                ContadorFilas += 1
            Next
        End If

        'CARGO LAS GUIAS

        SQLCnslt = "SELECT Articulo, Cantidad, Lote, Saldo FROM Guia WHERE Articulo >= '" & mastxtDesdeArt.Text & "' AND Articulo <= '" & mastxtHastaArt.Text & "' "
        SQLCnslt = SQLCnslt & "AND Saldo > 0 AND Marca <> 'X' AND Codigo < 900000 AND Tipo = 'M' AND Movi = 'E'"

        Dim TablaGuia As DataTable = GetAll(SQLCnslt, Operador.Base)

        If TablaGuia.Rows.Count > 0 Then
            For i = 0 To TablaGuia.Rows.Count - 1
                TablaARellenar.Rows.Add()
                TablaARellenar.Rows(ContadorFilas).Item("Laudo") = IIf(IsDBNull(TablaGuia.Rows(i).Item("Lote")), "0", TablaGuia.Rows(i).Item("Lote"))
                TablaARellenar.Rows(ContadorFilas).Item("Articulo") = TablaGuia.Rows(i).Item("Articulo")
                TablaARellenar.Rows(ContadorFilas).Item("Cantidad") = TablaGuia.Rows(i).Item("Cantidad")
                TablaARellenar.Rows(ContadorFilas).Item("Saldo") = IIf(IsDBNull(TablaGuia.Rows(i).Item("Saldo")), "0", TablaGuia.Rows(i).Item("Saldo"))

                TablaARellenar.Rows(ContadorFilas).Item("Empresa") = ""

                TablaARellenar.Rows(ContadorFilas).Item("Vencimiento") = ""
                TablaARellenar.Rows(ContadorFilas).Item("VencimientoOrdenado") = ""
                TablaARellenar.Rows(ContadorFilas).Item("Fecha") = ""
                TablaARellenar.Rows(ContadorFilas).Item("Tipo") = "G"

                ContadorFilas += 1
            Next
            Dim vuelta As Integer = 0
            For i = 0 To TablaARellenar.Rows.Count - 1
                If TablaARellenar.Rows(i).Item("Tipo") = "G" Then
                    SQLCnslt = "SELECT Fecha, FechaVencimiento, OrdFechaVencimiento FROM Laudo WHERE Laudo = '" & TablaARellenar.Rows(i).Item("Laudo") & "' "
                    SQLCnslt = SQLCnslt & "AND Articulo = '" & TablaARellenar.Rows(i).Item("Articulo") & "'"

                    For j As Integer = 1 To 11
                        Dim row As DataRow = GetSingle(SQLCnslt, _ObtenerEmpresa(Operador.Base, j), True)
                        If row IsNot Nothing Then
                            TablaARellenar.Rows(i).Item("Empresa") = _ObtenerEmpresa(_ObtenerEmpresa(Operador.Base, j))

                            TablaARellenar.Rows(i).Item("Vencimiento") = IIf(IsDBNull(row.Item("fechavencimiento")), "", row.Item("fechavencimiento"))
                            TablaARellenar.Rows(i).Item("VencimientoOrdenado") = IIf(IsDBNull(row.Item("OrdFechaVencimiento")), "", row.Item("OrdFechaVencimiento"))
                            TablaARellenar.Rows(i).Item("Fecha") = IIf(IsDBNull(row.Item("Fecha")), "", row.Item("Fecha"))
                            Exit For
                        End If
                    Next
                End If

                Dim Vto As String = ""
                Dim Auxi As String

                With TablaARellenar.Rows(i)

                    Dim OrdFecha As String = Microsoft.VisualBasic.Right$(.Item("Fecha"), 4) + Mid$(.Item("Fecha"), 4, 2) + Microsoft.VisualBasic.Left$(.Item("Fecha"), 2)
                    If .Item("Vencimiento") <> "" And .Item("Vencimiento") <> "  /  /    " And .Item("Vencimiento") <> "00/00/0000" Then
                        Auxi = Valida_fecha(.Item("Vencimiento"))
                        If Auxi = "S" Then
                            Vto = .Item("Vencimiento")
                        End If
                    End If

                    If Vto = "" Then

                        Dim Meses As Integer = 0

                        SQLCnslt = "SELECT Meses FROM Articulo WHERE Codigo = '" & .Item("Articulo") & "'"

                        Dim row As DataRow = GetSingle(SQLCnslt)

                        If row.Item("Meses") <> 0 Then
                            Meses = row.Item("Meses")
                        End If

                        Dim Mes As Integer = Val(Microsoft.VisualBasic.Mid$(.Item("Fecha"), 4, 2))
                        Dim Ano As Integer = Val(Microsoft.VisualBasic.Right$(.Item("Fecha"), 4))

                        For ZCiclo = 1 To Meses
                            Mes = Mes + 1
                            If Mes > 12 Then
                                Ano = Ano + 1
                                Mes = 1
                            End If
                        Next ZCiclo

                        Dim MesX As String = (Mes).ToString()
                        Dim AnoX As String = (Ano).ToString()
                        MesX = MesX.PadLeft(2, "0")
                        AnoX = AnoX.PadLeft(4, "0")

                        If Val(Microsoft.VisualBasic.Left$(.Item("Fecha"), 2)) <= 30 Then
                            If Val(MesX) = 2 And Val(Microsoft.VisualBasic.Left$(.Item("Fecha"), 2)) > 28 Then
                                Vto = "28/" + MesX + "/" + AnoX
                            Else
                                Vto = Microsoft.VisualBasic.Left$(.Item("Fecha"), 3) + MesX + "/" + AnoX
                            End If
                        Else
                            If Val(MesX) = 2 Then
                                Vto = "28/" + MesX + "/" + AnoX
                            Else
                                Vto = "30/" + MesX + "/" + AnoX
                            End If
                        End If

                    End If

                    If .Item("Fecha") <> "" Then
                        Dim Xfec1, XFec2 As String
                        Dim SumaDia As String

                        Do
                            Auxi = Valida_fecha(Vto)
                            If Auxi = "S" Then
                                Exit Do
                            Else
                                Xfec1 = Vto
                                SumaDia = 1
                                XFec2 = _Calcula_vencimiento(Xfec1, SumaDia)
                                Vto = XFec2
                            End If
                        Loop

                        REM WFechaActual = Right$(Fecha.Text, 4) + Mid$(Fecha.Text, 4, 2) + Left$(Fecha.Text, 2)
                        REM WFechaVto = Right$(ZVto, 4) + Mid$(ZVto, 4, 2) + Left$(ZVto, 2)

                        Select Case Val(Mid$(Vto, 4, 2))
                            Case 2
                                If Val(Mid$(Vto, 1, 2)) > 28 Then
                                    Vto = "28" + Mid$(Vto, 3, 6)
                                End If
                            Case Else
                                If Val(Mid$(Vto, 1, 2)) > 31 Then
                                    Vto = "30" + Mid$(Vto, 3, 6)
                                End If
                        End Select

                        Dim ComparaI As String = mastxtFecha.Text
                        Dim ComparaII As String = Vto
                        Dim Dias As Integer = DateDiff("d", ComparaI, ComparaII)

                        SQLCnslt = "SELECT Descripcion FROM Articulo WHERE Codigo = '" & .Item("Articulo") & "'"
                        Dim fila As DataRow = GetSingle(SQLCnslt)

                        Dim DescripcionBuscada As String = fila.Item("Descripcion")


                        If Val(Dias) > (Val(txtDias.Text) * (-1)) And Val(Dias) < Val(txtDias.Text) Then
                            TablaReporteVerificacionVenmientosMP.Rows.Add()
                            TablaReporteVerificacionVenmientosMP.Rows(vuelta).Item("Laudo") = .Item("Laudo")
                            TablaReporteVerificacionVenmientosMP.Rows(vuelta).Item("Fecha") = .Item("Fecha")
                            TablaReporteVerificacionVenmientosMP.Rows(vuelta).Item("FechaOrdenada") = OrdFecha
                            TablaReporteVerificacionVenmientosMP.Rows(vuelta).Item("Articulo") = .Item("Articulo")
                            TablaReporteVerificacionVenmientosMP.Rows(vuelta).Item("Cantidad") = (formatonumerico(.Item("Cantidad"))).ToString
                            TablaReporteVerificacionVenmientosMP.Rows(vuelta).Item("Saldo") = (formatonumerico(.Item("Saldo"))).ToString
                            TablaReporteVerificacionVenmientosMP.Rows(vuelta).Item("Vencimiento") = Vto
                            TablaReporteVerificacionVenmientosMP.Rows(vuelta).Item("DescripArticulo") = DescripcionBuscada
                            TablaReporteVerificacionVenmientosMP.Rows(vuelta).Item("Empresa") = .Item("Empresa")
                            TablaReporteVerificacionVenmientosMP.Rows(vuelta).Item("Dias") = Dias

                            vuelta += 1
                            prgbar.Value += 1
                        End If
                    End If
                End With
            Next
            prgbar.Value = 500
        End If

    End Sub



    Private Sub SoloNumero(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles mastxtFecha.KeyPress, txtDias.KeyPress, mastxtHastaArt.KeyPress, mastxtDesdeArt.KeyPress
        If Not Char.IsNumber(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub





    Private Function _Calcula_vencimiento(ByVal WFecha As String, ByVal Plazo As Integer) As String

        Dim Dg As Integer
        Dim Ano As Integer
        Dim WAno As String
        Dim Mes As Integer
        Dim WMes As String
        Dim Dia As Integer
        Dim WDia As String
        Dim Di As Integer
        Dim aa As Integer
        Dim Ds(20) As Integer

        Ds(1) = 31
        Ds(2) = 28
        Ds(3) = 31
        Ds(4) = 30
        Ds(5) = 31
        Ds(6) = 30
        Ds(7) = 31
        Ds(8) = 31
        Ds(9) = 30
        Ds(10) = 31
        Ds(11) = 30
        Ds(12) = 31

        REM   DATA "0101","0105","2505", , ,"0907", ,"1210", ,"2512", , , , , ,

        Dg = 0
        WAno = Mid$(WFecha, 7, 4)
        Ano = Val(WAno)
        WMes = Mid$(WFecha, 4, 2)
        Mes = Val(WMes)
        WDia = Mid$(WFecha, 1, 2)
        Dia = Val(WDia)

        'CANTIDAD DE DIAS HASTA LA FECHA

        Dg = Dia + Plazo - 1

        Do
            For aa = Mes To 12
                If (Ano Mod 4 = 0) And Mes = 2 Then Ds(2) = 29 Else Ds(2) = 28
                If Dg <= Ds(aa) Then Exit Do
                Dg = Dg - Ds(aa)
            Next aa
            Ano = Ano + 1
            Mes = 1
        Loop

        Dia = Dg
        WDia$ = Microsoft.VisualBasic.Right$("0" + Mid$(Str$(Dia), 2, Len(Str$(Dia)) - 1), 2)

        Mes = aa
        WMes = Microsoft.VisualBasic.Right$("0" + Mid$(Str$(Mes), 2, Len(Str$(Mes)) - 1), 2)

        WAno = Microsoft.VisualBasic.Right$("0" + Mid$(Str$(Ano), 2, Len(Str$(Ano)) - 1), 4)

        Return WDia + "/" + WMes + "/" + WAno

    End Function

    Private Function Valida_fecha(ByVal fecha As String) As String
        If fecha = Nothing Then
            Return "N"
        End If
        If _ValidarFecha(fecha) = True Then
            Return "S"
        Else
            Return "N"
        End If

    End Function


    Private Function _ObtenerEmpresa(ByVal Empresa As String, Optional ByVal NumEmpresa As Integer = 0) As String
        If NumEmpresa = 0 Then
            If UCase(Empresa) = UCase("SurfactanSA") Then
                Return "Pta SI"
            End If
            If UCase(Empresa) = UCase("Surfactan_II") Then
                Return "Pta SII"
            End If
            If UCase(Empresa) = UCase("Surfactan_III") Then
                Return "Pta SIII"
            End If
            If UCase(Empresa) = UCase("Surfactan_IV") Then
                Return "Pta SIV"
            End If
            If UCase(Empresa) = UCase("Surfactan_V") Then
                Return "Pta SV"
            End If
            If UCase(Empresa) = UCase("Surfactan_VI") Then
                Return "Pta SVI"
            End If
            If UCase(Empresa) = UCase("Surfactan_VII") Then
                Return "Pta SVII"
            End If
            If UCase(Empresa) = UCase("PellitalSA") Then
                Return "Pta PI"
            End If
            If UCase(Empresa) = UCase("Pelitall_II") Then
                Return "Pta PII"
            End If
            If UCase(Empresa) = UCase("Pellital_III") Then
                Return "Pta PIII"
            End If
            If UCase(Empresa) = UCase("Pellital_V") Then
                Return "Pta PV"
            End If
        Else
            If NumEmpresa = 1 Then
                Return "SurfactanSA"
            End If
            If NumEmpresa = 2 Then
                Return "Surfactan_II"
            End If
            If NumEmpresa = 3 Then
                Return "Surfactan_III"
            End If
            If NumEmpresa = 4 Then
                Return "Surfactan_IV"
            End If
            If NumEmpresa = 5 Then
                Return "Surfactan_V"
            End If
            If NumEmpresa = 6 Then
                Return "Surfactan_VI"
            End If
            If NumEmpresa = 7 Then
                Return "Surfactan_VII"
            End If
            If NumEmpresa = 8 Then
                Return "PellitalSA"
            End If
            If NumEmpresa = 9 Then
                Return "Pelitall_II"
            End If
            If NumEmpresa = 10 Then
                Return "Pellital_III"
            End If
            If NumEmpresa = 11 Then
                Return "Pellital_V"
            End If
        End If

    End Function


    Private Sub mastxtFecha_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles mastxtFecha.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                If mastxtFecha.Text.Length = 10 Then
                    If ValidaFecha(mastxtFecha.Text) = "S" Then
                        mastxtDesdeArt.Focus()
                    End If
                End If
            Case Keys.Escape
                mastxtFecha.Text = ""
        End Select
    End Sub

    Private Sub mastxtDesdeArt_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles mastxtDesdeArt.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                If mastxtDesdeArt.Text.Replace("-", "").Trim() = "" Then
                    mastxtDesdeArt.Text = "AA-000-000"
                End If
                If mastxtDesdeArt.Text.Length = 10 Then
                    mastxtHastaArt.Focus()
                End If
            Case Keys.Escape
                mastxtDesdeArt.Text = ""
        End Select
    End Sub

    Private Sub mastxtHastaArt_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles mastxtHastaArt.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                If mastxtHastaArt.Text.Replace("-", "").Trim() = "" Then
                    mastxtHastaArt.Text = "ZZ-999-999"
                End If
                If mastxtHastaArt.Text.Length = 10 Then
                    txtDias.Focus()
                End If
            Case Keys.Escape
                mastxtHastaArt.Text = ""
        End Select
    End Sub

    Private Sub txtDias_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDias.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                If txtDias.Text <> "" Then
                    btnAceptar_Click(Nothing, Nothing)
                End If
        End Select
    End Sub

    Private Sub mastxtDesdeArt_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles mastxtDesdeArt.MouseDoubleClick
        _CargarDGV_Ayuda()
        Referencia = mastxtDesdeArt
        pnlAyuda.Visible = True
    End Sub

    Private Sub btnPnlVolver_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPnlVolver.Click
        pnlAyuda.Visible = False
    End Sub

    Private Sub _CargarDGV_Ayuda()
        Dim SQLCnslt As String = "SELECT Codigo, Descripcion FROM Articulo"
        Dim tabla As DataTable = GetAll(SQLCnslt)
        If tabla.Rows.Count > 0 Then
            DGV_Ayuda.DataSource = tabla
        End If
    End Sub

    Private Sub DGV_Ayuda_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV_Ayuda.CellClick
        Referencia.Text = DGV_Ayuda.CurrentRow.Cells("Codigo").Value
        pnlAyuda.Visible = False
    End Sub

    Private Sub btnBuscarDesde_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarDesde.Click
        _CargarDGV_Ayuda()
        Referencia = mastxtDesdeArt
        pnlAyuda.Visible = True
    End Sub

    Private Sub mastxtHastaArt_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles mastxtHastaArt.MouseDoubleClick
        _CargarDGV_Ayuda()
        Referencia = mastxtHastaArt
        pnlAyuda.Visible = True
    End Sub

    Private Sub btnBuscarHasta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarHasta.Click
        _CargarDGV_Ayuda()
        Referencia = mastxtHastaArt
        pnlAyuda.Visible = True
    End Sub

    
    Private Sub txtAyuda_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtAyuda.KeyUp
        Dim tabla2 As DataTable = TryCast(DGV_Ayuda.DataSource, DataTable)
        If tabla2 IsNot Nothing Then
            tabla2.DefaultView.RowFilter = "Codigo LIKE '%" & txtAyuda.Text & "%' OR Descripcion LIKE '%" & txtAyuda.Text & "%'"
        End If
        
    End Sub

    Private Sub VerificacionDeVencimientosMP_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        mastxtFecha.Text = Date.Today

    End Sub

    Private Sub VerificacionDeVencimientosMP_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        mastxtDesdeArt.Focus()
    End Sub
End Class