Public Class ListaConsultas

    Dim WConsultas() As String

    Sub New(ByVal ParamArray Consultas As String())

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        WConsultas = Consultas

    End Sub

    Private Sub lstConsultas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstConsultas.Click

        If lstConsultas.SelectedIndex < 0 Then Exit Sub

        Dim WOwner As IListaConsultas = TryCast(Owner, IListaConsultas)

        If WOwner IsNot Nothing Then WOwner._ProcesarListaConsultas(lstConsultas.SelectedIndex)

        Close()

    End Sub

    Private Sub ListaConsultas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        lstConsultas.Items.Clear()

        For Each wConsulta As String In WConsultas
            lstConsultas.Items.Add(wConsulta)
        Next

    End Sub
End Class