using System;
using System.Collections.Generic;
using System.IO;

namespace Cw2
{
    class Program
    {
        public static void Main(string[] args)
        {
            var path = @"C:\Users\Łukasz\Desktop\dane.csv";
            var lines = File.ReadLines(path);
            string[] each;
            Student student;
            foreach (var line in lines)
            {
                each = line.Split(",");
                student = new Student(each);
            }




        }
    }
}

            
            /*var path = @"C:\Users\Łukasz\Desktop\dane.csv";

            var lines = File.ReadLines(path);
            
            foreach (var line in lines)
            {
                Console.WriteLine(line);
            }




            var parsedDate = DateTime.Parse("2020-03-09");
            Console.WriteLine(parsedDate);

            var now = DateTime.UtcNow;
            Console.WriteLine(now);

            var today = DateTime.Today;
            Console.WriteLine(today.ToShortDateString());

            var hash = new HashSet<Student>(new OwnComparer());

            var stud1 = new Student
            {
                FirstName = "Jan",
                LastName = "Kowalski",
                Index = "1234"
            };

            var stud2 = new Student
            {
                FirstName = "Jan",
                LastName = "Kowalski",
                Index = "1234"
            };

            var stud3 = new Student
            {
                FirstName = "Janina",
                LastName = "Nowak",
                Index = "1234"
            };

            var newStud = new Student();

            if(!hash.Add(newStud))
            {
             //   errors.Add(newStud);
            }
            Console.WriteLine(hash.Count);





        }
    }
}
*/