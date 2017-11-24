Imports ClasesCompartidas
Imports System.IO
Imports System.Data.SqlClient

Public Class ListadoRecibos

    Private Sub ListadoRecibos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Label2.Text = Globals.NombreEmpresa()
        txtDesdeFecha.Text = "  /  /    "
        txthastafecha.Text = "  /  /    "

    End Sub

    Private Sub txtdesdefecha_KeyPress(ByVal sender As Object, _
                ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDesdeFecha.KeyPress

        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            If ValidaFecha(txtDesdeFecha.Text) = "S" Then
                txthastafecha.Focus()
            End If
        ElseIf e.KeyChar = Convert.ToChar(Keys.Escape) Then
            e.Handled = True
            txtDesdeFecha.Text = "  /  /    "
            Me.txtDesdeFecha.SelectionStart = 0
        End If
    End Sub

    Private Sub txthastafecha_KeyPress(ByVal sender As Object, _
                ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txthastafecha.KeyPress

        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            If ValidaFecha(txthastafecha.Text) = "S" Then
                txtDesdeFecha.Focus()
            End If
        ElseIf e.KeyChar = Convert.ToChar(Keys.Escape) Then
            e.Handled = True
            txthastafecha.Text = "  /  /    "
            Me.txthastafecha.SelectionStart = 0
        End If
    End Sub

    Private Sub btnCancela_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancela.Click
        Me.Close()
        MenuPrincipal.Show()
    End Sub

    Enum Reporte
        Imprimir
        Pantalla
    End Enum

    Private Sub _Imprimir(ByVal TipoImpresion As Reporte)

        ' Reseteamos los datos de los recibos.
        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("ModificaReciboImpolista0")

        SQLConnector.conexionSql(cn, cm)

        Try
            cm.CommandType = CommandType.StoredProcedure

            cm.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox("Hubo un problema al querer consultar la Base de Datos.", MsgBoxStyle.Critical)
            Exit Sub
        Finally

            cn.Close()

        End Try

        ' Actualizamos los datos antes de generar el informe.
        Try
            cn.Open()

            cm.CommandText = "ModificaReciboImpolista"

            cm.CommandType = CommandType.StoredProcedure

            With cm.Parameters
                .AddWithValue("@Desde", Proceso.ordenaFecha(txtDesdeFecha.Text))
                .AddWithValue("@Hasta", Proceso.ordenaFecha(txthastafecha.Text))
            End With

            cm.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox("Hubo un problema al querer consultar la Base de Datos.", MsgBoxStyle.Critical)
            Exit Sub
        Finally

            cn.Close()
            cn = Nothing
            cm = Nothing
        End Try

        With VistaPrevia
            .Formula = "{Recibos.Fechaord}>='" & Proceso.ordenaFecha(txtDesdeFecha.Text) & "' AND {Recibos.Fechaord}<='" & Proceso.ordenaFecha(txthastafecha.Text) & "' and {Recibos.Cliente} = {Cliente.Cliente}"

            .Reporte = New WListadoRecibos

            Select Case TipoImpresion

                Case Reporte.Imprimir
                    .Imprimir()
                Case Reporte.Pantalla
                    .Mostrar()
            End Select

        End With

    End Sub

    Private Sub btnPantalla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPantalla.Click
        _Imprimir(Reporte.Pantalla)
    End Sub

    Private Sub ListadoRecibos_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        txtDesdeFecha.Focus()
    End Sub

    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
        _Imprimir(Reporte.Imprimir)
    End Sub
End Class