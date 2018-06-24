Imports System.Data.SqlClient
Imports ClasesCompartidas

Public Class CierreMes

    Private Sub CierreMes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Label2.Text = Proceso.NombreEmpresa()
        txtMes.Text = ""
        txtAno.Text = ""
        cmbEstado.SelectedIndex = 2
    End Sub



    Private Sub txtMes_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtMes.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txtMes.Text) = "" Then : Exit Sub : End If

            Dim WMes = Val(txtMes.Text)

            If WMes < 1 Or WMes > 12 Then Exit Sub

            _VerificarEstado()

            txtAno.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtMes.Text = ""
        End If

    End Sub

    Private Sub _VerificarEstado()

        Dim cn = New SqlConnection()
        Dim cm = New SqlCommand("SELECT Estado FROM Cierre WHERE Mes = '" & txtMes.Text & "' AND Ano = '" & txtAno.Text & "'")
        Dim dr As SqlDataReader

        Try

            cn.ConnectionString = Proceso._ConectarA
            cn.Open()
            cm.Connection = cn

            dr = cm.ExecuteReader()

            If dr.HasRows Then
                dr.Read()

                cmbEstado.SelectedIndex = dr.Item("Estado")
            Else
                cmbEstado.SelectedIndex = 2
            End If

        Catch ex As Exception
            Throw New Exception("Hubo un problema al querer consultar la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

    End Sub

    Private Sub txtAno_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtAno.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txtAno.Text) = "" Then : Exit Sub : End If

            Dim WAno = Val(txtAno.Text)

            If WAno < 0 Then Exit Sub

            _VerificarEstado()

            txtMes.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtAno.Text = ""
        End If

    End Sub

    Private Sub CierreMes_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        txtMes.Focus()
    End Sub

    Private Sub btnMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMenu.Click
        Me.Close()
    End Sub

    Private Sub btnGraba_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGraba.Click

        If cmbEstado.SelectedIndex = 2 Then Exit Sub

        Dim cn = New SqlConnection()
        Dim cm = New SqlCommand("SELECT * FROM Cierre WHERE Mes = '" & txtMes.Text & "' AND Ano = '" & txtAno.Text & "'")
        Dim dr As SqlDataReader
        Dim ZSql = ""

        Try

            cn.ConnectionString = Proceso._ConectarA
            cn.Open()
            cm.Connection = cn

            dr = cm.ExecuteReader()

            If dr.HasRows Then

                ZSql = "UPDATE Cierre SET "
                ZSql &= " Estado = " & "'" & Str$(cmbEstado.SelectedIndex) & "'"
                ZSql &= " Where Mes = " & "'" & txtMes.Text & "'"
                ZSql &= " and Ano = " & "'" & txtAno.Text & "'"

            Else

                ZSql = "INSERT INTO Cierre ("
                ZSql &= "Mes ,"
                ZSql &= "Ano ,"
                ZSql &= "Estado)"
                ZSql &= "Values ("
                ZSql &= "'" + txtMes.Text + "',"
                ZSql &= "'" + txtAno.Text + "',"
                ZSql &= "'" + Str$(cmbEstado.SelectedIndex) + "')"

            End If

            If Not dr.IsClosed Then
                dr.Close()
            End If

            cm.CommandText = ZSql
            cm.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox("Hubo un problema al querer Actualizar el Estado del Mes en la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
            txtMes.Focus()
            Exit Sub
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

        btnMenu.PerformClick()

    End Sub

    Private Sub SoloNumero(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMes.KeyPress, txtAno.KeyPress
        If Not Char.IsNumber(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

End Class