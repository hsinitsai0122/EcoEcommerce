CREATE PROCEDURE [dbo].[SP_Product_Insert]
	@name NVARCHAR(256),
	@description NVARCHAR(MAX),
	@price DECIMAL(10,2),
	@proCateg NVARCHAR(64),
	@ecoCriteria NVARCHAR(10)
AS
	INSERT INTO [Product] ([Name], [Description], [Price], [ProCateg], [EcoCriteria])
	OUTPUT [INSERTED].[Id_Product]

	VALUES (@name, @description, @price, @proCateg, @ecoCriteria)

