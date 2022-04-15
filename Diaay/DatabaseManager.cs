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
                Console.WriteLine($"{students.GetInt32(0),-4} {students.GetString(1),-10} {students.GetString(2),-10}");
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
        public void AddNewMark(string firstName,string lastName,string subject, string type, int mark)
        {
            var sql = string.Format("INSERT INTO marks(id_student,id_subject,id_type,mark) VALUES((select id_student from students where first_name='{0}' and last_name='{1}'),(select id_subject from subjects where name='{2}'),(select id_type from type_marks where type_mark='{3}'),{4})",firstName,lastName,subject,type,mark);
            using var cmd = new SqlCommand(sql, _sqlConnection);
            cmd.ExecuteNonQuery();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Ocena Dodana");
            Console.ResetColor();

            
        }




        
    }
}
