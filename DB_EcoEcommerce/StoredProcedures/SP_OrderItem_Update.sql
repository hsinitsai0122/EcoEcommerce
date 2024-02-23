CREATE PROCEDURE [dbo].[SP_OrderItem_Update]
	@id_OrderItem INT,
	@quantity INT,
	@id_Product INT,
	@id_Cart INT
AS

	Update [OrderItem]
Set
		[Quantity] = @quantity,
		[Id_Product] = @id_Product,
		[Id_Cart] = @id_Cart
	Where
		[Id_OrderItem] = @id_OrderItem
