using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
//inserts product into database, uses a stored procedure called insertProduct
namespace wpf.SQL
{
    class insertProduct : AbstractedSQL
    {
        public insertProduct(string pName, int pAmount, double pPrice)
        {
            using (SqlConnection dbConnection = new SqlConnection())
            {
                dbConnection.ConnectionString = connection;
                dbConnection.Open();
                SqlTransaction trans = dbConnection.BeginTransaction();
                SqlCommand newProduct = dbConnection.CreateCommand();
                newProduct.Transaction = trans;
                try
                {
                    newProduct.Connection = dbConnection;
                    newProduct.CommandType = CommandType.StoredProcedure;
                    newProduct.CommandText = "[dbo].[insertProduct]";
                    newProduct.Parameters.Add("@pName", SqlDbType.NVarChar, 100).Value = pName;
                    newProduct.Parameters.Add("@pUnits", SqlDbType.Int).Value = pAmount;
                    newProduct.Parameters.Add("@pPrice", SqlDbType.SmallMoney).Value = pPrice;
                    Guid pGuid = Guid.NewGuid();
                    newProduct.Parameters.Add("@pGUID", SqlDbType.UniqueIdentifier).Value = pGuid;
                    newProduct.Parameters.Add("@login", SqlDbType.NVarChar, 60).Value = Properties.Settings.Default.user_login;
                    newProduct.ExecuteScalar();
                    trans.Commit();
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
}
