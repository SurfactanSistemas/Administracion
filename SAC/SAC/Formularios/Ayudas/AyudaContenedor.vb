Public Class AyudaContenedor

    Sub New(ByVal ParamArray WOpciones As String())

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        lstOpciones.Items.AddRange(WOpciones)
    End Sub
    
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Close()
    End Sub

    Private Sub lstOpciones_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstOpciones.MouseDoubleClick
        With lstOpciones
            If .SelectedIndex < 0 Then Exit Sub

            Dim WOwner As IAyudaContenedor = CType(Owner, IAyudaContenedor)
            If Not IsNothing(WOwner) Then WOwner._ProcesarAyudaContenedor(.SelectedIndex)

            Close()
        End With
    End Sub
End Class