Public Class Proveedor
    Public id As String
    Public razonSocial, direccion, codPostal, localidad, telefono, email, observaciones, cuit, nombreCheque, cai, observacionCompleta, cufe1, cufe2, cufe3, diasPlazo, numeroIB, numeroSEDRONAR As String
    Public provincia, region, tipo, codIva, condicionIB1, condicionIB2, categoria, categoriaCalif, tipoInscripcionIB, certificados, estado, calificacion As Nullable(Of Integer)
    Public vtoSEDRONAR, vtoCategoria, vtoCAI, vtoCertificados, vtoCalificacion, dirCUFE1, dirCUFE2, dirCUFE3 As String
    Public porceIBProvincia, porceIBCABA As Double
    Public cuenta As CuentaContable
    Public rubro As RubroProveedor
    Public cliente As Cliente
    Public contacto1 As Object
    Public contacto2 As Object
    Public contacto3 As Object
    Public PaginaWeb As Object
    Public estaDefinidoCompleto As Boolean

    Public Sub New(ByVal codigo As String, ByVal nombre As String)
        id = codigo
        razonSocial = nombre
        estaDefinidoCompleto = False
    End Sub

    Public Sub New(ByVal codigo As String, ByVal nombre As String, ByVal dir As String, ByVal codigoPostal As String, ByVal loc As String,
                   ByVal tel As String, ByVal mail As String, ByVal obs1 As String, ByVal claveCUIT As String, ByVal cheque As String,
                   ByVal porceProv As Double, ByVal porceCABA As Double, ByVal claveCAI As String, ByVal obs2 As String,
                   ByVal cuf1 As String, ByVal cuf2 As String, ByVal cuf3 As String, ByVal prov As Integer, ByVal reg As Integer, ByVal dias As String, ByVal tipoProv As Integer,
                   ByVal iva As Integer, ByVal condicion1IB As Integer, ByVal condicion2IB As Integer, ByVal nroIB As String, ByVal SEDRONAR As String, ByVal cat As Integer,
                   ByVal calificacionCategoria As Integer, ByVal tipoIB As Integer, ByVal certificaciones As Integer, ByVal tipoEstado As Integer, ByVal calif As Integer,
                   ByVal SEDRONARVto As String, ByVal categoriaVto As String, ByVal CAIVto As String, ByVal certificadosVto As String, ByVal calificacionVto As String,
                   ByVal cufe1Dir As String, ByVal cufe2Dir As String, ByVal cufe3Dir As String, ByVal cuentaContable As CuentaContable, ByVal rubroProv As RubroProveedor,
                   ByVal _PaginaWeb As String, ByVal ContactoNombre1 As String, ByVal ContactoCargo1 As String, ByVal ContactoTelefono1 As String, ByVal ContactoEmail1 As String,
                   ByVal ContactoNombre2 As String, ByVal ContactoCargo2 As String, ByVal ContactoTelefono2 As String, ByVal ContactoEmail2 As String,
                   ByVal ContactoNombre3 As String, ByVal ContactoCargo3 As String, ByVal ContactoTelefono3 As String, ByVal ContactoEmail3 As String, Optional ByVal _ClienteAsociado As Cliente = Nothing)

        id = Trim(codigo)
        razonSocial = Trim(nombre)
        direccion = Trim(dir)
        codPostal = Trim(codigoPostal)
        localidad = Trim(loc)
        telefono = Trim(tel)
        email = Trim(mail)
        observaciones = Trim(obs1)
        cuit = Trim(claveCUIT)
        nombreCheque = Trim(cheque)
        porceIBProvincia = porceProv
        porceIBCABA = porceCABA
        cai = Trim(claveCAI)
        observacionCompleta = Trim(obs2)
        cufe1 = Trim(cuf1)
        cufe2 = Trim(cuf2)
        cufe3 = Trim(cuf3)
        provincia = prov
        region = reg
        diasPlazo = Trim(dias)
        tipo = tipoProv
        codIva = iva
        condicionIB1 = condicion1IB
        condicionIB2 = condicion2IB
        numeroIB = Trim(nroIB)
        numeroSEDRONAR = Trim(SEDRONAR)
        categoria = cat
        categoriaCalif = calificacionCategoria
        tipoInscripcionIB = tipoIB
        certificados = certificaciones
        estado = tipoEstado
        calificacion = calif
        vtoSEDRONAR = SEDRONARVto
        vtoCategoria = categoriaVto
        vtoCAI = CAIVto
        vtoCertificados = certificadosVto
        vtoCalificacion = calificacionVto
        dirCUFE1 = Trim(cufe1Dir)
        dirCUFE2 = Trim(cufe2Dir)
        dirCUFE3 = Trim(cufe3Dir)
        cuenta = cuentaContable
        rubro = rubroProv
        PaginaWeb = New Object() {_PaginaWeb}
        cliente = _ClienteAsociado
        contacto1 = New Object() {ContactoNombre1, ContactoCargo1, ContactoTelefono1, ContactoEmail1}
        contacto2 = New Object() {ContactoNombre2, ContactoCargo2, ContactoTelefono2, ContactoEmail2}
        contacto3 = New Object() {ContactoNombre3, ContactoCargo3, ContactoTelefono3, ContactoEmail3}

        estaDefinidoCompleto = True
    End Sub
    
    Public Overrides Function ToString() As String
        Return razonSocial
    End Function

    Public Function codigoRubro() As Integer
        If Not IsNothing(rubro) Then
            Return rubro.codigo
        Else
            Return -1
        End If
    End Function

    Public Function codigoCuenta() As String
        If Not IsNothing(cuenta) Then
            Return cuenta.id
        Else
            Return ""
        End If
    End Function
End Class
