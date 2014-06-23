USE [MasteryProject]
GO
/****** Object:  StoredProcedure [dbo].[AddClass]    Script Date: 6/19/2014 10:15:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[AddClass] (

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