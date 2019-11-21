Public Class ListaPoolEnsayos

    Private Producto, Partida, Etapa As String
    Private DatosEspecif As DataGridViewRowCollection

    Sub New(ByVal Producto As String, ByVal Partida As String, ByVal Etapa As String, ByVal DatosEspecif As DataGridViewRowCollection)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.Producto = Producto
        Me.Partida = Partida
        Me.Etapa = Etapa
        Me.DatosEspecif = DatosEspecif

    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Close()
    End Sub

    Private Sub ListaPoolEnsayos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lblCodigo.Text = Producto
        lblEtapa.Text = Etapa
        _PoblarGrilla()
    End Sub

    Private Sub _PoblarGrilla()

        lblDescripcion.Text = ""
        dgvDatos.Rows.Clear()

        Dim WTerminado As DataRow = GetSingle("SELECT Descripcion FROM Terminado WHERE Codigo = '" & Producto & "'")

        If WTerminado IsNot Nothing Then lblDescripcion.Text = Trim(OrDefault(WTerminado.Item("Descripcion"), ""))

        '
        ' Cargamos los datos de los Pooles de Ensayos que se encuentren cargado para este producto y Etapa en particular.
        '
        Dim WPooles As DataTable = GetAll("SELECT * FROM PrueterPoolEnsayos WHERE Partida = '" & Partida & "' And Etapa = '" & Etapa & "' Order by Renglon")

        For Each row As Datagridviewrow In DatosEspecif

            '
            ' Busco para cada renglon si tiene pooles asociados.
            '
            Dim WPool As DataRow() = WPooles.Select("RenglonEnsayos = '" & row.Index + 1 & "'")
            Dim i As Integer = 0

            For Each p As DataRow In WPool
                Dim WEnsayo As String = ""
                Dim WEspecificacion As String = ""

                If i <> row.Index + 1 Then
                    WEnsayo = row.Cells("Ensayo").Value
                    WEspecificacion = row.Cells("Especificacion").Value
                    i = row.Index + 1
                End If

                dgvDatos.Rows.Add(WEnsayo, WEspecificacion, p.Item("Descripcion"), row.Cells("Parametro").Value, p.Item("Valor"), i)
            Next
        Next
    End Sub

    Private Sub btnNuevoPool_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevoPool.Click
        With New SeleccionEnsayoReferidoPoolEnsayos(DatosEspecif, Partida, Etapa)
            .ShowDialog(Me)
            _PoblarGrilla()
        End With
    End Sub

    Private Sub dgvDatos_CellMouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvDatos.CellMouseDoubleClick
        If e.RowIndex < 0 Then Exit Sub

        With New IngresoNuevoPoolEnsayos(dgvDatos.CurrentRow.Cells("IDRenglonEnsayos").Value, dgvDatos.CurrentRow.Cells("DescEnsayo").Value, dgvDatos.CurrentRow.Cells("Parametro").Value, Partida, Etapa)
            .ShowDialog(Me)
            _PoblarGrilla()
        End With

    End Sub
End Class