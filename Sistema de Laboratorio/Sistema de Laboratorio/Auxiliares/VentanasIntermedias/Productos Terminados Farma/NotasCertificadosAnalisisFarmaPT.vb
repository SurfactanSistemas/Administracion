Public Class NotasCertificadosAnalisisFarmaPT

    Private ReadOnly WPartida As String = ""

    Sub New(ByVal Partida As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        WPartida = Partida
    End Sub

    Private Sub NotasAnterioresFarmaPT_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim WNotas As DataRow = GetSingle("SELECT NotaExterna1, NotaExterna2, NotaExterna3 FROM PrueterFarma WHERE Partida = '" & WPartida & "' And Renglon = '1'")

        With dgvNotasAnteriores

            If WNotas IsNot Nothing Then
                For Each col As String In {"NotaExterna1", "NotaExterna2", "NotaExterna3"}
                    .Rows.Add(OrDefault(WNotas.Item(col), "").ToString.Trim)
                Next
            End If

            For i = .Rows.Count + 1 To 3
                .Rows.Add("")
            Next

            .CurrentCell = .Rows(0).Cells(0)
            .Focus()

        End With
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Close()
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Dim WNotasExternas(2) As String

        For i = 0 To 2
            WNotasExternas(i) = Trim(OrDefault(dgvNotasAnteriores.Rows(i).Cells(0).Value, ""))
        Next

        ExecuteNonQueries("UPDATE PrueterFarma SET NotaExterna1 = '" & WNotasExternas(0) & "', NotaExterna2 = '" & WNotasExternas(1) & "', NotaExterna3 = '" & WNotasExternas(2) & "' WHERE Partida = '" & WPartida & "'")

        Close()

    End Sub

End Class