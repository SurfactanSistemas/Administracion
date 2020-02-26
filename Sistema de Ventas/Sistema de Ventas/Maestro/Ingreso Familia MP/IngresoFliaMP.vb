Imports ConsultasVarias
Imports ConsultasVarias.Clases.Query

Public Class IngresoFliaMP : Implements  IAgregarFliaMP
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Close()
    End Sub

    Private Sub IngresoFliaMP_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim SQLCnslt As String = ""
        SQLCnslt = "SELECT Codigo = Linea, Descripcion = Nombre FROM LineasMp WHERE Linea <> 0 ORDER BY Linea"
        Dim tablaLineaMP As DataTable = GetAll(SQLCnslt)
        DGV_FliaMP.DataSource = tablaLineaMP

    End Sub

    Private Sub IngresoLineaFliaMP_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        txtBuscador.Focus()
    End Sub

    Private Sub txtBuscador_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBuscador.KeyDown
        Select Case e.KeyData
            Case Keys.Escape
                txtBuscador.Text = ""
        End Select
    End Sub


    Private Sub txtBuscador_KeyUp(sender As Object, e As KeyEventArgs) Handles txtBuscador.KeyUp
        Dim TablaLineasMP As DataTable = DGV_FliaMP.DataSource
        TablaLineasMP.DefaultView.RowFilter = "Convert(Codigo,System.String) LIKE '%" & txtBuscador.Text & "%' OR Descripcion LIKE '%" & txtBuscador.Text & "%'"
    End Sub


    Private Sub DGV_FliaMP_RowHeaderMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DGV_FliaMP.RowHeaderMouseDoubleClick
        If MsgBox("¿Desea eliminar la familia de " & Trim(DGV_FliaMP.CurrentRow.Cells("Descripcion").Value) & "?", vbYesNo) = vbYes Then
            Dim SQlCnslt As String = "DELETE FROM LineasMp WHERE Linea = '" & DGV_FliaMP.CurrentRow.Cells("Codigo").Value & "'"
            ExecuteNonQueries({SQlCnslt})
            SQlCnslt = "SELECT Codigo = Linea, Descripcion = Nombre FROM LineasMp WHERE Linea <> 0 ORDER BY Linea"
            Dim tablaLineasMP As DataTable = GetAll(SQlCnslt)
            DGV_FliaMP.DataSource = tablaLineasMP
        End If
    End Sub

    Private Sub btnAgregarLineasMP_Click(sender As Object, e As EventArgs) Handles btnAgregarFliaMP.Click
        With New AgregarFliaMP(0)
            .Show(Me)
        End With
    End Sub

    Private Sub DGV_FliaMP_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DGV_FliaMP.CellMouseDoubleClick
        If e.ColumnIndex < 0 Then
            Exit Sub
        End If
        With New AgregarFliaMP(DGV_FliaMP.CurrentRow.Cells("Codigo").Value, DGV_FliaMP.CurrentRow.Cells("Descripcion").Value)
            .Show(Me)
        End With
    End Sub

    Private Sub txtAccesoRap_KeyDown(sender As Object, e As KeyEventArgs) Handles txtAccesoRap.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                If txtAccesoRap.Text <> "" Then
                    For Each Row As DataGridViewRow In DGV_FliaMP.Rows
                        If Row.Cells("Codigo").Value = txtAccesoRap.Text Then
                            With New AgregarFliaMP(Row.Cells("Codigo").Value, Trim(Row.Cells("Descripcion").Value))
                                .Show(Me)
                            End With
                        End If
                    Next
                End If
            Case Keys.Escape
                txtAccesoRap.Text = ""
        End Select
    End Sub



    Private Sub SoloNumero(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAccesoRap.KeyPress
        If Not Char.IsNumber(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub


'    Public Sub _ProcesarDatosRubro() Implements IAgregarRubro._ProcesarDatosRubro
'        Dim SQLCnslt As String = ""
'        SQLCnslt = "SELECT Codigo = Rubro, Descripcion = Nombre FROM Rubros WHERE Rubro <> 0 ORDER BY Rubro"
'        Dim tablaRubro As DataTable = GetAll(SQLCnslt)
'        DGV_FliaMP.DataSource = tablaRubro
'
'    End Sub

    Private Sub btnPantalla_Click(sender As Object, e As EventArgs) Handles btnPantalla.Click
        With New VistaPrevia
            .Reporte = New ReporteFliaMP()
            .Mostrar()
        End With
    End Sub

    Public Sub _ProcesarDatosFliaMP() Implements IAgregarFliaMP._ProcesarDatosFliaMP
        Dim SQlCnslt As String = "SELECT Codigo = Linea, Descripcion = Nombre FROM LineasMp WHERE Linea <> 0 ORDER BY Linea"
        Dim tablaLineasMP As DataTable = GetAll(SQlCnslt)
        DGV_FliaMP.DataSource = tablaLineasMP
    End Sub
End Class