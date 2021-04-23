CREATE TABLE [dbo].[Post] (
  [Id] [int] IDENTITY,
  [Title] [nvarchar](max) NULL,
  [Content] [nvarchar](max) NULL,
  [Image] [nvarchar](max) NULL,
  [Category] [nvarchar](max) NULL,
  [CreationDate] [datetime2] NOT NULL,
  CONSTRAINT [PK_Post] PRIMARY KEY CLUSTERED ([Id])
)
ON [PRIMARY]
TEXTIMAGE_ON [PRIMARY]
GO