using Labb_3___Anropa_databasen_Linus_Aspelöf_SUT23.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb_3___Anropa_databasen_Linus_Aspelöf_SUT23
{
    internal class Menu
    {
        static public void StartMenu()
        {
            bool run = true;

            while (run)
            {
                using (var context = new SampleDBContext())
                {
                    Console.Clear();
                    Console.Write("\n\tVälj 1 - 3" +
                    "\n\t[1] Hämta alla elever" +
                    "\n\t[2] Hämta alla elever i en viss klas" +
                    "\n\t[3] Lägga till ny personal" +
                    "\n\t[4] Avsluta programmet" +
                    "\n" +
                    "\n\tVälj: ");

                    int.TryParse(Console.ReadLine(), out int input);

                    switch (input)
                    {
                        case 1:
                            GetStudents(context);
                            break;
                        case 2:
                            GetStudentsInClass(context);
                            break;
                        case 3:
                            AddNewPerson(context);
                            break;
                        case 4:
                            Console.WriteLine("programmet avslutas...");
                            Console.ReadKey();
                            run = false;
                            break;
                    }
                }
            }
        }

        static void GetStudents(SampleDBContext context)
        {
            Console.Write("\n\tVälj sortering (1 för förnamn, 2 för efternamn): " +
                "\n" +
                "\n\tVälj: ");
            int sortChoice = int.Parse(Console.ReadLine());

            var query = context.Students.Include(s => s.Person);

            var students = sortChoice == 1
                ? query.OrderBy(s => s.Person.Förnamn).ToList()
                : query.OrderBy(s => s.Person.Efternamn).ToList();

            foreach (var student in students)
            {
                Console.Write($"\n\t{student.Person.Förnamn} {student.Person.Efternamn}");
            }
            Console.ReadKey();
        }
        static void GetStudentsInClass(SampleDBContext context)
        {
            var classes = context.Classes.ToList();

            Console.WriteLine("\n\tVälj en klass:");
            foreach (var c in classes)
            {
                Console.WriteLine($"\n\t{c.KlassId}. {c.Kursnamn}");
            }

            int classChoice;
            if (int.TryParse(Console.ReadLine(), out classChoice))
            {
                var studentsInClass = context.Students
                    .Include(s => s.Person)
                    .Where(s => s.KlassId == classChoice)
                    .OrderBy(s => s.Person.Efternamn)
                    .ToList();

                if (studentsInClass != null)
                {
                    foreach (var student in studentsInClass)
                    {
                        Console.Write($"\n\t{student.Person?.Förnamn} {student.Person?.Efternamn}");
                    }
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("\n\tInga elever hittades i vald klass.");
                }
            }
            else
            {
                Console.WriteLine("\n\tOgiltigt inmatning. Ange en giltig siffra.");
            }
        }
        static void AddNewPerson(SampleDBContext context)
        {
            Console.Clear();
            Console.Write("\n\tAnge förnamn: ");
            string firstName = Console.ReadLine();

            Console.Clear();
            Console.Write("\n\tAnge efternamn: ");
            string lastName = Console.ReadLine();

            Console.Clear();
            Console.Write("\n\tAnge personnummer: ");
            string personnummer = Console.ReadLine();

            Console.Clear();
            Console.Write("\n\tAnge befattning: ");
            string position = Console.ReadLine();

            var newPerson = new Person
            {
                Förnamn = firstName,
                Efternamn = lastName,
                Personnummer = personnummer,
                Befattning = position
            };
            context.People.Add(newPerson);
            context.SaveChanges();
        }

    }
}
