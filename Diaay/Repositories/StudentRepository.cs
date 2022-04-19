using Diary.Database;
using System;
using System.Data.SqlClient;

namespace Diary.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly IDatabaseConnection databaseConnection;

        public StudentRepository(IDatabaseConnection databaseConnection)
        {
            this.databaseConnection = databaseConnection;
        }

        public void GetAll()
        {
            var sql = "Select * from students";
            databaseConnection.ExecuteReader(sql, out SqlDataReader students);
            while (students.Read())
            {
                Console.WriteLine($"{students.GetInt32(0),-4} {students.GetString(1),-10} {students.GetString(2),-10}");
            }
        }

        public void Add(string firstName, string lastName)
        {
            var sql = "INSERT INTO students VALUES('" + firstName + "', '" + lastName + "');";
            databaseConnection.ExecuteNonQuery(sql);
            Console.WriteLine("Udało się dodać studenta " + firstName + " " + lastName);
        }

        public void Delete(string firstName, string lastName)
        {
            var sql = string.Format("DELETE FROM students WHERE first_name='{0}' and last_name='{1}'", firstName, lastName);
            databaseConnection.ExecuteNonQuery(sql);
            Console.WriteLine("Udało się usunąć " + firstName + " " + lastName);
        }
    }
}