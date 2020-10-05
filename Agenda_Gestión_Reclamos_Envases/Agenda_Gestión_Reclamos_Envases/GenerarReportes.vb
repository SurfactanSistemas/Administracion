﻿Imports System.Runtime.Serialization.Formatters
Imports Util
Imports Util.Clases.Helper

Public Class GenerarReportes

    Private Sub btnListar_Click(sender As Object, e As EventArgs) Handles btnListar.Click
        Dim WFormula As String = ""

        If rbCumplidos.Checked Then
            txt_FechaDesde.Text = ""
            txt_FechaHasta.Text = ""
            pnl_Fechas.Visible = True
            txt_FechaDesde.Focus()
            Exit Sub
        End If


        If rbFaltantes.Checked Then
            WFormula = "{DevolucionEnvMinutas.CantEnvIngresan} = 0"
        End If

        With New VistaPrevia
            .Reporte = New ListadoMinutas()
            .Formula = WFormula
            .Mostrar()
        End With

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Close()
    End Sub

    Private Sub btn_Aceptar_Click(sender As Object, e As EventArgs) Handles btn_Aceptar.Click
        Dim WFormula As String
        Dim WDesde As String = txt_FechaDesde.Text
        Dim WHasta As String = txt_FechaHasta.Text
        If ValidaFecha(txt_FechaDesde.Text) = "S" And ValidaFecha(txt_FechaHasta.Text) = "S" Then
            WDesde = Microsoft.VisualBasic.Right(WDesde, 4) & "-" & Mid(WDesde, 4, 2) & "-" & Microsoft.VisualBasic.Left(WDesde, 2)
            WHasta = Microsoft.VisualBasic.Right(WHasta, 4) & "-" & Mid(WHasta, 4, 2) & "-" & Microsoft.VisualBasic.Left(WHasta, 2)
        End If

        WFormula = "{DevolucionEnvMinutas.CantEnvIngresan} > 0 AND {DevolucionEnvMinutas.WDate} >= '" & WDesde & "' AND {DevolucionEnvMinutas.WDate} <= '" & WHasta & "'"

        pnl_Fechas.Visible = False

        With New VistaPrevia
            .Reporte = New ListadoMinutas()
            .Formula = WFormula
            .Mostrar()
        End With
    End Sub

    Private Sub btn_Cancelar_Click(sender As Object, e As EventArgs) Handles btn_Cancelar.Click
        pnl_Fechas.Visible = False
    End Sub

    Private Sub txt_FechaDesde_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_FechaDesde.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                If ValidaFecha(txt_FechaDesde.Text) = "S" Then
                    txt_FechaHasta.Focus()
                End If
            Case Keys.Escape
                txt_FechaDesde.Text = ""
        End Select
    End Sub

    Private Sub txt_FechaHasta_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_FechaHasta.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                If ValidaFecha(txt_FechaHasta.Text) = "S" Then
                    btn_Aceptar_Click(Nothing, Nothing)
                End If
            Case Keys.Escape
                txt_FechaHasta.Text = ""
        End Select
    End Sub
End Class