Imports Util.Clases

Public Class ListarReporteDesdeHastaBasico

    Public Event WOnKeyDown(ByVal sender As Object, ByVal e As EventArgs)

    Sub New(Optional ByVal Titulo As String = "Listar")

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        lblTitulo.Text = Titulo.ToUpper

    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Close()
    End Sub

    Private Sub txtDesde_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDesde.KeyDown

        If e.KeyData = Keys.Enter Then

            txtDesde.Text = Val(txtDesde.Text)

            RaiseEvent WOnKeyDown(txtDesde, New ListadoReporteEventArgs(lblDescripcion1))

            txtHasta.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtDesde.Text = ""
        End If

    End Sub

    Private Sub txtHasta_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtHasta.KeyDown

        If e.KeyData = Keys.Enter Then

            If Trim(txtHasta.Text) = "" Then : txtHasta.Text = "9999" : End If

            txtHasta.Text = Val(txtHasta.Text)

            RaiseEvent WOnKeyDown(txtHasta, New ListadoReporteEventArgs(lblDescripcion2))

            txtDesde.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtHasta.Text = ""
        End If

    End Sub

    Private Sub SoloNumero(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDesde.KeyPress, txtHasta.KeyPress
        If Not Char.IsNumber(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click

        Dim WDesde, WHasta As String
        Dim WTipoVisualizacion As Enumeraciones.TipoVisualizacionReporte

        WTipoVisualizacion = Enumeraciones.TipoVisualizacionReporte.Pantalla

        If rbImpresora.Checked Then WTipoVisualizacion = Enumeraciones.TipoVisualizacionReporte.Impresora

        WDesde = Val(txtDesde.Text)
        WHasta = Val(txtHasta.Text)

        If Val(WHasta) = 0 Then WHasta = "9999"
        If Val(WDesde) = 0 Then WDesde = "1"

        Dim WOwner As IListarReporteDesdeHastaBasico = TryCast(Owner, IListarReporteDesdeHastaBasico)

        If WOwner IsNot Nothing Then WOwner._ProcesarListarReporteDesdeHastaBasico(WDesde, WHasta, WTipoVisualizacion)

    End Sub

    Private Sub ListarReporteDesdeHastaBasico_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        txtDesde.Focus()
    End Sub

    Private Sub ListarReporteDesdeHastaBasico_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class

Public Class ListadoReporteEventArgs
    Inherits EventArgs

    Public Control As Label

    Sub New(ByRef Control As Label)
        Me.Control = Control
    End Sub

End Class
