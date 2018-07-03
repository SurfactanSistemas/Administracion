Imports ClasesCompartidas
Imports System.IO
Imports System.Data.SqlClient

Public Class ListadoMovimientosBancos

    Dim txtVectorBanco(1000) As String

    Private Sub ListadoMovimientosBancos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Label2.Text = Proceso.NombreEmpresa()
        Button1.PerformClick()
    End Sub


    Private Sub txtdesdefecha_KeyPress(ByVal sender As Object, _
                   ByVal e As System.Windows.Forms.KeyPressEventArgs) _
                   Handles txtDesdeFecha.KeyPress
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
                   ByVal e As System.Windows.Forms.KeyPressEventArgs) _
                   Handles txthastafecha.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            If ValidaFecha(txthastafecha.Text) = "S" Then
                txtDesdeBanco.Focus()
            End If
        ElseIf e.KeyChar = Convert.ToChar(Keys.Escape) Then
            e.Handled = True
            txthastafecha.Text = "  /  /    "
            Me.txthastafecha.SelectionStart = 0
        End If
    End Sub

    Private Sub txtdesdebanco_KeyPress(ByVal sender As Object, _
                   ByVal e As System.Windows.Forms.KeyPressEventArgs) _
                   Handles txtDesdeBanco.KeyPress

        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            txtHastaBanco.Text = txtDesdeBanco.Text
            txtHastaBanco.Focus()
        ElseIf e.KeyChar = Convert.ToChar(Keys.Escape) Then
            e.Handled = True
            txtDesdeBanco.Text = ""
        End If
        If Not IsNumeric(e.KeyChar) Then
            e.Handled = True
        End If

    End Sub

    Private Sub txthastabanco_KeyPress(ByVal sender As Object, _
                   ByVal e As System.Windows.Forms.KeyPressEventArgs) _
                   Handles txtHastaBanco.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            txtDesdeFecha.Focus()
        ElseIf e.KeyChar = Convert.ToChar(Keys.Escape) Then
            e.Handled = True
            txtHastaBanco.Text = ""
        End If
        If Not IsNumeric(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub btnCancela_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancela.Click
        Me.Close()
        MenuPrincipal.Show()
    End Sub


    Private Sub btnConsulta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsulta.Click

        Me.Size = New System.Drawing.Size(477, 461)

        lstAyuda.DataSource = DAOBanco.buscarBancoPorNombre("")

        txtAyuda.Text = ""
        txtAyuda.Visible = True
        lstAyuda.Visible = True

        txtAyuda.Focus()

    End Sub

    Private Sub txtAyuda_KeyPress(ByVal sender As Object, _
                   ByVal e As System.Windows.Forms.KeyPressEventArgs)

        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            lstAyuda.DataSource = DAOBanco.buscarBancoPorNombre(txtAyuda.Text)
        ElseIf e.KeyChar = Convert.ToChar(Keys.Escape) Then
            e.Handled = True
            txtAyuda.Text = ""
            lstAyuda.DataSource = DAOBanco.buscarBancoPorNombre(txtAyuda.Text)
        End If
    End Sub

    Private Sub mostrarbanco(ByVal banco As Banco)
        txtDesdeBanco.Text = banco.id
        txtHastaBanco.Text = banco.id
        txtDesdeBanco.Focus()
    End Sub

    Private Sub lstAyuda_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstAyuda.Click
        mostrarbanco(lstAyuda.SelectedValue)
        REM txtDesdeProveedor.Text = lstAyuda.SelectedValue.id
    End Sub

    Private Function _ObtenerSaldoInicialDebito(ByVal banco As String, ByVal txtDesdeFecha As String) As Double
        Dim saldoinicial As Double = 0
        txtDesdeFecha = Proceso.ordenaFecha(txtDesdeFecha)

        Dim cn = New SqlConnection()
        Dim cm = New SqlCommand("SELECT SUM(Importe2) as SaldoInicial FROM Pagos WHERE Banco2 = '" & Trim(banco) & "' AND FechaOrd2 < '" & txtDesdeFecha & "'")
        Dim dr As SqlDataReader

        SQLConnector.conexionSql(cn, cm)

        Try

            dr = cm.ExecuteReader()

            If dr.HasRows Then
                dr.Read()

                saldoinicial = IIf(IsDBNull(dr.Item("SaldoInicial")), 0, dr.Item("SaldoInicial"))

            End If

        Catch ex As Exception
            MsgBox("Hubo un problema al querer consultar la Base de Datos.", MsgBoxStyle.Critical)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

        Return saldoinicial
    End Function

    Private Function _ObtenerSaldoInicialCredito(ByVal banco As String, ByVal txtDesdeFecha As String) As Double
        Dim saldoinicial As Double = 0

        Return saldoinicial
    End Function

    Enum Reporte
        Imprimir
        Pantalla
    End Enum

    Private Sub _Imprimir(ByVal TipoImpresion As Reporte)
        Dim cn As New SqlConnection()
        Dim cm As New SqlCommand()
        Dim dr As SqlDataReader

        Dim varUno As String

        Dim varEmpresa As String
        Dim varFormula As String
        Dim x As Char = Chr(34)
        Dim varDesdefechaOrd, varHastafechaOrd As String

        Dim varBancoCodigo As Integer
        Dim varBancoCuenta As String

        Dim varRenglon As Integer
        Dim varTitulo As String
        Dim varTituloList As String
        Dim varVarios As String

        Dim varDebito, varCredito As Double
        Dim varAcredita, varAcreditaOrd As String
        Dim varBanco As Integer

        Dim vardada As String

        SQLConnector.retrieveDataTable("limpiar_movban")

        varEmpresa = "Surfactan S.A."

        If Proceso._EsPellital() Then
            varEmpresa = "Pellital S.A."
        End If

        varDesdefechaOrd = ordenaFecha(txtDesdeFecha.Text)
        varHastafechaOrd = ordenaFecha(txthastafecha.Text)

        Dim tablaII As DataTable
        tablaII = SQLConnector.retrieveDataTable("buscar_banco_por_nombre", "")

        For Each row As DataRow In tablaII.Rows

            Dim CamposBanco As New LeeBanco(row.Item(0), row.Item(1), row.Item(2))

            varBancoCuenta = CamposBanco.Cuenta
            varBancoCodigo = CamposBanco.banco

            txtVectorBanco(varBancoCodigo) = varBancoCuenta

        Next


        Dim tabla As DataTable
        varRenglon = 0

        tabla = SQLConnector.retrieveDataTable("buscar_pagos_Movban", varDesdefechaOrd, varHastafechaOrd, txtDesdeBanco.Text, txtHastaBanco.Text)

        For Each row As DataRow In tabla.Rows

            Dim CampoPagos As New LeePagosMovBan(row.Item(0).ToString, row.Item(1).ToString, row.Item(2).ToString,
                                            row.Item(3), row.Item(4).ToString, row.Item(5).ToString,
                                            row.Item(6).ToString, row.Item(7).ToString, row.Item(8).ToString,
                                            row.Item(9), row.Item(10), row.Item(11), row.Item(12),
                                            row.Item(13), row.Item(14), row.Item(15))


            vardada = CampoPagos.renglon
            REM If CampoPagos.orden = 116720 Then Stop

            varRenglon = varRenglon + 1

            varTitulo = "Pagos"
            varEmpresa = 1
            varTituloList = "Surfactan S.A."

            If Proceso._EsPellital() Then
                varEmpresa = 8
                varTituloList = "Pellital S.A."
            End If

            varVarios = "Desde el " + txtDesdeFecha.Text + " hasta el " + txthastafecha.Text

            varAcredita = CampoPagos.fecha2
            varAcreditaOrd = CampoPagos.fechaord2
            varDebito = 0
            varCredito = CampoPagos.importe2

            SQLConnector.executeProcedure("alta_movban", varRenglon, CampoPagos.banco2, CampoPagos.fecha, CampoPagos.fechaord, varAcredita, varAcreditaOrd, CampoPagos.observaciones,
                                          CampoPagos.numero2, varDebito, varCredito, CampoPagos.orden, varEmpresa, varTituloList, varVarios, CampoPagos.proveedor)


        Next









        tabla = SQLConnector.retrieveDataTable("buscar_pagos_MovbanII", varDesdefechaOrd, varHastafechaOrd, txtDesdeBanco.Text, txtHastaBanco.Text)

        For Each row As DataRow In tabla.Rows

            Dim CampoPagos As New LeePagosMovBan(row.Item(0).ToString, row.Item(1).ToString, row.Item(2).ToString,
                                            row.Item(3), row.Item(4).ToString, row.Item(5).ToString,
                                            row.Item(6).ToString, row.Item(7).ToString, row.Item(8).ToString,
                                            row.Item(9), row.Item(10), row.Item(11), row.Item(12),
                                            row.Item(13), row.Item(14), row.Item(15))

            REM If Val(CampoPagos.orden) = 114551 Then Stop
            vardada = CampoPagos.renglon
            REM If CampoPagos.orden = 116720 Then Stop



            If CampoPagos.tiporeg = "1" Then

                varRenglon = varRenglon + 1

                varTitulo = "Pagos"
                varEmpresa = 1
                varTituloList = "Surfactan S.A."
                varVarios = "Desde el " + txtDesdeFecha.Text + " hasta el " + txthastafecha.Text

                If Proceso._EsPellital() Then
                    varEmpresa = 8
                    varTituloList = "Pellital S.A."
                End If

                varAcredita = CampoPagos.fecha
                varAcreditaOrd = CampoPagos.fechaord
                varDebito = CampoPagos.importe1
                varCredito = 0

                SQLConnector.executeProcedure("alta_movban", varRenglon, CampoPagos.banco2, CampoPagos.fecha, CampoPagos.fechaord, varAcredita, varAcreditaOrd, CampoPagos.observaciones,
                                              CampoPagos.numero2, varDebito, varCredito, CampoPagos.orden, varEmpresa, varTituloList, varVarios, CampoPagos.proveedor)

            End If

        Next








        tabla = SQLConnector.retrieveDataTable("buscar_depositos_Movban", varDesdefechaOrd, varHastafechaOrd, txtDesdeBanco.Text, txtHastaBanco.Text)

        For Each row As DataRow In tabla.Rows

            Dim CampoDepositos As New LeeDepositosMovban(row.Item(0), row.Item(1), row.Item(2),
                                   row.Item(3), row.Item(4), row.Item(5),
                                   row.Item(6), row.Item(7), row.Item(8), row.Item(9))

            varRenglon = varRenglon + 1

            varTitulo = "Depositos"
            varEmpresa = 1
            varTituloList = "Surfactan S.A."
            varVarios = "Desde el " + txtDesdeFecha.Text + " hasta el " + txthastafecha.Text

            If Proceso._EsPellital() Then
                varEmpresa = 8
                varTituloList = "Pellital S.A."
            End If

            varAcredita = CampoDepositos.acredita
            varAcreditaOrd = CampoDepositos.acreditaord
            varDebito = CampoDepositos.importe
            varCredito = 0

            SQLConnector.executeProcedure("alta_movban", varRenglon, CampoDepositos.Banco, CampoDepositos.Fecha, CampoDepositos.fechaord, varAcredita, varAcreditaOrd, "Deposito",
                                          CampoDepositos.deposito, varDebito, varCredito, CampoDepositos.deposito, varEmpresa, varTituloList, varVarios, "")


        Next










        tabla = SQLConnector.retrieveDataTable("buscar_recibos_Movban", varDesdefechaOrd, varHastafechaOrd)

        For Each row As DataRow In tabla.Rows

            Dim CampoRecibos As New LeeRecibos(row.Item(0), row.Item(1), row.Item(2),
                                           row.Item(3), row.Item(4), row.Item(5),
                                           row.Item(6), row.Item(7), row.Item(8),
                                           row.Item(9), row.Item(10), row.Item(11), row.Item(12),
                                           row.Item(13), row.Item(14), row.Item(15), row.Item(16), row.Item(17),
                                           row.Item(18), row.Item(19), row.Item(20))

            varRenglon = varRenglon + 1

            If CampoRecibos.recibo = 88523 Then Stop

            varTitulo = "Recibos"
            varEmpresa = 1
            varTituloList = "Surfactan S.A."
            varVarios = "Desde el " + txtDesdeFecha.Text + " hasta el " + txthastafecha.Text

            If Proceso._EsPellital() Then
                varEmpresa = 8
                varTituloList = "Pellital S.A."
            End If

            varAcredita = CampoRecibos.fecha
            varAcreditaOrd = CampoRecibos.fechaord
            varDebito = CampoRecibos.importe2
            varCredito = 0
            varBanco = 0

            If Not Proceso._EsPellital() Then
                Select Case Trim(CampoRecibos.cuenta)
                    Case "21"
                        varBanco = 3
                    Case "22"
                        varBanco = 8
                    Case "26"
                        varBanco = 12
                    Case "27"
                        varBanco = 16
                    Case Else
                        varBanco = 99
                End Select
            Else
                Select Case Trim(CampoRecibos.cuenta)
                    Case "22"
                        varBanco = 5
                    Case "25"
                        varBanco = 12
                    Case "26"
                        varBanco = 11
                    Case Else
                        varBanco = 99
                End Select
            End If

            If varBanco >= Val(txtDesdeBanco.Text) And varBanco <= Val(txtHastaBanco.Text) Then

                SQLConnector.executeProcedure("alta_movban", varRenglon, varBanco, CampoRecibos.fecha, CampoRecibos.fechaord, varAcredita, varAcreditaOrd, "Recibos",
                                              CampoRecibos.recibo, varDebito, varCredito, CampoRecibos.recibo, varEmpresa, varTituloList, varVarios, "")

            End If

        Next

        'Dim txtdada As Double
        'txtdada = SQLConnector.executeProcedureWithReturnValue("get_saldo_inicial_pagos", txtDesdefechaOrd, txtHastafechaOrd, txtDesdeBanco.Text, txtHastaBanco.Text)

        ' Calculamos los saldos iniciales para los bancos seleccionados.

        Dim WInicial(100) As Double

        ' PAGOS
        cm.CommandText = "SELECT Tipo2, Banco2, Importe2, TipoReg, Importe1 FROM Pagos Where FechaOrd < '" & Proceso.ordenaFecha(txtDesdeFecha.Text) & "' AND Banco2 BETWEEN '" & Trim(txtDesdeBanco.Text) & "' AND '" & Trim(txtHastaBanco.Text) & "'"

        SQLConnector.conexionSql(cn, cm)

        Try

            dr = cm.ExecuteReader()

            With dr
                If .HasRows Then

                    Do While .Read()


                        If Val(.Item("Tipo2")) = 2 Then
                            WInicial(.Item("Banco2")) = WInicial(.Item("Banco2")) - .Item("Importe2")
                        End If

                        If Val(.Item("TipoReg")) = 1 And Val(.Item("Banco2")) <> 0 Then
                            WInicial(.Item("Banco2")) = WInicial(.Item("Banco2")) + .Item("Importe1")
                        End If
                    Loop

                End If
            End With


        Catch ex As Exception
            MsgBox("Hubo un problema al querer consultar la Base de Datos.", MsgBoxStyle.Critical)
        Finally

            'dr = Nothing
            cn.Close()
            'cn = Nothing
            'cm = Nothing

        End Try

        ' DEPOSITOS

        cm.CommandText = "SELECT Banco, Importe FROM Depositos Where FechaOrd < '" & Proceso.ordenaFecha(txtDesdeFecha.Text) & "' AND Renglon = '01' AND Banco BETWEEN '" & Trim(txtDesdeBanco.Text) & "' AND '" & Trim(txtHastaBanco.Text) & "'"

        SQLConnector.conexionSql(cn, cm)

        Try

            dr = cm.ExecuteReader()

            With dr
                If .HasRows Then

                    Do While .Read()

                        WInicial(.Item("Banco")) = WInicial(.Item("Banco")) + .Item("Importe")

                    Loop

                End If
            End With


        Catch ex As Exception
            MsgBox("Hubo un problema al querer consultar la Base de Datos.", MsgBoxStyle.Critical)
        Finally

            'dr = Nothing
            cn.Close()
            'cn = Nothing
            'cm = Nothing

        End Try

        ' RECIBOS

        cm.CommandText = "SELECT Tipo2, Importe2, Cuenta FROM Recibos Where FechaOrd < '" & Proceso.ordenaFecha(txtDesdeFecha.Text) & "' AND Cuenta IN ('21','22','26','27')"

        SQLConnector.conexionSql(cn, cm)

        Dim WTipo = 0

        Try

            dr = cm.ExecuteReader()

            With dr
                If .HasRows Then

                    Do While .Read()
                        WTipo = IIf(IsDBNull(.Item("Tipo2")), 0, Val(.Item("Tipo2")))
                        If WTipo = 4 Then

                            If Not proceso._EsPellital() Then
                                Select Case Val(.Item("Cuenta"))
                                    Case 21
                                        WInicial(3) = WInicial(3) + .Item("Importe2")
                                    Case 22
                                        WInicial(8) = WInicial(8) + .Item("Importe2")
                                    Case 26
                                        WInicial(12) = WInicial(12) + .Item("Importe2")
                                    Case 27
                                        WInicial(16) = WInicial(16) + .Item("Importe2")
                                End Select
                            Else

                                Select Case Val(.Item("Cuenta"))
                                    Case 22
                                        WInicial(5) = WInicial(5) + .Item("Importe2")
                                    Case 25
                                        WInicial(12) = WInicial(12) + .Item("Importe2")
                                    Case 26
                                        WInicial(11) = WInicial(11) + .Item("Importe2")
                                End Select

                            End If

                        End If

                    Loop

                End If
            End With


        Catch ex As Exception
            MsgBox("Hubo un problema al querer consultar la Base de Datos.", MsgBoxStyle.Critical)
        Finally

            'dr = Nothing
            cn.Close()
            'cn = Nothing
            'cm = Nothing

        End Try

        If Not Proceso._EsPellital() Then

            WInicial(3) = WInicial(3) - 4624.79 + 82277.33 - 21644.52 - 29233
            WInicial(8) = WInicial(8) + 65799.41 - 112141.1 + 11998.39 + 15008.45 + 10000.94 - 46211.58 + 46128.29 + 4135.52 - 434355.52 + 284428 + 2358.81
            WInicial(9) = WInicial(9) - 982.73
            WInicial(11) = WInicial(11) + 34749.08
            WInicial(12) = WInicial(12) - 3348.97

        Else

            WInicial(12) = WInicial(12) - 20491.04 - 75346.71
            WInicial(11) = WInicial(11) - 658606.91 - 87000
            WInicial(5) = WInicial(5) - 319209.66 + 46739.76 - 2921911.71
            WInicial(14) = WInicial(14) + 105837.46 - 99780.98

        End If


        ' Creamos los registros con los saldos iniciales.

        For i = 0 To 100

            If WInicial(i) <> 0 Then
                varRenglon = varRenglon + 1

                varTitulo = ""
                varEmpresa = 1
                varTituloList = "Surfactan S.A."
                varVarios = "Desde el " + txtDesdeFecha.Text + " hasta el " + txthastafecha.Text

                If Proceso._EsPellital() Then
                    varEmpresa = 8
                    varTituloList = "Pellital S.A."
                End If

                varAcredita = "00/00/0000" 'CampoPagos.fecha
                varAcreditaOrd = "00000000" 'CampoPagos.fechaord

                If WInicial(i) > 0 Then
                    varDebito = WInicial(i) 'CampoPagos.importe1
                    varCredito = 0
                Else
                    varDebito = 0 'CampoPagos.importe1
                    varCredito = Math.Abs(WInicial(i))
                End If


                SQLConnector.executeProcedure("alta_movban", varRenglon, i, "00/00/0000", "00000000", varAcredita, varAcreditaOrd, "Saldo Inicial",
                                              0, varDebito, varCredito, 0, varEmpresa, varTituloList, varVarios, 0)
            End If

        Next

        _ActualizarObservacionesVacias()

        varUno = "{Movban.Banco} in " + txtDesdeBanco.Text + " to " + txtHastaBanco.Text
        varFormula = varUno

        Dim viewer As New ReportViewer("Listado de Movimientos Bancarios", Globals.reportPathWithName("wMovbannet.rpt"), varFormula)

        With viewer

            Select Case TipoImpresion
                Case Reporte.Pantalla
                    .ShowDialog()
                Case Reporte.Imprimir
                    .imprimirReporte()
            End Select

        End With

    End Sub

    Private Sub _ActualizarObservacionesVacias()

        Dim cn = New SqlConnection()
        Dim cm = New SqlCommand("SELECT Da as Clave, Observaciones, Proveedor FROM MovBan WHERE Observaciones = '' or Observaciones IS NULL")
        Dim dr As SqlDataReader
        Dim WObs = "", WProv = "", WDa = ""

        Try

            cn.ConnectionString = Proceso._ConectarA
            cn.Open()
            cm.Connection = cn

            dr = cm.ExecuteReader()

            If dr.HasRows Then

                Do While dr.Read()

                    With dr

                        WDa = IIf(IsDBNull(.Item("Clave")), "", .Item("Clave"))
                        WObs = IIf(IsDBNull(.Item("Observaciones")), "", .Item("Observaciones"))
                        WProv = IIf(IsDBNull(.Item("Proveedor")), "", .Item("Proveedor"))

                        If Trim(WObs) = "" Then

                            If Val(WProv) <> 0 Then
                                WObs = _ObtenerNombreProveedor(WProv)
                            End If

                            If Trim(WObs) <> "" Then

                                _ActualizarObservacion(WDa, WObs)

                            End If

                        End If

                    End With

                Loop

            End If

        Catch ex As Exception
            Throw New Exception("Hubo un problema al querer actualizar la observación la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

    End Sub

    Private Sub _ActualizarObservacion(ByVal wDa As String, ByVal wObs As String)

        Dim cn = New SqlConnection()
        Dim cm = New SqlCommand("UPDATE Movban SET Observaciones = '" & Trim(wObs) & "' WHERE da = '" & wDa & "'")

        Try

            cn.ConnectionString = Proceso._ConectarA
            cn.Open()
            cm.Connection = cn

            cm.ExecuteNonQuery()
        Catch ex As Exception
            Throw New Exception("Hubo un problema al querer actualizar la observación la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        Finally

            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

    End Sub

    Private Function _ObtenerNombreProveedor(ByVal wProv As String) As String

        Dim cn = New SqlConnection()
        Dim cm = New SqlCommand("SELECT Nombre FROM Proveedor WHERE Proveedor = '" & Trim(wProv) & "'")
        Dim dr As SqlDataReader
        Dim WNom = ""
        Try

            cn.ConnectionString = Proceso._ConectarA
            cn.Open()
            cm.Connection = cn

            dr = cm.ExecuteReader()

            If dr.HasRows Then

                dr.Read()

                WNom = IIf(IsDBNull(dr.Item("Nombre")), "", dr.Item("Nombre"))

                WNom = Trim(WNom)

            End If

        Catch ex As Exception
            Throw New Exception("Hubo un problema al querer buscar la informacion para actualizar la observacion desde la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

        Return WNom
    End Function

    Private Sub txtDesdeBanco_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtDesdeBanco.MouseDoubleClick
        btnConsulta.PerformClick()
    End Sub


    ' Rutinas de Filtrado Dinámico.
    Private Sub _FiltrarDinamicamente()
        Dim origen As ListBox = lstAyuda
        Dim final As ListBox = lstFiltrada
        Dim cadena As String = Trim(txtAyuda.Text)

        final.Items.Clear()

        If UCase(Trim(cadena)) <> "" Then

            For Each item In origen.Items

                If UCase(item.ToString()).Contains(UCase(Trim(cadena))) Then

                    final.Items.Add(item)

                End If

            Next

            final.Visible = True

        Else

            final.Visible = False

        End If
    End Sub

    Private Sub lstFiltrada_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstFiltrada.MouseClick
        Dim origen As ListBox = lstAyuda
        Dim filtrado As ListBox = lstFiltrada
        Dim texto As TextBox = txtAyuda

        ' Buscamos el texto exacto del item seleccionado y seleccionamos el mismo item segun su indice en la lista de origen.
        origen.SelectedIndex = origen.FindStringExact(filtrado.SelectedItem.ToString)

        ' Llamamos al evento que tenga asosiado el control de origen.
        lstAyuda_Click(Nothing, Nothing)


        ' Sacamos de vista los resultados filtrados.
        filtrado.Visible = False
        texto.Text = ""
    End Sub

    Private Sub txtAyuda_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAyuda.TextChanged
        _FiltrarDinamicamente()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        txtDesdeBanco.Text = "0"
        txtHastaBanco.Text = "9999"

        txtDesdeFecha.Clear()
        txthastafecha.Clear()

        txtAyuda.Text = ""

        txtDesdeFecha.Focus()
    End Sub

    Private Sub ListadoMovimientosBancos_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        txtDesdeFecha.Focus()
    End Sub

    Private Sub txtDesdeFecha_TypeValidationCompleted(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TypeValidationEventArgs) Handles txtDesdeFecha.TypeValidationCompleted
        e.Cancel = Not Proceso._ValidarFecha(txtDesdeFecha.Text, e.IsValidInput)
    End Sub

    Private Sub txthastafecha_TypeValidationCompleted(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TypeValidationEventArgs) Handles txthastafecha.TypeValidationCompleted
        e.Cancel = Not Proceso._ValidarFecha(txthastafecha.Text, e.IsValidInput)
    End Sub

    Private Sub SoloNumero(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDesdeBanco.KeyPress, txtHastaBanco.KeyPress
        If Not Char.IsNumber(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub btnPantalla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPantalla.Click
        _Imprimir(Reporte.Pantalla)
    End Sub

    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
        _Imprimir(Reporte.Imprimir)
    End Sub
End Class