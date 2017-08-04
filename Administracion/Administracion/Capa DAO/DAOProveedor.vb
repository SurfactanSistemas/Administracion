Imports ClasesCompartidas
Imports System.Data.SqlClient

Public Class DAOProveedor

    Public Shared Sub agregarProveedor(ByVal proveedor As Proveedor)
        Try
            'SQLConnector.executeProcedure("alta_proveedor", proveedor.id, proveedor.razonSocial, proveedor.direccion, proveedor.localidad, _
            '                          proveedor.provincia, proveedor.codPostal, proveedor.region, proveedor.telefono, proveedor.diasPlazo, _
            '                          proveedor.email, proveedor.observaciones, proveedor.cuit, proveedor.tipo, proveedor.codIva, _
            '                          proveedor.codigoCuenta, proveedor.nombreCheque, proveedor.condicionIB1, proveedor.condicionIB2, _
            '                          proveedor.numeroIB, proveedor.porceIBProvincia, proveedor.porceIBCABA, proveedor.RawRubro, _
            '                          proveedor.numeroSEDRONAR, proveedor.vtoSEDRONAR, proveedor.categoria, proveedor.categoriaCalif, _
            '                          proveedor.vtoCategoria, proveedor.tipoInscripcionIB, proveedor.cai, proveedor.vtoCAI, _
            '                          proveedor.certificados, proveedor.vtoCertificados, proveedor.estado, proveedor.calificacion, _
            '                          proveedor.vtoCalificacion, proveedor.observacionCompleta, proveedor.cufe1, proveedor.cufe2, _
            '                          proveedor.cufe3, proveedor.dirCUFE1, proveedor.dirCUFE2, proveedor.dirCUFE3, _
            '                          proveedor.PaginaWeb(0).ToString, proveedor.contacto1(0).ToString, proveedor.contacto1(1).ToString, proveedor.contacto1(2).ToString, proveedor.contacto1(3).ToString, _
            '                          proveedor.contacto2(0).ToString, proveedor.contacto2(1).ToString, proveedor.contacto2(2).ToString, proveedor.contacto2(3).ToString, _
            '                          proveedor.contacto3(0).ToString, proveedor.contacto3(1).ToString, proveedor.contacto3(2).ToString, proveedor.contacto3(3).ToString, proveedor.cliente.id, proveedor.Inhabilitado)

            Dim ZSql, WProveedor, WNombre, WDireccion, WLocalidad, WProvincia, WPostal, WRegion, WTelefono, WDias, WEmail, WObservaciones, WCuit, WTipo, WIva, WCuenta, WNombreCheque, WCodIb, WCodIbCaba, WNroIb, WPorceIb, WPorceIbCaba, WRubro, WNroInsc, WFechaNroInsc, WCategoriaI, WCategoriaII, WFechaCategoria, WIbCiudadII, WCai, WVtoCai, WIso, WVtoIso, WEstado, WCalifica, WFechaCalifica, WObservacionesII, WCufe, WCufeII, WCufeIII, WDirCufe, WDirCufeII, WDirCufeIII, WOrdFechaCalifica, WOrdFechaCategoria, WOrdFechaNroInsc, WWdate, WPaginaWeb, WContactoNombre1, WContactoCargo1, WContactoTelefono1, WContactoEmail1, WContactoNombre2, WContactoCargo2, WContactoTelefono2, WContactoEmail2, WContactoNombre3, WContactoCargo3, WContactoTelefono3, WContactoEmail3, WClienteAsociado, WInhabilitado As String
            With proveedor
                WProveedor = .id
                WNombre = .razonSocial
                WDireccion = .direccion
                WLocalidad = .localidad
                WProvincia = .provincia
                WPostal = .codPostal
                WRegion = .region
                WTelefono = .telefono
                WDias = .diasPlazo
                WEmail = .email
                WObservaciones = .observaciones
                WCuit = .cuit
                WTipo = .tipo
                WIva = .codIva
                WCuenta = .codigoCuenta
                WNombreCheque = .nombreCheque
                WCodIb = .condicionIB1
                WCodIbCaba = .condicionIB2
                WNroIb = .numeroIB
                WPorceIb = .porceIBProvincia
                WPorceIbCaba = .porceIBCABA
                WRubro = .RawRubro
                WNroInsc = .numeroSEDRONAR
                WFechaNroInsc = .vtoSEDRONAR
                WCategoriaI = .categoria
                WCategoriaII = .categoriaCalif
                WFechaCategoria = .vtoCategoria
                WIbCiudadII = .tipoInscripcionIB
                WCai = .cai
                WVtoCai = .vtoCAI
                WIso = .certificados
                WVtoIso = .vtoCertificados
                WEstado = .estado
                WCalifica = .calificacion
                WFechaCalifica = .vtoCalificacion
                WObservacionesII = .observacionCompleta
                WCufe = .cufe1
                WCufeII = .cufe2
                WCufeIII = .cufe3
                WDirCufe = .dirCUFE1
                WDirCufeII = .dirCUFE2
                WDirCufeIII = .dirCUFE3
                WOrdFechaCalifica = Proceso.ordenaFecha(.vtoCalificacion)
                WOrdFechaCategoria = Proceso.ordenaFecha(.vtoCategoria)
                WOrdFechaNroInsc = Proceso.ordenaFecha(.vtoSEDRONAR)
                WWdate = Date.Now.ToString("MM-dd-yyyy")
                WPaginaWeb = .PaginaWeb(0)
                WContactoNombre1 = .contacto1(0)
                WContactoCargo1 = .contacto1(1)
                WContactoTelefono1 = .contacto1(2)
                WContactoEmail1 = .contacto1(3)
                WContactoNombre2 = .contacto2(0)
                WContactoCargo2 = .contacto2(1)
                WContactoTelefono2 = .contacto2(2)
                WContactoEmail2 = .contacto2(3)
                WContactoNombre3 = .contacto3(0)
                WContactoCargo3 = .contacto3(1)
                WContactoTelefono3 = .contacto3(2)
                WContactoEmail3 = .contacto3(3)
                WClienteAsociado = .cliente.id
                WInhabilitado = .Inhabilitado
            End With
            
            ZSql = ""
            ZSql = "INSERT INTO Proveedor (Proveedor,	Nombre, Direccion, Localidad,Provincia, Postal,Region,Telefono,Dias, Email,Observaciones,Cuit,Tipo,Iva,Cuenta,NombreCheque,CodIb,CodIbCaba,NroIb, PorceIb,PorceIbCaba,TipoProv,NroInsc,FechaNroInsc,CategoriaI,CategoriaII, FechaCategoria, IbCiudadII,Cai,VtoCai,Iso,VtoIso,Estado,Califica,FechaCalifica,ObservacionesII, Cufe,CufeII,CufeIII,DirCufe,DirCufeII,DirCufeIII, OrdFechaCalifica, OrdFechaCategoria, OrdFechaNroInsc, Wdate, PaginaWeb, ContactoNombre1, ContactoCargo1, ContactoTelefono1, ContactoEmail1, ContactoNombre2, ContactoCargo2, ContactoTelefono2, ContactoEmail2, ContactoNombre3, ContactoCargo3, ContactoTelefono3, ContactoEmail3, ClienteAsociado, Inhabilitado) VALUES ('" & WProveedor & "',	'" & WNombre & "', '" & WDireccion & "', '" & WLocalidad & "','" & WProvincia & "', '" & WPostal & "','" & WRegion & "','" & WTelefono & "','" & WDias & "','" & WEmail & "','" & WObservaciones & "','" & WCuit & "','" & WTipo & "','" & WIva & "','" & WCuenta & "','" & WNombreCheque & "','" & WCodIb & "','" & WCodIbCaba & "','" & WNroIb & "','" & WPorceIb & "','" & WPorceIbCaba & "','" & WRubro & "','" & WNroInsc & "','" & WFechaNroInsc & "','" & WCategoriaI & "','" & WCategoriaII & "', '" & WFechaCategoria & "','" & WIbCiudadII & "','" & WCai & "','" & WVtoCai & "','" & WIso & "','" & WVtoIso & "','" & WEstado & "','" & WCalifica & "','" & WFechaCalifica & "','" & WObservacionesII & "','" & WCufe & "','" & WCufeII & "','" & WCufeIII & "','" & WDirCufe & "','" & WDirCufeII & "','" & WDirCufeIII & "', '" & WOrdFechaCalifica & "', '" & WOrdFechaCategoria & "','" & WOrdFechaNroInsc & "', '" & WWdate & "', '" & WPaginaWeb & "', '" & WContactoNombre1 & "', '" & WContactoCargo1 & "', '" & WContactoTelefono1 & "', '" & WContactoEmail1 & "','" & WContactoNombre2 & "', '" & WContactoCargo2 & "', '" & WContactoTelefono2 & "', '" & WContactoEmail2 & "','" & WContactoNombre3 & "', '" & WContactoCargo3 & "', '" & WContactoTelefono3 & "', '" & WContactoEmail3 & "', '" & WClienteAsociado & "', '" & WInhabilitado & "')"

            _DarDeAltaEnTodasLasPlantas(ZSql)

        Catch ex As Exception
            Throw New Exception("Error al dar de alta nuevo proveedor")
        End Try
    End Sub

    Private Shared Sub _DarDeAltaEnTodasLasPlantas(ByVal ZSql As String)
        Dim _Empresas As New List(Of String) From {"SurfactanSA", "surfactan_II", "Surfactan_III", "Surfactan_IV", "Surfactan_V", "Surfactan_VI", "Surfactan_VII", "GastonPruebas"}
        Dim Xcs As String = "Data Source=193.168.0.7;Initial Catalog=#EMPRESA#;User ID=usuarioadmin; Password=usuarioadmin"

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand()

        ' Recorrer todos las plantas y dar de alta en cada una.

        For Each _Empresa In _Empresas

            Dim cs = Xcs.Replace("#EMPRESA#", _Empresa)

            Try
                cn.ConnectionString = cs
                cn.Open()

                cm.CommandText = ZSql

                cm.Connection = cn

                cm.ExecuteNonQuery()

            Catch ex As Exception
                Throw New Exception("Ocurrió un problema al querer actualizar al proveedor.")
                Exit Sub
            Finally

                cn.Close()

            End Try

        Next
    End Sub

    Public Shared Sub eliminarProveedor(ByVal codProveedor As String)
        SQLConnector.executeProcedure("baja_proveedor", codProveedor)
    End Sub

    Public Shared Function crearProveedor(ByVal row)
        Return New Proveedor(row("proveedor").ToString,
                            row("nombre").ToString,
                            row("direccion").ToString,
                            row("postal").ToString,
                            row("localidad").ToString,
                            row("telefono").ToString,
                            row("email").ToString,
                            row("observaciones").ToString,
                            row("cuit").ToString,
                            row("nombrecheque").ToString,
                            row("porceib"),
                            row("porceibcaba"),
                            row("cai").ToString,
                            row("observacionesii").ToString,
                            row("cufe").ToString,
                            row("cufeii").ToString,
                            row("cufeiii").ToString,
                            intNull(row("provincia")),
                            intNull(row("region")),
                            row("dias").ToString,
                            intNull(row("tipo")),
                            intNull(row("iva")),
                            intNull(row("codib")),
                            intNull(row("codibcaba")),
                            row("nroib").ToString,
                            row("nroinsc").ToString,
                            intNull(row("categoriai")),
                            intNull(row("categoriaii")),
                            intNull(row("ibciudadii")),
                            intNull(row("iso")),
                            intNull(row("estado")),
                            intNull(row("califica")),
                            row("fechanroinsc"),
                            row("fechacategoria"),
                            row("vtocai"),
                            row("vtoiso"),
                            row("fechacalifica"),
                            row("dircufe").ToString,
                            row("dircufeii").ToString,
                            row("dircufeiii").ToString,
                            DAOCuentaContable.buscarCuentaContablePorCodigo(row("cuenta").ToString),
                            DAORubroProveedor.buscarRubroProveedorPorCodigo(intNull(row("tipoprov"))),
                            row("PaginaWeb").ToString,
                            row("ContactoNombre1").ToString,
                            row("ContactoCargo1").ToString,
                            row("ContactoTelefono1").ToString,
                            row("ContactoEmail1").ToString,
                            row("ContactoNombre2").ToString,
                            row("ContactoCargo2").ToString,
                            row("ContactoTelefono2").ToString,
                            row("ContactoEmail2").ToString,
                            row("ContactoNombre3").ToString,
                            row("ContactoCargo3").ToString,
                            row("ContactoTelefono3").ToString,
                            row("ContactoEmail3").ToString,
                            DAOCliente.buscarClientePorCodigo(row("ClienteAsociado").ToString),
                            row("Inhabilitado").ToString,
                            row("TipoProv").ToString
                             )
    End Function

    Private Shared Function intNull(ByVal value)
        Return CustomConvert.toIntOrNull(value)
    End Function

    Private Shared Function asStringDate(ByVal value)
        Return CustomConvert.asTextDate(value)
    End Function

    Public Shared Function listarProvincias() As List(Of Provincia)
        Dim provincias As New List(Of Provincia)
        For Each row In SQLConnector.retrieveDataTable("get_provincias").Rows
            provincias.Add(New Provincia(row("codigo"), row("nombre")))
        Next
        Return provincias
    End Function

    Public Shared Function buscarProveedoresActivoPorNombre(Optional ByVal nombre As String = "")
        Dim proveedores As New List(Of Proveedor)
        Dim tabla As DataTable
        tabla = SQLConnector.retrieveDataTable("buscar_proveedor_por_nombre", nombre)
        For Each proveedor As DataRow In tabla.Rows

            If _ProveedorActivo(proveedor("Inhabilitado").ToString) Then

                proveedores.Add(New Proveedor(proveedor("codigo"), proveedor("nombre")))

            End If

        Next
        Return proveedores
    End Function

    Public Shared Function buscarProveedorPorNombre(ByVal nombre As String)
        Dim proveedores As New List(Of Proveedor)
        Dim tabla As DataTable
        tabla = SQLConnector.retrieveDataTable("buscar_proveedor_por_nombre", nombre)
        For Each proveedor As DataRow In tabla.Rows

            proveedores.Add(New Proveedor(proveedor("codigo"), proveedor("nombre")))

        Next
        Return proveedores
    End Function

    Public Shared Function _ProveedorActivo(ByVal estado As String) As Boolean
        Dim _estado As String = IIf(Trim(estado) = "", "0", Trim(estado))

        Return _estado <> "1"
    End Function

    Public Shared Function buscarProveedorPorCodigo(ByVal codigo As String)
        Try
            Dim tabla As DataTable
            tabla = SQLConnector.retrieveDataTable("buscar_proveedor_por_codigo", codigo)
            If tabla.Rows.Count > 0 Then
                Return crearProveedor(tabla(0))
            Else
                Return Nothing
            End If
        Catch e As Exception
            Return Nothing
        End Try
    End Function

    Public Shared Function cuentaDefault()
        Return DAOCuentaContable.buscarCuentaContablePorCodigo("2001")
    End Function

    Public Shared Function bancoNacion()
        Return DAOProveedor.buscarProveedorPorCodigo("10077777777")
    End Function

End Class
