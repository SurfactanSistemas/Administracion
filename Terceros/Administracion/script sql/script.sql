USE [SurfactanSA]
GO
/****** Object:  User [usuarioadmin]    Script Date: 22/06/2018 10:05:47 a. m. ******/
CREATE USER [usuarioadmin] FOR LOGIN [usuarioadmin] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  UserDefinedFunction [dbo].[FN_get_fecha_desde_ordenable]    Script Date: 22/06/2018 10:05:48 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE FUNCTION [dbo].[FN_get_fecha_desde_ordenable](@fecha varchar(10))
RETURNS varchar(10)
AS
BEGIN
	
	declare @fecha_retorno varchar(10) 
	SET @fecha_retorno = RIGHT(@fecha,2)+ '/' + RIGHT((LEFT(@fecha,6)),2) + '/' + LEFT(@fecha,4) 
	
	RETURN @fecha_retorno
END

GO
/****** Object:  UserDefinedFunction [dbo].[FN_get_fecha_ordenable]    Script Date: 22/06/2018 10:05:48 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE FUNCTION [dbo].[FN_get_fecha_ordenable](@fecha varchar(10))
RETURNS varchar(10)
AS
BEGIN
	declare @ordenFechaInt int
	declare @ordenFechaString varchar(10)
	set @ordenFechaInt = YEAR(@fecha) * 10000 + MONTH(@fecha) * 100 + DAY(@fecha)  
	set @ordenFechaString =  convert(varchar(10), @ordenFechaInt)
	RETURN @ordenFechaString
END
GO
/****** Object:  UserDefinedFunction [dbo].[FN_verificar_fecha_ordenable]    Script Date: 22/06/2018 10:05:48 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE FUNCTION [dbo].[FN_verificar_fecha_ordenable](@fecha varchar(10))
RETURNS varchar(8)
AS
BEGIN
	
	DECLARE @dia varchar(2) 
	DECLARE @mes varchar(2) 
	DECLARE @ano varchar(4) 
	DECLARE @fecha_ordenable varchar(8) 
	
	SET @dia = ISNULL(SUBSTRING(@fecha,1,2),'00')
	SET @mes = ISNULL(SUBSTRING(@fecha,4,2),'00')
	SET @ano = ISNULL(SUBSTRING(@fecha,7,4),'0000')
	IF (@dia > 0 and @mes > 0 and @ano > 0)
		SET @fecha_ordenable = (SELECT dbo.FN_get_fecha_ordenable (@fecha))
	
	RETURN @fecha_ordenable
END

GO
/****** Object:  Table [dbo].[Auxiliar]    Script Date: 22/06/2018 10:05:48 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Auxiliar](
	[Empresa] [smallint] NULL,
	[Nombre] [nvarchar](50) NULL,
	[Direccion] [nvarchar](50) NULL,
	[Cuit] [nvarchar](15) NULL,
	[Actividad] [nvarchar](50) NULL,
	[CtaRetgan] [nvarchar](10) NULL,
	[CtaRetIva] [nvarchar](10) NULL,
	[CtaRetotro] [nvarchar](10) NULL,
	[Ctadeudores] [nvarchar](10) NULL,
	[CtaEfectivo] [nvarchar](10) NULL,
	[CtaCheque] [nvarchar](10) NULL,
	[CtaDocumentos] [nvarchar](10) NULL,
	[CtaProveedores] [nvarchar](50) NULL,
	[CtaIva21] [nvarchar](50) NULL,
	[CtaIva5] [nvarchar](50) NULL,
	[CtaIva27] [nvarchar](50) NULL,
	[CtaIb] [nvarchar](50) NULL,
	[CtaTerceros] [nvarchar](50) NULL,
	[Auxi1] [char](10) NULL,
	[Auxi2] [char](10) NULL,
	[Auxi3] [char](10) NULL,
	[Auxi4] [char](10) NULL,
	[POSDAT] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Banco]    Script Date: 22/06/2018 10:05:48 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Banco](
	[Banco] [smallint] NULL,
	[Nombre] [nvarchar](50) NULL,
	[Cuenta] [nvarchar](10) NULL,
	[Empresa] [smallint] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BCRA]    Script Date: 22/06/2018 10:05:48 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BCRA](
	[Banco] [smallint] NULL,
	[Nombre] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CambioAdm]    Script Date: 22/06/2018 10:05:48 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CambioAdm](
	[Fecha] [nvarchar](10) NULL,
	[Cambio] [float] NULL,
	[OrdFecha] [nvarchar](10) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cambios]    Script Date: 22/06/2018 10:05:48 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cambios](
	[Fecha] [nvarchar](10) NULL,
	[Cambio] [float] NULL,
	[OrdFecha] [nvarchar](10) NULL,
	[CambioII] [float] NULL,
	[CambioIII] [float] NULL,
	[CambioIV] [float] NULL,
	[CambioV] [float] NULL,
	[CambioVI] [float] NULL,
	[CambioDivisa] [float] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Carpeta]    Script Date: 22/06/2018 10:05:48 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Carpeta](
	[Carpeta] [int] NULL,
	[Articulo] [char](10) NULL,
	[Cantidad] [float] NULL,
	[CostoFlete] [float] NULL,
	[Importe] [float] NULL,
	[Arancel] [float] NULL,
	[Costo] [float] NULL,
	[Gastos] [float] NULL,
	[Precio] [float] NULL,
	[Coeficiente] [float] NULL,
	[Clave] [char](8) NULL,
	[Leyenda] [int] NULL,
	[CantidadII] [float] NULL,
	[GastosII] [float] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cierre]    Script Date: 22/06/2018 10:05:48 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cierre](
	[Mes] [int] NULL,
	[Ano] [int] NULL,
	[Estado] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 22/06/2018 10:05:48 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[Cliente] [nvarchar](6) NULL,
	[Razon] [nvarchar](50) NULL,
	[Direccion] [nvarchar](50) NULL,
	[Localidad] [nvarchar](50) NULL,
	[Provincia] [nvarchar](2) NULL,
	[Postal] [nvarchar](10) NULL,
	[Email] [nvarchar](80) NULL,
	[Fax] [nvarchar](20) NULL,
	[Telefono] [nvarchar](40) NULL,
	[Cuit] [nvarchar](15) NULL,
	[Contacto] [nvarchar](50) NULL,
	[Observaciones] [nvarchar](100) NULL,
	[Vendedor] [int] NULL,
	[Iva] [nvarchar](1) NULL,
	[Rubro] [int] NULL,
	[Horario] [nvarchar](20) NULL,
	[Pago1] [int] NULL,
	[Pago2] [int] NULL,
	[Limite] [float] NULL,
	[Minimo] [float] NULL,
	[DirEntrega] [nvarchar](50) NULL,
	[Importe1] [float] NULL,
	[Importe2] [float] NULL,
	[Importe3] [float] NULL,
	[Importe4] [float] NULL,
	[Importe5] [float] NULL,
	[Importe6] [float] NULL,
	[WDate] [nvarchar](10) NULL,
	[Precio] [char](2) NULL,
	[Ib] [int] NULL,
	[Adicional] [float] NULL,
	[Especif1] [nvarchar](50) NULL,
	[Especif2] [nvarchar](50) NULL,
	[Especif3] [nvarchar](50) NULL,
	[Especif4] [nvarchar](50) NULL,
	[Especif5] [nvarchar](50) NULL,
	[Especif6] [nvarchar](50) NULL,
	[Especif7] [nvarchar](50) NULL,
	[Especif8] [nvarchar](50) NULL,
	[Especif9] [nvarchar](50) NULL,
	[Especif10] [nvarchar](50) NULL,
	[DirEntregaII] [nvarchar](50) NULL,
	[DirEntregaIII] [nvarchar](50) NULL,
	[DirEntregaIV] [nvarchar](50) NULL,
	[DirEntregaV] [nvarchar](50) NULL,
	[IbTucu] [int] NULL,
	[ImpreVto] [int] NULL,
	[NroIbTucu] [char](20) NULL,
	[PorceIb] [float] NULL,
	[IbCiudad] [int] NULL,
	[NroIbCiudad] [char](20) NULL,
	[NroIb] [char](20) NULL,
	[Fecha] [char](10) NULL,
	[OrdFecha] [char](8) NULL,
	[Hora] [float] NULL,
	[Anotacion] [char](50) NULL,
	[FechaMinuta] [char](10) NULL,
	[NroSedronar] [char](15) NULL,
	[Pais] [int] NULL,
	[CuitII] [char](20) NULL,
	[PorceIbCaba] [float] NULL,
	[fechsedro] [char](10) NULL,
	[PorceCm05Tucu] [float] NULL,
	[Emailenv] [char](70) NULL,
	[FechaEmailEnvase] [char](10) NULL,
	[Idioma] [int] NULL,
	[EtiI] [int] NULL,
	[EtiII] [int] NULL,
	[MarcaI] [char](1) NULL,
	[MarcaII] [char](1) NULL,
	[DolarEspecial] [int] NULL,
	[EmailFactura] [char](100) NULL,
	[Cufe] [char](13) NULL,
	[CufeII] [char](13) NULL,
	[DirCufe] [char](50) NULL,
	[DirCufeII] [char](50) NULL,
	[Restriccion] [int] NULL,
	[IbCiudadII] [int] NULL,
	[ImpreDireccion] [char](100) NULL,
	[PrecioPesos] [int] NULL,
	[EmailFacturaII] [char](200) NULL,
	[FechaII] [char](10) NULL,
	[OrdFechaII] [char](8) NULL,
	[HoraII] [float] NULL,
	[AnotacionII] [char](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ClienteDirEntrega]    Script Date: 22/06/2018 10:05:48 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClienteDirEntrega](
	[Cliente] [char](6) NULL,
	[DireccionI] [char](40) NULL,
	[NumeroI] [int] NULL,
	[LocalidadI] [char](50) NULL,
	[PostalI] [char](8) NULL,
	[ProvinciaI] [int] NULL,
	[ComplementoI] [char](5) NULL,
	[DireccionII] [char](40) NULL,
	[NumeroII] [int] NULL,
	[LocalidadII] [char](50) NULL,
	[PostalII] [char](8) NULL,
	[ProvinciaII] [int] NULL,
	[ComplementoII] [char](5) NULL,
	[DireccionIII] [char](40) NULL,
	[NumeroIII] [int] NULL,
	[LocalidadIII] [char](50) NULL,
	[PostalIII] [char](8) NULL,
	[ProvinciaIII] [int] NULL,
	[ComplementoIII] [char](5) NULL,
	[DireccionIV] [char](40) NULL,
	[NumeroIV] [int] NULL,
	[LocalidadIV] [char](50) NULL,
	[PostalIV] [char](8) NULL,
	[ProvinciaIV] [int] NULL,
	[ComplementoIV] [char](5) NULL,
	[DireccionV] [char](40) NULL,
	[LocalidadV] [char](50) NULL,
	[PostalV] [char](8) NULL,
	[Provinciav] [int] NULL,
	[ComplementoV] [char](5) NULL,
	[NumeroV] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ClienteEspecif]    Script Date: 22/06/2018 10:05:48 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClienteEspecif](
	[Cliente] [char](6) NULL,
	[RequiereCertificado] [int] NULL,
	[RequiereMsds] [int] NULL,
	[RequiereMsdsCada] [int] NULL,
	[RequiereHoja] [int] NULL,
	[PermiteParcial] [int] NULL,
	[DiasI] [char](50) NULL,
	[DiasII] [char](50) NULL,
	[DiasIII] [char](50) NULL,
	[Especif1] [char](50) NULL,
	[Especif2] [char](50) NULL,
	[Especif3] [char](50) NULL,
	[Especif4] [char](50) NULL,
	[Especif5] [char](50) NULL,
	[PartidaVarias] [int] NULL,
	[CantidadPartidas] [int] NULL,
	[EnvasesI] [char](50) NULL,
	[EnvasesII] [char](50) NULL,
	[EnvasesIII] [char](50) NULL,
	[EtiquetaI] [char](50) NULL,
	[EtiquetaII] [char](50) NULL,
	[EmailCertificado] [char](50) NULL,
	[EmailHoja] [char](50) NULL,
	[EmailMsds] [char](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Control]    Script Date: 22/06/2018 10:05:48 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Control](
	[Orden] [int] NULL,
	[Fecha] [nvarchar](10) NULL,
	[Proveedor] [nvarchar](11) NULL,
	[Articulo] [nvarchar](10) NULL,
	[Cantidad] [float] NULL,
	[Comprobante] [nvarchar](20) NULL,
	[Fecha1] [nvarchar](10) NULL,
	[Cantidad1] [float] NULL,
	[cantidad2] [float] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ControlImpoImpre]    Script Date: 22/06/2018 10:05:48 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ControlImpoImpre](
	[Orden] [int] NULL,
	[Pta] [char](3) NULL,
	[Fecha] [char](10) NULL,
	[Proveedor] [char](50) NULL,
	[Moneda] [char](4) NULL,
	[Carpeta] [int] NULL,
	[Djai] [char](20) NULL,
	[Origen] [char](30) NULL,
	[Incoterms] [char](10) NULL,
	[Transporte] [char](30) NULL,
	[FLLegada] [char](10) NULL,
	[TPago] [char](30) NULL,
	[Despacho] [float] NULL,
	[PagoDespacho] [char](20) NULL,
	[Letra] [float] NULL,
	[PagoLetra] [char](20) NULL,
	[VtoLetra] [char](10) NULL,
	[SumaI] [float] NULL,
	[SumaII] [float] NULL,
	[PagoParcial] [float] NULL,
	[FEmbarque] [char](10) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CostoPartida]    Script Date: 22/06/2018 10:05:48 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CostoPartida](
	[Clave] [char](18) NULL,
	[Empresa] [int] NULL,
	[Orden] [int] NULL,
	[Articulo] [char](10) NULL,
	[Carpeta] [int] NULL,
	[Costo] [float] NULL,
	[Laudo] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[coti]    Script Date: 22/06/2018 10:05:48 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[coti](
	[Clave] [nvarchar](8) NULL,
	[Cotiza] [int] NULL,
	[Renglon] [int] NULL,
	[Fecha] [nvarchar](10) NULL,
	[Proveedor] [nvarchar](11) NULL,
	[Articulo] [nvarchar](10) NULL,
	[Precio] [float] NULL,
	[Condicion] [nvarchar](40) NULL,
	[Observaciones] [nvarchar](40) NULL,
	[FechaOrd] [nvarchar](8) NULL,
	[WDate] [nvarchar](10) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cotiza]    Script Date: 22/06/2018 10:05:48 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cotiza](
	[Clave] [nvarchar](8) NULL,
	[Cotiza] [int] NULL,
	[Renglon] [int] NULL,
	[Fecha] [nvarchar](10) NULL,
	[Proveedor] [nvarchar](11) NULL,
	[Articulo] [nvarchar](10) NULL,
	[Precio] [float] NULL,
	[Condicion] [nvarchar](40) NULL,
	[Observaciones] [nvarchar](40) NULL,
	[FechaOrd] [nvarchar](8) NULL,
	[WDate] [nvarchar](10) NULL,
	[Moneda] [int] NULL,
	[Tipo] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CtaCte]    Script Date: 22/06/2018 10:05:48 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CtaCte](
	[Clave] [nvarchar](12) NULL,
	[Tipo] [nvarchar](2) NOT NULL,
	[Numero] [int] NOT NULL,
	[Renglon] [nvarchar](2) NOT NULL,
	[Cliente] [nvarchar](6) NULL,
	[fecha] [nvarchar](10) NULL,
	[Estado] [nvarchar](1) NULL,
	[Vencimiento] [nvarchar](10) NULL,
	[Vencimiento1] [nvarchar](10) NULL,
	[Total] [float] NULL,
	[TotalUs] [float] NULL,
	[Saldo] [float] NULL,
	[SaldoUs] [float] NULL,
	[OrdFecha] [nvarchar](8) NULL,
	[OrdVencimiento] [nvarchar](8) NULL,
	[OrdVencimiento1] [nvarchar](8) NULL,
	[Impre] [nvarchar](2) NULL,
	[Empresa] [smallint] NULL,
	[Neto] [float] NULL,
	[Iva1] [float] NULL,
	[Iva2] [float] NULL,
	[Pedido] [nvarchar](6) NULL,
	[Remito] [nvarchar](10) NULL,
	[Orden] [nvarchar](10) NULL,
	[Paridad] [float] NULL,
	[Provincia] [nvarchar](2) NULL,
	[Vendedor] [int] NULL,
	[Rubro] [int] NULL,
	[Comprobante] [nvarchar](8) NULL,
	[Aceptada] [nvarchar](1) NULL,
	[Costo] [float] NULL,
	[Importe1] [float] NULL,
	[Importe2] [float] NULL,
	[Importe3] [float] NULL,
	[Importe4] [float] NULL,
	[Importe5] [float] NULL,
	[Importe6] [float] NULL,
	[Importe7] [float] NULL,
	[WDate] [nvarchar](10) NULL,
	[Seguro] [float] NULL,
	[Flete] [float] NULL,
	[ImpoIb] [float] NULL,
	[Importe8] [float] NULL,
	[ClaveRecibo] [char](8) NULL,
	[NroFactura] [int] NULL,
	[NroRecibo] [int] NULL,
	[Moneda] [int] NULL,
	[Adicional] [int] NULL,
	[Numero8] [int] NULL,
	[ImpoIbTucu] [float] NULL,
	[ImpoIbCiudad] [float] NULL,
	[Importe9] [float] NULL,
	[TipoCompo] [int] NULL,
	[ImpreNumero] [char](8) NULL,
	[Cae] [char](30) NULL,
	[FechaCae] [char](10) NULL,
	[Marca] [char](50) NULL,
	[Envio1] [char](50) NULL,
	[Envio2] [char](50) NULL,
	[Pago1] [char](50) NULL,
	[Pago2] [char](50) NULL,
	[NroOrden] [char](20) NULL,
	[FecOrden] [char](10) NULL,
	[Consignatario] [char](50) NULL,
	[Cip] [char](50) NULL,
	[ImpreDolar1] [char](60) NULL,
	[ImpreDolar2] [char](60) NULL,
	[ImpreTotal] [float] NULL,
	[ImpreTotalBruto] [float] NULL,
	[ImpreTotalNeto] [float] NULL,
	[CipLista] [int] NULL,
	[Idioma] [int] NULL,
	[Gastos] [float] NULL,
	[ImpreBarra] [char](80) NULL,
	[ImpreBarraII] [char](80) NULL,
	[Descuento] [float] NULL,
	[ProyectaSaldo] [float] NULL,
	[ImpreReteIb] [float] NULL,
	[ClienteII] [char](6) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CtaCtePrv]    Script Date: 22/06/2018 10:05:48 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CtaCtePrv](
	[Clave] [nvarchar](26) NULL,
	[Proveedor] [nvarchar](11) NOT NULL,
	[Letra] [nvarchar](1) NULL,
	[Tipo] [nvarchar](2) NOT NULL,
	[Punto] [nvarchar](4) NULL,
	[Numero] [nvarchar](8) NOT NULL,
	[fecha] [nvarchar](10) NULL,
	[Estado] [nvarchar](1) NULL,
	[Vencimiento] [nvarchar](10) NULL,
	[Vencimiento1] [nvarchar](50) NULL,
	[Total] [float] NULL,
	[Saldo] [float] NULL,
	[OrdFecha] [nvarchar](8) NULL,
	[OrdVencimiento] [nvarchar](8) NULL,
	[Impre] [nvarchar](2) NULL,
	[Empresa] [smallint] NULL,
	[SaldoList] [float] NULL,
	[NroInterno] [int] NULL,
	[Lista] [nvarchar](1) NULL,
	[Acumulado] [float] NULL,
	[Paridad] [float] NULL,
	[Pago] [int] NULL,
	[Observaciones] [char](50) NULL,
	[Tarjeta] [char](1) NULL,
	[NroInternoAsociado] [int] NULL,
	[DesProveOriginal] [char](50) NULL,
	[FacturaOriginal] [int] NULL,
	[Cuota] [int] NULL,
	[ImporteOriginal] [float] NULL,
	[FechaOriginal] [char](10) NULL,
	[Interes] [float] NULL,
	[IvaInteres] [float] NULL,
	[OrdFechaOriginal] [char](8) NULL,
	[Referencia] [char](10) NULL,
	[TituloI] [char](50) NULL,
	[TituloII] [char](50) NULL,
	[Auxi1] [char](10) NULL,
	[Auxi2] [char](10) NULL,
	[Auxi3] [char](8) NULL,
	[Auxi4] [char](8) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cuenta]    Script Date: 22/06/2018 10:05:48 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cuenta](
	[Cuenta] [nvarchar](10) NULL,
	[Descripcion] [nvarchar](50) NULL,
	[Nivel] [smallint] NULL,
	[Empresa] [smallint] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cuit]    Script Date: 22/06/2018 10:05:48 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cuit](
	[Clave] [char](17) NULL,
	[Banco] [char](3) NULL,
	[Sucursal] [char](3) NULL,
	[Cuenta] [char](11) NULL,
	[Cuit] [char](15) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Depositos]    Script Date: 22/06/2018 10:05:48 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Depositos](
	[Clave] [nvarchar](8) NULL,
	[Deposito] [nvarchar](6) NULL,
	[Renglon] [nvarchar](2) NULL,
	[Banco] [smallint] NULL,
	[Fecha] [nvarchar](10) NULL,
	[FechaOrd] [nvarchar](8) NULL,
	[Importe] [float] NULL,
	[Acredita] [nvarchar](10) NULL,
	[AcreditaOrd] [nvarchar](8) NULL,
	[Tipo2] [nvarchar](2) NULL,
	[Numero2] [nvarchar](8) NULL,
	[Fecha2] [nvarchar](10) NULL,
	[Importe2] [real] NULL,
	[Observaciones2] [nvarchar](20) NULL,
	[Empresa] [smallint] NULL,
	[Impolista] [float] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DescComp]    Script Date: 22/06/2018 10:05:48 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DescComp](
	[Clave] [char](12) NULL,
	[Tipo] [char](2) NULL,
	[Numero] [char](8) NULL,
	[Renglon] [char](2) NULL,
	[Descripcion] [char](70) NULL,
	[Importe] [float] NULL,
	[Empresa] [int] NULL,
	[WDate] [char](10) NULL,
	[ClaveCtaCte] [char](12) NULL,
	[Cliente] [char](6) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Devcon]    Script Date: 22/06/2018 10:05:48 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Devcon](
	[Clave] [nvarchar](8) NOT NULL,
	[Numero] [int] NULL,
	[Renglon] [int] NULL,
	[Cliente] [nvarchar](6) NULL,
	[Fecha] [nvarchar](10) NULL,
	[Observaciones] [nvarchar](50) NULL,
	[Terminado] [nvarchar](12) NULL,
	[Cantidad] [float] NULL,
	[FechaOrd] [nvarchar](8) NULL,
	[Precio] [float] NULL,
	[Linea] [int] NULL,
	[Importe] [int] NULL,
	[Remito] [int] NULL,
	[Lote] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EspeCli]    Script Date: 22/06/2018 10:05:48 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EspeCli](
	[Cliente] [char](6) NULL,
	[Terminado] [char](12) NULL,
	[Especificaciones] [char](30) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Gasimpo]    Script Date: 22/06/2018 10:05:48 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Gasimpo](
	[Codigo] [int] NULL,
	[Nombre] [char](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ImpCtaCte]    Script Date: 22/06/2018 10:05:48 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ImpCtaCte](
	[Clave] [nvarchar](12) NULL,
	[Tipo] [nvarchar](2) NOT NULL,
	[Numero] [int] NOT NULL,
	[Renglon] [nvarchar](2) NOT NULL,
	[Cliente] [nvarchar](6) NULL,
	[fecha] [nvarchar](10) NULL,
	[Estado] [nvarchar](1) NULL,
	[Vencimiento] [nvarchar](10) NULL,
	[Vencimiento1] [nvarchar](10) NULL,
	[Total] [float] NULL,
	[TotalUs] [float] NULL,
	[Saldo] [float] NULL,
	[SaldoUs] [float] NULL,
	[OrdFecha] [nvarchar](8) NULL,
	[OrdVencimiento] [nvarchar](8) NULL,
	[OrdVencimiento1] [nvarchar](8) NULL,
	[Impre] [nvarchar](2) NULL,
	[Empresa] [smallint] NULL,
	[Neto] [float] NULL,
	[Iva1] [float] NULL,
	[Iva2] [float] NULL,
	[Pedido] [nvarchar](6) NULL,
	[Remito] [nvarchar](10) NULL,
	[Orden] [nvarchar](10) NULL,
	[Paridad] [float] NULL,
	[Provincia] [nvarchar](2) NULL,
	[Vendedor] [int] NULL,
	[Rubro] [int] NULL,
	[Comprobante] [nvarchar](8) NULL,
	[Aceptada] [nvarchar](1) NULL,
	[Costo] [float] NULL,
	[Importe1] [float] NULL,
	[Importe2] [float] NULL,
	[Importe3] [float] NULL,
	[Importe4] [float] NULL,
	[Importe5] [float] NULL,
	[Importe6] [float] NULL,
	[Importe7] [float] NULL,
	[WDate] [nvarchar](10) NULL,
	[claveimpre] [nvarchar](16) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ImpCtaCteProy]    Script Date: 22/06/2018 10:05:48 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ImpCtaCteProy](
	[Clave] [char](12) NULL,
	[Tipo] [char](2) NOT NULL,
	[Numero] [int] NOT NULL,
	[Renglon] [char](2) NOT NULL,
	[fecha] [char](10) NULL,
	[Total] [float] NULL,
	[TotalUs] [float] NULL,
	[Saldo] [float] NULL,
	[SaldoUs] [float] NULL,
	[OrdFecha] [char](8) NULL,
	[Paridad] [float] NULL,
	[Importe1] [float] NULL,
	[Importe2] [float] NULL,
	[Importe3] [float] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ImpCtaCtePrv]    Script Date: 22/06/2018 10:05:48 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ImpCtaCtePrv](
	[Clave] [nvarchar](26) NULL,
	[Proveedor] [nvarchar](11) NOT NULL,
	[Letra] [nvarchar](1) NULL,
	[Tipo] [nvarchar](2) NOT NULL,
	[Punto] [nvarchar](4) NULL,
	[Numero] [nvarchar](8) NOT NULL,
	[fecha] [nvarchar](10) NULL,
	[Estado] [nvarchar](1) NULL,
	[Vencimiento] [nvarchar](10) NULL,
	[Vencimiento1] [nvarchar](50) NULL,
	[Total] [float] NULL,
	[Saldo] [float] NULL,
	[OrdFecha] [nvarchar](8) NULL,
	[OrdVencimiento] [nvarchar](8) NULL,
	[Impre] [nvarchar](2) NULL,
	[Empresa] [smallint] NULL,
	[SaldoList] [float] NULL,
	[NroInterno] [int] NULL,
	[Lista] [nvarchar](1) NULL,
	[Acumulado] [float] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[impCtaCtePrvNet]    Script Date: 22/06/2018 10:05:48 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[impCtaCtePrvNet](
	[Clave] [char](26) NULL,
	[Proveedor] [char](11) NOT NULL,
	[Letra] [char](1) NULL,
	[Tipo] [char](2) NOT NULL,
	[Punto] [char](4) NULL,
	[Numero] [char](8) NOT NULL,
	[fecha] [char](10) NULL,
	[Estado] [char](1) NULL,
	[Vencimiento] [char](10) NULL,
	[Vencimiento1] [char](50) NULL,
	[Total] [float] NULL,
	[Saldo] [float] NULL,
	[OrdFecha] [char](8) NULL,
	[OrdVencimiento] [char](8) NULL,
	[Impre] [char](2) NULL,
	[Empresa] [smallint] NULL,
	[SaldoList] [float] NULL,
	[NroInterno] [int] NULL,
	[Orden] [int] NULL,
	[Acumulado] [float] NULL,
	[Titulo] [char](50) NULL,
	[Titulo1] [char](10) NULL,
	[Titulo2] [char](10) NULL,
	[Titulo3] [char](10) NULL,
	[Titulo4] [char](10) NULL,
	[Impre1] [float] NULL,
	[Impre2] [float] NULL,
	[Impre3] [float] NULL,
	[Impre4] [float] NULL,
	[Impre5] [float] NULL,
	[TituloII] [char](50) NULL,
	[RetIb] [float] NULL,
	[RetGanan] [float] NULL,
	[AcuNeto] [float] NULL,
	[Paridad] [float] NULL,
	[TotalUs] [float] NULL,
	[SaldoUs] [float] NULL,
	[AcumulaUs] [float] NULL,
	[Pago] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[impcyb]    Script Date: 22/06/2018 10:05:48 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[impcyb](
	[Clave] [char](24) NULL,
	[TipoMovi] [char](1) NOT NULL,
	[Proveedor] [char](11) NULL,
	[TipoComp] [char](2) NOT NULL,
	[LetraComp] [char](1) NULL,
	[PuntoComp] [char](4) NOT NULL,
	[NroComp] [char](8) NULL,
	[Renglon] [char](2) NULL,
	[Fecha] [char](10) NULL,
	[Observaciones] [char](50) NULL,
	[Cuenta] [char](10) NULL,
	[Debito] [float] NULL,
	[Credito] [float] NULL,
	[FechaOrd] [char](8) NULL,
	[Titulo] [char](50) NULL,
	[Empresa] [smallint] NULL,
	[DebitoList] [float] NULL,
	[CreditoList] [float] NULL,
	[NroINterno] [int] NULL,
	[Nombre] [char](50) NULL,
	[TituloList] [char](50) NULL,
	[Varios] [char](50) NULL,
	[ClaveOrd] [char](20) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ImpreConsultaRemito]    Script Date: 22/06/2018 10:05:48 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ImpreConsultaRemito](
	[Proveedor] [char](11) NULL,
	[DesProveedor] [char](50) NULL,
	[Remito] [int] NULL,
	[Orden] [int] NULL,
	[Renglon] [int] NULL,
	[Articulo] [char](10) NULL,
	[DesArticulo] [char](50) NULL,
	[Cantidad] [float] NULL,
	[Moneda] [char](10) NULL,
	[Precio] [float] NULL,
	[Condicion] [char](50) NULL,
	[Informe] [int] NULL,
	[CantidadII] [float] NULL,
	[Estado] [char](10) NULL,
	[FAprobacion] [char](10) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ImpreFactura]    Script Date: 22/06/2018 10:05:48 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ImpreFactura](
	[Clave] [char](10) NULL,
	[Numero] [char](8) NULL,
	[Renglon] [int] NULL,
	[Fecha] [char](10) NULL,
	[Razon] [char](50) NULL,
	[Direccion] [char](50) NULL,
	[Localidad] [char](50) NULL,
	[Cliente] [char](6) NULL,
	[Orden] [char](50) NULL,
	[Provincia] [char](50) NULL,
	[Postal] [char](50) NULL,
	[Iva] [char](50) NULL,
	[Cuit] [char](50) NULL,
	[Pago] [char](80) NULL,
	[Vencimiento] [char](10) NULL,
	[Remito] [char](50) NULL,
	[Cantidad] [float] NULL,
	[Descripcion] [char](50) NULL,
	[Precio] [float] NULL,
	[Parcial] [float] NULL,
	[ImpreDespachoI] [char](100) NULL,
	[ImpreDespachoII] [char](100) NULL,
	[Paridad] [float] NULL,
	[ImpoIva] [float] NULL,
	[Impotot] [float] NULL,
	[ImpoNeto] [float] NULL,
	[ImporteIb] [float] NULL,
	[ImporteIbTucuman] [float] NULL,
	[ImporteIbCiudad] [float] NULL,
	[PorceDescuento] [float] NULL,
	[Descuento] [float] NULL,
	[Interes] [float] NULL,
	[ImprePesos1] [char](100) NULL,
	[ImprePesos2] [char](100) NULL,
	[Neto] [float] NULL,
	[Iva1] [float] NULL,
	[Iva2] [float] NULL,
	[IbCiudad] [float] NULL,
	[IbTucuman] [float] NULL,
	[Ib] [float] NULL,
	[Total] [float] NULL,
	[ImpreComprobante] [char](30) NULL,
	[Cae] [char](20) NULL,
	[FechaCae] [char](10) NULL,
	[ImpreBarraI] [char](50) NULL,
	[ImpreBarraII] [char](50) NULL,
	[NetoII] [float] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Imputac]    Script Date: 22/06/2018 10:05:48 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Imputac](
	[Clave] [nvarchar](24) NULL,
	[TipoMovi] [nvarchar](1) NULL,
	[Proveedor] [nvarchar](11) NULL,
	[TipoComp] [nvarchar](2) NULL,
	[LetraComp] [nvarchar](1) NULL,
	[PuntoComp] [nvarchar](4) NULL,
	[NroComp] [nvarchar](8) NULL,
	[Renglon] [nvarchar](2) NULL,
	[Fecha] [nvarchar](10) NULL,
	[Observaciones] [nvarchar](30) NULL,
	[Cuenta] [nvarchar](10) NULL,
	[Debito] [float] NULL,
	[Credito] [float] NULL,
	[FechaOrd] [nvarchar](8) NULL,
	[Titulo] [nvarchar](30) NULL,
	[Empresa] [smallint] NULL,
	[DebitoList] [float] NULL,
	[CreditoList] [float] NULL,
	[NroInterno] [int] NULL,
	[Periodo] [char](10) NULL,
	[PeriodoOrd] [char](8) NULL,
	[TituloII] [char](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Informe]    Script Date: 22/06/2018 10:05:48 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Informe](
	[Clave] [nvarchar](8) NULL,
	[Informe] [int] NULL,
	[Renglon] [int] NULL,
	[Fecha] [nvarchar](10) NULL,
	[Remito] [int] NULL,
	[Proveedor] [nvarchar](11) NULL,
	[Orden] [int] NULL,
	[Articulo] [nvarchar](10) NULL,
	[Cantidad] [float] NULL,
	[Resta] [float] NULL,
	[Fechaord] [nvarchar](8) NULL,
	[WDate] [nvarchar](10) NULL,
	[Envase] [int] NULL,
	[FechaOrden] [char](10) NULL,
	[OrdFechaOrden] [char](8) NULL,
	[Difefecha] [int] NULL,
	[CantidadLaudo] [float] NULL,
	[Dife] [float] NULL,
	[Liberada] [float] NULL,
	[Partida1] [int] NULL,
	[Devuelta] [float] NULL,
	[Partida2] [int] NULL,
	[Certificado1] [int] NULL,
	[Certificado2] [char](50) NULL,
	[Estado1] [int] NULL,
	[Estado2] [char](50) NULL,
	[Lote1] [char](30) NULL,
	[Canti1] [float] NULL,
	[Lote2] [char](30) NULL,
	[Canti2] [float] NULL,
	[Lote3] [char](30) NULL,
	[Canti3] [float] NULL,
	[Lote4] [char](30) NULL,
	[Canti4] [float] NULL,
	[Lote5] [char](30) NULL,
	[Canti5] [float] NULL,
	[Transito] [char](20) NULL,
	[CantidadEnv] [float] NULL,
	[EstadoEnvI] [int] NULL,
	[EstadoEnvII] [int] NULL,
	[EstadoEnvIII] [int] NULL,
	[EstadoEnvIV] [int] NULL,
	[EstadoEnvV] [int] NULL,
	[EstadoEnvVI] [int] NULL,
	[EstadoEnvVII] [int] NULL,
	[EstadoEnvVIII] [int] NULL,
	[EstadoEnvIX] [int] NULL,
	[EstadoEnvX] [int] NULL,
	[FechaVencimiento] [char](10) NULL,
	[OrdFechaVencimiento] [char](8) NULL,
	[ObservaI] [char](50) NULL,
	[ObservaII] [char](50) NULL,
	[ObservaIII] [char](50) NULL,
	[ObservaIV] [char](50) NULL,
	[Expreso] [int] NULL,
	[Chapa] [char](20) NULL,
	[Chofer] [char](50) NULL,
	[Item1] [int] NULL,
	[Item2] [int] NULL,
	[Item3] [int] NULL,
	[Item4] [int] NULL,
	[Item5] [int] NULL,
	[Item6] [int] NULL,
	[Item7] [int] NULL,
	[Item8] [int] NULL,
	[Placa] [char](20) NULL,
	[Rombo] [char](20) NULL,
	[Observaciones] [char](50) NULL,
	[NroDespacho] [char](30) NULL,
	[Procedencia] [char](30) NULL,
	[Observa] [char](50) NULL,
	[Planta] [int] NULL,
	[PartidaProveedor] [char](30) NULL,
	[Lote6] [char](30) NULL,
	[Canti6] [float] NULL,
	[Lote7] [char](30) NULL,
	[Canti7] [float] NULL,
	[Lote8] [char](30) NULL,
	[Canti8] [float] NULL,
	[Lote9] [char](30) NULL,
	[Canti9] [float] NULL,
	[Lote10] [char](30) NULL,
	[Canti10] [float] NULL,
	[Lote11] [char](30) NULL,
	[Canti11] [float] NULL,
	[Lote12] [char](30) NULL,
	[Canti12] [float] NULL,
	[Lote13] [char](30) NULL,
	[Canti13] [float] NULL,
	[Lote14] [char](30) NULL,
	[Canti14] [float] NULL,
	[Lote15] [char](30) NULL,
	[Canti15] [float] NULL,
	[Lote16] [char](30) NULL,
	[Canti16] [float] NULL,
	[Lote17] [char](30) NULL,
	[Canti17] [float] NULL,
	[Lote18] [char](30) NULL,
	[Canti18] [float] NULL,
	[Lote19] [char](30) NULL,
	[Canti19] [float] NULL,
	[Lote20] [char](30) NULL,
	[Canti20] [float] NULL,
	[ImpreCantidad] [float] NULL,
	[ImpreLote] [char](30) NULL,
	[NombreComercial] [char](50) NULL,
	[Desexpreso] [char](50) NULL,
	[FechaElaboracion] [char](10) NULL,
	[ImpreCm02] [char](1) NULL,
	[TipoVencimiento] [int] NULL,
	[Bultos1] [int] NULL,
	[Bultos2] [int] NULL,
	[Bultos3] [int] NULL,
	[Bultos4] [int] NULL,
	[Bultos5] [int] NULL,
	[Bultos6] [int] NULL,
	[Bultos7] [int] NULL,
	[Bultos8] [int] NULL,
	[Bultos9] [int] NULL,
	[Bultos10] [int] NULL,
	[Bultos11] [int] NULL,
	[Bultos12] [int] NULL,
	[Bultos13] [int] NULL,
	[Bultos14] [int] NULL,
	[Bultos15] [int] NULL,
	[Bultos16] [int] NULL,
	[Bultos17] [int] NULL,
	[Bultos18] [int] NULL,
	[Bultos19] [int] NULL,
	[Bultos20] [int] NULL,
	[Necesidad] [char](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InformeConsol]    Script Date: 22/06/2018 10:05:48 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InformeConsol](
	[Informe] [int] NULL,
	[Fecha] [char](10) NULL,
	[OrdFecha] [char](8) NULL,
	[Expreso] [int] NULL,
	[Chapa] [char](20) NULL,
	[Chofer] [char](50) NULL,
	[Item1] [int] NULL,
	[Item2] [int] NULL,
	[Item3] [int] NULL,
	[Item4] [int] NULL,
	[Item5] [int] NULL,
	[Item6] [int] NULL,
	[Item7] [int] NULL,
	[Item8] [int] NULL,
	[Placa] [char](20) NULL,
	[Rombo] [char](20) NULL,
	[Observaciones] [char](50) NULL,
	[DesExpreso] [char](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InformeImpre]    Script Date: 22/06/2018 10:05:48 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InformeImpre](
	[Clave] [char](8) NULL,
	[Impre1] [char](50) NULL,
	[Impre2] [char](50) NULL,
	[Impre3] [char](50) NULL,
	[Impre4] [char](50) NULL,
	[Impre5] [char](50) NULL,
	[Impre6] [char](50) NULL,
	[Impre7] [char](50) NULL,
	[Impre8] [char](50) NULL,
	[Impre9] [char](50) NULL,
	[Impre10] [char](50) NULL,
	[Impre11] [char](50) NULL,
	[Impre12] [char](50) NULL,
	[Impre13] [char](50) NULL,
	[Impre14] [char](50) NULL,
	[Impre15] [char](50) NULL,
	[Impre16] [char](50) NULL,
	[Impre17] [char](50) NULL,
	[Impre18] [char](50) NULL,
	[Impre19] [char](50) NULL,
	[Impre20] [char](50) NULL,
	[Impre21] [char](50) NULL,
	[Impre22] [char](50) NULL,
	[Impre23] [char](50) NULL,
	[Impre24] [char](50) NULL,
	[Impre25] [char](50) NULL,
	[Impre26] [char](50) NULL,
	[Impre27] [char](50) NULL,
	[Impre28] [char](50) NULL,
	[Impre29] [char](50) NULL,
	[Impre30] [char](50) NULL,
	[Valor1] [char](50) NULL,
	[Valor2] [char](50) NULL,
	[Valor3] [char](50) NULL,
	[Valor4] [char](50) NULL,
	[Valor5] [char](50) NULL,
	[Valor6] [char](50) NULL,
	[Valor7] [char](50) NULL,
	[Valor8] [char](50) NULL,
	[Valor9] [char](50) NULL,
	[Valor10] [char](50) NULL,
	[Valor11] [char](50) NULL,
	[Valor12] [char](50) NULL,
	[Valor13] [char](50) NULL,
	[Valor14] [char](50) NULL,
	[Valor15] [char](50) NULL,
	[Valor16] [char](50) NULL,
	[Valor17] [char](50) NULL,
	[Valor18] [char](50) NULL,
	[Valor19] [char](50) NULL,
	[Valor20] [char](50) NULL,
	[Valor21] [char](50) NULL,
	[Valor22] [char](50) NULL,
	[Valor23] [char](50) NULL,
	[Valor24] [char](50) NULL,
	[Valor25] [char](50) NULL,
	[Valor26] [char](50) NULL,
	[Valor27] [char](50) NULL,
	[Valor28] [char](50) NULL,
	[Valor29] [char](50) NULL,
	[Valor30] [char](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Interes]    Script Date: 22/06/2018 10:05:48 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Interes](
	[Codigo] [int] NULL,
	[Cliente] [char](6) NULL,
	[Razon] [char](50) NULL,
	[Fecha] [char](10) NULL,
	[Numero] [char](8) NULL,
	[FechaII] [char](10) NULL,
	[Banco] [char](50) NULL,
	[Importe] [float] NULL,
	[Dias] [int] NULL,
	[Tasa] [float] NULL,
	[Interes] [float] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[iva]    Script Date: 22/06/2018 10:05:48 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[iva](
	[NroInterno] [int] NULL,
	[Proveedor] [nvarchar](11) NULL,
	[Tipo] [nvarchar](2) NULL,
	[Letra] [nvarchar](1) NULL,
	[Punto] [nvarchar](4) NULL,
	[Numero] [nvarchar](8) NULL,
	[Fecha] [nvarchar](10) NULL,
	[Vencimiento] [nvarchar](10) NULL,
	[Periodo] [nvarchar](10) NULL,
	[Neto] [float] NULL,
	[Iva21] [float] NULL,
	[Iva5] [float] NULL,
	[Iva27] [float] NULL,
	[Ib] [float] NULL,
	[Exento] [float] NULL,
	[Contado] [nvarchar](1) NULL,
	[Concepto] [smallint] NULL,
	[Impre] [nvarchar](2) NULL,
	[Ordfecha] [nvarchar](8) NULL,
	[Empresa] [smallint] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[IvaComp]    Script Date: 22/06/2018 10:05:48 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IvaComp](
	[NroInterno] [int] NULL,
	[Proveedor] [nvarchar](11) NULL,
	[Tipo] [nvarchar](2) NULL,
	[Letra] [nvarchar](1) NULL,
	[Punto] [nvarchar](4) NULL,
	[Numero] [nvarchar](8) NULL,
	[Fecha] [nvarchar](10) NULL,
	[Vencimiento] [nvarchar](10) NULL,
	[Vencimiento1] [nvarchar](10) NULL,
	[Periodo] [nvarchar](10) NULL,
	[Neto] [float] NULL,
	[Iva21] [float] NULL,
	[Iva5] [float] NULL,
	[Iva27] [float] NULL,
	[Ib] [float] NULL,
	[Exento] [float] NULL,
	[Contado] [nvarchar](1) NULL,
	[Impre] [nvarchar](2) NULL,
	[Ordfecha] [nvarchar](8) NULL,
	[Empresa] [smallint] NULL,
	[Netolist] [float] NULL,
	[ExentoList] [float] NULL,
	[Paridad] [float] NULL,
	[Pago] [int] NULL,
	[Cai] [char](14) NULL,
	[VtoCai] [char](10) NULL,
	[Despacho] [char](20) NULL,
	[Rechazado] [int] NULL,
	[Remito] [char](30) NULL,
	[NroInternoAsociado] [int] NULL,
	[Iva105] [float] NULL,
	[SoloIva] [int] NULL,
	[RetIb1] [float] NULL,
	[NroRetIb1] [nchar](10) NULL,
	[RetIb2] [float] NULL,
	[NroRetIb2] [nchar](10) NULL,
	[RetIb3] [float] NULL,
	[NroRetIb3] [nchar](10) NULL,
	[RetIb4] [float] NULL,
	[NroRetIb4] [nchar](10) NULL,
	[RetIb5] [float] NULL,
	[NroRetIb5] [nchar](10) NULL,
	[RetIb6] [float] NULL,
	[NroRetIb6] [nchar](10) NULL,
	[RetIb7] [float] NULL,
	[NroRetIb7] [nchar](10) NULL,
	[RetIb8] [float] NULL,
	[NroRetIb8] [nchar](10) NULL,
	[RetIb9] [float] NULL,
	[NroRetIb9] [nchar](10) NULL,
	[RetIb10] [float] NULL,
	[NroRetIb10] [nchar](10) NULL,
	[RetIb11] [float] NULL,
	[NroRetIb11] [nchar](10) NULL,
	[RetIb12] [float] NULL,
	[NroRetIb12] [nchar](10) NULL,
	[RetIb13] [float] NULL,
	[NroRetIb13] [nchar](10) NULL,
	[RetIb14] [float] NULL,
	[NroRetIb14] [nchar](10) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[IvaCompAdicional]    Script Date: 22/06/2018 10:05:48 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IvaCompAdicional](
	[Clave] [char](10) NULL,
	[NroInterno] [int] NULL,
	[Renglon] [int] NULL,
	[Cuit] [char](15) NULL,
	[Tipo] [char](2) NULL,
	[Letra] [char](1) NULL,
	[Punto] [char](4) NULL,
	[Numero] [char](8) NULL,
	[Fecha] [char](10) NULL,
	[OrdFecha] [char](8) NULL,
	[Neto] [float] NULL,
	[Iva21] [float] NULL,
	[Iva27] [float] NULL,
	[Iva105] [float] NULL,
	[PerceIva] [float] NULL,
	[PerceIb] [float] NULL,
	[Exento] [float] NULL,
	[Razon] [char](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ListadoIvaComp]    Script Date: 22/06/2018 10:05:48 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ListadoIvaComp](
	[NroInterno] [int] NULL,
	[Proveedor] [char](11) NULL,
	[Tipo] [char](2) NOT NULL,
	[Letra] [char](1) NULL,
	[Punto] [char](4) NOT NULL,
	[Numero] [char](8) NULL,
	[Fecha] [char](10) NULL,
	[Periodo] [char](10) NULL,
	[Neto] [float] NULL,
	[Iva21] [float] NULL,
	[Iva5] [float] NULL,
	[Iva27] [float] NULL,
	[Iva105] [float] NULL,
	[Ib] [float] NULL,
	[Exento] [float] NULL,
	[Impre] [char](3) NOT NULL,
	[OrdFecha] [char](8) NOT NULL,
	[Titulo] [char](50) NOT NULL,
	[TituloII] [char](50) NOT NULL,
	[Nombre] [char](50) NOT NULL,
	[Cuit] [char](15) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ListaEspe]    Script Date: 22/06/2018 10:05:48 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ListaEspe](
	[Codigo] [char](12) NULL,
	[Descripcion] [char](50) NULL,
	[Codigo1] [int] NULL,
	[Codigo2] [int] NULL,
	[Codigo3] [int] NULL,
	[Codigo4] [int] NULL,
	[Codigo5] [int] NULL,
	[Codigo6] [int] NULL,
	[Codigo7] [int] NULL,
	[Codigo8] [int] NULL,
	[Codigo9] [int] NULL,
	[Codigo10] [int] NULL,
	[Descri1] [char](50) NULL,
	[Descri2] [char](50) NULL,
	[Descri3] [char](50) NULL,
	[Descri4] [char](50) NULL,
	[Descri5] [char](50) NULL,
	[Descri6] [char](50) NULL,
	[Descri7] [char](50) NULL,
	[Descri8] [char](50) NULL,
	[Descri9] [char](50) NULL,
	[Descri10] [char](50) NULL,
	[Valor1] [char](50) NULL,
	[Valor2] [char](50) NULL,
	[Valor3] [char](50) NULL,
	[Valor4] [char](50) NULL,
	[Valor5] [char](50) NULL,
	[Valor6] [char](50) NULL,
	[Valor7] [char](50) NULL,
	[Valor8] [char](50) NULL,
	[Valor9] [char](50) NULL,
	[Valor10] [char](50) NULL,
	[Empresa] [char](50) NULL,
	[Valor11] [char](50) NULL,
	[Valor22] [char](50) NULL,
	[Valor33] [char](50) NULL,
	[Valor44] [char](50) NULL,
	[Valor55] [char](50) NULL,
	[Valor66] [char](50) NULL,
	[Valor77] [char](50) NULL,
	[Valor88] [char](50) NULL,
	[Valor99] [char](50) NULL,
	[Valor1010] [char](50) NULL,
	[Version] [int] NULL,
	[Responsable] [char](50) NULL,
	[Fecha] [char](10) NULL,
	[Codigo11] [int] NULL,
	[Codigo12] [int] NULL,
	[Codigo13] [int] NULL,
	[Codigo14] [int] NULL,
	[Codigo15] [int] NULL,
	[Codigo16] [int] NULL,
	[Codigo17] [int] NULL,
	[Codigo18] [int] NULL,
	[Codigo19] [int] NULL,
	[Codigo20] [int] NULL,
	[Descri11] [char](50) NULL,
	[Descri12] [char](50) NULL,
	[Descri13] [char](50) NULL,
	[Descri14] [char](50) NULL,
	[Descri15] [char](50) NULL,
	[Descri16] [char](50) NULL,
	[Descri17] [char](50) NULL,
	[Descri18] [char](50) NULL,
	[Descri19] [char](50) NULL,
	[Descri20] [char](50) NULL,
	[ZValor1] [char](50) NULL,
	[ZValor2] [char](50) NULL,
	[ZValor3] [char](50) NULL,
	[ZValor4] [char](50) NULL,
	[ZValor5] [char](50) NULL,
	[ZValor6] [char](50) NULL,
	[ZValor7] [char](50) NULL,
	[ZValor8] [char](50) NULL,
	[ZValor9] [char](50) NULL,
	[ZValor10] [char](50) NULL,
	[ZValor11] [char](50) NULL,
	[ZValor22] [char](50) NULL,
	[ZValor33] [char](50) NULL,
	[ZValor44] [char](50) NULL,
	[ZValor55] [char](50) NULL,
	[ZValor66] [char](50) NULL,
	[ZValor77] [char](50) NULL,
	[ZValor88] [char](50) NULL,
	[ZValor99] [char](50) NULL,
	[ZValor1010] [char](50) NULL,
	[ControlCambio] [char](100) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ListaIvaCompras]    Script Date: 22/06/2018 10:05:48 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ListaIvaCompras](
	[NroInterno] [int] NULL,
	[Proveedor] [char](11) NULL,
	[Tipo] [char](2) NOT NULL,
	[Letra] [char](1) NULL,
	[Punto] [char](4) NOT NULL,
	[Numero] [char](8) NULL,
	[Fecha] [char](10) NULL,
	[Periodo] [char](10) NULL,
	[Neto] [float] NULL,
	[Iva21] [float] NULL,
	[Iva5] [float] NULL,
	[Iva27] [float] NULL,
	[Iva105] [float] NULL,
	[Ib] [float] NULL,
	[Exento] [float] NULL,
	[Impre] [char](3) NOT NULL,
	[OrdFecha] [char](8) NOT NULL,
	[Titulo] [char](50) NOT NULL,
	[TituloII] [char](50) NOT NULL,
	[Nombre] [char](50) NOT NULL,
	[Cuit] [char](15) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ListaOrdenII]    Script Date: 22/06/2018 10:05:48 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ListaOrdenII](
	[Clave] [char](10) NULL,
	[Orden] [int] NULL,
	[Renglon] [int] NULL,
	[RenglonII] [int] NULL,
	[Fecha] [char](10) NULL,
	[Proveedor] [char](11) NULL,
	[Articulo] [char](10) NULL,
	[Cantidad] [float] NULL,
	[FechaEntrega] [char](10) NULL,
	[Saldo] [float] NULL,
	[Carpeta] [int] NULL,
	[Texto1] [char](12) NULL,
	[Texto2] [char](50) NULL,
	[PedidoImpo] [char](20) NULL,
	[FechaImpo] [char](10) NULL,
	[TipoImpo] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[lugarentrega]    Script Date: 22/06/2018 10:05:48 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[lugarentrega](
	[codigo] [char](10) NULL,
	[descripcion] [char](80) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Movban]    Script Date: 22/06/2018 10:05:48 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Movban](
	[da] [int] NULL,
	[Banco] [int] NULL,
	[Fecha] [char](10) NOT NULL,
	[FechaOrd] [char](8) NULL,
	[Acredita] [char](10) NOT NULL,
	[AcreditaOrd] [char](8) NULL,
	[Observaciones] [char](50) NULL,
	[Numero] [char](10) NULL,
	[Debito] [float] NULL,
	[Credito] [float] NULL,
	[Comprobante] [char](8) NULL,
	[Empresa] [int] NULL,
	[Titulo] [char](50) NULL,
	[Titulo1] [char](50) NULL,
	[Proveedor] [char](11) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MovEnv]    Script Date: 22/06/2018 10:05:48 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MovEnv](
	[Clave] [nvarchar](9) NULL,
	[Tipo] [nvarchar](1) NULL,
	[Codigo] [int] NULL,
	[Renglon] [int] NULL,
	[Fecha] [nvarchar](10) NULL,
	[FechaOrd] [nvarchar](8) NULL,
	[Cliente] [nvarchar](6) NULL,
	[Envase] [int] NULL,
	[Movimiento] [nvarchar](1) NULL,
	[Cantidad] [float] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Movgas]    Script Date: 22/06/2018 10:05:48 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Movgas](
	[Clave] [char](8) NULL,
	[Carpeta] [int] NULL,
	[Renglon] [int] NULL,
	[Fecha] [char](10) NULL,
	[Derechos] [float] NULL,
	[Orden] [int] NULL,
	[Concepto] [int] NULL,
	[Importe] [float] NULL,
	[Auxiliar] [float] NULL,
	[OrdFecha] [char](8) NULL,
	[Proveedor] [char](11) NULL,
	[Origen] [char](30) NULL,
	[Moneda] [int] NULL,
	[Marca] [char](1) NULL,
	[ImpoDerechos] [float] NULL,
	[FechaLlegada] [char](10) NULL,
	[OrdFechaLlegada] [char](8) NULL,
	[CostoFlete] [float] NULL,
	[Gastos] [float] NULL,
	[Pagado] [float] NULL,
	[Empresa] [int] NULL,
	[TipoImpo] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MovGasCon]    Script Date: 22/06/2018 10:05:48 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MovGasCon](
	[Clave] [char](10) NULL,
	[Empresa] [int] NULL,
	[Carpeta] [int] NULL,
	[Fecha] [char](10) NULL,
	[Derechos] [float] NULL,
	[Orden] [int] NULL,
	[Concepto] [int] NULL,
	[Importe] [float] NULL,
	[Auxiliar] [float] NULL,
	[OrdFecha] [char](8) NULL,
	[Proveedor] [char](11) NULL,
	[Origen] [char](30) NULL,
	[Moneda] [int] NULL,
	[Marca] [char](1) NULL,
	[ImpoDerechos] [float] NULL,
	[FechaLLegada] [char](10) NULL,
	[OrdFechaLLegada] [char](8) NULL,
	[CostoFlete] [float] NULL,
	[Gastos] [float] NULL,
	[Pagado] [float] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MovGasParcial]    Script Date: 22/06/2018 10:05:48 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MovGasParcial](
	[Clave] [char](8) NULL,
	[Codigo] [int] NULL,
	[Renglon] [int] NULL,
	[Fecha] [char](10) NULL,
	[Carpeta] [int] NULL,
	[Concepto] [int] NULL,
	[Importe] [float] NULL,
	[OrdFecha] [char](8) NULL,
	[Marca] [char](1) NULL,
	[Empresa] [int] NULL,
	[Orden] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MovGasParcialArti]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MovGasParcialArti](
	[Clave] [char](8) NULL,
	[Codigo] [int] NULL,
	[Renglon] [int] NULL,
	[Fecha] [char](10) NULL,
	[Carpeta] [int] NULL,
	[Articulo] [char](10) NULL,
	[Cantidad] [float] NULL,
	[OrdFecha] [char](8) NULL,
	[Marca] [char](1) NULL,
	[Empresa] [int] NULL,
	[Orden] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Movlab]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Movlab](
	[Clave] [nvarchar](8) NULL,
	[Codigo] [int] NULL,
	[Renglon] [int] NULL,
	[Fecha] [nvarchar](10) NULL,
	[Tipo] [nvarchar](1) NULL,
	[Articulo] [nvarchar](10) NULL,
	[Terminado] [nvarchar](12) NULL,
	[Cantidad] [float] NULL,
	[FechaOrd] [nvarchar](8) NULL,
	[Movi] [nvarchar](1) NULL,
	[Tipomov] [nvarchar](1) NULL,
	[Observaciones] [nvarchar](50) NULL,
	[WDate] [nvarchar](10) NULL,
	[Marca] [nvarchar](1) NULL,
	[Lote] [int] NULL,
	[Marcaant] [char](1) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Movvar]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Movvar](
	[Clave] [nvarchar](8) NULL,
	[Codigo] [int] NULL,
	[Renglon] [int] NULL,
	[Fecha] [nvarchar](10) NULL,
	[Tipo] [nvarchar](1) NULL,
	[Articulo] [nvarchar](10) NULL,
	[Terminado] [nvarchar](12) NULL,
	[Cantidad] [float] NULL,
	[FechaOrd] [nvarchar](8) NULL,
	[Movi] [nvarchar](1) NULL,
	[Tipomov] [nvarchar](1) NULL,
	[Observaciones] [nvarchar](50) NULL,
	[WDate] [nvarchar](10) NULL,
	[Marca] [nvarchar](1) NULL,
	[Lote] [int] NULL,
	[Marcaant] [char](1) NULL,
	[Guia] [char](10) NULL,
	[Planta] [int] NULL,
	[Descripcion] [char](50) NULL,
	[Operador] [int] NULL,
	[DesOperador] [char](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NombreComercial]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NombreComercial](
	[Clave] [char](14) NULL,
	[Terminado] [char](12) NULL,
	[Renglon] [int] NULL,
	[Nombre] [char](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NroCarpeta]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NroCarpeta](
	[Carpeta] [int] NULL,
	[Planta] [int] NULL,
	[Orden] [int] NULL,
	[Proveedor] [char](11) NULL,
	[Fecha] [char](10) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Numero]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Numero](
	[Codigo] [nvarchar](2) NULL,
	[Numero] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NumeroRemito]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NumeroRemito](
	[Codigo] [int] NULL,
	[Punto] [int] NULL,
	[Desde] [int] NULL,
	[Hasta] [int] NULL,
	[Cai] [nchar](20) NULL,
	[Fecha] [nchar](10) NULL,
	[Ultimo] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ObservaOrden]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ObservaOrden](
	[Clave] [char](8) NULL,
	[Carpeta] [int] NULL,
	[Renglon] [int] NULL,
	[Orden] [int] NULL,
	[Texto1] [char](12) NULL,
	[Texto2] [char](80) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ObservaOrdenCertificado]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ObservaOrdenCertificado](
	[Orden] [int] NULL,
	[Articulo] [char](10) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ObservaOrdenImpo]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ObservaOrdenImpo](
	[Orden] [int] NULL,
	[Descri11] [char](70) NULL,
	[Descri12] [char](70) NULL,
	[Descri13] [char](70) NULL,
	[Descri14] [char](70) NULL,
	[Descri21] [char](70) NULL,
	[Descri22] [char](70) NULL,
	[Descri23] [char](70) NULL,
	[Descri31] [char](70) NULL,
	[Descri32] [char](70) NULL,
	[Descri33] [char](70) NULL,
	[Descri40] [char](70) NULL,
	[Descri41] [char](70) NULL,
	[Descri42] [char](70) NULL,
	[Descri43] [char](70) NULL,
	[Descri44] [char](70) NULL,
	[Descri45] [char](70) NULL,
	[Descri46] [char](70) NULL,
	[Descri47] [char](70) NULL,
	[Descri48] [char](70) NULL,
	[Descri49] [char](70) NULL,
	[Descri51] [char](50) NULL,
	[Descri52] [char](50) NULL,
	[Descri53] [char](50) NULL,
	[Descri54] [char](50) NULL,
	[Descri55] [char](50) NULL,
	[Descri56] [char](50) NULL,
	[Descri57] [char](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Operador]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Operador](
	[Operador] [int] NULL,
	[Descripcion] [char](50) NULL,
	[Clave] [char](10) NULL,
	[GrabaI] [char](1) NULL,
	[GrabaII] [char](1) NULL,
	[GrabaIII] [char](1) NULL,
	[GrabaIV] [char](1) NULL,
	[NroResponsable] [int] NULL,
	[Inversion] [char](1) NULL,
	[ClaveInversion] [char](10) NULL,
	[Sector] [int] NULL,
	[EvaluaTransporte] [char](1) NULL,
	[EvaluaMateria] [char](1) NULL,
	[ClaveGuia] [char](10) NULL,
	[Email] [char](100) NULL,
	[Vendedor] [int] NULL,
	[Sistemas] [char](1) NULL,
	[Mantenimiento] [char](1) NULL,
	[EvalProveedores] [char](1) NULL,
	[GrabaV] [char](1) NULL,
	[FechaGrabaV] [char](10) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orden]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orden](
	[Clave] [nvarchar](8) NULL,
	[Orden] [int] NULL,
	[Renglon] [int] NULL,
	[Fecha] [nvarchar](10) NULL,
	[Proveedor] [nvarchar](11) NULL,
	[Articulo] [nvarchar](10) NULL,
	[Cantidad] [float] NULL,
	[Precio] [float] NULL,
	[Fecha1] [nvarchar](10) NULL,
	[Fecha2] [nvarchar](10) NULL,
	[Condicion] [nvarchar](40) NULL,
	[Recibida] [float] NULL,
	[Saldo] [float] NULL,
	[FechaOrd] [nvarchar](8) NULL,
	[Liberada] [float] NULL,
	[Devuelta] [float] NULL,
	[Fechaentrega] [nvarchar](10) NULL,
	[WDate] [nvarchar](10) NULL,
	[OrdFecha2] [char](8) NULL,
	[Moneda] [int] NULL,
	[Tipo] [int] NULL,
	[Carpeta] [int] NULL,
	[Derechos] [float] NULL,
	[Origen] [char](50) NULL,
	[Impresion] [char](1) NULL,
	[Leyenda] [int] NULL,
	[PedidoImpo] [char](20) NULL,
	[FechaImpo] [char](10) NULL,
	[OrdFechaImpo] [char](8) NULL,
	[TipoImpo] [int] NULL,
	[Observaciones] [char](50) NULL,
	[PagoDespacho] [int] NULL,
	[FechaLLegada] [char](10) NULL,
	[ImpoDespacho] [float] NULL,
	[TipoPago] [int] NULL,
	[VtoDespacho] [char](10) NULL,
	[OrdVtoDespacho] [char](8) NULL,
	[Marca] [char](1) NULL,
	[ImpoLetra] [float] NULL,
	[VtoLetra] [char](10) NULL,
	[OrdVtoLetra] [char](8) NULL,
	[PagoLetra] [int] NULL,
	[Flete] [float] NULL,
	[VtoLetraII] [char](10) NULL,
	[OrdVtoLetraII] [char](8) NULL,
	[EntregaI] [int] NULL,
	[EntregaII] [int] NULL,
	[Solicitud1] [int] NULL,
	[Solicitud2] [int] NULL,
	[Solicitud3] [int] NULL,
	[ImpreMarca] [char](50) NULL,
	[Planta] [char](10) NULL,
	[CondPago] [char](50) NULL,
	[TotalFob] [float] NULL,
	[ObservaII] [char](50) NULL,
	[Despachante] [int] NULL,
	[Posicion] [char](20) NULL,
	[Tarjeta] [int] NULL,
	[Cuotas] [int] NULL,
	[MesCuota] [int] NULL,
	[AnoCuota] [int] NULL,
	[ImpresionII] [char](1) NULL,
	[Bultos] [int] NULL,
	[ImpreEmpresa] [char](50) NULL,
	[ImpreLeyenda] [char](50) NULL,
	[ImpreTipoOrden] [char](50) NULL,
	[DJai] [char](30) NULL,
	[Paso] [int] NULL,
	[Lista] [char](1) NULL,
	[MarcaActualiza] [char](1) NULL,
	[FechaDJai] [char](10) NULL,
	[FechaEmbarque] [char](10) NULL,
	[PagoParcialLetra] [float] NULL,
	[Destino] [int] NULL,
	[ImpresionIII] [char](1) NULL,
	[Baja] [char](1) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pago]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pago](
	[Pago] [int] NULL,
	[Nombre] [nvarchar](50) NULL,
	[Dias] [real] NULL,
	[Plazo] [real] NULL,
	[Tasa] [real] NULL,
	[Descuento] [real] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[pagocarpetas]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[pagocarpetas](
	[clave] [nvarchar](10) NULL,
	[orden] [nvarchar](10) NULL,
	[renglon] [nvarchar](2) NULL,
	[proveedor] [nvarchar](11) NULL,
	[importe] [nvarchar](12) NULL,
	[importe2] [float] NULL,
	[carpeta] [int] NULL,
	[fecha] [char](10) NULL,
	[ofecha] [char](10) NULL,
	[despacho] [nvarchar](50) NULL,
	[saldo] [nvarchar](20) NULL,
	[acumulado] [nvarchar](8) NULL,
	[observaciones] [nvarchar](50) NULL,
	[pago] [nvarchar](12) NULL,
	[pago2] [float] NULL,
	[recibo] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pagos]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pagos](
	[Clave] [nvarchar](8) NULL,
	[Orden] [nvarchar](6) NULL,
	[Renglon] [nvarchar](2) NULL,
	[Proveedor] [nvarchar](11) NULL,
	[Fecha] [nvarchar](10) NULL,
	[FechaOrd] [nvarchar](8) NULL,
	[TipoOrd] [nvarchar](1) NULL,
	[RetGanancias] [float] NULL,
	[RetIva] [float] NULL,
	[RetOtra] [float] NULL,
	[Retencion] [float] NULL,
	[TipoReg] [nvarchar](1) NULL,
	[Tipo1] [nvarchar](2) NULL,
	[Letra1] [nvarchar](1) NULL,
	[Punto1] [nvarchar](4) NULL,
	[Numero1] [nvarchar](8) NULL,
	[Importe1] [float] NULL,
	[Tipo2] [nvarchar](2) NULL,
	[Numero2] [nvarchar](8) NULL,
	[Fecha2] [nvarchar](10) NULL,
	[banco2] [smallint] NULL,
	[Importe2] [float] NULL,
	[Observaciones2] [nvarchar](30) NULL,
	[Empresa] [smallint] NULL,
	[Concepto] [smallint] NULL,
	[Observaciones] [nvarchar](100) NULL,
	[Importe] [float] NULL,
	[FechaOrd2] [nvarchar](8) NULL,
	[Consecionaria] [smallint] NULL,
	[ImpoList] [float] NULL,
	[Cuenta] [nvarchar](10) NULL,
	[Carpeta] [int] NULL,
	[ImpoCarpeta] [float] NULL,
	[Carpeta1] [int] NULL,
	[ImpoCarpeta1] [float] NULL,
	[Carpeta2] [int] NULL,
	[ImpoCarpeta2] [float] NULL,
	[Carpeta3] [int] NULL,
	[ImpoCarpeta3] [float] NULL,
	[Carpeta4] [int] NULL,
	[ImpoCarpeta4] [float] NULL,
	[CertificadoGan] [int] NULL,
	[CertificadoIb] [int] NULL,
	[Paridad] [float] NULL,
	[CertificadoIva] [int] NULL,
	[ClaveRecibo] [char](8) NULL,
	[Cuit] [char](15) NULL,
	[ImporteCheque] [float] NULL,
	[NumeroCheque] [char](8) NULL,
	[FechaCheque] [char](10) NULL,
	[BancoCheque] [char](30) NULL,
	[RetIbCiudad] [float] NULL,
	[CertificadoIbCiudad] [int] NULL,
	[ImpoNeto] [float] NULL,
	[Carpeta5] [int] NULL,
	[Carpeta6] [int] NULL,
	[Carpeta7] [int] NULL,
	[Carpeta8] [int] NULL,
	[Carpeta9] [int] NULL,
	[Titulo] [char](50) NULL,
	[TituloI] [char](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PagosResumen]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PagosResumen](
	[Corte] [int] NULL,
	[Orden] [int] NULL,
	[Renglon] [int] NULL,
	[Proveedor] [char](11) NULL,
	[Fecha] [char](10) NULL,
	[Cuit] [char](15) NULL,
	[ImporteCheque] [float] NULL,
	[NumeroCheque] [char](8) NULL,
	[FechaCheque] [char](10) NULL,
	[BancoCheque] [char](30) NULL,
	[Razon] [char](50) NULL,
	[CuitProveedor] [char](20) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Precios]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Precios](
	[Clave] [nvarchar](18) NULL,
	[Cliente] [nvarchar](6) NULL,
	[Terminado] [nvarchar](12) NULL,
	[Precio] [float] NULL,
	[Descripcion] [nvarchar](50) NULL,
	[Fecha1] [nvarchar](10) NULL,
	[Factura1] [nvarchar](6) NULL,
	[Precio1] [float] NULL,
	[Cantidad1] [float] NULL,
	[Fecha2] [nvarchar](10) NULL,
	[Factura2] [nvarchar](6) NULL,
	[Precio2] [float] NULL,
	[Cantidad2] [float] NULL,
	[Fecha3] [nvarchar](10) NULL,
	[Factura3] [nvarchar](6) NULL,
	[Precio3] [float] NULL,
	[Cantidad3] [float] NULL,
	[Fecha4] [nvarchar](10) NULL,
	[Factura4] [nvarchar](6) NULL,
	[Precio4] [float] NULL,
	[Cantidad4] [float] NULL,
	[Fecha5] [nvarchar](10) NULL,
	[Factura5] [nvarchar](6) NULL,
	[Precio5] [float] NULL,
	[Cantidad5] [float] NULL,
	[WDate] [nvarchar](10) NULL,
	[Fecha] [char](10) NULL,
	[Pago] [int] NULL,
	[Estado] [int] NULL,
	[DescripcionFarma] [char](50) NULL,
	[DescripcionIngles] [char](50) NULL,
	[DescripcionFarmaIngles] [char](50) NULL,
	[PrecioAnterior] [float] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PreciosII]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PreciosII](
	[Clave] [char](14) NULL,
	[Terminado] [char](12) NULL,
	[Renglon] [int] NULL,
	[Nombre] [char](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PreciosMp]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PreciosMp](
	[Clave] [nvarchar](16) NULL,
	[Cliente] [nvarchar](6) NULL,
	[Articulo] [nvarchar](10) NULL,
	[Precio] [float] NULL,
	[Fecha1] [nvarchar](10) NULL,
	[Factura1] [nvarchar](6) NULL,
	[Precio1] [float] NULL,
	[Cantidad1] [float] NULL,
	[Fecha2] [nvarchar](10) NULL,
	[Factura2] [nvarchar](6) NULL,
	[Precio2] [float] NULL,
	[Cantidad2] [float] NULL,
	[Fecha3] [nvarchar](10) NULL,
	[Factura3] [nvarchar](6) NULL,
	[Precio3] [float] NULL,
	[Cantidad3] [float] NULL,
	[Fecha4] [nvarchar](10) NULL,
	[Factura4] [nvarchar](6) NULL,
	[Precio4] [float] NULL,
	[Cantidad4] [float] NULL,
	[Fecha5] [nvarchar](10) NULL,
	[Factura5] [nvarchar](6) NULL,
	[Precio5] [float] NULL,
	[Cantidad5] [float] NULL,
	[WDate] [nvarchar](10) NULL,
	[Fecha] [char](10) NULL,
	[Pago] [int] NULL,
	[Estado] [int] NULL,
	[PrecioAnterior] [float] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Proveedor]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Proveedor](
	[Proveedor] [nvarchar](11) NULL,
	[Nombre] [nvarchar](50) NULL,
	[Direccion] [nvarchar](50) NULL,
	[Localidad] [nvarchar](50) NULL,
	[Provincia] [nvarchar](2) NULL,
	[Postal] [nvarchar](4) NULL,
	[Cuit] [nvarchar](15) NULL,
	[Telefono] [nvarchar](100) NULL,
	[Email] [nvarchar](400) NULL,
	[Observaciones] [nvarchar](200) NULL,
	[Tipo] [nvarchar](2) NULL,
	[Iva] [nvarchar](1) NULL,
	[Dias] [nvarchar](20) NULL,
	[Empresa] [smallint] NULL,
	[Cuenta] [nvarchar](10) NULL,
	[Importe1] [float] NULL,
	[Importe2] [float] NULL,
	[Importe3] [float] NULL,
	[Importe4] [float] NULL,
	[Importe5] [float] NULL,
	[Importe6] [float] NULL,
	[NombreCheque] [nvarchar](50) NULL,
	[WDate] [char](10) NULL,
	[CodIb] [int] NULL,
	[NroIb] [char](20) NULL,
	[NroInsc] [char](15) NULL,
	[Cai] [char](14) NULL,
	[VtoCai] [char](10) NULL,
	[TipoProv] [int] NULL,
	[CategoriaI] [int] NULL,
	[CategoriaII] [int] NULL,
	[Iso] [int] NULL,
	[VtoIso] [char](10) NULL,
	[Impre1] [int] NULL,
	[Impre2] [int] NULL,
	[Impre3] [int] NULL,
	[Impre4] [int] NULL,
	[Impre5] [int] NULL,
	[Impre6] [int] NULL,
	[Impre7] [float] NULL,
	[Impre8] [float] NULL,
	[Impre9] [float] NULL,
	[Impre10] [int] NULL,
	[Impre11] [char](10) NULL,
	[Impre12] [char](10) NULL,
	[Impre13] [char](10) NULL,
	[Impre14] [char](10) NULL,
	[Periodo] [char](75) NULL,
	[Region] [int] NULL,
	[PorceIb] [float] NULL,
	[Estado] [int] NULL,
	[Califica] [float] NULL,
	[FechaCalifica] [char](10) NULL,
	[OrdFechaCalifica] [char](8) NULL,
	[ObservacionesII] [text] NULL,
	[FechaCategoria] [char](10) NULL,
	[OrdFechaCategoria] [char](8) NULL,
	[Embargo] [char](1) NULL,
	[FechaNroInsc] [char](10) NULL,
	[OrdFechaNroInsc] [char](8) NULL,
	[PorceIbCaba] [float] NULL,
	[Impre] [char](1) NULL,
	[PorceIbCabaAnterior] [float] NULL,
	[Cufe] [char](20) NULL,
	[CufeII] [char](20) NULL,
	[CufeIII] [char](20) NULL,
	[DirCufe] [char](50) NULL,
	[DirCufeII] [char](50) NULL,
	[DirCufeIII] [char](50) NULL,
	[CodIbCaba] [int] NULL,
	[IbCiudadII] [int] NULL,
	[PaginaWeb] [nvarchar](50) NULL,
	[ContactoNombre1] [nvarchar](50) NULL,
	[ContactoCargo1] [nvarchar](50) NULL,
	[ContactoTelefono1] [nvarchar](50) NULL,
	[ContactoEmail1] [nvarchar](50) NULL,
	[ContactoNombre2] [nvarchar](50) NULL,
	[ContactoCargo2] [nvarchar](50) NULL,
	[ContactoTelefono2] [nvarchar](50) NULL,
	[ContactoEmail2] [nvarchar](50) NULL,
	[ContactoNombre3] [nvarchar](50) NULL,
	[ContactoCargo3] [nvarchar](50) NULL,
	[ContactoTelefono3] [nvarchar](50) NULL,
	[ContactoEmail3] [nvarchar](50) NULL,
	[ClienteAsociado] [nvarchar](6) NULL,
	[Inhabilitado] [char](1) NULL,
	[Evaluador] [int] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProveedorAdicional]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProveedorAdicional](
	[Proveedor] [char](11) NULL,
	[Descri11] [char](70) NULL,
	[Descri12] [char](70) NULL,
	[Descri13] [char](70) NULL,
	[Descri14] [char](70) NULL,
	[Descri21] [char](70) NULL,
	[Descri22] [char](70) NULL,
	[Descri23] [char](70) NULL,
	[Descri31] [char](70) NULL,
	[Descri32] [char](70) NULL,
	[Descri33] [char](70) NULL,
	[Descri40] [char](70) NULL,
	[Descri41] [char](70) NULL,
	[Descri42] [char](70) NULL,
	[Descri43] [char](70) NULL,
	[Descri44] [char](70) NULL,
	[Descri45] [char](50) NULL,
	[Descri46] [char](70) NULL,
	[Descri47] [char](70) NULL,
	[Descri48] [char](70) NULL,
	[Descri49] [char](70) NULL,
	[Descri51] [char](50) NULL,
	[Descri52] [char](50) NULL,
	[Descri53] [char](50) NULL,
	[Descri54] [char](50) NULL,
	[Descri55] [char](50) NULL,
	[Descri56] [char](50) NULL,
	[Descri57] [char](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProveedorSelectivo]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProveedorSelectivo](
	[Proveedor] [nvarchar](11) NULL,
	[Fecha] [nvarchar](10) NULL,
	[FechaOrd] [nvarchar](8) NULL,
	[Observaciones] [char](100) NULL,
	[Desde] [char](10) NULL,
	[Hasta] [char](10) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Provincia]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Provincia](
	[Provincia] [nvarchar](2) NULL,
	[Nombre] [nvarchar](30) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Recibos]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Recibos](
	[Clave] [char](8) NULL,
	[Recibo] [char](6) NULL,
	[Renglon] [char](2) NULL,
	[Cliente] [char](6) NULL,
	[Fecha] [char](10) NULL,
	[Fechaord] [char](8) NULL,
	[TipoRec] [char](1) NULL,
	[RetGanancias] [float] NULL,
	[RetIva] [float] NULL,
	[RetOtra] [float] NULL,
	[Retencion] [float] NULL,
	[TipoReg] [char](1) NULL,
	[Tipo1] [char](2) NULL,
	[Letra1] [char](1) NULL,
	[Punto1] [char](4) NULL,
	[Numero1] [char](8) NULL,
	[Importe1] [float] NULL,
	[Tipo2] [char](2) NULL,
	[Numero2] [char](8) NULL,
	[Fecha2] [char](10) NULL,
	[banco2] [char](20) NULL,
	[Importe2] [float] NULL,
	[Estado2] [char](1) NULL,
	[Empresa] [smallint] NULL,
	[FechaOrd2] [char](8) NULL,
	[Importe] [float] NULL,
	[Observaciones] [char](50) NULL,
	[Impolist] [float] NULL,
	[Impo1list] [float] NULL,
	[Destino] [char](50) NULL,
	[Cuenta] [char](10) NULL,
	[Marca] [char](1) NULL,
	[FechaDepo] [char](10) NULL,
	[FechaDepoOrd] [char](8) NULL,
	[Paridad] [float] NULL,
	[RetSuss] [float] NULL,
	[ComproGanan] [char](10) NULL,
	[ComproIva] [char](10) NULL,
	[ComproIb] [char](10) NULL,
	[ComproSuss] [char](10) NULL,
	[ClaveCheque] [char](31) NULL,
	[Cuit] [char](15) NULL,
	[Provisorio] [char](10) NULL,
	[BancoCheque] [char](3) NULL,
	[SucursalCheque] [char](3) NULL,
	[ChequeCheque] [char](8) NULL,
	[CuentaCheque] [char](11) NULL,
	[DifCambio] [float] NULL,
	[ImpreObserva] [char](50) NULL,
	[FechaLista] [char](10) NULL,
	[OrdFechaLista] [char](8) NULL,
	[MarcaII] [char](1) NULL,
	[MarcaDebito] [char](1) NULL,
	[RetIb1] [float] NULL,
	[NroRetIb1] [float] NULL,
	[RetIb2] [float] NULL,
	[NroRetIb2] [float] NULL,
	[RetIb3] [float] NULL,
	[NroRetIb3] [float] NULL,
	[RetIb4] [float] NULL,
	[NroRetIb4] [float] NULL,
	[RetIb5] [float] NULL,
	[NroRetIb5] [float] NULL,
	[RetIb6] [float] NULL,
	[NroRetIb6] [float] NULL,
	[RetIb7] [float] NULL,
	[NroRetIb7] [float] NULL,
	[RetIb8] [float] NULL,
	[NroRetIb8] [float] NULL,
	[MarcaDiferencia] [char](1) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RecibosListado]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RecibosListado](
	[Clave] [char](8) NULL,
	[Recibo] [char](6) NULL,
	[Renglon] [char](2) NULL,
	[Cliente] [char](6) NULL,
	[Fecha] [char](10) NULL,
	[Fechaord] [char](8) NULL,
	[TipoRec] [char](1) NULL,
	[RetGanancias] [float] NULL,
	[RetIva] [float] NULL,
	[RetOtra] [float] NULL,
	[Retencion] [float] NULL,
	[TipoReg] [char](1) NULL,
	[Tipo1] [char](2) NULL,
	[Letra1] [char](1) NULL,
	[Punto1] [char](4) NULL,
	[Numero1] [char](8) NULL,
	[Importe1] [float] NULL,
	[Tipo2] [char](2) NULL,
	[Numero2] [char](8) NULL,
	[Fecha2] [char](10) NULL,
	[banco2] [char](20) NULL,
	[Importe2] [float] NULL,
	[Estado2] [char](1) NULL,
	[Empresa] [smallint] NULL,
	[FechaOrd2] [char](8) NULL,
	[Importe] [float] NULL,
	[Observaciones] [char](50) NULL,
	[Impolist] [float] NULL,
	[Impo1list] [float] NULL,
	[Destino] [char](50) NULL,
	[Cuenta] [char](10) NULL,
	[Marca] [char](1) NULL,
	[FechaDepo] [char](10) NULL,
	[FechaDepoOrd] [char](8) NULL,
	[Paridad] [float] NULL,
	[RetSuss] [float] NULL,
	[ComproGanan] [char](10) NULL,
	[ComproIva] [char](10) NULL,
	[ComproIb] [char](10) NULL,
	[ComproSuss] [char](10) NULL,
	[ClaveCheque] [char](31) NULL,
	[Cuit] [char](15) NULL,
	[Provisorio] [char](10) NULL,
	[BancoCheque] [char](3) NULL,
	[SucursalCheque] [char](3) NULL,
	[ChequeCheque] [char](8) NULL,
	[CuentaCheque] [char](11) NULL,
	[DifCambio] [float] NULL,
	[ImpreObserva] [char](50) NULL,
	[FechaLista] [char](10) NULL,
	[OrdFechaLista] [char](8) NULL,
	[MarcaII] [char](1) NULL,
	[MarcaDebito] [char](1) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RecibosProvi]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RecibosProvi](
	[Clave] [nvarchar](8) NULL,
	[Recibo] [nvarchar](6) NULL,
	[Renglon] [nvarchar](2) NULL,
	[Cliente] [nvarchar](6) NULL,
	[Fecha] [nvarchar](10) NULL,
	[Fechaord] [nvarchar](8) NULL,
	[TipoRec] [nvarchar](1) NULL,
	[RetGanancias] [float] NULL,
	[RetIva] [float] NULL,
	[RetOtra] [float] NULL,
	[Retencion] [float] NULL,
	[TipoReg] [nvarchar](1) NULL,
	[Tipo1] [nvarchar](2) NULL,
	[Letra1] [nvarchar](1) NULL,
	[Punto1] [nvarchar](4) NULL,
	[Numero1] [nvarchar](8) NULL,
	[Importe1] [float] NULL,
	[Tipo2] [nvarchar](2) NULL,
	[Numero2] [nvarchar](8) NULL,
	[Fecha2] [nvarchar](10) NULL,
	[banco2] [nvarchar](20) NULL,
	[Importe2] [float] NULL,
	[Estado2] [nvarchar](1) NULL,
	[Empresa] [smallint] NULL,
	[FechaOrd2] [nvarchar](8) NULL,
	[Importe] [float] NULL,
	[Observaciones] [nvarchar](50) NULL,
	[Impolist] [float] NULL,
	[Impo1list] [float] NULL,
	[Destino] [nvarchar](50) NULL,
	[Cuenta] [nvarchar](10) NULL,
	[Marca] [char](1) NULL,
	[FechaDepo] [char](10) NULL,
	[FechaDepoOrd] [char](8) NULL,
	[Paridad] [float] NULL,
	[RetSuss] [float] NULL,
	[ComproGanan] [char](10) NULL,
	[ComproIva] [char](10) NULL,
	[ComproIb] [char](10) NULL,
	[ComproSuss] [char](10) NULL,
	[ClaveCheque] [char](31) NULL,
	[Cuit] [char](15) NULL,
	[Provisorio] [char](10) NULL,
	[BancoCheque] [char](3) NULL,
	[SucursalCheque] [char](3) NULL,
	[ChequeCheque] [char](8) NULL,
	[CuentaCheque] [char](11) NULL,
	[ReciboDefinitivo] [int] NULL,
	[RetIb1] [float] NULL,
	[NroRetIb1] [float] NULL,
	[RetIb2] [float] NULL,
	[NroRetIb2] [float] NULL,
	[RetIb3] [float] NULL,
	[NroRetIb3] [float] NULL,
	[RetIb4] [float] NULL,
	[NroRetIb4] [float] NULL,
	[RetIb5] [float] NULL,
	[NroRetIb5] [float] NULL,
	[RetIb6] [float] NULL,
	[NroRetIb6] [float] NULL,
	[RetIb7] [float] NULL,
	[NroRetIb7] [float] NULL,
	[RetIb8] [float] NULL,
	[NroRetIb8] [float] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Retencion]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Retencion](
	[Clave] [nvarchar](15) NULL,
	[Fecha] [nvarchar](4) NULL,
	[Proveedor] [nvarchar](11) NULL,
	[Neto] [float] NULL,
	[Retenido] [float] NULL,
	[Anticipo] [float] NULL,
	[Bruto] [float] NULL,
	[Iva] [float] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rubros]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rubros](
	[Rubro] [int] NULL,
	[Nombre] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sector]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sector](
	[Codigo] [int] NULL,
	[Descripcion] [char](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoProv]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoProv](
	[Codigo] [int] NULL,
	[Descripcion] [char](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Valcar]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Valcar](
	[Recibo] [int] NULL,
	[Cliente] [char](6) NULL,
	[Cheque] [char](10) NOT NULL,
	[Banco] [char](20) NULL,
	[Impo1] [float] NULL,
	[Impo2] [float] NULL,
	[Impo3] [float] NULL,
	[Impo4] [float] NULL,
	[Impo5] [float] NULL,
	[Titulo1] [char](10) NOT NULL,
	[Titulo2] [char](10) NOT NULL,
	[Titulo3] [char](10) NOT NULL,
	[Titulo4] [char](10) NOT NULL,
	[Titulo5] [char](10) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Vendedor]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vendedor](
	[Vendedor] [int] NULL,
	[Nombre] [nvarchar](50) NULL,
	[Email1] [char](50) NULL,
	[Email2] [char](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Verifica]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Verifica](
	[Numero] [int] NULL,
	[Descri] [nvarchar](10) NULL,
	[fecha] [nvarchar](10) NULL,
	[Estado] [nvarchar](20) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WImpCtaCte]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WImpCtaCte](
	[Clave] [nvarchar](12) NULL,
	[Tipo] [nvarchar](2) NOT NULL,
	[Numero] [int] NOT NULL,
	[Renglon] [nvarchar](2) NOT NULL,
	[Cliente] [nvarchar](6) NULL,
	[fecha] [nvarchar](10) NULL,
	[Estado] [nvarchar](1) NULL,
	[Vencimiento] [nvarchar](10) NULL,
	[Vencimiento1] [nvarchar](10) NULL,
	[Total] [float] NULL,
	[TotalUs] [float] NULL,
	[Saldo] [float] NULL,
	[SaldoUs] [float] NULL,
	[OrdFecha] [nvarchar](8) NULL,
	[OrdVencimiento] [nvarchar](8) NULL,
	[OrdVencimiento1] [nvarchar](8) NULL,
	[Impre] [nvarchar](2) NULL,
	[Empresa] [smallint] NULL,
	[Neto] [float] NULL,
	[Iva1] [float] NULL,
	[Iva2] [float] NULL,
	[Pedido] [nvarchar](6) NULL,
	[Remito] [nvarchar](10) NULL,
	[Orden] [nvarchar](10) NULL,
	[Paridad] [float] NULL,
	[Provincia] [nvarchar](2) NULL,
	[Vendedor] [int] NULL,
	[Rubro] [int] NULL,
	[Comprobante] [nvarchar](8) NULL,
	[Aceptada] [nvarchar](1) NULL,
	[Costo] [float] NULL,
	[Importe1] [float] NULL,
	[Importe2] [float] NULL,
	[Importe3] [float] NULL,
	[Importe4] [float] NULL,
	[Importe5] [float] NULL,
	[Importe6] [float] NULL,
	[Importe7] [float] NULL,
	[WDate] [nvarchar](10) NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Proveedor] ADD  CONSTRAINT [DF__Proveedor__Inhab__02E830D1]  DEFAULT ((0)) FOR [Inhabilitado]
GO
/****** Object:  StoredProcedure [dbo].[PR_actualiza_periodo_imputac]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create procedure [dbo].[PR_actualiza_periodo_imputac]
	(@desde varchar(10)
	, @hasta varchar(10))
as 

	UPDATE ic
	SET ic.Periodo = iva.Periodo,
		ic.PeriodoOrd = 'S'
	FROM Imputac ic 
	LEFT JOIN IvaComp iva on iva.NroInterno = ic.NroInterno
	-- where iva.Periodo between @desde and @hasta
	where dbo.FN_get_fecha_ordenable (iva.Periodo) between @desde and @hasta

GO
/****** Object:  StoredProcedure [dbo].[PR_actualiza_periodo_imputacII]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create procedure [dbo].[PR_actualiza_periodo_imputacII]
	(@desde varchar(10)
	, @hasta varchar(10))
as 

	UPDATE ic
	SET ic.Periodo = @desde,
		ic.PeriodoOrd = @desde
	FROM Imputac ic 
	LEFT JOIN IvaComp iva on iva.NroInterno = ic.NroInterno


GO
/****** Object:  StoredProcedure [dbo].[PR_actualizar_cuenta_corriente_proveedor]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[PR_actualizar_cuenta_corriente_proveedor]
	@Tipo varchar(2)
	, @Letra varchar(1)
	, @Punto varchar(4)
	, @Numero varchar(8)
	, @Fecha varchar(10)
	, @Aplica float
	, @Proveedor varchar(11)
AS
BEGIN
--	DECLARE @arreglo int = (-1) 
	--IF (@Tipo = '03' or @Tipo = '05') 
		--SET @arreglo = 1
	/*
	Lo pongo de esta forma porque el saldo esta almacenado como positivo para los primeros casos
	y negativo para los que toma el if por lo que para restar en un caso se debe restar y en el
	otro sumar
	*/ 

	-- 31/07/2017 : Se elimina el if. Los signos y valores pasan a manejarse por codigo.

	UPDATE CtaCtePrv
	SET Saldo = Saldo + @Aplica
	WHERE Tipo = @Tipo
		and Letra = @Letra
		and Punto = @Punto
		and Numero = @Numero
		and fecha = @Fecha
		and Proveedor = @Proveedor
