Imports System.Configuration
Imports System.IO
Imports ConsultasVarias.Clases
Imports CrystalDecisions.Shared
Imports Conexion = ConsultasVarias.Clases.Conexion

Public Class Login

    Private WAbiertoporComando As Boolean = False

    Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
        Close()
    End Sub

    Private Sub Login_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load

        Dim tabla As New DataTable
        With tabla
            .Columns.Add("Empresa")
            .Columns.Add("Base")
            .Rows.Add("SURFACTAN S.A.", "SurfactanSa")
            .Rows.Add("PELLITAL S.A.", "Pellital_III")
        End With

        With cmbEntity
            .DataSource = tabla
            .DisplayMember = "Empresa"
            .ValueMember = "Base"
            .SelectedIndex = 0
        End With

        txtPsw.Text = ""

        _ProcesarLlamadaPorComando(Environment.GetCommandLineArgs)

    End Sub

    Public Sub _ProcesarLlamadaPorComando(ByVal Datos As String())

        Try
            '
            ' Chequeamos que se haya abierto por linea de comandos.
            '
            If Datos.Length > 1 Then

                Dim WTipoLlamada As Integer = Datos(1)

                Select Case WTipoLlamada
                    Case 1

                        Dim WTipo As String = Datos(2)
                        Dim WNumero As String = Datos(3)
                        Dim WAnio As String = Datos(4)

                        With New NuevoSac(WTipo, WNumero, WAnio, True)
                            .Show()
                        End With

                    Case 2 ' Envío de SAC por Mail

                        Dim WTipo As String = Datos(2)
                        Dim WNumero As String = Datos(3)
                        Dim WAnio As String = Datos(4)
                        Dim WDirecciones As String = Datos(5)
                        Dim WAsunto As String = Datos(6)
                        Dim WCuerpoMsj As String = Datos(7)

                        Dim frm As New ConsultasVarias.VistaPrevia

                        With frm

                            .Reporte = New NuevoSACAmbos

                            .Formula = "{CargaSac.Tipo} = " & WTipo & " And {CargaSac.Numero} = " & WNumero & " And {CargaSac.Ano} = " & WAnio & ""

                        End With

                        Conexion.EmpresaDeTrabajo = "SurfactanSa"
                        ConsultasVarias.Clases.Helper._ExportarReporte(frm, Enumeraciones.FormatoExportacion.PDF, WTipo & WNumero & WAnio & ".pdf", "C:\TempReclamos\")

                        If File.Exists("C:\TempReclamos\" & WTipo & WNumero & WAnio & ".pdf") Then
                            ConsultasVarias.Clases.Helper._EnviarEmail(WDirecciones, WAsunto, WCuerpoMsj, {"C:\TempReclamos\" & WTipo & WNumero & WAnio & ".pdf"}, False)
                        Else
                            MsgBox("No se encontró el archivo " & "C:\TempReclamos\" & WTipo & WNumero & WAnio & ".pdf")
                        End If

                    Case 3

                        Dim WNumero As String = Datos(2)
                        Dim WDirecciones As String = Datos(3)
                        Dim WAsunto As String = Datos(4)
                        Dim WCuerpoMsj As String = Datos(5)
                        Dim WEnviarAutomatico As Boolean = True

                        If Datos.Length > 6 Then
                            WEnviarAutomatico = Val(Datos(6)) <> 1
                        End If

                        Dim WNumeroTipo = ""
                        Dim WAnio = ""

                        Conexion.EmpresaDeTrabajo = "SurfactanSa"

                        Dim WRecl As DataRow = GetSingle("SELECT NumeroTipo, Ano = RIGHT(ISNULL(Fecha, '00/00/0000'), 4) FROM CentroReclamos WHERE numero = '" & WNumero & "'")

                        If WRecl IsNot Nothing Then
                            WNumeroTipo = OrDefault(WRecl.Item("NumeroTipo"), "")
                            WAnio = OrDefault(WRecl.Item("Ano"), "")
                        End If

                        Dim frm As New ConsultasVarias.VistaPrevia

                        With frm

                            .Reporte = New ReclamoClienteAvisoMail

                            .Formula = "{CentroReclamos.Numero} = " & WNumero & ""

                        End With

                        '
                        ' De aca, van a venir los mails de los responsables. Agregamos las que faltan.
                        '
                        WDirecciones = _DefinirMailsExtras(WNumero, WDirecciones)

                        ConsultasVarias.Clases.Helper._ExportarReporte(frm, Enumeraciones.FormatoExportacion.PDF, WNumeroTipo & " - " & WAnio & " Reclamo.pdf", "C:\TempReclamos\")

                        If File.Exists("C:\TempReclamos\" & WNumeroTipo & " - " & WAnio & " Reclamo.pdf") Then
                            ConsultasVarias.Clases.Helper._EnviarEmail(WDirecciones, WAsunto, WCuerpoMsj, {"C:\TempReclamos\" & WNumeroTipo & " - " & WAnio & " Reclamo.pdf"}, WEnviarAutomatico)
                        Else
                            MsgBox("No se encontró el archivo " & "C:\TempReclamos\" & WNumero & "Reclamo.pdf")
                        End If
                    Case 4

                        Dim WNumero As String = Datos(2)
                        Dim WDirecciones As String = "" 'Datos(3)
                        Dim WAsunto As String = "" 'Datos(4)
                        Dim WCuerpoMsj As String = "" ' Datos(5)

                        Dim frm As New ConsultasVarias.VistaPrevia

                        Dim WTipoProd, WNumeroINC, WArticulo, WNombreComercial, WProveedor, WLoteProv, WLaudo, WEmpresa, WOrden, WReferencia, WTitulo As String
                        WNumeroINC = ""

                        Clases.Conexion.EmpresaDeTrabajo = "SurfactanSa"

                        Dim WINC As DataRow = GetSingle("SELECT Numero, Orden, TipoProd, Producto, Referencia, Titulo, Proveedor, Lote, Empresa FROM CargaIncidencias WHERE Incidencia  = '" & WNumero & "'")

                        If WINC IsNot Nothing Then
                            WNumeroINC = OrDefault(WINC.Item("Numero"), "")
                            WTipoProd = UCase(OrDefault(WINC.Item("TipoProd"), "T"))
                            WProveedor = UCase(OrDefault(WINC.Item("Proveedor"), ""))
                            WLaudo = UCase(OrDefault(WINC.Item("Lote"), ""))
                            WArticulo = UCase(OrDefault(WINC.Item("Producto"), ""))
                            WEmpresa = UCase(OrDefault(WINC.Item("Empresa"), ""))
                            WOrden = UCase(OrDefault(WINC.Item("Orden"), ""))
                            WReferencia = Trim(OrDefault(WINC.Item("Referencia"), ""))
                            WTitulo = Trim(OrDefault(WINC.Item("Titulo"), ""))

                            WLoteProv = ""
                            WNombreComercial = ""

                            Dim WDescProv As String = ""

                            Dim WProv As DataRow = GetSingle("SELECT Nombre FROM Proveedor WHERE Proveedor = '" & WProveedor & "'")

                            If WProv IsNot Nothing Then WDescProv = Trim(OrDefault(WProv.Item("Nombre"), ""))

                            Dim WArt As DataRow = GetSingle("SELECT RTRIM(a.Descripcion) DescMP, RTRIM(m.Descripcion) NombreComercial FROM Articulo a LEFT OUTER JOIN Marcas m ON m.Articulo = a.Codigo And m.Proveedor = '" & WProveedor & "' WHERE a.Codigo = '" & WArticulo & "'")

                            If WArt IsNot Nothing Then

                                WNombreComercial = Trim(OrDefault(WArt.Item("NombreComercial"), ""))

                                If WNombreComercial.Trim = "" Then WNombreComercial = Trim(OrDefault(WArt.Item("DescMP"), ""))

                            End If

                            If Val(WEmpresa) > 0 And Val(WOrden) > 0 Then

                                Dim WLotes As DataRow = GetSingle("SELECT LoteProvInforme = RTRIM(i.Lote1) + '/' + RTRIM(i.Lote2) + '/' + RTRIM(i.Lote3) + '/' +RTRIM(i.Lote4) + '/' + RTRIM(i.Lote5) , l.PartiOri LoteProvLaudo FROM Informe i LEFT OUTER JOIN Laudo l ON l.Articulo = i.Articulo And i.Orden = l.Orden WHERE i.Articulo = '" & WArticulo & "' And i.Orden = '" & WOrden & "' And l.Laudo = '" & WLaudo & "'", Clases.Conexion.DeterminarSegunIDIDBasePara(Val(WEmpresa)))

                                If WLotes IsNot Nothing Then
                                    If Trim(OrDefault(WLotes.Item("LoteProvLaudo"), "")) <> "" Then
                                        WLoteProv = Trim(OrDefault(WLotes.Item("LoteProvLaudo"), ""))
                                    ElseIf Trim(OrDefault(WLotes.Item("LoteProvInforme"), "")) <> "" Then

                                        For Each s As String In WLotes.Item("LoteProvInforme").ToString().Split("/")
                                            If s.Trim <> "" Then WLoteProv &= s & "/"
                                        Next

                                        WLoteProv = WLoteProv.TrimEnd("/")

                                        'WLoteProv = Trim(OrDefault(WLotes.Item("LoteProvLaudo"), ""))
                                    End If

                                End If

                            End If

                            ExecuteNonQueries("UPDATE CargaIncidencias SET NombreComercial = '" & WNombreComercial & "', LoteProv = '" & WLoteProv & "', DescProveedor = '" & WDescProv & "' WHERE Incidencia = '" & WNumero & "'")

                        End If

                        ExecuteNonQueries("UPDATE CargaIncidencias SET ImpreDescProd = CASE inc.TipoProd WHEN 'T' THEN LEFT(t.Descripcion, 100) WHEN 'M' THEN LEFT(a.Descripcion, 100) ELSE '' END FROM CargaIncidencias inc LEFT OUTER JOIN Terminado t ON t.Codigo = inc.Producto LEFT OUTER JOIN Articulo a ON a.Codigo = inc.Producto")

                        WAsunto = "Carga de Informe de No Conformidad - Nro. " & WNumeroINC
                        WCuerpoMsj = "Se inició un Informe de No Conformidad :" & _
                                " : " & WNumeroINC & "" & _
                                " Referencia : " & WReferencia & _
                                " Titulo : " & WTitulo

                        With frm
                            .Reporte = New ReporteINCIndividual
                            .Formula = "{CargaIncidencias.Incidencia} = " & WNumero

                            .Reporte.SetParameterValue("MostrarPosiblesUsos", 1)
                            .Reporte.SetParameterValue("MostrarAcciones", 0)

                            Dim WNombreArchivo = String.Format("INC {0} - {1}", WNumeroINC.PadLeft(4, "0"), Date.Now.ToString("dd-MM-yyyy"))

                            Dim WRuta = "C:/tempIndice/"

                            WNombreArchivo &= ".pdf"

                            WDirecciones = "ebiglieri@surfactan.com.ar; calidad@surfactan.com.ar; wbarosio@surfactan.com.ar; calidad2@surfactan.com.ar; isocalidad@surfactan.com.ar;juanfs@surfactan.com.ar; lsantos@surfactan.com.ar; drodriguez@surfactan.com.ar; iburgos@surfactan.com.ar; ctomaszek@surfactan.com.ar; mlarias@surfactan.com.ar; mescames@surfactan.com.ar; supcc@surfactan.com.ar; svarela@surfactan.com.ar; textil@surfactan.com.ar; hfondeville@surfactan.com.ar; hsuarez@surfactan.com.ar;gferreyra@surfactan.com.ar;"

                            If Not Directory.Exists(WRuta) Then Directory.CreateDirectory(WRuta) 'Directory.Delete(WRuta, True)

                            If File.Exists(WRuta & WNombreArchivo) Then File.Delete(WRuta & WNombreArchivo)

                            Conexion.EmpresaDeTrabajo = "SurfactanSa"
                            ConsultasVarias.Clases.Helper._ExportarReporte(frm, Enumeraciones.FormatoExportacion.PDF, WNombreArchivo, WRuta)

                            If File.Exists(WRuta & WNombreArchivo) Then
                                ConsultasVarias.Clases.Helper._EnviarEmail(WDirecciones, WAsunto, WCuerpoMsj, {WRuta & WNombreArchivo}, True)
                            Else
                                MsgBox("No se encontró el archivo " & WRuta & WNombreArchivo)
                            End If

                        End With

                        If WTipoProd = "M" Then

                            With frm
                                .Reporte = New ReporteINCIndividualML
                                .Formula = "{CargaIncidencias.Incidencia} = " & WNumero

                                .Reporte.SetParameterValue("MostrarPosiblesUsos", 0)
                                .Reporte.SetParameterValue("MostrarAcciones", 0)

                                Dim WNombreArchivo = String.Format("Reclamo a Proveedor INC {0} - {1}", WNumeroINC.PadLeft(4, "0"), Date.Now.ToString("dd-MM-yyyy"))

                                Dim WRuta = "C:/tempIndice/"

                                WNombreArchivo &= ".pdf"

                                WDirecciones = "mlarias@surfactan.com.ar;gferreyra@surfactan.com.ar;"

                                If Not Directory.Exists(WRuta) Then Directory.CreateDirectory(WRuta) 'Directory.Delete(WRuta, True)

                                If File.Exists(WRuta & WNombreArchivo) Then File.Delete(WRuta & WNombreArchivo)

                                Conexion.EmpresaDeTrabajo = "SurfactanSa"
                                ConsultasVarias.Clases.Helper._ExportarReporte(frm, Enumeraciones.FormatoExportacion.PDF, WNombreArchivo, WRuta)

                                If File.Exists(WRuta & WNombreArchivo) Then
                                    ConsultasVarias.Clases.Helper._EnviarEmail(WDirecciones, WAsunto, WCuerpoMsj, {WRuta & WNombreArchivo}, True)
                                Else
                                    MsgBox("No se encontró el archivo " & WRuta & WNombreArchivo)
                                End If

                            End With

                        End If

                    Case 5

                        Dim WNumero As String = Datos(2)
                        Dim WNumeroTipo As String = ""
                        Dim WAnio As String = ""

                        Conexion.EmpresaDeTrabajo = "SurfactanSa"

                        Dim WRecl As DataRow = GetSingle("SELECT NumeroTipo, Ano = RIGHT(ISNULL(Fecha, '00/00/0000'), 4) FROM CentroReclamos WHERE numero = '" & WNumero & "'")

                        If WRecl IsNot Nothing Then
                            WNumeroTipo = OrDefault(WRecl.Item("NumeroTipo"), "")
                            WAnio = OrDefault(WRecl.Item("Ano"), "")
                        End If

                        Dim frm As New ConsultasVarias.VistaPrevia

                        With frm

                            .Reporte = New ReclamoClienteAvisoMailII

                            .Formula = "{CentroReclamos.Numero} = " & WNumero & ""

                            .Exportar(String.Format("Reclamo de Cliente Nro. {0}-{1} - {2}.pdf", WNumeroTipo, WAnio, Date.Now.ToString("dd-MM-yyyy")), ExportFormatType.PortableDocFormat, "")

                        End With

                        '
                        ' De aca, van a venir los mails de los responsables. Agregamos las que faltan.
                        '
                        'ConsultasVarias.Clases.Helper._ExportarReporte(frm, Enumeraciones.FormatoExportacion.PDF, WNumero & "Reclamo.pdf", "C:\TempReclamos\")

                        'If File.Exists("C:\TempReclamos\" & WNumero & "Reclamo.pdf") Then
                        ' ConsultasVarias.Clases.Helper._EnviarEmail(WDirecciones, WAsunto, WCuerpoMsj, {"C:\TempReclamos\" & WNumero & "Reclamo.pdf"}, True)
                        ' Else
                        ' MsgBox("No se encontró el archivo " & "C:\TempReclamos\" & WNumero & "Reclamo.pdf")
                        ' End If
                    Case 6

                        Dim WNumero As String = Datos(2)
                        Dim WDirecciones As String = Datos(3)
                        Dim WAsunto As String = Datos(4)
                        Dim WCuerpoMsj As String = Datos(5)
                        Dim WEnviarAutomatico As Boolean = False
                        Dim WNumeroTipo = ""
                        Dim WAnio = ""

                        Conexion.EmpresaDeTrabajo = "SurfactanSa"

                        Dim WRecl As DataRow = GetSingle("SELECT NumeroTipo, Ano = RIGHT(ISNULL(Fecha, '00/00/0000'), 4) FROM CentroReclamos WHERE numero = '" & WNumero & "'")

                        If WRecl IsNot Nothing Then
                            WNumeroTipo = OrDefault(WRecl.Item("NumeroTipo"), "")
                            WAnio = OrDefault(WRecl.Item("Ano"), "")
                        End If

                        Dim frm As New ConsultasVarias.VistaPrevia

                        With frm

                            .Reporte = New ReclamoClienteAvisoMailII

                            .Formula = "{CentroReclamos.Numero} = " & WNumero & ""

                        End With

                        '
                        ' De aca, van a venir los mails de los responsables. Agregamos las que faltan.
                        '
                        WDirecciones = "" '_DefinirMailsExtras(WNumero, WDirecciones)

                        ConsultasVarias.Clases.Helper._ExportarReporte(frm, Enumeraciones.FormatoExportacion.PDF, WNumeroTipo & " - " & WAnio & " Reclamo.pdf", "C:\TempReclamos\")

                        If File.Exists("C:\TempReclamos\" & WNumeroTipo & " - " & WAnio & " Reclamo.pdf") Then
                            ConsultasVarias.Clases.Helper._EnviarEmail(WDirecciones, WAsunto, WCuerpoMsj, {"C:\TempReclamos\" & WNumeroTipo & " - " & WAnio & " Reclamo.pdf"}, WEnviarAutomatico)
                        Else
                            MsgBox("No se encontró el archivo " & "C:\TempReclamos\" & WNumero & "Reclamo.pdf")
                        End If

                    Case 7

                        Dim WClaveSAC As String = Datos(3)
                        Dim WNumero As String = Datos(2)
                        Dim WNumeroTipo As String = ""
                        Dim WAnio As String = ""

                        Conexion.EmpresaDeTrabajo = "SurfactanSa"

                        Dim WRecl As DataRow = GetSingle("SELECT NumeroTipo, Ano = RIGHT(ISNULL(Fecha, '00/00/0000'), 4) FROM CentroReclamos WHERE numero = '" & WNumero & "'")

                        If WRecl IsNot Nothing Then
                            WNumeroTipo = OrDefault(WRecl.Item("NumeroTipo"), "")
                            WAnio = OrDefault(WRecl.Item("Ano"), "")
                        End If

                        Dim frm As New ConsultasVarias.VistaPrevia
                        Dim WRutaArchRelacSAC As String = ConfigurationManager.AppSettings("ARCHIVOS_RELACIONADOS") & "SAC_" & WClaveSAC

                        If Not Directory.Exists(WRutaArchRelacSAC) Then
                            Directory.CreateDirectory(WRutaArchRelacSAC)
                        End If

                        With frm

                            .Reporte = New ReclamoClienteAvisoMailII

                            .Formula = "{CentroReclamos.Numero} = " & WNumero & ""

                            .Exportar(String.Format("Reclamo de Cliente Nro. {0}-{1} - {2}.pdf", WNumeroTipo, WAnio, Date.Now.ToString("dd-MM-yyyy")), ExportFormatType.PortableDocFormat, WRutaArchRelacSAC)

                        End With
                End Select

                btnCancel_Click(Nothing, Nothing)


            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            btnCancel_Click(Nothing, Nothing)
        End Try
    End Sub

    Private Function _DefinirMailsExtras(ByVal WNumero As String, ByVal WDirecciones As String) As String

        '
        ' Completamos los datos de las direcciones cuando lleguen.
        '
        WDirecciones = ""
        '
        ' Definimos los mails obligatorios, según tipo Producto Terminado indicado en Reclamo.
        '
        Dim WReclamo As DataRow = GetSingle("SELECT Producto, Cliente FROM CentroReclamos WHERE Numero = '" & WNumero & "'")

        If WReclamo Is Nothing Then
            Return WDirecciones
        End If

        Dim WTerminado As String = OrDefault(WReclamo.Item("Producto"), "")

        Dim WTipoProd As String = _DeterminarTipoProd(WTerminado)

        Select Case WTipoProd
            Case "PG"
                For Each d As String In {"drodriguez@surfactan.com.ar", "ctomaszek@surfactan.com.ar"}
                    If Not WDirecciones.Contains(d) Then WDirecciones &= d & ";"
                Next
            Case "CO"
                For Each d As String In {"hfondeville@surfactan.com.ar", "textil@surfactan.com.ar", "hsuarez@surfactan.com.ar"}
                    If Not WDirecciones.Contains(d) Then WDirecciones &= d & ";"
                Next
            Case "FA"
                For Each d As String In {"drodriguez@surfactan.com.ar", "dsuarez@surfactan.com.ar", "msosa@surfactan.com.ar", "scoppiello@surfactan.com.ar", "svarela@surfactan.com.ar", "supcc@surfactan.com.ar"}
                    If Not WDirecciones.Contains(d) Then WDirecciones &= d & ";"
                Next
            Case Else ' El resto de los Productos los tomamos como Químicos.
                For Each d As String In {"drodriguez@surfactan.com.ar", "dsuarez@surfactan.com.ar", "mescames@surfactan.com.ar", "hmuller@surfactan.com.ar", "svarela@surfactan.com.ar", "supcc@surfactan.com.ar"}
                    If Not WDirecciones.Contains(d) Then WDirecciones &= d & ";"
                Next
        End Select

        For Each d As String In ("ebiglieri@surfactan.com.ar; calidad2@surfactan.com.ar; calidad@surfactan.com.ar; isocalidad@surfactan.com.ar; wbarosio@surfactan.com.ar; wbarosio@gmail.com; lsantos@surfactan.com.ar; juanfs@surfactan.com.ar").Split(";")
            If Not WDirecciones.Contains(Trim(d)) Then WDirecciones &= Trim(d) & ";"
        Next

        '
        ' Busco el vendedor definido para el Cliente.
        '
        Dim WCliente As DataRow = GetSingle("SELECT Vendedor FROM Cliente WHERE Cliente = '" & OrDefault(WReclamo.Item("Cliente"), "") & "'")

        If WCliente IsNot Nothing Then
            Dim WVendedor As DataRow = GetSingle("SELECT Email1, Email2 FROM Vendedor WHERE Vendedor  = '" & OrDefault(WCliente.Item("Vendedor"), 99) & "'")

            If WVendedor IsNot Nothing Then
                If WTipoProd = "FA" Then
                    WDirecciones &= "hsein@surfactan.com.ar; grodriguez@surfactan.com.ar"
                Else

                    If Trim(OrDefault(WVendedor.Item("Email1"), "")) <> "" Then
                        If Not WDirecciones.Contains(OrDefault(WVendedor.Item("Email1"), "")) Then WDirecciones &= OrDefault(WVendedor.Item("Email1"), "")
                    End If

                    If Trim(OrDefault(WVendedor.Item("Email2"), "")) <> "" Then
                        If Not WDirecciones.Contains(OrDefault(WVendedor.Item("Email2"), "")) Then WDirecciones &= OrDefault(WVendedor.Item("Email2"), "")
                    End If

                End If
            End If

        End If

        Return WDirecciones

    End Function

    Private Function _DeterminarTipoProd(ByVal WTerminado As String) As String

        WTerminado = UCase(WTerminado)

        Dim XTipoPro = "PT"

        Dim XCodigo As Integer = Val(Mid(WTerminado, 4, 5))

        If Microsoft.VisualBasic.Left(WTerminado, 2) <> "PT" Then
            Select Case Microsoft.VisualBasic.Left(WTerminado, 2)
                Case "DY", "DS"
                    XTipoPro = "CO"
                Case "QC", "YF"
                    XTipoPro = "FA"
                Case "YQ", "YH", "YP"
                    XTipoPro = "PT"
                Case Else
                    XTipoPro = "PT"
            End Select
        Else
            If XCodigo >= 0 And XCodigo <= 999 Then
                XTipoPro = "CO"
            Else
                If XCodigo >= 11000 And XCodigo <= 12999 Then
                    XTipoPro = "CO"
                Else
                    If XCodigo >= 25000 And XCodigo <= 25999 Then
                        XTipoPro = "FA"
                    Else
                        If XCodigo >= 2300 And XCodigo <= 2399 Then
                            XTipoPro = "BI"
                        Else
                            XTipoPro = "PT"
                        End If
                    End If
                End If
            End If
        End If

        Dim ZLinea = 0
        Dim WTerm As DataRow = GetSingle("SELECT Linea FROM Terminado WHERE Codigo = '" & WTerminado & "'")

        If WTerm IsNot Nothing Then ZLinea = OrDefault(WTerm.Item("Linea"), 0)

        Select Case ZLinea
            Case 8
                XTipoPro = "PG"
            Case 10, 20, 22, 24, 25, 26, 27, 28, 29, 30
                XTipoPro = "FA"
        End Select

        Return XTipoPro
    End Function

    Private Sub btnAccept_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAccept.Click

        'Globals.empresa = cmbEntity.SelectedItem

        If txtPsw.Text.Trim = "" Then Exit Sub

        Clases.Conexion.EmpresaDeTrabajo = CType(cmbEntity.SelectedItem, DataRowView).Item("Base")

        ' Validamos la contraseña.

        If Not Clases.Conexion._Login(txtPsw.Text, 4) Then
            MsgBox("La contraseña no es correcta.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        If _EsPellital() Then
            ' En caso de ser PELLITAL, validamos que la conexion se haga desde una pc con Permisos. Los mismos se definen segun nombre de PC.

            If Not _PermisosPellitalValidos() Then

                MsgBox("No tiene los permisos necesarios para poder ingresar a esta Empresa.", MsgBoxStyle.Exclamation)

                Exit Sub

            End If

        End If

        MenuPrincipal.Show()

        Close()

    End Sub

    Private Function _PermisosPellitalValidos() As Boolean

        Dim WPermitidos() = ConfigurationManager.AppSettings("PERMISOS_PELLITAL").ToString.Split(",")
        Dim WNombrePC = getNombrePC()

        Return (From N In WPermitidos Where UCase(Trim(N)) = UCase(Trim(WNombrePC))).Any()

    End Function

    Private Sub Login_Shown(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Shown
        If WAbiertoporComando Then
            btnCancel_Click(Nothing, Nothing)
        End If
        txtPsw.Focus()
    End Sub

    Private Sub txtPsw_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtPsw.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txtPsw.Text) = "" Then : Exit Sub : End If

            btnAccept.PerformClick()

        ElseIf e.KeyData = Keys.Escape Then
            txtPsw.Text = ""
        End If

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        _ProcesarLlamadaPorComando({"", "5", "24"})
    End Sub
End Class