USE MasteryProject
GO

CREATE PROCEDURE RetroGradeBookEntryforNewStudent (
@StudentID int,
@ClassID int
) AS

INSERT INTO StudentGradeBookEntry (StudentID, EntryID)
  
SELECT StudentClass.StudentID as StudentID, GradeBookEntry.EntryID as EntryID
FROM GradeBookEntry
JOIN StudentClass on StudentClass.ClassID = @ClassID
WHERE GradeBookEntry.ClassID = @ClassID AND StudentClass.StudentID = @StudentID AND GradeBookEntry.EntryID NOT IN (SELECT EntryID FROM StudentGradeBookEntry WHERE StudentId = @StudentID)