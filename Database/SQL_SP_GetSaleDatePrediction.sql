IF EXISTS (SELECT NAME FROM sys.objects WHERE TYPE = 'P' AND NAME = 'SP_GetSaleDatePrediction' )
BEGIN
	DROP PROCEDURE [Sales].[SP_GetSaleDatePrediction]
END
GO
CREATE PROCEDURE [Sales].[SP_GetSaleDatePrediction]
/*
	CreateBy: Juan Rodas
	CreatedAt: 2023-10-24
	Description: Get Client Orders
	Example: exec [Sales].[SP_GetSaleDatePrediction]
*/
AS
BEGIN
	SELECT
		c.[custid] AS [Id],
		c.[companyname] AS [CustomerName],
		CONVERT(varchar, MAX(o.[orderdate]), 120) AS [LastOrderDate],
		CONVERT(varchar, DATEADD(
			DAY,
			AVG([days_between_orders]),
			MAX(o.[orderdate])
		), 120)
		AS [NextPredictedOrder]
	FROM [Sales].[Customers] AS c
	JOIN [Sales].[Orders] AS o ON c.[custid] = o.[custid]
	JOIN (
		SELECT 
			Sso.[custid],
			Sso.[orderdate],
			DATEDIFF(
				DAY,
				LAG(Sso.[orderdate]) OVER (PARTITION BY Sso.[custid] ORDER BY Sso.[orderdate]),
				Sso.[orderdate]
			) AS [days_between_orders]
		FROM [Sales].[Orders] Sso 
		WHERE 
			Sso.[orderdate] <= (
								SELECT 
									MAX(orderdate) 
								FROM [Sales].[Orders] Ssso 
								WHERE 
									Ssso.custid = Sso.[custid]
								)
	) AS squery ON c.[custid] = squery.[custid]
	GROUP BY c.[custid], c.[companyname];
END


