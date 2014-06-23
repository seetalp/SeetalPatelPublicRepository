USE [MasteryProject]
GO

/****** Object:  Table [dbo].[StudentClass]    Script Date: 6/16/2014 10:50:05 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[StudentClass](
	[LetterGrade] [varchar](3) NULL,
	[PercentGrade] [float] NULL,
	[TotalPointsScored] [float] NULL,
	[StudentID] [int] NOT NULL,
	[ClassID] [int] NOT NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_StudentClass] PRIMARY KEY CLUSTERED 
(
	[StudentID] ASC,
	[ClassID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[StudentClass] ADD  DEFAULT ((0)) FOR [IsDeleted]
GO

ALTER TABLE [dbo].[StudentClass]  WITH CHECK ADD  CONSTRAINT [FK_StudentClass_Class] FOREIGN KEY([ClassID])
REFERENCES [dbo].[Class] ([ClassID])
GO

ALTER TABLE [dbo].[StudentClass] CHECK CONSTRAINT [FK_StudentClass_Class]
GO

ALTER TABLE [dbo].[StudentClass]  WITH CHECK ADD  CONSTRAINT [FK_StudentClass_StudentInformation] FOREIGN KEY([StudentID])
REFERENCES [dbo].[StudentInformation] ([StudentID])
GO

ALTER TABLE [dbo].[StudentClass] CHECK CONSTRAINT [FK_StudentClass_StudentInformation]
GO


