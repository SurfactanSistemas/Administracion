Public Class Consulta_Presupuesto

    Sub New(ByVal Proveedor As String, ByVal Razon As String)

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        txt_CodigoProveedor.Text = Proveedor
        txt_DescripcionProveedor.Text = Razon

    End Sub
    Private Sub Consulta_Presupuesto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If txt_CodigoProveedor.Text <> "" Then
            Dim SQLCnslt As String = "SELECT NroPresupuesto,TiTulo, Monto FROM Solicitud_Presupuesto WHERE Proveedor = '" & txt_CodigoProveedor.Text & "' AND Estado = 'Pendiente'"
            Dim TablaPresu As DataTable = GetAll(SQLCnslt, "SurfactanSa")
            If TablaPresu.Rows.Count > 0 Then
                dgv_Presupuestos.DataSource = TablaPresu
            End If
        End If
    End Sub

    Private Sub dgv_Presupuestos_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_Presupuestos.CellDoubleClick
        Dim Wowner As IPasa_NumeroPresupuesto = TryCast(Owner, IPasa_NumeroPresupuesto)
        If Wowner IsNot Nothing Then
            Wowner.PasaNroPresu(dgv_Presupuestos.CurrentRow.Cells("NroPresupuesto").Value)
        End If
    End Sub
End Class