USE [MasteryProject]
GO

/****** Object:  Table [dbo].[StudentInformation]    Script Date: 6/16/2014 10:55:20 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[StudentInformation](
	[StudentID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [nvarchar](128) NOT NULL,
	[GradeLevel] [int] NOT NULL,
	[GPA] [varchar](5) NULL,
 CONSTRAINT [PK__StudentI__32C52A79050503D0] PRIMARY KEY CLUSTERED 
(
	[StudentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[StudentInformation]  WITH CHECK ADD  CONSTRAINT [FK_StudentInformation_AspNetUsers] FOREIGN KEY([UserID])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO

ALTER TABLE [dbo].[StudentInformation] CHECK CONSTRAINT [FK_StudentInformation_AspNetUsers]
GO


