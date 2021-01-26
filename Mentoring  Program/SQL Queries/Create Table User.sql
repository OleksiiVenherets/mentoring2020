CREATE TABLE [dbo].[User](
	[ID] [int] Primary Key IDENTITY(1,1) NOT NULL,
	[Name] [nchar](30) NULL,
	[Surname] [nchar](30) NULL,
	[Email] [nchar](30) NULL,
	[Login] [nchar](30) NULL,
	[Password] [nchar](30) NULL,
)