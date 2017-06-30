/*
---------------------------------------------------------------
---------------------------FUNCIONES---------------------------
---------------------------------------------------------------
*/

USE [surfactanSA]
GO


IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FN_get_fecha_ordenable]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[FN_get_fecha_ordenable]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FN_get_fecha_desde_ordenable]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[FN_get_fecha_desde_ordenable]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FN_verificar_fecha_ordenable]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[FN_verificar_fecha_ordenable]
GO

USE [surfactanSA]
GO


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

CREATE FUNCTION [dbo].[FN_get_fecha_desde_ordenable](@fecha varchar(10))
RETURNS varchar(10)
AS
BEGIN
	
	declare @fecha_retorno varchar(10) 
	SET @fecha_retorno = RIGHT(@fecha,2)+ '/' + RIGHT((LEFT(@fecha,6)),2) + '/' + LEFT(@fecha,4) 
	
	RETURN @fecha_retorno
END

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

/*
---------------------------------------------------------------
-------------------------PROCEDIMIENTOS-------------------------
---------------------------------------------------------------
*/

USE [surfactanSA]
GO


IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PR_get_provincias]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[PR_get_provincias]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PR_baja_imputaciones]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[PR_baja_imputaciones]
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