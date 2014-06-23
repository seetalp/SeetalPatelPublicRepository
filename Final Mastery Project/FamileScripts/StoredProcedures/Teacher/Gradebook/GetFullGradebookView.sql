USE [MasteryProject]
GO
/****** Object:  StoredProcedure [dbo].[GetFullGradebookView]    Script Date: 6/12/2014 2:28:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetFullGradebookView]
(
	@ClassID int
) AS

SELECT gb.ClassID,users.FirstName,users.LastName,users.Id,si.StudentID,sc.LetterGrade AS CourseLetterGrade,gb.EntryName,gb.EntryID,gb.DueDate,sgb.PercentGrade AS AssignmentPercentGrade,sgb.LetterGrade AS AssignmentLetterGrade,sgb.PointsScored,gb.PossiblePoints
FROM GradeBookEntry AS gb 
INNER JOIN StudentGradeBookEntry AS sgb ON gb.EntryID = sgb.EntryID
INNER JOIN StudentInformation AS si ON sgb.StudentID = si.StudentID
INNER JOIN AspNetUsers AS users ON si.UserID = users.Id
INNER JOIN StudentClass AS sc ON si.StudentID = sc.StudentID AND sc.ClassID = gb.ClassID
WHERE gb.ClassID = @ClassID AND sc.IsDeleted = 0