CREATE PROCEDURE RemoveStudentFromClass(

@StudentID int,
@ClassID int
)AS

UPDATE StudentClass
SET IsDeleted = 1
From StudentClass
WHERE StudentID=@StudentID AND ClassID=@ClassID
GO
