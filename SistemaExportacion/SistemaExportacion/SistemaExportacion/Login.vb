﻿Imports Util
Imports Util.Clases
Imports Util.Clases.Query
Imports Util.Clases.Helper

Public Class Login

    Private WEmpresasAcceso As DataTable

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Close()
    End Sub

    Private Sub Login_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        WEmpresasAcceso = New DataTable()
        With WEmpresasAcceso
            .Columns.Add("Nombre")
            .Columns.Add("BaseDatos")

            With .Rows
                .Add("SURFACTAN", "SurfactanSa")
                .Add("PELLITAL", "Pelitall_II") ' Está asi en la Base de Datos.
            End With

        End With

        With cmbEmpresas
            .DataSource = WEmpresasAcceso
            .DisplayMember = "Nombre"
            .ValueMember = "BaseDatos"
            .SelectedIndex = 0
        End With

        txtClave.Text = ""

    End Sub

    Private Sub Login_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        txtClave.Focus()
    End Sub

    Private Sub btnIniciar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIniciar.Click
        Try

            If txtClave.Text.Trim = "" Then Throw New Exception("Debe indicar una Clave de Acceso al Sistema.")
            If cmbEmpresas.SelectedIndex < 0 Then cmbEmpresas.SelectedIndex = 0

            Dim WBaseDatos As String = CType(cmbEmpresas.SelectedItem, DataRowView).Item("BaseDatos")

            Conexion.EmpresaDeTrabajo = WBaseDatos

            Dim WOperador As DataRow = GetSingle("SELECT Operador, Descripcion, SistemaExportacion FROM Operador WHERE UPPER(Clave) = '" & txtClave.Text & "'", WBaseDatos)

            If IsNothing(WOperador) Then Throw New Exception("Clave Errónea")

            Dim PermisoSistemaExportacion As Integer
            With WOperador
                Operador.Base = WBaseDatos
                Operador.Codigo = OrDefault(.Item("Operador"), 0)
                Operador.Clave = txtClave.Text.Trim
                Operador.Descripcion = OrDefault(.Item("Descripcion"), "")
                PermisoSistemaExportacion = IIf(IsDBNull(.Item("SistemaExportacion")), 0, .Item("SistemaExportacion"))
            End With

            Select Case PermisoSistemaExportacion
                Case 1, 3
                    Dim frm As New MenuPrincipal()
                    frm.Show()
                Case 2
                    Dim frm As New MenuPreProformas()
                    frm.Show()
            End Select
            ' If UCase(Operador.Clave) = "PELADO" Then
            '     Dim frm As New MenuPrincipal()
            '     frm.Show()
            '     'Close()
            ' Else
            '     Dim frm As New MenuPreProformas()
            '     frm.Show()
            ' End If

            Close()


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
            With txtClave
                .Focus()
                .SelectionStart = 0
                .SelectionLength = .Text.Length
            End With

        End Try
    End Sub

    Private Sub ComboBox1_DrawItem(ByVal sender As Object, ByVal e As DrawItemEventArgs) Handles cmbEmpresas.DrawItem
        If e.Index >= 0 Then
            Using st As New StringFormat With {.Alignment = StringAlignment.Center}
                e.Graphics.DrawString(CType(sender.Items(e.Index), DataRowView).Item("Nombre").ToString, e.Font, New SolidBrush(Color.Black), e.Bounds, st)
            End Using
        End If
    End Sub

    Private Sub cmbEmpresas_DropDownClosed(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbEmpresas.DropDownClosed
        With txtClave
            .Focus()
            .SelectionStart = 0
            .SelectionLength = .Text.Length
        End With

    End Sub

    Private Sub txtClave_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtClave.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txtClave.Text) = "" Then : Exit Sub : End If

            btnIniciar.PerformClick()

        ElseIf e.KeyData = Keys.Escape Then
            txtClave.Text = ""
        End If

    End Sub

    Private Sub cmbEmpresas_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbEmpresas.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(cmbEmpresas.Text) = "" Then : Exit Sub : End If

            If txtClave.Text.Trim <> "" Then
                btnIniciar_Click(Nothing, Nothing)
            End If

            txtClave.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            cmbEmpresas.SelectedIndex = 0
        End If

    End Sub
End Class