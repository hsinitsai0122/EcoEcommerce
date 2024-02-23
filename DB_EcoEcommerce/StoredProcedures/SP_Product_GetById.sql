CREATE PROCEDURE [dbo].[SP_Product_GetById]
	@id_product INT
AS
	SELECT 
		[Id_Product],
		[Name],
		[Description],
		[Price],
		[ProCateg],
		[EcoCriteria]

	FROM [Product]

WHERE 
	[Id_Product] = @id_product
