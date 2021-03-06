USE [MasteryProject]
GO
/****** Object:  StoredProcedure [dbo].[AddClass]    Script Date: 6/10/2014 1:52:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddClass] (
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

-- to get the teacher id via user id we'll do a select
-- we can just embed the parameters as part of the select
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
SELECT TeacherID,            
	@ClassName,
	@IsArchived,
    @Description,
    @Subject,
	@StartDate,
	@EndDate,
	@GradeLevel
FROM TeacherInformation
WHERE UserID = @UserID


GO
/****** Object:  StoredProcedure [dbo].[CreateNewGradeBookEntry]    Script Date: 6/10/2014 1:52:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CreateNewGradeBookEntry] (
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
/****** Object:  StoredProcedure [dbo].[CreateParentInformationRecord]    Script Date: 6/10/2014 1:52:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CreateParentInformationRecord] (
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
/****** Object:  StoredProcedure [dbo].[CreateStudentInformationRecord]    Script Date: 6/10/2014 1:52:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CreateStudentInformationRecord] (
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
/****** Object:  StoredProcedure [dbo].[CreateTeacherInformationRecord]    Script Date: 6/10/2014 1:52:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CreateTeacherInformationRecord] (
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
/****** Object:  StoredProcedure [dbo].[EditClass]    Script Date: 6/10/2014 1:52:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EditClass]
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
/****** Object:  StoredProcedure [dbo].[EditClassbyClassIDandStudentID]    Script Date: 6/10/2014 1:52:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EditClassbyClassIDandStudentID] (
          @StudentID int,
		  @ClassID int,
		  @EntryID int,
		  @LastName nvarchar(30),
		  @PointsScored int,
		  @Description varchar(300),
		  @LetterGrade varchar(3),
		  @PercentGrade float
) 
AS

UPDATE StudentGradeBookEntry 
SET PointsScored = @PointsScored, [Description]=@Description, LetterGrade = @LetterGrade, PercentGrade=@PercentGrade
WHERE StudentID=@StudentID AND EntryID = @EntryID

GO
/****** Object:  StoredProcedure [dbo].[EditStudentAssignmentbyStudentID]    Script Date: 6/10/2014 1:52:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EditStudentAssignmentbyStudentID] (

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
/****** Object:  StoredProcedure [dbo].[GetArchivedClassNamesAndSizesByTeacherID]    Script Date: 6/10/2014 1:52:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetArchivedClassNamesAndSizesByTeacherID]
(
	 @UserID nvarchar(128)
) AS

	SELECT cl.ClassName, cl.ClassID, cl.IsArchived, 
	(SELECT count(*) AS StudentCount FROM StudentClass WHERE StudentClass.ClassID = cl.ClassID) AS StudentCount
	FROM Class cl
		INNER JOIN TeacherInformation i ON i.TeacherID = cl.TeacherID
	WHERE i.UserID = @UserID AND IsArchived = 1
	ORDER BY cl.ClassName, StudentCount
GO
/****** Object:  StoredProcedure [dbo].[GetClassGradeCountById]    Script Date: 6/10/2014 1:52:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetClassGradeCountById]
(
	@ClassID int

) AS

SELECT LetterGrade, COUNT(*) AS GradeCount
FROM StudentClass
Where ClassID = @ClassID
GROUP BY LetterGrade


GO
/****** Object:  StoredProcedure [dbo].[GetClassInfoById]    Script Date: 6/10/2014 1:52:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetClassInfoById] 
(
	@ClassID int

) AS

SELECT c.ClassID,c.ClassName,c.[Subject],c.StartDate,c.EndDate,c.IsArchived,c.[Description], c.GradeLevel
FROM Class AS c
WHERE c.ClassID = @ClassID
GO
/****** Object:  StoredProcedure [dbo].[GETClassNamesAndSizesByTeacherID]    Script Date: 6/10/2014 1:52:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GETClassNamesAndSizesByTeacherID]
(
	@userID int
) AS

SELECT ClassName,COUNT(*) AS StudentCount,IsArchived, class.ClassID
FROM Class
JOIN StudentClass ON Class.ClassID = StudentClass.ClassID
INNER JOIN TeacherInformation i ON i.TeacherID = Class.TeacherID
WHERE i.UserID = @UserID AND IsArchived = 0
GROUP BY ClassName,IsArchived, class.ClassID



GO
/****** Object:  StoredProcedure [dbo].[GetClassRosterbyClassID]    Script Date: 6/10/2014 1:52:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetClassRosterbyClassID] (
@ClassID int
) AS
SELECT s.StudentID, s.ClassID, FirstName, LastName, UserName
FROM Class c
JOIN StudentClass s ON c.ClassID = s.ClassID
JOIN StudentInformation i ON i.StudentID = s.StudentID
JOIN AspNetUsers a ON a.Id = i.UserID
WHERE s.ClassID= @ClassID
ORDER BY LastName, FirstName

GO
/****** Object:  StoredProcedure [dbo].[GetClassStudentCountById]    Script Date: 6/10/2014 1:52:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetClassStudentCountById]
(
	@ClassID int
)AS

SELECT COUNT(*) AS StudentCount
FROM StudentClass 
WHERE ClassID = @ClassID


GO
/****** Object:  StoredProcedure [dbo].[GetCurrentClassNamesAndSizesByTeacherID]    Script Date: 6/10/2014 1:52:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetCurrentClassNamesAndSizesByTeacherID]
(
	 @UserID nvarchar(128)
) AS

	SELECT cl.ClassName, cl.ClassID, cl.IsArchived, 
	(SELECT count(*) AS StudentCount FROM StudentClass WHERE StudentClass.ClassID = cl.ClassID) AS StudentCount
	FROM Class cl
		INNER JOIN TeacherInformation i ON i.TeacherID = cl.TeacherID
	WHERE i.UserID = @UserID AND IsArchived = 0
	ORDER BY cl.ClassName, StudentCount
GO
/****** Object:  StoredProcedure [dbo].[GetStudentAssignmentsbyClassID]    Script Date: 6/10/2014 1:52:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetStudentAssignmentsbyClassID]
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
/****** Object:  StoredProcedure [dbo].[GetStudentClassbyStudentID]    Script Date: 6/10/2014 1:52:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetStudentClassbyStudentID] (

@UserID varchar(128)
) AS
SELECT ClassName, LetterGrade
FROM StudentClass s
INNER JOIN Class c ON s.ClassID = c.ClassID
INNER JOIN StudentInformation i ON i.StudentID = s.StudentID
WHERE i.UserID =@UserID

GO
/****** Object:  StoredProcedure [dbo].[GetStudentGradeBookEntrybyStudentIDandClassID]    Script Date: 6/10/2014 1:52:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
/****** Object:  StoredProcedure [dbo].[RemoveStudentFromClass]    Script Date: 6/10/2014 1:52:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RemoveStudentFromClass]
(     
		  @StudentID int,
		  @ClassID int
) 
AS

UPDATE StudentClass
SET IsDeleted = 1
FROM StudentClass
WHERE StudentID=@StudentID AND ClassID = @ClassID


GO
