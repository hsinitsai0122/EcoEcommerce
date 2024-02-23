CREATE PROCEDURE [dbo].[SP_Product_GetAll]

AS
	SELECT 
		[Id_Product],
		[Name],
		[Description],
		[Price],
		[ProCateg],
		[EcoCriteria]
	FROM [Product]
