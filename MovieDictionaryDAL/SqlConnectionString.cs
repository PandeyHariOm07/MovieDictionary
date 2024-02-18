using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDictionaryDAL
{
    public static class SqlConnectionString
    {
        public static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["MovieDatabaseCon"].ConnectionString;
        }
    }
}
