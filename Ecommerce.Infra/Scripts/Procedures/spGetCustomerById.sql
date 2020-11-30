CREATE PROCEDURE spGetCustomerById
	@Id UNIQUEIDENTIFIER
AS
	SELECT
		[Id], 
		CONCAT([FirstName], ' ', [LastName]) AS [Name],
		[Document],
		[Email]
	FROM
		[Customer]
	wHERE [Id] = @Id
