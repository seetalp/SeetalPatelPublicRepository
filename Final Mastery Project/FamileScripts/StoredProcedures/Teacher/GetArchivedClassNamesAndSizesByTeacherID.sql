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