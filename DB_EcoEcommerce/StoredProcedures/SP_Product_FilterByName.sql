CREATE PROCEDURE [dbo].[SP_FilterByName]
	@name NVARCHAR(256)
AS
	SELECT 
			[Id_Product],
			[Name],
			[Description],
			[Price],
			[ProCateg],
			[EcoCriteria]
		FROM [Product]
		WHERE [Name] LIKE '%' + @name + '%'