END
GO
/****** Object:  StoredProcedure [dbo].[PR_alta_banco]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PR_alta_banco]
	(@banco smallint,
	@nombre varchar(50),
	@cuenta varchar(10))
AS
	DECLARE @mensaje_error varchar(255)
	set @mensaje_error = ''
	BEGIN TRANSACTION
		BEGIN TRY
			insert into surfactanSA.dbo.Banco
				values (@banco, @nombre, @cuenta, 1)
			IF @@ERROR = 0 COMMIT TRANSACTION
		END TRY
	BEGIN CATCH	
		ROLLBACK TRANSACTION
			EXEC PR_modificar_banco @banco, @nombre, @cuenta
	END CATCH
GO
/****** Object:  StoredProcedure [dbo].[PR_alta_cierre]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

CREATE PROCEDURE [dbo].[PR_alta_cierre] (@mes int, @anio int, @estado int)
AS
BEGIN
-- DE EXISTIR YA EL CIERRE INDICADO, LO MODIFICA, DE OTRA FORMA LO INSERTA
	IF(EXISTS (SELECT 1 
				FROM surfactanSA.dbo.Cierre ci 
				WHERE ci.Ano = @anio and ci.Mes = @mes))
		UPDATE surfactanSA.dbo.Cierre
			SET Estado = @estado
			WHERE Ano = @anio 
				and Mes = @mes
	ELSE
		INSERT INTO surfactanSA.dbo.Cierre
			values (@mes, @anio, @estado)
	
END
GO
/****** Object:  StoredProcedure [dbo].[PR_alta_cuenta]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
	
CREATE PROCEDURE [dbo].[PR_alta_cuenta]
	(@cuenta varchar(10),
	@descripcion varchar(50),
	@nivel smallint,
	@empresa smallint)
AS
	DECLARE @mensaje_error varchar(255)
	set @mensaje_error = ''
	BEGIN TRANSACTION
		BEGIN TRY
			insert into surfactanSA.dbo.Cuenta
				values (@Cuenta, @Descripcion, @Nivel, @Empresa)
			IF @@ERROR = 0 COMMIT TRANSACTION
		END TRY
	BEGIN CATCH	
		ROLLBACK TRANSACTION
			EXEC PR_modificar_cuenta @cuenta, @descripcion, @nivel, @empresa	
	END CATCH
GO
/****** Object:  StoredProcedure [dbo].[PR_alta_cuenta_corriente]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

CREATE PROCEDURE [dbo].[PR_alta_cuenta_corriente]
	(@Contado varchar(1),                   
	@Proveedor varchar(11),   
	@Letra varchar(1), 
	@Tipo varchar(2),
	@Punto varchar(4),
	@Numero varchar(8),  
	@fecha   varchar(10),   
	@Vencimiento varchar(10), 
	@Vencimiento1 varchar(50),                                       
	@Total   float    ,  
	@Saldo float,                                                                                 
	@Impre varchar(2),                                          
	@NroInterno int,  
	@Paridad   float   ,
	@Pago  int,
	@OrdFecha varchar(8), 
	@OrdVencimiento varchar(8),
	@NroInternoAsociado int,
	@DesProveOriginal char(50),
	@FacturaOriginal int,
	@ImporteOriginal float,
	@FechaOriginal char(10),
	@OrdFechaOriginal char(8),
	@Cuota int)
AS
BEGIN

	/*DECLARE @OrdFecha varchar(8) = (SELECT dbo.FN_verificar_fecha_ordenable (@fecha))*/
	/*DECLARE @OrdVencimiento varchar(8) = (SELECT dbo.FN_verificar_fecha_ordenable (@Vencimiento))*/
	DECLARE @Clave varchar(26) = @Proveedor + @Letra + @Tipo + @Punto + @Numero
	
	BEGIN TRAN
	-- LO SIGUIENTE SOLO OCURRE DE SER CTA CTE / PYME NACION
		IF (@Contado = 2 OR @Contado = 3)
			IF(NOT EXISTS (SELECT 1 FROM CtaCtePrv cc WHERE	cc.Clave = @Clave))
				INSERT INTO CtaCtePrv
					(
						Clave , Proveedor, Letra, Tipo , Punto , Numero ,  fecha   ,   
						Estado , Vencimiento, Vencimiento1, Total, Saldo, OrdFecha ,
						OrdVencimiento, Impre , Empresa, SaldoList, NroInterno,  
						Lista , Acumulado , Paridad , Pago , Observaciones , Tarjeta  , 
						NroInternoAsociado, DesProveOriginal, FacturaOriginal, ImporteOriginal, FechaOriginal, OrdFechaOriginal, Cuota
					)	
				VALUES
					(
						@Clave , @Proveedor , @Letra , @Tipo, @Punto, @Numero, @fecha,   
						1, @Vencimiento, @Vencimiento1, @Total, @Saldo, @OrdFecha,
						@OrdVencimiento, @Impre, 1, 0, @NroInterno,  
						"", 0 , @Paridad , @Pago, "", @Contado, 
						@NroInternoAsociado, @DesProveOriginal, @FacturaOriginal, @ImporteOriginal, @FechaOriginal, @OrdFechaOriginal, @Cuota
					)
			ELSE
				UPDATE CtaCteprv
				SET	Clave  =   @Clave ,
					Proveedor = @Proveedor,   
					Letra  = 	@Letra,
					Tipo = @Tipo ,
					Punto = @Punto ,
					Numero = @Numero ,
					fecha   = @fecha  ,
					Estado = 1,
					Vencimiento = @Vencimiento ,
					Vencimiento1 =   @Vencimiento1 ,
					Total   = @Total  ,
					Saldo  = @Saldo ,
					OrdFecha  = @OrdFecha  ,
					OrdVencimiento = @OrdVencimiento ,
					Impre = 	@Impre ,
					Empresa = 1, 
					SaldoList = 0,
					NroInterno = @NroInterno ,
					Lista  = 	"",
					Acumulado = 0,
					Paridad = @Paridad  ,
					Pago = @Pago , 
					Observaciones = "" , 
					Tarjeta = @Contado	,
					NroInternoAsociado = @NroInternoAsociado,
					DesProveOriginal = @DesProveOriginal,
					FacturaOriginal = @FacturaOriginal,
					ImporteOriginal = @ImporteOriginal,
					FechaOriginal = @FechaOriginal,
					OrdFechaOriginal = @OrdFechaOriginal	,
					Cuota = @Cuota
				WHERE
					Clave = @Clave

	COMMIT

