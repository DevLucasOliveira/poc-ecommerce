CREATE PROCEDURE spListCustomerQueryResult
AS
	SELECT 
		[Id], 
		CONCAT([FirstName], ' ', [LastName]) AS [Name],
		[Document],
		[Email]
	FROM
		[Customer]