CREATE PROCEDURE [dbo].[SP_Media_Update]
	@id_Media INT,
	@imgUrl NVARCHAR(256),
	@id_Product INT
AS
	Update [Media]
Set
		[ImgUrl] = @imgUrl,
		[Id_Product] = @id_Product
	Where
		[Id_Media] = @id_Media
