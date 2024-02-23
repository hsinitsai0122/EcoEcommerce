CREATE PROCEDURE [dbo].[SP_Cart_Insert]
	@orderNumber nvarchar(50),
	@orderDate datetime
AS
	INSERT INTO
		[Cart] (
			[OrderNumber], 
			[OrderDate])
		OUTPUT [INSERTED].[Id_Cart]
	VALUES (
		@orderNumber, 
		@orderDate)