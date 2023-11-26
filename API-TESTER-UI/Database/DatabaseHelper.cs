using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;
using System.Data.SqlClient;
using System.Data;
using System.Windows;
using System.Configuration;
using Google.Protobuf.WellKnownTypes;

namespace API_TESTER_UI.Database
{
    public class DatabaseHelper
    {
        private static readonly string _config = ConfigurationManager.AppSettings["build"];
        private static string connectionString = @"Data Source=.\APITESTData.db;Version=3;";

        public static void InitializeDatabase()
        {
            var connectionPath = @".\APITESTData.db";
            if (!File.Exists(connectionPath))
            {
                SQLiteConnection.CreateFile(connectionPath);
                using (var connection = new SQLiteConnection(connectionString))
                {

                    connection.Open();

                    // create tables
                    string createSessionsQuery = @"
                        CREATE TABLE IF NOT EXISTS Sessions ( 
                              SessionToken BLOB PRIMARY KEY, 
                              DateCreated datetime default current_timestamp,
                              IsTokenValid INTEGER CHECK (IsTokenValid IN (0,1)), 
                              CreatedBy TEXT, 
                              CwsUrl TEXT, 
                              SchemaAlias TEXT);";

                    // SessionToken, DateCreated, IsTokenValid, CreatedBy, CwsUrl, SchemaAlias
                    using (var command = new SQLiteCommand(connection))
                    {
                        command.CommandText = createSessionsQuery;
                        command.ExecuteNonQuery();                        
                    }
                }
            }
        }

        public static SQLiteConnection openConnection()
        {
            SQLiteConnection conn = null;
            try
            {
                SQLiteConnection connection = new SQLiteConnection(connectionString);
                connection.Open();
                if (connection.State == ConnectionState.Open)
                {
                    return conn = connection;
                }
                else
                    throw new Exception($"Failure to Open a connection, see exception detail ");
            }
            catch (Exception e)
            {
                MessageBox.Show("Failure to open a sql connection, try again.", "Open Connection", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return conn;
        }

        public static void CloseConnection()
        {
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            connection.Close();
        }

        public static SQLiteDataReader SelectRecords(string sqlQuery)
        {
            SQLiteConnection conn = openConnection();
            SQLiteDataReader sqlData;
            try
            {
                var sqlCommand = new SQLiteCommand(sqlQuery, conn);
                sqlData = sqlCommand.ExecuteReader();
            }
            catch (Exception e)
            {
                throw new Exception($"An error occurred while reading from the databas, see exception details here: {e.Message}");
            }

            return sqlData;
        }

        public static bool WriteDataIntoSession(string token, DateTime dateCreated, int isTokenValid, string createdBy, string cwsUrl, string schemaAlias)
        {
            bool returnCode = false;
            try
            {
                SQLiteConnection conn = openConnection();
                SQLiteCommand command = conn.CreateCommand();
                command.CommandType = CommandType.Text;

                command.CommandText = @"insert into Sessions(SessionToken, DateCreated, IsTokenValid, CreatedBy, CwsUrl, SchemaAlias) values (@token, @dateCreated, @isTokenValid, @createdBy, @cwsUrl, @schemaAlias)";
                command.Parameters.AddWithValue("@token", token);
                command.Parameters.AddWithValue("@dateCreated", dateCreated);
                command.Parameters.AddWithValue("@isTokenValid", isTokenValid);
                command.Parameters.AddWithValue("@createdBy", createdBy);
                command.Parameters.AddWithValue("@cwsUrl", cwsUrl);
                command.Parameters.AddWithValue("@schemaAlias", schemaAlias); 

                command.ExecuteNonQuery();
                conn.Close();
                returnCode = true;
            }
            catch (Exception e)
            {
                throw new Exception($"Error occurred while writing to the database, {e.Message}");
            }
            return returnCode;
        }

        public static bool DeleteSession(string token)
        {
            bool deletedRow = false;
            try
            {
                SQLiteConnection conn = openConnection();

                using (SQLiteCommand command = new SQLiteCommand("DELETE FROM Sessions WHERE SessionToken = '" + token + "'", conn))
                {
                    command.ExecuteNonQuery();
                }
                conn.Close();
                deletedRow = true;
            }
            catch (SystemException ex)
            {
                MessageBox.Show($"Failure to delete the session records see exception details here: {ex}.", "Delete session", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return deletedRow;
        }
    }
}
