CREATE TABLE [dbo].[OrderItem]
(
	[Id_OrderItem] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Quantity] INT NOT NULL, 
    [Id_Product] INT NOT NULL, 
    [Id_Cart] INT NOT NULL, 
    CONSTRAINT [FK_OrderItem_Product] FOREIGN KEY ([Id_Product]) REFERENCES [Product]([Id_Product]), 
    CONSTRAINT [FK_OrderItem_Cart] FOREIGN KEY ([Id_Cart]) REFERENCES [Cart]([Id_Cart])
)
