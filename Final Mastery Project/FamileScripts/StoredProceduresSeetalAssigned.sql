
USE MasteryProject
GO

---Create new Student Information record SPROC



CREATE PROCEDURE CreateStudentInformationRecord (
           @UserID nvarchar(128)
) 
AS 

BEGIN TRANSACTION
INSERT INTO StudentInformation 
(
			UserID
)
VALUES
(
		   @UserID
)
UPDATE AspNetUsers 
SET IsApproved =1 
WHERE id=@UserID

COMMIT TRANSACTION
GO

---Create new Teacher Information record SPROC

CREATE PROCEDURE CreateTeacherInformationRecord (
           @UserID nvarchar(128)
) 
AS 

BEGIN TRANSACTION
INSERT INTO TeacherInformation 
(
			UserID
)
VALUES
(
		   @UserID
)
UPDATE AspNetUsers 
SET IsApproved =1 
WHERE id=@UserID

COMMIT TRANSACTION
GO

---Create new Parent Information record SPROC

CREATE PROCEDURE CreateParentInformationRecord (
           @UserID nvarchar(128)
) 
AS 

BEGIN TRANSACTION
INSERT INTO ParentInformation 
(
			UserID
)
VALUES
(
		   @UserID
)
UPDATE AspNetUsers 
SET IsApproved =1 
WHERE id=@UserID

COMMIT TRANSACTION
GO


---Student Dashboard SPROC

CREATE PROCEDURE GetStudentClassbyStudentID (

@UserID varchar(128)
) AS
SELECT ClassName, LetterGrade
FROM StudentClass s
INNER JOIN Class c ON s.ClassID = c.ClassID
INNER JOIN StudentInformation i ON i.StudentID = s.StudentID
WHERE i.UserID =@UserID
GO



---Student Assignment with Grades SPROC

