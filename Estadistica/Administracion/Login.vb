﻿Imports ClasesCompartidas
Imports System.Data.SqlClient

Public Class Login
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Close()
    End Sub

    Private Sub Login_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        'If Asc(e.KeyChar) = Keys.Enter Then
        '    btnAccept.PerformClick()
        'End If
    End Sub

    Private Sub Login_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cmbEntity.DataSource = Globals.connectionStringNames()
    End Sub

    Private Function validarCampos()
        Dim validador As New Validator
        validador.validate(Me)
        validador.alsoValidate(Globals.connectionWorksFor(cmbEntity.Text), "La conexión con la base de datos falló")
        Return validador.flush()
    End Function

    Private Sub btnAccept_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAccept.Click
        If validarCampos() Then
            Globals.empresa = cmbEntity.Text
            MenuPrincipal.Show()
            Close()
        End If
    End Sub

    Private Sub cmbEntity_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbEntity.TextChanged
        txtClave.Focus()
    End Sub

    Private Sub cmbEntity_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbEntity.KeyDown

        If e.KeyData = Keys.Enter Then
            txtClave.Focus()
        End If

    End Sub

    Private Function _BuscarVendedor(ByVal clave As String) As Vendedor
        Dim _vendedor As Vendedor
        Dim WPermisos As Integer = 0

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT v.Vendedor, v.Nombre, o.Vendedor as Permisos FROM Operador as o, Vendedor as v WHERE Clave = '" & clave & "'")
        Dim dr As SqlDataReader

        SQLConnector.conexionSql(cn, cm)

        Try

            dr = cm.ExecuteReader()

            With dr
                If .HasRows Then
                    .Read()

                    WPermisos = IIf(IsDBNull(.Item("Permisos")), 0, .Item("Permisos"))

                    If WPermisos <> 0 Then

                        _vendedor = New Vendedor(.Item("Vendedor"), .Item("Nombre"))

                        Vendedor.permisos = WPermisos

                    End If

                End If
            End With
            

        Catch ex As Exception
            MsgBox("Hubo un problema al querer consultar la Base de Datos.", MsgBoxStyle.Critical)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try
        Return _vendedor
    End Function

    Private Sub txtClave_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtClave.KeyDown


        If e.KeyData = Keys.Enter Then
            If Trim(txtClave.Text) = "" Then : Exit Sub : End If

            If IsNothing(Globals.empresa) Then
                Globals.empresa = cmbEntity.Text
            End If

            Dim _Vendedor As Vendedor = _BuscarVendedor(Trim(txtClave.Text))

            If IsNothing(_Vendedor) Then
                MsgBox("No tiene permisos para acceder al sistema de Estadisticas.", MsgBoxStyle.Information)
                Exit Sub
            End If

        ElseIf e.KeyData = Keys.Escape Then
            txtClave.Text = ""
        End If



    End Sub
End Class