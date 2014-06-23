using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FamileLMS.Models.Views;

namespace FamileLMS.Data
{
    public class StudentRepository
    {
        //Return a list of student's classes with overall class grade
        public List<StudentDashboard> GetListofClassesWithGrades(string UserID)
        {
            //Instantiate a new list of model StudentDashboard-SP
            List<StudentDashboard> classes = new List<StudentDashboard>();
            //create and open a connection to SQL Server-SP


            using (var cn = new SqlConnection(Config.GetConnectionString()))
            {
                var cmd = new SqlCommand("GetStudentClassbyStudentID", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserID", UserID);

                cn.Open();

                using (var dr = cmd.ExecuteReader())//executes the stored procedures
                {
                    while (dr.Read())//did the data
                    {
                        classes.Add(new StudentDashboard()
                        {
                            ClassName = dr["ClassName"].ToString(),
                            LetterGrade = dr["LetterGrade"].ToString(),
                            ClassID = (int)dr["ClassID"]
                        });


                    }
                }

            }

            return classes;

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
