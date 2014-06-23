using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using FamileLMS.Models.Interfaces;
using FamileLMS.Models.Requests;
using FamileLMS.Models.Views;
using Dapper;

namespace FamileLMS.Data
{
    public class RosterRepository: IRosterRepository
    {
        public List<TeacherClassRoster> GetClassRoster(int classId)
        {
            //using Dapper for this one
            using (var cn = new SqlConnection(Config.GetConnectionString()))
            {
                var p = new DynamicParameters();
                p.Add("@ClassID", classId);
                return
                    cn.Query<TeacherClassRoster>("GetClassRosterbyClassID", p, commandType: CommandType.StoredProcedure)
                        .ToList();//we need to return type "list"
            }
        }

   

        //using Dapper and because we have a combo id use a request object to pass through this method
        public void DeleteStudentFromClass(RosterDeleteRequest request)
        {
            using (var cn = new SqlConnection(Config.GetConnectionString()))
            {
                var p = new DynamicParameters();
                p.Add("@ClassID", request.ClassID);
                p.Add("@StudentID", request.StudentID);

                cn.Execute("RemoveStudentFromClass", p, commandType: CommandType.StoredProcedure);//nothing to return
            }
        }


//------------------------------------------------------------------------------------------------------------------------------------
//Redo in Dapper


        //determines which search method to use
        public List<TeacherClassRoster> Search(TeacherClassRoster request)
        {
            if (string.IsNullOrEmpty(request.LastName))
            {
                return SearchStudentByGradeLevel(request);
            }
            if (request.GradeLevel == null)
            {
                return SearchStudentByLastNameOnly(request);
            }
            return SearchStudentByLastNameAndGradeLevel(request);
        }

        ///search student by last name and grade level
        private List<TeacherClassRoster> SearchStudentByLastNameAndGradeLevel(TeacherClassRoster request)
        {
            using (var cn = new SqlConnection(Config.GetConnectionString()))
            {
                var p = new DynamicParameters();
                p.Add("@LastName", request.LastName);
                p.Add("@GradeLevel", request.GradeLevel);
                p.Add("@ClassID", request.ClassID);
               

                return
                    cn.Query<TeacherClassRoster>("SearchStudentByLastNameAndGradeLevel", p,
                        commandType: CommandType.StoredProcedure).ToList();
            }
        }



        private List<TeacherClassRoster> SearchStudentByLastNameOnly(TeacherClassRoster request)
        {
            using (var cn = new SqlConnection(Config.GetConnectionString()))
            {
                var p = new DynamicParameters();
                p.Add("@LastName", request.LastName);
                p.Add("@ClassID", request.ClassID);
             
                

                return
                    cn.Query<TeacherClassRoster>("SearchStudentByLastNameOnly", p,
                        commandType: CommandType.StoredProcedure).ToList();
            }
        }

