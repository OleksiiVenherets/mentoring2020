CREATE TABLE [dbo].[Game](
	[ID] [int] Primary Key IDENTITY(1,1) NOT NULL,
	[Name] [nchar](30) NULL,
	[Description] [text] NULL,
	[SystemRequirenments] [text] NULL,
	[Genres] [text] NULL,
	[InterfaceLanguages] [text] NULL,
	[FullSupportLanguage] [text] NULL,
	[ReleaseDate] [text] NULL,
	[IsFreeToPlay] [bit] NULL,
	[Price] [money] NULL,
	[DeveloperID] [int] NULL,
	[PublisherID] [int] NULL,
	FOREIGN KEY ([DeveloperID]) REFERENCES GameCreator(ID) ON DELETE NO ACTION,
	FOREIGN KEY ([PublisherID]) REFERENCES GamePublisher(ID) ON DELETE NO ACTION
)