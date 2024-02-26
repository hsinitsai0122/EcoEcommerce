/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

INSERT INTO [Category] ([Categ])
VALUES ('Grocery'),
       ('Electronics'),
       ('Beauty');

GO

INSERT INTO [EcoScore] ([Score])
VALUES ('A'), ('B'), ('C'), ('D'), ('E');

GO

INSERT INTO [Product] ([Name], [Description], [Price], [ProCateg], [EcoCriteria])
VALUES 
    ('BJORG - Crispy Organic Cereal 3 Nuts - Whole Grain - Rich in Fiber - Bag of 450g', '3 NUT CRUSTILLANT BJORG CEREALS: Ideal for a good start to your day, the Crispy BJORG 3 Nuts cereal combines oatmeal, wheat, almonds, hazelnuts and cashews for a gourmet breakfast.', 4.85, 'Grocery', 'B'),
    ('Hermitlux Mini tabletop dishwasher, can be used with and without water connection, width 43 cm, space for 4 cutlery, suitable for camping, 175 kWh/year, white', '4 Cutlery Set Capacity. The table dishwasher can hold four cutlery sets, size 42.5 x 43 x 45.7 cm. It can accommodate plates up to 25cm long stacked at any angle. Even in kitchens with limited space, there is a suitable place for a small dishwasher.', 269.00, 'Electronics', 'A'),
    ('Garnier SkinActive Anti-Stain Serum - Face Care Enriched with Vitamin C, Salicylic Acid and Niacinamide - for All Skin Types - 30 ml', 'Highly concentrated stain remover serum (3.5%) in powerful active ingredients known to visibly reduce dark spots and acne scars. Results: In 3 days, the skin is unified and smoother. As soon as 6 days, dark spots are visibly reduced, -43% of dark spots in 56 days. Application: Apply 1 pipette morning and evening to clean face, penetrate into the skin, then apply your day cream or night cream. Formula enriched with Vitamin C, Niacinamide and Salicylic Acid. No ingredients or derivatives of animal origin. Not tested on animals. Dermatologically tested. Contents: 1 x Garnier SkinActive Vitamin C Anti-Stain Serum, Capacity: 30 ml', 10.45, 'Beauty', 'D'),
    ('O3 Pure Professional Eco Laundry Washer System', '10 minute installation by homeowner without any special tools. Requires no maintenance or additives. Only activates when the washer is in use, plugs into a standard outlet and uses less than 45 watts of electricity. The unit also only runs when the washer is filling or rinsing. The customer is supplied with a template, mounting hardware, phillips screwdriver, and an additional hose connector.', 297.00, 'Electronics', 'B'),
    ('Philips Sonicare ExpertClean 7500, Rechargeable Electric Power Toothbrush, Black', 'Includes: 1 Philips Sonicare handle, 1 charging travel case, 1 charger, 1 Premium Plaque Control brush head, 1 Premium Gum Health brush head', 199.99, 'Grocery', 'A'),
    ('siggi Icelandic Strained Nonfat Yogurt', 'Peach, Single Serve Cup Thick, Protein-Rich Yogurt Snack', 51.86, 'Grocery', 'A');
GO

INSERT INTO [Media] ([ImgUrl], [Id_Product])
VALUES 
    ('CerealBjorg1.jpg', 1),
    ('CerealBjorg2.jpg', 1),
    ('dishwasherHermitlux1.jpg', 2),
    ('dishwasherHermitlux2.jpg', 2),
    ('serumGarnier1.jpg', 3),
    ('serumGarnier2.jpg', 3),
    ('O3Laundry1.jpg', 4),
    ('O3Laundry2.jpg', 4),
    ('PhilipsSonicare1.jpg', 5),
    ('PhilipsSonicare2.jpg', 5),
    ('SigiYogurt1.jpg', 6),
    ('SigiYogurt2.jpg', 6);

GO

INSERT INTO [Cart] ([OrderNumber], [OrderDate])
VALUES 
    ('ORD000001', GETDATE()), 
    ('ORD000002', GETDATE()),
    ('ORD000003', GETDATE());
GO

INSERT INTO [OrderItem] ([Quantity], [Id_Product], [Id_Cart])
VALUES 
    (1, 1, 1),  
    (1, 2, 2), 
    (2, 3, 2),
    (3, 4, 2),
    (2, 5, 3),
    (3, 6, 3);
GO
