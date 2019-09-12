Public Class AyudaMPsDentroDeInforme

    Private Informe As String

    Sub New(ByVal Informe As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.Informe = Informe

    End Sub

    Private Sub AyudaMPsDentroDeInforme_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim WSql As String = PrepararConsultaSql

        Dim WArticulos As DataTable = GetAll(WSql)

        dgvItems.DataSource = WArticulos

        If dgvItems.Rows.Count = 0 Then
            Close()
        ElseIf dgvItems.Rows.Count = 1 Then
            _EnviarDatosDeFila(0)
        End If

    End Sub

    Private Function PrepararConsultaSql() As String
        Dim WSql As String = ""

        For i = 1 To 5
            WSql &= String.Format("SELECT i.Articulo Codigo, a.Descripcion, Cantidad = i.Canti{1}, LotePrv = i.Lote{1} FROM Informe i INNER JOIN Articulo a ON a.Codigo = i.Articulo WHERE i.Informe = '{0}' And i.Lote{1} <> '' ", Informe, i)
            If i <> 5 Then WSql &= String.Format("{0}UNION{0}", Environment.NewLine)
        Next

        WSql = WSql.TrimEnd("UNION" & Environment.NewLine)

        Return WSql

    End Function

    Private Sub dgvItems_CellMouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvItems.CellMouseDoubleClick
        _EnviarDatosDeFila(e.RowIndex)
    End Sub

    Private Sub _EnviarDatosDeFila(ByVal Indice As Integer)

        If Indice < 0 Then Exit Sub

        With dgvItems.Rows(Indice)

            Dim WCodigo As String = Trim(OrDefault(.Cells("Codigo").Value, ""))
            Dim WDescripcion As String = Trim(OrDefault(.Cells("Descripcion").Value, ""))
            Dim WCantidad As String = Trim(OrDefault(.Cells("Cantidad").Value, ""))
            Dim WLotePrv As String = Trim(OrDefault(.Cells("LotePrv").Value, ""))

            Dim WOwner As IAyudaMPDentroDeInforme = TryCast(Owner, IAyudaMPDentroDeInforme)
            If WOwner IsNot Nothing Then WOwner._ProcesarAyudaMPDentrodEInforme(WCodigo, WDescripcion.Trim, WCantidad, WLotePrv)

            Close()

        End With

    End Sub
End Class