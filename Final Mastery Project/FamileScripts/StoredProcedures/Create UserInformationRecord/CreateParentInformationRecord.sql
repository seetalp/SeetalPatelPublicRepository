USE [MasteryProject]
GO

/****** Object:  StoredProcedure [dbo].[CreateParentInformationRecord]    Script Date: 6/16/2014 2:50:13 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


---Create new Parent Information record SPROC

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


