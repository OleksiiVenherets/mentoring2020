USE Mentoring;
GO
CREATE PROCEDURE UpdateGame 
	@GameID int,
	@Description text,
	@Name text,
	@SystemRequirenments text,
	@Genres text,
	@InterfaceLanguages text,
	@FullSupportLanguage text,
	@ReleaseDate text,
	@IsFreeToPlay bit,
	@Price money
AS
BEGIN
	UPDATE Game 
	SET Name = @Name, 
		Description = @Description, 
		SystemRequirenments = @SystemRequirenments, 
		Genres = @Genres, 
		InterfaceLanguages = @InterfaceLanguages, 
		FullSupportLanguage = @FullSupportLanguage, 
		ReleaseDate = @ReleaseDate, IsFreeToPlay = @IsFreeToPlay, 
		Price = @Price 
	WHERE ID = @GameID
END;