CREATE PROCEDURE [dbo].[SP_Media_Insert]
	@imgUrl NVARCHAR(256),
	@id_Product INT

AS
	INSERT INTO 
		[Media] (
			[ImgUrl], 
			[Id_Product])
		OUTPUT [INSERTED].[Id_Media]
	VALUES (
		@imgUrl, 
		@id_Product)
	
