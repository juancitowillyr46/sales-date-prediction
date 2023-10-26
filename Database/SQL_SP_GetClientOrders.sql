IF EXISTS (SELECT NAME FROM sys.objects WHERE TYPE = 'P' AND NAME = 'SP_GetClientOrders' )
BEGIN
	DROP PROCEDURE [Sales].[SP_GetClientOrders]
END
GO
CREATE PROCEDURE [Sales].[SP_GetClientOrders]
/*
	CreateBy: Juan Rodas
	CreatedAt: 2023-10-24
	Description: Get Client Orders
	Example: exec [Sales].[SP_GetClientOrders] 1
*/
@CustomerID INT
AS
BEGIN
	SELECT 
		o.[orderid] AS [orderId],
		CONVERT(varchar, o.[requireddate], 120) AS [requiredDate],
		CONVERT(varchar, o.[shippeddate], 120) AS [shippedDate],
		o.[shipname] AS [shipName],
		o.[shipaddress] AS [shipAddress],
		o.[shipcity]  AS [shipCity]
	FROM [Sales].[Orders] o WHERE [custid] = @CustomerID;
END
