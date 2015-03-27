USE [MasteryProject]
GO
/****** Object:  StoredProcedure [dbo].[GetClassInfoById]    Script Date: 6/18/2014 2:44:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetClassInfoById] 
(
	@ClassID int
) AS

SELECT c.ClassID,c.ClassName,c.[Subject],c.StartDate,c.EndDate,c.IsArchived,c.[Description], c.GradeLevel
FROM Class AS c
	WHERE c.ClassID = @ClassID

