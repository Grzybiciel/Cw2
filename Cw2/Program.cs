using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace Cw2
{
    public class Program
    {
        public const string author = "Łukasz Grzybowski";

        public static void Main(string[] args)
        {
            var pathCSV = args.Length > 0 ? args[0] : "dane.csv";
            var destination = args.Length > 1 ? args[1] : "result.xml";
            var dataFormat = args.Length > 2 ? args[2] : "xml";
            var logPath = "log.txt";

            var log = new StringBuilder();
            var serializer = new XmlSerializer(typeof(University));
            var today = DateTime.Today;

            FileStream writer;
            IEnumerable<string> lines;
            try
            {
                lines = File.ReadLines(pathCSV);
                writer = new FileStream(destination, FileMode.Create);
            }
            catch (FileNotFoundException)
            {
                throw new FileNotFoundException("Plik nie istnieje");
            }
            catch (ArgumentException)
            {
                throw new ArgumentException("Podana sciezka jest niepoprawna");
            }
            var hash = new HashSet<Student>(new OwnComparer());

            var academy = new University();
            var studentList = new List<Student>();
            var activeStudiesList = new Dictionary<string, int>();

            foreach (var line in lines)
            {
                string[] student = line.Split(',');
                if (isLineCorrect(student))
                {
                    var stud = new Student(student);
                    
                    if (hash.Add(stud))
                    {
                        studentList.Add(stud);
                        if (!activeStudiesList.ContainsKey(stud.studies.name))
                        {
                            activeStudiesList.Add(stud.studies.name, 1);
                        }
                        else
                        {
                            activeStudiesList[stud.studies.name] += 1;
                        }
                    }
                    else
                    {
                        log.Append(line + "\n");
                    }
                }
                else
                {
                    log.Append(line + "\n");
                }

            }
            University.date = today.ToShortDateString();
            University.author = Program.author;
            University.Students = studentList;
            University.Studies = new List<ActiveStudies>();
            foreach (KeyValuePair<string, int> pair in activeStudiesList)
            {
                University.Studies.Add(new ActiveStudies
                {
                    name = pair.Key,
                    numberOfStudents = pair.Value.ToString()
                });
            }
            serializer.Serialize(writer, University);

            Console.WriteLine(today.ToShortDateString());
            Console.WriteLine(hash.Count);
            File.WriteAllText(logPath, log.ToString());
        }

        private static bool isLineCorrect(string[] line)
        {
            if (line.Length != 9)
                return false;
            for (int i = 0; i < line.Length; i++)
            {
                if (String.IsNullOrWhiteSpace(line[i]))
                    return false;
            }
            return true;
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