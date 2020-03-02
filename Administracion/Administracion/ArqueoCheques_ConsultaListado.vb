Public Class ArqueoCheques_ConsultaListado
    Sub New(ByVal Texto1 As String, ByVal Texto2 As String, ByVal Texto3 As String, ByVal Texto4 As String, ByVal Texto5 As String, ByVal Texto6 As String, ByVal Texto7 As String, ByVal Texto8 As String)

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        CheckBox1.Text = Texto1
        CheckBox2.Text = Texto2
        CheckBox3.Text = Texto3
        CheckBox4.Text = Texto4
        CheckBox5.Text = Texto5
        CheckBox6.Text = Texto6
        CheckBox7.Text = Texto7
        CheckBox8.Text = Texto8

    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Close()
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click


        Dim owner1 As IArqueoCheques = TryCast(Owner, IArqueoCheques)

        If owner1 IsNot Nothing Then
            owner1._ProcesarDatosChecks(CheckBox1.Checked, CheckBox2.Checked, CheckBox3.Checked, CheckBox4.Checked, CheckBox5.Checked, CheckBox6.Checked, CheckBox7.Checked, CheckBox8.Checked)
        End If

    End Sub
End Class