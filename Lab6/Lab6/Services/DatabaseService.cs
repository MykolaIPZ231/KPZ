using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace Lab6.Services
{
    public class DatabaseService
    {
        private const string ConnectionString = "Data Source=qr_codes.db;Version=3;";

        public void InitializeDatabase()
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                const string sql = @"
                    CREATE TABLE IF NOT EXISTS QRCodes(
                        Id        INTEGER PRIMARY KEY,
                        Content   TEXT,
                        FilePath  TEXT,
                        CreatedAt TEXT
                    );";
                new SQLiteCommand(sql, connection).ExecuteNonQuery();
            }
        }

        public void SaveQRCode(string content, string filePath)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                var command = new SQLiteCommand(
                    "INSERT INTO QRCodes(Content, FilePath, CreatedAt) VALUES(@content, @filePath, @createdAt);",
                    connection);

                command.Parameters.AddWithValue("@content", content);
                command.Parameters.AddWithValue("@filePath", filePath);
                command.Parameters.AddWithValue("@createdAt", DateTime.Now.ToString("s"));

                command.ExecuteNonQuery();
            }
        }

        public List<string> GetAllQRCodes()
        {
            var list = new List<string>();
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                var command = new SQLiteCommand("SELECT Content, CreatedAt FROM QRCodes;", connection);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add($"{reader["CreatedAt"]} — {reader["Content"]}");
                    }
                }
            }
            return list;
        }

        public void ClearAllQRCodes()
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                new SQLiteCommand("DELETE FROM QRCodes;", connection).ExecuteNonQuery();
            }
        }
    }
}