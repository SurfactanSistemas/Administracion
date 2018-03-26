Imports System.Data.SqlClient

Public Class EjemploImpresion

    Private Sub Login_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtDesde.Clear()
        txtHasta.Clear()
    End Sub

    Private Sub Login_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        txtDesde.Focus()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Close()
    End Sub

    Private Sub txtDesde_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDesde.KeyDown

        If e.KeyData = Keys.Enter Then
            If txtDesde.Text.estaVacia Then : Exit Sub : End If

            If Helper._ValidarFecha(txtDesde.Text) Then
                txtHasta.Focus()
            End If

        ElseIf e.KeyData = Keys.Escape Then
            txtDesde.Clear()
        End If

    End Sub

    Private Sub txtHasta_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtHasta.KeyDown
        If e.KeyData = Keys.Enter Then
            If txtHasta.Text.estaVacia Then : Exit Sub : End If

            If Helper._ValidarFecha(txtHasta.Text) Then

                If txtDesde.Text.esMenorA(txtHasta.Text) Then
                    txtDesde.Focus()
                Else
                    MsgBox("La fecha final debe ser posterior a la fecha inicial")
                End If

            End If

        ElseIf e.KeyData = Keys.Escape Then
            txtHasta.Clear()
        End If
    End Sub

    Private Sub btnPantalla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPantalla.Click

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT Orden, Fecha, Observaciones FROM OrdenTrabajo")
        Dim dr As SqlDataReader
        Dim trans As SqlTransaction = Nothing
        Dim WVectorI As New List(Of Object)
        Dim WVectorII As New List(Of Object)
        Dim WDesdeFecha = Helper.ordenaFecha(txtDesde.Text), WHastaFecha = Helper.ordenaFecha(txtHasta.Text)
        Dim WFecha = "", WAux = "", WOrden = "", WObs = "", WHoja = "", WProducto = "", WCantidad = 0.0, WImpo1 = "", WImpo2 = "", WImpo3 = "", ZSql = ""
        Dim WVenta = 0.0, WA = 0

        Try

            cn.ConnectionString = Helper._ConectarA
            cn.Open()
            cm.Connection = cn

            dr = cm.ExecuteReader()

            ' Extraemos los datos de las Ordenes de Trabajo que se encuentren dentro del rango de Fechas.
            If dr.HasRows Then

            End If

            ' Imprimimos por pantalla.

            With VistaPrevia
                .DesdeArchivo(Configuration.ConfigurationManager.AppSettings("reportsLocation").ToString & "WAnalisisDesarrollo.rpt")

                .Mostrar()
            End With


        Catch ex As Exception
            Throw New Exception("Hubo un problema al querer consultar la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

    End Sub
End Class