END
GO
/****** Object:  StoredProcedure [dbo].[PR_alta_deposito]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO


CREATE procedure [dbo].[PR_alta_deposito]
	@Clave    VarChar(8),
	@Deposito VarChar(6),
	@Renglon  varchar(2),
	@Banco    smallint,
	@Fecha    VarChar(10),  
	@FechaOrd    VarChar(8),
	@Importe  Float,                                             
	@Acredita VarChar(10),  
	@AcreditaOrd  VarChar(8),
	@Tipo2    VarChar(2),
	@Numero2  VarChar(8),
	@Fecha2   VarChar(10),  
	@Importe2 real,                
	@Observaciones2 VarChar(20)
AS
BEGIN
	--declare @fechaOrd varchar(8) = (select dbo.FN_get_fecha_ordenable (@Fecha))
	--declare @AcreditaOrd VarChar(8) = (select dbo.FN_get_fecha_ordenable (@Acredita))
	INSERT INTO
		Depositos
			(
			Clave    ,
			Deposito ,
			Renglon ,
			Banco  ,
			Fecha   ,  
			FechaOrd ,
			Importe   ,                                           
			Acredita   ,
			AcreditaOrd ,
			Tipo2 ,
			Numero2, 
			Fecha2  ,  
			Importe2 ,               
			Observaciones2,      
			Empresa ,
			Impolista
			)
	VALUES
			(
			@Clave    ,
			@Deposito ,
			@Renglon ,
			@Banco  ,
			@Fecha   ,   
			@FechaOrd ,
			@Importe   ,                                            
			@Acredita   ,
			@AcreditaOrd ,
			@Tipo2 ,
			@Numero2,  
			@Fecha2  ,   
			@Importe2 ,                
			@Observaciones2,       
			1 ,
			0
			)
END
GO
/****** Object:  StoredProcedure [dbo].[PR_alta_estaanu]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[PR_alta_estaanu]
	(@Clave char(20),
	@Cliente char(6),
	@Codigo char(12),
	@Descripcion char(50),
	@Imprecodigo char(12),
	@Linea int,
	@Impo1 float,
	@Descri1 char(10),
	@Impo2 float,
	@Descri2 char(10),
	@Impo3 float,
	@Descri3 char(10),
	@Impo4 float,
	@Descri4 char(10),
	@Impo5 float,
	@Descri5 char(10),
	@Impo6 float,
	@Descri6 char(10),
	@Impo7 float,
	@Descri7 char(10),
	@Impo8 float,
	@Descri8 char(10),
	@Impo9 float,
	@Descri9 char(10),
	@Impo10 float,
	@Descri10 char(10),
	@Impo11 float,
	@Descri11 char(10),
	@Impo12 float,
	@Descri12 char(10),
	@Promedio float,
	@Titulo1 char(50),
	@Titulo2 char(50))
AS
	INSERT INTO dbo.EstaAnu
		(Clave, Cliente, Codigo, Descripcion, ImpreCodigo, Linea, Impo1, Descri1, Impo2, Descri2, Impo3, Descri3, Impo4, Descri4,
			Impo5, Descri5, Impo6, Descri6, Impo7, Descri7, Impo8,  Descri8, Impo9, Descri9, Impo10, Descri10,
			Impo11, Descri11, Impo12, Descri12, Promedio, Titulo1, Titulo2)
		VALUES
		(@Clave, @Cliente, @Codigo, @Descripcion, @ImpreCodigo, @Linea, @Impo1, @Descri1, @Impo2, @Descri2, @Impo3, @Descri3, @Impo4, @Descri4, @Impo5, @Descri5,
			@Impo6, @Descri6, @Impo7, @Descri7, @Impo8, @Descri8, @Impo9, @Descri9, @Impo10, @Descri10,
		    @Impo11, @Descri11, @Impo12, @Descri12, @promedio, @Titulo1, @Titulo2)

GO
/****** Object:  StoredProcedure [dbo].[PR_alta_grafico]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[PR_alta_grafico]
	(@Codigo int,
	@Impo float,
	@Porce float,
	@TituloI char(50),
	@TituloII char(50),
	@Descri char(10),
	@DescriII char(50))
AS
	INSERT INTO dbo.Grafico2
		(Codigo, Impo, Porce,TituloI, TituloII,  descri, DescriII)
		VALUES
		(@Codigo, @Impo,@Porce, @TituloI, @TituloII,  @Descri,@DescriII)
GO
/****** Object:  StoredProcedure [dbo].[PR_alta_impCtaCtePrvNet]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[PR_alta_impCtaCtePrvNet]	
	(@clave char(26),
	@proveedor char(11),
	@tipo char(2),
	@letra char(1),
	@punto char(4),
	@numero char(8),
	@total float,
	@saldo float,
	@fecha char(10),
	@vencimiento char(10),
	@vencimiento1 char(10),
	@impre char(2),
	@nrointerno int,
	@titulo char(50),
	@Acumulado float,
	@Orden float,
	@titulo1 char(10),
	@titulo2 char(10),
	@titulo3 char(10),
	@titulo4 char(10),
	@Impre1 float,
	@impre2 float,
	@impre3 float,
	@impre4 float,
	@impre5 float,
	@tituloII char(50),
	@RetIb float,
	@RetGanan float,
	@AcuNeto float,
	@Paridad float,
	@TotalUs float,
	@SaldoUs float,
	@AcumulaUs float,
	@Pago int)
AS
	INSERT INTO dbo.impCtaCtePrvNet 
		(Clave, Proveedor, Letra, Tipo, Punto, Numero, Total, Saldo, fecha, Vencimiento, Vencimiento1, Impre, NroInterno, Titulo, Acumulado, Orden, Titulo1, Titulo2, Titulo3,Titulo4,Impre1,Impre2,Impre3,Impre4,Impre5, TituloII, RetIb, RetGanan, AcuNeto, Paridad, TotalUs, SaldoUs, AcumulaUs, Pago)
		VALUES
		(@clave, @proveedor, @letra, @tipo, @punto, @numero, @total, @saldo,@fecha, @vencimiento, @vencimiento1, @impre, @nrointerno, @titulo, @Acumulado, @orden, @titulo1, @titulo2, @titulo3, @titulo4, @Impre1, @impre2, @impre3, @impre4, @Impre5, @tituloII, @RetIb, @RetGanan, @AcuNeto, @Paridad, @TotalUs, @SaldoUs, @AcumulaUs, @Pago)
GO
/****** Object:  StoredProcedure [dbo].[PR_alta_impcyb]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[PR_alta_impcyb]
	(@clave char(24),
	@TipoMovi char(1),
	@NroINterno int,
	@Proveedor char(11),
	@TipoComp char(2),
	@LetraComp char(1),
	@PuntoComp char(4),
	@NroComp char(8),
	@Renglon char(2),
	@Fecha char(10),
	@Observaciones char(50),
	@Cuenta char(10),
	@Credito float,
	@Debito float,
	@FechaOrd char(8),
	@Titulo char(50),
	@Empresa smallint,
	@TituloList char(50),
	@Varios char(50),
	@ClaveOrd char(20))
AS
	INSERT INTO dbo.impcyb
		(Clave, TipoMovi, NroInterno, Proveedor, TipoComp, LetraComp, PuntoComp, NroComp, Renglon, Fecha, Observaciones, Cuenta, Credito, 
		Debito, FechaOrd, Titulo, Empresa, TituloList, Varios, ClaveOrd)
		VALUES
		(@clave, @TipoMovi, @NroInterno, @Proveedor, @TipoComp, @LetraComp, @PuntoComp, @NroComp, @Renglon, @Fecha, @Observaciones, @Cuenta, @Credito, 
		@Debito, @FechaOrd, @Titulo, @Empresa, @TituloList, @Varios, @ClaveOrd)
GO
/****** Object:  StoredProcedure [dbo].[PR_alta_imputacion]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

CREATE PROCEDURE [dbo].[PR_alta_imputacion]
	@Clave varchar(24),                    
	@TipoMovi varchar(1), 
	@Proveedor varchar(11),   
	@TipoComp varchar(2),
	@LetraComp varchar(1), 
	@PuntoComp varchar(4), 
	@NroComp varchar(8), 
	@Renglon varchar(2),
	@Fecha   varchar(10),   
	@Observaciones varchar(30),                  
	@Cuenta   varchar(10)  ,
	@Debito   float  ,                                           
	@Credito  float  ,                                                                                  
	@NroInterno int,
	@FechaOrd varchar(8)
AS
BEGIN

	/*DECLARE @FechaOrd varchar(8) = (SELECT dbo.FN_verificar_fecha_ordenable (@Fecha))*/
	
	INSERT INTO Imputac
		(
			Clave, TipoMovi, Proveedor, TipoComp, LetraComp, PuntoComp, 
			NroComp , Renglon, Fecha  , Observaciones, Cuenta, Debito,                                           
			Credito, FechaOrd , Titulo, Empresa , DebitoList,
			CreditoList, NroInterno  
		)	
	VALUES
		(
			@Clave, @TipoMovi, @Proveedor, @TipoComp, @LetraComp, @PuntoComp,
			@NroComp, @Renglon, @Fecha, @Observaciones, @Cuenta, @Debito,
			@Credito, @FechaOrd, 'Compras', 1, 0,
			0, @NroInterno
		)

