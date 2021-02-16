CREATE TABLE [dbo].[GameCreator](
	[ID] [int] Primary Key IDENTITY(1,1) NOT NULL,
	[Name] [nchar](30) NULL,
	[Country] [nchar](30) NULL,
	[Address] [text] NULL,
	[Owner] [nchar](30) NULL
)