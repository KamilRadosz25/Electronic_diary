using System;

namespace Diaay
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var databaseManager = new DatabaseManager();
            //databaseManager.PrintMSSQLVersion();
            //databaseManager.CheckAllStudents();
            string firstName;
            string lastName;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(" Witaj w Elektornicznym Dzienniku, Wybierz opcje: \n 1.Dodaj Studenta \n 2. Usuń studenta");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(" Opcje wybierasz za pomoca numeru opcji");
            Console.ResetColor();
            bool valid;
            int option;
            valid = int.TryParse(Console.ReadLine(), out option);
            if (valid == true)
            {
                    if (option == 1)
                    {
                        Console.WriteLine("Podaj Imie");
                        firstName = Console.ReadLine();
                        Console.WriteLine("Podaj Nazwisko");
                        lastName = Console.ReadLine();
                        databaseManager.AddNewStudent(firstName, lastName);
                    }
                    else if (option == 2)
                    {
                        Console.WriteLine("Podaj Imie");
                        firstName = Console.ReadLine();
                        Console.WriteLine("Podaj Nazwisko");
                        lastName = Console.ReadLine();
                        databaseManager.DeleteExistStudent(firstName, lastName);
                    }
                    else
                    {
                        Console.WriteLine("Twój wybór nie pasuje do żadnej z opcji");
                    }
            }
            else
            {
                Console.WriteLine("Coś poszlo nie tak");
            }










        }
    }
}