END
GO
/****** Object:  StoredProcedure [dbo].[PR_alta_iva_compra]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

CREATE PROCEDURE [dbo].[PR_alta_iva_compra]
	@NroInterno  int,
	@Proveedor char(11),
	@Tipo char(2),
	@Letra char(1),
	@Punto char(4),
	@Numero char(8),  
	@Fecha  char(10),    
	@Vencimiento char(10),
	@Vencimiento1 char(10),
	@Periodo    char(10),
	@Neto   float,                                               
	@Iva21  float,                                               
	@Iva5   float,                                               
	@Iva27  float,                                               
	@Ib     float,                                               
	@Exento float,                                               
	@Contado char(1),
	@Impre char(2),
	@Paridad float  ,
	@Pago  int ,    
	@cai varchar(14),
	@VtoCai  varchar(10),
	@Iva105 float, 
	@Despacho varchar(20), 
	@Remito varchar(30),
	@SoloIva int,
	@RetIB1 float,
	@RetIB2 float,
	@RetIB3 float,
	@RetIB4 float,
	@RetIB5 float,
	@RetIB6 float,
	@RetIB7 float,
	@RetIB8 float,
	@RetIB9 float,
	@RetIB10 float,
	@RetIB11 float,
	@RetIB12 float,
	@RetIB13 float,
	@RetIB14 float,
	@Ordfecha varchar(8)
AS
BEGIN

	/*DECLARE @Ordfecha varchar(8) = (SELECT dbo.FN_verificar_fecha_ordenable (@Fecha))	*/
	BEGIN TRAN
	
		IF (NOT EXISTS (SELECT 1 FROM IvaComp ic where ic.NroInterno = @NroInterno))
			INSERT INTO IvaComp
				(
				NroInterno, Proveedor, Tipo , Letra , Punto , Numero ,  
				Fecha, Vencimiento , Vencimiento1 , Periodo, Neto,                                          
				Iva21, Iva5, Iva27, Ib, Exento, Contado , Impre ,
				Ordfecha , Empresa , Netolist , ExentoList  , Paridad   ,
				Pago, Cai, VtoCai, Iva105, Despacho, Remito, SoloIva,
				RetIB1, RetIB2, RetIB3, RetIB4, RetIB5, RetIB6, RetIB7,
				RetIB8, RetIB9, RetIB10, RetIB11, RetIB12, RetIB13, RetIB14, Rechazado  		                                          
				)
			VALUES
				(	
				@NroInterno, @Proveedor, @Tipo, @Letra, @Punto, @Numero,  
				@Fecha, @Vencimiento, @Vencimiento1, @Periodo, @Neto,                                               
				@Iva21, @Iva5, @Iva27, @Ib, @Exento, @Contado, @Impre,
				@Ordfecha, 1, 0, 0, @Paridad    ,
				@Pago, @cai, @VtoCai, @Iva105, @Despacho, @Remito, @SoloIva,
				@RetIB1, @RetIB2, @RetIB3, @RetIB4, @RetIB5, @RetIB6, @RetIB7,
				@RetIB8, @RetIB9, @RetIB10, @RetIB11, @RetIB12, @RetIB13, @RetIB14, 0
				)
		ELSE
			UPDATE IvaComp
			SET
				Proveedor = @Proveedor,
				Tipo = @Tipo,
				Letra = @Letra,
				Punto = @Punto,
				Numero = @Numero,    
				Fecha = @Fecha,   
				Vencimiento = @Vencimiento,
				Vencimiento1 = @Vencimiento1,
				Periodo = @Periodo,
				Neto = @Neto,
				Iva21 = @Iva21,
				Iva5 = @Iva5,
				Iva27 = @Iva27,                                               
				Ib = @Ib,                                               
				Exento = @Exento,                                               
				Contado = @Contado,
				Impre = @Impre,
				Ordfecha = @Ordfecha,
				Paridad = @Paridad  ,
				Pago = @Pago,  
				Cai = @Cai,
				VtoCai = @VtoCai,
				Iva105 = @Iva105,
				Despacho = @Despacho,
				Remito = @Remito,
				SoloIva = @SoloIva,
				RetIB1 = @RetIB1,
				RetIB2 = @RetIB2,
				RetIB3 = @RetIB3,
				RetIB4 = @RetIB4,
				RetIB5 = @RetIB5,
				RetIB6 = @RetIB6,
				RetIB7 = @RetIB7,
				RetIB8 = @RetIB8,
				RetIB9 = @RetIB9,
				RetIB10 = @RetIB10,
				RetIB11 = @RetIB11,
				RetIB12 = @RetIB12,
				RetIB13 = @RetIB13,
				RetIB14 = @RetIB14	                                    
			WHERE
				NroInterno = @NroInterno
		
		EXEC PR_baja_imputaciones  @NroInterno = @NroInterno
 	COMMIT
END
GO
/****** Object:  StoredProcedure [dbo].[PR_alta_iva_compra_nacion]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

CREATE PROCEDURE [dbo].[PR_alta_iva_compra_nacion]
	@NroInterno  int,
	@Proveedor char(11),
	@Tipo char(2),
	@Letra char(1),
	@Punto char(4),
	@Numero char(8),  
	@Fecha  char(10),    
	@Vencimiento char(10),
	@Vencimiento1 char(10),
	@Periodo    char(10),
	@Neto   float,                                               
	@Iva21  float,                                               
	@Iva5   float,                                               
	@Iva27  float,                                               
	@Ib     float,                                               
	@Exento float,                                               
	@Contado char(1),
	@Impre char(2),
	@Paridad float  ,
	@Pago  int ,    
	@cai varchar(14),
	@VtoCai  varchar(10),
	@Iva105 float, 
	@Despacho varchar(20), 
	@Remito varchar(30),
	@SoloIva int,
	@NroInternoAsociado int,
	@Ordfecha varchar(8)                               
AS
BEGIN

	/*DECLARE @Ordfecha varchar(8) = (SELECT dbo.FN_verificar_fecha_ordenable (@Fecha))	*/
	BEGIN TRAN
	
		IF (NOT EXISTS (SELECT 1 FROM IvaComp ic where ic.NroInterno = @NroInterno))
			INSERT INTO IvaComp
				(
				NroInterno, Proveedor, Tipo , Letra , Punto , Numero ,  
				Fecha, Vencimiento , Vencimiento1 , Periodo, Neto,                                          
				Iva21, Iva5, Iva27, Ib, Exento, Contado , Impre ,
				Ordfecha , Empresa , Netolist , ExentoList  , Paridad   ,
				Pago, Cai, VtoCai, Iva105, Despacho, Remito, SoloIva, NroInternoAsociado 		                                          
				)
			VALUES
				(	
				@NroInterno, @Proveedor, @Tipo, @Letra, @Punto, @Numero,  
				@Fecha, @Vencimiento, @Vencimiento1, @Periodo, @Neto,                                               
				@Iva21, @Iva5, @Iva27, @Ib, @Exento, @Contado, @Impre,
				@Ordfecha, 1, 0, 0, @Paridad    ,
				@Pago, @cai, @VtoCai, @Iva105, @Despacho, @Remito, @SoloIva, @NroInternoAsociado 
				)
		ELSE
			UPDATE IvaComp
			SET
				Proveedor = @Proveedor,
				Tipo = @Tipo,
				Letra = @Letra,
				Punto = @Punto,
				Numero = @Numero,    
				Fecha = @Fecha,   
				Vencimiento = @Vencimiento,
				Vencimiento1 = @Vencimiento1,
				Periodo = @Periodo,
				Neto = @Neto,
				Iva21 = @Iva21,
				Iva5 = @Iva5,
				Iva27 = @Iva27,                                               
				Ib = @Ib,                                               
				Exento = @Exento,                                               
				Contado = @Contado,
				Impre = @Impre,
				Ordfecha = @Ordfecha,
				Paridad = @Paridad  ,
				Pago = @Pago,  
				Cai = @Cai,
				VtoCai = @VtoCai,
				Iva105 = @Iva105,
				Despacho = @Despacho,
				Remito = @Remito,
				SoloIva = @SoloIva,
				NroInternoAsociado = @NroInternoAsociado	                                    
			WHERE
				NroInterno = @NroInterno

 	COMMIT
END
GO
/****** Object:  StoredProcedure [dbo].[PR_alta_iva_compras_adicional]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

CREATE PROCEDURE [dbo].[PR_alta_iva_compras_adicional]
	(@Clave varchar(10),
	@NroInterno int,
	@Renglon int,
	@Cuit varchar(15),
	@Razon varchar(50),
	@Tipo varchar(2),
	@Letra char(1),
	@Punto varchar(4),
	@Numero varchar(8),
	@Fecha varchar(10),
	@Neto float,
	@Iva21 float,
	@Iva27 float,
	@Iva105 float,
	@PerceIva float,
	@PerceIb float,
	@Exento float,
	@OrdFecha varchar(8))
AS
BEGIN

	/*DECLARE @OrdFecha varchar(8) = (SELECT dbo.FN_verificar_fecha_ordenable (@Fecha))*/
	
	INSERT INTO IvaCompAdicional (
			Clave , NroInterno , Renglon , Cuit , Razon , Tipo ,
			Letra , Punto , Numero , Fecha , OrdFecha , Neto ,
			Iva21 , Iva27 , Iva105 , PerceIva , PerceIb , Exento)
		Values (
			@Clave, @NroInterno, @Renglon, @Cuit, @Razon , @Tipo,
			@Letra, @Punto , @Numero, @Fecha, @OrdFecha, @Neto,
			@Iva21, @Iva27, @Iva105, @PerceIva, @PerceIb, @Exento)

