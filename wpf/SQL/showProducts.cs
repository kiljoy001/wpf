using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpf.SQL
{
    class showProducts : AbstractedSQL
    {
        public showProducts()
        {
            string selectData = "[product_name], [product_units] ,[product_price] FROM[dbo].[Product]";
            using (SqlConnection dbConnect = new SqlConnection())
            {
                dbConnect.ConnectionString = connection;
                dbConnect.Open();
                SqlTransaction trans = dbConnect.BeginTransaction();
                SqlCommand selectAll = dbConnect.CreateCommand();
                selectAll.Transaction = trans;
                try
                {
                    selectAll.Connection = dbConnect;
                }
            }
        }
    }
}
