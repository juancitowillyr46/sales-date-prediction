SELECT
	c.[companyname] AS [CustomerName],
    MAX(o.[orderdate]) AS [LastOrderDate],
    DATEADD(
        DAY,
        AVG([days_between_orders]),
        MAX(o.[orderdate])
    )
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
GROUP BY c.[companyname];