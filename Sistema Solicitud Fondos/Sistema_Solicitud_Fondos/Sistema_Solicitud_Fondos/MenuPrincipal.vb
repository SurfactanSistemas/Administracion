﻿Imports Util
Imports Util.Operador
Imports Util.Clases.Query
Public Class MenuPrincipal
    Dim PermisoGrabar As String = ""
  
    Private Sub FinDeSistemasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FinDeSistemasToolStripMenuItem.Click
        Close()
    End Sub

    Private Sub IngresoDeSolicitudToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles IngresoDeSolicitudToolStripMenuItem.Click
        If Operador.Clave = "" Then
            With New Sistema_Solicitud_Fondos.Login("Crear")
                .Show(Me)
            End With
        Else
            With New Sistema_Solicitud_Fondos.Ingreso_Solicitud
                .Show()
            End With
        End If
        'With New Ingreso_Solicitud
        '    .Show()
        'End With
    End Sub

    Private Sub GestionSolicitudesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GestionSolicitudesToolStripMenuItem.Click
        With New Gestion_Solicitudes
            .Show()
        End With
    End Sub

    Private Sub AutoGestionarSolicitudesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AutoGestionarSolicitudesToolStripMenuItem.Click
        If Operador.Clave = "" Then

            With New Sistema_Solicitud_Fondos.Login("Gestion", "Externo")
                .Show(Me)
            End With



        Else
            If PermisoGrabar = "" Then
                BuscarPermiso()
            End If

            If PermisoGrabar = "S" Then
                With New Sistema_Solicitud_Fondos.Gestion_Solicitudes
                    .Show()
                End With
            Else
                With New Sistema_Solicitud_Fondos.AutoGestionSolicitudes
                    .Show()
                End With
            End If





        End If
        'With New AutoGestionSolicitudes
        '    .Show()
        'End With
    End Sub

    Private Sub BuscarPermiso()
        Dim WOperador As DataRow = GetSingle("SELECT SolicitudFondosEdicion FROM Operador WHERE UPPER(Clave) = '" & Operador.Clave & "'", "SurfactanSa")
        If WOperador IsNot Nothing Then
            PermisoGrabar = IIf(IsDBNull(WOperador.Item("SolicitudFondosEdicion")), "", WOperador.Item("SolicitudFondosEdicion"))
        End If
    End Sub
    Private Sub MenuPrincipal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GestionSolicitudesToolStripMenuItem.Visible = False
    End Sub
End Class
