USE [MasteryProject]
GO

/****** Object:  Table [dbo].[TeacherClass]    Script Date: 6/16/2014 10:56:20 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TeacherClass](
	[TeacherID] [int] NOT NULL,
	[ClassID] [int] NOT NULL,
 CONSTRAINT [PK_TeacherClass] PRIMARY KEY CLUSTERED 
(
	[TeacherID] ASC,
	[ClassID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[TeacherClass]  WITH CHECK ADD  CONSTRAINT [FK_TeacherClass_Class] FOREIGN KEY([ClassID])
REFERENCES [dbo].[Class] ([ClassID])
GO

ALTER TABLE [dbo].[TeacherClass] CHECK CONSTRAINT [FK_TeacherClass_Class]
GO

ALTER TABLE [dbo].[TeacherClass]  WITH CHECK ADD  CONSTRAINT [FK_TeacherClass_TeacherInformation] FOREIGN KEY([TeacherID])
REFERENCES [dbo].[TeacherInformation] ([TeacherID])
GO

ALTER TABLE [dbo].[TeacherClass] CHECK CONSTRAINT [FK_TeacherClass_TeacherInformation]
GO


