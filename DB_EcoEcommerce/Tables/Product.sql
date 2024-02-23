CREATE TABLE [dbo].[Product]
(
	[Id_Product] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(256) NOT NULL, 
    [Description] NVARCHAR(MAX) NOT NULL, 
    [Price] DECIMAL(10, 2) NOT NULL, 
    [ProCateg] NVARCHAR(64) NOT NULL, 
    [EcoCriteria] NVARCHAR(10) NOT NULL, 
    CONSTRAINT [FK_Product_Category] FOREIGN KEY ([ProCateg]) REFERENCES [Category]([Categ]), 
    CONSTRAINT [FK_Product_EcoScore] FOREIGN KEY ([EcoCriteria]) REFERENCES [EcoScore]([Score])
)
