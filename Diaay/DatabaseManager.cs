using System;
using System.Data.SqlClient;

namespace Diaay
{
    public class DatabaseManager
    {
        private SqlConnection _sqlConnection;

        public DatabaseManager()
        {
            ConnectToDatabase();
        }
        

        private void ConnectToDatabase()
        {
            var connectionString = @"Server=.\SQLEXPRESS;Database=Electronic_school_diary;Trusted_Connection=True;";
            _sqlConnection = new SqlConnection(connectionString);
            _sqlConnection.Open();
        }
        
        public void PrintMSSQLVersion()
        {
            var sql = "SELECT @@VERSION";
            using var cmd = new SqlCommand(sql, _sqlConnection);
            var version = cmd.ExecuteScalar().ToString();
            Console.WriteLine("MSSQL VERSION: " + version);
        }
        
        
        public void CheckAllStudents()
        {
            var sql = "Select * from students";
            using var cmd = new SqlCommand(sql, _sqlConnection);
            using SqlDataReader students = cmd.ExecuteReader();
            while(students.Read())
            {
                Console.WriteLine("{0} {1} {2}", students.GetInt32(0), students.GetString(1),students.GetString(2));
            }
        }

        public void AddNewStudent(string firstName, string lastName)
        {
            var sql = "INSERT INTO students VALUES('"+firstName+"', '"+lastName+"');";
            using var cmd = new SqlCommand(sql, _sqlConnection);
            //Bad method
            // using SqlDataReader students = cmd.ExecuteReader();
            //Console.WriteLine(students.Read());
            cmd.ExecuteNonQuery();
            Console.WriteLine("Udało się dodać studenta " +firstName+" "+ lastName);

        }
        public  void DeleteExistStudent(string firstName, string lastName)
        {
            var sql = string.Format("DELETE FROM students WHERE first_name='{0}' and last_name='{1}'",firstName,lastName);
            using var cmd = new SqlCommand(sql, _sqlConnection);
            cmd.ExecuteNonQuery();
            Console.WriteLine("Udało się usunąć " + firstName + " " + lastName);


        }



        
    }
}
