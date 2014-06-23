USE [MasteryProject]
GO

/****** Object:  Table [dbo].[TeacherInformation]    Script Date: 6/16/2014 10:56:43 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TeacherInformation](
	[TeacherID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK__TeacherI__EDF259449AAC4807] PRIMARY KEY CLUSTERED 
(
	[TeacherID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[TeacherInformation]  WITH CHECK ADD  CONSTRAINT [FK_TeacherInformation_AspNetUsers] FOREIGN KEY([UserID])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO

ALTER TABLE [dbo].[TeacherInformation] CHECK CONSTRAINT [FK_TeacherInformation_AspNetUsers]
GO


