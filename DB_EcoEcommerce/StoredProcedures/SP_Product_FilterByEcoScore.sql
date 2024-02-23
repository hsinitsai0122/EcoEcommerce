CREATE PROCEDURE [dbo].[SP_FilterByEcoScore]
	@ecoCriteria NVARCHAR(10)
AS
	SELECT 
			[Id_Product],
			[Name],
			[Description],
			[Price],
			[ProCateg],
			[EcoCriteria]
	
	FROM [Product]
	WHERE [EcoCriteria] = @ecoCriteria

