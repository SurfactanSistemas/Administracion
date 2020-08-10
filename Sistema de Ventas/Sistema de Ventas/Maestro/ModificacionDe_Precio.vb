Imports Util
Imports Util.Clases.Query
Imports Util.Clases.Helper

Public Class ModificacionDe_Precio : Implements IBuscarClienteCashFlow, IConsulta_Terminado, IConsulta_MP

    Private Sub btn_Cerrar_Click(sender As Object, e As EventArgs) Handles btn_Cerrar.Click
        Close()
    End Sub



    Private Sub SoloNumero(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_PorcentajePT.KeyPress, txt_PorcentajeMP.KeyPress
        If Not Char.IsNumber(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub




    Private Sub btn_AceptarPT_Click(sender As Object, e As EventArgs) Handles btn_AceptarPT.Click

        txt_DesdeCliPT.Text = UCase(txt_DesdeCliPT.Text)
        txt_HastaCliPT.Text = UCase(txt_HastaCliPT.Text)
        txt_DesdePT.Text = UCase(txt_DesdePT.Text)
        txt_HastaPT.Text = UCase(txt_HastaPT.Text)

        Dim listaSQLCnslt As New List(Of String)

        Dim SQLCnslt As String = "SELECT Clave, Precio FROM Precios " _
                                 & "WHERE Terminado BETWEEN '" & txt_DesdePT.Text & "' AND '" & txt_HastaPT.Text & "' " _
                                 & "AND Cliente BETWEEN '" & txt_DesdeCliPT.Text & "' AND '" & txt_HastaCliPT.Text & "' " _
                                 & "ORDER BY Clave"

        Dim TablaClave As DataTable = GetAll(SQLCnslt, Operador.Base)

        If TablaClave.Rows.Count > 0 Then
            For Each RowClave As DataRow In TablaClave.Rows

                Dim Precio As Double = RowClave.Item("Precio") + (RowClave.Item("Precio") * Val(txt_PorcentajePT.Text) / 100)
                Dim WPrecio As String = formatonumerico(Precio)
                Dim WClave = RowClave.Item("Clave")
                Dim WDate As String = Date.Today.ToString("MM/dd/yyyy")


                SQLCnslt = "UPDATE  Precios SET Precio = '" & WPrecio & "', Fecha = '" & WDate & "' " _
                             & "WHERE Clave = '" & WClave & "'"

                listaSQLCnslt.Add(SQLCnslt)


            Next

            ExecuteNonQueries(listaSQLCnslt.ToArray(), Operador.Base)
            LimpiarPantalla()

        End If



    End Sub

    Private Sub LimpiarPantalla()

        txt_DesdeCliPT.Text = ""
        txt_HastaCliPT.Text = ""
        txt_DesdePT.Text = ""
        txt_HastaPT.Text = ""
        txt_PorcentajePT.Text = ""
        txt_DesdeCliPTDes.Text = ""
        txt_HastaCliPTDes.Text = ""

        txt_DesdeCliMP.Text = ""
        txt_HastaCliMP.Text = ""
        txt_DesdeMP.Text = ""
        txt_HastaMP.Text = ""
        txt_PorcentajeMP.Text = ""
        txt_DesdeCliMPDes.Text = ""
        txt_HastaCliMPDes.Text = ""

    End Sub

  Private Sub txt_DesdeCliPT_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_DesdeCliPT.KeyDown

        Select Case e.KeyData
            Case Keys.Enter
                txt_DesdeCliPT.Text = UCase(txt_DesdeCliPT.Text)
                Dim SQLCnslt As String = "SELECT Razon FROM CLiente WHERE Cliente = '" & txt_DesdeCliPT.Text & "'"
                Dim RowCli As DataRow = GetSingle(SQLCnslt, Operador.Base)
                If RowCli IsNot Nothing Then
                    txt_DesdeCliPTDes.Text = RowCli.Item("Razon")
                    txt_HastaCliPT.Focus()
                End If


            Case Keys.Escape
                txt_DesdeCliPT.Text = ""

        End Select


    End Sub

    Private Sub txt_HastaCliPT_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_HastaCliPT.KeyDown

        Select Case e.KeyData
            Case Keys.Enter
                txt_HastaCliPT.Text = UCase(txt_HastaCliPT.Text)
                Dim SQLCnslt As String = "SELECT Razon FROM CLiente WHERE Cliente = '" & txt_HastaCliPT.Text & "'"
                Dim RowCli As DataRow = GetSingle(SQLCnslt, Operador.Base)
                If RowCli IsNot Nothing Then
                    txt_HastaCliPTDes.Text = RowCli.Item("Razon")
                    txt_DesdePT.Focus()
                End If


            Case Keys.Escape
                txt_HastaCliPT.Text = ""

        End Select
    End Sub

    Private Sub txt_DesdePT_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_DesdePT.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                If txt_DesdePT.Text.Length = 12 Then
                    txt_HastaPT.Focus()
                End If
            Case Keys.Escape
                txt_DesdePT.Text = ""
        End Select


    End Sub

    Private Sub txt_HastaPT_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_HastaPT.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                If txt_DesdePT.Text.Length = 12 Then
                    txt_PorcentajePT.Focus()
                End If
            Case Keys.Escape
                txt_HastaPT.Text = ""
        End Select
    End Sub

    Private Sub txt_PorcentajePT_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_PorcentajePT.KeyDown
        Select Case e.KeyData
            Case Keys.Escape
                txt_PorcentajePT.Text = ""
        End Select
    End Sub
    Private Sub txt_DesdeCliMP_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_DesdeCliMP.KeyDown

        Select Case e.KeyData
            Case Keys.Enter
                txt_DesdeCliMP.Text = UCase(txt_DesdeCliMP.Text)
                Dim SQLCnslt As String = "SELECT Razon FROM CLiente WHERE Cliente = '" & txt_DesdeCliMP.Text & "'"
                Dim RowCli As DataRow = GetSingle(SQLCnslt, Operador.Base)
                If RowCli IsNot Nothing Then
                    txt_DesdeCliMPDes.Text = RowCli.Item("Razon")
                    txt_HastaCliMP.Focus()
                End If


            Case Keys.Escape
                txt_DesdeCliMP.Text = ""

        End Select


    End Sub

    Private Sub txt_HastaCliMP_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_HastaCliMP.KeyDown

        Select Case e.KeyData
            Case Keys.Enter
                txt_HastaCliMP.Text = UCase(txt_HastaCliMP.Text)
                Dim SQLCnslt As String = "SELECT Razon FROM CLiente WHERE Cliente = '" & txt_HastaCliMP.Text & "'"
                Dim RowCli As DataRow = GetSingle(SQLCnslt, Operador.Base)
                If RowCli IsNot Nothing Then
                    txt_HastaCliMPDes.Text = RowCli.Item("Razon")
                    txt_DesdeMP.Focus()
                End If


            Case Keys.Escape
                txt_HastaCliMP.Text = ""

        End Select
    End Sub

    Private Sub txt_DesdeMP_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_DesdeMP.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                If txt_DesdeMP.Text.Length = 10 Then
                    txt_HastaMP.Focus()
                End If
            Case Keys.Escape
                txt_DesdeMP.Text = ""
        End Select


    End Sub

    Private Sub txt_HastaMP_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_HastaMP.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                If txt_DesdeMP.Text.Length = 10 Then
                    txt_PorcentajeMP.Focus()
                End If
            Case Keys.Escape
                txt_HastaMP.Text = ""
        End Select
    End Sub

    Private Sub txt_PorcentajeMP_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_PorcentajeMP.KeyDown
        Select Case e.KeyData
            Case Keys.Escape
                txt_PorcentajeMP.Text = ""
        End Select
    End Sub

    Private Sub btn_ConsultaCliPT_Click(sender As Object, e As EventArgs) Handles btn_ConsultaCliPT.Click
        With ConsultaCliente
            If .Visible = True Then
                .Visible = False
            End If
            .Show(Me)
        End With
    End Sub
   

    Public Sub CompletaCliente(CodigoCliente As String, Accion As String) Implements IBuscarClienteCashFlow.CompletaCliente
        If TabControl1.SelectedIndex = 0 Then
            If Accion = "Ambos" Then
                txt_DesdeCliPT.Text = CodigoCliente
                txt_HastaCliPT.Text = CodigoCliente

                txt_DesdeCliPT_KeyDown(Nothing, New KeyEventArgs(Keys.Enter))
                txt_HastaCliPT_KeyDown(Nothing, New KeyEventArgs(Keys.Enter))
            End If


            If Accion = "Desde" Then
                txt_DesdeCliPT.Text = CodigoCliente
                txt_DesdeCliPT_KeyDown(Nothing, New KeyEventArgs(Keys.Enter))
            End If

            If Accion = "Hasta" Then
                txt_HastaCliPT.Text = CodigoCliente
                txt_HastaCliPT_KeyDown(Nothing, New KeyEventArgs(Keys.Enter))
            End If

        Else

            If Accion = "Ambos" Then
                txt_DesdeCliMP.Text = CodigoCliente
                txt_HastaCliMP.Text = CodigoCliente

                txt_DesdeCliMP_KeyDown(Nothing, New KeyEventArgs(Keys.Enter))
                txt_HastaCliMP_KeyDown(Nothing, New KeyEventArgs(Keys.Enter))
            End If

            If Accion = "Desde" Then
                txt_DesdeCliMP.Text = CodigoCliente
                txt_DesdeCliMP_KeyDown(Nothing, New KeyEventArgs(Keys.Enter))
            End If

            If Accion = "Hasta" Then
                txt_HastaCliMP.Text = CodigoCliente
                txt_HastaCliMP_KeyDown(Nothing, New KeyEventArgs(Keys.Enter))
            End If
        End If
    End Sub

    Private Sub btn_ConsultaCliMP_Click(sender As Object, e As EventArgs) Handles btn_ConsultaCliMP.Click
        With ConsultaCliente
            If .Visible = True Then
                .Visible = False
            End If
            .Show(Me)
        End With
    End Sub

    Private Sub btn_ConsultaPT_Click(sender As Object, e As EventArgs) Handles btn_ConsultaPT.Click
        With Consulta_Terminado
            If .Visible = True Then
                .Visible = False
            End If
            .Show(Me)
        End With
    End Sub

    Public Sub PasaCodigo(Codigo As String, Accion As String) Implements IConsulta_Terminado.PasaCodigo

        If Accion = "Ambos" Then
            txt_DesdePT.Text = Codigo
            txt_HastaPT.Text = Codigo
        End If

        If Accion = "Desde" Then
            txt_DesdePT.Text = Codigo
        End If

        If Accion = "Hasta" Then
            txt_HastaPT.Text = Codigo
        End If
    End Sub

    Public Sub CargaDatos(Codigo As String, Accion As String) Implements IConsulta_MP.PasaCodigo
        If Accion = "Ambos" Then
            txt_DesdeMP.Text = Codigo
            txt_HastaMP.Text = Codigo
        End If

        If Accion = "Desde" Then
            txt_DesdeMP.Text = Codigo
        End If

        If Accion = "Hasta" Then
            txt_HastaMP.Text = Codigo
        End If
    End Sub

    Private Sub btn_AceptarMP_Click(sender As Object, e As EventArgs) Handles btn_AceptarMP.Click


        txt_DesdeCliMP.Text = UCase(txt_DesdeCliMP.Text)
        txt_HastaCliMP.Text = UCase(txt_HastaCliMP.Text)
        txt_DesdeMP.Text = UCase(txt_DesdeMP.Text)
        txt_HastaMP.Text = UCase(txt_HastaMP.Text)

        Dim listaSQLCnslt As New List(Of String)

        Dim SQLCnslt As String = "SELECT Clave, Precio FROM PreciosMP " _
                                 & "WHERE Articulo BETWEEN '" & txt_DesdeMP.Text & "' AND '" & txt_HastaMP.Text & "' " _
                                 & "AND Cliente BETWEEN '" & txt_DesdeCliMP.Text & "' AND '" & txt_HastaCliMP.Text & "' " _
                                 & "ORDER BY Clave"

        Dim TablaClave As DataTable = GetAll(SQLCnslt, Operador.Base)

        If TablaClave.Rows.Count > 0 Then
            For Each RowClave As DataRow In TablaClave.Rows

                Dim Precio As Double = RowClave.Item("Precio") + (RowClave.Item("Precio") * Val(txt_PorcentajeMP.Text) / 100)
                Dim WPrecio As String = formatonumerico(Precio)
                Dim WClave = RowClave.Item("Clave")
                Dim WDate As String = Date.Today.ToString("MM/dd/yyyy")


                SQLCnslt = "UPDATE  PreciosMP SET Precio = '" & WPrecio & "', Fecha = '" & WDate & "' " _
                             & "WHERE Clave = '" & WClave & "'"

                listaSQLCnslt.Add(SQLCnslt)


            Next

            ExecuteNonQueries(listaSQLCnslt.ToArray(), Operador.Base)
            LimpiarPantalla()

        End If

    End Sub

   
    Private Sub btn_ConsultaMP_Click(sender As Object, e As EventArgs) Handles btn_ConsultaMP.Click
        With Consulta_MP
            If .Visible = True Then
                .Visible = False
            End If
            .Show(Me)
        End With
    End Sub
End Class