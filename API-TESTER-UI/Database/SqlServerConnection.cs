//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//// added after class
//using System.Data;
//using System.Windows;
//using System.Data.SqlClient;
//using System.Configuration;
//using System.Security.Policy;
//using System.Data.Common;

//namespace API_TESTER_UI.Database
//{
//    public class SqlServerConnection
//    {
//        public string GetConnectionString()
//        {
//            string strConnString = ConfigurationManager.ConnectionStrings["conString"].ToString();
//            return strConnString;
//        }


//        public SqlConnection openConnection()
//        {
//            SqlConnection conn = null;
//            try
//            {
//                SqlConnection connection = new SqlConnection(GetConnectionString());
//                connection.Open();
//                if (connection.State == ConnectionState.Open)
//                {
//                    return conn = connection;
//                }
//                else
//                    throw new Exception($"Failure to Open a connection, see exception detail ");
//            }
//            catch(Exception e)
//            {
//                MessageBox.Show("Failure to open a sql connection, try again.","Open Connection", MessageBoxButton.OK ,MessageBoxImage.Error);
//            }
//            return conn;
//        }

//        public void closeConnection()
//        {
//            SqlConnection connection = new SqlConnection(GetConnectionString());
//            connection.Close();
//        }

//        public SqlDataReader SelectRecords(string sqlQuery)
//        {
//            SqlConnection conn = openConnection();
//            SqlDataReader sqlData;
//            try
//            {
//                SqlCommand sqlCommand = new SqlCommand(sqlQuery, conn);
//                sqlData =  sqlCommand.ExecuteReader();
//            }
//            catch (Exception e)
//            {
//                throw new Exception($"An error occurred while reading from the databas, see exception details here: {e.Message}");
//            }

//            return sqlData;
//        }

//        public void WriteDataIntoSession(string token, DateTime dateCreated, int isTokenValid, string createdBy, string cwsUrl, string schemaAlias)
//        {
//            try
//            {
//                SqlConnection conn = openConnection();
//                string sqlQuery = "Insert into Sessions(SessionToken, DateCreated, IsTokenValid, CreatedBy, CwsUrl, SchemaAlias)" +
//                                               "Values(@sessionToken, @dateNow, @IsTokenValid, @LoginID, @CwsUrl, @SchemaAliasNameText)";
//                using (SqlCommand wrtieSessionInfo = new SqlCommand(sqlQuery, conn))
//                {
//                    wrtieSessionInfo.Parameters.Add("@sessionToken", SqlDbType.NVarChar);
//                    wrtieSessionInfo.Parameters.Add("@dateNow", SqlDbType.DateTime2);
//                    wrtieSessionInfo.Parameters.Add("@IsTokenValid", SqlDbType.Int);
//                    wrtieSessionInfo.Parameters.Add("@LoginID", SqlDbType.NVarChar);
//                    wrtieSessionInfo.Parameters.Add("@CwsUrl", SqlDbType.NVarChar);
//                    wrtieSessionInfo.Parameters.Add("@SchemaAliasNameText", SqlDbType.NVarChar);

//                    wrtieSessionInfo.Parameters["@sessionToken"].Value = token;
//                    wrtieSessionInfo.Parameters["@dateNow"].Value = dateCreated;
//                    wrtieSessionInfo.Parameters["@IsTokenValid"].Value = isTokenValid;
//                    wrtieSessionInfo.Parameters["@LoginID"].Value = createdBy;
//                    wrtieSessionInfo.Parameters["@CwsUrl"].Value = cwsUrl;
//                    wrtieSessionInfo.Parameters["@SchemaAliasNameText"].Value = schemaAlias;

//                    wrtieSessionInfo.ExecuteNonQuery();
//                    conn.Close();
//                }
//            }
//            catch (Exception e)
//            {
//                throw new Exception($"Error occurred while writing to the database, {e.Message}");
//            }
//        }

//        public void DeleteSession(string token)
//        {
//            try
//            {
//                SqlConnection conn = openConnection();

//                using (SqlCommand command = new SqlCommand("DELETE FROM Sessions WHERE SessionToken = '" + token + "'", conn))
//                {
//                    command.ExecuteNonQuery();
//                }
//                conn.Close();
//            }
//            catch (SystemException ex)
//            {
//                MessageBox.Show($"Failure to delete the session records see exception details here: {ex}.", "Delete session", MessageBoxButton.OK, MessageBoxImage.Error);
//            }
//        }
//    }
//}
