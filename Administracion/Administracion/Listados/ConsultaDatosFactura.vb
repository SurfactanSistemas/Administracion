Imports System.Data.SqlClient
Imports ClasesCompartidas
Imports System.Text.RegularExpressions

Public Class ConsultaDatosFactura


    Private _NroInterno As String

    Public Property NroInterno() As String
        Get
            Return _NroInterno
        End Get
        Set(ByVal value As String)
            _NroInterno = value

            _LimpiarCampos()

            _ObtenerDatosDeNroInterno(value)
        End Set
    End Property

    Private Sub _LimpiarCampos()
        For Each Control As TextBox In Me.Panel2.Controls.OfType(Of TextBox)()
            Control.Text = ""
        Next

        For Each Control As MaskedTextBox In Me.Panel2.Controls.OfType(Of MaskedTextBox)()
            Control.Clear()
        Next

        DGVArticulos.Rows.Clear()

    End Sub

    Private Sub _ObtenerDatosDeNroInterno(ByVal _NroInterno)
        Dim XProveedor As String

        Dim cs As String = "Data Source=193.168.0.7;Initial Catalog=#EMPRESA#;User ID=usuarioadmin; Password=usuarioadmin"
        Dim XCs As String = ""
        Dim _Empresas As New List(Of String) From {"SurfactanSA", "surfactan_II", "Surfactan_III", "Surfactan_IV", "Surfactan_V", "Surfactan_VI", "Surfactan_VII"}

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT ic.Numero, ic.Fecha, ic.Remito, ic.Proveedor from IvaComp as ic WHERE ic.NroInterno = '" & _NroInterno & "'")
        Dim dr As SqlDataReader

        ' Extraemos datos de proveedor y remito.
        SQLConnector.conexionSql(cn, cm)

        Try

            dr = cm.ExecuteReader()

            With dr
                If .HasRows Then

                    .Read()

                    txtFactura.Text = .Item("Numero").ToString
                    txtFechaFactura.Text = .Item("Fecha").ToString
                    txtRemito.Text = Trim(Regex.Replace(dr.Item("Remito").ToString, "\,\d+", ""))
                    XProveedor = .Item("Proveedor").ToString

                End If
            End With

        Catch ex As Exception
            MsgBox("Hubo un problema al querer consultar la Base de Datos.", MsgBoxStyle.Critical)
        Finally
            cn.Close()
        End Try

        ' Busco el informe segun empresa.
        For Each _Empresa As String In _Empresas
            XCs = cs.Replace("#EMPRESA#", _Empresa)

            Try

                cn.ConnectionString = XCs
                cn.Open()
                cm.Connection = cn
                cm.CommandText = "SELECT i.Informe, i.Fecha, i.Orden, p.Nombre FROM Informe as i, Proveedor as p WHERE i.Remito = '" & txtRemito.Text & "' AND i.Proveedor = '" & XProveedor & "' AND i.Proveedor = p.Proveedor"

                dr = cm.ExecuteReader()

                With dr
                    If .HasRows Then

                        .Read()

                        txtInformeRecepcion.Text = Trim(.Item("Informe").ToString)
                        txtFechaInformeRecepcion.Text = .Item("Fecha").ToString
                        txtOrdenCompra.Text = Trim(.Item("Orden").ToString)
                        txtNombreProveedor.Text = Trim(.Item("Nombre").ToString)

                        Exit For
                    Else
                        XCs = ""
                    End If
                End With

            Catch ex As Exception
                MsgBox("Hubo un problema al querer consultar la Base de Datos.", MsgBoxStyle.Critical)
                XCs = ""
                Exit For
            Finally
                cn.Close()
            End Try

        Next

        ' Con el connection string donde conseguimos el informe, hacemos la consulta para extraer los detalles de los articulos.

        If XCs = "" Then
            Exit Sub
        End If

        ' Si el informe tiene numero de Orden, traemos los datos.

        If txtOrdenCompra.Text <> "" Then

            Try

                cn.ConnectionString = XCs
                cn.Open()
                cm.Connection = cn
                cm.CommandText = "SELECT Fecha, Carpeta FROM Orden WHERE Orden = '" & txtOrdenCompra.Text & "'"

                dr = cm.ExecuteReader()

                With dr
                    If .HasRows Then

                        .Read()
                        txtFechaOrdenCompra.Text = .Item("Fecha").ToString
                        txtCarpeta.Text = .Item("Carpeta").ToString

                    End If
                End With

            Catch ex As Exception
                MsgBox("Hubo un problema al querer consultar la Base de Datos.", MsgBoxStyle.Critical)
                XCs = ""
            Finally
                cn.Close()
            End Try

        End If

        If XCs = "" Then
            Exit Sub
        End If

        ' Extraemos los detalles de los articulos y los listamos.
        Try

            cn.ConnectionString = XCs
            cn.Open()
            cm.Connection = cn
            cm.CommandText = "SELECT i.Orden, i.Articulo, a.Descripcion, i.Cantidad, o.Precio FROM Informe as i, Orden as o, Articulo as a WHERE i.Informe = '" & Trim(txtInformeRecepcion.Text) & "' AND i.Orden = o.Orden  AND i.Articulo = a.Codigo AND i.Articulo = o.Articulo"

            dr = cm.ExecuteReader()

            If dr.HasRows Then
                Dim i As Integer = 0
                Do While dr.Read()
                    i = DGVArticulos.Rows.Add
                    With DGVArticulos.Rows(i)
                        .Cells(0).Value = dr.Item("Orden")
                        .Cells(1).Value = dr.Item("Articulo")
                        .Cells(2).Value = dr.Item("Descripcion")
                        .Cells(3).Value = formatonumerico(dr.Item("Cantidad"), "######0.#0", ".")
                        .Cells(4).Value = formatonumerico(dr.Item("Precio"), "######0.#0", ".")

                    End With

                Loop

            End If

        Catch ex As Exception
            MsgBox("Hubo un problema al querer consultar la Base de Datos.", MsgBoxStyle.Critical)
            XCs = ""
        Finally
            cn.Close()
        End Try

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub ConsultaDatosFactura_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        With DGVArticulos
            _AlinearDerecha(.Columns(0))
            _AlinearDerecha(.Columns(3))
            _AlinearDerecha(.Columns(4))
        End With

    End Sub

    Private Sub _AlinearDerecha(ByRef columna As DataGridViewColumn)
        columna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    End Sub
End Class