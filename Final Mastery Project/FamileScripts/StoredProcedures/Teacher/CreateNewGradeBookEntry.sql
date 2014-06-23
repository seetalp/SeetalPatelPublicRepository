USE [MasteryProject]
GO

/****** Object:  StoredProcedure [dbo].[CreateNewGradeBookEntry]    Script Date: 6/16/2014 1:03:54 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CreateNewGradeBookEntry] (
           @EntryName varchar(50),
		   @EntryType varchar(10),
           @Description varchar(300),
           @PossiblePoints int,
		   @DueDate date,
		   @ClassID int
		   
) 

AS 

DECLARE @EntryID int


BEGIN TRANSACTION

INSERT INTO GradeBookEntry 
(
			EntryName,
			EntryType,
			[Description],
			PossiblePoints,
			DueDate,
			ClassID,
			AssignedDate
			
) 
VALUES
(
		   @EntryName,
		   @EntryType,
           @Description,
           @PossiblePoints,
		   @DueDate,
		   @ClassID,
		   GETDATE()
		   
)

SET @EntryID = SCOPE_IDENTITY();


INSERT INTO StudentGradeBookEntry(StudentID, EntryId)
SELECT StudentID, @EntryID
FROM StudentClass
WHERE ClassID = @ClassID

COMMIT TRANSACTION
GO


