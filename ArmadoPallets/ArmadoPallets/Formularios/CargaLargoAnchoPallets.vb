Imports Util.Clases.Query
Imports Util.Clases.Helper
Public Class CargaLargoAnchoPallets

    Dim WNroPallet As Integer = 0
    Dim WProforma As String = ""

    Sub New(ByVal Proforma As String, ByVal NroPallet As Integer)

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        WProforma = Proforma
        WNroPallet = NroPallet

        CargarValoresPrevios()

        txt_Largo.Focus()

    End Sub

    Private Sub CargarValoresPrevios()
        If WNroPallet <> -1 Then
            Dim SQLCnslt As String = "SELECT Largo, Ancho  FROM ArmadoPallets WHERE Proforma = '" & WProforma & "' AND Pallet = '" & WNroPallet & "'"
            Dim RowArmadoPallets As DataRow = GetSingle(SQLCnslt, "SurfactanSa")
            If RowArmadoPallets IsNot Nothing Then

                With RowArmadoPallets
                    txt_Largo.Text = formatonumerico(OrDefault(.Item("Largo"), 0))
                    txt_Ancho.Text = formatonumerico(OrDefault(.Item("Ancho"), 0))
                End With
            Else
                txt_Largo.Text = 0
                txt_Ancho.Text = 0
            End If
        Else
            txt_Largo.Text = 0
            txt_Ancho.Text = 0
        End If
    End Sub


    Private Sub txt_Largo_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_Largo.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                If Val(txt_Largo.Text) >= 0 Then
                    txt_Largo.Text = formatonumerico(txt_Largo.Text)
                    txt_Ancho.Focus()
                End If
            Case Keys.Escape
                txt_Largo.Text = ""
        End Select
    End Sub

    Private Sub txt_Ancho_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_Ancho.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                If Val(txt_Ancho.Text) >= 0 Then
                    txt_Ancho.Text = formatonumerico(txt_Ancho.Text)
                End If
            Case Keys.Escape
                txt_Ancho.Text = ""
        End Select
    End Sub

 
    Private Sub btn_Aceptar_Click(sender As Object, e As EventArgs) Handles btn_Aceptar.Click
        Dim WOwner As IPasarLargoAncho = TryCast(Owner, IPasarLargoAncho)
        If WOwner IsNot Nothing Then
            WOwner.PasaLargoAncho(Val(txt_Largo.Text), Val(txt_Ancho.Text))
            Close()
        End If
    End Sub

    Private Sub btn_Cancelar_Click(sender As Object, e As EventArgs) Handles btn_Cancelar.Click
        Close()
    End Sub



    Private Sub NumerosConComas(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_Largo.KeyPress, txt_Ancho.KeyPress
        If Not Char.IsNumber(e.KeyChar) And Not Char.IsControl(e.KeyChar) And Not (CChar(".")) = e.KeyChar Then
            e.Handled = True
        End If
    End Sub





End Class