
Imports Util
Imports Util.Clases.Query
Imports Util.Clases.Helper

Public Class Discriminado_Mov_Env
    Private TablaDetallado As New DataTable
    Private _codigo As String
    Private _cbx_index As Integer
    Private WOrd As String = ""

    Sub New(ByVal Codigo As String, ByVal Cbx_Index As Integer)

        _codigo = Codigo
        _cbx_index = Cbx_Index

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        
    End Sub

    Private Sub _Proceso()

        TablaDetallado.Rows.Clear()

        Dim Codigo As String = _codigo
        Dim Cbx_Index As Integer = _cbx_index
        Dim SQLCnslt As String

        Dim DesdeFecha As String = BuscarFechaDesde(Cbx_Index)
        Dim DesdeFechaOrd As String = ordenaFecha(DesdeFecha)
        Dim FechaActualOrd As String = ordenaFecha(Date.Today.ToString("dd/MM/yyyy"))


        If rbEntradas.Checked Or rbTotal.Checked Then

            SQLCnslt = "SELECT  de.Envase, de.Fecha, de.OrdFecha, Entradas = de.Cantidad " _
                       & "FROM Surfactan_II.dbo.DevolucionEnvases de INNER JOIN SurfactanSa.dbo.EquivEnvArticulo eea ON de.Envase = eea.Articulo " _
                       & "WHERE de.Cliente = '" & Codigo & "' " _
                       & "AND de.OrdFecha >= '" & DesdeFechaOrd & "' AND de.OrdFecha <= '" & FechaActualOrd & "'" _
                       & "AND eea.Envase = 30"

            Dim tablaDevolEnv As DataTable = GetAll(SQLCnslt)

            If tablaDevolEnv.Rows.Count > 0 Then
                For Each rowdevolEnv As DataRow In tablaDevolEnv.Rows
                    TablaDetallado.Rows.Add("Devolucion Envases", "", "", rowdevolEnv.Item("Fecha"), rowdevolEnv.Item("Entradas"), 0, rowdevolEnv.Item("OrdFecha"))
                Next
            End If

            SQLCnslt = "SELECT hrde.Hoja, hrde.Fecha, hrde.FechaOrd, Entradas = hrde.Cantidad " _
                       & "FROM HojaRutaDevEnv hrde INNER JOIN EquivEnvArticulo eea ON hrde.Envase = eea.Articulo " _
                       & "WHERE hrde.Cliente = '" & Codigo & "' " _
                       & "AND hrde.FechaOrd >= '" & DesdeFechaOrd & "' AND hrde.FechaOrd <= '" & FechaActualOrd & "' " _
                       & "AND eea.Envase = 30"
            Dim tablaHojaRuta As DataTable = GetAll(SQLCnslt)

            If tablaHojaRuta.Rows.Count > 0 Then
                For Each rowHojaRuta As DataRow In tablaHojaRuta.Rows
                    TablaDetallado.Rows.Add("Hoja de Ruta", rowHojaRuta.Item("Hoja"), "", rowHojaRuta.Item("Fecha"), rowHojaRuta.Item("Entradas"), 0, rowHojaRuta.Item("FechaOrd"))
                Next
            End If

            '   SQLCnslt = "SELECT NroMovEnv = Codigo, Fecha, FechaOrd, Entradas = Cantidad FROM MovEnv " _
            '              & "WHERE Cliente = '" & Codigo & "' " _
            '              & "AND FechaOrd >= '" & DesdeFechaOrd & "' AND FechaOrd <= '" & FechaActualOrd & "'" _
            '              & "AND Movimiento = 'E' AND Envase = 30 AND Marca <> 'X' "
            '
            '   Dim tablaSalidas As DataTable = GetAll(SQLCnslt, "SurfactanSa")
            '
            '   If tablaSalidas.Rows.Count > 0 Then
            '       For Each rowSal As DataRow In tablaSalidas.Rows
            '           TablaDetallado.Rows.Add("Remito", "", rowSal.Item("NroMovEnv").ToString().Remove(0, 1), rowSal.Item("Fecha"), rowSal.Item("Entradas"), 0, rowSal.Item("FechaOrd"))
            '       Next
            '   End If
            '




        End If
        If rbSalidas.Checked Or rbTotal.Checked Then
            SQLCnslt = "SELECT NroMovEnv = Codigo, Fecha, FechaOrd, Salidas = Cantidad FROM MovEnv " _
                   & "WHERE Cliente = '" & Codigo & "' " _
                   & "AND FechaOrd >= '" & DesdeFechaOrd & "' AND FechaOrd <= '" & FechaActualOrd & "'" _
                   & "AND Movimiento = 'S' AND Envase = 30 AND Marca <> 'X' "

            Dim tablaSalidas As DataTable = GetAll(SQLCnslt, "SurfactanSa")

            If tablaSalidas.Rows.Count > 0 Then
                For Each rowSal As DataRow In tablaSalidas.Rows
                    TablaDetallado.Rows.Add("Remito", "", rowSal.Item("NroMovEnv").ToString().Remove(0, 1), rowSal.Item("Fecha"), 0, rowSal.Item("Salidas"), rowSal.Item("FechaOrd"))
                Next
            End If
        End If

        DGV_MovDetallados.DataSource = TablaDetallado
        Dim TSalidas As Integer = 0
        Dim TEntradas As Integer = 0

        For Each DGV_row As DataGridViewRow In DGV_MovDetallados.Rows
            TEntradas = TEntradas + DGV_row.Cells("Entrada").Value
            TSalidas = TSalidas + DGV_row.Cells("Salida").Value
        Next

        txt_TotalEntradas.Text = TEntradas
        txt_TotalSalidas.Text = TSalidas

        DGV_MovDetallados.Sort(DGV_MovDetallados.Columns(6), System.ComponentModel.ListSortDirection.Ascending)

    End Sub

    Private Function BuscarFechaDesde(Cbx_Index) As String
        Dim FechaDevolver As String

        If Cbx_Index = 0 Then
            FechaDevolver = Date.Today.AddMonths(-1).ToString("dd/MM/yyyy")
            Return FechaDevolver
        End If

        If Cbx_Index = 1 Then
            FechaDevolver = Date.Today.AddMonths(-3).ToString("dd/MM/yyyy")
            Return FechaDevolver
        End If

        If Cbx_Index = 2 Then
            FechaDevolver = Date.Today.AddMonths(-6).ToString("dd/MM/yyyy")
            Return FechaDevolver
        End If

        If Cbx_Index = 3 Then
            FechaDevolver = Date.Today.AddMonths(-12).ToString("dd/MM/yyyy")
            Return FechaDevolver
        End If

    End Function

    Private Sub btn_Cerrar_Click(sender As Object, e As EventArgs) Handles btn_Cerrar.Click
        Close()
    End Sub


    Private Sub DGV_MovDetallados_SortCompare(sender As Object, e As DataGridViewSortCompareEventArgs) Handles DGV_MovDetallados.SortCompare

        Dim num1, num2

        Select Case e.Column.Index
            Case 0
                'String
                num1 = e.CellValue1
                num2 = e.CellValue2

            Case 1, 2, 4, 5
                'INTEGER
                num1 = CInt(e.CellValue1)
                num2 = CInt(e.CellValue2)

            Case 3
                'Fechas
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
    
    Private Sub Discriminado_Mov_Env_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        txt_Cliente.Text = _codigo

        Dim SQLCnslt As String = "SELECT Razon FROM Cliente WHERE Cliente = '" & _codigo & "'"
        Dim RowCli As DataRow = GetSingle(SQLCnslt, "SurfactanSa")
        If RowCli IsNot Nothing Then
            txt_ClienteDes.Text = RowCli.Item("Razon")
        End If

        With TablaDetallado.Columns
            .Add("Tipo")
            .Add("Hoja")
            .Add("MovEnv")
            .Add("Fecha")
            .Add("Entrada")
            .Add("Salida")
            .Add("FechaOrd")
        End With

        _Proceso()
    End Sub

    Private Sub rbTotal_Click(sender As Object, e As EventArgs) Handles rbTotal.Click, rbSalidas.Click, rbEntradas.Click
        _Proceso()
    End Sub

    Private Sub DGV_MovDetallados_ColumnHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DGV_MovDetallados.ColumnHeaderMouseClick
        If e.ColumnIndex = DGV_MovDetallados.Columns("Fecha").Index Then
            WOrd = IIf(WOrd = "", "DESC", "")
            TryCast(DGV_MovDetallados.DataSource, DataTable).DefaultView.Sort = "FechaOrd " & WOrd
        End If
    End Sub
End Class