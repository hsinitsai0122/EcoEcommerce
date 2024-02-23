CREATE PROCEDURE [dbo].[SP_FilterByCateg]
	@proCateg NVARCHAR(64)
AS
	SELECT 
			[Id_Product],
			[Name],
			[Description],
			[Price],
			[ProCateg],
			[EcoCriteria]
	
	FROM [Product]
	WHERE [ProCateg] = @proCateg

