using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace wpf.SQL
{
    class insertProduct : AbstractedSQL
    {
        public insertProduct(string pName, string pAmount, string pPrice)
        {
            using (SqlConnection dbConnection = new SqlConnection())
            {
                dbConnection.ConnectionString = connection;
                SqlTransaction trans = dbConnection.BeginTransaction();
                SqlCommand newProduct = dbConnection.CreateCommand();
                newProduct.Transaction = trans;
                try
                {
                    dbConnection.Open();
                    newProduct.Connection = dbConnection;
                    newProduct.CommandType = CommandType.StoredProcedure;
                    newProduct.CommandText = "[dbo].[insertProduct]";
                    newProduct.Parameters.Add("@pName", SqlDbType.NVarChar, 100).Value = pName;
                    newProduct.Parameters.Add("@pAmount", SqlDbType.Int).Value = pAmount;
                    newProduct.Parameters.Add("@pPrice", SqlDbType.SmallMoney).Value = pPrice;
                    string pGuid = Guid.NewGuid().ToString();
                    newProduct.Parameters.Add("@pGUID", SqlDbType.UniqueIdentifier).Value = pGuid;
                    newProduct.ExecuteScalar();
                    trans.Commit();
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
    }
}
