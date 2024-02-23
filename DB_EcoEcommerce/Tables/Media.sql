CREATE TABLE [dbo].[Media]
(
	[Id_Media] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ImgUrl] NVARCHAR(256) NOT NULL, 
    [Id_Product] INT NOT NULL, 
    CONSTRAINT [FK_Media_Product] FOREIGN KEY ([Id_Product]) REFERENCES [Product]([Id_Product])
)