END
GO
/****** Object:  StoredProcedure [dbo].[PR_alta_ListaIvaComp]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[PR_alta_ListaIvaComp]
	(@NroINterno int,
	@Proveedor char(11),
	@Tipo char(2),
	@Letra char(1),
	@Punto char(4),
	@Numero char(8),
	@Fecha char(10),
	@Periodo char(10),
	@Neto float,
	@Iva21 float,
	@Iva5 float,
	@Iva27 float,
	@Iva105 float,
	@Ib float,
	@Exento float,
	@Impre char(3),
	@OrdFecha char(8),
	@Titulo char(50),
	@TituloII char(50),
	@Nombre char(50),
	@Cuit char(15))
AS
	INSERT INTO dbo.ListaIvaComp
		(NroINterno, Proveedor, tipo, Letra, Punto, Numero, Fecha, Periodo, Neto, Iva21, Iva5, Iva27, Iva105, Ib, 
		 Exento, Impre, OrdFecha, Titulo, TituloII, Nombre, cuit)
		VALUES
		(@NroINterno, @Proveedor, @tipo, @Letra, @Punto, @Numero, @Fecha, @Periodo, @Neto, @Iva21, @Iva5, @Iva27, @Iva105, @Ib, 
		 @Exento, @Impre, @OrdFecha, @Titulo, @TituloII, @Nombre, @Cuit)
GO
/****** Object:  StoredProcedure [dbo].[PR_alta_ListaIvaCompras]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



--
--   ---------------------------------------------------------------------------------------------------------
--

CREATE PROCEDURE [dbo].[PR_alta_ListaIvaCompras]
	(@NroINterno int,
	@Proveedor char(11),
	@Tipo char(2),
	@Letra char(1),
	@Punto char(4),
	@Numero char(8),
	@Fecha char(10),
	@Periodo char(10),
	@Neto float,
	@Iva21 float,
	@Iva5 float,
	@Iva27 float,
	@Iva105 float,
	@Ib float,
	@Exento float,
	@Impre char(3),
	@OrdFecha char(8),
	@Titulo char(50),
	@TituloII char(50),
	@Nombre char(50),
	@Cuit char(15))
AS
	INSERT INTO dbo.ListaIvaCompras
		(NroINterno, Proveedor, tipo, Letra, Punto, Numero, Fecha, Periodo, Neto, Iva21, Iva5, Iva27, Iva105, Ib, 
		 Exento, Impre, OrdFecha, Titulo, TituloII, Nombre, cuit)
		VALUES
		(@NroINterno, @Proveedor, @tipo, @Letra, @Punto, @Numero, @Fecha, @Periodo, @Neto, @Iva21, @Iva5, @Iva27, @Iva105, @Ib, 
		 @Exento, @Impre, @OrdFecha, @Titulo, @TituloII, @Nombre, @Cuit)
GO
/****** Object:  StoredProcedure [dbo].[PR_alta_MovBan]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[PR_alta_MovBan]
	(@da int,
	@Banco int,
	@Fecha char(10),
	@FechaOrd char(8),
	@Acredita char(10),
	@AcreditaOrd char(8),
	@Observaciones char(50),
	@Numero char(10),
	@Debito float,
	@Credito float,
	@Comprobante char(8),
	@Empresa int,
	@Titulo char(50),
	@Titulo1 char(50),
	@Proveedor char(11))
AS
	INSERT INTO dbo.Movban
		(da, Banco, Fecha, FechaOrd, Acredita, AcreditaOrd, Observaciones, Numero, Debito, Credito, Comprobante, Empresa, Titulo, Titulo1, 
		 Proveedor)
		VALUES
		(@da, @Banco, @Fecha, @FechaOrd, @Acredita, @AcreditaOrd, @Observaciones, @Numero, @Debito, @Credito, @Comprobante, @Empresa, @Titulo, @Titulo1, 
		 @Proveedor)
GO
/****** Object:  StoredProcedure [dbo].[PR_alta_pago_forma_de_pago]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

CREATE PROCEDURE [dbo].[PR_alta_pago_forma_de_pago]
	(@Orden VARCHAR(6)
	, @Renglon varchar(2)
	, @TipoOrd varchar(1)
	, @Fecha varchar(10)
	, @Proveedor varchar(11)
 	, @Observaciones varchar(50)
	, @banco2 smallint
	, @Fecha2 varchar(10)
	, @Paridad float 
	, @RetGanancias real
	, @RetOtra real
	, @RetIbCiudad real
	, @RetIva real
	, @Importe real
	, @Tipo2 varchar(2)
	, @Numero2 varchar(8)
	, @FechaCheque char(10)
	, @BancoCheque char(30)
	, @Importe2 float
	, @cuenta varchar(10)
	, @Observaciones2 varchar(30)
	) 
AS
	DECLARE @Clave as varchar(8)
	SET @Clave = @Orden + @Renglon
	INSERT INTO Pagos
		(Clave, Orden, Renglon, TipoOrd, Fecha , Proveedor , Observaciones , banco2 , Fecha2 
	, Paridad ,RetGanancias , retOtra , RetIbCiudad , RetIva, Importe, Tipo2 , Numero2 
	, FechaCheque , BancoCheque , Importe2 , cuenta, Observaciones2, TipoReg) 
	VALUES
			(@Clave, @Orden, @Renglon, @TipoOrd, @Fecha , @Proveedor , @Observaciones , @banco2 , @Fecha2 
	, @Paridad , @RetGanancias , @RetOtra , @RetIbCiudad , @RetIva, @Importe, @Tipo2 , @Numero2 
	, @FechaCheque , RTRIM(@BancoCheque) , @Importe2 , @cuenta, RTRIM(@Observaciones2), 2 ) 

GO
/****** Object:  StoredProcedure [dbo].[PR_alta_pago_pago]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

CREATE PROCEDURE [dbo].[PR_alta_pago_pago] 
	(@Orden VARCHAR(6)
	, @Renglon varchar(2)
	, @TipoOrd varchar(1)
	, @Fecha varchar(10)
	, @Proveedor varchar(11)
 	, @Observaciones varchar(50)
	, @banco2 smallint
	, @Fecha2 varchar(10)
	, @Paridad float 
	, @RetGanancias real
	, @RetOtra real
	, @RetIbCiudad real
	, @RetIva real
	, @Importe real
	, @Tipo1 varchar(2)
	, @Letra1 varchar(1)
	, @Punto1 varchar(4)
	, @Numero1 varchar(8)
	, @Importe1 real
	, @cuenta varchar(10)
	, @Observaciones2 varchar(30)
	) 
AS
BEGIN

	DECLARE @Clave as varchar(8)
	SET @Clave = @Orden + @Renglon
	INSERT INTO Pagos
		(Clave, Orden, Renglon, TipoOrd, Fecha , Proveedor , Observaciones , banco2 , Fecha2 
	, Paridad ,RetGanancias , retOtra , RetIbCiudad , RetIva, Importe, Tipo1 , Letra1 
	, Punto1 , numero1 , Importe1 , cuenta, Observaciones2, TipoReg) 
	VALUES
			(@Clave, @Orden, @Renglon, @TipoOrd, @Fecha , @Proveedor , @Observaciones , @banco2 , @Fecha2 
	, @Paridad , @RetGanancias , @RetOtra , @RetIbCiudad , @RetIva, @Importe, @Tipo1 , @Letra1 
	, @Punto1 , @Numero1 , @Importe1 , @cuenta, @Observaciones2, 1 ) 
	
	-- RESTO A LA CUENTA CORRIENTE LO QUE ESTOY ABONANDO AHORA
	--SELECT cc.Saldo
	--FROM CtaCtePrv cc
	--WHERE Tipo = @Tipo1
	--	AND Letra = @Letra1
	--	AND Punto = @Punto1
	--	AND Numero = @Numero1
	--	AND Proveedor = @Proveedor
		
	UPDATE CtaCtePrv
	SET Saldo = Saldo - @Importe1
	WHERE Tipo = @Tipo1
		AND Letra = @Letra1
		AND Punto = @Punto1
		AND Numero = @Numero1
		AND Proveedor = @Proveedor
END
GO
/****** Object:  StoredProcedure [dbo].[PR_alta_proveedor]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PR_alta_proveedor]
	(@Proveedor varchar(11) ,
	@Nombre varchar(50) ,
	@Direccion varchar(50) ,
	@Localidad varchar(50) ,
	@Provincia varchar(2) ,
	@Postal varchar(4) ,
	@Region int ,
	@Telefono varchar(30) ,
	@Dias varchar(20) ,
	@Email varchar(400) ,
	@Observaciones varchar(50) ,
	@Cuit varchar(15) ,
	@Tipo varchar(1) ,
	@Iva varchar(1) ,
	@Cuenta varchar(10) ,
	@NombreCheque varchar(50) ,
	@CodIb int ,
	@CodIbCaba int ,
	@NroIb char(20) ,
	@PorceIb float ,
	@PorceIbCaba float ,
	@Rubro int ,
	@NroInsc char(15) ,
	@FechaNroInsc char(10) ,
	@CategoriaI int ,
	@CategoriaII int, 
	@FechaCategoria char(10) ,
	@IbCiudadII int,
	@Cai char(14) ,
	@VtoCai char(10) ,
	@Iso int ,
	@VtoIso char(10) ,
	@Estado int ,
	@Califica float ,
	@FechaCalifica char(10) ,
	@ObservacionesII text ,
	@Cufe char(20) ,
	@CufeII char(20) ,
	@CufeIII char(20) ,
	@DirCufe char(50) ,
	@DirCufeII char(50) ,
	@DirCufeIII char(50),
	@PaginaWeb varchar(50) ,
	@ContactoNombre1 varchar(50) ,
	@ContactoCargo1 varchar(50) ,
	@ContactoTelefono1 varchar(50) ,
	@ContactoEmail1 varchar(50),
	@ContactoNombre2 varchar(50) ,
	@ContactoCargo2 varchar(50) ,
	@ContactoTelefono2 varchar(50) ,
	@ContactoEmail2 varchar(50) ,
	@ContactoNombre3 varchar(50) ,
	@ContactoCargo3 varchar(50) ,
	@ContactoTelefono3 varchar(50) ,
	@ContactoEmail3 varchar(50) ,
	@ClienteAsociado varchar(6) ,
	@Inhabilitado char(1) 
	)
AS
	DECLARE @OrdFechaCalifica varchar(8) = (SELECT dbo.FN_verificar_fecha_ordenable (@FechaCalifica))	
	DECLARE @OrdFechaCategoria varchar(8) = (SELECT dbo.FN_verificar_fecha_ordenable (@FechaCategoria))	
	DECLARE @OrdFechaNroInsc varchar(8) = (SELECT dbo.FN_verificar_fecha_ordenable (@FechaNroInsc))	

	DECLARE @Wdate char(10) = cast(getdate() AS DATE)
		
	--@Embargo char(1) , //ACA NUNCA IMPORTA --> S = rojo
	BEGIN TRANSACTION
					INSERT INTO Proveedor (Proveedor,	Nombre, Direccion, Localidad,Provincia, Postal,Region,Telefono,Dias,
					Email,Observaciones,Cuit,Tipo,Iva,Cuenta,NombreCheque,CodIb,CodIbCaba,NroIb,
					PorceIb,PorceIbCaba,TipoProv,NroInsc,FechaNroInsc,CategoriaI,CategoriaII, FechaCategoria,
					IbCiudadII,Cai,VtoCai,Iso,VtoIso,Estado,Califica,FechaCalifica,ObservacionesII,
					Cufe,CufeII,CufeIII,DirCufe,DirCufeII,DirCufeIII, OrdFechaCalifica, OrdFechaCategoria,
					OrdFechaNroInsc, Wdate, PaginaWeb, ContactoNombre1, ContactoCargo1, ContactoTelefono1, ContactoEmail1,
					ContactoNombre2, ContactoCargo2, ContactoTelefono2, ContactoEmail2,
					ContactoNombre3, ContactoCargo3, ContactoTelefono3, ContactoEmail3, ClienteAsociado, Inhabilitado)
				VALUES (@Proveedor,	@Nombre, @Direccion, @Localidad,@Provincia, @Postal,@Region,@Telefono,@Dias,
					@Email,@Observaciones,@Cuit,@Tipo,@Iva,@Cuenta,@NombreCheque,@CodIb,@CodIbCaba,@NroIb,
					@PorceIb,@PorceIbCaba,@Rubro,@NroInsc,@FechaNroInsc,@CategoriaI,@CategoriaII, @FechaCategoria,
					@IbCiudadII,@Cai,@VtoCai,@Iso,@VtoIso,@Estado,@Califica,@FechaCalifica,@ObservacionesII,
					@Cufe,@CufeII,@CufeIII,@DirCufe,@DirCufeII,@DirCufeIII, @OrdFechaCalifica, @OrdFechaCategoria,
					@OrdFechaNroInsc, @Wdate, @PaginaWeb, @ContactoNombre1, @ContactoCargo1, @ContactoTelefono1, @ContactoEmail1,
					@ContactoNombre2, @ContactoCargo2, @ContactoTelefono2, @ContactoEmail2,
					@ContactoNombre3, @ContactoCargo3, @ContactoTelefono3, @ContactoEmail3, @ClienteAsociado, @Inhabilitado)
	COMMIT TRANSACTION
GO
/****** Object:  StoredProcedure [dbo].[PR_alta_ranking]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[PR_alta_ranking]
	(@Clave char(12),
	@Cliente char(6),
	@Linea int,
	@Articulo char(12),
	@Unidades float,
	@Importe float,
	@Importe1 float,
	@Costo float,
	@Varios char(50),
	@Descripcion char(50),
	@Ordena float)
AS
	INSERT INTO dbo.Ranking
		(Clave, Cliente, Linea, Articulo, Unidades, Importe, Importe1, Costo, Titulo,Descripcion,  
		 Ordena)
		VALUES
		(@Clave, @Cliente, @Linea, @Articulo, @Unidades, @Importe, @Importe1, @Costo, @Varios,@Descripcion, 
		 @Ordena)
GO
/****** Object:  StoredProcedure [dbo].[PR_alta_recibo]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

CREATE PROCEDURE [dbo].[PR_alta_recibo]
	@Clave   	varchar(8), 
	@Recibo  	varchar(6),
	@Renglon 	varchar(2),
	@Cliente 	varchar(6),
	@Fecha      	varchar(10),
	@TipoRec 	varchar(1),
	@RetGanancias   FLOAT,          
	@RetIva         FLOAT,          
	@RetOtra        FLOAT,          
	@Retencion      FLOAT,          
	@TipoReg        varchar(1),
	@Tipo1 	varchar(2),
	@Numero1  	varchar(8),
	@Importe1       FLOAT,          
	@Importe        float,                            
	@Observaciones  varchar(50)
AS
BEGIN
	--@Letra1 	varchar(1),
	--@Punto1 	varchar(4),
	--@Tipo2 	varchar(2),
	--@Numero2  	varchar(8),
	--@Fecha2     	varchar(10),
	--@banco2         varchar(20),
	--@Importe2       FLOAT,          
	--@Estado2 	varchar(1),
	--@Empresa 	smallint,
	--@FechaOrd2 	varchar(8),
	--@Impolist       float,                           
	--@Impo1list      float,                                       
	--@Destino        varchar(50),                                    
	--@Cuenta     	varchar(10),
	--@Marca  char(1),
	--@FechaDepo Char(10) ,
	--@FechaDepoOrd char(8)
	DECLARE @Fechaord varchar(8) = (SELECT dbo.FN_verificar_fecha_ordenable (@Fecha))
	INSERT INTO	Recibos
		(Clave, Recibo, Renglon, Cliente, Fecha, Fechaord, 
		TipoRec , RetGanancias, RetIva, RetOtra, Retencion,             
		TipoReg , Tipo1 , Numero1 , Importe1, Importe   ,                                            
		Observaciones, Empresa)
VALUES
		(@Clave, @Recibo, @Renglon, @Cliente, @Fecha, @Fechaord, 
		@TipoRec , @RetGanancias, @RetIva, @RetOtra, @Retencion,             
		@TipoReg , @Tipo1 , @Numero1 , @Importe1, @Importe   ,                                            
		@Observaciones, 1)
END
GO
/****** Object:  StoredProcedure [dbo].[PR_alta_recibo_provisorio]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

CREATE PROCEDURE [dbo].[PR_alta_recibo_provisorio]
	@Recibo VARCHAR(6)
	, @Renglon VARCHAR(2)
	, @CLIENTE VARCHAR(6)
	, @FECHA VARCHAR(10)
	, @RETGANANCIAS FLOAT
	, @RETIVA FLOAT
	, @RETIB FLOAT
	, @RETSUSS FLOAT
	, @TIPO VARCHAR(2)
	, @NUMERO VARCHAR(8)
	, @FECHA2 VARCHAR(10)
	, @BANCO VARCHAR(20)
	, @IMPORTE2 FLOAT
	, @IMPORTE FLOAT
	, @PARIDAD FLOAT
	, @ESTADO2 CHAR
AS
	DECLARE @CLAVE VARCHAR(8) = @Recibo + @Renglon
	DECLARE @FECHAORD VARCHAR(8) = (SELECT dbo.FN_verificar_fecha_ordenable (@FECHA))
	DECLARE @FECHAORD2 VARCHAR(8) = (SELECT dbo.FN_verificar_fecha_ordenable (@FECHA2))
	INSERT INTO RecibosProvi(Clave, Recibo, Renglon, Cliente, Fecha,
	Fechaord, TipoRec, RetGanancias, RetIva, RetOtra, RetSuss, Retencion,
	TipoReg, Tipo2, Numero2, Fecha2, FechaOrd2, banco2, Importe2, Importe, Paridad,
	Empresa, Impolist, Observaciones, Cuenta, Estado2)
	VALUES (@CLAVE, @Recibo, @Renglon, @CLIENTE, @FECHA, @FECHAORD, 1,
	@RETGANANCIAS, @RETIVA, @RETIB, @RETSUSS, 0, 2, @TIPO, @NUMERO, @FECHA2,
	@FECHAORD2, @BANCO, @IMPORTE2, @IMPORTE, @PARIDAD, 1, 0, "", "", @ESTADO2)
GO
/****** Object:  StoredProcedure [dbo].[PR_alta_rubro_proveedor]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[PR_alta_rubro_proveedor]
	(@codigo int,
	@descripcion char(50))
AS
	DECLARE @mensaje_error varchar(255)
	set @mensaje_error = ''
	BEGIN TRANSACTION
		BEGIN TRY
			insert into surfactanSA.dbo.TipoProv
				values (@codigo, @descripcion)
			IF @@ERROR = 0 COMMIT TRANSACTION
		END TRY
	BEGIN CATCH	
		ROLLBACK TRANSACTION
			EXEC PR_modificar_rubro_proveedor @codigo, @descripcion
	END CATCH
GO
/****** Object:  StoredProcedure [dbo].[PR_alta_Valcar]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[PR_alta_Valcar]
	(@Recibo int,
	@Cliente char(6),
	@Cheque char(10),
	@Banco char(20),
	@Impo1 float,
	@Impo2 float,
	@Impo3 float,
	@Impo4 float,
	@Impo5 float,
	@Titulo1 char(10),
	@Titulo2 char(10),
	@Titulo3 char(10),
	@Titulo4 char(10),
	@Titulo5 char(10))
AS
	INSERT INTO dbo.Valcar
		(Recibo, Cliente, Cheque, Banco, Impo1, Impo2,Impo3, Impo4, Impo5, 
		Titulo1, Titulo2, Titulo3, Titulo4, Titulo5)
		VALUES
		(@Recibo, @Cliente, @Cheque, @Banco, @Impo1, @Impo2,@Impo3, @Impo4, @Impo5, 
		@Titulo1, @Titulo2, @Titulo3, @Titulo4, @Titulo5)
GO
/****** Object:  StoredProcedure [dbo].[PR_baja_banco]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

CREATE PROCEDURE [dbo].[PR_baja_banco]
	(@banco smallint)
AS
	DECLARE @mensaje_error varchar(255)
	set @mensaje_error = ''
	BEGIN TRANSACTION
		BEGIN TRY
			DELETE FROM surfactanSA.dbo.Banco
			WHERE Banco = @banco
			IF @@ERROR = 0 COMMIT TRANSACTION
		END TRY
	BEGIN CATCH	
		ROLLBACK TRANSACTION
		IF (@mensaje_error = '') 
				set @mensaje_error = @mensaje_error + 'NO SE PUDO ELIMINAR EL BANCO.'	
		RAISERROR(@mensaje_error, 16, 217)
			WITH SETERROR
	END CATCH
GO
/****** Object:  StoredProcedure [dbo].[PR_baja_cuenta]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

CREATE PROCEDURE [dbo].[PR_baja_cuenta]
	(@cuenta varchar(10))
AS
	DECLARE @mensaje_error varchar(255)
	set @mensaje_error = ''
	BEGIN TRANSACTION
		BEGIN TRY
			DELETE FROM surfactanSA.dbo.Cuenta
			WHERE Cuenta = @cuenta
			IF @@ERROR = 0 COMMIT TRANSACTION
		END TRY
	BEGIN CATCH	
		ROLLBACK TRANSACTION
		IF (@mensaje_error = '') 
				set @mensaje_error = @mensaje_error + 'NO SE PUDO ELIMINAR LA CUENTA.'	
		RAISERROR(@mensaje_error, 16, 217)
			WITH SETERROR
	END CATCH
GO
/****** Object:  StoredProcedure [dbo].[PR_baja_imputaciones]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[PR_baja_imputaciones] (@NroInterno int)
AS
BEGIN
	
	DELETE	
	FROM Imputac
	WHERE NroInterno = @NroInterno
	
	DELETE
	FROM CtaCtePrv
	Where NroInternoAsociado = @NroInterno	 

	DELETE 
	FROM IvaComp
	Where NroInternoAsociado = @NroInterno
	
	DELETE 
	FROM IvaCompAdicional
	Where NroInterno = @NroInterno
	
END
GO
/****** Object:  StoredProcedure [dbo].[PR_baja_proveedor]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[PR_baja_proveedor]
	(@proveedor varchar(11))
AS
	DECLARE @mensaje_error varchar(255)
	set @mensaje_error = ''
	BEGIN TRANSACTION
		BEGIN TRY
			DELETE FROM surfactanSA.dbo.Proveedor
			WHERE Proveedor = @proveedor
			IF @@ERROR = 0 COMMIT TRANSACTION
		END TRY
	BEGIN CATCH	
		ROLLBACK TRANSACTION
		IF (@mensaje_error = '') 
				set @mensaje_error = @mensaje_error + 'NO SE PUDO ELIMINAR EL PROVEEDOR.'	
		RAISERROR(@mensaje_error, 16, 217)
			WITH SETERROR
	END CATCH
GO
/****** Object:  StoredProcedure [dbo].[PR_baja_recibo_provisorio]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

CREATE PROCEDURE [dbo].[PR_baja_recibo_provisorio]
	@recibo varchar(6)
AS
	DELETE 
	FROM RecibosProvi
	WHERE Recibo = @recibo
GO
/****** Object:  StoredProcedure [dbo].[PR_baja_recibos_provisorios]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

CREATE PROCEDURE [dbo].[PR_baja_recibos_provisorios]
	@recibo varchar(6)
AS
	DELETE RecibosProvi
	Where Recibo = @recibo
GO
/****** Object:  StoredProcedure [dbo].[PR_baja_rubro_proveedor]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[PR_baja_rubro_proveedor]
	(@codigo int)
AS
	DECLARE @mensaje_error varchar(255)
	set @mensaje_error = ''
	BEGIN TRANSACTION
		BEGIN TRY
			DELETE FROM surfactanSA.dbo.TipoProv
			WHERE Codigo = @codigo
			IF @@ERROR = 0 COMMIT TRANSACTION
		END TRY
	BEGIN CATCH	
		ROLLBACK TRANSACTION
		IF (@mensaje_error = '') 
				set @mensaje_error = @mensaje_error + 'NO SE PUDO ELIMINAR EL RUBRO.'	
		RAISERROR(@mensaje_error, 16, 217)
			WITH SETERROR
	END CATCH
GO
/****** Object:  StoredProcedure [dbo].[PR_baja_tipo_cambio]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[PR_baja_tipo_cambio]
	(@fecha varchar(10))
AS
	DECLARE @mensaje_error varchar(255)
	set @mensaje_error = ''
	BEGIN TRANSACTION
		BEGIN TRY
			DELETE FROM surfactanSA.dbo.Cambios
			WHERE Fecha = @fecha
			IF @@ERROR = 0 COMMIT TRANSACTION
		END TRY
	BEGIN CATCH	
		ROLLBACK TRANSACTION
		IF (@mensaje_error = '') 
				set @mensaje_error = @mensaje_error + 'NO SE PUDO ELIMINAR EL CAMBIO.'	
		RAISERROR(@mensaje_error, 16, 217)
			WITH SETERROR
	END CATCH
GO
/****** Object:  StoredProcedure [dbo].[PR_buscar_acumulado_proveedor]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[PR_buscar_acumulado_proveedor]
	(@proveedor char(11),
	 @Fecha char(4))
	
AS
	select Acumula.Neto
		, Acumula.Retenido
		, Acumula.Anticipo
		, Acumula.Bruto
		, Acumula.Iva
	
	from surfactanSA.dbo.Retencion Acumula
	WHERE Acumula.Proveedor = @proveedor
		AND acumula.Fecha = @fecha
	
GO
/****** Object:  StoredProcedure [dbo].[PR_buscar_AplicaProve]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[PR_buscar_AplicaProve]
	(@DesdeProveedor char(11)
	, @HastaProveedor char(11)
	, @Fecha char(8))
AS
	select AplicaProve.Clave  as Clave
		 , AplicaProve.Codigo as Codigo
		 , AplicaProve.Renglon as Renglon
		 , AplicaProve.Fecha as Fecha
		 , AplicaProve.Ordfecha as OrdFecha
		 , AplicaProve.Proveedor as Proveedor
		 , AplicaProve.Tipo as Tipo
		 , AplicaProve.Letra as Letra
		 , AplicaProve.Punto as Punto
		 , AplicaProve.Numero as Numero
		 , AplicaProve.Importe as Importe
		 
	from surfactanSA.dbo.AplicaProve AplicaProve
	WHERE AplicaProve.Proveedor between @DesdeProveedor and @HastaProveedor
	    and  AplicaProve.Ordfecha > @Fecha
	order by AplicaProve.Clave



GO
/****** Object:  StoredProcedure [dbo].[PR_buscar_banco_por_codigo]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

CREATE PROCEDURE [dbo].[PR_buscar_banco_por_codigo]
	(@banco smallint)
AS
	SELECT ba.Banco
		, LTRIM(RTRIM(ba.Nombre)) as Nombre
		, LTRIM(RTRIM(ba.Cuenta)) as Cuenta
	FROM Banco ba 
	WHERE Banco = @banco
GO
/****** Object:  StoredProcedure [dbo].[PR_buscar_banco_por_nombre]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PR_buscar_banco_por_nombre]
	(@nombre varchar(50))
AS
	select LTRIM(RTRIM(ban.Banco)) as Banco, LTRIM(RTRIM(ban.Nombre)) as Nombre, LTRIM(RTRIM(ban.Cuenta)) as Cuenta
	from surfactanSA.dbo.Banco ban
	where ban.Nombre like '%' + @nombre + '%'
	order by ban.Nombre
GO
/****** Object:  StoredProcedure [dbo].[PR_buscar_cheques_emitidos]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO






CREATE PROCEDURE [dbo].[PR_buscar_cheques_emitidos]
	(@DesdeFecha char(8)
	, @HastaFecha char(8)
	, @Tipo2 char(2))
AS
	select Pagos.Banco2 as Banco2
		 , Pagos.Orden as Orden
		 , Pagos.Fecha as Fecha
		 , Pagos.FechaOrd as FechaOrd
		 , Pagos.Fecha2 as Fecha2
		 , Pagos.FechaOrd2 as FechaOrd2
		 , Pagos.Observaciones as Observaciones
		 , Pagos.Numero2 as Numero2
		 , Pagos.Importe2 as Importe2
		 , Pagos.Proveedor as Proveedor
		 
	from surfactanSA.dbo.Pagos Pagos
	WHERE pagos.FechaOrd2 between @DesdeFecha and @HastaFecha
	and Pagos.Tipo2 = @tipo2
	order by Pagos.Clave

GO
/****** Object:  StoredProcedure [dbo].[PR_buscar_cheques_valcar]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[PR_buscar_cheques_valcar]
	(@DesdeFecha char(8)
	, @HastaFecha char(8)
	, @DesdeCliente char(6)
	, @HastaCliente char(6))
AS
	select Recibos.FechaOrd as FechaOrd
		 , recibos.Recibo as Recibo
		 , recibos.TipoReg as TipoReg
		 , recibos.TipoRec as TipoRec
		 , recibos.Cuenta as Cuenta
		 , recibos.Cliente as Cliente
		 , recibos.Tipo1 as Tipo1
		 , recibos.letra1 as Letra1
		 , recibos.Punto1 as Punto1
		 , recibos.Numero1 as Numero1
		 , recibos.Fecha as Fecha
		 , recibos.Tipo2 as Tipo2
		 , recibos.Numero2 as Numero2
		 , recibos.Importe1 as Importe1
		 , recibos.Paridad as Paridad
		 , recibos.Importe2 as Importe2
		 , recibos.RetIva as RetIva
		 , recibos.RetOtra as RetOtra
		 , recibos.RetSuss as RetSuss
		 , recibos.RetGanancias as RetGanancias
		 , recibos.Renglon as Renglon
		 , recibos.banco2 AS Banco2
		 , recibos.Fecha2 AS Fecha2
		 , recibos.FechaOrd2 AS FechaOrd2
		 , recibos.Destino AS Destino
		 
	from surfactanSA.dbo.Recibos recibos
	WHERE recibos.Fechaord2 between @DesdeFecha and @HastaFecha
		and recibos.Cliente between @DesdeCliente and @HastaCliente
		and TipoReg = '2'
		and Tipo2 = '02'
		and Estado2 <> 'X'
	ORDER BY  Fechaord2,Numero2 --recibos.Clave


GO
/****** Object:  StoredProcedure [dbo].[PR_buscar_cheques_valcar_cuit]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[PR_buscar_cheques_valcar_cuit]
	(@DesdeFecha char(8)
	, @HastaFecha char(8)
	, @Cuit char(15))
AS
	select Recibos.FechaOrd as FechaOrd
		 , recibos.Recibo as Recibo
		 , recibos.TipoReg as TipoReg
		 , recibos.TipoRec as TipoRec
		 , recibos.Cuenta as Cuenta
		 , recibos.Cliente as Cliente
		 , recibos.Tipo1 as Tipo1
		 , recibos.letra1 as Letra1
		 , recibos.Punto1 as Punto1
		 , recibos.Numero1 as Numero1
		 , recibos.Fecha as Fecha
		 , recibos.Tipo2 as Tipo2
		 , recibos.Numero2 as Numero2
		 , recibos.Importe1 as Importe1
		 , recibos.Paridad as Paridad
		 , recibos.Importe2 as Importe2
		 , recibos.RetIva as RetIva
		 , recibos.RetOtra as RetOtra
		 , recibos.RetSuss as RetSuss
		 , recibos.RetGanancias as RetGanancias
		 , recibos.Renglon as Renglon
		 , recibos.banco2 AS Banco2
		 , recibos.Fecha2 AS Fecha2
		 , recibos.FechaOrd2 AS FechaOrd2
		 , recibos.Destino AS Destino
		 
	from surfactanSA.dbo.Recibos recibos
	WHERE recibos.Fechaord2 between @DesdeFecha and @HastaFecha
		and recibos.Cuit = @Cuit
		and TipoReg = '2'
		and Tipo2 = '02'
	order by recibos.Clave


GO
/****** Object:  StoredProcedure [dbo].[PR_buscar_cliente_por_codigo]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[PR_buscar_cliente_por_codigo]
	(@codigo varchar(6))
	
AS
	SELECT ISNULL(Cliente,'') as Cliente
		,ISNULL(Razon,'') as Razon
	FROM Cliente p 
	WHERE p.cliente = @codigo


GO
/****** Object:  StoredProcedure [dbo].[PR_buscar_cliente_por_nombre]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[PR_buscar_cliente_por_nombre]
	(@nombre varchar(50))
AS
	select LTRIM(RTRIM(c.Cliente)) as Cliente, LTRIM(RTRIM(c.razon)) as Razon
	from surfactanSA.dbo.Cliente c
	where c.Razon like '%' + @nombre + '%'
	order by c.Razon


GO
/****** Object:  StoredProcedure [dbo].[PR_buscar_composicion_por_codigo]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[PR_buscar_composicion_por_codigo]
	(@Codigo varchar(12))
AS
	SELECT LTRIM(RTRIM(compo.Clave)) as Clave
		, LTRIM(RTRIM(compo.Terminado)) as Terminado
		, LTRIM(RTRIM(compo.tipo)) as Tipo
		, LTRIM(RTRIM(compo.Articulo1)) as Articulo1
		, LTRIM(RTRIM(compo.Articulo2)) as Articulo2
		, compo.Cantidad as Cantidad
	FROM Composicion Compo
	WHERE Terminado = @Codigo
	order by Clave

GO
/****** Object:  StoredProcedure [dbo].[PR_buscar_cuenta_corriente_proveedores_desdehasta]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[PR_buscar_cuenta_corriente_proveedores_desdehasta]
	(@proveedordesde char(11)
	,@proveedorhasta char(11)
	, @tipo char(1))
AS
	select LTRIM(RTRIM(CtaCtePrv.Tipo)) as Tipo 
		 , LTRIM(RTRIM(CtaCtePrv.Letra)) as Letra
		 , LTRIM(RTRIM(CtaCtePrv.Punto)) as Punto
		 , LTRIM(RTRIM(CtaCtePrv.Numero)) as Numero
		 , CtaCtePrv.Total as Total
		 , CtaCtePrv.Saldo as Saldo
		 , LTRIM(RTRIM(CtaCtePrv.fecha)) as Fecha
		 , LTRIM(RTRIM(CtaCtePrv.Vencimiento)) as Vencimiento
		 , LTRIM(RTRIM(CtaCtePrv.Vencimiento1)) as Vencimiento1
		 , LTRIM(RTRIM(CtaCtePrv.Impre)) as Impre
		 , CtaCtePrv.NroInterno as NroInterno
		 , LTRIM(RTRIM(CtaCtePrv.Clave)) as Clave
		 , LTRIM(RTRIM(CtaCtePrv.Proveedor)) as Proveedor

	from surfactanSA.dbo.CtaCtePrv CtaCtePrv
	WHERE CtaCtePrv.Proveedor between @proveedordesde  and @proveedorhasta 
		AND ((CtaCtePrv.Saldo <> 0 and @tipo = 'P')
			OR (@tipo = 'T')) 
	order by CtaCtePrv.Proveedor, CtaCtePrv.OrdFecha, CtaCtePrv.Tipo,CtaCtePrv.Numero


GO
/****** Object:  StoredProcedure [dbo].[PR_buscar_cuenta_corriente_proveedores_deuda]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[PR_buscar_cuenta_corriente_proveedores_deuda]
	(@proveedor varchar(11)
	, @tipo char(1))
AS
	select LTRIM(RTRIM(CtaCtePrv.Tipo)) as Tipo 
		 , LTRIM(RTRIM(CtaCtePrv.Letra)) as Letra
		 , LTRIM(RTRIM(CtaCtePrv.Punto)) as Punto
		 , LTRIM(RTRIM(CtaCtePrv.Numero)) as Numero
		 , CtaCtePrv.Total as Total
		 , CtaCtePrv.Saldo as Saldo
		 , LTRIM(RTRIM(CtaCtePrv.fecha)) as Fecha
		 , LTRIM(RTRIM(CtaCtePrv.Vencimiento)) as Vencimiento
		 , LTRIM(RTRIM(CtaCtePrv.NroInterno)) as NroInterno
		 , LTRIM(RTRIM(CtaCtePrv.Impre)) as Impre
		 
	from surfactanSA.dbo.CtaCtePrv CtaCtePrv
	WHERE CtaCtePrv.Proveedor = @proveedor 
		AND ((CtaCtePrv.Saldo <> 0 and @tipo = 'P')
			OR (@tipo = 'T')) 
	order by CtaCtePrv.Proveedor, CtaCtePrv.OrdFecha, CtaCtePrv.Tipo,CtaCtePrv.Numero
GO
/****** Object:  StoredProcedure [dbo].[PR_buscar_cuenta_corriente_proveedores_Selectivo]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[PR_buscar_cuenta_corriente_proveedores_Selectivo]
	(@proveedor char(11))
	
AS
	select LTRIM(RTRIM(CtaCtePrv.Tipo)) as Tipo 
		 , LTRIM(RTRIM(CtaCtePrv.Letra)) as Letra
		 , LTRIM(RTRIM(CtaCtePrv.Punto)) as Punto
		 , LTRIM(RTRIM(CtaCtePrv.Numero)) as Numero
		 , CtaCtePrv.Total as Total
		 , CtaCtePrv.Saldo as Saldo
		 , LTRIM(RTRIM(CtaCtePrv.fecha)) as Fecha
		 , LTRIM(RTRIM(CtaCtePrv.Vencimiento)) as Vencimiento
		 , LTRIM(RTRIM(CtaCtePrv.Vencimiento1)) as Vencimiento1
		 , LTRIM(RTRIM(CtaCtePrv.Impre)) as Impre
		 , CtaCtePrv.NroInterno as NroInterno
		 , LTRIM(RTRIM(CtaCtePrv.Clave)) as Clave
		 , LTRIM(RTRIM(CtaCtePrv.Proveedor)) as Proveedor
		 , CtaCtePrv.Pago as Pago
		 , CtaCtePrv.Paridad as Paridad

	from surfactanSA.dbo.CtaCtePrv CtaCtePrv
	WHERE CtaCtePrv.Proveedor = @proveedor
		AND CtaCtePrv.Saldo <> 0
	order by CtaCtePrv.OrdFecha, CtaCtePrv.Numero
GO
/****** Object:  StoredProcedure [dbo].[PR_buscar_cuenta_por_codigo]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

CREATE PROCEDURE [dbo].[PR_buscar_cuenta_por_codigo]
	(@cuenta varchar(10))
AS
	SELECT LTRIM(RTRIM(cu.Cuenta)) as Cuenta
		, LTRIM(RTRIM(cu.Descripcion)) as Descripcion 
	FROM Cuenta cu 
	WHERE Cuenta = @cuenta
GO
/****** Object:  StoredProcedure [dbo].[PR_buscar_cuenta_por_descripcion]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PR_buscar_cuenta_por_descripcion]
	(@descripcion varchar(50))
AS
	select LTRIM(RTRIM(cu.Cuenta)) as Cuenta, LTRIM(RTRIM(cu.Descripcion)) as Descripcion
	from surfactanSA.dbo.Cuenta cu
	where cu.Descripcion like '%' + @descripcion + '%'
	order by cu.Descripcion
GO
/****** Object:  StoredProcedure [dbo].[PR_buscar_depositos_efectuados]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





CREATE PROCEDURE [dbo].[PR_buscar_depositos_efectuados]
	(@DesdeFecha char(8)
	, @HastaFecha char(8)
	, @Renglon int)
AS
	select Deposito.Banco as Banco
		 , Deposito.Deposito as Deposito
		 , Deposito.Renglon  as Renglon
		 , Deposito.Fecha as Fecha
		 , Deposito.FechaOrd as FechaOrd
		 , Deposito.Acredita as Acredita2
		 , Deposito.AcreditaOrd as AcreditaOrd2
		 , Deposito.Importe as Importe
		 
	from surfactanSA.dbo.Depositos Deposito
	WHERE Deposito.FechaOrd between @DesdeFecha and @HastaFecha
	and Deposito.Renglon = @Renglon
	order by Deposito.Clave

GO
/****** Object:  StoredProcedure [dbo].[PR_buscar_depositos_fecha]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO








CREATE PROCEDURE [dbo].[PR_buscar_depositos_fecha]
	(@DesdeFecha char(8)
	, @HastaFecha char(8))
AS
	select Depositos.FechaOrd as FechaOrd
		 , Depositos.Deposito as Deposito
		 , Depositos.Tipo2 as Tipo2
		 , Depositos.Numero2 as Numero2
		 , Depositos.Fecha as Fecha
		 , Depositos.Importe2 as Importe2
		 , Depositos.Banco as Banco
		 
	from surfactanSA.dbo.Depositos depositos
	WHERE depositos.FechaOrd between @DesdeFecha and @HastaFecha
	order by depositos.Clave

GO
/****** Object:  StoredProcedure [dbo].[PR_buscar_depositos_movban]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[PR_buscar_depositos_movban]
	(@DesdeFecha char(8)
	, @HastaFecha char(8)
	, @DesdeBanco int
	, @HastaBanco int)
AS
	select Depositos.FechaOrd as FechaOrd
		 , Depositos.Deposito as Deposito
		 , Depositos.Tipo2 as Tipo2
		 , Depositos.Numero2 as Numero2
		 , Depositos.Fecha as Fecha
		 , Depositos.Importe2 as Importe2
		 , Depositos.Banco as Banco
		 , Depositos.Importe as Importe
		 , Depositos.Acredita as Acredita
		 , Depositos.AcreditaOrd as AcreditaOrd
		 
	from surfactanSA.dbo.Depositos depositos
	WHERE depositos.FechaOrd between @DesdeFecha and @HastaFecha
		and depositos.banco between @DesdeBanco and @HastaBanco
		and depositos.Renglon = 1
	order by depositos.Clave


GO
/****** Object:  StoredProcedure [dbo].[PR_buscar_estadistica_productos]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[PR_buscar_estadistica_productos]
	(@DesdeVendedor int
	, @HastaVendedor int
	, @DesdeLinea int
	, @HastaLinea int
	, @DesdeRubro int
	, @HastaRubro int
	, @DesdeCliente char(6)
	, @HastaCliente char(6)
	, @DesdeTerminado char(12)
	, @HastaTerminado char(12)
	, @DesdeFecha char(8)
	, @HastaFecha char(8))
AS
	select distinct Articulo 
	FROM Estadistica Esta
	WHERE esta.Vendedor between @DesdeVendedor and @HastaVendedor
	    and  esta.OrdFecha between @DesdeFecha and @HastaFecha
		and  esta.Linea between @Desdelinea and @HastaLinea
		and  esta.Rubro between @Desderubro and @HastaRubro
		and  esta.Articulo between @DesdeTerminado and @HastaTerminado
		and  esta.Cliente between @DesdeCliente and @HastaCliente
GO
/****** Object:  StoredProcedure [dbo].[PR_buscar_estadistica_productosII]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[PR_buscar_estadistica_productosII]
	(@DesdeVendedor int
	, @HastaVendedor int
	, @DesdeLinea int
	, @HastaLinea int
	, @DesdeRubro int
	, @HastaRubro int
	, @DesdeCliente char(6)
	, @HastaCliente char(6)
	, @DesdeTerminado char(12)
	, @HastaTerminado char(12)
	, @DesdeFecha char(8)
	, @HastaFecha char(8))
AS
	select distinct Articulo 
	FROM Estadistica Esta
	WHERE esta.Vendedor between @DesdeVendedor and @HastaVendedor
	    and  esta.OrdFecha between @DesdeFecha and @HastaFecha
		and  esta.Linea between @Desdelinea and @HastaLinea
		and  esta.Rubro between @Desderubro and @HastaRubro
		and  esta.Articulo between @DesdeTerminado and @HastaTerminado
		and  esta.Cliente between @DesdeCliente and @HastaCliente
		--and  (Esta.DescriTerminadoII = '' or Esta.DescriTerminadoII = null)
		and ltrim(rtrim(ISNULL(Esta.DescriTerminadoII,''))) = ''		
GO
/****** Object:  StoredProcedure [dbo].[PR_buscar_estadistica_ranking_cliente]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[PR_buscar_estadistica_ranking_cliente]
	(@DesdeFecha char(8)
	, @HastaFecha char(8))
AS
	select Esta.Articulo as Articulo
		 , Esta.Cliente as Cliente
		 , Esta.Linea as Linea
		 , Esta.Cantidad as Cantidad
		 , Esta.ImporteUs as ImporeUs
		 , Esta.Importe as Importe
		 , Esta.Tipo as Tipo
		 , Esta.Costo2 as Costo
		 , ISNULL(Esta.DescriTerminadoII,'') as DescriTerminado
		 , Esta.Fecha as Fecha
		 
		 
	from surfactanSA.dbo.Estadistica Esta
	WHERE Esta.OrdFecha between @Desdefecha and @HastaFecha
	order by Esta.Cliente



GO
/****** Object:  StoredProcedure [dbo].[PR_buscar_estadistica_ranking_linea]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[PR_buscar_estadistica_ranking_linea]
	(@DesdeFecha char(8)
	, @HastaFecha char(8))
AS
	select Esta.Articulo as Articulo
		 , Esta.Cliente as Cliente
		 , Esta.Linea as Linea
		 , Esta.Cantidad as Cantidad
		 , Esta.ImporteUs as ImporeUs
		 , Esta.Importe as Importe
		 , Esta.Tipo as Tipo
		 , Esta.Costo2 as Costo
		 , ISNULL(Esta.DescriTerminadoII,'') as DescriTerminado
		 , Esta.Fecha as Fecha
		 
		 
	from surfactanSA.dbo.Estadistica Esta
	WHERE Esta.OrdFecha between @Desdefecha and @HastaFecha
	order by Esta.Linea



GO
/****** Object:  StoredProcedure [dbo].[PR_buscar_estadistica_ranking_producto]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[PR_buscar_estadistica_ranking_producto]
	(@DesdeFecha char(8)
	, @HastaFecha char(8))
AS
	select Esta.Articulo as Articulo
		 , Esta.Cliente as Cliente
		 , Esta.Linea as Linea
		 , Esta.Cantidad as Cantidad
		 , Esta.ImporteUs as ImporeUs
		 , Esta.Importe as Importe
		 , Esta.Tipo as Tipo
		 , Esta.Costo2 as Costo
		 , ISNULL(Esta.DescriTerminadoII,'') as DescriTerminado
		 , Esta.Fecha as Fecha
		 
		 
	from surfactanSA.dbo.Estadistica Esta
	WHERE Esta.OrdFecha between @Desdefecha and @HastaFecha
	order by Esta.Articulo



GO
/****** Object:  StoredProcedure [dbo].[PR_buscar_estadistica_ranking_producto_anual]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[PR_buscar_estadistica_ranking_producto_anual]
	(@DesdeFecha char(8)
     , @HastaFecha char(8)
	 , @DesdeArticulo char(12)
	 , @HastaArticulo char(12)
	 , @DesdeVendedor int
	 , @HastaVendedor int
	 , @DesdeCliente char(6)
	 , @HastaCliente char(6))
AS
	select Esta.Articulo as Articulo
		 , Esta.Cliente as Cliente
		 , Esta.Linea as Linea
		 , Esta.Cantidad as Cantidad
		 , Esta.ImporteUs as ImporeUs
		 , Esta.Importe as Importe
		 , Esta.Tipo as Tipo
		 , Esta.Costo2 as Costo
		 , ltrim(rtrim(isnull(Esta.DescriTerminadoII,''))) as DescriTerminado 
		 , Esta.Fecha as Fecha
		 
		 
	from surfactanSA.dbo.Estadistica Esta
	WHERE Esta.OrdFecha between @Desdefecha and @HastaFecha
	 and  esta.Articulo between @DesdeArticulo and @HastaArticulo
	 and  esta.Vendedor between @DesdeVendedor and @HastaVendedor
	 and  esta.Cliente between @DesdeCliente and @HastaCliente
	order by Esta.Articulo, esta.cliente



GO
/****** Object:  StoredProcedure [dbo].[PR_buscar_estadistica_ranking_rubro]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[PR_buscar_estadistica_ranking_rubro]
	(@DesdeFecha char(8)
	, @HastaFecha char(8))
AS
	select Esta.Articulo as Articulo
		 , Esta.Cliente as Cliente
		 , Esta.Linea as Linea
		 , Esta.Cantidad as Cantidad
		 , Esta.ImporteUs as ImporeUs
		 , Esta.Importe as Importe
		 , Esta.Tipo as Tipo
		 , Esta.Costo2 as Costo
		 , ISNULL(Esta.DescriTerminadoII,'') as DescriTerminado
		 , Esta.Fecha as Fecha
		 , Esta.Rubro as Rubro
		 , Esta.Vendedor as Vendedor
		 
		 
	from surfactanSA.dbo.Estadistica Esta
	WHERE Esta.OrdFecha between @Desdefecha and @HastaFecha
	order by Esta.Rubro



GO
/****** Object:  StoredProcedure [dbo].[PR_buscar_estadistica_ranking_vendedor]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[PR_buscar_estadistica_ranking_vendedor]
	(@DesdeFecha char(8)
	, @HastaFecha char(8))
AS
	select Esta.Articulo as Articulo
		 , Esta.Cliente as Cliente
		 , Esta.Linea as Linea
		 , Esta.Cantidad as Cantidad
		 , Esta.ImporteUs as ImporeUs
		 , Esta.Importe as Importe
		 , Esta.Tipo as Tipo
		 , Esta.Costo2 as Costo
		 , ISNULL(Esta.DescriTerminadoII,'') as DescriTerminado
		 , Esta.Fecha as Fecha
		 , Esta.Rubro as Rubro
		 , Esta.Vendedor as Vendedor
		 
		 
	from surfactanSA.dbo.Estadistica Esta
	WHERE Esta.OrdFecha between @Desdefecha and @HastaFecha
	order by Esta.vendedor



GO
/****** Object:  StoredProcedure [dbo].[PR_buscar_estadistica_registros]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[PR_buscar_estadistica_registros]
	(@DesdeVendedor int
	, @HastaVendedor int
	, @DesdeLinea int
	, @HastaLinea int
	, @DesdeRubro int
	, @HastaRubro int
	, @DesdeCliente char(6)
	, @HastaCliente char(6)
	, @DesdeTermimnado char(12)
	, @HastaTerminado char(12)
	, @DesdeFecha char(8)
	, @HastaFecha char(8))
AS
	select Esta.Articulo as Articulo
		 , Esta.Cliente as Cliente
		 , Esta.Linea as Linea
		 , Esta.Cantidad as Cantidad
		 , Esta.ImporteUs as ImporeUs
		 , Esta.Importe as Importe
		 , Esta.Tipo as Tipo
		 , Esta.Costo2 as Costo
		 , ISNULL(Esta.DescriTerminadoII,'') as DescriTerminado
		 , Esta.Fecha as Fecha
		 , Esta.Rubro as Rubro
		 , Esta.Vendedor as Vendedor
		 
		 
	from surfactanSA.dbo.Estadistica Esta
	WHERE Esta.Vendedor between @DesdeVendedor and @HastaVendedor
	 and  esta.Linea between @DesdeLinea and @HastaLinea
	 and  esta.Rubro between @DesdeRubro and @HastaRubro
	 and  esta.Cliente between @DesdeCliente and @HastaCliente
	 and  esta.Articulo between @DesdeTermimnado and @HastaTerminado
	 and  esta.ordfecha between @DesdeFecha and @HastaFecha
	order by Esta.clave



GO
/****** Object:  StoredProcedure [dbo].[PR_buscar_linea]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[PR_buscar_linea]
	(@Linea int)
AS
	select Linea.Linea as Linea, LTRIM(RTRIM(Linea.Nombre)) as Nombre
	from surfactanSA.dbo.Lineas Linea
	where Linea.Linea = @Linea
	
GO
/****** Object:  StoredProcedure [dbo].[PR_buscar_linea_por_nombre]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[PR_buscar_linea_por_nombre]
	(@nombre varchar(50))
AS
	select Linea.Linea as Linea, LTRIM(RTRIM(Linea.Nombre)) as Nombre
	from surfactanSA.dbo.Lineas Linea
	where Linea.Nombre like '%' + @nombre + '%' and Linea.Nombre <> ''
	order by Linea.Nombre

GO
/****** Object:  StoredProcedure [dbo].[PR_buscar_materiaprima]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[PR_buscar_materiaprima]

AS
	SELECT LTRIM(RTRIM(arti.Codigo)) as Codigo
		, arti.Costo2 as Costo
		, Arti.Descripcion as Descrricpion
	FROM Articulo Arti 

GO
/****** Object:  StoredProcedure [dbo].[PR_buscar_materiaprima_por_codigo_costo]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[PR_buscar_materiaprima_por_codigo_costo]
	(@Codigo varchar(10))
AS
	SELECT LTRIM(RTRIM(arti.Codigo)) as Codigo
		, arti.Costo2 as Costo
		, Arti.Descripcion as Descrricpion
	FROM Articulo Arti 
	WHERE Codigo = @Codigo

GO
/****** Object:  StoredProcedure [dbo].[PR_buscar_pagos_fecha]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[PR_buscar_pagos_fecha]
	(@DesdeFecha char(8)
	, @HastaFecha char(8))
AS
	select Pagos.FechaOrd as FechaOrd
		 , Pagos.Orden as Orden
		 , Pagos.TipoOrd as TipoOrd
		 , Pagos.Banco2 as Banco2
		 , Pagos.Cuenta as Cuenta
		 , Pagos.Proveedor as Proveedor
		 , Pagos.Letra1 as Letra1
		 , Pagos.Tipo1 as Tipo1
		 , Pagos.Punto1 as Punto1
		 , Pagos.Numero1 as Numero1
		 , Pagos.Importe1 as Importe1
		 , Pagos.Fecha as Fecha
		 , Pagos.TipoReg as Tiporeg
		 , Pagos.Observaciones as Observaciones
		 , Pagos.RetOtra as RetOtra
		 , Pagos.Retencion as Retencion
		 , Pagos.RetIbCiudad as RetIbCiudad
		 , Pagos.Importe2 as Importe2
		 , Pagos.Tipo2 as Tipo2
		 , Pagos.Numero2 as Numero2
		 , Pagos.Renglon as Renglon
		 
	from surfactanSA.dbo.pagos pagos
	WHERE pagos.FechaOrd between @DesdeFecha and @HastaFecha
	order by pagos.Clave



GO
/****** Object:  StoredProcedure [dbo].[PR_buscar_pagos_fecha_Proveedor]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[PR_buscar_pagos_fecha_Proveedor]
	(@DesdeProveedor char(11)
	, @HastaProveedor char(11)
	, @Fecha char(8))
AS
	select Pagos.FechaOrd as FechaOrd
		 , Pagos.Orden as Orden
		 , Pagos.TipoOrd as TipoOrd
		 , Pagos.Banco2 as Banco2
		 , Pagos.Cuenta as Cuenta
		 , Pagos.Proveedor as Proveedor
		 , Pagos.Letra1 as Letra1
		 , Pagos.Tipo1 as Tipo1
		 , Pagos.Punto1 as Punto1
		 , Pagos.Numero1 as Numero1
		 , Pagos.Importe1 as Importe1
		 , Pagos.Fecha as Fecha
		 , Pagos.TipoReg as Tiporeg
		 , Pagos.Observaciones as Observaciones
		 , Pagos.RetOtra as RetOtra
		 , Pagos.Retencion as Retencion
		 , Pagos.RetIbCiudad as RetIbCiudad
		 , Pagos.Importe2 as Importe2
		 , Pagos.Tipo2 as Tipo2
		 , Pagos.Numero2 as Numero2
		 , Pagos.Renglon as Renglon
		 , Pagos.Carpeta as carpeta
		 
		 
	from surfactanSA.dbo.pagos pagos
	WHERE pagos.Proveedor between @DesdeProveedor and @HastaProveedor
	    and  pagos.FechaOrd > @Fecha
	    and  pagos.Importe1 <> 0
	order by pagos.Clave



GO
/****** Object:  StoredProcedure [dbo].[PR_buscar_pagos_movban]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[PR_buscar_pagos_movban]
	(@DesdeFecha char(8)
	, @HastaFecha char(8)
	, @DesdeBanco int
	, @HastaBanco int)
AS
	select Pagos.FechaOrd as FechaOrd
		 , Pagos.Orden as Orden
		 , Pagos.TipoOrd as TipoOrd
		 , Pagos.Banco2 as Banco2
		 , Pagos.Cuenta as Cuenta
		 , Pagos.Proveedor as Proveedor
		 , Pagos.Fecha as Fecha
		 , Pagos.Fecha2 as Fecha2
		 , Pagos.FechaOrd2 as FechaOrd2
		 , Pagos.TipoReg as Tiporeg
		 , Pagos.Observaciones as Observaciones
		 , Pagos.Importe2 as Importe2
		 , Pagos.Tipo2 as Tipo2
		 , Pagos.Numero2 as Numero2
		 , Pagos.Renglon as Renglon
		 , Pagos.Importe1 as Importe1
		 
	from surfactanSA.dbo.pagos pagos
	LEFT JOIN Proveedor Prove on Prove.Proveedor = Pagos.Proveedor
	WHERE pagos.FechaOrd between @DesdeFecha and @HastaFecha
		and pagos.banco2 between @DesdeBanco and @HastaBanco
		and pagos.Tipo2 = '02'
	order by pagos.Clave

GO
/****** Object:  StoredProcedure [dbo].[PR_buscar_pagos_movbanII]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[PR_buscar_pagos_movbanII]
	(@DesdeFecha char(8)
	, @HastaFecha char(8)
	, @DesdeBanco int
	, @HastaBanco int)
AS
	select Pagos.FechaOrd as FechaOrd
		 , Pagos.Orden as Orden
		 , Pagos.TipoOrd as TipoOrd
		 , Pagos.Banco2 as Banco2
		 , Pagos.Cuenta as Cuenta
		 , Pagos.Proveedor as Proveedor
		 , Pagos.Fecha as Fecha
		 , Pagos.Fecha2 as Fecha2
		 , Pagos.FechaOrd2 as FechaOrd2
		 , Pagos.TipoReg as Tiporeg
		 , Pagos.Observaciones as Observaciones
		 , Pagos.Importe2 as Importe2
		 , Pagos.Tipo2 as Tipo2
		 , Pagos.Numero2 as Numero2
		 , Pagos.Renglon as Renglon
		 , Pagos.Importe1 as Importe1
		 
	from surfactanSA.dbo.pagos pagos
	--JOIN Proveedor Prove on Prove.Proveedor = Pagos.Proveedor
	WHERE pagos.FechaOrd between @DesdeFecha and @HastaFecha
		and pagos.banco2 between @DesdeBanco and @HastaBanco
		and pagos.banco2 <> 0
		--and pagos.TipoReg = '1'
	order by pagos.Clave

GO
/****** Object:  StoredProcedure [dbo].[PR_buscar_proveedor_por_codigo]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PR_buscar_proveedor_por_codigo]
	(@codigo varchar(11))
AS
	SELECT ISNULL(Proveedor,'') as Proveedor
		,ISNULL(Nombre,'') as Nombre
		, ISNULL(Direccion,'') as Direccion
		, ISNULL(Localidad,'') as Localidad
		, ISNULL(Provincia,'') as Provincia
		, ISNULL(Postal,'') as Postal
		, ISNULL(Region,0) as Region
		, ISNULL(Telefono,'') as Telefono
		, ISNULL(Dias,'') as Dias
		, ISNULL(Email,'') as Email
		, ISNULL(Observaciones,'') as Observaciones
		, ISNULL(Cuit,'') as Cuit
		, ISNULL(Tipo,'') as Tipo
		, ISNULL(Iva,'') as Iva
		, ISNULL(Cuenta,'') as Cuenta
		, ISNULL(NombreCheque,'') as NombreCheque
		, ISNULL(CodIb,0) as CodIb
		, ISNULL(CodIbCaba,0) as CodIbCaba
		, ISNULL(NroIb,'') as NroIb
		, ISNULL(PorceIb,0.0) as PorceIb
		, ISNULL(PorceIbCaba,0.0) as PorceIbCaba
		, ISNULL(TipoProv,0) as TipoProv
		, ISNULL(NroInsc,'') as NroInsc
		, ISNULL(FechaNroInsc,'  /  /    ') as FechaNroInsc
		, ISNULL(CategoriaI,0) as CategoriaI
		, ISNULL(CategoriaII,0) as CategoriaII
		, ISNULL(FechaCategoria,'  /  /    ') as FechaCategoria
		, ISNULL(IbCiudadII,0) as IbCiudadII
		, ISNULL(Cai,'') as Cai 
		, ISNULL(VtoCai,'') as VtoCai
		, ISNULL(Iso,0) as Iso
		, ISNULL(VtoIso,'') as VtoIso
		, ISNULL(Estado,0) as Estado
		, ISNULL(Califica,0.0) as Califica
		, ISNULL(FechaCalifica,'  /  /    ') as FechaCalifica
		, ISNULL(ObservacionesII,'') as ObservacionesII
		, ISNULL(Cufe,'') as Cufe
		, ISNULL(CufeII,'') as CufeII
		, ISNULL(CufeIII,'') as CufeIII
		, ISNULL(DirCufe,'') as DirCufe
		, ISNULL(DirCufeII,'') as DirCufeII
		, ISNULL(DirCufeIII,'') as DirCufeIII
		, ISNULL(PaginaWeb,'') as PaginaWeb
		, ISNULL(ContactoNombre1,'') as ContactoNombre1
		, ISNULL(ContactoCargo1,'') as ContactoCargo1
		, ISNULL(ContactoTelefono1,'') as ContactoTelefono1
		, ISNULL(ContactoEmail1,'') as ContactoEmail1
		, ISNULL(ContactoNombre2,'') as ContactoNombre2
		, ISNULL(ContactoCargo2,'') as ContactoCargo2
		, ISNULL(ContactoTelefono2,'') as ContactoTelefono2
		, ISNULL(ContactoEmail2,'') as ContactoEmail2
		, ISNULL(ContactoNombre3,'') as ContactoNombre3
		, ISNULL(ContactoCargo3,'') as ContactoCargo3
		, ISNULL(ContactoTelefono3,'') as ContactoTelefono3
		, ISNULL(ContactoEmail3,'') as ContactoEmail3
		, ISNULL(ClienteAsociado,'') as ClienteAsociado
		, ISNULL(Inhabilitado,'0') as Inhabilitado
		, ISNULL(Embargo,'') as Embargo
	FROM Proveedor p 
	WHERE p.Proveedor = @codigo
GO
/****** Object:  StoredProcedure [dbo].[PR_buscar_proveedor_por_nombre]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[PR_buscar_proveedor_por_nombre]
	(@nombre varchar(50))
AS
	select LTRIM(RTRIM(p.Proveedor)) as Codigo, LTRIM(RTRIM(p.Nombre)) as Nombre, ISNULL(p.Inhabilitado,'0') as Inhabilitado
	from surfactanSA.dbo.Proveedor p
	where p.Nombre like '%' + @nombre + '%'
	order by p.Nombre

GO
/****** Object:  StoredProcedure [dbo].[PR_buscar_recibos_fecha]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





CREATE PROCEDURE [dbo].[PR_buscar_recibos_fecha]
	(@DesdeFecha char(8)
	, @HastaFecha char(8))
	AS
	select isnull(Recibos.FechaOrd,'') as FechaOrd
		 , isnull(recibos.Recibo,'') as Recibo
		 , isnull(recibos.TipoReg,'') as TipoReg
		 , isnull(recibos.TipoRec,'') as TipoRec
		 , isnull(recibos.Cuenta,'') as Cuenta
		 , isnull(recibos.Cliente,'') as Cliente
		 , isnull(recibos.Tipo1,'') as Tipo1
		 , isnull(recibos.letra1,'') as Letra1
		 , isnull(recibos.Punto1,'') as Punto1
		 , isnull(recibos.Numero1,'') as Numero1
		 , isnull(recibos.Fecha,'') as Fecha
		 , isnull(recibos.Tipo2,'') as Tipo2
		 , isnull(recibos.Numero2,'') as Numero2
		 , isnull(recibos.Importe1,0) as Importe1
		 --, isnull(recibos.Paridad,0) as Paridad
		 , isnull(recibos.Importe2,0) as Importe2
		 , isnull(recibos.RetIva,0) as RetIva
		 , isnull(recibos.RetOtra,0) as RetOtra
		 , isnull(recibos.RetSuss,0) as RetSuss
		 , isnull(recibos.RetGanancias,0) as RetGanancias
		 , isnull(recibos.Renglon,0) as Renglon
		 , isnull(C.Provincia,'') as Provincia

from recibos
	--LEFT JOIN Cliente Clie on Clie.Cliente = recibos.Cliente
	LEFT OUTER JOIN Cliente C ON recibos.Cliente = C.Cliente WHERE recibos.Fechaord >= @DesdeFecha and recibos.Fechaord <= @HastaFecha
	order by recibos.Recibo

GO
/****** Object:  StoredProcedure [dbo].[PR_buscar_recibos_fecha2]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO






CREATE PROCEDURE [dbo].[PR_buscar_recibos_fecha2]
	(@DesdeFecha char(8)
	, @HastaFecha char(8))
	AS
	select isnull(Recibos.FechaOrd,'') as FechaOrd
		 , isnull(recibos.Recibo,'') as Recibo
		 , isnull(recibos.TipoReg,'') as TipoReg
		 , isnull(recibos.TipoRec,'') as TipoRec
		 , isnull(recibos.Cuenta,'') as Cuenta
		 , isnull(recibos.Cliente,'') as Cliente
		 , isnull(recibos.Tipo1,'') as Tipo1
		 , isnull(recibos.letra1,'') as Letra1
		 , isnull(recibos.Punto1,'') as Punto1
		 , isnull(recibos.Numero1,'') as Numero1
		 , isnull(recibos.Fecha,'') as Fecha
		 , isnull(recibos.Tipo2,'') as Tipo2
		 , isnull(recibos.Numero2,'') as Numero2
		 , isnull(recibos.Importe1,0) as Importe1
		 --, isnull(recibos.Paridad,0) as Paridad
		 , isnull(recibos.Importe2,0) as Importe2
		 , isnull(recibos.RetIva,0) as RetIva
		 , isnull(recibos.RetOtra,0) as RetOtra
		 , isnull(recibos.RetSuss,0) as RetSuss
		 , isnull(recibos.RetGanancias,0) as RetGanancias
		 , isnull(recibos.Renglon,0) as Renglon
		 , isnull(C.Provincia,'') as Provincia

from recibos
	--LEFT JOIN Cliente Clie on Clie.Cliente = recibos.Cliente
	LEFT OUTER JOIN Cliente C ON recibos.Cliente = C.Cliente WHERE recibos.Fechaord >= @DesdeFecha and recibos.Fechaord <= @HastaFecha
	order by recibos.Recibo


GO
/****** Object:  StoredProcedure [dbo].[PR_buscar_recibos_movban]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[PR_buscar_recibos_movban]
	(@DesdeFecha char(8)
	, @HastaFecha char(8))
AS
	select Recibos.FechaOrd as FechaOrd
		 , recibos.Recibo as Recibo
		 , recibos.TipoReg as TipoReg
		 , recibos.TipoRec as TipoRec
		 , recibos.Cuenta as Cuenta
		 , recibos.Cliente as Cliente
		 , recibos.Tipo1 as Tipo1
		 , recibos.letra1 as Letra1
		 , recibos.Punto1 as Punto1
		 , recibos.Numero1 as Numero1
		 , recibos.Fecha as Fecha
		 , recibos.Tipo2 as Tipo2
		 , recibos.Numero2 as Numero2
		 , recibos.Importe1 as Importe1
		 --, recibos.Paridad as Paridad
		 , recibos.Importe2 as Importe2
		 , recibos.RetIva as RetIva
		 , recibos.RetOtra as RetOtra
		 , recibos.RetSuss as RetSuss
		 , recibos.RetGanancias as RetGanancias
		 , recibos.Renglon as Renglon
		 , ISNULL(Clie.Provincia, '') as Provincia
		 
	from surfactanSA.dbo.Recibos recibos
	LEFT JOIN Cliente Clie on Clie.Cliente = recibos.Cliente
	WHERE recibos.Fechaord between @DesdeFecha and @HastaFecha
		and (recibos.Cuenta = '21' or recibos.Cuenta = '22' or recibos.Cuenta = '25' or 
		     recibos.Cuenta = '26' or recibos.Cuenta = '27')
	order by recibos.Clave


GO
/****** Object:  StoredProcedure [dbo].[PR_buscar_recibos_transferencias]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO






CREATE PROCEDURE [dbo].[PR_buscar_recibos_transferencias]
	(@DesdeFecha char(	8)
	, @HastaFecha char(8)
	, @Renglon int)
AS
	select Recibo.Recibo as Banco2
		 , Recibo.Fecha as Fecha
		 , Recibo.FechaOrd as FechaOrd
		 , Recibo.Importe as Importe
		 , Recibo.Cuenta as Cuenta
		 
	from surfactanSA.dbo.Recibos Recibo
	WHERE Recibo.FechaOrd between @DesdeFecha and @HastaFecha
	and (Recibo.Cuenta = '21' or Recibo.Cuenta = '22' or Recibo.Cuenta = '26' or Recibo.Cuenta = '27')
	order by Recibo.Clave

GO
/****** Object:  StoredProcedure [dbo].[PR_buscar_rubro]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[PR_buscar_rubro]
	(@Rubro int)
AS
	select rubro.rubro as Rubro, LTRIM(RTRIM(Rubro.Nombre)) as Nombre
	from surfactanSA.dbo.Rubros Rubro
	where Rubro.Rubro = @Rubro
	
GO
/****** Object:  StoredProcedure [dbo].[PR_buscar_rubro_por_nombre]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[PR_buscar_rubro_por_nombre]
	(@nombre varchar(50))
AS
	select Rubro.Rubro as Rubro, LTRIM(RTRIM(rubro.Nombre)) as Nombre
	from surfactanSA.dbo.Rubros Rubro
	where rubro.Nombre like '%' + @nombre + '%' and Rubro.Nombre <> ''
	order by rubro.Nombre

GO
/****** Object:  StoredProcedure [dbo].[PR_buscar_rubro_proveedor_por_codigo]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[PR_buscar_rubro_proveedor_por_codigo]
	(@codigo int)
AS
	SELECT tp.Codigo
		, LTRIM(RTRIM(tp.Descripcion)) as Descripcion
	FROM TipoProv tp 
	WHERE tp.Codigo = @codigo
GO
/****** Object:  StoredProcedure [dbo].[PR_buscar_rubro_proveedor_por_descripcion]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[PR_buscar_rubro_proveedor_por_descripcion]
	(@descripcion varchar(50))
AS
	select tp.Codigo as Codigo, LTRIM(RTRIM(tp.Descripcion)) as Descripcion
	from surfactanSA.dbo.TipoProv tp
	where tp.Descripcion like '%' + @descripcion + '%'
	order by tp.Codigo
GO
/****** Object:  StoredProcedure [dbo].[PR_buscar_terminado_por_codigo]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[PR_buscar_terminado_por_codigo]
	(@Codigo varchar(12))
AS
	SELECT LTRIM(RTRIM(Termi.Codigo)) as Codigo
		, termi.Descripcion as Descrricpion
	FROM Terminado Termi
	WHERE Codigo = @Codigo

GO
/****** Object:  StoredProcedure [dbo].[PR_buscar_terminado_por_nombre]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[PR_buscar_terminado_por_nombre]
	(@nombre varchar(50))
AS
	select Termi.Codigo as Codigo, LTRIM(RTRIM(termi.Descripcion)) as Descricpion
	from surfactanSA.dbo.Terminado Termi
	where Termi.Descripcion like '%' + @nombre + '%' and Termi.Descripcion <> ''
	order by Termi.Descripcion

GO
/****** Object:  StoredProcedure [dbo].[PR_buscar_tipo_cambio_por_fecha]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[PR_buscar_tipo_cambio_por_fecha]
	(@fecha varchar(10))
AS
	SELECT ca.Fecha
		, ca.Cambio
	FROM surfactanSA.dbo.Cambios ca
	WHERE ca.Fecha = @fecha

GO
/****** Object:  StoredProcedure [dbo].[PR_buscar_tipo_cambio_por_fecha_pago]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[PR_buscar_tipo_cambio_por_fecha_pago]
	(@fecha varchar(10))
AS
	SELECT ca.Fecha
		, ca.CambioDivisa
	FROM surfactanSA.dbo.Cambios ca
	WHERE ca.Fecha = @fecha


GO
/****** Object:  StoredProcedure [dbo].[PR_buscar_vendedor_por_codigo]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[PR_buscar_vendedor_por_codigo]
	(@vendedor int)
AS
	select Vende.Vendedor as Vendedor
		 , Vende.Nombre as Nombre
		 
		 
	from surfactanSA.dbo.Vendedor Vende
	WHERE Vende.Vendedor = @vendedor


GO
/****** Object:  StoredProcedure [dbo].[PR_buscar_vendedor_por_nombre]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[PR_buscar_vendedor_por_nombre]
	(@nombre varchar(50))
AS
	select vende.Vendedor as Vendedor, LTRIM(RTRIM(vende.Nombre)) as Nombre
	from surfactanSA.dbo.vendedor Vende
	where vende.Nombre like '%' + @nombre + '%' and Vende.Nombre <> ''
	order by vende.Nombre

GO
/****** Object:  StoredProcedure [dbo].[PR_depurar_cuentas_corrientes]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

CREATE PROCEDURE [dbo].[PR_depurar_cuentas_corrientes] 
AS
BEGIN
-- AGREGO SALDO <> 0 PARA QUE MODIFIQUE MENOS 
-- REGISTOS Y DE ESTA FORMA SEA MAS RAPIDO
	UPDATE surfactanSA.dbo.CtaCte
	SET Saldo = 0
	WHERE Saldo between (-0.1) and (0.1)
		and Saldo <> 0
	 
	UPDATE surfactanSA.dbo.CtaCtePrv
	SET Saldo = 0
	WHERE Saldo between (-0.1) and (0.1) 
		and Saldo <> 0
END
GO
/****** Object:  StoredProcedure [dbo].[PR_factura_pagada]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

CREATE PROCEDURE [dbo].[PR_factura_pagada]
	(@nro_interno int)
AS
	IF EXISTS (SELECT *
	FROM CtaCtePrv cta
	WHERE cta.NroInterno = @nro_interno
	AND cta.Saldo <> cta.Total)
	RETURN 1
	ELSE
	RETURN 0
GO
/****** Object:  StoredProcedure [dbo].[PR_get_banco]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[PR_get_banco] ( @accion varchar(10), @banco smallint )
AS
BEGIN
	declare @ultimo varchar(10) = (SELECT MAX(ba.banco) FROM surfactanSA.dbo.Banco ba)
	declare @primero varchar(10) = (SELECT MIN(ba.banco) FROM surfactanSA.dbo.Banco ba)
	IF(@accion = 'primero' or @accion = 'siguiente')

			SELECT ba_2.Banco, ba_2.Nombre, ba_2.Cuenta
			FROM surfactanSA.dbo.Banco ba_2
			WHERE  ba_2.Banco = (SELECT TOP 1 ba_int.Banco 
									FROM surfactanSA.dbo.Banco ba_int 
									WHERE LTRIM(RTRIM(ba_int.Banco)) > CASE  
																			WHEN @accion = 'primero' or @ultimo <= @banco THEN (-1)
																			ELSE @banco
																		END  
									ORDER BY ba_int.Banco)

		ELSE

			SELECT ba_2.Banco, ba_2.Nombre, ba_2.Cuenta
				FROM surfactanSA.dbo.Banco ba_2
				WHERE  ba_2.Banco = (SELECT TOP 1 ba_int.Banco 
										FROM surfactanSA.dbo.Banco ba_int 
										WHERE LTRIM(RTRIM(ba_int.Banco)) < CASE  
																				WHEN @accion = 'ultimo' or @primero >= @banco THEN 32767
																				ELSE @banco
																			END  
										ORDER BY ba_int.Banco DESC)

END
GO
/****** Object:  StoredProcedure [dbo].[PR_get_carga_intereses]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

CREATE PROCEDURE [dbo].[PR_get_carga_intereses] (@tipo char(1))
AS
	SELECT ISNULL(ccp.FechaOriginal,'') FechaOriginal 
		, RTRIM(ISNULL(ccp.DesProveOriginal,'')) DesProveOriginal
		, ISNULL(ccp.FacturaOriginal,'') FacturaOriginal
		, ISNULL(ccp.Cuota,'') Cuota
		, ISNULL(ccp.fecha,'') fecha
		, ISNULL(ccp.Saldo,0) as Saldo
		, ISNULL(ccp.Interes,0) as Intereses
		, ISNULL(ccp.IvaInteres,0) as IvaIntereses
		, ISNULL(ccp.Referencia,'') as Referencia
		, ISNULL(ccp.Clave,'') Clave
		, ISNULL(ccp.NroInterno,'') NroInterno
	FROM CtaCtePrv ccp
	WHERE ccp.Proveedor = '10077777777'
		AND ((@tipo = 'C' 
			and ISNULL(ccp.Saldo,0) <> 0
			and ISNULL(ccp.Interes,0) = 0)
			OR
			(@tipo = 'M' 
			and ISNULL(ccp.Saldo,0) <> 0
			and ISNULL(ccp.Interes,0) <> 0))

	ORDER BY ccp.OrdFechaOriginal
GO
/****** Object:  StoredProcedure [dbo].[PR_get_cheque_en_cartera]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

CREATE PROCEDURE [dbo].[PR_get_cheque_en_cartera] 
AS
BEGIN

	--SELECT *
	--FROM
	--(
		SELECT 
			 re.Estado2
			, re.Importe2
			, re.Numero2
			, re.Fecha2
			, LTRIM(RTRIM(re.banco2)) as banco2
			, re.Clave
			, re.FechaOrd2
			, 'Recibos' AS Tabla
		FROM surfactanSA.dbo.Recibos re
		WHERE re.TipoReg = 2
			AND re.Estado2 <> 'X'
			AND re.Tipo2 = '02'
		ORDER BY re.FechaOrd2, re.Numero2
			
	--	UNION ALL
		
	--	SELECT 
	--		 rep.Estado2
	--		, rep.Importe2
	--		, rep.Numero2
	--		, rep.Fecha2
	--		, LTRIM(RTRIM(rep.banco2)) as banco2
	--		, rep.Clave
	--		, rep.FechaOrd2
	--		, 'RecibosProvisorios' AS Tabla
	--	FROM surfactanSA.dbo.RecibosProvi rep
	--	WHERE rep.TipoReg = 2
	--		AND rep.Estado2 = 'P'
	--		AND rep.Tipo2 = '02'
	--		AND ISNULL(rep.ReciboDefinitivo,0) = 0 
	--)td
	--ORDER BY td.FechaOrd2, td.Numero2

END
GO
/****** Object:  StoredProcedure [dbo].[PR_get_cheques_propios]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

CREATE PROCEDURE [dbo].[PR_get_cheques_propios] (@cheque varchar(8)) AS

	SELECT 	LTRIM(RTRIM(ISNULL(p.Numero2,''))) as Numero2
		, LTRIM(RTRIM(ISNULL(p.Observaciones2,''))) as Banco2
		, p.Importe2
		, LTRIM(RTRIM(ISNULL(p.Fecha,''))) as Fecha
		, LTRIM(RTRIM(ISNULL(p.Fecha2,''))) as Fecha2
		, 'O.P.: ' + LTRIM(RTRIM(ISNULL(p.Orden,''))) as Recibo
		, p.Proveedor + ' ' + LTRIM(RTRIM(ISNULL(pro.Nombre,p.Observaciones))) as Proveedor 
	FROM Pagos p
	LEFT JOIN Proveedor pro on pro.Proveedor = p.Proveedor
	Where Tiporeg = '2' and Tipo2 = '02'
		and ISNULL(Numero2,'') LIKE ('%' + @cheque + '')
	ORDER BY p.FechaOrd2	

GO
/****** Object:  StoredProcedure [dbo].[PR_get_cheques_terceros]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

CREATE PROCEDURE [dbo].[PR_get_cheques_terceros] (@cheque varchar(8)) AS

	SELECT 
		LTRIM(RTRIM(ISNULL(td.Numero2,''))) as Numero2
		, LTRIM(RTRIM(ISNULL(td.Banco,''))) as Banco
		, td.Importe2
		, LTRIM(RTRIM(ISNULL(td.Fecha,''))) as Fecha
		, LTRIM(RTRIM(ISNULL(td.Fecha2,''))) as Fecha2
		, LTRIM(RTRIM(ISNULL(td.Recibo,''))) as Recibo
		, LTRIM(RTRIM(ISNULL(td.Cliente,''))) as Cliente
	FROM
	(
		SELECT r.Numero2
			, r.Banco2 as Banco
			, r.Importe2
			, r.Fecha
			, r.Fecha2
			, 'Rec: ' + r.Recibo as Recibo
			, r.Cliente + ' ' + cli.Razon as Cliente
			, r.FechaOrd2 as orden1
			, r.Numero2 as orden2
		FROM Recibos r
		JOIN Cliente cli on cli.Cliente = r.Cliente
		Where	Tiporeg= '2' 
			and  (Tipo2 = '2' or Tipo2 = '02')
			and ISNULL(Numero2,'') LIKE ('%' + @cheque + '')			
			
		UNION ALL
		
		SELECT d.Numero2
			, d.Observaciones2
			, d.Importe2
			, d.Fecha
			, d.Fecha2
			, 'Dep: ' + d.Deposito as Deposito
			, LTRIM(RTRIM(b.Cuenta)) + ' ' + LTRIM(RTRIM(ISNULL(b.Nombre,''))) as Nombre
			, d.Deposito 
			, 1 
		FROM Depositos d
		JOIN Banco b on b.Banco = d.Banco
		Where (Tipo2 = '3' Or Tipo2= '03')
			and ISNULL(Numero2,'') LIKE ('%' + @cheque + '')	

		UNION ALL
		
		SELECT p.Numero2
			, p.Observaciones2
			, p.Importe2
			, p.Fecha
			, p.Fecha2
			, 'O.P.: ' + p.Orden as Orden
			, p.Proveedor + ' ' + LTRIM(RTRIM(ISNULL(pro.Nombre,p.Observaciones))) 
			, p.Orden
			, 1
		FROM Pagos p
		LEFT JOIN Proveedor pro on pro.Proveedor = p.Proveedor
		Where  Tiporeg = '2' 
			and (Tipo2 = '3' Or Tipo2= '03')
			and ISNULL(Numero2,'') LIKE ('%' + @cheque + '')	
			
	)td
	--ORDER BY td.orden1, td.orden2
GO
/****** Object:  StoredProcedure [dbo].[PR_get_clave_lectora]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

CREATE PROCEDURE [dbo].[PR_get_clave_lectora] 
	(@clave char(31)
	, @tabla varchar(20))
AS
BEGIN

	declare @sql varchar(max)
		
	SET @sql = 'SELECT clave, recibo FROM '
	
	
	SET @sql = @sql + CASE @tabla WHEN 'recibos' THEN 'Recibos'
									ELSE 'RecibosProvi'
						END
	
	SET @sql = @sql + ' WHERE claveCheque = ''' + @clave + ''';'
	
	exec (@sql) 

END
GO
/****** Object:  StoredProcedure [dbo].[PR_get_cliente_por_codigo]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

CREATE PROCEDURE [dbo].[PR_get_cliente_por_codigo]
	@cliente varchar(6)
AS
	SELECT cli.Cliente
		, cli.Razon
	FROM Cliente cli
	WHERE cli.Cliente = @cliente
GO
/****** Object:  StoredProcedure [dbo].[PR_get_cliente_por_codigo_total]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[PR_get_cliente_por_codigo_total]
	@cliente varchar(6)
AS
	SELECT cli.Cliente
		, cli.Razon
		,cli.Provincia
	FROM Cliente cli
	WHERE cli.Cliente = @cliente

GO
/****** Object:  StoredProcedure [dbo].[PR_get_cliente_por_razon]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

CREATE PROCEDURE [dbo].[PR_get_cliente_por_razon]
	@razon varchar(50)
AS
	SELECT cli.Cliente
		, cli.Razon
	FROM Cliente cli
	WHERE cli.Razon LIKE '%' + @razon + '%' and cli.Razon <> ''
GO
/****** Object:  StoredProcedure [dbo].[PR_get_compra_por_codigo]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

CREATE PROCEDURE [dbo].[PR_get_compra_por_codigo]
	(@nro_interno int)
AS
	SELECT *
	FROM IvaComp ic
	WHERE ic.NroInterno = @nro_interno
GO
/****** Object:  StoredProcedure [dbo].[PR_get_cuenta]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[PR_get_cuenta] ( @accion varchar(10), @cuenta varchar(10) )
AS
BEGIN
	declare @ultimo varchar(10) = (SELECT MAX(cu.Cuenta) FROM surfactanSA.dbo.Cuenta cu)
	declare @primero varchar(10) = (SELECT MIN(cu.Cuenta) FROM surfactanSA.dbo.Cuenta cu)
	IF(@accion = 'primero' or @accion = 'siguiente')
	
		
			SELECT cu_2.Cuenta, cu_2.Descripcion
			FROM surfactanSA.dbo.Cuenta cu_2
			WHERE cu_2.Cuenta = (SELECT TOP 1 cu_int.Cuenta 
									FROM surfactanSA.dbo.Cuenta cu_int 
									WHERE LTRIM(RTRIM(cu_int.Cuenta)) > CASE  
																			WHEN @accion = 'primero' or @ultimo <= @cuenta THEN ''
																			ELSE @cuenta
																		END  
									ORDER BY cu_int.Cuenta)
	
		ELSE
	

			SELECT cu_1.Cuenta, cu_1.Descripcion
			FROM surfactanSA.dbo.Cuenta cu_1
			WHERE cu_1.Cuenta = (SELECT TOP 1 cu_int.Cuenta 
									FROM surfactanSA.dbo.Cuenta cu_int 
									WHERE LTRIM(RTRIM(cu_int.Cuenta)) < CASE  
																			WHEN @accion = 'ultimo' or @primero >= @cuenta THEN 'zzzzzzzzzz'
																			ELSE @cuenta
																		END 
									ORDER BY cu_int.Cuenta DESC) 
	
	
END
GO
/****** Object:  StoredProcedure [dbo].[PR_get_cuenta_corriente_por_clave]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

CREATE PROCEDURE [dbo].[PR_get_cuenta_corriente_por_clave]
	@Clave Char(12)
 AS
 -- SOLO TRAJE ESTOS PORQUE SON LOS QUE FUI VIENDO QUE SE USAN EN EL PROCESO DE LOS RECIBOS
	SELECT cc.Clave 
		, cc.Saldo
		, cc.TotalUs
		, cc.Total
		, cc.Estado
	FROM Ctacte cc
	WHERE
		Clave = @Clave
GO
/****** Object:  StoredProcedure [dbo].[PR_get_cuentas_sin_saldar]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

CREATE PROCEDURE [dbo].[PR_get_cuentas_sin_saldar]
	(@Proveedor varchar(11))
AS
	SELECT *
	FROM CtaCtePrv cta
	WHERE
	cta.Proveedor = @Proveedor AND
	cta.Saldo <> 0
GO
/****** Object:  StoredProcedure [dbo].[PR_get_datos_nacion]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

CREATE PROCEDURE [dbo].[PR_get_datos_nacion]
	@NroInterno int
AS
	SELECT TOP 1 ic.Vencimiento as fecha
		, (SELECT COUNT(*) FROM IvaComp ic2 WHERE NroInternoAsociado = @NroInterno) as cantidad
	FROM IvaComp ic
	WHERE NroInternoAsociado = @NroInterno	
	ORDER BY NroInterno
GO
/****** Object:  StoredProcedure [dbo].[PR_get_deposito_por_numero]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

CREATE PROCEDURE [dbo].[PR_get_deposito_por_numero]
	@Numero Char(6)
 AS
SELECT *
FROM Depositos 
WHERE
	Deposito = @Numero
GO
/****** Object:  StoredProcedure [dbo].[PR_get_imputaciones_por_nro_interno]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

CREATE PROCEDURE [dbo].[PR_get_imputaciones_por_nro_interno]
	(@nro_interno int)
AS
	SELECT *
	FROM Imputac im
	WHERE im.NroInterno = @nro_interno
GO
/****** Object:  StoredProcedure [dbo].[PR_get_interno_segun]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

CREATE procedure [dbo].[PR_get_interno_segun]
	(@codigo varchar(11)
	, @tipo varchar(2)
	, @letra varchar(1)
	, @punto varchar(4)
	, @numero varchar(8))
AS
BEGIN
	
	declare @clave varchar(26) = @codigo + @letra + @tipo + @punto + @numero
	declare @numero_int varchar(8)

	SELECT @numero_int = ccp.NroInterno
	FROM CtaCtePrv ccp
	WHERE ccp.Clave = @clave
		
	return (CONVERT(int, @numero_int))
END
GO
/****** Object:  StoredProcedure [dbo].[PR_get_iva_compras_adicional]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

CREATE PROCEDURE [dbo].[PR_get_iva_compras_adicional]
	@NroInterno int
AS
BEGIN


	SELECT 
			Clave , NroInterno , Renglon , Cuit , Razon , Tipo ,
			Letra , Punto , Numero , Fecha , OrdFecha , Neto ,
			Iva21 , Iva27 , Iva105 , PerceIva , PerceIb , Exento
	FROM IvaCompAdicional
	WHERE NroInterno = @NroInterno

END
GO
/****** Object:  StoredProcedure [dbo].[PR_get_mes_esta_cerrado]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

CREATE PROCEDURE [dbo].[PR_get_mes_esta_cerrado] (@mes int, @ano int)
AS
	/*
			ESTADO
	------------------------
		0 -------- Abierto		
		1 -------- Cerrado
		NO ESTA -- Cerrado
	*/
	SELECT	ISNULL( (SELECT c.Estado
					FROM Cierre c
					WHERE c.Mes = @mes 
						AND c.Ano = @ano)
					,1) AS Cerrado
