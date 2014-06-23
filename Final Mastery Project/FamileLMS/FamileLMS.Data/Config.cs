using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace FamileLMS.Data
{
    public static class Config
    {
        private static string _connectionString;

        public static string GetConnectionString()
        {
            if(string.IsNullOrEmpty(_connectionString))
                _connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            return _connectionString;
        }



    }
}
