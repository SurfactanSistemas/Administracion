Imports Util.Clases.Query
Public Class Form1 : Implements IActualzarDGV

    Dim WMODO As String = "SIMPLE"

    Private Sub btn_NuevoPresupuesto_Click(sender As Object, e As EventArgs) Handles btn_NuevoPresupuesto.Click
        With New Ingresar_Presupuesto(0)
            .Show(Me)
        End With
    End Sub


    Private Sub btn_Cerrar_Click(sender As Object, e As EventArgs) Handles btn_Cerrar.Click
        Close()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        actualizaGrilla(WMODO)
    End Sub

    Private Sub actualizaGrilla(ByVal Modo As String)
        Dim filtro As String = "WHERE Estado = 'Pendiente'"
        If Modo = "COMPLETO" Then
            filtro = ""
        End If
        Dim SQLCnslt As String = "SELECT NroPresu = NroPresupuesto, Cod_Proveedor = Proveedor, Proveedor = ProvDescp, Titulo = Titulo, Fecha, FormaPago = FormaPago, Monto, Moneda = IIF(Moneda = 0, 'Pesos ($)', 'Dolares (U$S)') FROM Solicitud_Presupuesto " & filtro & " ORDER BY NroPresupuesto"
        Dim TablaPresu As DataTable = GetAll(SQLCnslt, "SurfactanSa")

        dgv_Presupuestos.DataSource = TablaPresu

        Calcular_Pagado_y_Saldo()

    End Sub

    Private Sub Calcular_Pagado_y_Saldo()
        For Each RowDgv As DataGridViewRow In dgv_Presupuestos.Rows
            ' Pago(PESOS) = 1 , Pago(DOLARES) = 2
            Dim SQLCnslt As String = "SELECT Neto, Paridad, Pago, Fecha FROM IvaComp WHERE Proveedor = '" & RowDgv.Cells("Cod_Proveedor").Value & "' AND NroPresupuesto = '" & RowDgv.Cells("NroPresu").Value & "'"
            Dim Tablaivacomp As DataTable = GetAll(SQLCnslt, "SurfactanSa")
            If Tablaivacomp.Rows.Count > 0 Then
                Dim TotalPagado As Double = 0
                For Each row As DataRow In Tablaivacomp.Rows
                    Dim Neto As Double = row.Item("Neto")
                    Dim Pago As Integer = row.Item("Pago")
                    Dim Paridad As Double = row.Item("Paridad")
                    If Val(Paridad) = 0 Then
                        SQLCnslt = "Select Cambio from Cambios WHERE "
                    End If

                    If Pago = 1 Then
                        TotalPagado += Neto
                    Else
                        TotalPagado += (Neto / Paridad)
                    End If

                Next

                RowDgv.Cells("Pagado").Value = TotalPagado
                RowDgv.Cells("Saldo").Value = (RowDgv.Cells("Monto").Value - TotalPagado)

            Else
                RowDgv.Cells("Pagado").Value = 0
                RowDgv.Cells("Saldo").Value = RowDgv.Cells("Monto").Value
            End If
        Next
    End Sub

    Public Sub RefrescaDGV() Implements IActualzarDGV.RefrescaDGV
        actualizaGrilla(WMODO)
    End Sub

    Private Sub txt_filtro_KeyUp(sender As Object, e As KeyEventArgs) Handles txt_filtro.KeyUp
        Dim Tablafiltrar As DataTable = dgv_Presupuestos.DataSource
        Tablafiltrar.DefaultView.RowFilter = "Proveedor LIKE '%" & txt_filtro.Text & "%' OR Titulo LIKE '%" & txt_filtro.Text & "%'"
    End Sub

    Private Sub dgv_Presupuestos_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles dgv_Presupuestos.MouseDoubleClick
        With New Ingresar_Presupuesto(dgv_Presupuestos.CurrentRow.Cells("NroPresu").Value)
            .Show(Me)
        End With
    End Sub

    Private Sub CheckBox1_CheckStateChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckStateChanged
        If WMODO = "COMPLETO" Then
            WMODO = "SIMPLE"
        Else
            WMODO = "COMPLETO"
        End If
        actualizaGrilla(WMODO)
    End Sub
End Class
