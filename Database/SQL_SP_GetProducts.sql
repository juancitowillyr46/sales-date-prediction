IF EXISTS (SELECT NAME FROM sys.objects WHERE TYPE = 'P' AND NAME = 'SP_GetProducts' )
BEGIN
	DROP PROCEDURE [Sales].[SP_GetProducts]
END
GO
CREATE PROCEDURE [Sales].[SP_GetProducts]
/*
	CreateBy: Juan Rodas
	CreatedAt: 2023-10-24
	Description: Get Products
	Example: exec [Sales].[SP_GetProducts]
*/
AS
BEGIN
	SELECT 
		p.[productid] AS [productId],
		p.[productname] AS [productName]
	FROM [Production].[Products] p;
END
