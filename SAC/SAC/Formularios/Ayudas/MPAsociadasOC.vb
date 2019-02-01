Public Class MPAsociadasOC

    Private WOrden As Integer
    Private WEmpresa As Object
    Private WBase As Object

    Sub New(ByVal Orden, ByVal Empresa, ByVal Base)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        WOrden = Orden
        WEmpresa = Empresa
        WBase = Base
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Close()
    End Sub

    Private Sub MPAsociadasOC_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        With dgvItems
            .DefaultCellStyle.BackColor = globales.WBackColorTerciario
            .DefaultCellStyle.SelectionBackColor = Globales.WBackColorSecundario
            .DefaultCellStyle.SelectionForeColor = Color.White
            .Columns("Cantidad").DefaultCellStyle.Format = "0.00#"
        End With

        With txtDescProveedor
            .BackColor = Globales.WBackColorTerciario
        End With

        txtOrden.Text = WOrden
        txtEmpresa.Text = WEmpresa
        txtDescProveedor.Text = ""
        txtProveedor.Text = ""

        Dim WItems As DataTable = GetAll("SELECT o.Articulo As Codigo, o.Proveedor, DescProveedor = LTRIM(p.Nombre), o.Cantidad, LTRIM(a.Descripcion) Descripcion FROM Orden o LEFT OUTER JOIN Proveedor p ON p.Proveedor = o.Proveedor LEFT OUTER JOIN Articulo a ON a.Codigo = o.Articulo WHERE o.Orden = '" & WOrden & "' ORDER BY o.Clave", WBase)
        With dgvItems
            .DataSource = WItems
            If .Rows.Count > 0 Then
                txtProveedor.Text = WItems.Rows(0).Item("Proveedor")
                txtDescProveedor.Text = WItems.Rows(0).Item("DescProveedor")
                .CurrentCell = .Rows(0).Cells("Codigo")
            End If
        End With
    End Sub

    Private Sub dgvItems_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvItems.CellDoubleClick
        If e.RowIndex < 0 Then Exit Sub

        Dim WOwner = TryCast(Owner, IAyudaMPAsociadasOC)

        If (WOwner IsNot Nothing) Then
            With dgvItems.CurrentRow
                WOwner._ProcesarMPAsociadasOC(.Cells("Codigo").Value, .Cells("Descripcion").Value, .Cells("Cantidad").Value)
            End With
        End If

        Close()

    End Sub
End Class