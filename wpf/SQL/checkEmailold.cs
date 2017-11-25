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
    class checkEmailold : AbstractedSQL
    {
        string email_value = null;
        string selectEmail = "SELECT user_login from site_login where user_login like @login";
        public checkEmailold(string email)
        {
            using (SqlConnection dbConnect = new SqlConnection(this.connection))
            {
                SqlCommand verify = new SqlCommand(selectEmail, dbConnect);
                try
                {
                    verify.Connection = dbConnect;
                    verify.CommandType = CommandType.Text;
                    verify.Parameters.Add("@login", SqlDbType.NChar);
                    verify.Parameters["@login"].Value = email;
                    dbConnect.Open();
                    using (SqlDataReader reader = verify.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            email_value = reader.GetString(0);
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
        public bool check_if_correct(string email)
        {
            if(email_value == email) { return true; }
            else { return false; }         
        }
    }
}
