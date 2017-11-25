using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace wpf.SQL
{
    class checkEmail : AbstractedSQL
    {
        string email_value = null;
        string selectEmail = "SELECT [user_login] from [dbo].[site_login] where [user_login] = @login;";
        public checkEmail(string email)
        {
            using (SqlConnection dbConnect = new SqlConnection(this.connection))
            {
                if(dbConnect.IsAvaliable())
                {
                    try
                    {
                        dbConnect.Open();
                        using (SqlCommand verify = new SqlCommand(selectEmail, dbConnect))
                        {
                            //SqlParameter variable = new SqlParameter
                            //{
                            //    ParameterName = "@login",
                            //    Value = email
                            //};
                            verify.Parameters.Add("@login", SqlDbType.NChar).Value = email;
                            using (SqlDataReader reader = verify.ExecuteReader())
                            {
                                if(reader.HasRows)
                                {
                                    while (reader.Read())
                                    {
                                        email_value = (string)reader["user_login"];
                                    }
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
        }
        public bool check_if_correct(string email)
        {
            if (email_value.ToLower().Trim() == email.ToLower().Trim()) { return true; }
            else { return false; }         
        }
    }
}
