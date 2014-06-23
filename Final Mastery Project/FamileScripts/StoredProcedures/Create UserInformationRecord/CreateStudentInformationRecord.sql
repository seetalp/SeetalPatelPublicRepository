USE [MasteryProject]
GO

/****** Object:  StoredProcedure [dbo].[CreateStudentInformationRecord]    Script Date: 6/16/2014 2:51:01 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


---Create new Student Information record SPROC



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


