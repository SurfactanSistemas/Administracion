Imports System.Data.SqlClient
Imports ConsultasVarias

Public Class VerificacionLoteVencidoMP

    Private Sub VerificacionLoteVencidoMP_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Text = ""
        pnlContrasena.Visible = False
        CheckForIllegalCrossThreadCalls = False
        ProgressBar1.Value = 0
        ProgressBar1.Maximum = 100
        For Each columna As DataGridViewColumn In DGV_Verificacion.Columns
            columna.ReadOnly = True
        Next
        DGV_Verificacion.Columns("Check").ReadOnly = False
        'BackgroundWorker1.RunWorkerAsync()
        Timer1.Start()
    End Sub

    Private Function _CalcularStock(ByVal CodArticulo As String, ByVal Lote As String, Optional ByVal empresa As Integer = 0) As Double
        Lote = Trim(Lote)
        Dim Saldo As Double = 0
        Dim SQLCnslt As String
        Dim tablaGuia As New DataTable
        Dim tablaLaudo As New DataTable
        If empresa = 0 Then
            For i As Integer = 1 To 7

                SQLCnslt = "SELECT Saldo FROM Laudo WHERE Articulo = '" & CodArticulo & "' AND Laudo = '" & Lote & "' AND Saldo > 0 AND Marca <> 'X' ORDER BY Laudo"
                tablaLaudo = GetAll(SQLCnslt, _AQueEmpresa(i))
                If tablaLaudo.Rows.Count > 0 Then
                    For j As Integer = 0 To tablaLaudo.Rows.Count - 1
                        Saldo += tablaLaudo.Rows(j).Item("Saldo")
                    Next
                End If

                SQLCnslt = "SELECT Saldo FROM Guia WHERE Articulo = '" & CodArticulo & "' AND Lote = '" & Lote & "' AND Saldo > 0 AND Tipo = 'M' AND Movi = 'E' ORDER BY Codigo"
                tablaGuia = GetAll(SQLCnslt, _AQueEmpresa(i))
                If tablaGuia.Rows.Count > 0 Then
                    For j As Integer = 0 To tablaGuia.Rows.Count - 1
                        Saldo += tablaGuia.Rows(j).Item("Saldo")
                    Next
                End If

            Next


            Return Saldo
        Else


            SQLCnslt = "SELECT Saldo FROM Laudo WHERE Articulo = '" & CodArticulo & "' AND Laudo = '" & Lote & "' AND Saldo > 0 AND Marca <> 'X' ORDER BY Laudo"
            tablaLaudo = GetAll(SQLCnslt, _AQueEmpresa(empresa))
            If tablaLaudo.Rows.Count > 0 Then
                For j As Integer = 0 To tablaLaudo.Rows.Count - 1
                    Saldo += tablaLaudo.Rows(j).Item("Saldo")
                Next
            End If

            SQLCnslt = "SELECT Saldo FROM Guia WHERE Articulo = '" & CodArticulo & "' AND Lote = '" & Lote & "' AND Saldo > 0 AND Tipo = 'M' AND Movi = 'E' ORDER BY Codigo"
            tablaGuia = GetAll(SQLCnslt, _AQueEmpresa(empresa))
            If tablaGuia.Rows.Count > 0 Then
                For j As Integer = 0 To tablaGuia.Rows.Count - 1
                    Saldo += tablaGuia.Rows(j).Item("Saldo")
                Next
            End If

            Return Saldo
        End If
    End Function

    Private Function _CalculaDiferenciaDias(ByVal Articulo As String, ByVal Lote As String, ByVal Empresa As String) As Integer
        Dim SQLCnslt As String
        SQLCnslt = "SELECT Fecha, FechaVencimiento FROM Laudo WHERE Articulo = '" & Articulo & "' AND Laudo = '" & Lote & "'"

        Dim row As DataRow = GetSingle(SQLCnslt, _AQueEmpresa(Empresa))

        Dim Fecha, FechaVto, FechaOrd, Vencimiento As String

        Vencimiento = ""

        Fecha = row.Item("Fecha")
        FechaVto = IIf(IsDBNull(row.Item("FechaVencimiento")), "", row.Item("FechaVencimiento"))

        FechaOrd = CType(ordenaFecha(Fecha), String)

        If (FechaVto <> "" And FechaVto <> "  /  /    " And FechaVto <> "00/00/0000") Then
            If (ValidaFecha(FechaVto) = "S") Then
                Vencimiento = FechaVto
            End If
        End If

        Dim meses As Integer = 0

        If Vencimiento = "" Then


            SQLCnslt = "SELECT Meses FROM Articulo WHERE Codigo = '" & Articulo & "'"

            row = GetSingle(SQLCnslt, _AQueEmpresa(Empresa))

            meses = row.Item("Meses")

        End If

        Dim Mes As Integer = Val(Mid$(Fecha, 4, 2))
        Dim Ano As Integer = Val(Fecha.Substring(6, 4))

        For i = 1 To meses
            Mes = Mes + 1
            If Mes > 12 Then
                Ano = Ano + 1
                Mes = 1
            End If
        Next

        Dim MesStr, AnoStr As String

        MesStr = Mes.ToString().PadLeft(2, "0")
        AnoStr = Ano.ToString().PadLeft(4, "0")

        If Val(Fecha.Substring(0, 2)) <= 30 Then
            If Mes = 2 And Val(Fecha.Substring(0, 2)) > 28 Then
                Vencimiento = "28/" + MesStr + "/" + AnoStr
            Else
                Vencimiento = Fecha.Substring(0, 3) + MesStr + "/" + AnoStr
            End If
        Else
            If Mes = 2 Then
                Vencimiento = "28/" + MesStr + "/" + AnoStr
            Else
                Vencimiento = "30/" + MesStr + "/" + AnoStr
            End If
        End If

        If Vencimiento <> "" Then

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

            Fecha = Date.Now.ToString("dd/MM/yyyy")


            ComparaI = Fecha
            If Microsoft.VisualBasic.Left$(Vencimiento, 2) > "28" Then
                ComparaII = "28" + Mid$(Vencimiento, 3, 8)
            Else
                ComparaII = Vencimiento
            End If

            Dim Dias As Integer = DateDiff("d", ComparaI, ComparaII)

            Return Dias
        End If
        Return 0
    End Function

    Private Function _Calcula_vencimiento(ByVal WFecha As String, ByVal Plazo As Integer) As String

        Dim Wvenci As String

        Dim Dg As Integer
        Dim Ano As Integer
        Dim WAno As String
        Dim Mes As Integer
        Dim WMes As String
        Dim Dia As Integer
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

        WDia$ = Dia.ToString().PadLeft(2, "0")



        Mes = aa

        WMes = Mes.ToString().PadLeft(2, "0")

        WAno = Ano.ToString().PadLeft(4, "0")


        Wvenci = WDia + "/" + WMes + "/" + WAno

        Return Wvenci

    End Function



    Private Function _BuscarDescripcion(ByVal CodArticulo As String) As String
        Dim SQLCnsl As String
        Dim row As DataRow
        SQLCnsl = "SELECT Descripcion FROM Articulo WHERE Codigo = '" & CodArticulo & "'"
        row = GetSingle(SQLCnsl)
        Return row.Item("Descripcion")
    End Function

    Private Function _AQueEmpresa(ByVal Empresa As String) As String
        If (Empresa = "1") Then
            Return "SurfactanSa"
        End If
        If (Empresa = "2") Then
            Return "Surfactan_II"
        End If
        If (Empresa = "3") Then
            Return "Surfactan_III"
        End If
        If (Empresa = "4") Then
            Return "Surfactan_IV"
        End If
        If (Empresa = "5") Then
            Return "Surfactan_V"
        End If
        If (Empresa = "6") Then
            Return "Surfactan_VI"
        End If

        Return "Surfactan_VII"

    End Function

    Private Sub btnVolver_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVolver.Click
        Me.Close()
    End Sub


    Private Sub btnAjustes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAjustes.Click
        txtpnlContrasena.Text = ""
        pnlContrasena.Visible = True
        txtpnlContrasena.Focus()
    End Sub

    Private Sub btnpnlVolver_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnpnlVolver.Click
        pnlContrasena.Visible = False
    End Sub

    Private Sub DGV_Verificacion_SortCompare(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewSortCompareEventArgs) Handles DGV_Verificacion.SortCompare

        Dim num1, num2

        Select Case e.Column.Index
            '            Case 4
            '
            '                num1 = e.CellValue1
            '                num2 = e.CellValue2
            '
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


    Private Sub txtpnlContrasena_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtpnlContrasena.KeyDown
        Dim hayCambios As Boolean = False
        Select Case e.KeyData
            Case Keys.Enter
                If UCase(txtpnlContrasena.Text) = "INSUMOS" Then

                    For Each Row As DataGridViewRow In DGV_Verificacion.Rows
                        If (Row.Cells("Check").Value = True) Then
                            hayCambios = True
                            Exit For
                        End If
                    Next
                    If hayCambios = True Then
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
        For Each row As DataGridViewRow In DGV_Verificacion.Rows
            If row.Cells("Check").Value = True Then
                Dim Articulo, Lote As String
                Dim empresa As Integer
                Dim saldo As Double
                Dim SI, SII, SIII, SIV, SV, SVI, SVII As Double

                Articulo = row.Cells("MPrima").Value
                Lote = row.Cells("Lote").Value

                SI = row.Cells("SI").Value
                SII = row.Cells("SII").Value
                SIII = row.Cells("SIII").Value
                SIV = row.Cells("SIV").Value
                SV = row.Cells("SV").Value
                SVI = row.Cells("SVI").Value
                SVII = row.Cells("SVII").Value

                If SI <> 0 Then
                    empresa = 1
                    saldo = SI
                    GrabaPorPlanta(Articulo, Lote, empresa, saldo)
                End If
                If SII <> 0 Then
                    empresa = 2
                    saldo = SII
                    GrabaPorPlanta(Articulo, Lote, empresa, saldo)
                End If
                If SIII <> 0 Then
                    empresa = 3
                    saldo = SIII
                    GrabaPorPlanta(Articulo, Lote, empresa, saldo)
                End If
                If SIV <> 0 Then
                    empresa = 4
                    saldo = SIV
                    GrabaPorPlanta(Articulo, Lote, empresa, saldo)
                End If
                If SV <> 0 Then
                    empresa = 5
                    saldo = SV
                    GrabaPorPlanta(Articulo, Lote, empresa, saldo)
                End If
                If SVI <> 0 Then
                    empresa = 6
                    saldo = SVI
                    GrabaPorPlanta(Articulo, Lote, empresa, saldo)
                End If
                If SVII <> 0 Then
                    empresa = 7
                    saldo = SVII
                    GrabaPorPlanta(Articulo, Lote, empresa, saldo)
                End If
            End If
        Next
        pnlContrasena.Visible = False
        DGV_Verificacion.Rows.Clear()
        If Not BackgroundWorker1.IsBusy Then BackgroundWorker1.RunWorkerAsync()
    End Sub

    Private Sub GrabaPorPlanta(ByVal Articulo As String, ByVal Lote As String, ByVal Empresa As Integer, ByVal Saldo As Double)
        Try

            Dim NroAjuste As Integer = 0
            Dim SQLCnslt As String
            SQLCnslt = "Select MAX(Codigo), Codigo FROM Movvar"

            Dim Fila As DataRow = GetSingle(SQLCnslt, _AQueEmpresa(Empresa))
            If Fila.Item("Codigo") <> "" Then
                NroAjuste = Fila.Item("Codigo") + 1
            Else
                NroAjuste = 1
            End If

            Dim renglon As Integer
            Dim Tipo, Terminado, movi, auxiliar1, auxiliar2 As String
            Dim cantidad As String
            Tipo = "M"
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
            Gtipo = Tipo
            GArticulo = Articulo
            GTerminado = Terminado
            GCantidad = formatonumerico(cantidad)
            GMovi = movi
            GTipomov = "1"
            GObservaciones = "Ajuste de saldos de Materia Prima"
            GClave = auxiliar2 + auxiliar1
            GDate = (Date.Now.ToString("MM/dd/yyyy")).Replace("/", "-")
            GMarca = ""
            GLote = Lote


            SQLCnslt = "INSERT INTO Movvar(Clave, Codigo, Renglon, Fecha, Tipo, Articulo, Terminado, Cantidad, FechaOrd, Movi, Tipomov, Observaciones, Wdate, Marca, Lote) "
            SQLCnslt = SQLCnslt + "VALUES ('" & GClave & "', '" & GCodigo & "', '" & GRenglon & "', '" & Gfecha & "', '" & Gtipo & "', '" & GArticulo & "', '" & GTerminado & "', "
            SQLCnslt = SQLCnslt + "'" & GCantidad & "', '" & GFechaord & "', '" & GMovi & "', '" & GTipomov & "', '" & GObservaciones & "', '" & GDate & "', '" & GMarca & "', '" & GLote & "')"

            ExecuteNonQueries(_AQueEmpresa(Empresa), (SQLCnslt))

            Dim GControla As Integer = 0
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

                If GControla = 0 And Lote <> 0 Then

                    SQLCnslt = "SELECT Clave, Saldo FROM Laudo WHERE Articulo = '" & Articulo & "' AND laudo = '" & Lote & "' ORDER BY Laudo"

                    tabla.Clear()
                    tabla = GetAll(SQLCnslt, _AQueEmpresa(Empresa))
                    If tabla.Rows.Count > 0 Then
                        GClave = tabla.Rows(0).Item("Clave")
                        GSaldo = (tabla.Rows(0).Item("Saldo") - cantidad).ToString()

                        SQLCnslt = "UPDATE Laudo SET Clave = '" & GClave & "', WDate = '" & GDate & "', Saldo = '" & GSaldo & "' WHERE Clave = '" & GClave & "'"
                        ExecuteNonQueries(_AQueEmpresa(Empresa), (SQLCnslt))
                    Else

                        SQLCnslt = "SELECT Clave, Saldo FROM Guia WHERE Articulo = '" & Articulo & "' AND Lote = '" & Lote & "' ORDER BY Saldo DESC, FechaOrd"

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

    Private Sub BackgroundWorker1_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork

        Dim tablaVerificados As New DataTable
        Dim SQLCnlt As String

        SQLCnlt = "SELECT *,TipoMov =  CASE WHEN TipoMov IS NULL THEN 'M' ELSE TipoMov END FROM VerificaVtoArti WHERE Estado = 0 AND Stock > 0 AND TipoMov = 'M'  ORDER BY Codigo"

        tablaVerificados = GetAll(SQLCnlt)
        BackgroundWorker1.ReportProgress(1, tablaVerificados)

    End Sub


    Private Sub BackgroundWorker1_ProgressChanged(ByVal sender As System.Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged
        Dim tablaVerificados As DataTable = TryCast(e.UserState, DataTable)
        Dim contador As Integer = 0
        DGV_Verificacion.Rows.Clear()
        ProgressBar1.Value = 0
        ProgressBar1.Visible = True
        For Each row As DataRow In tablaVerificados.Rows

            contador = DGV_Verificacion.Rows.Add()
            'DATOS VISIBLES
            DGV_Verificacion.Rows(contador).Cells("MPrima").Value = row.Item("Articulo")
            DGV_Verificacion.Rows(contador).Cells("Descripcion").Value = _BuscarDescripcion(row.Item("Articulo"))
            DGV_Verificacion.Rows(contador).Cells("PlantaOrigen").Value = row.Item("EmpresaPartida")
            DGV_Verificacion.Rows(contador).Cells("Lote").Value = row.Item("Partida").ToString.Trim

            If (UCase(row.Item("Tipo")) = "PED.") Then
                DGV_Verificacion.Rows(contador).Cells("PlantaHoja").Value = "PED"
            Else
                DGV_Verificacion.Rows(contador).Cells("PlantaHoja").Value = UCase(row.Item("EmpresaTipo"))
            End If

            DGV_Verificacion.Rows(contador).Cells("Hoja").Value = row.Item("Numero")
            DGV_Verificacion.Rows(contador).Cells("Fecha").Value = row.Item("Fecha")
            DGV_Verificacion.Rows(contador).Cells("SI").Value = formatonumerico(_CalcularStock(row.Item("Articulo"), row.Item("Partida"), 1))
            DGV_Verificacion.Rows(contador).Cells("SII").Value = formatonumerico(_CalcularStock(row.Item("Articulo"), row.Item("Partida"), 2))
            DGV_Verificacion.Rows(contador).Cells("SIII").Value = formatonumerico(_CalcularStock(row.Item("Articulo"), row.Item("Partida"), 3))
            DGV_Verificacion.Rows(contador).Cells("SIV").Value = formatonumerico(_CalcularStock(row.Item("Articulo"), row.Item("Partida"), 4))
            DGV_Verificacion.Rows(contador).Cells("SV").Value = formatonumerico(_CalcularStock(row.Item("Articulo"), row.Item("Partida"), 5))
            DGV_Verificacion.Rows(contador).Cells("SVI").Value = formatonumerico(_CalcularStock(row.Item("Articulo"), row.Item("Partida"), 6))
            DGV_Verificacion.Rows(contador).Cells("SVII").Value = formatonumerico(_CalcularStock(row.Item("Articulo"), row.Item("Partida"), 7))
            With DGV_Verificacion.Rows(contador)
                .Cells("Stock").Value = formatonumerico(Val(.Cells("SI").Value) + Val(.Cells("SII").Value) + Val(.Cells("SIII").Value) + Val(.Cells("SIV").Value) + Val(.Cells("SV").Value) + Val(.Cells("SVI").Value) + Val(.Cells("SVII").Value))
            End With
            'DATOS INVISIBLES
            DGV_Verificacion.Rows(contador).Cells("TipoMov").Value = row.Item("TipoMov")
            DGV_Verificacion.Rows(contador).Cells("Tipo").Value = row.Item("Tipo")
            DGV_Verificacion.Rows(contador).Cells("DiferenciaEnDias").Value = _CalculaDiferenciaDias(row.Item("Articulo"), row.Item("Partida"), row.Item("EmpresaPartida"))
            'Aumento el contador para q grabe en otra 
            If DGV_Verificacion.Rows(contador).Cells("Stock").Value = 0 Then
                DGV_Verificacion.Rows.Remove(DGV_Verificacion.Rows(contador))
            End If
            ProgressBar1.Increment(1)
        Next
        ProgressBar1.Value = 0
        ProgressBar1.Visible = False
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        BackgroundWorker1.RunWorkerAsync()
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        Timer1.Stop()
    End Sub

    Private Sub DGV_Verificacion_CellMouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DGV_Verificacion.CellMouseDoubleClick
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