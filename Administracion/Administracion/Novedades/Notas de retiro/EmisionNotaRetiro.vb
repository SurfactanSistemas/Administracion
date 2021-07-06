Imports CrystalDecisions.CrystalReports.Engine

Public Class EmisionNotaRetiro

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        If MsgBox("¿Está seguro/a de querer salir? Los datos no se guardarán.", MsgBoxStyle.YesNo) <> MsgBoxResult.Yes Then Exit Sub
        Close()
    End Sub

    Private Sub EmisionNotaRetiro_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        txtDestinatario.Focus()
    End Sub

    Private Sub EmisionNotaRetiro_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtFechaCheque.Text = ""
        txtFechaRetiro.Text = Date.Now.ToString("dd/MM/yyyy")
        ckSiCheque_MouseUp(Nothing, Nothing)
        limpiar()
    End Sub

    Private Sub txtDestinatario_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDestinatario.KeyDown, txtNotasAdicionales.KeyDown, txtMontoCheque.KeyDown, txtMailRetira.KeyDown, txtMailDestinatario.KeyDown, txtHorarios.KeyDown, txtFechaRetiro.KeyDown, txtFechaCheque.KeyDown, txtCoordinado.KeyDown, txtBancoCheque.KeyDown, txtNumero.KeyDown
        Dim control As Control = TryCast(sender, Control)

        If control Is Nothing Then Exit Sub

        If e.KeyData = Keys.Enter Then

            If Trim(control.Text.Replace("/", "")) = "" Then : Exit Sub : End If

            Select Case control.Name
                Case txtDestinatario.Name
                    txtMailDestinatario.Focus()
                Case txtMailDestinatario.Name
                    txtMailRetira.Focus()
                Case txtMailRetira.Name
                    txtFechaRetiro.Focus()
                Case txtFechaRetiro.Name
                    If txtFechaRetiro.Text.Replace(" ", "").Length = 10 Then txtHorarios.Focus()
                Case txtHorarios.Name
                    txtQueRetirar.Focus()
                Case txtMontoCheque.Name
                    txtMontoCheque.Text = formatonumerico(txtMontoCheque.Text)
                    txtFechaCheque.Focus()
                Case txtFechaCheque.Name
                    If txtFechaCheque.Text.Replace(" ", "").Length = 10 Then txtNumero.Focus()
                Case txtNumero.Name
                    If Val(txtNumero.Text) > 0 Then txtBancoCheque.Focus()
                Case txtBancoCheque.Name
                    txtNotasAdicionales.Focus()
                Case txtCoordinado.Name
                    txtNotasAdicionales.Focus()
            End Select

        ElseIf e.KeyData = Keys.Escape Then
            control.Text = ""
        End If

    End Sub

    Private Sub ckSiCheque_MouseUp(sender As Object, e As MouseEventArgs) Handles ckSiCheque.MouseUp
        For Each c As Control In {txtMontoCheque, txtBancoCheque, txtFechaCheque}
            c.Enabled = ckSiCheque.Checked
        Next

        If ckSiCheque.Checked Then
            txtMontoCheque.Focus()
        Else
            txtNotasAdicionales.Focus()
        End If

    End Sub

    Private Sub btnEmitir_Click(sender As Object, e As EventArgs) Handles btnEmitir.Click
        If Not _DatosValidos() Then Exit Sub

        Dim tabla As DataTable = New DBAuxi.NotaRetiroDataTable

        Dim r As DataRow = tabla.NewRow

        With r
            .Item("Destino") = txtDestinatario.Text
            .Item("FechaRetiro") = txtFechaRetiro.Text
            .Item("QueRetirar") = txtQueRetirar.Text
            .Item("Horarios") = txtHorarios.Text
            .Item("ConQuien") = txtCoordinado.Text
            .Item("SiCheque") = ckSiCheque.Checked
            .Item("Monto") = Val(formatonumerico(txtMontoCheque.Text))
            .Item("FechaCheque") = txtFechaCheque.Text
            .Item("Banco") = txtBancoCheque.Text
            .Item("Numero") = txtNumero.Text.PadLeft(6)
            .Item("Notas") = txtNotasAdicionales.Text
        End With

        tabla.Rows.Add(r)

        Dim reporte As ReportDocument = New ReporteNotaRetiro
        reporte.SetDataSource(tabla)

        With New VistaPrevia
            .Reporte = reporte
            .Reconectar = False
            .Exportar("notaretiro.pdf", CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, "C:\tempMail")
            If txtMailDestinatario.Text.Trim <> "" Then
                .EnviarPorEmail("C:\tempMail\notaretiro.pdf", False, "SURFACTAN S.A - Nota de Retiro " & txtFechaRetiro.Text, "Estimados. <br/>Se adjunta la nota de retiro correspondiente a la fecha " & txtFechaRetiro.Text, txtMailDestinatario.Text, "")
            End If
            If txtMailRetira.Text.Trim <> "" Then
                .EnviarPorEmail("C:\tempMail\notaretiro.pdf", False, "SURFACTAN S.A - Nota de Retiro " & txtFechaRetiro.Text, "Estimado. <br/>Se adjunta la nota de retiro correspondiente a la fecha " & txtFechaRetiro.Text, txtMailRetira.Text, "")
            End If
            .Mostrar()
        End With

        limpiar()
    End Sub

    Private Sub limpiar()
        For Each c As Control In {txtDestinatario, txtCoordinado, txtBancoCheque, txtFechaCheque, txtFechaRetiro, txtMailDestinatario, txtHorarios, txtMailRetira, txtMontoCheque, txtNotasAdicionales, txtNumero, txtQueRetirar}
            c.Text = ""
        Next
        ckSiCheque.Checked = False
        ckSiCheque_MouseUp(Nothing, Nothing)
    End Sub

    Private Function _DatosValidos() As Boolean

        Dim datos_validos As Boolean = True
        Dim motivos As New List(Of String)

        If txtDestinatario.Text.Trim = "" Then
            motivos.Add(vbTab & "- Debe indicar destinatario." & vbCrLf)
            txtDestinatario.Focus()
            datos_validos = False
        End If

        If txtFechaRetiro.Text.Replace(" ", "").Length < 10 Then
            motivos.Add(vbTab & "- Debe indicar una Fecha válida de Retiro." & vbCrLf)
            txtFechaRetiro.Focus()
            datos_validos = False
        End If

        If txtQueRetirar.Text.Trim = "" Then
            motivos.Add(vbTab & "- Debe indicar qué se debe retirar." & vbCrLf)
            txtQueRetirar.Focus()
            datos_validos = False
        End If

        If ckSiCheque.Checked Then

            If Val(txtMontoCheque.Text) <= 0 Then
                motivos.Add(vbTab & "- Debe indicar el monto correspondiente al Cheque." & vbCrLf)
                txtMontoCheque.Text = ""
                txtMontoCheque.Focus()
                datos_validos = False
            End If

            If txtFechaCheque.Text.Replace(" ", "").Length < 10 Then
                motivos.Add(vbTab & "- Debe indicar una Fecha válida para el Cheque." & vbCrLf)
                txtFechaCheque.Focus()
                datos_validos = False
            End If

            If txtBancoCheque.Text.Trim = "" Then
                motivos.Add(vbTab & "- Debe indicar a cuál Banco corresponde el Cheque." & vbCrLf)
                txtBancoCheque.Focus()
                datos_validos = False
            End If

        End If

        If Not datos_validos Then

            MsgBox("Se han encontrados errores al querer emitir la Nota de Retiro" & vbCrLf & "Motivos: " & vbCrLf & String.Concat(motivos), MsgBoxStyle.Exclamation)

        End If

        Return datos_validos

    End Function

    Private Sub SoloNumero(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumero.KeyPress
        If Not Char.IsNumber(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub NumerosConComas(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMontoCheque.KeyPress
        If Not Char.IsNumber(e.KeyChar) And Not Char.IsControl(e.KeyChar) And Not (CChar(".")) = e.KeyChar Then
            e.Handled = True
        End If
    End Sub

End Class