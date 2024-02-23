CREATE PROCEDURE [dbo].[SP_Product_Delete]
	@id_product int
AS

	DELETE FROM [Product]
	WHERE
		[Id_Product] = @id_product
