using System;
using System.Data.SqlClient;

namespace Diary.Database
{
    public class DatabaseConnection : IDatabaseConnection
    {
        private SqlConnection _sqlConnection;

        public DatabaseConnection()
        {
            var connectionString = @"Server=.\SQLEXPRESS;Database=Electronic_school_diary;Trusted_Connection=True;";
            _sqlConnection = new SqlConnection(connectionString);
            //_sqlConnection.Open();
        }

        public int ExecuteNonQuery(string sql)
        {
            using var cmd = new SqlCommand(sql, _sqlConnection);
            return cmd.ExecuteNonQuery();
        }


        public void ExecuteReader(string sql, out SqlDataReader dataReader)
        {
            using var cmd = new SqlCommand(sql, _sqlConnection);
            dataReader = cmd.ExecuteReader();
        }
    }
}