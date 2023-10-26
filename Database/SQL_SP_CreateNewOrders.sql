IF EXISTS (SELECT NAME FROM sys.objects WHERE TYPE = 'P' AND NAME = 'SP_CreateNewOrder' )
BEGIN
	DROP PROCEDURE [Sales].[SP_CreateNewOrder]
END
GO
CREATE PROCEDURE [Sales].[SP_CreateNewOrder]
/*
	CreateBy: Juan Rodas
	CreatedAt: 2023-10-24
	Description: Get New Order
	Example: exec [Sales].[SP_CreateNewOrder] 1,
		1,
		'Juan Rodas',
		'Address 123',
		'Barquisimeto',
		1.5,
		'USA',
		1,
		150,
		2,
		1,
		'2023-10-25 00:00:00';
*/
		@EmployeeID INT,
		@ShipperID INT,
		@ShipName NVARCHAR(40),
		@ShipAddress NVARCHAR(60),
		@ShipCity NVARCHAR(15),
		@Freight DECIMAL(10, 2),
		@ShipCountry NVARCHAR(15),
		@ProductID INT,
		@UnitPrice DECIMAL(10, 2),
		@Qty INT,
		@Discount NUMERIC(4, 3),
		@DateAudit Datetime
AS
BEGIN
	DECLARE @datenow datetime;
	SET @datenow = @DateAudit;

    INSERT INTO Orders (
		[empid], 
		[shipperid], 
		[shipname], 
		[shipaddress], 
		[shipcity], 
		[orderdate],
		[requireddate], 
		[shippeddate],
		[freight],
		[shipcountry]
	)
    VALUES (
		@EmployeeID, 
		@ShipperID, 
		@ShipName, 
		@ShipAddress, 
		@ShipCity, 
		@DateAudit,
		@DateAudit,
		@DateAudit, 
		@Freight, 
		@ShipCountry
	);

    DECLARE @OrderID INT = SCOPE_IDENTITY();

    INSERT INTO OrderDetails (
		[orderid], 
		[productid], 
		[unitprice], 
		[qty], 
		[discount]
	)
    VALUES (
		@OrderID, 
		@ProductID, 
		@UnitPrice, 
		@Qty, 
		@Discount
	);
	SELECT 
		[orderid] AS [Orderid], 
		CONVERT(varchar, O.[requireddate], 120) AS [RequiredDate],  
		CONVERT(varchar, O.[ShippedDate], 120) AS [ShippedDate], 
		[ShipName], 
		[ShipAddress],
		[ShipCity]
	FROM [Sales].[Orders] O WHERE [orderid] = @OrderID;
END
