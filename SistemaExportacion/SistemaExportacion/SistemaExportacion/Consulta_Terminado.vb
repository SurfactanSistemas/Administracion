Imports Util
Imports Util.Clases.Query
Imports Util.Clases.Helper
Public Class Consulta_Terminado
    Sub New(Optional ByVal CodCliente As String = "0")

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        If CodCliente = "0" Then
            Dim SQLCnslt As String = "SELECT Codigo, Descripcion FROM Terminado ORDER BY Codigo ASC"

            Dim TablaTerminado As DataTable = GetAll(SQLCnslt, "SurfactanSa")

            If TablaTerminado.Rows.Count > 0 Then
                DGV_Terminado.DataSource = TablaTerminado
            End If
        Else
            Dim SQLCnslt As String = "SELECT t.Codigo, t.Descripcion FROM Terminado as t, Precios as p WHERE t.Codigo >= 'PT-00004-100' AND t.Codigo <= 'PT-99999-999' AND t.Codigo = p.Terminado AND p.Cliente = '" & CodCliente & "' ORDER BY t.Codigo"
            Dim TablaTerminado As DataTable = GetAll(SQLCnslt, "SurfactanSa")

            If TablaTerminado.Rows.Count > 0 Then
                DGV_Terminado.DataSource = TablaTerminado
            End If
        End If
        
    End Sub
    
    Private Sub txt_Filtro_KeyUp(sender As Object, e As KeyEventArgs) Handles txt_Filtro.KeyUp
        Dim TablaFiltrar As DataTable = DGV_Terminado.DataSource
        TablaFiltrar.DefaultView.RowFilter = "Codigo LIKE '%" & txt_Filtro.Text & "%' OR Descripcion LIKE '%" & txt_Filtro.Text & "%'"
    End Sub

    Private Sub btn_Cerrar_Click(sender As Object, e As EventArgs) Handles btn_Cerrar.Click
        Close()
    End Sub

    Private Sub DGV_Cliente_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DGV_Terminado.CellMouseDoubleClick

        Dim WOwner As IConsulta_Terminado = TryCast(Owner, IConsulta_Terminado)
        If WOwner IsNot Nothing Then
            WOwner.PasaCodigo(DGV_Terminado.CurrentRow.Cells("Codigo").Value)
            Close()
        End If
    End Sub


    
End Class