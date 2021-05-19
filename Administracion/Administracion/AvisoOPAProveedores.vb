Imports System.Data.SqlClient
Imports System.IO
Imports Microsoft.Office.Interop.Outlook
Imports System.Text.RegularExpressions

Public Class AvisoOPAProveedores

    Private WNoEnviados(,) As String = New String(1000, 2) {}
    Private WNoEnviadosPorERRORDEMAIL(,) As String = New String(1000, 2) {}
    Dim WIndiceNoEnviadosPorERRORDEMAIL As Integer = 0
    Dim WIndiceNoEnviados As Integer = 0
    Private WPorComando As Boolean = True
    Private WBCC As String = ""

    Sub New(Optional ByVal PorComando As Boolean = False)

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        WPorComando = PorComando

    End Sub

    Private Sub btnCerrar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCerrar.Click
        Close()
    End Sub

    Private Sub RadioButton1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles rbEntreRango.Click, rbEntreFechas.Click

        txtDesde.Mask = "000000"
        txtHasta.Mask = "000000"

        txtDesde.Text = ""
        txtHasta.Text = ""

        If rbEntreFechas.Checked Then
            txtDesde.Mask = "00/00/0000"
            txtHasta.Mask = "00/00/0000"
            txtDesde.Text = Date.Now.ToString("dd/MM/yyyy")
            txtHasta.Text = txtDesde.Text
        End If

        With txtDesde
            .Focus()
            .SelectionStart = 0
            .SelectionLength = .Text.Length
        End With

    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnLimpiar.Click

        txtDesde.Text = ""
        txtHasta.Text = ""

        WNoEnviados = New String(1000, 2) {}
        WIndiceNoEnviados = 0

        rbEntreFechas.Checked = True

        Dim WFechaBase As Date = Date.Now

        Dim WFechaFinal = WFechaBase.AddDays(-1 * (WFechaBase.DayOfWeek - DayOfWeek.Friday)).ToString("dd/MM/yyyy")

        txtAPartirFecha.Text = WFechaFinal

        RadioButton1_Click(Nothing, Nothing)

    End Sub

    Private Sub AvisoOPAProveedores_Shown(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Shown
        With txtDesde
            .Focus()
            .SelectionStart = 0
            .SelectionLength = .Text.Length
        End With
    End Sub

    Private Sub AvisoOPAProveedores_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        btnLimpiar.PerformClick()

        If WPorComando Then

            WBCC = "recepcion@surfactan.com.ar;"

            '
            ' Marcamos para que se manden todos los de la semana actual, para evitar que se queden colgados algunos.
            '
            txtDesde.Text = Date.Now.AddDays(-1 * (Date.Now.DayOfWeek - DayOfWeek.Monday)).ToString("dd/MM/yyyy")
            txtHasta.Text = Date.Now.AddDays(-1 * (Date.Now.DayOfWeek - DayOfWeek.Friday)).ToString("dd/MM/yyyy")

            btnEnviar_Click(Nothing, Nothing)

            Close()

        End If

    End Sub

    Private Sub btnEnviar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnEnviar.Click

        Try

            WNoEnviados = New String(1000, 2) {}
            WIndiceNoEnviados = 0

            ProgressBar1.Value = 0

            Dim WParametros As String = "Entre " & txtDesde.Text & " al " & txtHasta.Text

            If txtAPartirFecha.Text.Replace("/", "").Trim = "" Then
                Dim WFechaBase As Date = Date.Now

                Dim WFechaFinal = WFechaBase.AddDays(-1 * (WFechaBase.DayOfWeek - DayOfWeek.Friday)).ToString("dd/MM/yyyy")

                txtAPartirFecha.Text = WFechaFinal
            End If

            '
            ' Buscamos los proveedores con OP.
            '
            Dim WOrdenesPago As DataTable = _TraerProveedoresConOP()

            ProgressBar1.Maximum = WOrdenesPago.Rows.Count

            For Each row2 As DataRow In WOrdenesPago.Rows

                Dim WFechasTransferencias As String = ""
                Dim WFechasECheques As String = ""
                Dim WFechasCompensaciones As String = ""

                With row2
                    Dim WOrden As String = OrDefault(.Item("Orden"), "")

                    If Trim(WOrden) = "" Then Continue For

                    '
                    ' Consultamos la información de la Orden de Pago para determinar si es o no por transferencia.
                    '
                    Dim WOrdenPago As DataTable = _TraerDatosOrdenPago(WOrden)
                    Dim EsPorTransferencia As Boolean = False
                    Dim WHayECheques As Boolean = False
                    Dim WHayCompensaciones As Boolean = False
                    Dim PorTransferenciaYCheques As Boolean = False
                    Dim WProveedor As String = ""

                    If WOrdenPago.Rows.Count > 0 Then

                        For Each row As DataRow In WOrdenPago.Rows
                            With row

                                Dim WTipo2 = OrDefault(.Item("Tipo2"), "00")

                                Select Case Val(WTipo2)
                                    Case 2

                                        EsPorTransferencia = Val(OrDefault(.Item("Numero2"), "")) = 0

                                        If EsPorTransferencia And Not WFechasTransferencias.Contains(OrDefault(.Item("Fecha2"), "")) Then
                                            WFechasTransferencias &= OrDefault(.Item("Fecha2"), "") & ","
                                        End If

                                    Case 6 ' Compensación entre Cuentas Corrientes.
                                        EsPorTransferencia = Val(OrDefault(.Item("Cuenta"), "00")) = 5
                                        
                                        WHayCompensaciones = Val(OrDefault(.Item("Cuenta"), "00")) = 5

                                        If WHayCompensaciones And Not WFechasCompensaciones.Contains(OrDefault(.Item("Fecha2"), "")) Then
                                            WFechasCompensaciones &= OrDefault(.Item("Fecha2"), "") & ","
                                        End If

                                        If EsPorTransferencia Then Exit For
                                    Case 7
                                        WHayECheques = True

                                        If Not WFechasECheques.Contains(OrDefault(.Item("Fecha2"), "")) Then
                                            WFechasECheques &= OrDefault(.Item("Fecha2"), "") & ","
                                        End If
                                    Case 3
                                        If EsPorTransferencia Then PorTransferenciaYCheques = True
                                    Case Else
                                        EsPorTransferencia = False
                                End Select


                            End With
                        Next

                        With WOrdenPago.Rows(0)

                            WProveedor = OrDefault(.Item("Proveedor"), "")
                            Dim WDescProveedor = OrDefault(.Item("Nombre"), "")
                            Dim WFechaOP As String = OrDefault(.Item("Fecha"), "")
                            Dim WTipoOrd As Integer = Val(OrDefault(.Item("TipoOrd"), ""))

                            If Trim(WProveedor) <> "" Then


                                If Not _EnviarAvisoSegunSelectivoSemanal(WProveedor, WFechaOP) Then Continue For

                                WFechasTransferencias = WFechasTransferencias.TrimEnd(",")

                                If _EsPellital() Then

                                    _EnviarAvisoOPDisponiblePellital(WProveedor, WDescProveedor, WOrden, EsPorTransferencia, WFechasTransferencias, PorTransferenciaYCheques, HayECheques:=WHayECheques, FechasECheques:=WFechasECheques, TipoOrd:=WTipoOrd)
                                Else
                                    _EnviarAvisoOPDisponible(WProveedor, WDescProveedor, WOrden, EsPorTransferencia, WFechasTransferencias, PorTransferenciaYCheques, HayECheques:=WHayECheques, FechasECheques:=WFechasECheques, TipoOrd:=WTipoOrd, WHayCompensaciones:=WHayCompensaciones, WFechasCompensaciones:=WFechasCompensaciones)
                                End If

                            End If

                        End With

                    End If

                End With

                ProgressBar1.Increment(1)

            Next

            ProgressBar1.Value = 0

            If WIndiceNoEnviados > 0 And Not WPorComando Then
                MsgBox("Hay Proveedores a los que no se pudieron enviar el Aviso debido a que no tienen informado una Casilla de Mail a dónde enviar el mismo.", MsgBoxStyle.Information)

                Dim tabla As DataTable = New DBAuxi.AvisosNoEnviadosDataTable

                For i = 1 To WIndiceNoEnviados
                    If Trim(WNoEnviados(i, 0)) <> "" Then

                        Dim r As DataRow = tabla.NewRow

                        r.Item("Id") = i
                        r.Item("Proveedor") = WNoEnviados(i, 0)
                        r.Item("OrdenPago") = WNoEnviados(i, 1)
                        r.Item("DescProveedor") = _TraerDescProveedor(r.Item("Proveedor"))
                        r.Item("Parámetro") = WParametros

                        tabla.Rows.Add(r)

                    End If
                Next

                Dim rpt As New AvisosNoEnviados
                rpt.SetDataSource(tabla)

                With VistaPrevia
                    .Reporte = rpt
                    .Mostrar()
                End With

            End If

            'INCLUIDO POR ANDRES

            If WIndiceNoEnviadosPorERRORDEMAIL > 0 And WPorComando Then
                ' EnviarMailAviso_MalCargados()
            End If
            'FIN INCLUCION

            If Not WPorComando Then
                MsgBox("¡Proceso finalizado correctamente!", MsgBoxStyle.Information)
            Else
                Close()
            End If

        Catch ex As System.Exception
            If Not WPorComando Then
                MsgBox(ex.Message, MsgBoxStyle.Exclamation)
            Else
                Close()
            End If
        End Try

    End Sub

    Private Sub EnviarMailAviso_MalCargados()

        Try
            'Direccion donde se mandan los proveedores con mails incorrectos
            Dim WMailAEnviar As String = "recepcion@surfactan.com.ar"

            Dim WBody As String = ""

            WBody = "A los siguientes proveedores no se pudo enviar el mail de Aviso de Orden de Pago, debido a errores de tipeo en la dirección de mail correspondiente." & "<br/>"

            For i = 1 To WIndiceNoEnviadosPorERRORDEMAIL
                Dim Proveedor As String = WNoEnviadosPorERRORDEMAIL(i, 0)
                Dim OrdenPago As String = WNoEnviadosPorERRORDEMAIL(i, 1)
                

                WBody &= " - Proveedor : "
                WBody &= "<strong>" & Proveedor & "  " & _TraerDescProveedor(Proveedor) & "</strong>"
                WBody &= " Para la Orden Nro: "
                WBody &= "<strong>" & OrdenPago & "</strong>" & "<br/>"

            Next

            'Dim WAsunto As String = "Proveedores Con Mails a Revisar"
            Dim WAsunto As String = "Notificación de no envío de Aviso de OP a Proveedores por error en direcciones."

            Dim WAdjuntos As New List(Of String)

            WBCC = "aam@surfactan.com.ar"

            _EnviarEmail(WMailAEnviar, WBCC, WAsunto, WBody, WAdjuntos.ToArray)

        Catch ex As System.Exception
            If Not WPorComando Then Throw New System.Exception("Hubo un problema al querer procesar el envío de mail por OP Disponible." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        End Try

    End Sub
    Private Function _EnviarAvisoSegunSelectivoSemanal(ByVal wProveedor As String, ByVal wFechaOp As String) As Boolean

        Dim WFechaInicial As String = ""
        Dim WFechaFinal As String = ""

        'Dim WFechaBase As Date = (New Date(wFechaOp.Substring(6, 4), wFechaOp.Substring(3, 2), wFechaOp.Substring(0, 2)))

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("")
        Dim dr As SqlDataReader

        Try

            Dim WFechaBase As Date = Date.ParseExact(wFechaOp, "dd/MM/yyyy", Nothing)

            WFechaInicial = WFechaBase.AddDays(-1 * (WFechaBase.DayOfWeek - DayOfWeek.Monday)).ToString("yyyyMMdd")
            WFechaFinal = WFechaBase.AddDays(-1 * (WFechaBase.DayOfWeek - DayOfWeek.Friday)).ToString("yyyyMMdd")

            cn.ConnectionString = _ConectarA()
            cn.Open()
            cm.Connection = cn
            cm.CommandText = "SELECT Proveedor, EnviarAvisoOp FROM ProveedorSelectivo WHERE Proveedor = '" & wProveedor & "' and FechaOrd >= '" & WFechaInicial & "' And FechaOrd <= '" & WFechaFinal & "'"

            dr = cm.ExecuteReader()

            If dr.HasRows Then

                dr.Read()

                Return OrDefault(dr.Item("EnviarAvisoOp"), "X") = "X"

            End If

        Catch ex As System.Exception
            If Not WPorComando Then Throw New System.Exception("Hubo un problema al querer consultar la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

        Return True

    End Function

    Private Sub _MarcarOPComoEnviada(ByVal OrdenPago As Object)

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("UPDATE Pagos SET AvisoMailOp = '1' WHERE Orden = '" & OrdenPago & "'")

        Try

            cn.ConnectionString = _ConectarA()
            cn.Open()
            cm.Connection = cn

            cm.ExecuteNonQuery()

        Catch ex As System.Exception
            If Not WPorComando Then Throw New System.Exception("No se pudo marcar la Orden de Pago '" & OrdenPago & "' como 'ENVIADA'." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        Finally

            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

    End Sub

    Private Function _TraerDescProveedor(ByVal Proveedor As Object) As String

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT Nombre FROM Proveedor WHERE Proveedor = '" & Proveedor & "'")
        Dim dr As SqlDataReader

        Try

            cn.ConnectionString = _ConectarA()
            cn.Open()
            cm.Connection = cn

            dr = cm.ExecuteReader()

            If dr.HasRows Then
                dr.Read()

                Return UCase(Trim(OrDefault(dr.Item("Nombre"), "")))

            End If

        Catch ex As System.Exception
            If Not WPorComando Then Throw New System.Exception("Hubo un problema al querer consultar la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

        Return ""

    End Function

    Private Function _TraerDatosOrdenPago(ByVal OrdenPago As String) As DataTable

        Dim tabla As New DataTable

        Using cn As New SqlConnection

            cn.ConnectionString = _ConectarA()
            cn.Open()

            Using cm As New SqlCommand()
                cm.Connection = cn
                cm.CommandText = "SELECT p.Proveedor, p.Fecha, pr.Nombre, p.Tipo2, p.Importe2, p.Numero2, p.Importe, p.Cuenta, p.Fecha2, p.TipoOrd FROM Pagos p LEFT OUTER JOIN Proveedor pr ON pr.Proveedor = p.Proveedor WHERE p.Orden = '" & OrdenPago & "' and p.TipoReg IN ('02', '2') Order by p.Tipo2"

                Using dr As SqlDataReader = cm.ExecuteReader

                    If dr.HasRows Then
                        tabla.Load(dr)
                    End If

                End Using
            End Using
        End Using

        Return tabla

    End Function

    Private Function _TraerProveedoresConOP() As DataTable
        Dim WTabla As New DataTable
        Dim WFiltro As String = ""

        If rbEntreFechas.Checked Then
            Dim WDesdeOrd As String = ordenaFecha(txtDesde.Text)
            Dim WHastaOrd As String = ordenaFecha(txtHasta.Text)

            WFiltro = " p.FechaOrd BETWEEN '" & WDesdeOrd & "' And '" & WHastaOrd & "' "

        Else

            WFiltro = " p.Orden >= '" & txtDesde.Text & "' And p.Orden <= '" & txtHasta.Text & "' "

        End If

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT DISTINCT p.Proveedor, p.Orden, p.TipoOrd FROM Pagos p WHERE p.Proveedor <> '' And p.TipoOrd IN ('1', '2', '3', '4', '5') And ISNULL(AvisoMailOp, '0') = '0' And " & WFiltro & " ")
        Dim dr As SqlDataReader

        Try

            cn.ConnectionString = _ConectarA()
            cn.Open()
            cm.Connection = cn

            dr = cm.ExecuteReader()

            If dr.HasRows Then
                WTabla.Load(dr)
            End If

        Catch ex As System.Exception
            If Not WPorComando Then Throw New System.Exception("Hubo un problema al querer consultar los Proveedores con OP." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

        Return WTabla
    End Function

    '
    'INCLUIDO POR ANDRES
    '
    Public Shared Function FormatoCorreoValido(ByVal correo As String) As Boolean
        correo = Trim(correo)
        Dim Listmails As New List(Of String)

        'EN CASO DE TENER PUNTO Y COMO LOS SEPARAMOS PARA COMPROBARLOS POR SEPARADO
        If correo.Contains(";") Then
            Listmails.AddRange(Split(correo, ";"))
        End If

        If Listmails.Count > 0 Then
            'ESTE CAMINO ES SI SON VARIOS MAILS
            For Each mail As String In Listmails

                Dim MailInpeccionar = Trim(mail)
                'POR CADA UNO COMPROBAMOS SI TIENEN LOS SIGNOS "<" Y ">" Y EXTRAEMOS LE MAIL DE ADENTRO
                If MailInpeccionar.Contains("<") And MailInpeccionar.Contains(">") Then
                    Dim Inicio As String = -1
                    Dim Final As String = -1
                    For i = 0 To Len(MailInpeccionar) - 1
                        If MailInpeccionar.Chars(i) = "<" Then
                            Inicio = i + 1
                        End If
                        If MailInpeccionar.Chars(i) = ">" Then
                            Final = i
                        End If
                    Next

                    If Inicio <> -1 And Final <> -1 Then
                        MailInpeccionar = MailInpeccionar.Substring(Inicio, (Final - Inicio))
                    End If

                End If

                '
                ' La siguiente expresión regular permite direcciones del siguiente estilo:
                '   sop+surfac@mail.com
                '   sop.surfac@mail.com.ar
                '   sop_surfac@mail.com
                '   sopsurfac@mail.com.ar
                ' Exige que lo posterior al @ tenga el formato mail.com o mail.com.ar
                '   Ej: sop+surfac@mail.com
                '
                '   Toma como invalido lo siguiente: soporte@surfactan
                '

                Dim sregVarios As String = "^[a-zA-Z0-9.+_]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?\.(?:[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$"
                Dim rgxVarios As Regex = New Regex(sregVarios)

                If rgxVarios.IsMatch(MailInpeccionar) = False Then
                    Dim sreg2 As String = "^[a-zA-Z0-9.+_]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?\.(?:[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)?\.(?:[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$"
                    Dim rgx2 As Regex = New Regex(sreg2)
                    If rgx2.IsMatch(MailInpeccionar) = False Then
                        Return False
                    End If

                End If
            Next

            Return True

        End If


        'ESTE CAMINO ES SI NO SON VARIOS MAILS


        If correo.Contains("<") And correo.Contains(">") Then
            Dim Inicio As Integer = -1
            Dim Final As Integer = -1
            For i = 0 To Len(correo) - 1
                If correo.Chars(i) = "<" Then
                    Inicio = i + 1
                End If
                If correo.Chars(i) = ">" Then
                    Final = i
                End If
            Next

            If Inicio <> -1 And Final <> -1 Then
                correo = correo.Substring(Inicio, (Final - Inicio))
            End If

        End If


        '
        ' La siguiente expresión regular permite direcciones del siguiente estilo:
        '   sop+surfac@mail.com
        '   sop.surfac@mail.com.ar
        '   sop_surfac@mail.com
        '   sopsurfac@mail.com.ar
        ' Exige que lo posterior al @ tenga el formato mail.com o mail.com.ar
        '   Ej: sop+surfac@mail.com
        '
        '   Toma como invalido lo siguiente: soporte@surfactan
        '


        Dim sreg As String = "^[a-zA-Z0-9.+_]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?\.(?:[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$"
        Dim rgx As Regex = New Regex(sreg)

        If rgx.IsMatch(correo) = False Then
            Dim sreg2 As String = "^[a-zA-Z0-9.+_]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?\.(?:[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)?\.(?:[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$"
            Dim rgx2 As Regex = New Regex(sreg2)
            Return rgx2.IsMatch(correo)
        Else
            Return rgx.IsMatch(correo)
        End If


    End Function

    '
    'FIN INCLUSION
    '
    Private Sub _EnviarAvisoOPDisponible(ByVal Proveedor As String, ByVal wDescProveedor As String, Optional ByVal OrdenPago As String = "", Optional ByVal EsPorTransferencia As Boolean = False, Optional ByVal wFechasTransferencias As String = "", Optional ByVal PorTransferenciaYCheques As Boolean = False, Optional ByVal HayECheques As Boolean = False, Optional ByVal FechasECheques As String = "", Optional ByVal TipoOrd As Integer = 0, Optional ByVal WHayCompensaciones As Boolean = False, Optional ByVal WFechasCompensaciones As String = "")

        If Proveedor.Trim = "" Then Exit Sub
        If EsPorTransferencia And Trim(OrdenPago) = "" Then Exit Sub

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT ISNULL(MailOP, '') MailOP FROM Proveedor WHERE Proveedor = '" & Proveedor & "'")
        Dim dr As SqlDataReader

        Try

            cn.ConnectionString = _ConectarA()
            cn.Open()
            cm.Connection = cn

            dr = cm.ExecuteReader()

            If dr.HasRows Then

                dr.Read()

                Dim WMailOp As String = dr.Item("MailOp")

                If WMailOp.Trim = "" Then
                    WIndiceNoEnviados += 1
                    WNoEnviados(WIndiceNoEnviados, 0) = Proveedor
                    WNoEnviados(WIndiceNoEnviados, 1) = OrdenPago
                    Exit Sub
                End If

                '
                'PARTE AGREGADA PARA COMPROBAR QUE EL MAIL ESTE ESCRITO CORRECTAMENTE
                '20/01/2021
                '
                If Not FormatoCorreoValido(Trim(LCase(WMailOp))) Then
                    'MsgBox("contiene caracter no valido verificar", vbExclamation)

                    'CONSULTAMOS SI SE ENCUENTA EN LA TABLA
                    Dim SQLCnslt As String = "SELECT Proveedor FROM ListaProvOPMailIncorrecto WHERE Proveedor = '" & Proveedor & "'"
                    Dim RowMailIncorrectos As DataRow = GetSingle(SQLCnslt, "SurfactanSa")
                    If RowMailIncorrectos Is Nothing Then
                        ' SINO SE ENCUENTRA LO CARGAMOS EN EL MAIL AUTOMATICO
                        WIndiceNoEnviadosPorERRORDEMAIL += 1
                        WNoEnviadosPorERRORDEMAIL(WIndiceNoEnviadosPorERRORDEMAIL, 0) = Proveedor
                        WNoEnviadosPorERRORDEMAIL(WIndiceNoEnviadosPorERRORDEMAIL, 1) = OrdenPago
                        ' LO GRABAMOS EN LA TABLA
                        SQLCnslt = "INSERT INTO ListaProvOPMailIncorrecto(Proveedor) VALUES('" & Proveedor & "')"
                        ExecuteNonQueries("SurfactanSa", {SQLCnslt})
                    End If

                    'Y SALTEAMOS EL ENVIO DE MAIL
                    Exit Sub
                End If
                '
                'FIN INCLUCION ANDRES
                '



                '
                ' SACAR DESPUES. SOLO PRUEBA.
                '
                ' WMailOp = "sistemas@surfactan.com.ar"

                Dim WBody = ""

                If EsPorTransferencia Then

                    'WBody = "Informamos que durante el transcurso del día de hoy, SURFACTAN S.A. le realizará una transferencia"
                    WBody = "Informamos que durante el transcurso del día de hoy, SURFACTAN S.A. le realizará un pago mediante los siguientes métodos de pagos: " & "<br/>"

                    If Not WHayCompensaciones Then
                        WBody &= vbCrLf & "- Transferencia Bancaria"

                        If wFechasTransferencias.Trim <> "" Then

                            If wFechasTransferencias.Split(",").Count > 1 Then
                                WBody &= " con las siguientes fechas: "
                            Else
                                WBody &= " con fecha: "
                            End If

                            WBody &= "<strong>" & wFechasTransferencias & "</strong>"

                        End If

                    End If

                    If HayECheques Then

                        'WBody &= " y a través de Cheque(s) Electrónico(s)"
                        WBody &= vbCrLf & "- Cheque(s) Electrónico(s)"

                        If FechasECheques.Trim <> "" Then

                            If FechasECheques.Split(",").Count > 1 Then
                                WBody &= " con las siguientes fechas: "
                            Else
                                WBody &= " con fecha: "
                            End If

                            WBody &= "<strong>" & FechasECheques.TrimEnd(",") & "</strong>"

                        End If

                    End If

                    If WHayCompensaciones Then

                        WBody &= vbCrLf & "- Compensación de Pago."

                        If WFechasCompensaciones.Trim <> "" Then

                            If WFechasCompensaciones.Split(",").Count > 1 Then
                                WBody &= " con las siguientes fechas: "
                            Else
                                WBody &= " con fecha: "
                            End If

                            WBody &= "<strong>" & WFechasCompensaciones & "</strong>."

                        End If
                    End If

                    If PorTransferenciaYCheques Then
                        Dim DiaARetirar As Date
                        Dim DiaARetirarTexto As String = ""

                        TraerProximoMartesOJueves(DiaARetirar, DiaARetirarTexto)
                        
                        WBody &= vbCrLf & "- Cheque(s) que deberá retirar por nuestras oficinas <em>(Malvinas Argentinas 4495, B1644CAQ Victoria, Buenos Aires)</em>, a partir del <strong>" & DiaARetirarTexto & " " & DiaARetirar.ToString("dd/MM/yyyy") & "</strong>, los <strong>Martes y Jueves</strong> en el horario de <strong>14:00 a 17:00 hs.</strong>."
                    Else
                        WBody &= "." & "<br/>" & "<br/>" & "Adjuntamos Orden de Pago y retenciones si correspondiesen."
                    End If

                ElseIf HayECheques Then

                    'WBody = "Informamos que en el día de la fecha, SURFACTAN S.A. le ha realizado un pago a través de Cheque(s) Electrónico(s)"
                    WBody = "Informamos que en el día de la fecha, SURFACTAN S.A. le ha realizado un pago mediante los siguientes metodos de pago:" & "<br/>"

                    WBody &= vbCrLf & "- Cheque(s) Electrónico(s)"

                    If FechasECheques.Trim <> "" Then

                        If FechasECheques.Split(",").Count > 1 Then
                            WBody &= " con las siguientes fechas: "
                        Else
                            WBody &= " con fecha: "
                        End If

                        WBody &= "<strong>" & FechasECheques & "</strong>"

                    End If

                    If WHayCompensaciones Then

                        WBody &= vbCrLf & "- Compensación de Pago"

                        If WFechasCompensaciones.Trim <> "" Then

                            If WFechasCompensaciones.Split(",").Count > 1 Then
                                WBody &= " con las siguientes fechas: "
                            Else
                                WBody &= " con fecha: "
                            End If

                            WBody &= "<strong>" & WFechasCompensaciones & "</strong>."

                        End If

                    End If

                    If PorTransferenciaYCheques Then
                        Dim DiaARetirar As Date
                        Dim DiaARetirarTexto As String = ""

                        TraerProximoMartesOJueves(DiaARetirar, DiaARetirarTexto)
                        
                        WBody &= vbCrLf & "- Cheque(s) que deberá retirar por nuestras oficinas <em>(Malvinas Argentinas 4495, B1644CAQ Victoria, Buenos Aires)</em>, los <strong>Martes y Jueves</strong> a partir del <strong>" & DiaARetirarTexto & " " & DiaARetirar.ToString("dd/MM/yyyy") & "</strong>, los <strong>Martes y Jueves</strong> en el horario de <strong>14:00 a 17:00 hs.</strong>."
                Else
                    WBody &= "." & "<br/>" & "<br/>" & "Adjuntamos Orden de Pago y retenciones si correspondiesen."
                End If

                Else
                    Dim DiaARetirar As Date
                    Dim DiaARetirarTexto As String = ""

                    TraerProximoMartesOJueves(DiaARetirar, DiaARetirarTexto)

                    WBody = "Informamos que se encuentra a su disposición un pago que podrá ser retirado por nuestras oficinas <em>(Malvinas Argentinas 4495, B1644CAQ Victoria, Buenos Aires)</em>, a partir del <strong>" & DiaARetirarTexto & " " & DiaARetirar.ToString("dd/MM/yyyy") & "</strong>, los <strong>Martes y Jueves</strong> en el horario de <strong>14:00 a 17:00 hs.</strong>"

                End If

                If Trim(wDescProveedor) <> "" Then
                    WBody = "Sres. <strong>" & wDescProveedor.Trim.ToUpper & "</strong> <br/>" & "<br/>" & WBody
                End If

                Select Case Proveedor
                    Case "10167878480", "10000000100", "10071081483", "10069345023", "10066352912", "10023969933", "10014123562"
                        WBody = WBody & "<br/>" & "<br/>" & "En caso de cualquier consulta, por favor dirigirla a strong><em>facturacion@surfactan.com.ar</em></strong> o <strong><em>biglesias@surfactan.com.ar</em></strong>"
                End Select

                Dim WAdjuntos As New List(Of String)

                If EsPorTransferencia And Not PorTransferenciaYCheques Then
                    WAdjuntos = _PrepararAdjuntos(OrdenPago)
                End If

                For Each wAdjunto As String In WAdjuntos
                    If Not File.Exists(wAdjunto) Then
                        If Not WPorComando Then
                            Throw New System.Exception("No existe el archivo " & wAdjunto)
                        Else
                            Exit Sub
                        End If
                    End If
                Next

                WBCC &= "mlarias@surfactan.com.ar;"

                Dim WAsunto As String = "ORDEN DE PAGO - SURFACTAN S.A. - "

                If TipoOrd = 2 Then ' Si es Anticipo
                    WAsunto = "ANTICIPO DE PAGO - SURFACTAN S.A. - "

                    If EsPorTransferencia Then
                        If HayECheques Then
                            If PorTransferenciaYCheques Then
                                'SI TIENE CHEQUES SE ENVIA A JUAN
                                WMailOp = "juanfs@surfactan.com.ar;"
                            End If
                        End If
                    Else
                        If HayECheques Then
                            If PorTransferenciaYCheques Then
                                'SI TIENE CHEQUES SE ENVIA A JUAN
                                WMailOp = "juanfs@surfactan.com.ar;"
                            End If
                        End If
                    End If


                End If



                _EnviarEmail(WMailOp, WBCC, WAsunto, WBody, WAdjuntos.ToArray)

                If WPorComando Then
                    WBCC = "recepcion@surfactan.com.ar;"
                End If


                _MarcarOPComoEnviada(OrdenPago)

                '
                ' INCLUIDO POR ANDRES 24/02/2021
                '
                Dim SQLCnst As String = "SELECT Proveedor FROM ListaProvOPMailIncorrecto WHERE Proveedor = '" & Proveedor & "'"
                Dim RowMailIncorrec As DataRow = GetSingle(SQLCnst, "SurfactanSa")
                If RowMailIncorrec IsNot Nothing Then
                    SQLCnst = "DELETE FROM ListaProvOPMailIncorrecto WHERE Proveedor = '" & Proveedor & "'"
                    ExecuteNonQueries("SurfactanSa", {SQLCnst})
                End If
                '
                ' FIN INCLUCION 24/02/2021
                '

            End If

        Catch ex As System.Exception
            If Not WPorComando Then Throw New System.Exception("Hubo un problema al querer procesar el envío de mail por OP Disponible." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

    End Sub

    Private Sub TraerProximoMartesOJueves(ByRef DiaARetirar As Date, ByRef DiaARetirarTexto As String)
        DiaARetirar = Date.Today
        For i = 1 To 10
            DiaARetirar = DiaARetirar.AddDays(1)
            Select Case DiaARetirar.DayOfWeek
                Case 2 'MARTES
                    DiaARetirarTexto = "Martes"
                    Exit Sub
                Case 4 'JUEVES
                    DiaARetirarTexto = "Jueves"
                    Exit Sub
            End Select
        Next
    End Sub

       Private Sub _EnviarAvisoOPDisponiblePellital(ByVal Proveedor As String, ByVal wDescProveedor As String, Optional ByVal OrdenPago As String = "", Optional ByVal EsPorTransferencia As Boolean = False, Optional ByVal wFechasTransferencias As String = "", Optional ByVal PorTransferenciaYCheques As Boolean = False, Optional ByVal HayECheques As Boolean = False, Optional ByVal FechasECheques As String = "", Optional ByVal TipoOrd As Integer = 0)

        If Proveedor.Trim = "" Then Exit Sub
        If EsPorTransferencia And Trim(OrdenPago) = "" Then Exit Sub

    Dim cn As SqlConnection = New SqlConnection()
    Dim cm As SqlCommand = New SqlCommand("SELECT ISNULL(MailOP, '') MailOP FROM Proveedor WHERE Proveedor = '" & Proveedor & "'")
    Dim dr As SqlDataReader

        Try

            cn.ConnectionString = _ConectarA()
            cn.Open()
            cm.Connection = cn

            dr = cm.ExecuteReader()

            If dr.HasRows Then

                dr.Read()

    Dim WMailOp As String = dr.Item("MailOp")

                If WMailOp.Trim = "" Then
                    WIndiceNoEnviados += 1
                    WNoEnviados(WIndiceNoEnviados, 0) = Proveedor
                    WNoEnviados(WIndiceNoEnviados, 1) = OrdenPago
                    Exit Sub
                End If

    '
    ' SACAR DESPUES. SOLO PRUEBA.
    '
    ' WMailOp = "sistemas@surfactan.com.ar"

    Dim WBody = ""

                If EsPorTransferencia Then

                    WBody = "Informamos que durante el transcurso del día de hoy, PELLITAL S.A. le realizará una transferencia"

                    If wFechasTransferencias.Trim <> "" Then

                        If wFechasTransferencias.Split(",").Count > 1 Then
                            WBody &= " con las siguientes fechas: "
                        Else
                            WBody &= " con fecha: "
                        End If

                        WBody &= "<strong>" & wFechasTransferencias & "</strong>"

                    End If

                    If PorTransferenciaYCheques Then
    'WBody &= "." & "<br/>" & "<br/>" & "Así mismo, tiene Cheque(s) para retirar por nuestras oficinas <em>(Malvinas Argentinas 4495, B1644CAQ Victoria, Buenos Aires)</em>, a partir del día <strong>" & txtAPartirFecha.Text & "</strong> los <strong>Martes y Jueves</strong> en el horario de <strong>14:00 a 17:00 hs.</strong>"
                        WBody &= "." & "<br/>" & "<br/>" & "Así mismo, tiene Cheque(s) para retirar por nuestras oficinas <em>(Tucumán 3475, B1644CAQ Victoria, Buenos Aires)</em>, a partir de la <strong>semana próxima</strong> los <strong>Martes y Jueves</strong> en el horario de <strong>08:00 a 15:00 hs.</strong>"
                    Else
                        WBody &= "." & "<br/>" & "<br/>" & "Adjuntamos Orden de Pago y retenciones si correspondiesen."
                    End If

                    If HayECheques Then

                        WBody &= " y a través de Cheque(s) Electrónico(s)"

                        If FechasECheques.Trim <> "" Then

                            If FechasECheques.Split(",").Count > 1 Then
                                WBody &= " con las siguientes fechas: "
                            Else
                                WBody &= " con fecha: "
                            End If

                            WBody &= "<strong>" & FechasECheques.TrimEnd(",") & "</strong>"

                        End If

                    End If

                ElseIf HayECheques Then

                    WBody = "Informamos que en el día de la fecha, PELLITAL S.A. le ha realizado un pago a través de Cheque(s) Electrónico(s)"

                    If FechasECheques.Trim <> "" Then

                        If FechasECheques.Split(",").Count > 1 Then
                            WBody &= " con las siguientes fechas: "
                        Else
                            WBody &= " con fecha: "
                        End If

                        WBody &= "<strong>" & FechasECheques & "</strong>"

                    End If

                    If PorTransferenciaYCheques Then
                        WBody &= "." & "<br/>" & "<br/>" & "Además tiene Cheque(s) para retirar por nuestras oficinas <em>(Tucumán 3475, B1644CAQ Victoria, Buenos Aires)</em>, a partir de la <strong>semana próxima</strong>, los <strong>Martes y Jueves</strong> en el horario de <strong>08:00 a 15:00 hs.</strong>"
                    Else
                        WBody &= "." & "<br/>" & "<br/>" & "Adjuntamos Orden de Pago y retenciones si correspondiesen."
                    End If

                Else

                    WBody = "Informamos que se encuentra a su disposición un pago que podrá ser retirado por nuestras oficinas <em>(Tucumán 3475, B1644CAQ Victoria, Buenos Aires)</em>, a partir de la <strong>semana próxima</strong>, los <strong>Martes y Jueves</strong> en el horario de <strong>08:00 a 15:00 hs.</strong>"

                    If TipoOrd = 2 Then ' Si es anticipo.
                        WMailOp = "juanfs@surfactan.com.ar;mlarias@surfactan.com.ar;"
                    End If

                End If

                If Trim(wDescProveedor) <> "" Then
                    WBody = "Sres. <strong>" & wDescProveedor.Trim.ToUpper & "</strong> <br/>" & "<br/>" & WBody
                End If

    'Select Case Proveedor
    '    Case "10167878480", "10000000100", "10071081483", "10069345023", "10066352912"
    '        WBody = WBody & "<br/>" & "<br/>" & "En caso de cualquier consulta, por favor dirigirla a <strong><em>fgmonti@surfactan.com.ar</em></strong>"
    'End Select

    Dim WAdjuntos As New List(Of String)

                If EsPorTransferencia And Not PorTransferenciaYCheques Then
                    WAdjuntos = _PrepararAdjuntos(OrdenPago)
                End If

                For Each wAdjunto As String In WAdjuntos
                    If Not File.Exists(wAdjunto) Then
                        If Not WPorComando Then
                            Throw New System.Exception("No existe el archivo " & wAdjunto)
                        Else
                            Exit Sub
                        End If
                    End If
                Next

    Dim WAsunto As String = "ORDEN DE PAGO - PELLITAL S.A. - "

                If TipoOrd = 2 Then ' Si es Anticipo
    'WBCC &= "svitale@pellital.com.ar;"

                    WAsunto = "ANTICIPO DE PAGO - PELLITAL S.A. - "

                End If

                _EnviarEmail(WMailOp, WBCC, WAsunto, WBody, WAdjuntos.ToArray)

                If WPorComando Then
    'WBCC = "svitale@pellital.com.ar;"
                End If

                _MarcarOPComoEnviada(OrdenPago)

            End If

        Catch ex As System.Exception
            If Not WPorComando Then Throw New System.Exception("Hubo un problema al querer procesar el envío de mail por OP Disponible." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

    End Sub

    Private Function _PrepararAdjuntos(ByVal ordenPago As String) As List(Of String)
        Dim WAdjuntos As New List(Of String)

        If Val(ordenPago) <> 0 Then

            Dim cn As SqlConnection = New SqlConnection()
            Dim cm As SqlCommand = New SqlCommand("SELECT Orden FROM Pagos WHERE Orden = '" & ordenPago & "' And Renglon IN ('01', '1')")
            Dim dr As SqlDataReader

            Try

                cn.ConnectionString = _ConectarA()
                cn.Open()
                cm.Connection = cn

                dr = cm.ExecuteReader()

                If dr.HasRows Then
                    dr.Read()

                    With New Pagos
                        .WindowState = FormWindowState.Minimized
                        .GenerarPDF = True
                        .Show(Me)
                        .txtOrdenPago.Text = ordenPago
                        .txtOrdenPago_KeyDown(Nothing, New KeyEventArgs(Keys.Enter))
                        .btnImprimir.PerformClick()
                        .Close()
                    End With

                    For Each o As String In Directory.GetFiles("C:/ImpreOrdenPagoTemp", ordenPago & "OrdenPago*")
                        WAdjuntos.Add(o)
                    Next
                    'WAdjuntos.Add("C:/ImpreOrdenPagoTemp/" & ordenPago & "OrdenPago.pdf")

                End If

            Catch ex As System.Exception
                If Not WPorComando Then Throw New System.Exception("Hubo un problema al querer consultar la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
            Finally

                dr = Nothing
                cn.Close()
                cn = Nothing
                cm = Nothing

            End Try

        End If

        Return WAdjuntos
    End Function

    Private Sub _EnviarEmail(ByVal _to As String, ByVal _bcc As String, ByVal _subject As String, ByVal _body As String, ByVal _adjuntos() As String)
        Dim _Outlook As New Application

        Try
            Dim _Mail As MailItem = _Outlook.CreateItem(OlItemType.olMailItem)

            Dim WAC As Account = Nothing

            For Each a As Account In _Outlook.Session.Accounts

                If _EsPellital() Then
                    If a.DisplayName = "svitale@pellital.com.ar" Then
                        WAC = a
                        Exit For
                    End If
                Else
                    If a.DisplayName = "recepcion@surfactan.com.ar" Then
                        WAC = a
                        Exit For
                    End If
                End If

            Next

            With _Mail

                '
                ' (NO BORRAR) Obtenemos la Instancia de Inspector para que nos agrege la firma que se encuentra definida por defecto.
                '
                ' ReSharper disable once UnusedVariable
                Dim WInspector = .GetInspector

                .To = _to
                .BCC = _bcc
                .Subject = _subject

                If WAC IsNot Nothing Then .SendUsingAccount = WAC

                '.Body = _body
                Dim WFirmaAct As String = ""
                'WFirmaAct &= "<br/>" & "<h2><u><strong>CRONOGRAMA DE PRÓXIMAS ACTIVIDADES</strong></u></h2>"
                'WFirmaAct &= "<h4>" & "<p>- Viernes 20/12/2019 y 27/12/2019, los pagos se realizarán en forma normal.</p>"
                'WFirmaAct &= "" & "<p>- Los días 30/12/2019 y 31/12/2019, <strong>SURFACTAN</strong> no tendrá actividades.</p>"
                '  WFirmaAct &= "" & "<p>- Los pagos del 03/01/2020, se trasladan al día 10/01/2020.</p></h4>"

                If _EsPellital() Then
                    .HTMLBody = "<p>" & _body & "</p>" & "<br/><br/><p><strong>Atentamente</strong><br/>PELLITAL S.A</p>" & WFirmaAct & .HTMLBody
                Else
                    .HTMLBody = "<p>" & _body & "</p>" & "<br/><br/><p><strong>Atentamente</strong><br/>SURFACTAN S.A</p>" & WFirmaAct & .HTMLBody
                End If

                For Each adjunto As String In _adjuntos
                    If Trim(adjunto) <> "" Then
                        .Attachments.Add(adjunto)
                    End If
                Next

                .Send()
                '.Display()

            End With

            _Mail = Nothing

        Catch ex As System.Exception
            If Not WPorComando Then Throw New System.Exception("Ocurrió un problema al querer enviar Aviso de Orden de Pago disponible." & vbCrLf & vbCrLf & " Motivo: " & ex.Message)
        Finally
            _Outlook = Nothing
        End Try

    End Sub


    Private Sub txtDesde_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtDesde.KeyDown, txtAPartirFecha.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txtDesde.Text.Replace("/", "")) = "" Or (rbEntreFechas.Checked And txtDesde.Text.Replace(" ", "").Length < 10) Then : Exit Sub : End If

            txtHasta.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtDesde.Text = ""
        End If

    End Sub

    Private Sub txtHasta_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtHasta.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txtHasta.Text.Replace("/", "")) = "" Or (rbEntreFechas.Checked And txtHasta.Text.Replace(" ", "").Length < 10) Then : Exit Sub : End If

            txtDesde.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtHasta.Text = ""
        End If

    End Sub

End Class