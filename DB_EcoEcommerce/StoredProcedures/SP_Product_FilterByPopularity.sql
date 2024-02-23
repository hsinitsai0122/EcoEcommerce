CREATE PROCEDURE [dbo].[SP_Product_FilterByPopularity]
AS
    SELECT 
        [Product].[Id_Product],
        [Name],
        [Description],
        [Price],
        [ProCateg],
        [EcoCriteria]
    FROM [Product]
    LEFT JOIN (
        SELECT 
            Id_Product, 
            SUM(ISNULL(Quantity, 0)) AS TotalQuantity
        FROM 
            OrderItem
        GROUP BY 
            Id_Product
    ) AS Subquery ON [Product].Id_Product = Subquery.Id_Product
    ORDER BY 
        ISNULL(Subquery.TotalQuantity, 0) DESC;

		
