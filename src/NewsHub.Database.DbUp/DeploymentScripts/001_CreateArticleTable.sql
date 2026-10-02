CREATE TABLE [dbo].[Article](
	[Id] [int] IDENTITY(1,1) NOT NULL,	
	[Name] [nvarchar](1024) NOT NULL,
	[Url] [nvarchar](1024) NOT NULL,
	[ImageUrl] [nvarchar](1024) null
 CONSTRAINT [PK_Instance] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)
) 