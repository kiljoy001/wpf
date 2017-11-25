using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpf.SQL
{
    public static class SqlExtensions
    {
        public static bool IsAvaliable(this SqlConnection connection)
        {
            try
            {
                connection.Open();
                connection.Close();
            }
            catch(SqlException)
            {
                return false;
            }
            return true;
        }
    }
}
