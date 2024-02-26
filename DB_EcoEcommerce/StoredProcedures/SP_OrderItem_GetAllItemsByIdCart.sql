CREATE PROCEDURE [dbo].[SP_OrderItem_GetAllItemsByIdCart]
	@id_Cart int
AS
	SELECT 
	[OrderItem].[Id_OrderItem],
	[OrderItem].[Id_Product],
	[OrderItem].[Quantity],
	[OrderItem].[Id_Cart]
FROM [OrderItem]
WHERE [OrderItem].[Id_Cart] = @id_Cart

