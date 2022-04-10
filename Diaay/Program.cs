using System;

namespace Diaay
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var databaseManager = new DatabaseManager();
            

            //databaseManager.PrintMSSQLVersion();
            
            databaseManager.CheckAllStudents();


        }
    }
}
