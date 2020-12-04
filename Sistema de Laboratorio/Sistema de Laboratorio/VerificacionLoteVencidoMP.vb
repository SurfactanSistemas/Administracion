Imports System.ComponentModel
Imports Util

Public Class VerificacionLoteVencidoMP

    Dim PermisoGrabar As Boolean = True
    Sub New(ByVal ID As String)

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Dim SQLCnslt As String = "SELECT Escritura FROM PermisosPerfiles WHERE ID = '" & ID & "' AND Sistema = 'LABORATORIO' AND Perfil = '" & Operador.Perfil & "' AND Planta = '" & Operador.Base & "' ORDER BY ID"
        Dim Row As DataRow = GetSingle(SQLCnslt, "SurfactanSa")
        If Row IsNot Nothing Then
            PermisoGrabar = Row.Item("Escritura")
        End If
    End Sub

    Private Sub VerificacionLoteVencidoMP_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        pnlContrasena.Visible = False
        CheckForIllegalCrossThreadCalls = False
        ProgressBar1.Value = 0
        ProgressBar1.Maximum = 100
        DGV_Verificacion.Columns.Cast(Of DataGridViewColumn).ToList.ForEach(Sub(c) c.ReadOnly = True)
        DGV_Verificacion.Columns("Check").ReadOnly = False

        If PermisoGrabar = False Then
            btnAjustes.Enabled = False
        End If

        Timer1.Start()
    End Sub

    Private Function _CalcularStock(ByVal CodArticulo As String, ByVal WLote As String, Optional ByVal empresa As Integer = 0) As String
        WLote = Trim(WLote)
        Dim Saldo As Double = 0
        Dim SQLCnslt As String
        If empresa = 0 Then

            For i As Integer = 1 To 7

                SQLCnslt = "SELECT Saldo = SUM(Saldo) FROM Laudo WHERE Articulo = '" & CodArticulo & "' AND Laudo = '" & WLote & "' AND Saldo > 0 And Renglon = '1' AND Marca <> 'X'"

                Dim row As DataRow = GetSingle(SQLCnslt, _AQueEmpresa(i))

                If row IsNot Nothing Then Saldo += OrDefault(row.Item("Saldo"), 0)

                SQLCnslt = "SELECT Saldo = SUM(Saldo) FROM Guia WHERE Articulo = '" & CodArticulo & "' AND Lote = '" & WLote & "' AND Saldo > 0 AND Tipo = 'M' AND Movi = 'E'"

                row = GetSingle(SQLCnslt, _AQueEmpresa(i))

                If row IsNot Nothing Then Saldo += OrDefault(row.Item("Saldo"), 0)

            Next

        Else

            SQLCnslt = "SELECT SUM(Saldo) As Saldo FROM Laudo WHERE Articulo = '" & CodArticulo & "' AND Laudo = '" & WLote & "' And Renglon = '1' AND Marca <> 'X'"

            Dim row As DataRow = GetSingle(SQLCnslt, _AQueEmpresa(empresa))

            If row IsNot Nothing Then Saldo += OrDefault(row.Item("Saldo"), 0)

            SQLCnslt = "SELECT SUM(Saldo) As Saldo FROM Guia WHERE Articulo = '" & CodArticulo & "' AND Lote = '" & WLote & "' AND Saldo > 0 AND Tipo = 'M' AND Movi = 'E'"

            row = GetSingle(SQLCnslt, _AQueEmpresa(empresa))

            If row IsNot Nothing Then Saldo += OrDefault(row.Item("Saldo"), 0)

        End If

        Return formatonumerico(Saldo)
    End Function

    Private Function _CalculaDiferenciaDias(ByVal Articulo As String, ByVal WLote As String, ByVal Empresa As String) As Integer
        Dim SQLCnslt As String
        SQLCnslt = "SELECT l.Fecha, a.Meses FROM Laudo l INNER JOIN Articulo a ON a.Codigo = l.Articulo WHERE l.Articulo = '" & Articulo & "' AND l.Laudo = '" & WLote & "' And l.Renglon = '1'"

        Dim WEnEmpresa As String = _AQueEmpresa(Empresa)

        Dim row As DataRow = GetSingle(SQLCnslt, WEnEmpresa)

        If row Is Nothing Then Return 0

        Dim WFecha, Vencimiento As String

        WFecha = OrDefault(row.Item("Fecha"), "00/00/0000")

        Dim meses As Integer = OrDefault(row.Item("Meses"), 0)

        Dim Mes As Integer = Val(Mid$(WFecha, 4, 2))
        Dim Ano As Integer = Val(WFecha.right(4))

        For i = 1 To meses
            Mes = Mes + 1
            If Mes > 12 Then
                Ano = Ano + 1
                Mes = 1
            End If
        Next

        Dim MesStr, AnoStr As String

        MesStr = Mes.Ceros(2)
        AnoStr = Ano.Ceros(4)

        If Val(WFecha.Substring(0, 2)) <= 30 Then
            If Mes = 2 AndAlso Val(WFecha.left(2)) > 28 Then
                Vencimiento = "28/" + MesStr + "/" + AnoStr
            Else
                Vencimiento = WFecha.Substring(0, 3) + MesStr + "/" + AnoStr
            End If
        Else
            If Mes = 2 Then
                Vencimiento = "28/" + MesStr + "/" + AnoStr
            Else
                Vencimiento = "30/" + MesStr + "/" + AnoStr
            End If
        End If

        Do
            If (ValidaFecha(Vencimiento) = "S") Then
                Exit Do
            Else
                Dim XFec1 As String = Vencimiento
                Dim SumaDia As Integer = 1
                Dim Xfec2 As String = _Calcula_vencimiento(XFec1, SumaDia)
                Vencimiento = Xfec2
            End If

        Loop

        Dim ComparaI, ComparaII As String

        WFecha = Date.Now.ToString("dd/MM/yyyy")

        ComparaI = WFecha
        If Microsoft.VisualBasic.Left$(Vencimiento, 2) > "28" Then
            ComparaII = "28" + Mid$(Vencimiento, 3, 8)
        Else
            ComparaII = Vencimiento
        End If

        Dim Dias As Integer = DateDiff("d", ComparaI, ComparaII)

        Return Dias

    End Function

    Private Function _Calcula_vencimiento(ByVal WFecha As String, ByVal Plazo As Integer) As String

        Dim Wvenci As String

        Dim Dg As Integer

        Dim Ano As Integer
        Dim Mes As Integer
        Dim Dia As Integer

        Dim WAno As String
        Dim WMes As String
        Dim WDia As String

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

        WDia$ = Dia.ToString().PadLeft(2, "0")

        Mes = aa

        WMes = Mes.ToString().PadLeft(2, "0")

        WAno = Ano.ToString().PadLeft(4, "0")

        Wvenci = WDia + "/" + WMes + "/" + WAno

        Return Wvenci

    End Function

    Private Function _BuscarDescripcion(ByVal CodArticulo As String) As String
        Dim row As DataRow = GetSingle("SELECT Descripcion FROM Articulo WHERE Codigo = '" & CodArticulo & "'")
        If row Is Nothing Then Return ""

        Return Trim(OrDefault(row.Item("Descripcion"), ""))
    End Function

    Private Function _AQueEmpresa(ByVal Empresa As String) As String

        Select Case Val(Empresa)
            Case 1
                Return "SurfactanSa"
            Case 2
                Return "Surfactan_II"
            Case 3
                Return "Surfactan_III"
            Case 4
                Return "Surfactan_IV"
            Case 5
                Return "Surfactan_V"
            Case 6
                Return "Surfactan_VI"
            Case Else
                Return "Surfactan_VII"
        End Select

    End Function

    Private Sub btnAjustes_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAjustes.Click
        txtpnlContrasena.Text = ""
        pnlContrasena.Visible = True
        txtpnlContrasena.Focus()
    End Sub

    Private Sub btnpnlVolver_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnpnlVolver.Click
        pnlContrasena.Visible = False
    End Sub

    Private Sub DGV_Verificacion_SortCompare(ByVal sender As Object, ByVal e As DataGridViewSortCompareEventArgs) Handles DGV_Verificacion.SortCompare

        Dim num1, num2

        Select Case e.Column.Index
            Case 4, 5, 7, 9, 10, 11, 12, 13, 14, 15

                num1 = CDbl(e.CellValue1)
                num2 = CDbl(e.CellValue2)

            Case 8

                num1 = ordenaFecha(e.CellValue1)
                num2 = ordenaFecha(e.CellValue2)

            Case Else
                Exit Sub
        End Select

        If num1 < num2 Then
            e.SortResult = -1
        ElseIf num1 = num2 Then
            e.SortResult = 0
        Else
            e.SortResult = 1
        End If

        e.Handled = True

    End Sub

    Private Sub txtpnlContrasena_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtpnlContrasena.KeyDown
        Dim hayCambios As Boolean
        Select Case e.KeyData
            Case Keys.Enter
                If UCase(txtpnlContrasena.Text) = "INSUMOS" Then

                    hayCambios = DGV_Verificacion.Rows.Cast(Of DataGridViewRow).Any(Function(r) r.Cells("Check").Value)

                    If hayCambios Then
                        _ModificarTablas()
                    Else
                        MsgBox("No hay ninguna materia prima seleccionada")
                    End If

                Else
                    txtpnlContrasena.Text = ""
                End If
            Case Keys.Escape
                txtpnlContrasena.Text = ""
        End Select
    End Sub

    Private Sub _ModificarTablas()
        For Each row As DataGridViewRow In DGV_Verificacion.Rows.Cast(Of DataGridViewRow).ToList.FindAll(Function(c) c.Visible)
            If row.Cells("Check").Value = True Then

                Dim Articulo, WLote As String
                Dim empresa As Integer = 0

                Articulo = row.Cells("MPrima").Value
                WLote = row.Cells("Lote").Value

                For Each c As String In {"SI", "SII", "SIII", "SIV", "SV", "SVI", "SVII"}
                    empresa += 1
                    GrabaPorPlanta(Articulo, WLote, empresa, row.Cells(c).Value)
                Next

            End If
        Next

        pnlContrasena.Visible = False
        DGV_Verificacion.Rows.Clear()

        If Not BackgroundWorker1.IsBusy Then BackgroundWorker1.RunWorkerAsync()
    End Sub

    Private Sub GrabaPorPlanta(ByVal Articulo As String, ByVal WLote As String, ByVal Empresa As Integer, ByVal Saldo As Double)
        Try

            Dim NroAjuste As Integer
            Dim SQLCnslt As String
            SQLCnslt = "Select MAX(Codigo), Codigo FROM Movvar"

            Dim Fila As DataRow = GetSingle(SQLCnslt, _AQueEmpresa(Empresa))
            If Fila.Item("Codigo") <> "" Then
                NroAjuste = Fila.Item("Codigo") + 1
            Else
                NroAjuste = 1
            End If

            Dim renglon As Integer
            Dim WTipo, Terminado, movi, auxiliar1, auxiliar2 As String
            Dim cantidad As String
            WTipo = "M"
            Terminado = "  -     -   "
            cantidad = Saldo
            movi = "S"

            renglon = 1
            auxiliar1 = CType(renglon, String)
            auxiliar1 = auxiliar1.PadLeft(2, "0")

            auxiliar2 = CType(NroAjuste, String)
            auxiliar2 = auxiliar2.PadLeft(6, "0")



            Dim GCodigo, GRenglon, Gfecha, GFechaord, Gtipo, GArticulo, GTerminado, GCantidad As String
            Dim GMovi, GTipomov, GObservaciones, GClave, GDate, GMarca, GLote, GSaldo As String



            GCodigo = CType(NroAjuste, String)
            GRenglon = CType(renglon, String)
            Gfecha = Date.Now.ToString("dd/MM/yyyy")
            GFechaord = ordenaFecha(Gfecha)
            Gtipo = WTipo
            GArticulo = Articulo
            GTerminado = Terminado
            GCantidad = formatonumerico(cantidad)
            GMovi = movi
            GTipomov = "1"
            GObservaciones = "Ajuste de saldos de Materia Prima"
            GClave = auxiliar2 + auxiliar1
            GDate = (Date.Now.ToString("MM/dd/yyyy")).Replace("/", "-")
            GMarca = ""
            GLote = WLote


            SQLCnslt = "INSERT INTO Movvar(Clave, Codigo, Renglon, Fecha, Tipo, Articulo, Terminado, Cantidad, FechaOrd, Movi, Tipomov, Observaciones, Wdate, Marca, Lote) "
            SQLCnslt = SQLCnslt + "VALUES ('" & GClave & "', '" & GCodigo & "', '" & GRenglon & "', '" & Gfecha & "', '" & Gtipo & "', '" & GArticulo & "', '" & GTerminado & "', "
            SQLCnslt = SQLCnslt + "'" & GCantidad & "', '" & GFechaord & "', '" & GMovi & "', '" & GTipomov & "', '" & GObservaciones & "', '" & GDate & "', '" & GMarca & "', '" & GLote & "')"

            ExecuteNonQueries(_AQueEmpresa(Empresa), (SQLCnslt))

            Dim GControla As Integer
            Dim GSalidas, GEntradas As String

            SQLCnslt = "SELECT  Controla, Salidas, Entradas FROM Articulo WHERE Codigo = '" & Articulo & "'"

            Dim tabla As DataTable = GetAll(SQLCnslt, _AQueEmpresa(Empresa))

            If (tabla.Rows.Count > 0) Then
                GControla = IIf(IsDBNull(tabla.Rows(0).Item("Controla")), "0", tabla.Rows(0).Item("Controla"))
                GCodigo = Articulo
                GSalidas = (CType(tabla.Rows(0).Item("Salidas"), Double) + cantidad).ToString().Replace(",", ".")
                GEntradas = CType(tabla.Rows(0).Item("Entradas"), String).Replace(",", ".")

                SQLCnslt = "UPDATE Articulo SET Codigo = '" & GCodigo & "', Entradas = '" & GEntradas & "', Salidas = '" & GSalidas & "', WDate = '" & GDate & "' WHERE Codigo = '" & GCodigo & "'"

                ExecuteNonQueries(_AQueEmpresa(Empresa), (SQLCnslt))

                If GControla = 0 And WLote <> 0 Then

                    SQLCnslt = "SELECT Clave, Saldo FROM Laudo WHERE Articulo = '" & Articulo & "' AND laudo = '" & WLote & "' ORDER BY Laudo"

                    tabla.Clear()
                    tabla = GetAll(SQLCnslt, _AQueEmpresa(Empresa))
                    If tabla.Rows.Count > 0 Then
                        GClave = tabla.Rows(0).Item("Clave")
                        GSaldo = (tabla.Rows(0).Item("Saldo") - cantidad).ToString()

                        SQLCnslt = "UPDATE Laudo SET Clave = '" & GClave & "', WDate = '" & GDate & "', Saldo = '" & GSaldo & "' WHERE Clave = '" & GClave & "'"
                        ExecuteNonQueries(_AQueEmpresa(Empresa), (SQLCnslt))
                    Else

                        SQLCnslt = "SELECT Clave, Saldo FROM Guia WHERE Articulo = '" & Articulo & "' AND Lote = '" & WLote & "' ORDER BY Saldo DESC, FechaOrd"

                        tabla.Clear()
                        tabla = GetAll(SQLCnslt, _AQueEmpresa(Empresa))

                        If tabla.Rows.Count > 0 Then
                            GClave = tabla.Rows(0).Item("Clave")
                            GSaldo = (tabla.Rows(0).Item("Saldo") - cantidad).ToString()

                            SQLCnslt = "UPDATE Guia SET Clave = '" & GClave & "', WDate = '" & GDate & "', Saldo = '" & GSaldo & "' WHERE Clave = '" & GClave & "'"
                            ExecuteNonQueries(_AQueEmpresa(Empresa), (SQLCnslt))
                        End If
                    End If
                End If
            End If


        Catch ex As Exception
            MsgBox("no se puedo conectar")
        End Try
    End Sub

    Private Sub BackgroundWorker1_DoWork(ByVal sender As Object, ByVal e As DoWorkEventArgs) Handles BackgroundWorker1.DoWork

        Dim tablaVerificados As DataTable
        Dim SQLCnlt As String

        DGV_Verificacion.Rows.Clear()
        ProgressBar1.Value = 0
        ProgressBar1.Visible = True

        SQLCnlt = "SELECT Numero, Articulo, Fecha, EmpresaPartida, Partida, EmpresaTipo, Tipo, TipoMov FROM VerificaVtoArti WHERE Estado = 0 AND Stock > 0 AND TipoMov = 'M'  ORDER BY Codigo"

        tablaVerificados = GetAll(SQLCnlt)

        ProgressBar1.Maximum = tablaVerificados.Rows.Count + 5

        For Each row As DataRow In tablaVerificados.Rows
            BackgroundWorker1.ReportProgress(1, row)
        Next

    End Sub


    Private Sub BackgroundWorker1_ProgressChanged(ByVal sender As Object, ByVal e As ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged
        Dim row As DataRow = TryCast(e.UserState, DataRow)

        With DGV_Verificacion.Rows(DGV_Verificacion.Rows.Add())

            .Visible = False

            .Cells("SI").Value = _CalcularStock(row.Item("Articulo"), row.Item("Partida"), 1)
            .Cells("SII").Value = _CalcularStock(row.Item("Articulo"), row.Item("Partida"), 2)
            .Cells("SIII").Value = _CalcularStock(row.Item("Articulo"), row.Item("Partida"), 3)
            .Cells("SIV").Value = _CalcularStock(row.Item("Articulo"), row.Item("Partida"), 4)
            .Cells("SV").Value = _CalcularStock(row.Item("Articulo"), row.Item("Partida"), 5)
            .Cells("SVI").Value = _CalcularStock(row.Item("Articulo"), row.Item("Partida"), 6)
            .Cells("SVII").Value = _CalcularStock(row.Item("Articulo"), row.Item("Partida"), 7)

            .Cells("Stock").Value = formatonumerico(Val(.Cells("SI").Value) + Val(.Cells("SII").Value) + Val(.Cells("SIII").Value) + Val(.Cells("SIV").Value) + Val(.Cells("SV").Value) + Val(.Cells("SVI").Value) + Val(.Cells("SVII").Value))

            If .Cells("Stock").Value > 0 Then
                .Cells("MPrima").Value = row.Item("Articulo")
                .Cells("Descripcion").Value = _BuscarDescripcion(row.Item("Articulo"))
                .Cells("PlantaOrigen").Value = row.Item("EmpresaPartida")
                .Cells("Lote").Value = row.Item("Partida").ToString.Trim

                .Cells("PlantaHoja").Value = "PED"

                If UCase(row.Item("Tipo")) <> "PED." Then .Cells("PlantaHoja").Value = UCase(row.Item("EmpresaTipo"))

                .Cells("Hoja").Value = row.Item("Numero")
                .Cells("Fecha").Value = row.Item("Fecha")

                .Cells("TipoMov").Value = row.Item("TipoMov")
                .Cells("Tipo").Value = row.Item("Tipo")
                .Cells("DiferenciaEnDias").Value = _CalculaDiferenciaDias(row.Item("Articulo"), row.Item("Partida"), row.Item("EmpresaPartida"))

                .Visible = True
            End If

            ProgressBar1.Increment(1)
        End With

        DGV_Verificacion.Refresh()

    End Sub

    Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles Timer1.Tick
        BackgroundWorker1.RunWorkerAsync()
        Timer1.Stop()
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(ByVal sender As Object, ByVal e As RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted

        ProgressBar1.Value = 0
        ProgressBar1.Visible = False

    End Sub

    Private Sub DGV_Verificacion_CellMouseDoubleClick(ByVal sender As Object, ByVal e As DataGridViewCellMouseEventArgs) Handles DGV_Verificacion.CellMouseDoubleClick
        If DGV_Verificacion.CurrentCell.ColumnIndex = 5 Then
            With New DetallesEnsayosMP(DGV_Verificacion.CurrentCell.Value)
                .Show(Me)
            End With
        End If
    End Sub


    Private Sub VerificacionLoteVencidoMP_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If BackgroundWorker1.IsBusy Then BackgroundWorker1.CancelAsync()
    End Sub

End Class