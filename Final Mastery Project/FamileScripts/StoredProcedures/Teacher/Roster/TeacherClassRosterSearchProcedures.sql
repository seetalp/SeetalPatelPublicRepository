USE [MasteryProject]
GO
/****** Object:  StoredProcedure [dbo].[SearchStudentByLastNameAndGradeLevel]    Script Date: 6/20/2014 9:58:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--exec SearchStudentByGradeLevelOnly 7

ALTER PROCEDURE [dbo].[SearchStudentByLastNameAndGradeLevel](
@LastName varchar(30),
@GradeLevel tinyint,
@ClassID int
) AS
SELECT FirstName, LastName, AspNetUsers.GradeLevel, StudentInformation.StudentID
FROM StudentInformation
INNER JOIN AspNetUsers ON AspNetUsers.Id = StudentInformation.StudentID
WHERE LastName LIKE @LastName + '%' AND AspNetUsers.GradeLevel = @GradeLevel AND (StudentID NOT IN (SELECT StudentID FROM StudentClass WHERE ClassID = @ClassID) OR StudentID IN (SELECT StudentID FROM StudentClass WHERE ClassID = @ClassID AND IsDeleted =1))


USE [MasteryProject]
GO
/****** Object:  StoredProcedure [dbo].[SearchStudentByLastNameOnly]    Script Date: 6/20/2014 9:58:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[SearchStudentByLastNameOnly](
@LastName varchar(30),
@ClassID int
)AS


SELECT FirstName,LastName, AspNetUsers.GradeLevel, StudentInformation.StudentID
FROM StudentInformation
INNER JOIN AspNetUsers ON AspNetUsers.Id = StudentInformation.UserID
WHERE LastName LIKE @LastName +'%' AND (StudentID NOT IN (SELECT StudentID FROM StudentClass WHERE ClassID = @ClassID) OR StudentID IN (SELECT StudentID FROM StudentClass WHERE ClassID = @ClassID AND IsDeleted =1))


USE [MasteryProject]
GO
/****** Object:  StoredProcedure [dbo].[SearchStudentByGradeLevelOnly]    Script Date: 6/20/2014 9:57:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[SearchStudentByGradeLevelOnly](
@GradeLevel tinyint,
@ClassID int
)AS
SELECT FirstName, LastName, AspNetUsers.GradeLevel, StudentInformation.StudentID
FROM StudentInformation
INNER JOIN AspNetUsers ON AspNetUsers.Id = StudentInformation.UserID
WHERE AspNetUsers.GradeLevel = @GradeLevel AND (StudentID NOT IN (SELECT StudentID FROM StudentClass WHERE ClassID = @ClassID) OR StudentID IN (SELECT StudentID FROM StudentClass WHERE ClassID = @ClassID AND IsDeleted =1))