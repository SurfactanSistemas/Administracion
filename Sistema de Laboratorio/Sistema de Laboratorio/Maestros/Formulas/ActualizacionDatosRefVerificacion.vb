Public Class ActualizacionDatosRefVerificacion
    Private ReadOnly Terminado As String
    Private ReadOnly Renglon As Integer

    Sub New(ByVal Terminado As String, ByVal Renglon As Integer)

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me.Terminado = Terminado
        Me.Renglon = Renglon

    End Sub

    Private Sub ActualizacionDatosRefVerificacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim datos As DataRow = GetSingle("SELECT Top 1 FechaVerificacion, ReferenciaVerificacion, PartidaVerificacion FROM FormulasDeEnsayos WHERE Terminado = '" & Terminado & "' And Renglon = '" & Renglon & "' Order by Renglon", "Surfactan_II")

        Dim WFecha, WRef, WPart As String

        WFecha = ""
        WRef = ""
        WPart = ""

        If datos IsNot Nothing Then

            WFecha = OrDefault(datos("FechaVerificacion"), "")
            WRef = OrDefault(datos("ReferenciaVerificacion"), "")
            WPart = OrDefault(datos("PartidaVerificacion"), "")

        End If

        txtFecha.Text = WFecha
        txtReferencia.Text = WRef.Trim
        txtPartida.Text = WPart

    End Sub

    Private Sub ActualizacionDatosRefVerificacion_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        txtFecha.Focus()
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click

        Dim WFecha, WRef, WPart As String

        WFecha = txtFecha.Text
        WRef = txtReferencia.Text.Trim
        WPart = txtPartida.Text

        ExecuteNonQueries("Surfactan_II", {"UPDATE FormulasDeEnsayos SET FechaVerificacion = '" & WFecha & "', ReferenciaVerificacion = '" & WRef & "', PartidaVerificacion = '" & WPart & "' WHERE Terminado = '" & Terminado & "' AND Renglon = '" & Renglon & "'"})

        Dim WOwner As IImprimirPlanillaVerificacion = TryCast(Owner, IImprimirPlanillaVerificacion)

        If WOwner IsNot Nothing Then WOwner._ProcesarImprimirPlanillaVerificacion(Terminado, Renglon)

        Close()

    End Sub

    Private Sub txtFecha_KeyDown(sender As Object, e As KeyEventArgs) Handles txtFecha.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                txtPartida.Focus()
            Case Keys.Escape
                txtFecha.Clear()
        End Select

    End Sub

    Private Sub txtPartida_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPartida.KeyDown

        Select Case e.KeyCode
            Case Keys.Enter
                txtReferencia.Focus()
            Case Keys.Escape
                txtPartida.Text = ""
        End Select

    End Sub

    Private Sub txtReferencia_KeyDown(sender As Object, e As KeyEventArgs) Handles txtReferencia.KeyDown

        Select Case e.KeyCode
            Case Keys.Enter
                btnAceptar_Click(Nothing, Nothing)
            Case Keys.Escape
                txtReferencia.Text = ""
        End Select

    End Sub

End Class