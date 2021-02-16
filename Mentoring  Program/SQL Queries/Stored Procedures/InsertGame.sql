USE Mentoring;
GO
CREATE PROCEDURE InsertGame 
	@GameID int,
	@Description text,
	@Name text,
	@SystemRequirenments text,
	@Genres text,
	@InterfaceLanguages text,
	@FullSupportLanguage text,
	@ReleaseDate text,
	@IsFreeToPlay bit,
	@Price money,
	@Developer nchar(30),
	@Publisher nchar(30)

AS
BEGIN
	DECLARE @DeveloperID INT;
	DECLARE @PublisherID INT;
	
	IF EXISTS (SELECT ID FROM GameCreator WHERE GameCreator.Name = @Developer)
		BEGIN
			SET @DeveloperID = (SELECT ID FROM GameCreator WHERE GameCreator.Name = @Developer);
		END
	ELSE
		BEGIN
			SET @DeveloperID = 0;
		END
	
	IF EXISTS (SELECT ID FROM GamePublisher WHERE GamePublisher.Name = @Publisher)
		BEGIN
			SET @PublisherID = (SELECT ID FROM GamePublisher WHERE GamePublisher.Name = @Publisher);
		END
	ELSE
		BEGIN
			SET @DeveloperID = 0;
		END	

	IF @DeveloperID <> 0 AND @DeveloperID <> 0
		BEGIN
			INSERT INTO 
			Game (Name, Description, SystemRequirenments, Genres, InterfaceLanguages, FullSupportLanguage, ReleaseDate, IsFreeToPLay, Price, DeveloperID, PublisherID) 
			VALUES (@Name, @Description, @SystemRequirenments, @Genres, @InterfaceLanguages, @FullSupportLanguage, @ReleaseDate, @IsFreeToPLay, @Price, @DeveloperID, @PublisherID)
		END
END;