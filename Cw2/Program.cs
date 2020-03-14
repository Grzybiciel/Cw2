using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using System.Xml;
using Newtonsoft.Json;


namespace Cw2
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = @"C:\Users\Łukasz\Desktop\dane.csv";
            var resultPath = @"C:\Users\Łukasz\Desktop\result.xml";
            var resultFormat = "xml";

            var log = new StringBuilder();

            try
            {
                if (args.Length != 3)
                    throw new ArgumentException("Wrong number of arguments");
                if (args.Length == 3)
                {
                    if (!(args[2] == "xml" || args[2] == ".xml" || args[2] == "json" || args[2] == ".json"))
                    {
                        throw new ArgumentException("Unable to save in this format");
                    }
                    resultFormat = args[2];
                    if (!Directory.Exists((resultPath)))
                    {
                        throw new ArgumentException("Incorrect path");
                    }
                    resultPath = "@" + args[1];
                    if (!File.Exists(path))
                    { 
                        throw new FileNotFoundException("File " + path + " does not exist.");
                    }
                    path = "@" + args[0];
                }
            }
            catch (Exception ex)
            {
                log.Append(ex.Message);
                path = @"C:\Users\Łukasz\Desktop\dane.csv";
                resultPath = @"C:\Users\Łukasz\Desktop\result.xml";
                resultFormat = "xml";
            }


            var university = new University {
                date = DateTime.Today.ToString("dd.MM.yyyy"),
                author = "Łukasz Grzybowski",
                students = new HashSet<Student>(new OwnComparer()),
                studies = new List<ActiveStudies>()
            };
            var allLines = File.ReadLines(path);
            HashSet<Student> studentsHashSet = university.students;

            foreach (var line in allLines)
            {
                var eachStudent = line.Split(",");
                if (eachStudent.Length != 9)
                {
                    log.Append("Wrong number of columns in this line: " + line);
                    continue;
                }

                var stud = new Student(eachStudent);

                if (!studentsHashSet.Add(stud))
                {
                    log.Append("This student already exists: " + stud.FirstName + " " + stud.LastName + " " + stud.Index + " ");
                }
                else
                {
                    var flag2 = true;
                    foreach (var stud2 in university.studies)
                    {
                        if (stud2.name == stud.studies.name)
                        {
                            stud2.numberOfStudents++;
                            flag2 = false;
                            break;
                        }
                    }

                    if (flag2 == true)
                    {
                        university.studies.Add(new ActiveStudies
                        {
                            name = stud.studies.name,
                            numberOfStudents = 1
                        });
                    }
                }

                var flag = true;
                foreach (var line2 in eachStudent)
                {
                    if (line2.Length != 0)
                    {
                        continue;
                    }
                    log.Append("One or more columns are empty in this line: " + line);
                    flag = false;
                    break;
                }

                if (!flag)
                {
                    continue;
                }

                
            }

            File.WriteAllText(@"C:\Users\Łukasz\Desktop\log.txt", log.ToString());
            if (resultFormat == "xml")
            {
                var serializer = new XmlSerializer(typeof(University));
                var writer = new FileStream(resultPath, FileMode.Create);
                serializer.Serialize(writer, university, new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty}));
            }
            else if (resultFormat == "json")
            {
                var pathToJSON = resultPath;
                University universityToJSON = university;
                string json = JsonConvert.SerializeObject(universityToJSON);
                File.WriteAllText(pathToJSON, json);
            }
        }
    }

}