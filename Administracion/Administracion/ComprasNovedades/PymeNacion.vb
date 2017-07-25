Public Class PymeNacion

    Private _Cuotas As Integer = 0
    Private _Mes As Integer = 0
    Private _Ano As Integer = 0

    Private Const ANO_MAX = 2100
    Private Const ANO_MIN = 2000
    Private Const MES_MAX = 12
    Private Const MES_MIN = 1

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

            With Me

                .Cuotas = Val(txtCantCuotas.Text)
                .Mes = Val(txtMes.Text)
                .Ano = Val(txtAno.Text)

                .Close()

            End With

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

            If Val(txtAno.Text) >= ANO_MIN And Val(txtAno.Text) <= ANO_MAX Then
                _AsignarNuevoValor()
            Else
                txtAno.Focus()
            End If

        End If

    End Sub

    Private Sub txtCantCuotas_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCantCuotas.KeyDown

        If e.KeyData = Keys.Enter Then
            If Val(txtCantCuotas.Text) > 0 Then
                txtMes.Focus()
            Else
                txtCantCuotas.Focus()
            End If
        End If

    End Sub

    Private Sub txtMes_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtMes.KeyDown

        If e.KeyData = Keys.Enter Then
            If Val(txtMes.Text) >= MES_MIN And Val(txtMes.Text) <= MES_MAX Then
                txtAno.Focus()
            Else
                txtAno.Focus()
            End If
        End If

    End Sub

    Private Sub InformacionRetenciones_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        If e.KeyData = Keys.Escape Then
            Me.Close()
        End If

    End Sub

    Private Sub txtCantCuotas_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCantCuotas.KeyPress

        If e.KeyChar = ChrW(Keys.Back) Or e.KeyChar = ChrW(Keys.Left) Or e.KeyChar = ChrW(Keys.Right) Or (e.KeyChar > CChar("0"c) And e.KeyChar <= CChar("9"c)) Then
            e.Handled = False
        Else
            e.Handled = True
        End If

    End Sub

    Private Sub txtMes_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMes.KeyPress
        If e.KeyChar = ChrW(Keys.Back) Or e.KeyChar = ChrW(Keys.Left) Or e.KeyChar = ChrW(Keys.Right) Or (e.KeyChar >= CChar("0"c) And e.KeyChar <= CChar("9"c)) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txtAno_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAno.KeyPress
        If e.KeyChar = ChrW(Keys.Back) Or e.KeyChar = ChrW(Keys.Left) Or e.KeyChar = ChrW(Keys.Right) Or (e.KeyChar >= CChar("0"c) And e.KeyChar <= CChar("9"c)) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub
End Class