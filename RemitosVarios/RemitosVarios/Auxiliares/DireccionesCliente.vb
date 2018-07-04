Imports System.Data.SqlClient

Public Class DireccionesCliente

    Dim WDatos As DataRow

    Sub New(ByVal WCliente As String)

        InitializeComponent()
        WDatos = _TraerDatosCliente(WCliente)

    End Sub

    Private Sub DireccionesCliente_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsNothing(WDatos) Then
            _PoblarGrilla()
        End If
        Dim WOwner As IngresoRemitoVario = Owner
        Location = New Point((WOwner.Width + Width) / 2, WOwner.Location.Y + 10)
    End Sub

    Private Sub _PoblarGrilla()
        For Each d As String In {"", "II", "III", "IV", "V"}
            dgvDirecciones.Rows.Add(WDatos.Item("DirEntrega" & d))
        Next

        Label2.Text = String.Format("({0})  {1}", WDatos.Item("Cliente"), WDatos.Item("Razon"))
    End Sub

    Private Function _TraerDatosCliente(ByVal WCliente As String) As DataRow

        Dim tabla As New DataTable

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT Cliente, ISNULL(Razon, '') Razon, ISNULL(DirEntrega, '') DirEntrega, ISNULL(DirEntregaII, '') DirEntregaII, ISNULL(DirEntregaIII, '') DirEntregaIII, ISNULL(DirEntregaIV, '') DirEntregaIV, ISNULL(DirEntregaV, '') DirEntregaV FROM Cliente WHERE Cliente = '" & WCliente & "'")
        Dim dr As SqlDataReader

        Try

            cn.ConnectionString = Helper._ConectarA
            cn.Open()
            cm.Connection = cn

            dr = cm.ExecuteReader()

            If dr.HasRows Then

                tabla.Load(dr)

            End If

        Catch ex As Exception
            Throw New Exception("Hubo un problema al querer consultar los datos del Cliente desde la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

        If tabla.Rows.Count > 0 Then
            Return tabla.Rows(0)
        Else
            Return Nothing
        End If

    End Function

    Private Sub dgvDirecciones_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDirecciones.CellClick
        If IsNothing(dgvDirecciones.CurrentCell) Then Exit Sub

        Dim WDireccion = If(dgvDirecciones.CurrentCell.Value, "")

        Dim WOwner As IngresoRemitoVario = Owner

        WOwner.AsignarDireccion(WDireccion)

        Close()
    End Sub
End Class
