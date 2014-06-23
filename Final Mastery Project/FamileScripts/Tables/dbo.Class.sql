USE [MasteryProject]
GO

/****** Object:  Table [dbo].[Class]    Script Date: 6/16/2014 11:48:46 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Class](
	[ClassName] [varchar](50) NOT NULL,
	[Description] [varchar](50) NULL,
	[Subject] [varchar](50) NOT NULL,
	[StartDate] [date] NOT NULL,
	[EndDate] [date] NOT NULL,
	[IsArchived] [bit] NOT NULL,
	[TotalPointsPossible] [float] NULL,
	[ClassID] [int] IDENTITY(1,1) NOT NULL,
	[TeacherID] [int] NOT NULL,
	[GradeLevel] [tinyint] NULL,
 CONSTRAINT [PK__Class__CB1927C05B1EA49D] PRIMARY KEY CLUSTERED 
(
	[ClassID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[Class]  WITH CHECK ADD  CONSTRAINT [FK_Class_TeacherInformation] FOREIGN KEY([TeacherID])
REFERENCES [dbo].[TeacherInformation] ([TeacherID])
GO

ALTER TABLE [dbo].[Class] CHECK CONSTRAINT [FK_Class_TeacherInformation]
GO