CREATE PROCEDURE GetStudentGradeBookEntrybyStudentIDandClassID (
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



---Teacher Add Assignment SPROC

CREATE PROCEDURE CreateNewGradeBookEntry (
           @EntryName varchar(50),
		   @EntryType varchar(10),
           @Description varchar(300),
           @PossiblePoints int,
		   @AssignedDate date,
		   @DueDate date,
		   @ClassID int,
		   @GradeBookEntryTypeID int
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
			AssignedDate,
			DueDate,
			ClassID
			
) 
VALUES
(
		   @EntryName,
		   @EntryType,
           @Description,
           @PossiblePoints,
		   @AssignedDate,
		   @DueDate,
		   @ClassID
		   
)

SET @EntryID = SCOPE_IDENTITY();

INSERT INTO StudentGradeBookEntry(StudentID, EntryId)
SELECT StudentID, @EntryID
FROM StudentClass
WHERE ClassID = @ClassID

COMMIT TRANSACTION

GO



---Current Class Size SPROC (Bryan)

CREATE PROCEDURE GetCurrentClassNamesAndSizesByTeacherID
(
	 @UserID nvarchar(128)
) AS

SELECT ClassName,COUNT(*)AS ClassCountActive
FROM Class
JOIN StudentClass ON Class.ClassID = StudentClass.ClassID
JOIN TeacherInformation i ON i.TeacherID = Class.TeacherID
WHERE i.UserID = @UserID AND IsArchived = 0
GROUP BY ClassName


GO



---Archived Class Size SPROC (Bryan)

CREATE PROCEDURE GetArchivedClassNamesAndSizesByTeacherID
(
	 @UserID nvarchar(128)
) AS

SELECT ClassName,COUNT(*)AS ClassCountArchived
FROM Class
JOIN StudentClass ON Class.ClassID = StudentClass.ClassID
JOIN TeacherInformation i ON i.TeacherID = Class.TeacherID
WHERE i.UserID = @UserID AND IsArchived = 1
GROUP BY ClassName

GO




---Retrieve Student Assignments by ClassID SPROC

CREATE PROCEDURE GetStudentAssignmentsbyClassID
(
	@ClassID int,
	 @UserID nvarchar(128)
) AS

SELECT ClassName, FirstName, LastName, LetterGrade, PercentGrade, PointsScored, PossiblePoints
FROM StudentGradeBookEntry s
JOIN GradeBookEntry g ON g.EntryID = s.EntryID
JOIN StudentInformation i ON i.StudentID=s.StudentID
JOIN AspNetUsers a ON a.Id = i.UserID
JOIN Class c on c.ClassID = @ClassID
WHERE g.ClassID = @ClassID AND  i.UserID = @UserID


GO





---Edit Student Assignments by StudentID SPROC
CREATE PROCEDURE EditStudentAssignmentbyStudentID (

          @UserID nvarchar(128),
		  @EntryID int,
		  @PercentGrade float,
		  @LetterGrade varchar(3),
		  @PointsScored int,
		  @Description varchar(300)
) 
AS

UPDATE StudentGradeBookEntry
SET PointsScored = @PointsScored, [Description]= @Description, LetterGrade = @LetterGrade, PercentGrade= @PercentGrade
FROM StudentGradeBookEntry
JOIN StudentInformation s ON StudentGradeBookEntry.StudentID = s.StudentID
WHERE s.UserID= @UserID AND StudentGradeBookEntry.EntryID = @EntryID

GO




---TeacherClass Information get Class Details SPROC
CREATE PROCEDURE GetClassInfoById 
(
	@ClassID int

) AS

SELECT c.ClassID,c.ClassName,c.[Subject],c.StartDate,c.EndDate,c.IsArchived,c.[Description]
FROM Class AS c
WHERE c.ClassID = @ClassID

GO




---TeacherClass Information get Class grade count
CREATE PROCEDURE GetClassGradeCountById
(
	@ClassID int

) AS

SELECT LetterGrade, COUNT(*) AS GradeCount
FROM StudentClass
Where ClassID = @ClassID
GROUP BY LetterGrade

GO




---TeacherClass Information get Class student count
CREATE PROCEDURE GetClassStudentCountById
(
	@ClassID int
)AS

SELECT COUNT(*) AS StudentCount
FROM StudentClass 
WHERE ClassID = @ClassID

GO

---TeacherClass Information create Class



CREATE PROCEDURE AddClass (
		   
		   @UserID varchar(128),
           @ClassName varchar(50),
		   @IsArchived bit,
           @Description varchar(300),
           @Subject varchar(50),
		   @StartDate date,
		   @EndDate date,
		   @GradeLevel tinyint

) 

AS 

DECLARE @ClassID int

BEGIN TRANSACTION

INSERT INTO Class 
(
		   TeacherID,
           ClassName,
		   IsArchived,
           [Description],
           [Subject],
		   StartDate,
		   EndDate,
		   GradeLevel
			
) 
VALUES
(
		   @UserID,
           @ClassName,
		   @IsArchived,
           @Description,
           @Subject,
		   @StartDate,
		   @EndDate,
		   @GradeLevel
		   
)

SET @ClassID = SCOPE_IDENTITY();
COMMIT TRANSACTION

GO





---TeacherClass Information edit Class

CREATE PROCEDURE EditClass
(
	@ClassID int,
	@UserID varchar(128),
	@ClassName varchar(50),
	@Subject varchar(50),
	@StartDate date,
	@EndDate date,
	@GradeLevel tinyint,
	@IsArchived bit,
	@Description varchar(300)
	
)AS

UPDATE Class
SET  ClassName = @ClassName, [Subject] = @Subject, [Description]=@Description, GradeLevel = @GradeLevel, IsArchived=@IsArchived, StartDate=@StartDate, EndDate=@EndDate
FROM Class
JOIN TeacherInformation t ON t.TeacherID = Class.TeacherID
WHERE Class.ClassID = @ClassID AND t.UserID= @UserID

GO
---Still NEED:
---Get Class Roster by Class
---Remove Student from Class
---Add student to Class
---Search Student in Class
---Get Student by Parent ID












