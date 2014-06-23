USE [MasteryProject]
GO

/****** Object:  Table [dbo].[StudentParent]    Script Date: 6/16/2014 10:55:54 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[StudentParent](
	[StudentID] [int] NOT NULL,
	[ParentID] [int] NOT NULL,
 CONSTRAINT [PK_StudentParent] PRIMARY KEY CLUSTERED 
(
	[StudentID] ASC,
	[ParentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[StudentParent]  WITH CHECK ADD  CONSTRAINT [FK_StudentParent_ParentInformation1] FOREIGN KEY([ParentID])
REFERENCES [dbo].[ParentInformation] ([ParentID])
GO

ALTER TABLE [dbo].[StudentParent] CHECK CONSTRAINT [FK_StudentParent_ParentInformation1]
GO

ALTER TABLE [dbo].[StudentParent]  WITH CHECK ADD  CONSTRAINT [FK_StudentParent_StudentInformation] FOREIGN KEY([StudentID])
REFERENCES [dbo].[StudentInformation] ([StudentID])
GO

ALTER TABLE [dbo].[StudentParent] CHECK CONSTRAINT [FK_StudentParent_StudentInformation]
GO


