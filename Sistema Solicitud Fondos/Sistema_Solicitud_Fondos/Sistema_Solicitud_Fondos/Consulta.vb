Imports Util.Clases.Query
Public Class Consulta

    Sub New(Optional ByVal Opcion As Integer = 0)

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Select Case Opcion
            Case 0
                Dim SQLCnslt As String = ""
                SQLCnslt = "SELECT Codigo = Proveedor , Descripcion = Nombre FROM Proveedor ORDER BY Nombre"
                Dim tablaProvee As DataTable = GetAll(SQLCnslt, "SurfactanSa")
                If tablaProvee.Rows.Count > 0 Then
                    DGV_Consulta.DataSource = tablaProvee
                End If
                cbx_Opcion.SelectedIndex = 0
            Case 1
                Dim SQLCnslt As String = ""
                SQLCnslt = "SELECT Codigo =Cuenta , Descripcion FROM Cuenta order by Descripcion"
                Dim tablaCuentas As DataTable = GetAll(SQLCnslt, "SurfactanSa")
                If tablaCuentas.Rows.Count > 0 Then
                    DGV_Consulta.DataSource = tablaCuentas
                End If
                cbx_Opcion.SelectedIndex = 1
        End Select

    End Sub
    Private Sub Consulta_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        txt_Filtro.Focus()
    End Sub


    
    Private Sub txt_Filtro_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_Filtro.KeyPress
        Dim tablaVendedores As DataTable = DGV_Consulta.DataSource


        tablaVendedores.DefaultView.RowFilter = "convert(Codigo, System.String) LIKE '%" & txt_Filtro.Text & "%' OR Descripcion LIKE '%" & txt_Filtro.Text & "%'"

    End Sub

    Private Sub DGV_Consultae_SortCompare(sender As Object, e As DataGridViewSortCompareEventArgs) Handles DGV_Consulta.SortCompare

        Dim num1, num2

        Select Case e.Column.Index
            Case 1
                'String
                num1 = e.CellValue1
                num2 = e.CellValue2

            Case 0
                'INTEGER
                num1 = CInt(e.CellValue1)
                num2 = CInt(e.CellValue2)

         
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


    Private Sub DGV_Consulta_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DGV_Consulta.CellMouseDoubleClick
        Dim Wowner As IConsulta = TryCast(Owner, IConsulta)

        If Wowner IsNot Nothing Then
            Wowner.PasaConsulta(cbx_Opcion.SelectedIndex, DGV_Consulta.CurrentRow.Cells("Codigo").Value, DGV_Consulta.CurrentRow.Cells("Descripcion").Value)
            Close()
        End If
    End Sub

End Class