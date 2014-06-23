using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using FamileLMS.Models.Interfaces;
using FamileLMS.Models.Views;

namespace FamileLMS.Data
{
    public class ParentRepository
    {
        public List<ParentDashboard> GetStudents(string UserID)
        {
            List<ParentDashboard> students = new List<ParentDashboard>();


            using (var cn = new SqlConnection(Config.GetConnectionString()))
            {
                var cmd = new SqlCommand("GetStudentByParentID", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserID", UserID);

                cn.Open();

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        students.Add(new ParentDashboard()
                        {
                            StudentID = (int) dr["StudentID"],
                            FirstName = dr["FirstName"].ToString(),
                            LastName = dr["LastName"].ToString(),
                            UserID = dr["UserID"].ToString()
                        });
                    }
                }
            }
            return students;
        }
        //Return a list of student's assignments with grades
        public List<StudentAndParentGrade> GetStudentAssignmentGradesbyClass(string UserID, int ClassID)
        {
            List<StudentAndParentGrade> assignmentgrades = new List<StudentAndParentGrade>();

            using (var cn = new SqlConnection(Config.GetConnectionString()))
            {
                var cmd = new SqlCommand("GetStudentGradeBookEntrybyStudentIDandClassID", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserID", UserID);
                cmd.Parameters.AddWithValue("@ClassID", ClassID);

                cn.Open();

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        if (dr["PercentGrade"] != DBNull.Value)
                        {
                            assignmentgrades.Add(new StudentAndParentGrade()
                            {
                                StudentID = (int)dr["StudentID"],
                                ClassID = (int)dr["ClassID"],
                                EntryName = dr["EntryName"].ToString(),
                                PercentGrade = (double)dr["PercentGrade"],
                                LetterGrade = dr["LetterGrade"].ToString()

                            });
                        }



                    }
                }

            }

            return assignmentgrades;
        }
    }
}