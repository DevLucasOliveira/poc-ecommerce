CREATE PROCEDURE spGetCustomerOrdersCount
	@Document CHAR(11)
AS
					--Ajustar proc
	SELECT c.[Id],
	CONCAT(c.[FirstName], ' ', c.[LastName]) AS [Name],
	c.[Document]
	FROM 
		[Customer] c 
		INNER JOIN [Order] o 
		On o.[CustomerId] = c.Id
