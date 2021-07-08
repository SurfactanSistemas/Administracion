Imports CrystalDecisions.CrystalReports.Engine
Imports Util

Public Class EmisionNotaRetiro : Implements Util.IAyudaGeneral

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

    Private Sub txtDestinatario_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDestinatario.KeyDown, txtNotasAdicionales.KeyDown, txtMontoCheque.KeyDown, txtMailRetira.KeyDown, txtMailDestinatario.KeyDown, txtHorarios.KeyDown, txtFechaRetiro.KeyDown, txtFechaCheque.KeyDown, txtCoordinado.KeyDown, txtBancoCheque.KeyDown, txtNumero.KeyDown, txtDireccion.KeyDown, txtNombreRespRetiro.KeyDown
        Dim control As Control = TryCast(sender, Control)

        If control Is Nothing Then Exit Sub

        If e.KeyData = Keys.Enter Then

            If Trim(control.Text.Replace("/", "")) = "" Then : Exit Sub : End If

            Select Case control.Name
                Case txtDestinatario.Name
                    txtMailDestinatario.Focus()
                Case txtMailDestinatario.Name
                    txtNombreRespRetiro.Focus()
                Case txtNombreRespRetiro.Name
                    txtMailRetira.Focus()
                Case txtMailRetira.Name
                    txtFechaRetiro.Focus()
                Case txtFechaRetiro.Name
                    If txtFechaRetiro.Text.Replace(" ", "").Length = 10 Then txtHorarios.Focus()
                Case txtHorarios.Name
                    txtDireccion.Focus()
                Case txtDireccion.Name
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
            .Item("Direccion") = txtDireccion.Text
            .Item("NombreResp") = txtNombreRespRetiro.Text
        End With

        tabla.Rows.Add(r)

        Dim reporte As ReportDocument = New ReporteNotaRetiro
        reporte.SetDataSource(tabla)

        Dim WImprimir As Boolean = True

        With New VistaPrevia
            .Reporte = reporte
            .Reconectar = False
            .Exportar("notaretiro.pdf", CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, "C:\tempMail")

            If txtMailDestinatario.Text.Trim <> "" Then
                If MsgBox("¿Enviar Nota de retiro a " & txtDestinatario.Text & "?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

                    .EnviarPorEmail("C:\tempMail\notaretiro.pdf", False, "SURFACTAN S.A - Nota de Retiro " & txtFechaRetiro.Text, "Estimados. <br/>Se adjunta la nota de retiro correspondiente a la fecha " & txtFechaRetiro.Text, txtMailDestinatario.Text, "")
                End If
            End If

            If txtMailRetira.Text.Trim <> "" Then
                If MsgBox("¿Enviar Nota de retiro a " & txtNombreRespRetiro.Text & "?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    .EnviarPorEmail("C:\tempMail\notaretiro.pdf", False, "SURFACTAN S.A - Nota de Retiro " & txtFechaRetiro.Text, "Estimado. <br/>Se adjunta la nota de retiro correspondiente a la fecha " & txtFechaRetiro.Text, txtMailRetira.Text, "")
                    WImprimir = False
                End If
            End If

            If Not WImprimir Then
                If MsgBox("¿Imprimir la Nota de Retiro?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    WImprimir = True
                End If
            End If

            If WImprimir Then
                .Imprimir()
            Else
                .Mostrar()
            End If

        End With

        limpiar()
    End Sub

    Private Sub limpiar()
        For Each c As Control In {txtDestinatario, txtCoordinado, txtBancoCheque, txtFechaCheque, txtFechaRetiro, txtMailDestinatario, txtHorarios, txtMailRetira, txtMontoCheque, txtNotasAdicionales, txtNumero, txtQueRetirar, txtDireccion, txtNombreRespRetiro}
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

        If txtNombreRespRetiro.Text.Trim = "" Then
            motivos.Add(vbTab & "- Debe indicar el nombre de la persona que va a retirar." & vbCrLf)
            txtNombreRespRetiro.Focus()
            datos_validos = False
        End If

        If txtDireccion.Text.Trim = "" Then
            motivos.Add(vbTab & "- Debe indicar la dirección del lugar donde hay que ir a retirar." & vbCrLf)
            txtDireccion.Focus()
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

    Private Sub btnConsulta_Click(sender As Object, e As EventArgs) Handles btnConsulta.Click
        With New Util.AyudaGeneral(GetAll("SELECT Proveedor As Codigo, Nombre as Descripcion FROM Proveedor WHERE Nombre <> '' And Provincia < 2 ORDER BY Nombre"), "PROVEEDORES")
            .Show(Me)
        End With
        txtNombreRespRetiro.Focus()
    End Sub

    Public Sub _ProcesarAyudaGeneral(row As DataGridViewRow) Implements IAyudaGeneral._ProcesarAyudaGeneral
        Dim datos As DataRow = GetSingle("SELECT Nombre, Email, Direccion, Localidad FROM Proveedor WHERE Proveedor = '" & OrDefault(row.Cells("Codigo").Value, "") & "'")

        If datos Is Nothing Then Exit Sub

        txtDestinatario.Text = OrDefault(datos("Nombre"), "")
        txtMailDestinatario.Text = OrDefault(datos("Email"), "")
        txtDireccion.Text = OrDefault(datos("Direccion"), "") & " - " & OrDefault(datos("Localidad"), "")

    End Sub
End Class