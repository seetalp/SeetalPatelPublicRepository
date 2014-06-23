USE [MasteryProject]
GO

/****** Object:  Table [dbo].[StudentGradeBookEntry]    Script Date: 6/16/2014 10:54:46 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[StudentGradeBookEntry](
	[PercentGrade] [float] NULL,
	[LetterGrade] [varchar](3) NULL,
	[PointsScored] [int] NULL,
	[Description] [varchar](300) NULL,
	[StudentID] [int] NOT NULL,
	[EntryID] [int] NOT NULL,
 CONSTRAINT [PK_StudentGradeBookEntry] PRIMARY KEY CLUSTERED 
(
	[StudentID] ASC,
	[EntryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[StudentGradeBookEntry]  WITH CHECK ADD  CONSTRAINT [FK_StudentGradeBookEntry_GradeBookEntry] FOREIGN KEY([EntryID])
REFERENCES [dbo].[GradeBookEntry] ([EntryID])
GO

ALTER TABLE [dbo].[StudentGradeBookEntry] CHECK CONSTRAINT [FK_StudentGradeBookEntry_GradeBookEntry]
GO

ALTER TABLE [dbo].[StudentGradeBookEntry]  WITH CHECK ADD  CONSTRAINT [FK_StudentGradeBookEntry_StudentInformation] FOREIGN KEY([StudentID])
REFERENCES [dbo].[StudentInformation] ([StudentID])
GO

ALTER TABLE [dbo].[StudentGradeBookEntry] CHECK CONSTRAINT [FK_StudentGradeBookEntry_StudentInformation]
GO


