Imports Util.Clases.Query
Public Class ActualizarDatosEnvases

    Private Sub txt_Codigo_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_Codigo.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
            If txt_Codigo.Text.Length = 10 Then
                    Try
                        Dim SQLCnslt As String = "SELECT Descripcion, TamanioBase, Tara, DescPackingList, DescPackingListIngles FROM Articulo WHERE Codigo = '" & txt_Codigo.Text & "'"
                        Dim RowArt As DataRow = GetSingle(SQLCnslt, "SurfactanSa")
                        If RowArt IsNot Nothing Then
                            txt_Descripcion.Text = RowArt.Item("Descripcion")
                            txt_DescPackingList.Text = RowArt.Item("DescPackingList")
                            txt_TamanioBase.Text = RowArt.Item("TamanioBase")
                            txt_Tara.Text = formatonumerico(RowArt.Item("Tara"))
                            txt_DescInglesPackingList.Text = RowArt.Item("DescPackingListIngles")
                            txt_DescPackingList.Focus()
                        End If
                    Catch ex As Exception

                    End Try
                End If

            Case Keys.Escape
                txt_Codigo.Text = ""
        End Select
    End Sub



    Private Sub NumerosConComas(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_Tara.KeyPress
        If Not Char.IsNumber(e.KeyChar) And Not Char.IsControl(e.KeyChar) And Not (CChar(".")) = e.KeyChar Then
            e.Handled = True
        End If
    End Sub

    Private Sub btn_Cerrar_Click(sender As Object, e As EventArgs) Handles btn_Cerrar.Click
        Close()
    End Sub

    Private Sub txt_DescPackingList_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_DescPackingList.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                txt_TamanioBase.Focus()
            Case Keys.Escape
                txt_DescPackingList.Text = ""
        End Select

    End Sub

    Private Sub txt_TamanioBase_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_TamanioBase.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                txt_Tara.Focus()
            Case Keys.Escape
                txt_TamanioBase.Text = ""
        End Select

    End Sub

    Private Sub txt_Tara_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_Tara.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                txt_DescInglesPackingList.Focus()
            Case Keys.Escape
                txt_Tara.Text = ""
        End Select

    End Sub

    Private Sub btn_Grabar_Click(sender As Object, e As EventArgs) Handles btn_Grabar.Click
        Dim Empresas(6) As String

        Empresas(0) = "SurfactanSA"
        Empresas(1) = "Surfactan_II"
        Empresas(2) = "Surfactan_III"
        Empresas(3) = "Surfactan_IV"
        Empresas(4) = "Surfactan_V"
        Empresas(5) = "Surfactan_VI"
        Empresas(6) = "Surfactan_VII"

        Dim ListSQLCnlst As New List(Of String)

        Dim SQLCnslt As String
        For i = 0 To 6
            SQLCnslt = "UPDATE " & Empresas(i) & ".dbo.Articulo SET TamanioBase = '" & txt_TamanioBase.Text & "' , Tara = '" & txt_Tara.Text & "', DescPackingList = '" & txt_DescPackingList.Text & "', DescPackingListIngles = '" & txt_DescInglesPackingList.Text & "' WHERE Codigo = '" & txt_Codigo.Text & "'"
            ListSQLCnlst.Add(SQLCnslt)
        Next

        ExecuteNonQueries(ListSQLCnlst.ToArray())
    End Sub

    Private Sub txt_DescInglesPackingList_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_DescInglesPackingList.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                btn_Grabar_Click(Nothing, Nothing)
            Case Keys.Escape
                txt_DescInglesPackingList.Text = ""
        End Select
    End Sub
End Class