USE [MasteryProject]
GO
/****** Object:  StoredProcedure [dbo].[EditClass]    Script Date: 6/17/2014 3:26:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[EditClass]
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