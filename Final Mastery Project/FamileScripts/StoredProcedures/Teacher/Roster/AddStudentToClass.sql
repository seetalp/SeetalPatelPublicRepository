USE [MasteryProject]
GO
/****** Object:  StoredProcedure [dbo].[AddStudentToClass]    Script Date: 6/16/2014 4:32:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[AddStudentToClass](
@ClassID int,
@StudentID int
) AS

IF EXISTS (SELECT * FROM StudentClass WHERE ClassId = @ClassID AND StudentID = @StudentID)
BEGIN
	UPDATE StudentClass 
		SET IsDeleted = 0 -- undelete
	FROM StudentClass 
	WHERE ClassID = @ClassID AND StudentID = @StudentID;
END
ELSE
BEGIN
INSERT INTO StudentClass(
	ClassID,
	StudentID
)
Values(
	@ClassID,
	@StudentID
)
END