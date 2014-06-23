CREATE PROCEDURE [dbo].[GetClassGradeCountById]
(
	@ClassID int
) AS

SELECT LetterGrade, COUNT(*) AS GradeCount
FROM StudentClass
Where ClassID = @ClassID
GROUP BY LetterGrade
HAVING LetterGrade IS NOT NULL