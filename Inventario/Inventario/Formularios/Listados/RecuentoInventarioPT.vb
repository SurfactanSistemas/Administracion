Imports System.Data.SqlClient
Imports Inventario.Clases

Public Class RecuentoInventarioPT : Implements IAyudaPT

    Private WTargetAyuda As Control

    Private Sub RecuentoInventarioPT_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
    
    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Close()
    End Sub

    Private Sub Ayuda_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDesde.Enter, txtHasta.Enter
        WTargetAyuda = CType(sender, Control)
    End Sub

    Private Sub btnConsulta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsulta.Click

        If IsNothing(WTargetAyuda) Then
            WTargetAyuda = txtDesde
        End If

        Dim frm As New AyudaPT
        frm.Show(Me)

    End Sub

    Private Sub Ayuda_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtDesde.MouseDoubleClick, txtHasta.MouseDoubleClick
        btnConsulta.PerformClick()
    End Sub

    Private Sub txtDesde_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDesde.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txtDesde.Text.Replace("-", "")) = "" Then

                WTargetAyuda = txtDesde

                btnConsulta.PerformClick()

                Exit Sub
            End If

            If txtHasta.Text.Replace("-", "").Trim = "" Then
                txtHasta.Text = txtDesde.Text
            End If

            txtHasta.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtDesde.Text = ""
        End If

    End Sub

    Private Sub txtHasta_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtHasta.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txtHasta.Text.Replace("-", "")) = "" Then

                WTargetAyuda = txtHasta

                btnConsulta.PerformClick()

                Exit Sub
            End If

            txtDesde.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtHasta.Text = ""
        End If

    End Sub

    Private Sub RecuentoInventarioPT_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        txtDesde.Focus()
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Try

            txtHasta.Text = UCase(txtHasta.Text)
            txtDesde.Text = UCase(txtDesde.Text)

            If txtHasta.Text < txtDesde.Text Then

                Dim temp = txtHasta.Text

                txtHasta.Text = txtDesde.Text

                txtDesde.Text = temp

            End If

            Dim ds As New DSRecuentoInventario
            Dim WDatos As SqlDataAdapter = _TraerDatos()
            WDatos.Fill(ds, "Detalles")

            Dim rpt As New ReporteRecuentoInventarioPT
            rpt.SetDataSource(ds)

            Dim frm As New VistaPrevia
            frm.Reporte = rpt

            If rbImpresora.Checked Then
                frm.Imprimir()
            Else
                frm.Show(Me)
            End If

        Catch ex As Exception

            MsgBox(ex.Message, MsgBoxStyle.Exclamation)

        End Try
    End Sub

    Private Function _TraerDatos() As SqlDataAdapter

        Dim WEmpresa = IIf(Helper._EsPellital, "PELLITAL S.A.", "SURFACTAN S.A.")
        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT i.Clave, i.Terminado, t.Descripcion, i.Numero, i.Cantidad, i.Lote, i.Talon, i.Observaciones, i.Ubicacion, Empresa = '" & WEmpresa & "' FROM Inventario i LEFT OUTER JOIN Terminado t ON t.Codigo = i.Terminado WHERE i.Tipo = 'T' AND i.Terminado BETWEEN '" & txtDesde.Text & "' AND '" & txtHasta.Text & "' ORDER BY i.Clave")

        Try

            cn.ConnectionString = Helper._ConectarA(Conexion.EmpresaDeTrabajo)
            cn.Open()
            cm.Connection = cn

            Dim dr As New SqlDataAdapter(cm)

            Return dr

        Catch ex As Exception
            Throw New Exception("Hubo un problema al querer consultar la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        Finally

            'dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

    End Function

    Private Sub UCASE_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDesde.Leave, txtHasta.Leave
        CType(sender, MaskedTextBox).Text = CType(sender, MaskedTextBox).Text.ToUpper
    End Sub

    Public Sub AsignarPT(ByVal _Codigo As Object, ByVal _Descripcion As Object) Implements IAyudaPT.AsignarPT
        If Not IsNothing(WTargetAyuda) Then

            WTargetAyuda.Text = _Codigo

            SendKeys.Send("{ENTER}")

        End If
    End Sub
End Class