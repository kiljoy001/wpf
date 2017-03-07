using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
//abstracted class that collects hash from the database for logins
namespace wpf
{
    public class getHash : AbstractedSQL
    {
        string hash = null;
        string selectPwd = "SELECT user_password from site_login where user_login like @login";
        public getHash(string email)
        {
            using (SqlConnection dbConnect = new SqlConnection())
            {
                dbConnect.ConnectionString = connection;
                SqlCommand getPwd = new SqlCommand(selectPwd);
                try
                {
                    
                    dbConnect.Open();
                    getPwd.Connection = dbConnect;
                    getPwd.CommandType = CommandType.Text;
                    getPwd.Parameters.AddWithValue("@login", email);
                    SqlDataReader return_value = getPwd.ExecuteReader();
                    if (return_value.HasRows)
                    {
                        while (return_value.Read()) { hash = return_value.GetString(0); }
                    }
                    else
                    {
                        throw new ArgumentNullException();
                    }
                }
                catch (SqlException se)
                {
                    MessageBox.Show($"An SQL related error has occured.", $"Error: {se.ToString()}");
                }
                catch (Exception e)
                {
                    MessageBox.Show($"Error: {e.ToString()}\n{e.GetType()}", $"An {e.GetType()} error has occured.");
                }
            }
        }
                public string hashValue { get { return hash; } }
            }

        }
