USE [MasteryProject]
GO

/****** Object:  StoredProcedure [dbo].[GetStudentByParentID]    Script Date: 6/17/2014 2:35:06 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetStudentByParentID] (

@UserID varchar(128)

) AS
SELECT p.StudentID, aa.FirstName, aa.LastName, aa.Id as UserID
FROM AspNetUsers a
	JOIN ParentInformation i ON i.UserID = a.Id
	JOIN StudentParent p ON i.ParentID = p.ParentID
	JOIN StudentInformation s ON s.StudentID = p.StudentID
	JOIN AspNetUsers aa ON aa.Id = s.UserID
WHERE a.Id = @UserID 
GO


