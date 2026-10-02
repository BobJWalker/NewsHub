CREATE TABLE [dbo].[FeedLoad](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FeedUrl] [nvarchar](1024) NOT NULL,
	[State] [nvarchar](256) NOT NULL,	
	[Created] [datetime2](7) NOT NULL,
	[Started] [datetime2](7) NULL,
	[Completed] [datetime2](7) NULL,	
	[RetryAttempts] [int] NULL,
 CONSTRAINT [PK_Sync] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)
)
GO