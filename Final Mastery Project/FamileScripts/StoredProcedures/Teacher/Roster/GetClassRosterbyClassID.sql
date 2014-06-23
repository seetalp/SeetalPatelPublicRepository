CREATE PROCEDURE [dbo].[GetClassRosterbyClassID] (
@ClassID int
) AS
SELECT s.StudentID, s.ClassID, FirstName, LastName, UserName
FROM Class c
JOIN StudentClass s ON c.ClassID = s.ClassID
JOIN StudentInformation i ON i.StudentID = s.StudentID
JOIN AspNetUsers a ON a.Id = i.UserID
WHERE s.ClassID= @ClassID AND s.IsDeleted = 0
ORDER BY LastName, FirstName

