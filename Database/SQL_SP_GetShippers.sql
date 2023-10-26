IF EXISTS (SELECT NAME FROM sys.objects WHERE TYPE = 'P' AND NAME = 'SP_GetShippers' )
BEGIN
	DROP PROCEDURE [Sales].[SP_GetShippers]
END
GO
CREATE PROCEDURE [Sales].[SP_GetShippers]
/*
    CreatedBy: Juan Rodas
    CreatedAt: 2023-10-24
    Description: Get Shippers
    Example: exec [Sales].[SP_GetShippers]
*/
AS
BEGIN
    SELECT 
        s.[shipperid] AS [shipperId],
        s.[companyname] AS [companyName]
    FROM [Sales].[Shippers] s;
END
