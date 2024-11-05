using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studentregistrering
{
    internal class FrontDesk
    {

        public void Start()
        {
            var dbCtx = new StudentDbContext();

            bool done = false;
            while (!done)
            {
                Console.WriteLine("Välj ett alternativ:");
                Console.WriteLine("1. Registrera ny elev");
                Console.WriteLine("2. Ändra en elev");
                Console.WriteLine("3. Lista alla elever");
                Console.WriteLine("4. Avsluta");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddStudent(dbCtx);
                        break;
                    case "2":
                        UpdateStudent(dbCtx);
                        break;
                    case "3":
                        ListStudents(dbCtx);
                        break;
                    case "4":
                        done = true;
                        break;
                    default:
                        Console.WriteLine("Ogiltigt val, försök igen.");
                        break;
                }

            }

        }
        private void AddStudent(StudentDbContext dbCtx)
        {
            Console.WriteLine("Vad heter eleven i förnamn?");
            string firstName = Console.ReadLine();

            Console.WriteLine("Vad heter eleven i efternamn?");
            string lastName = Console.ReadLine();

            Console.WriteLine("I vilken stad bor eleven?");
            string city = Console.ReadLine();

            var student = new Student()
            {
                FirstName = firstName,
                LastName = lastName,
                City = city
            };
            dbCtx.Add(student);
            dbCtx.SaveChanges();
        }

        private void UpdateStudent(StudentDbContext dbCtx)
        {
            Console.WriteLine("Vänligen skriv student-ID för eleven du vill ändra");
            int id = int.Parse(Console.ReadLine());
            
            var student = dbCtx.Students.FirstOrDefault(s => s.StudentId == id);

            if (student == null)
            {
                Console.WriteLine("Student med ID " + id + " kunde inte hittas. Försök igen.");
                return;
            }

            Console.WriteLine("\n1. Ändra förnamn \n2. Ändra efternamn \n3.Ändra stad");
            string choice = Console.ReadLine();


            switch (choice)
            {
                case "1":
                    Console.WriteLine("Skriv in det nya förnamnet");
                    student.FirstName = Console.ReadLine();
                    break;
                case "2":
                    Console.WriteLine("Skriv in det nya efternamnet");
                    student.LastName = Console.ReadLine();
                    break;
                case "3":
                    Console.WriteLine("Skriv in den nya staden");
                    student.City = Console.ReadLine();
                    break;
                default:
                    Console.WriteLine("Ogiltigt val");
                    return;
            }
            dbCtx.SaveChanges();
        }

        private void ListStudents(StudentDbContext dbCtx)
        {
            foreach (var student in dbCtx.Students)
            {
                Console.WriteLine($"\nID: {student.StudentId} \nNamn: {student.FirstName} {student.LastName} \nStad: {student.City}\n");
            }

        }
    }
}

