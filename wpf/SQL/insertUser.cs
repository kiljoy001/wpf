using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Windows;
//untested abstraction
namespace wpf
{
    public class insertUser : AbstractedSQL
    {
        public insertUser(string password, string fName, string lName, string phone, string login, string cname, string ctitle, string caddr, string czip, string cstate, string city)
        {
            using (SqlConnection dbConnection = new SqlConnection())
            {
                dbConnection.ConnectionString = connection;
                SqlCommand newUser = new SqlCommand();
                try
                {
                    dbConnection.Open();
                    newUser.Connection = dbConnection;
                    newUser.CommandType = CommandType.StoredProcedure;
                    newUser.CommandText = "[dbo].[insertUser]";
                    newUser.Parameters.Clear();
                    newUser.Parameters.Add("@login", SqlDbType.NVarChar, 60).Value = login;
                    newUser.Parameters.Add("@password", SqlDbType.NVarChar, 60).Value = password;
                    newUser.Parameters.Add("@fname", SqlDbType.NVarChar, 60).Value = fName;
                    newUser.Parameters.Add("@lname", SqlDbType.NVarChar, 60).Value = lName;
                    newUser.Parameters.Add("@phone", SqlDbType.NVarChar, 11).Value = phone;
                    newUser.Parameters.Add("@cname", SqlDbType.NVarChar, 255).Value = cname;
                    newUser.Parameters.Add("@ctitle", SqlDbType.NVarChar, 60).Value = ctitle;
                    newUser.Parameters.Add("@caddr", SqlDbType.NVarChar, 255).Value = caddr;
                    newUser.Parameters.Add("@czip", SqlDbType.NVarChar, 6).Value = czip;
                    newUser.Parameters.Add("@cstate", SqlDbType.NVarChar, 2).Value = cstate;
                    newUser.Parameters.Add("@city", SqlDbType.NVarChar, 60).Value = city;

                }
                catch (SqlException se)
                {
                    MessageBox.Show($"An SQL related error has occured.", $"Error: {se.ToString()}");
                }
                catch(Exception e)
                {
                    MessageBox.Show($"Error: {e.ToString()}\n{e.GetType()}", $"An {e.GetType()} error has occured.");
                }
            }
        }
        
    
    }
}