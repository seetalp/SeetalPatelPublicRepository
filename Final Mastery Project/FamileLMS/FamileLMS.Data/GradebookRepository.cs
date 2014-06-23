using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using FamileLMS.Models.Views;
using FamileLMS.Models.Views.GradebookModels;

namespace FamileLMS.Data
{
    public class GradebookRepository
    {
        public GradebookFullPage GetAllGradebookEntries(int ClassID)
        {
            var rawData = new List<GradebookRawData>();

            using (var cn = new SqlConnection(Config.GetConnectionString()))
            {
                var cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "GetFullGradebookView";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ClassID", ClassID);

                cn.Open();

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        var data = new GradebookRawData();
                        data.ClassID = (int)dr["ClassID"];
                        data.FirstName = dr["FirstName"].ToString();
                        data.LastName = dr["LastName"].ToString();
                        data.StudentID = (int)dr["StudentID"];
                        data.CourseLetterGrade = dr["CourseLetterGrade"].ToString();
                        data.EntryName = dr["EntryName"].ToString();
                        data.EntryID = (int)dr["EntryID"];
                        data.DueDate = DateTime.Parse(dr["DueDate"].ToString());
                        data.PossiblePoints = (int)dr["PossiblePoints"];
                        if (dr["AssignmentPercentGrade"] != DBNull.Value)
                        {
                            data.AssignmentPercentGrade = (double)dr["AssignmentPercentGrade"];
                        }   
                        if (dr["PointsScored"] != DBNull.Value)
                        {
                            data.PointsScored = (int)dr["PointsScored"];
                        }
                        if (dr["AssignmentLetterGrade"] != DBNull.Value)
                        {
                            data.AssignmentLetterGrade = dr["AssignmentLetterGrade"].ToString();
                        }


                        rawData.Add(data);
                    }
                }
            }
            return new GradebookFullPage(rawData);
        }

        public HttpStatusCode UpdateGrade(GradeChangeRequest input)
        {
            using (var cn = new SqlConnection(Config.GetConnectionString()))
            {
                var p = new DynamicParameters();
                p.Add("@ClassID", input.ClassID);
                p.Add("@EntryID", input.EntryID);
                p.Add("@LetterGrade", input.LetterGrade);
                p.Add("@PercentGrade", input.PercentGrade);
                p.Add("@PointsScored", input.PointsScored);
                p.Add("@StudentID", input.StudentID);

                cn.Execute("UpdateGrade", p, commandType: CommandType.StoredProcedure);
            }

            return HttpStatusCode.OK;
        }
    }
}
