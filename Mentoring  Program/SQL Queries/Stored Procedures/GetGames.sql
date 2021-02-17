USE Mentoring;
GO
CREATE PROCEDURE GetGames AS
BEGIN
	Select Game.ID, Game.Name, Description, SystemRequirenments, Genres, InterfaceLanguages, FullSupportLanguage, ReleaseDate, IsFreeToPLay, Price, GameCreator.Name as 'CreatorName', GamePublisher.Name as 'PublisherName' 
	FROM Game 
		INNER JOIN GameCreator ON(Game.DeveloperID = GameCreator.ID) 
		INNER JOIN GamePublisher ON(Game.PublisherID = GamePublisher.ID)
END;