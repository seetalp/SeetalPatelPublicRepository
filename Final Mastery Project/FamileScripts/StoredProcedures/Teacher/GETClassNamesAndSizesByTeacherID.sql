USE [MasteryProject]
GO
/****** Object:  StoredProcedure [dbo].[GETClassNamesAndSizesByTeacherID]    Script Date: 6/11/2014 1:32:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GETClassNamesAndSizesByTeacherID]
(
	 @UserID nvarchar(128)
) AS

	SELECT cl.ClassName, cl.ClassID, cl.IsArchived, 
	(SELECT count(*) AS StudentCount FROM StudentClass WHERE StudentClass.ClassID = cl.ClassID AND IsDeleted=0) AS StudentCount
	FROM Class cl
		INNER JOIN TeacherInformation i ON i.TeacherID = cl.TeacherID
	WHERE i.UserID = @UserID AND IsArchived = 0
	ORDER BY cl.ClassName, StudentCount