GO
/****** Object:  StoredProcedure [dbo].[PR_get_pago_por_orden]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

CREATE PROCEDURE [dbo].[PR_get_pago_por_orden] (@orden VARCHAR(6)) AS
	SELECT p.Orden
		, p.TipoOrd
		, p.Fecha
		, p.Proveedor
		, p.Observaciones
		, p.banco2 AS banco
		, p.Fecha2 AS fechaParidad
		, p.Paridad
		, p.Retencion
		, p.RetGanancias
		, p.RetOtra AS RetencionIB
		, p.RetIbCiudad
		, p.RetIva
		, p.Importe
		, p.TipoReg
		, p.Tipo1
		, p.Letra1
		, p.Punto1
		, p.Numero1
		, p.Importe1
		, p.cuenta
		, p.Observaciones2
		, p.Tipo2
		, p.Numero2
		, p.FechaCheque
		, p.banco2
		, RTRIM(p.BancoCheque) AS NombreCheque
		, p.Importe2
		, p.Cuit
		, ISNULL(p.ImpoNeto,0) as ImpoNeto
		, p.CertificadoIb
		, p.CertificadoIbCiudad
		, p.CertificadoIva
	FROM Pagos p
	WHERE p.Orden = @orden
	order by Renglon
GO
/****** Object:  StoredProcedure [dbo].[PR_get_paridad]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

CREATE PROCEDURE [dbo].[PR_get_paridad] (@fecha date)
AS
BEGIN	
	declare @paridad varchar(10)
	 
	select @paridad = c.Cambio
	from CambioAdm c
	where c.Fecha = @fecha
	
	return ISNULL(@paridad,'0')
END
GO
/****** Object:  StoredProcedure [dbo].[PR_get_proveedor]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[PR_get_proveedor] ( @accion varchar(10), @proveedor varchar(11) )
AS
BEGIN
	declare @ultimo varchar(11) = (SELECT MAX(p.Proveedor) FROM surfactanSA.dbo.Proveedor p)
	declare @primero varchar(11) = (SELECT MIN(p.Proveedor) FROM surfactanSA.dbo.Proveedor p)
	IF(@accion = 'primero' or @accion = 'siguiente')

			SELECT ISNULL(Proveedor,'') as Proveedor
				,ISNULL(Nombre,'') as Nombre
				, ISNULL(Direccion,'') as Direccion
				, ISNULL(Localidad,'') as Localidad
				, ISNULL(Provincia,'') as Provincia
				, ISNULL(Postal,'') as Postal
				, ISNULL(Region,0) as Region
				, ISNULL(Telefono,'') as Telefono
				, ISNULL(Dias,'') as Dias
				, ISNULL(Email,'') as Email
				, ISNULL(Observaciones,'') as Observaciones
				, ISNULL(Cuit,'') as Cuit
				, ISNULL(Tipo,'') as Tipo
				, ISNULL(Iva,'') as Iva
				, ISNULL(Cuenta,'') as Cuenta
				, ISNULL(NombreCheque,'') as NombreCheque
				, ISNULL(CodIb,0) as CodIb
				, ISNULL(CodIbCaba,0) as CodIbCaba
				, ISNULL(NroIb,'') as NroIb
				, ISNULL(PorceIb,0.0) as PorceIb
				, ISNULL(PorceIbCaba,0.0) as PorceIbCaba
				, ISNULL(TipoProv,0) as TipoProv
				, ISNULL(NroInsc,'') as NroInsc
				, ISNULL(FechaNroInsc,'  /  /    ') as FechaNroInsc
				, ISNULL(CategoriaI,0) as CategoriaI
				, ISNULL(CategoriaII,0) as CategoriaII
				, ISNULL(FechaCategoria,'  /  /    ') as FechaCategoria
				, ISNULL(IbCiudadII,0) as IbCiudadII
				, ISNULL(Cai,'') as Cai 
				, ISNULL(VtoCai,'') as VtoCai
				, ISNULL(Iso,0) as Iso
				, ISNULL(VtoIso,'') as VtoIso
				, ISNULL(Estado,0) as Estado
				, ISNULL(Califica,0.0) as Califica
				, ISNULL(FechaCalifica,'  /  /    ') as FechaCalifica
				, ISNULL(ObservacionesII,'') as ObservacionesII
				, ISNULL(Cufe,'') as Cufe
				, ISNULL(CufeII,'') as CufeII
				, ISNULL(CufeIII,'') as CufeIII
				, ISNULL(DirCufe,'') as DirCufe
				, ISNULL(DirCufeII,'') as DirCufeII
				, ISNULL(DirCufeIII,'') as DirCufeIII
			FROM surfactanSA.dbo.Proveedor p2
			WHERE p2.Proveedor = (SELECT TOP 1 p_int.Proveedor
									FROM surfactanSA.dbo.Proveedor p_int 
									WHERE p_int.Proveedor > CASE  
																WHEN @accion = 'primero' or @ultimo <= @proveedor THEN ''
																ELSE @proveedor
															END  
									ORDER BY p_int.Proveedor)

		ELSE


			SELECT ISNULL(Proveedor,'') as Proveedor
				,ISNULL(Nombre,'') as Nombre
				, ISNULL(Direccion,'') as Direccion
				, ISNULL(Localidad,'') as Localidad
				, ISNULL(Provincia,'') as Provincia
				, ISNULL(Postal,'') as Postal
				, ISNULL(Region,0) as Region
				, ISNULL(Telefono,'') as Telefono
				, ISNULL(Dias,'') as Dias
				, ISNULL(Email,'') as Email
				, ISNULL(Observaciones,'') as Observaciones
				, ISNULL(Cuit,'') as Cuit
				, ISNULL(Tipo,'') as Tipo
				, ISNULL(Iva,'') as Iva
				, ISNULL(Cuenta,'') as Cuenta
				, ISNULL(NombreCheque,'') as NombreCheque
				, ISNULL(CodIb,0) as CodIb
				, ISNULL(CodIbCaba,0) as CodIbCaba
				, ISNULL(NroIb,'') as NroIb
				, ISNULL(PorceIb,0.0) as PorceIb
				, ISNULL(PorceIbCaba,0.0) as PorceIbCaba
				, ISNULL(TipoProv,0) as TipoProv
				, ISNULL(NroInsc,'') as NroInsc
				, ISNULL(FechaNroInsc,'  /  /    ') as FechaNroInsc
				, ISNULL(CategoriaI,0) as CategoriaI
				, ISNULL(CategoriaII,0) as CategoriaII
				, ISNULL(FechaCategoria,'  /  /    ') as FechaCategoria
				, ISNULL(IbCiudadII,0) as IbCiudadII
				, ISNULL(Cai,'') as Cai 
				, ISNULL(VtoCai,'') as VtoCai
				, ISNULL(Iso,0) as Iso
				, ISNULL(VtoIso,'') as VtoIso
				, ISNULL(Estado,0) as Estado
				, ISNULL(Califica,0.0) as Califica
				, ISNULL(FechaCalifica,'  /  /    ') as FechaCalifica
				, ISNULL(ObservacionesII,'') as ObservacionesII
				, ISNULL(Cufe,'') as Cufe
				, ISNULL(CufeII,'') as CufeII
				, ISNULL(CufeIII,'') as CufeIII
				, ISNULL(DirCufe,'') as DirCufe
				, ISNULL(DirCufeII,'') as DirCufeII
				, ISNULL(DirCufeIII,'') as DirCufeIII
			FROM surfactanSA.dbo.Proveedor p2
			WHERE p2.Proveedor = (SELECT TOP 1 p_int.Proveedor
									FROM surfactanSA.dbo.Proveedor p_int 
									WHERE p_int.Proveedor < CASE  
																WHEN @accion = 'ultimo' or @primero >= @proveedor THEN '99999999999'
																ELSE @proveedor
															END  
									ORDER BY p_int.Proveedor DESC)
									

END
GO
/****** Object:  StoredProcedure [dbo].[PR_get_provincias]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[PR_get_provincias] 
AS

		SELECT td.codigo, td.Nombre from 
			(SELECT [Provincia] as codigo
				  ,[Nombre]
				  , 0 as orden
			  FROM [surfactanSA].[dbo].[Provincia] pr
			  where pr.Nombre not in ('Exterior', 'Sin Asignar')
			union all
			SELECT [Provincia] as codigo
				  ,[Nombre]
				  , 1 as orden
			  FROM [surfactanSA].[dbo].[Provincia] pr
			  where pr.Nombre = 'Exterior'  
			union all
			SELECT 25 as codigo
				, '' as Nombre
				, 2 as orden
			) td
		order by td.orden, td.Nombre
	RETURN

GO
/****** Object:  StoredProcedure [dbo].[PR_get_recibo]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO


CREATE PROCEDURE [dbo].[PR_get_recibo] (@recibo varchar(6))
AS
	SELECT
		re.Recibo
		, re.Renglon
		, re.Fecha
		, re.Cliente
		, re.RetGanancias	
		, re.RetOtra
		, re.RetIva
		, re.RetSuss
		, re.Paridad
		, re.Observaciones
		, re.TipoRec
		, re.TipoReg
		, re.Tipo1
		, re.Cuenta
		, re.Tipo2
		, re.Numero2
		, re.Fecha2
		, re.banco2
		, re.Importe2
		, re.Tipo1
		, re.Letra1
		, re.Punto1
		, re.Numero1
		, re.Importe1
	FROM Recibos re
	WHERE Recibo = @recibo
	order by Renglon

GO
/****** Object:  StoredProcedure [dbo].[PR_get_recibo_provisorio]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

CREATE PROCEDURE [dbo].[PR_get_recibo_provisorio]
	@recibo varchar(6)
	, @Numero2 varchar(12) = null
AS
	SELECT rp.Recibo
		, RTRIM(rp.Cliente) Cliente
		, c.Razon
		, ISNULL(rp.Fecha,'//') as Fecha
		, ISNULL(rp.RetGanancias, 0.0) RetGanancias
		, ISNULL(rp.RetIva, 0.0) RetIva
		, ISNULL(rp.RetOtra, 0.0) RetOtra
		, ISNULL(rp.RetSuss, 0.0) RetSuss
		, ISNULL(rp.Paridad, 0.0) Paridad
		, TipoReg
		, Tipo2
		, Numero2
		, Fecha2
		, banco2
		, rp.Importe2
		, rp.Importe
	FROM RecibosProvi rp
	JOIN Cliente c on c.Cliente = rp.Cliente
	WHERE rp.Recibo = @recibo
		and rp.Numero2 = ISNULL(@Numero2,rp.Numero2)
GO
/****** Object:  StoredProcedure [dbo].[PR_get_recibo_provisorio_sin_numero]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

CREATE PROCEDURE [dbo].[PR_get_recibo_provisorio_sin_numero]
	@recibo varchar(6)
AS
	SELECT rp.Recibo
		, RTRIM(rp.Cliente) Cliente
		, c.Razon
		, ISNULL(rp.Fecha,'//') as Fecha
		, ISNULL(rp.RetGanancias, 0.0) RetGanancias
		, ISNULL(rp.RetIva, 0.0) RetIva
		, ISNULL(rp.RetOtra, 0.0) RetOtra
		, ISNULL(rp.RetSuss, 0.0) RetSuss
		, ISNULL(rp.Paridad, 0.0) Paridad
		, TipoReg
		, Tipo2
		, Numero2
		, Fecha2
		, banco2
		, rp.Importe2
		, rp.Importe
	FROM RecibosProvi rp
	JOIN Cliente c on c.Cliente = rp.Cliente
	WHERE rp.Recibo = @recibo

GO
/****** Object:  StoredProcedure [dbo].[PR_get_rubro]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[PR_get_rubro] ( @accion varchar(10), @rubro int )
AS
BEGIN
	declare @ultimo int = (SELECT MAX(tp.Codigo) FROM surfactanSA.dbo.TipoProv tp)
	declare @primero int = (SELECT MIN(tp.Codigo) FROM surfactanSA.dbo.TipoProv tp)
	IF(@accion = 'primero' or @accion = 'siguiente')

			SELECT tp2.Codigo, tp2.Descripcion
			FROM surfactanSA.dbo.TipoProv tp2
			WHERE tp2.Codigo = (SELECT TOP 1 tp_int.Codigo 
									FROM surfactanSA.dbo.TipoProv tp_int 
									WHERE tp_int.Codigo > CASE  
																WHEN @accion = 'primero' or @ultimo <= @rubro THEN 0
																ELSE @rubro
															END  
									ORDER BY tp_int.Codigo)

		ELSE

			SELECT tp2.Codigo, tp2.Descripcion
			FROM surfactanSA.dbo.TipoProv tp2
			WHERE tp2.Codigo = (SELECT TOP 1 tp_int.Codigo 
									FROM surfactanSA.dbo.TipoProv tp_int 
									WHERE tp_int.Codigo < CASE  
																WHEN @accion = 'ultimo' or @primero >= @rubro THEN 2000000000
																ELSE @rubro
															END 
									ORDER BY tp_int.Codigo DESC) 

END

GO
/****** Object:  StoredProcedure [dbo].[PR_get_saldo_inicial_pagos]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[PR_get_saldo_inicial_pagos]
	@desde varchar(8)
	, @hasta varchar(8)
	, @desde_banco smallint
	, @hasta_banco smallint
AS
BEGIN
	DECLARE @importe float
-- El isnull interno es para que valgan 0 todos los nullos que pasen el filtro
-- el isnull externo es para que, en caso de que nada pase el filtro, no retorne null sino 0
	SET @importe = (SELECT ISNULL( SUM( ISNULL(p.Importe2,0) ) ,0) 
	FROM Pagos p
	WHERE
		p.Tipo2 = '02'
		AND p.banco2 BETWEEN @desde_banco AND @hasta_banco
		AND p.FechaOrd2 BETWEEN @desde AND @hasta ) 
		
	RETURN @importe
END
GO
/****** Object:  StoredProcedure [dbo].[PR_get_siguiente_deposito]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

CREATE procedure [dbo].[PR_get_siguiente_deposito]
AS
BEGIN
	

	declare @deposito_siguiente varchar(8) = (SELECT MAX(Deposito) FROM Depositos)

	return (CONVERT(int, @deposito_siguiente) + 1)
END
GO
/****** Object:  StoredProcedure [dbo].[PR_get_siguiente_numero_interno]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

CREATE PROCEDURE [dbo].[PR_get_siguiente_numero_interno]
AS

	SELECT TOP 1 ( NroInterno + 1 ) as NroInterno
	FROM IvaComp
	ORDER BY NroInterno DESC

GO
/****** Object:  StoredProcedure [dbo].[PR_get_siguiente_orden_pago]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

CREATE PROCEDURE [dbo].[PR_get_siguiente_orden_pago]
AS
	DECLARE @orden_siguiente VARCHAR(6)
	
	SET @orden_siguiente = (SELECT TOP 1 p.Orden
							FROM Pagos p
							ORDER BY p.Orden desc)
	
	RETURN (convert(int, @orden_siguiente) + 1)
GO
/****** Object:  StoredProcedure [dbo].[PR_get_tipo_cambio]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[PR_get_tipo_cambio] ( @accion varchar(10), @fecha varchar(10) )
AS 
BEGIN
	declare @OrdFecha varchar(10) = dbo.FN_get_fecha_ordenable(@fecha)
	declare @ultimo varchar(10) = (SELECT MAX(ca.OrdFecha) FROM surfactanSA.dbo.Cambios ca)
	declare @primero varchar(10) = (SELECT MIN(ca.OrdFecha) FROM surfactanSA.dbo.Cambios ca)
	IF(@accion = 'primero' or @accion = 'siguiente')

			SELECT ca_2.fecha, ca_2.cambio
			FROM surfactanSA.dbo.Cambios ca_2
			WHERE ca_2.OrdFecha = (SELECT TOP 1 ca_int.OrdFecha 
									FROM surfactanSA.dbo.Cambios ca_int 
									WHERE LTRIM(RTRIM(ca_int.OrdFecha)) > CASE  
																			WHEN @accion = 'primero' or @ultimo <= @OrdFecha THEN '0'
																			ELSE @OrdFecha
																		END  
									ORDER BY ca_int.OrdFecha)

		ELSE

			SELECT ca_2.fecha, ca_2.cambio
			FROM surfactanSA.dbo.Cambios ca_2
			WHERE ca_2.OrdFecha = (SELECT TOP 1 ca_int.OrdFecha 
									FROM surfactanSA.dbo.Cambios ca_int 
									WHERE LTRIM(RTRIM(ca_int.OrdFecha)) < CASE  
																			WHEN @accion = 'ultimo' or @primero >= @OrdFecha THEN '99999999'
																			ELSE @OrdFecha
																		END  
									ORDER BY ca_int.OrdFecha DESC)

END
GO
/****** Object:  StoredProcedure [dbo].[PR_get_tipos_cambio]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[PR_get_tipos_cambio]
AS
	SELECT *
	FROM surfactanSA.dbo.Cambios

GO
/****** Object:  StoredProcedure [dbo].[PR_get_ultimo_recibo]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO


CREATE PROCEDURE [dbo].[PR_get_ultimo_recibo]
AS
	DECLARE @ultimo int	
	SET @ultimo = (SELECT TOP 1 R.Recibo
					FROM Recibos R
					ORDER BY r.Recibo desc)
	
	return (@ultimo + 1)
GO
/****** Object:  StoredProcedure [dbo].[PR_getCtaCtePrv]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

CREATE PROCEDURE [dbo].[PR_getCtaCtePrv]
	(@desde varchar(11)
	, @hasta varchar(11)
	, @tipo varchar(10))
AS
BEGIN
	
	SELECT ccp.Proveedor
		,  p.Nombre
		, ccp.Tipo
		, ccp.Letra
		, ccp.Punto
		, ccp.Numero
		, ccp.Total
		, ccp.Saldo
		, ccp.fecha
		, ccp.Vencimiento
	FROM CtaCtePrv ccp
	JOIN Proveedor p on p.Proveedor = ccp.Proveedor
	WHERE ccp.Proveedor BETWEEN @desde and @hasta
		 and ccp.Saldo <> CASE @tipo WHEN 'pendiente' THEN 0
									ELSE -999999
							END
	ORDER BY ccp.Proveedor, ccp.OrdFecha, ccp.Tipo, ccp.Numero
END
GO
/****** Object:  StoredProcedure [dbo].[PR_lee_cuenta_corriente_clave]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[PR_lee_cuenta_corriente_clave]
	@Clave Char(12)
 AS
 -- SOLO TRAJE ESTOS PORQUE SON LOS QUE FUI VIENDO QUE SE USAN EN EL PROCESO DE LOS RECIBOS
	SELECT cc.Clave 
		, cc.Tipo
		,cc.Numero
		,cc.Cliente
		,cc.fecha
		,cc.Vencimiento
		,cc.Total
		,cc.Saldo
		,cc.TotalUs
		,cc.SaldoUs
		,cc.Impre
		,cc.Neto
		,cc.Iva1
		,cc.Iva2
		,cc.Paridad
	 
		
	FROM Ctacte cc
	WHERE
		Clave = @Clave

GO
/****** Object:  StoredProcedure [dbo].[PR_Lee_IvaComp]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





--
--   ---------------------------------------------------------------------------------------------------------
--


CREATE PROCEDURE [dbo].[PR_Lee_IvaComp] (@desde_fecha varchar(8)
								, @hasta_Fecha varchar(8))
AS
BEGIN

	SELECT ic.[NroInterno]
      ,ic.[Proveedor]
      ,ic.[Tipo]
      ,ic.[Letra]
      ,ic.[Punto]
      ,ic.[Numero]
      ,ic.[Fecha]
      ,ic.[Periodo]
      ,ic.[Neto]
      ,ic.[Iva21]
      ,ic.[Iva5]
      ,ic.[Iva27]
      ,ic.[Ib]
      ,ic.[Exento]
      ,ISNULL(ic.[Iva105],0)
      ,p.Nombre
      ,p.Cuit
      ,ISNULL(ic.[soloiva],0)
      ,ISNULL(ic.[Impre],'')
  FROM [IvaComp] ic
  LEFT JOIN Proveedor p on p.Proveedor = ic.Proveedor
  WHERE dbo.FN_get_fecha_ordenable (ic.Periodo) between @desde_fecha and  @hasta_fecha
END

GO
/****** Object:  StoredProcedure [dbo].[PR_Lee_IvaCompAdicional]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO






--
--   ---------------------------------------------------------------------------------------------------------
--


CREATE PROCEDURE [dbo].[PR_Lee_IvaCompAdicional] (@nrointerno integer)
AS
BEGIN

	SELECT ic.[NroInterno]
      ,ic.[Tipo]
      ,ic.[Letra]
      ,ic.[Punto]
      ,ic.[Numero]
      ,ic.[Fecha]
      ,ic.[Neto]
      ,ic.[Iva21]
      ,ic.[perceiva]
      ,ic.[Iva27]
      ,ic.[perceIb]
      ,ic.[Exento]
      ,ISNULL(ic.[Iva105],0)
      ,ic.[Cuit]
      ,ic.[Razon]
  FROM [surfactanSA].[dbo].[IvaCompAdicional] ic
  WHERE ic.NroInterno = @nrointerno
END

GO
/****** Object:  StoredProcedure [dbo].[PR_lee_trabajo]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[PR_lee_trabajo]
	(@codigo integer)
AS
	select Trabajo.Codigo as Codigo
		 , Trabajo.Proceso as Proceso
		 , Trabajo.Destino as Destino 
		 , Trabajo.Planta as Planta
		 , Trabajo.Orden as Orden 
		 , Trabajo.Nombre as Nombre
	from surfactanSA.dbo.Trabajo Trabajo
	WHERE Trabajo.Codigo = @Codigo



GO
/****** Object:  StoredProcedure [dbo].[PR_limpiar_estaanu]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[PR_limpiar_estaanu]
AS
	DELETE 
	FROM dbo.EstaAnu
GO
/****** Object:  StoredProcedure [dbo].[PR_limpiar_grafico]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[PR_limpiar_grafico]
AS
	DELETE 
	FROM dbo.Grafico2
GO
/****** Object:  StoredProcedure [dbo].[PR_limpiar_impCtaCtePrvNet]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[PR_limpiar_impCtaCtePrvNet]
AS
	DELETE 
	FROM dbo.impCtaCtePrvNet 
GO
/****** Object:  StoredProcedure [dbo].[PR_limpiar_impcyb]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[PR_limpiar_impcyb]
AS
	DELETE 
	FROM dbo.impcyb
GO
/****** Object:  StoredProcedure [dbo].[PR_limpiar_ListaIvaComp]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[PR_limpiar_ListaIvaComp]
AS
	DELETE 
	FROM dbo.ListaIvaComp
GO
/****** Object:  StoredProcedure [dbo].[PR_limpiar_ListaIvaCompras]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



--
--   ---------------------------------------------------------------------------------------------------------
--

CREATE PROCEDURE [dbo].[PR_limpiar_ListaIvaCompras]
AS
	DELETE 
	FROM dbo.ListaIvaCompras
GO
/****** Object:  StoredProcedure [dbo].[PR_limpiar_MovBan]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PR_limpiar_MovBan]
AS
	DELETE 
	FROM dbo.Movban
GO
/****** Object:  StoredProcedure [dbo].[PR_limpiar_ranking]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[PR_limpiar_ranking]
AS
	DELETE 
	FROM dbo.Ranking
GO
/****** Object:  StoredProcedure [dbo].[PR_limpiar_Valcar]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PR_limpiar_Valcar]
AS
	DELETE 
	FROM dbo.Valcar
GO
/****** Object:  StoredProcedure [dbo].[PR_materiaprima_por_codigo_costo]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[PR_materiaprima_por_codigo_costo]
	(@Codigo varchar(10))
AS
	SELECT LTRIM(RTRIM(arti.Codigo)) as Codigo
		, arti.Costo2 as Costo
	FROM Articulo Arti 
	WHERE Codigo = @Codigo

GO
/****** Object:  StoredProcedure [dbo].[PR_modifica_estadistica_costo]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE procedure [dbo].[PR_modifica_estadistica_costo]
	@DesdeFecha VarChar(8) ,
	@HastaFecha char(8)  ,
	@Articulo char(12),
	@Costo float,
	@Titulo char(50)
AS
UPDATE
	Estadistica
SET
	Costo2 = @Costo * Estadistica.Cantidad, 
	Titulo = @Titulo
	
	WHERE Estadistica.OrdFecha between @Desdefecha and @HastaFecha
	    and  estadistica.Articulo = @Articulo

GO
/****** Object:  StoredProcedure [dbo].[PR_modifica_estadistica_costo_historico]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE procedure [dbo].[PR_modifica_estadistica_costo_historico]
	@DesdeFecha VarChar(8) ,
	@HastaFecha char(8)  ,
	@Titulo char(50)
AS
UPDATE
	Estadistica
SET
	Costo2 = Costo1 * Estadistica.Cantidad, 
	Titulo = @Titulo
	
	WHERE Estadistica.OrdFecha between @Desdefecha and @HastaFecha

GO
/****** Object:  StoredProcedure [dbo].[PR_modifica_estadistica_DescriTerminado]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE procedure [dbo].[PR_modifica_estadistica_DescriTerminado]
	@DesdeFecha VarChar(8) ,
	@HastaFecha char(8)  ,
	@Articulo char(12),
	@Descripcion char(50)
AS
UPDATE
	Estadistica
SET
	descriterminadoII = @descripcion
	
	WHERE Estadistica.OrdFecha between @Desdefecha and @HastaFecha
	    and  estadistica.Articulo = @Articulo

GO
/****** Object:  StoredProcedure [dbo].[PR_modificar_banco]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PR_modificar_banco]
	(@banco smallint,
	@nombre varchar(50),
	@cuenta varchar(10))
AS
	DECLARE @mensaje_error varchar(255)
	set @mensaje_error = ''
	BEGIN TRANSACTION
		BEGIN TRY
			UPDATE surfactanSA.dbo.Banco
			SET Nombre = @nombre
				, Cuenta = @cuenta
				, Empresa = 1
			WHERE Banco = @banco
			IF @@ERROR = 0 COMMIT TRANSACTION
		END TRY
	BEGIN CATCH	
		ROLLBACK TRANSACTION
		IF (@mensaje_error = '') 
				set @mensaje_error = @mensaje_error + 'NO SE PUDO MODIFICAR EL BANCO.'	
		RAISERROR(@mensaje_error, 16, 217)
			WITH SETERROR
	END CATCH
GO
/****** Object:  StoredProcedure [dbo].[PR_modificar_carga_intereses]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

CREATE PROCEDURE [dbo].[PR_modificar_carga_intereses]
	(@clave varchar(26)
	, @saldo float
	, @intereses float
	, @ivaIntereses float
	, @referencia varchar(10)) 
AS
BEGIN
	declare @saldo_nuevo float = @saldo + @intereses + @ivaIntereses
	declare @nro_interno int = (select NroInterno from CtaCtePrv where Clave = @clave)

	BEGIN TRAN
		UPDATE	CtaCtePrv
		SET Saldo = @saldo_nuevo
			, Interes = @intereses 
			, IvaInteres = @ivaIntereses
			, Referencia = @referencia
		WHERE Clave = @clave
		
		UPDATE IvaComp
		SET Neto = @intereses
			, Iva21 = @ivaIntereses
		WHERE NroInterno = @nro_interno
			
	COMMIT
END
GO
/****** Object:  StoredProcedure [dbo].[PR_modificar_ctacteprv_titulo]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[PR_modificar_ctacteprv_titulo]
	(@tituloI varchar(50)
	, @tituloII varchar(50)
	, @auxi1 varchar(10)
	, @auxi2 varchar(10)
	, @auxi3 varchar(8)
	, @auxi4 varchar(8)
	, @DesdeFecha char(8)
	, @HastaFecha char(8)
	, @DesdeProveedor char(11)
	, @HastaProveedor char(11))
AS
BEGIN
	BEGIN TRAN
		UPDATE	CtaCtePrv
		SET tituloI = @tituloI
		  , tituloII = @tituloII
		  , auxi1 = @auxi1
		  , auxi2 = @auxi2
		  , auxi3 = @auxi3
		  , auxi4 = @auxi4
		WHERE CtaCtePrv.OrdFecha between @DesdeFecha and @HastaFecha
		   and CtaCtePrv.Proveedor between @DesdeProveedor and @HastaProveedor
		   and (CtaCtePrv.Saldo > 1 or CtaCtePrv.Saldo < 1)
	COMMIT
END
GO
/****** Object:  StoredProcedure [dbo].[PR_modificar_cuenta]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

	
CREATE PROCEDURE [dbo].[PR_modificar_cuenta]
	(@cuenta varchar(10),
	@descripcion varchar(50),
	@nivel smallint,
	@empresa smallint)
AS
	DECLARE @mensaje_error varchar(255)
	set @mensaje_error = ''
	BEGIN TRANSACTION
		BEGIN TRY
			UPDATE surfactanSA.dbo.Cuenta
			SET Descripcion = @descripcion
				, Nivel = @nivel
				, Empresa = @empresa
			WHERE Cuenta = @cuenta
			IF @@ERROR = 0 COMMIT TRANSACTION
		END TRY
	BEGIN CATCH	
		ROLLBACK TRANSACTION
		IF (@mensaje_error = '') 
				set @mensaje_error = @mensaje_error + 'NO SE PUDO MODIFICAR LA CUENTA.'	
		RAISERROR(@mensaje_error, 16, 217)
			WITH SETERROR
	END CATCH
GO
/****** Object:  StoredProcedure [dbo].[PR_modificar_cuenta_corriente]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

CREATE PROCEDURE [dbo].[PR_modificar_cuenta_corriente]
	@Clave varchar(12),
	@Saldo float,
	@SaldoUs float,
	@WEstado varchar(8),
	@Wdate varchar(10)
 AS
	UPDATE 	CtaCte
	SET
		Saldo = @Saldo,
		SaldoUs = @SaldoUS,
		Estado = @WEstado,
		Wdate = @Wdate
	WHERE
		Clave = @Clave
GO
/****** Object:  StoredProcedure [dbo].[PR_modificar_pagos_titulo]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[PR_modificar_pagos_titulo]
	(@titulo varchar(50)
	, @tituloi varchar(50)
	, @DesdeFecha char(8)
	, @HastaFecha char(8))
AS
BEGIN
	BEGIN TRAN
		UPDATE	Pagos
		SET titulo = @titulo
		  , tituloi = @tituloi
		WHERE Pagos.FechaOrd between @DesdeFecha and @HastaFecha
	COMMIT
END
GO
/****** Object:  StoredProcedure [dbo].[PR_modificar_recibos]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

CREATE PROCEDURE [dbo].[PR_modificar_recibos] 
	(@clave char(8)
	, @estado varchar(1)
	, @destino varchar(50)
	, @tabla varchar(20))
AS
BEGIN

	declare @sql varchar(max)
		
	SET @sql = 'UPDATE '
	
	
	SET @sql = @sql + CASE @tabla WHEN 'recibos' THEN 'Recibos'
									ELSE 'RecibosProvi'
						END
	
	SET @sql = @sql + ' SET estado2 = ''' + @estado + ''' , destino = ''' + @destino + ''' WHERE clave = ''' + @clave + ''';'
	
	exec (@sql) 

END
GO
/****** Object:  StoredProcedure [dbo].[PR_modificar_recibos_marca]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE procedure [dbo].[PR_modificar_recibos_marca]
	@Recibo VarChar(6) ,
	@FechaDepo char(10)  ,
	@FechaDepoOrd char(8),
	@Marca char(1)
AS
UPDATE
	Recibos
SET
	Marca = @Marca  ,
	FechaDepo = @FechaDepo   ,
	FechaDepoOrd =  @FechaDepoOrd

WHERE
	Recibo = @Recibo
GO
/****** Object:  StoredProcedure [dbo].[PR_modificar_rubro_proveedor]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[PR_modificar_rubro_proveedor]
	(@codigo int,
	@descripcion char(50))
AS
	DECLARE @mensaje_error varchar(255)
	set @mensaje_error = ''
	BEGIN TRANSACTION
		BEGIN TRY
			UPDATE surfactanSA.dbo.TipoProv
			SET Descripcion = @descripcion
			WHERE Codigo = @codigo
			IF @@ERROR = 0 COMMIT TRANSACTION
		END TRY
	BEGIN CATCH	
		ROLLBACK TRANSACTION
		IF (@mensaje_error = '') 
				set @mensaje_error = @mensaje_error + 'NO SE PUDO MODIFICAR EL RUBRO.'	
		RAISERROR(@mensaje_error, 16, 217)
			WITH SETERROR
	END CATCH
GO
/****** Object:  StoredProcedure [dbo].[PR_modificar_saldo_impctacteprv]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[PR_modificar_saldo_impctacteprv]
	(@clave char(26)
	, @Importe float)
AS
BEGIN
	BEGIN TRAN
		UPDATE	impCtaCtePrvNet
		SET impCtaCtePrvNet.Saldo = impCtaCtePrvNet.Saldo - @importe
		WHERE impCtaCtePrvNet.clave = @clave
	COMMIT
END
GO
/****** Object:  StoredProcedure [dbo].[PR_modificar_tipo_cambio]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[PR_modificar_tipo_cambio]
	(@fecha varchar(10),
	@paridad float,
	@fecha_ord varchar(10))
AS
	DECLARE @mensaje_error varchar(255)
	set @mensaje_error = ''
	BEGIN TRANSACTION
		BEGIN TRY
			UPDATE surfactanSA.dbo.Cambios
			SET Fecha = @fecha
				, Cambio = @paridad 
			WHERE OrdFecha = @fecha_ord
			IF @@ERROR = 0 COMMIT TRANSACTION
		END TRY
	BEGIN CATCH	
		ROLLBACK TRANSACTION
		IF (@mensaje_error = '') 
				set @mensaje_error = @mensaje_error + 'NO SE PUDO MODIFICAR EL CAMBIO.'	
		RAISERROR(@mensaje_error, 16, 217)
			WITH SETERROR
	END CATCH
GO
/****** Object:  StoredProcedure [dbo].[PR_permite_actualizacion]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

CREATE PROCEDURE [dbo].[PR_permite_actualizacion]
	@recibo varchar(6)
AS
BEGIN
-- EN CASO DE QUE SE PUEDA MODIFICAR EL RECIBO PROVISORIO, RETORNA UN 1
-- EL 0 DEVUELVE SI ENCUENTRA UN CHEQUE QUE NO TENGA EL ESTADO PENDIENTE
	DECLARE @existe as int

	SET @existe = ISNULL((SELECT 0
					FROM RecibosProvi rp
					WHERE rp.Recibo = @recibo
						AND Tipo2 = '02' 
						AND Estado2 = 'X'),1)
	RETURN @existe
END	
GO
/****** Object:  StoredProcedure [dbo].[PR_procesoCiudadNuevo_ctacte]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

CREATE PROCEDURE [dbo].[PR_procesoCiudadNuevo_ctacte]
	(@desde varchar(8)
	, @hasta varchar(8))
AS
BEGIN
	
	SELECT cc.OrdFecha
		, cc.ImpoIbCiudad
		, cc.Neto
		, cc.Iva1
		, cc.Iva2
		, cc.ImpoIb
		, cc.ImpoIbTucu
		, cc.Total
		, cc.Numero
		, cc.Clave
		, cc.fecha
		, cc.Tipo
		, cc.Cliente
		, cli.Cuit	
		, cli.NroIbCiudad
		, cli.Razon
		, cli.PorceIbCaba
		, cli.IbCiudadII
	FROM CtaCte cc
	JOIN Cliente cli on cli.Cliente = cc.Cliente	
	WHERE cc.FecOrden BETWEEN @desde and @hasta
		and cc.ImpoIbCiudad <> 0
	ORDER BY cc.OrdFecha
END
GO
/****** Object:  StoredProcedure [dbo].[PR_procesoCiudadNuevo_pagos]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

CREATE PROCEDURE [dbo].[PR_procesoCiudadNuevo_pagos]
	(@desde varchar(8)
	, @hasta varchar(8))
AS
BEGIN
	
	SELECT pa.FechaOrd
		, pa.RetIbCiudad
		, pa.Renglon
		, pa.Orden
		, pa.Proveedor
		, pa.Fecha
		, pa.Importe
		, pa.Retencion
		, pa.Observaciones
		, pa.Cuenta
		, pa.TipoOrd
		, pa.TipoReg
		, pa.Tipo1
		, pa.Letra1
		, pa.Punto1
		, pa.Numero1
		, pa.Importe1
		, pa.Observaciones2
		, pa.Tipo2
		, pa.Numero2
		, pa.Fecha2
		, pa.FechaOrd2
		, pa.banco2
		, pa.Importe2
		, pa.Clave
		, pa.CertificadoIbCiudad
		, p.Nombre
		, p.Cuit
		, p.Iva
		, p.NroIb
		, p.IbCiudadII
	FROM Pagos pa
	JOIN Proveedor p on p.Proveedor = pa.Proveedor
	WHERE pa.FechaOrd BETWEEN @desde and @hasta
		 and pa.RetIbCiudad <> 0
		 and pa.Renglon = 1
END
GO
/****** Object:  StoredProcedure [dbo].[PR_procesogetcierre]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

CREATE PROCEDURE [dbo].[PR_procesogetcierre] (@mes int, @anio int)
AS
BEGIN
-- EN CASO DE SER AMBOS 0 INDICA QUE QUIERE VER TODOS LOS CIERRES
	IF (@mes = 0 AND @anio = 0)
		SELECT * FROM surfactanSA.dbo.Cierre
	ELSE
		SELECT [Mes]
			,[Ano]
			,[Estado]
		FROM surfactanSA.dbo.Cierre ci
		WHERE   ci.Ano = @anio and @mes = ci.Mes 
END
GO
/****** Object:  StoredProcedure [dbo].[PR_procesogetctacte]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

CREATE PROCEDURE [dbo].[PR_procesogetctacte] (@desde varchar(8), @hasta varchar(8))
AS
BEGIN
	SELECT 
		cu.OrdFecha
		, cu.Tipo
		, cu.Numero
		, cu.fecha
		, cu.Cliente
		, cu.Neto
		, cu.Iva1
		, cu.Iva2
		, cu.ImpoIbTucu
		, cu.ImpoIbCiudad
		, cu.ImpoIb
		, cu.Vencimiento
		, cli.Razon
		, cli.Cuit
	FROM surfactanSA.dbo.CtaCte cu
	JOIN Cliente cli on cli.Cliente = cu.Cliente
	WHERE cu.OrdFecha between @desde and @hasta
END
GO
/****** Object:  StoredProcedure [dbo].[PR_procesogetivacomp]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

CREATE PROCEDURE [dbo].[PR_procesogetivacomp] (@desde varchar(10)
								, @hasta varchar(10)
								, @letra varchar(1)
								, @tipo varchar(2))
AS
BEGIN

--REVISAR PORQUE NO FUNCIONA AL COMPARAR PERIODOS ORDENABLES

	declare @desde_fecha varchar(10) = (select dbo.[FN_get_fecha_desde_ordenable] (@desde) )
	declare @hasta_fecha varchar(10) = (select dbo.[FN_get_fecha_desde_ordenable] (@hasta) )

	SELECT ic.[NroInterno]
      ,ic.[Proveedor]
      ,ic.[Tipo]
      ,ic.[Letra]
      ,ic.[Punto]
      ,ic.[Numero]
      ,ic.[Fecha]
      ,ic.[Periodo]
      ,ic.[Neto]
      ,ic.[Iva21]
      ,ic.[Iva5]
      ,ic.[Iva27]
      ,ic.[Ib]
      ,ic.[Exento]
      ,ic.[Despacho]
      ,ic.[Iva105]
      ,p.Nombre
      ,p.Cuit
  FROM [surfactanSA].[dbo].[IvaComp] ic
  JOIN Proveedor p on p.Proveedor = ic.Proveedor
  WHERE --dbo.FN_procesogetfecha_ordenable (ic.Periodo) between @desde and  @hasta
	ic.Periodo between @desde_fecha and @hasta_fecha
  	and ic.Letra = @letra
	and ic.Tipo = @tipo
END
GO
/****** Object:  StoredProcedure [dbo].[PR_procesogetivacompadicional]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

CREATE PROCEDURE [dbo].[PR_procesogetivacompadicional] (@clave varchar(10))
AS
BEGIN
	SELECT
		ica.Clave
		, ica.Tipo
		, ica.Letra
		, ica.Punto
		, ica.Numero
		, ica.Fecha
		, ica.Neto
		, ica.Iva21
		, ica.PerceIb
		, ica.Iva27
		, ica.PerceIva
		, ica.Iva105
		, ica.Exento
		, ica.Razon
		, ica.Cuit
	FROM surfactanSA.dbo.IvaCompAdicional ica
	WHERE ica.Clave = @clave
END
GO
/****** Object:  StoredProcedure [dbo].[PR_procesoPerceIb]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

CREATE PROCEDURE [dbo].[PR_procesoPerceIb]
	(@desde varchar(8)
	, @hasta varchar(8))
AS
BEGIN
	SELECT
		cc.OrdFecha
		, cc.ImpoIb
		, cc.Clave
		, cc.fecha
		, cc.Tipo
		, cc.Numero
		, cc.Cliente
		, cc.Neto	
		, cli.Cuit
	FROM surfactanSA.dbo.CtaCte cc
	JOIN Cliente cli on cli.Cliente = cc.Cliente
	WHERE cc.OrdFecha between @desde and @hasta
		and cc.ImpoIb <> 0

END
GO
/****** Object:  StoredProcedure [dbo].[PR_procesoPerceIbTucuman]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

CREATE PROCEDURE [dbo].[PR_procesoPerceIbTucuman]
	(@desde varchar(8)
	, @hasta varchar(8))
AS
BEGIN
	
	SELECT cc.OrdFecha
		, cc.ImpoIbTucu
		, cc.Cliente
		, cc.fecha
		, cc.Tipo
		, cc.Numero
		, cc.Neto
		, cli.Cuit
		, cli.IbTucu
		, cli.PorceCm05Tucu
	FROM CtaCte cc
	JOIN Cliente cli on cli.Cliente = cc.Cliente	
	WHERE cc.FecOrden BETWEEN @desde and @hasta
		and cc.ImpoIbTucu <> 0
	
END
GO
/****** Object:  StoredProcedure [dbo].[PR_procesoPerceIva]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

CREATE PROCEDURE [dbo].[PR_procesoPerceIva]
	(@desde varchar(8)
	, @hasta varchar(8))
AS
BEGIN

	declare @periodo_desde varchar(10)
	declare @periodo_hasta varchar(10)
	SET @periodo_desde = (select dbo.[FN_get_fecha_desde_ordenable] (@desde) )
	SET @periodo_hasta = (select dbo.[FN_get_fecha_desde_ordenable] (@hasta) )
	
	SELECT 
		ic.Periodo
		, ic.Iva5
		, ic.Punto
		, ic.Numero
		, ic.Proveedor
		, ic.Fecha
		, p.Nombre
		, p.Cuit
	FROM surfactanSA.dbo.IvaComp ic
	JOIN Proveedor p on p.Proveedor = ic.Proveedor
	WHERE ic.Periodo between @periodo_desde and @periodo_hasta
		and ic.Iva5 <> 0

END
GO
/****** Object:  StoredProcedure [dbo].[PR_procesoReteGanan]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

CREATE PROCEDURE [dbo].[PR_procesoReteGanan]
	(@desde varchar(8)
	, @hasta varchar(8))
AS
BEGIN
	SELECT
		pa.FechaOrd
		, pa.Orden
		, pa.Renglon
		, pa.Importe
		, pa.Fecha
		, pa.Retencion
		, pa.Proveedor
		, pa.CertificadoGan
		, pr.Cuit
		, pr.Tipo
	FROM surfactanSA.dbo.Pagos pa
	JOIN Proveedor pr on pr.Proveedor = pa.Proveedor
	WHERE pa.FechaOrd between @desde and @hasta
		and pa.Retencion <> 0
		and pa.Renglon = 1
END
GO
/****** Object:  StoredProcedure [dbo].[PR_procesoReteGananII_imputac]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

CREATE PROCEDURE [dbo].[PR_procesoReteGananII_imputac]
	(@desde varchar(8)
	, @hasta varchar(8))
AS
BEGIN

	SELECT 
		im.FechaOrd
		, im.Cuenta
		, im.Proveedor
		, im.Fecha
		, im.NroComp
		, im.Debito
		, p.Cuit
	FROM surfactanSA.dbo.Imputac im
	JOIN Proveedor p on p.Proveedor = im.Proveedor
	WHERE im.Fechaord between @desde and @hasta
		and im.Cuenta = 144

END
GO
/****** Object:  StoredProcedure [dbo].[PR_procesoReteGananII_recibos]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

CREATE PROCEDURE [dbo].[PR_procesoReteGananII_recibos]
	(@desde varchar(8)
	, @hasta varchar(8))
AS
BEGIN

	SELECT 
		re.Fechaord
		, re.RetGanancias
		, re.Renglon
		, re.Cliente
		, re.ComproGanan
		, cli.Cuit
		, re.Fecha
	FROM surfactanSA.dbo.Recibos re
	JOIN Cliente cli on cli.Cliente = re.Cliente
	WHERE re.Fechaord between @desde and @hasta
		and re.RetGanancias <> 0
		and re.Renglon = 1

END
GO
/****** Object:  StoredProcedure [dbo].[PR_procesoReteIb]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

CREATE PROCEDURE [dbo].[PR_procesoReteIb]
	(@desde varchar(8)
	, @hasta varchar(8))
AS
BEGIN
	SELECT
		pa.FechaOrd
		, pa.RetOtra
		, pa.Renglon
		, pa.Proveedor
		, pa.Fecha
		, pa.Orden
		, pr.Cuit
	FROM surfactanSA.dbo.Pagos pa
	JOIN Proveedor pr on pr.Proveedor = pa.Proveedor
	WHERE pa.FechaOrd between @desde and @hasta
		and pa.RetOtra <> 0
		and pa.Renglon = 1
	ORDER BY pa.Orden
END
GO
/****** Object:  StoredProcedure [dbo].[PR_procesoReteIbRecibos]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

CREATE PROCEDURE [dbo].[PR_procesoReteIbRecibos]
	(@desde varchar(8)
	, @hasta varchar(8))
AS
BEGIN
	SELECT
		re.Fechaord
		, re.RetOtra
		, re.Renglon
		, re.Cliente
		, re.Fecha
		, re.ComproIb
		, cli.Cuit
	FROM surfactanSA.dbo.Recibos re
	JOIN Cliente cli on cli.Cliente = re.Cliente
	WHERE re.Fechaord between @desde and @hasta
		and re.RetOtra <> 0
		and re.Renglon = 1
END
GO
/****** Object:  StoredProcedure [dbo].[PR_procesoReteIva]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

CREATE PROCEDURE [dbo].[PR_procesoReteIva]
	(@desde varchar(8)
	, @hasta varchar(8))
AS
BEGIN
	SELECT
		re.Fechaord
		, re.RetIva
		, re.Renglon
		, re.Cliente
		, re.Fecha
		, re.ComproIva
		, cli.Cuit
	FROM surfactanSA.dbo.Recibos re
	JOIN Cliente cli on cli.Cliente = re.Cliente
	WHERE re.Fechaord between @desde and @hasta
		and re.RetIva <> 0
		and re.Renglon = 1
	ORDER BY Fechaord
END
GO
/****** Object:  StoredProcedure [dbo].[PR_procesoSiapre]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO


CREATE PROCEDURE [dbo].[PR_procesoSiapre]
	(@desde varchar(8)
	, @hasta varchar(8))
AS
BEGIN
	
	SELECT itac.FechaOrd
		, itac.Debito
		, itac.Proveedor
		, itac.Cuenta
		, ic.Despacho
		, p.Cuit
		, itac.Fecha
	FROM Imputac itac
	JOIN IvaComp ic on ic.NroInterno = itac.NroInterno
	JOIN Proveedor p on p.Proveedor = itac.Proveedor
	WHERE itac.FechaOrd BETWEEN @desde and @hasta
		 and itac.Debito <> 0
END
GO
/****** Object:  StoredProcedure [dbo].[PR_procesoSifere]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

CREATE PROCEDURE [dbo].[PR_procesoSifere]
	(@desde varchar(8)
	, @hasta varchar(8))
AS
BEGIN

	SELECT 
		im.FechaOrd
		, im.Debito
		, im.Proveedor
		, im.Cuenta
		, im.NroInterno
		, ic.Punto
		, ic.Numero
		, ic.Despacho
		, p.Cuit
		, ic.Letra
		, ic.Fecha
	FROM surfactanSA.dbo.Imputac im
	JOIN Proveedor p on p.Proveedor = im.Proveedor
	JOIN IvaComp ic on im.NroInterno = ic.NroInterno
	WHERE im.FechaOrd between @desde and @hasta
		and im.Debito <> 0

END
GO
/****** Object:  StoredProcedure [dbo].[PR_procesoSifereAduana]    Script Date: 22/06/2018 10:05:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

CREATE PROCEDURE [dbo].[PR_procesoSifereAduana]
	(@desde varchar(8)
	, @hasta varchar(8))
AS
BEGIN
	
	SELECT im.FechaOrd
		, im.Debito
		, im.Proveedor
		, im.Cuenta
		, im.NroInterno
		, ic.Punto
		, ic.Numero
		, ic.Despacho
		, p.Cuit
	FROM Imputac im
	JOIN IvaComp ic on ic.NroInterno = im.NroInterno
	JOIN Proveedor p on p.Proveedor = im.Proveedor
	WHERE im.FechaOrd BETWEEN @desde and @hasta
		and im.Debito <> 0
	
END
GO
