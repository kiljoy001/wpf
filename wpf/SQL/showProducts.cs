using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace wpf.SQL
{
    class showProducts : AbstractedSQL
    {
        private DataSet products_fetch;

        public showProducts()
        {

            string selectData = "Select [product_name], [product_units] ,[product_price], [product_enable] FROM[dbo].[Product]";
            using (SqlConnection dbConnect = new SqlConnection())
            {
                dbConnect.ConnectionString = connection;
                dbConnect.Open();
                SqlCommand selectAll = new SqlCommand(selectData);
                try
                {
                    selectAll.Connection = dbConnect;
                    selectAll.CommandType = CommandType.Text;
                    selectAll.CommandText = selectData;
                    SqlDataAdapter adapter = new SqlDataAdapter(selectAll);
                    adapter.SelectCommand = selectAll;
                    model_table result = new model_table();
                    adapter.Fill(result,"Product");

                    //if(return_value.HasRows)
                    //{
                    //    while
                    //        (return_value.Read())
                    //    {
                            
                    //    }
                    //}
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

