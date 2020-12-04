Imports Util.Clases.Helper
Imports Util.Clases.Query

Public Class GestionDePerfiles : Implements ICrearPerfil

    Private Sub btn_Cerrar_Click(sender As Object, e As EventArgs) Handles btn_Cerrar.Click
        Close()
    End Sub

    Private Sub btn_Crear_Click(sender As Object, e As EventArgs) Handles btn_Crear.Click
        With CrearPerfil
            .Show(Me)
        End With
    End Sub

    Private Sub GestionDePerfiles_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DGV_Actualiza()
    End Sub

    Private Sub DGV_Actualiza()
        Try

            DGV_Perfiles.Rows.Clear()

            Dim SQLCnslt As String = "SELECT Perfil FROM Perfiles ORDER BY id"

            Dim TPerfiles As DataTable = GetAll(SQLCnslt, "SurfactanSA")

            If TPerfiles.Rows.Count > 0 Then
                For Each row As DataRow In TPerfiles.Rows
                    DGV_Perfiles.Rows.Add(row.Item("Perfil"))
                Next
            End If


        Catch ex As Exception

        End Try
    End Sub


    Public Sub Actualiza() Implements ICrearPerfil.Actualiza
        DGV_Actualiza()
    End Sub

    Private Sub DGV_Perfiles_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DGV_Perfiles.CellMouseDoubleClick
        With New EleccionSistema(DGV_Perfiles.CurrentRow.Cells("Perfil").Value)
            .Show(Me)
        End With
    End Sub
End Class