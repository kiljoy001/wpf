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
        private List<product> products_fetch = new List<product>();

        public showProducts()
        {

            string selectData = "Select [product_name], [product_units] ,[product_price], [product_enable], [product_guid] FROM [dbo].[Product]";
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
                    using (SqlDataReader return_value = selectAll.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        if (return_value.HasRows)
                        {
                              
                            while(return_value.Read())
                            {
                                product temp = new product();
                                temp.Product_name = return_value["product_name"].ToString();
                                temp.Number = (int)return_value["product_units"];
                                temp.Amount = decimal.Parse(return_value["product_price"].ToString());
                                temp.Show_Item = (bool)return_value["product_enable"];
                                temp.ID = (Guid)return_value["product_guid"];
                                products_fetch.Add(temp);
                            }
                        }
                    }
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
                public List<product> result { get { return products_fetch; } }
        }
    }

