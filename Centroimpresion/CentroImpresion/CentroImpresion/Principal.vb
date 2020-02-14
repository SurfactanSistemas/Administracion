Public Class Principal

    Private Sub EmisiónDeEtiquetasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmisiónDeEtiquetasToolStripMenuItem.Click
        With New EmisionEtiquetas
            .Show(Me)
        End With
    End Sub

    Private Sub EmisiónDeEtiquetasDePreenvasadoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmisiónDeEtiquetasDePreenvasadoToolStripMenuItem.Click
        With New EmisionEtiquetaPreenvasado
            .Show(Me)
        End With
    End Sub

    Private Sub Principal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '
        ' Determino acciones para cuando es llamado por linea de Comandos.
        '
        If Environment.GetCommandLineArgs.Length > 1 Then

            Dim WPartida As String = Environment.GetCommandLineArgs(1)
            Dim WCantidad As String = Environment.GetCommandLineArgs(2)
            Dim WCantidadEtiq As String = Environment.GetCommandLineArgs(3)
            Dim WTara As String = Environment.GetCommandLineArgs(4)
            Dim WLoteMP As String = Environment.GetCommandLineArgs(5)

            'MsgBox(WLoteMP)

            Me.WindowState = FormWindowState.Minimized
            Me.Hide()

            With New EmisionEtiquetas()

                .WindowState = FormWindowState.Minimized
                .Hide()
                .Show()
                .Focus()

                .txtLote.Text = WPartida
                .txtLote_KeyDown(Nothing, New KeyEventArgs(Keys.Enter))
                .txtCantidad.Text = WCantidad
                .txtCantEtiq.Text = WCantidadEtiq
                .txtTara.Text = WTara
                .txtLoteMP.Text = WLoteMP

                .btnEmitir_Click(Nothing, Nothing)

                .Close()

            End With

            Close()

        End If

    End Sub
End Class