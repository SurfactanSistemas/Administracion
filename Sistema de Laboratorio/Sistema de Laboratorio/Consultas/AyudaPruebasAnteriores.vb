Public Class AyudaPruebasAnteriores

    Private EsMP As Boolean = False
    Sub New(ByVal WDatos As DataTable, Optional ByVal EsMP As Boolean = False)

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        dgvDatos.DataSource = WDatos

        Me.EsMP = EsMP

        If Me.EsMP Then
            rbFinales.Checked = True
            rbPooles.Checked = False
            rbFinales.Visible = True
            rbPooles.Visible = False
        End If

    End Sub

    Private Sub txtFiltrar_KeyUp(sender As Object, e As KeyEventArgs) Handles txtFiltrar.KeyUp
        Dim tabla As DataTable = TryCast(dgvDatos.DataSource, DataTable)

        If tabla IsNot Nothing Then tabla.DefaultView.RowFilter = String.Format("Codigo LIKE '%{0}%' OR CONVERT(LotePartida, System.String) LIKE '%{0}%' OR Fecha LIKE '%{0}%' OR Descripcion LIKE '%{0}%'", txtFiltrar.Text)

    End Sub

    Private Sub dgvDatos_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvDatos.CellMouseDoubleClick
        If e.RowIndex < 0 Then Exit Sub

        Dim WOwner As IAyudaPruebasAnteriores = TryCast(Owner, IAyudaPruebasAnteriores)
        
        If WOwner IsNot Nothing Then WOwner._ProcesarAyudaPruebasAnteriores(dgvDatos.CurrentRow.Cells("LotePartida").Value, EsMP)

        Close()

    End Sub

    Private Sub AyudaPruebasAnteriores_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        txtFiltrar.Focus()
    End Sub

    Private Sub btnBorrar_Click(sender As Object, e As EventArgs) Handles btnBorrar.Click
        Close()
    End Sub

    Private Sub AyudaPruebasAnteriores_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub rbPooles_Click(sender As Object, e As EventArgs) Handles rbPooles.Click, rbFinales.Click
        If EsMP Then

            Dim WDatos As DataTable = Nothing

            dgvDatos.Columns("Pool").Visible = rbPooles.Checked

            If rbFinales.Checked Then
                WDatos = GetAll("SELECT Pool = 0, ptf.Fecha, ptf.Lote as LotePartida, ptf.Producto As Codigo, a.Descripcion FROM PrueArt ptf INNER JOIN Articulo a ON a.Codigo = ptf.Producto ORDER BY ptf.FechaOrd DESC, ptf.Lote DESC")
            Else
                WDatos = GetAll("SELECT ptf.Pool, ptf.Fecha, ptf.LoteProv as LotePartida, ptf.Producto As Codigo, a.Descripcion FROM PrueArtNuevoPooles ptf INNER JOIN Articulo a ON a.Codigo = ptf.Producto ORDER BY ptf.FechaOrd DESC, ptf.Pool DESC, ptf.LoteProv DESC")
            End If

            dgvDatos.DataSource = WDatos

        End If
    End Sub
End Class