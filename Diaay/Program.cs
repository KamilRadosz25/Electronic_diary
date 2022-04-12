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
            string firstName, lastName;
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(" Witaj w Elektornicznym Dzienniku, Wybierz opcje: \n 1.Dodaj Studenta \n 2. Usuń studenta");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" Opcje wybierasz za pomoca numeru opcji");
                Console.ResetColor();
                int option;
                var valid = int.TryParse(Console.ReadLine(), out option);
                if (valid)
                {
                    switch (option)
                    {
                        case 1:
                            Console.WriteLine("Podaj Imie");
                            firstName = Console.ReadLine();
                            Console.WriteLine("Podaj Nazwisko");
                            lastName = Console.ReadLine();
                            databaseManager.AddNewStudent(firstName, lastName);
                            break;
                        case 2:
                            Console.WriteLine("Podaj Imie");
                            firstName = Console.ReadLine();
                            Console.WriteLine("Podaj Nazwisko");
                            lastName = Console.ReadLine();
                            databaseManager.DeleteExistStudent(firstName, lastName);
                            break;
                        case 3:
                            databaseManager.CheckAllStudents();
                            break;

                        default:
                            Console.WriteLine("Twój wybór nie pasuje do żadnej z opcji");
                            break;

                    }
                }
                else
                {
                    Console.WriteLine("Coś poszlo nie tak");
                }
            }
        }
    }
}
