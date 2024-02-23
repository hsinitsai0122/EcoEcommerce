CREATE PROCEDURE [dbo].[SP_Cart_Update]
	@id_Cart INT,
	@orderNumber nvarchar(50),
	@orderDate datetime
AS
	Update [Cart]
Set
		[OrderNumber] = @orderNumber,
		[OrderDate] = @orderDate
	Where
		[Id_Cart] = @id_Cart