Public Class PymeNacion

    Private _Cuotas As Integer = 0
    Private _Mes As Integer = 0
    Private _Ano As Integer = 0

    Public Property Cuotas() As Integer

        Get
            Return _Cuotas
        End Get
        Set(ByVal value As Integer)
            _Cuotas = Trim(value)
        End Set

    End Property

    Public Property Mes() As Integer

        Get
            Return _Mes
        End Get
        Set(ByVal value As Integer)
            _Mes = Trim(value)
        End Set

    End Property

    Public Property Ano() As Integer

        Get
            Return _Ano
        End Get
        Set(ByVal value As Integer)
            _Ano = Trim(value)
        End Set

    End Property

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        _AsignarNuevoValor()

    End Sub

    Private Sub _AsignarNuevoValor()


        If Val(txtCantCuotas.Text) > 0 And Val(txtMes.Text) > 0 And Val(txtAno.Text) > 0 Then
            With Me

                .Cuotas = Val(txtCantCuotas.Text)
                .Mes = Val(txtMes.Text)
                .Ano = Val(txtAno.Text)

                .Close()

            End With
        Else
            MsgBox("No todos los valores son correctos." & vbCrLf & vbCrLf & "Por favor verifique que los mismos sean correctos e intente nuevamente.", MsgBoxStyle.Information)
        End If


    End Sub

    Private Sub InformacionRetenciones_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        txtCantCuotas.Text = Me.Cuotas
        txtMes.Text = Me.Mes
        txtAno.Text = Me.Ano

    End Sub

    Private Sub InformacionRetenciones_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        txtCantCuotas.Focus()
    End Sub

    Private Sub txtAno_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtAno.KeyDown

        If e.KeyData = Keys.Enter Then

            If Val(txtAno.Text) > 0 Then
                _AsignarNuevoValor()
            End If

        End If

    End Sub

    Private Sub txtCantCuotas_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCantCuotas.KeyDown

        If e.KeyData = Keys.Enter Then
            If Val(txtCantCuotas.Text) > 0 Then
                txtMes.Focus()
            End If
        End If

    End Sub

    Private Sub txtMes_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtMes.KeyDown

        If e.KeyData = Keys.Enter Then
            If Val(txtMes.Text) > 0 Then
                txtAno.Focus()
            End If
        End If

    End Sub

    Private Sub InformacionRetenciones_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        If e.KeyData = Keys.Escape Then
            Me.Close()
        End If

    End Sub
End Class