Public Class NotasAnterioresFarmaPT

    Private ReadOnly WPartida As String = ""
    Private ReadOnly WEtapa As String = ""

    Sub New(ByVal Partida As String, ByVal Etapa As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        WPartida = Partida
        WEtapa = Etapa
    End Sub

    Private Sub NotasAnterioresFarmaPT_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim WNotas As DataRow = Nothing
        If Val(WEtapa) = 99 Then
            WNotas = GetSingle("SELECT Ensayo, Aspecto, Observaciones FROM PrueterFarma WHERE Partida = '" & WPartida & "' And Renglon = '1'")
        Else
            WNotas = GetSingle("SELECT Ensayo, Aspecto, Observaciones FROM PrueterFarmaIntermedio WHERE Partida = '" & WPartida & "' And Paso = '" & WEtapa & "' And Renglon = '1'")
        End If

        If WNotas IsNot Nothing Then
            For Each col As String In {"Ensayo", "Aspecto", "Observaciones"}
                dgvNotasAnteriores.Rows.Add(WNotas.Item(col))
            Next
        End If

    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Close()
    End Sub
End Class