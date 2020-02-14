Imports CentroImpresion

Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Timer1.Start()
    End Sub

    Private Sub _ProcesarImpresiones()

        Timer1.Stop()

        Dim WEtiquetas As DataTable = GetAll("SELECT pci.*, ci.Ip IpImpresora, ci.NombreRed FROM ProcesoCentroImpresion pci LEFT OUTER JOIN ColectoraImpresoras ci ON ci.Impresora = pci.Impresora WHERE UPPER(ISNULL(pci.Impresion, '')) <> 'X'")
        Dim WLote, WCantEti, WCantXEnv, WImpresora, WID As String

        For Each row As DataRow In WEtiquetas.Rows
            With row
                WID = OrDefault(.Item("ID"), "")
                WLote = OrDefault(.Item("Lote"), "0")
                WCantEti = OrDefault(.Item("CantEtiq"), "1")
                WImpresora = Trim(OrDefault(.Item("NombreRed"), ""))

                'If Trim(WImpresora) <> "" Then WImpresora = "\\" & Environment.MachineName & "\" & WImpresora

                WCantXEnv = formatonumerico(OrDefault(.Item("CantPorEtiq"), "1"))

                With New EmisionEtiquetaPreenvasado(WLote, WCantEti, WCantXEnv, WImpresora, True, WID)
                    .WindowState = Windows.Forms.FormWindowState.Minimized
                    .Show()
                End With

                ExecuteNonQueries({"UPDATE ProcesoCentroImpresion SET Impresion = 'X' WHERE ID = '" & WID & "'"})

            End With
        Next

        Timer1.Start()

    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        _ProcesarImpresiones()
    End Sub
End Class
