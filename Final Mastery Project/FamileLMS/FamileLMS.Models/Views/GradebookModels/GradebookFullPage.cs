using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace FamileLMS.Models.Views.GradebookModels
{
    public class GradebookFullPage
    {
        public GradebookFullPage()
        {

        }

        public GradebookFullPage(List<GradebookRawData> raw)
        {
            AssignmentNames = raw.Select(s => s.EntryName).Distinct().ToList();
            StudentGrades = new List<StudentGrade>();
            foreach (var record in raw)
            {
                if (!StudentGrades.Exists(x => x.StudentID == record.StudentID))
                {
                    StudentGrades.Add(new StudentGrade()
                        {
                            FirstName = record.FirstName,
                            LastName = record.LastName,
                            StudentID = record.StudentID,
                            LetterGrade = record.CourseLetterGrade,
                            Assignments = new List<StudentAssignmentEntry>()
                        });
                }
                StudentGrades.Find(x=>x.StudentID == record.StudentID).Assignments.Add(new StudentAssignmentEntry()
                {
                    DueDate = record.DueDate,
                    EntryID = record.EntryID,
                    LetterGrade = record.AssignmentLetterGrade,
                    PercentGrade = record.AssignmentPercentGrade,
                    PointsPossible = record.PossiblePoints,
                    PointsScored = record.PointsScored
                });
            }
        }
        public List<string> AssignmentNames { get; set; }
        public List<StudentGrade> StudentGrades { get; set; }
    }
}
