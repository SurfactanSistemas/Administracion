Imports Util
Imports Util.Clases.Query
Imports Util.Clases.Helper

Public Class ClientesReprogramados : Implements IPasaCliente

    Private WOrd As String = ""

    Private Sub btn_Cerrar_Click(sender As Object, e As EventArgs) Handles btn_Cerrar.Click
        Close()
    End Sub


    Sub New()

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Dim SQLCnslt As String = "SELECT r.Cliente, FechaRePro = r.Fecha, FechaReProgOrd = r.FechaOrd, Descripcion = c.Razon, r.Observaciones " _
                                 & "FROM ReclamosEnvReProg r INNER JOIN Cliente c ON r.Cliente = c.Cliente ORDER BY r.FechaOrd"

        Dim TablaReclamos As DataTable = GetAll(SQLCnslt, "SurfactanSa")

        If TablaReclamos.Rows.Count > 0 Then
            DGV_Clientes.DataSource = TablaReclamos
        End If

    End Sub


    Private Sub txt_Filtro_KeyUp(sender As Object, e As KeyEventArgs) Handles txt_Filtro.KeyUp
        Dim TablaFiltrar As DataTable = DGV_Clientes.DataSource

        TablaFiltrar.DefaultView.RowFilter = "Cliente LIKE '%" & txt_Filtro.Text & "%' OR Descripcion LIKE '%" & txt_Filtro.Text & "%'"
        
    End Sub

    Private Sub DGV_Clientes_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DGV_Clientes.CellMouseDoubleClick
        With New Acciones_Agenda(DGV_Clientes.CurrentRow.Cells("Cliente").Value, DGV_Clientes.CurrentRow.Cells("FechaRePro").Value, DGV_Clientes.CurrentRow.Cells("Observaciones").Value)
            .Show(Me)
        End With
    End Sub

    Public Sub PasaCliente(CodCliente As String) Implements IPasaCliente.PasaCliente

        Dim SQLCnlst As String = "DELETE FROM ReclamosEnvReProg WHERE Cliente = '" & CodCliente & "'"

        ExecuteNonQueries({SQLCnlst}, "SurfactanSa")

        Dim PosicionTabla As Integer = 0
        Dim PosicionBorrar As Integer = 0

        Dim tablaAux As DataTable = DGV_Clientes.DataSource

        For Each rowAux As DataRow In tablaAux.Rows

            If CodCliente = rowAux.Item("Cliente") Then
                PosicionBorrar = PosicionTabla
            End If

            PosicionTabla += 1

        Next

        tablaAux.Rows.RemoveAt(PosicionBorrar)

    End Sub

    Public Sub ActualizaGrilla() Implements IPasaCliente.ActualizaGrilla
        Dim SQLCnslt As String = "SELECT r.Cliente, FechaRePro = r.Fecha, FechaReProgOrd = r.FechaOrd, Descripcion = c.Razon, r.Observaciones " _
                                 & "FROM ReclamosEnvReProg r INNER JOIN Cliente c ON r.Cliente = c.Cliente ORDER BY r.FechaOrd"

        Dim TablaReclamos As DataTable = GetAll(SQLCnslt, "SurfactanSa")

        If TablaReclamos.Rows.Count > 0 Then
            DGV_Clientes.DataSource = TablaReclamos
        End If
    End Sub

    Private Sub ClientesReprogramados_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub DGV_Clientes_ColumnHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DGV_Clientes.ColumnHeaderMouseClick
        If e.ColumnIndex = DGV_Clientes.Columns("FechaRePro").Index Then
            WOrd = IIf(WOrd = "", "DESC", "")
            TryCast(DGV_Clientes.DataSource, DataTable).DefaultView.Sort = "FechaReProgOrd " & WOrd
        End If
    End Sub
End Class