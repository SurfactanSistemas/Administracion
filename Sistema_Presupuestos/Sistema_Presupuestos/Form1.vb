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
        Dim SQLCnslt As String = "SELECT NroPresu = NroPresupuesto, Proveedor = trim(ProvDescp), Titulo = Trim(Titulo), Fecha, FormaPago = Trim(FormaPago), Monto, Moneda = IIF(Moneda = 0, 'Pesos ($)', 'Dolares (U$S)') FROM SolicitudPresupuesto " & filtro & " ORDER BY NroPresupuesto"
        Dim TablaPresu As DataTable = GetAll(SQLCnslt, "SurfactanSa")

        dgv_Presupuestos.DataSource = TablaPresu

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
