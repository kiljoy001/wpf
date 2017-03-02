using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows;

namespace wpf.SQL
{
    class showProducts : AbstractedSQL
    {
        public showProducts()
        {
            string selectData = "[product_name], [product_units] ,[product_price], [product_enable] FROM[dbo].[Product]";
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
                    selectAll.CommandType = CommandType.Text;
                    selectAll.CommandText = selectData;
                    SqlDataTable return_value = selectAll.ExecuteReader();
                    if(return_value.HasRows)
                    {
                        while(return_value.Read())
                        {

                        }
                    }
                    else
                    {
                        throw new ArgumentNullException();
                    }
                }
                catch(SqlException se)
                {
                    MessageBox.Show($"Error: {se.ToString()}", $"An SQL related error has occured.");
                }
                catch(Exception e)
                {
                    MessageBox.Show($"Error: {e.ToString()}\n{e.GetType()}", $"An {e.GetType()} error has occured.");
                }
            }
        }
    }
}
