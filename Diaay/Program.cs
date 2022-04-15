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
                Console.WriteLine(" Witaj w Elektornicznym Dzienniku, Wybierz opcje: \n 1.Dodaj Studenta \n 2. Usuń studenta \n 3.Wyświetl liste studentów \n 4.Dodawanie oceny dla studenta");
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
                        case 4:
                            try
                            {
                                Console.WriteLine("Podaj Imie  i nazwisko");
                                var s = Console.ReadLine();
                                string[] subs = s.Split(' ');
                                firstName = subs[0];
                                lastName = subs[1];
                                Console.WriteLine("Za co i z jakiego przedmiotu chcesz dodać ocene dla " + firstName + " " + lastName + " ?");
                                var type = Console.ReadLine();
                                var subject = Console.ReadLine();
                                var mark = int.Parse(Console.ReadLine());
                                databaseManager.AddNewMark(firstName, lastName, subject, type, mark);
                            }
                            catch (System.Data.SqlClient.SqlException)
                            {
                                Console.WriteLine("Źle wprowadziłeś dane, prawdpodobnie podałeś imie i nazwisko studenta którego nie ma na liście");
                            }
                            catch(IndexOutOfRangeException)
                            {
                                Console.WriteLine("Prawdopodobnie nie podałeś całego imienia i nazwiska");
                            }
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
