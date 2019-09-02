Imports ClasesCompartidas

Public Class DAOProveedor

    Public Shared Sub agregarProveedor(ByVal proveedor As Proveedor)
        SQLConnector.executeProcedure("alta_proveedor", proveedor.id, proveedor.razonSocial, proveedor.direccion, proveedor.localidad, _
                                      proveedor.provincia, proveedor.codPostal, proveedor.region, proveedor.telefono, proveedor.diasPlazo, _
                                      proveedor.email, proveedor.observaciones, proveedor.cuit, proveedor.tipo, proveedor.codIva, _
                                      proveedor.codigoCuenta, proveedor.nombreCheque, proveedor.condicionIB1, proveedor.condicionIB2, _
                                      proveedor.numeroIB, proveedor.porceIBProvincia, proveedor.porceIBCABA, proveedor.codigoRubro, _
                                      proveedor.numeroSEDRONAR, proveedor.vtoSEDRONAR, proveedor.categoria, proveedor.categoriaCalif, _
                                      proveedor.vtoCategoria, proveedor.tipoInscripcionIB, proveedor.cai, proveedor.vtoCAI, _
                                      proveedor.certificados, proveedor.vtoCertificados, proveedor.estado, proveedor.calificacion, _
                                      proveedor.vtoCalificacion, proveedor.observacionCompleta, proveedor.cufe1, proveedor.cufe2, _
                                      proveedor.cufe3, proveedor.dirCUFE1, proveedor.dirCUFE2, proveedor.dirCUFE3)
    End Sub

    Public Shared Sub eliminarProveedor(ByVal codProveedor As String)
        SQLConnector.executeProcedure("baja_proveedor", codProveedor)
    End Sub

    'Private Shared Function crearProveedor(ByVal codigo As String, ByVal row As DataRow)
    '    Return New Proveedor(codigo, row("nombre").ToString, row("direccion").ToString, row("postal").ToString, row("localidad").ToString, row("telefono").ToString, row("email").ToString,
    '                         row("observaciones").ToString, row("cuit").ToString, row("nombrecheque").ToString, row("porceib"), row("porceibcaba"), row("cai").ToString, row("observacionesii").ToString, row("cufe").ToString, row("cufeii").ToString, row("cufeiii").ToString,
    '                         intNull(row("provincia")), intNull(row("region")), row("dias").ToString, intNull(row("tipo")), intNull(row("iva")), intNull(row("codib")), intNull(row("codibcaba")), row("nroib").ToString, row("nroinsc").ToString, intNull(row("categoriai")),
    '                         intNull(row("categoriaii")), intNull(row("ibciudadii")), intNull(row("iso")), intNull(row("estado")), intNull(row("califica")), asStringDate(row("fechanroinsc")), asStringDate(row("fechacategoria")), asStringDate(row("vtocai")), asStringDate(row("vtoiso")), asStringDate(row("fechacalifica")),
    '                         asStringDate(row("dircufe")), asStringDate(row("dircufeii")), asStringDate(row("dircufeiii")), DAOCuentaContable.buscarCuentaContablePorCodigo(row("cuenta").ToString), DAORubroProveedor.buscarRubroProveedorPorCodigo(intNull(row("tipoprov"))))
    'End Function

    Public Shared Function crearProveedor(ByVal row)
        Return New Proveedor(row("proveedor").ToString, row("nombre").ToString, row("direccion").ToString, row("postal").ToString, row("localidad").ToString, row("telefono").ToString, row("email").ToString,
                             row("observaciones").ToString, row("cuit").ToString, row("nombrecheque").ToString, row("porceib"), row("porceibcaba"), row("cai").ToString, row("observacionesii").ToString, row("cufe").ToString, row("cufeii").ToString, row("cufeiii").ToString,
                             intNull(row("provincia")), intNull(row("region")), row("dias").ToString, intNull(row("tipo")), intNull(row("iva")), intNull(row("codib")), intNull(row("codibcaba")), row("nroib").ToString, row("nroinsc").ToString, intNull(row("categoriai")),
                             intNull(row("categoriaii")), intNull(row("ibciudadii")), intNull(row("iso")), intNull(row("estado")), intNull(row("califica")), asStringDate(row("fechanroinsc")), asStringDate(row("fechacategoria")), asStringDate(row("vtocai")), asStringDate(row("vtoiso")), asStringDate(row("fechacalifica")),
                             asStringDate(row("dircufe")), asStringDate(row("dircufeii")), asStringDate(row("dircufeiii")), DAOCuentaContable.buscarCuentaContablePorCodigo(row("cuenta").ToString), DAORubroProveedor.buscarRubroProveedorPorCodigo(intNull(row("tipoprov"))))
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

    Public Shared Function buscarProveedorPorNombre(ByVal nombre As String)
        Dim proveedores As New List(Of Proveedor)
        Dim tabla As DataTable
        tabla = SQLConnector.retrieveDataTable("buscar_proveedor_por_nombre", nombre)
        For Each proveedor As DataRow In tabla.Rows
            proveedores.Add(New Proveedor(proveedor("codigo"), proveedor("nombre")))
        Next
        Return proveedores
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

End Class
