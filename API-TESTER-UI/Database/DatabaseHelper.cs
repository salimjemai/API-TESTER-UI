using System;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Windows;
using API_TESTER_UI.Utilities;

namespace API_TESTER_UI.Database
{
    public static class DatabaseHelper
    {
        private static readonly string _config = ConfigurationManager.AppSettings["build"];
        private const string ConnectionString = @"Data Source=.\APITESTData.db;Version=3;";

        public static void InitializeDatabase()
        {
            var connectionPath = @".\APITESTData.db";
            if (File.Exists(connectionPath))
            {
                Log.Debug("DatabaseHelper - Database file exists ... {0}", "InitializeDatabase()");
                return;
            }

            Log.Debug($"DatabaseHelper - Database file doesn't exists, now the DB file will be created ...");
            SQLiteConnection.CreateFile(connectionPath);
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                Log.Info($"Opening Database connection ...");
                connection.Open();

                // create tables
                const string createSessionsQuery = @"
                        CREATE TABLE IF NOT EXISTS Sessions ( 
                              SessionToken BLOB PRIMARY KEY, 
                              DateCreated datetime default current_timestamp,
                              IsTokenValid INTEGER CHECK (IsTokenValid IN (0,1)), 
                              CreatedBy TEXT, 
                              CwsUrl TEXT, 
                              SchemaAlias TEXT);";

                Log.Debug($"Creating Session table ...");
                // SessionToken, DateCreated, IsTokenValid, CreatedBy, CwsUrl, SchemaAlias
                using (var command = new SQLiteCommand(connection))
                {
                    command.CommandText = createSessionsQuery;
                    command.ExecuteNonQuery();
                }
            }
        }

        private static SQLiteConnection OpenConnection()
        {
            SQLiteConnection conn = null;
            try
            {
                var connection = new SQLiteConnection(ConnectionString);
                connection.Open();
                if (connection.State == ConnectionState.Open)
                    return conn = connection;
                throw new Exception("Failure to Open a connection, see exception detail ");
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                MessageBox.Show("Failure to open a sql connection, try again.", "Open Connection", MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }

            return conn;
        }

        public static void CloseConnection()
        {
            var connection = new SQLiteConnection(ConnectionString);
            connection.Close();
        }

        public static SQLiteDataReader SelectRecords(string sqlQuery)
        {
            var conn = OpenConnection();
            SQLiteDataReader sqlData = null;
            try
            {
                var sqlCommand = new SQLiteCommand(sqlQuery, conn);
                sqlData = sqlCommand.ExecuteReader();
            }
            catch (Exception e)
            {
                Log.Error($"An error occurred while reading from the database, see exception details here: {e.Message}");
            }

            return sqlData;
        }

        public static bool WriteDataIntoSession(string token, DateTime dateCreated, int isTokenValid, string createdBy,
            string cwsUrl, string schemaAlias)
        {
            var returnCode = false;
            try
            {
                var conn = OpenConnection();
                var command = conn.CreateCommand();
                command.CommandType = CommandType.Text;

                command.CommandText =
                    @"insert into Sessions(SessionToken, DateCreated, IsTokenValid, CreatedBy, CwsUrl, SchemaAlias) values (@token, @dateCreated, @isTokenValid, @createdBy, @cwsUrl, @schemaAlias)";
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
                Log.Error($"Error occurred while writing to the database, {e.Message}");
            }

            return returnCode;
        }

        public static bool DeleteSession(string token)
        {
            var deletedRow = false;
            try
            {
                var conn = OpenConnection();

                Log.Debug($"Deleting token: {token}");
                using (var command = new SQLiteCommand("DELETE FROM Sessions WHERE SessionToken = '" + token + "'", conn))
                {
                    command.ExecuteNonQuery();
                }

                conn.Close();
                deletedRow = true;
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                MessageBox.Show($"Failure to delete the session records see exception details here: {ex}.",
                    "Delete session", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return deletedRow;
        }
    }
}