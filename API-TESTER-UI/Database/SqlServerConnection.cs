using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// added after class
using System.Data;
using System.Windows;
using System.Data.SqlClient;
using System.Configuration;
using System.Security.Policy;
using System.Data.Common;

namespace API_TESTER_UI.Database
{
    public class SqlServerConnection
    {
        public string GetConnectionString()
        {
            string strConnString = ConfigurationManager.ConnectionStrings["conString"].ToString();
            return strConnString;
        }


        public SqlConnection openConnection()
        {
            SqlConnection conn = null;
            try
            {
                SqlConnection connection = new SqlConnection(GetConnectionString());
                connection.Open();
                if (connection.State == ConnectionState.Open)
                {
                    return conn = connection;
                }
                else
                    throw new Exception($"Failure to Open a connection, see exception detail ");
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return conn;
        }

        public void closeConnection()
        {
            SqlConnection connection = new SqlConnection(GetConnectionString());
            connection.Close();
        }

        public SqlDataReader SelectRecords(string sqlQuery)
        {
            SqlConnection conn = openConnection();
            SqlDataReader sqlData;
            try
            {
                SqlCommand sqlCommand = new SqlCommand(sqlQuery, conn);
                sqlData =  sqlCommand.ExecuteReader();
                //conn.Close();
            }
            catch (Exception e)
            {
                throw new Exception($"An error occurred while reading from the databas, see exception details here: {e.Message}");
            }

            return sqlData;
        }

        public void WriteDataIntoSession(string token, DateTime dateCreated, int isTokenValid, string createdBy, string cwsUrl, string schemaAlias)
        {
            try
            {
                SqlConnection conn = openConnection();
                string sqlQuery = "Insert into Sessions(SessionToken, DateCreated, IsTokenValid, CreatedBy, CwsUrl, SchemaAlias)" +
                                               "Values(@sessionToken, @dateNow, @IsTokenValid, @_LoginID, @_CwsUrl, @_SchemaAliasNameText)";
                using (SqlCommand wrtieSessionInfo = new SqlCommand(sqlQuery, conn))
                {
                    wrtieSessionInfo.Parameters.Add("@sessionToken", SqlDbType.NVarChar);
                    wrtieSessionInfo.Parameters.Add("@dateNow", SqlDbType.DateTime2);
                    wrtieSessionInfo.Parameters.Add("@IsTokenValid", SqlDbType.Int);
                    wrtieSessionInfo.Parameters.Add("@_LoginID", SqlDbType.NVarChar);
                    wrtieSessionInfo.Parameters.Add("@_CwsUrl", SqlDbType.NVarChar);
                    wrtieSessionInfo.Parameters.Add("@_SchemaAliasNameText", SqlDbType.NVarChar);

                    wrtieSessionInfo.Parameters["@sessionToken"].Value = token;
                    wrtieSessionInfo.Parameters["@dateNow"].Value = dateCreated;
                    wrtieSessionInfo.Parameters["@IsTokenValid"].Value = isTokenValid;
                    wrtieSessionInfo.Parameters["@_LoginID"].Value = createdBy;
                    wrtieSessionInfo.Parameters["@_CwsUrl"].Value = cwsUrl;
                    wrtieSessionInfo.Parameters["@_SchemaAliasNameText"].Value = schemaAlias;

                    wrtieSessionInfo.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Error occurred while writing to the database, {e.Message}");
            }
        }
    }
}
