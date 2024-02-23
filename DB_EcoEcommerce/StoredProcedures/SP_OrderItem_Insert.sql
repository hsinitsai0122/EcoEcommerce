CREATE PROCEDURE [dbo].[SP_OrderItem_Insert]
	@quantity INT,
	@id_Product INT,
	@id_Cart INT
AS
	INSERT INTO
		[OrderItem] (
			[Quantity], 
			[Id_Product], 
			[Id_Cart])
		OUTPUT [INSERTED].[Id_OrderItem]
	VALUES (
		@quantity, 
		@id_Product, 
		@id_Cart)
