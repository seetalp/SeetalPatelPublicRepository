USE [MasteryProject]
GO

/****** Object:  StoredProcedure [dbo].[UpdateGrade]    Script Date: 6/16/2014 2:38:19 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[UpdateGrade]
(
	@ClassID int,
	@EntryID int,
	@LetterGrade varchar(3),
	@PercentGrade float,
	@PointsScored int,
	@StudentID int
) AS

UPDATE StudentClass
SET LetterGrade = @LetterGrade
WHERE StudentID = @StudentID AND ClassID = @ClassID

UPDATE StudentGradeBookEntry
SET PercentGrade = @PercentGrade, PointsScored = @PointsScored
WHERE StudentID = @StudentID AND EntryID = @EntryID


GO


