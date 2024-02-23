CREATE PROCEDURE [dbo].[SP_Cart_GetAll]

AS
	SELECT 
		[Cart].[Id_Cart],
		[OrderItem].[Id_OrderItem],
		[OrderItem].[Quantity],
		[Product].[Id_Product],
		[Product].[Name],
		[Product].[Description],
		[Product].[Price],
		[Product].[ProCateg],
		[Product].[EcoCriteria]
	FROM [Cart]
	INNER JOIN [OrderItem] ON [Cart].[Id_Cart] = [OrderItem].[Id_Cart]
	INNER JOIN [Product] ON [OrderItem].[Id_Product] = [Product].[Id_Product]



