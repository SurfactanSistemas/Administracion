Public Class SeleccionEnsayoReferidoPoolEnsayos

    Private Datos As DataGridViewRowCollection
    Private Partida, Etapa As String

    Sub New(ByVal Datos As DataGridViewRowCollection, ByVal Partida As String, ByVal Etapa As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.Datos = Datos
        Me.Partida = Partida
        Me.Etapa = Etapa

    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Close()
    End Sub

    Private Sub SeleccionEnsayoReferidoPoolEnsayos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        _RepoblarGrilla()
    End Sub

    Private Sub _RepoblarGrilla()

        For Each row As Datagridviewrow In Datos
            With row
                dgvDatos.Rows.Add(.Cells("Ensayo").Value, .Cells("Especificacion").Value, .Cells("Parametro").Value)
            End With
        Next

    End Sub

    Private Sub dgvDatos_CellMouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvDatos.CellMouseDoubleClick
        If e.RowIndex < 0 Then Exit Sub

        With New IngresoNuevoPoolEnsayos(dgvDatos.CurrentRow, Partida, Etapa)
            .ShowDialog(Me)
            Close()
        End With

    End Sub
End Class