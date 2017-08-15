Public Class SolicitarInformacionCuit

    Private _valor As String = ""

    Public Property Valor() As String

        Get
            Return _valor
        End Get
        Set(ByVal value As String)
            _valor = Trim(value)
        End Set

    End Property

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        If _ValidarCuit(txtInfo.Text) Then
            _AsignarNuevoValor()
        End If

    End Sub

    Private Sub _AsignarNuevoValor()

        With Me

            .Valor = txtInfo.Text

            .Close()

        End With

    End Sub

    Private Sub InformacionRetenciones_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        txtInfo.Text = Me.Valor

    End Sub

    Private Sub InformacionRetenciones_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        txtInfo.Focus()
    End Sub

    Private Sub txtInfo_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtInfo.KeyDown

        If e.KeyData = Keys.Enter Then

            If _ValidarCuit(txtInfo.Text) Then
                _AsignarNuevoValor()
            End If

        End If

    End Sub

    Private Function _ValidarCuit(ByVal cuit As String) As Boolean
        If Trim(cuit) = "" Then
            Return False
        Else
            Return IIf(Val(cuit) = 0, True, Proceso.CuitValido(cuit))
        End If
    End Function

    Private Sub InformacionRetenciones_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        If e.KeyData = Keys.Escape Then
            Me.Close()
        End If

    End Sub

    Private Sub txtInfo_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtInfo.KeyPress

        If Char.IsNumber(e.KeyChar) Or Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If

    End Sub
End Class