USE [MasteryProject]
GO

/****** Object:  Table [dbo].[GradeBookEntry]    Script Date: 6/16/2014 10:45:47 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[GradeBookEntry](
	[EntryType] [varchar](10) NULL,
	[EntryName] [varchar](50) NULL,
	[AssignedDate] [date] NOT NULL,
	[DueDate] [date] NOT NULL,
	[PossiblePoints] [int] NULL,
	[Description] [varchar](300) NULL,
	[EntryID] [int] IDENTITY(1,1) NOT NULL,
	[GradeBookEntryTypeID] [int] NULL,
	[ClassID] [int] NOT NULL,
 CONSTRAINT [PK__GradeBoo__F57BD2F72FE74294] PRIMARY KEY CLUSTERED 
(
	[EntryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[GradeBookEntry]  WITH CHECK ADD  CONSTRAINT [FK_GradeBookEntry_Class] FOREIGN KEY([ClassID])
REFERENCES [dbo].[Class] ([ClassID])
GO

ALTER TABLE [dbo].[GradeBookEntry] CHECK CONSTRAINT [FK_GradeBookEntry_Class]
GO

ALTER TABLE [dbo].[GradeBookEntry]  WITH CHECK ADD  CONSTRAINT [FK_GradeBookEntry_GradeBookEntryType] FOREIGN KEY([GradeBookEntryTypeID])
REFERENCES [dbo].[GradeBookEntryType] ([GradeBookEntryTypeID])
GO

ALTER TABLE [dbo].[GradeBookEntry] CHECK CONSTRAINT [FK_GradeBookEntry_GradeBookEntryType]
GO


