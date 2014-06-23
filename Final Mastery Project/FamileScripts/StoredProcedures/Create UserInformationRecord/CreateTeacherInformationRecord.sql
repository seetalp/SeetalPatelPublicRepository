USE [MasteryProject]
GO

/****** Object:  StoredProcedure [dbo].[CreateTeacherInformationRecord]    Script Date: 6/16/2014 2:51:34 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


---Create new Teacher Information record SPROC

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


