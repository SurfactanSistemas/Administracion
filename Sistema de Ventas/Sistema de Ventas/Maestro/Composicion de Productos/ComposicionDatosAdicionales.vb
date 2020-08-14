Public Class ComposicionDatosAdicionales
    Private ReadOnly WDatosAdicionales As DatosAdicionales
    Sub New(ByVal DatosAdicionales As DatosAdicionales)

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        WDatosAdicionales = DatosAdicionales
    End Sub

    Private Sub ComposicionDatosAdicionales_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With WDatosAdicionales
            txtCaracteristicas.Text = .Caracteristicas
            txtClase.Text = .Clase
            txtEmbalaje.Text = .Embalaje
            txtFIntervension.Text = .FIntervencion
            txtNUnidas.Text = .NUnidas
            txtRiesgo.Text = .Riesgo
            txtRSec.Text = .RSec
            txtVidaUtil.Text = .VidaUtil
            cmbCarga.SelectedIndex = .Carga
            cmbEstado.SelectedIndex = .Estado
            ckRestriccion.Checked = .Restriccion
        End With
    End Sub

    Public Function ObtenerDatos() As DatosAdicionales
        Return WDatosAdicionales
    End Function

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Close()
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click

        DialogResult = Windows.Forms.DialogResult.OK

        With WDatosAdicionales
            .Caracteristicas = txtCaracteristicas.Text
            .Carga = cmbCarga.SelectedIndex
            .Clase = txtClase.Text
            .Embalaje = txtEmbalaje.Text
            .Estado = cmbEstado.SelectedIndex
            .FIntervencion = txtFIntervension.Text
            .NUnidas = txtNUnidas.Text
            .Riesgo = txtRiesgo.Text
            .RSec = txtRSec.Text
            .VidaUtil = Val(txtVidaUtil.Text)
            .Restriccion = ckRestriccion.Checked
        End With

        Dim WOwner As IComposicionDatosAdicionales = TryCast(Owner, IComposicionDatosAdicionales)

        If WOwner IsNot Nothing Then WOwner._ProcesarComposicionDatosAdicionales(WDatosAdicionales)

        Close()

    End Sub

    Private Sub ComposicionDatosAdicionales_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        txtNUnidas.Focus()
    End Sub
End Class