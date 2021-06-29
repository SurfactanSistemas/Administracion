Imports Util
Imports Util.Clases.Query
Imports Util.Clases.Helper
Public Class Gestor_Insumos : Implements IActualizaGrilla

    Private Sub CargarGrilla()

        Dim FiltroOperador As String = ""

        Select Case UCase(Operador.Clave)
            Case "POLOK"
                FiltroOperador = " WHERE PLANTA <> 'SI'"
            Case "OLULA"
                FiltroOperador = " WHERE PLANTA = 'SI'"
        End Select


        Dim Filtro As String = " AND (EstadoPedido = 'Pendiente'"

        Dim filtrototal As String = Filtro

        If Chk_IncluyeAprobados.Checked Then
            filtrototal = filtrototal & " OR EstadoPedido = 'Aprobado'"
        End If

        If Chk_IncluyeRechazadas.Checked Then
            filtrototal = filtrototal & " OR EstadoPedido = 'Rechazado'"
        End If
        filtrototal = filtrototal & ")"

        Dim SQLCnslt As String = "SELECT distinct Solicitud, Fecha, Solicitante, Observaciones, Planta, EstadoPedido FROM Insumos_Provisorios " & FiltroOperador & filtrototal
        Dim TablaInsumosProvi As DataTable = GetAll(SQLCnslt, "SurfactanSa")
        If TablaInsumosProvi.Rows.Count > 0 Then
            'For Each row As DataRow In TablaInsumosProvi.Rows
            '    With row
            '        dgv_SolicitudesInsumos.Rows.Add(.Item("Solicitud"), .Item("Fecha"), .Item("Solicitante"), Trim(.Item("Observaciones")), Trim(.Item("Planta")), .Item("EstadoPedido"))
            '    End With
            '
            'Next
            dgv_SolicitudesInsumos.DataSource = TablaInsumosProvi

            PintarGrilla()
        End If
    End Sub

    Private Sub Gestor_Insumos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarGrilla()
    End Sub

    Private Sub PintarGrilla()
        For Each row As DataGridViewRow In dgv_SolicitudesInsumos.Rows
            With row
                If Trim(IIf(IsDBNull(.Cells("EstadoPedido").Value), "", .Cells("EstadoPedido").Value)) = "Aprobado" Then
                    row.DefaultCellStyle.BackColor = Color.Green
                    row.DefaultCellStyle.ForeColor = Color.White
                End If
                If Trim(IIf(IsDBNull(.Cells("EstadoPedido").Value), "", .Cells("EstadoPedido").Value)) = "Rechazado" Then
                    row.DefaultCellStyle.BackColor = Color.Red
                    row.DefaultCellStyle.ForeColor = Color.White
                End If
            End With
        Next
    End Sub

    Private Sub txt_Filtro_KeyUp(sender As Object, e As KeyEventArgs) Handles txt_Filtro.KeyUp
        Dim Tablafiltrar As DataTable = dgv_SolicitudesInsumos.DataSource
        'Tablafiltrar.DefaultView.RowFilter = "Solicitud LIKE '%" & txt_Filtro.Text & "%' OR Fecha LIKE '%" & txt_Filtro.Text & "%' OR Solicitante LIKE '%" & txt_Filtro.Text & "%' OR Observaciones LIKE '%" & txt_Filtro.Text & "%' OR Planta LIKE '%" & txt_Filtro.Text & "%'"
        Tablafiltrar.DefaultView.RowFilter = "Fecha LIKE '%" & txt_Filtro.Text & "%' OR Solicitante LIKE '%" & txt_Filtro.Text & "%' OR Observaciones LIKE '%" & txt_Filtro.Text & "%' OR Planta LIKE '%" & txt_Filtro.Text & "%'"
    End Sub

    Private Sub btn_Cerrar_Click(sender As Object, e As EventArgs) Handles btn_Cerrar.Click
        Close()
    End Sub

    Private Sub Chk_IncluyeRechazadas_CheckedChanged(sender As Object, e As EventArgs) Handles Chk_IncluyeRechazadas.CheckedChanged
        CargarGrilla()
    End Sub

    Private Sub Chk_IncluyeAprobados_CheckedChanged(sender As Object, e As EventArgs) Handles Chk_IncluyeAprobados.CheckedChanged
        CargarGrilla()
    End Sub

    Private Sub dgv_SolicitudesInsumos_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_SolicitudesInsumos.CellDoubleClick
        With New Vista_Insumos(dgv_SolicitudesInsumos.CurrentRow.Cells("Nro_Insumo").Value)
            .Show(Me)
        End With
    End Sub

    Public Sub ActualizarGrilla() Implements IActualizaGrilla.ActualizarGrilla
        CargarGrilla()
    End Sub

    Private Sub dgv_SolicitudesInsumos_Sorted(sender As Object, e As EventArgs) Handles dgv_SolicitudesInsumos.Sorted
        PintarGrilla()
    End Sub

    Private Sub dgv_SolicitudesInsumos_SortCompare(sender As Object, e As DataGridViewSortCompareEventArgs) Handles dgv_SolicitudesInsumos.SortCompare

        Dim num1, num2

        Select Case e.Column.Index
            'Case 1, 3, 4, 5
            '    'String
            '    num1 = e.CellValue1
            '    num2 = e.CellValue2
            '
            'Case 0
            '    'INTEGER
            '    num1 = CInt(e.CellValue1)
            '    num2 = CInt(e.CellValue2)
            '
            'Case 6
            '    'Double
            '    num1 = CDbl(e.CellValue1)
            '    num2 = CDbl(e.CellValue2)

            Case 1
                'Fechas
                num1 = ordenaFecha(e.CellValue1)
                num2 = ordenaFecha(e.CellValue2)


            Case Else
                Exit Sub
        End Select

        If num1 < num2 Then
            e.SortResult = -1
        ElseIf num1 = num2 Then
            e.SortResult = 0
        Else
            e.SortResult = 1
        End If

        e.Handled = True

    End Sub

End Class