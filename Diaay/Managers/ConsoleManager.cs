using Diary.Helpers;
using Diary.Repositories;
using System;

namespace Diary.Manager
{
    public class ConsoleManager
    {
        private readonly IMarkRepository markRepository;
        private readonly IStudentRepository studentRepository;

        public ConsoleManager(IMarkRepository markRepository, IStudentRepository studentRepository)
        {
            this.markRepository = markRepository;
            this.studentRepository = studentRepository;
        }

        public void DisplayWelcomeText()
        {
            ConsoleHelpers.WriteLineWithColor(" Witaj w Elektornicznym Dzienniku, Wybierz opcje: \n 1.Dodaj Studenta \n 2. Usuń studenta \n 3.Wyświetl liste studentów \n 4.Dodawanie oceny dla studenta", ConsoleColor.Cyan);
            ConsoleHelpers.WriteLineWithColor(" Opcje wybierasz za pomoca numeru opcji", ConsoleColor.Red);
            if (int.TryParse(Console.ReadLine(), out int option))
            {
                switch (option)
                {
                    case 1:
                        AddStudent();
                        break;

                    case 2:
                        DeleteStudent();
                        break;

                    case 3:
                        studentRepository.GetAll();
                        break;

                    case 4:
                        AddNewMark();
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

            //Rekurencja facet, a nie żadne while(true) :P
            DisplayWelcomeText();
        }

        private void AddNewMark()
        {
            try
            {
                Console.WriteLine("Podaj Imie  i nazwisko");
                var s = Console.ReadLine();
                string[] subs = s.Split(' ');
                var firstName = subs[0];
                var lastName = subs[1];
                Console.WriteLine("Za co i z jakiego przedmiotu chcesz dodać ocene dla " + firstName + " " + lastName + " ?");
                var type = Console.ReadLine();
                var subject = Console.ReadLine();
                var mark = int.Parse(Console.ReadLine());
                markRepository.Add(firstName, lastName, subject, type, mark);
            }
            catch (System.Data.SqlClient.SqlException)
            {
                Console.WriteLine("Źle wprowadziłeś dane, prawdpodobnie podałeś imie i nazwisko studenta którego nie ma na liście");
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Prawdopodobnie nie podałeś całego imienia i nazwiska");
            }
        }

        private void DeleteStudent()
        {
            Console.WriteLine("Podaj Imie");
            var firstName = Console.ReadLine();
            Console.WriteLine("Podaj Nazwisko");
            var lastName = Console.ReadLine();
            studentRepository.Delete(firstName, lastName);
        }

        private void AddStudent()
        {
            Console.WriteLine("Podaj Imie");
            var firstName = Console.ReadLine();
            Console.WriteLine("Podaj Nazwisko");
            var lastName = Console.ReadLine();
            studentRepository.Add(firstName, lastName);
        }
    }
}