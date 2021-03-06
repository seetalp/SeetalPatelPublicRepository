USE [MasteryProject]
GO

/****** Object:  Table [dbo].[GradeBookEntryType]    Script Date: 6/16/2014 10:48:48 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[GradeBookEntryType](
	[GradeBookEntryTypeID] [int] NOT NULL,
	[EntryType] [varchar](50) NULL,
 CONSTRAINT [PK_GradeBookEntryType] PRIMARY KEY CLUSTERED 
(
	[GradeBookEntryTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


