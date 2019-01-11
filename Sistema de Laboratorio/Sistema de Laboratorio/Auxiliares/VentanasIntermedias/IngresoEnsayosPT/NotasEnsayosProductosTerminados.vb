Public Class NotasEnsayosProductosTerminados
    Public Property Partida As Integer
    Public Property Terminado As String
    Public Property Etapa As Integer
    Public Property Notas As List(Of String)

    Private Sub NotasEnsayosProductosTerminados_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load

        dgvNotas.Rows.Clear()

        For i = 0 To 8
            dgvNotas.Rows.Add("", "")
        Next

        Dim WNotas As DataRow = GetSingle("SELECT Nota1, Nota2, Nota3, Nota4, Nota5, Nota6, Nota7, Nota8, Nota9 FROM PrueterFarmaIntermedio WHERE Partida = '" & Partida & "' And Producto = '" & Terminado & "' And Paso = '" & Etapa & "'")

        If WNotas IsNot Nothing Then

            dgvNotas.Rows.Clear()

            For i = 0 To 8

                Dim WContenido As String = OrDefault(WNotas.Item("Nota" & i + 1), "")

                dgvNotas.Rows.Add(i, Trim(WContenido))

            Next

        End If

        If Notas IsNot Nothing Then
            Dim x = 0
            For Each n As String In Notas
                With dgvNotas.Rows(x)
                    .Cells("Nota").Value = x + 1
                    .Cells("Contenido").Value = Trim(n)
                    x += 1
                End With
            Next
        End If

        With dgvNotas
            .CurrentCell = .Rows(0).Cells("Contenido")
            .Focus()
        End With

    End Sub

    Private Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
        Dim WNotas As New List(Of String)

        For i = 0 To 8
            WNotas.Add(OrDefault(dgvNotas.Rows(i).Cells("Contenido").Value, ""))
            WNotas.Item(i) = Trim(WNotas.Item(i))
        Next

        Dim WOwner As INotasEnsayosProductosTerminados = CType(Owner, INotasEnsayosProductosTerminados)

        If WOwner IsNot Nothing Then WOwner._ProcesarNotasEnsayosProductosTerminados(WNotas)

        Close()

    End Sub
End Class