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
                    Console.Write("\n\tVälj 1 - 7" +
                    "\n\t[1] Hämta alla elever" +
                    "\n\t[2] Hämta alla elever i en viss klas" +
                    "\n\t[3] Lägga till ny personal" +
                    "\n\t[4] Hämta lärare per avdelning" +
                    "\n\t[5] Hämta alla elever" +
                    "\n\t[6] Hämta alla kurser" +
                    "\n\t[7] Avsluta programmet" +
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
                            TeacherCount(context);
                            break; 
                        case 5:
                            Studentinfo(context);
                            break;
                        case 6:
                            ViewCourses(context);
                            break;
                        case 7:
                            Console.WriteLine("programmet avslutas...");
                            Console.ReadKey();
                            run = false;
                            break;
                    }
                }
            }
        }
        public static void TeacherCount(SampleDBContext context)
        {
            var lärarePerAvdelning = context.Lärares
                    .GroupBy(l => l.Avdelning)
                    .Select(group => new
                    {
                        Avdelning = group.Key,
                        AntalLärare = group.Count()
                    })
                    .ToList();

            Console.WriteLine("\n\tAntal lärare per avdelning:");
            foreach (var avdelning in lärarePerAvdelning)
            {
                Console.Write($"\n\t{avdelning.Avdelning}: {avdelning.AntalLärare} lärare");
            }
            Console.ReadKey();
        }
        public static void Studentinfo(SampleDBContext context)
        {
            var allaElever = context.Students
                    .Select(student => new
                    {
                        ElevId = student.StudentId,
                        Förnamn = student.Person.Förnamn,
                        Efternamn = student.Person.Efternamn,
                        Klass = student.Klass.Klassnamn,
                        Personnummer = student.Person.Personnummer
                    })
                    .ToList();

            Console.WriteLine("\n\tInformation om alla elever:");
            foreach (var elev in allaElever)
            {
                Console.Write($"\n\tElevID: {elev.ElevId}, " +
                    $"\n\tNamn: {elev.Förnamn} {elev.Efternamn}, " +
                    $"\n\tKlass: {elev.Klass}" +
                    $"\n\tPersonnummer {elev.Personnummer}" +
                    $"\n\t");
            }
            Console.ReadKey();
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

        public static void ViewCourses(SampleDBContext context)
        {
            var allaKurser = context.Kurs
                    .Select(kurs => new
                    {
                        KursId = kurs.KursId,
                        Kursnamn = kurs.Kursnamn
                    })
                    .ToList();

            Console.WriteLine("\n\tLista över alla kurser:");
            foreach (var kurs in allaKurser)
            {
                Console.Write($"\n\tKursID: {kurs.KursId}, " +
                    $"\n\tKursnamn: {kurs.Kursnamn}" +
                    $"\n\t");
            }
            Console.ReadKey();
        }

        static void GetStudentsInClass(SampleDBContext context)
        {
            var classes = context.Klasses.ToList();

            Console.WriteLine("\n\tVälj en klass:");
            foreach (var c in classes)
            {
                Console.WriteLine($"\n\t{c.KlassId}. {c.Klassnamn}");
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
