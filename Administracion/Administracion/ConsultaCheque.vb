Imports ClasesCompartidas
Imports System.Data.SqlClient

Public Class ConsultaCheque

    Private Sub btnProceso_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProceso.Click
        ejecutar()
    End Sub

    Private Sub ejecutar()

        If Trim(txtCheque.Text) = "" Then
            Exit Sub
        End If


        If IsNumeric(txtCheque.Text) Then
            gridCheque.Rows.Clear()
            If cmbTipo.SelectedIndex = 0 Then
                _ListarChequesTerceros(txtCheque.Text)
            Else
                For Each row In SQLConnector.retrieveDataTable("get_cheques_propios", txtCheque.Text).Rows
                    gridCheque.Rows.Add(row("Numero2").ToString,
                                        row("Banco2").ToString,
                                        formatonumerico(redondeo(Convert.ToDouble(row("Importe2"))), "#######0.#0", "."),
                                        row("Fecha").ToString,
                                        row("Fecha2").ToString,
                                        row("Recibo").ToString,
                                        row("Cuit").ToString,
                                        row("Proveedor").ToString)
                Next
            End If

        End If
    End Sub

    Private Sub _ListarChequesTerceros(ByVal cheque As String)
        cheque = Trim(cheque)
        Dim cn As New SqlConnection()
        Dim cm As New SqlCommand()
        Dim dr As SqlDataReader

        ' Listamos los pertenecientes a Recibos.
        SQLConnector.conexionSql(cn, cm)

        Try
            cm.CommandText = "SELECT r.Numero2, r.Banco2, r.Importe2, r.Fecha, r.Fecha2, r.Recibo, r.Cliente, cli.Razon, r.Cuit, TipoCheque = IIF((Tipo2 ='02' or Tipo2 = '02' or Tipo2 = ' 2'  ),'Fisico','e-check') FROM Recibos as r LEFT OUTER JOIN Cliente as cli ON cli.Cliente = r.Cliente WHERE Tiporeg= '2' and ((Tipo2 = '2' or Tipo2 = '02' or Tipo2 = ' 2') or (Tipo2 = '7' or Tipo2 = '07' or Tipo2 = ' 7')) and ISNULL(Numero2,'') LIKE ('%" & cheque & "') order by FechaOrd2"
            'cm.CommandText = "SELECT r.Numero2, r.Banco2, r.Importe2, r.Fecha, r.Fecha2, r.Recibo, r.Cliente, cli.Razon, r.Cuit FROM Recibos as r LEFT OUTER JOIN Cliente as cli ON cli.Cliente = r.Cliente WHERE Tiporeg= '2' and (Tipo2 = '2' or Tipo2 = '02' or Tipo2 = ' 2') and ISNULL(Numero2,'') LIKE ('%" & cheque & "') order by FechaOrd2"
            dr = cm.ExecuteReader()

            If dr.HasRows Then

                Do While dr.Read()
                    gridCheque.Rows.Add(dr.Item("Numero2"),
                                        Trim(dr.Item("Banco2")),
                                            formatonumerico(redondeo(Convert.ToDouble(dr.Item("Importe2"))), "#######0.#0", "."),
                                            dr.Item("Fecha"),
                                            dr.Item("Fecha2"),
                                            "Rec: " & dr.Item("Recibo"),
                                            dr.Item("Cuit"),
                                            dr.Item("Cliente") & " " & dr.Item("Razon"),
                                            dr.Item("TipoCheque"))
                Loop

            End If

        Catch ex As Exception
            MsgBox("Hubo un problema al querer consultar la Base de Datos.", MsgBoxStyle.Critical)
        Finally

            'dr = Nothing
            cn.Close()
            'cn = Nothing
            'cm = Nothing

        End Try


        ' Listamos los pertenecientes a Depositos
        SQLConnector.conexionSql(cn, cm)

        Try
            cm.CommandText = "SELECT d.Numero2, d.Observaciones2, d.Importe2, d.Fecha, d.Fecha2, d.Deposito, d.Banco, b.Cuenta, b.Nombre, TipoCheque = IIF((ChequeVirtual = 0),'Fisico','e-check') FROM Depositos as d, Banco as b Where d.Banco = b.Banco and (Tipo2 = ' 3' Or Tipo2 = '3' Or Tipo2= '03') and ISNULL(Numero2,'') LIKE ('%" & cheque & "') Order by FechaOrd"
            dr = cm.ExecuteReader()

            If dr.HasRows Then

                Do While dr.Read()
                    gridCheque.Rows.Add(dr.Item("Numero2"),
                                        dr.Item("Observaciones2"),
                                            formatonumerico(redondeo(Convert.ToDouble(dr.Item("Importe2"))), "#######0.#0", "."),
                                            dr.Item("Fecha"),
                                            dr.Item("Fecha2"),
                                            "Dep: " & dr.Item("Deposito"),
                                            "",
                                            dr.Item("Banco") & " " & dr.Item("Nombre"),
                                              dr.Item("TipoCheque"))
                Loop

            End If

        Catch ex As Exception
            MsgBox("Hubo un problema al querer consultar la Base de Datos.", MsgBoxStyle.Critical)
        Finally

            'dr = Nothing
            cn.Close()
            'cn = Nothing
            'cm = Nothing

        End Try

        ' Listamos los pertenecientes a Pagos
        SQLConnector.conexionSql(cn, cm)

        Try
            'cm.CommandText = "SELECT d.Numero2, d.Observaciones2, d.Importe2, d.Fecha, d.Fecha2, d.Orden, d.Proveedor, b.Nombre, d.Observaciones FROM Pagos as d, Proveedor as b Where d.Proveedor = b.Proveedor and Tiporeg = '2' and (Tipo2 = '3' Or Tipo2= '03') and ISNULL(Numero2,'') LIKE ('%" & cheque & "') Order by FechaOrd2"cm.CommandText = "SELECT d.Numero2, d.Observaciones2, d.Importe2, d.Fecha, d.Fecha2, d.Orden, isnull(b.Proveedor, '') as Proveedor, isnull(b.Nombre, '') as Nombre, d.Observaciones, d.Cuit FROM Pagos as d FULL OUTER JOIN Proveedor as b ON b.Proveedor = d.Proveedor  Where d.Tiporeg = '2' and (d.Tipo2 = '3' Or d.Tipo2= '03' Or d.Tipo2= ' 3') and d.Numero2 LIKE '%" & cheque & "' Order by FechaOrd2"
            cm.CommandText = "SELECT d.Numero2, d.Observaciones2, d.Importe2, d.Fecha, d.Fecha2, d.Orden, isnull(b.Proveedor, '') as Proveedor, isnull(b.Nombre, '') as Nombre, d.Observaciones, d.Cuit, TipoCheque = IIF((Tipo2 ='3' or Tipo2 = '03' or Tipo2 = ' 3'  ),'Fisico','e-check') FROM Pagos as d FULL OUTER JOIN Proveedor as b ON b.Proveedor = d.Proveedor  Where d.Tiporeg = '2' and ((d.Tipo2 = '3' Or d.Tipo2= '03' Or d.Tipo2= ' 3') OR (d.Tipo2 = '7' Or d.Tipo2= '07' Or d.Tipo2= ' 7')) and d.Numero2 LIKE '%" & cheque & "' Order by FechaOrd2"
            ' cm.CommandText = "SELECT d.Numero2, d.Observaciones2, d.Importe2, d.Fecha, d.Fecha2, d.Orden, isnull(b.Proveedor, '') as Proveedor, isnull(b.Nombre, '') as Nombre, d.Observaciones, d.Cuit FROM Pagos as d FULL OUTER JOIN Proveedor as b ON b.Proveedor = d.Proveedor  Where d.Tiporeg = '2' and (d.Tipo2 = '3' Or d.Tipo2= '03' Or d.Tipo2= ' 3') and d.Numero2 LIKE '%" & cheque & "' Order by FechaOrd2"
            dr = cm.ExecuteReader()

            If dr.HasRows Then

                Do While dr.Read()
                    gridCheque.Rows.Add(dr.Item("Numero2"),
                                        dr.Item("Observaciones2"),
                                            formatonumerico(redondeo(Convert.ToDouble(dr.Item("Importe2"))), "#######0.#0", "."),
                                            dr.Item("Fecha"),
                                            dr.Item("Fecha2"),
                                            "O.P.: " & dr.Item("Orden"),
                                            dr.Item("Cuit"),
                                            dr.Item("Proveedor") & " " & IIf(IsDBNull(dr.Item("Nombre")), dr.Item("Observaciones"), dr.Item("Nombre")),
                                              dr.Item("TipoCheque"))
                Loop

            End If

        Catch ex As Exception
            MsgBox("Hubo un problema al querer consultar la Base de Datos.", MsgBoxStyle.Critical)
        Finally

            'dr = Nothing
            cn.Close()
            'cn = Nothing
            'cm = Nothing

        End Try

        ' Listamos los pertenecientes a RecibosProvi
        SQLConnector.conexionSql(cn, cm)

        Try

            cm.CommandText = "SELECT r.Numero2, r.Banco2, r.Importe2, r.Fecha, r.Fecha2, r.Recibo, r.Cliente, cli.Razon, r.Cuit, TipoCheque = IIF((Tipo2 ='2' or Tipo2 = '02' or Tipo2 = ' 2'  ),'Fisico','e-check') FROM RecibosProvi as r LEFT OUTER JOIN Cliente as cli ON cli.Cliente = r.Cliente WHERE Tiporeg= '2' and ((Tipo2 = '2' or Tipo2 = '02' or Tipo2 = ' 2') or (Tipo2 = '7' or Tipo2 = '07' or Tipo2 = ' 7')) and ISNULL(Numero2,'') LIKE ('%" & cheque & "') AND ReciboDefinitivo = 0 order by FechaOrd2"

            dr = cm.ExecuteReader()

            If dr.HasRows Then

                Do While dr.Read()
                    gridCheque.Rows.Add(dr.Item("Numero2"),
                                          dr.Item("Banco2"),
                                              formatonumerico(redondeo(Convert.ToDouble(dr.Item("Importe2"))), "#######0.#0", "."),
                                              dr.Item("Fecha"),
                                              dr.Item("Fecha2"),
                                              "RecProv: " & dr.Item("Recibo"),
                                              dr.Item("Cuit"),
                                              dr.Item("Cliente") & " " & dr.Item("Razon"),
                                              dr.Item("TipoCheque"))
                Loop

            End If

        Catch ex As Exception
            MsgBox("Hubo un problema al querer consultar la Base de Datos.", MsgBoxStyle.Critical)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
        MenuPrincipal.Show()
    End Sub

    Private Sub ConsultaCheque_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Label2.Text = Globals.NombreEmpresa()
        cmbTipo.SelectedIndex = 0
    End Sub

    Private Sub txtCheque_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCheque.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            ejecutar()
        End If
    End Sub

    Private Sub ConsultaCheque_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        txtCheque.Focus()
    End Sub

    Private Sub CustomButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CustomButton1.Click
        txtCheque.Text = ""
        gridCheque.Rows.Clear()
        cmbTipo.SelectedIndex = 0

        txtCheque.Focus()
    End Sub

    Private Sub cmbTipo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTipo.SelectedIndexChanged
        ejecutar()
    End Sub

    Private Sub txtCheque_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCheque.KeyDown

        If e.KeyData = Keys.Escape Then
            txtCheque.Text = ""
        End If

    End Sub

    Private Sub SoloNumero(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCheque.KeyPress
        If Not Char.IsNumber(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub gridCheque_SortCompare(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewSortCompareEventArgs) Handles gridCheque.SortCompare
        gridCheque.ClearSelection()

        Dim num1, num2

        Select Case e.Column.Index
            Case 0, 1, 5, 6

                num1 = e.CellValue1
                num2 = e.CellValue2

            Case 2

                num1 = CDbl(e.CellValue1)
                num2 = CDbl(e.CellValue2)

            Case 3, 4

                num1 = Proceso.ordenaFecha(e.CellValue1)
                num2 = Proceso.ordenaFecha(e.CellValue2)

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