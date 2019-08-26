Imports ConsultasVarias

Public Class IngresoEnsayos : Implements IIngresoClaveSeguridad

    Private ReadOnly WBase As String = ""
    Private WAutorizado As Boolean = False
    Private WProceso As Byte = 0

    Sub New(Optional ByVal Codigo As Object = 0)

        ' This call is required by the designer.
        InitializeComponent()

        WBase = IIf(_EsPellital, "Pelitall_II", "Surfactan_II")

        ' Add any initialization after the InitializeComponent() call.

        If Codigo > 0 Then

            Dim WEnsayo As DataRow = GetSingle("SELECT  * FROM Ensayos WHERE Codigo = '" & Codigo & "'", WBase)

            If WEnsayo Is Nothing Then
                MsgBox("No se pudo encontrar el Ensayo " & Codigo, MsgBoxStyle.Exclamation)
                Close()
            End If

            With WEnsayo
                txtCodigo.Text = Trim(OrDefault(.Item("Codigo"), ""))
                txtUnidad.Text = Trim(OrDefault(.Item("Unidad"), ""))
                txtDescripcion.Text = Trim(OrDefault(.Item("Descripcion"), ""))
                txtDescripcionIngles.Text = Trim(OrDefault(.Item("DescripcionII"), ""))
            End With

        Else

            Dim WUltimo As DataRow = GetSingle("SELECT MAX(Codigo) Ultimo FROM Ensayos", WBase)

            If WUltimo IsNot Nothing Then txtCodigo.Text = OrDefault(WUltimo.Item("Ultimo"), 0)

            txtCodigo.Text = Val(txtCodigo.Text) + 1

        End If

        txtCodigo.ReadOnly = True

        txtDescripcion.Focus()

    End Sub

    Private Sub txtCodigo_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtUnidad.KeyDown, txtDescripcionIngles.KeyDown, txtDescripcion.KeyDown, txtCodigo.KeyDown

        Dim WControl As TextBox = TryCast(sender, TextBox)

        If WControl Is Nothing Then Exit Sub

        If e.KeyData = Keys.Enter Then
            WControl.Text = Trim(WControl.Text)

            Select Case WControl.Name.Replace("txt", "")
                Case "Codigo"
                    txtUnidad.Focus()
                Case "Unidad"
                    txtDescripcion.Focus()
                Case "Descripcion"
                    txtDescripcionIngles.Focus()
                Case "DescripcionIngles"
                    txtDescripcion.Focus()
            End Select

        ElseIf e.KeyData = Keys.Escape Then
            WControl.Text = ""
        End If

    End Sub

    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click

        If txtDescripcion.Text.Trim = "" Then
            MsgBox("No se ha cargado la Descripcion del Ensayo.", MsgBoxStyle.Exclamation)
            txtDescripcion.Focus()
            Exit Sub
        End If

        If Not WAutorizado Then
            WProceso = 1
            With New IngresoClaveSeguridad
                .Show(Me)
            End With
            Exit Sub
        End If

        WAutorizado = False
        WProceso = 0

        Dim WCodigo, WUnidad, WDescripcion, WDescripcionII, WSql As String

        WCodigo = txtCodigo.Text.Trim
        WUnidad = txtUnidad.Text.Trim
        WDescripcion = txtDescripcion.Text.Trim
        WDescripcionII = txtDescripcionIngles.Text.Trim

        WSql = String.Format("INSERT INTO Ensayos (Codigo, Descripcion, DescripcionII, Unidad, WDate) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}')", WCodigo, WDescripcion, WDescripcionII, WUnidad, Date.Now.ToString("dd-MM-yyyy"))

        ExecuteNonQueries(WBase, {"DELETE FROM Ensayos WHERE Codigo = '" & WCodigo & "'", WSql})

        Dim WOwner As IActualizarPorNuevoIngreso = TryCast(Owner, IActualizarPorNuevoIngreso)

        If WOwner IsNot Nothing Then WOwner._ProcesarActualizarPorNuevoIngreso()

        Close()

    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click

        Dim WEnsayo As DataRow = GetSingle("SELECT Codigo FROM Ensayos WHERE Codigo = '" & txtCodigo.Text & "'", WBase)

        If WEnsayo IsNot Nothing Then

            If Not WAutorizado Then

                If MsgBox("¿Desea eliminar el Ensayo " & txtCodigo.Text & "?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

                WProceso = 2

                With New IngresoClaveSeguridad
                    .Show(Me)
                End With

                Exit Sub
            End If

            WAutorizado = False
            WProceso = 0

            ExecuteNonQueries(WBase, {"DELETE FROM Ensayos WHERE Codigo = '" & txtCodigo.Text & "'"})

            Dim WOwner As IActualizarPorNuevoIngreso = TryCast(Owner, IActualizarPorNuevoIngreso)

            If WOwner IsNot Nothing Then WOwner._ProcesarActualizarPorNuevoIngreso()

            Close()

        End If

    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Close()
    End Sub

    Public Sub _ProcesarIngresoClaveSeguridad(ByVal WClave As Object) Implements IIngresoClaveSeguridad._ProcesarIngresoClaveSeguridad

        Dim WOper As DataRow = GetSingle("SELECT GrabaII FROM Operador WHERE upper(Clave) = '" & UCase(WClave) & "'")

        If WOper IsNot Nothing Then
            WAutorizado = UCase(OrDefault(WOper.Item("GrabaII"), "N")) = "S"
        End If

        Select Case WProceso
            Case 1
                btnGrabar_Click(Nothing, Nothing)
            Case 2
                btnEliminar_Click(Nothing, Nothing)
            Case Else
                Exit Sub
        End Select

    End Sub

End Class