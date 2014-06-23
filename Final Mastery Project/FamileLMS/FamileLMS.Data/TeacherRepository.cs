using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using FamileLMS.Models;
using FamileLMS.Models.Interfaces;
using FamileLMS.Models.Requests;
using FamileLMS.Models.Response;
using FamileLMS.Models.Views;

namespace FamileLMS.Data
{
    public class TeacherRepository : ITeacherRepository
    {

        //Class summary by Teacher
        public List<TeacherDashboardItem> GetTeacherDashboardItems(string userId)
        {
            var classList = new List<TeacherDashboardItem>();
            using (var cn = new SqlConnection(Config.GetConnectionString()))
            {
                var cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "GETClassNamesAndSizesByTeacherID";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@UserID", userId);

                cn.Open();

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        classList.Add(new TeacherDashboardItem()
                        {
                            ClassID = (int)dr["ClassID"],
                            ClassName = dr["ClassName"].ToString(),
                            StudentCount = (int)dr["StudentCount"],
                            IsArchived = (bool)dr["IsArchived"]
                        });
                    }
                }
            }

            return classList;
        }

        //Class details by Class ID
        public TeacherClassInformation GetClassInformationbyClassID(int classId)
        {
            TeacherClassInformation classinfo = null;

            using (var cn = new SqlConnection(Config.GetConnectionString()))
            {
                var cmd = new SqlCommand("GetClassInfoById", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ClassID", classId);

                cn.Open();


                using (var dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        classinfo = new TeacherClassInformation();

                        classinfo.ClassID = (int)dr["ClassID"];
                        classinfo.ClassName = dr["ClassName"].ToString();
                        classinfo.Subject = dr["Subject"].ToString();
                        classinfo.Description = dr["Description"].ToString();

                        if (dr["GradeLevel"] != DBNull.Value)
                        {
                            classinfo.GradeLevel = (byte)dr["GradeLevel"];
                        }

                        classinfo.StartDate = (DateTime)dr["StartDate"];
                        classinfo.EndDate = (DateTime)dr["EndDate"];
                        classinfo.IsArchived = (bool)dr["IsArchived"];


                    }
                }
            }


            return classinfo;


        }

        //Add a Class
        public void AddClass(TeacherClassInformation classInfo)
        {
            using (var cn = new SqlConnection(Config.GetConnectionString()))
            {

                var cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "AddClass";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@UserID", classInfo.UserID);
                cmd.Parameters.AddWithValue("@ClassName", classInfo.ClassName);
                cmd.Parameters.AddWithValue("@GradeLevel", classInfo.GradeLevel);
                cmd.Parameters.AddWithValue("@Subject", classInfo.Subject);
                cmd.Parameters.AddWithValue("@StartDate", classInfo.StartDate);
                cmd.Parameters.AddWithValue("@EndDate", classInfo.EndDate);
                cmd.Parameters.AddWithValue("@IsArchived", classInfo.IsArchived);
                cmd.Parameters.AddWithValue("@Description", classInfo.Description);

                cn.Open();
                cmd.ExecuteNonQuery();


            }
        }

        //Edit Class using Dapper
        public void EditClass(TeacherClassInformation classInfo)
        {
            using (SqlConnection cn = new SqlConnection(Config.GetConnectionString()))
            {
                var p = new DynamicParameters();
                p.Add("@UserId", classInfo.UserID);
                p.Add("@ClassName", classInfo.ClassName);
                p.Add("@GradeLevel", classInfo.GradeLevel);
                p.Add("@Subject", classInfo.Subject);
                p.Add("@StartDate", classInfo.StartDate);
                p.Add("@EndDate", classInfo.EndDate);
                p.Add("@IsArchived", classInfo.IsArchived);
                p.Add("@Description", classInfo.Description);
                p.Add("@ClassID", classInfo.ClassID);

                cn.Execute("EditClass", p, commandType: CommandType.StoredProcedure);


            }
        }



        //Insert a new assignment based on teacher view
        public void AddNewAssignmentbyClass(Assignment assignment)
        {
            using (var cn = new SqlConnection(Config.GetConnectionString()))
            {
                var cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "CreateNewGradeBookEntry";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ClassID", assignment.ClassID);
                cmd.Parameters.AddWithValue("@EntryName", assignment.EntryName);
                cmd.Parameters.AddWithValue("@PossiblePoints", assignment.PossiblePoints);
                cmd.Parameters.AddWithValue("@DueDate", assignment.DueDate);
                cmd.Parameters.AddWithValue("@EntryType", assignment.EntryType);
                cmd.Parameters.AddWithValue("@Description", assignment.Description);

                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public AnalyticsResponse GetAnalytics(int id)
        {
            var response = new AnalyticsResponse();

            using (var cn = new SqlConnection(Config.GetConnectionString()))
            {
                var p = new DynamicParameters();
                p.Add("@ClassID", id);

                response.StudentGradeAggregate= cn.Query<GradeTableCount>("GetClassGradeCountById", p, commandType: CommandType.StoredProcedure).ToList();
                //response.GradeCounts = cn.Query("GetClassGradeCountById", p, commandType: CommandType.StoredProcedure).ToDictionary(m =>(string)m.LetterGrade, m=>(int)m.GradeCount);//complicated casting because we need to convert results back into dictionary

                //foreach (var item in rawGradeCounts)
                //{
                //    response.StudentGradeAggregate.Add(new GradeCount() { Count = (int)item.GradeCount, LetterGrade = item.LetterGrade.ToString() });
                //}
                response.StudentCount = cn.Query<int>("GetClassStudentCountById", p, commandType: CommandType.StoredProcedure).First();
            }

            return response;
        }





    }
}



