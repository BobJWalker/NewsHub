CREATE TABLE [dbo].[FeedLoadLog](
	[Id] [long] IDENTITY(1,1) NOT NULL,
	[FeedLoadId] [int] NOT NULL,
	[Created] [datetime2](7) NOT NULL,
	[Type] [nvarchar](256) NOT NULL,
	[Message] [nvarchar](2048) NOT NULL,
 CONSTRAINT [PK_FeedLoadLog] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)
)
GO

ALTER TABLE [dbo].[FeedLoadLog]  WITH CHECK ADD  CONSTRAINT [FK_FeadLoadLog_Sync] FOREIGN KEY([FeedLoadId])
REFERENCES [dbo].[FeedLoad] ([Id])
GO

ALTER TABLE [dbo].[FeedLoadLog] CHECK CONSTRAINT [FK_FeadLoadLog_Sync]
GO