CREATE PROCEDURE [dbo].[SP_Product_Update]
	@id_product INT,
	@name NVARCHAR(256),
	@description NVARCHAR(MAX),
	@price DECIMAL(10,2),
	@proCateg NVARCHAR(64),
	@ecoCriteria NVARCHAR(10)
AS
	UPDATE [Product]
SET 
		[Name] = @name,
		[Description] = @description,
		[Price] = @price,
		[ProCateg] = @proCateg,
		[EcoCriteria] = @ecoCriteria
	WHERE 
		[Id_Product] = @id_product

