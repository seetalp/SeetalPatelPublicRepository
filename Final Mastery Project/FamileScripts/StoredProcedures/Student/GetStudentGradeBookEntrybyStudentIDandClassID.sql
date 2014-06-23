USE [MasteryProject]
GO

/****** Object:  StoredProcedure [dbo].[GetStudentGradeBookEntrybyStudentIDandClassID]    Script Date: 6/16/2014 1:18:33 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




---Student Assignment with Grades SPROC

CREATE PROCEDURE [dbo].[GetStudentGradeBookEntrybyStudentIDandClassID] (
@UserID varchar(128),
@ClassID int
) AS
SELECT s.StudentID, ClassID, LetterGrade, PercentGrade, EntryName
FROM StudentGradeBookEntry s
INNER JOIN GradeBookEntry g ON s.EntryID = g.EntryID
INNER JOIN StudentInformation i ON i.StudentID = s.StudentID
WHERE i.UserID =@UserID AND ClassID= @ClassID AND PointsScored IS NOT NULL
ORDER BY DueDate

GO


