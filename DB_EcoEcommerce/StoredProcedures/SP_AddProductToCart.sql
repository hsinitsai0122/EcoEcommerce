CREATE PROCEDURE [dbo].[SP_AddProductToCart]
	@Id_Cart INT,
	@Id_Product INT,
	@Quantity INT

AS
    IF NOT EXISTS (SELECT 1 FROM Product WHERE Id_Product = @Id_Product)
        BEGIN
            RAISERROR('Product not found', 16, 1)
            RETURN
        END

    INSERT INTO [OrderItem] 
        ([Quantity], [Id_Product], [Id_Cart])
    VALUES
		(@Quantity, @Id_Product, @Id_Cart)