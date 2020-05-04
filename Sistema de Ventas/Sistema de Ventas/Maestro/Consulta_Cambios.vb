Imports ConsultasVarias
Imports ConsultasVarias.Clases.Query
Imports ConsultasVarias.Clases.Helper
Public Class Consulta_Cambios

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Close()
    End Sub

    Private Sub Consulta_Cambios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim SQLCnslt As String = "SELECT Fecha, OrdFecha, Dolar = Cambio, Euro = CambioII, Divisa = CambioDivisa, " _
                                 & "Reflex30 = CambioIII, Reflex60 = CambioIV, Reflex90 = CambioV, Reflex120 = CambioVI " _
                                 & "From Cambios ORDER BY OrdFecha DESC"
        Dim tabla As DataTable = GetAll(SQLCnslt, "SurfactanSa")
        If tabla.Rows.Count > 0 Then
            DGV_Cambios.DataSource = tabla
        End If
    End Sub





    Private Sub txtFiltro_KeyDown(sender As Object, e As KeyEventArgs) Handles txtFiltro.KeyDown
        Select Case e.KeyData
            Case Keys.Escape
                txtFiltro.Text = ""
        End Select
    End Sub

    
    Private Sub txtFiltro_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtFiltro.KeyPress
        Dim tabla As DataTable = DGV_Cambios.DataSource
        tabla.DefaultView.RowFilter = "Fecha LIKE '%" & txtFiltro.Text & "%'"
    End Sub

    Private Sub DGV_Cambios_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DGV_Cambios.CellMouseDoubleClick
        Dim WOwner As IConsultaCambios = TryCast(Owner, IConsultaCambios)
        If WOwner IsNot Nothing Then
            With DGV_Cambios.CurrentRow
                WOwner.PasarDatos(.Cells("Fecha").Value, .Cells("Dolar").Value, .Cells("Euro").Value, .Cells("Divisa").Value, .Cells("Reflex30").Value, .Cells("Reflex60").Value, .Cells("Reflex90").Value, .Cells("Reflex120").Value)
            End With
        End If
        Close()
    End Sub
End Class