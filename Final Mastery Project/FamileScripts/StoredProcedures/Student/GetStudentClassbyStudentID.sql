USE [MasteryProject]
GO
/****** Object:  StoredProcedure [dbo].[GetStudentClassbyStudentID]    Script Date: 6/18/2014 1:47:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


---Student Dashboard SPROC

CREATE PROCEDURE [dbo].[GetStudentClassbyStudentID] (

@UserID varchar(128)
) AS
SELECT ClassName, LetterGrade, s.ClassID
FROM StudentClass s
INNER JOIN Class c ON s.ClassID = c.ClassID
INNER JOIN StudentInformation i ON i.StudentID = s.StudentID
WHERE i.UserID =@UserID AND s.IsDeleted=0
