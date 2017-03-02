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
        private DataSet products_fetch;

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
                    //selectAll.CommandType = CommandType.Text;
                    //selectAll.CommandText = selectData;
                    SqlDataAdapter return_value = new SqlDataAdapter(selectData, dbConnect);
                    products_fetch = new DataSet();
                    return_value.Fill(products_fetch, "Products");
                }
                catch (SqlException se)
                {
                    MessageBox.Show($"Error: {se.ToString()}", $"An SQL related error has occured.");
                }
                catch (Exception e)
                {
                    MessageBox.Show($"Error: {e.ToString()}\n{e.GetType()}", $"An {e.GetType()} error has occured.");
                }
            }
        }
                public DataSet result { get { return products_fetch; } }
        }
    }

