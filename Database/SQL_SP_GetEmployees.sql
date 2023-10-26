IF EXISTS (SELECT NAME FROM sys.objects WHERE TYPE = 'P' AND NAME = 'SP_GetEmployees' )
BEGIN
	DROP PROCEDURE [HR].[SP_GetEmployees]
END
GO
CREATE PROCEDURE [HR].[SP_GetEmployees]
/*
	CreateBy: Juan Rodas	
	CreatedAt: 2023-10-24
	Description: Get employees
	Example: exec [HR].[SP_GetEmployees]
*/
AS
BEGIN
	SELECT 
		e.[empid] AS [empId],
		e.[firstname] AS [firstName],
		CONCAT(
				e.[firstname], ' ', 
				e.[lastname]
		) AS [fullName]
	FROM [HR].[Employees] e;
END