        private List<TeacherClassRoster> SearchStudentByGradeLevel(TeacherClassRoster request)
        {
            using (var cn = new SqlConnection(Config.GetConnectionString()))
            {
                var p = new DynamicParameters();
                p.Add("@GradeLevel", request.GradeLevel);
                p.Add("@ClassID", request.ClassID);
             


                return
                    cn.Query<TeacherClassRoster>("SearchStudentByGradeLevelOnly", p,
                        commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public void AddToRoster(RosterAddRequest request)
        {
            using (var cn = new SqlConnection(Config.GetConnectionString()))
            {
                var p = new DynamicParameters();
                p.Add("@ClassID", request.ClassID);
                p.Add("@StudentID", request.StudentID);
                

                cn.Execute("AddStudentToClass", p, commandType: CommandType.StoredProcedure);
                cn.Execute("RetroGradeBookEntryforNewStudent", p, commandType: CommandType.StoredProcedure);

                request.ClassID = p.Get<int>("@ClassID");
                request.StudentID = p.Get<int>("@StudentID");
              

                
            }
        }
//-------------------------------------------------legacy code-------------------------------------------------------------------------------------------------------------
        ////search student by last name and grade level
        //private List<TeacherClassRoster> SearchStudentByLastNameAndGradeLevel(TeacherClassRoster name)
        // {
        //    var studentlist = new List<TeacherClassRoster>();
        //    using (var cn = new SqlConnection(Config.GetConnectionString()))
        //    {
        //        var cmd = new SqlCommand();
        //        cmd.Connection = cn;
        //        cmd.CommandText = "SearchStudentByLastNameAndGradeLevel";
        //        cmd.CommandType = CommandType.StoredProcedure;

        //        cmd.Parameters.AddWithValue("@LastName", name.LastName);
        //        cmd.Parameters.AddWithValue("@GradeLevel", name.GradeLevel);

        //        cn.Open();

        //        using (var dr = cmd.ExecuteReader())
        //        {
        //            while (dr.Read())
        //            {
        //                studentlist.Add(new TeacherClassRoster()
        //                {
        //                    FirstName = dr["FirstName"].ToString(),
        //                    LastName = dr["LastName"].ToString(),
        //                    GradeLevel = (int) dr["GradeLevel"],
        //                    StudentID = (int) dr["StudentID"]
        //                });

        //            }
        //        }
        //    }
        //    return studentlist;
        //}
        ////search student by last name only
        //private List<TeacherClassRoster> SearchStudentByLastNameOnly(TeacherClassRoster name)
        //{
        //    var studentlist = new List<TeacherClassRoster>();
        //    using (var cn = new SqlConnection(Config.GetConnectionString()))
        //    {
        //        var cmd = new SqlCommand();
        //        cmd.Connection = cn;
        //        cmd.CommandText = "SearchStudentByLastNameOnly";
        //        cmd.CommandType = CommandType.StoredProcedure;

        //        cmd.Parameters.AddWithValue("@LastName", name.LastName);

        //        cn.Open();

        //        using (var dr = cmd.ExecuteReader())
        //        {
        //            while (dr.Read())
        //            {
        //                studentlist.Add(new TeacherClassRoster()
        //                {
        //                    FirstName = dr["FirstName"].ToString(),
        //                    LastName = dr["LastName"].ToString(),
        //                    GradeLevel = (int)dr["GradeLevel"],
        //                    StudentID = (int)dr["StudentID"]
        //                });
        //            }
        //        }
        //    }
        //    return studentlist;
        //}
        ////search student by grade level only
        //public List<TeacherClassRoster> SearchStudentByGradeLevel(TeacherClassRoster gradelevel)
        //{
        //    var studentlist = new List<TeacherClassRoster>();
        //    using (var cn = new SqlConnection(Config.GetConnectionString()))
        //    {
        //        var cmd = new SqlCommand();
        //        cmd.Connection = cn;
        //        cmd.CommandText = "SearchStudentByGradeLevelOnly";
        //        cmd.CommandType = CommandType.StoredProcedure;

        //        cmd.Parameters.AddWithValue("@GradeLevel", gradelevel.GradeLevel);

        //        cn.Open();

        //        using (var dr = cmd.ExecuteReader())
        //        {
        //            while (dr.Read())
        //            {
        //                studentlist.Add(new TeacherClassRoster()
        //                {
        //                    FirstName = dr["FirstName"].ToString(),
        //                    LastName = dr["LastName"].ToString(),
        //                    GradeLevel = (int)dr["GradeLevel"],
        //                    StudentID = (int)dr["StudentID"]
        //                });
        //            }
        //        }
        //    }
        //    return studentlist;
        //}
//------------------------------------------------------------------------------------------------------------------------------------------
        //public void AddToRoster(RosterAddRequest request)
        //{
        //    using (var cn = new SqlConnection(Config.GetConnectionString()))
        //    {
        //        var cmd = new SqlCommand();
        //        cmd.CommandText = "AddStudentToClass";
        //        cmd.CommandType = CommandType.StoredProcedure;

        //        cmd.Parameters.AddWithValue("@ClassID", request.ClassID);
        //        cmd.Parameters.AddWithValue("@StudentID", request.StudentID);
        //        cmd.Parameters.AddWithValue("@FirstName", request.FirstName);
        //        cmd.Parameters.AddWithValue("@LastName", request.LastName);
        //        cmd.Parameters.AddWithValue("@UserName", request.UserName);

        //        cn.Open();
        //        cmd.ExecuteNonQuery();
        //    }
        //}
    }
}
